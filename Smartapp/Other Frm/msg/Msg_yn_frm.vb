Imports Management.GENDRAL_mod

Public Class Msg_yn_frm
    Private Sub Msg_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Height = Me.Height + 30
        'Me.CenterToScreen()

        Stype_(typ_, Me)

    End Sub
    Public Location_ As Integer
    Public btn_ As Integer
    Public typ_ As Integer
    Public custom_Color As Color = Color.Black
    Public custom_Titel As String = "Question"
    Public custom_img As Image = My.Resources.Question_animation_icn
    Public Function Msg(frm As Msg_yn_frm, NOT_Ty As Integer, Location As Integer, btn As Integer, Head As String, Message As String) As DialogResult
        With frm
            .Location_ = Location
            .Type_(NOT_Ty, frm)
            .head_lb.Text = Head
            .msg_lb.Text = Message.Replace("<nl>", vbNewLine)
            .btn_ = btn
            .typ_ = NOT_Ty
            .Stype_(NOT_Ty, frm)
            My.Computer.Audio.Play(My.Resources.Dialoag_Sound, AudioPlayMode.Background)
            Return .ShowDialog()
        End With
    End Function
    Public Function Stype_(S As Integer, frm As Msg_yn_frm)
        With frm
            If Location_ = 0 Then
                .Location = New Point(BG_frm.BG_PAN.Width - .Width, ((BG_Head_frm.Top_Bar.Height + BG_frm.Label11.Height) - Me.Height) + BG_frm.BG_PAN.Height)
            ElseIf Location_ = 1 Then
                obj_center(frm, BG_frm.BG_PAN)
            End If

            If btn_ = 0 Then
                btn_manag(YN_Btn_Panel)
            ElseIf btn_ = 1 Then
                btn_manag(OK_Btn_Panel)
            ElseIf btn_ = 2 Then
                btn_manag(Retry_Calnel_Panel)
            ElseIf btn_ = 3 Then
                btn_manag(any_panel)

            End If


            msg_lb.Location = New Point(Convert.ToInt32(Me.ClientSize.Width / 2 - Me.msg_lb.Width / 2), msg_lb.Location.Y)

            head_lb.Location = New Point(Convert.ToInt32(Me.ClientSize.Width / 2 - Me.head_lb.Width / 2), head_lb.Location.Y)

        End With
    End Function
    Private Function btn_manag(pan As Panel)
        OK_Btn_Panel.Visible = False
        YN_Btn_Panel.Visible = False
        Retry_Calnel_Panel.Visible = False
        any_panel.Visible = False

        pan.Dock = DockStyle.Bottom
        pan.Visible = True
    End Function
    Dim Type_noti As Integer
    Public Function Type_(typ As Integer, frm As Msg_yn_frm)
        Type_noti = typ
        If typ = 0 Then
            type_lb.Text = "Actip?"
            Me.Text = "Question"
            PictureBox1.Image = My.Resources.Save_animation_icn
            color_(Color.DarkCyan)
        ElseIf typ = 1 Then
            type_lb.Text = "Quit?"
            Me.Text = "Question"
            PictureBox1.Image = My.Resources.Exit_animation_icn
            color_(Color.Tomato)
        ElseIf typ = 2 Then
            type_lb.Text = "Delete?"
            Me.Text = "Question"
            PictureBox1.Image = My.Resources.Delete_animation_icn
            color_(Color.Red)
        ElseIf typ = 3 Then
            type_lb.Text = custom_Titel
            Me.Text = "Question"
            PictureBox1.Image = custom_img
            color_(custom_Color)
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

    Private Sub Msg_yn_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Back Then
            Me.DialogResult = DialogResult.Cancel
            Me.Dispose()
        End If

        If btn_ = 0 Then
            If typ_ = 1 Then
                If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Escape Or e.KeyCode = Keys.Y Then
                    Me.DialogResult = DialogResult.Yes
                    Me.Dispose()
                ElseIf e.KeyCode = Keys.N Then
                    Me.DialogResult = DialogResult.No
                    Me.Dispose()
                End If
            Else
                If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Y Then
                    Me.DialogResult = DialogResult.Yes
                    Me.Dispose()
                ElseIf e.KeyCode = Keys.Escape Or e.KeyCode = Keys.N Then
                    Me.DialogResult = DialogResult.No
                    Me.Dispose()
                End If
            End If
        ElseIf btn_ = 1 Then
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Escape Or e.KeyCode = Keys.O Then
                Me.DialogResult = DialogResult.OK
                Me.Dispose()
            End If
        ElseIf btn_ = 2 Then
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.R Then
                Me.DialogResult = DialogResult.Retry
                Me.Dispose()
            ElseIf e.KeyCode = Keys.Escape Or e.KeyCode = Keys.C Then
                Me.DialogResult = DialogResult.Cancel
                Me.Dispose()
            End If
        ElseIf btn_ = 3 Then
            If e.KeyCode <> Keys.Enter Then
                Me.DialogResult = DialogResult.OK
                Me.Dispose()
            End If
        End If
    End Sub

    Private Sub Msg_yn_frm_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        Stype_(typ_, Me)
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Me.DialogResult = DialogResult.Yes
        Me.Dispose()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Me.DialogResult = DialogResult.No
        Me.Dispose()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Me.DialogResult = DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Me.DialogResult = DialogResult.Retry
        Me.Dispose()
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Dispose()
    End Sub

    Private Sub Retry_Calnel_Panel_Paint(sender As Object, e As PaintEventArgs) Handles Retry_Calnel_Panel.Paint

    End Sub

    Private Sub Msg_yn_frm_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress

    End Sub
End Class