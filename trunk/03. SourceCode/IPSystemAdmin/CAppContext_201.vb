Option Explicit On 
Option Strict On

Imports IP.Core.IPCommon
Imports IP.Core.IPUserService
'Imports eSchool.eSchoolData
'Imports eSchool.eSchoolUserService

#Region "Nhiệm vụ của Class"
'************************************************************************
'* Phục vụ lấy dữ liệu đặc trưng cho ứng dụng
'*
'************************************************************************
#End Region

Public Class CAppContext_201

#Region "Variables"
    Private Shared m_us_user As US_HT_NGUOI_SU_DUNG
    Private Shared m_strRunMode As String
#End Region

#Region "Public interface"
    Public Shared Function IsHavingQuyen(ByVal i_str_ma_quyen As String) As Boolean
        Return US_HT_NGUOI_SU_DUNG.IsHavingMA_QUYEN( _
           CAppContext_201.getCurrentUserID() _
           , i_str_ma_quyen)

    End Function

    Public Shared Sub InitializeContext(ByVal i_LoginInfo As CLoginInformation_302)
        '*****************************************************************
        '* Init context 
        '* 1. các giá trị thường dùng trong hệ thống
        '* 2. load phân quyền hệ thống về 
        '* 3. Các biến môi trường khác
        '****************************************************************
        '* 1. các giá trị thường dùng trong hệ thống
        '        Debug.Assert(m_strCurrentUserName <> "")
        Try

            m_us_user = i_LoginInfo.m_us_user
            '* 2. load phân quyền hệ thống về 
            '* 3. Các biến môi trường khác
            Dim v_configReader As New System.Configuration.AppSettingsReader
            m_strRunMode = v_configReader.GetValue("RUN_MODE", IPConstants.C_StringType).ToString()
            v_configReader = Nothing
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Function getCurentDate() As DateTime
        '*****************************************************************
        '*  Gọi để lấy ngày hiện tại
        '***********************************************************************
        Return System.DateTime.Now.Date
    End Function

    Public Shared Function getCurrentUser() As String
        Return m_us_user.strTEN_TRUY_CAP
    End Function

    Public Shared Function getCurrentUserID() As Decimal
        Return m_us_user.dcID
    End Function

    Public Shared Function getRunMode() As String
        Return m_strRunMode
    End Function

    Public Shared Function getAppPath() As String
        Return AppDomain.CurrentDomain.SetupInformation.ApplicationBase
    End Function

    Public Shared Function get_DefaultReportRootPath() As String
        Dim v_strRootPath As String
        v_strRootPath = Application.StartupPath
        'v_strRootPath += "\..\.."
        v_strRootPath += "\Reports"
        Return v_strRootPath
    End Function

    Public Shared Function checkLicense() As Boolean

    End Function
#End Region

End Class
Public Class PHAN_QUYEN
    Public Const BACK_UP_AND_RESTORE As String = "Q1"
    Public Const QUAN_LY_NGUOI_DUNG As String = "Q2"
    Public Const QUAN_LY_DANH_MUC As String = "Q3"
    Public Const DANG_KY_DAU_GIA As String = "Q4"
    Public Const HIEN_THI_KET_QUA_DAU_GIA As String = "Q5"
    Public Const XU_LY_SAU_DAU_GIA As String = "Q6"
    Public Const IN_BAO_CAO As String = "Q7"
    Public Const CHUC_NANG As String = "Q8"
    Public Const LAN_DAU_GIA As String = "Q9"
    Public Const NOP_TIEN_DAT_COC As String = "Q10"
    Public Const DANG_KY As String = "Q11"
    Public Const HOP_LE As String = "Q12"
    Public Const DAU_GIA As String = "Q13"
    Public Const KET_QUA As String = "Q14"
    Public Const XU_LY_DAU_GIA As String = "Q15"
    Public Const NOP_TIEN_MUA_CP As String = "Q16"
End Class
