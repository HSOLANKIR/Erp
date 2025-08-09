Imports System.Data.SqlClient
Imports System.Data.SQLite
Imports Microsoft.Reporting.WinForms
Imports PopupControl

Public Class Report_Stock_item_monthly_frm
    Dim From_ID As String
    Private VC_Type_ As String
    Private VC_ID_ As String
    Public Path_End As String
    Dim YN_Details As Boolean = False
    Dim Acc_Under As String
    Dim Frm_date As Date
    Dim to_date As Date
    Dim suggest_date As Date

    Dim ds_print As New Print_dt
    Dim dt_print As New DataTable
    Private Sub Report_Stock_item_monthly_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text

        VC_Type_ = Link_Valu(1)
        VC_ID_ = Link_Valu(2)

        suggest_date = CDate(Date_3)

        Frm_Date_LB.Text = Date_Formate(CDate(Date_1))
        To_Date_LB.Text = Date_Formate(CDate(Date_2))

        Try
            'Frm_Date_LB.Text = Date_Formate("01-04-" & CDate(Link_Valu(3)).AddMonths(-12).ToString("yyyy"))
            'To_Date_LB.Text = Date_Formate(CDate(Link_Valu(3)).AddMonths(0))
        Catch ex As Exception

        End Try


        BG_frm.HADE_TXT.Text = "Stock Item Monthly"
        BG_frm.TYP_TXT.Text = VC_Type_
        Update_Report = True

        Button_Manage()
        Add_Hander_Remove_Handel(True)
    End Sub
    Private Function Button_Manage()
        Button_Clear()
        BG_frm.R_1.Text = "|F1 : Detailed"
        BG_frm.R_2.Text = "|F2 : Period"
        'BG_frm.R_3.Text = "|F3 : Expiry Date Report"
        If Branch_Visible() = True Then
            BG_frm.R_5.Text = "F4 : Branch"
        End If

        BG_frm.R_6.Text = "F5 : Valuation"
        If Godown_YN = True Then
            BG_frm.R_7.Text = "F6 : Godown"
        End If

        BG_frm.B_1.Text = "|&P : Print"

    End Function
    Private Function Add_Hander_Remove_Handel(Ans As Boolean)
        If Ans = True Then
            AddHandler BG_frm.KeyDown, AddressOf Me.BG_Keydown
            AddHandler BG_frm.B_3.Click, AddressOf Me.B_3_Click

            AddHandler BG_frm.R_2.Click, AddressOf Me.R_2_Click
            AddHandler BG_frm.R_3.Click, AddressOf Me.R_3_Click

            If Branch_Visible() = True Then
                AddHandler BG_frm.R_5.Click, AddressOf Me.R_5_Click
            End If

            AddHandler BG_frm.R_6.Click, AddressOf Me.R_6_Click

            AddHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click

            If Godown_YN = True Then
                AddHandler BG_frm.R_7.Click, AddressOf Me.R_7_Click
            End If
        Else
            RemoveHandler BG_frm.KeyDown, AddressOf Me.BG_Keydown
            RemoveHandler BG_frm.B_3.Click, AddressOf Me.B_3_Click

            RemoveHandler BG_frm.R_3.Click, AddressOf Me.R_3_Click

            RemoveHandler BG_frm.R_2.Click, AddressOf Me.R_2_Click
            If Branch_Visible() = True Then
                RemoveHandler BG_frm.R_5.Click, AddressOf Me.R_5_Click
            End If

            RemoveHandler BG_frm.R_6.Click, AddressOf Me.R_6_Click
            RemoveHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click

            If Godown_YN = True Then
                RemoveHandler BG_frm.R_7.Click, AddressOf Me.R_7_Click
            End If
        End If
    End Function
    Private Sub BG_Keydown(sender As Object, e As KeyEventArgs)
        If BG_frm.HADE_TXT.Text = "Stock Item Monthly" Then
            If e.KeyCode = Keys.F1 AndAlso e.Modifiers = Keys.Alt Then
                'BG_frm.R_1.PerformClick()
            End If
            If e.KeyCode = Keys.F2 Then
                BG_frm.R_2.PerformClick()
            End If
            If e.KeyCode = Keys.F3 AndAlso e.Modifiers = Keys.Alt Then

            ElseIf e.KeyCode = Keys.F3 Then
                BG_frm.R_3.PerformClick()
            End If
            If e.KeyCode = Keys.F4 AndAlso e.Modifiers = Keys.Alt Then

            ElseIf e.KeyCode = Keys.F4 Then
                BG_frm.R_5.PerformClick()
            End If
            If e.KeyCode = Keys.F5 AndAlso e.Modifiers = Keys.Alt Then

            ElseIf e.KeyCode = Keys.F5 Then
                BG_frm.R_6.PerformClick()
            End If
            If e.KeyCode = Keys.F6 AndAlso e.Modifiers = Keys.Alt Then

            ElseIf e.KeyCode = Keys.F6 Then
                BG_frm.R_7.PerformClick()
            End If
        End If
    End Sub
    Private Sub R_1_Click(sender As Object, e As EventArgs)
        If BG_frm.HADE_TXT.Text = "Stock Item Monthly" Then
            If YN_Details = True Then
                YN_Details = False
                BG_frm.R_1.Text = "|F1 : Detailed"
            Else
                YN_Details = True
                BG_frm.R_1.Text = "|F1 : Condensed"
            End If
            Fill_Grid()
        End If
    End Sub
    Private Sub B_1_Click(sender As Object, e As EventArgs)
        If BG_frm.HADE_TXT.Text = "Stock Item Monthly" Then
            Dim paramtr(9) As ReportParameter

            Print_Priew_frm.ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dt_list", dt_print))
            Print_Priew_frm.ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dt_cmp", Print_DT_Company))
            Print_Priew_frm.Print_Privew(Application.StartupPath & "\Print_\Report\Item_Monthly", "", paramtr)
        End If
    End Sub
    Private Sub R_3_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Cell("Stock Items (Expiry Date Report)", VC_ID_)
        End If
    End Sub
    Private Sub R_2_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Set_Date(True, Me)
        End If
    End Sub
    Private Sub R_7_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Cell("Filter", "Godown", BG_frm.HADE_TXT.Text)
        End If
    End Sub
    Private Sub R_5_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Cell("Filter", "Branch", BG_frm.HADE_TXT.Text)
        End If
    End Sub
    Private Sub B_3_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Fill_Grid()
        End If
    End Sub
    Private Sub R_6_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Cell("Filter", "Valuation", BG_frm.HADE_TXT.Text)
        End If
    End Sub
    Public Function Filter_Apply()
        Label10.Text = Dft_Branch
        Label14.Text = Dft_Valuation
        Label3.Text = dft_Godown_Name

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
    Private Sub Report_Stock_item_monthly_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.HADE_TXT.Text = "Stock Item Monthly"
        BG_frm.TYP_TXT.Text = VC_Type_

        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text

        cfg_Fill()
        Button_Clear()
        Button_Manage()

        Unit_ = Find_DT_Value(Database_File.cre, "TBL_Stock_Item", "Unit", "ID = '" & VC_ID_ & "'")
        Unit_ = Find_DT_Unit_Conves(Unit_)

        Fill_Grid()
    End Sub
    Private Function cfg_Fill()
        Branch_Panel.Visible = Branch_Visible()
        Godown_Panel.Visible = Godown_YN

    End Function

    Dim Unit_ As String
    Private Sub Report_Stock_item_monthly_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End
        Add_Hander_Remove_Handel(False)
        Frm_foCus()
    End Sub
    Dim Current_Grid_Count As Integer
    Private Function Fill_Opnig_Blanace(dt As DataTable)
        Dim in_q As Decimal = Val(Find_DT_Value(Database_File.cre, "TBL_Stock_Item", "OB_Quantity", $"ID = '{VC_ID_}'"))
        Dim in_a As Decimal = Val(Find_DT_Value(Database_File.cre, "TBL_Stock_Item", "OB_Value", $"ID = '{VC_ID_}'"))

        Dim out_q As Decimal = 0.00
        Dim out_a As Decimal = 0.00



        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select vi.Type,vi.Qty1,vi.Amount1 From TBL_VC_item_Details VI where VI.Item = '{VC_ID_}' and vi.Date <= '{CDate(Frm_date).AddDays(0).ToString(Lite_date_Format)}'", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            'My.Computer.Clipboard.SetText(cmd.CommandText)
            While r.Read
                If r("Type").ToString = "Credit" Then
                    in_q += Val(r("Qty1").ToString)
                    in_a += Val(r("Amount1").ToString)
                ElseIf r("Type").ToString = "Debit" Then
                    out_q += Val(r("Qty1").ToString)
                    out_a += Val(r("Amount1").ToString)
                End If
            End While
            r.Close()
            Dim Rate_ As Decimal = 0.00

            If Dft_Valuation = "At Zero Price" Then
                Rate_ = 0.00
            ElseIf Dft_Valuation = "Avg. Cost (as per period)" Then
                Try
                    Rate_ = in_a / in_q
                Catch ex As Exception

                End Try
            ElseIf Dft_Valuation = "Avg. Price (as per period)" Then
                Try
                    Rate_ = out_a / out_q
                Catch ex As Exception

                End Try
            ElseIf Dft_Valuation = "Last Purchase Cost" Then
                If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                    cmd = New SQLiteCommand($"SELECT ifnull(vi.Rate1 ,0) as Rate_ From TBL_VC_item_Details vi LEFT JOIN TBL_VC vc on vc.Tra_ID = vi.Tra_ID where vc.Voucher_Type = 'Purchase' and vi.Item = '{VC_ID_}' and vc.Visible = 'Approval' and vc.Date <= '{CDate(Frm_date).AddDays(0).ToString(Lite_date_Format)}' ORDER by vc.[date] DESC LIMIT 1", cn)
                    Dim r1 As SQLiteDataReader
                    r1 = cmd.ExecuteReader
                    While r1.Read
                        Rate_ = Val(r1("Rate_").ToString)
                    End While
                End If
            ElseIf Dft_Valuation = "Last Sales Price" Then
                If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                    cmd = New SQLiteCommand($"SELECT ifnull(vi.Rate1 ,0) as Rate_ From TBL_VC_item_Details vi LEFT JOIN TBL_VC vc on vc.Tra_ID = vi.Tra_ID where vc.Voucher_Type = 'Sales' and vi.Item = '{VC_ID_}' and vc.Visible = 'Approval' and vc.Date <= '{CDate(Frm_date).AddDays(0).ToString(Lite_date_Format)}' ORDER by vc.[date] DESC LIMIT 1", cn)
                    Dim r1 As SQLiteDataReader
                    r1 = cmd.ExecuteReader
                    While r1.Read
                        Rate_ = Val(r1("Rate_").ToString)
                    End While
                End If
            ElseIf Dft_Valuation = "Std. Price" Then
                If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                    cmd = New SQLiteCommand($"SELECT ifnull((std.Rate) ,0) as Rate From TBL_Item_Rate std where std.Item = '{VC_ID_}' and std.Type = 'Price' and ([Date] <= '{Frm_date.AddDays(0).ToString(Lite_date_Format)}') ORDER BY [Date] DESC LIMIT 1", cn)
                    Dim r1 As SQLiteDataReader
                    r1 = cmd.ExecuteReader
                    While r1.Read
                        Rate_ = Val(r1("Rate").ToString)
                    End While
                    r1.Close()
                End If
            ElseIf Dft_Valuation = "Std. Cost" Then
                If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                    cmd = New SQLiteCommand($"SELECT ifnull((std.Rate) ,0) as Rate From TBL_Item_Rate std where std.Item = '{VC_ID_}' and std.Type = 'Cost' and ([Date] <= '{Frm_date.AddDays(0).ToString(Lite_date_Format)}') ORDER BY [Date] DESC LIMIT 1", cn)
                    Dim r1 As SQLiteDataReader
                    r1 = cmd.ExecuteReader
                    While r1.Read
                        Rate_ = Val(r1("Rate").ToString)
                    End While
                    r1.Close()
                End If



            End If

            Dim Cl_qty As Decimal = in_q - out_q
            Dim Cl_amt As Decimal = Cl_qty * Rate_

            Label37.Text = N2_FORMATE(Cl_qty)
            Label38.Text = N2_FORMATE(Cl_amt)

            Return Cl_qty

        End If


    End Function
    Public Function Fill_Grid()
        Acc_LB.Text = Find_DT_Value(Database_File.cre, "TBL_Stock_Item", "Name", "ID = '" & VC_ID_ & "'")


        Label10.Text = Dft_Branch
        Label14.Text = Dft_Valuation
        Label3.Text = dft_Godown_Name

        dt_print.Rows.Clear()
        dt_print = ds_print.Tables("TBL_Monthly")

        Dim Branch_Filter As String = ""
        If Dft_Branch <> "Primary" Then
            Branch_Filter = " AND VC.Branch = '" & Find_DT_Value(Database_File.cre, "TBL_Ledger", "ID", "Name = '" & Dft_Branch & "'") & "'"
        End If
        Dim Godown_Filter As String = ""
        Dim Godown_LeftJoin As String = "LEFT JOIN TBL_VC_Item_Other_Details vio on vio.TBL_VI = vi.ID"
        Dim Qty_Source As String = "vi"

        If Godown_YN = True Then
            If dft_Godown_Name <> "All Godown" Then
                Godown_Filter = "AND vio.Godown = '" & Find_DT_Value(Database_File.cre, "TBL_Stock_Godown", "ID", "Name = '" & dft_Godown_Name & "'") & "'"
            End If
        End If

        Dim valu As String = ""
        valu = Dft_Valuation
        If Dft_Valuation = "Default" Then
            valu = Find_DT_Value(Database_File.cre, "TBL_Stock_Item", "Costing_Value_Type", $"ID = '{VC_ID_}'")
        End If

        Chart_Setup()


        Dim dt As New DataTable
        Dim dr As DataRow

        Dim dr_Print As DataRow
        Dim Particuls As String

        Dim D1 As Integer = DateDiff(DateInterval.Month, CDate(Frm_date), CDate(to_date))

        dt.Clear()
        dt.Columns.Add("Type")
        dt.Columns.Add("Date_Frm").DataType = GetType(Date)
        dt.Columns.Add("Date_TO").DataType = GetType(Date)
        dt.Columns.Add("Particulars")
        dt.Columns.Add("Entrys")
        dt.Columns.Add("Quantity_IN")
        dt.Columns.Add("Value_IN")
        dt.Columns.Add("Quantity_OW")
        dt.Columns.Add("Value_OW")
        dt.Columns.Add("Quantity_CL")
        dt.Columns.Add("Value_CL")

        Dim OB_ As Decimal = 0
        OB_ = Fill_Opnig_Blanace(dt)


        'Dim Closing_Total As String = LD_Opning_Balance(VC_ID_, CDate(Frm_date).AddDays(1), Branch_ID, "0")
        Dim Company_Valu As Date = Company_Book_frm


        Dim Qty_IN_TO As String = 0
        Dim Qty_OW_TO As String = 0

        Dim Value_IN_TO As String = 0
        Dim Value_OW_TO As String = 0

        Dim Qty_CL As Decimal = OB_
        Dim Value_CL As Decimal = OB_


        'For i As Integer = 0 To D1
        Dim Qty_IN As String = 0
        Dim Qty_OW As String = 0

        'Dim Value_IN As String = 0
        'Dim Value_OW As String = 0

        Dim Entri_Count As String = "0"

        If open_MSSQL(Database_File.cre) = True Then
            Dim Date_Filter As String = $"(vc.Date >= '{Frm_date.ToString(Lite_date_Format)}' and vc.Date <= '{to_date.AddDays(1).ToString(Lite_date_Format)}')"

            cmd = New SQLiteCommand($"Select [Date],SUM(Inward_qty) as Inward_qty,SUM(Outward_qty) as Outward_qty,SUM(Inward_vlu) as Inward_vlu,SUM(Outward_vlu) as Outward_vlu,Rate1 as Rate From (Select vc.[Date],
(SELECT SUM(ifnull((vi.Qty1) ,0))
From TBL_VC_item_Details vi
{Godown_LeftJoin}
where (vi.Type = 'Credit' and vi.Tra_ID = vc.Tra_ID) and vi.Item = '{VC_ID_}' {Godown_Filter}{Branch_Filter}) as Inward_qty,

(SELECT SUM(ifnull((vi.Qty1) ,0))
From TBL_VC_item_Details vi
{Godown_LeftJoin}
where (vi.Type = 'Debit' and vi.Tra_ID = vc.Tra_ID) and vi.Item = '{VC_ID_}' {Godown_Filter}{Branch_Filter}) as Outward_qty,

(SELECT ifnull((vi.Amount1) ,0)
From TBL_VC_item_Details vi
{Godown_LeftJoin}
where (vi.Type = 'Credit' and vi.Tra_ID = vc.Tra_ID) and vi.Item = '{VC_ID_}' {Godown_Filter}{Branch_Filter}) as Inward_vlu,

(SELECT ifnull((vi.Amount1) ,0)
From TBL_VC_item_Details vi
{Godown_LeftJoin}
where (vi.Type = 'Debit' and vi.Tra_ID = vc.Tra_ID) and vi.Item = '{VC_ID_}' {Godown_Filter}{Branch_Filter}) as Outward_vlu,

'0' as Rate1

From TBL_VC vc

where vc.ID <> '0' and {Date_Filter})
GROUP BY STRFTIME('%m-%Y', [date])
Order By [Date]", con)


            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            'My.Computer.Clipboard.SetText(cmd.CommandText)
            Dim Rate_ As Decimal = 0.00

            While r.Read

                Dim Dateee_ As Date = CDate(r("Date"))

                dr = dt.NewRow
                dr_Print = dt_print.NewRow

                Particuls = CDate(Dateee_).ToString("MMMM") & " - " & Dateee_.ToString("yyyy")

                dr("Particulars") = Particuls
                dr("Date_frm") = CDate("01-" & Dateee_.ToString("MM-yyyy"))
                dr("Date_TO") = Month_last_date(Dateee_.ToString("MM"), Dateee_.ToString("yyyy"))



                dr_Print("Partiiculars") = Particuls



                dr("Quantity_IN") = Back_Unit(r("Inward_qty").ToString)
                Qty_IN = Val(r("Inward_qty").ToString)
                Qty_IN_TO = Val(Qty_IN_TO) + Val(r("Inward_qty").ToString)
                dr_Print("Quantity_IN") = Back_Unit(r("Inward_qty").ToString)


                dr("Quantity_OW") = Back_Unit(r("Outward_qty").ToString)
                Qty_OW = Val(r("Outward_qty").ToString)
                Qty_OW_TO = Val(Qty_OW_TO) + Val(r("Outward_qty").ToString)
                dr_Print("Quantity_OW") = Back_Unit(r("Outward_qty").ToString)


                dr("Value_IN") = N2_FORMATE(r("Inward_vlu").ToString)
                Value_IN_TO = Val(Value_IN_TO) + Val(r("Inward_vlu").ToString)
                dr_Print("Value_IN") = N2_FORMATE(r("Inward_vlu").ToString)


                dr("Value_OW") = N2_FORMATE(r("Outward_vlu").ToString)
                Value_OW_TO = Val(Value_OW_TO) + Val(r("Outward_vlu").ToString)
                dr_Print("Value_OW") = N2_FORMATE(r("Outward_vlu").ToString)


                'Rate valuation
                If valu = "At Zero Price" Then
                    Rate_ = 0.00
                ElseIf valu = "Avg. Cost (as per period)" Then
                    Rate_ = nUmBeR_FORMATE(Val(r("Inward_vlu").ToString) / Val(r("Inward_qty").ToString))
                ElseIf valu = "Avg. Price (as per period)" Then
                    Rate_ = nUmBeR_FORMATE(Val(r("Outward_vlu").ToString) / Val(r("Outward_qty").ToString))
                ElseIf valu = "Last Purchase Cost" Then
                    Dim cn As New SQLiteConnection
                    If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                        cmd = New SQLiteCommand($"SELECT ifnull(vi.Rate1 ,0) as Rate_ From TBL_VC_item_Details vi LEFT JOIN TBL_VC vc on vc.Tra_ID = vi.Tra_ID {Godown_LeftJoin} where vc.Voucher_Type = 'Purchase' and vi.Item = '{VC_ID_}' and vc.Visible = 'Approval' and vc.Date <= '{Dateee_.AddDays(1).ToString(Lite_date_Format)}' {Godown_Filter} ORDER by vc.[date] DESC LIMIT 1", cn)
                        Dim r1 As SQLiteDataReader
                        r1 = cmd.ExecuteReader
                        While r1.Read
                            Rate_ = Val(r1("Rate_").ToString)
                        End While
                    End If
                ElseIf valu = "Last Sales Price" Then
                    Dim cn As New SQLiteConnection
                    If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                        cmd = New SQLiteCommand($"SELECT ifnull(vi.Rate1 ,0) as Rate_ From TBL_VC_item_Details vi LEFT JOIN TBL_VC vc on vc.Tra_ID = vi.Tra_ID {Godown_LeftJoin} where vc.Voucher_Type = 'Sales' and vi.Item = '{VC_ID_}' and vc.Visible = 'Approval' and vc.Date <= '{Dateee_.AddDays(1).ToString(Lite_date_Format)}' {Godown_Filter} ORDER by vc.[date] DESC LIMIT 1", cn)
                        Dim r1 As SQLiteDataReader
                        r1 = cmd.ExecuteReader
                        While r1.Read
                            Rate_ = Val(r1("Rate_").ToString)
                        End While
                    End If
                ElseIf valu = "Std. Price" Then
                    Dim cn As New SQLiteConnection
                    If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                        cmd = New SQLiteCommand($"SELECT ifnull((std.Rate) ,0) as Rate_ From TBL_Item_Rate std where std.Item = '{VC_ID_}' and std.Type = 'Price' and ([Date] <= '{Dateee_.ToString(Lite_date_Format)}') ORDER BY [Date] DESC LIMIT 1", cn)
                        Dim r1 As SQLiteDataReader
                        r1 = cmd.ExecuteReader
                        'My.Computer.Clipboard.SetText(cmd.CommandText)
                        While r1.Read
                            Rate_ = Val(r1("Rate_").ToString)
                        End While
                    End If
                ElseIf valu = "Std. Cost" Then
                    Dim cn As New SQLiteConnection
                    If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                        cmd = New SQLiteCommand($"SELECT ifnull((std.Rate) ,0) as Rate_ From TBL_Item_Rate std where std.Item = '{VC_ID_}' and std.Type = 'Cost' and ([Date] <= '{Dateee_.ToString(Lite_date_Format)}') ORDER BY [Date] DESC LIMIT 1", cn)
                        Dim r1 As SQLiteDataReader
                        r1 = cmd.ExecuteReader
                        'My.Computer.Clipboard.SetText(cmd.CommandText)
                        While r1.Read
                            Rate_ = Val(r1("Rate_").ToString)
                        End While
                    End If
                ElseIf valu = "Basic Purchase Rate" Then
                    Dim cn As New SQLiteConnection
                    If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                        cmd = New SQLiteCommand($"SELECT ifnull((std.Purchase_Rate) ,0) as Rate_ From TBL_Stock_Item std where std.ID = '{VC_ID_}'", cn)
                        Dim r1 As SQLiteDataReader
                        r1 = cmd.ExecuteReader
                        'My.Computer.Clipboard.SetText(cmd.CommandText)
                        While r1.Read
                            Rate_ = Val(r1("Rate_").ToString)
                        End While
                    End If
                ElseIf valu = "Basic Sales Rate" Then
                    Dim cn As New SQLiteConnection
                    If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                        cmd = New SQLiteCommand($"SELECT ifnull((std.Sales_Rate) ,0) as Rate_ From TBL_Stock_Item std where std.ID = '{VC_ID_}'", cn)
                        Dim r1 As SQLiteDataReader
                        r1 = cmd.ExecuteReader
                        'My.Computer.Clipboard.SetText(cmd.CommandText)
                        While r1.Read
                            Rate_ = Val(r1("Rate_").ToString)
                        End While
                    End If
                End If



                Qty_CL = Qty_CL + (Val(r("Inward_qty").ToString) - Val(r("Outward_qty").ToString))
                Value_CL = Val(Qty_CL) * Val(Rate_)

                dr("Quantity_CL") = Back_Unit(Qty_CL)
                dr_Print("Quantity_CL") = Back_Unit(Qty_CL)

                dr("Value_CL") = N2_FORMATE(Value_CL)
                dr_Print("Value_CL") = N2_FORMATE(Value_CL)

                dt.Rows.Add(dr)
                dt_print.Rows.Add(dr_Print)


                Chart1.Series(0).Points.AddXY((Particuls), Val(Qty_IN))
                Chart1.Series(1).Points.AddXY((Particuls), Val(Qty_OW))
                Chart1.DataBind()

                If Dateee_.ToString("MM") = suggest_date.ToString("MM") Then
                    Current_Grid_Count = dt.Rows.Count - 1
                End If

            End While
            r.Close()


            If dt.Rows.Count <> 0 Then
                dt.Rows(0)(1) = CDate(Frm_date)
                dt.Rows(dt.Rows.Count - 1)(2) = CDate(to_date)
            End If
        End If



        Label6.Text = N2_FORMATE(Value_CL)


        'Next


        Label11.Text = Back_Unit(Qty_IN_TO)
        Label5.Text = Back_Unit(Qty_OW_TO)
        Label8.Text = Back_Unit(Qty_CL)

        Label9.Text = Back_Unit(Value_IN_TO)
        Label2.Text = Back_Unit(Value_OW_TO)

        Label37.Text = Back_Unit(Label37.Text)


        Dim dv As New DataView(dt)
        Dim Dt_set As New DataTable
        'dv.Sort = "Date_frm"
        Dt_set = dv.ToTable


        Grid1.DataSource = dv


        Grid1.Columns(0).Visible = False
        Grid1.Columns(1).Visible = False
        Grid1.Columns(2).Visible = False

        Grid1.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Grid1.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        Grid1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        Grid1.Columns(4).Width = 50
        Grid1.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        Grid1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Grid1.Columns(5).Width = 100
        Grid1.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        Grid1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


        Grid1.Columns(6).Width = 100
        Grid1.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        Grid1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Grid1.Columns(7).Width = 100
        Grid1.Columns(7).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        Grid1.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Grid1.Columns(8).Width = 100
        Grid1.Columns(8).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        Grid1.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Grid1.Columns(9).Width = 100
        Grid1.Columns(9).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        Grid1.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Grid1.Columns(10).Width = 100
        Grid1.Columns(10).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        Grid1.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'Grid1.Columns(10).DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Bold)

        Grid1.DefaultCellStyle.BackColor = Color.White
        Grid1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(254, 197, 48)

        Label4.Width = (Val(Grid1.Columns(4).Width))

        Panel10.Width = (Val(Grid1.Columns(6).Width) * 2)
        Panel19.Width = (Val(Grid1.Columns(6).Width) * 2)


        Panel11.Width = (Val(Grid1.Columns(6).Width) * 2) - 1
        Panel22.Width = (Val(Grid1.Columns(6).Width) * 2) - 1

        Panel12.Width = (Val(Grid1.Columns(6).Width) * 2) - 1
        Panel20.Width = (Val(Grid1.Columns(6).Width) * 2) - 1


        Label38.Width = Label20.Width
        Label37.Width = Label21.Width

        Try
            Grid1.CurrentCell = Grid1.Rows(Current_Grid_Count).Cells(3)
        Catch ex As Exception

        End Try
        Set_Column()
        Grid1.Focus()
    End Function
    Private Function Back_Unit(vlu As String) As String
        If Val(vlu) = 0 Then
            Return ""
        Else
            Dim s As Decimal = nUmBeR_FORMATE(vlu)
            Return N2_FORMATE(s) & $" {Unit_}"
        End If
    End Function
    Private Function Chart_Setup()
        Grid1.Focus()
        Dim Series1 As DataVisualization.Charting.Series = New DataVisualization.Charting.Series()
        Dim Series2 As DataVisualization.Charting.Series = New DataVisualization.Charting.Series()

        Series1.IsValueShownAsLabel = True
        Series2.IsValueShownAsLabel = True


        Series1.ChartArea = "ChartArea1"
        Series1.Color = Color.Blue
        Series1.Legend = "Legend1"
        Series1.Name = "Inward"
        Series1.ChartType = DataVisualization.Charting.SeriesChartType.Column

        Series2.ChartArea = "ChartArea1"
        Series2.Color = Color.Red
        Series2.Legend = "Legend1"
        Series2.Name = "Outward"
        Series2.ChartType = DataVisualization.Charting.SeriesChartType.Column

        Chart1.Series.Clear()

        Chart1.Series.Add(Series1)
        Chart1.Series.Add(Series2)
        Chart1.Update()
        Chart1.DataBind()


        Chart1.Size = New Size(1246, 209)
        Chart1.Text = "Chart1"
    End Function
    Private Sub Grid1_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles Grid1.RowsAdded
        Grid1.Rows(Grid1.Rows.Count - 1).Height = 18
    End Sub
    Private Sub Frm_Date_LB_TextChanged(sender As Object, e As EventArgs) Handles Frm_Date_LB.TextChanged
        Frm_date = Date_Formate(Frm_Date_LB.Text)
    End Sub
    Private Sub To_Date_LB_TextChanged(sender As Object, e As EventArgs) Handles To_Date_LB.TextChanged
        to_date = Date_Formate(To_Date_LB.Text)
    End Sub

    Private Sub Report_Stock_item_monthly_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub Grid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid1.CellContentClick

    End Sub

    Private Sub Grid1_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid1.KeyDown
        If e.KeyCode = Keys.Enter Then

            Dim d1 As Date = CDate(Grid1.CurrentRow.Cells(1).Value)
            Dim d2 As Date = CDate(Grid1.CurrentRow.Cells(2).Value).AddDays(0)


            Cell("Stock Item Vouchers", "", "Display", VC_ID_, d1, d2, Find_DT_Value(Database_File.cre, "TBL_Ledger", "ID", "Name = '" & Dft_Branch & "'"), Dft_Valuation)
        End If
    End Sub

    Private Sub Grid1_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles Grid1.RowPrePaint
        Dim ro As DataGridViewRow = Grid1.Rows(e.RowIndex)

        If ro.Cells(0).Value.ToString = "OB" Then
            ro.Height = 20
            'ro.DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Bold)
        End If
    End Sub

    Private Sub Report_Stock_item_monthly_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
        Grid1.Focus()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        Set_Column()
    End Sub
    Private Function Set_Column()
        Dim ctlpos As Point = Panel12.PointToScreen(Panel12.DisplayRectangle.Location)
        B1.Location = New Point(ctlpos.X, 0)
        B1.Height = Me.Height

        ctlpos = New Point
        ctlpos = Panel11.PointToScreen(Panel11.DisplayRectangle.Location)
        B2.Location = New Point(ctlpos.X, 0)
        B2.Height = Me.Height

        ctlpos = New Point
        ctlpos = Panel10.PointToScreen(Panel10.DisplayRectangle.Location)
        B3.Location = New Point(ctlpos.X, 0)
        B3.Height = Me.Height
    End Function

    Private Sub Godown_Panel_Paint(sender As Object, e As PaintEventArgs) Handles Godown_Panel.Paint

    End Sub
End Class