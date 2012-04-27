Namespace CommonSpace
    Public Class CProvider

        Shared Function getConnection(ByVal i_strServer As String, _
                                    ByVal i_strDatabase As String, _
                                    ByVal i_strUserName As String, _
                                    ByVal i_strPassword As String) As SqlClient.SqlConnection
            Dim cn As New SqlClient.SqlConnection()
            cn.ConnectionString = "data source=" & i_strServer
            cn.ConnectionString &= ";initial catalog=" & i_strDatabase
            cn.ConnectionString &= ";user id=" & i_strUserName
            cn.ConnectionString &= ";password=" & i_strPassword
            Return cn
        End Function

        Shared Function getAdapter() As SqlClient.SqlDataAdapter
            Dim da As New SqlClient.SqlDataAdapter()
            Return da
        End Function

    End Class
End Namespace