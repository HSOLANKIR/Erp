Imports System.Data.SqlClient
Imports System.Data.SQLite
Imports Microsoft.Reporting.WinForms

Public Class Loan_complit_installment_display
    Private VC_Type_ As String
    Public VC_ID_ As String
    Private Loan_ID_ As String
    Private Path_End As String

    Dim Frm_date As Date
    Dim to_date As Date

    Dim ds As New Print_dt
    Dim dt_print As New DataTable
    Private Sub Loan_complit_installment_display_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Path_End = BG_frm.BG_Path_TXT.Text

        VC_Type_ = Link_Valu(1)
        VC_ID_ = Link_Valu(2)

        Loan_()

        BG_frm.HADE_TXT.Text = "Loan Installation Report"
        BG_frm.TYP_TXT.Text = VC_Type_

        Button_Manage()
        Add_Hander_Remove_Handel(True)
    End Sub

    Private Sub Loan_complit_installment_display_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.HADE_TXT.Text = "Loan Installation Report"
        BG_frm.TYP_TXT.Text = VC_Type_

        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text
        Button_Clear()
        Button_Manage()

        If Grid1.Rows.Count = 0 Then
            ComboBox1.Focus()
        Else
            Grid1.Focus()
        End If
    End Sub

    Private Sub Loan_complit_installment_display_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub Loan_complit_installment_display_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        Add_Hander_Remove_Handel(False)
        BG_frm.BG_Path_TXT.Text = Path_End
        Frm_foCus()
    End Sub
    Private Function Button_Manage()
        Button_Clear()
        BG_frm.B_1.Text = "&E : Exit"
        BG_frm.B_2.Text = "&P : Print"
    End Function
    Private Function Add_Hander_Remove_Handel(Ans As Boolean)
        If Ans = True Then
            AddHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            AddHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
        Else
            AddHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            AddHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
        End If
    End Function
    Private Sub B_1_Click(sender As Object, e As EventArgs)
        If BG_frm.HADE_TXT.Text = "Loan Installation Report" Then
            Me.Dispose()
        End If
    End Sub
    Private Sub B_2_Click(sender As Object, e As EventArgs)
        If BG_frm.HADE_TXT.Text = "Loan Installation Report" Then
            Print_()
        End If
    End Sub
    Private Function Print_()
        Print_Priew_frm.ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("cmp_dt", Print_DT_Company))
        Print_Priew_frm.ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dt_", dt_print))
        Dim paramtr(0) As ReportParameter
        Print_Priew_frm.Print_Privew(Application.StartupPath & "\Print_\Report\Loan_Statement", "", paramtr)
    End Function
    Dim Date_Filter As String
    Dim dt As New DataTable
    Private Function Fill_Grid()
        Dim no As Integer = 0

        dt.Clear()
        dt.Columns.Clear()
        Grid1.Columns.Clear()
        dt = New DataTable
        dt.Columns.Add("From").DataType = GetType(Date)
        dt.Columns.Add("To").DataType = GetType(Date)
        dt.Columns.Add("Distance")
        dt.Columns.Add("Account")
        dt.Columns.Add("Loan Amount")
        dt.Columns.Add("Interest")
        dt.Columns.Add("Installments")
        dt.Columns.Add("Type")
        dt.Columns.Add("Closing Loan")
        dt.Columns.Add("Tra_ID")

        dt_print.Rows.Clear()

        Date_Filter = "Date BETWEEN '" & CDate(Frm_date).ToString("MM-dd-yyyy") & "' and '" & CDate(to_date).ToString("MM-dd-yyyy") & "'"

        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand("Select *,(Select TOP 1 (Select ld.[Name] From TBL_Ledger ld where ld.Id = vc.Account) From TBL_VC vc where vc.Tra_ID = ls.Tra_ID) as Account_Name From TBL_Loan_Installments ls 

Where ls.Loan_ID = '" & Loan_ID_ & "' and ls.Employee_ID = '" & VC_ID_ & "' Order By ls.[To]", cn)

            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            Dim dr As DataRow

            Dim dr_P As DataRow
            dt_print = ds.Tables("TBL_Loan_Sanction")
            dr_P = dt_print.NewRow

            While r.Read
                Dim Frm As Date = CDate(r("From"))
                Dim To_ As Date = CDate(r("To"))
                Dim Dist As String = DateDiff(DateInterval.Day, CDate(r("From")), CDate(r("To"))) & "Days"
                Dim Account_Name As String = (r("Account_Name").ToString)
                Dim Loan_Amount As String = N2_FORMATE(r("Loan_Amount").ToString)
                Dim Intrest As String = N2_FORMATE(r("Interest").ToString)
                Dim Installment As String = N2_FORMATE(r("Installment").ToString)
                Dim Loan_Type As String = (r("Loan_Type").ToString)
                Dim Closing As String = N2_FORMATE(r("Closing").ToString)
                Dim Tra_ID As String = (r("Tra_ID").ToString)

                dr = dt.NewRow
                dr("From") = Frm
                dr("To") = To_
                dr("Distance") = Dist
                dr("Account") = Account_Name
                dr("Loan Amount") = Loan_Amount
                dr("Interest") = Intrest
                dr("Installments") = Installment
                dr("Type") = Loan_Type
                dr("Closing Loan") = Closing

                dr("Tra_ID") = (r("Tra_ID"))
                dt.Rows.Add(dr)

                dr_P = dt_print.NewRow
                dr_P("No") = no
                dr_P("From") = Frm.ToString("dd-MM-yyyy")
                dr_P("To") = To_.ToString("dd-MM-yyyy")
                dr_P("Destance") = Dist
                dr_P("Account") = Account_Name
                dr_P("Loan_Amount") = Loan_Amount
                dr_P("Interest") = Intrest
                dr_P("Instalments") = Installment
                dr_P("Closing") = Closing

                dt_print.Rows.Add(dr_P)

                no += 1
            End While
        End If

        Dim dv As New DataView(dt)
        Dim Dt_set As New DataTable

        dv.Sort = "To"
        Dt_set = dv.ToTable

        BindingSource1.DataSource = dv
        Grid1.DataSource = BindingSource1

        Grid1.Columns(0).Width = 100
        Grid1.Columns(1).Width = 100

        Grid1.Columns(2).Width = 100

        Grid1.Columns(3).Width = 100
        Grid1.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        Grid1.Columns(4).Width = 100
        Grid1.Columns(4).DefaultCellStyle.Font = New Font(Dft_Font, 11, FontStyle.Bold)
        Grid1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Grid1.Columns(5).Width = 100
        Grid1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Grid1.Columns(5).DefaultCellStyle.ForeColor = Color.Red

        Grid1.Columns(6).Width = 100
        Grid1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Grid1.Columns(6).DefaultCellStyle.ForeColor = Color.Green

        Grid1.Columns(7).Width = 150

        Grid1.Columns(8).Width = 100
        Grid1.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Grid1.Columns(8).DefaultCellStyle.Font = New Font(Dft_Font, 11, FontStyle.Bold)
        Grid1.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


        Grid1.Columns(9).Visible = False
    End Function

    Private Sub Grid1_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles Grid1.RowsAdded
        Grid1.Rows(Grid1.Rows.Count - 1).Height = 18
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Loan_ID_ = ComboBox1.Text

        Fill_Grid()
        Grid1.Focus()
    End Sub
    Private Function Loan_()
        ComboBox1.Items.Clear()

        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand("Select ls.Id as ID From TBL_Loan_sanction ls where ls.Employee_ID = '" & VC_ID_ & "'", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                ComboBox1.Items.Add(r("ID"))
            End While
        End If
        Try
            ComboBox1.SelectedIndex = 0
        Catch ex As Exception

        End Try
    End Function
End Class