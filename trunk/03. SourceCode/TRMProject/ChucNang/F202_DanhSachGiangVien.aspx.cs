using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Web.UI.HtmlControls;

using IP.Core.IPCommon;
using IP.Core.IPData;
using IP.Core.IPUserService;

using WebUS;
using WebDS;
using WebDS.CDBNames;
using System.Data;

public partial class ChuNang_F202_DanhSachGiangVien : System.Web.UI.Page
{

    #region Members
    US_V_DM_GIANG_VIEN m_us_dm_giang_vien = new US_V_DM_GIANG_VIEN();
    DS_V_DM_GIANG_VIEN m_ds_giang_vien = new DS_V_DM_GIANG_VIEN();

    US_CM_DM_TU_DIEN m_us_cm_dm_tu_dien = new US_CM_DM_TU_DIEN();
    DS_CM_DM_TU_DIEN m_ds_cm_dm_tu_dien = new DS_CM_DM_TU_DIEN();
    #endregion

    // Cho phép nhìn lại lần cuối cùng ta search trên form giảng viên là gì?
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            m_txt_ten_giang_vien.Focus();
            m_lbl_thong_bao.Text = "";
            
            if (!IsPostBack)
            {                
                // Nếu đã tồn tại session, ta load lại dữ liệu lên form và search theo session
                if (Session["Sname"] != null)
                {
                    session_2_form();
                    search_using_session();
                }
                load_2_cbo_don_vi_q_ly();
                load_2_cbo_trang_thai_giang_vien();
                load_data_2_nam_bd_hop_tac();

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

    #region Private Methods
    
    private void load_data_to_grid()
    {
        try
        {
            // Đổ dữ liệu từ US vào DS
            m_us_dm_giang_vien.FillDataset(m_ds_giang_vien);

            // Treo dữ liệu lên lưới
            m_grv_dm_danh_sach_giang_vien.DataSource = m_ds_giang_vien.V_DM_GIANG_VIEN;
            m_grv_dm_danh_sach_giang_vien.DataBind();
        }
        catch (Exception v_e)
        {
            throw v_e;

        }
    }
   
    private string get_ma_from_id(string ip_dc_id_trang_thai_giang_vien)
    {
        try
        {
            US_CM_DM_TU_DIEN v_us_dm_tu_dien = new US_CM_DM_TU_DIEN();
            DS_CM_DM_TU_DIEN v_ds_dm_tu_dien = new DS_CM_DM_TU_DIEN();

            v_us_dm_tu_dien.FillDataset(v_ds_dm_tu_dien, " WHERE ID = " + ip_dc_id_trang_thai_giang_vien + "");
            return CIPConvert.ToStr(v_ds_dm_tu_dien.CM_DM_TU_DIEN[0][CM_DM_TU_DIEN.MA_TU_DIEN]);
        }

        catch (Exception v_e)
        {

            throw v_e;
        }
    }

    private void delete_dm_giang_vien(int ip_i_row_del)
    {
        try
        {
            decimal v_dc_id_ma_giang_vien = CIPConvert.ToDecimal(m_grv_dm_danh_sach_giang_vien.DataKeys[ip_i_row_del].Value);
            m_us_dm_giang_vien.dcID = v_dc_id_ma_giang_vien;
            m_us_dm_giang_vien.DeleteByID(v_dc_id_ma_giang_vien);
            m_lbl_thong_bao.Text = "Xóa bản ghi thành công";
            get_form_search_data_and_load_to_grid();
        }
        catch (Exception v_e)
        {

            throw v_e;
        }

    }

    //
    // Region for search
    //
    private void load_data_2_nam_bd_hop_tac()
    {
        m_cbo_nam_bd_hop_tac.Items.Add(new ListItem("Tất cả",CIPConvert.ToStr(0)));
        for (int v_i = 2000; v_i < 2051; v_i++)
        {
            m_cbo_nam_bd_hop_tac.Items.Add(new ListItem(v_i.ToString(),v_i.ToString()));
        }
    }

    private void load_2_cbo_trang_thai_giang_vien()
    {
        try
        {
            DS_CM_DM_TU_DIEN v_ds_cm_tu_dien = new DS_CM_DM_TU_DIEN();
            US_CM_DM_TU_DIEN v_us_cm_tu_dien = new US_CM_DM_TU_DIEN();
           // DataRow v_dr_all = m_ds_cm_dm_tu_dien.CM_DM_TU_DIEN.NewCM_DM_TU_DIENRow();
            // Đổ dữ liệu vào DS 
            v_us_cm_tu_dien.FillDataset(v_ds_cm_tu_dien, " WHERE ID_LOAI_TU_DIEN = " + (int)e_loai_tu_dien.TRANG_THAI_GIANG_VIEN); // Đây là lấy theo điều kiện
           
            m_cbo_trang_thai_g_vien.Items.Add(new ListItem("Tất cả","0"));
            for (int i = 0; i < v_ds_cm_tu_dien.CM_DM_TU_DIEN.Rows.Count; i++)
            {
                m_cbo_trang_thai_g_vien.Items.Add(new ListItem(v_ds_cm_tu_dien.CM_DM_TU_DIEN[i][CM_DM_TU_DIEN.TEN].ToString(), v_ds_cm_tu_dien.CM_DM_TU_DIEN[i][CM_DM_TU_DIEN.ID].ToString()));
            }
        }

        catch (Exception v_e)
        {
            throw v_e;
        }
    }
   /// <summary>
   /// Load session và đổ lên form
   /// </summary>
    private void session_2_form()
    {
        m_txt_ten_giang_vien.Text = CIPConvert.ToStr(Session["Sname"]);
        if (CIPConvert.ToStr(Session["Sgender"]).Equals("N"))
            rdl_gender_check.Items[2].Selected = true;
        else if (CIPConvert.ToStr(Session["Sgender"]).Equals("Y"))
            rdl_gender_check.Items[1].Selected = true;
        else rdl_gender_check.Items[0].Selected = true;
        m_cbo_trang_thai_g_vien.SelectedValue = CIPConvert.ToStr(CIPConvert.ToDecimal(Session["Sstatus"]));
        m_cbo_don_vi_q_ly.SelectedValue = CIPConvert.ToStr(CIPConvert.ToDecimal(Session["Squanly"]));
        m_txt_tu_khoa_tim_kiem.Text = CIPConvert.ToStr(Session["Skey"]);
        m_cbo_thang_bd_hop_tac.SelectedValue = CIPConvert.ToStr(CIPConvert.ToDecimal(Session["Sthanghoptac"]));
        m_cbo_nam_bd_hop_tac.SelectedValue = CIPConvert.ToStr(CIPConvert.ToDecimal(Session["Snamhoptac"]));
        m_cbo_thang_sn_GV.SelectedValue = CIPConvert.ToStr(CIPConvert.ToDecimal(Session["Smonth"]));

        if (CIPConvert.ToStr(Session["Sduyethl"]) == "Y") m_cbl_loai_hinh_thuc_cong_tac.Items[3].Selected = true;
        if (CIPConvert.ToStr(Session["Shdkh"]) == "Y") m_cbl_loai_hinh_thuc_cong_tac.Items[6].Selected = true;
        if (CIPConvert.ToStr(Session["Squayhl"]) == "Y") m_cbl_loai_hinh_thuc_cong_tac.Items[5].Selected = true;
        if (CIPConvert.ToStr(Session["Sthamdinhhl"]) == "Y") m_cbl_loai_hinh_thuc_cong_tac.Items[4].Selected = true;
        if (CIPConvert.ToStr(Session["Sviethl"]) == "Y") m_cbl_loai_hinh_thuc_cong_tac.Items[2].Selected = true;
        if (CIPConvert.ToStr(Session["Sgvcm"]) == "Y") m_cbl_loai_hinh_thuc_cong_tac.Items[1].Selected = true;
        if (CIPConvert.ToStr(Session["Sgvhd"]) == "Y") m_cbl_loai_hinh_thuc_cong_tac.Items[0].Selected = true;

        m_txt_po_phu_trach_chinh.Text = CIPConvert.ToStr(Session["Spochinh"]);
        m_txt_po_phu_trach_chinh.Text = CIPConvert.ToStr(Session["Spophu"]);
    }

    private int count_selected_hinh_thuc_cong_tac()
    {
        int v_i_so_hinh_thuc = 0;
        for (int v_i = 0; v_i < m_cbl_loai_hinh_thuc_cong_tac.Items.Count; v_i++)
        {
            if (m_cbl_loai_hinh_thuc_cong_tac.Items[v_i].Selected)
                v_i_so_hinh_thuc += 1;
        }
        return v_i_so_hinh_thuc;
    }
    private void load_2_cbo_don_vi_q_ly()
    {
        try
        {
            DS_CM_DM_TU_DIEN v_ds_cm_tu_dien = new DS_CM_DM_TU_DIEN();
            US_CM_DM_TU_DIEN v_us_cm_tu_dien = new US_CM_DM_TU_DIEN();
            //v_ds_cm_tu_dien.Clear();
            //DataRow v_dr_all_dv_quan_ly = m_ds_cm_dm_tu_dien.CM_DM_TU_DIEN.NewCM_DM_TU_DIENRow();
            // Đổ dữ liệu vào DS 
            v_us_cm_tu_dien.FillDataset(v_ds_cm_tu_dien, " WHERE ID_LOAI_TU_DIEN = "
                                                + (int)e_loai_tu_dien.DON_VI_QUAN_LY_CHINH); // Đây là lấy theo điều kiện

              m_cbo_don_vi_q_ly.Items.Add(new ListItem("Tất cả","0"));
            for (int i = 0; i < v_ds_cm_tu_dien.CM_DM_TU_DIEN.Rows.Count; i++)
            {
                m_cbo_don_vi_q_ly.Items.Add(new ListItem(v_ds_cm_tu_dien.CM_DM_TU_DIEN[i][CM_DM_TU_DIEN.TEN].ToString(),v_ds_cm_tu_dien.CM_DM_TU_DIEN[i][CM_DM_TU_DIEN.ID].ToString()));
            }
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    private string get_gender_search()
    {
        string v_str_gen = "";
        if (rdl_gender_check.Items[0].Selected) v_str_gen = "All";
        else if (rdl_gender_check.Items[1].Selected) v_str_gen = "Y";
        else v_str_gen = "N";
        return v_str_gen;
    }

    //Thu thập dữ liệu và cho vào sesion
    /// <summary>
    /// Thu thập dữ liệu và gán cho các session
    /// </summary>
    /// <param name="ip_str_name"></param>
    /// <param name="ip_str_keyword"></param>
    /// <param name="ip_str_gender"></param>
    /// <param name="ip_dc_id_trang_thai_giang_vien"></param>
    /// <param name="ip_dc_id_don_vi_quan_ly"></param>
    /// <param name="ip_dat_ngay_bd_hop_tac"></param>
    /// <param name="ip_dc_month_birthday"></param>
    private void collect_data_2_search(string ip_str_name,string ip_str_keyword
                                    , string ip_str_gender
                                    , decimal ip_dc_id_trang_thai_giang_vien
                                    , decimal ip_dc_id_don_vi_quan_ly
                                    , decimal ip_dc_thang_bd_hop_tac
                                    , decimal ip_dc_nam_bd_hop_tac
                                    , decimal ip_dc_month_birthday
                                    , string ip_str_gvhd
                                    , string ip_str_gvcm
                                    , string ip_str_gv_viet_hl
                                    , string ip_str_gv_tham_dinh_hl
                                    , string ip_str_duyet_hl
                                    , string ip_str_gv_quay_hl
                                    , string ip_str_hdkh
                                    , string ip_str_po_phu_trach_chinh
                                    , string ip_str_po_phu_trach_phu
                                    , string ip_str_trang_thai_thong_tin)
    {
        Session["Sname"] = ip_str_name;
        Session["Skey"] = ip_str_keyword;
        Session["Sstatus"] = ip_dc_id_trang_thai_giang_vien;
        Session["Sgender"] = ip_str_gender;
        Session["Squanly"] = ip_dc_id_don_vi_quan_ly;
        Session["Sthanghoptac"] = ip_dc_thang_bd_hop_tac;
        Session["Snamhoptac"] = ip_dc_nam_bd_hop_tac;
        Session["Smonth"] = ip_dc_month_birthday;
        Session["Sgvcm"] = ip_str_gvcm;
        Session["Sgvhd"] = ip_str_gvhd;
        Session["Sviethl"] = ip_str_gv_viet_hl;
        Session["Sduyethl"] = ip_str_duyet_hl;
        Session["Sthamdinhhl"] = ip_str_gv_tham_dinh_hl;
        Session["Squayhl"] = ip_str_gv_quay_hl;
        Session["Shdkh"] = ip_str_hdkh;
        Session["Spochinh"] = ip_str_po_phu_trach_chinh;
        Session["Spophu"] = ip_str_po_phu_trach_phu;
        Session["Strangthaitt"] = ip_str_trang_thai_thong_tin;
    }
    private void get_form_search_data_and_load_to_grid()
    {
        try
        {
            System.Globalization.CultureInfo enUS = new System.Globalization.CultureInfo("en-US"); 

            // thu thập dữ liệu và chuẩn hóa        
            string v_str_ten_giang_vien = m_txt_ten_giang_vien.Text.Trim();
            v_str_ten_giang_vien = Process_name_search(v_str_ten_giang_vien);

            string v_str_search_key_word = m_txt_tu_khoa_tim_kiem.Text.Trim();
            v_str_search_key_word = Process_name_search(v_str_search_key_word);

            string v_str_gender="";
            v_str_gender = get_gender_search();
            decimal v_dc_thang_bd_hop_tac, v_dc_nam_bd_hop_tac;
            v_dc_thang_bd_hop_tac = CIPConvert.ToDecimal(m_cbo_thang_bd_hop_tac.SelectedValue);
            v_dc_nam_bd_hop_tac = CIPConvert.ToDecimal(m_cbo_nam_bd_hop_tac.SelectedValue);      
            string v_str_month = m_cbo_thang_sn_GV.SelectedValue;
                 
            decimal v_dc_id_trang_thai_giang_vien = CIPConvert.ToDecimal(m_cbo_trang_thai_g_vien.SelectedValue);
            decimal v_dc_id_don_vi_quan_ly= CIPConvert.ToDecimal(m_cbo_don_vi_q_ly.SelectedValue);

            // Lấy dữ liệu loại hình cộng tác
            string v_str_gvhd, v_str_gvcm, v_str_gv_viet_hl, v_str_gv_tham_dinh_hl, v_str_duyet_hl, v_str_gv_quay_hl, v_str_hdkh;
            if (count_selected_hinh_thuc_cong_tac() == 0)
            {
                v_str_duyet_hl = "A";
                v_str_hdkh = "A";
                v_str_gv_quay_hl = "A";
                v_str_gv_tham_dinh_hl = "A";
                v_str_gv_viet_hl = "A";
                v_str_gvcm = "A";
                v_str_gvhd = "A";
            }
            else
            {
                v_str_duyet_hl = m_cbl_loai_hinh_thuc_cong_tac.Items[3].Selected ? "Y" : "N";
                v_str_hdkh = m_cbl_loai_hinh_thuc_cong_tac.Items[6].Selected ? "Y" : "N";
                v_str_gv_quay_hl = m_cbl_loai_hinh_thuc_cong_tac.Items[5].Selected ? "Y" : "N";
                v_str_gv_tham_dinh_hl = m_cbl_loai_hinh_thuc_cong_tac.Items[4].Selected ? "Y" : "N";
                v_str_gv_viet_hl = m_cbl_loai_hinh_thuc_cong_tac.Items[2].Selected ? "Y" : "N";
                v_str_gvcm = m_cbl_loai_hinh_thuc_cong_tac.Items[1].Selected ? "Y" : "N";
                v_str_gvhd = m_cbl_loai_hinh_thuc_cong_tac.Items[0].Selected ? "Y" : "N";
            }
            // Po phụ trách
            string v_str_po_phu_trach_chinh, v_str_po_phu_trach_phu;
            v_str_po_phu_trach_chinh = m_txt_po_phu_trach_chinh.Text.Trim();
            v_str_po_phu_trach_phu = m_txt_po_phu_trach_phu.Text.Trim();
            string v_str_trang_thai_thong_tin_gv = m_cbo_trang_thai_thong_tin.SelectedValue;

            // Thu thập dữ liệu và cho vào Session
            collect_data_2_search(v_str_ten_giang_vien
                                                  , v_str_search_key_word
                                                  , v_str_gender
                                                  , v_dc_id_trang_thai_giang_vien
                                                  , v_dc_id_don_vi_quan_ly
                                                  , v_dc_thang_bd_hop_tac
                                                  , v_dc_nam_bd_hop_tac
                                                  , CIPConvert.ToDecimal(v_str_month)
                                                  , v_str_gvhd
                                                  , v_str_gvcm
                                                  , v_str_gv_viet_hl
                                                  , v_str_gv_tham_dinh_hl
                                                  , v_str_duyet_hl
                                                  , v_str_gv_quay_hl
                                                  , v_str_hdkh
                                                  , v_str_po_phu_trach_chinh
                                                  , v_str_po_phu_trach_phu
                                                  , v_str_trang_thai_thong_tin_gv);
            // Thực hiện Search

            m_us_dm_giang_vien.search_giang_vien(v_str_ten_giang_vien
                                                ,v_str_search_key_word      
                                                ,v_str_gender   
                                                ,v_dc_id_trang_thai_giang_vien
                                                ,v_dc_id_don_vi_quan_ly
                                                ,m_ds_giang_vien
                                                ,v_dc_thang_bd_hop_tac
                                                ,v_dc_nam_bd_hop_tac
                                                ,CIPConvert.ToDecimal(v_str_month)
                                                ,v_str_gvhd
                                                ,v_str_gvcm
                                                ,v_str_gv_viet_hl
                                                ,v_str_gv_tham_dinh_hl
                                                ,v_str_duyet_hl
                                                ,v_str_gv_quay_hl
                                                ,v_str_hdkh
                                                ,v_str_po_phu_trach_chinh
                                                ,v_str_po_phu_trach_phu
                                                ,v_str_trang_thai_thong_tin_gv
                                                , CIPConvert.ToStr(Session["Username"]));
            m_lbl_ket_qua_loc_du_lieu.Text = "Kết quả lọc dữ liệu: " + m_ds_giang_vien.V_DM_GIANG_VIEN.Rows.Count + " bản ghi";
            if (m_ds_giang_vien.V_DM_GIANG_VIEN.Rows.Count == 0)
            {
                m_lbl_thong_bao.Text = "Không có bản ghi nào phù hợp";
                if (m_grv_dm_danh_sach_giang_vien.Visible == true) m_grv_dm_danh_sach_giang_vien.Visible = false;
                return;
            }
            m_grv_dm_danh_sach_giang_vien.Visible = true;
            m_grv_dm_danh_sach_giang_vien.DataSource = m_ds_giang_vien.V_DM_GIANG_VIEN;
            m_grv_dm_danh_sach_giang_vien.DataBind();
        }
        catch (Exception v_e)
        {

            throw v_e;
        }
    }

    private void get_data_to_search_excel()
    {
        System.Globalization.CultureInfo enUS = new System.Globalization.CultureInfo("en-US");

        // thu thập dữ liệu và chuẩn hóa        
        string v_str_ten_giang_vien = m_txt_ten_giang_vien.Text.Trim();
        v_str_ten_giang_vien = Process_name_search(v_str_ten_giang_vien);

        string v_str_search_key_word = m_txt_tu_khoa_tim_kiem.Text.Trim();
        v_str_search_key_word = Process_name_search(v_str_search_key_word);

        string v_str_gender = "";
        v_str_gender = get_gender_search();
        decimal v_dc_thang_bd_hop_tac, v_dc_nam_bd_hop_tac;
        v_dc_thang_bd_hop_tac = CIPConvert.ToDecimal(m_cbo_thang_bd_hop_tac.SelectedValue);
        v_dc_nam_bd_hop_tac = CIPConvert.ToDecimal(m_cbo_nam_bd_hop_tac.SelectedValue);
        string v_str_month = m_cbo_thang_sn_GV.SelectedValue;

        decimal v_dc_id_trang_thai_giang_vien = CIPConvert.ToDecimal(m_cbo_trang_thai_g_vien.SelectedValue);
        decimal v_dc_id_don_vi_quan_ly = CIPConvert.ToDecimal(m_cbo_don_vi_q_ly.SelectedValue);

        // Lấy dữ liệu loại hình cộng tác
        string v_str_gvhd, v_str_gvcm, v_str_gv_viet_hl, v_str_gv_tham_dinh_hl, v_str_duyet_hl, v_str_gv_quay_hl, v_str_hdkh;
        if (count_selected_hinh_thuc_cong_tac() == 0)
        {
            v_str_duyet_hl = "A";
            v_str_hdkh = "A";
            v_str_gv_quay_hl = "A";
            v_str_gv_tham_dinh_hl = "A";
            v_str_gv_viet_hl = "A";
            v_str_gvcm = "A";
            v_str_gvhd = "A";
        }
        else
        {
            v_str_duyet_hl = m_cbl_loai_hinh_thuc_cong_tac.Items[3].Selected ? "Y" : "N";
            v_str_hdkh = m_cbl_loai_hinh_thuc_cong_tac.Items[6].Selected ? "Y" : "N";
            v_str_gv_quay_hl = m_cbl_loai_hinh_thuc_cong_tac.Items[5].Selected ? "Y" : "N";
            v_str_gv_tham_dinh_hl = m_cbl_loai_hinh_thuc_cong_tac.Items[4].Selected ? "Y" : "N";
            v_str_gv_viet_hl = m_cbl_loai_hinh_thuc_cong_tac.Items[2].Selected ? "Y" : "N";
            v_str_gvcm = m_cbl_loai_hinh_thuc_cong_tac.Items[1].Selected ? "Y" : "N";
            v_str_gvhd = m_cbl_loai_hinh_thuc_cong_tac.Items[0].Selected ? "Y" : "N";
        }
        // Po phụ trách
        string v_str_po_phu_trach_chinh, v_str_po_phu_trach_phu;
        v_str_po_phu_trach_chinh = m_txt_po_phu_trach_chinh.Text.Trim();
        v_str_po_phu_trach_phu = m_txt_po_phu_trach_phu.Text.Trim();
        string v_str_trang_thai_thong_tin_gv = m_cbo_trang_thai_thong_tin.SelectedValue;
        // Thực hiện Search
        m_us_dm_giang_vien.search_giang_vien(v_str_ten_giang_vien
                                            , v_str_search_key_word
                                            , v_str_gender
                                            , v_dc_id_trang_thai_giang_vien
                                            , v_dc_id_don_vi_quan_ly
                                            , m_ds_giang_vien
                                            , v_dc_thang_bd_hop_tac
                                            , v_dc_nam_bd_hop_tac
                                            , CIPConvert.ToDecimal(v_str_month)
                                            , v_str_gvhd
                                            , v_str_gvcm
                                            , v_str_gv_viet_hl
                                            , v_str_gv_tham_dinh_hl
                                            , v_str_duyet_hl
                                            , v_str_gv_quay_hl
                                            , v_str_hdkh
                                            , v_str_po_phu_trach_chinh
                                            , v_str_po_phu_trach_phu
                                            , v_str_trang_thai_thong_tin_gv
                                            , CIPConvert.ToStr(Session["Username"]));
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
    /// <summary>
    /// Search sử dụng session
    /// </summary>
    private void search_using_session()
    {
        try
        {
            m_ds_giang_vien.Clear();
            m_us_dm_giang_vien.search_giang_vien(CIPConvert.ToStr(Session["Sname"])
                                               , CIPConvert.ToStr(Session["Skey"])
                                               , CIPConvert.ToStr(Session["Sgender"])
                                               , CIPConvert.ToDecimal(Session["Sstatus"])
                                               , CIPConvert.ToDecimal(Session["Squanly"])
                                               , m_ds_giang_vien
                                               , CIPConvert.ToDecimal(Session["Sthanghoptac"])
                                               , CIPConvert.ToDecimal(Session["Snamhoptac"])
                                               , CIPConvert.ToDecimal(Session["Smonth"])
                                               , CIPConvert.ToStr(Session["Sgvcm"])
                                               , CIPConvert.ToStr(Session["Sgvhd"])
                                               , CIPConvert.ToStr(Session["Sviethl"])
                                               , CIPConvert.ToStr(Session["Sduyethl"])
                                               , CIPConvert.ToStr(Session["Sthamdinhhl"])
                                               , CIPConvert.ToStr(Session["Squayhl"])
                                               , CIPConvert.ToStr(Session["Shdkh"])
                                               , CIPConvert.ToStr(Session["Spochinh"])
                                               , CIPConvert.ToStr(Session["Spophu"])
                                               , CIPConvert.ToStr(Session["Strangthaitt"])
                                               , CIPConvert.ToStr(Session["Username"]));
            m_lbl_ket_qua_loc_du_lieu.Text = "Kết quả lọc dữ liệu: " + m_ds_giang_vien.V_DM_GIANG_VIEN.Rows.Count + " bản ghi";
            if (m_ds_giang_vien.V_DM_GIANG_VIEN.Rows.Count == 0)
            {
                m_lbl_thong_bao.Text = "Không có bản ghi nào phù hợp";
                m_grv_dm_danh_sach_giang_vien.DataSource = m_ds_giang_vien.V_DM_GIANG_VIEN;
                m_grv_dm_danh_sach_giang_vien.DataBind();
                if (m_grv_dm_danh_sach_giang_vien.Visible == true) m_grv_dm_danh_sach_giang_vien.Visible = false;
                return;
            }
            m_grv_dm_danh_sach_giang_vien.Visible = true;
            m_grv_dm_danh_sach_giang_vien.DataSource = m_ds_giang_vien.V_DM_GIANG_VIEN;
            m_grv_dm_danh_sach_giang_vien.DataBind();
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
    private string convert_so_tk_2_str(object ip_o_obj)
    {
        if (ip_o_obj == DBNull.Value)
            return "";
        return CIPConvert.ToStr(ip_o_obj,"0");
    }
    private string convert_datetime_2_str(object ip_o_obj)
    {
        if (ip_o_obj == DBNull.Value)
            return "";
        return CIPConvert.ToStr(ip_o_obj,"dd/MM/yyyy");
    }
    //
    // Region for Export Excel
    //
    private string get_hinh_thuc_cong_tac()
    {
        string v_str_hinh_thuc_cong_tac = "";
        for (int v_i = 0; v_i < m_cbl_loai_hinh_thuc_cong_tac.Items.Count; v_i++)
        {
            if (m_cbl_loai_hinh_thuc_cong_tac.Items[v_i].Selected) v_str_hinh_thuc_cong_tac += m_cbl_loai_hinh_thuc_cong_tac.Items[v_i].Text+ ", ";
        }
        v_str_hinh_thuc_cong_tac = v_str_hinh_thuc_cong_tac.Trim();
        if(v_str_hinh_thuc_cong_tac.Length >0)
        v_str_hinh_thuc_cong_tac = v_str_hinh_thuc_cong_tac.Substring(0, v_str_hinh_thuc_cong_tac.Length - 1);
        return v_str_hinh_thuc_cong_tac;
    }
    private void loadDSExprort(ref string strTable)
    {
        int v_i_so_thu_tu = 0;
        get_data_to_search_excel();
        // Mỗi cột dữ liệu ứng với từng dòng là label
        foreach (DataRow grv in this.m_ds_giang_vien.V_DM_GIANG_VIEN.Rows)
        {
            strTable += "\n<tr>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + ++v_i_so_thu_tu + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + (grv[V_DM_GIANG_VIEN.MA_GIANG_VIEN]).ToString() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + (grv[V_DM_GIANG_VIEN.HO_VA_TEN_DEM]).ToString().Trim() + " " + (grv[V_DM_GIANG_VIEN.TEN_GIANG_VIEN]).ToString() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + convert_datetime_2_str(grv[V_DM_GIANG_VIEN.NGAY_SINH]) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_gender(CIPConvert.ToStr(grv[V_DM_GIANG_VIEN.GIOI_TINH_YN])) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + (grv[V_DM_GIANG_VIEN.DON_VI_QUAN_LY]).ToString() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + (grv[V_DM_GIANG_VIEN.DIA_CHI]).ToString() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + (grv[V_DM_GIANG_VIEN.TEN_CO_QUAN_CONG_TAC]).ToString() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + "'" + (grv[V_DM_GIANG_VIEN.TEL_OFFICE]).ToString() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + "'"+(grv[V_DM_GIANG_VIEN.MOBILE_PHONE]).ToString() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + "'" + (grv[V_DM_GIANG_VIEN.TEL_HOME]).ToString() + "</td>";

            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + "'" + (grv[V_DM_GIANG_VIEN.SO_CMTND]).ToString() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + convert_datetime_2_str(grv[V_DM_GIANG_VIEN.NGAY_CAP]) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + (grv[V_DM_GIANG_VIEN.NOI_CAP]).ToString() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + (grv[V_DM_GIANG_VIEN.EMAIL]).ToString() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + (grv[V_DM_GIANG_VIEN.EMAIL_TOPICA]).ToString() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + "'"+(grv[V_DM_GIANG_VIEN.SO_TAI_KHOAN]).ToString() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + (grv[V_DM_GIANG_VIEN.TEN_NGAN_HANG]).ToString() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + "'" + (grv[V_DM_GIANG_VIEN.MA_SO_THUE]).ToString() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_hoc_vi(grv[V_DM_GIANG_VIEN.HOC_VI].ToString()) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_hoc_ham(grv[V_DM_GIANG_VIEN.HOC_HAM].ToString()) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + (grv[V_DM_GIANG_VIEN.CHUYEN_NGANH_CHINH]).ToString() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + (grv[V_DM_GIANG_VIEN.TRUONG_DAO_TAO]).ToString() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + (grv[V_DM_GIANG_VIEN.CHUC_VU_HIEN_TAI]).ToString() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + (grv[V_DM_GIANG_VIEN.CHUC_VU_CAO_NHAT]).ToString() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + (grv[V_DM_GIANG_VIEN.TRANG_THAI_GIANG_VIEN]).ToString() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + (grv[V_DM_GIANG_VIEN.PO_PHU_TRACH_CHINH]).ToString() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + (grv[V_DM_GIANG_VIEN.PO_PHU_TRACH_PHU]).ToString() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + (grv[V_DM_GIANG_VIEN.PO_PHU_TRACH_PHU2]).ToString() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + (grv[V_DM_GIANG_VIEN.PO_PHU_TRACH_PHU3]).ToString() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + (grv[V_DM_GIANG_VIEN.PO_PHU_TRACH_PHU4]).ToString() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + convert_datetime_2_str(grv[V_DM_GIANG_VIEN.NGAY_BD_HOP_TAC]) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_hd(grv[V_DM_GIANG_VIEN.GVHD_YN].ToString()) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_cm(grv[V_DM_GIANG_VIEN.GVCM_YN].ToString()) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_viet_hl(grv[V_DM_GIANG_VIEN.GV_VIET_HL_YN].ToString()) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_duyet_hl(grv[V_DM_GIANG_VIEN.GV_DUYET_HL_YN].ToString()) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_tham_dinh_hl(grv[V_DM_GIANG_VIEN.GV_THAM_DINH_HL_YN].ToString()) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_quay_hl(grv[V_DM_GIANG_VIEN.GV_QUAY_HL].ToString()) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_hdkh(grv[V_DM_GIANG_VIEN.GV_HDKH_YN].ToString()) + "</td>";
            strTable += "\n</tr>";
        }
    }

    private void loadTieuDe(ref string strTable)
    {
        strTable += "<table cellpadding='2' cellspacing='0' class='cssTableReport'>";
        strTable += "\n<tr>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width: 100%;  height: 40px; font-size: large; color:White; background-color:#810C15;' nowrap='wrap'>TRM202 - BÁO CÁO DANH SÁCH GIẢNG VIÊN " + "</td>";
        strTable += "\n</tr>";
        //
        strTable += "\n<tr>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>Giới tính: " + mapping_gender(get_gender_search()) + "</td>";
        strTable += "\n</tr>";
        
        //
        strTable += "\n<tr>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>Trạng thái giảng viên: " + m_cbo_trang_thai_g_vien.SelectedItem.Text + "</td>";
        strTable += "\n</tr>";
        //
        strTable += "\n<tr>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>Đơn vị quản lý giảng viên: " + m_cbo_don_vi_q_ly.SelectedItem.Text + "</td>";
        strTable += "\n</tr>";
        //
        //strTable += "\n<tr>";
        //strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        //strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        //strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>Đơn vị quản lý hợp đồng: " + ddDonViQuanLy.SelectedItem.ToString() + "</td>";
        //strTable += "\n</tr>";        
        //
        strTable += "\n<tr>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>Tháng sinh nhật giảng viên: " + m_cbo_thang_sn_GV.SelectedItem.Text + "</td>";
        strTable += "\n</tr>";
        //
        strTable += "\n<tr>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>Tháng bắt đầu hợp tác: " + m_cbo_thang_bd_hop_tac.SelectedItem.Text + " </td>";
        strTable += "\n</tr>";
        //
        strTable += "\n<tr>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>Năm bắt đầu hợp tác: " + m_cbo_nam_bd_hop_tac.SelectedItem.Text + " </td>";
        strTable += "\n</tr>";
        //
        strTable += "\n<tr>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>Hình thức cộng tác: " + get_hinh_thuc_cong_tac() + " </td>";
        strTable += "\n</tr>";
        //
        strTable += "\n<tr>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>PO phụ trách chính: " + m_txt_po_phu_trach_chinh.Text + " </td>";
        strTable += "\n</tr>";
        //
        strTable += "\n<tr>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>PO phụ trách phụ: " + m_txt_po_phu_trach_phu.Text + " </td>";
        strTable += "\n</tr>";

        strTable += "\n</table>";
         
        //table noi dung
        strTable += "<table cellpadding='2' cellspacing='0' class='cssTableReport'>";
        strTable += "\n<tr>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>STT</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Mã giảng viên</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Họ và Tên</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Ngày sinh</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Giới tính</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Đơn vị quản lý</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Địa chỉ giảng viên</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Tên cơ quan công tác</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Điện thoại cơ quan</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Điện thoại di động</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Điện thoại nhà riêng</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Số chứng minh</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Ngày cấp</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Nơi cấp</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Email</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Email Topica</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Số tài khoản</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Tên ngân hàng</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Mã số thuế</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Học vị</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Học hàm</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Chuyên ngành chính</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Trường đào tạo</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Chức vụ hiện tại</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Chức vụ cao nhất</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Trạng thái giảng viên</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>PO phụ trách chính</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>PO phụ trách phụ 1</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>PO phụ trách phụ 2</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>PO phụ trách phụ 3</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>PO phụ trách phụ 4</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Ngày bắt đầu hợp tác</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>GV hướng dẫn?</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>GV chuyên môn?</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>GV viết học liệu?</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>GV duyệt học liệu?</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>GV thẩm định học liệu?</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>GV quay học liệu?</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>GV hội đồng khoa học?</td>";
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


    #endregion

    #region Public Interfaces
    public string mapping_gender(string ip_str_gen)
    {
        if (ip_str_gen.Equals("Y"))
            return "Nam";
        else if (ip_str_gen.Equals("All")) return "Tất cả";
        return "Nữ";
    }
    public string mapping_hoc_vi(string ip_str_ma_hoc_vi)
    {
        US_CM_DM_TU_DIEN v_us_tu_dien = new US_CM_DM_TU_DIEN("HOC_VI", ip_str_ma_hoc_vi);
        return v_us_tu_dien.strTEN;
    }
    public string mapping_hoc_ham(string ip_str_ma_hoc_ham)
    {
        US_CM_DM_TU_DIEN v_us_tu_dien = new US_CM_DM_TU_DIEN("HOC_HAM", ip_str_ma_hoc_ham);
        return v_us_tu_dien.strTEN;
    }
    public string mapping_hd(string ip_str_hd_YN)
    {
        if (ip_str_hd_YN.Equals("Y"))
            return "Có";
        return "Không";
    }
    public string mapping_cm(string ip_str_cm_YN)
    {
        if (ip_str_cm_YN.Equals("Y"))
            return "Có";
        return "Không";
    }
    public string mapping_viet_hl(string ip_str_viet_hl_YN)
    {
        if (ip_str_viet_hl_YN.Equals("Y"))
            return "Có";
        return "Không";
    }
    public string mapping_duyet_hl(string ip_str_duyet_hl_YN)
    {
        if (ip_str_duyet_hl_YN.Equals("Y"))
            return "Có";
        return "Không";
    }
    public string mapping_quay_hl(string ip_str_quay_hl_YN)
    {
        if (ip_str_quay_hl_YN.Equals("Y"))
            return "Có";
        return "Không";
    }
    public string mapping_tham_dinh_hl(string ip_str_tham_dinh_hl_YN)
    {
        if (ip_str_tham_dinh_hl_YN.Equals("Y"))
            return "Có";
        return "Không";
    }
    public string mapping_hdkh(string ip_str_hdkh_YN)
    {
        if (ip_str_hdkh_YN.Equals("Y"))
            return "Có";
        return "Không";
    }
    //public string mapping_datetime(string ip_str_datetime)
    //{
    //    if (ip_str_datetime.Equals("") ||CIPConvert.ToStr(ip_str_datetime,"dd/MM/yyyy").Contains("1/1/1900")) return "";
    //    return CIPConvert.ToStr(ip_str_datetime,"dd/MM/yyyy");
    //}
    public string mapping_format_datetime(string ip_str_date)
    {
        if (ip_str_date == "") return "";
        return String.Format("{0:dd/MM/yyyy}", ip_str_date);
    }

    //public override void VerifyRenderingInServerForm(Control control)
    //{
 
    //}
    #endregion

    //
    //Events
    //

    protected void m_grv_dm_danh_sach_giang_vien_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            m_grv_dm_danh_sach_giang_vien.PageIndex = e.NewPageIndex;
            //  search_using_session();
            get_form_search_data_and_load_to_grid();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void cmd_them_moi_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("/TRMProject/ChucNang/F201_CapNhatThongTinGiangVien.aspx?mode=add",false);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    protected void m_grv_dm_danh_sach_giang_vien_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            delete_dm_giang_vien(e.RowIndex);
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
            m_grv_dm_danh_sach_giang_vien.PageSize = 30;
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
            string strNamFile = "DSGiangVien" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + ".xls";
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
    protected void m_cbo_trang_thai_thong_tin_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            m_grv_dm_danh_sach_giang_vien.PageSize = 30;
            get_form_search_data_and_load_to_grid();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
}