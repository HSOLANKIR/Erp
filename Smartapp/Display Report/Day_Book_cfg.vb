Public Class Day_Book_cfg
    Private Sub Repoer_Ledger_cfg_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.Login_Type = "Admin Account" Then
            admin_panel.Visible = True
        Else
            admin_panel.Visible = False
        End If
        Load_()

    End Sub
    Public Function Load_()
        Delete_Entry_YN.Text = Boolean_TXT(Day_Book_frm.Delete_Entry)
        Neration_YN.Text = Boolean_TXT(Day_Book_frm.Narration_)
    End Function
    Public Function Save_()
        Day_Book_frm.Delete_Entry = YN_Boolean(Delete_Entry_YN.Text)
        Day_Book_frm.Narration_ = YN_Boolean(Neration_YN.Text)
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Save_()
        Day_Book_frm.Fill_Grid()
        Me.Dispose()
    End Sub

    Private Sub Button1_KeyDown(sender As Object, e As KeyEventArgs) Handles Button1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1.PerformClick()
        End If
        If e.KeyCode = Keys.Back Then
            SendKeys.Send("+{TAB}")
        End If
    End Sub
End Class
