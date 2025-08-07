Imports System.Data.SQLite
Imports Tools

Public Class Group_info_Laboratry
    Dim Path_End As String
    Dim VC_Type_ As String
    Dim VC_ID_ As String

    Dim Unit_Type As String
    Dim Unit_A_Type As String

    Public close_focus_obj As TXT
    Private Sub Group_info_Laboratry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Path_End = BG_frm.BG_Path_TXT.Text
        VC_Type_ = Link_Valu(1)
        VC_ID_ = Link_Valu(2)
        data_cfg()

        BG_frm.HADE_TXT.Text = "Group Info"
        BG_frm.TYP_TXT.Text = VC_Type_

        Load_Data()
        List_set()

        If VC_Type_ = "Display" Or VC_Type_ = "Display_Close" Then
            Display_Fill_All()
            Me.Enabled = False
        ElseIf VC_Type_ = "Alter" Then
            Me.Enabled = True
            Display_Fill_All()
        ElseIf VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            Group_List_Laboratry1.Add_New()

        End If

        Button_Manage()
        Add_Hander_Remove_Handel(True)
        Name_TXT.Focus()
    End Sub

    Private Sub Group_info_Laboratry_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.HADE_TXT.Text = "Group Info"
        BG_frm.TYP_TXT.Text = VC_Type_
        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text

        Button_Clear()
        Button_Manage()
        cfg_fill()

        Load_Data()

        Name_TXT.Focus()
    End Sub

    Private Sub Group_info_Laboratry_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If Msg_Exit_YN("Group " & VC_Type_) = DialogResult.Yes Then
                Me.Dispose()
                If VC_Type_ = "Alter_Close" Or VC_Type_ = "Create_Close" Then
                    close_focus_obj.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub Group_info_Laboratry_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End
        Add_Hander_Remove_Handel(False)
        Frm_foCus()
    End Sub
    Private Function data_cfg()
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then

        End If
    End Function
    Private Function Load_Data()
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            Dim dt As New DataTable
            dt.Columns.Add("Name")
            dt.Columns.Add("Alias")
            dt.Columns.Add("ID")
            dt.Rows.Add("End of List", "", "")

            cmd = New SQLiteCommand("Select * From TBL_Stock_Item where " & Company_Visible_Filter, cn)
            Dim r As SQLiteDataReader
            Dim dr As DataRow
            r = cmd.ExecuteReader
            While r.Read
                dr = dt.NewRow
                dr("ID") = r("ID")
                dr("Name") = r("Name")
                dr("Alias") = r("Alias")
                dt.Rows.Add(dr)
            End While
            r.Close()

            Item_Source.DataSource = dt
        End If
    End Function
    Private Function List_set()

    End Function
    Private Function Display_Fill_All()
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select * From TBL_Laboratry_Group where ID = '{VC_ID_}'", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                Name_TXT.Text = r("Name").ToString
                Alias_TXT.Text = r("Alias").ToString
                Rate_TXT.Text = r("Rate").ToString
            End While
            r.Close()

            Group_List_Laboratry1.platform.Controls.Clear()

            cmd = New SQLiteCommand($"Select *,(Select it.Name From TBL_Stock_Item it where it.Id = g.Test_ID) as Test_Name,(Select it.MRP From TBL_Stock_Item it where it.Id = g.Test_ID) as MRP From TBL_Laboratry_Group_List g where g.Group_ID = '{VC_ID_}'", cn)
            r = cmd.ExecuteReader
            While r.Read
                With Group_List_Laboratry1
                    .Add_New()
                    Dim idx As Integer = .platform.Controls.Count - 0

                    .Find_Particuls_ID_LAB(idx).Text = r("Test_ID").ToString
                    .Find_Particuls_TXT(idx).Text = r("Test_Name").ToString
                    .Find_Rate_LAB(idx).Text = r("MRP").ToString
                    .Find_Formula_Label(idx).Text = r("Formula").ToString
                    If r("Formula").ToString.Trim = Nothing Then
                        .Find_Formula_YN(idx).Text = "No"
                        .Find_Formula_Panel(idx).Visible = False
                    Else
                        .Find_Formula_Panel(idx).Visible = True
                        .Find_Formula_YN(idx).Text = "Yes"
                    End If

                End With
            End While
            r.Close()
            If Group_List_Laboratry1.platform.Controls.Count = 0 Then
                Group_List_Laboratry1.Add_New()
            End If
        End If
    End Function
    Private Function Button_Manage()
        Button_Clear()
        BG_frm.B_1.Text = "&E : Exit"
        BG_frm.B_2.Text = "&S : Save"
        If VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close" Then
            BG_frm.B_3.Text = "&D : Delete"
        End If

        If Login_Type = "Admin Account" And (VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close") Then
            'BG_frm.B_4.Text = "|&O : Audit"
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
        If BG_frm.HADE_TXT.Text = "Group Info" Then
            Me.Dispose()
        End If
    End Sub
    Private Sub B_2_Click(sender As Object, e As EventArgs)
        If BG_frm.HADE_TXT.Text = "Group Info" Then
            Save_Data()
        End If
    End Sub
    Private Sub B_3_Click(sender As Object, e As EventArgs)
        If BG_frm.HADE_TXT.Text = "Group Info" Then
            If VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close" Then
                Delete_Data()
            End If
        End If
    End Sub
    Private Function cfg_fill()

    End Function
    Private Function Delete_Data()

    End Function
    Private Function Save_Data()
        If Save_Requr() = True Then
            If Insurt_Value() = True Then
                Clear_all()
            End If
        End If
    End Function
    Private Function Clear_all()
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            'BG_frm.All_Unit_BS.DataSource = Nothing
            'BG_frm.All_Unit_BS.DataSource = Fill_Stock_Item(cn)
        End If

        If VC_Type_ = "Create" Then
            Name_TXT.Text = ""
            Alias_TXT.Text = ""
            Rate_TXT.Text = ""


            Group_List_Laboratry1.platform.Controls.Clear()
            Group_List_Laboratry1.Clear_All_SUM()
            Group_List_Laboratry1.Add_New()

            Name_TXT.Focus()



            NOT_("The entry you entered has been successfully accepted", NOT_Type.Success)
        ElseIf VC_Type_ = "Alter_Close" Or VC_Type_ = "Create_Close" Then
            close_focus_obj.Text = Name_TXT.Text
            Me.Dispose()
            close_focus_obj.Focus()
        ElseIf VC_Type_ = "Alter" Then
            Me.Dispose()
        End If
    End Function
    Private Function Save_Requr() As Boolean
        If Name_TXT.Text = "" Then
            NOT_("Please enter name and try agin", NOT_Type.Erro)
            MsgBox("")
            Name_TXT.Focus()
            Return False
            Exit Function
        End If
        If Name_TXT.Text = Alias_TXT.Text Then
            NOT_("Please change (alias)", NOT_Type.Erro)
            Alias_TXT.Focus()
            Return False
            Exit Function
        End If
        If Chack_Duplicate(Database_File.cre, "TBL_Laboratry_Group", "Name", Duplicate_Type) = True Then
            NOT_("Name already exists please change name and try again", NOT_Type.Erro)
            Name_TXT.Focus()
            Return False
            Exit Function
        End If
        If Chack_Duplicate(Database_File.cre, "TBL_Laboratry_Group", "Alias", Duplicate_Type1) = True Then
            NOT_("Name already exists please change name and try again", NOT_Type.Erro)
            Return False
            Exit Function
        End If

        If Chack_Duplicate(Database_File.cre, "TBL_Laboratry_Group", "Name", Duplicate_Alias_Type) = True Then
            NOT_("Alias already exists please change name and try again", NOT_Type.Erro)
            Return False
            Exit Function
        End If

        If Chack_Duplicate(Database_File.cre, "TBL_Laboratry_Group", "Alias", Duplicate_Alias_Type1) = True And Alias_TXT.Text <> "" Then
            NOT_("Alias already exists please change name and try again", NOT_Type.Erro)
            Return False
            Exit Function
        End If

        For Each bg_p As Panel In Group_List_Laboratry1.platform.Controls.OfType(Of Panel)()
            If Val(Group_List_Laboratry1.Find_Particuls_ID_LAB(Group_List_Laboratry1.Find_Idx(bg_p)).Text.ToString.Trim) = 0 Then
                Group_List_Laboratry1.platform.Controls.Remove(bg_p)
            End If
        Next

        Return True
    End Function
    Private Function Insurt_Value()
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
                Dim qry As String = "INSERT INTO TBL_Laboratry_Group (Name,Alias,Rate,Visible) VALUES (@Name,@Alias,@Rate,@Visible)"
                cmd = New SQLiteCommand(qry, cn)
                Try
                    With cmd.Parameters
                        .AddWithValue("@Name", Name_TXT.Text.Trim)
                        .AddWithValue("@Alias", Alias_TXT.Text.Trim)
                        .AddWithValue("@Rate", Rate_TXT.Text.Trim)
                        .AddWithValue("@Visible", "Approval")
                        cmd.ExecuteNonQuery()
                    End With
                    VC_ID_ = Find_DT_Value(Database_File.cre, "TBL_Laboratry_Group", "ID", $"Name = '{Name_TXT.Text}' and Visible = 'Approval'")
                    List_data_save(cn)
                    Return True
                Catch ex As Exception
                    Msg_Custom_YN(NOT_Location.Bottom_Right, Color.Red, My.Resources.Error_animation_icn, Dialoag_Button.Ok, "Error !", "Data Save Error", ex.Message)
                    Return False
                End Try
            Else
                Dim qry As String = "UPDATE TBL_Laboratry_Group SET Name = @Name,Alias = @Alias,Rate = @Rate WHERE ID = '" & VC_ID_ & "'"
                cmd = New SQLiteCommand(qry, cn)
                Try
                    With cmd.Parameters
                        .AddWithValue("@Name", Name_TXT.Text.Trim)
                        .AddWithValue("@Alias", Alias_TXT.Text.Trim)
                        .AddWithValue("@Rate", Rate_TXT.Text.Trim)
                        cmd.ExecuteNonQuery()
                    End With
                    List_data_save(cn)
                    Return True
                Catch ex As Exception
                    Msg_Custom_YN(NOT_Location.Bottom_Right, Color.Red, My.Resources.Error_animation_icn, Dialoag_Button.Ok, "Error !", "Data Save Error", ex.Message)
                    Return False
                End Try
            End If
        End If
    End Function
    Private Function List_data_save(cn As SQLiteConnection)
        Dim P_ As New Queue(Of Panel)()
        For Each bg_p As Panel In Group_List_Laboratry1.platform.Controls.OfType(Of Panel)()
            P_.Enqueue(bg_p)
        Next

        cmd = New SQLiteCommand($"DELETE FROM TBL_Laboratry_Group_list WHERE Group_ID = '{VC_ID_}';", cn)
        cmd.ExecuteNonQuery()

        Try
            For Each bg_p As Panel In P_.Reverse
                With Group_List_Laboratry1
                    Dim idx As Integer = .Find_Idx(bg_p)
                    Dim test_id As String = .Find_Particuls_ID_LAB(idx).Text
                    Dim formula_ As String = .Find_Formula_Label(idx).Text

                    cmd = New SQLiteCommand($"INSERT INTO TBL_Laboratry_Group_list (Group_ID,Test_ID,Formula) VALUES ('{VC_ID_}','{test_id}','{formula_}')", cn)
                    cmd.ExecuteNonQuery()
                End With
            Next
        Catch ex As Exception
            Msg_Custom_YN(NOT_Location.Bottom_Right, Color.Red, My.Resources.Error_animation_icn, Dialoag_Button.Ok, "Error !", "Data Save Error", ex.Message)
            Return False
        End Try

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

    Dim Duplicate_Type As String
    Dim Duplicate_Type1 As String
    Private Function Name_aLlow() As Boolean
        If BG_frm.HADE_TXT.Text = "Group Info" Then
            If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
                Duplicate_Type = " Name = '" & Name_TXT.Text & "' COLLATE NOCASE and Visible = 'Approval'"
            Else
                Duplicate_Type = " Name = '" & Name_TXT.Text & "' COLLATE NOCASE and ID <> '" & VC_ID_ & "' and Visible = 'Approval'"
            End If

            If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
                Duplicate_Type1 = " Alias = '" & Name_TXT.Text & "' COLLATE NOCASE  and Visible = 'Approval'"
            Else
                Duplicate_Type1 = " Alias = '" & Name_TXT.Text & "' COLLATE NOCASE  and ID <> '" & VC_ID_ & "' and Visible = 'Approval'"
            End If

            If Name_TXT.Text = "" Then
                'NOT_("Not Valid Without a Blank 'Name'", NOT_Type.Warning)
                Return False
                Exit Function
            End If

            If Chack_Duplicate(Database_File.cre, "TBL_Laboratry_Group", "Name", Duplicate_Type) = True Then
                NOT_("The Name Entered is a 'Duplicate'", NOT_Type.Warning)
                Msg_Duplicat(Name_TXT, "Item")
                Return False
                Exit Function
            ElseIf Chack_Duplicate(Database_File.cre, "TBL_Laboratry_Group", "Name", Duplicate_Type1) = True Then
                NOT_("The Name Entered is a 'Duplicate'", NOT_Type.Warning)
                Msg_Duplicat(Name_TXT, "Item")
                Return False
                Exit Function
            Else
                NOT_Clear()
                Return True
            End If
        End If
        Return True
    End Function
    Dim Duplicate_Alias_Type As String
    Dim Duplicate_Alias_Type1 As String

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

    Private Function Alias_aLlow() As Boolean
        If BG_frm.HADE_TXT.Text = "Group Info" Then
            If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
                Duplicate_Alias_Type = " Name  = '" & Alias_TXT.Text & "' COLLATE NOCASE  and Visible = 'Approval'"
            Else
                Duplicate_Alias_Type = " Name  = '" & Alias_TXT.Text & "' COLLATE NOCASE  and ID <> '" & VC_ID_ & "' and Visible = 'Approval'"
            End If

            If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
                Duplicate_Alias_Type1 = " Alias  = '" & Alias_TXT.Text & "' COLLATE NOCASE and Visible = 'Approval'"
            Else
                Duplicate_Alias_Type1 = " Alias  = '" & Alias_TXT.Text & "' COLLATE NOCASE  and ID <> '" & VC_ID_ & "' and Visible = 'Approval'"

            End If
            If Alias_TXT.Text <> "" Then
                If Name_TXT.Text = Alias_TXT.Text Then
                    NOT_("Name and Alias is Sam", NOT_Type.Warning)
                    Msg_Duplicat(Alias_TXT, "Item")
                    Return False
                    Exit Function
                End If

                If Chack_Duplicate(Database_File.cre, "TBL_Laboratry_Group", "Nickname", Duplicate_Alias_Type) = True Then
                    NOT_("The Alias Entered is a 'Duplicate'", NOT_Type.Warning)
                    Msg_Duplicat(Alias_TXT, "Item")
                    Return False
                    Exit Function
                ElseIf Chack_Duplicate(Database_File.cre, "TBL_Laboratry_Group", "Name", Duplicate_Alias_Type1) = True Then
                    NOT_("The Alias Entered is a 'Duplicate'", NOT_Type.Warning)
                    Msg_Duplicat(Alias_TXT, "Item")
                    Return False
                    Exit Function
                Else
                    NOT_Clear()
                    Return True
                End If
            Else
                Return True
            End If
        End If
    End Function

    Private Sub Group_List_Laboratry1_Load(sender As Object, e As EventArgs) Handles Group_List_Laboratry1.Load

    End Sub

    Private Sub Group_List_Laboratry1_Paint(sender As Object, e As PaintEventArgs) Handles Group_List_Laboratry1.Paint
        'obj_center(sender, Panel3)
        'Dim h As Integer = Panel3.Height - 50
        'Group_List_Laboratry1.Size = New Size(500, h)
    End Sub

    Private Sub save_TXT_TextChanged(sender As Object, e As EventArgs) Handles save_TXT.TextChanged

    End Sub

    Private Sub save_TXT_Enter(sender As Object, e As EventArgs) Handles save_TXT.Enter
        Dim result As DialogResult = Msg_Save_YN(Name_TXT, "Group")

        If result = DialogResult.Yes Then
            Save_Data()
        ElseIf result = DialogResult.No Then
            Name_TXT.Focus()
        ElseIf result = DialogResult.Cancel Then
            SendKeys.Send("{BACKSPACE}")
        End If
    End Sub
End Class