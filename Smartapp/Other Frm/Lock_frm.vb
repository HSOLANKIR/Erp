Public Class Lock_frm
    Private Sub Lock_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        obj_center(sender, Me)
    End Sub

    Private Sub Txt1_TextChanged(sender As Object, e As EventArgs) Handles Txt1.TextChanged

    End Sub

    Private Sub Txt1_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Txt1.Text = Login_Password Then
                Me.Dispose()
                Frm_foCus()
            End If
        End If
    End Sub

    Private Sub Lock_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        Txt1.Focus()
    End Sub
End Class