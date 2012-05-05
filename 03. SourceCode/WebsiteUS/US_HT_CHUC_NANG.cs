///************************************************
/// Generated by: linhdh
/// Date: 26/02/2012 12:29:46
/// Goal: Create User Service Class for HT_CHUC_NANG
///************************************************
/// <summary>
/// Create User Service Class for HT_CHUC_NANG
/// </summary>

using System;
using IP.Core.IPCommon;
using IP.Core.IPUserService;
using System.Data.SqlClient;
using System.Data;
using WebDS;


namespace WebUS{

public class US_HT_CHUC_NANG : US_Object
{
	private const string c_TableName = "HT_CHUC_NANG";
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

	public string strTEN_CHUC_NANG 
	{
		get 
		{
			return CNull.RowNVLString(pm_objDR, "TEN_CHUC_NANG", IPConstants.c_DefaultString);
		}
		set 
		{
			pm_objDR["TEN_CHUC_NANG"] = value;
		}
	}

	public bool IsTEN_CHUC_NANGNull() 
	{
		return pm_objDR.IsNull("TEN_CHUC_NANG");
	}

	public void SetTEN_CHUC_NANGNull() {
		pm_objDR["TEN_CHUC_NANG"] = System.Convert.DBNull;
	}

	public string strURL_FORM 
	{
		get 
		{
			return CNull.RowNVLString(pm_objDR, "URL_FORM", IPConstants.c_DefaultString);
		}
		set 
		{
			pm_objDR["URL_FORM"] = value;
		}
	}

	public bool IsURL_FORMNull() 
	{
		return pm_objDR.IsNull("URL_FORM");
	}

	public void SetURL_FORMNull() {
		pm_objDR["URL_FORM"] = System.Convert.DBNull;
	}

	public string strTRANG_THAI_YN 
	{
		get 
		{
			return CNull.RowNVLString(pm_objDR, "TRANG_THAI_YN", IPConstants.c_DefaultString);
		}
		set 
		{
			pm_objDR["TRANG_THAI_YN"] = value;
		}
	}

	public bool IsTRANG_THAI_YNNull() 
	{
		return pm_objDR.IsNull("TRANG_THAI_YN");
	}

	public void SetTRANG_THAI_YNNull() {
		pm_objDR["TRANG_THAI_YN"] = System.Convert.DBNull;
	}

	public decimal dcVI_TRI 
	{
		get
		{
			return CNull.RowNVLDecimal(pm_objDR, "VI_TRI", IPConstants.c_DefaultDecimal);
		}
		set	
		{
			pm_objDR["VI_TRI"] = value;
		}
	}

	public bool IsVI_TRINull()	{
		return pm_objDR.IsNull("VI_TRI");
	}

	public void SetVI_TRINull() {
		pm_objDR["VI_TRI"] = System.Convert.DBNull;
	}

	public decimal dcCHUC_NANG_PARENT_ID 
	{
		get
		{
			return CNull.RowNVLDecimal(pm_objDR, "CHUC_NANG_PARENT_ID", IPConstants.c_DefaultDecimal);
		}
		set	
		{
			pm_objDR["CHUC_NANG_PARENT_ID"] = value;
		}
	}

	public bool IsCHUC_NANG_PARENT_IDNull()	{
		return pm_objDR.IsNull("CHUC_NANG_PARENT_ID");
	}

	public void SetCHUC_NANG_PARENT_IDNull() {
		pm_objDR["CHUC_NANG_PARENT_ID"] = System.Convert.DBNull;
	}

	public string strHIEN_THI_YN 
	{
		get 
		{
			return CNull.RowNVLString(pm_objDR, "HIEN_THI_YN", IPConstants.c_DefaultString);
		}
		set 
		{
			pm_objDR["HIEN_THI_YN"] = value;
		}
	}

	public bool IsHIEN_THI_YNNull() 
	{
		return pm_objDR.IsNull("HIEN_THI_YN");
	}

	public void SetHIEN_THI_YNNull() {
		pm_objDR["HIEN_THI_YN"] = System.Convert.DBNull;
	}

#endregion
#region "Init Functions"
	public US_HT_CHUC_NANG() 
	{
		pm_objDS = new DS_HT_CHUC_NANG();
		pm_strTableName = c_TableName;
		pm_objDR = pm_objDS.Tables[pm_strTableName].NewRow();
	}

	public US_HT_CHUC_NANG(DataRow i_objDR): this()
	{
		this.DataRow2Me(i_objDR);
	}

	public US_HT_CHUC_NANG(decimal i_dbID) 
	{
		pm_objDS = new DS_HT_CHUC_NANG();
		pm_strTableName = c_TableName;
		IMakeSelectCmd v_objMkCmd = new CMakeAndSelectCmd(pm_objDS, c_TableName);
		v_objMkCmd.AddCondition("ID", i_dbID, eKieuDuLieu.KieuNumber, eKieuSoSanh.Bang);
		SqlCommand v_cmdSQL;
		v_cmdSQL = v_objMkCmd.getSelectCmd();
		this.FillDatasetByCommand(pm_objDS, v_cmdSQL);
		pm_objDR = getRowClone(pm_objDS.Tables[pm_strTableName].Rows[0]);
	}
#endregion

    #region Additional Methods
    public void get_parent_table(string ip_str_user_name, DS_HT_CHUC_NANG ip_ds_ht_chuc_nang)
    {
        CStoredProc v_cstore = new CStoredProc("pr_HT_CHUC_NANG_GetQuyenChucNang");
        v_cstore.addNVarcharInputParam("@USER_NAME", ip_str_user_name);
        v_cstore.fillDataSetByCommand(this, ip_ds_ht_chuc_nang);
    }
    public void get_child_menu(decimal ip_dc_parent_id, string ip_str_user_name, DS_HT_CHUC_NANG ip_ds_ht_chuc_nang_con)
    {
        CStoredProc v_cstore = new CStoredProc("pr_HT_CHUC_NANG_GetQuyenChucNang_Con");
        v_cstore.addNVarcharInputParam("@PARENT_ID", ip_dc_parent_id);
        v_cstore.fillDataSetByCommand(this, ip_ds_ht_chuc_nang_con);
    }
    #endregion
	}
}