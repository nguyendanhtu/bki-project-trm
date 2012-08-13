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

public partial class ChucNang_F609_NghiemThuCongViecGVCM : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            load_data_2_cbo_trang_thai_cv_gv();
            load_data_2_cbo_ten_giang_vien();
            load_data_2_cbo_hop_dong_loc();
            load_data_2_grv();
            m_hdf_check_hd.Value = "";
            // Load thông tin về nội dung thanh toán
            if (m_cbo_noi_dung_thanh_toan.Items.Count > 0)
            {
                decimal v_dc_id_noi_dung_tt = CIPConvert.ToDecimal(m_cbo_noi_dung_thanh_toan.SelectedValue);
                US_V_DM_NOI_DUNG_THANH_TOAN v_us_dm_noi_dung_tt = new US_V_DM_NOI_DUNG_THANH_TOAN(v_dc_id_noi_dung_tt);
                m_txt_don_gia.Text = CIPConvert.ToStr(v_us_dm_noi_dung_tt.dcDON_GIA_DEFAULT, "#,###");
                m_txt_so_luong.Text = CIPConvert.ToStr(v_us_dm_noi_dung_tt.dcSO_LUONG_HE_SO_DEFAULT, "#,#");
                m_lbl_don_vi.Text = v_us_dm_noi_dung_tt.strDON_VI_TINH;
            }
            else if(m_cbo_ten_giang_vien.SelectedIndex > 0) m_lbl_mess.Text = "Hợp đồng này không có phụ lục hợp đồng";
            
            m_cbo_trang_thai_cv_gv.SelectedValue =CIPConvert.ToStr(ID_TRANG_THAI_CONG_VIEC_GVCM.DA_NGHIEM_THU);
        }
    }

    #region Members
    US_V_GD_GV_CONG_VIEC_MOI m_us_cong_viec_moi = new US_V_GD_GV_CONG_VIEC_MOI();
    DS_V_GD_GV_CONG_VIEC_MOI m_ds_cong_viec_moi = new DS_V_GD_GV_CONG_VIEC_MOI();
    #endregion

    #region Private Methods
    private void load_data_2_grv()
    {
        m_ds_cong_viec_moi.Clear();
        m_us_cong_viec_moi.loc_du_lieu_gv_cong_viec_moi_theo_trang_thai_nghiem_thu(m_ds_cong_viec_moi, CIPConvert.ToDecimal(m_cbo_so_hop_dong.SelectedValue), CIPConvert.ToDecimal(m_cbo_ten_giang_vien.SelectedValue));
        m_grv_gd_assign_su_kien_cho_giang_vien.DataSource = m_ds_cong_viec_moi.V_GD_GV_CONG_VIEC_MOI;
        m_grv_gd_assign_su_kien_cho_giang_vien.DataBind();
        if (m_ds_cong_viec_moi.V_GD_GV_CONG_VIEC_MOI.Rows.Count > 0)
        {
            m_lbl_ket_qua_loc_du_lieu.Text = "Kết quả lọc dữ liệu: " + m_ds_cong_viec_moi.V_GD_GV_CONG_VIEC_MOI.Rows.Count + " bản ghi";
            decimal v_dc_tong_tien = get_sum_tien(m_ds_cong_viec_moi);
            m_grv_gd_assign_su_kien_cho_giang_vien.FooterRow.Cells[8].Text = CIPConvert.ToStr(v_dc_tong_tien, "#,###");
        }
        else m_lbl_ket_qua_loc_du_lieu.Text = "";
    }
    private void load_data_2_us_update(int ip_i_stt_row)
    {
        decimal v_dc_id_cong_viec_gv = CIPConvert.ToDecimal(m_grv_gd_assign_su_kien_cho_giang_vien.DataKeys[ip_i_stt_row].Value);
        m_cbo_so_hop_dong.ToolTip = CIPConvert.ToStr(v_dc_id_cong_viec_gv);
        m_us_cong_viec_moi = new US_V_GD_GV_CONG_VIEC_MOI(v_dc_id_cong_viec_gv);
        US_DM_HOP_DONG_KHUNG v_us_dm_hop_dong_khung = new US_DM_HOP_DONG_KHUNG(m_us_cong_viec_moi.dcID_HOP_DONG_KHUNG);
        m_cbo_ten_giang_vien.SelectedValue = CIPConvert.ToStr(v_us_dm_hop_dong_khung.dcID_GIANG_VIEN);
    }
    private void us_object_2_form(US_V_GD_GV_CONG_VIEC_MOI ip_us_v_gd_cv_moi)
    {
        m_cbo_so_hop_dong.SelectedValue = CIPConvert.ToStr(ip_us_v_gd_cv_moi.dcID_HOP_DONG_KHUNG);
        load_data_2_cbo_noi_dung_tt();
        m_cbo_noi_dung_thanh_toan.SelectedValue = CIPConvert.ToStr(ip_us_v_gd_cv_moi.dcID_NOI_DUNG_TT);
        US_V_GD_HOP_DONG_NOI_DUNG_TT v_us_dm_noi_dung_tt = new US_V_GD_HOP_DONG_NOI_DUNG_TT(ip_us_v_gd_cv_moi.dcID_NOI_DUNG_TT);
        m_lbl_don_vi.Text = v_us_dm_noi_dung_tt.strDON_VI_TINH;
        m_cbo_noi_dung_thanh_toan.Enabled = false;
        //m_cbo_so_hop_dong.Enabled = false;

        m_cbo_trang_thai_cv_gv.ToolTip = CIPConvert.ToStr(ip_us_v_gd_cv_moi.dcID_TRANG_THAI); // Cái này lưu trạng thái cũ

        m_cbo_noi_dung_thanh_toan.ToolTip = CIPConvert.ToStr(ip_us_v_gd_cv_moi.dcID_NOI_DUNG_TT);
        m_txt_so_luong.Text = CIPConvert.ToStr(ip_us_v_gd_cv_moi.dcSO_LUONG_HE_SO, "#");
        m_txt_so_luong_nghiem_thu.Text = CIPConvert.ToStr(ip_us_v_gd_cv_moi.dcSO_LUONG_NGHIEM_THU,"#");
        m_txt_don_gia.Text = CIPConvert.ToStr(ip_us_v_gd_cv_moi.dcDON_GIA, "#,###");
        if (!m_us_cong_viec_moi.IsNGAY_DAT_HANGNull()) m_dat_ngay_bat_dau.SelectedDate = CIPConvert.ToDatetime(CIPConvert.ToStr(m_us_cong_viec_moi.datNGAY_DAT_HANG, "dd/MM/yyyy"), "dd/MM/yyyy");
        m_cbo_trang_thai_cv_gv.SelectedValue = CIPConvert.ToStr(ip_us_v_gd_cv_moi.dcID_TRANG_THAI);
        m_txt_ghi_chu.Text = ip_us_v_gd_cv_moi.strGHI_CHU;
    }
    private void form_2_us_object()
    {
        System.Globalization.CultureInfo enUS = new System.Globalization.CultureInfo("en-US");
        DateTime v_dat_out_result;
        m_us_cong_viec_moi.dcID_HOP_DONG_KHUNG = CIPConvert.ToDecimal(m_cbo_so_hop_dong.SelectedValue);
        m_us_cong_viec_moi.dcID_NOI_DUNG_TT = CIPConvert.ToDecimal(m_cbo_noi_dung_thanh_toan.SelectedValue);
        if (m_txt_so_luong.Text.Trim() != "")
        {
            m_us_cong_viec_moi.dcSO_LUONG_HE_SO = CIPConvert.ToDecimal(m_txt_so_luong.Text);
        }
        if (m_txt_don_gia.Text != "")
        {
            m_us_cong_viec_moi.dcDON_GIA = CIPConvert.ToDecimal(m_txt_don_gia.Text);
        }
        if (DateTime.TryParseExact(CIPConvert.ToStr(m_dat_ngay_bat_dau.SelectedDate), "dd/MM/yyyy", enUS, System.Globalization.DateTimeStyles.None, out v_dat_out_result))
        {
            if (m_dat_ngay_bat_dau.SelectedDate != CIPConvert.ToDatetime("01/01/0001"))
                m_us_cong_viec_moi.datNGAY_DAT_HANG = m_dat_ngay_bat_dau.SelectedDate;
            // Nếu công việc này chưa đc đặt hàng, lấy ngày đầu tiên của tháng trước
            else
            {
                DateTime v_dat_today = DateTime.Today;
                int v_i_year = v_dat_today.Year;
                int v_i_month = v_dat_today.Month - 1;
                if (v_i_month == 0)
                {
                    v_i_year = v_i_year - 1;
                    v_i_month = 12;
                }
                DateTime v_dat_ngay_dat_hang = new DateTime(v_i_year, v_i_month, 1);
                m_us_cong_viec_moi.datNGAY_DAT_HANG = v_dat_ngay_dat_hang;
            }
        }
        m_us_cong_viec_moi.datNGAY_NGHIEM_THU = DateTime.Today;
        m_us_cong_viec_moi.dcSO_LUONG_NGHIEM_THU = CIPConvert.ToDecimal(m_txt_so_luong_nghiem_thu.Text.Trim());
        m_us_cong_viec_moi.dcID_TRANG_THAI = CIPConvert.ToDecimal(m_cbo_trang_thai_cv_gv.SelectedValue);
        m_us_cong_viec_moi.strGHI_CHU = m_txt_ghi_chu.Text;
        m_us_cong_viec_moi.dcID_USER_NHAP = get_id_user_by_username(CIPConvert.ToStr(Session["Username"]));

    }
    private void load_data_2_cbo_trang_thai_cv_gv()
    {
        US_CM_DM_TU_DIEN v_us_tu_dien = new US_CM_DM_TU_DIEN();
        DS_CM_DM_TU_DIEN v_ds_tu_dien = new DS_CM_DM_TU_DIEN();

        v_us_tu_dien.FillDataset(v_ds_tu_dien, " WHERE ID_LOAI_TU_DIEN = " + (int)e_loai_tu_dien.TRANG_THAI_CONG_VIEC_GV);

        m_cbo_trang_thai_cv_gv.Items.Add(new ListItem("Tất cả", "0"));
        for (int v_i = 0; v_i < v_ds_tu_dien.CM_DM_TU_DIEN.Rows.Count; v_i++)
        {
            m_cbo_trang_thai_cv_gv.Items.Add(new ListItem(CIPConvert.ToStr(v_ds_tu_dien.CM_DM_TU_DIEN.Rows[v_i][CM_DM_TU_DIEN.TEN]), CIPConvert.ToStr(v_ds_tu_dien.CM_DM_TU_DIEN.Rows[v_i][CM_DM_TU_DIEN.ID])));
        }
    }
    private void load_data_2_cbo_ten_giang_vien()
    {
        US_V_DM_GIANG_VIEN v_us_v_dm_giang_vien = new US_V_DM_GIANG_VIEN();
        DS_V_DM_GIANG_VIEN v_ds_v_dm_giang_vien = new DS_V_DM_GIANG_VIEN();

        v_us_v_dm_giang_vien.load_all_giang_vien_CM(v_ds_v_dm_giang_vien);
        m_cbo_ten_giang_vien.Items.Add(new ListItem("Tất cả", "0"));
        for (int v_i = 0; v_i < v_ds_v_dm_giang_vien.V_DM_GIANG_VIEN.Rows.Count; v_i++)
        {
            m_cbo_ten_giang_vien.Items.Add(new ListItem(CIPConvert.ToStr(v_ds_v_dm_giang_vien.V_DM_GIANG_VIEN.Rows[v_i][V_DM_GIANG_VIEN.HO_VA_TEN_DEM]).Trim() + " " + CIPConvert.ToStr(v_ds_v_dm_giang_vien.V_DM_GIANG_VIEN.Rows[v_i][V_DM_GIANG_VIEN.TEN_GIANG_VIEN]).Trim(), CIPConvert.ToStr(v_ds_v_dm_giang_vien.V_DM_GIANG_VIEN.Rows[v_i][V_DM_GIANG_VIEN.ID])));
        }

    }
    private void load_data_2_cbo_hop_dong_loc()
    {
        US_V_DM_HOP_DONG_KHUNG v_us_v_dm_hop_dong_khung = new US_V_DM_HOP_DONG_KHUNG();
        DS_V_DM_HOP_DONG_KHUNG v_ds_v_dm_hop_dong_khung = new DS_V_DM_HOP_DONG_KHUNG();
        m_cbo_so_hop_dong.Items.Clear();
        v_us_v_dm_hop_dong_khung.load_hop_dong_by_id_giang_vien_cm_da_ky(CIPConvert.ToDecimal(m_cbo_ten_giang_vien.SelectedValue), v_ds_v_dm_hop_dong_khung);
        if (v_ds_v_dm_hop_dong_khung.V_DM_HOP_DONG_KHUNG.Rows.Count > 0)
        {
            for (int v_i = 0; v_i < v_ds_v_dm_hop_dong_khung.V_DM_HOP_DONG_KHUNG.Rows.Count; v_i++)
            {
                m_cbo_so_hop_dong.Items.Add(new ListItem(CIPConvert.ToStr(v_ds_v_dm_hop_dong_khung.V_DM_HOP_DONG_KHUNG.Rows[v_i][V_DM_HOP_DONG_KHUNG.SO_HOP_DONG]), CIPConvert.ToStr(v_ds_v_dm_hop_dong_khung.V_DM_HOP_DONG_KHUNG.Rows[v_i][V_DM_HOP_DONG_KHUNG.ID])));
            }
        }
    }
    private void load_thong_tin_co_ban_cong_viec(decimal ip_dc_id_cong_viec)
    {
        US_V_GD_HOP_DONG_NOI_DUNG_TT v_us_gd_hop_dong_noi_dung_tt = new US_V_GD_HOP_DONG_NOI_DUNG_TT(ip_dc_id_cong_viec);
        m_lbl_don_vi.Text = v_us_gd_hop_dong_noi_dung_tt.strDON_VI_TINH;
        if(m_txt_don_gia.Text.Trim().Equals(""))
            m_txt_don_gia.Text = CIPConvert.ToStr(v_us_gd_hop_dong_noi_dung_tt.dcDON_GIA_HD,"#,###");
    }
    private void load_data_2_cbo_noi_dung_tt()
    {
        m_lbl_mess.Text = "";
        m_cbo_noi_dung_thanh_toan.Items.Clear();
        US_V_GD_HOP_DONG_NOI_DUNG_TT v_us_gd_hop_dong_noi_dung_tt = new US_V_GD_HOP_DONG_NOI_DUNG_TT();
        DS_V_GD_HOP_DONG_NOI_DUNG_TT v_ds_gd_hop_dong_noi_dung_tt = new DS_V_GD_HOP_DONG_NOI_DUNG_TT();

        // Lấy tất cả các nội dung thanh toán từ phụ lục hợp đồng
        v_us_gd_hop_dong_noi_dung_tt.FillDataset(v_ds_gd_hop_dong_noi_dung_tt, " WHERE ID_HOP_DONG_KHUNG = " + CIPConvert.ToDecimal(m_cbo_so_hop_dong.SelectedValue));
        m_cbo_noi_dung_thanh_toan.Items.Add(new ListItem("------ Chọn công việc ------", "0"));
        for (int v_i = 0; v_i < v_ds_gd_hop_dong_noi_dung_tt.V_GD_HOP_DONG_NOI_DUNG_TT.Rows.Count; v_i++)
        {
            m_cbo_noi_dung_thanh_toan.Items.Add(new ListItem(CIPConvert.ToStr(v_ds_gd_hop_dong_noi_dung_tt.V_GD_HOP_DONG_NOI_DUNG_TT.Rows[v_i][V_GD_HOP_DONG_NOI_DUNG_TT.NOI_DUNG_THANH_TOAN]), CIPConvert.ToStr(v_ds_gd_hop_dong_noi_dung_tt.V_GD_HOP_DONG_NOI_DUNG_TT.Rows[v_i][V_GD_HOP_DONG_NOI_DUNG_TT.ID])));
        }
        if (m_cbo_noi_dung_thanh_toan.Items.Count > 0)
        {
            if (!m_cbo_noi_dung_thanh_toan.SelectedValue.Equals("0"))
            {
                decimal v_dc_id_noi_dung_tt = CIPConvert.ToDecimal(m_cbo_noi_dung_thanh_toan.SelectedValue);
                US_V_GD_HOP_DONG_NOI_DUNG_TT v_us_dm_noi_dung_tt = new US_V_GD_HOP_DONG_NOI_DUNG_TT(v_dc_id_noi_dung_tt);
                m_lbl_don_vi.Text = v_us_dm_noi_dung_tt.strDON_VI_TINH;
            }
        }
        else m_lbl_mess.Text = "Hợp đồng này không có phụ lục hợp đồng!";
    }
    private void load_data_2_control_cong_viec()
    {
        if (m_cbo_noi_dung_thanh_toan.Items.Count > 0 && !m_cbo_noi_dung_thanh_toan.SelectedValue.Equals("0"))
        {
            // Lấy công việc theo số HĐ và ID công việc
            m_us_cong_viec_moi.lay_cong_viec_de_nghiem_thu(m_ds_cong_viec_moi, CIPConvert.ToDecimal(m_cbo_so_hop_dong.SelectedValue), CIPConvert.ToDecimal(m_cbo_noi_dung_thanh_toan.SelectedValue));
            // Nếu đã tồn tại công việc đó rồi thì load theo đơn giá như công việc đã nhập
            if (m_ds_cong_viec_moi.V_GD_GV_CONG_VIEC_MOI.Rows.Count > 0)
            {
                if (m_ds_cong_viec_moi.V_GD_GV_CONG_VIEC_MOI.Rows[0][V_GD_GV_CONG_VIEC_MOI.NGAY_DAT_HANG].GetType() != typeof(DBNull))
                    m_dat_ngay_bat_dau.SelectedDate = CIPConvert.ToDatetime(CIPConvert.ToStr(m_ds_cong_viec_moi.V_GD_GV_CONG_VIEC_MOI.Rows[0][V_GD_GV_CONG_VIEC_MOI.NGAY_DAT_HANG]), "dd/MM/yyyy");
                if (m_ds_cong_viec_moi.V_GD_GV_CONG_VIEC_MOI.Rows[0][V_GD_GV_CONG_VIEC_MOI.SO_LUONG_HE_SO].GetType() != typeof(DBNull))
                    m_txt_so_luong.Text = CIPConvert.ToStr(m_ds_cong_viec_moi.V_GD_GV_CONG_VIEC_MOI.Rows[0][V_GD_GV_CONG_VIEC_MOI.SO_LUONG_HE_SO], "#");
                m_txt_so_luong.Enabled = false;
                //m_cbo_trang_thai_cv_gv.SelectedValue = CIPConvert.ToStr(m_ds_cong_viec_moi.V_GD_GV_CONG_VIEC_MOI.Rows[0][V_GD_GV_CONG_VIEC_MOI.ID_TRANG_THAI]);
                if (m_ds_cong_viec_moi.V_GD_GV_CONG_VIEC_MOI.Rows[0][V_GD_GV_CONG_VIEC_MOI.SO_LUONG_NGHIEM_THU].GetType() != typeof(DBNull))
                    m_txt_so_luong_nghiem_thu.Text = CIPConvert.ToStr(m_ds_cong_viec_moi.V_GD_GV_CONG_VIEC_MOI.Rows[0][V_GD_GV_CONG_VIEC_MOI.SO_LUONG_NGHIEM_THU], "#");
                m_cbo_trang_thai_cv_gv.ToolTip = CIPConvert.ToStr(m_ds_cong_viec_moi.V_GD_GV_CONG_VIEC_MOI.Rows[0][V_GD_GV_CONG_VIEC_MOI.ID_TRANG_THAI]);
                m_cbo_so_hop_dong.ToolTip = CIPConvert.ToStr(m_ds_cong_viec_moi.V_GD_GV_CONG_VIEC_MOI.Rows[0][V_GD_GV_CONG_VIEC_MOI.ID]);
                m_txt_don_gia.Text = CIPConvert.ToStr(m_ds_cong_viec_moi.V_GD_GV_CONG_VIEC_MOI.Rows[0][V_GD_GV_CONG_VIEC_MOI.DON_GIA], "#,###");
            }
                // Còn nếu công việc này ko có trong kế hoạch
            else
            {
                decimal v_dc_id_noi_dung_tt = CIPConvert.ToDecimal(m_cbo_noi_dung_thanh_toan.SelectedValue);
                DateTime v_dat_today = DateTime.Today;
                int v_i_year = v_dat_today.Year;
                int v_i_month = v_dat_today.Month - 1;
                if (v_i_month == 0)
                {
                    v_i_year = v_i_year - 1;
                    v_i_month = 12;
                }
                DateTime v_dat_ngay_dat_hang = new DateTime(v_i_year, v_i_month, 1);

                US_V_GD_HOP_DONG_NOI_DUNG_TT v_us_dm_noi_dung_tt = new US_V_GD_HOP_DONG_NOI_DUNG_TT(v_dc_id_noi_dung_tt);
                m_txt_don_gia.Text = CIPConvert.ToStr(v_us_dm_noi_dung_tt.dcDON_GIA_HD, "#,###");
                m_lbl_mess.Text = "";
                m_cbo_trang_thai_cv_gv.ToolTip = "-1";
                m_cbo_so_hop_dong.ToolTip = "-1";
                m_dat_ngay_bat_dau.SelectedDate = v_dat_ngay_dat_hang;
                m_txt_so_luong_nghiem_thu.Text = "";
            }
        }
    }
    private bool check_cong_viec_da_duoc_len_hay_chua()
    {
        // Lấy công việc theo số HĐ và ID công việc
        m_us_cong_viec_moi.FillDataset(m_ds_cong_viec_moi, " WHERE ID_HOP_DONG_KHUNG = " + CIPConvert.ToDecimal(m_cbo_so_hop_dong.SelectedValue) + " AND ID_NOI_DUNG_TT = " + CIPConvert.ToDecimal(m_cbo_noi_dung_thanh_toan.SelectedValue));
        if (m_ds_cong_viec_moi.V_GD_GV_CONG_VIEC_MOI.Rows.Count > 0)
        {
            return true; // Đã tồn tại
        }
        return false;
    }
    private void clear_form()
    {
        m_txt_don_gia.Text = "";
        m_txt_so_luong.Text = "";
        m_txt_ghi_chu.Text = "";
        m_dat_ngay_bat_dau.Clear();
        m_lbl_mess.Text = "";
        m_txt_so_luong_nghiem_thu.Text = "";
        m_cbo_noi_dung_thanh_toan.SelectedIndex = 0;
        //m_cbo_trang_thai_cv_gv.SelectedIndex = 0;
    }
    private decimal get_id_user_by_username(string ip_strsusername)
    {
        US_HT_NGUOI_SU_DUNG v_us_ht_nguoi_su_dung = new US_HT_NGUOI_SU_DUNG();
        DS_HT_NGUOI_SU_DUNG v_ds_ht_nguoi_su_dung = new DS_HT_NGUOI_SU_DUNG();
        v_us_ht_nguoi_su_dung.FillDataset(v_ds_ht_nguoi_su_dung, " WHERE TEN_TRUY_CAP=N'" + ip_strsusername + "'");
        return CIPConvert.ToDecimal(v_ds_ht_nguoi_su_dung.HT_NGUOI_SU_DUNG.Rows[0][HT_NGUOI_SU_DUNG.ID]);
    }
    //private bool check_hop_dong_noi_dung_cong_viec_unique()
    public string get_ma_trang_thai_by_id(decimal ip_dc_id_trang_thai)
    {
        US_CM_DM_TU_DIEN v_us_dm_tu_dien = new US_CM_DM_TU_DIEN(ip_dc_id_trang_thai);
        return v_us_dm_tu_dien.strMA_TU_DIEN;
    }
    public string get_so_tien_thanh_toan(object ip_obj_so_luong_nghiem_thu, object ip_obj_don_gia)
    {
        string v_str_so_tien_thanh_toan = "";
        if (ip_obj_so_luong_nghiem_thu.GetType() == typeof(DBNull) || ip_obj_don_gia.GetType() == typeof(DBNull))
            v_str_so_tien_thanh_toan = "";
        else v_str_so_tien_thanh_toan = CIPConvert.ToStr(CIPConvert.ToDecimal(ip_obj_don_gia) * CIPConvert.ToDecimal(ip_obj_so_luong_nghiem_thu), "#,###");
        return v_str_so_tien_thanh_toan;
    }
    #endregion

    #region Public Interfaces
    public string mapping_so_hop_dong_by_id(object ip_obj_id_hop_dong)
    {
        US_DM_HOP_DONG_KHUNG v_us_hop_dong_khung = new US_DM_HOP_DONG_KHUNG(CIPConvert.ToDecimal(ip_obj_id_hop_dong));
        return v_us_hop_dong_khung.strSO_HOP_DONG;
    }
    public decimal get_id_by_so_hop_dong(string ip_so_hop_dong)
    {
        US_DM_HOP_DONG_KHUNG v_us_hop_dong = new US_DM_HOP_DONG_KHUNG();
        DS_DM_HOP_DONG_KHUNG v_ds_hop_dong = new DS_DM_HOP_DONG_KHUNG();
        v_us_hop_dong.FillDataset(v_ds_hop_dong, " WHERE SO_HOP_DONG =N'" + ip_so_hop_dong + "'");
        return CIPConvert.ToDecimal(v_ds_hop_dong.DM_HOP_DONG_KHUNG.Rows[0][DM_HOP_DONG_KHUNG.ID]);
    }
    public bool check_trang_thai_chuyen(decimal ip_obj_trang_thai_hien_tai)
    {
        // Kiểm tra xem dòng đó có được phép chỉnh sửa trạng thái nữa không? (duyệt nữa không?)
        CValidateTrangThaiCongViec v_validate_cong_viec = new CValidateTrangThaiCongViec();
        v_validate_cong_viec.Trang_thai_cong_viec_hien_tai = get_ma_trang_thai_by_id(ip_obj_trang_thai_hien_tai);
        v_validate_cong_viec.set_trang_thai();
        if (!v_validate_cong_viec.check_chuyen_trang_thai(TRANG_THAI_CONG_VIEC_GVCM.DA_DUYET_KE_HOACH))
            return false;
        return true;
    }
    public bool check_trang_thai_chuyen(decimal ip_obj_trang_thai_hien_tai, decimal ip_obj_trang_thai_huong_toi)
    {
        // Kiểm tra xem dòng đó có được phép chỉnh sửa trạng thái nữa không? (duyệt nữa không?)
        CValidateTrangThaiCongViec v_validate_cong_viec = new CValidateTrangThaiCongViec();
        v_validate_cong_viec.Trang_thai_cong_viec_hien_tai = get_ma_trang_thai_by_id(ip_obj_trang_thai_hien_tai);
        v_validate_cong_viec.set_trang_thai();
        if (!v_validate_cong_viec.check_chuyen_trang_thai(get_ma_trang_thai_by_id(ip_obj_trang_thai_huong_toi)))
            return false;
        return true;
    }
    public decimal get_sum_tien(DS_V_GD_GV_CONG_VIEC_MOI ip_ds_gd_gv_cong_viec)
    {
        decimal v_dc_sum_tien = 0;
        for (int v_i = 0; v_i < ip_ds_gd_gv_cong_viec.V_GD_GV_CONG_VIEC_MOI.Rows.Count; v_i++)
        {
            if (ip_ds_gd_gv_cong_viec.V_GD_GV_CONG_VIEC_MOI.Rows[v_i][V_GD_GV_CONG_VIEC_MOI.SO_LUONG_NGHIEM_THU].GetType() == typeof(DBNull) || ip_ds_gd_gv_cong_viec.V_GD_GV_CONG_VIEC_MOI.Rows[v_i][V_GD_GV_CONG_VIEC_MOI.DON_GIA].GetType() == typeof(DBNull))
                v_dc_sum_tien += 0;
            else v_dc_sum_tien += CIPConvert.ToDecimal(ip_ds_gd_gv_cong_viec.V_GD_GV_CONG_VIEC_MOI.Rows[v_i][V_GD_GV_CONG_VIEC_MOI.SO_LUONG_NGHIEM_THU])*CIPConvert.ToDecimal(ip_ds_gd_gv_cong_viec.V_GD_GV_CONG_VIEC_MOI.Rows[v_i][V_GD_GV_CONG_VIEC_MOI.DON_GIA]);
        }
        return v_dc_sum_tien;
    }
    #endregion

    #region Events
    protected void m_cmd_cap_nhat_Click(object sender, EventArgs e)
    {
        try
        {
            if (m_cbo_trang_thai_cv_gv.SelectedIndex == 0)
            {
                m_lbl_thong_bao_tthai.Text = "Bạn chưa chọn trạng thái thanh toán!";
                return;
            }
            else m_lbl_thong_bao_tthai.Text = "";
            if (m_cbo_noi_dung_thanh_toan.SelectedIndex == 0)
            {
                m_lbl_thong_bao_cong_viec.Text = "Bạn chưa chọn công việc!";
                return;
            }
            else m_lbl_thong_bao_tthai.Text = "";
            form_2_us_object();
            if (!m_cbo_trang_thai_cv_gv.ToolTip.Equals("-1"))
                // check chuyển trạng thái
                if (!check_trang_thai_chuyen(CIPConvert.ToDecimal(m_cbo_trang_thai_cv_gv.ToolTip), CIPConvert.ToDecimal(m_cbo_trang_thai_cv_gv.SelectedValue)))
                {
                    string sScript;
                    sScript = "<script language='javascript'>alert('Không chuyển được từ trạng thái hiện tại đến trạng thái này!');</script>";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "onload", sScript);
                    return;
                }
            // Nếu đã có công việc này, cập nhật
            if (!m_cbo_so_hop_dong.ToolTip.Equals("-1"))
            {
                m_us_cong_viec_moi.dcID = CIPConvert.ToDecimal(m_cbo_so_hop_dong.ToolTip);
                m_us_cong_viec_moi.Update();
            }
            else m_us_cong_viec_moi.Insert();
            US_V_GD_HOP_DONG_NOI_DUNG_TT v_us_gd_hd_noi_dung_tt = new US_V_GD_HOP_DONG_NOI_DUNG_TT(CIPConvert.ToDecimal(m_cbo_noi_dung_thanh_toan.SelectedValue));
            m_txt_don_gia.Text = CIPConvert.ToStr(v_us_gd_hd_noi_dung_tt.dcDON_GIA_HD,"#,###");
            load_data_2_grv();
            //m_cbo_so_hop_dong.ToolTip = "";
            m_lbl_thong_bao_sau_cap_nhat.Text = " * Cập nhật thành công !";
            m_cbo_noi_dung_thanh_toan.Enabled = true;
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
    protected void m_cbo_ten_giang_vien_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            load_data_2_cbo_hop_dong_loc();
            if (m_cbo_so_hop_dong.Items.Count > 0)
            {
                load_data_2_cbo_noi_dung_tt();
                load_data_2_control_cong_viec();
                load_data_2_grv();
            }
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
    protected void m_cbo_noi_dung_thanh_toan_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            m_txt_so_luong_nghiem_thu.Text = "";
            if (!m_cbo_noi_dung_thanh_toan.SelectedValue.Equals("0"))
            {
                load_data_2_control_cong_viec();
                load_thong_tin_co_ban_cong_viec(CIPConvert.ToDecimal(m_cbo_noi_dung_thanh_toan.SelectedValue));
                m_lbl_thong_bao_cong_viec.Text = "";
                if (!m_txt_so_luong_nghiem_thu.Text.Trim().Equals(""))
                    m_lbl_tong_tien.Text = "Tổng tiền: " + CIPConvert.ToStr(CIPConvert.ToDecimal(m_txt_so_luong_nghiem_thu.Text) * CIPConvert.ToDecimal(m_txt_don_gia.Text), "#,###");
                else m_lbl_tong_tien.Text = "";
            }
            else
            {
                m_txt_don_gia.Text = "";
                m_txt_so_luong_nghiem_thu.Text = "";
                m_txt_so_luong.Text = "";
                m_lbl_don_vi.Text = "";
                m_lbl_thong_bao_cong_viec.Text = "Hãy chọn công việc cần nghiệm thu!";
            }
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_so_hop_dong_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            load_data_2_cbo_noi_dung_tt();
            load_data_2_control_cong_viec();
            load_data_2_grv();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_grv_gd_assign_su_kien_cho_giang_vien_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            // Lấy dữ liệu của dòng vừa chọn và cho vào US
            load_data_2_us_update(e.NewSelectedIndex);
            // Kiểm tra trạng thái để xem có chuyển đc không?
            if (!check_trang_thai_chuyen(m_us_cong_viec_moi.dcID_TRANG_THAI, ID_TRANG_THAI_CONG_VIEC_GVCM.DA_DUYET_NGHIEM_THU))
            {
                string sScript;
                sScript = "<script language='javascript'>alert('Công việc này đã được duyệt nghiệm thu hoặc chưa đủ điều kiện để duyệt nghiệm thu...!');</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "onload", sScript);
                return;
            }
            // Nếu được phép thì hiển thị dữ liệu lên form
            us_object_2_form(m_us_cong_viec_moi);
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    #endregion
} 