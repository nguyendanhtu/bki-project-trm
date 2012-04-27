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

public partial class ChucNang_F306_HopDongKhungGiangVien : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //m_txt_so_hop_dong.Enabled = true;
        m_cmd_luu_va_sinh_pl.Enabled = true;
        if (!IsPostBack)
        {
            load_2_cbo_don_vi_tt();
            load_2_cbo_giang_vien();
            load_2_cbo_trang_thai_hd();
            load_2_cbo_don_vi_quan_ly();
            load_2_cbo_loai_hop_dong();
            load_2_cbo_mon_hoc_1();
            load_2_cbo_mon_hoc_2();
            load_2_cbo_mon_hoc_3();
            load_2_cbo_mon_hoc_4();
            load_2_cbo_mon_hoc_5();
            load_2_cbo_mon_hoc_6();
            load_2_cbo_po_phu_trach();
            // Nếu là trạng thái edit mới load lại form, cho vào trong ispostback để tránh việc sau khi đã sửa dữ liệu, 
            //nó lại load lại form ban đầu
            if (Request.QueryString["mode"] != null && Request.QueryString["mode"].ToString() == "edit")
            {
                load_data_2_us_by_id_and_show_on_form(CIPConvert.ToDecimal(Request.QueryString["id_hd"]));
            }
        }
        // Lấy thông tin id giảng viên, đây là lúc mới ban đầu nhận id giảng viên và load lên lưới
        if (Request.QueryString["id_gv"] != null && Request.QueryString["id_gv"].ToString() != "")
        {
            m_dc_id_gv = CIPConvert.ToDecimal(Request.QueryString["id_gv"]);
        }

        if (Request.QueryString["mode"] != null && Request.QueryString["mode"].ToString() == "edit")
        {
            m_init_mode = DataEntryFormMode.UpdateDataState;
            m_dc_id_gv = get_id_gv_from_id_hd(CIPConvert.ToDecimal(Request.QueryString["id_hd"]));
        }
        else m_init_mode = DataEntryFormMode.InsertDataState;

        // Text của header, nếu id_gv > 0
        if (m_dc_id_gv > 0)
        {
            m_pnl_table.Visible = false;
            m_lbl_header_giang_vien.Text = "Danh sách hợp đồng khung của giảng viên: " + get_gv_info(m_dc_id_gv);
        }

        // Đẩy dữ liệu lên lưới
        load_data_2_grid(m_dc_id_gv);

        if (m_init_mode == DataEntryFormMode.UpdateDataState)
        {
            m_pnl_table.Visible = true;
            m_cbo_gvien.Enabled = false;
            //m_txt_so_hop_dong.Enabled = false;
            m_cmd_luu_va_sinh_pl.Enabled = false;
            m_dc_id_hd = CIPConvert.ToDecimal(Request.QueryString["id_hd"]);
        }     

    }
    #region Members
    US_V_DM_HOP_DONG_KHUNG m_us_dm_hop_dong_khung = new US_V_DM_HOP_DONG_KHUNG();
    DS_V_DM_HOP_DONG_KHUNG m_ds_hop_dong_khung = new DS_V_DM_HOP_DONG_KHUNG();

    US_CM_DM_TU_DIEN m_us_cm_dm_tu_dien = new US_CM_DM_TU_DIEN();
    DS_CM_DM_TU_DIEN m_ds_cm_dm_tu_dien = new DS_CM_DM_TU_DIEN();

    US_V_DM_GIANG_VIEN m_us_dm_giang_vien = new US_V_DM_GIANG_VIEN();
    DS_V_DM_GIANG_VIEN m_ds_dm_giang_vien = new DS_V_DM_GIANG_VIEN();
    DataEntryFormMode m_init_mode;
    decimal m_dc_id_gv, m_dc_id_hd;
    #endregion

    #region private Method
    private decimal get_id_gv_from_id_hd(decimal ip_dc_id_hdong)
    {
        try
        {
            US_V_DM_HOP_DONG_KHUNG v_us_dm_hop_dong_khung = new US_V_DM_HOP_DONG_KHUNG(ip_dc_id_hdong);
            if (v_us_dm_hop_dong_khung.IsIDNull()) return 0;
            return v_us_dm_hop_dong_khung.dcID_GIANG_VIEN;
        }
        catch (Exception v_e)
        {
            
            throw v_e;
        }
    }
    private void load_data_2_us_by_id_and_show_on_form(decimal ip_i_id)
    {
        US_V_DM_HOP_DONG_KHUNG v_us_hop_dong_khung = new US_V_DM_HOP_DONG_KHUNG(ip_i_id);
        // Đẩy us lên form
        us_object_2_form(v_us_hop_dong_khung);
    }
    private void load_2_cbo_trang_thai_hd()
    {
        US_CM_DM_TU_DIEN v_us_trang_thai_hd = new US_CM_DM_TU_DIEN();
        DS_CM_DM_TU_DIEN v_ds_trang_thai_hd = new DS_CM_DM_TU_DIEN();
        try
        {
            v_us_trang_thai_hd.FillDataset(v_ds_trang_thai_hd, " WHERE ID_LOAI_TU_DIEN =" + (int)e_loai_tu_dien.TRANG_THAI_HOP_DONG_KHUNG);
            m_cbo_dm_trang_thai_hop_dong.DataSource = v_ds_trang_thai_hd.CM_DM_TU_DIEN;
            m_cbo_dm_trang_thai_hop_dong.DataValueField = CM_DM_TU_DIEN.ID;
            m_cbo_dm_trang_thai_hop_dong.DataTextField = CM_DM_TU_DIEN.TEN;
            m_cbo_dm_trang_thai_hop_dong.DataBind();
        }
        catch (Exception v_e)
        {

            throw v_e;
        }
    }
    private void load_2_cbo_giang_vien()
    {
        US_V_DM_GIANG_VIEN v_us_giang_vien = new US_V_DM_GIANG_VIEN();
        DS_V_DM_GIANG_VIEN v_ds_giang_vien = new DS_V_DM_GIANG_VIEN();
        try
        {
            v_us_giang_vien.FillDataset(v_ds_giang_vien);
            for (int v_i = 0; v_i < v_ds_giang_vien.V_DM_GIANG_VIEN.Rows.Count; v_i++)
            {
                m_cbo_gvien.Items.Add(new ListItem(v_ds_giang_vien.V_DM_GIANG_VIEN.Rows[v_i][V_DM_GIANG_VIEN.HO_VA_TEN_DEM].ToString().TrimEnd() + " " + v_ds_giang_vien.V_DM_GIANG_VIEN.Rows[v_i][V_DM_GIANG_VIEN.TEN_GIANG_VIEN].ToString(), v_ds_giang_vien.V_DM_GIANG_VIEN.Rows[v_i][V_DM_GIANG_VIEN.ID].ToString()));
            }
        }
        catch (Exception v_e)
        {

            throw v_e;
        }
    }
    private void load_2_cbo_mon_hoc_1()
    {
        US_DM_MON_HOC v_us_dm_mon_hoc_1 = new US_DM_MON_HOC();
        DS_DM_MON_HOC v_ds_dm_mon_hoc_1 = new DS_DM_MON_HOC();
        try
        {
            v_us_dm_mon_hoc_1.FillDataset(v_ds_dm_mon_hoc_1," ORDER BY TEN_MON_HOC");
            m_cbo_dm_mon_hoc_1.DataSource = v_ds_dm_mon_hoc_1.DM_MON_HOC;
            m_cbo_dm_mon_hoc_1.DataValueField = DM_MON_HOC.ID;
            m_cbo_dm_mon_hoc_1.DataTextField = DM_MON_HOC.TEN_MON_HOC;
            m_cbo_dm_mon_hoc_1.DataBind();
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    private void load_2_cbo_mon_hoc_2()
    {
        US_DM_MON_HOC v_us_dm_mon_hoc_2 = new US_DM_MON_HOC();
        DS_DM_MON_HOC v_ds_dm_mon_hoc_2 = new DS_DM_MON_HOC();
        try
        {
            v_us_dm_mon_hoc_2.FillDataset(v_ds_dm_mon_hoc_2, " ORDER BY TEN_MON_HOC");
            DataRow v_dr_none = v_ds_dm_mon_hoc_2.DM_MON_HOC.NewDM_MON_HOCRow();
            v_dr_none[DM_MON_HOC.ID] = "0";
            v_dr_none[DM_MON_HOC.TEN_MON_HOC] = "Không có";
            v_dr_none[DM_MON_HOC.MA_MON_HOC] = "none";
            v_ds_dm_mon_hoc_2.DM_MON_HOC.Rows.InsertAt(v_dr_none, 0);

           // v_us_dm_mon_hoc_2.FillDataset(v_ds_dm_mon_hoc_2);
            m_cbo_dm_mon_hoc_2.DataSource = v_ds_dm_mon_hoc_2.DM_MON_HOC;
            m_cbo_dm_mon_hoc_2.DataValueField = DM_MON_HOC.ID;
            m_cbo_dm_mon_hoc_2.DataTextField = DM_MON_HOC.TEN_MON_HOC;
            m_cbo_dm_mon_hoc_2.SelectedIndex = 0;
            m_cbo_dm_mon_hoc_2.DataBind();
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    private void load_2_cbo_mon_hoc_3()
    {
        US_DM_MON_HOC v_us_dm_mon_hoc_3 = new US_DM_MON_HOC();
        DS_DM_MON_HOC v_ds_dm_mon_hoc_3 = new DS_DM_MON_HOC();
        try
        {
            v_us_dm_mon_hoc_3.FillDataset(v_ds_dm_mon_hoc_3, " ORDER BY TEN_MON_HOC");
            DataRow v_dr_none = v_ds_dm_mon_hoc_3.DM_MON_HOC.NewDM_MON_HOCRow();
            v_dr_none[DM_MON_HOC.ID] = "0";
            v_dr_none[DM_MON_HOC.TEN_MON_HOC] = "Không có";
            v_dr_none[DM_MON_HOC.MA_MON_HOC] = "none";
            v_ds_dm_mon_hoc_3.DM_MON_HOC.Rows.InsertAt(v_dr_none, 0);

           // v_us_dm_mon_hoc_3.FillDataset(v_ds_dm_mon_hoc_3);
            m_cbo_dm_mon_hoc_3.DataSource = v_ds_dm_mon_hoc_3.DM_MON_HOC;
            m_cbo_dm_mon_hoc_3.DataValueField = DM_MON_HOC.ID;
            m_cbo_dm_mon_hoc_3.DataTextField = DM_MON_HOC.TEN_MON_HOC;

            m_cbo_dm_mon_hoc_3.DataBind();
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    private void load_2_cbo_mon_hoc_4()
    {
        US_DM_MON_HOC v_us_dm_mon_hoc_4 = new US_DM_MON_HOC();
        DS_DM_MON_HOC v_ds_dm_mon_hoc_4 = new DS_DM_MON_HOC();
        try
        {
            v_us_dm_mon_hoc_4.FillDataset(v_ds_dm_mon_hoc_4, " ORDER BY TEN_MON_HOC");
            DataRow v_dr_none = v_ds_dm_mon_hoc_4.DM_MON_HOC.NewDM_MON_HOCRow();
            v_dr_none[DM_MON_HOC.ID] = "0";
            v_dr_none[DM_MON_HOC.TEN_MON_HOC] = "Không có";
            v_dr_none[DM_MON_HOC.MA_MON_HOC] = "none";
            v_ds_dm_mon_hoc_4.DM_MON_HOC.Rows.InsertAt(v_dr_none, 0);

          //  v_us_dm_mon_hoc_4.FillDataset(v_ds_dm_mon_hoc_4);
            m_cbo_dm_mon_hoc_4.DataSource = v_ds_dm_mon_hoc_4.DM_MON_HOC;
            m_cbo_dm_mon_hoc_4.DataValueField = DM_MON_HOC.ID;
            m_cbo_dm_mon_hoc_4.DataTextField = DM_MON_HOC.TEN_MON_HOC;
            m_cbo_dm_mon_hoc_4.DataBind();
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    private void load_2_cbo_mon_hoc_5()
    {
        US_DM_MON_HOC v_us_dm_mon_hoc_5 = new US_DM_MON_HOC();
        DS_DM_MON_HOC v_ds_dm_mon_hoc_5 = new DS_DM_MON_HOC();
        try
        {
            v_us_dm_mon_hoc_5.FillDataset(v_ds_dm_mon_hoc_5, " ORDER BY TEN_MON_HOC");
            DataRow v_dr_none = v_ds_dm_mon_hoc_5.DM_MON_HOC.NewDM_MON_HOCRow();
            v_dr_none[DM_MON_HOC.ID] = "0";
            v_dr_none[DM_MON_HOC.TEN_MON_HOC] = "Không có";
            v_dr_none[DM_MON_HOC.MA_MON_HOC] = "none";
            v_ds_dm_mon_hoc_5.DM_MON_HOC.Rows.InsertAt(v_dr_none, 0);

            m_cbo_dm_mon_hoc_5.DataSource = v_ds_dm_mon_hoc_5.DM_MON_HOC;
            m_cbo_dm_mon_hoc_5.DataValueField = DM_MON_HOC.ID;
            m_cbo_dm_mon_hoc_5.DataTextField = DM_MON_HOC.TEN_MON_HOC;
            m_cbo_dm_mon_hoc_2.SelectedIndex = 0;
            m_cbo_dm_mon_hoc_5.DataBind();
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    private void load_2_cbo_mon_hoc_6()
    {
        US_DM_MON_HOC v_us_dm_mon_hoc_6 = new US_DM_MON_HOC();
        DS_DM_MON_HOC v_ds_dm_mon_hoc_6 = new DS_DM_MON_HOC();
        try
        {
            v_us_dm_mon_hoc_6.FillDataset(v_ds_dm_mon_hoc_6, " ORDER BY TEN_MON_HOC");
            DataRow v_dr_none = v_ds_dm_mon_hoc_6.DM_MON_HOC.NewDM_MON_HOCRow();
            v_dr_none[DM_MON_HOC.ID] = "0";
            v_dr_none[DM_MON_HOC.TEN_MON_HOC] = "Không có";
            v_dr_none[DM_MON_HOC.MA_MON_HOC] = "none";
            v_ds_dm_mon_hoc_6.DM_MON_HOC.Rows.InsertAt(v_dr_none, 0);

            //v_us_dm_mon_hoc_6.FillDataset(v_ds_dm_mon_hoc_6);
            m_cbo_dm_mon_hoc_6.DataSource = v_ds_dm_mon_hoc_6.DM_MON_HOC;
            m_cbo_dm_mon_hoc_6.DataValueField = DM_MON_HOC.ID;
            m_cbo_dm_mon_hoc_6.DataTextField = DM_MON_HOC.TEN_MON_HOC;
            m_cbo_dm_mon_hoc_2.SelectedIndex = 0;
            m_cbo_dm_mon_hoc_6.DataBind();
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    private void load_2_cbo_loai_hop_dong()
    {
        US_CM_DM_TU_DIEN v_us_dm_loai_hop_dong = new US_CM_DM_TU_DIEN();
        DS_CM_DM_TU_DIEN v_ds_dm_loai_hop_dong = new DS_CM_DM_TU_DIEN();
        try
        {
            v_us_dm_loai_hop_dong.FillDataset(v_ds_dm_loai_hop_dong, " WHERE ID_LOAI_TU_DIEN = " + (int)e_loai_tu_dien.LOAI_HOP_DONG);
            m_cbo_dm_loai_hop_dong.DataSource = v_ds_dm_loai_hop_dong.CM_DM_TU_DIEN;
            m_cbo_dm_loai_hop_dong.DataValueField = CM_DM_TU_DIEN.ID;
            m_cbo_dm_loai_hop_dong.DataTextField = CM_DM_TU_DIEN.TEN;
            m_cbo_dm_loai_hop_dong.DataBind();
        }
        catch (Exception v_e)
        {

            throw v_e;
        }
    }
    private void load_2_cbo_don_vi_quan_ly()
    {
        US_CM_DM_TU_DIEN v_us_don_vi_quan_ly = new US_CM_DM_TU_DIEN();
        DS_CM_DM_TU_DIEN v_ds_don_vi_quan_ly = new DS_CM_DM_TU_DIEN();
        try
        {
            v_us_don_vi_quan_ly.FillDataset(v_ds_don_vi_quan_ly, " WHERE ID_LOAI_TU_DIEN = " + (int)e_loai_tu_dien.DON_VI_QUAN_LY_CHINH);
            m_cbo_dm_loai_don_vi_quan_li.DataSource = v_ds_don_vi_quan_ly.CM_DM_TU_DIEN;
            m_cbo_dm_loai_don_vi_quan_li.DataValueField = CM_DM_TU_DIEN.ID;
            m_cbo_dm_loai_don_vi_quan_li.DataTextField = CM_DM_TU_DIEN.TEN;
            m_cbo_dm_loai_don_vi_quan_li.DataBind();
        }
        catch (Exception v_e)
        {

            throw v_e;
        }

    }
    private void load_2_cbo_don_vi_tt()
    {
        US_DM_DON_VI_THANH_TOAN v_us_don_vi_tt = new US_DM_DON_VI_THANH_TOAN();
        DS_DM_DON_VI_THANH_TOAN v_ds_don_vi_tt = new DS_DM_DON_VI_THANH_TOAN();
        try
        {
            v_us_don_vi_tt.FillDataset(v_ds_don_vi_tt);
            m_cbo_dm_loai_don_vi_thanh_toan.DataSource = v_ds_don_vi_tt.DM_DON_VI_THANH_TOAN;
            m_cbo_dm_loai_don_vi_thanh_toan.DataValueField = DM_DON_VI_THANH_TOAN.ID;
            m_cbo_dm_loai_don_vi_thanh_toan.DataTextField = DM_DON_VI_THANH_TOAN.TEN_DON_VI;
            m_cbo_dm_loai_don_vi_thanh_toan.DataBind();
        }
        catch (Exception v_e)
        {

            throw v_e;
        }

    }
    private void reset_control()
    {
        m_txt_so_hop_dong.Text = "";
        m_txt_gia_tri_hop_dong.Text = "";
        m_cbo_dm_mon_hoc_2.SelectedValue = "0";
        m_cbo_dm_mon_hoc_3.SelectedValue = "0";
        m_cbo_dm_mon_hoc_4.SelectedValue = "0";
        m_cbo_dm_mon_hoc_5.SelectedValue = "0";
        m_cbo_dm_mon_hoc_6.SelectedValue = "0";
        m_txt_thue_suat.Text = "";
        m_txt_ghi_chu1.Text = "";
        m_rbt_hoclieu_yn.Items[1].Selected = true;
        m_rbt_bt_vanhanh_yn.Items[0].Selected = true;
        m_rbt_co_so_hd_yn.Items[0].Selected = true;
    }
    private string get_gv_info(decimal ip_dc_id_gv)
    {
        try
        {
            US_V_DM_GIANG_VIEN v_us_dm_giang_vien = new US_V_DM_GIANG_VIEN(ip_dc_id_gv);
            if (v_us_dm_giang_vien.IsIDNull()) return "";
            return v_us_dm_giang_vien.strHO_VA_TEN_DEM +" "+ v_us_dm_giang_vien.strTEN_GIANG_VIEN+ " ("+v_us_dm_giang_vien.strMA_GIANG_VIEN+")";
        }
        catch (Exception v_e)
        {
            
            throw v_e;
        }
      
    }
    private void load_2_cbo_po_phu_trach()
    {
        try
        {
            US_HT_NGUOI_SU_DUNG v_us_nguoi_su_dung = new US_HT_NGUOI_SU_DUNG();
            DS_HT_NGUOI_SU_DUNG v_ds_nguoi_su_dung = new DS_HT_NGUOI_SU_DUNG();
            // Đổ dữ liệu vào DS 
            v_us_nguoi_su_dung.FillDataset(v_ds_nguoi_su_dung);

            //TReo dữ liệu vào Dropdownlist loại hợp đồng
            // Đây là giá trị thực
            m_cbo_po_phu_trach.DataValueField = HT_NGUOI_SU_DUNG.TEN_TRUY_CAP;
            // dây là giá trị hiển thị
            m_cbo_po_phu_trach.DataTextField = HT_NGUOI_SU_DUNG.TEN;

            m_cbo_po_phu_trach.DataSource = v_ds_nguoi_su_dung.HT_NGUOI_SU_DUNG;
            m_cbo_po_phu_trach.DataBind();
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    // Lưu dữ liệu
    private void save_data()
    {
        try
        {
            if (m_init_mode != DataEntryFormMode.UpdateDataState)
                m_us_dm_hop_dong_khung.Insert();
            else m_us_dm_hop_dong_khung.Update();
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    private void save_data_va_sinh_phu_luc()
    {
        try
        {
            if (m_init_mode != DataEntryFormMode.UpdateDataState)
                m_us_dm_hop_dong_khung.insert_and_gen_phu_luc();
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    private bool check_so_hd()
    {
        try
        {
            if (m_us_dm_hop_dong_khung.check_exist_so_hd(m_txt_so_hop_dong.Text.TrimEnd())) return false;
            return true;
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    private void load_data_2_grid(decimal ip_dc_id_gv)
    {
        try
        {
            m_ds_hop_dong_khung.Clear();
            // Đổ dữ liệu từ US vào DS
            m_us_dm_hop_dong_khung.FillDataset(m_ds_hop_dong_khung," WHERE ID_GIANG_VIEN="+ip_dc_id_gv);

            // Nếu dữ liệu trống
            if (m_ds_hop_dong_khung.V_DM_HOP_DONG_KHUNG.Rows.Count == 0)
            {
                m_lbl_thong_bao.Text = "Chưa có hợp đông khung nào cho giảng viên này";
                m_pnl_table.Visible = true;
                m_cbo_gvien.SelectedValue =CIPConvert.ToStr(m_dc_id_gv);
            }
            else
            {
                m_pnl_table.Visible = false;
            }
            m_grv_dm_danh_sach_hop_dong_khung.DataSource = m_ds_hop_dong_khung.V_DM_HOP_DONG_KHUNG;
            m_grv_dm_danh_sach_hop_dong_khung.DataBind();
        }
        catch (Exception v_e)
        {
            //nhớ using Ip.Common
            CSystemLog_301.ExceptionHandle(this, v_e);

        }
    }

    private void form_2_us_object(US_V_DM_HOP_DONG_KHUNG ip_us_hd_khung)
    {
        try
        {
            System.Globalization.CultureInfo enUS = new System.Globalization.CultureInfo("en-US"); 
            ip_us_hd_khung.strSO_HOP_DONG = m_txt_so_hop_dong.Text;
            ip_us_hd_khung.dcID_GIANG_VIEN = CIPConvert.ToDecimal(m_cbo_gvien.SelectedValue);

            DateTime v_dat_out_result;
            if (DateTime.TryParseExact(CIPConvert.ToStr(m_dat_ngay_ki.SelectedDate), "dd/MM/yyyy", enUS, System.Globalization.DateTimeStyles.None, out v_dat_out_result))
            {
                if (m_dat_ngay_ki.SelectedDate != CIPConvert.ToDatetime("01/01/0001"))
                    ip_us_hd_khung.datNGAY_KY = m_dat_ngay_ki.SelectedDate;
                else ip_us_hd_khung.datNGAY_KY = CIPConvert.ToDatetime("01/01/1900");
            }

            if (DateTime.TryParseExact(CIPConvert.ToStr(m_dat_ngay_hieu_luc.SelectedDate), "dd/MM/yyyy", enUS, System.Globalization.DateTimeStyles.None, out v_dat_out_result))
            {
                if (m_dat_ngay_hieu_luc.SelectedDate != CIPConvert.ToDatetime("01/01/0001"))
                    ip_us_hd_khung.datNGAY_HIEU_LUC = m_dat_ngay_hieu_luc.SelectedDate;
                else ip_us_hd_khung.datNGAY_HIEU_LUC = CIPConvert.ToDatetime("01/01/1900");
            }

            if (DateTime.TryParseExact(CIPConvert.ToStr(m_dat_ngay_ket_thuc.SelectedDate), "dd/MM/yyyy", enUS, System.Globalization.DateTimeStyles.None, out v_dat_out_result))
            {
                if (m_dat_ngay_ket_thuc.SelectedDate != CIPConvert.ToDatetime("01/01/0001"))
                    ip_us_hd_khung.datNGAY_KET_THUC_DU_KIEN = m_dat_ngay_ket_thuc.SelectedDate;
                else ip_us_hd_khung.datNGAY_KET_THUC_DU_KIEN = CIPConvert.ToDatetime("01/01/1900");
            }

            ip_us_hd_khung.dcID_LOAI_HOP_DONG = CIPConvert.ToDecimal(m_cbo_dm_loai_hop_dong.SelectedValue);
            ip_us_hd_khung.dcID_TRANG_THAI_HOP_DONG = CIPConvert.ToDecimal(m_cbo_dm_trang_thai_hop_dong.SelectedValue);
            ip_us_hd_khung.dcID_DON_VI_QUAN_LY = CIPConvert.ToDecimal(m_cbo_dm_loai_don_vi_quan_li.SelectedValue);
            ip_us_hd_khung.dcID_DON_VI_THANH_TOAN = CIPConvert.ToDecimal(m_cbo_dm_loai_don_vi_thanh_toan.SelectedValue);

            ip_us_hd_khung.dcID_MON1 = CIPConvert.ToDecimal(m_cbo_dm_mon_hoc_1.SelectedValue);
            ip_us_hd_khung.dcID_MON2 = CIPConvert.ToDecimal(m_cbo_dm_mon_hoc_2.SelectedValue);
            // if (ip_us_hd_khung.dcID_MON2 == 0) ip_us_hd_khung.SetID_MON2Null();
            ip_us_hd_khung.dcID_MON3 = CIPConvert.ToDecimal(m_cbo_dm_mon_hoc_3.SelectedValue);
            //if (ip_us_hd_khung.dcID_MON3 == 0) ip_us_hd_khung.SetID_MON3Null();
            ip_us_hd_khung.dcID_MON4 = CIPConvert.ToDecimal(m_cbo_dm_mon_hoc_4.SelectedValue);
            //if (ip_us_hd_khung.dcID_MON4 == 0) ip_us_hd_khung.SetID_MON4Null();
            ip_us_hd_khung.dcID_MON5 = CIPConvert.ToDecimal(m_cbo_dm_mon_hoc_5.SelectedValue);
            //if (ip_us_hd_khung.dcID_MON5 == 0) ip_us_hd_khung.SetID_MON5Null();
            ip_us_hd_khung.dcID_MON6 = CIPConvert.ToDecimal(m_cbo_dm_mon_hoc_6.SelectedValue);
            //if (ip_us_hd_khung.dcID_MON6 == 0) ip_us_hd_khung.SetID_MON6Null();
            if (m_txt_thue_suat.Text != "")
                ip_us_hd_khung.dcTHUE_SUAT = CIPConvert.ToDecimal(m_txt_thue_suat.Text);
            if (m_txt_gia_tri_hop_dong.Text != "")
                ip_us_hd_khung.dcGIA_TRI_HOP_DONG = CIPConvert.ToDecimal(m_txt_gia_tri_hop_dong.Text);
            // set giá trị nghiệm thu thực tế bằng null lúc đầu tạo hợp đồng khung
            ip_us_hd_khung.SetGIA_TRI_NGHIEM_THU_THUC_TENull();

            if (m_rbt_hoclieu_yn.Items[0].Selected)
                ip_us_hd_khung.strHOC_LIEU_YN = "Y";
            else ip_us_hd_khung.strHOC_LIEU_YN = "N";

            if (m_rbt_bt_vanhanh_yn.Items[0].Selected)
                ip_us_hd_khung.strVAN_HANH_YN = "Y";
            else ip_us_hd_khung.strVAN_HANH_YN = "N";

            if (m_rbt_co_so_hd_yn.Items[0].Selected)
                ip_us_hd_khung.strCO_SO_HD_YN = "Y";
            else ip_us_hd_khung.strCO_SO_HD_YN = "N";

            ip_us_hd_khung.strGHI_CHU = m_txt_ghi_chu1.Text;
            ip_us_hd_khung.strGHI_CHU2 = m_txt_ghi_chu2.Text;
            ip_us_hd_khung.strGHI_CHU3 = m_txt_ghi_chu3.Text;
            ip_us_hd_khung.strGHI_CHU4 = m_txt_ghi_chu4.Text;
            ip_us_hd_khung.strMA_PO_PHU_TRACH = CIPConvert.ToStr(m_cbo_po_phu_trach.SelectedValue);
        }
        catch (Exception v_e)
        {

            throw v_e;
        }

    }

    private void us_object_2_form(US_V_DM_HOP_DONG_KHUNG ip_us_hd_khung)
    {
        try
        {
            m_txt_so_hop_dong.Text = ip_us_hd_khung.strSO_HOP_DONG;
            m_cbo_gvien.SelectedValue = CIPConvert.ToStr(ip_us_hd_khung.dcID_GIANG_VIEN);
            if (!ip_us_hd_khung.IsNGAY_KYNull())
                m_dat_ngay_ki.SelectedDate = ip_us_hd_khung.datNGAY_KY;
            // else ip_us_hd_khung.datNGAY_KY = CIPConvert.ToDatetime("01/01/1900");
            if (!ip_us_hd_khung.IsNGAY_HIEU_LUCNull())
                m_dat_ngay_hieu_luc.SelectedDate = ip_us_hd_khung.datNGAY_HIEU_LUC;
            //else ip_us_hd_khung.datNGAY_HIEU_LUC = CIPConvert.ToDatetime("01/01/1900");
            if (!ip_us_hd_khung.IsNGAY_KET_THUC_DU_KIENNull())
                m_dat_ngay_ket_thuc.SelectedDate = ip_us_hd_khung.datNGAY_KET_THUC_DU_KIEN;
            // else ip_us_hd_khung.datNGAY_KET_THUC_DU_KIEN = CIPConvert.ToDatetime("01/01/1900");

            m_cbo_dm_loai_hop_dong.SelectedValue = CIPConvert.ToStr(ip_us_hd_khung.dcID_LOAI_HOP_DONG);
            m_cbo_dm_trang_thai_hop_dong.SelectedValue = CIPConvert.ToStr(ip_us_hd_khung.dcID_TRANG_THAI_HOP_DONG);
            m_cbo_dm_loai_don_vi_quan_li.SelectedValue = CIPConvert.ToStr(ip_us_hd_khung.dcID_DON_VI_QUAN_LY);
            m_cbo_dm_loai_don_vi_thanh_toan.SelectedValue = CIPConvert.ToStr(ip_us_hd_khung.dcID_DON_VI_THANH_TOAN);

            m_cbo_dm_mon_hoc_1.SelectedValue = CIPConvert.ToStr(ip_us_hd_khung.dcID_MON1);
            m_cbo_dm_mon_hoc_2.SelectedValue = CIPConvert.ToStr(ip_us_hd_khung.dcID_MON2);
            if (ip_us_hd_khung.dcID_MON2 == null) ip_us_hd_khung.dcID_MON2 = 0;
            m_cbo_dm_mon_hoc_2.SelectedValue = CIPConvert.ToStr(ip_us_hd_khung.dcID_MON2);
            if (ip_us_hd_khung.dcID_MON3 == null) ip_us_hd_khung.dcID_MON3 = 0;
            m_cbo_dm_mon_hoc_3.SelectedValue = CIPConvert.ToStr(ip_us_hd_khung.dcID_MON3);
            if (ip_us_hd_khung.dcID_MON4 == null) ip_us_hd_khung.dcID_MON4 = 0;
            m_cbo_dm_mon_hoc_4.SelectedValue = CIPConvert.ToStr(ip_us_hd_khung.dcID_MON4);
            if (ip_us_hd_khung.dcID_MON5 == null) ip_us_hd_khung.dcID_MON5 = 0;
            m_cbo_dm_mon_hoc_5.SelectedValue = CIPConvert.ToStr(ip_us_hd_khung.dcID_MON5);
            if (ip_us_hd_khung.dcID_MON6 == null) ip_us_hd_khung.dcID_MON6 = 0;
            m_cbo_dm_mon_hoc_6.SelectedValue = CIPConvert.ToStr(ip_us_hd_khung.dcID_MON6);

            m_txt_thue_suat.Text = CIPConvert.ToStr(ip_us_hd_khung.dcTHUE_SUAT);
            m_txt_gia_tri_hop_dong.Text = CIPConvert.ToStr(ip_us_hd_khung.dcGIA_TRI_HOP_DONG,"#,###");

            if (ip_us_hd_khung.strHOC_LIEU_YN == "Y")
            {
                m_rbt_hoclieu_yn.Items[0].Selected = true;
                m_rbt_hoclieu_yn.Items[1].Selected = false;
            }
            else m_rbt_hoclieu_yn.Items[1].Selected = true;

            if (ip_us_hd_khung.strVAN_HANH_YN == "Y")
                m_rbt_bt_vanhanh_yn.Items[0].Selected = true;
            else m_rbt_bt_vanhanh_yn.Items[1].Selected = true;

            if (ip_us_hd_khung.strCO_SO_HD_YN == "Y")
                m_rbt_co_so_hd_yn.Items[0].Selected = true;
            else m_rbt_co_so_hd_yn.Items[1].Selected = true;
            m_txt_ghi_chu1.Text = ip_us_hd_khung.strGHI_CHU;
            m_txt_ghi_chu2.Text = ip_us_hd_khung.strGHI_CHU2;
            m_txt_ghi_chu3.Text = ip_us_hd_khung.strGHI_CHU3;
            m_txt_ghi_chu4.Text = ip_us_hd_khung.strGHI_CHU4;
            m_cbo_po_phu_trach.SelectedValue = ip_us_hd_khung.strMA_PO_PHU_TRACH;
           
        }
        catch (Exception v_e)
        {

            throw v_e;
        }

    }
    private void delete_dm_hd_khung(int ip_i_row_del)
    {
        try
        {
            decimal v_dc_id_id_hd_khung = CIPConvert.ToDecimal(m_grv_dm_danh_sach_hop_dong_khung.DataKeys[ip_i_row_del].Value);
            m_us_dm_hop_dong_khung.dcID = v_dc_id_id_hd_khung;
            m_us_dm_hop_dong_khung.DeleteByID(v_dc_id_id_hd_khung);
            m_lbl_thong_bao.Text = "Xóa bản ghi thành công";
            load_data_2_grid(m_dc_id_gv);
        }
        catch (Exception v_e)
        {

            throw v_e;
        }

    }
    #endregion

    #region Public Interfaces
    public string get_ma_gv_form_id(decimal ip_dc_id)
    {
        try
        {
            US_V_DM_GIANG_VIEN v_us_dm_giang_vien = new US_V_DM_GIANG_VIEN(ip_dc_id);
            return v_us_dm_giang_vien.strMA_GIANG_VIEN;
        }
        catch (Exception v_e)
        {

            throw v_e;
        }

    }
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
    #endregion

    //
    // Events
    //

    protected void cmd_them_moi_Click(object sender, EventArgs e)
    {
        try
        {
            m_pnl_table.Visible = true;
            // Nếu nút tạo mới đc click khi đang hoặc vừa mới Edit thông tin hợp đồng giảng viên của người đó
            if (Request.QueryString["mode"] != null && Request.QueryString["mode"].ToString() == "edit")
            {
                m_cbo_gvien.SelectedValue =CIPConvert.ToStr(m_dc_id_gv);
                reset_control();
            }
            else 
              m_cbo_gvien.SelectedValue = CIPConvert.ToStr(Request.QueryString["id_gv"]);
            m_cbo_gvien.Enabled = false;
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
            // Nếu đang cập nhật thông tin giảng viên thì ta phải cung cấp thêm Id giảng viên
            if (m_init_mode == DataEntryFormMode.InsertDataState)
            {
                if (!check_so_hd())
                {
                    string someScript;
                    someScript = "<script language='javascript'>alert('Số hợp đồng này đã tồn tại');</script>";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "onload", someScript);
                    // m_lbl_mess.Text = "Số hợp đồng này đã tồn tại";
                    m_txt_so_hop_dong.Focus();
                   // m_lbl_thong_bao.Text = "Số hợp đồng này đã tồn tại";
                    return;
                }
            }
            form_2_us_object(m_us_dm_hop_dong_khung);
            // truyền ID hợp đồng cho us
            if (m_init_mode == DataEntryFormMode.UpdateDataState)
                m_us_dm_hop_dong_khung.dcID = m_dc_id_hd;
            // Lưu dữ liệu
            save_data();
            reset_control();
            m_pnl_table.Visible =false;
            // Chuyển vể danh sách giảng viên
            if (m_init_mode == DataEntryFormMode.UpdateDataState)
                m_lbl_thong_bao.Text = "Cập nhật thông tin thành công";
            else m_lbl_thong_bao.Text = "Thêm thông tin thành công";
            load_data_2_grid(m_dc_id_gv);
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }

    protected void m_cmd_luu_va_sinh_pl_Click(object sender, EventArgs e)
    {
        try
        {
             // Nếu đang cập nhật thông tin giảng viên thì ta phải cung cấp thêm Id giảng viên
            if (m_init_mode == DataEntryFormMode.InsertDataState)
            {
                if (!check_so_hd())
                {
                    string someScript;
                    someScript = "<script language='javascript'>alert('Số hợp đồng này đã tồn tại');</script>";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "onload", someScript);
                    // m_lbl_mess.Text = "Số hợp đồng này đã tồn tại";
                    m_txt_so_hop_dong.Focus();
                   // m_lbl_thong_bao.Text = "Số hợp đồng này đã tồn tại";
                    return;
                }
            }
            form_2_us_object(m_us_dm_hop_dong_khung);
            // truyền ID hợp đồng cho us
            if (m_init_mode == DataEntryFormMode.UpdateDataState)
                m_us_dm_hop_dong_khung.dcID = m_dc_id_hd;
            // Lưu dữ liệu
            save_data_va_sinh_phu_luc();
            reset_control();
            m_pnl_table.Visible =false;
            // Chuyển vể danh sách giảng viên
            if (m_init_mode == DataEntryFormMode.UpdateDataState)
                m_lbl_thong_bao.Text = "Cập nhật thông tin thành công";
            else m_lbl_thong_bao.Text = "Thêm thông tin thành công";
            load_data_2_grid(m_dc_id_gv);
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this,v_e);
        }
    }
    protected void m_cmd_thoat_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("/TRMProject/ChucNang/F202_DanhSachGiangVien.aspx", false);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        catch (Exception v_e)
        {

            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_grv_dm_danh_sach_hop_dong_khung_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            m_grv_dm_danh_sach_hop_dong_khung.PageIndex = e.NewPageIndex;
            load_data_2_grid(m_dc_id_gv);
        }
        catch (Exception v_e)
        {

            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_grv_dm_danh_sach_hop_dong_khung_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            delete_dm_hd_khung(e.RowIndex);
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
}