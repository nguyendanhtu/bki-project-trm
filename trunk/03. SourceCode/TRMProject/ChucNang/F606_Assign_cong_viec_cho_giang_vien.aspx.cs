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

public partial class ChucNang_F606_Assign_cong_viec_cho_giang_vien : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            load_data_2_grv();
            load_data_2_cbo_noi_dung_tt();
            load_data_2_cbo_trang_thai_cv_gv();
        }
    }

    protected void m_btn_check_Click(object sender, EventArgs e)
    {
        if (!check_exist_so_hd(m_txt_so_hop_dong.Text))
        {
            m_lbl_thong_bao_so_hd.Text = "   Số hợp đồng này chưa có ! Vui lòng kiểm tra lại.";
            m_txt_so_hop_dong.Focus();
        }
        else m_lbl_thong_bao_so_hd.Text = "   Hợp đồng đã tồn tại. Xin mời tiếp tục...";
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        clear_form();
    }

    #region Members
    US_GD_GV_CONG_VIEC_MOI m_us_cong_viec_moi = new US_GD_GV_CONG_VIEC_MOI();
    DS_GD_GV_CONG_VIEC_MOI m_ds_cong_viec_moi = new DS_GD_GV_CONG_VIEC_MOI();
    #endregion

    #region Private Interfaces
    private void load_data_2_grv()
    {
        m_us_cong_viec_moi.FillDataset(m_ds_cong_viec_moi);
        m_grv_gd_assign_su_kien_cho_giang_vien.DataSource = m_ds_cong_viec_moi.GD_GV_CONG_VIEC_MOI;
        m_grv_gd_assign_su_kien_cho_giang_vien.DataBind();
    }
    private void load_data_2_us_update(int ip_i_stt_row)
    {
        decimal v_dc_id_cong_viec_gv = CIPConvert.ToDecimal(m_grv_gd_assign_su_kien_cho_giang_vien.DataKeys[ip_i_stt_row].Value);
        m_txt_so_hop_dong.ToolTip = CIPConvert.ToStr(v_dc_id_cong_viec_gv);
        m_us_cong_viec_moi = new US_GD_GV_CONG_VIEC_MOI(v_dc_id_cong_viec_gv);
    }
    private void us_object_2_form(US_GD_GV_CONG_VIEC_MOI ip_us_v_gd_cv_moi)
    {
        m_txt_so_hop_dong.Text = mapping_so_hop_dong_by_id(ip_us_v_gd_cv_moi.dcID_HOP_DONG_KHUNG);
        m_cbo_noi_dung_thanh_toan.SelectedValue = CIPConvert.ToStr(ip_us_v_gd_cv_moi.dcID_NOI_DUNG_TT);
        m_txt_so_luong.Text = CIPConvert.ToStr(ip_us_v_gd_cv_moi.dcSO_LUONG_HE_SO,"#");
        m_txt_don_gia.Text = CIPConvert.ToStr(ip_us_v_gd_cv_moi.dcDON_GIA, "#,###");
        if (!m_us_cong_viec_moi.IsNGAY_DAT_HANGNull()) m_dat_ngay_bat_dau.SelectedDate = CIPConvert.ToDatetime(CIPConvert.ToStr(m_us_cong_viec_moi.datNGAY_DAT_HANG, "dd/MM/yyyy"), "dd/MM/yyyy");
        if (!m_us_cong_viec_moi.IsNGAY_NGHIEM_THUNull()) m_dat_ngay_nghiem_thu.SelectedDate = CIPConvert.ToDatetime(CIPConvert.ToStr(m_us_cong_viec_moi.datNGAY_NGHIEM_THU, "dd/MM/yyyy"), "dd/MM/yyyy");
        m_cbo_trang_thai_cv_gv.SelectedValue = CIPConvert.ToStr(ip_us_v_gd_cv_moi.dcID_TRANG_THAI);
        m_txt_ghi_chu.Text = ip_us_v_gd_cv_moi.strGHI_CHU;
    }
    private void form_2_us_object()
    {
        System.Globalization.CultureInfo enUS = new System.Globalization.CultureInfo("en-US");
        DateTime v_dat_out_result;
        if(m_txt_so_hop_dong.Text != "")
        {
           m_us_cong_viec_moi.dcID_HOP_DONG_KHUNG = get_id_by_so_hop_dong(m_txt_so_hop_dong.Text); 
        }
        m_us_cong_viec_moi.dcID_NOI_DUNG_TT = CIPConvert.ToDecimal(m_cbo_noi_dung_thanh_toan.SelectedValue);
        if(m_txt_so_luong.Text != "")
        {
            m_us_cong_viec_moi.dcSO_LUONG_HE_SO = CIPConvert.ToDecimal(m_txt_so_luong.Text);
        }
        if(m_txt_don_gia.Text != "")
        {
            m_us_cong_viec_moi.dcDON_GIA = CIPConvert.ToDecimal(m_txt_don_gia.Text);
        }
        if (DateTime.TryParseExact(CIPConvert.ToStr(m_dat_ngay_bat_dau.SelectedDate), "dd/MM/yyyy", enUS, System.Globalization.DateTimeStyles.None, out v_dat_out_result))
        {
            if (m_dat_ngay_bat_dau.SelectedDate != CIPConvert.ToDatetime("01/01/0001"))
                m_us_cong_viec_moi.datNGAY_DAT_HANG = m_dat_ngay_bat_dau.SelectedDate;
            else m_us_cong_viec_moi.datNGAY_DAT_HANG = CIPConvert.ToDatetime("01/01/1900");
        }
        if (DateTime.TryParseExact(CIPConvert.ToStr(m_dat_ngay_nghiem_thu.SelectedDate), "dd/MM/yyyy", enUS, System.Globalization.DateTimeStyles.None, out v_dat_out_result))
        {
            if (m_dat_ngay_nghiem_thu.SelectedDate != CIPConvert.ToDatetime("01/01/0001"))
                m_us_cong_viec_moi.datNGAY_NGHIEM_THU = m_dat_ngay_bat_dau.SelectedDate;
            else m_us_cong_viec_moi.datNGAY_NGHIEM_THU = CIPConvert.ToDatetime("01/01/1900");
        }
        m_us_cong_viec_moi.dcID_TRANG_THAI = CIPConvert.ToDecimal(m_cbo_trang_thai_cv_gv.SelectedValue);
        m_us_cong_viec_moi.strGHI_CHU = m_txt_ghi_chu.Text;
        m_us_cong_viec_moi.dcID_USER_NHAP = get_id_user_by_username(CIPConvert.ToStr(Session["Username"]));

    }
    private void load_data_2_cbo_noi_dung_tt()
    {
        US_DM_NOI_DUNG_THANH_TOAN v_us_dm_noi_dung_tt = new US_DM_NOI_DUNG_THANH_TOAN();
        DS_DM_NOI_DUNG_THANH_TOAN v_ds_dm_noi_dung_tt = new DS_DM_NOI_DUNG_THANH_TOAN();
        
        v_us_dm_noi_dung_tt.FillDataset(v_ds_dm_noi_dung_tt);

        m_cbo_noi_dung_thanh_toan.DataTextField  = DM_NOI_DUNG_THANH_TOAN.TEN_NOI_DUNG;
        m_cbo_noi_dung_thanh_toan.DataValueField = DM_NOI_DUNG_THANH_TOAN.ID;

        m_cbo_noi_dung_thanh_toan.DataSource = v_ds_dm_noi_dung_tt.DM_NOI_DUNG_THANH_TOAN;
        m_cbo_noi_dung_thanh_toan.DataBind();
    }
    private void load_data_2_cbo_trang_thai_cv_gv()
    {
        US_CM_DM_TU_DIEN v_us_tu_dien = new US_CM_DM_TU_DIEN();
        DS_CM_DM_TU_DIEN v_ds_tu_dien = new DS_CM_DM_TU_DIEN();

        v_us_tu_dien.FillDataset(v_ds_tu_dien, "WHERE ID_LOAI_TU_DIEN=21");

        m_cbo_trang_thai_cv_gv.DataTextField = CM_DM_TU_DIEN.TEN;
        m_cbo_trang_thai_cv_gv.DataValueField = CM_DM_TU_DIEN.ID;

        m_cbo_trang_thai_cv_gv.DataSource = v_ds_tu_dien.CM_DM_TU_DIEN;
        m_cbo_trang_thai_cv_gv.DataBind();
    }
    /// <summary>
    /// Kiểm tra xem số hợp đồng này đã có hay chưa
    /// </summary>
    /// <param name="ip_str_so_hd">Số hợp đồng</param>
    private bool check_exist_so_hd(string ip_str_so_hd)
    {
        US_DM_HOP_DONG_KHUNG v_us_dm_hop_dong_khung = new US_DM_HOP_DONG_KHUNG();
        DS_DM_HOP_DONG_KHUNG v_ds_dm_hop_dong_khung = new DS_DM_HOP_DONG_KHUNG();

        v_us_dm_hop_dong_khung.check_so_hop_dong(v_ds_dm_hop_dong_khung, ip_str_so_hd);
        if (v_ds_dm_hop_dong_khung.DM_HOP_DONG_KHUNG.Rows.Count <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    private void clear_form()
    {
        m_txt_so_hop_dong.Text = "";
        m_txt_don_gia.Text = "";
        m_txt_so_luong.Text = "";
        m_txt_ghi_chu.Text = "";
        m_dat_ngay_bat_dau.Text = "";
        m_dat_ngay_bat_dau.Text = "";
        m_dat_ngay_nghiem_thu.Text = "";
        m_lbl_thong_bao_so_hd.Text = "";
        m_lbl_mess.Text = "";
        m_dat_ngay_bat_dau.Text = "";
        m_dat_ngay_nghiem_thu.Text = "";
    }
    private decimal get_id_user_by_username(string ip_strsusername)
    {
        US_HT_NGUOI_SU_DUNG v_us_ht_nguoi_su_dung = new US_HT_NGUOI_SU_DUNG();
        DS_HT_NGUOI_SU_DUNG v_ds_ht_nguoi_su_dung = new DS_HT_NGUOI_SU_DUNG();
        v_us_ht_nguoi_su_dung.FillDataset(v_ds_ht_nguoi_su_dung, " WHERE TEN_TRUY_CAP=N'" + ip_strsusername + "'");
        return CIPConvert.ToDecimal(v_ds_ht_nguoi_su_dung.HT_NGUOI_SU_DUNG.Rows[0][HT_NGUOI_SU_DUNG.ID]);
    }
    private void search_gv_cong_viec_moi_and_load_2_grv()
    {
        // Thu thập dữ liệu từ form tìm kiếm
        string v_str_so_hd = m_txt_so_hop_dong.Text.Trim();
        decimal v_dc_noi_dung = CIPConvert.ToDecimal(m_cbo_noi_dung_thanh_toan.SelectedValue);
        decimal v_dc_id_trang_thai = CIPConvert.ToDecimal(m_cbo_trang_thai_cv_gv.SelectedValue);
        string v_str_tu_khoa = m_txt_tu_khoa.Text.Trim();
        // Search
        m_us_cong_viec_moi.loc_du_lieu_gv_cong_viec_moi(m_ds_cong_viec_moi, v_str_so_hd, v_dc_noi_dung, v_dc_id_trang_thai, v_str_tu_khoa);
        m_grv_gd_assign_su_kien_cho_giang_vien.DataSource = m_ds_cong_viec_moi.GD_GV_CONG_VIEC_MOI;
        m_grv_gd_assign_su_kien_cho_giang_vien.DataBind();
        m_lbl_ket_qua_loc_du_lieu.Text = "Kết quả lọc dữ liệu: Có " + m_ds_cong_viec_moi.GD_GV_CONG_VIEC_MOI.Rows.Count + " bản ghi phù hợp.";
        if (m_ds_cong_viec_moi.GD_GV_CONG_VIEC_MOI.Rows.Count == 0)
        {
            m_lbl_ket_qua_loc_du_lieu.Text = "Kết quả lọc dữ liệu";
            m_lbl_thong_bao_sau_cap_nhat.Text = "* Không có bản ghi nào phù hợp.";
        }

    }
    #endregion

    #region Public Interfaces
    public string mapping_so_hop_dong_by_id(object ip_obj_id_hop_dong)
    {
        US_DM_HOP_DONG_KHUNG v_us_hop_dong_khung = new US_DM_HOP_DONG_KHUNG(CIPConvert.ToDecimal(ip_obj_id_hop_dong));
        return v_us_hop_dong_khung.strSO_HOP_DONG;
    }
    public string mapping_noi_dung_thanh_toan_by_id(object ip_obj_id_noi_dung_tt)
    {
        US_DM_NOI_DUNG_THANH_TOAN v_us_noi_dung_tt = new US_DM_NOI_DUNG_THANH_TOAN(CIPConvert.ToDecimal(ip_obj_id_noi_dung_tt));
        return v_us_noi_dung_tt.strTEN_NOI_DUNG;
    }
    public string mapping_trang_thai_by_id(object ip_obj_id_trang_thai)
    {
        US_CM_DM_TU_DIEN v_us_tu_dien = new US_CM_DM_TU_DIEN(CIPConvert.ToDecimal(ip_obj_id_trang_thai));
        return v_us_tu_dien.strTEN;
    }
    public decimal get_id_by_so_hop_dong(string ip_so_hop_dong)
    {
        US_DM_HOP_DONG_KHUNG v_us_hop_dong = new US_DM_HOP_DONG_KHUNG();
        DS_DM_HOP_DONG_KHUNG v_ds_hop_dong = new DS_DM_HOP_DONG_KHUNG();
        v_us_hop_dong.FillDataset(v_ds_hop_dong);
        return CIPConvert.ToDecimal(v_ds_hop_dong.DM_HOP_DONG_KHUNG.Rows[0][DM_HOP_DONG_KHUNG.ID]);
    }
    #endregion

    protected void An_form_click_Sua()
    {
        m_lbl_ds_cv_gv.Text = "Sửa Công việc mới - giảng viên";
        m_txt_so_hop_dong.Enabled = false;
        m_btn_check.Visible = false;
        m_lbl_thong_bao_so_hd.Visible = false;
        lbl_tu_khoa.Visible = false;
        m_txt_tu_khoa.Visible = false;
        lbl_tb_cap_nhat.Visible = false;
        lbl_tu_khoa_tim_kiem.Visible = false;
        m_cmd_tao_moi.Visible = false;
        m_cmd_xuat_excel.Visible = false;
        m_cmd_loc_du_lieu.Visible = false;
        m_cmd_xoa_trang.Visible = false;
        m_cmd_cap_nhat.Visible = true;
        m_cmd_huy.Visible = true;
    }
    protected void Hien_thi_nhu_ban_dau()
    {
        m_lbl_ds_cv_gv.Text = "Danh sách công việc mới - giảng viên";
        m_txt_so_hop_dong.Enabled = true;
        m_btn_check.Visible = true;
        m_lbl_thong_bao_so_hd.Visible = true;
        lbl_tu_khoa.Visible = true;
        m_txt_tu_khoa.Visible = true;
        lbl_tb_cap_nhat.Visible = true;
        lbl_tu_khoa_tim_kiem.Visible = true;
        m_cmd_tao_moi.Visible = true;
        m_cmd_xuat_excel.Visible = true;
        m_cmd_loc_du_lieu.Visible = true;
        m_cmd_xoa_trang.Visible = false;
        m_cmd_cap_nhat.Visible = false;
        m_cmd_huy.Visible = false;
        m_cmd_xoa_trang.Visible = true;
    }
    protected void m_grv_gd_assign_su_kien_cho_giang_vien_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        decimal v_dc_id_cv_gv = CIPConvert.ToDecimal(m_grv_gd_assign_su_kien_cho_giang_vien.DataKeys[e.RowIndex].Value);
        m_us_cong_viec_moi.DeleteByID(v_dc_id_cv_gv);
        m_lbl_thong_bao_sau_cap_nhat.Text = " * Xóa bản ghi thành công !";
        load_data_2_grv();
        m_txt_so_hop_dong.ToolTip = "";
    }
    protected void m_grv_gd_assign_su_kien_cho_giang_vien_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        load_data_2_us_update(e.RowIndex);
        us_object_2_form(m_us_cong_viec_moi);
        An_form_click_Sua();
    }
    protected void m_cmd_cap_nhat_Click(object sender, EventArgs e)
    {
        form_2_us_object();
        m_us_cong_viec_moi.dcID = CIPConvert.ToDecimal(m_txt_so_hop_dong.ToolTip);
        m_us_cong_viec_moi.Update();
        load_data_2_grv();
        m_txt_so_hop_dong.ToolTip = "";
        clear_form();

        m_lbl_thong_bao_sau_cap_nhat.Text = " * Cập nhật thành công !";
        Hien_thi_nhu_ban_dau();

    }
    protected void m_cmd_huy_Click(object sender, EventArgs e)
    {
        clear_form();
        Hien_thi_nhu_ban_dau();
    }
    protected void m_cmd_tao_moi_Click(object sender, EventArgs e)
    {
        if (!check_exist_so_hd(m_txt_so_hop_dong.Text))
        {
            m_lbl_thong_bao_so_hd.Text = "   Số hợp đồng này chưa có ! Vui lòng kiểm tra lại.";
            m_txt_so_hop_dong.Focus();
        }
        else
        {
            form_2_us_object();
            m_us_cong_viec_moi.Insert();
            m_lbl_thong_bao_sau_cap_nhat.Text = " * Thêm thành công một bản ghi !";
            load_data_2_grv();
            clear_form();
        }
        
    }
    protected void m_cmd_loc_du_lieu_Click(object sender, EventArgs e)
    {
        search_gv_cong_viec_moi_and_load_2_grv();
    }
}