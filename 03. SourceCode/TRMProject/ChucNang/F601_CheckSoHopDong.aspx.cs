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

public partial class ChucNang_F601_CheckSoHopDong : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            m_lbl_thong_bao.Text = "";
            string v_str_so_hd, v_str_loai_hd;
            if (Request.QueryString["sohd"] != null)
            {
                v_str_so_hd = CIPConvert.ToStr(Request.QueryString["sohd"]);
                v_str_loai_hd = CIPConvert.ToStr(Request.QueryString["loai"]);
                if (v_str_so_hd.Equals(""))
                {
                    string someScript;
                    someScript = "<script language='javascript'>{ alert('Bạn chưa nhập số hợp đồng'); window.close(); }</script>";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "onload", someScript);
                    return;
                }
                m_lbl_so_hd.Text = v_str_so_hd;

                US_V_DM_HOP_DONG_KHUNG v_us_hop_dong_khung = new US_V_DM_HOP_DONG_KHUNG();
                DS_V_DM_HOP_DONG_KHUNG v_ds_hop_dong_khung = new DS_V_DM_HOP_DONG_KHUNG();

                v_us_hop_dong_khung.FillDataset(v_ds_hop_dong_khung, " WHERE SO_HOP_DONG = N'" + v_str_so_hd + "'");
                if (v_ds_hop_dong_khung.V_DM_HOP_DONG_KHUNG.Rows.Count == 0)
                {
                    string someScript;
                    someScript = "<script language='javascript'>{ alert('Không có hợp đồng nào phù hợp!'); window.close(); }</script>";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "onload", someScript);
                    return;
                }
                if (v_str_loai_hd.Equals("VH"))
                {
                    // nhưng số hợp đồng nhập vào lại của hợp đồng học liệu
                    if (CIPConvert.ToStr(v_ds_hop_dong_khung.V_DM_HOP_DONG_KHUNG.Rows[0][V_DM_HOP_DONG_KHUNG.HOC_LIEU_YN]).Equals("Y"))
                    {
                        m_lbl_thong_bao.Text = "";
                        string someScript;
                        someScript = "<script language='javascript'>{ alert('Ta đang dự toán cho hợp đồng vận hành. Hợp đồng nhập vào là hợp đông học liệu'); window.close(); }</script>";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "onload", someScript);
                        return;
                    }
                }
                // Nếu là HĐ học liệu
                else
                {
                    // nhưng số hợp đồng nhập vào lại của hợp đồng vận hành
                    if (CIPConvert.ToStr(v_ds_hop_dong_khung.V_DM_HOP_DONG_KHUNG.Rows[0][V_DM_HOP_DONG_KHUNG.VAN_HANH_YN]).Equals("Y"))
                    {
                        m_lbl_thong_bao.Text = "";
                        string someScript;
                        someScript = "<script language='javascript'>{ alert('Ta đang dự toán cho hợp đồng học liệu. Hợp đồng nhập vào là hợp đông vận hành'); window.close(); }</script>";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "onload", someScript);
                        return;
                    }
                }

                // Chỗ này kiểm tra xem có hợp đồng nào trùng với hợp đồng đang xét đến ko?
                if (!check_trung_hop_dong(v_str_so_hd))
                {
                    string someScript;
                    someScript = "<script language='javascript'>{ alert('Tồn tại số hợp đồng trùng với số hợp đồng này. Hãy xử lý trước khi lên bảng kê cho hợp đồng này!');}</script>";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "onload", someScript);
                    m_grv_dm_danh_sach_hop_dong_khung.DataSource = m_ds_hop_dong_khung.V_DM_HOP_DONG_KHUNG;
                    m_grv_dm_danh_sach_hop_dong_khung.DataBind();
                    return;
                }
                kiem_tra_toan_bo_thanh_toan_ung_hop_dong(get_id_hd_khung_by_so_hd(v_str_so_hd),v_str_loai_hd);
                // Đoạn này đã lấy được số hợp đồng, search và đổ lên lưới
                m_grv_dm_danh_sach_hop_dong_khung.DataSource = v_ds_hop_dong_khung.V_DM_HOP_DONG_KHUNG;
                m_grv_dm_danh_sach_hop_dong_khung.DataBind();
            }

        }
    }

    #region Members
    US_V_DM_HOP_DONG_KHUNG m_us_hop_dong_khung = new US_V_DM_HOP_DONG_KHUNG();
    DS_V_DM_HOP_DONG_KHUNG m_ds_hop_dong_khung = new DS_V_DM_HOP_DONG_KHUNG();
    #endregion

    #region Private Methods
    private string cut_end_string(string ip_str_string)
    {
        return ip_str_string.Substring(ip_str_string.Trim().Length - 1, 1);
    }
    private void load_data_2_grid(string ip_str_ma_hop_dong)
    {
        US_V_DM_HOP_DONG_KHUNG v_us_hop_dong_khung = new US_V_DM_HOP_DONG_KHUNG();
        DS_V_DM_HOP_DONG_KHUNG v_ds_hop_dong_khung = new DS_V_DM_HOP_DONG_KHUNG();

        v_us_hop_dong_khung.FillDataset(v_ds_hop_dong_khung, " WHERE SO_HOP_DONG = N'"+ip_str_ma_hop_dong+"'");
        if (v_ds_hop_dong_khung.V_DM_HOP_DONG_KHUNG.Rows.Count == 0)
        {
            string someScript;
            someScript = "<script language='javascript'>{ alert('Không có hợp đồng nào phù hợp!'); window.close(); }</script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "onload", someScript);
            return;
        }
        m_grv_dm_danh_sach_hop_dong_khung.DataSource = v_ds_hop_dong_khung.V_DM_HOP_DONG_KHUNG;
        m_grv_dm_danh_sach_hop_dong_khung.DataBind();
    }
    private decimal get_id_hd_khung_by_so_hd(string ip_str_so_hd)
    {
        DS_V_DM_HOP_DONG_KHUNG v_ds_hd_khung = new DS_V_DM_HOP_DONG_KHUNG();
        US_V_DM_HOP_DONG_KHUNG v_us_hd_khung = new US_V_DM_HOP_DONG_KHUNG();
        v_us_hd_khung.FillDataset(v_ds_hd_khung, " WHERE  SO_HOP_DONG = N'" + ip_str_so_hd + "'");
        if (v_ds_hd_khung.V_DM_HOP_DONG_KHUNG.Rows.Count == 0) return 0;
        return CIPConvert.ToDecimal(v_ds_hd_khung.V_DM_HOP_DONG_KHUNG.Rows[0][V_DM_HOP_DONG_KHUNG.ID]);
    }
    private void kiem_tra_toan_bo_thanh_toan_ung_hop_dong(decimal ip_dc_id_hop_dong_khung,string ip_str_loai_hd)
    {
        US_V_GD_THANH_TOAN v_us_v_gd_tt = new US_V_GD_THANH_TOAN();
        DS_V_GD_THANH_TOAN v_ds_v_gd_tt = new DS_V_GD_THANH_TOAN();
        // lấy toàn bộ thanh toán của hợp đồng theo id_hop_dong
        v_us_v_gd_tt.f601_load_thanh_toan_theo_hop_dong_de_kiem_tra(ip_dc_id_hop_dong_khung, v_ds_v_gd_tt);
        // Nếu đã có thanh toán
        if (v_ds_v_gd_tt.V_GD_THANH_TOAN.Rows.Count > 0)
        // kiểm tra xem đã thanh lý chưa
            // Sử dụng dòng cuối cùng, ứng với thanh toán cuối cùng của hd này
            // Nếu đã thanh lý, reference_code là null
            if (v_ds_v_gd_tt.V_GD_THANH_TOAN.Rows[v_ds_v_gd_tt.V_GD_THANH_TOAN.Rows.Count - 1][V_GD_THANH_TOAN.REFERENCE_CODE].GetType()== typeof(DBNull))
            {
                string someScript;
                someScript = "<script language='javascript'>{ alert('Hợp đồng này đã được thanh lý!'); window.close(); }</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "oncheck", someScript);
                return;
            }            
            // Nếu ko phải thanh lý mà là tạm ứng, kiểm tra số lần tạm ứng
            else
            {
               
                decimal v_dc_so_tien_da_tt = 0;
                if (ip_str_loai_hd.Equals("HL"))
                {
                    v_dc_so_tien_da_tt += CIPConvert.ToDecimal(v_ds_v_gd_tt.V_GD_THANH_TOAN.Rows[v_ds_v_gd_tt.V_GD_THANH_TOAN.Rows.Count - 1][V_GD_THANH_TOAN.DA_THANH_TOAN]) + CIPConvert.ToDecimal(v_ds_v_gd_tt.V_GD_THANH_TOAN.Rows[v_ds_v_gd_tt.V_GD_THANH_TOAN.Rows.Count - 1][V_GD_THANH_TOAN.TONG_TIEN_THANH_TOAN]);
                    string v_str_so_lan_tam_ung = cut_end_string(CIPConvert.ToStr(v_ds_v_gd_tt.V_GD_THANH_TOAN.Rows[v_ds_v_gd_tt.V_GD_THANH_TOAN.Rows.Count - 1][V_GD_THANH_TOAN.REFERENCE_CODE]));
                    m_lbl_thong_bao.Text = "Hợp đồng này đã được tạm ứng " + v_str_so_lan_tam_ung + " lần. Số tiền đã thanh toán là: " + CIPConvert.ToStr(v_dc_so_tien_da_tt, "#,###");
                }
                else // Vận hành
                {
                    for (int v_i = 0; v_i < v_ds_v_gd_tt.V_GD_THANH_TOAN.Rows.Count; v_i++)
                    {
                        v_dc_so_tien_da_tt += CIPConvert.ToDecimal(v_ds_v_gd_tt.V_GD_THANH_TOAN.Rows[v_i][V_GD_THANH_TOAN.TONG_TIEN_THANH_TOAN]);
                    }
                    
                    m_lbl_thong_bao.Text = "Số tiền đã thanh toán: " + CIPConvert.ToStr(v_dc_so_tien_da_tt, "#,###");
                }
            }
         // Nếu số dòng ==0 nghĩa là chưa có thanh toán nào, ko thực hiện gì
    }
    private bool check_trung_hop_dong(string ip_str_so_hd)
    {
        m_us_hop_dong_khung.FillDataset(m_ds_hop_dong_khung, " WHERE SO_HOP_DONG = N'" + ip_str_so_hd + "'");
        if (m_ds_hop_dong_khung.V_DM_HOP_DONG_KHUNG.Rows.Count > 1) return false; // có hợp đồng trùng
        return true;
    }
    #endregion

    #region Public Interfaces
    public string mapping_cs(string ip_str_cs_YN)
    {
        if (ip_str_cs_YN.Equals("Y"))
            return "Có";
        return "Không";
    } 
    #endregion
}