Imports System.ComponentModel
Imports System.Drawing.Printing
Imports System.IO
Imports Microsoft.Reporting.WinForms
Imports Microsoft.Win32

Public Class Printing_Direct_frm

    Public Report As LocalReport
    Public ReportData() As ReportDataSource
    Public ReportPath As String
    Public ReportName As String
    Public ExportName As String

    Public Frm_ As Object
    Public cfg_frm As New Object
    Private Sub Printing_Direct_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        obj_center(Load_Panel, Me)

        Printer_Driver_Find()
        List_set()

        Txt2.Text = Primary_Printer

        Load_data()
        ReportViewer1.RefreshReport()

    End Sub
    Dim ag_list As List_frm

    Private Function List_set()
        ag_list = New List_frm
        List_Setup("List of Printer", Select_List.Right, Select_List_Format.Singel, Txt2, ag_list, BindingSource1, 250)

    End Function

    Private Function Printer_Driver_Find()
        Dim dt As New DataTable
        dt.Columns.Add("Name")
        Dim pkInstalledPrinters As String

        For Each pkInstalledPrinters In
            PrinterSettings.InstalledPrinters
            dt.Rows.Add(pkInstalledPrinters)
        Next pkInstalledPrinters

        BindingSource1.DataSource = dt
    End Function

    Public Function Printing_(path As String, nm As String, export_name As String, ParamArray data() As ReportDataSource)
        ReportName = nm
        ReportPath = path
        ReportData = data
        ExportName = export_name

        Me.Text = ExportName

        Me.ShowDialog()
    End Function
    Private Function Load_data()
        Report = New LocalReport
        Report.ReportPath = ReportPath & ".rdlc"
        For Each s As ReportDataSource In ReportData
            Report.DataSources.Add(s)
        Next

        ReportViewer1.LocalReport.ReportPath = ReportPath & ".rdlc"
        For Each d As ReportDataSource In ReportData
            ReportViewer1.LocalReport.DataSources.Add(d)
            Report.DataSources.Add(d)
        Next

        Dim parmm = Link_xml_printing(ReportPath & ".xml")

        Report.SetParameters(parmm)
        ReportViewer1.LocalReport.SetParameters(parmm)

    End Function

    Private Function Refresh_Data()

        If Report.GetDefaultPageSettings.IsLandscape = True Then
            Label26.Text = "Landscape"
        Else
            Label26.Text = "Portrait"
        End If

        With Report.GetDefaultPageSettings
            Label13.Text = .Margins.Top / 100 & " in."
            Label10.Text = .Margins.Left / 100 & " in."
            Label19.Text = .Margins.Bottom / 100 & " in."
            Label16.Text = .Margins.Right / 100 & " in."
        End With

        Label23.Text = $"{ReportViewer1.GetTotalPages()} Pages"

        obj_center(Panel1, Me)

        Load_Panel.Visible = False
        Panel1.Visible = True
    End Function
    Private Sub Printing_Direct_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter

    End Sub

    Private Sub Printing_Direct_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub Printing_Direct_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        Frm_foCus()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        obj_center(sender, Me)
    End Sub
    Private Sub Panel7_Paint(sender As Object, e As PaintEventArgs) Handles Load_Panel.Paint
        obj_center(Load_Panel, Me)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        PictureBox1.Image = My.Resources.printing_animation_icn
        Label28.Text = "Printing Document.."
        Load_Panel.Show()
        Panel1.Hide()

        BackgroundWorker2.RunWorkerAsync()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim path As String() = ReportPath.Split("\")
        Dim s As String
        For t As Integer = 0 To path.Length - 2
            s &= path(t) & "\"
        Next
        s = s.Substring(0, s.Length - 1)
        'Printing_frm.Printing(s, ReportName, ReportData)


        Dim frm As New Printing_frm
        With frm
            .Print_Name = ExportName
            .Print_Path = s
            .ReportData = ReportData
            .Load_background.RunWorkerAsync()
            .Show()
        End With


        'Me.Dispose()

    End Sub

    Private Sub BackgroundWorker2_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        Direct_Print(Report, Val(Txt1.Text), Txt2.Text)
    End Sub

    Private Sub BackgroundWorker2_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker2.RunWorkerCompleted
        Me.Dispose()
    End Sub

    Private Sub Printing_Direct_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus

    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        With Print_Cfg_Dialoag
            .Ctrl = cfg_frm
            .Text = Me.Text & " Print Configuration"
            .ShowDialog()
        End With
    End Sub

    Private Sub Txt1_TextChanged(sender As Object, e As EventArgs) Handles Txt1.TextChanged

    End Sub

    Private Sub Txt1_LostFocus(sender As Object, e As EventArgs) Handles Txt1.LostFocus
        If Val(Txt1.Text) = 0 Then
            Txt1.Text = "1"
        End If
    End Sub

    Private Sub Txt2_TextChanged(sender As Object, e As EventArgs) Handles Txt2.TextChanged

    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        Export_Report_DIaloag.ShowDialog()
    End Sub
    Public Function pdf_export(path As String)
        Dim byteViewer As Byte() = ReportViewer1.LocalReport.Render("PDF")
        Dim newFile As New FileStream(path, FileMode.Create)
        newFile.Write(byteViewer, 0, byteViewer.Length)
        newFile.Close()
    End Function

    Private Sub Load_Back_DoWork(sender As Object, e As DoWorkEventArgs)

    End Sub

    Private Sub Load_Back_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs)

    End Sub

    Private Sub ReportViewer1_Load(sender As Object, e As RenderingCompleteEventArgs) Handles ReportViewer1.RenderingComplete
        Refresh_Data()



        If TypeOf cfg_frm Is UserControl Then
            Button4.Enabled = True
            SendKeys.Send("{TAB}")
            SendKeys.Send("{TAB}")
        Else
            Button4.Enabled = False
            SendKeys.Send("{TAB}")
        End If

        'Try
        '    If IsNothing(cfg_frm.Name) Then
        '        Button4.Enabled = False
        '        SendKeys.Send("{TAB}")
        '    Else
        '        Button4.Enabled = True
        '        SendKeys.Send("{TAB}")
        '        SendKeys.Send("{TAB}")
        '    End If
        'Catch ex As Exception
        '    Button4.Enabled = False
        '    SendKeys.Send("{TAB}")
        'End Try
    End Sub
    Private Function Create_File_Name() As String
        Dim OPT_Hint As String = ((Val(Now.Date.Day) + Val(Now.Date.Millisecond) + Val(Now.Date.Second) & Val(Val(Now.TimeOfDay.Hours + Now.TimeOfDay.Minutes & Now.Date.Month + Now.Date.Day)) + Val(Val(Now.Date.Year))) - Val(Now.TimeOfDay.Seconds) + Val(Now.TimeOfDay.Milliseconds)) * 12552
        Return Val(OPT_Hint) * 999
    End Function
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim path As String = ""
        path = Application.StartupPath & $"\_other_savefiles\{Create_File_Name()}.pdf"
        pdf_export(path)

        Direct_Communication_frm.path_ = path
        Direct_Communication_frm.ifSingal = True
        Direct_Communication_frm.Show()
    End Sub

    Private Sub Label26_Click(sender As Object, e As EventArgs) Handles Label26.Click

    End Sub

    Private Sub Label23_Click(sender As Object, e As EventArgs) Handles Label23.Click

    End Sub
End Class