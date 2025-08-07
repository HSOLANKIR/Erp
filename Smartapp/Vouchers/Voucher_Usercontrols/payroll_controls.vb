Imports System.Data.SqlClient
Imports System.Data.SQLite
Imports System.Reflection
Imports Tools
Public Class payroll_controls
    Private Sub payroll_controls_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Dim curr_count As Integer = 0
    Dim _Name_ As String

    Private Amt_ As New List(Of Label)

    Public Function Clear_All()
        Amt_.Clear()
    End Function
    Public Function Add_New(isenabale As Boolean)
        curr_count = bg_panel.Controls.OfType(Of Panel).ToList.Count

        _Name_ = (curr_count + 1)

        Dim bg_p As Panel = New Panel
        Dim emp_p As Panel = New Panel
        Dim under_p As Panel = New Panel

        Dim total_Lab As Label = New Label

        Dim border_panel As Panel = New Panel


        With bg_p
            .Controls.Add(emp_p)
            .Controls.Add(under_p)
            .Controls.Add(border_panel)
            .Controls.Add(total_Lab)

            .Dock = DockStyle.Top
            .Location = New Point(0, 0)
            .Name = "bg_" & _Name_
            .Size = New Size(903, 100)
            .TabIndex = curr_count + 1
            .BackColor = Color.Beige
            .AutoSize = True
            .Enabled = isenabale
        End With

        With total_Lab
            .Name = "Total_" & _Name_
            .Visible = False
            Amt_.Add(total_Lab)
        End With

        With under_p
            .Dock = DockStyle.Top
            .Location = New Point(0, 0)
            .Name = "bgunder_" & _Name_
            .Size = New Size(903, 100)
            .TabIndex = 1
            .BackColor = Color.Beige
            .AutoSize = True
            .BringToFront()
        End With
        With border_panel
            .Dock = DockStyle.Top
            .Height = 1
            .BackColor = Color.Gainsboro
            .BringToFront()
        End With

        Employee_Panel_add(emp_p)

        bg_panel.Controls.Add(bg_p)
        bg_p.BringToFront()



        'Add_Under(curr_count + 1)
        'Add_Under(curr_count + 1)
        'Add_Under(curr_count + 1)


        List_set_H(curr_count + 1)
    End Function


    Private Function Employee_Panel_add(pan As Panel)
        Dim emp_ As New TXT
        Dim vlu_ As New Label
        Dim vlu_T As New Label


        With pan
            .Controls.Add(emp_)
            .Controls.Add(vlu_)
            .Controls.Add(vlu_T)

            .Dock = DockStyle.Top
            .Location = New Point(0, 0)
            .Name = "empPanel_" & _Name_
            .Size = New Size(903, 16)
            .TabIndex = 0
            .BackColor = Color.Beige

            AddHandler pan.Enter, AddressOf bg_panel_H_Enter
            AddHandler pan.Leave, AddressOf bg_panel_H_Leave
        End With


        With emp_
            .Back_color = Color.Beige
            .BackColor = Color.Beige
            .BorderStyle = BorderStyle.None
            .Dock = DockStyle.Left
            .Font = New Font("Arial", 9.75, FontStyle.Bold)
            .Name = "employee_" & (curr_count + 1)
            .Width = Label1.Width
            .TabIndex = 0
            .Type_ = "Select"
            .Select_Filter = "(Name LIKE '%<value>%' or [Under] LIKE 'Create')"
            .Select_Columns = 0
            .BringToFront()

            AddHandler emp_.KeyDown, AddressOf Employee_Keydown
            AddHandler emp_.Enter, AddressOf Employee_Enter
            AddHandler emp_.LostFocus, AddressOf Employee_LostFocus
        End With



        With vlu_
            .BackColor = Color.Transparent
            .BorderStyle = BorderStyle.None
            .Dock = DockStyle.Right
            .Font = New Font("Arial", 9.75, FontStyle.Bold)
            .Name = "valuH_" & (curr_count + 1)
            .Text = "0.00"
            .Width = Val(Label2.Width) - 25
            .TextAlign = ContentAlignment.MiddleRight
            .TabIndex = 0
            .SendToBack()
        End With

        With vlu_T
            .BackColor = Color.Beige
            .BorderStyle = BorderStyle.None
            .Dock = DockStyle.Right
            .Font = New Font("Arial", 9.75, FontStyle.Bold)
            .Name = "valutypeH_" & (curr_count + 1)
            .Text = "Dr"
            .Width = 25
            .TextAlign = ContentAlignment.MiddleLeft
            .TabIndex = 0
            .SendToBack()
        End With

    End Function
    Public Function Add_Under(idx As Integer)
        Dim i2 As Integer = Find_bg_Under(idx).Controls.Count + 1
        Dim bg_ As New Panel

        Dim Space_lab As New Label
        Dim Phd_TXT As New TXT

        Dim bal_vlu_inner As Label = New Label

        Dim bal_head As Label = New Label
        Dim bal_vlu As Label = New Label
        Dim bal_unit As Label = New Label

        Dim Amt_TXT As New TXT
        Dim Amt_type As New TXT




        With bg_
            .Controls.Add(Space_lab)
            .Controls.Add(Phd_TXT)

            .Controls.Add(bal_head)
            .Controls.Add(bal_vlu)
            .Controls.Add(bal_unit)

            .Controls.Add(bal_vlu_inner)

            .Controls.Add(Amt_TXT)
            .Controls.Add(Amt_type)


            .Dock = DockStyle.Top
            .Location = New Point(0, 0)
            .Name = $"underPanelU_{idx}_{i2}"
            .Size = New Size(903, 16)
            .TabIndex = i2
            .BackColor = Color.Beige



            AddHandler .Enter, AddressOf bg_panel_U_Enter
            AddHandler .Leave, AddressOf bg_panel_U_Leave
        End With

        With Space_lab
            .BackColor = Color.Beige
            .Dock = DockStyle.Left
            .Width = 100
            .AutoSize = False
            .BringToFront()
        End With

        With Phd_TXT
            .Back_color = Color.Beige
            .BackColor = Color.Beige
            .BorderStyle = BorderStyle.None
            .Dock = DockStyle.Left
            .Font = New Font("Arial", 9.75, FontStyle.Bold)
            .Name = $"payhead_{idx}_{i2}"
            .Width = 300
            .TabIndex = 0
            .Type_ = "Select"
            .Select_Filter = "(Name LIKE '%<value>%')"
            .Select_Columns = 0
            .BringToFront()

            AddHandler .KeyDown, AddressOf Phd_Keydown
            AddHandler .Enter, AddressOf Phd_Enter
            AddHandler .LostFocus, AddressOf Phd_LostFocus
        End With

        With Amt_TXT
            .Back_color = Color.Beige
            .BackColor = Color.Beige
            .BorderStyle = BorderStyle.None
            .TextAlign = HorizontalAlignment.Right
            .Dock = DockStyle.Left
            .Font = New Font("Arial", 9.75, FontStyle.Bold)
            .Name = $"amountU_{idx}_{i2}"
            .Width = 100
            .TabIndex = 1
            .Type_ = "Num"
            .Text = "0.00"
            .BringToFront()

            AddHandler .KeyDown, AddressOf Amount_U_Keydown
        End With


        With Amt_type
            .Back_color = Color.Beige
            .BackColor = Color.Beige
            .BorderStyle = BorderStyle.None
            .TextAlign = HorizontalAlignment.Center
            .Dock = DockStyle.Left
            .Font = New Font("Arial", 9.75, FontStyle.Bold)
            .Name = $"amounttypeU_{idx}_{i2}"
            .Width = 25
            .TabIndex = 2
            .Type_ = "Select"
            .Select_Filter = "(Name LIKE '%<value>%')"
            .Text = ""
            .Select_Columns = 0
            .BringToFront()

            AddHandler .TextChanged, AddressOf Amount_Type_U_TextChange
            AddHandler .KeyDown, AddressOf Amount_Type_U_Keydown

        End With


        With bal_head
            .BackColor = Color.Transparent
            .BorderStyle = BorderStyle.None
            .Dock = DockStyle.Left
            .Font = New Font("Arial", 10.0, FontStyle.Italic)
            .Name = $"balhead_{idx}_{i2}"
            .Text = "Cur. Bal. :"
            .Width = 100
            .TextAlign = ContentAlignment.MiddleLeft
            .Padding = New Padding(20, 0, 0, 0)
            .TabIndex = 0
            .BringToFront()
        End With

        With bal_vlu_inner
            .Visible = False
            .Name = $"balclosing_{idx}_{i2}"
        End With

        With bal_vlu
                .BackColor = Color.Transparent
                .BorderStyle = BorderStyle.None
                .Dock = DockStyle.Left
            .Font = New Font("Arial", 9.75, FontStyle.Italic Or FontStyle.Bold)
            .Name = $"balvlu_{idx}_{i2}"
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
            .Font = New Font("Arial", 9.75, FontStyle.Italic Or FontStyle.Bold)
            .Name = $"balunit_{idx}_{i2}"
            .Text = ""
            .Width = 80
            .TextAlign = ContentAlignment.MiddleLeft
            .TabIndex = 0
            .BringToFront()
        End With

        Find_bg_Under(idx).Controls.Add(bg_)
        bg_.BringToFront()

        List_set_U(idx, i2)

    End Function
    Private Sub Employee_LostFocus(sender As Object, e As EventArgs)
        Employee_Source.MoveFirst()
    End Sub

    Private Sub Phd_LostFocus(sender As Object, e As EventArgs)
        Phd_Source.MoveFirst()
    End Sub

    Private Sub Employee_Enter(sender As Object, e As EventArgs)
        Dim i As Integer = Find_Idx(sender)
    End Sub

    Private Sub Phd_Enter(sender As Object, e As EventArgs)
        Dim i1 As Integer = Find_Idx(sender)
        Dim i2 As Integer = Find_Idx2(sender)
    End Sub


    Private Sub Amount_U_Keydown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Dim i As Integer = Find_Idx(sender)
            Dim i2 As Integer = Find_Idx2(sender)

            Head_Clculation(i)
            Balance_Offline(i, i2)
        End If
    End Sub
    Public Function Head_Clculation(i As Integer)
        Dim vlu As Decimal = 0.00

        For Each p As Panel In Find_bg_Under(i).Controls.OfType(Of Panel)()
            Dim i2 As Integer = Find_Idx2(p)

            If Find_Amount_Type_Under_TXT(i, i2).Text = "Cr" Then
                vlu = Val(vlu) + Val(Find_Amount_Under_TXT(i, i2).Text)
            ElseIf Find_Amount_Type_Under_TXT(i, i2).Text = "Dr" Then
                vlu = Val(vlu) - Val(Find_Amount_Under_TXT(i, i2).Text)
            End If
        Next

        Find_Total(i).Text = vlu

        If vlu < 0 Then
            Find_Value_H_TXT(i).Text = N2_FORMATE(vlu * -1)
            Find_Value_Type_H_TXT(i).Text = "Dr"
        Else
            Find_Value_H_TXT(i).Text = N2_FORMATE(vlu)
            Find_Value_Type_H_TXT(i).Text = "Cr"
        End If


        Try
            Label3.Text = nUmBeR_FORMATE(Amt_.Sum(Function(m)
                                                      Return nUmBeR_FORMATE(m.Text)
                                                  End Function))
        Catch ex As Exception

        End Try

        If nUmBeR_FORMATE(Label3.Text) < 0 Then
            Label4.Text = "Cr"
            Label3.Text = N2_FORMATE(Val(Label3.Text) * -1)
        Else
            Label4.Text = "Dr"
            Label3.Text = N2_FORMATE(Val(Label3.Text))
        End If

    End Function
    Private Sub Amount_Type_U_TextChange(sender As Object, e As EventArgs)
        If sender.Text.Length = 2 Then
            Dim i1 As Integer = Find_Idx(sender)
            Dim i2 As Integer = Find_Idx2(sender)
            Head_Clculation(i1)
            Balance_Online(i1, i2)
            Balance_Offline(i1, i2)
        End If
    End Sub
    Private Sub Amount_Type_U_Keydown(sender As Object, e As KeyEventArgs)

        If e.KeyCode = Keys.Enter Then
            Dim i1 As Integer = Find_Idx(sender)
            Dim i2 As Integer = Find_Idx2(sender)

            If Find_bg_Under(i1).Controls.Count = i2 Then
                If Find_Payhead_TXT(i1, i2).Text <> Nothing Then
                    Add_Under(i1)
                End If
            End If


        End If

    End Sub
    Private Sub Phd_Keydown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Dim i1 As Integer = Find_Idx(sender)
            Dim i2 As Integer = Find_Idx2(sender)

            sender.Data_Link_ = phd_list.List_Grid.CurrentRow.Cells(2).Value.ToString

            If sender.Data_Link_ = Nothing Then
                Find_Amount_Under_TXT(i1, i2).Enabled = False
                Find_Amount_Under_TXT(i1, i2).Text = ""

                Find_Amount_Type_Under_TXT(i1, i2).Enabled = False
                Find_Amount_Type_Under_TXT(i1, i2).Text = ""

                Find_Balance_Head(i1, i2).Text = ""
                Find_Balance_Value(i1, i2).Text = ""
                Find_Balance_Unit(i1, i2).Text = ""

            Else
                Find_Amount_Under_TXT(i1, i2).Enabled = True
                Find_Amount_Type_Under_TXT(i1, i2).Enabled = True

                Find_Balance_Head(i1, i2).Text = "Cur. Bal. :"
                Find_Balance_Value(i1, i2).Text = ""
                Find_Balance_Unit(i1, i2).Text = ""

                Balance_Online(i1, i2)
                Balance_Offline(i1, i2)
            End If
        End If
    End Sub
    Public Function Balance_Offline(i1 As Integer, i2 As Integer)
        Dim provisnol As Decimal = Val(Find_Closing_bal_Value(i1, i2).Text)
        Dim typ As String = Find_Amount_Type_Under_TXT(i1, i2).Text
        Dim vl As Decimal = Val(Find_Amount_Under_TXT(i1, i2).Text)


        If typ = "Cr" Then
            Find_Balance_Value(i1, i2).Text = provisnol + vl
        ElseIf typ = "Dr" Then
            Find_Balance_Value(i1, i2).Text = provisnol - vl
        Else
            Find_Balance_Value(i1, i2).Text = provisnol
        End If

        If Val(Find_Balance_Value(i1, i2).Text) > 0 Then
            Find_Balance_Value(i1, i2).Text = N2_FORMATE(Find_Balance_Value(i1, i2).Text) & " Cr"
        ElseIf Val(Find_Balance_Value(i1, i2).Text) < 0 Then
            Find_Balance_Value(i1, i2).Text = N2_FORMATE(Val(Find_Balance_Value(i1, i2).Text) * -1) & " Dr"
        End If





    End Function
    Public Function Balance_Online(i1 As Integer, i2 As Integer)
        Dim vlu As Decimal = 0
        Dim cn As New SQLiteConnection

        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            Dim q As String = $"SELECT SUM(vlu) as Vlu, 
