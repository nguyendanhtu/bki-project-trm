using System;
using System.Collections.Generic;
using System.Text;

using WebDS;
using WebDS.CDBNames;
using System.Data;

namespace WebDS
{
   
    public class CValidatePaymentStates
    {
        string trang_thai_thanh_toan_hien_tai;
        public string Trang_thai_thanh_toan_hien_tai
        {
            get { return trang_thai_thanh_toan_hien_tai; }
            set { trang_thai_thanh_toan_hien_tai = value; }
        }
        
        string[] trang_thai_chuyen_duoc;
        public string[] Trang_thai_chuyen_duoc
        {
            get { return trang_thai_chuyen_duoc; }
            set { trang_thai_chuyen_duoc = value; }
        }

        public void set_trang_thai()
        {
            trang_thai_chuyen_duoc = new string[4];
            switch (Trang_thai_thanh_toan_hien_tai)
            {               
                case TRANG_THAI_THANH_TOAN.DA_LEN_BANG_KE:
                    trang_thai_chuyen_duoc[0] = TRANG_THAI_THANH_TOAN.CHUNG_TU_DA_DUOC_DUYET;
                    // Không thể chuyển về trạng thái CHUNG_TU_KHONG_DUOC_DUYET được
                    trang_thai_chuyen_duoc[1] = TRANG_THAI_THANH_TOAN.CHUNG_TU_CHUA_DUOC_CHUYEN_KHOAN;
                    trang_thai_chuyen_duoc[2] = TRANG_THAI_THANH_TOAN.DA_LEN_BANG_KE;
                    trang_thai_chuyen_duoc[3] = "";
                    break;
                case TRANG_THAI_THANH_TOAN.CHUNG_TU_DA_DUOC_DUYET:
                    trang_thai_chuyen_duoc[0] = TRANG_THAI_THANH_TOAN.NGAN_HANG_CHUYEN_KHOAN_THANH_CONG;
                    // Không chuyển lên trạng thái ngân hàng chuyển khoản không thành công được do ta thực hiện chức năng duyệt toàn bộ ngân hàng
                    trang_thai_chuyen_duoc[1] = TRANG_THAI_THANH_TOAN.CHUNG_TU_CHUA_DUOC_CHUYEN_KHOAN;
                    trang_thai_chuyen_duoc[2] = TRANG_THAI_THANH_TOAN.CHUNG_TU_DA_DUOC_DUYET;
                    trang_thai_chuyen_duoc[3] = TRANG_THAI_THANH_TOAN.CHUNG_TU_KHONG_DUOC_DUYET;
                    break;
                case TRANG_THAI_THANH_TOAN.CHUNG_TU_CHUA_DUOC_CHUYEN_KHOAN:
                    // Đã duyệt luôn chứng từ
                    trang_thai_chuyen_duoc[0] = TRANG_THAI_THANH_TOAN.CHUNG_TU_DA_DUOC_DUYET;
                    trang_thai_chuyen_duoc[1] = TRANG_THAI_THANH_TOAN.CHUNG_TU_CHUA_DUOC_CHUYEN_KHOAN;
                    // Có thể quay trở lại đã được lên bảng kê
                    trang_thai_chuyen_duoc[2] = TRANG_THAI_THANH_TOAN.DA_LEN_BANG_KE;
                    trang_thai_chuyen_duoc[3] = "";
                    break;
                case TRANG_THAI_THANH_TOAN.CHUNG_TU_KHONG_DUOC_DUYET:
                    trang_thai_chuyen_duoc[0] = TRANG_THAI_THANH_TOAN.CHUNG_TU_KHONG_DUOC_DUYET;
                    trang_thai_chuyen_duoc[1] = "";
                    trang_thai_chuyen_duoc[2] = "";
                    trang_thai_chuyen_duoc[3] = "";
                    break;
                 case TRANG_THAI_THANH_TOAN.NGAN_HANG_CHUYEN_KHOAN_THANH_CONG:
                    trang_thai_chuyen_duoc[0] = TRANG_THAI_THANH_TOAN.CHUA_CO_XAC_NHAN_CUA_GIANG_VIEN;
                    trang_thai_chuyen_duoc[1] = TRANG_THAI_THANH_TOAN.DA_CO_XAC_NHAN_CUA_GIANG_VIEN;
                    trang_thai_chuyen_duoc[2] = TRANG_THAI_THANH_TOAN.NGAN_HANG_CHUYEN_KHOAN_THANH_CONG;
                    // Chỉnh sửa xác nhận của ngân hàng
                    trang_thai_chuyen_duoc[3] = TRANG_THAI_THANH_TOAN.NGAN_HANG_CHUYEN_KHOAN_KHONG_THANH_CONG;
                    break;
                 case TRANG_THAI_THANH_TOAN.NGAN_HANG_CHUYEN_KHOAN_KHONG_THANH_CONG:
                    trang_thai_chuyen_duoc[0] = TRANG_THAI_THANH_TOAN.NGAN_HANG_CHUYEN_KHOAN_THANH_CONG;
                    trang_thai_chuyen_duoc[1] = TRANG_THAI_THANH_TOAN.NGAN_HANG_CHUYEN_KHOAN_KHONG_THANH_CONG;
                    trang_thai_chuyen_duoc[2] = "";
                    trang_thai_chuyen_duoc[3] = "";
                    break;
                 case TRANG_THAI_THANH_TOAN.CHUA_CO_XAC_NHAN_CUA_GIANG_VIEN:
                    trang_thai_chuyen_duoc[0] = TRANG_THAI_THANH_TOAN.DA_CO_XAC_NHAN_CUA_GIANG_VIEN;
                    trang_thai_chuyen_duoc[1] = TRANG_THAI_THANH_TOAN.CHUA_CO_XAC_NHAN_CUA_GIANG_VIEN;
                    trang_thai_chuyen_duoc[2] = "";
                    trang_thai_chuyen_duoc[3] = "";
                    break;
                 case TRANG_THAI_THANH_TOAN.DA_CO_XAC_NHAN_CUA_GIANG_VIEN:
                    trang_thai_chuyen_duoc[0] = TRANG_THAI_THANH_TOAN.DA_CO_XAC_NHAN_CUA_GIANG_VIEN;
                    // Chỉnh sửa xác nhận của giảng viên
                    trang_thai_chuyen_duoc[1] = TRANG_THAI_THANH_TOAN.CHUA_CO_XAC_NHAN_CUA_GIANG_VIEN;
                    trang_thai_chuyen_duoc[2] = "";
                    trang_thai_chuyen_duoc[3] = "";
                    break;
            }
        }
        public bool check_chuyen_trang_thai(string ip_str_ma_trang_thai_thay_doi)
        {
            for (int v_i = 0; v_i < trang_thai_chuyen_duoc.Length; v_i++)
            {
                if (trang_thai_chuyen_duoc[v_i].Equals(ip_str_ma_trang_thai_thay_doi))
                    return true;
            }
            return false;
        }
    }

}
