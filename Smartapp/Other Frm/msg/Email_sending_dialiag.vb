Imports System.ComponentModel
Imports System.Net.Mail

Public Class Email_sending_dialiag
    Private Sub Email_sending_dialiag_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Dim Email_Add As String
    Dim Email_Subj As String
    Dim Email_Mess As String
    Dim Issuccess As Boolean = False
    Dim HTML_Body As Boolean = False

    Public Function EMAIL(Email_Address As String, SubJect As String, Message As String, isHTML_Body As Boolean) As DialogResult
        Dim ms As New Email_sending_dialiag
        With ms
            .Email_Add = Email_Address
            .Email_Subj = SubJect
            .Email_Mess = Message
            .HTML_Body = isHTML_Body
            .FormBorderStyle = FormBorderStyle.None
            .Email_Sending_Background.RunWorkerAsync()
            .Location = New Point(BG_frm.BG_PAN.Width - .Width, (((BG_frm.BG_PAN.PointToScreen(New Point(0, 0)).Y)) - Me.Height) + BG_frm.BG_PAN.Height)
        End With
        Return ms.ShowDialog()
    End Function
    Private Sub Email_Sending_Background_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles Email_Sending_Background.DoWork
        Try
            Dim mail As New MailMessage
            Dim SMTPServee As New SmtpClient
            mail.From = New MailAddress(Send_Email)
            mail.Subject = Email_Subj
            mail.To.Add(Email_Add)
            mail.IsBodyHtml = HTML_Body
            mail.Body = Email_Mess
            Dim SMTP As New SmtpClient("smtp.gmail.com")
            SMTP.EnableSsl = True
            SMTP.Credentials = New Net.NetworkCredential(Send_Email, Send_Email_Password)
            SMTP.Port = "587"
            SMTP.Send(mail)
            Issuccess = True
        Catch ex As Exception
            Issuccess = False
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Email_Sending_Background_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles Email_Sending_Background.RunWorkerCompleted
        If Issuccess = True Then
            Me.DialogResult = DialogResult.Yes
        Else
            Me.DialogResult = DialogResult.No
        End If
        Me.Dispose()
    End Sub
End Class