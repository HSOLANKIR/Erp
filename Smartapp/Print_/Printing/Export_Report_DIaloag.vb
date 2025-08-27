Imports System.IO
Imports Microsoft.Reporting.WinForms

Public Class Export_Report_DIaloag
    Private Sub Export_Report_DIaloag_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim saveFileDialog1 As New SaveFileDialog()
        saveFileDialog1.Filter = "*PDF files (*.pdf)|*.pdf"
        saveFileDialog1.FileName = Printing_Direct_frm.ExportName
        If saveFileDialog1.ShowDialog = DialogResult.OK Then
            pdf_export(saveFileDialog1.FileName)
            Me.Dispose()

        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim saveFileDialog1 As New SaveFileDialog()
        saveFileDialog1.Filter = "*Excel files (*.xlsx)|*.xlsx"
        saveFileDialog1.FileName = Printing_Direct_frm.ExportName
        If saveFileDialog1.ShowDialog = DialogResult.OK Then
            excel_export(saveFileDialog1.FileName)
            Me.Dispose()

        End If
    End Sub
    Public Function pdf_export(path As String)
        Dim byteViewer As Byte() = Printing_Direct_frm.ReportViewer1.LocalReport.Render("PDF")
        Dim newFile As New FileStream(path, FileMode.Create)
        newFile.Write(byteViewer, 0, byteViewer.Length)
        newFile.Close()
    End Function
    Public Function excel_export(path As String)
        Dim byteViewer As Byte() = Printing_Direct_frm.ReportViewer1.LocalReport.Render("EXCELOPENXML")
        Dim newFile As New FileStream(path, FileMode.Create)
        newFile.Write(byteViewer, 0, byteViewer.Length)
        newFile.Close()
    End Function
    Public Function word_export(path As String)
        Dim byteViewer As Byte() = Printing_Direct_frm.ReportViewer1.LocalReport.Render("WORDOPENXML")
        Dim newFile As New FileStream(path, FileMode.Create)
        newFile.Write(byteViewer, 0, byteViewer.Length)
        newFile.Close()
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim saveFileDialog1 As New SaveFileDialog()
        saveFileDialog1.Filter = "*Excel files (*.docx)|*.docx"
        saveFileDialog1.FileName = Printing_Direct_frm.ExportName
        If saveFileDialog1.ShowDialog = DialogResult.OK Then
            word_export(saveFileDialog1.FileName)
            Me.Dispose()
        End If
    End Sub

    Private Sub Export_Report_DIaloag_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub
End Class