Imports System.Data.SqlClient
Imports System.Data.SQLite

Module Link_Find
    Public Link_Valu As String()
    Public Link_to_ As String()
    Public Link_to_frm As String()

    Public VC_Type As String
    Public VC_ID As String

    Declare Auto Function SetParent Lib "user32.dll" (ByVal hWndChild As IntPtr, ByVal hWndNewParent As IntPtr) As Integer
    Declare Auto Function SendMessage Lib "user32.dll" (ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    Private Const WM_SYSCOMMAND As Integer = 274
    Private Const SC_MAXIMIZE As Integer = 61488
    Dim proc As Process

    Public Function Cell(Frm As String, ParamArray Value() As String) As Form
        Link_Valu = Value
        Link_to_frm = {Frm}
        Dim Frm_New As Form

        Try
            If My.Computer.FileSystem.DirectoryExists(Frm) Then
                With Spacial_Report_Opning_frm
                    .path = Frm & "\Program.exe"
                    .Show()
                End With

                'proc = Process.Start(Frm & "\Program.exe", str)
                'Threading.Thread.Sleep(1000)

                'SetParent(proc.MainWindowHandle, BG_frm.BG_PAN.Handle)
                'SetParent(proc.MainWindowHandle, BG_Head_frm.Panel3.Handle)
                'SendMessage(proc.MainWindowHandle, WM_SYSCOMMAND, SC_MAXIMIZE, 0)
            Else
                If Frm = "main_manu" Then
                    Cell_Manu(Frm, Value(1))
                ElseIf Frm = "manu" Then
                    Main_Frm.Cell_Manu_Next(Value(1))
                Else
                    BG_frm.Show()
                    Frm_New = Form_Find_To_Link(Frm)
                    'BG_frm.Active_Contols.Add(Frm_New)
                    With Frm_New
                        .TopLevel = False
                        BG_frm.BG_PAN.Controls.Add(Frm_New)
                        .Dock = DockStyle.Fill
                        .Show()
                        .BringToFront()
                        .Focus()
                    End With

                    Return Frm_New
                End If
            End If

        Catch ex As Exception
            'Msg(NOT_Type.Erro, Frm, ex.Message)
        End Try
    End Function
    Public TXT_Focus_shortcut As Object
    Public Function sHortcut_open_frm(Frm As Form, Ob As Object, ParamArray Link() As String) As String
        TXT_Focus_shortcut = Ob
        With Frm
            Link_Valu = Link
            .TopLevel = False
            BG_frm.BG_PAN.Controls.Add(Frm)
            .Dock = DockStyle.Fill
            .BringToFront()
            .Focus()
            .Show()
        End With
        AddHandler Frm.Disposed, AddressOf Shortcut_frm_Disposed
    End Function
    Private Sub Shortcut_frm_Disposed(sender As Object, e As EventArgs)
        TXT_Focus_shortcut.Focus()
    End Sub
    Private Function Cell_Manu(frm As String, VC_Type As String)
        If Main_Frm.Visible = True Then
            Main_Frm.Filter_Word = VC_Type
        Else
            With Main_Frm
                .TopLevel = False
                BG_frm.BG_PAN.Controls.Add(Main_Frm)
                .Dock = DockStyle.Fill
                .Show()
                .BringToFront()
                .Filter_Word = VC_Type
            End With
        End If
    End Function
    Public Function Form_Find_To_Link(Srm_String) As Form
        If Company_Class_str = "Management" Then
            Return Form_Find_To_Link_Managment(Srm_String)
        ElseIf Company_Class_str = "Hospital" Then
            Return Form_Find_To_Link_Managment(Srm_String)
        Else
            Return Form_Find_To_Link_Defolt(Srm_String)
        End If
    End Function
    Public Function Form_Find_To_Link_Defolt(Srm_String) As Form
        Select Case Srm_String
            Case "main_manu"
                Return Main_Frm
            Case Application_Name
                Return Main_Frm
            Case "cmp_activ"
                Return Device_Activation_frm
            Case "Login"
                Return Login_Frm
            Case "Password Manager"
                Return Forgot_password_frm
            Case "Company Information"
                Return Company_Creation_frm
            Case "User Information"
                Return User_frm
            Case "Import Company"
                Return Device_Activation_frm
            Case "Select Company"
                Return Select_Company_frm
            Case "Company Select"
                Return Select_Company_frm
            Case "Forgot Company Serial"
                Return Find_Serial_frm
            Case "Backup Database"
                Return Backup_db_frm
            Case "Restore Database"
                Return Restore_db_frm
            Case "System Update"
                Return System_Update_Frm
            Case "Load Data"
                Return Fill_Data_Loading
            Case "Database Update"
                Return Database_repair_frm
            Case "Database Verification"
                Return Database_verification_frm
            Case "User Configuration"
                Return User_Raids_frm
            Case "User Info."
                Return User_List_frm
            Case "Not Access"
                Return Not_Access_frm
            Case "Create Database"
                Return Create_local_db_frm
            Case "Whatsapp"
                Return Whatsapp_Home

            Case "Load Box"
                'Return Load_Box


        End Select
    End Function
    Public Function Form_Find_To_Link_Managment(Srm_String) As Form
        Select Case Srm_String
            Case "main_manu"
                Return Main_Frm
            Case Application_Name
                Return Main_Frm
            Case "Company Select"
                Return Select_Company_frm
            Case "cmp_activ"
                Return Device_Activation_frm
            Case "Login"
                Return Login_Frm
            Case "Password Manager"
                Return Forgot_password_frm
            Case "Account Ledger"
                Return Ledger_frm
            Case "Account Group"
                Return Acc_Group_frm
            Case "Stock Unit"
                Return Unit_frm
            Case "Payroll Unit"
                Return Unit_frm
            Case "Printing"
                Return Printing_frm
            Case "Feedbank"
                Return FeedBank_frm
            Case "Company Fetchers"
                Return cmp_cfg_bg_frm

            Case "Stock Group"
                Return Stock_Group_frm
            Case "Payroll Group"
                Return Stock_Group_frm
            Case "Stock Category"
                Return Stock_Category_frm
            Case "Stock Godown"
                Return Godown_frm
            Case "Stock Item"
                Return Stock_Item_frm
            Case "Display List"
                Return Display_List
            Case "Payroll Employee"
                Return Payroll_Employee_frm
            Case "Payroll Attendance\Production Type"
                Return Payroll_Atten_Production_Type_frm
            Case "Payroll Pay Head"
                Return Payroll_Payhead_frm
            Case "Display List"
                Return Display_List
            Case "Accounting Voucher"
                Return Accounting_Voucher_frm
            Case "Inventory Voucher"
                Return Inventory_Vouchers_frm
            Case "Voucher Create"
                Return Voucher_Md_frm
            Case "Voucher BG"
                Return Voucher_BG_frm
            Case "Report Ledger"
                Return New Report_Ledger_frm
            Case "Report Ledger Monthly"
                Return New Report_Ledger_monthly_frm
            Case "Date"
                Return Date_frm
            Case "Salary Details"
                Return Payroll_Salary_details_frm
            Case "Company Information"
                Return Company_Creation_frm
            Case "User Information"
                Return User_frm
            Case "Device Activation"
                Return Device_Activation_frm
            Case "Select Company"
                Return Select_Company_frm
            Case "Attage cre"
                Return Attage_cre_frm
            Case "Day Book"
                Return Day_Book_frm
            Case "Group Summary"
                Return New Report_Group_Summary_frm
            Case "Inventory Register"
                Return Inventory_Register_frm
            Case "Accounting Register"
                Return Accounting_Registers_frm
            Case "Vouchers Register Summary"
                Return Registers_Summary_Frm
            Case "Stock Item Vouchers"
                Return Report_Stock_item_frm
            Case "Stock Item Monthly"
                Return Report_Stock_item_monthly_frm
            Case "Group Stock Summary"
                Return Stock_Group_Summary_frm
            Case "Group Stock Summary (Godown)"
                Return Stock_Group_Summary_frm
            Case "Forgot Company Serial"
                Return Find_Serial_frm
            Case "Stock Summary"
                Return Report_Stock_Summary_frm
            Case "Backup Database"
                Return Backup_db_frm
            Case "Communication Configuration"
                Return Communication_frm
            Case "Restore Database"
                Return Restore_db_frm
            Case "System Update"
                Return System_Update_Frm
            Case "Audit Analysis"
                Return Audit_Analysis
            Case "Configuration"
                Return cfg_Head_Form
            Case "Profit & Loss Account"
                Return Profit_Loss_frm
            Case "Balance Sheet"
                Return Balance_Sheet_frm
            Case "GSTR1"
                Return gstr1_frm
            Case "GSTR1 Summary"
                Return GSTR1_Ledger_Summary
            Case "GSTR1 Voucher Register"
                Return GSTR1_Ledger_Vouchers

            Case "Select Voucher"
                Return Voucher_Select
            Case "Inventory Voucher Export Details"
                Return vc_export_frm


            Case "Attendance Sheet"
                Return Attendance_sheet_frm
            Case "Payslip"
                Return Payshlip_display_frm
            Case "Pay Sheet"
                Return Paysheet_frm
            Case "Payroll Sheet"
                Return Payroll_Sheett
            Case "Payroll Group Summary"
                Return Employee_Group_Summary
            Case "Payroll Employee Summary"
                Return Payroll_Employee_Summary
            Case "Payroll Monthly Summary"
                Return Payroll_Monthly_Summary
            Case "Search Manu"
                Return Search_Manu_frm
            Case "Payroll Vouchers"
                Return Payroll_Vouchers
            Case "Payroll Statement"
                Return Payroll_Statement_frm

            Case "HSN/SAC Summary"
                Return HSN_Summary_frm
            Case "Vouchers Count"
                Return vouchers_count_frm
            Case "GSTR2"
                Return GSTR2_frm
            Case "Uncertain Transactions"
                Return gstr1_Uncertain__frm
            Case "Uncertain Vouchers"
                Return GSTR_Update_vouchers_frm
            Case "Bill-Wise Details"
                Return Bill_wise_details_frm
            Case "Included in Return"
                Return Included_in_return_frm
            Case "Not relevant in the Return"
                Return Included_in_return_frm
            Case "GSTR Vouchers Register"
                Return gstr_vouchers_registers_frm
            Case "Dealer\Party Vouchers"
                Return dealer_party_vouchers
            Case "Dealer/Party Vouchers Summary"
                Return dealer_party_vouchers_details
            Case "Load Data"
                Return Fill_Data_Loading
            Case "EwayBill"
                Return EwayBill_frm
            Case "Transport"
                Return Transport_create_frm
            Case "Vouchers Transport"
                Return vc_Transport
            Case "Vouchers Order Details"
                Return vc_Order_Details_frm
            Case "VC Ledger Details"
                Return VC_Account_Details
            Case "VC Supplier Details"
                Return vc_Supplier_details_frm
            Case "Vouchers Configuration"
                Return Voucher_cfg
            Case "Attach Display"
                Return attage_display
            Case "Salary Details Type"
                Return Salary_details_type
            Case "Loan Sanction"
                Return Loan_sanction_frm
            Case "Company Features"
                Return cmp_cfg_bg_frm
            Case "Loan Sanctioned Display"
                Return Loan_section_Display
            Case "Loan Installation Report"
                Return Loan_complit_installment_display
            Case "List of Outstanding Loan"
                Return Loan_Last_Installment__Report
            Case "Database Update"
                Return Database_repair_frm
            Case "Inventory Item Batch"
                Return Inventory_BOM
            Case "GST Search"
                Return GST_Chack_frm
            Case "Accounting Ledger (Multi Branch Manager)"
                Return Ledger_Branch_Balance
            Case "Stock Item (Multi Branch Manager)"
                Return Stock_Item_Branch_Stock
            Case "Merge Voucher"
                Return vc_marge_frm
            Case "Item Allocations"
                Return vc_item_other_details_frm
            Case "Direct Print"
                Return Printing_Direct_frm
            Case "Email Login"
                Return Email_Login_frm
            Case "Whatsapp Setup"
                Return Whatsapp_setup
            Case "User Configuration"
                Return User_Raids_frm
            Case "User Info."
                Return User_List_frm
            Case "Not Access"
                Return Not_Access_frm
            Case "Create Database"
                Return Create_local_db_frm
            Case "Filter"
                Return Filter_frm
            Case "Search Vouchers"
                Return Search_Vouchers_frm
            Case "Account Ledger Import"
                Return import_data_ledger
            Case "Payroll Auto Fill"
                Return Payroll_Auto_Fill_Dialoag
            Case "Payroll Voucher"
                Return Payroll_Vouchers_frm
            Case "PaySlip Summary"
                Return PaySlip_Summary_frm
            Case "Attendance Vouchers"
                Return Attendance_Vouchers_frm
            Case "Stock Item Import"
                Return import_data_items
            Case "Reorder Stock Report"
                Return Reorder_Quantity_Report
            Case "Payable Report"
                Return Report_Payable_Receivable
            Case "Receivable Report"
                Return Report_Payable_Receivable
            Case "Payable Receivable Report"
                Return Report_Payable_Receivable
            Case "CHEQUE"
                Return CHEQUE_frm
            Case "Cheque Configuration"
                Return Cheque_Set_frm
            Case "Cheque Print"
                Return vc_CHEQUE_Print_frm
            Case "Database Verification"
                Return Database_verification_frm
            Case "Whatsapp"
                Return Whatsapp_Home
            Case "WhatsApp Templates"
                Return WhatsApp_Template_frm
            Case "Voucher Type Class"
                Return sp_vouchers_type_class_frm


        End Select
    End Function
    Public Function Form_Find_To_Link_Laboratry(Srm_String) As Form
        Select Case Srm_String
            Case "main_manu"
                Return Main_Frm
            Case Application_Name
                Return Main_Frm
            Case "Load Data"
                Return Fill_Data_Loading


            Case "Login"
                Return Login_Frm
            Case "Doctor Info"
                Return Doctor_info_Laboratory
            Case "Unit Info"
                Return Unit_info_Laboratory
            Case "Item Info"
                Return Item_info_Laboratory
            Case "Group Laboratory"
                Return Group_info_Laboratry
            Case "Laboratry Vouchers"
                Return Vouchers_Laboratry_frm
        End Select
    End Function

    Public Function bIndingsource_fInd(Srm_String) As BindingSource
        'Select Case Srm_String
        '    Case "Ledger_BS"
        '        Return BG_frm.Ledger_BS

        '    Case "Acc_Group_BS"
        '        Return BG_frm.Acc_Group_BS

        '    Case "UQC_BS"
        '        Return BG_frm.UQC_BS

        '    Case "Set_Manu_BS"
        '        Return BG_frm.Set_Manu_BS

        '    Case "HSN_BindingSource"
        '        Return BG_frm.HSN_BindingSource

        '    Case "Address_BS"
        '        Return BG_frm.Address_BS

        '    Case "TAX_BS"
        '        Return BG_frm.TAX_BS

        '    Case "Stock_Group_BS"
        '        Return BG_frm.Stock_Group_BS

        '    Case "Stock_Category_BS"
        '        Return BG_frm.Stock_Category_BS

        '    Case "Godown_BS"
        '        Return BG_frm.Godown_BS

        '    Case "Stock_Item_BS"
        '        Return BG_frm.Stock_Item_BS

        '    Case "Payroll_Group_BS"
        '        Return BG_frm.Payroll_Group_BS

        '    Case "Payroll_Employee_BS"
        '        Return BG_frm.Payroll_Employee_BS
        '    Case "Payroll_Att_Production_Type_BS"
        '        Return BG_frm.Payroll_Att_Production_Type_BS

        '    Case "Payroll_Payhead_BS"
        '        Return BG_frm.Payroll_Payhead_BS
        '    Case "Voucher_BS"
        '        Return BG_frm.Voucher_BS
        '    Case "Voucher_Create"
        '        Return BG_frm.Voucher_Create_BS
        '    Case "Voucher_Data_BS"
        '        Return BG_frm.Voucher_Data_BS
        '    Case "Stock_Godown"
        '        Return BG_frm.Godown_BS
        '    Case "All_Unit_BS"
        '        Return BG_frm.All_Unit_BS
        '    Case "Transport_BS"
        '        Return BG_frm.Transport_BS
        '    Case Else
        '        Return Nothing
        'End Select
    End Function

    Public Enum VC_Type_List
        Create
        Display
        Alter
        Create_Close
        Display_Close
        Alter_Close
    End Enum
    Public Function Chack_Duplicate(DataBase_File As Database_File, TBL_Name As String, Coluam As String, Find_String As String) As Boolean
        'Find_String = Find_String.Replace("'", """")

        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(DataBase_File, cn) = True Then
            cmd_2 = New SQLiteCommand("Select * From " & TBL_Name & " where " & Find_String, cn)

            Dim r As SQLiteDataReader
            r = cmd_2.ExecuteReader
            While r.Read
                r.Close()
                cn.Close()
                Return True
            End While
            r.Close()
            cn.Close()
            Return False
        End If
    End Function
    Public Function Chack_Duplicate_unit_copund(Id As String, Name As String) As Boolean
        If open_MSSQL(Database_File.cre) Then
            cmd = New SQLiteCommand("Select * From TBL_Inventory_Unit where ID = '" & Id & "'", con)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                If Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "Symbol", "ID = '" & r("Unit1") & "'") & " of " & r("Conversion") & " " & Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "Symbol", "ID = '" & r("Unit2") & "'") = Name.ToString Then
                    r.Close()
                    con.Close()
                                        Return True
                End If
            End While
            Return False
        End If
    End Function
    Public Function Convert_Unit_Compund_Value(Id As String, Valu As Decimal, Typ As String) As Decimal

        Dim Type_ As String = Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "Type", "ID = '" & Id & "'")
        Dim Frist_ As String = Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "Unit1", "ID = '" & Id & "'")
        Dim Confersio_ As String = Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "Conversion", "ID = '" & Id & "'")
        Dim Last_ As String = Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "Unit2", "ID = '" & Id & "'")

        If Type_ <> "Simple" Then
            If Typ = "1-2" Then
                Return Format(Val(Valu * Val(Confersio_)), "0.00")
            ElseIf Typ = "2-1" Then
                Return Format(Val(Valu / Val(Confersio_)), "0.00")
            End If
        Else

        End If
    End Function
    Public Function Find_DT_Value_SUM(DataBase_File As Database_File, TBL_Name As String, Coluam As String, Filter As String) As String
        If open_MSSQL_2(DataBase_File) = True Then
            cmd_2 = New SQLiteCommand("Select ifnull(SUM(" & Coluam & "),0) as Vlu From " & TBL_Name & " where " & Filter, con_2)

            Dim r As SQLiteDataReader
            r = cmd_2.ExecuteReader
            While r.Read
                Dim vlu As String = r("Vlu").ToString
                r.Close()
                con_2.Close()
                Return vlu
            End While
            r.Close()
            Return ""
        End If
    End Function

    Public Function Find_DT_Value(DataBase_File As Database_File, TBL_Name As String, Coluam As String, Filter As String) As String
        If open_MSSQL_2(DataBase_File) = True Then
            cmd_2 = New SQLiteCommand("Select * From [" & TBL_Name & "] where " & Filter & "", con_2)
            Dim r As SQLiteDataReader
            r = cmd_2.ExecuteReader
            While r.Read
                Dim vlu As String = r(Coluam).ToString
                r.Close()
                con_2.Close()
                Return vlu
            End While
            r.Close()
            Return ""
        End If
    End Function
    Public Function Find_Features(Type_ As Features_Type, Head_ As Features_Head, Coluam As String) As String
        If Type_ = 0 Then
            open_MSSQL_2(Database_File.cfgs)
        Else
            open_MSSQL_2(Database_File.cmp)
        End If


        cmd_2 = New SQLiteCommand($"Select * From TBL_Features where Head = '{Coluam}' and Type = '{Head_.ToString}'", con_2)
        Dim r As SQLiteDataReader
        r = cmd_2.ExecuteReader
        While r.Read
            Dim vlu As String = r("Value").ToString
            r.Close()
            con_2.Close()
            Return vlu
        End While
        r.Close()
        Return ""
    End Function
    Public Enum Features_Type
        All_Company = 0
        Selected_Company = 1
    End Enum
    Public Enum Features_Head
        General = 0
        Account = 1
        Inventory = 2
        Payroll = 3
    End Enum
    Public Function Find_alter_unit_vlu(id As String, qty As Decimal, main_Unit As Boolean, only_vlu As Boolean, set_decimal As Boolean) As String
        Dim unit1 As String = Find_DT_Value(Database_File.cre, "TBL_Stock_Item", "Unit", "ID = '" & id & "'")
        Dim unit1_dec As String = Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "Decimal", "ID = '" & unit1 & "'")

        Dim unit2 As String = Find_DT_Value(Database_File.cre, "TBL_Stock_Item", "Alter_Unit", "ID = '" & id & "'")
        Dim unit2_dec As String = Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "Decimal", "ID = '" & unit2 & "'")

        Dim unit1_vlu As String = Find_DT_Value(Database_File.cre, "TBL_Stock_Item", "Alter_Unit_val1", "ID = '" & id & "'")
        Dim unit2_vlu As String = Find_DT_Value(Database_File.cre, "TBL_Stock_Item", "Alter_Unit_val2", "ID = '" & id & "'")


        Dim U As String = ""

        If main_Unit = True Then

            If only_vlu = False Then
                U = " " & Find_DT_Unit_Conves(unit1)
            End If

            If unit2 <> "0" Then
                If set_decimal = True Then
                    Return Value_Decimal_set(Val(Val(unit1_vlu) / Val(unit2_vlu) * Val(qty)), unit1_dec) & U
                Else
                    Return (Val(Val(unit1_vlu) / Val(unit2_vlu) * Val(qty))) & U
                End If
            Else
                Return ""
            End If
        Else
            If only_vlu = False Then
                U = " " & Find_DT_Unit_Conves(unit2)
            End If

            If unit2 <> "0" Then
                If set_decimal = True Then
                    If Val(unit2_vlu) <> 0 Then
                        Return Value_Decimal_set(Val(Val(unit2_vlu) / Val(unit1_vlu) * Val(qty)), unit2_dec) & U
                    End If
                Else
                    Return (Val(Val(unit2_vlu) / Val(unit1_vlu) * Val(qty))) & U
                End If
            Else
                Return ""
            End If
        End If
    End Function
    Public Function Find_DT_Unit_Conves(Id As String) As String
        If open_MSSQL_2(Database_File.cre) And Id.Trim <> Nothing Then
            Dim Type_ As String = Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "Type", "ID = '" & Id & "'")
            Dim Frist_ As String = Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "Unit1", "ID = '" & Id & "'")
            Dim Confersio_ As String = Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "Conversion", "ID = '" & Id & "'")
            Dim Last_ As String = Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "Unit2", "ID = '" & Id & "'")

            If Type_ = "Simple" Then
                Dim vlu As String = Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "Symbol", "ID = '" & Id & "'")


                Return vlu
            ElseIf Type_ = "Compound" Then
                Return Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "Symbol", "ID = '" & Frist_ & "'") & " of " & Confersio_ & " " & Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "Symbol", "ID = '" & Last_ & "'")
            Else
                Return "(Not Applicable)"
            End If
        Else
            Return ""
        End If
    End Function
    Public Function Find_MAX_VLU(Database_File As Database_File, TBL As String, Col As String) As String
        If open_MSSQL_2(Database_File) = True Then
            cmd_2 = New SQLiteCommand("SELECT MAX(" & Col & ") as " & Col & " FROM " & TBL & "", con_2)
            Dim r As SQLiteDataReader
            r = cmd_2.ExecuteReader
            r.Read()
            Dim vl As Decimal
            Try
                vl = Val(r(Col))
            Catch ex As Exception
                vl = "1"
            End Try
            r.Close()
            con_2.Close()
            Return Val(vl) + 1
        End If
    End Function
    Public Function Other_details_Fill(Source As BindingSource, Head As String)
        Dim M As New Other_details_Fill_frm
        With M
            .TopLevel = False
            BG_frm.BG_PAN.Controls.Add(M)
            .Dock = DockStyle.Fill
            .BringToFront()
            .Show()
            .Focus()
            .Bs = Source
            .sou_bs = Source
            .Grid_.DataSource = .Bs
            .BG_HADE_TXT.Text = Head
        End With
    End Function
    Public Function Frm_foCus()
        Dim result As String = BG_frm.BG_Path_TXT.Text.Split("->").Last
        Form_Find_To_Link(result.Substring(1, result.Length - 1)).Focus()

        NOT_Clear()
    End Function
    Public Function Find_Max_ID(DataBase_File As Database_File, TBL_Name As String, Coluam As String, Filter As String) As Integer
        Dim St As Integer = 0
        If open_MSSQL_2(DataBase_File) = True Then
            cmd_2 = New SQLiteCommand("Select * From " & TBL_Name & " where " & Filter & " Order By " & Coluam & " DESC LIMIT 1;", con_2)
            Dim r As SQLiteDataReader
            r = cmd_2.ExecuteReader
            While r.Read
                Dim vlu As String = Val(r(Coluam))
                St = vlu
            End While
            r.Close()
            con_2.Close()
            r.Close()
            Return St
        End If
    End Function

    Public Function Branch_Balance(ID_ As String, Date_ As Date, Noetect_Tra_ID As String) As Decimal
        Dim Date_Filter As String = $" and (vc.[Date] <= '{CDate(Date_).AddDays(1).ToString(Lite_date_Format)}')"

        Dim cn As New SQLiteConnection
        Dim r As SQLiteDataReader
        Dim Vlu As Decimal = 0.00

        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select (Select ifnull(sum(lob.OB_Cr),0)-ifnull(sum(lob.OB_Dr),0) From TBL_Ledger_Opning_Balance lob where lob.Ledger_ID = '{ID_}')+((ifnull(SUM(Cr),0)) - ifnull(SUM(Dr),0)) as vlu From (
Select ld.ID,ld.name,ld.OB_CR,ld.OB_DR,
(Select ifnull(SUM(vc.Debit_Amount),0) From TBL_VC vc 
where vc.Branch = ld.id and
vc.Visible = 'Approval' and vc.Effect_Ledger = 'Yes'{Date_Filter} and (vc.Tra_ID <> '{Noetect_Tra_ID}')) as Dr,
(Select ifnull(SUM(vc.Credit_Amount),0) From TBL_VC vc 
where vc.Branch = ld.id and
vc.Visible = 'Approval' and vc.Effect_Ledger = 'Yes'{Date_Filter} and (vc.Tra_ID <> '{Noetect_Tra_ID}')) as Cr

From TBL_Ledger ld where ld.[ID] = '{ID_}' and ld.Visible = 'Approval')", cn)

            r = cmd.ExecuteReader
            While r.Read
                Vlu = Val(r("vlu"))
            End While
            r.Close()
        End If
        cn.Close()

        Return nUmBeR_FORMATE(Vlu)
    End Function
    Public Function Ledger_Balance(ID_ As String, Date_ As Date, Noetect_Tra_ID As String, Branch_ID As Integer) As Decimal

        Dim Date_Filter As String = $" and (vl.[Date] <= '{CDate(Date_).AddDays(1).ToString(Lite_date_Format)}')"


        Dim cn As New SQLiteConnection
        Dim r As SQLiteDataReader
        Dim Vlu As Decimal = 0.00

        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then

            cmd = New SQLiteCommand($"Select ifnull((Select ifnull(SUM(vl.Cr),0)-ifnull(SUM(vl.Dr),0) From TBL_VC_Ledger vl where vl.Ledger = l.ID and vl.Tra_ID <> '{Noetect_Tra_ID}' {Date_Filter}),0)+(ifnull((l.OB_CR),0)-ifnull((l.OB_DR),0)) as Vlu
From TBL_Ledger L
Where L.ID = '{ID_}'", cn)


            r = cmd.ExecuteReader
            ' My.Computer.Clipboard.SetText(cmd.CommandText)
            While r.Read
                Vlu = Val(r("vlu").ToString)
            End While
            r.Close()
        End If
        cn.Close()

        Return nUmBeR_FORMATE(Vlu)
    End Function
    Public Function LD_Credit(ID_ As String, Date_ As Date, Branch_ As String) As Decimal
        Dim cn As New SQLiteConnection
        Dim r As SQLiteDataReader
        Dim Vlu As Decimal = 0.00

        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand("Select [ID],[Name],[Group],(LD.Cradit) - 
(((((Select ifnull(SUM(VC.Cr),0.00)
From TBL_VC VC
Where (((((VC.CR_DR = 'Head' and VC.Account = LD.Id) or (VC.CR_DR = 'Exp' and VC.Particuls = LD.Id)) or (VC.Particuls = LD.Id and vC.CR_DR = 'Under')) and VC.Visible = 'Approval') and ((VC.Voucher_Type = 'Contra') or (VC.Voucher_Type = 'Payment' or VC.Voucher_Type = 'Credit Note') or (VC.Voucher_Type = 'Receipt' or VC.Voucher_Type = 'Debit Note') or (VC.Voucher_Type = 'Journal') or (VC.CR_DR = 'Exp'))) and (([Date] < @Filter_Date)))) -

((Select ifnull(SUM(VC.Dr),0.00)
From TBL_VC VC
Where (((((VC.CR_DR = 'Head' and VC.Account = LD.Id) or (VC.CR_DR = 'Exp' and VC.Particuls = LD.Id)) or (VC.Particuls = LD.Id and vC.CR_DR = 'Under')) and VC.Visible = 'Approval') and ((VC.Voucher_Type = 'Contra') or (VC.Voucher_Type = 'Payment' or VC.Voucher_Type = 'Credit Note') or (VC.Voucher_Type = 'Receipt' or VC.Voucher_Type = 'Debit Note') or (VC.Voucher_Type = 'Journal') or (VC.CR_DR = 'Exp'))) and (([Date] < @Filter_Date))))) + 

(((Select ifnull(SUM(VC.Cr),0.00)
From TBL_VC VC
Where (VC.Account = LD.Id and VC.CR_DR = 'Head') and (VC.Voucher_Type = 'Purchase' or VC.Voucher_Type = 'Sales Return') and (([Date] < @Filter_Date)))) -

((Select ifnull(SUM(VC.Dr),0.00)
From TBL_VC VC
Where (VC.Account = LD.Id and VC.CR_DR = 'Head') and (VC.Voucher_Type = 'Sales' or VC.Voucher_Type = 'Purchase Return') and (([Date] < @Filter_Date))))) + ((LD.OB_CR) - (LD.OB_DR))) * -1) as Value_

from TBL_Ledger LD

Where LD.Id = @ID_", cn)

            With cmd.Parameters
                .AddWithValue("@Filter_Date", Date_.ToString(Lite_date_Format))
                .AddWithValue("@Branch", Branch_.ToString.Trim)
                .AddWithValue("@ID_", ID_)
                r = cmd.ExecuteReader
                While r.Read
                    Vlu += Val(r("Value_").ToString)
                End While
                r.Close()
                cn.Close()
            End With
        End If
        Return Vlu
    End Function
    Public Function Item_Stock(ID As Integer, Unit_ As Integer, To_Dt As String, No_Tra_ID As String) As Decimal
        Dim Valu As Decimal = 0.00
        Dim To_Date As String = To_Dt
        Dim conn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, conn) Then
            cmd = New SQLiteCommand($"Select 
ifnull(
(SELECT CASE
WHEN '{Unit_}' = vi.Unit1 THEN SUM(Qty1)
WHEN '{Unit_}' = vi.Unit2 THEN SUM(Qty2)
ELSE SUM(Qty)
END as Qty
From TBL_VC_item_Details vi
where vi.Item = it.Id and (vi.[Date] <= '{CDate(To_Dt).AddDays(1).ToString(Lite_date_Format)}') and vi.Tra_ID <> '{No_Tra_ID}' and vi.Type = 'Credit'),0)-
ifnull(
(SELECT CASE
WHEN '{Unit_}' = vi.Unit1 THEN SUM(Qty1)
WHEN '{Unit_}' = vi.Unit2 THEN SUM(Qty2)
ELSE SUM(Qty)
END as Qty
From TBL_VC_item_Details vi
where vi.Item = it.Id and (vi.[Date] <= '{CDate(To_Dt).AddDays(1).ToString(Lite_date_Format)}') and vi.Tra_ID <> '{No_Tra_ID}' and vi.Type = 'Debit'),0) + ifnull(it.Ob_Quantity,0) as Qty
From TBL_Stock_Item it WHERE it.id = '{ID}' and it.Visible = 'Approval'

", conn)
            Dim r As SQLiteDataReader
            My.Computer.Clipboard.SetText(cmd.CommandText)
            r = cmd.ExecuteReader
            While r.Read
                Valu = nUmBeR_FORMATE(r("Qty"))
            End While
            r.Close()
            conn.Close()
        End If
        Return nUmBeR_FORMATE(Valu)
    End Function
    Public Function Find_STD_Rate(ID As String, date_ As Date, typ As STD_RATE_Typ) As Decimal
        Try
            Dim vl As Decimal
            Dim cn As New SQLiteConnection
            If typ.ToString = "Cost" Then
                If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                    cmd = New SQLiteCommand("select (SELECT r.Rate FROM TBL_Item_Rate r WHERE r.Item = @IDT AND r.Type = 'Cost' AND [Date] <= @Frm_Date ORDER BY [Date] DESC limit 1) as Value_", cn)
                    Dim r As SQLiteDataReader
                    With cmd.Parameters
                        .AddWithValue("@IDT", ID)
                        .AddWithValue("@Frm_Date", date_.ToString(Lite_date_Format))
                        r = cmd.ExecuteReader
                        While r.Read
                            vl = Val(r("Value_").ToString)
                        End While
                        r.Close()
                        cn.Close()
                    End With
                End If
            Else
                If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                    cmd = New SQLiteCommand($"select (SELECT r.Rate FROM TBL_Item_Rate r WHERE r.Item = '{ID}' AND r.Type = 'Price' AND [Date] <= '{date_.ToString(Lite_date_Format)}' ORDER BY [Date] DESC limit 1) as Value_", cn)

                    Dim r As SQLiteDataReader
                    'My.Computer.Clipboard.SetText(cmd.CommandText)
                    With cmd.Parameters
                        r = cmd.ExecuteReader
                        While r.Read
                            vl = Val(r("Value_").ToString)
                        End While
                        r.Close()
                        cn.Close()
                    End With
                End If
            End If
            Return vl
        Catch ex As Exception
            Return 0.00
        End Try

    End Function
    Public Enum STD_RATE_Typ
        Cost
        Sales
    End Enum
    Public Function Grid_Auto_size(Grid As DataGridView, Other_Size As Integer)
        If Val(Grid.Rows.Count) > 0 Then
            Grid.Height = (Val(Grid.Rows.Count) * Val(Grid.Rows(0).Height)) + Other_Size + 3
        Else
            Grid.Height = Other_Size
        End If
    End Function
    Public Function String_Part_(st As String, Symbol As String) As String()
        Dim Output As String()
        Try
            Output = st.Split(New String() {Symbol}, StringSplitOptions.None)
            Return Output
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Public Function Under_Group_Find__(ID As String) As String()
        Dim St As String()
        If open_MSSQL(Database_File.cre) Then
            cmd = New SQLiteCommand("Select * From TBL_Acc_Group where ID = '" & ID & "'", con)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                'TOP Most Under Supplied
                For i As Integer = 1 To 16
                    If ID = i Then
                        St = New String() {r("ID")}
                        r.Close()
                        con.Close()
                        Return St
                    End If
                Next

                For i As Integer = 17 To 29
                    If ID = i Then
                        St = New String() {r("UserGroup")}
                        r.Close()
                        con.Close()
                        Return St
                    End If
                Next

                Dim Under As String = r("UserGroup")
                Return Sub_Under_Find1(Under)
            End While
        End If
    End Function
    Private Function Sub_Under_Find1(Under As String) As String()
        Dim St As String()
        Dim TO_Group As Integer = 10

        Dim Under1 As String = Under

        For i As Integer = 0 To 10
            If Sub_Under_Find(Under1).Length > 0 Then
                St = New String() {Sub_Under_Find(Under1).Last}
                Return St
                Exit For
                Exit Function
            Else
                St = New String() {Under1}
                Under1 = Find_DT_Value(Database_File.cre, "TBL_Acc_Group", "UserGroup", "ID = '" & Under1 & "'")
            End If
        Next

        Return St
    End Function
    Private Function Sub_Under_Find(Under As String) As String()
        If Under = ("1" Or "2" Or "3" Or "4" Or "5" Or "6" Or "7" Or "8" Or "9" Or "10" Or "11" Or "12" Or "13" Or "14" Or "15" Or "16") Then
            Return {Under}
        ElseIf Under = ("17" Or "18" Or "19" Or "20" Or "21" Or "22" Or "23" Or "24" Or "25" Or "26" Or "27" Or "28" Or "29") Then
            Return {Under, Find_DT_Value(Database_File.cre, "TBL_Acc_Group", "UserGroup", "ID = '" & Under & "")}
        Else
            Return {}
        End If
    End Function
    Public Function Attendance_Balance(Ac As String, Att As String, D1 As Date, D2 As Date, no_cal_tra_id As Integer) As String()
        Dim Vlu As Decimal = 0.00
        If open_MSSQL(Database_File.cre) Then
            qury = "Select * From TBL_Attendance_VC where Account = '" & Ac & "' and Particuls = '" & Att & "' and Date BETWEEN '" & D1.ToString("MM-dd-yyyy") & "' and '" & D2.ToString("MM-dd-yyyy") & "' and Tra_ID <> '" & no_cal_tra_id & "' and Visible = 'Approval'"
            cmd = New SQLiteCommand(qury, con)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                Vlu += Val(r("Value"))
            End While
            r.Close()
        End If

        Dim unit As String
        If Find_DT_Value(Database_File.cre, "TBL_Payroll_Att_Production_Type", "Attendance_Type", "ID = '" & Att & "'") = "Production" Then
            Dim unit1 As String = Find_DT_Value(Database_File.cre, "TBL_Payroll_Att_Production_Type", "Unit", "ID = '" & Att & "'")
            unit = Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "Symbol", "ID = '" & unit1 & "'")
        Else
            unit = "Day"
        End If
        con.Close()

        Return {nUmBeR_FORMATE(Vlu), unit}
    End Function
    Public Function Payroll_Balance(Ac As String, Pyhd As String, D1 As Date, D2 As Date, no_cal_tra_id As Integer) As Decimal
        Dim Vlu As Decimal = 0.00
        Dim amt As Decimal = 0.00
        Dim cr As Decimal
        Dim Dr As Decimal

        Dim typ_ As String = Find_DT_Value(Database_File.cre, "TBL_PayHead", "Payhead_Type", "ID = '" & Pyhd & "'")
        Dim cal_type As String = Find_DT_Value(Database_File.cre, "TBL_PayHead", "Cal_Type", "ID = '" & Pyhd & "'")
        Dim cal_ As String = Find_DT_Value(Database_File.cre, "TBL_PayHead", "Cal", "ID = '" & Pyhd & "'")
        Dim ans As Decimal = 0

        If cal_type = "On Attendance" Or cal_type = "On Production" Then
            ans = On_Attendance_On_Production(Ac, Pyhd, D1, D2, no_cal_tra_id)
        ElseIf cal_type = "Flat Rate" Then
            'ans = Flat_Rate_cal(Ac, Pyhd, D1, D2, no_cal_tra_id)
        ElseIf cal_type = "As Computed Value" Then
            'ans = ""
        End If

        If typ_ = "Earnings for Employees" Then

        ElseIf typ_ = "Deductions From Employees" Or typ_ = "Loans and Advances" Then
            ans *= Val(-1)
        End If
        Return Format(Val(ans), "0.00")
    End Function
    Public Function Payroll_Bal(emp As String, phd As String, loan_id As String, d1 As Date, d2 As Date, No_read_tra_id As String) As Decimal
        Dim vlu As String
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            If Find_DT_Value(Database_File.cre, "TBL_Payhead", "Name", "ID = '" & phd & "'") <> "Loan & Advance A/c" Then
                cmd = New SQLiteCommand("Select att.Account as Employee_ID,(select e.[Name] from TBL_Payroll_Employee e where e.id = att.Account) as Employee_Name,att.Payhead,(select p.[Name] from TBL_Payhead p where p.id = att.Payhead) as Payhead_Name,ifnull(SUM(att.Balance),0.00) as TBL_Attendance,
((Select ifnull(SUM(VC.Dr),0.00) From TBL_VC vc where vc.Particuls = att.Account and vc.Payhead = att.Payhead and vc.Visible = 'Approval' and vc.Auto_Entry = 'False' and (vc.Date BETWEEN '" & d1.ToString("MM-dd-yyyy") & "' AND '" & d2.ToString("MM-dd-yyyy") & "') and vc.Tra_ID <> '" & No_read_tra_id & "')) - 
((Select ifnull(SUM(VC.Cr),0.00) From TBL_VC vc where vc.Particuls = att.Account and vc.Payhead = att.Payhead and vc.Visible = 'Approval' and vc.Auto_Entry = 'False' and (vc.Date BETWEEN '" & d1.ToString("MM-dd-yyyy") & "' AND '" & d2.ToString("MM-dd-yyyy") & "') and vc.Tra_ID <> '" & No_read_tra_id & "')) as TBL_VC
From TBL_Attendance_VC att

where att.Visible = 'Approval' and att.Account = '" & emp & "' and att.Payhead = '" & phd & "' and (Date BETWEEN '" & d1.ToString("MM-dd-yyyy") & "' AND '" & d2.ToString("MM-dd-yyyy") & "') and (att.Tra_ID <> '" & No_read_tra_id & "' or att.Voucher_Type <> 'Payroll')

Group By att.Payhead,att.Account
order By att.Account", cn)

                Dim r As SQLiteDataReader
                r = cmd.ExecuteReader
                While r.Read
                    vlu = Val(vlu) + (Val(r("TBL_Attendance")) - Val(r("TBL_VC")))
                End While
                r.Close()
                cn.Close()
            Else
                If loan_id.Trim <> Nothing Then

                    cmd = New SQLiteCommand("Select TOP 1 ls.Closing,
DATEDIFF(DAY,ls.[To],'" & d2.ToString("MM-dd-yyyy") & "') as Diff,
(Select l.Interest_Rate from TBL_Loan_sanction l where id = ls.Loan_ID) as Rate
From TBL_Loan_Installments ls
where ls.Employee_ID = '" & emp & "' and ls.Loan_ID = '" & loan_id & "' 
order by ls.[To] DESC", cn)

                    Dim rate_ As String
                    Dim diff_ As Integer

                    Dim r As SQLiteDataReader
                    r = cmd.ExecuteReader
                    While r.Read
                        vlu = Val(r("Closing"))
                        rate_ = Val(r("Rate"))
                        diff_ = Val(r("Diff"))
                    End While
                    r.Close()
                    cn.Close()

                    If diff_ > 0 Then
                        vlu = vlu + Closing_to_intest_cal(nUmBeR_FORMATE(rate_), nUmBeR_FORMATE(vlu), Val(diff_))

                        vlu = Val(vlu) * -1
                    End If
                End If
            End If
        End If

        Return Val(vlu)
    End Function
    Public Function Closing_to_intest_cal(intrest As Decimal, Closing As Decimal, Diff_ As Integer) As Decimal
        Return nUmBeR_FORMATE(((Val(Val(Val(intrest) / 12) / 30) * Val(Closing)) / 100) * Val(Diff_))
    End Function
    Private Function On_Attendance_On_Production(Ac As String, Pyhd As String, D1 As Date, D2 As Date, no_cal_tra_id As Integer) As Decimal
        Dim CONN As New SQLiteConnection
        Dim Vlu As Decimal = 0.00
        Dim amt As Decimal = 0.00
        Dim cr As Decimal
        Dim Dr As Decimal

        If open_MSSQL_Cstm(Database_File.cre, CONN) Then
            qury = "Select * From TBL_Attendance_VC where Account = '" & Ac & "' and Payhead = '" & Pyhd & "' and Date BETWEEN '" & D1.ToString("MM-dd-yyyy") & "' and '" & D2.ToString("MM-dd-yyyy") & "' and Visible = 'Approval' and Tra_ID <> '" & no_cal_tra_id & "'"
            cmd = New SQLiteCommand(qury, CONN)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader

            While r.Read
                Vlu += Val(r("Balance"))
                amt += Val(r("Pay"))
            End While
            r.Close()
        End If
        CONN.Close()

        If open_MSSQL_Cstm(Database_File.cre, CONN) Then
            qury = "Select * From TBL_VC where Particuls = '" & Ac & "' and Payhead = '" & Pyhd & "' and Date BETWEEN '" & D1.ToString("MM-dd-yyyy") & "' and '" & D2.ToString("MM-dd-yyyy") & "' and CR_DR = 'Under' and Visible = 'Approval' AND Auto_Entry = 'False' and Tra_ID <> '" & no_cal_tra_id & "'"

            cmd = New SQLiteCommand(qury, CONN)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                cr += Val(r("Cr"))
                Dr += Val(r("Dr"))
            End While
            r.Close()
        End If
        CONN.Close()
        Return (Vlu - (Val(Dr) - Val(cr)))
    End Function
    Public Function Flat_Rate_cal(Ac As String, Pyhd As String, D1 As Date, D2 As Date, no_cal_tra_id As Integer) As Decimal()
        'Dim cal_ As String = Find_DT_Value(Database_File.cre, "TBL_Payhead", "Cal", "ID = '" & Pyhd & "'")

        Dim CONN As New SQLiteConnection
        Dim rate As Decimal
        If open_MSSQL_Cstm(Database_File.cre, CONN) = True Then
            qury = "Select * From TBL_Payroll_SalaryDetails where Account Like N'" & Ac & "' and Payhead = '" & Pyhd & "' and Date BETWEEN '" & CDate(Company_Book_frm).ToString("MM-dd-yyyy") & "' and '" & D2.ToString("MM-dd-yyyy") & "'"
            cmd = New SQLiteCommand(qury, CONN)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                'Dim date_deff As Integer = 0
                'If cal_ = "Days" Then
                '    date_deff = DateDiff(DateInterval.Day, D1, D2.AddDays(1))
                'ElseIf cal_ = "Months" Then
                '    date_deff = DateDiff(DateInterval.Month, D1, D2.AddDays(1))
                'ElseIf cal_ = "Weeks" Then
                '    date_deff = DateDiff(DateInterval.Weekday, D1, D2)
                'End If

                'If Val(date_deff) > 0 Then
                '    Return Val(date_deff) * Val(r("Rate"))
                'Else
                '    Return 0
                'End If
                rate = Val(r("Rate"))
            End While
            r.Close()

            Dim cr As Decimal = Val(Find_DT_Value_SUM(Database_File.cre, "TBL_VC", "Cr", "Date BETWEEN '" & D1.ToString("MM-dd-yyyy") & "' and '" & Month_last_date(D2.Month, D2.Year).ToString("MM-dd-yyyy") & "' and Particuls = '" & Ac & "' and Payhead = '" & Pyhd & "'"))

            Dim dr As Decimal = Val(Find_DT_Value_SUM(Database_File.cre, "TBL_VC", "Dr", "Date BETWEEN '" & D1.ToString("MM-dd-yyyy") & "' and '" & Month_last_date(D2.Month, D2.Year).ToString("MM-dd-yyyy") & "' and Particuls = '" & Ac & "' and Payhead = '" & Pyhd & "'"))


            CONN.Close()
            Return {Val(rate) - (Val(dr) - Val(cr)), Val(rate)}
        End If
    End Function
    Public Function Month_last_date(mont As Integer, yer As Integer) As Date
        Dim dt As Date
        Try
            dt = CDate("31-" & mont & "-" & yer)
        Catch ex As Exception
            Try
                dt = CDate("30-" & mont & "-" & yer)
            Catch ex1 As Exception
                Try
                    dt = CDate("29-" & mont & "-" & yer)
                Catch ex2 As Exception
                    dt = CDate("28-" & mont & "-" & yer)
                End Try
            End Try
        End Try
        Return dt
    End Function
    Private Function Loan_Advance_cal(Ac As String, Pyhd As String, D1 As Date, D2 As Date) As Decimal

    End Function
    'and Auto_Entry = 'False'
    Public Function Company_Opning_Balance(Branch_ID As String) As ArrayList
        Dim ans As New ArrayList
        Dim cr As Decimal
        Dim Dr As Decimal



        If open_MSSQL(Database_File.cre) = True Then
            cmd = New SQLiteCommand($"Select SUM(ob.OB_Dr) as Dr,SUM(ob.OB_Cr) as Cr From TBL_Ledger_Opning_Balance ob where (Select ld.Visible From TBL_Ledger ld where ld.ID = ob.Ledger_ID) = 'Approval' and ob.Branch_ID = '{Branch_ID}' ", con)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                cr += Val(r("Cr").ToString)
                Dr += Val(r("Dr").ToString)
            End While
            r.Close()

            cmd = New SQLiteCommand($"Select SUM(ob.OB_DR) as Dr,SUM(ob.OB_CR) as Cr From TBL_PayHead ob where ob.Visible = 'Approval'", con)
            r = cmd.ExecuteReader
            While r.Read
                cr += Val(r("Cr").ToString)
                Dr += Val(r("Dr").ToString)
            End While

            r.Close()
            con.Close()

            ans.Add(Dr & "Dr")
            ans.Add(cr & "Cr")

            If Val(Val(cr) - Val(Dr)) > 0 Then
                ans.Add(Val(cr) - Val(Dr) & " Cr")
            Else
                If Val(Val(Dr) - Val(cr)) > 0 Then
                    ans.Add(Val(Dr) - Val(cr) & " Dr")
                Else
                    ans.Add("0.00")
                End If
            End If
        End If
        Return ans
    End Function
    Public Function Find_SalaryDetails_date(Acc As String, Current_Date As Date) As Date
        Dim Company_DAte As Date = CDate(Company_Book_frm)
        Dim Date_ As Date = Current_Date
        If open_MSSQL_3(Database_File.cre) Then
            qury = "Select * From TBL_Payroll_SalaryDetails where Account Like N'" & Acc & "' and Date BETWEEN '" & Company_DAte.ToString("MM-dd-yyyy") & "' and '" & CDate("01-01-2099").ToString("MM-dd-yyyy") & "'"
            cmd_3 = New SQLiteCommand(qury, con_3)
            Dim r2 As SQLiteDataReader
            r2 = cmd_3.ExecuteReader
            While r2.Read
                If Current_Date >= CDate(r2("Date")) Then
                    Date_ = CDate(r2("Date"))
                End If
            End While
            r2.Close()
            con.Close()
        End If
        Return Date_
    End Function
    Public Function Delete_Account_VC(ID As Integer) As Boolean
        Dim conn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, conn) Then
            cmd = New SQLiteCommand("INSERT INTO DEL_VC (Tra_ID,Voucher_ID,Voucher_No,Order_No,Register_No,Bill_No,Voucher_Type,Voucher_Type_ID,CR_DR,Date,Under,Account,Particuls,Fat,Quantity,Unit,Rate,Cr,Dr,Branch,Godown,Narration,Tax_Type,Tax_Per,Tax_Value,Company,Visible,[User],Date_Install,PC) SELECT Tra_ID,Voucher_ID,Voucher_No,Order_No,Register_No,Bill_No,Voucher_Type,Voucher_Type_ID,CR_DR,Date,Under,Account,Particuls,Fat,Quantity,Unit,Rate,Cr,Dr,Branch,Godown,Narration,Tax_Type,Tax_Per,Tax_Value,Company,'Delete',[User],Date_Install,PC FROM TBL_VC WHERE Tra_ID = '" & ID & "'", conn)
            cmd.ExecuteNonQuery()
            conn.Close()
            If Data_Delete(Database_File.cre, "TBL_VC", "Visible = 'Delete' WHERE Tra_ID = '" & ID & "'") = True Then
                Return True
            End If
        End If
    End Function
    Public Function Rate_Valuation(Valuation As String, ID As String, Dt_ As Date, Branch_ As String, Optional ByVal Defolt_Type As String = "Inward") As Decimal
        Dim Amt As Decimal = 0.00
        Dim valu As String = ""
        valu = Valuation

        Dt_ = Dt_.AddDays(1)

        If Valuation = "Default" Then
            If Defolt_Type = "Inward" Then
                valu = Find_DT_Value(Database_File.cre, "TBL_Stock_Item", "Costing_Value_Type", $"ID = '{ID}'")
            ElseIf Defolt_Type = "Outward" Then
                valu = Find_DT_Value(Database_File.cre, "TBL_Stock_Item", "Market_Value_Type", $"ID = '{ID}'")
            End If
        End If

        If valu = Nothing Then
            valu = "Standard Sales"
        End If

        If valu = "Avg. Inward" Then
            Dim cn As New SQLiteConnection
            If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                cmd = New SQLiteCommand("SELECT (SUM(Dr)/SUM(Quantity)) as Value_ FROM TBL_VC where ((((Voucher_Type = 'Purchase' or Voucher_Type = 'Sales Return') and (Particuls = @IDT) AND CR_DR = 'Under') or ((Voucher_Type = 'Stock Journal') and (Account = @IDT) AND CR_DR = 'Head')) AND (Visible = @Visible AND Company = @Company)) AND ([Date] <= @Filter_Date)", cn)
                Dim r As SQLiteDataReader
                With cmd.Parameters
                    .AddWithValue("@IDT", ID)
                    .AddWithValue("@Visible", "Approval")
                    .AddWithValue("@Branch", Branch_)
                    .AddWithValue("@Company", Company_ID_str)
                    .AddWithValue("@Filter_Date", Dt_.AddDays(1).ToString(Lite_date_Format))
                    r = cmd.ExecuteReader
                    While r.Read
                        Amt = Val(r("Value_").ToString)
                    End While
                    r.Close()
                End With
                cn.Close()

            End If
        ElseIf valu = "Avg. Outward" Then
            Dim cn As New SQLiteConnection
            If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                cmd = New SQLiteCommand("SELECT (SUM(Cr)/SUM(Quantity)) as Value_ FROM TBL_VC where ((((Voucher_Type = 'Sales' or Voucher_Type = 'Purchase Return') and (Particuls = @IDT) AND CR_DR = 'Under') or ((Voucher_Type = 'Stock Journal') and (Particuls = @IDT) AND CR_DR = 'Under')) AND (Visible = @Visible AND Company = @Company)) AND ([Date] <= @Filter_Date)", cn)
                Dim r As SQLiteDataReader
                With cmd.Parameters
                    .AddWithValue("@IDT", ID)
                    .AddWithValue("@Visible", "Approval")
                    .AddWithValue("@Branch", Branch_)
                    .AddWithValue("@Company", Company_ID_str)
                    .AddWithValue("@Filter_Date", Dt_.AddDays(1).ToString(Lite_date_Format))
                    r = cmd.ExecuteReader
                    While r.Read
                        Amt = Val(r("Value_").ToString)
                    End While
                    r.Close()
                End With
                cn.Close()
            End If
        ElseIf valu = "Last Purchase" Then
            Dim cn As New SQLiteConnection
            If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                cmd = New SQLiteCommand($"SELECT (SELECT vi.Rate1 FROM TBL_VC_item_Details vi LEFT JOIN TBL_VC vc on vc.Tra_ID = vi.Tra_ID Where (((vc.Voucher_Type = 'Purchase') AND vi.Item = '{ID}') AND (vc.Visible = 'Approval')) AND (vc.[Date] <= '{Dt_.AddDays(1).ToString(Lite_date_Format)}') ORDER BY vc.Voucher_ID desc LIMIT 1) As Value_", cn)
                Dim r As SQLiteDataReader
                r = cmd.ExecuteReader
                While r.Read
                    Amt = nUmBeR_FORMATE(r("Value_").ToString)
                End While
                cn.Close()
                'MsgBox(Amt)
            End If
        ElseIf valu = "Last Sales" Then
            Dim cn As New SQLiteConnection
            If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                cmd = New SQLiteCommand($"SELECT (SELECT vi.Rate1 FROM TBL_VC_item_Details vi LEFT JOIN TBL_VC vc on vc.Tra_ID = vi.Tra_ID Where (((vc.Voucher_Type = 'Sales') AND vi.Item = '{ID}') AND (vc.Visible = 'Approval')) AND (vc.[Date] <= '{Dt_.AddDays(1).ToString(Lite_date_Format)}') ORDER BY vc.Voucher_ID desc LIMIT 1) As Value_", cn)
                Dim r As SQLiteDataReader
                r = cmd.ExecuteReader
                'My.Computer.Clipboard.SetText(cmd.CommandText)
                While r.Read
                    Amt = nUmBeR_FORMATE(r("Value_").ToString)
                End While
                cn.Close()
            End If
        ElseIf valu = "Standard Purchase" Then
            Amt = Find_STD_Rate(ID, Dt_, STD_RATE_Typ.Cost)
        ElseIf valu = "Standard Sales" Then
            Amt = Find_STD_Rate(ID, Dt_, STD_RATE_Typ.Sales)
            'MsgBox(Amt)
        ElseIf valu = "Basic Purchase Rate" Then
            Amt = Val(Find_DT_Value(Database_File.cre, "TBL_Stock_Item", "Purchase_Rate", $"ID = '{ID}'"))
        ElseIf valu = "Basic Sales Rate" Then
            Amt = Val(Find_DT_Value(Database_File.cre, "TBL_Stock_Item", "Sales_Rate", $"ID = '{ID}'"))
        End If
        Return Amt
    End Function
    Public Function Branch_ID_() As Integer
        Dim str As Integer = Val(Find_DT_Value(Database_File.cre, "TBL_Ledger", "ID", "Name = '" & Dft_Branch & "'"))
        Return str
    End Function
    Public Function Branch_Visible() As Boolean
        If Find_Features(Features_Type.Selected_Company, Features_Head.General, "Branch_YN") = "Yes" And Branch_ID = "0" Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Not_Delete_Error_head As String = ""
    Public Not_Delete_Error_msg As String = ""
    Public Function Delete_Vouchers(Tra_ID As Integer, Voucher_Type As String) As Boolean
        If Chack_Duplicate(Database_File.cre, "TBL_VC", "ID", "(Order_No = '" & Tra_ID & "' or Register_No = '" & Tra_ID & "') and (Visible = 'Approval')") = True Then
            Not_Delete_Error_head = "This voucher link another vouchers"
            Not_Delete_Error_msg = "This voucher will not be modified,<nl>as this voucher is linked under another voucher,<nl>if you want to modify the voucher,<nl>delete the linked voucher or unlink it."
            Return False
        End If

        If Chack_Duplicate(Database_File.cre, "TBL_Attendance_VC", "ID", $"(TBL_VC_ID <> 'NA') and (Visible = 'Approval') and Tra_ID = '{Tra_ID}'") = True Then
            Not_Delete_Error_head = "This voucher link another vouchers"
            Not_Delete_Error_msg = "This voucher will not be modified,<nl>as this voucher is linked under another voucher,<nl>if you want to modify the voucher,<nl>delete the linked voucher or unlink it."
            Return False
        End If


        'Dim conn As New SQLiteConnection

        If Audit_Vouchers(Tra_ID) = True Then
            If Data_Delete(Database_File.cre, "TBL_VC", $"{Tra_ID}") = True Then
                'Dim conns As New SQLiteConnection
                'If open_MSSQL_Cstm(Database_File.cre, conns) = True Then
                '    cmd = New SQLiteCommand($"Update TBL_Attendance_VC SET TBL_VC_ID = 'NA' WHERE TBL_VC_ID = '{Tra_ID}' and Visible = 'Approval'", conns)
                '    cmd.ExecuteNonQuery()
                '    conns.Close()
                'End If
            End If
        End If

        'Order Details Fills
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            Dim order_id As String = Find_DT_Value(Database_File.cre, "TBL_VC", "Order_No", $"Tra_ID = '{Tra_ID}' and Type = 'Head'")
            Order_Complit_Fll(cn, order_id)
        End If
        Return True
    End Function
    Private Function Order_Complit_Fll(cn As SQLiteConnection, ID As String) As Boolean
        If ID <> Nothing Then
            Dim istrue As Boolean = Order_Fll(cn, ID)

            Dim status_ As String
            If istrue = False Then
                status_ = "Pending"
            Else
                status_ = "Approval"
            End If


            qury = $"UPDATE TBL_VC Set Visible = '{status_}' WHERE Tra_ID = '{ID}'"

            cmd = New SQLiteCommand(qury, cn)
            cmd.ExecuteNonQuery()



        End If
    End Function

    Private Function Order_Fll(cn As SQLiteConnection, ID As String) As Boolean
        Dim istrue As Boolean = False

        cmd = New SQLiteCommand($"Select vi.Item,SUM(vi.Qty) as Ord,

(Select SUM(vi1.Qty) From TBL_VC_item_Details  vi1 where vi1.Item = vi.Item and (Select vc.Order_No From TBL_VC vc where vc.Tra_ID = vi1.Tra_ID and vc.Type = 'Head' and vc.Visible = 'Approval') = vi.Tra_ID) as Com 

From TBL_VC_item_Details vi
where vi.Tra_ID = '{ID}'
Group By vi.Item", cn)

        Dim r As SQLiteDataReader = cmd.ExecuteReader
        While r.Read
            If Val(r("Ord").ToString) > Val(r("Com").ToString) Then
                istrue = True
                Exit While
            End If
        End While
        r.Close()

        Return istrue
    End Function
    Private Function Payroll_Loan_Brake_Delete(Tra_ID As String) As Boolean
        Dim cn As New SQLiteConnection
        Dim Loan_ID As String = ""
        Dim tr_ID As String = ""
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand("Select vc.Tra_ID,vc.Loan_ID,
(Select TOP 1 ls.[Tra_ID] From TBL_Loan_Installments ls where ls.Loan_ID = vc.Loan_ID Order By ls.[To] DESC) as Last_Tra_ID
From TBL_VC vc
where vc.Tra_ID = '" & Tra_ID & "' and vc.Voucher_Type = 'Payroll' and vc.CR_DR = 'Under'", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                Dim T As String = r("Last_Tra_ID").ToString
                Loan_ID = r("Loan_ID").ToString
                tr_ID = r("Last_Tra_ID").ToString
                If T.ToString <> Nothing Then
                    If Tra_ID <> T Then
                        Return False
                    End If
                End If
            End While
            r.Close()
            cn.Close()
        End If

        Dim cnn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cnn) = True Then
            cmd = New SQLiteCommand("DELETE FROM TBL_Loan_Installments WHERE Loan_ID = '" & Loan_ID & "' and Tra_ID = '" & Tra_ID & "'", cnn)
            cmd.ExecuteReader()
            cnn.Close()
        End If

        Return True
    End Function
    Public Function Update_Value(cn As SQLiteConnection, TBL_ As String, Clu_ As String, vLU As String, Filter As String)
        cmd = New SQLiteCommand("UPDATE " & TBL_ & " SET " & Clu_ & " = '" & vLU & "' where " & Filter, cn)
        cmd.ExecuteNonQuery()

        'cn.Close()
    End Function

    Private Function Order_Auto_aet_pending_delete(conns As SQLiteConnection, Tra_ID As String)
        Dim Order_ID = Find_DT_Value(Database_File.cre, "TBL_VC", "Order_No", "Tra_Id = '" & Tra_ID & "' AND CR_DR = 'Head'")
        Dim Register_ID = Find_DT_Value(Database_File.cre, "TBL_VC", "Register_No", "Tra_Id = '" & Tra_ID & "' AND CR_DR = 'Head'")
        Dim Order_Tra As String
        If Order_ID.Length <> 0 Then
            Order_Tra = Order_ID
        ElseIf Register_ID.Length <> 0 Then
            Order_Tra = Register_ID
        End If

        qury = "UPDATE TBL_VC SET Visible = 'Pending',Bill_No = '' WHERE Tra_ID = '" & Order_Tra & "'"

        cmd = New SQLiteCommand(qury, conns)
        cmd.ExecuteNonQuery()

        conns.Close()
        Return True
    End Function
    Public Function Find_Branch_Name(ID_ As String) As String
        If ID_.ToString.Trim = "Primary" Or ID_.ToString.Trim = "0" Or ID_.ToString.Trim = Nothing Then
            Return "Primary"
        Else
            Return Find_DT_Value(Database_File.cre, "TBL_Ledger", "Name", "ID = '" & ID_ & "'")
        End If
    End Function
    Public Function Set_Branch() As String
        If Branch_Visible() = True Then
            Return Find_Branch_Name(Branch_ID)
        Else
            Return "Primary"

        End If
    End Function
    Public Function Branch_Enable_Ledger(ld_id As String, Branch_id As String) As String

        Return $"(((Select count(*) From TBL_Ledger_Opning_Balance ob where ob.Ledger_ID = {ld_id} and ob.Branch_ID = {Branch_id}) <> 0 AND
(Select ob.Applicable From TBL_Ledger_Opning_Balance ob where ob.Ledger_ID = {ld_id} and ob.Branch_ID = {Branch_id}) = 'Yes') or
(Select count(*) From TBL_Ledger_Opning_Balance ob where ob.Ledger_ID = {ld_id} and ob.Branch_ID = {Branch_id}) = 0)"
    End Function
    Public Function Branch_Enable_Stock_Item(it_id As String, Branch_id As String) As String

        Return $"(((Select count(*) From TBL_Stock_Item_Opning_Stock ob where ob.Item_ID = {it_id} and ob.Branch_ID = {Branch_id}) <> 0 AND
(Select ob.Applicable From TBL_Stock_Item_Opning_Stock ob where ob.Item_ID = {it_id} and ob.Branch_ID = {Branch_id}) = 'Yes') or
(Select count(*) From TBL_Stock_Item_Opning_Stock ob where ob.Item_ID = {it_id} and ob.Branch_ID = {Branch_id}) = 0)"
    End Function
    Public Function Find_Server_Datetime(cn As SqlConnection) As String
        Try
            Dim cmd_o As New SqlCommand("SELECT DATEADD(MINUTE, 90, GETDATE()) AS vlu;", cn)
            Dim r As SqlDataReader
            r = cmd_o.ExecuteReader
            While r.Read
                Dim dt As Date = CDate(r("vlu"))
                Return dt.ToString
            End While
        Catch ex As Exception
            Return ""
        End Try
    End Function
End Module
