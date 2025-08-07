Imports System.Data.SQLite
Imports Management.All_Message_And_Text
Imports Microsoft.Reporting.WinForms
Imports PopupControl

Public Class Balance_Sheet_frm
    Dim From_ID As String
    Private VC_Type_ As String
    Private VC_ID_ As String
    Private Path_End As String
    Dim YN_Details As Boolean = True
    Dim Acc_Under As String
    Public Frm_date As Date
    Public to_date As Date

    Public YN_Percantage As Boolean = False

    Private Sub Balance_Sheet_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text

        VC_Type_ = Link_Valu(1)
        VC_ID_ = Link_Valu(2)

        Frm_Date_LB.Text = Date_Formate(Date_1)
        To_Date_LB.Text = Date_Formate(Date_2)

        BG_frm.HADE_TXT.Text = "Balance Sheet"
        BG_frm.TYP_TXT.Text = VC_Type_

        Button_Manage()
        Add_Hander_Remove_Handel(True)


        Get_Focus(Grid1)
        Update_Report = True
    End Sub
    Private Function Button_Manage()
        BG_frm.B_1.Text = "|&P : Print"
        BG_frm.R_1.Text = "|F1 : Detailed"
        BG_frm.R_2.Text = "F2 : Date"
        BG_frm.R_3.Text = "|F2 : Period"
        If Branch_Visible() = True Then
            BG_frm.R_5.Text = "F4 : Branch"
        End If
        BG_frm.R_6.Text = "F5 : Valuation"
        'BG_frm.R_22.Text = "F12 : Configuration"
    End Function
    Private Function Add_Hander_Remove_Handel(Ans As Boolean)
        If Ans = True Then
            AddHandler BG_frm.KeyDown, AddressOf Me.BG_Keydown
            AddHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            AddHandler BG_frm.R_1.Click, AddressOf Me.R_1_Click
            AddHandler BG_frm.R_2.Click, AddressOf Me.R_3_Click
            AddHandler BG_frm.R_3.Click, AddressOf Me.R_4_Click
            AddHandler BG_frm.R_5.Click, AddressOf Me.R_5_Click
            AddHandler BG_frm.R_6.Click, AddressOf Me.R_6_Click
            AddHandler BG_frm.R_22.Click, AddressOf Me.R_22_Click
        Else
            RemoveHandler BG_frm.KeyDown, AddressOf Me.BG_Keydown
            RemoveHandler BG_frm.R_1.Click, AddressOf Me.R_1_Click
            RemoveHandler BG_frm.R_2.Click, AddressOf Me.R_3_Click
            RemoveHandler BG_frm.R_3.Click, AddressOf Me.R_4_Click
            RemoveHandler BG_frm.R_5.Click, AddressOf Me.R_5_Click
            RemoveHandler BG_frm.R_6.Click, AddressOf Me.R_6_Click
            RemoveHandler BG_frm.R_22.Click, AddressOf Me.R_22_Click
        End If
    End Function
    Private Sub R_22_Click(sender As Object, e As EventArgs)
        If BG_frm.HADE_TXT.Text = "Balance Sheet" And BG_Panel.Visible = True Then
            Cell("Configuration", "Balance Sheet")
        End If
    End Sub
    Private Sub BG_Keydown(sender As Object, e As KeyEventArgs)
        If BG_frm.From_ID = From_ID Then
            If e.KeyCode = Keys.F1 AndAlso e.Modifiers = Keys.Alt Then
                BG_frm.R_1.PerformClick()
            End If
            If e.KeyCode = Keys.F2 AndAlso e.Modifiers = Keys.Alt Then
                BG_frm.R_3.PerformClick()
            ElseIf e.KeyCode = Keys.F2 Then
                BG_frm.R_2.PerformClick()
            End If
            If e.KeyCode = Keys.F4 AndAlso e.Modifiers = Keys.Alt Then

            ElseIf e.KeyCode = Keys.F4 Then
                BG_frm.R_5.PerformClick()
            End If
            If e.KeyCode = Keys.F5 AndAlso e.Modifiers = Keys.Alt Then

            ElseIf e.KeyCode = Keys.F5 Then
                BG_frm.R_6.PerformClick()
            End If
            If e.KeyCode = Keys.F12 Then
                BG_frm.R_22.PerformClick()
            End If
        End If
    End Sub
    Dim ds_print As New Print_dt
    Dim dt_print As New DataTable

    Dim cfg_print_path As String
    Dim rdlc_report_name As String
    Dim rdlc_report_data() As ReportDataSource
    Private Sub B_1_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Print_Data()
        End If
    End Sub
    Private Function Print_Data()
        Dim ds_print As New Print_dt
        Dim D1 As New DataTable
        Dim D2 As New DataTable

        D1.Rows.Clear()
        D1 = ds_print.Tables("TBL_Balance_Sheet1")

        D2.Rows.Clear()
        D2 = ds_print.Tables("TBL_Balance_Sheet2")


        With Grid1
            For Each ro As DataGridViewRow In Grid1.Rows
                Dim Type_ As String = ro.Cells(0).Value
                Dim Head_ As String = ro.Cells(1).Value
                Dim Under_Vlu_ As String = ro.Cells(2).Value
                Dim Head_Vlu_ As String = ro.Cells(3).Value


                Dim amt_ As String = 0
                If Type_ = "Head" Then
                    amt_ = Head_Vlu_
                Else
                    amt_ = Under_Vlu_
                End If

                D1.Rows.Add(Type_, Head_, amt_)

            Next
        End With


        With Grid2
            For Each ro As DataGridViewRow In Grid2.Rows
                Dim Type_ As String = ro.Cells(0).Value
                Dim Head_ As String = ro.Cells(1).Value
                Dim Under_Vlu_ As String = ro.Cells(2).Value
                Dim Head_Vlu_ As String = ro.Cells(3).Value


                Dim amt_ As String = 0
                If Type_ = "Head" Then
                    amt_ = Head_Vlu_
                Else
                    amt_ = Under_Vlu_
                End If

                D2.Rows.Add(Type_, Head_, amt_)

            Next
        End With



        Print_data_fill(D1, D2)
        Printing_Direct_frm.Printing_(cfg_print_path, rdlc_report_name, "", rdlc_report_data)


    End Function
    Private Function Print_data_fill(d1 As DataTable, d2 As DataTable)

        cfg_print_path = Application.StartupPath & "\Print_\Report\Balance_Sheet\Balance_sheet"

        rdlc_report_name = $"Balance Sheet ({Frm_date.ToString("dd-MMM-yyyy")} to {to_date.ToString("dd-MMM-yyyy")})"
        rdlc_report_name = path_validation(rdlc_report_name, "-")

        rdlc_report_data = {New ReportDataSource("D1", d1),
            New ReportDataSource("D2", d2),
            New ReportDataSource("dt_cmp", Print_DT_Company)}

    End Function
    Private Sub R_1_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            If YN_Details = True Then
                YN_Details = False
                BG_frm.R_1.Text = "|F1 : Detailed"
            ElseIf YN_Details = False Then
                YN_Details = True
                BG_frm.R_1.Text = "|F1 : Condensed"
            End If

            Fill_Grid()
        End If
    End Sub
    Private Sub R_3_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Set_Date(False, Me)
        End If
    End Sub
    Private Sub R_4_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Set_Date(True, Me)
        End If
    End Sub
    Private Sub R_5_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Dim pop As Popup
            Dim Audit_cfg_pop As Object

            Audit_cfg_pop = New Branch_select_ctrl
            Audit_cfg_pop.frm_ = Me
            pop = New Popup(Audit_cfg_pop)

            pop.FocusOnOpen = True

            pop.AnimationDuration = 1
            pop.Show(sender)
        End If
    End Sub
    Private Sub R_6_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Cell("Filter", "Valuation", BG_frm.HADE_TXT.Text)
        End If
    End Sub
    Public Function Filter_Apply()
        Fill_Grid()

    End Function
    Public Function Apply_Date_Filter(ifPeriod As Boolean)
        If ifPeriod = True Then
            Frm_Date_LB.Text = Date_Formate(Date_1)
            To_Date_LB.Text = Date_Formate(Date_2)
        Else
            Frm_Date_LB.Text = Date_Formate(Date_3)
            To_Date_LB.Text = Date_Formate(Date_3)
        End If
        Fill_Grid()
    End Function
    Private Sub Balance_Sheet_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
        If e.KeyCode = Keys.Right Then
            Grid2.Focus()
        End If
        If e.KeyCode = Keys.Left Then
            Grid1.Focus()
        End If
    End Sub

    Private Sub Balance_Sheet_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.HADE_TXT.Text = "Balance Sheet"
        BG_frm.TYP_TXT.Text = VC_Type_

        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text
        Button_Clear()
        Button_Manage()
        Config_Fill()
        If Update_Report = True Then
            Fill_Grid()
        End If

    End Sub
    Private Function Config_Fill()

    End Function
    Dim DT_1 As New DataTable
    Dim DT_2 As New DataTable

    Dim Focus_String As String = ""
    Dim Current_Grid As DataGridView

    Private Function Fill_Grid()
        If Current_Grid.RowCount <> 0 Then
            Focus_String = Current_Grid.CurrentRow.Cells(1).Value
        End If



        Cr_Total = 0
        Dr_Total = 0

        Grid1.Rows.Clear()
        Grid2.Rows.Clear()


        Total_L.Text = "0.00"
        Total_A.Text = "0.00"

        Dim cn As New SQLiteConnection

        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            Fill_Group_acc(cn)
            Fill_Profil_Loss_vlu(cn)

            Try
                If nUmBeR_FORMATE(Total_L.Text) > nUmBeR_FORMATE(Total_A.Text) Then
                    Dim vl As String = nUmBeR_FORMATE(Total_L.Text) - nUmBeR_FORMATE(Total_A.Text)

                    Grid2.Rows.Add("Head", "Difference in opening balances", "", N2_FORMATE(vl))
                    Total_A.Text = Val(Total_A.Text) + Val(vl)
                Else
                    Dim vl As String = nUmBeR_FORMATE(Total_A.Text) - nUmBeR_FORMATE(Total_L.Text)
                    Grid1.Rows.Add("Head", "Difference in opening balances", "", N2_FORMATE(vl))
                    Total_L.Text = Val(Total_L.Text) + Val(vl)

                End If
            Catch ex As Exception

            End Try

            Try
                Current_Grid.CurrentCell = Current_Grid.Rows(Val(Focus_String)).Cells(1)
            Catch ex As Exception

            End Try

            Total_L.Text = N2_FORMATE(Total_L.Text)
            Total_A.Text = N2_FORMATE(Total_A.Text)

        End If

    End Function
    Dim Dr_Total As Decimal
    Dim Cr_Total As Decimal
    Private Function Fill_Profil_Loss_vlu(cn As SQLiteConnection)
        Dim dt_ As New DataTable
        dt_.Columns.Add("ID")
        dt_.Columns.Add("Name")
        dt_.Columns.Add("Vlu")
        dt_.Columns.Add("Type")
        dt_.Columns.Add("Open_Type")

        Dim Current_ As Decimal = 0.00
        Dim Opning_ As Decimal = 0.00

        Dim q_o As String = ""
        Dim q_c As String = ""

        q_o &= $" and (vc.[Date] <= '{CDate(Frm_date).AddDays(0).ToString(Lite_date_Format)}')"

        'q_c &= $" and (vc.[Date] <= '{CDate(to_date).AddDays(1).ToString(Lite_date_Format)}')"

        q_c &= $" and (vc.[Date] BETWEEN '{CDate(Frm_date).ToString(Lite_date_Format)}' and '{CDate(to_date).AddDays(1).ToString(Lite_date_Format) }')"


        Dim qry As String = $"Select ag.[Head] as HD,
