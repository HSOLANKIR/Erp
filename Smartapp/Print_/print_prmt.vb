
Module print_prmt
    Public Obj As Report_Ledger_frm
    Public Function xml_Function_link(st As String, Vlu As String)
        Select Case st
            Case "cprj"
                Return cprj_(Vlu)
            Case "ivc"
                Return INVOICE_(Vlu)
            Case "Account_Ledger_Report"
                Return DAL_(Vlu)
            Case "DayBook"
                Return DayBook_(Vlu)
            Case "Account_Ledger_Report_Monthly"
                Return DAL_Monthly_(Vlu)
            Case "Account_Group"
                Return Account_Group_(Vlu)
            Case "Stock_Item"
                Return Stock_Item_(Vlu)
            Case "Stock_Item_Monthly"
                Return Stock_Item_Monthly_(Vlu)
            Case "Stock_Summary"
                Return Stock_Summary_(Vlu)
            Case "Stock_Summary_Expiry_Date"
                Return Stock_Summary_Expiry_Date_Report(Vlu)
            Case "Sales_Purchase_Register"
                Return Sales_Purchase_Register(Vlu)
            Case "Vouchers_Summary"
                Return Vouchers_Summary(Vlu)
            Case "Payroll_Loan_Sanction"
                Return Payroll_Loan_Sanction(Vlu)
            Case "Loan_Statement"
                Return Loan_Statement(Vlu)
            Case "Accountiong_Register"
                Return Accounting_Register(Vlu)
            Case "Profit_Loss"
                Return Profit_Loss(Vlu)
            Case "Balance_Sheet"
                Return Balance_Sheet_(Vlu)
            Case "Payroll_Payslip"
                Return Payroll_Payslip(Vlu)
            Case "GSTR1"
                Return GSTR1(Vlu)


        End Select
    End Function
    Public Function cprj_(vlu As String)
        If vlu.ToString.Substring(0, 1) = "'" And vlu.ToString.Substring(vlu.Length - 1, 1) = "'" Then

            Return vlu.ToString.Substring(1, vlu.Length - 2)
        Else
            Select Case vlu
                Case "Head"
                    Return Accounting_Voucher_frm.cfg_print_head
                Case "YN_signature"
                    Return Accounting_Voucher_frm.cfg_print_signature
                Case "YN_stamp"
                    Return Accounting_Voucher_frm.cfg_print_stamp
                Case "yn_Qr_Pay"
                    Return Accounting_Voucher_frm.cfg_YN_print_pay_qry
                Case "Print_Terms_Conditions"
                    Return Accounting_Voucher_frm.cfg_print_Terms_Conditions
                Case "YN_Provisnoal"
                    Return YN_Boolean(Accounting_Voucher_frm.cfg_print_Provisnoal)
                Case "Total_Amount"
                    Return Val(Accounting_Voucher_frm.TOTAL_AMOUNT_VALUE)
                Case "Narration"
                    If Accounting_Voucher_frm.cfg_YN_narration = True Then
                        Return Accounting_Voucher_frm.Narration_TXT.Text
                    Else
                        Return ""
                    End If
                Case Else
                    Return ""
            End Select
        End If
    End Function
    Public Function INVOICE_(vlu As String)
        If vlu.ToString.Substring(0, 1) = "'" And vlu.ToString.Substring(vlu.Length - 1, 1) = "'" Then

            Return vlu.ToString.Substring(1, vlu.Length - 2)
        Else
            With Inventory_Vouchers_frm
                Select Case vlu
                    Case "Head"
                        Return .cfg_print_head
                    Case "ivc_type"
                        Return .cfg_print_type
                    Case "SabTotal"
                        Return Format(Val(.Sp_controls1.amt_total_label.Text), "N2")
                    Case "CSGST_Value"
                        If .TAX_Type = "CS" Then
                            Return Format(Val(Val(.Sp_controls1.GST_Total.Text) / 2), "N2")
                        Else
                            Return ""
                        End If
                    Case "IGST_Value"
                        If .TAX_Type = "I" Then
                            Return Format(Val(.Sp_controls1.GST_Total.Text), "N2")
                        Else
                            Return ""
                        End If
                    Case "cess_prmt"
                        Return Format(Val(.Sp_controls1.Cess_Total.Text), "N2")

                    Case "Amount_vlu"
                        Return Format(Val(.Sp_controls1.Amounr_Label.Text), "N2")

                    Case "Amount_word"
                        Return NumberToText(Val(.Sp_controls1.Amounr_Label.Text)) & " Only/-"
                    Case "Expence_total"
                        Return Format(Val(.Sp_controls1.Label10.Text), "N2")
                    Case "Account_name"
                        Return .To_Name
                    Case "Account_Address"
                        Return .To_Address1
                    Case "Date_"
                        Return .Date_TXT.Text
                    Case "Day_"
                        Return .Day_Label.Text
                    Case "Delivry_date"
                        Return .Delivery_Date_TXT.Text
                    Case "Delivry_day"
                        Return Date_TO_Day(.Delivery_Date_TXT.Text)
                    Case "Voucher_No"
                        Return .Print_IVC_No_
                    Case "order_details"
                        Return .Print_Order_Details
                    Case "register_details"
                        Return .Print_Register_Details
                    Case "Payment_Type"
                        Return .Terms_of_payment
                    Case "Payment_refrence"
                        Return .Payment_reference
                    Case "Payment_Description"
                        Return .terms_of_delivery
                    Case "Supplier_ivc_no"
                        Return .supplier_vc_no

                    Case "YN_Expence"
                        If Val(.Sp_controls1.Label10.Text) <= 0 Then
                            Return "Yes"
                        Else
                            Return "No"
                        End If
                    Case "trams_conditions"
                        Return .cfg_print_Terms_Conditions
                    Case "Provisnoal_Balance"
                        If .cfg_print_Provisnoal = "Amount" Then
                            Return .Label8.Text.ToString.Trim
                        Else
                            Return "Not Applicable"
                        End If
                    Case "Transport_Name"
                        Return .Transport_Name.Trim
                    Case "Vehicale_Type"
                        Return .Vihicale_Type.Trim
                    Case "Vehicale_No"
                        Return .Vihicale_No.Trim
                    Case "Transport_LR"
                        Return .LR_No.Trim
                    Case "Driver_Name"
                        Return .Driver_Name.Trim
                    Case "Driver_Phone"
                        Return .Driver_Phone.Trim
                    Case "upi_id"
                        Return Company_UPI_str.Trim
                    Case "EwayBill_No"
                        Return .eb_ewaybill_no.Trim
                    Case "Supplier_GST"
                        Return .Supp_GST.Trim
                    Case "Supplier_PAN"
                        Return .Supp_PAN.Trim
                    Case "Supplier_BankName"
                        Return .Supp_Bank.Trim
                    Case "Supplier_BankBranch"
                        Return .Supp_Branch.Trim
                    Case "Supplier_AccountNo"
                        Return .Supp_BankAcc.Trim
                    Case "Supplier_Bankifsc"
                        Return .Supp_IFSC.Trim
                    Case "Ship_Name"
                        Return .Ship_Mailing.Trim
                    Case "Ship_Address"
                        Return .Ship_Address.Trim
                    Case "YN_MRP"
                        Return .cfg_YN_print_item_MRP
                    Case "YN_UPI_QR"
                        Return .cfg_YN_print_pay_qry
                    Case "round_off"
                        Return N2_FORMATE(.Sp_controls1.roundup_val_Lab.Text)
                    Case "discount_total"
                        Return N2_FORMATE(.Sp_controls1.Discount_Total_Label.Text)
                    Case "Subtotal1_prmt"
                        Return N2_FORMATE(.Sp_controls1.Label19.Text)
                    Case "prmt_Provisional_Type"
                        Return .cfg_print_Provisnoal

                    Case Else
                        Return ""
                End Select
            End With

        End If
    End Function
    Public Function DAL_(vlu As String)
        If vlu.ToString.Substring(0, 1) = "'" And vlu.ToString.Substring(vlu.Length - 1, 1) = "'" Then

            Return vlu.ToString.Substring(1, vlu.Length - 2)
        Else
            With Obj
                Select Case vlu
                    Case "Account_Name"
                        Return .Acc_LB.Text
                    Case "Account_prmt"
                        Return .Acc_LB.Text
                    Case "Date_"
                        Return .Frm_Date_LB.Text & " to " & .To_Date_LB.Text
                    Case "Debit_Value"
                        Return Format(nUmBeR_FORMATE(nUmBeR_FORMATE(.Dr_Total) + nUmBeR_FORMATE(.Label6.Text)), "N2")
                    Case "Credit_Value"
                        Return Format(nUmBeR_FORMATE(nUmBeR_FORMATE(.Cr_Total) + nUmBeR_FORMATE(.Label7.Text)), "N2")
                    Case "Closing_prmt"
                        Return .Label10.Text
                    Case "Debit_Opning_Value"
                        Return Format(Val(.Label6.Text), "N2")
                    Case "Credit_Opning_Value"
                        Return Format(Val(.Label7.Text), "N2")
                    Case "Qty_Total"
                        If .Total_Unit_YN = True Then
                            Return Format(Val(.Total_Qty), "N2") & " " & .Total_Unit
                        Else
                            Return ""
                        End If
                    Case "Amount"
                        Dim cl As Decimal = (Val(.Label6.Text) + Val(.Label8.Text))
                        If cl = 0 Then
                            Return Format(Val(Val(.Label7.Text) + Val(.Cr_Total)), "N2")
                        Else
                            Return Format(Val(cl), "N2")
                        End If
                End Select
            End With

        End If
    End Function
    Public Function Profit_Loss(vlu As String)
        If vlu.ToString.Substring(0, 1) = "'" And vlu.ToString.Substring(vlu.Length - 1, 1) = "'" Then
            Return vlu.ToString.Substring(1, vlu.Length - 2)
        Else
            With Profit_Loss_frm
                Select Case vlu
                    Case "prmt_Head"
                        Return "Profit & Loss Account"
                    Case "Date_"
                        Return $"{ .Frm_Date_LB.Text} to { .To_Date_LB.Text}"
                    Case "gross_total"
                        Return $"{ .Label6.Text}"
                    Case "Net_Total"
                        Return $"{ .Label6.Text}"

                End Select
            End With
        End If
    End Function
    Public Function Accounting_Register(vlu As String)
        If vlu.ToString.Substring(0, 1) = "'" And vlu.ToString.Substring(vlu.Length - 1, 1) = "'" Then
            Return vlu.ToString.Substring(1, vlu.Length - 2)
        Else
            With Accounting_Registers_frm

                Select Case vlu
                    Case "Head_prmt"
                        Return .Print_Head
                    Case "Date_prmt"
                        Return .Print_Date
                    Case "Amount_Total"
                        Return .Total_Labale.Text
                    Case "Entry_Total"
                        Return .Total_Vouchers_Label.Text

                End Select
            End With

        End If
    End Function
    Public Function DayBook_(vlu As String)
        If vlu.ToString.Substring(0, 1) = "'" And vlu.ToString.Substring(vlu.Length - 1, 1) = "'" Then

            Return vlu.ToString.Substring(1, vlu.Length - 2)
        Else
            Select Case vlu
                Case "Date_"
                    Return Day_Book_frm.Frm_Date_LB.Text & " to " & Day_Book_frm.To_Date_LB.Text
            End Select

        End If
    End Function
    Public Function DAL_Monthly_(vlu As String)
        If vlu.ToString.Substring(0, 1) = "'" And vlu.ToString.Substring(vlu.Length - 1, 1) = "'" Then

            Return vlu.ToString.Substring(1, vlu.Length - 2)
        Else
            Select Case vlu
                Case "Account_Name"
                    Return Report_Ledger_monthly_frm.Acc_LB.Text
                Case "Date_"
                    Return Report_Ledger_monthly_frm.Frm_Date_LB.Text & " to " & Report_Ledger_monthly_frm.To_Date_LB.Text
                Case "Credit_Closing_Value"
                    Return ((Report_Ledger_monthly_frm.CR_TO_LB.Text))
                Case "Debit_Closing_Value"
                    Return ((Report_Ledger_monthly_frm.DR_TO_LB.Text))
                Case "Closing_Value"
                    Return ((Report_Ledger_monthly_frm.Label2.Text))
                Case "Debit_Opning"
                    Return ((Report_Ledger_monthly_frm.Grid1.Rows(0).Cells(4).Value.ToString))
                Case "Credit_Opning"
                    Return Format(Val(Report_Ledger_monthly_frm.Grid1.Rows(0).Cells(5).Value.ToString), "N2")
                Case "Closing_Opning"
                    Return ((Report_Ledger_monthly_frm.Grid1.Rows(0).Cells(6).Value.ToString))
            End Select

        End If
    End Function
    Public Function GSTR1(vlu As String)
        If vlu.ToString.Substring(0, 1) = "'" And vlu.ToString.Substring(vlu.Length - 1, 1) = "'" Then
            Return vlu.ToString.Substring(1, vlu.Length - 2)
        Else
            With gstr1_frm
                Select Case vlu
                    Case "Date_"
                        Return $"{CDate(.Frm_Date_LB.Text)} to {CDate(.To_Date_LB.Text)}"
                    Case "total_vouchers"
                        Return $"{ .Label12.Text}"
                    Case "total_taxable_amount"
                        Return $"{ .Label14.Text}"
                    Case "total_igst"
                        Return $"{ .Label15.Text}"
                    Case "total_cgst"
                        Return $"{ .Label16.Text}"
                    Case "total_sgst"
                        Return $"{ .Label18.Text}"
                    Case "total_cess"
                        Return $"{ .Label19.Text}"
                    Case "total_TAX_Amount"
                        Return $"{ .Label20.Text}"
                    Case "total_ivc_amount"
                        Return $"{ .Label22.Text}"


                End Select
            End With
        End If
    End Function
    Public Function Payroll_Payslip(vlu As String)
        If vlu.ToString.Substring(0, 1) = "'" And vlu.ToString.Substring(vlu.Length - 1, 1) = "'" Then
            Return vlu.ToString.Substring(1, vlu.Length - 2)
        Else
            With Payshlip_display_frm
                Select Case vlu
                    Case "prmt_Employee_ID"
                        Return .Em_ID_LB.Text
                    Case "prmt_Employee_Name"
                        Return .Label1.Text
                    Case "prmt_Employee_Phone"
                        Return .EM_Phone_LB.Text
                    Case "Date_prmt"
                        Return $"{CDate(.Frm_Date_LB.Text)} to {CDate(.To_Date_LB.Text)}"
                    Case "prmt_Earning_total"
                        Return .Label18.Text
                    Case "prmt_deductions_total"
                        Return .Label20.Text
                    Case "prmt_net_amt"
                        Return .Label24.Text
                    Case "prmt_note"
                        Return ""

                End Select
            End With
        End If
    End Function
    Public Function Balance_Sheet_(vlu As String)
        If vlu.ToString.Substring(0, 1) = "'" And vlu.ToString.Substring(vlu.Length - 1, 1) = "'" Then
            Return vlu.ToString.Substring(1, vlu.Length - 2)
        Else
            With Balance_Sheet_frm
                Select Case vlu
                    Case "prmt_Head"
                        Return "Balance Sheet"
                    Case "Date_"
                        Return $"{ .Frm_Date_LB.Text} to { .To_Date_LB.Text}"
                    Case "Net_Total"
                        Return $"{ .Total_A.Text}"

                End Select
            End With
        End If
    End Function
    Public Function Account_Group_(vlu As String)
        With Report_Group_Summary_frm
            If vlu.ToString.Substring(0, 1) = "'" And vlu.ToString.Substring(vlu.Length - 1, 1) = "'" Then
                Return vlu.ToString.Substring(1, vlu.Length - 2)
            Else
                Select Case vlu
                    Case "Date_"
                        Return .Frm_Date_LB.Text & " to " & .To_Date_LB.Text
                    Case "Account_prmt"
                        Return .Acc_LB.Text
                    Case "Opning_total"
                        Return .OB_LB.Text
                    Case "curr_Total"
                        Return .CR_LB.Text
                    Case "closing_Total"
                        Return .CL_LB.Text


                End Select
            End If
        End With
    End Function
    Public Function Stock_Item_(vlu As String)
        If vlu.ToString.Substring(0, 1) = "'" And vlu.ToString.Substring(vlu.Length - 1, 1) = "'" Then
            Return vlu.ToString.Substring(1, vlu.Length - 2)
        Else
            Select Case vlu
                Case "Item_Name"
                    Return Report_Stock_item_frm.Acc_LB.Text
                Case "Date_"
                    Return Report_Stock_item_frm.Frm_Date_LB.Text & " to " & Report_Stock_item_frm.To_Date_LB.Text
                Case "Inward_Qty_Opning_Balance"
                    Return Report_Stock_item_frm.Grid1.Rows(0).Cells(6).Value.ToString
                Case "Inward_Rate_Opning_Balance"
                    Return Report_Stock_item_frm.Grid1.Rows(0).Cells(7).Value.ToString
                Case "Inward_Amount_Opning_Balance"
                    Return Report_Stock_item_frm.Grid1.Rows(0).Cells(8).Value.ToString
                Case "Outward_Qty_Opning_Balance"
                    Return Report_Stock_item_frm.Grid1.Rows(0).Cells(9).Value.ToString
                Case "Outward_Rate_Opning_Balance"
                    Return Report_Stock_item_frm.Grid1.Rows(0).Cells(10).Value.ToString
                Case "Outward_Amount_Opning_Balance"
                    Return Report_Stock_item_frm.Grid1.Rows(0).Cells(11).Value.ToString
                Case "Closing_Qty_Opning_Balance"
                    Return Report_Stock_item_frm.Grid1.Rows(0).Cells(12).Value.ToString
                Case "Closing_Rate_Opning_Balance"
                    Return Report_Stock_item_frm.Grid1.Rows(0).Cells(13).Value.ToString
                Case "Closing_Amount_Opning_Balance"
                    Return Report_Stock_item_frm.Grid1.Rows(0).Cells(14).Value.ToString
                Case "Inward_Qty_Total_Balance"
                    Return Report_Stock_item_frm.Label11.Text.ToString
                Case "Inward_Rate_Total_Balance"
                    'Return Report_Stock_item_frm.Label10.Text.ToString
                Case "Inward_Amount_Total_Balance"
                    Return Report_Stock_item_frm.Label9.Text.ToString
                Case "Outward_Qty_Total_Balance"
                    Return Report_Stock_item_frm.Label5.Text.ToString
                Case "Outward_Rate_Total_Balance"
                    'Return Report_Stock_item_frm.Label4.Text.ToString
                Case "Outward_Amount_Total_Balance"
                    Return Report_Stock_item_frm.Label2.Text.ToString
                Case "Closing_Qty_Total_Balance"
                    Return Report_Stock_item_frm.Label8.Text.ToString
                Case "Closing_Rate_Total_Balance"
                    'Return Report_Stock_item_frm.Label7.Text.ToString
                Case "Closing_Amount_Total_Balance"
                    Return Report_Stock_item_frm.Label6.Text.ToString

            End Select
        End If
    End Function
    Public Function Stock_Item_Monthly_(vlu As String)
        If vlu.ToString.Substring(0, 1) = "'" And vlu.ToString.Substring(vlu.Length - 1, 1) = "'" Then
            Return vlu.ToString.Substring(1, vlu.Length - 2)
        Else
            Select Case vlu
                Case "Date_"
                    Return Report_Stock_item_monthly_frm.Frm_Date_LB.Text & " to " & Report_Stock_item_monthly_frm.To_Date_LB.Text
                Case "Account_Name"
                    Return Report_Stock_item_monthly_frm.Acc_LB.Text
                Case "Qty_Opning_Closing"
                    Return Report_Stock_item_monthly_frm.Grid1.Rows(0).Cells(9).Value.ToString
                Case "Amount_Opning_Closing"
                    Return Report_Stock_item_monthly_frm.Grid1.Rows(0).Cells(10).Value.ToString
                Case "Qty_Total_Inward"
                    Return Report_Stock_item_monthly_frm.Label11.Text
                Case "Amount_Total_Inward"
                    Return Report_Stock_item_monthly_frm.Label9.Text
                Case "Qty_Total_Outward"
                    Return Report_Stock_item_monthly_frm.Label5.Text
                Case "Amount_Total_Outward"
                    Return Report_Stock_item_monthly_frm.Label2.Text
                Case "Qty_Total_Closing"
                    Return Report_Stock_item_monthly_frm.Label8.Text
                Case "Amount_Total_Closing"
                    Return Report_Stock_item_monthly_frm.Label6.Text
            End Select
        End If
    End Function
    Public Function Stock_Summary_(vlu As String)
        If vlu.ToString.Substring(0, 1) = "'" And vlu.ToString.Substring(vlu.Length - 1, 1) = "'" Then
            Return vlu.ToString.Substring(1, vlu.Length - 2)
        Else
            Select Case vlu
                Case "Date_"
                    Return Report_Stock_Summary_frm.To_Date_LB.Text
                Case "Account_Name"
                    Return Report_Stock_Summary_frm.Acc_LB.Text
            End Select
        End If
    End Function
    Public Function Stock_Summary_Expiry_Date_Report(vlu As String)
        If vlu.ToString.Substring(0, 1) = "'" And vlu.ToString.Substring(vlu.Length - 1, 1) = "'" Then
            Return vlu.ToString.Substring(1, vlu.Length - 2)
        Else
            Select Case vlu
                Case "Item_Name"
                    Return Expiry_Date_Item_Summary.Acc_LB.Text
                Case "Date_"
                    Return Expiry_Date_Item_Summary.To_Date_LB.Text
                Case "Total_"
                    Return Expiry_Date_Item_Summary.Label2.Text
            End Select
        End If
    End Function
    Public Function Sales_Purchase_Register(vlu As String)
        With Inventory_Register_frm
            If vlu.ToString.Substring(0, 1) = "'" And vlu.ToString.Substring(vlu.Length - 1, 1) = "'" Then
                Return vlu.ToString.Substring(1, vlu.Length - 2)
            Else
                Select Case vlu
                    Case "Register_Name"
                        Return .Acc_LB.Text
                    Case "Item_prmt"
                        Return .it_name
                    Case "Date_"
                        Return .Frm_Date_LB.Text & " to " & .To_Date_LB.Text
                    Case "Subtotal"
                        Return (.Total_Grid.Rows(0).Cells(9).Value)
                    Case "CSGST"
                        Return (.Total_Grid.Rows(0).Cells(11).Value)
                    Case "IGST"
                        Return (.Total_Grid.Rows(0).Cells(12).Value)
                    Case "Amount"
                        Return (.Total_Grid.Rows(0).Cells(13).Value)
                    Case "qty_total_prmt"
                        Return (.Total_Grid.Rows(0).Cells(6).Value & " " & .Grid1.Rows(0).Cells(7).Value)

                End Select
            End If
        End With
    End Function
    Public Function Vouchers_Summary(vlu As String)
        If vlu.ToString.Substring(0, 1) = "'" And vlu.ToString.Substring(vlu.Length - 1, 1) = "'" Then
            Return vlu.ToString.Substring(1, vlu.Length - 2)
        Else
            Select Case vlu
                Case "Head"
                    Return $"{Registers_Summary_Frm.Acc_LB.Text} Summary"
                Case "Date_"
                    Return Registers_Summary_Frm.To_Date_LB.Text
                Case "Entry_Total"
                    Return Registers_Summary_Frm.Label1.Text
                Case "Credit_Closing"
                    Return 0
                Case "Closing_prmt"
                    Return Registers_Summary_Frm.Label2.Text

            End Select
        End If
    End Function
    Public Function Payroll_Loan_Sanction(vlu As String)
        If vlu.ToString.Substring(0, 1) = "'" And vlu.ToString.Substring(vlu.Length - 1, 1) = "'" Then
            Return vlu.ToString.Substring(1, vlu.Length - 2)
        Else
            Select Case vlu
                Case "customer_id"
                    Return Loan_sanction_frm.ID_LAB.Text
                Case "customer_name"
                    Return Loan_sanction_frm.Name_LAB.Text
                Case "customer_aadhaar"
                    Return Loan_sanction_frm.Aadhaar_LAB.Text
                Case "customer_pan"
                    Return Loan_sanction_frm.PAN_LAB.Text
                Case "customer_dob"
                    Return CDate(Find_DT_Value(Database_File.cre, "TBL_Payroll_Employee", "Date_of_birth", "ID = '" & Loan_sanction_frm.ID_LAB.Text & "'")).ToString("dd-MM-yyyy")
                Case "customer_phone"
                    Return Loan_sanction_frm.Mobile_LAB.Text
                Case "customer_address"
                    Return Loan_sanction_frm.Address_LAB.Text
                Case "customer_salary"
                    Return Loan_sanction_frm.Salary_LAB.Text
                Case "customer_email"
                    Return Loan_sanction_frm.Email_LAB.Text
                Case "customer_doj"
                    Return Loan_sanction_frm.joining_LAB.Text

                Case "loan_amt"
                    Return N2_FORMATE(Loan_sanction_frm.LoanAmt_TXT.Text)
                Case "month_intrest"
                    Return N2_FORMATE(Loan_sanction_frm.intrest_txt.Text)
                Case "month_prmt"
                    Return Format(Val(Loan_sanction_frm.Label36.Text), "0")
                Case "month_amount"
                    Return N2_FORMATE(Loan_sanction_frm.Month_Payment_LAB.Text)
                Case "total_intrest"
                    Return N2_FORMATE(Loan_sanction_frm.Total_Intrest_LAB.Text)
                Case "total_payment"
                    Return N2_FORMATE(Loan_sanction_frm.Total_Payment_LAB.Text)
                Case "samction_date"
                    Return (Loan_sanction_frm.SanctionDate_txt.Text)
                Case "frist_date"
                    Return (Loan_sanction_frm.Frist_instalment_Date_LAB.Text)
                Case "last_date"
                    Return (Loan_sanction_frm.Last_instalment_Date_LAB.Text)
                Case "loan_period"
                    Return (Loan_sanction_frm.Period_instalment_LAB.Text)
                Case "customer_bankname"
                    Return Find_DT_Value(Database_File.cre, "TBL_Payroll_Employee", "Bank_Name", "Name = '" & Loan_sanction_frm.Name_LAB.Text & "'")
                Case "customer_bankbranch"
                    Return Find_DT_Value(Database_File.cre, "TBL_Payroll_Employee", "Bank_Branch", "Name = '" & Loan_sanction_frm.Name_LAB.Text & "'")
                Case "customer_bankifsc"
                    Return Find_DT_Value(Database_File.cre, "TBL_Payroll_Employee", "Bank_IFSC_code", "Name = '" & Loan_sanction_frm.Name_LAB.Text & "'")
                Case "customer_bankaccountno"
                    Return Find_DT_Value(Database_File.cre, "TBL_Payroll_Employee", "Bank_AccounNo", "Name = '" & Loan_sanction_frm.Name_LAB.Text & "'")


                Case "gu_id"
                    Return Find_DT_Value(Database_File.cre, "TBL_Payroll_Employee", "ID", "Name = '" & Loan_sanction_frm.gu_Name_TXT.Text & "'")
                Case "gu_name"
                    Return Loan_sanction_frm.gu_Name_TXT.Text
                Case "gu_aadhaar"
                    Return Find_DT_Value(Database_File.cre, "TBL_Payroll_Employee", "Aadhaar", "Name = '" & Loan_sanction_frm.gu_Name_TXT.Text & "'")
                Case "gu_pan"
                    Return Find_DT_Value(Database_File.cre, "TBL_Payroll_Employee", "PAN", "Name = '" & Loan_sanction_frm.gu_Name_TXT.Text & "'")
                Case "gu_phone"
                    Return Find_DT_Value(Database_File.cre, "TBL_Payroll_Employee", "Mobile1", "Name = '" & Loan_sanction_frm.gu_Name_TXT.Text & "'") & ", " & Find_DT_Value(Database_File.cre, "TBL_Payroll_Employee", "Mobile2", "Name = '" & Loan_sanction_frm.gu_Name_TXT.Text & "'")
                Case "gu_address"
                    Return Find_DT_Value(Database_File.cre, "TBL_Payroll_Employee", "Address", "Name = '" & Loan_sanction_frm.gu_Name_TXT.Text & "'")
                Case "loan_payble"
                    Return N2_FORMATE(Loan_sanction_frm.Label10.Text)
                Case "share_per"
                    Return N2_FORMATE(Loan_sanction_frm.share_per)
                Case "share_amt"
                    Return N2_FORMATE(Loan_sanction_frm.Label33.Text)
                Case "share_qry"
                    Return N2_FORMATE(Val(Loan_sanction_frm.Label33.Text) / Val((Loan_sanction_frm.share_prise)))
                Case "share_rate"
                    Return N2_FORMATE(Loan_sanction_frm.share_prise)
                Case "total_amt_txt"
                    Return NumberToText(Val(Loan_sanction_frm.Total_Payment_LAB.Text))
                Case "last_installment"
                    Return N2_FORMATE(Loan_sanction_frm.Last_instalment_LAB.Text)
                Case "Head_of_Department"
                    Return Loan_sanction_frm.Head_department_TXT.Text
                Case "Employee_Discription"
                    Return Find_DT_Value(Database_File.cre, "TBL_Payroll_Employee", "Discription", "Name = '" & Loan_sanction_frm.Name_LAB.Text & "'")
                Case "total_loan_txt"
                    Return NumberToText(Val(Loan_sanction_frm.LoanAmt_TXT.Text))
                Case "installment_amount_txt"
                    Return NumberToText(Val(Loan_sanction_frm.Month_Payment_LAB.Text))
                Case "Employee_City"
                    Return Find_DT_Value(Database_File.cre, "TBL_Payroll_Employee", "City", "Name = '" & Loan_sanction_frm.Name_LAB.Text & "'")
                Case "Employee_Taluka"
                    Return Find_DT_Value(Database_File.cre, "TBL_Payroll_Employee", "Taluka", "Name = '" & Loan_sanction_frm.Name_LAB.Text & "'")
                Case "Employee_dis"
                    Return Find_DT_Value(Database_File.cre, "TBL_Payroll_Employee", "Dis", "Name = '" & Loan_sanction_frm.Name_LAB.Text & "'")

            End Select
        End If
    End Function
    Public Function Loan_Statement(vlu As String)
        If vlu.ToString.Substring(0, 1) = "'" And vlu.ToString.Substring(vlu.Length - 1, 1) = "'" Then
            Return vlu.ToString.Substring(1, vlu.Length - 2)
        Else
            Select Case vlu
                Case "ID"
                    Return Loan_complit_installment_display.VC_ID_
                Case "Name"
                    Return Find_DT_Value(Database_File.cre, "TBL_Payroll_Employee", "Name", "ID = '" & Loan_complit_installment_display.VC_ID_ & "'")
                Case "Customer_Phone"
                    Return Find_DT_Value(Database_File.cre, "TBL_Payroll_Employee", "Mobile1", "ID = '" & Loan_complit_installment_display.VC_ID_ & "'") & ", " & Find_DT_Value(Database_File.cre, "TBL_Payroll_Employee", "Mobile2", "ID = '" & Loan_complit_installment_display.VC_ID_ & "'")
                Case "Email"
                    Return Find_DT_Value(Database_File.cre, "TBL_Payroll_Employee", "Email", "ID = '" & Loan_complit_installment_display.VC_ID_ & "'")
                Case "Address"
                    Return Find_DT_Value(Database_File.cre, "TBL_Payroll_Employee", "Address", "ID = '" & Loan_complit_installment_display.VC_ID_ & "'")
                Case "Aadhaar"
                    Return Find_DT_Value(Database_File.cre, "TBL_Payroll_Employee", "Aadhaar", "ID = '" & Loan_complit_installment_display.VC_ID_ & "'")
                Case "PANno"
                    Return Find_DT_Value(Database_File.cre, "TBL_Payroll_Employee", "PAN", "ID = '" & Loan_complit_installment_display.VC_ID_ & "'")
                Case "DOJ"
                    Return CDate(Find_DT_Value(Database_File.cre, "TBL_Payroll_Employee", "Date_of_joining", "ID = '" & Loan_complit_installment_display.VC_ID_ & "'")).ToString("dd-MM-yyyy")
                Case "Loan_ID"
                    Return Loan_complit_installment_display.ComboBox1.Text
            End Select
        End If
    End Function


End Module
