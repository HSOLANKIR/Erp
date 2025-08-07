Public Class Server_frm
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Server_Name = Txt1.Text
        Server_Database = Txt2.Text
        Server_UserName = Txt3.Text
        Server_Password = Txt4.Text

        Me.Dispose()
    End Sub

    Private Sub Server_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Txt1.Text = Server_Name
        Txt2.Text = Server_Database
        Txt3.Text = Server_UserName
        Txt4.Text = Server_Password
    End Sub

    Private Sub Txt5_TextChanged(sender As Object, e As EventArgs) Handles Txt5.TextChanged

    End Sub

    Private Sub Txt5_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt5.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Txt5.Text = "Opens@S?" & TimeOfDay.ToString("hh-mm") Then
                Panel1.Visible = True
                Panel2.Visible = False
                Txt1.Focus()
            Else
                Application.Exit()
            End If
        End If
    End Sub
End Class