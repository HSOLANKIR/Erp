Imports System.ComponentModel

Public Class Msg_frm
    Private Sub Msg_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Height = Me.Height + 30
        Me.CenterToScreen()

    End Sub
    Public Function Msg(frm As Msg_frm, NOT_Ty As Integer, Location As Integer, Head As String, Message As String)
        With frm
            .Type_(NOT_Ty, frm)
            .head_lb.Text = Head
            .msg_lb.Text = Message.Replace("<nl>", vbNewLine)
            .Show()
            .Stype_(NOT_Ty, Location, frm)
            .BringToFront()
        End With
    End Function
    Private Function Stype_(S As Integer, L As Integer, frm As Msg_frm)
        With frm
            If L = 0 Then
                .Location = New Point(BG_frm.BG_PAN.Width - .Width, (((BG_frm.BG_PAN.PointToScreen(New Point(0, 0)).Y)) - Me.Height) + BG_frm.BG_PAN.Height)
            End If

            msg_lb.Location = New Point(Convert.ToInt32(Me.ClientSize.Width / 2 - Me.msg_lb.Width / 2), msg_lb.Location.Y)

            head_lb.Location = New Point(Convert.ToInt32(Me.ClientSize.Width / 2 - Me.head_lb.Width / 2), head_lb.Location.Y)
        End With
    End Function
    Dim Type_noti As Integer
    Private Function Type_(typ As Integer, frm As Msg_frm)
        Type_noti = typ
        If typ = 0 Then
            type_lb.Text = "Success"
            Me.Text = "Success"
            PictureBox1.Image = My.Resources.Success_animation_icn
            color_(Color.DarkCyan)
            My.Computer.Audio.Play(My.Resources.Success_Sound, AudioPlayMode.Background)
        ElseIf typ = 1 Then
            type_lb.Text = "Error"
            Me.Text = "Error"
            PictureBox1.Image = My.Resources.Error_animation_icn
            color_(Color.OrangeRed)
            My.Computer.Audio.Play(My.Resources.Dialoag_Sound, AudioPlayMode.Background)
        ElseIf typ = 2 Then
            type_lb.Text = "Information"
            Me.Text = "Information"
            color_(Color.DeepSkyBlue)
            PictureBox1.Image = My.Resources.Info_animation_icn
            My.Computer.Audio.Play(My.Resources.Info_Sound, AudioPlayMode.Background)
        ElseIf typ = 3 Then
            type_lb.Text = "Warning"
            Me.Text = "Warning"
            PictureBox1.Image = My.Resources.Warning_animation_icn
            color_(Color.DarkOrange)

        ElseIf typ = 4 Then
            type_lb.Text = "Question"
            Me.Text = "Question"
            PictureBox1.Image = My.Resources.Question_animation_icn
            color_(Color.DodgerBlue)

        End If
    End Function
    Private Function color_(c As Color)
        T.BackColor = c
        R.BackColor = c
        B.BackColor = c
        L.BackColor = c

        type_lb.ForeColor = c

    End Function
    Private Sub Msg_frm_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        DrawLinePoint(e)
    End Sub

    Public Sub DrawLinePoint(ByVal e As PaintEventArgs)
        Dim blackPen As New Pen(Color.Orange, 5)

        Dim P As Point = Me.PointToScreen(Me.Location)

        Dim point1 As New Point(P.X, 0)
        Dim point2 As New Point(P.X + Me.Width, 100)
        e.Graphics.DrawLine(blackPen, point1, point2)

    End Sub

    Private Sub Msg_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Me.Hide()
    End Sub

    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim ret As CreateParams = MyBase.CreateParams
            ret.Style = CInt(&H40000000)
            Return ret
        End Get
    End Property
End Class