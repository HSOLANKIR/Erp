Imports System.ComponentModel
Imports System.Data.SQLite
Imports System.Net.Mail

Public Class Direct_Communication_frm
    Public Property path_ As String
    Private Sub Direct_Communication_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Close_Fales(Me)
        Fill_Source()


        Email_frm = Find_DT_Value(Database_File.cmp, "TBL_Email_Login", "Email Address", "[Email Address] <> ''")
        password_frm = Find_DT_Value(Database_File.cmp, "TBL_Email_Login", "Password", "[Email Address] <> ''")
        smtp_server = Find_DT_Value(Database_File.cmp, "TBL_Email_Login", "Outgoing SMTP", "[Email Address] <> ''")
        smtp_port = Find_DT_Value(Database_File.cmp, "TBL_Email_Login", "Server Port", "[Email Address] <> ''")

        'Button2.Focus()



        Label2.Visible = Email_YN_fech
        Label5.Visible = Whatsapp_YN_fech



        If bg_Panel.Controls.Count = 0 Then
            With Add_New()
                .List_set()
            End With

        End If
    End Sub
    Public Function Fill_Source()
        Dim dt As New DataTable
        dt.Columns.Add("Name")
        dt.Columns.Add("Alias")
        dt.Columns.Add("WhatsApp")
        dt.Columns.Add("Email")

        dt.Rows.Add("", "Custom", "", "")
        dt.Rows.Add("End of List", "", "", "")
        Dim r As SQLiteDataReader

        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select [ID],[Name],[Alise],[Phone],[Email]
from TBL_Ledger LD", cn)

            r = cmd.ExecuteReader
            While r.Read
                dt.Rows.Add(r("Name").ToString, r("Alise").ToString, r("Phone").ToString, r("Email").ToString)
            End While
            Ledger_Source.DataSource = dt
        End If
    End Function
    Private Function List_set()

    End Function

    Public Function Add_list(Name As String, Whatsapp As String, email As String, subject As String, message As String, type_msg As String, attage_path As String, attage_type As String)
        Dim dt As New DataTable
        dt.Columns.Add("Name")
        dt.Columns.Add("Alias")
        dt.Columns.Add("Phone")
        dt.Columns.Add("Email")

        dt.Rows.Add("", "Custom", "", "")
        dt.Rows.Add("End of List", "", "", "")

        Ledger_Source.DataSource = dt

        With Add_New()
            .List_set()

            .Name_TXT.Text = Name
            .Wh_TXT.Text = Whatsapp
            .Email_TXT.Text = email
            .Subject_ = subject
            .Message_ = message
            .Type_of_message_ = type_msg
            .Attached_ = attage_path
            .Attached_Type_ = attage_type
        End With
    End Function
    Public Function Add_New() As Communication_Direct_list_ctrl
        Dim ctrl As New Communication_Direct_list_ctrl
        With ctrl
            bg_Panel.Controls.Add(ctrl)
            .Dock = DockStyle.Top
            .BringToFront()

            .ID_ = bg_Panel.Controls.Count
        End With
        Return ctrl
    End Function

    Public Function Start_() As Boolean
        ProgressBag2.Value = 0
        ProgressBag2.Run(0)


        ProgressBag2.Maximum = bg_Panel.Controls.Count
        Label8.Text = $"{ProgressBag2.Value} / {ProgressBag2.Maximum} Complete"


        Send_background.RunWorkerAsync()
    End Function

    Private Sub Send_background_DoWork(sender As Object, e As DoWorkEventArgs) Handles Send_background.DoWork
        Dim fil As String = ""
        If ifSingal = True Then
            fil = Whatsapp_Upload_file(path_)
        End If


        Dim P1_ As New Queue(Of Communication_Direct_list_ctrl)()
        For Each bg_p As Communication_Direct_list_ctrl In bg_Panel.Controls.OfType(Of Communication_Direct_list_ctrl)()
            P1_.Enqueue(bg_p)
        Next
        For Each c As Communication_Direct_list_ctrl In P1_.Reverse
            Dim Status_W As String = c.wh_status.Text
            Dim Status_E As String = c.email_status.Text
            c.Color_(Color.FromArgb(255, 238, 178))
            If (Status_E = "Pending" Or Status_W = "Pending") Then
                If Status_W = "Pending" And c.Wh_TXT.Text.Trim <> "" Then
                    c.wh_status.Text = "Processing"
                    Send_W(c, fil)
                End If
                If Status_E = "Pending" And c.Email_TXT.Text.Trim <> "" Then
                    c.email_status.Text = "Processing"
                    Send_E(c)
                End If
            End If
            c.Color_(Color.White)


            ProgressBag2.Value = ProgressBag2.Value + 1
            ProgressBag2.Run(0)

            Label8.Text = $"{ProgressBag2.Value} / {ProgressBag2.Maximum} Complete"
            Label1.Text = $"{N2_FORMATE(Val(ProgressBag2.Value * 100) / Val(ProgressBag2.Maximum))} %"
        Next

        If ifSingal = True Then
            Whatsapp_delete_file(fil)
        End If
    End Sub
    Dim Email_frm As String = ""
    Dim password_frm As String = ""
    Dim smtp_server As String = ""
    Dim smtp_port As String = ""

    Private Function Send_W(c As Communication_Direct_list_ctrl, fil As String)
        Dim Name_ As String = c.Name_
        Dim wh_no As String = c.Wh_TXT.Text
        Dim msg As String = c.Message_
        Dim attage_ As String = c.Attached_

        Try
            Dim str() As String
            If ifSingal = True Then
                str = Whatsapp_call_document("91" & wh_no, msg, whmedia_type.pdf, fil, False, False)
            Else
                str = Whatsapp_call_document("91" & wh_no, msg, whmedia_type.pdf, attage_, True, True)
            End If


            If str(0) = True Then
                c.wh_status.Text = "Success"
                c.wh_status.ForeColor = Color.Green
            Else
                c.wh_status.Text = str(1)
                c.wh_status.ForeColor = Color.Red
            End If
        Catch ex As Exception

        End Try
    End Function
    Private Function Send_E(c As Communication_Direct_list_ctrl)
        Dim Name_ As String = c.Name_
        Dim Email_to As String = c.Email_TXT.Text
        Dim subject As String = c.Subject_
        Dim body As String = c.Message_
        Dim attage_ As String = c.Attached_

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

            c.email_status.Text = "Success"
            c.email_status.ForeColor = Color.Green
        Catch ex As Exception
            c.email_status.Text = ex.Message
            c.email_status.ForeColor = Color.Red
        End Try
    End Function

    Private Sub Send_background_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles Send_background.RunWorkerCompleted
        Button1.Visible = False
        Button2.Visible = True
        Me.Dispose()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Send_background.CancelAsync()
    End Sub

    Private Sub Send_background_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles Send_background.ProgressChanged
        'Progress.Value = (e.ProgressPercentage)
        'Progress.Run(0)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Start_()
        Button2.Visible = False
        Button1.Visible = True
        Button1.Focus()
    End Sub

    Private Sub feebank_P_Paint(sender As Object, e As PaintEventArgs) Handles feebank_P.Paint
        obj_center(sender, Me)
    End Sub

    Private Sub Direct_Communication_frm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Me.Dispose()
    End Sub

    Private Sub Button2_KeyDown(sender As Object, e As KeyEventArgs) Handles Button2.KeyDown
        If e.KeyCode = Keys.Back Then
            SendKeys.Send("+{TAB}")
        End If
    End Sub

    Private Sub Direct_Communication_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub
End Class