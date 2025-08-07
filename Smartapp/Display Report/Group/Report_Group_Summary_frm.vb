Imports System.Data.SqlClient
Imports System.Data.SQLite
Imports Microsoft.Reporting.WinForms
Imports MS.Internal.Text.TextInterface
Imports PopupControl

Public Class Report_Group_Summary_frm
    Dim From_ID As String
    Private VC_Type_ As String
    Private VC_ID_ As String
    Private Path_End As String
    Public YN_Opning_Balance As Boolean = True
    Public YN_Percentage As Boolean = False
    Dim Acc_Under As String
    Dim Frm_date As Date
    Dim to_date As Date

    Public Voucher_Type As String = "All Vouchers"

    Dim ds_print As New Print_dt
    Dim dt_print As New DataTable

    Dim Defolt_Select_ID As String = 0
    Public Property Active_ctrl As Control
    Private Sub Report_Group_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Path_End = BG_frm.BG_Path_TXT.Text
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        VC_Type_ = Link_Valu(1)
        VC_ID_ = Link_Valu(2)


        Frm_Date_LB.Text = Date_Formate(Date_1)
        To_Date_LB.Text = Date_Formate(Date_2)



        BG_frm.HADE_TXT.Text = "Group Summary"
        BG_frm.TYP_TXT.Text = VC_Type_
        Button_Manage()
        Add_Hander_Remove_Handel(True)

    End Sub
    Private Function Button_Manage()
        Button_Clear()
        BG_frm.R_2.Text = "F2 : Date"
        BG_frm.R_3.Text = "|F2 : Period"
        If Branch_Visible() = True Then
            BG_frm.R_4.Text = "F4 : Branch"
        End If
        BG_frm.B_1.Text = "|&P : Print"
        'BG_frm.R_22.Text = "F12 : Configuration"
    End Function
    Private Function Add_Hander_Remove_Handel(Ans As Boolean)
        If Ans = True Then
            AddHandler BG_frm.KeyDown, AddressOf Me.BG_Keydown
            AddHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            AddHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click

            AddHandler BG_frm.R_2.Click, AddressOf Me.R_2_Click
            AddHandler BG_frm.R_3.Click, AddressOf Me.R_3_Click
            If Branch_Visible() = True Then
                AddHandler BG_frm.R_4.Click, AddressOf Me.R_4_Click
            End If
            AddHandler BG_frm.R_22.Click, AddressOf Me.R_22_Click
        Else
            RemoveHandler BG_frm.KeyDown, AddressOf Me.BG_Keydown
            RemoveHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            RemoveHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click

            RemoveHandler BG_frm.R_2.Click, AddressOf Me.R_2_Click
            RemoveHandler BG_frm.R_3.Click, AddressOf Me.R_3_Click
            If Branch_Visible() = True Then
                RemoveHandler BG_frm.R_4.Click, AddressOf Me.R_4_Click
            End If
            RemoveHandler BG_frm.R_22.Click, AddressOf Me.R_22_Click
        End If
    End Function
    Private Sub BG_Keydown(sender As Object, e As KeyEventArgs)
        If BG_frm.From_ID = From_ID Then
            If e.KeyCode = Keys.F2 AndAlso e.Modifiers = Keys.Alt Then
                BG_frm.R_3.PerformClick()
            ElseIf e.KeyCode = Keys.F2 Then
                BG_frm.R_2.PerformClick()
            End If
            If e.KeyCode = Keys.F4 AndAlso e.Modifiers = Keys.Alt Then

            ElseIf e.KeyCode = Keys.F4 Then
                BG_frm.R_4.PerformClick()
            End If
            If e.KeyCode = Keys.F5 AndAlso e.Modifiers = Keys.Alt Then

            ElseIf e.KeyCode = Keys.F5 Then
                BG_frm.R_5.PerformClick()
            End If

            If e.KeyCode = Keys.F12 Then
                BG_frm.R_22.PerformClick()
            End If
            If e.KeyCode = Keys.F AndAlso e.Modifiers = Keys.Control Then
                BG_frm.R_5.PerformClick()
            End If
        End If
    End Sub
    Private Sub B_1_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Print_Data()
        End If
    End Sub
    Dim cfg_print_path As String
    Dim rdlc_report_name As String
    Dim rdlc_report_data() As ReportDataSource
    Private Function Print_Data()
        Dim ds_print As New Print_dt
        Dim D1 As New DataTable

        D1.Rows.Clear()
        D1 = ds_print.Tables("TBL_Account_Group")

        For Each ro As DataGridViewRow In Grid1.Rows
            With ro
                D1.Rows.Add(.Cells(1).Value, .Cells(2).Value, .Cells(3).Value, .Cells(4).Value)
            End With
        Next


        Print_data_fill(D1)
        Printing_Direct_frm.Printing_(cfg_print_path, rdlc_report_name, "", rdlc_report_data)
    End Function
    Private Function Print_data_fill(d1 As DataTable)

        cfg_print_path = Application.StartupPath & "\Print_\Report\Account_Group\Account_Group"

        rdlc_report_name = $"{Acc_LB.Text} ({Frm_date.ToString("dd-MMM-yyyy")} to {to_date.ToString("dd-MMM-yyyy")})"
        rdlc_report_name = path_validation(rdlc_report_name, "-")

        rdlc_report_data = {New ReportDataSource("dt_list", d1),
            New ReportDataSource("dt_cmp", Print_DT_Company)}


    End Function
    Private Function Enter_()

        If Grid1.CurrentRow.Cells(0).Value = "Head" Then
            If Grid1.CurrentRow.Cells(7).Value = "Stock" Then
                Cell("Group Stock Summary", "", "", "", "")
                Stock_Group_Summary_frm.Frm_Date_LB.Text = Frm_date
                Stock_Group_Summary_frm.To_Date_LB.Text = to_date
                Stock_Group_Summary_frm.Fill_Grid()
            ElseIf Grid1.CurrentRow.Cells(7).Value = "Group" Then
                'VC_ID_ = Grid1.CurrentRow.Cells(6).Value
                'Fill_Grid()
                Dim Frm As Object = Cell("Group Summary", "", "Display", Grid1.CurrentRow.Cells(6).Value)
                With Frm
                    .YN_Opning_Balance = True
                    .Fill_Grid()
                End With
            End If
        Else
            If Grid1.CurrentRow.Cells(7).Value = "Account" Then
                'Cell("Report Ledger", "", "Display", Grid1.CurrentRow.Cells(6).Value, Frm_date, to_date, Branch_ID)

                Dim YYear As FirstWeekOfYear = Date_2.ToString("yyyy")
                Cell("Report Ledger Monthly", "", "Display", Grid1.CurrentRow.Cells(6).Value, CDate("01-04-" & YYear).ToString("dd-MM-yyyy"), CDate("31-03-" & YYear + 1).ToString("dd-MM-yyyy"), Dft_Voucher, Dft_Branch, CDate(to_date).ToString("dd-MM-yyyy"))
            ElseIf Grid1.CurrentRow.Cells(7).Value = "Payroll" Then
                Cell("Payroll Vouchers", 0, Grid1.CurrentRow.Cells(6).Value)
            End If
        End If
    End Function
    Private Sub B_2_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Fill_Grid()
        End If
    End Sub

    Private Sub R_2_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Set_Date(False, Me)
        End If
    End Sub

    Private Sub R_3_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Set_Date(True, Me)
        End If
    End Sub
    Private Sub R_4_Click(sender As Object, e As EventArgs)
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
    Private Sub R_22_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Dim pop As Popup
            Dim Audit_cfg_pop As Object

            Audit_cfg_pop = New Report_Group_Summary_cfg
            pop = New Popup(Audit_cfg_pop)

            pop.FocusOnOpen = True

            pop.AnimationDuration = 1
            pop.Show(sender)
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
    Private Sub Report_Group_Summary_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.HADE_TXT.Text = "Group Summary"
        BG_frm.TYP_TXT.Text = VC_Type_

        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text
        Button_Clear()
        Button_Manage()

        Acc_LB.Text = Find_DT_Value(Database_File.cre, "TBL_Acc_Group", "Name", "ID = '" & VC_ID_.Trim & "'")

        Config_Fill()

        Fill_Grid()
    End Sub

    Private Sub Report_Group_Summary_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub
    Dim Cr_Total As Decimal = 0
    Dim Dr_Total As Decimal = 0
    Dim Cr_Ob_Total As Decimal = 0
    Dim Dr_Ob_Total As Decimal = 0
    Dim dt As New DataTable
    Dim Date_Filter As String
    Public Function Fill_Grid()
        If Grid1.Rows.Count <> 0 Then
            Try
                Defolt_Select_ID = Grid1.CurrentRow.Cells("Focus_String").Value.ToString
            Catch ex As Exception

            End Try
        End If


        Dim Positive As String = Find_DT_Value(Database_File.cmp, "TBL_Features", "Value", "Head = 'Positive Value'")
        Dim Negative As String = Find_DT_Value(Database_File.cmp, "TBL_Features", "Value", "Head = 'Negative Value'")


        Acc_LB.Text = Find_DT_Value(Database_File.cre, "TBL_Acc_Group", "Name", "ID = '" & VC_ID_ & "'")
        Acc_Under = Find_DT_Value(Database_File.cre, "TBL_Acc_Group", "ID", "Name = '" & VC_ID_ & "'")

        Cr_Total = 0
        Dr_Total = 0


        dt.Clear()
        dt.Columns.Clear()
        dt.Reset()
        dt = New DataTable
        dt.Columns.Add("Type")
        dt.Columns.Add("Particulars")
        dt.Columns.Add("Opning")
        dt.Columns.Add("Debit")
        dt.Columns.Add("Credit")
        dt.Columns.Add("Closing")
        dt.Columns.Add("ID")
        dt.Columns.Add("Group")
        dt.Columns.Add("Focus_String")
        'dt.Columns.Add(" ")

        OB_TO = 0.00
        Cr_TO = 0.00
        Dr_TO = 0.00
        CL_TO = 0.00

        Fill_oTher_Group(dt, 0)

        If Val(OB_TO) > 0 Then
            OB_LB.Text = $"{N2_FORMATE(OB_TO)} {Positive}"
        Else
            OB_LB.Text = $"{N2_FORMATE(Val(OB_TO) * -1)} {Negative}"
        End If

        If Val(Dr_TO) > 0 Then
            DR_LB.Text = $"{N2_FORMATE(Dr_TO)}"
        Else
            DR_LB.Text = $"{N2_FORMATE(Val(Dr_TO) * -1)}"
        End If

        If Val(Cr_TO) > 0 Then
            CR_LB.Text = $"{N2_FORMATE(Cr_TO)}"
        Else
            CR_LB.Text = $"{N2_FORMATE(Val(Cr_TO) * -1)}"
        End If

        If Val(CL_TO) > 0 Then
            CL_LB.Text = $"{N2_FORMATE(CL_TO)} {Positive}"
        Else
            CL_LB.Text = $"{N2_FORMATE(Val(CL_TO) * -1)} {Negative}"
        End If


        Dim dv As New DataView(dt)
        Dim Dt_set As New DataTable

        Source_.DataSource = dv
        Grid1.DataSource = Source_

        Grid1.DataSource = dv

        Grid1.Columns(0).Visible = False
        Grid1.Columns(1).Visible = True
        Grid1.Columns(2).Visible = True
        Grid1.Columns(3).Visible = True
        Grid1.Columns(6).Visible = False
        Grid1.Columns(7).Visible = False
        Grid1.Columns("Focus_String").Visible = False


        Panel8.Visible = YN_Opning_Balance
        Panel10.Visible = YN_Opning_Balance

        If YN_Opning_Balance = True Then
            Grid1.Columns(2).Visible = True
            OB_LB.Visible = True
        Else
            Grid1.Columns(2).Visible = False
            OB_LB.Visible = False
        End If

        With Grid1.Columns(1)
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .DefaultCellStyle.Font = New Font("Arial", 9.75, FontStyle.Bold)
        End With

        With Grid1.Columns(2)
            .Width = Label6.Width
            .DefaultCellStyle.Font = New Font("Arial", 9.75, FontStyle.Bold)
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        With Grid1.Columns(3)
            .Width = Label11.Width
            .DefaultCellStyle.Font = New Font("Arial", 9.75, FontStyle.Bold)
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        With Grid1.Columns(4)
            .Width = Label10.Width
            .DefaultCellStyle.Font = New Font("Arial", 9.75, FontStyle.Bold)
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        With Grid1.Columns(5)
            .Width = Panel8.Width
            .DefaultCellStyle.Font = New Font("Arial", 9.75, FontStyle.Bold)
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With



        OB_LB.Width = Label6.Width
        DR_LB.Width = Label11.Width
        CR_LB.Width = Label10.Width
        CL_LB.Width = Label5.Width

        Border_()

        If Grid1.Rows.Count >= 1 Then
            Grid1.CurrentCell = Grid1.Rows(0).Cells(1)
        End If

        If Val(Defolt_Select_ID) <= Grid1.Rows.Count - 1 Then
            Grid1.CurrentCell = Grid1.Rows(Val(Defolt_Select_ID)).Cells(1)
        End If
        Grid1.Focus()
    End Function
    Dim OB_TO As Decimal = 0.00
    Dim Cr_TO As Decimal = 0.00
    Dim Dr_TO As Decimal = 0.00
    Dim CL_TO As Decimal = 0.00
    Private Function Stock_data_Fill(cn As SQLiteConnection)
        Dim crueent As String = Val(Stock_Data_(cn, to_date, Frm_date, to_date)) * -1
        'NET_TO += Val(crueent)
        CL_TO += Val(crueent)
        If Val(crueent) < 0 Then
            crueent = $"{N2_FORMATE(Val(crueent) * -1)} {Negative_Value_fech}"
        Else
            crueent = $"{N2_FORMATE(crueent)} {Positive_Value_fech}"
        End If

        dt.Rows.Add("Head", "Stock-in-Hand", "", "", "", crueent, "", "Stock", $"Stock")
        If Defolt_Select_ID = $"Stock" Then
            Defolt_Select_ID = dt.Rows.Count - 1
        End If
    End Function
    Private Function Fill_oTher_Group(dt As DataTable, Closing_ As String)


        Dim Positive As String = Positive_Value_fech
        Dim Negative As String = Negative_Value_fech



        Dim Date_Filter_Curr = " and (vc.Date BETWEEN '" & CDate(Frm_date).ToString(Lite_date_Format) & "' and '" & CDate(to_date).AddDays(1).ToString(Lite_date_Format) & "')"
        Dim Date_Filter_OB = "and (vc.Date < '" & CDate(Frm_date).AddDays(0).ToString(Lite_date_Format) & "')"


        Dim cn As New SQLiteConnection
        open_MSSQL_Cstm(Database_File.cre, cn)
        If VC_ID_ = 6 Then
            Stock_data_Fill(cn)
        End If

        Dim Qry As String = $"Select * From TBL_Acc_Group ag where ag.[ID] = '{VC_ID_}' and ag.Visible = 'Approval'"
        cmd = New SQLiteCommand(Qry, cn)
        Dim r As SQLiteDataReader = cmd.ExecuteReader()


        Dim q_ob As String = ""
        q_ob &= Date_Filter_OB
        Dim q As String = ""
        q &= Date_Filter_Curr

        Dim cn1 As New SQLiteConnection
        open_MSSQL_Cstm(Database_File.cre, cn1)
        While r.Read

            'Group_data

            Qry = $"Select id,Name,SUM(Opning) as Opning, SUM(Debit) as Debit, SUM(Credit) as Credit From(
