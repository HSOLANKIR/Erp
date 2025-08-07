Imports System.Data.SqlClient
Imports System.Data.SQLite
Imports Microsoft.Reporting.WinForms
Public Class Payroll_Monthly_Summary
    Dim From_ID As String
    Private VC_Type_ As String
    Private VC_ID_ As String
    Private Path_End As String
    Dim YN_Details As Boolean
    Dim Acc_Under As String
    Dim Frm_date As Date
    Dim to_date As Date

    Public Branch As String = "Primary"
    Public Branch_ID As String
    Public Narration_ As Boolean = False
    Public Delete_Entry = False


    Dim ds_print As New Print_dt
    Dim dt_print As New DataTable
    Private Sub Payroll_Monthly_Summary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text
        Branch = Branch_Name

        VC_ID_ = Link_Valu(0)
        Branch = Link_Valu(1)

        Frm_Date_LB.Text = Date_Formate(Date_1)
        To_Date_LB.Text = Date_Formate(Date_2)

        BG_frm.HADE_TXT.Text = "Payroll Monthly Summary"
        BG_frm.TYP_TXT.Text = VC_Type_

        Button_Manage()
        Add_Hander_Remove_Handel(True)

        Label3.Text = Branch
        Update_Report = True
    End Sub
    Private Function Button_Manage()
        Button_Clear()

        BG_frm.B_1.Text = "|&P : Print"

        BG_frm.R_1.Text = "|F1 : Detailed"
        BG_frm.R_2.Text = "|F2 : Peiod"
        BG_frm.R_4.Text = "F3 : Voucher Type"
        If Branch_Visible() = True Then
            BG_frm.R_5.Text = "F4 : Branch"
        End If
        BG_frm.R_3.Text = ""
    End Function
    Private Function Add_Hander_Remove_Handel(Ans As Boolean)
        If Ans = True Then
            AddHandler BG_frm.KeyDown, AddressOf Me.BG_Keydown
            AddHandler BG_frm.B_1.Click, AddressOf Me.B_3_Click

            AddHandler BG_frm.R_1.Click, AddressOf Me.R_1_Click
            AddHandler BG_frm.R_2.Click, AddressOf Me.R_2_Click
            If Branch_Visible() = True Then
                AddHandler BG_frm.R_5.Click, AddressOf Me.R_5_Click
            End If
        Else
            RemoveHandler BG_frm.KeyDown, AddressOf Me.BG_Keydown
            RemoveHandler BG_frm.B_1.Click, AddressOf Me.B_3_Click

            RemoveHandler BG_frm.R_2.Click, AddressOf Me.R_2_Click
            If Branch_Visible() = True Then
                RemoveHandler BG_frm.R_5.Click, AddressOf Me.R_5_Click
            End If
        End If
    End Function
    Private Sub BG_Keydown(sender As Object, e As KeyEventArgs)
        If BG_frm.HADE_TXT.Text = "Payroll Monthly Summary" Then
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
        If BG_frm.HADE_TXT.Text = "Payroll Monthly Summary" Then
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
        If BG_frm.HADE_TXT.Text = "Payroll Monthly Summary" Then
            Cell("Report Ledger", "", "Display", VC_ID_)
            Me.Dispose()
        End If
    End Sub
    Private Sub R_2_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            If Date_Set_Curr(True) = DialogResult.Yes Then
                Frm_Date_LB.Text = Date_1
                To_Date_LB.Text = Date_2
                Fill_Grid()
            End If
        End If
    End Sub

    Private Sub R_5_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then

        End If
    End Sub
    Private Sub B_3_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then

        End If
    End Sub

    Private Sub Payroll_Monthly_Summary_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.HADE_TXT.Text = "Payroll Monthly Summary"
        BG_frm.TYP_TXT.Text = VC_Type_

        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text
        Button_Clear()
        Button_Manage()
        'Config_Fill()
        If Update_Report = True Then
            Fill_Grid()
        End If
        Grid1.Focus()
    End Sub

    Private Sub Payroll_Monthly_Summary_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub Payroll_Monthly_Summary_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        Add_Hander_Remove_Handel(False)
        BG_frm.BG_Path_TXT.Text = Path_End
        Frm_foCus()
    End Sub
    Private Function Where_Filter() As String
        Dim q As String
        If Branch <> "Primary" Then
            q &= " AND vc.Branch = '" & Find_DT_Value(Database_File.cre, "TBL_Ledger", "ID", "Name = '" & Branch & "'") & "'"
        End If
        Return q
    End Function
    Dim Date_Filter As String
    Dim dt As New DataTable
    Public Function Fill_Grid()
        Dim Cr_to As Decimal = 0.00
        Dim Dr_to As Decimal = 0.00
        Dim _to As Decimal = 0.00

        dt_print.Rows.Clear()
        dt_print = ds_print.Tables("TBL_Monthly")
        Dim dr_Print As DataRow

        Acc_LB.Text = Find_DT_Value(Database_File.cre, "TBL_Payroll_Employee", "Name", "ID = '" & VC_ID_ & "'")
        Acc_Under = Find_DT_Value(Database_File.cre, "TBL_Payroll_Employee", "Under", "ID = '" & VC_ID_ & "'")

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
        dt.Columns.Add("Debit")
        dt.Columns.Add("Credit")
        dt.Columns.Add("Closing")

        Dim Company_Valu As Date = Find_DT_Value(Database_File.cmp, "TBL_Company_Creation", "Opning_Date", "CompanySerial = '" & Company_Serial_str & "'")

        Dim D1_F As Date
        Dim D2_F As Date
        Dim r As SQLiteDataReader

        If open_MSSQL(Database_File.cre) = True Then
            For i As Integer = 0 To D1
                Dim Cr_Total As String = 0
                Dim Dr_Total As String = 0
                Dim _Total As String = 0
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

                Dim Date_Filter As String = "(Date >= '" & D1_F.ToString("MM-dd-yyyy") & "' and Date < '" & D2_F.ToString("MM-dd-yyyy") & "')"

                cmd = New SQLiteCommand("Select (Select [Name] From TBL_Payroll_Employee where id = vc.Particuls) as Employee, SUM(Dr) as Dr,SUM(Cr) as Cr, SUM(Dr) - SUM(Cr) as To_ from TBL_VC VC


where " & Date_Filter & Where_Filter() & " and vc.Visible = 'Approval' and VC.Voucher_Type = 'Payroll' and vc.CR_DR = 'Under' and vc.Particuls = '" & VC_ID_ & "'

GROUP BY Particuls
ORDER BY sum(Dr),sum(Cr)", con)
                r = cmd.ExecuteReader
                dr = dt.NewRow

                If YN_Details = True Then
                    Particuls = D1_F.ToString("dd-MMM-yyyy") & " to " & D2_F.ToString("dd-MMM-yyyy")
                Else
                    Particuls = D1_F.ToString("MMMM") & " - " & D1_F.ToString("yyyy")
                End If

                dr("Particulars") = Particuls
                dr("Date_frm") = CDate(dt1)
                dr("Date_TO") = CDate(dt2)
                While r.Read
                    Dr_Total = r("Dr")
                    Cr_Total = r("Cr")
                    _Total = r("To_")
                End While
                If Val(Dr_Total) = 0 Then
                    Dr_Total = ""
                Else
                    Dr_Total = Format(Val(Dr_Total), "0.00")
                End If
                If Val(Cr_Total) = 0 Then
                    Cr_Total = ""
                Else
                    Cr_Total = Format(Val(Cr_Total), "0.00")
                End If
                If Val(_Total) = 0 Then
                    _Total = ""
                Else
                    _Total = Format(Val(_Total), "0.00")
                End If

                Dr_to = Val(Dr_to) + Val(Dr_Total)
                Cr_to = Val(Cr_to) + Val(Cr_Total)
                _to = Val(_to) + Val(_Total)

                dr("Debit") = Dr_Total
                dr("Credit") = Cr_Total
                dr("Closing") = _Total

                r.Close()
                dt.Rows.Add(dr)

                Chart1.Series(0).Points.AddXY((Particuls), Dr_Total)
                Chart1.Series(1).Points.AddXY((Particuls), Cr_Total)
            Next
        End If


        Dim dv As New DataView(dt)
        Dim Dt_set As New DataTable
        dv.Sort = "Date_frm"
        Dt_set = dv.ToTable


        Grid1.DataSource = dv

        Try
            Grid1.CurrentCell = Grid1.Rows(0).Cells(3)
        Catch ex As Exception

        End Try

        Grid1.Columns(0).Visible = False
        Grid1.Columns(1).Visible = False
        Grid1.Columns(2).Visible = False
        Grid1.Columns(6).Visible = True

        Grid1.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Grid1.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        Grid1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        Grid1.Columns(4).Width = 100
        Grid1.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        Grid1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Grid1.Columns(5).Width = 100
        Grid1.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        Grid1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Grid1.Columns(6).Width = 100
        Grid1.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        Grid1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Grid1.Columns(6).DefaultCellStyle.Font = Defolt_Fonts_Bold
        Grid1.Columns(6).DefaultCellStyle.ForeColor = Color.SaddleBrown

        Grid1.DefaultCellStyle.BackColor = Color.White
        Grid1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(254, 197, 48)

        DR_TO_LB.Width = Grid1.Columns(4).Width
        CR_TO_LB.Width = Grid1.Columns(5).Width
        Label2.Width = Grid1.Columns(6).Width

        DR_TO_LB.Text = Format(Val(Val(Dr_to)), "N2")
        CR_TO_LB.Text = Format(Val(Val(Cr_to)), "N2")
        Label2.Text = Format(Val(Val(_to)), "N2")

        Grid1.Focus()
    End Function

    Private Sub Grid1_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles Grid1.RowsAdded
        Grid1.Rows(Grid1.Rows.Count - 1).Height = 18
    End Sub
    Private Sub Frm_Date_LB_TextChanged(sender As Object, e As EventArgs) Handles Frm_Date_LB.TextChanged
        Frm_date = Frm_Date_LB.Text
    End Sub
    Private Sub To_Date_LB_TextChanged(sender As Object, e As EventArgs) Handles To_Date_LB.TextChanged
        to_date = To_Date_LB.Text
    End Sub
    Private Function Chart_Setup()
        Grid1.Focus()
        Dim Series1 As DataVisualization.Charting.Series = New DataVisualization.Charting.Series()
        Dim Series2 As DataVisualization.Charting.Series = New DataVisualization.Charting.Series()

        Series1.IsValueShownAsLabel = True
        Series2.IsValueShownAsLabel = True


        Series1.ChartArea = "ChartArea1"
        Series1.Color = Color.Blue
        Series1.Legend = "Legend1"
        Series1.Name = "Debit"

        Series2.ChartArea = "ChartArea1"
        Series2.Color = Color.Red
        Series2.Legend = "Legend1"
        Series2.Name = "Credit"

        Chart1.Series.Clear()

        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Series.Add(Series2)

        Me.Chart1.Size = New System.Drawing.Size(1246, 209)
        Me.Chart1.Text = "Chart1"
    End Function

    Private Sub Grid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid1.CellContentClick

    End Sub

    Private Sub Grid1_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If BG_frm.HADE_TXT.Text = "Payroll Monthly Summary" Then
                Dim d1 As Date = CDate(Grid1.CurrentRow.Cells(1).Value)
                Dim d2 As Date = CDate(Grid1.CurrentRow.Cells(2).Value).AddDays(-1)
                Cell("Payroll Vouchers Summary", VC_ID_, Branch)

            End If
            e.Handled = True
        End If
    End Sub

    Private Sub Payroll_Monthly_Summary_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
    End Sub
End Class