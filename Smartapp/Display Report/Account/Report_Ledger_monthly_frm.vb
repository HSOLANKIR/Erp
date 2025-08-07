Imports System.Data.SqlClient
Imports System.Data.SQLite
Imports Microsoft.Reporting.WinForms
Imports PopupControl

Public Class Report_Ledger_monthly_frm
    Dim From_ID As String
    Private VC_Type_ As String
    Private VC_ID_ As String
    Public Path_End As String
    Dim YN_Details As Boolean
    Dim Acc_Under As String
    Dim Frm_date As Date
    Dim to_date As Date
    Dim suggest_date As Date


    Dim ds_print As New Print_dt
    Dim dt_print As New DataTable
    Private Sub Report_Ledger_monthly_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text

        VC_Type_ = Link_Valu(1)
        VC_ID_ = Link_Valu(2)

        Frm_Date_LB.Text = Link_Valu(3)
        To_Date_LB.Text = Link_Valu(4)

        suggest_date = Link_Valu(7)

        BG_frm.HADE_TXT.Text = "Report Ledger Monthly"
        BG_frm.TYP_TXT.Text = VC_Type_

        Button_Manage()
        Add_Hander_Remove_Handel(True)
        Update_Report = True

        Label12.Text = "Voucher Type : " & Dft_Voucher
    End Sub
    Private Function Button_Manage()
        Button_Clear()

        BG_frm.B_1.Text = "|&P : Print"

        BG_frm.R_1.Text = "|F1 : Detailed"
        BG_frm.R_2.Text = "|F2 : Peiod"
        BG_frm.R_4.Text = "F3 : Voucher Type"
        BG_frm.R_3.Text = ""
    End Function
    Private Function Add_Hander_Remove_Handel(Ans As Boolean)
        If Ans = True Then
            AddHandler BG_frm.KeyDown, AddressOf Me.BG_Keydown
            AddHandler BG_frm.B_1.Click, AddressOf Me.B_3_Click

            AddHandler BG_frm.R_1.Click, AddressOf Me.R_1_Click
            AddHandler BG_frm.R_2.Click, AddressOf Me.R_2_Click
            AddHandler BG_frm.R_4.Click, AddressOf Me.R_6_Click
        Else
            RemoveHandler BG_frm.KeyDown, AddressOf Me.BG_Keydown
            RemoveHandler BG_frm.B_1.Click, AddressOf Me.B_3_Click

            RemoveHandler BG_frm.R_2.Click, AddressOf Me.R_2_Click
            RemoveHandler BG_frm.R_4.Click, AddressOf Me.R_6_Click
        End If
    End Function
    Private Sub BG_Keydown(sender As Object, e As KeyEventArgs)
        If BG_frm.HADE_TXT.Text = "Report Ledger Monthly" Then
            If e.KeyCode = Keys.F1 AndAlso e.Modifiers = Keys.Alt Then
                BG_frm.R_1.PerformClick()
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
        End If
    End Sub
    Private Sub R_1_Click(sender As Object, e As EventArgs)
        If BG_frm.HADE_TXT.Text = "Report Ledger Monthly" Then
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
        If BG_frm.HADE_TXT.Text = "Report Ledger Monthly" Then
            Cell("Report Ledger", "", "Display", VC_ID_)
            Me.Dispose()
        End If
    End Sub
    Private Sub R_2_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Set_Date(True, Me)
        End If
    End Sub
    Private Sub R_6_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then

        End If
    End Sub
    Private Sub B_3_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Dim paramtr(7) As ReportParameter

            Print_Priew_frm.ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dt_dal_mt", dt_print))
            Print_Priew_frm.ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dt_cmp", Print_DT_Company))
            Print_Priew_frm.Print_Privew(Application.StartupPath & "\Print_\Report\Account_Book_Monthly", "", paramtr)
        End If
    End Sub
    Public Function Filter_Apply()
        Label12.Text = Dft_Voucher
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

    Private Sub Report_Ledger_monthly_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.HADE_TXT.Text = "Report Ledger Monthly"
        BG_frm.TYP_TXT.Text = VC_Type_

        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text

        Button_Clear()
        Button_Manage()

        Acc_LB.Text = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Name", "ID = '" & VC_ID_ & "'")
        Fill_Grid()
    End Sub

    Private Sub Report_Ledger_monthly_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End
        Add_Hander_Remove_Handel(False)
        Frm_foCus()
    End Sub
    Private Function Where_Filter() As String
        Dim q As String
        If Dft_Voucher <> "All Vouchers" Then
            q = $"AND Voucher_Type = '{Dft_Voucher}'"
        End If
        Return q
    End Function
    Dim Current_Grid_Count As Integer

    Private Function Fill_Grid()
        Dim Cr_to As Decimal = 0.00
        Dim Dr_to As Decimal = 0.00

        dt_print.Rows.Clear()
        dt_print = ds_print.Tables("TBL_Monthly")
        Dim dr_Print As DataRow

        Acc_LB.Text = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Name", "ID = '" & VC_ID_ & "'")
        Acc_Under = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Group", "ID = '" & VC_ID_ & "'")

        Chart_Setup()

        Dim dt As New DataTable
        Dim dr As DataRow
        Dim Particuls As String

        Dim D1 As Integer = DateDiff(DateInterval.Month, CDate(Frm_date), CDate(to_date))

        dt.Clear()
        dt.Columns.Add("Type")
        dt.Columns.Add("Date_Frm").DataType = GetType(Date)
        dt.Columns.Add("Date_TO").DataType = GetType(Date)
        dt.Columns.Add("Particulars")
        dt.Columns.Add("Vouchers")
        dt.Columns.Add("Debit")
        dt.Columns.Add("Credit")
        dt.Columns.Add("Closing")


        Dim Closing_Total As String = 0.00

        Closing_Total = Ledger_Balance(VC_ID_, CDate(Frm_date), "", 0)

        If Val(Closing_Total) < 0 Then
            Label4.Text = $"{N2_FORMATE(Closing_Total * -1)}"
            Label38.Text = $"{N2_FORMATE(Closing_Total * -1)} {Negative_Value_fech}"
        ElseIf Val(Closing_Total) > 0 Then
            Label37.Text = $"{N2_FORMATE(Closing_Total)}"
            Label38.Text = $"{N2_FORMATE(Closing_Total)} {Positive_Value_fech}"
        End If

        'dt.Rows.Add("", Company_Valu, Company_Valu, "Opning Balance", "", "", Format(Val(Closing_Total), "N2"))

        Dim D1_F As Date
        Dim D2_F As Date

        For i As Integer = 0 To D1
            Dim Cr_Total As String = 0
            Dim Dr_Total As String = 0

            Dim dt1 As Date = CDate(CDate(Frm_date).ToString("dd-MM-yyyy")).AddMonths(i)
            Dim dt2 As Date = CDate(CDate(Frm_date).ToString("dd-MM-yyyy")).AddMonths(i + 1)

            D1_F = dt1
            D2_F = dt2

            If D1 <= 0 Then
                D1_F = Frm_date
                D2_F = to_date
            ElseIf i = 0 Then
                D1_F = CDate(Frm_date).ToString("dd-MM-yyyy")
                D2_F = "01-" & dt2.ToString("MM-yyyy")
            ElseIf i = D1 Then
                D1_F = "01-" & dt1.ToString("MM-yyyy")
                D2_F = CDate(to_date).ToString("dd-MM-yyyy")
            Else
                D1_F = "01-" & dt1.ToString("MM-yyyy")
                D2_F = "01-" & dt2.ToString("MM-yyyy")
            End If

            Dim Date_Filter As String = "(vl.Date >= '" & D1_F.AddDays(0).ToString(Lite_date_Format) & "' and vl.Date < '" & D2_F.AddDays(0).ToString(Lite_date_Format) & "')"

            Dim cnn As New SQLiteConnection
            open_MSSQL_Cstm(Database_File.cre, cnn)

            cmd = New SQLiteCommand($"Select SUM(ifnull(vl.Dr,0)) as Dr,SUM(ifnull(vl.Cr,0)) as Cr,Count(vc.ID) as Count
From TBL_VC_Ledger vl
Left Join TBL_VC vc on vc.Tra_ID = vl.Tra_ID
Where vl.Ledger = '{VC_ID_}' and {Date_Filter} {Where_Filter()}", cnn)

            Dim r As SQLiteDataReader
            Dim cn As New SQLiteConnection
            open_MSSQL_Cstm(Database_File.cre, cn)

            r = cmd.ExecuteReader
            dr = dt.NewRow
            dr_Print = dt_print.NewRow
            If YN_Details = True Then
                Particuls = D1_F.ToString(Date_Format_fech) & " to " & D2_F.ToString(Date_Format_fech)
            Else
                Particuls = D1_F.ToString("MMMM") & " - " & D1_F.ToString("yyyy")
            End If
            dr("Particulars") = Particuls
            dr("Date_frm") = CDate(dt1)
            dr("Date_TO") = CDate(dt2)

            dr_Print("Partiiculars") = Particuls

            While r.Read
                Dr_Total = Val(Dr_Total) + Val(r("Dr").ToString)
                Cr_Total = Val(Cr_Total) + Val(r("Cr").ToString)


                dr("Vouchers") = N2_FORMATE(r("Count").ToString).Replace(".00", "")
                dr("Debit") = N2_FORMATE(Dr_Total)
                dr_Print("Dr_Amount") = N2_FORMATE(Dr_Total)

                dr("Credit") = N2_FORMATE(Cr_Total)
                dr_Print("Cr_Amount") = N2_FORMATE(Cr_Total)

            End While
            r.Close()

            Dr_to = Val(Dr_to) + Val(Dr_Total)
            Cr_to = Val(Cr_to) + Val(Cr_Total)

            Closing_Total -= (Val(Dr_Total) - Val(Cr_Total))

            If Val(Closing_Total) < 0 Then
                dr("Closing") = $"{N2_FORMATE(Closing_Total * -1)} {Negative_Value_fech}"
                dr_Print("CL_Amount") = $"{N2_FORMATE(Closing_Total * -1)} {Negative_Value_fech}"
            ElseIf Val(Closing_Total) > 0 Then
                dr("Closing") = $"{N2_FORMATE(Closing_Total)} {Positive_Value_fech}"
                dr_Print("CL_Amount") = $"{N2_FORMATE(Closing_Total)} {Positive_Value_fech}"
            End If

            If Closing_Total < 0 Then
                Label2.Text = $"{N2_FORMATE(Closing_Total) * -1} {Negative_Value_fech}"
            ElseIf Closing_Total > 0 Then
                Label2.Text = $"{N2_FORMATE(Closing_Total)} {Positive_Value_fech}"
            End If

            dt.Rows.Add(dr)
            dt_print.Rows.Add(dr_Print)


            If D1_F.ToString("MM-yy") = suggest_date.ToString("MM-yy") Then
                Current_Grid_Count = dt.Rows.Count - 1
            End If


            Chart1.Series(0).Points.AddXY((Particuls), Dr_Total)
            Chart1.Series(1).Points.AddXY((Particuls), Cr_Total)
        Next


        Dim dv As New DataView(dt)
        Dim Dt_set As New DataTable
        dv.Sort = "Date_frm"
        Dt_set = dv.ToTable


        Grid1.DataSource = dv


        Grid1.Columns("Type").Visible = False
        Grid1.Columns("Date_Frm").Visible = False
        Grid1.Columns("Date_TO").Visible = False

        With Grid1.Columns("Particulars")
            Dim L As Label = Label31
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        With Grid1.Columns("Vouchers")
            Dim L As Label = Label7
            .Width = L.Width
            .Visible = L.Visible
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        With Grid1.Columns("Debit")
            Dim L As Label = Label11
            .Width = L.Width
            .Visible = L.Visible
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Regular)
            DR_TO_LB.Width = L.Width
        End With
        With Grid1.Columns("Credit")
            Dim L As Label = Label10
            .Width = L.Width
            .Visible = L.Visible
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Regular)

            CR_TO_LB.Width = L.Width
        End With
        With Grid1.Columns("Closing")
            Dim L As Label = Label5
            .Width = L.Width
            .Visible = L.Visible
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .DefaultCellStyle.Font = New Font("Arial", 9.75, FontStyle.Bold)

            Label2.Width = L.Width
        End With


        Grid1.CurrentCell = Grid1.Rows(Current_Grid_Count).Cells(3)

        Grid1.DefaultCellStyle.BackColor = Color.White
        Grid1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(254, 197, 48)

        DR_TO_LB.Text = N2_FORMATE(Dr_to)
        CR_TO_LB.Text = N2_FORMATE(Cr_to)


        Border_()

        Grid1.Focus()
    End Function

    Private Sub Report_Ledger_monthly_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub Grid1_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles Grid1.RowsAdded
        Grid1.Rows(Grid1.Rows.Count - 1).Height = 18
    End Sub
    Private Function Chart_Setup()
        Grid1.Focus()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()

        Series1.IsValueShownAsLabel = True
        Series2.IsValueShownAsLabel = True


        Series1.ChartArea = "ChartArea1"
        Series1.Color = System.Drawing.Color.Blue
        Series1.Legend = "Legend1"
        Series1.Name = "Debit"

        Series2.ChartArea = "ChartArea1"
        Series2.Color = System.Drawing.Color.Red
        Series2.Legend = "Legend1"
        Series2.Name = "Credit"

        Chart1.Series.Clear()

        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Series.Add(Series2)

        Me.Chart1.Size = New System.Drawing.Size(1246, 209)
        Me.Chart1.Text = "Chart1"
    End Function
    Private Sub Grid1_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim d1 As Date = CDate(Grid1.CurrentRow.Cells(1).Value)
            Dim d2 As Date = CDate(Grid1.CurrentRow.Cells(2).Value).AddDays(-1)
            suggest_date = d2
            Dim Frm As Report_Ledger_frm = Cell("Report Ledger", "", "Display", VC_ID_)
            With Frm
                .Frm_Date_LB.Text = d1
                .To_Date_LB.Text = d2
                .Fill_Grid()
                .Grid1.Focus()
            End With
        End If
    End Sub
    Private Function Group() As String
        Dim Type_of_Duty As String = Find_DT_Value(Database_File.cre, "TBL_Ledger", "TypeOfDuty", "ID = '" & VC_ID_ & "'")
        Dim TAX_per As String = (Find_DT_Value(Database_File.cre, "TBL_TAX", "Under", "ID = '" & Type_of_Duty & "'"))

        If Acc_Under = "10" Then
            Return "Sales"
        ElseIf Acc_Under = "11" Then
            Return "Purchase"
        ElseIf Acc_Under = "20" Then
            If TAX_per = "INPUT" Then
                Return "Purchase"
            Else
                Return "Sales"
            End If
        Else
            Return "All"
        End If
    End Function

    Private Sub Frm_Date_LB_TextChanged(sender As Object, e As EventArgs) Handles Frm_Date_LB.TextChanged
        Frm_date = Date_Formate(Frm_Date_LB.Text)
    End Sub
    Private Sub TO_Date_LB_TextChanged(sender As Object, e As EventArgs) Handles To_Date_LB.TextChanged
        to_date = Date_Formate(To_Date_LB.Text)
    End Sub
    Private Sub Label2_TextChanged(sender As Object, e As EventArgs) Handles Label2.TextChanged
        'If Val(Label2.Text) >= 0 Then
        '    Label2.ForeColor = Color.Green
        'Else
        '    Label2.ForeColor = Color.Red
        'End If
    End Sub

    Private Sub Grid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid1.CellContentClick

    End Sub
    Private Sub Grid1_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles Grid1.RowPrePaint
        Dim ro As DataGridViewRow = Grid1.Rows(e.RowIndex)

        If Val(ro.Cells(5).Value.ToString) = 0 Then
            ro.Cells(5).Style.SelectionBackColor = Color.FromArgb(254, 197, 48)
            ro.Cells(5).Style.ForeColor = Color.White
            ro.Cells(5).Style.SelectionForeColor = Color.FromArgb(254, 197, 48)
        End If
        If Val(ro.Cells(6).Value.ToString) = 0 Then
            ro.Cells(6).Style.SelectionBackColor = Color.FromArgb(254, 197, 48)
            ro.Cells(6).Style.ForeColor = Color.White
            ro.Cells(6).Style.SelectionForeColor = Color.FromArgb(254, 197, 48)
        End If
        ro.DefaultCellStyle.BackColor = Color.White
        ro.DefaultCellStyle.SelectionBackColor = Color.FromArgb(254, 197, 48)

    End Sub

    Private Sub Report_Ledger_monthly_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
        Grid1.Focus()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        Border_()
    End Sub
    Private Function Border_()
        With Panel11
            Dim P As Panel = B1
            Dim ctlpos As Point = .PointToScreen(.DisplayRectangle.Location)
            P.Location = New Point(ctlpos.X, 0)
            P.Height = Me.Height
            P.Visible = .Visible
        End With

        With Panel12
            Dim P As Panel = B2
            Dim ctlpos As Point = .PointToScreen(.DisplayRectangle.Location)
            P.Location = New Point(ctlpos.X, 0)
            P.Height = Me.Height
            P.Visible = .Visible
        End With

        With Label10
            Dim P As Panel = B1_1
            Dim ctlpos As Point = .PointToScreen(.DisplayRectangle.Location)
            P.Location = New Point(ctlpos.X, Panel14.Height)
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

    End Function

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class