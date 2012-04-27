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

public partial class BaoCao_F805_BaoCaoTinhHinhThanhToanGV : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            load_data_2_nam_tinh_toan();
            load_data_2_grid();
        }
    }

    #region Members
    US_RPT_BAO_CAO_THONG_KE_SO_TIEN_THANH_TOAN_HD_GIANG_VIEN m_us_rpt_bao_cao_so_luong_trang_thai_hd_tong_hop = new US_RPT_BAO_CAO_THONG_KE_SO_TIEN_THANH_TOAN_HD_GIANG_VIEN();
    DS_RPT_BAO_CAO_THONG_KE_SO_TIEN_THANH_TOAN_HD_GIANG_VIEN m_ds_rpt_bao_cao_so_luong_trang_thai_hd_tong_hop = new DS_RPT_BAO_CAO_THONG_KE_SO_TIEN_THANH_TOAN_HD_GIANG_VIEN();
    #endregion

    #region Public Interface
    public string get_tong_hang(object ip_obj_so_hd_chuyen_mon_edutop, object ip_obj_so_hd_huong_dan_edutop, object ip_obj_so_hd_hoc_lieu_edutop, object ip_obj_so_hd_chuyen_mon_elc, object ip_obj_so_hd_huong_dan_elc, object ip_obj_so_hd_hoc_lieu_elc)
    {
        return CIPConvert.ToStr(CIPConvert.ToDecimal(ip_obj_so_hd_chuyen_mon_edutop) + CIPConvert.ToDecimal(ip_obj_so_hd_huong_dan_edutop) + CIPConvert.ToDecimal(ip_obj_so_hd_hoc_lieu_edutop) + CIPConvert.ToDecimal(ip_obj_so_hd_chuyen_mon_elc) + CIPConvert.ToDecimal(ip_obj_so_hd_huong_dan_elc) + CIPConvert.ToDecimal(ip_obj_so_hd_hoc_lieu_elc),"#,###");
    }
    #endregion

    #region Private Methods
    private void load_data_2_grid()
    {
        m_us_rpt_bao_cao_so_luong_trang_thai_hd_tong_hop.bao_cao_thong_ke_so_tien_thanh_toan_hd_giang_vien_tong_hop(m_ds_rpt_bao_cao_so_luong_trang_thai_hd_tong_hop, CIPConvert.ToDecimal(m_cbo_thang_tinh_toan.SelectedValue), CIPConvert.ToDecimal(m_cbo_nam_tinh_toan.SelectedValue));
        m_grv_danh_sach_du_toan.DataSource = m_ds_rpt_bao_cao_so_luong_trang_thai_hd_tong_hop.RPT_BAO_CAO_THONG_KE_SO_TIEN_THANH_TOAN_HD_GIANG_VIEN;
        m_grv_danh_sach_du_toan.DataBind();
    }
    private void load_data_2_excel_search()
    {
        m_us_rpt_bao_cao_so_luong_trang_thai_hd_tong_hop.bao_cao_thong_ke_so_tien_thanh_toan_hd_giang_vien_tong_hop(m_ds_rpt_bao_cao_so_luong_trang_thai_hd_tong_hop, CIPConvert.ToDecimal(m_cbo_thang_tinh_toan.SelectedValue), CIPConvert.ToDecimal(m_cbo_nam_tinh_toan.SelectedValue));
    }
    private void load_data_2_nam_tinh_toan()
    {
        m_cbo_nam_tinh_toan.Items.Add(new ListItem("Tất cả", CIPConvert.ToStr(0)));
        for (int v_i = 2008; v_i < 2051; v_i++)
        {
            m_cbo_nam_tinh_toan.Items.Add(new ListItem(v_i.ToString(), v_i.ToString()));
        }

    }
    private string mapping_edutop_elc(string ip_str_edutop_elc)
    {
        if (ip_str_edutop_elc.Equals("edutop")) return "EDUTOP";
        return "ELC";
    }
    private string get_thang_nam_hien_thi(string ip_str_thang, string ip_str_nam)
    {
        // Khi năm tính toán là tất cả, tháng tính toán sẽ tự động là tất cả
        // vậy coi như tính toán cho tất cả thời gian
        if (ip_str_nam.Equals("0")) return "Trong khoảng thời gian: Tất cả";
        else if (ip_str_thang.Equals("0"))
            return "Trong khoảng thời gian từ: tháng 01 năm " + ip_str_nam + " đến nay";
        return "Trong khoảng thời gian từ: tháng " + ip_str_thang + " năm " + ip_str_nam + " đến nay";
    }
    #endregion

    #region Export Excel
    private void loadDSExprort(ref string strTable)
    {
        int v_i_so_thu_tu = 0;
        // Mỗi cột dữ liệu ứng với từng dòng là label
        foreach (DataRow grv in this.m_ds_rpt_bao_cao_so_luong_trang_thai_hd_tong_hop.RPT_BAO_CAO_THONG_KE_SO_TIEN_THANH_TOAN_HD_GIANG_VIEN.Rows)
        {
            strTable += "\n<tr>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + "<span style='font-family:Tahoma; font-size:0.9em'>" + ++v_i_so_thu_tu + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + "<span style='font-family:Tahoma; font-size:0.9em'>" + grv[RPT_BAO_CAO_THONG_KE_SO_TIEN_THANH_TOAN_HD_GIANG_VIEN.TRANG_THAI_TT_HOP_DONG] + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + "<span style='font-family:Tahoma; font-size:0.9em'>" + grv[RPT_BAO_CAO_THONG_KE_SO_TIEN_THANH_TOAN_HD_GIANG_VIEN.HD_CHUYEN_MON_EDUTOP] + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + "<span style='font-family:Tahoma; font-size:0.9em'>" + grv[RPT_BAO_CAO_THONG_KE_SO_TIEN_THANH_TOAN_HD_GIANG_VIEN.HD_HUONG_DAN_EDUTOP] + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + "<span style='font-family:Tahoma; font-size:0.9em'>" + grv[RPT_BAO_CAO_THONG_KE_SO_TIEN_THANH_TOAN_HD_GIANG_VIEN.HD_HOC_LIEU_EDUTOP] + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + "<span style='font-family:Tahoma; font-size:0.9em'>" + grv[RPT_BAO_CAO_THONG_KE_SO_TIEN_THANH_TOAN_HD_GIANG_VIEN.HD_CHUYEN_MON_ELC] + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + "<span style='font-family:Tahoma; font-size:0.9em'>" + grv[RPT_BAO_CAO_THONG_KE_SO_TIEN_THANH_TOAN_HD_GIANG_VIEN.HD_HUONG_DAN_ELC] + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + "<span style='font-family:Tahoma; font-size:0.9em'>" + grv[RPT_BAO_CAO_THONG_KE_SO_TIEN_THANH_TOAN_HD_GIANG_VIEN.HD_HOC_LIEU_ELC] + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + "<span style='font-family:Tahoma; font-size:0.9em'>" + get_tong_hang(grv[RPT_BAO_CAO_THONG_KE_SO_TIEN_THANH_TOAN_HD_GIANG_VIEN.HD_CHUYEN_MON_EDUTOP], grv[RPT_BAO_CAO_THONG_KE_SO_TIEN_THANH_TOAN_HD_GIANG_VIEN.HD_HUONG_DAN_EDUTOP], grv[RPT_BAO_CAO_THONG_KE_SO_TIEN_THANH_TOAN_HD_GIANG_VIEN.HD_HOC_LIEU_EDUTOP], grv[RPT_BAO_CAO_THONG_KE_SO_TIEN_THANH_TOAN_HD_GIANG_VIEN.HD_CHUYEN_MON_ELC], grv[RPT_BAO_CAO_THONG_KE_SO_TIEN_THANH_TOAN_HD_GIANG_VIEN.HD_HUONG_DAN_ELC], grv[RPT_BAO_CAO_THONG_KE_SO_TIEN_THANH_TOAN_HD_GIANG_VIEN.HD_HOC_LIEU_ELC]) + "</td>";
            strTable += "\n</tr>";
        }
    }

    private void loadTieuDe(ref string strTable)
    {
        load_data_2_excel_search();
        strTable += "<table cellpadding='2' cellspacing='0' class='cssTableReport'>";
        strTable += "\n<tr>";
        strTable += "\n<td colspan='6' align='center'><class='cssTableView' style='width: 100%;  height: 40px; font-size: large; color:White; background-color:#810C15;' nowrap='wrap'><span style='font-family:Times New Roman; font-weight:bold; font-size:1.3em;'>TRM802 - BÁO CÁO TỔNG HỢP SỐ HỢP ĐỒNG THEO TRẠNG THÁI HỢP ĐỒNG" + "</td>";
        strTable += "\n</tr>";
        //
        strTable += "\n<tr>";
        strTable += "\n<td colspan='6' align='center'><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'><span style='font-family:Times New Roman; font-style:italic; font-size:1.0em'>" + get_thang_nam_hien_thi(m_cbo_thang_tinh_toan.SelectedValue, m_cbo_nam_tinh_toan.SelectedValue) + "</span></td>";
        strTable += "\n</tr>";
        //
        strTable += "\n</table>";
        //table noi dung
        strTable += "<table cellpadding='2' cellspacing='0' class='cssTableReport'>";
        strTable += "\n<tr>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>STT</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Trạng thái hợp đồng</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Chuyên môn EDUTOP</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Hướng dẫn EDUTOP</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Học liệu EDUTOP</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Chuyên môn ELC</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Hướng dẫn ELC</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Học liệu ELC</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Tổng</td>";
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
    protected void m_cmd_xuat_excel_Click(object sender, EventArgs e)
    {
        try
        {
            string html = loadExport();
            string strNamFile = "BaoCaoTongHopSoHDTheoTrangThaiHD" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + ".xls";
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
    protected void m_cbo_dot_thanh_toan_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            load_data_2_grid();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_edutop_or_elc_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            load_data_2_grid();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_thang_tinh_toan_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (m_cbo_nam_tinh_toan.SelectedValue == "0") m_cbo_thang_tinh_toan.SelectedIndex = 0;
            load_data_2_grid();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_nam_tinh_toan_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (m_cbo_nam_tinh_toan.SelectedValue == "0") m_cbo_thang_tinh_toan.SelectedIndex = 0;
            load_data_2_grid();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    #endregion
}