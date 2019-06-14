Public Class model

    Dim pConexao As ADODB.Connection
    Dim strTemp As String


    Public Function connect()

        pConexao = New ADODB.Connection
        pConexao.Open("DRIVER={MySQL ODBC 3.51 Driver};user=root;password=;server=localhos;option=20499")

        If pConexao.State = 1 Then
            MessageBox.Show("Conexao com sucesso")
        Else
            MessageBox.Show("sem conexao")
        End If



    End Function


End Class
