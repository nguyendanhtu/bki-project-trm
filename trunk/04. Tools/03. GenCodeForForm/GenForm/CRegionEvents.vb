Imports System.IO
Imports GenForm.CommonSpace
Namespace WriterSpace
    Public Class CRegionEvents
        Implements IWrite2File

        Private m_strFileName4Read As String
        Private m_fFileStream As StreamWriter
        Private m_dt As DataTable
        Private m_str_FormName As String

        Public Sub New(ByVal i_fFileStream As StreamWriter, ByVal i_strFileName4Read As String, _
                          ByVal i_dt As DataTable, ByVal i_str_FormName As String)
            m_strFileName4Read = i_strFileName4Read
            m_fFileStream = i_fFileStream
            m_dt = i_dt
            m_str_FormName = i_str_FormName
        End Sub

        Public Sub imp_IWrite2File_Write2File() Implements CommonSpace.IWrite2File.Write2File
            Dim v_fFileReader As New StreamReader(m_strFileName4Read)
            Dim v_str As String
            v_str = v_fFileReader.ReadToEnd()
            v_str = v_str.Replace(CConstant.CKeyToReplace.FORM_NAME, m_str_FormName)
            v_str = v_str.Replace(CConstant.CKeyToReplace.L_TABLE_NAME, m_dt.TableName.ToLower())
            m_fFileStream.Write(v_str)
            m_fFileStream.Write(Constants.vbCrLf)
            m_fFileStream.WriteLine()
            v_fFileReader.Close()
        End Sub
    End Class
End Namespace