Imports System.Data.SQLite
Public Class vc_payment_terms_ctrl
    Public obj As Object
    Dim tra_ID As String
    Private Function Load_()
        terms_of_payment_txt.Text = Inventory_Vouchers_frm.Terms_of_payment
        other_reference_txt.Text = Inventory_Vouchers_frm.Payment_reference
        terms_of_dilivry_txt.Text = Inventory_Vouchers_frm.terms_of_delivery
    End Function
    Private Function Save_()
        Inventory_Vouchers_frm.Terms_of_payment = terms_of_payment_txt.Text
        Inventory_Vouchers_frm.Payment_reference = other_reference_txt.Text
        Inventory_Vouchers_frm.terms_of_delivery = terms_of_dilivry_txt.Text
    End Function


    Private Sub vc_transport_ctrl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_()

        Fill_data_source()

        terms_of_payment_txt.Focus()

        SendKeys.Send("+{TAB}")
    End Sub
    Private Function Fill_data_source()

    End Function

    Private Sub Button1_KeyDown(sender As Object, e As KeyEventArgs) Handles Button1.KeyDown
        If e.KeyCode = Keys.Back Then
            SendKeys.Send("+{TAB}")
        End If
        If e.KeyCode = Keys.Enter Then
            Save_()
            Me.Dispose()
            Inventory_Vouchers_frm.SelectNextControl(obj, True, True, True, True)
        End If
    End Sub
End Class
