Imports System.ComponentModel
Imports System.Data.Entity.Core.Objects
Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Imports System.Management

Public Class Install_Setup_manager_dialoag
    Private webclint As New WebClient()
    Public Install_Path As String
    Public Install_link As String
    Private Sub Download_dialoag_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Install_Path = Application.StartupPath
        Download_Background.RunWorkerAsync()
    End Sub
    Private Function Get_Link()

        Try
            Dim cn As New SqlConnection
            Dim r As SqlDataReader
            If Online_MSSQL(cn) = True Then
                Dim cm As New SqlCommand($"Select Setup_Link From TBL_Update_Manager where System_Code = '004'", cn)
                r = cm.ExecuteReader
                While r.Read
                    Install_link = r("Setup_Link").ToString
                    issuccess = True
                End While
                r.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            issuccess = False
        End Try

    End Function

    Private Function Download_()
        Dim UserFolder As String = IO.Path.GetTempPath()
        Dim ArchiveTemp As String = $"{Install_Path}\installer.exe"

        Dim Path = New FileInfo(IO.Path.Combine(UserFolder, ArchiveTemp))

        AddHandler webclint.DownloadProgressChanged, New DownloadProgressChangedEventHandler(AddressOf web_clint_download_progressbarChange)
        AddHandler webclint.DownloadFileCompleted, New AsyncCompletedEventHandler(AddressOf webclint_download_complit)

        webclint.DownloadFileAsync(New Uri(Install_link), Path.FullName)
    End Function
    Dim issuccess As Boolean = False
    Private Sub web_clint_download_progressbarChange(sender As Object, e As DownloadProgressChangedEventArgs)
        issuccess = False

        Dim bytesin As Double = Double.Parse(e.BytesReceived.ToString())
        Dim totalBytes As Double = Double.Parse(e.TotalBytesToReceive.ToString())
        Dim parsantage As Double = bytesin / totalBytes * 100
        ProgressBar1.Value = Integer.Parse(Math.Truncate(parsantage).ToString)
        ProgressBar1.Run(0)
        Label6.Text = String.Format("{0} MB's / {1} MB's", (e.BytesReceived / 1024 / 1024D).ToString("0.00"), (e.TotalBytesToReceive / 1024 / 1024D).ToString("0.00"))
        Label4.Text = $"{(Val(ProgressBar1.Value * 100) / Val(ProgressBar1.Maximum))}%"
        Label7.Text = "Downloading... "
    End Sub
    Dim enebale_dispos As Boolean = False
    Private Sub webclint_download_complit(sender As Object, e As AsyncCompletedEventArgs)

        Process.Start($"{Install_Path}\installer.exe")
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub Download_dialoag_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate

    End Sub

    Private Sub Download_dialoag_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        If Label4.Text = "100%" Then
            Me.DialogResult = DialogResult.OK
        Else
            Me.DialogResult = DialogResult.Cancel
        End If
    End Sub

    Private Sub Download_Background_DoWork(sender As Object, e As DoWorkEventArgs) Handles Download_Background.DoWork
        Get_Link()
    End Sub

    Private Sub Download_Background_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles Download_Background.RunWorkerCompleted
        If issuccess = True Then
            Panel1.Show()
            Download_()
        End If

    End Sub
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
    Public Function IsRealTimeProtectionEnabled() As Boolean
        Try
            Dim scope As New ManagementScope("\\localhost\root\SecurityCenter2")
            Dim query As New System.Management.ObjectQuery("SELECT * FROM AntiVirusProduct")
            Dim searcher As New ManagementObjectSearcher(scope, query)

            For Each item As ManagementObject In searcher.Get()
                Dim productState As Integer = CInt(item("productState"))
                ' Check if real-time protection is enabled (bit 21 in productState)
                Dim realTimeProtectionEnabled As Boolean = (productState And &H1000) <> 0

                If realTimeProtectionEnabled Then
                    Return True
                End If
            Next

            Return False
        Catch ex As Exception
            ' Handle exception
            Console.WriteLine("Error checking protection status: " & ex.Message)
            Return False
        End Try
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Process.Start("ms-settings:windowsdefender")

    End Sub
    Dim off_protaction As Boolean = True
    Private Sub searchbackground_DoWork(sender As Object, e As DoWorkEventArgs)
        off_protaction = IsRealTimeProtectionEnabled()
    End Sub

    Private Sub Install_Setup_manager_dialoag_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Me.Dispose()
    End Sub

    Private Sub Download_Panel_Paint(sender As Object, e As PaintEventArgs) Handles Download_Panel.Paint
        obj_center(Download_Panel, Me)
    End Sub
End Class