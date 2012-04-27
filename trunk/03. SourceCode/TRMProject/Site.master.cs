using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using IP.Core.IPBusinessService;
using IP.Core.IPCommon;
using IP.Core.IPData;
using IP.Core.IPUserService;
using WebDS;
using WebDS.CDBNames;
using WebUS;
using System.Data;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AccounLogin"] != null)
        {
            if (Session["AccounLogin"].ToString().Equals("Y"))
            {
                m_lhk_user_name.Text = "Xin chào: "+Session["UserName"].ToString();
            }
            else
            {
                Response.Redirect("/TRMProject/Account/Login.aspx");
            }
        }
        else
        {
            Response.Redirect("/TRMProject/Account/Login.aspx");
        }

        m_str_user_name = CIPConvert.ToStr(Session["UserName"]);
        if (!IsPostBack)
        {
            m_us_ht_chuc_nang.get_parent_table(m_str_user_name, m_ds_ht_chuc_nang);
            // Lấy toàn bộ các menu cấp 1 được cấp quyền và được hiển thị
            rptMainMenu.DataSource = m_ds_ht_chuc_nang.HT_CHUC_NANG.Select("CHUC_NANG_PARENT_ID =0 AND HIEN_THI_YN='Y'","VI_TRI");
            rptMainMenu.DataBind();
        }

    }
    protected void rptCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        DS_HT_CHUC_NANG.HT_CHUC_NANGRow dtr_row = (DS_HT_CHUC_NANG.HT_CHUC_NANGRow)e.Item.DataItem;        
        Repeater rptMenu_child = (Repeater)e.Item.FindControl("rpt_child_Menu");
        decimal v_dc_parent_id = CIPConvert.ToDecimal(dtr_row[0]);
        if (rptMenu_child != null)
        {
            // Cái này chứa những thằng con của menu cha, được cấp quyền và đc phép hiển thị
            rptMenu_child.DataSource = m_ds_ht_chuc_nang.HT_CHUC_NANG.Select("CHUC_NANG_PARENT_ID =" + v_dc_parent_id + " AND HIEN_THI_YN='Y'", " VI_TRI");
            rptMenu_child.DataBind();
        }
    }
    protected void rptCategory_ItemDataBound_cap_ba(object sender, RepeaterItemEventArgs e)
    {
        DS_HT_CHUC_NANG.HT_CHUC_NANGRow dtr_row = (DS_HT_CHUC_NANG.HT_CHUC_NANGRow)e.Item.DataItem;  
        Repeater rptMenu_child = (Repeater)e.Item.FindControl("rpt_child_Menu_cap_ba");
        decimal v_dc_parent_id = CIPConvert.ToDecimal(dtr_row[0]);
        //m_us_ht_chuc_nang.get_child_menu(v_dc_parent_id, m_str_user_name, m_ds_ht_chuc_nang);
        if (rptMenu_child != null)
        {
            // Cái này chứa những thằng con của thằng cha 
            rptMenu_child.DataSource = m_ds_ht_chuc_nang.HT_CHUC_NANG.Select("CHUC_NANG_PARENT_ID =" + v_dc_parent_id + " AND HIEN_THI_YN='Y'", "VI_TRI");
            rptMenu_child.DataBind();
        }
    }
    protected void rptCategory_ItemDataBound_cap_bon(object sender, RepeaterItemEventArgs e)
    {
        DS_HT_CHUC_NANG.HT_CHUC_NANGRow dtr_row = (DS_HT_CHUC_NANG.HT_CHUC_NANGRow)e.Item.DataItem;  
        Repeater rptMenu_child = (Repeater)e.Item.FindControl("rpt_child_Menu_cap_bon");
        decimal v_dc_parent_id = CIPConvert.ToDecimal(dtr_row[0]);
        //m_us_ht_chuc_nang.get_child_menu(v_dc_parent_id, m_str_user_name, m_ds_ht_chuc_nang);
        if (rptMenu_child != null)
        {
            // Cái này chứa những thằng con của thằng cha 
            rptMenu_child.DataSource = m_ds_ht_chuc_nang.HT_CHUC_NANG.Select("CHUC_NANG_PARENT_ID =" + v_dc_parent_id + " AND HIEN_THI_YN='Y'", "VI_TRI");
            rptMenu_child.DataBind();
        }
    }
    #region Members
    US_HT_CHUC_NANG m_us_ht_chuc_nang = new US_HT_CHUC_NANG();
    DS_HT_CHUC_NANG m_ds_ht_chuc_nang = new DS_HT_CHUC_NANG();
    string m_str_user_name = "";
    #endregion
}
