Imports System.Data.SQLite
Imports System.Web.UI.WebControls
Imports Microsoft.Reporting.WinForms
Imports PopupControl

Public Class Report_Stock_item_frm
    Dim From_ID As String
    Private VC_Type_ As String
    Private VC_ID_ As String
    Private Path_End As String
    Dim YN_Details As Boolean = True
    Dim Acc_Under As String
    Dim Frm_date As Date
    Dim to_date As Date
    Dim Count_ As Integer

    Public Delete_Entry = False

    Dim ds_print As New Print_dt
    Dim dt_print As New DataTable
    Dim Branch_ID As String = "0"

    Private Sub Report_Stock_item_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text

        VC_Type_ = Link_Valu(1)
        VC_ID_ = Link_Valu(2)

        Frm_Date_LB.Text = Link_Valu(3)
        To_Date_LB.Text = CDate(Link_Valu(4)).AddDays(0)


        BG_frm.HADE_TXT.Text = "Stock Item Vouchers"
        BG_frm.TYP_TXT.Text = VC_Type_
        Button_Manage()
        Add_Hander_Remove_Handel(True)

        Label10.Text = Dft_Branch
        Label14.Text = Dft_Valuation
        Label4.Text = dft_Godown_Name
        Update_Report = True
    End Sub
    Private Function Button_Manage()
        Button_Clear()
        BG_frm.B_1.Text = "Enter : Alter"
        BG_frm.B_2.Text = "|&D : Delete"
        BG_frm.B_3.Text = "|&R : Refresh"
        BG_frm.B_4.Text = "|&2 : Duplicate"
        BG_frm.B_5.Text = "|&A : Add Voucher"
        BG_frm.B_6.Text = "|&P : Print"
        BG_frm.B_7.Text = "Space : Select"

        BG_frm.R_1.Text = ""
        BG_frm.R_2.Text = "F2 : Date"
        BG_frm.R_3.Text = "|F2 : Period"
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
            AddHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
            AddHandler BG_frm.B_3.Click, AddressOf Me.B_3_Click
            AddHandler BG_frm.B_4.Click, AddressOf Me.B_4_Click
            AddHandler BG_frm.B_5.Click, AddressOf Me.B_5_Click
            AddHandler BG_frm.B_6.Click, AddressOf Me.B_6_Click
            AddHandler BG_frm.B_7.Click, AddressOf Me.B_7_Click

            AddHandler BG_frm.R_1.Click, AddressOf Me.R_1_Click
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
            RemoveHandler BG_frm.KeyDown, AddressOf Me.BG_Keydown
            RemoveHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            RemoveHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
            RemoveHandler BG_frm.B_3.Click, AddressOf Me.B_3_Click
            RemoveHandler BG_frm.B_4.Click, AddressOf Me.B_4_Click
            RemoveHandler BG_frm.B_5.Click, AddressOf Me.B_5_Click
            RemoveHandler BG_frm.B_6.Click, AddressOf Me.B_6_Click
            RemoveHandler BG_frm.B_7.Click, AddressOf Me.B_7_Click

            RemoveHandler BG_frm.R_1.Click, AddressOf Me.R_1_Click
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
        If BG_frm.HADE_TXT.Text = "Stock Item Vouchers" And BG_Panel.Visible = True Then
            If e.KeyCode = Keys.R AndAlso e.Modifiers = Keys.Alt Then
                BG_frm.B_3.PerformClick()
            End If
            If e.KeyCode = Keys.D2 AndAlso e.Modifiers = Keys.Alt Then
                BG_frm.B_4.PerformClick()
            End If
            If e.KeyCode = Keys.A AndAlso e.Modifiers = Keys.Alt Then
                BG_frm.B_5.PerformClick()
            End If
            If e.KeyCode = Keys.Space AndAlso e.Modifiers = Keys.Control Then
            ElseIf e.KeyCode = Keys.Space Then
                BG_frm.B_7.PerformClick()
            End If

            If e.KeyCode = Keys.F1 AndAlso e.Modifiers = Keys.Alt Then
                BG_frm.R_1.PerformClick()
            End If
            If e.KeyCode = Keys.F2 AndAlso e.Modifiers = Keys.Alt Then
                BG_frm.R_3.PerformClick()
            ElseIf e.KeyCode = Keys.F2 Then
                BG_frm.R_2.PerformClick()
            End If
            If e.KeyCode = Keys.F3 AndAlso e.Modifiers = Keys.Alt Then

            ElseIf e.KeyCode = Keys.F3 Then
                BG_frm.R_4.PerformClick()
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
            If Grid1.CurrentRow.Cells(2).Value.ToString = "Opning Stock" Then
                To_Date_LB.Text = Frm_Date_LB.Text
                Frm_Date_LB.Text = Company_Book_frm
                Fill_Grid()
            Else
                Cell("Voucher BG", Grid1.CurrentRow.Cells(15).Value, "Alter_Close", Grid1.CurrentRow.Cells(3).Value)
            End If
        End If
    End Sub
    Private Sub B_2_Click(sender As Object, e As EventArgs)
        Dim ro As Integer
        If BG_frm.HADE_TXT.Text = "Stock Item Vouchers" And BG_Panel.Visible = True Then
            If Msg_Yn("Are you source", "Delete Selected Voucher ?") = DialogResult.Yes Then
                For Each row_ As DataGridViewRow In Grid1.Rows
                    If row_.Cells(17).Value = True Then
                        If Delete_Vouchers(row_.Cells(15).Value, row_.Cells(3).Value) = False Then
                            Msg(NOT_Type.Erro, "Entry Delete Error", "Voucher No = " & row_.Cells(4).Value & ", Entry is Not Deleted")
                        End If
                    End If
                Next
                Dim cn As New SQLiteConnection
                If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                    'BG_frm.Voucher_BS.DataSource = Nothing
                    'BG_frm.Voucher_BS.DataSource = Fill_Vouchhers(cn)
                End If
                Fill_Grid()
            End If
        End If
    End Sub
    Private Sub B_3_Click(sender As Object, e As EventArgs)
        If BG_frm.HADE_TXT.Text = "Stock Item Vouchers" And BG_Panel.Visible = True Then
            Fill_Grid()
        End If
    End Sub
    Private Sub B_4_Click(sender As Object, e As EventArgs)
        If BG_frm.HADE_TXT.Text = "Stock Item Vouchers" And BG_Panel.Visible = True Then
            Cell("Voucher BG", Grid1.CurrentRow.Cells(15).Value, "Duplicate", Grid1.CurrentRow.Cells(3).Value)
        End If
    End Sub
    Private Sub B_5_Click(sender As Object, e As EventArgs)
        If BG_frm.HADE_TXT.Text = "Stock Item Vouchers" And BG_Panel.Visible = True Then
            Cell("Voucher BG", Grid1.CurrentRow.Cells(15).Value, "Create_Close", Grid1.CurrentRow.Cells(3).Value)
        End If
    End Sub
    Private Sub B_6_Click(sender As Object, e As EventArgs)
        If BG_frm.HADE_TXT.Text = "Stock Item Vouchers" And BG_Panel.Visible = True Then
            Dim paramtr(19) As ReportParameter
            'paramtr(0) = New ReportParameter("Item_prmt", Acc_LB.Text)
            'paramtr(1) = New ReportParameter("Date_prmt", Frm_Date_LB.Text & " to " & To_Date_LB.Text)
            'paramtr(2) = New ReportParameter("IR_Qty_OB_prmt", Grid1.Rows(0).Cells(6).Value.ToString)
            'paramtr(3) = New ReportParameter("IR_Rate_OB_prmt", Grid1.Rows(0).Cells(7).Value.ToString)
            'paramtr(4) = New ReportParameter("IR_Value_OB_prmt", Grid1.Rows(0).Cells(8).Value.ToString)

            'paramtr(5) = New ReportParameter("OW_Qty_OB_prmt", Grid1.Rows(0).Cells(9).Value.ToString)
            'paramtr(6) = New ReportParameter("OW_Rate_OB_prmt", Grid1.Rows(0).Cells(10).Value.ToString)
            'paramtr(7) = New ReportParameter("OW_Value_OB_prmt", Grid1.Rows(0).Cells(11).Value.ToString)

            'paramtr(8) = New ReportParameter("CL_Qty_OB_prmt", Grid1.Rows(0).Cells(12).Value.ToString)
            'paramtr(9) = New ReportParameter("CL_Rate_OB_prmt", Grid1.Rows(0).Cells(13).Value.ToString)
            'paramtr(10) = New ReportParameter("CL_Value_OB_prmt", Grid1.Rows(0).Cells(14).Value.ToString)

            'paramtr(11) = New ReportParameter("IR_Qty_To_prmt", Label11.Text.ToString)
            'paramtr(12) = New ReportParameter("IR_Rate_To_prmt", Label10.Text.ToString)
            'paramtr(13) = New ReportParameter("IR_Value_To_prmt", Label9.Text.ToString)

            'paramtr(14) = New ReportParameter("OW_Qty_To_prmt", Label5.Text.ToString)
            'paramtr(15) = New ReportParameter("OW_Rate_To_prmt", Label4.Text.ToString)
            'paramtr(16) = New ReportParameter("OW_Value_To_prmt", Label2.Text.ToString)

            'paramtr(17) = New ReportParameter("CL_Qty_To_prmt", Label8.Text.ToString)
            'paramtr(18) = New ReportParameter("CL_Rate_To_prmt", Label7.Text.ToString)
            'paramtr(19) = New ReportParameter("CL_Value_To_prmt", Label6.Text.ToString)


            Print_Priew_frm.ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dt_list", dt_print))
            Print_Priew_frm.ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dt_cmp", Print_DT_Company))
            Print_Priew_frm.Print_Privew(Application.StartupPath & "\Print_\Report\Item_Stock", "", paramtr)
        End If
    End Sub
    Private Sub B_7_Click(sender As Object, e As EventArgs)
        If BG_frm.HADE_TXT.Text = "Stock Item Vouchers" And BG_Panel.Visible = True And Grid1.CurrentRow.Cells(0).Value <> "OB" Then
            If Grid1.CurrentRow.Cells(17).Value = True Then
                Grid1.CurrentRow.Cells(17).Value = False
            ElseIf Grid1.CurrentRow.Cells(17).Value = False Then
                Grid1.CurrentRow.Cells(17).Value = True
            End If
        End If
    End Sub
    Private Sub B_8_Click(sender As Object, e As EventArgs)
        If Delete_Entry = False Then
            BG_frm.B_8.Text = "|&U : Hide Delete"
            Delete_Entry = True
        Else
            BG_frm.B_8.Text = "|&U : Show Delete"
            Delete_Entry = False
        End If
        Fill_Grid()
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
        If BG_frm.HADE_TXT.Text = "Stock Item Vouchers" And BG_Panel.Visible = True Then
            Set_Date(False, Me)
        End If
    End Sub
    Private Sub R_4_Click(sender As Object, e As EventArgs)
        If BG_frm.HADE_TXT.Text = "Stock Item Vouchers" And BG_Panel.Visible = True Then
            Set_Date(True, Me)
        End If
    End Sub
    Private Sub R_7_Click(sender As Object, e As EventArgs)
        If BG_frm.HADE_TXT.Text = "Stock Item Vouchers" And BG_Panel.Visible = True Then

        End If
    End Sub
    Private Sub R_9_Click(sender As Object, e As EventArgs)
        If BG_frm.HADE_TXT.Text = "Stock Item Vouchers" And BG_Panel.Visible = True Then
            Cell("Filter", "Branch", BG_frm.HADE_TXT.Text)
        End If
    End Sub
    Private Sub R_10_Click(sender As Object, e As EventArgs)
        If BG_frm.HADE_TXT.Text = "Stock Item Vouchers" And BG_Panel.Visible = True Then
            Cell("Filter", "Valuation", BG_frm.HADE_TXT.Text)
        End If
    End Sub
    Private Sub R_11_Click(sender As Object, e As EventArgs)
        If BG_frm.HADE_TXT.Text = "Stock Item Vouchers" And BG_Panel.Visible = True Then
            Cell("Filter", "Godown", BG_frm.HADE_TXT.Text)
        End If
    End Sub
    Public Function Filter_Apply()
        Label10.Text = Dft_Branch
        Label14.Text = Dft_Valuation
        Label4.Text = dft_Godown_Name
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
    Dim QTY_IN_TOtal As Decimal = 0
    Dim QTY_OW_TOtal As Decimal = 0
    Dim AMT_IN_TOtal As Decimal = 0
    Dim AMT_OW_TOtal As Decimal = 0
    Dim dt As New DataTable
    Public Function Fill_Grid()

        Branch_ID = Branch_ID_()

        Acc_LB.Text = Find_DT_Value(Database_File.cre, "TBL_Stock_Item", "Name", "ID = '" & VC_ID_ & "'")
        Acc_Under = Find_DT_Value(Database_File.cre, "TBL_Stock_Item", "Under", "ID = '" & VC_ID_ & "'")

        Unit_ID = Find_DT_Value(Database_File.cre, "TBL_Stock_Item", "Unit", $"ID = '{VC_ID_}'")
        Unit_Name = Find_DT_Unit_Conves(Unit_ID)

        QTY_IN_TOtal = 0
        QTY_OW_TOtal = 0
        AMT_IN_TOtal = 0
        AMT_OW_TOtal = 0
        Count_ = 0

        dt.Clear()
        dt.Columns.Clear()
        dt.Reset()
        Grid1.Columns.Clear()

        dt = New DataTable
        dt.Columns.Add("Type")
        dt.Columns.Add("Date").DataType = GetType(Date)
        dt.Columns.Add("Particulars")
        dt.Columns.Add("Voucher Type")
        dt.Columns.Add("Voucher No.")
        dt.Columns.Add("Unit")

        dt.Columns.Add("Quantity_IN")
        dt.Columns.Add("Rate_IN")
        dt.Columns.Add("Value_IN")

        dt.Columns.Add("Quantity_OW")
        dt.Columns.Add("Rate_OW")
        dt.Columns.Add("Value_OW")

        dt.Columns.Add("Quantity_CL")
        dt.Columns.Add("Rate_CL")
        dt.Columns.Add("Value_CL")

        dt.Columns.Add("Tra_ID")
        dt.Columns.Add("Status")


        Dim OB_ As Decimal = Item_Stock(VC_ID_, Unit_ID, CDate(Frm_date).AddDays(-1), "0")
        Dim OB_Rate_Vaue As Decimal = 0.00
        OB_Rate_Vaue = Rate_Valuation(Dft_Valuation, VC_ID_, to_date, Branch_ID)


        Fill_Opnig_Blanace(dt)
        Fill_oTher_Group(dt, OB_)

        Dim dv As New DataView(dt)
        Dim Dt_set As New DataTable
        dv.Sort = "Date"
        Dt_set = dv.ToTable


        Grid1.DataSource = dv


        Grid1.Columns(0).Visible = False
        Grid1.Columns(1).Visible = True
        Grid1.Columns(2).Visible = True
        Grid1.Columns(3).Visible = True
        Grid1.Columns(4).Visible = True
        Grid1.Columns(5).Visible = False
        Grid1.Columns(6).Visible = True
        Grid1.Columns(7).Visible = False
        Grid1.Columns(8).Visible = True
        Grid1.Columns(9).Visible = True
        Grid1.Columns(10).Visible = False
        Grid1.Columns(11).Visible = True
        Grid1.Columns(12).Visible = True
        Grid1.Columns(13).Visible = False
        Grid1.Columns(14).Visible = True
        Grid1.Columns(15).Visible = False
        Grid1.Columns(16).Visible = False

        Grid1.Columns(1).Width = 100
        Grid1.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Grid1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        Grid1.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Grid1.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        Grid1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        Grid1.Columns(3).Width = 117
        Grid1.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Grid1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        Grid1.Columns(4).Width = 102
        Grid1.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        Grid1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Grid1.Columns(5).Width = 50
        Grid1.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Grid1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        Grid1.Columns(6).HeaderText = "Inward Quantity"
        Grid1.Columns(6).Width = 103
        Grid1.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Grid1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Grid1.Columns(7).HeaderText = "Inward Rate"
        Grid1.Columns(7).Width = 103
        Grid1.Columns(7).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Grid1.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Grid1.Columns(8).HeaderText = "Inward Value"
        Grid1.Columns(8).Width = 103
        Grid1.Columns(8).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Grid1.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Grid1.Columns(9).HeaderText = "Outward Quantity"
        Grid1.Columns(9).Width = 103
        Grid1.Columns(9).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Grid1.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


        Grid1.Columns(10).HeaderText = "Outward Rate"
        Grid1.Columns(10).Width = 103
        Grid1.Columns(10).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Grid1.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Grid1.Columns(11).HeaderText = "Outward Value"
        Grid1.Columns(11).Width = 103
        Grid1.Columns(11).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Grid1.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Grid1.Columns(12).HeaderText = "Closing Quantity"
        Grid1.Columns(12).Width = 103
        Grid1.Columns(12).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Grid1.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Grid1.Columns(13).HeaderText = "Closing Rate"
        Grid1.Columns(13).Width = 103
        Grid1.Columns(13).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Grid1.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Grid1.Columns(14).HeaderText = "Closing Value"
        Grid1.Columns(14).Width = Label20.Width
        Grid1.Columns(14).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Grid1.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Grid1.Columns(15).Width = 103
        Grid1.Columns(15).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Grid1.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Dim chk As New DataGridViewCheckBoxColumn()
        Grid1.Columns.Add(chk)
        Grid1.Columns(17).Width = 30
        Grid1.Columns(17).Visible = False

        TableLayoutPanel3.Width = 210
        BG_Panel.BringToFront()

        Label11.Text = Back_Unit(QTY_IN_TOtal)
        Label5.Text = Back_Unit(QTY_OW_TOtal)
        Label9.Text = N2_FORMATE(AMT_IN_TOtal)
        Label2.Text = N2_FORMATE(AMT_OW_TOtal)


        Label24.Text = nUmBeR_FORMATE(QTY_IN_TOtal) + nUmBeR_FORMATE(Label28.Text)
        Label19.Text = N2_FORMATE(nUmBeR_FORMATE(AMT_IN_TOtal) + nUmBeR_FORMATE(Label32.Text))

        Label40.Text = nUmBeR_FORMATE(QTY_OW_TOtal) + nUmBeR_FORMATE(Label35.Text)
        Label39.Text = N2_FORMATE(nUmBeR_FORMATE(AMT_OW_TOtal) + nUmBeR_FORMATE(Label36.Text))



        Label24.Text = Back_Unit(Label24.Text)
        Label40.Text = Back_Unit(Label40.Text)

        Label8.Text = Back_Unit(Label8.Text)

        Label28.Text = Back_Unit(Label28.Text)
        Label35.Text = Back_Unit(Label35.Text)
        Label37.Text = Back_Unit(Label37.Text)



        Label16.Width = Label30.Width
        Label17.Width = Label31.Width
        Label28.Width = Label26.Width
        Label32.Width = Label27.Width + 2
        Label35.Width = Label22.Width + 2
        Label36.Width = Label23.Width + 2
        Label37.Width = Label21.Width + 2
        Label38.Width = Label20.Width + 2


        Grid1.Focus()

        'Label30.Width = Val(Grid1.Columns(1).Width)
        'Label34.Width = Val(Grid1.Columns(3).Width)
        'Label33.Width = Val(Grid1.Columns(4).Width)

        'Panel10.Width = (Val(Grid1.Columns(6).Width) * 3)
        'Panel19.Width = (Val(Grid1.Columns(6).Width) * 3)


        'Panel11.Width = (Val(Grid1.Columns(6).Width) * 3) - 1
        'Panel22.Width = (Val(Grid1.Columns(6).Width) * 3) - 1

        'Panel12.Width = (Val(Grid1.Columns(6).Width) * 3) - 1
        'Panel20.Width = (Val(Grid1.Columns(6).Width) * 3) - 1

        If Grid1.Rows.Count > 0 Then
            Grid1.CurrentCell = Grid1.Rows(0).Cells(1)
        End If
    End Function
    Dim Unit_Name As String
    Dim Unit_ID As String
    Private Function Fill_Opnig_Blanace(dt As DataTable)
        Dim in_q As Decimal = 0.00
        Dim in_a As Decimal = 0.00

        Dim out_q As Decimal = 0.00
        Dim out_a As Decimal = 0.00

        Dim ob_q As Decimal = Val(Find_DT_Value(Database_File.cre, "TBL_Stock_Item", "OB_Quantity", $"ID = '{VC_ID_}'"))
        Dim ob_a As Decimal = Val(Find_DT_Value(Database_File.cre, "TBL_Stock_Item", "OB_Value", $"ID = '{VC_ID_}'"))


        If ob_q > 0 Then
            in_q = ob_q
            in_a = ob_a
        Else
            out_q = ob_q * -1
            out_a = ob_a * -1
        End If
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select vi.Type,
CASE
WHEN '{Unit_ID}' = vi.Unit1 THEN SUM(vi.Qty1)
WHEN '{Unit_ID}' = vi.Unit2 THEN SUM(vi.Qty2)
ELSE SUM(vi.Qty)
END as Qty,

