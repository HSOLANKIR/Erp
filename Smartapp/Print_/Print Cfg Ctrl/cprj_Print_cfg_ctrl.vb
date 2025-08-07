Imports Tools

Public Class cprj_Print_cfg_ctrl
    Private Sub cprj_Print_cfg_ctrl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Fill_Data()
        List_set()


        Load_()
    End Sub
    Private Function Fill_Data()

    End Function
    Dim acc_list1 As List_frm
    Private Function List_set()

    End Function
    Private Function Load_()
        With Accounting_Voucher_frm
            Txt1.Text = .cfg_print_head

            Yn1.Text = Boolean_TXT(.cfg_YN_narration)
            Yn2.Text = Boolean_TXT(.cfg_print_signature)
            Yn4.Text = Boolean_TXT(.cfg_print_stamp)
            Yn3.Text = Boolean_TXT(.cfg_print_Provisnoal)

        End With
    End Function
    Public Function Save_()
        With Accounting_Voucher_frm
            .cfg_print_head = Txt1.Text

            .cfg_YN_narration = YN_Boolean(Yn1.Text)
            .cfg_print_signature = YN_Boolean(Yn2.Text)
            .cfg_print_stamp = YN_Boolean(Yn4.Text)
            .cfg_print_Provisnoal = YN_Boolean(Yn3.Text)

        End With


        Printing_Direct_frm.Dispose()
        Print_Cfg_Dialoag.Dispose()
        Accounting_Voucher_frm.Print_Page()
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Save_()
    End Sub
    Private Sub Button1_KeyDown(sender As Object, e As KeyEventArgs) Handles Button1.KeyDown
        If e.KeyCode = Keys.Back Then
            SendKeys.Send("+{TAB}")
        End If
    End Sub
End Class
