Imports System.Data.SQLite
Imports Management.All_Message_And_Text
Imports Tools
Public Class attandance_controls
    Private Sub attandance_controls_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Dim curr_count As Integer = 0
    Public Function Add_New(isnotauto As Boolean)
        curr_count = bg_panel.Controls.OfType(Of Panel).ToList.Count


        Dim bg_p As Panel = New Panel

        Dim emp_T As TXT = New TXT
        Dim att_T As TXT = New TXT

        Dim bal_head As Label = New Label
        Dim bal_vlu As Label = New Label
        Dim bal_unit As Label = New Label


        Dim vlu_T As TXT = New TXT
        Dim Unit_T As Label = New Label



        With bg_p
            .Controls.Add(emp_T)
            .Controls.Add(att_T)
            .Controls.Add(vlu_T)
            .Controls.Add(Unit_T)

            .Controls.Add(bal_head)
            .Controls.Add(bal_vlu)
            .Controls.Add(bal_unit)

            .Dock = DockStyle.Top
            .Location = New Point(0, 0)
            .Name = "bg_" & (curr_count + 1)
            .Size = New Size(903, 16)
            .TabIndex = curr_count + 1
            .BackColor = Color.Beige


            AddHandler bg_p.Enter, AddressOf bg_panel_Enter
            AddHandler bg_p.Leave, AddressOf bg_panel_Leave
        End With


        With emp_T
            .Back_color = Color.Beige
            .BackColor = Color.Beige
            .BorderStyle = BorderStyle.None
            .Dock = DockStyle.Left
            .Font = New Font("Arial", 10.0, FontStyle.Bold)
            .Name = "employee_" & (curr_count + 1)
            .Width = Label1.Width
            .TabIndex = 0
            .Type_ = "Select"
            .Select_Filter = "(Name LIKE '%<value>%') or (Under LIKE 'Create')"
            .Select_Columns = 0
            .Enabled = isnotauto
            .BringToFront()


            AddHandler emp_T.KeyDown, AddressOf Employee_Keydown
            AddHandler emp_T.Enter, AddressOf Employee_Enter
            AddHandler emp_T.LostFocus, AddressOf Employee_LostFocus
        End With


        With att_T
            .Back_color = Color.Beige
            .BackColor = Color.Beige
            .BorderStyle = BorderStyle.None
            .Dock = DockStyle.Left
            .Font = New Font("Arial", 10.0, FontStyle.Bold)
            .Name = "attendance_" & (curr_count + 1)
            .Width = Label4.Width
            .TabIndex = 1
            .Type_ = "Select"
            .Select_Filter = "(Name LIKE '%<value>%') or (Unit LIKE 'Create' or Unit LIKE 'Salary Details')"
            .Select_Columns = 0
            .Enabled = isnotauto
            .BringToFront()

            AddHandler att_T.KeyDown, AddressOf Attendance_Keydown
            AddHandler att_T.LostFocus, AddressOf Attendance_LostFocus
        End With

        With bal_head
            .BackColor = Color.Transparent
            .BorderStyle = BorderStyle.None
            .Dock = DockStyle.Left
            .Font = New Font("Arial", 10.0, FontStyle.Italic)
            .Name = "balhead_" & (curr_count + 1)
            .Text = "Cur. Bal. :"
            .Width = 80
            .TextAlign = ContentAlignment.MiddleLeft
            .TabIndex = 0
            .BringToFront()
        End With

        With bal_vlu
            .BackColor = Color.Transparent
            .BorderStyle = BorderStyle.None
            .Dock = DockStyle.Left
            .Font = New Font("Arial", 10.0, FontStyle.Italic Or FontStyle.Bold)
            .Name = "balvlu_" & (curr_count + 1)
            .Text = "0.00"
            .Width = 120
            .TextAlign = ContentAlignment.MiddleRight
            .TabIndex = 0
            .BringToFront()
        End With

        With bal_unit
            .BackColor = Color.Transparent
            .BorderStyle = BorderStyle.None
            .Dock = DockStyle.Left
            .Font = New Font("Arial", 10.0, FontStyle.Italic Or FontStyle.Bold)
            .Name = "balunit_" & (curr_count + 1)
            .Text = ""
            .Width = 80
            .TextAlign = ContentAlignment.MiddleLeft
            .TabIndex = 0
            .BringToFront()
        End With


        '-------------------------------------------------------------------------
        With vlu_T
            .Back_color = Color.Beige
            .BackColor = Color.Beige
            .BorderStyle = BorderStyle.None
            .Dock = DockStyle.Right
            .Font = New Font("Arial", 10.0, FontStyle.Bold)
            .Name = "vlu_" & (curr_count + 1)
            .Width = Label3.Width
            .TabIndex = 2
            .Type_ = "Num"
            .TextAlign = HorizontalAlignment.Right
            .SendToBack()

            AddHandler vlu_T.KeyDown, AddressOf Value_Keydown
            AddHandler vlu_T.LostFocus, AddressOf Value_LostFocus
        End With

        With Unit_T
            .BackColor = Color.Beige
            .BorderStyle = BorderStyle.None
            .Dock = DockStyle.Right
            .Font = New Font("Arial", 10.0, FontStyle.Bold)
            .Name = "unit_" & (curr_count + 1)
            .Width = Label2.Width
            .TextAlign = ContentAlignment.MiddleLeft
            .TabIndex = 0
            .SendToBack()
        End With


        bg_panel.Controls.Add(bg_p)
        bg_p.BringToFront()

        List_set(curr_count + 1)

        If curr_count = 1 Then
            Fill_Data_Source(CDate(Payroll_Vouchers_frm.Date_TXT.Text), False)
        End If
    End Function

    Dim emp_list As List_frm
    Dim att_list As List_frm
    Private Function List_set(idx As Integer)
        Dim emp As TXT = Find_Employee_TXT(idx)
        Dim att As TXT = Find_Attendance_TXT(idx)

        emp_list = New List_frm
        List_Setup("List of Employee", Select_List.Right_Dock, Select_List_Format.Defolt, emp, emp_list, Employee_Source, 320)
        emp_list.System_Data_integer = 1

        att_list = New List_frm
        List_Setup("List of Attendance/Production Types", Select_List.Right_Dock, Select_List_Format.Defolt, att, att_list, Attendance_Source, 320)
        att_list.System_Data_integer = 1

    End Function
    Public Function Fill_Data_Source(dtd As Date, ifstart As Boolean)
        Dim cn As New SQLiteConnection
        Dim r As SQLiteDataReader

        Dim dr As DataRow
        Dim dt As New DataTable

        dt.Columns.Add("Name")
        dt.Columns.Add("Under")
        dt.Columns.Add("ID")

        dt.Rows.Add("", "Create", "")
        If ifstart = False Then
            dt.Rows.Add("End of List", "", "")
        End If


        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select em.ID,em.Name,
