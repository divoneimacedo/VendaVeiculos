Imports System.Configuration
Imports MySql.Data.MySqlClient
Public Class frmVehicleTypeList
    Public Shared idType As Integer
    Private Sub FrmVehicleTypeList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim appsSettings = ConfigurationManager.AppSettings
        Dim result = appsSettings("vehiclesTypeList")
        Me.Text = result
        idType = 0
        fillDataGrid()

    End Sub

    Private Sub FrmVehicleTypeList_GotFocus(sender As Object, e As EventArgs) Handles MyBase.GotFocus
        fillDataGrid()
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim frmVehiclesTypeCad As New frmVehiclesTypes
        'frmVehiclesTypes.MdiParent = MDIParent1
        'frmVehiclesTypes.TopMost = True
        'frmVehiclesTypes.m
        frmVehiclesTypes.ShowDialog()


    End Sub

    Public Sub fillDataGrid()

        Dim SDA As New MySqlDataAdapter
        Dim DB As New DataTable
        Dim bSource As New BindingSource
        Dim SQL As String = ""
        idType = 0
        Try
            SQL = "SELECT vehicle_type_id as `#`, vehicle_type_name as `Tipo Veiculo`  FROM  vehicle_types ORDER BY vehicle_type_name "
            LoginForm1.modelo.__ExecutaQueryAdpter(SQL)
            SDA.SelectCommand = LoginForm1.modelo.ComandoMysql
            SDA.Fill(DB)
            bSource.DataSource = DB

            dataGridVehicleType.DataSource = bSource
            Console.WriteLine(bSource)
            dataGridVehicleType.Refresh()
            dataGridVehicleType.Update()

            SDA.Update(DB)
            'LoginForm1.modelo.__CloseReader()
            'LoginForm1.modelo.__closeConnect()
            Console.WriteLine(" id type full grid " + idType.ToString)
        Catch ex As Exception
            MessageBox.Show("Erro " + ex.Message, "Erro sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub DataGridVehicleType_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridVehicleType.CellClick
        If e.RowIndex < 0 Then
            Console.WriteLine(e.RowIndex)
            Exit Sub
        End If
        fillDataGrid()
        Dim intIndex As Integer = e.RowIndex

        dataGridVehicleType.Rows(intIndex).Selected = True
        idType = dataGridVehicleType.Rows(intIndex).Cells(0).Value
        Console.WriteLine(idType)

    End Sub
End Class