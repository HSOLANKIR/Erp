Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.IO

Public Class License_LInk_frm
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)
        obj_center(sender, Me)
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Application.Exit()
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Process.Start("cryptonix://license_details")
    End Sub
    Public Function Panel_Manage(p As Panel)
        If (p.Name = Expiar_Panel.Name And Expiar_Panel.Visible = True) Or (p.Name = Not_Found.Name And Not_Found.Visible = True) Then
        Else
            Expiar_Panel.Visible = False
            Not_Found.Visible = False

            obj_center(p, Me)
            p.Visible = True
        End If

    End Function
    Private Sub License_LInk_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Application.Exit()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Process.Start("cryptonix://link_license")
    End Sub
End Class