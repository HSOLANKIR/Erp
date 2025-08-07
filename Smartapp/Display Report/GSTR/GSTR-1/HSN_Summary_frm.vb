Imports System.ComponentModel
Imports System.Data.SQLite

Public Class HSN_Summary_frm
    Dim From_ID As String
    Private VC_Type_ As String
    Private Path_End As String
    Dim YN_Details As Boolean
    Dim Acc_Under As String
    Dim Frm_date As Date
    Dim to_date As Date

    Public Narration_ As Boolean = False
    Public Sorting_Methoud_ As String = "Date (Decreasing)"
    Public Delete_Entry = False

    Dim ds_print As New Print_dt
    Dim dt_print As New DataTable

    Dim Defolt_Select_ID As String = 0
    Private Sub GSTR1_Ledger_Summary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text

        VC_Type_ = Link_Valu(0)

        Frm_Date_LB.Text = Date_Formate(Date_1)
        To_Date_LB.Text = Date_Formate(Date_2)

        GSLab.Text = Company_GST_str

        BG_frm.HADE_TXT.Text = "HSN/SAC Summary"
        BG_frm.TYP_TXT.Text = VC_Type_

        Button_Manage()
        Add_Hander_Remove_Handel(True)

        Update_Report = True
    End Sub

    Private Sub GSTR1_Ledger_Summary_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.HADE_TXT.Text = "HSN/SAC Summary"
        BG_frm.TYP_TXT.Text = VC_Type_

        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text


        Button_Clear()
        Button_Manage()
        'cfg_fill()
        If Update_Report = True Then
            Fill_Grid()
        End If
        Grid1.Focus()
    End Sub

    Private Sub GSTR1_Ledger_Summary_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
        If e.KeyCode = Keys.F2 AndAlso e.Modifiers = Keys.Alt Then
            BG_frm.R_3.PerformClick()
        ElseIf e.KeyCode = Keys.F2 Then
            BG_frm.R_2.PerformClick()
        End If
    End Sub

    Private Sub GSTR1_Ledger_Summary_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        Add_Hander_Remove_Handel(False)
        BG_frm.BG_Path_TXT.Text = Path_End
        Frm_foCus()
    End Sub
    Private Sub Frm_Date_LB_TextChanged(sender As Object, e As EventArgs) Handles Frm_Date_LB.TextChanged
        Frm_date = Frm_Date_LB.Text
    End Sub
    Private Sub To_Date_LB_TextChanged(sender As Object, e As EventArgs) Handles To_Date_LB.TextChanged
        to_date = To_Date_LB.Text
    End Sub
    Private Function Button_Manage()
        Button_Clear()
        BG_frm.R_2.Text = "F2 : Date"
        BG_frm.R_3.Text = "|F2 : Period"

        BG_frm.R_4.Text = "&X : CSV Exp."

    End Function
    Private Function Add_Hander_Remove_Handel(Ans As Boolean)
        If Ans = True Then
            AddHandler BG_frm.R_2.Click, AddressOf Me.R_2_Click
            AddHandler BG_frm.R_3.Click, AddressOf Me.R_3_Click

            AddHandler BG_frm.R_4.Click, AddressOf Me.R_4_Click
        Else
            RemoveHandler BG_frm.R_2.Click, AddressOf Me.R_2_Click
            RemoveHandler BG_frm.R_3.Click, AddressOf Me.R_3_Click

            RemoveHandler BG_frm.R_4.Click, AddressOf Me.R_4_Click

        End If
    End Function
    Dim Export_Location As String
    Private Sub R_4_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Dim SaveFileDialog1 As New SaveFileDialog
            With SaveFileDialog1

                .FileName = "HSN SAC Summary - 12"
                .Title = "Export csv"

                'MsgBox(.ShowDialog)
                If .ShowDialog = 1 Then
                    Export_Location = .FileName
                    Export_CSV_Background.RunWorkerAsync()
                Else
                End If
            End With

        End If
    End Sub
    Private Sub Export_CSV_Background_DoWork(sender As Object, e As DoWorkEventArgs) Handles Export_CSV_Background.DoWork
        HSN_Exp(Frm_date, to_date, False)
    End Sub
    Private Sub Export_CSV_Background_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles Export_CSV_Background.ProgressChanged


    End Sub
    Dim dt_export As DataTable
    Private Sub Export_CSV_Background_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles Export_CSV_Background.RunWorkerCompleted
        DataGridView1.DataSource = dt_export
        Export_csv(DataGridView1, $"{Export_Location}.csv")

    End Sub
    Public Function HSN_Exp(frm_ As Date, To_ As Date, ifexcel As Boolean) As DataTable
        dt_export = New DataTable
        dt_export.Columns.Add("HSN")
        dt_export.Columns.Add("Description")
        dt_export.Columns.Add("UQC")
        dt_export.Columns.Add("Total Quantity")
        dt_export.Columns.Add("Total Value")
        dt_export.Columns.Add("Taxable Value")
        dt_export.Columns.Add("Integrated Tax Amount")
        dt_export.Columns.Add("Central Tax Amount")
        dt_export.Columns.Add("State/UT Tax Amount")
        dt_export.Columns.Add("Cess Amount")
        dt_export.Columns.Add("Rate")

        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select it.HSN_Code,U.UQC,vi.GST_per,
