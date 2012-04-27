using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WebDS;
using WebUS;
using WebDS.CDBNames;

using IP.Core.IPCommon;
using IP.Core.IPUserService;
using IP.Core.IPData;
using System.Data;

public partial class ChucNang_F603_ThanhToanChiTiet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        m_lbl_thong_bao.Text = "";
        m_cbo_noi_dung_tt.Enabled = true;
        if (!IsPostBack)
        {
            m_cmd_cap_nhat_pl.Enabled = true;
            m_cmd_luu_du_lieu.Enabled = true;
            enable_controls();
            // show on grid
            if (Request.QueryString["id_gdtt"] != null)
            {
                //Lấy ID GD_THANH_TOAN
                m_dc_id_gd_thanh_toan = CIPConvert.ToDecimal(Request.QueryString["id_gdtt"]);
                if (check_tam_ung(m_dc_id_gd_thanh_toan))
                {
                    //Chứa loại hợp đồng : học liệu hay vận hành
                    //string v_str_loai_hd = "";
                    //if (Request.QueryString["loai"] != null)
                    //    v_str_loai_hd = CIPConvert.ToStr(Request.QueryString["loai"]);
                    string somescript;
                    somescript = "<script language='javascript'>alert('Không có chi tiết thanh toán cho hợp đồng đã được tạm ứng')</script>";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Thongbao", somescript);
                    disable_controls();
                    //if (v_str_loai_hd.Equals("hl"))
                   // {
                        //Response.Redirect("/TRMProject/ChucNang/F602_DuToanHopDongHocLieu.aspx", false);
                        //HttpContext.Current.ApplicationInstance.CompleteRequest();
                    //}
                    //else
                    //{
                    //    Response.Redirect("/TRMProject/ChucNang/F501_DuToanHopDongVanHanh.aspx", false);
                    //    HttpContext.Current.ApplicationInstance.CompleteRequest();
                    //}
                    return;
                }
                else
                {
                    // Đổ vào nội dung thanh toán phụ lục ứng với hợp đồng
                    load_2_cbo_noi_dung_tt(get_id_hop_dong_khung_by_id_gd_thanh_toan(m_dc_id_gd_thanh_toan));
                    load_data_2_grid(m_dc_id_gd_thanh_toan);
                }
            }
            // Nếu đã có phụ lục rồi, hiển thị dữ liệu vào các textbox tương ứng
            if (m_cbo_noi_dung_tt.Items.Count > 0)
            {
                decimal v_dc_id_noi_dung_tt = CIPConvert.ToDecimal(m_cbo_noi_dung_tt.SelectedValue);
                US_V_GD_HOP_DONG_NOI_DUNG_TT v_us_dm_hd_noi_dung_tt = new US_V_GD_HOP_DONG_NOI_DUNG_TT(v_dc_id_noi_dung_tt);
                m_txt_don_gia_hd.Text = CIPConvert.ToStr(v_us_dm_hd_noi_dung_tt.dcDON_GIA_HD, "#,###");
                m_txt_so_luong_he_so.Text = CIPConvert.ToStr(v_us_dm_hd_noi_dung_tt.dcSO_LUONG_HE_SO, "#,###");
                m_lbl_don_vi_tinh.Text = v_us_dm_hd_noi_dung_tt.strDON_VI_TINH;
                if (!v_us_dm_hd_noi_dung_tt.IsTAN_SUATNull())
                    m_lbl_tan_suat.Text = "Theo " + v_us_dm_hd_noi_dung_tt.strTAN_SUAT;
                else m_lbl_tan_suat.Text = "";
            }
        }
        // Đổ dữ liệu vào các labels
        load_data_2_basic_control();
    }

    #region Members
    US_V_GD_THANH_TOAN_DETAIL m_us_v_gd_thanh_toan_detail = new US_V_GD_THANH_TOAN_DETAIL();
    DS_V_GD_THANH_TOAN_DETAIL m_ds_v_gd_thanh_toan_detail = new DS_V_GD_THANH_TOAN_DETAIL();
    decimal m_dc_id_gd_thanh_toan = 0;
    #endregion

    #region Private Methods
    private void reset_control()
    {
        m_txt_so_luong_he_so.Text = "";
        m_txt_don_gia_hd.Text = "";
        m_cbo_noi_dung_tt.SelectedIndex = 0;
        m_txt_description.Text = "";
    }
    // Cái này chỉ cho load các nội dung phụ lục có trong hợp đồng
    private void load_2_cbo_noi_dung_tt(decimal ip_dc_id_hd)
    {
        US_V_GD_HOP_DONG_NOI_DUNG_TT v_us_phu_luc = new US_V_GD_HOP_DONG_NOI_DUNG_TT();
        DS_V_GD_HOP_DONG_NOI_DUNG_TT v_ds_phu_luc = new DS_V_GD_HOP_DONG_NOI_DUNG_TT();
        try
        {
            v_us_phu_luc.FillDataset(v_ds_phu_luc, " WHERE ID_HOP_DONG_KHUNG = " + ip_dc_id_hd);
            m_cbo_noi_dung_tt.DataSource = v_ds_phu_luc.V_GD_HOP_DONG_NOI_DUNG_TT;

            m_cbo_noi_dung_tt.DataValueField = V_GD_HOP_DONG_NOI_DUNG_TT.ID;
            m_cbo_noi_dung_tt.DataTextField = V_GD_HOP_DONG_NOI_DUNG_TT.NOI_DUNG_THANH_TOAN;

            m_cbo_noi_dung_tt.DataBind();
        }
        catch (Exception v_e)
        {

            throw v_e;
        }
    }

    private void form_2_us_object(US_V_GD_THANH_TOAN_DETAIL op_us_gd_thanh_toan_detail)
    {
        try
        {
            op_us_gd_thanh_toan_detail.dcID_NOI_DUNG_THANH_TOAN = CIPConvert.ToDecimal(m_cbo_noi_dung_tt.SelectedValue);
            op_us_gd_thanh_toan_detail.dcDON_GIA_TT = CIPConvert.ToDecimal(m_txt_don_gia_hd.Text.Trim());
            op_us_gd_thanh_toan_detail.dcSO_LUONG_HE_SO = CIPConvert.ToDecimal(m_txt_so_luong_he_so.Text.Trim());
            op_us_gd_thanh_toan_detail.dcID_GD_THANH_TOAN = CIPConvert.ToDecimal(Request.QueryString["id_gdtt"]);
            op_us_gd_thanh_toan_detail.strDESCRIPTION = m_txt_description.Text;
        }
        catch (Exception v_e)
        {

            throw v_e;
        }

    }

    private void us_object_2_form(US_V_GD_THANH_TOAN_DETAIL ip_us_gd_thanh_toan_detail)
    {
        try
        {
            m_txt_so_luong_he_so.Text = CIPConvert.ToStr(ip_us_gd_thanh_toan_detail.dcSO_LUONG_HE_SO, "0.0");
            m_txt_don_gia_hd.Text = CIPConvert.ToStr(ip_us_gd_thanh_toan_detail.dcDON_GIA_TT, "#,###");
            m_cbo_noi_dung_tt.SelectedValue = CIPConvert.ToStr(ip_us_gd_thanh_toan_detail.dcID_NOI_DUNG_THANH_TOAN);
            m_txt_description.Text = ip_us_gd_thanh_toan_detail.strDESCRIPTION;
        }
        catch (Exception v_e)
        {

            throw v_e;
        }

    }
    // Load data và hiển thị lên form
    private void load_data_2_us_by_id_and_show_on_form(int ip_i_detail_selected)
    {
        try
        {
            decimal v_dc_id_thanh_toan_detail = CIPConvert.ToDecimal(m_grv_gd_thanh_toan_detail.DataKeys[ip_i_detail_selected].Value);
            hdf_id_gv.Value = CIPConvert.ToStr(v_dc_id_thanh_toan_detail);
            US_V_GD_THANH_TOAN_DETAIL v_us_gd_thanh_toan_detail = new US_V_GD_THANH_TOAN_DETAIL(v_dc_id_thanh_toan_detail);

            // Load data to form 
            us_object_2_form(v_us_gd_thanh_toan_detail);
        }
        catch (Exception v_e)
        {

            throw v_e;
        }

    }
    private void delete_row_hop_dong_noi_dung_tt(int ip_i_id_detail_del)
    {
        decimal v_dc_id_thanh_toan_detail = CIPConvert.ToDecimal(m_grv_gd_thanh_toan_detail.DataKeys[ip_i_id_detail_del].Value);
        m_us_v_gd_thanh_toan_detail.dcID = v_dc_id_thanh_toan_detail;
        m_us_v_gd_thanh_toan_detail.DeleteByID(v_dc_id_thanh_toan_detail);
        m_lbl_thong_bao.Text = "Xóa bản ghi thành công";
        load_data_2_grid(CIPConvert.ToDecimal(Request.QueryString["id_gdtt"]));
    }
    // Load toàn bộ thanh toán detail của thanh toán đang xét
    private void load_data_2_grid(decimal ip_dc_id_thanh_toan)
    {
        try
        {
            m_us_v_gd_thanh_toan_detail.FillDataset(m_ds_v_gd_thanh_toan_detail, " WHERE ID_GD_THANH_TOAN= " + ip_dc_id_thanh_toan);

            // Nếu chưa có thanh toán detail nào ứng với thanh toán này(có thể do chưa làm detail nào)
            if (m_ds_v_gd_thanh_toan_detail.V_GD_THANH_TOAN_DETAIL.Rows.Count == 0)
            {
                // Nếu lý do chưa có là do bản chất chưa có phụ lục nào ứng với hợp đồng của thanh toán này thì hiển thị alert !
                if (m_cbo_noi_dung_tt.Items.Count == 0)
                {
                    string someScript;
                    someScript = "<script language='javascript'>alert('Không có nội dung thanh toán ứng với giao dịch thanh toán này!');</script>";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "onload", someScript);
                    // Ko cho phéo add thêm
                    m_cmd_luu_du_lieu.Enabled = false;
                }
                // Nếu chưa có gì thì ko cho cập nhật (chỉ cho add thêm)
                m_cmd_cap_nhat_pl.Enabled = false;
                m_grv_gd_thanh_toan_detail.Visible = false;
                m_grv_gd_thanh_toan_detail.DataSource = m_ds_v_gd_thanh_toan_detail.V_GD_THANH_TOAN_DETAIL;
                m_grv_gd_thanh_toan_detail.DataBind();
            }
            else
            {
                // Load to grid
                m_grv_gd_thanh_toan_detail.Visible = true;
                m_grv_gd_thanh_toan_detail.DataSource = m_ds_v_gd_thanh_toan_detail.V_GD_THANH_TOAN_DETAIL;
                m_grv_gd_thanh_toan_detail.DataBind();
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
            US_V_GD_THANH_TOAN v_us_gd_thanh_toan = new US_V_GD_THANH_TOAN(CIPConvert.ToDecimal(Request.QueryString["id_gdtt"]));
            if (!v_us_gd_thanh_toan.IsIDNull())
            {
                m_lbl_so_phieu_thanh_toan.Text = v_us_gd_thanh_toan.strSO_PHIEU_THANH_TOAN;
                m_lbl_so_hop_dong.Text =get_so_hop_dong_by_id(v_us_gd_thanh_toan.dcID_HOP_DONG_KHUNG);
                if (v_us_gd_thanh_toan.datNGAY_THANH_TOAN != null)
                    m_lbl_dat_ngay_thanh_toan.Text = CIPConvert.ToStr(v_us_gd_thanh_toan.datNGAY_THANH_TOAN, "dd/MM/yyyy");
                m_lbl_don_vi_thanh_toan.Text =get_dv_thanh_toan_by_id_hd(v_us_gd_thanh_toan.dcID_HOP_DONG_KHUNG);
            }
        }
        catch (Exception v_e)
        {

            throw v_e;
        }
    }
    /// <summary>
    /// Được dùng để kiểm tra thanh toán nay đã có tạm ứng hay chưa???
    /// Nếu đã  có tạm ứng thì ko cho nhập detail nữa, và chuyển về trang dự toán trước đó
    /// </summary>
    /// <param name="ip_dc_id_thanh_toan"></param>
    private bool check_tam_ung(decimal ip_dc_id_thanh_toan)
    {
        US_V_GD_THANH_TOAN v_us_gd_thanh_toan = new US_V_GD_THANH_TOAN(ip_dc_id_thanh_toan);
        // Nếu reference chứa từ đợt, nghĩa là có tạm ứng
        if (v_us_gd_thanh_toan.strREFERENCE_CODE.Contains("đợt"))
            // Nghĩa là đã có tạm ứng
            return true;
        return false;
    }
    private string get_dv_thanh_toan_by_id_hd(decimal ip_dc_hd_id)
    {
        try
        {
            US_V_DM_HOP_DONG_KHUNG v_us_dm_hop_dong_khung = new US_V_DM_HOP_DONG_KHUNG(ip_dc_hd_id);
            if (v_us_dm_hop_dong_khung.IsIDNull()) return "";
            US_DM_DON_VI_THANH_TOAN v_us_dv_thanh_toan = new US_DM_DON_VI_THANH_TOAN(v_us_dm_hop_dong_khung.dcID_DON_VI_THANH_TOAN);
            return v_us_dv_thanh_toan.strTEN_DON_VI;
        }
        catch (Exception v_e)
        {

            throw v_e;
        }
    }
    // Hàm này lấy được ID hợp đồng dựa vào ID GD_THANH_TOAN
    private decimal get_id_hop_dong_khung_by_id_gd_thanh_toan(decimal ip_dc_id_thanh_toan)
    {
        US_V_GD_THANH_TOAN v_us_v_gd_thanh_toan = new US_V_GD_THANH_TOAN(ip_dc_id_thanh_toan);
        return v_us_v_gd_thanh_toan.dcID_HOP_DONG_KHUNG;
    }
    // Lấy được i nội dung thanh toán từ id phụ lục đã biết
    private decimal get_id_noi_dung_tt_by_id_thanh_toan_detail(decimal ip_dc_id_thanh_toan_detail)
    {
        US_V_GD_THANH_TOAN_DETAIL v_us_gd_phu_luc = new US_V_GD_THANH_TOAN_DETAIL(ip_dc_id_thanh_toan_detail);
        if (v_us_gd_phu_luc.IsIDNull()) return 0;
        return v_us_gd_phu_luc.dcID_NOI_DUNG_THANH_TOAN;
    }
    private bool check_enough_noi_dung_tt(int ip_i_num_of_noi_dung_in_database)
    {
        // Nếu số lượng nhỏ hơn, nghĩa là chưa đủ, return false
        if (m_cbo_noi_dung_tt.Items.Count > ip_i_num_of_noi_dung_in_database) return false;
        // còn nếu đã đủ ròio thì return true
        return true;
    }
    private bool check_exist_noi_dung_tt(decimal ip_dc_id_noi_dung_tt)
    {
        for (int v_i = 0; v_i < m_grv_gd_thanh_toan_detail.Rows.Count; v_i++)
        {
            if (ip_dc_id_noi_dung_tt == get_id_noi_dung_tt_by_id_thanh_toan_detail(CIPConvert.ToDecimal(m_grv_gd_thanh_toan_detail.DataKeys[v_i].Value)))
                // True nghĩa là có tồn tại
                return true;
        }
        // false nghia là không tồn tại
        return false;
    }
    private void disable_controls()
    {
        m_cbo_noi_dung_tt.Enabled = false;
        m_txt_don_gia_hd.Enabled = false;
        m_txt_so_luong_he_so.Enabled = false;
        m_txt_description.Enabled = false;
        m_cmd_cap_nhat_pl.Enabled = false;
        m_cmd_luu_du_lieu.Enabled = false;
    }
    private void enable_controls()
    {
        m_cbo_noi_dung_tt.Enabled = true;
        m_txt_don_gia_hd.Enabled = true;
        m_txt_so_luong_he_so.Enabled = true;
        m_txt_description.Enabled = true;
    }
    #endregion

    #region Public Interfaces
    public string get_so_phieu_thanh_toan_by_id_gd_thanh_toan(decimal ip_dc_id_thanh_toan)
    {
        US_V_GD_THANH_TOAN v_us_v_gd_thanh_toan = new US_V_GD_THANH_TOAN(ip_dc_id_thanh_toan);
        return v_us_v_gd_thanh_toan.strSO_PHIEU_THANH_TOAN;
    }
    public string get_so_hop_dong_by_id(decimal ip_dc_hd_id)
    {
        try
        {
            US_V_DM_HOP_DONG_KHUNG v_us_dm_hop_dong_khung = new US_V_DM_HOP_DONG_KHUNG(ip_dc_hd_id);
            if (v_us_dm_hop_dong_khung.IsIDNull()) return "";
            return v_us_dm_hop_dong_khung.strSO_HOP_DONG;
        }
        catch (Exception v_e)
        {

            throw v_e;
        }
    }
    public string get_noi_dung_tt_by_id(decimal ip_dc_hd_tt_id)
    {
        US_V_GD_HOP_DONG_NOI_DUNG_TT v_us_gd_hop_dong_noi_dung_tt = new US_V_GD_HOP_DONG_NOI_DUNG_TT(ip_dc_hd_tt_id);
        if (v_us_gd_hop_dong_noi_dung_tt.IsIDNull()) return "";
        return v_us_gd_hop_dong_noi_dung_tt.strNOI_DUNG_THANH_TOAN;
    }
    #endregion

    #region Events
    protected void m_cmd_luu_du_lieu_Click(object sender, EventArgs e)
    {
        try
        {
            form_2_us_object(m_us_v_gd_thanh_toan_detail);
            // dcID_NOI_DUNG_TT này đc lấy từ bảng GD_HOP_DONG_NOI_DUNG_TT chứ ko phải bảng DM_NOI_DUNG_TT
            if (check_exist_noi_dung_tt(m_us_v_gd_thanh_toan_detail.dcID_NOI_DUNG_THANH_TOAN))
            {
                string someScript;
                someScript = "<script language='javascript'>alert('Nội dung thanh toán này đã tồn tại trong thanh toán này');</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "onload", someScript);
                return;
            }
            m_us_v_gd_thanh_toan_detail.Insert();
            m_lbl_thong_bao.Text = "Thêm bản ghi thành công";
            reset_control();
            //m_pnl_table.Visible = false;
            load_data_2_grid(CIPConvert.ToDecimal(Request.QueryString["id_gdtt"]));
            // Cho phép cập nhật trở lai
            m_cmd_cap_nhat_pl.Enabled = true;
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
                return;
            }
            form_2_us_object(m_us_v_gd_thanh_toan_detail);
            m_us_v_gd_thanh_toan_detail.dcID = CIPConvert.ToDecimal(hdf_id_gv.Value);
            m_us_v_gd_thanh_toan_detail.Update();
            m_lbl_thong_bao.Text = "Cập nhật bản ghi thành công";
            reset_control();
            //m_pnl_table.Visible = false;
            m_cmd_luu_du_lieu.Enabled = true;
            load_data_2_grid(CIPConvert.ToDecimal(Request.QueryString["id_gdtt"]));
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cmd_xoa_trang_Click(object sender, EventArgs e)
    {
        try
        {
            reset_control();
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
            Response.Redirect("/TRMProject/ChucNang/F501_DuToanHopDongVanHanh.aspx", false);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        catch (Exception v_e)
        {

            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_noi_dung_tt_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            decimal v_dc_id_hd_tt = CIPConvert.ToDecimal(m_cbo_noi_dung_tt.SelectedValue);
            US_V_GD_HOP_DONG_NOI_DUNG_TT v_us_dm_noi_dung_tt = new US_V_GD_HOP_DONG_NOI_DUNG_TT(v_dc_id_hd_tt);
            m_txt_don_gia_hd.Text = CIPConvert.ToStr(v_us_dm_noi_dung_tt.dcDON_GIA_HD, "#,#");
            m_txt_so_luong_he_so.Text = CIPConvert.ToStr(v_us_dm_noi_dung_tt.dcSO_LUONG_HE_SO, "#,#");
            m_lbl_don_vi_tinh.Text = v_us_dm_noi_dung_tt.strDON_VI_TINH;
            if (!v_us_dm_noi_dung_tt.IsTAN_SUATNull())
                m_lbl_tan_suat.Text = "Theo " + v_us_dm_noi_dung_tt.strTAN_SUAT;
            else m_lbl_tan_suat.Text = "";
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_grv_gd_thanh_toan_detail_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {
           // m_init_mode = DataEntryFormMode.UpdateDataState;
            m_cmd_luu_du_lieu.Enabled = false;
            m_cbo_noi_dung_tt.Enabled = false;
            m_cmd_cap_nhat_pl.Enabled = true;
            m_lbl_thong_bao.Text = "";
            load_data_2_us_by_id_and_show_on_form(e.NewSelectedIndex);
        }
        catch (Exception V_e)
        {
            CSystemLog_301.ExceptionHandle(this, V_e);
        }
    }
    protected void m_grv_gd_thanh_toan_detail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            m_lbl_thong_bao.Text = "";
            delete_row_hop_dong_noi_dung_tt(e.RowIndex);
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    #endregion
   
}