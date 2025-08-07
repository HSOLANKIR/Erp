Imports System.Data.SqlClient
Imports System.Data.SQLite
Imports System.IO
Imports Tools

Public Class Stock_Category_frm
    Dim From_ID As String

    Dim Under_ID As String
    Dim Under As String
    Dim Path_End As String
    Dim VC_Type_ As String
    Dim VC_ID_ As String
    Public close_focus_obj As TXT
    Private Sub Inventory_Category_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID


        Path_End = BG_frm.BG_Path_TXT.Text

        VC_Type_ = Link_Valu(1)
        VC_ID_ = Link_Valu(2)

        BG_frm.HADE_TXT.Text = "Stock Category"
        BG_frm.TYP_TXT.Text = VC_Type_
        If VC_Type_ = "Display" Or VC_Type_ = "Display_Close" Then
            Me.Enabled = False
            Display_Fill_All()
        ElseIf VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close" Then
            Me.Enabled = True
            Display_Fill_All()
        ElseIf VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then

        End If
        Name_TXT.Focus()

        Button_Manage()
        Add_Hander_Remove_Handel(True)
        Name_TXT.Focus()
    End Sub
    Private Function Button_Manage()
        Button_Clear()
        BG_frm.B_1.Text = "&E : Exit"
        BG_frm.B_2.Text = "&S : Save"
        If VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close" Then
            BG_frm.B_3.Text = "&D : Delete"
        End If
        If Login_Type = "Admin Account" And (VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close") Then
            BG_frm.B_5.Text = "|&O : Audit"
        End If
    End Function
    Private Function Add_Hander_Remove_Handel(Ans As Boolean)
        If Ans = True Then
            AddHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            AddHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
            AddHandler BG_frm.B_3.Click, AddressOf Me.B_3_Click
            If Login_Type = "Admin Account" And (VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close") Then
                AddHandler BG_frm.B_5.Click, AddressOf Me.B_5_Click
            End If
        Else
            RemoveHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            RemoveHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
            RemoveHandler BG_frm.B_3.Click, AddressOf Me.B_3_Click
            If Login_Type = "Admin Account" And (VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close") Then
                AddHandler BG_frm.B_5.Click, AddressOf Me.B_5_Click
            End If
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
    Private Sub B_5_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Cell("Audit Analysis", "", "Stock Category", VC_ID_)
        End If
    End Sub
    Private Function Insurt_Audit() As Boolean
        If Val(VC_ID_) = 0 Then
            Return True
        End If

        If Audit_Save("TBL_Stock_Category", "ID", VC_ID_) = True Then
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
    Private Function Delete_Data()
        If Chack_Delete_Allow() = True Then
            If Msg_Yn("Are you soure", "You really want to delete the Category") = DialogResult.Yes Then
                If Insurt_Audit() = True Then
                    qury = "UPDATE TBL_Stock_Category SET Visible = @Visible,[User] = @User,Date_Install = @Install_,PC = @PC WHERE ID  = '" & VC_ID_ & "'"
                    cmd = New SQLiteCommand(qury, con)
                    With cmd.Parameters
                        .AddWithValue("@Visible", "Delete")
                        .AddWithValue("@User", LOGIN_ID.Trim)
                        .AddWithValue("@PC", PC_ID.Trim)
                        .AddWithValue("@Install_", CDate(DateTime.Now))
                        cmd.ExecuteNonQuery()
                    End With
                    Clear_all()
                End If
            End If
        Else
            Msg(NOT_Type.Info, "You cannot delete", "You cannot delete this Category because the Category you selected is made up of vouchers")
        End If
    End Function

    Private Sub Inventory_Category_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.HADE_TXT.Text = "Stock Category"
        BG_frm.TYP_TXT.Text = VC_Type_

        If VC_Type_ = "Display" Or VC_Type_ = "Display_Close" Then
            Me.Enabled = False
        ElseIf VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close" Then
            Me.Enabled = True
        ElseIf VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then

        End If
        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text
        Button_Clear()
        Button_Manage()
        Name_TXT.Focus()
    End Sub
    Dim Duplicate_Type As String
    Dim Duplicate_Type1 As String

    Dim Duplicate_Alias_Type As String
    Dim Duplicate_Alias_Type1 As String
    Private Function Save_Requr() As Boolean
        If Name_TXT.Text = "" Then
            Msg(NOT_Type.Erro, "Input Error - Name", Text_Action(vl.Input_Error_Blank, "Name"))
            Name_TXT.Focus()
            Return False
            Exit Function
        End If
        If Name_TXT.Text = Alias_TXT.Text Then
            Msg(NOT_Type.Erro, "Name and Alias are the same", "Please change (alias)")
            Alias_TXT.Focus()
            Return False
            Exit Function
        End If
        If Chack_Duplicate(Database_File.cre, "TBL_Stock_Category", "Name", Duplicate_Type) = True Then
            Msg(NOT_Type.Erro, "Duplicate - Name", Text_Action(vl.Already_Exists, "Name"))
            Name_TXT.Focus()
            Return False
            Exit Function
        End If
        If Chack_Duplicate(Database_File.cre, "TBL_Stock_Category", "Nickname", Duplicate_Type1) = True Then
            Msg(NOT_Type.Erro, "Duplicate - Name", Text_Action(vl.Already_Exists, "Name"))
            Return False
            Exit Function
        End If

        If Chack_Duplicate(Database_File.cre, "TBL_Stock_Category", "Alias", Duplicate_Alias_Type) = True Then
            Msg(NOT_Type.Erro, "Duplicate - Alias", Text_Action(vl.Already_Exists, "Alias"))
            Return False
            Exit Function
        End If

        If Chack_Duplicate(Database_File.cre, "TBL_Stock_Category", "Alias", Duplicate_Alias_Type1) = True And Alias_TXT.Text <> "" Then
            Msg(NOT_Type.Erro, "Duplicate - Alias", Text_Action(vl.Already_Exists, "Alias"))
            Return False
            Exit Function
        End If
        Return True
    End Function
    Private Function Chack_Delete_Allow() As Boolean

        Return True
    End Function


    Private Sub Inventory_Category_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If Close_Box(Me) = True Then
                Me.Dispose()
                If VC_Type_ = "Alter_Close" Or VC_Type_ = "Create_Close" Then
                    close_focus_obj.Focus()
                End If
            End If
        End If
    End Sub
    Private Function Insurt_Value() As Boolean
        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            If open_MSSQL(Database_File.cre) Then
                qury = "INSERT INTO TBL_Stock_Category (Name,Nickname,Company,[User],Date_install,Visible,PC) VALUES (@Name, @Nickname,@Company,@User,@Install_,@Visible,@PC)"
                cmd = New SQLiteCommand(qury, con)
                Try
                    With cmd.Parameters
                        .AddWithValue("@Name", Name_TXT.Text.Trim)
                        .AddWithValue("@Nickname", Alias_TXT.Text.Trim)
                        .AddWithValue("@Company", Company_ID_str)
                        .AddWithValue("@User", LOGIN_ID)
                        .AddWithValue("@PC", PC_ID.Trim)
                        .AddWithValue("@Install_", CDate(DateTime.Now))
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
            If open_MSSQL(Database_File.cre) = True Then
                qury = "UPDATE TBL_Stock_Category SET Name = @Name,Nickname = @Nickname,[User] = @User,Date_install = @Install_,PC = @PC WHERE ID = '" & VC_ID_ & "'"
                cmd = New SQLiteCommand(qury, con)
                Try
                    With cmd.Parameters
                        .AddWithValue("@Name", Name_TXT.Text.Trim)
                        .AddWithValue("@Nickname", Alias_TXT.Text.Trim)
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
            'BG_frm.Stock_Category_BS.DataSource = Nothing
            'BG_frm.Stock_Category_BS.DataSource = Fill_Stock_Category(cn)
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

    Private Sub Inventory_Category_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End
        Add_Hander_Remove_Handel(False)
        List_frm.Dispose()
        Frm_foCus()
    End Sub
    Private Function Display_Fill_All()
        Name_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Stock_Category", "Name", "ID = '" & VC_ID_ & "'")

        Alias_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Stock_Category", "Nickname", "ID = '" & VC_ID_ & "'")

    End Function
    Private Function Name_aLlow() As Boolean
        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            Duplicate_Type = " Name  = '" & Name_TXT.Text & "' COLLATE NOCASE  and " & Company_Visible_Filter()
        Else
            Duplicate_Type = " Name  = '" & Name_TXT.Text & "' COLLATE NOCASE  and ID <> '" & VC_ID_ & "' and " & Company_Visible_Filter()
        End If

        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            Duplicate_Type1 = " Nickname  = '" & Name_TXT.Text & "' COLLATE NOCASE  and " & Company_Visible_Filter()
        Else
            Duplicate_Type1 = " Nickname  = '" & Name_TXT.Text & "' COLLATE NOCASE  and ID <> '" & VC_ID_ & "' and " & Company_Visible_Filter()
        End If

        If Name_TXT.Text = "" Then
            NOT_("Not Valid Without a Blank 'Name'", NOT_Type.Warning)
            Return False
            Exit Function
        End If

        If Chack_Duplicate(Database_File.cre, "TBL_Stock_Category", "Name", Duplicate_Type) = True Then
            NOT_("The Name Entered is a 'Duplicate'", NOT_Type.Warning)
            Return False
            Exit Function
        ElseIf Chack_Duplicate(Database_File.cre, "TBL_Stock_Category", "Nickname", Duplicate_Type1) = True Then
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
    Private Function Alisa_aLlow() As Boolean
        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            Duplicate_Alias_Type = " Name  = '" & Alias_TXT.Text & "' COLLATE NOCASE "
        Else
            Duplicate_Alias_Type = " Name  = '" & Alias_TXT.Text & "' COLLATE NOCASE  and ID <> '" & VC_ID_ & "'"
        End If

        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            Duplicate_Alias_Type1 = " Nickname  = '" & Alias_TXT.Text & "' COLLATE NOCASE "
        Else
            Duplicate_Alias_Type1 = " Nickname  = '" & Alias_TXT.Text & "' COLLATE NOCASE  and ID <> '" & VC_ID_ & "'"

        End If
        If Alias_TXT.Text <> "" Then
            If Name_TXT.Text = Alias_TXT.Text Then
                NOT_("Name and Alias is Sam", NOT_Type.Warning)
                Return False
                Exit Function
            End If

            If Chack_Duplicate(Database_File.cre, "TBL_Stock_Category", "Nickname", Duplicate_Alias_Type) = True Then
                NOT_("The Alias Entered is a 'Duplicate'", NOT_Type.Warning)
                Return False
                Exit Function
            ElseIf Chack_Duplicate(Database_File.cre, "TBL_Stock_Category", "Name", Duplicate_Alias_Type1) = True Then
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

    Private Sub end_TXT_Enter(sender As Object, e As EventArgs) Handles end_TXT.Enter
        Dim res As DialogResult = Msg_Save_YN(Name_TXT, "Stock Category")
        If res = DialogResult.Yes Then
            Save_Data()
        ElseIf res = DialogResult.Yes Then
            Name_TXT.Focus()
        ElseIf res = DialogResult.Cancel Then
            SendKeys.Send("{BACKSPACE}")
        End If
    End Sub

    Private Sub Stock_Category_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
    End Sub
End Class