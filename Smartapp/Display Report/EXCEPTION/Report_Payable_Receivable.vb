Imports System.Data.SqlClient
Imports System.Data.SQLite
Imports Microsoft.Reporting.WinForms
Public Class Report_Payable_Receivable
    Dim From_ID As String
    Private VC_Type_ As String
    Private Path_End As String
    Dim YN_Details As Boolean

    Dim Frm_date As Date
    Dim to_date As Date

    Dim Defolt_Select_ID As String = 0

    Dim ds_print As New Print_dt
    Dim dt_print As New DataTable
    Private Sub Payroll_Vouchers_Summary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text

        To_Date_LB.Text = Date_Formate(Date_3)

        BG_frm.HADE_TXT.Text = "Payable Receivable Report"
        BG_frm.TYP_TXT.Text = VC_Type_

        Label1.Text = "Overdue Ledger"
        Label3.Text = Link_Valu(2)

        Button_Manage()
        Add_Hander_Remove_Handel(True)

        Update_Report = True
    End Sub

    Private Sub Payroll_Vouchers_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.HADE_TXT.Text = "Payable Receivable Report"
        BG_frm.TYP_TXT.Text = VC_Type_

        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text


        Button_Clear()
        Button_Manage()
        'cfg_fill()
        If Update_Report = True Then
            Fill_Grid()
        End If
        Grid1.Focus()
    End Sub

    Private Sub Payroll_Vouchers_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub Payroll_Vouchers_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        Add_Hander_Remove_Handel(False)
        BG_frm.BG_Path_TXT.Text = Path_End
        Frm_foCus()
    End Sub

    Private Sub Payroll_Vouchers_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
        Grid1.Focus()
    End Sub
    Private Function Button_Manage()
        Button_Clear()
        BG_frm.B_1.Text = "Enter : Alter"
        BG_frm.B_3.Text = "|&R : Refresh"


        BG_frm.R_1.Text = "|F1 : Detailed"
        BG_frm.R_2.Text = "F2 : Date"

        If Label3.Text = "Payable Report" Then
            BG_frm.R_3.Text = "F3 : Receivable"
        ElseIf Label3.Text = "Receivable Report" Then
            BG_frm.R_3.Text = "F3 : Payable"
        End If


        'BG_frm.R_22.Text = "F12 : Configuration"
    End Function
    Private Function Add_Hander_Remove_Handel(Ans As Boolean)
        If Ans = True Then
            AddHandler BG_frm.KeyDown, AddressOf Me.BG_Keydown
            AddHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            AddHandler BG_frm.B_3.Click, AddressOf Me.B_3_Click

            AddHandler BG_frm.R_1.Click, AddressOf Me.R_1_Click
            AddHandler BG_frm.R_2.Click, AddressOf Me.R_3_Click
            AddHandler BG_frm.R_3.Click, AddressOf Me.R_4_Click
        Else
            RemoveHandler BG_frm.KeyDown, AddressOf Me.BG_Keydown
            RemoveHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            RemoveHandler BG_frm.B_3.Click, AddressOf Me.B_3_Click

            RemoveHandler BG_frm.R_1.Click, AddressOf Me.R_1_Click
            RemoveHandler BG_frm.R_2.Click, AddressOf Me.R_3_Click
            RemoveHandler BG_frm.R_3.Click, AddressOf Me.R_4_Click
        End If
    End Function
    Private Sub BG_Keydown(sender As Object, e As KeyEventArgs)
        If BG_frm.From_ID = From_ID Then
            If e.KeyCode = Keys.D2 AndAlso e.Modifiers = Keys.Alt Then

            End If

            If e.KeyCode = Keys.Space AndAlso e.Modifiers = Keys.Control Then

            ElseIf e.KeyCode = Keys.Space Then

            End If

            If e.KeyCode = Keys.F1 AndAlso e.Modifiers = Keys.Alt Then
                BG_frm.R_1.PerformClick()
            End If

            If e.KeyCode = Keys.F2 AndAlso e.Modifiers = Keys.Alt Then

            ElseIf e.KeyCode = Keys.F2 Then
                BG_frm.R_2.PerformClick()
            End If

            If e.KeyCode = Keys.F3 AndAlso e.Modifiers = Keys.Alt Then

            ElseIf e.KeyCode = Keys.F3 Then
                BG_frm.R_3.PerformClick()
            End If


            If e.KeyCode = Keys.F12 Then
                'BG_frm.R_22.PerformClick()
            End If
        End If
    End Sub
    Private Sub B_1_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            If Grid1.Rows.Count > 0 Then
                Defolt_Select_ID = Grid1.CurrentRow.Cells(1).Value.ToString


                Dim YYear As FirstWeekOfYear = Date_3.ToString("yyyy")
                Cell("Report Ledger Monthly", "", "Display", Defolt_Select_ID, CDate("01-04-" & YYear).ToString("dd-MM-yyyy"), to_date, Dft_Voucher, Dft_Branch, CDate(Date_3).ToString("dd-MM-yyyy"))
            End If
        End If
    End Sub
    Private Sub B_3_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Fill_Grid()
        End If
    End Sub

    Private Sub B_7_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            If Grid1.CurrentRow.Cells(11).Value = True Then
                Grid1.CurrentRow.Cells(11).Value = False
            ElseIf Grid1.CurrentRow.Cells(11).Value = False Then
                Grid1.CurrentRow.Cells(11).Value = True
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


            If Label3.Text = "Payable Report" Then
                Label3.Text = "Receivable Report"
                BG_frm.R_3.Text = "F3 : Payable"
            ElseIf Label3.Text = "Receivable Report" Then
                Label3.Text = "Payable Report"
                BG_frm.R_3.Text = "F3 : Receivable"
            End If
            Fill_Grid()
        End If
    End Sub



    Public Function Apply_Date_Filter(ifPeriod As Boolean)
        If ifPeriod = True Then
            To_Date_LB.Text = Date_Formate(Date_3)
        Else
            To_Date_LB.Text = Date_Formate(Date_3)
        End If
        Fill_Grid()
    End Function
    Dim dt As New DataTable
    Public Function Fill_Grid()
        dt.Clear()
        dt.Columns.Clear()
        dt.Reset()

        Grid1.Columns.Clear()
        dt = New DataTable

        dt.Columns.Add("Type")
        dt.Columns.Add("ID")
        dt.Columns.Add("Party's Name")
        dt.Columns.Add("Amount")
        dt.Columns.Add("Credit_1")
        dt.Columns.Add("Credit_2")
        dt.Columns.Add("Days_1")
        dt.Columns.Add("Days_2")
        dt.Columns.Add("Days_3")

        Fill_oTher_Group(dt, 0)

        Grid1.DataSource = dt

        Grid1.Columns(0).Visible = False
        Grid1.Columns(1).Visible = False


        Grid1.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Grid1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft


        Grid1.Columns(3).Width = 130
        Grid1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'Credit Limit
        Grid1.Columns(4).Width = 125
        Grid1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Grid1.Columns(5).Width = 125
        Grid1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        'Credit Days
        Grid1.Columns(6).Width = 116
        Grid1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Grid1.Columns(7).Width = 116
        Grid1.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Grid1.Columns(8).Width = 116
        Grid1.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


        Border_()

        If Grid1.Rows.Count > Val(Defolt_Select_ID) Then
            Grid1.CurrentCell = Grid1.Rows(Val(Defolt_Select_ID)).Cells(2)
        End If
    End Function
    Private Function Fill_oTher_Group(dt As DataTable, Closing_ As String)
        dt_print.Rows.Clear()
        dt_print = ds_print.Tables("TBL_DayBook")
        Dim dr_print As DataRow

        Dim Total_to As Decimal = 0
        Dim Total_Credit As Decimal = 0
        Dim Total_Credit_CLosing As Decimal = 0
        Dim Total_Days_Credit As Decimal = 0
        Dim Total_Days_Closing As Decimal = 0


        Dim cn As New SQLiteConnection
        Dim dr As DataRow
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select 'Under' as Type,[Ledger] as ID,'' as Name,'' as Gro,'' as Alise,'' as Cradit,(SELECT julianday('{CDate(Now.Date).ToString(Lite_date_Format)}')-julianday(vc.[Date])) as Days,
ifnull(vc.Cr,0)-ifnull(vc.Dr,0) as Bal_
from TBL_VC_Ledger vc 
where vc.[Date] <= '{CDate(to_date).AddDays(1).ToString(Lite_date_Format)}' and {Branch_Enable_Ledger("vc.Ledger", "0")}

