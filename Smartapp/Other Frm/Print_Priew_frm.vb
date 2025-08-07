Imports System.ComponentModel
Imports System.Drawing.Printing
Imports System.IO
Imports System.Net.Mail
Imports System.Xml
Imports Microsoft.Reporting.WinForms

Public Class Print_Priew_frm
    Private Sub Print_Priew_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Driver_detect()
        Me.ReportViewer1.RefreshReport()

        Select_1.Text = Primary_Printer
        'Button1.PerformClick()
    End Sub

    Private Sub Print_Priew_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub
    Private Function Driver_detect()
        Select_1.Items.Clear()
        Dim pkInstalledPrinters As String

        For Each pkInstalledPrinters In
            PrinterSettings.InstalledPrinters
            Select_1.Items.Add(pkInstalledPrinters)
        Next pkInstalledPrinters

        If Select_1.Items.Count > 0 Then
            Select_1.SelectedIndex = 0
        End If


        Dim strFileSize As String = ""
        Dim di As New IO.DirectoryInfo(Print_Path)
        Dim aryFi As IO.FileInfo() = di.GetFiles("*.rdlc")
        Dim fi As IO.FileInfo
        Dim dft_ As Boolean = False

        For Each fi In aryFi
            strFileSize = (Math.Round(fi.Length / 1024)).ToString()
            Select_2.Items.Add(fi.Name)

            If fi.Name = defolt_report Then
                dft_ = True
            End If
        Next

        Try
            Select_2.SelectedIndex = 0
            ReportViewer1.LocalReport.ReportPath = Print_Path & "\" & Select_2.Text
            ReportViewer1.LocalReport.SetParameters(Print_Param)
            ReportViewer1.RefreshReport()
        Catch ex As Exception

        End Try

        If dft_ = True Then
            Select_2.Text = defolt_report
        End If
    End Function
    Dim Print_Path As String
    Dim Print_Param As ReportParameter()
    Public defolt_report As String
    Public Function Print_Privew(Path_ As String, Email_ As String, Paramiters As ReportParameter())
        Label9.Text = Now.Millisecond & Val(Now.Millisecond) * Val(Now.Second) & "_" & Val(Now.Minute) * Val(Now.Millisecond) & ".pdf"
        Txt1.Text = Email_
        Print_Path = Path_
        Me.ShowDialog()
    End Function
    Private Function Link_xml(path As String)
        Dim paramtr(xml_info(path)) As ReportParameter

        Dim xml As XmlTextReader
        xml = New XmlTextReader(path)
        xml.WhitespaceHandling = WhitespaceHandling.None
        xml.Read()
        xml.Read()
        Dim int As Integer
        int = 0
        While Not xml.EOF
            xml.Read()
            If Not xml.IsStartElement() Then
                Exit While
            End If
            Dim fun = xml.GetAttribute("Function")
            xml.Read()
            Dim Head As String
            Dim Value As String

            Head = xml.ReadElementString("Head")
            Value = xml_Function_link(fun, xml.ReadElementString("Value"))

            paramtr(int) = New ReportParameter(Head, Value)

            int = Val(int) + 1
        End While
        xml.Close()
        Print_Param = paramtr
    End Function
    Private Function xml_info(path As String) As Integer
        Dim xmldoc As New XmlDataDocument()
        Dim fs As New FileStream(path, FileMode.Open, FileAccess.Read)
        xmldoc.Load(fs)
        Dim Globalobjectscount = xmldoc.GetElementsByTagName("name").Count

        Return Val(Globalobjectscount) - 1
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With ReportViewer1
            .PrinterSettings.PrinterName = Select_1.Text
            .PrinterSettings.Copies = NumericUpDown1.Value
            .PrintDialog()
        End With
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim byteViewer As Byte() = ReportViewer1.LocalReport.Render("PDF")
        Dim saveFileDialog1 As New SaveFileDialog()
        saveFileDialog1.Filter = "*PDF files (*.pdf)|*.pdf"
        If saveFileDialog1.ShowDialog = DialogResult.OK Then
            Dim newFile As New FileStream(saveFileDialog1.FileName & "", FileMode.Create)
            newFile.Write(byteViewer, 0, byteViewer.Length)
            newFile.Close()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Txt1.Text.Trim = Nothing Then
            Msg(NOT_Type.Warning, "Input Error", "Please enter Email Address and try agin")
            Exit Sub
        End If
        Email_Send()
    End Sub
    Dim path As String
    Private Function Email_Send()
        Button2.Hide()
        path = Application.StartupPath & "\_other_savefiles\" & Label9.Text
        Defolt_Location_Save_PDF(path)
        BackgroundWorker1.RunWorkerAsync()
    End Function
    Private Function Defolt_Location_Save_PDF(Location As String)
        Try
            Dim byteViewer As Byte() = ReportViewer1.LocalReport.Render("PDF")
            Dim newFile As New FileStream(Location, FileMode.Create)
            newFile.Write(byteViewer, 0, byteViewer.Length)
            newFile.Close()
        Catch ex As Exception
            'MsgBox(Location & File_Name)
        End Try
    End Function
    Dim Email_Status As Boolean
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim mail As New MailMessage
            Dim SMTPServee As New SmtpClient
            mail.From = New MailAddress(Send_Email)
            mail.Subject = Txt2.Text
            mail.To.Add(Txt1.Text)
            mail.Body = Txt3.Text

            mail.Attachments.Add(New Net.Mail.Attachment(path))

            Dim SMTP As New SmtpClient("smtp.gmail.com")
            SMTP.EnableSsl = True
            SMTP.Credentials = New Net.NetworkCredential(Send_Email, Send_Email_Password)
            SMTP.Port = "587"
            SMTP.Send(mail)
            Email_Status = True
        Catch ex As Exception
            Email_Status = False
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Button2.Show()

        If Email_Status = True Then
            Msg(NOT_Type.Success, "Successfully Send Email", "")
        Else
            Msg(NOT_Type.Erro, "Email Sending Error", "")
        End If
    End Sub

    Private Sub Print_Priew_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        Try
            My.Computer.FileSystem.DeleteFile(path)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ReportViewer2_Load(sender As Object, e As EventArgs)

    End Sub

    Private Sub Select_2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Select_2.SelectedIndexChanged
        ReportViewer1.LocalReport.ReportPath = Print_Path & "\" & Select_2.Text
        Link_xml(Print_Path & "\" & Select_2.Text.ToString.Split(".").First & ".xml")
        Try
            ReportViewer1.LocalReport.SetParameters(Print_Param)
        Catch ex As Exception


        End Try
        ReportViewer1.RefreshReport()
    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click
        ReportViewer1.Refresh()
        ReportViewer1.RefreshReport()

    End Sub
End Class