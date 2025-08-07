Public Class Head_ctrl
    Public Property Head As String = ""
    Private Sub Head_ctrl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Refresh_()
    End Sub
    Public Function Refresh_()
        Label1.Text = Head
    End Function
End Class
