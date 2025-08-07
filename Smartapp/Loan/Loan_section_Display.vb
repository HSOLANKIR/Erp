Imports System.Data.SqlClient
Imports System.Data.SQLite

Public Class Loan_section_Display
    Private VC_Type_ As String
    Private VC_ID_ As String
    Private Path_End As String

    Dim Frm_date As Date
    Dim to_date As Date
    Private Sub Loan_section_Display_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Path_End = BG_frm.BG_Path_TXT.Text

        VC_Type_ = Link_Valu(1)
        VC_ID_ = Link_Valu(2)


        Frm_Date_LB.Text = Date_Formate(Date_1)
        To_Date_LB.Text = Date_Formate(Date_2)

        BG_frm.HADE_TXT.Text = "Loan Sanctioned Display"
        BG_frm.TYP_TXT.Text = VC_Type_

        Button_Manage()
        Add_Hander_Remove_Handel(True)
    End Sub

    Private Sub Loan_section_Display_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.HADE_TXT.Text = "Loan Sanctioned Display"
        BG_frm.TYP_TXT.Text = VC_Type_

        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text
        Button_Clear()
        Button_Manage()
        Fill_Grid()
        Grid1.Focus()
    End Sub

    Private Sub Loan_section_Display_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub Loan_section_Display_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        Add_Hander_Remove_Handel(False)
        BG_frm.BG_Path_TXT.Text = Path_End
        Frm_foCus()
    End Sub

    Private Function Button_Manage()
        Button_Clear()
    End Function
    Private Function Add_Hander_Remove_Handel(Ans As Boolean)

    End Function
    Dim Date_Filter As String
    Dim dt As New DataTable
    Private Function Fill_Grid()
        dt.Clear()
        dt.Columns.Clear()
        Grid1.Columns.Clear()
        dt = New DataTable
        dt.Columns.Add("Loan ID")
        dt.Columns.Add("Sanction Date")
        dt.Columns.Add("Instalments Date")
        dt.Columns.Add("Employee Name")
        dt.Columns.Add("Guarantor")
        'dt.Columns.Add("Head of Department")
        dt.Columns.Add("Loan Amount")
        'dt.Columns.Add("Loan Type")
        'dt.Columns.Add("Installments")
        'dt.Columns.Add("Installment Type")
        'dt.Columns.Add("Interest Rate")

        Date_Filter = "Date BETWEEN '" & CDate(Frm_date).ToString("MM-dd-yyyy") & "' and '" & CDate(to_date).ToString("MM-dd-yyyy") & "'"


        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand("Select *,(Select [Name] From TBL_Payroll_Employee where ID = ls.Employee_ID) as Employee_Name,(Select [Name] From TBL_Payroll_Employee where ID = ls.Guarantor_ID) as Guarantor_Name From TBL_Loan_sanction ls where " & Company_Visible_Filter, cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            Dim dr As DataRow
            While r.Read
                dr = dt.NewRow
                dr("Loan ID") = r("ID")
                dr("Sanction Date") = CDate(r("Sanction_Date")).ToString("dd-MM-yyyy")
                dr("Instalments Date") = CDate(r("Instalments_Date")).ToString("dd-MM-yyyy")
                dr("Employee Name") = (r("Employee_Name"))
                dr("Guarantor") = (r("Guarantor_Name"))
                'dr("Head of Department") = (r("Head_of_Department"))
                dr("Loan Amount") = N2_FORMATE(r("Loan_Amount"))
                'dr("Loan Type") = (r("Loan_Type"))
                'dr("Installments") = N2_FORMATE(r("Loan_Type"))
                'dr("Installment Type") = (r("Particuls_Type"))
                'dr("Interest Rate") = (r("Interest_Rate"))
                dt.Rows.Add(dr)
            End While
        End If

        Dim dv As New DataView(dt)
        Dim Dt_set As New DataTable

        dv.Sort = "Loan ID"
        Dt_set = dv.ToTable

        BindingSource1.DataSource = dv
        Grid1.DataSource = BindingSource1


        Grid1.Columns(0).Width = 80
        Grid1.Columns(1).Width = 100
        Grid1.Columns(2).Width = 100
        Grid1.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Grid1.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        Grid1.Columns(5).Width = 100
        Grid1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Function
    Private Sub Frm_Date_LB_TextChanged(sender As Object, e As EventArgs) Handles Frm_Date_LB.TextChanged
        Frm_date = Frm_Date_LB.Text
    End Sub
    Private Sub To_Date_LB_TextChanged(sender As Object, e As EventArgs) Handles To_Date_LB.TextChanged
        to_date = To_Date_LB.Text
    End Sub

    Private Sub Grid1_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles Grid1.RowsAdded
        Grid1.Rows(Grid1.Rows.Count - 1).Height = 18
    End Sub

    Private Sub Grid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid1.CellContentClick

    End Sub

    Private Sub Grid1_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid1.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            Cell("Loan Sanction", Grid1.CurrentRow.Cells(0).Value, "Alter", "")
        End If
    End Sub
End Class