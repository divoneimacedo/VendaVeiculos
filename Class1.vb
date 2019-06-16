Imports System.Configuration
Imports MySql.Data.MySqlClient
Public Class model

    Dim StringConexao As String = ConfigurationManager.ConnectionStrings("ConexaoMysql").ConnectionString()
    Public conexaoMySql As MySqlConnection
    Public ComandoMysql As MySqlCommand
    Dim leitorDataReader As MySqlDataReader
    Dim dataAdapter As MySqlDataAdapter
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
            Dim temp = conexaoMySql.State.ToString
            Console.WriteLine(temp)
            If temp = "Closed" Then
                conexaoMySql.Open()
            ElseIf temp = "Open" Then
                conexaoMySql.Close()
                conexaoMySql.Open()
            End If

            leitorDataReader = ComandoMysql.ExecuteReader()
            Return leitorDataReader
        Catch ex As Exception
            'Return ex.Message
            MessageBox.Show("Erro model class" + ex.Message, "Erro sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            'conexaoMySql.Close()
        End Try
    End Function


    Public Function __ExecutaQueryAdpter(SQL)
        Try
            Dim temp = conexaoMySql.State.ToString
            If temp = "Closed" Then
                conexaoMySql.Open()
            ElseIf temp = "Open" Then
                conexaoMySql.Close()
                conexaoMySql.Open()
            End If
            ComandoMysql = New MySqlCommand(SQL, conexaoMySql)
        Catch ex As Exception
            'Return ex.Message
            MessageBox.Show("Erro model class" + ex.Message, "Erro sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
