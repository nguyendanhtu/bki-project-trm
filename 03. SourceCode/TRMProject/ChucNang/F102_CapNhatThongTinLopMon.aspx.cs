using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDS;
using WebUS;
using WebDS.CDBNames;
using IP.Core.IPCommon;
public partial class ChucNang_F102_CapNhatThongTinLopMon : System.Web.UI.Page
{
    #region Public Interface

    #endregion

    #region Data Structure
    DataEntryFormMode m_e_form_mode;
    #endregion

    #region Members
    US_GD_LOP_MON m_us_gd_lop_mon = new US_GD_LOP_MON();
    DS_GD_LOP_MON m_ds_gd_lop_mon = new DS_GD_LOP_MON();
    decimal m_dc_id_lop_mon = 0;
    #endregion

    #region Private Methods
    private void load_2_cbo_mon_hoc(){
        US_DM_MON_HOC v_us_dm_mon_hoc = new US_DM_MON_HOC();
        DS_DM_MON_HOC v_ds_dm_mon_hoc = new DS_DM_MON_HOC();
        try
        {
            v_us_dm_mon_hoc.FillDataset(v_ds_dm_mon_hoc, " ORDER BY TEN_MON_HOC");
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
    private void form_2_us_object(){
        m_us_gd_lop_mon.dcID = CIPConvert.ToDecimal(this.Request.QueryString["id_lop_mon"].ToString());
        m_us_gd_lop_mon.strMA_LOP_MON = m_txt_ma_lop_mon.Text;
        m_us_gd_lop_mon.dcID_MON_HOC = CIPConvert.ToDecimal(m_cbo_dm_mon_hoc.SelectedValue);
        if(m_txt_slhv.Text!="") m_us_gd_lop_mon.dcSO_LUONG_HV = CIPConvert.ToDecimal(m_txt_slhv.Text);
        if (m_txt_slhv_online.Text != "") m_us_gd_lop_mon.dcSO_LUONG_ONLINES = CIPConvert.ToDecimal(m_txt_slhv_online.Text);
        if (m_txt_slhv_offline.Text != "") m_us_gd_lop_mon.dcSO_LUONG_OFFLINE = CIPConvert.ToDecimal(m_txt_slhv_offline.Text);
        m_us_gd_lop_mon.strPO_PHU_TRACH = m_txt_po_phu_trach.Text;
        m_us_gd_lop_mon.strCHUONG_TRINH_PHU_TRACH =m_txt_chuong_trinh_phu_trach.Text;
        if (m_dat_ngay_bat_dau.SelectedDate != CIPConvert.ToDatetime("01/01/0001")) m_us_gd_lop_mon.datNGAY_BAT_DAU = m_dat_ngay_bat_dau.SelectedDate;
        if (m_dat_ngay_ket_thuc.SelectedDate != CIPConvert.ToDatetime("01/01/0001")) m_us_gd_lop_mon.datNGAY_KET_THUC = m_dat_ngay_ket_thuc.SelectedDate;
        if (m_dat_ngay_thi.SelectedDate != CIPConvert.ToDatetime("01/01/0001")) m_us_gd_lop_mon.datNGAY_THI = m_dat_ngay_thi.SelectedDate;
        if(m_rbt_online_yn.SelectedValue =="Y")
            m_us_gd_lop_mon.strONLINES_YN = "Y";
        else
            m_us_gd_lop_mon.strONLINES_YN = "N";
        if(m_rbt_offline_yn.SelectedValue=="Y")
            m_us_gd_lop_mon.strOFFLINE_YN ="Y";
        else m_us_gd_lop_mon.strOFFLINE_YN ="N";
        if(m_rbt_bt_gky_yn.SelectedValue =="Y")
            m_us_gd_lop_mon.strBAI_TAP_GKY_YN = "Y";
        else m_us_gd_lop_mon.strBAI_TAP_GKY_YN = "N";
    }
    private void us_object_2_form(){
        m_txt_ma_lop_mon.Text = m_us_gd_lop_mon.strMA_LOP_MON;
        m_cbo_dm_mon_hoc.SelectedValue = CIPConvert.ToStr(m_us_gd_lop_mon.dcID_MON_HOC);
        m_txt_po_phu_trach.Text = m_us_gd_lop_mon.strPO_PHU_TRACH;
        m_txt_chuong_trinh_phu_trach.Text = m_us_gd_lop_mon.strCHUONG_TRINH_PHU_TRACH;
        m_txt_slhv.Text = CIPConvert.ToStr(m_us_gd_lop_mon.dcSO_LUONG_HV,"#,###0");
        m_txt_slhv_online.Text = CIPConvert.ToStr(m_us_gd_lop_mon.dcSO_LUONG_ONLINES,"#,###0");
        m_txt_slhv_offline.Text = CIPConvert.ToStr(m_us_gd_lop_mon.dcSO_LUONG_OFFLINE,"#,###0");
        m_rbt_online_yn.SelectedValue = m_us_gd_lop_mon.strONLINES_YN;
        m_rbt_offline_yn.SelectedValue = m_us_gd_lop_mon.strOFFLINE_YN;
        m_rbt_bt_gky_yn.SelectedValue = m_us_gd_lop_mon.strBAI_TAP_GKY_YN;
        if(!m_us_gd_lop_mon.IsNGAY_THINull()) m_dat_ngay_thi.SelectedDate = CIPConvert.ToDatetime(CIPConvert.ToStr(m_us_gd_lop_mon.datNGAY_THI,"dd/MM/yyyy"),"dd/MM/yyyy");
        if (!m_us_gd_lop_mon.IsNGAY_BAT_DAUNull()) m_dat_ngay_bat_dau.SelectedDate = CIPConvert.ToDatetime(CIPConvert.ToStr(m_us_gd_lop_mon.datNGAY_BAT_DAU, "dd/MM/yyyy"), "dd/MM/yyyy");
        if (!m_us_gd_lop_mon.IsNGAY_KET_THUCNull()) m_dat_ngay_ket_thuc.SelectedDate = CIPConvert.ToDatetime(CIPConvert.ToStr(m_us_gd_lop_mon.datNGAY_KET_THUC, "dd/MM/yyyy"), "dd/MM/yyyy");
    }
    private void load_form_update() {
        try
        {
            m_us_gd_lop_mon = new US_GD_LOP_MON(m_dc_id_lop_mon);
            us_object_2_form();
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    private bool trung_ma_lop_mon(){
       try{
           US_GD_LOP_MON v_us_dm_lop_mon = new US_GD_LOP_MON();
           return v_us_dm_lop_mon.check_trung_ma_lop_mon(m_txt_ma_lop_mon.Text) ;
        }catch(Exception v_e){
            throw v_e;
        }
    }
    #endregion
    //
    //
    // Event
    //
    //
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            m_cmd_thoat.Attributes.Add("onclick", "window.close();");
            
            if (this.Request.QueryString["mode"] != null && this.Request.QueryString["id_lop_mon"] != null)
            {
                if (this.Request.QueryString["mode"] == "update")
                    m_e_form_mode = DataEntryFormMode.UpdateDataState;
                else if (this.Request.QueryString["mode"] == "insert") m_e_form_mode = DataEntryFormMode.InsertDataState;
                else if (this.Request.QueryString["mode"] == "view") m_e_form_mode = DataEntryFormMode.ViewDataState;
                else return;
                m_dc_id_lop_mon = CIPConvert.ToDecimal(this.Request.QueryString["id_lop_mon"].ToString());}
            if (!this.IsPostBack)
            {

                    load_2_cbo_mon_hoc();
                    switch (m_e_form_mode)
                    {

                        case DataEntryFormMode.UpdateDataState:
                            load_form_update();
                            break;
                        case DataEntryFormMode.InsertDataState:

                            break;
                        case DataEntryFormMode.ViewDataState:

                            break;
                    }

             }
        }catch(Exception v_e){
            CSystemLog_301.ExceptionHandle(this,v_e);
        }
    }
    protected void m_cmd_luu_du_lieu_Click(object sender, EventArgs e)
    {
        try{
            m_lbl_mess.Text = "";
            form_2_us_object();
            switch (m_e_form_mode) { 
                case DataEntryFormMode.UpdateDataState:
                    m_us_gd_lop_mon.Update();
                    m_lbl_mess.Text = "Đã cập nhật dữ liệu thành công";
                    Response.Write("<script language='javascript'> { window.close();}</script>");

                    break;
                case DataEntryFormMode.InsertDataState:
                    // check trung ma lop mon
                    if (trung_ma_lop_mon()) {
                        m_lbl_mess.Text = "Mã lớp môn " + m_txt_ma_lop_mon.Text + " đã tồn tại, vui lòng nhập mã lớp môn khác";
                        return; }
                    m_us_gd_lop_mon.Insert();
                    m_lbl_mess.Text = "Đã thêm mới dữ liệu thành công";
                    Response.Write("<script language='javascript'> { window.close();}</script>");
                    
                    break;
            }

        }catch(Exception v_e){
            CSystemLog_301.ExceptionHandle(this,v_e);
        }
    }
    protected void m_cmd_thoat_Click(object sender, EventArgs e)
    {
        try{
            Response.Write("<script language='javascript'> { window.close();}</script>");
        }catch(Exception v_e){
             CSystemLog_301.ExceptionHandle(this,v_e);
        }
        
    }
}