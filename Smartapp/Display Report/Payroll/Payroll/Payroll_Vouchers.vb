Imports System.Data.SqlClient
Imports System.Data.SQLite
Imports Microsoft.Reporting.WinForms
Public Class Payroll_Vouchers
    Dim From_ID As String

    Private VC_Type_ As String
    Private em_ID As String
    Private att_ID As String
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

        em_ID = Link_Valu(0)
        att_ID = Link_Valu(1)

        Frm_Date_LB.Text = Date_Formate(Date_1)
        To_Date_LB.Text = Date_Formate(Date_2)

        BG_frm.HADE_TXT.Text = "Payroll Vouchers"
        BG_frm.TYP_TXT.Text = VC_Type_

        Label3.Text = Find_DT_Value(Database_File.cre, "TBL_Payhead", "Name", $"ID = '{att_ID}' and Visible = 'Approval'")

        If em_ID = 0 Then
            Label1.Text = "All Employee"
        Else
            Label1.Text = Find_DT_Value(Database_File.cre, "TBL_Payroll_Employee", "Name", $"ID = '{em_ID}' and Visible = 'Approval'")
        End If

        Button_Manage()
        Add_Hander_Remove_Handel(True)



        Update_Report = True
    End Sub

    Private Sub Payroll_Vouchers_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.HADE_TXT.Text = "Payroll Vouchers"
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
        BG_frm.B_2.Text = "|&D : Delete"
        BG_frm.B_3.Text = "|&R : Refresh"
        BG_frm.B_4.Text = "|&2 : Duplicate"
        BG_frm.B_5.Text = "|&A : Add Voucher"
        BG_frm.B_6.Text = "|&P : Print"
        BG_frm.B_7.Text = "|Space : Select"


        BG_frm.R_1.Text = "|F1 : Detailed"
        BG_frm.R_2.Text = "F2 : Date"
        BG_frm.R_3.Text = "|F2 : Period"

        'BG_frm.R_22.Text = "F12 : Configuration"
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
        End If
    End Function
    Private Sub BG_Keydown(sender As Object, e As KeyEventArgs)
        If BG_frm.From_ID = From_ID Then
            If e.KeyCode = Keys.D2 AndAlso e.Modifiers = Keys.Alt Then
                BG_frm.B_4.PerformClick()
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

            If e.KeyCode = Keys.F12 Then
                BG_frm.R_22.PerformClick()
            End If
        End If
    End Sub
    Private Sub B_1_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            If Grid1.Rows.Count > 0 Then
                Defolt_Select_ID = Grid1.CurrentRow.Cells(8).Value.ToString
                Cell("Voucher BG", Grid1.CurrentRow.Cells(8).Value, "Alter_Close", Grid1.CurrentRow.Cells(3).Value)
            End If
        End If
    End Sub
    Private Sub B_2_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            If Msg_Yn("Are you source", "Delete Selected Voucher ?") = DialogResult.Yes Then
                For Each row_ As DataGridViewRow In Grid1.Rows
                    If row_.Cells(10).Value = True Then
                        If Delete_Vouchers(row_.Cells(8).Value, row_.Cells(3).Value) = False Then
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
        If BG_frm.From_ID = From_ID Then
            Fill_Grid()
        End If
    End Sub
    Private Sub B_4_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Cell("Voucher BG", Grid1.CurrentRow.Cells(8).Value, "Duplicate", Grid1.CurrentRow.Cells(3).Value)
        End If
    End Sub
    Private Sub B_5_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Cell("Voucher BG", Grid1.CurrentRow.Cells(8).Value, "Create_Close", Grid1.CurrentRow.Cells(3).Value, Grid1.CurrentRow.Cells(7).Value)
        End If
    End Sub
    Private Sub B_6_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            'Print_data_fill()
            'Printing_Direct_frm.Printing_(cfg_print_path, rdlc_report_name, rdlc_report_data)
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
            Set_Date(True, Me)
        End If
    End Sub
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
    Dim dt As New DataTable
    Public Function Fill_Grid()
        dt.Clear()
        dt.Columns.Clear()
        dt.Reset()

        Grid1.Columns.Clear()
        dt = New DataTable

        dt.Columns.Add("Type")
        dt.Columns.Add("Date")
        dt.Columns.Add("Particulars")
        dt.Columns.Add("Voucher Type")
        dt.Columns.Add("Voucher No.")
        dt.Columns.Add("Debit")
        dt.Columns.Add("Credit")
        dt.Columns.Add("VC_ID")
        dt.Columns.Add("Tra_ID")
        dt.Columns.Add("Narration")
        dt.Columns.Add("Status")

        Fill_oTher_Group(dt, 0)

        Grid1.DataSource = dt

        Grid1.Columns(0).Visible = False
        Grid1.Columns(7).Visible = False
        Grid1.Columns(8).Visible = False
        Grid1.Columns(9).Visible = False
        Grid1.Columns(10).Visible = False


        Grid1.Columns(1).Width = 100
        Grid1.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Grid1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter


        Grid1.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Grid1.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        Grid1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft


        Grid1.Columns(3).Width = 130
        Grid1.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Grid1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        Grid1.Columns(4).Width = 130
        Grid1.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Grid1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        Grid1.Columns(5).Width = 120
        Grid1.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Grid1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Grid1.Columns(6).Width = 120
        Grid1.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Grid1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Dim chk As New DataGridViewCheckBoxColumn()
        Grid1.Columns.Add(chk)
        Grid1.Columns(11).Width = 30
        Grid1.Columns(11).Visible = False

        If Grid1.Rows.Count > Val(Defolt_Select_ID) Then
            Grid1.CurrentCell = Grid1.Rows(Val(Defolt_Select_ID)).Cells(1)
        End If
    End Function
    Private Function Fill_oTher_Group(dt As DataTable, Closing_ As String)
        dt_print.Rows.Clear()
        dt_print = ds_print.Tables("TBL_DayBook")
        Dim dr_print As DataRow

        Dim Dr_to As Decimal = 0
        Dim Cr_to As Decimal = 0


        Dim Employee_Filter As String = ""

        If em_ID = 0 Then
            Employee_Filter = ""
        Else
            Employee_Filter = $"and vp.Employee = '{em_ID}'"
        End If



        Dim q As String
        q = $"and (vc.Date BETWEEN '{CDate(Frm_date).ToString(Lite_date_Format)}' and '{CDate(to_date).AddDays(1).ToString(Lite_date_Format)}')"

        Dim cn As New SQLiteConnection
        Dim dr As DataRow
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select vc.[Date],vc.Tra_ID,vc.Voucher_No,vc.Voucher_Type_ID,vc.Voucher_Type,vc.Visible,
ifnull(SUM(vp.Dr),0) as Debit,ifnull(SUM(vp.Cr),0) as Credit
From TBL_VC_Payroll vp
Left Join TBL_VC vc on vc.Tra_ID = vp.Tra_ID
WHERE vp.Payhead = '{att_ID}' {Employee_Filter} {q}
Group By vc.Tra_ID
", cn)

            'My.Computer.Clipboard.SetText(cmd.CommandText)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                Dim Tra_id As String = r("Tra_ID")
                Dim Voucher_Type As String = r("Voucher_Type")
                Dim Voucher_No As String = r("Voucher_No")
                Dim Date_ As String = CDate(r("Date")).ToString(Date_Format_fech)

                dr = dt.NewRow
                dr("Tra_ID") = Tra_id
                dr("Type") = "Head"
                dr("Date") = Date_Formate(Date_)
                dr("Particulars") = Label3.Text
                dr("Voucher Type") = Voucher_Type
                dr("Voucher No.") = Voucher_No
                dr("VC_ID") = r("Voucher_Type_ID")

                If r("Visible") = "Approval" Then
                    dr("Status") = "Active"
                Else
                    dr("Status") = r("Visible")
                End If

                dr("Credit") = $"{N2_FORMATE(r("Credit"))}"
                dr("Debit") = $"{N2_FORMATE(r("Debit"))}"


                Dr_to += Val(r("Debit").ToString)
                Cr_to += Val(r("Credit").ToString)

                dt.Rows.Add(dr)


                If Defolt_Select_ID = Tra_id Then
                    Defolt_Select_ID = dt.Rows.Count - 1
                End If
            End While

            Label5.Text = N2_FORMATE(Dr_to)
            Label4.Text = N2_FORMATE(Cr_to)

            Dim cl As Decimal = Dr_to - Cr_to

            If cl > 0 Then
                Label6.Text = $"{N2_FORMATE(cl)} {Negative_Value_fech}"
            Else
                Label6.Text = $"{N2_FORMATE(cl * -1)} {Positive_Value_fech}"
            End If

        End If
    End Function
    Private Sub Frm_Date_LB_TextChanged(sender As Object, e As EventArgs) Handles Frm_Date_LB.TextChanged
        Frm_date = Frm_Date_LB.Text
    End Sub
    Private Sub To_Date_LB_TextChanged(sender As Object, e As EventArgs) Handles To_Date_LB.TextChanged
        to_date = To_Date_LB.Text
    End Sub
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

        If Grid1.Rows.Count = 0 Then
            Exit Sub
        End If

        Dim ctlpos As Point = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(2, 0, False).Location)
        L1.Location = New Point(ctlpos.X, 0)
        L1.Height = Me.Height

        ctlpos = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(3, 0, False).Location)
        L2.Location = New Point(ctlpos.X, 0)
        L2.Height = Me.Height

        ctlpos = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(4, 0, False).Location)
        L3.Location = New Point(ctlpos.X, 0)
        L3.Height = Me.Height

        ctlpos = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(5, 0, False).Location)
        L4.Location = New Point(ctlpos.X, 0)
        L4.Height = Me.Height

        ctlpos = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(6, 0, False).Location)
        L5.Location = New Point(ctlpos.X, 0)
        L5.Height = Me.Height

    End Sub
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

            If ro.Cells(10).Value <> "Delete" Then
                ro.DefaultCellStyle.ForeColor = Color.DimGray
            End If

            ro.DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Bold)
            ro.Cells(1).Style.SelectionBackColor = Color.White
            ro.Cells(1).Style.ForeColor = Color.White
            ro.Cells(1).Style.SelectionForeColor = Color.White
        ElseIf ro.Cells(0).Value = "Narration" Then
            Grid1.DefaultCellStyle.WrapMode = DataGridViewTriState.True
            Grid1.AutoResizeRow(e.RowIndex)

            If ro.Cells(10).Value <> "Delete" Then
                ro.DefaultCellStyle.ForeColor = Color.DimGray
            End If

            ro.DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Italic)
            ro.Cells(1).Style.SelectionBackColor = Color.White
            ro.Cells(1).Style.ForeColor = Color.White
            ro.Cells(1).Style.SelectionForeColor = Color.White
            ro.Cells(2).Style.Padding = New Padding(20, 0, 0, 0)
        End If

        If Grid1.Rows(e.RowIndex).Cells(11).Value = True Then
            ro.DefaultCellStyle.BackColor = Color_SELECT_back
            ro.DefaultCellStyle.ForeColor = Color_SELECT_fonr
        Else
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
        End If


        If ro.Cells(10).Value = "Delete" Then
            ro.DefaultCellStyle.ForeColor = Color.Red
        End If
    End Sub

    Private Sub Grid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid1.CellContentClick

    End Sub
End Class