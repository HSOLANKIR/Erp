Imports System.ComponentModel
Imports System.Data.SQLite

Public Class Create_local_db_frm
    Public st, VC_ID_, Class_, Path_TXT As String
    Dim From_ID As String

    Dim Path_End As String
    Private Sub Create_local_db_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text
        Class_ = Link_Valu(0)


        BG_frm.HADE_TXT.Text = "Create Database"
        BG_frm.TYP_TXT.Text = ""

        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub Create_local_db_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.HADE_TXT.Text = "Create Database"
        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text

        Button_Clear()
    End Sub
    Private Sub Create_local_db_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        'BG_frm.BG_Path_TXT.Text = Path_End
        List_frm.Dispose()
        Frm_foCus()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        obj_center(sender, Me)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Run(1)
        If ProgressBar1.Value = 100 Then
            ProgressBar1.Value = (0)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Data_install.Class_ = Class_
        Create_cmp(Path_TXT)
        BackgroundWorker1.ReportProgress(20)
        Create_cre(Path_TXT)
        BackgroundWorker1.ReportProgress(40)
        Create_lnk(Path_TXT)
        BackgroundWorker1.ReportProgress(60)
        Create_rec(Path_TXT)
        BackgroundWorker1.ReportProgress(80)
        Create_aud(Path_TXT)
        BackgroundWorker1.ReportProgress(100)


    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        'ProgressBar1.Value = (0)
        ProgressBar2.Value = e.ProgressPercentage
        ProgressBar2.Run(0)
        'Label3.Text = P1.Value & "%"
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted

    End Sub

    Private Sub Create_local_db_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
    End Sub
End Class