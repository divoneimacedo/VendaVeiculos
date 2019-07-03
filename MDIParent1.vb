Imports System.Windows.Forms

Public Class MDIParent1
    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs) Handles OpenToolStripMenuItem.Click, OpenToolStripButton.Click
        'Dim OpenFileDialog As New OpenFileDialog
        'OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        'OpenFileDialog.Filter = "Arquivos de texto (*.txt)|*.txt|Todos os arquivos (*.*)|*.*"
        'If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
        'Dim FileName As String = OpenFileDialog.FileName
        ' TODO: Adicione aqui código para abrir o arquivo.
        'End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Arquivos de texto (*.txt)|*.txt|Todos os arquivos (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: Adicionar código aqui para salvar em arquivo o conteúdo atual do formulário.
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)

        Me.Close()

    End Sub
    Private Sub MDIParent1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'MessageBox.Show("teste")
        'Me.MaximizeBox = False
        'Me.WindowState = FormWindowState.Maximized
        lblStBarUserName.Text = LoginForm1.user_name


    End Sub

    Private Sub MDIParent1_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.FormClosing
        Dim result = MessageBox.Show("Deseja sair do programa?", "Sair do programa", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then
            e.Cancel = True
        Else
            LoginForm1.Close()
        End If
    End Sub

    Private Sub NovoVeículoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NovoVeículoToolStripMenuItem.Click
        Dim formCadVeiculos As New frmCadVeiculos
        formCadVeiculos.MdiParent = Me
        formCadVeiculos.Show()

    End Sub

    Private Sub MDIParent1_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        'Console.WriteLine("Tamanho mdi: " + Me.Width.ToString)
        lblStBarStatus.Width = Me.Width - lblStBarUserName.Width - lblStBarLogado.Width - 100
        'Console.WriteLine("lblstbarstatus : " + (Me.Width - lblStBarUserName.Width - lblStBarLogado.Width - 200).ToString)
        'Console.WriteLine("real tamanho do lbl: " + lblStBarStatus.Width.ToString)
    End Sub

    Private Sub OptionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OptionsToolStripMenuItem.Click

    End Sub

    Private Sub TipoVeículosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TipoVeículosToolStripMenuItem.Click
        Dim formVehicleTpeList As New frmVehicleTypeList
        formVehicleTpeList.MdiParent = Me
        formVehicleTpeList.Show()
        'Console.WriteLine("excutou o click")
    End Sub
End Class
