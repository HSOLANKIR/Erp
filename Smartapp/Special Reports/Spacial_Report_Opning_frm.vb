Public Class Spacial_Report_Opning_frm
    Public path As String
    Dim proc As Process

    Private Sub Spacial_Report_Opning_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        obj_center(sender, Me)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Val(Now.Second) < 55 Then
            Dim Code As String = ((Val(Now.Date.Day) + Val(Now.Date.Minute) + Val(Now.Date.Hour) & Val(Val(Now.TimeOfDay.Hours + Now.TimeOfDay.Minutes & Now.Date.Month + Now.Date.Day)) + Val(Val(Now.Date.Year))) - Val(Now.TimeOfDay.Minutes) + Val(Now.TimeOfDay.Minutes)) * 12552
            Dim str As String = $"{Code}|{Connection_Path & "\" & Connection_Data}"

            proc = Process.Start(path, str)
            Threading.Thread.Sleep(2000)
            SetParent(proc.MainWindowHandle, BG_Head_frm.Panel3.Handle)
            SendMessage(proc.MainWindowHandle, 274, 61488, 0)

            Timer1.Stop()

            Me.Dispose()

        End If
    End Sub
End Class