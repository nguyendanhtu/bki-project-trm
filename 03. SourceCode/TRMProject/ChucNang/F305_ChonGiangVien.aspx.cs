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

public partial class ChucNang_F305_ChonGiangVien : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            load_2_cbo_don_vi_q_ly();
            load_2_cbo_trang_thai_giang_vien();
        }
    }
    #region Members
    US_V_DM_GIANG_VIEN m_us_dm_giang_vien = new US_V_DM_GIANG_VIEN();
    DS_V_DM_GIANG_VIEN m_ds_giang_vien = new DS_V_DM_GIANG_VIEN();

    US_CM_DM_TU_DIEN m_us_cm_dm_tu_dien = new US_CM_DM_TU_DIEN();
    DS_CM_DM_TU_DIEN m_ds_cm_dm_tu_dien = new DS_CM_DM_TU_DIEN();
    #endregion
 
    #region Method
     private void load_data_to_grid()
    {
        try
        {
            // Đổ dữ liệu từ US vào DS
            m_us_dm_giang_vien.FillDataset(m_ds_giang_vien);

            // Treo dữ liệu lên lưới
            m_grv_dm_danh_sach_giang_vien_to_choose.DataSource = m_ds_giang_vien.V_DM_GIANG_VIEN;
            m_grv_dm_danh_sach_giang_vien_to_choose.DataBind();
        }
        catch (Exception v_e)
        {
            throw v_e;

        }
    }

     //
     // Region for search
     //
     private void load_2_cbo_trang_thai_giang_vien()
     {
         try
         {
             DS_CM_DM_TU_DIEN v_ds_cm_tu_dien = new DS_CM_DM_TU_DIEN();
             US_CM_DM_TU_DIEN v_us_cm_tu_dien = new US_CM_DM_TU_DIEN();
             // DataRow v_dr_all = m_ds_cm_dm_tu_dien.CM_DM_TU_DIEN.NewCM_DM_TU_DIENRow();
             // Đổ dữ liệu vào DS 
             v_us_cm_tu_dien.FillDataset(v_ds_cm_tu_dien, " WHERE ID_LOAI_TU_DIEN = " + (int)e_loai_tu_dien.TRANG_THAI_GIANG_VIEN); // Đây là lấy theo điều kiện

             //m_cbo_trang_thai_g_vien.DataValueField = CM_DM_TU_DIEN.ID;
             //m_cbo_trang_thai_g_vien.DataTextField = CM_DM_TU_DIEN.TEN;

             //m_cbo_trang_thai_g_vien.DataSource = v_ds_cm_tu_dien.CM_DM_TU_DIEN;
             //m_cbo_trang_thai_g_vien.DataBind();

             m_cbo_trang_thai_g_vien.Items.Add(new ListItem("Tất cả", "0"));
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

     private void load_2_cbo_don_vi_q_ly()
     {
         try
         {
             DS_CM_DM_TU_DIEN v_ds_cm_tu_dien = new DS_CM_DM_TU_DIEN();
             US_CM_DM_TU_DIEN v_us_cm_tu_dien = new US_CM_DM_TU_DIEN();
             // Đổ dữ liệu vào DS 
             v_us_cm_tu_dien.FillDataset(v_ds_cm_tu_dien, " WHERE ID_LOAI_TU_DIEN = "
                                                 + (int)e_loai_tu_dien.DON_VI_QUAN_LY_CHINH); // Đây là lấy theo điều kiện
             m_cbo_don_vi_q_ly.Items.Add(new ListItem("Tất cả", "0"));
             for (int i = 0; i < v_ds_cm_tu_dien.CM_DM_TU_DIEN.Rows.Count; i++)
             {
                 m_cbo_don_vi_q_ly.Items.Add(new ListItem(v_ds_cm_tu_dien.CM_DM_TU_DIEN[i][CM_DM_TU_DIEN.TEN].ToString(), v_ds_cm_tu_dien.CM_DM_TU_DIEN[i][CM_DM_TU_DIEN.ID].ToString()));
             }
         }
         catch (Exception v_e)
         {
             throw v_e;
         }
     }

     private void get_form_search_data_and_load_to_grid()
     {
         try
         {
             // thu thập dữ liệu            
             string v_str_ten_giang_vien = m_txt_ten_giang_vien.Text.Trim();
             // Cắt string name
             string[] v_str_ten_gv = v_str_ten_giang_vien.Split(' ');
             string v_str_ho_va_ten_split = "";
             // Việc này là để loại bỏ các dấu cách trong từ khóa search
             for (int i = 0; i < v_str_ten_gv.Length; i++)
             {
                 v_str_ho_va_ten_split += v_str_ten_gv[i];
                 v_str_ho_va_ten_split += " ";
             }

             v_str_ho_va_ten_split = v_str_ho_va_ten_split.TrimEnd();

             string v_str_search_key_word = m_txt_tu_khoa_tim_kiem.Text.Trim();

             string v_str_gender = "";
             if (rdl_gender_check.Items[0].Selected) v_str_gender = "All";
             else if (rdl_gender_check.Items[1].Selected) v_str_gender = "Y";
             else v_str_gender = "N";

             DateTime v_dat_ngay_bd_hop_tac;
             if (m_dat_ngay_bd_hop_tac.Text != "")
                 v_dat_ngay_bd_hop_tac = m_dat_ngay_bd_hop_tac.SelectedDate;
             else v_dat_ngay_bd_hop_tac = CIPConvert.ToDatetime("01/01/1900");
             string v_str_month = m_cbo_thang_sn_GV.SelectedValue;

             decimal v_dc_id_trang_thai_giang_vien = CIPConvert.ToDecimal(m_cbo_trang_thai_g_vien.SelectedValue);
             decimal v_dc_id_don_vi_quan_ly = CIPConvert.ToDecimal(m_cbo_don_vi_q_ly.SelectedValue);


             // Thực hiện Search

             //m_us_dm_giang_vien.search_giang_vien(v_str_ho_va_ten_split
             //                                    , v_str_search_key_word
             //                                    , v_str_gender
             //                                    , v_dc_id_trang_thai_giang_vien
             //                                    , v_dc_id_don_vi_quan_ly
             //                                    , m_ds_giang_vien
             //                                    , v_dat_ngay_bd_hop_tac
             //                                    , CIPConvert.ToDecimal(v_str_month));
             m_grv_dm_danh_sach_giang_vien_to_choose.DataSource = m_ds_giang_vien.V_DM_GIANG_VIEN;
             m_grv_dm_danh_sach_giang_vien_to_choose.DataBind();
         }
         catch (Exception v_e)
         {

             throw v_e;
         }
     }
    #endregion

    #region Public Interfaces
     public string mapping_gender(string ip_str_gen)
     {
         if (ip_str_gen.Equals("Y"))
             return "Nam";
         return "Nữ";
     }
     #endregion

    //
    //Events
    //


     protected void m_cmd_loc_du_lieu_Click(object sender, EventArgs e)
     {
         try
         {
             m_grv_dm_danh_sach_giang_vien_to_choose.PageSize = 100;
             get_form_search_data_and_load_to_grid();
         }
         catch (Exception v_e)
         {
             CSystemLog_301.ExceptionHandle(this, v_e);
         }
     }
     protected void m_grv_dm_danh_sach_giang_vien_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
     {
         try
         {
             decimal v_dc_id_dm_giang_vien = CIPConvert.ToDecimal(m_grv_dm_danh_sach_giang_vien_to_choose.DataKeys[e.NewSelectedIndex].Value);
             US_V_DM_GIANG_VIEN v_us_dm_giang_vien = new US_V_DM_GIANG_VIEN(v_dc_id_dm_giang_vien);
             Session["id_giang_vien"] = v_us_dm_giang_vien.dcID;
             Session["name_giang_vien"] = v_us_dm_giang_vien.strTEN_GIANG_VIEN;
             Response.Write("<script language='javascript'>{windown.close();}</scritp>");

         }
         catch (Exception v_e)
         {
             CSystemLog_301.ExceptionHandle(this, v_e);
         }
     }
     //protected void m_grv_dm_danh_sach_giang_vien_RowDataBound(object sender, GridViewRowEventArgs e)
     //{
     //    try
     //    {
     //        if ((e.Row.RowType == DataControlRowType.DataRow))
     //        {
     //            string v_str = e.Row.Cells[1].Text;
     //            //assuming that the required value column is the second column in gridview
     //            ((LinkButton)e.Row.FindControl("lbt_choose_teacher")).Attributes.Add("onclick", "javascript:GetRowValue('"+ v_str +"')");
     //        }
     //    }
     //    catch (Exception v_e)
     //    {
     //        CSystemLog_301.ExceptionHandle(this, v_e);
     //    }
     //}
}