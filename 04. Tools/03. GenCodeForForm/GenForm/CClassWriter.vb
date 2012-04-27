Imports System.IO
Imports GenForm.CommonSpace

Namespace CommonSpace
    Public Interface IWrite2File
        Sub Write2File()
    End Interface
End Namespace
Namespace WriterSpace
    Public Class CClassWriter
        Implements IWrite2File
        Public Components As IWrite2File()

        Private Sub imp_IWrite2File_Write2File() Implements IWrite2File.Write2File
            Dim v_com As IWrite2File
            For Each v_com In Components
                v_com.Write2File()
            Next
        End Sub
    End Class
End Namespace