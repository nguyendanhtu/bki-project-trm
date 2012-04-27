Imports System.IO
Imports GenForm.WriterSpace
Imports GenForm.CommonSpace

Namespace BuilderSpace

    Public Class CClassBuilderFactory
        Public Shared Function CreateCCsharpClassBuiler(ByVal i_dt As DataTable, _
                                                        ByVal i_hst As Hashtable, _
                                                        ByVal i_str_FormName As String, _
                                                        ByVal i_fFileStream As StreamWriter, _
                                                        ByVal i_fFileStreamCreateCollection As StreamWriter, _
                                                        ByVal i_str_Author As String) As CClassBuilder
            Return New CCSharpBuilder(i_dt, i_hst, i_str_FormName, i_fFileStream, i_fFileStreamCreateCollection, i_str_Author)
        End Function
    End Class

    Public Class CClassBuilder
        Public Overridable Function BuildClass() As IWrite2File
        End Function
    End Class

    Public Class CCSharpBuilder
        Inherits CClassBuilder
        Dim m_dt As DataTable
        Dim m_str_Author As String
        Dim m_fFileStream As StreamWriter
        Dim m_fFileStreamCreateCollection As StreamWriter
        Dim m_ClassWriter As CClassWriter
        Dim m_hst As Hashtable
        Dim m_str_FormName As String

        Public Sub New(ByVal i_dt As DataTable, _
                        ByVal i_hst As Hashtable, _
                        ByVal i_str_FormName As String, _
                        ByVal i_fFileStream As StreamWriter, _
                        ByVal i_fFileStreamCreateCollection As StreamWriter, _
                        ByVal i_str_Author As String)
            m_dt = i_dt
            m_hst = i_hst
            m_str_FormName = i_str_FormName
            m_str_Author = i_str_Author
            m_fFileStream = i_fFileStream
            m_fFileStreamCreateCollection = i_fFileStreamCreateCollection
            m_ClassWriter = New CClassWriter
        End Sub

        Public Overrides Function BuildClass() As IWrite2File
            Dim v_CurDirName As String
            v_CurDirName = AppDomain.CurrentDomain.SetupInformation.ApplicationBase
            ReDim m_ClassWriter.Components(5)
            m_ClassWriter.Components(0) = New CCommentWriter(m_fFileStream, v_CurDirName & CConstant.Cpath.COMMENT, m_str_Author, m_dt.TableName)
            m_ClassWriter.Components(1) = New CImportWriter(m_fFileStream, v_CurDirName & CConstant.Cpath.IMPORT)
            m_ClassWriter.Components(2) = New CCreateFormWriter(m_fFileStream, v_CurDirName & CConstant.Cpath.CREATE_FORM, m_str_FormName, m_dt, m_hst)
            m_ClassWriter.Components(3) = New CUserWriter(m_fFileStream, m_dt, m_hst, m_str_FormName)
            m_ClassWriter.Components(4) = New CEndFormWriter(m_fFileStream, v_CurDirName & CConstant.Cpath.LSEND)
            m_ClassWriter.Components(5) = New CCollectionOfForm(m_fFileStreamCreateCollection, m_str_FormName, v_CurDirName & CConstant.Cpath.COLLECTION_OF_FORM)

            Return m_ClassWriter
        End Function
    End Class
End Namespace