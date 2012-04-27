Imports System.IO
Imports GenForm.CommonSpace
Namespace WriterSpace
    Public Class CRegionDataStructure
        Implements IWrite2File

        Private m_strFileName4Read As String
        Private m_fFileStream As StreamWriter
        Private m_hst As Hashtable

        Public Sub New(ByVal i_fFileStream As StreamWriter, ByVal i_strFileName4Read As String, _
                          ByVal i_hst As Hashtable)
            m_strFileName4Read = i_strFileName4Read
            m_fFileStream = i_fFileStream
            m_hst = i_hst

        End Sub

        Public Sub imp_IWrite2File_Write2File() Implements CommonSpace.IWrite2File.Write2File
            Dim v_fFileReader As New StreamReader(m_strFileName4Read)
            Dim v_str As String
            v_str = v_fFileReader.ReadToEnd()
            v_str = v_str.Replace(CConstant.CKeyToReplace.COLUMN_LIST_TO_DISPLAY, get_ColectionOfEnum())
            m_fFileStream.Write(v_str)
            m_fFileStream.Write(Constants.vbCrLf)
            m_fFileStream.WriteLine()
            v_fFileReader.Close()
        End Sub

        Private Function get_ColectionOfEnum() As String
            Dim v_str As String = ""
            Dim v_colection As String
            For Each v_colection In m_hst.Keys
                v_str += v_colection + " = " + CType(m_hst(v_colection), String) + Chr(13) + ","
            Next
            If Not (v_str = "") Then
                v_str = v_str.Remove(v_str.Length - 1, 1)
            End If
            Return v_str
        End Function
    End Class

End Namespace