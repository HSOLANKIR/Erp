Imports System.ComponentModel
Imports System.Data.SQLite
Imports BarcodeLib
Imports Microsoft.Reporting.WinForms
Imports PopupControl
Imports Tools

Public Class Profit_Loss_frm
    Dim From_ID As String
    Private VC_Type_ As String
    Private VC_ID_ As String
    Private Path_End As String
    Dim YN_Details As Boolean = True
    Dim Acc_Under As String
    Public Frm_date As Date
    Public to_date As Date

    Dim SUB_Left_Count As Decimal = 0.00
    Dim SUB_Right_Count As Decimal = 0.00
    Dim SUB_Left01_Count As Decimal = 0.00
    Dim SUB_Right02_Count As Decimal = 0.00

    Dim Branch_ID As String = "0"

    Private Sub Profit_Loss_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text

        VC_Type_ = Link_Valu(1)
        VC_ID_ = Link_Valu(2)


        Frm_Date_LB.Text = Date_Formate(Date_1)
        To_Date_LB.Text = Date_Formate(Date_2)

        BG_frm.HADE_TXT.Text = "Profit & Loss Account"
        BG_frm.TYP_TXT.Text = VC_Type_

        Button_Manage()
        Add_Hander_Remove_Handel(True)

        Get_Focus(Grid1)
        Update_Report = True
    End Sub
    Private Function Button_Manage()
        BG_frm.R_1.Text = "|F1 : Detailed"
        BG_frm.R_2.Text = "F2 : Date"
        BG_frm.R_3.Text = "|F2 : Period"
        If Branch_Visible() = True Then
            BG_frm.R_5.Text = "F4 : Branch"
        End If
        BG_frm.R_6.Text = "F5 : Valuation"

        BG_frm.B_1.Text = "&E : Exit"
        BG_frm.B_2.Text = "&P : Print"
    End Function
    Private Function Add_Hander_Remove_Handel(Ans As Boolean)
        If Ans = True Then
            AddHandler BG_frm.KeyDown, AddressOf Me.BG_Keydown
            AddHandler BG_frm.R_1.Click, AddressOf Me.R_1_Click
            AddHandler BG_frm.R_2.Click, AddressOf Me.R_3_Click
            AddHandler BG_frm.R_3.Click, AddressOf Me.R_4_Click
            If Branch_Visible() = True Then
                AddHandler BG_frm.R_5.Click, AddressOf Me.R_5_Click
            End If
            AddHandler BG_frm.R_6.Click, AddressOf Me.R_6_Click

            AddHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            AddHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
        Else
            RemoveHandler BG_frm.KeyDown, AddressOf Me.BG_Keydown
            RemoveHandler BG_frm.R_1.Click, AddressOf Me.R_1_Click
            RemoveHandler BG_frm.R_2.Click, AddressOf Me.R_3_Click
            RemoveHandler BG_frm.R_3.Click, AddressOf Me.R_4_Click
            If Branch_Visible() = True Then
                RemoveHandler BG_frm.R_5.Click, AddressOf Me.R_5_Click
            End If
            RemoveHandler BG_frm.R_6.Click, AddressOf Me.R_6_Click

            RemoveHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            RemoveHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
        End If
    End Function
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
        End If
    End Sub
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
    Private Sub B_1_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Me.Dispose()
        End If
    End Sub
    Private Sub B_2_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Print_Data()
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
        'Fill_Grid()
    End Function
    Private Sub Profit_Loss_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
        If e.KeyCode = Keys.Right Then

        End If
        If e.KeyCode = Keys.Left Then

        End If
    End Sub

    Private Sub Profit_Loss_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.HADE_TXT.Text = "Profit & Loss Account"
        BG_frm.TYP_TXT.Text = VC_Type_

        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text
        Button_Clear()
        Button_Manage()
        'Config_Fill()
        If Update_Report = True Then
            Fill_Grid()
        End If
    End Sub
    Private Function Print_Data()

        Dim ds_print As New Print_dt
        Dim D1 As New DataTable
        Dim D2 As New DataTable
        Dim D3 As New DataTable
        Dim D4 As New DataTable

        D1.Rows.Clear()
        D1 = ds_print.Tables("Profit_Loss1")

        D2.Rows.Clear()
        D2 = ds_print.Tables("Profit_Loss2")

        D3.Rows.Clear()
        D3 = ds_print.Tables("Profit_Loss3")

        D4.Rows.Clear()
        D4 = ds_print.Tables("Profit_Loss4")

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

        With Grid3
            For Each ro As DataGridViewRow In Grid3.Rows
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

                D3.Rows.Add(Type_, Head_, amt_)
            Next
        End With

        With Grid4
            For Each ro As DataGridViewRow In Grid4.Rows
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

                D4.Rows.Add(Type_, Head_, amt_)
            Next
        End With


        Print_data_fill(D1, D2, D3, D4)
        Printing_Direct_frm.Printing_(cfg_print_path, rdlc_report_name, "", rdlc_report_data)


    End Function
    Dim cfg_print_path As String
    Dim rdlc_report_name As String
    Dim rdlc_report_data() As ReportDataSource
    Private Function Print_data_fill(d1 As DataTable, d2 As DataTable, d3 As DataTable, d4 As DataTable)

        cfg_print_path = Application.StartupPath & "\Print_\Report\Profit & Loss\Profit_loss"

        rdlc_report_name = $"Profit & Loss Account ({Frm_date.ToString("dd-MMM-yyyy")} to {to_date.ToString("dd-MMM-yyyy")})"
        rdlc_report_name = path_validation(rdlc_report_name, "-")

        rdlc_report_data = {New ReportDataSource("D1", d1),
            New ReportDataSource("D2", d2),
            New ReportDataSource("D3", d3),
            New ReportDataSource("D4", d4),
            New ReportDataSource("dt_cmp", Print_DT_Company)}

    End Function
    Dim Focus_String As String = ""
    Dim Current_Grid As DataGridView

    Public Function Fill_Grid() As Decimal
        If Current_Grid.RowCount <> 0 Then
            Focus_String = Current_Grid.CurrentRow.Cells(1).Value
        End If


        Branch_ID = Branch_ID_()

        Grid1.Rows.Clear()
        Grid2.Rows.Clear()
        Grid3.Rows.Clear()
        Grid4.Rows.Clear()


        'Load_Panel.Show()
        Load_Panel.Dock = DockStyle.Fill

        'data_panel.Hide()

        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            Stock_Data_(cn, True)
            Fill_Group_acc(cn, True)
            Stock_Data_(cn, False)



            Gross_Datafill()

            Fill_Group_acc(cn, False)

            Net_Datafill()

            Total_Panel_Higt_balance()

        End If

        Try
            Current_Grid.CurrentCell = Current_Grid.Rows(Val(Focus_String)).Cells(1)
        Catch ex As Exception

        End Try

        data_panel.Show()
        data_panel.Dock = DockStyle.Fill

        Load_Panel.Hide()
    End Function
    Private Function Net_Datafill()
        Dim Bot_L As Decimal = 0
        For Each ro As DataGridViewRow In Grid3.Rows
            Bot_L = Val(Bot_L) + nUmBeR_FORMATE(ro.Cells(3).Value)
        Next
        Dim Bot_R As Decimal = 0
        For Each ro As DataGridViewRow In Grid4.Rows
            Bot_R = Val(Bot_R) + nUmBeR_FORMATE(ro.Cells(3).Value)
        Next

        If Bot_R > Bot_L Or Bot_R = Bot_L Then
            Grid3.Rows.Add("Head", "Net Profit", "", N2_FORMATE(Val(Bot_R - Bot_L)), "Profit&Loss")
            Label11.Text = N2_FORMATE(Bot_L + (Bot_R - Bot_L))
            Label14.Text = N2_FORMATE(Bot_R)
        Else
            Grid4.Rows.Add("Head", "Net Loss", "", N2_FORMATE(Val(Bot_L - Bot_R)), "Profit&Loss")
            Label11.Text = N2_FORMATE(Bot_L)
            Label14.Text = N2_FORMATE(Bot_R + (Bot_L - Bot_R))
        End If

    End Function
    Private Function Gross_Datafill()
        Dim Profeet As Decimal = 0


        Dim Top_L As Decimal = 0
        For Each ro As DataGridViewRow In Grid1.Rows
            Top_L = Val(Top_L) + nUmBeR_FORMATE(ro.Cells(3).Value)
        Next
        Dim Top_R As Decimal = 0
        For Each ro As DataGridViewRow In Grid2.Rows
            Top_R = Val(Top_R) + nUmBeR_FORMATE(ro.Cells(3).Value)
        Next



        If Top_R > Top_L Or Top_R = Top_L Then
            Grid1.Rows.Add("Head", "Gross Profit", "", N2_FORMATE(Val(Top_R - Top_L)), "Profit&Loss")
            Grid4.Rows.Add("Head", "Gross Profit", "", N2_FORMATE(Val(Top_R - Top_L)), "Profit&Loss")
            Label6.Text = N2_FORMATE(Top_R)
            Label9.Text = N2_FORMATE(Top_L + (Top_R - Top_L))
        Else
            Grid2.Rows.Add("Head", "Gross Loss", "", N2_FORMATE(Val(Top_L - Top_R)), "Profit&Loss")
            Grid3.Rows.Add("Head", "Gross Loss", "", N2_FORMATE(Val(Top_L - Top_R)), "Profit&Loss")
            Label6.Text = N2_FORMATE(Top_R + (Top_L - Top_R))
            Label9.Text = N2_FORMATE(Top_L)
        End If
        'Net




    End Function
    Public Focus_obj As Object
    Dim isprofeet As Boolean = False
    Private Function Total_Panel_Higt_balance()
        Grid1.Height = (Grid1.RowCount * 18) + 3
        Grid2.Height = (Grid2.RowCount * 18) + 3
        Grid3.Height = (Grid3.RowCount * 18) + 3
        Grid4.Height = (Grid4.RowCount * 18) + 3

        If Grid1.Height > Grid2.Height Then
            Grid2.Height = Grid1.Height
        ElseIf Grid1.Height < Grid2.Height Then
            Grid1.Height = Grid2.Height
        End If

    End Function
    Private Function Pass_Data_(isExp As Boolean, isderect As Boolean, id As String, Head_Name As String, dt As DataTable, Group As String) As TextBox
        Dim Gri1 As DataGridView
        Dim Gri2 As DataGridView

        If isderect = True Then
            Gri1 = Grid1
            Gri2 = Grid2
        Else
            Gri1 = Grid3
            Gri2 = Grid4
        End If



        Dim Focus_ As Boolean = False
        Dim Total_ As Decimal = Val(dt.AsEnumerable().Sum(Function(row) row.Field(Of String)("Vlu")))
        If isExp = True Then
            If Total_ >= 0 Then
                Gri1.Rows.Add("Head", Head_Name, "", N2_FORMATE(Val(Total_)), Group, id)

                If Focus_String = Head_Name Then
                    Focus_String = Grid1.RowCount
                    Get_Focus(Gri1)
                End If

                If YN_Details = True Then
                    For Each ro As DataRow In dt.Rows
                        Dim typ As String
                        If ro(3).ToString = "Under_Group" Then
                            typ = "UnderGroup"
                        Else
                            typ = "Under"
                        End If
                        Gri1.Rows.Add(typ, ro(1).ToString, N2_FORMATE(Val(ro(2).ToString)), "", ro(4).ToString, ro(0).ToString)
                        If Focus_String = ro(1).ToString Then
                            Focus_String = Grid1.RowCount
                            Get_Focus(Gri1)
                        End If
                    Next
                End If
            Else
                Gri2.Rows.Add("Head", Head_Name, "", N2_FORMATE(Val(Total_ * -1)), Group, id)
                If Focus_String = Head_Name Then
                    Focus_String = Grid1.RowCount
                    Get_Focus(Gri2)
                End If

                If YN_Details = True Then
                    For Each ro As DataRow In dt.Rows
                        Dim typ As String
                        If ro(3).ToString = "Under_Group" Then
                            typ = "UnderGroup"
                        Else
                            typ = "Under"
                        End If
                        Gri2.Rows.Add(typ, ro(1).ToString, N2_FORMATE(Val(ro(2).ToString) * -1), "", ro(4).ToString, ro(0).ToString)
                        If Focus_String = ro(1).ToString Then
                            Focus_String = Grid1.RowCount
                            Get_Focus(Gri2)
                        End If
                    Next
                End If
            End If
        Else
            If Total_ <= 0 Then
                Gri2.Rows.Add("Head", Head_Name, "", N2_FORMATE(Val(Total_ * -1)), Group, id)
                If Focus_String = Head_Name Then
                    Focus_String = Grid1.RowCount
                    Get_Focus(Gri2)
                End If

                If YN_Details = True Then
                    For Each ro As DataRow In dt.Rows
                        Dim typ As String
                        If ro(3).ToString = "Under_Group" Then
                            typ = "UnderGroup"
                        Else
                            typ = "Under"
                        End If
                        Gri2.Rows.Add(typ, ro(1).ToString, N2_FORMATE(Val(ro(2).ToString) * -1), "", ro(4).ToString, ro(0).ToString)
                        If Focus_String = ro(1).ToString Then
                            Focus_String = Grid1.RowCount
                            Get_Focus(Gri2)
                        End If
                    Next
                End If
            Else
                Gri1.Rows.Add("Head", Head_Name, "", N2_FORMATE(Val(Total_)), Group, id)
                If Focus_String = Head_Name Then
                    Focus_String = Grid1.RowCount
                    Get_Focus(Gri1)
                End If

                If YN_Details = True Then
                    For Each ro As DataRow In dt.Rows
                        Dim typ As String
                        If ro(3).ToString = "Under_Group" Then
                            typ = "UnderGroup"
                        Else
                            typ = "Under"
                        End If
                        Gri1.Rows.Add(typ, ro(1).ToString, N2_FORMATE(Val(ro(2).ToString)), "", ro(4).ToString, ro(0).ToString)
                        If Focus_String = ro(1).ToString Then
                            Focus_String = Grid1.RowCount
                            Get_Focus(Gri1)
                        End If
                    Next
                End If
            End If
        End If
    End Function

    Public Function Fill_Group_acc(cn As SQLiteConnection, isdirect As Boolean)
        Dim dt_ As New DataTable
        dt_.Columns.Add("ID")
        dt_.Columns.Add("Name")
        dt_.Columns.Add("Vlu")

        Dim filter_ As String
        If isdirect = True Then
            filter_ = "and (ag.Id <> '14' and ag.Id <> '15')"
        Else
            filter_ = "and (ag.Id = '14' or ag.Id = '15')"
        End If


        Dim cn1 As New SQLiteConnection
        open_MSSQL_Cstm(Database_File.cre, cn1)
        Dim Qry As String = $"Select * From TBL_Acc_Group ag where (ag.Head = 'Expenses' or ag.Head = 'Income') {filter_} and ag.Visible = 'Approval'"
        cmd = New SQLiteCommand(Qry, cn)
        Dim r As SQLiteDataReader = cmd.ExecuteReader()


        Dim q As String = ""
        'q &= $" and (vc.[Date] <= '{CDate(to_date).AddDays(1).ToString(Lite_date_Format)}')"
        q &= $" and (vc.[Date] BETWEEN '{CDate(Frm_date).ToString(Lite_date_Format)}' and '{CDate(to_date).AddDays(1).ToString(Lite_date_Format) }')"
        If Branch_ID <> 0 Then
            q &= $" AND VC.Branch = '{Branch_ID }'"
        End If


        While r.Read

            Qry = $"Select 'Account Ledger' as Type,ld.ID,ld.name,
