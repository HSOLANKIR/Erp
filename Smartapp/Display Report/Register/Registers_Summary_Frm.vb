Imports System.Data.SqlClient
Imports System.Data.SQLite
Imports Microsoft.Reporting.WinForms
Imports PopupControl

Public Class Registers_Summary_Frm
    Dim From_ID As String
    Private VC_Type_ As String
    Private VC_ID_ As String
    Private RG_Yype_ As String
    Public Path_End As String
    Dim YN_Details As Boolean
    Dim Acc_Under As String
    Dim to_date As Date

    Dim ds_print As New Print_dt
    Dim dt_print As New DataTable

    Dim Branch_ID As String = 0

    'Cfg
    Public Chart_YN As Boolean
    Public Chart_Type As String

    Public Periodicity As String
    Public Average_YN As Boolean = False
    Private Sub Report_Sales_Purchase_monthly_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text

        RG_Yype_ = Link_Valu(4).Split("|")(0)
        VC_Type_ = Link_Valu(1)
        VC_ID_ = Link_Valu(2)

        Dim date_ As Date = Date_Formate(Date_3)

        To_Date_LB.Text = Date_Formate(date_)

        Acc_LB.Text = RG_Yype_ & " Register"

        BG_frm.HADE_TXT.Text = "Vouchers Register Summary"
        BG_frm.TYP_TXT.Text = VC_Type_

        Button_Manage()
        Add_Hander_Remove_Handel(True)
    End Sub
    Private Function Button_Manage()
        Button_Clear()
        BG_frm.B_1.Text = "|&P : Print"
        BG_frm.B_3.Text = "|R : Refresh"


        BG_frm.R_1.Text = "|F1 : Detailed"
        BG_frm.R_2.Text = "F2 : Date"
        If Branch_Visible() = True Then
            BG_frm.R_5.Text = "F4 : Branch"
        End If
        BG_frm.R_3.Text = ""
        BG_frm.R_22.Text = "F12 : Configuration"
    End Function
    Private Function Add_Hander_Remove_Handel(Ans As Boolean)
        If Ans = True Then
            AddHandler BG_frm.KeyDown, AddressOf Me.BG_Keydown
            AddHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            AddHandler BG_frm.B_3.Click, AddressOf Me.B_3_Click

            AddHandler BG_frm.R_2.Click, AddressOf Me.R_2_Click
            AddHandler BG_frm.R_5.Click, AddressOf Me.R_5_Click

            AddHandler BG_frm.R_22.Click, AddressOf Me.R_22_Click
        Else
            RemoveHandler BG_frm.KeyDown, AddressOf Me.BG_Keydown
            RemoveHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            RemoveHandler BG_frm.B_3.Click, AddressOf Me.B_3_Click

            RemoveHandler BG_frm.R_2.Click, AddressOf Me.R_2_Click
            RemoveHandler BG_frm.R_5.Click, AddressOf Me.R_5_Click
            RemoveHandler BG_frm.R_22.Click, AddressOf Me.R_22_Click
        End If
    End Function
    Private Sub BG_Keydown(sender As Object, e As KeyEventArgs)
        If BG_frm.HADE_TXT.Text = "Vouchers Register Summary" Then
            If e.KeyCode = Keys.F1 AndAlso e.Modifiers = Keys.Alt Then
                'BG_frm.R_1.PerformClick()
            End If
            If e.KeyCode = Keys.F2 Then
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
            If e.KeyCode = Keys.F12 AndAlso e.Modifiers = Keys.Alt Then

            ElseIf e.KeyCode = Keys.F12 Then
                BG_frm.R_22.PerformClick()
            End If
        End If
    End Sub
    Private Sub R_1_Click(sender As Object, e As EventArgs)
        If BG_frm.HADE_TXT.Text = "Vouchers Register Summary" Then
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
    Public cfg_print_path As String
    Dim rdlc_report_name As String
    Dim rdlc_report_data() As ReportDataSource
    Private Sub B_1_Click(sender As Object, e As EventArgs)
        If BG_frm.HADE_TXT.Text = "Vouchers Register Summary" Then
            rdlc_report_name = $"{Acc_LB.Text} ({to_date.ToString("dd-MMM-yyyy")})"
            rdlc_report_name = path_validation(rdlc_report_name, "-")
            rdlc_report_data = {New ReportDataSource("dt_list", dt_print), New ReportDataSource("dt_cmp", Print_DT_Company)}

            If cfg_print_path = Nothing Then
                cfg_print_path = Application.StartupPath & "\Print_\Report\Sp_Monthly\Format 1"
            End If

            Printing_Direct_frm.Printing_(cfg_print_path, rdlc_report_name, "", rdlc_report_data)
        End If
    End Sub
    Private Sub R_2_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Set_Date(False, Me)
        End If
    End Sub
    Private Sub R_22_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Dim obj_bg As Object = Cell("Configuration", "")
            Dim obj As Object = New Registers_Summary_cfg
            obj.obj = Me
            obj_bg.Set_Cfg(obj)
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
    Public Function Filter_Apply()
        Label3.Text = Dft_Branch
        Fill_Grid()
    End Function
    Public Function Apply_Date_Filter(ifPeriod As Boolean)
        To_Date_LB.Text = Date_Formate(Date_3)
        Fill_Grid()
    End Function
    Private Sub B_3_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Fill_Grid()
        End If
    End Sub
    Private Sub Report_Sales_Purchase_monthly_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.HADE_TXT.Text = "Vouchers Register Summary"
        BG_frm.TYP_TXT.Text = VC_Type_

        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text
        Acc_LB.Text = RG_Yype_ & " Register"

        cfg_fill

        Button_Clear()
        Button_Manage()

        Label3.Visible = Branch_Visible()

        Fill_Grid()
    End Sub
    Public Function cfg_fill()

        Dim New_Tb As Boolean = Create_Database_Table()

        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.lnk, cn) = True Then
            cmd = New SQLiteCommand("Select * From cfg_Registers_Summary", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                If r("Head") = "Chart_YN" Then
                    Chart_YN = YN_Boolean(r("Value"))
                ElseIf r("Head") = "Chart_Type" Then
                    Chart_Type = (r("Value"))
                ElseIf r("Head") = "Print_Path" Then
                    cfg_print_path = (r("Value"))
                ElseIf r("Head") = "Periodicity" Then
                    Periodicity = (r("Value"))
                ElseIf r("Head") = "Average" Then
                    Average_YN = YN_Boolean(r("Value"))
                End If
            End While
            r.Close()
        End If

        If New_Tb = True Then
            Chart_YN = True
            Chart_Type = "Column"
            Periodicity = "Monthly"
        End If
        Panel3.Visible = Chart_YN
        Panel8.Visible = Average_YN

    End Function
    Public Function Create_Database_Table() As Boolean
        Dim cn As New SQLiteConnection
        Dim create_ As Boolean = False
        If open_MSSQL_Cstm(Database_File.lnk, cn) = True Then
            cmd = New SQLiteCommand("SELECT count(*) as c FROM sqlite_master WHERE type='table' AND name='cfg_Registers_Summary'", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                If r("c") <> 1 Then
                    create_ = True
                End If
            End While
            r.Close()


            If create_ = True Then
                cmd = New SQLiteCommand("CREATE TABLE 'cfg_Registers_Summary' (
	'Id'	INTEGER NOT NULL UNIQUE,
	'Head'	TEXT,
	'Value'	TEXT,
	PRIMARY KEY('Id' AUTOINCREMENT));", cn)

                cmd.ExecuteNonQuery()
            End If
        End If

        Return create_
    End Function
    Private Function Fill_Grid()
        Branch_ID = Branch_ID_()

        Chart_Setup()

        'Dim Dr_TO As Decimal = 0.00
        'Dim Cr_TO As Decimal = 0.00

        dt_print.Rows.Clear()
        dt_print = ds_print.Tables("TBL_Monthly")
        Dim dr_Print As DataRow


        Dim dt As New DataTable
        Dim dr As DataRow
        Dim Particuls As String

        Dim Closign As Decimal = 0.00


        dt.Clear()
        dt.Columns.Add("Type")
        dt.Columns.Add("Date_Frm").DataType = GetType(Date)
        dt.Columns.Add("Date_TO").DataType = GetType(Date)
        dt.Columns.Add("Particulars")
        dt.Columns.Add($"Net Transection")
        dt.Columns.Add("Closing Balance")
        dt.Columns.Add("Vouchers")

        Dim Closing_Total As String = 0
        Dim Company_Valu As Date = Company_Book_frm
        Dim Enrys As Integer = 0
        Dim Total_Entrys As Integer = 0

        Dim Branch_Filter As String = ""

        If Branch_ID <> 0 Then
            Branch_Filter &= " AND VC.Branch = '" & Branch_ID & "'"
        End If


        If open_MSSQL(Database_File.cre) = True Then
            Dim t As PeriodCity_Type = PeriodCity_Type.Monthly


            If Periodicity = "Fortnightly" Then t = PeriodCity_Type.Fortnightly
            If Periodicity = "Half Yearly" Then t = PeriodCity_Type.Half_Yearly
            If Periodicity = "Quarterly" Then t = PeriodCity_Type.Quarterly
            If Periodicity = "Yearly" Then t = PeriodCity_Type.Yearly




            For Each s As String In Date_PeriodCity(Date_3, t)
                Dim dt1 As Date = CDate(s.Split("*")(0))
                Dim dt2 As Date = CDate(s.Split("*")(1))

                Particuls = dt1.ToString("MMMM-yyyy")

                If Periodicity = "Fortnightly" Then Particuls = dt1.ToString("dd-MM-yyyy") & " to " & dt2.ToString("dd-MM-yyyy")
                If Periodicity = "Half Yearly" Then Particuls = dt1.ToString("dd-MM-yyyy") & " to " & dt2.ToString("dd-MM-yyyy")
                If Periodicity = "Quarterly" Then Particuls = $"Q{dt.Rows.Count + 1} ({dt1.ToString("dd-MM-yyyy") & " to " & dt2.ToString("dd-MM-yyyy")})"
                If Periodicity = "Yearly" Then Particuls = $"{dt1.ToString("yyyy")}-{dt1.AddYears(1).ToString("yy")}"


                Dim Total As String = 0
                Dim Date_Filter As String = $"(Date >= '{dt1.ToString(Lite_date_Format)}' and Date < '{dt2.AddDays(1).ToString(Lite_date_Format)}')"

                Dim Q As String = ""

                Q = $"Select SUM(vc.Debit_Amount) + SUM(vc.Credit_Amount) as vlu,count(vc.ID) as Count_ From TBL_VC vc
where (vc.Voucher_Type = '{RG_Yype_}') and {Date_Filter}{Branch_Filter} and Visible <> 'Delete'"

                cmd = New SQLiteCommand(Q, con)


                Dim r As SQLiteDataReader
                r = cmd.ExecuteReader
                dr = dt.NewRow
                dr_Print = dt_print.NewRow

                dr("Particulars") = Particuls
                dr("Date_frm") = CDate(dt1)
                dr("Date_TO") = CDate(dt2)

                dr_Print("Partiiculars") = Particuls

                While r.Read
                    Enrys = r("Count_")
                    Total_Entrys += Enrys
                    dr("Vouchers") = Enrys

                    Dim vlu As String = r("vlu").ToString
                    Total = Val(Total) + Format(Val(vlu), "0.00")
                    Closing_Total = Val(Closing_Total) + Val(vlu)

                End While
                r.Close()

                If Val(Total) = 0 Then
                    Total = ""
                Else
                    Total = nUmBeR_FORMATE(Total)
                End If


                dr("Net Transection") = N2_FORMATE(Total)
                dr("Closing Balance") = N2_FORMATE(Closing_Total)

                dr_Print("Entry") = N2_FORMATE(Enrys).Replace(".00", "")
                dr_Print("Cr_Amount") = (Total)
                dr_Print("Cl_Amount") = N2_FORMATE(Closing_Total)


                dt.Rows.Add(dr)
                dt_print.Rows.Add(dr_Print)

                Chart1.Series(0).Points.AddXY((Particuls), Total)

                Closign += Val(Total)
            Next
        End If


        Label2.Text = Format(Val(Closing_Total), "N2")
        Label1.Text = (Val(Total_Entrys)) & " Vch."
        Label8.Text = N2_FORMATE(Val(Closing_Total) / Val(Grid1.Rows.Count))


        Dim dv As New DataView(dt)
        Dim Dt_set As New DataTable
        dv.Sort = "Date_frm"
        Dt_set = dv.ToTable


        Grid1.DataSource = dv


        Grid1.Columns(0).Visible = False
        Grid1.Columns(1).Visible = False
        Grid1.Columns(2).Visible = False

        Grid1.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Grid1.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        Grid1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        Grid1.Columns(4).Width = 130
        Grid1.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        Grid1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Label4.Width = Grid1.Columns(4).Width

        Grid1.Columns(5).Width = 130
        Grid1.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        Grid1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Grid1.Columns(5).DefaultCellStyle.Font = New Font("Arial", 9.75!, FontStyle.Bold)
        Grid1.Columns(5).DefaultCellStyle.ForeColor = Color.SaddleBrown
        Label2.Width = Grid1.Columns(5).Width


        Grid1.Columns(6).DisplayIndex = 4
        Grid1.Columns(6).Width = 80
        Grid1.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Grid1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Label1.Width = Grid1.Columns(6).Width


        Grid1.DefaultCellStyle.BackColor = Color.White
        Grid1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(254, 197, 48)

        Grid1.Focus()
    End Function
    Private Function Chart_Setup()
        Grid1.Focus()

        If Chart_YN = True Then
            Dim Series1 As DataVisualization.Charting.Series = New DataVisualization.Charting.Series()
            With Series1
                .IsValueShownAsLabel = True
                .ChartArea = "ChartArea1"
                .Legend = "Legend1"
                .Name = RG_Yype_

                If Chart_Type = "Column" Then .ChartType = DataVisualization.Charting.SeriesChartType.Column
                If Chart_Type = "Line" Then .ChartType = DataVisualization.Charting.SeriesChartType.Line
                If Chart_Type = "Spline" Then .ChartType = DataVisualization.Charting.SeriesChartType.Spline
                If Chart_Type = "Area" Then .ChartType = DataVisualization.Charting.SeriesChartType.Area
                If Chart_Type = "Range" Then .ChartType = DataVisualization.Charting.SeriesChartType.Range


                .BorderWidth = 2

                If RG_Yype_ = "Purchase" Then .Color = Color.Blue
                If RG_Yype_ = "Sales" Then .Color = Color.Red
                If RG_Yype_ = "Payment" Then .Color = Color.MediumTurquoise
                If RG_Yype_ = "Receipt" Then .Color = Color.Coral
                If RG_Yype_ = "Contra" Then .Color = Color.DarkKhaki
                If RG_Yype_ = "Journal" Then .Color = Color.Khaki
                If RG_Yype_ = "Sales Order" Then .Color = Color.DodgerBlue
                If RG_Yype_ = "Purchase Order" Then .Color = Color.HotPink
                If RG_Yype_ = "Stock Journal" Then .Color = Color.Orange


                Chart1.Series.Clear()

                Me.Chart1.Series.Add(Series1)

                Me.Chart1.Size = New Size(1246, 209)
                Me.Chart1.Text = "Chart1"

            End With
        End If
    End Function
    Private Sub Grid1_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim d1 As Date = CDate(Grid1.CurrentRow.Cells(1).Value)
            Dim d2 As Date = CDate(Grid1.CurrentRow.Cells(2).Value).AddDays(0)

            If RG_Yype_ = "Payment" Or RG_Yype_ = "Receipt" Or RG_Yype_ = "Contra" Or RG_Yype_ = "Journal" Then
                Cell("Accounting Register", RG_Yype_, "Display", "", d1, d2, Dft_Branch)
            Else
                Cell("Inventory Register", RG_Yype_, "Display", "", d1, d2, Dft_Branch)
            End If
        End If
    End Sub
    Private Sub Report_Sales_Purchase_monthly_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub Report_Sales_Purchase_monthly_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End
        Add_Hander_Remove_Handel(False)
        Frm_foCus()
    End Sub
    Private Sub To_Date_LB_TextChanged(sender As Object, e As EventArgs) Handles To_Date_LB.TextChanged
        to_date = Date_Formate(To_Date_LB.Text)
    End Sub
    Private Sub Grid1_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles Grid1.RowsAdded
        Grid1.Rows(Grid1.Rows.Count - 1).Height = 18
    End Sub

    Private Sub Grid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid1.CellContentClick

    End Sub

    Private Sub Grid1_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles Grid1.EditingControlShowing
    End Sub
    Public Sub DrawLinePoint(ByVal e As PaintEventArgs)
        If Grid1.RowCount <> 0 Then
            Dim blackPen As New Pen(Color.Gray, 1)
            Dim x As Decimal = Val(Grid1.Width) - Val(Grid1.Columns(4).Width) - Val(Grid1.Columns(5).Width) - Val(Grid1.Columns(6).Width)
            Dim point1 As Point = New Point(x, 0)
            Dim point2 As Point = New Point(x, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)

            x = Val(Grid1.Width) - Val(Grid1.Columns(4).Width) - Val(Grid1.Columns(5).Width)
            point1 = New Point(x, 0)
            point2 = New Point(x, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)

            x = Val(Grid1.Width) - Val(Grid1.Columns(4).Width)
            point1 = New Point(x, 0)
            point2 = New Point(x, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)

            point1 = New Point(0, 20)
            point2 = New Point(Grid1.Width, 20)
            e.Graphics.DrawLine(blackPen, point1, point2)

            point1 = New Point(0, 0)
            point2 = New Point(Grid1.Width, 0)
            e.Graphics.DrawLine(blackPen, point1, point2)
        End If
    End Sub

    Private Sub Grid1_Paint(sender As Object, e As PaintEventArgs) Handles Grid1.Paint
        DrawLinePoint(e)

    End Sub

    Private Sub Report_Sales_Purchase_monthly_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
        Grid1.Focus()
    End Sub
End Class