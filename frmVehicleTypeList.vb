Imports System.Configuration
Imports MySql.Data.MySqlClient
Public Class frmVehicleTypeList
    Private Sub FrmVehicleTypeList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim appsSettings = ConfigurationManager.AppSettings
        Dim result = appsSettings("vehiclesTypeList")
        Me.Text = result
        fillDataGrid()

    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim frmVehiclesTypeCad As New frmVehiclesTypes
        'frmVehiclesTypes.MdiParent = MDIParent1
        'frmVehiclesTypes.TopMost = True
        'frmVehiclesTypes.m
        frmVehiclesTypes.ShowDialog()


    End Sub

    Private Sub fillDataGrid()
        Dim SDA As New MySqlDataAdapter
        Dim DB As New DataTable
        Dim bSource As New BindingSource
        Dim SQL As String = ""
        Try
            SQL = "SELECT vehicle_type_id as `#`, vehicle_type_name as `Tipo Veiculo`  FROM  vehicle_types ORDER BY vehicle_type_name "
            LoginForm1.modelo.__ExecutaQueryAdpter(SQL)
            SDA.SelectCommand = LoginForm1.modelo.ComandoMysql
            SDA.Fill(DB)
            bSource.DataSource = DB
            dataGridVehicleType.DataSource = bSource
            SDA.Update(DB)
            'LoginForm1.modelo.__CloseReader()
            'LoginForm1.modelo.__closeConnect()
        Catch ex As Exception
            MessageBox.Show("Erro " + ex.Message, "Erro sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class