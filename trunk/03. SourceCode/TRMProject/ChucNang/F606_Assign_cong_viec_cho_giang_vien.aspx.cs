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
            m_cbo_trang_thai_cv_gv.Enabled = false;
            // Load thông tin về nội dung thanh toán
            if (m_cbo_noi_dung_thanh_toan.Items.Count > 0)
            {
                decimal v_dc_id_noi_dung_tt = CIPConvert.ToDecimal(m_cbo_noi_dung_thanh_toan.SelectedValue);
                US_V_GD_HOP_DONG_NOI_DUNG_TT v_us_dm_noi_dung_tt = new US_V_GD_HOP_DONG_NOI_DUNG_TT(v_dc_id_noi_dung_tt);
                m_txt_so_luong.Text = CIPConvert.ToStr(v_us_dm_noi_dung_tt.dcSO_LUONG_HE_SO, "#,#");
                m_lbl_don_vi.Text = v_us_dm_noi_dung_tt.strDON_VI_TINH;
            }
            else m_lbl_mess.Text = "Hợp đồng này không có phụ lục hợp đồng!";
        }
    }

    #region Members
    US_GD_GV_CONG_VIEC_MOI m_us_cong_viec_moi = new US_GD_GV_CONG_VIEC_MOI();
    DS_GD_GV_CONG_VIEC_MOI m_ds_cong_viec_moi = new DS_GD_GV_CONG_VIEC_MOI();
    #endregion

    #region Private Methods
    private void load_data_2_grv()
    {
        m_us_cong_viec_moi.loc_du_lieu_giang_vien_cong_viec_moi(m_ds_cong_viec_moi, CIPConvert.ToDecimal(m_cbo_so_hop_dong_loc.SelectedValue), CIPConvert.ToDecimal(m_cbo_trang_thai_cv_gv.SelectedValue));
        m_grv_gd_assign_su_kien_cho_giang_vien.DataSource = m_ds_cong_viec_moi.GD_GV_CONG_VIEC_MOI;
        m_grv_gd_assign_su_kien_cho_giang_vien.DataBind();
        m_lbl_ket_qua_loc_du_lieu.Text = "Kết quả lọc dữ liệu: " + m_ds_cong_viec_moi.GD_GV_CONG_VIEC_MOI.Rows.Count + " bản ghi";
    }
    private void load_data_2_cbo_ten_giang_vien()
    {
        US_V_DM_GIANG_VIEN v_us_v_dm_giang_vien = new US_V_DM_GIANG_VIEN();
        DS_V_DM_GIANG_VIEN v_ds_v_dm_giang_vien = new DS_V_DM_GIANG_VIEN();

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

        m_cbo_so_hop_dong_loc.DataTextField = V_DM_HOP_DONG_KHUNG.SO_HOP_DONG;
        m_cbo_so_hop_dong_loc.DataValueField = V_DM_HOP_DONG_KHUNG.ID;

        m_cbo_so_hop_dong_loc.DataSource = v_ds_v_dm_hop_dong_khung.V_DM_HOP_DONG_KHUNG;
        m_cbo_so_hop_dong_loc.DataBind();
    }
    private void load_data_2_us_update(int ip_i_stt_row)
    {
        decimal v_dc_id_cong_viec_gv = CIPConvert.ToDecimal(m_grv_gd_assign_su_kien_cho_giang_vien.DataKeys[ip_i_stt_row].Value);
        m_cbo_so_hop_dong_loc.ToolTip = CIPConvert.ToStr(v_dc_id_cong_viec_gv);
        m_us_cong_viec_moi = new US_GD_GV_CONG_VIEC_MOI(v_dc_id_cong_viec_gv);
    }
    private void us_object_2_form(US_GD_GV_CONG_VIEC_MOI ip_us_v_gd_cv_moi)
    {
        m_cbo_so_hop_dong_loc.SelectedValue = CIPConvert.ToStr(ip_us_v_gd_cv_moi.dcID_HOP_DONG_KHUNG);
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
        m_us_cong_viec_moi.SetDON_GIANull();
        m_us_cong_viec_moi.dcID_TRANG_THAI = CIPConvert.ToDecimal(m_cbo_trang_thai_cv_gv.SelectedValue);
        m_us_cong_viec_moi.strGHI_CHU = m_txt_ghi_chu.Text;
        m_us_cong_viec_moi.dcID_USER_NHAP = get_id_user_by_username(CIPConvert.ToStr(Session["Username"]));

    }
    private void load_data_2_cbo_noi_dung_tt()
    {
        US_V_GD_HOP_DONG_NOI_DUNG_TT v_us_gd_hop_dong_noi_dung_tt = new US_V_GD_HOP_DONG_NOI_DUNG_TT();
        DS_V_GD_HOP_DONG_NOI_DUNG_TT v_ds_gd_hop_dong_noi_dung_tt = new DS_V_GD_HOP_DONG_NOI_DUNG_TT();
        
        // Lấy tất cả các nội dung thanh toán từ phụ lục hợp đồng
        v_us_gd_hop_dong_noi_dung_tt.FillDataset(v_ds_gd_hop_dong_noi_dung_tt, " WHERE ID_HOP_DONG_KHUNG = " + CIPConvert.ToDecimal(m_cbo_so_hop_dong_loc.SelectedValue));
        m_cbo_noi_dung_thanh_toan.DataTextField = V_GD_HOP_DONG_NOI_DUNG_TT.NOI_DUNG_THANH_TOAN;
        m_cbo_noi_dung_thanh_toan.DataValueField = V_GD_HOP_DONG_NOI_DUNG_TT.ID;

        m_cbo_noi_dung_thanh_toan.DataSource = v_ds_gd_hop_dong_noi_dung_tt.V_GD_HOP_DONG_NOI_DUNG_TT;
        m_cbo_noi_dung_thanh_toan.DataBind();
        if (m_cbo_noi_dung_thanh_toan.Items.Count > 0)
        {
            decimal v_dc_id_noi_dung_tt = CIPConvert.ToDecimal(m_cbo_noi_dung_thanh_toan.SelectedValue);
            US_V_GD_HOP_DONG_NOI_DUNG_TT v_us_dm_noi_dung_tt = new US_V_GD_HOP_DONG_NOI_DUNG_TT(v_dc_id_noi_dung_tt);
            m_txt_so_luong.Text = CIPConvert.ToStr(v_us_dm_noi_dung_tt.dcSO_LUONG_HE_SO, "#,#");
            m_lbl_don_vi.Text = v_us_dm_noi_dung_tt.strDON_VI_TINH;
            m_lbl_mess.Text = "";
        }
        else m_lbl_mess.Text = "Hợp đồng này không có phụ lục hợp đồng!";
    }
    private void load_data_2_cbo_trang_thai_cv_gv()
    {
        US_CM_DM_TU_DIEN v_us_tu_dien = new US_CM_DM_TU_DIEN();
        DS_CM_DM_TU_DIEN v_ds_tu_dien = new DS_CM_DM_TU_DIEN();

        v_us_tu_dien.FillDataset(v_ds_tu_dien, " WHERE ID_LOAI_TU_DIEN = " + (int)e_loai_tu_dien.TRANG_THAI_CONG_VIEC_GV);

        m_cbo_trang_thai_cv_gv.DataTextField = CM_DM_TU_DIEN.TEN;
        m_cbo_trang_thai_cv_gv.DataValueField = CM_DM_TU_DIEN.ID;

        m_cbo_trang_thai_cv_gv.DataSource = v_ds_tu_dien.CM_DM_TU_DIEN;
        m_cbo_trang_thai_cv_gv.DataBind();
        m_cbo_trang_thai_cv_gv.SelectedIndex = 0;
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
        m_cbo_trang_thai_cv_gv.SelectedIndex = 0;
    }
    private bool check_hop_dong_noi_dung_cong_viec_unique()
    {
        
        return true; // nghĩa là chưa lập
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
    #endregion

    #region Public Interfaces
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
            form_2_us_object();
            m_us_cong_viec_moi.dcID = CIPConvert.ToDecimal(m_cbo_so_hop_dong_loc.ToolTip);
            m_us_cong_viec_moi.Update();
            load_data_2_grv();
            clear_form();

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
    protected void m_cmd_tao_moi_Click(object sender, EventArgs e)
    {
        try
        {
            // Nếu nội dung CV này ứng với HĐ này đã tồn tại
            if (!check_hop_dong_noi_dung_cong_viec_unique())
            {
                m_lbl_thong_bao_so_hd.Text = "  Công việc này đã được lên cho hợp đồng GVCM!";
                return;
            }
            form_2_us_object();
            m_us_cong_viec_moi.Insert();
            m_lbl_thong_bao_sau_cap_nhat.Text = " * Thêm thành công một bản ghi !";
            m_cmd_huy.ToolTip = "";
            m_hdf_check_hd.Value = "";
            load_data_2_grv();
            clear_form();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cmd_loc_du_lieu_Click(object sender, EventArgs e)
    {
        search_gv_cong_viec_moi_and_load_2_grv();
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
            decimal v_dc_id_noi_dung_tt = CIPConvert.ToDecimal(m_cbo_noi_dung_thanh_toan.SelectedValue);
            US_V_GD_HOP_DONG_NOI_DUNG_TT v_us_dm_noi_dung_tt = new US_V_GD_HOP_DONG_NOI_DUNG_TT(v_dc_id_noi_dung_tt);
            m_txt_so_luong.Text = CIPConvert.ToStr(v_us_dm_noi_dung_tt.dcSO_LUONG_HE_SO, "#,#");
            m_lbl_don_vi.Text = v_us_dm_noi_dung_tt.strDON_VI_TINH;
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
            load_data_2_cbo_noi_dung_tt();
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
    #endregion
}