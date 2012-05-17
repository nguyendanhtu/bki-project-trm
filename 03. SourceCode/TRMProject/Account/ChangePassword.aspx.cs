using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using IP.Core.IPException;
using IP.Core.IPData;
using IP.Core.IPBusinessService;
using IP.Core.IPCommon;
using IP.Core.IPUserService;

using WebDS;
using WebUS;
using WebDS.CDBNames;

public partial class Account_ChangePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region Members
    US_HT_NGUOI_SU_DUNG m_us_ht_nguoi_su_dung = new US_HT_NGUOI_SU_DUNG();
    DS_HT_NGUOI_SU_DUNG m_ds_ht_nguoi_su_dung = new DS_HT_NGUOI_SU_DUNG();
    #endregion

    #region Private Methods
    private string get_current_password(string ip_str_ten_dang_nhap_nguoi_su_dung)
    {
        m_us_ht_nguoi_su_dung.FillDataset(m_ds_ht_nguoi_su_dung, " WHERE TEN_TRUY_CAP='"+ip_str_ten_dang_nhap_nguoi_su_dung+"'");
        return m_ds_ht_nguoi_su_dung.HT_NGUOI_SU_DUNG.Rows[0][HT_NGUOI_SU_DUNG.MAT_KHAU].ToString();
    }

    #endregion

    #region Events
     protected void m_cmd_doi_mat_khau_Click(object sender, EventArgs e)
    {
        try
        {
            string v_str_ten_dang_nhap = CIPConvert.ToStr(Session["Username"]);
            // Kiểm tra mật khẩu cũ nhập vào đã chuẩn chưa?
            if (!m_txt_old_password.Text.Equals(get_current_password(v_str_ten_dang_nhap)))
            {
                m_lbl_mess.Text = "Mật khẩu cũ nhập vào chưa đúng";
                return;
            }
            m_us_ht_nguoi_su_dung.strMAT_KHAU = m_txt_new_password.Text;
            m_us_ht_nguoi_su_dung.strTEN_TRUY_CAP = v_str_ten_dang_nhap;
            m_us_ht_nguoi_su_dung.change_pass_word();
            m_lbl_mess.Text = "Thay đổi mật khẩu thành công";
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
            Response.Redirect("Default.aspx",true);
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    #endregion

   
}