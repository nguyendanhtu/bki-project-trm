using System;
using System.Collections.Generic;
using System.Text;


namespace WebDS.CDBNames
{
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
        , HOC_HAM = 11
        , HOC_VI = 12
        , HINH_THUC_CONG_TAC = 13
        , TRANG_THAI_DOT_THANH_TOAN = 14
        , TRANG_THAI_THANH_TOAN = 15
    }

    public enum e_user_group
    {
        TESTER=1
        ,PM_TD = 2
        ,TRUONG_NHOM_PO = 3
        ,PO = 4
        , ADMIN = 5
        ,GIANG_VIEN = 6
    }
    public class SU_KIEN
    {
         public const string ID = "ID";
         public const string ID_LOAI_SU_KIEN = "ID_LOAI_SU_KIEN";
         public const string TEN_SU_KIEN = "TEN_SU_KIEN";
         public const string NGAY_DIEN_RA = "NGAY_DIEN_RA";
         public const string ID_TRANG_THAI = "ID_TRANG_THAI";
         public const string MO_TA = "MO_TA";
    }
 public class TRANG_THAI_DOT_TT
    {
        public const string DA_LAP_DOT = "1_DA_LAP_DOT";
        public const string DA_LAP_BANG_KE_XONG = "2_DA_LAP_BANG_KE_XONG";
        public const string DA_THANH_TOAN = "3_DA_THANH_TOAN";
        public const string DA_KET_THUC = "4_DA_KET_THUC";
    }
 public class TRANG_THAI_THANH_TOAN
 {
     public const string DA_LEN_BANG_KE = "1_DA_LEN_BANG_KE";
     public const string CHUNG_TU_DA_DUOC_DUYET = "2_CHUNG_TU_DA_DUOC_DUYET";
     public const string CHUNG_TU_KHONG_DUOC_DUYET = "2B_CHUNG_TU_KHONG_DUOC_DUYET";
     public const string CHUNG_TU_CHUA_DUOC_CHUYEN_KHOAN = "2C_CHUNG_TU_CHUA_DUOC_CHUYEN_KHOAN";
     public const string NGAN_HANG_CHUYEN_KHOAN_THANH_CONG = "3_NGAN_HANG_CHUYEN_KHOAN_THANH_CONG";
     public const string NGAN_HANG_CHUYEN_KHOAN_KHONG_THANH_CONG = "3B_NGAN_HANG_CHUYEN_KHOAN_KHONG_THANH_CONG";
     public const string CHUA_CO_XAC_NHAN_CUA_GIANG_VIEN = "4_CHUA_CO_XAC_NHAN_CUA_GIANG_VIEN";
     public const string DA_CO_XAC_NHAN_CUA_GIANG_VIEN = "5_DA_CO_XAC_NHAN_CUA_GIANG_VIEN";
 }
    public class CM_DM_TU_DIEN
    {
        public const string ID = "ID";
        public const string MA_TU_DIEN = "MA_TU_DIEN";
        public const string TEN_NGAN = "TEN_NGAN";
        public const string TEN = "TEN";
        public const string ID_LOAI_TU_DIEN = "ID_LOAI_TU_DIEN";
        public const string GHI_CHU = "GHI_CHU";
    }
    public class CM_DM_LOAI_TD
    {
        public const string ID = "ID";
        public const string MA_LOAI = "MA_LOAI";
        public const string TEN_LOAI = "TEN_LOAI";
    }
    public class V_DM_NOI_DUNG_THANH_TOAN
    {
        public const string ID = "ID";
        public const string TEN_NOI_DUNG = "TEN_NOI_DUNG";
        public const string GHI_CHU = "GHI_CHU";
        public const string ID_LOAI_HOP_DONG = "ID_LOAI_HOP_DONG";
        public const string MA_DON_VI_TINH = "MA_DON_VI_TINH";
        public const string DON_GIA_DEFAULT = "DON_GIA_DEFAULT";
        public const string MA_TAN_SUAT = "MA_TAN_SUAT";
        public const string HOC_LIEU_YN = "HOC_LIEU_YN";
        public const string VAN_HANH_YN = "VAN_HANH_YN";
        public const string MA_TU_DIEN = "MA_TU_DIEN";
        public const string TEN_NGAN = "TEN_NGAN";
        public const string SO_LUONG_HE_SO_DEFAULT = "SO_LUONG_HE_SO_DEFAULT";
        public const string DON_VI_TINH = "DON_VI_TINH";
        public const string TAN_SUAT = "TAN_SUAT";
        public const string SU_KIEN_YN = "SU_KIEN_YN";
        public const string SU_DUNG_YN = "SU_DUNG_YN";
    }
    public class DM_MON_HOC
    {
        public const string ID = "ID";
        public const string MA_MON_HOC = "MA_MON_HOC";
        public const string TEN_MON_HOC = "TEN_MON_HOC";
        public const string SO_DVHT = "SO_DVHT";
        public const string GHI_CHU = "GHI_CHU";
    }

    public class DM_NOI_DUNG_THANH_TOAN
    {
        public const string ID = "ID";
        public const string TEN_NOI_DUNG = "TEN_NOI_DUNG";
        public const string GHI_CHU = "GHI_CHU";
        public const string ID_LOAI_HOP_DONG = "ID_LOAI_HOP_DONG";
        public const string MA_DON_VI_TINH = "MA_DON_VI_TINH";
        public const string DON_GIA_DEFAULT = "DON_GIA_DEFAULT";
        public const string MA_TAN_SUAT = "MA_TAN_SUAT";
        public const string HOC_LIEU_YN = "HOC_LIEU_YN";
        public const string VAN_HANH_YN = "VAN_HANH_YN";
        public const string SO_LUONG_HE_SO_DEFAULT = "SO_LUONG_HE_SO_DEFAULT";
    }
    public class DM_DON_VI_THANH_TOAN
    {
        public const string ID = "ID";
        public const string MA_DON_VI = "MA_DON_VI";
        public const string TEN_DON_VI = "TEN_DON_VI";
        public const string DIA_CHI = "DIA_CHI";
        public const string SO_DIEN_THOAI = "SO_DIEN_THOAI";
        public const string SO_TAI_KHOAN = "SO_TAI_KHOAN";
        public const string CAP_TAI = "CAP_TAI";
    }
    public class GD_LOP_MON
    {
        public const string ID = "ID";
        public const string MA_LOP_MON = "MA_LOP_MON";
        public const string ID_MON_HOC = "ID_MON_HOC";
        public const string NGAY_BAT_DAU = "NGAY_BAT_DAU";
        public const string NGAY_KET_THUC = "NGAY_KET_THUC";
        public const string PO_PHU_TRACH = "PO_PHU_TRACH";
        public const string NGAY_THI = "NGAY_THI";
        public const string CHUONG_TRINH_PHU_TRACH = "CHUONG_TRINH_PHU_TRACH";
        public const string SO_LUONG_HV = "SO_LUONG_HV";
        public const string OFFLINE_YN = "OFFLINE_YN";
        public const string SO_LUONG_OFFLINE = "SO_LUONG_OFFLINE";
        public const string ONLINES_YN = "ONLINES_YN";
        public const string SO_LUONG_ONLINES = "SO_LUONG_ONLINES";
        public const string BAI_TAP_GKY_YN = "BAI_TAP_GKY_YN";
    }
  public  class V_DM_GIANG_VIEN
    {
        public const string ID = "ID";
        public const string MA_GIANG_VIEN = "MA_GIANG_VIEN";
        public const string HO_VA_TEN_DEM = "HO_VA_TEN_DEM";
        public const string TEN_GIANG_VIEN = "TEN_GIANG_VIEN";
        public const string NGAY_SINH = "NGAY_SINH";
        public const string GIOI_TINH_YN = "GIOI_TINH_YN";
        public const string CHUC_VU_HIEN_TAI = "CHUC_VU_HIEN_TAI";
        public const string CHUC_VU_CAO_NHAT = "CHUC_VU_CAO_NHAT";
        public const string TEL_HOME = "TEL_HOME";
        public const string TEL_OFFICE = "TEL_OFFICE";
        public const string MOBILE_PHONE = "MOBILE_PHONE";
        public const string EMAIL = "EMAIL";
        public const string TEN_CO_QUAN_CONG_TAC = "TEN_CO_QUAN_CONG_TAC";
        public const string EMAIL_TOPICA = "EMAIL_TOPICA";
        public const string ANH_CA_NHAN = "ANH_CA_NHAN";
        public const string HOC_VI = "HOC_VI";
        public const string HOC_HAM = "HOC_HAM";
        public const string CHUYEN_NGANH_CHINH = "CHUYEN_NGANH_CHINH";
        public const string TRUONG_DAO_TAO = "TRUONG_DAO_TAO";
        public const string ID_TRANG_THAI_GIANG_VIEN = "ID_TRANG_THAI_GIANG_VIEN";
        public const string TRANG_THAI_GIANG_VIEN = "TRANG_THAI_GIANG_VIEN";
        public const string SO_TAI_KHOAN = "SO_TAI_KHOAN";
        public const string TEN_NGAN_HANG = "TEN_NGAN_HANG";
        public const string SO_CMTND = "SO_CMTND";
        public const string NGAY_CAP = "NGAY_CAP";
        public const string NOI_CAP = "NOI_CAP";
        public const string ID_DON_VI_QUAN_LY = "ID_DON_VI_QUAN_LY";
        public const string DON_VI_QUAN_LY = "DON_VI_QUAN_LY";
        public const string MA_SO_THUE = "MA_SO_THUE";
        public const string GVHD_YN = "GVHD_YN";
        public const string GVCM_YN = "GVCM_YN";
        public const string GV_VIET_HL_YN = "GV_VIET_HL_YN";
        public const string GV_DUYET_HL_YN = "GV_DUYET_HL_YN";
        public const string GV_THAM_DINH_HL_YN = "GV_THAM_DINH_HL_YN";
        public const string GV_QUAY_HL = "GV_QUAY_HL";
        public const string GV_HDKH_YN = "GV_HDKH_YN";
        public const string DESCRIPTION = "DESCRIPTION";
        public const string NGAY_BD_HOP_TAC = "NGAY_BD_HOP_TAC";
        public const string PO_PHU_TRACH_CHINH = "PO_PHU_TRACH_CHINH";
        public const string PO_PHU_TRACH_PHU = "PO_PHU_TRACH_PHU";
        public const string PO_PHU_TRACH_PHU2 = "PO_PHU_TRACH_PHU2";
        public const string PO_PHU_TRACH_PHU3 = "PO_PHU_TRACH_PHU3";
        public const string PO_PHU_TRACH_PHU4 = "PO_PHU_TRACH_PHU4";
        public const string DIA_CHI = "DIA_CHI";
    }

   public  class V_DM_HOP_DONG_KHUNG
     {
         public const string ID = "ID";
         public const string SO_HOP_DONG = "SO_HOP_DONG";
         public const string ID_GIANG_VIEN = "ID_GIANG_VIEN";
         public const string GIANG_VIEN = "GIANG_VIEN";
         public const string MA_SO_THUE = "MA_SO_THUE";
         public const string SO_TAI_KHOAN = "SO_TAI_KHOAN";
         public const string TEN_NGAN_HANG = "TEN_NGAN_HANG";
         public const string NGAY_KY = "NGAY_KY";
         public const string NGAY_HIEU_LUC = "NGAY_HIEU_LUC";
         public const string NGAY_KET_THUC_DU_KIEN = "NGAY_KET_THUC_DU_KIEN";
         public const string GIA_TRI_HOP_DONG = "GIA_TRI_HOP_DONG";
         public const string GIA_TRI_NGHIEM_THU_THUC_TE = "GIA_TRI_NGHIEM_THU_THUC_TE";
         public const string ID_LOAI_HOP_DONG = "ID_LOAI_HOP_DONG";
         public const string LOAI_HOP_DONG = "LOAI_HOP_DONG";
         public const string ID_DON_VI_QUAN_LY = "ID_DON_VI_QUAN_LY";
         public const string DON_VI_QUAN_LY = "DON_VI_QUAN_LY";
         public const string GHI_CHU = "GHI_CHU";
         public const string ID_TRANG_THAI_HOP_DONG = "ID_TRANG_THAI_HOP_DONG";
         public const string TRANG_THAI_HOP_DONG = "TRANG_THAI_HOP_DONG";
         public const string ID_DON_VI_THANH_TOAN = "ID_DON_VI_THANH_TOAN";
         public const string DON_VI_THANH_TOAN = "DON_VI_THANH_TOAN";
         public const string THUE_SUAT = "THUE_SUAT";
         public const string ID_MON1 = "ID_MON1";
         public const string FIRST_MON = "FIRST_MON";
         public const string ID_MON2 = "ID_MON2";
         public const string SEC_MON = "SEC_MON";
         public const string ID_MON3 = "ID_MON3";
         public const string THIR_MON = "THIR_MON";
         public const string ID_MON4 = "ID_MON4";
         public const string FOURTH_MON = "FOURTH_MON";
         public const string ID_MON5 = "ID_MON5";
         public const string FITH_MON = "FITH_MON";
         public const string ID_MON6 = "ID_MON6";
         public const string SIXTH_MON = "SIXTH_MON";
         public const string HOC_LIEU_YN = "HOC_LIEU_YN";
         public const string VAN_HANH_YN = "VAN_HANH_YN";
         public const string MA_PO_PHU_TRACH = "MA_PO_PHU_TRACH";
         public const string GHI_CHU2 = "GHI_CHU2";
         public const string GHI_CHU3 = "GHI_CHU3";
         public const string GHI_CHU4 = "GHI_CHU4";
         public const string CO_SO_HD_YN = "CO_SO_HD_YN";
         public const string TRANG_THAI_TT_HOP_DONG = "TRANG_THAI_TT_HOP_DONG";

     }

    public class DM_HOP_DONG_KHUNG {
        public const string ID = "ID";
        public const string SO_HOP_DONG = "SO_HOP_DONG";
        public const string ID_GIANG_VIEN = "ID_GIANG_VIEN";
        public const string NGAY_KY = "NGAY_KY";
        public const string NGAY_HIEU_LUC = "NGAY_HIEU_LUC";
        public const string NGAY_KET_THUC_DU_KIEN = "NGAY_KET_THUC_DU_KIEN";
        public const string GIA_TRI_HOP_DONG = "GIA_TRI_HOP_DONG";
        public const string ID_LOAI_HOP_DONG = "ID_LOAI_HOP_DONG";
        public const string ID_DON_VI_QUAN_LY = "ID_DON_VI_QUAN_LY";
        public const string GHI_CHU = "GHI_CHU";
        public const string ID_TRANG_THAI_HOP_DONG = "ID_TRANG_THAI_HOP_DONG";
        public const string ID_DON_VI_THANH_TOAN = "ID_DON_VI_THANH_TOAN";
        public const string THUE_SUAT = "THUE_SUAT";
        public const string ID_MON1 = "ID_MON1";
        public const string ID_MON2 = "ID_MON2";
        public const string ID_MON3 = "ID_MON3";
        public const string ID_MON4 = "ID_MON4";
        public const string ID_MON5 = "ID_MON5";
        public const string ID_MON6 = "ID_MON6";
        public const string HOC_LIEU_YN = "HOC_LIEU_YN";
        public const string VAN_HANH_YN = "VAN_HANH_YN";
    }
    public class GD_LOP_MON_DETAIL
    {
        public const string ID = "ID";
        public const string ID_LOP_MON = "ID_LOP_MON";
        public const string ID_HOP_DONG_KHUNG = "ID_HOP_DONG_KHUNG";
        public const string ID_NOI_DUNG_THANH_TOAN = "ID_NOI_DUNG_THANH_TOAN";
        public const string DA_THANH_TOAN_YN = "DA_THANH_TOAN_YN";
        public const string SO_LUONG_HE_SO = "SO_LUONG_HE_SO";
        public const string THANH_TIEN = "THANH_TIEN";
    }

    public class V_GD_HOP_DONG_NOI_DUNG_TT
    {
        public const string ID = "ID";
        public const string ID_HOP_DONG_KHUNG = "ID_HOP_DONG_KHUNG";
        public const string SO_HOP_DONG = "SO_HOP_DONG";
        public const string TEN_GIANG_VIEN = "TEN_GIANG_VIEN";
        public const string ID_NOI_DUNG_TT = "ID_NOI_DUNG_TT";
        public const string NOI_DUNG_THANH_TOAN = "NOI_DUNG_THANH_TOAN";
        public const string GHI_CHU_NOI_DUNG_TT = "GHI_CHU_NOI_DUNG_TT";
        public const string SO_LUONG_HE_SO = "SO_LUONG_HE_SO";
        public const string MA_DON_VI_TINH = "MA_DON_VI_TINH";
        public const string DON_VI_TINH = "DON_VI_TINH";
        public const string MA_TAN_SUAT = "MA_TAN_SUAT";
        public const string TAN_SUAT = "TAN_SUAT";
        public const string DON_GIA_HD = "DON_GIA_HD";
    }

   public class HT_NGUOI_SU_DUNG
    {
        public const string ID = "ID";
        public const string TEN_TRUY_CAP = "TEN_TRUY_CAP";
        public const string TEN = "TEN";
        public const string MAT_KHAU = "MAT_KHAU";
        public const string NGAY_TAO = "NGAY_TAO";
        public const string NGUOI_TAO = "NGUOI_TAO";
        public const string TRANG_THAI = "TRANG_THAI";
        public const string BUILT_IN_YN = "BUILT_IN_YN";
        public const string ID_USER_GROUP = "ID_USER_GROUP";
        public const string ID_TRAINING_PROJECT = "ID_TRAINING_PROJECT";
    }

   public class V_DM_DOT_THANH_TOAN
   {
       public const string ID = "ID";
       public const string MA_DOT_TT = "MA_DOT_TT";
       public const string TEN_DOT_TT = "TEN_DOT_TT";
       public const string NGAY_TT_DU_KIEN = "NGAY_TT_DU_KIEN";
       public const string NGAY_THU_CHUNG_TU = "NGAY_THU_CHUNG_TU";
       public const string NGAY_DONG_DOT_TT = "NGAY_DONG_DOT_TT";
       public const string ID_TRANG_THAI_DOT_TT = "ID_TRANG_THAI_DOT_TT";
       public const string TRANG_THAI_DOT_TT = "TRANG_THAI_DOT_TT";
       public const string ID_DON_VI_THANH_TOAN = "ID_DON_VI_THANH_TOAN";
       public const string DON_VI_THANH_TOAN = "DON_VI_THANH_TOAN";
       public const string GHI_CHU = "GHI_CHU";
   }

   public class V_GD_THANH_TOAN
   {
       public const string ID = "ID";
       public const string SO_PHIEU_THANH_TOAN = "SO_PHIEU_THANH_TOAN";
       public const string ID_HOP_DONG_KHUNG = "ID_HOP_DONG_KHUNG";
       public const string LOAI_HOP_DONG = "LOAI_HOP_DONG";
       public const string ID_GIANG_VIEN = "ID_GIANG_VIEN";
       public const string TEN_GIANG_VIEN = "TEN_GIANG_VIEN";
       public const string SO_TAI_KHOAN = "SO_TAI_KHOAN";
       public const string TEN_NGAN_HANG = "TEN_NGAN_HANG";
       public const string MA_SO_THUE = "MA_SO_THUE";
       public const string REFERENCE_CODE = "REFERENCE_CODE";
       public const string ID_MON_HOC = "ID_MON_HOC";
       public const string NGAY_THANH_TOAN = "NGAY_THANH_TOAN";
       public const string DESCRIPTION = "DESCRIPTION";
       public const string DA_THANH_TOAN = "DA_THANH_TOAN";
       public const string CON_PHAI_THANH_TOAN = "CON_PHAI_THANH_TOAN";
       public const string TONG_TIEN_THANH_TOAN = "TONG_TIEN_THANH_TOAN";
       public const string GIA_TRI_NGHIEM_THU_THUC_TE = "GIA_TRI_NGHIEM_THU_THUC_TE";
       public const string SO_HOP_DONG = "SO_HOP_DONG";
       public const string THOI_GIAN = "THOI_GIAN";
       public const string ID_DON_VI_QUAN_LY = "ID_DON_VI_QUAN_LY";
       public const string GIA_TRI_HOP_DONG = "GIA_TRI_HOP_DONG";
       public const string PO_PHU_TRACH_CHINH = "PO_PHU_TRACH_CHINH";
       public const string PO_PHU_TRACH_PHU = "PO_PHU_TRACH_PHU";
       public const string SO_TIEN_THUE = "SO_TIEN_THUE";
       public const string TONG_TIEN_THUC_NHAN = "TONG_TIEN_THUC_NHAN";
       public const string ID_TRANG_THAI_THANH_TOAN = "ID_TRANG_THAI_THANH_TOAN";
       public const string PO_LAP_THANH_TOAN = "PO_LAP_THANH_TOAN";
       public const string GHI_CHU_CAC_MON_PHU_TRACH = "GHI_CHU_CAC_MON_PHU_TRACH";
       public const string GHI_CHU_THOI_GIAN_LOP_MON = "GHI_CHU_THOI_GIAN_LOP_MON";
       public const string GHI_CHU_HE_SO_DON_GIA = "GHI_CHU_HE_SO_DON_GIA";
       public const string GHI_CHU_4 = "GHI_CHU_4";
       public const string GHI_CHU_5 = "GHI_CHU_5";
   }

   public class V_GD_THANH_TOAN_DETAIL
   {
       public const string ID = "ID";
       public const string ID_GD_THANH_TOAN = "ID_GD_THANH_TOAN";
       public const string DESCRIPTION = "DESCRIPTION";
       public const string ID_HOP_DONG_KHUNG = "ID_HOP_DONG_KHUNG";
       public const string ID_NOI_DUNG_THANH_TOAN = "ID_NOI_DUNG_THANH_TOAN";
       public const string NOI_DUNG_THANH_TOAN = "NOI_DUNG_THANH_TOAN";
       public const string SO_LUONG_HE_SO = "SO_LUONG_HE_SO";
       public const string MA_DON_VI_TINH = "MA_DON_VI_TINH";
       public const string DON_VI_TINH = "DON_VI_TINH";
       public const string MA_TAN_SUAT = "MA_TAN_SUAT";
       public const string TAN_SUAT = "TAN_SUAT";
       public const string DON_GIA_TT = "DON_GIA_TT";
       public const string REFERENCE_CODE = "REFERENCE_CODE";
   }
   public class HT_CHUC_NANG
   {
       public const string ID = "ID";
       public const string TEN_CHUC_NANG = "TEN_CHUC_NANG";
       public const string URL_FORM = "URL_FORM";
       public const string TRANG_THAI_YN = "TRANG_THAI_YN";
       public const string VI_TRI = "VI_TRI";
       public const string CHUC_NANG_PARENT_ID = "CHUC_NANG_PARENT_ID";
       public const string HIEN_THI_YN = "HIEN_THI_YN";
   }
   public class HT_QUYEN_GROUP
   {
       public const string ID = "ID";
       public const string ID_USER_GROUP = "ID_USER_GROUP";
       public const string ID_QUYEN = "ID_QUYEN";
   }
   public class HT_USER_GROUP
   {
       public const string ID = "ID";
       public const string USER_GROUP_NAME = "USER_GROUP_NAME";
       public const string DESCRIPTION = "DESCRIPTION";
   }
   public class RPT_BAO_CAO_THONG_KE_TRANG_THAI_GIANG_VIEN
   {
       public const string ID = "ID";
       public const string ID_DON_VI_QUAN_LY = "ID_DON_VI_QUAN_LY";
       public const string DON_VI_QUAN_LY = "DON_VI_QUAN_LY";
       public const string ID_TRANG_THAI_GIANG_VIEN = "ID_TRANG_THAI_GIANG_VIEN";
       public const string TRANG_THAI_GIANG_VIEN = "TRANG_THAI_GIANG_VIEN";
       public const string GV_CHUYEN_MON = "GV_CHUYEN_MON";
       public const string GV_HUONG_DAN = "GV_HUONG_DAN";
       public const string GV_HOC_LIEU = "GV_HOC_LIEU";
   }
   public class RPT_BAO_CAO_SO_LUONG_TRANG_THAI_HD_GIANG_VIEN
   {
       public const string ID = "ID";
       public const string ID_DON_VI_QUAN_LY = "ID_DON_VI_QUAN_LY";
       public const string DON_VI_QUAN_LY = "DON_VI_QUAN_LY";
       public const string ID_TRANG_THAI_HOP_DONG = "ID_TRANG_THAI_HOP_DONG";
       public const string TRANG_THAI_HOP_DONG = "TRANG_THAI_HOP_DONG";
       public const string HD_CHUYEN_MON = "HD_CHUYEN_MON";
       public const string HD_HUONG_DAN = "HD_HUONG_DAN";
       public const string HD_HOC_LIEU = "HD_HOC_LIEU";
   }
   public class RPT_BAO_CAO_SO_LUONG_TRANG_THAI_HD_TONG_HOP
   {
       public const string ID = "ID";
       public const string ID_TRANG_THAI_HOP_DONG = "ID_TRANG_THAI_HOP_DONG";
       public const string TRANG_THAI_HOP_DONG = "TRANG_THAI_HOP_DONG";
       public const string HD_CHUYEN_MON_EDUTOP = "HD_CHUYEN_MON_EDUTOP";
       public const string HD_HUONG_DAN_EDUTOP = "HD_HUONG_DAN_EDUTOP";
       public const string HD_HOC_LIEU_EDUTOP = "HD_HOC_LIEU_EDUTOP";
       public const string HD_CHUYEN_MON_ELC = "HD_CHUYEN_MON_ELC";
       public const string HD_HUONG_DAN_ELC = "HD_HUONG_DAN_ELC";
       public const string HD_HOC_LIEU_ELC = "HD_HOC_LIEU_ELC";
   }
   public class RPT_BAO_CAO_THONG_KE_HOP_DONG_THANH_TOAN_GV
   {
       public const string ID = "ID";
       public const string ID_DON_VI_QUAN_LY = "ID_DON_VI_QUAN_LY";
       public const string DON_VI_QUAN_LY = "DON_VI_QUAN_LY";
       public const string TRANG_THAI_THANH_TOAN_HOP_DONG = "TRANG_THAI_THANH_TOAN_HOP_DONG";
       public const string HD_CHUYEN_MON = "HD_CHUYEN_MON";
       public const string HD_HUONG_DAN = "HD_HUONG_DAN";
       public const string HD_HOC_LIEU = "HD_HOC_LIEU";
   }
   public class RPT_BAO_CAO_THONG_KE_HD_THANH_TOAN_GV_TONG_HOP
   {
       public const string ID = "ID";
       public const string TRANG_THAI_TT_HOP_DONG = "TRANG_THAI_TT_HOP_DONG";
       public const string HD_CHUYEN_MON_EDUTOP = "HD_CHUYEN_MON_EDUTOP";
       public const string HD_HUONG_DAN_EDUTOP = "HD_HUONG_DAN_EDUTOP";
       public const string HD_HOC_LIEU_EDUTOP = "HD_HOC_LIEU_EDUTOP";
       public const string HD_CHUYEN_MON_ELC = "HD_CHUYEN_MON_ELC";
       public const string HD_HUONG_DAN_ELC = "HD_HUONG_DAN_ELC";
       public const string HD_HOC_LIEU_ELC = "HD_HOC_LIEU_ELC";
   }

   public class RPT_BAO_CAO_THONG_KE_SO_TIEN_THANH_TOAN_HD_GIANG_VIEN
   {
       public const string ID = "ID";
       public const string TRANG_THAI_TT_HOP_DONG = "TRANG_THAI_TT_HOP_DONG";
       public const string HD_CHUYEN_MON_EDUTOP = "HD_CHUYEN_MON_EDUTOP";
       public const string HD_HUONG_DAN_EDUTOP = "HD_HUONG_DAN_EDUTOP";
       public const string HD_HOC_LIEU_EDUTOP = "HD_HOC_LIEU_EDUTOP";
       public const string HD_CHUYEN_MON_ELC = "HD_CHUYEN_MON_ELC";
       public const string HD_HUONG_DAN_ELC = "HD_HUONG_DAN_ELC";
       public const string HD_HOC_LIEU_ELC = "HD_HOC_LIEU_ELC";
   }
   public class GD_GV_CONG_VIEC_MOI
   {
       public const string ID = "ID";
       public const string ID_HOP_DONG_KHUNG = "ID_HOP_DONG_KHUNG";
       public const string ID_NOI_DUNG_TT = "ID_NOI_DUNG_TT";
       public const string SO_LUONG_HE_SO = "SO_LUONG_HE_SO";
       public const string DON_GIA = "DON_GIA";
       public const string NGAY_DAT_HANG = "NGAY_DAT_HANG";
       public const string NGAY_NGHIEM_THU = "NGAY_NGHIEM_THU";
       public const string ID_TRANG_THAI = "ID_TRANG_THAI";
       public const string ID_USER_NHAP = "ID_USER_NHAP";
       public const string GHI_CHU = "GHI_CHU";
   }
   public class DM_SU_KIEN
   {
       public const string ID = "ID";
       public const string ID_LOAI_SU_KIEN = "ID_LOAI_SU_KIEN";
       public const string TEN_SU_KIEN = "TEN_SU_KIEN";
       public const string NGAY_DIEN_RA = "NGAY_DIEN_RA";
       public const string ID_TRANG_THAI = "ID_TRANG_THAI";
       public const string MO_TA = "MO_TA";
   }

   public class GD_ASSIGN_SU_KIEN_GIANG_VIEN
   {
       public const string ID = "ID";
       public const string ID_SU_KIEN = "ID_SU_KIEN";
       public const string ID_GIANG_VIEN = "ID_GIANG_VIEN";
       public const string SO_TIEN_GV_HUONG = "SO_TIEN_GV_HUONG";
       public const string ID_VAI_TRO_GV = "ID_VAI_TRO_GV";
       public const string ID_HOP_DONG = "ID_HOP_DONG";
       public const string THANH_TOAN_NGAY_YN = "THANH_TOAN_NGAY_YN";
       public const string ID_TRANG_THAI = "ID_TRANG_THAI";
       public const string GHI_CHU = "GHI_CHU";
       public const string ID_USER_LAP = "ID_USER_LAP";
   }
   public class V_GD_ASSIGN_SU_KIEN_GIANG_VIEN
   {
       public const string ID = "ID";
       public const string ID_LOAI_SU_KIEN = "ID_LOAI_SU_KIEN";
       public const string ID_SU_KIEN = "ID_SU_KIEN";
       public const string ID_GIANG_VIEN = "ID_GIANG_VIEN";
       public const string ID_VAI_TRO_GV = "ID_VAI_TRO_GV";
       public const string ID_HOP_DONG = "ID_HOP_DONG";
       public const string ID_TRANG_THAI = "ID_TRANG_THAI";
       public const string ID_USER_LAP = "ID_USER_LAP";
       public const string SO_TIEN_GV_HUONG = "SO_TIEN_GV_HUONG";
       public const string GHI_CHU = "GHI_CHU";
       public const string THANH_TOAN_NGAY_YN = "THANH_TOAN_NGAY_YN";
       public const string SO_HOP_DONG = "SO_HOP_DONG";
       public const string HO_VA_TEN_GIANG_VIEN = "HO_VA_TEN_GIANG_VIEN";
       public const string TEN_TRUY_CAP = "TEN_TRUY_CAP";
       public const string TEN_USER_LAP = "TEN_USER_LAP";
   }

}
