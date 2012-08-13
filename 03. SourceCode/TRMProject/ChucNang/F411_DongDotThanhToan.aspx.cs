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

public partial class ChucNang_F411_DongDotThanhToan : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        m_lbl_thong_bao.Visible = false;
        if (!IsPostBack)
        {
            //string v_str_ma_dot = m_cbo_dot_thanh_toan.SelectedValue;
            load_data_2_dot_tt();            
            if (m_cbo_dot_thanh_toan.Items.Count > 0)
            {
                fill_data_2_thong_tin_dot_tt(CIPConvert.ToDecimal(m_cbo_dot_thanh_toan.SelectedValue));
                m_cmd_dong_dot_tt.Enabled = true;
            }
            else
            {
                m_cmd_dong_dot_tt.Enabled = false;
                m_lbl_thong_bao1.Text = "Chưa có đợt thanh toán nào";
            }
            hdf_id_trang_thai_da_co_xac_nhan_gv.Value = CIPConvert.ToStr(ID_TRANG_THAI_THANH_TOAN.DA_CO_XAC_NHAN_CUA_GIANG_VIEN);
            hdf_id_trang_thai_ngan_hang_chuyen_khoan_khong_thanh_cong.Value = CIPConvert.ToStr(ID_TRANG_THAI_THANH_TOAN.NGAN_HANG_CHUYEN_KHOAN_KHONG_THANH_CONG);
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
    public string mapping_loai_hd(string ip_str_loai_hd)
    {
        if (ip_str_loai_hd.Equals("HL"))
            return "Học liệu";
        // Còn lại là hợp đồng vận hành
        return "Vận hành";
    }
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
    public string mapping_trang_thai_thanh_toan(decimal ip_dc_id_trang_thai_tt)
    {
        US_CM_DM_TU_DIEN v_us_dm_tu_dien = new US_CM_DM_TU_DIEN(ip_dc_id_trang_thai_tt);
        return v_us_dm_tu_dien.strTEN;
    }
    public string get_ma_dot_tt_by_id_dot(decimal ip_dc_ma_dot)
    {
        DS_V_DM_DOT_THANH_TOAN v_ds_dot_tt = new DS_V_DM_DOT_THANH_TOAN();
        US_V_DM_DOT_THANH_TOAN v_us_dot_thanh_toan = new US_V_DM_DOT_THANH_TOAN();
        v_us_dot_thanh_toan.FillDataset(v_ds_dot_tt, " WHERE ID = " + ip_dc_ma_dot);
        if (v_ds_dot_tt.V_DM_DOT_THANH_TOAN.Rows.Count == 0) return "";
        return CIPConvert.ToStr(v_ds_dot_tt.V_DM_DOT_THANH_TOAN.Rows[0][V_DM_DOT_THANH_TOAN.MA_DOT_TT]);
    }
    public string cut_description_string(string ip_str_description)
    {
        string[] v_des = ip_str_description.Split(' ');
        string v_str_result = "";
        for (int v_i = 0; v_i < v_des.Length - 1; v_i++)
        {
            v_str_result += v_des[v_i];
            v_str_result += " ";
        }
        return v_str_result.Trim();
    }
    public string mapping_url_by_id_trang_thai_tt(object ip_obj_id_trang_thai_tt)
    {

        return "";
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
        load_data_2_grid(get_ma_dot_tt_by_id_dot(CIPConvert.ToDecimal(m_cbo_dot_thanh_toan.SelectedValue)));
    }
    // Chỉ load lên những đợt thanh toán đang ở trạng thái 3 - đã thanh toán
    private void load_data_2_dot_tt()
    {
        DS_V_DM_DOT_THANH_TOAN v_ds_dot_thanh_toan = new DS_V_DM_DOT_THANH_TOAN();
        US_V_DM_DOT_THANH_TOAN v_us_dot_thanh_toan = new US_V_DM_DOT_THANH_TOAN();
        v_us_dot_thanh_toan.load_dot_thanh_toan_by_trang_thai(ID_TRANG_THAI_DOT_TT.DA_THANH_TOAN,v_ds_dot_thanh_toan);
        //v_us_dot_thanh_toan.FillDataset(v_ds_dot_thanh_toan, " WHERE ID_TRANG_THAI_DOT_TT = " + get_id_trang_thai_dot_tt_da_thanh_toan());
        // Không load đợt thanh toán kho lên
        for (int i = 0; i < v_ds_dot_thanh_toan.V_DM_DOT_THANH_TOAN.Rows.Count; i++)
        {
            if (CIPConvert.ToDecimal(v_ds_dot_thanh_toan.V_DM_DOT_THANH_TOAN.Rows[i][V_DM_DOT_THANH_TOAN.ID]) != get_id_of_dot_tt_kho())
                m_cbo_dot_thanh_toan.Items.Add(new ListItem(CIPConvert.ToStr(v_ds_dot_thanh_toan.V_DM_DOT_THANH_TOAN.Rows[i][V_DM_DOT_THANH_TOAN.TEN_DOT_TT]), CIPConvert.ToStr(v_ds_dot_thanh_toan.V_DM_DOT_THANH_TOAN.Rows[i][V_DM_DOT_THANH_TOAN.ID])));
        }
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
    private decimal get_id_of_dot_tt_kho()
    {
        US_V_DM_DOT_THANH_TOAN v_us_v_dm_dot_tt = new US_V_DM_DOT_THANH_TOAN();
        DS_V_DM_DOT_THANH_TOAN v_ds_v_dm_dot_tt = new DS_V_DM_DOT_THANH_TOAN();
        v_us_v_dm_dot_tt.FillDataset(v_ds_v_dm_dot_tt, " WHERE MA_DOT_TT LIKE '%KHO%'");
        if (v_ds_v_dm_dot_tt.V_DM_DOT_THANH_TOAN.Rows.Count == 0)
            return 25;
        return CIPConvert.ToDecimal(v_ds_v_dm_dot_tt.V_DM_DOT_THANH_TOAN.Rows[0][V_DM_DOT_THANH_TOAN.ID]);
    }
    // Hiển thị toàn bộ các thanh toán của đợt thanh toán này
    private void load_data_2_grid(string ip_str_ma_dot_tt)
    {
        if (ip_str_ma_dot_tt == "")
        {
            m_lbl_thong_bao1.Visible = true;
            m_lbl_thong_bao1.Text = "Chưa có đợt thanh toán nào đã thanh toán xong";
            return;
        }
        else
        {
            US_V_GD_THANH_TOAN v_us_gd_thanh_toan = new US_V_GD_THANH_TOAN();
            DS_V_GD_THANH_TOAN v_ds_gd_thanh_toan = new DS_V_GD_THANH_TOAN();
            // Hiển thị toàn bộ các thanh toán trong đợt thanh toán đang chọn
            v_us_gd_thanh_toan.f501_load_thanh_toan_by_ma_dot_tt_va_trang_thai_tt(ip_str_ma_dot_tt, 0, v_ds_gd_thanh_toan, CIPConvert.ToStr(Session["user_quyen"]));
            //v_us_gd_thanh_toan.FillDataset(v_ds_gd_thanh_toan, " WHERE SO_PHIEU_THANH_TOAN = N'" + ip_str_ma_dot_tt+"' ORDER BY ID");
            if (v_ds_gd_thanh_toan.V_GD_THANH_TOAN.Rows.Count == 0)
            {
                m_lbl_thong_bao1.Visible = true;
                m_lbl_thong_bao1.Text = "Chưa có Thanh toán nào ứng với Đợt thanh toán này";
            }
            m_grv_danh_sach_du_toan.DataSource = v_ds_gd_thanh_toan.V_GD_THANH_TOAN;
            m_grv_danh_sach_du_toan.DataBind();
            m_lbl_loc_du_lieu.Text = "Danh sách thanh toán trong đợt này: " + v_ds_gd_thanh_toan.V_GD_THANH_TOAN.Rows.Count + " thanh toán";
            if (v_ds_gd_thanh_toan.V_GD_THANH_TOAN.Rows.Count > 0)
            {
                m_grv_danh_sach_du_toan.Columns[0].Visible = false;
            }
        }
    }
    /// <summary>
    ///  Hàm này load các thanh toán chưa có xác nhận của giảng viên và bind lên lưới
    /// </summary>
    /// <param name="ip_str_ma_dot_tt">Mã đợt thanh toán</param>
    private void load_cac_thanh_toan_chua_duoc_xac_nhan_gv(string ip_str_ma_dot_tt)
    {
        m_us_gd_thanh_toan.FillDataset(m_ds_gd_thanh_toan, " WHERE SO_PHIEU_THANH_TOAN='" + ip_str_ma_dot_tt + "' AND ID_TRANG_THAI_THANH_TOAN <> " + hdf_id_trang_thai_da_co_xac_nhan_gv.Value + " ORDER BY ID DESC");
        if (m_ds_gd_thanh_toan.V_GD_THANH_TOAN.Rows.Count == 0)
        {
            if (m_grv_danh_sach_du_toan.Visible == true) m_grv_danh_sach_du_toan.Visible = false;
            return;
        }
        m_grv_danh_sach_du_toan.Visible = true;
        m_grv_danh_sach_du_toan.DataSource = m_ds_gd_thanh_toan.V_GD_THANH_TOAN;
        m_grv_danh_sach_du_toan.DataBind();
        m_grv_danh_sach_du_toan.Columns[0].Visible = true;
        m_lbl_loc_du_lieu.Text = "Danh sách các thanh toán chưa có xác nhận của giảng viên: " + m_ds_gd_thanh_toan.V_GD_THANH_TOAN.Rows.Count + " thanh toán";
    }
    /// <summary>
    /// Hàm này có chức năng cut đoạn mô tả ra mã đợt thanh toán
    /// </summary>
    /// <param name="ip_str_description">Mô tả của thanh toán</param>
    /// <param name="ip_str_old_ma_dot_tt">Đối số ra: lưu trữ mã đợt thanh toán ban đầu của thanh toán này</param>
    /// <returns>Mô tả ban đầu của thanh toán</returns>
    private string cut_description_string(string ip_str_description, ref string ip_str_old_ma_dot_tt)
    {
        string[] v_des = ip_str_description.Split(' ');
        string v_str_result = "";
        for (int v_i = 0; v_i < v_des.Length - 1; v_i++)
        {
            v_str_result += v_des[v_i];
            v_str_result += " ";
        }
        ip_str_old_ma_dot_tt = v_des[v_des.Length - 1];
        return v_str_result.Trim();
    }
    
    /// <summary>
    /// Hàm này kiểm tra trạng thái các thanh toán trong đợt thanh tóan (có cho đóng đợt thanh toán ko???). Cho đóng đợt thanh toán khi:
    /// + Khi tất cả các thanh toán có trong đợt đã ở trạng thái 5_DA_CO_XAC_NHAN_CUA_GIANG_VIEN
    /// + không có thanh toán nào của đợt này trong KHO có trạng thái: 3B_NGAN_HANG_CHUYEN_KHOAN_KHONG_THANH_CONG
    /// </summary>
    /// <param name="ip_str_ma_dot_tt">Mã của đợt thanh toán cần kiểm tra</param>
    private bool check_trang_thai_cac_thanh_toan_cua_dot_tt(string ip_str_ma_dot_tt)
    {
        // Check trạng thái các thanh toán trong đợt thanh toán
        US_V_GD_THANH_TOAN v_us_v_gd_thanh_toan = new US_V_GD_THANH_TOAN();
        DS_V_GD_THANH_TOAN v_ds_v_gd_thanh_toan = new DS_V_GD_THANH_TOAN();
        // Load các thanh toán có trạng thái khác với đã có xác nhận giảng viên
        v_us_v_gd_thanh_toan.FillDataset(v_ds_v_gd_thanh_toan, " WHERE SO_PHIEU_THANH_TOAN =N'" + ip_str_ma_dot_tt + "' AND ID_TRANG_THAI_THANH_TOAN <> " + hdf_id_trang_thai_da_co_xac_nhan_gv.Value + " ORDER BY ID");
        if (v_ds_v_gd_thanh_toan.V_GD_THANH_TOAN.Rows.Count > 0) return false;
        return true;
    }
    // Check trạng thái các thanh toán  trong KHO nằm trong đợt thanh toán này
    // Nếu có các thanh toán đó thì ta cho nó vào 1 ds để xuất ra màn hình
    private bool check_trang_thai_cac_thanh_toan_cua_dot_tt_trong_kho(string ip_str_ma_dot_tt, ref DS_V_GD_THANH_TOAN ip_ds_gd_thanh_toan)
    {
        US_V_GD_THANH_TOAN v_us_v_gd_thanh_toan = new US_V_GD_THANH_TOAN();
        // Láy tất cả các thanh toán trong kho mà có description giống với mã đợt thanh toán hiện 
        v_us_v_gd_thanh_toan.FillDataset(ip_ds_gd_thanh_toan, " WHERE SO_PHIEU_THANH_TOAN like '%KHO%' AND [DESCRIPTION] like N'%" + ip_str_ma_dot_tt + "%' AND ID_TRANG_THAI_THANH_TOAN = " + hdf_id_trang_thai_ngan_hang_chuyen_khoan_khong_thanh_cong.Value + " ORDER BY ID DESC");
        // Nếu ko có thanh toán nào phù hợp, nghĩa là ổn :)
        if (ip_ds_gd_thanh_toan.V_GD_THANH_TOAN.Rows.Count == 0) return true; 
        return false;
    }
    #endregion

    #region Events
    protected void m_cbo_dot_thanh_toan_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            fill_data_2_thong_tin_dot_tt(CIPConvert.ToDecimal(m_cbo_dot_thanh_toan.SelectedValue));
            m_cmd_dong_dot_tt.Enabled = true;
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cmd_dong_dot_tt_Click(object sender, EventArgs e)
    {
        try
        {
            m_us_dm_dot_thanh_toan.strMA_DOT_TT = get_ma_dot_tt_form_id(CIPConvert.ToDecimal(m_cbo_dot_thanh_toan.SelectedValue));
            if (!check_trang_thai_cac_thanh_toan_cua_dot_tt(m_us_dm_dot_thanh_toan.strMA_DOT_TT))
            {
                m_lbl_thong_bao.Text = "Đóng đợt thanh toán thất bại, vẫn còn thanh toán chưa có xác nhận của giảng viên";
                m_lbl_thong_bao.Visible = true;
                load_cac_thanh_toan_chua_duoc_xac_nhan_gv(m_us_dm_dot_thanh_toan.strMA_DOT_TT);
                return;
            }
            if (!check_trang_thai_cac_thanh_toan_cua_dot_tt_trong_kho(m_us_dm_dot_thanh_toan.strMA_DOT_TT,ref m_ds_gd_thanh_toan))
            {
                m_lbl_thong_bao.Text = "Đóng đợt thanh toán thất bại, vẫn còn thanh toán chưa được chuyển khoản thành công trong KHO";
                m_lbl_thong_bao.Visible = true;
                m_grv_danh_sach_du_toan.DataSource = m_ds_gd_thanh_toan;
                m_grv_danh_sach_du_toan.DataBind();
                m_grv_danh_sach_du_toan.Columns[0].Visible = true;
                m_lbl_loc_du_lieu.Text = "Danh sách các thanh toán chưa được chuyển khoản thành công: " + m_ds_gd_thanh_toan.V_GD_THANH_TOAN.Rows.Count + " thanh toán";
                return;
            }
            // Chuyển trạng thái của đợt thanh toán từ 3 sang 4
            m_us_dm_dot_thanh_toan.dong_dot_thanh_toan();
            string someScript;
            someScript = "<script language='javascript'>alert('Đã đóng đợt thanh toán thành công!'); </script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "onsucced", someScript);
            m_cbo_dot_thanh_toan.Items.Clear();
            load_data_2_dot_tt();
            if (m_cbo_dot_thanh_toan.Items.Count > 0)
            {
                fill_data_2_thong_tin_dot_tt(CIPConvert.ToDecimal(m_cbo_dot_thanh_toan.SelectedValue));
            }
            else
            {
                m_cmd_dong_dot_tt.Enabled = false;
                m_lbl_thong_bao1.Text = "Chưa có đợt thanh toán nào";
                m_grv_danh_sach_du_toan.DataSource = null;
                m_grv_danh_sach_du_toan.DataBind();
                m_lbl_loc_du_lieu.Text = "";
            }
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
    protected void m_grv_danh_sach_du_toan_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            m_grv_danh_sach_du_toan.PageIndex = e.NewPageIndex;
            load_data_2_grid(get_ma_dot_tt_by_id_dot(CIPConvert.ToDecimal(m_cbo_dot_thanh_toan.SelectedValue)));
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_grv_danh_sach_du_toan_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {      
        try
        {
            string v_str_function_url = string.Format("OpenSiteFromUrl('F410_ChinhSuaXacNhanGV.aspx?id_tt={0}');", CIPConvert.ToDecimal(m_grv_danh_sach_du_toan.DataKeys[e.NewSelectedIndex].Value));
            this.ClientScript.RegisterStartupScript(this.Page.GetType(), "ThemMoiLopMon", v_str_function_url, true);
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    #endregion
    
}