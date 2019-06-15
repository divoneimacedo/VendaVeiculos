Imports System.Configuration
Imports MySql.Data.MySqlClient
Public Class model

    Dim StringConexao As String = ConfigurationManager.ConnectionStrings("ConexaoMysql").ConnectionString()
    Dim conexaoMySql As MySqlConnection
    Dim ComandoMysql As MySqlCommand
    Dim leitorDataReader As MySqlDataReader

    Public Function connect()
        Try
            conexaoMySql = New MySqlConnection(StringConexao)
            Return True
        Catch ex As Exception
        Finally

        End Try

    End Function

    Public Function __ExecutaQuery(SQL As String)
        Try
            ComandoMysql = New MySqlCommand(SQL, conexaoMySql)
            conexaoMySql.Open()
            leitorDataReader = ComandoMysql.ExecuteReader()
            Return leitorDataReader
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function __CloseReader()
        Try
            leitorDataReader.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function


    Public Function __closeConnect()
        Try
            conexaoMySql.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function




End Class
