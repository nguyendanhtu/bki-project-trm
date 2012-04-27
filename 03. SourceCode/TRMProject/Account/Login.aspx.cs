using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IP.Core.IPCommon;
using IP.Core.IPData;
using IP.Core.IPUserService;
public partial class Account_Login : System.Web.UI.Page
{
    #region Data structure
    #endregion

    #region Members
    #endregion

    #region Private methods
    private void LoginSystem()
    {
        if (Page.IsValid)
        {
            string strUserName = this.txtUserName.Text.Trim();
            string strPassWord = this.txtPassWord.Text.Trim();
            //strPassWord = FormsAuthentication.HashPasswordForStoringInConfigFile(strPassWord, "SHA1");
            CheckAccount(strUserName, strPassWord);
        }
        
    }
    // Kiem tra cap ten/mat khau
    public void CheckAccount(string strUserName, string strPassWord)
    {
        US_HT_NGUOI_SU_DUNG v_us_nguoi_su_dung = new US_HT_NGUOI_SU_DUNG();
        US_HT_NGUOI_SU_DUNG.LogonResult v_log_result = US_HT_NGUOI_SU_DUNG.LogonResult.WrongPassword_OR_Name;
        v_us_nguoi_su_dung.check_user(strUserName, strPassWord, ref v_log_result);
        if (v_log_result == US_HT_NGUOI_SU_DUNG.LogonResult.OK_Login_Succeeded)
        {
            if (this.cbxRememberPassword.Checked)
            {
                Response.Cookies["UserName"].Expires = DateTime.Now.AddMonths(1);
                Response.Cookies["PassWord"].Expires = DateTime.Now.AddMonths(1);
                Response.Cookies["UserName"].Value = strUserName;
                Response.Cookies["PassWord"].Value = strPassWord;
            }
            Session["AccounLogin"] = "Y";
            Session["Username"] = strUserName;
            Response.Redirect("../Default.aspx");
        }
        else
        {
            this.ctvLogin.IsValid = false;
        }
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request.Cookies["UserName"] != null && Request.Cookies["PassWord"] != null)
            {
                Response.Cookies.Set(Request.Cookies["UserName"]);
                Response.Cookies.Set(Request.Cookies["PassWord"]);
                if (!Response.Cookies["UserName"].Value.Equals("") && !Response.Cookies["PassWord"].Value.Equals(""))
                {
                    this.txtUserName.Text = Response.Cookies["UserName"].Value.ToString().Trim();
                    this.txtPassWord.Text = Response.Cookies["PassWord"].Value.ToString().Trim();
                    CheckAccount(Request.Cookies["UserName"].Value, Request.Cookies["PassWord"].Value);
                }
            }
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try {
            this.ctvLogin.IsValid = true;
            LoginSystem();
        }
        catch (Exception v_e) {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
}