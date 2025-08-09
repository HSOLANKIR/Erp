Imports System.Data.SqlClient
Imports System.Data.SQLite
Imports Microsoft.Reporting.WinForms
Imports PopupControl

Public Class Report_Stock_Summary_frm
    Dim From_ID As String
    Private VC_Type_ As String
    Private VC_ID_ As String
    Private Path_End As String
    Dim To_date As Date
    Dim Frm_date As Date
    Dim Date_Filter As String
    Dim Count_ As Integer

    Dim ds_print As New Print_dt
    Dim dt_print As New DataTable

    Dim Branch_ID As String = "0"
    Private Sub Report_Stock_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text

        VC_Type_ = Link_Valu(1)
        VC_ID_ = Link_Valu(2)

        'MsgBox(VC_ID_)

        'To_Date_LB.Text = Link_Valu(4)

        To_Date_LB.Text = Date_2
        Frm_Date_LB.Text = Date_1


        BG_frm.HADE_TXT.Text = "Stock Summary"
        BG_frm.TYP_TXT.Text = VC_Type_
        Acc_LB.Text = Find_DT_Value(Database_File.cre, "TBL_Stock_Group", "Name", $"ID = '{VC_ID_}'")

        Button_Manage()
        Add_Hander_Remove_Handel(True)

        Label10.Text = Dft_Branch
        Label14.Text = Dft_Valuation
        Label4.Text = dft_Godown_Name
        Update_Report = True
    End Sub
    Private Function Button_Manage()
        Button_Clear()
        BG_frm.B_1.Text = "|&P : Print"
        BG_frm.B_3.Text = "|&R : Refresh"
        'BG_frm.R_3.Text = "|F3 : Expiry Date Report"

        BG_frm.R_1.Text = ""
        BG_frm.R_2.Text = "F2 : Date"
        If Branch_Visible() = True Then
            BG_frm.R_5.Text = "F4 : Branch"
        End If
        BG_frm.R_6.Text = "F5 : Valuation"
        If Godown_YN = True Then
            BG_frm.R_7.Text = "F6 : Godown"
        End If
    End Function
    Private Function Add_Hander_Remove_Handel(Ans As Boolean)
        If Ans = True Then
            AddHandler BG_frm.KeyDown, AddressOf Me.BG_Keydown
            AddHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click

            AddHandler BG_frm.R_2.Click, AddressOf Me.R_3_Click
            AddHandler BG_frm.R_3.Click, AddressOf Me.R_4_Click
            If Branch_Visible() = True Then
                AddHandler BG_frm.R_5.Click, AddressOf Me.R_9_Click
            End If
            AddHandler BG_frm.R_6.Click, AddressOf Me.R_10_Click

            If Godown_YN = True Then
                AddHandler BG_frm.R_7.Click, AddressOf Me.R_11_Click
            End If
        Else
            RemoveHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click

            RemoveHandler BG_frm.KeyDown, AddressOf Me.BG_Keydown
            RemoveHandler BG_frm.R_2.Click, AddressOf Me.R_3_Click
            RemoveHandler BG_frm.R_3.Click, AddressOf Me.R_4_Click
            If Branch_Visible() = True Then
                RemoveHandler BG_frm.R_5.Click, AddressOf Me.R_9_Click
            End If
            RemoveHandler BG_frm.R_6.Click, AddressOf Me.R_10_Click

            RemoveHandler BG_frm.R_7.Click, AddressOf Me.R_11_Click
        End If
    End Function
    Private Sub BG_Keydown(sender As Object, e As KeyEventArgs)
        If BG_frm.From_ID = From_ID Then
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

    Private Sub B_1_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Dim paramtr(1) As ReportParameter
            paramtr(0) = New ReportParameter("Account_prmt", Acc_LB.Text)
            paramtr(1) = New ReportParameter("Date_prmt", To_Date_LB.Text)

            Print_Priew_frm.ReportViewer1.LocalReport.DataSources.Add(New ReportDataSource("dt_list", dt_print))
            Print_Priew_frm.ReportViewer1.LocalReport.DataSources.Add(New ReportDataSource("dt_cmp", Print_DT_Company))
            Print_Priew_frm.Print_Privew(Application.StartupPath & "\Print_\Report\Item_Stock_Summary", "", paramtr)
        End If
    End Sub
    Private Sub R_3_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Set_Date(True, Me)
        End If
    End Sub
    Private Sub R_4_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            'Cell("Stock Summary (Expiry Date Report)", VC_ID_, Frm_date, To_date)
        End If
    End Sub
    Private Sub R_9_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Cell("Filter", "Branch", BG_frm.HADE_TXT.Text)
        End If
    End Sub
    Private Sub R_11_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Cell("Filter", "Godown", BG_frm.HADE_TXT.Text)
        End If
    End Sub
    Private Sub R_10_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Cell("Filter", "Valuation", BG_frm.HADE_TXT.Text)
        End If
    End Sub
    Private Sub Report_Stock_Summary_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.HADE_TXT.Text = "Stock Summary"
        BG_frm.TYP_TXT.Text = VC_Type_

        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text
        Button_Clear()
        Button_Manage()
        cfg_Fill()

        Fill_Grid()
        Grid1.Focus()

        Try
            Grid1.CurrentCell = Grid1.Rows(Alter_Tra_ID).Cells(2)
        Catch ex As Exception

        End Try
    End Sub
    Private Function cfg_Fill()
        Branch_Panel.Visible = Branch_Visible()
        Godown_Panel.Visible = Godown_YN

    End Function

    Private Sub Report_Stock_Summary_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub Report_Stock_Summary_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        Add_Hander_Remove_Handel(False)
        BG_frm.BG_Path_TXT.Text = Path_End
        Frm_foCus()
    End Sub
    Public Function Filter_Apply()
        Label10.Text = Dft_Branch
        Label14.Text = Dft_Valuation
        Label4.Text = dft_Godown_Name
        Fill_Grid()
    End Function
    Public Function Apply_Date_Filter(ifPeriod As Boolean)
        Frm_Date_LB.Text = Date_Formate(Date_1)
        To_Date_LB.Text = Date_Formate(Date_2)

        Fill_Grid()
    End Function
    Dim QTY_IN_TOtal As Decimal = 0
    Dim QTY_OW_TOtal As Decimal = 0
    Dim AMT_IN_TOtal As Decimal = 0
    Dim AMT_OW_TOtal As Decimal = 0
    Dim dt As New DataTable
    Public Function Fill_Grid()
        Branch_ID = Branch_ID_()

        QTY_IN_TOtal = 0
        QTY_OW_TOtal = 0
        AMT_IN_TOtal = 0
        AMT_OW_TOtal = 0
        Count_ = 0

        dt.Clear()
        dt.Columns.Clear()
        dt.Reset()
        dt = New DataTable
        dt.Columns.Add("Type")
        dt.Columns.Add("ID")
        dt.Columns.Add("Particulars")
        dt.Columns.Add("Opning_Q")
        dt.Columns.Add("Opning_Unit")
        dt.Columns.Add("Inward_Q")
        dt.Columns.Add("Inward_U")
        dt.Columns.Add("Inward_V")
        dt.Columns.Add("Outward_Q")
        dt.Columns.Add("Outward_U")
        dt.Columns.Add("Outward_V")
        dt.Columns.Add("Closing_Q")
        dt.Columns.Add("Closing_U")
        dt.Columns.Add("Closing_V")


        Fill_oTher_Group1(Date_Filter, dt)

        Dim dv As New DataView(dt)
        Dim Dt_set As New DataTable


        Grid1.DataSource = dv


        Grid1.Columns("Type").Visible = False
        Grid1.Columns("ID").Visible = False

        With Grid1.Columns("Particulars")
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        With Grid1.Columns("Opning_Q")
            Dim L As Label = Label17
            .Visible = L.Visible
            .Width = L.Width - 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Regular)
        End With
        With Grid1.Columns("Opning_Unit")
            Dim L As Label = Label17
            .Visible = L.Visible
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Italic)
        End With
        With Grid1.Columns("Inward_Q")
            Dim L As Label = Label24
            .Visible = L.Visible
            .Width = L.Width - 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Regular)
        End With
        With Grid1.Columns("Inward_U")
            Dim L As Label = Label24
            .Visible = L.Visible
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Italic)
        End With
        With Grid1.Columns("Inward_V")
            Dim L As Label = Label26
            .Visible = L.Visible
            .Width = L.Width
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Regular)
        End With
        With Grid1.Columns("Outward_Q")
            Dim L As Label = Label20
            .Visible = L.Visible
            .Width = L.Width - 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Regular)
        End With
        With Grid1.Columns("Outward_U")
            Dim L As Label = Label26
            .Visible = L.Visible
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Italic)
        End With
        With Grid1.Columns("Outward_V")
            Dim L As Label = Label22
            .Visible = L.Visible
            .Width = L.Width
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Regular)
        End With
        With Grid1.Columns("Closing_Q")
            Dim L As Label = Label19
            .Visible = L.Visible
            .Width = L.Width - 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        With Grid1.Columns("Closing_U")
            Dim L As Label = Label19
            .Visible = L.Visible
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        With Grid1.Columns("Closing_V")
            Dim L As Label = Label16
            .Visible = L.Visible
            .Width = L.Width
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With

        BG_Panel.BringToFront()

        Label10.Text = Dft_Branch
        Label14.Text = Dft_Valuation
        Label4.Text = dft_Godown_Name


        Panel19.Width = Panel19.Width
        TO_CL_Value.Width = Label16.Width
        TO_CL_Qty.Width = Label19.Width

        Panel23.Width = Panel18.Width
        TO_Ow_Value.Width = Label22.Width
        TO_Ow_Qty.Width = Label20.Width

        Panel26.Width = Panel21.Width
        TO_In_Value.Width = Label26.Width
        TO_In_Qty.Width = Label24.Width

        Panel27.Width = Panel10.Width
        TO_Op_Qty.Width = Label17.Width

        Grid1.Focus()


        Border_()

        'Panel19.Width = (Val(Grid1.Columns(3).Width))
        'Label2.Width = (Val(Grid1.Columns(2).Width))

        If Grid1.Rows.Count > 0 Then
            Grid1.CurrentCell = Grid1.Rows(0).Cells(2)
        End If
    End Function
    Private Function Fill_oTher_Group1(Date_Filter As String, dt As DataTable)
        dt_print.Rows.Clear()
        dt_print = ds_print.Tables("TBL_Item_Stock")
        Dim Rate_Valu As String
        Dim dr As DataRow
        Dim dr_Print As DataRow
        Dim cn As New SQLiteConnection

        Dim TO_Op_Qty_ As Decimal = 0.00

        Dim TO_IN_Qty_ As Decimal = 0.00
        Dim TO_IN_Value_ As Decimal = 0

        Dim TO_OW_Qty_ As Decimal = 0.00
        Dim TO_OW_Value_ As Decimal = 0

        Dim TO_CL_Qty_ As Decimal = 0.00
        Dim TO_CL_Value_ As Decimal = 0

        Dim Unit_Allo As Boolean = True
        Dim Unit_Total As String = ""


        Dim Opning_Date As String = $" and (vi.[Date] <= '{Frm_date.AddDays(0).ToString(Lite_date_Format)}')"
        Dim Period_Date As String = $" and (vi.Date BETWEEN '{CDate(Frm_date).ToString(Lite_date_Format)}' and '{CDate(To_date).AddDays(1).ToString(Lite_date_Format)}')"

        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select it.id,it.name,(SELECT un.Symbol From TBL_Inventory_Unit un where un.id = it.Unit) as Un,
