Public Class ivc_Print_cfg_ctrl
    Private Sub ivc_Print_cfg_ctrl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Fill_Data()
        List_set()


        LOAD_()
    End Sub
    Private Function Fill_Data()
        Dim dt As New DataTable
        dt.Columns.Add("Name")
        dt.Rows.Add("Original Receipt")
        dt.Rows.Add("Duplicate Receipt")
        dt.Rows.Add("Triplicate Receipt")
        dt.Rows.Add("Transporter")
        dt.Rows.Add("Extra Copy")
        BindingSource1.DataSource = dt

        dt = New DataTable
        dt.Columns.Add("Name")
        dt.Rows.Add("Manual Pay")
        dt.Rows.Add("Current Value")
        dt.Rows.Add("Provisional Value")

        BindingSource2.DataSource = dt

        dt = New DataTable
        dt.Columns.Add("Name")

        dt.Rows.Add("Amount")
        dt.Rows.Add("Not Applicable")
        dt.Rows.Add("Barcode")
        provinoal_source.DataSource = dt
    End Function
    Dim acc_list As List_frm
    Dim acc_list1 As List_frm
    Dim Provinoal_List As List_frm

    Private Function List_set()
        acc_list = New List_frm
        List_Setup("Type of Print", Select_List.Right, Select_List_Format.Singel, Txt2, acc_list, BindingSource1, 200)

        acc_list1 = New List_frm
        List_Setup("Payment Qr Code Value", Select_List.Right, Select_List_Format.Singel, Txt3, acc_list1, BindingSource2, 200)


        Provinoal_List = New List_frm
        List_Setup("Type of Provisional Balance", Select_List.Right, Select_List_Format.Singel, Provisnoal_TXT, Provinoal_List, provinoal_source, 150)
    End Function

    Private Function Load_()
        With Inventory_Vouchers_frm
            Txt1.Text = .cfg_print_head
            Txt2.Text = .cfg_print_type

            Yn1.Text = Boolean_TXT(.cfg_YN_print_item_MRP)
            Yn2.Text = Boolean_TXT(.cfg_YN_narration)
            Yn4.Text = Boolean_TXT(.cfg_print_signature)
            Yn3.Text = Boolean_TXT(.cfg_print_stamp)
            Yn8.Text = Boolean_TXT(.cfg_YN_print_pay_qry)
            Txt3.Text = (.cfg_print_pay_value)
            Provisnoal_TXT.Text = (.cfg_print_Provisnoal)


            If Yn8.Text = "Yes" Then
                Txt3.Visible = True
                Label18.Visible = True
                Label12.Visible = True
            Else
                Txt3.Visible = False
                Label18.Visible = False
                Label12.Visible = False
            End If
        End With
    End Function
    Public Function Save_()
        With Inventory_Vouchers_frm
            .cfg_print_head = Txt1.Text
            .cfg_print_type = Txt2.Text

            .cfg_YN_print_item_MRP = YN_Boolean(Yn1.Text)
            .cfg_YN_narration = YN_Boolean(Yn2.Text)
            .cfg_print_signature = YN_Boolean(Yn4.Text)
            .cfg_print_stamp = YN_Boolean(Yn3.Text)
            .cfg_YN_print_pay_qry = YN_Boolean(Yn8.Text)
            .cfg_print_Provisnoal = (Provisnoal_TXT.Text)
            .cfg_print_pay_value = (Txt3.Text)
        End With


        Printing_Direct_frm.Dispose()
        Print_Cfg_Dialoag.Dispose()
        Inventory_Vouchers_frm.Print_Page()
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Save_()
    End Sub

    Private Sub Button1_KeyDown(sender As Object, e As KeyEventArgs) Handles Button1.KeyDown
        If e.KeyCode = Keys.Back Then
            SendKeys.Send("+{TAB}")
        End If
    End Sub

    Private Sub Yn8_TextChanged(sender As Object, e As EventArgs) Handles Yn8.TextChanged
        If Yn8.Text = "Yes" Then
            Txt3.Visible = True
            Label18.Visible = True
            Label12.Visible = True
        Else
            Txt3.Visible = False
            Label18.Visible = False
            Label12.Visible = False
        End If
    End Sub
End Class
