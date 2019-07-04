Imports System.Configuration
Imports MySql.Data.MySqlClient
Public Class frmVehiclesTypes
    Private modelo As model
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim appSettings = ConfigurationManager.AppSettings
        Dim resultString As String = appSettings("vehiclesType")
        Me.Text = resultString
        Me.MaximizeBox = False
        modelo = New model
        modelo.connect()
        'Console.WriteLine(resultString)
        If frmVehicleTypeList.idType = 0 Then
            btnSaveVehicleType.Text = "&Salvar"
        Else
            btnSaveVehicleType.Text = "E&ditar"
            dataLoadType()
        End If

    End Sub

    Private Sub BtnVehicleTypeCancel_Click(sender As Object, e As EventArgs) Handles btnVehicleTypeCancel.Click
        Me.Close()
    End Sub

    Private Sub frmVehiclesTypes_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Dim RowCount As Integer = CType(Me.Owner, frmVehicleTypeList).fillDataGrid()
        modelo.__closeConnect()
        modelo.__CloseReader()
    End Sub

    Private Sub BtnSaveVehicleType_Click(sender As Object, e As EventArgs) Handles btnSaveVehicleType.Click
        If frmVehicleTypeList.idType = 0 Then
            saveData()
        Else
            editData()
        End If
    End Sub
    Private Sub dataLoadType()
        Dim SQL As String
        Dim mysqlDataReader As MySqlDataReader
        If frmVehicleTypeList.idType > 0 Then
            Try

                SQL = "SELECT vehicle_type_name FROM vehicle_types Where vehicle_type_id = " + frmVehicleTypeList.idType.ToString + " Limit 1"
                mysqlDataReader = modelo.__ExecutaQuery(SQL)
                Console.WriteLine(mysqlDataReader.HasRows)
                If (mysqlDataReader.HasRows) Then
                    While mysqlDataReader.Read()
                        txtVehicleTypeName.Text = mysqlDataReader.Item("vehicle_type_name")
                    End While
                    txtVehicleTypeName.Select(txtVehicleTypeName.Text.Length, 0)
                End If
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        End If
    End Sub
    Private Sub saveData()
        Dim SQL As String
        Dim mysqlDataReader As MySqlDataReader
        If txtVehicleTypeName.Text <> "" Then
            SQL = "INSERT INTO vehicle_types (vehicle_type_name) VALUES ('" + txtVehicleTypeName.Text + "')"
            Try
                mysqlDataReader = modelo.__ExecutaQuery(SQL)
                If mysqlDataReader.RecordsAffected = 1 Then
                    Dim RowCount As Integer = CType(Me.Owner, frmVehicleTypeList).fillDataGrid()
                    'MessageBox.Show("Dados salvos com sucesso", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtVehicleTypeName.Text = ""
                    txtVehicleTypeName.Select()
                    Me.Close()
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
    Private Sub editData()
        Dim SQL As String
        Dim mysqlDataReader As MySqlDataReader
        If txtVehicleTypeName.Text <> "" Then
            SQL = "UPDATE vehicle_types SET vehicle_type_name = '" + txtVehicleTypeName.Text + "' WHERE vehicle_type_id = " + frmVehicleTypeList.idType.ToString
            Try
                mysqlDataReader = modelo.__ExecutaQuery(SQL)
                If mysqlDataReader.RecordsAffected = 1 Then
                    Dim RowCount As Integer = CType(Me.Owner, frmVehicleTypeList).fillDataGrid()
                    'MessageBox.Show("Dados salvos com sucesso", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtVehicleTypeName.Text = ""
                    txtVehicleTypeName.Select()
                    Me.Close()
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
    Private Sub txtVehicleTypeName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtVehicleTypeName.KeyPress
        If (Asc(e.KeyChar) = 13) Then
            If frmVehicleTypeList.idType = 0 Then
                saveData()
            Else
                editData()
            End If
        End If
    End Sub
End Class