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


public partial class DanhMuc_NoiDungThanhToan : System.Web.UI.Page
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
            load_data_2_cbo_loai_hop_dong();
            load_data_2_cbo_ma_don_vi_tinh();            
            load_data_2_cbo_ma_tan_suat();
            load_cbo_loai_hop_dong();
            load_data_to_grid();
        }
    }

    #region Members
    US_V_DM_NOI_DUNG_THANH_TOAN m_us_dm_noi_dung_thanh_toan = new US_V_DM_NOI_DUNG_THANH_TOAN();
    DS_V_DM_NOI_DUNG_THANH_TOAN m_ds_noi_dung_thanh_toan = new DS_V_DM_NOI_DUNG_THANH_TOAN();

    US_CM_DM_TU_DIEN m_us_cm_dm_tu_dien = new US_CM_DM_TU_DIEN();
    DS_CM_DM_TU_DIEN m_ds_cm_dm_tu_dien = new DS_CM_DM_TU_DIEN();
    Hashtable m_hst_mapping_id_to_ten_loai_hop_dong = new Hashtable();
    Hashtable m_hst_mapping_ten_loai_hop_dong_to_id_ = new Hashtable();
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

        v_us_cm_dm_tu_dien.FillDataset(v_ds_cm_dm_tu_dien, " WHERE ID= "+ ip_dc_id);
        if(v_ds_cm_dm_tu_dien.CM_DM_TU_DIEN.Rows.Count <0)
        return "";
        else return v_ds_cm_dm_tu_dien.CM_DM_TU_DIEN.Rows[0][CM_DM_TU_DIEN.MA_TU_DIEN].ToString();
    }
    private void load_data_to_grid()
    {
        try
        {
            // Đổ dữ liệu từ US vào DS
            m_us_dm_noi_dung_thanh_toan.FillDataset(m_ds_noi_dung_thanh_toan, " WHERE ID_LOAI_HOP_DONG =  "+ CIPConvert.ToDecimal(m_cbo_loai_hop_dong.SelectedValue));

            // Treo dữ liệu lên lưới
            m_grv_dm_noi_dung_thanh_toan.DataSource = m_ds_noi_dung_thanh_toan.V_DM_NOI_DUNG_THANH_TOAN;
            m_grv_dm_noi_dung_thanh_toan.DataBind();
            if (m_ds_noi_dung_thanh_toan.V_DM_NOI_DUNG_THANH_TOAN.Rows.Count == 0)
            {
                m_lbl_thong_bao.Text = "Chưa có nội dung thanh toán cho lọai hợp đồng này";
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
        m_txt_ten_noi_dung.Text = "";
        m_txt_don_gia.Text = "";
        m_rd_no_hoc_lieu.Checked = true;
        m_rd_yes_van_hanh.Checked = true;
        m_txt_ghi_chu.Text = "";
    }
    private void load_data_2_cbo_loai_hop_dong()
    {
        try
        {
            m_ds_cm_dm_tu_dien.CM_DM_TU_DIEN.Clear();
             // Đổ dữ liệu vào DS 
            m_us_cm_dm_tu_dien.FillDataset(m_ds_cm_dm_tu_dien, " WHERE ID_LOAI_TU_DIEN = "+ (int)e_loai_tu_dien.LOAI_HOP_DONG); // Đây là lấy theo điều kiện
           
            //TReo dữ liệu vào Dropdownlist loại hợp đồng
            // dây là giá trị hiển thị
            m_ddl_loai_hop_dong.DataTextField = CM_DM_TU_DIEN.TEN;
            // Đây là giá trị thực
            m_ddl_loai_hop_dong.DataValueField = CM_DM_TU_DIEN.ID;

            m_ddl_loai_hop_dong.DataSource = m_ds_cm_dm_tu_dien.CM_DM_TU_DIEN;
            m_ddl_loai_hop_dong.DataBind();
           
        }
        catch (Exception v_e)
        {
            throw v_e;
         
        }
    }

    private void load_data_2_cbo_ma_don_vi_tinh()
    {
        try
        {
            m_ds_cm_dm_tu_dien.CM_DM_TU_DIEN.Clear();
            // Đổ dữ liệu vào DS 
            m_us_cm_dm_tu_dien.FillDataset(m_ds_cm_dm_tu_dien, " WHERE ID_LOAI_TU_DIEN = "+ (int)e_loai_tu_dien.DON_VI_TINH); // Đây là lấy theo điều kiện

            //TReo dữ liệu vào Dropdownlist loại hợp đồng
            // dây là giá trị hiển thị
             m_ddl_ma_don_vi_tinh.DataTextField = CM_DM_TU_DIEN.TEN;
            // Đây là giá trị thực
            m_ddl_ma_don_vi_tinh.DataValueField = CM_DM_TU_DIEN.MA_TU_DIEN;

            m_ddl_ma_don_vi_tinh.DataSource = m_ds_cm_dm_tu_dien.CM_DM_TU_DIEN;
            m_ddl_ma_don_vi_tinh.DataBind();

        }
        catch (Exception v_e)
        {
            throw v_e;

        }
    }

    private void load_data_2_cbo_ma_tan_suat()
    {
        try
        {
            m_ds_cm_dm_tu_dien.CM_DM_TU_DIEN.Clear();
            // Đổ dữ liệu vào DS 
            m_us_cm_dm_tu_dien.FillDataset(m_ds_cm_dm_tu_dien, " WHERE ID_LOAI_TU_DIEN = " + (int)e_loai_tu_dien.MA_TAN_SUAT); // Đây là lấy theo điều kiện

            //TReo dữ liệu vào Dropdownlist loại hợp đồng
            // dây là giá trị hiển thị
            m_ddl_ma_tan_xuat.DataTextField = CM_DM_TU_DIEN.TEN;
            // Đây là giá trị thực
            m_ddl_ma_tan_xuat.DataValueField = CM_DM_TU_DIEN.MA_TU_DIEN;            
            
            m_ddl_ma_tan_xuat.DataSource = m_ds_cm_dm_tu_dien.CM_DM_TU_DIEN;
            m_ddl_ma_tan_xuat.DataBind();
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }

    private void form_2_us_object(US_V_DM_NOI_DUNG_THANH_TOAN ip_us_noi_dung_thanh_toan)
    {
        ip_us_noi_dung_thanh_toan.strTEN_NOI_DUNG = m_txt_ten_noi_dung.Text;
        ip_us_noi_dung_thanh_toan.dcID_LOAI_HOP_DONG = CIPConvert.ToDecimal(m_ddl_loai_hop_dong.SelectedValue);
        ip_us_noi_dung_thanh_toan.strMA_DON_VI_TINH = m_ddl_ma_don_vi_tinh.SelectedValue;
        ip_us_noi_dung_thanh_toan.strMA_TAN_SUAT = m_ddl_ma_tan_xuat.SelectedValue;
        ip_us_noi_dung_thanh_toan.dcDON_GIA_DEFAULT = CIPConvert.ToDecimal(m_txt_don_gia.Text);
        ip_us_noi_dung_thanh_toan.strGHI_CHU = m_txt_ghi_chu.Text;
        if (m_rd_yes_hoc_lieu.Checked)
            ip_us_noi_dung_thanh_toan.strHOC_LIEU_YN = "Y";
        else ip_us_noi_dung_thanh_toan.strHOC_LIEU_YN = "N";
        if (m_rd_yes_van_hanh.Checked)
            ip_us_noi_dung_thanh_toan.strVAN_HANH_YN = "Y";
        else ip_us_noi_dung_thanh_toan.strVAN_HANH_YN = "N";
        if (m_txt_so_luong_he_so_default.Text == "") ip_us_noi_dung_thanh_toan.dcSO_LUONG_HE_SO_DEFAULT = 0;
        else 
          ip_us_noi_dung_thanh_toan.dcSO_LUONG_HE_SO_DEFAULT = CIPConvert.ToDecimal(m_txt_so_luong_he_so_default.Text.Trim());
        if (m_rdl_su_dung_yn.Items[0].Selected) ip_us_noi_dung_thanh_toan.strSU_DUNG_YN = "Y";
        else ip_us_noi_dung_thanh_toan.strSU_DUNG_YN = "N";
        ip_us_noi_dung_thanh_toan.strSU_KIEN_YN = "N";
    }
    /// <summary>
    /// Hàm này có chức năng chuyển từ id_loai_hop_dong trong bảng dm_noi_dung_thanh_toan sang tên ngắn trong bảng từ điển
    /// </summary>
    private void mapping_col_id_to_ten_loai_hop_dong()
    {
        m_ds_cm_dm_tu_dien.CM_DM_TU_DIEN.Clear();
        m_us_cm_dm_tu_dien.FillDataset(m_ds_cm_dm_tu_dien);

        foreach (DataRow v_dr in m_ds_cm_dm_tu_dien.CM_DM_TU_DIEN.Rows)
        {
            m_hst_mapping_id_to_ten_loai_hop_dong.Add(v_dr[CM_DM_TU_DIEN.ID], v_dr[CM_DM_TU_DIEN.TEN]);
            m_hst_mapping_ten_loai_hop_dong_to_id_.Add(v_dr[CM_DM_TU_DIEN.TEN], v_dr[CM_DM_TU_DIEN.ID]);
        }
    }

    /// <summary>
    /// Load dữ liệu từ US đổ vào form
    /// </summary>
    /// <param name="ip_dm_noi_dung_thanh_toan"></param>
    private void us_obj_2_form(US_V_DM_NOI_DUNG_THANH_TOAN ip_us_noi_dung_thanh_toan)
    {
        m_txt_ten_noi_dung.Text = ip_us_noi_dung_thanh_toan.strTEN_NOI_DUNG;
        m_ddl_loai_hop_dong.SelectedValue = CIPConvert.ToStr( ip_us_noi_dung_thanh_toan.dcID_LOAI_HOP_DONG);
        m_ddl_ma_don_vi_tinh.SelectedValue = ip_us_noi_dung_thanh_toan.strMA_DON_VI_TINH;
        m_txt_don_gia.Text = CIPConvert.ToStr(ip_us_noi_dung_thanh_toan.dcDON_GIA_DEFAULT,"#,###");
        if (ip_us_noi_dung_thanh_toan.strHOC_LIEU_YN == "Y")
            m_rd_yes_hoc_lieu.Checked=true;
        else m_rd_no_hoc_lieu.Checked = true;
        if (ip_us_noi_dung_thanh_toan.strVAN_HANH_YN == "Y")
            m_rd_yes_van_hanh.Checked = true;
        else m_rd_no_van_hanh.Checked = true;
        m_txt_ghi_chu.Text = ip_us_noi_dung_thanh_toan.strGHI_CHU;
        m_ddl_ma_tan_xuat.SelectedValue = ip_us_noi_dung_thanh_toan.strMA_TAN_SUAT;
        m_txt_so_luong_he_so_default.Text = CIPConvert.ToStr(ip_us_noi_dung_thanh_toan.dcSO_LUONG_HE_SO_DEFAULT);
        if (ip_us_noi_dung_thanh_toan.strSU_DUNG_YN.Equals("Y"))
        {
            m_rdl_su_dung_yn.Items[0].Selected = true;
            m_rdl_su_dung_yn.Items[1].Selected = false;
        }
        else
        {
            m_rdl_su_dung_yn.Items[0].Selected = false;
            m_rdl_su_dung_yn.Items[1].Selected = true;
        }
    }
    private void load_data_2_us_by_id(int ip_i_id)
    {
        decimal v_dc_id_dm_noi_dung_thanh_toan = CIPConvert.ToDecimal(m_grv_dm_noi_dung_thanh_toan.DataKeys[ip_i_id].Value);
        hdf_id.Value = v_dc_id_dm_noi_dung_thanh_toan.ToString();
        US_V_DM_NOI_DUNG_THANH_TOAN v_us_dm_noi_dung_thanh_toan = new US_V_DM_NOI_DUNG_THANH_TOAN(v_dc_id_dm_noi_dung_thanh_toan);
       // Đẩy us lên form
        us_obj_2_form(v_us_dm_noi_dung_thanh_toan);
    }
    private void delete_dm_noi_dung_thanh_toan(int ip_i_row_del)
    {
        decimal v_dc_id_noi_dung_thanh_toan = CIPConvert.ToDecimal(m_grv_dm_noi_dung_thanh_toan.DataKeys[ip_i_row_del].Value);
        m_us_dm_noi_dung_thanh_toan.dcID = v_dc_id_noi_dung_thanh_toan;
        m_us_dm_noi_dung_thanh_toan.DeleteByID(v_dc_id_noi_dung_thanh_toan);
        load_data_to_grid();
        m_lbl_mess.Text = "Xóa bản ghi thành công";
    }
    private bool check_validate()
    {
        if (this.m_txt_ten_noi_dung.Text.Trim().Equals(""))
        {
            this.m_ct_noi_dung.IsValid = false;
            return false;
        }
        if (this.m_txt_don_gia.Text.Trim().Equals(""))
        {
            this.m_ct_don_gia.IsValid = false;
            return false;
        }
        return true;
    }
    private void load_cbo_loai_hop_dong()
    {
        try
        {
            US_CM_DM_TU_DIEN v_us_loai_hop_dong = new US_CM_DM_TU_DIEN();
            DS_CM_DM_TU_DIEN v_ds_loai_loai_hop_dong = new DS_CM_DM_TU_DIEN();
            v_us_loai_hop_dong.FillDataset(v_ds_loai_loai_hop_dong, " WHERE ID_LOAI_TU_DIEN = 5");
            m_cbo_loai_hop_dong.DataSource = v_ds_loai_loai_hop_dong.CM_DM_TU_DIEN;

            m_cbo_loai_hop_dong.DataTextField = CM_DM_TU_DIEN.TEN;
            m_cbo_loai_hop_dong.DataValueField = CM_DM_TU_DIEN.ID;
            m_cbo_loai_hop_dong.DataBind();
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    #endregion

    #region Public Interface
    public string mapping_ma_to_ten(string ip_ma_tu_dien)
    {
        if (ip_ma_tu_dien == "") return "";

        US_CM_DM_TU_DIEN v_us_cm_dm = new US_CM_DM_TU_DIEN("MA_TAN_SUAT", ip_ma_tu_dien);
        return v_us_cm_dm.strTEN;
    }
    public string mapping_YN(string ip_str_YN)
    {
        if(ip_str_YN=="") return "";
        if (ip_str_YN.Equals("Y"))
            return "Có";
        return "Không";
    }
    #endregion

    #region Data Structure
    public enum e_loai_tu_dien
    {
        PHAN_QUYEN = 1
        , DIA_DIEM_QUAN_LY = 2
        , DON_VI_QUAN_LY_CHINH = 3
        , LEVEL_GIANG_VIEN =4
        , LOAI_HOP_DONG =5
        , NGANH_DAO_TAO =6
        , DON_VI_TINH =7
        , TRANG_THAI_HOP_DONG_KHUNG =8
        , TRANG_THAI_GIANG_VIEN =9
        , MA_TAN_SUAT = 10
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
            form_2_us_object(m_us_dm_noi_dung_thanh_toan);
            m_us_dm_noi_dung_thanh_toan.Insert();
            m_lbl_mess.Text = "Thêm bản ghi thành công !";
            reset_control();
            load_data_to_grid();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this,v_e);
        }
    }

    protected void m_grv_dm_noi_dung_thanh_toan_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
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
            form_2_us_object(m_us_dm_noi_dung_thanh_toan);
            m_us_dm_noi_dung_thanh_toan.dcID = CIPConvert.ToDecimal(hdf_id.Value);
            m_us_dm_noi_dung_thanh_toan.Update();
            reset_control();
            m_lbl_mess.Text = "Cập nhật dữ liệu thành công";
            m_grv_dm_noi_dung_thanh_toan.EditIndex = -1;
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
            delete_dm_noi_dung_thanh_toan(e.RowIndex);
        }
        catch (Exception v_e)
        {
            // de su dung CsystemLog_301 bat buoc Site phai dat trong thu muc cap 1. Vi du: DanhMuc/Dictionary.aspx
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }

    protected void m_grv_dm_noi_dung_thanh_toan_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            m_grv_dm_noi_dung_thanh_toan.PageIndex = e.NewPageIndex;
            load_data_to_grid();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this,v_e);
        }
    }
    protected void m_cbo_loai_hop_dong_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            m_ddl_loai_hop_dong.SelectedValue = m_cbo_loai_hop_dong.SelectedValue;
            load_data_to_grid();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
}