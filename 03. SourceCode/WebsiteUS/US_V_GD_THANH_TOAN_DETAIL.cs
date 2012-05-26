///************************************************
/// Generated by: linhdh
/// Date: 17/11/2011 11:47:23
/// Goal: Create User Service Class for V_GD_THANH_TOAN_DETAIL
///************************************************
/// <summary>
/// Create User Service Class for V_GD_THANH_TOAN_DETAIL
/// </summary>

using System;
using IP.Core.IPCommon;
using IP.Core.IPUserService;
using System.Data.SqlClient;
using System.Data;
using WebDS;


namespace WebUS{

public class US_V_GD_THANH_TOAN_DETAIL : US_Object
{
	private const string c_TableName = "V_GD_THANH_TOAN_DETAIL";
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

	public decimal dcID_GD_THANH_TOAN 
	{
		get
		{
			return CNull.RowNVLDecimal(pm_objDR, "ID_GD_THANH_TOAN", IPConstants.c_DefaultDecimal);
		}
		set	
		{
			pm_objDR["ID_GD_THANH_TOAN"] = value;
		}
	}

	public bool IsID_GD_THANH_TOANNull()	{
		return pm_objDR.IsNull("ID_GD_THANH_TOAN");
	}

	public void SetID_GD_THANH_TOANNull() {
		pm_objDR["ID_GD_THANH_TOAN"] = System.Convert.DBNull;
	}

	public string strDESCRIPTION 
	{
		get 
		{
			return CNull.RowNVLString(pm_objDR, "DESCRIPTION", IPConstants.c_DefaultString);
		}
		set 
		{
			pm_objDR["DESCRIPTION"] = value;
		}
	}

	public bool IsDESCRIPTIONNull() 
	{
		return pm_objDR.IsNull("DESCRIPTION");
	}

	public void SetDESCRIPTIONNull() {
		pm_objDR["DESCRIPTION"] = System.Convert.DBNull;
	}

	public decimal dcID_HOP_DONG_KHUNG 
	{
		get
		{
			return CNull.RowNVLDecimal(pm_objDR, "ID_HOP_DONG_KHUNG", IPConstants.c_DefaultDecimal);
		}
		set	
		{
			pm_objDR["ID_HOP_DONG_KHUNG"] = value;
		}
	}

	public bool IsID_HOP_DONG_KHUNGNull()	{
		return pm_objDR.IsNull("ID_HOP_DONG_KHUNG");
	}

	public void SetID_HOP_DONG_KHUNGNull() {
		pm_objDR["ID_HOP_DONG_KHUNG"] = System.Convert.DBNull;
	}

	public decimal dcID_NOI_DUNG_THANH_TOAN 
	{
		get
		{
			return CNull.RowNVLDecimal(pm_objDR, "ID_NOI_DUNG_THANH_TOAN", IPConstants.c_DefaultDecimal);
		}
		set	
		{
			pm_objDR["ID_NOI_DUNG_THANH_TOAN"] = value;
		}
	}

	public bool IsID_NOI_DUNG_THANH_TOANNull()	{
		return pm_objDR.IsNull("ID_NOI_DUNG_THANH_TOAN");
	}

	public void SetID_NOI_DUNG_THANH_TOANNull() {
		pm_objDR["ID_NOI_DUNG_THANH_TOAN"] = System.Convert.DBNull;
	}

	public string strNOI_DUNG_THANH_TOAN 
	{
		get 
		{
			return CNull.RowNVLString(pm_objDR, "NOI_DUNG_THANH_TOAN", IPConstants.c_DefaultString);
		}
		set 
		{
			pm_objDR["NOI_DUNG_THANH_TOAN"] = value;
		}
	}

	public bool IsNOI_DUNG_THANH_TOANNull() 
	{
		return pm_objDR.IsNull("NOI_DUNG_THANH_TOAN");
	}

	public void SetNOI_DUNG_THANH_TOANNull() {
		pm_objDR["NOI_DUNG_THANH_TOAN"] = System.Convert.DBNull;
	}

	public decimal dcSO_LUONG_HE_SO 
	{
		get
		{
			return CNull.RowNVLDecimal(pm_objDR, "SO_LUONG_HE_SO", IPConstants.c_DefaultDecimal);
		}
		set	
		{
			pm_objDR["SO_LUONG_HE_SO"] = value;
		}
	}

	public bool IsSO_LUONG_HE_SONull()	{
		return pm_objDR.IsNull("SO_LUONG_HE_SO");
	}

	public void SetSO_LUONG_HE_SONull() {
		pm_objDR["SO_LUONG_HE_SO"] = System.Convert.DBNull;
	}

