Imports System.ComponentModel
Imports System.Net.Mail

Public Class Direct_Communication_frm
    Private Sub Direct_Communication_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Close_Fales(Me)

        PictureBox1.Image = My.Resources.Resources.sending_animation_gif

        Email_frm = Find_DT_Value(Database_File.cmp, "TBL_Email_Login", "Email Address", "[Email Address] <> ''")
        password_frm = Find_DT_Value(Database_File.cmp, "TBL_Email_Login", "Password", "[Email Address] <> ''")
        smtp_server = Find_DT_Value(Database_File.cmp, "TBL_Email_Login", "Outgoing SMTP", "[Email Address] <> ''")
        smtp_port = Find_DT_Value(Database_File.cmp, "TBL_Email_Login", "Server Port", "[Email Address] <> ''")

        Start_()

        Progress.Maximum = Grid1.Rows.Count - 1
    End Sub
    Public Function Add_list(Name As String, Whatsapp As String, email As String, subject As String, message As String, type_msg As String, attage_path As String, attage_type As String)
        With Grid1
            Dim wh_s As String = "Pending"
            Dim em_s As String = "Pending"
            If Whatsapp.ToString = "" Then
                wh_s = "NA"
            End If
            If email.ToString = "" Then
                em_s = "NA"
            End If

            .Rows.Add(Name, Whatsapp, email, subject, message, type_msg, attage_path, attage_type, wh_s, em_s)
        End With
    End Function
    Public Function Start_() As Boolean
        Send_background.RunWorkerAsync()

    End Function

    Private Sub Send_background_DoWork(sender As Object, e As DoWorkEventArgs) Handles Send_background.DoWork
        For i As Integer = 0 To Grid1.Rows.Count - 1
            Dim ro As DataGridViewRow = Grid1.Rows(i)
            Dim Status_W As String = ro.Cells(8).Value.ToString
            Dim Status_E As String = ro.Cells(9).Value.ToString

            ro.DefaultCellStyle.BackColor = Color.FromArgb(255, 238, 178)

            If (Status_E = "Pending" Or Status_W = "Pending") Then
                If Status_W = "Pending" Then
                    ro.Cells(8).Value = "Processing"
                    Send_W(ro)
                End If
                If Status_E = "Pending" Then
                    ro.Cells(9).Value = "Processing"
                    Send_E(ro)
                End If
            End If
            Send_background.ReportProgress(i)
            ro.DefaultCellStyle.BackColor = Color.White
        Next
    End Sub
    Dim Email_frm As String = ""
    Dim password_frm As String = ""
    Dim smtp_server As String = ""
    Dim smtp_port As String = ""

    Private Function Send_W(ro As DataGridViewRow)
        Dim Name_ As String = ro.Cells(0).Value.ToString
        Dim wh_no As String = ro.Cells(1).Value.ToString
        Dim msg As String = ro.Cells(4).Value.ToString
        Dim attage_ As String = ro.Cells(6).Value.ToString
        Dim status As String = ro.Cells(8).Value.ToString

        Try
            Dim str() As String = Whatsapp_call_document("91" & wh_no, msg, whmedia_type.pdf, attage_, True, True)

            If str(0) = True Then
                ro.Cells(8).Value = "Success"
                ro.Cells(8).Style.BackColor = Color.Green
            Else
                ro.Cells(8).Value = str(1)
                ro.Cells(8).Style.BackColor = Color.Red
            End If
        Catch ex As Exception

        End Try
    End Function
    Private Function Send_E(ro As DataGridViewRow)
        Dim Name_ As String = ro.Cells(0).Value.ToString
        Dim Email_to As String = ro.Cells(2).Value.ToString
        Dim subject As String = ro.Cells(3).Value.ToString
        Dim body As String = ro.Cells(4).Value.ToString
        Dim attage_ As String = ro.Cells(6).Value.ToString
        Dim status As String = ro.Cells(9).Value.ToString

        Try
            Dim mail As New MailMessage
            Dim SMTPServee As New SmtpClient
            mail.From = New MailAddress(Email_frm)
            mail.Subject = subject
            mail.To.Add(Email_to)
            mail.IsBodyHtml = True
            mail.Body = body

            If attage_.Length > 1 Then
                Dim data As Attachment = New Attachment(attage_)
                mail.Attachments.Add(data)
            End If

            Dim SMTP As New SmtpClient(smtp_server)
            SMTP.EnableSsl = True
            SMTP.Credentials = New Net.NetworkCredential(Email_frm, password_frm)
            SMTP.Port = smtp_port
            SMTP.Send(mail)

            ro.Cells(9).Value = "Success"
            ro.Cells(9).Style.BackColor = Color.Green
        Catch ex As Exception
            ro.Cells(9).Value = ex.Message
            ro.Cells(9).Style.BackColor = Color.Red
        End Try
    End Function

    Private Sub Send_background_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles Send_background.RunWorkerCompleted
        Me.Dispose()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Send_background.CancelAsync()
        Me.Dispose()
    End Sub

    Private Sub Send_background_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles Send_background.ProgressChanged
        Progress.Value = (e.ProgressPercentage)
        Progress.Run(0)
    End Sub
End Class