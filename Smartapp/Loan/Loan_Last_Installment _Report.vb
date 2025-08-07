Imports System.Data.SqlClient
Imports System.Data.SQLite

Public Class Loan_Last_Installment__Report
    Private VC_Type_ As String
    Public VC_ID_ As String
    Private Loan_ID_ As String
    Private Path_End As String

    Dim Frm_date As Date
    Dim to_date As Date

    Dim ds As New Print_dt
    Dim dt_print As New DataTable
    Private Sub Loan_Last_Installment__Report_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Path_End = BG_frm.BG_Path_TXT.Text

        VC_Type_ = Link_Valu(1)
        VC_ID_ = Link_Valu(2)

        To_Date_LB.Text = Date_Formate(Date_3)


        'Loan_()

        BG_frm.HADE_TXT.Text = "List of Outstanding Loan"
        BG_frm.TYP_TXT.Text = VC_Type_

        Button_Manage()
        Add_Hander_Remove_Handel(True)
    End Sub

    Private Sub Loan_Last_Installment__Report_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.HADE_TXT.Text = "List of Outstanding Loan"
        BG_frm.TYP_TXT.Text = VC_Type_

        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text
        Button_Clear()
        Button_Manage()

        Grid1.Focus()
    End Sub

    Private Sub Loan_Last_Installment__Report_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
        If e.KeyCode = Keys.F2 Then
            If BG_frm.HADE_TXT.Text = "List of Outstanding Loan" Then
                BG_frm.R_2.PerformClick()
            End If
        End If
    End Sub

    Private Sub Loan_Last_Installment__Report_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        Add_Hander_Remove_Handel(False)
        BG_frm.BG_Path_TXT.Text = Path_End
        Frm_foCus()
    End Sub
    Private Function Button_Manage()
        Button_Clear()
        BG_frm.B_1.Text = "&E : Exit"
        BG_frm.B_2.Text = "&P : Print"

        BG_frm.R_2.Text = "|F2 : Date"
    End Function
    Private Function Add_Hander_Remove_Handel(Ans As Boolean)
        If Ans = True Then
            AddHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            AddHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
            AddHandler BG_frm.R_2.Click, AddressOf Me.R_2_Click
        Else
            RemoveHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            RemoveHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
            RemoveHandler BG_frm.R_2.Click, AddressOf Me.R_2_Click
        End If
    End Function
    Private Sub B_1_Click(sender As Object, e As EventArgs)
        If BG_frm.HADE_TXT.Text = "List of Outstanding Loan" Then
            Me.Dispose()
        End If
    End Sub
    Private Sub B_2_Click(sender As Object, e As EventArgs)
        If BG_frm.HADE_TXT.Text = "List of Outstanding Loan" Then
            'Print_()
        End If
    End Sub
    Private Sub R_2_Click(sender As Object, e As EventArgs)
        If BG_frm.HADE_TXT.Text = "List of Outstanding Loan" And BG_Panel.Visible = True Then
            If Date_Set_Curr(False) = DialogResult.Yes Then
                To_Date_LB.Text = Date_3
                Fill_Grid()
            End If
        End If
    End Sub
    Private Sub Frm_Date_LB_TextChanged(sender As Object, e As EventArgs) Handles To_Date_LB.TextChanged
        Frm_date = To_Date_LB.Text
    End Sub
    Dim Date_Filter As String
    Dim dt As New DataTable
    Private Function Fill_Grid()
        dt.Clear()
        dt.Columns.Clear()
        Grid1.Columns.Clear()
        dt = New DataTable
        dt.Columns.Add("Employee")
        dt.Columns.Add("Loan Amount")
        dt.Columns.Add("Total Installments")
        dt.Columns.Add("Total Interest")
        dt.Columns.Add("Closing Loan")

        Date_Filter = "Date BETWEEN '" & CDate(Frm_date).ToString("MM-dd-yyyy") & "' and '" & CDate(to_date).ToString("MM-dd-yyyy") & "'"

        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand("Select *,
DATEDIFF(DAY,ls.[To],'" & CDate(To_Date_LB.Text).ToString("MM-dd-yyyy") & "') as Diff,
(Select SUM(lss.Installment) From TBL_Loan_Installments lss where Lss.[To] <= '" & CDate(To_Date_LB.Text).ToString("MM-dd-yyyy") & "' and lss.Loan_ID = ls.Loan_ID) as Total_Installment,
(Select SUM(lss.Interest) From TBL_Loan_Installments lss where Lss.[To] <= '" & CDate(To_Date_LB.Text).ToString("MM-dd-yyyy") & "' and lss.Loan_ID = ls.Loan_ID) as Total_Intrest,
(Select ln.Loan_Amount From TBL_Loan_sanction ln where ln.ID = ls.Loan_ID) as Loan_Amt,
(Select em.[Name] From TBL_Payroll_Employee em where em.Id = ls.Employee_ID) as Employee_Name
From TBL_Loan_Installments ls
where Ls.[To] <= '" & CDate(To_Date_LB.Text).ToString("MM-dd-yyyy") & "' and ls.[To] = (Select TOP 1 lss.[To] From TBL_Loan_Installments lss where lss.Loan_ID = ls.Loan_ID and Lss.[To] <= '" & CDate(To_Date_LB.Text).ToString("MM-dd-yyyy") & "' Order By lss.[To] DESC)

Order By ls.[To] DESC
", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            Dim dr As DataRow
            While r.Read
                Dim Loan_Amount As Decimal = Val(r("Closing"))
                Dim Intrast As Decimal = Val(r("Interest"))
                Dim Diff As Integer = Val(r("Diff"))
                Dim Emplyee_ As String = r("Employee_Name")
                Dim Total_Installment As Decimal = Val(r("Total_Installment"))
                Dim Total_Intrest As Decimal = Val(r("Total_Intrest"))

                Dim Loan_Diff_Cal As Decimal = Loan_Amount + Closing_to_intest_cal(Intrast, Loan_Amount, Val(Diff))

                dr = dt.NewRow
                dr("Employee") = Emplyee_
                dr("Loan Amount") = N2_FORMATE(r("Loan_Amt"))
                dr("Total Installments") = N2_FORMATE(Total_Installment)
                dr("Total Interest") = N2_FORMATE(Total_Intrest)
                dr("Closing Loan") = N2_FORMATE(Loan_Diff_Cal)
                dt.Rows.Add(dr)
            End While
            Grid1.DataSource = dt
        End If
    End Function
End Class