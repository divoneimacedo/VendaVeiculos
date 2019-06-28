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
        'frmVehiclesTypeCad.MdiParent = MDIParent1
        frmVehiclesTypeCad.Owner = Me
        frmVehiclesTypeCad.TopMost = True
        frmVehiclesTypeCad.Show()
        'frmVehiclesTypes.m
        'frmVehiclesTypes.ShowDialog()


    End Sub

    Public Function fillDataGrid()

        Dim SDA As New MySqlDataAdapter
        Dim DB As New DataTable
        Dim bSource As New BindingSource
        Dim SQL As String = ""
        idType = 0
        dataGridVehicleType.ReadOnly = True
        dataGridVehicleType.DataSource = Nothing
        Try
            SQL = "SELECT vehicle_type_id as `ID`, vehicle_type_name as `Tipo`  FROM  vehicle_types ORDER BY vehicle_type_name "
            LoginForm1.modelo.__ExecutaQueryAdpter(SQL)
            SDA.SelectCommand = LoginForm1.modelo.ComandoMysql
            SDA.Fill(DB)
            bSource.DataSource = DB

            dataGridVehicleType.DataSource = bSource
            Console.WriteLine(bSource)
            dataGridVehicleType.Refresh()

            'SDA.Update(DB)
            LoginForm1.modelo.__CloseReader()
            LoginForm1.modelo.__closeConnect()
            Console.WriteLine(" id type full grid " + idType.ToString)

        Catch ex As Exception
            MessageBox.Show("Erro " + ex.Message, "Erro sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function


    Private Sub DataGridVehicleType_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridVehicleType.CellClick
        If e.RowIndex < 0 Then
            Console.WriteLine(e.RowIndex)
            Exit Sub
        End If
        'fillDataGrid()

        Dim intIndex As Integer = e.RowIndex
        Try
            dataGridVehicleType.Rows(intIndex).Selected = True
            idType = dataGridVehicleType.Rows(intIndex).Cells(0).Value
            Console.WriteLine(idType)
        Catch ex As Exception

        End Try



    End Sub

    Private Sub BtnRefres_Click(sender As Object, e As EventArgs) Handles btnRefres.Click
        dataGridVehicleType.DataSource = Nothing
    End Sub
End Class