(CASE WHEN vi.Type = 'Debit' THEN
ifnull(SUM(vi.Qty),0)
ELSE(
ifnull(SUM(vi.Qty),0) * -1
)END) as Qty,

(CASE WHEN vi.Type = 'Debit' THEN
ifnull(SUM(vi.CGST),0)
ELSE(
ifnull(SUM(vi.CGST),0) * -1
)END) as CGST,

(CASE WHEN vi.Type = 'Debit' THEN
ifnull(SUM(vi.Cess_Amt),0)
ELSE(
ifnull(SUM(vi.Cess_Amt),0) * -1
)END) as Cess,

(CASE WHEN vi.Type = 'Debit' THEN
ifnull(SUM(vi.SGST),0)
ELSE(
ifnull(SUM(vi.SGST),0) * -1
)END) as SGST,

(CASE WHEN vi.Type = 'Debit' THEN
ifnull(SUM(vi.IGST),0)
ELSE(
ifnull(SUM(vi.IGST),0) * -1
)END) as IGST,

(CASE WHEN vi.Type = 'Debit' THEN
ifnull(SUM(vi.Amount),0)
ELSE(
ifnull(SUM(vi.Amount),0) * -1
)END) as Amt


From TBL_VC_Item_Details vi
LEFT JOIN TBL_VC vc on vc.Tra_ID = vi.Tra_ID
LEFT JOIN TBL_Stock_Item it on it.ID = vi.Item
LEFT JOIN TBL_Inventory_Unit U on U.ID = it.Unit
WHERE vc.Visible = 'Approval' and vc.Type = 'Head' and (vc.Voucher_Type = 'Sales' or vc.Voucher_Type = 'Credit Note' or vc.Voucher_Type = 'Debit Note') and (vc.Date BETWEEN '{CDate(frm_).ToString(Lite_date_Format)}' and '{CDate(To_).AddDays(1).ToString(Lite_date_Format)}')
Group By it.HSN_Code,U.UQC,vi.GST_per", cn)
            Dim r As SQLiteDataReader = cmd.ExecuteReader
            'My.Computer.Clipboard.SetText(cmd.CommandText)
            While r.Read
                Dim to_gst As Decimal = Val(Val(r("IGST").ToString) + Val(r("CGST").ToString) + Val(r("SGST").ToString))
                Dim HSN As String = r("HSN_Code").ToString
                Dim UQC As String = r("UQC").ToString
                Dim Qty As String = r("Qty").ToString
                Dim To_Amt As String = Val(r("Amt").ToString) + to_gst
                Dim tx_rate As String = (r("GST_per").ToString)
                Dim taxable_amt As String = (r("Amt").ToString)
                Dim CGST As String = (r("CGST").ToString)
                Dim SGST As String = (r("SGST").ToString)
                Dim IGST As String = (r("IGST").ToString)
                Dim Cess As String = (r("Cess").ToString)

                If HSN.ToString <> Nothing Then

                    dt_export.Rows.Add(HSN,
                                            "",
                                            UQC,
                                            Qty,
                                            To_Amt,
                                            taxable_amt,
                                            IGST,
                                            CGST,
                                            SGST,
                                            Cess,
                                            tx_rate
)
                End If
            End While
        End If

        Return dt_export
    End Function
    Private Sub R_2_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Set_Date(False, Me)
        End If
    End Sub
    Private Sub R_3_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Set_Date(True, Me)
        End If
    End Sub
    Public Function Apply_Date_Filter(ifPeriod As Boolean)
        If ifPeriod = True Then
            Frm_Date_LB.Text = Date_Formate(Date_1)
            To_Date_LB.Text = Date_Formate(Date_2)
        Else
            Frm_Date_LB.Text = Date_Formate(Date_3)
            To_Date_LB.Text = Date_Formate(Date_3)
        End If
        Fill_Grid()
    End Function
    Private Sub pANEL1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        Dim ctlpos As Point = H1.PointToScreen(H1.DisplayRectangle.Location)
        B1.Location = New Point(ctlpos.X, 0)
        B1.Height = Panel1.Height

        ctlpos = H2.PointToScreen(H2.DisplayRectangle.Location)
        B2.Location = New Point(ctlpos.X, 0)
        B2.Height = Panel1.Height

        ctlpos = H3.PointToScreen(H3.DisplayRectangle.Location)
        B3.Location = New Point(ctlpos.X, 0)
        B3.Height = Panel1.Height

        ctlpos = H4.PointToScreen(H4.DisplayRectangle.Location)
        B4.Location = New Point(ctlpos.X, 0)
        B4.Height = Panel1.Height

        ctlpos = H5.PointToScreen(H5.DisplayRectangle.Location)
        B10.Location = New Point(ctlpos.X, 0)
        B10.Height = Panel1.Height

        ctlpos = H6.PointToScreen(H6.DisplayRectangle.Location)
        B5.Location = New Point(ctlpos.X, 0)
        B5.Height = Panel1.Height

        ctlpos = H7.PointToScreen(H7.DisplayRectangle.Location)
        B6.Location = New Point(ctlpos.X, 0)
        B6.Height = Panel1.Height

        ctlpos = H8.PointToScreen(H8.DisplayRectangle.Location)
        B7.Location = New Point(ctlpos.X, 0)
        B7.Height = Panel1.Height

        ctlpos = H9.PointToScreen(H9.DisplayRectangle.Location)
        B8.Location = New Point(ctlpos.X, 0)
        B8.Height = Panel1.Height

        ctlpos = H10.PointToScreen(H10.DisplayRectangle.Location)
        B9.Location = New Point(ctlpos.X, 0)
        B9.Height = Panel1.Height

        ctlpos = H11.PointToScreen(H11.DisplayRectangle.Location)
        B11.Location = New Point(ctlpos.X, 0)
        B11.Height = Panel1.Height




    End Sub
    Public Function Fill_Grid()
        GSLab.Text = Company_GST_str

        HNS_Claculation()
    End Function
    Private Function HNS_Claculation()
        Dim Ledger_ID As String = ""
        Dim Ledger_Name As String = ""
        Dim GSTNo As String = ""

        Dim Vch_total As String = ""


        Grid1.Rows.Clear()

        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select it.HSN_Code,U.UQC,vi.GST_per,
