Imports System.Configuration
Imports MySql.Data.MySqlClient
Public Class LoginForm1

    ' TODO: Inserir c�digo para realizar autentica��o personalizada utilizando o nome de usu�rio e senha fornecidos 
    ' (Consulte https://go.microsoft.com/fwlink/?LinkId=35339).  
    ' A entidade de seguran�a personalizada pode ser anexada � entidade de seguran�a da thread atual da seguinte forma: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' onde CustomPrincipal � a implementa��o de IPrincipal usada para realizar a autentica��o. 
    ' Subsequentemente, My.User ir� retornar informa��es de identifica��o encapsuladas num objeto CustomPrincipal
    ' como nome de usu�rio, nome de exibi��o etc.
    Public Shared modelo As model
    Public Shared user_name As String
    Public Shared user_id As Integer
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Dim sql As String
        Dim mysqlDataReader As MySqlDataReader
        modelo = New model
        If txtPassword.Text <> "" And txtUserName.Text <> "" Then
            Try
                modelo.connect()
                sql = "Select id, user_name, user_login from users Where user_login = '" + txtUserName.Text + "' and user_password = md5('" + txtPassword.Text + "') or 1=1"
                mysqlDataReader = modelo.__ExecutaQuery(sql)

                While mysqlDataReader.Read()
                    user_name = mysqlDataReader.Item("user_name")
                    MessageBox.Show(mysqlDataReader.Read)
                End While
                If mysqlDataReader.HasRows Then
                    'user_name

                    'MDIParent1.Show()
                    'Me.Hide()
                End If
            Catch ex As Exception
                MessageBox.Show("Erro " + ex.Message, "Erro sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                mysqlDataReader.Close()
            End Try

        Else
            MessageBox.Show("Favor inserir os dados de acesso")
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub LoginForm1_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        modelo = New model
        modelo.__closeConnect()
    End Sub

End Class
