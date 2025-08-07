Imports System.Data.SQLite


Public Class Payroll_Auto_Fill_Dialoag
    Dim From_ID As String
    Dim Path_End As String
    Dim VC_Type_ As String

    Public Filter_ID As String
    Private Sub Payroll_Auto_Fill_Dialoag_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text
        BG_frm.HADE_TXT.Text = "Payroll Auto Fill"
        List_set()
        VC_Type_ = Link_Valu(0)
        obj_center(Attendance_Panel, Me)
        obj_center(Payroll_Panel, Me)

        Button_Manage()

        Type_TXT.Focus()

        If VC_Type_ = "Attendance" Then
            Attendance_Panel.Visible = True
            Payroll_Panel.Visible = False
            Type_TXT.Focus()
        ElseIf VC_Type_ = "Payroll" Then
            Payroll_Panel.Visible = True
            Attendance_Panel.Visible = False
            frm_date.Focus()
        End If
    End Sub
    Dim type_list As List_frm
    Dim acc_list As List_frm
    Dim att_list As List_frm
    Dim emp_list As List_frm
    Public Function List_set()
        type_list = New List_frm
        List_Setup("Type of Filter", Select_List.Right, Select_List_Format.Singel, Type_TXT, type_list, Type_Source, 200)


        acc_list = New List_frm
        List_Setup("List of Employee", Select_List.Right_Dock, Select_List_Format.Singel, Filter_TXT, acc_list, Filter_Source, 320)


        att_list = New List_frm
        List_Setup("List of Attendance/Production Type", Select_List.Right_Dock, Select_List_Format.Defolt, Atendance_Select, att_list, Attendance_Source, 320)

        emp_list = New List_frm
        List_Setup("Employee/Group", Select_List.Right_Dock, Select_List_Format.Defolt, Txt2, emp_list, Employee_Group_Source, 320)


    End Function
    Public Function Fill_Data()
        Dim dr As DataRow
        Dim dt As New DataTable
        dt.Columns.Add("Name")

        dt.Rows.Add("All Employee")
        dt.Rows.Add("Employee Group wise")
        dt.Rows.Add("Employee wise")
        Type_Source.DataSource = dt

        Fill_Data_Filter()

        dt = New DataTable
        dt.Columns.Add("Name")
        dt.Columns.Add("Unit")
        dt.Columns.Add("ID")
        dt.Columns.Add("Decimal")

        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select *,
