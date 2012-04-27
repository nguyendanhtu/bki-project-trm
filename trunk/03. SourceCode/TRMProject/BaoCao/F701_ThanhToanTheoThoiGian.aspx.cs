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

public partial class BaoCao_F701_ThanhToanTheoThoiGian : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            m_lbl_thong_bao.Text = "";
            load_data_2_cbo_don_vi_thanh_toan();
            load_data_2_nam_bd_hop_tac();
            load_data_2_cbo_dot_thanh_toan(CIPConvert.ToDecimal(m_cbo_thang_thanh_toan.SelectedValue), CIPConvert.ToDecimal(m_cbo_nam_thanh_toan.SelectedValue), CIPConvert.ToDecimal(m_cbo_don_vi_thanh_toan.SelectedValue));
            if (m_cbo_dot_thanh_toan.Items.Count > 0)
            {
                m_cmd_tim_kiem.Enabled = true;
               fill_data_2_thong_tin_dot_tt(CIPConvert.ToDecimal(m_cbo_dot_thanh_toan.SelectedValue));
            }
            else
            {
                m_cmd_tim_kiem.Enabled = false;
            }
        }
    }

    #region Members
    US_CM_DM_TU_DIEN m_us_cm_tu_dien = new US_CM_DM_TU_DIEN();
    DS_CM_DM_TU_DIEN m_ds_cm_tu_dien = new DS_CM_DM_TU_DIEN();
    US_V_GD_THANH_TOAN m_us_v_gd_thanh_toan = new US_V_GD_THANH_TOAN();
    DS_V_GD_THANH_TOAN m_v_ds_gd_thanh_toan = new DS_V_GD_THANH_TOAN();
    public string m_str_loai_hd = "";
    //DataEntryFormMode m_init_mode = DataEntryFormMode.ViewDataState;
    #endregion

    #region Public Interfaces
    public string mapping_loai_hd(string ip_str_loai_hd)
    {
        if (ip_str_loai_hd.Equals("HL"))
            return "Học liệu";
        // Còn lại là hợp đồng vận hành
        return "Vận hành";
    }
    public string mapping_don_vi_thanh_toan(decimal ip_dc_id_don_vi_tt)
    {
        US_DM_DON_VI_THANH_TOAN v_us_dm_don_vi_tt = new US_DM_DON_VI_THANH_TOAN(ip_dc_id_don_vi_tt);
        if (!v_us_dm_don_vi_tt.IsIDNull()) return v_us_dm_don_vi_tt.strTEN_DON_VI;
        return "";
    }
    public string mapping_don_vi_quan_ly(decimal ip_dc_id_don_vi_quan_ly)
    {
        US_CM_DM_TU_DIEN v_us_dm_tu_dien = new US_CM_DM_TU_DIEN(ip_dc_id_don_vi_quan_ly);
        return v_us_dm_tu_dien.strTEN;
    }
    public string mapping_trang_thai_dot_thanh_toan(decimal ip_dc_id_trang_thai_dot_tt)
    {
        US_CM_DM_TU_DIEN v_us_dm_tu_dien = new US_CM_DM_TU_DIEN(ip_dc_id_trang_thai_dot_tt);
        return v_us_dm_tu_dien.strTEN;
    }
    public string mapping_trang_thai_thanh_toan(decimal ip_dc_id_trang_thai_tt)
    {
        US_CM_DM_TU_DIEN v_us_dm_tu_dien = new US_CM_DM_TU_DIEN(ip_dc_id_trang_thai_tt);
        return v_us_dm_tu_dien.strTEN;
    }
    public string get_so_hd_khung_by_id_hd(decimal ip_dc_so_hd)
    {
        DS_V_DM_HOP_DONG_KHUNG v_ds_hd_khung = new DS_V_DM_HOP_DONG_KHUNG();
        US_V_DM_HOP_DONG_KHUNG v_us_hd_khung = new US_V_DM_HOP_DONG_KHUNG();
        v_us_hd_khung.FillDataset(v_ds_hd_khung, " WHERE  ID = " + ip_dc_so_hd);
        if (v_ds_hd_khung.V_DM_HOP_DONG_KHUNG.Rows.Count == 0) return "";
        return CIPConvert.ToStr(v_ds_hd_khung.V_DM_HOP_DONG_KHUNG.Rows[0][V_DM_HOP_DONG_KHUNG.SO_HOP_DONG]);
    }
    public string get_ma_dot_tt_by_id_dot(decimal ip_dc_ma_dot)
    {
        DS_V_DM_DOT_THANH_TOAN v_ds_dot_tt = new DS_V_DM_DOT_THANH_TOAN();
        US_V_DM_DOT_THANH_TOAN v_us_dot_thanh_toan = new US_V_DM_DOT_THANH_TOAN();
        v_us_dot_thanh_toan.FillDataset(v_ds_dot_tt, " WHERE ID = " + ip_dc_ma_dot);
        if (v_ds_dot_tt.V_DM_DOT_THANH_TOAN.Rows.Count == 0) return "";
        return CIPConvert.ToStr(v_ds_dot_tt.V_DM_DOT_THANH_TOAN.Rows[0][V_DM_DOT_THANH_TOAN.MA_DOT_TT]);
    }
    public string mapping_loai_hop_dong_gv(decimal ip_dc_id_hd_khung)
    {
        string v_str_noi_dung = "";
        // Lấy tên loại hợp đồng
        US_V_DM_HOP_DONG_KHUNG v_us_dm_hd_khung = new US_V_DM_HOP_DONG_KHUNG(ip_dc_id_hd_khung);
        v_str_noi_dung += v_us_dm_hd_khung.strLOAI_HOP_DONG.Trim();
        return v_str_noi_dung;
    }
    public decimal get_so_tien_da_thanh_toan(decimal ip_dc_id_hop_dong)
    {
        decimal v_dc_so_tien_da_tt = 0;
        m_us_v_gd_thanh_toan.FillDataset(m_v_ds_gd_thanh_toan, " WHERE ID_HOP_DONG_KHUNG=" + ip_dc_id_hop_dong + " AND REFERENCE_CODE IS NOT NULL");
        if (m_v_ds_gd_thanh_toan.V_GD_THANH_TOAN.Rows.Count == 0) return 0;
        else
        {
            foreach (DataRow dtr in m_v_ds_gd_thanh_toan.V_GD_THANH_TOAN.Rows)
            {
                v_dc_so_tien_da_tt += CIPConvert.ToDecimal(dtr[V_GD_THANH_TOAN.TONG_TIEN_THANH_TOAN]);
            }
        }
        return v_dc_so_tien_da_tt;
    }
    public decimal get_so_tien_con_phai_thanh_toan(decimal ip_dc_id_thanh_toan, decimal ip_dc_id_hop_dong)
    {
        // Nếu là tạm ứng nghiệm thu thực tế bằng null
        US_V_GD_THANH_TOAN v_us_gd_tt = new US_V_GD_THANH_TOAN(ip_dc_id_thanh_toan);
        // Nếu là tạm ứng lần >=2 thì: giá trị còn lại phải thanh toán bằng giá trị hđ trừ đi đã thanh toán
        if (v_us_gd_tt.IsGIA_TRI_NGHIEM_THU_THUC_TENull())
            return (v_us_gd_tt.dcGIA_TRI_HOP_DONG - get_so_tien_da_thanh_toan(ip_dc_id_hop_dong));
        // Nếu là thanh lý thì: giá trị còn lại phải thanh toán bằng giá trị nghiệm thu thực tế trừ đi đã thanh toán
        return (v_us_gd_tt.dcGIA_TRI_NGHIEM_THU_THUC_TE - get_so_tien_da_thanh_toan(ip_dc_id_hop_dong));
    }
    public string mapping_magv_by_id(decimal ip_dc_id_gv)
    {
        US_V_DM_GIANG_VIEN v_dm_gv = new US_V_DM_GIANG_VIEN(ip_dc_id_gv);
        if (v_dm_gv.IsIDNull()) return "";
        return v_dm_gv.strMA_GIANG_VIEN;
    }
    public string mapping_time(object ip_obj_time)
    {
        if (ip_obj_time.GetType() != typeof(DBNull)) return CIPConvert.ToStr(ip_obj_time, "dd/MM/yyyy");
        return "";
    }
    public string mapping_header_nghiem_thu_lop_mon(string ip_str_loai_hd)
    {
        if (ip_str_loai_hd.Equals("VH")) return "Các lớp môn phụ trách";
        else if (ip_str_loai_hd.Equals("HL")) return "Giá trị nghiệm thu thực tế (VNĐ)";
        return "Giá trị nghiệm thu thực tế (VNĐ) / Các lớp môn phụ trách";
    }
    public string mapping_item_field_nghiem_thu_lop_mon(string ip_str_loai_hd, object ip_obj_reference, object ip_obj_gia_tri_nghiem_thu)
    {
        if (ip_obj_reference.GetType() != typeof(DBNull) && ip_str_loai_hd.Equals("VH"))
        {
            return CIPConvert.ToStr(ip_obj_reference);
        }
        else if (ip_obj_gia_tri_nghiem_thu.GetType() != typeof(DBNull) && ip_str_loai_hd.Equals("HL"))
        {
            return mapping_gia_tri_hd(ip_obj_gia_tri_nghiem_thu);
        }
        return "";
    }
    public string mapping_item_field_ten_cac_mon(string ip_str_loai_hd, object ip_obj_ghi_chu_cac_mon_phu_trach)
    {
        if (ip_obj_ghi_chu_cac_mon_phu_trach.GetType() != typeof(DBNull) && ip_str_loai_hd.Equals("VH"))
        {
            return CIPConvert.ToStr(ip_obj_ghi_chu_cac_mon_phu_trach);
        }
        return "";
    }
    public string mapping_gia_tri_hd(object ip_obj_gia_tri_hd)
    {
        if (ip_obj_gia_tri_hd.GetType() == typeof(DBNull) || CIPConvert.ToDecimal(ip_obj_gia_tri_hd) == 0) return "";
        return CIPConvert.ToStr(ip_obj_gia_tri_hd, "#,###");
    }
    public string mapping_so_tien_con_phai_tt(object ip_obj_so_tien, object ip_obj_loai_hd, object ip_obj_reference)
    {
        if (ip_obj_so_tien.GetType() == typeof(DBNull)) return "";
        if (CIPConvert.ToDecimal(ip_obj_so_tien) == 0)
        {
            if (CIPConvert.ToStr(ip_obj_loai_hd).Equals("VH"))
                return "";
            else if (ip_obj_reference.GetType() != typeof(DBNull)) // nghĩa là tạm ứng học liệu
                return "";
            else return CIPConvert.ToStr(0); // đây là thanh lý học liệu
        }
        return CIPConvert.ToStr(ip_obj_so_tien, "#,###");
    }
    #endregion

    #region Private Methods
    private void load_data_2_nam_bd_hop_tac()
    {
        m_cbo_nam_thanh_toan.Items.Add(new ListItem("Tất cả", CIPConvert.ToStr(0)));
        for (int v_i = 2008; v_i < 2051; v_i++)
        {
            m_cbo_nam_thanh_toan.Items.Add(new ListItem(v_i.ToString(), v_i.ToString()));
        }
    }
    private void load_data_2_cbo_dot_thanh_toan(decimal ip_dc_thang_tt, decimal ip_dc_nam_tt, decimal ip_dc_id_don_vi_tt)
    {
        DS_V_DM_DOT_THANH_TOAN v_ds_dot_thanh_toan = new DS_V_DM_DOT_THANH_TOAN();
        US_V_DM_DOT_THANH_TOAN v_us_dot_thanh_toan = new US_V_DM_DOT_THANH_TOAN();
        // Load đợt thanh toán dựa vào tháng và năm thanh toán
        v_us_dot_thanh_toan.load_data_2_dot_tt_by_thang_nam(ip_dc_thang_tt, ip_dc_nam_tt, ip_dc_id_don_vi_tt, v_ds_dot_thanh_toan);
        DataRow v_dr = v_ds_dot_thanh_toan.V_DM_DOT_THANH_TOAN.NewV_DM_DOT_THANH_TOANRow();
        v_dr[V_DM_DOT_THANH_TOAN.ID] = 0;
        v_dr[V_DM_DOT_THANH_TOAN.MA_DOT_TT] = "All";
        v_dr[V_DM_DOT_THANH_TOAN.TEN_DOT_TT] = "Tất cả";
        v_dr[V_DM_DOT_THANH_TOAN.NGAY_TT_DU_KIEN] = CIPConvert.ToDatetime("01/01/2010");
        v_dr[V_DM_DOT_THANH_TOAN.ID_DON_VI_THANH_TOAN] = 0;
        v_dr[V_DM_DOT_THANH_TOAN.TRANG_THAI_DOT_TT] = 0;
        v_dr[V_DM_DOT_THANH_TOAN.ID_TRANG_THAI_DOT_TT] = 0;
        v_dr[V_DM_DOT_THANH_TOAN.DON_VI_THANH_TOAN] = "All";
        v_ds_dot_thanh_toan.V_DM_DOT_THANH_TOAN.Rows.InsertAt(v_dr, 0);
        m_cbo_dot_thanh_toan.DataTextField = V_DM_DOT_THANH_TOAN.TEN_DOT_TT;
        m_cbo_dot_thanh_toan.DataValueField = V_DM_DOT_THANH_TOAN.ID;
        m_cbo_dot_thanh_toan.DataSource = v_ds_dot_thanh_toan.V_DM_DOT_THANH_TOAN;
        m_cbo_dot_thanh_toan.DataBind();
        //ListItem v_items = new ListItem(get_id_kho());
        //m_cbo_dot_thanh_toan.Items.Remove(v_items);
    }
    private string get_id_kho()
    {
        US_V_DM_DOT_THANH_TOAN v_us_dm_dot_tt = new US_V_DM_DOT_THANH_TOAN();
        DS_V_DM_DOT_THANH_TOAN v_ds_dm_dot_tt = new DS_V_DM_DOT_THANH_TOAN();
        v_us_dm_dot_tt.FillDataset(v_ds_dm_dot_tt, " WHERE MA_DOT_TT LIKE N'KHO'");
        //if(v_ds)
        return CIPConvert.ToStr(v_ds_dm_dot_tt.V_DM_DOT_THANH_TOAN.Rows[0][V_DM_DOT_THANH_TOAN.ID]);
    }
    private void load_data_2_cbo_don_vi_thanh_toan()
    {
        DS_DM_DON_VI_THANH_TOAN v_ds_don_vi_thanh_toan = new DS_DM_DON_VI_THANH_TOAN();
        US_DM_DON_VI_THANH_TOAN v_us_don_vi_thanh_toan = new US_DM_DON_VI_THANH_TOAN();

        DataRow v_dr_none = v_ds_don_vi_thanh_toan.DM_DON_VI_THANH_TOAN.NewDM_DON_VI_THANH_TOANRow();
        v_dr_none[DM_DON_VI_THANH_TOAN.ID] = "0";
        v_dr_none[DM_DON_VI_THANH_TOAN.MA_DON_VI] = "All";
        v_dr_none[DM_DON_VI_THANH_TOAN.TEN_DON_VI] = "Tất cả";
        v_ds_don_vi_thanh_toan.DM_DON_VI_THANH_TOAN.Rows.InsertAt(v_dr_none, 0);
        // Load đợt thanh toán dựa vào tháng và năm thanh toán
        v_us_don_vi_thanh_toan.FillDataset(v_ds_don_vi_thanh_toan);
        m_cbo_don_vi_thanh_toan.DataTextField = DM_DON_VI_THANH_TOAN.TEN_DON_VI;
        m_cbo_don_vi_thanh_toan.DataValueField = DM_DON_VI_THANH_TOAN.ID;
        m_cbo_don_vi_thanh_toan.DataSource = v_ds_don_vi_thanh_toan.DM_DON_VI_THANH_TOAN;
        m_cbo_don_vi_thanh_toan.DataBind();
    }
    private decimal get_id_trang_thai_da_duyet()
    {
        US_CM_DM_TU_DIEN v_us_cm_tu_dien = new US_CM_DM_TU_DIEN();
        DS_CM_DM_TU_DIEN v_ds_tu_dien = new DS_CM_DM_TU_DIEN();
        v_us_cm_tu_dien.FillDataset(v_ds_tu_dien, " WHERE ID_LOAI_TU_DIEN = 15 AND MA_TU_DIEN LIKE N'%CHUNG_TU_DA_DUOC_DUYET%'");
        if (v_ds_tu_dien.CM_DM_TU_DIEN.Rows.Count == 0) return 512;
        return CIPConvert.ToDecimal(v_ds_tu_dien.CM_DM_TU_DIEN.Rows[0][CM_DM_TU_DIEN.ID]);
    }
    private decimal get_id_trang_thai_chua_duyet()
    {
        US_CM_DM_TU_DIEN v_us_cm_tu_dien = new US_CM_DM_TU_DIEN();
        DS_CM_DM_TU_DIEN v_ds_tu_dien = new DS_CM_DM_TU_DIEN();
        v_us_cm_tu_dien.FillDataset(v_ds_tu_dien, " WHERE ID_LOAI_TU_DIEN = 15 AND MA_TU_DIEN LIKE N'%CHUNG_TU_KHONG_DUOC_DUYET%'");
        if (v_ds_tu_dien.CM_DM_TU_DIEN.Rows.Count == 0) return 513;
        return CIPConvert.ToDecimal(v_ds_tu_dien.CM_DM_TU_DIEN.Rows[0][CM_DM_TU_DIEN.ID]);
    }
    private void load_data_2_grid_search(string ip_str_ma_dot_tt, string ip_str_loai_hop_dong, decimal ip_dc_thang_tt, decimal ip_dc_nam_tt,decimal ip_dc_dv_thanh_toan)
    {
        if (ip_str_loai_hop_dong.Equals("VH")) // Vận hành
        {
            m_str_loai_hd = "VH";
        }
        else if (ip_str_loai_hop_dong.Equals("HL"))// Học liệu
        {
            m_str_loai_hd = "HL";
        }
        else m_str_loai_hd = "All";

        m_us_v_gd_thanh_toan.fill_dataset_by_dot_tt_va_loai_hd(ip_str_ma_dot_tt,ip_str_loai_hop_dong, ip_dc_thang_tt,ip_dc_nam_tt,ip_dc_dv_thanh_toan, m_v_ds_gd_thanh_toan);

        if (m_v_ds_gd_thanh_toan.V_GD_THANH_TOAN.Rows.Count == 0)
        {
            m_lbl_thong_bao.Visible = true;
            m_lbl_thong_bao.Text = "Không có Thanh toán nào phù hợp";
        }
        else m_lbl_thong_bao.Text = "";
        m_grv_danh_sach_du_toan.DataSource = m_v_ds_gd_thanh_toan.V_GD_THANH_TOAN;
        m_grv_danh_sach_du_toan.DataBind();
        m_lbl_danh_sach_thanh_toan.Text = "Danh sách Thanh toán: " + m_v_ds_gd_thanh_toan.V_GD_THANH_TOAN.Rows.Count + " thanh toán";
    }
    private void load_data_2_excel_search(decimal ip_dc_id_dot_tt)
    {
        string v_str_ma_dot_tt = "";
        if (ip_dc_id_dot_tt == 0) v_str_ma_dot_tt = "All";
        else v_str_ma_dot_tt = get_ma_dot_tt_by_id_dot(CIPConvert.ToDecimal(m_cbo_dot_thanh_toan.SelectedValue));
        m_v_ds_gd_thanh_toan.Clear();
        if (m_rdl_loai_hop_dong.Items[0].Selected)
        // All
        {
            m_str_loai_hd = "All";
        }
        else if (m_rdl_loai_hop_dong.Items[1].Selected)
        // Vận hành
        {
            m_str_loai_hd = "VH";
        }
        // Học liệu
        else m_str_loai_hd = "HL";
        m_us_v_gd_thanh_toan.fill_dataset_by_dot_tt_va_loai_hd(v_str_ma_dot_tt, m_str_loai_hd, 
                                                                CIPConvert.ToDecimal(m_cbo_thang_thanh_toan.SelectedValue), 
                                                                CIPConvert.ToDecimal(m_cbo_nam_thanh_toan.SelectedValue),
                                                                CIPConvert.ToDecimal(m_cbo_don_vi_thanh_toan.SelectedValue), 
                                                                m_v_ds_gd_thanh_toan);
    }
    private decimal get_id_by_so_hop_dong(string ip_str_so_hd)
    {
        US_DM_HOP_DONG_KHUNG v_us_dm_hd_khung = new US_DM_HOP_DONG_KHUNG();
        DS_DM_HOP_DONG_KHUNG v_ds_dm_hd_khung = new DS_DM_HOP_DONG_KHUNG();
        v_us_dm_hd_khung.FillDataset(v_ds_dm_hd_khung, " WHERE SO_HOP_DONG =N'" + ip_str_so_hd + "'");
        if (v_ds_dm_hd_khung.DM_HOP_DONG_KHUNG.Rows.Count > 0)
            return CIPConvert.ToDecimal(v_ds_dm_hd_khung.DM_HOP_DONG_KHUNG.Rows[0][DM_HOP_DONG_KHUNG.ID]);
        return 0;
    }
    private void when_cbo_dot_tt_changed()
    {
        decimal v_dc_id_dot_thanh_toan = CIPConvert.ToDecimal(m_cbo_dot_thanh_toan.SelectedValue);
        US_V_DM_DOT_THANH_TOAN v_us_dot_thanh_toan = new US_V_DM_DOT_THANH_TOAN(v_dc_id_dot_thanh_toan);
        //load_data_2_grid_search_trang_thai(get_ma_dot_tt_by_id_dot(CIPConvert.ToDecimal(m_cbo_dot_thanh_toan.SelectedValue)), CIPConvert.ToDecimal(m_cbo_trang_thai_tt_search.SelectedValue));
    }
    private string cut_string_tam_ung(string ip_str_tam_ung)
    {
        string[] v_str_result = ip_str_tam_ung.Split(' ');
        return (v_str_result[2] + " " + v_str_result[3]);
    }
    private void search_data_show_on_grid(decimal ip_dc_id_dot_tt)
    {
        string v_str_loai_hd = "";
        if (m_rdl_loai_hop_dong.Items[0].Selected)
            v_str_loai_hd = "All";
        else if (m_rdl_loai_hop_dong.Items[1].Selected)
            v_str_loai_hd = "VH";
        else v_str_loai_hd = "HL"; 
        if (ip_dc_id_dot_tt == 0) load_data_2_grid_search("All", v_str_loai_hd, 
                                                            CIPConvert.ToDecimal(m_cbo_thang_thanh_toan.SelectedValue), 
                                                            CIPConvert.ToDecimal(m_cbo_nam_thanh_toan.SelectedValue),
                                                            CIPConvert.ToDecimal(m_cbo_don_vi_thanh_toan.SelectedValue));
        else
            load_data_2_grid_search(get_ma_dot_tt_by_id_dot(ip_dc_id_dot_tt), v_str_loai_hd, 
                                                            CIPConvert.ToDecimal(m_cbo_thang_thanh_toan.SelectedValue), 
                                                            CIPConvert.ToDecimal(m_cbo_nam_thanh_toan.SelectedValue), 
                                                            CIPConvert.ToDecimal(m_cbo_don_vi_thanh_toan.SelectedValue));
    }
    private string get_dv_tt_by_id_dot(decimal ip_dc_id_dot_tt)
    {
        US_V_DM_DOT_THANH_TOAN v_us_dm_dot_tt = new US_V_DM_DOT_THANH_TOAN(ip_dc_id_dot_tt);
        return v_us_dm_dot_tt.strDON_VI_THANH_TOAN;
    }
    private string mapping_nghiem_thu_thuc_te(object ip_obj_nghiem_thu_thuc_te)
    {
        if (ip_obj_nghiem_thu_thuc_te.GetType() == typeof(DBNull))
            return "";
        return CIPConvert.ToStr(ip_obj_nghiem_thu_thuc_te, "#,###");
    }
    private string mapping_so_tien(object ip_obj_nghiem_thu_thuc_te)
    {
        if (ip_obj_nghiem_thu_thuc_te.GetType() == typeof(DBNull)) return "";
        if (CIPConvert.ToDecimal(ip_obj_nghiem_thu_thuc_te) == 0)
            return CIPConvert.ToStr(0);
        return CIPConvert.ToStr(ip_obj_nghiem_thu_thuc_te, "#,###");
    }
    private decimal get_id_trang_thai_dot_tt_da_lap_bang_ke()
    {
        US_CM_DM_TU_DIEN v_us_cm_tu_dien = new US_CM_DM_TU_DIEN();
        DS_CM_DM_TU_DIEN v_ds_tu_dien = new DS_CM_DM_TU_DIEN();
        v_us_cm_tu_dien.FillDataset(v_ds_tu_dien, " WHERE ID_LOAI_TU_DIEN = 14 AND MA_TU_DIEN LIKE N'%DA_LAP_BANG_KE%'");
        if (v_ds_tu_dien.CM_DM_TU_DIEN.Rows.Count == 0) return 504;
        return CIPConvert.ToDecimal(v_ds_tu_dien.CM_DM_TU_DIEN.Rows[0][CM_DM_TU_DIEN.ID]);
    }
    private string mapping_loai_hop_dong()
    {
        if (m_rdl_loai_hop_dong.Items[0].Selected) return "Tất cả";
            if (m_rdl_loai_hop_dong.Items[1].Selected) return "Vận hành";
        return "Học liệu";
    }
    public string mapping_time_to_str(object ip_obj_thoi_gian)
    {
        if (ip_obj_thoi_gian.GetType() != typeof(DBNull))
        {
            return CIPConvert.ToStr(ip_obj_thoi_gian);
        }
        return "";
    }
    private string mapping_string(object ip_obj_str)
    {
        if (ip_obj_str.GetType() != typeof(DBNull))
            return CIPConvert.ToStr(ip_obj_str);
        return "";
    }
    // Thông tin đợt thanh toán
    private void fill_data_2_thong_tin_dot_tt(decimal ip_dc_id_dot)
    {
        if (ip_dc_id_dot != 0)
        {
            US_V_DM_DOT_THANH_TOAN v_us_dm_dot_thanh_toan = new US_V_DM_DOT_THANH_TOAN(ip_dc_id_dot);
            //m_lbl_don_vi_thanh_toan.Text = v_us_dm_dot_thanh_toan.strDON_VI_THANH_TOAN;
            m_lbl_ngay_tt_du_kien.Text = CIPConvert.ToStr(v_us_dm_dot_thanh_toan.datNGAY_TT_DU_KIEN, "dd/MM/yyyy");
            if (!v_us_dm_dot_thanh_toan.IsNGAY_DONG_DOT_TTNull())
                m_lbl_ngay_hoan_tat_tt.Text = CIPConvert.ToStr(v_us_dm_dot_thanh_toan.datNGAY_DONG_DOT_TT, "dd/MM/yyyy");
        }
        search_data_show_on_grid(ip_dc_id_dot);
    }
    #endregion

    #region Export Excel
    private void loadDSExprort(ref string strTable)
    {
        int v_i_so_thu_tu = 0;
        // Mỗi cột dữ liệu ứng với từng dòng là label
        foreach (DataRow grv in this.m_v_ds_gd_thanh_toan.V_GD_THANH_TOAN.Rows)
        {
            strTable += "\n<tr>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + ++v_i_so_thu_tu + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + CIPConvert.ToStr(grv[V_GD_THANH_TOAN.SO_PHIEU_THANH_TOAN]).Trim() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + CIPConvert.ToStr(grv[V_GD_THANH_TOAN.SO_HOP_DONG]).Trim() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_loai_hop_dong_gv(CIPConvert.ToDecimal(grv[V_GD_THANH_TOAN.ID_HOP_DONG_KHUNG])) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_don_vi_quan_ly(CIPConvert.ToDecimal(grv[V_GD_THANH_TOAN.ID_DON_VI_QUAN_LY])) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_time_to_str(grv[V_GD_THANH_TOAN.THOI_GIAN]) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_magv_by_id(CIPConvert.ToDecimal(grv[V_GD_THANH_TOAN.ID_GIANG_VIEN])) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + CIPConvert.ToStr(grv[V_GD_THANH_TOAN.TEN_GIANG_VIEN]).Trim() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + "'" + mapping_string(grv[V_GD_THANH_TOAN.SO_TAI_KHOAN]) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_string(grv[V_GD_THANH_TOAN.TEN_NGAN_HANG]) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + "'" + mapping_string(grv[V_GD_THANH_TOAN.MA_SO_THUE]) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_so_tien(grv[V_GD_THANH_TOAN.GIA_TRI_HOP_DONG]) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_item_field_nghiem_thu_lop_mon(CIPConvert.ToStr(grv[V_GD_THANH_TOAN.LOAI_HOP_DONG]), grv[V_GD_THANH_TOAN.REFERENCE_CODE], grv[V_GD_THANH_TOAN.GIA_TRI_NGHIEM_THU_THUC_TE]) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_item_field_ten_cac_mon(CIPConvert.ToStr(grv[V_GD_THANH_TOAN.LOAI_HOP_DONG]) ,grv[V_GD_THANH_TOAN.GHI_CHU_CAC_MON_PHU_TRACH]) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_so_tien(grv[V_GD_THANH_TOAN.DA_THANH_TOAN]) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_so_tien(grv[V_GD_THANH_TOAN.TONG_TIEN_THANH_TOAN]) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_so_tien(grv[V_GD_THANH_TOAN.SO_TIEN_THUE]) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_so_tien(grv[V_GD_THANH_TOAN.TONG_TIEN_THUC_NHAN]) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_so_tien_con_phai_tt(grv[V_GD_THANH_TOAN.CON_PHAI_THANH_TOAN], grv[V_GD_THANH_TOAN.LOAI_HOP_DONG], grv[V_GD_THANH_TOAN.REFERENCE_CODE]) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_string(grv[V_GD_THANH_TOAN.PO_LAP_THANH_TOAN]) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_string(grv[V_GD_THANH_TOAN.DESCRIPTION]) + "</td>";
            strTable += "\n</tr>";
        }
    }

    private void loadTieuDe(ref string strTable)
    {
        load_data_2_excel_search(CIPConvert.ToDecimal(m_cbo_dot_thanh_toan.SelectedValue));
        strTable += "<table cellpadding='2' cellspacing='0' class='cssTableReport'>";
        strTable += "\n<tr>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width: 100%;  height: 40px; font-size: large; color:White; background-color:#810C15;' nowrap='wrap'>TRM700 - BÁO CÁO CHI TIẾT THANH TOÁN CỦA ĐỢT THANH TOÁN" + "</td>";
        strTable += "\n</tr>";
        //
        strTable += "\n<tr>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>Đợt thanh toán: " + get_ma_dot_tt_by_id_dot(CIPConvert.ToDecimal(m_cbo_dot_thanh_toan.SelectedValue)) + "</td>";
        strTable += "\n</tr>";
        //
        strTable += "\n<tr>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>Đơn vị thanh toán: " + m_cbo_don_vi_thanh_toan.SelectedItem.Text + "</td>";
        strTable += "\n</tr>";
        //
        strTable += "\n<tr>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>Thời gian thanh toán: " + m_lbl_ngay_tt_du_kien.Text + "</td>";
        strTable += "\n</tr>";
        //
        strTable += "\n<tr>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>Loại hợp đồng: " + mapping_loai_hop_dong() + "</td>";
        strTable += "\n</tr>";
        //
        strTable += "\n<tr>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>Ngày hoàn tất thanh toán : " + m_lbl_ngay_hoan_tat_tt.Text + "</td>";
        strTable += "\n</tr>";
        strTable += "\n</table>";
        //table noi dung
        strTable += "<table cellpadding='2' cellspacing='0' class='cssTableReport'>";
        strTable += "\n<tr>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>STT</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Mã đợt TT</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Số HĐ</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Loại hợp đồng</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Đơn vị quản lý HĐ</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Thời gian thực hiện</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Mã giảng viên</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Họ tên</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Số tài khoản</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Tên ngân hàng</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Mã số thuế</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Tổng giá trị HĐ (VNĐ)</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>" + mapping_header_nghiem_thu_lop_mon(m_str_loai_hd) + "</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Tên các môn phụ trách</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Đã thanh toán (VNĐ)</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Tổng tiền thanh toán đợt này (VNĐ)</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Số tiền thuế (VNĐ)</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Tổng tiền thực nhận đợt này (VNĐ)</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Số tiền còn phải thanh toán (VNĐ)</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>PO lập thanh toán</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Ghi chú</td>";
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
            + "{font-family: tahoma; font-size: 11px;font-weight:normal;border: 1px #000000 solid;text-align:left;}"
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
    protected void m_cmd_tim_kiem_Click(object sender, EventArgs e)
    {
        try
        {
            search_data_show_on_grid(CIPConvert.ToDecimal(m_cbo_dot_thanh_toan.SelectedValue));
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
            string strNamFile = "BaoCaoDSThanhToanTheoDVvaThoiGian" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + ".xls";
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
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_grv_danh_sach_du_toan_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            m_grv_danh_sach_du_toan.PageIndex = e.NewPageIndex;
            search_data_show_on_grid(CIPConvert.ToDecimal(m_cbo_dot_thanh_toan.SelectedValue));
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_dot_thanh_toan_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            fill_data_2_thong_tin_dot_tt(CIPConvert.ToDecimal(m_cbo_dot_thanh_toan.SelectedValue));
            search_data_show_on_grid(CIPConvert.ToDecimal(m_cbo_dot_thanh_toan.SelectedValue));
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_thang_thanh_toan_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            load_data_2_cbo_dot_thanh_toan(CIPConvert.ToDecimal(m_cbo_thang_thanh_toan.SelectedValue), CIPConvert.ToDecimal(m_cbo_nam_thanh_toan.SelectedValue), CIPConvert.ToDecimal(m_cbo_don_vi_thanh_toan.SelectedValue));
            search_data_show_on_grid(CIPConvert.ToDecimal(m_cbo_dot_thanh_toan.SelectedValue));
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_nam_thanh_toan_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            load_data_2_cbo_dot_thanh_toan(CIPConvert.ToDecimal(m_cbo_thang_thanh_toan.SelectedValue), CIPConvert.ToDecimal(m_cbo_nam_thanh_toan.SelectedValue), CIPConvert.ToDecimal(m_cbo_don_vi_thanh_toan.SelectedValue));
            search_data_show_on_grid(CIPConvert.ToDecimal(m_cbo_dot_thanh_toan.SelectedValue));
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_don_vi_thanh_toan_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            load_data_2_cbo_dot_thanh_toan(CIPConvert.ToDecimal(m_cbo_thang_thanh_toan.SelectedValue), CIPConvert.ToDecimal(m_cbo_nam_thanh_toan.SelectedValue), CIPConvert.ToDecimal(m_cbo_don_vi_thanh_toan.SelectedValue));
            search_data_show_on_grid(CIPConvert.ToDecimal(m_cbo_dot_thanh_toan.SelectedValue));
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    #endregion
}