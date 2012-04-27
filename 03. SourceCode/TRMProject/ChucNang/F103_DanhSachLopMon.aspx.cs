using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IP.Core.IPCommon;
using WebDS;
using WebDS.CDBNames;
using WebUS;
using System.Data;
using System.Web.UI.HtmlControls;
public partial class ChuNang_F103_DanhSachLopMon : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            
            if (!this.IsPostBack) {
                  load_2_cbo_dm_mon_hoc();
            }
        }
        catch(Exception v_e) {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    #region Data Structures
    #endregion

    #region Members
    DS_GD_LOP_MON m_ds_gd_lop_mon = new DS_GD_LOP_MON();
    US_GD_LOP_MON m_us_gd_lop_mon = new US_GD_LOP_MON();
    #endregion

    #region Private Methods
    private void load_2_cbo_dm_mon_hoc()
    {
        US_DM_MON_HOC v_us_dm_mon_hoc = new US_DM_MON_HOC();
        DS_DM_MON_HOC v_ds_dm_mon_hoc = new DS_DM_MON_HOC();
        try
        {
            v_us_dm_mon_hoc.FillDataset(v_ds_dm_mon_hoc, " ORDER BY TEN_MON_HOC");

            //add item Tat Ca
            DataRow v_dr_all = v_ds_dm_mon_hoc.DM_MON_HOC.NewDM_MON_HOCRow();
            v_dr_all[DM_MON_HOC.ID] = 0;
            v_dr_all[DM_MON_HOC.TEN_MON_HOC] = "Tất cả";
            v_ds_dm_mon_hoc.EnforceConstraints = false;
            v_ds_dm_mon_hoc.DM_MON_HOC.Rows.InsertAt(v_dr_all, 0);

            m_cbo_dm_mon_hoc.DataSource = v_ds_dm_mon_hoc.DM_MON_HOC;
            m_cbo_dm_mon_hoc.DataValueField = DM_MON_HOC.ID;
            m_cbo_dm_mon_hoc.DataTextField = DM_MON_HOC.TEN_MON_HOC;
            m_cbo_dm_mon_hoc.DataBind();
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    public string get_mapping_ten_mon_hoc(decimal i_dc_id_mon_hoc) {
        try {
            string v_str_ten_mon_hoc = "";
            US_DM_MON_HOC v_us_dm_mon_hoc = new US_DM_MON_HOC(i_dc_id_mon_hoc);
            v_str_ten_mon_hoc = v_us_dm_mon_hoc.strTEN_MON_HOC;
            return v_str_ten_mon_hoc;
        }
        catch (Exception v_e) {
            throw v_e;
        }

    }
    public string get_mapping_yn(string i_str_yn)
    {
        try
        {
            if (i_str_yn == "Y")
                return "Có";
            else return "Không";
        }
        catch (Exception v_e)
        {
            throw v_e;
        }

    }
    private void load_data_2_grid() {
        m_ds_gd_lop_mon = new DS_GD_LOP_MON();
        try
        {
            #region Get value YN Field
            string v_str_online_yn = "";
            string v_str_offline_yn = "";
            string v_str_bt_gky_yn = "";
            if (m_rbt_online_yn.SelectedValue =="Y") {
                v_str_online_yn = "Y";
            }else if (m_rbt_online_yn.SelectedValue == "N") v_str_online_yn = "N";
            else if (m_rbt_online_yn.SelectedValue == "ALL") v_str_online_yn = "ALL";
            //
            if (m_rbt_offline_yn.SelectedValue == "Y")
            {
                v_str_offline_yn = "Y";
            }else if (m_rbt_offline_yn.SelectedValue == "N") v_str_offline_yn = "N";
            else if (m_rbt_offline_yn.SelectedValue == "ALL") v_str_offline_yn = "ALL";
            //
            if (m_rbt_bt_gky_yn.SelectedValue == "Y")
            {
                v_str_bt_gky_yn = "Y";
            }
            else if (m_rbt_bt_gky_yn.SelectedValue == "N") v_str_bt_gky_yn = "N";
            else if (m_rbt_bt_gky_yn.SelectedValue == "ALL") v_str_bt_gky_yn = "ALL";
            #endregion
            string v_str_ngay_bat_dau_tu = "01/01/1900", v_str_ngay_bat_dau_den = "01/01/1900", v_str_ngay_ket_thuc_tu = "01/01/1900",
                v_str_ngay_ket_thuc_den ="01/01/1900",v_str_ngay_thi_tu ="01/01/1900",v_str_ngay_thi_den="01/01/1900";
            if(m_dat_ngay_bat_dau_tu.SelectedDate!=CIPConvert.ToDatetime("01/01/0001","dd/MM/yyyy")) v_str_ngay_bat_dau_tu =CIPConvert.ToStr(m_dat_ngay_bat_dau_tu.SelectedDate,"dd/MM/yyyy");
            if (m_dat_ngay_bat_dau_den.SelectedDate != CIPConvert.ToDatetime("01/01/0001", "dd/MM/yyyy")) v_str_ngay_bat_dau_den = CIPConvert.ToStr(m_dat_ngay_bat_dau_den.SelectedDate, "dd/MM/yyyy");
            if (m_dat_ngay_ket_thuc_tu.SelectedDate != CIPConvert.ToDatetime("01/01/0001", "dd/MM/yyyy")) v_str_ngay_ket_thuc_tu = CIPConvert.ToStr(m_dat_ngay_ket_thuc_tu.SelectedDate, "dd/MM/yyyy");
            if (m_dat_ngay_ket_thuc_den.SelectedDate != CIPConvert.ToDatetime("01/01/0001", "dd/MM/yyyy")) v_str_ngay_ket_thuc_den = CIPConvert.ToStr(m_dat_ngay_ket_thuc_den.SelectedDate, "dd/MM/yyyy");
            if (m_dat_ngay_thi_tu.SelectedDate != CIPConvert.ToDatetime("01/01/0001", "dd/MM/yyyy")) v_str_ngay_thi_tu = CIPConvert.ToStr(m_dat_ngay_thi_tu.SelectedDate, "dd/MM/yyyy");
            if (m_dat_ngay_thi_den.SelectedDate != CIPConvert.ToDatetime("01/01/0001", "dd/MM/yyyy")) v_str_ngay_thi_den = CIPConvert.ToStr(m_dat_ngay_thi_den.SelectedDate, "dd/MM/yyyy");

           
            m_us_gd_lop_mon.fill_data_by_search(CIPConvert.ToDecimal(m_cbo_dm_mon_hoc.SelectedValue)
                            ,v_str_online_yn
                            ,v_str_offline_yn
                            ,v_str_bt_gky_yn
                            , m_txt_tu_khoa_tim_kiem.Text
                            , v_str_ngay_bat_dau_tu
                            ,v_str_ngay_bat_dau_den
                            ,v_str_ngay_ket_thuc_tu
                            , v_str_ngay_ket_thuc_den
                            , v_str_ngay_thi_tu
                            , v_str_ngay_thi_den
                            , m_ds_gd_lop_mon);
            m_grv.DataSource = m_ds_gd_lop_mon.GD_LOP_MON;
            m_grv.DataBind();
            m_lbl_ket_qua_loc.Text = "Kết quả lọc dữ liệu: " + m_ds_gd_lop_mon.GD_LOP_MON.Rows.Count+" bản ghi";
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    private void delete_row(int i_int_row_index)
    {
        try
        {
            decimal v_dc_id= CIPConvert.ToDecimal(m_grv.DataKeys[i_int_row_index].Value);
            m_us_gd_lop_mon.DeleteByID(v_dc_id);
            m_lbl_mess.Text = "Xóa bản ghi thành công.";
            load_data_2_grid();  
        }
        catch (Exception v_e)
        {
            m_lbl_mess.Text = "Lỗi trong quá trình xóa bản ghi.";
            throw v_e;
        }
    }
    private void save_excel(string i_str_file_name){
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition",
         "attachment;filename=GridViewExport.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        // Bỏ phân trang - Nếu chỉ muỗn Export Trang hiện hành thì chọn =true
        m_grv.AllowPaging = false;
        m_grv.DataBind();
        m_grv.RenderControl(hw);
        //Thay đổi Style
        string style = @"";
        Response.Write(style);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }
    #endregion
    //
    //
    // Event Hanlder
    //
    //


    protected void m_cmd_loc_du_lieu_Click(object sender, EventArgs e)
    {
        
        try
        {
            load_data_2_grid();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_grv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            //HyperLink v_lnk = (HyperLink)e.Row.FindControl("m_lnk_sua");
            //v_lnk.Attributes.Add("OnClick", "JavaScript:OpenWinCenter2(350, 800, '', '~/ChucNang/F102_CapNhatThongTinLopMon.aspx?id=");
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }

    protected void m_cmd_tao_moi(object sender, EventArgs e)
    {
        try
        {

            this.ClientScript.RegisterStartupScript(this.Page.GetType(), "ThemMoiLopMon", "OpenSiteFromUrl('F102_CapNhatThongTinLopMon.aspx?mode=insert&id_lop_mon=0');", true);
            
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_grv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            m_grv.PageIndex = e.NewPageIndex;
            load_data_2_grid();
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
            delete_row(e.RowIndex);
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
            save_excel("contact");
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }

    }
}