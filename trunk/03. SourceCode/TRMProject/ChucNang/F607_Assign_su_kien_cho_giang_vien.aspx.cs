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
        }
    }

    #region Members
    US_GD_ASSIGN_SU_KIEN_GIANG_VIEN m_us_su_kien_gv = new US_GD_ASSIGN_SU_KIEN_GIANG_VIEN();
    DS_GD_ASSIGN_SU_KIEN_GIANG_VIEN m_ds_su_kien_gv = new DS_GD_ASSIGN_SU_KIEN_GIANG_VIEN();
    #endregion

    private void load_data_2_grv()
    {
        m_us_su_kien_gv.FillDataset(m_ds_su_kien_gv);
        m_grv_gd_assign_su_kien_cho_giang_vien.DataSource = m_ds_su_kien_gv.GD_ASSIGN_SU_KIEN_GIANG_VIEN;
        m_grv_gd_assign_su_kien_cho_giang_vien.DataBind();
    }
    private void load_data_2_cbo_loai_su_kien()
    {
        US_CM_DM_TU_DIEN v_us_tu_dien = new US_CM_DM_TU_DIEN();
        DS_CM_DM_TU_DIEN v_ds_tu_dien = new DS_CM_DM_TU_DIEN();

        v_us_tu_dien.FillDataset(v_ds_tu_dien, " WHERE ID_LOAI_TU_DIEN=19");

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

        v_us_su_kien.FillDataset(v_ds_su_kien, " WHERE ID_LOAI_SU_KIEN=" + CIPConvert.ToDecimal(m_cbo_loai_su_kien.SelectedValue));

        m_cbo_su_kien.DataTextField = DM_SU_KIEN.TEN_SU_KIEN;
        m_cbo_su_kien.DataValueField = DM_SU_KIEN.ID;

        m_cbo_su_kien.DataSource = v_ds_su_kien.DM_SU_KIEN;
        m_cbo_su_kien.DataBind();
    }
    private void load_2_cbo_vai_tro_giang_vien()
    {
        US_CM_DM_TU_DIEN v_us_tu_dien = new US_CM_DM_TU_DIEN();
        DS_CM_DM_TU_DIEN v_ds_tu_dien = new DS_CM_DM_TU_DIEN();

        v_us_tu_dien.FillDataset(v_ds_tu_dien, " WHERE ID_LOAI_TU_DIEN=18");

        m_cbo_vai_tro_gv.DataTextField = CM_DM_TU_DIEN.TEN;
        m_cbo_vai_tro_gv.DataValueField = CM_DM_TU_DIEN.ID;

        m_cbo_vai_tro_gv.DataSource = v_ds_tu_dien.CM_DM_TU_DIEN;
        m_cbo_vai_tro_gv.DataBind();
    }
    private void load_2_cbo_trang_thai_sk()
    {
        US_CM_DM_TU_DIEN v_us_tu_dien = new US_CM_DM_TU_DIEN();
        DS_CM_DM_TU_DIEN v_ds_tu_dien = new DS_CM_DM_TU_DIEN();

        v_us_tu_dien.FillDataset(v_ds_tu_dien, "WHERE ID_LOAI_TU_DIEN=22");

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
        m_txt_ghi_chu.ToolTip = CIPConvert.ToStr(v_dc_id_su_kien_gv);
        m_us_su_kien_gv = new US_GD_ASSIGN_SU_KIEN_GIANG_VIEN(v_dc_id_su_kien_gv);
    }

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

    #region Public Methods
    public string mapping_ten_su_kien_by_id(object ip_obj_id_su_kien)
    {
        US_DM_SU_KIEN v_us_dm_su_kien = new US_DM_SU_KIEN(CIPConvert.ToDecimal(ip_obj_id_su_kien));
        return v_us_dm_su_kien.strTEN_SU_KIEN;
    }
    public string mapping_so_hop_dong_by_id(object ip_obj_id_hop_dong)
    {
        US_DM_HOP_DONG_KHUNG v_us_hop_dong_khung = new US_DM_HOP_DONG_KHUNG(CIPConvert.ToDecimal(ip_obj_id_hop_dong));
        return v_us_hop_dong_khung.strSO_HOP_DONG;
    }
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
    #endregion

    protected void m_grv_gd_assign_su_kien_cho_giang_vien_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        load_data_2_us_update(e.RowIndex);
    }
}