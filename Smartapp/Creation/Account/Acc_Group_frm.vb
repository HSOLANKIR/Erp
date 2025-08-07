Imports System.Data.SqlClient
Imports System.Data.SQLite
Imports Tools

Public Class Acc_Group_frm
    Dim From_ID As String
    Dim Under As String
    Dim Path_End As String
    Dim VC_Type_ As String
    Dim VC_ID_ As String
    Public close_focus_obj As TXT
    'Cell(Head/VC_Type/VC_No)
    Private Sub Acc_Group_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text
        VC_Type_ = Link_Valu(1)
        VC_ID_ = Link_Valu(2)

        BG_frm.HADE_TXT.Text = "Account Group"
        BG_frm.TYP_TXT.Text = VC_Type_

        If From_Access(BG_frm.HADE_TXT.Text, BG_frm.TYP_TXT.Text) = False Then
            Me.Dispose()
            Cell("Not Access", BG_frm.HADE_TXT.Text & $"({BG_frm.TYP_TXT.Text})")
            Exit Sub
        End If



        Load_data_source()
        List_set()
        Set_msg()



        If VC_Type_ = "Display" Or VC_Type_ = "Display_Close" Then
            Display_Fill_All()
            Me.Enabled = False
        ElseIf VC_Type_ = "Alter" Then
            Me.Enabled = True
            Display_Fill_All()
        ElseIf VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then

        End If

        If Name_TXT.Enabled = True Then
            Name_TXT.Focus()
        Else
            Alias_TXT.Focus()
        End If

        Button_Manage()
        NOT_Clear()
        Add_Hander_Remove_Handel(True)
    End Sub
    Dim ag_list As List_frm
    Private Function List_set()
        ag_list = New List_frm
        List_Setup("List of Account Groups", Select_List.Right_Dock, Select_List_Format.Defolt, Group_TXT, ag_list, BindingSource1, 320)

    End Function
    Dim msg_Name As Msg_frm
    Dim msg_alias As Msg_frm
    Private Function Set_msg()
        msg_Name = New Msg_frm
        Name_TXT.Msg_Object = msg_Name

        msg_alias = New Msg_frm
        Alias_TXT.Msg_Object = msg_alias
    End Function
    Private Function Load_data_source()
        Dim cn As New SQLiteConnection
        Dim dt As New DataTable
        dt.Columns.Add("Name")
        dt.Columns.Add("Under Group")
        dt.Columns.Add("ID")

        Dim dr As DataRow

        If open_MSSQL_Cstm(Database_File.cre, cn) Then
            cmd = New SQLiteCommand("Select ID,Name,(Select [Name] From TBL_Acc_Group agg where agg.ID = ag.UserGroup) as Under_Group From TBL_Acc_Group ag where Company = 'All'", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                dr = dt.NewRow
                dr("ID") = r("ID")
                dr("Name") = r("Name")
                dr("Under Group") = r("Under_Group")
                dt.Rows.Add(dr)
            End While
            r.Close()
        End If
        cn.Close()

        BindingSource1.DataSource = dt
    End Function
    Private Function Button_Manage()
        Button_Clear()
        BG_frm.B_1.Text = "&E : Exit"
        BG_frm.B_2.Text = "&S : Save"

        If VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close" Then
            BG_frm.B_3.Text = "&D : Delete"
        End If

        If Login_Type = "Admin Account" And (VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close") Then
            BG_frm.B_4.Text = "|&O : Audit"
        End If
    End Function
    Private Function Add_Hander_Remove_Handel(Ans As Boolean)
        If Ans = True Then
            AddHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            AddHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
            AddHandler BG_frm.B_3.Click, AddressOf Me.B_3_Click

            If Login_Type = "Admin Account" And (VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close") Then
                AddHandler BG_frm.B_4.Click, AddressOf Me.B_5_Click
            End If
        Else
            RemoveHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            RemoveHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
            RemoveHandler BG_frm.B_3.Click, AddressOf Me.B_3_Click

            If Login_Type = "Admin Account" And (VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close") Then
                RemoveHandler BG_frm.B_4.Click, AddressOf Me.B_5_Click
            End If
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
    Private Sub B_5_Click(sender As Object, e As EventArgs)
        If BG_frm.HADE_TXT.Text = "Account Group" Then
            Cell("Audit Analysis", "", "Account Group", VC_ID_)
        End If
    End Sub
    Private Function Delete_Data()
        Dim cn As New SQLiteConnection
        open_MSSQL_Cstm(Database_File.cre, cn)

        If Chack_Delete_Allow() = True Then
            If Msg_Delete_YN(Name_TXT, "Acc. Group") = DialogResult.Yes Then
                If Insurt_Audit() = True Then
                    cmd = New SQLiteCommand($"DELETE FROM TBL_Acc_Group Where ID = '{VC_ID_}'", cn)
                    cmd.ExecuteNonQuery()
                    Clear_all()
                End If
            End If
        Else
            Msg(NOT_Type.Info, "You cannot delete", "You cannot delete this account group because the account group you selected is already in use")
        End If
    End Function
    Private Function Chack_Delete_Allow() As Boolean
        Dim isavalable As Boolean = True
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select count(*) as count, 'Ledger Under' as Type From TBL_VC vc where 
(vc.Ledger = '{VC_ID_}') and 
vc.Visible = 'Approval'

UNION ALL

Select count(*), 'Defolt Ledger' as Type From TBL_Acc_Group ag WHERE
ag.id = '{VC_ID_}' and
ag.Company = 'All'", cn)

            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                If Val(r("count")) <> 0 Then
                    If isavalable = True Then
                        isavalable = False
                    End If
                End If
            End While
        End If

        Return isavalable
    End Function
    Private Function Save_Data()
        If BG_frm.From_ID = From_ID Then
            If Save_Requr() = True Then
                If Insurt_Audit() = True Then
                    If Insurt_Value() = True Then
                        If Insurt_Ledger_Coomunicatuio() = True Then
                            Clear_all()
                        End If
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

        If Name_TXT.Text = "" Then
            Msg(NOT_Type.Warning, "Required - Name", Text_Action(vl.Input_Error_Blank, "Name"))
            Name_TXT.Focus()
            Return False
            Exit Function
        End If
        If Name_TXT.Text = Alias_TXT.Text Then
            Msg(NOT_Type.Warning, "Alias is match to name", "Please change (alias) or Name")
            Alias_TXT.Focus()
            Return False
            Exit Function
        End If
        If Chack_Duplicate(Database_File.cre, "TBL_Acc_Group", "Name", Duplicate_Type) = True Then
            Msg(NOT_Type.Warning, "Exists - Name", Text_Action(vl.Already_Exists, "Name"))
            Return False
            Exit Function
        End If

        If Chack_Duplicate(Database_File.cre, "TBL_Acc_Group", "Nickname", Duplicate_Type1) = True Then
            Msg(NOT_Type.Warning, "Exists - Name", Text_Action(vl.Already_Exists, "Name"))
            Return False
            Exit Function
        End If
        ''
        If Chack_Duplicate(Database_File.cre, "TBL_Acc_Group", "Alias", Duplicate_Alias_Type) = True Then
            Msg(NOT_Type.Warning, "Exists - Alias", Text_Action(vl.Already_Exists, "Alias"))
            Return False
            Exit Function
        End If

        If Chack_Duplicate(Database_File.cre, "TBL_Acc_Group", "Alias", Duplicate_Alias_Type1) = True And Alias_TXT.Text <> "" Then
            Msg(NOT_Type.Warning, "Exists - Alias", Text_Action(vl.Already_Exists, "Alias"))
            Return False
            Exit Function
        End If

        If Chack_Duplicate(Database_File.cre, "TBL_Acc_Group", "Name", " Name ='" & Group_TXT.Text & "'") = False And Group_TXT.Text <> "Primary" Then
            Msg(NOT_Type.Warning, "Selection Error - Under Group", Text_Action(vl.Select_Current, "Under Group"))
            Return False
            Exit Function
        Else
            If Group_TXT.Text = "Primary" Then
                Group_TXT.Data_Link_ = 0
            Else
                Group_TXT.Data_Link_ = Find_DT_Value(Database_File.cre, "TBL_Acc_Group", "ID", " Name ='" & Group_TXT.Text & "'")
            End If
        End If

        If Find_DT_Value(Database_File.cre, "TBL_Acc_Group", "Company", "Name = '" & Group_TXT.Text & "'") = "All" Then
            Return True
        End If

        Return True
    End Function
    Private Function Insurt_Audit() As Boolean
        If Val(VC_ID_) = 0 Then
            Return True
        End If
        If Audit_Save("TBL_Acc_Group", "ID", VC_ID_) = True Then
            Return True
        End If
    End Function
    Private Function Insurt_Value() As Boolean
        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            If open_MSSQL(Database_File.cre) = True Then
                qury = "INSERT INTO TBL_Acc_Group (Name, Nickname, UserGroup, HeadGroup,Communication_Whatsapp,Communication_Email, Company, Visible, [User], Date_Install, PC) VALUES (@Name, @Nickname, @UserGroup,@HeadGroup,@w,@e,@Company,@Visible,@User,@Install_,@PC)"
                cmd = New SQLiteCommand(qury, con)
                Try
                    With cmd.Parameters
                        .AddWithValue("@Name", Name_TXT.Text)
                        .AddWithValue("@Nickname", Alias_TXT.Text)
                        .AddWithValue("@UserGroup", Group_TXT.Data_Link_)
                        .AddWithValue("@HeadGroup", Find_DT_Value(Database_File.cre, "TBL_Acc_Group", "UserGroup", "ID = '" & Group_TXT.Data_Link_ & "'").Trim)
                        .AddWithValue("@w", w_yn.Text)
                        .AddWithValue("@e", e_yn.Text)
                        .AddWithValue("@Company", Company_ID_str)
                        .AddWithValue("@User", LOGIN_ID)
                        .AddWithValue("@Install_", CDate(DateTime.Now))
                        .AddWithValue("@PC", PC_ID)
                        .AddWithValue("@Visible", "Approval")
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
                qury = "UPDATE TBL_Acc_Group SET Name = @Name,Nickname = @Nickname,UserGroup = @UserGroup,HeadGroup = @HeadGroup,[User] = @User,Date_Install = @Install_,PC = @PC,Communication_Whatsapp = @w,Communication_Email = @e WHERE ID ='" & VC_ID_ & "'"
                cmd = New SQLiteCommand(qury, con)
                Try
                    With cmd.Parameters
                        .AddWithValue("@Name", Name_TXT.Text.Trim)
                        .AddWithValue("@Nickname", Alias_TXT.Text.Trim)
                        .AddWithValue("@UserGroup", Group_TXT.Data_Link_)
                        .AddWithValue("@HeadGroup", Find_DT_Value(Database_File.cre, "TBL_Acc_Group", "UserGroup", "ID = '" & Group_TXT.Data_Link_ & "'"))
                        .AddWithValue("@w", w_yn.Text)
                        .AddWithValue("@e", e_yn.Text)
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
    Private Function Insurt_Ledger_Coomunicatuio() As Boolean
        Dim cn As New SQLiteConnection

        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"UPDATE TBL_Ledger SET Communication_Whatsapp = '{w_yn.Text}',Communication_Email = '{e_yn.Text}' where [Group] = '{VC_ID_}' and Communication_Type = 'By Group (Default)'", cn)
            cmd.ExecuteNonQuery()
        End If

        Return True
    End Function
    Private Function Clear_all()
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            'BG_frm.Acc_Group_BS.DataSource = Nothing
            'BG_frm.Acc_Group_BS.DataSource = Fill_Acc_Group(cn)
        End If


        If VC_Type_ = "Create" Then
            Name_TXT.Text = ""
            Alias_TXT.Text = ""
            Name_TXT.Focus()
            NOT_("The entry you entered has been successfully accepted", NOT_Type.Success)
        ElseIf VC_Type_ = "Alter_Close" Or VC_Type_ = "Create_Close" Then
            close_focus_obj.Text = Name_TXT.Text
            Me.Dispose()
            close_focus_obj.Focus()
        Else
            Me.Dispose()
        End If
    End Function

    Private Sub Group_TXT_TextChanged(sender As Object, e As EventArgs) Handles Group_TXT.TextChanged
        'BindingSource1.Filter = $""
    End Sub
    Private Sub Acc_Group_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If Msg_Exit_YN("Acc. Group " & VC_Type_) = DialogResult.Yes Then
                Me.Dispose()
                If VC_Type_ = "Alter_Close" Or VC_Type_ = "Create_Close" Then
                    close_focus_obj.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub Acc_Group_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.HADE_TXT.Text = "Account Group"
        BG_frm.TYP_TXT.Text = VC_Type_
        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text

        Button_Clear()
        Button_Manage()
        cfg_fill()
        Name_TXT.Focus()
    End Sub
    Private Function cfg_fill()
        Panel6.Visible = Features_mod.Communication_YN
    End Function
    Private Function Display_Fill_All() As Boolean

        Name_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Acc_Group", "Name", "ID = '" & VC_ID_ & "'")

        Alias_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Acc_Group", "Nickname", "ID = '" & VC_ID_ & "'")

        Group_TXT.Data_Link_ = Find_DT_Value(Database_File.cre, "TBL_Acc_Group", "UserGroup", "ID = '" & VC_ID_ & "'")

        Under = Find_DT_Value(Database_File.cre, "TBL_Acc_Group", "Name", "ID = '" & Group_TXT.Data_Link_ & "'")

        w_yn.Text = Find_DT_Value(Database_File.cre, "TBL_Acc_Group", "Communication_Whatsapp", "ID = '" & VC_ID_ & "'")
        e_yn.Text = Find_DT_Value(Database_File.cre, "TBL_Acc_Group", "Communication_Email", "ID = '" & VC_ID_ & "'")
        Group_TXT.Text = Under

        If Group_TXT.Text = Nothing Then
            Group_TXT.Text = "Primary"
        End If

        If VC_Type_ = "Alter_Close" Or VC_Type_ = "Alter" Then
            If VC_ID_ <= 28 Then
                Name_TXT.Enabled = False
                Group_TXT.Enabled = False
            End If
        End If

        Return True
    End Function
    Dim is_save As Boolean = False
    Private Sub Acc_Group_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End
        Add_Hander_Remove_Handel(False)
        Frm_foCus()
    End Sub

    Private Sub Alias_TXT_Enter(sender As Object, e As EventArgs) Handles Alias_TXT.Enter
        Alias_TXT_TextChanged(e, e)
    End Sub
    Private Sub Alias_TXT_TextChanged(sender As Object, e As EventArgs) Handles Alias_TXT.TextChanged
        Alias_aLlow()
    End Sub
    Private Sub Alias_TXT_LostFocus(sender As Object, e As EventArgs) Handles Alias_TXT.LostFocus
        If Alias_aLlow() = False Then
            Alias_TXT.Focus()
        End If
    End Sub

    Private Sub Name_TXT_LostFocus(sender As Object, e As EventArgs) Handles Name_TXT.LostFocus
        If Name_aLlow() = False Then
            Name_TXT.Focus()
        End If
    End Sub
    Private Sub Name_TXT_Enter(sender As Object, e As EventArgs) Handles Name_TXT.Enter
        Name_aLlow()
    End Sub
    Private Sub Name_TXT_TextChanged(sender As Object, e As EventArgs) Handles Name_TXT.TextChanged
        Name_aLlow()
    End Sub
    Private Function Name_aLlow() As Boolean
        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            Duplicate_Type = " Name = '" & Name_TXT.Text & "' COLLATE NOCASE "
        Else
            Duplicate_Type = " Name = '" & Name_TXT.Text & "' COLLATE NOCASE  and ID <> '" & VC_ID_ & "'"
        End If

        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            Duplicate_Type1 = " Nickname = '" & Name_TXT.Text & "' COLLATE NOCASE "
        Else
            Duplicate_Type1 = " Nickname = '" & Name_TXT.Text & "' COLLATE NOCASE  and ID <> '" & VC_ID_ & "'"
        End If

        If Name_TXT.Text = "" Then
            'NOT_("Not Valid Without a Blank 'Name'", NOT_Type.Warning)
            Return False
            Exit Function
        End If

        If Chack_Duplicate(Database_File.cre, "TBL_Acc_Group", "Name", Duplicate_Type) = True Then
            NOT_("The Name Entered is a 'Duplicate'", NOT_Type.Warning)
            Msg_Duplicat(Name_TXT, "Acc. Group")
            Return False
            Exit Function
        ElseIf Chack_Duplicate(Database_File.cre, "TBL_Acc_Group", "Nickname", Duplicate_Type1) = True Then
            NOT_("The Name Entered is a 'Duplicate'", NOT_Type.Warning)
            Msg_Duplicat(Name_TXT, "Acc. Group")
            Return False
            Exit Function
        Else
            NOT_Clear()
            Return True
        End If
        Return True
    End Function
    Private Function Alias_aLlow() As Boolean
        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            Duplicate_Alias_Type = " Name = '" & Alias_TXT.Text & "' COLLATE NOCASE "
        Else
            Duplicate_Alias_Type = " Name = '" & Alias_TXT.Text & "' COLLATE NOCASE  and ID <> '" & VC_ID_ & "'"
        End If

        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            Duplicate_Alias_Type1 = " Nickname = '" & Alias_TXT.Text & "' COLLATE NOCASE "
        Else
            Duplicate_Alias_Type1 = " Nickname = '" & Alias_TXT.Text & "' COLLATE NOCASE  and ID <> '" & VC_ID_ & "'"
        End If
        If Alias_TXT.Text <> "" Then
            If Name_TXT.Text = Alias_TXT.Text Then
                NOT_("Name and Alias is Sam", NOT_Type.Warning)
                Msg_Duplicat(Alias_TXT, "Alias")
                Return False
                Exit Function
            End If

            If Chack_Duplicate(Database_File.cre, "TBL_Acc_Group", "Nickname", Duplicate_Alias_Type) = True Then
                NOT_("The Alias Entered is a 'Duplicate'", NOT_Type.Warning)
                Msg_Duplicat(Alias_TXT, "Alias")
                Return False
                Exit Function
            ElseIf Chack_Duplicate(Database_File.cre, "TBL_Acc_Group", "Name", Duplicate_Alias_Type1) = True Then
                NOT_("The Alias Entered is a 'Duplicate'", NOT_Type.Warning)
                Msg_Duplicat(Alias_TXT, "Alias")
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
    Private Function Under_aLlow() As Boolean
        '(Name LIKE'<value>%' OR Alias LIKE'<value>%')
        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            Group_TXT.Select_Filter = "Name LIKE '<value>' and Company = 'All'"
        Else
            Group_TXT.Select_Filter = "(ID <> '" & VC_ID_ & "') AND Name LIKE '<value>'"
        End If
    End Function
    Private Sub Txt1_Enter(sender As Object, e As EventArgs) Handles Txt1.Enter
        Dim result As DialogResult = Msg_Save_YN(Name_TXT, "Acc. Group")
        If result = DialogResult.Yes Then
            Save_Data()
        ElseIf result = DialogResult.No Then
            Name_TXT.Focus()
        Else
            SendKeys.Send("{BACKSPACE}")
        End If
    End Sub

    Private Sub Group_TXT_Layout(sender As Object, e As LayoutEventArgs) Handles Group_TXT.Layout

    End Sub

    Private Sub Group_TXT_Enter(sender As Object, e As EventArgs) Handles Group_TXT.Enter
        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            Group_TXT.Select_Filter = "Name LIKE '%<value>%'"
        Else
            Group_TXT.Select_Filter = "(ID <> '" & VC_ID_ & "') AND Name LIKE '%<value>%'"
        End If
    End Sub

    Private Sub w_yn_TextChanged(sender As Object, e As EventArgs) Handles w_yn.TextChanged

    End Sub

    Private Sub Acc_Group_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID

    End Sub
End Class