(Select (ifnull(SUM(vc.Dr),0) - ifnull(SUM(vc.Cr),0)) From TBL_VC_Ledger vc where vc.Ledger = ld.id {q_o}) as opning_,
(Select (ifnull(SUM(vc.Dr),0) - ifnull(SUM(vc.Cr),0)) From TBL_VC_Ledger vc where vc.Ledger = ld.id {q_c}) as curr_
 From TBL_Ledger ld LEFT JOIN TBL_Acc_Group ag on ag.ID = ld.[Group] where ld.Visible = 'Approval' and (ag.[Head] = 'Income' or ag.[Head] = 'Expenses')
 
UNION ALL
 
Select ag.[Head] as HD,
(Select (ifnull(SUM(vc.Dr),0) - ifnull(SUM(vc.Cr),0)) From TBL_VC_Payroll vc where vc.Payhead = ld.id {q_o}) as opning_,
(Select (ifnull(SUM(vc.Dr),0) - ifnull(SUM(vc.Cr),0)) From TBL_VC_Payroll vc where vc.Payhead = ld.id {q_c}) as curr_
From TBL_PayHead ld LEFT JOIN TBL_Acc_Group ag on ag.ID = ld.[Under] where ld.Visible = 'Approval' and (ag.[Head] = 'Income' or ag.[Head] = 'Expenses') 

