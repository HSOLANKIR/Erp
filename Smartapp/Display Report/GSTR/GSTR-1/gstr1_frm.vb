Imports System.ComponentModel
Imports System.Data.SQLite
Imports Microsoft.Office.Interop
Imports Microsoft.Reporting.WinForms

Public Class gstr1_frm
    Dim From_ID As String
    Private VC_Type_ As String
    Private VC_ID_ As String
    Private Path_End As String
    Dim YN_Details As Boolean
    Dim Acc_Under As String
    Dim Frm_date As Date
    Dim to_date As Date

    Public Branch_ID As String = ""
    Public Branch As String = "Primary"
    Public Voucher_Type As String = "All Vouchers"
    Public Narration_ As Boolean = False

    Public Delete_Entry = False

    Dim Focus_Grid As DataGridView
    Dim Focus_Cell As Integer

    Private Sub gstr1_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text

        VC_Type_ = Link_Valu(1)
        VC_ID_ = Link_Valu(2)

        Frm_Date_LB.Text = Date_Formate(Date_1)
        To_Date_LB.Text = Date_Formate(Date_2)

        BG_frm.HADE_TXT.Text = "GSTR1"
        BG_frm.TYP_TXT.Text = VC_Type_

        Button_Manage()
        Add_Hander_Remove_Handel(True)

        Branch_ID = Set_Branch()
        Branch = Find_Branch_Name(Branch_ID)

        Focus_Grid = Grid1
        Focus_Cell = 0

        Grid2.Focus()

    End Sub
    Private Function Button_Manage()
        Button_Clear()
        BG_frm.B_1.Text = "Enter : Alter"
        BG_frm.B_2.Text = "|&R : Refresh"
        BG_frm.B_3.Text = "|&P : Print"

        BG_frm.R_1.Text = "|F1 : Detailed"
        BG_frm.R_2.Text = "F2 : Date"
        BG_frm.R_4.Text = "&X : Excel Exp."
        BG_frm.R_3.Text = "|F2 : Period"
        If Branch_Visible() = True Then
            BG_frm.R_5.Text = "F4 : Branch"
        End If
        BG_frm.R_6.Text = "F5 : HSN Summary"

        BG_frm.R_22.Text = "F12 : Configuration"
    End Function
    Private Function Add_Hander_Remove_Handel(Ans As Boolean)
        If Ans = True Then
            AddHandler BG_frm.KeyDown, AddressOf Me.BG_Keydown
            AddHandler BG_frm.B_3.Click, AddressOf Me.B_3_Click

            AddHandler BG_frm.R_2.Click, AddressOf Me.R_3_Click
            AddHandler BG_frm.R_3.Click, AddressOf Me.R_4_Click
            AddHandler BG_frm.R_6.Click, AddressOf Me.R_6_Click
            AddHandler BG_frm.R_4.Click, AddressOf Me.R_5_Click
            If Branch_Visible() = True Then
                AddHandler BG_frm.R_5.Click, AddressOf Me.R_9_Click
            End If
        Else
            RemoveHandler BG_frm.B_3.Click, AddressOf Me.B_3_Click
            RemoveHandler BG_frm.KeyDown, AddressOf Me.BG_Keydown
            RemoveHandler BG_frm.R_2.Click, AddressOf Me.R_3_Click
            RemoveHandler BG_frm.R_3.Click, AddressOf Me.R_4_Click
            RemoveHandler BG_frm.R_6.Click, AddressOf Me.R_6_Click
            RemoveHandler BG_frm.R_4.Click, AddressOf Me.R_5_Click
            If Branch_Visible() = True Then
                RemoveHandler BG_frm.R_5.Click, AddressOf Me.R_9_Click
            End If
        End If
    End Function
    Private Sub BG_Keydown(sender As Object, e As KeyEventArgs)
        If BG_frm.From_ID = From_ID Then
            If e.KeyCode = Keys.F2 AndAlso e.Modifiers = Keys.Alt Then
                BG_frm.R_3.PerformClick()
            ElseIf e.KeyCode = Keys.F2 Then
                BG_frm.R_2.PerformClick()
            End If

            If e.KeyCode = Keys.F4 AndAlso e.Modifiers = Keys.Alt Then

            ElseIf e.KeyCode = Keys.F4 Then
                BG_frm.R_5.PerformClick()
            End If

            If e.KeyCode = Keys.F5 AndAlso e.Modifiers = Keys.Alt Then

            ElseIf e.KeyCode = Keys.F5 Then
                BG_frm.R_6.PerformClick()
            End If
        End If
    End Sub
    Private Sub R_9_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then

        End If
    End Sub
    Private Sub B_3_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Print_data_fill()
            Printing_Direct_frm.Printing_(cfg_print_path, rdlc_report_name, "", rdlc_report_data)
        End If
    End Sub
    Private Sub R_3_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Set_Date(False, Me)
        End If
    End Sub
    Private Sub R_4_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Set_Date(True, Me)
        End If
    End Sub
    Dim Export_Location As String
    Private Sub R_5_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Dim count_ As Integer = 1
            Dim cn As New SQLiteConnection
            If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                cmd = New SQLiteCommand($"Select SUM(C) as C From (
Select count(*) as C From TBL_VC_item_Details vi
LEFT JOIN TBL_VC vc on vc.Tra_ID = vi.Tra_ID
LEFT JOIN TBL_VC_Other vo on vo.Tra_ID = vi.Tra_ID 
where vc.Type = 'Head' and vc.Visible = 'Approval'  and vc.Voucher_Type = 'Sales' and (vc.Date BETWEEN '{CDate(Frm_date).ToString(Lite_date_Format)}' and '{CDate(to_date).AddDays(1).ToString(Lite_date_Format)}')
Group By vc.Voucher_No, vi.GST_per)", cn)
                Dim r As SQLiteDataReader
                r = cmd.ExecuteReader
                While r.Read
                    count_ = Val(r("C").ToString)
                End While


                Dim SaveFileDialog1 As New SaveFileDialog
                With SaveFileDialog1
                    .FileName = $"GSTR1 {Frm_date.ToString("dd-MMM-yyyy")} to {to_date.ToString("dd-MMM-yyyy")}"
                    .Title = "Export Excel"
                    If .ShowDialog = 1 Then
                        Export_Location = .FileName
                        Export_Data_Frind.RunWorkerAsync()
                    Else

                    End If
                End With

            End If
        End If
    End Sub
    Private Sub R_6_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Cell("HSN/SAC Summary", "")
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
    Dim cfg_print_path As String
    Dim rdlc_report_name As String
    Dim rdlc_report_data() As ReportDataSource

    Dim ds_print As New Print_dt
    Dim dt_print As New DataTable

    Private Function Print_data_fill()
        Pribat_data_set()
        cfg_print_path = Application.StartupPath & "\Print_\Report\GSTR1\GSTR1"

        rdlc_report_name = $"GSTR1 ({Frm_date.ToString("dd-MMM-yyyy")} to {to_date.ToString("dd-MMM-yyyy")})"
        rdlc_report_name = path_validation(rdlc_report_name, "-")

        rdlc_report_data = {New ReportDataSource("dt_list", dt_print), New ReportDataSource("dt_cmp", Print_DT_Company)}

    End Function
    Private Function Pribat_data_set()
        dt_print.Rows.Clear()
        dt_print = ds_print.Tables("TBL_GSTR1")
        Dim dr_print As DataRow

        For Each ro As DataGridViewRow In Grid2.Rows
            dr_print = dt_print.NewRow
            dr_print("Head") = ro.Cells(0).Value
            dr_print("Voucher_Count") = ro.Cells(1).Value
            dr_print("Taxable") = ro.Cells(2).Value
            dr_print("IGST") = ro.Cells(3).Value
            dr_print("CGST") = ro.Cells(4).Value
            dr_print("SGST") = ro.Cells(5).Value
            dr_print("CESS") = ro.Cells(6).Value
            dr_print("TAX_Amount") = ro.Cells(7).Value
            dr_print("Invoice_Amount") = ro.Cells(8).Value
            dt_print.Rows.Add(dr_print)
        Next
    End Function
    Private Function Fill_Grid()
        GSLab.Text = Company_GST_str

        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then

            With Grid2
                .Rows.Clear()
                B2B_Invoice(cn, Grid2)
            End With


            With Grid1
                .Rows.Clear()
                .Rows.Add("Total Vouchers", Total_Voucher(cn))
                .Rows.Add("Included in Return", Included_in_Return(cn))
                .Rows.Add("Not relevant in the Return", Not_relevant_in_the_Return(cn))
                .DefaultCellStyle.Padding = New Padding(10, 0, 0, 0)
            End With

        End If
    End Function
    Private Function B2B_Invoice(cn As SQLiteConnection, grid As DataGridView)
        Dim B2B_Vch_total As String = ""
        Dim B2B_Taxable As String = ""
        Dim B2B_IGST As String = ""
        Dim B2B_CGST As String = ""
        Dim B2B_SGST As String = ""
        Dim B2B_Cess As String = ""
        Dim B2B_TAX_Amt As String = ""
        Dim B2B_Ivc_Amt As String = ""

        Dim B2CL_Vch_total As String = ""
        Dim B2CL_Taxable As String = ""
        Dim B2CL_IGST As String = ""
        Dim B2CL_CGST As String = ""
        Dim B2CL_SGST As String = ""
        Dim B2CL_Cess As String = ""
        Dim B2CL_TAX_Amt As String = ""
        Dim B2CL_Ivc_Amt As String = ""

        Dim B2CS_Vch_total As String = ""
        Dim B2CS_Taxable As String = ""
        Dim B2CS_IGST As String = ""
        Dim B2CS_CGST As String = ""
        Dim B2CS_SGST As String = ""
        Dim B2CS_Cess As String = ""
        Dim B2CS_TAX_Amt As String = ""
        Dim B2CS_Ivc_Amt As String = ""


        Dim Export_Vch_total As String = ""
        Dim Export_Taxable As String = ""
        Dim Export_IGST As String = ""
        Dim Export_CGST As String = ""
        Dim Export_SGST As String = ""
        Dim Export_Cess As String = ""
        Dim Export_TAX_Amt As String = ""
        Dim Export_Ivc_Amt As String = ""


        Dim crdr_note_regular_Vch_total As String = ""
        Dim crdr_note_regular_Taxable As String = ""
        Dim crdr_note_regular_IGST As String = ""
        Dim crdr_note_regular_CGST As String = ""
        Dim crdr_note_regular_SGST As String = ""
        Dim crdr_note_regular_Cess As String = ""
        Dim crdr_note_regular_TAX_Amt As String = ""
        Dim crdr_note_regular_Ivc_Amt As String = ""

        Dim crdr_note_unregister_Vch_total As String = ""
        Dim crdr_note_unregister_Taxable As String = ""
        Dim crdr_note_unregister_IGST As String = ""
        Dim crdr_note_unregister_CGST As String = ""
        Dim crdr_note_unregister_SGST As String = ""
        Dim crdr_note_unregister_Cess As String = ""
        Dim crdr_note_unregister_TAX_Amt As String = ""
        Dim crdr_note_unregister_Ivc_Amt As String = ""


        Dim nill_Vch_total As String = ""
        Dim nill_Taxable As String = ""
        Dim nill_IGST As String = ""
        Dim nill_CGST As String = ""
        Dim nill_SGST As String = ""
        Dim nill_Cess As String = ""
        Dim nill_TAX_Amt As String = ""
        Dim nill_Ivc_Amt As String = ""

        Dim Total_Vch_total As String = 0
        Dim Total_Taxable As String = 0
        Dim Total_IGST As String = 0
        Dim Total_CGST As String = 0
        Dim Total_SGST As String = 0
        Dim Total_Cess As String = 0
        Dim Total_TAX_Amt As String = 0
        Dim Total_Ivc_Amt As String = 0



        cmd = New SQLiteCommand($"Select Tra_I,Amount,IGST,CGST,SGST,Cess,To_State,GST_Type,Voucher_Type,Country,ifnull(SUM(vc.Debit_Amount),0) as Dr,ifnull(SUM(vc.Credit_Amount),0) as Cr From (
Select vi.Tra_ID as Tra_I,
SUM(vi.Amount) as Amount,
SUM(vi.IGST) as IGST,
SUM(vi.CGST) as CGST,
SUM(vi.SGST) as SGST,
SUM(vi.Cess_Amt) as Cess,
vo.To_GST_Type as GST_Type,
vo.To_State as To_State,
(Select ld.Country From TBL_Ledger ld where ld.ID = vc.Ledger) as Country
From TBL_VC_item_Details vi
LEFT JOIN TBL_VC vc on vc.Tra_ID = vi.Tra_ID
LEFT JOIN TBL_VC_Other vo on vo.Tra_ID = vi.Tra_ID 
WHERE  vc.Type = 'Head' and vc.Visible = 'Approval' and (vc.Date BETWEEN '{CDate(Frm_date).ToString(Lite_date_Format)}' and '{CDate(to_date).AddDays(1).ToString(Lite_date_Format)}')
Group By vi.Tra_ID)
LEFT JOIN TBL_VC vc on vc.Tra_ID = Tra_I
Group By vc.Tra_ID", cn)

        Dim r As SQLiteDataReader = cmd.ExecuteReader
        While r.Read
            Dim to_gst As Decimal = Val(Val(r("IGST").ToString) + Val(r("CGST").ToString) + Val(r("SGST").ToString))
            Dim Vc_type As String = r("Voucher_Type").ToString.ToLower

            If Vc_type = "sales" Then
                If r("Country").ToString.ToLower = "india" Then
                    If Val(to_gst) <> 0 Then
                        If r("GST_Type").ToString.ToLower = "regular" Then
                            If State_Filter(r("To_State").ToString) = True Then
                                B2B_Vch_total = Val(B2B_Vch_total) + 1
                                B2B_Taxable = Val(B2B_Taxable) + Val(r("Amount").ToString)
                                B2B_IGST = Val(B2B_IGST) + Val(r("IGST").ToString)
                                B2B_SGST = Val(B2B_SGST) + Val(r("SGST").ToString)
                                B2B_CGST = Val(B2B_CGST) + Val(r("CGST").ToString)
                                B2B_Cess = Val(B2B_Cess) + Val(r("Cess").ToString)
                                B2B_TAX_Amt = Val(B2B_TAX_Amt) + Val(Val(r("IGST").ToString) + Val(r("SGST").ToString) + Val(r("CGST").ToString))
                                B2B_Ivc_Amt = Val(B2B_Ivc_Amt) + Val(r("Dr"))
                            End If
                        ElseIf r("GST_Type").ToString.ToLower = "consumer" Then
                            If State_Filter(r("To_State").ToString) = True Then
                                If Val(r("Dr")) <= 250000 Then
                                    B2CS_Vch_total = Val(B2CS_Vch_total) + 1
                                    B2CS_Taxable = Val(B2CS_Taxable) + Val(r("Amount").ToString)
                                    B2CS_IGST = Val(B2CS_IGST) + Val(r("IGST").ToString)
                                    B2CS_SGST = Val(B2CS_SGST) + Val(r("SGST").ToString)
                                    B2CS_CGST = Val(B2CS_CGST) + Val(r("CGST").ToString)
                                    B2CS_Cess = Val(B2CS_Cess) + Val(r("Cess").ToString)
                                    B2CS_TAX_Amt = Val(B2CS_TAX_Amt) + Val(Val(r("IGST").ToString) + Val(r("SGST").ToString) + Val(r("CGST").ToString))
                                    B2CS_Ivc_Amt = Val(B2CS_Ivc_Amt) + Val(r("Dr"))
                                Else
                                    B2CL_Vch_total = Val(B2CL_Vch_total) + 1
                                    B2CL_Taxable = Val(B2CL_Taxable) + Val(r("Amount").ToString)
                                    B2CL_IGST = Val(B2CL_IGST) + Val(r("IGST").ToString)
                                    B2CL_SGST = Val(B2CL_SGST) + Val(r("SGST").ToString)
                                    B2CL_CGST = Val(B2CL_CGST) + Val(r("CGST").ToString)
                                    B2CL_Cess = Val(B2CL_Cess) + Val(r("Cess").ToString)
                                    B2CL_TAX_Amt = Val(B2CL_TAX_Amt) + Val(Val(r("IGST").ToString) + Val(r("SGST").ToString) + Val(r("CGST").ToString))
                                    B2CL_Ivc_Amt = Val(B2CL_Ivc_Amt) + Val(r("Dr"))
                                End If
                            End If
                        End If
                    Else
                        nill_Vch_total = Val(nill_Vch_total) + 1
                        nill_Taxable = Val(nill_Taxable) + Val(r("Amount").ToString)
                        nill_IGST = Val(nill_IGST) + Val(r("IGST").ToString)
                        nill_SGST = Val(nill_SGST) + Val(r("SGST").ToString)
                        nill_CGST = Val(nill_CGST) + Val(r("CGST").ToString)
                        nill_Cess = Val(nill_Cess) + Val(r("Cess").ToString)
                        nill_TAX_Amt = Val(nill_TAX_Amt) + Val(Val(r("IGST").ToString) + Val(r("SGST").ToString) + Val(r("CGST").ToString))
                        nill_Ivc_Amt = Val(nill_Ivc_Amt) + Val(r("Dr"))
                    End If
                Else
                    Export_Vch_total = Val(Export_Vch_total) + 1
                    Export_Taxable = Val(Export_Taxable) + Val(r("Amount").ToString)
                    Export_IGST = Val(Export_IGST) + Val(r("IGST").ToString)
                    Export_SGST = Val(Export_SGST) + Val(r("SGST").ToString)
                    Export_CGST = Val(Export_CGST) + Val(r("CGST").ToString)
                    Export_Cess = Val(Export_Cess) + Val(r("Cess").ToString)
                    Export_TAX_Amt = Val(Export_TAX_Amt) + Val(Val(r("IGST").ToString) + Val(r("SGST").ToString) + Val(r("CGST").ToString))
                    Export_Ivc_Amt = Val(Export_Ivc_Amt) + Val(r("Dr"))
                End If
            ElseIf Vc_type = "credit note" Or Vc_type = "debit note" Then
                Dim nagitive_vlu As Decimal = 0
                If Vc_type = "credit note" Then
                    nagitive_vlu = -1
                Else
                    nagitive_vlu = 1
                End If

                If State_Filter(r("To_State").ToString) = True Then
                    If r("GST_Type").ToString.ToLower = "regular" Then
                        crdr_note_regular_Vch_total = Val(crdr_note_regular_Vch_total) + 1
                        crdr_note_regular_Taxable = Val(crdr_note_regular_Taxable) + (Val(r("Amount").ToString) * nagitive_vlu)
                        crdr_note_regular_IGST = Val(crdr_note_regular_IGST) + (Val(r("IGST").ToString) * nagitive_vlu)
                        crdr_note_regular_SGST = Val(crdr_note_regular_SGST) + (Val(r("SGST").ToString) * nagitive_vlu)
                        crdr_note_regular_CGST = Val(crdr_note_regular_CGST) + (Val(r("CGST").ToString) * nagitive_vlu)
                        crdr_note_regular_Cess = Val(crdr_note_regular_Cess) + (Val(r("Cess").ToString) * nagitive_vlu)
                        crdr_note_regular_TAX_Amt = Val(crdr_note_regular_TAX_Amt) + (Val(Val(r("IGST").ToString) + Val(r("SGST").ToString) + Val(r("CGST").ToString)) * nagitive_vlu)

                        If Vc_type = "credit note" Then
                            crdr_note_regular_Ivc_Amt = Val(crdr_note_regular_Ivc_Amt) + (Val(r("Dr").ToString) * nagitive_vlu)
                        Else
                            crdr_note_regular_Ivc_Amt = Val(crdr_note_regular_Ivc_Amt) + (Val(r("Cr").ToString) * nagitive_vlu)
                        End If
                    Else
                        crdr_note_unregister_Vch_total = Val(crdr_note_unregister_Vch_total) + 1
                        crdr_note_unregister_Taxable = Val(crdr_note_unregister_Taxable) + (Val(r("Amount").ToString) * nagitive_vlu)
                        crdr_note_unregister_IGST = Val(crdr_note_unregister_IGST) + (Val(r("IGST").ToString) * nagitive_vlu)
                        crdr_note_unregister_SGST = Val(crdr_note_unregister_SGST) + (Val(r("SGST").ToString) * nagitive_vlu)
                        crdr_note_unregister_CGST = Val(crdr_note_unregister_CGST) + (Val(r("CGST").ToString) * nagitive_vlu)
                        crdr_note_unregister_Cess = Val(crdr_note_unregister_Cess) + (Val(r("Cess").ToString) * nagitive_vlu)
                        crdr_note_unregister_TAX_Amt = Val(crdr_note_unregister_TAX_Amt) + (Val(Val(r("IGST").ToString) + Val(r("SGST").ToString) + Val(r("CGST").ToString)) * nagitive_vlu)

                        If Vc_type = "credit note" Then
                            crdr_note_unregister_Ivc_Amt = Val(crdr_note_unregister_Ivc_Amt) + (Val(r("Dr").ToString) * nagitive_vlu)
                        Else
                            crdr_note_unregister_Ivc_Amt = Val(crdr_note_unregister_Ivc_Amt) + (Val(r("Cr").ToString) * nagitive_vlu)
                        End If
                    End If
                End If
            End If
        End While



        grid.Rows.Add("B2B Invoices - 4A, 4B, 4C, 6B, 6C", (B2B_Vch_total),
N2_FORMATE(B2B_Taxable),
N2_FORMATE(B2B_IGST), N2_FORMATE(B2B_CGST), N2_FORMATE(B2B_SGST),
N2_FORMATE(B2B_Cess),
N2_FORMATE(B2B_TAX_Amt),
N2_FORMATE(B2B_Ivc_Amt)
)

        grid.Rows.Add("B2C (Small) Invoices - 7", (B2CS_Vch_total),
N2_FORMATE(B2CS_Taxable),
N2_FORMATE(B2CS_IGST), N2_FORMATE(B2CS_CGST), N2_FORMATE(B2CS_SGST),
N2_FORMATE(B2CS_Cess),
N2_FORMATE(B2CS_TAX_Amt),
N2_FORMATE(B2CS_Ivc_Amt)
)

        grid.Rows.Add("B2C (Large) Invoices - SA, 6B", (B2CL_Vch_total),
N2_FORMATE(B2CL_Taxable),
N2_FORMATE(B2CL_IGST), N2_FORMATE(B2CL_CGST), N2_FORMATE(B2CL_SGST),
N2_FORMATE(B2CL_Cess),
N2_FORMATE(B2CL_TAX_Amt),
N2_FORMATE(B2CL_Ivc_Amt)
)

        grid.Rows.Add("Exports Invoices - 6A", (Export_Vch_total),
N2_FORMATE(Export_Taxable),
N2_FORMATE(Export_IGST), N2_FORMATE(Export_CGST), N2_FORMATE(Export_SGST),
N2_FORMATE(Export_Cess),
N2_FORMATE(Export_TAX_Amt),
N2_FORMATE(Export_Ivc_Amt)
)


        grid.Rows.Add("Credit Or Debit Notes (Registered) - 9B", (crdr_note_regular_Vch_total),
N2_FORMATE(crdr_note_regular_Taxable),
N2_FORMATE(crdr_note_regular_IGST), N2_FORMATE(crdr_note_regular_CGST), N2_FORMATE(crdr_note_regular_SGST),
N2_FORMATE(crdr_note_regular_Cess),
N2_FORMATE(crdr_note_regular_TAX_Amt),
N2_FORMATE(crdr_note_regular_Ivc_Amt)
)

        grid.Rows.Add("Credit Or Debit Notes (Unregistered) - 9B", (crdr_note_unregister_Vch_total),
N2_FORMATE(crdr_note_unregister_Taxable),
N2_FORMATE(crdr_note_unregister_IGST), N2_FORMATE(crdr_note_unregister_CGST), N2_FORMATE(crdr_note_unregister_SGST),
N2_FORMATE(crdr_note_unregister_Cess),
N2_FORMATE(crdr_note_unregister_TAX_Amt),
N2_FORMATE(crdr_note_unregister_Ivc_Amt)
)

        grid.Rows.Add("Nil Rated Invoices - 8A, 8B, 8C, 8D", "",
"",
"", "", "",
"",
"",
""
)

        grid.Rows.Add("HSN Summary - 12", "",
"",
"", "", "",
"",
"",
""
)


        Total_Vch_total = Val(B2B_Vch_total) + Val(B2CS_Vch_total) + Val(B2CL_Vch_total) + Val(Export_Vch_total) + Val(crdr_note_regular_Vch_total) + Val(crdr_note_unregister_Vch_total) + Val(nill_Vch_total)
        Total_Taxable = Val(B2B_Taxable) + Val(B2CS_Taxable) + Val(B2CL_Taxable) + Val(Export_Taxable) + Val(crdr_note_regular_Taxable) + Val(crdr_note_unregister_Taxable) + Val(nill_Taxable)
        Total_IGST = Val(B2B_IGST) + Val(B2CS_IGST) + Val(B2CL_IGST) + Val(Export_IGST) + Val(crdr_note_regular_IGST) + Val(crdr_note_unregister_IGST) + Val(nill_IGST)
        Total_CGST = Val(B2B_CGST) + Val(B2CS_CGST) + Val(B2CL_CGST) + Val(Export_CGST) + Val(crdr_note_regular_CGST) + Val(crdr_note_unregister_CGST) + Val(nill_CGST)
        Total_SGST = Val(B2B_SGST) + Val(B2CS_SGST) + Val(B2CL_SGST) + Val(Export_SGST) + Val(crdr_note_regular_SGST) + Val(crdr_note_unregister_SGST) + Val(nill_SGST)
        Total_TAX_Amt = Val(B2B_TAX_Amt) + Val(B2CS_TAX_Amt) + Val(B2CL_TAX_Amt) + Val(Export_TAX_Amt) + Val(crdr_note_regular_TAX_Amt) + Val(crdr_note_unregister_TAX_Amt) + Val(nill_TAX_Amt)
        Total_Ivc_Amt = Val(B2B_Ivc_Amt) + Val(B2CS_Ivc_Amt) + Val(B2CL_Ivc_Amt) + Val(Export_Ivc_Amt) + Val(crdr_note_regular_Ivc_Amt) + Val(crdr_note_unregister_Ivc_Amt) + Val(nill_Ivc_Amt)




        Label12.Text = N2_FORMATE(Total_Vch_total)
        Label14.Text = N2_FORMATE(Total_Taxable)
        Label15.Text = N2_FORMATE(Total_IGST)
        Label16.Text = N2_FORMATE(Total_CGST)
        Label18.Text = N2_FORMATE(Total_SGST)
        Label19.Text = N2_FORMATE(0)
        Label20.Text = N2_FORMATE(Total_TAX_Amt)
        Label22.Text = N2_FORMATE(Total_Ivc_Amt)

    End Function
    Public Function State_Filter(str As String) As Boolean
        If (str.ToString.ToLower = "not applicable") Or (str.ToString.Length <= 2) Then
            Return False
        Else
            Return True
        End If
    End Function
    Private Function Not_relevant_in_the_Return(cnn As SQLiteConnection) As String
        Dim vl As Decimal = Val(Total_Voucher(cnn)) - Included_in_Return(cnn)

        Return Value_Decimal_set(vl, 0)
    End Function
    Private Function Included_in_Return(cnn As SQLiteConnection) As String
        Dim vl As Decimal = nUmBeR_FORMATE(Label12.Text)

        Return Value_Decimal_set(vl, 0)
    End Function
    Private Function Total_Voucher(cnn As SQLiteConnection) As Decimal
        Dim vlu As Integer = 0
        qury = $"Select count(*) As C From(
