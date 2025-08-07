Imports System.Data.SqlClient
Imports System.Data.SQLite
Imports System.IO
Imports Tools
Imports Tools.Grid

Public Class Payroll_Payhead_frm
    Dim From_ID As String
    Dim Under_ As String
    Dim Attendance_Type_ As String
    Dim Production_ As String

    Dim VC_Type_ As String
    Dim VC_ID_ As String
    Dim Path_End As String
    Public close_focus_obj As TXT
    Public close_link_yn As Boolean = False
    Private Sub Payroll_Payhead_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID
        Path_End = BG_frm.BG_Path_TXT.Text

        VC_Type_ = Link_Valu(1)
        VC_ID_ = Link_Valu(2)

        BG_frm.HADE_TXT.Text = "Payroll Pay Head"
        BG_frm.TYP_TXT.Text = VC_Type_


        Fill_data_source()
        List_set()


        If VC_Type_ = "Display" Or VC_Type_ = "Display_Close" Then
            Me.Enabled = False
            Display_Fill_All()
        ElseIf VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close" Then
            Me.Enabled = True
            Display_Fill_All()
        ElseIf VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
        End If
        'BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text


        Total_Opning_balance()
        Button_Manage()
        Add_Hander_Remove_Handel(True)
        Name_TXT.Focus()
    End Sub
    Dim type_payhead_list As List_frm
    Dim Under_list As List_frm
    Dim Cal_Type_List As List_frm
    Dim Attendance_type_list As List_frm
    Dim Cal_list As List_frm
    Dim Production_List As List_frm
    Private Function List_set()
        type_payhead_list = New List_frm
        List_Setup("List of Pay Head Type", Select_List.Right, Select_List_Format.Singel, P_Type_TXT, type_payhead_list, P_Type_Source, 320)

        Under_list = New List_frm
        List_Setup("List of Pay Head Type", Select_List.Right_Dock, Select_List_Format.Defolt, Under_TXT, Under_list, Under_Source, 300)

        Cal_Type_List = New List_frm
        List_Setup("Type of Calculation", Select_List.Right, Select_List_Format.Singel, Cal_Type_TXT, Cal_Type_List, Cal_Type_Source, 300)

        Attendance_type_list = New List_frm
        List_Setup("List of Attendance Types", Select_List.Right, Select_List_Format.Singel, Attendance_type_TXT, Attendance_type_list, Attendance_type_source, 300)

        Cal_list = New List_frm
        List_Setup("Type of Calculation", Select_List.Right, Select_List_Format.Singel, cal_TXT, Cal_list, Cal_Source, 150)

        Production_List = New List_frm
        List_Setup("List of Production Type", Select_List.Right, Select_List_Format.Defolt, Production_TXT, Production_List, Production_Source, 300)



    End Function
    Private Function Fill_data_Under_Group()
        Dim q As String = ""
        Dim cn As New SQLiteConnection

        With type_payhead_list.List_Grid
            If .CurrentRow.Cells(0).Value = "Not Applicable" Then
                q = " and (ID = '3')"
            ElseIf .CurrentRow.Cells(0).Value = "Deductions From Employees" Then
                q = " and (ID = '3' or ID = '6' or ID = '12' or ID = '13' or ID = '14' or ID = '15')"

            ElseIf .CurrentRow.Cells(0).Value = "Earnings for Employees" Then
                q = " and (ID = '12' or ID = '13')"

            ElseIf .CurrentRow.Cells(0).Value = "Loans and Advances" Then
                q = " and (ID = '25')"
            ElseIf .CurrentRow.Cells(0).Value = "Employees' Statutory Deductions" Then
                q = " and (ID = '3' or ID = '20')"
            End If
        End With



        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            Dim dt As New DataTable
            dt.Columns.Add("Name")
            dt.Columns.Add("UserGroup")
            dt.Columns.Add("ID")


            cmd = New SQLiteCommand($"Select * From TBL_Acc_Group where {Company_Visible_Filter()} {q}", cn)
            Dim r As SQLiteDataReader
            Dim dr As DataRow
            r = cmd.ExecuteReader
            While r.Read
                dr = dt.NewRow
                dr("ID") = r("ID")
                dr("Name") = r("Name")
                If r("UserGroup") <> "Primary" Then
                    dr("UserGroup") = Find_DT_Value(Database_File.cre, "TBL_Acc_Group", "Name", "(ID = '" & r("UserGroup") & "')")
                Else
                    dr("UserGroup") = "Primary"
                End If
                dt.Rows.Add(dr)
            End While
            r.Close()
            Under_Source.DataSource = dt
        End If
    End Function
    Private Function Fill_data_Attendance_Type()
        Dim q As String = ""
        Dim cn As New SQLiteConnection

        With type_payhead_list.List_Grid
            If .CurrentRow.Cells(0).Value = "Not Applicable" Then

            ElseIf .CurrentRow.Cells(0).Value = "Deductions From Employees" Then
                q = " and (Attendance_Type = 'Leave without Pay')"

            ElseIf .CurrentRow.Cells(0).Value = "Earnings for Employees" Then
                q = " and (Attendance_Type = 'Attendance / Leave with Pay')"

            ElseIf .CurrentRow.Cells(0).Value = "Loans and Advances" Then
                q = " and (Attendance_Type = 'Attendance / Leave with Pay')"
            End If
        End With



        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            Dim dt As New DataTable
            dt.Columns.Add("Name")
            dt.Columns.Add("Alias")
            dt.Columns.Add("ID")


            cmd = New SQLiteCommand($"Select * From TBL_Payroll_Att_Production_Type where {Company_Visible_Filter()} {q}", cn)

            Dim r As SQLiteDataReader
            Dim dr As DataRow

            r = cmd.ExecuteReader
            While r.Read
                dr = dt.NewRow

                dr("ID") = r("ID")
                dr("Name") = r("Name")
                dr("Alias") = r("alias").ToString

                dt.Rows.Add(dr)
            End While
            Attendance_type_source.DataSource = dt
        End If
    End Function

    Private Function Fill_data_source()
        Dim dt As New DataTable
        dt.Columns.Add("Name")
        dt.Rows.Add("Deductions From Employees")
        dt.Rows.Add("Earnings for Employees")
        dt.Rows.Add("Loans And Advances")

        P_Type_Source.DataSource = dt
        '////////////////
        dt = New DataTable
        dt.Columns.Add("Name")
        dt.Rows.Add("As User Defined Value")
        dt.Rows.Add("On Attendance")
        dt.Rows.Add("On Production")
        dt.Rows.Add("Flat Rate")

        Cal_Type_Source.DataSource = dt



        dt = New DataTable
        dt.Columns.Add("Name")
        dt.Columns.Add("UserGroup")
        dt.Columns.Add("ID")

        dt.Rows.Add("")

        Under_Source.DataSource = dt


        dt = New DataTable
        dt.Columns.Add("Name")
        dt.Columns.Add("Alias")
        dt.Columns.Add("ID")

        dt.Rows.Add("")

        Attendance_type_source.DataSource = dt


        Dim cn As New SQLiteConnection

        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            Dim r As SQLiteDataReader
            Dim dr As DataRow

            dt = New DataTable
            dt.Columns.Add("Name")
            dt.Columns.Add("Alias")
            dt.Columns.Add("ID")
            dt.Columns.Add("Attendance_Type")
            dt.Columns.Add("Unit")


            cmd = New SQLiteCommand($"Select * From TBL_Payroll_Att_Production_Type where Attendance_Type <> 'Production' and {Company_Visible_Filter()}", cn)
            r = cmd.ExecuteReader
            While r.Read
                dr = dt.NewRow

                dr("ID") = r("ID")
                dr("Name") = r("Name")
                dr("Alias") = r("alias").ToString
                dr("Attendance_Type") = r("Attendance_Type")

                If r("Attendance_Type") = "Production" Then
                    dr("Unit") = Find_DT_Unit_Conves(r("Unit"))
                Else
                    dr("Unit") = "Day"
                End If

                dt.Rows.Add(dr)
            End While
            Attendance_type_source.DataSource = dt




            dt = New DataTable
            dt.Columns.Add("Name")
            dt.Columns.Add("Alias")
            dt.Columns.Add("ID")
            dt.Columns.Add("Unit")

            cmd = New SQLiteCommand($"Select * From TBL_Payroll_Att_Production_Type where Attendance_Type = 'Production' and {Company_Visible_Filter()}", cn)
            r = cmd.ExecuteReader
            While r.Read
                dr = dt.NewRow

                dr("ID") = r("ID")
                dr("Name") = r("Name")
                dr("Alias") = r("alias").ToString

                dr("Unit") = Find_DT_Unit_Conves(r("Unit"))

                dt.Rows.Add(dr)
            End While
            Production_Source.DataSource = dt




        End If


        dt = New DataTable
        dt.Columns.Add("Name")
        dt.Rows.Add("Days")
        dt.Rows.Add("Months")


        Cal_Source.DataSource = dt
    End Function
    Private Function Button_Manage()
        Button_Clear()
        BG_frm.B_1.Text = "&E : Exit"
        BG_frm.B_2.Text = "&S : Save"
        If VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close" Then
            BG_frm.B_3.Text = "&D : Delete"
        End If
    End Function
    Private Function Add_Hander_Remove_Handel(Ans As Boolean)
        If Ans = True Then
            AddHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            AddHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
            AddHandler BG_frm.B_3.Click, AddressOf Me.B_3_Click
        Else
            RemoveHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            RemoveHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
            RemoveHandler BG_frm.B_3.Click, AddressOf Me.B_3_Click
        End If
    End Function
    Private Sub B_1_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Me.Dispose()
        End If
    End Sub
    Private Sub B_2_Click(sender As Object, e As EventArgs)
        Save_Data()
    End Sub
    Private Sub B_3_Click(sender As Object, e As EventArgs)
        If VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close" Then
            If BG_frm.From_ID = From_ID Then
                Delete_Data()
            End If
        End If
    End Sub
    Private Function Save_Data()
        If BG_frm.From_ID = From_ID Then

            If Save_Requr() = True Then
                If Insurt_Audit() = True Then
                    If Insurt_Value() = True Then
                        If Cal_Type_TXT.Text = "As Computed Value" Then
                        End If
                        Clear_all()
                    End If
                End If
            End If
        End If
    End Function
    Private Function Delete_Data()
        Dim cn As New SQLiteConnection
        open_MSSQL_Cstm(Database_File.cre, cn)


        If Chack_Delete_Allow() = True Then
            If Msg_Delete_YN(Name_TXT, "PayHead") = DialogResult.Yes Then
                If Insurt_Audit() = True Then
                    qury = $"DELETE FROM TBL_PayHead Where ID = '{VC_ID_}';"
                    cmd = New SQLiteCommand(qury, cn)
                    cmd.ExecuteNonQuery()
                    Clear_all()
                End If
            End If
        Else
            Msg_Custom_YN(NOT_Location.Bottom_Right, Color.Red, My.Resources.Error_animation_icn, Dialoag_Button.Ok, "Error!", "Payhead is not delete", "This 'Payhead' will not be modified,<nl>as this 'Payhead' is linked under another 'vouchers',<nl>if you want to modify the 'Payhead',<nl>delete the linked 'voucher' or unlink it.")
        End If
    End Function

    Private Function Insurt_Audit() As Boolean
        If Val(VC_ID_) = 0 Then
            Return True
        End If

        If Audit_Save("TBL_PayHead", "ID", VC_ID_) = True Then
            Return True
        End If
    End Function
    Private Function Chack_Delete_Allow() As Boolean

        Dim cn As New SQLiteConnection
        Dim r As SQLiteDataReader
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select vc.ID From TBL_VC vc where vc.Payhead = '{VC_ID_}' and vc.Effect_PayHead = 'Yes' and vc.Visible = 'Approval'
UNION ALL
Select sd.ID From TBL_Payroll_SalaryDetails sd where sd.Payhead = '{VC_ID_}' and sd.Visible = 'Approval'", cn)
            r = cmd.ExecuteReader
            While r.Read
                r.Close()
                Return False
            End While
        End If
        Return True

    End Function
    Dim Duplicate_Type As String
    Dim Duplicate_Type1 As String

    Dim Duplicate_Alias_Type As String
    Dim Duplicate_Alias_Type1 As String
    Private Function Save_Requr() As Boolean
        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            Duplicate_Type = " Name  = '" & Name_TXT.Text & "'"
        Else
            Duplicate_Type = " Name  = '" & Name_TXT.Text & "' and ID <> '" & VC_ID_ & "'"
        End If
        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            Duplicate_Type1 = "Alias  = '" & Alias_TXT.Text & "'"
        Else
            Duplicate_Type1 = " Alias  = '" & Alias_TXT.Text & "' and ID <> '" & VC_ID_ & "'"
        End If
        '//
        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            Duplicate_Alias_Type = "Name  = '" & Alias_TXT.Text & "'"
        Else
            Duplicate_Alias_Type = "Name  = '" & Alias_TXT.Text & "' and ID <> '" & VC_ID_ & "'"
        End If
        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            Duplicate_Alias_Type1 = "Alias  = '" & Alias_TXT.Text & "'"
        Else
            Duplicate_Alias_Type1 = "Alias  = '" & Alias_TXT.Text & "' and ID <> '" & VC_ID_ & "'"
        End If
        If Name_TXT.Text = Nothing Then
            Msg(NOT_Type.Warning, "Input Error - Name", "Please enter name and try agin")
            Name_TXT.Focus()
            Return False
            Exit Function
        End If
        If Name_TXT.Text = Alias_TXT.Text Then
            Msg(NOT_Type.Warning, "Name and Alias is Same", "Please name or alias change and try again")
            Alias_TXT.Focus()
            Return False
            Exit Function
        End If
        If Chack_Duplicate(Database_File.cre, "TBL_PayHead", "Name", Duplicate_Type) = True Then
            Msg(NOT_Type.Warning, "Duplicate Name", "Name already exists please change name and try again")
            Name_TXT.Focus()
            Return False
            Exit Function
        End If
        If Chack_Duplicate(Database_File.cre, "TBL_PayHead", "Alias", Duplicate_Type1) = True And Alias_TXT.Text <> Nothing Then
            Msg(NOT_Type.Warning, "Duplicate Name", "Alias already exists please change name and try again")
            Alias_TXT.Focus()
            Return False
            Exit Function
        End If
        '//
        If Chack_Duplicate(Database_File.cre, "TBL_PayHead", "Name", Duplicate_Alias_Type) = True Then
            Msg(NOT_Type.Warning, "Duplicate Alias", "Alias already exists please change name and try again")
            Alias_TXT.Focus()
            Return False
            Exit Function
        End If
        If Chack_Duplicate(Database_File.cre, "TBL_PayHead", "Alias", Duplicate_Alias_Type1) = True And Alias_TXT.Text <> Nothing Then
            Msg(NOT_Type.Warning, "Duplicate Alias", "Alias already exists please change name and try again")
            Alias_TXT.Focus()
            Return False
            Exit Function
        End If
        If Chack_Duplicate(Database_File.cre, "TBL_Acc_Group", "Name", " Name  = '" & Under_TXT.Text & "'") = False Then
            Msg(NOT_Type.Warning, "Selection Error - Under Group", "Please select Under Group and Try again")
            Under_TXT.Focus()
            Return False
            Exit Function
        Else
            Under_ = Find_DT_Value(Database_File.cre, "TBL_Acc_Group", "ID", "Name  = '" & Under_TXT.Text & "'")
        End If

        If Attendance_type_TXT.Visible = True Then
            If Chack_Duplicate(Database_File.cre, "TBL_Payroll_Att_Production_Type", "Name", " Name  = '" & Attendance_type_TXT.Text.ToString & "'") = False Then
                Msg(NOT_Type.Warning, "Selection Error - Leave without pay", "Leave without pay error, Please select again")
                Attendance_type_TXT.Focus()
                Return False
                Exit Function
            Else
                Attendance_Type_ = Find_DT_Value(Database_File.cre, "TBL_Payroll_Att_Production_Type", "ID", " Name  = '" & Attendance_type_TXT.Text.ToString & "'")
            End If
        End If
        If Production_TXT.Visible = True Then
            If Chack_Duplicate(Database_File.cre, "TBL_Payroll_Att_Production_Type", "Name", " Name  = '" & Production_TXT.Text & "'") = False Then
                Msg(NOT_Type.Warning, "Selection Error - Leave without pay", "Leave without pay error, Please select again")
                Opning_Balance_TXT.Focus()
                Return False
                Exit Function
            Else
                Production_ = Find_DT_Value(Database_File.cre, "TBL_Payroll_Att_Production_Type", "ID", " Name  = '" & Production_TXT.Text & "'")
            End If
        End If
        Return True
    End Function
    Private Function Insurt_Value() As Boolean
        If VC_Type_ = "Create" OrElse VC_Type_ = "Create_Close" Then
            If open_MSSQL(Database_File.cre) Then
                qury = "INSERT INTO TBL_PayHead (Name,alias,Under,Payhead_Type,Cal_Type,Leave_without_pay,Cal,Production,Company,Visible,OB_CR,OB_DR,[User],Date_install,PC,Computed) VALUES (@Name,@alias,@Under,@Payhead_Type,@Cal_Type,@Leave_without_pay,@Cal,@Production,@Company,@Visible,@OB_CR,@OB_DR,@User,@Install_,@PC,@Computed)"
                cmd = New SQLiteCommand(qury, con)
                Try
                    With cmd.Parameters
                        .AddWithValue("@Name", Name_TXT.Text.Trim)
                        .AddWithValue("@alias", Alias_TXT.Text.Trim)
                        .AddWithValue("@Under", Under_.Trim)
                        .AddWithValue("@Payhead_Type", P_Type_TXT.Text.Trim)
                        .AddWithValue("@Cal_Type", Cal_Type_TXT.Text.Trim)
                        .AddWithValue("@Cal", cal_TXT.Text.Trim)
                        If Attendance_type_TXT.Visible = True Then
                            .AddWithValue("@Leave_without_pay", Attendance_Type_.Trim)
                        Else
                            .AddWithValue("@Leave_without_pay", "".Trim)
                        End If

                        If Production_TXT.Visible = True Then
                            .AddWithValue("@Production", Production_.Trim)
                        Else
                            .AddWithValue("@Production", "".Trim)
                        End If

                        If Txt3.Text = "Cr" Then
                            .AddWithValue("@OB_CR", Val(Opning_Balance_TXT.Text))
                            .AddWithValue("@OB_DR", "0".Trim)
                        ElseIf Txt3.Text = "Dr" Then
                            .AddWithValue("@OB_CR", "0".Trim)
                            .AddWithValue("@OB_DR", Val(Opning_Balance_TXT.Text))
                        End If
                        If Cal_Type_TXT.Text = "As Computed Value" Then
                            .AddWithValue("@Computed", "")
                        Else
                            .AddWithValue("@Computed", "")
                        End If

                        .AddWithValue("@Company", Company_ID_str.Trim)
                        .AddWithValue("@Visible", "Approval".Trim)
                        .AddWithValue("@User", LOGIN_ID)
                        .AddWithValue("@PC", PC_ID.Trim)
                        .AddWithValue("@Install_", CDate(DateTime.Now))
                        cmd.ExecuteNonQuery()
                    End With
                    Return True
                Catch ex As Exception
                    Msg(NOT_Type.Erro, "Data Save Error", ex.Message)
                    Return False
                End Try
            End If
        Else
            If open_MSSQL(Database_File.cre) Then
                qury = "UPDATE TBL_PayHead SET Name = @Name,alias = @alias,Under = @Under,Payhead_Type = @Payhead_Type,Cal_Type = @Cal_Type,Leave_without_pay = @Leave_without_pay,Cal = @Cal,Production = @Production,OB_CR = @OB_CR,OB_DR = @OB_DR,[User] = @User,Date_install = @Install_,PC = @PC,Computed = @Computed WHERE ID = '" & VC_ID_ & "'"
                cmd = New SQLiteCommand(qury, con)
                Try
                    With cmd.Parameters
                        .AddWithValue("@Name", Name_TXT.Text.Trim)
                        .AddWithValue("@alias", Alias_TXT.Text.Trim)
                        .AddWithValue("@Under", Under_.Trim)
                        .AddWithValue("@Payhead_Type", P_Type_TXT.Text.Trim)
                        .AddWithValue("@Cal_Type", Cal_Type_TXT.Text.Trim)
                        .AddWithValue("@Cal", cal_TXT.Text.Trim)
                        If Attendance_type_TXT.Visible = True Then
                            .AddWithValue("@Leave_without_pay", Attendance_Type_.Trim)
                        Else
                            .AddWithValue("@Leave_without_pay", "".Trim)
                        End If

                        If Production_TXT.Visible = True Then
                            .AddWithValue("@Production", Production_.Trim)
                        Else
                            .AddWithValue("@Production", "".Trim)
                        End If
                        If Txt3.Text = "Cr" Then
                            .AddWithValue("@OB_CR", Val(Opning_Balance_TXT.Text))
                            .AddWithValue("@OB_DR", "0".Trim)
                        ElseIf Txt3.Text = "Dr" Then
                            .AddWithValue("@OB_CR", "0".Trim)
                            .AddWithValue("@OB_DR", Val(Opning_Balance_TXT.Text))
                        End If
                        If Cal_Type_TXT.Text = "As Computed Value" Then
                            .AddWithValue("@Computed", "")
                        Else
                            .AddWithValue("@Computed", "")
                        End If
                        .AddWithValue("@User", LOGIN_ID)
                        .AddWithValue("@PC", PC_ID.Trim)
                        .AddWithValue("@Install_", CDate(DateTime.Now))
                        cmd.ExecuteNonQuery()
                    End With
                    Return True
                Catch ex As Exception
                    Msg(NOT_Type.Erro, "Data Save Error", ex.Message)
                    Return False
                End Try
            End If
        End If
    End Function
    Private Function Clear_all()
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            'BG_frm.Payroll_Payhead_BS.DataSource = Nothing
            'BG_frm.Payroll_Payhead_BS.DataSource = Fill_Payroll_Payhead(cn)
        End If

        If VC_Type_ = "Create" Then
            Total_Opning_balance()
            Name_TXT.Text = ""
            Alias_TXT.Text = ""
            Attendance_type_TXT.Text = ""
            Production_TXT.Text = ""
            Opning_Balance_TXT.Text = ""
            Name_TXT.Focus()
            NOT_("The entry you entered has been successfully accepted", NOT_Type.Success)
        Else
            If close_link_yn = True Then
                close_focus_obj.Text = Name_TXT.Text
                close_focus_obj.Focus()
            End If
            Me.Dispose()
        End If
    End Function
    Private Sub Payroll_Payhead_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If Msg_Exit_YN("Pay Head " & VC_Type_) = DialogResult.Yes Then
                Me.Dispose()
                If VC_Type_ = "Alter_Close" Or VC_Type_ = "Create_Close" Then
                    close_focus_obj.Focus()
                End If
            End If
        End If
    End Sub
    Private Sub TextBox1_Enter(sender As Object, e As EventArgs) Handles Attendance_type_TXT.Enter

    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles Attendance_type_TXT.TextChanged

    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles Attendance_type_TXT.KeyDown

    End Sub
    Private Sub TextBox2_Enter(sender As Object, e As EventArgs) Handles Production_TXT.Enter

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles Production_TXT.TextChanged

    End Sub

    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles Production_TXT.KeyDown

        If e.KeyCode = Keys.C AndAlso e.Modifiers = Keys.Alt Then
            Dim frm As New Payroll_Atten_Production_Type_frm
            sHortcut_open_frm(frm, sender, "", "Create_Close", "")
            frm.Type_TXT.Text = "Production"
            frm.Type_TXT.Enabled = False
            NOT_("Create new", NOT_Type.Info)
        ElseIf e.KeyCode = Keys.Enter AndAlso e.Modifiers = Keys.Control Then

        End If
    End Sub
    Private Function Total_Opning_balance()
        Dim Arr As ArrayList = Company_Opning_Balance(Branch_ID_)
        Label45.Text = Arr(0)
        Label44.Text = Arr(1)
        Label46.Text = Arr(2)
    End Function

    Private Sub Payroll_Payhead_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.TYP_TXT.Text = VC_Type_
        BG_frm.HADE_TXT.Text = "Payroll Pay Head"
        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text

        Total_Opning_balance()
        Button_Clear()
        Button_Manage()
        Name_TXT.Focus()
    End Sub

    Private Sub Payroll_Payhead_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End
        Add_Hander_Remove_Handel(False)
        Frm_foCus()
    End Sub

    Private Function Display_Fill_All()
        Name_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_PayHead", "Name", "ID = '" & VC_ID_ & "'")
        Alias_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_PayHead", "alias", "ID = '" & VC_ID_ & "'")
        Under_ = Find_DT_Value(Database_File.cre, "TBL_PayHead", "Under", "ID = '" & VC_ID_ & "'")

        P_Type_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_PayHead", "Payhead_Type", "ID = '" & VC_ID_ & "'")
        Cal_Type_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_PayHead", "Cal_Type", "ID = '" & VC_ID_ & "'")
        Attendance_Type_ = Find_DT_Value(Database_File.cre, "TBL_PayHead", "Leave_without_pay", "ID = '" & VC_ID_ & "'")
        Attendance_type_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Payroll_Att_Production_Type", "Name", "ID = '" & Attendance_Type_ & "'")

        Production_ = Find_DT_Value(Database_File.cre, "TBL_PayHead", "Production", "ID = '" & VC_ID_ & "'")
        Production_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Payroll_Att_Production_Type", "Name", "ID = '" & Production_ & "'")
        Dim ob_cr As Decimal = Val(Find_DT_Value(Database_File.cre, "TBL_PayHead", "OB_CR", "ID = '" & VC_ID_ & "'"))
        Dim ob_dr As Decimal = Val(Find_DT_Value(Database_File.cre, "TBL_PayHead", "OB_DR", "ID = '" & VC_ID_ & "'"))

        Under_ = Find_DT_Value(Database_File.cre, "TBL_PayHead", "Under", "ID = '" & VC_ID_ & "'")
        Under_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Acc_Group", "Name", "ID = '" & Under_ & "'")

        cal_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_PayHead", "Cal", "ID = '" & VC_ID_ & "'")

        If Val(ob_cr) < Val(ob_dr) Then
            Opning_Balance_TXT.Text = ob_dr
            Txt3.Text = "Dr"
        Else
            Opning_Balance_TXT.Text = ob_dr
            Txt3.Text = "Cr"
        End If




        Dim isEnabale As Boolean = Chack_Delete_Allow()

        Panel19.Enabled = isEnabale

    End Function
    Private Function Name_aLlow() As Boolean
        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            Duplicate_Type = " Name  = '" & Name_TXT.Text & "'"
        Else
            Duplicate_Type = " Name  = '" & Name_TXT.Text & "' and ID <> '" & VC_ID_ & "'"
        End If

        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            Duplicate_Type1 = " Alias  = '" & Name_TXT.Text & "'"
        Else
            Duplicate_Type1 = " Alias  = '" & Name_TXT.Text & "' and ID <> '" & VC_ID_ & "'"
        End If

        If Name_TXT.Text = "" Then
            NOT_("Not Valid Without a Blank 'Name'", NOT_Type.Warning)
            Return False
            Exit Function
        End If

        If Chack_Duplicate(Database_File.cre, "TBL_PayHead", "Name", Duplicate_Type) = True Then
            NOT_("The Name Entered is a 'Duplicate'", NOT_Type.Warning)
            Return False
            Exit Function
        ElseIf Chack_Duplicate(Database_File.cre, "TBL_PayHead", "Nickname", Duplicate_Type1) = True Then
            NOT_("The Name Entered is a 'Duplicate'", NOT_Type.Warning)
            Return False
            Exit Function
        Else
            NOT_Clear()
            Return True
        End If
        Return True
    End Function

    Private Sub Name_TXT_Enter(sender As Object, e As EventArgs) Handles Name_TXT.Enter
        Name_aLlow()
    End Sub
    Private Sub Name_TXT_TextChanged(sender As Object, e As EventArgs) Handles Name_TXT.TextChanged
        Name_aLlow()
    End Sub
    Private Sub Name_TXT_Lostfocus(sender As Object, e As EventArgs) Handles Name_TXT.LostFocus
        If Name_aLlow() = False Then
            Name_TXT.Focus()
        End If
    End Sub
    Private Function Alisa_aLlow() As Boolean
        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            Duplicate_Alias_Type = "Name  = '" & Alias_TXT.Text & "'"
        Else
            Duplicate_Alias_Type = "Name  = '" & Alias_TXT.Text & "' and ID <> '" & VC_ID_ & "'"
        End If

        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            Duplicate_Alias_Type1 = "Alias  = '" & Alias_TXT.Text & "'"
        Else
            Duplicate_Alias_Type1 = "Alias  = '" & Alias_TXT.Text & "' and ID <> '" & VC_ID_ & "'"

        End If
        If Alias_TXT.Text <> "" Then
            If Name_TXT.Text = Alias_TXT.Text Then
                NOT_("Name and Alias is Sam", NOT_Type.Warning)
                Return False
                Exit Function
            End If

            If Chack_Duplicate(Database_File.cre, "TBL_PayHead", "Nickname", Duplicate_Alias_Type) = True Then
                NOT_("The Alias Entered is a 'Duplicate'", NOT_Type.Warning)
                Return False
                Exit Function
            ElseIf Chack_Duplicate(Database_File.cre, "TBL_PayHead", "Name", Duplicate_Alias_Type1) = True Then
                NOT_("The Alias Entered is a 'Duplicate'", NOT_Type.Warning)
                Return False
                Exit Function
            Else
                NOT_Clear()
                Return True
            End If
        Else
            Return True
        End If
    End Function
    Private Sub Alias_TXT_Enter(sender As Object, e As EventArgs) Handles Alias_TXT.Enter
        Alisa_aLlow()
    End Sub
    Private Sub Alias_TXT_TextChanged(sender As Object, e As EventArgs) Handles Alias_TXT.TextChanged
        Alisa_aLlow()
    End Sub
    Private Sub Alias_TXT_LostFocus(sender As Object, e As EventArgs) Handles Alias_TXT.LostFocus
        If Alisa_aLlow() = False Then
            Alias_TXT.Focus()
        End If
    End Sub

    Private Sub Grid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub Type_select_TextChanged(sender As Object, e As EventArgs)
        If P_Type_TXT.Text = "Not Applicable" Then
            Panel19.Hide()
        Else
            Panel19.Show()
        End If
        Under_TXT.Text = ""
    End Sub

    Private Sub Calculation_type_select_Load(sender As Object, e As EventArgs)

    End Sub

    Private Sub Calculation_type_select_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Select_ctrl1_Load(sender As Object, e As EventArgs)

    End Sub

    Private Sub TAB_txt_TextChanged(sender As Object, e As EventArgs) Handles TAB_txt.TextChanged

    End Sub

    Private Sub TAB_txt_Enter(sender As Object, e As EventArgs) Handles TAB_txt.Enter
        Dim result As DialogResult = Msg_Save_YN(Name_TXT, "Employee")

        If result = DialogResult.Yes Then
            Save_Data()
        ElseIf result = DialogResult.No Then
            Name_TXT.Focus()
        ElseIf result = DialogResult.Cancel Then
            SendKeys.Send("{BACKSPACE}")
        End If
    End Sub

    Private Sub P_Type_TXT_TextChanged(sender As Object, e As EventArgs) Handles P_Type_TXT.TextChanged

    End Sub

    Private Sub Cal_Type_TXT_TextChanged(sender As Object, e As EventArgs) Handles Cal_Type_TXT.TextChanged
        If Cal_Type_TXT.Text = "As User Defined Value" Then
            Label12.Hide()
            Label11.Hide()
            Attendance_type_TXT.Hide()

            Label14.Hide()
            Label13.Hide()
            cal_TXT.Hide()

            Label10.Hide()
            Label9.Hide()
            Production_TXT.Hide()
            Formula_Panel.Hide()
        ElseIf Cal_Type_TXT.Text = "Flat Rate" Then
            Label12.Hide()
            Label11.Hide()
            Attendance_type_TXT.Hide()

            Label14.Show()
            Label13.Show()
            cal_TXT.Show()

            Label10.Hide()
            Label9.Hide()
            Production_TXT.Hide()
            Formula_Panel.Hide()
        ElseIf Cal_Type_TXT.Text = "On Attendance" Then
            Label12.Show()
            Label11.Show()
            Attendance_type_TXT.Show()

            Label14.Show()
            Label13.Show()
            cal_TXT.Show()

            Label10.Hide()
            Label9.Hide()
            Production_TXT.Hide()
            Formula_Panel.Hide()
        ElseIf Cal_Type_TXT.Text = "On Production" Then
            Label12.Hide()
            Label11.Hide()
            Attendance_type_TXT.Hide()

            Label14.Hide()
            Label13.Hide()
            cal_TXT.Hide()

            Label10.Show()
            Label9.Show()
            Production_TXT.Show()
            Formula_Panel.Hide()
        ElseIf Cal_Type_TXT.Text = "As Computed Value" Then
            Label12.Hide()
            Label11.Hide()
            Attendance_type_TXT.Hide()

            Label14.Show()
            Label13.Show()
            cal_TXT.Show()

            Label10.Hide()
            Label9.Hide()
            Production_TXT.Hide()

            Formula_Panel.Show()
        End If
    End Sub

    Private Sub Txt3_TextChanged(sender As Object, e As EventArgs) Handles Txt3.TextChanged

    End Sub

    Private Sub Txt3_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt3.KeyDown
        If e.KeyCode = Keys.C Then
            Txt3.Text = "Cr"
        ElseIf e.KeyCode = Keys.D Then
            Txt3.Text = "Dr"
        End If

    End Sub

    Private Sub P_Type_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles P_Type_TXT.KeyDown
        If e.KeyCode = Keys.Enter Then
            Fill_data_Under_Group()
            Fill_data_Attendance_Type()
        End If
    End Sub

    Private Sub Payroll_Payhead_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
    End Sub
End Class