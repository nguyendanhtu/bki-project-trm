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

public partial class ChucNang_F501_DuToanHopDongVanHanh : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        m_lbl_thong_bao.Text = "";
        m_lbl_thong_bao1.Text = "";
        if (!IsPostBack)
        {
            load_data_2_cbo_dot_thanh_toan();
            load_data_2_cbo_trang_thai_thanh_toan();
            when_cbo_dot_tt_changed();
        }
        m_cmd_check_so_hd.Attributes.Add("onclick", "openPopUp()");
        m_cmd_check_ma_lop_mon.Attributes.Add("onclick", "openPopUpMaLopMon()");
    }

    #region Members
    US_CM_DM_TU_DIEN m_us_cm_tu_dien = new US_CM_DM_TU_DIEN();
    DS_CM_DM_TU_DIEN m_ds_cm_tu_dien = new DS_CM_DM_TU_DIEN();
    US_V_GD_THANH_TOAN m_us_v_gd_thanh_toan = new US_V_GD_THANH_TOAN();
    DS_V_GD_THANH_TOAN m_v_ds_gd_thanh_toan = new DS_V_GD_THANH_TOAN();
    US_V_DM_HOP_DONG_KHUNG m_us_dm_hop_dong_khung = new US_V_DM_HOP_DONG_KHUNG();
    DS_V_DM_HOP_DONG_KHUNG m_ds_dm_hop_dong_khung = new DS_V_DM_HOP_DONG_KHUNG();
    DataEntryFormMode m_init_mode = DataEntryFormMode.ViewDataState;
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
    public string get_so_hd_khung_by_id_hd(decimal ip_dc_so_hd)
    {
        DS_V_DM_HOP_DONG_KHUNG v_ds_hd_khung = new DS_V_DM_HOP_DONG_KHUNG();
        US_V_DM_HOP_DONG_KHUNG v_us_hd_khung = new US_V_DM_HOP_DONG_KHUNG();
        v_us_hd_khung.FillDataset(v_ds_hd_khung, " WHERE  ID = " + ip_dc_so_hd);
        if (v_ds_hd_khung.V_DM_HOP_DONG_KHUNG.Rows.Count == 0) return "";
        return CIPConvert.ToStr(v_ds_hd_khung.V_DM_HOP_DONG_KHUNG.Rows[0][V_DM_HOP_DONG_KHUNG.SO_HOP_DONG]);
    }
    public string get_ma_dot_tt_by_id_dot(decimal ip_dc_ma_dot)
    {
        DS_V_DM_DOT_THANH_TOAN v_ds_dot_tt = new DS_V_DM_DOT_THANH_TOAN();
        US_V_DM_DOT_THANH_TOAN v_us_dot_thanh_toan = new US_V_DM_DOT_THANH_TOAN();
        v_us_dot_thanh_toan.FillDataset(v_ds_dot_tt, " WHERE ID = " + ip_dc_ma_dot);
        if (v_ds_dot_tt.V_DM_DOT_THANH_TOAN.Rows.Count == 0) return "";
        return CIPConvert.ToStr(v_ds_dot_tt.V_DM_DOT_THANH_TOAN.Rows[0][V_DM_DOT_THANH_TOAN.MA_DOT_TT]);
    }
    public string mapping_magv_by_id(decimal ip_dc_id_gv)
    {
        US_V_DM_GIANG_VIEN v_dm_gv = new US_V_DM_GIANG_VIEN(ip_dc_id_gv);
        if (v_dm_gv.IsIDNull()) return "";
        return v_dm_gv.strMA_GIANG_VIEN;
    }
    public string mapping_time_lop_mon(string ip_str_ma_lop_mon)
    {
        US_GD_LOP_MON v_us_gd_lop_mon = new US_GD_LOP_MON();
        DS_GD_LOP_MON v_ds_gd_lop_mon = new DS_GD_LOP_MON();

        v_us_gd_lop_mon.FillDataset(v_ds_gd_lop_mon, " WHERE MA_LOP_MON=N'" + ip_str_ma_lop_mon + "'");
        if (v_ds_gd_lop_mon.GD_LOP_MON.Rows[0][GD_LOP_MON.NGAY_BAT_DAU].GetType()==typeof(DBNull))
        {
            if (v_ds_gd_lop_mon.GD_LOP_MON.Rows[0][GD_LOP_MON.NGAY_KET_THUC].GetType() == typeof(DBNull)) return "";
            else return CIPConvert.ToStr(v_ds_gd_lop_mon.GD_LOP_MON.Rows[0][GD_LOP_MON.NGAY_KET_THUC], "dd/MM/yyyy");
        }
        else if (v_ds_gd_lop_mon.GD_LOP_MON.Rows[0][GD_LOP_MON.NGAY_KET_THUC].GetType() == typeof(DBNull))  
            return CIPConvert.ToStr(v_ds_gd_lop_mon.GD_LOP_MON.Rows[0][GD_LOP_MON.NGAY_BAT_DAU], "dd/MM/yyyy");
        return CIPConvert.ToStr(v_ds_gd_lop_mon.GD_LOP_MON.Rows[0][GD_LOP_MON.NGAY_BAT_DAU], "dd/MM/yyyy") + " - " + CIPConvert.ToStr(v_ds_gd_lop_mon.GD_LOP_MON.Rows[0][GD_LOP_MON.NGAY_KET_THUC], "dd/MM/yyyy");
    }
    public string mapping_thoi_gian_lop_mon(object ip_obj_time_lop_mon)
    {
        if (ip_obj_time_lop_mon.GetType() == typeof(DBNull)) return "";
        return CIPConvert.ToStr(ip_obj_time_lop_mon,"dd/MM/yyyy");
    }

    #endregion

    #region Private Methods
    private void load_data_2_cbo_dot_thanh_toan()
    {
        DS_V_DM_DOT_THANH_TOAN v_ds_dot_thanh_toan = new DS_V_DM_DOT_THANH_TOAN();
        US_V_DM_DOT_THANH_TOAN v_us_dot_thanh_toan = new US_V_DM_DOT_THANH_TOAN();
        v_us_dot_thanh_toan.load_dot_thanh_toan_by_trang_thai(ID_TRANG_THAI_DOT_TT.DA_LAP_DOT, v_ds_dot_thanh_toan);
        //v_us_dot_thanh_toan.FillDataset(v_ds_dot_thanh_toan, " WHERE ID_TRANG_THAI_DOT_TT = "+get_id_trang_thai_dot_tt_da_lap_dot()+" ORDER BY ID DESC");
        for (int i = 0; i < v_ds_dot_thanh_toan.V_DM_DOT_THANH_TOAN.Rows.Count; i++)
        {
            if (CIPConvert.ToDecimal(v_ds_dot_thanh_toan.V_DM_DOT_THANH_TOAN.Rows[i][V_DM_DOT_THANH_TOAN.ID]) != get_id_of_dot_tt_kho())
                m_cbo_dot_thanh_toan.Items.Add(new ListItem(CIPConvert.ToStr(v_ds_dot_thanh_toan.V_DM_DOT_THANH_TOAN.Rows[i][V_DM_DOT_THANH_TOAN.TEN_DOT_TT]), CIPConvert.ToStr(v_ds_dot_thanh_toan.V_DM_DOT_THANH_TOAN.Rows[i][V_DM_DOT_THANH_TOAN.ID])));
        }
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
    private void load_data_2_cbo_trang_thai_thanh_toan()
    {
        m_us_cm_tu_dien.FillDataset(m_ds_cm_tu_dien, " WHERE ID_LOAI_TU_DIEN= "+ (int)e_loai_tu_dien.TRANG_THAI_THANH_TOAN);

        m_cbo_trang_thai_thanh_toan.DataTextField = CM_DM_TU_DIEN.TEN;
        m_cbo_trang_thai_thanh_toan.DataValueField = CM_DM_TU_DIEN.ID;
        m_cbo_trang_thai_thanh_toan.DataSource = m_ds_cm_tu_dien.CM_DM_TU_DIEN;
        m_cbo_trang_thai_thanh_toan.DataBind();
    }
    private void load_data_2_grid(string ip_str_ma_dot_tt)
    {
        if (ip_str_ma_dot_tt == "")
        {
            m_lbl_thong_bao.Visible = true;
            m_lbl_thong_bao.Text = "Chưa tạo Đợt thanh toán";
            return;
        }
        else
        {
            //US_V_GD_THANH_TOAN v_us_gd_thanh_toan = new US_V_GD_THANH_TOAN();
            //DS_V_GD_THANH_TOAN v_ds_gd_thanh_toan = new DS_V_GD_THANH_TOAN();
            // Số phiếu thanh toán là mã đợt thanh toán
            m_us_v_gd_thanh_toan.f501_load_thanh_toan_by_ma_dot_tt_va_loai_hd(ip_str_ma_dot_tt,"VH", m_v_ds_gd_thanh_toan);
            if (m_v_ds_gd_thanh_toan.V_GD_THANH_TOAN.Rows.Count == 0)
            {
                m_lbl_thong_bao.Visible = true;
                m_lbl_thong_bao.Text = "Chưa có Thanh toán nào ứng với Đợt thanh toán này";
            }
            m_grv_danh_sach_du_toan.DataSource = m_v_ds_gd_thanh_toan.V_GD_THANH_TOAN;
            m_grv_danh_sach_du_toan.DataBind();
            m_lbl_result.Text = "Danh sách bảng kê hợp đồng vận hành: " + m_v_ds_gd_thanh_toan.V_GD_THANH_TOAN.Rows.Count + " bản ghi";
        }
    }
    private void load_data_2_export_excel(string ip_str_ma_dot_tt)
    {
        if (ip_str_ma_dot_tt == "")
        {
            m_lbl_thong_bao.Visible = true;
            m_lbl_thong_bao.Text = "Chưa tạo Đợt thanh toán";
            return;
        }
        else
        {
            // Số phiếu thanh toán là mã đợt thanh toán
            m_us_v_gd_thanh_toan.f501_load_thanh_toan_by_ma_dot_tt_va_loai_hd(ip_str_ma_dot_tt, "VH", m_v_ds_gd_thanh_toan);
        }
    }
    private string get_ma_trang_thai_dot_tt_by_id(decimal ip_dc_id_dot_tt)
    {
        US_CM_DM_TU_DIEN v_us_cm_dm_tu_dien = new US_CM_DM_TU_DIEN(ip_dc_id_dot_tt);
        return v_us_cm_dm_tu_dien.strMA_TU_DIEN;
    }
    private decimal get_id_trang_thai_dot_tt_by_ma(string ip_str_ma_dot_tt)
    {
        US_CM_DM_TU_DIEN v_us_cm_dm_tu_dien = new US_CM_DM_TU_DIEN("DOT_THANH_TOAN", ip_str_ma_dot_tt);
        return v_us_cm_dm_tu_dien.dcID;
    }
    private void reset_controls()
    {
        m_txt_so_hop_dong.Text = "";
        m_txt_so_tien_thanh_toan.Text = "";
        m_txt_so_tien_thue1.Text = "";
        m_txt_so_tien_thuc_nhan.Text = "";
        m_txt_ma_lop_mon.Text = "";
        m_txt_mo_ta.Text = "";
        m_cbo_trang_thai_thanh_toan.SelectedIndex = 0;
        m_txt_ghi_chu_4.Text = "";
        m_txt_ghi_chu_5.Text = "";
        m_txt_thoi_gian_lop_mon.Text = "";
        m_txt_ten_cac_mon_phu_trach.Text = "";
        m_txt_he_so_quy_mo.Text = "";
    }
    private void when_cbo_dot_tt_changed()
    {
        if (m_cbo_dot_thanh_toan.Items.Count == 0)
        {
            m_lbl_thong_bao1.Text = "Chưa tồn tại đợt thanh toán nào !";
            return;
        }      
        decimal v_dc_id_dot_thanh_toan = CIPConvert.ToDecimal(m_cbo_dot_thanh_toan.SelectedValue);
        US_V_DM_DOT_THANH_TOAN v_us_dot_thanh_toan = new US_V_DM_DOT_THANH_TOAN(v_dc_id_dot_thanh_toan);
        m_dat_ngay_thanh_toan.SelectedDate = v_us_dot_thanh_toan.datNGAY_TT_DU_KIEN;
        load_data_2_grid(get_ma_dot_tt_by_id_dot(CIPConvert.ToDecimal(m_cbo_dot_thanh_toan.SelectedValue)));
    }
    private string mapping_so_tien(object ip_obj_nghiem_thu_thuc_te)
    {
        if (ip_obj_nghiem_thu_thuc_te.GetType() == typeof(DBNull)) return "";
        if (CIPConvert.ToDecimal(ip_obj_nghiem_thu_thuc_te) == 0)
            return CIPConvert.ToStr(0);
        return CIPConvert.ToStr(ip_obj_nghiem_thu_thuc_te, "#,###");
    }
    private decimal get_id_dot_tt_by_ma_dot(string ip_str_ma_dot)
    {
        DS_V_DM_DOT_THANH_TOAN v_ds_dot_tt = new DS_V_DM_DOT_THANH_TOAN();
        US_V_DM_DOT_THANH_TOAN v_us_dot_thanh_toan = new US_V_DM_DOT_THANH_TOAN();
        v_us_dot_thanh_toan.FillDataset(v_ds_dot_tt, " WHERE MA_DOT_TT = '" + ip_str_ma_dot + "'");
        if (v_ds_dot_tt.V_DM_DOT_THANH_TOAN.Rows.Count == 0) return 0;
        return CIPConvert.ToDecimal(v_ds_dot_tt.V_DM_DOT_THANH_TOAN.Rows[0][V_DM_DOT_THANH_TOAN.ID]);
    }
    private decimal get_id_hd_khung_by_so_hd(string ip_str_so_hd)
    {
        DS_V_DM_HOP_DONG_KHUNG v_ds_hd_khung = new DS_V_DM_HOP_DONG_KHUNG();
        US_V_DM_HOP_DONG_KHUNG v_us_hd_khung = new US_V_DM_HOP_DONG_KHUNG();
        v_us_hd_khung.FillDataset(v_ds_hd_khung, " WHERE  SO_HOP_DONG = N'" + ip_str_so_hd + "'");
        if (v_ds_hd_khung.V_DM_HOP_DONG_KHUNG.Rows.Count == 0) return 0;
        return CIPConvert.ToDecimal(v_ds_hd_khung.V_DM_HOP_DONG_KHUNG.Rows[0][V_DM_HOP_DONG_KHUNG.ID]);
    }    
    private void us_obj_2_form(US_V_GD_THANH_TOAN ip_us_gd_thanh_toan)
    {
        m_cbo_dot_thanh_toan.SelectedValue =CIPConvert.ToStr(get_id_dot_tt_by_ma_dot(ip_us_gd_thanh_toan.strSO_PHIEU_THANH_TOAN));
        m_txt_so_hop_dong.Text = get_so_hd_khung_by_id_hd(ip_us_gd_thanh_toan.dcID_HOP_DONG_KHUNG);
        m_txt_ma_lop_mon.Text = ip_us_gd_thanh_toan.strREFERENCE_CODE;
        m_dat_ngay_thanh_toan.SelectedDate = ip_us_gd_thanh_toan.datNGAY_THANH_TOAN;
        m_txt_so_tien_thanh_toan.Text =CIPConvert.ToStr(ip_us_gd_thanh_toan.dcTONG_TIEN_THANH_TOAN,"#,###");
        m_txt_so_tien_thuc_nhan.Text = CIPConvert.ToStr(ip_us_gd_thanh_toan.dcTONG_TIEN_THUC_NHAN,"#,###");
        m_txt_so_tien_thue1.Text = CIPConvert.ToStr(ip_us_gd_thanh_toan.dcSO_TIEN_THUE,"#,###");
        m_cbo_trang_thai_thanh_toan.SelectedValue = CIPConvert.ToStr(ip_us_gd_thanh_toan.dcID_TRANG_THAI_THANH_TOAN);
        hdf_id_trang_thai_thanh_toan_cu.Value = CIPConvert.ToStr(ip_us_gd_thanh_toan.dcID_TRANG_THAI_THANH_TOAN);
        m_txt_mo_ta.Text = ip_us_gd_thanh_toan.strDESCRIPTION;
        m_txt_ten_cac_mon_phu_trach.Text = ip_us_gd_thanh_toan.strGHI_CHU_CAC_MON_PHU_TRACH;
        m_txt_thoi_gian_lop_mon.Text = ip_us_gd_thanh_toan.strGHI_CHU_THOI_GIAN_LOP_MON;
        m_txt_he_so_quy_mo.Text = ip_us_gd_thanh_toan.strGHI_CHU_HE_SO_DON_GIA;
        m_txt_ghi_chu_4.Text = ip_us_gd_thanh_toan.strGHI_CHU_4;
        m_txt_ghi_chu_5.Text = ip_us_gd_thanh_toan.strGHI_CHU_5;
    }
    private void form_2_us_obj(US_V_GD_THANH_TOAN op_us_gd_thanh_toan)
    {
        op_us_gd_thanh_toan.strSO_PHIEU_THANH_TOAN =get_ma_dot_tt_by_id_dot(CIPConvert.ToDecimal(m_cbo_dot_thanh_toan.SelectedValue));
        op_us_gd_thanh_toan.dcID_HOP_DONG_KHUNG =get_id_hd_khung_by_so_hd(m_txt_so_hop_dong.Text.Trim());
        op_us_gd_thanh_toan.strREFERENCE_CODE = m_txt_ma_lop_mon.Text.Trim();
        if (m_dat_ngay_thanh_toan.SelectedDate == CIPConvert.ToDatetime("01/01/0001", "dd/MM/yyyy"))
        {
            string sScript;
            sScript = "<script language='javascript'>alert('Bạn phải nhập ngày thanh toán');</script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "onload", sScript);
            m_dat_ngay_thanh_toan.Focus();
            return;
        }
        else op_us_gd_thanh_toan.datNGAY_THANH_TOAN = m_dat_ngay_thanh_toan.SelectedDate;
        op_us_gd_thanh_toan.dcTONG_TIEN_THANH_TOAN =CIPConvert.ToDecimal(m_txt_so_tien_thanh_toan.Text);
        op_us_gd_thanh_toan.SetGIA_TRI_NGHIEM_THU_THUC_TENull();
        op_us_gd_thanh_toan.dcTONG_TIEN_THUC_NHAN =CIPConvert.ToDecimal(m_txt_so_tien_thuc_nhan.Text);
        op_us_gd_thanh_toan.dcSO_TIEN_THUE = CIPConvert.ToDecimal(m_txt_so_tien_thue1.Text);
        op_us_gd_thanh_toan.dcID_TRANG_THAI_THANH_TOAN = CIPConvert.ToDecimal(m_cbo_trang_thai_thanh_toan.SelectedValue);
        op_us_gd_thanh_toan.strDESCRIPTION = m_txt_mo_ta.Text.Trim();
        if (Session["UserName"].GetType() != typeof(DBNull))
            op_us_gd_thanh_toan.strPO_LAP_THANH_TOAN = CIPConvert.ToStr(Session["UserName"]);
        op_us_gd_thanh_toan.strGHI_CHU_CAC_MON_PHU_TRACH = m_txt_ten_cac_mon_phu_trach.Text.Trim();
        op_us_gd_thanh_toan.strGHI_CHU_THOI_GIAN_LOP_MON = m_txt_thoi_gian_lop_mon.Text.Trim();
        op_us_gd_thanh_toan.strGHI_CHU_HE_SO_DON_GIA = m_txt_he_so_quy_mo.Text;
        op_us_gd_thanh_toan.strGHI_CHU_4 = m_txt_ghi_chu_4.Text;
        op_us_gd_thanh_toan.strGHI_CHU_5 = m_txt_ghi_chu_5.Text;
    }
    private void load_data_2_us_by_id_and_show_on_form(int ip_i_thanh_toan_selected)
    {
        try
        {
            decimal v_dc_id_thanh_toan = CIPConvert.ToDecimal(m_grv_danh_sach_du_toan.DataKeys[ip_i_thanh_toan_selected].Value);
            hdf_id_gv.Value = CIPConvert.ToStr(v_dc_id_thanh_toan);
            US_V_GD_THANH_TOAN v_us_gd_thanh_toan = new US_V_GD_THANH_TOAN(v_dc_id_thanh_toan);

            // Load data to form 
            us_obj_2_form(v_us_gd_thanh_toan);
        }
        catch (Exception v_e)
        {

            throw v_e;
        }

    }
    private void delete_row_thanh_toan(int ip_i_id_thanh_toan)
    {
        // Lấy được ID thanh tóan
        decimal v_dc_id_thanh_toan = CIPConvert.ToDecimal(m_grv_danh_sach_du_toan.DataKeys[ip_i_id_thanh_toan].Value);
        m_us_v_gd_thanh_toan.dcID = v_dc_id_thanh_toan;
        // Xóa GD_THANH_TOAN
        m_us_v_gd_thanh_toan.DeleteByID(v_dc_id_thanh_toan);
        m_lbl_thong_bao.Text = "Xóa bản ghi thành công";
        // Load lại dữ liệu
        load_data_2_grid(get_ma_dot_tt_by_id_dot(CIPConvert.ToDecimal(m_cbo_dot_thanh_toan.SelectedValue)));
    }
    private decimal get_id_trang_thai_dot_tt_da_lap_dot()
    {
        US_CM_DM_TU_DIEN v_us_cm_tu_dien = new US_CM_DM_TU_DIEN();
        DS_CM_DM_TU_DIEN v_ds_tu_dien = new DS_CM_DM_TU_DIEN();
        v_us_cm_tu_dien.FillDataset(v_ds_tu_dien, " WHERE ID_LOAI_TU_DIEN = 14 AND MA_TU_DIEN LIKE N'%DA_LAP_DOT%'");
        if (v_ds_tu_dien.CM_DM_TU_DIEN.Rows.Count == 0) return 503;
        return CIPConvert.ToDecimal(v_ds_tu_dien.CM_DM_TU_DIEN.Rows[0][CM_DM_TU_DIEN.ID]);
    }
    private bool check_exist_so_hop_dong(string ip_str_so_hd)
    {
        US_DM_HOP_DONG_KHUNG v_us_dm_hop_dong_khung = new US_DM_HOP_DONG_KHUNG();
        DS_DM_HOP_DONG_KHUNG v_ds_dm_hop_dong_khung = new DS_DM_HOP_DONG_KHUNG();
        v_us_dm_hop_dong_khung.FillDataset(v_ds_dm_hop_dong_khung, " WHERE SO_HOP_DONG=N'" + ip_str_so_hd + "'");
        if (v_ds_dm_hop_dong_khung.DM_HOP_DONG_KHUNG.Rows.Count == 0)
            return false; // Nghĩa là không tồn tại số hợp đồng đó
        return true; // Nghĩa là tồn tại số hợp đồng đó
    }
    private string get_ma_trang_thai_thanh_toan_by_id(decimal ip_dc_id_tt)
    {
        US_CM_DM_TU_DIEN v_us_cm_dm_tu_dien = new US_CM_DM_TU_DIEN(ip_dc_id_tt);
        return v_us_cm_dm_tu_dien.strMA_TU_DIEN;
    }
    private decimal get_id_trang_thai_da_len_bang_ke()
    {
        US_CM_DM_TU_DIEN v_us_cm_tu_dien = new US_CM_DM_TU_DIEN();
        DS_CM_DM_TU_DIEN v_ds_tu_dien = new DS_CM_DM_TU_DIEN();
        v_us_cm_tu_dien.FillDataset(v_ds_tu_dien, " WHERE ID_LOAI_TU_DIEN = 15 AND MA_TU_DIEN LIKE N'%DA_LEN_BANG_KE%'");
        if (v_ds_tu_dien.CM_DM_TU_DIEN.Rows.Count == 0) return 511;
        return CIPConvert.ToDecimal(v_ds_tu_dien.CM_DM_TU_DIEN.Rows[0][CM_DM_TU_DIEN.ID]);
    }
    // Kiểm tra xem hợp đồng có đúng là do đơn vị thanh toán đó thanh toán không???
    private bool check_hop_dong_ung_voi_dv_thanh_toan(decimal ip_dc_id_dv_thanh_toan, decimal ip_dc_id_hop_dong)
    {
        US_DM_HOP_DONG_KHUNG v_us_dm_hop_dong = new US_DM_HOP_DONG_KHUNG(ip_dc_id_hop_dong);
        if (v_us_dm_hop_dong.dcID_DON_VI_THANH_TOAN != ip_dc_id_dv_thanh_toan) return false;
        return true;
    }
    private string get_ten_dv_thanh_toan(decimal ip_dc_id_dv_thanh_toan)
    {
        US_DM_DON_VI_THANH_TOAN v_us_dm_dv_tt = new US_DM_DON_VI_THANH_TOAN(ip_dc_id_dv_thanh_toan);
        return v_us_dm_dv_tt.strTEN_DON_VI;
    }
    private decimal get_id_don_vi_thanh_toan_by_id_dot_tt(decimal ip_dc_id_dot_tt)
    {
        US_V_DM_DOT_THANH_TOAN v_us_dot_tt = new US_V_DM_DOT_THANH_TOAN(ip_dc_id_dot_tt);
        return v_us_dot_tt.dcID_DON_VI_THANH_TOAN;
    }
    private string mapping_string(object ip_obj_string)
    {
        if (ip_obj_string.GetType() == typeof(DBNull)) return "";
        return CIPConvert.ToStr(ip_obj_string);
    }
    //private bool check_hop_ly_so_tien()
    //{
    //    if()
    //    return false;
    //    return true;
    //}
    private bool check_exist_ma_mon(string ip_str_ma_lop_mon)
    {
        US_GD_LOP_MON v_us_gd_lop_mon = new US_GD_LOP_MON();
        DS_GD_LOP_MON v_ds_gd_lop_mon = new DS_GD_LOP_MON();
        v_us_gd_lop_mon.FillDataset(v_ds_gd_lop_mon, " WHERE MA_LOP_MON='" + ip_str_ma_lop_mon + "'");
        if (v_ds_gd_lop_mon.GD_LOP_MON.Rows.Count == 0)
            return false; // Nghĩa là không tồn tại lớp môn đó
        return true; // Nghĩa là tồn tại lớp môn đó
    }
    // Kiểm tra hợp đồng đã được thanh lý chưa? 
    private bool check_thanh_ly(decimal ip_dc_id_hop_dong_khung)
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
                return false; // Nghĩa là đã được thanh lý
        return true; // Chưa đc thanh lý
    }
    private bool check_tuong_ung_lop_mon_hop_dong(decimal ip_dc_id_hop_dong, string ip_str_ma_lop_mon)
    {
        US_GD_LOP_MON_DETAIL v_us_gd_lop_mon_detail = new US_GD_LOP_MON_DETAIL();
        DS_GD_LOP_MON_DETAIL v_ds_gd_lop_mon_detail = new DS_GD_LOP_MON_DETAIL();
        decimal v_dc_id_lop_mon = get_id_lop_mon_by_ma_lop_mon(ip_str_ma_lop_mon);
        v_us_gd_lop_mon_detail.FillDataset(v_ds_gd_lop_mon_detail, " WHERE ID_HOP_DONG_KHUNG = " + ip_dc_id_hop_dong + " AND ID_LOP_MON=" + v_dc_id_lop_mon);
        if (v_ds_gd_lop_mon_detail.GD_LOP_MON_DETAIL.Rows.Count == 0)
            return false; // Nghĩa là không tương ứng
        return true; // Nghĩa là tương ứng (hay chúng là 1 cặp)
    }
    private decimal get_id_lop_mon_by_ma_lop_mon(string ip_str_ma_lop_mon)
    {
        DS_GD_LOP_MON v_ds_lop_mon = new DS_GD_LOP_MON();
        US_GD_LOP_MON v_us_lop_mon = new US_GD_LOP_MON();
        v_us_lop_mon.FillDataset(v_ds_lop_mon, " WHERE MA_LOP_MON = N'" + ip_str_ma_lop_mon + "'");
        if (v_ds_lop_mon.GD_LOP_MON.Rows.Count == 0) return 0;
        return CIPConvert.ToDecimal(v_ds_lop_mon.GD_LOP_MON.Rows[0][GD_LOP_MON.ID]);
    }
    private bool check_trung_hop_dong(string ip_str_so_hd)
    {
        m_us_dm_hop_dong_khung.FillDataset(m_ds_dm_hop_dong_khung, " WHERE SO_HOP_DONG = N'" + ip_str_so_hd + "'");
        if (m_ds_dm_hop_dong_khung.V_DM_HOP_DONG_KHUNG.Rows.Count > 1) return false; // có hợp đồng trùng
        return true;
    }
    #endregion

    #region Export Excel
    private void loadDSExprort(ref string strTable)
    {
        int v_i_so_thu_tu = 0;
        load_data_2_export_excel(get_ma_dot_tt_by_id_dot(CIPConvert.ToDecimal(m_cbo_dot_thanh_toan.SelectedValue)));
        // Mỗi cột dữ liệu ứng với từng dòng là label
        foreach (DataRow grv in this.m_v_ds_gd_thanh_toan.V_GD_THANH_TOAN.Rows)
        {
            strTable += "\n<tr>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + ++v_i_so_thu_tu + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + CIPConvert.ToStr(grv[V_GD_THANH_TOAN.SO_PHIEU_THANH_TOAN]).Trim() + "</td>"; // Mã đợt thanh toán
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + CIPConvert.ToStr(grv[V_GD_THANH_TOAN.SO_HOP_DONG]).Trim() + "</td>"; // Số hợp đồng
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_magv_by_id(CIPConvert.ToDecimal(grv[V_GD_THANH_TOAN.ID_GIANG_VIEN])) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + CIPConvert.ToStr(grv[V_GD_THANH_TOAN.TEN_GIANG_VIEN]).Trim() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + CIPConvert.ToStr(grv[V_GD_THANH_TOAN.REFERENCE_CODE]).Trim() + "</td>"; // Mã lớp môn
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + grv[V_GD_THANH_TOAN.GHI_CHU_CAC_MON_PHU_TRACH].ToString() + "</td>"; // Tên môn
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + grv[V_GD_THANH_TOAN.GHI_CHU_THOI_GIAN_LOP_MON].ToString() + "</td>"; // Thời gian lớp môn
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + grv[V_GD_THANH_TOAN.GHI_CHU_HE_SO_DON_GIA].ToString() + "</td>"; // Hệ số quy mô lớp
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_so_tien(grv[V_GD_THANH_TOAN.TONG_TIEN_THANH_TOAN]) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_so_tien(grv[V_GD_THANH_TOAN.SO_TIEN_THUE]) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_so_tien(grv[V_GD_THANH_TOAN.TONG_TIEN_THUC_NHAN]) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + CIPConvert.ToStr(grv[V_GD_THANH_TOAN.NGAY_THANH_TOAN],"dd/MM/yyyy") + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_string(grv[V_GD_THANH_TOAN.DESCRIPTION]) + "</td>";  // Mô tả, ghi chú
            strTable += "\n</tr>";
        }
    }

    private void loadTieuDe(ref string strTable)
    {
        strTable += "<table cellpadding='2' cellspacing='0' class='cssTableReport'>";
        strTable += "\n<tr>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width: 100%;  height: 40px; font-size: large; color:White; background-color:#810C15;' nowrap='wrap'>DANH SÁCH THANH TOÁN HỢP ĐỒNG VẬN HÀNH" + "</td>";
        strTable += "\n</tr>";
        //
        strTable += "\n<tr>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>Đợt thanh toán: " + get_ma_dot_tt_by_id_dot(CIPConvert.ToDecimal(m_cbo_dot_thanh_toan.SelectedValue)) + "</td>";
        strTable += "\n</tr>";
        //
        strTable += "\n</table>";

        //table noi dung
        strTable += "<table cellpadding='2' cellspacing='0' class='cssTableReport'>";
        strTable += "\n<tr>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>STT</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Mã đợt thanh toán</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Số HĐ</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Mã giảng viên</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Tên giảng viên</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Các lớp môn phụ trách</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Tên các môn phụ trách</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Thời gian lớp môn</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Hệ số quy mô lớp</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Tổng tiền thanh toán đợt này (VNĐ)</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Số tiền thuế (VNĐ)</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Tổng tiền thực nhận đợt này (VNĐ)</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Ngày thanh toán</td>";
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
    protected void m_cmd_check_so_hd_Click(object sender, EventArgs e)
    {
        try
        {
            hdf_check_click_kiem_tra_so_hd.Value = "Đã check";
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cmd_luu_du_lieu_Click(object sender, EventArgs e)
    {
        try
        {
            //if (hdf_check_click_kiem_tra_so_hd.Value == null)
            //{
            //    string someScript;
            //    someScript = "<script language='javascript'>alert('Bạn chưa kiểm tra lại số hợp đồng. Nhấn nút Kiểm tra HĐ để thực hiện việc đó.');</script>";
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "onload", someScript);
            //    return;
            //}
            //// check bấm kiểm tra mã lớp môn
            //if (hdf_check_click_kiem_tra_lop_mon.Value == null)
            //{
            //    string someScript;
            //    someScript = "<script language='javascript'>alert('Bạn chưa kiểm tra lại lớp môn. Nhấn nút Kiểm tra LM để thực hiện việc đó.');</script>";
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "onload", someScript);
            //    return;
            //}
            // Kiểm tra tồn tại hợp đồng
            if (!check_exist_so_hop_dong(m_txt_so_hop_dong.Text.Trim()))
            {
                string Script;
                Script = "<script language='javascript'>alert('Số hợp đồng không tồn tại trong hệ thống');</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "onload", Script);
                //m_lbl_mess.Text = "";
                return;
            }
            //// Kiểm tra tồn tại mã lớp môn
            //if (!check_exist_ma_mon(m_txt_ma_lop_mon.Text.Trim()))
            //{
            //    string script;
            //    script = "<script language='javascript'>alert('Lớp môn này không tồn tại trong hệ thống')</script>";
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "oncheckmalop", script);
            //    return;
            //}

            decimal ip_dc_d_hop_dong = get_id_hd_khung_by_so_hd(m_txt_so_hop_dong.Text.Trim());

            // Kiểm tra hợp đồng khung và lớp môn là 1 cặp
            //if (!check_tuong_ung_lop_mon_hop_dong(ip_dc_d_hop_dong, m_txt_ma_lop_mon.Text.Trim()))
            //{
            //    string scriptalert;
            //    scriptalert = "<script language='javascript'>alert('Lớp môn và hợp đồng không tương ứng với nhau')</script>";
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "onchecktuongung", scriptalert);
            //    return;
            //}

            // Check trùng số hợp đồng
            if (!check_trung_hop_dong(m_txt_so_hop_dong.Text.Trim()))
            {
                string Script;
                Script = "<script language='javascript'>alert('Tồn tại số hợp đồng trùng với số hợp đồng này. Hãy xử lý trước khi lên bảng kê cho hợp đồng này!');</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "oncheck1", Script);
                return;
            }

            // Check hợp đồng do bên đv thanh toán này thanh toán
            decimal v_dc_id_dv_tt = get_id_don_vi_thanh_toan_by_id_dot_tt(CIPConvert.ToDecimal(m_cbo_dot_thanh_toan.SelectedValue));
            if (!check_hop_dong_ung_voi_dv_thanh_toan(v_dc_id_dv_tt, get_id_hd_khung_by_so_hd(m_txt_so_hop_dong.Text.Trim())))
            {
                string Script;
                Script = "<script language='javascript'>alert('Hợp đồng này không do " + get_ten_dv_thanh_toan(v_dc_id_dv_tt) + " thanh toán');</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "oncheck1", Script);
                return;
            }
            form_2_us_obj(m_us_v_gd_thanh_toan);
            m_us_v_gd_thanh_toan.Insert();
            load_data_2_grid(get_ma_dot_tt_by_id_dot(CIPConvert.ToDecimal(m_cbo_dot_thanh_toan.SelectedValue)));
            m_lbl_thong_bao.Text = "Thêm bản ghi thành công";
            reset_controls();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cmd_cap_nhat_du_toan_Click(object sender, EventArgs e)
    {
        try
        {
            if (hdf_id_gv.Value == "")
            {
                string someScript;
                someScript = "<script language='javascript'>alert('Bạn phải chọn thanh toán cần Cập nhật');</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "onload", someScript);
                //m_lbl_mess.Text = "";
                return;
            }
            //if (hdf_check_click_kiem_tra_so_hd.Value == null)
            //{
            //    string someScript;
            //    someScript = "<script language='javascript'>alert('Bạn chưa kiểm tra lại số hợp đồng. Nhấn nút Kiểm tra HĐ để thực hiện việc đó.');</script>";
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "onload", someScript);
            //    return;
            //}
            //if (hdf_check_click_kiem_tra_lop_mon.Value == null)
            //{
            //    string someScript;
            //    someScript = "<script language='javascript'>alert('Bạn chưa kiểm tra lại lớp môn. Nhấn nút Kiểm tra LM để thực hiện việc đó.');</script>";
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "onload", someScript);
            //    return;
            //}
            if (!check_exist_so_hop_dong(m_txt_so_hop_dong.Text.Trim()))
            {
                string Script;
                Script = "<script language='javascript'>alert('Số hợp đồng không tồn tại trong hệ thống. Hãy kiểm tra lại số hợp đồng!');</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "onload", Script);
                //m_lbl_mess.Text = "";
                return;
            }
            //if (!check_exist_ma_mon(m_txt_ma_lop_mon.Text.Trim()))
            //{
            //    string script;
            //    script = "<script language='javascript'>alert('Lớp môn này không tồn tại trong hệ thống')</script>";
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "oncheckmalop", script);
            //    return;
            //}
            form_2_us_obj(m_us_v_gd_thanh_toan);
            // Nếu đây là update thông tin bảng kê, kiểm tra trạng thái mới có phù hợp không?
            if (hdf_id_trang_thai_thanh_toan_cu.Value != "")
            {
                CValidatePaymentStates v_cvalidate_state = new CValidatePaymentStates();
                v_cvalidate_state.Trang_thai_thanh_toan_hien_tai = get_ma_trang_thai_thanh_toan_by_id(CIPConvert.ToDecimal(hdf_id_trang_thai_thanh_toan_cu.Value));
                v_cvalidate_state.set_trang_thai();
                if (!v_cvalidate_state.check_chuyen_trang_thai(get_ma_trang_thai_thanh_toan_by_id(m_us_v_gd_thanh_toan.dcID_TRANG_THAI_THANH_TOAN)))
                {
                    string someScript;
                    someScript = "<script language='javascript'>alert('Không chuyển từ trạng thái ban đầu của thanh toán về trạng thái này được!');</script>";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "onload", someScript);
                    return;
                }
            }
            m_us_v_gd_thanh_toan.dcID = CIPConvert.ToDecimal(hdf_id_gv.Value);
            m_us_v_gd_thanh_toan.Update();
            m_lbl_thong_bao.Visible = true;
            m_lbl_thong_bao.Text = "Cập nhật bản ghi thành công";            
            reset_controls();
            m_cmd_luu_du_lieu.Enabled = true;
            load_data_2_grid(get_ma_dot_tt_by_id_dot(CIPConvert.ToDecimal(m_cbo_dot_thanh_toan.SelectedValue)));
            hdf_check_click_kiem_tra_so_hd.Value = "";
            hdf_check_click_kiem_tra_lop_mon.Value = "";
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cmd_xoa_trang_Click(object sender, EventArgs e)
    {
        try
        {
            reset_controls();
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
            when_cbo_dot_tt_changed();
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
            m_init_mode = DataEntryFormMode.UpdateDataState;
            m_cmd_luu_du_lieu.Enabled = false;
            m_cmd_cap_nhat_du_toan.Enabled = true;
            load_data_2_us_by_id_and_show_on_form(e.NewSelectedIndex);
        }
        catch (Exception V_e)
        {
            CSystemLog_301.ExceptionHandle(this, V_e);
        }
    }
    protected void m_grv_danh_sach_du_toan_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            m_lbl_thong_bao.Text = "";
            delete_row_thanh_toan(e.RowIndex);
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
            string strNamFile = "BangkeThanhToanHDVanHanh" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + ".xls";
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
    protected void m_cmd_check_ma_lop_mon_Click(object sender, EventArgs e)
    {
        try
        {
            hdf_check_click_kiem_tra_lop_mon.Value = "Đã check";
            //string script;
            //if (!check_exist_ma_mon(m_txt_ma_lop_mon.Text.Trim()))
            //{
            //    script = "<script language='javascript'>alert('Lớp môn này không tồn tại trong hệ thống')</script>";
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "oncheckmalop", script);
            //    return;
            //}
            //script = "<script language='javascript'>alert('Mã lớp môn hợp lệ')</script>";
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "onsucced", script);
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
    #endregion    
   
}