SELECT count(vc.ID)
FROM TBL_VC vc
where (vc.Visible = 'Approval') {Where_Filter() } and (Date BETWEEN '{Frm_date.ToString(Lite_date_Format)}' and '{to_date.AddDays(1).ToString(Lite_date_Format)}')
GROUP BY Tra_ID)"
        Dim r As SQLiteDataReader
        cmd = New SQLiteCommand(qury, cnn)
        r = cmd.ExecuteReader
        While r.Read
            vlu = Val(r("C").ToString)
        End While
        r.Close()
        Return vlu
    End Function
    'Dim Allo_Vouchers_Type As String = "(vc.Voucher_Type = 'Sales' or vc.Voucher_Type = 'Purchase Return'  or vc.Voucher_Type = 'Credit Note')"
    'Dim NotAllo_Vouchers_Type As String = "(vc.Voucher_Type <> 'Sales' and vc.Voucher_Type <> 'Purchase')"
    Private Sub gstr1_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.HADE_TXT.Text = "GSTR1"
        BG_frm.TYP_TXT.Text = VC_Type_

        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text
        Button_Clear()
        Button_Manage()
        'Config_Fill()
        'If Update_Report = True Then
        Fill_Grid()
        'End If


        Focus_Grid.CurrentCell = Focus_Grid.Rows(Focus_Cell).Cells(0)
        Focus_Grid.Focus()
    End Sub
    Private Sub gstr1_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub
    Private Sub gstr1_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
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
    Private Function Where_Filter() As String
        Dim q As String
        If Branch <> "Primary" Then
            q &= $" AND VC.Branch = '{Find_DT_Value(Database_File.cre, "TBL_Ledger", "ID", $"Name = '" & Branch & "'")}'"
        End If
        Return q
    End Function
    Public Sub G1_DrawLinePoint(ByVal e As PaintEventArgs)
        If Grid1.Columns.Count <> 0 Then
            Dim blackPen As New Pen(Color.Silver, 1)
            'Dim x As Decimal = Val(Grid1.Columns(1).Width)
            Dim x As Point = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(1, 0, False).Location)
            Dim point1 As New Point(x.X, 0)
            Dim point2 As New Point(x.X, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)
        End If
    End Sub
    Private Sub Grid1_Paint(sender As Object, e As PaintEventArgs) Handles Grid1.Paint
        G1_DrawLinePoint(e)
    End Sub
    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint
        Dim ctlpos As Point = Label7.PointToScreen(Label7.DisplayRectangle.Location)
        B1.Location = New Point(ctlpos.X, 0)
        B1.Height = Panel4.Height

        ctlpos = Label4.PointToScreen(Label4.DisplayRectangle.Location)
        B2.Location = New Point(ctlpos.X, 0)
        B2.Height = Panel4.Height

        ctlpos = Label5.PointToScreen(Label5.DisplayRectangle.Location)
        B3.Location = New Point(ctlpos.X, 0)
        B3.Height = Panel4.Height

        ctlpos = Label6.PointToScreen(Label6.DisplayRectangle.Location)
        B4.Location = New Point(ctlpos.X, 0)
        B4.Height = Panel4.Height

        ctlpos = Label8.PointToScreen(Label8.DisplayRectangle.Location)
        B5.Location = New Point(ctlpos.X, 0)
        B5.Height = Panel4.Height

        ctlpos = Label9.PointToScreen(Label9.DisplayRectangle.Location)
        B6.Location = New Point(ctlpos.X, 0)
        B6.Height = Panel4.Height

        ctlpos = Label10.PointToScreen(Label10.DisplayRectangle.Location)
        B7.Location = New Point(ctlpos.X, 0)
        B7.Height = Panel4.Height

        ctlpos = Label11.PointToScreen(Label11.DisplayRectangle.Location)
        B8.Location = New Point(ctlpos.X, 0)
        B8.Height = Panel4.Height




    End Sub

    Private Sub Grid2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid2.CellContentClick

    End Sub

    Private Sub Grid2_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid2.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Grid2.CurrentRow.Cells(0).Value = "HSN Summary - 12" Then
                Cell("HSN/SAC Summary", "")
            Else
                Focus_Grid = Grid2
                Focus_Cell = Grid2.CurrentRow.Index

                Cell("GSTR1 Summary", VC_Type_, Grid2.CurrentRow.Cells(0).Value.ToString)
            End If
        End If

        If e.KeyCode = Keys.Up Then
            If Grid2.CurrentRow.Index = 0 Then
                Grid1.CurrentCell = Grid1.Rows(Grid1.RowCount - 1).Cells(0)
                Grid1.Focus()
            End If
        End If
    End Sub

    Private Sub Grid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid1.CellContentClick

    End Sub

    Private Sub Grid1_GotFocus(sender As Object, e As EventArgs) Handles Grid1.GotFocus, Grid2.GotFocus
        sender.DefaultCellStyle.SelectionBackColor = Color.FromArgb(254, 197, 48)

    End Sub

    Private Sub Grid1_LostFocus(sender As Object, e As EventArgs) Handles Grid1.LostFocus, Grid2.LostFocus
        sender.DefaultCellStyle.SelectionBackColor = Color.White
    End Sub

    Private Sub Grid1_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid1.KeyDown
        If e.KeyCode = Keys.Down Then
            If Grid1.CurrentRow.Index = Grid1.RowCount - 1 Then
                Grid2.CurrentCell = Grid2.Rows(0).Cells(1)
                Grid2.Focus()
            End If
        End If
    End Sub

    Private Sub gstr1_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID

        Focus_Grid.CurrentCell = Focus_Grid.Rows(Focus_Cell).Cells(0)
        Focus_Grid.Focus()
    End Sub
    Dim B2B_Exp As New DataTable
    Dim B2CS_Exp As New DataTable
    Dim B2CL_Exp As New DataTable
    Dim Export_Exp As New DataTable
    Dim CreditNote_Reg_Exp As New DataTable
    Dim CreditNote_Unreg_Exp As New DataTable
    Dim Nill_Rate_Exp As New DataTable
    Dim HSN_Exp As New DataTable
    Private Sub Export_CSV_Background_DoWork(sender As Object, e As DoWorkEventArgs) Handles Export_Data_Frind.DoWork
        B2B_Exp = GSTR1_Ledger_Summary.B2B_Csv(Frm_date, to_date, True)
        B2CS_Exp = GSTR1_Ledger_Summary.B2CS_Csv(Frm_date, to_date, True)
        B2CL_Exp = GSTR1_Ledger_Summary.B2CL_Csv(Frm_date, to_date, True)
        Export_Exp = GSTR1_Ledger_Summary.EXPORT_un_Csv(Frm_date, to_date, True)
        CreditNote_Reg_Exp = GSTR1_Ledger_Summary.Crdr_R_Csv(Frm_date, to_date, True)
        CreditNote_Unreg_Exp = GSTR1_Ledger_Summary.Crdr_un_Csv(Frm_date, to_date, True)
        Nill_Rate_Exp = GSTR1_Ledger_Summary.NillRate_un_Csv(Frm_date, to_date, True)
        HSN_Exp = HSN_Summary_frm.HSN_Exp(Frm_date, to_date, True)
    End Sub

    Private Sub Export_CSV_Background_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles Export_Data_Frind.RunWorkerCompleted
        b2b_grid.DataSource = B2B_Exp
        b2cs_Grid.DataSource = B2CS_Exp
        b2cl_Grid.DataSource = B2CL_Exp
        Export_Grid.DataSource = Export_Exp
        Cr_reg_Grid.DataSource = CreditNote_Reg_Exp
        Cr_unreg_Grid.DataSource = CreditNote_Unreg_Exp
        nill_rate_Grid.DataSource = Nill_Rate_Exp
        HSN_Grid.DataSource = HSN_Exp


        Export_Background.RunWorkerAsync()

    End Sub

    Dim oBook As Excel.Workbook
    Private Sub Export_Background_DoWork(sender As Object, e As DoWorkEventArgs) Handles Export_Background.DoWork

        Dim oExcel As Object
        oExcel = CreateObject("Excel.Application")
        Dim oSheet As Excel.Worksheet

        oBook = oExcel.Workbooks.Add

        If oExcel.Application.Sheets.Count() < 1 Then
            oSheet = CType(oBook.Worksheets.Add(), Excel.Worksheet)
        Else
            oSheet = oExcel.Worksheets(1)
        End If

        oSheet.Name = "b2b,sez,de"
        Dim it As Integer = 0

        Dim cellRowIndex As Integer = 4
        Dim cellColumnIndex As Integer = 1

        Dim Gridd As DataGridView = b2b_grid

        For i As Integer = -1 To Gridd.Rows.Count - 1
            For j As Integer = 0 To Gridd.Columns.Count - 1
                If cellRowIndex = 4 Then
                    oSheet.Cells(cellRowIndex, cellColumnIndex) = Gridd.Columns(j).HeaderText
                Else
                    oSheet.Cells(cellRowIndex, cellColumnIndex) = Gridd.Rows(i).Cells(j).Value
                End If
                cellColumnIndex += 1
            Next
            cellColumnIndex = 1
            cellRowIndex += 1

            Export_Background.ReportProgress(it)
            it += 1
        Next


        If oExcel.Application.Sheets.Count() < 2 Then
            oSheet = CType(oBook.Worksheets.Add(), Excel.Worksheet)
        Else
            oSheet = oExcel.Worksheets(2)
        End If

        oSheet.Name = "b2cl"
        Gridd = b2cl_Grid

        cellRowIndex = 4
        cellColumnIndex = 1

        For i As Integer = -1 To Gridd.Rows.Count - 1
            For j As Integer = 0 To Gridd.Columns.Count - 1
                If cellRowIndex = 4 Then
                    oSheet.Cells(cellRowIndex, cellColumnIndex) = Gridd.Columns(j).HeaderText
                Else
                    oSheet.Cells(cellRowIndex, cellColumnIndex) = Gridd.Rows(i).Cells(j).Value
                End If
                cellColumnIndex += 1
            Next
            cellColumnIndex = 1
            cellRowIndex += 1

            Export_Background.ReportProgress(it)
            it += 1
        Next


        If oExcel.Application.Sheets.Count() < 3 Then
            oSheet = CType(oBook.Worksheets.Add(), Excel.Worksheet)
        Else
            oSheet = oExcel.Worksheets(3)
        End If

        oSheet.Name = "b2cs"
        Gridd = b2cs_Grid

        cellRowIndex = 4
        cellColumnIndex = 1

        For i As Integer = -1 To Gridd.Rows.Count - 1
            For j As Integer = 0 To Gridd.Columns.Count - 1
                If cellRowIndex = 4 Then
                    oSheet.Cells(cellRowIndex, cellColumnIndex) = Gridd.Columns(j).HeaderText
                Else
                    oSheet.Cells(cellRowIndex, cellColumnIndex) = Gridd.Rows(i).Cells(j).Value
                End If
                cellColumnIndex += 1
            Next
            cellColumnIndex = 1
            cellRowIndex += 1

            Export_Background.ReportProgress(it)
            it += 1
        Next


        If oExcel.Application.Sheets.Count() < 4 Then
            oSheet = CType(oBook.Worksheets.Add(), Excel.Worksheet)
        Else
            oSheet = oExcel.Worksheets(4)
        End If

        oSheet.Name = "cdnr"
        Gridd = Cr_reg_Grid

        cellRowIndex = 4
        cellColumnIndex = 1

        For i As Integer = -1 To Gridd.Rows.Count - 1
            For j As Integer = 0 To Gridd.Columns.Count - 1
                If cellRowIndex = 4 Then
                    oSheet.Cells(cellRowIndex, cellColumnIndex) = Gridd.Columns(j).HeaderText
                Else
                    oSheet.Cells(cellRowIndex, cellColumnIndex) = Gridd.Rows(i).Cells(j).Value
                End If
                cellColumnIndex += 1
            Next
            cellColumnIndex = 1
            cellRowIndex += 1

            Export_Background.ReportProgress(it)
            it += 1
        Next

        If oExcel.Application.Sheets.Count() < 5 Then
            oSheet = CType(oBook.Worksheets.Add(), Excel.Worksheet)
        Else
            oSheet = oExcel.Worksheets(5)
        End If

        oSheet.Name = "cdnur"
        Gridd = Cr_unreg_Grid

        cellRowIndex = 4
        cellColumnIndex = 1

        For i As Integer = -1 To Gridd.Rows.Count - 1
            For j As Integer = 0 To Gridd.Columns.Count - 1
                If cellRowIndex = 4 Then
                    oSheet.Cells(cellRowIndex, cellColumnIndex) = Gridd.Columns(j).HeaderText
                Else
                    oSheet.Cells(cellRowIndex, cellColumnIndex) = Gridd.Rows(i).Cells(j).Value
                End If
                cellColumnIndex += 1
            Next
            cellColumnIndex = 1
            cellRowIndex += 1

            Export_Background.ReportProgress(it)
            it += 1
        Next

        If oExcel.Application.Sheets.Count() < 6 Then
            oSheet = CType(oBook.Worksheets.Add(), Excel.Worksheet)
        Else
            oSheet = oExcel.Worksheets(6)
        End If

        oSheet.Name = "exp"
        Gridd = Export_Grid

        cellRowIndex = 4
        cellColumnIndex = 1

        For i As Integer = -1 To Gridd.Rows.Count - 1
            For j As Integer = 0 To Gridd.Columns.Count - 1
                If cellRowIndex = 4 Then
                    oSheet.Cells(cellRowIndex, cellColumnIndex) = Gridd.Columns(j).HeaderText
                Else
                    oSheet.Cells(cellRowIndex, cellColumnIndex) = Gridd.Rows(i).Cells(j).Value
                End If
                cellColumnIndex += 1
            Next
            cellColumnIndex = 1
            cellRowIndex += 1

            Export_Background.ReportProgress(it)
            it += 1
        Next

        If oExcel.Application.Sheets.Count() < 7 Then
            oSheet = CType(oBook.Worksheets.Add(), Excel.Worksheet)
        Else
            oSheet = oExcel.Worksheets(6)
        End If

        oSheet.Name = "exemp"
        Gridd = nill_rate_Grid

        cellRowIndex = 4
        cellColumnIndex = 1

        For i As Integer = -1 To Gridd.Rows.Count - 1
            For j As Integer = 0 To Gridd.Columns.Count - 1
                If cellRowIndex = 4 Then
                    oSheet.Cells(cellRowIndex, cellColumnIndex) = Gridd.Columns(j).HeaderText
                Else
                    oSheet.Cells(cellRowIndex, cellColumnIndex) = Gridd.Rows(i).Cells(j).Value
                End If
                cellColumnIndex += 1
            Next
            cellColumnIndex = 1
            cellRowIndex += 1

            Export_Background.ReportProgress(it)
            it += 1
        Next

        If oExcel.Application.Sheets.Count() < 7 Then
            oSheet = CType(oBook.Worksheets.Add(), Excel.Worksheet)
        Else
            oSheet = oExcel.Worksheets(6)
        End If


        oSheet.Name = "hsn"
        Gridd = HSN_Grid

        cellRowIndex = 4
        cellColumnIndex = 1

        For i As Integer = -1 To Gridd.Rows.Count - 1
            For j As Integer = 0 To Gridd.Columns.Count - 1
                If cellRowIndex = 4 Then
                    oSheet.Cells(cellRowIndex, cellColumnIndex) = Gridd.Columns(j).HeaderText
                Else
                    oSheet.Cells(cellRowIndex, cellColumnIndex) = Gridd.Rows(i).Cells(j).Value
                End If
                cellColumnIndex += 1
            Next
            cellColumnIndex = 1
            cellRowIndex += 1

            Export_Background.ReportProgress(it)
            it += 1
        Next
    End Sub
    Private Sub Export_Background_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles Export_Background.ProgressChanged
    End Sub

    Private Sub Export_Background_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles Export_Background.RunWorkerCompleted
        oBook.SaveAs($"{Export_Location}.xlsx")
    End Sub

End Class