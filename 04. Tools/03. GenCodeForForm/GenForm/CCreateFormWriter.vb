Imports System.IO
Imports GenForm.CommonSpace
Namespace WriterSpace
    Public Class CCreateFormWriter
        Implements IWrite2File
        Private m_fFileStream As StreamWriter
        Private m_FileName4Read As String
        Private m_FormName As String
        Protected p_oDataTable As DataTable
        Protected p_hst As Hashtable
        Public Sub New(ByVal i_fFileStream As StreamWriter, _
                        ByVal i_FileName4Read As String, _
                        ByVal i_str_FormName As String, _
                        ByVal i_oDataTable As DataTable, _
                        ByVal i_hst As Hashtable)
            m_FileName4Read = i_FileName4Read
            m_fFileStream = i_fFileStream
            m_FormName = i_str_FormName
            p_oDataTable = i_oDataTable
            p_hst = i_hst
        End Sub
        Public Sub imp_IWrite2File_Write2File() Implements CommonSpace.IWrite2File.Write2File
            Dim fReadFile As New StreamReader(m_FileName4Read)
            Dim v_str As String
            v_str = fReadFile.ReadToEnd()
            v_str = v_str.Replace(CConstant.CKeyToReplace.FORM_NAME, m_FormName)
            v_str = v_str.Replace(CConstant.CKeyToReplace.NUM_OF_COLS, get_nums_of_col().ToString())
            v_str = v_str.Replace(CConstant.CKeyToReplace.COLS_INFO, get_cols_info())
            m_fFileStream.Write(v_str)
            m_fFileStream.Write(Constants.vbCrLf)
            m_fFileStream.WriteLine()
            fReadFile.Close()
        End Sub
        Private Function get_cols_info() As String
            Dim v_str As String
            Dim v_str_temp As String
            Dim v_colection As String
            Dim v_str_DataType As String
            Dim v_str_TextAlign As String
            Dim v_str_TextFixedAlign As String = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter.ToString()
            For Each v_colection In p_hst.Keys
                v_str_temp = CConstant.CGridCol.TEMPLATE_COL
                v_str_temp = v_str_temp.Replace(CConstant.CGridCol.TEMPLATE_COL_INFO.NUM_COL, CType(p_hst(v_colection), String))
                v_str_temp = v_str_temp.Replace(CConstant.CGridCol.TEMPLATE_COL_INFO.CAPTION, p_oDataTable.Columns(v_colection).Caption)
                Select Case p_oDataTable.Columns(v_colection).DataType.ToString()
                    Case "System.Decimal", "System.Integer", "System.Int32", "System.DateTime"
                        v_str_DataType = "System.Decimal"
                        v_str_TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.RightCenter.ToString()
                    Case "System.String"
                        If (v_colection.Substring(v_colection.Length - 2) = "YN") Then
                            v_str_DataType = "System.Boolean"
                        Else
                            v_str_DataType = "System.String"
                        End If
                        v_str_TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter.ToString()
                    Case Else
                        Throw (New Exception("Kiểu dữ liệu chưa định nghĩa"))
                End Select
                v_str_temp = v_str_temp.Replace(CConstant.CGridCol.TEMPLATE_COL_INFO.VISIBLE_ENUM, p_oDataTable.Columns(v_colection).ReadOnly.ToString())
                v_str_temp = v_str_temp.Replace(CConstant.CGridCol.TEMPLATE_COL_INFO.DATA_TYPE_ENUM, v_str_DataType)
                v_str_temp = v_str_temp.Replace(CConstant.CGridCol.TEMPLATE_COL_INFO.TEXT_ALIGN_ENUM, v_str_TextAlign)
                v_str_temp = v_str_temp.Replace(CConstant.CGridCol.TEMPLATE_COL_INFO.TEXT_ALIGN_FIXED_ENUM, v_str_TextFixedAlign)
                v_str += v_str_temp
            Next
            Return v_str
        End Function
        Private Function get_nums_of_col() As Decimal
            Dim v_dc_nums_of_col As Decimal = 0
            Dim v_colection As String
            For Each v_colection In p_hst.Keys
                If v_dc_nums_of_col < CType(p_hst(v_colection), Decimal) Then
                    v_dc_nums_of_col = CType(p_hst(v_colection), Decimal)
                End If
            Next
            ' Cộng thêm 1 cột Fixed
            v_dc_nums_of_col += 1
            Return v_dc_nums_of_col
        End Function
    End Class
End Namespace

