Imports System.Data.SQLite
Imports Tools
Public Class Vouchers_Laboratry_frm
    Dim Path_End As String
    Dim VC_Type_ As String
    Dim VC_ID_ As String

    Dim Unit_Type As String
    Dim Unit_A_Type As String

    Public close_focus_obj As TXT


    Dim Dr_ID As String
    Private Sub Vouchers_Laboratry_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Path_End = BG_frm.BG_Path_TXT.Text
        VC_Type_ = Link_Valu(1)
        VC_ID_ = Link_Valu(2)

        BG_frm.HADE_TXT.Text = "Laboratry Vouchers"
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

        End If

        Button_Manage()
        Add_Hander_Remove_Handel(True)
        Date_TXT.Focus()

    End Sub

    Private Sub Vouchers_Laboratry_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.HADE_TXT.Text = "Laboratry Vouchers"
        BG_frm.TYP_TXT.Text = VC_Type_
        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text

        Button_Clear()
        Button_Manage()
        cfg_fill()

        Load_Data()

        Date_TXT.Focus()
    End Sub

    Private Sub Vouchers_Laboratry_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If Msg_Exit_YN("Laboratry Vouchers " & VC_Type_) = DialogResult.Yes Then
                Me.Dispose()
                If VC_Type_ = "Alter_Close" Or VC_Type_ = "Create_Close" Then
                    close_focus_obj.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub Vouchers_Laboratry_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End
        Add_Hander_Remove_Handel(False)
        Frm_foCus()
    End Sub
    Private Function Load_Data()
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            Dim dt As New DataTable
            dt.Columns.Add("Name")
            dt.Columns.Add("Alias")
            dt.Columns.Add("ID")
            dt.Columns.Add("Phone")
            dt.Rows.Add("Self", "", "", "")

            cmd = New SQLiteCommand("Select * From TBL_Ledger ld where LD.Visible = 'Approval' and ld.[Group] = (Select g.ID From TBL_Acc_Group g where g.Name = 'Doctor')", cn)
            Dim r As SQLiteDataReader
            Dim dr As DataRow
            r = cmd.ExecuteReader
            While r.Read
                dr = dt.NewRow
                dr("ID") = r("ID")
                dr("Name") = r("Name")
                dr("Alias") = r("Alise")
                dr("Phone") = r("Phone")
                dt.Rows.Add(dr)
            End While
            r.Close()
            Doctor_Source.DataSource = dt


            dt = New DataTable
            dt.Columns.Add("Name")
            dt.Columns.Add("Alias")
            dt.Columns.Add("ID")
            dt.Columns.Add("Phone")
            dt.Columns.Add("Email")
            dt.Rows.Add("Create New", "", "", "")

            cmd = New SQLiteCommand("Select * From TBL_Ledger ld where LD.Visible = 'Approval' and ld.[Group] = (Select g.ID From TBL_Acc_Group g where g.Name = 'Sundry Debtors')", cn)
            r = cmd.ExecuteReader
            While r.Read
                dr = dt.NewRow
                dr("ID") = r("ID")
                dr("Name") = r("Name")
                dr("Alias") = r("Alias")
                dr("Phone") = r("Phone")
                dr("Email") = r("Email")
                dt.Rows.Add(dr)
            End While
            r.Close()
            Patient_Source.DataSource = dt
        End If
    End Function
    Dim dr_list As List_frm
    Dim cr_list As List_frm
    Private Function List_set()
        dr_list = New List_frm
        List_Setup("List of Doctor", Select_List.Right, Select_List_Format.Defolt, Dr_TXT, dr_list, Doctor_Source, 320, {"Create|Alt + C", "Alter|Ctrl + Enter"})

        cr_list = New List_frm
        List_Setup("List of Patient", Select_List.Botom, Select_List_Format.Custome, Cr_TXT, cr_list, Patient_Source, 400, {"Create|Alt + C", "Alter|Ctrl + Enter"})

    End Function

    Private Function Display_Fill_All()

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
        If BG_frm.HADE_TXT.Text = "Laboratry Vouchers" Then
            Me.Dispose()
        End If
    End Sub
    Private Sub B_2_Click(sender As Object, e As EventArgs)
        If BG_frm.HADE_TXT.Text = "Laboratry Vouchers" Then
            Save_Data()
        End If
    End Sub
    Private Sub B_3_Click(sender As Object, e As EventArgs)
        If BG_frm.HADE_TXT.Text = "Laboratry Vouchers" Then
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

    End Function
    Private Function Clear_all()

    End Function

    Private Sub Dr_TXT_TextChanged(sender As Object, e As EventArgs) Handles Dr_TXT.TextChanged

    End Sub

    Private Sub Dr_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles Dr_TXT.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dr_ID = dr_list.List_Grid.CurrentRow.Cells(2).Value
        End If

        If e.KeyCode = Keys.C AndAlso e.Modifiers = Keys.Alt Then
            Cell("Doctor Info", "", "Create_Close", "")
            Doctor_info_Laboratory.close_focus_obj = sender
        ElseIf e.KeyCode = Keys.Enter AndAlso e.Modifiers = Keys.Control Then
            Cell("Doctor Info", "", "Alter_Close", Dr_ID)
            Doctor_info_Laboratory.close_focus_obj = sender
        End If
    End Sub

    Private Sub Txt1_TextChanged(sender As Object, e As EventArgs) Handles Cr_TXT.TextChanged

    End Sub
End Class