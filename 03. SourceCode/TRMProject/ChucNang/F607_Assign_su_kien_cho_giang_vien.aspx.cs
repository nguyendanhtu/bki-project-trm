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

public partial class ChucNang_F607_Assign_su_kien_cho_giang_vien : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            load_data_2_grv();
            load_data_2_cbo_loai_su_kien();
            load_2_cbo_giang_vien();
            load_2_cbo_vai_tro_giang_vien();
            load_2_cbo_trang_thai_sk();
            load_2_cbo_su_kien();
            load_2_cbo_so_hop_dong();
            m_cbo_trang_thai_sk.Enabled = false;
        }
    }

    #region Members
    //US_GD_ASSIGN_SU_KIEN_GIANG_VIEN m_us_su_kien_gv = new US_GD_ASSIGN_SU_KIEN_GIANG_VIEN();
    //DS_GD_ASSIGN_SU_KIEN_GIANG_VIEN m_ds_su_kien_gv = new DS_GD_ASSIGN_SU_KIEN_GIANG_VIEN();
    US_DM_SU_KIEN m_us_dm_su_kien = new US_DM_SU_KIEN();
    DS_DM_SU_KIEN m_ds_dm_su_kien = new DS_DM_SU_KIEN();
    US_V_GD_ASSIGN_SU_KIEN_GIANG_VIEN m_us_v_gd_assign_su_kien_giang_vien = new US_V_GD_ASSIGN_SU_KIEN_GIANG_VIEN();
    DS_V_GD_ASSIGN_SU_KIEN_GIANG_VIEN m_ds_v_gd_assign_su_kien_giang_vien = new DS_V_GD_ASSIGN_SU_KIEN_GIANG_VIEN();
    #endregion

    #region Public Methods
    public string mapping_ten_su_kien_by_id(object ip_obj_id_su_kien)
    {
        US_DM_SU_KIEN v_us_dm_su_kien = new US_DM_SU_KIEN(CIPConvert.ToDecimal(ip_obj_id_su_kien));
        return v_us_dm_su_kien.strTEN_SU_KIEN;
    }
    //public string mapping_so_hop_dong_by_id(object ip_obj_id_hop_dong)
    //{
    //    US_DM_HOP_DONG_KHUNG v_us_hop_dong_khung = new US_DM_HOP_DONG_KHUNG(CIPConvert.ToDecimal(ip_obj_id_hop_dong));
    //    return v_us_hop_dong_khung.strSO_HOP_DONG;
    //}
    public string mapping_vai_tro_giang_vien_by_id(object ip_obj_vai_tro_giang_vien)
    {
        US_CM_DM_TU_DIEN v_us_tu_dien = new US_CM_DM_TU_DIEN(CIPConvert.ToDecimal(ip_obj_vai_tro_giang_vien));
        return v_us_tu_dien.strTEN;
    }
    public string mapping_trang_thai_su_kien_giang_vien_by_id(object ip_obj_trang_thai_su_kien)
    {
        US_CM_DM_TU_DIEN v_us_tu_dien = new US_CM_DM_TU_DIEN(CIPConvert.ToDecimal(ip_obj_trang_thai_su_kien));
        return v_us_tu_dien.strTEN;
    }
    public string mapping_ten_giang_vien_by_id(object ip_obj_ten_gv)
    {
        US_V_DM_GIANG_VIEN v_us_giang_vien = new US_V_DM_GIANG_VIEN(CIPConvert.ToDecimal(ip_obj_ten_gv));
        return v_us_giang_vien.strHO_VA_TEN_DEM + " " + v_us_giang_vien.strTEN_GIANG_VIEN;
    }
    public string mapping_thanh_toan_ngay(string ip_str_thanh_toan)
    {
        if (ip_str_thanh_toan.Equals("Y"))
            return "Có";
        return "Không";
    }
    private string mapping_string(object ip_obj_string)
    {
        if (ip_obj_string.GetType() == typeof(DBNull)) return "";
        return CIPConvert.ToStr(ip_obj_string);
    }
    #endregion

    #region Private Methods
    private void load_data_2_grv()
    {
        m_us_v_gd_assign_su_kien_giang_vien.FillDataset(m_ds_v_gd_assign_su_kien_giang_vien);
        m_grv_gd_assign_su_kien_cho_giang_vien.DataSource = m_ds_v_gd_assign_su_kien_giang_vien.V_GD_ASSIGN_SU_KIEN_GIANG_VIEN;
        m_grv_gd_assign_su_kien_cho_giang_vien.DataBind();
    }
    private void load_data_2_export_excel()
    {
        m_us_v_gd_assign_su_kien_giang_vien.FillDataset(m_ds_v_gd_assign_su_kien_giang_vien);
    }
    private void load_data_2_cbo_loai_su_kien()
    {
        US_CM_DM_TU_DIEN v_us_tu_dien = new US_CM_DM_TU_DIEN();
        DS_CM_DM_TU_DIEN v_ds_tu_dien = new DS_CM_DM_TU_DIEN();

        v_us_tu_dien.FillDataset(v_ds_tu_dien, " WHERE ID_LOAI_TU_DIEN = " + (int)e_loai_tu_dien.LOAI_SU_KIEN);

        m_cbo_loai_su_kien.DataTextField = CM_DM_TU_DIEN.TEN;
        m_cbo_loai_su_kien.DataValueField = CM_DM_TU_DIEN.ID;

        m_cbo_loai_su_kien.DataSource = v_ds_tu_dien.CM_DM_TU_DIEN;
        m_cbo_loai_su_kien.DataBind();
    }
    private void load_2_cbo_giang_vien()
    {
        US_V_DM_GIANG_VIEN v_us_giang_vien = new US_V_DM_GIANG_VIEN();
        DS_V_DM_GIANG_VIEN v_ds_giang_vien = new DS_V_DM_GIANG_VIEN();
        try
        {
            v_us_giang_vien.FillDataset(v_ds_giang_vien, " ORDER BY HO_VA_TEN_DEM, TEN_GIANG_VIEN");
            for (int v_i = 0; v_i < v_ds_giang_vien.V_DM_GIANG_VIEN.Rows.Count; v_i++)
            {
                m_cbo_ten_giang_vien.Items.Add(new ListItem(v_ds_giang_vien.V_DM_GIANG_VIEN.Rows[v_i][V_DM_GIANG_VIEN.HO_VA_TEN_DEM].ToString().TrimEnd() + " " + v_ds_giang_vien.V_DM_GIANG_VIEN.Rows[v_i][V_DM_GIANG_VIEN.TEN_GIANG_VIEN].ToString(), v_ds_giang_vien.V_DM_GIANG_VIEN.Rows[v_i][V_DM_GIANG_VIEN.ID].ToString()));
            }
        }
        catch (Exception v_e)
        {

            throw v_e;
        }
    }
    private void load_2_cbo_su_kien()
    {
        US_DM_SU_KIEN v_us_su_kien = new US_DM_SU_KIEN();
        DS_DM_SU_KIEN v_ds_su_kien = new DS_DM_SU_KIEN();

        v_us_su_kien.FillDataset(v_ds_su_kien, " WHERE ID_LOAI_SU_KIEN=" + CIPConvert.ToDecimal(m_cbo_loai_su_kien.SelectedValue) +" ORDER BY ID DESC");

        m_cbo_su_kien.DataTextField = DM_SU_KIEN.TEN_SU_KIEN;
        m_cbo_su_kien.DataValueField = DM_SU_KIEN.ID;

        m_cbo_su_kien.DataSource = v_ds_su_kien.DM_SU_KIEN;
        m_cbo_su_kien.DataBind();
    }
    private void load_2_cbo_vai_tro_giang_vien()
    {
        US_CM_DM_TU_DIEN v_us_tu_dien = new US_CM_DM_TU_DIEN();
        DS_CM_DM_TU_DIEN v_ds_tu_dien = new DS_CM_DM_TU_DIEN();

        v_us_tu_dien.FillDataset(v_ds_tu_dien, " WHERE ID_LOAI_TU_DIEN = " + (int) e_loai_tu_dien.VAI_TRO_GV);

        m_cbo_vai_tro_gv.DataTextField = CM_DM_TU_DIEN.TEN;
        m_cbo_vai_tro_gv.DataValueField = CM_DM_TU_DIEN.ID;

        m_cbo_vai_tro_gv.DataSource = v_ds_tu_dien.CM_DM_TU_DIEN;
        m_cbo_vai_tro_gv.DataBind();
    }
    private void load_2_cbo_trang_thai_sk()
    {
        US_CM_DM_TU_DIEN v_us_tu_dien = new US_CM_DM_TU_DIEN();
        DS_CM_DM_TU_DIEN v_ds_tu_dien = new DS_CM_DM_TU_DIEN();

        v_us_tu_dien.FillDataset(v_ds_tu_dien, "WHERE ID_LOAI_TU_DIEN = " + (int)e_loai_tu_dien.TRANG_THAI_SU_KIEN_GV);

        m_cbo_trang_thai_sk.DataTextField = CM_DM_TU_DIEN.TEN;
        m_cbo_trang_thai_sk.DataValueField = CM_DM_TU_DIEN.ID;

        m_cbo_trang_thai_sk.DataSource = v_ds_tu_dien.CM_DM_TU_DIEN;
        m_cbo_trang_thai_sk.DataBind();
    }
    private void load_2_cbo_so_hop_dong()
    {
        US_DM_HOP_DONG_KHUNG v_us_hop_dong_khung = new US_DM_HOP_DONG_KHUNG();
        DS_DM_HOP_DONG_KHUNG v_ds_hop_dong_khung = new DS_DM_HOP_DONG_KHUNG();

        v_ds_hop_dong_khung.Clear();
        m_cbo_so_hd.Items.Clear();

        v_us_hop_dong_khung.FillDataset(v_ds_hop_dong_khung, "WHERE ID_GIANG_VIEN=" + CIPConvert.ToDecimal(m_cbo_ten_giang_vien.SelectedValue));
        m_cbo_so_hd.Items.Add(new ListItem("Không có hợp đồng", CIPConvert.ToStr(0)));
        for (int v_i = 0; v_i < v_ds_hop_dong_khung.DM_HOP_DONG_KHUNG.Rows.Count; v_i++)
        {
            m_cbo_so_hd.Items.Add(new ListItem(CIPConvert.ToStr(v_ds_hop_dong_khung.DM_HOP_DONG_KHUNG.Rows[v_i][DM_HOP_DONG_KHUNG.SO_HOP_DONG]), CIPConvert.ToStr(v_ds_hop_dong_khung.DM_HOP_DONG_KHUNG.Rows[v_i][DM_HOP_DONG_KHUNG.ID])));
        }
    }
    private void load_data_2_us_update(int ip_i_stt_row)
    {
        decimal v_dc_id_su_kien_gv = CIPConvert.ToDecimal(m_grv_gd_assign_su_kien_cho_giang_vien.DataKeys[ip_i_stt_row].Value);
        m_us_v_gd_assign_su_kien_giang_vien = new US_V_GD_ASSIGN_SU_KIEN_GIANG_VIEN(v_dc_id_su_kien_gv);
        hdf_id.Value = CIPConvert.ToStr(v_dc_id_su_kien_gv);
    }
    private decimal get_id_user_by_username(string ip_strsusername)
    {
        US_HT_NGUOI_SU_DUNG v_us_ht_nguoi_su_dung = new US_HT_NGUOI_SU_DUNG();
        DS_HT_NGUOI_SU_DUNG v_ds_ht_nguoi_su_dung = new DS_HT_NGUOI_SU_DUNG();
        v_us_ht_nguoi_su_dung.FillDataset(v_ds_ht_nguoi_su_dung, " WHERE TEN_TRUY_CAP=N'" + ip_strsusername + "'");
        return CIPConvert.ToDecimal(v_ds_ht_nguoi_su_dung.HT_NGUOI_SU_DUNG.Rows[0][HT_NGUOI_SU_DUNG.ID]);
    }

    private void form_2_us_object()
    {
        System.Globalization.CultureInfo enUS = new System.Globalization.CultureInfo("en-US");

        m_us_v_gd_assign_su_kien_giang_vien.dcID_SU_KIEN = CIPConvert.ToDecimal(m_cbo_su_kien.SelectedValue);
        m_us_v_gd_assign_su_kien_giang_vien.dcID_GIANG_VIEN = CIPConvert.ToDecimal(m_cbo_ten_giang_vien.SelectedValue);
        m_us_v_gd_assign_su_kien_giang_vien.dcID_VAI_TRO_GV = CIPConvert.ToDecimal(m_cbo_vai_tro_gv.SelectedValue);
        m_us_v_gd_assign_su_kien_giang_vien.dcID_HOP_DONG = CIPConvert.ToDecimal(m_cbo_so_hd.SelectedValue);
        m_us_v_gd_assign_su_kien_giang_vien.strTHANH_TOAN_NGAY_YN = m_rdl_thanh_toan_ngay.Items[0].Selected ? "Y" : "N";
        m_us_v_gd_assign_su_kien_giang_vien.dcID_TRANG_THAI = CIPConvert.ToDecimal(m_cbo_trang_thai_sk.SelectedValue);
        if (m_txt_so_tien_gv_huong.Text != "")
        {
            m_us_v_gd_assign_su_kien_giang_vien.dcSO_TIEN_GV_HUONG = CIPConvert.ToDecimal(m_txt_so_tien_gv_huong.Text);
        }
        else m_us_v_gd_assign_su_kien_giang_vien.dcSO_TIEN_GV_HUONG = 0;
        if (m_txt_ghi_chu.Text != "")
        {
            m_us_v_gd_assign_su_kien_giang_vien.strGHI_CHU = m_txt_ghi_chu.Text.Trim();
        }
        m_us_v_gd_assign_su_kien_giang_vien.dcID_USER_LAP = get_id_user_by_username(CIPConvert.ToStr(Session["Username"]));

    }
    private void us_object_2_form(US_V_GD_ASSIGN_SU_KIEN_GIANG_VIEN ip_us_v_gd_assign_su_kien_giang_vien)
    {
        m_cbo_loai_su_kien.SelectedValue = CIPConvert.ToStr(ip_us_v_gd_assign_su_kien_giang_vien.dcID_LOAI_SU_KIEN);
        m_cbo_su_kien.SelectedValue = CIPConvert.ToStr(ip_us_v_gd_assign_su_kien_giang_vien.dcID_SU_KIEN);
        m_cbo_ten_giang_vien.SelectedValue = CIPConvert.ToStr(ip_us_v_gd_assign_su_kien_giang_vien.dcID_GIANG_VIEN);
        m_txt_so_tien_gv_huong.Text = CIPConvert.ToStr(ip_us_v_gd_assign_su_kien_giang_vien.dcSO_TIEN_GV_HUONG, "#,###");
        m_cbo_vai_tro_gv.SelectedValue = CIPConvert.ToStr(ip_us_v_gd_assign_su_kien_giang_vien.dcID_VAI_TRO_GV);
        m_cbo_so_hd.SelectedValue = CIPConvert.ToStr(ip_us_v_gd_assign_su_kien_giang_vien.dcID_HOP_DONG);
        m_cbo_trang_thai_sk.SelectedValue = CIPConvert.ToStr(ip_us_v_gd_assign_su_kien_giang_vien.dcID_TRANG_THAI);
        m_txt_ghi_chu.Text = ip_us_v_gd_assign_su_kien_giang_vien.strGHI_CHU;
        if (ip_us_v_gd_assign_su_kien_giang_vien.strTHANH_TOAN_NGAY_YN.Equals("Y")) m_rdl_thanh_toan_ngay.Items[0].Selected = true;
        else m_rdl_thanh_toan_ngay.Items[1].Selected = true;
    }
    private void clear_form()
    {
        m_txt_ghi_chu.Text = "";
        m_txt_so_tien_gv_huong.Text = "";
        m_txt_tu_khoa.Text = "";
        m_cbo_so_hd.SelectedIndex = 0;
        m_cbo_su_kien.SelectedIndex = 0;
        m_cbo_loai_su_kien.SelectedIndex = 0;
        m_lbl_mess.Text = "";
        m_lbl_ds_gv_sk.Text = "";
        m_rdl_thanh_toan_ngay.Items[0].Selected = true;
    }
    private void search_su_kien_gv_and_load_2_grv()
    {
        // Thu thập dữ liệu từ form tìm kiếm


        decimal v_dc_id_su_kien = CIPConvert.ToDecimal(m_cbo_su_kien.SelectedValue);
        decimal v_dc_id_giang_vien = CIPConvert.ToDecimal(m_cbo_ten_giang_vien.SelectedValue);
        decimal v_dc_id_vai_tro_gv = CIPConvert.ToDecimal(m_cbo_vai_tro_gv.SelectedValue);
        decimal v_dc_id_hop_dong = CIPConvert.ToDecimal(m_cbo_so_hd.SelectedValue);
        decimal v_dc_id_trang_thai = CIPConvert.ToDecimal(m_cbo_trang_thai_sk.SelectedValue);
        string v_str_thanh_toan_ngay_yn = m_rdl_thanh_toan_ngay.Items[0].Selected ? "Y" : "N";
        string v_str_tu_khoa = m_txt_tu_khoa.Text.Trim();
        // Search
        m_us_v_gd_assign_su_kien_giang_vien.loc_du_lieu_assign_su_kien_giang_vien(m_ds_v_gd_assign_su_kien_giang_vien
            , v_dc_id_su_kien
            , v_dc_id_giang_vien
            , v_dc_id_vai_tro_gv
            , v_dc_id_hop_dong
            , v_dc_id_trang_thai
            , v_str_thanh_toan_ngay_yn
            , v_str_tu_khoa);
        m_grv_gd_assign_su_kien_cho_giang_vien.DataSource = m_ds_v_gd_assign_su_kien_giang_vien.V_GD_ASSIGN_SU_KIEN_GIANG_VIEN;
        m_grv_gd_assign_su_kien_cho_giang_vien.DataBind();
        m_lbl_ket_qua_loc_du_lieu.Text = "Kết quả lọc dữ liệu: Có " + m_ds_v_gd_assign_su_kien_giang_vien.V_GD_ASSIGN_SU_KIEN_GIANG_VIEN.Rows.Count + " bản ghi phù hợp.";
        if (m_ds_v_gd_assign_su_kien_giang_vien.V_GD_ASSIGN_SU_KIEN_GIANG_VIEN.Rows.Count == 0)
        {
            m_lbl_ket_qua_loc_du_lieu.Text = "Kết quả lọc dữ liệu: Không có bản ghi nào phù hợp";

        }

    }
    #endregion
   
    #region Export Excel
    private void loadDSExprort(ref string strTable)
    {
        int v_i_so_thu_tu = 0;
        load_data_2_export_excel();
        // Mỗi cột dữ liệu ứng với từng dòng là label
        foreach (DataRow grv in this.m_ds_v_gd_assign_su_kien_giang_vien.V_GD_ASSIGN_SU_KIEN_GIANG_VIEN.Rows)
        {
            strTable += "\n<tr>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + ++v_i_so_thu_tu + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_ten_su_kien_by_id(grv[V_GD_ASSIGN_SU_KIEN_GIANG_VIEN.ID_SU_KIEN]) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + CIPConvert.ToStr(grv[V_GD_ASSIGN_SU_KIEN_GIANG_VIEN.HO_VA_TEN_GIANG_VIEN]).Trim() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + CIPConvert.ToStr(grv[V_GD_ASSIGN_SU_KIEN_GIANG_VIEN.SO_TIEN_GV_HUONG]).Trim() + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_vai_tro_giang_vien_by_id(grv[V_GD_ASSIGN_SU_KIEN_GIANG_VIEN.ID_VAI_TRO_GV]) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + CIPConvert.ToStr(grv[V_GD_ASSIGN_SU_KIEN_GIANG_VIEN.SO_HOP_DONG]).Trim() + "</td>"; // Số hợp đồng
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_thanh_toan_ngay(CIPConvert.ToStr(grv[V_GD_ASSIGN_SU_KIEN_GIANG_VIEN.THANH_TOAN_NGAY_YN])) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_trang_thai_su_kien_giang_vien_by_id(grv[V_GD_ASSIGN_SU_KIEN_GIANG_VIEN.ID_TRANG_THAI]) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_string(grv[V_GD_ASSIGN_SU_KIEN_GIANG_VIEN.GHI_CHU]).Trim() + "</td>";
            strTable += "\n</tr>";
        }
    }

    private void loadTieuDe(ref string strTable)
    {
        strTable += "<table cellpadding='2' cellspacing='0' class='cssTableReport'>";
        strTable += "\n<tr>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width: 100%;  height: 40px; font-size: large; color:White; background-color:#810C15;' nowrap='wrap'>BẢNG ASSIGN SỰ KIỆN GIẢNG VIÊN" + "</td>";
        strTable += "\n</tr>";
        strTable += "\n<tr>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";

        strTable += "\n</tr>";
        //
        strTable += "\n</table>";

        //table noi dung
        strTable += "<table cellpadding='2' cellspacing='0' class='cssTableReport'>";
        strTable += "\n<tr>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>STT</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Sự kiện</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Giảng viên</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Số tiền hưởng</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Vai trò gv</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Số HĐ</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Thanh toán ngay</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Trạng thái</td>";
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
    protected void m_cbo_ten_giang_vien_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            load_2_cbo_so_hop_dong();
        }
        catch (Exception v_e)
        {
            this.Response.Write(v_e.ToString());
        }
    }
    protected void m_cbo_su_kien_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void m_cbo_loai_su_kien_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            load_2_cbo_su_kien();
        }
        catch (Exception v_e)
        {
            this.Response.Write(v_e.ToString());
        }
    }
    protected void m_grv_gd_assign_su_kien_cho_giang_vien_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            load_data_2_us_update(e.RowIndex);
            us_object_2_form(m_us_v_gd_assign_su_kien_giang_vien);
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
            form_2_us_object();
            m_us_v_gd_assign_su_kien_giang_vien.Insert();
            m_lbl_mess.Text = "Lưu dữ liệu thành công!";
            load_data_2_grv();
            clear_form();
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
            if (hdf_id.Value.Trim().Equals(""))
            {
                m_lbl_mess.Visible = true;
                m_lbl_mess.Text = "Bạn chưa chọn 1 dòng để cập nhật!";
                return;
            }
            form_2_us_object();
            m_us_v_gd_assign_su_kien_giang_vien.dcID = CIPConvert.ToDecimal(hdf_id.Value);
            m_us_v_gd_assign_su_kien_giang_vien.Update();
            hdf_id.Value = "";
            load_data_2_grv();
            clear_form();
            m_lbl_mess.Text = " * Cập nhật thành công !";

        }
        catch (Exception v_e)
        {

            CSystemLog_301.ExceptionHandle(this, v_e);
        }


    }
    protected void m_grv_gd_assign_su_kien_cho_giang_vien_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            decimal v_dc_id_noi_dung_tt = CIPConvert.ToDecimal(m_grv_gd_assign_su_kien_cho_giang_vien.DataKeys[e.RowIndex].Value);
            m_us_v_gd_assign_su_kien_giang_vien.DeleteByID(v_dc_id_noi_dung_tt);
            load_data_2_grv();
            m_lbl_mess.Text = "Bạn đã xóa dữ liệu thành công!";
        }
        catch (Exception v_e)
        {

            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cmd_loc_du_lieu_Click(object sender, EventArgs e)
    {
        search_su_kien_gv_and_load_2_grv();
    }
    protected void m_cmd_xuat_excel_Click(object sender, EventArgs e)
    {
        try
        {
            string html = loadExport();
            string strNamFile = "Assign Su kien giang vien" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + ".xls";
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
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        clear_form();
    }
    #endregion
    
}