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
using System.Text.RegularExpressions;

public partial class CongTTGV_F1201_HoSoGiangVien : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            load_cbo_don_vi_quan_ly();
            load_data_2_cbo_hoc_vi();
            load_data_2_cbo_hoc_ham();
            load_cbo_trang_thai_giang_vien();
            load_data_2_cbo_po_quan_ly_chinh_va_phu();
            m_lbl_mess.Text = "";
            if (Session["UserName"] == null)
                Response.Redirect("/TRMProject/Account/Login.aspx");
            else
            {
                string v_str_giang_vien_user = CIPConvert.ToStr(Session["UserName"]); // đây là mã giảng viên
                m_dc_id = get_id_giang_vien_by_ma_gv(v_str_giang_vien_user);
                // Lưu mã giảng viên bằng Tool Tip của mã giảng viên
                m_txt_ma_giang_vien.ToolTip = CIPConvert.ToStr(m_dc_id);
                load_data_2_us_by_id_and_show_on_form(m_dc_id);
            }
        }
    }

    #region Members
    US_V_DM_GIANG_VIEN m_us_dm_giang_vien = new US_V_DM_GIANG_VIEN();
    DS_V_DM_GIANG_VIEN m_ds_giang_vien = new DS_V_DM_GIANG_VIEN();

    US_CM_DM_TU_DIEN m_us_cm_dm_tu_dien = new US_CM_DM_TU_DIEN();
    DS_CM_DM_TU_DIEN m_ds_cm_dm_tu_dien = new DS_CM_DM_TU_DIEN();
    //DataEntryFormMode m_init_mode;
    decimal m_dc_id = 0;
    #endregion

    #region Private Methods
    private void load_data_2_us_by_id_and_show_on_form(decimal ip_i_id)
    {
        US_V_DM_GIANG_VIEN v_us_dm_giang_vien = new US_V_DM_GIANG_VIEN(ip_i_id);
        // Đẩy us lên form
        us_object_2_form(v_us_dm_giang_vien);
    }
    // Load lên combo
    private void load_cbo_don_vi_quan_ly()
    {
        try
        {
            m_ds_cm_dm_tu_dien.CM_DM_TU_DIEN.Clear();
            // Đổ dữ liệu vào DS 
            m_us_cm_dm_tu_dien.FillDataset(m_ds_cm_dm_tu_dien, " WHERE ID_LOAI_TU_DIEN = " + (int)e_loai_tu_dien.DON_VI_QUAN_LY_CHINH); // Đây là lấy theo điều kiện

            //TReo dữ liệu vào Dropdownlist loại hợp đồng
            // dây là giá trị hiển thị
            // Đây là giá trị thực
            m_cbo_dm_don_vi_quan_ly.DataValueField = CM_DM_TU_DIEN.ID;
            m_cbo_dm_don_vi_quan_ly.DataTextField = CM_DM_TU_DIEN.TEN;
            m_cbo_dm_don_vi_quan_ly.DataSource = m_ds_cm_dm_tu_dien.CM_DM_TU_DIEN;
            m_cbo_dm_don_vi_quan_ly.DataBind();
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    private void load_data_2_cbo_hoc_vi()
    {
        try
        {
            m_ds_cm_dm_tu_dien.CM_DM_TU_DIEN.Clear();
            // Đổ dữ liệu vào DS 
            m_us_cm_dm_tu_dien.FillDataset(m_ds_cm_dm_tu_dien, " WHERE ID_LOAI_TU_DIEN = " + (int)e_loai_tu_dien.HOC_VI); // Đây là lấy theo điều kiện

            m_cbo_hoc_vi.DataValueField = CM_DM_TU_DIEN.MA_TU_DIEN;
            m_cbo_hoc_vi.DataTextField = CM_DM_TU_DIEN.TEN;

            m_cbo_hoc_vi.DataSource = m_ds_cm_dm_tu_dien.CM_DM_TU_DIEN;
            m_cbo_hoc_vi.DataBind();
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    private void load_data_2_cbo_hoc_ham()
    {
        try
        {
            m_ds_cm_dm_tu_dien.CM_DM_TU_DIEN.Clear();
            // Đổ dữ liệu vào DS 
            m_us_cm_dm_tu_dien.FillDataset(m_ds_cm_dm_tu_dien, " WHERE ID_LOAI_TU_DIEN = " + (int)e_loai_tu_dien.HOC_HAM); // Đây là lấy theo điều kiện

            m_cbo_hoc_ham.DataValueField = CM_DM_TU_DIEN.MA_TU_DIEN;
            m_cbo_hoc_ham.DataTextField = CM_DM_TU_DIEN.TEN;

            m_cbo_hoc_ham.DataSource = m_ds_cm_dm_tu_dien.CM_DM_TU_DIEN;
            m_cbo_hoc_ham.DataBind();
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    private void load_cbo_trang_thai_giang_vien()
    {
        try
        {
            m_ds_cm_dm_tu_dien.CM_DM_TU_DIEN.Clear();
            // Đổ dữ liệu vào DS 
            m_us_cm_dm_tu_dien.FillDataset(m_ds_cm_dm_tu_dien, " WHERE ID_LOAI_TU_DIEN = " + (int)e_loai_tu_dien.TRANG_THAI_GIANG_VIEN); // Đây là lấy theo điều kiện

            //TReo dữ liệu vào Dropdownlist loại hợp đồng
            // dây là giá trị hiển thị
            // Đây là giá trị thực
            m_cbo_dm_trang_thai_giang_vien.DataValueField = CM_DM_TU_DIEN.ID;
            m_cbo_dm_trang_thai_giang_vien.DataTextField = CM_DM_TU_DIEN.TEN;

            m_cbo_dm_trang_thai_giang_vien.DataSource = m_ds_cm_dm_tu_dien.CM_DM_TU_DIEN;
            m_cbo_dm_trang_thai_giang_vien.DataBind();
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    private void load_data_2_cbo_po_quan_ly_chinh_va_phu()
    {
        US_HT_NGUOI_SU_DUNG v_us_nguoi_su_dung = new US_HT_NGUOI_SU_DUNG();
        DS_HT_NGUOI_SU_DUNG v_ds_nguoi_su_dung = new DS_HT_NGUOI_SU_DUNG();
        try
        {
            v_us_nguoi_su_dung.FillDataset(v_ds_nguoi_su_dung);

            // Load data to PO phụ trách chính Combobox
            m_cbo_po_phu_trach_chinh.DataSource = v_ds_nguoi_su_dung.HT_NGUOI_SU_DUNG;

            m_cbo_po_phu_trach_chinh.DataValueField = HT_NGUOI_SU_DUNG.TEN_TRUY_CAP;
            m_cbo_po_phu_trach_chinh.DataTextField = HT_NGUOI_SU_DUNG.TEN;
            m_cbo_po_phu_trach_chinh.SelectedIndex = 0;
            m_cbo_po_phu_trach_chinh.DataBind();

            DataRow v_dr_none = v_ds_nguoi_su_dung.HT_NGUOI_SU_DUNG.NewHT_NGUOI_SU_DUNGRow();
            v_dr_none[HT_NGUOI_SU_DUNG.ID] = "0";
            v_dr_none[HT_NGUOI_SU_DUNG.TEN] = "Không có";
            v_dr_none[HT_NGUOI_SU_DUNG.MAT_KHAU] = "123456";
            v_dr_none[HT_NGUOI_SU_DUNG.TEN_TRUY_CAP] = "KHONG_CO";
            v_dr_none[HT_NGUOI_SU_DUNG.NGAY_TAO] = CIPConvert.ToDatetime("01/01/2011");
            v_dr_none[HT_NGUOI_SU_DUNG.NGUOI_TAO] = "ADMIN";
            v_dr_none[HT_NGUOI_SU_DUNG.BUILT_IN_YN] = "N";
            v_dr_none[HT_NGUOI_SU_DUNG.TRANG_THAI] = "0";

            v_ds_nguoi_su_dung.HT_NGUOI_SU_DUNG.Rows.InsertAt(v_dr_none, 0);
            m_cbo_po_phu_trach_phu.DataSource = v_ds_nguoi_su_dung.HT_NGUOI_SU_DUNG;

            m_cbo_po_phu_trach_phu.DataValueField = HT_NGUOI_SU_DUNG.TEN_TRUY_CAP;
            m_cbo_po_phu_trach_phu.DataTextField = HT_NGUOI_SU_DUNG.TEN;
            m_cbo_po_phu_trach_phu.SelectedIndex = 0;
            m_cbo_po_phu_trach_phu.DataBind();
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }

    private decimal get_id_giang_vien_by_ma_gv(string ip_str_ma_gv)
    {
        m_us_dm_giang_vien.FillDataset(m_ds_giang_vien, " WHERE MA_GIANG_VIEN = N'"+ip_str_ma_gv+"'");
        if (m_us_dm_giang_vien.IsIDNull()) return 0;
        return CIPConvert.ToDecimal(m_ds_giang_vien.V_DM_GIANG_VIEN.Rows[0][V_DM_GIANG_VIEN.ID]);
    }

    private void reset_control()
    {
        m_txt_ma_giang_vien.Enabled = true;
        m_txt_middle_name.Text = "";
        m_txt_last_name.Text = "";
        m_txt_chuc_vu_cao_nhat.Text = "";
        m_txt_chuc_vu_hien_tai.Text = "";
        m_txt_chuyen_nganh_chinh.Text = "";
        m_txt_email.Text = "";
        m_txt_co_quan_cong_tac.Text = "";
        m_txt_email_topica.Text = "";
        m_txt_ma_giang_vien.Text = "";
        m_txt_ma_so_thue.Text = "";
        m_txt_mobile_phone.Text = "";
        m_txt_noi_cap.Text = "";
        m_txt_so_cmnd.Text = "";
        m_txt_so_tai_khoan.Text = "";
        m_txt_tel_home.Text = "";
        m_txt_tel_office.Text = "";
        m_txt_ten_ngan_hang.Text = "";
        m_txt_truong_dao_tao.Text = "";
        rb_sex.Items[0].Selected = true;
        m_dat_ngay_cap.Text = "";
        m_txt_dia_chi_gv.Text = "";
    }
    private bool check_ma_giang_vien()
    {
        try
        {
            if (!m_us_dm_giang_vien.check_exist_ma_giang_vien(m_txt_ma_giang_vien.Text.TrimEnd())) return false;
            return true;
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    private bool check_check_loai_hop_dong()
    {
        if (m_cbl_loai_hop_dong.SelectedIndex < 0)
            return false;
        return true;
    }

    private void form_2_us_object(US_V_DM_GIANG_VIEN ip_us_giang_vien)
    {
        try
        {
            System.Globalization.CultureInfo enUS = new System.Globalization.CultureInfo("en-US");
            ip_us_giang_vien.dcID_DON_VI_QUAN_LY = CIPConvert.ToDecimal(m_cbo_dm_don_vi_quan_ly.SelectedValue);
            ip_us_giang_vien.strCHUC_VU_CAO_NHAT = m_txt_chuc_vu_cao_nhat.Text.Trim();
            ip_us_giang_vien.strCHUC_VU_HIEN_TAI = m_txt_chuc_vu_hien_tai.Text.Trim();
            ip_us_giang_vien.strCHUYEN_NGANH_CHINH = m_txt_chuyen_nganh_chinh.Text.Trim();
            ip_us_giang_vien.strDESCRIPTION = m_txt_description.Text.Trim();

            //if (m_txt_email.Text.Trim().Equals("")) ip_us_giang_vien.strEMAIL = "";
            //else if (!IsEmail(m_txt_email.Text))
            //{
            //    string someScript;
            //    someScript = "<script language='javascript'>alert('Email nhập sai định dạng !');</script>";
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "onload", someScript);
            //    m_txt_email.Focus();
            //    return;
            //}

            //if (m_txt_email_topica.Text.Trim().Equals("")) ip_us_giang_vien.strEMAIL_TOPICA = "";
            //else if (!IsEmail(m_txt_email_topica.Text))
            //{
            //    string someScript;
            //    someScript = "<script language='javascript'>alert('Email Topica nhập sai định dạng !');</script>";
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "onload", someScript);
            //    m_txt_email_topica.Focus();
            //    return;
            //}

            ip_us_giang_vien.strEMAIL = m_txt_email.Text.Trim();
            ip_us_giang_vien.strEMAIL_TOPICA = m_txt_email_topica.Text.Trim();
            ip_us_giang_vien.strEMAIL = m_txt_email.Text.Trim();
            ip_us_giang_vien.strEMAIL_TOPICA = m_txt_email_topica.Text.Trim();
            ip_us_giang_vien.strGIOI_TINH_YN = rb_sex.Items[0].Selected ? "Y" : "N";

            ip_us_giang_vien.strGV_DUYET_HL_YN = m_cbl_loai_hop_dong.Items[3].Selected ? "Y" : "N";
            ip_us_giang_vien.strGV_HDKH_YN = m_cbl_loai_hop_dong.Items[6].Selected ? "Y" : "N";
            ip_us_giang_vien.strGV_QUAY_HL = m_cbl_loai_hop_dong.Items[5].Selected ? "Y" : "N";
            ip_us_giang_vien.strGV_THAM_DINH_HL_YN = m_cbl_loai_hop_dong.Items[4].Selected ? "Y" : "N";
            ip_us_giang_vien.strGV_VIET_HL_YN = m_cbl_loai_hop_dong.Items[2].Selected ? "Y" : "N";
            ip_us_giang_vien.strGVCM_YN = m_cbl_loai_hop_dong.Items[1].Selected ? "Y" : "N";
            ip_us_giang_vien.strGVHD_YN = m_cbl_loai_hop_dong.Items[0].Selected ? "Y" : "N";

            ip_us_giang_vien.strHO_VA_TEN_DEM = m_txt_middle_name.Text.Trim();
            ip_us_giang_vien.strHOC_HAM = m_cbo_hoc_ham.SelectedValue;
            ip_us_giang_vien.strHOC_VI = m_cbo_hoc_vi.SelectedValue;
            ip_us_giang_vien.strID_TRANG_THAI_GIANG_VIEN = m_cbo_dm_trang_thai_giang_vien.SelectedValue;
            ip_us_giang_vien.strMA_GIANG_VIEN = m_txt_ma_giang_vien.Text.Trim();
            ip_us_giang_vien.strMA_SO_THUE = m_txt_ma_so_thue.Text.Trim();
            ip_us_giang_vien.strMOBILE_PHONE = m_txt_mobile_phone.Text.Trim();
            ip_us_giang_vien.strNOI_CAP = m_txt_noi_cap.Text.Trim();
            ip_us_giang_vien.strSO_CMTND = m_txt_so_cmnd.Text.Trim();
            ip_us_giang_vien.strSO_TAI_KHOAN = m_txt_so_tai_khoan.Text.Trim();
            ip_us_giang_vien.strTEL_HOME = m_txt_tel_home.Text.Trim();
            ip_us_giang_vien.strTEL_OFFICE = m_txt_tel_office.Text.Trim();
            ip_us_giang_vien.strTEN_CO_QUAN_CONG_TAC = m_txt_co_quan_cong_tac.Text.Trim();
            ip_us_giang_vien.strTEN_GIANG_VIEN = m_txt_last_name.Text.Trim();
            ip_us_giang_vien.strTEN_NGAN_HANG = m_txt_ten_ngan_hang.Text.Trim();
            ip_us_giang_vien.strDIA_CHI = m_txt_dia_chi_gv.Text.Trim();
            ip_us_giang_vien.strTRUONG_DAO_TAO = m_txt_truong_dao_tao.Text.Trim();
            DateTime v_dat_out_result;
            // Kiểm tra đúng định dạng datetime
            if (DateTime.TryParseExact(CIPConvert.ToStr(m_dat_ngay_sinh_gv.SelectedDate), "dd/MM/yyyy", enUS, System.Globalization.DateTimeStyles.None, out v_dat_out_result))
            {
                if (m_dat_ngay_sinh_gv.SelectedDate != CIPConvert.ToDatetime("01/01/0001"))
                    ip_us_giang_vien.datNGAY_SINH = m_dat_ngay_sinh_gv.SelectedDate;
                else ip_us_giang_vien.SetNGAY_SINHNull();
            }

            if (DateTime.TryParseExact(CIPConvert.ToStr(m_dat_ngay_cap.SelectedDate), "dd/MM/yyyy", enUS, System.Globalization.DateTimeStyles.None, out v_dat_out_result))
            {
                if (m_dat_ngay_cap.SelectedDate != CIPConvert.ToDatetime("01/01/0001"))
                    ip_us_giang_vien.datNGAY_CAP = m_dat_ngay_cap.SelectedDate;
                else ip_us_giang_vien.SetNGAY_CAPNull();
            }

            if (DateTime.TryParseExact(CIPConvert.ToStr(m_dat_ngay_bat_dau_hop_tac.SelectedDate), "dd/MM/yyyy", enUS, System.Globalization.DateTimeStyles.None, out v_dat_out_result))
            {
                if (m_dat_ngay_bat_dau_hop_tac.SelectedDate != CIPConvert.ToDatetime("01/01/0001"))
                    ip_us_giang_vien.datNGAY_BD_HOP_TAC = m_dat_ngay_bat_dau_hop_tac.SelectedDate;
                else ip_us_giang_vien.SetNGAY_BD_HOP_TACNull();
            }

            ip_us_giang_vien.strPO_PHU_TRACH_CHINH = m_cbo_po_phu_trach_chinh.SelectedValue;
            ip_us_giang_vien.strPO_PHU_TRACH_PHU = m_cbo_po_phu_trach_phu.SelectedValue;
        }
        catch (Exception v_e)
        {

            throw v_e;
        }

    }
    private void us_object_2_form(US_V_DM_GIANG_VIEN ip_us_giang_vien)
    {
        try
        {
            m_cbo_dm_don_vi_quan_ly.SelectedValue = CIPConvert.ToStr(ip_us_giang_vien.dcID_DON_VI_QUAN_LY);
            m_txt_chuc_vu_cao_nhat.Text = ip_us_giang_vien.strCHUC_VU_CAO_NHAT;
            m_txt_chuc_vu_hien_tai.Text = ip_us_giang_vien.strCHUC_VU_HIEN_TAI;
            m_txt_chuyen_nganh_chinh.Text = ip_us_giang_vien.strCHUYEN_NGANH_CHINH;
            m_txt_description.Text = ip_us_giang_vien.strDESCRIPTION;
            m_txt_email.Text = ip_us_giang_vien.strEMAIL;
            m_txt_email_topica.Text = ip_us_giang_vien.strEMAIL_TOPICA;

            if (ip_us_giang_vien.strGIOI_TINH_YN == "Y") rb_sex.Items[0].Selected = true;
            else rb_sex.Items[1].Selected = true;

            if (ip_us_giang_vien.strGV_DUYET_HL_YN == "Y") m_cbl_loai_hop_dong.Items[3].Selected = true;
            if (ip_us_giang_vien.strGV_HDKH_YN == "Y") m_cbl_loai_hop_dong.Items[6].Selected = true;
            if (ip_us_giang_vien.strGV_QUAY_HL == "Y") m_cbl_loai_hop_dong.Items[5].Selected = true;
            if (ip_us_giang_vien.strGV_THAM_DINH_HL_YN == "Y") m_cbl_loai_hop_dong.Items[4].Selected = true;
            if (ip_us_giang_vien.strGV_VIET_HL_YN == "Y") m_cbl_loai_hop_dong.Items[2].Selected = true;
            if (ip_us_giang_vien.strGVCM_YN == "Y") m_cbl_loai_hop_dong.Items[1].Selected = true;
            if (ip_us_giang_vien.strGVHD_YN == "Y") m_cbl_loai_hop_dong.Items[0].Selected = true;

            m_txt_middle_name.Text = ip_us_giang_vien.strHO_VA_TEN_DEM;
            m_txt_last_name.Text = ip_us_giang_vien.strTEN_GIANG_VIEN;
            m_cbo_hoc_ham.SelectedValue = ip_us_giang_vien.strHOC_HAM;
            m_cbo_hoc_vi.SelectedValue = ip_us_giang_vien.strHOC_VI;
            if (ip_us_giang_vien.strID_TRANG_THAI_GIANG_VIEN != "")
                m_cbo_dm_trang_thai_giang_vien.SelectedValue = CIPConvert.ToStr(CIPConvert.ToDecimal(ip_us_giang_vien.strID_TRANG_THAI_GIANG_VIEN));
            m_txt_ma_giang_vien.Text = ip_us_giang_vien.strMA_GIANG_VIEN;
            m_txt_ma_so_thue.Text = ip_us_giang_vien.strMA_SO_THUE;
            m_txt_mobile_phone.Text = ip_us_giang_vien.strMOBILE_PHONE;
            m_txt_noi_cap.Text = ip_us_giang_vien.strNOI_CAP;
            m_txt_so_cmnd.Text = ip_us_giang_vien.strSO_CMTND;
            m_txt_so_tai_khoan.Text = ip_us_giang_vien.strSO_TAI_KHOAN;
            m_txt_tel_home.Text = ip_us_giang_vien.strTEL_HOME;
            m_txt_tel_office.Text = ip_us_giang_vien.strTEL_OFFICE;
            m_txt_co_quan_cong_tac.Text = ip_us_giang_vien.strTEN_CO_QUAN_CONG_TAC;
            m_txt_ten_ngan_hang.Text = ip_us_giang_vien.strTEN_NGAN_HANG;
            m_txt_truong_dao_tao.Text = ip_us_giang_vien.strTRUONG_DAO_TAO;

            m_cbo_po_phu_trach_chinh.SelectedValue = ip_us_giang_vien.strPO_PHU_TRACH_CHINH;
            m_cbo_po_phu_trach_phu.SelectedValue = ip_us_giang_vien.strPO_PHU_TRACH_PHU;
            m_txt_dia_chi_gv.Text = ip_us_giang_vien.strDIA_CHI;

            //calendar.Value = CIPConvert.ToStr(ip_us_giang_vien.datNGAY_SINH);
            if (!ip_us_giang_vien.IsNGAY_SINHNull() || ip_us_giang_vien.datNGAY_SINH != CIPConvert.ToDatetime("01/01/1900", "dd/MM/yyyy"))
                m_dat_ngay_sinh_gv.SelectedDate = ip_us_giang_vien.datNGAY_SINH;
            if (!ip_us_giang_vien.IsNGAY_CAPNull() || ip_us_giang_vien.datNGAY_CAP != CIPConvert.ToDatetime("01/01/1900", "dd/MM/yyyy"))
                m_dat_ngay_cap.SelectedDate = ip_us_giang_vien.datNGAY_CAP;
            if (!ip_us_giang_vien.IsNGAY_BD_HOP_TACNull() || ip_us_giang_vien.datNGAY_BD_HOP_TAC != CIPConvert.ToDatetime("01/01/1900", "dd/MM/yyyy"))
                m_dat_ngay_bat_dau_hop_tac.SelectedDate = ip_us_giang_vien.datNGAY_BD_HOP_TAC;
        }
        catch (Exception v_e)
        {

            throw v_e;
        }

    }
    private string get_ten_by_ten_truy_cap(string ip_str_ten_truy_cap)
    {
        US_HT_NGUOI_SU_DUNG v_us_nguoi_su_dung = new US_HT_NGUOI_SU_DUNG();
        DS_HT_NGUOI_SU_DUNG v_ds_ht_nguoi_su_dung = new DS_HT_NGUOI_SU_DUNG();
        v_us_nguoi_su_dung.FillDataset(v_ds_ht_nguoi_su_dung, " WHERE TEN_TRUY_CAP = N'" + ip_str_ten_truy_cap + "'");
        if (v_ds_ht_nguoi_su_dung.HT_NGUOI_SU_DUNG.Rows.Count > 0) return v_ds_ht_nguoi_su_dung.HT_NGUOI_SU_DUNG.Rows[0][HT_NGUOI_SU_DUNG.TEN].ToString();
        return "";
    }
    #endregion

    #region Public Interface
    public bool IsEmail(string email)
    {
        string MatchEmailPattern =
           @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
    + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
    + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
    + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";
        if (email != null) return Regex.IsMatch(email, MatchEmailPattern);
        else return false;
    }
    #endregion

    //
    //Event
    //
    protected void m_cmd_luu_du_lieu_Click(object sender, EventArgs e)
    {
        try
        {
            string v_str_trang_thai_thong_ket = m_cbo_trang_thai_thong_tin.SelectedValue;
            m_us_dm_giang_vien.strCO_LOI_YN = v_str_trang_thai_thong_ket;
            m_us_dm_giang_vien.dcID = CIPConvert.ToDecimal(m_txt_ma_giang_vien.ToolTip);
            m_us_dm_giang_vien.thay_doi_trang_thai_thong_tin_ho_so();
            m_lbl_mess.Text = "Đã phản hồi thành công trạng thái của hồ sơ!";
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
            Response.Redirect("/TRMProject/CongTTGV/Welcome.aspx", false);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
}