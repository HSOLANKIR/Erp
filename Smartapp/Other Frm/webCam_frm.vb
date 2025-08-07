Imports PInvoke
Imports AForge
Imports AForge.Video
Imports AForge.Video.DirectShow
Imports System.Text.RegularExpressions
Imports System.ComponentModel

Public Class webCam_frm
    Dim camara As VideoCaptureDevice
    Dim bmp As Bitmap
    Public img As Image
    Private Sub webCam_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CenterToScreen()
        Top = 0
        Me.Height = 0

    End Sub
    Private Function Load_Camara()
        Dim camara_frm As VideoCaptureDeviceForm = New VideoCaptureDeviceForm

        If camara_frm.ShowDialog = DialogResult.OK Then
            camara = camara_frm.VideoDevice
            AddHandler camara.NewFrame, New NewFrameEventHandler(AddressOf Captur)
            camara.Start()
        End If
    End Function
    Private Sub Captur(sender As Object, eventArge As NewFrameEventArgs)
        bmp = DirectCast(eventArge.Frame.Clone(), Bitmap)
        PictureBox1.Image = DirectCast(eventArge.Frame.Clone(), Bitmap)
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.Height += 10

        If Me.Height >= 257 Then
            Timer1.Stop()
            Load_Camara()
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Me.Height -= 5

        camara.Stop()
        If Me.Height <= 5 Then
            Timer2.Stop()
            Me.DialogResult = rest
            Me.Dispose()
        End If
    End Sub

    Private Sub webCam_frm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Me.Dispose()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        camara.Stop()
        PictureBox1.Image = My.Resources.face_animation_gif

        Load_Camara()


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        img = PictureBox1.Image
        Timer2.Start()
        rest = DialogResult.Yes
    End Sub
    Dim rest As DialogResult
    Private Sub webCam_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            rest = DialogResult.Cancel
            Timer2.Start()
        End If
    End Sub
End Class