Imports System.ComponentModel
Imports System.Net.Mail

Public Class Email_Verification_dialoag
    Private Sub Email_Verification_dialoag_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Function Email_OTP(Type As String, Head As String, TO_Name As String, TO_Email As String, Subject As String, Body As String, Sec As Integer) As DialogResult
        Dim ms As New Email_Verification_dialoag
        With ms
            .Email_Sendin_Panel.Show()
            .Email_Sendin_Panel.Dock = DockStyle.Fill
            .Text = Type
            .Width = 323 + 10
            .Height = 412
            .Button2.Focus()
            Close_Fales(Me)
            .SEDING_EMAIL_HEAD_TXT.Text = Head
            .SEDING_EMAIL_MESSAGE_TXT.Text = $"A verification code will be sent to '{TO_Email.Substring(0, 3)}**********{TO_Email.Substring(TO_Email.Length - 4, 4)}' , the code will have to be given to this software, if the verification code is correct then the software will proceed"
            .Email_SUB_LAB = Subject
            .EMAIL_MESSAGE = Body
            .Email_Sending_Time = Sec
            .EMAIL_TO = TO_Email
            .NAME_TO = TO_Name
            Me.Text = Type
        End With
        Return ms.ShowDialog
    End Function
    Dim Email_SUB_LAB As String = ""
    Dim EMAIL_MESSAGE As String = ""
    Dim Email_Sending_Time As String = ""
    Dim EMAIL_TO As String = ""
    Dim NAME_TO As String = ""

    Public OTP As String = ""
    Dim Refrence_id As String = ""
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim st As New ErrorProvider
        Dim OPT_Hint As String = ((Val(Now.Date.Day) + Val(Now.Date.Millisecond) + Val(Now.Date.Second) & Val(Val(Now.TimeOfDay.Hours + Now.TimeOfDay.Minutes & Now.Date.Month + Now.Date.Day)) + Val(Val(Now.Date.Year))) - Val(Now.TimeOfDay.Seconds) + Val(Now.TimeOfDay.Milliseconds)) * 12552

        Dim O1 As String = OPT_Hint.Substring(OPT_Hint.Length - 4, 3)
        OPT_Hint += ((O1 * 2) + O1)
        Dim O2 As String = OPT_Hint.Substring(OPT_Hint.Length - 4, 3)

        OTP = O1 & "-" & O2

        Refrence_id = Val(OPT_Hint) * 1299
        Refrence_id = "REF/" & Refrence_id.Substring(Refrence_id.Length - 5, 4) & "/" & Now.Date.ToString("MMM")

        Label2.Text = "Reference No : " & Refrence_id.ToUpper


        Panel10.Hide()
        Button4.Text = "&VERIFIED"
        Button2.Enabled = False
        Button1.Enabled = False
        Email_Sec_Lab.Text = Val(Email_Sending_Time)
        Email_Sending_OTP_Background.RunWorkerAsync()
        Email_Verification_Panel.Focus()
        Timer1.Start()
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Email_Sec_Lab.Text = Val(Email_Sec_Lab.Text) - 1
        If Val(Email_Sec_Lab.Text) = 0 Then
            Button4.Text = "&RESEND"
            Timer1.Stop()
        End If
    End Sub
    Dim Issuccess As Boolean = False
    Private Sub Email_Sending_Background_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles Email_Sending_OTP_Background.DoWork
        If Me.Text = "Email" Then
            Try
                Dim mail As New MailMessage
                Dim SMTPServee As New SmtpClient
                mail.From = New MailAddress(Send_Email)
                mail.Subject = Email_SUB_LAB & "-" & Refrence_id.ToUpper
                mail.To.Add(EMAIL_TO)
                mail.IsBodyHtml = True
                mail.Body = msg_HTML()
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
        ElseIf Me.Text = "WhatsApp" Then
            Try
                Send_WhatsApp_api(json_OTP_(EMAIL_TO, Email_SUB_LAB, OTP))
                Issuccess = True
            Catch ex As Exception
                Issuccess = False
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If
    End Sub
    Private Sub Email_Sending_Background_OTP_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles Email_Sending_OTP_Background.RunWorkerCompleted
        'Panel10.Show()
        Button2.Enabled = True
        Button1.Enabled = True
        If Issuccess = True Then
            Email_Sendin_Panel.Hide()
            Email_Verification_Panel.Show()
            Email_Verification_Panel.Dock = DockStyle.Fill
            Email_Verified_TXT.Focus()
            Timer1.Start()
        Else
            MessageBox.Show("Send Fail", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Dispose()
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim st As New ErrorProvider
        If Button4.Text = "&VERIFIED" Then
            If Email_Verified_TXT.Text = OTP Then
                Me.DialogResult = DialogResult.Yes
                Me.Dispose()
            Else
                Msg_Custom_YN(NOT_Location.Center, Color.Red, My.Resources.Error_animation_icn, Dialoag_Button.Ok, "Error !", "Verification Code is Wrong", "Verification Code is Wrong,<nl> Please enter currant<nl>Verification code and try agin")
                DialLoag_Result = DialogResult.No
            End If
        Else
            Email_Verification_Panel.Hide()
            Email_Sendin_Panel.Show()
            Button2.Focus()
            Me.DialogResult = DialogResult.No
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Dispose()
    End Sub

    Private Sub Email_Verified_TXT_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles Email_Verified_TXT.MaskInputRejected

    End Sub

    Private Sub Email_Verified_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles Email_Verified_TXT.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button4.PerformClick()
        End If
    End Sub

    Private Sub Email_Verification_dialoag_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If Msg_Exit_YN(Me.Name) = DialogResult.Yes Then
                Me.DialogResult = DialogResult.Cancel
                Me.Dispose()
            End If
        End If
    End Sub
    Private Function msg_HTML()
        Dim st As String = "<!DOCTYPE HTML PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional //EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
<html xmlns=""http://www.w3.org/1999/xhtml"" xmlns:v=""urn:schemas-microsoft-com:vml"" xmlns:o=""urn:schemas-microsoft-com:office:office"">

<head>
  <!--[if gte mso 9]>
<xml>
  <o:OfficeDocumentSettings>
    <o:AllowPNG/>
    <o:PixelsPerInch>96</o:PixelsPerInch>
  </o:OfficeDocumentSettings>
</xml>
<![endif]-->
  <meta http-equiv=""Content-Type"" content=""text/html; charset=UTF-8"">
  <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
  <meta name=""x-apple-disable-message-reformatting"">
  <!--[if !mso]><!-->
  <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
  <!--<![endif]-->
  <title></title>

  <style type=""text/css"">
    @media only screen and (min-width: 620px) {
      .u-row {
        width: 600px !important;
      }
      .u-row .u-col {
        vertical-align: top;
      }
      .u-row .u-col-100 {
        width: 600px !important;
      }
    }
    
    @media (max-width: 620px) {
      .u-row-container {
        max-width: 100% !important;
        padding-left: 0px !important;
        padding-right: 0px !important;
      }
      .u-row .u-col {
        min-width: 320px !important;
        max-width: 100% !important;
        display: block !important;
      }
      .u-row {
        width: 100% !important;
      }
      .u-col {
        width: 100% !important;
      }
      .u-col>div {
        margin: 0 auto;
      }
    }
    
    body {
      margin: 0;
      padding: 0;
    }
    
    table,
    tr,
    td {
      vertical-align: top;
      border-collapse: collapse;
    }
    
    p {
      margin: 0;
    }
    
    .ie-container table,
    .mso-container table {
      table-layout: fixed;
    }
    
    * {
      line-height: inherit;
    }
    
    a[x-apple-data-detectors='true'] {
      color: inherit !important;
      text-decoration: none !important;
    }
    
    table,
    td {
      color: #000000;
    }
    
    @media (max-width: 480px) {
      #u_content_image_1 .v-container-padding-padding {
        padding: 14px !important;
      }
      #u_content_image_1 .v-src-width {
        width: auto !important;
      }
      #u_content_image_1 .v-src-max-width {
        max-width: 100% !important;
      }
    }
  </style>



  <!--[if !mso]><!-->
  <link href=""https://fonts.googleapis.com/css?family=Cabin:400,700"" rel=""stylesheet"" type=""text/css"">
  <!--<![endif]-->

