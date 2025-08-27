Imports System.ComponentModel
Imports System.Drawing.Printing
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Xml
Imports Microsoft.Reporting.WinForms

Public Class Printing_frm
    'Dim Path_End As String
    Private Sub Printing_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label13.Text = Print_Name & ".pdf"


        'Load_background.RunWorkerAsync()
        'ReportViewer1.ZoomMode = ZoomMode.FullPage
        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        't_margin.Value = ReportViewer1.LocalReport.GetDefaultPageSettings.PaperSize
    End Sub

    Private Sub Printing_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        'Add_Hander_Remove_Handel(False)
        Frm_foCus()
    End Sub
    Public ReportData() As ReportDataSource
    Public Function Printing(path As String, name As String, ParamArray ReportData_() As ReportDataSource)
        'Cell("Printing")

        Dim frm As New Printing_frm
        frm.Print_Name = name
        frm.Print_Path = path
        frm.ReportData = ReportData_
        frm.Load_background.RunWorkerAsync()
        frm.ShowDialog()
    End Function
    Private Sub Printing_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        Frm_foCus()
    End Sub

    Private Sub Printing_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
        If e.KeyCode = Keys.P AndAlso e.Modifiers = Keys.Alt Then
            PictureBox10_Click(e, e)
        End If
        If e.KeyCode = Keys.D AndAlso e.Modifiers = Keys.Alt Then
            PictureBox2_Click(e, e)
        End If
        If e.KeyCode = Keys.E AndAlso e.Modifiers = Keys.Alt Then
            PictureBox3_Click(e, e)
        End If
        If e.KeyCode = Keys.O AndAlso e.Modifiers = Keys.Alt Then
            PictureBox4_Click(e, e)
        End If
        If e.KeyCode = Keys.W AndAlso e.Modifiers = Keys.Alt Then
            PictureBox8_Click(e, e)
        End If
        If e.KeyCode = Keys.E AndAlso e.Modifiers = Keys.Alt Then
            PictureBox7_Click(e, e)
        End If
    End Sub
    Private Sub Panel3_Click(sender As Object, e As EventArgs) Handles Panel3.Click
        Dim byteViewer As Byte() = ReportViewer1.LocalReport.Render("PDF")
        Dim saveFileDialog1 As New SaveFileDialog()
        saveFileDialog1.Filter = "*PDF files (*.pdf)|*.pdf"
        saveFileDialog1.FileName = Print_Name
        If saveFileDialog1.ShowDialog = DialogResult.OK Then
            Dim newFile As New FileStream(saveFileDialog1.FileName & "", FileMode.Create)
            newFile.Write(byteViewer, 0, byteViewer.Length)
            newFile.Close()
        End If
    End Sub
    Dim prt_list As List_frm
    Dim form_list As List_frm
    Public Print_Path As String = ""
    Public Print_Name As String = ""
    Public defolt_report As String
    Dim Print_Param As ReportParameter()
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

        For Each fi In aryFi
            strFileSize = (Math.Round(fi.Length / 1024)).ToString()
            ListBox1.Items.Add(fi.Name)
            If fi.Name = defolt_report Then
                dft_ = True
            End If

        Next
    End Function
    Dim dft_ As Boolean = False

    Private Function Change_Report_Format()
        ReportViewer1.RefreshReport()
        t_m = ReportViewer1.LocalReport.GetDefaultPageSettings.Margins.Top
        l_m = ReportViewer1.LocalReport.GetDefaultPageSettings.Margins.Left
        r_m = ReportViewer1.LocalReport.GetDefaultPageSettings.Margins.Right
        b_m = ReportViewer1.LocalReport.GetDefaultPageSettings.Margins.Bottom

        Page_size = ReportViewer1.LocalReport.GetDefaultPageSettings.PaperSize
        isLandscape = ReportViewer1.LocalReport.GetDefaultPageSettings.IsLandscape
    End Function

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs)
        ReportViewer1.PageSetupDialog()
    End Sub
    Private Sub Label16_Click(sender As Object, e As EventArgs) Handles Label16.Click
        ReportViewer1.PrintDialog()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim saveFileDialog1 As New SaveFileDialog()
        saveFileDialog1.Filter = "*PDF files (*.pdf)|*.pdf"
        saveFileDialog1.FileName = Print_Name
        If saveFileDialog1.ShowDialog = DialogResult.OK Then
            pdf_export(saveFileDialog1.FileName)
        End If
    End Sub
    Public Function pdf_export(path As String)
        Dim byteViewer As Byte() = ReportViewer1.LocalReport.Render("PDF")
        Dim newFile As New FileStream(path, FileMode.Create)
        newFile.Write(byteViewer, 0, byteViewer.Length)
        newFile.Close()
    End Function
    Public Function excel_export(path As String)
        Dim byteViewer As Byte() = ReportViewer1.LocalReport.Render("EXCELOPENXML")
        Dim newFile As New FileStream(path, FileMode.Create)
        newFile.Write(byteViewer, 0, byteViewer.Length)
        newFile.Close()
    End Function
    Public Function word_export(path As String)
        Dim byteViewer As Byte() = ReportViewer1.LocalReport.Render("WORDOPENXML")
        Dim newFile As New FileStream(path, FileMode.Create)
        newFile.Write(byteViewer, 0, byteViewer.Length)
        newFile.Close()
    End Function
    Private Sub PictureBox10_Click(sender As Object, e As EventArgs) Handles PictureBox10.Click, Label14.Click
        print_microsoft_report(ReportViewer1.LocalReport, Select_1.Text, NumericUpDown1.Value, page_info)
    End Sub
    Private Function Panel_Manag(p As Panel)
        bg_Panel.Visible = False
        load_panel.Visible = False

        p.Visible = True
    End Function
    Public t_m As Integer = 0.02
    Public b_m As Integer = 0.02
    Public l_m As Integer = 0.02
    Public r_m As Integer = 0.02

    Public Page_size As PaperSize
    Public isLandscape As Boolean

    Public Function page_info() As String
        Dim w As Integer
        Dim h As Integer
        Dim doc As New PrintDocument()
        If isLandscape = True Then
            w = ReportViewer1.LocalReport.GetDefaultPageSettings.PaperSize.Height
            h = ReportViewer1.LocalReport.GetDefaultPageSettings.PaperSize.Width
        Else
            w = ReportViewer1.LocalReport.GetDefaultPageSettings.PaperSize.Width
            h = ReportViewer1.LocalReport.GetDefaultPageSettings.PaperSize.Height
        End If

        Dim s As String = $"<DeviceInfo>
            <OutputFormat>EMF</OutputFormat>
            <PageWidth>{w / 100 }in</PageWidth>
            <PageHeight>{h / 100 }in</PageHeight>
            <MarginTop>{t_m / 100}in</MarginTop>
            <MarginLeft>{l_m / 100}in</MarginLeft>
            <MarginRight>{r_m / 100}in</MarginRight>
            <MarginBottom>{b_m / 100}in</MarginBottom>
            </DeviceInfo>"

        My.Computer.Clipboard.SetText(s)
        Return s
    End Function

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        If Print_Page_Seting_dialoag.ShowDialog() = DialogResult.OK Then
            With ReportViewer1.LocalReport.GetDefaultPageSettings
                .Margins.Top = t_m
                .Margins.Bottom = b_m
                .Margins.Left = l_m
                .Margins.Right = r_m
            End With
            ReportViewer1.RefreshReport()
        End If
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Dim saveFileDialog1 As New SaveFileDialog()
        saveFileDialog1.Filter = "*Excel files (*.xlsx)|*.xlsx"
        saveFileDialog1.FileName = Print_Name
        If saveFileDialog1.ShowDialog = DialogResult.OK Then
            excel_export(saveFileDialog1.FileName)
        End If
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Dim saveFileDialog1 As New SaveFileDialog()
        saveFileDialog1.Filter = "*Excel files (*.docx)|*.docx"
        saveFileDialog1.FileName = Print_Name
        If saveFileDialog1.ShowDialog = DialogResult.OK Then
            word_export(saveFileDialog1.FileName)
        End If
    End Sub
    Private Function Create_File_Name() As String
        Dim OPT_Hint As String = ((Val(Now.Date.Day) + Val(Now.Date.Millisecond) + Val(Now.Date.Second) & Val(Val(Now.TimeOfDay.Hours + Now.TimeOfDay.Minutes & Now.Date.Month + Now.Date.Day)) + Val(Val(Now.Date.Year))) - Val(Now.TimeOfDay.Seconds) + Val(Now.TimeOfDay.Milliseconds)) * 12552
        Return Val(OPT_Hint) * 999
    End Function
    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click, Label9.Click
        Dim path As String = ""

        If CheckBox1.Checked = True Then
            path = Application.StartupPath & $"\_other_savefiles\{Create_File_Name()}.pdf"
            pdf_export(path)
        End If
        If CheckBox2.Checked = True Then
            path = Application.StartupPath & $"\_other_savefiles\{Create_File_Name()}.xlsx"
            excel_export(path)
        End If
        If CheckBox3.Checked = True Then
            path = Application.StartupPath & $"\_other_savefiles\{Create_File_Name()}.docx"
            word_export(path)
        End If

        Direct_Communication_frm.path_ = path
        Direct_Communication_frm.ifSingal = True
        Direct_Communication_frm.ShowDialog()
    End Sub

    Private Sub load_panel_Paint(sender As Object, e As PaintEventArgs) Handles load_panel.Paint
        obj_center(sender, Me)
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles Load_background.DoWork
        Driver_detect()
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles Load_background.RunWorkerCompleted
        Try
            ListBox1.SelectedIndex = 0
            'ReportViewer1.LocalReport.ReportPath = Print_Path & "\" & Select_2.Text
            'ReportViewer1.LocalReport.SetParameters(Print_Param)

            'ReportViewer1.RefreshReport()
        Catch ex As Exception

        End Try

        If dft_ = True Then
            SetDefaultSelectionManual()
        End If

        Select_1.Text = Primary_Printer
        Change_Report_Format()
        Panel_Manag(bg_Panel)
    End Sub

    Private Sub SetDefaultSelectionManual()
        Dim index As Integer = ListBox1.FindString(defolt_report)
        If index >= 0 Then
            ListBox1.SelectedIndex = index
        End If
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click, Label8.Click

    End Sub

    Private Sub Printing_frm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Me.Dispose()
    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click
        ReportViewer1.GetTotalPages
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs)
        If CheckBox1.Checked = True Then
            Dim saveFileDialog1 As New SaveFileDialog()
            saveFileDialog1.Filter = "*PDF files (*.pdf)|*.pdf"
            saveFileDialog1.FileName = Print_Name
            If saveFileDialog1.ShowDialog = DialogResult.OK Then
                pdf_export(saveFileDialog1.FileName)
            End If
        End If
        If CheckBox2.Checked = True Then
            Dim saveFileDialog1 As New SaveFileDialog()
            saveFileDialog1.Filter = "*Excel files (*.xlsx)|*.xlsx"
            saveFileDialog1.FileName = Print_Name
            If saveFileDialog1.ShowDialog = DialogResult.OK Then
                excel_export(saveFileDialog1.FileName)
            End If
        End If
        If CheckBox3.Checked = True Then
            Dim saveFileDialog1 As New SaveFileDialog()
            saveFileDialog1.Filter = "*Excel files (*.docx)|*.docx"
            saveFileDialog1.FileName = Print_Name
            If saveFileDialog1.ShowDialog = DialogResult.OK Then
                word_export(saveFileDialog1.FileName)
            End If
        End If

    End Sub
    Private Sub ListBox1_DrawItem(sender As Object, e As DrawItemEventArgs) Handles ListBox1.DrawItem
        If e.Index < 0 Then Exit Sub

        Dim listBox As ListBox = CType(sender, ListBox)
        Dim itemText As String = listBox.Items(e.Index).ToString()

        ' Determine background color
        Dim backColor As Color
        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
            backColor = Color.FromArgb(254, 197, 48) ' Your custom selection color
        Else
            backColor = listBox.BackColor
        End If

        ' Draw background
        Using backBrush As New SolidBrush(backColor)
            e.Graphics.FillRectangle(backBrush, e.Bounds)
        End Using

        ' Draw text
        Using textBrush As New SolidBrush(listBox.ForeColor)
            e.Graphics.DrawString(itemText, e.Font, textBrush, e.Bounds)
        End Using

        ' Draw focus rectangle if needed
        e.DrawFocusRectangle()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        ReportViewer1.LocalReport.DataSources.Clear()

        ReportViewer1.LocalReport.ReportPath = Print_Path & "\" & ListBox1.SelectedItem
        Print_Param = Link_xml_printing(Print_Path & "\" & ListBox1.SelectedItem.ToString.Split(".").First & ".xml")
        Try
            ReportViewer1.LocalReport.SetParameters(Print_Param)
        Catch ex As Exception

        End Try

        For Each d As ReportDataSource In ReportData
            ReportViewer1.LocalReport.DataSources.Add(d)
        Next

        Dim pageSettings As New PageSettings()
        pageSettings.PaperSize = ReportViewer1.LocalReport.GetDefaultPageSettings.PaperSize
        pageSettings.Margins = ReportViewer1.LocalReport.GetDefaultPageSettings.Margins
        pageSettings.Landscape = ReportViewer1.LocalReport.GetDefaultPageSettings.IsLandscape
        ReportViewer1.SetPageSettings(pageSettings)

        ReportViewer1.LocalReport.Refresh()
        Change_Report_Format()
    End Sub

    Private Sub Load_background_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles Load_background.ProgressChanged

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            CheckBox2.Checked = False
            CheckBox3.Checked = False
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            CheckBox1.Checked = False
            CheckBox3.Checked = False
        End If

    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked = True Then
            CheckBox1.Checked = False
            CheckBox2.Checked = False
        End If

    End Sub
End Class