///************************************************
/// Generated by: linhdh
/// Date: 27/03/2012 04:20:46
/// Goal: Create User Service Class for RPT_BAO_CAO_THONG_KE_SO_TIEN_THANH_TOAN_HD_GIANG_VIEN
///************************************************
/// <summary>
/// Create User Service Class for RPT_BAO_CAO_THONG_KE_SO_TIEN_THANH_TOAN_HD_GIANG_VIEN
/// </summary>

using System;
using IP.Core.IPCommon;
using IP.Core.IPUserService;
using System.Data.SqlClient;
using System.Data;
using WebDS;


namespace WebUS{

public class US_RPT_BAO_CAO_THONG_KE_SO_TIEN_THANH_TOAN_HD_GIANG_VIEN : US_Object
{
	private const string c_TableName = "RPT_BAO_CAO_THONG_KE_SO_TIEN_THANH_TOAN_HD_GIANG_VIEN";
#region "Public Properties"
	public decimal dcID 
	{
		get
		{
			return CNull.RowNVLDecimal(pm_objDR, "ID", IPConstants.c_DefaultDecimal);
		}
		set	
		{
			pm_objDR["ID"] = value;
		}
	}

	public bool IsIDNull()	{
		return pm_objDR.IsNull("ID");
	}

	public void SetIDNull() {
		pm_objDR["ID"] = System.Convert.DBNull;
	}

	public string strTRANG_THAI_TT_HOP_DONG 
	{
		get 
		{
			return CNull.RowNVLString(pm_objDR, "TRANG_THAI_TT_HOP_DONG", IPConstants.c_DefaultString);
		}
		set 
		{
			pm_objDR["TRANG_THAI_TT_HOP_DONG"] = value;
		}
	}

	public bool IsTRANG_THAI_TT_HOP_DONGNull() 
	{
		return pm_objDR.IsNull("TRANG_THAI_TT_HOP_DONG");
	}

	public void SetTRANG_THAI_TT_HOP_DONGNull() {
		pm_objDR["TRANG_THAI_TT_HOP_DONG"] = System.Convert.DBNull;
	}

	public decimal dcHD_CHUYEN_MON_EDUTOP 
	{
		get
		{
			return CNull.RowNVLDecimal(pm_objDR, "HD_CHUYEN_MON_EDUTOP", IPConstants.c_DefaultDecimal);
		}
		set	
		{
			pm_objDR["HD_CHUYEN_MON_EDUTOP"] = value;
		}
	}

	public bool IsHD_CHUYEN_MON_EDUTOPNull()	{
		return pm_objDR.IsNull("HD_CHUYEN_MON_EDUTOP");
	}

	public void SetHD_CHUYEN_MON_EDUTOPNull() {
		pm_objDR["HD_CHUYEN_MON_EDUTOP"] = System.Convert.DBNull;
	}

	public decimal dcHD_HUONG_DAN_EDUTOP 
	{
		get
		{
			return CNull.RowNVLDecimal(pm_objDR, "HD_HUONG_DAN_EDUTOP", IPConstants.c_DefaultDecimal);
		}
		set	
		{
			pm_objDR["HD_HUONG_DAN_EDUTOP"] = value;
		}
	}

	public bool IsHD_HUONG_DAN_EDUTOPNull()	{
		return pm_objDR.IsNull("HD_HUONG_DAN_EDUTOP");
	}

	public void SetHD_HUONG_DAN_EDUTOPNull() {
		pm_objDR["HD_HUONG_DAN_EDUTOP"] = System.Convert.DBNull;
	}

	public decimal dcHD_HOC_LIEU_EDUTOP 
	{
		get
		{
			return CNull.RowNVLDecimal(pm_objDR, "HD_HOC_LIEU_EDUTOP", IPConstants.c_DefaultDecimal);
		}
		set	
		{
			pm_objDR["HD_HOC_LIEU_EDUTOP"] = value;
		}
	}

	public bool IsHD_HOC_LIEU_EDUTOPNull()	{
		return pm_objDR.IsNull("HD_HOC_LIEU_EDUTOP");
	}

	public void SetHD_HOC_LIEU_EDUTOPNull() {
		pm_objDR["HD_HOC_LIEU_EDUTOP"] = System.Convert.DBNull;
	}

