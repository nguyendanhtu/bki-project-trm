Imports System.IO
Imports GenForm.CommonSpace
Namespace WriterSpace
    Public Class CCollectionOfForm
        Implements IWrite2File
        Dim m_fFileStream As StreamWriter
        Dim m_str_FormName As String
        Dim m_FileName4Read As String
        Public Sub New(ByVal i_fFileStream As StreamWriter, ByVal i_str_FormName As String, ByVal i_FileName4Read As String)
            m_fFileStream = i_fFileStream
            m_str_FormName = i_str_FormName
            m_FileName4Read = i_FileName4Read
        End Sub
        Private Sub imp_IWrite2File_Write2File() Implements IWrite2File.Write2File
            Dim fReadFile As New StreamReader(m_FileName4Read)
            Dim v_str As String
            v_str = fReadFile.ReadToEnd()
            v_str = v_str.Replace(CConstant.CKeyToReplace.FORM_NAME, m_str_FormName)
            m_fFileStream.Write(v_str)
            m_fFileStream.Write(Constants.vbCrLf)
            m_fFileStream.WriteLine()
            fReadFile.Close()
        End Sub
    End Class
End Namespace