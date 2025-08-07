Imports System.ComponentModel

Public Class Attage_Password
    Public Password As String
    Public Status_ As Boolean
    Private Sub Attage_Password_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CenterToScreen()
        Top = 0
        Me.Height = 0
        Me.Text = Application_Name & " Security"
        Txt1.Focus()
        Timer1.Start()
    End Sub

    Private Sub Attage_Password_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            result = DialogResult.No
            Timer2.Start()
        End If
    End Sub

    Private Sub Attage_Password_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        Frm_foCus()
    End Sub

    Private Sub Txt1_TextChanged(sender As Object, e As EventArgs) Handles Txt1.TextChanged
        NOT_Clear()
    End Sub
    Dim result As DialogResult
    Private Sub Txt1_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Txt1.Text = Password Then
                PictureBox1.Image = My.Resources.Success_animation_icn
                Timer2.Start()
                result = DialogResult.Yes
            Else
                Txt1.SelectionStart = 0
                NOT_("incorrect Password", NOT_Type.Erro)
            End If
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        Panel1.Location = New Point(Me.ClientSize.Width / 2 - Panel1.Size.Width / 2, Me.ClientSize.Height / 2 - Panel1.Size.Height / 2)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.Height += 10

        If Me.Height >= 223 Then
            Timer1.Stop()
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Me.Height -= 5

        If Me.Height <= 5 Then
            Timer2.Stop()
            Me.DialogResult = result
            Me.Dispose()
        End If
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Timer2.Start()
    End Sub
End Class