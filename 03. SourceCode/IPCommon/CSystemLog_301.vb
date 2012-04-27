Option Strict On
Option Explicit On 
'Imports environment
Imports System.Web
Public Class CSystemLog_301

#Region "Nhiệm vụ của Class"
    '************************************************************************
    '* Created by: Csung, 2003-11
    '* Xử lý các exception của hệ thống 
    '* - Chú ý: Class này thuộc lớp cuối cùng, sẽ không reference đến một lớp nào khác
    '*
    '************************************************************************
#End Region

#Region "Variables "
    Private Shared m_strRunMode As String = IPConstants.C_RUNMODE_NOT_LOADED
#End Region

#Region "class public interface"
    Public Shared Sub Initialize()
        If m_strRunMode = IPConstants.C_RUNMODE_NOT_LOADED Then
            Dim v_configReader As New System.Configuration.AppSettingsReader
            m_strRunMode = v_configReader.GetValue("RUN_MODE", IPConstants.C_StringType).ToString()
        End If
    End Sub

    Public Shared Sub ExceptionHandle(ByVal i_exp As System.Exception)
        Try
            Initialize()
            ' xử lý lỗi theo các trường hợp khác nhau
            ' tạm thời dùng theo kiểu select-case,
            ' nếu có nhu cầu cụ thể sẽ chuyển sang dạng strategy
            Select Case m_strRunMode
                Case IPConstants.C_RUNMODE_TEST
                    System.Windows.Forms.MessageBox.Show("environment-TEST: " & i_exp.Message, "IP-LOGGING ")
                Case IPConstants.C_RUNMODE_DEVELOP
                    System.Windows.Forms.MessageBox.Show("environment-DEVELOPE: " & i_exp.Message, "IP-LOGGING ")
                Case IPConstants.C_RUNMODE_RUNTIME
                    System.Windows.Forms.MessageBox.Show("environment-RUNTIME: " & i_exp.Message, "IP-LOGGING ")
            End Select
        Catch
            System.Windows.Forms.MessageBox.Show("environment- Không có file Ini")
        End Try
    End Sub
    Public Shared Sub ExceptionHandle(ByVal i_page As System.Web.UI.Page, ByVal i_exp As System.Exception)
        Try
            Initialize()
            ' xử lý lỗi theo các trường hợp khác nhau
            ' tạm thời dùng theo kiểu select-case,
            ' nếu có nhu cầu cụ thể sẽ chuyển sang dạng strategy
            Select Case m_strRunMode
                Case IPConstants.C_RUNMODE_TEST
                    i_page.Response.Redirect("../MessageError.aspx?mess=Title Website: " + i_page.Title + ". Message: " + i_exp.Message + " Source: " + i_exp.Source)

                Case IPConstants.C_RUNMODE_DEVELOP
                    i_page.Response.Redirect("../MessageError.aspx?mess=Title Website: " + i_page.Title + ". Message: " + i_exp.Message + " Source: " + i_exp.Source)
                Case IPConstants.C_RUNMODE_RUNTIME
                    i_page.Response.Redirect("../MessageError.aspx?mess=Title Website: " + i_page.Title + ". Message: " + i_exp.Message + " Source: " + i_exp.Source)
            End Select
        Catch
            'i_page.Response.Redirect("../MessageError.aspx?mess=Title Website: " + i_page.Title + ". Message: " + i_exp.Message + " Source: " + i_exp.Source)
        End Try
    End Sub
#End Region
End Class
