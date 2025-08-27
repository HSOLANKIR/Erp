Public Class UserControl1
    Public Property DataIndex As Integer
    Private Sub UserControl1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Function SetData(str As String)
        Label1.Text = str
    End Function
End Class
