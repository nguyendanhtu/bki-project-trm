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

public partial class ChucNang_F408_XacNhanToanBoNganHang : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        m_lbl_thong_bao1.Text = "";
        if (!IsPostBack)
        {
            load_data_2_dot_tt();
            string v_str_ma_dot = m_cbo_dot_thanh_toan.SelectedValue;
            if (m_cbo_dot_thanh_toan.Items.Count > 0)
            {
                fill_data_2_thong_tin_dot_tt(CIPConvert.ToDecimal(m_cbo_dot_thanh_toan.SelectedValue));
                m_cmd_xac_nhan_tat_ca_ngan_hang.Enabled = true;
            }
            else
            {
                m_lbl_thong_bao1.Text = "Chưa có đợt thanh toán nào";
                m_cmd_xac_nhan_tat_ca_ngan_hang.Enabled = false;
            }
        }
    }

    #region Members
    US_V_GD_THANH_TOAN m_us_gd_thanh_toan = new US_V_GD_THANH_TOAN();
    DS_V_GD_THANH_TOAN m_ds_gd_thanh_toan = new DS_V_GD_THANH_TOAN();

    US_V_DM_DOT_THANH_TOAN m_us_dm_dot_thanh_toan = new US_V_DM_DOT_THANH_TOAN();
    DS_V_DM_DOT_THANH_TOAN m_ds_dm_dot_thanh_toan = new DS_V_DM_DOT_THANH_TOAN();

    US_CM_DM_TU_DIEN m_us_cm_dm_tu_dien = new US_CM_DM_TU_DIEN();
    DS_CM_DM_TU_DIEN m_ds_cm_dm_tu_dien = new DS_CM_DM_TU_DIEN();
    public string m_str_ma_dot;
    #endregion

    #region Public Interfaces
    public string mapping_hl(string ip_str_hl_YN)
    {
        if (ip_str_hl_YN.Equals("Y"))
            return "Có";
        return "Không";
    }
    public string mapping_vh(string ip_str_vh_YN)
    {
        if (ip_str_vh_YN.Equals("Y"))
            return "Có";
        return "Không";
    }
    public string mapping_cs(string ip_str_cs_YN)
    {
        if (ip_str_cs_YN.Equals("Y"))
            return "Có";
        return "Không";
    }
    public string get_ma_gv_form_id(decimal ip_dc_id)
    {
        try
        {
            US_V_DM_GIANG_VIEN v_us_dm_giang_vien = new US_V_DM_GIANG_VIEN();
            DS_V_DM_GIANG_VIEN v_ds_dm_gv = new DS_V_DM_GIANG_VIEN();

            v_us_dm_giang_vien.FillDataset(v_ds_dm_gv, " WHERE ID=" + ip_dc_id);
            return v_ds_dm_gv.V_DM_GIANG_VIEN.Rows[0][V_DM_GIANG_VIEN.MA_GIANG_VIEN].ToString();
        }
        catch (Exception v_e)
        {

            throw v_e;
        }

    }
    public string get_so_hd_khung_by_id_hd(decimal ip_dc_so_hd)
    {
        DS_V_DM_HOP_DONG_KHUNG v_ds_hd_khung = new DS_V_DM_HOP_DONG_KHUNG();
        US_V_DM_HOP_DONG_KHUNG v_us_hd_khung = new US_V_DM_HOP_DONG_KHUNG();
        v_us_hd_khung.FillDataset(v_ds_hd_khung, " WHERE  ID = " + ip_dc_so_hd);
        if (v_ds_hd_khung.V_DM_HOP_DONG_KHUNG.Rows.Count == 0) return "";
        return CIPConvert.ToStr(v_ds_hd_khung.V_DM_HOP_DONG_KHUNG.Rows[0][V_DM_HOP_DONG_KHUNG.SO_HOP_DONG]);
    }
    #endregion

    #region Private Methods
    private decimal get_id_dot_tt_by_ma_dot(string ip_str_ma_dot)
    {
        DS_V_DM_DOT_THANH_TOAN v_ds_dot_tt = new DS_V_DM_DOT_THANH_TOAN();
        US_V_DM_DOT_THANH_TOAN v_us_dot_thanh_toan = new US_V_DM_DOT_THANH_TOAN();
        v_us_dot_thanh_toan.FillDataset(v_ds_dot_tt, " WHERE MA_DOT_TT = '" + ip_str_ma_dot + "'");
        if (v_ds_dot_tt.V_DM_DOT_THANH_TOAN.Rows.Count == 0) return 0;
        return CIPConvert.ToDecimal(v_ds_dot_tt.V_DM_DOT_THANH_TOAN.Rows[0][V_DM_DOT_THANH_TOAN.ID]);
    }

    // Thông tin đợt thanh toán
    private void fill_data_2_thong_tin_dot_tt(decimal ip_dc_id_dot)
    {
        US_V_DM_DOT_THANH_TOAN v_us_dm_dot_thanh_toan = new US_V_DM_DOT_THANH_TOAN(ip_dc_id_dot);
        m_lbl_don_vi_thanh_toan.Text = v_us_dm_dot_thanh_toan.strDON_VI_THANH_TOAN;
        m_lbl_ngay_tt_du_kien.Text = CIPConvert.ToStr(v_us_dm_dot_thanh_toan.datNGAY_TT_DU_KIEN, "dd/MM/yyyy");
        m_lbl_trang_thai_dot_tt.Text = v_us_dm_dot_thanh_toan.strTRANG_THAI_DOT_TT;

        // Hiển thị lên lưới các bản kê trong đợt
        // search_data_and_load_to_grid(get_ma_dot_tt_form_id(CIPConvert.ToDecimal(m_cbo_dot_thanh_toan.SelectedValue)));
    }
    // Chỉ load lên những đợt thanh toán đang ở trạng thái 1 - đã lập đợt
    private void load_data_2_dot_tt()
    {
        DS_V_DM_DOT_THANH_TOAN v_ds_dot_thanh_toan = new DS_V_DM_DOT_THANH_TOAN();
        US_V_DM_DOT_THANH_TOAN v_us_dot_thanh_toan = new US_V_DM_DOT_THANH_TOAN();
        v_us_dot_thanh_toan.load_dot_thanh_toan_by_trang_thai(ID_TRANG_THAI_DOT_TT.DA_LAP_BANG_KE_XONG,v_ds_dot_thanh_toan);
        //v_us_dot_thanh_toan.FillDataset(v_ds_dot_thanh_toan, " WHERE ID_TRANG_THAI_DOT_TT = " + get_id_trang_thai_dot_tt_da_lap_bang_ke());
        m_cbo_dot_thanh_toan.DataTextField = V_DM_DOT_THANH_TOAN.TEN_DOT_TT;
        m_cbo_dot_thanh_toan.DataValueField = V_DM_DOT_THANH_TOAN.ID;
        m_cbo_dot_thanh_toan.DataSource = v_ds_dot_thanh_toan.V_DM_DOT_THANH_TOAN;
        m_cbo_dot_thanh_toan.DataBind();
    }
    private decimal get_id_trang_thai_dot_tt_da_lap_dot()
    {
        US_CM_DM_TU_DIEN v_us_cm_tu_dien = new US_CM_DM_TU_DIEN();
        DS_CM_DM_TU_DIEN v_ds_tu_dien = new DS_CM_DM_TU_DIEN();
        v_us_cm_tu_dien.FillDataset(v_ds_tu_dien, " WHERE ID_LOAI_TU_DIEN = 14 AND MA_TU_DIEN LIKE N'%DA_LAP_DOT%'");
        if (v_ds_tu_dien.CM_DM_TU_DIEN.Rows.Count == 0) return 503;
        return CIPConvert.ToDecimal(v_ds_tu_dien.CM_DM_TU_DIEN.Rows[0][CM_DM_TU_DIEN.ID]);
    }

    private decimal get_id_trang_thai_dot_tt_da_lap_bang_ke()
    {
        US_CM_DM_TU_DIEN v_us_cm_tu_dien = new US_CM_DM_TU_DIEN();
        DS_CM_DM_TU_DIEN v_ds_tu_dien = new DS_CM_DM_TU_DIEN();
        v_us_cm_tu_dien.FillDataset(v_ds_tu_dien, " WHERE ID_LOAI_TU_DIEN = 14 AND MA_TU_DIEN LIKE N'%DA_LAP_BANG_KE%'");
        if (v_ds_tu_dien.CM_DM_TU_DIEN.Rows.Count == 0) return 504;
        return CIPConvert.ToDecimal(v_ds_tu_dien.CM_DM_TU_DIEN.Rows[0][CM_DM_TU_DIEN.ID]);
    }
    /// <summary>
    /// Xóa các khoảng trắng, chuyển về một dạng chuẩn "Đinh Hồng Lĩnh"
    /// </summary>
    /// <param name="ip_str_name_search"></param>
    /// <returns></returns>
    private string Process_name_search(string ip_str_name_search)
    {
        while (ip_str_name_search.Contains("  "))
        {
            ip_str_name_search = ip_str_name_search.Replace("  ", " ");
        }
        return ip_str_name_search;
    }
    private void search_data_and_load_to_grid(string ip_str_so_phieu_tt)
    {
        try
        {
            m_lbl_loc_du_lieu.Text = "Danh sách bản kê các khoản thanh toán : " + m_ds_gd_thanh_toan.V_GD_THANH_TOAN.Rows.Count + " hợp đồng";
            m_us_gd_thanh_toan.FillDataset(m_ds_gd_thanh_toan, " WHERE SO_PHIEU_THANH_TOAN='" + ip_str_so_phieu_tt + "'");
            if (m_ds_gd_thanh_toan.V_GD_THANH_TOAN.Rows.Count == 0)
            {
                if (m_grv_danh_sach_du_toan.Visible == true) m_grv_danh_sach_du_toan.Visible = false;
                return;
            }
            m_grv_danh_sach_du_toan.Visible = true;
            m_grv_danh_sach_du_toan.DataSource = m_ds_gd_thanh_toan.V_GD_THANH_TOAN;
            m_grv_danh_sach_du_toan.DataBind();
        }
        catch (Exception v_e)
        {
            throw v_e;

        }

    }
    public string get_ma_dot_tt_form_id(decimal ip_dc_id_dot)
    {
        US_V_DM_DOT_THANH_TOAN v_us_v_dm_dot_tt = new US_V_DM_DOT_THANH_TOAN();
        DS_V_DM_DOT_THANH_TOAN v_ds_v_dm_dot_tt = new DS_V_DM_DOT_THANH_TOAN();

        v_us_v_dm_dot_tt.FillDataset(v_ds_v_dm_dot_tt, " WHERE ID=" + ip_dc_id_dot);
        return v_ds_v_dm_dot_tt.V_DM_DOT_THANH_TOAN.Rows[0][V_DM_DOT_THANH_TOAN.MA_DOT_TT].ToString();
    }
    private string convert_2_str(object ip_o_obj)
    {
        if (ip_o_obj == DBNull.Value)
            return "";
        return CIPConvert.ToStr(ip_o_obj);
    }
    private string convert_so_tien_2_str(object ip_o_obj)
    {
        if (ip_o_obj == DBNull.Value)
            return "";
        return CIPConvert.ToStr(ip_o_obj, "0");
    }
    private string convert_datetime_2_str(object ip_o_obj)
    {
        if (ip_o_obj == DBNull.Value)
            return "";
        return CIPConvert.ToStr(ip_o_obj, "dd/MM/yyyy");
    }
    public string mapping_YN(string ip_str_YN)
    {
        if (ip_str_YN.Equals("Y"))
            return "Có";
        return "Không";
    }
    #endregion

    #region Events
    protected void m_cmd_xac_nhan_tat_ca_ngan_hang_Click(object sender, EventArgs e)
    {
        try
        {
            // Chuyển trạng thái của đợt thanh toán từ 1 sang 2
            // và chuyển tất cả trạng thái của thanh toán trong đợt thanh toán này từ 1 -> 2
            m_us_dm_dot_thanh_toan.strMA_DOT_TT = get_ma_dot_tt_form_id(CIPConvert.ToDecimal(m_cbo_dot_thanh_toan.SelectedValue));
            m_us_dm_dot_thanh_toan.xac_nhan_toan_bo_ngan_hang();
            string someScript;
            someScript = "<script language='javascript'>alert('Toàn bộ chứng từ trong đợt thanh toán này đã được duyệt!');</script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "onsuccess", someScript);
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
            Response.Redirect("/TRMProject/Default.aspx", false);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_dot_thanh_toan_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            fill_data_2_thong_tin_dot_tt(CIPConvert.ToDecimal(m_cbo_dot_thanh_toan.SelectedValue));
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    #endregion
   
}