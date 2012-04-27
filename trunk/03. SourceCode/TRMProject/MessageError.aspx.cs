using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IP.Core.IPException;
public partial class MessageError : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try {
            if (this.Request.QueryString["mess"] != null) {
                m_lbl_mess.Text = "Thông báo lỗi: " + (string)this.Request.QueryString["mess"];
                
            }
        }
        catch (Exception v_e) {
            m_lbl_mess.Text = v_e.ToString();
        }
    }
}