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
        }
    }

    // load dữ liệu lên combobox giảng viên
    private void load_data_2_combo_giang_vien()
    {
        US_V_DM_GIANG_VIEN v_dm_giang_vien = new US_V_DM_GIANG_VIEN();
        DS_V_DM_GIANG_VIEN v_ds_dm_giang_vien = new DS_V_DM_GIANG_VIEN();
        v_dm_giang_vien.FillDataset(v_ds_dm_giang_vien);

        m_cbo_giang_vien.DataTextField = V_DM_GIANG_VIEN.TEN_GIANG_VIEN;
        m_cbo_giang_vien.DataValueField = V_DM_GIANG_VIEN.ID;

        m_cbo_giang_vien.DataSource = v_ds_dm_giang_vien.V_DM_GIANG_VIEN;
        m_cbo_giang_vien.DataBind();
    }
}