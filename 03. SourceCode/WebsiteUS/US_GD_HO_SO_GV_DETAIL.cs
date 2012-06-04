﻿///************************************************
/// Generated by: minhnn
/// Date: 04/06/2012 08:57:20
/// Goal: Create User Service Class for GD_HO_SO_GV_DETAIL
///************************************************
/// <summary>
/// Create User Service Class for GD_HO_SO_GV_DETAIL
/// </summary>

using System;
using IP.Core.IPCommon;
using IP.Core.IPUserService;
using System.Data.SqlClient;
using System.Data;
using WebDS;


namespace WebUS
{

    public class US_GD_HO_SO_GV_DETAIL : US_Object
    {
        private const string c_TableName = "GD_HO_SO_GV_DETAIL";
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

        public decimal dcID_HO_SO
        {
            get
            {
                return CNull.RowNVLDecimal(pm_objDR, "ID_HO_SO", IPConstants.c_DefaultDecimal);
            }
            set
            {
                pm_objDR["ID_HO_SO"] = value;
            }
        }

        public bool IsID_HO_SONull()
        {
            return pm_objDR.IsNull("ID_HO_SO");
        }

        public void SetID_HO_SONull()
        {
            pm_objDR["ID_HO_SO"] = System.Convert.DBNull;
        }

        public string strTEN_LOAI_HO_SO
        {
            get
            {
                return CNull.RowNVLString(pm_objDR, "TEN_LOAI_HO_SO", IPConstants.c_DefaultString);
            }
            set
            {
                pm_objDR["TEN_LOAI_HO_SO"] = value;
            }
        }

        public bool IsTEN_LOAI_HO_SONull()
        {
            return pm_objDR.IsNull("TEN_LOAI_HO_SO");
        }

        public void SetTEN_LOAI_HO_SONull()
        {
            pm_objDR["TEN_LOAI_HO_SO"] = System.Convert.DBNull;
        }

        public string strHO_SO_DINH_KEM
        {
            get
            {
                return CNull.RowNVLString(pm_objDR, "HO_SO_DINH_KEM", IPConstants.c_DefaultString);
            }
            set
            {
                pm_objDR["HO_SO_DINH_KEM"] = value;
            }
        }

        public bool IsHO_SO_DINH_KEMNull()
        {
            return pm_objDR.IsNull("HO_SO_DINH_KEM");
        }

        public void SetHO_SO_DINH_KEMNull()
        {
            pm_objDR["HO_SO_DINH_KEM"] = System.Convert.DBNull;
        }

        public DateTime datNGAY_CAP_NHAT
        {
            get
            {
                return CNull.RowNVLDate(pm_objDR, "NGAY_CAP_NHAT", IPConstants.c_DefaultDate);
            }
            set
            {
                pm_objDR["NGAY_CAP_NHAT"] = value;
            }
        }

        public bool IsNGAY_CAP_NHATNull()
        {
            return pm_objDR.IsNull("NGAY_CAP_NHAT");
        }

        public void SetNGAY_CAP_NHATNull()
        {
            pm_objDR["NGAY_CAP_NHAT"] = System.Convert.DBNull;
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

        #endregion
        #region "Init Functions"
        public US_GD_HO_SO_GV_DETAIL()
        {
            pm_objDS = new DS_GD_HO_SO_GV_DETAIL();
            pm_strTableName = c_TableName;
            pm_objDR = pm_objDS.Tables[pm_strTableName].NewRow();
        }

        public US_GD_HO_SO_GV_DETAIL(DataRow i_objDR)
            : this()
        {
            this.DataRow2Me(i_objDR);
        }

        public US_GD_HO_SO_GV_DETAIL(decimal i_dbID)
        {
            pm_objDS = new DS_GD_HO_SO_GV_DETAIL();
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
