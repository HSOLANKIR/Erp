Public Class sp_vouchers_type_class_ctrl
    Private Sub sp_vouchers_type_class_ctrl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Add_Account_Group("", "")
        'Add_Ledger("", "", "", "")
    End Sub
    Public Function Add_Account_Group(nm As String, st As String)
        Try
            Dim ob As New vouchers_type_class_group_list_ctrl
            ob.Dock = DockStyle.Top
            ob.Bg_Panel = Panel8
            ob.obj = Me
            ob.Txt1.Text = nm
            ob.statsu_txt.Text = st
            Panel8.Controls.Add(ob)
            ob.BringToFront()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function
    Public Function Add_Ledger(nm As String, cal_ As String, dft_vlu As String, rounding As String, rounding_limit As String)
        Try
            Dim ob As New vouchers_type_class_ledger_list_ctrl
            ob.Dock = DockStyle.Top
            ob.Bg_Panel = Panel10
            ob.obj = Me
            ob.Ledger_TXT.Text = nm
            ob.calulation_TXT.Text = cal_
            ob.Dft_TXT.Text = dft_vlu
            ob.Rounding_TXT.Text = rounding
            ob.Rounding_Limit.Text = rounding_limit
            Panel10.Controls.Add(ob)
            ob.BringToFront()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Private Sub Txt1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Txt1_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub Panel8_Paint(sender As Object, e As PaintEventArgs) Handles Panel8.Paint

    End Sub
End Class