</head>

<body class=""clean-body u_body"" style=""margin: 0;padding: 0;-webkit-text-size-adjust: 100%;background-color: #f9f9f9;color: #000000"">
  <!--[if IE]><div class=""ie-container""><![endif]-->
  <!--[if mso]><div class=""mso-container""><![endif]-->
  <table style=""border-collapse: collapse;table-layout: fixed;border-spacing: 0;mso-table-lspace: 0pt;mso-table-rspace: 0pt;vertical-align: top;min-width: 320px;Margin: 0 auto;background-color: #f9f9f9;width:100%"" cellpadding=""0"" cellspacing=""0"">
    <tbody>
      <tr style=""vertical-align: top"">
        <td style=""word-break: break-word;border-collapse: collapse !important;vertical-align: top"">
          <!--[if (mso)|(IE)]><table width=""100%"" cellpadding=""0"" cellspacing=""0"" border=""0""><tr><td align=""center"" style=""background-color: #f9f9f9;""><![endif]-->



          <div class=""u-row-container"" style=""padding: 0px;background-color: transparent"">
            <div class=""u-row"" style=""margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #ffffff;"">
              <div style=""border-collapse: collapse;display: table;width: 100%;height: 100%;background-color: transparent;"">
                <!--[if (mso)|(IE)]><table width=""100%"" cellpadding=""0"" cellspacing=""0"" border=""0""><tr><td style=""padding: 0px;background-color: transparent;"" align=""center""><table cellpadding=""0"" cellspacing=""0"" border=""0"" style=""width:600px;""><tr style=""background-color: #ffffff;""><![endif]-->

                <!--[if (mso)|(IE)]><td align=""center"" width=""600"" style=""width: 600px;padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;"" valign=""top""><![endif]-->
                <div class=""u-col u-col-100"" style=""max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;"">
                  <div style=""height: 100%;width: 100% !important;"">
                    <!--[if (!mso)&(!IE)]><!-->
                    <div style=""box-sizing: border-box; height: 100%; padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;"">
                      <!--<![endif]-->

                      <table id=""u_content_image_1"" style=""font-family:'Cabin',sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">
                        <tbody>
                          <tr>
                            <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:20px;font-family:'Cabin',sans-serif;"" align=""left"">

                              <table width=""100%"" cellpadding=""0"" cellspacing=""0"" border=""0"">
                                <tr>
                                  <td style=""padding-right: 0px;padding-left: 0px;"" align=""center"">

                                    <img align=""center"" border=""0"" src=""https://onedrive.live.com/embed?resid=9961498AAC9FBC66%21225&authkey=%21ADCEY40c5sUOJ10&width=1479&height=328"" alt=""Image"" title=""Image"" style=""outline: none;text-decoration: none;-ms-interpolation-mode: bicubic;clear: both;display: inline-block !important;border: none;height: auto;float: none;width: 85%;max-width: 476px;""
                                      width=""476"" class=""v-src-width v-src-max-width"" />

                                  </td>
                                </tr>
                              </table>

                            </td>
                          </tr>
                        </tbody>
                      </table>

                      <table style=""font-family:'Cabin',sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">
                        <tbody>
                          <tr>
                            <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:13px;font-family:'Cabin',sans-serif;"" align=""left"">

                              <table height=""0px"" align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" width=""71%"" style=""border-collapse: collapse;table-layout: fixed;border-spacing: 0;mso-table-lspace: 0pt;mso-table-rspace: 0pt;vertical-align: top;border-top: 1px dashed #000000;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%"">
                                <tbody>
                                  <tr style=""vertical-align: top"">
                                    <td style=""word-break: break-word;border-collapse: collapse !important;vertical-align: top;font-size: 0px;line-height: 0px;mso-line-height-rule: exactly;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%"">
                                      <span>&#160;</span>
                                    </td>
                                  </tr>
                                </tbody>
                              </table>

                            </td>
                          </tr>
                        </tbody>
                      </table>

                      <!--[if (!mso)&(!IE)]><!-->
                    </div>
                    <!--<![endif]-->
                  </div>
                </div>
                <!--[if (mso)|(IE)]></td><![endif]-->
                <!--[if (mso)|(IE)]></tr></table></td></tr></table><![endif]-->
              </div>
            </div>
          </div>





          <div class=""u-row-container"" style=""padding: 0px;background-color: transparent"">
            <div class=""u-row"" style=""margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #ef7f1a;"">
              <div style=""border-collapse: collapse;display: table;width: 100%;height: 100%;background-color: transparent;"">
                <!--[if (mso)|(IE)]><table width=""100%"" cellpadding=""0"" cellspacing=""0"" border=""0""><tr><td style=""padding: 0px;background-color: transparent;"" align=""center""><table cellpadding=""0"" cellspacing=""0"" border=""0"" style=""width:600px;""><tr style=""background-color: #ef7f1a;""><![endif]-->

                <!--[if (mso)|(IE)]><td align=""center"" width=""600"" style=""width: 600px;padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;"" valign=""top""><![endif]-->
                <div class=""u-col u-col-100"" style=""max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;"">
                  <div style=""height: 100%;width: 100% !important;"">
                    <!--[if (!mso)&(!IE)]><!-->
                    <div style=""box-sizing: border-box; height: 100%; padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;"">
                      <!--<![endif]-->

                      <table style=""font-family:'Cabin',sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">
                        <tbody>
                          <tr>
                            <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:3px;font-family:'Cabin',sans-serif;"" align=""left"">

                              <table width=""100%"" cellpadding=""0"" cellspacing=""0"" border=""0"">
                                <tr>
                                  <td style=""padding-right: 0px;padding-left: 0px;"" align=""center"">

                                    <img align=""center"" border=""0"" src=""https://cdn.templates.unlayer.com/assets/1597218650916-xxxxc.png"" alt=""Image"" title=""Image"" style=""outline: none;text-decoration: none;-ms-interpolation-mode: bicubic;clear: both;display: inline-block !important;border: none;height: auto;float: none;width: 22%;max-width: 130.68px;""
                                      width=""130.68"" class=""v-src-width v-src-max-width"" />

                                  </td>
                                </tr>
                              </table>

                            </td>
                          </tr>
                        </tbody>
                      </table>

                      <table style=""font-family:'Cabin',sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">
                        <tbody>
                          <tr>
                            <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:5px;font-family:'Cabin',sans-serif;"" align=""left"">

                              <div style=""font-size: 14px; color: #e5eaf5; line-height: 140%; text-align: center; word-wrap: break-word;"">
                                <p style=""font-size: 14px; line-height: 140%;""><span style=""color: #ecf0f1; line-height: 19.6px;""><strong>T H A N K S&nbsp; &nbsp;F O R&nbsp; &nbsp;U S I N G</strong></span></p>
                              </div>

                            </td>
                          </tr>
                        </tbody>
                      </table>

                      <table style=""font-family:'Cabin',sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">
                        <tbody>
                          <tr>
                            <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:0px 10px 19px;font-family:'Cabin',sans-serif;"" align=""left"">

                              <div style=""font-size: 14px; color: #e5eaf5; line-height: 140%; text-align: center; word-wrap: break-word;"">
                                <p style=""font-size: 14px; line-height: 140%;""><span style=""font-size: 28px; line-height: 39.2px; color: #ecf0f1;""><strong><span style=""line-height: 39.2px; font-size: 28px;"">{type}</span></strong>
                                  </span>
                                </p>
                              </div>

                            </td>
                          </tr>
                        </tbody>
                      </table>

                      <!--[if (!mso)&(!IE)]><!-->
                    </div>
                    <!--<![endif]-->
                  </div>
                </div>
                <!--[if (mso)|(IE)]></td><![endif]-->
                <!--[if (mso)|(IE)]></tr></table></td></tr></table><![endif]-->
              </div>
            </div>
          </div>





          <div class=""u-row-container"" style=""padding: 0px;background-color: transparent"">
            <div class=""u-row"" style=""margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #ffffff;"">
              <div style=""border-collapse: collapse;display: table;width: 100%;height: 100%;background-color: transparent;"">
                <!--[if (mso)|(IE)]><table width=""100%"" cellpadding=""0"" cellspacing=""0"" border=""0""><tr><td style=""padding: 0px;background-color: transparent;"" align=""center""><table cellpadding=""0"" cellspacing=""0"" border=""0"" style=""width:600px;""><tr style=""background-color: #ffffff;""><![endif]-->

                <!--[if (mso)|(IE)]><td align=""center"" width=""600"" style=""width: 600px;padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;"" valign=""top""><![endif]-->
                <div class=""u-col u-col-100"" style=""max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;"">
                  <div style=""height: 100%;width: 100% !important;"">
                    <!--[if (!mso)&(!IE)]><!-->
                    <div style=""box-sizing: border-box; height: 100%; padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;"">
                      <!--<![endif]-->

                      <table style=""font-family:'Cabin',sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">
                        <tbody>
                          <tr>
                            <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:14px 10px 15px;font-family:'Cabin',sans-serif;"" align=""left"">

                              <div style=""font-size: 14px; line-height: 160%; text-align: center; word-wrap: break-word;"">
                                <p style=""font-size: 14px; line-height: 160%;""><span style=""font-size: 22px; line-height: 35.2px;"">Hi, {name}</span></p>
                                <p style=""font-size: 18px; line-height: 160%;"">You received this message because your email address is registered with our software. Please enter the verification code below into the software to verify your email address and confirm that you are the owner of this account.</p>
                              </div>

                            </td>
                          </tr>
                        </tbody>
                      </table>

                      <table style=""font-family:'Cabin',sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">
                        <tbody>
                          <tr>
                            <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:10px 10px 2px;font-family:'Cabin',sans-serif;"" align=""left"">

                              <div style=""font-size: 15px; line-height: 140%; text-align: center; word-wrap: break-word;"">
                                <p style=""line-height: 140%;"">{msg}</p>
                              </div>

                            </td>
                          </tr>
                        </tbody>
                      </table>

                      <table style=""font-family:'Cabin',sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">
                        <tbody>
                          <tr>
                            <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:10px;font-family:'Cabin',sans-serif;"" align=""left"">

                              <!--[if mso]><table width=""100%""><tr><td><![endif]-->
                              <h1 style=""margin: 0px; color: #ff6600; line-height: 220%; text-align: center; word-wrap: break-word; font-family: arial,helvetica,sans-serif; font-size: 23px; font-weight: 700;""><span><span><span><span><span><span><span style=""line-height: 50.6px;""><span style=""line-height: 50.6px;""><span style=""line-height: 50.6px;"">{email}</span></span>
                                </span>
                                </span>
                                </span>
                                </span>
                                </span>
                                </span>
                                </span>
                              </h1>
                              <!--[if mso]></td></tr></table><![endif]-->

                            </td>
                          </tr>
                        </tbody>
                      </table>

                      <!--[if (!mso)&(!IE)]><!-->
                    </div>
                    <!--<![endif]-->
                  </div>
                </div>
                <!--[if (mso)|(IE)]></td><![endif]-->
                <!--[if (mso)|(IE)]></tr></table></td></tr></table><![endif]-->
              </div>
            </div>
          </div>





          <div class=""u-row-container"" style=""padding: 8px 80px;background-color: transparent"">
            <div class=""u-row"" style=""margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: transparent;"">
              <div style=""border-collapse: collapse;display: table;width: 100%;height: 100%;background-color: transparent;"">
                <!--[if (mso)|(IE)]><table width=""100%"" cellpadding=""0"" cellspacing=""0"" border=""0""><tr><td style=""padding: 8px 80px;background-color: transparent;"" align=""center""><table cellpadding=""0"" cellspacing=""0"" border=""0"" style=""width:600px;""><tr style=""background-color: transparent;""><![endif]-->

                <!--[if (mso)|(IE)]><td align=""center"" width=""596"" style=""width: 596px;padding: 0px;border-top: 2px dashed #5c68e2;border-left: 2px dashed #5c68e2;border-right: 2px dashed #5c68e2;border-bottom: 2px dashed #5c68e2;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;"" valign=""top""><![endif]-->
                <div class=""u-col u-col-100"" style=""max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;"">
                  <div style=""height: 100%;width: 100% !important;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;"">
                    <!--[if (!mso)&(!IE)]><!-->
                    <div style=""box-sizing: border-box; height: 100%; padding: 0px;border-top: 2px dashed #5c68e2;border-left: 2px dashed #5c68e2;border-right: 2px dashed #5c68e2;border-bottom: 2px dashed #5c68e2;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;"">
                      <!--<![endif]-->

                      <table style=""font-family:'Cabin',sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">
                        <tbody>
                          <tr>
                            <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:16px 7px 10px;font-family:'Cabin',sans-serif;"" align=""left"">

                              <div style=""font-family: arial,helvetica,sans-serif; font-size: 23px; font-weight: 700; line-height: 100%; text-align: center; word-wrap: break-word;"">
                                <p style=""line-height: 100%;"">Verification Code</p>
                              </div>

                            </td>
                          </tr>
                        </tbody>
                      </table>

                      <table style=""font-family:'Cabin',sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">
                        <tbody>
                          <tr>
                            <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:0px;font-family:'Cabin',sans-serif;"" align=""left"">

                              <div style=""font-family: arial,helvetica,sans-serif; font-size: 35px; font-weight: 700; line-height: 110%; text-align: center; word-wrap: break-word;"">
                                <p style=""line-height: 110%;""><span style=""color: #5c68e2; line-height: 38.5px;"">{otp}</span></p>
                              </div>

                            </td>
                          </tr>
                        </tbody>
                      </table>

                      <table style=""font-family:'Cabin',sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">
                        <tbody>
                          <tr>
                            <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:0px 1px 10px;font-family:'Cabin',sans-serif;"" align=""left"">

                              <!--[if mso]><table width=""100%""><tr><td><![endif]-->
                              <h1 style=""margin: 0px; color: #f80505; line-height: 100%; text-align: center; word-wrap: break-word; font-family: arial,helvetica,sans-serif; font-size: 21px; font-weight: 400;""><span><span><span><span><span><span><span><span><span><span style=""line-height: 30px;""><span style=""line-height: 30px;""><em><strong><span style=""line-height: 30px;""><span style=""line-height: 30px;""><span style=""line-height: 30px;""><span style=""line-height: 30px;"">{ref}</span></span>
                                </span>
                                </span>
                                </strong>
                                </em>
                                </span>
                                </span>
                                </span>
                                </span>
                                </span>
                                </span>
                                </span>
                                </span>
                                </span>
                                </span>
                                </span>
                              </h1>
                              <!--[if mso]></td></tr></table><![endif]-->

                            </td>
                          </tr>
                        </tbody>
                      </table>

                      <!--[if (!mso)&(!IE)]><!-->
                    </div>
                    <!--<![endif]-->
                  </div>
                </div>
                <!--[if (mso)|(IE)]></td><![endif]-->
                <!--[if (mso)|(IE)]></tr></table></td></tr></table><![endif]-->
              </div>
            </div>
          </div>





          <div class=""u-row-container"" style=""padding: 0px;background-color: transparent"">
            <div class=""u-row"" style=""margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: transparent;"">
              <div style=""border-collapse: collapse;display: table;width: 100%;height: 100%;background-color: transparent;"">
                <!--[if (mso)|(IE)]><table width=""100%"" cellpadding=""0"" cellspacing=""0"" border=""0""><tr><td style=""padding: 0px;background-color: transparent;"" align=""center""><table cellpadding=""0"" cellspacing=""0"" border=""0"" style=""width:600px;""><tr style=""background-color: transparent;""><![endif]-->

                <!--[if (mso)|(IE)]><td align=""center"" width=""600"" style=""width: 600px;padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;"" valign=""top""><![endif]-->
                <div class=""u-col u-col-100"" style=""max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;"">
                  <div style=""height: 100%;width: 100% !important;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;"">
                    <!--[if (!mso)&(!IE)]><!-->
                    <div style=""box-sizing: border-box; height: 100%; padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;"">
                      <!--<![endif]-->

                      <table style=""font-family:'Cabin',sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">
                        <tbody>
                          <tr>
                            <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:23px 10px 5px;font-family:'Cabin',sans-serif;"" align=""left"">

                              <div style=""font-size: 19px; line-height: 140%; text-align: center; word-wrap: break-word;"">
                                <p style=""line-height: 140%;""><span style=""line-height: 26.6px;"">Thanks,</span></p>
                                <p style=""line-height: 140%;""><span style=""line-height: 26.6px;"">The Company Team</span></p>
                              </div>

                            </td>
                          </tr>
                        </tbody>
                      </table>

                      <!--[if (!mso)&(!IE)]><!-->
                    </div>
                    <!--<![endif]-->
                  </div>
                </div>
                <!--[if (mso)|(IE)]></td><![endif]-->
                <!--[if (mso)|(IE)]></tr></table></td></tr></table><![endif]-->
              </div>
            </div>
          </div>





          <div class=""u-row-container"" style=""padding: 0px;background-color: transparent"">
            <div class=""u-row"" style=""margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #fcefe6;"">
              <div style=""border-collapse: collapse;display: table;width: 100%;height: 100%;background-color: transparent;"">
                <!--[if (mso)|(IE)]><table width=""100%"" cellpadding=""0"" cellspacing=""0"" border=""0""><tr><td style=""padding: 0px;background-color: transparent;"" align=""center""><table cellpadding=""0"" cellspacing=""0"" border=""0"" style=""width:600px;""><tr style=""background-color: #fcefe6;""><![endif]-->

                <!--[if (mso)|(IE)]><td align=""center"" width=""600"" style=""width: 600px;padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;"" valign=""top""><![endif]-->
                <div class=""u-col u-col-100"" style=""max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;"">
                  <div style=""height: 100%;width: 100% !important;"">
                    <!--[if (!mso)&(!IE)]><!-->
                    <div style=""box-sizing: border-box; height: 100%; padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;"">
                      <!--<![endif]-->

                      <table style=""font-family:'Cabin',sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">
                        <tbody>
                          <tr>
                            <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:41px 55px 18px;font-family:'Cabin',sans-serif;"" align=""left"">

                              <div style=""font-size: 14px; color: #003399; line-height: 160%; text-align: center; word-wrap: break-word;"">
                                <p style=""font-size: 14px; line-height: 160%;""><span style=""font-size: 20px; line-height: 32px; color: #000000;""><strong>Contact Us</strong></span></p>
                                <p style=""font-size: 14px; line-height: 160%;""><span style=""font-size: 16px; line-height: 25.6px; color: #000000;"">Phone: +91 63531 61009, +91 94288 37047</span></p>
                                <p style=""font-size: 14px; line-height: 160%;""><span style=""font-size: 16px; line-height: 25.6px; color: #000000;"">Email: cryptonixtechnology@gmail.com</span></p>
                              </div>

                            </td>
                          </tr>
                        </tbody>
                      </table>

                      <!--[if (!mso)&(!IE)]><!-->
                    </div>
                    <!--<![endif]-->
                  </div>
                </div>
                <!--[if (mso)|(IE)]></td><![endif]-->
                <!--[if (mso)|(IE)]></tr></table></td></tr></table><![endif]-->
              </div>
            </div>
          </div>





          <div class=""u-row-container"" style=""padding: 0px;background-color: transparent"">
            <div class=""u-row"" style=""margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #ff6600;"">
              <div style=""border-collapse: collapse;display: table;width: 100%;height: 100%;background-color: transparent;"">
                <!--[if (mso)|(IE)]><table width=""100%"" cellpadding=""0"" cellspacing=""0"" border=""0""><tr><td style=""padding: 0px;background-color: transparent;"" align=""center""><table cellpadding=""0"" cellspacing=""0"" border=""0"" style=""width:600px;""><tr style=""background-color: #ff6600;""><![endif]-->

                <!--[if (mso)|(IE)]><td align=""center"" width=""600"" style=""width: 600px;padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;"" valign=""top""><![endif]-->
                <div class=""u-col u-col-100"" style=""max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;"">
                  <div style=""height: 100%;width: 100% !important;"">
                    <!--[if (!mso)&(!IE)]><!-->
                    <div style=""box-sizing: border-box; height: 100%; padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;"">
                      <!--<![endif]-->

                      <table style=""font-family:'Cabin',sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">
                        <tbody>
                          <tr>
                            <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:10px;font-family:'Cabin',sans-serif;"" align=""left"">

                              <div style=""font-size: 14px; color: #fafafa; line-height: 180%; text-align: center; word-wrap: break-word;"">
                                <p style=""font-size: 14px; line-height: 180%;""><span style=""font-size: 16px; line-height: 28.8px;"">Copyrights © Company All Rights Reserved</span></p>
                              </div>

                            </td>
                          </tr>
                        </tbody>
                      </table>

                      <!--[if (!mso)&(!IE)]><!-->
                    </div>
                    <!--<![endif]-->
                  </div>
                </div>
                <!--[if (mso)|(IE)]></td><![endif]-->
                <!--[if (mso)|(IE)]></tr></table></td></tr></table><![endif]-->
              </div>
            </div>
          </div>



          <!--[if (mso)|(IE)]></td></tr></table><![endif]-->
        </td>
      </tr>
    </tbody>
  </table>
  <!--[if mso]></div><![endif]-->
  <!--[if IE]></div><![endif]-->
</body>

</html>"

        st = st.Replace("{ref}", Refrence_id.ToUpper)
        st = st.Replace("{otp}", OTP)
        st = st.Replace("{email}", EMAIL_TO.Trim)
        st = st.Replace("{name}", NAME_TO)
        st = st.Replace("{msg}", EMAIL_MESSAGE)
        st = st.Replace("{type}", SEDING_EMAIL_HEAD_TXT.Text)

        Return st
    End Function

    Private Sub Email_Verification_dialoag_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Me.Dispose()
    End Sub
End Class