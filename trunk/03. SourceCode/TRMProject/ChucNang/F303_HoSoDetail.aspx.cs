using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.IO;
using WebDS;
using WebUS;
using WebDS.CDBNames;

using IP.Core.IPCommon;
using IP.Core.IPUserService;
using IP.Core.IPData;
using System.Data;
using System.Text;

public partial class ChucNang_F303_HoSoDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        m_lbl_thong_bao.Text = "";
        m_cbo_loai_ho_so.Enabled = true;
        if (!IsPostBack)
        {
            m_cmd_cap_nhat_pl.Enabled = true;
            m_cmd_luu_du_lieu.Enabled = true;
            // show on grid
            if (Request.QueryString["id_hs"] != null)
            {
                m_lbl_id_ho_so.Text = Request.QueryString["id_hs"];
                load_data_2_grid(CIPConvert.ToDecimal(m_lbl_id_ho_so.Text));
            }
            load_data_2_basic_control();
            load_loai_giang_vien();
        }
    }
    
    #region Public Interface
    public string get_mapping_ten_giang_vien(object i_dc_id_giang_vien)
    {
        string v_str_ten_giang_vien = "";
        try
        {
            US_V_DM_GIANG_VIEN v_us_dm_giang_vien = new US_V_DM_GIANG_VIEN(CIPConvert.ToDecimal(i_dc_id_giang_vien));
            v_str_ten_giang_vien = v_us_dm_giang_vien.strHO_VA_TEN_DEM.TrimEnd() + " " + v_us_dm_giang_vien.strTEN_GIANG_VIEN;
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
        return v_str_ten_giang_vien;
    }
    public string get_mapping_loai_giang_vien(object i_dc_id_giang_vien)
    {
        string v_str_loai_giang_vien = "";
        try
        {
            US_V_DM_GIANG_VIEN v_us_dm_giang_vien = new US_V_DM_GIANG_VIEN(CIPConvert.ToDecimal(i_dc_id_giang_vien));
            v_str_loai_giang_vien = v_us_dm_giang_vien.strGVHD_YN.Trim() + v_us_dm_giang_vien.strGVCM_YN.Trim();
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
        return v_str_loai_giang_vien;
    }

    public string get_mapping_ten_don_vi_thanh_toan(object i_dc_id_don_vi_thanh_toan)
    {
        string v_str_ten_don_vi_thanh_toan = "";
        try
        {
            US_DM_DON_VI_THANH_TOAN v_us_dm_don_vi_thanh_toan = new US_DM_DON_VI_THANH_TOAN(CIPConvert.ToDecimal(i_dc_id_don_vi_thanh_toan));
            v_str_ten_don_vi_thanh_toan = v_us_dm_don_vi_thanh_toan.strTEN_DON_VI;
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
        return v_str_ten_don_vi_thanh_toan;
    }
    public string get_mapping_ma_to_ten_trang_thai(object ip_ma_tu_dien)
    {
        US_CM_DM_TU_DIEN v_us_cm_dm = new US_CM_DM_TU_DIEN(CIPConvert.ToDecimal(ip_ma_tu_dien));
        return v_us_cm_dm.strTEN;
    }
    // Chuyển tên về không dấu
    public string Change_AV(string ip_str_change)
    {
        Regex v_reg_regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
        string v_str_FormD = ip_str_change.Normalize(NormalizationForm.FormD);
        return v_reg_regex.Replace(v_str_FormD, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
    }
    public string get_file_name()
    {
        string m_str_file_name;
        US_DM_HO_SO_GIANG_VIEN v_us_gd_ho_so_gv = new US_DM_HO_SO_GIANG_VIEN(CIPConvert.ToDecimal(Request.QueryString["id_hs"]));
        string v_str_loai_ho_so = Change_AV(m_cbo_loai_ho_so.SelectedItem.Text);
        while (v_str_loai_ho_so.Contains(" "))
        {
            v_str_loai_ho_so.Replace(" ", "");
        }
        m_str_file_name = Change_AV(get_mapping_ten_giang_vien(v_us_gd_ho_so_gv.dcID_GIANG_VIEN)) + "_" + v_str_loai_ho_so + "_ver" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + "_" + DateTime.Now.Hour + DateTime.Now.Minute;
        //while (m_str_file_name.Contains(" "))
        //{
        //    m_str_file_name.Replace(" ", "");
        //}
        return m_str_file_name;
    }
    #endregion

    #region Members
    DataEntryFormMode m_init_mode = DataEntryFormMode.ViewDataState;
    DS_GD_HO_SO_GV_DETAIL m_ds_gd_ho_so_gv_detail = new DS_GD_HO_SO_GV_DETAIL();
    US_GD_HO_SO_GV_DETAIL m_us_gd_ho_so_gv_detail = new US_GD_HO_SO_GV_DETAIL();
    #endregion

    #region Private Method
    private void reset_control()
    {
        m_txt_ghi_chu.Text = "";
        m_cbo_loai_ho_so.SelectedIndex = 0;
        m_lbl_ten_hs_dinh_kem.Text = "";
        lblHoSoDinhKem1.Visible = false;
        lblHoSoDinhKem0.Visible = false;
    }
    private void Cap_nhat()
    {
        // Nếu chưa tồn tại
        string v_str_uploadFolder = Request.PhysicalApplicationPath + "HoSoDinhKem\\";
        if (m_up_ho_so.HasFile && m_up_ho_so.PostedFile.ContentLength > 8192)
        {
            string someScript;
            someScript = "<script language='javascript'>alert('File upload phải có dung lượng nhỏ hơn 8Mb');</script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "onload", someScript);
            //m_lbl_thong_bao.Text = "Nội dung thanh tóan này đã tồn tại trong hợp đồng này";
            return;
        }
        if (m_up_ho_so.HasFile)
        {
            string v_str_extension = Path.GetExtension(m_up_ho_so.PostedFile.FileName);
            m_txt_ten_hs_dinh_kem.Text = get_file_name();
            if (m_txt_ten_hs_dinh_kem.Text.Trim() != "")
            {
                m_up_ho_so.SaveAs(v_str_uploadFolder + m_txt_ten_hs_dinh_kem.Text.Trim() + v_str_extension);
                m_lbl_ten_hs_dinh_kem.Text = m_txt_ten_hs_dinh_kem.Text.Trim() + v_str_extension;
            }
            else
            {
                m_up_ho_so.SaveAs(v_str_uploadFolder + Path.GetFileName(m_up_ho_so.PostedFile.FileName) + v_str_extension);
                m_lbl_ten_hs_dinh_kem.Text = Path.GetFileName(m_up_ho_so.PostedFile.FileName);
            }
            form_2_us_object();
        }
        else
        {
            form_2_us_object_update();
        }
        m_us_gd_ho_so_gv_detail.Update();
        m_lbl_mess.Text = "Cập nhật thành công";
    }
    // Load loại giảng viên
    private void load_loai_giang_vien()
    {
        try
        {
            US_CM_DM_TU_DIEN v_cm_dm_tu_dien = new US_CM_DM_TU_DIEN();
            DS_CM_DM_TU_DIEN v_ds_cm_dm_tu_dien = new DS_CM_DM_TU_DIEN();
            string m_str_loai_giang_vien = "";
            US_DM_HO_SO_GIANG_VIEN v_us_gd_ho_so_gv = new US_DM_HO_SO_GIANG_VIEN(CIPConvert.ToDecimal(Request.QueryString["id_hs"]));
            if (!v_us_gd_ho_so_gv.IsIDNull())
            {
                m_str_loai_giang_vien = get_mapping_loai_giang_vien(v_us_gd_ho_so_gv.dcID_GIANG_VIEN);
                if (m_str_loai_giang_vien == "NY" || m_str_loai_giang_vien == "YY")
                {
                    m_lbl_loai_giang_vien.Text = "Giảng viên chuyên môn";
                    v_cm_dm_tu_dien.FillDataset(v_ds_cm_dm_tu_dien, " WHERE ID_LOAI_TU_DIEN = " + (int)e_loai_tu_dien.LOAI_HO_SO_GV_CM);
                }
                else
                {
                    m_lbl_loai_giang_vien.Text = "Giảng viên hướng dẫn";
                    v_cm_dm_tu_dien.FillDataset(v_ds_cm_dm_tu_dien, " WHERE ID_LOAI_TU_DIEN = " + (int)e_loai_tu_dien.LOAI_HO_SO_GV_HD);
                }
                m_cbo_loai_ho_so.DataTextField = CM_DM_TU_DIEN.TEN;
                m_cbo_loai_ho_so.DataValueField = CM_DM_TU_DIEN.ID;

                m_cbo_loai_ho_so.DataSource = v_ds_cm_dm_tu_dien.CM_DM_TU_DIEN;
                m_cbo_loai_ho_so.DataBind();
            }
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }

    }
    private void Them_moi()
    {
        string v_str_result = "";
        if (!check_exist_giang_vien_dv_tt(CIPConvert.ToDecimal(Request.QueryString["id_hs"]), m_cbo_loai_ho_so.SelectedValue, out v_str_result))
        {
            string v_str_script = string.Format("<script language='javascript'> alert('{0}'); </script>", v_str_result);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Oncheck", v_str_script);
            return;
        }
        // Nếu chưa tồn tại
        string v_str_uploadFolder = Request.PhysicalApplicationPath + "HoSoDinhKem\\";
        if (m_up_ho_so.HasFile && m_up_ho_so.PostedFile.ContentLength > 8192)
        {
            string someScript;
            someScript = "<script language='javascript'>alert('File upload phải có dung lượng nhỏ hơn 8Mb');</script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "onload", someScript);
            //m_lbl_thong_bao.Text = "Nội dung thanh tóan này đã tồn tại trong hợp đồng này";
            return;
        }
        if (m_up_ho_so.HasFile)
        {
            string v_str_extension = Path.GetExtension(m_up_ho_so.PostedFile.FileName);
            m_txt_ten_hs_dinh_kem.Text = get_file_name();
            if (m_txt_ten_hs_dinh_kem.Text.Trim() != "")
            {
                m_up_ho_so.SaveAs(v_str_uploadFolder + m_txt_ten_hs_dinh_kem.Text.Trim() + v_str_extension);
                m_lbl_ten_hs_dinh_kem.Text = m_txt_ten_hs_dinh_kem.Text.Trim() + v_str_extension;
            }
            else
            {
                m_up_ho_so.SaveAs(v_str_uploadFolder + Path.GetFileName(m_up_ho_so.PostedFile.FileName) + v_str_extension);
                m_lbl_ten_hs_dinh_kem.Text = Path.GetFileName(m_up_ho_so.PostedFile.FileName);
            }
            m_lbl_mess.Text = "Thêm thành công";
            form_2_us_object();
            m_us_gd_ho_so_gv_detail.Insert();
        }
        else
        {
            m_lbl_mess.Text = "Bạn cần chọn hồ sơ đính kèm";
        }
    }

    private bool check_exist_giang_vien_dv_tt(decimal ip_id_ho_so, string ip_str_loai_hs, out string op_str_du_an_trung)
    {
        m_us_gd_ho_so_gv_detail.check_trung_giang_vien_dvtt(m_ds_gd_ho_so_gv_detail, ip_id_ho_so, ip_str_loai_hs);
        op_str_du_an_trung = "";
        if (m_ds_gd_ho_so_gv_detail.GD_HO_SO_GV_DETAIL.Rows.Count > 0)
        {
            op_str_du_an_trung = "Đã tồn tại bản ghi này.";
            return false;
        }
        return true;
    }

    private void form_2_us_object(US_GD_HO_SO_GV_DETAIL op_us_gd_ho_so_gv_detail)
    {
        try
        {

            op_us_gd_ho_so_gv_detail.strTEN_LOAI_HO_SO = m_cbo_loai_ho_so.SelectedValue;
            op_us_gd_ho_so_gv_detail.strGHI_CHU = m_txt_ghi_chu.Text;
            op_us_gd_ho_so_gv_detail.dcID_HO_SO = CIPConvert.ToDecimal(m_lbl_id_ho_so.Text);
            op_us_gd_ho_so_gv_detail.strHO_SO_DINH_KEM = m_lbl_ten_hs_dinh_kem.Text;

        }
        catch (Exception v_e)
        {

            throw v_e;
        }

    }

    private void form_2_us_object_update(US_GD_HO_SO_GV_DETAIL op_us_gd_ho_so_gv_detail)
    {
        try
        {

            op_us_gd_ho_so_gv_detail.strTEN_LOAI_HO_SO = m_cbo_loai_ho_so.SelectedValue;
            op_us_gd_ho_so_gv_detail.strGHI_CHU = m_txt_ghi_chu.Text;
            op_us_gd_ho_so_gv_detail.dcID_HO_SO = CIPConvert.ToDecimal(m_lbl_id_ho_so.Text);
            op_us_gd_ho_so_gv_detail.strHO_SO_DINH_KEM = lblHoSoDinhKem0.Text;

        }
        catch (Exception v_e)
        {

            throw v_e;
        }

    }

    private void us_object_2_form(US_GD_HO_SO_GV_DETAIL ip_us_gd_ho_so_gv_detail)
    {
        try
        {
            m_cbo_loai_ho_so.Enabled = false;
            m_txt_ghi_chu.Text = ip_us_gd_ho_so_gv_detail.strGHI_CHU;
            m_cbo_loai_ho_so.SelectedValue = ip_us_gd_ho_so_gv_detail.strTEN_LOAI_HO_SO;
            lblHoSoDinhKem1.Visible = true;
            lblHoSoDinhKem0.Visible = true;
            lblHoSoDinhKem0.Text = ip_us_gd_ho_so_gv_detail.strHO_SO_DINH_KEM;
        }
        catch (Exception v_e)
        {

            throw v_e;
        }

    }
    // Load data và hiển thị lên form
    private void load_data_2_us_by_id_and_show_on_form(int ip_i_ho_so_selected)
    {
        try
        {
            decimal v_dc_id_loai_ho_so = CIPConvert.ToDecimal(m_grv_gd_ho_so_detail.DataKeys[ip_i_ho_so_selected].Value);
            hdf_id_gv.Value = CIPConvert.ToStr(v_dc_id_loai_ho_so);
            US_GD_HO_SO_GV_DETAIL v_us_gd_ho_so_gv_detail = new US_GD_HO_SO_GV_DETAIL(v_dc_id_loai_ho_so);

            // Load data to form 
            us_object_2_form(v_us_gd_ho_so_gv_detail);
        }
        catch (Exception v_e)
        {
            throw v_e;
        }

    }
    private void delete_row_ho_so_gv_detail(int ip_i_id_ho_so)
    {
        decimal v_dc_id_ho_so_gv_detail = CIPConvert.ToDecimal(m_grv_gd_ho_so_detail.DataKeys[ip_i_id_ho_so].Value);
        m_us_gd_ho_so_gv_detail.dcID = v_dc_id_ho_so_gv_detail;
        m_us_gd_ho_so_gv_detail.DeleteByID(v_dc_id_ho_so_gv_detail);
        m_lbl_thong_bao.Text = "Xóa bản ghi thành công";
        load_data_2_grid(CIPConvert.ToDecimal(Request.QueryString["id_hs"]));
    }
    private void load_data_2_grid(decimal ip_dc_id_hs)
    {
        try
        {
            m_us_gd_ho_so_gv_detail.FillDataset(m_ds_gd_ho_so_gv_detail, " WHERE ID_HO_SO=" + ip_dc_id_hs);

            // Nếu chưa có phụ lục nào ứng với hồ sơ này
            if (m_ds_gd_ho_so_gv_detail.GD_HO_SO_GV_DETAIL.Rows.Count == 0)
            {
                // m_pnl_table.Visible = true;
                if (m_cbo_loai_ho_so.Items.Count == 0)
                {
                    // m_lbl_mess.Text = "";
                    string someScript;
                    someScript = "<script language='javascript'>alert('Chưa có chi tiết hồ sơ nào ứng với loại hồ sơ này!');</script>";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "onload", someScript);
                    // Ko cho phéo add
                    m_cmd_luu_du_lieu.Enabled = false;
                }
                // Nếu chưa có gì thì ko cho cập nhật
                m_cmd_cap_nhat_pl.Enabled = false;
                m_grv_gd_ho_so_detail.Visible = false;
                m_grv_gd_ho_so_detail.DataSource = m_ds_gd_ho_so_gv_detail.GD_HO_SO_GV_DETAIL;
                m_grv_gd_ho_so_detail.DataBind();
            }
            else
            {
                // Load to grid
                m_grv_gd_ho_so_detail.Visible = true;
                m_grv_gd_ho_so_detail.DataSource = m_ds_gd_ho_so_gv_detail.GD_HO_SO_GV_DETAIL;
                m_grv_gd_ho_so_detail.DataBind();
            }
        }
        catch (Exception v_e)
        {

            throw v_e;
        }

    }
    // Load data to so hợp đồng và tên giảng viên
    private void load_data_2_basic_control()
    {
        try
        {
            US_DM_HO_SO_GIANG_VIEN v_us_gd_ho_so_gv = new US_DM_HO_SO_GIANG_VIEN(CIPConvert.ToDecimal(Request.QueryString["id_hs"]));
            if (!v_us_gd_ho_so_gv.IsIDNull())
            {
                m_lbl_giang_vien.Text = get_mapping_ten_giang_vien(v_us_gd_ho_so_gv.dcID_GIANG_VIEN);
                m_lbl_don_vi_thanh_toan.Text = get_mapping_ten_don_vi_thanh_toan(v_us_gd_ho_so_gv.dcID_DON_VI_THANH_TOAN);
                m_lbl_trang_thai.Text = get_mapping_ma_to_ten_trang_thai(v_us_gd_ho_so_gv.dcID_TRANG_THAI);
                m_lbl_dat_ngay_cap_nhat.Text = CIPConvert.ToStr(v_us_gd_ho_so_gv.datNGAY_CAP_NHAT);
            }
        }
        catch (Exception v_e)
        {

            //throw v_e;
        }
    }
    // Lấy được i nội dung thanh toán từ id phụ lục đã biết
    private string get_id_ho_so_gv_by_id_detail(decimal ip_dc_id_detail)
    {
        US_GD_HO_SO_GV_DETAIL v_us_gd_ho_so_gv_detail = new US_GD_HO_SO_GV_DETAIL(ip_dc_id_detail);
        if (v_us_gd_ho_so_gv_detail.IsIDNull()) return "";
        return v_us_gd_ho_so_gv_detail.strTEN_LOAI_HO_SO;
    }

    private bool check_exist_ho_so_detail(string ip_str_ho_so_detail)
    {
        for (int v_i = 0; v_i < m_grv_gd_ho_so_detail.Rows.Count; v_i++)
        {
            if (ip_str_ho_so_detail == get_id_ho_so_gv_by_id_detail(CIPConvert.ToDecimal(m_grv_gd_ho_so_detail.DataKeys[v_i].Value)))
                //if (ip_dc_id_noi_dung_tt == CIPConvert.ToDecimal(m_cbo_loai_ho_so.Items[v_i].Value))
                // True nghĩa là có tồn tại
                return true;
        }
        // false nghia là không tồn tại
        return false;
    }

    private void form_2_us_object()
    {
        US_DM_HO_SO_GIANG_VIEN v_us_gd_ho_so_gv = new US_DM_HO_SO_GIANG_VIEN(CIPConvert.ToDecimal(Request.QueryString["id_hs"]));
        m_us_gd_ho_so_gv_detail.dcID_HO_SO = v_us_gd_ho_so_gv.dcID;
        m_us_gd_ho_so_gv_detail.strTEN_LOAI_HO_SO = m_cbo_loai_ho_so.SelectedValue;
        m_us_gd_ho_so_gv_detail.strHO_SO_DINH_KEM = m_txt_ten_hs_dinh_kem.Text;
        m_us_gd_ho_so_gv_detail.strGHI_CHU = m_txt_ghi_chu.Text;
    }
    private void form_2_us_object_update()
    {
        US_DM_HO_SO_GIANG_VIEN v_us_gd_ho_so_gv = new US_DM_HO_SO_GIANG_VIEN(CIPConvert.ToDecimal(Request.QueryString["id_hs"]));
        m_us_gd_ho_so_gv_detail.dcID_HO_SO = v_us_gd_ho_so_gv.dcID;
        m_us_gd_ho_so_gv_detail.strTEN_LOAI_HO_SO = m_cbo_loai_ho_so.SelectedValue;
        m_us_gd_ho_so_gv_detail.strHO_SO_DINH_KEM = lblHoSoDinhKem0.Text;
        m_us_gd_ho_so_gv_detail.strGHI_CHU = m_txt_ghi_chu.Text;
    }
    #endregion

    #region Events
    protected void m_cmd_luu_du_lieu_Click(object sender, EventArgs e)
    {
        try
        {
            form_2_us_object(m_us_gd_ho_so_gv_detail);
            if (m_lbl_ten_hs_dinh_kem.Text == "")
            {
                string someScript;
                someScript = "<script language='javascript'>alert('Chưa đính kèm hồ sơ hoặc chưa ấn upload');</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "onload", someScript);
                //m_lbl_thong_bao.Text = "Nội dung thanh tóan này đã tồn tại trong hợp đồng này";
                return;
            }
            if (check_exist_ho_so_detail(m_us_gd_ho_so_gv_detail.strTEN_LOAI_HO_SO))
            {
                string someScript;
                someScript = "<script language='javascript'>alert('Chi tiết hồ sơ này đã tồn tại trong hồ sơ gv này');</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "onload", someScript);
                //m_lbl_thong_bao.Text = "Nội dung thanh tóan này đã tồn tại trong hợp đồng này";
                return;
            }
            m_us_gd_ho_so_gv_detail.Insert();
            m_lbl_thong_bao.Text = "Thêm bản ghi thành công";
            reset_control();
            //m_pnl_table.Visible = false;
            load_data_2_grid(CIPConvert.ToDecimal(Request.QueryString["id_hs"]));
            // Cho phép cập nhật trở lai
            m_cmd_cap_nhat_pl.Enabled = true;
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
            reset_control();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.Equals(this, v_e);
        }
    }
    protected void m_grv_gd_ho_so_gv_detail_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            m_init_mode = DataEntryFormMode.UpdateDataState;
            m_cmd_luu_du_lieu.Enabled = false;
            m_cbo_loai_ho_so.Enabled = false;
            m_cmd_cap_nhat_pl.Enabled = true;
            m_lbl_thong_bao.Text = "";
            //m_pnl_table.Visible = true;
            load_data_2_us_by_id_and_show_on_form(e.NewSelectedIndex);
        }
        catch (Exception V_e)
        {
            CSystemLog_301.ExceptionHandle(this, V_e);
        }
    }
    protected void m_grv_gd_ho_so_gv_detail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            m_lbl_thong_bao.Text = "";
            delete_row_ho_so_gv_detail(e.RowIndex);
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cmd_cap_nhat_pl_Click(object sender, EventArgs e)
    {
        try
        {
            if (hdf_id_gv.Value == "")
            {
                string someScript;
                someScript = "<script language='javascript'>alert('Bạn phải chọn nội dung cần Cập nhật');</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "onload", someScript);
                //m_lbl_mess.Text = "";
                return;
            }
            form_2_us_object(m_us_gd_ho_so_gv_detail);
            //if (check_exist_noi_dung_tt(m_us_gd_ho_so_gv_detail.dcID_NOI_DUNG_TT))
            //{
            //    m_lbl_thong_bao.Text = "Nội dung thanh tóan này đã tồn tại trong hợp đồng này";
            //    return;
            //}
            m_us_gd_ho_so_gv_detail.dcID = CIPConvert.ToDecimal(hdf_id_gv.Value);
            m_us_gd_ho_so_gv_detail.Update();
            m_lbl_thong_bao.Text = "Cập nhật bản ghi thành công";
            reset_control();
            //m_pnl_table.Visible = false;
            m_cmd_luu_du_lieu.Enabled = true;
            load_data_2_grid(CIPConvert.ToDecimal(Request.QueryString["id_hs"]));
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cmd_exit_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("/TRMProject/DanhMuc/F106_HoSo.aspx", false);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        catch (Exception v_e)
        {

            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_loai_ho_so_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    protected void m_grv_gd_ho_so_detail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            m_grv_gd_ho_so_detail.PageIndex = e.NewPageIndex;
            load_data_2_grid(CIPConvert.ToDecimal(Request.QueryString["id_hs"]));
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cmd_luu_du_lieu_Click1(object sender, EventArgs e)
    {
        Them_moi();
        reset_control();
        m_lbl_id_ho_so.Text = Request.QueryString["id_hs"];
        load_data_2_grid(CIPConvert.ToDecimal(m_lbl_id_ho_so.Text));
    }
    protected void m_cmd_cap_nhat_pl_Click1(object sender, EventArgs e)
    {
        Cap_nhat();
        m_cbo_loai_ho_so.Enabled = true;
        reset_control();
        m_lbl_id_ho_so.Text = Request.QueryString["id_hs"];
        load_data_2_grid(CIPConvert.ToDecimal(m_lbl_id_ho_so.Text));
    }
    #endregion
}