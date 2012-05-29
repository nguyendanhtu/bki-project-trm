using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

using IP.Core.IPCommon;
using IP.Core.IPData;
using IP.Core.IPUserService;

using WebUS;
using WebDS;
using WebDS.CDBNames;
using System.Data;

public partial class DanhMuc_F105_SuKien : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        m_lbl_mess.Text = "";
        if (m_init_mode == DataEntryFormMode.UpdateDataState)
        {
            m_cmd_tao_moi.Enabled = false;
        }
        else
        {
            m_cmd_tao_moi.Enabled = true;
        }
        if (!IsPostBack)
        {
            load_data_2_cbo_loai_su_kien();
            load_data_2_cbo_trang_thai();
            load_cbo_loai_su_kien();
            load_data_to_grid();
        }
    }

    #region Members
    US_DM_SU_KIEN m_us_dm_su_kien = new US_DM_SU_KIEN();
    DS_DM_SU_KIEN m_ds_dm_su_kien = new DS_DM_SU_KIEN();

    US_CM_DM_TU_DIEN m_us_cm_dm_tu_dien = new US_CM_DM_TU_DIEN();
    DS_CM_DM_TU_DIEN m_ds_cm_dm_tu_dien = new DS_CM_DM_TU_DIEN();
    Hashtable m_hst_mapping_id_to_ten_loai_su_kien = new Hashtable();
    Hashtable m_hst_mapping_ten_loai_su_kien_to_id_ = new Hashtable();
    DataEntryFormMode m_init_mode = DataEntryFormMode.ViewDataState;
    #endregion

    #region Private Method
    /// <summary>
    /// Hàm lấy mã từ điển (string) dựa vào mã ID
    /// </summary>
    /// <param name="ip_dc_id"></param>
    /// <returns></returns>
    private string load_ma_tu_dien_by_id(decimal ip_dc_id)
    {
        US_CM_DM_TU_DIEN v_us_cm_dm_tu_dien = new US_CM_DM_TU_DIEN();
        DS_CM_DM_TU_DIEN v_ds_cm_dm_tu_dien = new DS_CM_DM_TU_DIEN();

        v_us_cm_dm_tu_dien.FillDataset(v_ds_cm_dm_tu_dien, " WHERE ID= " + ip_dc_id);
        if (v_ds_cm_dm_tu_dien.CM_DM_TU_DIEN.Rows.Count < 0)
            return "";
        else return v_ds_cm_dm_tu_dien.CM_DM_TU_DIEN.Rows[0][CM_DM_TU_DIEN.MA_TU_DIEN].ToString();
    }
    private void load_data_to_grid()
    {
        try
        {
            // Đổ dữ liệu từ US vào DS
            m_us_dm_su_kien.FillDataset(m_ds_dm_su_kien, " WHERE ID_LOAI_SU_KIEN =  " + CIPConvert.ToDecimal(m_cbo_loai_su_kien.SelectedValue));

            // Treo dữ liệu lên lưới
            m_grv_dm_su_kien.DataSource = m_ds_dm_su_kien.DM_SU_KIEN;
            m_grv_dm_su_kien.DataBind();
            if (m_ds_dm_su_kien.DM_SU_KIEN.Rows.Count == 0)
            {
                m_lbl_thong_bao.Text = "Chưa có sự kiện nào";
                m_lbl_thong_bao.Visible = true;
            }
            else m_lbl_thong_bao.Visible = false;
        }
        catch (Exception v_e)
        {
            //nhớ using Ip.Common
            CSystemLog_301.ExceptionHandle(this, v_e);

        }

    }

    private void reset_control()
    {
        m_txt_mo_ta.Text = "";
        m_txt_ten_su_kien.Text = "";
        m_dat_ngay_dien_ra.Text = "";
    }
    private void load_data_2_cbo_loai_su_kien()
    {
        try
        {
            m_ds_cm_dm_tu_dien.CM_DM_TU_DIEN.Clear();
            // Đổ dữ liệu vào DS 
            m_us_cm_dm_tu_dien.FillDataset(m_ds_cm_dm_tu_dien, " WHERE ID_LOAI_TU_DIEN = " + (int)e_loai_tu_dien.LOAI_SU_KIEN); // Đây là lấy theo điều kiện

            //TReo dữ liệu vào Dropdownlist loại hợp đồng
            // dây là giá trị hiển thị
            m_ddl_loai_su_kien.DataTextField = CM_DM_TU_DIEN.TEN;
            // Đây là giá trị thực
            m_ddl_loai_su_kien.DataValueField = CM_DM_TU_DIEN.ID;

            m_ddl_loai_su_kien.DataSource = m_ds_cm_dm_tu_dien.CM_DM_TU_DIEN;
            m_ddl_loai_su_kien.DataBind();

        }
        catch (Exception v_e)
        {
            throw v_e;

        }
    }

    private void load_data_2_cbo_trang_thai()
    {
        try
        {
            m_ds_cm_dm_tu_dien.CM_DM_TU_DIEN.Clear();
            // Đổ dữ liệu vào DS 
            m_us_cm_dm_tu_dien.FillDataset(m_ds_cm_dm_tu_dien, " WHERE ID_LOAI_TU_DIEN = " + (int)e_loai_tu_dien.TRANG_THAI_SU_KIEN); // Đây là lấy theo điều kiện

            //TReo dữ liệu vào Dropdownlist loại hợp đồng
            // dây là giá trị hiển thị
            m_ddl_trang_thai.DataTextField = CM_DM_TU_DIEN.TEN;
            // Đây là giá trị thực
            m_ddl_trang_thai.DataValueField = CM_DM_TU_DIEN.ID;

            m_ddl_trang_thai.DataSource = m_ds_cm_dm_tu_dien.CM_DM_TU_DIEN;
            m_ddl_trang_thai.DataBind();
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }

    private void form_2_us_object(US_DM_SU_KIEN ip_us_su_kien)
    {
        ip_us_su_kien.strTEN_SU_KIEN= m_txt_ten_su_kien.Text.Trim();
        ip_us_su_kien.dcID_LOAI_SU_KIEN = CIPConvert.ToDecimal(m_ddl_loai_su_kien.SelectedValue);
        ip_us_su_kien.datNGAY_DIEN_RA = m_dat_ngay_dien_ra.SelectedDate;
        ip_us_su_kien.dcID_TRANG_THAI = CIPConvert.ToDecimal(m_ddl_trang_thai.SelectedValue);
        ip_us_su_kien.strMO_TA= m_txt_mo_ta.Text.Trim();

    }
    /// <summary>
    /// Hàm này có chức năng chuyển từ id_loai_su_kien trong bảng dm_su_kien sang tên ngắn trong bảng từ điển
    /// </summary>
    //private void mapping_col_id_to_ten_loai_su_kien()
    //{
    //    m_ds_cm_dm_tu_dien.CM_DM_TU_DIEN.Clear();
    //    m_us_cm_dm_tu_dien.FillDataset(m_ds_cm_dm_tu_dien);

    //    foreach (DataRow v_dr in m_ds_cm_dm_tu_dien.CM_DM_TU_DIEN.Rows)
    //    {
    //        m_hst_mapping_id_to_ten_loai_su_kien.Add(v_dr[CM_DM_TU_DIEN.ID], v_dr[CM_DM_TU_DIEN.TEN]);
    //        m_hst_mapping_ten_loai_su_kien_to_id_.Add(v_dr[CM_DM_TU_DIEN.TEN], v_dr[CM_DM_TU_DIEN.ID]);
    //    }
    //}

    /// <summary>
    /// Load dữ liệu từ US đổ vào form
    /// </summary>
    /// <param name="ip_dm_su_kien"></param>
    private void us_obj_2_form(US_DM_SU_KIEN ip_us_su_kien)
    {
        m_txt_ten_su_kien.Text=ip_us_su_kien.strTEN_SU_KIEN ;
        m_ddl_loai_su_kien.SelectedValue = CIPConvert.ToStr(ip_us_su_kien.dcID_LOAI_SU_KIEN);
        m_dat_ngay_dien_ra.SelectedDate = ip_us_su_kien.datNGAY_DIEN_RA;
        m_ddl_trang_thai.SelectedValue = CIPConvert.ToStr(ip_us_su_kien.dcID_TRANG_THAI);
        m_txt_mo_ta.Text=ip_us_su_kien.strMO_TA;
    }
    private void load_data_2_us_by_id(int ip_i_id)
    {
        decimal v_dc_id_dm_su_kien = CIPConvert.ToDecimal(m_grv_dm_su_kien.DataKeys[ip_i_id].Value);
        hdf_id.Value = v_dc_id_dm_su_kien.ToString();
        US_DM_SU_KIEN v_us_dm_su_kien = new US_DM_SU_KIEN(v_dc_id_dm_su_kien);
        // Đẩy us lên form
        us_obj_2_form(v_us_dm_su_kien);
    }
    private void delete_dm_su_kien(int ip_i_row_del)
    {
        decimal v_dc_id_su_kien = CIPConvert.ToDecimal(m_grv_dm_su_kien.DataKeys[ip_i_row_del].Value);
        m_us_dm_su_kien.dcID = v_dc_id_su_kien;
        m_us_dm_su_kien.DeleteByID(v_dc_id_su_kien);
        load_data_to_grid();
        m_lbl_mess.Text = "Xóa bản ghi thành công";
    }
    private bool check_validate()
    {
        if (this.m_txt_ten_su_kien.Text.Trim().Equals(""))
        {
            this.m_ct_su_kien.IsValid = false;
            return false;
        }
        return true;
    }
    private void load_cbo_loai_su_kien()
    {
        try
        {
            US_CM_DM_TU_DIEN v_us_loai_su_kien = new US_CM_DM_TU_DIEN();
            DS_CM_DM_TU_DIEN v_ds_loai_loai_su_kien = new DS_CM_DM_TU_DIEN();
            v_us_loai_su_kien.FillDataset(v_ds_loai_loai_su_kien, " WHERE ID_LOAI_TU_DIEN = " + (int)e_loai_tu_dien.LOAI_SU_KIEN);
            m_cbo_loai_su_kien.DataSource = v_ds_loai_loai_su_kien.CM_DM_TU_DIEN;

            m_cbo_loai_su_kien.DataTextField = CM_DM_TU_DIEN.TEN;
            m_cbo_loai_su_kien.DataValueField = CM_DM_TU_DIEN.ID;
            m_cbo_loai_su_kien.DataBind();
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    #endregion

    #region Public Interface
    public string mapping_ma_to_ten(object ip_ma_tu_dien)
    {
        US_CM_DM_TU_DIEN v_us_cm_dm = new US_CM_DM_TU_DIEN(CIPConvert.ToDecimal(ip_ma_tu_dien));
        return v_us_cm_dm.strTEN;
    }

    #endregion

    #region Data Structure
    public enum e_loai_tu_dien
    {
        PHAN_QUYEN = 1
        ,
        DIA_DIEM_QUAN_LY = 2
            ,
        DON_VI_QUAN_LY_CHINH = 3
            ,
        LEVEL_GIANG_VIEN = 4
            ,
        loai_su_kien = 5
            ,
        NGANH_DAO_TAO = 6
            ,
        DON_VI_TINH = 7
            ,
        TRANG_THAI_HOP_DONG_KHUNG = 8
            ,
        TRANG_THAI_GIANG_VIEN = 9
            , MA_TAN_SUAT = 10
        , LOAI_SU_KIEN=19
        , TRANG_THAI_SU_KIEN=20
    }
    #endregion

    //
    //Events
    //
    //

    protected void m_cmd_tao_moi_Click(object sender, EventArgs e)
    {
        try
        {
            if (!check_validate()) return;
            if (m_init_mode == DataEntryFormMode.UpdateDataState) return;
            form_2_us_object(m_us_dm_su_kien);
            m_us_dm_su_kien.Insert();
            m_lbl_mess.Text = "Thêm bản ghi thành công !";
            reset_control();
            load_data_to_grid();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }

    protected void m_grv_dm_su_kien_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            m_init_mode = DataEntryFormMode.UpdateDataState;
            m_cmd_tao_moi.Enabled = false;
            m_lbl_mess.Text = "";
            load_data_2_us_by_id(e.NewSelectedIndex);
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
            if (hdf_id.Value == "")
            {
                m_lbl_mess.Text = "Bạn phải chọn nội dung cần Cập nhật";
                return;
            }
            form_2_us_object(m_us_dm_su_kien);
            m_us_dm_su_kien.dcID = CIPConvert.ToDecimal(hdf_id.Value);
            m_us_dm_su_kien.Update();
            reset_control();
            m_lbl_mess.Text = "Cập nhật dữ liệu thành công";
            m_grv_dm_su_kien.EditIndex = -1;
            m_init_mode = DataEntryFormMode.ViewDataState;
            load_data_to_grid();
        }
        catch (System.Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            reset_control();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.Equals(this, v_e);
        }
    }

    protected void m_grv_dm_tu_dien_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            m_lbl_mess.Text = "";
            delete_dm_su_kien(e.RowIndex);
        }
        catch (Exception v_e)
        {
            // de su dung CsystemLog_301 bat buoc Site phai dat trong thu muc cap 1. Vi du: DanhMuc/Dictionary.aspx
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }

    protected void m_grv_dm_su_kien_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            m_grv_dm_su_kien.PageIndex = e.NewPageIndex;
            load_data_to_grid();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_loai_su_kien_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            m_ddl_loai_su_kien.SelectedValue = m_cbo_loai_su_kien.SelectedValue;
            load_data_to_grid();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
}