Select ag.ID,ag.Name,
(Select (ifnull(SUM(vc.Cr),0) - ifnull(SUM(vc.Dr),0)) From TBL_VC_Ledger vc where ld.ID = vc.Ledger {q_ob})+(ifnull((lo.OB_CR),0)-ifnull((lo.OB_DR),0)) as Opning,
(Select (ifnull(SUM(vc.Dr),0)) From TBL_VC_Ledger vc where ld.ID = vc.Ledger {q}) as Debit,
(Select (ifnull(SUM(vc.Cr),0)) From TBL_VC_Ledger vc where ld.ID = vc.Ledger {q}) as Credit
From TBL_Ledger ld
LEFT JOIN TBL_Acc_Group ag on ag.ID = ld.[Group]
LEFT JOIN TBL_Ledger_Opning_Balance lo on lo.Ledger_ID = ld.ID

WHERE ag.[UserGroup] = '{r("ID")}')
Group By ID"


            cmd = New SQLiteCommand(Qry, cn1)
            Dim r1 As SQLiteDataReader = cmd.ExecuteReader
            'My.Computer.Clipboard.SetText(cmd.CommandText)
            While r1.Read

                Dim Op As String = Val(r1("Opning"))
                Dim Dr As String = Val(r1("Debit"))
                Dim Cr As String = Val(r1("Credit"))
                Dim cl As String = Val(Val(r1("Opning")) + Val(Val(Cr) - Val(Dr)))

                OB_TO += Val(r1("Opning"))
                Dr_TO += Val(r1("Debit"))
                Cr_TO += Val(r1("Credit"))
                CL_TO += Val(Val(r1("Opning")) + Val(Val(Cr) - Val(Dr)))

                If Val(r1("Opning")) < 0 Then
                    Op = $"{N2_FORMATE(Val(Op) * -1)} {Negative}"
                Else
                    Op = $"{N2_FORMATE(Op)} {Positive}"
                End If

                If Val(r1("Debit")) < 0 Then
                    Dr = $"{N2_FORMATE(Val(Dr) * -1)}"
                Else
                    Dr = $"{N2_FORMATE(Dr)}"
                End If

                If Val(r1("Credit")) < 0 Then
                    Cr = $"{N2_FORMATE(Val(Cr) * -1)}"
                Else
                    Cr = $"{N2_FORMATE(Cr)}"
                End If

                If Val(Val(r1("Opning")) + Val(Val(Cr) - Val(Dr))) < 0 Then
                    cl = $"{N2_FORMATE(Val(cl) * -1)} {Negative}"
                Else
                    cl = $"{N2_FORMATE(cl)} {Positive}"
                End If

                If r1("ID").ToString <> "23" Then
                    dt.Rows.Add("Head", r1("Name"), Op, Dr, Cr, cl, r1("ID").ToString, "Group", $"Group_{r1("ID").ToString}")

                    If Defolt_Select_ID = $"Group_{r1("ID").ToString}" Then
                        Defolt_Select_ID = dt.Rows.Count - 1
                    End If
                Else

                End If
            End While

            Qry = $"Select 'Account' as Type,ld.ID,ld.name,
