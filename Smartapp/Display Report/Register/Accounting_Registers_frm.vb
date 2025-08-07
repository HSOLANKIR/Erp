Imports System.Data.SQLite
Imports Microsoft.Reporting.WinForms
Imports PopupControl

Public Class Accounting_Registers_frm
    Dim From_ID As String
    Private VC_Type_ As String
    Private VC_ID_ As String
    Private RG_Yype_ As String
    Private Path_End As String
    Dim YN_Details As Boolean
    Dim Acc_Under As String
    Dim Frm_date As Date
    Dim to_date As Date
    Dim Count_ As Integer


    Dim ds_print As New Print_dt
    Dim dt_print As New DataTable

    Dim Branch_ID As String = 0
    Public it_id As Integer = 0
    Public it_name As String = ""

    Public ld_id As Integer = 0
    Public ld_name As String = ""

    Public Print_Head As String = ""
    Public Print_Date As String = ""

    Private Sub Report_Sales_Purchase_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text

        RG_Yype_ = Link_Valu(0)
        VC_Type_ = Link_Valu(1)
        VC_ID_ = Link_Valu(2)
        Frm_Date_LB.Text = Link_Valu(3)
        To_Date_LB.Text = Link_Valu(4)

        Acc_LB.Text = RG_Yype_ & " Register"
        BG_frm.HADE_TXT.Text = "Accounting Register"
        BG_frm.TYP_TXT.Text = VC_Type_
        Button_Manage()
        Add_Hander_Remove_Handel(True)

        fill_Data()
        List_Fill()

        Panel_manag(BG_Panel)
    End Sub
    Private Function Button_Manage()
        Button_Clear()
        BG_frm.B_1.Text = "Enter : Alter"
        BG_frm.B_2.Text = "|&D : Delete"
        BG_frm.B_3.Text = "|&R : Refresh"
        BG_frm.B_4.Text = "|&2 : Duplicate"
        BG_frm.B_5.Text = "|&A : Add Voucher"
        BG_frm.B_6.Text = "|&P : Print"
        BG_frm.B_7.Text = "||Space : Select All"

        BG_frm.R_1.Text = "|F1 : Detailed"
        BG_frm.R_2.Text = "F2 : Date"
        BG_frm.R_3.Text = "|F2 : Period"
        BG_frm.R_4.Text = ""
        If Branch_Visible() = True Then
            BG_frm.R_5.Text = "F4 : Branch"
        End If
        BG_frm.R_6.Text = "F5 : Filter"
        BG_frm.R_22.Text = "F12 : Configuration"
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
            AddHandler BG_frm.R_4.Click, AddressOf Me.R_6_Click
            AddHandler BG_frm.R_5.Click, AddressOf Me.R_9_Click
            AddHandler BG_frm.R_6.Click, AddressOf Me.R_7_Click
            AddHandler BG_frm.R_22.Click, AddressOf Me.R_22_Click
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
            RemoveHandler BG_frm.R_4.Click, AddressOf Me.R_6_Click
            RemoveHandler BG_frm.R_5.Click, AddressOf Me.R_9_Click
            RemoveHandler BG_frm.R_6.Click, AddressOf Me.R_7_Click
            RemoveHandler BG_frm.R_22.Click, AddressOf Me.R_22_Click
        End If
    End Function
    Private Sub BG_Keydown(sender As Object, e As KeyEventArgs)
        If BG_frm.From_ID = From_ID Then
            If e.KeyCode = Keys.D AndAlso e.Modifiers = Keys.Alt Then
                BG_frm.B_2.PerformClick()
            End If
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
                BG_frm.B_7.PerformClick()
            ElseIf e.KeyCode = Keys.Space Then
                BG_frm.B_6.PerformClick()
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
            If e.KeyCode = Keys.F12 Then
                BG_frm.R_22.PerformClick()
            End If
        End If
    End Sub
    Private Sub B_1_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Cell("Voucher BG", Grid1.CurrentRow.Cells(6).Value, "Alter_Close", RG_Yype_)
        End If
    End Sub
    Private Sub R_22_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Cell("Configuration", "Sales Purchase Register")
        End If
    End Sub
    Private Sub B_2_Click(sender As Object, e As EventArgs)
        Dim ro As Integer
        If BG_frm.From_ID = From_ID Then

        End If
    End Sub
    Private Sub B_3_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Fill_Grid()
        End If
    End Sub
    Private Sub B_4_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Cell("Voucher BG", Grid1.CurrentRow.Cells(6).Value, "Duplicate", RG_Yype_)
        End If
    End Sub
    Private Sub B_5_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Cell("Voucher BG", Grid1.CurrentRow.Cells(6).Value, "Create_Close", RG_Yype_, Grid1.CurrentRow.Cells(7).Value)
        End If
    End Sub
    Public cfg_print_path As String
    Dim rdlc_report_name As String
    Dim rdlc_report_data() As ReportDataSource
    Private Sub B_6_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Dim FIlter As String
            If ld_id <> 0 Then
                FIlter = $" ({Txt1.Text})"
            End If

            Print_Head = Acc_LB.Text & FIlter
            Print_Date = $"{Date_Formate(Frm_Date_LB.Text)} to {Date_Formate(To_Date_LB.Text)}"


            rdlc_report_name = $"{Acc_LB.Text} ({CDate(Frm_Date_LB.Text).ToString("dd-MMM-yyyy")} to {CDate(To_Date_LB.Text).ToString("dd-MMM-yyyy")})"
            rdlc_report_name = path_validation(rdlc_report_name, "-")
            rdlc_report_data = {New ReportDataSource("dt_register", dt_print), New ReportDataSource("dt_cmp", Print_DT_Company)}

            If cfg_print_path = Nothing Then
                cfg_print_path = Application.StartupPath & "\Print_\Report\Registers\Accountiong\F1"
            End If

            Printing_Direct_frm.Printing_(cfg_print_path, rdlc_report_name, "", rdlc_report_data)
        End If
    End Sub
    Private Sub B_7_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            If Grid1.DefaultCellStyle.BackColor = Color.FromArgb(170, 251, 236) Then
                Grid1.DefaultCellStyle.BackColor = Color.White
                Grid1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(254, 197, 48)
            Else
                Grid1.DefaultCellStyle.BackColor = Color.FromArgb(170, 251, 236)
                Grid1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(63, 239, 182)
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
    Private Sub R_6_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub R_9_Click(sender As Object, e As EventArgs)
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
    Private Sub R_7_Click(sender As Object, e As EventArgs)
        Panel_manag(Panel4)
        Ledgeer_Filter_TXT.Focus()
    End Sub
    Public Function Filter_Apply()
        Label17.Text = Dft_Branch
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
    Private Sub Report_Sales_Purchase_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.HADE_TXT.Text = "Accounting Register"
        BG_frm.TYP_TXT.Text = VC_Type_

        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text
        Button_Clear()
        Button_Manage()

        Fill_Grid()
    End Sub
    Private Sub Report_Sales_Purchase_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If BG_Panel.Visible = True Then
                Me.Dispose()
            Else
                Panel_manag(BG_Panel)
                Grid1.Focus()
            End If
        End If
    End Sub

    Private Sub Report_Sales_Purchase_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        Add_Hander_Remove_Handel(False)
        BG_frm.BG_Path_TXT.Text = Path_End
        Frm_foCus()
    End Sub
    Dim dt As New DataTable
    Public Function Fill_Grid()
        Branch_ID = Branch_ID_()

        dt.Clear()
        dt.Columns.Clear()
        dt.Reset()
        dt = New DataTable
        dt.Columns.Add("Type")
        dt.Columns.Add("Date").DataType = GetType(Date)
        dt.Columns.Add("Particulars")
        dt.Columns.Add("Voucher Type")
        dt.Columns.Add("Voucher No.")
        dt.Columns.Add("Amount")
        dt.Columns.Add("Tra_ID")
        dt.Columns.Add("vc_type_id")


        'BG_Panel.Hide()

        Fill_oTher_Group(dt)

        Dim dv As New DataView(dt)
        Dim Dt_set As New DataTable
        dv.Sort = "Date"
        Dt_set = dv.ToTable


        Grid1.DataSource = dv



        Grid1.Columns(0).Visible = False
        Grid1.Columns(6).Visible = False
        Grid1.Columns(7).Visible = False


        Grid1.Columns(1).Width = 100
        Grid1.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Grid1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        Grid1.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Grid1.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        Grid1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        'Grid1.Columns(2).Frozen = True

        Grid1.Columns(3).Width = 150
        Grid1.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Grid1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        Grid1.Columns(4).Width = 120
        Grid1.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Grid1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        Grid1.Columns(5).Width = 130
        Grid1.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Grid1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        BG_Panel.BringToFront()
        Count_ = 0

        Label17.Text = Dft_Branch
        Grid1.Focus()
        If Grid1.Rows.Count > 0 Then
            Grid1.CurrentCell = Grid1.Rows(0).Cells(1)
        End If

        Colunm_Filter_Apply()

        'TOTAL_Set
    End Function
    Public GST_YN As Boolean = True
    Public Transport_YN As Boolean = True
    Public Narration_YN As Boolean = False
    Public Tra_Name_YN As Boolean = True
    Public Vehicle_Type_YN As Boolean = True
    Public Vehicle_No_YN As Boolean = True
    Public Driver_YN As Boolean = False
    Public Driver_Phone_YN As Boolean = False
    Private Function Colunm_Filter_Apply()


    End Function
    Private Function Fill_oTher_Group(dt As DataTable)
        Dim dr_Print As DataRow
        dt_print.Rows.Clear()
        dt_print = ds_print.Tables("TBL_Acc_Register")
        Dim DAte_Filter As String = " (vc.Date BETWEEN '" & CDate(Frm_date).ToString(Lite_date_Format) & "' and '" & CDate(to_date).AddDays(1).ToString(Lite_date_Format) & "')"

        Dim Branch_Filter As String = ""
        If Branch_ID <> 0 Then
            Branch_Filter = " AND vc.Branch = '" & Branch_ID & "'"
        End If

        Dim vc_Filter As String = ""
        vc_Filter = $" and (vc.Voucher_Type = '{RG_Yype_}')"

        Dim ledger_filter As String = ""

        If ld_id = 0 Then
            ledger_filter = ""
        Else
            ledger_filter = $"and vl.Ledger = '{ld_id}'"
        End If

        Dim Total_ As Decimal = 0

        Dim dr As DataRow
        If open_MSSQL(Database_File.cre) = True Then

            Dim Q As String = ""

            Q = $"Select vc.Tra_ID,vc.Voucher_Type,vc.Voucher_No,vc.[Date],vc.Voucher_Type_ID,SUM(ifnull(vl.Cr,0)) as Cr,SUM(ifnull(vl.Dr,0)) as Dr,
