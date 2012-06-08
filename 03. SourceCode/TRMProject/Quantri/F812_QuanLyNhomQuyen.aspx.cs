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

public partial class Quantri_F812_QuanLyNhomQuyen : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            load_data_2_grid();
        }
    }

    #region Members
    US_HT_USER_GROUP m_us_ht_user_group= new US_HT_USER_GROUP();
    DS_HT_USER_GROUP m_ds_ht_user_group = new DS_HT_USER_GROUP();
    #endregion

    #region Private Methods
    private void load_data_2_grid()
    {
        m_us_ht_user_group.FillDataset(m_ds_ht_user_group, " ORDER BY ID");
        m_grv_dm_nhom_quyen_he_thong.DataSource = m_ds_ht_user_group.HT_USER_GROUP;
        m_grv_dm_nhom_quyen_he_thong.DataBind();
    }
    private void load_data_2_us_by_id(int ip_i_row_index)
    {
        decimal v_dc_chuc_nang_id = CIPConvert.ToDecimal(m_grv_dm_nhom_quyen_he_thong.DataKeys[ip_i_row_index].Value);
        hdf_id.Value = CIPConvert.ToStr(v_dc_chuc_nang_id);
        m_us_ht_user_group = new US_HT_USER_GROUP(v_dc_chuc_nang_id);
        m_txt_ten_nhom_quyen.Text = m_us_ht_user_group.strUSER_GROUP_NAME;
        m_txt_mo_ta.Text = m_us_ht_user_group.strDESCRIPTION;
    }
    private void delete_dm_nhom_quyen(int ip_i_row_index)
    {
        decimal v_dc_nhom_quyen_id = CIPConvert.ToDecimal(m_grv_dm_nhom_quyen_he_thong.DataKeys[ip_i_row_index].Value);
        m_us_ht_user_group.DeleteByID(v_dc_nhom_quyen_id);
    }
    private void reset_control()
    {
        m_txt_mo_ta.Text = "";
        m_txt_ten_nhom_quyen.Text = "";
    }
    private void form_2_us_obj()
    {
        m_us_ht_user_group.strUSER_GROUP_NAME = m_txt_ten_nhom_quyen.Text.Trim();
        m_us_ht_user_group.strDESCRIPTION = m_txt_mo_ta.Text.Trim();
    }
    private void us_obj_2_form()
    {

    }
    #endregion

    #region Public Interfaces
    public string mapping_yn(object ip_obj_str_yn)
    {
        if (CIPConvert.ToStr(ip_obj_str_yn).Equals("Y")) return "Có";
        return "Không";
    }

    public string mapping_chuc_nang_parrent_by_id(object ip_dc_chuc_nang_parrent_id)
    {

        return "";
    }
    #endregion

    #region Events
    protected void m_cmd_tao_moi_Click(object sender, EventArgs e)
    {
        try
        {
            // thu thập dữ liệu
            form_2_us_obj();
            // Insert
            m_us_ht_user_group.Insert();
            // hiển thị lại lên lưới
            load_data_2_grid();
            // Reset lại control
            reset_control();
            // thong báo
            m_lbl_mess.Text = "Thêm bản ghi thành công!";
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cmd_cap_nhat_Click1(object sender, EventArgs e)
    {
        try
        {
            // thu thập dữ liệu
            form_2_us_obj();
            m_us_ht_user_group.dcID = CIPConvert.ToDecimal(hdf_id.Value);
            // Update
            m_us_ht_user_group.Update();
            // hiển thị lại lên lưới
            load_data_2_grid();
            // Reset lại control
            reset_control();
            m_lbl_mess.Text = "Cập nhật bản ghi thành công!";
            m_cmd_tao_moi.Enabled = true;
            m_cmd_cap_nhat.Enabled = false;
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_grv_dm_nhom_quyen_he_thong_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            // Xóa nhóm quyền kèm theo xóa các phần phân quyền cho nhóm quyền đó
            delete_dm_nhom_quyen(e.RowIndex);
            m_lbl_mess.Text = "Xóa bản ghi thành công!";
        }
        catch (Exception v_e)
        {
            // de su dung CsystemLog_301 bat buoc Site phai dat trong thu muc cap 1. Vi du: DanhMuc/Dictionary.aspx
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_grv_dm_nhom_quyen_he_thong_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            m_grv_dm_nhom_quyen_he_thong.PageIndex = e.NewPageIndex;
            load_data_2_grid();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_grv_dm_nhom_quyen_he_thong_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            m_cmd_tao_moi.Enabled = false;
            m_cmd_cap_nhat.Enabled = true;
            m_lbl_mess.Text = "";
            load_data_2_us_by_id(e.NewSelectedIndex);
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    #endregion
   
}