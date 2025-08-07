Imports System.Data.SQLite

Public Class Filter_frm
    Dim From_ID As String
    Dim Path_End As String
    Dim VC_Type_ As String
    Dim frm_ As String
    Private Sub Filter_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text
        VC_Type_ = Link_Valu(0)
        frm_ = Link_Valu(1)

        BG_frm.HADE_TXT.Text = "Filter"
        BG_frm.TYP_TXT.Text = VC_Type_

        obj_top(Panel4)

        Fill_Data()

    End Sub
    Dim me_list As List_frm
    Private Sub Filter_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.HADE_TXT.Text = "Filter"
        BG_frm.TYP_TXT.Text = VC_Type_
        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text

        Button_Clear()
        TX.Focus()
    End Sub

    Private Sub Filter_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub Filter_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End
        List_frm.Dispose()
        Frm_foCus()
    End Sub
    Private Function Fill_Data()
        Dim dt As New DataTable
        dt.Columns.Add("Head")
        dt.Columns.Add("Under")
        dt.Columns.Add("ID")

        If VC_Type_ = "Branch" Then
            BindingSource1.DataSource = Branch_Data(dt)
            List_set("List of Branch")
            Label3.Text = "Select Branch"
            TX.Text = Dft_Branch
        ElseIf VC_Type_ = "Valuation" Then
            BindingSource1.DataSource = Valuation_Data(dt)
            List_set("List of Valuation")
            Label3.Text = "Select Valuation Type"
            TX.Text = Dft_Valuation
        ElseIf VC_Type_ = "Godown" Then
            BindingSource1.DataSource = Godown_Data(dt)
            List_set("List of Godown")
            Label3.Text = "Select Godown"
            TX.Text = dft_Godown_Name
        ElseIf VC_Type_ = "Voucher Type" Then
            BindingSource1.DataSource = Voucher_Type_Data(dt)
            List_set("List of Voucher Type")
            Label3.Text = "Select Voucher Type"
            TX.Text = Dft_Voucher
        ElseIf (VC_Type_ = "Change Voucher:Contra" Or VC_Type_ = "Change Voucher:Payment" Or VC_Type_ = "Change Voucher:Receipt" Or VC_Type_ = "Change Voucher:Journal") Or (VC_Type_ = "Change Voucher:Purchase" Or VC_Type_ = "Change Voucher:Sales" Or VC_Type_ = "Change Voucher:Purchase Order" Or VC_Type_ = "Change Voucher:Sales Order" Or VC_Type_ = "Change Voucher:Inward Register" Or VC_Type_ = "Change Voucher:Outward Register" Or VC_Type_ = "Change Voucher:Credit Note" Or VC_Type_ = "Change Voucher:Debit Note" Or VC_Type_ = "Change Voucher:Stock Journal") Or (VC_Type_ = "Change Voucher:Attendance" Or VC_Type_ = "Change Voucher:Payroll") Then
            BindingSource1.DataSource = Voucher_Type_Custome_Data(dt, VC_Type_.Split(":")(1))
            List_set($"List of {VC_Type_.Split(":")(1)} Voucher")
            Label3.Text = $"Select {VC_Type_.Split(":")(1)} Voucher"
            'TX.Text = Dft_Voucher
        ElseIf (VC_Type_ = "Change Voucher:All Vouchers") Then
            BindingSource1.DataSource = Voucher_Type_Custome_Data(dt, VC_Type_.Split(":")(1))
            List_set($"List of {VC_Type_.Split(":")(1)} Voucher")
            Label3.Text = $"Select {VC_Type_.Split(":")(1)} Voucher"
        End If

    End Function


    Private Function List_set(head As String)
        me_list = New List_frm
        List_Setup("List of ", Select_List.Botom_Center, Select_List_Format.Defolt, TX, me_list, BindingSource1, TX.Width + 100)
        me_list.List_Head_TXT.Text = head
    End Function
    Private Function Valuation_Data(dt As DataTable) As DataTable
        dt.Rows.Add("Default", "", "")
        dt.Rows.Add("At Zero Price", "", "")
        dt.Rows.Add("Avg. Cost (as per period)", "", "")
        dt.Rows.Add("Avg. Price (as per period)", "", "")
        dt.Rows.Add("Last Purchase Cost", "", "")
        dt.Rows.Add("Last Sales Price", "", "")
        dt.Rows.Add("Std. Cost", "", "")
        dt.Rows.Add("Std. Price", "", "")
        'dt.Rows.Add("Basic Purchase Rate", "", "")
        'dt.Rows.Add("Basic Sales Rate", "", "")

        Return dt
    End Function
    Private Function Voucher_Type_Data(dt As DataTable) As DataTable
        dt.Rows.Add("All Vouchers", "", "")
        dt.Rows.Add("Attendance", "", "")
        dt.Rows.Add("Contra", "", "")
        dt.Rows.Add("Credit Note", "", "")
        dt.Rows.Add("Debit Note", "", "")
        dt.Rows.Add("Journal", "", "")
        dt.Rows.Add("Payment", "", "")
        dt.Rows.Add("Payroll", "", "")
        dt.Rows.Add("Purchase", "", "")
        dt.Rows.Add("Purchase Order", "", "")
        dt.Rows.Add("Receipt", "", "")
        dt.Rows.Add("Sales", "", "")
        dt.Rows.Add("Sales Order", "", "")
        dt.Rows.Add("Outward Register", "", "")
        dt.Rows.Add("Inward Register", "", "")
        dt.Rows.Add("Stock Journal", "", "")
        Return dt
    End Function
    Private Function Voucher_Type_Custome_Data(dt As DataTable, Type As String) As DataTable
        Dim filter As String = ""

        If Type = "All Vouchers" Then
            filter = ""
        Else
            filter = $"and Under = '{Type}'"
        End If



        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select vc.Name,vc.Under,vc.ID From TBL_Voucher_Create vc