vi.Amount From TBL_VC_item_Details VI where VI.Item = '{VC_ID_}' and VI.Date <= '{CDate(Frm_date).AddDays(0).ToString(Lite_date_Format)}'", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                If r("Type").ToString = "Credit" Then
                    in_q += Val(r("Qty").ToString)
                    in_a += Val(r("Amount").ToString)
                ElseIf r("Type").ToString = "Debit" Then
                    out_q += Val(r("Qty").ToString)
                    out_a += Val(r("Amount").ToString)
                End If
            End While
            r.Close()

            Dim Rate_ As Decimal = 0.00

            If Dft_Valuation = "At Zero Price" Then
                Rate_ = 0.00
            ElseIf Dft_Valuation = "Avg. Price (as per period)" Then
                Try
                    Rate_ = out_a / out_q
                Catch ex As Exception

                End Try
            ElseIf Dft_Valuation = "Avg. Cost (as per period)" Then
                'MsgBox(in_a)
                'MsgBox(in_q)
                Try
                    Rate_ = in_a / in_q
                Catch ex As Exception

                End Try
            ElseIf Dft_Valuation = "Last Purchase Cost" Then
                If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                    cmd = New SQLiteCommand($"SELECT ifnull(vi.Rate ,0) as Rate_ From TBL_VC_item_Details vi LEFT JOIN TBL_VC vc on vc.Tra_ID = vi.Tra_ID where vc.Voucher_Type = 'Purchase' and vi.Item = '{VC_ID_}' and vc.Visible = 'Approval' and vc.Date <= '{CDate(Frm_date).AddDays(0).ToString(Lite_date_Format)}' ORDER by vc.[date] DESC LIMIT 1", cn)
                    Dim r1 As SQLiteDataReader
                    r1 = cmd.ExecuteReader
                    While r1.Read
                        Rate_ = Val(r1("Rate_").ToString)
                    End While
                End If
            ElseIf Dft_Valuation = "Last Sales Price" Then
                If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                    cmd = New SQLiteCommand($"SELECT ifnull(vi.Rate ,0) as Rate_ From TBL_VC_item_Details vi LEFT JOIN TBL_VC vc on vc.Tra_ID = vi.Tra_ID where vc.Voucher_Type = 'Sales' and vi.Item = '{VC_ID_}' and vc.Visible = 'Approval' and vc.Date <= '{CDate(Frm_date).AddDays(0).ToString(Lite_date_Format)}' ORDER by vc.[date] DESC LIMIT 1", cn)
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
                End If
            ElseIf Dft_Valuation = "Std. Cost" Then
                If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                    cmd = New SQLiteCommand($"SELECT ifnull((std.Rate) ,0) as Rate From TBL_Item_Rate std where std.Item = '{VC_ID_}' and std.Type = 'Cost' and ([Date] <= '{Frm_date.AddDays(0).ToString(Lite_date_Format)}') ORDER BY [Date] DESC LIMIT 1", cn)
                    Dim r1 As SQLiteDataReader
                    r1 = cmd.ExecuteReader
                    While r1.Read
                        Rate_ = Val(r1("Rate").ToString)
                    End While
                End If
            End If


            Dim Cl_qty As Decimal = in_q - out_q
            Dim Cl_amt As Decimal = Cl_qty * Rate_

            'dt.Rows.Add("OB", Company_Book_frm, "Opning Stock", "", "", "", N2_FORMATE(in_q), "", N2_FORMATE(in_a), N2_FORMATE(out_q), "", N2_FORMATE(out_a), N2_FORMATE(Cl_qty), N2_FORMATE(0.00), N2_FORMATE(Cl_amt))

            Label28.Text = N2_FORMATE(in_q)
            Label32.Text = N2_FORMATE(in_a)

            Label35.Text = N2_FORMATE(out_q)
            Label36.Text = N2_FORMATE(out_a)

            Label37.Text = N2_FORMATE(Cl_qty)
            Label38.Text = N2_FORMATE(Cl_amt)


        End If
    End Function
    Private Function Fill_oTher_Group(dt As DataTable, Closing_ As Decimal)
        dt_print.Rows.Clear()
        dt_print = ds_print.Tables("TBL_Item_Stock")
        Dim date_Filter As String = " and (vi.Date BETWEEN '" & CDate(Frm_Date_LB.Text).ToString(Lite_date_Format) & "' and '" & CDate(To_Date_LB.Text).AddDays(1).ToString(Lite_date_Format) & "')"



        Dim dr_Print As DataRow
        Dim dr As DataRow
        Dim cn As New SQLiteConnection

        Dim Closing_vlu_total As Decimal = 0
        Dim Godown_Filter As String = ""
        Dim Godown_LeftJoin As String = "LEFT JOIN TBL_VC_Item_Other_Details vio on vio.TBL_VI = vi.ID"

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


        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select vc.Tra_ID,vc.[Date],vc.Voucher_Type,vc.Voucher_No,(Select ld.name From TBL_Ledger ld where ld.id = vc.Ledger) as Ledger,vc.Visible,
