Imports System.Data.SqlClient
Imports System.Data.SQLite

Public Class Voucher_Md_frm
    Dim From_ID As String
    Dim Path_End As String
    Public VC_Type_ As String
    Public VC_ID_ As String

    Private Sub Voucher_Md_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text

        VC_Type_ = Link_Valu(1)
        VC_ID_ = Link_Valu(2)



        BG_frm.HADE_TXT.Text = "Voucher"
        BG_frm.TYP_TXT.Text = VC_Type_

        Fill_()
        Fill_Bindingsource()
        List_set()
        Set_msg()


        If VC_Type_ = "Display" Or VC_Type_ = "Display_Close" Then
            Type_TXT.Enabled = False
        ElseIf VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close" Then
            Type_TXT.Enabled = False
        ElseIf VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            Type_TXT.Enabled = True
        End If

        Name_TXT.Focus()
        Button_Manage()
        Add_Hander_Remove_Handel(True)
        Name_TXT.Focus()
    End Sub
    Private Function Fill_()
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select * From TBL_Voucher_Create where id = '{VC_ID_}'", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                Name_TXT.Text = r("Name").ToString
                Alias_TXT.Text = r("Alias").ToString
                Type_TXT.Text = r("Under").ToString
                Txt1.Text = r("Voucher_No_Method").ToString
                Prefix_TXT.Text = r("Voucher_No_Prefix").ToString
                Suffix_TXT.Text = r("Voucher_No_Suffix").ToString
                Txt2.Text = Val(r("Voucher_Start").ToString)
            End While
            r.Close()
        End If
        cn.Close()

        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select count(*) as C From TBL_VC vc where vc.Voucher_Type_ID = '{VC_ID_}' and vc.Visible = 'Approval'", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                If Val(r("C").ToString) = 0 Then
                    Panel6.Enabled = True
                Else
                    Panel6.Enabled = False
                End If
            End While
            r.Close()
        End If

    End Function
    Private Sub Voucher_Md_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End

        BG_frm.HADE_TXT.Text = "Voucher"
        BG_frm.TYP_TXT.Text = VC_Type_
        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text
        Button_Clear()
        Button_Manage()
    End Sub

    Private Sub Voucher_Md_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If Msg_Exit_YN("Voucher " & VC_Type_) = DialogResult.Yes Then
                Me.Dispose()
                If VC_Type_ = "Alter_Close" Or VC_Type_ = "Create_Close" Then
                    'close_focus_obj.Focus()
                End If
            End If
        End If
    End Sub
    Private Sub Voucher_Md_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End
        Add_Hander_Remove_Handel(False)
        Frm_foCus()
    End Sub
    'Button_Managment------------------------------------------------------------------------
    Private Function Button_Manage()
        Button_Clear()
        BG_frm.B_1.Text = "&S : Save"
        If VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close" Then
            BG_frm.B_2.Text = "&D : Delete"
        End If
    End Function
    Private Function Add_Hander_Remove_Handel(Ans As Boolean)
        If Ans = True Then
            AddHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            AddHandler BG_frm.B_2.Click, AddressOf Me.B_3_Click
        Else
            RemoveHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            RemoveHandler BG_frm.B_2.Click, AddressOf Me.B_3_Click
        End If
    End Function
    Private Sub B_3_Click(sender As Object, e As EventArgs)
        If VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close" Then
            If BG_frm.From_ID = From_ID Then
                Delete_Data()
            End If
        End If
    End Sub

    Private Function Delete_Data() As Boolean
        Dim cn As New SQLiteConnection
        open_MSSQL_Cstm(Database_File.cre, cn)

        If Delect_Chack() = True Then
            If Msg_Delete_YN(Name_TXT, "Voucher") = DialogResult.Yes Then
                If Insurt_Audit() = True Then
                    If open_MSSQL(Database_File.cre) = True Then
                        qury = $"DELETE FROM TBL_Voucher_Create Where ID = '{VC_ID_}';
"
                        cmd = New SQLiteCommand(qury, cn)
                        cmd.ExecuteNonQuery()
                        Clear_all()
                    End If
                End If
            End If
        Else
            Msg(NOT_Type.Info, "You cannot delete", "You cannot delete this account group because the account group you selected is already in use")
        End If
    End Function
    Private Function Delect_Chack() As Boolean
        Dim isavalable As Boolean = True
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select count(*) as count, 'Vouchers' as Type From TBL_VC vc where 
(vc.Voucher_Type_ID = '{VC_ID_}') and 
vc.Visible = 'Approval'

UNION ALL

