
Public Class frmCadVeiculos


    Private Sub FrmCadVeiculos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim SQL As String = "Select * from users"
        'Try
        'conexaoMySql = New MySqlConnection(StringConexao)
        'ComandoMysql = New MySqlCommand(SQL, conexaoMySql)
        'conexaoMySql.Open()
        'leitorDataReader = ComandoMysql.ExecuteReader()
        'While (leitorDataReader.Read())
        'lblUsuario.Items.Add(leitorDataReader.Item("user_name"))
        'End While
        'Catch ex As Exception
        'MessageBox.Show("Error " + ex.Message, "Error Line 20", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'Finally
        'leitorDataReader.Close()
        'conexaoMySql.Close()
        'End Try
    End Sub

    Private Sub FrmCadVeiculos_ResizeBegin(sender As Object, e As EventArgs) Handles MyBase.ResizeBegin
        'gbDadosUsuario.SetBounds(21, 29, (Me.Size.Width - 110), gbDadosUsuario.Size.Height)
        'lblUsuario.SetBounds(lblUsuario.Location.X, lblUsuario.Location.Y, (gbDadosUsuario.Size.Width - 40), lblUsuario.Size.Height)
    End Sub

    Private Sub FrmCadVeiculos_ResizeEnd(sender As Object, e As EventArgs) Handles MyBase.ResizeEnd
        'MessageBox.Show(Me.Width)
        'gbDadosUsuario.SetBounds(21, 29, (Me.Size.Width - 110), gbDadosUsuario.Size.Height)
        'lblUsuario.SetBounds(lblUsuario.Location.X, lblUsuario.Location.Y, (gbDadosUsuario.Size.Width - 40), lblUsuario.Size.Height)
    End Sub

    Private Sub FrmCadVeiculos_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        'MessageBox.Show(Me.Width)
        Console.WriteLine(Me.Width)
        Dim tamanhoForm As Integer = (Me.Size.Width - 110)
        Console.WriteLine((tamanhoForm))
        gbDadosUsuario.Refresh()

        gbDadosUsuario.SetBounds(21, 29, tamanhoForm, gbDadosUsuario.Size.Height)
        gbDadosUsuario.Refresh()
        Console.WriteLine("Tamanho grid: " + gbDadosUsuario.Size.Width.ToString)
        lblUsuario.Refresh()
        lblUsuario.SetBounds(lblUsuario.Location.X, lblUsuario.Location.Y, (gbDadosUsuario.Size.Width - 40), lblUsuario.Size.Height)
        lblUsuario.Refresh()
    End Sub
End Class