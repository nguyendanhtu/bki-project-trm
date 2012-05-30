using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebUS;
using WebDS;
using WebDS.CDBNames;
using IP.Core.IPUserService;
using IP.Core.IPData;
using IP.Core.IPCommon;

public partial class DanhMuc_F106_DanhMucHoSo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            load_data_2_combo_giang_vien();
            load_data_2_combo_don_vi_thanh_toan();
            load_data_2_combo_trang_thai();
            load_data_2_combo_loc_giang_vien();
            load_data_2_combo_loc_don_vi_thanh_toan();
            load_data_2_combo_loc_don_vi_thanh_toan();
        }
    }

    // load dữ liệu lên combobox giảng viên
    private void load_data_2_combo_giang_vien()
    {
        US_V_DM_GIANG_VIEN v_us_giang_vien = new US_V_DM_GIANG_VIEN();
        DS_V_DM_GIANG_VIEN v_ds_giang_vien = new DS_V_DM_GIANG_VIEN();
        try
        {
            v_us_giang_vien.FillDataset(v_ds_giang_vien, " ORDER BY HO_VA_TEN_DEM, TEN_GIANG_VIEN");
            for (int v_i = 0; v_i < v_ds_giang_vien.V_DM_GIANG_VIEN.Rows.Count; v_i++)
            {
                m_cbo_giang_vien.Items.Add(new ListItem(v_ds_giang_vien.V_DM_GIANG_VIEN.Rows[v_i][V_DM_GIANG_VIEN.HO_VA_TEN_DEM].ToString().TrimEnd() + " " + v_ds_giang_vien.V_DM_GIANG_VIEN.Rows[v_i][V_DM_GIANG_VIEN.TEN_GIANG_VIEN].ToString(), v_ds_giang_vien.V_DM_GIANG_VIEN.Rows[v_i][V_DM_GIANG_VIEN.ID].ToString()));
            }
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }

  // load dữ liệu lên combobox đơn vị thanh toán
    private void load_data_2_combo_don_vi_thanh_toan()
    {
        US_DM_DON_VI_THANH_TOAN v_dm_don_vi_thanh_toan = new US_DM_DON_VI_THANH_TOAN();
        DS_DM_DON_VI_THANH_TOAN v_ds_dm_don_vi_thanh_toan = new DS_DM_DON_VI_THANH_TOAN();
        try
        {
            v_dm_don_vi_thanh_toan.FillDataset(v_ds_dm_don_vi_thanh_toan);

            m_cbo_don_vi_thanh_toan.DataSource = v_ds_dm_don_vi_thanh_toan.DM_DON_VI_THANH_TOAN;

            m_cbo_don_vi_thanh_toan.DataTextField = DM_DON_VI_THANH_TOAN.TEN_DON_VI;
            m_cbo_don_vi_thanh_toan.DataValueField = DM_DON_VI_THANH_TOAN.ID;

            m_cbo_don_vi_thanh_toan.DataBind();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }

   // load dữ liệu lên combo trạng thái
    private void load_data_2_combo_trang_thai()
    {
        US_CM_DM_TU_DIEN v_cm_dm_tu_dien = new US_CM_DM_TU_DIEN();
        DS_CM_DM_TU_DIEN v_ds_cm_dm_tu_dien = new DS_CM_DM_TU_DIEN();
        try
        {
            v_cm_dm_tu_dien.FillDataset(v_ds_cm_dm_tu_dien, "WHERE ID_LOAI_TU_DIEN = 23");

            m_cbo_trang_thai.DataSource = v_ds_cm_dm_tu_dien.CM_DM_TU_DIEN;

            m_cbo_trang_thai.DataTextField = CM_DM_TU_DIEN.TEN;
            m_cbo_trang_thai.DataValueField = CM_DM_TU_DIEN.ID;
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
        
    }

  // load dữ liệu lên combo lọc theo giảng viên
    private void load_data_2_combo_loc_giang_vien()
    {
        US_V_DM_GIANG_VIEN v_us_loc_giang_vien = new US_V_DM_GIANG_VIEN();
        DS_V_DM_GIANG_VIEN v_ds_loc_giang_vien = new DS_V_DM_GIANG_VIEN();
        try
        {
            v_us_loc_giang_vien.FillDataset(v_ds_loc_giang_vien, " ORDER BY HO_VA_TEN_DEM, TEN_GIANG_VIEN");
            for (int v_i = 0; v_i < v_ds_loc_giang_vien.V_DM_GIANG_VIEN.Rows.Count; v_i++)
            {
                m_cbo_loc_giang_vien.Items.Add(new ListItem(v_ds_loc_giang_vien.V_DM_GIANG_VIEN.Rows[v_i][V_DM_GIANG_VIEN.HO_VA_TEN_DEM].ToString().TrimEnd() + " " + v_ds_loc_giang_vien.V_DM_GIANG_VIEN.Rows[v_i][V_DM_GIANG_VIEN.TEN_GIANG_VIEN].ToString(), v_ds_loc_giang_vien.V_DM_GIANG_VIEN.Rows[v_i][V_DM_GIANG_VIEN.ID].ToString()));
            }
        }
        catch (Exception v_e)
        {

            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }

    // load dữ liệu lên combo lọc đơn vị thanh toán
    private void load_data_2_combo_loc_don_vi_thanh_toan()
    {
        US_DM_DON_VI_THANH_TOAN v_dm_loc_don_vi_thanh_toan = new US_DM_DON_VI_THANH_TOAN();
        DS_DM_DON_VI_THANH_TOAN v_ds_dm_loc_don_vi_thanh_toan = new DS_DM_DON_VI_THANH_TOAN();
        try
        {
            v_dm_loc_don_vi_thanh_toan.FillDataset(v_ds_dm_loc_don_vi_thanh_toan);

            m_cbo_loc_don_vi_thanh_toan.DataSource = v_ds_dm_loc_don_vi_thanh_toan.DM_DON_VI_THANH_TOAN;

            m_cbo_loc_don_vi_thanh_toan.DataTextField = DM_DON_VI_THANH_TOAN.TEN_DON_VI;
            m_cbo_loc_don_vi_thanh_toan.DataValueField = DM_DON_VI_THANH_TOAN.ID;

            m_cbo_loc_don_vi_thanh_toan.DataBind();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);        
        }
        
    }

  // load dữ liệu lên combo lọc trạng thái
    private void load_data_2_combo_loc_trang_thai()
    {
        US_CM_DM_TU_DIEN v_cm_dm_tu_dien = new US_CM_DM_TU_DIEN();
        DS_CM_DM_TU_DIEN v_ds_cm_dm_tu_dien = new DS_CM_DM_TU_DIEN();
        try
        {
            v_cm_dm_tu_dien.FillDataset(v_ds_cm_dm_tu_dien, "WHERE ID_LOAI_TU_DIEN = 23");

            m_cbo_loc_trang_thai.DataSource = v_ds_cm_dm_tu_dien.CM_DM_TU_DIEN;

            m_cbo_loc_trang_thai.DataTextField = CM_DM_TU_DIEN.TEN;
            m_cbo_loc_trang_thai.DataValueField = CM_DM_TU_DIEN.ID;
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
        
    }
}