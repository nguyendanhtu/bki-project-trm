using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IP.Core.IPCommon;
using WebDS;
using WebDS.CDBNames;
using WebUS;
using System.Data;
using System.Web.UI.HtmlControls;
using IP.Core.IPData;
using IP.Core.IPUserService;

public partial class DanhMuc_F106_HoSo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            m_lbl_mess.Text = "";
            if (m_init_mode == DataEntryFormMode.UpdateDataState)
            {
                m_cmd_tao_moi.Enabled = false;
            }
            else
            {
                m_cmd_tao_moi.Enabled = true;
            }

            if (!this.IsPostBack)
            {
                load_2_cbo_giang_vien();
                load_2_cbo_don_vi_thanh_toan();
                load_2_cbo_giang_trang_thai();
                load_data_2_grid();
            }
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    #region Data Structures
    public enum e_loai_tu_dien
    {
        PHAN_QUYEN = 1
        ,
        DIA_DIEM_QUAN_LY = 2
            ,
        DON_VI_QUAN_LY_CHINH = 3
            ,
        LEVEL_GIANG_VIEN = 4
            ,
        loai_su_kien = 5
            ,
        NGANH_DAO_TAO = 6
            ,
        DON_VI_TINH = 7
            ,
        TRANG_THAI_HOP_DONG_KHUNG = 8
            ,
        TRANG_THAI_GIANG_VIEN = 9
            ,
        MA_TAN_SUAT = 10
            ,
        LOAI_SU_KIEN = 19
            ,
        TRANG_THAI_SU_KIEN = 20
            , TRANG_THAI_HO_SO_GV = 23

    }
    #endregion

    #region Members
    US_CM_DM_TU_DIEN m_us_cm_dm_tu_dien = new US_CM_DM_TU_DIEN();
    DS_CM_DM_TU_DIEN m_ds_cm_dm_tu_dien = new DS_CM_DM_TU_DIEN();
    DS_DM_DON_VI_THANH_TOAN m_ds_dm_don_vi_thanh_toan = new DS_DM_DON_VI_THANH_TOAN();
    US_DM_DON_VI_THANH_TOAN m_us_dm_don_vi_thanh_toan = new US_DM_DON_VI_THANH_TOAN();
    DS_V_DM_GIANG_VIEN m_ds_dm_giang_vien = new DS_V_DM_GIANG_VIEN();
    US_V_DM_GIANG_VIEN m_us_dm_giang_vien = new US_V_DM_GIANG_VIEN();
    DS_DM_HO_SO_GIANG_VIEN m_ds_dm_ho_so_giang_vien = new DS_DM_HO_SO_GIANG_VIEN();
    US_DM_HO_SO_GIANG_VIEN m_us_dm_ho_so_giang_vien = new US_DM_HO_SO_GIANG_VIEN();
    DataEntryFormMode m_init_mode = DataEntryFormMode.ViewDataState;
    #endregion

    #region Private Methods
    private void load_2_cbo_giang_vien()
    {
        DS_V_DM_GIANG_VIEN v_ds_dm_giang_vien = new DS_V_DM_GIANG_VIEN();
        US_V_DM_GIANG_VIEN v_us_dm_giang_vien = new US_V_DM_GIANG_VIEN();
        try
        {
            v_us_dm_giang_vien.FillDataset(v_ds_dm_giang_vien, " ORDER BY HO_VA_TEN_DEM, TEN_GIANG_VIEN");
            m_cbo_loc_giang_vien.Items.Add(new ListItem("Tất cả", "0"));
            for (int v_i = 0; v_i < v_ds_dm_giang_vien.V_DM_GIANG_VIEN.Rows.Count; v_i++)
            {
                m_cbo_giang_vien.Items.Add(new ListItem(v_ds_dm_giang_vien.V_DM_GIANG_VIEN.Rows[v_i][V_DM_GIANG_VIEN.HO_VA_TEN_DEM].ToString().TrimEnd() + " " + v_ds_dm_giang_vien.V_DM_GIANG_VIEN.Rows[v_i][V_DM_GIANG_VIEN.TEN_GIANG_VIEN].ToString(), v_ds_dm_giang_vien.V_DM_GIANG_VIEN.Rows[v_i][V_DM_GIANG_VIEN.ID].ToString()));
                m_cbo_loc_giang_vien.Items.Add(new ListItem(v_ds_dm_giang_vien.V_DM_GIANG_VIEN.Rows[v_i][V_DM_GIANG_VIEN.HO_VA_TEN_DEM].ToString().TrimEnd() + " " + v_ds_dm_giang_vien.V_DM_GIANG_VIEN.Rows[v_i][V_DM_GIANG_VIEN.TEN_GIANG_VIEN].ToString(), v_ds_dm_giang_vien.V_DM_GIANG_VIEN.Rows[v_i][V_DM_GIANG_VIEN.ID].ToString()));
            }
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    private void load_2_cbo_don_vi_thanh_toan()
    {
        DS_DM_DON_VI_THANH_TOAN v_ds_dm_don_vi_thanh_toan = new DS_DM_DON_VI_THANH_TOAN();
        US_DM_DON_VI_THANH_TOAN v_us_dm_don_vi_thanh_toan = new US_DM_DON_VI_THANH_TOAN();
        try
        {
            v_us_dm_don_vi_thanh_toan.FillDataset(v_ds_dm_don_vi_thanh_toan, " ORDER BY TEN_DON_VI");
            //Load len combo don vi tt de insert
            m_cbo_don_vi_thanh_toan.DataSource = v_ds_dm_don_vi_thanh_toan.DM_DON_VI_THANH_TOAN;
            m_cbo_don_vi_thanh_toan.DataValueField = DM_DON_VI_THANH_TOAN.ID;
            m_cbo_don_vi_thanh_toan.DataTextField = DM_DON_VI_THANH_TOAN.TEN_DON_VI;
            m_cbo_don_vi_thanh_toan.DataBind();
            //thêm tất cả
            DataRow v_dr_all = v_ds_dm_don_vi_thanh_toan.DM_DON_VI_THANH_TOAN.NewDM_DON_VI_THANH_TOANRow();
            v_dr_all[DM_DON_VI_THANH_TOAN.ID] = 0;
            v_dr_all[DM_DON_VI_THANH_TOAN.TEN_DON_VI] = "Tất cả";
            v_ds_dm_don_vi_thanh_toan.EnforceConstraints = false;
            v_ds_dm_don_vi_thanh_toan.DM_DON_VI_THANH_TOAN.Rows.InsertAt(v_dr_all, 0);

            //Load len bo loc don vi tt
            m_cbo_loc_don_vi_thanh_toan.DataSource = v_ds_dm_don_vi_thanh_toan.DM_DON_VI_THANH_TOAN;
            m_cbo_loc_don_vi_thanh_toan.DataValueField = DM_DON_VI_THANH_TOAN.ID;
            m_cbo_loc_don_vi_thanh_toan.DataTextField = DM_DON_VI_THANH_TOAN.TEN_DON_VI;
            m_cbo_loc_don_vi_thanh_toan.DataBind();
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    private void load_2_cbo_giang_trang_thai()
    {
        try
        {
            m_ds_cm_dm_tu_dien.CM_DM_TU_DIEN.Clear();
            // Đổ dữ liệu vào DS 
            m_us_cm_dm_tu_dien.FillDataset(m_ds_cm_dm_tu_dien, " WHERE ID_LOAI_TU_DIEN = " + (int)e_loai_tu_dien.TRANG_THAI_HO_SO_GV); // Đây là lấy theo điều kiện

            //TReo dữ liệu vào Dropdownlist loại hợp đồng
            // dây là giá trị hiển thị
            m_cbo_trang_thai.DataTextField = CM_DM_TU_DIEN.TEN;
            // Đây là giá trị thực
            m_cbo_trang_thai.DataValueField = CM_DM_TU_DIEN.ID;

            m_cbo_trang_thai.DataSource = m_ds_cm_dm_tu_dien.CM_DM_TU_DIEN;
            m_cbo_trang_thai.DataBind();
            //Load len bo loc de search
            m_cbo_loc_trang_thai.DataTextField = CM_DM_TU_DIEN.TEN;
            m_cbo_loc_trang_thai.DataValueField = CM_DM_TU_DIEN.ID;
            m_cbo_loc_trang_thai.DataSource = m_ds_cm_dm_tu_dien.CM_DM_TU_DIEN;
            m_cbo_loc_trang_thai.DataBind();
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
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
    public string get_mapping_ma_to_ten(object ip_ma_tu_dien)
    {
        US_CM_DM_TU_DIEN v_us_cm_dm = new US_CM_DM_TU_DIEN(CIPConvert.ToDecimal(ip_ma_tu_dien));
        return v_us_cm_dm.strTEN;
    }
    private void load_data_2_grid()
    {
        try
        {
            string v_str_ngay_bat_dau_tu = "01/01/1900", v_str_ngay_ket_thuc_tu = "01/01/1900";
            if (m_dat_ngay_bat_dau_tu.SelectedDate != CIPConvert.ToDatetime("01/01/0001", "dd/MM/yyyy")) v_str_ngay_bat_dau_tu = CIPConvert.ToStr(m_dat_ngay_bat_dau_tu.SelectedDate, "dd/MM/yyyy");
            if (m_dat_ngay_ket_thuc_tu.SelectedDate != CIPConvert.ToDatetime("01/01/0001", "dd/MM/yyyy")) v_str_ngay_ket_thuc_tu = CIPConvert.ToStr(m_dat_ngay_ket_thuc_tu.SelectedDate, "dd/MM/yyyy");

            m_us_dm_ho_so_giang_vien.fill_data_by_search(CIPConvert.ToDecimal(m_cbo_loc_giang_vien.SelectedValue)
                            , CIPConvert.ToDecimal(m_cbo_loc_don_vi_thanh_toan.SelectedValue)
                            , v_str_ngay_bat_dau_tu
                            , v_str_ngay_ket_thuc_tu
                            , CIPConvert.ToDecimal(m_cbo_loc_trang_thai.SelectedValue)
                            , m_ds_dm_ho_so_giang_vien
                            );
            m_grv_dm_ho_so.DataSource = m_ds_dm_ho_so_giang_vien.DM_HO_SO_GIANG_VIEN;
            m_grv_dm_ho_so.DataBind();
            m_lbl_thong_bao.Text = "Kết quả lọc dữ liệu: " + m_ds_dm_ho_so_giang_vien.DM_HO_SO_GIANG_VIEN.Rows.Count + " bản ghi";
            m_lbl_thong_bao.Visible = true;
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    private void load_data_2_us_by_id(int ip_i_id)
    {
        decimal v_dc_id_dm_ho_so = CIPConvert.ToDecimal(m_grv_dm_ho_so.DataKeys[ip_i_id].Value);
        hdf_id.Value = v_dc_id_dm_ho_so.ToString();
        US_DM_HO_SO_GIANG_VIEN v_us_dm_ho_so_giang_vien = new US_DM_HO_SO_GIANG_VIEN(v_dc_id_dm_ho_so);
        // Đẩy us lên form
        us_obj_2_form(v_us_dm_ho_so_giang_vien);
    }
    private void delete_row(int i_int_row_index)
    {
        try
        {
            decimal v_dc_id = CIPConvert.ToDecimal(m_grv_dm_ho_so.DataKeys[i_int_row_index].Value);
            m_us_dm_ho_so_giang_vien.DeleteByID(v_dc_id);
            m_lbl_mess.Text = "Xóa bản ghi thành công.";
            load_data_2_grid();
        }
        catch (Exception v_e)
        {
            m_lbl_mess.Text = "Lỗi trong quá trình xóa bản ghi.";
            throw v_e;
        }
    }

    private void loadDSExprort(ref string strTable)
    {
        int v_i_so_thu_tu = 0;
        load_data_2_grid();
        // Mỗi cột dữ liệu ứng với từng dòng là label
        foreach (DataRow grv in this.m_ds_dm_ho_so_giang_vien.DM_HO_SO_GIANG_VIEN.Rows)
        {
            strTable += "\n<tr>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + ++v_i_so_thu_tu + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + get_mapping_ten_giang_vien(grv[HO_SO_GIANG_VIEN.ID_GIANG_VIEN]).ToString() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + get_mapping_ten_don_vi_thanh_toan(grv[HO_SO_GIANG_VIEN.ID_DON_VI_THANH_TOAN]).ToString() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + CIPConvert.ToStr(grv[HO_SO_GIANG_VIEN.NGAY_CAP_NHAT]) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + get_mapping_ma_to_ten(grv[HO_SO_GIANG_VIEN.ID_TRANG_THAI]) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + (grv[HO_SO_GIANG_VIEN.GHI_CHU]).ToString() + "</td>";
            strTable += "\n</tr>";
        }
    }

    private void loadTieuDe(ref string strTable)
    {
        strTable += "<table cellpadding='2' cellspacing='0' class='cssTableReport'>";
        strTable += "\n<tr>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width: 100%;  height: 40px; font-size: large; color:White; background-color:#810C15;' nowrap='wrap'>TRM106 - BÁO CÁO HỒ SƠ GIẢNG VIÊN " + "</td>";
        strTable += "\n</tr>";
        //
        //
        strTable += "\n<tr>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>Giảng viên: " + m_cbo_loc_giang_vien.SelectedItem.Text + "</td>";
        strTable += "\n</tr>";
        //
        strTable += "\n<tr>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>Đơn vị thanh toán: " + m_cbo_loc_don_vi_thanh_toan.SelectedItem.Text + "</td>";
        strTable += "\n</tr>";

        strTable += "\n<tr>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'> Ngày cập nhật - Từ ngày: "; if (m_dat_ngay_bat_dau_tu.SelectedDate != CIPConvert.ToDatetime("01/01/0001", "dd/MM/yyyy")) { strTable += CIPConvert.ToStr(m_dat_ngay_bat_dau_tu.SelectedDate); }; strTable += "      Đến ngày:"; if (m_dat_ngay_ket_thuc_tu.SelectedDate != CIPConvert.ToDatetime("01/01/0001", "dd/MM/yyyy")) { strTable += CIPConvert.ToStr(m_dat_ngay_ket_thuc_tu.SelectedDate); }; strTable += "</td>";
        strTable += "\n</tr>";
        //
        strTable += "\n<tr>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>Trạng thái: " + m_cbo_loc_trang_thai.SelectedItem.Text + " </td>";
        strTable += "\n</tr>";

        strTable += "\n</table>";

        //table noi dung
        strTable += "<table cellpadding='2' cellspacing='0' class='cssTableReport'>";
        strTable += "\n<tr>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>STT</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Giảng viên</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Đơn vị thanh toán</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Ngày cập nhật</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Trạng thái</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Ghi chú</td>";
        strTable += "\n</tr>";
        //loadGridExprort(ref strTable);
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
    private void save_excel(string i_str_file_name)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition",
         "attachment;filename=GridViewExport.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        // Bỏ phân trang - Nếu chỉ muỗn Export Trang hiện hành thì chọn =true
        m_grv_dm_ho_so.AllowPaging = false;
        m_grv_dm_ho_so.DataBind();
        m_grv_dm_ho_so.RenderControl(hw);
        //Thay đổi Style
        string style = @"";
        Response.Write(style);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }

    private void form_2_us_object(US_DM_HO_SO_GIANG_VIEN ip_us_dm_ho_so_giang_vien)
    {
        ip_us_dm_ho_so_giang_vien.strGHI_CHU = m_txt_ghi_chu.Text.Trim();
        ip_us_dm_ho_so_giang_vien.dcID_GIANG_VIEN = CIPConvert.ToDecimal(m_cbo_giang_vien.SelectedValue);
        ip_us_dm_ho_so_giang_vien.dcID_DON_VI_THANH_TOAN = CIPConvert.ToDecimal(m_cbo_don_vi_thanh_toan.SelectedValue);
        ip_us_dm_ho_so_giang_vien.dcID_TRANG_THAI = CIPConvert.ToDecimal(m_cbo_trang_thai.SelectedValue);
    }

    private void us_obj_2_form(US_DM_HO_SO_GIANG_VIEN ip_us_dm_ho_so_giang_vien)
    {
        m_txt_ghi_chu.Text = ip_us_dm_ho_so_giang_vien.strGHI_CHU;
        m_cbo_trang_thai.SelectedValue = CIPConvert.ToStr(ip_us_dm_ho_so_giang_vien.dcID_TRANG_THAI);
        m_cbo_giang_vien.SelectedValue = CIPConvert.ToStr(ip_us_dm_ho_so_giang_vien.dcID_GIANG_VIEN);
        m_cbo_don_vi_thanh_toan.SelectedValue = CIPConvert.ToStr(ip_us_dm_ho_so_giang_vien.dcID_DON_VI_THANH_TOAN);
    }
    private void reset_control()
    {
        m_txt_ghi_chu.Text = "";
    }
    #endregion
    //
    //
    // Event Hanlder
    //
    //
    private bool check_exist_giang_vien_dv_tt(decimal ip_id_giang_vien, decimal ip_id_don_vi_tt, out string op_str_du_an_trung)
    {
        m_us_dm_ho_so_giang_vien.check_trung_ma_du_an(m_ds_dm_ho_so_giang_vien, ip_id_giang_vien, ip_id_don_vi_tt);
        op_str_du_an_trung = "";
        if (m_ds_dm_ho_so_giang_vien.DM_HO_SO_GIANG_VIEN.Rows.Count > 0)
        {
            op_str_du_an_trung = "Đã tồn tại bản ghi này.";
            return false;
        }
        return true;
    }
    protected void m_cmd_tao_moi_Click(object sender, EventArgs e)
    {
        try
        {
            string v_str_result = "";
            if (!check_exist_giang_vien_dv_tt(CIPConvert.ToDecimal(m_cbo_giang_vien.SelectedValue), CIPConvert.ToDecimal(m_cbo_don_vi_thanh_toan.SelectedValue), out v_str_result))
            {
                string v_str_script = string.Format("<script language='javascript'> alert('{0}'); </script>", v_str_result);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Oncheck", v_str_script);
                return;
            }
            if (m_init_mode == DataEntryFormMode.UpdateDataState) return;
            form_2_us_object(m_us_dm_ho_so_giang_vien);
            m_us_dm_ho_so_giang_vien.Insert();
            m_lbl_mess.Text = "Thêm bản ghi thành công !";
            reset_control();
            load_data_2_grid();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }

    protected void m_grv_dm_ho_so_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            m_init_mode = DataEntryFormMode.UpdateDataState;
            m_cmd_tao_moi.Enabled = false;
            m_lbl_mess.Text = "";
            load_data_2_us_by_id(e.NewSelectedIndex);
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }

    protected void m_cmd_cap_nhat_Click(object sender, EventArgs e)
    {
        try
        {
            if (hdf_id.Value == "")
            {
                m_lbl_mess.Text = "Bạn phải chọn nội dung cần Cập nhật";
                return;
            }
            form_2_us_object(m_us_dm_ho_so_giang_vien);
            m_us_dm_ho_so_giang_vien.dcID = CIPConvert.ToDecimal(hdf_id.Value);
            m_us_dm_ho_so_giang_vien.Update();
            reset_control();
            m_lbl_mess.Text = "Cập nhật dữ liệu thành công";
            m_grv_dm_ho_so.EditIndex = -1;
            m_init_mode = DataEntryFormMode.ViewDataState;
            load_data_2_grid();
        }
        catch (System.Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
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

    protected void m_grv_dm_ho_so_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            m_lbl_mess.Text = "";
            delete_row(e.RowIndex);
        }
        catch (Exception v_e)
        {
            // de su dung CsystemLog_301 bat buoc Site phai dat trong thu muc cap 1. Vi du: DanhMuc/Dictionary.aspx
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }

    protected void m_grv_dm_ho_so_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            m_grv_dm_ho_so.PageIndex = e.NewPageIndex;
            load_data_2_grid();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }

    protected void m_cmd_loc_du_lieu_Click(object sender, EventArgs e)
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

    protected void m_cmd_xuat_excel_Click(object sender, EventArgs e)
    {
        try
        {
            string html = loadExport();
            string strNamFile = "DS_DM_HO_SO_GIANG_VIEN" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + ".xls";
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
            // Response.End();
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }

    }
    protected void m_grv_dm_ho_so_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            m_init_mode = DataEntryFormMode.UpdateDataState;
            m_cmd_tao_moi.Enabled = false;
            m_lbl_mess.Text = "";
            load_data_2_us_by_id(e.NewEditIndex);
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
}