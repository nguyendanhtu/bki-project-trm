﻿using System;
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

public partial class BaoCao_F707_BaoCaoChiTietCongViecGVCMTheoTrangThai : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            load_data_2_cbo_ten_giang_vien();
            load_data_2_cbo_hop_dong_loc();
            load_data_2_cbo_noi_dung_tt();
            load_data_2_cbo_trang_thai_cv_gv();
            load_data_2_cbo_thoi_gian_dat_hang();
            load_data_2_grv();
        }
    }

    #region Members
    US_GD_GV_CONG_VIEC_MOI m_us_cong_viec_moi = new US_GD_GV_CONG_VIEC_MOI();
    DS_GD_GV_CONG_VIEC_MOI m_ds_cong_viec_moi = new DS_GD_GV_CONG_VIEC_MOI();
    DS_V_GD_GV_CONG_VIEC_MOI m_ds_v_cong_viec_moi = new DS_V_GD_GV_CONG_VIEC_MOI();
    #endregion

    #region Private Methods
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
    private void load_data_2_grv()
    {
        m_us_cong_viec_moi.loc_du_lieu_giang_vien_cong_viec_moi_f707(m_ds_v_cong_viec_moi, CIPConvert.ToDecimal(m_cbo_ten_giang_vien_loc.SelectedValue)
                                                        , CIPConvert.ToDecimal(m_cbo_so_hop_dong_loc.SelectedValue)
                                                        , CIPConvert.ToDecimal(m_cbo_trang_thai_cv_gv.SelectedValue)
                                                        , CIPConvert.ToDecimal(m_cbo_noi_dung_thanh_toan.SelectedValue)
                                                        , CIPConvert.ToDecimal(m_cbo_thang_dat_hang.SelectedValue)
                                                        , CIPConvert.ToDecimal(m_cbo_nam_dat_hang.SelectedValue));
        m_grv_gd_assign_su_kien_cho_giang_vien.DataSource = m_ds_v_cong_viec_moi.V_GD_GV_CONG_VIEC_MOI;
        m_grv_gd_assign_su_kien_cho_giang_vien.DataBind();
        m_lbl_ket_qua_loc_du_lieu.Text = "Kết quả lọc dữ liệu: " + m_ds_v_cong_viec_moi.V_GD_GV_CONG_VIEC_MOI.Rows.Count + " bản ghi";
        if (m_ds_v_cong_viec_moi.V_GD_GV_CONG_VIEC_MOI.Rows.Count > 0)
        {
            decimal v_dc_tong_tien = get_sum_tien(m_ds_v_cong_viec_moi);
            m_grv_gd_assign_su_kien_cho_giang_vien.FooterRow.Cells[6].Text = CIPConvert.ToStr(v_dc_tong_tien, "#,###");
        }
    }
    private void load_data_2_cbo_ten_giang_vien()
    {
        m_cbo_ten_giang_vien_loc.Items.Clear();
        US_V_DM_GIANG_VIEN v_us_v_dm_giang_vien = new US_V_DM_GIANG_VIEN();
        DS_V_DM_GIANG_VIEN v_ds_v_dm_giang_vien = new DS_V_DM_GIANG_VIEN();
        m_cbo_ten_giang_vien_loc.Items.Add(new ListItem("Tất cả", "0"));
        v_us_v_dm_giang_vien.load_all_giang_vien_CM(v_ds_v_dm_giang_vien);
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
        if (v_ds_v_dm_hop_dong_khung.V_DM_HOP_DONG_KHUNG.Rows.Count > 0)
        {
            if (m_cbo_ten_giang_vien_loc.SelectedIndex == 0)
            {
                m_cbo_so_hop_dong_loc.Items.Add(new ListItem("Tất cả", "0"));
            }
            else
            {
                for (int v_i = 0; v_i < v_ds_v_dm_hop_dong_khung.V_DM_HOP_DONG_KHUNG.Rows.Count; v_i++)
                {
                    m_cbo_so_hop_dong_loc.Items.Add(new ListItem(CIPConvert.ToStr(v_ds_v_dm_hop_dong_khung.V_DM_HOP_DONG_KHUNG.Rows[v_i][V_DM_HOP_DONG_KHUNG.SO_HOP_DONG]), CIPConvert.ToStr(v_ds_v_dm_hop_dong_khung.V_DM_HOP_DONG_KHUNG.Rows[v_i][V_DM_HOP_DONG_KHUNG.ID])));
                }
            }
        }
        else
        {
            m_lbl_mess.Text = "Chưa có hợp đồng cho giảng viên này!";
            m_grv_gd_assign_su_kien_cho_giang_vien.DataSource = null;
            m_grv_gd_assign_su_kien_cho_giang_vien.DataBind();
            m_lbl_ket_qua_loc_du_lieu.Text = "";
        }
    }
    private void load_data_2_cbo_noi_dung_tt()
    {
        m_cbo_noi_dung_thanh_toan.Items.Clear();
        US_V_GD_HOP_DONG_NOI_DUNG_TT v_us_gd_hop_dong_noi_dung_tt = new US_V_GD_HOP_DONG_NOI_DUNG_TT();
        DS_V_GD_HOP_DONG_NOI_DUNG_TT v_ds_gd_hop_dong_noi_dung_tt = new DS_V_GD_HOP_DONG_NOI_DUNG_TT();

        // Lấy tất cả các nội dung thanh toán từ phụ lục hợp đồng
        v_us_gd_hop_dong_noi_dung_tt.load_noi_dung_at_phu_luc_hop_dong(CIPConvert.ToDecimal(m_cbo_so_hop_dong_loc.SelectedValue), v_ds_gd_hop_dong_noi_dung_tt);
        m_cbo_noi_dung_thanh_toan.DataTextField = V_GD_HOP_DONG_NOI_DUNG_TT.NOI_DUNG_THANH_TOAN;
        m_cbo_noi_dung_thanh_toan.DataValueField = V_GD_HOP_DONG_NOI_DUNG_TT.ID;

        m_cbo_noi_dung_thanh_toan.Items.Add(new ListItem("---- Hãy chọn công việc -----", "0"));
        for (int v_i = 0; v_i < v_ds_gd_hop_dong_noi_dung_tt.V_GD_HOP_DONG_NOI_DUNG_TT.Rows.Count; v_i++)
        {
            m_cbo_noi_dung_thanh_toan.Items.Add(new ListItem(CIPConvert.ToStr(v_ds_gd_hop_dong_noi_dung_tt.V_GD_HOP_DONG_NOI_DUNG_TT.Rows[v_i][V_GD_HOP_DONG_NOI_DUNG_TT.NOI_DUNG_THANH_TOAN]), CIPConvert.ToStr(v_ds_gd_hop_dong_noi_dung_tt.V_GD_HOP_DONG_NOI_DUNG_TT.Rows[v_i][V_GD_HOP_DONG_NOI_DUNG_TT.ID])));
        }      
    }
    private void load_data_2_cbo_trang_thai_cv_gv()
    {
        US_CM_DM_TU_DIEN v_us_tu_dien = new US_CM_DM_TU_DIEN();
        DS_CM_DM_TU_DIEN v_ds_tu_dien = new DS_CM_DM_TU_DIEN();

        v_us_tu_dien.FillDataset(v_ds_tu_dien, " WHERE ID_LOAI_TU_DIEN = " + (int)e_loai_tu_dien.TRANG_THAI_CONG_VIEC_GV);
        m_cbo_trang_thai_cv_gv.Items.Add(new ListItem("Tất cả", "0"));
        for (int v_i = 0; v_i < v_ds_tu_dien.CM_DM_TU_DIEN.Rows.Count; v_i++)
        {
            m_cbo_trang_thai_cv_gv.Items.Add(new ListItem(CIPConvert.ToStr(v_ds_tu_dien.CM_DM_TU_DIEN.Rows[v_i][CM_DM_TU_DIEN.TEN]), CIPConvert.ToStr(v_ds_tu_dien.CM_DM_TU_DIEN.Rows[v_i][CM_DM_TU_DIEN.ID])));
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
    public decimal get_sum_tien(DS_V_GD_GV_CONG_VIEC_MOI ip_ds_gd_gv_cong_viec)
    {
        decimal v_dc_sum_tien = 0;
        for (int v_i = 0; v_i < ip_ds_gd_gv_cong_viec.V_GD_GV_CONG_VIEC_MOI.Rows.Count; v_i++)
        {
            if (ip_ds_gd_gv_cong_viec.V_GD_GV_CONG_VIEC_MOI.Rows[v_i][GD_GV_CONG_VIEC_MOI.SO_LUONG_HE_SO].GetType() == typeof(DBNull) || ip_ds_gd_gv_cong_viec.V_GD_GV_CONG_VIEC_MOI.Rows[v_i][V_GD_GV_CONG_VIEC_MOI.DON_GIA].GetType() == typeof(DBNull))
                v_dc_sum_tien += 0;
            else
            {
                if (CIPConvert.ToDecimal(ip_ds_gd_gv_cong_viec.V_GD_GV_CONG_VIEC_MOI.Rows[v_i][GD_GV_CONG_VIEC_MOI.ID_TRANG_THAI]) > ID_TRANG_THAI_CONG_VIEC_GVCM.DA_DUYET_KE_HOACH)
                    v_dc_sum_tien += CIPConvert.ToDecimal(ip_ds_gd_gv_cong_viec.V_GD_GV_CONG_VIEC_MOI.Rows[v_i][V_GD_GV_CONG_VIEC_MOI.SO_LUONG_NGHIEM_THU]) * CIPConvert.ToDecimal(ip_ds_gd_gv_cong_viec.V_GD_GV_CONG_VIEC_MOI.Rows[v_i][GD_GV_CONG_VIEC_MOI.DON_GIA]);
                else v_dc_sum_tien += CIPConvert.ToDecimal(ip_ds_gd_gv_cong_viec.V_GD_GV_CONG_VIEC_MOI.Rows[v_i][V_GD_GV_CONG_VIEC_MOI.SO_LUONG_HE_SO]) * CIPConvert.ToDecimal(ip_ds_gd_gv_cong_viec.V_GD_GV_CONG_VIEC_MOI.Rows[v_i][GD_GV_CONG_VIEC_MOI.DON_GIA]);
            }
        }
        return v_dc_sum_tien;
    }
    public string get_so_tien_thanh_toan(object ip_obj_don_gia, object ip_obj_trang_thai, object ip_obj_so_luong, object ip_obj_so_luong_nghiem_thu)
    {
        string v_str_so_tien_thanh_toan = "";
        //if (ip_obj_so_luong_nghiem_thu.GetType() == typeof(DBNull) || ip_obj_don_gia.GetType() == typeof(DBNull))
        //    v_str_so_tien_thanh_toan = "";
        //else
        {
            if (CIPConvert.ToDecimal(ip_obj_trang_thai) > ID_TRANG_THAI_CONG_VIEC_GVCM.DA_DUYET_KE_HOACH)
                v_str_so_tien_thanh_toan = CIPConvert.ToStr(CIPConvert.ToDecimal(ip_obj_don_gia) * CIPConvert.ToDecimal(ip_obj_so_luong_nghiem_thu), "#,###");
            else v_str_so_tien_thanh_toan = CIPConvert.ToStr(CIPConvert.ToDecimal(ip_obj_don_gia) * CIPConvert.ToDecimal(ip_obj_so_luong), "#,###");
        }
        return v_str_so_tien_thanh_toan;
    }
    public string get_so_luong(object ip_id_trang_thai, object ip_so_luong_he_so, object ip_so_luong_nghiem_thu)
    {
        if (CIPConvert.ToDecimal(ip_id_trang_thai) > ID_TRANG_THAI_CONG_VIEC_GVCM.DA_DUYET_KE_HOACH)
            return CIPConvert.ToStr(ip_so_luong_nghiem_thu, "#,###");
        return CIPConvert.ToStr(ip_so_luong_he_so, "#,###");
    }
    #endregion

    #region Export Excel
    private void loadDSExprort(ref string strTable)
    {
        int v_i_so_thu_tu = 0;
        // Mỗi cột dữ liệu ứng với từng dòng là label
        foreach (DataRow grv in this.m_ds_v_cong_viec_moi.V_GD_GV_CONG_VIEC_MOI.Rows)
        {
            strTable += "\n<tr>";
            strTable += "\n<td align='center' class='cssTitleReport' style='width:12%;' nowrap='nowrap'><span style='font-family:Times New Roman;font-size:1.1em'>" + ++v_i_so_thu_tu + "</span></td>";
            strTable += "\n<td class='cssTitleReport' style='width:12%;' wrap='wrap'><span style='font-family:Times New Roman;font-size:1.1em'>" + grv[V_GD_GV_CONG_VIEC_MOI.SO_HOP_DONG] + "</span></td>";
            strTable += "\n<td class='cssTitleReport' style='width:12%;' wrap='wrap'><span style='font-family:Times New Roman;font-size:1.1em'>" + grv[V_GD_GV_CONG_VIEC_MOI.HO_VA_TEN_GIANG_VIEN] + "</span></td>";
            strTable += "\n<td class='cssTitleReport' style='width:12%;' wrap='wrap'><span style='font-family:Times New Roman;font-size:1.1em'>" + grv[V_GD_GV_CONG_VIEC_MOI.TEN_NOI_DUNG] + "</span></td>";
            strTable += "\n<td align='right' class='cssTitleReport' style='width:12%;' nowrap='nowrap'><span style='font-family:Times New Roman;font-size:1.1em'>" + mapping_so_tien(grv[V_GD_GV_CONG_VIEC_MOI.DON_GIA]) + "</span></td>";
            strTable += "\n<td class='cssTitleReport' align='center' style='width:12%;' nowrap='nowrap'><span style='font-family:Times New Roman;font-size:1.1em'>" + grv[V_GD_GV_CONG_VIEC_MOI.SO_LUONG_HE_SO] + "</span></td>";
            strTable += "\n<td align='center' class='cssTitleReport' style='width:12%;' nowrap='nowrap'><span style='font-family:Times New Roman;font-size:1.1em'>" + mapping_dvt_by_id_noi_dung_tt(CIPConvert.ToDecimal(grv[V_GD_GV_CONG_VIEC_MOI.ID_NOI_DUNG_TT])) + "</span></td>";// ĐVT
            strTable += "\n<td align='right' class='cssTitleReport' style='width:12%;' nowrap='nowrap'><span style='font-family:Times New Roman;font-size:1.1em'>" + get_so_tien_thanh_toan(grv[V_GD_GV_CONG_VIEC_MOI.DON_GIA], grv[V_GD_GV_CONG_VIEC_MOI.ID_TRANG_THAI], grv[V_GD_GV_CONG_VIEC_MOI.SO_LUONG_HE_SO], grv[V_GD_GV_CONG_VIEC_MOI.SO_LUONG_NGHIEM_THU]) + "</span></td>";
            strTable += "\n<td class='cssTitleReport' style='width:12%;' wrap='wrap'><span style='font-family:Times New Roman;font-size:1.1em'>" + grv[V_GD_GV_CONG_VIEC_MOI.NGAY_DAT_HANG] + "</span></td>";
            strTable += "\n<td class='cssTitleReport' style='width:12%;' wrap='wrap'><span style='font-family:Times New Roman;font-size:1.1em'>" + grv[V_GD_GV_CONG_VIEC_MOI.TEN_TRANG_THAI] + "</span></td>";
            strTable += "\n</tr>";
        }
        decimal v_dc_tong_tien = get_sum_tien(m_ds_v_cong_viec_moi);
        // Đây là đoạn tổng cộng số tiền
        strTable += "\n<tr>";
        strTable += "\n<td style='width:12%; background-color:#B8D7FF' class='cssTitleReport' nowrap='nowrap'>" + "<span style='font-family:Times New Roman; font-size:1.1em'></span></td>";
        strTable += "\n<td style='width:12%; background-color:#B8D7FF' class='cssTitleReport' nowrap='nowrap'><span style='font-family:Times New Roman;  font-weight:bold; font-size:1.1em'>Tổng cộng</span></td>";
        strTable += "\n<td style='width:12%; background-color:#B8D7FF' class='cssTitleReport' nowrap='nowrap'>" + "<span style='font-family:Times New Roman; font-size:1.1em'></span></td>";
        strTable += "\n<td style='width:12%; background-color:#B8D7FF' class='cssTitleReport' nowrap='nowrap'>" + "<span style='font-family:Times New Roman; font-size:1.1em'></span></td>";
        strTable += "\n<td style='width:12%; background-color:#B8D7FF' class='cssTitleReport' nowrap='nowrap'>" + "<span style='font-family:Times New Roman; font-size:1.1em'></span></td>";
        strTable += "\n<td style='width:12%; background-color:#B8D7FF' class='cssTitleReport' nowrap='nowrap'>" + "<span style='font-family:Times New Roman; font-size:1.1em'></span></td>";
        strTable += "\n<td style='width:12%; background-color:#B8D7FF' class='cssTitleReport' nowrap='nowrap'>" + "<span style='font-family:Times New Roman; font-size:1.1em'></span></td>";
        strTable += "\n<td style='width:12%; background-color:#B8D7FF' align='right' class='cssTitleReport' nowrap='nowrap'><span style='font-family:Times New Roman;  font-weight:bold; font-size:1.1em'>" + CIPConvert.ToStr(v_dc_tong_tien, "#,###") + "</span></td>"; // Số tiền tổng
        strTable += "\n<td style='width:12%; background-color:#B8D7FF' class='cssTitleReport' nowrap='nowrap'>" + "<span style='font-family:Times New Roman; font-size:1.1em'></span></td>";
        strTable += "\n<td style='width:12%; background-color:#B8D7FF' class='cssTitleReport' nowrap='nowrap'>" + "<span style='font-family:Times New Roman; font-size:1.1em'></span></td>";
        strTable += "\n</tr>";
    }
    private void loadTieuDe(ref string strTable)
    {
        //m_ds_cong_viec_moi.EnforceConstraints = false;
        m_us_cong_viec_moi.loc_du_lieu_giang_vien_cong_viec_moi_f707(m_ds_v_cong_viec_moi, CIPConvert.ToDecimal(m_cbo_ten_giang_vien_loc.SelectedValue)
                                                        , CIPConvert.ToDecimal(m_cbo_so_hop_dong_loc.SelectedValue)
                                                        , CIPConvert.ToDecimal(m_cbo_trang_thai_cv_gv.SelectedValue)
                                                        , CIPConvert.ToDecimal(m_cbo_noi_dung_thanh_toan.SelectedValue)
                                                        , CIPConvert.ToDecimal(m_cbo_thang_dat_hang.SelectedValue)
                                                        , CIPConvert.ToDecimal(m_cbo_nam_dat_hang.SelectedValue));
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
        strTable += "\n<td colspan='6' align='center'><class='cssTableView' style='width: 100%;  height: 40px; font-size: large; color:White; background-color:#810C15;' nowrap='wrap'><span style='font-family:Times New Roman; font-weight:bold; font-size:1.4em;'>F707 - BÁO CÁO CHI TIẾT CÔNG VIỆC GIẢNG VIÊN CHUYÊN MÔN" + "</span></td>";
        strTable += "\n</tr>";
        //Khoảng trắng trước khi vào thông tin về phiếu xác nhận thù lao
        strTable += "\n<tr>";
        strTable += "\n<td colspan='6'></td>";
        strTable += "\n</tr>";
        //Họ tên giảng viên
        strTable += "\n<tr>";
        strTable += "\n<td colspan='6' align='left'><class='cssTableView' style='width:100%;' nowrap='nowrap'> <span style='font-family:Times New Roman;font-size:1.1em'>Họ và tên giảng viên: <font style='font-weight:bold'>" + m_cbo_ten_giang_vien_loc.SelectedItem.Text + "</font></span></td>";
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
        strTable += "\n<td align='center' class='cssTableView' style='width:12%;' nowrap='nowrap'><span style='font-family:Times New Roman; font-weight:bold; font-size:1.1em'>Số hợp đồng</span></td>";
        strTable += "\n<td align='center' class='cssTableView' style='width:12%;' nowrap='nowrap'><span style='font-family:Times New Roman; font-weight:bold; font-size:1.1em'>Tên giảng viên</span></td>";
        strTable += "\n<td align='center' class='cssTableView' style='width:12%;' nowrap='nowrap'><span style='font-family:Times New Roman; font-weight:bold; font-size:1.1em'>Công việc</span></td>";
        strTable += "\n<td align='center' class='cssTableView' style='width:12%;' nowrap='nowrap'><span style='font-family:Times New Roman; font-weight:bold; font-size:1.1em'>Đơn giá (VNĐ)</span></td>";
        strTable += "\n<td align='center' class='cssTableView' style='width:12%;' nowrap='nowrap'><span style='font-family:Times New Roman; font-weight:bold; font-size:1.1em'>Số lượng</span></td>";
        strTable += "\n<td align='center' class='cssTableView' style='width:12%;' nowrap='nowrap'><span style='font-family:Times New Roman; font-weight:bold; font-size:1.1em'>ĐVT</span></td>";
        strTable += "\n<td align='center' class='cssTableView' style='width:12%;' nowrap='nowrap'><span style='font-family:Times New Roman; font-weight:bold; font-size:1.1em'>Thành tiền (VNĐ)</span></td>";
        strTable += "\n<td align='center' class='cssTableView' style='width:12%;' nowrap='nowrap'><span style='font-family:Times New Roman; font-weight:bold; font-size:1.1em'>Ngày đặt hàng</span></td>";
        strTable += "\n<td align='center' class='cssTableView' style='width:12%;' nowrap='nowrap'><span style='font-family:Times New Roman; font-weight:bold; font-size:1.1em'>Trạng thái</span></td>";
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
    protected void m_cmd_loc_du_lieu_Click(object sender, EventArgs e)
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
    protected void m_cmd_xuat_excel_Click(object sender, EventArgs e)
    {
        try
        {
            string html = loadExport();
            string strNamFile = "BaoCaoChiTietCongViecGVChuyenMon" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + ".xls";
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
    protected void m_cbo_noi_dung_thanh_toan_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (m_cbo_noi_dung_thanh_toan.SelectedIndex != 0)
            {
                load_data_2_grv();
            }
            else
            {
                load_data_2_grv();
            }
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
            load_data_2_cbo_hop_dong_loc();
            if (m_cbo_so_hop_dong_loc.Items.Count > 0)
            {
                load_data_2_cbo_noi_dung_tt();
                load_data_2_grv();
            }
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
            load_data_2_cbo_noi_dung_tt();
            load_data_2_grv();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_trang_thai_cv_gv_SelectedIndexChanged(object sender, EventArgs e)
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