(Select (ifnull(SUM(vl.Dr),0) - ifnull(SUM(vl.Cr),0)) From TBL_VC_Ledger vl Left Join TBL_VC vc on vc.Tra_ID = vl.Tra_ID where vl.Ledger = ld.id {q}) as Bal_
From TBL_Ledger ld 
where ld.Visible = 'Approval' and ld.[Group] = '{r("ID")}'
 
 UNION ALL
 
 Select 'Payhead' as Type,ld.ID,ld.name,
(Select (ifnull(SUM(vc.Dr),0) - ifnull(SUM(vc.Cr),0)) From TBL_VC_Payroll vc where vc.Payhead = ld.id {q}) as Bal_
 From TBL_PayHead ld where ld.Visible = 'Approval' and ld.[Under] = '{r("ID")}'
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
                Dim vlu As Decimal = Val(r1("Bal_"))
                If Val(vlu) <> 0 Then
                    dt_.Rows.Add(r1("ID"), r1("Name"), vlu, "Under", r1("Type").ToString)
                End If
            End While

            If r("Head") = "Expenses" Then
                Pass_Data_(True, isdirect, r("ID"), r("Name").ToString, dt_, "Account Group")
            ElseIf r("Head") = "Income" Then
                Pass_Data_(False, isdirect, r("ID"), r("Name").ToString, dt_, "Account Group")
            End If

        End While




    End Function
    Public Function Stock_Data_(cn As SQLiteConnection, Opning_ As Boolean)
        Dim Branch_Filter As String = ""
        Dim cn1 As New SQLiteConnection
        Dim frm_ As Date
        Dim to_ As Date

        Dim dt_ As New DataTable
        dt_.Columns.Add("ID")
        dt_.Columns.Add("Name")
        dt_.Columns.Add("Vlu")
        dt_.Columns.Add("Type")
        dt_.Columns.Add("Open_Type")

        If Opning_ = True Then
            frm_ = CDate(Company_Book_frm)
            to_ = CDate(Frm_date)
        Else

            frm_ = CDate(Frm_date)
            to_ = CDate(to_date).AddDays(1)
        End If


        If Dft_Branch <> "Primary" Then
            Branch_Filter = " AND VC.Branch = '" & Find_DT_Value(Database_File.cre, "TBL_Ledger", "ID", "Name = '" & Dft_Branch & "'") & "'"
        End If


        Dim Qry As String = $"Select '0' as 'ID','Primary' as 'Name' UNION ALL Select ID,[Name] From TBL_Stock_Group where {Company_Visible_Filter()}"
        cmd = New SQLiteCommand(Qry, cn)
        Dim r As SQLiteDataReader = cmd.ExecuteReader


        open_MSSQL_Cstm(Database_File.cre, cn1)
        While r.Read
            Qry = $"Select it.id,it.name,(Select u.Symbol From TBL_Inventory_Unit u where u.ID = it.Unit) as Unit_Name,
