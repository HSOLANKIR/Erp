Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Data.SQLite
Imports MS.Internal

Public Class cmp_cfg_bg_frm
    Dim Path_End As String
    Private Sub cmp_cfg_bg_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Path_End = BG_frm.BG_Path_TXT.Text
        BG_frm.HADE_TXT.Text = "Company Fetchers"
        BG_frm.TYP_TXT.Text = "Alter"



        Load_Background.RunWorkerAsync()
        'LoadBox("Load Data", "Please wait... Load Features Data", My.Resources.Save_animation_icn, Load_Background)

    End Sub

    Private Sub cmp_cfg_bg_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        Path_End = BG_frm.BG_Path_TXT.Text
        BG_frm.HADE_TXT.Text = "Company Fetchers"
        BG_frm.TYP_TXT.Text = "Alter"
        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text
        Button_Manage()
        Add_Hander_Remove_Handel(True)

    End Sub
    Private Function Button_Manage()
        Button_Clear()
        BG_frm.B_1.Text = "&E : Exit"
        BG_frm.B_2.Text = "&S : Save"
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
        If BG_frm.HADE_TXT.Text = "Company Fetchers" Then
            Me.Dispose()
        End If
    End Sub
    Private Sub B_2_Click(sender As Object, e As EventArgs)
        If BG_frm.HADE_TXT.Text = "Company Fetchers" Then
            Save_All()
        End If
    End Sub
    Private Sub cmp_cfg_bg_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Dim all_ = GetAllControls(Panel15).OfType(Of Features_Manu_ctrl)().ToList()

        all_.FindAll(Function(i)
                         If i.Visible = True Then
                             If e.KeyCode = i.Shortcut_ Then
                                 i.CLick_()
                             End If
                         End If
                     End Function)

        If e.KeyCode = Keys.Escape Then
            If Msg_Exit_YN("Company Fetchers") = DialogResult.Yes Then
                Me.Dispose()
            End If
        End If
    End Sub
    Private Function Save_All()
        Dim all_ = GetAllControls(Panel15).OfType(Of Features_Manu_ctrl)().ToList()

        General_Menu.Object_.Save_()
        Account_Menu.Object_.Save_()
        Inventory_Menu.Object_.Save_()
        Payroll_Menu.Object_.Save_()
        Backup_Menu.Object_.Save_()
        Device_Manu.Object_.Save_()
        Communication_Manu.Object_.Save_()

        Me.Dispose()
        Try

            'all_.FindAll(Function(i)
            '                 'If i.Object_ <> Nothing Then
            '                 i.Object_.Save_()
            '                 'End If
            '             End Function)
        Catch ex As Exception

        End Try
    End Function
    Private Sub cmp_cfg_bg_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End
        Add_Hander_Remove_Handel(False)
        Frm_foCus()
    End Sub

    Public Function Save_(Head As String, Vlu As String, Type As String)
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cmp, cn) = True Then
            cmd = New SQLiteCommand("UPDATE TBL_Features SET Value = '" & Vlu & "' where Head = '" & Head & "' and Type = '" & Type & "'", cn)
            cmd.ExecuteNonQuery()
            cn.Close()
        End If
    End Function

    Private Sub bg_Paint(sender As Object, e As PaintEventArgs) Handles bg.Paint
        obj_center(sender, Panel16)
    End Sub
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles Load_Background.DoWork
        General_Menu.Object_ = New General_Features_ctrl
        General_Menu.Object_.Load_()

        Account_Menu.Object_ = New Account_Features_ctrl
        Account_Menu.Object_.Load_()

        Inventory_Menu.Object_ = New Inventory_Features_ctrl
        Inventory_Menu.Object_.Load_()

        Payroll_Menu.Object_ = New Payroll_Features_ctrl
        Payroll_Menu.Object_.Load_()

        Backup_Menu.Object_ = New Backup_Restore_Features_ctrl
        Backup_Menu.Object_.Load_()

        Device_Manu.Object_ = New Device_Features_ctrl
        Device_Manu.Object_.Load_()

        Communication_Manu.Object_ = New Communication_Features_ctrl
        Communication_Manu.Object_.Load_()

    End Sub
    Public Function Set_ctrl(obj As Object)
        If IsNothing(obj) Then
            bg.Visible = False
            Panel6.Visible = True
            Exit Function
        End If
        bg.Visible = True
        Panel6.Visible = False
        With obj
            '.TopLevel = False
            bg.Controls.Add(obj)
            .Location = New Point(18, Panel1.Height + 5)
            .Show()
            .BringToFront()
            .Focus()
        End With

        Dim all_ = GetAllControls(Panel15).OfType(Of Features_Manu_ctrl)().ToList()

        all_.FindAll(Function(i)
                         Try
                             If i.Visible = True Then
                                 If i.Object_.Name <> obj.Name Then
                                     i.Object_.Visible = False
                                 End If
                             End If
                         Catch ex As Exception

                         End Try
                     End Function)

        bg.AutoSize = True
        bg.AutoSizeMode = AutoSizeMode.GrowAndShrink

    End Function

    Private Sub TAB_TXT_TextChanged(sender As Object, e As EventArgs) Handles TAB_TXT.TextChanged

    End Sub

    Private Sub TAB_TXT_Enter(sender As Object, e As EventArgs) Handles TAB_TXT.Enter
        If Msg_Custom_YN(NOT_Location.Bottom_Right, Color.Black, My.Resources.Save_animation_icn, Dialoag_Button.Yes_No, "Are you sure", "Save Change ?", "Do you want to save?") = DialogResult.Yes Then
            Save_All()
        End If
    End Sub

    Private Sub Save_Background_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)

        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Load_Background_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles Load_Background.RunWorkerCompleted
        General_Menu.CLick_()

    End Sub

    Private Sub General_Menu_Load(sender As Object, e As EventArgs) Handles General_Menu.Load

    End Sub

    Private Sub Panel6_Paint(sender As Object, e As PaintEventArgs) Handles Panel6.Paint
        obj_center(sender, Panel16)
    End Sub
End Class