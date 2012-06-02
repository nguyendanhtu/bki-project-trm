///************************************************
/// Generated by: linhdh
/// Date: 02/06/2012 10:17:09
/// Goal: Create User Service Class for V_GD_ASSIGN_SU_KIEN_GIANG_VIEN
///************************************************
/// <summary>
/// Create User Service Class for V_GD_ASSIGN_SU_KIEN_GIANG_VIEN
/// </summary>

using System;
using IP.Core.IPCommon;
using IP.Core.IPUserService;
using System.Data.SqlClient;
using System.Data;
using WebDS;


namespace WebUS{

public class US_V_GD_ASSIGN_SU_KIEN_GIANG_VIEN : US_Object
{
	private const string c_TableName = "V_GD_ASSIGN_SU_KIEN_GIANG_VIEN";
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

	public decimal dcID_LOAI_SU_KIEN 
	{
		get
		{
			return CNull.RowNVLDecimal(pm_objDR, "ID_LOAI_SU_KIEN", IPConstants.c_DefaultDecimal);
		}
		set	
		{
			pm_objDR["ID_LOAI_SU_KIEN"] = value;
		}
	}

	public bool IsID_LOAI_SU_KIENNull()	{
		return pm_objDR.IsNull("ID_LOAI_SU_KIEN");
	}

	public void SetID_LOAI_SU_KIENNull() {
		pm_objDR["ID_LOAI_SU_KIEN"] = System.Convert.DBNull;
	}

	public decimal dcID_SU_KIEN 
	{
		get
		{
			return CNull.RowNVLDecimal(pm_objDR, "ID_SU_KIEN", IPConstants.c_DefaultDecimal);
		}
		set	
		{
			pm_objDR["ID_SU_KIEN"] = value;
		}
	}

	public bool IsID_SU_KIENNull()	{
		return pm_objDR.IsNull("ID_SU_KIEN");
	}

	public void SetID_SU_KIENNull() {
		pm_objDR["ID_SU_KIEN"] = System.Convert.DBNull;
	}

	public decimal dcID_GIANG_VIEN 
	{
		get
		{
			return CNull.RowNVLDecimal(pm_objDR, "ID_GIANG_VIEN", IPConstants.c_DefaultDecimal);
		}
		set	
		{
			pm_objDR["ID_GIANG_VIEN"] = value;
		}
	}

	public bool IsID_GIANG_VIENNull()	{
		return pm_objDR.IsNull("ID_GIANG_VIEN");
	}

	public void SetID_GIANG_VIENNull() {
		pm_objDR["ID_GIANG_VIEN"] = System.Convert.DBNull;
	}

	public decimal dcID_VAI_TRO_GV 
	{
		get
		{
			return CNull.RowNVLDecimal(pm_objDR, "ID_VAI_TRO_GV", IPConstants.c_DefaultDecimal);
		}
		set	
		{
			pm_objDR["ID_VAI_TRO_GV"] = value;
		}
	}

	public bool IsID_VAI_TRO_GVNull()	{
		return pm_objDR.IsNull("ID_VAI_TRO_GV");
	}

	public void SetID_VAI_TRO_GVNull() {
		pm_objDR["ID_VAI_TRO_GV"] = System.Convert.DBNull;
	}

	public decimal dcID_HOP_DONG 
	{
		get
		{
			return CNull.RowNVLDecimal(pm_objDR, "ID_HOP_DONG", IPConstants.c_DefaultDecimal);
		}
		set	
		{
			pm_objDR["ID_HOP_DONG"] = value;
		}
	}

	public bool IsID_HOP_DONGNull()	{
		return pm_objDR.IsNull("ID_HOP_DONG");
	}

	public void SetID_HOP_DONGNull() {
		pm_objDR["ID_HOP_DONG"] = System.Convert.DBNull;
	}

	public decimal dcID_TRANG_THAI 
	{
		get
		{
			return CNull.RowNVLDecimal(pm_objDR, "ID_TRANG_THAI", IPConstants.c_DefaultDecimal);
		}
		set	
		{
			pm_objDR["ID_TRANG_THAI"] = value;
		}
	}

	public bool IsID_TRANG_THAINull()	{
		return pm_objDR.IsNull("ID_TRANG_THAI");
	}

	public void SetID_TRANG_THAINull() {
		pm_objDR["ID_TRANG_THAI"] = System.Convert.DBNull;
	}

	public decimal dcID_USER_LAP 
	{
		get
		{
			return CNull.RowNVLDecimal(pm_objDR, "ID_USER_LAP", IPConstants.c_DefaultDecimal);
		}
		set	
		{
			pm_objDR["ID_USER_LAP"] = value;
		}
	}

	public bool IsID_USER_LAPNull()	{
		return pm_objDR.IsNull("ID_USER_LAP");
	}

	public void SetID_USER_LAPNull() {
		pm_objDR["ID_USER_LAP"] = System.Convert.DBNull;
	}

	public decimal dcSO_TIEN_GV_HUONG 
	{
		get
		{
			return CNull.RowNVLDecimal(pm_objDR, "SO_TIEN_GV_HUONG", IPConstants.c_DefaultDecimal);
		}
		set	
		{
			pm_objDR["SO_TIEN_GV_HUONG"] = value;
		}
	}

	public bool IsSO_TIEN_GV_HUONGNull()	{
		return pm_objDR.IsNull("SO_TIEN_GV_HUONG");
	}

