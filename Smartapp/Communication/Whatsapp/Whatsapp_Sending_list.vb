Imports OpenQA.Selenium
Imports OpenQA.Selenium.Support.UI
Imports System.ComponentModel
Imports System.Net.Mail
Imports System.Threading

Public Class Whatsapp_Sending_list
    Public Enable_ As Boolean = False
    Public isBusy As Boolean = False
    Private Sub Whatsapp_Sending_list_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Close_Fales(Me)
        Grid1.Columns(8).DisplayIndex = 7
        Grid1.Columns(9).DisplayIndex = 2

        Email_frm = Find_DT_Value(Database_File.cmp, "TBL_Email_Login", "Email Address", "[Email Address] <> ''")
        password_frm = Find_DT_Value(Database_File.cmp, "TBL_Email_Login", "Password", "[Email Address] <> ''")
        smtp_server = Find_DT_Value(Database_File.cmp, "TBL_Email_Login", "Outgoing SMTP", "[Email Address] <> ''")
        smtp_port = Find_DT_Value(Database_File.cmp, "TBL_Email_Login", "Server Port", "[Email Address] <> ''")


        Send_back.RunWorkerAsync()
        'BG_frm.PictureBox1.Image = My.Resources.email_send_animation_icn
        'BG_frm.Label1.Text = "E-Mail Sending"
    End Sub
    Dim Email_frm As String = ""
    Dim password_frm As String = ""
    Dim smtp_server As String = ""
    Dim smtp_port As String = ""

    Dim under_TXT As String
    Private Sub Send_back_DoWork(sender As Object, e As DoWorkEventArgs) Handles Send_back.DoWork
        For i As Integer = 0 To Grid1.Rows.Count - 1
            Dim ro As DataGridViewRow = Grid1.Rows(i)
            Dim Status_W As String = ro.Cells(6).Value.ToString
            Dim Status_E As String = ro.Cells(8).Value.ToString
            If (Status_E = "Pending" Or Status_W = "Pending") Then
                isBusy = True
                BG_frm.Backgroud_Prossecc = True
                under_TXT = $"{ro.Index} Sent of {Grid1.Rows.Count}"

                If Status_E = "Pending" Then
                    ro.Cells(8).Value = "Processing"
                    Send_E(ro)
                End If
                If Status_W = "Pending" Then
                    ro.Cells(8).Value = "Processing"
                    Send_W(ro)
                End If
                Send_back.ReportProgress(i)
            End If
        Next
    End Sub
    Private Function temp() As String
        Dim st As String = "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'><html dir='ltr' xmlns='http://www.w3.org/1999/xhtml' xmlns:o='urn:schemas-microsoft-com:office:office' lang='en'><head><meta charset='UTF-8'><meta content='width=device-width, initial-scale=1' name='viewport'><meta name='x-apple-disable-message-reformatting'><meta http-equiv='X-UA-Compatible' content='IE=edge'><meta content='telephone=no' name='format-detection'><title>New Template 3</title> <!--[if (mso 16)]><style type='text/css'>     a {text-decoration: none;}     </style><![endif]--> <!--[if gte mso 9]><style>sup { font-size: 100% !important; }</style><![endif]--> <!--[if gte mso 9]><xml> <o:OfficeDocumentSettings> <o:AllowPNG></o:AllowPNG> <o:PixelsPerInch>96</o:PixelsPerInch> </o:OfficeDocumentSettings> </xml>
