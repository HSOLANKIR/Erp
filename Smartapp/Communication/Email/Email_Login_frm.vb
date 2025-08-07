Imports System.Data.SQLite

Public Class Email_Login_frm
    Public focus_YN As Boolean = False
    Public focus_Obj As Object

    Private Sub Email_Login_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()

        Load_data()

        List_set()
    End Sub
    Dim ag_list As List_frm
    Private Function List_set()


        ag_list = New List_frm
        List_Setup("Email Gateway", Select_List.Right, Select_List_Format.Singel, Gateway_, ag_list, BindingSource1, 200)

    End Function
    Private Function Load_data()

        Dim dt As New DataTable
        dt.Columns.Add("Name")
        dt.Rows.Add("Gmail")
        dt.Rows.Add("Yahoo Mail")
        dt.Rows.Add("Other")

        BindingSource1.DataSource = dt


        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cmp, cn) = True Then
            Dim create_ As Boolean = True
            cmd = New SQLiteCommand("SELECT count(*) as c FROM sqlite_master WHERE type='table' AND name='TBL_Email_Login'", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader()
            While r.Read
                If Val(r("c")) <> 0 Then
                    create_ = False
                End If
            End While
            r.Close()

            If create_ = True Then
                cmd = New SQLiteCommand($"CREATE TABLE 'TBL_Email_Login' (
	'ID'	INTEGER NOT NULL UNIQUE,
	'Email Gateway'	TEXT,
	'Outgoing SMTP'	TEXT,
	'Server Port'	TEXT,
	'Email Address'	TEXT,
	'Password'	TEXT,
	PRIMARY KEY('ID' AUTOINCREMENT));", cn)
                cmd.ExecuteNonQuery()

            Else
                cmd = New SQLiteCommand("Select * From TBL_Email_Login", cn)
                r = cmd.ExecuteReader
                While r.Read
                    Gateway_.Text = r("Email Gateway").ToString
                    SMTP_TXT.Text = r("Outgoing SMTP").ToString
                    PORT_TXT.Text = r("Server Port").ToString
                    Email_TXT.Text = r("Email Address").ToString
                    Pass_TXT.Text = r("Password").ToString
                End While
                r.Close()
            End If
        End If


    End Function
    Private Function Save_Data()
        Dim cn As New SQLiteConnection

        If SMTP_TXT.Text = Nothing Then
            SMTP_TXT.Focus()
            Exit Function
        End If
        If PORT_TXT.Text = Nothing Then
            PORT_TXT.Focus()
            Exit Function
        End If
        If Email_TXT.Text = Nothing Then
            Email_TXT.Focus()
            Exit Function
        End If
        If Pass_TXT.Text = Nothing Then
            Pass_TXT.Focus()
            Exit Function
        End If

        If open_MSSQL_Cstm(Database_File.cmp, cn) = True Then
            cmd = New SQLiteCommand("DELETE FROM TBL_Email_Login;", cn)
            cmd.ExecuteNonQuery()

            cmd = New SQLiteCommand($"INSERT INTO TBL_Email_Login ([Email Gateway],[Outgoing SMTP],[Server Port],[Email Address],[Password]) VALUES ('{Gateway_.Text}','{SMTP_TXT.Text}','{PORT_TXT.Text}','{Email_TXT.Text}','{Pass_TXT.Text}')", cn)
            cmd.ExecuteNonQuery()
        End If
    End Function
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Email_Login_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter

    End Sub

    Private Sub Email_Login_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub Email_Login_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        Frm_foCus()

        If focus_YN = True Then
            focus_Obj.Focus()
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Save_TXT_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Save_TXT_Enter(sender As Object, e As EventArgs)
        If Msg_Custom_YN(NOT_Location.Bottom_Right, Color.Black, My.Resources.Save_animation_icn, Dialoag_Button.Yes_No, "Question?", "Save Email Details ?", "Communication details will<nl>be sent from the<nl>entered email data") = DialogResult.Yes Then
            Save_Data()
            Me.Dispose()
        End If
    End Sub

    Private Sub Email_Login_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        Gateway_.Focus()
    End Sub

    Private Sub Success_P_Paint(sender As Object, e As PaintEventArgs)
        obj_center(sender, Me)
    End Sub

    Private Sub Txt1_TextChanged(sender As Object, e As EventArgs) Handles Gateway_.TextChanged

    End Sub

    Private Sub Txt1_KeyDown(sender As Object, e As KeyEventArgs) Handles Gateway_.KeyDown
        If e.KeyCode = Keys.Enter Then
            If ag_list.List_Grid.CurrentRow.Cells(0).Value.ToString = "Other" Then
                SMTP_TXT.Enabled = True
                PORT_TXT.Enabled = True
            Else
                SMTP_TXT.Enabled = False
                PORT_TXT.Enabled = False

                If ag_list.List_Grid.CurrentRow.Cells(0).Value.ToString = "Yahoo Mail" Then
                    SMTP_TXT.Text = "smtp.mail.yahoo.com"
                    PORT_TXT.Text = "587"
                ElseIf ag_list.List_Grid.CurrentRow.Cells(0).Value.ToString = "Gmail" Then
                    SMTP_TXT.Text = "smtp.gmail.com"
                    PORT_TXT.Text = "587"
                End If
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        If Msg_Custom_YN(NOT_Location.Bottom_Right, Color.Black, My.Resources.Save_animation_icn, Dialoag_Button.Yes_No, "Question?", "Save Email Details ?", "Communication details will<nl>be sent from the<nl>entered email data") = DialogResult.Yes Then

        End If
    End Sub

    Private Sub Button1_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            If Msg_Custom_YN(NOT_Location.Bottom_Right, Color.Black, My.Resources.Save_animation_icn, Dialoag_Button.Yes_No, "Question?", "Save Email Details ?", "Communication details will<nl>be sent from the<nl>entered email data") = DialogResult.Yes Then
                Save_Data()
                Me.Dispose()
            End If
        End If
        If e.KeyCode = Keys.Back Then
            SendKeys.Send("+{TAB}")
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Me.Dispose()
    End Sub

    Private Sub Button3_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Me.Dispose()
        End If

        If e.KeyCode = Keys.Back Then
            SendKeys.Send("+{TAB}")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Save_Data()
        Me.Dispose()
    End Sub

    Private Sub Login_P_Paint(sender As Object, e As PaintEventArgs) Handles Login_P.Paint
        obj_center(sender, Me)
    End Sub

    Private Sub Label25_Click(sender As Object, e As EventArgs) Handles Label25.Click
        Process.Start("https://myaccount.google.com/")
    End Sub

    Private Sub Pass_TXT_TextChanged(sender As Object, e As EventArgs) Handles Pass_TXT.TextChanged

    End Sub
End Class