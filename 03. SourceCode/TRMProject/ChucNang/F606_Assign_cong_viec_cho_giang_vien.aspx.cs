using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using IP.Core.IPCommon;
using IP.Core.IPData;
using IP.Core.IPUserService;

using WebUS;
using WebDS;
using WebDS.CDBNames;
using System.Data;

public partial class ChucNang_F606_Assign_cong_viec_cho_giang_vien : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            load_data_2_cbo_ten_giang_vien();
            load_data_2_cbo_hop_dong_loc();
            load_data_2_cbo_noi_dung_tt();
            load_data_2_cbo_trang_thai_cv_gv();
            load_data_2_grv();
        }
    }

    #region Members
    US_GD_GV_CONG_VIEC_MOI m_us_cong_viec_moi = new US_GD_GV_CONG_VIEC_MOI();
    DS_GD_GV_CONG_VIEC_MOI m_ds_cong_viec_moi = new DS_GD_GV_CONG_VIEC_MOI();
    DS_V_GD_GV_CONG_VIEC_MOI m_ds_v_cong_viec_moi = new DS_V_GD_GV_CONG_VIEC_MOI();
    #endregion

    #region Private Methods
    private void load_data_2_grv()
    {
        m_us_cong_viec_moi.loc_du_lieu_giang_vien_cong_viec_moi_f606(m_ds_v_cong_viec_moi, CIPConvert.ToDecimal(m_cbo_ten_giang_vien_loc.SelectedValue)
                                                        , CIPConvert.ToDecimal(m_cbo_so_hop_dong_loc.SelectedValue)
                                                        , CIPConvert.ToDecimal(m_cbo_trang_thai_cv_gv.SelectedValue)
                                                        , CIPConvert.ToDecimal(m_cbo_noi_dung_thanh_toan.SelectedValue));
        m_grv_gd_assign_su_kien_cho_giang_vien.DataSource = m_ds_v_cong_viec_moi.V_GD_GV_CONG_VIEC_MOI;
        m_grv_gd_assign_su_kien_cho_giang_vien.DataBind();
        m_lbl_ket_qua_loc_du_lieu.Text = "Kết quả lọc dữ liệu: " + m_ds_v_cong_viec_moi.V_GD_GV_CONG_VIEC_MOI.Rows.Count + " bản ghi";
        if (m_ds_v_cong_viec_moi.V_GD_GV_CONG_VIEC_MOI.Rows.Count > 0)
        {
            decimal v_dc_tong_tien = get_sum_tien(m_ds_v_cong_viec_moi);
            m_grv_gd_assign_su_kien_cho_giang_vien.FooterRow.Cells[6].Text = CIPConvert.ToStr(v_dc_tong_tien, "#,###");
        }
    }
    private void load_data_2_cbo_ten_giang_vien()
    {
        m_cbo_ten_giang_vien_loc.Items.Clear();
        US_V_DM_GIANG_VIEN v_us_v_dm_giang_vien = new US_V_DM_GIANG_VIEN();
        DS_V_DM_GIANG_VIEN v_ds_v_dm_giang_vien = new DS_V_DM_GIANG_VIEN();
        m_cbo_ten_giang_vien_loc.Items.Add(new ListItem("Tất cả", "0"));
        v_us_v_dm_giang_vien.load_all_giang_vien_CM(v_ds_v_dm_giang_vien);
        for (int v_i = 0; v_i < v_ds_v_dm_giang_vien.V_DM_GIANG_VIEN.Rows.Count; v_i++)
        {
            m_cbo_ten_giang_vien_loc.Items.Add(new ListItem(CIPConvert.ToStr(v_ds_v_dm_giang_vien.V_DM_GIANG_VIEN.Rows[v_i][V_DM_GIANG_VIEN.HO_VA_TEN_DEM]).Trim() + " " + CIPConvert.ToStr(v_ds_v_dm_giang_vien.V_DM_GIANG_VIEN.Rows[v_i][V_DM_GIANG_VIEN.TEN_GIANG_VIEN]).Trim(), CIPConvert.ToStr(v_ds_v_dm_giang_vien.V_DM_GIANG_VIEN.Rows[v_i][V_DM_GIANG_VIEN.ID])));
        }
    }
    private void load_data_2_cbo_hop_dong_loc()
    {
        m_cbo_so_hop_dong_loc.Items.Clear();
        US_V_DM_HOP_DONG_KHUNG v_us_v_dm_hop_dong_khung = new US_V_DM_HOP_DONG_KHUNG();
        DS_V_DM_HOP_DONG_KHUNG v_ds_v_dm_hop_dong_khung = new DS_V_DM_HOP_DONG_KHUNG();
        v_us_v_dm_hop_dong_khung.load_hop_dong_by_id_giang_vien_cm_da_ky(CIPConvert.ToDecimal(m_cbo_ten_giang_vien_loc.SelectedValue), v_ds_v_dm_hop_dong_khung);
        if (v_ds_v_dm_hop_dong_khung.V_DM_HOP_DONG_KHUNG.Rows.Count > 0)
        {
            m_cmd_tao_moi.Enabled = true;
            if (m_cbo_ten_giang_vien_loc.SelectedIndex == 0)
            {
                m_cbo_so_hop_dong_loc.Items.Add(new ListItem("Tất cả", "0"));
            }
            else
            {
                for (int v_i = 0; v_i < v_ds_v_dm_hop_dong_khung.V_DM_HOP_DONG_KHUNG.Rows.Count; v_i++)
                {
                    m_cbo_so_hop_dong_loc.Items.Add(new ListItem(CIPConvert.ToStr(v_ds_v_dm_hop_dong_khung.V_DM_HOP_DONG_KHUNG.Rows[v_i][V_DM_HOP_DONG_KHUNG.SO_HOP_DONG]), CIPConvert.ToStr(v_ds_v_dm_hop_dong_khung.V_DM_HOP_DONG_KHUNG.Rows[v_i][V_DM_HOP_DONG_KHUNG.ID])));
                }
            }
        }
        else
        {
            m_lbl_mess.Text = "Chưa có hợp đồng cho giảng viên này!";
            m_grv_gd_assign_su_kien_cho_giang_vien.DataSource = null;
            m_grv_gd_assign_su_kien_cho_giang_vien.DataBind();
            m_lbl_ket_qua_loc_du_lieu.Text = "";
            m_cmd_tao_moi.Enabled = false;
        }
    }
    private void load_data_2_us_update(int ip_i_stt_row)
    {
        decimal v_dc_id_cong_viec_gv = CIPConvert.ToDecimal(m_grv_gd_assign_su_kien_cho_giang_vien.DataKeys[ip_i_stt_row].Value);
        m_cbo_so_hop_dong_loc.ToolTip = CIPConvert.ToStr(v_dc_id_cong_viec_gv);
        m_us_cong_viec_moi = new US_GD_GV_CONG_VIEC_MOI(v_dc_id_cong_viec_gv);
        load_data_2_cbo_noi_dung_tt(m_us_cong_viec_moi.dcID_HOP_DONG_KHUNG);
        m_cbo_trang_thai_cv_gv.Enabled = false;
    }
    private void us_object_2_form(US_GD_GV_CONG_VIEC_MOI ip_us_v_gd_cv_moi)
    {
        m_cbo_so_hop_dong_loc.SelectedValue = CIPConvert.ToStr(ip_us_v_gd_cv_moi.dcID_HOP_DONG_KHUNG);
        US_DM_HOP_DONG_KHUNG v_us_dm_hd_khung = new US_DM_HOP_DONG_KHUNG(ip_us_v_gd_cv_moi.dcID_HOP_DONG_KHUNG);
        m_cbo_ten_giang_vien_loc.SelectedValue =CIPConvert.ToStr(v_us_dm_hd_khung.dcID_GIANG_VIEN);
        m_cbo_noi_dung_thanh_toan.SelectedValue = CIPConvert.ToStr(ip_us_v_gd_cv_moi.dcID_NOI_DUNG_TT);
        m_cbo_noi_dung_thanh_toan.Enabled = false;
        m_cbo_so_hop_dong_loc.Enabled = false;
        m_cmd_huy.ToolTip = m_cbo_so_hop_dong_loc.SelectedValue;
        m_cbo_noi_dung_thanh_toan.ToolTip = CIPConvert.ToStr(ip_us_v_gd_cv_moi.dcID_NOI_DUNG_TT);
        m_txt_so_luong.Text = CIPConvert.ToStr(ip_us_v_gd_cv_moi.dcSO_LUONG_HE_SO,"#");
        //m_txt_don_gia.Text = CIPConvert.ToStr(ip_us_v_gd_cv_moi.dcDON_GIA, "#,###");
        if (!m_us_cong_viec_moi.IsNGAY_DAT_HANGNull()) m_dat_ngay_bat_dau.SelectedDate = CIPConvert.ToDatetime(CIPConvert.ToStr(m_us_cong_viec_moi.datNGAY_DAT_HANG, "dd/MM/yyyy"), "dd/MM/yyyy");
        //if (!m_us_cong_viec_moi.IsNGAY_NGHIEM_THUNull()) m_dat_ngay_nghiem_thu.SelectedDate = CIPConvert.ToDatetime(CIPConvert.ToStr(m_us_cong_viec_moi.datNGAY_NGHIEM_THU, "dd/MM/yyyy"), "dd/MM/yyyy");
        m_cbo_trang_thai_cv_gv.SelectedValue = CIPConvert.ToStr(ip_us_v_gd_cv_moi.dcID_TRANG_THAI);
        m_txt_ghi_chu.Text = ip_us_v_gd_cv_moi.strGHI_CHU;
    }
    private void form_2_us_object()
    {
        System.Globalization.CultureInfo enUS = new System.Globalization.CultureInfo("en-US");
        DateTime v_dat_out_result;
        m_us_cong_viec_moi.dcID_HOP_DONG_KHUNG = CIPConvert.ToDecimal(m_cbo_so_hop_dong_loc.SelectedValue);
        m_us_cong_viec_moi.dcID_NOI_DUNG_TT = CIPConvert.ToDecimal(m_cbo_noi_dung_thanh_toan.SelectedValue);
        if(m_txt_so_luong.Text != "")
        {
            m_us_cong_viec_moi.dcSO_LUONG_HE_SO = CIPConvert.ToDecimal(m_txt_so_luong.Text);
        }
        if (DateTime.TryParseExact(CIPConvert.ToStr(m_dat_ngay_bat_dau.SelectedDate), "dd/MM/yyyy", enUS, System.Globalization.DateTimeStyles.None, out v_dat_out_result))
        {
            if (m_dat_ngay_bat_dau.SelectedDate != CIPConvert.ToDatetime("01/01/0001"))
                m_us_cong_viec_moi.datNGAY_DAT_HANG = m_dat_ngay_bat_dau.SelectedDate;
            else m_us_cong_viec_moi.datNGAY_DAT_HANG = CIPConvert.ToDatetime("01/01/1900");
        }
        m_us_cong_viec_moi.SetNGAY_NGHIEM_THUNull();
        m_us_cong_viec_moi.SetSO_LUONG_NGHIEM_THUNull();
        m_us_cong_viec_moi.dcDON_GIA = CIPConvert.ToDecimal(m_lbl_don_gia.Text);
        m_us_cong_viec_moi.dcID_TRANG_THAI = CIPConvert.ToDecimal(m_cbo_trang_thai_cv_gv.SelectedValue);
        m_us_cong_viec_moi.strGHI_CHU = m_txt_ghi_chu.Text;
        m_us_cong_viec_moi.dcID_USER_NHAP = get_id_user_by_username(CIPConvert.ToStr(Session["Username"]));
        m_us_cong_viec_moi.SetNAM_THANH_TOANNull();
        m_us_cong_viec_moi.SetTHANG_THANH_TOANNull();

    }
    private void load_data_2_cbo_noi_dung_tt(decimal ip_dc_id_hop_dong)
    {
        US_V_GD_HOP_DONG_NOI_DUNG_TT v_us_gd_hop_dong_noi_dung_tt = new US_V_GD_HOP_DONG_NOI_DUNG_TT();
        DS_V_GD_HOP_DONG_NOI_DUNG_TT v_ds_gd_hop_dong_noi_dung_tt = new DS_V_GD_HOP_DONG_NOI_DUNG_TT();

        // Lấy tất cả các nội dung thanh toán từ phụ lục hợp đồng
        v_us_gd_hop_dong_noi_dung_tt.FillDataset(v_ds_gd_hop_dong_noi_dung_tt, " WHERE ID_HOP_DONG_KHUNG = " + ip_dc_id_hop_dong);
        m_cbo_noi_dung_thanh_toan.DataTextField = V_GD_HOP_DONG_NOI_DUNG_TT.NOI_DUNG_THANH_TOAN;
        m_cbo_noi_dung_thanh_toan.DataValueField = V_GD_HOP_DONG_NOI_DUNG_TT.ID;

        m_cbo_noi_dung_thanh_toan.DataSource = v_ds_gd_hop_dong_noi_dung_tt.V_GD_HOP_DONG_NOI_DUNG_TT;
        m_cbo_noi_dung_thanh_toan.DataBind();
    }
    private void load_data_2_cbo_noi_dung_tt()
    {
        m_cbo_noi_dung_thanh_toan.Items.Clear();
        US_V_GD_HOP_DONG_NOI_DUNG_TT v_us_gd_hop_dong_noi_dung_tt = new US_V_GD_HOP_DONG_NOI_DUNG_TT();
        DS_V_GD_HOP_DONG_NOI_DUNG_TT v_ds_gd_hop_dong_noi_dung_tt = new DS_V_GD_HOP_DONG_NOI_DUNG_TT();
        
        // Lấy tất cả các nội dung thanh toán từ phụ lục hợp đồng
        v_us_gd_hop_dong_noi_dung_tt.load_noi_dung_at_phu_luc_hop_dong(CIPConvert.ToDecimal(m_cbo_so_hop_dong_loc.SelectedValue),v_ds_gd_hop_dong_noi_dung_tt);
        m_cbo_noi_dung_thanh_toan.DataTextField = V_GD_HOP_DONG_NOI_DUNG_TT.NOI_DUNG_THANH_TOAN;
        m_cbo_noi_dung_thanh_toan.DataValueField = V_GD_HOP_DONG_NOI_DUNG_TT.ID;

        m_cbo_noi_dung_thanh_toan.Items.Add(new ListItem("---- Hãy chọn công việc -----","0"));
        for (int v_i = 0; v_i < v_ds_gd_hop_dong_noi_dung_tt.V_GD_HOP_DONG_NOI_DUNG_TT.Rows.Count; v_i++)
        {
            m_cbo_noi_dung_thanh_toan.Items.Add(new ListItem(CIPConvert.ToStr(v_ds_gd_hop_dong_noi_dung_tt.V_GD_HOP_DONG_NOI_DUNG_TT.Rows[v_i][V_GD_HOP_DONG_NOI_DUNG_TT.NOI_DUNG_THANH_TOAN]),CIPConvert.ToStr(v_ds_gd_hop_dong_noi_dung_tt.V_GD_HOP_DONG_NOI_DUNG_TT.Rows[v_i][V_GD_HOP_DONG_NOI_DUNG_TT.ID])));
        }

        if (m_cbo_noi_dung_thanh_toan.Items.Count > 0)
        {
            if (m_cbo_noi_dung_thanh_toan.SelectedIndex != 0)
            {
                decimal v_dc_id_noi_dung_tt = CIPConvert.ToDecimal(m_cbo_noi_dung_thanh_toan.SelectedValue);
                US_V_GD_HOP_DONG_NOI_DUNG_TT v_us_dm_noi_dung_tt = new US_V_GD_HOP_DONG_NOI_DUNG_TT(v_dc_id_noi_dung_tt);
                m_txt_so_luong.Text = CIPConvert.ToStr(v_us_dm_noi_dung_tt.dcSO_LUONG_HE_SO, "#,#");
                m_lbl_don_gia.Text = CIPConvert.ToStr(v_us_dm_noi_dung_tt.dcDON_GIA_HD);
                m_lbl_don_vi.Text = v_us_dm_noi_dung_tt.strDON_VI_TINH;
                m_lbl_mess.Text = "";
                m_cmd_tao_moi.Enabled = true;
            }
        }
        else
        {
            m_lbl_mess.Text = "Hợp đồng này không có phụ lục hợp đồng!";
            m_cmd_tao_moi.Enabled = false;
        }
    }
    private void load_data_2_cbo_trang_thai_cv_gv()
    {
        US_CM_DM_TU_DIEN v_us_tu_dien = new US_CM_DM_TU_DIEN();
        DS_CM_DM_TU_DIEN v_ds_tu_dien = new DS_CM_DM_TU_DIEN();

        v_us_tu_dien.FillDataset(v_ds_tu_dien, " WHERE ID_LOAI_TU_DIEN = " + (int)e_loai_tu_dien.TRANG_THAI_CONG_VIEC_GV);
        m_cbo_trang_thai_cv_gv.Items.Add(new ListItem("Tất cả", "0"));
        for (int v_i = 0; v_i < v_ds_tu_dien.CM_DM_TU_DIEN.Rows.Count; v_i++)
        {
            m_cbo_trang_thai_cv_gv.Items.Add(new ListItem(CIPConvert.ToStr(v_ds_tu_dien.CM_DM_TU_DIEN.Rows[v_i][CM_DM_TU_DIEN.TEN]),CIPConvert.ToStr(v_ds_tu_dien.CM_DM_TU_DIEN.Rows[v_i][CM_DM_TU_DIEN.ID])));
        }
    }
    /// <summary>
    /// Kiểm tra xem số hợp đồng này đã có hay chưa
    /// </summary>
    /// <param name="ip_str_so_hd">Số hợp đồng</param>
    private void clear_form()
    {
        m_txt_so_luong.Text = "";
        m_txt_ghi_chu.Text = "";
        m_lbl_thong_bao_so_hd.Text = "";
        m_lbl_mess.Text = "";
        //m_cbo_trang_thai_cv_gv.SelectedIndex = 0;
    }
    private bool check_hop_dong_noi_dung_cong_viec_unique()
    {
        // Lấy công việc theo số HĐ và ID công việc
        //m_us_cong_viec_moi.FillDataset(m_ds_cong_viec_moi, " WHERE ID_HOP_DONG_KHUNG = " + CIPConvert.ToDecimal(m_cbo_so_hop_dong_loc.SelectedValue) + " AND ID_NOI_DUNG_TT = " + CIPConvert.ToDecimal(m_cbo_noi_dung_thanh_toan.SelectedValue) + " AND NGAY_DAT_HANG = '" +CIPConvert.ToStr(m_dat_ngay_bat_dau.SelectedDate,"dd/MM/yyyy")+"'");
        m_us_cong_viec_moi.kiem_tra_unique_cong_viec(m_ds_cong_viec_moi, CIPConvert.ToDecimal(m_cbo_so_hop_dong_loc.SelectedValue), CIPConvert.ToDecimal(m_cbo_noi_dung_thanh_toan.SelectedValue), m_dat_ngay_bat_dau.SelectedDate);
        if (m_ds_cong_viec_moi.GD_GV_CONG_VIEC_MOI.Rows.Count > 0)
        {
            return true; // Đã tồn tại
        }
        return false; // chưa tồn tại
    }
    private decimal get_id_user_by_username(string ip_strsusername)
    {
        US_HT_NGUOI_SU_DUNG v_us_ht_nguoi_su_dung = new US_HT_NGUOI_SU_DUNG();
        DS_HT_NGUOI_SU_DUNG v_ds_ht_nguoi_su_dung = new DS_HT_NGUOI_SU_DUNG();
        v_us_ht_nguoi_su_dung.FillDataset(v_ds_ht_nguoi_su_dung, " WHERE TEN_TRUY_CAP=N'" + ip_strsusername + "'");
        return CIPConvert.ToDecimal(v_ds_ht_nguoi_su_dung.HT_NGUOI_SU_DUNG.Rows[0][HT_NGUOI_SU_DUNG.ID]);
    }
    private void search_gv_cong_viec_moi_and_load_2_grv()
    {
        // Thu thập dữ liệu từ form tìm kiếm
        string v_str_so_hd = m_cbo_so_hop_dong_loc.SelectedItem.Text;
        decimal v_dc_noi_dung = CIPConvert.ToDecimal(m_cbo_noi_dung_thanh_toan.SelectedValue);
        decimal v_dc_id_trang_thai = CIPConvert.ToDecimal(m_cbo_trang_thai_cv_gv.SelectedValue);
        string v_str_tu_khoa = m_txt_tu_khoa.Text.Trim();
        // Search
        m_us_cong_viec_moi.loc_du_lieu_gv_cong_viec_moi(m_ds_cong_viec_moi, v_str_so_hd, v_dc_noi_dung, v_dc_id_trang_thai, v_str_tu_khoa);
        m_grv_gd_assign_su_kien_cho_giang_vien.DataSource = m_ds_cong_viec_moi.GD_GV_CONG_VIEC_MOI;
        m_grv_gd_assign_su_kien_cho_giang_vien.DataBind();
        m_lbl_ket_qua_loc_du_lieu.Text = "Kết quả lọc dữ liệu: Có " + m_ds_cong_viec_moi.GD_GV_CONG_VIEC_MOI.Rows.Count + " bản ghi phù hợp.";
        if (m_ds_cong_viec_moi.GD_GV_CONG_VIEC_MOI.Rows.Count == 0)
        {
            m_lbl_ket_qua_loc_du_lieu.Text = "Kết quả lọc dữ liệu";
            m_lbl_thong_bao_sau_cap_nhat.Text = "* Không có bản ghi nào phù hợp.";
        }

    }
    private string mapping_so_tien(object ip_obj_so_tien)
    {
        if (ip_obj_so_tien.GetType() == typeof(DBNull)) return "";
        if (CIPConvert.ToDecimal(ip_obj_so_tien) == 0)
            return CIPConvert.ToStr(0);
        return CIPConvert.ToStr(ip_obj_so_tien, "#,###");
    }
    private string mapping_dvt_by_id_noi_dung_tt(decimal ip_dc_id_noi_dung_tt)
    {
        US_V_GD_HOP_DONG_NOI_DUNG_TT v_us_gd_hop_dong_noi_dung_tt = new US_V_GD_HOP_DONG_NOI_DUNG_TT(ip_dc_id_noi_dung_tt);
        if (v_us_gd_hop_dong_noi_dung_tt.IsIDNull()) return "";
        return v_us_gd_hop_dong_noi_dung_tt.strDON_VI_TINH;
    }
    #endregion

    #region Public Interfaces
    public decimal get_sum_tien(DS_V_GD_GV_CONG_VIEC_MOI ip_ds_gd_gv_cong_viec)
    {
        decimal v_dc_sum_tien = 0;
        for (int v_i = 0; v_i < ip_ds_gd_gv_cong_viec.V_GD_GV_CONG_VIEC_MOI.Rows.Count; v_i++)
        {
            if (ip_ds_gd_gv_cong_viec.V_GD_GV_CONG_VIEC_MOI.Rows[v_i][GD_GV_CONG_VIEC_MOI.SO_LUONG_HE_SO].GetType() == typeof(DBNull) || ip_ds_gd_gv_cong_viec.V_GD_GV_CONG_VIEC_MOI.Rows[v_i][V_GD_GV_CONG_VIEC_MOI.DON_GIA].GetType() == typeof(DBNull))
                v_dc_sum_tien += 0;
            else
            {
                if(CIPConvert.ToDecimal(ip_ds_gd_gv_cong_viec.V_GD_GV_CONG_VIEC_MOI.Rows[v_i][GD_GV_CONG_VIEC_MOI.ID_TRANG_THAI]) > ID_TRANG_THAI_CONG_VIEC_GVCM.DA_DUYET_KE_HOACH)
                    v_dc_sum_tien += CIPConvert.ToDecimal(ip_ds_gd_gv_cong_viec.V_GD_GV_CONG_VIEC_MOI.Rows[v_i][V_GD_GV_CONG_VIEC_MOI.SO_LUONG_NGHIEM_THU]) * CIPConvert.ToDecimal(ip_ds_gd_gv_cong_viec.V_GD_GV_CONG_VIEC_MOI.Rows[v_i][GD_GV_CONG_VIEC_MOI.DON_GIA]);
                else v_dc_sum_tien += CIPConvert.ToDecimal(ip_ds_gd_gv_cong_viec.V_GD_GV_CONG_VIEC_MOI.Rows[v_i][V_GD_GV_CONG_VIEC_MOI.SO_LUONG_HE_SO]) * CIPConvert.ToDecimal(ip_ds_gd_gv_cong_viec.V_GD_GV_CONG_VIEC_MOI.Rows[v_i][GD_GV_CONG_VIEC_MOI.DON_GIA]);
            }
        }
        return v_dc_sum_tien;
    }
    public string get_so_tien_thanh_toan(object ip_obj_don_gia, object ip_obj_trang_thai, object ip_obj_so_luong, object ip_obj_so_luong_nghiem_thu)
    {
        string v_str_so_tien_thanh_toan = "";
        //if (ip_obj_so_luong_nghiem_thu.GetType() == typeof(DBNull) || ip_obj_don_gia.GetType() == typeof(DBNull))
        //    v_str_so_tien_thanh_toan = "";
        //else
        {
            if (CIPConvert.ToDecimal(ip_obj_trang_thai) > ID_TRANG_THAI_CONG_VIEC_GVCM.DA_DUYET_KE_HOACH)       
              v_str_so_tien_thanh_toan = CIPConvert.ToStr(CIPConvert.ToDecimal(ip_obj_don_gia) * CIPConvert.ToDecimal(ip_obj_so_luong_nghiem_thu), "#,###");
            else v_str_so_tien_thanh_toan = CIPConvert.ToStr(CIPConvert.ToDecimal(ip_obj_don_gia) * CIPConvert.ToDecimal(ip_obj_so_luong), "#,###");
        }
        return v_str_so_tien_thanh_toan;
    }
    public string mapping_so_hop_dong_by_id(object ip_obj_id_hop_dong)
    {
        US_DM_HOP_DONG_KHUNG v_us_hop_dong_khung = new US_DM_HOP_DONG_KHUNG(CIPConvert.ToDecimal(ip_obj_id_hop_dong));
        return v_us_hop_dong_khung.strSO_HOP_DONG;
    }
    public string mapping_noi_dung_thanh_toan_by_id(object ip_obj_id_noi_dung_tt)
    {
        US_DM_NOI_DUNG_THANH_TOAN v_us_noi_dung_tt = new US_DM_NOI_DUNG_THANH_TOAN(CIPConvert.ToDecimal(ip_obj_id_noi_dung_tt));
        return v_us_noi_dung_tt.strTEN_NOI_DUNG;
    }
    public string mapping_trang_thai_by_id(object ip_obj_id_trang_thai)
    {
        US_CM_DM_TU_DIEN v_us_tu_dien = new US_CM_DM_TU_DIEN(CIPConvert.ToDecimal(ip_obj_id_trang_thai));
        return v_us_tu_dien.strTEN;
    }
    public decimal get_id_by_so_hop_dong(string ip_so_hop_dong)
    {
        US_DM_HOP_DONG_KHUNG v_us_hop_dong = new US_DM_HOP_DONG_KHUNG();
        DS_DM_HOP_DONG_KHUNG v_ds_hop_dong = new DS_DM_HOP_DONG_KHUNG();
        v_us_hop_dong.FillDataset(v_ds_hop_dong, " WHERE SO_HOP_DONG = N'"+ip_so_hop_dong+"'");
        return CIPConvert.ToDecimal(v_ds_hop_dong.DM_HOP_DONG_KHUNG.Rows[0][DM_HOP_DONG_KHUNG.ID]);
    }
    public string get_so_luong(object ip_id_trang_thai, object ip_so_luong_he_so, object ip_so_luong_nghiem_thu)
    {
        if (CIPConvert.ToDecimal(ip_id_trang_thai) > ID_TRANG_THAI_CONG_VIEC_GVCM.DA_DUYET_KE_HOACH)
            return CIPConvert.ToStr(ip_so_luong_nghiem_thu,"#,###");
        return CIPConvert.ToStr(ip_so_luong_he_so,"#,###");
    }
    #endregion

    #region Export Excel
    private void loadDSExprort(ref string strTable)
    {
        int v_i_so_thu_tu = 0;
        // Mỗi cột dữ liệu ứng với từng dòng là label
        foreach (DataRow grv in this.m_ds_v_cong_viec_moi.V_GD_GV_CONG_VIEC_MOI.Rows)
        {
            strTable += "\n<tr>";
            strTable += "\n<td align='center' class='cssTitleReport' style='width:12%;' nowrap='nowrap'><span style='font-family:Times New Roman;font-size:1.1em'>" + ++v_i_so_thu_tu + "</span></td>";
            strTable += "\n<td class='cssTitleReport' style='width:12%;' wrap='wrap'><span style='font-family:Times New Roman;font-size:1.1em'>" + grv[V_GD_GV_CONG_VIEC_MOI.SO_HOP_DONG] + "</span></td>";
            strTable += "\n<td class='cssTitleReport' style='width:12%;' wrap='wrap'><span style='font-family:Times New Roman;font-size:1.1em'>" + grv[V_GD_GV_CONG_VIEC_MOI.HO_VA_TEN_GIANG_VIEN] + "</span></td>";
            strTable += "\n<td class='cssTitleReport' style='width:12%;' wrap='wrap'><span style='font-family:Times New Roman;font-size:1.1em'>" + grv[V_GD_GV_CONG_VIEC_MOI.TEN_NOI_DUNG] + "</span></td>";
            strTable += "\n<td align='right' class='cssTitleReport' style='width:12%;' nowrap='nowrap'><span style='font-family:Times New Roman;font-size:1.1em'>" + mapping_so_tien(grv[V_GD_GV_CONG_VIEC_MOI.DON_GIA]) + "</span></td>";
            strTable += "\n<td class='cssTitleReport' align='center' style='width:12%;' nowrap='nowrap'><span style='font-family:Times New Roman;font-size:1.1em'>" + grv[V_GD_GV_CONG_VIEC_MOI.SO_LUONG_HE_SO] + "</span></td>";
            strTable += "\n<td align='center' class='cssTitleReport' style='width:12%;' nowrap='nowrap'><span style='font-family:Times New Roman;font-size:1.1em'>" + mapping_dvt_by_id_noi_dung_tt(CIPConvert.ToDecimal(grv[V_GD_GV_CONG_VIEC_MOI.ID_NOI_DUNG_TT])) + "</span></td>";// ĐVT
            strTable += "\n<td align='right' class='cssTitleReport' style='width:12%;' nowrap='nowrap'><span style='font-family:Times New Roman;font-size:1.1em'>" + get_so_tien_thanh_toan(grv[V_GD_GV_CONG_VIEC_MOI.DON_GIA], grv[V_GD_GV_CONG_VIEC_MOI.ID_TRANG_THAI], grv[V_GD_GV_CONG_VIEC_MOI.SO_LUONG_HE_SO], grv[V_GD_GV_CONG_VIEC_MOI.SO_LUONG_NGHIEM_THU]) + "</span></td>";
            strTable += "\n<td class='cssTitleReport' style='width:12%;' wrap='wrap'><span style='font-family:Times New Roman;font-size:1.1em'>" + grv[V_GD_GV_CONG_VIEC_MOI.NGAY_DAT_HANG] + "</span></td>";
            strTable += "\n<td class='cssTitleReport' style='width:12%;' wrap='wrap'><span style='font-family:Times New Roman;font-size:1.1em'>" + grv[V_GD_GV_CONG_VIEC_MOI.TEN_TRANG_THAI] + "</span></td>";
            strTable += "\n</tr>";
        }
        decimal v_dc_tong_tien = get_sum_tien(m_ds_v_cong_viec_moi);
        // Đây là đoạn tổng cộng số tiền
        strTable += "\n<tr>";
        strTable += "\n<td style='width:12%; background-color:#B8D7FF' class='cssTitleReport' nowrap='nowrap'>" + "<span style='font-family:Times New Roman; font-size:1.1em'></span></td>";
        strTable += "\n<td style='width:12%; background-color:#B8D7FF' class='cssTitleReport' nowrap='nowrap'><span style='font-family:Times New Roman;  font-weight:bold; font-size:1.1em'>Tổng cộng</span></td>";
        strTable += "\n<td style='width:12%; background-color:#B8D7FF' class='cssTitleReport' nowrap='nowrap'>" + "<span style='font-family:Times New Roman; font-size:1.1em'></span></td>";
        strTable += "\n<td style='width:12%; background-color:#B8D7FF' class='cssTitleReport' nowrap='nowrap'>" + "<span style='font-family:Times New Roman; font-size:1.1em'></span></td>";
        strTable += "\n<td style='width:12%; background-color:#B8D7FF' class='cssTitleReport' nowrap='nowrap'>" + "<span style='font-family:Times New Roman; font-size:1.1em'></span></td>";
        strTable += "\n<td style='width:12%; background-color:#B8D7FF' class='cssTitleReport' nowrap='nowrap'>" + "<span style='font-family:Times New Roman; font-size:1.1em'></span></td>";
        strTable += "\n<td style='width:12%; background-color:#B8D7FF' class='cssTitleReport' nowrap='nowrap'>" + "<span style='font-family:Times New Roman; font-size:1.1em'></span></td>";
        strTable += "\n<td style='width:12%; background-color:#B8D7FF' align='right' class='cssTitleReport' nowrap='nowrap'><span style='font-family:Times New Roman;  font-weight:bold; font-size:1.1em'>" + CIPConvert.ToStr(v_dc_tong_tien, "#,###") + "</span></td>"; // Số tiền tổng
        strTable += "\n<td style='width:12%; background-color:#B8D7FF' class='cssTitleReport' nowrap='nowrap'>" + "<span style='font-family:Times New Roman; font-size:1.1em'></span></td>";
        strTable += "\n<td style='width:12%; background-color:#B8D7FF' class='cssTitleReport' nowrap='nowrap'>" + "<span style='font-family:Times New Roman; font-size:1.1em'></span></td>";
        strTable += "\n</tr>";
    }
    private void loadTieuDe(ref string strTable)
    {
        //m_ds_cong_viec_moi.EnforceConstraints = false;
        m_us_cong_viec_moi.loc_du_lieu_giang_vien_cong_viec_moi_f606(m_ds_v_cong_viec_moi, CIPConvert.ToDecimal(m_cbo_ten_giang_vien_loc.SelectedValue)
                                                       , CIPConvert.ToDecimal(m_cbo_so_hop_dong_loc.SelectedValue)
                                                       , CIPConvert.ToDecimal(m_cbo_trang_thai_cv_gv.SelectedValue)
                                                       , CIPConvert.ToDecimal(m_cbo_noi_dung_thanh_toan.SelectedValue));
        strTable += "<table cellpadding='2' cellspacing='0' class='cssTableReport'>";

        strTable += "\n<tr>";
        strTable += "\n<td colspan='3'><class='cssTableView' style='width:100%;' nowrap='nowrap'><span style='font-family:Times New Roman; font-weight:bold; font-size:1.1em'>Công ty CP Đầu tư và Phát triển đào tạo Edutop64</span></td>";
        strTable += "\n<td colspan='3' align='right'><class='cssTableView' style='width:100%;' nowrap='nowrap'></td>";
        strTable += "\n</tr>";
        //
        strTable += "\n<tr>";
        strTable += "\n<td colspan='3'><class='cssTableView' style='width:100%;' nowrap='nowrap'><span style='font-family:Times New Roman; margin-left:30px; font-weight:bold; font-size:1.1em; text-decoration:underline;'>Trung tâm Đào tạo HOU - TOPICA</span></td>";
        strTable += "\n</tr>";
        //Khoảng trắng trước khi vào header chính
        strTable += "\n<tr>";
        strTable += "\n<td colspan='6'></td>";
        strTable += "\n</tr>";
        //
        strTable += "\n<tr>";
        strTable += "\n<td colspan='6' align='center'><class='cssTableView' style='width: 100%;  height: 40px; font-size: large; color:White; background-color:#810C15;' nowrap='wrap'><span style='font-family:Times New Roman; font-weight:bold; font-size:1.4em;'>BẢNG ĐĂNG KÝ CÔNG VIỆC GIẢNG VIÊN CHUYÊN MÔN"+"</span></td>";
        strTable += "\n</tr>";
        //Khoảng trắng trước khi vào thông tin về phiếu xác nhận thù lao
        strTable += "\n<tr>";
        strTable += "\n<td colspan='6'></td>";
        strTable += "\n</tr>";
        //Họ tên giảng viên
        strTable += "\n<tr>";
        strTable += "\n<td colspan='6' align='left'><class='cssTableView' style='width:100%;' nowrap='nowrap'> <span style='font-family:Times New Roman;font-size:1.1em'>Họ và tên giảng viên: <font style='font-weight:bold'>" + m_cbo_ten_giang_vien_loc.SelectedItem.Text + "</font></span></td>";
        strTable += "\n</tr>";
        //Khoảng trắng trước khi vào nội dung chính
        strTable += "\n<tr>";
        strTable += "\n<td colspan='6'></td>";
        strTable += "\n</tr>";
        //
        strTable += "\n</table>";
        //table noi dung
        strTable += "<table cellpadding='2' cellspacing='0' class='cssTableReport'>";
        strTable += "\n<tr>";
        strTable += "\n<td align='center' class='cssTableView' style='width:12%;' nowrap='nowrap'><span style='font-family:Times New Roman; font-weight:bold; font-size:1.1em'>STT</span></td>";
        strTable += "\n<td align='center' class='cssTableView' style='width:12%;' nowrap='nowrap'><span style='font-family:Times New Roman; font-weight:bold; font-size:1.1em'>Số hợp đồng</span></td>";
        strTable += "\n<td align='center' class='cssTableView' style='width:12%;' nowrap='nowrap'><span style='font-family:Times New Roman; font-weight:bold; font-size:1.1em'>Tên giảng viên</span></td>";
        strTable += "\n<td align='center' class='cssTableView' style='width:12%;' nowrap='nowrap'><span style='font-family:Times New Roman; font-weight:bold; font-size:1.1em'>Công việc</span></td>";
        strTable += "\n<td align='center' class='cssTableView' style='width:12%;' nowrap='nowrap'><span style='font-family:Times New Roman; font-weight:bold; font-size:1.1em'>Đơn giá (VNĐ)</span></td>";
        strTable += "\n<td align='center' class='cssTableView' style='width:12%;' nowrap='nowrap'><span style='font-family:Times New Roman; font-weight:bold; font-size:1.1em'>Số lượng</span></td>";
        strTable += "\n<td align='center' class='cssTableView' style='width:12%;' nowrap='nowrap'><span style='font-family:Times New Roman; font-weight:bold; font-size:1.1em'>ĐVT</span></td>";
        strTable += "\n<td align='center' class='cssTableView' style='width:12%;' nowrap='nowrap'><span style='font-family:Times New Roman; font-weight:bold; font-size:1.1em'>Thành tiền (VNĐ)</span></td>";
        strTable += "\n<td align='center' class='cssTableView' style='width:12%;' nowrap='nowrap'><span style='font-family:Times New Roman; font-weight:bold; font-size:1.1em'>Ngày đặt hàng</span></td>";
        strTable += "\n<td align='center' class='cssTableView' style='width:12%;' nowrap='nowrap'><span style='font-family:Times New Roman; font-weight:bold; font-size:1.1em'>Trạng thái</span></td>";
        strTable += "\n</tr>";
        loadDSExprort(ref strTable);
        strTable += "\n</table>";
    }
    private string loadExport()
    {
        try
        {
            string strHTML = "<html xmlns:o='urn:schemas-microsoft-com:office:office'"
            + "\n xmlns:x='urn:schemas-microsoft-com:office:excel'"
            + "\n xmlns='http://www.w3.org/TR/REC-html40'>"
            + "\n <head>"
            + "\n <meta http-equiv=Content-Type content='text/html; charset=utf-8'>"
            + "\n <meta name=ProgId content=Excel.Sheet>"
            + "\n <meta name=Generator content='Microsoft Excel 11'>"
            + "\n <link rel=File-List href='Book1_files/filelist.xml'>"
            + "\n <style id='Book1_28091_Styles'><!--table"
            + "\n 	{mso-displayed-decimal-separator:'\\.';"
            + "\n 	mso-displayed-thousand-separator:'\\,';}"
            + ".cssTitleReport"
            + "{font-family: Times New Roman; font-size: 1.1em;font-weight:normal;border: 1px #000000 solid;}"
            + ".cssTableView"
            + "{color:#FFFFFF;background-color:#800000;font-family: tahoma,Arial,Times New Roman; font-size: 12px;font-weight:bold;border: 1px #000000 solid;}"
            + "\n 	--></style>"
            + "\n 	</head>"
            + "\n 	<body><div id='Book1_28091' align=center x:publishsource='Excel'>";
            string strTable = "";
            loadTieuDe(ref strTable);
            strHTML += strTable;
            strHTML += "\n </div></body> ";
            strHTML += "\n </html> ";

            return strHTML;
        }
        catch
        {
            return "";
        }
    }
    #endregion

    #region Events
    protected void m_grv_gd_assign_su_kien_cho_giang_vien_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            decimal v_dc_id_cv_gv = CIPConvert.ToDecimal(m_grv_gd_assign_su_kien_cho_giang_vien.DataKeys[e.RowIndex].Value);
            m_us_cong_viec_moi.DeleteByID(v_dc_id_cv_gv);
            m_lbl_thong_bao_sau_cap_nhat.Text = " * Xóa bản ghi thành công !";
            load_data_2_grv();
            m_cbo_so_hop_dong_loc.ToolTip = "";
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_grv_gd_assign_su_kien_cho_giang_vien_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            load_data_2_us_update(e.RowIndex);
            us_object_2_form(m_us_cong_viec_moi);
            m_cmd_cap_nhat.Visible = true;
            m_cmd_tao_moi.Visible = false;
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cmd_cap_nhat_Click(object sender, EventArgs e)
    {
        try
        {
            if (m_cbo_ten_giang_vien_loc.SelectedValue.Equals("0"))
            {
                m_lbl_thong_bao_giang_vien.Text = "Bạn chưa chọn giảng viên cho công việc!";
                return;
            }
            form_2_us_object();
            m_us_cong_viec_moi.dcID = CIPConvert.ToDecimal(m_cbo_so_hop_dong_loc.ToolTip);
            m_us_cong_viec_moi.Update();
            load_data_2_grv();
            clear_form();
            m_cbo_trang_thai_cv_gv.Enabled = true;

            m_lbl_thong_bao_sau_cap_nhat.Text = " * Cập nhật thành công !";
            m_cbo_noi_dung_thanh_toan.Enabled = true;
            m_cmd_tao_moi.Visible = true;
            m_cmd_cap_nhat.Visible = false;
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cmd_huy_Click(object sender, EventArgs e)
    {
        try
        {
            clear_form();
            m_cbo_trang_thai_cv_gv.Enabled = true;
            m_cbo_noi_dung_thanh_toan.Enabled = true;
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cmd_tao_moi_Click(object sender, EventArgs e)
    {
        try
        {
            // Nếu chưa chọn công việc
            if (m_cbo_noi_dung_thanh_toan.SelectedIndex == 0)
            {
                m_lbl_thong_bao_so_hd.Text = "Bạn chưa chọn công việc giảng viên thực hiện!";
                return;
            }
            // Nếu nội dung CV này ứng với HĐ này đã tồn tại
            if (check_hop_dong_noi_dung_cong_viec_unique())
            {
                m_lbl_thong_bao_so_hd.Text = m_cbo_noi_dung_thanh_toan.SelectedItem.Text + " đã được đặt hàng cùng ngày " + CIPConvert.ToStr(m_dat_ngay_bat_dau.SelectedDate,"dd/MM/yyyy");
                return;
            }
            else m_lbl_thong_bao_so_hd.Text = "";
            if (m_cbo_ten_giang_vien_loc.SelectedValue.Equals("0"))
            {
                m_lbl_thong_bao_giang_vien.Text = "Bạn chưa chọn giảng viên cho công việc!";
                return;
            }
            if (m_cbo_trang_thai_cv_gv.SelectedValue.Equals("0"))
            {
                m_lbl_thong_bao_trang_thai.Text = "Bạn chưa chọn trạng thái của công việc!";
                return;
            }
            form_2_us_object();
            m_us_cong_viec_moi.Insert();
            m_lbl_thong_bao_sau_cap_nhat.Text = " * Thêm thành công một bản ghi !";
            m_cmd_huy.ToolTip = "";
            m_hdf_check_hd.Value = "";
            m_cbo_noi_dung_thanh_toan.SelectedIndex = 0;
            load_data_2_grv();
            clear_form();
            m_cbo_trang_thai_cv_gv.Enabled = true;
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cmd_loc_du_lieu_Click(object sender, EventArgs e)
    {
        try
        {
            load_data_2_grv();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    /*
   Kiểm tra các việc sau:
    - Kiểm tra trống
    - Kiểm tra tồn tại
    - Kiểm tra đó là hợp đồng GVCM
   */
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            clear_form();
            m_cbo_noi_dung_thanh_toan.Enabled = true;
            m_cbo_trang_thai_cv_gv.Enabled = true;
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cmd_xuat_excel_Click(object sender, EventArgs e)
    {
        try
        {
            string html = loadExport();
            string strNamFile = "BaoCaoDangKyCongViecGVChuyenMon" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + ".xls";
            Response.Cache.SetExpires(DateTime.Now.AddSeconds(1));
            Response.Clear();
            Response.AppendHeader("content-disposition", "attachment;filename=" + strNamFile);
            Response.Charset = "UTF-8";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "text/csv";
            Response.ContentType = "application/vnd.ms-excel";
            this.EnableViewState = false;
            Response.Write("\r\n");
            Response.Write(html);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this,v_e);
        }
    }
    protected void m_cbo_noi_dung_thanh_toan_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (m_cbo_noi_dung_thanh_toan.SelectedIndex != 0)
            {
                decimal v_dc_id_noi_dung_tt = CIPConvert.ToDecimal(m_cbo_noi_dung_thanh_toan.SelectedValue);
                US_V_GD_HOP_DONG_NOI_DUNG_TT v_us_dm_noi_dung_tt = new US_V_GD_HOP_DONG_NOI_DUNG_TT(v_dc_id_noi_dung_tt);
                m_txt_so_luong.Text = CIPConvert.ToStr(v_us_dm_noi_dung_tt.dcSO_LUONG_HE_SO, "#,#");
                m_lbl_don_vi.Text = v_us_dm_noi_dung_tt.strDON_VI_TINH;
                m_lbl_don_gia.Text = CIPConvert.ToStr(v_us_dm_noi_dung_tt.dcDON_GIA_HD);
                //load_data_2_grv();
            }
            else
            {
                load_data_2_grv();
            }
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_ten_giang_vien_loc_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            load_data_2_cbo_hop_dong_loc();
            if (m_cbo_so_hop_dong_loc.Items.Count > 0)
            {
                load_data_2_cbo_noi_dung_tt();
                load_data_2_grv();
            }
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_so_hop_dong_loc_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            load_data_2_cbo_noi_dung_tt();
            load_data_2_grv();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_trang_thai_cv_gv_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            load_data_2_grv();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_grv_gd_assign_su_kien_cho_giang_vien_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            m_grv_gd_assign_su_kien_cho_giang_vien.PageIndex = e.NewPageIndex;
            load_data_2_grv();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    #endregion
}