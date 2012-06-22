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

public partial class ChucNang_F611_ChuyenQuaThanhToan : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            load_data_2_cbo_dot_thanh_toan();
            load_data_2_cbo_trang_thai_cv_gv();
            load_data_2_cbo_ten_giang_vien();
            load_data_2_cbo_hop_dong_loc();
            if (m_cbo_dot_thanh_toan.Items.Count > 0)
            {
                m_us_dm_dot_thanh_toan = new US_V_DM_DOT_THANH_TOAN(CIPConvert.ToDecimal(m_cbo_dot_thanh_toan.SelectedValue));
                m_dat_ngay_thanh_toan.SelectedDate = m_us_dm_dot_thanh_toan.datNGAY_TT_DU_KIEN;
                m_lbl_don_vi_thanh_toan.Text = m_us_dm_dot_thanh_toan.strDON_VI_THANH_TOAN;
            }
            load_data_2_grv();
        }
    }

    #region Members
    US_V_GD_GV_CONG_VIEC_MOI m_us_cong_viec_moi = new US_V_GD_GV_CONG_VIEC_MOI();
    DS_V_GD_GV_CONG_VIEC_MOI m_ds_cong_viec_moi = new DS_V_GD_GV_CONG_VIEC_MOI();

    US_V_DM_DOT_THANH_TOAN m_us_dm_dot_thanh_toan = new US_V_DM_DOT_THANH_TOAN();
    #endregion

    #region Private Methods
    private void load_data_2_grv()
    {
        m_us_cong_viec_moi.loc_du_lieu_gv_cong_viec_moi(m_ds_cong_viec_moi, CIPConvert.ToDecimal(m_cbo_so_hop_dong_loc.SelectedValue), CIPConvert.ToDecimal(m_cbo_trang_thai_cv_loc.SelectedValue));
        m_grv_gd_assign_su_kien_cho_giang_vien.DataSource = m_ds_cong_viec_moi.V_GD_GV_CONG_VIEC_MOI;
        m_grv_gd_assign_su_kien_cho_giang_vien.DataBind();
        m_lbl_ds_cv_gv.Text = "Chuyển chứng từ con qua thanh toán: " + m_ds_cong_viec_moi.V_GD_GV_CONG_VIEC_MOI.Rows.Count + " bản ghi";
        if (m_ds_cong_viec_moi.V_GD_GV_CONG_VIEC_MOI.Rows.Count == 0)
            m_cmd_chuyen_qua_thanh_toan.Visible = false;
        else m_cmd_chuyen_qua_thanh_toan.Visible = true;
    }
    // Chỉ load đợt thanh toán đã lập đợt và không load các thanh toán của KHO lên
    private void load_data_2_cbo_dot_thanh_toan()
    {
        DS_V_DM_DOT_THANH_TOAN v_ds_dot_thanh_toan = new DS_V_DM_DOT_THANH_TOAN();
        US_V_DM_DOT_THANH_TOAN v_us_dot_thanh_toan = new US_V_DM_DOT_THANH_TOAN();
        // Vì đợt thanh toán kho có trạng thái là đã lập đợt
        v_us_dot_thanh_toan.load_dot_thanh_toan_by_trang_thai(ID_TRANG_THAI_DOT_TT.DA_LAP_DOT, v_ds_dot_thanh_toan);

        m_cbo_dot_thanh_toan.DataTextField = V_DM_DOT_THANH_TOAN.TEN_DOT_TT;
        m_cbo_dot_thanh_toan.DataValueField = V_DM_DOT_THANH_TOAN.ID;

        m_cbo_dot_thanh_toan.DataSource = v_ds_dot_thanh_toan.V_DM_DOT_THANH_TOAN;
        m_cbo_dot_thanh_toan.DataBind();
    }
    private void load_data_2_cbo_trang_thai_cv_gv()
    {
        US_CM_DM_TU_DIEN v_us_tu_dien = new US_CM_DM_TU_DIEN();
        DS_CM_DM_TU_DIEN v_ds_tu_dien = new DS_CM_DM_TU_DIEN();

        v_us_tu_dien.FillDataset(v_ds_tu_dien, " WHERE ID_LOAI_TU_DIEN = " + (int)e_loai_tu_dien.TRANG_THAI_CONG_VIEC_GV);

        m_cbo_trang_thai_cv_loc.Items.Add(new ListItem("Tất cả", "0"));
        for (int v_i = 0; v_i < v_ds_tu_dien.CM_DM_TU_DIEN.Rows.Count; v_i++)
        {
            m_cbo_trang_thai_cv_loc.Items.Add(new ListItem(CIPConvert.ToStr(v_ds_tu_dien.CM_DM_TU_DIEN.Rows[v_i][CM_DM_TU_DIEN.TEN]), CIPConvert.ToStr(v_ds_tu_dien.CM_DM_TU_DIEN.Rows[v_i][CM_DM_TU_DIEN.ID])));
        }
    }
    private void load_data_2_cbo_ten_giang_vien()
    {
        US_V_DM_GIANG_VIEN v_us_v_dm_giang_vien = new US_V_DM_GIANG_VIEN();
        DS_V_DM_GIANG_VIEN v_ds_v_dm_giang_vien = new DS_V_DM_GIANG_VIEN();

        v_us_v_dm_giang_vien.load_giang_vien_CM_da_thuc_hien_cong_viec(v_ds_v_dm_giang_vien);
        m_cbo_ten_giang_vien_loc.Items.Add(new ListItem("Tất cả", "0"));
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

        m_cbo_so_hop_dong_loc.Items.Add(new ListItem("Tất cả", "0"));
        for (int v_i = 0; v_i < v_ds_v_dm_hop_dong_khung.V_DM_HOP_DONG_KHUNG.Rows.Count; v_i++)
        {
            m_cbo_so_hop_dong_loc.Items.Add(new ListItem(CIPConvert.ToStr(v_ds_v_dm_hop_dong_khung.V_DM_HOP_DONG_KHUNG.Rows[v_i][V_DM_HOP_DONG_KHUNG.SO_HOP_DONG]), CIPConvert.ToStr(v_ds_v_dm_hop_dong_khung.V_DM_HOP_DONG_KHUNG.Rows[v_i][V_DM_HOP_DONG_KHUNG.ID])));
        }
    }
    //private bool check_hop_dong_noi_dung_cong_viec_unique()
    public string get_ma_trang_thai_by_id(decimal ip_dc_id_trang_thai)
    {
        US_CM_DM_TU_DIEN v_us_dm_tu_dien = new US_CM_DM_TU_DIEN(ip_dc_id_trang_thai);
        return v_us_dm_tu_dien.strMA_TU_DIEN;
    }
    #endregion

    #region Public Interfaces
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
    public string get_so_tien_thanh_toan(object ip_obj_so_luong_nghiem_thu, object ip_obj_don_gia)
    {
        string v_str_so_tien_thanh_toan = "";
        if (ip_obj_so_luong_nghiem_thu.GetType() == typeof(DBNull) || ip_obj_don_gia.GetType() == typeof(DBNull))
            v_str_so_tien_thanh_toan = "";
        else v_str_so_tien_thanh_toan = CIPConvert.ToStr(CIPConvert.ToDecimal(ip_obj_don_gia) * CIPConvert.ToDecimal(ip_obj_so_luong_nghiem_thu), "#,###");
        return v_str_so_tien_thanh_toan;
    }
    #endregion

    #region Events
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
    protected void m_grv_gd_assign_su_kien_cho_giang_vien_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            // Kiểm tra trạng thái để xem có chuyển đc không?
            if (!check_trang_thai_chuyen(m_us_cong_viec_moi.dcID_TRANG_THAI, ID_TRANG_THAI_CONG_VIEC_GVCM.DA_DUYET_NGHIEM_THU))
            {
                string sScript;
                sScript = "<script language='javascript'>alert('Công việc này đã được duyệt nghiệm thu hoặc chưa đủ điều kiện để duyệt nghiệm thu...!');</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "onload", sScript);
                return;
            }
            // Nếu được phép thì hiển thị dữ liệu lên form
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
            load_data_2_grv();
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
            load_data_2_grv();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_trang_thai_cv_loc_SelectedIndexChanged(object sender, EventArgs e)
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
    protected void m_cmd_duyet_ke_hoach_Click(object sender, EventArgs e)
    {
        try
        {
            int v_i_count = 0;
            string v_str_id_cac_cong_viec_chuyen = "";
            // Cái này sẽ lấy các HĐ đc chọn
            string v_str_id_cac_hop_dong = "";
            foreach (GridViewRow row in m_grv_gd_assign_su_kien_cho_giang_vien.Rows)
            {
                bool isChecked = ((CheckBox)row.FindControl("chkItem")).Checked;
                if (isChecked)
                {
                    v_i_count += 1;
                    // Lấy id của công việc
                    decimal v_dc_id_cong_viec = CIPConvert.ToDecimal(((CheckBox)row.FindControl("chkItem")).ToolTip);
                    decimal v_dc_id_trang_thai_hien_tai = CIPConvert.ToDecimal(((CheckBox)row.FindControl("chkTrangThai")).ToolTip);
                    if (!check_trang_thai_chuyen(v_dc_id_trang_thai_hien_tai, ID_TRANG_THAI_CONG_VIEC_GVCM.DA_DUYET_NGHIEM_THU))
                        continue;
                    //m_us_cong_viec_moi.dcID = v_dc_id_cong_viec;
                    // thực hiện công việc
                    //m_us_cong_viec_moi.cap_nhat_trang_thai_cong_viec(ID_TRANG_THAI_CONG_VIEC_GVCM.DA_DUYET_NGHIEM_THU);
                    // cho tất cả ID của công việc vào 1 string
                    v_str_id_cac_cong_viec_chuyen += CIPConvert.ToStr(v_dc_id_cong_viec);
                }
            }
            // Neu so items duoc check lớn hơn 0
            if (v_i_count > 0)
            {
                m_us_cong_viec_moi.chuyen_cong_viec_qua_thanh_toan(v_str_id_cac_cong_viec_chuyen,CIPConvert.ToDecimal(m_cbo_dot_thanh_toan.SelectedValue),v_str_id_cac_hop_dong,CIPConvert.ToStr(Session["UserName"]));
                // Load lại dữ liêụ
                load_data_2_grv();
                m_lbl_thong_bao_sau_cap_nhat.Text = "Đã chuyển qua thanh toán thành công!";
            }
            // Nếu ko
            else
            {
                m_lbl_mess.Text = "Bạn chưa chọn công việc nào để chuyển qua thanh toán!";
            }
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
    protected void m_cbo_dot_thanh_toan_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            m_us_dm_dot_thanh_toan = new US_V_DM_DOT_THANH_TOAN(CIPConvert.ToDecimal(m_cbo_dot_thanh_toan.SelectedValue));
            m_dat_ngay_thanh_toan.SelectedDate = m_us_dm_dot_thanh_toan.datNGAY_TT_DU_KIEN;
            m_lbl_don_vi_thanh_toan.Text = m_us_dm_dot_thanh_toan.strDON_VI_THANH_TOAN;
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    #endregion
}