(CASE WHEN vi.Type = 'Credit' THEN
SUM(vi.Qty)
ELSE(
'0.00'
)END) as Inward_qty,
(CASE WHEN vi.Type = 'Debit' THEN
SUM(vi.Qty)
ELSE(
'0.00'
)END) as Outward_qty,
(ifnull(sum(vi.Amount),0)/ifnull(SUM(vi.Qty),0)) as Rate,
ifnull((Case WHEN '{valu}' = 'At Zero Price' THEN
'0'
else (Case WHEN '{valu}' = 'Avg. Price (as per period)' THEN
(SELECT ifnull(SUM(vi.Amount),0)/ifnull(SUM(vi.Qty),0) From TBL_VC_item_Details vi {Godown_LeftJoin} where (vi.Type = 'Debit') and vi.Item = '{VC_ID_}' {date_Filter} {Godown_Filter})
else (Case WHEN '{valu}' = 'Avg. Cost (as per period)' THEN
(SELECT ifnull(SUM(vi.Amount),0)/ifnull(SUM(vi.Qty),0) From TBL_VC_item_Details vi {Godown_LeftJoin} where (vi.Type = 'Credit') and vi.Item = '{VC_ID_}' {date_Filter} {Godown_Filter})

else (Case WHEN '{valu}' = 'Last Sales Price' THEN
(SELECT ifnull(vi.Rate ,0) From TBL_VC_item_Details vi LEFT JOIN TBL_VC vc on vc.Tra_ID = vi.Tra_ID {Godown_LeftJoin} where vc.Voucher_Type = 'Sales' and vi.Item = '{VC_ID_}' and vc.Visible = 'Approval' {Godown_Filter}{date_Filter} ORDER by vc.[date] DESC LIMIT 1)
else (Case WHEN '{valu}' = 'Last Purchase Cost' THEN
(SELECT ifnull(vi.Rate ,0) From TBL_VC_item_Details vi LEFT JOIN TBL_VC vc on vc.Tra_ID = vi.Tra_ID {Godown_LeftJoin} where vc.Voucher_Type = 'Purchase' and vi.Item = '{VC_ID_}' and vc.Visible = 'Approval' {Godown_Filter}{date_Filter} ORDER by vc.[date] DESC LIMIT 1)

else (Case WHEN '{valu}' = 'Std. Cost' THEN
(SELECT ifnull((std.Rate) ,0) From TBL_Item_Rate std where std.Item = '{VC_ID_}' and std.Type = 'Cost' and ([Date] <= '{to_date.AddDays(1).ToString(Lite_date_Format)}') ORDER BY [Date] DESC LIMIT 1)
else (Case WHEN '{valu}' = 'Std. Price' THEN
(SELECT ifnull((std.Rate) ,0) From TBL_Item_Rate std where std.Item = '{VC_ID_}' and std.Type = 'Price' and ([Date] <= '{to_date.AddDays(1).ToString(Lite_date_Format)}') ORDER BY [Date] DESC LIMIT 1)

else (Case WHEN '{valu}' = 'Basic Purchase Rate' THEN
ifnull(it.Purchase_Rate,0)

else (Case WHEN '{valu}' = 'Basic Sales Rate' THEN
ifnull(it.Sales_Rate,0)

end)
end)
end)
end)
end)
end)
end)
end)
end),0) as std_rate

