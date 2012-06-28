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

public partial class CongTTGV_F1722_TongHopThanhToanGV : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            m_lbl_thong_bao.Text = "";
            load_data_2_cbo_don_vi_thanh_toan();
            load_data_2_nam_bd_hop_tac();
            load_data_2_cbo_giang_vien();            
            m_lbl_ma_gv.Text = mapping_magv_by_id(CIPConvert.ToDecimal(m_cbo_ten_giang_vien.SelectedValue));
            if (Session["UserName"] == null)
                Response.Redirect("/TRMProject/Account/Login.aspx");
            else
            {
                m_cbo_ten_giang_vien.SelectedValue = CIPConvert.ToStr(get_id_giang_vien_by_ma(CIPConvert.ToStr(Session["UserName"])));
                m_lbl_ma_gv.Text = CIPConvert.ToStr(Session["UserName"]);                
                search_data_show_on_grid();
            }
        }
    }

    #region Members
    US_CM_DM_TU_DIEN m_us_cm_tu_dien = new US_CM_DM_TU_DIEN();
    DS_CM_DM_TU_DIEN m_ds_cm_tu_dien = new DS_CM_DM_TU_DIEN();
    US_TBL_GD_THANH_TOAN m_us_tbl_gd_thanh_toan = new US_TBL_GD_THANH_TOAN();
    DS_TBL_GD_THANH_TOAN m_ds_tbl_gd_thanh_toan = new DS_TBL_GD_THANH_TOAN();
    #endregion

    #region Public Interfaces
    private string mapping_so_tien(object ip_obj_so_tien)
    {
        if (ip_obj_so_tien.GetType() == typeof(DBNull)) return "";
        if (CIPConvert.ToDecimal(ip_obj_so_tien) == 0)
            return CIPConvert.ToStr(0);
        return CIPConvert.ToStr(ip_obj_so_tien, "#,###");
    }
    private string mapping_string(object ip_obj_str)
    {
        if (ip_obj_str.GetType() != typeof(DBNull))
            return CIPConvert.ToStr(ip_obj_str);
        return "";
    }
    public string mapping_sophieutt_by_ID(decimal ip_dc_id_dtt)
    {
        if (ip_dc_id_dtt == 0) return "";
        US_V_DM_DOT_THANH_TOAN v_dm_dtt = new US_V_DM_DOT_THANH_TOAN(ip_dc_id_dtt);
        if (v_dm_dtt.IsMA_DOT_TTNull()) return "";
        return v_dm_dtt.strMA_DOT_TT;
    }
    public string mapping_dvtt_by_ID(decimal ip_dc_id_dtt)
    {
        if (ip_dc_id_dtt == 0) return "";
        US_V_DM_DOT_THANH_TOAN v_dm_dtt = new US_V_DM_DOT_THANH_TOAN(ip_dc_id_dtt);
        if (v_dm_dtt.IsDON_VI_THANH_TOANNull()) return "";
        return v_dm_dtt.strDON_VI_THANH_TOAN;
    }
    public string mapping_magv_by_id(decimal ip_dc_id_gv)
    {
        if (ip_dc_id_gv == 0) return "";
        US_V_DM_GIANG_VIEN v_dm_gv = new US_V_DM_GIANG_VIEN(ip_dc_id_gv);
        if (v_dm_gv.IsMA_GIANG_VIENNull()) return "";
        return v_dm_gv.strMA_GIANG_VIEN;
    }
    public string mapping_tengv_by_id(decimal ip_dc_id_gv)
    {
        if (ip_dc_id_gv == 0) return "";
        US_V_DM_GIANG_VIEN v_dm_gv = new US_V_DM_GIANG_VIEN(ip_dc_id_gv);
        if (v_dm_gv.IsTEN_GIANG_VIENNull()) return "";
        return v_dm_gv.strTEN_GIANG_VIEN;
    }
    public string mapping_sotaikhoan_by_id(decimal ip_dc_id_gv)
    {
        if (ip_dc_id_gv == 0) return "";
        US_V_DM_GIANG_VIEN v_dm_gv = new US_V_DM_GIANG_VIEN(ip_dc_id_gv);
        if (v_dm_gv.IsSO_TAI_KHOANNull()) return "";
        return v_dm_gv.strSO_TAI_KHOAN;
    }
    public string mapping_tennganhang_by_id(decimal ip_dc_id_gv)
    {
        if (ip_dc_id_gv == 0) return "";
        US_V_DM_GIANG_VIEN v_dm_gv = new US_V_DM_GIANG_VIEN(ip_dc_id_gv);
        if (v_dm_gv.IsTEN_NGAN_HANGNull()) return "";
        return v_dm_gv.strTEN_NGAN_HANG;
    }
    public string mapping_masothue_by_id(decimal ip_dc_id_gv)
    {
        if (ip_dc_id_gv == 0) return "";
        US_V_DM_GIANG_VIEN v_dm_gv = new US_V_DM_GIANG_VIEN(ip_dc_id_gv);
        if (v_dm_gv.IsMA_SO_THUENull()) return "";
        return v_dm_gv.strMA_SO_THUE;
    }
    public decimal get_tong_tien_dot_TT()
    {
        decimal v_tong_tien = 0;
        if (m_ds_tbl_gd_thanh_toan.TBL_GD_THANH_TOAN != null)
        {
            foreach (DataRow item in m_ds_tbl_gd_thanh_toan.TBL_GD_THANH_TOAN)
            {
                v_tong_tien += CIPConvert.ToDecimal(item["TONG_TIEN_THANH_TOAN"]);
            }
        }        
        return v_tong_tien;
    }
    #endregion

    #region Private Methods
    private void load_data_2_cbo_don_vi_thanh_toan()
    {
        DS_DM_DON_VI_THANH_TOAN v_ds_don_vi_thanh_toan = new DS_DM_DON_VI_THANH_TOAN();
        US_DM_DON_VI_THANH_TOAN v_us_don_vi_thanh_toan = new US_DM_DON_VI_THANH_TOAN();

        DataRow v_dr_none = v_ds_don_vi_thanh_toan.DM_DON_VI_THANH_TOAN.NewDM_DON_VI_THANH_TOANRow();
        v_dr_none[DM_DON_VI_THANH_TOAN.ID] = "0";
        v_dr_none[DM_DON_VI_THANH_TOAN.MA_DON_VI] = "All";
        v_dr_none[DM_DON_VI_THANH_TOAN.TEN_DON_VI] = "Tất cả";
        v_ds_don_vi_thanh_toan.DM_DON_VI_THANH_TOAN.Rows.InsertAt(v_dr_none, 0);

        v_us_don_vi_thanh_toan.FillDataset(v_ds_don_vi_thanh_toan);
        m_cbo_don_vi_thanh_toan.DataTextField = DM_DON_VI_THANH_TOAN.TEN_DON_VI;
        m_cbo_don_vi_thanh_toan.DataValueField = DM_DON_VI_THANH_TOAN.ID;
        m_cbo_don_vi_thanh_toan.DataSource = v_ds_don_vi_thanh_toan.DM_DON_VI_THANH_TOAN;
        m_cbo_don_vi_thanh_toan.DataBind();
    }
    private void load_data_2_nam_bd_hop_tac()
    {
        m_cbo_nam_thanh_toan.Items.Add(new ListItem("Tất cả", CIPConvert.ToStr(0)));
        for (int v_i = 2008; v_i < 2051; v_i++)
        {
            m_cbo_nam_thanh_toan.Items.Add(new ListItem(v_i.ToString(), v_i.ToString()));
        }
    }
    private void load_data_2_cbo_giang_vien()
    {
        US_V_DM_GIANG_VIEN v_us_giang_vien = new US_V_DM_GIANG_VIEN();
        DS_V_DM_GIANG_VIEN v_ds_giang_vien = new DS_V_DM_GIANG_VIEN();
        v_us_giang_vien.FillDataset(v_ds_giang_vien, " ORDER BY HO_VA_TEN_DEM");
        // Add thêm tất cả vào cbo
        m_cbo_ten_giang_vien.Items.Add(new ListItem("Tất cả", CIPConvert.ToStr(0)));
        for (int v_i = 0; v_i < v_ds_giang_vien.V_DM_GIANG_VIEN.Rows.Count; v_i++)
        {
            m_cbo_ten_giang_vien.Items.Add(new ListItem(v_ds_giang_vien.V_DM_GIANG_VIEN.Rows[v_i][V_DM_GIANG_VIEN.HO_VA_TEN_DEM].ToString().TrimEnd() + " " + v_ds_giang_vien.V_DM_GIANG_VIEN.Rows[v_i][V_DM_GIANG_VIEN.TEN_GIANG_VIEN].ToString(), v_ds_giang_vien.V_DM_GIANG_VIEN.Rows[v_i][V_DM_GIANG_VIEN.ID].ToString()));
        }
    }
    private decimal get_id_giang_vien_by_ma(string ip_str_ma_gv)
    {
        US_V_DM_GIANG_VIEN v_us_dm_gv = new US_V_DM_GIANG_VIEN();
        DS_V_DM_GIANG_VIEN v_ds_dm_gv = new DS_V_DM_GIANG_VIEN();
        v_us_dm_gv.FillDataset(v_ds_dm_gv, " WHERE MA_GIANG_VIEN = N'" + ip_str_ma_gv + "'");
        return CIPConvert.ToDecimal(v_ds_dm_gv.V_DM_GIANG_VIEN.Rows[0][V_DM_GIANG_VIEN.ID]);
    }
    private void search_data_show_on_grid()
    {
   
        // if (ip_dc_id_dot_tt == 0) load_data_2_grid_search("All", v_str_loai_hd);
        load_data_2_grid_search(CIPConvert.ToDecimal(m_cbo_ten_giang_vien.SelectedValue),
                                CIPConvert.ToDecimal(m_cbo_don_vi_thanh_toan.SelectedValue),                                                                
                                CIPConvert.ToDecimal(m_cbo_thang_thanh_toan.SelectedValue),
                                CIPConvert.ToDecimal(m_cbo_nam_thanh_toan.SelectedValue));
    }
    private void load_data_2_grid_search(decimal ip_dc_id_giang_vien,
                                         decimal ip_dc_dv_thanh_toan,
                                         decimal ip_dc_thang_tt,
                                         decimal ip_dc_nam_tt)
    {
        m_us_tbl_gd_thanh_toan.fill_dataset_tongho_thanhtaon_by_id_giang_vien_thang_nam_dot_va_dv_thanh_toan(ip_dc_id_giang_vien,
                                            ip_dc_dv_thanh_toan,
                                            ip_dc_thang_tt,
                                            ip_dc_nam_tt,
                                            m_ds_tbl_gd_thanh_toan);

        if (m_ds_tbl_gd_thanh_toan.TBL_GD_THANH_TOAN.Rows.Count == 0)
        {
            m_lbl_thong_bao.Visible = true;
            m_lbl_thong_bao.Text = "Chưa có đợt thanh toán nào cho giảng viên này!";
        }
        else m_lbl_thong_bao.Text = "";
        m_grv_danh_sach_du_toan.DataSource = m_ds_tbl_gd_thanh_toan.TBL_GD_THANH_TOAN;
        m_grv_danh_sach_du_toan.DataBind();
        m_lbl_danh_sach_thanh_toan.Text = "Danh Đợt sách Thanh toán: " + m_ds_tbl_gd_thanh_toan.TBL_GD_THANH_TOAN.Rows.Count + "đợt thanh toán";        
    }
    private void load_data_2_excel_search(decimal ip_dc_id_giang_vien,
                                         decimal ip_dc_dv_thanh_toan,
                                         decimal ip_dc_thang_tt,
                                         decimal ip_dc_nam_tt)
    {
        m_ds_tbl_gd_thanh_toan.Clear();
        m_us_tbl_gd_thanh_toan.fill_dataset_tongho_thanhtaon_by_id_giang_vien_thang_nam_dot_va_dv_thanh_toan(ip_dc_id_giang_vien,
                                            ip_dc_dv_thanh_toan,
                                            ip_dc_thang_tt,
                                            ip_dc_nam_tt,
                                            m_ds_tbl_gd_thanh_toan);
    }

    #endregion

    #region Export Excel
    private void loadDSExprort(ref string strTable)
    {
        int v_i_so_thu_tu = 0;
        // Mỗi cột dữ liệu ứng với từng dòng là label
        foreach (DataRow grv in this.m_ds_tbl_gd_thanh_toan.TBL_GD_THANH_TOAN.Rows)
        {
            strTable += "\n<tr>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + ++v_i_so_thu_tu + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_sophieutt_by_ID( CIPConvert.ToDecimal(grv[TBL_GD_THANH_TOAN.ID_DOT_THANH_TOAN])) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_dvtt_by_ID(CIPConvert.ToDecimal(grv[TBL_GD_THANH_TOAN.ID_DOT_THANH_TOAN])) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + "'" + mapping_string(mapping_sotaikhoan_by_id(CIPConvert.ToDecimal(grv[TBL_GD_THANH_TOAN.ID_GIANG_VIEN]))) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_string(mapping_tennganhang_by_id(CIPConvert.ToDecimal(grv[TBL_GD_THANH_TOAN.ID_GIANG_VIEN]))) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + "'" + mapping_string(mapping_masothue_by_id(CIPConvert.ToDecimal(grv[TBL_GD_THANH_TOAN.ID_GIANG_VIEN]))) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_so_tien(grv[TBL_GD_THANH_TOAN.TONG_TIEN_THANH_TOAN]) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_so_tien((CIPConvert.ToDecimal(Eval("TONG_TIEN_THANH_TOAN")) > 1000000) ? CIPConvert.ToDecimal(Eval("TONG_TIEN_THANH_TOAN")) / 10 : 0) + "</td>";
            strTable += "\n<td style='width:12%;' class='cssTitleReport' nowrap='nowrap'>" + mapping_so_tien(CIPConvert.ToDecimal(Eval("TONG_TIEN_THANH_TOAN")) - ((CIPConvert.ToDecimal(Eval("TONG_TIEN_THANH_TOAN")) > 1000000) ? CIPConvert.ToDecimal(Eval("TONG_TIEN_THANH_TOAN")) / 10 : 0)) + "</td>";            
            strTable += "\n</tr>";
        }

        strTable += "\n<tr>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'></td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'></td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'></td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'></td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'></td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Tổng tiền: </td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>" + mapping_so_tien(get_tong_tien_dot_TT()) + "</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>" + mapping_so_tien((get_tong_tien_dot_TT() > 1000000) ? get_tong_tien_dot_TT() / 10 : 0) + "</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>" + mapping_so_tien(get_tong_tien_dot_TT() - ((get_tong_tien_dot_TT() > 1000000) ? get_tong_tien_dot_TT() / 10 : 0)) + "</td>";        
        strTable += "\n</tr>";
    }

    private void loadTieuDe(ref string strTable)
    {
        load_data_2_excel_search(CIPConvert.ToDecimal(m_cbo_ten_giang_vien.SelectedValue)
                    , CIPConvert.ToDecimal(m_cbo_don_vi_thanh_toan.SelectedValue)
                    , CIPConvert.ToDecimal(m_cbo_thang_thanh_toan.SelectedValue)
                    , CIPConvert.ToDecimal(m_cbo_nam_thanh_toan.SelectedValue));
        strTable += "<table cellpadding='2' cellspacing='0' class='cssTableReport'>";
        strTable += "\n<tr>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width: 100%;  height: 40px; font-size: large; color:White; background-color:#810C15;' nowrap='wrap'>TRM702 - BÁO CÁO LỊCH SỬ THANH TOÁN CỦA GIẢNG VIÊN" + "</td>";
        strTable += "\n</tr>";
        //
        strTable += "\n<tr>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'> Mã giảng viên: " + mapping_magv_by_id(CIPConvert.ToDecimal(m_cbo_ten_giang_vien.SelectedValue)) + "</td>";
        strTable += "\n</tr>";
        //
        strTable += "\n<tr>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>Tên giảng viên: " + m_cbo_ten_giang_vien.SelectedItem.Text + "</td>";
        strTable += "\n</tr>";
        //
        strTable += "\n<tr>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>  </td>";
        strTable += "\n<td><align='center' class='cssTableView' style='width:100%;' nowrap='nowrap'>Đơn vị thanh toán: " + m_cbo_don_vi_thanh_toan.SelectedItem.Text + "</td>";
        strTable += "\n</tr>";
        strTable += "\n</table>";
        //table noi dung
        strTable += "<table cellpadding='2' cellspacing='0' class='cssTableReport'>";
        strTable += "\n<tr>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>STT</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Mã đợt thanh toán</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Đơn vị quản lý HĐ</td>";;
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Số tài khoản</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Tên ngân hàng</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Mã số thuế</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Tổng tiền thanh toán đợt này (VNĐ)</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Số tiền thuế (VNĐ)</td>";
        strTable += "\n<td style='width:12%;' class='cssTableView' nowrap='nowrap'>Tổng tiền thức nhận đợt này</td>";
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
    protected void m_cmd_tim_kiem_Click(object sender, EventArgs e)
    {
        try
        {
            search_data_show_on_grid();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cmd_xuat_excel_Click(object sender, EventArgs e)
    {
        try
        {
            string html = loadExport();
            string strNamFile = "BaoCaoTongHopThanhToanTheoGiangVien" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + ".xls";
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
    protected void m_grv_danh_sach_du_toan_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            m_grv_danh_sach_du_toan.PageIndex = e.NewPageIndex;
            search_data_show_on_grid();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_ten_giang_vien_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            m_lbl_ma_gv.Text = mapping_magv_by_id(CIPConvert.ToDecimal(m_cbo_ten_giang_vien.SelectedValue));
            search_data_show_on_grid();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_don_vi_thanh_toan_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {            
            search_data_show_on_grid();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_thang_thanh_toan_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {            
            search_data_show_on_grid();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cbo_nam_thanh_toan_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {           
            search_data_show_on_grid();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    #endregion
}