(Select sg.Name From TBL_Stock_Group sg where sg.ID = em.Under and Head = 'Payroll') as Group_Name From TBL_Payroll_Employee em 
where [Date_of_joining] <= '{dtd.ToString(Lite_date_Format)}' and {Company_Visible_Filter}", cn)

            r = cmd.ExecuteReader

            While r.Read
                dr = dt.NewRow
                dr("ID") = r("ID").ToString
                dr("Name") = r("Name").ToString
                dr("Under") = r("Group_Name").ToString
                dt.Rows.Add(dr)

            End While
            r.Close()
            Employee_Source.DataSource = dt

            Fill_Attendance_Type(0)
        End If
    End Function
    Private Function Fill_Attendance_Type(em As String) As Integer
        Dim ans As Integer = 0


        Dim dt As New DataTable
        Dim dr As DataRow

        dt = New DataTable
        dt.Columns.Add("Name")
        dt.Columns.Add("Unit")
        dt.Columns.Add("ID")

        dt.Rows.Add("", "Salary Details", "")


        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select *,(Select u.Symbol From TBL_Inventory_Unit u where u.ID = [Unit]) as Unit_Name From (
Select at.ID,at.name,at.Unit,at.Attendance_Type
 From TBL_Payroll_SalaryDetails sd
LEFT JOIN TBL_PayHead phd on Phd.ID = sd.Payhead
CROSS JOIN TBL_Payroll_Att_Production_Type at On (at.ID = phd.Leave_without_pay or at.ID = phd.Production)
WHERE sd.Account = '{em}' and phd.Visible = 'Approval' and at.Visible = 'Approval'
AND sd.[Date] = (Select sd1.[Date] From TBL_Payroll_SalaryDetails sd1 where sd1.Account = sd.Account and sd1.[Date] <= '{CDate(Payroll_Vouchers_frm.Date_TXT.Text).AddDays(1).ToString(Lite_date_Format)}' ORDER By sd1.[Date] DESC LIMIT 1)
)Group By ID", cn)
            Dim r As SQLiteDataReader

            r = cmd.ExecuteReader
            While r.Read
                dr = dt.NewRow
                dr("ID") = r("ID")
                dr("Name") = r("Name")
                If r("Attendance_Type") = "Production" Then
                    dr("Unit") = r("Unit_Name")
                Else
                    dr("Unit") = "Day"
                End If
                dt.Rows.Add(dr)
            End While
            If dt.Rows.Count = 0 Then
                dt.Rows.Add("Not Applicable", "", "0")
                ans = 0
            Else
                ans = dt.Rows.Count
            End If
            Attendance_Source.DataSource = dt
        End If
        Return ans
    End Function
    Private Sub Value_Keydown(sender As Object, e As KeyEventArgs)
        Dim i As Integer = Find_Idx(sender)

        If e.KeyCode = Keys.Enter Then
            NOT_Clear()

            If bg_panel.Controls.Count = i Then
                If Find_Employee_TXT(i).Data_Link_ <> Nothing Then
                    Add_New(True)
                Else
                End If
            Else
            End If
        End If
    End Sub
    Private Sub Employee_LostFocus(sender As Object, e As EventArgs)
        Employee_Source.MoveFirst()
    End Sub
    Private Sub Value_LostFocus(sender As Object, e As EventArgs)
        Dim i As Integer = Find_Idx(sender)
        Balance_Set(i)
    End Sub
    Private Sub Attendance_LostFocus(sender As Object, e As EventArgs)
        Attendance_Source.MoveFirst()
    End Sub
    Private Sub Attendance_Keydown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            If att_list.List_Grid.CurrentRow.Cells(1).Value = "Salary Details" Then
                Alter_Salary_Details(sender)
                Exit Sub
            End If
            sender.Data_Link_ = att_list.List_Grid.CurrentRow.Cells(2).Value.ToString
        End If

        If e.KeyCode = Keys.C AndAlso e.Modifiers = Keys.Alt Then
            Create_Employee(sender)
        ElseIf e.KeyCode = Keys.Enter AndAlso e.Modifiers = Keys.Control Then
            Cell("Salary Details", "", "Employee wise", Find_Employee_TXT(Find_Idx(sender)).Data_Link_)
            Payroll_Salary_details_frm.Focus()
            Payroll_Salary_details_frm.close_link_yn = True
            Payroll_Salary_details_frm.close_focus_obj = sender


            AddHandler Payroll_Salary_details_frm.Disposed, AddressOf Salary_Details_Disposed
        ElseIf e.KeyCode = Keys.Enter Then
            Dim i As Integer = Find_Idx(sender)

            Find_Unit_Lab(i).Text = att_list.List_Grid.CurrentRow.Cells(1).Value.ToString
            Find_balunit_Lab(i).Text = att_list.List_Grid.CurrentRow.Cells(1).Value.ToString
            Balance_Set(i)
        End If
    End Sub
    Public Sub Salary_Details_Disposed(sender As Object, e As EventArgs)
        Frm_foCus()
        Fill_Attendance_Type(Payroll_Salary_details_frm.VC_ID_)
    End Sub
    Private Function Alter_Salary_Details(sender As TXT)
        Cell("Salary Details", "", "Employee wise", Find_Employee_TXT(Find_Idx(sender)).Data_Link_)
        Payroll_Salary_details_frm.Focus()
        Payroll_Salary_details_frm.close_link_yn = True
        Payroll_Salary_details_frm.close_focus_obj = sender


        AddHandler Payroll_Salary_details_frm.Disposed, AddressOf Salary_Details_Disposed
    End Function
    Private Function Create_Employee(sender As TXT)
        Cell("Payroll Employee", "", "Create_Close", "")
        Payroll_Employee_frm.Name_TXT.Text = sender.Text
        Payroll_Employee_frm.close_link_yn = True
        Payroll_Employee_frm.close_focus_obj = sender
    End Function
    Private Function Balance_Set(i As Integer)

        Dim emp_id As Integer = Val(Find_Employee_TXT(i).Data_Link_)
        Dim att_id As Integer = Val(Find_Attendance_TXT(i).Data_Link_)

        If emp_id = 0 Or att_id = 0 Then
        Else
            Dim cn As New SQLiteConnection
            If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                cmd = New SQLiteCommand($"Select SUM(vt.Value) as Vlu From TBL_Attendance_VC vt where vt.Employee = '{emp_id}' and vt.Attendance_ID = '{att_id}' and vt.[Date] < '{CDate(Payroll_Vouchers_frm.Date_TXT.Text).AddDays(1).ToString(Lite_date_Format)}' and vt.Tra_ID <> '{Payroll_Vouchers_frm.Tra_ID}'", cn)
                Dim r As SQLiteDataReader = cmd.ExecuteReader

                While r.Read
                    Find_balvlu_Lab(i).Text = N2_FORMATE(r("Vlu").ToString)
                End While
                r.Close()
            End If
            Find_balvlu_Lab(i).Text = N2_FORMATE(nUmBeR_FORMATE(Find_balvlu_Lab(i).Text) + Val(Find_Value_TXT(i).Text))
        End If

    End Function
    Private Sub Employee_Enter(sender As Object, e As EventArgs)
        Dim i As Integer = Find_Idx(sender)
    End Sub
    Private Sub Employee_Keydown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            If emp_list.List_Grid.CurrentRow.Cells(1).Value = "Create" Then
                Create_Employee(sender)
                Exit Sub
            End If
            sender.Data_Link_ = emp_list.List_Grid.CurrentRow.Cells(2).Value.ToString
        End If

        If e.KeyCode = Keys.C AndAlso e.Modifiers = Keys.Alt Then
            Create_Employee(sender)
            Exit Sub
        ElseIf e.KeyCode = Keys.Enter AndAlso e.Modifiers = Keys.Control Then
            Cell("Payroll Employee", "", "Alter_Close", sender.Data_Link_)
            Payroll_Employee_frm.close_focus_obj = sender
            Exit Sub
        ElseIf e.KeyCode = Keys.Enter Then
            Dim i As Integer = Find_Idx(sender)
            If sender.Data_Link_ = Nothing Then
                Find_Attendance_TXT(i).Enabled = False
                Find_Attendance_TXT(i).Text = ""

                Find_Value_TXT(i).Enabled = False
                Find_Value_TXT(i).Text = ""

                Find_Unit_Lab(i).Text = ""
            Else
                Dim ii As Integer = Fill_Attendance_Type(sender.Data_Link_)
                If ii = 0 Then
                    e.Handled = True
                    sender.Text = ""
                    SendKeys.Send("+{TAB}")
                    Msg_Custom_YN(NOT_Location.Bottom_Right, Color.OrangeRed, My.Resources.Exclamation_PNG, Dialoag_Button.Ok, "Input Error", "Salary Details", "You have not entered the salary details of the selected employee,<nl>so you cannot complete the attendance")
                ElseIf ii = 1 Then
                    SendKeys.Send("{Enter}")
                End If

                Find_Attendance_TXT(i).Enabled = True
                Find_Value_TXT(i).Enabled = True

                Balance_Set(i)
            End If
        End If
    End Sub

    Public Function Find_Employee_TXT(Index As Integer) As TXT
        Try
            Return CType(Me.Controls.Find(("employee_" & Index), True).First, TXT)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Bg_Panel(Index As Integer) As Panel
        Try
            Return CType(Me.Controls.Find(("bg_" & Index), True).First, Panel)
        Catch ex As Exception

        End Try
    End Function

    Public Function Find_Attendance_TXT(Index As Integer) As TXT
        Try
            Return CType(Me.Controls.Find(("attendance_" & Index), True).First, TXT)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Value_TXT(Index As Integer) As TXT
        Try
            Return CType(Me.Controls.Find(("vlu_" & Index), True).First, TXT)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Unit_Lab(Index As Integer) As Label
        Try
            Return CType(Me.Controls.Find(("unit_" & Index), True).First, Label)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_balHead_Lab(Index As Integer) As Label
        Try
            Return CType(Me.Controls.Find(("balhead_" & Index), True).First, Label)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_balvlu_Lab(Index As Integer) As Label
        Try
            Return CType(Me.Controls.Find(("balvlu_" & Index), True).First, Label)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_balunit_Lab(Index As Integer) As Label
        Try
            Return CType(Me.Controls.Find(("balunit_" & Index), True).First, Label)
        Catch ex As Exception

        End Try
    End Function


    Public Function Find_ID_Lab(Index As Integer) As Label
        Try
            Return CType(Me.Controls.Find(("unit_" & Index), True).First, Label)
        Catch ex As Exception

        End Try
    End Function


    Public Function Find_Idx(sender As Object) As Integer
        Return sender.Name.Split("_")(1)
    End Function

    Private Sub bg_panel_Enter(sender As Object, e As EventArgs)
        Dim col As Color = Color.FromArgb(252, 227, 156)
        'RGB(254, 237, 194)
        sender.BackColor = col
        Dim idx As Integer = Find_Idx(sender)

        Find_Employee_TXT(idx).Back_color = col
        Find_Attendance_TXT(idx).Back_color = col
        Find_Value_TXT(idx).Back_color = col

        Find_Employee_TXT(idx).BackColor = col
        Find_Attendance_TXT(idx).BackColor = col
        Find_Value_TXT(idx).BackColor = col
        Find_Unit_Lab(idx).BackColor = col

    End Sub

    Private Sub bg_panel_Leave(sender As Object, e As EventArgs)
        Dim col As Color = bg_panel.BackColor
        sender.BackColor = col

        Dim idx As Integer = Find_Idx(sender)

        Find_Employee_TXT(idx).Back_color = col
        Find_Attendance_TXT(idx).Back_color = col
        Find_Value_TXT(idx).Back_color = col

        Find_Employee_TXT(idx).BackColor = col
        Find_Attendance_TXT(idx).BackColor = col
        Find_Value_TXT(idx).BackColor = col
        Find_Unit_Lab(idx).BackColor = col
    End Sub

    Private Sub attandance_controls_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        If curr_count >= 1 Then
            Fill_Data_Source(CDate(Payroll_Vouchers_frm.Date_TXT.Text), False)
        Else
            Fill_Data_Source(CDate(Payroll_Vouchers_frm.Date_TXT.Text), True)
        End If
    End Sub
End Class