(Select ifnull(SUM(vc.Dr),0) - ifnull(SUM(vc.Cr),0) From TBL_VC_Payroll vc where vc.Employee = '{Find_Employee_TXT(i1).Data_Link_}' and vc.Payhead = '{Find_Payhead_TXT(i1, i2).Data_Link_}' and vc.[Date] <= '{CDate(Payroll_Vouchers_frm.Date_TXT.Text).AddDays(1).ToString(Lite_date_Format)}' and vc.Tra_ID <> '{Payroll_Vouchers_frm.Tra_ID}') as Payroll_
From (SELECT ifnull(atvc.Value,0) *
(Select ifnull(sd.Rate,0) From TBL_Payroll_SalaryDetails sd where sd.Under = 'Employee' and sd.Account = '{Find_Employee_TXT(i1).Data_Link_}' and sd.Payhead = phd.ID and sd.[Date] = (Select sd1.[Date] From TBL_Payroll_SalaryDetails sd1 where sd1.[Date] = (Select sd1.[Date] From TBL_Payroll_SalaryDetails sd1 where sd1.Account = '{Find_Employee_TXT(i1).Data_Link_}' and sd1.[Date] <= atvc.[Date] ORDER By sd1.[Date] DESC LIMIT 1))) as Vlu
From TBL_Attendance_VC atvc
LEFT JOIN TBL_PayHead phd on (phd.Leave_without_pay = atvc.Attendance_ID or phd.Production = atvc.Attendance_ID) and phd.ID = '{Find_Payhead_TXT(i1, i2).Data_Link_}' 

where atvc.Visible = 'Approval' and atvc.Employee = '{Find_Employee_TXT(i1).Data_Link_}' and atvc.[Date] <= '{CDate(Payroll_Vouchers_frm.Date_TXT.Text).AddDays(1).ToString(Lite_date_Format)}')"
            cmd = New SQLiteCommand(q, cn)
            'My.Computer.Clipboard.SetText(cmd.CommandText)
            Dim r As SQLiteDataReader = cmd.ExecuteReader
            While r.Read
                vlu = Val(r("Vlu").ToString) - Val(r("Payroll_").ToString)
            End While
        End If
        Find_Closing_bal_Value(i1, i2).Text = Val(vlu)
    End Function
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
        ElseIf e.KeyCode = Keys.Enter AndAlso e.Modifiers = Keys.Control Then
            Cell("Payroll Employee", "", "Alter_Close", sender.Data_Link_)
            Ledger_frm.close_focus_obj = sender
        ElseIf e.KeyCode = Keys.Enter AndAlso e.Modifiers = Keys.Shift Then
            Cell("Salary Details", "", "Employee wise", sender.Data_Link_)
            Payroll_Salary_details_frm.close_link_yn = True
            Payroll_Salary_details_frm.close_focus_obj = sender
            Payroll_Salary_details_frm.Salary_details_cc1.Find_Date_TXT(1).Focus()
            Exit Sub
        ElseIf e.KeyCode = Keys.Enter Then
            Dim i As Integer = Find_Idx(sender)


            If sender.Data_Link_ = Nothing Then
                Find_bg_Under(i).Enabled = False
                Find_bg_Under(i).Controls.Clear()
            Else
                Find_bg_Under(i).Enabled = True
            End If

            If Find_Employee_TXT(i).Data_Link_ <> Nothing Then
                If bg_panel.Controls.Count = i Then
                    Add_New(True)
                End If
                If Find_bg_Under(i).Controls.Count = 0 Then
                    Add_Under(i)
                End If
            End If
        End If

    End Sub
    Private Function Create_Employee(sender As TXT)
        Cell("Payroll Employee", "", "Create_Close", "")
        Payroll_Employee_frm.Name_TXT.Text = sender.Text
        Payroll_Employee_frm.close_focus_obj = sender
    End Function

    Dim emp_list As List_frm
    Private Function List_set_H(idx As Integer)
        Dim emp As TXT = Find_Employee_TXT(idx)

        emp_list = New List_frm
        List_Setup("List of Employee", Select_List.Right_Dock, Select_List_Format.Defolt, emp, emp_list, Employee_Source, 320, {"Salary Details|Shift + Enter"})
        emp_list.System_Data_integer = 1

    End Function
    Dim phd_list As List_frm
    Dim amt_type_list As List_frm
    Private Function List_set_U(i1 As Integer, i2 As Integer)
        Dim emp As TXT = Find_Payhead_TXT(i1, i2)
        phd_list = New List_frm
        List_Setup("List of Pay Head", Select_List.Right, Select_List_Format.Defolt, emp, phd_list, Phd_Source, 320, {"Create|Alt + C", "Alter|Ctrl + Enter"})

        Dim typ As TXT = Find_Amount_Type_Under_TXT(i1, i2)
        amt_type_list = New List_frm
        List_Setup("Cr/Dr", Select_List.Right, Select_List_Format.Singel, typ, amt_type_list, Cr_DR_Source, 80)


    End Function


    Public Function Fill_Data_Source(dtd As Date)
        Dim cn As New SQLiteConnection
        Dim r As SQLiteDataReader

        Dim dr As DataRow
        Dim dt As New DataTable



        dt.Columns.Add("Name")
        dt.Columns.Add("Under")
        dt.Columns.Add("ID")

        dt.Rows.Add("", "Create", "")
        dt.Rows.Add("End of List", "", "")

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


            dt = New DataTable
            dt.Columns.Add("Name")
            dt.Columns.Add("Under")
            dt.Columns.Add("ID")

            dt.Rows.Add("End of List", "", "")

            cmd = New SQLiteCommand($"Select *,(Select u.Name From TBL_Acc_Group u where u.ID = tt.Under) as Under_Name From TBL_PayHead tt where {Company_Visible_Filter}", cn)

            r = cmd.ExecuteReader
            While r.Read
                dr = dt.NewRow
                dr("ID") = r("ID")
                dr("Name") = r("Name")
                dr("Under") = r("Under_Name")
                dt.Rows.Add(dr)
            End While
            r.Close()
            Phd_Source.DataSource = dt

        End If



        dt = New DataTable
        dt.Columns.Add("Name")
        dt.Rows.Add("Cr")
        dt.Rows.Add("Dr")

        Cr_DR_Source.DataSource = dt


    End Function
    Public Function Find_Value_H_TXT(Index As Integer) As Label
        Try
            Return CType(Me.Controls.Find(("valuH_" & Index), True).First, Label)
        Catch ex As Exception

        End Try
    End Function

    Public Function Find_bg(Index As Integer) As Panel
        Try
            Return CType(Me.Controls.Find(("bg_" & Index), True).First, Panel)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_bg_Under(Index As Integer) As Panel
        Try
            Return CType(Me.Controls.Find(("bgunder_" & Index), True).First, Panel)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Total(Index As Integer) As Label
        Try
            Return CType(Me.Controls.Find(("Total_" & Index), True).First, Label)
        Catch ex As Exception

        End Try
    End Function


    Public Function Find_Value_Type_H_TXT(Index As Integer) As Label
        Try
            Return CType(Me.Controls.Find(("valutypeH_" & Index), True).First, Label)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Employee_TXT(Index As Integer) As TXT
        Try
            Return CType(Me.Controls.Find(("employee_" & Index), True).First, TXT)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Under_Panel(I As Integer, I2 As Integer) As Panel
        Try
            Return CType(Me.Controls.Find(($"underPanelU_{I}_{I2}"), True).First, Panel)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Payhead_TXT(I As Integer, I2 As Integer) As TXT
        Try
            Return CType(Me.Controls.Find(($"payhead_{I}_{I2}"), True).First, TXT)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Amount_Under_TXT(I As Integer, I2 As Integer) As TXT
        Try
            Return CType(Me.Controls.Find(($"amountU_{I}_{I2}"), True).First, TXT)
        Catch ex As Exception

        End Try
    End Function

    Public Function Find_Balance_Head(I As Integer, I2 As Integer) As Label
        Try
            Return CType(Me.Controls.Find(($"balhead_{I}_{I2}"), True).First, Label)
        Catch ex As Exception

        End Try
    End Function

    Public Function Find_Balance_Unit(I As Integer, I2 As Integer) As Label
        Try
            Return CType(Me.Controls.Find(($"balunit_{I}_{I2}"), True).First, Label)
        Catch ex As Exception

        End Try
    End Function


    Public Function Find_Closing_bal_Value(I As Integer, I2 As Integer) As Label
        Try
            Return CType(Me.Controls.Find(($"balclosing_{I}_{I2}"), True).First, Label)
        Catch ex As Exception

        End Try
    End Function

    Public Function Find_Balance_Value(I As Integer, I2 As Integer) As Label
        Try
            Return CType(Me.Controls.Find(($"balvlu_{I}_{I2}"), True).First, Label)
        Catch ex As Exception

        End Try
    End Function



    Public Function Find_Amount_Type_Under_TXT(I As Integer, I2 As Integer) As TXT
        Try
            Return CType(Me.Controls.Find(($"amounttypeU_{I}_{I2}"), True).First, TXT)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Idx(sender As Object) As Integer
        Return sender.Name.Split("_")(1)
    End Function
    Public Function Find_Idx2(sender As Object) As Integer
        Return sender.Name.Split("_")(2)
    End Function

    Private Sub bg_panel_U_Enter(sender As Object, e As EventArgs)
        Dim col As Color = Color.FromArgb(252, 227, 156)
        sender.BackColor = col
        Dim I1 As Integer = Find_Idx(sender)
        Dim I2 As Integer = Find_Idx2(sender)

        Find_Payhead_TXT(I1, I2).BackColor = col
        Find_Payhead_TXT(I1, I2).Back_color = col

        Find_Amount_Under_TXT(I1, I2).BackColor = col
        Find_Amount_Under_TXT(I1, I2).Back_color = col

        Find_Amount_Type_Under_TXT(I1, I2).BackColor = col
        Find_Amount_Type_Under_TXT(I1, I2).Back_color = col


    End Sub
    Private Sub bg_panel_U_Leave(sender As Object, e As EventArgs)
        Dim col As Color = bg_panel.BackColor
        sender.BackColor = col

        Dim I1 As Integer = Find_Idx(sender)
        Dim I2 As Integer = Find_Idx2(sender)

        Find_Payhead_TXT(I1, I2).BackColor = col
        Find_Payhead_TXT(I1, I2).Back_color = col

        Find_Amount_Under_TXT(I1, I2).BackColor = col
        Find_Amount_Under_TXT(I1, I2).Back_color = col

        Find_Amount_Type_Under_TXT(I1, I2).BackColor = col
        Find_Amount_Type_Under_TXT(I1, I2).Back_color = col

    End Sub

    Private Sub bg_panel_H_Enter(sender As Object, e As EventArgs)
        Dim col As Color = Color.FromArgb(252, 227, 156)
        sender.BackColor = col
        Dim idx As Integer = Find_Idx(sender)

        Find_Employee_TXT(idx).BackColor = col
        Find_Employee_TXT(idx).Back_color = col

        'Find_Value_H_TXT(idx).BackColor = col

    End Sub

    Private Sub bg_panel_H_Leave(sender As Object, e As EventArgs)
        Dim col As Color = bg_panel.BackColor
        sender.BackColor = col

        Dim idx As Integer = Find_Idx(sender)

        Find_Employee_TXT(idx).BackColor = col
        Find_Employee_TXT(idx).Back_color = col

        'Find_Value_H_TXT(idx).BackColor = col
    End Sub

    Private Sub payroll_controls_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        Fill_Data_Source(CDate(Payroll_Vouchers_frm.Date_TXT.Text))
    End Sub
End Class
