Imports System.Data.SqlClient
Imports System.Data.SQLite
Imports Microsoft.Reporting.WinForms
Public Class Expiry_Date_Stock_Report
    Dim From_ID As String
    Private VC_Type_ As String
    Private VC_ID_ As String
    Private Path_End As String
    Dim YN_Details As Boolean
    Dim Acc_Under As String
    Dim Frm_date As Date
    Dim to_date As Date

    Public Branch As String = "Primary"
    Public Narration_ As Boolean = False
    Public Delete_Entry = False


    Dim ds_print As New Print_dt
    Dim dt_print As New DataTable
    Private Sub Expiry_Date_Stock_Report_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text

        VC_ID_ = Link_Valu(0)

        To_Date_LB.Text = Date_Formate(Date_3)

        BG_frm.HADE_TXT.Text = "Stock Items (Expiry Date Report)"
        BG_frm.TYP_TXT.Text = VC_Type_

        Button_Manage()
        Add_Hander_Remove_Handel(True)
        Branch = Branch_Name

        Label17.Text = Branch
        Update_Report = True
    End Sub
    Private Function Button_Manage()
        BG_frm.B_1.Text = "|&P : Print"
    End Function
    Private Function Add_Hander_Remove_Handel(Ans As Boolean)
        If Ans = True Then
            AddHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
        Else
            RemoveHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
        End If
    End Function
    Private Sub B_1_Click(sender As Object, e As EventArgs)
        'If BG_frm.HADE_TXT.Text = "Stock Items (Expiry Date Report)" And BG_Panel.Visible = True Then
        '    Dim paramtr(2) As ReportParameter
        '    paramtr(0) = New ReportParameter("Item_Name_prmt", Acc_LB.Text)
        '    paramtr(1) = New ReportParameter("Date_prmt", To_Date_LB.Text)
        '    paramtr(2) = New ReportParameter("Total_prmt", Label2.Text)

        '    Print_Priew_frm.ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet2", dt_print))
        '    Print_Priew_frm.ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", Print_DT_Company))
        '    Print_Priew_frm.Print_Privew(Application.StartupPath & "\Print_\Report\Item_Stock_Expiry", "", paramtr)
        'End If
    End Sub
    Private Sub Expiry_Date_Stock_Report_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.HADE_TXT.Text = "Stock Items (Expiry Date Report)"
        BG_frm.TYP_TXT.Text = VC_Type_

        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text
        Button_Clear()
        Button_Manage()
        'Config_Fill()
        If Update_Report = True Then
            Fill_Grid()
        End If
        Grid1.Focus()
    End Sub

    Private Sub Expiry_Date_Stock_Report_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub Expiry_Date_Stock_Report_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        Add_Hander_Remove_Handel(False)
        BG_frm.BG_Path_TXT.Text = Path_End
        Frm_foCus()
    End Sub
    Private Function Fill_Grid()
        dt_print.Rows.Clear()
        dt_print = ds_print.Tables("TBL_Stock_Item_Expiry_Date")


        Dim Total As Decimal = 0

        Grid1.Rows.Clear()
        Acc_LB.Text = Find_DT_Value(Database_File.cre, "TBL_Stock_Item", "Name", "Id = '" & VC_ID_ & "'")
        Dim Uni As String = Find_DT_Value(Database_File.cre, "TBL_Stock_Item", "Unit", "Id = '" & VC_ID_ & "'")
        Dim Unit As String = " " & Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "Symbol", "Id = '" & Uni & "'")

        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand("select vc.Batch_No,vc.[Expiry_Date],isnull((Select SUM(Quantity) From TBL_VC where (Voucher_Type = 'Purchase' or Voucher_Type = 'Sales Return') and Particuls = '" & VC_ID_ & "' AND CR_DR = 'Under' AND Visible = 'Approval' and Batch_No = vc.Batch_No and [Date] <= '" & CDate(to_date).ToString("MM-dd-yyyy") & "'),0) -
isnull((Select SUM(Quantity) From TBL_VC where (Voucher_Type = 'Sales' or Voucher_Type = 'Purchase Return') and Particuls = '" & VC_ID_ & "' AND CR_DR = 'Under' AND Visible = 'Approval' and Batch_No = vc.Batch_No and [Date] <= '" & CDate(to_date).ToString("MM-dd-yyyy") & "'),0) as Vlu

From TBL_VC vc
where (vc.Voucher_Type = 'Purchase' or vc.Voucher_Type = 'Sales Return') and vc.CR_DR = 'Under' and (vc.Particuls = '" & VC_ID_ & "')
Group By vc.Batch_No,vc.[Expiry_Date]", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                If Val(r("vlu")) <> 0 Then
                    Dim dt As String = Date_Formate(r("Expiry_Date").ToString)
                    Total += Val(r("vlu"))
                    Grid1.Rows.Add(r("Batch_No").ToString, dt, N2_FORMATE(r("Vlu")) & Unit)
                    dt_print.Rows.Add(r("Batch_No").ToString, dt, N2_FORMATE(r("Vlu")) & Unit)
                End If
            End While
        End If

        Label2.Text = N2_FORMATE(Total) & Unit
    End Function
    Private Sub To_Date_LB_TextChanged(sender As Object, e As EventArgs) Handles To_Date_LB.TextChanged
        to_date = To_Date_LB.Text
    End Sub
    Private Sub Grid1_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles Grid1.RowsAdded
        Grid1.Rows(Grid1.Rows.Count - 1).Height = 18
    End Sub

    Private Sub Expiry_Date_Stock_Report_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
    End Sub
End Class