ifnull(ifnull((SELECT ifnull(SUM(vi.Qty1) ,0)
From TBL_VC_item_Details vi
where (vi.Type = 'Credit') and vi.Item = it.Id {Opning_Date}) -

(SELECT ifnull(SUM(vi.Qty1) ,0)
From TBL_VC_item_Details vi
where (vi.Type = 'Debit') and vi.Item = it.Id {Opning_Date}),0) + ifnull(it.OB_Quantity,0),0) as Opning,

(SELECT ifnull(SUM(vi.Qty1) ,0)
From TBL_VC_item_Details vi

where (vi.Type = 'Credit') and vi.Item = it.Id {Period_Date}) as In_Q,

(SELECT ifnull(SUM(vi.Qty1) ,0)
From TBL_VC_item_Details vi
where (vi.Type = 'Debit') and vi.Item = it.Id {Period_Date}) as Out_Q,

(SELECT ifnull(SUM(vi.Amount1) ,0)
From TBL_VC_item_Details vi
where (vi.Type = 'Credit') and vi.Item = it.Id {Period_Date}) as In_V,

(SELECT ifnull(SUM(vi.Amount1) ,0)
From TBL_VC_item_Details vi
where (vi.Type = 'Debit') and vi.Item = it.Id {Period_Date}) as Out_V,



