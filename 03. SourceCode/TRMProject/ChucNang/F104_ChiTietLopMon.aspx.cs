using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IP.Core.IPCommon;
using WebDS;
using WebDS.CDBNames;
using WebUS;
public partial class ChucNang_F104_ChiTietLopMon : System.Web.UI.Page
{
    #region Public Interface
    public string get_mapping_so_hop_dong_khung(decimal i_dc_id_hop_dong_khung) {
        try
        {
            US_DM_HOP_DONG_KHUNG v_us_dm_hop_dong_khung = new US_DM_HOP_DONG_KHUNG(i_dc_id_hop_dong_khung);
            if (v_us_dm_hop_dong_khung.IsSO_HOP_DONGNull()) return "";
            return v_us_dm_hop_dong_khung.strSO_HOP_DONG;
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    public string get_mapping_ten_noi_dung_thanh_toan(decimal i_dc_id_noi_dung_thanh_toan)
    {
        try
        {
        US_DM_NOI_DUNG_THANH_TOAN v_us_dm_noi_dung_thanh_toan = new US_DM_NOI_DUNG_THANH_TOAN(i_dc_id_noi_dung_thanh_toan);
        if (v_us_dm_noi_dung_thanh_toan.IsTEN_NOI_DUNGNull()) return "";
        return v_us_dm_noi_dung_thanh_toan.strTEN_NOI_DUNG;
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    public string get_mapping_da_thanh_toan_yn(string i_str_yn)
    {
        try
        {
            return i_str_yn == "Y" ? "Đã thanh toán" : "Chưa thanh toán";
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    #endregion

    #region Data Structures

    #endregion

    #region Members
    US_GD_LOP_MON_DETAIL m_us_gd_lop_mon_detail = new US_GD_LOP_MON_DETAIL();
    DS_GD_LOP_MON_DETAIL m_ds_gd_lop_mon_detail = new DS_GD_LOP_MON_DETAIL();
    DataEntryFormMode m_e_form_mode = DataEntryFormMode.InsertDataState;
    #endregion

    #region Private Methods
    private void load_2_cbo_hop_dong_khung()
    {
        US_DM_HOP_DONG_KHUNG v_us = new US_DM_HOP_DONG_KHUNG();
        DS_DM_HOP_DONG_KHUNG v_ds = new DS_DM_HOP_DONG_KHUNG();
        try
        {
            v_us.FillDataset(v_ds);

            m_cbo_dm_hop_dong_khung.DataSource = v_ds.DM_HOP_DONG_KHUNG;
            m_cbo_dm_hop_dong_khung.DataValueField = DM_HOP_DONG_KHUNG.ID;
            m_cbo_dm_hop_dong_khung.DataTextField = DM_HOP_DONG_KHUNG.SO_HOP_DONG;
            m_cbo_dm_hop_dong_khung.DataBind();
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    private void load_2_cbo_noi_dung_thanh_toan()
    {
        if (m_cbo_dm_hop_dong_khung.SelectedItem == null) return;
        US_DM_NOI_DUNG_THANH_TOAN v_us = new US_DM_NOI_DUNG_THANH_TOAN();
        DS_DM_NOI_DUNG_THANH_TOAN v_ds = new DS_DM_NOI_DUNG_THANH_TOAN();
        try
        {
            v_us.FillDataset(v_ds, "WHERE ID_LOAI_HOP_DONG IN (SELECT ID_LOAI_HOP_DONG FROM DM_HOP_DONG_KHUNG WHERE ID="
                                        +CIPConvert.ToDecimal(m_cbo_dm_hop_dong_khung.SelectedValue)+")");

            m_cbo_noi_dung_thanh_toan.DataSource = v_ds.DM_NOI_DUNG_THANH_TOAN;
            m_cbo_noi_dung_thanh_toan.DataValueField = DM_NOI_DUNG_THANH_TOAN.ID;
            m_cbo_noi_dung_thanh_toan.DataTextField = DM_NOI_DUNG_THANH_TOAN.TEN_NOI_DUNG;
            m_cbo_noi_dung_thanh_toan.DataBind();
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    private string get_ma_lop_mon(decimal i_dc_id_lop_mon) {
        try
        {
            US_GD_LOP_MON v_us = new US_GD_LOP_MON(i_dc_id_lop_mon);
            if (v_us.IsMA_LOP_MONNull()) return "";
            else return v_us.strMA_LOP_MON;
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    private void load_data_2_grid() {
        try
        {
            m_us_gd_lop_mon_detail.FillDataset(m_ds_gd_lop_mon_detail," WHERE ID_LOP_MON="+this.Request.QueryString["id_lop_mon"].ToString());
            m_grv.DataSource = m_ds_gd_lop_mon_detail.GD_LOP_MON_DETAIL;
            
            m_grv.DataBind();
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    private void delete_dm_tu_dien(int i_int_row_index)
    {
        try
        {
            decimal v_dc_id = CIPConvert.ToDecimal(m_grv.DataKeys[i_int_row_index].Value);
            m_us_gd_lop_mon_detail.DeleteByID(v_dc_id);
            load_data_2_grid();
            m_lbl_mess.Text = "Xóa bản ghi thành công.";
        }
        catch (Exception v_e)
        {
            m_lbl_mess.Text = "Lỗi trong quá trình xóa bản ghi.";
            throw v_e;
        }
    }
    private void form_2_us_object() {
        m_us_gd_lop_mon_detail.dcID_HOP_DONG_KHUNG = CIPConvert.ToDecimal(m_cbo_dm_hop_dong_khung.SelectedValue);
        m_us_gd_lop_mon_detail.dcID_NOI_DUNG_THANH_TOAN = CIPConvert.ToDecimal(m_cbo_noi_dung_thanh_toan.SelectedValue);
        m_us_gd_lop_mon_detail.dcID_LOP_MON = CIPConvert.ToDecimal(this.Request.QueryString["id_lop_mon"]);
        m_us_gd_lop_mon_detail.dcSO_LUONG_HE_SO = CIPConvert.ToDecimal(m_txt_so_luong_he_so.Text);
        m_us_gd_lop_mon_detail.dcTHANH_TIEN = CIPConvert.ToDecimal(m_txt_thanh_tien.Text);
        m_us_gd_lop_mon_detail.strDA_THANH_TOAN_YN =m_rbt_trang_thai_thanh_toan.SelectedValue;
        
    }
    private void us_object_2_form() {
        m_cbo_dm_hop_dong_khung.SelectedValue = CIPConvert.ToStr(m_us_gd_lop_mon_detail.dcID_HOP_DONG_KHUNG);
        m_cbo_noi_dung_thanh_toan.SelectedValue = CIPConvert.ToStr( m_us_gd_lop_mon_detail.dcID_NOI_DUNG_THANH_TOAN);
        m_txt_so_luong_he_so.Text = CIPConvert.ToStr(m_us_gd_lop_mon_detail.dcSO_LUONG_HE_SO, "0.0");
        m_txt_thanh_tien.Text = CIPConvert.ToStr(m_us_gd_lop_mon_detail.dcTHANH_TIEN, "#,###");
        m_rbt_trang_thai_thanh_toan.SelectedValue = m_us_gd_lop_mon_detail.strDA_THANH_TOAN_YN;
    }
    #endregion

    //
    //
    // Events
    //
    //
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (m_hdf_id.Value !="") m_e_form_mode = DataEntryFormMode.UpdateDataState;
            else m_e_form_mode = DataEntryFormMode.InsertDataState;
            m_cmd_thoat.Attributes.Add("onclick", "window.close();");
            if (!this.IsPostBack) {
                if (this.Request.QueryString["id_lop_mon"] != null)
                {
                    m_txt_ma_lop_mon.Text = get_ma_lop_mon(CIPConvert.ToDecimal(this.Request.QueryString["id_lop_mon"]));
                    load_2_cbo_hop_dong_khung();
                    load_2_cbo_noi_dung_thanh_toan();
                    load_data_2_grid();
                }
                else {
                    this.Response.Redirect("../Default.aspx");
                }
            }
           
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this,v_e);
        }
    }
    protected void m_cmd_luu_du_lieu_Click(object sender, EventArgs e)
    {
        try
        {
            m_grv.EditIndex = -1;
            m_lbl_mess.Text = "";
            form_2_us_object();
            switch (m_e_form_mode) { 
                case DataEntryFormMode.InsertDataState:
                    m_us_gd_lop_mon_detail.Insert();
                    m_lbl_mess.Text = "Đã thêm mới dữ liệu thành công";
                    break;
                case DataEntryFormMode.UpdateDataState:
                    m_us_gd_lop_mon_detail.dcID = CIPConvert.ToDecimal(m_hdf_id.Value);
                    if (m_us_gd_lop_mon_detail.IsIDNull()) {
                        m_lbl_mess.Text = "Cập nhật không thành công";
                        return;
                    }
                    m_us_gd_lop_mon_detail.Update();
                    m_lbl_mess.Text = "Đã cập nhật dữ liệu thành công";
                    break;
            }
            load_data_2_grid();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cmd_thoat_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Write("<script language='javascript'> { window.close();}</script>");
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_dm_hop_dong_khung_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            m_lbl_mess.Text = "";
            load_2_cbo_noi_dung_thanh_toan();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_grv_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            m_lbl_mess.Text = "";
            delete_dm_tu_dien(e.RowIndex);
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_grv_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            m_lbl_mess.Text = "";
            m_e_form_mode = DataEntryFormMode.UpdateDataState;
            m_hdf_id.Value = CIPConvert.ToStr(this.m_grv.DataKeys[e.NewSelectedIndex].Value);
            m_us_gd_lop_mon_detail = new US_GD_LOP_MON_DETAIL(CIPConvert.ToDecimal(this.m_grv.DataKeys[e.NewSelectedIndex].Value));
            us_object_2_form();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this,v_e);
        }
    }
}