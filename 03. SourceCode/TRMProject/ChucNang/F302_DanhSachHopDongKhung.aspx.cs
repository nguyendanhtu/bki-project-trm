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

public partial class ChucNang_F302_DanhSachHopDongKhung : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            try
            {
                m_lbl_thong_bao.Text = "";
                m_txt_ten_giang_vien.Focus();
                if (!IsPostBack)
                {                    
                    load_2_cbo_don_vi_quan_ly();
                    load_data_2_loai_hop_dong();
                    load_data_2_trang_thai_hop_dong();
                    load_data_2_nam_bd_hop_tac();
                    if (Session["Snamekhung"] != null)
                    {
                        session_2_form();
                        search_using_session();
                    }
                    if (Request.QueryString["edit"] != null)
                    {
                        if (Request.QueryString["edit"].ToString().Equals("ok"))
                            m_lbl_thong_bao.Text = "Cập nhật dữ liệu thành công";
                        else m_lbl_thong_bao.Text = "Thêm dữ liệu thành công";
                    }
                }
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(this, v_e);
            }
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    #region Members
    US_V_DM_HOP_DONG_KHUNG m_us_dm_hop_dong_khung = new US_V_DM_HOP_DONG_KHUNG();
    DS_V_DM_HOP_DONG_KHUNG m_ds_hop_dong_khung = new DS_V_DM_HOP_DONG_KHUNG();

    US_CM_DM_TU_DIEN m_us_cm_dm_tu_dien = new US_CM_DM_TU_DIEN();
    DS_CM_DM_TU_DIEN m_ds_cm_dm_tu_dien = new DS_CM_DM_TU_DIEN();

    US_V_DM_GIANG_VIEN m_us_dm_giang_vien = new US_V_DM_GIANG_VIEN();
    DS_V_DM_GIANG_VIEN m_ds_dm_giang_vien = new DS_V_DM_GIANG_VIEN();

    DataEntryFormMode m_init_mode = DataEntryFormMode.ViewDataState;
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
    #endregion

    #region Private Methods
    private void load_2_cbo_don_vi_quan_ly()
    {
        try
        {
            DS_CM_DM_TU_DIEN v_ds_cm_tu_dien = new DS_CM_DM_TU_DIEN();
            US_CM_DM_TU_DIEN v_us_cm_tu_dien = new US_CM_DM_TU_DIEN();
            //v_ds_cm_tu_dien.Clear();
            //DataRow v_dr_all_dv_quan_ly = m_ds_cm_dm_tu_dien.CM_DM_TU_DIEN.NewCM_DM_TU_DIENRow();
          
            ////add item Tat Ca          
            //v_dr_all_dv_quan_ly[CM_DM_TU_DIEN.ID] = 0;
            //v_dr_all_dv_quan_ly[CM_DM_TU_DIEN.TEN] = "Tất cả";

            //v_ds_cm_tu_dien.EnforceConstraints = false;
            //v_ds_cm_tu_dien.CM_DM_TU_DIEN.Rows.InsertAt(v_dr_all_dv_quan_ly, 0);

            // Đổ dữ liệu vào DS 
            v_us_cm_tu_dien.FillDataset(v_ds_cm_tu_dien, " WHERE ID_LOAI_TU_DIEN = "
                                                + (int)e_loai_tu_dien.DON_VI_QUAN_LY_CHINH); // Đây là lấy theo điều kiện
            m_cbo_don_vi_quan_ly_search.Items.Add(new ListItem("Tất cả", "0"));
            for (int i = 0; i < v_ds_cm_tu_dien.CM_DM_TU_DIEN.Rows.Count; i++)
            {
                m_cbo_don_vi_quan_ly_search.Items.Add(new ListItem(v_ds_cm_tu_dien.CM_DM_TU_DIEN[i][CM_DM_TU_DIEN.TEN].ToString(), v_ds_cm_tu_dien.CM_DM_TU_DIEN[i][CM_DM_TU_DIEN.ID].ToString()));
            }
          
            //for (int i = 0; i < v_ds_cm_tu_dien.CM_DM_TU_DIEN.Rows.Count; i++)
            //{
            //    m_cbo_don_vi_q_ly.Items.Add(new ListItem(v_ds_cm_tu_dien.CM_DM_TU_DIEN[i][CM_DM_TU_DIEN.TEN].ToString(), v_ds_cm_tu_dien.CM_DM_TU_DIEN[i][CM_DM_TU_DIEN.ID].ToString()));
            //}
        }
        catch (Exception v_e)
        {
            throw v_e;
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
    private void load_data_2_loai_hop_dong()
    {
        try
        {
             DS_CM_DM_TU_DIEN v_ds_cm_tu_dien = new DS_CM_DM_TU_DIEN();
            US_CM_DM_TU_DIEN v_us_cm_tu_dien = new US_CM_DM_TU_DIEN();
            //v_ds_cm_tu_dien.Clear();
            //DataRow v_dr_all_loai_hdong = m_ds_cm_dm_tu_dien.CM_DM_TU_DIEN.NewCM_DM_TU_DIENRow();
          
            ////add item Tat Ca          
            //v_dr_all_loai_hdong[CM_DM_TU_DIEN.ID] = 0;
            //v_dr_all_loai_hdong[CM_DM_TU_DIEN.TEN] = "Tất cả";

            //v_ds_cm_tu_dien.EnforceConstraints = false;
            //v_ds_cm_tu_dien.CM_DM_TU_DIEN.Rows.InsertAt(v_dr_all_loai_hdong, 0);

            // Đổ dữ liệu vào DS 
            v_us_cm_tu_dien.FillDataset(v_ds_cm_tu_dien, " WHERE ID_LOAI_TU_DIEN = "
                                                + (int)e_loai_tu_dien.LOAI_HOP_DONG); // Đây là lấy theo điều kiện
            m_cbo_loai_hop_dong_search.Items.Add(new ListItem("Tất cả", "0"));
            for (int i = 0; i < v_ds_cm_tu_dien.CM_DM_TU_DIEN.Rows.Count; i++)
            {
                m_cbo_loai_hop_dong_search.Items.Add(new ListItem(v_ds_cm_tu_dien.CM_DM_TU_DIEN[i][CM_DM_TU_DIEN.TEN].ToString(), v_ds_cm_tu_dien.CM_DM_TU_DIEN[i][CM_DM_TU_DIEN.ID].ToString()));
            }

            //m_cbo_loai_hop_dong_search.DataValueField = CM_DM_TU_DIEN.ID;
            //m_cbo_loai_hop_dong_search.DataTextField = CM_DM_TU_DIEN.TEN;

            //m_cbo_loai_hop_dong_search.DataSource = v_ds_cm_tu_dien.CM_DM_TU_DIEN;
            //m_cbo_loai_hop_dong_search.DataBind();
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
            get_form_search_data_and_load_to_grid();
        }
        catch (Exception v_e)
        {

            throw v_e;
        }

    }
    private void load_data_2_trang_thai_hop_dong()
    {
        try
        {
            DS_CM_DM_TU_DIEN v_ds_cm_tu_dien = new DS_CM_DM_TU_DIEN();
            US_CM_DM_TU_DIEN v_us_cm_tu_dien = new US_CM_DM_TU_DIEN();
            //v_ds_cm_tu_dien.Clear();
            //DataRow v_dr_all_trang_thai_hdong = m_ds_cm_dm_tu_dien.CM_DM_TU_DIEN.NewCM_DM_TU_DIENRow();

            ////add item Tat Ca          
            //v_dr_all_trang_thai_hdong[CM_DM_TU_DIEN.ID] = 0;
            //v_dr_all_trang_thai_hdong[CM_DM_TU_DIEN.TEN] = "Tất cả";

            //v_ds_cm_tu_dien.EnforceConstraints = false;
            //v_ds_cm_tu_dien.CM_DM_TU_DIEN.Rows.InsertAt(v_dr_all_trang_thai_hdong, 0);

            // Đổ dữ liệu vào DS 
            v_us_cm_tu_dien.FillDataset(v_ds_cm_tu_dien, " WHERE ID_LOAI_TU_DIEN = "
                                                + (int)e_loai_tu_dien.TRANG_THAI_HOP_DONG_KHUNG); // Đây là lấy theo điều kiện
            m_cbo_trang_thai_hop_dong_search.Items.Add(new ListItem("Tất cả", "0"));
            for (int i = 0; i < v_ds_cm_tu_dien.CM_DM_TU_DIEN.Rows.Count; i++)
            {
                m_cbo_trang_thai_hop_dong_search.Items.Add(new ListItem(v_ds_cm_tu_dien.CM_DM_TU_DIEN[i][CM_DM_TU_DIEN.TEN].ToString(), v_ds_cm_tu_dien.CM_DM_TU_DIEN[i][CM_DM_TU_DIEN.ID].ToString()));
            }
            //m_cbo_trang_thai_hop_dong_search.DataValueField = CM_DM_TU_DIEN.ID;
            //m_cbo_trang_thai_hop_dong_search.DataTextField = CM_DM_TU_DIEN.TEN;

            //m_cbo_trang_thai_hop_dong_search.DataSource = v_ds_cm_tu_dien.CM_DM_TU_DIEN;
            //m_cbo_trang_thai_hop_dong_search.DataBind();
        }
        catch (Exception v_e)
        {

            throw v_e;
        }
    }

    private void session_2_form()
    {
        m_txt_ten_giang_vien.Text = CIPConvert.ToStr(Session["Snamekhung"]);
        m_txt_so_hd.Text = CIPConvert.ToStr(Session["Ssohdkhung"]);
        m_txt_tu_khoa_tim_kiem.Text = CIPConvert.ToStr(Session["Skeykhung"]);
        m_txt_ma_PO_quan_ly.Text = CIPConvert.ToStr(Session["Spokhung"]);

        m_cbo_loai_hop_dong_search.SelectedValue = CIPConvert.ToStr(CIPConvert.ToDecimal(Session["Sloaihdkhung"]));
        m_cbo_don_vi_quan_ly_search.SelectedValue = CIPConvert.ToStr(CIPConvert.ToDecimal(Session["Squanlykhung"]));
        m_cbo_thang_ky.SelectedValue = CIPConvert.ToStr(Session["Sthangkykhung"]);
        m_cbo_nam_ky.SelectedValue = CIPConvert.ToStr(Session["Snamkykhung"]);
        if (CIPConvert.ToStr(Session["Sthangkykhung"]) != "")
            m_cbo_thang_ky.SelectedValue = CIPConvert.ToStr(Session["Sthangkykhung"]);
        if (CIPConvert.ToStr(Session["Sdathieuluckhung"]) != "" && CIPConvert.ToDatetime(CIPConvert.ToStr(Session["Sdathieuluckhung"]), "dd/MM/yyyy") != CIPConvert.ToDatetime("01/01/1900", "dd/MM/yyyy"))
            m_dat_ngay_hieu_luc.SelectedDate = CIPConvert.ToDatetime(CIPConvert.ToStr(Session["Sdathieuluckhung"]), "dd/MM/yyyy");
        if (CIPConvert.ToStr(Session["Sdatketthuc"]) != "" && CIPConvert.ToDatetime(CIPConvert.ToStr(Session["Sdatketthuc"]), "dd/MM/yyyy") != CIPConvert.ToDatetime("01/01/1900", "dd/MM/yyyy"))
            m_dat_date_ket_thuc.SelectedDate = CIPConvert.ToDatetime(CIPConvert.ToStr(Session["Sdatketthuc"]), "dd/MM/yyyy");
        m_cbo_trang_thai_hop_dong_search.SelectedValue = CIPConvert.ToStr(CIPConvert.ToDecimal(Session["Strangthaihdkhung"]));
    }

    private void collect_data_2_search(string ip_str_name, string ip_str_keyword
                                  , string ip_str_so_hd
                                  , decimal ip_dc_id_loai_hd
                                  , decimal ip_dc_id_trang_thai_hd
                                  , decimal ip_dc_don_vi_quan_ly
                                  , decimal ip_dc_thang_ky
                                  , decimal ip_dc_nam_ky
                                  , DateTime ip_dat_ngay_hieu_luc
                                  , DateTime ip_dat_ngay_ket_thuc
                                  , string ip_str_ma_po_quan_ly)
    {
        Session["Snamekhung"] = ip_str_name;
        Session["Skeykhung"] = ip_str_keyword;
        Session["Ssohdkhung"] = ip_str_so_hd;
        Session["Sloaihdkhung"] = ip_dc_id_loai_hd;
        Session["Squanlykhung"] = ip_dc_don_vi_quan_ly;
        Session["Strangthaihdkhung"] = ip_dc_id_trang_thai_hd;
        Session["Sthangkykhung"] = ip_dc_thang_ky;
        Session["Snamkykhung"] = ip_dc_nam_ky;
        Session["Sdathieuluckhung"] = ip_dat_ngay_hieu_luc;
        Session["Spokhung"] = ip_str_ma_po_quan_ly;
        Session["Sdatketthuc"] = ip_dat_ngay_ket_thuc;
    }
    private void clear_session() {
        Session["Snamekhung"] = "";
        Session["Skeykhung"] = "";
        Session["Ssohdkhung"] = "";
        Session["Sloaihdkhung"] = "";
        Session["Squanlykhung"] = "";
        Session["Strangthaihdkhung"] = "";
        Session["Sthangkykhung"] = "";
        Session["Snamkykhung"] = "";
        Session["Sdathieuluckhung"] = "";
        Session["Spokhung"] = "";
        Session["Sdatketthuc"] = "";
    }
    private void load_data_2_nam_bd_hop_tac()
    {
        m_cbo_nam_ky.Items.Add(new ListItem("Tất cả", CIPConvert.ToStr(0)));
        for (int v_i = 2000; v_i < 2051; v_i++)
        {
            m_cbo_nam_ky.Items.Add(new ListItem(v_i.ToString(), v_i.ToString()));
        }
    }
    private void get_form_search_data_and_load_to_grid()
    {

        try
        {
            System.Globalization.CultureInfo enUS = new System.Globalization.CultureInfo("en-US"); 
            // thu thập dữ liệu

            string v_str_ten_giang_vien = m_txt_ten_giang_vien.Text.Trim();
            v_str_ten_giang_vien = Process_name_search(v_str_ten_giang_vien);

            string v_str_search_key_word = m_txt_tu_khoa_tim_kiem.Text.Trim();
            v_str_search_key_word = Process_name_search(v_str_search_key_word);

            decimal v_dc_id_loai_hop_dong = CIPConvert.ToDecimal(m_cbo_loai_hop_dong_search.SelectedValue);

            decimal v_dc_trang_thai_hop_dong = CIPConvert.ToDecimal(m_cbo_trang_thai_hop_dong_search.SelectedValue);

            decimal v_dc_don_vi_quan_li = CIPConvert.ToDecimal(m_cbo_don_vi_quan_ly_search.SelectedValue);
            string v_str_ma_po_quan_ly = m_txt_ma_PO_quan_ly.Text.Trim();
            string v_str_so_hop_dong = m_txt_so_hd.Text.Trim();

            Decimal v_dc_thang_ki, v_dc_nam_ky;
            // Nếu ngày ký đúng định dạng
            v_dc_nam_ky = CIPConvert.ToDecimal(m_cbo_nam_ky.SelectedValue);
            v_dc_thang_ki = CIPConvert.ToDecimal(m_cbo_thang_ky.SelectedValue);   
            DateTime v_dat_ngay_hieu_luc;
            if (DateTime.TryParseExact(CIPConvert.ToStr(m_dat_ngay_hieu_luc.SelectedDate), "dd/MM/yyyy", enUS, System.Globalization.DateTimeStyles.None, out v_dat_ngay_hieu_luc))
            {
                if (m_dat_ngay_hieu_luc.SelectedDate != CIPConvert.ToDatetime("01/01/0001"))
                    v_dat_ngay_hieu_luc = m_dat_ngay_hieu_luc.SelectedDate;
                else v_dat_ngay_hieu_luc = CIPConvert.ToDatetime("01/01/1900");
            }
            

            DateTime v_dat_ngay_ket_thuc;
            if (DateTime.TryParseExact(CIPConvert.ToStr(m_dat_date_ket_thuc.SelectedDate), "dd/MM/yyyy", enUS, System.Globalization.DateTimeStyles.None, out v_dat_ngay_ket_thuc))
            {
                if (m_dat_date_ket_thuc.SelectedDate != CIPConvert.ToDatetime("01/01/0001"))
                    v_dat_ngay_ket_thuc = m_dat_date_ket_thuc.SelectedDate;
                else v_dat_ngay_ket_thuc = CIPConvert.ToDatetime("01/01/1900");
            }
           

            collect_data_2_search(v_str_ten_giang_vien
                                                        , v_str_search_key_word
                                                        , v_str_so_hop_dong
                                                        , v_dc_id_loai_hop_dong
                                                        , v_dc_trang_thai_hop_dong
                                                        , v_dc_don_vi_quan_li
                                                        , v_dc_thang_ki
                                                        , v_dc_nam_ky
                                                        , v_dat_ngay_hieu_luc
                                                        , v_dat_ngay_ket_thuc
                                                        , v_str_ma_po_quan_ly);

            // Search

            m_us_dm_hop_dong_khung.search_hop_dong_khung( v_str_ten_giang_vien
                                                        , v_str_search_key_word
                                                        , v_str_so_hop_dong
                                                        , v_dc_id_loai_hop_dong                                                        
                                                        , v_dc_trang_thai_hop_dong
                                                        , v_dc_don_vi_quan_li
                                                        , v_dc_thang_ki
                                                        , v_dc_nam_ky
                                                        , v_dat_ngay_hieu_luc
                                                        , v_dat_ngay_ket_thuc
                                                        , v_str_ma_po_quan_ly
                                                        , m_ds_hop_dong_khung
                                                        , CIPConvert.ToStr(Session["Username"]));
            m_lbl_loc_du_lieu.Text = "Kết quả lọc dữ liệu: " + m_ds_hop_dong_khung.V_DM_HOP_DONG_KHUNG.Rows.Count + " bản ghi";
            if (m_ds_hop_dong_khung.V_DM_HOP_DONG_KHUNG.Rows.Count == 0)
            {
                m_lbl_thong_bao.Text = "Không có bản ghi nào phù hợp";
                if (m_grv_dm_danh_sach_hop_dong_khung.Visible == true) m_grv_dm_danh_sach_hop_dong_khung.Visible = false;
                return;
            }
            m_grv_dm_danh_sach_hop_dong_khung.Visible = true;
            m_grv_dm_danh_sach_hop_dong_khung.DataSource = m_ds_hop_dong_khung.V_DM_HOP_DONG_KHUNG;

            m_grv_dm_danh_sach_hop_dong_khung.DataBind();
        }

        catch (Exception v_e)
        {
            throw v_e;

        }

    }
    private void get_data_2_export_excel()
    {
        System.Globalization.CultureInfo enUS = new System.Globalization.CultureInfo("en-US");
        // thu thập dữ liệu

        string v_str_ten_giang_vien = m_txt_ten_giang_vien.Text.Trim();
        v_str_ten_giang_vien = Process_name_search(v_str_ten_giang_vien);

        string v_str_search_key_word = m_txt_tu_khoa_tim_kiem.Text.Trim();
        v_str_search_key_word = Process_name_search(v_str_search_key_word);

        decimal v_dc_id_loai_hop_dong = CIPConvert.ToDecimal(m_cbo_loai_hop_dong_search.SelectedValue);

        decimal v_dc_trang_thai_hop_dong = CIPConvert.ToDecimal(m_cbo_trang_thai_hop_dong_search.SelectedValue);

        decimal v_dc_don_vi_quan_li = CIPConvert.ToDecimal(m_cbo_don_vi_quan_ly_search.SelectedValue);
        string v_str_ma_po_quan_ly = m_txt_ma_PO_quan_ly.Text.Trim();
        string v_str_so_hop_dong = m_txt_so_hd.Text.Trim();

        Decimal v_dc_thang_ki, v_dc_nam_ky;
        // Nếu ngày ký đúng định dạng
        v_dc_nam_ky = CIPConvert.ToDecimal(m_cbo_nam_ky.SelectedValue);
        v_dc_thang_ki = CIPConvert.ToDecimal(m_cbo_thang_ky.SelectedValue);
        DateTime v_dat_ngay_hieu_luc;
        if (DateTime.TryParseExact(CIPConvert.ToStr(m_dat_ngay_hieu_luc.SelectedDate), "dd/MM/yyyy", enUS, System.Globalization.DateTimeStyles.None, out v_dat_ngay_hieu_luc))
        {
            if (m_dat_ngay_hieu_luc.SelectedDate != CIPConvert.ToDatetime("01/01/0001"))
                v_dat_ngay_hieu_luc = m_dat_ngay_hieu_luc.SelectedDate;
            else v_dat_ngay_hieu_luc = CIPConvert.ToDatetime("01/01/1900");
        }


        DateTime v_dat_ngay_ket_thuc;
        if (DateTime.TryParseExact(CIPConvert.ToStr(m_dat_date_ket_thuc.SelectedDate), "dd/MM/yyyy", enUS, System.Globalization.DateTimeStyles.None, out v_dat_ngay_ket_thuc))
        {
            if (m_dat_date_ket_thuc.SelectedDate != CIPConvert.ToDatetime("01/01/0001"))
                v_dat_ngay_ket_thuc = m_dat_date_ket_thuc.SelectedDate;
            else v_dat_ngay_ket_thuc = CIPConvert.ToDatetime("01/01/1900");
        }

        // Search

        m_us_dm_hop_dong_khung.search_hop_dong_khung(v_str_ten_giang_vien
                                                    , v_str_search_key_word
                                                    , v_str_so_hop_dong
                                                    , v_dc_id_loai_hop_dong
                                                    , v_dc_trang_thai_hop_dong
                                                    , v_dc_don_vi_quan_li
                                                    , v_dc_thang_ki
                                                    , v_dc_nam_ky
                                                    , v_dat_ngay_hieu_luc
                                                    , v_dat_ngay_ket_thuc
                                                    , v_str_ma_po_quan_ly
                                                    , m_ds_hop_dong_khung
                                                    , CIPConvert.ToStr(Session["Username"]));
    }
    /// <summary>
    /// Search sử dụng session
    /// </summary>
    private void search_using_session()
    {
        try
        {
            m_ds_hop_dong_khung.Clear();
            m_us_dm_hop_dong_khung.search_hop_dong_khung(CIPConvert.ToStr(Session["Snamekhung"])
                                               , CIPConvert.ToStr(Session["Skeykhung"])
                                               , CIPConvert.ToStr(Session["Ssohdkhung"])
                                               , CIPConvert.ToDecimal(Session["Sloaihdkhung"])
                                               , CIPConvert.ToDecimal(Session["Strangthaihdkhung"])
                                               , CIPConvert.ToDecimal(Session["Squanlykhung"])
                                               , CIPConvert.ToDecimal(Session["Sthangkykhung"])
                                               , CIPConvert.ToDecimal(Session["Snamkykhung"])
                                               , CIPConvert.ToDatetime(CIPConvert.ToStr(Session["Sdathieuluckhung"]))
                                               , CIPConvert.ToDatetime(CIPConvert.ToStr(Session["Sdatketthuc"]))
                                               , CIPConvert.ToStr(Session["Spokhung"])
                                               , m_ds_hop_dong_khung
                                               , CIPConvert.ToStr(Session["Username"]));
            m_lbl_loc_du_lieu.Text = "Kết quả lọc dữ liệu: " + m_ds_hop_dong_khung.V_DM_HOP_DONG_KHUNG.Rows.Count + " bản ghi";
            if (m_ds_hop_dong_khung.V_DM_HOP_DONG_KHUNG.Rows.Count == 0)
            {
                m_lbl_thong_bao.Text = "Không có bản ghi nào phù hợp";
                if (m_grv_dm_danh_sach_hop_dong_khung.Visible == true) m_grv_dm_danh_sach_hop_dong_khung.Visible = false;
                return;
            }
            m_grv_dm_danh_sach_hop_dong_khung.Visible = true;
            m_grv_dm_danh_sach_hop_dong_khung.DataSource = m_ds_hop_dong_khung.V_DM_HOP_DONG_KHUNG;
            m_grv_dm_danh_sach_hop_dong_khung.DataBind();
        }
        catch (Exception ve)
        {

            throw ve;
        }
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
    //
    // Region for Export Excel
    //
    private void loadGridExprort(ref string strTable)
    {
        // Mỗi cột dữ liệu ứng với từng dòng là label
        foreach (GridViewRow grv in this.m_grv_dm_danh_sach_hop_dong_khung.Rows)
        {
            strTable += "\n<tr>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + ((Label)grv.FindControl("m_lbl_stt")).Text.Trim() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + ((Label)grv.FindControl("m_lbl_so_hop_dong")).Text + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + ((Label)grv.FindControl("m_lbl_ngay_ky")).Text.Trim() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + ((Label)grv.FindControl("m_lbl_ma_gv")).Text.Trim() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + ((Label)grv.FindControl("m_lbl_ten_gv")).Text.Trim() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + ((Label)grv.FindControl("m_lbl_loai_hop_dong")).Text.Trim() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + ((Label)grv.FindControl("m_lbl_don_vi_quan_ly")).Text + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + ((Label)grv.FindControl("m_lbl_don_vi_thanh_toan")).Text.Trim() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + ((Label)grv.FindControl("m_lbl_mon_1")).Text.Trim() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + ((Label)grv.FindControl("m_lbl_mon_2")).Text.Trim() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + ((Label)grv.FindControl("m_lbl_mon_3")).Text.Trim() + "</td>";

            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + ((Label)grv.FindControl("m_lbl_mon_4")).Text.Trim() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + ((Label)grv.FindControl("m_lbl_mon_5")).Text.Trim() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + ((Label)grv.FindControl("m_lbl_mon_6")).Text.Trim() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + ((Label)grv.FindControl("m_lbl_ngay_hieu_luc")).Text.Trim() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + ((Label)grv.FindControl("m_lbl_ngay_ket_thuc")).Text.Trim() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + ((Label)grv.FindControl("m_lbl_trang_thai_hd")).Text.Trim() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + ((Label)grv.FindControl("m_lbl_ma_po_phu_trach")).Text.Trim() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + ((Label)grv.FindControl("m_lbl_gia_tri_hd")).Text.Trim() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + ((Label)grv.FindControl("m_lbl_thue_suat")).Text.Trim() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + ((Label)grv.FindControl("m_lbl_lam_hoc_lieu")).Text.Trim() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + ((Label)grv.FindControl("m_lbl_van_hanh")).Text.Trim() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + ((Label)grv.FindControl("m_lbl_co_so_hop_dong")).Text.Trim() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + ((Label)grv.FindControl("m_lbl_ghi_chu")).Text.Trim() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + ((Label)grv.FindControl("m_lbl_ghi_chu2")).Text.Trim() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + ((Label)grv.FindControl("m_lbl_ghi_chu3")).Text.Trim() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + ((Label)grv.FindControl("m_lbl_ghi_chu4")).Text.Trim() + "</td>";
            strTable += "\n</tr>";
        }
    }

    private void loadTieuDe(ref string strTable)
    {
        strTable += "<table cellpadding='2' cellspacing='0' class='cssTableReport'>";
        strTable += "\n<tr>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width: 100%;  height: 40px; font-size: large; color:White; background-color:#810C15;' nowrap='wrap'>TRM302 - BÁO CÁO DANH SÁCH DANH SÁCH HỢP ĐỒNG KHUNG " + "</td>";
        strTable += "\n</tr>";
        //
        strTable += "\n<tr>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>Số hợp đồng: " + m_txt_so_hd.Text.Trim() + "</td>";
        strTable += "\n</tr>";
        //
        strTable += "\n<tr>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>Tên giảng viên: "  + m_txt_ten_giang_vien.Text.Trim()+"</td>";
        strTable += "\n</tr>";

        //
        strTable += "\n<tr>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>Mã PO quản lý: " + m_txt_ma_PO_quan_ly.Text.Trim() + "</td>";
        strTable += "\n</tr>";
        //
        strTable += "\n<tr>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>Loại hợp đồng: " + m_cbo_loai_hop_dong_search.SelectedItem.Text + "</td>";
        strTable += "\n</tr>";
        //
        strTable += "\n<tr>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>Đơn vị quản lý hợp đồng: " + m_cbo_don_vi_quan_ly_search.SelectedItem.Text + "</td>";
        strTable += "\n</tr>";        
        //
        strTable += "\n<tr>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>Trạng thái hợp đồng: " + m_cbo_trang_thai_hop_dong_search.SelectedItem.Text + "</td>";
        strTable += "\n</tr>";
        //
        strTable += "\n<tr>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>Tháng ký hợp đồng: " + m_cbo_thang_ky.SelectedItem.Text + " </td>";
        strTable += "\n</tr>";
        strTable += "\n</table>";
        //
        strTable += "\n<tr>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>Năm ký hợp đồng: " + m_cbo_nam_ky.SelectedItem.Text + " </td>";
        strTable += "\n</tr>";
        strTable += "\n</table>";
        //
        strTable += "\n<tr>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>Ngày hiệu lực: " + CIPConvert.ToStr(m_dat_ngay_hieu_luc.SelectedDate, "dd/MM/yyyy") + " </td>";
        strTable += "\n</tr>";
        strTable += "\n</table>";
        //
        strTable += "\n<tr>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>Ngày kết thúc: " + CIPConvert.ToStr(m_dat_date_ket_thuc.SelectedDate, "dd/MM/yyyy") + " </td>";
        strTable += "\n</tr>";
        strTable += "\n</table>";

        //table noi dung
        strTable += "<table cellpadding='2' cellspacing='0' class='cssTableReport'>";
        strTable += "\n<tr>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>STT</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Số hợp đồng</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Ngày ký</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Mã giảng viên</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Tên giảng viên</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Mã số thuế</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Số tài khoản</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Tên ngân hàng</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Loại hợp đồng</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Đơn vị quản lý</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Đơn vị thanh toán</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Môn 1</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Môn 2</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Môn 3</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Môn 4</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Môn 5</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Môn 6</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Ngày hiệu lực</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Ngày kết thúc</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Trạng thái hợp đồng</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Mã PO Phụ trách</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Giá trị hợp đồng</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Thuế suất(%)</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>HĐ học liệu?</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>HĐ vận hành?</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Có số hợp đồng?</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Ghi chú</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Ghi chú 2</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Ghi chú 3</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Ghi chú 4</td>";
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

    private void loadDSExprort(ref string strTable)
    {
        get_data_2_export_excel();
        // Mỗi cột dữ liệu ứng với từng dòng là label
        foreach (DataRow grv in this.m_ds_hop_dong_khung.V_DM_HOP_DONG_KHUNG.Rows)
        {
            int v_i_so_thu_tu = 0;
            strTable += "\n<tr>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" +  ++v_i_so_thu_tu + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" +  grv[V_DM_HOP_DONG_KHUNG.SO_HOP_DONG].ToString() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + convert_datetime_2_str(grv[V_DM_HOP_DONG_KHUNG.NGAY_KY]) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + get_ma_gv_form_id(CIPConvert.ToDecimal(grv[V_DM_HOP_DONG_KHUNG.ID_GIANG_VIEN])) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + grv[V_DM_HOP_DONG_KHUNG.GIANG_VIEN].ToString() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + "'"+grv[V_DM_HOP_DONG_KHUNG.MA_SO_THUE].ToString() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + "'" + grv[V_DM_HOP_DONG_KHUNG.SO_TAI_KHOAN].ToString() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + grv[V_DM_HOP_DONG_KHUNG.TEN_NGAN_HANG].ToString() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + grv[V_DM_HOP_DONG_KHUNG.LOAI_HOP_DONG].ToString() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + grv[V_DM_HOP_DONG_KHUNG.DON_VI_QUAN_LY].ToString() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + grv[V_DM_HOP_DONG_KHUNG.DON_VI_THANH_TOAN].ToString() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + grv[V_DM_HOP_DONG_KHUNG.FIRST_MON].ToString() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + grv[V_DM_HOP_DONG_KHUNG.SEC_MON].ToString() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + grv[V_DM_HOP_DONG_KHUNG.THIR_MON].ToString() + "</td>";

            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + grv[V_DM_HOP_DONG_KHUNG.FOURTH_MON].ToString() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + grv[V_DM_HOP_DONG_KHUNG.FITH_MON].ToString() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + grv[V_DM_HOP_DONG_KHUNG.SIXTH_MON].ToString() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + convert_datetime_2_str(grv[V_DM_HOP_DONG_KHUNG.NGAY_HIEU_LUC]) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + convert_datetime_2_str(grv[V_DM_HOP_DONG_KHUNG.NGAY_KET_THUC_DU_KIEN]) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + grv[V_DM_HOP_DONG_KHUNG.TRANG_THAI_HOP_DONG].ToString() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + grv[V_DM_HOP_DONG_KHUNG.MA_PO_PHU_TRACH].ToString() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" +convert_so_tien_2_str(grv[V_DM_HOP_DONG_KHUNG.GIA_TRI_HOP_DONG].ToString()) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + grv[V_DM_HOP_DONG_KHUNG.THUE_SUAT].ToString()+"%" + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_YN(grv[V_DM_HOP_DONG_KHUNG.HOC_LIEU_YN].ToString()) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_YN(grv[V_DM_HOP_DONG_KHUNG.VAN_HANH_YN].ToString()) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_YN(grv[V_DM_HOP_DONG_KHUNG.CO_SO_HD_YN].ToString()) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + grv[V_DM_HOP_DONG_KHUNG.GHI_CHU].ToString() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + grv[V_DM_HOP_DONG_KHUNG.GHI_CHU2].ToString() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + grv[V_DM_HOP_DONG_KHUNG.GHI_CHU3].ToString() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + grv[V_DM_HOP_DONG_KHUNG.GHI_CHU4].ToString() + "</td>";
            strTable += "\n</tr>";
        }
    }

    #endregion
    protected void cmd_them_moi_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("/TRMProject/ChucNang/F301_GdHopDongKhung.aspx?mode=add", false);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
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
            clear_session();
            m_grv_dm_danh_sach_hop_dong_khung.PageSize = 50;
           get_form_search_data_and_load_to_grid();
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
    protected void m_grv_dm_danh_sach_hop_dong_khung_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            m_grv_dm_danh_sach_hop_dong_khung.PageIndex = e.NewPageIndex;
            get_form_search_data_and_load_to_grid();
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
            string strNamFile = "DSHopDongKhung" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + ".xls";
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
}