ifnull((Case WHEN (@Valuation = 'At Zero Price' or (@Valuation = 'Default' and it.Costing_Value_Type = 'At Zero Price')) THEN
'0'
else (Case WHEN (@Valuation = 'Avg. Cost (as per period)' or (@Valuation = 'Default' and it.Costing_Value_Type = 'Avg. Cost (as per period)')) THEN
(SELECT ifnull(ifnull(SUM(vi.Amount1) ,0) / ifnull(ifnull(SUM(vi.Qty1),0),0),0) From TBL_VC_item_Details vi LEFT JOIN TBL_VC where (vi.Type = 'Credit') and vi.Item = it.Id and (vi.Date BETWEEN '{CDate(Frm_date).ToString(Lite_date_Format)}' and '{CDate(To_date).AddDays(1).ToString(Lite_date_Format) }'))
else (Case WHEN (@Valuation = 'Avg. Price (as per period)' or (@Valuation = 'Default' and it.Costing_Value_Type = 'Avg. Price (as per period)')) THEN
(SELECT ifnull(ifnull(SUM(vi.Amount1) ,0) / ifnull(ifnull(SUM(vi.Qty1),0),0),0) From TBL_VC_item_Details vi LEFT JOIN TBL_VC  where (vi.Type = 'Debit') and vi.Item = it.Id and (vi.Date BETWEEN '{CDate(Frm_date).ToString(Lite_date_Format)}' and '{CDate(To_date).AddDays(1).ToString(Lite_date_Format) }'))

else (Case WHEN (@Valuation = 'Last Purchase Cost' or (@Valuation = 'Default' and it.Costing_Value_Type = 'Last Purchase Cost')) THEN
(SELECT ifnull(vi.Rate1 ,0) From TBL_VC_item_Details vi LEFT JOIN TBL_VC vc on vc.Tra_ID = vi.Tra_ID where vc.Voucher_Type = 'Purchase' and vi.Item = it.Id and vc.Visible = 'Approval' and (vc.[Date] <= @Filter_Date) ORDER by vc.[date] DESC LIMIT 1)
else (Case WHEN (@Valuation = 'Last Sales Price' or (@Valuation = 'Default' and it.Costing_Value_Type = 'Last Sales Price')) THEN
(SELECT ifnull(vi.Rate1 ,0) From TBL_VC_item_Details vi LEFT JOIN TBL_VC vc on vc.Tra_ID = vi.Tra_ID where vc.Voucher_Type = 'Sales' and vi.Item = it.Id and vc.Visible = 'Approval' and (vc.[Date] <= @Filter_Date) ORDER by vc.[date] DESC LIMIT 1)


else (Case WHEN (@Valuation = 'Std. Price' or (@Valuation = 'Default' and it.Costing_Value_Type = 'Std. Price')) THEN
(SELECT ifnull((std.Rate) ,0) From TBL_Item_Rate std where std.Item = it.id  and std.Type = 'Price' and ([Date] <= @Filter_Date) ORDER BY [Date] DESC LIMIT 1)

else (Case WHEN (@Valuation = 'Std. Cost' or (@Valuation = 'Default' and it.Costing_Value_Type = 'Std. Cost')) THEN
(SELECT ifnull((std.Rate) ,0) From TBL_Item_Rate std where std.Item = it.id  and std.Type = 'Cost' and ([Date] <= @Filter_Date) ORDER BY [Date] DESC LIMIT 1)

else (Case WHEN (@Valuation = 'Basic Purchase Rate' or (@Valuation = 'Default' and it.Costing_Value_Type = 'Basic Purchase Rate')) THEN
ifnull(it.Purchase_Rate,0)

else (Case WHEN (@Valuation = 'Basic Sales Rate' or (@Valuation = 'Default' and it.Costing_Value_Type = 'Basic Sales Rate')) THEN
ifnull(it.Sales_Rate,0)

end)
end)
end)
end)
end)
end)
end)
end)
end),0) Rate1

