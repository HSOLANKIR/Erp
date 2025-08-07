Imports System.ComponentModel
Imports System.Data.SQLite
Imports Tools
Imports Tools.Grid
Public Class Payroll_Salary_details_frm
    Dim From_ID As String
    Dim Path_End As String
    Dim VC_Type_ As String
    Public VC_ID_ As String
    Dim Defolt_date As Date

    Public close_focus_obj As Object
    Public close_link_yn As Boolean = False

    Private Sub Payroll_Salary_details_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text

        VC_Type_ = Link_Valu(1)
        VC_ID_ = Link_Valu(2)

        BG_frm.HADE_TXT.Text = "Salary Details"
        BG_frm.TYP_TXT.Text = VC_Type_

        Button_Manage()
        Add_Hander_Remove_Handel(True)

        If VC_Type_ = "Employee wise" Then
            Label5.Text = Find_DT_Value(Database_File.cre, "TBL_Payroll_Employee", "Name", "ID = '" & VC_ID_ & "'")
            Label3.Text = Find_DT_Value(Database_File.cre, "TBL_Payroll_Employee", "Under", "ID = '" & VC_ID_ & "'")
            Label3.Text = Find_DT_Value(Database_File.cre, "TBL_Stock_Group", "Name", "ID = '" & Label3.Text & "'")
        Else
            Label5.Text = Find_DT_Value(Database_File.cre, "TBL_Stock_Group", "Name", "ID = '" & VC_ID_ & "'")
            Label3.Text = ""
        End If

        Salary_details_cc1.Fill_Source_data()


        Grid_setup()
        Display_All()


        Salary_details_cc1.Add_New()
        'Salary_details_cc1.Find_Date_TXT(1).Focus()

    End Sub

    Private Sub Payroll_Salary_details_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.TYP_TXT.Text = VC_Type_
        BG_frm.HADE_TXT.Text = "Salary Details"

        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text


        Button_Clear()
        Button_Manage()
    End Sub

    Private Function Grid_setup()
        Grid1.Colum_Manag("Type", Col_Formate.Text_, 1, ContentAlignment.MiddleRight, ContentAlignment.MiddleRight)
        Grid1.Colum_Manag("Effective From", Col_Formate.Date_null, 80, ContentAlignment.MiddleCenter, ContentAlignment.MiddleCenter)
        Grid1.Colum_Manag("Pay Head", Col_Formate.Text_, 0, ContentAlignment.MiddleCenter, ContentAlignment.MiddleLeft)
        Grid1.Colum_Manag("Rate", Col_Formate.Number_0, 100, ContentAlignment.MiddleCenter, ContentAlignment.MiddleRight)
        Grid1.Colum_Manag("Per", Col_Formate.DSP_, 80, ContentAlignment.MiddleCenter, ContentAlignment.MiddleLeft)
        Grid1.Colum_Manag("Pay Head Type", Col_Formate.DSP_, 0, ContentAlignment.MiddleCenter, ContentAlignment.MiddleLeft)
        Grid1.Colum_Manag("Calculation Type", Col_Formate.DSP_, 200, ContentAlignment.MiddleCenter, ContentAlignment.MiddleLeft)
        Grid1.Colum_Manag("Date of deduction", Col_Formate.Number_0, 40, ContentAlignment.MiddleCenter, ContentAlignment.MiddleLeft)
        Grid1.Colum_Manag("installment period", Col_Formate.Number_0, 40, ContentAlignment.MiddleCenter, ContentAlignment.MiddleLeft)
        Grid1.Columns(0).Visible = False

        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand("select * From TBL_Attendance_VC VC
where VC.Account = '" & VC_ID_ & "' and Vc.Visible = 'Approval'
ORDER BY [Date] DESC LIMIT 1;", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                Try
                    Salary_details_cc1.Vc_Last_Date = CDate(r("Date"))
                Catch ex As Exception

                End Try
            End While
        End If

        BackgroundWorker1.RunWorkerAsync()
        Grid1.Focus()
    End Function
    Dim vc_last_date As Date
    Private Function Button_Manage()
        Button_Clear()
        BG_frm.B_1.Text = "|&E : Exit"
        BG_frm.B_2.Text = "|&S : Save"
    End Function
    Private Function Add_Hander_Remove_Handel(Ans As Boolean)
        If Ans = True Then
            AddHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            AddHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
        Else
            RemoveHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            RemoveHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
        End If
    End Function
    Private Sub B_1_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Me.Dispose()
        End If
    End Sub
    Private Sub B_2_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Save_data()
        End If
    End Sub
    Private Function Insurt_Audit() As Boolean
        If VC_Type_ = "Employee wise" Then
            If Val(VC_ID_) = 0 Then
                Return True
            End If

            If Audit_Save("TBL_Payroll_SalaryDetails", "Account", VC_ID_) = True Then
                Return True
            End If
        Else
            Return True
        End If
    End Function

    Private Function Save_Data_()
        If Save_requid() = True Then
            If Insurt_Audit() = True Then
                If Insurt_data() = True Then
                    If Delete_Report_Install() = True Then
                        Me.Dispose()
                        NOT_("Successfully Save", NOT_Type.Success)
                    End If
                End If
            End If
        End If
    End Function
    Private Function All_Filters_Set()
        If Grid1.CurrentRow.Cells(2).Selected = True Then
            Group_1_Payhead()
        End If
    End Function
    Private Function Group_1_Payhead()
        If Grid1.CurrentRow.Cells(2).Selected = True And List_frm.Visible = False And Grid1.CurrentRow.Cells(0).Value = "TXT" Then

        End If
        NOT_Clear()
    End Function

    Private Sub Grid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid1.CellContentClick

    End Sub

    Private Sub Grid1_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grid1.CellEnter
        List_frm.Dispose()
        Mini_List_frm.Dispose()
        All_Filters_Set()
        Select_Currant(Grid1.CurrentCell.Value)
    End Sub

    Private Sub Grid1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Grid1.KeyPress
        All_Filters_Set()
    End Sub

    Private Sub Grid1_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid1.KeyDown
        If Me.Visible = True Then
            If Grid1.CurrentRow.Cells(1).Selected = True Then
                Try
                    Dim Curr_dT As Date = CDate(Grid1.CurrentRow.Cells(1).Value)
                    Dim deff As Integer = DateDiff(DateInterval.Day, Curr_dT, Defolt_date)

                    If deff > 0 And Grid1.CurrentRow.Index <> 0 And Grid1.CurrentRow.Cells(1).Value <> Nothing And CDate(vc_last_date) >= CDate(Grid1.CurrentRow.Cells(1).Value) Then
                        Grid1.CurrentCell = Grid1.CurrentRow.Cells(1)
                        e.Handled = True
                        Exit Sub
                    End If
                    If Grid1.CurrentRow.Cells(1).Value <> Nothing Then
                        Defolt_date = CDate(Grid1.CurrentRow.Cells(1).Value).ToString("dd-MM-yyyy")
                    End If
                Catch ex As Exception
                    Grid1.CurrentCell = Grid1.CurrentRow.Cells(1)
                End Try
            ElseIf Grid1.CurrentRow.Cells(2).Selected = True Then
                If e.KeyCode = Keys.C AndAlso e.Modifiers = Keys.Alt Then
                    Dim frm As New Ledger_frm
                    sHortcut_open_frm(frm, sender, "", "Create_Close", "")
                    NOT_("Create new", NOT_Type.Info)
                ElseIf e.KeyCode = Keys.Enter AndAlso e.Modifiers = Keys.Control Then
                    Dim frm As New Ledger_frm
                    sHortcut_open_frm(frm, sender, "", "Alter_Close", List_frm.List_Grid.CurrentRow.Cells(0).Value.ToString)
                    NOT_("Alter", NOT_Type.Info)
                ElseIf e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Enter Then
                    Dim Production As String = List_frm.List_Grid.CurrentRow.Cells(9).Value

                    Grid1.CurrentRow.Cells(6).Value = List_frm.List_Grid.CurrentRow.Cells(6).Value
                    Grid1.CurrentRow.Cells(5).Value = List_frm.List_Grid.CurrentRow.Cells(5).Value
                    Grid1.CurrentRow.Cells(4).Value = List_frm.List_Grid.CurrentRow.Cells(8).Value
                    Grid1.CurrentRow.Cells(2).Value = List_frm.List_Grid.CurrentRow.Cells(1).Value

                    If Grid1.CurrentRow.Cells(6).Value = "On Production" Then
                        Dim Pro As String = Find_DT_Value(Database_File.cre, "TBL_Payroll_Att_Production_Type", "Unit", "ID = '" & Production & "'")
                        Grid1.CurrentRow.Cells(4).Value = Find_DT_Unit_Conves(Pro)
                    End If
                    If Grid1.CurrentRow.Cells(2).Value = "End of List" Then
                        Try
                            If Grid1.Rows(Grid1.CurrentRow.Index + 1).Cells(1).Value <> Nothing Then
                                Grid1.CurrentCell = Grid1.Rows(Grid1.CurrentRow.Index + 1).Cells(2)
                                Grid1.Rows.RemoveAt(Grid1.CurrentRow.Index - 1)
                                Exit Sub
                            End If
                        Catch ex As Exception

                        End Try

                        Grid1.CurrentRow.Cells(2).Value = ""
                        Grid1.CurrentCell = Grid1.CurrentRow.Cells(1)

                    End If
                End If
            ElseIf Grid1.CurrentRow.Cells(6).Selected = True Then
                If e.KeyCode = Keys.C AndAlso e.Modifiers = Keys.Alt Then
                    Dim frm As New Ledger_frm
                    sHortcut_open_frm(frm, sender, "", "Create_Close", "")
                    NOT_("Create new", NOT_Type.Info)
                ElseIf e.KeyCode = Keys.Enter AndAlso e.Modifiers = Keys.Control Then
                    Dim frm As New Ledger_frm
                    sHortcut_open_frm(frm, sender, "", "Alter_Close", List_frm.List_Grid.CurrentRow.Cells(0).Value.ToString)
                    NOT_("Alter", NOT_Type.Info)
                ElseIf e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Enter Then
                    Try
                        If Grid1.Rows(Grid1.CurrentRow.Index + 1).Cells(1).Value <> Nothing Then
                            Dim newrow As DataGridViewRow = New DataGridViewRow()
                            Grid1.Rows.Insert(Grid1.CurrentRow.Index + 1, newrow)
                            Grid1.CurrentCell = Grid1.Rows(Grid1.CurrentRow.Index + 1).Cells(1)
                            Grid1.Rows(Grid1.CurrentRow.Index + 1).Cells(0).Value = "TXT"
                        End If
                    Catch ex As Exception

                    End Try
                End If
            End If
            'All_Filters_Set()
        End If
    End Sub
    Public Function Save_data()
        Dim obj As TXT = Salary_details_cc1.Find_Date_TXT(1)

        Dim result As DialogResult = Msg_Save_YN(obj, "Salary Details")

        If result = DialogResult.Yes Then
            Save_Data_()
        ElseIf result = DialogResult.No Then
            obj.Focus()
        ElseIf result = DialogResult.Cancel Then
            SendKeys.Send("{BACKSPACE}")
        End If
    End Function
    Private Sub Grid1_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles Grid1.CellLeave
        All_Filters_Set()
    End Sub

    Private Sub Grid1_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles Grid1.RowsAdded
        SendKeys.Send("{Right}")
        If Grid1.Rows.Count > 1 Then
            If Grid1.Rows(Grid1.CurrentRow.Index + 1).Cells(0).Value = Nothing Then
                Grid1.Rows(Grid1.CurrentRow.Index + 1).Cells(0).Value = "TXT"
                Grid1.Rows(Grid1.CurrentRow.Index + 1).Cells(2).Value = " "
            End If
        End If
    End Sub
    Private Function Save_requid() As Boolean
        Dim Dt As Date
        For Each ro As DataGridViewRow In Grid1.Rows
            If ro.Cells(1).Value <> Nothing Then
                Dim deff As Integer = DateDiff(DateInterval.Day, CDate(ro.Cells(1).Value), Dt)
                If deff > 0 And Grid1.CurrentRow.Index <> 0 And Grid1.CurrentRow.Cells(1).Value <> Nothing Then
                    Grid1.CurrentCell = ro.Cells(1)
                    NOT_("You have entered an outdated date", NOT_Type.Erro)
                    Return False
                End If
                Dt = CDate(ro.Cells(1).Value)
            End If
        Next
        Return True
    End Function
    Private Function Insurt_data() As Boolean
        Dim Und As String = ""
        If VC_Type_ = "Employee wise" Then
            Und = "Employee"
        ElseIf VC_Type_ = "Group wise" Then
            Und = "Group"
        End If

        If open_MSSQL(Database_File.cre) Then

            qury = $"Delete From TBL_Payroll_SalaryDetails where Account = '{VC_ID_}' and Under = '{Und}'"
            cmd = New SQLiteCommand(qury, con)
            cmd.ExecuteNonQuery()
        End If

        If open_MSSQL(Database_File.cre) Then
            qury = "INSERT INTO TBL_Payroll_SalaryDetails (Account,Under,Date,Payhead,Rate,Date_of_deduction,installment_period,Company,Visible,[User],Date_install,PC) VALUES (@Account,@Under,@Date,@Payhead,@Rate,@Date_of_deduction,@installment_period,@Company,@Visible,@User,@Install_,@PC)"

            Dim U_ As New Queue(Of Panel)()

            For Each P As Panel In Salary_details_cc1.bg_panel.Controls
                For Each U As Panel In Salary_details_cc1.Find_bg_Panel(Salary_details_cc1.Find_Idx(P)).Controls.OfType(Of Panel)()
                    If U.Name <> "Datepanel_" & Salary_details_cc1.Find_Idx(U) Then
                        U_.Enqueue(U)
                    End If
                Next
            Next


            For Each U As Panel In U_.Reverse
                Dim idx As Integer = Salary_details_cc1.Find_Idx(U)
                Dim dt_ As Object = Salary_details_cc1.Find_Date_TXT(idx)


                Dim idx2 As Integer = Salary_details_cc1.Find_Idx_idx(U)
                Dim phd_ As Object = Salary_details_cc1.Find_pay_ID(idx, idx2)
                Dim rate_ As Object = Salary_details_cc1.Find_rate_txt(idx, idx2)

                If Val(phd_.Text) <> 0 Then
                    cmd = New SQLiteCommand(qury, con)
                    With cmd.Parameters
                        .AddWithValue("@Account", VC_ID_)
                        .AddWithValue("@Under", Und)
                        .AddWithValue("@Date", CDate(dt_.Text))
                        .AddWithValue("@Payhead", phd_.Text)
                        .AddWithValue("@Rate", Val(rate_.Text))
                        .AddWithValue("@Date_of_deduction", Val(0))
                        .AddWithValue("@installment_period", Val(0))
                        .AddWithValue("@Company", Company_ID_str)
                        .AddWithValue("@User", LOGIN_ID)
                        .AddWithValue("@PC", PC_ID.Trim)
                        .AddWithValue("@Install_", CDate(DateTime.Now))
                        .AddWithValue("@Visible", "Approval")
                        cmd.ExecuteNonQuery()
                    End With
                End If
            Next
        End If
        Return True
    End Function
    Private Function Delete_Report_Install() As Boolean
        If open_MSSQL(Database_File.cre) Then
            qury = "INSERT INTO DEL_Payroll_SalaryDetails (Account,Under,Date,Payhead,LoanAcc,Rate,Date_of_deduction,installment_period,Company,Visible,[User],Date_install,PC) VALUES (@Account,@Under,@Date,@Payhead,@LoanAcc,@Rate,@Date_of_deduction,@installment_period,@Company,@Visible,@User,@Install_,@PC)"
            Dim dt As Date
            For Each ro As DataGridViewRow In Grid1.Rows
                If Chack_Duplicate(Database_File.cre, "TBL_Payhead", "Name", "Name  = '" & ro.Cells(2).Value & "'") = True Then
                    cmd = New SQLiteCommand(qury, con)
                    If ro.Cells(1).Value <> Nothing Then
                        dt = ro.Cells(1).Value
                    End If
                    With cmd.Parameters
                        .AddWithValue("@Account", VC_ID_)
                        .AddWithValue("@Under", "")
                        .AddWithValue("@Date", CDate(dt))
                        .AddWithValue("@Payhead", Find_DT_Value(Database_File.cre, "TBL_Payhead", "ID", "Name  = '" & ro.Cells(2).Value & "'"))
                        .AddWithValue("@Rate", ro.Cells(3).Value)
                        .AddWithValue("@Date_of_deduction", Val(ro.Cells(7).Value))
                        .AddWithValue("@installment_period", Val(ro.Cells(8).Value))
                        .AddWithValue("@Company", Company_ID_str)
                        .AddWithValue("@User", LOGIN_ID)
                        .AddWithValue("@PC", PC_ID.Trim)
                        .AddWithValue("@Install_", CDate(DateTime.Now))
                        .AddWithValue("@Visible", "Approval")
                        cmd.ExecuteNonQuery()
                    End With
                End If
            Next
        End If
        Return True
    End Function
    Private Function Display_All()
        Grid1.Rows.Clear()

        Dim Last_data As Date = Company_Book_frm


        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select vc.[Date] as Date From TBL_Attendance_VC vc
where vc.Voucher_Type = 'Attendance' and vc.Visible = 'Approval' and vc.Employee = '{VC_ID_}'
ORDER by vc.[Date] DESC LIMIT 1;", cn)

            Dim r As SQLiteDataReader = cmd.ExecuteReader
            My.Computer.Clipboard.SetText(cmd.CommandText)
            While r.Read
                Last_data = CDate(r("Date").ToString)
            End While
        End If


        Dim dt As Date
        Dim dt1 As Date
        Salary_details_cc1.bg_panel.Controls.Clear()

        If open_MSSQL(Database_File.cre) Then
            Dim Filter_ As String = ""


            If VC_Type_ = "Employee wise" Then
                Filter_ = "Employee"
            Else
                Filter_ = "Group"
            End If


            cmd = New SQLiteCommand($"Select sd.[Date],sd.Payhead,sd.Rate,PD.Payhead_Type,PD.Cal_Type,PD.Cal,
(Select [Unit] From TBL_Payroll_Att_Production_Type ff where ff.ID = PD.Production) as Unit_Name

From TBL_Payroll_SalaryDetails sd
LEFT JOIN TBL_Payhead PD ON PD.ID = sd.Payhead

where sd.Account = '{VC_ID_}' and (sd.Under = '{Filter_}')", con)


            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                Dim Unit As String = ""
                If r("Cal_Type").ToString = "On Production" Then
                    Unit = Find_DT_Unit_Conves(r("Unit_Name"))
                Else
                    Unit = r("Cal")
                End If

                Salary_details_cc1.Add_data(r("Date").ToString, r("Payhead").ToString, r("Rate").ToString, Unit.ToString, r("Payhead_Type").ToString, r("cal_type").ToString, True)


                If Last_data >= CDate(r("Date").ToString) Then
                    'Salary_details_cc1.Find_bg_Panel(Salary_details_cc1.bg_panel.Controls.Count - 0).Enabled = False
                End If

            End While
        End If
        'Salary_details_cc1.Add_New()

        Grid1.Rows.Add("TXT")
        Grid1.CurrentCell = Grid1.Rows(Grid1.Rows.Count - 1).Cells(1)
    End Function

    Private Sub Payroll_Salary_details_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End
        Add_Hander_Remove_Handel(False)

        If close_link_yn = True Then
            close_focus_obj.Focus()
        Else
            Frm_foCus()
        End If
    End Sub

    Private Sub Payroll_Salary_details_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If Msg_Exit_YN("Salary Details " & VC_Type_) = DialogResult.Yes Then
                Me.Dispose()
                Frm_foCus()
            End If
        End If
    End Sub
    Private Function Select_Currant(TXT As String)
        Try
            If List_frm.Visible = True And Grid1.Visible = True Then
                For i As Integer = 0 To List_frm.List_Grid.Rows.Count - 1
                    Dim ro As DataGridViewRow = List_frm.List_Grid.Rows(i)
                    If ro.Cells(1).Value = TXT Then
                        List_frm.List_Grid.CurrentCell = List_frm.List_Grid.Rows(i).Cells(1)
                        Exit For
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Function

    Private Sub Salary_details_cc1_Load(sender As Object, e As EventArgs) Handles Salary_details_cc1.Load

    End Sub

    Private Sub Payroll_Salary_details_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
    End Sub
End Class