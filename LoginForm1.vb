Imports MySql.Data.MySqlClient
Public Class LoginForm1

    ' TODO: Inserir código para realizar autenticação personalizada utilizando o nome de usuário e senha fornecidos 
    ' (Consulte https://go.microsoft.com/fwlink/?LinkId=35339).  
    ' A entidade de segurança personalizada pode ser anexada à entidade de segurança da thread atual da seguinte forma: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' onde CustomPrincipal é a implementação de IPrincipal usada para realizar a autenticação. 
    ' Subsequentemente, My.User irá retornar informações de identificação encapsuladas num objeto CustomPrincipal
    ' como nome de usuário, nome de exibição etc.
    Private modelo As model
    Public Shared user_name As String
    Public Shared user_id As Integer
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Dim sql As String
        Dim mysqlDataReader As MySqlDataReader
        Dim totalRegistros As Integer = 0
        modelo = New model
        If txtPassword.Text <> "" And txtUserName.Text <> "" Then
            Try
                modelo.connect()
                sql = "Select id, user_name, user_login from users Where user_login = '" + txtUserName.Text + "' and user_password = md5('" + txtPassword.Text + "')"
                mysqlDataReader = modelo.__ExecutaQuery(sql)
                Console.WriteLine(mysqlDataReader.HasRows)
                Console.WriteLine(sql)
                If mysqlDataReader.HasRows Then
                    While mysqlDataReader.Read()
                        If (totalRegistros > 0) Then
                            totalRegistros += 1
                            Exit While
                        End If
                        user_name = mysqlDataReader.Item("user_name")
                        user_id = mysqlDataReader.Item("id")
                        totalRegistros += 1
                    End While
                    If totalRegistros = 1 Then
                        MDIParent1.Show()
                        modelo.__closeConnect()
                        modelo.__CloseReader()
                        Me.Hide()
                    Else
                        MessageBox.Show("Dados errados por favor tente novamente.", "Erro sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    MessageBox.Show("Usuário ou senha inválido.", "Erro sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MessageBox.Show("Erro " + ex.Message, "Erro sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub LoginForm1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