(Select (ifnull(SUM(vc.Cr),0) - ifnull(SUM(vc.Dr),0)) From TBL_VC_Ledger vc where vc.Ledger = ld.id {q_ob})+(ifnull((lo.OB_CR),0)-ifnull((lo.OB_DR),0)) as Opning,
(Select (ifnull(SUM(vc.Dr),0)) From TBL_VC_Ledger vc where vc.Ledger = ld.id {q}) as Debit,
(Select (ifnull(SUM(vc.Cr),0)) From TBL_VC_Ledger vc where vc.Ledger = ld.id {q}) as Credit
 From TBL_Ledger ld
 LEFT JOIN TBL_Ledger_Opning_Balance lo on lo.Ledger_ID = ld.ID
 where ld.[Group] = '{r("ID")}'
 
 UNION ALL

 Select 'Payroll' as Type,phd.ID,phd.Name,
(Select (ifnull(SUM(vc.Cr),0) - ifnull(SUM(vc.Dr),0)) From TBL_VC_Payroll vc where vc.Payhead = phd.id {q_ob})+(ifnull((phd.OB_CR),0)-ifnull((phd.OB_DR),0)) as Opning,
(Select (ifnull(SUM(vc.Dr),0)) From TBL_VC_Payroll vc where vc.Payhead = phd.id  {q}) as Debit,
(Select (ifnull(SUM(vc.Cr),0)) From TBL_VC_Payroll vc where vc.Payhead = phd.id  {q}) as Credit

