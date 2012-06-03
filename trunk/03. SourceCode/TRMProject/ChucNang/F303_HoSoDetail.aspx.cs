using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IP.Core.IPUserService;
using IP.Core.IPData;
using IP.Core.IPCommon;
using WebUS;
using WebDS;
using WebDS.CDBNames;

public partial class ChucNang_F303_HoSoDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    // load dữ liệu lên combo loại hồ  sơ
    private void load_data_2_combo_loai_ho_so()
    {
        US_CM_DM_TU_DIEN v_cm_dm_tu_dien = new US_CM_DM_TU_DIEN();
        DS_CM_DM_TU_DIEN v_ds_cm_dm_tu_dien = new DS_CM_DM_TU_DIEN();
        try
        {
            v_cm_dm_tu_dien.FillDataset(v_ds_cm_dm_tu_dien, "WHERE ID_LOAI_TU_DIEN = 24");//sẽ insert LOAI_HO_SO vào bảng CM_DM_LOAI_TU_DIEM sau

            m_cbo_loai_ho_so.DataSource = v_ds_cm_dm_tu_dien.CM_DM_TU_DIEN;

            m_cbo_loai_ho_so.DataTextField = CM_DM_TU_DIEN.TEN;
            m_cbo_loai_ho_so.DataValueField = CM_DM_TU_DIEN.ID;
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }

    }
}