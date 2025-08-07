Imports System.Data.SQLite
Imports Microsoft.Reporting.WinForms

Public Class Payshlip_display_frm
    Dim From_ID As String
    Private VC_Type_ As String
    Private VC_ID_ As String
    Private Path_End As String
    Dim YN_Details As Boolean
    Dim Acc_Under As String
    Dim Frm_date As Date
    Dim to_date As Date

    Public Branch As String = "Primary"
    Public Voucher_Type As String = "All Vouchers"
    Public Narration_ As Boolean = False
    Public Delete_Entry = False


    Dim ds_print As New Print_dt
    Dim dt_print As New DataTable

    Private Sub Payshlip_display_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text

        VC_ID_ = Link_Valu(0)

        Frm_Date_LB.Text = Date_Formate(Date_1)
        To_Date_LB.Text = Date_Formate(Date_2)

        BG_frm.HADE_TXT.Text = "Payslip"
        BG_frm.TYP_TXT.Text = VC_Type_

        Button_Manage()
        Add_Hander_Remove_Handel(True)
        Branch = Branch_Name

        Update_Report = True
    End Sub
    Private Function Button_Manage()
        Button_Clear()
        BG_frm.B_1.Text = "|&R : Refresh"
        BG_frm.B_2.Text = "|&P : Print"

        BG_frm.R_1.Text = "|F1 : Detailed"
        BG_frm.R_2.Text = "|F2 : Period"
        If Branch_Visible() = True Then
            BG_frm.R_5.Text = "F4 : Branch"
        End If
        'BG_frm.R_22.Text = "F12 : Configuration"
    End Function
    Private Sub Payshlip_display_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.HADE_TXT.Text = "Payslip"
        BG_frm.TYP_TXT.Text = VC_Type_

        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text
        Button_Clear()
        Button_Manage()
        cfg_fill()
        If Update_Report = True Then
            Fill_Grid()
        End If
        Grid1.Focus()
    End Sub
    Private Function Add_Hander_Remove_Handel(Ans As Boolean)
        If Ans = True Then
            AddHandler BG_frm.KeyDown, AddressOf Me.BG_Keydown
            AddHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            AddHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click

            AddHandler BG_frm.R_1.Click, AddressOf Me.R_1_Click
            AddHandler BG_frm.R_2.Click, AddressOf Me.R_2_Click

            If Branch_Visible() = True Then
                AddHandler BG_frm.R_5.Click, AddressOf Me.R_9_Click
            End If
        Else
            RemoveHandler BG_frm.KeyDown, AddressOf Me.BG_Keydown
            RemoveHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            RemoveHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click

            RemoveHandler BG_frm.R_1.Click, AddressOf Me.R_1_Click
            RemoveHandler BG_frm.R_2.Click, AddressOf Me.R_2_Click
        End If
    End Function
    Private Sub BG_Keydown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.F2 AndAlso e.Modifiers = Keys.Alt Then
            BG_frm.R_2.PerformClick()
        ElseIf e.KeyCode = Keys.F2 Then
            BG_frm.R_2.PerformClick()
        End If

        If e.KeyCode = Keys.F4 AndAlso e.Modifiers = Keys.Alt Then

        ElseIf e.KeyCode = Keys.F4 Then
            BG_frm.R_5.PerformClick()
        End If
    End Sub
    Private Sub B_1_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub B_2_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Print_data_fill()
            Printing_Direct_frm.Printing_(cfg_print_path, rdlc_report_name, "", rdlc_report_data)
        End If
    End Sub
    Dim cfg_print_path As String
    Dim rdlc_report_name As String
    Dim rdlc_report_data() As ReportDataSource
    Private Function Print_data_fill()
        rdlc_report_name = $"PaySlip {Label1.Text} ({Frm_date.ToString("dd-MMM-yyyy")} to {to_date.ToString("dd-MMM-yyyy")})"
        rdlc_report_name = path_validation(rdlc_report_name, "-")

        rdlc_report_data = {New ReportDataSource("DataSet1", dt_print), New ReportDataSource("dt_cmp", Print_DT_Company)}

    End Function
    Private Function cfg_fill()

        If cfg_print_path = Nothing Then
            cfg_print_path = Application.StartupPath & "\Print_\Report\Payroll\Payslip\Payslip"
        End If
    End Function

    Private Sub R_1_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub R_2_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Set_Date(True, Me)
        End If
    End Sub
    Private Sub R_9_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then

        End If
    End Sub
    Private Sub Payshlip_display_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
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
    Private Sub Payshlip_display_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
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
    Private Function Fill_Grid()
        Grid1.Rows.Clear()
        Grid2.Rows.Clear()
        Grid3.Rows.Clear()


        dt_print.Rows.Clear()
        dt_print = ds_print.Tables("TBL_Payslip")

        Dim dr_print As DataRow


        Dim Dr_Total As Decimal = 0
        Dim Cr_Total As Decimal = 0

        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            Dim r As SQLiteDataReader

            cmd = New SQLiteCommand($"Select em.Name,em.ID,em.Mobile1,em.Mobile2,em.Gender,em.Father_Name,em.Father_Mobile,
(Select g.Name From TBL_Stock_Group g where g.ID = em.Under) as Group_Name
From TBL_Payroll_Employee em where em.ID = '{VC_ID_}'", cn)
            r = cmd.ExecuteReader
            While r.Read
                Label1.Text = r("Name").ToString
                Em_ID_LB.Text = r("ID").ToString
                EM_Group_LB.Text = r("Group_Name").ToString
                EM_Phone_LB.Text = $"{r("Mobile1").ToString}, {r("Mobile2").ToString}"
                EM_Gender_LB.Text = r("Gender").ToString
                Father_Name_LB.Text = r("Father_Name").ToString
                Father_Phone_LB.Text = r("Father_Mobile").ToString
            End While
            r.Close()


            cmd = New SQLiteCommand($"SELECT att.ID,att.Name,
(Select SUM(vc.Value) From TBL_Attendance_VC vc WHERE vc.Employee = '{VC_ID_}' and vc.Attendance_ID = att.ID and Visible = 'Approval' and (vc.Date BETWEEN '{CDate(Frm_date).ToString(Lite_date_Format)}' and '{CDate(to_date).AddDays(1).ToString(Lite_date_Format)}')) as Vlu,
(Select u.Symbol From TBL_Inventory_Unit u where u.ID = att.Unit) as Unit

From TBL_Payroll_Att_Production_Type att
WHERE att.Visible = 'Approval'", cn)
            r = cmd.ExecuteReader
            'My.Computer.Clipboard.SetText(cmd.CommandText)
            While r.Read
                Dim vl As String
                If Val(r("Vlu").ToString) <> 0 Then
                    If r("Unit").ToString = "" Then
                        vl = r("Vlu").ToString & " Day"
                    Else
                        vl = r("Vlu").ToString & " " & r("Unit").ToString
                    End If


                    Grid1.Rows.Add(r("Name"), vl)

                    dr_print = dt_print.NewRow
                    dr_print("Head") = r("Name")
                    dr_print("Unit") = vl
                    dt_print.Rows.Add(dr_print)
                End If
            End While
            r.Close()

            cmd = New SQLiteCommand($"Select phd.ID,phd.Name,phd.Payhead_Type,
(Select ifnull(SUM(vc.Dr),0)-ifnull(SUM(vc.Cr),0) From TBL_VC_Payroll vc WHERE vc.Payhead = phd.ID and vc.Employee = '{VC_ID_}' and (vc.Date BETWEEN '{CDate(Frm_date).ToString(Lite_date_Format)}' and '{CDate(to_date).AddDays(1).ToString(Lite_date_Format)}')) as Vlu
 From TBL_PayHead phd
 where phd.Visible = 'Approval'", cn)

            r = cmd.ExecuteReader
            'My.Computer.Clipboard.SetText(cmd.CommandText)

            While r.Read
                Dim vlu As Decimal = Val(r("Vlu").ToString)

                If vlu <> 0 Then
                    If r("Payhead_Type").ToString = "Earnings for Employees" Then
                        Grid2.Rows.Add(r("Name"), N2_FORMATE(vlu))
                        Dr_Total += Val(vlu)

                        dr_print = dt_print.NewRow
                        dr_print("Head") = r("Name")
                        dr_print("Earning") = N2_FORMATE(vlu)
                        dt_print.Rows.Add(dr_print)

                    ElseIf r("Payhead_Type").ToString = "Deductions From Employees" Then
                        Grid3.Rows.Add(r("Name"), N2_FORMATE(vlu * -1))
                        Cr_Total += (Val(vlu) * -1)

                        dr_print = dt_print.NewRow
                        dr_print("Head") = r("Name")
                        dr_print("Deductions") = N2_FORMATE(vlu * -1)
                        dt_print.Rows.Add(dr_print)
                    End If
                End If
            End While
            r.Close()

            Label18.Text = N2_FORMATE(Dr_Total)
            Label20.Text = N2_FORMATE(Cr_Total)
        End If
    End Function
    Private Sub Grid1_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles Grid1.RowsAdded, Grid2.RowsAdded, Grid3.RowsAdded
        sender.Rows(sender.Rows.Count - 1).Height = 18
    End Sub

    Private Sub Label18_Click(sender As Object, e As EventArgs) Handles Label18.Click

    End Sub
    Private Function Total_cal()
        Label24.Text = nUmBeR_FORMATE(Label18.Text) - nUmBeR_FORMATE(Label20.Text)
        Label24.Text = N2_FORMATE(Label24.Text)

    End Function

    Private Sub Label18_TextChanged(sender As Object, e As EventArgs) Handles Label18.TextChanged, Label20.TextChanged
        Total_cal()
    End Sub

    Private Sub Payshlip_display_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID

        Grid1.Focus()
    End Sub
End Class