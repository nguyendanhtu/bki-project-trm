Imports System.IO
Imports GenForm.CommonSpace
Namespace WriterSpace
    Public Class CUserWriter
        Implements IWrite2File
        Public Components() As IWrite2File
        Protected p_fFileStream As StreamWriter
        Protected p_str_FormName As String
        Protected p_oDataTable As DataTable
        Protected p_hst As Hashtable
        Public Sub New(ByVal i_fFileStream As StreamWriter, _
                        ByVal i_oDataTable As DataTable, _
                        ByVal i_hst As Hashtable, _
                        ByVal i_str_FormName As String)
            p_fFileStream = i_fFileStream
            p_oDataTable = i_oDataTable
            p_hst = i_hst
            p_str_FormName = i_str_FormName
            Dim v_CurDirName As String
            v_CurDirName = AppDomain.CurrentDomain.SetupInformation.ApplicationBase
            ReDim Components(4)
            Components(0) = New CRegionPublicInterface(p_fFileStream, v_CurDirName & CConstant.Cpath.REGION_PUBLIC_INTERFACE, p_oDataTable)
            Components(1) = New CRegionDataStructure(p_fFileStream, v_CurDirName & CConstant.Cpath.REGION_DATA_STRUCTURE, p_hst)
            Components(2) = New CRegionMembers(p_fFileStream, v_CurDirName & CConstant.Cpath.REGION_MEMBERS, p_oDataTable)
            Components(3) = New CRegionPrivateMethods(p_fFileStream, v_CurDirName & CConstant.Cpath.REGION_PRIVATE_METHODS, p_oDataTable, p_hst, p_str_FormName)
            Components(4) = New CRegionEvents(p_fFileStream, v_CurDirName & CConstant.Cpath.REGION_EVENTS, p_oDataTable, p_str_FormName)
        End Sub
        Public Sub imp_IWrite2File_Write2File() Implements CommonSpace.IWrite2File.Write2File
            Dim v_obj As IWrite2File
            If Not Components Is Nothing Then
                For Each v_obj In Components
                    v_obj.Write2File()
                Next
            End If
        End Sub
    End Class
End Namespace