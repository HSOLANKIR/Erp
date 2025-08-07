Imports System.ComponentModel

Public Class Whatsapp_Home_Dialoag
    Private Sub Whatsapp_Home_Dialoag_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Close_Fales(Me)
    End Sub

    Private Sub Server_Panel_Paint(sender As Object, e As PaintEventArgs)
        obj_center(sender, Me)
    End Sub

    Private Function Count_()
        Label2.Text = (Val(Label21.Text) + Val(Label6.Text) + Val(Label10.Text) + Val(Label13.Text))
        Label12.Text = Val(Label18.Text) - (Val(Label2.Text) + Val(Label22.Text))
    End Function

    Private Sub Label18_Click(sender As Object, e As EventArgs) Handles Label18.Click

    End Sub

    Private Sub Label18_TextChanged(sender As Object, e As EventArgs) Handles Label18.TextChanged, Label21.TextChanged, Label6.TextChanged, Label10.TextChanged, Label13.TextChanged, Label22.TextChanged
        Count_()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Push_btn.Click
        Push_btn.Visible = False
        Start_btn.Visible = True
        Stop_btn.Visible = True
        Restart_btn.Visible = True

        Whatsapp_Home.Push_Msg()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Stop_btn.Click
        Push_btn.Visible = False
        Stop_btn.Visible = False
        Start_btn.Visible = True
        Restart_btn.Visible = True

        Whatsapp_Home.Stop_Msg()

        Me.Dispose()

    End Sub

    Private Sub start_btn_Click(sender As Object, e As EventArgs) Handles Start_btn.Click
        Whatsapp_Home.start_btn.PerformClick()

        If Whatsapp_Home.start_btn.Visible = False Then
            Push_btn.Visible = True
            Stop_btn.Visible = True
            Start_btn.Visible = False
            Restart_btn.Visible = False
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Restart_btn.Click
        Whatsapp_Home.Restart_Msg()
        start_btn_Click(e, e)
    End Sub

    Private Sub Whatsapp_Home_Dialoag_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        Whatsapp_Home.Stop_Msg()
    End Sub

    Private Sub Whatsapp_Home_Dialoag_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Me.Dispose()
    End Sub

    Private Sub ProgressBag_Custom1_Load(sender As Object, e As EventArgs) Handles ProgressBag_Custom1.Load

    End Sub
End Class