	public void SetSO_TIEN_GV_HUONGNull() {
		pm_objDR["SO_TIEN_GV_HUONG"] = System.Convert.DBNull;
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

	public string strTHANH_TOAN_NGAY_YN 
	{
		get 
		{
			return CNull.RowNVLString(pm_objDR, "THANH_TOAN_NGAY_YN", IPConstants.c_DefaultString);
		}
		set 
		{
			pm_objDR["THANH_TOAN_NGAY_YN"] = value;
		}
	}

	public bool IsTHANH_TOAN_NGAY_YNNull() 
	{
		return pm_objDR.IsNull("THANH_TOAN_NGAY_YN");
	}

	public void SetTHANH_TOAN_NGAY_YNNull() {
		pm_objDR["THANH_TOAN_NGAY_YN"] = System.Convert.DBNull;
	}

	public string strSO_HOP_DONG 
	{
		get 
		{
			return CNull.RowNVLString(pm_objDR, "SO_HOP_DONG", IPConstants.c_DefaultString);
		}
		set 
		{
			pm_objDR["SO_HOP_DONG"] = value;
		}
	}

	public bool IsSO_HOP_DONGNull() 
	{
		return pm_objDR.IsNull("SO_HOP_DONG");
	}

	public void SetSO_HOP_DONGNull() {
		pm_objDR["SO_HOP_DONG"] = System.Convert.DBNull;
	}

	public string strHO_VA_TEN_GIANG_VIEN 
	{
		get 
		{
			return CNull.RowNVLString(pm_objDR, "HO_VA_TEN_GIANG_VIEN", IPConstants.c_DefaultString);
		}
		set 
		{
			pm_objDR["HO_VA_TEN_GIANG_VIEN"] = value;
		}
	}

	public bool IsHO_VA_TEN_GIANG_VIENNull() 
	{
		return pm_objDR.IsNull("HO_VA_TEN_GIANG_VIEN");
	}

	public void SetHO_VA_TEN_GIANG_VIENNull() {
		pm_objDR["HO_VA_TEN_GIANG_VIEN"] = System.Convert.DBNull;
	}

	public string strTEN_TRUY_CAP 
	{
		get 
		{
			return CNull.RowNVLString(pm_objDR, "TEN_TRUY_CAP", IPConstants.c_DefaultString);
		}
		set 
		{
			pm_objDR["TEN_TRUY_CAP"] = value;
		}
	}

	public bool IsTEN_TRUY_CAPNull() 
	{
		return pm_objDR.IsNull("TEN_TRUY_CAP");
	}

	public void SetTEN_TRUY_CAPNull() {
		pm_objDR["TEN_TRUY_CAP"] = System.Convert.DBNull;
	}

	public string strTEN_USER_LAP 
	{
		get 
		{
			return CNull.RowNVLString(pm_objDR, "TEN_USER_LAP", IPConstants.c_DefaultString);
		}
		set 
		{
			pm_objDR["TEN_USER_LAP"] = value;
		}
	}

	public bool IsTEN_USER_LAPNull() 
	{
		return pm_objDR.IsNull("TEN_USER_LAP");
	}

	public void SetTEN_USER_LAPNull() {
		pm_objDR["TEN_USER_LAP"] = System.Convert.DBNull;
	}

#endregion
#region "Init Functions"
	public US_V_GD_ASSIGN_SU_KIEN_GIANG_VIEN() 
	{
		pm_objDS = new DS_V_GD_ASSIGN_SU_KIEN_GIANG_VIEN();
		pm_strTableName = c_TableName;
		pm_objDR = pm_objDS.Tables[pm_strTableName].NewRow();
	}

	public US_V_GD_ASSIGN_SU_KIEN_GIANG_VIEN(DataRow i_objDR): this()
	{
		this.DataRow2Me(i_objDR);
	}

	public US_V_GD_ASSIGN_SU_KIEN_GIANG_VIEN(decimal i_dbID) 
	{
		pm_objDS = new DS_V_GD_ASSIGN_SU_KIEN_GIANG_VIEN();
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
    public void loc_du_lieu_assign_su_kien_giang_vien(DS_V_GD_ASSIGN_SU_KIEN_GIANG_VIEN op_us_v_gd_assign_su_kien_giang_vien, decimal ip_dc_id_su_kien,
                                                                                decimal ip_dc_id_giang_vien,
                                                                                decimal ip_dc_id_vai_tro,
                                                                                decimal ip_dc_id_hop_dong,
                                                                                decimal ip_dc_id_trang_thai,
                                                                                string ip_dc_thanh_toan_ngay_yn,
                                                                                string ip_str_tu_khoa)
    {
        CStoredProc v_cstore = new CStoredProc("pr_GD_ASSIGN_SU_KIEN_GIANG_VIEN_Search");
        v_cstore.addDecimalInputParam("@ID_SU_KIEN", ip_dc_id_su_kien);
        v_cstore.addDecimalInputParam("@ID_GIANG_VIEN", ip_dc_id_giang_vien);
        v_cstore.addDecimalInputParam("@ID_VAI_TRO", ip_dc_id_vai_tro);
        v_cstore.addDecimalInputParam("@ID_HOP_DONG", ip_dc_id_hop_dong);
        v_cstore.addDecimalInputParam("@ID_TRANG_THAI", ip_dc_id_trang_thai);
        v_cstore.addNVarcharInputParam("@THANH_TOAN_NGAY_YN", ip_dc_thanh_toan_ngay_yn);
        v_cstore.addNVarcharInputParam("@TU_KHOA", ip_str_tu_khoa);
        v_cstore.fillDataSetByCommand(this, op_us_v_gd_assign_su_kien_giang_vien);
    }


    #endregion
	}
}