From TBL_PayHead phd
WHERE phd.[Under] = '{r("ID")}'
 
 "


            cmd = New SQLiteCommand(Qry, cn1)
            r1 = cmd.ExecuteReader
            'My.Computer.Clipboard.SetText(cmd.CommandText)
            While r1.Read
                Dim Op As String = Val(r1("Opning"))
                Dim Dr As String = Val(r1("Debit"))
                Dim Cr As String = Val(r1("Credit"))
                Dim cl As String = Val(Val(r1("Opning")) + Val(Val(Cr) - Val(Dr)))

                OB_TO += Val(r1("Opning"))
                Dr_TO += Val(r1("Debit"))
                Cr_TO += Val(r1("Credit"))
                CL_TO += Val(Val(r1("Opning")) + Val(Val(Cr) - Val(Dr)))


                If Val(r1("Opning")) < 0 Then
                    Op = $"{N2_FORMATE(Val(Op) * -1)} {Negative}"
                Else
                    Op = $"{N2_FORMATE(Op)} {Positive}"
                End If

                If Val(r1("Debit")) < 0 Then
                    Dr = $"{N2_FORMATE(Val(Dr) * -1)}"
                Else
                    Dr = $"{N2_FORMATE(Dr)}"
                End If

                If Val(r1("Credit")) < 0 Then
                    Cr = $"{N2_FORMATE(Val(Cr) * -1)}"
                Else
                    Cr = $"{N2_FORMATE(Cr)}"
                End If

                If Val(Val(r1("Opning")) + Val(Val(Cr) - Val(Dr))) < 0 Then
                    cl = $"{N2_FORMATE(Val(cl) * -1)} {Negative}"
                Else
                    cl = $"{N2_FORMATE(cl)} {Positive}"
                End If

                dt.Rows.Add("Under", r1("Name"), Op, Dr, Cr, cl, r1("ID"), r1("Type").ToString, $"{r1("Type").ToString}_{r1("ID").ToString}")
                If Defolt_Select_ID = $"{r1("Type").ToString}_{r1("ID").ToString}" Then
                    Defolt_Select_ID = dt.Rows.Count - 1
                End If
            End While

        End While

    End Function
    Public Function Stock_Data_(cn As SQLiteConnection, dat As Date, frm_ As Date, to_ As Date) As Decimal
        Dim vlu As Decimal = 0.00

        Try
            Dim Qry As String = $" Select 
