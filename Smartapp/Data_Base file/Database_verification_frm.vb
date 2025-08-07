Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Data.SQLite

Public Class Database_verification_frm
    Dim From_ID As String
    Dim Path_End As String
    Dim TYP_TXT_old As String

    Dim Verification_Code_cmp As String = ""
    Dim Verification_Code_cre As String = ""
    Dim Verification_Code_lnk As String = ""
    Dim Verification_Code_rec As String = ""
    Public Function Cheack_() As Boolean
        If Val(Find_DT_Value(Database_File.cmp, "TBL_Company_Creation", "DB_Version", "ID <> '000'").ToString.Replace(".", "")) <= 1050 Then

            Return True
        End If

        Dim cn As New SQLiteConnection
        Dim r As SQLiteDataReader
        If open_MSSQL_Cstm(Database_File.cmp, cn) = True Then
            cmd = New SQLiteCommand("Select * From TBL_Info where Head = 'Verification'", cn)
            r = cmd.ExecuteReader
            While r.Read
                Verification_Code_cmp = r("Value").ToString
            End While
            r.Close()
        End If

        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand("Select * From TBL_Info where Head = 'Verification'", cn)
            r = cmd.ExecuteReader
            While r.Read
                Verification_Code_cre = r("Value").ToString
            End While
            r.Close()
        End If

        If open_MSSQL_Cstm(Database_File.lnk, cn) = True Then
            cmd = New SQLiteCommand("Select * From TBL_Info where Head = 'Verification'", cn)
            r = cmd.ExecuteReader
            While r.Read
                Verification_Code_lnk = r("Value").ToString
            End While
            r.Close()
        End If

        If open_MSSQL_Cstm(Database_File.rec, cn) = True Then
            cmd = New SQLiteCommand("Select * From TBL_Info where Head = 'Verification'", cn)
            r = cmd.ExecuteReader
            While r.Read
                Verification_Code_rec = r("Value").ToString
            End While
            r.Close()
        End If

        If Verification_Code_cmp = Verification_Code_cre And Verification_Code_cre = Verification_Code_lnk And Verification_Code_lnk = Verification_Code_rec Then
            Repair_()
            Return True
        Else
            Cell("Database Verification") '<--Me Visible
            My.Computer.Audio.Play(My.Resources.z_error, AudioPlayMode.Background)
        End If
    End Function
    Private Sub Database_verification_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text
        TYP_TXT_old = BG_frm.TYP_TXT.Text
        Dim cnn As New SQLiteConnection

        BG_frm.HADE_TXT.Text = "Database Verification"
        BG_frm.TYP_TXT.Text = ""

        BackgroundWorker1.RunWorkerAsync()

        Verification_TXT.Focus()
    End Sub

    Private Function Server_()
        Dim Code As String = ((Val(Now.Date.Day) + Val(Now.Date.Minute) + Val(Now.Date.Hour) & Val(Val(Now.TimeOfDay.Hours + Now.TimeOfDay.Minutes & Now.Date.Month + Now.Date.Day)) + Val(Val(Now.Date.Year))) - Val(Now.TimeOfDay.Minutes) + Val(Now.TimeOfDay.Minutes)) * 12552

        Dim isavalabel As Boolean = False
        Dim cn As New SqlConnection
        Dim cmmd As New SqlCommand

        If Online_MSSQL(cn) = True Then
            cmmd = New SqlCommand($"Select * From TBL_Database_Tampering where Company Like N'{Company_ID_str}' and PC = '{PC_ID}' and YN = 'No'", cn)
            Dim r As SqlDataReader
            r = cmmd.ExecuteReader
            While r.Read
                isavalabel = True
            End While
            r.Close()

            If isavalabel = False Then
                Dim cmd As New SqlCommand($"INSERT INTO TBL_Database_Tampering (Company,DateTime,Code,[User],PC,YN) VALUES ('{Company_ID_str}',SYSDATETIME(),'{Code}','{LOGIN_ID}','{PC_ID}','No')", cn)
                cmd.ExecuteNonQuery()
            End If
        End If
    End Function

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)
        obj_center(sender, Me)
    End Sub

    Private Sub Database_verification_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.HADE_TXT.Text = "Database Verification"
        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text

        Button_Clear()
    End Sub

    Private Sub Database_verification_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        'BG_frm.BG_Path_TXT.Text = Path_End
        List_frm.Dispose()
        Frm_foCus()
    End Sub
    Private Function Panel_Manag(pan As Panel)


        pan.Visible = True
    End Function

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs)
        obj_center(sender, Me)
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Login_Frm.Dispose()
        Cell("Company Select")
        Me.Dispose()
    End Sub

    Private Sub Panel8_Paint(sender As Object, e As PaintEventArgs)
        obj_center(sender, Me)
    End Sub

    Private Sub DamiDatabase_Background_ProgressChanged(sender As Object, e As ProgressChangedEventArgs)

    End Sub

    Private Sub Panel1_Paint_1(sender As Object, e As PaintEventArgs)
        obj_center(sender, Me)
    End Sub

    Private Sub BackgroundWorker1_DoWork_1(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Server_()
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Panel4.Visible = False
        Panel1.Visible = True
        Verification_TXT.Focus()

    End Sub

    Private Sub Verification_TXT_TextChanged(sender As Object, e As EventArgs) Handles Verification_TXT.TextChanged
        Label8.Visible = False
    End Sub

    Private Sub Verification_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles Verification_TXT.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Verification_TXT.Text <> Nothing Then
                Panel4.Visible = True
                Panel1.Visible = False
                Chack_BackgroundWorker.RunWorkerAsync()
            End If
        End If
    End Sub

    Private Sub Chack_BackgroundWorker_DoWork(sender As Object, e As DoWorkEventArgs) Handles Chack_BackgroundWorker.DoWork
        Dim cn As New SqlConnection
        Dim cmmd As New SqlCommand
        Dim isverifid As Boolean = False

        If Online_MSSQL(cn) = True Then
            cmmd = New SqlCommand($"Select * From TBL_Database_Tampering where Company Like N'{Company_ID_str}' and PC = '{PC_ID}' and YN = 'No' and Code = '{Verification_TXT.Text}'", cn)
            Dim r As SqlDataReader
            r = cmmd.ExecuteReader
            While r.Read
                isverifid = True
            End While
            r.Close()

            If isverifid = True Then
                Dim cmd As New SqlCommand($"UPDATE TBL_Database_Tampering SET YN = 'Yes' where Code = '{Verification_TXT.Text}'", cn)
                cmd.ExecuteNonQuery()
            Else
                Verification_TXT.Focus()
                Exit Sub
            End If

            If Repair_() = True Then
                Application.Restart()
            End If
        End If
    End Sub
    Private Function Repair_() As Boolean
        Dim Code As String = ((Val(Now.Date.Day) + Val(Now.Date.Minute) + Val(Now.Date.Hour) & Val(Val(Now.TimeOfDay.Hours + Now.TimeOfDay.Minutes & Now.Date.Month + Now.Date.Day)) + Val(Val(Now.Date.Year))) - Val(Now.TimeOfDay.Minutes) + Val(Now.TimeOfDay.Minutes)) * 12552


        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cmp, cn) = True Then
            cmd = New SQLiteCommand($"UPDATE TBL_Info SET Value = '{Code}' where Head = 'Verification'", cn)
            cmd.ExecuteNonQuery()
        End If

        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"UPDATE TBL_Info SET Value = '{Code}' where Head = 'Verification'", cn)
            cmd.ExecuteNonQuery()
        End If

        If open_MSSQL_Cstm(Database_File.lnk, cn) = True Then
            cmd = New SQLiteCommand($"UPDATE TBL_Info SET Value = '{Code}' where Head = 'Verification'", cn)
            cmd.ExecuteNonQuery()
        End If

        If open_MSSQL_Cstm(Database_File.rec, cn) = True Then
            cmd = New SQLiteCommand($"UPDATE TBL_Info SET Value = '{Code}' where Head = 'Verification'", cn)
            cmd.ExecuteNonQuery()
        End If


        Return True
    End Function
    Private Sub Chack_BackgroundWorker_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles Chack_BackgroundWorker.RunWorkerCompleted
        Label8.Visible = True
        Panel4.Visible = False
        Panel1.Visible = True
        Verification_TXT.Focus()
    End Sub

    Private Sub Database_verification_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID

        Verification_TXT.Focus()
    End Sub

    Private Sub Panel4_Paint_1(sender As Object, e As PaintEventArgs) Handles Panel4.Paint
        obj_center(sender, Me)
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

    End Sub

    Private Sub Import_Company_Data_Panel_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        obj_center(sender, Me)
    End Sub
End Class