UNION ALL

Select 'Head' as Type,[ID],[Name],[Group],[Alise],[Cradit],[Cradit_Days] as Days,
(Select ifnull((Select ifnull(SUM(vc.Cr),0)-ifnull(SUM(vc.Dr),0) From TBL_VC_Ledger vc Where vc.Ledger = LD.ID and vc.[Date] <= '{CDate(to_date).AddDays(1).ToString(Lite_date_Format)}'),0)+ifnull((Select ifnull(sum(lob.OB_Cr),0)-ifnull(sum(lob.OB_Dr),0) From TBL_Ledger_Opning_Balance lob where lob.Ledger_ID = LD.ID and lob.Branch_ID = '0'),0)) as Bal_
from TBL_Ledger LD where {Branch_Enable_Ledger("LD.id", "0")} and {Company_Visible_Filter()}
order by ID

", cn)

            'My.Computer.Clipboard.SetText(cmd.CommandText)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader

            Dim Vl1 As String = 0



            While r.Read
                Dim ID As String = r("ID").ToString
                Dim Particuls As String = r("Name")
                Dim Amt_ As String = Val(r("Bal_"))


                If (Label3.Text = "Payable Report" And Amt_ > 0) Or (Label3.Text = "Receivable Report" And Amt_ < 0) Or (r("Type").ToString = "Under") Then
                    If Val(r("Gro").ToString) = 27 Or Val(r("Gro").ToString) = 28 Then
                    Else
                        If r("Type").ToString = "Head" Then
                            dr = dt.NewRow
                            Dim Curr_day As String = Value_Decimal_set(Val(Val(Vl1) / Val(Amt_)), 0)
                            dr("Days_1") = Val(r("Days").ToString)
                            dr("Days_2") = Curr_day
                            dr("Days_3") = Val(r("Days").ToString) - Val(Curr_day)


                            If Amt_ < 0 Then
                                Amt_ *= -1
                            End If

                            dr("Type") = "Head"
                            dr("ID") = r("ID").ToString
                            dr("Party's Name") = Particuls
                            dr("Amount") = N2_FORMATE(Amt_)

                            dr("Credit_1") = r("Cradit").ToString
                            dr("Credit_2") = Val(r("Bal_").ToString) - Val(r("Cradit").ToString)

                            Total_to += Val(Amt_)
                            dt.Rows.Add(dr)

                            Vl1 = 0
                            Total_Credit += Val(Val(r("Cradit").ToString))
                            Total_Credit_CLosing += Val(Val(r("Bal_").ToString) - Val(r("Cradit").ToString))
                            Total_Days_Credit += Val(r("Cradit").ToString)
                            Total_Days_Closing += Val(Val(r("Days").ToString) - Val(Curr_day))
                        ElseIf r("Type").ToString = "Under" Then
                            Vl1 = Val(Vl1) + Val(r("Bal_").ToString) * Val(r("Days").ToString)
                        End If
                    End If
                Else
                    Vl1 = 0
                End If

                If Defolt_Select_ID = ID Then
                    Defolt_Select_ID = dt.Rows.Count - 0
                End If
            End While

            Label6.Text = N2_FORMATE(Total_to)
            Label17.Text = N2_FORMATE(Total_Credit)
            Label16.Text = N2_FORMATE(Total_Credit_CLosing)
            Label15.Text = N2_FORMATE(Total_Days_Credit)
            Label14.Text = ""
            Label9.Text = N2_FORMATE(Total_Days_Closing)

        End If
    End Function
    Private Sub To_Date_LB_TextChanged(sender As Object, e As EventArgs) Handles To_Date_LB.TextChanged
        to_date = To_Date_LB.Text
    End Sub
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        Border_()
    End Sub
    Private Function Border_()
        With Label13
            Dim P As Panel = B1
            Dim ctlpos As Point = .PointToScreen(.DisplayRectangle.Location)
            P.Location = New Point(ctlpos.X, 0)
            P.Height = Me.Height
            P.Visible = .Visible
        End With

        With Panel8
            Dim P As Panel = B2
            Dim ctlpos As Point = .PointToScreen(.DisplayRectangle.Location)
            P.Location = New Point(ctlpos.X, 0)
            P.Height = Me.Height
            P.Visible = .Visible
        End With

        With Panel7
            Dim P As Panel = B3
            Dim ctlpos As Point = .PointToScreen(.DisplayRectangle.Location)
            P.Location = New Point(ctlpos.X, 0)
            P.Height = Me.Height
            P.Visible = .Visible
        End With




        With Label10
            Dim P As Panel = B1_1
            Dim ctlpos As Point = .PointToScreen(.DisplayRectangle.Location)
            P.Location = New Point(ctlpos.X, Panel11.Height)
            P.Height = Me.Height - Panel11.Height
            P.Visible = .Visible
        End With

        With Label8
            Dim P As Panel = B2_1
            Dim ctlpos As Point = .PointToScreen(.DisplayRectangle.Location)
            P.Location = New Point(ctlpos.X, Panel12.Height)
            P.Height = Me.Height - Panel12.Height
            P.Visible = .Visible
        End With

        With Label5
            Dim P As Panel = B2_2
            Dim ctlpos As Point = .PointToScreen(.DisplayRectangle.Location)
            P.Location = New Point(ctlpos.X, Panel12.Height)
            P.Height = Me.Height - Panel12.Height
            P.Visible = .Visible
        End With


        Label9.Visible = Label5.Visible
        Label14.Visible = Label8.Visible
        Label15.Visible = Label4.Visible

        Label16.Visible = Label10.Visible
        Label17.Visible = Label11.Visible
        Label6.Visible = Label13.Visible


    End Function
    Private Sub Grid1_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid1.KeyDown
        If e.KeyCode = Keys.Enter Then
            BG_frm.B_1.PerformClick()
            e.Handled = True
        End If
    End Sub
    Private Sub Grid1_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles Grid1.RowPrePaint
        Dim ro As DataGridViewRow = Grid1.Rows(e.RowIndex)
        If ro.Cells(0).Value = "Head" Then
            If YN_Details = True Then
                ro.DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Bold)
            End If
        ElseIf ro.Cells(0).Value = "Under" Then

            ro.DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Bold)
            ro.Cells(1).Style.SelectionBackColor = Color.White
            ro.Cells(1).Style.ForeColor = Color.White
            ro.Cells(1).Style.SelectionForeColor = Color.White
        ElseIf ro.Cells(0).Value = "Narration" Then
            Grid1.DefaultCellStyle.WrapMode = DataGridViewTriState.True
            Grid1.AutoResizeRow(e.RowIndex)

            ro.DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Italic)
            ro.Cells(1).Style.SelectionBackColor = Color.White
            ro.Cells(1).Style.ForeColor = Color.White
            ro.Cells(1).Style.SelectionForeColor = Color.White
            ro.Cells(2).Style.Padding = New Padding(20, 0, 0, 0)
        End If
    End Sub

    Private Sub Grid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid1.CellContentClick

    End Sub
End Class