<![endif]--><style type='text/css'>.rollover:hover .rollover-first { max-height:0px!important; display:none!important; } .rollover:hover .rollover-second { max-height:none!important; display:block!important; } .rollover span { font-size:0px; } u + .body img ~ div div { display:none; } #outlook a { padding:0; } span.MsoHyperlink,span.MsoHyperlinkFollowed { color:inherit; mso-style-priority:99; } a.es-button { mso-style-priority:100!important; text-decoration:none!important; } a[x-apple-data-detectors] { color:inherit!important; text-decoration:none!important; font-size:inherit!important; font-family:inherit!important; font-weight:inherit!important; line-height:inherit!important; } .es-desk-hidden { display:none; float:left; overflow:hidden; width:0; max-height:0; line-height:0; mso-hide:all; } .es-button-border:hover > a.es-button { color:#ffffff!important; }
@media only screen and (max-width:600px) {*[class='gmail-fix'] { display:none!important } p, a { line-height:150%!important } h1, h1 a { line-height:120%!important } h2, h2 a { line-height:120%!important } h3, h3 a { line-height:120%!important } h4, h4 a { line-height:120%!important } h5, h5 a { line-height:120%!important } h6, h6 a { line-height:120%!important } h1 { font-size:36px!important; text-align:left } h2 { font-size:26px!important; text-align:left } h3 { font-size:20px!important; text-align:left } h4 { font-size:24px!important; text-align:left } h5 { font-size:20px!important; text-align:left } h6 { font-size:16px!important; text-align:left } .es-header-body h1 a, .es-content-body h1 a, .es-footer-body h1 a { font-size:36px!important } .es-header-body h2 a, .es-content-body h2 a, .es-footer-body h2 a { font-size:26px!important } .es-header-body h3 a, .es-content-body h3 a, .es-footer-body h3 a { font-size:20px!important }
 .es-header-body h4 a, .es-content-body h4 a, .es-footer-body h4 a { font-size:24px!important } .es-header-body h5 a, .es-content-body h5 a, .es-footer-body h5 a { font-size:20px!important } .es-header-body h6 a, .es-content-body h6 a, .es-footer-body h6 a { font-size:16px!important } .es-menu td a { font-size:12px!important } .es-header-body p, .es-header-body a { font-size:14px!important } .es-content-body p, .es-content-body a { font-size:14px!important } .es-footer-body p, .es-footer-body a { font-size:14px!important } .es-infoblock p, .es-infoblock a { font-size:12px!important } .es-m-txt-c, .es-m-txt-c h1, .es-m-txt-c h2, .es-m-txt-c h3, .es-m-txt-c h4, .es-m-txt-c h5, .es-m-txt-c h6 { text-align:center!important } .es-m-txt-r, .es-m-txt-r h1, .es-m-txt-r h2, .es-m-txt-r h3, .es-m-txt-r h4, .es-m-txt-r h5, .es-m-txt-r h6 { text-align:right!important }
 .es-m-txt-j, .es-m-txt-j h1, .es-m-txt-j h2, .es-m-txt-j h3, .es-m-txt-j h4, .es-m-txt-j h5, .es-m-txt-j h6 { text-align:justify!important } .es-m-txt-l, .es-m-txt-l h1, .es-m-txt-l h2, .es-m-txt-l h3, .es-m-txt-l h4, .es-m-txt-l h5, .es-m-txt-l h6 { text-align:left!important } .es-m-txt-r img, .es-m-txt-c img, .es-m-txt-l img { display:inline!important } .es-m-txt-r .rollover:hover .rollover-second, .es-m-txt-c .rollover:hover .rollover-second, .es-m-txt-l .rollover:hover .rollover-second { display:inline!important } .es-m-txt-r .rollover span, .es-m-txt-c .rollover span, .es-m-txt-l .rollover span { line-height:0!important; font-size:0!important } .es-spacer { display:inline-table } a.es-button, button.es-button { font-size:20px!important; line-height:120%!important } a.es-button, button.es-button, .es-button-border { display:inline-block!important } .es-m-fw, .es-m-fw.es-fw, .es-m-fw .es-button { display:block!important }
 .es-m-il, .es-m-il .es-button, .es-social, .es-social td, .es-menu { display:inline-block!important } .es-adaptive table, .es-left, .es-right { width:100%!important } .es-content table, .es-header table, .es-footer table, .es-content, .es-footer, .es-header { width:100%!important; max-width:600px!important } .adapt-img { width:100%!important; height:auto!important } .es-mobile-hidden, .es-hidden { display:none!important } .es-desk-hidden { width:auto!important; overflow:visible!important; float:none!important; max-height:inherit!important; line-height:inherit!important } tr.es-desk-hidden { display:table-row!important } table.es-desk-hidden { display:table!important } td.es-desk-menu-hidden { display:table-cell!important } .es-menu td { width:1%!important } table.es-table-not-adapt, .esd-block-html table { width:auto!important } .es-social td { padding-bottom:10px } .h-auto { height:auto!important } }
