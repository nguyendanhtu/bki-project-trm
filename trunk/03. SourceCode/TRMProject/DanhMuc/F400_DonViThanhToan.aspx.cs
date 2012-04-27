using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDS;
using WebUS;
using IP.Core.IPCommon;

public partial class DanhMuc_DonViThanhToan : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        m_lbl_mess.Text = "";
        if (m_init_mode == DataEntryFormMode.UpdateDataState)
        {
            m_cmd_tao_moi.Enabled = false;
        }
        else
        {
            m_cmd_tao_moi.Enabled = true;
        }
        if (!IsPostBack)
        {
            try
            {
                load_data_to_grid();
            }
            catch (Exception v_e)
            {
                
                CSystemLog_301.ExceptionHandle(this, v_e);
            }
        }

    }
    #region Enums
    #endregion
    #region Members
   
    US_DM_DON_VI_THANH_TOAN m_us_dm_don_vi_thanh_toan = new US_DM_DON_VI_THANH_TOAN();
    DS_DM_DON_VI_THANH_TOAN m_ds_dm_don_vi_thanh_toan = new DS_DM_DON_VI_THANH_TOAN();

    DataEntryFormMode m_init_mode = DataEntryFormMode.ViewDataState;
    #endregion
    #region Methods
    private bool check_validate()
    {
        if (this.m_txt_ma_don_vi.Text.Trim().Equals(""))
        {
            this.m_ctv_ma_don_vi.IsValid= false;
            return false;
        }
        if (this.m_txt_ten_don_vi.Text.Trim().Equals(""))
        {
            this.m_ctv_ten_don_vi.IsValid = false;
            return false;
        }

        return true;
    }
    private void load_data_to_grid()
    {
        m_us_dm_don_vi_thanh_toan.FillDataset(m_ds_dm_don_vi_thanh_toan);
        m_grv_dm_don_vi_thanh_toan.DataSource = m_ds_dm_don_vi_thanh_toan;
        m_grv_dm_don_vi_thanh_toan.DataBind();
        
    }
    private void form_to_us_object()
    {
        m_us_dm_don_vi_thanh_toan.strMA_DON_VI = m_txt_ma_don_vi.Text;
        m_us_dm_don_vi_thanh_toan.strTEN_DON_VI = m_txt_ten_don_vi.Text;
        m_us_dm_don_vi_thanh_toan.strMA_SO_THUE = m_txt_ma_so_thue.Text;
        m_us_dm_don_vi_thanh_toan.strSO_DIEN_THOAI = m_txt_so_dien_thoai.Text;
        m_us_dm_don_vi_thanh_toan.strSO_TAI_KHOAN = m_txt_so_tai_khoan.Text;
        m_us_dm_don_vi_thanh_toan.strDIA_CHI = m_txt_dia_chi.Text;
        m_us_dm_don_vi_thanh_toan.strCAP_TAI = m_txt_cap_tai.Text;

    }
    private void us_object_to_form(US_DM_DON_VI_THANH_TOAN ip_us_dm_don_vi_thanh_toan)
    {
        m_txt_ma_don_vi.Text =CIPConvert.ToStr(ip_us_dm_don_vi_thanh_toan.strMA_DON_VI);
        m_txt_ma_so_thue.Text =CIPConvert.ToStr( ip_us_dm_don_vi_thanh_toan.strMA_SO_THUE);
        m_txt_so_dien_thoai.Text = CIPConvert.ToStr(ip_us_dm_don_vi_thanh_toan.strSO_DIEN_THOAI);
        m_txt_so_tai_khoan.Text = CIPConvert.ToStr(ip_us_dm_don_vi_thanh_toan.strSO_TAI_KHOAN);
        m_txt_ten_don_vi.Text = CIPConvert.ToStr(ip_us_dm_don_vi_thanh_toan.strTEN_DON_VI);
        m_txt_dia_chi.Text = CIPConvert.ToStr(ip_us_dm_don_vi_thanh_toan.strDIA_CHI);
        m_txt_cap_tai.Text = CIPConvert.ToStr(ip_us_dm_don_vi_thanh_toan.strCAP_TAI);
    }
    private void reset_control()
    {
        m_txt_ma_don_vi.Text = "";
        m_txt_ma_so_thue.Text = "";
        m_txt_so_dien_thoai.Text = "";
        m_txt_so_tai_khoan.Text = "";
        m_txt_ten_don_vi.Text = "";
        m_txt_dia_chi.Text = "";
        m_txt_cap_tai.Text = "";
    }
    private bool check_ma_don_vi()
    {
        try
        {
            if (!m_us_dm_don_vi_thanh_toan.check_exist_ma_don_vi(m_txt_ma_don_vi.Text.TrimEnd())) return false;
            return true;
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    private void update_don_vi_thanh_toan()
    {
        try
        {
             m_grv_dm_don_vi_thanh_toan.EditIndex=-1;
            if (Page.IsValid)
            {
                if (!check_validate()) return;
                if (m_hdf_id_dm_don_vi_thanh_toan.Value == "") { m_lbl_mess.Text = "Bạn phải chọn đơn vị cần Cập nhật."; return; }
                form_to_us_object();
                m_us_dm_don_vi_thanh_toan.dcID = CIPConvert.ToDecimal(m_hdf_id_dm_don_vi_thanh_toan.Value);
                m_us_dm_don_vi_thanh_toan.Update();
                m_lbl_mess.Text = "Đã cập nhật bản ghi thành công.";
                reset_control();
                m_init_mode = DataEntryFormMode.ViewDataState;
                m_grv_dm_don_vi_thanh_toan.EditIndex = -1;
                load_data_to_grid();
            }
        }
        catch (Exception v_e)
        {
            m_lbl_mess.Text = "Lỗi trong quá trình cập nhật bản ghi.";
            throw v_e;
        }
    }
    private void delete_don_vi_thanh_toan(int i_int_row_index)
    {
        try
        {
            decimal v_dc_id_don_vi_thanh_toan = CIPConvert.ToDecimal(m_grv_dm_don_vi_thanh_toan.DataKeys[i_int_row_index].Value);
            m_us_dm_don_vi_thanh_toan.DeleteByID(v_dc_id_don_vi_thanh_toan);
            load_data_to_grid();
            m_lbl_mess.Text = "Xóa bản ghi thành công.";
            reset_control();
        }
        catch (Exception v_e)
        {
            m_lbl_mess.Text = "Lỗi trong quá trình xóa bản ghi.";
            throw v_e;
        }
    }
    private void insert_don_vi_thanh_toan()
    {
        try
        {
            m_grv_dm_don_vi_thanh_toan.EditIndex = -1;
            if (Page.IsValid)
            {
                if (!check_validate()) return;
                form_to_us_object();
                m_us_dm_don_vi_thanh_toan.Insert();
                m_lbl_mess.Text = "Đã thêm mới thành công.";
                reset_control();
                load_data_to_grid();
            }
        }
        catch (Exception v_e)
        {
            m_lbl_mess.Text = "Lỗi trong quá trình thêm mới bản ghi.";
            throw v_e;
        }
    }
    private void load_update_don_vi_thanh_toan(int i_int_row_index)
    {
        try
        {
            decimal v_dc_id_don_vi_thanh_toan = CIPConvert.ToDecimal(m_grv_dm_don_vi_thanh_toan.DataKeys[i_int_row_index].Value);
            US_DM_DON_VI_THANH_TOAN v_us_dm_don_vi_thanh_toan = new US_DM_DON_VI_THANH_TOAN(v_dc_id_don_vi_thanh_toan);
            m_hdf_id_dm_don_vi_thanh_toan.Value = CIPConvert.ToStr(v_dc_id_don_vi_thanh_toan);
            us_object_to_form(v_us_dm_don_vi_thanh_toan);
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    #endregion

    #region Data Structures
    #endregion

    #region Events
    protected void m_cmd_tao_moi_Click(object sender, EventArgs e)
    {
        try
        {
            m_lbl_mess.Text = "";
            if (m_init_mode == DataEntryFormMode.UpdateDataState) return;
            insert_don_vi_thanh_toan();
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
            m_lbl_mess.Text = "";
            update_don_vi_thanh_toan();
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
            reset_control();

        }
        catch (Exception v_e)
        {

            CSystemLog_301.ExceptionHandle(this, v_e);
        }

    }

    protected void m_grv_dm_don_vi_thanh_toan_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            m_lbl_mess.Text = "";
            m_cmd_tao_moi.Enabled = false;
            m_init_mode = DataEntryFormMode.UpdateDataState;
            load_update_don_vi_thanh_toan(e.NewSelectedIndex);
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_grv_dm_don_vi_thanh_toan_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            m_lbl_mess.Text = "";
            delete_don_vi_thanh_toan(e.RowIndex);
        }
        catch (Exception v_e)
        {
            // de su dung CsystemLog_301 bat buoc Site phai dat trong thu muc cap 1. Vi du: DanhMuc/Dictionary.aspx
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    #endregion

}