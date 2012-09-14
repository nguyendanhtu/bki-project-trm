///************************************************
/// Generated by: linhdh
/// Date: 17/07/2012 07:28:27
/// Goal: Create User Service Class for RPT_BAO_CAO_TONG_HOP_CONG_VIEC_GVCM
///************************************************
/// <summary>
/// Create User Service Class for RPT_BAO_CAO_TONG_HOP_CONG_VIEC_GVCM
/// </summary>

using System;
using IP.Core.IPCommon;
using IP.Core.IPUserService;
using System.Data.SqlClient;
using System.Data;
using WebDS;


namespace WebUS{

public class US_RPT_BAO_CAO_TONG_HOP_CONG_VIEC_GVCM : US_Object
{
	private const string c_TableName = "RPT_BAO_CAO_TONG_HOP_CONG_VIEC_GVCM";
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

	public decimal dcID_NOI_DUNG_GOC 
	{
		get
		{
			return CNull.RowNVLDecimal(pm_objDR, "ID_NOI_DUNG_GOC", IPConstants.c_DefaultDecimal);
		}
		set	
		{
			pm_objDR["ID_NOI_DUNG_GOC"] = value;
		}
	}

	public bool IsID_NOI_DUNG_GOCNull()	{
		return pm_objDR.IsNull("ID_NOI_DUNG_GOC");
	}

	public void SetID_NOI_DUNG_GOCNull() {
		pm_objDR["ID_NOI_DUNG_GOC"] = System.Convert.DBNull;
	}

	public decimal dcTONG_SO_LUONG 
	{
		get
		{
			return CNull.RowNVLDecimal(pm_objDR, "TONG_SO_LUONG", IPConstants.c_DefaultDecimal);
		}
		set	
		{
			pm_objDR["TONG_SO_LUONG"] = value;
		}
	}

	public bool IsTONG_SO_LUONGNull()	{
		return pm_objDR.IsNull("TONG_SO_LUONG");
	}

	public void SetTONG_SO_LUONGNull() {
		pm_objDR["TONG_SO_LUONG"] = System.Convert.DBNull;
	}

	public string strTEN_NOI_DUNG 
	{
		get 
		{
			return CNull.RowNVLString(pm_objDR, "TEN_NOI_DUNG", IPConstants.c_DefaultString);
		}
		set 
		{
			pm_objDR["TEN_NOI_DUNG"] = value;
		}
	}

	public bool IsTEN_NOI_DUNGNull() 
	{
		return pm_objDR.IsNull("TEN_NOI_DUNG");
	}

	public void SetTEN_NOI_DUNGNull() {
		pm_objDR["TEN_NOI_DUNG"] = System.Convert.DBNull;
	}

	public decimal dcDON_GIA 
	{
		get
		{
			return CNull.RowNVLDecimal(pm_objDR, "DON_GIA", IPConstants.c_DefaultDecimal);
		}
		set	
		{
			pm_objDR["DON_GIA"] = value;
		}
	}

	public bool IsDON_GIANull()	{
		return pm_objDR.IsNull("DON_GIA");
	}

	public void SetDON_GIANull() {
		pm_objDR["DON_GIA"] = System.Convert.DBNull;
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

	public decimal dcTHANH_TIEN 
	{
		get
		{
			return CNull.RowNVLDecimal(pm_objDR, "THANH_TIEN", IPConstants.c_DefaultDecimal);
		}
		set	
		{
			pm_objDR["THANH_TIEN"] = value;
		}
	}

	public bool IsTHANH_TIENNull()	{
		return pm_objDR.IsNull("THANH_TIEN");
	}

	public void SetTHANH_TIENNull() {
		pm_objDR["THANH_TIEN"] = System.Convert.DBNull;
	}

#endregion
#region "Init Functions"
	public US_RPT_BAO_CAO_TONG_HOP_CONG_VIEC_GVCM() 
	{
		pm_objDS = new DS_RPT_BAO_CAO_TONG_HOP_CONG_VIEC_GVCM();
		pm_strTableName = c_TableName;
		pm_objDR = pm_objDS.Tables[pm_strTableName].NewRow();
	}

	public US_RPT_BAO_CAO_TONG_HOP_CONG_VIEC_GVCM(DataRow i_objDR): this()
	{
		this.DataRow2Me(i_objDR);
	}

	public US_RPT_BAO_CAO_TONG_HOP_CONG_VIEC_GVCM(decimal i_dbID) 
	{
		pm_objDS = new DS_RPT_BAO_CAO_TONG_HOP_CONG_VIEC_GVCM();
		pm_strTableName = c_TableName;
		IMakeSelectCmd v_objMkCmd = new CMakeAndSelectCmd(pm_objDS, c_TableName);
		v_objMkCmd.AddCondition("ID", i_dbID, eKieuDuLieu.KieuNumber, eKieuSoSanh.Bang);
		SqlCommand v_cmdSQL;
		v_cmdSQL = v_objMkCmd.getSelectCmd();
		this.FillDatasetByCommand(pm_objDS, v_cmdSQL);
		pm_objDR = getRowClone(pm_objDS.Tables[pm_strTableName].Rows[0]);
	}
#endregion

    #region Additional Functions
    public void load_data_2_export_bao_cao_706(DS_RPT_BAO_CAO_TONG_HOP_CONG_VIEC_GVCM op_ds_v_gd_cv_moi, decimal ip_dc_thang_dat_hang, decimal ip_dc_nam_dat_hang, decimal ip_dc_id_trang_thai_cv)
    {
        CStoredProc v_cstore = new CStoredProc("pr_GD_GV_CONG_VIEC_MOI_Load_Cong_Viec_Export_Bao_Cao_706");
        v_cstore.addDecimalInputParam("@THANG_DAT_HANG", ip_dc_thang_dat_hang);
        v_cstore.addDecimalInputParam("@NAM_DAT_HANG", ip_dc_nam_dat_hang);
        v_cstore.addDecimalInputParam("@ID_TRANG_THAI_CV", ip_dc_id_trang_thai_cv);
        v_cstore.fillDataSetByCommand(this, op_ds_v_gd_cv_moi);
    }
    #endregion
}
}