Imports System.IO
Imports GenForm.CommonSpace
Namespace WriterSpace
    Public Class CImportWriter
        Implements IWrite2File

        Private m_fFileStream As StreamWriter
        Private m_strFileName4Read As String
        Public Sub New(ByVal i_fFileStream As StreamWriter, ByVal i_strFileName4Read As String)
            m_fFileStream = i_fFileStream
            m_strFileName4Read = i_strFileName4Read
        End Sub
        Private Sub imp_IWrite2File_Write2File() Implements IWrite2File.Write2File
            Dim v_fFileReader As New StreamReader(m_strFileName4Read)
            Dim v_str As String
            v_str = v_fFileReader.ReadToEnd()
            m_fFileStream.Write(v_str)
            m_fFileStream.Write(Constants.vbCrLf)
            m_fFileStream.WriteLine()
            v_fFileReader.Close()
        End Sub
    End Class
End Namespace
