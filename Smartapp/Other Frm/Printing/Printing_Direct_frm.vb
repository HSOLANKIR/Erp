Imports System.ComponentModel
Imports Microsoft.Reporting.WinForms

Public Class Printing_Direct_frm

    Public Report As LocalReport
    Public ReportData() As ReportDataSource
    Public ReportPath As String
    Public ReportName As String

    Public Frm_ As Object
    Private Sub Printing_Direct_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        obj_center(Load_Panel, Me)

        Label4.Text = Primary_Printer

        BackgroundWorker1.RunWorkerAsync()


    End Sub
    Public Function Printing_(path As String, nm As String, ParamArray data() As ReportDataSource)
        ReportName = nm
        ReportPath = path
        ReportData = data

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
        Next

        Dim parmm = Link_xml_printing(ReportPath & ".xml")

        Report.SetParameters(parmm)
        ReportViewer1.LocalReport.SetParameters(parmm)
    End Function

    Private Function Refresh_Data()
        Label23.Text = ReportViewer1.GetTotalPages & " Pages"

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

        obj_center(Panel1, Me)

        Load_Panel.Visible = False
        Panel1.Visible = True

        Button2.Focus()
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

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Load_data()


    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        ReportViewer1.RefreshReport()

        For i As Integer = 0 To 100
            Refresh_Data()
        Next
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
            .Print_Name = Name
            .Print_Path = s
            .ReportData = ReportData
            .Load_background.RunWorkerAsync()
            .Show()
        End With


        'Me.Dispose()

    End Sub

    Private Sub BackgroundWorker2_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        Direct_Print(Report)
    End Sub

    Private Sub BackgroundWorker2_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker2.RunWorkerCompleted
        Me.Dispose()
    End Sub

    Private Sub Printing_Direct_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        Button1.Focus()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Refresh_Data()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Print_Cfg_frm.Load_()
        Frm_.Print_prmt()
        Print_Cfg_frm.ShowDialog()
    End Sub
End Class