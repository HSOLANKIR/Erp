Imports System.Data.SQLite
Imports Tools

Public Class Unit_info_Laboratory
    Dim Path_End As String
    Dim VC_Type_ As String
    Dim VC_ID_ As String

    Public close_focus_obj As TXT
    Private Sub Doctor_info_Laboratory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Path_End = BG_frm.BG_Path_TXT.Text
        VC_Type_ = Link_Valu(1)
        VC_ID_ = Link_Valu(2)
        data_cfg()

        BG_frm.HADE_TXT.Text = "Unit Info."
        BG_frm.TYP_TXT.Text = VC_Type_

        If VC_Type_ = "Display" Or VC_Type_ = "Display_Close" Then
            Display_Fill_All()
            Me.Enabled = False
        ElseIf VC_Type_ = "Alter" Then
            Me.Enabled = True
            Display_Fill_All()
        ElseIf VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then

        End If

        Button_Manage()
        Add_Hander_Remove_Handel(True)
        Symbol_TXT.Focus()
    End Sub

    Private Sub Doctor_info_Laboratory_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.HADE_TXT.Text = "Unit Info."
        BG_frm.TYP_TXT.Text = VC_Type_
        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text

        Button_Clear()
        Button_Manage()
        cfg_fill()

        Symbol_TXT.Focus()
    End Sub
    Private Function data_cfg()
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then

        End If
    End Function
    Private Function cfg_fill()

    End Function
    Private Function Display_Fill_All()
        Symbol_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "Symbol", "ID = '" & VC_ID_ & "'")
        FormalName_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "Formal_Name", "ID = '" & VC_ID_ & "'")
        Deciaml_TXT.Text = Val(Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "Decimal", "ID = '" & VC_ID_ & "'"))


    End Function

    Private Sub Doctor_info_Laboratory_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If Msg_Exit_YN("Unit " & VC_Type_) = DialogResult.Yes Then
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

        If Login_Type = "Admin Account" And (VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close") Then
            'BG_frm.B_4.Text = "|&O : Audit"
        End If
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
        If BG_frm.HADE_TXT.Text = "Unit Info." Then
            Me.Dispose()
        End If
    End Sub
    Private Sub B_2_Click(sender As Object, e As EventArgs)
        If BG_frm.HADE_TXT.Text = "Unit Info." Then
            Save_Data()
        End If
    End Sub
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
            'BG_frm.Ledger_BS.DataSource = Nothing
            'BG_frm.Ledger_BS.DataSource = Fill_Ledger(cn)

        End If

        If VC_Type_ = "Create" Then
            Symbol_TXT.Text = ""
            FormalName_TXT.Text = ""
            Deciaml_TXT.Text = "0"
            Symbol_TXT.Focus()

            NOT_("The entry you entered has been successfully accepted", NOT_Type.Success)
        ElseIf VC_Type_ = "Alter_Close" Or VC_Type_ = "Create_Close" Then
            close_focus_obj.Text = Symbol_TXT.Text
            Me.Dispose()
            close_focus_obj.Focus()
        ElseIf VC_Type_ = "Alter" Then
            Me.Dispose()
        End If
    End Function
    Private Function Insurt_Value() As Boolean
        Dim cn As New SQLiteConnection

        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            Dim q As String = $"INSERT INTO TBL_Inventory_Unit (Type,Symbol,Formal_Name,Decimal,Company,[User],Date_install,Visible,PC) VALUES (@Type,@Symbol,@Formal_Name,@Decimal,@Company,@User,@Install_,@Visible,@PC)"
            If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                Try
                    cmd = New SQLiteCommand(q, cn)
                    With cmd.Parameters
                        .AddWithValue("@Type", "Simple")
                        .AddWithValue("@Symbol", Symbol_TXT.Text.Trim)
                        .AddWithValue("@Formal_Name", FormalName_TXT.Text.Trim)
                        .AddWithValue("@Decimal", Val(Deciaml_TXT.Text.Trim))


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
            Dim q As String = $"UPDATE TBL_Inventory_Unit SET Symbol = @Symbol,Formal_Name = @Formal_Name, Decimal = @Decimal WHERE ID = '{VC_ID_}'"

            Try
                If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                    cmd = New SQLiteCommand(q, cn)
                    With cmd.Parameters
                        .AddWithValue("@Symbol", Symbol_TXT.Text.Trim)
                        .AddWithValue("@Formal_Name", FormalName_TXT.Text.Trim)
                        .AddWithValue("@Decimal", Val(Deciaml_TXT.Text.Trim))
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
        If Symbol_TXT.Text = "" Then
            Msg_Blank(Symbol_TXT, "Symbol")
            Symbol_TXT.Focus()
            Return False
            Exit Function
        End If
        If Chack_Duplicate(Database_File.cre, "TBL_Inventory_Unit", "Symbol", Duplicate_Type) = True Then
            Msg_Duplicat(Symbol_TXT, "Symbol")
            Symbol_TXT.Focus()
            Return False
            Exit Function
        End If

        Return True
    End Function
    Private Sub Symbol_TXT_Enter(sender As Object, e As EventArgs) Handles Symbol_TXT.Enter
        Name_aLlow()
    End Sub
    Private Sub Symbol_TXT_TextChanged(sender As Object, e As EventArgs) Handles Symbol_TXT.TextChanged
        Name_aLlow()
    End Sub
    Private Sub Symbol_TXT_Lost_Focus(sender As Object, e As EventArgs) Handles Symbol_TXT.LostFocus
        If Name_aLlow() = False Then
            Symbol_TXT.Focus()
        End If
    End Sub
    Private Function Name_aLlow() As Boolean
        If BG_frm.HADE_TXT.Text = "Unit Info." Then
            If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
                Duplicate_Type = " Symbol = '" & Symbol_TXT.Text & "' COLLATE NOCASE and " & Company_Visible_Filter
            Else
                Duplicate_Type = " Symbol = '" & Symbol_TXT.Text & "' COLLATE NOCASE and ID <> '" & VC_ID_ & "' and " & Company_Visible_Filter
            End If

            If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
                Duplicate_Type1 = " Formal_Name = '" & Symbol_TXT.Text & "' COLLATE NOCASE  and " & Company_Visible_Filter
            Else
                Duplicate_Type1 = " Formal_Name = '" & Symbol_TXT.Text & "' COLLATE NOCASE  and ID <> '" & VC_ID_ & "' and " & Company_Visible_Filter
            End If

            If Symbol_TXT.Text = "" Then
                'NOT_("Not Valid Without a Blank 'Name'", NOT_Type.Warning)
                Return False
                Exit Function
            End If

            If Chack_Duplicate(Database_File.cre, "TBL_Inventory_Unit", "Symbol", Duplicate_Type) = True Then
                NOT_("The Name Entered is a 'Duplicate'", NOT_Type.Warning)
                Msg_Duplicat(Symbol_TXT, "Unit")
                Return False
                Exit Function
            ElseIf Chack_Duplicate(Database_File.cre, "TBL_Inventory_Unit", "Formal_Name", Duplicate_Type1) = True Then
                NOT_("The Name Entered is a 'Duplicate'", NOT_Type.Warning)
                Msg_Duplicat(Symbol_TXT, "Unit")
                Return False
                Exit Function
            Else
                NOT_Clear()
                Return True
            End If
        End If
        Return True
    End Function
    Private Sub Txt2_KeyDown(sender As Object, e As KeyEventArgs) Handles Deciaml_TXT.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim result As DialogResult = Msg_Save_YN(Symbol_TXT, "Unit")

            If result = DialogResult.Yes Then
                Save_Data()
            ElseIf result = DialogResult.No Then
                'Symbol_TXT.Focus()
            ElseIf result = DialogResult.Cancel Then
                'SendKeys.Send("{BACKSPACE}")
            End If
        End If
    End Sub
End Class