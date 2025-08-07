Imports System.IO
Imports System.Drawing.Imaging

Public Class Document_view_frm
    Public Byt As Byte()
    Public Name As String
    Public Formett As String
    Public Narra As String
    Private Sub Document_view_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim imgstrm As New MemoryStream
            imgstrm = New MemoryStream(Byt)
            PictureBox1.Image = Drawing.Image.FromStream(imgstrm)
        Catch ex As Exception
            Me.Dispose()
            Msg(NOT_Type.Erro, "File formate Error", "")
        End Try
        Label1.Text = Name
        Label2.Text = Narra
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim ms As New MemoryStream(Byt)

        SaveFileDialog1.FileName = Label1.Text
        SaveFileDialog1.Title = "Save Document"
        If SaveFileDialog1.ShowDialog = DialogResult.OK Then
            Dim file As New FileStream(SaveFileDialog1.FileName & Formett, FileMode.Create, FileAccess.Write)
            ms.WriteTo(file)
            file.Close()
            ms.Close()
        End If
    End Sub

    Private Sub Document_view_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class