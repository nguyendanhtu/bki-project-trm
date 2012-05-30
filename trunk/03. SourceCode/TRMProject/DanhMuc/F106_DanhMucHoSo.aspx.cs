using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebUS;
using WebDS;
using WebDS.CDBNames;

public partial class DanhMuc_F106_DanhMucHoSo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            load_data_2_combo_giang_vien();
            load_data_2_combo_don_vi_thanh_toan();
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
            //m_cbo_gvien.DataSource = v_ds_giang_vien.V_DM_GIANG_VIEN;
            //m_cbo_gvien.DataValueField = V_DM_GIANG_VIEN.ID;
            //m_cbo_gvien.DataTextField = V_DM_GIANG_VIEN.TEN_GIANG_VIEN;
            //m_cbo_gvien.DataBind();
        }
        catch (Exception v_e)
        {

            throw v_e;
        }
    }

  // load dữ liệu lên combobox đơn vị thanh toán
    private void load_data_2_combo_don_vi_thanh_toan()
    {
        US_DM_DON_VI_THANH_TOAN v_dm_don_vi_thanh_toan = new US_DM_DON_VI_THANH_TOAN();
        DS_DM_DON_VI_THANH_TOAN v_ds_dm__don_vi_thanh_toan = new DS_DM_DON_VI_THANH_TOAN();
        v_dm_don_vi_thanh_toan.FillDataset(v_ds_dm__don_vi_thanh_toan);

        m_cbo_don_vi_thanh_toan.DataSource = v_ds_dm__don_vi_thanh_toan.DM_DON_VI_THANH_TOAN;

        m_cbo_don_vi_thanh_toan.DataTextField = DM_DON_VI_THANH_TOAN.TEN_DON_VI;
        m_cbo_don_vi_thanh_toan.DataValueField = DM_DON_VI_THANH_TOAN.ID;

        m_cbo_don_vi_thanh_toan.DataBind();

        
    }
}