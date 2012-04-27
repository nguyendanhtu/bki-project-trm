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

public partial class ChucNang_F605_CheckMaLopMon : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            m_lbl_thong_bao.Text = "";
            string v_str_so_hd, v_str_ma_lop_mon;
            if (Request.QueryString["sohd"] != null)
            {
                v_str_so_hd = CIPConvert.ToStr(Request.QueryString["sohd"]);
                v_str_ma_lop_mon = CIPConvert.ToStr(Request.QueryString["malop"]);
               // Kiểm tra bỏ trống
                if (v_str_so_hd.Equals(""))
                {
                    string someScript;
                    someScript = "<script language='javascript'>{ alert('Bạn chưa nhập số hợp đồng'); window.close(); }</script>";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "onload", someScript);
                    return;
                }
                if (v_str_ma_lop_mon.Equals(""))
                {
                    string soScript;
                    soScript = "<script language='javascript'>{ alert('Bạn chưa nhập mã lớp môn'); window.close(); }</script>";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "onload", soScript);
                    return;
                }

                // Check tồn tại
                //if (!check_exist_ma_mon(v_str_ma_lop_mon))
                //{
                //    string script;
                //    script = "<script language='javascript'>alert('Lớp môn này không tồn tại trong hệ thống')</script>";
                //    Page.ClientScript.RegisterStartupScript(this.GetType(), "oncheckmalop", script);
                //    return;
                //}
                // Hiển thị lên labels
                m_lbl_so_hd.Text = v_str_so_hd;
                m_lbl_ma_lop_mon.Text= v_str_ma_lop_mon;

                decimal ip_dc_d_hop_dong = get_id_hd_khung_by_so_hd(v_str_so_hd);

                // Kiểm tra hợp đồng khung và lớp môn là 1 cặp
                //if (!check_tuong_ung_lop_mon_hop_dong(ip_dc_d_hop_dong, v_str_ma_lop_mon))
                //{
                //    string scriptalert;
                //    scriptalert = "<script language='javascript'>alert('Lớp môn và hợp đồng không tương ứng với nhau')</script>";
                //    Page.ClientScript.RegisterStartupScript(this.GetType(), "onchecktuongung", scriptalert);
                //    return;
                //}
                // Đoạn này đã lấy được số hợp đồng, mã lớp môn, search và đổ lên lưới 
                //(hiển thị lịch sử thanh toán của hợp đồng ứng với mã lớp môn này
                load_data_2_grid_lich_su(ip_dc_d_hop_dong, v_str_ma_lop_mon);
            }

        }
    }

    #region Members

    #endregion

    #region Private Methods
    private string cut_end_string(string ip_str_string)
    {
        return ip_str_string.Substring(ip_str_string.Trim().Length - 1, 1);
    }
    private void load_data_2_grid_lich_su(decimal ip_dc_id_hop_dong, string ip_str_ma_lop_mon)
    {
        US_V_GD_THANH_TOAN v_us_gd_thanh_toan = new US_V_GD_THANH_TOAN();
        DS_V_GD_THANH_TOAN v_ds_gd_thanh_toan = new DS_V_GD_THANH_TOAN();

        v_us_gd_thanh_toan.FillDataset(v_ds_gd_thanh_toan, " WHERE ID_HOP_DONG_KHUNG ="+ip_dc_id_hop_dong+" AND REFERENCE_CODE = '" + ip_str_ma_lop_mon + "'");
        if (v_ds_gd_thanh_toan.V_GD_THANH_TOAN.Rows.Count == 0)
        {
            m_lbl_thong_bao.Text = "Chưa có thanh toán nào ứng với lớp môn và hợp đồng này";
            return;
        }
        m_grv_dm_danh_sach_hop_dong_khung.DataSource = v_ds_gd_thanh_toan.V_GD_THANH_TOAN;
        m_grv_dm_danh_sach_hop_dong_khung.DataBind();
        if (v_ds_gd_thanh_toan.V_GD_THANH_TOAN.Rows.Count > 0)
        {
            decimal v_dc_sum = 0;
            for (int i = 0; i < v_ds_gd_thanh_toan.V_GD_THANH_TOAN.Rows.Count; i++)
            {
                v_dc_sum += CIPConvert.ToDecimal(v_ds_gd_thanh_toan.V_GD_THANH_TOAN.Rows[i][V_GD_THANH_TOAN.TONG_TIEN_THANH_TOAN]);
            }
            //string v_str_da_tt =
            m_grv_dm_danh_sach_hop_dong_khung.FooterRow.Cells[8].Text = CIPConvert.ToStr(v_dc_sum, "#,###");
        }
    }
    private decimal get_id_hd_khung_by_so_hd(string ip_str_so_hd)
    {
        DS_V_DM_HOP_DONG_KHUNG v_ds_hd_khung = new DS_V_DM_HOP_DONG_KHUNG();
        US_V_DM_HOP_DONG_KHUNG v_us_hd_khung = new US_V_DM_HOP_DONG_KHUNG();
        v_us_hd_khung.FillDataset(v_ds_hd_khung, " WHERE  SO_HOP_DONG = N'" + ip_str_so_hd + "'");
        if (v_ds_hd_khung.V_DM_HOP_DONG_KHUNG.Rows.Count == 0) return 0;
        return CIPConvert.ToDecimal(v_ds_hd_khung.V_DM_HOP_DONG_KHUNG.Rows[0][V_DM_HOP_DONG_KHUNG.ID]);
    }
    private decimal get_id_lop_mon_by_ma_lop_mon(string ip_str_ma_lop_mon)
    {
        DS_GD_LOP_MON v_ds_lop_mon = new DS_GD_LOP_MON();
        US_GD_LOP_MON v_us_lop_mon = new US_GD_LOP_MON();
        v_us_lop_mon.FillDataset(v_ds_lop_mon, " WHERE MA_LOP_MON = N'" + ip_str_ma_lop_mon + "'");
        if (v_ds_lop_mon.GD_LOP_MON.Rows.Count == 0) return 0;
        return CIPConvert.ToDecimal(v_ds_lop_mon.GD_LOP_MON.Rows[0][GD_LOP_MON.ID]);
    }
    private bool check_tuong_ung_lop_mon_hop_dong(decimal ip_dc_id_hop_dong,string ip_str_ma_lop_mon)
    {
        US_GD_LOP_MON_DETAIL v_us_gd_lop_mon_detail = new US_GD_LOP_MON_DETAIL();
        DS_GD_LOP_MON_DETAIL v_ds_gd_lop_mon_detail = new DS_GD_LOP_MON_DETAIL();
        decimal v_dc_id_lop_mon = get_id_lop_mon_by_ma_lop_mon(ip_str_ma_lop_mon);
        v_us_gd_lop_mon_detail.FillDataset(v_ds_gd_lop_mon_detail, " WHERE ID_HOP_DONG_KHUNG = " + ip_dc_id_hop_dong + " AND ID_LOP_MON=" + v_dc_id_lop_mon);
        if (v_ds_gd_lop_mon_detail.GD_LOP_MON_DETAIL.Rows.Count == 0)
            return false; // Nghĩa là không tương ứng
        return true; // Nghĩa là tương ứng (hay chúng là 1 cặp)
    }
    // Hàm này kiểm tra
    // - Lớp môn có ứng với hợp đồng không?
    private void kiem_tra_toan_bo_thanh_toan_ung_hop_dong(decimal ip_dc_id_hop_dong_khung, string ip_str_ma_lop_mon)
    {
        US_V_GD_THANH_TOAN v_us_v_gd_tt = new US_V_GD_THANH_TOAN();
        DS_V_GD_THANH_TOAN v_ds_v_gd_tt = new DS_V_GD_THANH_TOAN();
        // lấy toàn bộ thanh toán của hợp đồng theo id_hop_dong
        v_us_v_gd_tt.FillDataset(v_ds_v_gd_tt, " WHERE ID_HOP_DONG_KHUNG=" + ip_dc_id_hop_dong_khung + " ORDER BY ID");
        // Nếu đã có thanh toán
        if (v_ds_v_gd_tt.V_GD_THANH_TOAN.Rows.Count > 0)
            // kiểm tra xem đã thanh lý chưa
            // Sử dụng dòng cuối cùng, ứng với thanh toán cuối cùng của hd này
            // Nếu đã thanh lý, reference_code là null
            if (v_ds_v_gd_tt.V_GD_THANH_TOAN.Rows[v_ds_v_gd_tt.V_GD_THANH_TOAN.Rows.Count - 1][V_GD_THANH_TOAN.REFERENCE_CODE].GetType() == typeof(DBNull))
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
                string v_str_so_lan_tam_ung = cut_end_string(CIPConvert.ToStr(v_ds_v_gd_tt.V_GD_THANH_TOAN.Rows[v_ds_v_gd_tt.V_GD_THANH_TOAN.Rows.Count - 1][V_GD_THANH_TOAN.REFERENCE_CODE]));
                v_dc_so_tien_da_tt += CIPConvert.ToDecimal(v_ds_v_gd_tt.V_GD_THANH_TOAN.Rows[v_ds_v_gd_tt.V_GD_THANH_TOAN.Rows.Count - 1][V_GD_THANH_TOAN.DA_THANH_TOAN]) + CIPConvert.ToDecimal(v_ds_v_gd_tt.V_GD_THANH_TOAN.Rows[v_ds_v_gd_tt.V_GD_THANH_TOAN.Rows.Count - 1][V_GD_THANH_TOAN.TONG_TIEN_THANH_TOAN]);
                m_lbl_thong_bao.Text = "Hợp đồng này đã được tạm ứng " + v_str_so_lan_tam_ung + " lần. Số tiền đã thanh toán là: " + CIPConvert.ToStr(v_dc_so_tien_da_tt, "#,###");
            }
        // Nếu số dòng ==0 nghĩa là chưa có thanh toán nào, ko thực hiện gì
    }
    private bool check_exist_ma_mon(string ip_str_ma_lop_mon)
    {
        US_GD_LOP_MON v_us_gd_lop_mon = new US_GD_LOP_MON();
        DS_GD_LOP_MON v_ds_gd_lop_mon = new DS_GD_LOP_MON();
        v_us_gd_lop_mon.FillDataset(v_ds_gd_lop_mon, " WHERE MA_LOP_MON=N'" + ip_str_ma_lop_mon + "'");
        if (v_ds_gd_lop_mon.GD_LOP_MON.Rows.Count == 0)
            return false; // Nghĩa là không tồn tại lớp môn đó
        return true; // Nghĩa là tồn tại lớp môn đó
    }
    #endregion

    #region Public Interfaces
    public string mapping_cs(string ip_str_cs_YN)
    {
        if (ip_str_cs_YN.Equals("Y"))
            return "Có";
        return "Không";
    }
    public string mapping_time_lop_mon(string ip_str_ma_lop_mon)
    {
        US_GD_LOP_MON v_us_gd_lop_mon = new US_GD_LOP_MON();
        DS_GD_LOP_MON v_ds_gd_lop_mon = new DS_GD_LOP_MON();

        v_us_gd_lop_mon.FillDataset(v_ds_gd_lop_mon, " WHERE MA_LOP_MON=N'" + ip_str_ma_lop_mon + "'");
        if (v_ds_gd_lop_mon.GD_LOP_MON.Rows[0][GD_LOP_MON.NGAY_BAT_DAU].GetType()== typeof(DBNull))
        {
            if (v_ds_gd_lop_mon.GD_LOP_MON.Rows[0][GD_LOP_MON.NGAY_KET_THUC].GetType() == typeof(DBNull)) return "";
            else return CIPConvert.ToStr(v_ds_gd_lop_mon.GD_LOP_MON.Rows[0][GD_LOP_MON.NGAY_KET_THUC], "dd/MM/yyyy");
        }
        else if (v_ds_gd_lop_mon.GD_LOP_MON.Rows[0][GD_LOP_MON.NGAY_KET_THUC].GetType() == typeof(DBNull))
            return CIPConvert.ToStr(v_ds_gd_lop_mon.GD_LOP_MON.Rows[0][GD_LOP_MON.NGAY_BAT_DAU], "dd/MM/yyyy");
        return CIPConvert.ToStr(v_ds_gd_lop_mon.GD_LOP_MON.Rows[0][GD_LOP_MON.NGAY_BAT_DAU], "dd/MM/yyyy") + " - " + CIPConvert.ToStr(v_ds_gd_lop_mon.GD_LOP_MON.Rows[0][GD_LOP_MON.NGAY_KET_THUC], "dd/MM/yyyy");
    }
    public string mapping_thoi_gian_lop_mon(object ip_obj_thoi_gian_lop_mon)
    {
        if (ip_obj_thoi_gian_lop_mon.GetType() == typeof(DBNull)) return "";
        return CIPConvert.ToStr(ip_obj_thoi_gian_lop_mon,"dd/MM/yyyy");
    }
    public string mapping_magv_by_id(decimal ip_dc_id_gv)
    {
        US_V_DM_GIANG_VIEN v_dm_gv = new US_V_DM_GIANG_VIEN(ip_dc_id_gv);
        if (v_dm_gv.IsIDNull()) return "";
        return v_dm_gv.strMA_GIANG_VIEN;
    }
    #endregion
}