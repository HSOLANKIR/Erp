Imports System.Data.SQLite

Public Class Payroll_Statement_frm
    Dim From_ID As String

    Private VC_Type_ As String
    Private phd_ID As String = "NA"
    Private emp_ID As String = "0"
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
    Private Sub Payroll_Statement_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text

        VC_Type_ = Link_Valu(1)
        phd_ID = Link_Valu(2)
        emp_ID = 0

        Panel_Manag(employee_panel)

        Frm_Date_LB.Text = Date_Formate(Date_1)
        To_Date_LB.Text = Date_Formate(Date_2)

        BG_frm.HADE_TXT.Text = "Payroll Statement"
        BG_frm.TYP_TXT.Text = VC_Type_


        Fill_Source()
        List_Fill()

        'Button_Manage()
        Add_Hander_Remove_Handel(True)
        Branch = Branch_Name

        Update_Report = True

        Txt1.Focus()

    End Sub
    Private Function Button_Manage()
        Button_Clear()
        BG_frm.B_1.Text = "|&R : Refresh"
        BG_frm.B_3.Text = "|&P : Print"

        BG_frm.R_2.Text = "F2 : Date"
        BG_frm.R_3.Text = "|F2 : Period"
        BG_frm.R_4.Text = "|F3 : Employee"
        If Branch_Visible() = True Then
            BG_frm.R_5.Text = "F4 : Branch"
        End If

        BG_frm.R_22.Text = "F12 : Configuration"
    End Function
    Private Function Add_Hander_Remove_Handel(Ans As Boolean)
        If Ans = True Then
            AddHandler BG_frm.KeyDown, AddressOf Me.BG_Keydown
            AddHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            AddHandler BG_frm.R_2.Click, AddressOf Me.R_3_Click
            AddHandler BG_frm.R_3.Click, AddressOf Me.R_4_Click
            AddHandler BG_frm.R_4.Click, AddressOf Me.R_6_Click
            AddHandler BG_frm.R_5.Click, AddressOf Me.R_5_Click
        Else
            RemoveHandler BG_frm.KeyDown, AddressOf Me.BG_Keydown
            RemoveHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            RemoveHandler BG_frm.R_2.Click, AddressOf Me.R_3_Click
            RemoveHandler BG_frm.R_3.Click, AddressOf Me.R_4_Click
            RemoveHandler BG_frm.R_4.Click, AddressOf Me.R_6_Click
            RemoveHandler BG_frm.R_5.Click, AddressOf Me.R_5_Click
        End If
    End Function
    Private Sub BG_Keydown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.F1 AndAlso e.Modifiers = Keys.Alt Then
            BG_frm.R_1.PerformClick()
        End If
        If e.KeyCode = Keys.F2 AndAlso e.Modifiers = Keys.Alt Then
            BG_frm.R_3.PerformClick()
        ElseIf e.KeyCode = Keys.F2 Then
            BG_frm.R_2.PerformClick()
        End If
        If e.KeyCode = Keys.F4 AndAlso e.Modifiers = Keys.Alt Then

        ElseIf e.KeyCode = Keys.F4 Then
            BG_frm.R_5.PerformClick()
        End If
    End Sub
    Private Sub B_1_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Fill_Grid()
        End If
    End Sub
    Private Sub R_3_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Set_Date(False, Me)
        End If
    End Sub
    Private Sub R_6_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then

        End If
    End Sub
    Private Sub R_4_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Set_Date(True, Me)
        End If
    End Sub
    Private Sub R_5_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then

        End If
    End Sub
    Private Function Panel_Manag(pa As Panel)
        bg_Panel.Visible = False
        employee_panel.Visible = False

        If pa.Name = bg_Panel.Name Then
            Button_Manage()
        Else
            Button_Clear()
        End If

        pa.Dock = DockStyle.Fill
        pa.Visible = True
    End Function
    Private Sub Payroll_Statement_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.HADE_TXT.Text = "Payroll Statement"
        BG_frm.TYP_TXT.Text = VC_Type_

        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text
        Button_Clear()
        Button_Manage()
        'Config_Fill()
        Fill_Grid()


        If bg_Panel.Visible = True Then
            Grid1.Focus()
        ElseIf employee_panel.Visible = True Then

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
    Public Function Fill_Grid()
        If phd_ID <> "NA" Then
            Label1.Text = Find_DT_Value(Database_File.cre, "TBL_Payroll_Employee", "Name", $"ID = '{emp_ID}'")
            Label3.Text = Find_DT_Value(Database_File.cre, "TBL_Payhead", "Name", $"ID = '{phd_ID}'")

            If Label1.Text = Nothing Then
                Label1.Text = "All Employee"
            End If


            'Create New Data Tabale
            Dim dt As New DataTable
            Dim cn As New SQLiteConnection
            Dim r As SQLiteDataReader

            dt.Columns.Add("Name")
            dt.Columns.Add("Value")


            Dim emp_filter As String = ""
            If emp_ID <> "0" Then
                emp_filter = $" and em.ID = '{emp_ID}'"
            End If

            If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                cmd = New SQLiteCommand($"Select em.ID as e_ID,em.Name as e_Name,
(Select ifnull(SUM(vc.Dr),0)-ifnull(SUM(vc.Cr),0) From TBL_VC_Payroll vc where vc.Employee = em.ID and vc.Payhead = '{phd_ID}' and (vc.Date BETWEEN '{CDate(Frm_date).ToString(Lite_date_Format)}' and '{CDate(to_date).AddDays(1).ToString(Lite_date_Format)}')) as Vlu
From TBL_Payroll_Employee em
WHERE em.Visible = 'Approval' {emp_filter}", cn)
                r = cmd.ExecuteReader
                Dim ro As DataRow

                'My.Computer.Clipboard.SetText(cmd.CommandText)
                While r.Read
                    If Val(r("Vlu").ToString) <> 0 Then
                        ro = dt.NewRow
                        ro("Name") = r("e_Name")
                        Dim uni As String
                        If Val(r("Vlu").ToString) < 0 Then
                            uni = $"{N2_FORMATE(Val(r("Vlu")) * -1)} {Positive_Value_fech}"
                        Else
                            uni = $"{N2_FORMATE(Val(r("Vlu")))} {Negative_Value_fech}"
                        End If

                        ro("Value") = $"{uni}"
                        dt.Rows.Add(ro)
                    End If
                End While

                Grid1.DataSource = dt
            End If


            With Grid1

                For i As Integer = 1 To Grid1.ColumnCount - 1
                    .Columns(i).Width = 100
                    .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                Next

                .Columns(0).Width = 200
                .Columns(0).Frozen = True

                Dim total_h As Integer = Val(Grid1.ColumnCount - 1) * 100

                If total_h <= Grid1.Width Then
                    .Columns(0).Frozen = False
                    .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                End If

            End With

        End If
    End Function
    Private Sub Payroll_Statement_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If bg_Panel.Visible = True Then
                Panel_Manag(employee_panel)
                TX.Focus()
            ElseIf employee_panel.Visible = True Then
                Me.Dispose()
            End If
        End If
    End Sub

    Private Sub Payroll_Statement_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        Add_Hander_Remove_Handel(False)
        BG_frm.BG_Path_TXT.Text = Path_End
        Frm_foCus()
    End Sub
    Private Sub Frm_Date_LB_TextChanged(sender As Object, e As EventArgs) Handles Frm_Date_LB.TextChanged
        Frm_date = Frm_Date_LB.Text
    End Sub
    Private Sub To_Date_LB_TextChanged(sender As Object, e As EventArgs) Handles To_Date_LB.TextChanged
        to_date = To_Date_LB.Text
    End Sub
    Private Sub Grid1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles Grid1.CellFormatting
        If Grid1.CurrentCell IsNot Nothing Then
            If e.RowIndex = Grid1.CurrentCell.RowIndex And e.ColumnIndex = Grid1.CurrentCell.ColumnIndex Then
                e.CellStyle.SelectionBackColor = Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(48, Byte), Integer))
            Else
                e.CellStyle.SelectionBackColor = Grid1.DefaultCellStyle.SelectionBackColor
            End If
        End If
    End Sub

    Private Sub Grid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid1.CellContentClick

    End Sub

    Private Sub Grid1_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid1.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            Dim em As String = Grid1.CurrentRow.Cells(0).Value
            em = Find_DT_Value(Database_File.cre, "TBL_Payroll_Employee", "ID", $"Name = '{em}' and Visible = 'Approval'")
            Cell("Payroll Vouchers", em, phd_ID)
        End If

    End Sub

    Private Sub Payroll_Sheett_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID

        If bg_Panel.Visible = True Then
            Grid1.Focus()
        ElseIf employee_panel.Visible = True Then

        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        obj_top(Panel1)
    End Sub
    Private Function Fill_Source()
        Dim cn As New SQLiteConnection
        Dim dt As New DataTable
        Dim dr As DataRow

        Dim r As SQLiteDataReader

        dt.Columns.Add("Name")
        dt.Columns.Add("Alias")
        dt.Columns.Add("ID")
        dt.Rows.Add("All Employee", "", "0")

        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand("Select em.ID,em.Name,(Select sg.Name From TBL_Stock_Group sg where sg.ID = em.[Under]) as Under_Name
From TBL_Payroll_Employee em where em.Visible = 'Approval'", cn)
            r = cmd.ExecuteReader
            While r.Read
                dr = dt.NewRow
                dr("ID") = r("ID")
                dr("Name") = r("Name")
                dr("Alias") = r("Under_Name")
                dt.Rows.Add(dr)
            End While
            Employee_Source.DataSource = dt

            dt = New DataTable
            dt.Columns.Add("Name")
            dt.Columns.Add("Alias")
            dt.Columns.Add("ID")

            cmd = New SQLiteCommand("Select phd.ID,phd.Name
From TBL_Payhead phd where phd.Visible = 'Approval'", cn)
            r = cmd.ExecuteReader
            While r.Read
                dr = dt.NewRow
                dr("ID") = r("ID")
                dr("Name") = r("Name")
                dr("Alias") = ""
                dt.Rows.Add(dr)
            End While
            Payhead_Source.DataSource = dt
        End If
    End Function
    Public em_list As List_frm
    Public phd_list As List_frm
    Private Function List_Fill()
        obj_top(Panel1)

        em_list = New List_frm
        List_Setup("List of Employee", Select_List.Right_Dock, Select_List_Format.Defolt, TX, em_list, Employee_Source, 350)

        phd_list = New List_frm
        List_Setup("List of Payhead", Select_List.Right_Dock, Select_List_Format.Defolt, Txt1, phd_list, Payhead_Source, 350)

    End Function

    Private Sub TX_TextChanged(sender As Object, e As EventArgs) Handles TX.TextChanged

    End Sub

    Private Sub TX_KeyDown(sender As Object, e As KeyEventArgs) Handles TX.KeyDown
        If e.KeyCode = Keys.Enter Then
            emp_ID = em_list.List_Grid.CurrentRow.Cells(2).Value
        End If
    End Sub

    Private Sub Txt1_TextChanged(sender As Object, e As EventArgs) Handles Txt1.TextChanged

    End Sub

    Private Sub Txt1_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt1.KeyDown
        If e.KeyCode = Keys.Enter Then
            phd_ID = phd_list.List_Grid.CurrentRow.Cells(2).Value

            If emp_ID <> "NA" And phd_ID <> "NA" Then
                Panel_Manag(bg_Panel)
                Fill_Grid()
            End If
        End If
    End Sub
End Class