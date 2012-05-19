///************************************************
/// Generated by: linhdh
/// Date: 16/09/2011 12:39:52
/// Goal: Create User Service Class for DM_MON_HOC
///************************************************
/// <summary>
/// Create User Service Class for DM_MON_HOC
/// </summary>

using System;
using IP.Core.IPCommon;
using IP.Core.IPUserService;
using System.Data.SqlClient;
using System.Data;
using WebDS;
using WebDS.CDBNames;


namespace WebUS{

public class US_DM_MON_HOC : US_Object
{
	private const string c_TableName = "DM_MON_HOC";
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

	public string strMA_MON_HOC 
	{
		get 
		{
			return CNull.RowNVLString(pm_objDR, "MA_MON_HOC", IPConstants.c_DefaultString);
		}
		set 
		{
			pm_objDR["MA_MON_HOC"] = value;
		}
	}

	public bool IsMA_MON_HOCNull() 
	{
		return pm_objDR.IsNull("MA_MON_HOC");
	}

	public void SetMA_MON_HOCNull() {
		pm_objDR["MA_MON_HOC"] = System.Convert.DBNull;
	}

	public string strTEN_MON_HOC 
	{
		get 
		{
			return CNull.RowNVLString(pm_objDR, "TEN_MON_HOC", IPConstants.c_DefaultString);
		}
		set 
		{
			pm_objDR["TEN_MON_HOC"] = value;
		}
	}

	public bool IsTEN_MON_HOCNull() 
	{
		return pm_objDR.IsNull("TEN_MON_HOC");
	}

	public void SetTEN_MON_HOCNull() {
		pm_objDR["TEN_MON_HOC"] = System.Convert.DBNull;
	}

	public decimal dcSO_DVHT 
	{
		get
		{
			return CNull.RowNVLDecimal(pm_objDR, "SO_DVHT", IPConstants.c_DefaultDecimal);
		}
		set	
		{
			pm_objDR["SO_DVHT"] = value;
		}
	}

	public bool IsSO_DVHTNull()	{
		return pm_objDR.IsNull("SO_DVHT");
	}

	public void SetSO_DVHTNull() {
		pm_objDR["SO_DVHT"] = System.Convert.DBNull;
	}

	public string strGHI_CHU 
	{
		get 
		{
			return CNull.RowNVLString(pm_objDR, "GHI_CHU", IPConstants.c_DefaultString);
		}
		set 
		{
			pm_objDR["GHI_CHU"] = value;
		}
	}

	public bool IsGHI_CHUNull() 
	{
		return pm_objDR.IsNull("GHI_CHU");
	}

	public void SetGHI_CHUNull() {
		pm_objDR["GHI_CHU"] = System.Convert.DBNull;
	}

#endregion
#region "Init Functions"
	public US_DM_MON_HOC() 
	{
		pm_objDS = new DS_DM_MON_HOC();
		pm_strTableName = c_TableName;
		pm_objDR = pm_objDS.Tables[pm_strTableName].NewRow();
	}

	public US_DM_MON_HOC(DataRow i_objDR): this()
	{
		this.DataRow2Me(i_objDR);
	}

	public US_DM_MON_HOC(decimal i_dbID) 
	{
		pm_objDS = new DS_DM_MON_HOC();
		pm_strTableName = c_TableName;
		IMakeSelectCmd v_objMkCmd = new CMakeAndSelectCmd(pm_objDS, c_TableName);
		v_objMkCmd.AddCondition("ID", i_dbID, eKieuDuLieu.KieuNumber, eKieuSoSanh.Bang);
		SqlCommand v_cmdSQL;
		v_cmdSQL = v_objMkCmd.getSelectCmd();
		this.FillDatasetByCommand(pm_objDS, v_cmdSQL);
		pm_objDR = getRowClone(pm_objDS.Tables[pm_strTableName].Rows[0]);
	}
#endregion

    #region Additional functions
    public bool check_exist_ma_mon(string ip_str_ma_mon)
    {
        US_DM_MON_HOC v_us_mon_hoc = new US_DM_MON_HOC();
        DS_DM_MON_HOC v_ds_mon_hoc = new DS_DM_MON_HOC();

        v_us_mon_hoc.FillDataset(v_ds_mon_hoc, " where MA_MON_HOC = '" + ip_str_ma_mon + "'");
        if (v_ds_mon_hoc.DM_MON_HOC.Rows.Count == 0) return true;
        return false;
    }
    public bool check_exist_ma_mon_update(string ip_str_ma_mon_moi, string ip_str_ma_mon_ban_dau)
    {
        US_DM_MON_HOC v_us_mon_hoc = new US_DM_MON_HOC();
        DS_DM_MON_HOC v_ds_mon_hoc = new DS_DM_MON_HOC();

        v_us_mon_hoc.FillDataset(v_ds_mon_hoc, " where MA_MON_HOC = '" + ip_str_ma_mon_moi + "'");
        if (v_ds_mon_hoc.DM_MON_HOC.Rows.Count == 0) return true;
        else if (v_ds_mon_hoc.DM_MON_HOC.Rows[0][DM_MON_HOC.MA_MON_HOC].ToString().Equals(ip_str_ma_mon_ban_dau)) return true;
        return false;
    }

    public void search_mon_hoc(string ip_str_tu_khoa, DS_DM_MON_HOC op_ds_dm_mon_hoc)
    {
        CStoredProc v_store = new CStoredProc("pr_V_DM_MON_HOC_Search");
        v_store.addNVarcharInputParam("@TU_KHOA", ip_str_tu_khoa);
        v_store.fillDataSetByCommand(this,op_ds_dm_mon_hoc);
    }
    #endregion
}
}