<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVehiclesTypes
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtVehicleTypeName = New System.Windows.Forms.TextBox()
        Me.btnSaveVehicleType = New System.Windows.Forms.Button()
        Me.btnVehicleTypeCancel = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtVehicleTypeName)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(435, 94)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo de veículo"
        '
        'txtVehicleTypeName
        '
        Me.txtVehicleTypeName.Location = New System.Drawing.Point(6, 19)
        Me.txtVehicleTypeName.Name = "txtVehicleTypeName"
        Me.txtVehicleTypeName.Size = New System.Drawing.Size(397, 20)
        Me.txtVehicleTypeName.TabIndex = 0
        '
        'btnSaveVehicleType
        '
        Me.btnSaveVehicleType.Location = New System.Drawing.Point(372, 118)
        Me.btnSaveVehicleType.Name = "btnSaveVehicleType"
        Me.btnSaveVehicleType.Size = New System.Drawing.Size(75, 23)
        Me.btnSaveVehicleType.TabIndex = 1
        Me.btnSaveVehicleType.Text = "Salvar"
        Me.btnSaveVehicleType.UseVisualStyleBackColor = True
        '
        'btnVehicleTypeCancel
        '
        Me.btnVehicleTypeCancel.Location = New System.Drawing.Point(291, 118)
        Me.btnVehicleTypeCancel.MaximumSize = New System.Drawing.Size(73, 23)
        Me.btnVehicleTypeCancel.Name = "btnVehicleTypeCancel"
        Me.btnVehicleTypeCancel.Size = New System.Drawing.Size(73, 23)
        Me.btnVehicleTypeCancel.TabIndex = 2
        Me.btnVehicleTypeCancel.Text = "Cancelar"
        Me.btnVehicleTypeCancel.UseVisualStyleBackColor = True
        '
        'frmVehiclesTypes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(465, 153)
        Me.Controls.Add(Me.btnVehicleTypeCancel)
        Me.Controls.Add(Me.btnSaveVehicleType)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximumSize = New System.Drawing.Size(481, 192)
        Me.Name = "frmVehiclesTypes"
        Me.Text = "Form2"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtVehicleTypeName As TextBox
    Friend WithEvents btnSaveVehicleType As Button
    Friend WithEvents btnVehicleTypeCancel As Button
End Class