	public string strMA_DON_VI_TINH 
	{
		get 
		{
			return CNull.RowNVLString(pm_objDR, "MA_DON_VI_TINH", IPConstants.c_DefaultString);
		}
		set 
		{
			pm_objDR["MA_DON_VI_TINH"] = value;
		}
	}

	public bool IsMA_DON_VI_TINHNull() 
	{
		return pm_objDR.IsNull("MA_DON_VI_TINH");
	}

	public void SetMA_DON_VI_TINHNull() {
		pm_objDR["MA_DON_VI_TINH"] = System.Convert.DBNull;
	}

	public string strDON_VI_TINH 
	{
		get 
		{
			return CNull.RowNVLString(pm_objDR, "DON_VI_TINH", IPConstants.c_DefaultString);
		}
		set 
		{
			pm_objDR["DON_VI_TINH"] = value;
		}
	}

	public bool IsDON_VI_TINHNull() 
	{
		return pm_objDR.IsNull("DON_VI_TINH");
	}

	public void SetDON_VI_TINHNull() {
		pm_objDR["DON_VI_TINH"] = System.Convert.DBNull;
	}

	public string strMA_TAN_SUAT 
	{
		get 
		{
			return CNull.RowNVLString(pm_objDR, "MA_TAN_SUAT", IPConstants.c_DefaultString);
		}
		set 
		{
			pm_objDR["MA_TAN_SUAT"] = value;
		}
	}

	public bool IsMA_TAN_SUATNull() 
	{
		return pm_objDR.IsNull("MA_TAN_SUAT");
	}

	public void SetMA_TAN_SUATNull() {
		pm_objDR["MA_TAN_SUAT"] = System.Convert.DBNull;
	}

	public string strTAN_SUAT 
	{
		get 
		{
			return CNull.RowNVLString(pm_objDR, "TAN_SUAT", IPConstants.c_DefaultString);
		}
		set 
		{
			pm_objDR["TAN_SUAT"] = value;
		}
	}

	public bool IsTAN_SUATNull() 
	{
		return pm_objDR.IsNull("TAN_SUAT");
	}

	public void SetTAN_SUATNull() {
		pm_objDR["TAN_SUAT"] = System.Convert.DBNull;
	}

	public decimal dcDON_GIA_TT 
	{
		get
		{
			return CNull.RowNVLDecimal(pm_objDR, "DON_GIA_TT", IPConstants.c_DefaultDecimal);
		}
		set	
		{
			pm_objDR["DON_GIA_TT"] = value;
		}
	}

	public bool IsDON_GIA_TTNull()	{
		return pm_objDR.IsNull("DON_GIA_TT");
	}

	public void SetDON_GIA_TTNull() {
		pm_objDR["DON_GIA_TT"] = System.Convert.DBNull;
	}

	public string strREFERENCE_CODE 
	{
		get 
		{
			return CNull.RowNVLString(pm_objDR, "REFERENCE_CODE", IPConstants.c_DefaultString);
		}
		set 
		{
			pm_objDR["REFERENCE_CODE"] = value;
		}
	}

	public bool IsREFERENCE_CODENull() 
	{
		return pm_objDR.IsNull("REFERENCE_CODE");
	}

	public void SetREFERENCE_CODENull() {
		pm_objDR["REFERENCE_CODE"] = System.Convert.DBNull;
	}

#endregion
#region "Init Functions"
	public US_V_GD_THANH_TOAN_DETAIL() 
	{
		pm_objDS = new DS_V_GD_THANH_TOAN_DETAIL();
		pm_strTableName = c_TableName;
		pm_objDR = pm_objDS.Tables[pm_strTableName].NewRow();
	}

	public US_V_GD_THANH_TOAN_DETAIL(DataRow i_objDR): this()
	{
		this.DataRow2Me(i_objDR);
	}

	public US_V_GD_THANH_TOAN_DETAIL(decimal i_dbID) 
	{
		pm_objDS = new DS_V_GD_THANH_TOAN_DETAIL();
		pm_strTableName = c_TableName;
		IMakeSelectCmd v_objMkCmd = new CMakeAndSelectCmd(pm_objDS, c_TableName);
		v_objMkCmd.AddCondition("ID", i_dbID, eKieuDuLieu.KieuNumber, eKieuSoSanh.Bang);
		SqlCommand v_cmdSQL;
		v_cmdSQL = v_objMkCmd.getSelectCmd();
		this.FillDatasetByCommand(pm_objDS, v_cmdSQL);
		pm_objDR = getRowClone(pm_objDS.Tables[pm_strTableName].Rows[0]);
	}
#endregion
	}
}