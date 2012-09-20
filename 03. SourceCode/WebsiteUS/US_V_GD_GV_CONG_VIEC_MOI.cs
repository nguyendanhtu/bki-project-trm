///************************************************
/// Generated by: linhdh
/// Date: 18/06/2012 12:57:30
/// Goal: Create User Service Class for V_GD_GV_CONG_VIEC_MOI
///************************************************
/// <summary>
/// Create User Service Class for V_GD_GV_CONG_VIEC_MOI
/// </summary>

using System;
using IP.Core.IPCommon;
using IP.Core.IPUserService;
using System.Data.SqlClient;
using System.Data;
using WebDS;


namespace WebUS{

public class US_V_GD_GV_CONG_VIEC_MOI : US_Object
{
	private const string c_TableName = "V_GD_GV_CONG_VIEC_MOI";
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

    public bool IsIDNull()
    {
        return pm_objDR.IsNull("ID");
    }

    public void SetIDNull()
    {
        pm_objDR["ID"] = System.Convert.DBNull;
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

    public bool IsID_HOP_DONG_KHUNGNull()
    {
        return pm_objDR.IsNull("ID_HOP_DONG_KHUNG");
    }

    public void SetID_HOP_DONG_KHUNGNull()
    {
        pm_objDR["ID_HOP_DONG_KHUNG"] = System.Convert.DBNull;
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

    public void SetSO_HOP_DONGNull()
    {
        pm_objDR["SO_HOP_DONG"] = System.Convert.DBNull;
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

    public bool IsID_GIANG_VIENNull()
    {
        return pm_objDR.IsNull("ID_GIANG_VIEN");
    }

    public void SetID_GIANG_VIENNull()
    {
        pm_objDR["ID_GIANG_VIEN"] = System.Convert.DBNull;
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

    public void SetHO_VA_TEN_GIANG_VIENNull()
    {
        pm_objDR["HO_VA_TEN_GIANG_VIEN"] = System.Convert.DBNull;
    }

    public decimal dcID_NOI_DUNG_TT
    {
        get
        {
            return CNull.RowNVLDecimal(pm_objDR, "ID_NOI_DUNG_TT", IPConstants.c_DefaultDecimal);
        }
        set
        {
            pm_objDR["ID_NOI_DUNG_TT"] = value;
        }
    }

    public bool IsID_NOI_DUNG_TTNull()
    {
        return pm_objDR.IsNull("ID_NOI_DUNG_TT");
    }

    public void SetID_NOI_DUNG_TTNull()
    {
        pm_objDR["ID_NOI_DUNG_TT"] = System.Convert.DBNull;
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

    public void SetTEN_NOI_DUNGNull()
    {
        pm_objDR["TEN_NOI_DUNG"] = System.Convert.DBNull;
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

    public bool IsID_NOI_DUNG_GOCNull()
    {
        return pm_objDR.IsNull("ID_NOI_DUNG_GOC");
    }

    public void SetID_NOI_DUNG_GOCNull()
    {
        pm_objDR["ID_NOI_DUNG_GOC"] = System.Convert.DBNull;
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

    public bool IsSO_LUONG_HE_SONull()
    {
        return pm_objDR.IsNull("SO_LUONG_HE_SO");
    }

    public void SetSO_LUONG_HE_SONull()
    {
        pm_objDR["SO_LUONG_HE_SO"] = System.Convert.DBNull;
    }

    public decimal dcSO_LUONG_NGHIEM_THU
    {
        get
        {
            return CNull.RowNVLDecimal(pm_objDR, "SO_LUONG_NGHIEM_THU", IPConstants.c_DefaultDecimal);
        }
        set
        {
            pm_objDR["SO_LUONG_NGHIEM_THU"] = value;
        }
    }

    public bool IsSO_LUONG_NGHIEM_THUNull()
    {
        return pm_objDR.IsNull("SO_LUONG_NGHIEM_THU");
    }

    public void SetSO_LUONG_NGHIEM_THUNull()
    {
        pm_objDR["SO_LUONG_NGHIEM_THU"] = System.Convert.DBNull;
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

    public bool IsDON_GIANull()
    {
        return pm_objDR.IsNull("DON_GIA");
    }

    public void SetDON_GIANull()
    {
        pm_objDR["DON_GIA"] = System.Convert.DBNull;
    }

    public DateTime datNGAY_DAT_HANG
    {
        get
        {
            return CNull.RowNVLDate(pm_objDR, "NGAY_DAT_HANG", IPConstants.c_DefaultDate);
        }
        set
        {
            pm_objDR["NGAY_DAT_HANG"] = value;
        }
    }

    public bool IsNGAY_DAT_HANGNull()
    {
        return pm_objDR.IsNull("NGAY_DAT_HANG");
    }

    public void SetNGAY_DAT_HANGNull()
    {
        pm_objDR["NGAY_DAT_HANG"] = System.Convert.DBNull;
    }

    public DateTime datNGAY_NGHIEM_THU
    {
        get
        {
            return CNull.RowNVLDate(pm_objDR, "NGAY_NGHIEM_THU", IPConstants.c_DefaultDate);
        }
        set
        {
            pm_objDR["NGAY_NGHIEM_THU"] = value;
        }
    }

    public bool IsNGAY_NGHIEM_THUNull()
    {
        return pm_objDR.IsNull("NGAY_NGHIEM_THU");
    }

    public void SetNGAY_NGHIEM_THUNull()
    {
        pm_objDR["NGAY_NGHIEM_THU"] = System.Convert.DBNull;
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

    public bool IsID_TRANG_THAINull()
    {
        return pm_objDR.IsNull("ID_TRANG_THAI");
    }

    public void SetID_TRANG_THAINull()
    {
        pm_objDR["ID_TRANG_THAI"] = System.Convert.DBNull;
    }

    public string strTEN_TRANG_THAI
    {
        get
        {
            return CNull.RowNVLString(pm_objDR, "TEN_TRANG_THAI", IPConstants.c_DefaultString);
        }
        set
        {
            pm_objDR["TEN_TRANG_THAI"] = value;
        }
    }

    public bool IsTEN_TRANG_THAINull()
    {
        return pm_objDR.IsNull("TEN_TRANG_THAI");
    }

    public void SetTEN_TRANG_THAINull()
    {
        pm_objDR["TEN_TRANG_THAI"] = System.Convert.DBNull;
    }

    public decimal dcID_USER_NHAP
    {
        get
        {
            return CNull.RowNVLDecimal(pm_objDR, "ID_USER_NHAP", IPConstants.c_DefaultDecimal);
        }
        set
        {
            pm_objDR["ID_USER_NHAP"] = value;
        }
    }

    public bool IsID_USER_NHAPNull()
    {
        return pm_objDR.IsNull("ID_USER_NHAP");
    }

    public void SetID_USER_NHAPNull()
    {
        pm_objDR["ID_USER_NHAP"] = System.Convert.DBNull;
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

    public void SetTEN_TRUY_CAPNull()
    {
        pm_objDR["TEN_TRUY_CAP"] = System.Convert.DBNull;
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

    public void SetGHI_CHUNull()
    {
        pm_objDR["GHI_CHU"] = System.Convert.DBNull;
    }

    public decimal dcTHANG_THANH_TOAN
    {
        get
        {
            return CNull.RowNVLDecimal(pm_objDR, "THANG_THANH_TOAN", IPConstants.c_DefaultDecimal);
        }
        set
        {
            pm_objDR["THANG_THANH_TOAN"] = value;
        }
    }

    public bool IsTHANG_THANH_TOANNull()
    {
        return pm_objDR.IsNull("THANG_THANH_TOAN");
    }

    public void SetTHANG_THANH_TOANNull()
    {
        pm_objDR["THANG_THANH_TOAN"] = System.Convert.DBNull;
    }

    public decimal dcNAM_THANH_TOAN
    {
        get
        {
            return CNull.RowNVLDecimal(pm_objDR, "NAM_THANH_TOAN", IPConstants.c_DefaultDecimal);
        }
        set
        {
            pm_objDR["NAM_THANH_TOAN"] = value;
        }
    }

    public bool IsNAM_THANH_TOANNull()
    {
        return pm_objDR.IsNull("NAM_THANH_TOAN");
    }

    public void SetNAM_THANH_TOANNull()
    {
        pm_objDR["NAM_THANH_TOAN"] = System.Convert.DBNull;
    }

    #endregion
    
    #region "Init Functions"
	public US_V_GD_GV_CONG_VIEC_MOI() 
	{
		pm_objDS = new DS_V_GD_GV_CONG_VIEC_MOI();
		pm_strTableName = c_TableName;
		pm_objDR = pm_objDS.Tables[pm_strTableName].NewRow();
	}

	public US_V_GD_GV_CONG_VIEC_MOI(DataRow i_objDR): this()
	{
		this.DataRow2Me(i_objDR);
	}

	public US_V_GD_GV_CONG_VIEC_MOI(decimal i_dbID) 
	{
		pm_objDS = new DS_V_GD_GV_CONG_VIEC_MOI();
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
    public void loc_du_lieu_gv_cong_viec_moi(DS_V_GD_GV_CONG_VIEC_MOI op_ds_v_gd_cv_moi, decimal ip_dc_hop_dong_khung, decimal ip_dc_trang_thai)
    {
        CStoredProc v_cstore = new CStoredProc("pr_V_GD_GV_CONG_VIEC_MOI_Loc_Duyet_Ke_Hoach");
        v_cstore.addDecimalInputParam("@ID_HOP_DONG_KHUNG", ip_dc_hop_dong_khung);
        v_cstore.addDecimalInputParam("@ID_TRANG_THAI", ip_dc_trang_thai);
        v_cstore.fillDataSetByCommand(this, op_ds_v_gd_cv_moi);
    }
    public void loc_du_lieu_gv_cong_viec_moi_theo_cbo_trang_thai_nghiem_thu(DS_V_GD_GV_CONG_VIEC_MOI op_ds_v_gd_cv_moi, decimal ip_dc_hop_dong_khung, decimal ip_dc_trang_thai, decimal ip_dc_id_giang_vien)
    {
        CStoredProc v_cstore = new CStoredProc("pr_V_GD_GV_CONG_VIEC_MOI_Loc_Duyet_Ke_Hoach_theo_cbo_trang_thai_nghiem_thu");
        v_cstore.addDecimalInputParam("@ID_HOP_DONG_KHUNG", ip_dc_hop_dong_khung);
        v_cstore.addDecimalInputParam("@ID_GIANG_VIEN", ip_dc_id_giang_vien);
        v_cstore.addDecimalInputParam("@ID_TRANG_THAI", ip_dc_trang_thai);
        v_cstore.fillDataSetByCommand(this, op_ds_v_gd_cv_moi);
    }
    public void loc_du_lieu_gv_cong_viec_moi_theo_trang_thai_nghiem_thu(DS_V_GD_GV_CONG_VIEC_MOI op_ds_v_gd_cv_moi, decimal ip_dc_hop_dong_khung, decimal ip_dc_id_giang_vien)
    {
        CStoredProc v_cstore = new CStoredProc("pr_V_GD_GV_CONG_VIEC_MOI_Loc_theo_cbo_trang_thai_nghiem_thu");
        v_cstore.addDecimalInputParam("@ID_HOP_DONG_KHUNG", ip_dc_hop_dong_khung);
        v_cstore.addDecimalInputParam("@ID_GIANG_VIEN", ip_dc_id_giang_vien);
        v_cstore.fillDataSetByCommand(this, op_ds_v_gd_cv_moi);
    }
    public void cap_nhat_trang_thai_cong_viec(decimal ip_dc_trang_thai_moi)
    {
        CStoredProc v_cstore = new CStoredProc("pr_V_GD_GV_CONG_VIEC_MOI_Cap_Nhat_Trang_Thai");
        v_cstore.addDecimalInputParam("@ID", this.dcID);
        v_cstore.addDecimalInputParam("@ID_TRANG_THAI", ip_dc_trang_thai_moi);
        v_cstore.ExecuteCommand(this);
    }
    public void chuyen_cong_viec_qua_thanh_toan(string ip_str_id_cac_cong_viec
                                                , decimal ip_dc_id_dot_thanh_toan
                                                , string ip_str_user_lap_thanh_toan
                                                , string ip_str_thoi_gian_lop_mon
                                                , decimal ip_dc_thoi_diem_thanh_toan_thang
                                                , decimal ip_dc_thoi_diem_thanh_toan_nam)
    {
        CStoredProc v_cstore = new CStoredProc("pr_V_GD_GV_CONG_VIEC_MOI_Chuyen_Qua_Thanh_Toan");
        v_cstore.addDecimalInputParam("@ID_DOT_THANH_TOAN", ip_dc_id_dot_thanh_toan);
        v_cstore.addNVarcharInputParam("@USER_LAP_THANH_TOAN", ip_str_user_lap_thanh_toan);
        v_cstore.addNVarcharInputParam("@THOI_GIAN_LOP_MON", ip_str_thoi_gian_lop_mon);
        v_cstore.addNVarcharInputParam("@ID_CAC_CONG_VIEC", ip_str_id_cac_cong_viec);
        v_cstore.addDecimalInputParam("@THOI_DIEM_THANG", ip_dc_thoi_diem_thanh_toan_thang);
        v_cstore.addDecimalInputParam("@THOI_DIEM_NAM", ip_dc_thoi_diem_thanh_toan_nam);
        v_cstore.ExecuteCommand(this);
    }
    public void lay_cong_viec_de_nghiem_thu(DS_V_GD_GV_CONG_VIEC_MOI op_ds_v_gd_cv_moi,decimal ip_dc_id_hop_dong_khung, decimal ip_dc_id_noi_dung_tt)
    {
        CStoredProc v_cstore = new CStoredProc("pr_GD_GV_CONG_VIEC_MOI_Lay_Cong_Viec_De_Nghiem_Thu");
        v_cstore.addDecimalInputParam("@ID_HOP_DONG_KHUNG", ip_dc_id_hop_dong_khung);
        v_cstore.addDecimalInputParam("@ID_NOI_DUNG_TT", ip_dc_id_noi_dung_tt);
        v_cstore.fillDataSetByCommand(this, op_ds_v_gd_cv_moi);
    }
    public void loc_du_lieu_giang_vien_cong_viec_moi_all_gv(DS_V_GD_GV_CONG_VIEC_MOI op_ds_v_gd_cv_moi, decimal ip_dc_id_giang_vien, decimal ip_dc_hop_dong_khung, decimal ip_dc_trang_thai)
    {
        CStoredProc v_cstore = new CStoredProc("pr_GD_GV_CONG_VIEC_MOI_Loc_Duyet_Ke_Hoach_all_gv");
        v_cstore.addDecimalInputParam("@ID_HOP_DONG_KHUNG", ip_dc_hop_dong_khung);
        v_cstore.addDecimalInputParam("@ID_GIANG_VIEN", ip_dc_id_giang_vien);
        v_cstore.addDecimalInputParam("@ID_TRANG_THAI", ip_dc_trang_thai);
        v_cstore.fillDataSetByCommand(this, op_ds_v_gd_cv_moi);
    }
    public void load_data_2_export_excel(DS_V_GD_GV_CONG_VIEC_MOI op_ds_v_gd_cv_moi, decimal ip_dc_id_giang_vien, decimal ip_dc_hop_dong_khung)
    {
        CStoredProc v_cstore = new CStoredProc("pr_GD_GV_CONG_VIEC_MOI_Load_Cong_Viec_Export_Excel");
        v_cstore.addDecimalInputParam("@ID_HOP_DONG_KHUNG", ip_dc_hop_dong_khung);
        v_cstore.addDecimalInputParam("@ID_GIANG_VIEN", ip_dc_id_giang_vien);
        v_cstore.fillDataSetByCommand(this, op_ds_v_gd_cv_moi);
    }
    public void load_data_2_export_bao_cao_706(DS_V_GD_GV_CONG_VIEC_MOI op_ds_v_gd_cv_moi, decimal ip_dc_thang_dat_hang, decimal ip_dc_nam_dat_hang, decimal ip_dc_id_trang_thai_cv)
    {
        CStoredProc v_cstore = new CStoredProc("pr_GD_GV_CONG_VIEC_MOI_Load_Cong_Viec_Export_Bao_Cao_706");
        v_cstore.addDecimalInputParam("@THANG_DAT_HANG", ip_dc_thang_dat_hang);
        v_cstore.addDecimalInputParam("@NAM_DAT_HANG", ip_dc_nam_dat_hang);
        v_cstore.addDecimalInputParam("@ID_TRANG_THAI_CV", ip_dc_id_trang_thai_cv);
        v_cstore.fillDataSetByCommand(this, op_ds_v_gd_cv_moi);
    }
    public void loc_du_lieu_giang_vien_cong_viec_moi_f606(DS_V_GD_GV_CONG_VIEC_MOI op_ds_v_gd_cv_moi, decimal ip_dc_id_giang_vien
                                                           , decimal ip_dc_hop_dong_khung, decimal ip_dc_trang_thai, decimal ip_dc_id_cong_viec_id)
    {
        CStoredProc v_cstore = new CStoredProc("pr_GD_GV_CONG_VIEC_MOI_Loc_Cong_Viec_Giang_Vien_606");
        v_cstore.addDecimalInputParam("@ID_HOP_DONG_KHUNG", ip_dc_hop_dong_khung);
        v_cstore.addDecimalInputParam("@ID_GIANG_VIEN", ip_dc_id_giang_vien);
        v_cstore.addDecimalInputParam("@ID_TRANG_THAI", ip_dc_trang_thai);
        v_cstore.addDecimalInputParam("@ID_HD_NOI_DUNG_TT", ip_dc_id_cong_viec_id);
        v_cstore.fillDataSetByCommand(this, op_ds_v_gd_cv_moi);
    }
    #endregion
}
}