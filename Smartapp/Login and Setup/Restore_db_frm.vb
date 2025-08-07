Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Data.SQLite
Imports System.IO

Public Class Restore_db_frm
    Dim Path_End As String
    Dim VC_Type_ As String
    Dim VC_ID_ As String
    Dim BS As New BindingSource

    Private Sub Restore_db_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel5.Location = New Point(Me.ClientSize.Width / 2 - Panel5.Size.Width / 2, Me.ClientSize.Height / 2 - Panel5.Size.Height / 2)
        Path_End = BG_frm.BG_Path_TXT.Text
        BG_frm.HADE_TXT.Text = "Restore Database"
        Frm_Date_TXT.Text = Cfg_Setting.Default.Curr_Date
        To_Date_TXT.Text = Cfg_Setting.Default.Curr_Date
    End Sub

    Private Sub Restore_db_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.HADE_TXT.Text = "Restore Database"
        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text
        Button_Clear()
    End Sub

    Private Sub Restore_db_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If Msg_Yn("Exit ?", "") = DialogResult.Yes Then
                Me.Dispose()
            End If
        End If
    End Sub

    Private Sub Restore_db_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End
        List_frm.Dispose()
        Frm_foCus()
    End Sub

    Private Sub Path_TXT_TextChanged(sender As Object, e As EventArgs) Handles Path_TXT.TextChanged

    End Sub

    Private Sub Path_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles Path_TXT.KeyDown
        If e.KeyCode = Keys.Enter Then
            Refresh_Load()
        End If
    End Sub
    Private Function Refresh_Load()
        If Offline_Data() = True Then
            Panel4.Location = New Point(Panel3.ClientSize.Width / 2 - Panel4.Size.Width / 2, Panel3.ClientSize.Height / 2 - Panel4.Size.Height / 2)
            If Fill_data() = True Then
                To_Date_TXT.Focus()
                Panel1.Show()
            End If
        End If
    End Function
    Private Function Offline_Data() As Boolean
        DataGridView3.DataSource = Nothing
        Try
            Dim result As String = My.Settings.Con_Data.Split(".").First
            Dim FOl As New DirectoryInfo(Path_TXT.Text)
            Dim files As New List(Of IO.DirectoryInfo)(FOl.GetDirectories("*." & result & "bcup?"))

            BS.DataSource = files
            DataGridView3.DataSource = BS

        Catch ex As Exception
            'BS.Clear()
            Path_TXT.Focus()
            DataGridView3.DataSource = BS
        End Try
        If DataGridView3.Rows.Count = 0 Then
            Msg(NOT_Type.Erro, "Backup is Not Found", "")
            Path_TXT.Focus()
            Return False
        End If
        Return True
    End Function
    Private Function Fill_data() As Boolean
        Dim dtt As New DataTable
        dtt.Clear()
        dtt.Columns.Clear()
        dtt.Rows.Clear()

        dtt.Columns.Add("Backup")
        dtt.Columns.Add("Date").DataType = GetType(Date)
        dtt.Columns.Add("Path")

        Dim fol_name As String
        Dim fol_date As Date
        Dim fol_path As String
        For i As Integer = 0 To DataGridView3.RowCount - 1
            fol_name = DataGridView3.Rows(i).Cells(0).Value.ToString
            fol_date = CDate(DataGridView3.Rows(i).Cells(6).Value.ToString.Split(" ").First)
            fol_path = DataGridView3.Rows(i).Cells(1).Value.ToString
            dtt.Rows.Add(fol_name, fol_date, fol_path)
        Next
        BindingSource1.DataSource = Nothing

        BindingSource1.DataSource = dtt
        DataGridView2.DataSource = BindingSource1

        DataGridView2.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DataGridView2.Columns(0).DefaultCellStyle.Font = Defolt_Fonts


        DataGridView2.Columns(1).Width = 130
        DataGridView2.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView2.Columns(1).DefaultCellStyle.Font = New Font(Dft_Font, Dft_Font_Size, FontStyle.Italic)

        DataGridView2.Columns(2).Visible = False
        If DataGridView2.RowCount = 0 Then
            Path_TXT.Focus()
            Return False
        Else
            To_Date_TXT.Focus()
            DataGridView2.CurrentCell = DataGridView2.Rows(0).Cells(0)
        End If
    End Function
    Private Sub Grid1_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles DataGridView2.RowsAdded
        DataGridView2.Rows(DataGridView2.Rows.Count - 1).Height = 18
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

    Private Sub DataGridView2_Enter(sender As Object, e As EventArgs) Handles DataGridView2.Enter
        To_Date_TXT.Focus()
    End Sub

    Private Sub Search_TXT_TextChanged(sender As Object, e As EventArgs) Handles To_Date_TXT.TextChanged
        Filter_()
    End Sub

    Private Sub Search_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles To_Date_TXT.KeyDown
        If e.KeyCode = Keys.Up Then
            BindingSource1.MovePrevious()
        End If
        If e.KeyCode = Keys.Down Then
            BindingSource1.MoveNext()
        End If
        If e.KeyCode = Keys.Enter Then
            If DataGridView2.Rows.Count > 0 Then
                If Msg_Yn("Restor Database", "") = DialogResult.Yes Then
                    TableLayoutPanel1.Hide()
                    BackgroundWorker1.RunWorkerAsync()
                End If
            End If
        End If
    End Sub
    Private Sub Txt1_KeyDown(sender As Object, e As KeyEventArgs) Handles Frm_Date_TXT.KeyDown
        If e.KeyCode = Keys.Up Then
            BindingSource1.MovePrevious()
        End If
        If e.KeyCode = Keys.Down Then
            BindingSource1.MoveNext()
        End If
    End Sub
    Private Function Filter_()
        Try
            If Frm_Date_TXT.Text = "" And To_Date_TXT.Text = "" Then
                BindingSource1.Filter = Nothing
            ElseIf Frm_Date_TXT.Text <> "" And To_Date_TXT.Text <> "" Then
                BindingSource1.Filter = "Date >= '" & CDate(Frm_Date_TXT.Text) & "' AND Date <= '" & CDate(To_Date_TXT.Text) & "'"
            ElseIf Frm_Date_TXT.Text <> "" Then
                BindingSource1.Filter = "Date >= '" & CDate(Frm_Date_TXT.Text) & "'"
            ElseIf To_Date_TXT.Text <> "" Then
                BindingSource1.Filter = "Date <= '" & CDate(To_Date_TXT.Text) & "'"
            End If


        Catch ex As Exception

        End Try
    End Function

    Private Sub Frm_Date_TXT_TextChanged(sender As Object, e As EventArgs) Handles Frm_Date_TXT.TextChanged
        Filter_()
    End Sub

    Private Sub Frm_Date_TXT_LostFocus(sender As Object, e As EventArgs) Handles Frm_Date_TXT.LostFocus
        Frm_Date_TXT.Text = Date_Formate(Frm_Date_TXT.Text)
    End Sub

    Private Sub To_Date_TXT_LostFocus(sender As Object, e As EventArgs) Handles To_Date_TXT.LostFocus
        To_Date_TXT.Text = Date_Formate(To_Date_TXT.Text)
    End Sub
    Private Function Restor_Date(file_ As String) As Boolean
        Dim Path_ As String = DataGridView2.CurrentRow.Cells(2).Value
        Dim Mdf_Path As String = My.Settings.Con_Location & "\" & My.Settings.Con_Data & "\" & file_ & ".mdf"
        Dim Bak_Path As String = Path_ & "\" & file_ & ".bak"

        Try
            Dim cn As New SQLiteConnection
            If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                cmd = New SQLiteCommand("USE Master ALTER DATABASE [" & Mdf_Path & "] SET Single_User WITH Rollback Immediate Restore database [" & Mdf_Path & "] FROM disk=N'" & Bak_Path & "' WITH REPLACE ALTER DATABASE [" & Mdf_Path & "] SET Multi_User", cn)
                cmd.ExecuteNonQuery()
            End If
            cn.Close()
            Restore_Status = True
        Catch ex As Exception
            Msg(NOT_Type.Erro, "Database Restor Error", ex.Message)
            Restore_Status = False
        End Try
        Return Restore_Status
    End Function

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        BackgroundWorker1.ReportProgress(10)
        BackgroundWorker1.ReportProgress(25)
        If Restor_Date("cre") = True Then
            BackgroundWorker1.ReportProgress(50)
            If Restor_Date("lnk") = True Then
                BackgroundWorker1.ReportProgress(90)
                If Restor_Date("rec") = True Then
                    BackgroundWorker1.ReportProgress(100)
                End If
            End If
        End If
    End Sub
    Dim Restore_Status As Boolean
    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If Restore_Status = True Then
            Msg(NOT_Type.Success, "Database is Successfully Restore", "")
            Me.Dispose()
            Frm_foCus()
        Else
            TableLayoutPanel1.Show()
        End If
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
        Label6.Text = ProgressBar1.Value & "% Complete Restore"
    End Sub
End Class