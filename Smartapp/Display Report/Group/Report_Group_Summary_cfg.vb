Public Class Report_Group_Summary_cfg
    Private Sub Repoer_Ledger_cfg_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_()
    End Sub
    Public Function Load_()
        OB_YN.Text = Boolean_TXT(Report_Group_Summary_frm.YN_Opning_Balance)
        'CL_YN.Text = Boolean_TXT(Report_Group_Summary_frm.YN_Closing_Balance)
        Percentage_YN.Text = Boolean_TXT(Report_Group_Summary_frm.YN_Percentage)
    End Function
    Public Function Save_()
        Report_Group_Summary_frm.YN_Opning_Balance = YN_Boolean(OB_YN.Text)
        'Report_Group_Summary_frm.YN_Closing_Balance = YN_Boolean(CL_YN.Text)
        Report_Group_Summary_frm.YN_Percentage = YN_Boolean(Percentage_YN.Text)
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Save_()
        Report_Group_Summary_frm.Fill_Grid()
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
