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

public partial class CongTTGV_Welcome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UserName"]== null)
                Response.Redirect("/TRMProject/Account/Login.aspx");
            else
            {
                m_lbl_ten_giang_vien.Text = get_ten_giang_vien_by_ma_gv(CIPConvert.ToStr(Session["UserName"]));
            }
        }
    }

    #region Members
    US_V_DM_GIANG_VIEN m_us_dm_giang_vien = new US_V_DM_GIANG_VIEN();
    DS_V_DM_GIANG_VIEN m_ds_giang_vien = new DS_V_DM_GIANG_VIEN();
    #endregion
    #region Private Method
    private string get_ten_giang_vien_by_ma_gv(string ip_str_ma_gv)
    {
        m_us_dm_giang_vien.FillDataset(m_ds_giang_vien, " WHERE MA_GIANG_VIEN = N'" + ip_str_ma_gv + "'");
        if (m_us_dm_giang_vien.IsIDNull()) return "";
        return CIPConvert.ToStr(m_ds_giang_vien.V_DM_GIANG_VIEN.Rows[0][V_DM_GIANG_VIEN.HO_VA_TEN_DEM]).Trim() + " " + CIPConvert.ToStr(m_ds_giang_vien.V_DM_GIANG_VIEN.Rows[0][V_DM_GIANG_VIEN.TEN_GIANG_VIEN]).Trim();
    }
    #endregion
   
}