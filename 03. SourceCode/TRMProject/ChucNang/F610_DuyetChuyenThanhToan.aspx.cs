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

public partial class ChucNang_F610_DuyetChuyenThanhToan : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        m_lbl_thong_bao_sau_cap_nhat.Text = "";
        if (!IsPostBack)
        {
            load_data_2_cbo_trang_thai_cv_gv();
            load_data_2_cbo_ten_giang_vien();
            load_data_2_cbo_hop_dong_loc();
            load_data_2_grv();
        }
    }

    #region Members
    US_V_GD_GV_CONG_VIEC_MOI m_us_cong_viec_moi = new US_V_GD_GV_CONG_VIEC_MOI();
    DS_V_GD_GV_CONG_VIEC_MOI m_ds_cong_viec_moi = new DS_V_GD_GV_CONG_VIEC_MOI();
    #endregion

    #region Private Methods
    //private void load_data_2_excel_export()
    //{
    //    m_us_cong_viec_moi.loc_du_lieu_giang_vien_cong_viec_moi_all_gv(m_ds_cong_viec_moi, CIPConvert.ToDecimal(m_cbo_ten_giang_vien_loc.SelectedValue), CIPConvert.ToDecimal(m_cbo_so_hop_dong_loc.SelectedValue), CIPConvert.ToDecimal(m_cbo_trang_thai_cv_loc.SelectedValue));
    //}
    private void load_data_2_grv()
    {
        m_us_cong_viec_moi.loc_du_lieu_giang_vien_cong_viec_moi_all_gv(m_ds_cong_viec_moi,CIPConvert.ToDecimal(m_cbo_ten_giang_vien_loc.SelectedValue), CIPConvert.ToDecimal(m_cbo_so_hop_dong_loc.SelectedValue), CIPConvert.ToDecimal(m_cbo_trang_thai_cv_loc.SelectedValue));
        m_grv_gd_assign_su_kien_cho_giang_vien.DataSource = m_ds_cong_viec_moi.V_GD_GV_CONG_VIEC_MOI;
        m_grv_gd_assign_su_kien_cho_giang_vien.DataBind();
        m_lbl_ds_cv_gv.Text = "Duyệt chuyển thanh toán: " + m_ds_cong_viec_moi.V_GD_GV_CONG_VIEC_MOI.Rows.Count + " bản ghi";
        if (m_ds_cong_viec_moi.V_GD_GV_CONG_VIEC_MOI.Rows.Count == 0)
        {
            m_cmd_duyet_ke_hoach.Visible = false;
            if(m_cbo_trang_thai_cv_loc.SelectedValue.Equals(CIPConvert.ToStr(ID_TRANG_THAI_CONG_VIEC_GVCM.DA_DUYET_CHUYEN_THANH_TOAN)))
                m_lbl_thong_bao_sau_cap_nhat.Text = "Giảng viên này chưa có công việc nào được duyệt chuyển!";
            m_cmd_xuat_excel.Visible = false;
            m_cmd_huy_chuyen_duyet_thanh_toan.Visible = false;
        }
        else
        {
            m_cmd_duyet_ke_hoach.Visible = true;
            m_cmd_xuat_excel.Visible = true;
            decimal v_dc_tong_tien = get_sum_tien(m_ds_cong_viec_moi);
            m_grv_gd_assign_su_kien_cho_giang_vien.FooterRow.Cells[9].Text = CIPConvert.ToStr(v_dc_tong_tien, "#,###");
            m_lbl_thong_bao_sau_cap_nhat.Text = "";
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
    private void load_data_2_cbo_ten_giang_vien()
    {
        US_V_DM_GIANG_VIEN v_us_v_dm_giang_vien = new US_V_DM_GIANG_VIEN();
        DS_V_DM_GIANG_VIEN v_ds_v_dm_giang_vien = new DS_V_DM_GIANG_VIEN();

        v_us_v_dm_giang_vien.load_all_giang_vien_CM(v_ds_v_dm_giang_vien);
        m_cbo_ten_giang_vien_loc.Items.Add(new ListItem("Tất cả", "0"));
        for (int v_i = 0; v_i < v_ds_v_dm_giang_vien.V_DM_GIANG_VIEN.Rows.Count; v_i++)
        {
            m_cbo_ten_giang_vien_loc.Items.Add(new ListItem(CIPConvert.ToStr(v_ds_v_dm_giang_vien.V_DM_GIANG_VIEN.Rows[v_i][V_DM_GIANG_VIEN.HO_VA_TEN_DEM]).Trim() + " " + CIPConvert.ToStr(v_ds_v_dm_giang_vien.V_DM_GIANG_VIEN.Rows[v_i][V_DM_GIANG_VIEN.TEN_GIANG_VIEN]).Trim(), CIPConvert.ToStr(v_ds_v_dm_giang_vien.V_DM_GIANG_VIEN.Rows[v_i][V_DM_GIANG_VIEN.ID])));
        }

    }
    private void load_data_2_cbo_hop_dong_loc()
    {
        m_cbo_so_hop_dong_loc.Items.Clear();
        US_V_DM_HOP_DONG_KHUNG v_us_v_dm_hop_dong_khung = new US_V_DM_HOP_DONG_KHUNG();
        DS_V_DM_HOP_DONG_KHUNG v_ds_v_dm_hop_dong_khung = new DS_V_DM_HOP_DONG_KHUNG();
        v_us_v_dm_hop_dong_khung.load_hop_dong_by_id_giang_vien_cm_da_ky(CIPConvert.ToDecimal(m_cbo_ten_giang_vien_loc.SelectedValue), v_ds_v_dm_hop_dong_khung);

        //m_cbo_so_hop_dong_loc.Items.Add(new ListItem("Tất cả", "0"));
        for (int v_i = 0; v_i < v_ds_v_dm_hop_dong_khung.V_DM_HOP_DONG_KHUNG.Rows.Count; v_i++)
        {
            m_cbo_so_hop_dong_loc.Items.Add(new ListItem(CIPConvert.ToStr(v_ds_v_dm_hop_dong_khung.V_DM_HOP_DONG_KHUNG.Rows[v_i][V_DM_HOP_DONG_KHUNG.SO_HOP_DONG]), CIPConvert.ToStr(v_ds_v_dm_hop_dong_khung.V_DM_HOP_DONG_KHUNG.Rows[v_i][V_DM_HOP_DONG_KHUNG.ID])));
        }
    }
    private void visible_xuat_excel_button()
    {
        if (m_cbo_ten_giang_vien_loc.SelectedValue != "0" && m_cbo_trang_thai_cv_loc.SelectedValue.Equals(CIPConvert.ToStr(ID_TRANG_THAI_CONG_VIEC_GVCM.DA_DUYET_CHUYEN_THANH_TOAN)))
            m_cmd_xuat_excel.Visible = true;
        else m_cmd_xuat_excel.Visible = false;
    }
    private void visible_huy_duyet_button()
    {
        if (m_cbo_trang_thai_cv_loc.SelectedValue.Equals(CIPConvert.ToStr(ID_TRANG_THAI_CONG_VIEC_GVCM.DA_DUYET_CHUYEN_THANH_TOAN)))
            m_cmd_huy_chuyen_duyet_thanh_toan.Visible = true;
        else m_cmd_huy_chuyen_duyet_thanh_toan.Visible = false;
    }
    private string get_ngay_ky_hd_by_id(decimal ip_dc_ngay_ky_hd, ref string op_str_ten_mon)
    {
        US_DM_HOP_DONG_KHUNG v_us_dm_hop_dong_khung = new US_DM_HOP_DONG_KHUNG(ip_dc_ngay_ky_hd);
        US_DM_MON_HOC v_us_dm_mon_hoc = new US_DM_MON_HOC(v_us_dm_hop_dong_khung.dcID_MON1);
        op_str_ten_mon = v_us_dm_mon_hoc.strTEN_MON_HOC;
        if (v_us_dm_hop_dong_khung.dcID_MON2 > 0)
        {
            US_DM_MON_HOC v_us_dm_mon_hoc2 = new US_DM_MON_HOC(v_us_dm_hop_dong_khung.dcID_MON2);
            op_str_ten_mon += ", "+v_us_dm_mon_hoc2.strTEN_MON_HOC;
        }
        if (v_us_dm_hop_dong_khung.dcID_MON3 > 0)
        {
            US_DM_MON_HOC v_us_dm_mon_hoc3 = new US_DM_MON_HOC(v_us_dm_hop_dong_khung.dcID_MON3);
            op_str_ten_mon += ", " + v_us_dm_mon_hoc3.strTEN_MON_HOC;
        }
        if (v_us_dm_hop_dong_khung.dcID_MON4 > 0)
        {
            US_DM_MON_HOC v_us_dm_mon_hoc4 = new US_DM_MON_HOC(v_us_dm_hop_dong_khung.dcID_MON4);
            op_str_ten_mon += ", " + v_us_dm_mon_hoc4.strTEN_MON_HOC;
        }
        if (v_us_dm_hop_dong_khung.dcID_MON5 > 0)
        {
            US_DM_MON_HOC v_us_dm_mon_hoc5 = new US_DM_MON_HOC(v_us_dm_hop_dong_khung.dcID_MON5);
            op_str_ten_mon += ", " + v_us_dm_mon_hoc5.strTEN_MON_HOC;
        }
        if (v_us_dm_hop_dong_khung.dcID_MON6 > 0)
        {
            US_DM_MON_HOC v_us_dm_mon_hoc6 = new US_DM_MON_HOC(v_us_dm_hop_dong_khung.dcID_MON6);
            op_str_ten_mon += ", " + v_us_dm_mon_hoc6.strTEN_MON_HOC;
        }
        return CIPConvert.ToStr(v_us_dm_hop_dong_khung.datNGAY_KY, "dd/MM/yyyy");
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
    private string get_last_day_of_month()
    {
        DateTime today = DateTime.Today;
        DateTime lastDayOfThisMonth = new DateTime(today.Year, today.Month, 1).AddMonths(1).AddDays(-1);
        return CIPConvert.ToStr(lastDayOfThisMonth,"dd/MM/yyyy");
    }
    private string get_ngay_bdau_kthuc_mon(string ip_str_ghi_chu_thoi_gian)
    {
        string v_str_thoi_gian_bdau = "Từ ngày <span style='font-family:Times New Roman; font-weight:bold;font-size:1.1em'>";
        string[] v_str_thoi_gian_split = ip_str_ghi_chu_thoi_gian.Split('-');
        if (v_str_thoi_gian_split.Length >= 2)
        {
            v_str_thoi_gian_bdau += v_str_thoi_gian_split[0].Trim();
            v_str_thoi_gian_bdau += "</span>  Đến ngày   <span style='font-family:Times New Roman; font-weight:bold;font-size:1.1em'>";
            v_str_thoi_gian_bdau += v_str_thoi_gian_split[1].Trim();
        }
        else if (v_str_thoi_gian_split.Length == 1)
        {
            v_str_thoi_gian_bdau += v_str_thoi_gian_split[0].Trim();
            v_str_thoi_gian_bdau += "</span>  Đến ngày   <span style='font-family:Times New Roman; font-weight:bold;font-size:1.1em'>";
            v_str_thoi_gian_bdau += v_str_thoi_gian_bdau += get_last_day_of_month();
        }
        else
        {
            int v_i_month = DateTime.Now.Month - 1;
            int v_i_year = DateTime.Now.Year;
            if (v_i_month == 0)
            {
                v_i_month = 12;
                v_i_year = v_i_year - 1;
            }
            v_str_thoi_gian_bdau += "01/" + v_i_month.ToString() + "/" + v_i_year.ToString();
            v_str_thoi_gian_bdau += "</span>  Đến ngày  <span style='font-family:Times New Roman; font-weight:bold;font-size:1.1em'>";
            v_str_thoi_gian_bdau += get_last_day_of_month();
        }
        return v_str_thoi_gian_bdau;
    }
    private void visible_textbox()
    {
        if (m_cbo_ten_giang_vien_loc.SelectedIndex != 0 && m_cbo_trang_thai_cv_loc.SelectedItem.Value.Equals(CIPConvert.ToStr(ID_TRANG_THAI_CONG_VIEC_GVCM.DA_DUYET_CHUYEN_THANH_TOAN)))
        {
            m_txt_thoi_gian_lop_mon.Visible = true;
            m_lbl_vi_du.Visible = true;
            m_lbl_thong_bao_nhap_thoi_gian_lop_mon.Visible = true;
            m_lbl_thoi_gian_lop_mon.Visible = true;
        }
        else
        {
            m_txt_thoi_gian_lop_mon.Visible = false;
             m_lbl_vi_du.Visible = false;
            m_lbl_thong_bao_nhap_thoi_gian_lop_mon.Visible = false;
            m_lbl_thoi_gian_lop_mon.Visible = false;
        }
    }
    #endregion

    #region Public Interfaces
    public string get_ma_trang_thai_by_id(decimal ip_dc_id_trang_thai)
    {
        US_CM_DM_TU_DIEN v_us_dm_tu_dien = new US_CM_DM_TU_DIEN(ip_dc_id_trang_thai);
        return v_us_dm_tu_dien.strMA_TU_DIEN;
    }
    public decimal get_sum_tien(DS_V_GD_GV_CONG_VIEC_MOI ip_ds_gd_gv_cong_viec)
    {
        decimal v_dc_sum_tien = 0;
        for (int v_i = 0; v_i < ip_ds_gd_gv_cong_viec.V_GD_GV_CONG_VIEC_MOI.Rows.Count; v_i++)
        {
            if (ip_ds_gd_gv_cong_viec.V_GD_GV_CONG_VIEC_MOI.Rows[v_i][V_GD_GV_CONG_VIEC_MOI.SO_LUONG_NGHIEM_THU].GetType() == typeof(DBNull) || ip_ds_gd_gv_cong_viec.V_GD_GV_CONG_VIEC_MOI.Rows[v_i][V_GD_GV_CONG_VIEC_MOI.DON_GIA].GetType() == typeof(DBNull))
                v_dc_sum_tien += 0;
            else v_dc_sum_tien += CIPConvert.ToDecimal(ip_ds_gd_gv_cong_viec.V_GD_GV_CONG_VIEC_MOI.Rows[v_i][V_GD_GV_CONG_VIEC_MOI.SO_LUONG_NGHIEM_THU]) * CIPConvert.ToDecimal(ip_ds_gd_gv_cong_viec.V_GD_GV_CONG_VIEC_MOI.Rows[v_i][V_GD_GV_CONG_VIEC_MOI.DON_GIA]);
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
        foreach (DataRow grv in this.m_ds_cong_viec_moi.V_GD_GV_CONG_VIEC_MOI.Rows)
        {
            strTable += "\n<tr>";
            strTable += "\n<td align='center' class='cssTitleReport' style='width:12%;' nowrap='nowrap'><span style='font-family:Times New Roman;font-size:1.1em'>" + ++v_i_so_thu_tu + "</span></td>";
            strTable += "\n<td class='cssTitleReport' style='width:12%;' wrap='wrap'><span style='font-family:Times New Roman;font-size:1.1em'>" + grv[V_GD_GV_CONG_VIEC_MOI.TEN_NOI_DUNG] + "</span></td>";
            strTable += "\n<td align='right' class='cssTitleReport' style='width:12%;' nowrap='nowrap'><span style='font-family:Times New Roman;font-size:1.1em'>" + mapping_so_tien(grv[V_GD_GV_CONG_VIEC_MOI.DON_GIA]) + "</span></td>";
            strTable += "\n<td align='center' class='cssTitleReport' style='width:12%;' nowrap='nowrap'><span style='font-family:Times New Roman;font-size:1.1em'>" + mapping_dvt_by_id_noi_dung_tt(CIPConvert.ToDecimal(grv[V_GD_GV_CONG_VIEC_MOI.ID_NOI_DUNG_TT])) + "</span></td>";// ĐVT
            strTable += "\n<td class='cssTitleReport' align='center' style='width:12%;' nowrap='nowrap'><span style='font-family:Times New Roman;font-size:1.1em'>" + grv[V_GD_GV_CONG_VIEC_MOI.SO_LUONG_NGHIEM_THU] + "</span></td>";
            strTable += "\n<td align='right' class='cssTitleReport' style='width:12%;' nowrap='nowrap'><span style='font-family:Times New Roman;font-size:1.1em'>" + get_so_tien_thanh_toan(grv[V_GD_GV_CONG_VIEC_MOI.DON_GIA], grv[V_GD_GV_CONG_VIEC_MOI.SO_LUONG_NGHIEM_THU]) + "</span></td>";
            strTable += "\n</tr>";
        }
        decimal v_dc_tong_tien = get_sum_tien(m_ds_cong_viec_moi);
        decimal v_dc_so_tien_thue = 0;
        // Nếu >= 1 triệu, có tính thuế 10%
        if(v_dc_tong_tien >=1000000) v_dc_so_tien_thue = v_dc_tong_tien/10;
        // Đây là đoạn tổng cộng số tiền
        strTable += "\n<tr>";
        strTable += "\n<td style='width:12%; background-color:#B8D7FF' class='cssTitleReport' nowrap='nowrap'>" + "<span style='font-family:Times New Roman; font-size:1.1em'></span></td>";
        strTable += "\n<td style='width:12%; background-color:#B8D7FF' class='cssTitleReport' nowrap='nowrap'><span style='font-family:Times New Roman;  font-weight:bold; font-size:1.1em'>Tổng cộng</span></td>";
        strTable += "\n<td style='width:12%; background-color:#B8D7FF' class='cssTitleReport' nowrap='nowrap'>" + "<span style='font-family:Times New Roman; font-size:1.1em'></span></td>";
        strTable += "\n<td style='width:12%; background-color:#B8D7FF' class='cssTitleReport' nowrap='nowrap'>" + "<span style='font-family:Times New Roman; font-size:1.1em'></span></td>";
        strTable += "\n<td style='width:12%; background-color:#B8D7FF' class='cssTitleReport' nowrap='nowrap'>" + "<span style='font-family:Times New Roman; font-size:1.1em'></span></td>";
        strTable += "\n<td style='width:12%; background-color:#B8D7FF' align='right' class='cssTitleReport' nowrap='nowrap'><span style='font-family:Times New Roman;  font-weight:bold; font-size:1.1em'>" + CIPConvert.ToStr(v_dc_tong_tien, "#,###") + "</span></td>"; // Số tiền tổng
        strTable += "\n</tr>";
        // Đoạn thuế thu nhập cá nhân
        strTable += "\n<tr>";
        strTable += "\n<td rowspan='3' class='cssTitleReport' nowrap='nowrap'></td>";
        strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'><span style='font-family:Times New Roman;font-size:1.1em'>Thuế TNCN khấu trừ tại nguồn (10%)</span></td>";
        strTable += "\n<td colspan='4' align='right' style='width:12%;' class='cssTitleReport' nowrap='nowrap'><span style='font-family:Times New Roman;font-size:1.1em'>" + CIPConvert.ToStr(v_dc_so_tien_thue, "#,###") + "</span></td>"; // Số tiền thuế
        strTable += "\n</tr>";
        //Giá trị thực nhận
        strTable += "\n<tr>";
        strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'><span style='font-family:Times New Roman;font-size:1.1em'>Giá trị thực nhận</span></td>";
        strTable += "\n<td colspan='4' align='right' style='width:12%;' class='cssTitleReport' nowrap='nowrap'><span style='font-family:Times New Roman;font-size:1.1em'>" + CIPConvert.ToStr(v_dc_tong_tien - v_dc_so_tien_thue, "#,###") + "</span></td>";
        strTable += "\n</tr>";
        // Bằng chữ
        string v_str_so_tien_bang_chu = "Bằng chữ: ";
        string v_str_tien_bang_chu = CHelperCore.ToString(v_dc_tong_tien - v_dc_so_tien_thue);
        string v_str_first_char = v_str_tien_bang_chu.Substring(0, 1);
        v_str_first_char = v_str_first_char.ToUpper();
        v_str_tien_bang_chu = v_str_first_char + v_str_tien_bang_chu.Substring(1, v_str_tien_bang_chu.Length - 1);
        v_str_so_tien_bang_chu += v_str_tien_bang_chu;
        strTable += "\n<tr>";
        strTable += "\n<td colspan='5' style='width:12%;' class='cssTitleReport' nowrap='nowrap'><span style='font-family:Times New Roman; font-style:italic;font-size:1.1em'>" + v_str_so_tien_bang_chu +" ./."+ "</span></td>";
        strTable += "\n</tr>";
        //Khoảng trắng
        strTable += "\n<tr>";
        strTable += "\n<td colspan='6'></td>";
        strTable += "\n</tr>";
        // Ngày tháng năm ký
        strTable += "\n<tr>";
        strTable += "\n<td colspan='2'></td>";
        strTable += "\n<td colspan='4' align='left' style='width:12%;' nowrap='nowrap'><span style='font-family:Times New Roman;font-size:1.1em'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Hà Nội, ngày&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tháng&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;năm&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></td>";
        strTable += "\n</tr>";
        // Giám đốc, cán bộ hành chính
        strTable += "\n<tr>";
        strTable += "\n<td colspan='2' align='center' style='width:12%;' nowrap='nowrap'><span style='font-family:Times New Roman;font-weight:bold; font-size:1.1em'>GIÁM ĐỐC TRUNG TÂM</td>";
        strTable += "\n<td colspan='4' align='center' style='width:12%;' nowrap='nowrap'><span style='font-family:Times New Roman;font-weight:bold; font-size:1.1em'>CÁN BỘ HÀNH CHÍNH</span></td>";
        strTable += "\n</tr>";
        // Ký họ tên
        strTable += "\n<tr>";
        strTable += "\n<td colspan='2' align='center' style='width:12%;' nowrap='nowrap'><span style='font-family:Times New Roman;font-style:italic; font-size:1.1em'>(Ký, họ tên)</td>";
        strTable += "\n<td colspan='4' align='center' style='width:12%;' nowrap='nowrap'><span style='font-family:Times New Roman;font-style:italic; font-size:1.1em'>(Ký, họ tên)</span></td>";
        strTable += "\n</tr>";
        //Khoảng trắng
        strTable += "\n<tr>";
        strTable += "\n<td colspan='6'></td>";
        strTable += "\n</tr>";
        //
        strTable += "\n<tr>";
        strTable += "\n<td colspan='6'></td>";
        strTable += "\n</tr>";
        //
        strTable += "\n<tr>";
        strTable += "\n<td colspan='6'></td>";
        strTable += "\n</tr>";
        //
        strTable += "\n<tr>";
        strTable += "\n<td colspan='6'></td>";
        strTable += "\n</tr>";
        // Tên người ký
        strTable += "\n<tr>";
        strTable += "\n<td colspan='2' align='center' style='width:12%;' nowrap='nowrap'><span style='font-family:Times New Roman; font-size:1.1em'>ThS Nguyễn Danh Tú</td>";
        strTable += "\n<td colspan='4' align='center' style='width:12%;' nowrap='nowrap'><span style='font-family:Times New Roman; font-size:1.1em'>Trần Thu Trang</span></td>";
        strTable += "\n</tr>";
    }
    private void loadTieuDe(ref string strTable)
    {
        string v_str_ten_mon = "";
        m_ds_cong_viec_moi.EnforceConstraints = false;
        m_us_cong_viec_moi.load_data_2_export_excel_da_duyet_chuyen(m_ds_cong_viec_moi, CIPConvert.ToDecimal(m_cbo_ten_giang_vien_loc.SelectedValue), CIPConvert.ToDecimal(m_cbo_so_hop_dong_loc.SelectedValue));
        strTable += "<table cellpadding='2' cellspacing='0' class='cssTableReport'>";

        strTable += "\n<tr>";
        strTable += "\n<td colspan='3'><class='cssTableView' style='width:100%;' nowrap='nowrap'><span style='font-family:Times New Roman; font-weight:bold; font-size:1.1em'>Công ty CP Đầu tư và Phát triển đào tạo Edutop64</span></td>";
        strTable += "\n<td colspan='3' align='right'><class='cssTableView' style='width:100%;' nowrap='nowrap'><span style='font-family:Times New Roman; font-weight:bold; font-size:1.0em'>PSP444</span></td>";
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
        strTable += "\n<td colspan='6' align='center'><class='cssTableView' style='width: 100%;  height: 40px; font-size: large; color:White; background-color:#810C15;' nowrap='wrap'><span style='font-family:Times New Roman; font-weight:bold; font-size:1.4em;'>XÁC NHẬN THÙ LAO CHUYÊN MÔN" + "</span></td>";
        strTable += "\n</tr>";
        //Khoảng trắng trước khi vào thông tin về phiếu xác nhận thù lao
        strTable += "\n<tr>";
        strTable += "\n<td colspan='6'></td>";
        strTable += "\n</tr>";
        // Số Hợp đồng
        strTable += "\n<tr>";
        strTable += "\n<td colspan='6' align='left'><class='cssTableView' style='width:100%;' nowrap='nowrap'> <span style='font-family:Times New Roman; font-size:1.1em'>Căn cứ Hợp đồng số: " + m_cbo_so_hop_dong_loc.SelectedItem.Text + " ngày "+ get_ngay_ky_hd_by_id(CIPConvert.ToDecimal(m_cbo_so_hop_dong_loc.SelectedValue),ref v_str_ten_mon)+"</span></td>";
        strTable += "\n</tr>";
        //Họ tên giảng viên
        strTable += "\n<tr>";
        strTable += "\n<td colspan='6' align='left'><class='cssTableView' style='width:100%;' nowrap='nowrap'> <span style='font-family:Times New Roman;font-size:1.1em'>Họ và tên giảng viên: <font style='font-weight:bold'>" + m_cbo_ten_giang_vien_loc.SelectedItem.Text+"</font></span></td>";
        strTable += "\n</tr>";
        //Môn tham gia
        strTable += "\n<tr>";
        strTable += "\n<td colspan='6' align='left'><class='cssTableView' style='width:100%;' nowrap='nowrap'> <span style='font-family:Times New Roman;font-size:1.1em'>Đã tham gia giảng dạy, sản xuất nâng cấp học liệu, hướng dẫn, giải đáp thắc mắc môn:</span></td>";
        strTable += "\n</tr>";
        //Tên môn
        strTable += "\n<tr>";
        strTable += "\n<td colspan='6' align='left'><class='cssTableView' style='width:100%;' nowrap='nowrap'> <span style='font-family:Times New Roman;font-weight:bold;font-size:1.1em'>"+v_str_ten_mon+"</span></td>";
        strTable += "\n</tr>";
        //Thời gian giảng dạy
        DateTime v_dat_today = DateTime.Today;
          strTable += "\n<tr>";
          strTable += "\n<td colspan='6' align='left'><class='cssTableView' style='width:100%;' nowrap='nowrap'> <span style='font-family:Times New Roman;font-size:1.1em'>Thời gian giảng dạy:"+get_ngay_bdau_kthuc_mon(m_txt_thoi_gian_lop_mon.Text.Trim())+"</span></td>";
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
        strTable += "\n<td align='center' class='cssTableView' style='width:12%;' nowrap='nowrap'><span style='font-family:Times New Roman; font-weight:bold; font-size:1.1em'>Đơn giá (VNĐ)</span></td>";
        strTable += "\n<td align='center' class='cssTableView' style='width:12%;' nowrap='nowrap'><span style='font-family:Times New Roman; font-weight:bold; font-size:1.1em'>ĐVT</span></td>";
        strTable += "\n<td align='center' class='cssTableView' style='width:12%;' nowrap='nowrap'><span style='font-family:Times New Roman; font-weight:bold; font-size:1.1em'>Số lượng</span></td>";
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
            if (m_cbo_ten_giang_vien_loc.SelectedValue.Equals("0"))
            {
                m_lbl_thong_bao_chon_giang_vien.Text = "Bạn chưa chọn giảng viên để xuất báo cáo!";
                return;
            }
            else m_lbl_thong_bao_chon_giang_vien.Text = "";
            if (!m_cbo_trang_thai_cv_loc.SelectedValue.Equals(CIPConvert.ToStr(ID_TRANG_THAI_CONG_VIEC_GVCM.DA_DUYET_CHUYEN_THANH_TOAN)) && !m_cbo_trang_thai_cv_loc.SelectedValue.Equals(CIPConvert.ToStr(ID_TRANG_THAI_CONG_VIEC_GVCM.DA_CHUYEN_THANH_TOAN)))
            {
                m_lbl_thong_bao_chon_trang_thai.Text = "Hãy chon trạng thái Đã duyệt chuyển thanh toán hoặc đã thanh toán";
                return;
            }
            else m_lbl_thong_bao_chon_trang_thai.Text = "";
            if (m_txt_thoi_gian_lop_mon.Text.Trim().Equals(""))
            {
                m_lbl_thong_bao_nhap_thoi_gian_lop_mon.Text = "Hãy nhập thời gian lớp môn!";
                return;
            }
            else m_lbl_thong_bao_nhap_thoi_gian_lop_mon.Text = "";

            // Lưu vào session thời gian lớp môn
            Session["timelopmon"] = m_txt_thoi_gian_lop_mon.Text.Trim();
            string html = loadExport();
            string strNamFile = "PSP444_BaoCaoXacNhanThuLaoChuyenMon" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + ".xls";
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
    protected void m_grv_gd_assign_su_kien_cho_giang_vien_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            // Kiểm tra trạng thái để xem có chuyển đc không?
            if (!check_trang_thai_chuyen(m_us_cong_viec_moi.dcID_TRANG_THAI, ID_TRANG_THAI_CONG_VIEC_GVCM.DA_DUYET_NGHIEM_THU))
            {
                string sScript;
                sScript = "<script language='javascript'>alert('Công việc này đã được duyệt nghiệm thu hoặc chưa đủ điều kiện để duyệt nghiệm thu...!');</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "onload", sScript);
                return;
            }
            // Nếu được phép thì ...
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_ten_giang_vien_loc_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (m_cbo_ten_giang_vien_loc.SelectedValue.Equals("0"))
            {
                m_lbl_thong_bao_chon_giang_vien.Text = "Bạn chưa chọn giảng viên để xuất báo cáo!";
                load_data_2_cbo_hop_dong_loc();
                return;
            }
            else m_lbl_thong_bao_chon_giang_vien.Text = "";
            load_data_2_cbo_hop_dong_loc();
            visible_textbox();
            visible_huy_duyet_button();
            if(m_cbo_so_hop_dong_loc.Items.Count > 0)
                load_data_2_grv();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_so_hop_dong_loc_SelectedIndexChanged(object sender, EventArgs e)
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
            // Nếu đang ở trạng thái đã duyệt chuyển thanh toán thì cho hiển thị chức năng hủy duyệt chuyển thanh toán
            if (m_cbo_trang_thai_cv_loc.SelectedItem.Value.Equals(CIPConvert.ToStr(ID_TRANG_THAI_CONG_VIEC_GVCM.DA_DUYET_CHUYEN_THANH_TOAN)))
            {
                if (m_grv_gd_assign_su_kien_cho_giang_vien.Rows.Count > 0)
                    m_cmd_huy_chuyen_duyet_thanh_toan.Visible = true;
            }
            else m_cmd_huy_chuyen_duyet_thanh_toan.Visible = false;
            if (!m_cbo_trang_thai_cv_loc.SelectedItem.Value.Equals(CIPConvert.ToStr(ID_TRANG_THAI_CONG_VIEC_GVCM.DA_DUYET_CHUYEN_THANH_TOAN)) && !m_cbo_trang_thai_cv_loc.SelectedItem.Value.Equals(CIPConvert.ToStr(ID_TRANG_THAI_CONG_VIEC_GVCM.DA_CHUYEN_THANH_TOAN)))
            {
                m_lbl_thong_bao_chon_trang_thai.Text = "Hãy chon trạng thái Đã duyệt chuyển thanh toán hoặc đã thanh toán";
            }
            else m_lbl_thong_bao_chon_trang_thai.Text = "";
            visible_huy_duyet_button();
            visible_textbox();
            load_data_2_grv();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cmd_duyet_ke_hoach_Click(object sender, EventArgs e)
    {
        try
        {
            int v_i_count = 0;
            foreach (GridViewRow row in m_grv_gd_assign_su_kien_cho_giang_vien.Rows)
            {
                bool isChecked = ((CheckBox)row.FindControl("chkItem")).Checked;
                if (isChecked)
                {
                    v_i_count += 1;
                    // Lấy id của công việc
                    decimal v_dc_id_cong_viec = CIPConvert.ToDecimal(((CheckBox)row.FindControl("chkItem")).ToolTip);
                    decimal v_dc_id_trang_thai_hien_tai = CIPConvert.ToDecimal(((CheckBox)row.FindControl("chkTrangThai")).ToolTip);
                    if (!check_trang_thai_chuyen(v_dc_id_trang_thai_hien_tai, ID_TRANG_THAI_CONG_VIEC_GVCM.DA_DUYET_CHUYEN_THANH_TOAN))
                        continue;
                    m_us_cong_viec_moi.dcID = v_dc_id_cong_viec;
                    // Chuyển trạng thái của công việc sang đã duyệt
                    m_us_cong_viec_moi.cap_nhat_trang_thai_cong_viec(ID_TRANG_THAI_CONG_VIEC_GVCM.DA_DUYET_CHUYEN_THANH_TOAN);
                }
            }
            // Neu so items duoc check lớn hơn 0
            if (v_i_count > 0)
            {
                // Load lại dữ liêụ
                m_lbl_thong_bao_sau_cap_nhat.Text = "Đã duyệt chuyển thanh toán các công việc thành công!";
                m_cbo_trang_thai_cv_loc.SelectedValue = CIPConvert.ToStr(ID_TRANG_THAI_CONG_VIEC_GVCM.DA_DUYET_CHUYEN_THANH_TOAN);
                m_cmd_huy_chuyen_duyet_thanh_toan.Visible = true;
                //visible_xuat_excel_button();
                load_data_2_grv();
            }
            // Nếu ko
            else
            {
                m_lbl_thong_bao_sau_cap_nhat.Text = "Bạn chưa chọn công việc nào để duyệt!";
                m_cmd_huy_chuyen_duyet_thanh_toan.Visible = false;
            }
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
    protected void m_cmd_huy_chuyen_duyet_thanh_toan_Click(object sender, EventArgs e)
    {
        try
        {
            int v_i_count = 0;
            foreach (GridViewRow row in m_grv_gd_assign_su_kien_cho_giang_vien.Rows)
            {
                bool isChecked = ((CheckBox)row.FindControl("chkItem")).Checked;
                if (isChecked)
                {
                    v_i_count += 1;
                    // Lấy id của công việc
                    decimal v_dc_id_cong_viec = CIPConvert.ToDecimal(((CheckBox)row.FindControl("chkItem")).ToolTip);
                    decimal v_dc_id_trang_thai_hien_tai = CIPConvert.ToDecimal(((CheckBox)row.FindControl("chkTrangThai")).ToolTip);
                    if (!check_trang_thai_chuyen(v_dc_id_trang_thai_hien_tai, ID_TRANG_THAI_CONG_VIEC_GVCM.DA_DUYET_NGHIEM_THU))
                        continue;
                    m_us_cong_viec_moi.dcID = v_dc_id_cong_viec;
                    // Chuyển trạng thái của công việc sang đã duyệt
                    m_us_cong_viec_moi.cap_nhat_trang_thai_cong_viec(ID_TRANG_THAI_CONG_VIEC_GVCM.DA_DUYET_NGHIEM_THU);
                }
            }
            // Neu so items duoc check lớn hơn 0
            if (v_i_count > 0)
            {
                // Load lại dữ liêụ
                load_data_2_grv();
                m_lbl_thong_bao_sau_cap_nhat.Text = "Hủy duyệt chuyển thanh toán thành công!"; 
            }
            // Nếu ko
            else
            {
                m_lbl_thong_bao_sau_cap_nhat.Text = "Bạn chưa chọn công việc nào để hủy duyệt!";
            }
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    #endregion
}