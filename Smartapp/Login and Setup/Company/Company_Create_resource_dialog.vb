Imports System.ComponentModel

Public Class Company_Create_resource_dialog
    Private Sub Company_Create_resource_dialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With Company_Creation_frm
            PictureBox1.Image = .PictureBox1.Image
            PictureBox2.Image = .PictureBox2.Image
            PictureBox3.Image = .PictureBox3.Image
            Logo_ = .Logo_
            Stamp_ = .Stamp_
            Sig_ = .Sig_
        End With
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With Company_Creation_frm


            .PictureBox1.Image = Nothing
            .PictureBox2.Image = Nothing
            .PictureBox3.Image = Nothing

            If PictureBox1.Image IsNot Nothing Then
                .PictureBox1.Image = PictureBox1.Image
            End If

            If PictureBox2.Image IsNot Nothing Then
                .PictureBox2.Image = PictureBox2.Image
            End If

            If PictureBox3.Image IsNot Nothing Then
                .PictureBox3.Image = PictureBox3.Image
            End If


            .Logo_ = Logo_
            .Stamp_ = Stamp_
            .Sig_ = Sig_
        End With
        Me.DialogResult = DialogResult.OK
        Me.Dispose()

        Company_Creation_frm.Yn1.Focus()
        SendKeys.Send("{TAB}")
    End Sub
    Public Logo_() As Byte
    Public Stamp_() As Byte
    Public Sig_() As Byte

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim OpenFile As New OpenFileDialog()
        Try
            With OpenFile
                .FileName = ""
                .Title = "LOGO:"
                .Filter = "Company Logo : (*.png)|*.png"
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    Logo_ = Byte_(.FileName)
                    Me.PictureBox1.Image = System.Drawing.Image.FromFile(.FileName)
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Error...")
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim OpenFile As New OpenFileDialog()
        Try
            With OpenFile
                .FileName = ""
                .Title = "Stamp:"
                .Filter = "Company Stamp : (*.png)|*.png"
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    Stamp_ = Byte_(.FileName)
                    Me.PictureBox2.Image = System.Drawing.Image.FromFile(.FileName)
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Error...")
        End Try
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim OpenFile As New OpenFileDialog()
        Try
            With OpenFile
                .FileName = ""
                .Title = "Signatory:"
                .Filter = "Authorised Signatory : (*.png)|*.png"
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    Sig_ = Byte_(.FileName)
                    Me.PictureBox3.Image = System.Drawing.Image.FromFile(.FileName)
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Error...")
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        PictureBox1.Image = Nothing
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        PictureBox2.Image = Nothing
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        PictureBox3.Image = Nothing
    End Sub

    Private Sub Company_Create_resource_dialog_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub Company_Create_resource_dialog_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Me.Dispose()
    End Sub

    Private Sub Company_Create_resource_dialog_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        If Me.DialogResult = DialogResult.OK Then

        Else
            Company_Creation_frm.Yn1.Focus()
            Company_Creation_frm.Yn1.Text = "No"
        End If
    End Sub
End Class