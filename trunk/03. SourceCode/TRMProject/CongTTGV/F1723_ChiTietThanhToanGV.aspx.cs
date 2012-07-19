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

public partial class CongTTGV_F1723_ChiTietThanhToanGV : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        m_lbl_thong_bao.Text = "";
        if (!IsPostBack)
        {
            // show on grid
            if (Request.QueryString["id_gdtt"] != null)
            {
                //Lấy ID GD_THANH_TOAN
                m_dc_id_gd_thanh_toan = CIPConvert.ToDecimal(Request.QueryString["id_gdtt"]);
                // Đổ dữ liệu vào các labels
                load_data_2_basic_control(m_dc_id_gd_thanh_toan);
                load_data_2_grid(m_dc_id_gd_thanh_toan);

            }
        }
    }

    #region Members
    US_V_GD_THANH_TOAN_DETAIL m_us_v_gd_thanh_toan_detail = new US_V_GD_THANH_TOAN_DETAIL();
    DS_V_GD_THANH_TOAN_DETAIL m_ds_v_gd_thanh_toan_detail = new DS_V_GD_THANH_TOAN_DETAIL();
    decimal m_dc_id_gd_thanh_toan = 0;
    decimal m_dc_id_dot_thanh_toan = 0;
    #endregion

    #region Private Methods
    // Load toàn bộ thanh toán detail của thanh toán đang xét
    private void load_data_2_grid(decimal ip_dc_id_thanh_toan)
    {
        try
        {
            m_us_v_gd_thanh_toan_detail.FillDataset(m_ds_v_gd_thanh_toan_detail, " WHERE ID_GD_THANH_TOAN= " + ip_dc_id_thanh_toan);

            if (m_ds_v_gd_thanh_toan_detail.V_GD_THANH_TOAN_DETAIL.Rows.Count > 0)
            {
                // Load to grid                
                m_grv_gd_thanh_toan_detail.DataSource = m_ds_v_gd_thanh_toan_detail.V_GD_THANH_TOAN_DETAIL;
                m_grv_gd_thanh_toan_detail.DataBind();

                decimal v_dc_tong_tien = get_sum_tien(m_ds_v_gd_thanh_toan_detail);
                m_grv_gd_thanh_toan_detail.FooterRow.Cells[7].Text = CIPConvert.ToStr(v_dc_tong_tien, "#,###");
            }
        }
        catch (Exception v_e)
        {

            throw v_e;
        }

    }
    // Load data to so hợp đồng và tên giảng viên
    private void load_data_2_basic_control(decimal ip_dc_id_gdtt)
    {
        try
        {
            US_V_GD_THANH_TOAN v_us_gd_thanh_toan = new US_V_GD_THANH_TOAN(ip_dc_id_gdtt);
            if (!v_us_gd_thanh_toan.IsIDNull())
            {
                m_lbl_so_phieu_thanh_toan.Text = v_us_gd_thanh_toan.strSO_PHIEU_THANH_TOAN;
                m_lbl_so_hop_dong.Text = get_so_hop_dong_by_id(v_us_gd_thanh_toan.dcID_HOP_DONG_KHUNG);
                if (v_us_gd_thanh_toan.datNGAY_THANH_TOAN != null)
                    m_lbl_dat_ngay_thanh_toan.Text = CIPConvert.ToStr(v_us_gd_thanh_toan.datNGAY_THANH_TOAN, "dd/MM/yyyy");
                m_lbl_don_vi_thanh_toan.Text = get_dv_thanh_toan_by_id_hd(v_us_gd_thanh_toan.dcID_HOP_DONG_KHUNG);
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
    private string mapping_so_tien(object ip_obj_nghiem_thu_thuc_te)
    {
        if (ip_obj_nghiem_thu_thuc_te.GetType() == typeof(DBNull)) return "";
        if (CIPConvert.ToDecimal(ip_obj_nghiem_thu_thuc_te) == 0)
            return CIPConvert.ToStr(0);
        return CIPConvert.ToStr(ip_obj_nghiem_thu_thuc_te, "#,###");
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
    public string get_so_tien_thanh_toan(object ip_obj_so_luong_nghiem_thu, object ip_obj_don_gia)
    {
        string v_str_so_tien_thanh_toan = "";
        if (ip_obj_so_luong_nghiem_thu.GetType() == typeof(DBNull) || ip_obj_don_gia.GetType() == typeof(DBNull))
            v_str_so_tien_thanh_toan = "";
        else v_str_so_tien_thanh_toan = CIPConvert.ToStr(CIPConvert.ToDecimal(ip_obj_don_gia) * CIPConvert.ToDecimal(ip_obj_so_luong_nghiem_thu), "#,###");
        return v_str_so_tien_thanh_toan;
    }
    public decimal get_sum_tien(DS_V_GD_THANH_TOAN_DETAIL ip_ds_gd_thanh_toan_detail)
    {
        decimal v_dc_sum_tien = 0;
        for (int v_i = 0; v_i < ip_ds_gd_thanh_toan_detail.V_GD_THANH_TOAN_DETAIL.Rows.Count; v_i++)
        {
            if (ip_ds_gd_thanh_toan_detail.V_GD_THANH_TOAN_DETAIL.Rows[v_i][V_GD_THANH_TOAN_DETAIL.SO_LUONG_HE_SO].GetType() == typeof(DBNull) || ip_ds_gd_thanh_toan_detail.V_GD_THANH_TOAN_DETAIL.Rows[v_i][V_GD_THANH_TOAN_DETAIL.DON_GIA_TT].GetType() == typeof(DBNull))
                v_dc_sum_tien += 0;
            else v_dc_sum_tien += CIPConvert.ToDecimal(ip_ds_gd_thanh_toan_detail.V_GD_THANH_TOAN_DETAIL.Rows[v_i][V_GD_THANH_TOAN_DETAIL.SO_LUONG_HE_SO]) * CIPConvert.ToDecimal(ip_ds_gd_thanh_toan_detail.V_GD_THANH_TOAN_DETAIL.Rows[v_i][V_GD_THANH_TOAN_DETAIL.DON_GIA_TT]);
        }
        return v_dc_sum_tien;
    }
    #endregion

    #region Export Excel
    private void loadDSExprort(ref string strTable)
    {
        int v_i_so_thu_tu = 0;
        // Mỗi cột dữ liệu ứng với từng dòng là label
        foreach (DataRow grv in this.m_ds_v_gd_thanh_toan_detail.V_GD_THANH_TOAN_DETAIL.Rows)
        {
            strTable += "\n<tr>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + ++v_i_so_thu_tu + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + get_so_phieu_thanh_toan_by_id_gd_thanh_toan(CIPConvert.ToDecimal(grv[V_GD_THANH_TOAN_DETAIL.ID_GD_THANH_TOAN])) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + get_so_hop_dong_by_id(CIPConvert.ToDecimal(grv[V_GD_THANH_TOAN_DETAIL.ID_HOP_DONG_KHUNG])) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + get_noi_dung_tt_by_id(CIPConvert.ToDecimal(grv[V_GD_THANH_TOAN_DETAIL.ID_NOI_DUNG_THANH_TOAN])) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + CIPConvert.ToStr(CIPConvert.ToDecimal(grv[V_GD_THANH_TOAN_DETAIL.SO_LUONG_HE_SO])) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + CIPConvert.ToStr(grv[V_GD_THANH_TOAN_DETAIL.DON_VI_TINH]) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_so_tien(CIPConvert.ToDecimal(grv[V_GD_THANH_TOAN_DETAIL.DON_GIA_TT])) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + "Theo " + CIPConvert.ToStr(grv[V_GD_THANH_TOAN_DETAIL.TAN_SUAT]) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + CIPConvert.ToStr(grv[V_GD_THANH_TOAN_DETAIL.DESCRIPTION]) + "</td>";
            strTable += "\n</tr>";
        }
    }

    private void loadTieuDe(ref string strTable)
    {
        m_ds_v_gd_thanh_toan_detail.Clear();
        m_dc_id_gd_thanh_toan = CIPConvert.ToDecimal(Request.QueryString["id_gdtt"]);
        m_us_v_gd_thanh_toan_detail.FillDataset(m_ds_v_gd_thanh_toan_detail, " WHERE ID_GD_THANH_TOAN= " + m_dc_id_gd_thanh_toan);
        strTable += "<table cellpadding='2' cellspacing='0' class='cssTableReport'>";
        strTable += "\n<tr>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width: 100%;  height: 40px; font-size: large; color:White; background-color:#810C15;' nowrap='wrap'>TRM702 - BÁO CÁO CHI TIẾT THANH TOÁN CỦA GIẢNG VIÊN" + "</td>";
        strTable += "\n</tr>";
        //
        strTable += "\n<tr>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'> Số phiếu thanh toán: " + m_lbl_so_phieu_thanh_toan.Text + "</td>";
        strTable += "\n</tr>";
        //
        strTable += "\n<tr>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>Đơn vị thanh toán: " + m_lbl_don_vi_thanh_toan.Text + "</td>";
        strTable += "\n</tr>";
        //
        strTable += "\n<tr>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>Ngày thanh toán: " + m_lbl_dat_ngay_thanh_toan.Text + "</td>";
        strTable += "\n</tr>";
        //
        strTable += "\n<tr>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>Số hợp đồng: " + m_lbl_so_hop_dong.Text + "</td>";
        strTable += "\n</tr>";
        strTable += "\n</table>";
        //table noi dung
        strTable += "<table cellpadding='2' cellspacing='0' class='cssTableReport'>";
        strTable += "\n<tr>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>STT</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Số phiếu thanh toán</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Số hợp đồng</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Nội dung thanh toán</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Số lượng/hệ số</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Đơn vị tính</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Đơn giá(VNĐ)</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Tần suất thanh toán</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Mô tả</td>";
        strTable += "\n</tr>";
        loadDSExprort(ref strTable);
        strTable += "\n</table>";
    }

    private string loadExport()
    {
        try
        {
            string strHTML = "<html xmlns:o='urn:schemas-microsoft-com:office:office'"
            + "\n xmlns:x='urn:schemas-microsoft-com:office:excel'"
            + "\n xmlns='http://www.w3.org/TR/REC-html40'>"
            + "\n <head>"
            + "\n <meta http-equiv=Content-Type content='text/html; charset=utf-8'>"
            + "\n <meta name=ProgId content=Excel.Sheet>"
            + "\n <meta name=Generator content='Microsoft Excel 11'>"
            + "\n <link rel=File-List href='Book1_files/filelist.xml'>"
            + "\n <style id='Book1_28091_Styles'><!--table"
            + "\n 	{mso-displayed-decimal-separator:'\\.';"
            + "\n 	mso-displayed-thousand-separator:'\\,';}"
            + ".cssTitleReport"
            + "{font-family: tahoma; font-size: 11px;font-weight:normal;border: 1px #000000 solid;text-align:left;}"
            + ".cssTableView"
            + "{color:#FFFFFF;background-color:#800000;font-family: tahoma,Arial,Times New Roman; font-size: 12px;font-weight:bold;border: 1px #000000 solid;}"
            + "\n 	--></style>"
            + "\n 	</head>"
            + "\n 	<body><div id='Book1_28091' align=center x:publishsource='Excel'>";
            string strTable = "";
            loadTieuDe(ref strTable);
            strHTML += strTable;
            strHTML += "\n </div></body> ";
            strHTML += "\n </html> ";

            return strHTML;
        }
        catch
        {
            return "";
        }
    }
    #endregion


    #region Events
    protected void m_cmd_exit_Click(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["id_dtt"] != null)
            {
                //Lấy ID GD_THANH_TOAN
                m_dc_id_dot_thanh_toan = CIPConvert.ToDecimal(Request.QueryString["id_dtt"]);
                Response.Redirect("/TRMProject/CongTTGV/F1721_ThanhToanGVTheoDot.aspx?id_dtt=" + m_dc_id_dot_thanh_toan.ToString(), false);
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
            else
            {
                Response.Redirect("/TRMProject/CongTTGV/F1721_ThanhToanGVTheoDot.aspx", false);
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
        }
        catch (Exception v_e)
        {

            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_btt_xuatExcel_Click(object sender, EventArgs e)
    {
        try
        {
            string html = loadExport();
            string strNamFile = "BaoCaoChiTietThanhToanTheoGiangVien" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + ".xls";
            Response.Cache.SetExpires(DateTime.Now.AddSeconds(1));
            Response.Clear();
            Response.AppendHeader("content-disposition", "attachment;filename=" + strNamFile);
            Response.Charset = "UTF-8";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "text/csv";
            Response.ContentType = "application/vnd.ms-excel";
            this.EnableViewState = false;
            Response.Write("\r\n");
            Response.Write(html);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    #endregion
}