Imports System.ComponentModel

Public Class Transport_Tred_Details_diaload
    Private Sub Transport_Tred_Details_diaload_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With vc_Transport
            Txt1.Text = Val(.Vebrij_Vihical)
            Txt2.Text = Val(.Vebrij_Gross)
            Txt3.Text = Val(.Vebrij_Net)
        End With
        SendKeys.Send("+{TAB}")
    End Sub
    Private Function Cal()
        Txt3.Text = Val(Txt2.Text) - Val(Txt1.Text)
    End Function

    Private Sub Txt2_TextChanged(sender As Object, e As EventArgs) Handles Txt2.TextChanged
        Cal()

    End Sub

    Private Sub Txt1_TextChanged(sender As Object, e As EventArgs) Handles Txt1.TextChanged
        Cal()

    End Sub

    Private Sub Txt1_Enter(sender As Object, e As EventArgs) Handles Txt1.Enter, Txt1.LostFocus, Txt1.GotFocus
        sender.Font = New Font("Arial", 26, FontStyle.Bold)
    End Sub
    Private Sub Txt2_Enter(sender As Object, e As EventArgs) Handles Txt2.Enter, Txt2.LostFocus, Txt2.GotFocus
        sender.Font = New Font("Arial", 26, FontStyle.Bold)
    End Sub
    Private Sub Txt3_Enter(sender As Object, e As EventArgs) Handles Txt3.Enter, Txt3.LostFocus, Txt3.GotFocus
        sender.Font = New Font("Arial", 26, FontStyle.Bold)
    End Sub

    Private Sub Transport_Tred_Details_diaload_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = DialogResult.Cancel
            Me.Dispose()
        End If
    End Sub

    Private Sub Transport_Tred_Details_diaload_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Me.Dispose()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        vc_Transport.Vebrij_Gross = Val(Txt2.Text)
        vc_Transport.Vebrij_Vihical = Val(Txt1.Text)
        vc_Transport.Vebrij_Net = Val(Txt3.Text)
        Me.DialogResult = DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub Button1_KeyDown(sender As Object, e As KeyEventArgs) Handles Button1.KeyDown
        If e.KeyCode = Keys.Back Then
            SendKeys.Send("+{TAB}")
        End If

    End Sub
End Class