From TBL_VC vc
LEFT JOIN TBL_VC_item_Details vi on vi.Tra_ID = vc.Tra_ID
LEFT JOIN TBL_Stock_Item it on it.ID = '{VC_ID_}'
{Godown_LeftJoin}

where vi.Item = '{VC_ID_}' and vc.Effect_Stock = 'Yes' and vc.Visible = 'Approval' {Godown_Filter}{date_Filter} 

Group By vc.Tra_ID
ORDER BY vc.[Date]", cn)



            Dim r As SQLiteDataReader
            'My.Computer.Clipboard.SetText(cmd.CommandText)
            r = cmd.ExecuteReader
            While r.Read

                dr = dt.NewRow
                dr_Print = dt_print.NewRow
                dr("Tra_ID") = r("Tra_ID")
                dr("Type") = "Under"
                dr("Date") = CDate(r("Date")).ToString(Date_Format_fech)
                dr("Voucher Type") = r("Voucher_Type")
                dr("Voucher No.") = r("Voucher_No")
                dr("Unit") = ""
                dr("Particulars") = r("Ledger")

                If r("Visible") = "Approval" Then
                    dr("Status") = "Active"
                Else
                    dr("Status") = r("Visible")
                End If

                dr_Print("Date") = CDate(r("Date")).ToString(Date_Format_fech)
                dr_Print("Partiiculars") = r("Ledger")
                dr_Print("Voucher_Type") = r("Voucher_Type")
                dr_Print("Voucher_No") = r("Voucher_No")
                dr_Print("Unit") = ""

                dr("Quantity_OW") = Back_Unit(r("Outward_qty"))
                dr("Rate_OW") = N2_FORMATE(r("Rate"))
                dr("Value_OW") = N2_FORMATE(Val(r("Outward_qty")) * Val(r("Rate")))

                dr_Print("OW_Qty") = Back_Unit(r("Outward_qty"))
                dr_Print("OW_Rate") = N2_FORMATE(r("Rate"))
                dr_Print("OW_Value") = N2_FORMATE(Val(r("Outward_qty")) * Val(r("Rate")))


                QTY_OW_TOtal += Val(r("Outward_qty"))
                AMT_OW_TOtal += (Val(r("Outward_qty")) * Val(r("Rate")))
                Closing_ = Val(Closing_) - Val(r("Outward_qty"))

                dr("Quantity_IN") = Back_Unit(r("Inward_qty"))
                dr("Rate_IN") = N2_FORMATE(r("Rate"))
                dr("Value_IN") = N2_FORMATE(Val(r("Inward_qty")) * Val(r("Rate")))

                dr_Print("IW_Qty") = Back_Unit(r("Inward_qty"))
                dr_Print("IW_Rate") = N2_FORMATE(r("Rate"))
                dr_Print("IW_Value") = N2_FORMATE(Val(r("Inward_qty")) * Val(r("Rate")))
                QTY_IN_TOtal += Val(r("Inward_qty"))
                AMT_IN_TOtal += (Val(r("Inward_qty")) * Val(r("Rate")))
                Closing_ = Val(Closing_) + Val(r("Inward_qty"))

                dr("Quantity_CL") = Back_Unit(Closing_)
                dr("Rate_CL") = N2_FORMATE(r("std_rate"))
                dr("Value_CL") = N2_FORMATE(Val(Closing_) * Val(r("std_rate")))

                'MsgBox(r("std_rate"))

                dr_Print("CL_Qty") = Back_Unit(Closing_)
                dr_Print("CL_Rate") = N2_FORMATE(r("std_rate"))
                dr_Print("CL_Value") = N2_FORMATE(Val(Closing_) * Val(r("std_rate")))

                Closing_vlu_total = Val(Val(Closing_) * Val(r("std_rate")))

                dt.Rows.Add(dr)
                dt_print.Rows.Add(dr_Print)
            End While
            r.Close()
        End If
        Label8.Text = N2_FORMATE(Closing_)
        'Label7.Text = nUmBeR_FORMATE(Rate_Valu)

        Label6.Text = N2_FORMATE(Closing_vlu_total)
    End Function
    Private Function Back_Unit(vlu As String) As String
        If Val(vlu) = 0 Then
            Return ""
        Else
            Return N2_FORMATE(vlu) & $" {Unit_Name}"
        End If
    End Function
    Private Sub Report_Stock_item_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.HADE_TXT.Text = "Stock Item Vouchers"
        BG_frm.TYP_TXT.Text = VC_Type_

        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text
        cfg_Fill()
        Button_Clear()
        Button_Manage()

        If Update_Report = True Then
            Fill_Grid()
        End If
        Grid1.Focus()
    End Sub
    Private Function cfg_Fill()
        Branch_Panel.Visible = Branch_Visible()
        Godown_Panel.Visible = Godown_YN

        Label10.Text = Dft_Branch
        Label14.Text = Dft_Valuation
        Label4.Text = dft_Godown_Name

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

    Private Sub Grid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid1.CellContentClick

    End Sub

    Private Sub Grid1_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid1.KeyDown
        If e.KeyCode = Keys.Enter Then
            BG_frm.B_1.PerformClick()
        End If
    End Sub

    Private Sub Report_Stock_item_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub Report_Stock_item_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        Add_Hander_Remove_Handel(False)
        BG_frm.BG_Path_TXT.Text = Path_End
        Frm_foCus()
    End Sub

    Private Sub Grid1_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles Grid1.RowPrePaint
        Dim ro As DataGridViewRow = Grid1.Rows(e.RowIndex)
        ro.DefaultCellStyle.BackColor = Color.White
        ro.DefaultCellStyle.SelectionBackColor = Color.FromArgb(254, 197, 48)

        If ro.Cells(0).Value = "OB" Then
            ro.DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Bold )
            ro.Cells(1).Style.SelectionBackColor = Color.White
            ro.Cells(1).Style.ForeColor = Color.White
            ro.Cells(1).Style.SelectionForeColor = Color.White
        End If
        If Val(ro.Cells(12).Value.ToString) < 0 Then
            ro.Cells(12).Style.ForeColor = Color.Red
            ro.Cells(12).Style.SelectionForeColor = Color.Red
        End If
        If Val(ro.Cells(14).Value.ToString) < 0 Then
            ro.Cells(14).Style.ForeColor = Color.Red
            ro.Cells(14).Style.SelectionForeColor = Color.Red
        End If
    End Sub
    Private Sub Grid1_Paint(sender As Object, e As PaintEventArgs) Handles Grid1.Paint
        'DrawLinePoint(e)
    End Sub

    Private Sub Report_Stock_item_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID

        Grid1.Focus()
    End Sub

    Private Sub Panel7_Paint(sender As Object, e As PaintEventArgs) Handles Panel7.Paint
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


    End Sub
End Class