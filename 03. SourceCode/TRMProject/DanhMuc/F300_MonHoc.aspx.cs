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

public partial class DanhMuc_F300_MonHoc : System.Web.UI.Page
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
            load_data_to_grid();
        }
    }

    #region Members
    US_DM_MON_HOC m_us_dm_mon_hoc = new US_DM_MON_HOC();
    DS_DM_MON_HOC m_ds_mon_hoc = new DS_DM_MON_HOC();

    US_CM_DM_TU_DIEN m_us_cm_dm_tu_dien = new US_CM_DM_TU_DIEN();
    DS_CM_DM_TU_DIEN m_ds_cm_dm_tu_dien = new DS_CM_DM_TU_DIEN();
    DataEntryFormMode m_init_mode = DataEntryFormMode.ViewDataState;
    #endregion

    #region Private Methods
    private bool check_validate()
    {
        if (this.m_txt_ma_mon.Text.Trim().Equals(""))
        {
            this.m_ctv_ma_mon.IsValid = false;
            return false;
        }
        if (this.m_txt_ten_mon.Text.Trim().Equals(""))
        {
            this.m_ctv_ten_mon.IsValid = false;
            return false;
        }
        if (this.m_txt_don_vi_hoc_trinh.Text.Trim().Equals(""))
        {
            this.m_ctv_don_vi_hoc_trinh.IsValid = false;
            return false;
        }

        return true;
    }
    private void load_data_to_grid()
    {
        try
        {
            // Đổ dữ liệu từ US vào DS
            m_us_dm_mon_hoc.FillDataset(m_ds_mon_hoc);

            // Treo dữ liệu lên lưới
            m_grv_dm_mon_hoc.DataSource = m_ds_mon_hoc.DM_MON_HOC;
            m_grv_dm_mon_hoc.DataBind();

        }
        catch (Exception v_e)
        {
            //nhớ using Ip.Common
            CSystemLog_301.ExceptionHandle(this, v_e);

        }

    }
    private void reset_control()
    {
        m_txt_ten_mon.Text = "";
        m_txt_ma_mon.Text = "";
        m_txt_don_vi_hoc_trinh.Text = "";
        m_txt_ghi_chu.Text = "";
    }
    private void form_2_us_object(US_DM_MON_HOC ip_us_mon_hoc)
    {
        ip_us_mon_hoc.strTEN_MON_HOC = m_txt_ten_mon.Text;
        ip_us_mon_hoc.strMA_MON_HOC= m_txt_ma_mon.Text;
        ip_us_mon_hoc.strGHI_CHU = m_txt_ghi_chu.Text;
        ip_us_mon_hoc.dcSO_DVHT = CIPConvert.ToDecimal(m_txt_don_vi_hoc_trinh.Text);

    }
    /// <summary>
    /// Load dữ liệu từ US đổ vào form
    /// </summary>
    /// <param name="ip_dm_noi_dung_thanh_toan"></param>
    private void us_obj_2_form(US_DM_MON_HOC ip_us_mon_hoc)
    {
        m_txt_ten_mon.Text = ip_us_mon_hoc.strTEN_MON_HOC;
        m_txt_ma_mon.Text = ip_us_mon_hoc.strMA_MON_HOC;
        m_txt_don_vi_hoc_trinh.Text = CIPConvert.ToStr(ip_us_mon_hoc.dcSO_DVHT);
        m_txt_ghi_chu.Text = ip_us_mon_hoc.strGHI_CHU;
    }
    private void delete_dm_mon_hoc(int ip_i_row_del)
    {
        decimal v_dc_id_mon_hoc = CIPConvert.ToDecimal(m_grv_dm_mon_hoc.DataKeys[ip_i_row_del].Value);
        m_us_dm_mon_hoc.dcID = v_dc_id_mon_hoc;
        m_us_dm_mon_hoc.DeleteByID(v_dc_id_mon_hoc);
        m_lbl_mess.Text = "Xóa bản ghi thành công";
        load_data_to_grid();
    }
    private void load_data_2_us_by_id(int ip_i_id)
    {
        decimal v_dc_id_dm_mon_hoc = CIPConvert.ToDecimal(m_grv_dm_mon_hoc.DataKeys[ip_i_id].Value);
        hdf_id.Value = v_dc_id_dm_mon_hoc.ToString(); 
        US_DM_MON_HOC v_us_dm_mon_hoc = new US_DM_MON_HOC(v_dc_id_dm_mon_hoc);
        hdf_ma_mon.Value = v_us_dm_mon_hoc.strMA_MON_HOC;
        // Đẩy us lên form
        us_obj_2_form(v_us_dm_mon_hoc);
    }
    private void search_mon_hoc(string ip_str_tu_khoa)
    {
        m_us_dm_mon_hoc.search_mon_hoc(ip_str_tu_khoa, m_ds_mon_hoc);
        m_grv_dm_mon_hoc.DataSource = m_ds_mon_hoc.DM_MON_HOC;
        m_grv_dm_mon_hoc.DataBind();
        if (m_ds_mon_hoc.DM_MON_HOC.Rows.Count == 0) m_lbl_thong_bao.Text = "Không có môn nào thỏa mãn!";
    }
    private bool check_ma_mon()
    {
        try
        {
            if (!m_us_dm_mon_hoc.check_exist_ma_mon(m_txt_ma_mon.Text.TrimEnd())) return false;
            return true;
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }

    private bool check_ma_mon_update(string v_str_ma_mon_bd)
    {
        try
        {
            if (!m_us_dm_mon_hoc.check_exist_ma_mon_update(m_txt_ma_mon.Text.TrimEnd(), v_str_ma_mon_bd)) return false;
            return true;
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    #endregion

    //
    // Events
    //

    protected void m_cmd_tao_moi_Click(object sender, EventArgs e)
    {
        try
        {
            if (!check_validate()) return;
            if (!check_ma_mon())
            {
                m_lbl_mess.Text = "Mã môn này đã tồn tại";
                return;
            }
            if (m_init_mode == DataEntryFormMode.UpdateDataState) return;
            form_2_us_object(m_us_dm_mon_hoc);
            m_us_dm_mon_hoc.Insert();
            m_lbl_mess.Text = "Thêm bản ghi thành công";
            reset_control();
            load_data_to_grid();
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
            if (hdf_id.Value == "")
            {
                m_lbl_mess.Text = "Bạn phải chọn nội dung cần Cập nhật";
                return;
            }
            if (!check_validate()) return;
            // hdf_id lưu ID của môn chứ ko phải lưu mã môn
            if (!check_ma_mon_update(hdf_ma_mon.Value))
            {
                string someScript;
                someScript = "<script language='javascript'>alert('Mã môn này đã tồn tại');</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "onload", someScript);
                return;
            }
            form_2_us_object(m_us_dm_mon_hoc);
            m_us_dm_mon_hoc.dcID = CIPConvert.ToDecimal(hdf_id.Value);
            m_us_dm_mon_hoc.Update();
            reset_control();
            m_lbl_mess.Text = "Cập nhật dữ liệu thành công";
            m_grv_dm_mon_hoc.EditIndex = -1;
            m_init_mode = DataEntryFormMode.ViewDataState;
            load_data_to_grid();
        }
        catch (System.Exception v_e)
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
            CSystemLog_301.Equals(this, v_e);
        }
    }

    protected void m_grv_dm_mon_hoc_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            m_lbl_mess.Text = "";
            delete_dm_mon_hoc(e.RowIndex);
        }
        catch (Exception v_e)
        {
            // de su dung CsystemLog_301 bat buoc Site phai dat trong thu muc cap 1. Vi du: DanhMuc/Dictionary.aspx
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_grv_dm_mon_hoc_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            m_init_mode = DataEntryFormMode.UpdateDataState;
            m_cmd_tao_moi.Enabled = false;
            m_lbl_mess.Text = "";
            load_data_2_us_by_id(e.NewSelectedIndex);
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_grv_dm_mon_hoc_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            m_grv_dm_mon_hoc.PageIndex = e.NewPageIndex;
            load_data_to_grid();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this,v_e);
        }
    }
    protected void m_cmd_tim_kiem_Click(object sender, EventArgs e)
    {
        try
        {
            // Thu thập dữ liệu search
            string v_str_tu_khoa_tim_kiem = m_txt_tu_khoa_tim_kiem.Text.Trim();            
            // Search Môn học
            search_mon_hoc(v_str_tu_khoa_tim_kiem);
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
}