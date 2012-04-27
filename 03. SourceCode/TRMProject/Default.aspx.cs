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

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            load_data_2_grid();
        }
    }

    #region Members
    US_RPT_BAO_CAO_THONG_KE_TRANG_THAI_GIANG_VIEN m_us_rpt_bao_cao_thong_ke_trang_thai_gv = new US_RPT_BAO_CAO_THONG_KE_TRANG_THAI_GIANG_VIEN();
    DS_RPT_BAO_CAO_THONG_KE_TRANG_THAI_GIANG_VIEN m_ds_rpt_bao_cao_thong_ke_trang_thai_gv = new DS_RPT_BAO_CAO_THONG_KE_TRANG_THAI_GIANG_VIEN();
    #endregion

    #region Private Methods
    private void load_data_2_grid()
    {

        m_us_rpt_bao_cao_thong_ke_trang_thai_gv.bao_cao_thong_ke_gv(m_ds_rpt_bao_cao_thong_ke_trang_thai_gv);
        m_grv_danh_sach_du_toan.DataSource = m_ds_rpt_bao_cao_thong_ke_trang_thai_gv.RPT_BAO_CAO_THONG_KE_TRANG_THAI_GIANG_VIEN;
        m_grv_danh_sach_du_toan.DataBind();
    }
    private void load_data_2_excel_search()
    {
        m_us_rpt_bao_cao_thong_ke_trang_thai_gv.bao_cao_thong_ke_gv(m_ds_rpt_bao_cao_thong_ke_trang_thai_gv);
    }
    #endregion

    #region Public Interface
    public decimal get_tong_hang(object ip_obj_so_gv_chuyen_mon, object ip_obj_so_gv_huong_dan, object ip_obj_so_gv_hoc_lieu)
    {
        return CIPConvert.ToDecimal(ip_obj_so_gv_chuyen_mon) + CIPConvert.ToDecimal(ip_obj_so_gv_huong_dan) + CIPConvert.ToDecimal(ip_obj_so_gv_hoc_lieu);
    }
    #endregion

    #region Export Excel
    private void loadDSExprort(ref string strTable)
    {
        int v_i_so_thu_tu = 0;
        // Mỗi cột dữ liệu ứng với từng dòng là label
        foreach (DataRow grv in this.m_ds_rpt_bao_cao_thong_ke_trang_thai_gv.RPT_BAO_CAO_THONG_KE_TRANG_THAI_GIANG_VIEN.Rows)
        {
            strTable += "\n<tr>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + "<span style='font-family:Tahoma; font-size:0.9em'>" + ++v_i_so_thu_tu + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + "<span style='font-family:Tahoma; font-size:0.9em'>" + grv[RPT_BAO_CAO_THONG_KE_TRANG_THAI_GIANG_VIEN.DON_VI_QUAN_LY] + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + "<span style='font-family:Tahoma; font-size:0.9em'>" + grv[RPT_BAO_CAO_THONG_KE_TRANG_THAI_GIANG_VIEN.TRANG_THAI_GIANG_VIEN] + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + "<span style='font-family:Tahoma; font-size:0.9em'>" + grv[RPT_BAO_CAO_THONG_KE_TRANG_THAI_GIANG_VIEN.GV_CHUYEN_MON] + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + "<span style='font-family:Tahoma; font-size:0.9em'>" + grv[RPT_BAO_CAO_THONG_KE_TRANG_THAI_GIANG_VIEN.GV_HUONG_DAN] + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + "<span style='font-family:Tahoma; font-size:0.9em'>" + grv[RPT_BAO_CAO_THONG_KE_TRANG_THAI_GIANG_VIEN.GV_HOC_LIEU] + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + "<span style='font-family:Tahoma; font-size:0.9em'>" + get_tong_hang(grv[RPT_BAO_CAO_THONG_KE_TRANG_THAI_GIANG_VIEN.GV_CHUYEN_MON], grv[RPT_BAO_CAO_THONG_KE_TRANG_THAI_GIANG_VIEN.GV_HUONG_DAN], grv[RPT_BAO_CAO_THONG_KE_TRANG_THAI_GIANG_VIEN.GV_HOC_LIEU]) + "</td>";
            strTable += "\n</tr>";
        }
    }

    private void loadTieuDe(ref string strTable)
    {
        load_data_2_excel_search();
        strTable += "<table cellpadding='2' cellspacing='0' class='cssTableReport'>";
        strTable += "\n<tr>";
        strTable += "\n<td colspan='6' align='center'><class='cssTableView' style='width: 100%;  height: 40px; font-size: large; color:White; background-color:#810C15;' nowrap='wrap'><span style='font-family:Times New Roman; font-weight:bold; font-size:1.3em;'>TRM800 - BÁO CÁO THỐNG KÊ TRẠNG THÁI GIẢNG VIÊN" + "</td>";
        strTable += "\n</tr>";
        strTable += "\n</table>";
        //table noi dung
        strTable += "<table cellpadding='2' cellspacing='0' class='cssTableReport'>";
        strTable += "\n<tr>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>STT</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Đơn vị quản lý</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Trạng thái giảng viên</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>GV Chuyên môn</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>GV hướng dẫn</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>GV học liệu</td>";
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
            string strNamFile = "BaoCaoThongKeTrangThaiGV" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + ".xls";
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
