Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.IO

Public Class License_Count_frm
    Private Second_ As Integer = 0
    Private Sub License_Count_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Visible = False
        Second_ = LC_Timer
        Timer1.Start()
        device_serial = Computer_Serial()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Second_ -= 1
        Label1.Text = Second_

        If Second_ <= 0 Or LC_Status <> "Approval" Then
            'Timer1.Stop()
            If License_LInk_frm.Visible = False Then
                License_LInk_frm.Panel_Manage(License_LInk_frm.Expiar_Panel)
                License_LInk_frm.ShowDialog()
                If Second_ <= 0 Then
                    Application.Exit()
                End If
            End If
        Else
            If License_LInk_frm.Visible = True Then
                License_LInk_frm.Dispose()
            End If
        End If

        If File.Exists($"{Application.StartupPath}\exit.txt") Then
            Application.Exit()
        End If

    End Sub
    Dim Online_sec As Integer = 30
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Online_sec = Val(Online_sec) - 1
        If Online_sec <= 0 Then
            Timer2.Stop()
            If BG_frm.BG_Path_TXT.Visible = True Then
                Last_activity = BG_frm.BG_Path_TXT.Text.ToString.Trim
            End If
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub
    Dim device_serial As String
    Dim Last_activity As String = ""
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim verson_ As String = My.Application.Info.Version.ToString
            Dim cn As New SqlConnection
            If Online_MSSQL(cn) = True Then
                Dim cmmd As SqlCommand
                Dim Isnothig As Boolean = False
                cmmd = New SqlCommand($"Select Status,Exp_Date,Description,(SELECT DATEADD(MINUTE, 90, GETDATE()) AS vlu) as Time_ From TBL_License where License = '{LC_ID_str}'", cn)
                Dim r As SqlDataReader = cmmd.ExecuteReader
                While r.Read
                    Isnothig = True
                    LC_Status = r("Status").ToString
                    LC_Message = r("Description").ToString
                    LC_Expir = CDate(r("Exp_Date").ToString)
                    LC_Timer = (DateDiff(DateInterval.Second, CDate(r("Time_").ToString), CDate(LC_Expir)))
                    Second_ = LC_Timer
                End While
                r.Close()

                If Isnothig = True Then
                    cmmd = New SqlCommand($"UPDATE TBL_License_Device SET Version = '{verson_}',Last_Login = SYSDATETIME(),Last_Login_Company = '{Company_ID_str.ToString.Trim}',Last_Activity = '{Last_activity}' WHERE Device_ID = '{device_serial}'", cn)
                    cmmd.ExecuteNonQuery()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Online_sec = 30
        Timer2.Start()
    End Sub
End Class