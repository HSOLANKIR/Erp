Public Class network_error_ctrl
    Public obj_ As Object
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Application.Exit()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If My.Computer.Network.IsAvailable = True Then
            obj_.Dispose()
        End If
    End Sub

    Private Sub network_error_ctrl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Timer1.Start()

    End Sub
End Class
