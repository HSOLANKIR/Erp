Public Class Group_Formula_Laboratry_ctrl
    Public obj As Object
    Public Head As String
    Private Sub Group_Formula_Laboratry_ctrl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Txt1.Text = obj.Text
        Label1.Text = Head & " Formula"
        Txt1.Focus()
    End Sub

    Private Sub Txt1_TextChanged(sender As Object, e As EventArgs) Handles Txt1.TextChanged

    End Sub

    Private Sub Txt1_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt1.KeyDown
        If e.KeyCode = Keys.Enter Then
            obj.Text = Txt1.Text
            Me.Dispose()
        End If
    End Sub
End Class
