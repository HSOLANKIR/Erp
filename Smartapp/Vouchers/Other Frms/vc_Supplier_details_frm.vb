Imports Tools

Public Class vc_Supplier_details_frm
    Dim From_ID As String
    Dim Path_End As String
    Private Sub vc_Supplier_details_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        obj_top(Panel1)
        Path_End = BG_frm.BG_Path_TXT.Text
        BG_frm.HADE_TXT.Text = "VC Supplier Details"
        BG_frm.TYP_TXT.Text = ""

        Button_Manage()
        NOT_Clear()
        Add_Hander_Remove_Handel(True)


        Load_data()
        List_set()
        Load_()

        If Inventory_Vouchers_frm.VC_Formate = "Credit Note" Or Inventory_Vouchers_frm.VC_Formate = "Debit Note" Then
            Panel3.Visible = True
        Else
            Panel3.Visible = False
        End If

        If Inventory_Vouchers_frm.VC_Formate = "Debit Note" Then
            Panel2.Visible = False
        Else
            Panel2.Visible = True
        End If



    End Sub

    Private Function Button_Manage()
        BG_frm.B_1.Text = "&E : Exit"
        BG_frm.B_2.Text = "&S : Save"
    End Function
    Private Function Add_Hander_Remove_Handel(Ans As Boolean)
        If Ans = True Then
            AddHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            AddHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
        Else
            RemoveHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            RemoveHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
        End If
    End Function
    Private Sub B_1_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Succ_ = False
            Me.Dispose()
        End If
    End Sub
    Private Sub B_2_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Save_()
            Succ_ = True
            Me.Dispose()
        End If
    End Sub
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        obj_top(Panel1)
    End Sub

    Private Sub vc_Supplier_details_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.HADE_TXT.Text = "VC Supplier Details"
        BG_frm.TYP_TXT.Text = ""
        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text

        Button_Clear()
        Button_Manage()

        Load_data()


        Acc_Mailing_TXT.Focus()
    End Sub
    Dim Succ_ As Boolean = False
    Private Sub vc_Supplier_details_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Succ_ = False
            Me.Dispose()
        End If
    End Sub

    Private Sub vc_Supplier_details_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End
        Add_Hander_Remove_Handel(False)

        If Succ_ = True Then
            Inventory_Vouchers_frm.SelectNextControl(Inventory_Vouchers_frm.Yn5, True, True, True, True)
        Else
            Inventory_Vouchers_frm.Yn5.Focus()
        End If
    End Sub
    Dim acc_list As List_frm
    Private Function List_set()
        acc_list = New List_frm
        List_Setup("List of Reasons", Select_List.Right, Select_List_Format.Singel, Txt2, acc_list, BindingSource1, 250)

    End Function
    Private Function Load_data()
        Dim dt As New DataTable
        dt.Columns.Add("Name")
        If Inventory_Vouchers_frm.VC_Formate = "Credit Note" Then
            dt.Rows.Add("Not Applicable")
            dt.Rows.Add("Sales Return")
            dt.Rows.Add("Post Sale Discount")
            dt.Rows.Add("Deficiency in services")
            dt.Rows.Add("Correction in Invoice")
            dt.Rows.Add("Change in POS")
            dt.Rows.Add("Finalization of Provisional assessment")
            dt.Rows.Add("Others")
        ElseIf Inventory_Vouchers_frm.VC_Formate = "Debit Note" Then
            dt.Rows.Add("Not Applicable")
            dt.Rows.Add("Correction in Invoice")
            dt.Rows.Add("Change in POS")
            dt.Rows.Add("Finalization of Provisional assessment")
            dt.Rows.Add("Others")
        End If
        BindingSource1.DataSource = dt
    End Function
    Private Function Load_()
        With Inventory_Vouchers_frm
            Acc_Mailing_TXT.Text = .supplier_vc_no
            Date_TXT.Text = .supplier_date
            Txt2.Text = .credit_note_resion
            Acc_Address_TXT.Text = .supplier_narration
        End With
    End Function
    Private Function Save_()
        With Inventory_Vouchers_frm
            .supplier_vc_no = Acc_Mailing_TXT.Text
            .supplier_date = Date_TXT.Text
            .credit_note_resion = Txt2.Text
            .supplier_narration = Acc_Address_TXT.Text
        End With
    End Function
    Private Sub save_txt_Enter(sender As Object, e As EventArgs) Handles save_txt.Enter
        Save_()
        Succ_ = True
        Me.Dispose()
    End Sub

    Private Sub vc_Supplier_details_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
    End Sub
End Class