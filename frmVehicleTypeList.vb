Imports System.Configuration
Imports MySql.Data.MySqlClient
Public Class frmVehicleTypeList
    Public Shared idType As Integer
    Private modelo As model
    Private Sub FrmVehicleTypeList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim appsSettings = ConfigurationManager.AppSettings
        Dim result = appsSettings("vehiclesTypeList")
        Me.Text = result
        idType = 0
        modelo = New model
        modelo.connect()

        fillDataGrid()
    End Sub

    Private Sub FrmVehicleTypeList_GotFocus(sender As Object, e As EventArgs) Handles MyBase.GotFocus
        fillDataGrid()
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim frmVehiclesTypeCad As New frmVehiclesTypes
        frmVehiclesTypeCad.Owner = Me
        frmVehiclesTypeCad.TopMost = True
        frmVehiclesTypeCad.ShowDialog()
    End Sub

    Public Function fillDataGrid()
        Dim SDA As New MySqlDataAdapter
        Dim DB As New DataTable
        Dim bSource As New BindingSource
        Dim SQL As String = ""
        Dim total As Integer
        Dim widthColumns As Double
        idType = 0
        dataGridVehicleType.ReadOnly = True
        dataGridVehicleType.DataSource = Nothing
        btnEdit.Enabled = False
        btnDelete.Enabled = False
        Try
            SQL = "SELECT vehicle_type_id as `ID`, vehicle_type_name as `Tipo`  FROM  vehicle_types ORDER BY vehicle_type_name "
            modelo.__ExecutaQueryAdpter(SQL)
            SDA.SelectCommand = modelo.ComandoMysql
            SDA.Fill(DB)
            bSource.DataSource = DB
            dataGridVehicleType.DataSource = bSource
            'Console.WriteLine(bSource)
            dataGridVehicleType.Refresh()
            'Console.WriteLine(" id type full grid " + idType.ToString)
            total = (dataGridVehicleType.Columns.Count)
            widthColumns = (dataGridVehicleType.Width - 45) / total
            Console.WriteLine(widthColumns)
            total = total - 1
            For index = 0 To total Step 1
                dataGridVehicleType.Columns.Item(index).Width = widthColumns
                Console.WriteLine(index)
            Next

        Catch ex As Exception
            MessageBox.Show("Erro " + ex.Message, "Erro sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function


    Private Sub DataGridVehicleType_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridVehicleType.CellClick
        If e.RowIndex < 0 Then
            Console.WriteLine(e.RowIndex)
            Exit Sub
        End If

        Dim intIndex As Integer = e.RowIndex
        Try
            dataGridVehicleType.Rows(intIndex).Selected = True
            idType = dataGridVehicleType.Rows(intIndex).Cells(0).Value
            btnDelete.Enabled = True
            btnEdit.Enabled = True
            'Console.WriteLine(idType)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim result = MessageBox.Show("Deseja excluir o registro?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        Dim SQL As String
        Dim mysqlDataReader As MySqlDataReader
        If idType > 0 Then
            If result = DialogResult.Yes Then
                Try
                    SQL = "Delete From vehicle_types Where vehicle_type_id = " + idType.ToString
                    Console.WriteLine(SQL)
                    mysqlDataReader = modelo.__ExecutaQuery(SQL)
                    Console.WriteLine(mysqlDataReader.RecordsAffected)
                    If mysqlDataReader.RecordsAffected = 1 Then
                        MessageBox.Show("Dados excluídos com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        idType = 0
                        btnDelete.Enabled = False
                        fillDataGrid()
                    Else
                        MessageBox.Show("Houve um problema ao excluir os dados.", "Erro ao salvar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                Catch ex As Exception
                    MessageBox.Show("Erro ao tentar exluir dados " + ex.Message + ".", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            End If
        Else
            MessageBox.Show("Você precisa selecionar um registro para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Dim frmVehiclesTypeCad As New frmVehiclesTypes
        If idType > 0 Then
            frmVehiclesTypeCad.Owner = Me
            frmVehiclesTypeCad.TopMost = True
            frmVehiclesTypeCad.ShowDialog()
        Else
            btnEdit.Enabled = False
            btnDelete.Enabled = False
        End If
    End Sub

    Private Sub dataGridVehicleType_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridVehicleType.CellDoubleClick
        Dim frmVehiclesTypeCad As New frmVehiclesTypes
        If e.RowIndex < 0 Then
            Console.WriteLine(e.RowIndex)
            Exit Sub
        End If
        Dim intIndex As Integer = e.RowIndex
        Try
            dataGridVehicleType.Rows(intIndex).Selected = True
            idType = dataGridVehicleType.Rows(intIndex).Cells(0).Value
            btnDelete.Enabled = True
            btnEdit.Enabled = True
            frmVehiclesTypeCad.Owner = Me
            frmVehiclesTypeCad.TopMost = True
            frmVehiclesTypeCad.ShowDialog()
            'Console.WriteLine(idType)
        Catch ex As Exception

        End Try

    End Sub
End Class