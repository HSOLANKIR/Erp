Imports System.Data.SQLite
Imports Tools

Public Class Doctor_info_Laboratory
    Dim Path_End As String
    Dim VC_Type_ As String
    Dim VC_ID_ As String

    Public close_focus_obj As TXT
    Private Sub Doctor_info_Laboratory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Path_End = BG_frm.BG_Path_TXT.Text
        VC_Type_ = Link_Valu(1)
        VC_ID_ = Link_Valu(2)
        data_cfg()

        BG_frm.HADE_TXT.Text = "Doctor Info."
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
        Add_Hander_Remove_Handel(True)
        Name_TXT.Focus()
    End Sub

    Private Sub Doctor_info_Laboratory_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.HADE_TXT.Text = "Doctor Info."
        BG_frm.TYP_TXT.Text = VC_Type_
        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text

        Button_Clear()
        Button_Manage()
        cfg_fill()

        Label7.Text = "Attach Files : " & DataGridView1.Rows.Count

        Name_TXT.Focus()
    End Sub
    Private Function data_cfg()
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            Try
                cmd = New SQLiteCommand("ALTER TABLE [TBL_Ledger] ADD [Ref_P] TEXT;", cn)
                cmd.ExecuteNonQuery()
            Catch ex As Exception

            End Try
            If Chack_Duplicate(Database_File.cre, "TBL_Acc_Group", "Name", "Name = 'Doctor'") = False Then
                cmd = New SQLiteCommand($"INSERT INTO TBL_Acc_Group (Name, UserGroup, Company, Visible) VALUES ('Doctor', '22', '{Company_ID_str}','Approval')", cn)
                cmd.ExecuteNonQuery()
            End If
        End If
    End Function
    Private Function cfg_fill()

    End Function
    Private Function Display_Fill_All()
        Name_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Name", "ID = '" & VC_ID_ & "'")
        Alias_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Alise", "ID = '" & VC_ID_ & "'")
        Phone_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Phone", "ID = '" & VC_ID_ & "'")
        Email_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Email", "ID = '" & VC_ID_ & "'")
        Txt2.Text = Val(Find_DT_Value(Database_File.cre, "TBL_Ledger", "Ref_P", "ID = '" & VC_ID_ & "'"))


    End Function

    Private Sub Doctor_info_Laboratory_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If Msg_Exit_YN("Doctor " & VC_Type_) = DialogResult.Yes Then
                Me.Dispose()
                If VC_Type_ = "Alter_Close" Or VC_Type_ = "Create_Close" Then
                    close_focus_obj.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub Doctor_info_Laboratory_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
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
        BG_frm.B_4.Text = "&T : Attach"

        If Login_Type = "Admin Account" And (VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close") Then
            'BG_frm.B_4.Text = "|&O : Audit"
        End If
    End Function
    Private Function Add_Hander_Remove_Handel(Ans As Boolean)
        If Ans = True Then
            AddHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            AddHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
            AddHandler BG_frm.B_4.Click, AddressOf Me.B_4_Click
        Else
            RemoveHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            RemoveHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
            RemoveHandler BG_frm.B_4.Click, AddressOf Me.B_4_Click
        End If
    End Function
    Private Sub B_1_Click(sender As Object, e As EventArgs)
        If BG_frm.HADE_TXT.Text = "Doctor Info." Then
            Me.Dispose()
        End If
    End Sub
    Private Sub B_2_Click(sender As Object, e As EventArgs)
        If BG_frm.HADE_TXT.Text = "Doctor Info." Then
            Save_Data()
        End If
    End Sub

    Private Sub B_4_Click(sender As Object, e As EventArgs)
        If BG_frm.HADE_TXT.Text = "Doctor Info." Then
            Attage_cre_frm.Grid = Me.DataGridView1
            attage_display.Grid_ = DataGridView1

            Cell("Attach Display")
        End If
    End Sub


    Private Function Fill_Attage()
        If open_MSSQL(Database_File.rec) = True Then
            DataGridView1.Rows.Clear()
            qury = "Select * From TBL_Attage where TBL = 'Ledger' and TBL_ID = '" & VC_ID_ & "' and Visible = 'Approval'"
            cmd = New SQLiteCommand(qury, con)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                DataGridView1.Rows.Add(r("ID"), r("Name"), r("Narration"), r("Attage_Type"), r("Attage"), r("Password"))
            End While
        End If
    End Function
    Private Function Save_Data()
        If Save_Requr() = True Then
            If Insurt_Value() = True Then
                If Document_Save() = True Then
                    Clear_all()
                End If
            End If
        End If
    End Function
    Private Function Clear_all()
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            'BG_frm.Ledger_BS.DataSource = Nothing
            'BG_frm.Ledger_BS.DataSource = Fill_Ledger(cn)

        End If

        If VC_Type_ = "Create" Then
            Name_TXT.Text = ""
            Alias_TXT.Text = ""
            Name_TXT.Focus()
            NOT_("The entry you entered has been successfully accepted", NOT_Type.Success)
            DataGridView1.Rows.Clear()
        ElseIf VC_Type_ = "Alter_Close" Or VC_Type_ = "Create_Close" Then
            close_focus_obj.Text = Name_TXT.Text
            Me.Dispose()
            close_focus_obj.Focus()
        ElseIf VC_Type_ = "Alter" Then
            Me.Dispose()
        End If
    End Function
    Private Function Document_Save() As Boolean
        If open_MSSQL(Database_File.rec) = True Then
            qury = "INSERT INTO TBL_Attage (Name,Narration,TBL,TBL_ID,Attage,Attage_Type,Password,[User],Date_install,PC,Visible) VALUES (@Name,@Narration,@TBL,@TBL_ID,@Attage,@Attage_Type,@Password,@User,@Install_,@PC,@Visible)"
            For i As Integer = 0 To DataGridView1.Rows.Count - 1
                Dim ro As DataGridViewRow = DataGridView1.Rows(i)
                If ro.Cells(0).Value = "0" Then
                    cmd = New SQLiteCommand(qury, con)
                    Dim Byt As Byte()
                    Byt = DirectCast(ro.Cells(4).Value, Byte())
                    Try
                        With cmd.Parameters
                            .AddWithValue("@Name", ro.Cells(1).Value)
                            .AddWithValue("@Narration", ro.Cells(2).Value)
                            .AddWithValue("@TBL", "Ledger")
                            .AddWithValue("@TBL_ID", Find_DT_Value(Database_File.cre, "TBL_Ledger", "ID", "Name = '" & Name_TXT.Text & "'"))
                            .AddWithValue("@Attage", Byt)
                            .AddWithValue("@Attage_Type", ro.Cells(3).Value)
                            .AddWithValue("@Password", ro.Cells(5).Value)
                            .AddWithValue("@User", LOGIN_ID)
                            .AddWithValue("@Install_", CDate(DateTime.Now))
                            .AddWithValue("@PC", PC_ID.Trim)
                            .AddWithValue("@Visible", "Approval")
                            cmd.ExecuteNonQuery()
                        End With
                    Catch ex As Exception
                        Msg(NOT_Type.Erro, "Data Save Error", ex.Message)
                        Return False
                    End Try
                End If
            Next
        End If
        Return True
    End Function
    Private Function Insurt_Value() As Boolean
        Dim cn As New SQLiteConnection

        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            Dim q As String = $"INSERT INTO TBL_Ledger (Name,Alise,[Group],Phone,Email,Ref_P,Visible,Company,[User],Date_install,PC) VALUES (@Name,@Alise,(Select ag.ID From TBL_Acc_Group ag where ag.Name = 'Doctor' and ag.Visible = 'Approval'),@Phone,@Email,@RefP,'Approval','{Company_ID_str.Trim}','{LOGIN_ID}',@install_,'{PC_ID}')"
            If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                Try
                    cmd = New SQLiteCommand(q, cn)
                    With cmd.Parameters
                        .AddWithValue("@Name", Name_TXT.Text.Trim)
                        .AddWithValue("@Alise", Alias_TXT.Text.Trim)

                        .AddWithValue("@Phone", Phone_TXT.Text.Trim)
                        .AddWithValue("@RefP", Val(Txt2.Text))
                        .AddWithValue("@Email", Email_TXT.Text.Trim)
                        .AddWithValue("@install_", CDate(DateTime.Now))

                        cmd.ExecuteNonQuery()
                    End With
                    Return True
                Catch ex As Exception
                    Msg(NOT_Type.Erro, "Data Save Error", ex.Message)
                    Return False
                End Try
            End If
        Else
            Dim q As String = $"UPDATE TBL_Ledger SET Name = @Name,Alise = @Alise,Phone = @Phone,Email = @Email,Ref_P = @RefP WHERE ID = '{VC_ID_}'"

            Try
                If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                    cmd = New SQLiteCommand(q, cn)
                    With cmd.Parameters
                        .AddWithValue("@Name", Name_TXT.Text.Trim)
                        .AddWithValue("@Alise", Alias_TXT.Text.Trim)
                        .AddWithValue("@Phone", Phone_TXT.Text.Trim)
                        .AddWithValue("@Email", Email_TXT.Text.Trim)
                        .AddWithValue("@RefP", Val(Txt2.Text))
                        cmd.ExecuteNonQuery()
                    End With
                    Return True
                End If
            Catch ex As Exception
                Msg(NOT_Type.Erro, "Data Save Error", ex.Message)
                    Return False
                End Try

            End If

    End Function
    Dim Duplicate_Type As String
    Dim Duplicate_Type1 As String

    Private Function Save_Requr() As Boolean
        If Name_TXT.Text = "" Then
            Msg_Blank(Name_TXT, "Doctor Name")
            Name_TXT.Focus()
            Return False
            Exit Function
        End If
        If Chack_Duplicate(Database_File.cre, "TBL_Ledger", "Name", Duplicate_Type) = True Then
            Msg_Duplicat(Name_TXT, "Doctor Name")
            Name_TXT.Focus()
            Return False
            Exit Function
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
    Private Function Name_aLlow() As Boolean
        If BG_frm.HADE_TXT.Text = "Doctor Info." Then
            If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
                Duplicate_Type = " Name = '" & Name_TXT.Text & "' COLLATE NOCASE and " & Company_Visible_Filter
            Else
                Duplicate_Type = " Name = '" & Name_TXT.Text & "' COLLATE NOCASE and ID <> '" & VC_ID_ & "' and " & Company_Visible_Filter
            End If

            If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
                Duplicate_Type1 = " Alise = '" & Name_TXT.Text & "' COLLATE NOCASE  and " & Company_Visible_Filter
            Else
                Duplicate_Type1 = " Alise = '" & Name_TXT.Text & "' COLLATE NOCASE  and ID <> '" & VC_ID_ & "' and " & Company_Visible_Filter
            End If

            If Name_TXT.Text = "" Then
                'NOT_("Not Valid Without a Blank 'Name'", NOT_Type.Warning)
                Return False
                Exit Function
            End If

            If Chack_Duplicate(Database_File.cre, "TBL_Ledger", "Name", Duplicate_Type) = True Then
                NOT_("The Name Entered is a 'Duplicate'", NOT_Type.Warning)
                Msg_Duplicat(Name_TXT, "Ledger")
                Return False
                Exit Function
            ElseIf Chack_Duplicate(Database_File.cre, "TBL_Ledger", "Alise", Duplicate_Type1) = True Then
                NOT_("The Name Entered is a 'Duplicate'", NOT_Type.Warning)
                Msg_Duplicat(Name_TXT, "Ledger")
                Return False
                Exit Function
            Else
                NOT_Clear()
                Return True
            End If
        End If
        Return True
    End Function
    Private Sub Txt2_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt2.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim result As DialogResult = Msg_Save_YN(Name_TXT, "Doctor")

            If result = DialogResult.Yes Then
                Save_Data()
            ElseIf result = DialogResult.No Then
                'Name_TXT.Focus()
            ElseIf result = DialogResult.Cancel Then
                'SendKeys.Send("{BACKSPACE}")
            End If
        End If
    End Sub
End Class