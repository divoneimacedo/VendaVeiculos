Imports System.Configuration
Imports MySql.Data.MySqlClient
Public Class frmVehiclesTypes
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.Text = ConfigurationManager.AppSettings.Keys("vehiclesType")
        Dim appSettings = ConfigurationManager.AppSettings
        Dim resultString As String = appSettings("vehiclesType")
        Me.Text = resultString
        Me.MaximizeBox = False
        'Console.WriteLine(resultString)

    End Sub

    Private Sub BtnVehicleTypeCancel_Click(sender As Object, e As EventArgs) Handles btnVehicleTypeCancel.Click
        'frmVehicleTypeList.fillDataGrid()
        Me.Close()
        'Dim RowCount As Integer = CType(Me.Owner, frmVehicleTypeList).fillDataGrid()
        'MessageBox.Show("Row count for Form1.DataGridView1 is " & RowCount.ToString)
    End Sub

    Private Sub frmVehiclesTypes_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Dim RowCount As Integer = CType(Me.Owner, frmVehicleTypeList).fillDataGrid()
    End Sub

    Private Sub BtnSaveVehicleType_Click(sender As Object, e As EventArgs) Handles btnSaveVehicleType.Click
        Dim SQL As String = ""
        Dim mysqlDataReader As MySqlDataReader
        If txtVehicleTypeName.Text <> "" Then
            SQL = "INSERT INTO vehicle_types (vehicle_type_name) VALUES ('" + txtVehicleTypeName.Text + "')"
            Try
                mysqlDataReader = LoginForm1.modelo.__ExecutaQuery(SQL)
                'Console.WriteLine(mysqlDataReader.RecordsAffected)
                If mysqlDataReader.RecordsAffected = 1 Then
                    'fillDataGrid()
                    Dim RowCount As Integer = CType(Me.Owner, frmVehicleTypeList).fillDataGrid()
                    MessageBox.Show("Dados salvos com sucesso", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtVehicleTypeName.Text = ""
                    txtVehicleTypeName.Select()
                Else
                    MessageBox.Show("Houve um problema ao salvar os dados.", "Erro ao salvar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Catch ex As Exception
                MessageBox.Show("Erro " + ex.Message, "Erro sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("Por favor preencha o tipo de veículo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtVehicleTypeName.Select()
        End If





    End Sub
End Class