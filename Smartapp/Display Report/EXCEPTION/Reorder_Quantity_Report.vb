Imports System.Data.SqlClient
Imports System.Data.SQLite
Imports Microsoft.Reporting.WinForms
Imports PopupControl

Public Class Reorder_Quantity_Report
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

        To_Date_LB.Text = Date_3

        BG_frm.HADE_TXT.Text = "Reorder Stock Report"
        BG_frm.TYP_TXT.Text = "Display"
        Button_Manage()
        Add_Hander_Remove_Handel(True)

        If Link_Valu(3) = "0" Then
            dft_Godown_Name = Find_DT_Value(Database_File.cre, "TBL_Stock_Godown", "ID", $"Name = '{Link_Valu(3)}'")
        End If

        Label4.Text = Dft_Branch
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
            AddHandler BG_frm.R_7.Click, AddressOf Me.R_11_Click
        Else
            RemoveHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click

            RemoveHandler BG_frm.KeyDown, AddressOf Me.BG_Keydown
            RemoveHandler BG_frm.R_2.Click, AddressOf Me.R_3_Click
            If Branch_Visible() = True Then
                RemoveHandler BG_frm.R_5.Click, AddressOf Me.R_9_Click
            End If
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
            Set_Date(False, Me)
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
    Private Sub Stock_Group_Summary_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.HADE_TXT.Text = "Reorder Stock Report"
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
        Label3.Text = dft_Godown_Name
        Fill_Grid()
    End Function
    Public Function Apply_Date_Filter(ifPeriod As Boolean)
        If ifPeriod = True Then
            To_Date_LB.Text = Date_Formate(Date_3)
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
        dt.Columns.Add("Closing")
        dt.Columns.Add("Unit1")
        dt.Columns.Add("Reorder")
        dt.Columns.Add("Unit2")

        Dim OB_ As Decimal = 0 'Item_Stock(VC_ID_, CDate(My.Settings.Company_Opning_DAte), CDate(Frm_date))
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

        Grid1.Columns(5).Width = 80
        Grid1.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        Grid1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Grid1.Columns(6).Width = 50
        Grid1.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        Grid1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        BG_Panel.BringToFront()

        Label4.Text = Dft_Branch
        Label3.Text = dft_Godown_Name


        If Grid1.Rows.Count > 0 Then
            Grid1.CurrentCell = Grid1.Rows(0).Cells(2)
        End If
    End Function
    Dim ds_print As New Print_dt
    Dim dt_print As New DataTable
    Private Function Fill_oTher_Group(cn As SQLiteConnection, Date_ As Date) As Decimal
        dt_print.Rows.Clear()
        dt_print = ds_print.Tables("TBL_Item_Stock")
        Dim dr As DataRow
        Dim dr_Print As DataRow

        Dim Branch_Filter As String = ""
        If Dft_Branch <> "Primary" Then
            Branch_Filter = " AND VC.Branch = '" & Find_DT_Value(Database_File.cre, "TBL_Ledger", "ID", "Name = '" & Dft_Branch & "'") & "'"
        End If

        Dim Qty_source As String
        'Godown Filters
        Dim Godown_Filter As String = ""
        Dim Godown_LeftJoin As String = ""
        If dft_Godown_Name = "All Godown" Then
            Godown_LeftJoin = ""
            Qty_source = "vi"
            Godown_Filter = ""
        Else
            Godown_LeftJoin = "LEFT JOIN TBL_VC_Item_Other_Details vio on vio.TBL_VI = vi.ID"
            Qty_source = "vio"
            Godown_Filter = $" and vio.Godown = {Find_DT_Value(Database_File.cre, "TBL_Stock_Godown", "ID", "Name = '" & dft_Godown_Name & "'")}"
        End If

        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select it.id,it.name,it.Reorder_Qty,(SELECT un.Symbol From TBL_Inventory_Unit un where un.id = it.Unit) as Un,
ifnull(ifnull((SELECT ifnull(SUM({Qty_source}.Qty) ,0)
From TBL_VC_item_Details vi
LEFT JOIN TBL_VC vc on vc.Tra_ID = vi.Tra_ID
{Godown_LeftJoin}
where (vi.Type = 'Credit' and vc.Effect_Stock = 'Yes' and vc.Type = 'Head') and vi.Item = it.Id and vc.Visible = 'Approval' and (vc.[Date] <= @Filter_Date){Branch_Filter}{Godown_Filter}) -
(SELECT ifnull(SUM({Qty_source}.Qty) ,0)
From TBL_VC_item_Details vi
LEFT JOIN TBL_VC vc on vc.Tra_ID = vi.Tra_ID
{Godown_LeftJoin}
where (vi.Type = 'Debit' and vc.Effect_Stock = 'Yes' and vc.Type = 'Head') and vi.Item = it.Id and vc.Visible = 'Approval' and (vc.[Date] <= @Filter_Date){Branch_Filter}{Godown_Filter}),0) + (Select ifnull(sum(ios.Stock),0) From TBL_Stock_Item_Opning_Stock ios where ios.Item_ID = it.id and ios.Branch_ID = '{Branch_ID}'),0) as Qty

From TBL_Stock_Item it WHERE it.Visible = 'Approval'", cn)
            With cmd.Parameters
                .AddWithValue("@Filter_Date", to_date.AddDays(1).ToString(Lite_date_Format))
                Dim r1 As SQLiteDataReader
                r1 = cmd.ExecuteReader
                'My.Computer.Clipboard.SetText(cmd.CommandText)
                While r1.Read
                    'Dim Valu As String = Val(r1("Qty")) * Val(r1("Rate"))


                    dr = dt.NewRow
                    dr("Type") = "Head"
                    dr("ID") = r1("ID")
                    dr("Particulars") = r1("Name")
                    dr("Closing") = N2_FORMATE(Val(r1("Qty").ToString))
                    dr("Reorder") = N2_FORMATE(Val(r1("Reorder_Qty").ToString))
                    dr("Unit1") = r1("Un")
                    dr("Unit2") = r1("Un")

                    If Val(r1("Qty").ToString) <= Val(r1("Reorder_Qty").ToString) Then
                        dt.Rows.Add(dr)
                    End If

                    If Alter_Tra_ID = r1("ID").ToString Then
                        Alter_Tra_ID = dt.Rows.Count - 1
                    End If


                    'Total Unit Data Fill

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
    Private Sub To_Date_LB_TextChanged(sender As Object, e As EventArgs) Handles To_Date_LB.TextChanged
        to_date = Date_Formate(To_Date_LB.Text)
    End Sub

    Private Sub Grid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid1.CellContentClick

    End Sub

    Dim Alter_Tra_ID As String = ""
    Private Sub Grid1_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Alter_Tra_ID = (Grid1.CurrentRow.Cells(1).Value.ToString)
            Cell("Stock Item Monthly", "", "Display", Grid1.CurrentRow.Cells(1).Value, to_date)
            e.Handled = True
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        Dim ctlpos As Point = Label9.PointToScreen(Label9.DisplayRectangle.Location)
        B1.Location = New Point(ctlpos.X, 0)
        B1.Height = Me.Height

        ctlpos = New Point
        ctlpos = Label10.PointToScreen(Label10.DisplayRectangle.Location)
        B2.Location = New Point(ctlpos.X, 0)
        B2.Height = Me.Height
    End Sub

    Private Sub Stock_Group_Summary_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
        Grid1.Focus()
    End Sub
End Class