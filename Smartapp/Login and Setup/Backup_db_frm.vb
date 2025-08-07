Imports System.Data.SqlClient
Imports System.Data.SQLite

Public Class Backup_db_frm
    Dim Path_End As String
    Dim VC_Type_ As String
    Dim VC_ID_ As String

    Private Sub Backup_db_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Path_End = BG_frm.BG_Path_TXT.Text
        Panel1.Location = New Point(Me.ClientSize.Width / 2 - Panel1.Size.Width / 2, Me.ClientSize.Height / 2 - Panel1.Size.Height / 2)
        BG_frm.HADE_TXT.Text = "Backup Database"



        Label1.Text = My.Settings.Company_Name & " Data Backup"
    End Sub
    Private Function BackUP_Data() As Boolean
        Dim result As String = My.Settings.Con_Data.Split(".").First
        Dim path As String = Path_TXT.Text & "\" & DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss") & "." & result & "bcup"
        If Not System.IO.Directory.Exists(path) Then
            System.IO.Directory.CreateDirectory(path)
        End If

        Try
            Dim cn As New SQLiteConnection
            If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                cmd = New SQLiteCommand("Backup Database [" & My.Settings.Con_Location & "\" & My.Settings.Con_Data & "\cmp.mdf] TO DISK = '" & path & "\cmp.bak'", cn)
                cmd.ExecuteNonQuery()

                cmd = New SQLiteCommand("Backup Database [" & My.Settings.Con_Location & "\" & My.Settings.Con_Data & "\cre.mdf] TO DISK = '" & path & "\cre.bak'", cn)
                cmd.ExecuteNonQuery()

                cmd = New SQLiteCommand("Backup Database [" & My.Settings.Con_Location & "\" & My.Settings.Con_Data & "\lnk.mdf] TO DISK = '" & path & "\lnk.bak'", cn)
                cmd.ExecuteNonQuery()

                cmd = New SQLiteCommand("Backup Database [" & My.Settings.Con_Location & "\" & My.Settings.Con_Data & "\rec.mdf] TO DISK = '" & path & "\rec.bak'", cn)
                cmd.ExecuteNonQuery()
                Return True
            End If
        Catch ex As Exception
            Msg(NOT_Type.Erro, "Backup Error", ex.Message)
            Return False
        End Try
    End Function
    Private Sub Txt1_KeyDown(sender As Object, e As KeyEventArgs) Handles Path_TXT.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Msg_Yn("Backup Database", "") = DialogResult.Yes Then
                If Chck_Directry(Path_TXT.Text) = True Then
                    If BackUP_Data() = True Then
                        Msg(NOT_Type.Success, "Backup is Success", "")
                        Me.Dispose()
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub Backup_db_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End
        List_frm.Dispose()
        Frm_foCus()
    End Sub

    Private Sub Backup_db_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If Msg_Yn("Exit ?", "") = DialogResult.Yes Then
                Me.Dispose()
            End If
        End If
    End Sub

    Private Sub Backup_db_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.HADE_TXT.Text = "Backup Database"
        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text
        Button_Clear()
        Path_TXT.Focus()
    End Sub
End Class