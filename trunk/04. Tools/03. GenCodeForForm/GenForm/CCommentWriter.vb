Imports System.IO
Imports GenForm.CommonSpace

Namespace WriterSpace
    Public Class CCommentWriter
        Implements IWrite2File
        Private m_FileName4Read As String
        Private m_FileStream As StreamWriter
        Private m_AuthorName As String
        Private m_sTableName As String

        Public Sub New(ByVal i_fFileStream As StreamWriter, ByVal i_FileName4Read As String, _
                    ByVal i_AuthorName As String, ByVal i_sTableName As String)
            m_FileName4Read = i_FileName4Read
            m_FileStream = i_fFileStream
            m_AuthorName = i_AuthorName
            m_sTableName = i_sTableName
        End Sub

        Private Sub imp_IWrite2File_Write2File() Implements IWrite2File.Write2File
            Dim fReadFile As New StreamReader(m_FileName4Read)
            Dim v_str As String
            v_str = fReadFile.ReadToEnd()
            v_str = v_str.Replace(CConstant.CKeyToReplace.CREATED_USER, m_AuthorName)
            v_str = v_str.Replace(CConstant.CKeyToReplace.CREATED_DATE, Format(Now(), "dd/MM/yyyy hh:mm:ss"))
            v_str = v_str.Replace(CConstant.CKeyToReplace.U_TABLE_NAME, m_sTableName.ToUpper())
            m_FileStream.Write(v_str)
            m_FileStream.Write(Constants.vbCrLf)
            m_FileStream.WriteLine()
            fReadFile.Close()
        End Sub
    End Class
End Namespace