"

        cmd = New SQLiteCommand(qry, cn)
        Dim r As SQLiteDataReader = cmd.ExecuteReader

        'My.Computer.Clipboard.SetText(cmd.CommandText)

        While r.Read
            Dim vlu_opning As Decimal = Val(r("opning_"))
            Dim vlu_curr As Decimal = Val(r("curr_"))

            Opning_ += Val(vlu_opning)
            Current_ += Val(vlu_curr)


        End While


        Opning_ += Val(Find_Opning_Balance(cn)) - Val(Stock_Data_(cn, Frm_date.AddDays(-1), CDate(Company_Book_frm), Frm_date.AddDays(-1)))

        Current_ += Val(Stock_Data_(cn, Frm_date.AddDays(-1), CDate(Company_Book_frm), Frm_date.AddDays(-1))) - Val(Stock_Data_(cn, to_date, Frm_date, to_date))

        dt_.Rows.Add("", "Opning Balance", Opning_, "Under", "")
        dt_.Rows.Add("", "Current Period", Current_, "Under", "")



        Pass_Data_(True, "", "Profit & Loss A/c".ToString, dt_, "Profit&Loss")

    End Function
    Private Function Find_Opning_Balance(cn As SQLiteConnection) As Decimal
        cmd = New SQLiteCommand($"Select (SUM(OB_Value)) as vlu From TBL_Stock_Item it where it.Visible = 'Approval'", cn)
        Dim r As SQLiteDataReader = cmd.ExecuteReader

        Dim vlu As Decimal = 0.00
        While r.Read
            vlu = Val(r("Vlu").ToString)
        End While

        Return vlu
    End Function
    Public Function Fill_Group_acc(cn As SQLiteConnection)
        Dim dt_ As New DataTable
        dt_.Columns.Add("ID")
        dt_.Columns.Add("Name")
        dt_.Columns.Add("Vlu")
        dt_.Columns.Add("Type")
        dt_.Columns.Add("Open_Type")

        Dim Date_Filter As String = $" and (vl.[Date] <= '{CDate(to_date).AddDays(1).ToString(Lite_date_Format)}')"

        'SQL Data Colloct
        Dim Qry As String = $"Select * From TBL_Acc_Group ag where (ag.Head = 'Liabilities' or ag.Head = 'Assets')"
        cmd = New SQLiteCommand(Qry, cn)
        Dim r As SQLiteDataReader = cmd.ExecuteReader()

        Dim Stock_vlu As Decimal = Stock_Data_(cn, to_date, Frm_date, to_date)

        Dim q As String = ""
        q &= Date_Filter

        Dim cn1 As New SQLiteConnection
        open_MSSQL_Cstm(Database_File.cre, cn1)
        While r.Read

            'Group_data

            Qry = $"Select id,Name,SUM(Bal_) as Vlu From(
