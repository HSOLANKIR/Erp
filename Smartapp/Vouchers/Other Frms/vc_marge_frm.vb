Imports System.Data.SQLite
Imports Tools

Public Class vc_marge_frm
    Dim From_ID As String
    Dim Path_End As String
    Dim voucher_type_id As String = 0
    Dim ledger_id As String = 0
    Dim item_id As String = 0
    Private Sub vc_marge_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text
        BG_frm.HADE_TXT.Text = "Merge Voucher"
        BG_frm.TYP_TXT.Text = ""


        Button_Manage()
        NOT_Clear()
        Add_Hander_Remove_Handel(True)

        Load_data()
        List_set()

        frm_TXT.Text = Date_Formate(Date_1)
        To_TXT.Text = Date_Formate(Date_2)
        Label8.Text = Inventory_Vouchers_frm.Voucher_Name_LB.Text
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
            Succ_ = True
            Me.Dispose()
        End If
    End Sub
    Private Sub vc_marge_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.HADE_TXT.Text = "Merge Voucher"
        BG_frm.TYP_TXT.Text = ""
        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text

        Button_Clear()
        Button_Manage()


        frm_TXT.Focus()
    End Sub

    Private Sub vc_marge_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Succ_ = False
            Me.Dispose()
        End If
    End Sub

    Private Sub vc_marge_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End
        Add_Hander_Remove_Handel(False)
        'Frm_foCus()
        Inventory_Vouchers_frm.Account_TXT.Focus()
        If Succ_ = True Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Dim Succ_ As Boolean = False
    Dim acc_list As List_frm
    Dim itm_list As List_frm
    Dim vc_list As List_frm
    Private Function List_set()
        acc_list = New List_frm
        List_Setup("List of Ledger", Select_List.Right_Dock, Select_List_Format.Defolt, Acc_Name_TXT, acc_list, Ledger_Source, 320, {"Create|Alt + C", "Alter|Ctrl + Enter"})

        vc_list = New List_frm
        List_Setup($"List of Vouchers ({Inventory_Vouchers_frm.Voucher_Type_LB.Text})", Select_List.Right, Select_List_Format.Singel, vc_txt, vc_list, Voucher_type_source, 200)

        itm_list = New List_frm
        List_Setup($"List of Stock Item", Select_List.Botom, Select_List_Format.Defolt, item_TX, itm_list, Item_Source, 350)

    End Function
    Private Function Load_data()
        Dim Positive As String = Find_DT_Value(Database_File.cmp, "TBL_Features", "Value", "Head = 'Positive Value'")
        Dim Negative As String = Find_DT_Value(Database_File.cmp, "TBL_Features", "Value", "Head = 'Negative Value'")

        Dim cn As New SQLiteConnection
        Dim dt_ As New DataTable
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            dt_.Columns.Clear()
            dt_.Columns.Add("Name")
            dt_.Columns.Add("Under")
            dt_.Columns.Add("ID")

            dt_.Rows.Add("Not Applicable", "", "0")

            Dim r As SQLiteDataReader
            cmd = New SQLiteCommand($"Select [ID],[Name],(Select ag.name From TBL_Acc_Group ag where ag.id = ld.[Group]) as Group_Name From TBL_Ledger LD where ([Group] = '22' or [Group] = '26' or [Group] = '27')", cn)

            With cmd.Parameters
                r = cmd.ExecuteReader
                While r.Read
                    dt_.Rows.Add(r("Name"), r("Group_Name"), r("ID"))
                End While
            End With
            r.Close()
            Ledger_Source.DataSource = dt_



            dt_ = New DataTable
            dt_.Columns.Add("Name")
            dt_.Columns.Add("Under")
            dt_.Columns.Add("ID")
            dt_.Rows.Add("Not Applicable", "", "")

            cmd = New SQLiteCommand($"Select *,(Select sg.name From TBL_Stock_Group sg where sg.id = it.Under) as Group_Name From TBL_Stock_Item it
where it.Visible = 'Approval'", cn)

            With cmd.Parameters
                r = cmd.ExecuteReader
                While r.Read
                    dt_.Rows.Add(r("Name"), r("Group_Name"), r("ID"))
                End While
            End With
            r.Close()
            Item_Source.DataSource = dt_



            dt_ = New DataTable
            dt_.Columns.Add("Name")
            dt_.Columns.Add("ID")
            'dt_.Rows.Add("Not Applicable","0")

            cmd = New SQLiteCommand($"Select * From TBL_Voucher_Create vc
where vc.Visible = 'Approval' and vc.Under = '{Inventory_Vouchers_frm.Voucher_Type_LB.Text}' and Name <> '{Inventory_Vouchers_frm.Voucher_Name_LB.Text}'", cn)

            With cmd.Parameters
                r = cmd.ExecuteReader
                While r.Read
                    dt_.Rows.Add(r("Name"), r("ID"))
                End While
            End With
            r.Close()
            Voucher_type_source.DataSource = dt_
        End If
    End Function

    Private Sub frm_TXT_TextChanged(sender As Object, e As EventArgs) Handles frm_TXT.TextChanged, To_TXT.TextChanged
        DAte_search(sender)
    End Sub

    Private Sub frm_TXT_LostFocus(sender As Object, e As EventArgs) Handles frm_TXT.LostFocus, To_TXT.LostFocus
        If sender.Text = Nothing Then
            sender.Text = Date_Formate(Now.Date)
        End If
        sender.Text = Date_Formate(sender.Text)
        If DAte_search(sender) = "" Then
            sender.focus
        End If
    End Sub
    Private Function DAte_search(obj As TXT) As String
        If Date_Formate(obj.Text) = "" Then
            Msg_InputError(obj, obj.Data_Link_)
            Return False
        End If
        Return True
    End Function

    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs) Handles Panel5.Paint

    End Sub

    Private Sub Acc_Name_TXT_TextChanged(sender As Object, e As EventArgs) Handles Acc_Name_TXT.TextChanged

    End Sub

    Private Sub Acc_Name_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles Acc_Name_TXT.KeyDown
        If e.KeyCode = Keys.Enter Then
            ledger_id = acc_list.List_Grid.CurrentRow.Cells(2).Value.ToString
            Find_Acc_Vc_details()
        End If
    End Sub
    Private Sub vc_txt_KeyDown(sender As Object, e As KeyEventArgs) Handles vc_txt.KeyDown
        If e.KeyCode = Keys.Enter Then
            voucher_type_id = vc_list.List_Grid.CurrentRow.Cells(1).Value.ToString
        End If
    End Sub
    Private Sub item_TX_KeyDown(sender As Object, e As KeyEventArgs) Handles item_TX.KeyDown
        If e.KeyCode = Keys.Enter Then
            item_id = itm_list.List_Grid.CurrentRow.Cells(2).Value.ToString
            Find_Acc_Vc_details()

        End If
    End Sub
    Private Function Find_Acc_Vc_details()
        Dim F As String
        F &= $" where (vc.Visible = 'Approval')"
        F &= $"and (vc.Date BETWEEN '{CDate(frm_TXT.Text).ToString(Lite_date_Format)}' and '{CDate(To_TXT.Text).AddDays(1).ToString(Lite_date_Format)}')"
        F &= $" and (vc.Voucher_Type_ID = '{voucher_type_id}')"

        If Val(ledger_id) <> 0 Then
            F &= $" and (vc.Ledger = '{ledger_id}')"
        End If

        If Val(item_id) <> 0 Then
            F &= $" and (vi.Item = '{item_id}')"
        End If


        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select ifnull(SUM(Debit_Amount),0) + ifnull(SUM(Credit_Amount),0) as Amt,count(*) as count,ifnull(SUM(vi.Qty),0) as Qty,(Select u.Symbol From TBL_Inventory_Unit u where u.id = (Select it.Unit From TBL_Stock_Item it where it.id = vi.Item)) as Unit_Name,ifnull(SUM(vi.Amount),0) as it_amt From TBL_VC vc LEFT JOIN TBL_VC_item_Details vi on vi.Tra_ID = vc.Tra_ID {F} and vc.Type = 'Head'", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader

            While r.Read
                Label9.Text = Val(r("Count").ToString)
                Label14.Text = N2_FORMATE(r("Amt").ToString)

                If Val(item_id) = 0 Then
                    Label21.Text = "Not Applicable"
                Else
                    Label21.Text = N2_FORMATE(r("Qty").ToString) & " " & r("Unit_Name")
                End If
                Label18.Text = N2_FORMATE(r("it_amt").ToString)
            End While
        End If
    End Function

    Private Sub vc_txt_TextChanged(sender As Object, e As EventArgs) Handles vc_txt.TextChanged

    End Sub

    Private Sub item_TX_TextChanged(sender As Object, e As EventArgs) Handles item_TX.TextChanged

    End Sub

    Private Sub Save_TXT_TextChanged(sender As Object, e As EventArgs) Handles Save_TXT.TextChanged

    End Sub

    Private Sub Save_TXT_Enter(sender As Object, e As EventArgs) Handles Save_TXT.Enter
        If Msg_Custom_YN(NOT_Location.Bottom_Right, Color.DarkCyan, My.Resources.Marge_animation_icn, Dialoag_Button.Yes_No, "Marge Vouchers", $"{vc_txt.Text} -> {Label8.Text}", "Are you sure?") = DialogResult.Yes Then


            Dim F As String
            F &= $" where (vc.Visible = 'Approval')"
            F &= $"and (vc.Date BETWEEN '{CDate(frm_TXT.Text).ToString(Lite_date_Format)}' and '{CDate(To_TXT.Text).AddDays(1).ToString(Lite_date_Format)}')"
            F &= $" and (vc.Voucher_Type_ID = '{voucher_type_id}')"

            If Val(ledger_id) <> 0 Then
                F &= $" and (vc.Ledger = '{ledger_id}')"
            End If

            If Val(item_id) <> 0 Then
                F &= $" and (vi.Item = '{item_id}')"
            End If

            With Inventory_Vouchers_frm
                .Marge_Voucher_Filter = F
                .cstm_control_mng(.Item_Progress_Panel)
                Me.Dispose()
                .Marge_Timer.Start()
            End With
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        obj_top(sender)
    End Sub

    Private Sub vc_marge_frm_GiveFeedback(sender As Object, e As GiveFeedbackEventArgs) Handles Me.GiveFeedback

    End Sub

    Private Sub vc_marge_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus

        BG_frm.From_ID = From_ID
    End Sub
End Class