(Select vcc.Name From TBL_Voucher_Create vcc where vcc.ID = vc.Voucher_Type_ID) as Voucher_Name,
(Select l.Name From TBL_Ledger l where l.ID = (Select vl1.Ledger From TBL_VC_Ledger vl1 where vl1.Tra_ID = vc.Tra_ID and vl1.Ledger <> vl.Ledger LIMIT 1)) as Ledger_Name
From TBL_VC_Ledger vl
Left Join TBL_VC vc on vc.Tra_ID = vl.Tra_ID
Where vc.Visible <> 'Delete' and {DAte_Filter} {vc_Filter}{ledger_filter}{Branch_Filter}
Group By vc.Tra_ID"


            cmd = New SQLiteCommand(Q, con)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            'My.Computer.Clipboard.SetText(cmd.CommandText)
            While r.Read
                Dim Amt_crdr As String = ""
                Dim Amt_ As Decimal = Val(r("Cr").ToString) + Val(r("Dr").ToString)

                If ld_id = 0 Then
                    Amt_ = Amt_ / 2
                End If


                Total_ += Amt_

                dr = dt.NewRow
                dr_Print = dt_print.NewRow

                dr("Type") = "Head"
                dr("Date") = Date_Formate(r("Date").ToString)
                dr("Voucher Type") = r("Voucher_Name").ToString
                dr("Voucher No.") = r("Voucher_No").ToString
                dr("Particulars") = r("Ledger_Name").ToString
                dr("Amount") = $"{N2_FORMATE(Amt_)} {Amt_crdr}"
                dr("Tra_ID") = (r("Tra_ID").ToString)
                dr("vc_type_id") = (r("Voucher_Type_ID").ToString)


                dr_Print("Date") = Date_Formate(r("Date").ToString)
                dr_Print("Type") = "Head"
                dr_Print("Partiiculars") = (r("Ledger_Name").ToString)
                dr_Print("Voucher_Type") = (r("Voucher_Name").ToString)
                dr_Print("Voucher_No") = (r("Voucher_No").ToString)
                dr_Print("Amount") = $"{N2_FORMATE(Amt_)} {Amt_crdr}"

                dt.Rows.Add(dr)
                dt_print.Rows.Add(dr_Print)

            End While
            r.Close()
        End If

        Total_Labale.Text = N2_FORMATE(Total_)
        Total_Vouchers_Label.Text = $"{(dt.Rows.Count)} Entry"

    End Function
    Private Sub Frm_Date_LB_TextChanged(sender As Object, e As EventArgs) Handles Frm_Date_LB.TextChanged
        Frm_date = Date_Formate(Frm_Date_LB.Text)
    End Sub
    Private Sub To_Date_LB_TextChanged(sender As Object, e As EventArgs) Handles To_Date_LB.TextChanged
        to_date = Date_Formate(To_Date_LB.Text)
    End Sub
    Private Sub Grid1_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid1.KeyDown
        If e.KeyCode = Keys.Enter Then
            BG_frm.B_1.PerformClick()
        End If
    End Sub
    Private Sub Grid1_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles Grid1.RowPrePaint
        Dim ro As DataGridViewRow = Grid1.Rows(e.RowIndex)
        If ro.Cells(0).Value = "Head" Or ro.Cells(0).Value = "Total" Then
            Count_ += 1

        Else
            ro.Visible = YN_Details
            ro.DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Italic)
            ro.DefaultCellStyle.ForeColor = Color.DimGray
            ro.Cells(1).Style.SelectionBackColor = Color.White
            ro.Cells(1).Style.ForeColor = Color.White
            ro.Cells(1).Style.SelectionForeColor = Color.White
            ro.Cells(2).Style.Padding = New Padding(20, 0, 0, 0)
            ro.Cells(5).Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        End If

        If ro.Cells(0).Value = "Total" Then
            ro.DefaultCellStyle.BackColor = Color.NavajoWhite

            ro.Cells(1).Style.SelectionBackColor = Color.NavajoWhite
            ro.Cells(1).Style.ForeColor = Color.NavajoWhite
            ro.Cells(1).Style.SelectionForeColor = Color.NavajoWhite
        Else
            ro.DefaultCellStyle.SelectionBackColor = Color.FromArgb(254, 197, 48)
            ro.DefaultCellStyle.BackColor = Color.White
        End If


    End Sub

    Private Sub Grid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid1.CellContentClick

    End Sub

    Private Sub Grid1_Paint(sender As Object, e As PaintEventArgs) Handles Grid1.Paint
        DrawLinePoint(e)
    End Sub
    Public Sub DrawLinePoint(ByVal e As PaintEventArgs)
        If Grid1.Rows.Count <> 0 Then
            Dim blackPen As New Pen(Color.Gray, 1)
            Dim font_ As Font = New Font("Arial", 10, FontStyle.Bold)
            Dim Brsh As New SolidBrush(Color.Black)

            Dim recf As New RectangleF(0, 0, 100, 20)
            Dim hh As New StringFormat
            hh.Alignment = StringAlignment.Far


            Dim ctlpos As Point = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(2, 0, False).Location)
            Dim point1 As New Point(ctlpos.X, 0)
            Dim point2 As New Point(ctlpos.X, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)

            ctlpos = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(3, 0, False).Location)
            point1 = New Point(ctlpos.X, 0)
            point2 = New Point(ctlpos.X, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)

            ctlpos = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(4, 0, False).Location)
            point1 = New Point(ctlpos.X, 0)
            point2 = New Point(ctlpos.X, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)


            ctlpos = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(5, 0, False).Location)
            point1 = New Point(ctlpos.X, 0)
            point2 = New Point(ctlpos.X, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)

            'Top
            point1 = New Point(0, Grid1.ColumnHeadersHeight)
            point2 = New Point(Grid1.Width, Grid1.ColumnHeadersHeight)
            e.Graphics.DrawLine(blackPen, point1, point2)

            point1 = New Point(0, 0)
            point2 = New Point(Grid1.Width, 0)
            e.Graphics.DrawLine(blackPen, point1, point2)

            'Bootom
            point1 = New Point(0, Grid1.Rows.Count * 18)
            point2 = New Point(Grid1.Width, Grid1.Rows.Count * 18)
            'e.Graphics.DrawLine(blackPen, point1, point2)

            point1 = New Point(0, Grid1.Height - 0)
            point2 = New Point(Grid1.Width, Grid1.Height - 0)
            'e.Graphics.DrawLine(New Pen(Color.Black, 4), point1, point2)

        End If
    End Sub
    Private Sub Report_Ledger_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
        Grid1.Focus()
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs)
        obj_top(sender)
    End Sub

    Private Sub Panel3_Paint_1(sender As Object, e As PaintEventArgs) Handles Panel3.Paint
        obj_top(sender)
    End Sub
    Dim ledger_list As List_frm
    Private Function List_Fill()
        obj_top(Panel3)

        ledger_list = New List_frm
        List_Setup("List of Accounting Ledger", Select_List.Botom_Center, Select_List_Format.Defolt, Ledgeer_Filter_TXT, ledger_list, Ledger_Source, Ledgeer_Filter_TXT.Width + 100)
    End Function
    Private Function fill_Data()
        Dim dt As New DataTable
        Dim cn As New SQLiteConnection

        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            dt = New DataTable
            dt.Columns.Add("Name")
            dt.Columns.Add("Group")
            dt.Columns.Add("ID")
            dt.Rows.Add("Not Applicable", "", "0")


            cmd = New SQLiteCommand("Select ld.name,ld.id,(select ag.name From TBL_Acc_Group ag where ag.id = ld.[Group]) as Under_Name From TBL_Ledger ld where ld.Visible = 'Approval'", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                dt.Rows.Add(r("Name"), r("Under_Name"), r("ID"))
            End While
            r.Close()
            Ledger_Source.DataSource = dt

        End If




    End Function
    Private Function Panel_manag(pan As Panel)
        Panel4.Visible = False
        BG_Panel.Visible = False

        pan.Dock = DockStyle.Fill
        pan.Visible = True
    End Function

    Public Function Save_Data()

    End Function
    Private Sub Ledgeer_Filter_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles Ledgeer_Filter_TXT.KeyDown
        If e.KeyCode = Keys.Enter Then
            ld_id = ledger_list.List_Grid.CurrentRow.Cells(2).Value
            ld_name = ledger_list.List_Grid.CurrentRow.Cells(0).Value.ToString
        End If
    End Sub

    Private Sub Txt1_TextChanged(sender As Object, e As EventArgs) Handles Txt1.TextChanged

    End Sub

    Private Sub Txt1_Enter(sender As Object, e As EventArgs) Handles Txt1.Enter
        Fill_Grid()
        Panel_manag(BG_Panel)
        Grid1.Focus()
    End Sub

    Private Sub Ledgeer_Filter_TXT_TextChanged(sender As Object, e As EventArgs) Handles Ledgeer_Filter_TXT.TextChanged

    End Sub
End Class