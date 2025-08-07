Imports OpenQA.Selenium
Imports OpenQA.Selenium.Support.UI
Imports System.ComponentModel
Imports System.Net.Mail
Imports System.Threading
Public Class Email_Sending_list
    Public Enable_ As Boolean = False
    Public isBusy As Boolean = True
    Private Sub Whatsapp_Sending_list_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Close_Fales(Me)
        Email_frm = Find_DT_Value(Database_File.cmp, "TBL_Email_Login", "Email Address", "[Email Address] <> ''")
        password_frm = Find_DT_Value(Database_File.cmp, "TBL_Email_Login", "Password", "[Email Address] <> ''")
        smtp_server = Find_DT_Value(Database_File.cmp, "TBL_Email_Login", "Outgoing SMTP", "[Email Address] <> ''")
        smtp_port = Find_DT_Value(Database_File.cmp, "TBL_Email_Login", "Server Port", "[Email Address] <> ''")

        Send_back.RunWorkerAsync()
    End Sub
    Private Sub OnApplicationExit(ByVal sender As Object, ByVal e As EventArgs)
        Try

        Catch
        End Try
    End Sub
    Private Sub Send_back_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles Send_back.DoWork
        For i As Integer = 0 To Grid1.Rows.Count - 1
            Dim ro As DataGridViewRow = Grid1.Rows(i)
            Dim Status As String = ro.Cells(5).Value
            If Status = "Pending" Then
                isBusy = True
                Send_back.ReportProgress(i)
                ro.Cells(5).Value = Send_(ro)
                ro.Cells(6).Value = DateTime.Now.ToString("hh:mm:ss tt")
            End If
        Next
    End Sub
    Public Function Add_to_list(name As String, emal As String, subject As String, msg As String, attage As String) As String
        Dim idx As Integer = 0
        idx = Grid1.Rows.Count - 1
        Grid1.Rows.Add(name, emal, subject, msg, attage, "Pending")
        If Formate_Email(emal) = False Then
            Grid1.Rows(idx).Cells(5).Value = "email is incorrect"
            Grid1.Rows(idx).Cells(6).Value = DateTime.Now.ToString("hh:mm:ss tt")
        End If

        If isBusy = False Then
            Send_back.RunWorkerAsync()
            Me.Visible = True
        End If
        Return idx
    End Function
    Private Function whatsapp_number_verifid(numb As String)
        If numb.Length = 10 Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub Send_back_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles Send_back.RunWorkerCompleted
        isBusy = False
        'Send_back.RunWorkerAsync()
        Grid1.Rows.Clear()
        Me.Visible = False
    End Sub
    'Dim cn_yn As Boolean = False
    Dim Email_frm As String = ""
    Dim password_frm As String = ""
    Dim smtp_server As String = ""
    Dim smtp_port As String = ""
    Private Function Send_(ro As DataGridViewRow) As String
        Dim Name_ As String = ro.Cells(0).Value.ToString
        Dim Email_to As String = ro.Cells(1).Value.ToString
        Dim subject As String = ro.Cells(2).Value.ToString
        Dim body As String = ro.Cells(3).Value.ToString
        Dim attage_ As String = ro.Cells(4).Value.ToString
        Dim status As String = ro.Cells(5).Value.ToString

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

            Return "Success"
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Private Sub Grid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid1.CellContentClick

    End Sub

    Private Sub Grid1_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles Grid1.RowPrePaint
        Dim ro As DataGridViewRow = Grid1.Rows(e.RowIndex)
        If ro.Cells(5).Value = "Pending" Then
            ro.DefaultCellStyle.ForeColor = Color.Black
        ElseIf ro.Cells(5).Value = "Success" Then
            ro.DefaultCellStyle.ForeColor = Color.Green
        Else
            ro.DefaultCellStyle.ForeColor = Color.Red
        End If
    End Sub
    Private Sub Send_back_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles Send_back.ProgressChanged
        ProgressBag_Custom1.Maximum = Grid1.Rows.Count - 0
        ProgressBag_Custom1.Run(e.ProgressPercentage)

        ProgressBag_Custom1.Last_TXT = "/" & Grid1.Rows.Count - 0

    End Sub
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click, PictureBox1.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
    End Sub

    Private Sub ProgressBag_Custom1_Load(sender As Object, e As EventArgs) Handles ProgressBag_Custom1.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Grid1.Rows.Add("Hit Solanki", "info.hitsolanki.in@gmail.com", "Try email", "Hello word", "C:\Users\infoh\Downloads\invoice.pdf", "Pending")
        'Grid1.Rows.Add("Hit Solanki", "info.hitsolanki.in@gmail.com", "no attage", "Hello word", "", "Pending")

        Button2.Visible = False
        Send_back.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork

    End Sub
End Class