ifnull(ifnull((SELECT ifnull(SUM(vi.Qty1) ,0)
From TBL_VC_item_Details vi
LEFT JOIN TBL_VC vc on vc.Tra_ID = vi.Tra_ID

where (vi.Type = 'Credit' and vc.Effect_Stock = 'Yes' and vc.Type = 'Head') and vi.Item = it.Id and vc.Visible = 'Approval' and (vc.[Date] <= '{to_.ToString(Lite_date_Format)}'){Branch_Filter}) -
(SELECT ifnull(SUM(vi.Qty1) ,0)
From TBL_VC_item_Details vi
LEFT JOIN TBL_VC vc on vc.Tra_ID = vi.Tra_ID

where (vi.Type = 'Debit' and vc.Effect_Stock = 'Yes' and vc.Type = 'Head') and vi.Item = it.Id and vc.Visible = 'Approval' and (vc.[Date] <= '{to_.ToString(Lite_date_Format)}'){Branch_Filter}),0) + (Select ifnull(sum(ios.Stock),0) From TBL_Stock_Item_Opning_Stock ios where ios.Item_ID = it.id and ios.Branch_ID = '{Branch_ID}'),0) as Qty1 ,

ifnull((Case WHEN ('{Dft_Valuation}' = 'At Zero Price' or ('{Dft_Valuation}' = 'Default' and it.Costing_Value_Type = 'At Zero Price')) THEN
'0'
else (Case WHEN ('{Dft_Valuation}' = 'Avg. Cost (as per period)' or ('{Dft_Valuation}' = 'Default' and it.Costing_Value_Type = 'Avg. Cost (as per period)')) THEN
(SELECT ifnull(ifnull(SUM(vi.Amount1) ,0) / ifnull(ifnull(SUM(vi.Qty1),0),0),0) From TBL_VC_item_Details vi where (vi.Type = 'Credit') and vi.Item = it.Id and (vi.Date BETWEEN '{CDate(frm_).ToString(Lite_date_Format)}' and '{CDate(to_).ToString(Lite_date_Format) }'){Branch_Filter})

else (Case WHEN ('{Dft_Valuation}' = 'Avg. Price (as per period)' or ('{Dft_Valuation}' = 'Default' and it.Costing_Value_Type = 'Avg. Price (as per period)')) THEN
(SELECT ifnull(ifnull(SUM(vi.Amount1) ,0) / ifnull(ifnull(SUM(vi.Qty1),0),0),0) From TBL_VC_item_Details vi where (vi.Type = 'Debit') and vi.Item = it.Id and (vi.Date BETWEEN '{CDate(frm_).ToString(Lite_date_Format)}' and '{CDate(to_).ToString(Lite_date_Format) }'){Branch_Filter})


else (Case WHEN ('{Dft_Valuation}' = 'Last Sales Price' or ('{Dft_Valuation}' = 'Default' and it.Costing_Value_Type = 'Last Sales Price')) THEN
(SELECT ifnull(vi.Rate1 ,0) From TBL_VC_item_Details vi LEFT JOIN TBL_VC vc on vc.Tra_ID = vi.Tra_ID where vc.Voucher_Type = 'Sales' and vi.Item = it.Id and vc.Visible = 'Approval' and (vc.[Date] <= '{to_.ToString(Lite_date_Format)}'){Branch_Filter} ORDER by vc.[date] DESC LIMIT 1)

else (Case WHEN ('{Dft_Valuation}' = 'Last Purchase Cost' or ('{Dft_Valuation}' = 'Default' and it.Costing_Value_Type = 'Last Purchase Cost')) THEN
(SELECT ifnull(vi.Rate1 ,0) From TBL_VC_item_Details vi LEFT JOIN TBL_VC vc on vc.Tra_ID = vi.Tra_ID where vc.Voucher_Type = 'Purchase' and vi.Item = it.Id and vc.Visible = 'Approval' and (vc.[Date] <= '{to_.ToString(Lite_date_Format)}'){Branch_Filter} ORDER by vc.[date] DESC LIMIT 1)

else (Case WHEN ('{Dft_Valuation}' = 'Std. Cost' or ('{Dft_Valuation}' = 'Default' and it.Costing_Value_Type = 'Std. Cost')) THEN
(SELECT ifnull((std.Rate) ,0) From TBL_Item_Rate std where std.Item = it.id and std.Type = 'Cost' and ([Date] <= '{to_.ToString(Lite_date_Format)}') ORDER BY [Date] DESC LIMIT 1)

else (Case WHEN ('{Dft_Valuation}' = 'Std. Price' or ('{Dft_Valuation}' = 'Default' and it.Costing_Value_Type = 'Std. Price')) THEN
(SELECT ifnull((std.Rate) ,0) From TBL_Item_Rate std where std.Item = it.id and std.Type = 'Price' and ([Date] <= '{to_.ToString(Lite_date_Format)}') ORDER BY [Date] DESC LIMIT 1)

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

From TBL_Stock_Item it WHERE it.Under = '{r("ID")}' and it.Visible = 'Approval'"

            cmd = New SQLiteCommand(Qry, cn1)


            Dim r1 As SQLiteDataReader
            r1 = cmd.ExecuteReader

            Dim vlu As Decimal = 0
            While r1.Read
                vlu += Val(Val(r1("Qty1") * r1("Vlu")))
            End While

            If Opning_ = False Then
                vlu *= -1
            End If

            If vlu <> 0 Then
                If Opning_ = True Then
                    dt_.Rows.Add(r("ID"), r("Name"), vlu, "Under", "Opning Group")
                Else
                    dt_.Rows.Add(r("ID"), r("Name"), vlu, "Under", "Closing Group")
                End If
            End If
            r1.Close()
        End While

        If Opning_ = True Then
            Dim obj As Object = Pass_Data_(True, True, "", "Opning Stock", dt_, "Opning Stock")
        Else
            Dim obj As Object = Pass_Data_(False, True, "", "Closing Stock", dt_, "Closing Stock")
        End If

    End Function

    Public Profeet_ As Decimal = 0.00
    Public Loss_ As Decimal = 0.00
    Private Sub Frm_Date_LB_TextChanged(sender As Object, e As EventArgs) Handles Frm_Date_LB.TextChanged
        Frm_date = Frm_Date_LB.Text
    End Sub
    Private Sub To_Date_LB_TextChanged(sender As Object, e As EventArgs) Handles To_Date_LB.TextChanged
        to_date = To_Date_LB.Text
    End Sub

    Private Sub Profit_Loss_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
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

    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs) Handles Panel5.Paint
        obj_center(sender, Load_Panel)
    End Sub

    Private Sub Frm_Date_LB_Click(sender As Object, e As EventArgs) Handles Frm_Date_LB.Click

    End Sub

    Private Sub Profit_Loss_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
        Current_Grid.Focus()
    End Sub
    Private Sub Grid1_GotFocus(sender As Object, e As EventArgs) Handles Grid1.GotFocus, Grid2.GotFocus, Grid3.GotFocus, Grid4.GotFocus
        Get_Focus(sender)
    End Sub

    Private Function Get_Focus(Grid As DataGridView)
        Grid1.DefaultCellStyle.SelectionBackColor = Color.White
        Grid2.DefaultCellStyle.SelectionBackColor = Color.White
        Grid3.DefaultCellStyle.SelectionBackColor = Color.White
        Grid4.DefaultCellStyle.SelectionBackColor = Color.White

        Grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(254, 197, 48)

        Current_Grid = Grid
    End Function
    Private Sub Grid1_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles Grid1.RowPrePaint, Grid2.RowPrePaint, Grid3.RowPrePaint, Grid4.RowPrePaint
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

        If ro.Cells(1).Value = "Net Loss" Or ro.Cells(1).Value = "Gross Loss" Then
            ro.DefaultCellStyle.ForeColor = Color.Red
            ro.DefaultCellStyle.SelectionForeColor = Color.Red
        End If

        If ro.Cells(1).Value = "Net Profit" Or ro.Cells(1).Value = "Gross Profit" Then
            ro.DefaultCellStyle.ForeColor = Color.Green
            ro.DefaultCellStyle.SelectionForeColor = Color.Green
        End If
    End Sub

    Private Sub Grid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid1.CellContentClick

    End Sub

    Private Sub Grid1_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid1.KeyDown
        If e.KeyCode = Keys.Right Then
            Grid2.Focus()
            Try
                Grid2.CurrentCell = Grid2.Rows(Grid1.CurrentRow.Index).Cells(1)
            Catch ex As Exception
                Grid2.CurrentCell = Grid2.Rows(Grid2.Rows.Count - 1).Cells(1)
            End Try
        End If
        If e.KeyCode = Keys.Down Then
            If Grid1.CurrentRow.Index = Grid1.Rows.Count - 1 Then
                Grid3.Focus()
                Grid3.CurrentCell = Grid3.Rows(0).Cells(1)
            End If
        End If
    End Sub
    Private Sub Grid2_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid2.KeyDown
        If e.KeyCode = Keys.Left Then
            Grid1.Focus()
            Try
                Grid1.CurrentCell = Grid1.Rows(Grid2.CurrentRow.Index).Cells(1)
            Catch ex As Exception
                Grid1.CurrentCell = Grid1.Rows(Grid1.RowCount - 1).Cells(1)
            End Try
        End If
        If e.KeyCode = Keys.Down Then
            If Grid2.CurrentRow.Index = Grid2.Rows.Count - 1 Then
                Grid4.Focus()
                Grid4.CurrentCell = Grid4.Rows(0).Cells(1)
            End If
        End If
    End Sub
    Private Sub Grid3_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid3.KeyDown
        If e.KeyCode = Keys.Right Then
            Grid4.Focus()
            Try
                Grid4.CurrentCell = Grid4.Rows(Grid3.CurrentRow.Index).Cells(1)
            Catch ex As Exception
                Grid4.CurrentCell = Grid4.Rows(Grid4.Rows.Count - 1).Cells(1)
            End Try
        End If
        If e.KeyCode = Keys.Up Then
            If Grid3.CurrentRow.Index = 0 Then
                Grid1.Focus()
                Grid1.CurrentCell = Grid1.Rows(Grid1.Rows.Count - 1).Cells(1)
            End If
        End If
    End Sub
    Private Sub Grid4_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid4.KeyDown
        If e.KeyCode = Keys.Left Then
            Grid3.Focus()
            Try
                Grid3.CurrentCell = Grid3.Rows(Grid4.CurrentRow.Index).Cells(1)
            Catch ex As Exception
                Grid3.CurrentCell = Grid3.Rows(Grid3.RowCount - 1).Cells(1)
            End Try
        End If
        If e.KeyCode = Keys.Up Then
            If Grid4.CurrentRow.Index = 0 Then
                Grid2.Focus()
                Grid2.CurrentCell = Grid2.Rows(Grid2.Rows.Count - 1).Cells(1)
            End If
        End If
    End Sub
    Private Sub Cell_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid1.KeyDown, Grid2.KeyDown, Grid3.KeyDown, Grid4.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim ro As DataGridViewRow = sender.CurrentRow
            Dim ID_ As String = ro.Cells(5).Value
            If ro.Cells(4).Value = "Account Group" Then
                Cell("Group Summary", "", "Display", ID_)
                Report_Group_Summary_frm.YN_Opning_Balance = False
                Report_Group_Summary_frm.Fill_Grid()
            ElseIf ro.Cells(4).Value = "Account Ledger" Then
                Cell("Report Ledger", "", "Display", ID_, Frm_date, to_date)
            ElseIf ro.Cells(4).Value = "Closing Stock" Then
                Cell("Group Stock Summary", "", "", "", "")
                Stock_Group_Summary_frm.To_Date_LB.Text = to_date
                Stock_Group_Summary_frm.Fill_Grid()
            ElseIf ro.Cells(4).Value = "Opning Stock" Then
                Cell("Group Stock Summary", "", "", "", "")
                Stock_Group_Summary_frm.To_Date_LB.Text = Frm_date
                Stock_Group_Summary_frm.Fill_Grid()
            ElseIf ro.Cells(4).Value = "Opning Group" Then
                Cell("Stock Summary", "", "Display", ID_, Company_Book_frm, Frm_date, "")
            ElseIf ro.Cells(4).Value = "Closing Group" Then
                Cell("Stock Summary", "", "Display", ID_, Frm_date, to_date, "")
            ElseIf ro.Cells(4).Value = "Payhead" Then
                Cell("Payroll Vouchers", 0, ID_)
            End If
            e.Handled = True
        End If
    End Sub
End Class