Select ag.ID,ag.Name,
(Select (ifnull(SUM(vl.Dr),0) - ifnull(SUM(vl.Cr),0))+(ifnull((lo.OB_DR),0)-ifnull((lo.OB_CR),0)) From TBL_VC_Ledger vl where ld.ID = vl.Ledger {q}) as Bal_
From TBL_Ledger ld
LEFT JOIN TBL_Acc_Group ag on ag.ID = ld.[Group]
LEFT JOIN TBL_Ledger_Opning_Balance lo on lo.Ledger_ID = ld.ID

WHERE ag.[UserGroup] = '{r("ID")}')
Group By ID


"


            cmd = New SQLiteCommand(Qry, cn1)
            Dim r1 As SQLiteDataReader = cmd.ExecuteReader

            'My.Computer.Clipboard.SetText(cmd.CommandText)

            dt_ = New DataTable
            dt_.Columns.Add("ID")
            dt_.Columns.Add("Name")
            dt_.Columns.Add("Vlu")
            dt_.Columns.Add("Type")
            dt_.Columns.Add("Open_Type")

            While r1.Read
                Dim vlu As Decimal = Val(r1("Vlu"))
                If Val(vlu) <> 0 Then
                    dt_.Rows.Add(r1("ID"), r1("Name"), vlu, "Under_Group", "Account Group")
                End If
                If r("ID").ToString = "6" Then
                    If Stock_vlu <> 0 Then
                        dt_.Rows.Add(r1("ID"), "Closing Stock", Stock_vlu, "Under", "Closing_Stock")
                        Stock_vlu = 0
                    End If
                End If
            End While


            Qry = $"Select ld.ID,ld.name,'Account Ledger' as Type,
