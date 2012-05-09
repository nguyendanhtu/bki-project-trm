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

public partial class ChucNang_F602_DuToanHopDongHocLieu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        m_lbl_thong_bao.Text = "";
        m_lbl_thong_bao1.Text = "";
        if (!IsPostBack)
        {
            load_data_2_cbo_dot_thanh_toan();
            load_data_2_cbo_trang_thai_thanh_toan();
            when_cbo_dot_tt_changed();
        }
        m_cmd_check_so_hd.Attributes.Add("onclick", "openPopUp()");
    }

    #region Members
    US_CM_DM_TU_DIEN m_us_cm_tu_dien = new US_CM_DM_TU_DIEN();
    DS_CM_DM_TU_DIEN m_ds_cm_tu_dien = new DS_CM_DM_TU_DIEN();

    US_V_GD_THANH_TOAN m_us_v_gd_thanh_toan = new US_V_GD_THANH_TOAN();
    DS_V_GD_THANH_TOAN m_v_ds_gd_thanh_toan = new DS_V_GD_THANH_TOAN();

    US_V_DM_HOP_DONG_KHUNG m_us_dm_hop_dong_khung = new US_V_DM_HOP_DONG_KHUNG();
    DS_V_DM_HOP_DONG_KHUNG m_ds_dm_hop_dong_khung = new DS_V_DM_HOP_DONG_KHUNG();
    #endregion

    #region Public Interfaces
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
    public string mapping_magv_by_id(decimal ip_dc_id_gv)
    {
        US_V_DM_GIANG_VIEN v_dm_gv = new US_V_DM_GIANG_VIEN(ip_dc_id_gv);
        if (v_dm_gv.IsIDNull()) return "";
        return v_dm_gv.strMA_GIANG_VIEN;
    }
    private string mapping_so_tien(object ip_obj_nghiem_thu_thuc_te)
    {
        if (ip_obj_nghiem_thu_thuc_te.GetType() == typeof(DBNull)) return "";
        if (CIPConvert.ToDecimal(ip_obj_nghiem_thu_thuc_te) == 0)
            return CIPConvert.ToStr(0);
        return CIPConvert.ToStr(ip_obj_nghiem_thu_thuc_te, "#,###");
    }
    #endregion

    #region Private Methods
    // Lấy giá trị số lần
    private string cut_end_string(string ip_str_string)
    {
        return ip_str_string.Substring(ip_str_string.Trim().Length - 1, 1);
    }
    private bool check_dot_tam_ung(int ip_i_next)
    {

        return true;
    }
    // Chỉ load lên những đợt thanh toán chưa kết thúc
    private void load_data_2_cbo_dot_thanh_toan()
    {
        DS_V_DM_DOT_THANH_TOAN v_ds_dot_thanh_toan = new DS_V_DM_DOT_THANH_TOAN();
        US_V_DM_DOT_THANH_TOAN v_us_dot_thanh_toan = new US_V_DM_DOT_THANH_TOAN();
        v_us_dot_thanh_toan.load_dot_thanh_toan_by_trang_thai(get_id_trang_thai_dot_tt_da_lap_dot(),v_ds_dot_thanh_toan);
        //v_us_dot_thanh_toan.FillDataset(v_ds_dot_thanh_toan, " WHERE ID_TRANG_THAI_DOT_TT = " + get_id_trang_thai_dot_tt_da_lap_dot()+" ORDER BY ID DESC");
        for (int i = 0; i < v_ds_dot_thanh_toan.V_DM_DOT_THANH_TOAN.Rows.Count; i++)
        {
            if (CIPConvert.ToDecimal(v_ds_dot_thanh_toan.V_DM_DOT_THANH_TOAN.Rows[i][V_DM_DOT_THANH_TOAN.ID]) != get_id_of_dot_tt_kho())
                m_cbo_dot_thanh_toan.Items.Add(new ListItem(CIPConvert.ToStr(v_ds_dot_thanh_toan.V_DM_DOT_THANH_TOAN.Rows[i][V_DM_DOT_THANH_TOAN.TEN_DOT_TT]), CIPConvert.ToStr(v_ds_dot_thanh_toan.V_DM_DOT_THANH_TOAN.Rows[i][V_DM_DOT_THANH_TOAN.ID])));
        }
    }
    private decimal get_id_of_dot_tt_kho()
    {
        US_V_DM_DOT_THANH_TOAN v_us_v_dm_dot_tt = new US_V_DM_DOT_THANH_TOAN();
        DS_V_DM_DOT_THANH_TOAN v_ds_v_dm_dot_tt = new DS_V_DM_DOT_THANH_TOAN();
        v_us_v_dm_dot_tt.FillDataset(v_ds_v_dm_dot_tt, " WHERE MA_DOT_TT LIKE '%KHO%'");
        if (v_ds_v_dm_dot_tt.V_DM_DOT_THANH_TOAN.Rows.Count == 0)
            return 25;
        return CIPConvert.ToDecimal(v_ds_v_dm_dot_tt.V_DM_DOT_THANH_TOAN.Rows[0][V_DM_DOT_THANH_TOAN.ID]);
    }
    private void load_data_2_cbo_trang_thai_thanh_toan()
    {
        m_us_cm_tu_dien.FillDataset(m_ds_cm_tu_dien, " WHERE ID_LOAI_TU_DIEN= " + (int)e_loai_tu_dien.TRANG_THAI_THANH_TOAN);

        m_cbo_trang_thai_thanh_toan.DataTextField = CM_DM_TU_DIEN.TEN;
        m_cbo_trang_thai_thanh_toan.DataValueField = CM_DM_TU_DIEN.ID;
        m_cbo_trang_thai_thanh_toan.DataSource = m_ds_cm_tu_dien.CM_DM_TU_DIEN;
        m_cbo_trang_thai_thanh_toan.DataBind();
    }
    private void load_data_2_grid(string ip_str_ma_dot_tt)
    {
        if (ip_str_ma_dot_tt == "")
        {
            m_lbl_thong_bao.Visible = true;
            m_lbl_thong_bao.Text = "Chưa tạo Đợt thanh toán";
            return;
        }
        else
        {
            //US_V_GD_THANH_TOAN v_us_gd_thanh_toan = new US_V_GD_THANH_TOAN();
            //DS_V_GD_THANH_TOAN v_ds_gd_thanh_toan = new DS_V_GD_THANH_TOAN();
            // Số phiếu thanh toán là mã đợt thanh toán
            m_us_v_gd_thanh_toan.f501_load_thanh_toan_by_ma_dot_tt_va_loai_hd(ip_str_ma_dot_tt, "HL", m_v_ds_gd_thanh_toan);
            if (m_v_ds_gd_thanh_toan.V_GD_THANH_TOAN.Rows.Count == 0)
            {
                m_lbl_thong_bao.Visible = true;
                m_lbl_thong_bao.Text = "Chưa có Thanh toán nào ứng với Đợt thanh toán này";
            }
            m_grv_danh_sach_du_toan.DataSource = m_v_ds_gd_thanh_toan.V_GD_THANH_TOAN;
            m_grv_danh_sach_du_toan.DataBind();
            m_lbl_result.Text = "Danh sách bảng kê hợp đồng học liệu: " + m_v_ds_gd_thanh_toan.V_GD_THANH_TOAN.Rows.Count+" bản ghi";
        }
    }
    private void load_data_2_export_excel(string ip_str_ma_dot_tt)
    {
        if (ip_str_ma_dot_tt == "")
        {
            m_lbl_thong_bao.Visible = true;
            m_lbl_thong_bao.Text = "Chưa tạo Đợt thanh toán";
            return;
        }
        else
        {
            // Số phiếu thanh toán là mã đợt thanh toán
            m_us_v_gd_thanh_toan.f501_load_thanh_toan_by_ma_dot_tt_va_loai_hd(ip_str_ma_dot_tt, "HL", m_v_ds_gd_thanh_toan);
        }
    }
    private string get_ma_trang_thai_dot_tt_by_id(decimal ip_dc_id_dot_tt)
    {
        US_CM_DM_TU_DIEN v_us_cm_dm_tu_dien = new US_CM_DM_TU_DIEN(ip_dc_id_dot_tt);
        return v_us_cm_dm_tu_dien.strMA_TU_DIEN;
    }
    private decimal get_id_trang_thai_dot_tt_by_ma(string ip_str_ma_dot_tt)
    {
        US_CM_DM_TU_DIEN v_us_cm_dm_tu_dien = new US_CM_DM_TU_DIEN("DOT_THANH_TOAN", ip_str_ma_dot_tt);
        return v_us_cm_dm_tu_dien.dcID;
    }
    private void reset_controls()
    {
        m_txt_so_hop_dong.Text = "";
        m_txt_so_tien_thanh_toan.Text = "";
        m_txt_so_tien_thue1.Text = "";
        m_txt_so_tien_thuc_nhan.Text = "";
        m_cbo_lan_so.SelectedIndex = 0;
        m_txt_gia_tri_nghiem_thu_thuc_te.Text = "";
        rdl_noi_dung_list.Items[0].Selected = true;
        m_txt_mo_ta.Text = "";
        m_cbo_trang_thai_thanh_toan.SelectedIndex = 0;
        hdf_id_gv.Value = "";
    }
    private void when_cbo_dot_tt_changed()
    {
        if (m_cbo_dot_thanh_toan.Items.Count == 0)
        {
            m_lbl_thong_bao1.Text = "Chưa tồn tại đợt thanh toán nào !";
            return;
        }
        decimal v_dc_id_dot_thanh_toan = CIPConvert.ToDecimal(m_cbo_dot_thanh_toan.SelectedValue);
        US_V_DM_DOT_THANH_TOAN v_us_dot_thanh_toan = new US_V_DM_DOT_THANH_TOAN(v_dc_id_dot_thanh_toan);
        m_dat_ngay_thanh_toan.SelectedDate = v_us_dot_thanh_toan.datNGAY_TT_DU_KIEN;
        load_data_2_grid(get_ma_dot_tt_by_id_dot(CIPConvert.ToDecimal(m_cbo_dot_thanh_toan.SelectedValue)));
    }
    private decimal get_id_dot_tt_by_ma_dot(string ip_str_ma_dot)
    {
        DS_V_DM_DOT_THANH_TOAN v_ds_dot_tt = new DS_V_DM_DOT_THANH_TOAN();
        US_V_DM_DOT_THANH_TOAN v_us_dot_thanh_toan = new US_V_DM_DOT_THANH_TOAN();
        v_us_dot_thanh_toan.FillDataset(v_ds_dot_tt, " WHERE MA_DOT_TT = '" + ip_str_ma_dot + "'");
        if (v_ds_dot_tt.V_DM_DOT_THANH_TOAN.Rows.Count == 0) return 0;
        return CIPConvert.ToDecimal(v_ds_dot_tt.V_DM_DOT_THANH_TOAN.Rows[0][V_DM_DOT_THANH_TOAN.ID]);
    }
    private decimal get_id_hd_khung_by_so_hd(string ip_str_so_hd)
    {
        DS_V_DM_HOP_DONG_KHUNG v_ds_hd_khung = new DS_V_DM_HOP_DONG_KHUNG();
        US_V_DM_HOP_DONG_KHUNG v_us_hd_khung = new US_V_DM_HOP_DONG_KHUNG();
        v_us_hd_khung.FillDataset(v_ds_hd_khung, " WHERE  SO_HOP_DONG = N'" + ip_str_so_hd + "'");
        if (v_ds_hd_khung.V_DM_HOP_DONG_KHUNG.Rows.Count == 0) return 0;
        return CIPConvert.ToDecimal(v_ds_hd_khung.V_DM_HOP_DONG_KHUNG.Rows[0][V_DM_HOP_DONG_KHUNG.ID]);
    }
    private void us_obj_2_form(US_V_GD_THANH_TOAN ip_us_gd_thanh_toan)
    {
        m_cbo_dot_thanh_toan.SelectedValue = CIPConvert.ToStr(get_id_dot_tt_by_ma_dot(ip_us_gd_thanh_toan.strSO_PHIEU_THANH_TOAN));
        m_txt_so_hop_dong.Text = get_so_hd_khung_by_id_hd(ip_us_gd_thanh_toan.dcID_HOP_DONG_KHUNG);
        m_txt_so_hop_dong.Enabled = false;
        m_dat_ngay_thanh_toan.SelectedDate = ip_us_gd_thanh_toan.datNGAY_THANH_TOAN;
        m_txt_so_tien_thanh_toan.Text = CIPConvert.ToStr(ip_us_gd_thanh_toan.dcTONG_TIEN_THANH_TOAN, "#,###");
        m_txt_so_tien_thuc_nhan.Text = CIPConvert.ToStr(ip_us_gd_thanh_toan.dcTONG_TIEN_THUC_NHAN, "#,###");
        if (ip_us_gd_thanh_toan.dcSO_TIEN_THUE == 0) m_txt_so_tien_thue1.Text = CIPConvert.ToStr(0);
        else m_txt_so_tien_thue1.Text = CIPConvert.ToStr(ip_us_gd_thanh_toan.dcSO_TIEN_THUE, "#,###");
        m_cbo_trang_thai_thanh_toan.SelectedValue = CIPConvert.ToStr(ip_us_gd_thanh_toan.dcID_TRANG_THAI_THANH_TOAN);
        m_txt_mo_ta.Text = ip_us_gd_thanh_toan.strDESCRIPTION;
        hdf_id_trang_thai_thanh_toan_cu.Value = CIPConvert.ToStr(ip_us_gd_thanh_toan.dcID_TRANG_THAI_THANH_TOAN);
        // Thanh toán này là tạm ứng
        if (ip_us_gd_thanh_toan.strREFERENCE_CODE != "")
        {
            rdl_noi_dung_list.Items[1].Selected = true;
            rdl_noi_dung_list.Items[0].Selected = false;
            m_cbo_lan_so.SelectedValue = cut_end_string(ip_us_gd_thanh_toan.strREFERENCE_CODE);
        }
        else // Đây là thanh lý
        {
            rdl_noi_dung_list.Items[0].Selected = true; //Thanh lý
            rdl_noi_dung_list.Items[1].Selected = false; // Tạm ứng
            m_cbo_lan_so.SelectedIndex = 0;
            m_txt_gia_tri_nghiem_thu_thuc_te.Text =CIPConvert.ToStr(ip_us_gd_thanh_toan.dcGIA_TRI_NGHIEM_THU_THUC_TE,"#,###");
        }
    }
    private void form_2_us_obj(US_V_GD_THANH_TOAN op_us_gd_thanh_toan)
    {
        op_us_gd_thanh_toan.strSO_PHIEU_THANH_TOAN = get_ma_dot_tt_by_id_dot(CIPConvert.ToDecimal(m_cbo_dot_thanh_toan.SelectedValue));
        op_us_gd_thanh_toan.dcID_HOP_DONG_KHUNG = get_id_hd_khung_by_so_hd(m_txt_so_hop_dong.Text.Trim());
        if (m_dat_ngay_thanh_toan.SelectedDate == CIPConvert.ToDatetime("01/01/0001", "dd/MM/yyyy"))
        {
            string sScript;
            sScript = "<script language='javascript'>alert('Bạn phải nhập ngày thanh toán');</script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "onload", sScript);
            m_dat_ngay_thanh_toan.Focus();
            return;
        }
        else op_us_gd_thanh_toan.datNGAY_THANH_TOAN = m_dat_ngay_thanh_toan.SelectedDate;
        op_us_gd_thanh_toan.dcTONG_TIEN_THANH_TOAN = CIPConvert.ToDecimal(m_txt_so_tien_thanh_toan.Text);
        if (m_txt_so_tien_thuc_nhan.Text == "") op_us_gd_thanh_toan.dcTONG_TIEN_THUC_NHAN = 0;
        else op_us_gd_thanh_toan.dcTONG_TIEN_THUC_NHAN = CIPConvert.ToDecimal(m_txt_so_tien_thuc_nhan.Text);
        if (m_txt_so_tien_thue1.Text == "") op_us_gd_thanh_toan.dcSO_TIEN_THUE = 0;
        else op_us_gd_thanh_toan.dcSO_TIEN_THUE = CIPConvert.ToDecimal(m_txt_so_tien_thue1.Text);
        op_us_gd_thanh_toan.dcID_TRANG_THAI_THANH_TOAN = CIPConvert.ToDecimal(m_cbo_trang_thai_thanh_toan.SelectedValue);
        op_us_gd_thanh_toan.strDESCRIPTION = m_txt_mo_ta.Text.Trim();
        if (Session["UserName"].GetType() != typeof(DBNull))
            op_us_gd_thanh_toan.strPO_LAP_THANH_TOAN = CIPConvert.ToStr(Session["UserName"]);
        if (rdl_noi_dung_list.Items[1].Selected == true)
            op_us_gd_thanh_toan.SetGIA_TRI_NGHIEM_THU_THUC_TENull();
        else op_us_gd_thanh_toan.dcGIA_TRI_NGHIEM_THU_THUC_TE =CIPConvert.ToDecimal(m_txt_gia_tri_nghiem_thu_thuc_te.Text.Trim());
        if (rdl_noi_dung_list.Items[1].Selected)
        {
            op_us_gd_thanh_toan.strREFERENCE_CODE = "đợt " + m_cbo_lan_so.SelectedValue;
        }
        else op_us_gd_thanh_toan.SetREFERENCE_CODENull();
    }
    private void load_data_2_us_by_id_and_show_on_form(int ip_i_thanh_toan_selected)
    {
        try
        {
            decimal v_dc_id_thanh_toan = CIPConvert.ToDecimal(m_grv_danh_sach_du_toan.DataKeys[ip_i_thanh_toan_selected].Value);
            hdf_id_gv.Value = CIPConvert.ToStr(v_dc_id_thanh_toan);
            US_V_GD_THANH_TOAN v_us_gd_thanh_toan = new US_V_GD_THANH_TOAN(v_dc_id_thanh_toan);

            // Load data to form 
            us_obj_2_form(v_us_gd_thanh_toan);
        }
        catch (Exception v_e)
        {

            throw v_e;
        }

    }
    private void delete_row_thanh_toan(int ip_i_id_thanh_toan)
    {
        // Lấy được ID thanh tóan
        decimal v_dc_id_thanh_toan = CIPConvert.ToDecimal(m_grv_danh_sach_du_toan.DataKeys[ip_i_id_thanh_toan].Value);
        m_us_v_gd_thanh_toan.dcID = v_dc_id_thanh_toan;
        // Xóa GD_THANH_TOAN
        m_us_v_gd_thanh_toan.DeleteByID(v_dc_id_thanh_toan);
        m_lbl_thong_bao.Text = "Xóa bản ghi thành công";
        // Load lại dữ liệu
        load_data_2_grid(get_ma_dot_tt_by_id_dot(CIPConvert.ToDecimal(m_cbo_dot_thanh_toan.SelectedValue)));
    }
    private decimal get_id_trang_thai_dot_tt_da_lap_dot()
    {
        US_CM_DM_TU_DIEN v_us_cm_tu_dien = new US_CM_DM_TU_DIEN();
        DS_CM_DM_TU_DIEN v_ds_tu_dien = new DS_CM_DM_TU_DIEN();
        v_us_cm_tu_dien.FillDataset(v_ds_tu_dien, " WHERE ID_LOAI_TU_DIEN = 14 AND MA_TU_DIEN LIKE N'%DA_LAP_DOT%'");
        if (v_ds_tu_dien.CM_DM_TU_DIEN.Rows.Count == 0) return 503;
        return CIPConvert.ToDecimal(v_ds_tu_dien.CM_DM_TU_DIEN.Rows[0][CM_DM_TU_DIEN.ID]);
    }
    private bool check_exist_so_hop_dong(string ip_str_so_hd)
    {
        US_DM_HOP_DONG_KHUNG v_us_dm_hop_dong_khung = new US_DM_HOP_DONG_KHUNG();
        DS_DM_HOP_DONG_KHUNG v_ds_dm_hop_dong_khung = new DS_DM_HOP_DONG_KHUNG();
        v_us_dm_hop_dong_khung.FillDataset(v_ds_dm_hop_dong_khung, " WHERE SO_HOP_DONG=N'"+ip_str_so_hd+"'");
        if (v_ds_dm_hop_dong_khung.DM_HOP_DONG_KHUNG.Rows.Count == 0)
            return false; // Nghĩa là không tồn tại số hợp đồng đó
        return true; // Nghĩa là tồn tại số hợp đồng đó
    }
    private string get_ma_trang_thai_thanh_toan_by_id(decimal ip_dc_id_tt)
    {
        US_CM_DM_TU_DIEN v_us_cm_dm_tu_dien = new US_CM_DM_TU_DIEN(ip_dc_id_tt);
        return v_us_cm_dm_tu_dien.strMA_TU_DIEN;
    }
    // Kiểm tra đây có phải lập bảng kê cho thanh lý hợp đồng ko?
    private bool check_nhap_nghiem_thu_thuc_te()
    {
         if(rdl_noi_dung_list.Items[0].Selected ==true && m_txt_gia_tri_nghiem_thu_thuc_te.Text.Trim().Equals("")) return false;
       return true;
    }
     private bool check_nghiem_thu_va_thanh_toan(decimal ip_dc_id_hd_khung)
     {
         if (rdl_noi_dung_list.Items[0].Selected == true)
             if (CIPConvert.ToDecimal(m_txt_gia_tri_nghiem_thu_thuc_te.Text.Trim()) == (CIPConvert.ToDecimal(m_txt_so_tien_thanh_toan.Text.Trim()))+ get_so_tien_da_thanh_toan(ip_dc_id_hd_khung))
                 return true;
             else return false;
         return true;
     }
     private bool check_nghiem_thu_va_thanh_toan_update(decimal ip_dc_id_hd_khung)
     {
         if (rdl_noi_dung_list.Items[0].Selected == true)
             if (CIPConvert.ToDecimal(m_txt_gia_tri_nghiem_thu_thuc_te.Text.Trim()) == (CIPConvert.ToDecimal(m_txt_so_tien_thanh_toan.Text.Trim())) + get_so_tien_da_thanh_toan_update(ip_dc_id_hd_khung))
                 return true;
             else return false;
         return true;
     }
     private decimal get_id_don_vi_thanh_toan_by_id_dot_tt(decimal ip_dc_id_dot_tt)
     {
         US_V_DM_DOT_THANH_TOAN v_us_dot_tt = new US_V_DM_DOT_THANH_TOAN(ip_dc_id_dot_tt);
         return v_us_dot_tt.dcID_DON_VI_THANH_TOAN;
     }
     private void check_so_lan_tam_ung()
     {
 
     }
    // Kiểm tra hợp đồng đã được thanh lý chưa? 
    private bool check_thanh_ly(decimal ip_dc_id_hop_dong_khung)
      {
            US_V_GD_THANH_TOAN v_us_v_gd_tt = new US_V_GD_THANH_TOAN();
            DS_V_GD_THANH_TOAN v_ds_v_gd_tt = new DS_V_GD_THANH_TOAN();
            // lấy toàn bộ thanh toán của hợp đồng theo id_hop_dong
            v_us_v_gd_tt.FillDataset(v_ds_v_gd_tt, " WHERE ID_HOP_DONG_KHUNG=" + ip_dc_id_hop_dong_khung + " ORDER BY ID");
            // Nếu đã có thanh toán
            if (v_ds_v_gd_tt.V_GD_THANH_TOAN.Rows.Count > 0)
                // kiểm tra xem đã thanh lý chưa
                // Sử dụng dòng cuối cùng, ứng với thanh toán cuối cùng của hd này
                // Nếu đã thanh lý, reference_code là null
                if (v_ds_v_gd_tt.V_GD_THANH_TOAN.Rows[v_ds_v_gd_tt.V_GD_THANH_TOAN.Rows.Count - 1][V_GD_THANH_TOAN.REFERENCE_CODE].GetType() == typeof(DBNull))
                    return false; // Nghĩa là đã được thanh lý
            return true; // Chưa đc thanh lý
     }
    // Kiểm tra xem hợp đồng có đúng là do đơn vị thanh toán đó thanh toán không???
     private bool check_hop_dong_ung_voi_dv_thanh_toan(decimal ip_dc_id_dv_thanh_toan, decimal ip_dc_id_hop_dong)
     {
         US_DM_HOP_DONG_KHUNG v_us_dm_hop_dong = new US_DM_HOP_DONG_KHUNG(ip_dc_id_hop_dong);
         if (v_us_dm_hop_dong.dcID_DON_VI_THANH_TOAN != ip_dc_id_dv_thanh_toan) return false;
         return true;
     }
     private string get_ten_dv_thanh_toan(decimal ip_dc_id_dv_thanh_toan)
     {
         US_DM_DON_VI_THANH_TOAN v_us_dm_dv_tt = new US_DM_DON_VI_THANH_TOAN(ip_dc_id_dv_thanh_toan);
         return v_us_dm_dv_tt.strTEN_DON_VI;
     }
     private decimal get_so_tien_da_tt(decimal ip_dc_id_so_hd)
     {
         US_V_GD_THANH_TOAN v_us_v_gd_tt = new US_V_GD_THANH_TOAN();
         DS_V_GD_THANH_TOAN v_ds_v_gd_tt = new DS_V_GD_THANH_TOAN();
         v_us_v_gd_tt.FillDataset(v_ds_v_gd_tt," WHERE ID_HOP_DONG_KHUNG ="+ip_dc_id_so_hd);
         return CIPConvert.ToDecimal(v_ds_v_gd_tt.V_GD_THANH_TOAN.Rows[0][V_GD_THANH_TOAN.DA_THANH_TOAN]);
     }
     private int get_so_lan_tam_ung(decimal ip_dc_id_hd_khung)
     {
        US_V_GD_THANH_TOAN v_us_v_gd_tt = new US_V_GD_THANH_TOAN();
        DS_V_GD_THANH_TOAN v_ds_v_gd_tt = new DS_V_GD_THANH_TOAN();
        // lấy toàn bộ thanh toán của hợp đồng theo id_hop_dong
        v_us_v_gd_tt.f601_load_thanh_toan_theo_hop_dong_de_kiem_tra(ip_dc_id_hd_khung,v_ds_v_gd_tt);
        string v_str_so_lan_tam_ung;
        // Nếu đã có thanh toán
        if (v_ds_v_gd_tt.V_GD_THANH_TOAN.Rows.Count > 0)
        {
            v_str_so_lan_tam_ung = cut_end_string(CIPConvert.ToStr(v_ds_v_gd_tt.V_GD_THANH_TOAN.Rows[v_ds_v_gd_tt.V_GD_THANH_TOAN.Rows.Count - 1][V_GD_THANH_TOAN.REFERENCE_CODE]));
            return int.Parse(v_str_so_lan_tam_ung);
        }
         // Nếu chưa có thanh toán nào --> chưa có tạm ứng
         return 0;
     }
     private string mapping_string(object ip_obj_string)
     {
         if (ip_obj_string.GetType() == typeof(DBNull)) return "";
         return CIPConvert.ToStr(ip_obj_string);
     }
     private decimal get_so_tien_da_thanh_toan(decimal ip_dc_id_hop_dong_khung)
     {
         US_V_GD_THANH_TOAN v_us_v_gd_tt = new US_V_GD_THANH_TOAN();
         DS_V_GD_THANH_TOAN v_ds_v_gd_tt = new DS_V_GD_THANH_TOAN();
         // lấy toàn bộ thanh toán của hợp đồng theo id_hop_dong
         v_us_v_gd_tt.f601_load_thanh_toan_theo_hop_dong_de_kiem_tra(ip_dc_id_hop_dong_khung, v_ds_v_gd_tt);
         // Nếu đã có thanh toán
         if (v_ds_v_gd_tt.V_GD_THANH_TOAN.Rows.Count > 0)
         {
             decimal v_dc_so_tien_da_tt = 0;
             //string v_str_so_lan_tam_ung = cut_end_string(CIPConvert.ToStr(v_ds_v_gd_tt.V_GD_THANH_TOAN.Rows[v_ds_v_gd_tt.V_GD_THANH_TOAN.Rows.Count - 1][V_GD_THANH_TOAN.REFERENCE_CODE]));
             v_dc_so_tien_da_tt += CIPConvert.ToDecimal(v_ds_v_gd_tt.V_GD_THANH_TOAN.Rows[v_ds_v_gd_tt.V_GD_THANH_TOAN.Rows.Count - 1][V_GD_THANH_TOAN.DA_THANH_TOAN]) + CIPConvert.ToDecimal(v_ds_v_gd_tt.V_GD_THANH_TOAN.Rows[v_ds_v_gd_tt.V_GD_THANH_TOAN.Rows.Count - 1][V_GD_THANH_TOAN.TONG_TIEN_THANH_TOAN]);
             return v_dc_so_tien_da_tt;
         }
         else return 0;
     }
     private decimal get_so_tien_da_thanh_toan_update(decimal ip_dc_id_hop_dong_khung)
     {
         US_V_GD_THANH_TOAN v_us_v_gd_tt = new US_V_GD_THANH_TOAN();
         DS_V_GD_THANH_TOAN v_ds_v_gd_tt = new DS_V_GD_THANH_TOAN();
         // lấy toàn bộ thanh toán của hợp đồng theo id_hop_dong
         v_us_v_gd_tt.FillDataset(v_ds_v_gd_tt, " WHERE ID_HOP_DONG_KHUNG=" + ip_dc_id_hop_dong_khung + " ORDER BY ID");
         // Nếu đã có thanh toán
         if (v_ds_v_gd_tt.V_GD_THANH_TOAN.Rows.Count > 0)
         {
             decimal v_dc_so_tien_da_tt = 0;
             //string v_str_so_lan_tam_ung = cut_end_string(CIPConvert.ToStr(v_ds_v_gd_tt.V_GD_THANH_TOAN.Rows[v_ds_v_gd_tt.V_GD_THANH_TOAN.Rows.Count - 1][V_GD_THANH_TOAN.REFERENCE_CODE]));
             v_dc_so_tien_da_tt += CIPConvert.ToDecimal(v_ds_v_gd_tt.V_GD_THANH_TOAN.Rows[v_ds_v_gd_tt.V_GD_THANH_TOAN.Rows.Count - 1][V_GD_THANH_TOAN.DA_THANH_TOAN]);
             return v_dc_so_tien_da_tt;
         }
         else return 0;
     }
     private bool check_trung_hop_dong(string ip_str_so_hd)
     {
         m_us_dm_hop_dong_khung.FillDataset(m_ds_dm_hop_dong_khung, " WHERE SO_HOP_DONG = N'" + ip_str_so_hd + "'");
         if (m_ds_dm_hop_dong_khung.V_DM_HOP_DONG_KHUNG.Rows.Count > 1) return false; // có hợp đồng trùng
         return true;
     }
    #endregion

    #region Export Excel
     private void loadDSExprort(ref string strTable)
     {
         int v_i_so_thu_tu = 0;
         load_data_2_export_excel(get_ma_dot_tt_by_id_dot(CIPConvert.ToDecimal(m_cbo_dot_thanh_toan.SelectedValue)));
         // Mỗi cột dữ liệu ứng với từng dòng là label
         foreach (DataRow grv in this.m_v_ds_gd_thanh_toan.V_GD_THANH_TOAN.Rows)
         {
             strTable += "\n<tr>";
             strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + ++v_i_so_thu_tu + "</td>";
             strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + CIPConvert.ToStr(grv[V_GD_THANH_TOAN.SO_PHIEU_THANH_TOAN]).Trim() + "</td>"; // Mã đợt thanh toán
             strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + CIPConvert.ToStr(grv[V_GD_THANH_TOAN.SO_HOP_DONG]).Trim() + "</td>"; // Số hợp đồng
             strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_magv_by_id(CIPConvert.ToDecimal(grv[V_GD_THANH_TOAN.ID_GIANG_VIEN])) + "</td>";
             strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + CIPConvert.ToStr(grv[V_GD_THANH_TOAN.TEN_GIANG_VIEN]).Trim() + "</td>";
             strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_so_tien(grv[V_GD_THANH_TOAN.GIA_TRI_NGHIEM_THU_THUC_TE]) + "</td>";
             strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_so_tien(grv[V_GD_THANH_TOAN.TONG_TIEN_THANH_TOAN]) + "</td>";
             strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_so_tien(grv[V_GD_THANH_TOAN.SO_TIEN_THUE]) + "</td>";
             strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_so_tien(grv[V_GD_THANH_TOAN.TONG_TIEN_THUC_NHAN]) + "</td>";
             strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + CIPConvert.ToStr(grv[V_GD_THANH_TOAN.NGAY_THANH_TOAN],"dd/MM/yyyy") + "</td>";
             strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_string(grv[V_GD_THANH_TOAN.DESCRIPTION]) + "</td>";  // Mô tả, ghi chú
             strTable += "\n</tr>";
         }
     }

     private void loadTieuDe(ref string strTable)
     {
         strTable += "<table cellpadding='2' cellspacing='0' class='cssTableReport'>";
         strTable += "\n<tr>";
         strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
         strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
         strTable += "\n<td><align='center' class='cssTableView' style='width: 100%;  height: 40px; font-size: large; color:White; background-color:#810C15;' nowrap='wrap'>DANH SÁCH THANH TOÁN HỢP ĐỒNG HỌC LIỆU" + "</td>";
         strTable += "\n</tr>";
         //
         strTable += "\n<tr>";
         strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
         strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
         strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>Đợt thanh toán: " + get_ma_dot_tt_by_id_dot(CIPConvert.ToDecimal(m_cbo_dot_thanh_toan.SelectedValue)) + "</td>";
         strTable += "\n</tr>";
         //
         strTable += "\n</table>";

         //table noi dung
         strTable += "<table cellpadding='2' cellspacing='0' class='cssTableReport'>";
         strTable += "\n<tr>";
         strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>STT</td>";
         strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Mã đợt thanh toán</td>";
         strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Số Hợp đồng</td>";
         strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Mã giảng viên</td>";
         strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Tên giảng viên</td>";
         strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Giá trị nghiệm thu thực tế (VNĐ)</td>";
         strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Tổng tiền thanh toán đợt này (VNĐ)</td>";
         strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Số tiền thuế (VNĐ)</td>";
         strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Tổng tiền thực nhận đợt này (VNĐ)</td>";
         strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Ngày thanh toán</td>";
         strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Mô tả</td>";
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
    protected void m_cmd_check_so_hd_Click(object sender, EventArgs e)
    {
        try
        {
            hdf_check_click_kiem_tra_so_hd.Value = "Đã check";
            //lbl_da_tt.Text = CIPConvert.ToStr(get_so_tien_da_tt(get_id_hd_khung_by_so_hd(m_txt_so_hop_dong.Text.Trim())),"#,###");
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cmd_luu_du_lieu_Click(object sender, EventArgs e)
    {
        try
        {
            if (hdf_check_click_kiem_tra_so_hd.Value == "")
            {
                string someScript;
                someScript = "<script language='javascript'>alert('Bạn chưa kiểm tra lại số hợp đồng. Nhấn nút Kiểm tra để thực hiện việc đó.');</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "oncheck", someScript);
                return;
            }
            if (!check_exist_so_hop_dong(m_txt_so_hop_dong.Text.Trim()))
            {
                string Script;
                Script = "<script language='javascript'>alert('Số hợp đồng không tồn tại trong hệ thống. Hãy kiểm tra lại số hợp đồng!');</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "oncheck1", Script);
                //m_lbl_mess.Text = "";
                return;
            }
            // Check trùng số hợp đồng
            if (!check_trung_hop_dong(m_txt_so_hop_dong.Text.Trim()))
            {
                string Script;
                Script = "<script language='javascript'>alert('Tồn tại số hợp đồng trùng với số hợp đồng này. Hãy xử lý trước khi lên bảng kê cho hợp đồng này!');</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "oncheck1", Script);
                return;
            }

            decimal v_dc_id_hop_dong_khung = get_id_hd_khung_by_so_hd(m_txt_so_hop_dong.Text.Trim());
            if (!check_thanh_ly(v_dc_id_hop_dong_khung))
            {
                string someScript;
                someScript = "<script language='javascript'>{ alert('Hợp đồng này đã được thanh lý!'); window.close(); }</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "oncheck0", someScript);
                return;
            }
            // Kiểm tra đơn vị thanh toán
            decimal v_dc_id_dv_tt = get_id_don_vi_thanh_toan_by_id_dot_tt(CIPConvert.ToDecimal(m_cbo_dot_thanh_toan.SelectedValue));
            if (!check_hop_dong_ung_voi_dv_thanh_toan(v_dc_id_dv_tt, v_dc_id_hop_dong_khung))
            {
                string Script;
                Script = "<script language='javascript'>alert('Hợp đồng này không do "+get_ten_dv_thanh_toan(v_dc_id_dv_tt)+" thanh toán');</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "oncheck3", Script);
                //m_lbl_mess.Text = "";
                return;
            }
            // Nếu là thanh lý thì yêu cầu nhập nghiệm thu thực tế
            if (rdl_noi_dung_list.Items[0].Selected == true)
            {
                if (m_txt_gia_tri_nghiem_thu_thuc_te.Text.Trim().Equals(""))
                {
                    string soScript;
                    soScript = "<script language='javascript'>alert('Đây là lần thanh lý hợp đồng. Xin hãy nhập tổng giá trị nghiệm thu thực tế');</script>";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "oncheck2", soScript);
                    return;
                }
            }
            else
            {
                // Nếu là tạm ứng thì yêu cầu nhập đợt tạm ứng lớn hơn 1 đơn vị đợt đã tạm ứng
                int v_i_so_lan_tam_ung = get_so_lan_tam_ung(v_dc_id_hop_dong_khung);
                // Nếu chưa có tạm ứng
                if (v_i_so_lan_tam_ung == 0)
                {
                    // Nếu chưa có tạm ứng mà chọn đợt >=2
                    if (int.Parse(m_cbo_lan_so.SelectedValue) > v_i_so_lan_tam_ung + 1)
                    {
                        string soScript;
                        soScript = "<script language='javascript'>alert('Hợp đồng này chưa được tạm ứng. Chọn đợt tạm ứng là 1');</script>";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "oncheck4", soScript);
                        m_cbo_lan_so.SelectedValue = CIPConvert.ToStr(1);
                        return;
                    }
                }
                // Nếu đã có tạm ứng
                else
                {
                    // đợt tạm ứng chọn ko phù hợp
                    if (int.Parse(m_cbo_lan_so.SelectedValue) <= v_i_so_lan_tam_ung || int.Parse(m_cbo_lan_so.SelectedValue) > v_i_so_lan_tam_ung + 1)
                    {
                        string soScript;
                        soScript = "<script language='javascript'>alert('Hợp đồng này đã được tạm ứng " + v_i_so_lan_tam_ung + " lần. Hãy chọn đợt tạm ứng là " + (v_i_so_lan_tam_ung + 1) + "');</script>";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "oncheck5", soScript);
                        m_cbo_lan_so.SelectedValue = CIPConvert.ToStr(v_i_so_lan_tam_ung + 1);
                        return;
                    }
                }
            }
            if (!check_nghiem_thu_va_thanh_toan(v_dc_id_hop_dong_khung))
            {
                string soScript;
                soScript = "<script language='javascript'>alert('Giá trị nghiệm thu thực tế và tổng tiền thanh toán phải bằng nhau');</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "oncheck2", soScript);
                //m_lbl_mess.Text = "";
                return;
            }
            form_2_us_obj(m_us_v_gd_thanh_toan);
            m_us_v_gd_thanh_toan.Insert();
            load_data_2_grid(get_ma_dot_tt_by_id_dot(CIPConvert.ToDecimal(m_cbo_dot_thanh_toan.SelectedValue)));
            reset_controls();
            m_lbl_thong_bao.Text = "Thêm bản ghi thành công!";
            hdf_check_click_kiem_tra_so_hd.Value = "";
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cmd_cap_nhat_du_toan_Click(object sender, EventArgs e)
    {
        try
        {
            if (hdf_id_gv.Value == "")
            {
                string someScript;
                someScript = "<script language='javascript'>alert('Bạn phải chọn thanh toán cần Cập nhật');</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "onload", someScript);
                return;
            }
            if (!check_exist_so_hop_dong(m_txt_so_hop_dong.Text.Trim()))
            {
                string Script;
                Script = "<script language='javascript'>alert('Số hợp đồng không tồn tại trong hệ thống');</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "oncheck4", Script);
                return;
            }
            decimal v_dc_id_hop_dong_khung = get_id_hd_khung_by_so_hd(m_txt_so_hop_dong.Text.Trim());
            // Kiểm tra đơn vị thanh toán
            decimal v_dc_id_dv_tt = get_id_don_vi_thanh_toan_by_id_dot_tt(CIPConvert.ToDecimal(m_cbo_dot_thanh_toan.SelectedValue));
            if (!check_hop_dong_ung_voi_dv_thanh_toan(v_dc_id_dv_tt, v_dc_id_hop_dong_khung))
            {
                string Script;
                Script = "<script language='javascript'>alert('Hợp đồng này không do " + get_ten_dv_thanh_toan(v_dc_id_dv_tt) + " thanh toán');</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "oncheck3", Script);
                //m_lbl_mess.Text = "";
                return;
            }

            // Nếu là thanh lý thì yêu cầu nhập nghiệm thu thực tế
            if (rdl_noi_dung_list.Items[0].Selected == true)
            {
                if (m_txt_gia_tri_nghiem_thu_thuc_te.Text.Trim().Equals(""))
                {
                    string soScript;
                    soScript = "<script language='javascript'>alert('Đây là lần thanh lý hợp đồng. Xin hãy nhập tổng giá trị nghiệm thu thực tế');</script>";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "oncheck5", soScript);
                    return;
                }
            }

            if (!check_nghiem_thu_va_thanh_toan_update(v_dc_id_hop_dong_khung))
            {
                string soScript;
                soScript = "<script language='javascript'>alert('Giá trị nghiệm thu thực tế phải bằng tổng tiền thanh toán cộng số tiền đã thanh toán ');</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "oncheck2", soScript);
                return;
            }

            form_2_us_obj(m_us_v_gd_thanh_toan);
           
            // Nếu đây là update thông tin bảng kê, kiểm tra trạng thái mới có phù hợp không?
            if (hdf_id_trang_thai_thanh_toan_cu.Value != "")
            {
                CValidatePaymentStates v_cvalidate_state = new CValidatePaymentStates();
                v_cvalidate_state.Trang_thai_thanh_toan_hien_tai = get_ma_trang_thai_thanh_toan_by_id(CIPConvert.ToDecimal(hdf_id_trang_thai_thanh_toan_cu.Value));
                v_cvalidate_state.set_trang_thai();
                if (!v_cvalidate_state.check_chuyen_trang_thai(get_ma_trang_thai_thanh_toan_by_id(m_us_v_gd_thanh_toan.dcID_TRANG_THAI_THANH_TOAN)))
                {
                    string someScript;
                    someScript = "<script language='javascript'>alert('Không chuyển từ trạng thái ban đầu của thanh toán về trạng thái này được!');</script>";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "onload1", someScript);
                    return;
                }
            }
            m_us_v_gd_thanh_toan.dcID = CIPConvert.ToDecimal(hdf_id_gv.Value);
            m_us_v_gd_thanh_toan.Update();
            m_lbl_thong_bao.Visible = true;
            m_lbl_thong_bao.Text = "Cập nhật bản ghi thành công";
            reset_controls();
            m_cbo_lan_so.Enabled = true;
            m_cmd_luu_du_lieu.Enabled = true;
            m_txt_so_hop_dong.Enabled = true;
            m_cmd_check_so_hd.Visible = true;
            load_data_2_grid(get_ma_dot_tt_by_id_dot(CIPConvert.ToDecimal(m_cbo_dot_thanh_toan.SelectedValue)));
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cmd_xoa_trang_Click(object sender, EventArgs e)
    {
        try
        {
            reset_controls();
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
            when_cbo_dot_tt_changed();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_grv_danh_sach_du_toan_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            m_cmd_luu_du_lieu.Enabled = false;
            m_cmd_cap_nhat_du_toan.Enabled = true;
            load_data_2_us_by_id_and_show_on_form(e.NewSelectedIndex);
            m_cmd_check_so_hd.Visible = false;
            m_cbo_lan_so.Enabled = false;
        }
        catch (Exception V_e)
        {
            CSystemLog_301.ExceptionHandle(this, V_e);
        }
    }
    protected void m_grv_danh_sach_du_toan_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            m_lbl_thong_bao.Text = "";
            delete_row_thanh_toan(e.RowIndex);
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
            string strNamFile = "BangkeThanhToanHDHocLieu" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + ".xls";
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
            load_data_2_grid(get_ma_dot_tt_by_id_dot(CIPConvert.ToDecimal(m_cbo_dot_thanh_toan.SelectedValue)));
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
	#endregion
   
} 