ifnull(ifnull((SELECT ifnull(SUM(vi.Qty) ,0)
From TBL_VC_item_Details vi
LEFT JOIN TBL_VC vc on vc.Tra_ID = vi.Tra_ID

where (vi.Type = 'Credit' and vc.Effect_Stock = 'Yes') and vi.Item = it.Id and vc.Visible = 'Approval' and (vc.[Date] <= '{dat.AddDays(1).ToString(Lite_date_Format)}')) -
(SELECT ifnull(SUM(vi.Qty) ,0)
From TBL_VC_item_Details vi
LEFT JOIN TBL_VC vc on vc.Tra_ID = vi.Tra_ID

where (vi.Type = 'Debit' and vc.Effect_Stock = 'Yes') and vi.Item = it.Id and vc.Visible = 'Approval' and (vc.[Date] <= '{dat.AddDays(1).ToString(Lite_date_Format)}')),0) + (Select ifnull(sum(ios.Stock),0) From TBL_Stock_Item_Opning_Stock ios where ios.Item_ID = it.id),0) as Qty ,

ifnull((Case WHEN ('{Dft_Valuation}' = 'At Zero Price' or ('{Dft_Valuation}' = 'Default' and it.Costing_Value_Type = 'At Zero Price')) THEN
'0'
else (Case WHEN ('{Dft_Valuation}' = 'Avg. Cost (as per period)' or ('{Dft_Valuation}' = 'Default' and it.Costing_Value_Type = 'Avg. Cost (as per period)')) THEN
(SELECT ifnull(ifnull(SUM(vi.Amount) ,0) / ifnull(ifnull(SUM(vi.Qty),0),0),0) From TBL_VC_item_Details vi where (vi.Type = 'Credit') and vi.Item = it.Id and (vi.Date BETWEEN '{CDate(frm_).ToString(Lite_date_Format)}' and '{CDate(to_).AddDays(1).ToString(Lite_date_Format) }'))

else (Case WHEN ('{Dft_Valuation}' = 'Avg. Price (as per period)' or ('{Dft_Valuation}' = 'Default' and it.Costing_Value_Type = 'Avg. Price (as per period)')) THEN
(SELECT ifnull(ifnull(SUM(vi.Amount) ,0) / ifnull(ifnull(SUM(vi.Qty),0),0),0) From TBL_VC_item_Details vi where (vi.Type = 'Debit') and vi.Item = it.Id and (vi.Date BETWEEN '{CDate(frm_).ToString(Lite_date_Format)}' and '{CDate(to_).AddDays(1).ToString(Lite_date_Format) }'))


else (Case WHEN ('{Dft_Valuation}' = 'Last Purchase Cost' or ('{Dft_Valuation}' = 'Default' and it.Costing_Value_Type = 'Last Purchase Cost')) THEN
(SELECT ifnull(vi.Rate ,0) From TBL_VC_item_Details vi LEFT JOIN TBL_VC vc on vc.Tra_ID = vi.Tra_ID where vc.Voucher_Type = 'Purchase' and vi.Item = it.Id and vc.Visible = 'Approval' and (vc.[Date] <= '{dat.AddDays(1).ToString(Lite_date_Format)}') ORDER by vc.[date] DESC LIMIT 1)

else (Case WHEN ('{Dft_Valuation}' = 'Last Sales Price' or ('{Dft_Valuation}' = 'Default' and it.Costing_Value_Type = 'Last Sales Price')) THEN
(SELECT ifnull(vi.Rate ,0) From TBL_VC_item_Details vi LEFT JOIN TBL_VC vc on vc.Tra_ID = vi.Tra_ID where vc.Voucher_Type = 'Sales' and vi.Item = it.Id and vc.Visible = 'Approval' and (vc.[Date] <= '{dat.AddDays(1).ToString(Lite_date_Format)}') ORDER by vc.[date] DESC LIMIT 1)

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



            While r.Read
                vlu += (Val(r("Qty").ToString) * Val(r("Vlu").ToString))
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



        Return vlu
    End Function
    Public Valuation As String = "Avg. Inward"
    Private Sub Report_Group_Summary_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        Add_Hander_Remove_Handel(False)
        BG_frm.BG_Path_TXT.Text = Path_End
        'Frm_foCus()
    End Sub

    Private Sub Grid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid1.CellContentClick

    End Sub
    Private Sub Grid1_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles Grid1.RowsAdded
        Grid1.Rows(Grid1.Rows.Count - 1).Height = 18
    End Sub
    Private Sub Frm_Date_LB_TextChanged(sender As Object, e As EventArgs) Handles Frm_Date_LB.TextChanged
        Frm_date = Frm_Date_LB.Text
    End Sub
    Private Sub To_Date_LB_TextChanged(sender As Object, e As EventArgs) Handles To_Date_LB.TextChanged
        to_date = To_Date_LB.Text
    End Sub

    Private Sub Frm_Date_LB_Click(sender As Object, e As EventArgs) Handles Frm_Date_LB.Click

    End Sub

    Private Sub Grid1_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid1.KeyDown
        If e.KeyCode = Keys.Enter Then
            'Defolt_Select_ID = Grid1.CurrentRow.Cells(1).Value.ToString
            Enter_()
            e.Handled = True
        End If
    End Sub
    Private Sub Grid1_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles Grid1.RowPrePaint
        Dim ro As DataGridViewRow = sender.Rows(e.RowIndex)
        If ro.Cells(0).Value = "Head" Then
            ro.DefaultCellStyle.Font = New Font("Arial", 9.75, FontStyle.Bold)
        Else
            ro.DefaultCellStyle.Padding = New Padding(0, 0, 0, 0)
            ro.DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Regular)
        End If

        ro.DefaultCellStyle.BackColor = Color.White

        If Val(ro.Cells(2).Value.ToString) = 0 Then
            ro.Cells(2).Style.SelectionBackColor = Color.FromArgb(254, 197, 48)
            ro.Cells(2).Style.ForeColor = Color.White
            ro.Cells(2).Style.SelectionForeColor = Color.FromArgb(254, 197, 48)
        End If
        If Val(ro.Cells(3).Value.ToString) = 0 Then
            ro.Cells(3).Style.SelectionBackColor = Color.FromArgb(254, 197, 48)
            ro.Cells(3).Style.ForeColor = Color.White
            ro.Cells(3).Style.SelectionForeColor = Color.FromArgb(254, 197, 48)
        End If
        If Val(ro.Cells(4).Value.ToString) = 0 Then
            ro.Cells(4).Style.SelectionBackColor = Color.FromArgb(254, 197, 48)
            ro.Cells(4).Style.ForeColor = Color.White
            ro.Cells(4).Style.SelectionForeColor = Color.FromArgb(254, 197, 48)
        End If
        If Val(ro.Cells(6).Value.ToString) = 0 Then
            ro.Cells(6).Style.SelectionBackColor = Color.FromArgb(254, 197, 48)
            ro.Cells(6).Style.ForeColor = Color.White
            ro.Cells(6).Style.SelectionForeColor = Color.FromArgb(254, 197, 48)
        End If

    End Sub
    Private Function Config_Fill()
        'If Find_DT_Value(Database_File.lnk, "TBL_Configurr", "Value", "Filter = 'Account Group Summary' AND Name = 'Show Opning Balance'") = "Yes" Then
        '    YN_Opning_Balance = True
        'Else
        '    YN_Opning_Balance = False
        'End If
        'If Find_DT_Value(Database_File.lnk, "TBL_Configurr", "Value", "Filter = 'Account Group Summary' AND Name = 'Show Closing Balance'") = "Yes" Then
        '    YN_Closing_Balance = True
        'Else
        '    YN_Closing_Balance = False
        'End If
        'If Find_DT_Value(Database_File.lnk, "TBL_Configurr", "Value", "Filter = 'Account Group Summary' AND Name = 'Show Percentages'") = "Yes" Then
        '    YN_Percentage = True
        'Else
        '    YN_Percentage = False
        'End If
    End Function

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        Border_()
    End Sub

    Private Function Border_()
        With Panel10
            Dim P As Panel = B1
            Dim ctlpos As Point = .PointToScreen(.DisplayRectangle.Location)
            P.Location = New Point(ctlpos.X, 0)
            P.Height = Me.Height
            P.Visible = .Visible
        End With
        With Panel4
            Dim P As Panel = B2
            Dim ctlpos As Point = .PointToScreen(.DisplayRectangle.Location)
            P.Location = New Point(ctlpos.X, 0)
            P.Height = Me.Height
            P.Visible = .Visible
        End With
        With Panel8
            Dim P As Panel = B3
            Dim ctlpos As Point = .PointToScreen(.DisplayRectangle.Location)
            P.Location = New Point(ctlpos.X, 0)
            P.Height = Me.Height
            P.Visible = .Visible
        End With


        With Label10
            Dim P As Panel = B1_1
            Dim ctlpos As Point = .PointToScreen(.DisplayRectangle.Location)
            P.Location = New Point(ctlpos.X, Panel12.Height)
            P.Height = Me.Height - Panel12.Height
            P.Visible = .Visible
        End With
    End Function
    Private Sub Report_Group_Summary_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
        Grid1.Focus()

        Try
            Active_ctrl.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Report_Group_Summary_frm_LostFocus(sender As Object, e As EventArgs) Handles Me.LostFocus
        Active_ctrl = Me.ActiveControl
    End Sub
End Class