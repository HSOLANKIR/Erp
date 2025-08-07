Imports System
Imports System.IO
Imports System.Data
Imports System.Text
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Printing
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports Microsoft.Reporting.WinForms
Imports System.Xml

Module Direct_print_mod
    Private m_currentPageIndex As Integer
    Private m_streams As IList(Of Stream)
    Private printdoc As PrintDocument
    Public Sub print_microsoft_report(ByVal report As LocalReport, printer_name As String, copy As Integer, devideinfo As String)
        printdoc = New PrintDocument()
        If printer_name <> Nothing Then
            printdoc.PrinterSettings.PrinterName = printer_name
            printdoc.PrinterSettings.Copies = copy
        End If
        If Not printdoc.PrinterSettings.IsValid Then ' detecate is the printer is exist
            Throw New Exception("Cannot find the specified printer")
        Else
            Dim ps As PaperSize = report.GetDefaultPageSettings.PaperSize
            Dim pagekind_found As Boolean = False
            printdoc.DefaultPageSettings.PaperSize = ps
            For i = 0 To printdoc.PrinterSettings.PaperSizes.Count - 1
                pagekind_found = True
                Exit For
            Next
            If Not pagekind_found Then Throw New Exception("paper size is invalid")
            printdoc.DefaultPageSettings.Landscape = report.GetDefaultPageSettings.IsLandscape
            Export(report, devideinfo)
            Print()
        End If

    End Sub

    ' Routine to provide to the report renderer, in order to
    ' save an image for each page of the report.
    Private Function CreateStream(ByVal name As String, ByVal fileNameExtension As String, ByVal encoding As Encoding, ByVal mimeType As String, ByVal willSeek As Boolean) As Stream
        Dim stream As Stream = New MemoryStream()
        m_streams.Add(stream)
        Return stream
    End Function
    ' Export the given report as an EMF (Enhanced Metafile) file.
    Private Sub Export(ByVal report As LocalReport, deviceInfo As String)
        Dim w As Integer
        Dim h As Integer
        If printdoc.DefaultPageSettings.Landscape = True Then
            w = printdoc.DefaultPageSettings.PaperSize.Width
            h = printdoc.DefaultPageSettings.PaperSize.Height
        Else
            w = printdoc.DefaultPageSettings.PaperSize.Width
            h = printdoc.DefaultPageSettings.PaperSize.Height
        End If
        Dim warnings As Warning()
        m_streams = New List(Of Stream)()
        report.Render("Image", deviceInfo, AddressOf CreateStream, warnings)
        For Each stream As Stream In m_streams
            stream.Position = 0
        Next

    End Sub

    ' Handler for PrintPageEvents
    Private Sub PrintPage(ByVal sender As Object, ByVal ev As PrintPageEventArgs)
        Dim pageImage As New Metafile(m_streams(m_currentPageIndex))

        ' Adjust rectangular area with printer margins.
        Dim adjustedRect As New Rectangle(ev.PageBounds.Left - CInt(ev.PageSettings.HardMarginX),
                                          ev.PageBounds.Top - CInt(ev.PageSettings.HardMarginY),
                                          ev.PageBounds.Width,
                                          ev.PageBounds.Height)

        ' Draw a white background for the report
        ev.Graphics.FillRectangle(Brushes.White, adjustedRect)

        ' Draw the report content
        ev.Graphics.DrawImage(pageImage, adjustedRect)

        ' Prepare for the next page. Make sure we haven't hit the end.
        m_currentPageIndex += 1
        ev.HasMorePages = (m_currentPageIndex < m_streams.Count)
    End Sub
    Private Sub Print()
        If m_streams Is Nothing OrElse m_streams.Count = 0 Then
            Throw New Exception("Error: no stream to print.")
        End If
        AddHandler printdoc.PrintPage, AddressOf PrintPage
        m_currentPageIndex = 0
        printdoc.Print()
    End Sub
    Public Function Export_PDF(ReportPath As String, export_path As String, ParamArray data() As ReportDataSource)
        Dim Report As New LocalReport

        Report.ReportPath = ReportPath & ".rdlc"
        Report.SetParameters(Link_xml_printing(ReportPath & ".xml"))

        For Each s As ReportDataSource In data
            Report.DataSources.Add(s)
        Next

        Report.Refresh()
        Dim byteViewer As Byte() = Report.Render("PDF")
        Dim newFile As New FileStream(export_path, FileMode.Create)
        newFile.Write(byteViewer, 0, byteViewer.Length)
        newFile.Close()
    End Function
    Public Function Direct_Print(report As LocalReport, copy_ As Integer, printer_ As String)
        print_microsoft_report(report, printer_, copy_, page_info(report))
    End Function
    Public Function Direct_Print(report_path As String, ParamArray full_Datasource() As ReportDataSource)
        Dim report As New LocalReport
        report.ReportPath = report_path
        Dim t_m As String = report.GetDefaultPageSettings.Margins.Top
        Dim l_m As String = report.GetDefaultPageSettings.Margins.Left
        Dim r_m As String = report.GetDefaultPageSettings.Margins.Right
        Dim b_m As String = report.GetDefaultPageSettings.Margins.Bottom

        Dim Page_size As PaperSize = report.GetDefaultPageSettings.PaperSize
        Dim isLandscape As String = report.GetDefaultPageSettings.IsLandscape

        report.SetParameters(Link_xml_printing(report_path.ToString.Split(".").First & ".xml"))

        For Each dt As ReportDataSource In full_Datasource
            report.DataSources.Add(dt)
        Next

        print_microsoft_report(report, Primary_Printer, 1, page_info(report))
    End Function
    Public Function page_info(report As LocalReport) As String
        Dim w As Integer
        Dim h As Integer
        Dim doc As New PrintDocument()
        If report.GetDefaultPageSettings.IsLandscape = True Then
            w = report.GetDefaultPageSettings.PaperSize.Height
            h = report.GetDefaultPageSettings.PaperSize.Width
        Else
            w = report.GetDefaultPageSettings.PaperSize.Width
            h = report.GetDefaultPageSettings.PaperSize.Height
        End If

        Dim t_m As String = report.GetDefaultPageSettings.Margins.Top
        Dim l_m As String = report.GetDefaultPageSettings.Margins.Left
        Dim r_m As String = report.GetDefaultPageSettings.Margins.Right
        Dim b_m As String = report.GetDefaultPageSettings.Margins.Bottom

        Dim s As String = $"<DeviceInfo>
            <OutputFormat>EMF</OutputFormat>
            <PageWidth>{w / 100 }in</PageWidth>
            <PageHeight>{h / 100 }in</PageHeight>
            <MarginTop>{t_m / 100}in</MarginTop>
            <MarginLeft>{l_m / 100}in</MarginLeft>
            <MarginRight>{r_m / 100}in</MarginRight>
            <MarginBottom>{b_m / 100}in</MarginBottom>
            </DeviceInfo>"

        Return s
    End Function
    Public Function Link_xml_printing(path_of_xml As String)
        Dim paramtr(xml_info(path_of_xml)) As ReportParameter

        Dim xml As XmlTextReader
        xml = New XmlTextReader(path_of_xml)
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
        Return paramtr
    End Function
    Private Function xml_info(path As String) As Integer
        Dim xmldoc As New XmlDataDocument()
        Dim fs As New FileStream(path, FileMode.Open, FileAccess.Read)
        xmldoc.Load(fs)
        Dim Globalobjectscount = xmldoc.GetElementsByTagName("name").Count

        Return Val(Globalobjectscount) - 1
    End Function
End Module
