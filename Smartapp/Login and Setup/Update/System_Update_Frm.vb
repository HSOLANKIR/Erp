Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Public Class System_Update_Frm
    Dim From_ID As String
    Dim Path_End As String
    Dim VC_Type_ As String
    Dim VC_ID_ As String

    Dim Old_Version As String
    Dim New_Version As String
    Dim New_Description As String
    Dim New_Link As String
    Public Update_yn As Boolean = False

    Private Sub System_Update_Frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text
        Label2.Text = "Current Version : " & My.Application.Info.Version.ToString
        Label10.Text = My.Application.Info.Version.ToString
        Old_Version = My.Application.Info.Version.ToString

        Button1.PerformClick()
    End Sub

    Private Sub System_Update_Frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.HADE_TXT.Text = "System Update"
        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text
        Button_Clear()
    End Sub

    Private Sub System_Update_Frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If Update_yn = True And Download_Panel.Visible = True Then
                Msg_Custom_YN(NOT_Location.Center, Color.OrangeRed, My.Resources.Warning_animation_icn, Dialoag_Button.Ok, "System Update", $"Compulsory Update", $"It is mandatory to install the update (V-{New_Version})<nl> published by the company,<nl> so if the software is fully updated then<nl>the software will continue to run otherwise it will not run.")
            Else
                If Msg_Exit_YN("System Update") = DialogResult.Yes Then
                    Me.Dispose()
                End If
            End If
        End If
    End Sub

    Private Sub System_Update_Frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End
        List_frm.Dispose()
        Frm_foCus()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PictureBox1.Show()
        Button1.Hide()
        Check_BAckground.RunWorkerAsync()
    End Sub

    Private Sub Check_BAckground_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles Check_BAckground.DoWork
        Dim cmmd As New SqlCommand
        Dim cn As New SqlConnection
        If Online_MSSQL(cn) = True Then
            cmmd = New SqlCommand("Select * From TBL_Update_Manager where System_Code = '001'", cn)
            Dim r As SqlDataReader
            r = cmmd.ExecuteReader
            While r.Read
                New_Version = r("System_Version").ToString
                New_Description = r("Description").ToString
                New_Link = r("Update_Link").ToString
                Update_yn = YN_Boolean(r("Compulsory_YN").ToString)
            End While
        End If
    End Sub

    Private Sub Check_BAckground_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles Check_BAckground.RunWorkerCompleted
        PictureBox1.Hide()
        Button1.Show()


        If Old_Version = New_Version Then
            Msg_Custom_YN(NOT_Location.Center, Color.Green, My.Resources.Success_animation_icn, Dialoag_Button.Ok, "System Update", "System is Up To Date", "")
            Button1.Focus()
        Else

            If My.Computer.FileSystem.FileExists(Application.StartupPath & "\System_Update.zip") = True Then
                Panel_mang(Download_Panel)
                Button6.Focus()
                Button6.Text = "Install"
                Button6.Image = My.Resources.install_button_png

                Label5.Text = "New Version is already download"
                Label8.Text = ""
                If Update_yn = True Then
                    Label3.Text = "Compulsory"
                Else
                    Label3.Text = "Optional"
                End If

                Button2.Show()
                Panel1.Hide()

            Else
                Panel_mang(Download_Panel)
                Button6.Focus()

                Label5.Text = New_Version
                Label8.Text = New_Description
            End If
        End If
    End Sub
    Private Function Panel_mang(Pan As Panel)
        Check_Panel.Hide()
        Download_Panel.Hide()

        Pan.Show()
        Pan.BringToFront()
    End Function
    Private webclint As New WebClient()
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If Button6.Text = "Download" Then
            If My.Computer.Network.IsAvailable = True Then
                AddHandler webclint.DownloadProgressChanged, New DownloadProgressChangedEventHandler(AddressOf web_clint_download_progressbarChange)
                AddHandler webclint.DownloadFileCompleted, New AsyncCompletedEventHandler(AddressOf webclint_download_complit)

                webclint.DownloadFileAsync(New Uri(New_Link), Application.StartupPath & "\System_Update.zip")

                Button6.Hide()
                Panel1.Show()
            Else
                Msg(NOT_Type.Info, "Internet Error", "Please enable internet and try again")
                Button6.Focus()
            End If
        ElseIf Button6.Text = "Install" Then
            File.Create($"{Application.StartupPath}\exit.txt").Dispose()
            Application.Exit()
            Process.Start(Application.StartupPath & "\Update Manager\Update.exe", Application.ExecutablePath)
        End If
    End Sub
    Private Sub web_clint_download_progressbarChange(sender As Object, e As DownloadProgressChangedEventArgs)
        Dim bytesin As Double = Double.Parse(e.BytesReceived.ToString())
        Dim totalBytes As Double = Double.Parse(e.TotalBytesToReceive.ToString())
        Dim parsantage As Double = bytesin / totalBytes * 100
        ProgressBar1.Value = Integer.Parse(Math.Truncate(parsantage).ToString)
        ProgressBar1.Run(0)
        Label6.Text = String.Format("{0} MB's / {1} MB's", (e.BytesReceived / 1024 / 1024D).ToString("0.00"), (e.TotalBytesToReceive / 1024 / 1024D).ToString("0.00"))
        Label7.Text = "Downloading update... " & Integer.Parse(Math.Truncate(parsantage).ToString) & "%"
    End Sub
    Private Sub webclint_download_complit(sender As Object, e As AsyncCompletedEventArgs)
        Button6.Text = "Install"
        Button6.Image = My.Resources.install_button_png
        Button6.Show()
        Panel1.Hide()
    End Sub

    Private Sub Check_Panel_Paint(sender As Object, e As PaintEventArgs) Handles Check_Panel.Paint
        obj_center(sender, Me)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If My.Computer.Network.IsAvailable = True Then
            Label5.Text = New_Version
            Label8.Text = New_Description


            Button6.Text = "Download"
            Button6.PerformClick()
            Button2.Hide()
        Else
            Msg(NOT_Type.Info, "Internet Error", "Please enable internet and try again")
            Button2.Focus()
        End If


    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Download_Panel_Paint(sender As Object, e As PaintEventArgs) Handles Download_Panel.Paint
        obj_center(sender, Me)
    End Sub

    Private Sub Download_Background_DoWork(sender As Object, e As DoWorkEventArgs) Handles Download_Background.DoWork

    End Sub

    Private Sub System_Update_Frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
    End Sub
End Class