<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCadVeiculos
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
        Me.gbDadosUsuario = New System.Windows.Forms.GroupBox()
        Me.lblUsuario = New System.Windows.Forms.ListBox()
        Me.gbDadosUsuario.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbDadosUsuario
        '
        Me.gbDadosUsuario.Controls.Add(Me.lblUsuario)
        Me.gbDadosUsuario.Location = New System.Drawing.Point(21, 29)
        Me.gbDadosUsuario.Name = "gbDadosUsuario"
        Me.gbDadosUsuario.Size = New System.Drawing.Size(781, 160)
        Me.gbDadosUsuario.TabIndex = 0
        Me.gbDadosUsuario.TabStop = False
        Me.gbDadosUsuario.Text = "Escdolha o usuário"
        '
        'lblUsuario
        '
        Me.lblUsuario.FormattingEnabled = True
        Me.lblUsuario.Location = New System.Drawing.Point(6, 33)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(740, 108)
        Me.lblUsuario.TabIndex = 0
        '
        'frmCadVeiculos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(875, 616)
        Me.Controls.Add(Me.gbDadosUsuario)
        Me.MinimumSize = New System.Drawing.Size(891, 655)
        Me.Name = "frmCadVeiculos"
        Me.Text = "Form2"
        Me.gbDadosUsuario.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gbDadosUsuario As GroupBox
    Friend WithEvents lblUsuario As ListBox
End Class
