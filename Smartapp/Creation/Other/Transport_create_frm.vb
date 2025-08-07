Imports System.Data.SqlClient
Imports System.Data.SQLite
Imports Tools

Public Class Transport_create_frm
    Dim From_ID As String
    Dim Under_ID As String
    Dim Under As String
    Dim Path_End As String
    Dim VC_Type_ As String
    Dim VC_ID_ As String

    Public close_focus_obj As TXT
    Public close_link_yn As Boolean
    Private Sub Transport_create_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text
        VC_Type_ = Link_Valu(1)
        VC_ID_ = Link_Valu(2)

        BG_frm.HADE_TXT.Text = "Transport"
        BG_frm.TYP_TXT.Text = VC_Type_

        If VC_Type_ = "Display" Or VC_Type_ = "Display_Close" Then
            Display_Fill_All()
            Me.Enabled = False
        ElseIf VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close" Then
            Me.Enabled = True
            Display_Fill_All()
        ElseIf VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
        End If


        Button_Manage()
        NOT_Clear()
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
        If BG_frm.From_ID = From_ID Then
            Save_Data()
        End If
    End Sub
    Private Sub B_3_Click(sender As Object, e As EventArgs)
        If VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close" Then
            If BG_frm.From_ID = From_ID Then
                Delete_Data()
            End If
        End If
    End Sub


    Private Function Display_Fill_All()
        Name_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Tranport", "Name", "ID = '" & VC_ID_ & "'")
        Phone_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Tranport", "Phone", "ID = '" & VC_ID_ & "'")
        Vehicle_Type.Text = Find_DT_Value(Database_File.cre, "TBL_Tranport", "Vehicle_Type", "ID = '" & VC_ID_ & "'")
        Vehicle_No.Text = Find_DT_Value(Database_File.cre, "TBL_Tranport", "Vehicle_No", "ID = '" & VC_ID_ & "'")
    End Function

    Private Sub Transport_create_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.HADE_TXT.Text = "Transport"
        BG_frm.TYP_TXT.Text = VC_Type_
        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text

        Button_Clear()
        Button_Manage()
        Name_TXT.Focus()
    End Sub

    Private Sub Transport_create_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If Msg_Exit_YN("Transportation " & VC_Type_) = DialogResult.Yes Then
                Me.Dispose()
                If VC_Type_ = "Alter_Close" Or VC_Type_ = "Create_Close" Then
                    close_focus_obj.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub Transport_create_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End
        Add_Hander_Remove_Handel(False)
        List_frm.Dispose()
        Frm_foCus()
    End Sub
    Private Function Delete_Data()
        Dim cn As New SQLiteConnection
        open_MSSQL_Cstm(Database_File.cre, cn)


        If Chack_Delete_Allow() = True Then
            If Msg_Delete_YN(Name_TXT, "Transport") = DialogResult.Yes Then
                If Insurt_Audit() = True Then
                    If open_MSSQL(Database_File.cre) = True Then
                        qury = $"DELETE FROM TBL_Tranport Where ID = '{VC_ID_}';"
                        cmd = New SQLiteCommand(qury, cn)
                        cmd.ExecuteNonQuery()
                        Clear_all()
                    End If
                End If
            End If
        Else
            Msg(NOT_Type.Info, "You cannot delete", "You cannot delete this ledger because the ledger you selected is made up of vouchers")
        End If
    End Function
    Private Function Chack_Delete_Allow() As Boolean
        Dim isavalable As Boolean = True
        Return isavalable
    End Function
    Private Function Insurt_Audit() As Boolean
        If Val(VC_ID_) = 0 Then
            Return True
        End If

        If Audit_Save("TBL_Tranport", "ID", VC_ID_) = True Then
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
            Duplicate_Type = " Name = '" & Name_TXT.Text & "' COLLATE NOCASE"
        ElseIf VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close" Then
            Duplicate_Type = " Name = '" & Name_TXT.Text & "' COLLATE NOCASE and ID <> '" & VC_ID_ & "'"
        End If

        '
        If Name_TXT.Text = "" Then
            Msg(NOT_Type.Warning, "Required - Name", Text_Action(vl.Input_Error_Blank, "Name"))
            Name_TXT.Focus()
            Return False
            Exit Function
        End If
        If Chack_Duplicate(Database_File.cre, "TBL_Tranport", "Name", Duplicate_Type) = True Then
            Msg(NOT_Type.Warning, "Exists - Name", Text_Action(vl.Already_Exists, "Name"))
            Return False
            Exit Function
        End If
        Return True
    End Function
    Private Function Insurt_Value() As Boolean
        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            Dim cn As New SQLiteConnection
            If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                qury = "INSERT INTO TBL_Tranport (Name,Phone,Vehicle_Type,Vehicle_No,Company,Visible,[User],Date_Install,PC) VALUES (@Name,@Phone,@Vehicle_Type,@Vehicle_No,@Company,@Visible,@User,@Install_,@PC)"
                cmd = New SQLiteCommand(qury, cn)
                Try
                    With cmd.Parameters
                        .AddWithValue("@Name", Name_TXT.Text.Trim)
                        .AddWithValue("@Phone", Phone_TXT.Text.Trim)
                        .AddWithValue("@Vehicle_Type", Vehicle_Type.Text.Trim)
                        .AddWithValue("@Vehicle_No", Vehicle_No.Text.Trim)
                        .AddWithValue("@Company", Company_ID_str)
                        .AddWithValue("@User", LOGIN_ID)
                        .AddWithValue("@Install_", CDate(DateTime.Now))
                        .AddWithValue("@PC", PC_ID.Trim)
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
            Dim cn As New SQLiteConnection
            If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                qury = "UPDATE TBL_Tranport SET Name = @Name,Phone = @Phone,Vehicle_Type = @Vehicle_Type,Vehicle_No = @Vehicle_No,[User] = @User,Date_Install = @Install_,PC = @PC WHERE ID = '" & VC_ID_ & "'"
                cmd = New SQLiteCommand(qury, cn)
                Try
                    With cmd.Parameters
                        .AddWithValue("@Name", Name_TXT.Text.Trim)
                        .AddWithValue("@Phone", Phone_TXT.Text.Trim)
                        .AddWithValue("@Vehicle_Type", Vehicle_Type.Text.Trim)
                        .AddWithValue("@Vehicle_No", Vehicle_No.Text.Trim)
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
            'BG_frm.Transport_BS.DataSource = Nothing
            'BG_frm.Transport_BS.DataSource = Fill_Transport(cn)
        End If
        If VC_Type_ = "Create" Then
            Name_TXT.Text = ""
            Phone_TXT.Text = ""
            Vehicle_Type.Text = ""
            Vehicle_No.Text = ""
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

    Private Sub Vehicle_Type_TextChanged(sender As Object, e As EventArgs) Handles Vehicle_Type.TextChanged

    End Sub

    Private Sub Save_TXT_TextChanged(sender As Object, e As EventArgs) Handles Save_TXT.TextChanged

    End Sub

    Private Sub Save_TXT_Enter(sender As Object, e As EventArgs) Handles Save_TXT.Enter
        Dim result As DialogResult = Msg_Save_YN(Name_TXT, "Transportation")

        If result = DialogResult.Yes Then
            Save_Data()
        ElseIf result = DialogResult.No Then
            Name_TXT.Focus()
        ElseIf result = DialogResult.Cancel Then
            SendKeys.Send("{BACKSPACE}")
        End If
    End Sub

    Private Sub Transport_create_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
    End Sub
End Class