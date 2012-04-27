using System;
using System.Collections.Generic;

using System.Web;

/// <summary>
/// Summary description for CSystemMessage
/// </summary>
public class CSystemMessage
{
	public CSystemMessage()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    string m_str_url_mess_site_err = "../MessageError.aspx?mess=";
    public void ExceptionHanlde(System.Web.UI.Page v_page, Exception v_e) {
        v_page.Response.Redirect("../MessageError.aspx?mess=" + "Message: " + v_e.Message + " Source: " + v_e.Source);
    }
}