	public decimal dcHD_CHUYEN_MON_ELC 
	{
		get
		{
			return CNull.RowNVLDecimal(pm_objDR, "HD_CHUYEN_MON_ELC", IPConstants.c_DefaultDecimal);
		}
		set	
		{
			pm_objDR["HD_CHUYEN_MON_ELC"] = value;
		}
	}

	public bool IsHD_CHUYEN_MON_ELCNull()	{
		return pm_objDR.IsNull("HD_CHUYEN_MON_ELC");
	}

	public void SetHD_CHUYEN_MON_ELCNull() {
		pm_objDR["HD_CHUYEN_MON_ELC"] = System.Convert.DBNull;
	}

	public decimal dcHD_HUONG_DAN_ELC 
	{
		get
		{
			return CNull.RowNVLDecimal(pm_objDR, "HD_HUONG_DAN_ELC", IPConstants.c_DefaultDecimal);
		}
		set	
		{
			pm_objDR["HD_HUONG_DAN_ELC"] = value;
		}
	}

	public bool IsHD_HUONG_DAN_ELCNull()	{
		return pm_objDR.IsNull("HD_HUONG_DAN_ELC");
	}

	public void SetHD_HUONG_DAN_ELCNull() {
		pm_objDR["HD_HUONG_DAN_ELC"] = System.Convert.DBNull;
	}

	public decimal dcHD_HOC_LIEU_ELC 
	{
		get
		{
			return CNull.RowNVLDecimal(pm_objDR, "HD_HOC_LIEU_ELC", IPConstants.c_DefaultDecimal);
		}
		set	
		{
			pm_objDR["HD_HOC_LIEU_ELC"] = value;
		}
	}

	public bool IsHD_HOC_LIEU_ELCNull()	{
		return pm_objDR.IsNull("HD_HOC_LIEU_ELC");
	}

	public void SetHD_HOC_LIEU_ELCNull() {
		pm_objDR["HD_HOC_LIEU_ELC"] = System.Convert.DBNull;
	}

#endregion
#region "Init Functions"
	public US_RPT_BAO_CAO_THONG_KE_SO_TIEN_THANH_TOAN_HD_GIANG_VIEN() 
	{
		pm_objDS = new DS_RPT_BAO_CAO_THONG_KE_SO_TIEN_THANH_TOAN_HD_GIANG_VIEN();
		pm_strTableName = c_TableName;
		pm_objDR = pm_objDS.Tables[pm_strTableName].NewRow();
	}

	public US_RPT_BAO_CAO_THONG_KE_SO_TIEN_THANH_TOAN_HD_GIANG_VIEN(DataRow i_objDR): this()
	{
		this.DataRow2Me(i_objDR);
	}

	public US_RPT_BAO_CAO_THONG_KE_SO_TIEN_THANH_TOAN_HD_GIANG_VIEN(decimal i_dbID) 
	{
		pm_objDS = new DS_RPT_BAO_CAO_THONG_KE_SO_TIEN_THANH_TOAN_HD_GIANG_VIEN();
		pm_strTableName = c_TableName;
		IMakeSelectCmd v_objMkCmd = new CMakeAndSelectCmd(pm_objDS, c_TableName);
		v_objMkCmd.AddCondition("ID", i_dbID, eKieuDuLieu.KieuNumber, eKieuSoSanh.Bang);
		SqlCommand v_cmdSQL;
		v_cmdSQL = v_objMkCmd.getSelectCmd();
		this.FillDatasetByCommand(pm_objDS, v_cmdSQL);
		pm_objDR = getRowClone(pm_objDS.Tables[pm_strTableName].Rows[0]);
	}
#endregion

    #region Additional function
    public void bao_cao_thong_ke_so_tien_thanh_toan_hd_giang_vien_tong_hop(DS_RPT_BAO_CAO_THONG_KE_SO_TIEN_THANH_TOAN_HD_GIANG_VIEN op_ds_bao_cao_thong_ke_so_tien_thanh_toan_gv_tong_hop, decimal ip_dc_thang, decimal ip_dc_nam)
    {
        CStoredProc v_cstore = new CStoredProc("pr_V_DM_HOP_DONG_KHUNG_Bao_Cao_Tong_hop_so_Tien_Thanh_Toan");
        v_cstore.addDecimalInputParam("@thang", ip_dc_thang);
        v_cstore.addDecimalInputParam("@nam", ip_dc_nam);
        v_cstore.fillDataSetByCommand(this, op_ds_bao_cao_thong_ke_so_tien_thanh_toan_gv_tong_hop);
    }
    #endregion
	}
}