Select count(*), 'Defolt Vouchers' as Type From TBL_Voucher_Create vc WHERE
vc.id = '{VC_ID_}' and
vc.Company = 'All'", cn)

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
    Private Sub B_1_Click(sender As Object, e As EventArgs)
        Save_Data()
    End Sub
    Private Function Insurt_Audit() As Boolean
        If Val(VC_ID_) = 0 Then
            Return True
        End If

        If Audit_Save("TBL_Voucher_Create", "ID", VC_ID_) = True Then
            Return True
        End If
    End Function
    'Focus Managment---------------------------------------------------------------------------
    'Other Details and managment proccess--------------------------------------------------------------
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
            Duplicate_Type = " Name = '" & Name_TXT.Text & "' and Visible = 'Approval' and " & Company_Visible_Filter()
        Else
            Duplicate_Type = " Name = '" & Name_TXT.Text & "' and ID <> '" & VC_ID_ & "' and Visible = 'Approval' and " & Company_Visible_Filter()
        End If
        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            Duplicate_Type1 = "Alias = '" & Alias_TXT.Text & "' and Visible = 'Approval' and " & Company_Visible_Filter()
        Else
            Duplicate_Type1 = " Alias = '" & Alias_TXT.Text & "' and ID <> '" & VC_ID_ & "' and Visible = 'Approval' and " & Company_Visible_Filter()
        End If

        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            Duplicate_Alias_Type = "Name = '" & Alias_TXT.Text & "' and Visible = 'Approval' and " & Company_Visible_Filter()
        Else
            Duplicate_Alias_Type = "Name = '" & Alias_TXT.Text & "' and ID <> '" & VC_ID_ & "' and Visible = 'Approval' and " & Company_Visible_Filter()
        End If
        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            Duplicate_Alias_Type1 = "Alias = '" & Alias_TXT.Text & "' and Visible = 'Approval' and " & Company_Visible_Filter()
        Else
            Duplicate_Alias_Type1 = "Alias = '" & Alias_TXT.Text & "' and ID <> '" & VC_ID_ & "' and Visible = 'Approval' and " & Company_Visible_Filter()
        End If

        If Name_TXT.Text = "" Then
            NOT_("Input Error : Name | Please enter name and try again", NOT_Type.Warning)
            Name_TXT.Focus()
            Return False
            Exit Function
        End If
        If Name_TXT.Text = Alias_TXT.Text Then
            MessageBox.Show("Please change (alias)", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            NOT_("Duplicate : Alas | Please change alias and try again", NOT_Type.Warning)
            Alias_TXT.Focus()
            Return False
            Exit Function
        End If
        If Chack_Duplicate(Database_File.cre, "TBL_Voucher_Create", "Name", Duplicate_Type) = True Then
            NOT_("Duplicate : Name | Name already exists please change name and try again", NOT_Type.Warning)
            Name_TXT.Focus()
            Return False
            Exit Function
        End If
        If Chack_Duplicate(Database_File.cre, "TBL_Voucher_Create", "Alias", Duplicate_Type1) = True And Alias_TXT.Text <> "" Then
            MessageBox.Show("Name already exists please change name and try again", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            NOT_("Duplicate : Alias | Alias already exists please change Alias and try again", NOT_Type.Warning)
            Return False
            Exit Function
        End If

        If Chack_Duplicate(Database_File.cre, "TBL_Voucher_Create", "Name", Duplicate_Alias_Type) = True Then
            MessageBox.Show("Alias already exists please change name and try again", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            NOT_("Duplicate : Name | Name already exists please change name and try again", NOT_Type.Warning)

            Name_TXT.Focus()
            Return False
            Exit Function
        End If
        If Chack_Duplicate(Database_File.cre, "TBL_Voucher_Create", "Alias", Duplicate_Alias_Type1) = True And Alias_TXT.Text <> "" Then
            NOT_("Duplicate : Alias | Alias already exists please change Alias and try again", NOT_Type.Warning)
            Return False
            Exit Function
        End If

        If Val(Txt2.Text = 0) Then
            Txt2.Text = 1
        End If
        Return True
    End Function
    Private Function Insurt_Value() As Boolean
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
                qury = "INSERT INTO TBL_Voucher_Create (Name,Alias,Under,Voucher_No_Method,Voucher_Start,Voucher_No_Prefix,Voucher_No_Suffix,Company,Visible) VALUES (@Name,@Alias,@Under,@Voucher_No_Method,@Voucher_Start,@Voucher_No_Prefix,@Voucher_No_Suffix,@Company,@Visible)"
            Else
                qury = $"UPDATE TBL_Voucher_Create SET Name = @Name,Alias = @Alias,Under = @Under,Voucher_No_Method = @Voucher_No_Method,Voucher_Start = @Voucher_Start,Voucher_No_Prefix = @Voucher_No_Prefix,Voucher_No_Suffix = @Voucher_No_Suffix,Company = @Company,Visible = @Visible where id = {VC_ID_}"
            End If

            cmd = New SQLiteCommand(qury, cn)

            Try
                With cmd.Parameters
                    .AddWithValue("@Name", Name_TXT.Text.Trim)
                    .AddWithValue("@Alias", Alias_TXT.Text.Trim)
                    .AddWithValue("@Under", Type_TXT.Text.Trim)
                    .AddWithValue("@Voucher_No_Method", Txt1.Text.Trim)
                    .AddWithValue("@Voucher_No_Prefix", Prefix_TXT.Text.Trim)
                    .AddWithValue("@Voucher_No_Suffix", Suffix_TXT.Text.Trim)
                    .AddWithValue("@Voucher_Start", Val(Txt2.Text))
                    .AddWithValue("@Company", Company_ID_str)
                    .AddWithValue("@Visible", "Approval")

                    cmd.ExecuteReader()
                End With
            Catch ex As Exception
                Msg(NOT_Type.Erro, "Data Save Error", ex.Message)
                Return False
            End Try
        End If

        Return ctrl.Save_Data(Name_TXT.Text)
    End Function
    Private Function Clear_all()
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            'BG_frm.Godown_BS.DataSource = Nothing
            'BG_frm.Godown_BS.DataSource = Fill_Godown(cn)

            'BG_frm.Voucher_BS.DataSource = Nothing
            'BG_frm.Voucher_BS.DataSource = Fill_Vouchhers(cn)
        End If

        Name_TXT.Text = ""
        Alias_TXT.Text = ""
        Prefix_TXT.Text = ""
        Suffix_TXT.Text = ""
        Txt2.Text = "0"
        If VC_Type_ = "Create" Then
            Name_TXT.Focus()
            NOT_("The entry you entered has been successfully accepted", NOT_Type.Success)
        Else
            Me.Dispose()
        End If
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
    '
    Private Function Name_aLlow() As Boolean
        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            Duplicate_Type = " Name = '" & Name_TXT.Text & "' COLLATE NOCASE"
        Else
            Duplicate_Type = " Name = '" & Name_TXT.Text & "' COLLATE NOCASE and ID <> '" & VC_ID_ & "'"
        End If

        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            Duplicate_Type1 = " Alias = '" & Name_TXT.Text & "'"
        Else
            Duplicate_Type1 = " Alias = '" & Name_TXT.Text & "' COLLATE NOCASE and ID <> '" & VC_ID_ & "'"
        End If

        If Name_TXT.Text = "" Then
            'NOT_("Not Valid Without a Blank 'Name'", NOT_Type.Warning)
            Return False
            Exit Function
        End If

        If Chack_Duplicate(Database_File.cre, "TBL_Voucher_Create", "Name", Duplicate_Type) = True Then
            NOT_("The Name Entered is a 'Duplicate'", NOT_Type.Warning)
            Msg_Duplicat(Name_TXT, "Voucher Name")
            Return False
            Exit Function
        ElseIf Chack_Duplicate(Database_File.cre, "TBL_Voucher_Create", "Alias", Duplicate_Type1) = True Then
            NOT_("The Name Entered is a 'Duplicate'", NOT_Type.Warning)
            Msg_Duplicat(Name_TXT, "Voucher Name")
            Return False
            Exit Function
        Else
            NOT_Clear()
            Return True
        End If
        Return True
    End Function
    Private Function Alisa_aLlow() As Boolean
        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            Duplicate_Alias_Type = " Name = '" & Alias_TXT.Text & "' COLLATE NOCASE"
        Else
            Duplicate_Alias_Type = " Name = '" & Alias_TXT.Text & "' COLLATE NOCASE and ID <> '" & VC_ID_ & "'"
        End If

        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            Duplicate_Alias_Type1 = " Alias = '" & Alias_TXT.Text & "' COLLATE NOCASE"
        Else
            Duplicate_Alias_Type1 = " Alias = '" & Alias_TXT.Text & "' COLLATE NOCASE and ID <> '" & VC_ID_ & "'"
        End If
        If Alias_TXT.Text <> "" Then
            If Name_TXT.Text = Alias_TXT.Text Then
                NOT_("Name and Alias is Sam", NOT_Type.Warning)
                Msg_Duplicat(Alias_TXT, "Alias")
                Return False
                Exit Function
            End If

            If Chack_Duplicate(Database_File.cre, "TBL_Voucher_Create", "Alias", Duplicate_Alias_Type) = True Then
                NOT_("The Alias Entered is a 'Duplicate'", NOT_Type.Warning)
                Msg_Duplicat(Alias_TXT, "Alias")

                Return False
                Exit Function
            ElseIf Chack_Duplicate(Database_File.cre, "TBL_Voucher_Create", "Name", Duplicate_Alias_Type1) = True Then
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
    Private Sub Alias_TXT_Enter(sender As Object, e As EventArgs) Handles Alias_TXT.Enter
        Alisa_aLlow()
    End Sub
    Private Sub Alias_TXT_TextChanged(sender As Object, e As EventArgs) Handles Alias_TXT.TextChanged
        Alisa_aLlow()
    End Sub
    Private Sub Alias_TXT_Lost_Focus(sender As Object, e As EventArgs) Handles Alias_TXT.LostFocus
        If Alisa_aLlow() = False Then
            Alias_TXT.Focus()
        End If
    End Sub
    Dim msg_Name As Msg_frm
    Dim msg_alias As Msg_frm
    Private Function Set_msg()
        msg_Name = New Msg_frm
        Name_TXT.Msg_Object = msg_Name

        msg_alias = New Msg_frm
        Alias_TXT.Msg_Object = msg_alias
    End Function
    Dim vc_list As List_frm
    Dim no_list As List_frm
    Private Function List_set()
        vc_list = New List_frm
        List_Setup("List of Vouchers Type", Select_List.Right_Dock, Select_List_Format.Singel, Type_TXT, vc_list, BindingSource1, 200)

        no_list = New List_frm
        List_Setup("Vouchers No Type", Select_List.Botom, Select_List_Format.Singel, Txt1, no_list, BindingSource2, Txt1.Width)
    End Function
    Private Function Fill_Bindingsource()
        Dim dt As New DataTable
        dt.Columns.Add("Name")
        dt.Columns.Add("Type")
        dt.Columns.Add("ID")

        dt.Rows.Add("Attendance")
        dt.Rows.Add("Contra")
        dt.Rows.Add("Credit Note")
        dt.Rows.Add("Debit Note")
        dt.Rows.Add("Delivery Note")
        'dt.Rows.Add("Job Work In Order")
        'dt.Rows.Add("Job Work Out Order")
        dt.Rows.Add("Journal")
        'dt.Rows.Add("Material In")
        'dt.Rows.Add("Material Out")
        'dt.Rows.Add("Memorandum")
        dt.Rows.Add("Payment")
        dt.Rows.Add("Payroll")
        'dt.Rows.Add("Physical Stock")
        dt.Rows.Add("Purchase")
        dt.Rows.Add("Purchase Order")
        dt.Rows.Add("Purchase Return")
        dt.Rows.Add("Receipt")
        dt.Rows.Add("Receipt Note")
        'dt.Rows.Add("Rejections In")
        'dt.Rows.Add("Rejections Out")
        'dt.Rows.Add("Reversing Journal")
        dt.Rows.Add("Sales")
        dt.Rows.Add("Sales Order")
        dt.Rows.Add("Sales Return")
        dt.Rows.Add("Stock Journal")
        dt.Rows.Add("Inward Register")
        dt.Rows.Add("Outward Register")

        BindingSource1.DataSource = dt


        Dim dt_no As New DataTable
        dt_no.Columns.Add("Name")
        dt_no.Rows.Add("Automatitic")
        dt_no.Rows.Add("Automatic (Manual Override)")
        dt_no.Rows.Add("Manual")
        dt_no.Rows.Add("Custom")
        BindingSource2.DataSource = dt_no

    End Function

    Private Sub Txt1_TextChanged(sender As Object, e As EventArgs) Handles Type_TXT.TextChanged
        Setup_VC()
        'ctrl.print_head_txt.Text = Type_TXT.Text
    End Sub
    Private Sub Txt1_LostFocus(sender As Object, e As EventArgs) Handles Type_TXT.LostFocus
    End Sub
    Private Function Setup_VC()
        If Type_TXT.Text = "Payment" Or Type_TXT.Text = "Receipt" Or Type_TXT.Text = "Contra" Or Type_TXT.Text = "Journal" Then
            ctrl_manage(cprj)
        ElseIf Type_TXT.Text = "Purchase" Or Type_TXT.Text = "Purchase Order" Or Type_TXT.Text = "Sales" Or Type_TXT.Text = "Sales Order" Or Type_TXT.Text = "Sales Return" Or Type_TXT.Text = "Purchase Return" Or Type_TXT.Text = "Inward Register" Or Type_TXT.Text = "Outward Register" Or Type_TXT.Text = "Credit Note" Or Type_TXT.Text = "Debit Note" Then
            ctrl_manage(Sp_voucher_create_ctrl1)
        ElseIf Type_TXT.Text = "Stock Journal" Then
            ctrl_manage(Stock_journal_create_ctrl1)
        ElseIf Type_TXT.Text = "Attendance" Or Type_TXT.Text = "Payroll" Then
            ctrl_manage(Payroll)
        End If
    End Function
    Dim ctrl As Object
    Private Function ctrl_manage(pan As Object)
        cprj.Visible = False
        Payroll.Visible = False
        Sp_voucher_create_ctrl1.Visible = False
        Stock_journal_create_ctrl1.Visible = False

        ctrl = pan
        With ctrl
            .Dock = DockStyle.Fill
            .VC_Formate_ = Type_TXT.Text
            .VC_ID_ = VC_ID_
            .VC_Type_ = VC_Type_
            .Visible = True
            .Fill_data()
            '.List_set()
        End With
    End Function
    Private Sub Prefix_TXT_LostFocus(sender As Object, e As EventArgs) Handles Prefix_TXT.LostFocus
        If find_Duplicate_prifax() = True Then
            NOT_("Prefix is Duplicate", NOT_Type.Warning)
            Prefix_TXT.Focus()
        End If
    End Sub
    Private Sub Prefix_TXT_TextChanged(sender As Object, e As EventArgs) Handles Prefix_TXT.TextChanged
        If find_Duplicate_prifax() = True Then
            NOT_("Prefix is Duplicate", NOT_Type.Warning)
        End If
    End Sub
    Private Function find_Duplicate_prifax() As Boolean
        NOT_Clear()
        Dim txt As String = ""
        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            txt = $" Voucher_No_Prefix = '{Prefix_TXT.Text}' and Voucher_No_Method = 'Custom'"
        Else
            txt = $" Voucher_No_Prefix = '{Prefix_TXT.Text}' and Voucher_No_Method = 'Custom' and id <> '{VC_ID_}'"
        End If
        Return Chack_Duplicate(Database_File.cre, "TBL_Voucher_Create", "", txt)
    End Function

    Private Sub Txt1_TextChanged_1(sender As Object, e As EventArgs) Handles Txt1.TextChanged
        If Txt1.Text = "Custom" Then
            With TableLayoutPanel1
                .GetControlFromPosition(0, 0).Visible = True
                .GetControlFromPosition(0, 1).Visible = True

                .GetControlFromPosition(2, 0).Visible = True
                .GetControlFromPosition(2, 1).Visible = True
            End With
        Else
            With TableLayoutPanel1
                .GetControlFromPosition(0, 0).Visible = False
                .GetControlFromPosition(0, 1).Visible = False

                .GetControlFromPosition(2, 0).Visible = False
                .GetControlFromPosition(2, 1).Visible = False
            End With
        End If
    End Sub

    Private Sub Suffix_TXT_TextChanged(sender As Object, e As EventArgs) Handles Suffix_TXT.TextChanged

    End Sub

    Private Sub Save_TXT_TextChanged(sender As Object, e As EventArgs) Handles Save_TXT.TextChanged

    End Sub

    Private Sub Save_TXT_Enter(sender As Object, e As EventArgs) Handles Save_TXT.Enter
        Dim result As DialogResult = Msg_Save_YN(Name_TXT, "Vouchers")

        If result = DialogResult.Yes Then
            Save_Data()
        ElseIf result = DialogResult.No Then
            Name_TXT.Focus()
        ElseIf result = DialogResult.Cancel Then
            SendKeys.Send("{BACKSPACE}")
        End If
    End Sub

    Private Sub cprj_Load(sender As Object, e As EventArgs) Handles cprj.Load

    End Sub

    Private Sub Label18_Click(sender As Object, e As EventArgs) Handles Label18.Click

    End Sub

    Private Sub Txt2_TextChanged(sender As Object, e As EventArgs) Handles Txt2.TextChanged

    End Sub

    Private Sub Txt2_LostFocus(sender As Object, e As EventArgs) Handles Txt2.LostFocus
        Txt2.Text = Value_Decimal_set(Txt2.Text, 0)
    End Sub

    Private Sub Voucher_Md_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
    End Sub
End Class