where vc.Visible = 'Approval' {filter }", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                dt.Rows.Add(r("Name"), r("Under"), r("ID"))
            End While
            r.Close()
        End If

        Return dt
    End Function
    Private Function Godown_Data(dt As DataTable) As DataTable
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            dt.Rows.Add("All Godown", "", "")

            cmd = New SQLiteCommand("Select * From TBL_Stock_Godown where Visible = 'Approval' and (Company = 'All' or Company = '" & Company_ID_str & "')", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                dt.Rows.Add(r("Name"), r("Nickname"), r("ID"))
            End While
            r.Close()
        End If

        Return dt
    End Function
    Private Function Branch_Data(dt As DataTable) As DataTable
        Dim cn As New SQLiteConnection
        dt.Rows.Add("Primary", "", "")

        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then

            cmd = New SQLiteCommand("Select * From TBL_Ledger WHERE Visible = 'Approval' and [Group] = '7'", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                dt.Rows.Add(r("Name"), r("Alise"), r("ID"))
            End While
            r.Close()
        End If

        Return dt
    End Function

    Private Sub TX_TextChanged(sender As Object, e As EventArgs) Handles TX.TextChanged
        If TX.Text = Nothing Then
            BindingSource1.MoveFirst()
        End If
    End Sub

    Private Sub TX_KeyDown(sender As Object, e As KeyEventArgs) Handles TX.KeyDown
        If e.KeyCode = Keys.Enter Then
            TX.Data_Link_ = me_list.List_Grid.CurrentRow.Cells(2).Value.ToString
            If VC_Type_ = "Branch" Then
                Dft_Branch = me_list.List_Grid.CurrentRow.Cells(0).Value.ToString
            ElseIf VC_Type_ = "Valuation" Then
                Dft_Valuation = me_list.List_Grid.CurrentRow.Cells(0).Value.ToString
            ElseIf VC_Type_ = "Godown" Then
                dft_Godown_Name = me_list.List_Grid.CurrentRow.Cells(0).Value.ToString
            ElseIf VC_Type_ = "Voucher Type" Then
                Dft_Voucher = me_list.List_Grid.CurrentRow.Cells(0).Value.ToString
            ElseIf VC_Type_ = "Change Voucher:Contra" Or VC_Type_ = "Change Voucher:Payment" Or VC_Type_ = "Change Voucher:Receipt" Or VC_Type_ = "Change Voucher:Journal" Then

            End If
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint
        obj_top(Panel4)
    End Sub

    Private Sub Save_TXT_TextChanged(sender As Object, e As EventArgs) Handles Save_TXT.TextChanged

    End Sub

    Private Sub Save_TXT_Enter(sender As Object, e As EventArgs) Handles Save_TXT.Enter


        If (VC_Type_ = "Change Voucher:All Vouchers") Then
            Dim Date_ As Date
            Dim Vc_Type As String
            Dim Tra_ID_ As String

            With Accounting_Voucher_frm
                If .Visible = True Then
                    Date_ = CDate(.Date_TXT.Text)
                    Vc_Type = .VC_Type_
                    Tra_ID_ = .Tra_ID
                End If
            End With

            With Inventory_Vouchers_frm
                If .Visible = True Then
                    Date_ = CDate(.Date_TXT.Text)
                    Vc_Type = .VC_Type_
                    Tra_ID_ = .Tra_ID
                End If
            End With

            With Payroll_Vouchers_frm
                If .Visible = True Then
                    Date_ = CDate(.Date_TXT.Text)
                    Vc_Type = .VC_Type_
                    Tra_ID_ = .Tra_ID
                End If
            End With


            If me_list.List_Grid.CurrentRow.Cells(1).Value = "Payment" Or me_list.List_Grid.CurrentRow.Cells(1).Value = "Receipt" Or me_list.List_Grid.CurrentRow.Cells(1).Value = "Contra" Or me_list.List_Grid.CurrentRow.Cells(1).Value = "Journal" Then
                If Accounting_Voucher_frm.Visible = True Then
                    VC_Type_ = $"Change Voucher:{me_list.List_Grid.CurrentRow.Cells(1).Value}"
                Else
                    Voucher_BG_frm.Dispose()
                    Cell("Voucher BG", "", "Voucher Transfer", Me.me_list.List_Grid.CurrentRow.Cells(1).Value.ToString, Me.me_list.List_Grid.CurrentRow.Cells(2).Value.ToString, Date_, Tra_ID_)
                End If
            ElseIf (me_list.List_Grid.CurrentRow.Cells(1).Value = "Purchase" Or me_list.List_Grid.CurrentRow.Cells(1).Value = "Sales" Or me_list.List_Grid.CurrentRow.Cells(1).Value = "Purchase Order" Or me_list.List_Grid.CurrentRow.Cells(1).Value = "Sales Order" Or me_list.List_Grid.CurrentRow.Cells(1).Value = "Inward Register" Or me_list.List_Grid.CurrentRow.Cells(1).Value = "Outward Register" Or me_list.List_Grid.CurrentRow.Cells(1).Value = "Credit Note" Or me_list.List_Grid.CurrentRow.Cells(1).Value = "Debit Note" Or me_list.List_Grid.CurrentRow.Cells(1).Value = "Stock Journal") Then
                If Inventory_Vouchers_frm.Visible = True Then
                    VC_Type_ = $"Change Voucher:{me_list.List_Grid.CurrentRow.Cells(1).Value}"
                Else
                    Voucher_BG_frm.Dispose()
                    Cell("Voucher BG", "", "Voucher Transfer", Me.me_list.List_Grid.CurrentRow.Cells(1).Value.ToString, Me.me_list.List_Grid.CurrentRow.Cells(2).Value.ToString, Date_, Tra_ID_)
                End If
            ElseIf (me_list.List_Grid.CurrentRow.Cells(1).Value = "Attendance" Or me_list.List_Grid.CurrentRow.Cells(1).Value = "Payroll") Then
                If Payroll_Vouchers_frm.Visible = True Then
                    VC_Type_ = $"Change Voucher:{me_list.List_Grid.CurrentRow.Cells(1).Value}"
                Else
                    Voucher_BG_frm.Dispose()
                    Cell("Voucher BG", "", "Voucher Transfer", Me.me_list.List_Grid.CurrentRow.Cells(1).Value.ToString, Me.me_list.List_Grid.CurrentRow.Cells(2).Value.ToString, Date_, Tra_ID_)
                End If
            End If

        End If


        Me.Dispose()


        If VC_Type_ = "Change Voucher:Contra" Or VC_Type_ = "Change Voucher:Payment" Or VC_Type_ = "Change Voucher:Receipt" Then
            With Accounting_Voucher_frm
                If .VC_Formate.ToLower = "journal" Then
                    .Panel30.Controls.Clear()
                    .controls_add("payment")
                End If
                .VC_Formate_ID = TX.Data_Link_
                .VC_Formate = VC_Type_.Split(":")(1)
                .Defolt_Set_Voucher()
                .Voucher_No_Setup()
                .Date_TXT.Focus()
            End With
        ElseIf VC_Type_ = "Change Voucher:Journal" Then
            With Accounting_Voucher_frm
                If .VC_Formate.ToLower = "payment" Or .VC_Formate.ToLower = "receipt" Or .VC_Formate.ToLower = "contra" Then
                    .Panel30.Controls.Clear()
                    .controls_add("journal")
                End If
                .VC_Formate_ID = TX.Data_Link_
                .VC_Formate = VC_Type_.Split(":")(1)
                .Defolt_Set_Voucher()
                .Voucher_No_Setup()
                .Date_TXT.Focus()
            End With
        End If

        If (VC_Type_ = "Change Voucher:Purchase" Or VC_Type_ = "Change Voucher:Sales" Or VC_Type_ = "Change Voucher:Purchase Order" Or VC_Type_ = "Change Voucher:Sales Order" Or VC_Type_ = "Change Voucher:Inward Register" Or VC_Type_ = "Change Voucher:Outward Register" Or VC_Type_ = "Change Voucher:Credit Note" Or VC_Type_ = "Change Voucher:Debit Note") Then
            With Inventory_Vouchers_frm
                If .VC_Formate.ToLower = "stock journal" Then
                    .Panel30.Controls.Clear()
                    .controls_add("purchase")
                End If
                .VC_Formate_ID = TX.Data_Link_
                .VC_Formate = VC_Type_.Split(":")(1)
                .Defolt_Set_Voucher()
                .Voucher_No_Setup()
                .Date_TXT.Focus()
            End With
        ElseIf VC_Type_ = "Change Voucher:Stock Journal" Then
            With Inventory_Vouchers_frm
                If (.VC_Formate.ToLower = "purchase" Or .VC_Formate.ToLower = "sales" Or .VC_Formate.ToLower = "purchase order" Or .VC_Formate.ToLower = "sales order" Or .VC_Formate.ToLower = "inward register" Or .VC_Formate.ToLower = "outward register" Or .VC_Formate.ToLower = "credit note" Or .VC_Formate.ToLower = "debit note") Then
                    .Panel30.Controls.Clear()
                    .controls_add("stock journal")
                End If
                .VC_Formate_ID = TX.Data_Link_
                .VC_Formate = VC_Type_.Split(":")(1)
                .Defolt_Set_Voucher()
                .Voucher_No_Setup()
                .Date_TXT.Focus()
            End With
        End If

        If VC_Type_ = "Change Voucher:Attendance" Then
            With Payroll_Vouchers_frm
                If .VC_Formate.ToLower = "payroll" Then
                    .Panel30.Controls.Clear()
                    .controls_add("attendance")
                End If
                .VC_Formate_ID = TX.Data_Link_
                .VC_Formate = VC_Type_.Split(":")(1)
                .Defolt_Set_Voucher()
                .Voucher_No_Setup()
                .Date_TXT.Focus()
            End With
        ElseIf VC_Type_ = "Change Voucher:Payroll" Then
            With Payroll_Vouchers_frm
                If .VC_Formate.ToLower = "attendance" Then
                    .Panel30.Controls.Clear()
                    .controls_add("payroll")
                End If
                .VC_Formate_ID = TX.Data_Link_
                .VC_Formate = VC_Type_.Split(":")(1)
                .Defolt_Set_Voucher()
                .Voucher_No_Setup()
                .Date_TXT.Focus()
            End With
        End If
        Frm_foCus()
    End Sub

    Private Sub Filter_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
    End Sub
End Class