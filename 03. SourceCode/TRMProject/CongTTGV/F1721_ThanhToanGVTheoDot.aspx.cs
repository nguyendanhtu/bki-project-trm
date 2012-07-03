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

public partial class CongTTGV_F1721_ThanhToanGVTheoDot : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            m_lbl_thong_bao.Text = "";
            load_data_2_cbo_don_vi_thanh_toan();
            load_data_2_nam_bd_hop_tac();
            load_data_2_cbo_giang_vien();
            load_data_2_cbo_trang_thai_thanh_toan();          
            m_lbl_ma_gv.Text = mapping_magv_by_id(CIPConvert.ToDecimal(m_cbo_ten_giang_vien.SelectedValue));            
            if (Session["UserName"] == null)
                Response.Redirect("/TRMProject/Account/Login.aspx");
            else
            {
                m_cbo_ten_giang_vien.SelectedValue = CIPConvert.ToStr(get_id_giang_vien_by_ma(CIPConvert.ToStr(Session["UserName"])));
                m_lbl_ma_gv.Text = CIPConvert.ToStr(Session["UserName"]);
                load_data_2_cbo_dot_thanh_toan(CIPConvert.ToDecimal(m_cbo_ten_giang_vien.SelectedValue), CIPConvert.ToDecimal(m_cbo_thang_thanh_toan.SelectedValue), CIPConvert.ToDecimal(m_cbo_nam_thanh_toan.SelectedValue), CIPConvert.ToDecimal(m_cbo_don_vi_thanh_toan.SelectedValue));
                if (Request.QueryString["id_dtt"] != null)
                {
                    decimal v_dc_id_dtt = CIPConvert.ToDecimal(Request.QueryString["id_dtt"]);
                    US_V_DM_DOT_THANH_TOAN v_dm_dtt = new US_V_DM_DOT_THANH_TOAN(v_dc_id_dtt);
                    if (!v_dm_dtt.IsMA_DOT_TTNull())
                        m_cbo_dot_thanh_toan.SelectedValue = v_dm_dtt.strMA_DOT_TT;
                }
                search_data_show_on_grid();                
            }            
        }
    }

    #region Members
    US_CM_DM_TU_DIEN m_us_cm_tu_dien = new US_CM_DM_TU_DIEN();
    DS_CM_DM_TU_DIEN m_ds_cm_tu_dien = new DS_CM_DM_TU_DIEN();
    US_V_GD_THANH_TOAN m_us_v_gd_thanh_toan = new US_V_GD_THANH_TOAN();
    DS_V_GD_THANH_TOAN m_v_ds_gd_thanh_toan = new DS_V_GD_THANH_TOAN();
    public string m_str_loai_hd = "";    
    #endregion 

    #region Public Interfaces
    public string mapping_magv_by_id(decimal ip_dc_id_gv)
    {
        if (ip_dc_id_gv == 0) return "";
        US_V_DM_GIANG_VIEN v_dm_gv = new US_V_DM_GIANG_VIEN(ip_dc_id_gv);
        if (v_dm_gv.IsIDNull()) return "";
        return v_dm_gv.strMA_GIANG_VIEN;
    }
    public string mapping_don_vi_quan_ly(decimal ip_dc_id_don_vi_quan_ly)
    {
        US_CM_DM_TU_DIEN v_us_dm_tu_dien = new US_CM_DM_TU_DIEN(ip_dc_id_don_vi_quan_ly);
        return v_us_dm_tu_dien.strTEN;
    }
    public string mapping_loai_hop_dong_gv(decimal ip_dc_id_hd_khung)
    {
        string v_str_noi_dung = "";
        // Lấy tên loại hợp đồng
        US_V_DM_HOP_DONG_KHUNG v_us_dm_hd_khung = new US_V_DM_HOP_DONG_KHUNG(ip_dc_id_hd_khung);
        v_str_noi_dung += v_us_dm_hd_khung.strLOAI_HOP_DONG.Trim();
        return v_str_noi_dung;
    }
    public string mapping_gia_tri_hd(object ip_obj_gia_tri_hd)
    {
        if (ip_obj_gia_tri_hd.GetType() == typeof(DBNull) || CIPConvert.ToDecimal(ip_obj_gia_tri_hd) == 0) return "";
        return CIPConvert.ToStr(ip_obj_gia_tri_hd, "#,###");
    }
    public string mapping_so_tien_con_phai_tt(object ip_obj_so_tien, object ip_obj_loai_hd, object ip_obj_reference)
    {
        if (ip_obj_so_tien.GetType() == typeof(DBNull)) return "";
        if (CIPConvert.ToDecimal(ip_obj_so_tien) == 0)
        {
            if (CIPConvert.ToStr(ip_obj_loai_hd).Equals("VH"))
                return "";
            else if (ip_obj_reference.GetType() != typeof(DBNull)) // nghĩa là tạm ứng học liệu
                return "";
            else return CIPConvert.ToStr(0); // đây là thanh lý học liệu
        }
        return CIPConvert.ToStr(ip_obj_so_tien, "#,###");
    }
    public string mapping_header_nghiem_thu_lop_mon(string ip_str_loai_hd)
    {
        if (ip_str_loai_hd.Equals("VH")) return "Các lớp môn phụ trách";
        else if (ip_str_loai_hd.Equals("HL")) return "Giá trị nghiệm thu thực tế (VNĐ)";
        return "Giá trị nghiệm thu thực tế (VNĐ) / Các lớp môn phụ trách";
    }
    public string mapping_item_field_nghiem_thu_lop_mon(string ip_str_loai_hd, object ip_obj_reference, object ip_obj_gia_tri_nghiem_thu)
    {
        if (ip_obj_reference.GetType() != typeof(DBNull) && ip_str_loai_hd.Equals("VH"))
        {
            return CIPConvert.ToStr(ip_obj_reference);
        }
        else if (ip_obj_gia_tri_nghiem_thu.GetType() != typeof(DBNull) && ip_str_loai_hd.Equals("HL"))
        {
            return mapping_gia_tri_hd(ip_obj_gia_tri_nghiem_thu);
        }
        return "";
    }
    public string mapping_item_field_ten_cac_mon(string ip_str_loai_hd, object ip_obj_ghi_chu_cac_mon_phu_trach)
    {
        if (ip_obj_ghi_chu_cac_mon_phu_trach.GetType() != typeof(DBNull) && ip_str_loai_hd.Equals("VH"))
        {
            return CIPConvert.ToStr(ip_obj_ghi_chu_cac_mon_phu_trach);
        }
        return "";
    }
    public string mapping_trang_thai_thanh_toan(decimal ip_dc_id_trang_thai_tt)
    {
        US_CM_DM_TU_DIEN v_us_dm_tu_dien = new US_CM_DM_TU_DIEN(ip_dc_id_trang_thai_tt);
        return v_us_dm_tu_dien.strTEN;
    }
    public string mapping_time_to_str(object ip_obj_thoi_gian)
    {
        if (ip_obj_thoi_gian.GetType() != typeof(DBNull))
        {
            return CIPConvert.ToStr(ip_obj_thoi_gian);
        }
        return "";
    }
    private string mapping_string(object ip_obj_str)
    {
        if (ip_obj_str.GetType() != typeof(DBNull))
            return CIPConvert.ToStr(ip_obj_str);
        return "";
    }
    public string mapping_so_tien(object ip_obj_nghiem_thu_thuc_te)
    {
        if (ip_obj_nghiem_thu_thuc_te.GetType() == typeof(DBNull)) return "";
        if (CIPConvert.ToDecimal(ip_obj_nghiem_thu_thuc_te) == 0)
            return CIPConvert.ToStr(0);
        return CIPConvert.ToStr(ip_obj_nghiem_thu_thuc_te, "#,###");
    }    
    public decimal get_tong_tien_dot_TT()
    {
        decimal v_tong_tien = 0;
        string v_str_loai_hd = "";
        if (m_rdl_loai_hop_dong.Items[0].Selected)
            v_str_loai_hd = "All";
        else if (m_rdl_loai_hop_dong.Items[1].Selected)
            v_str_loai_hd = "VH";
        else v_str_loai_hd = "HL";

        m_us_v_gd_thanh_toan.fill_dataset_by_id_giang_vien_thang_nam_dot_va_dv_thanh_toan(CIPConvert.ToDecimal(m_cbo_ten_giang_vien.SelectedValue),
                                CIPConvert.ToDecimal(m_cbo_don_vi_thanh_toan.SelectedValue),
                                CIPConvert.ToDecimal(m_cbo_trang_thai_thanh_toan.SelectedValue),
                                v_str_loai_hd,
                                m_txt_reference_code.Text.Trim(),
                                CIPConvert.ToDecimal(m_cbo_thang_thanh_toan.SelectedValue),
                                CIPConvert.ToDecimal(m_cbo_nam_thanh_toan.SelectedValue),
                                m_cbo_dot_thanh_toan.SelectedValue,m_v_ds_gd_thanh_toan);
        foreach (DataRow item in m_v_ds_gd_thanh_toan.V_GD_THANH_TOAN)
        {
            v_tong_tien += CIPConvert.ToDecimal(item["TONG_TIEN_THANH_TOAN"]);
        }
        return v_tong_tien;
    }
    #endregion

    #region Private Methods
    private void load_data_2_grid_search(decimal ip_dc_id_giang_vien,
                                         decimal ip_dc_dv_thanh_toan,
                                         decimal ip_dc_trang_thai_thanh_toan,
                                         string ip_str_loai_hop_dong,
                                         string ip_str_reference_code,
                                         decimal ip_dc_thang_tt,
                                         decimal ip_dc_nam_tt,
                                         string ip_str_ma_dot_thanh_toan)
    {
        if (ip_str_loai_hop_dong.Equals("VH")) // Vận hành
        {
            m_str_loai_hd = "VH";
        }
        else if (ip_str_loai_hop_dong.Equals("HL"))// Học liệu
        {
            m_str_loai_hd = "HL";
        }
        else m_str_loai_hd = "All";

        m_us_v_gd_thanh_toan.fill_dataset_by_id_giang_vien_thang_nam_dot_va_dv_thanh_toan(ip_dc_id_giang_vien,
                                            ip_dc_dv_thanh_toan,
                                            ip_dc_trang_thai_thanh_toan,
                                            ip_str_reference_code,
                                            ip_str_loai_hop_dong,
                                            ip_dc_thang_tt,
                                            ip_dc_nam_tt,
                                            ip_str_ma_dot_thanh_toan,
                                            m_v_ds_gd_thanh_toan);

        if (m_v_ds_gd_thanh_toan.V_GD_THANH_TOAN.Rows.Count == 0)
        {
            m_lbl_thong_bao.Visible = true;
            m_lbl_thong_bao.Text = "Chưa có thanh toán nào cho giảng viên này!";
        }
        else m_lbl_thong_bao.Text = "";
        m_grv_danh_sach_du_toan.DataSource = m_v_ds_gd_thanh_toan.V_GD_THANH_TOAN;
        m_grv_danh_sach_du_toan.DataBind();
        m_lbl_danh_sach_thanh_toan.Text = "Danh sách Thanh toán: " + m_v_ds_gd_thanh_toan.V_GD_THANH_TOAN.Rows.Count + " thanh toán";
    }
    private void load_data_2_excel_search(decimal ip_dc_id_giang_vien
                                   , decimal ip_dc_dv_thanh_toan
                                   , decimal ip_dc_trang_thai_tt
                                   , string ip_str_reference_code
                                   , decimal ip_dc_thang_tt
                                   , decimal ip_dc_nam_tt
                                   , string ip_str_ma_dot_thanh_toan)
    {
        //string v_str_ma_dot_tt = "";
        //if (ip_dc_id_dot_tt == 0) v_str_ma_dot_tt = "All";
        //else v_str_ma_dot_tt = get_ma_dot_tt_by_id_dot(CIPConvert.ToDecimal(m_cbo_dot_thanh_toan.SelectedValue));
        m_v_ds_gd_thanh_toan.Clear();
        if (m_rdl_loai_hop_dong.Items[0].Selected)
        // All
        {
            m_str_loai_hd = "All";
        }
        else if (m_rdl_loai_hop_dong.Items[1].Selected)
        // Vận hành
        {
            m_str_loai_hd = "VH";
        }
        // Học liệu
        else m_str_loai_hd = "HL";
        m_us_v_gd_thanh_toan.fill_dataset_by_id_giang_vien_thang_nam_dot_va_dv_thanh_toan(ip_dc_id_giang_vien,
                                                                         ip_dc_dv_thanh_toan,
                                                                         ip_dc_trang_thai_tt,
                                                                         ip_str_reference_code,
                                                                         m_str_loai_hd,
                                                                         ip_dc_thang_tt,
                                                                         ip_dc_nam_tt,
                                                                         ip_str_ma_dot_thanh_toan,
                                                                         m_v_ds_gd_thanh_toan);
    }
    private void load_data_2_cbo_don_vi_thanh_toan()
    {
        DS_DM_DON_VI_THANH_TOAN v_ds_don_vi_thanh_toan = new DS_DM_DON_VI_THANH_TOAN();
        US_DM_DON_VI_THANH_TOAN v_us_don_vi_thanh_toan = new US_DM_DON_VI_THANH_TOAN();

        DataRow v_dr_none = v_ds_don_vi_thanh_toan.DM_DON_VI_THANH_TOAN.NewDM_DON_VI_THANH_TOANRow();
        v_dr_none[DM_DON_VI_THANH_TOAN.ID] = "0";
        v_dr_none[DM_DON_VI_THANH_TOAN.MA_DON_VI] = "All";
        v_dr_none[DM_DON_VI_THANH_TOAN.TEN_DON_VI] = "Tất cả";
        v_ds_don_vi_thanh_toan.DM_DON_VI_THANH_TOAN.Rows.InsertAt(v_dr_none, 0);

        v_us_don_vi_thanh_toan.FillDataset(v_ds_don_vi_thanh_toan);
        m_cbo_don_vi_thanh_toan.DataTextField = DM_DON_VI_THANH_TOAN.TEN_DON_VI;
        m_cbo_don_vi_thanh_toan.DataValueField = DM_DON_VI_THANH_TOAN.ID;
        m_cbo_don_vi_thanh_toan.DataSource = v_ds_don_vi_thanh_toan.DM_DON_VI_THANH_TOAN;
        m_cbo_don_vi_thanh_toan.DataBind();
    }
    private void load_data_2_nam_bd_hop_tac()
    {
        m_cbo_nam_thanh_toan.Items.Add(new ListItem("Tất cả", CIPConvert.ToStr(0)));
        for (int v_i = 2008; v_i < 2051; v_i++)
        {
            m_cbo_nam_thanh_toan.Items.Add(new ListItem(v_i.ToString(), v_i.ToString()));
        }
    }
    private void load_data_2_cbo_giang_vien()
    {
        US_V_DM_GIANG_VIEN v_us_giang_vien = new US_V_DM_GIANG_VIEN();
        DS_V_DM_GIANG_VIEN v_ds_giang_vien = new DS_V_DM_GIANG_VIEN();
        v_us_giang_vien.FillDataset(v_ds_giang_vien, " ORDER BY HO_VA_TEN_DEM");
        // Add thêm tất cả vào cbo
        m_cbo_ten_giang_vien.Items.Add(new ListItem("Tất cả", CIPConvert.ToStr(0)));
        for (int v_i = 0; v_i < v_ds_giang_vien.V_DM_GIANG_VIEN.Rows.Count; v_i++)
        {
            m_cbo_ten_giang_vien.Items.Add(new ListItem(v_ds_giang_vien.V_DM_GIANG_VIEN.Rows[v_i][V_DM_GIANG_VIEN.HO_VA_TEN_DEM].ToString().TrimEnd() + " " + v_ds_giang_vien.V_DM_GIANG_VIEN.Rows[v_i][V_DM_GIANG_VIEN.TEN_GIANG_VIEN].ToString(), v_ds_giang_vien.V_DM_GIANG_VIEN.Rows[v_i][V_DM_GIANG_VIEN.ID].ToString()));
        }
    }
    private void load_data_2_cbo_trang_thai_thanh_toan()
    {
        DS_CM_DM_TU_DIEN v_ds_trang_thai_thanh_toan = new DS_CM_DM_TU_DIEN();
        US_CM_DM_TU_DIEN v_us_trang_thai_thanh_toan = new US_CM_DM_TU_DIEN();

        DataRow v_dr_none = v_ds_trang_thai_thanh_toan.CM_DM_TU_DIEN.NewCM_DM_TU_DIENRow();
        v_ds_trang_thai_thanh_toan.EnforceConstraints = false;
        v_dr_none[CM_DM_TU_DIEN.ID] = "0";
        v_dr_none[CM_DM_TU_DIEN.MA_TU_DIEN] = "All";
        v_dr_none[CM_DM_TU_DIEN.TEN] = "Tất cả";
        v_ds_trang_thai_thanh_toan.CM_DM_TU_DIEN.Rows.InsertAt(v_dr_none, 0);

        v_us_trang_thai_thanh_toan.FillDataset(v_ds_trang_thai_thanh_toan, " WHERE ID_LOAI_TU_DIEN = 15");
        m_cbo_trang_thai_thanh_toan.DataTextField = CM_DM_TU_DIEN.TEN;
        m_cbo_trang_thai_thanh_toan.DataValueField = CM_DM_TU_DIEN.ID;
        m_cbo_trang_thai_thanh_toan.DataSource = v_ds_trang_thai_thanh_toan.CM_DM_TU_DIEN;
        m_cbo_trang_thai_thanh_toan.DataBind();
    }
    private void load_data_2_cbo_dot_thanh_toan(decimal ip_dc_giang_vien,decimal ip_dc_thang_tt, decimal ip_dc_nam_tt, decimal ip_dc_id_don_vi_tt)
    {
        DS_V_DM_DOT_THANH_TOAN v_ds_dot_thanh_toan = new DS_V_DM_DOT_THANH_TOAN();
        US_V_DM_DOT_THANH_TOAN v_us_dot_thanh_toan = new US_V_DM_DOT_THANH_TOAN();
        // Load đợt thanh toán dựa vào tháng và năm thanh toán
        v_us_dot_thanh_toan.load_data_2_dot_tt_by_thang_nam_and_giang_vien(ip_dc_giang_vien,ip_dc_thang_tt, ip_dc_nam_tt, ip_dc_id_don_vi_tt, v_ds_dot_thanh_toan);
        DataRow v_dr = v_ds_dot_thanh_toan.V_DM_DOT_THANH_TOAN.NewV_DM_DOT_THANH_TOANRow();                       
        m_cbo_dot_thanh_toan.DataTextField = V_DM_DOT_THANH_TOAN.TEN_DOT_TT;
        m_cbo_dot_thanh_toan.DataValueField = V_DM_DOT_THANH_TOAN.MA_DOT_TT;
        m_cbo_dot_thanh_toan.DataSource = v_ds_dot_thanh_toan.V_DM_DOT_THANH_TOAN;
        m_cbo_dot_thanh_toan.DataBind();        
    }
    private void search_data_show_on_grid()
    {
        string v_str_loai_hd = "";
        if (m_rdl_loai_hop_dong.Items[0].Selected)
            v_str_loai_hd = "All";
        else if (m_rdl_loai_hop_dong.Items[1].Selected)
            v_str_loai_hd = "VH";
        else v_str_loai_hd = "HL";
        // if (ip_dc_id_dot_tt == 0) load_data_2_grid_search("All", v_str_loai_hd);
        load_data_2_grid_search(CIPConvert.ToDecimal(m_cbo_ten_giang_vien.SelectedValue),
                                CIPConvert.ToDecimal(m_cbo_don_vi_thanh_toan.SelectedValue),
                                CIPConvert.ToDecimal(m_cbo_trang_thai_thanh_toan.SelectedValue),
                                v_str_loai_hd,
                                m_txt_reference_code.Text.Trim(),
                                CIPConvert.ToDecimal(m_cbo_thang_thanh_toan.SelectedValue),
                                CIPConvert.ToDecimal(m_cbo_nam_thanh_toan.SelectedValue),
                                m_cbo_dot_thanh_toan.SelectedValue);
    }
    private decimal get_id_giang_vien_by_ma(string ip_str_ma_gv)
    {
        US_V_DM_GIANG_VIEN v_us_dm_gv = new US_V_DM_GIANG_VIEN();
        DS_V_DM_GIANG_VIEN v_ds_dm_gv = new DS_V_DM_GIANG_VIEN();
        v_us_dm_gv.FillDataset(v_ds_dm_gv, " WHERE MA_GIANG_VIEN = N'" + ip_str_ma_gv + "'");
        return CIPConvert.ToDecimal(v_ds_dm_gv.V_DM_GIANG_VIEN.Rows[0][V_DM_GIANG_VIEN.ID]);
    }
    private string mapping_loai_hop_dong()
    {
        if (m_rdl_loai_hop_dong.Items[0].Selected) return "Tất cả";
        if (m_rdl_loai_hop_dong.Items[1].Selected) return "Vận hành";
        return "Học liệu";
    }
    #endregion

    #region Export Excel
    private void loadDSExprort(ref string strTable)
    {
        int v_i_so_thu_tu = 0;
        // Mỗi cột dữ liệu ứng với từng dòng là label
        foreach (DataRow grv in this.m_v_ds_gd_thanh_toan.V_GD_THANH_TOAN.Rows)
        {
            strTable += "\n<tr>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + ++v_i_so_thu_tu + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + CIPConvert.ToStr(grv[V_GD_THANH_TOAN.SO_PHIEU_THANH_TOAN]) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + CIPConvert.ToStr(grv[V_GD_THANH_TOAN.NGAY_THANH_TOAN], "dd/MM/yyyy") + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_don_vi_quan_ly(CIPConvert.ToDecimal(grv[V_GD_THANH_TOAN.ID_DON_VI_QUAN_LY])) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + CIPConvert.ToStr(grv[V_GD_THANH_TOAN.SO_HOP_DONG]).Trim() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_loai_hop_dong_gv(CIPConvert.ToDecimal(grv[V_GD_THANH_TOAN.ID_HOP_DONG_KHUNG])) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_time_to_str(grv[V_GD_THANH_TOAN.THOI_GIAN]) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + "'" + mapping_string(grv[V_GD_THANH_TOAN.SO_TAI_KHOAN]) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_string(grv[V_GD_THANH_TOAN.TEN_NGAN_HANG]) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + "'" + mapping_string(grv[V_GD_THANH_TOAN.MA_SO_THUE]) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_so_tien(grv[V_GD_THANH_TOAN.GIA_TRI_HOP_DONG]) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_item_field_nghiem_thu_lop_mon(CIPConvert.ToStr(grv[V_GD_THANH_TOAN.LOAI_HOP_DONG]), grv[V_GD_THANH_TOAN.REFERENCE_CODE], grv[V_GD_THANH_TOAN.GIA_TRI_NGHIEM_THU_THUC_TE]) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_item_field_ten_cac_mon(CIPConvert.ToStr(grv[V_GD_THANH_TOAN.LOAI_HOP_DONG]), grv[V_GD_THANH_TOAN.GHI_CHU_CAC_MON_PHU_TRACH]) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_so_tien(grv[V_GD_THANH_TOAN.DA_THANH_TOAN]) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_so_tien(grv[V_GD_THANH_TOAN.TONG_TIEN_THANH_TOAN]) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_so_tien_con_phai_tt(grv[V_GD_THANH_TOAN.CON_PHAI_THANH_TOAN], grv[V_GD_THANH_TOAN.LOAI_HOP_DONG], grv[V_GD_THANH_TOAN.REFERENCE_CODE]) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_string(grv[V_GD_THANH_TOAN.PO_LAP_THANH_TOAN]) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_string(grv[V_GD_THANH_TOAN.DESCRIPTION]) + "</td>";
            strTable += "\n</tr>";
        }

        strTable += "\n<tr>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'></td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'></td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'></td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'></td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'></td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'></td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'></td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'></td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'></td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'></td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'></td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'></td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'></td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Tổng tiền: </td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>" + string.Format("{0:N0}", get_tong_tien_dot_TT()) + "</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Thuế: </td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>" + string.Format("{0:N0}", (get_tong_tien_dot_TT() > 1000000) ? double.Parse(CIPConvert.ToStr(get_tong_tien_dot_TT())) * 0.1 : 0) + "</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'></td>";
        strTable += "\n</tr>";
    }

    private void loadTieuDe(ref string strTable)
    {
        load_data_2_excel_search(CIPConvert.ToDecimal(m_cbo_ten_giang_vien.SelectedValue)
                    , CIPConvert.ToDecimal(m_cbo_don_vi_thanh_toan.SelectedValue)
                    , CIPConvert.ToDecimal(m_cbo_trang_thai_thanh_toan.SelectedValue)
                    , m_txt_reference_code.Text.Trim()
                    , CIPConvert.ToDecimal(m_cbo_thang_thanh_toan.SelectedValue)
                    , CIPConvert.ToDecimal(m_cbo_nam_thanh_toan.SelectedValue)
                    , m_cbo_dot_thanh_toan.SelectedValue);
        strTable += "<table cellpadding='2' cellspacing='0' class='cssTableReport'>";
        strTable += "\n<tr>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width: 100%;  height: 40px; font-size: large; color:White; background-color:#810C15;' nowrap='wrap'>TRM702 - BÁO CÁO LỊCH SỬ THANH TOÁN CỦA GIẢNG VIÊN THEO ĐỢT" + "</td>";
        strTable += "\n</tr>";
        //
        strTable += "\n<tr>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'> Mã giảng viên: " + mapping_magv_by_id(CIPConvert.ToDecimal(m_cbo_ten_giang_vien.SelectedValue)) + "</td>";
        strTable += "\n</tr>";
        //
        strTable += "\n<tr>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>Tên giảng viên: " + m_cbo_ten_giang_vien.SelectedItem.Text + "</td>";
        strTable += "\n</tr>";
        //
        strTable += "\n<tr>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>Đơn vị thanh toán: " + m_cbo_don_vi_thanh_toan.SelectedItem.Text + "</td>";
        strTable += "\n</tr>";
        //
        strTable += "\n<tr>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>Loại hợp đồng: " + mapping_loai_hop_dong() + "</td>";
        strTable += "\n</tr>";
        strTable += "\n</table>";
        //table noi dung
        strTable += "<table cellpadding='2' cellspacing='0' class='cssTableReport'>";
        strTable += "\n<tr>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>STT</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Mã đợt thanh toán</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Ngày thanh toán</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Đơn vị quản lý HĐ</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Số HĐ</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Loại hợp đồng</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Thời gian thực hiện</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Số tài khoản</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Tên ngân hàng</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Mã số thuế</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Tổng giá trị HĐ (VNĐ)</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>" + mapping_header_nghiem_thu_lop_mon(m_str_loai_hd) + "</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Tên các môn phụ trách</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Đã thanh toán (VNĐ)</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Tổng tiền thanh toán đợt này (VNĐ)</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Số tiền còn phải thanh toán (VNĐ)</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>PO lập thanh toán</td>";
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
    protected void m_cmd_tim_kiem_Click(object sender, EventArgs e)
    {
        try
        {
            search_data_show_on_grid();
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
            string strNamFile = "BaoCaoDSThanhToanTheoGiangVienVaDotThanhToan" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + ".xls";
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
    protected void m_grv_danh_sach_du_toan_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            m_grv_danh_sach_du_toan.PageIndex = e.NewPageIndex;
            search_data_show_on_grid();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_ten_giang_vien_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            m_lbl_ma_gv.Text = mapping_magv_by_id(CIPConvert.ToDecimal(m_cbo_ten_giang_vien.SelectedValue));
            search_data_show_on_grid();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_don_vi_thanh_toan_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            load_data_2_cbo_dot_thanh_toan(CIPConvert.ToDecimal(m_cbo_ten_giang_vien.SelectedValue) ,CIPConvert.ToDecimal(m_cbo_thang_thanh_toan.SelectedValue), CIPConvert.ToDecimal(m_cbo_nam_thanh_toan.SelectedValue), CIPConvert.ToDecimal(m_cbo_don_vi_thanh_toan.SelectedValue));
            search_data_show_on_grid();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_trang_thai_thanh_toan_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            search_data_show_on_grid();
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
            load_data_2_cbo_dot_thanh_toan(CIPConvert.ToDecimal(m_cbo_ten_giang_vien.SelectedValue), CIPConvert.ToDecimal(m_cbo_thang_thanh_toan.SelectedValue), CIPConvert.ToDecimal(m_cbo_nam_thanh_toan.SelectedValue), CIPConvert.ToDecimal(m_cbo_don_vi_thanh_toan.SelectedValue));
            search_data_show_on_grid();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_nam_thanh_toan_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            load_data_2_cbo_dot_thanh_toan(CIPConvert.ToDecimal(m_cbo_ten_giang_vien.SelectedValue), CIPConvert.ToDecimal(m_cbo_thang_thanh_toan.SelectedValue), CIPConvert.ToDecimal(m_cbo_nam_thanh_toan.SelectedValue), CIPConvert.ToDecimal(m_cbo_don_vi_thanh_toan.SelectedValue));
            search_data_show_on_grid();
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
            search_data_show_on_grid();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    #endregion    
}