(Select (ifnull(SUM(vl.Dr),0) - ifnull(SUM(vl.Cr),0))+0 From TBL_VC_Ledger vl where vl.Ledger = ld.id {q}) + ifnull((lo.OB_DR),0)-ifnull((lo.OB_CR),0) as Bal_
 From TBL_Ledger ld
 LEFT JOIN TBL_Ledger_Opning_Balance lo on lo.Ledger_ID = ld.ID
 where ld.Visible = 'Approval' and ld.[Group] = '{r("ID")}'
 UNION ALL

Select ld.ID,ld.name,'Payhead' as Type,
(Select (ifnull(SUM(vl.Dr),0) - ifnull(SUM(vl.Cr),0))+0 From TBL_VC_Payroll vl where vl.Payhead = ld.id {q}) + ifnull((ld.OB_DR),0)-ifnull((ld.OB_CR),0) as Bal_
From TBL_PayHead ld
where ld.Visible = 'Approval' and ld.[Under] = '{r("ID")}'
 "


            cmd = New SQLiteCommand(Qry, cn1)
            r1 = cmd.ExecuteReader
            'My.Computer.Clipboard.SetText(cmd.CommandText)

            While r1.Read
                Dim vlu As Decimal = Val(r1("Bal_"))
                If Val(vlu) <> 0 Then
                    dt_.Rows.Add(r1("ID"), r1("Name"), vlu, "Under", r1("Type").ToString)
                End If
            End While

            If r("Head") = "Liabilities" Then
                Pass_Data_(True, r("ID"), r("Name").ToString, dt_, "Account Group")
            ElseIf r("Head") = "Assets" Then
                Pass_Data_(False, r("ID"), r("Name").ToString, dt_, "Account Group")
            End If

        End While
    End Function

    Public Function Stock_Data_(cn As SQLiteConnection, dat As Date, frm_ As Date, to_ As Date) As Decimal
        'Dim to_ As Date = dat.AddDays(1)

        Dim Branch_Filter As String = ""
        If Dft_Branch <> "Primary" Then
            Branch_Filter = " AND VC.Branch = '" & Find_DT_Value(Database_File.cre, "TBL_Ledger", "ID", "Name = '" & Dft_Branch & "'") & "'"
        End If


        Dim Qry As String = $" Select 
ifnull(ifnull((SELECT ifnull(SUM(vi.Qty) ,0)
From TBL_VC_item_Details vi
LEFT JOIN TBL_VC vc on vc.Tra_ID = vi.Tra_ID

where (vi.Type = 'Credit' and vc.Effect_Stock = 'Yes' and vc.Type = 'Head') and vi.Item = it.Id and vc.Visible = 'Approval' and (vc.[Date] <= '{dat.AddDays(1).ToString(Lite_date_Format)}'){Branch_Filter}) -
(SELECT ifnull(SUM(vi.Qty) ,0)
From TBL_VC_item_Details vi
LEFT JOIN TBL_VC vc on vc.Tra_ID = vi.Tra_ID

where (vi.Type = 'Debit' and vc.Effect_Stock = 'Yes' and vc.Type = 'Head') and vi.Item = it.Id and vc.Visible = 'Approval' and (vc.[Date] <= '{dat.AddDays(1).ToString(Lite_date_Format)}'){Branch_Filter}),0) + (Select ifnull(sum(ios.Stock),0) From TBL_Stock_Item_Opning_Stock ios where ios.Item_ID = it.id),0) as Qty ,

