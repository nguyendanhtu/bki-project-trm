Imports System.IO
Imports GenForm.CommonSpace

Namespace WriterSpace
    Public Class CEndFormWriter
        Implements IWrite2File
        Private m_FileName4Read As String
        Private m_FileStream As StreamWriter
        Public Sub New(ByVal i_fFileStream As StreamWriter, ByVal i_FileName4Read As String)
            m_FileName4Read = i_FileName4Read
            m_FileStream = i_fFileStream
        End Sub
        Public Sub imp_IWrite2File_Write2File() Implements CommonSpace.IWrite2File.Write2File
            Dim fReadFile As New StreamReader(m_FileName4Read)
            Dim v_str As String
            v_str = fReadFile.ReadToEnd()
            m_FileStream.Write(v_str)
            m_FileStream.Write(Constants.vbCrLf)
            m_FileStream.WriteLine()
            fReadFile.Close()
        End Sub
    End Class
End Namespace