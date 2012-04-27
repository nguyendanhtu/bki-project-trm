Imports System.IO
Imports GenForm.CommonSpace
Namespace WriterSpace

    Public Class CRegionPrivateMethods
        Implements IWrite2File

        Private m_strFileName4Read As String
        Private m_fFileStream As StreamWriter
        Private m_dt As DataTable
        Private m_hst As Hashtable
        Private m_str_FormName As String

        Public Sub New(ByVal i_fFileStream As StreamWriter, ByVal i_strFileName4Read As String, _
                          ByVal i_dt As DataTable, ByVal i_hst As Hashtable, ByVal i_str_FormName As String)
            m_strFileName4Read = i_strFileName4Read
            m_fFileStream = i_fFileStream
            m_dt = i_dt
            m_hst = i_hst
            m_str_FormName = i_str_FormName

        End Sub

        Public Sub imp_IWrite2File_Write2File() Implements CommonSpace.IWrite2File.Write2File
            Dim v_fFileReader As New StreamReader(m_strFileName4Read)
            Dim v_str As String
            v_str = v_fFileReader.ReadToEnd()
            v_str = v_str.Replace(CConstant.CKeyToReplace.COLUMN_LIST_TO_DISPLAY, get_colection_of_hst())
            v_str = v_str.Replace(CConstant.CKeyToReplace.U_TABLE_NAME, m_dt.TableName.ToUpper())
            v_str = v_str.Replace(CConstant.CKeyToReplace.L_TABLE_NAME, m_dt.TableName.ToLower())
            v_str = v_str.Replace(CConstant.CKeyToReplace.FORM_NAME, m_str_FormName)

            m_fFileStream.Write(v_str)
            m_fFileStream.Write(Constants.vbCrLf)
            m_fFileStream.WriteLine()
            v_fFileReader.Close()
        End Sub
        Private Function get_colection_of_hst() As String
            Dim v_str As String = ""
            Dim v_colection As Object
            For Each v_colection In m_hst.Keys
                v_str += "v_htb.Add(" + m_dt.TableName.ToUpper() + "." + _
                        CType(v_colection, String) + ", e_col_Number." + _
                        CType(v_colection, String) + ");" + Chr(13) + Chr(9) + Chr(9) + Chr(9)

            Next
            Return v_str
        End Function
    End Class
End Namespace