ifnull((Case WHEN ('{Dft_Valuation}' = 'At Zero Price' or ('{Dft_Valuation}' = 'Default' and it.Costing_Value_Type = 'At Zero Price')) THEN
'0'
else (Case WHEN ('{Dft_Valuation}' = 'Avg. Cost (as per period)' or ('{Dft_Valuation}' = 'Default' and it.Costing_Value_Type = 'Avg. Cost (as per period)')) THEN
(SELECT ifnull(ifnull(SUM(vi.Amount) ,0) / ifnull(ifnull(SUM(vi.Qty),0),0),0) From TBL_VC_item_Details vi where (vi.Type = 'Credit') and vi.Item = it.Id and (vi.Date BETWEEN '{CDate(frm_).ToString(Lite_date_Format)}' and '{CDate(to_).AddDays(1).ToString(Lite_date_Format) }'){Branch_Filter})

else (Case WHEN ('{Dft_Valuation}' = 'Avg. Price (as per period)' or ('{Dft_Valuation}' = 'Default' and it.Costing_Value_Type = 'Avg. Price (as per period)')) THEN
(SELECT ifnull(ifnull(SUM(vi.Amount) ,0) / ifnull(ifnull(SUM(vi.Qty),0),0),0) From TBL_VC_item_Details vi where (vi.Type = 'Debit') and vi.Item = it.Id and (vi.Date BETWEEN '{CDate(frm_).ToString(Lite_date_Format)}' and '{CDate(to_).AddDays(1).ToString(Lite_date_Format) }'){Branch_Filter})


else (Case WHEN ('{Dft_Valuation}' = 'Last Sales Price' or ('{Dft_Valuation}' = 'Default' and it.Costing_Value_Type = 'Last Sales Price')) THEN
(SELECT ifnull(vi.Rate ,0) From TBL_VC_item_Details vi LEFT JOIN TBL_VC vc on vc.Tra_ID = vi.Tra_ID where vc.Voucher_Type = 'Sales' and vi.Item = it.Id and vc.Visible = 'Approval' and (vc.[Date] <= '{dat.AddDays(1).ToString(Lite_date_Format)}'){Branch_Filter} ORDER by vc.[date] DESC LIMIT 1)

else (Case WHEN ('{Dft_Valuation}' = 'Last Purchase Cost' or ('{Dft_Valuation}' = 'Default' and it.Costing_Value_Type = 'Last Purchase Cost')) THEN
(SELECT ifnull(vi.Rate ,0) From TBL_VC_item_Details vi LEFT JOIN TBL_VC vc on vc.Tra_ID = vi.Tra_ID where vc.Voucher_Type = 'Purchase' and vi.Item = it.Id and vc.Visible = 'Approval' and (vc.[Date] <= '{dat.AddDays(1).ToString(Lite_date_Format)}'){Branch_Filter} ORDER by vc.[date] DESC LIMIT 1)

else (Case WHEN ('{Dft_Valuation}' = 'Std. Cost' or ('{Dft_Valuation}' = 'Default' and it.Costing_Value_Type = 'Std. Cost')) THEN
(SELECT ifnull((std.Rate) ,0) From TBL_Item_Rate std where std.Item = it.id and std.Type = 'Cost' and ([Date] <= '{dat.AddDays(1).ToString(Lite_date_Format)}') ORDER BY [Date] DESC LIMIT 1)

else (Case WHEN ('{Dft_Valuation}' = 'Std. Price' or ('{Dft_Valuation}' = 'Default' and it.Costing_Value_Type = 'Std. Price')) THEN
(SELECT ifnull((std.Rate) ,0) From TBL_Item_Rate std where std.Item = it.id and std.Type = 'Price' and ([Date] <= '{dat.AddDays(1).ToString(Lite_date_Format)}') ORDER BY [Date] DESC LIMIT 1)

else (Case WHEN ('{Dft_Valuation}' = 'Basic Purchase Rate' or ('{Dft_Valuation}' = 'Default' and it.Costing_Value_Type = 'Basic Purchase Rate')) THEN
ifnull(it.Purchase_Rate,0)

else (Case WHEN ('{Dft_Valuation}' = 'Basic Sales Rate' or ('{Dft_Valuation}' = 'Default' and it.Costing_Value_Type = 'Basic Sales Rate')) THEN
ifnull(it.Sales_Rate,0)

end)
end)
end)
end)
end)
end)
end)
end)
end),0) vlu

