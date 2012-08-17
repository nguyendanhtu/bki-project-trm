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


public partial class BaoCao_F706_TongHopCongViecGVCM : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            load_data_2_cbo_trang_thai_cv_gv();
            load_data_2_cbo_thoi_gian_dat_hang();
            load_data_2_grv();
        }
    }

    #region Members
    US_RPT_BAO_CAO_TONG_HOP_CONG_VIEC_GVCM m_us_cong_viec_moi = new US_RPT_BAO_CAO_TONG_HOP_CONG_VIEC_GVCM();
    DS_RPT_BAO_CAO_TONG_HOP_CONG_VIEC_GVCM m_ds_cong_viec_moi = new DS_RPT_BAO_CAO_TONG_HOP_CONG_VIEC_GVCM();
    #endregion

    #region Private Methods
    private void load_data_2_grv()
    {
        m_ds_cong_viec_moi.EnforceConstraints = false;
        m_us_cong_viec_moi.load_data_2_export_bao_cao_706(m_ds_cong_viec_moi, CIPConvert.ToDecimal(m_cbo_thang_dat_hang.SelectedValue), CIPConvert.ToDecimal(m_cbo_nam_dat_hang.SelectedValue), CIPConvert.ToDecimal(m_cbo_trang_thai_cv_loc.SelectedValue));
        m_grv_gd_assign_su_kien_cho_giang_vien.DataSource = m_ds_cong_viec_moi.RPT_BAO_CAO_TONG_HOP_CONG_VIEC_GVCM;
        m_grv_gd_assign_su_kien_cho_giang_vien.DataBind();
        m_lbl_ds_cv_gv.Text = "Báo cáo tổng hợp công việc GVCM: " + m_ds_cong_viec_moi.RPT_BAO_CAO_TONG_HOP_CONG_VIEC_GVCM.Rows.Count + " bản ghi";
        if (m_ds_cong_viec_moi.RPT_BAO_CAO_TONG_HOP_CONG_VIEC_GVCM.Rows.Count == 0)
        {
            m_cmd_xuat_excel.Visible = false;
        }
        else
        {
            m_cmd_xuat_excel.Visible = true;
            decimal v_dc_tong_tien = get_sum_tien(m_ds_cong_viec_moi);
            m_grv_gd_assign_su_kien_cho_giang_vien.FooterRow.Cells[5].Text = CIPConvert.ToStr(v_dc_tong_tien, "#,###");
        }
    }
    private void load_data_2_cbo_trang_thai_cv_gv()
    {
        US_CM_DM_TU_DIEN v_us_tu_dien = new US_CM_DM_TU_DIEN();
        DS_CM_DM_TU_DIEN v_ds_tu_dien = new DS_CM_DM_TU_DIEN();

        v_us_tu_dien.FillDataset(v_ds_tu_dien, " WHERE ID_LOAI_TU_DIEN = " + (int)e_loai_tu_dien.TRANG_THAI_CONG_VIEC_GV);

        m_cbo_trang_thai_cv_loc.Items.Add(new ListItem("Tất cả", "0"));
        for (int v_i = 0; v_i < v_ds_tu_dien.CM_DM_TU_DIEN.Rows.Count; v_i++)
        {
            m_cbo_trang_thai_cv_loc.Items.Add(new ListItem(CIPConvert.ToStr(v_ds_tu_dien.CM_DM_TU_DIEN.Rows[v_i][CM_DM_TU_DIEN.TEN]), CIPConvert.ToStr(v_ds_tu_dien.CM_DM_TU_DIEN.Rows[v_i][CM_DM_TU_DIEN.ID])));
        }
    }
    private void load_data_2_cbo_thoi_gian_dat_hang()
    {
        // Load tháng đặt hàng
        m_cbo_thang_dat_hang.Items.Add(new ListItem("Tất cả", "0"));
        for (int v_i = 1; v_i <= 12; v_i++)
        {
            m_cbo_thang_dat_hang.Items.Add(new ListItem(CIPConvert.ToStr(v_i), CIPConvert.ToStr(v_i)));
        }
        // Load năm đặt hàng
        m_cbo_nam_dat_hang.Items.Add(new ListItem("Tất cả", "0"));
        for (int v_i = 2012; v_i < 2050; v_i++)
        {
            m_cbo_nam_dat_hang.Items.Add(new ListItem(CIPConvert.ToStr(v_i), CIPConvert.ToStr(v_i)));
        }

    }
    private string mapping_so_tien(object ip_obj_so_tien)
    {
        if (ip_obj_so_tien.GetType() == typeof(DBNull)) return "";
        if (CIPConvert.ToDecimal(ip_obj_so_tien) == 0)
            return CIPConvert.ToStr(0);
        return CIPConvert.ToStr(ip_obj_so_tien, "#,###");
    }
    private string mapping_dvt_by_id_noi_dung_tt(decimal ip_dc_id_noi_dung_tt)
    {
        US_V_GD_HOP_DONG_NOI_DUNG_TT v_us_gd_hop_dong_noi_dung_tt = new US_V_GD_HOP_DONG_NOI_DUNG_TT(ip_dc_id_noi_dung_tt);
        if (v_us_gd_hop_dong_noi_dung_tt.IsIDNull()) return "";
        return v_us_gd_hop_dong_noi_dung_tt.strDON_VI_TINH;
    }
    #endregion

    #region Public Interfaces
    public string get_ma_trang_thai_by_id(decimal ip_dc_id_trang_thai)
    {
        US_CM_DM_TU_DIEN v_us_dm_tu_dien = new US_CM_DM_TU_DIEN(ip_dc_id_trang_thai);
        return v_us_dm_tu_dien.strMA_TU_DIEN;
    }
    public decimal get_sum_tien(DS_RPT_BAO_CAO_TONG_HOP_CONG_VIEC_GVCM ip_ds_gd_gv_cong_viec)
    {
        decimal v_dc_sum_tien = 0;
        for (int v_i = 0; v_i < ip_ds_gd_gv_cong_viec.RPT_BAO_CAO_TONG_HOP_CONG_VIEC_GVCM.Rows.Count; v_i++)
        {
            if (ip_ds_gd_gv_cong_viec.RPT_BAO_CAO_TONG_HOP_CONG_VIEC_GVCM.Rows[v_i][RPT_BAO_CAO_TONG_HOP_CONG_VIEC_GVCM.THANH_TIEN].GetType() == typeof(DBNull))
                v_dc_sum_tien += 0;
            else
            {
                v_dc_sum_tien += CIPConvert.ToDecimal(ip_ds_gd_gv_cong_viec.RPT_BAO_CAO_TONG_HOP_CONG_VIEC_GVCM.Rows[v_i][RPT_BAO_CAO_TONG_HOP_CONG_VIEC_GVCM.THANH_TIEN]);
            }
        }
        return v_dc_sum_tien;
    }
    public bool check_trang_thai_chuyen(decimal ip_obj_trang_thai_hien_tai, decimal ip_obj_trang_thai_huong_toi)
    {
        // Kiểm tra xem dòng đó có được phép chỉnh sửa trạng thái nữa không? (duyệt nữa không?)
        CValidateTrangThaiCongViec v_validate_cong_viec = new CValidateTrangThaiCongViec();
        v_validate_cong_viec.Trang_thai_cong_viec_hien_tai = get_ma_trang_thai_by_id(ip_obj_trang_thai_hien_tai);
        v_validate_cong_viec.set_trang_thai();
        if (!v_validate_cong_viec.check_chuyen_trang_thai(get_ma_trang_thai_by_id(ip_obj_trang_thai_huong_toi)))
            return false;
        return true;
    }
    public string get_so_tien_thanh_toan(object ip_obj_so_luong_nghiem_thu, object ip_obj_don_gia)
    {
        string v_str_so_tien_thanh_toan = "";
        if (ip_obj_so_luong_nghiem_thu.GetType() == typeof(DBNull) || ip_obj_don_gia.GetType() == typeof(DBNull))
            v_str_so_tien_thanh_toan = "";
        else v_str_so_tien_thanh_toan = CIPConvert.ToStr(CIPConvert.ToDecimal(ip_obj_don_gia) * CIPConvert.ToDecimal(ip_obj_so_luong_nghiem_thu), "#,###");
        return v_str_so_tien_thanh_toan;
    }
    #endregion

    #region Export Excel
    private void loadDSExprort(ref string strTable)
    {
        int v_i_so_thu_tu = 0;
        // Mỗi cột dữ liệu ứng với từng dòng là label
        foreach (DataRow grv in this.m_ds_cong_viec_moi.RPT_BAO_CAO_TONG_HOP_CONG_VIEC_GVCM.Rows)
        {
            strTable += "\n<tr>";
            strTable += "\n<td align='center' class='cssTitleReport' style='width:12%;' nowrap='nowrap'><span style='font-family:Times New Roman;font-size:1.1em'>" + ++v_i_so_thu_tu + "</span></td>";
            strTable += "\n<td class='cssTitleReport' style='width:12%;' wrap='wrap'><span style='font-family:Times New Roman;font-size:1.1em'>" + grv[RPT_BAO_CAO_TONG_HOP_CONG_VIEC_GVCM.TEN_NOI_DUNG] + "</span></td>";
            //strTable += "\n<td align='right' class='cssTitleReport' style='width:12%;' nowrap='nowrap'><span style='font-family:Times New Roman;font-size:1.1em'>" + mapping_so_tien(grv[RPT_BAO_CAO_TONG_HOP_CONG_VIEC_GVCM.DON_GIA]) + "</span></td>";
            strTable += "\n<td align='center' class='cssTitleReport' style='width:12%;' nowrap='nowrap'><span style='font-family:Times New Roman;font-size:1.1em'>" + grv[RPT_BAO_CAO_TONG_HOP_CONG_VIEC_GVCM.DON_VI_TINH] + "</span></td>";
            strTable += "\n<td class='cssTitleReport' align='center' style='width:12%;' nowrap='nowrap'><span style='font-family:Times New Roman;font-size:1.1em'>" + grv[RPT_BAO_CAO_TONG_HOP_CONG_VIEC_GVCM.TONG_SO_LUONG] + "</span></td>";
            strTable += "\n<td align='right' class='cssTitleReport' style='width:12%;' nowrap='nowrap'><span style='font-family:Times New Roman;font-size:1.1em'>" + mapping_so_tien(grv[RPT_BAO_CAO_TONG_HOP_CONG_VIEC_GVCM.THANH_TIEN]) + "</span></td>";
            strTable += "\n</tr>";
        }
        // Đây là đoạn tổng cộng số tiền
        decimal v_dc_tong_tien = get_sum_tien(m_ds_cong_viec_moi);
        strTable += "\n<tr>";
        strTable += "\n<td style='width:12%; background-color:#B8D7FF' class='cssTitleReport' nowrap='nowrap'>" + "<span style='font-family:Times New Roman; font-size:1.1em'></span></td>";
        strTable += "\n<td style='width:12%; background-color:#B8D7FF' class='cssTitleReport' nowrap='nowrap'><span style='font-family:Times New Roman;  font-weight:bold; font-size:1.1em'>Tổng cộng</span></td>";
        strTable += "\n<td style='width:12%; background-color:#B8D7FF' class='cssTitleReport' nowrap='nowrap'>" + "<span style='font-family:Times New Roman; font-size:1.1em'></span></td>";
        strTable += "\n<td style='width:12%; background-color:#B8D7FF' class='cssTitleReport' nowrap='nowrap'>" + "<span style='font-family:Times New Roman; font-size:1.1em'></span></td>";
        strTable += "\n<td style='width:12%; background-color:#B8D7FF' align='right' class='cssTitleReport' nowrap='nowrap'><span style='font-family:Times New Roman;  font-weight:bold; font-size:1.1em'>" + CIPConvert.ToStr(v_dc_tong_tien, "#,###") + "</span></td>"; // Số tiền tổng
        strTable += "\n</tr>";
    }
    private void loadTieuDe(ref string strTable)
    {
        m_ds_cong_viec_moi.EnforceConstraints = false;
        m_us_cong_viec_moi.load_data_2_export_bao_cao_706(m_ds_cong_viec_moi, CIPConvert.ToDecimal(m_cbo_thang_dat_hang.SelectedValue), CIPConvert.ToDecimal(m_cbo_nam_dat_hang.SelectedValue), CIPConvert.ToDecimal(m_cbo_trang_thai_cv_loc.SelectedValue));
        strTable += "<table cellpadding='2' cellspacing='0' class='cssTableReport'>";

        strTable += "\n<tr>";
        strTable += "\n<td colspan='3'><class='cssTableView' style='width:100%;' nowrap='nowrap'><span style='font-family:Times New Roman; font-weight:bold; font-size:1.1em'>Công ty CP Đầu tư và Phát triển đào tạo Edutop64</span></td>";
        strTable += "\n<td colspan='3' align='right'><class='cssTableView' style='width:100%;' nowrap='nowrap'></td>";
        strTable += "\n</tr>";
        //
        strTable += "\n<tr>";
        strTable += "\n<td colspan='3'><class='cssTableView' style='width:100%;' nowrap='nowrap'><span style='font-family:Times New Roman; margin-left:30px; font-weight:bold; font-size:1.1em; text-decoration:underline;'>Trung tâm Đào tạo HOU - TOPICA</span></td>";
        strTable += "\n</tr>";
        //Khoảng trắng trước khi vào header chính
        strTable += "\n<tr>";
        strTable += "\n<td colspan='6'></td>";
        strTable += "\n</tr>";
        //
        strTable += "\n<tr>";
        strTable += "\n<td colspan='6' align='center'><class='cssTableView' style='width: 100%;  height: 40px; font-size: large; color:White; background-color:#810C15;' nowrap='wrap'><span style='font-family:Times New Roman; font-weight:bold; font-size:1.4em;'>F706 - TỔNG HỢP CÔNG VIỆC GIẢNG VIÊN CHUYÊN MÔN" + "</span></td>";
        strTable += "\n</tr>";
        //Khoảng trắng trước khi vào thông tin về phiếu xác nhận thù lao
        strTable += "\n<tr>";
        strTable += "\n<td colspan='6'></td>";
        strTable += "\n</tr>";
        // Tháng đặt hàng
        strTable += "\n<tr>";
        strTable += "\n<td colspan='6' align='left'><class='cssTableView' style='width:100%;' nowrap='nowrap'> <span style='font-family:Times New Roman; font-size:1.1em'>Tháng: " + m_cbo_thang_dat_hang.SelectedItem.Text + "</span></td>";
        strTable += "\n</tr>";
        // Năm đặt hàng
        strTable += "\n<tr>";
        strTable += "\n<td colspan='6' align='left'><class='cssTableView' style='width:100%;' nowrap='nowrap'> <span style='font-family:Times New Roman;font-size:1.1em'>Năm: <font style='font-weight:bold'>" + m_cbo_nam_dat_hang.SelectedItem.Text + "</font></span></td>";
        strTable += "\n</tr>";
        // Trạng thái công việc
        strTable += "\n<tr>";
        strTable += "\n<td colspan='6' align='left'><class='cssTableView' style='width:100%;' nowrap='nowrap'> <span style='font-family:Times New Roman;font-size:1.1em'>Trạng thái công việc: <font style='font-weight:bold'>" + m_cbo_trang_thai_cv_loc.SelectedItem.Text + "</font></span></td>";
        strTable += "\n</tr>";
        //Khoảng trắng trước khi vào nội dung chính
        strTable += "\n<tr>";
        strTable += "\n<td colspan='6'></td>";
        strTable += "\n</tr>";
        //
        strTable += "\n</table>";
        //table noi dung
        strTable += "<table cellpadding='2' cellspacing='0' class='cssTableReport'>";
        strTable += "\n<tr>";
        strTable += "\n<td align='center' class='cssTableView' style='width:12%;' nowrap='nowrap'><span style='font-family:Times New Roman; font-weight:bold; font-size:1.1em'>STT</span></td>";
        strTable += "\n<td align='center' class='cssTableView' style='width:12%;' nowrap='nowrap'><span style='font-family:Times New Roman; font-weight:bold; font-size:1.1em'>Công việc</span></td>";
        strTable += "\n<td align='center' class='cssTableView' style='width:12%;' nowrap='nowrap'><span style='font-family:Times New Roman; font-weight:bold; font-size:1.1em'>Số lượng</span></td>";
        strTable += "\n<td align='center' class='cssTableView' style='width:12%;' nowrap='nowrap'><span style='font-family:Times New Roman; font-weight:bold; font-size:1.1em'>Đơn vị tính</span></td>";
        //strTable += "\n<td align='center' class='cssTableView' style='width:12%;' nowrap='nowrap'><span style='font-family:Times New Roman; font-weight:bold; font-size:1.1em'>Đơn giá (VNĐ)</span></td>";
        strTable += "\n<td align='center' class='cssTableView' style='width:12%;' nowrap='nowrap'><span style='font-family:Times New Roman; font-weight:bold; font-size:1.1em'>Thành tiền (VNĐ)</span></td>";
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
            + "{font-family: Times New Roman; font-size: 1.1em;font-weight:normal;border: 1px #000000 solid;}"
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
            string strNamFile = "F706_BaoCaoTongHopCongViecGVCM" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + ".xls";
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
    protected void m_cbo_thang_dat_hang_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            load_data_2_grv();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_trang_thai_cv_loc_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            load_data_2_grv();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_grv_gd_assign_su_kien_cho_giang_vien_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            m_grv_gd_assign_su_kien_cho_giang_vien.PageIndex = e.NewPageIndex;
            load_data_2_grv();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_nam_dat_hang_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            load_data_2_grv();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    #endregion
}