From TBL_Stock_Item it WHERE it.Under = '{VC_ID_ }' and it.Visible = 'Approval'", cn)
            With cmd.Parameters
                .AddWithValue("@Filter_Date", To_date.AddDays(1).ToString(Lite_date_Format))
                .AddWithValue("@Valuation", Dft_Valuation)
                Dim r1 As SQLiteDataReader
                r1 = cmd.ExecuteReader
                'My.Computer.Clipboard.SetText(cmd.CommandText)
                While r1.Read
                    Dim CLosing_vlu As Decimal = (Val(r1("Opning")) + (Val(r1("In_Q")) - Val(r1("Out_Q"))))
                    Dim Valu As String = CLosing_vlu * Val(r1("Rate1"))

                    dr = dt.NewRow
                    dr("ID") = r1("ID")
                    dr("Particulars") = r1("Name")
                    dr("Opning_Q") = N2_FORMATE(Val(r1("Opning").ToString))
                    dr("Inward_Q") = N2_FORMATE(Val(r1("In_Q").ToString))
                    dr("Inward_V") = N2_FORMATE(Val(r1("In_V").ToString))
                    dr("Outward_Q") = N2_FORMATE(Val(r1("Out_Q").ToString))
                    dr("Outward_V") = N2_FORMATE(Val(r1("Out_V").ToString))

                    dr("Closing_Q") = N2_FORMATE(CLosing_vlu)
                    dr("Closing_V") = N2_FORMATE(CLosing_vlu * Val(r1("Rate1").ToString))

                    If Val(r1("Opning").ToString) <> 0 Then
                        dr("Opning_Unit") = r1("Un").ToString
                    End If
                    If Val(r1("In_Q").ToString) <> 0 Then
                        dr("Inward_U") = r1("Un").ToString
                    End If
                    If Val(r1("Out_Q").ToString) <> 0 Then
                        dr("Outward_U") = r1("Un").ToString
                    End If
                    If Val(CLosing_vlu) <> 0 Then
                        dr("Closing_U") = r1("Un").ToString
                    End If



                    If Val(r1("Opning")) <> 0 Or Val(r1("In_Q")) <> 0 Or Val(r1("Out_Q")) <> 0 Then
                        dt.Rows.Add(dr)
                    End If

                    If Alter_Tra_ID = r1("ID").ToString Then
                        Alter_Tra_ID = dt.Rows.Count - 1
                    End If


                    'Total Unit Data Fill

                    If Unit_Allo = True Then
                        If Unit_Total = "" Or Unit_Total = r1("Un") Then
                            Unit_Total = r1("Un")
                        Else
                            Unit_Allo = False
                        End If
                    End If

                    TO_Op_Qty_ += Val(Val(r1("Opning").ToString))

                    TO_IN_Qty_ += Val(Val(r1("In_Q").ToString))
                    TO_IN_Value_ += Val(Val(r1("In_V").ToString))

                    TO_OW_Qty_ += Val(Val(r1("Out_Q").ToString))
                    TO_OW_Value_ += Val(Val(r1("Out_V").ToString))

                    TO_CL_Qty_ += Val(CLosing_vlu)
                    TO_CL_Value_ += Valu

                    'dr_Print = dt_print.NewRow
                    'dr_Print("Partiiculars") = r1("Name")
                    'dr_Print("CL_Qty") = N2_FORMATE(Val(r1("Qty").ToString))
                    'dr_Print("CL_Rate") = N2_FORMATE(r1("Rate").ToString)
                    'dr_Print("CL_Value") = N2_FORMATE(Valu)
                    'If Val(r1("Qty")) <> 0 Then
                    '    dt_print.Rows.Add(dr_Print)
                    'End If

                End While
            End With

        End If

        TO_Op_Qty.Text = $"{N2_FORMATE(TO_Op_Qty_)} {Unit_Total}"

        TO_In_Value.Text = N2_FORMATE(TO_IN_Value_)
        TO_In_Qty.Text = $"{N2_FORMATE(TO_IN_Qty_)} {Unit_Total}"

        TO_Ow_Value.Text = N2_FORMATE(TO_OW_Value_)
        TO_Ow_Qty.Text = $"{N2_FORMATE(TO_OW_Qty_)} {Unit_Total}"

        TO_CL_Value.Text = N2_FORMATE(TO_CL_Value_)
        TO_CL_Qty.Text = $"{N2_FORMATE(TO_CL_Qty_)} {Unit_Total}"

        TO_Op_Qty.Visible = Unit_Allo
        TO_In_Qty.Visible = Unit_Allo
        TO_Ow_Qty.Visible = Unit_Allo
        TO_CL_Qty.Visible = Unit_Allo
    End Function
    Private Sub Grid1_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles Grid1.RowsAdded
        Grid1.Rows(Grid1.Rows.Count - 1).Height = 18
    End Sub
    Dim Alter_Tra_ID As String = ""
    Private Sub Grid1_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Alter_Tra_ID = (Grid1.CurrentRow.Cells(1).Value.ToString)
            Cell("Stock Item Monthly", "", "Display", Grid1.CurrentRow.Cells(1).Value, To_date)
            e.Handled = True
        End If
    End Sub
    Private Sub Grid1_Paint(sender As Object, e As PaintEventArgs) Handles Grid1.Paint

    End Sub

    Private Sub Report_Stock_Summary_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
        Grid1.Focus()
    End Sub
    Private Sub Frm_Date_LB_TextChanged(sender As Object, e As EventArgs) Handles Frm_Date_LB.TextChanged
        Frm_date = Date_Formate(Frm_Date_LB.Text)
    End Sub
    Private Sub To_Date_LB_TextChanged(sender As Object, e As EventArgs) Handles To_Date_LB.TextChanged
        To_date = Date_Formate(To_Date_LB.Text)
    End Sub

    Private Sub Grid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid1.CellContentClick

    End Sub

    Private Function Border_()
        With Panel10
            Dim P As Panel = B1
            Dim ctlpos As Point = .PointToScreen(.DisplayRectangle.Location)
            P.Location = New Point(ctlpos.X, 0)
            P.Height = Me.Height
            P.Visible = .Visible
        End With
        With Panel21
            Dim P As Panel = B2
            Dim ctlpos As Point = .PointToScreen(.DisplayRectangle.Location)
            P.Location = New Point(ctlpos.X, 0)
            P.Height = Me.Height
            P.Visible = .Visible
        End With
        With Panel18
            Dim P As Panel = B3
            Dim ctlpos As Point = .PointToScreen(.DisplayRectangle.Location)
            P.Location = New Point(ctlpos.X, 0)
            P.Height = Me.Height
            P.Visible = .Visible
        End With
        With Panel11
            Dim P As Panel = B4
            Dim ctlpos As Point = .PointToScreen(.DisplayRectangle.Location)
            P.Location = New Point(ctlpos.X, 0)
            P.Height = Me.Height
            P.Visible = .Visible
        End With

    End Function

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        Border_()
    End Sub
End Class