From TBL_Stock_Item it WHERE it.Visible = 'Approval'"


        cmd = New SQLiteCommand(Qry, cn)
        Dim r As SQLiteDataReader = cmd.ExecuteReader

        Dim vlu As Decimal = 0.00


        While r.Read
            vlu += (Val(r("Qty").ToString) * Val(r("Vlu").ToString))
        End While

        Return vlu
    End Function

    Private Function Pass_Data_(isLiabilities As Boolean, id As String, Head_Name As String, dt As DataTable, type_s As String) As TextBox
        'Dim Total_ As Decimal = Val(dt.AsEnumerable().Sum(Function(row)
        '                                                      Return row.Field(Of String)("Vlu")
        '                                                  End Function))
        Dim Total_ As Decimal = 0

        For Each ro As DataRow In dt.Rows
            Total_ += Val(ro("Vlu").ToString)
        Next

        If isLiabilities = True Then
            If Total_ <= 0 Then
                Grid1.Rows.Add("Head", Head_Name, "", N2_FORMATE(Total_ * -1), type_s, id)
                Total_L.Text = nUmBeR_FORMATE(Total_L.Text) + (Total_ * -1)

                If Focus_String = Head_Name Then
                    Focus_String = Grid1.RowCount
                    Get_Focus(Grid1)
                End If

                For Each ro As DataRow In dt.Rows
                    Dim typ As String
                    If ro(3).ToString = "Under_Group" Then
                        typ = "UnderGroup"
                    Else
                        typ = "Under"
                    End If
                    If YN_Details = True Then
                        Grid1.Rows.Add(typ, ro(1).ToString, N2_FORMATE(Val(ro(2).ToString) * -1), "", ro(4).ToString, ro(0).ToString)
                        If Focus_String = ro(1).ToString Then
                            Focus_String = Grid1.RowCount
                            Get_Focus(Grid1)
                        End If
                    End If
                Next
            Else
                Grid2.Rows.Add("Head", Head_Name, "", N2_FORMATE(Total_), type_s, id)
                Total_A.Text = nUmBeR_FORMATE(Total_A.Text) + (Total_)

                If Focus_String = Head_Name Then
                    Focus_String = Grid2.RowCount
                    Get_Focus(Grid2)
                End If

                For Each ro As DataRow In dt.Rows
                    Dim typ As String
                    If ro(3).ToString = "Under_Group" Then
                        typ = "UnderGroup"
                    Else
                        typ = "Under"
                    End If
                    If YN_Details = True Then
                        Grid2.Rows.Add(typ, ro(1).ToString, N2_FORMATE(Val(ro(2).ToString)), "", ro(4).ToString, ro(0).ToString)

                        If Focus_String = ro(1).ToString Then
                            Focus_String = Grid2.RowCount
                            Get_Focus(Grid2)
                        End If
                    End If
                Next
            End If
        ElseIf isLiabilities = False Then
            If Total_ >= 0 Then
                Grid2.Rows.Add("Head", Head_Name, "", N2_FORMATE(Total_), type_s, id)
                Total_A.Text = nUmBeR_FORMATE(Total_A.Text) + (Total_)

                If Focus_String = Head_Name Then
                    Focus_String = Grid2.RowCount
                    Get_Focus(Grid2)
                End If
                For Each ro As DataRow In dt.Rows
                    Dim typ As String
                    If ro(3).ToString = "Under_Group" Then
                        typ = "UnderGroup"
                    Else
                        typ = "Under"
                    End If
                    If YN_Details = True Then
                        Grid2.Rows.Add(typ, ro(1).ToString, N2_FORMATE(Val(ro(2).ToString)), "", ro(4).ToString, ro(0).ToString)
                        If Focus_String = ro(1).ToString Then
                            Focus_String = Grid2.RowCount
                            Get_Focus(Grid2)
                        End If
                    End If
                Next
            Else
                Grid1.Rows.Add("Head", Head_Name, "", N2_FORMATE(Total_ * -1), type_s, id)
                Total_L.Text = nUmBeR_FORMATE(Total_L.Text) + (Total_ * -1)

                If Focus_String = Head_Name Then
                    Focus_String = Grid1.RowCount
                    Get_Focus(Grid1)
                End If
                For Each ro As DataRow In dt.Rows
                    Dim typ As String
                    If ro(3).ToString = "Under_Group" Then
                        typ = "UnderGroup"
                    Else
                        typ = "Under"
                    End If
                    If YN_Details = True Then
                        Grid1.Rows.Add(typ, ro(1).ToString, N2_FORMATE(Val(ro(2).ToString) * -1), "", ro(4).ToString, ro(0).ToString)

                        If Focus_String = ro(1).ToString Then
                            Focus_String = Grid1.RowCount
                            Get_Focus(Grid1)
                        End If
                    End If
                Next

            End If
        End If
    End Function


    Private Sub Frm_Date_LB_TextChanged(sender As Object, e As EventArgs) Handles Frm_Date_LB.TextChanged
        Frm_date = Frm_Date_LB.Text
    End Sub
    Private Sub To_Date_LB_TextChanged(sender As Object, e As EventArgs) Handles To_Date_LB.TextChanged
        to_date = To_Date_LB.Text
    End Sub

    Private Sub Balance_Sheet_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        Add_Hander_Remove_Handel(False)
        BG_frm.BG_Path_TXT.Text = Path_End
        Frm_foCus()
    End Sub
    Private Sub Grid1_Enter(sender As Object, e As EventArgs)
        sender.DefaultCellStyle.SelectionBackColor = Color.FromArgb(254, 197, 48)
    End Sub

    Private Sub Grid4_LostFocus(sender As Object, e As EventArgs)
        sender.DefaultCellStyle.SelectionBackColor = Color.White
    End Sub

    Private Sub Balance_Sheet_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
        Current_Grid.Focus()
    End Sub

    Private Sub Grid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid1.CellContentClick

    End Sub

    Private Function Get_Focus(Grid As DataGridView)
        Grid1.DefaultCellStyle.SelectionBackColor = Color.White
        Grid2.DefaultCellStyle.SelectionBackColor = Color.White

        Grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(254, 197, 48)

        Current_Grid = Grid
    End Function

    Private Sub Grid1_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles Grid1.RowPrePaint, Grid2.RowPrePaint
        Dim ro As DataGridViewRow = sender.Rows(e.RowIndex)
        ro.Cells(2).Style.Font = New Font("Arial", 10, FontStyle.Italic)


        If ro.Cells(0).Value = "Head" Then
            ro.DefaultCellStyle.Font = New Font("Arial", 9.75!, FontStyle.Bold)
        ElseIf ro.Cells(0).Value = "UnderGroup" Then
            ro.DefaultCellStyle.Font = New Font("Arial", 9.75!, FontStyle.Bold Or FontStyle.Italic)
            ro.Cells(1).Style.Padding = New Padding(25, 0, 0, 0)
        ElseIf ro.Cells(0).Value = "Under" Then
            ro.DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Regular)
            ro.Cells(1).Style.Padding = New Padding(25, 0, 0, 0)
        End If
    End Sub

    Private Sub Grid1_GotFocus(sender As Object, e As EventArgs) Handles Grid1.GotFocus, Grid2.GotFocus
        Get_Focus(sender)
    End Sub

    Private Sub Grid1_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid1.KeyDown, Grid2.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim ro As DataGridViewRow = sender.CurrentRow
            Dim ID_ As String = ro.Cells(5).Value
            If ro.Cells(4).Value = "Account Group" Then
                Cell("Group Summary", "", "Display", ID_)
                Report_Group_Summary_frm.YN_Opning_Balance = True
                Report_Group_Summary_frm.Fill_Grid()
            ElseIf ro.Cells(4).Value = "Account Ledger" Then
                Cell("Report Ledger", "", "Display", ID_, Frm_date, to_date)
            ElseIf ro.Cells(4).Value = "Profit&Loss" Then
                Cell("Profit & Loss Account", "", "Display", "", "", "")
            ElseIf ro.Cells(4).Value = "Closing_Stock" Then
                Cell("Group Stock Summary", "", "", "", "")
                Stock_Group_Summary_frm.To_Date_LB.Text = to_date
                Stock_Group_Summary_frm.Fill_Grid()
            ElseIf ro.Cells(4).Value = "Payhead" Then
                Cell("Payroll Vouchers", 0, ID_)
            End If
            e.Handled = True
        End If
    End Sub
End Class