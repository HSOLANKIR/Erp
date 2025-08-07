Imports System.Data.SQLite
Imports Tools

Public Class WhatsApp_Template_frm
    Dim Path_End As String
    Dim VC_Type_ As String
    Dim VC_ID_ As String
    Public close_focus_obj As TXT
    Public close_link_yn As Boolean = True
    Private Sub WhatsApp_Template_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Path_End = BG_frm.BG_Path_TXT.Text

        VC_Type_ = Link_Valu(1)
        VC_ID_ = Link_Valu(2)

        BG_frm.HADE_TXT.Text = "WhatsApp Templates"
        BG_frm.TYP_TXT.Text = VC_Type_

        Load_data_source()
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

        Add_Parameter()


        Name_TXT.Focus()


    End Sub

    Private Sub WhatsApp_Template_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.TYP_TXT.Text = VC_Type_

        BG_frm.HADE_TXT.Text = "WhatsApp Templates"
        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text

        Button_Clear()
        Button_Manage()

        Name_TXT.Focus()
    End Sub

    Private Sub WhatsApp_Template_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        NOT_Clear()
        If e.KeyCode = Keys.Escape Then
            If Msg_Exit_YN("Ledger " & VC_Type_) = DialogResult.Yes Then
                Me.Dispose()
                If VC_Type_ = "Alter_Close" Or VC_Type_ = "Create_Close" Then
                    close_focus_obj.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub WhatsApp_Template_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End
        Ledger_Branch_Balance.Dispose()
        Add_Hander_Remove_Handel(False)
        Frm_foCus()
    End Sub

    'All Connditions
    Private Function Button_Manage()
        Button_Clear()
        BG_frm.B_1.Text = "&E : Exit"
        BG_frm.B_2.Text = "&S : Save"

    End Function
    Private Function Add_Hander_Remove_Handel(ans As Boolean)
        If ans = True Then
            AddHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            AddHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
        Else
            RemoveHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            RemoveHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
        End If
    End Function
    Private Sub B_1_Click(sender As Object, e As EventArgs)
        If BG_frm.HADE_TXT.Text = "WhatsApp Templates" Then
            Me.Dispose()
        End If
    End Sub
    Private Sub B_2_Click(sender As Object, e As EventArgs)
        If BG_frm.HADE_TXT.Text = "WhatsApp Templates" Then
            Save_data()
        End If
    End Sub
    Private Function Display_Fill_All()
        Dim cn As New SQLiteConnection
        open_MSSQL_Cstm(Database_File.cre, cn)
        cmd = New SQLiteCommand($"Select *,(Select ag.Name From TBL_Acc_Group ag where ag.ID = w.Account_Group) as Group_Name From TBL_WhatsApp_Temp w where w.ID = '{VC_ID_}'", cn)
        Dim r As SQLiteDataReader = cmd.ExecuteReader
        While r.Read
            Name_TXT.Text = r("Name").ToString
            Txt1.Text = r("WhatsApp_Number").ToString
            Txt3.Text = r("Group_Name").ToString
            Txt3.Data_Link_ = r("Account_Group").ToString
            Txt4.Text = r("Ledger_Permission").ToString
            Txt5.Text = r("Ledger_Filter").ToString
            Message_TXT.Text = r("Message").ToString
        End While
        r.Close()

        cmd = New SQLiteCommand($"Select * From TBL_WhatsApp_Temp_column where Temp_ID = '{VC_ID_}'", cn)
        r = cmd.ExecuteReader
        While r.Read
            Add_Colunm(r("Column_Name").ToString)
        End While
        r.Close()


        Whatsapp_no_set(Txt1.Text)
    End Function
    Private Function Save_data()
        If Save_Requr() = True Then
            If Insurt_Value() = True Then
                Clear_all()
            End If
        End If
    End Function
    Private Function Insurt_Value() As Boolean
        Dim cn As New SQLiteConnection
        open_MSSQL_Cstm(Database_File.cre, cn)
        If VC_Type_ = "Create" OrElse VC_Type_ = "Create_Close" Then
            qury = "INSERT INTO TBL_WhatsApp_Temp (Name, WhatsApp_Number, Account_Group, Ledger_Permission, Ledger_Filter, Message) VALUES (@Name,@WhatsApp_Number,@Account_Group,@Ledger_Permission,@Ledger_Filter,@Message)"
            cmd = New SQLiteCommand(qury, cn)
            Try
                With cmd.Parameters
                    .AddWithValue("@Name", Name_TXT.Text.Trim)
                    .AddWithValue("@WhatsApp_Number", Txt1.Text.Trim)
                    .AddWithValue("@Account_Group", Txt3.Data_Link_.Trim)
                    .AddWithValue("@Ledger_Permission", Txt4.Text.Trim)
                    .AddWithValue("@Ledger_Filter", Txt5.Text.Trim)
                    .AddWithValue("@Message", Message_TXT.Text.Trim)
                    cmd.ExecuteNonQuery()
                End With
            Catch ex As Exception
                Msg(NOT_Type.Erro, "Data Save Error", ex.Message)
                Return False
            End Try
        Else
            qury = $"UPDATE TBL_WhatsApp_Temp Set Name = @Name,WhatsApp_Number = @WhatsApp_Number,Account_Group = @Account_Group,Ledger_Permission = @Ledger_Permission,Ledger_Filter = @Ledger_Filter,Message = @Message WHERE ID = '{VC_ID_}'"
            cmd = New SQLiteCommand(qury, cn)

            Try
                With cmd.Parameters
                    .AddWithValue("@Name", Name_TXT.Text.Trim)
                    .AddWithValue("@WhatsApp_Number", Txt1.Text.Trim)
                    .AddWithValue("@Account_Group", Txt3.Data_Link_.Trim)
                    .AddWithValue("@Ledger_Permission", Txt4.Text.Trim)
                    .AddWithValue("@Ledger_Filter", Txt5.Text.Trim)
                    .AddWithValue("@Message", Message_TXT.Text.Trim)
                    cmd.ExecuteNonQuery()
                End With
            Catch ex As Exception
                Msg(NOT_Type.Erro, "Data Save Error", ex.Message)
                Return False
            End Try
        End If

        If VC_Type_ = "Create" OrElse VC_Type_ = "Create_Close" Then
            VC_ID_ = Find_DT_Value(Database_File.cre, "TBL_WhatsApp_Temp", "ID", $"Name = '{Name_TXT.Text.Trim}'")
        End If

        cmd = New SQLiteCommand($"Delete From TBL_WhatsApp_Temp_column where Temp_ID = '{VC_ID_}'", cn)
        cmd.ExecuteNonQuery()


        'Save_colunm
        Dim P_ As New Queue(Of Whatsapp_tamp_colunm_ctrl)()
        For Each bg_p As Whatsapp_tamp_colunm_ctrl In Panel14.Controls.OfType(Of Whatsapp_tamp_colunm_ctrl)()
            P_.Enqueue(bg_p)
        Next

        For Each bg_p As Whatsapp_tamp_colunm_ctrl In P_.Reverse
            Try
                qury = $"INSERT INTO TBL_WhatsApp_Temp_column (Temp_ID,Column_Name) VALUES ('{VC_ID_}','{bg_p.Name_Label.Text}')"
                cmd = New SQLiteCommand(qury, cn)
                cmd.ExecuteNonQuery()

            Catch ex As Exception

            End Try
        Next

        Return True
    End Function

    Private Function Save_Requr() As Boolean
        If Name_TXT.Text = "" Then
            Msg_Custom_YN(NOT_Location.Center, Color.OrangeRed, My.Resources.Error_animation_icn, Dialoag_Button.Ok, "Input Error", "Name", "Please enter name and try agin")
            Name_TXT.Focus()
            Return False
            Exit Function
        End If
        If Chack_Duplicate(Database_File.cre, "TBL_WhatsApp_Temp", "Name", Duplicate_Type) = True Then
            Msg_Custom_YN(NOT_Location.Center, Color.OrangeRed, My.Resources.Error_animation_icn, Dialoag_Button.Ok, "Duplicate", "Name", "Name already exists please change name and try again")

            Name_TXT.Focus()
            Return False
            Exit Function
        End If
        If Txt1.Text = "" Then
            Msg_Custom_YN(NOT_Location.Center, Color.OrangeRed, My.Resources.Error_animation_icn, Dialoag_Button.Ok, "Input Error", "WhatsApp Number", "Please select WhatsApp Number and try agin")
            Txt1.Focus()
            Return False
            Exit Function
        End If

        If Txt1.Text = "Account Group" Then
            If Txt3.Data_Link_ = Nothing Then
                Msg_Custom_YN(NOT_Location.Center, Color.OrangeRed, My.Resources.Error_animation_icn, Dialoag_Button.Ok, "Input Error", "Account Group", "Please select Account Group and try again")
                Txt3.Focus()
                Exit Function
            End If

            If Txt4.Text = Nothing Then
                Msg_Custom_YN(NOT_Location.Center, Color.OrangeRed, My.Resources.Error_animation_icn, Dialoag_Button.Ok, "Input Error", "Ledger Permission", "Please select Ledger Permission and try again")
                Txt4.Focus()
                Exit Function
            End If
            If Txt5.Text = Nothing Then
                Msg_Custom_YN(NOT_Location.Center, Color.OrangeRed, My.Resources.Error_animation_icn, Dialoag_Button.Ok, "Input Error", "Ledger Filter", "Please select Ledger Filter and try again")
                Txt4.Focus()
                Exit Function
            End If
        End If

        Return True
    End Function
    Private Function Load_data_source()
        Dim dt As New DataTable
        dt.Columns.Add("Name")
        dt.Rows.Add("Not Applicable")
        dt.Rows.Add("Custom")
        dt.Rows.Add("Account Group")

        typeofNo_Surce.DataSource = dt

        dt = New DataTable
        dt.Columns.Add("Name")
        dt.Rows.Add("All")
        dt.Rows.Add("Only those with permission")
        BindingSource1.DataSource = dt

        dt = New DataTable
        dt.Columns.Add("Name")
        dt.Rows.Add("All Ledgers")
        dt.Rows.Add("Credit limit has been exhausted.")
        dt.Rows.Add("Those with negative balances")
        Ledger_Filter_Surce.DataSource = dt

        dt = New DataTable
        dt.Columns.Add("Name")
        dt.Columns.Add("Under Group")
        dt.Columns.Add("ID")
        Dim dr As DataRow
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) Then
            cmd = New SQLiteCommand("Select ID,Name,(Select [Name] From TBL_Acc_Group agg where agg.ID = ag.UserGroup) as Under_Group From TBL_Acc_Group ag where " & Company_Visible_Filter(), cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                dr = dt.NewRow
                dr("ID") = r("ID").ToString
                dr("Name") = r("Name").ToString
                If r("Under_Group").ToString = Nothing Then
                    dr("Under Group") = "Primary"
                Else
                    dr("Under Group") = r("Under_Group").ToString
                End If
                dt.Rows.Add(dr)
            End While
            r.Close()
        End If
        Group_Source.DataSource = dt

        Fill_Ledger_Colunm("")
    End Function
    Dim type_of_no_list As List_frm
    Dim ag_list As List_frm
    Dim ledger_parrmition_list As List_frm
    Dim ledger_filter_list As List_frm
    Dim ledger_colunm_list As List_frm
    Private Function List_set()
        type_of_no_list = New List_frm
        List_Setup("List of Type of WhatsApp", Select_List.Right, Select_List_Format.Singel, Txt1, type_of_no_list, typeofNo_Surce, 200)

        ag_list = New List_frm
        List_Setup("List of Account Groups", Select_List.Right_Dock, Select_List_Format.Defolt, Txt3, ag_list, Group_Source, 320)

        ledger_parrmition_list = New List_frm
        List_Setup("Type of Ledger Permission", Select_List.Right, Select_List_Format.Singel, Txt4, ledger_parrmition_list, BindingSource1, 200)

        ledger_filter_list = New List_frm
        List_Setup("Type of Ledger Filter", Select_List.Right, Select_List_Format.Singel, Txt5, ledger_filter_list, Ledger_Filter_Surce, 250)

        ledger_colunm_list = New List_frm
        List_Setup("Parameters of Ledger", Select_List.Right, Select_List_Format.Defolt, Txt6, ledger_colunm_list, Ledger_Colunm_Surce, 250)
        ledger_colunm_list.System_Data_integer = 1


    End Function

    Private Sub Txt1_TextChanged(sender As Object, e As EventArgs) Handles Txt1.TextChanged

    End Sub

    Private Sub Txt1_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Whatsapp_no_set(type_of_no_list.List_Grid.CurrentRow.Cells(0).Value)
        End If
    End Sub
    Private Function Whatsapp_no_set(head As String)
        If head = "Not Applicable" Then
            Acc_Group_Panel.Visible = False
            Panel11.Visible = False
        ElseIf Head = "Custom" Then
            Acc_Group_Panel.Visible = False
            Panel11.Visible = True
        ElseIf Head = "Account Group" Then
            Acc_Group_Panel.Visible = True
            Panel11.Visible = True
        End If
        Fill_Ledger_Colunm(head)
    End Function

    Private Sub btn_colunm_Click(sender As Object, e As EventArgs) Handles btn_colunm.Click
        Dim P_ As New Queue(Of Whatsapp_tamp_colunm_ctrl)()
        For Each bg_p As Whatsapp_tamp_colunm_ctrl In Panel14.Controls.OfType(Of Whatsapp_tamp_colunm_ctrl)()
            P_.Enqueue(bg_p)
        Next

        For Each bg_p As Whatsapp_tamp_colunm_ctrl In P_.Reverse
            If bg_p.Name_Label.Text.ToLower = Txt6.Text.ToLower Then
                Msg_Custom_YN(NOT_Location.Center, Color.Red, My.Resources.error_gif, Dialoag_Button.Ok, "Duplicate", "Column Name", "You have already added a column.")
                Txt6.Focus()
                Exit Sub
            End If
        Next

        Add_Colunm(Txt6.Text)
        Add_Parameter()


        Txt6.Text = ""
        Txt6.Focus()

    End Sub
    Private Function Add_Colunm(str As String)
        Dim obj As New Whatsapp_tamp_colunm_ctrl
        With obj
            Panel14.Controls.Add(obj)
            .BringToFront()
            .Name_Label.Text = str
            .Dock = DockStyle.Top
            .TabStop = False
        End With
    End Function
    Private Sub Txt3_TextChanged(sender As Object, e As EventArgs) Handles Txt3.TextChanged

    End Sub

    Private Function Fill_Ledger_Colunm(str As String)

        Dim dt = New DataTable
        dt.Columns.Add("Name")
        dt.Columns.Add("Under")
        dt.Rows.Add("", "Custom")
        dt.Rows.Add("End of List", "")
        If str = "Account Group" Then
            dt.Rows.Add("Name", "")
            dt.Rows.Add("Alias", "")
            dt.Rows.Add("Under Group", "")
            dt.Rows.Add("Email", "")
            dt.Rows.Add("Phone", "")
            dt.Rows.Add("Country", "")
            dt.Rows.Add("Pincode", "")
            dt.Rows.Add("State", "")
            dt.Rows.Add("District", "")
            dt.Rows.Add("Taluko", "")
            dt.Rows.Add("City", "")
            dt.Rows.Add("Address", "")
            dt.Rows.Add("Bank Name", "")
            dt.Rows.Add("Bank Branch", "")
            dt.Rows.Add("Bank Account No", "")
            dt.Rows.Add("IFSC Code", "")
            dt.Rows.Add("GST No.", "")
            dt.Rows.Add("PAN No.", "")
            dt.Rows.Add("Credit Limit", "")
            dt.Rows.Add("Current Credit", "")
            dt.Rows.Add("Current Balance", "")

            Txt6.Type_ = "Select"
        Else

            Txt6.Type_ = "TXT"
        End If

        Ledger_Colunm_Surce.DataSource = dt
    End Function

    Private Sub Txt6_TextChanged(sender As Object, e As EventArgs) Handles Txt6.TextChanged
        If Txt6.Text = Nothing Or Txt6.Text.ToLower = "end of list" Then
            btn_colunm.Enabled = False
        Else
            btn_colunm.Enabled = True
        End If
    End Sub

    Private Sub Txt6_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt6.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Txt6.Type_ = "Select" Then
                btn_colunm.Enabled = True
                If ledger_colunm_list.List_Grid.CurrentRow.Cells(1).Value = "Custom" Then
                    ledger_colunm_list.List_Grid.CurrentRow.Cells(0).Value = Txt6.Text
                ElseIf ledger_colunm_list.List_Grid.CurrentRow.Cells(0).Value.ToString.ToLower = "end of list" Then
                    btn_colunm.Enabled = False
                End If
            End If
        End If
    End Sub

    Private Sub Txt6_Enter(sender As Object, e As EventArgs) Handles Txt6.Enter
        ledger_colunm_list.List_Grid.Rows(0).Cells(0).Value = ""
    End Sub

    Private Sub Panel14_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Panel14_ControlAdded(sender As Object, e As ControlEventArgs)

    End Sub
    Public Function Add_Parameter()
        FlowLayoutPanel1.Controls.Clear()
        Dim P_ As New Queue(Of Whatsapp_tamp_colunm_ctrl)()
        For Each bg_p As Whatsapp_tamp_colunm_ctrl In Panel14.Controls.OfType(Of Whatsapp_tamp_colunm_ctrl)()
            P_.Enqueue(bg_p)
        Next

        For Each bg_p As Whatsapp_tamp_colunm_ctrl In P_.Reverse
            Dim btn_ As Button = New Button
            With btn_
                .AutoSize = True
                .AutoSizeMode = AutoSizeMode.GrowAndShrink
                .BackColor = Color.LightYellow
                .FlatStyle = FlatStyle.Flat
                .Text = bg_p.Name_Label.Text
                .TextAlign = ContentAlignment.MiddleLeft
                .UseVisualStyleBackColor = False
                .TabStop = False
                AddHandler .Click, AddressOf Parameter_Click
            End With
            FlowLayoutPanel1.Controls.Add(btn_)
        Next
    End Function

    Private Sub Parameter_Click(sender As Object, e As EventArgs)
        Message_TXT.Text &= "{{" & sender.Text & "}}"
    End Sub
    Dim Duplicate_Type As String
    Private Function Name_aLlow() As Boolean
        If BG_frm.HADE_TXT.Text = "WhatsApp Templates" Then
            If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
                Duplicate_Type = " Name = '" & Name_TXT.Text & "' COLLATE NOCASE"
            Else
                Duplicate_Type = " Name = '" & Name_TXT.Text & "' COLLATE NOCASE and ID <> '" & VC_ID_ & "'"
            End If

            If Name_TXT.Text = "" Then
                'NOT_("Not Valid Without a Blank 'Name'", NOT_Type.Warning)
                Return False
                Exit Function
            End If

            If Chack_Duplicate(Database_File.cre, "TBL_WhatsApp_Temp", "Name", Duplicate_Type) = True Then
                NOT_("The Name Entered is a 'Duplicate'", NOT_Type.Warning)
                'Msg_Duplicat(Name_TXT, "Ledger")
                Return False
                Exit Function
            Else
                NOT_Clear()
                Return True
            End If
        End If
        Return True
    End Function
    Private Sub Name_TXT_Enter(sender As Object, e As EventArgs) Handles Name_TXT.Enter
        Name_aLlow()
    End Sub
    Private Sub Name_TXT_TextChanged(sender As Object, e As EventArgs) Handles Name_TXT.TextChanged
        Name_aLlow()
    End Sub
    Private Sub Name_TXT_Lost_Focus(sender As Object, e As EventArgs) Handles Name_TXT.LostFocus
        If Name_aLlow() = False Then
            Name_TXT.Focus()
        End If
    End Sub
    Private Function Clear_all()
        Dim cn As New SQLiteConnection
        If VC_Type_ = "Create" Then
            Name_TXT.Text = ""
            Txt2.Text = ""
            Txt3.Text = ""
            Txt4.Text = ""
            Txt5.Text = ""
            Txt6.Text = ""
            Message_TXT.Text = ""

            Panel14.Controls.Clear()
            Add_Parameter()


            Name_TXT.Focus()
            NOT_("The entry you entered has been successfully accepted", NOT_Type.Success)
        ElseIf VC_Type_ = "Alter_Close" Or VC_Type_ = "Create_Close" Then
            If close_link_yn = True Then
                close_focus_obj.Text = Name_TXT.Text
            End If

            Me.Dispose()
            close_focus_obj.Focus()
        ElseIf VC_Type_ = "Alter" Then
            Me.Dispose()
        End If
    End Function

    Private Sub Txt3_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt3.KeyDown
        If e.KeyCode = Keys.Enter Then
            Txt3.Data_Link_ = ag_list.List_Grid.CurrentRow.Cells(2).Value
        End If
    End Sub
    Private Sub Save_TXT_Enter(sender As Object, e As EventArgs) Handles Save_TXT.Enter
        Dim result As DialogResult = Msg_Save_YN(Name_TXT, "WhatsApp templates")

        If result = DialogResult.Yes Then
            Save_data()
        ElseIf result = DialogResult.No Then
            Name_TXT.Focus()
        ElseIf result = DialogResult.Cancel Then
            SendKeys.Send("{BACKSPACE}")
        End If
    End Sub
    Private Sub Message_TXT_TextChanged(sender As Object, e As EventArgs) Handles Message_TXT.TextChanged

    End Sub
End Class