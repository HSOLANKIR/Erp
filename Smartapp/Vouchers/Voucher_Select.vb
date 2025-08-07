Imports System.Data.SQLite

Public Class Voucher_Select
    Dim From_ID As String
    Dim Under_ID As String
    Dim Under As String
    Dim Path_End As String
    Dim VC_Type_ As String
    Dim VC_ID_ As String
    Private Sub Voucher_Select_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text
        VC_Type_ = Link_Valu(1)
        VC_ID_ = Link_Valu(2)

        BG_frm.HADE_TXT.Text = "Select Voucher"
        BG_frm.TYP_TXT.Text = VC_Type_


        obj_top(Panel4)
        Fill_Source()

        me_list = New List_frm
        List_Setup("List of Vouchers", Select_List.Botom_Center, Select_List_Format.Defolt, TX, me_list, BindingSource1, TX.Width + 100)
    End Sub
    Private Function Fill_Source()
        Dim cn As New SQLiteConnection
        Dim dt_ As New DataTable

        Dim filter_ As String = ""
        If Account_YN = True Then
            If Acc_Contra_YN = False Then filter_ &= " and (vc.[Under] <> 'Contra')"
            If Acc_Payment_YN = False Then filter_ &= " and (vc.[Under] <> 'Payment')"
            If Acc_Receipt_YN = False Then filter_ &= " and (vc.[Under] <> 'Receipt')"
            If Acc_Journal_YN = False Then filter_ &= " and (vc.[Under] <> 'Journal')"
        Else
            filter_ &= " and (vc.[Under] <> 'Contra' and vc.[Under] <> 'Payment' and vc.[Under] <> 'Receipt' and vc.[Under] <> 'Journal')"
        End If


        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            dt_.Columns.Clear()
            dt_.Columns.Add("Name")
            dt_.Columns.Add("Under")
            dt_.Columns.Add("ID")
            cmd = New SQLiteCommand($"Select * From TBL_Voucher_Create vc
where vc.Visible = 'Approval' {filter_}", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                dt_.Rows.Add(r("Name"), r("Under"), r("ID"))
            End While
            r.Close()
        End If
        BindingSource1.DataSource = dt_
    End Function
    Dim me_list As List_frm
    Private Sub Voucher_Select_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.HADE_TXT.Text = "Select Voucher"
        BG_frm.TYP_TXT.Text = VC_Type_
        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text

        Button_Clear()
        TX.Focus()
    End Sub

    Private Sub Voucher_Select_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub Voucher_Select_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End
        List_frm.Dispose()
        Frm_foCus()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TX.TextChanged

    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TX.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            Cell("Voucher BG", "", "Create", Me.me_list.List_Grid.CurrentRow.Cells(1).Value.ToString, Me.me_list.List_Grid.CurrentRow.Cells(2).Value.ToString)
            SendKeys.Send("{BACKSPACE}")
        End If
        If e.KeyCode = Keys.F1 AndAlso e.Modifiers = Keys.Alt Then
            Cell("Voucher BG", "", "Create", "Stock Journal")
        ElseIf e.KeyCode = Keys.F1 AndAlso e.Modifiers = Keys.Control Then

        ElseIf e.KeyCode = Keys.F1 Then
        End If


        If e.KeyCode = Keys.F4 AndAlso e.Modifiers = Keys.Alt Then

        ElseIf e.KeyCode = Keys.F4 AndAlso e.Modifiers = Keys.Control Then
            Cell("Voucher BG", "", "Create", "Attendance")
        ElseIf e.KeyCode = Keys.F4 Then
            Cell("Voucher BG", "", "Create", "Contra")
        End If

        If e.KeyCode = Keys.F5 AndAlso e.Modifiers = Keys.Alt Then

        ElseIf e.KeyCode = Keys.F5 AndAlso e.Modifiers = Keys.Control Then
            Cell("Voucher BG", "", "Create", "Payroll")
        ElseIf e.KeyCode = Keys.F5 Then
            Cell("Voucher BG", "", "Create", "Payment")
        End If

        If e.KeyCode = Keys.F6 Then
            Cell("Voucher BG", "", "Create", "Receipt")
        End If

        If e.KeyCode = Keys.F8 AndAlso e.Modifiers = Keys.Alt Then
            Cell("Voucher BG", "", "Create", "Outward Register")
        ElseIf e.KeyCode = Keys.F8 AndAlso e.Modifiers = Keys.Control Then
            Cell("Voucher BG", "", "Create", "Sales Order")
        ElseIf e.KeyCode = Keys.F8 Then
            Cell("Voucher BG", "", "Create", "Sales")
        End If


        If e.KeyCode = Keys.F9 AndAlso e.Modifiers = Keys.Alt Then
            Cell("Voucher BG", "", "Create", "Inward Register")
        ElseIf e.KeyCode = Keys.F9 AndAlso e.Modifiers = Keys.Control Then
            Cell("Voucher BG", "", "Create", "Purchase Order")
        ElseIf e.KeyCode = Keys.F9 Then
            Cell("Voucher BG", "", "Create", "Purchase")
        End If
    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint
        obj_top(sender)
    End Sub

    Private Sub Voucher_Select_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID

        TX.Focus()
    End Sub
End Class