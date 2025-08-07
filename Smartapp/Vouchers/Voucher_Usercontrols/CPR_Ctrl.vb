Public Class CPR_Ctrl

    Private Sub CPR_Ctrl_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub CPR_Ctrl_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged

    End Sub

    Private Sub CPR_Ctrl_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
        End If
    End Sub

    Private Sub Particuls_TXT_TextChanged(sender As Object, e As EventArgs) Handles Particuls_TXT.TextChanged

    End Sub

    Private Sub Particuls_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles Particuls_TXT.KeyDown
        If e.KeyCode = Keys.Enter Then
            Amount_TXT.Focus()

        End If
    End Sub
    Public Grid As DataGridView
    Private Sub CPR_Ctrl_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        Particuls_TXT.Focus()
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
    End Sub
End Class
