Public Class Print_Cfg_Dialoag
    Public Ctrl As Object
    Private Sub Print_Cfg_Dialoag_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Set_ctrl()
    End Sub

    Private Sub Print_Cfg_Dialoag_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Function Set_ctrl()
        With Ctrl
            '.TopLevel = False
            bg.Controls.Add(Ctrl)
            .Location = New Point(15, Panel1.Height + 0)
            .Show()
            .BringToFront()
            .Focus()
        End With
        bg.AutoSize = True
        bg.AutoSizeMode = AutoSizeMode.GrowAndShrink
    End Function
    Private Sub bg_Paint(sender As Object, e As PaintEventArgs) Handles bg.Paint
        Me.Width = bg.Width + 250
        Me.Height = bg.Height + 250

        obj_center(sender, Me)
        CenterToScreen()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Ctrl.Save_()
    End Sub
End Class