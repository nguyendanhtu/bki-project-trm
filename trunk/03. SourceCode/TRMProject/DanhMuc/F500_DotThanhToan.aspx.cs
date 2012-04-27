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

public partial class DanhMuc_F500_DotThanhToan : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
     {
         m_lbl_mess.Text = "";
        if (!IsPostBack)
        {
            load_data_2_cbo_don_vi_tt();
            load_data_2_cbo_trang_thai_dot_tt();
            load_data_2_grid();
        }
    }

    #region Members
    US_CM_DM_TU_DIEN m_us_cm_dm_tu_dien = new US_CM_DM_TU_DIEN();
    DS_CM_DM_TU_DIEN m_ds_cm_dm_tu_dien = new DS_CM_DM_TU_DIEN();
    US_V_DM_DOT_THANH_TOAN m_us_v_dm_dot_thanh_toan = new US_V_DM_DOT_THANH_TOAN();
    DS_V_DM_DOT_THANH_TOAN m_ds_v_dm_dot_thanh_toan = new DS_V_DM_DOT_THANH_TOAN();
    #endregion

    #region Public Interfaces
    public string mapping_don_vi_thanh_toan(decimal ip_dc_id_don_vi_tt)
    {
        US_DM_DON_VI_THANH_TOAN v_us_dm_don_vi_tt = new US_DM_DON_VI_THANH_TOAN(ip_dc_id_don_vi_tt);
        if (!v_us_dm_don_vi_tt.IsIDNull()) return v_us_dm_don_vi_tt.strTEN_DON_VI;
        return "";
    }
    public string mapping_trang_thai_dot_thanh_toan(decimal ip_dc_id_trang_thai_dot_tt)
    {
        US_CM_DM_TU_DIEN v_us_dm_tu_dien = new US_CM_DM_TU_DIEN(ip_dc_id_trang_thai_dot_tt);
        return v_us_dm_tu_dien.strTEN;
    }
    #endregion

    #region Private Method
    private void load_data_2_cbo_trang_thai_dot_tt()
    {
        try
        {
            // Đổ dữ liệu vào DS 
            m_us_cm_dm_tu_dien.FillDataset(m_ds_cm_dm_tu_dien, " WHERE ID_LOAI_TU_DIEN = " + (int)e_loai_tu_dien.TRANG_THAI_DOT_THANH_TOAN); // Đây là lấy theo điều kiện

            //TReo dữ liệu vào Dropdownlist loại hợp đồng
            // dây là giá trị hiển thị
            m_cbo_dm_trang_thai_dot_thanh_toan.DataTextField = CM_DM_TU_DIEN.TEN;
            m_cbo_dm_trang_thai_dot_thanh_toan_search.DataTextField = CM_DM_TU_DIEN.TEN;
            // Đây là giá trị thực
            m_cbo_dm_trang_thai_dot_thanh_toan.DataValueField = CM_DM_TU_DIEN.ID;
            m_cbo_dm_trang_thai_dot_thanh_toan_search.DataValueField = CM_DM_TU_DIEN.ID;

            m_cbo_dm_trang_thai_dot_thanh_toan.DataSource = m_ds_cm_dm_tu_dien.CM_DM_TU_DIEN;
            m_cbo_dm_trang_thai_dot_thanh_toan.DataBind();

            m_cbo_dm_trang_thai_dot_thanh_toan_search.DataSource = m_ds_cm_dm_tu_dien.CM_DM_TU_DIEN;
            m_cbo_dm_trang_thai_dot_thanh_toan_search.DataBind();
            m_cbo_dm_trang_thai_dot_thanh_toan.SelectedIndex = 0;
        }
        catch (Exception v_e)
        {
            throw v_e;

        }
    }
    private void load_data_2_cbo_don_vi_tt()
    {
        try
        {
            US_DM_DON_VI_THANH_TOAN v_us_dm_don_vi_tt = new US_DM_DON_VI_THANH_TOAN();
            DS_DM_DON_VI_THANH_TOAN v_ds_dm_don_vi_tt = new DS_DM_DON_VI_THANH_TOAN();
            // Đổ dữ liệu vào DS 
            v_us_dm_don_vi_tt.FillDataset(v_ds_dm_don_vi_tt);

            //TReo dữ liệu vào Dropdownlist loại hợp đồng
            // dây là giá trị hiển thị
            m_cbo_dm_loai_don_vi_thanh_toan.DataTextField = DM_DON_VI_THANH_TOAN.TEN_DON_VI;
            m_cbo_dm_loai_don_vi_thanh_toan_search.DataTextField = DM_DON_VI_THANH_TOAN.TEN_DON_VI;
            // Đây là giá trị thực
            m_cbo_dm_loai_don_vi_thanh_toan.DataValueField = DM_DON_VI_THANH_TOAN.ID;
            m_cbo_dm_loai_don_vi_thanh_toan_search.DataValueField = DM_DON_VI_THANH_TOAN.ID;

            m_cbo_dm_loai_don_vi_thanh_toan.DataSource = v_ds_dm_don_vi_tt.DM_DON_VI_THANH_TOAN;
            m_cbo_dm_loai_don_vi_thanh_toan.DataBind();

            m_cbo_dm_loai_don_vi_thanh_toan_search.DataSource = v_ds_dm_don_vi_tt.DM_DON_VI_THANH_TOAN;
            m_cbo_dm_loai_don_vi_thanh_toan_search.DataBind();

        }
        catch (Exception v_e)
        {
            throw v_e;

        }
    }
    private void load_data_2_grid()
    {
        decimal v_dc_id_trang_thai_dot_tt;
        decimal v_dc_id_don_vi_tt;
        decimal v_dc_thang_tt;
        v_dc_id_don_vi_tt = CIPConvert.ToDecimal(m_cbo_dm_loai_don_vi_thanh_toan_search.SelectedValue);
        v_dc_id_trang_thai_dot_tt = CIPConvert.ToDecimal(m_cbo_dm_trang_thai_dot_thanh_toan_search.SelectedValue);
        v_dc_thang_tt = CIPConvert.ToDecimal(m_cbo_thang_thanh_toan.SelectedValue);
        //DS_V_DM_DOT_THANH_TOAN v_ds_v_dm_dot_tt = new DS_V_DM_DOT_THANH_TOAN();
        //US_V_DM_DOT_THANH_TOAN v_us_v_dm_dot_tt = new US_V_DM_DOT_THANH_TOAN();
        // Search danh mục
        m_us_v_dm_dot_thanh_toan.load_danh_muc_dot_tt(v_dc_thang_tt, v_dc_id_don_vi_tt, v_dc_id_trang_thai_dot_tt, m_ds_v_dm_dot_thanh_toan);

        if (m_ds_v_dm_dot_thanh_toan.V_DM_DOT_THANH_TOAN.Rows.Count == 0)
        {
            m_lbl_thong_bao.Text = "Không có đợt thanh toán nào phù hợp";
            m_grv_dm_dot_thanh_toan.DataSource = m_ds_v_dm_dot_thanh_toan.V_DM_DOT_THANH_TOAN;
            m_grv_dm_dot_thanh_toan.DataBind();
            m_grv_dm_dot_thanh_toan.Visible = false;
            m_lbl_thong_bao.Visible = true;
        }
        else 
        {
            m_lbl_thong_bao.Visible = false;
            m_grv_dm_dot_thanh_toan.Visible = true;
            m_grv_dm_dot_thanh_toan.DataSource = m_ds_v_dm_dot_thanh_toan.V_DM_DOT_THANH_TOAN;
            m_grv_dm_dot_thanh_toan.DataBind();
        }
    }
    private void us_obj_2_form(US_V_DM_DOT_THANH_TOAN ip_us_v_dm_dot_thanh_toan)
    {
        m_cbo_dm_loai_don_vi_thanh_toan.SelectedValue = CIPConvert.ToStr(ip_us_v_dm_dot_thanh_toan.dcID_DON_VI_THANH_TOAN);
        m_txt_ma_dot_tt.Text = ip_us_v_dm_dot_thanh_toan.strMA_DOT_TT;
        m_txt_ten_dot_tt.Text = ip_us_v_dm_dot_thanh_toan.strTEN_DOT_TT;
        if (ip_us_v_dm_dot_thanh_toan.datNGAY_TT_DU_KIEN != CIPConvert.ToDatetime("01/01/1900", "dd/MM/yyyy"))
            m_dat_ngay_ket_thuc_du_kien.SelectedDate = ip_us_v_dm_dot_thanh_toan.datNGAY_TT_DU_KIEN;
        if (ip_us_v_dm_dot_thanh_toan.datNGAY_THU_CHUNG_TU != CIPConvert.ToDatetime("01/01/1900", "dd/MM/yyyy"))
            m_dat_ngay_thu_chung_tu.SelectedDate = ip_us_v_dm_dot_thanh_toan.datNGAY_THU_CHUNG_TU;
        m_cbo_dm_trang_thai_dot_thanh_toan.SelectedValue = CIPConvert.ToStr(ip_us_v_dm_dot_thanh_toan.dcID_TRANG_THAI_DOT_TT);
        m_txt_ghi_chu.Text = ip_us_v_dm_dot_thanh_toan.strGHI_CHU;
    }
    private void form_2_us_obj(US_V_DM_DOT_THANH_TOAN op_us_v_dm_dot_thanh_toan)
    {
        System.Globalization.CultureInfo enUS = new System.Globalization.CultureInfo("en-US"); 
        op_us_v_dm_dot_thanh_toan.dcID_DON_VI_THANH_TOAN =CIPConvert.ToDecimal(m_cbo_dm_loai_don_vi_thanh_toan.SelectedValue);
        op_us_v_dm_dot_thanh_toan.strMA_DOT_TT = m_txt_ma_dot_tt.Text;
        op_us_v_dm_dot_thanh_toan.strTEN_DOT_TT = m_txt_ten_dot_tt.Text;
        // Đây là tình trạng không nhập ngày
        if (m_dat_ngay_ket_thuc_du_kien.SelectedDate == CIPConvert.ToDatetime("01/01/0001", "dd/MM/yyyy"))
        {
             string someScript;
            someScript = "<script language='javascript'>alert('Bạn phải nhập ngày kết thúc dự kiến ');</script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "onload", someScript);
            m_dat_ngay_ket_thuc_du_kien.Focus();
            return;
        }
        else op_us_v_dm_dot_thanh_toan.datNGAY_TT_DU_KIEN = m_dat_ngay_ket_thuc_du_kien.SelectedDate;

        if (m_dat_ngay_thu_chung_tu.SelectedDate == CIPConvert.ToDatetime("01/01/0001", "dd/MM/yyyy"))
        {
            string someScript;
            someScript = "<script language='javascript'>alert('Bạn phải nhập ngày thu chứng từ');</script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "onload", someScript);
            m_dat_ngay_thu_chung_tu.Focus();
            return;
        }
        else op_us_v_dm_dot_thanh_toan.datNGAY_THU_CHUNG_TU = m_dat_ngay_thu_chung_tu.SelectedDate;
        op_us_v_dm_dot_thanh_toan.dcID_TRANG_THAI_DOT_TT = CIPConvert.ToDecimal(m_cbo_dm_trang_thai_dot_thanh_toan.SelectedValue);
        op_us_v_dm_dot_thanh_toan.strGHI_CHU = m_txt_ghi_chu.Text;
    }
    private void reset_control()
    {
        m_txt_ma_dot_tt.Text = "";
        m_txt_ghi_chu.Text = "";
        m_txt_ten_dot_tt.Text = "";
        m_cbo_dm_loai_don_vi_thanh_toan.SelectedIndex = 0;
        m_cbo_dm_trang_thai_dot_thanh_toan.SelectedIndex = 0;
    }
    private bool check_exist_ma_dot_tt(string ip_str_ma_dot)
    {
        if (m_us_v_dm_dot_thanh_toan.check_exist_ma_dot_thanh_toan(ip_str_ma_dot)) return true;
        return false; // Nghĩa là chưa tồn tại
    }
    private void load_data_2_us_by_id(int ip_i_id)
    {
        decimal v_dc_id_dot_thanh_toan = CIPConvert.ToDecimal(m_grv_dm_dot_thanh_toan.DataKeys[ip_i_id].Value);
        hdf_id_dot_tt.Value = CIPConvert.ToStr(v_dc_id_dot_thanh_toan);
        //hdf_id.Value = v_dc_id_dm_mon_hoc.ToString();
        US_V_DM_DOT_THANH_TOAN v_us_dm_dot_tt = new US_V_DM_DOT_THANH_TOAN(v_dc_id_dot_thanh_toan);
        hdf_ma_dot_tt.Value = v_us_dm_dot_tt.strMA_DOT_TT;
        // Đẩy us lên form
        us_obj_2_form(v_us_dm_dot_tt);
        m_cmd_tao_moi.Enabled = false;
    }
    // Nếu xóa đợt thanh toán, các thanh toán của đợt đó sẽ bị del luôn
    private void load_data_2_us_and_del(int ip_i_id)
    {
        decimal v_dc_id_dot_thanh_toan = CIPConvert.ToDecimal(m_grv_dm_dot_thanh_toan.DataKeys[ip_i_id].Value);
        m_us_v_dm_dot_thanh_toan.dcID = v_dc_id_dot_thanh_toan;
        m_us_v_dm_dot_thanh_toan.DeleteByID(v_dc_id_dot_thanh_toan);
        m_lbl_mess.Text = "Xóa bản ghi thành công";
        m_lbl_mess.Visible = true;
        load_data_2_grid();
    }
    // Nếu đợt thanh toán này chưa được sử dụng,hay chưa đc làm dự toán thì sẽ đc quyền Update nội dung bên trong đợt thanh toán
     private bool enable_update_dot_thanh_toan()
    {
         // Nếu đã có thanh toán trong đợt thanh toán và lại chỉnh sửa mã đợt thanh toán --> không sửa được nữa
        if (get_the_number_of_payments_by_dot_tt(hdf_ma_dot_tt.Value) > 0 && !hdf_ma_dot_tt.Value.Equals(m_txt_ma_dot_tt.Text.Trim()))
            return false;
        return true;
    }
     private int get_the_number_of_payments_by_dot_tt(string ip_str_ma_dot_tt)
     {
         US_V_GD_THANH_TOAN v_us_v_gd_tt = new US_V_GD_THANH_TOAN();
         DS_V_GD_THANH_TOAN v_ds_v_gd_tt = new DS_V_GD_THANH_TOAN();
         v_us_v_gd_tt.FillDataset(v_ds_v_gd_tt, " WHERE SO_PHIEU_THANH_TOAN='"+ip_str_ma_dot_tt+"'");
         return v_ds_v_gd_tt.V_GD_THANH_TOAN.Rows.Count;
     }
     private string mapping_date(object ip_obj_date)
     {
         if (ip_obj_date.GetType() == typeof(DBNull)) return "";
         return CIPConvert.ToStr(ip_obj_date,"dd/MM/yyyy");
     }
     private string mapping_string(object ip_obj_string)
     {
         if (ip_obj_string.GetType() == typeof(DBNull)) return "";
         return CIPConvert.ToStr(ip_obj_string);
     }
    #endregion

     #region Export Excel
     private void loadDSExprort(ref string strTable)
     {
         int v_i_so_thu_tu = 0;
         load_data_2_grid();
         // Mỗi cột dữ liệu ứng với từng dòng là label
         foreach (DataRow grv in this.m_ds_v_dm_dot_thanh_toan.V_DM_DOT_THANH_TOAN.Rows)
         {
             strTable += "\n<tr>";
             strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + ++v_i_so_thu_tu + "</td>";
             strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + CIPConvert.ToStr(grv[V_DM_DOT_THANH_TOAN.MA_DOT_TT]).Trim() + "</td>"; // Mã đợt thanh toán
             strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + CIPConvert.ToStr(grv[V_DM_DOT_THANH_TOAN.TEN_DOT_TT]).Trim() + "</td>"; // Tên đợt thanh toán
             strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + CIPConvert.ToStr(grv[V_DM_DOT_THANH_TOAN.DON_VI_THANH_TOAN]).Trim() + "</td>"; // ĐV thanh toán
             strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + CIPConvert.ToStr(grv[V_DM_DOT_THANH_TOAN.TRANG_THAI_DOT_TT]).Trim() + "</td>"; // Trạng thái đợt thanh toán
             strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + CIPConvert.ToStr(grv[V_DM_DOT_THANH_TOAN.NGAY_TT_DU_KIEN],"dd/MM/yyyy") + "</td>";
             strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_date(grv[V_DM_DOT_THANH_TOAN.NGAY_THU_CHUNG_TU]) + "</td>";
             strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_string(grv[V_DM_DOT_THANH_TOAN.GHI_CHU])+ "</td>";
             strTable += "\n</tr>";
         }
     }

     private void loadTieuDe(ref string strTable)
     {
         // Định nghĩa table
         strTable += "<table cellpadding='2' cellspacing='0' class='cssTableReport'>";
         strTable += "\n<tr>";
         strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
         strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
         strTable += "\n<td><align='center' class='cssTableView' style='width: 100%;  height: 40px; font-size: large; color:White; background-color:#810C15;' nowrap='wrap'>DANH SÁCH ĐỢT THANH TOÁN" + "</td>";
         strTable += "\n</tr>";
         strTable += "\n</table>";

         //table noi dung
         strTable += "<table cellpadding='2' cellspacing='0' class='cssTableReport'>";
         strTable += "\n<tr>";
         strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>STT</td>";
         strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Mã đợt thanh toán</td>";
         strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Tên đợt thanh toán</td>";
         strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'Đơn vị TT</td>";
         strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Trạng thái đợt TT</td>";
         strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Ngày thanh toán dự kiến</td>";
         strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Ngày thu chứng từ</td>";
         strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Ghi chú</td>";
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
    protected void m_grv_dm_dot_thanh_toan_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            //m_cbo_dm_trang_thai_dot_thanh_toan.Enabled = true;
            load_data_2_us_by_id(e.NewSelectedIndex);
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_grv_dm_dot_thanh_toan_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
         try
        {
            load_data_2_us_and_del(e.RowIndex);
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_grv_dm_dot_thanh_toan_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
         try
        {
            m_grv_dm_dot_thanh_toan.PageIndex = e.NewPageIndex;
            load_data_2_grid();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cmd_tao_moi_Click(object sender, EventArgs e)
    {
        try
        {
            if(check_exist_ma_dot_tt(m_txt_ma_dot_tt.Text.Trim()))
            {
              string someScript;
              someScript = "<script language='javascript'>alert('Mã đợt thanh toán này đã tồn tại');</script>";
              Page.ClientScript.RegisterStartupScript(this.GetType(), "onload", someScript);
              return;
            }
            form_2_us_obj(m_us_v_dm_dot_thanh_toan);
            m_us_v_dm_dot_thanh_toan.Insert();
            m_lbl_mess.Visible = true;
            m_lbl_mess.Text = "Thêm đợt thanh toán thành công";
            reset_control();
            load_data_2_grid();
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
            if (hdf_id_dot_tt.Value == "")
            {
                string someScript;
                someScript = "<script language='javascript'>alert('Bạn chưa chọn nội dung cần cập nhật');</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "onload", someScript);
                m_dat_ngay_ket_thuc_du_kien.Focus();
                return;
            }
            if (!enable_update_dot_thanh_toan())
            {
                m_txt_ma_dot_tt.Text = hdf_ma_dot_tt.Value;
                string script;
                script = "<script language='javascript'>alert('Không thể thay đổi thông tin mã đợt thanh toán do đã tồn tại giao dịch thanh toán cho đợt thanh toán này');</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "onload", script);
                return;
            }
            form_2_us_obj(m_us_v_dm_dot_thanh_toan);
            m_us_v_dm_dot_thanh_toan.dcID =CIPConvert.ToDecimal(hdf_id_dot_tt.Value);
            m_us_v_dm_dot_thanh_toan.Update();
            m_lbl_mess.Text = "Cập nhật thông tin thành công";
            load_data_2_grid();
            reset_control();
            m_cmd_tao_moi.Enabled = true;
        }
        catch (Exception v_e)
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
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_dm_loai_don_vi_thanh_toan_search_SelectedIndexChanged(object sender, EventArgs e)
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
    protected void m_cbo_dm_trang_thai_dot_thanh_toan_search_SelectedIndexChanged(object sender, EventArgs e)
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
    protected void m_cbo_thang_thanh_toan_SelectedIndexChanged(object sender, EventArgs e)
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
            string strNamFile = "DSDotThanhToan" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + ".xls";
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