(CASE WHEN vi.Type = 'Debit' THEN
ifnull(SUM(vi.Qty),0)
ELSE(
ifnull(SUM(vi.Qty),0) * -1
)END) as Qty,

(CASE WHEN vi.Type = 'Debit' THEN
ifnull(SUM(vi.CGST),0)
ELSE(
ifnull(SUM(vi.CGST),0) * -1
)END) as CGST,

(CASE WHEN vi.Type = 'Debit' THEN
ifnull(SUM(vi.SGST),0)
ELSE(
ifnull(SUM(vi.SGST),0) * -1
)END) as SGST,

(CASE WHEN vi.Type = 'Debit' THEN
ifnull(SUM(vi.IGST),0)
ELSE(
ifnull(SUM(vi.IGST),0) * -1
)END) as IGST,

(CASE WHEN vi.Type = 'Debit' THEN
ifnull(SUM(vi.Cess_Amt),0)
ELSE(
ifnull(SUM(vi.Cess_Amt),0) * -1
)END) as Cess,

(CASE WHEN vi.Type = 'Debit' THEN
ifnull(SUM(vi.Amount),0)
ELSE(
ifnull(SUM(vi.Amount),0) * -1
)END) as Amt


From TBL_VC_Item_Details vi
LEFT JOIN TBL_VC vc on vc.Tra_ID = vi.Tra_ID
LEFT JOIN TBL_Stock_Item it on it.ID = vi.Item
LEFT JOIN TBL_Inventory_Unit U on U.ID = it.Unit
WHERE vc.Visible = 'Approval' and vc.Type = 'Head' and (vc.Voucher_Type = 'Sales' or vc.Voucher_Type = 'Credit Note' or vc.Voucher_Type = 'Debit Note') and (vc.Date BETWEEN '{CDate(Frm_date).ToString(Lite_date_Format)}' and '{CDate(to_date).AddDays(1).ToString(Lite_date_Format)}')
Group By it.HSN_Code,U.UQC,vi.GST_per", cn)
            Dim r As SQLiteDataReader = cmd.ExecuteReader


            While r.Read
                Dim to_gst As Decimal = Val(Val(r("IGST").ToString) + Val(r("CGST").ToString) + Val(r("SGST").ToString))
                Dim HSN As String = r("HSN_Code").ToString
                Dim UQC As String = r("UQC").ToString
                Dim Qty As String = r("Qty").ToString
                Dim To_Amt As String = Val(r("Amt").ToString) + to_gst
                Dim tx_rate As String = (r("GST_per").ToString)
                Dim taxable_amt As String = (r("Amt").ToString)
                Dim CGST As String = (r("CGST").ToString)
                Dim SGST As String = (r("SGST").ToString)
                Dim IGST As String = (r("IGST").ToString)
                Dim Cess As String = (r("Cess").ToString)

                If HSN.ToString <> Nothing Then
                    Grid1.Rows.Add(HSN, UQC,
                               N2_FORMATE(Qty),
                               N2_FORMATE(To_Amt),
                               nUmBeR_FORMATE(tx_rate) & " %",
                               N2_FORMATE(taxable_amt),
                               N2_FORMATE(IGST),
                               N2_FORMATE(CGST),
                               N2_FORMATE(SGST),
                               Cess,
                               N2_FORMATE(to_gst)
)
                End If



            End While


        End If

    End Function

    Private Sub Grid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid1.CellContentClick

    End Sub

    Private Sub Grid1_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim HSN As String = Grid1.CurrentRow.Cells(0).Value.ToString
            Dim UQC As String = Grid1.CurrentRow.Cells(1).Value.ToString
            Dim Rate As String = Grid1.CurrentRow.Cells(4).Value.ToString
            Cell("GSTR1 Voucher Register", VC_Type_, "HSN/SAC Summary", HSN, UQC, Rate)
        End If
    End Sub

    Private Sub HSN_Summary_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID

        Grid1.Focus()
    End Sub
End Class