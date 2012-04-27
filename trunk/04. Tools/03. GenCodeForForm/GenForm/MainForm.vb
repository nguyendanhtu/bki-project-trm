Imports System.Data.SqlClient
Imports System.Data
Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Soap

Imports GenForm.CommonSpace
Imports GenForm.BuilderSpace


Public Class m_frm_main
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        format_control()

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents m_pnl As System.Windows.Forms.Panel
    Friend WithEvents m_fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents m_cmd_exit As System.Windows.Forms.Button
    Friend WithEvents m_cmd_gen As System.Windows.Forms.Button
    Friend WithEvents m_cmd_display As System.Windows.Forms.Button
    Friend WithEvents m_grp As System.Windows.Forms.GroupBox
    Friend WithEvents txtServer As System.Windows.Forms.TextBox
    Friend WithEvents txtPath As System.Windows.Forms.TextBox
    Friend WithEvents txtCreatedUser As System.Windows.Forms.TextBox
    Friend WithEvents txtTableName As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents txtDBName As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents m_cmd_Browse As System.Windows.Forms.Button
    Friend WithEvents dlgSave As System.Windows.Forms.SaveFileDialog
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents m_radVB As System.Windows.Forms.RadioButton
    Friend WithEvents m_radCSharp As System.Windows.Forms.RadioButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtFormName As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.m_pnl = New System.Windows.Forms.Panel
        Me.m_cmd_display = New System.Windows.Forms.Button
        Me.m_cmd_gen = New System.Windows.Forms.Button
        Me.m_cmd_exit = New System.Windows.Forms.Button
        Me.m_fg = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.m_grp = New System.Windows.Forms.GroupBox
        Me.txtFormName = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.m_radVB = New System.Windows.Forms.RadioButton
        Me.m_radCSharp = New System.Windows.Forms.RadioButton
        Me.txtServer = New System.Windows.Forms.TextBox
        Me.txtPath = New System.Windows.Forms.TextBox
        Me.txtCreatedUser = New System.Windows.Forms.TextBox
        Me.txtTableName = New System.Windows.Forms.TextBox
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.txtUserName = New System.Windows.Forms.TextBox
        Me.txtDBName = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.m_cmd_Browse = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.dlgSave = New System.Windows.Forms.SaveFileDialog
        Me.m_pnl.SuspendLayout()
        CType(Me.m_fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.m_grp.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'm_pnl
        '
        Me.m_pnl.Controls.Add(Me.m_cmd_display)
        Me.m_pnl.Controls.Add(Me.m_cmd_gen)
        Me.m_pnl.Controls.Add(Me.m_cmd_exit)
        Me.m_pnl.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.m_pnl.DockPadding.All = 4
        Me.m_pnl.Location = New System.Drawing.Point(0, 345)
        Me.m_pnl.Name = "m_pnl"
        Me.m_pnl.Size = New System.Drawing.Size(796, 36)
        Me.m_pnl.TabIndex = 2
        '
        'm_cmd_display
        '
        Me.m_cmd_display.Dock = System.Windows.Forms.DockStyle.Left
        Me.m_cmd_display.Location = New System.Drawing.Point(4, 4)
        Me.m_cmd_display.Name = "m_cmd_display"
        Me.m_cmd_display.Size = New System.Drawing.Size(75, 28)
        Me.m_cmd_display.TabIndex = 0
        Me.m_cmd_display.Text = "Hiển thị lưới"
        '
        'm_cmd_gen
        '
        Me.m_cmd_gen.Dock = System.Windows.Forms.DockStyle.Right
        Me.m_cmd_gen.Location = New System.Drawing.Point(642, 4)
        Me.m_cmd_gen.Name = "m_cmd_gen"
        Me.m_cmd_gen.Size = New System.Drawing.Size(75, 28)
        Me.m_cmd_gen.TabIndex = 1
        Me.m_cmd_gen.Text = "Gen&Form"
        '
        'm_cmd_exit
        '
        Me.m_cmd_exit.Dock = System.Windows.Forms.DockStyle.Right
        Me.m_cmd_exit.Location = New System.Drawing.Point(717, 4)
        Me.m_cmd_exit.Name = "m_cmd_exit"
        Me.m_cmd_exit.Size = New System.Drawing.Size(75, 28)
        Me.m_cmd_exit.TabIndex = 2
        Me.m_cmd_exit.Text = "&Thoát"
        '
        'm_fg
        '
        Me.m_fg.ColumnInfo = "7,1,0,0,0,85,Columns:0{Width:8;}" & Microsoft.VisualBasic.ChrW(9) & "1{Width:142;Caption:""Tên cột"";AllowEditing:False" & _
        ";DataType:System.String;TextAlign:LeftCenter;TextAlignFixed:CenterCenter;}" & Microsoft.VisualBasic.ChrW(9) & "2{Wid" & _
        "th:70;Caption:""Kiểu dữ liệu"";AllowEditing:False;DataType:System.String;TextAlign" & _
        ":LeftCenter;TextAlignFixed:CenterCenter;}" & Microsoft.VisualBasic.ChrW(9) & "3{Width:55;Caption:""Display grid"";Data" & _
        "Type:System.Boolean;ImageAlign:CenterCenter;}" & Microsoft.VisualBasic.ChrW(9) & "4{Width:68;Caption:""Cột hiển thị"";" & _
        "DataType:System.Int32;TextAlign:RightCenter;}" & Microsoft.VisualBasic.ChrW(9) & "5{Width:109;Caption:""Caption"";Data" & _
        "Type:System.String;TextAlign:LeftCenter;TextAlignFixed:CenterCenter;}" & Microsoft.VisualBasic.ChrW(9) & "6{Width:45" & _
        ";Caption:""Visible"";DataType:System.Boolean;TextAlignFixed:CenterCenter;ImageAlig" & _
        "n:CenterCenter;ImageAlignFixed:CenterCenter;}" & Microsoft.VisualBasic.ChrW(9)
        Me.m_fg.Dock = System.Windows.Forms.DockStyle.Right
        Me.m_fg.Location = New System.Drawing.Point(276, 0)
        Me.m_fg.Name = "m_fg"
        Me.m_fg.Size = New System.Drawing.Size(520, 345)
        Me.m_fg.Styles = New C1.Win.C1FlexGrid.CellStyleCollection("Normal{Font:Microsoft Sans Serif, 8.25pt;}" & Microsoft.VisualBasic.ChrW(9) & "Fixed{BackColor:Control;ForeColor:Cont" & _
        "rolText;Border:Flat,1,ControlDark,Both;}" & Microsoft.VisualBasic.ChrW(9) & "Highlight{BackColor:Highlight;ForeColor" & _
        ":HighlightText;}" & Microsoft.VisualBasic.ChrW(9) & "Search{BackColor:Highlight;ForeColor:HighlightText;}" & Microsoft.VisualBasic.ChrW(9) & "Frozen{Bac" & _
        "kColor:Window;}" & Microsoft.VisualBasic.ChrW(9) & "EmptyArea{BackColor:AppWorkspace;Border:Flat,1,ControlDarkDark,B" & _
        "oth;}" & Microsoft.VisualBasic.ChrW(9) & "GrandTotal{BackColor:Black;ForeColor:White;}" & Microsoft.VisualBasic.ChrW(9) & "Subtotal0{BackColor:ControlDa" & _
        "rk;ForeColor:White;}" & Microsoft.VisualBasic.ChrW(9) & "Subtotal1{BackColor:ControlDarkDark;ForeColor:White;}" & Microsoft.VisualBasic.ChrW(9) & "Subto" & _
        "tal2{BackColor:ControlDarkDark;ForeColor:White;}" & Microsoft.VisualBasic.ChrW(9) & "Subtotal3{BackColor:ControlDark" & _
        "Dark;ForeColor:White;}" & Microsoft.VisualBasic.ChrW(9) & "Subtotal4{BackColor:ControlDarkDark;ForeColor:White;}" & Microsoft.VisualBasic.ChrW(9) & "Sub" & _
        "total5{BackColor:ControlDarkDark;ForeColor:White;}" & Microsoft.VisualBasic.ChrW(9) & "CustomStyle{BackColor:Desktop" & _
        ";ForeColor:HighlightText;}" & Microsoft.VisualBasic.ChrW(9))
        Me.m_fg.TabIndex = 1
        '
        'm_grp
        '
        Me.m_grp.Controls.Add(Me.txtFormName)
        Me.m_grp.Controls.Add(Me.Label8)
        Me.m_grp.Controls.Add(Me.GroupBox1)
        Me.m_grp.Controls.Add(Me.txtServer)
        Me.m_grp.Controls.Add(Me.txtPath)
        Me.m_grp.Controls.Add(Me.txtCreatedUser)
        Me.m_grp.Controls.Add(Me.txtTableName)
        Me.m_grp.Controls.Add(Me.txtPassword)
        Me.m_grp.Controls.Add(Me.txtUserName)
        Me.m_grp.Controls.Add(Me.txtDBName)
        Me.m_grp.Controls.Add(Me.Label7)
        Me.m_grp.Controls.Add(Me.m_cmd_Browse)
        Me.m_grp.Controls.Add(Me.Label6)
        Me.m_grp.Controls.Add(Me.Label5)
        Me.m_grp.Controls.Add(Me.Label4)
        Me.m_grp.Controls.Add(Me.Label3)
        Me.m_grp.Controls.Add(Me.Label2)
        Me.m_grp.Controls.Add(Me.Label1)
        Me.m_grp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.m_grp.Location = New System.Drawing.Point(0, 0)
        Me.m_grp.Name = "m_grp"
        Me.m_grp.Size = New System.Drawing.Size(276, 345)
        Me.m_grp.TabIndex = 0
        Me.m_grp.TabStop = False
        Me.m_grp.Text = "Thông tin"
        '
        'txtFormName
        '
        Me.txtFormName.Location = New System.Drawing.Point(76, 244)
        Me.txtFormName.Name = "txtFormName"
        Me.txtFormName.Size = New System.Drawing.Size(190, 20)
        Me.txtFormName.TabIndex = 16
        Me.txtFormName.Text = ""
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(8, 244)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 19)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Tên Form"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.m_radVB)
        Me.GroupBox1.Controls.Add(Me.m_radCSharp)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.Location = New System.Drawing.Point(3, 296)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(270, 46)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "File extension"
        '
        'm_radVB
        '
        Me.m_radVB.Location = New System.Drawing.Point(146, 16)
        Me.m_radVB.Name = "m_radVB"
        Me.m_radVB.TabIndex = 1
        Me.m_radVB.Text = "VB .Net (*.vb)"
        '
        'm_radCSharp
        '
        Me.m_radCSharp.Checked = True
        Me.m_radCSharp.Location = New System.Drawing.Point(26, 15)
        Me.m_radCSharp.Name = "m_radCSharp"
        Me.m_radCSharp.TabIndex = 0
        Me.m_radCSharp.TabStop = True
        Me.m_radCSharp.Text = "C#  (*.cs)"
        '
        'txtServer
        '
        Me.txtServer.Location = New System.Drawing.Point(76, 24)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(190, 20)
        Me.txtServer.TabIndex = 1
        Me.txtServer.Text = "ACBNT"
        '
        'txtPath
        '
        Me.txtPath.Enabled = False
        Me.txtPath.Location = New System.Drawing.Point(76, 192)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.Size = New System.Drawing.Size(190, 20)
        Me.txtPath.TabIndex = 13
        Me.txtPath.Text = "C:"
        '
        'txtCreatedUser
        '
        Me.txtCreatedUser.Location = New System.Drawing.Point(76, 164)
        Me.txtCreatedUser.Name = "txtCreatedUser"
        Me.txtCreatedUser.Size = New System.Drawing.Size(190, 20)
        Me.txtCreatedUser.TabIndex = 11
        Me.txtCreatedUser.Text = ""
        '
        'txtTableName
        '
        Me.txtTableName.Location = New System.Drawing.Point(76, 136)
        Me.txtTableName.Name = "txtTableName"
        Me.txtTableName.Size = New System.Drawing.Size(190, 20)
        Me.txtTableName.TabIndex = 9
        Me.txtTableName.Text = ""
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(76, 108)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(190, 20)
        Me.txtPassword.TabIndex = 7
        Me.txtPassword.Text = "eSchool"
        '
        'txtUserName
        '
        Me.txtUserName.Location = New System.Drawing.Point(76, 80)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(190, 20)
        Me.txtUserName.TabIndex = 5
        Me.txtUserName.Text = "eSchool"
        '
        'txtDBName
        '
        Me.txtDBName.Location = New System.Drawing.Point(76, 52)
        Me.txtDBName.Name = "txtDBName"
        Me.txtDBName.Size = New System.Drawing.Size(190, 20)
        Me.txtDBName.TabIndex = 3
        Me.txtDBName.Text = "eSchool"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(8, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 19)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Server"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'm_cmd_Browse
        '
        Me.m_cmd_Browse.Location = New System.Drawing.Point(238, 220)
        Me.m_cmd_Browse.Name = "m_cmd_Browse"
        Me.m_cmd_Browse.Size = New System.Drawing.Size(27, 21)
        Me.m_cmd_Browse.TabIndex = 14
        Me.m_cmd_Browse.Text = "..."
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(10, 192)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 19)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Dir to save"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 164)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 19)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Người tạo"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 136)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 19)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Tên bảng"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 108)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 19)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Password"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 19)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "User Name"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 19)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Database"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dlgSave
        '
        Me.dlgSave.FileName = "frm_"
        Me.dlgSave.Filter = "VB .NET Files |*.vb | C# Files | *.cs | All files| *.*"
        Me.dlgSave.Title = "Create file"
        '
        'm_frm_main
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(796, 381)
        Me.Controls.Add(Me.m_grp)
        Me.Controls.Add(Me.m_fg)
        Me.Controls.Add(Me.m_pnl)
        Me.Name = "m_frm_main"
        Me.Text = "Gen Form Danh mục"
        Me.m_pnl.ResumeLayout(False)
        CType(Me.m_fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.m_grp.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Data Structure"

    Private Enum e_colNumber
        ten_cot = 1
        kieu_du_lieu = 2
        hien_thi_luoi = 3
        cot_hien_thi = 4
        caption = 5
        visible = 6
    End Enum

#End Region

#Region "Members"
    Private m_hst As New Hashtable
#End Region

#Region "Private Method"
    Private Sub format_control()
        m_fg.Cols.Frozen = e_colNumber.kieu_du_lieu
        m_cmd_gen.Enabled = False
        m_fg.Rows.Count = m_fg.Rows.Fixed
        m_fg.Col = e_colNumber.cot_hien_thi
    End Sub
    Private Sub load_data_2_form()
        Dim v_objStream As Stream = File.OpenRead(CUtil.getCurDir() & "\GenForm.xml")
        Dim v_objXmlFormat As SoapFormatter = New SoapFormatter
        Dim v_objInfo As New FormInfo
        v_objInfo = CType(v_objXmlFormat.Deserialize(v_objStream), FormInfo)
        v_objStream.Close()
        txtServer.Text = v_objInfo.m_strServer
        txtTableName.Text = v_objInfo.m_strTableName
        txtUserName.Text = v_objInfo.m_strUserName
        txtDBName.Text = v_objInfo.m_strDatabase
        txtCreatedUser.Text = v_objInfo.m_strNguoiTao
        txtPassword.Text = v_objInfo.m_strPassword
        txtPath.Text = v_objInfo.m_strPath
        txtFormName.Text = "frm_" & v_objInfo.m_strTableName.ToUpper()
    End Sub
    Private Function check_validate_for_information() As Boolean
        If Me.txtTableName.Text.Trim = "" Then
            MessageBox.Show("Tên bảng, please")
            Return False
            Exit Function
        End If

        If Me.txtUserName.Text.Trim = "" Then
            MessageBox.Show("Tên người, please")
            Return False
            Exit Function
        End If
        If Me.txtFormName.Text.Trim = "" Then
            MessageBox.Show("Tên Form, please")
            Return False
            Exit Function
        End If
        Return True
    End Function
    Private Function check_validate_for_grid() As Boolean
        Dim v_i_GridRow As Int32
        For v_i_GridRow = m_fg.Rows.Fixed To m_fg.Rows.Count - 1
            If (CType(m_fg(v_i_GridRow, e_colNumber.hien_thi_luoi), Boolean)) Then
                If (m_fg(v_i_GridRow, e_colNumber.cot_hien_thi) Is Nothing) Then
                    MessageBox.Show("Cột hiện thị, please")
                    Return False
                End If
            End If
        Next
        Return True
    End Function
    Private Sub load_data_2_grid(ByVal i_dt As DataTable)
        m_fg.Rows.Count = m_fg.Rows.Fixed
        Dim v_dt_col As New DataColumn
        For Each v_dt_col In i_dt.Columns
            m_fg.Rows.Count += 1
            m_fg(m_fg.Rows.Count - 1, e_colNumber.ten_cot) = v_dt_col.ColumnName
            Select Case v_dt_col.DataType.ToString()
                Case "System.Decimal", "System.Integer", "System.Int32"
                    m_fg(m_fg.Rows.Count - 1, e_colNumber.kieu_du_lieu) = "Decimal"
                Case "System.String"
                    m_fg(m_fg.Rows.Count - 1, e_colNumber.kieu_du_lieu) = "String"
                Case "System.DateTime"
                    m_fg(m_fg.Rows.Count - 1, e_colNumber.kieu_du_lieu) = "Datetime"
                Case Else
                    m_fg(m_fg.Rows.Count - 1, e_colNumber.kieu_du_lieu) = "Chưa định nghĩa"
            End Select
            m_fg(m_fg.Rows.Count - 1, e_colNumber.hien_thi_luoi) = True
            m_fg(m_fg.Rows.Count - 1, e_colNumber.visible) = True
        Next

    End Sub
    Private Function get_dir_name(ByVal i_strFileName As String) As String
        Dim v_str As String
        Dim v_Pos As Integer
        v_Pos = i_strFileName.LastIndexOf("\")
        v_str = i_strFileName.Substring(0, v_Pos)
        Return v_str
    End Function
    Private Function get_data_table_from_table_name() As DataTable
        Dim v_ds As New DataSet
        Dim v_da As SqlDataAdapter = CProvider.getAdapter()
        Dim v_cmd As New SqlCommand

        v_cmd.Connection = CProvider.getConnection(txtServer.Text, _
                        txtDBName.Text, txtUserName.Text, txtPassword.Text)
        v_cmd.CommandText = "SELECT * FROM " & txtTableName.Text
        v_cmd.CommandType = CommandType.Text
        v_da.SelectCommand = v_cmd
        v_da.Fill(v_ds)
        v_ds.Tables(0).TableName = txtTableName.Text.ToUpper()
        Return v_ds.Tables(0)
    End Function
    Private Sub write_2_file(ByVal i_dt As DataTable _
                            , ByVal i_fg As C1.Win.C1FlexGrid.C1FlexGrid _
                            , ByVal i_str_file_name As String _
                            , ByVal i_str_collection_file_name As String)
        Dim v_i_CurrentRow As Int32
        m_hst.Clear()
        For v_i_CurrentRow = i_fg.Rows.Fixed To i_fg.Rows.Count - 1
            If CType(i_fg(v_i_CurrentRow, e_colNumber.hien_thi_luoi), Boolean) Then
                m_hst.Add(i_fg(v_i_CurrentRow, e_colNumber.ten_cot), _
                    i_fg(v_i_CurrentRow, e_colNumber.cot_hien_thi))
                i_dt.Columns(CType(i_fg(v_i_CurrentRow, e_colNumber.ten_cot), String)).Caption = _
                CType(i_fg(v_i_CurrentRow, e_colNumber.caption), String)
                ' Dùng tạm tính chất ReadOnly thay cho Visible của column
                ' Không đẹp lắm!
                i_dt.Columns(CType(i_fg(v_i_CurrentRow, e_colNumber.ten_cot), String)).ReadOnly = _
                CType(i_fg(v_i_CurrentRow, e_colNumber.visible), Boolean)
            End If
        Next

        Dim v_oClass As IWrite2File
        Dim v_fFileStream As New StreamWriter(i_str_file_name)
        Dim v_fFileStreamCreateCollection As New StreamWriter(i_str_collection_file_name)
        Dim v_oBuilder As CClassBuilder
        v_oBuilder = CClassBuilderFactory.CreateCCsharpClassBuiler(i_dt, m_hst, txtFormName.Text, v_fFileStream, v_fFileStreamCreateCollection, txtCreatedUser.Text)
        v_oClass = v_oBuilder.BuildClass()
        v_oClass.Write2File()
        v_fFileStream.Flush()
        v_fFileStream.Close()
        v_fFileStreamCreateCollection.Flush()
        v_fFileStreamCreateCollection.Close()
    End Sub
    Private Sub Save()
        Dim v_objStream As Stream = File.OpenWrite(CUtil.getCurDir() & "\GenForm.xml")
        Dim v_objXmlFormat As SoapFormatter = New SoapFormatter
        Dim v_objInfo As New FormInfo
        v_objInfo.m_strServer = txtServer.Text
        v_objInfo.m_strTableName = txtTableName.Text
        v_objInfo.m_strUserName = txtUserName.Text
        v_objInfo.m_strDatabase = txtDBName.Text
        v_objInfo.m_strNguoiTao = txtCreatedUser.Text
        v_objInfo.m_strPassword = txtPassword.Text
        v_objInfo.m_strPath = txtPath.Text
        v_objXmlFormat.Serialize(v_objStream, v_objInfo)
        v_objStream.Close()
    End Sub
#End Region
    '
    '
    '   EVENT HALDERS
    '
    '

    Private Sub m_frm_main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        load_data_2_form()
    End Sub

    Private Sub m_cmd_exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_cmd_exit.Click
        Me.Close()
    End Sub

    Private Sub m_cmd_display_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_cmd_display.Click
        If Not check_validate_for_information() Then Return
        Try
            Dim v_dt As DataTable = get_data_table_from_table_name()
            load_data_2_grid(v_dt)
            m_cmd_gen.Enabled = True
            m_fg.Focus()
        Catch v_e As Exception
            MsgBox(v_e.Message)
        End Try
    End Sub

    Private Sub m_cmd_Browse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_cmd_Browse.Click
        If dlgSave.ShowDialog() = DialogResult.OK Then
            txtPath.Text = Me.get_dir_name(dlgSave.FileName)
        End If
    End Sub

    Private Sub m_cmd_gen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_cmd_gen.Click
        If Not check_validate_for_information() Then Return
        If Not check_validate_for_grid() Then Return
        Try

            Dim v_dt As DataTable = get_data_table_from_table_name()

            If m_radVB.Checked Then
                'write_2_file(v_dt, m_fg, txtPath.Text & "\" & txtFormName.Text & ".vb")
            Else
                write_2_file(v_dt, m_fg, _
                            txtPath.Text & "\" & txtFormName.Text & ".cs", _
                            txtPath.Text & "\" & txtFormName.Text & ".resx")
            End If
            Me.Save()
            MsgBox("Đã xong!")
        Catch v_e As Exception
            MsgBox(v_e.Message)
        End Try
    End Sub

    Private Sub m_fg_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles m_fg.AfterEdit

        Select Case e.Col
            Case e_colNumber.hien_thi_luoi
                If CType(m_fg(e.Row, e.Col), Boolean) Then
                    m_fg(e.Row, e_colNumber.visible) = True
                    m_fg.Rows(e.Row).Style = m_fg.Styles("CustomStyle")
                Else
                    m_fg(e.Row, e_colNumber.cot_hien_thi) = Nothing
                    m_fg(e.Row, e_colNumber.visible) = False
                    m_fg(e.Row, e_colNumber.caption) = Nothing
                    m_fg.Rows(e.Row).Style = m_fg.Styles.Normal
                End If

        End Select



    End Sub
End Class

<Serializable()> _
Public Class FormInfo
#Region "Thuc thi ISerializable"
    Implements ISerializable

    Public m_strServer As String
    Public m_strDatabase As String
    Public m_strUserName As String
    Public m_strPassword As String
    Public m_strPath As String
    Public m_strTableName As String
    Public m_strNguoiTao As String

    Public Sub New()
    End Sub

    Private Sub New(ByVal si As SerializationInfo, _
        ByVal ctx As StreamingContext)
        m_strServer = si.GetString("Server")
        m_strDatabase = si.GetString("Database")
        m_strUserName = si.GetString("Username")
        m_strPassword = si.GetString("Password")
        m_strPath = si.GetString("Path")
        m_strTableName = si.GetString("Tablename")
        m_strNguoiTao = si.GetString("NguoiTao")
    End Sub

    Public Sub GetObjectData(ByVal info As System.Runtime.Serialization.SerializationInfo, ByVal context As System.Runtime.Serialization.StreamingContext) Implements System.Runtime.Serialization.ISerializable.GetObjectData
        info.AddValue("Server", m_strServer)
        info.AddValue("Database", m_strDatabase)
        info.AddValue("Username", m_strUserName)
        info.AddValue("Password", m_strPassword)
        info.AddValue("Path", m_strPath)
        info.AddValue("Tablename", m_strTableName)
        info.AddValue("NguoiTao", m_strNguoiTao)
    End Sub

#End Region
End Class