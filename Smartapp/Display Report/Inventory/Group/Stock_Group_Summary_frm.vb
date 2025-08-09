Imports System.Data.SqlClient
Imports System.Data.SQLite
Imports Microsoft.Reporting.WinForms
Imports PopupControl

Public Class Stock_Group_Summary_frm
    Dim From_ID As String
    Private Path_End As String
    Dim YN_Details As Boolean = True
    Dim Acc_Under As String
    Dim Frm_date As Date
    Dim to_date As Date
    Dim Date_Filter As String
    Dim Count_ As Integer

    Public Delete_Entry = False
    Dim Branch_ID As String = "0"
    Private Sub Stock_Group_Summary_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text

        To_Date_LB.Text = Date_2
        Frm_Date_LB.Text = Date_1

        BG_frm.HADE_TXT.Text = "Group Stock Summary"
        BG_frm.TYP_TXT.Text = "Display"
        Button_Manage()
        Add_Hander_Remove_Handel(True)

        If Link_Valu(3) = "0" Then
            dft_Godown_Name = Find_DT_Value(Database_File.cre, "TBL_Stock_Godown", "ID", "Name = '" & Link_Valu(3) & "'")
        End If

        Label4.Text = Dft_Branch
        Label2.Text = Dft_Valuation
        Label3.Text = dft_Godown_Name
    End Sub
    Private Function Button_Manage()
        Button_Clear()
        BG_frm.B_1.Text = "|&P : Print"

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
            If Branch_Visible() = True Then
                AddHandler BG_frm.R_5.Click, AddressOf Me.R_9_Click
            End If
            AddHandler BG_frm.R_6.Click, AddressOf Me.R_10_Click
            AddHandler BG_frm.R_7.Click, AddressOf Me.R_11_Click
        Else
            RemoveHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click

            RemoveHandler BG_frm.KeyDown, AddressOf Me.BG_Keydown
            RemoveHandler BG_frm.R_2.Click, AddressOf Me.R_3_Click
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
            'Dim paramtr(1) As ReportParameter
            'paramtr(0) = New ReportParameter("Account_prmt", Acc_LB.Text)
            'paramtr(1) = New ReportParameter("Date_prmt", Frm_Date_LB.Text)

            'Print_Priew_frm.ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dt_list", dt_print))
            'Print_Priew_frm.ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dt_cmp", Print_DT_Company))
            'Print_Priew_frm.Print_Privew(Application.StartupPath & "\Print_\Report\Item_Stock_Summary", "", paramtr)
        End If
    End Sub
    Private Sub R_3_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Set_Date(True, Me)
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
    Private Sub Stock_Group_Summary_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.HADE_TXT.Text = "Group Stock Summary"
        BG_frm.TYP_TXT.Text = "Display"

        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text

        cfg_Fill()

        Button_Clear()
        Button_Manage()

        Fill_Grid()

        Try
            Grid1.CurrentCell = Grid1.Rows(Alter_Tra_ID).Cells(2)
        Catch ex As Exception

        End Try

        Grid1.Focus()
    End Sub
    Private Function cfg_Fill()
        Branch_Panel.Visible = Branch_Visible()
        Godown_Panel.Visible = Godown_YN

    End Function
    Public Function Filter_Apply()
        Label4.Text = Dft_Branch
        Label2.Text = Dft_Valuation
        Label3.Text = dft_Godown_Name
        Fill_Grid()
    End Function
    Public Function Apply_Date_Filter(ifPeriod As Boolean)
        If ifPeriod = True Then
            To_Date_LB.Text = Date_Formate(Date_2)
            Frm_Date_LB.Text = Date_Formate(Date_1)
        Else
            To_Date_LB.Text = Date_Formate(Date_3)
        End If
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
        dt.Columns.Add("Quantity")
        dt.Columns.Add("Unit")
        dt.Columns.Add("Value")

        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            Fill_oTher_Group(cn, CDate(to_date))
        End If


        Dim dv As New DataView(dt)
        Dim Dt_set As New DataTable


        Grid1.DataSource = dv


        Grid1.Columns(0).Visible = False
        Grid1.Columns(1).Visible = False

        Grid1.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Grid1.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        Grid1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        Grid1.Columns(3).Width = 80
        Grid1.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        Grid1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Grid1.Columns(4).Width = 50
        Grid1.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        Grid1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        Grid1.Columns(5).Width = Label18.Width
        Grid1.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        Grid1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        BG_Panel.BringToFront()

        Label4.Text = Dft_Branch
        Label2.Text = Dft_Valuation
        Label3.Text = dft_Godown_Name
        Border_()

        If Grid1.Rows.Count > 0 Then
            Grid1.CurrentCell = Grid1.Rows(0).Cells(2)
        End If
    End Function
    Private Function Fill_oTher_Group(cn As SQLiteConnection, Date_ As Date)
        Dim Vlu As Decimal = 0.00
        Dim ToVlu As Decimal = 0.00
        Dim r As SQLiteDataReader


        Dim Qty_Total_Head As Decimal = 0.00
        Dim Unit_Allo_Head As Boolean = True
        Dim Unit_Total_Head As String = ""

        cmd = New SQLiteCommand($"Select '0' as 'ID','Primary' as 'Name' UNION ALL Select ID,[Name] From TBL_Stock_Group where {Company_Visible_Filter()}", cn)
        r = cmd.ExecuteReader
        While r.Read
            Dim cn1 As New SQLiteConnection
            Dim GR As String = r("ID")

            cmd = New SQLiteCommand($"Select it.id,it.name,(Select u.Symbol From TBL_Inventory_Unit u where u.ID = it.Unit) as Unit_Name,
ifnull(ifnull((SELECT ifnull(SUM(vi.Qty1) ,0)
From TBL_VC_item_Details vi
LEFT JOIN TBL_VC vc on vc.Tra_ID = vi.Tra_ID

where (vi.Type = 'Credit' and vc.Effect_Stock = 'Yes') and vi.Item = it.Id and vc.Visible = 'Approval' and (vc.[Date] <= @Filter_Date)) -
(SELECT ifnull(SUM(vi.Qty1) ,0)
From TBL_VC_item_Details vi
LEFT JOIN TBL_VC vc on vc.Tra_ID = vi.Tra_ID

where (vi.Type = 'Debit' and vc.Effect_Stock = 'Yes') and vi.Item = it.Id and vc.Visible = 'Approval' and (vc.[Date] <= @Filter_Date)),0) + ifnull(it.OB_Quantity,0),0) as Qty1 ,

ifnull((Case WHEN (@Valuation = 'At Zero Price' or (@Valuation = 'Default' and it.Costing_Value_Type = 'At Zero Price')) THEN
'0'
else (Case WHEN (@Valuation = 'Avg. Cost (as per period)' or (@Valuation = 'Default' and it.Costing_Value_Type = 'Avg. Cost (as per period)')) THEN
(SELECT ifnull(ifnull(SUM(vi.Amount1) ,0) / ifnull(ifnull(SUM(vi.Qty1),0),0),0) From TBL_VC_item_Details vi  where (vi.Type = 'Credit') and vi.Item = it.Id and (vi.Date BETWEEN '{CDate(Frm_date).ToString(Lite_date_Format)}' and '{CDate(to_date).AddDays(1).ToString(Lite_date_Format) }'))
else (Case WHEN (@Valuation = 'Avg. Price (as per period)' or (@Valuation = 'Default' and it.Costing_Value_Type = 'Avg. Price (as per period)')) THEN
(SELECT ifnull(ifnull(SUM(vi.Amount1) ,0) / ifnull(ifnull(SUM(vi.Qty1),0),0),0) From TBL_VC_item_Details vi  where (vi.Type = 'Debit') and vi.Item = it.Id and (vi.Date BETWEEN '{CDate(Frm_date).ToString(Lite_date_Format)}' and '{CDate(to_date).AddDays(1).ToString(Lite_date_Format) }'))

else (Case WHEN (@Valuation = 'Last Purchase Cost' or (@Valuation = 'Default' and it.Costing_Value_Type = 'Last Purchase Cost')) THEN
(SELECT ifnull(vi.Rate1 ,0) From TBL_VC_item_Details vi LEFT JOIN TBL_VC vc on vc.Tra_ID = vi.Tra_ID  where vc.Voucher_Type = 'Purchase' and vi.Item = it.Id and vc.Visible = 'Approval' and (vc.[Date] <= @Filter_Date) ORDER by vc.[date] DESC LIMIT 1)
else (Case WHEN (@Valuation = 'Last Sales Price' or (@Valuation = 'Default' and it.Costing_Value_Type = 'Last Sales Price')) THEN
(SELECT ifnull(vi.Rate1 ,0) From TBL_VC_item_Details vi LEFT JOIN TBL_VC vc on vc.Tra_ID = vi.Tra_ID  where vc.Voucher_Type = 'Sales' and vi.Item = it.Id and vc.Visible = 'Approval' and (vc.[Date] <= @Filter_Date) ORDER by vc.[date] DESC LIMIT 1)

else (Case WHEN (@Valuation = 'Std. Price' or (@Valuation = 'Default' and it.Costing_Value_Type = 'Std. Price')) THEN
(SELECT ifnull((std.Rate) ,0) From TBL_Item_Rate std where std.Item = it.id and std.Type = 'Price' and ([Date] <= @Filter_Date) ORDER BY [Date] DESC LIMIT 1)

else (Case WHEN (@Valuation = 'Std. Cost' or (@Valuation = 'Default' and it.Costing_Value_Type = 'Std. Cost')) THEN
(SELECT ifnull((std.Rate) ,0) From TBL_Item_Rate std where std.Item = it.id and std.Type = 'Cost' and ([Date] <= @Filter_Date) ORDER BY [Date] DESC LIMIT 1)

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
end),0) vlu

From TBL_Stock_Item it WHERE it.Under = '{GR}' and it.Visible = 'Approval'", cn1)
            With cmd.Parameters
                Vlu = 0.00
                .AddWithValue("Filter_Date", Date_.AddDays(1).ToString(Lite_date_Format))
                .AddWithValue("@Valuation", Dft_Valuation)

                'My.Computer.Clipboard.SetText(cmd.CommandText)

                If open_MSSQL_Cstm(Database_File.cre, cn1) = True Then
                    Dim r1 As SQLiteDataReader
                    r1 = cmd.ExecuteReader

                    Dim Qty_Total As Decimal = 0.00
                    Dim Unit_Allo As Boolean = True
                    Dim Unit_Total As String = ""

                    While r1.Read
                        Vlu += (Val(r1("Qty1") * r1("Vlu")))
                        Qty_Total += (Val(r1("Qty1")))


                        If Unit_Allo = True Then
                            If Unit_Total = "" Or Unit_Total = r1("Unit_Name").ToString Then
                                Unit_Total = r1("Unit_Name").ToString
                            Else
                                Unit_Allo = False
                            End If
                        End If

                    End While
                    If Val(Vlu) <> 0 Or Val(Qty_Total) <> 0 Then

                        Dim q As String
                        If Unit_Allo = False Then
                            Unit_Total = ""
                            q = ""
                        Else
                            q = N2_FORMATE(Qty_Total)
                            Qty_Total_Head += Val(Qty_Total)
                        End If

                        dt.Rows.Add("Head", r("ID"), r("Name"), q, Unit_Total, N2_FORMATE(Vlu))

                        If Alter_Tra_ID = r("ID").ToString Then
                            Alter_Tra_ID = dt.Rows.Count - 1
                        End If



                        If Unit_Allo_Head = True Then
                            If Unit_Total_Head = "" Or Unit_Total_Head = Unit_Total Or Unit_Total.ToString.Trim = "" Then
                                If Unit_Total.ToString.Trim <> "" Then
                                    Unit_Total_Head = Unit_Total
                                End If
                            Else
                                Unit_Allo_Head = False
                            End If
                        End If

                        ToVlu += nUmBeR_FORMATE(Vlu)
                    End If
                    r1.Close()
                End If
            End With
        End While
        r.Close()
        Label12.Text = N2_FORMATE(ToVlu)
        Label8.Text = $"{N2_FORMATE(Qty_Total_Head)} {Unit_Total_Head }"
        Label8.Visible = Unit_Allo_Head


    End Function
    Private Sub Stock_Group_Summary_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        Add_Hander_Remove_Handel(False)
        BG_frm.BG_Path_TXT.Text = Path_End
        Frm_foCus()
    End Sub

    Private Sub Stock_Group_Summary_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub
    Private Sub Grid1_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles Grid1.RowsAdded
        Grid1.Rows(Grid1.Rows.Count - 1).Height = 18
    End Sub
    Private Sub Frm_Date_LB_TextChanged(sender As Object, e As EventArgs) Handles Frm_Date_LB.TextChanged
        Frm_date = Date_Formate(Frm_Date_LB.Text)
    End Sub
    Private Sub To_Date_LB_TextChanged(sender As Object, e As EventArgs) Handles To_Date_LB.TextChanged
        to_date = Date_Formate(To_Date_LB.Text)
    End Sub

    Private Sub Grid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid1.CellContentClick

    End Sub

    Dim Alter_Tra_ID As String = ""
    Private Sub Grid1_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Alter_Tra_ID = (Grid1.CurrentRow.Cells(1).Value.ToString)
            Cell("Stock Summary", "", "Display", Grid1.CurrentRow.Cells(1).Value.ToString, Frm_date, to_date, "")
            e.Handled = True
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        Border_()
    End Sub
    Private Function Border_()
        Dim ctlpos As Point = Label9.PointToScreen(Label9.DisplayRectangle.Location)
        B1.Location = New Point(ctlpos.X, 0)
        B1.Height = Me.Height

        ctlpos = New Point
        ctlpos = Label18.PointToScreen(Label18.DisplayRectangle.Location)
        B2.Location = New Point(ctlpos.X, 0)
        B2.Height = Me.Height
    End Function

    Private Sub Stock_Group_Summary_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
        Grid1.Focus()
    End Sub

    Private Sub Load__DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)

    End Sub

    Private Sub Frm_Date_LB_Click(sender As Object, e As EventArgs) Handles Frm_Date_LB.Click

    End Sub
End Class