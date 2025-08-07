Imports System.Data.SqlClient
Imports System.Data.SQLite
Imports Microsoft.Reporting.WinForms
Public Class Employee_Group_Summary
    Dim From_ID As String
    Private VC_Type_ As String
    Private VC_ID_ As String
    Private Path_End As String
    Dim YN_Details As Boolean
    Dim Acc_Under As String
    Dim Frm_date As Date
    Dim to_date As Date

    Public Branch As String = "Primary"
    Public Narration_ As Boolean = False
    Public Delete_Entry = False

    Dim ds_print As New Print_dt
    Dim dt_print As New DataTable
    Private Sub Employee_Group_Summary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text

        VC_Type_ = Link_Valu(1)
        VC_ID_ = Link_Valu(2)

        Frm_Date_LB.Text = Date_Formate(Date_1)
        To_Date_LB.Text = Date_Formate(Date_2)

        BG_frm.HADE_TXT.Text = "Payroll Group Summary"
        BG_frm.TYP_TXT.Text = VC_Type_

        Button_Manage()
        Add_Hander_Remove_Handel(True)
        Branch = Branch_Name

        Label17.Text = Branch
        Update_Report = True
    End Sub
    Private Function Button_Manage()
        Button_Clear()
        BG_frm.B_1.Text = "Enter : Alter"
        BG_frm.B_2.Text = "|&R : Refresh"
        BG_frm.B_3.Text = "|&P : Print"

        BG_frm.R_1.Text = "|F1 : Detailed"
        BG_frm.R_2.Text = "F2 : Date"
        BG_frm.R_3.Text = "|F2 : Period"
        If Branch_Visible() = True Then
            BG_frm.R_5.Text = "F4 : Branch"
        End If
        'BG_frm.R_22.Text = "F12 : Configuration"
    End Function
    Private Function Add_Hander_Remove_Handel(Ans As Boolean)
        If Ans = True Then
            AddHandler BG_frm.KeyDown, AddressOf Me.BG_Keydown
            AddHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            AddHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
            AddHandler BG_frm.B_3.Click, AddressOf Me.B_3_Click

            AddHandler BG_frm.R_1.Click, AddressOf Me.R_1_Click
            AddHandler BG_frm.R_2.Click, AddressOf Me.R_3_Click
            AddHandler BG_frm.R_3.Click, AddressOf Me.R_4_Click
            If Branch_Visible() = True Then
                AddHandler BG_frm.R_5.Click, AddressOf Me.R_9_Click
            End If
        Else
            RemoveHandler BG_frm.KeyDown, AddressOf Me.BG_Keydown
            RemoveHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            RemoveHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
            RemoveHandler BG_frm.B_3.Click, AddressOf Me.B_3_Click

            RemoveHandler BG_frm.R_1.Click, AddressOf Me.R_1_Click
            RemoveHandler BG_frm.R_2.Click, AddressOf Me.R_3_Click
            RemoveHandler BG_frm.R_3.Click, AddressOf Me.R_4_Click
            If Branch_Visible() = True Then
                RemoveHandler BG_frm.R_5.Click, AddressOf Me.R_9_Click
            End If
        End If
    End Function
    Private Sub BG_Keydown(sender As Object, e As KeyEventArgs)
        If BG_frm.From_ID = From_ID Then
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
                BG_frm.R_7.PerformClick()
            ElseIf e.KeyCode = Keys.F3 Then
                BG_frm.R_4.PerformClick()
            End If
            If e.KeyCode = Keys.F4 AndAlso e.Modifiers = Keys.Alt Then

            ElseIf e.KeyCode = Keys.F4 Then
                BG_frm.R_5.PerformClick()
            End If

            If e.KeyCode = Keys.F5 AndAlso e.Modifiers = Keys.Alt Then
            ElseIf e.KeyCode = Keys.F5 Then
                BG_frm.R_7.PerformClick()
            End If

            If e.KeyCode = Keys.F12 Then
                BG_frm.R_22.PerformClick()
            End If

            If e.KeyCode = Keys.F AndAlso e.Modifiers = Keys.Control Then
                BG_frm.R_6.PerformClick()
            End If
        End If
    End Sub
    Private Sub B_1_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            If Grid1.CurrentRow.Cells(0).Value = "Head" Then
                Cell("Payroll Employee Summary", Grid1.CurrentRow.Cells(5).Value, Branch)
            Else
                Cell("Payroll Monthly Summary", Grid1.CurrentRow.Cells(5).Value, Branch)
            End If
        End If
    End Sub
    Private Sub B_2_Click(sender As Object, e As EventArgs)
        Dim ro As Integer
        If BG_frm.From_ID = From_ID Then
            Fill_Grid()
        End If
    End Sub
    Private Sub B_3_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then

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
            If Date_Set_Curr(False) = DialogResult.Yes Then
                Frm_Date_LB.Text = Date_3
                To_Date_LB.Text = Date_3
                Fill_Grid()
            End If
        End If
    End Sub
    Private Sub R_4_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            If Date_Set_Curr(True) = DialogResult.Yes Then
                Frm_Date_LB.Text = Date_1
                To_Date_LB.Text = Date_2
                Fill_Grid()
            End If
        End If
    End Sub
    Private Sub R_9_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then

        End If
    End Sub

    Private Sub Employee_Group_Summary_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.HADE_TXT.Text = "Payroll Group Summary"
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

    Private Sub Employee_Group_Summary_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub Employee_Group_Summary_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        Add_Hander_Remove_Handel(False)
        BG_frm.BG_Path_TXT.Text = Path_End
        Frm_foCus()
    End Sub
    Dim Date_Filter As String
    Dim dt As New DataTable
    Public Function Fill_Grid()
        dt.Clear()
        dt.Columns.Clear()
        dt.Reset()

        Grid1.Columns.Clear()
        dt = New DataTable
        dt.Columns.Add("Type")
        dt.Columns.Add("Particulars")
        'dt.Columns.Add("Opning")
        dt.Columns.Add("Debit")
        dt.Columns.Add("Credit")
        dt.Columns.Add("Closing")
        dt.Columns.Add("ID")

        Date_Filter = "Date BETWEEN '" & CDate(Frm_date).ToString("MM-dd-yyyy") & "' and '" & CDate(to_date).ToString("MM-dd-yyyy") & "'"

        Fill_oTher_Group(Date_Filter, dt, 0)


        Dim dv As New DataView(dt)
        Dim Dt_set As New DataTable

        Grid1.DataSource = dt

        Try
            Grid1.CurrentCell = Grid1.Rows(0).Cells(1)
        Catch ex As Exception

        End Try

        Grid1.Columns(0).Visible = False
        Grid1.Columns(5).Visible = False

        Grid1.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Grid1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        'Grid1.Columns(2).Width = Label2.Width + 5
        'Grid1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Grid1.Columns(2).Width = Label4.Width + 5
        Grid1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Grid1.Columns(3).Width = Label4.Width + 5
        Grid1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Grid1.Columns(4).Width = Label8.Width + 5
        Grid1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Label5.Text = Grid1.Rows.Count
    End Function
    Private Function Where_Filter() As String
        Dim q As String
        If Branch <> "Primary" Then
            q &= " AND vc.Branch = '" & Find_DT_Value(Database_File.cre, "TBL_Ledger", "ID", "Name = '" & Branch & "'") & "'"
        End If
        If Delete_Entry = True Then

        Else
            q &= " AND (vc.Visible <> 'Delete')"
        End If
        Return q
    End Function
    Private Function Fill_oTher_Group(Date_Filter As String, dt As DataTable, Closing_ As String)
        Dim dr As DataRow
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand("Select ID,[Name] From TBL_Stock_Group
where Head = 'Payroll' and Visible = 'Approval'", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                Dim cn1 As New SQLiteConnection
                If open_MSSQL_Cstm(Database_File.cre, cn1) = True Then
                    cmd = New SQLiteCommand("Select SUM(Dr) as Dr,SUM(Cr) as Cr, SUM(Dr) - SUM(Cr) as To_
From TBL_VC vc

LEFT JOIN TBL_Payroll_Employee ep
ON vc.Particuls = ep.[ID]

where " & Date_Filter & Where_Filter() & " and vc.Voucher_Type = 'Payroll' and vc.Visible = 'Approval' and vc.CR_DR = 'Under' and ep.Under = '" & r("ID") & "'", cn1)
                    Dim r1 As SQLiteDataReader
                    r1 = cmd.ExecuteReader
                    dr = dt.NewRow
                    While r1.Read
                        dr("ID") = r("ID")
                        dr("Type") = "Head"
                        dr("Particulars") = r("Name")
                        dr("Closing") = r1("To_")
                        dr("Debit") = r1("Dr")
                        dr("Credit") = r1("Cr")
                        dt.Rows.Add(dr)
                    End While
                End If
                If YN_Details = True Then
                    Dim cn2 As New SQLiteConnection
                    If open_MSSQL_Cstm(Database_File.cre, cn2) = True Then
                        cmd = New SQLiteCommand("Select vc.Particuls,(Select [Name] From TBL_Payroll_Employee where id = vc.Particuls) as Employee, SUM(Dr) as Dr,SUM(Cr) as Cr, SUM(Dr) - SUM(Cr) as To_ from TBL_VC VC

LEFT JOIN TBL_Payroll_Employee em
ON VC.Particuls = em.[ID]

where " & Date_Filter & Where_Filter() & " and VC.Voucher_Type = 'Payroll' and vc.CR_DR = 'Under' and em.Under = '" & r("ID") & "'

GROUP BY Particuls
ORDER BY sum(Dr),sum(Cr)", cn2)
                        Dim r2 As SQLiteDataReader
                        r2 = cmd.ExecuteReader
                        While r2.Read
                            dr = dt.NewRow
                            dr("Type") = "Under"
                            dr("ID") = r2("Particuls")
                            dr("Particulars") = r2("Employee")
                            dr("Closing") = r2("To_")
                            dr("Debit") = r2("Dr")
                            dr("Credit") = r2("Cr")
                            dt.Rows.Add(dr)
                        End While
                    End If
                End If
            End While
        End If
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
    Private Sub Grid1_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles Grid1.RowPrePaint
        Dim ro As DataGridViewRow = Grid1.Rows(e.RowIndex)
        If ro.Cells(0).Value = "Head" Then
            If YN_Details = True Then
                ro.DefaultCellStyle.Font = Defolt_Fonts_Bold
            End If
        Else
            If YN_Details = True Then
                ro.DefaultCellStyle.Font = Defolt_Fonts_Bold
                ro.DefaultCellStyle.Padding = New Padding(20, 0, 0, 0)
            End If
        End If
        ro.DefaultCellStyle.BackColor = Color.White
        ro.DefaultCellStyle.SelectionBackColor = Color.FromArgb(254, 197, 48)
    End Sub

    Private Sub Grid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid1.CellContentClick

    End Sub

    Private Sub Grid1_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid1.KeyDown
        If e.KeyCode = Keys.Enter Then
            BG_frm.B_1.PerformClick()
            e.Handled = True
        End If
    End Sub

    Private Sub Employee_Group_Summary_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
    End Sub
End Class