@media screen and (max-width:384px) {.mail-message-content { width:414px!important } }</style>
 </head> <body class='body' style='width:100%;height:100%;padding:0;Margin:0'><div dir='ltr' class='es-wrapper-color' lang='en' style='background-color:#FAFAFA'> <!--[if gte mso 9]><v:background xmlns:v='urn:schemas-microsoft-com:vml' fill='t'> <v:fill type='tile' color='#fafafa'></v:fill> </v:background><![endif]--><table class='es-wrapper' width='100%' cellspacing='0' cellpadding='0' role='none' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;padding:0;Margin:0;width:100%;height:100%;background-repeat:repeat;background-position:center top;background-color:#FAFAFA'><tr><td valign='top' style='padding:0;Margin:0'><table cellpadding='0' cellspacing='0' class='es-content' align='center' role='none' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;width:100%;table-layout:fixed !important'><tr>
<td align='center' style='padding:0;Margin:0'><table bgcolor='#ffffff' class='es-content-body' align='center' cellpadding='0' cellspacing='0' role='none' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#FFFFFF;width:600px'><tr><td align='left' style='padding:0;Margin:0;padding-top:15px;padding-right:20px;padding-left:20px'><table cellpadding='0' cellspacing='0' width='100%' role='none' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'><tr><td align='center' valign='top' style='padding:0;Margin:0;width:560px'><table cellpadding='0' cellspacing='0' width='100%' role='presentation' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'><tr>
<td align='left' style='padding:0;Margin:0'><h4 align='center' style='Margin:0;font-family:'lucida sans unicode', 'lucida grande', sans-serif;mso-line-height-rule:exactly;letter-spacing:0;font-size:24px;font-style:normal;font-weight:normal;line-height:29px;color:#0b5394'><strong>{cmp}</strong></h4> </td></tr><tr><td align='center' style='padding:0;Margin:0;padding-top:10px;padding-bottom:10px;font-size:0px'><img src='https://onedrive.live.com/embed?resid=9961498AAC9FBC66%21228&amp;authkey=%21APb8zOUiZNnqVM0&amp;height=1525&amp;width=1204' alt='' style='display:block;font-size:14px;border:0;outline:none;text-decoration:none' width='100' class='adapt-img' height='127'></td></tr><tr>
<td align='center' class='es-m-txt-c' style='padding:0;Margin:0;padding-bottom:20px'><h1 style='Margin:0;font-family:arial, 'helvetica neue', helvetica, sans-serif;mso-line-height-rule:exactly;letter-spacing:0;font-size:46px;font-style:normal;font-weight:bold;line-height:46px;color:#333333'>{vc_type}</h1></td></tr></table></td></tr></table></td></tr> <tr><td align='left' style='padding:0;Margin:0;padding-right:20px;padding-left:20px;padding-top:20px'><table cellpadding='0' cellspacing='0' role='none' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'><tr><td align='left' style='padding:0;Margin:0;width:560px'><table cellpadding='0' cellspacing='0' width='100%' role='presentation' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'><tr>
<td align='left' style='padding:0;Margin:0'><h2 align='center' style='Margin:0;font-family:arial, 'helvetica neue', helvetica, sans-serif;mso-line-height-rule:exactly;letter-spacing:0;font-size:26px;font-style:normal;font-weight:bold;line-height:31px;color:#333333'>Your Account Balance is</h2></td></tr></table></td></tr></table></td></tr> <tr><td align='left' style='padding:0;Margin:0;padding-right:40px;padding-left:40px'><table cellpadding='0' cellspacing='0' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:separate;border-spacing:0px' role='none'><tr><td align='left' style='padding:0;Margin:0;width:520px'><table cellpadding='0' cellspacing='0' width='100%' role='presentation' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:separate;border-spacing:0px;border-style:dashed;border-width:3px;border-radius:10px;border-color:#0b5394'><tr>
<td align='left' style='padding:0;Margin:0;padding-top:15px;padding-bottom:15px'><h1 align='center' style='Margin:0;font-family:arial, 'helvetica neue', helvetica, sans-serif;mso-line-height-rule:exactly;letter-spacing:0;font-size:46px;font-style:normal;font-weight:bold;line-height:55px;color:#333333'>{bal}</h1></td></tr></table></td></tr></table></td></tr> </table></td></tr></table></td></tr></table></div></body></html>"

        st = st.Replace("{vc_type}", "Sales")
        st = st.Replace("{cmp}", "POLLAN FERTILIZER PRIVATE LIMITED")
        st = st.Replace("{bal}", "5,00,00.00 Cr.")

        Return st
    End Function
    Public Function Add_to_list(name As String, numb As String, emal As String, subj As String, msg_ As String, typ_msg As String, attage As String, attage_type As String, status_w As String, status_e As String) As String

        Dim idx As Integer = 0

        Grid1.Rows.Add(name, "91" & numb, msg_, typ_msg, attage, attage_type, status_w, "", status_e, emal, subj)
        idx = Grid1.Rows.Count - 1

        If whatsapp_number_verifid(numb) = False Then
            Grid1.Rows(idx).Cells(6).Value = "WhatsApp number is not in correct format"
            Grid1.Rows(idx).Cells(7).Value = DateTime.Now.ToString("hh:mm:ss tt")
        End If

        If Formate_Email(emal) = False Then
            If emal = Nothing Then
                Grid1.Rows(idx).Cells(8).Value = "NA"
                Grid1.Rows(idx).Cells(7).Value = DateTime.Now.ToString("hh:mm:ss tt")
            Else
                Grid1.Rows(idx).Cells(8).Value = "email is incorrect"
                Grid1.Rows(idx).Cells(7).Value = DateTime.Now.ToString("hh:mm:ss tt")
            End If
        End If

        Return idx
    End Function
    Public Function Start_() As Boolean
        If Send_back.IsBusy = False Then
            Send_back.RunWorkerAsync()
        End If
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
        BG_frm.Backgroud_Prossecc = False

        con_status_change()

        Dim refresh_ As Boolean = False

        Dim P_ As New Queue(Of DataGridViewRow)()

        For Each ro As DataGridViewRow In Grid1.Rows
            Dim Status_E As String = ro.Cells(8).Value.ToString
            If Status_E = "Pending" Then
                refresh_ = True
            Else
                P_.Enqueue(ro)
            End If
        Next
        For Each ro As DataGridViewRow In P_
            Grid1.Rows.Remove(ro)
        Next


        If refresh_ = True Then
            isBusy = True
            BG_frm.Backgroud_Prossecc = True

            Send_back.RunWorkerAsync()
        End If



    End Sub
    Dim cn_yn As Boolean = False
    Private Function Send_E(ro As DataGridViewRow)
        Dim Name_ As String = ro.Cells(0).Value.ToString
        Dim Email_to As String = ro.Cells(9).Value.ToString
        Dim subject As String = ro.Cells(10).Value.ToString
        Dim body As String = ro.Cells(2).Value.ToString
        Dim attage_ As String = ro.Cells(4).Value.ToString
        Dim status As String = ro.Cells(8).Value.ToString

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

            ro.Cells(8).Value = "Success"
        Catch ex As Exception
            ro.Cells(8).Value = ex.Message
        End Try
    End Function
    Private Function Send_W(ro As DataGridViewRow)

    End Function
    'Private Function sending(ro As DataGridViewRow) As String
    '    Dim Name_ As String = ro.Cells(0).Value.ToString
    '    Dim to_ As String = ro.Cells(1).Value.ToString
    '    Dim message_ As String = ro.Cells(2).Value.ToString
    '    Dim type_ As String = ro.Cells(3).Value.ToString
    '    Dim attage As String = ro.Cells(4).Value.ToString
    '    Dim attage_type As String = ro.Cells(5).Value.ToString
    '    Dim Status As String = ro.Cells(6).Value.ToString

    '    If type_ = "Text" Then
    '        Try
    '            Dim elm As IWebElement = wait("//*[@id='main']/footer/div[1]/div/span[2]/div/div[2]/div[1]/div/div[1]/p")
    '            elm.Click()
    '            elm.SendKeys(message_)

    '            elm.SendKeys(Keys.Enter)
    '            Return "Success"
    '        Catch ex As Exception
    '            Return ex.Message
    '        End Try
    '    ElseIf type_ = "Image" Or type_ = "Document" Then
    '        Try

    '            wait("//*[@id='main']/footer/div[1]/div/span[2]/div/div[1]/div[2]/div/div/div/span").Click()

    '            If type_ = "Image" Then
    '                'wait("//input[@accept = 'image/*,video/mp4,video/3gpp,video/quicktime']").SendKeys(attage)
    '            ElseIf type_ = "Document" Then
    '                whatsapp_drv.FindElement(By.XPath("//input[@accept = '*']")).SendKeys(attage)
    '            End If
    '            'Thread.Sleep(2000)
    '            Dim txt As IWebElement

    '            If type_ = "Image" Then

    '            ElseIf type_ = "Document" Then
    '                Try
    '                    txt = wait("//*[@id='app']/div/div[2]/div[2]/div[2]/span/div/span/div/div/div[2]/div/div[1]/div[3]/div/div/div[1]/div[1]/p")
    '                Catch ex As Exception

    '                End Try
    '            End If
    '            txt.Click()
    '            If message_ <> Nothing Then
    '                txt.SendKeys(message_)
    '            End If
    '            txt.SendKeys(Keys.Enter)

    '            Return "Success"
    '        Catch ex As Exception
    '            Return ex.Message
    '        End Try
    '    End If
    'End Function
    'Private Function Chat_click() As Boolean
    '    Try
    '        whatsapp_drv.FindElement(By.XPath("//*[@id='app']/div/div[2]/div[2]/div[1]/span/div/span/div/div[2]/div/div/div/div[2]/div")).Click()

    '        Return True
    '    Catch ex As Exception

    '    End Try
    '    Try
    '        whatsapp_drv.FindElement(By.XPath("//*[@id='app']/div/div[2]/div[2]/div[1]/span/div/span/div/div[2]/div[2]/div[2]")).Click()

    '        Return True
    '    Catch ex As Exception
    '        whatsapp_drv.FindElement(By.XPath("//*[@id='app']/div/div[2]/div[2]/div[1]/span/div/span/div/header/div/div[1]/div/span")).Click()
    '        Return False
    '    End Try
    'End Function
    'Private Function New_chat(phone As String) As Boolean
    '    Try
    '        wait("//*[@id='app']/div/div[2]/div[3]/header/div[2]/div/span/div[4]/div/span").Click()
    '        wait("//*[@id='app']/div/div[2]/div[2]/div[1]/span/div/span/div/div[1]/div[2]/div[2]/div/div[1]/p").SendKeys(phone)
    '        Return True
    '    Catch ex As Exception
    '        Return False
    '    End Try
    'End Function
    'Private Enum evant
    '    click = 0
    '    sendKey = 1
    'End Enum
    'Private Function wait(xpath As String) As IWebElement
    '    Dim wt = New WebDriverWait(whatsapp_drv, New TimeSpan(0, 5, 0))
    '    'wt.IgnoreExceptionTypes(GetType(NoSuchElementException), GetType(ElementNotVisibleException))


    '    Return wt.Until(Function() As IWebElement
    '                        Try
    '                            Dim e As IWebElement = whatsapp_drv.FindElement(By.XPath(xpath))
    '                            If e.Displayed = True Then
    '                                Return e
    '                            End If
    '                        Catch ex As Exception

    '                        End Try
    '                    End Function)
    'End Function
    'Private Sub Grid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid1.CellContentClick

    'End Sub

    Private Sub Grid1_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles Grid1.RowPrePaint
        Dim ro As DataGridViewRow = Grid1.Rows(e.RowIndex)
        If ro.Cells(6).Value = "Pending" Then
            ro.DefaultCellStyle.ForeColor = Color.Black
        ElseIf ro.Cells(6).Value = "Success" Then
            ro.DefaultCellStyle.ForeColor = Color.Green
        Else
            ro.DefaultCellStyle.ForeColor = Color.Red
        End If
    End Sub
    'Private Function Chack_con() As Boolean
    '    Try
    '        Dim id As String = whatsapp_drv.CurrentWindowHandle.Length
    '        whatsapp_drv.FindElement(By.XPath("//*[@id='app']/div/div[2]/div[3]/header/div[2]/div/span/div[4]/div/span"))
    '        Return True
    '    Catch ex As Exception
    '        Return False
    '    End Try
    'End Function
    Private Sub Send_back_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles Send_back.ProgressChanged
        con_status_change()

    End Sub
    Private Function con_status_change()
        Enable_ = cn_yn
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button2.Visible = True
        Button1.Visible = False
        Send_back.CancelAsync()
    End Sub

    Private Sub ProgressBag_Custom1_Load(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Button2.Visible = False
        Button1.Visible = True
        Send_back.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs)
        'whatsapp_driver()
        'SendKeys.Send("%{TAB}")
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs)
        'Send_back.RunWorkerAsync()
    End Sub

    Private Sub Login_back_DoWork(sender As Object, e As DoWorkEventArgs)
        'If Whatsapp_YN_fech = True Then
        '    Dim iswhatsapp As Boolean = False
        '    For Each ro As DataGridViewRow In Grid1.Rows
        '        If ro.Cells(1).Value <> Nothing Then
        '            iswhatsapp = True
        '            Exit For
        '        End If
        '    Next

        '    'If iswhatsapp = True Then
        '    whatsapp_driver()

        '    Dim elm As IWebElement = wait("//*[@id='app']/div/div[2]/div[3]/header/div[2]/div/span/div[4]/div/span")
        '        If elm.Displayed = True Then
        '            cn_yn = True
        '        End If
        '    'Else
        '    'cn_yn = True
        '    'End If
        'Else
        '    cn_yn = True
        'End If


        For i As Integer = 0 To 100000

        Next

    End Sub

    Private Sub Whatsapp_Sending_list_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        'whatsapp_drv.Dispose()
    End Sub
    Private Sub Login_back_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs)
        'If cn_yn = True Then
        If isBusy = False And BG_frm.Backgroud_Prossecc = False Then
            'Panel3.Visible = False
            'bg_panel.Visible = True
            'bg_panel.Dock = DockStyle.Fill
            'Send_back.RunWorkerAsync()
            'BG_frm.PictureBox1.Image = My.Resources.email_send_animation_icn
            'BG_frm.Label1.Text = "E-Mail Sending"

        Else
            'Start_()
        End If
        'End If
    End Sub
    Dim cunt As Integer = 100
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        cunt -= 1

        If cunt = 0 Then
            Me.Dispose()
        End If
    End Sub

    Private Sub Grid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid1.CellContentClick

    End Sub
End Class