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

public partial class ChucNang_F407_LapDuToan : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //fill_data_2_thong_tin_hop_dong();
            //load_data_to_grid();
        }
    }

    #region Members
    US_V_DM_HOP_DONG_KHUNG m_us_dm_hop_dong_khung = new US_V_DM_HOP_DONG_KHUNG();
    DS_V_DM_HOP_DONG_KHUNG m_ds_hop_dong_khung = new DS_V_DM_HOP_DONG_KHUNG();

    US_CM_DM_TU_DIEN m_us_cm_dm_tu_dien = new US_CM_DM_TU_DIEN();
    DS_CM_DM_TU_DIEN m_ds_cm_dm_tu_dien = new DS_CM_DM_TU_DIEN();

    US_V_DM_GIANG_VIEN m_us_dm_giang_vien = new US_V_DM_GIANG_VIEN();
    DS_V_DM_GIANG_VIEN m_ds_dm_giang_vien = new DS_V_DM_GIANG_VIEN();
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
    private void fill_data_2_thong_tin_dot_tt(string ip_str_ma_dot)
    {
        if (get_id_dot_tt_by_ma_dot(ip_str_ma_dot) == 0)
        {
            string someScript;
            someScript = "<script language='javascript'>alert('Không có đợt thanh toán phù hợp');</script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "onload", someScript);
            return;
        }
        US_V_DM_DOT_THANH_TOAN v_us_dm_dot_thanh_toan = new US_V_DM_DOT_THANH_TOAN(get_id_dot_tt_by_ma_dot(ip_str_ma_dot));
        m_lbl_don_vi_thanh_toan.Text = v_us_dm_dot_thanh_toan.strDON_VI_THANH_TOAN;
        m_lbl_ma_dot_thanh_toan.Text = v_us_dm_dot_thanh_toan.strMA_DOT_TT;
        m_lbl_ngay_tt_du_kien.Text = CIPConvert.ToStr(v_us_dm_dot_thanh_toan.datNGAY_TT_DU_KIEN, "dd/MM/yyyy");
        m_lbl_ten_dot_thanh_toan.Text = v_us_dm_dot_thanh_toan.strTEN_DOT_TT;
        m_lbl_trang_thai_dot_tt.Text = v_us_dm_dot_thanh_toan.strTRANG_THAI_DOT_TT;
    }
    // Thông tin hợp đồng
    private void fill_data_2_thong_tin_hop_dong(string ip_str_ma_dot)
    {
        if (get_id_dot_tt_by_ma_dot(ip_str_ma_dot) == 0)
        {
            string someScript;
            someScript = "<script language='javascript'>alert('Không có đợt thanh toán phù hợp');</script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "onload", someScript);
            return;
        }
        US_V_DM_DOT_THANH_TOAN v_us_dm_dot_thanh_toan = new US_V_DM_DOT_THANH_TOAN(get_id_dot_tt_by_ma_dot(ip_str_ma_dot));
        m_lbl_don_vi_thanh_toan.Text = v_us_dm_dot_thanh_toan.strDON_VI_THANH_TOAN;
        m_lbl_ma_dot_thanh_toan.Text = v_us_dm_dot_thanh_toan.strMA_DOT_TT;
        m_lbl_ngay_tt_du_kien.Text = CIPConvert.ToStr(v_us_dm_dot_thanh_toan.datNGAY_TT_DU_KIEN, "dd/MM/yyyy");
        m_lbl_ten_dot_thanh_toan.Text = v_us_dm_dot_thanh_toan.strTEN_DOT_TT;
        m_lbl_trang_thai_dot_tt.Text = v_us_dm_dot_thanh_toan.strTRANG_THAI_DOT_TT;
    }
    private void load_data_to_grid()
    {

        try
        {
            
            m_lbl_loc_du_lieu.Text = "Danh sách Hợp đồng cần lập dự toán: " + m_ds_hop_dong_khung.V_DM_HOP_DONG_KHUNG.Rows.Count + " hợp đồng";
            if (m_ds_hop_dong_khung.V_DM_HOP_DONG_KHUNG.Rows.Count == 0)
            {
                m_lbl_thong_bao.Text = "Không có bản ghi nào phù hợp";
                if (m_grv_dm_danh_sach_hop_dong_khung.Visible == true) m_grv_dm_danh_sach_hop_dong_khung.Visible = false;
                return;
            }
            m_lbl_thong_bao.Visible = false;
            m_grv_dm_danh_sach_hop_dong_khung.Visible = true;
            m_grv_dm_danh_sach_hop_dong_khung.DataSource = m_ds_hop_dong_khung.V_DM_HOP_DONG_KHUNG;

            m_grv_dm_danh_sach_hop_dong_khung.DataBind();
        }

        catch (Exception v_e)
        {
            throw v_e;

        }

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
  
    #endregion
}