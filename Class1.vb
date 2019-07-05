Imports System.Configuration
Imports MySql.Data.MySqlClient
Public Class model

    Dim StringConexao As String = ConfigurationManager.ConnectionStrings("ConexaoMysql").ConnectionString()
    Public conexaoMySql As MySqlConnection
    Public ComandoMysql As MySqlCommand
    Dim leitorDataReader As MySqlDataReader
    Dim stringValues As String
    Dim indexString As String
    Private arrayValue() As String
    Private arrayIndex() As String
    Dim dataAdapter As MySqlDataAdapter
    Public Function connect()
        Dim SQL As String
        Try
            conexaoMySql = New MySqlConnection(StringConexao)
            Dim temp = conexaoMySql.State.ToString
            If temp = "Closed" Then
                conexaoMySql.Open()
            ElseIf temp = "Open" Then
                conexaoMySql.Close()
                conexaoMySql.Open()
            End If
            SQL = "SELECT valor,nome FROM conf WHERE modulo = 0 ORDER BY id"
            'Console.WriteLine(SQL)
            ComandoMysql = New MySqlCommand(SQL, conexaoMySql)
            leitorDataReader = ComandoMysql.ExecuteReader()
            If (leitorDataReader.HasRows) Then
                While leitorDataReader.Read()
                    stringValues += leitorDataReader.Item("valor") + "|string|"
                    indexString += leitorDataReader.Item("nome") + "|string|"
                End While
            End If
            stringValues = stringValues.Substring(0, (Len(stringValues) - 8))
            indexString = indexString.Substring(0, (Len(indexString) - 8))
            'Console.WriteLine(indexString)
            'Console.WriteLine(indexString)
            arrayValue = Split(stringValues, "|string|")
            arrayIndex = Split(indexString, "|string|")
            'Console.WriteLine(arrayValue)
            leitorDataReader.Close()
            conexaoMySql.Close()
            Return True
        Catch ex As Exception
            MessageBox.Show("Erro ao conectar ao servidor de dados: " + ex.Message, "Erro conexão", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
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
            MessageBox.Show("Erro model class " + ex.Message, "Erro sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            'conexaoMySql.Close()
        End Try
    End Function

    Public Function getConfValue(index As String) As String
        Dim real_index As Integer
        real_index = Array.IndexOf(arrayIndex, index)
        'Console.WriteLine(real_index)
        Return arrayValue(real_index)
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