(Select u.Symbol From TBL_Inventory_Unit u where u.ID = tt.[Unit]) as Unit_Name,
(Select u.Decimal From TBL_Inventory_Unit u where u.ID = tt.[Unit]) as Decimal_
From TBL_Payroll_Att_Production_Type tt where {Company_Visible_Filter()}", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                dr = dt.NewRow
                dr("ID") = r("ID")
                dr("Name") = r("Name").ToString
                dr("Decimal") = Val(r("Decimal_").ToString)
                If r("Attendance_Type") = "Production" Then
                    dr("Unit") = r("Unit_Name").ToString
                Else
                    dr("Unit") = "Day"
                End If
                dt.Rows.Add(dr)
            End While
            Attendance_Source.DataSource = dt


            dt = New DataTable
            dt.Columns.Add("Name")
            dt.Columns.Add("Type")
            dt.Columns.Add("ID")

            dt.Rows.Add("All Employee", "", "")

            cmd = New SQLiteCommand("
Select id,Name,'Group' as Type From TBL_Stock_Group WHERE Visible = 'Approval' and Head = 'Payroll'
UNION ALL
Select id,Name,'Employee' as Type From TBL_Payroll_Employee WHERE Visible = 'Approval'", cn)

            r = cmd.ExecuteReader
            While r.Read
                dr = dt.NewRow
                dr("ID") = r("ID")
                dr("Name") = r("Name")
                dr("Type") = r("Type")
                dt.Rows.Add(dr)
            End While
            r.Close()

            Employee_Group_Source.DataSource = dt
        End If

    End Function
    Private Function Button_Manage()
        Button_Clear()

    End Function

    Private Function Fill_Data_Filter()
        Dim dr As DataRow
        Dim dt As New DataTable

        dt.Columns.Add("Name")
        dt.Columns.Add("ID")

        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            If Type_TXT.Text = "Employee Group wise" Then
                acc_list.List_Head_TXT.Text = "List of Payroll Group"
                cmd = New SQLiteCommand($"Select g.ID,g.Name From TBL_Stock_Group g where g.Head = 'Payroll' and {Company_Visible_Filter()}", cn)
            ElseIf Type_TXT.Text = "Employee wise" Then
                acc_list.List_Head_TXT.Text = "List of Employee"
                cmd = New SQLiteCommand($"Select em.ID,em.Name From TBL_Payroll_Employee em where {Company_Visible_Filter()}", cn)
            Else
                'acc_list.List_Head_TXT.Text = "List of Employee"
                cmd = New SQLiteCommand($"Select '' as ID,'' as Name", cn)
            End If
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                dr = dt.NewRow
                dr("ID") = r("ID")
                dr("Name") = r("Name")
                dt.Rows.Add(dr)
            End While
            r.Close()
            Filter_Source.DataSource = dt
        End If
    End Function

    Private Sub Payroll_Auto_Fill_Dialoag_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub
    Private Sub Payroll_Auto_Fill_Dialoag_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End
        Frm_foCus()
    End Sub
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Attendance_Panel.Paint
        obj_center(Attendance_Panel, Me)
    End Sub

    Private Sub Type_TXT_TextChanged(sender As Object, e As EventArgs) Handles Type_TXT.TextChanged
        If Type_TXT.Text = "All Employee" Then
            Label3.Visible = False
            Label5.Visible = False
            Filter_TXT.Visible = False
        Else
            Label3.Visible = True
            Label5.Visible = True
            Filter_TXT.Visible = True

            'Fill_Data_Filter()
        End If
    End Sub

    Private Sub Type_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles Type_TXT.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Type_TXT.Text = "All Employee" Then
                Label3.Visible = False
                Label5.Visible = False
                Filter_TXT.Visible = False
            Else
                Label3.Visible = True
                Label5.Visible = True
                Filter_TXT.Visible = True

                Fill_Data_Filter()
            End If
        End If
    End Sub

    Private Sub Filter_TXT_TextChanged(sender As Object, e As EventArgs) Handles Filter_TXT.TextChanged

    End Sub

    Private Sub Filter_TXT_Enter(sender As Object, e As EventArgs) Handles Filter_TXT.Enter
        If Type_TXT.Text = "All Employee" Then
            Label3.Visible = False
            Label5.Visible = False
            Filter_TXT.Visible = False
        Else
            Label3.Visible = True
            Label5.Visible = True
            Filter_TXT.Visible = True

            Fill_Data_Filter()
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Payroll_Vouchers_frm.Attendance_Auto_Fill()
    End Sub

    Private Sub Filter_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles Filter_TXT.KeyDown
        If e.KeyCode = Keys.Enter Then
            Filter_ID = acc_list.List_Grid.CurrentRow.Cells(1).Value
        End If
    End Sub

    Private Sub Atendance_Select_TextChanged(sender As Object, e As EventArgs) Handles Atendance_Select.TextChanged

    End Sub

    Private Sub Atendance_Select_KeyDown(sender As Object, e As KeyEventArgs) Handles Atendance_Select.KeyDown
        If e.KeyCode = Keys.Enter Then
            Atendance_Select.Data_Link_ = att_list.List_Grid.CurrentRow.Cells(2).Value
            vlu_TXT.Decimal_ = Val(att_list.List_Grid.CurrentRow.Cells(3).Value)
        End If
    End Sub

    Private Sub Payroll_Panel_Paint(sender As Object, e As PaintEventArgs) Handles Payroll_Panel.Paint
        obj_center(Payroll_Panel, Me)
    End Sub

    Private Sub Txt4_TextChanged(sender As Object, e As EventArgs) Handles frm_date.TextChanged

    End Sub

    Private Sub Txt4_LostFocus(sender As Object, e As EventArgs) Handles frm_date.LostFocus
        If Date_Brack(frm_date.Text) = True Then
            frm_date.Text = CDate(Date_Formate(frm_date.Text)).ToString(Date_Format_fech)
        Else
            If frm_date.Text <> "" Then
                frm_date.Text = ""
                sender.focus()
            End If
        End If
    End Sub
    Private Sub Txt3_LostFocus(sender As Object, e As EventArgs) Handles To_date.LostFocus
        If Date_Brack(To_date.Text) = True Then
            To_date.Text = CDate(Date_Formate(To_date.Text)).ToString(Date_Format_fech)
        Else
            If To_date.Text <> "" Then
                To_date.Text = ""
                sender.focus()
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Payroll_Vouchers_frm.Payroll_Auto_Fill(Payroll_Type, Payroll_ID)
    End Sub

    Private Sub Button2_KeyDown(sender As Object, e As KeyEventArgs) Handles Button2.KeyDown
        If e.KeyCode = Keys.Back Then
            SendKeys.Send("+{TAB}")
        End If
        If e.KeyCode = Keys.Enter Then
            sender.PerformClick()
        End If
    End Sub

    Private Sub Button1_KeyDown(sender As Object, e As KeyEventArgs) Handles Button1.KeyDown
        If e.KeyCode = Keys.Back Then
            SendKeys.Send("+{TAB}")
        End If
        If e.KeyCode = Keys.Enter Then
            sender.PerformClick()
        End If
    End Sub

    Private Sub Txt2_TextChanged(sender As Object, e As EventArgs) Handles Txt2.TextChanged

    End Sub

    Private Payroll_Type As String = ""
    Private Payroll_ID As String = ""
    Private Sub Txt2_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt2.KeyDown
        If e.KeyCode = Keys.Enter Then
            Payroll_Type = emp_list.List_Grid.CurrentRow.Cells(1).Value
            Payroll_ID = emp_list.List_Grid.CurrentRow.Cells(2).Value
        End If
    End Sub

    Private Sub Payroll_Auto_Fill_Dialoag_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
    End Sub
End Class