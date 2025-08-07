Imports System.Data.SqlClient
Imports System.Data.SQLite
Imports System.IO

Public Class Payroll_Atten_Production_Type_frm
    Dim From_ID As String
    Dim Under_ID As String
    Dim Under As String
    Dim Path_End As String
    Dim VC_Type_ As String
    Dim VC_ID_ As String
    Dim Unit_ID As String
    Dim Unit As String
    Dim Unit_Type As String
    Private Sub Payroll_Atten_Production_Type_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text

        VC_Type_ = Link_Valu(1)
        VC_ID_ = Link_Valu(2)

        BG_frm.HADE_TXT.Text = "Payroll Attendance\Production Type"
        BG_frm.TYP_TXT.Text = VC_Type_

        Fill_data_Source()
        List_set()

        If VC_Type_ = "Display" Or VC_Type_ = "Display_Close" Then
            Me.Enabled = False
            Display_Fill_All()
        ElseIf VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close" Then
            Me.Enabled = True
            Display_Fill_All()
        ElseIf VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then

        End If

        Button_Manage()
        Add_Hander_Remove_Handel(True)
        Name_TXT.Focus()
    End Sub

    Dim group_list As List_frm
    Dim unit_list As List_frm
    Private Function List_set()
        group_list = New List_frm
        List_Setup("List of Attendance\Production Type", Select_List.Right, Select_List_Format.Singel, Type_TXT, group_list, Type_source, 320)

        unit_list = New List_frm
        List_Setup("List of Units", Select_List.Right, Select_List_Format.Defolt, Unit_TXT, unit_list, Unit_Source, 350)

    End Function


    Private Function Fill_data_Source()
        Dim cn As New SQLiteConnection

        Dim dt As New DataTable
        Dim dr As DataRow

        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then

            dt.Columns.Add("Name")
            dt.Columns.Add("Formal_Name")
            dt.Columns.Add("ID")

            cmd = New SQLiteCommand("Select * From TBL_Inventory_Unit where Head = 'Payroll' and " & Company_Visible_Filter(), cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                dr = dt.NewRow
                dr("ID") = r("ID")

                If r("Type") = "Compound" Then
                    dr("Name") = Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "Symbol", "ID = '" & r("Unit1") & "'") & " of " & r("Conversion") & " " & Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "Symbol", "ID = '" & r("Unit2") & "'")
                Else
                    dr("Name") = r("Symbol")
                End If


                dr("Formal_Name") = r("Formal_Name")
                dt.Rows.Add(dr)
            End While
            r.Close()

            Unit_Source.DataSource = dt

        End If
        cn.Close()

        dt = New DataTable
        dt.Columns.Add("Name")
        dt.Rows.Add("Attendance / Leave with Pay")
        dt.Rows.Add("Leave without Pay")
        dt.Rows.Add("Production")

        Type_source.DataSource = dt
    End Function
    Private Sub Payroll_Atten_Production_Type_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.TYP_TXT.Text = VC_Type_
        BG_frm.HADE_TXT.Text = "Payroll Attendance\Production Type"
        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text

        Button_Clear()
        Button_Manage()
        Name_TXT.Focus()
    End Sub

    Private Sub Payroll_Atten_Production_Type_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End
        Add_Hander_Remove_Handel(False)
        Frm_foCus()
    End Sub
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
        Me.Dispose()
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
    Private Function Delete_Data()
        Dim cn As New SQLiteConnection
        open_MSSQL_Cstm(Database_File.cre, cn)


        If Chack_Delete_Allow() = True Then
            If Msg_Delete_YN(Name_TXT, "Payroll Attendance\Production Type") = DialogResult.Yes Then
                If Insurt_Audit() = True Then
                    qury = $"DELETE FROM TBL_Payroll_Att_Production_Type Where ID = '{VC_ID_}';"
                    cmd = New SQLiteCommand(qury, cn)
                    cmd.ExecuteNonQuery()
                    Clear_all()
                End If
            End If
        Else
            Msg_Custom_YN(NOT_Location.Bottom_Right, Color.Red, My.Resources.Error_animation_icn, Dialoag_Button.Ok, "Error!", "Attendance\Production Type is not delete", "This 'Attendance\Production Type' will not be modified,<nl>as this 'Attendance\Production Type' is linked under another 'vouchers',<nl>if you want to modify the 'Attendance\Production Type',<nl>delete the linked 'voucher' or unlink it.")
        End If
    End Function
    Private Function Chack_Delete_Allow() As Boolean
        Dim cn As New SQLiteConnection
        Dim r As SQLiteDataReader
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select phd.ID From TBL_Payhead phd where (phd.Leave_without_pay = '{VC_ID_}' or phd.Production = '{VC_ID_}') and phd.Visible = 'Approval'
UNION ALL 
Select vc.ID From TBL_Attendance_VC vc where Attendance_ID = '{VC_ID_}' and Visible = 'Approval'", cn)
            r = cmd.ExecuteReader
            While r.Read
                r.Close()
                Return False
            End While
        End If
        Return True
    End Function
    Private Function Insurt_Audit() As Boolean
        If Val(VC_ID_) = 0 Then
            Return True
        End If

        If Audit_Save("TBL_Payroll_Att_Production_Type", "ID", VC_ID_) = True Then
            Return True
        End If
    End Function
    Private Function Save_Data()
        If BG_frm.From_ID = From_ID Then
            If Save_Requr() = True Then
                If Insurt_Audit() = True Then
                    If Insurt_Value() = True Then
                        Clear_all()
                    End If
                End If
            End If
        End If
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
            Duplicate_Type1 = " Alias  = '" & Name_TXT.Text & "'"
        Else
            Duplicate_Type1 = " Alias  = '" & Name_TXT.Text & "' and ID <> '" & VC_ID_ & "'"
        End If
        '
        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            Duplicate_Alias_Type = " Name  = '" & Alias_TXT.Text & "'"
        Else
            Duplicate_Alias_Type = " Name  = '" & Alias_TXT.Text & "' and ID <> '" & VC_ID_ & "'"
        End If

        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            Duplicate_Alias_Type1 = " Alias  = '" & Alias_TXT.Text & "'"
        Else
            Duplicate_Alias_Type1 = " Alias  = '" & Alias_TXT.Text & "' and ID <> '" & VC_ID_ & "'"
        End If

        If Name_TXT.Text = "" Then
            Msg(NOT_Type.Warning, "Input Error - Name", "Please enter name and try agin")
            Name_TXT.Focus()
            Return False
            Exit Function
        End If
        If Name_TXT.Text = Alias_TXT.Text Then
            Msg(NOT_Type.Warning, "Name and Alias is Same", "Please Chane Name or Alias and try agin")
            Alias_TXT.Focus()
            Return False
            Exit Function
        End If
        If Chack_Duplicate(Database_File.cre, "TBL_Payroll_Att_Production_Type", "Name", Duplicate_Type) = True Then
            Msg(NOT_Type.Warning, "Duplicate - Name", "Name already exists please change name and try again")
            Name_TXT.Focus()
            Return False
            Exit Function
        End If
        If Chack_Duplicate(Database_File.cre, "TBL_Payroll_Att_Production_Type", "Alias", Duplicate_Type1) = True Then
            Msg(NOT_Type.Warning, "Duplicate - Alias", "Name already exists please change name and try again")
            Alias_TXT.Focus()
            Return False
            Exit Function
        End If
        ''
        If Chack_Duplicate(Database_File.cre, "TBL_Payroll_Att_Production_Type", "Name", Duplicate_Alias_Type) = True Then
            Msg(NOT_Type.Warning, "Duplicate - Name", "Name already exists please change name and try again")
            Name_TXT.Focus()
            Return False
            Exit Function
        End If

        If Chack_Duplicate(Database_File.cre, "TBL_Payroll_Att_Production_Type", "Alias", Duplicate_Alias_Type1) = True And Alias_TXT.Text <> Nothing Then
            Msg(NOT_Type.Warning, "Duplicate - Alias", "Alias already exists please change name and try again")
            Return False
            Exit Function
        End If
        If Type_TXT.Text = "Production" Then
            If Chack_Duplicate(Database_File.cre, "TBL_Inventory_Unit", "Symbol", " Symbol  = '" & Unit_TXT.Text & "'") = False Then
                Msg(NOT_Type.Warning, "Selection Error - Unit", "Unit select error, Please select again")
                Unit_TXT.Focus()
                Return False
                Exit Function
            Else
                Unit_ID = Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "ID", " Symbol  = '" & Unit_TXT.Text.Trim & "'")
            End If
        End If
        Return True
    End Function
    Private Function Insurt_Value() As Boolean
        If VC_Type_ = "Create" OrElse VC_Type_ = "Create_Close" Then
            If open_MSSQL(Database_File.cre) Then
                qury = "INSERT INTO TBL_Payroll_Att_Production_Type (Name, alias, Attendance_Type, Unit, Company, Visible,[User],Date_install,PC) VALUES (@Name,@alias,@Attendance_Type, @Unit,@Company,@Visible,@User,@Install_,@PC)"

                cmd = New SQLiteCommand(qury, con)
                Try
                    With cmd.Parameters
                        .AddWithValue("@Name", Name_TXT.Text.Trim)
                        .AddWithValue("@alias", Alias_TXT.Text.Trim)
                        .AddWithValue("@Attendance_Type", Type_TXT.Text.Trim)
                        If Type_TXT.Text = "Production" Then
                            .AddWithValue("@Unit", Unit_ID.Trim)
                        Else
                            .AddWithValue("@Unit", "".Trim)
                        End If
                        .AddWithValue("@Company", Company_ID_str.Trim)
                        .AddWithValue("@Visible", "Approval".Trim)
                        .AddWithValue("@User", LOGIN_ID)
                        .AddWithValue("@Install_", CDate(DateTime.Now))
                        .AddWithValue("@PC", PC_ID.Trim)
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
                qury = "UPDATE TBL_Payroll_Att_Production_Type SET Name = @Name, alias = @alias, Attendance_Type = @Attendance_Type, Unit = @Unit,[User] = @User,Date_install = @Install_, PC = @PC WHERE ID = '" & VC_ID_ & "'"
                cmd = New SQLiteCommand(qury, con)
                Try
                    With cmd.Parameters
                        .AddWithValue("@Name", Name_TXT.Text.Trim)
                        .AddWithValue("@alias", Alias_TXT.Text.Trim)
                        .AddWithValue("@Attendance_Type", Type_TXT.Text.Trim)
                        If Type_TXT.Text = "Production" Then
                            .AddWithValue("@Unit", Unit_ID.Trim)
                        Else
                            .AddWithValue("@Unit", "".Trim)
                        End If
                        .AddWithValue("@User", LOGIN_ID)
                        .AddWithValue("@Install_", CDate(DateTime.Now))
                        .AddWithValue("@PC", PC_ID.Trim)
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
            'BG_frm.Payroll_Att_Production_Type_BS.DataSource = Nothing
            'BG_frm.Payroll_Att_Production_Type_BS.DataSource = Fill_Payroll_Attenda_Production_Type(cn)
        End If

        If VC_Type_ = "Create" Then
            Name_TXT.Text = ""
            Alias_TXT.Text = ""
            Unit_TXT.Text = ""
            Name_TXT.Focus()
            NOT_("The entry you entered has been successfully accepted", NOT_Type.Success)
        Else
            Me.Dispose()
        End If
    End Function
    Private Sub Payroll_Atten_Production_Type_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If Msg_Exit_YN("Attendance\Production Type " & VC_Type_) = DialogResult.Yes Then
                Me.Dispose()
            End If
        End If
    End Sub


    Private Function Display_Fill_All()
        Name_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Payroll_Att_Production_Type", "Name", "ID = '" & VC_ID_ & "'")
        Alias_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Payroll_Att_Production_Type", "alias", "ID = '" & VC_ID_ & "'")
        Type_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Payroll_Att_Production_Type", "Attendance_Type", "ID = '" & VC_ID_ & "'")
        Unit_ID = Find_DT_Value(Database_File.cre, "TBL_Payroll_Att_Production_Type", "Unit", "ID = '" & VC_ID_ & "'")
        Unit_Type = Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "Type", "ID = '" & Unit_ID & "'")
        Unit_TXT.Text = Find_DT_Unit_Conves(Unit_ID)


        Panel3.Enabled = Chack_Delete_Allow()

    End Function
    Private Function Name_aLlow() As Boolean
        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            Duplicate_Type = " Name  = '" + Name_TXT.Text.ToString.Trim + "' and " & Company_Visible_Filter()
        Else
            Duplicate_Type = " Name  = '" & Name_TXT.Text.ToString.Trim & "' and ID <> '" & VC_ID_ & "' and " & Company_Visible_Filter()
        End If

        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            Duplicate_Type1 = " Alias  = '" & Name_TXT.Text.ToString & "' and " & Company_Visible_Filter()
        Else
            Duplicate_Type1 = " Alias  = '" & Name_TXT.Text.ToString & "' and ID <> '" & VC_ID_ & "' and " & Company_Visible_Filter()
        End If

        If Name_TXT.Text = "" Then
            NOT_("Not Valid Without a Blank 'Name'", NOT_Type.Warning)
            Return False
            Exit Function
        End If

        If Chack_Duplicate(Database_File.cre, "TBL_Payroll_Att_Production_Type", "Name", Duplicate_Type) = True Then
            NOT_("The Name Entered is a 'Duplicate'", NOT_Type.Warning)
            Return False
            Exit Function
        ElseIf Chack_Duplicate(Database_File.cre, "TBL_Payroll_Att_Production_Type", "Alias", Duplicate_Type1) = True Then
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
    Private Sub Name_TXT_LostFocus(sender As Object, e As EventArgs) Handles Name_TXT.LostFocus
        If Name_aLlow() = False Then
            Name_TXT.Focus()
        End If
    End Sub
    Private Function Alias_aLlow() As Boolean
        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            Duplicate_Alias_Type = " Name  = '" & Alias_TXT.Text & "' and " & Company_Visible_Filter()
        Else
            Duplicate_Alias_Type = " Name  = '" & Alias_TXT.Text & "' and ID <> '" & VC_ID_ & "' and " & Company_Visible_Filter()
        End If

        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            Duplicate_Alias_Type1 = " Alias  = '" & Alias_TXT.Text & "' and " & Company_Visible_Filter()
        Else
            Duplicate_Alias_Type1 = " Alias  = '" & Alias_TXT.Text & "' and ID <> '" & VC_ID_ & "' and " & Company_Visible_Filter()

        End If
        If Alias_TXT.Text <> "" Then
            If Name_TXT.Text = Alias_TXT.Text Then
                NOT_("Name and Alias is Sam", NOT_Type.Warning)
                Return False
                Exit Function
            End If

            If Chack_Duplicate(Database_File.cre, "TBL_Payroll_Att_Production_Type", "Alias", Duplicate_Alias_Type) = True Then
                NOT_("The Alias Entered is a 'Duplicate'", NOT_Type.Warning)
                Return False
                Exit Function
            ElseIf Chack_Duplicate(Database_File.cre, "TBL_Payroll_Att_Production_Type", "Name", Duplicate_Alias_Type1) = True Then
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
        Alias_aLlow()
    End Sub
    Private Sub Alias_TXT_TextChanged(sender As Object, e As EventArgs) Handles Alias_TXT.TextChanged
        Alias_aLlow()
    End Sub
    Private Sub Alias_TXT_LostFocus(sender As Object, e As EventArgs) Handles Alias_TXT.LostFocus
        If Alias_aLlow() = False Then
            Alias_TXT.Focus()
        End If
    End Sub

    Private Sub Type_select_Load(sender As Object, e As EventArgs)

    End Sub

    Private Sub Type_select_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TAB_txt_TextChanged(sender As Object, e As EventArgs) Handles TAB_txt.TextChanged

    End Sub

    Private Sub TAB_txt_Enter(sender As Object, e As EventArgs) Handles TAB_txt.Enter
        Dim result As DialogResult = Msg_Save_YN(Name_TXT, "Attendance\Production Type")

        If result = DialogResult.Yes Then
            Save_Data()
        ElseIf result = DialogResult.No Then
            Name_TXT.Focus()
        ElseIf result = DialogResult.Cancel Then
            SendKeys.Send("{BACKSPACE}")
        End If



    End Sub

    Private Sub Type_TXT_TextChanged(sender As Object, e As EventArgs) Handles Type_TXT.TextChanged
        If Type_TXT.Text = "Production" Then
            Label12.Show()
            Label10.Show()
            Unit_TXT.Show()
            Label13.Show()

            Label8.Hide()
            Label5.Hide()
            Label9.Hide()
        Else
            Label12.Hide()
            Label10.Hide()
            Unit_TXT.Hide()
            Label13.Hide()

            Label8.Show()
            Label5.Show()
            Label9.Show()
        End If
    End Sub

    Private Sub Unit_TXT_TextChanged(sender As Object, e As EventArgs) Handles Unit_TXT.TextChanged

    End Sub

    Private Sub Unit_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles Unit_TXT.KeyDown
        If e.KeyCode = Keys.Enter Then
            Unit_ID = unit_list.List_Grid.CurrentRow.Cells(2).Value
        End If
    End Sub

    Private Sub Payroll_Atten_Production_Type_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
    End Sub
End Class