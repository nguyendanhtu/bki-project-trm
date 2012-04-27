using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IP.Core.IPCommon;
using WebDS;
using WebDS.CDBNames;
using WebUS;
using System.Data;
public partial class ChucNang_F205_AdvanceSearchGiangVien : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!this.IsPostBack)
            {
                load_2_cbo_dm_mon_hoc();
            }
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    #region Data Structures
    #endregion

    #region Members
    DS_V_DM_GIANG_VIEN m_ds_dm_v_giang_vien = new DS_V_DM_GIANG_VIEN();
    US_V_DM_GIANG_VIEN m_us_v_dm_giang_vien = new US_V_DM_GIANG_VIEN();
    #endregion

    #region Private Methods
    private void load_2_cbo_dm_mon_hoc()
    {
        US_DM_MON_HOC v_us_dm_mon_hoc = new US_DM_MON_HOC();
        DS_DM_MON_HOC v_ds_dm_mon_hoc = new DS_DM_MON_HOC();
        try
        {
            v_us_dm_mon_hoc.FillDataset(v_ds_dm_mon_hoc);

            //add item Tat Ca
            DataRow v_dr_all = v_ds_dm_mon_hoc.DM_MON_HOC.NewDM_MON_HOCRow();
            v_dr_all[DM_MON_HOC.ID] = 0;
            v_dr_all[DM_MON_HOC.TEN_MON_HOC] = "Tất cả";
            v_ds_dm_mon_hoc.EnforceConstraints = false;
            v_ds_dm_mon_hoc.DM_MON_HOC.Rows.InsertAt(v_dr_all, 0);

            m_cbo_dm_mon_hoc.DataSource = v_ds_dm_mon_hoc.DM_MON_HOC;
            m_cbo_dm_mon_hoc.DataValueField = DM_MON_HOC.ID;
            m_cbo_dm_mon_hoc.DataTextField = DM_MON_HOC.TEN_MON_HOC;
            m_cbo_dm_mon_hoc.DataBind();
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    public string get_mapping_ten_mon_hoc(decimal i_dc_id_mon_hoc)
    {
        try
        {
            string v_str_ten_mon_hoc = "";
            US_DM_MON_HOC v_us_dm_mon_hoc = new US_DM_MON_HOC(i_dc_id_mon_hoc);
            v_str_ten_mon_hoc = v_us_dm_mon_hoc.strTEN_MON_HOC;
            return v_str_ten_mon_hoc;
        }
        catch (Exception v_e)
        {
            throw v_e;
        }

    }
    public string get_mapping_yn(string i_str_yn)
    {
        try
        {
            if (i_str_yn == "Y")
                return "Có";
            else return "Không";
        }
        catch (Exception v_e)
        {
            throw v_e;
        }

    }

    private void load_data_2_grid()
    {
        m_ds_dm_v_giang_vien = new DS_V_DM_GIANG_VIEN();
        try
        {
            decimal v_dc_so_hop_dong=0;
            string v_str_ten_ngan_hang = m_txt_ten_ngan_hang.Text.Trim();
            if(m_txt_so_hop_dong.Text != "")
                v_dc_so_hop_dong = CIPConvert.ToDecimal(m_txt_so_hop_dong.Text);
            decimal v_dc_id_mon_hoc = CIPConvert.ToDecimal(m_cbo_dm_mon_hoc.SelectedValue);

            m_us_v_dm_giang_vien.fill_data_by_search(
                            v_str_ten_ngan_hang
                            , v_dc_id_mon_hoc
                            ,v_dc_so_hop_dong
                            , m_ds_dm_v_giang_vien);
            if (m_ds_dm_v_giang_vien.V_DM_GIANG_VIEN.Rows.Count == 0)
            {
                m_lbl_thong_bao.Text = "Không có bản ghi nào phù hợp";
                if (m_grv_dm_danh_sach_giang_vien.Visible == true) m_grv_dm_danh_sach_giang_vien.Visible = false;
                return;
            }
            m_grv_dm_danh_sach_giang_vien.Visible = true;
            m_grv_dm_danh_sach_giang_vien.DataSource = m_ds_dm_v_giang_vien.V_DM_GIANG_VIEN;
            m_grv_dm_danh_sach_giang_vien.DataBind();
            m_lbl_loc_du_lieu.Text = "Kết quả lọc dữ liệu: " + m_ds_dm_v_giang_vien.V_DM_GIANG_VIEN.Rows.Count + " bản ghi";
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    #endregion
    //
    //
    // Event Hanlder
    //
    //


    protected void m_cmd_loc_du_lieu_Click(object sender, EventArgs e)
    {

        try
        {
            load_data_2_grid();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }

    protected void m_grv_dm_danh_sach_giang_vien_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            m_grv_dm_danh_sach_giang_vien.PageIndex = e.NewPageIndex;
            load_data_2_grid();
            //if (m_init_mode != DataEntryFormMode.ViewDataState)

            //else get_form_search_data_and_load_to_grid();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
   
}