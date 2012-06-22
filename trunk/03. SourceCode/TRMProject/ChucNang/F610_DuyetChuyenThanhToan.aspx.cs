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

public partial class ChucNang_F610_DuyetChuyenThanhToan : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        m_lbl_thong_bao_sau_cap_nhat.Text = "";
        if (!IsPostBack)
        {
            load_data_2_cbo_trang_thai_cv_gv();
            load_data_2_cbo_ten_giang_vien();
            load_data_2_cbo_hop_dong_loc();
            load_data_2_grv();
        }
    }

    #region Members
    US_V_GD_GV_CONG_VIEC_MOI m_us_cong_viec_moi = new US_V_GD_GV_CONG_VIEC_MOI();
    DS_V_GD_GV_CONG_VIEC_MOI m_ds_cong_viec_moi = new DS_V_GD_GV_CONG_VIEC_MOI();
    #endregion

    #region Private Methods
    private void load_data_2_grv()
    {
        m_us_cong_viec_moi.loc_du_lieu_gv_cong_viec_moi(m_ds_cong_viec_moi, CIPConvert.ToDecimal(m_cbo_so_hop_dong_loc.SelectedValue), CIPConvert.ToDecimal(m_cbo_trang_thai_cv_loc.SelectedValue));
        m_grv_gd_assign_su_kien_cho_giang_vien.DataSource = m_ds_cong_viec_moi.V_GD_GV_CONG_VIEC_MOI;
        m_grv_gd_assign_su_kien_cho_giang_vien.DataBind();
        m_lbl_ds_cv_gv.Text = "Duyệt chuyển thanh toán: " + m_ds_cong_viec_moi.V_GD_GV_CONG_VIEC_MOI.Rows.Count + " bản ghi";
        if (m_ds_cong_viec_moi.V_GD_GV_CONG_VIEC_MOI.Rows.Count == 0) m_cmd_duyet_ke_hoach.Visible = false;
        else m_cmd_duyet_ke_hoach.Visible = true;
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
    #endregion

    #region Public Interfaces
    public string get_ma_trang_thai_by_id(decimal ip_dc_id_trang_thai)
    {
        US_CM_DM_TU_DIEN v_us_dm_tu_dien = new US_CM_DM_TU_DIEN(ip_dc_id_trang_thai);
        return v_us_dm_tu_dien.strMA_TU_DIEN;
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
            // Nếu được phép thì ...
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
            // Nếu đang ở trạng thái đã duyệt chuyển nghiệm thu thì cho hiển thị chức năng hủy duyệt chuyển thanh toán
            if (m_cbo_trang_thai_cv_loc.SelectedItem.Value.Equals(CIPConvert.ToStr(ID_TRANG_THAI_CONG_VIEC_GVCM.DA_DUYET_CHUYEN_THANH_TOAN)))
            {
                if (m_grv_gd_assign_su_kien_cho_giang_vien.Rows.Count > 0)
                    m_cmd_huy_chuyen_duyet_thanh_toan.Visible = true;
            }
            else m_cmd_huy_chuyen_duyet_thanh_toan.Visible = false;
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
            foreach (GridViewRow row in m_grv_gd_assign_su_kien_cho_giang_vien.Rows)
            {
                bool isChecked = ((CheckBox)row.FindControl("chkItem")).Checked;
                if (isChecked)
                {
                    v_i_count += 1;
                    // Lấy id của công việc
                    decimal v_dc_id_cong_viec = CIPConvert.ToDecimal(((CheckBox)row.FindControl("chkItem")).ToolTip);
                    decimal v_dc_id_trang_thai_hien_tai = CIPConvert.ToDecimal(((CheckBox)row.FindControl("chkTrangThai")).ToolTip);
                    if (!check_trang_thai_chuyen(v_dc_id_trang_thai_hien_tai, ID_TRANG_THAI_CONG_VIEC_GVCM.DA_DUYET_CHUYEN_THANH_TOAN))
                        continue;
                    m_us_cong_viec_moi.dcID = v_dc_id_cong_viec;
                    // Chuyển trạng thái của công việc sang đã duyệt
                    m_us_cong_viec_moi.cap_nhat_trang_thai_cong_viec(ID_TRANG_THAI_CONG_VIEC_GVCM.DA_DUYET_CHUYEN_THANH_TOAN);
                }
            }
            // Neu so items duoc check lớn hơn 0
            if (v_i_count > 0)
            {
                // Load lại dữ liêụ
                load_data_2_grv();
                m_lbl_thong_bao_sau_cap_nhat.Text = "Đã duyệt chuyển thanh toán các công việc thành công!";
            }
            // Nếu ko
            else
            {
                m_lbl_thong_bao_sau_cap_nhat.Text = "Bạn chưa chọn công việc nào để duyệt!";
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
    protected void m_cmd_huy_chuyen_duyet_thanh_toan_Click(object sender, EventArgs e)
    {
        try
        {
            int v_i_count = 0;
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
                    m_us_cong_viec_moi.dcID = v_dc_id_cong_viec;
                    // Chuyển trạng thái của công việc sang đã duyệt
                    m_us_cong_viec_moi.cap_nhat_trang_thai_cong_viec(ID_TRANG_THAI_CONG_VIEC_GVCM.DA_DUYET_NGHIEM_THU);
                }
            }
            // Neu so items duoc check lớn hơn 0
            if (v_i_count > 0)
            {
                // Load lại dữ liêụ
                load_data_2_grv();
                m_lbl_thong_bao_sau_cap_nhat.Text = "Hủy duyệt chuyển thanh toán thành công!"; 
            }
            // Nếu ko
            else
            {
                m_lbl_thong_bao_sau_cap_nhat.Text = "Bạn chưa chọn công việc nào để duyệt!";
            }
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    #endregion
}