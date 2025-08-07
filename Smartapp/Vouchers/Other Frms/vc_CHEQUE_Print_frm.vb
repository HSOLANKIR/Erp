Imports System.Data.SQLite
Imports System.Drawing.Printing


Public Class vc_CHEQUE_Print_frm
    Dim From_ID As String
    Dim Path_End As String
    Public Ledger_ID As String
    Public Ledger_Name As String
    Public Amount As String
    Public Date_ As String
    Public focus_Object As Object
    Private Sub vc_CHEQUE_Print_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text
        obj_top(Panel1)

        BG_frm.HADE_TXT.Text = "Cheque Print"
        BG_frm.TYP_TXT.Text = ""

        Button_Manage()
        NOT_Clear()
        Add_Hander_Remove_Handel(True)

        Load_Data()
        Fill_data_source()
        List_set()

        Paper_Size_set()

    End Sub

    Private Function Button_Manage()
        BG_frm.B_1.Text = "&E : Exit"
        BG_frm.B_2.Text = "&S : Save"
    End Function
    Private Function Add_Hander_Remove_Handel(Ans As Boolean)
        If Ans = True Then
            AddHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            AddHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
        Else
            RemoveHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            RemoveHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
        End If
    End Function
    Private Sub B_1_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Me.Dispose()
        End If
    End Sub
    Private Sub B_2_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Save_()
            Me.Dispose()
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Function Save_()
        With Inventory_Vouchers_frm

        End With
    End Function
    Private Sub vc_CHEQUE_Print_frm_Enter(sender As Object, e As EventArgs) Handles MyBase.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.HADE_TXT.Text = "Cheque Print"
        BG_frm.TYP_TXT.Text = ""
        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text

        Button_Clear()
        Button_Manage()
        Fill_data_source()
    End Sub

    Private Sub vc_CHEQUE_Print_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub vc_CHEQUE_Print_frm_Disposed(sender As Object, e As EventArgs) Handles MyBase.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End
        Add_Hander_Remove_Handel(False)
    End Sub
    Private Function Fill_data_source()
        Dim dt As New DataTable
        dt.Columns.Add("Name")
        Dim pkInstalledPrinters As String

        For Each pkInstalledPrinters In
            PrinterSettings.InstalledPrinters
            dt.Rows.Add(pkInstalledPrinters)
        Next pkInstalledPrinters

        Printer_Source.DataSource = dt
    End Function
    Dim ag_list As List_frm
    Private Function List_set()
        ag_list = New List_frm
        List_Setup("List of Printer", Select_List.Right, Select_List_Format.Singel, Defolt_Printer_Select, ag_list, Printer_Source, 250)
    End Function
    Private Sub SAVE_TXT_Enter(sender As Object, e As EventArgs)
        BG_frm.B_2.PerformClick()
    End Sub
    Private _PaperSize As Printing.PaperSize
    Public Sub Paper_Size_set()
        Try
            ' Start the print.
            _PaperSize = New PaperSize()
            _PaperSize.RawKind = PaperKind.Custom
            _PaperSize.Width = Cheque_Width
            _PaperSize.Height = Cheque_Height
            _PaperSize.PaperName = Cheque_Height

            'PrintDocument1.DefaultPageSettings.PaperSize = _PaperSize
            'PrintDocument1.PrinterSettings.DefaultPageSettings.PaperSize = _PaperSize


        Catch ex As Exception
            Throw
        End Try
    End Sub
    Private Function Load_Data()
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select * From TBL_Cheque_Design where Ledger_ID = '{Ledger_ID}'", cn)
            Dim r As SQLiteDataReader = cmd.ExecuteReader
            While r.Read
                Cheque_Width = Val(r("Width").ToString)
                Cheque_Height = Val(r("Height").ToString)
                Cheque_Cross_Top = Val(r("Cross_Top").ToString)
                Cheque_Cross_Left = Val(r("Cross_Left").ToString)
                Cheque_Date_Top = Val(r("Date_Top").ToString)
                Cheque_Date_Left = Val(r("Date_Left").ToString)
                Cheque_Date_Format = (r("Date_Format").ToString)
                Cheque_Date_Separator = (r("Date_Separator").ToString)
                Cheque_Date_Distance = Val(r("Date_Distance").ToString)
                Cheque_Party_Top = Val(r("Party_Top").ToString)
                Cheque_Party_Left = Val(r("Party_Left").ToString)
                Cheque_Party_area = Val(r("Party_Width").ToString)
                Cheque_AmountW1_Top = Val(r("Amount_Word_1_Top").ToString)
                Cheque_AmountW1_Left = Val(r("Amount_Word_1_Left").ToString)
                Cheque_AmountW1_Width = Val(r("Amount_Word_1_Width").ToString)
                Cheque_AmountW2_Top = Val(r("Amount_Word_2_Top").ToString)
                Cheque_AmountW2_Left = Val(r("Amount_Word_2_Left").ToString)
                Cheque_AmountW2_Width = Val(r("Amount_Word_2_Width").ToString)
                Cheque_Amount_Top = Val(r("Amount_Top").ToString)
                Cheque_Amount_Left = Val(r("Amount_Left").ToString)
                Cheque_Amount_Width = Val(r("Amount_Width").ToString)
            End While
            r.Close()
        End If

        Pay_.Text = $"**{Ledger_Name}**"
        Amount_.Text = $"**{N2_FORMATE(Amount)}/-"
        DATE_TXT.Text = CDate(Date_).ToString(Cheque_Date_Format)

        Dim amt_w As String = $"**{NumberToText(Val(Amount))}Only"
        Dim L1 As Integer = Val(Cheque_AmountW1_Width) * 0.55
        If amt_w.Length <= L1 Then
            amt_w1.Text = $"{amt_w}"
        Else
            amt_w1.Text = ""
            amt_w2.Text = ""
            Dim Line_F As Boolean = True
            For Each s As String In amt_w.Split(" ")
                If (Val(amt_w1.Text.Length) + s.Length <= L1) And Line_F = True Then
                    amt_w1.Text &= $"{s} "
                Else
                    amt_w2.Text &= $"{s} "
                    Line_F = False
                End If
            Next
        End If


        Defolt_Printer_Select.Text = Primary_Printer
    End Function
    Public Cheque_Width As Integer = 0
    Public Cheque_Height As Integer = 0

    Public Cheque_Cross_Top As Integer = 0
    Public Cheque_Cross_Left As Integer = 0

    Public Cheque_Date_Top As Integer = 0
    Public Cheque_Date_Left As Integer = 0
    Public Cheque_Date_Format As String = ""
    Public Cheque_Date_Separator As String = ""
    Public Cheque_Date_Distance As Integer = 0

    Public Cheque_Party_Top As Integer = 0
    Public Cheque_Party_Left As Integer = 0
    Public Cheque_Party_area As Integer = 0

    Public Cheque_AmountW1_Top As Integer = 0
    Public Cheque_AmountW1_Left As Integer = 0
    Public Cheque_AmountW1_Width As Integer = 0

    Public Cheque_AmountW2_Top As Integer = 0
    Public Cheque_AmountW2_Left As Integer = 0
    Public Cheque_AmountW2_Width As Integer = 0

    Public Cheque_Amount_Top As Integer = 0
    Public Cheque_Amount_Left As Integer = 0
    Public Cheque_Amount_Width As Integer = 0


    Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument1.PrintPage
        e.Graphics.PageUnit = GraphicsUnit.Millimeter

        Dim C As Integer = Val(Val(205) - Cheque_Height) / 2

        Dim rect As New Rectangle(C, -5, Cheque_Height, Cheque_Width)
        'e.Graphics.DrawRectangle(New Pen(Color.Black, 1), rect)

        C = (C + Cheque_Height) * -1

        'Party
        Dim T As Integer = C + Cheque_Party_Top
        Dim L As Integer = Cheque_Party_Left - 5
        e.Graphics.RotateTransform(90)
        e.Graphics.DrawString(Pay_.Text, New Font("Arial", 10, FontStyle.Bold), Brushes.Black, New PointF(L, T))
        e.Graphics.ResetTransform()

        If Yn1.Text = "Yes" Then
            'Cross Line
            T = C + Cheque_Cross_Top
            L = Cheque_Cross_Left - 5
            e.Graphics.RotateTransform(90)
            e.Graphics.DrawLine(New Pen(Color.Black, 0.25), L, T, L + 25, T)
            e.Graphics.ResetTransform()

            T = C + Cheque_Cross_Top + 0
            L = Cheque_Cross_Left - 2
            e.Graphics.RotateTransform(90)
            e.Graphics.DrawString("A/c Payee", New Font("Arial", 10, FontStyle.Bold), Brushes.Black, New PointF(L, T))
            e.Graphics.ResetTransform()

            T = C + Cheque_Cross_Top
            L = Cheque_Cross_Left - 5
            e.Graphics.RotateTransform(90)
            e.Graphics.DrawLine(New Pen(Color.Black, 0.25), L, T + 4, L + 25, T + 4)
            e.Graphics.ResetTransform()
        End If

        'date
        T = C + Cheque_Date_Top
        L = (Cheque_Date_Left - 5) - Cheque_Date_Distance
        For Each s As Char In DATE_TXT.Text
            L = L + Cheque_Date_Distance
            e.Graphics.RotateTransform(90)
            e.Graphics.DrawString(s, New Font("Arial", 10, FontStyle.Bold), Brushes.Black, New PointF(L, T))
            e.Graphics.ResetTransform()
        Next


        'Amount in word
        T = C + Cheque_AmountW1_Top
        L = Cheque_AmountW1_Left - 5
        e.Graphics.RotateTransform(90)
        e.Graphics.DrawString(amt_w1.Text, New Font("Arial", 10, FontStyle.Bold), Brushes.Black, New PointF(L, T))
        e.Graphics.ResetTransform()

        T = C + Cheque_AmountW2_Top
        L = Cheque_AmountW2_Left - 5
        e.Graphics.RotateTransform(90)
        e.Graphics.DrawString(amt_w2.Text, New Font("Arial", 10, FontStyle.Bold), Brushes.Black, New PointF(L, T))
        e.Graphics.ResetTransform()

        'Amount in Number
        T = C + Cheque_Amount_Top
        L = Cheque_Amount_Left - 5
        e.Graphics.RotateTransform(90)
        e.Graphics.DrawString(Amount_.Text, New Font("Arial", 12, FontStyle.Bold), Brushes.Black, New PointF(L, T))
        e.Graphics.ResetTransform()
    End Sub

    Private Sub DATE_TXT_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub DATE_TXT_Click_1(sender As Object, e As EventArgs) Handles DATE_TXT.Click

    End Sub

    Private Sub Yn1_TextChanged(sender As Object, e As EventArgs) Handles Yn1.TextChanged
        If Yn1.Text = "Yes" Then
            PictureBox1.Visible = True
        Else
            PictureBox1.Visible = False
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Dispose()
        focus_Object.Focus()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PrintDocument1.PrinterSettings.PrinterName = Defolt_Printer_Select.Text
        PrintDocument1.Print()
        Me.Dispose()
        focus_Object.Focus()
        SendKeys.Send("{TAB}")
    End Sub

    Private Sub vc_CHEQUE_Print_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
    End Sub
End Class