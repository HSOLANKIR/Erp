Imports System.Data.SQLite
Imports BarcodeLib
Imports Microsoft.Reporting.WinForms
Imports QRCoder
Imports PopupControl
Imports System.IO
Imports System.Text
Imports Tools
Public Class Inventory_Vouchers_frm
    Dim From_ID As String
    Public VC_Type_ As String
    Public VC_ID_ As String
    Public Tra_ID As String
    Dim Audit_ID As String
    Public VC_Formate As String
    Public VC_Formate_ID As String

    Public Order_Tra_ID As String
    Public Order_Next As Boolean = False

    Public Acc_ID As String
    Dim Path_End As String
    Dim List_Fing_Bs As BindingSource
    Dim Voucher_ID As Integer
    Dim Effect_Stock As Boolean = True
    Dim Effect_Ledger As Boolean = True
    Public Order_Type As String
    'Voucher_Setup Variabels\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\


    Dim Payroll_Date1, Payroll_Date2 As Date

    Public Ledger_List_Value As String
    Dim Ledger_Credit_Expire_Action As String
    '
    Dim Acc_Phone As String
    Dim Acc_Email As String
    Dim Acc_Address As String

    Dim Attendance_Edit As Boolean = True

    Public Dispatch_Doc As String = ""
    Public Dispatch_through As String = ""
    Public Dispatch_Carrier_Name_agent As String = ""
    Public Dispatch_date As Date

    Public Transport_ID As String = ""
    Public Transport_Mode As String = ""
    Public Transport_Distance As String = ""
    Public Transport_Name As String = ""
    Public Vihicale_Name As String = ""
    Public Vihicale_No As String = ""
    Public Vihicale_Type As String = ""
    Public LR_No As String = ""
    Public Driver_Name As String = ""
    Public Driver_Phone As String = ""
    Public Driver_License As String = ""
    'Vebrij Details
    Public Vebrij_Gross As String = ""
    Public Vebrij_Vihical As String = ""
    Public Vebrij_Net As String = ""

    Public eWay_Bill_No As String = ""
    Public ewayBill_Type As String = ""
    Public ewayBill_Document_Type As String = ""
    Public From_Address1 As String = ""
    Public From_Address2 As String = ""
    Public From_Please As String = ""
    Public From_Pincode As String = ""
    Public To_ID As String = ""
    Public To_Name As String = ""
    Public To_GST As String = ""
    Public To_Address1 As String = ""
    Public To_Address2 As String = ""
    Public To_Please As String = ""
    Public To_Pincode As String = ""
    Public To_Country As String = ""
    Public To_State As String = ""
    Public To_GST_Type As String = ""

    Public supplier_vc_no As String = ""
    Public supplier_date As String = ""

    Public credit_note_resion As String = ""
    Public supplier_narration As String = ""

    Public Terms_of_payment As String = ""
    Public Payment_reference As String = ""
    Public terms_of_delivery As String = ""

    Public Ship_ID As String = ""
    Public Ship_Name As String = ""
    Public Ship_Address As String = ""
    Public Ship_Mailing As String = ""
    Public Ship_Country As String = ""
    Public Ship_State As String = ""
    Public Ship_Pincode As String = ""
    Public Ship_GST As String = ""
    Public Ship_GST_Type As String = ""

    'Ewaybill Parameters
    Public eb_ewaybill_no As String = ""
    Public eb_date As String = ""
    Public eb_Sub_Type As String = ""
    Public eb_Document_Type As String = ""
    Public eb_Consignee_F As String = ""
    Public eb_Address1_F As String = ""
    Public eb_Address2_F As String = ""
    Public eb_Please_F As String = ""
    Public eb_Pincode_F As String = ""
    Public eb_GSTIN_F As String = ""
    Public eb_State_F As String = ""
    Public eb_Consignee_T As String = ""
    Public eb_Address1_T As String = ""
    Public eb_Address2_T As String = ""
    Public eb_Please_T As String = ""
    Public eb_State_dispath_T As String = ""
    Public eb_State_ship_T As String = ""
    Public eb_Pincode_T As String = ""
    Public eb_GSTIN_T As String = ""
    Public eb_State_T As String = ""
    Public eb_Mode As String = ""
    Public eb_Distance As String = ""
    Public eb_Transport_Name As String = ""
    Public eb_Transport_ID As String = ""
    Public eb_Vehicle_No As String = ""
    Public eb_Vehicle_Type As String = ""
    Public eb_LR_No As String = ""

    'Export Details
    Public Export_shipper As String = ""
    Public Export_port_loading As String = ""
    Public Export_port_discharge As String = ""
    Public Export_shipping_bill As String = ""
    Public Export_Date As Date
    Public Export_Port_Code As String = ""
    Public Export_LUT_No As String = ""

    Public vc_Transfer As Boolean = False

    'Form Setup Proccess||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
    Private Sub Voucher_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text

        VC_Formate = Link_Valu(2)
        VC_Type_ = Link_Valu(1)
        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Or VC_Type_ = "Voucher Transfer" Then
            VC_Formate_ID = Link_Valu(3)
        End If

        BG_frm.HADE_TXT.Text = "Inventory Voucher"
        BG_frm.TYP_TXT.Text = VC_Type_
        Date_TXT.Text = Now.Date


        Fill_Source()
        List_set()

        Set_msg()

        controls_add(VC_Formate.ToLower)

        If VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close" Or VC_Type_ = "Duplicate" Then
            If vc_Transfer = False Then
                Display_all_Data(False, "")
            End If
        ElseIf VC_Type_ = "Audit" Then
            Audit_ID = Link_Valu(3)
            'Display_all_Data("DEL_VC", "TBL_VC_item_Details", "Audit_ID", False, "")
        ElseIf VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Or VC_Type_ = "Voucher Transfer" Then
            Defolt_Set_Voucher()
            Tra_ID = "0"
        End If

        Button_Manage()
        Add_Hander_Remove_Handel(True)

        Date_TXT.Focus()
    End Sub
    Private Function Qry_Filters() As String
        Dim q As String = ""
        q &= $" and (vc.Visible = 'Approval')"
        q &= $" and (vc.[Date] <= '{CDate(Date_TXT.Text).AddDays(1).ToString(Lite_date_Format)}')"
        If Dft_Branch <> "Primary" Then
            q &= " AND VC.Branch = '" & Find_DT_Value(Database_File.cre, "TBL_Ledger", "ID", "Name = '" & Dft_Branch & "'") & "'"
        End If

        If VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close" Then
            q &= $" and (vc.Tra_ID <> '{Tra_ID}')"
        End If
        Return q
    End Function
    Dim msg_Acc As Msg_frm
    Dim msg_date As Msg_frm
    Dim msg_vc_no As Msg_frm
    Private Function Set_msg()
        msg_Acc = New Msg_frm
        Account_TXT.Msg_Object = msg_Acc

        msg_date = New Msg_frm
        Date_TXT.Msg_Object = msg_date


        msg_vc_no = New Msg_frm
        Voucher_No_TXT.Msg_Object = msg_vc_no
    End Function
    Dim acc_list As List_frm
    Dim Head_list As List_frm
    Dim Class_list As List_frm
    Private Function List_set()
        Dim dt_ = New DataTable
        dt_.Columns.Add("Name")
        dt_.Columns.Add("ID")
        dt_.Rows.Add("Not Applicable", "0")
        Class_Source.DataSource = dt_
        obj_top(Class_Panel)


        acc_list = New List_frm
        List_Setup("List of Ledger", Select_List.Right_Dock, Select_List_Format.Defolt, Account_TXT, acc_list, Account_Source, 450)
        acc_list.Set_COlor(6)
        acc_list.System_Data_integer = 1

        Class_list = New List_frm
        List_Setup("List of Class", Select_List.Botom_Center, Select_List_Format.Singel, Class_TXT, Class_list, Class_Source, 300)


    End Function
    Private Function Fill_Source()
        Dim Positive As String = Find_DT_Value(Database_File.cmp, "TBL_Features", "Value", "Head = 'Positive Value'")
        Dim Negative As String = Find_DT_Value(Database_File.cmp, "TBL_Features", "Value", "Head = 'Negative Value'")

        Dim Filter As String = " and (LD.ID = '' "

        Filter &= " or (LD.[Group] = '27') or (LD.[Group] = '22') or (LD.[Group] = '26') or (LD.[Group] = '7')"

        Filter &= ")"

        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            Dim dt_ As New DataTable
            dt_.Columns.Clear()
            dt_.Columns.Add("Name")
            dt_.Columns.Add("Curr. Balance")
            dt_.Columns.Add("ID")
            dt_.Columns.Add("Alias")
            dt_.Columns.Add("Group")
            dt_.Columns.Add("Curr. Credit")
            dt_.Columns.Add("Color")
            dt_.Columns.Add("balance_")

            dt_.Rows.Add("", "Create Ledger")
            Dim r As SQLiteDataReader
            cmd = New SQLiteCommand($"Select [ID],[Name],[Group],[Alise],[Cradit],
(Select ifnull((Select ifnull(SUM(vc.Cr),0)-ifnull(SUM(vc.Dr),0) From TBL_VC_Ledger vc Where vc.Ledger = LD.ID and vc.[Date] <= '{CDate(Date_TXT.Text).AddDays(1).ToString(Lite_date_Format)}' and vc.Tra_ID <> '{Tra_ID}'),0)+ifnull((Select ifnull(sum(lob.OB_Cr),0)-ifnull(sum(lob.OB_Dr),0) From TBL_Ledger_Opning_Balance lob where lob.Ledger_ID = LD.ID and lob.Branch_ID = '{Branch_ID}'),0)) as Bal_
from TBL_Ledger LD where {Branch_Enable_Ledger("LD.id", Branch_ID)} {Head_Filter_on_CLass} and {Company_Visible_Filter()} Order By [Name]", cn)

            'My.Computer.Clipboard.SetText(cmd.CommandText)
            With cmd.Parameters
                .AddWithValue("@Filter_Date", CDate(Date_TXT.Text).AddDays(1).ToString(Lite_date_Format))

                r = cmd.ExecuteReader

                While r.Read
                    Dim Vlu_ As String
                    Vlu_ = r("Bal_").ToString
                    If Val(Vlu_) > 0 Then
                        Vlu_ = N2_FORMATE(Val(Vlu_)) & " " & Positive
                    ElseIf Val(Vlu_) < 0 Then
                        Vlu_ = N2_FORMATE(Vlu_ * -1) & " " & Negative
                    Else
                        Vlu_ = ""
                    End If

                    Dim Credit_ As String
                    Dim Color_ As String
                    Credit_ = Val(r("Bal_").ToString) - Val(r("Cradit").ToString)
                    If Val(Credit_) < 0 Then
                        Color_ = "Red"
                    ElseIf Val(Credit_) > 0 Then
                        Color_ = "Black"
                    Else
                        Credit_ = ""
                        Color_ = "Black"
                    End If

                    dt_.Rows.Add(r("Name"), Vlu_, r("ID"), r("Alise"), r("Group"), Credit_, Color_, Val(r("Bal_").ToString) * -1)
                End While
            End With
            r.Close()
            Account_Source.DataSource = dt_

            'Direct Fill Source
            Branch_source.DataSource = Fill_Branch_data(cn)
            Order_Source.DataSource = Fill_Vouchhers(cn)


            dt_ = New DataTable
            dt_.Columns.Add("Name")
            dt_.Columns.Add("Alias")
            dt_.Columns.Add("ID")
            If Voucher_Type_LB.Text = "Sales" Then
                cmd = New SQLiteCommand("Select ld.ID,ld.Name,ld.Alise From TBL_Ledger ld where ld.[Group] = '10' and Visible = 'Approval'", cn)
            ElseIf Voucher_Type_LB.Text = "Purchase" Then
                cmd = New SQLiteCommand("Select ld.ID,ld.Name,ld.Alise From TBL_Ledger ld where ld.[Group] = '11' and Visible = 'Approval'", cn)
            End If
            r = cmd.ExecuteReader
            While r.Read
                dt_.Rows.Add(r("Name"), r("Alise"), r("ID"))
            End While
            Head_Account_Source.DataSource = dt_



        End If
    End Function
    Public Function Fill_Branch_data(cn As SQLiteConnection) As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow

        dt.Clear()
        dt.Columns.Add("Name")
        dt.Columns.Add("Alias")
        dt.Columns.Add("ID")

        dt.Rows.Add("Primary")

        cmd = New SQLiteCommand("Select * From TBL_Ledger WHERE Visible = 'Approval' and [Group] = '7'", cn)
        Dim r As SQLiteDataReader
        r = cmd.ExecuteReader
        While r.Read
            dr = dt.NewRow
            dr("ID") = r("ID")
            dr("Name") = r("Name")
            dr("Alias") = r("Alise")
            dt.Rows.Add(dr)
        End While
        r.Close()
        Return dt
    End Function
    Public Function Defolt_Set_Voucher()
        If VC_Formate = "Sales Order" Then
            Sales_Order_Frmt()
        ElseIf VC_Formate = "Outward Register" Then
            Outward_Register_Frmt()
        ElseIf VC_Formate = "Sales Return" Then
            Sales_Return_Frmt()
        ElseIf VC_Formate = "Sales" Then
            Sales_Frmt()
        ElseIf VC_Formate = "Purchase Order" Then
            Purchase_Order_Frmt()
        ElseIf VC_Formate = "Inward Register" Then
            Inward_Register_Frmt()
        ElseIf VC_Formate = "Purchase" Then
            Purchase_Frmt()
        ElseIf VC_Formate = "Purchase Return" Then
            Purchase_Return_Frmt()
        ElseIf VC_Formate = "Stock Journal" Then
            Stock_Journal_Frmt()
        ElseIf VC_Formate = "Credit Note" Then
            Credit_Note_Frmt()
        ElseIf VC_Formate = "Debit Note" Then
            Debit_Note_Frmt()
        End If


        Dim textboxes = Me.GetAllControls(Me).OfType(Of TXT)().ToList()
        For Each TX As TXT In textboxes
            TX.Back_color = Color_bg
            TX.BackColor = Color_bg
        Next

        Dim ynnn = Me.GetAllControls(Me).OfType(Of YN)().ToList()
        For Each TX As YN In ynnn
            TX.Back_color = Color_bg
            TX.BackColor = Color_bg
        Next


        Me.BackColor = Color_bg


    End Function
    Public Color_bg As Color = Color.White

    Private Function GetAllControls(control As Control) As IEnumerable(Of Control)
        Dim controls = control.Controls.Cast(Of Control)()
        Return controls.SelectMany(Function(ctrl) GetAllControls(ctrl)).Concat(controls)
    End Function

    Public Sp_controls1 As sp_controls
    Public Stock_journal_controls1 As stock_journal_controls
    Public Function controls_add(typ As String)
        If typ = "sales" Or typ = "sales order" Or typ = "purchase" Or typ = "purchase order" Or typ = "purchase return" Or typ = "sales return" Or typ = "inward register" Or typ = "outward register" Or typ = "credit note" Or typ = "debit note" Then
            Sp_controls1 = New sp_controls

            With Sp_controls1
                Panel30.Controls.Add(Sp_controls1)
                .Dock = DockStyle.Fill

                .Fill_Item_data(True)

                Defolt_Set_Voucher()
                .Color_bg = Color_bg

                .Add_New()
                .Add_New_exp("User Defined Value", "Not Applicable", 0)
                '.List_set()
                Panel8.Visible = True
            End With
        ElseIf typ = "stock journal" Then
            Stock_journal_controls1 = New stock_journal_controls
            Panel30.Controls.Add(Stock_journal_controls1)
            Stock_journal_controls1.Dock = DockStyle.Fill


            Stock_journal_controls1.Add_New_S()
            Panel8.Visible = True
            Account_Panel.Visible = False

        End If

        'Sp_controls1.Add_New()
        'Sp_controls1.Add_New_exp()

    End Function
    Public Function cstm_control_mng(lb As Object)
        If VC_Formate.ToLower = "sales" Or VC_Formate.ToLower = "sales order" Or VC_Formate.ToLower = "purchase" Or VC_Formate.ToLower = "purchase order" Or VC_Formate.ToLower = "purchase return" Or VC_Formate.ToLower = "sales return" Or VC_Formate.ToLower = "inward register" Or VC_Formate.ToLower = "outward register" Then
            Sp_controls1.Visible = False
        ElseIf VC_Formate.ToLower = "stock journal" Then
            Stock_journal_controls1.Visible = False
        End If

        Item_Progress_Panel.Visible = False

        lb.Visible = True
        lb.Dock = DockStyle.Fill
    End Function
    Private Sub Voucher_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.From_ID = From_ID
        BG_frm.HADE_TXT.Text = "Inventory Voucher"
        BG_frm.TYP_TXT.Text = VC_Type_

        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text
        Button_Clear()
        Cfg_Link()
        Button_Manage()

        Fill_Source()


        'If Branch_TXT.Text = "" And Branch_Panel.Visible = True Then
        '    Branch_TXT.Focus()
        'Else
        '    Date_TXT.Focus()
        'End If 

    End Sub
    Public VC_Name As String
    Public VC_Under As String
    Public vc_start As String
    Public VC_VoucherNo_Method As String
    Public VC_VoucherNo_Frist As String
    Public VC_VoucherNo_Last As String
    Public VC_YN_Narration_Cell As String

    Public cfg_YN_Duplicate_No As Boolean = False
    Public cfg_YN_zero As Boolean = False
    Public cfg_YN_narration As Boolean = False
    Public cfg_print_head As String = ""
    Public cfg_print_type As String = ""
    Public cfg_YN_Order_details As Boolean = False
    Public cfg_YN_GST As Boolean = False
    Public cfg_YN_Ewaybill As Boolean = False
    Public cfg_YN_Transport As Boolean = False
    Public cfg_YN_Payment_Details As Boolean = False
    Public cfg_rate_valuation As String = ""
    Public cfg_Roud_Up As String = ""
    Public cfg_warning__credil_expiar As Boolean = False
    Public cfg_warning__Stock As Boolean = False

    Public cfg_print_derect As Boolean = False
    Public cfg_print_signature As Boolean = False
    Public cfg_print_stamp As Boolean = False
    Public cfg_YN_print_pay_qry As Boolean = False
    Public cfg_print_pay_value As String = ""
    Public cfg_print_Terms_Conditions As String = ""
    Public cfg_print_Provisnoal As String = ""
    Public cfg_YN_print_item_MRP As Boolean = False
    Public cfg_YN_Barcode As Boolean = False
    Public cfg_communication_yn As Boolean = False
    Public cfg_alter_account_details As Boolean = False
    Public YN_item_description As Boolean = False

    Public cfg_YN_Stock_Journal_Production As Boolean = False

    Public cfg_print_path As String = ""
    Public cfg_Print_format As String = ""

    Public cfg_Item_Discount As Boolean = False


    Private Function Cfg_Link()
        Dim cn As New SQLiteConnection()
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select * From TBL_Voucher_Create where id = '{VC_Formate_ID}' and {Company_Visible_Filter()}", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                VC_Name = r("Name").ToString
                VC_Under = r("Under").ToString
                VC_VoucherNo_Method = r("Voucher_No_Method").ToString
                VC_VoucherNo_Frist = r("Voucher_No_Prefix").ToString
                VC_VoucherNo_Last = r("Voucher_No_Suffix").ToString
                vc_start = r("Voucher_Start").ToString
                VC_YN_Narration_Cell = r("YN_Narration_Cell").ToString


                cfg_YN_zero = YN_Boolean(r("Zerol_Value").ToString)
                cfg_YN_Duplicate_No = YN_Boolean(r("Duplicate_No").ToString)
                cfg_YN_narration = YN_Boolean(r("YN_Narration").ToString)
                cfg_print_head = (r("Print_Head").ToString)
                cfg_print_type = (r("Print_Type").ToString)
                cfg_YN_Order_details = YN_Boolean(r("Order_YN").ToString)
                cfg_YN_GST = YN_Boolean(r("YN_GST").ToString)
                cfg_YN_Ewaybill = YN_Boolean(r("YN_EwayBill").ToString)
                cfg_YN_Transport = YN_Boolean(r("YN_Transport").ToString)
                cfg_YN_Payment_Details = YN_Boolean(r("Payment_Details_YN").ToString)
                cfg_rate_valuation = (r("Rate_Valuation").ToString)
                cfg_Roud_Up = (r("Round_Vlu").ToString)
                cfg_warning__credil_expiar = YN_Boolean(r("YN_Credit_Limit_Warning").ToString)
                cfg_warning__Stock = YN_Boolean(r("YN_Stock_Warning").ToString)

                cfg_print_derect = YN_Boolean(r("Print_after_seve").ToString)
                cfg_print_signature = YN_Boolean(r("Print_Signature").ToString)
                cfg_print_stamp = YN_Boolean(r("Print_Stamp").ToString)
                cfg_YN_print_pay_qry = YN_Boolean(r("Print_UPI_QR").ToString)
                cfg_print_Provisnoal = (r("Print_Provisional").ToString)
                cfg_print_pay_value = (r("Print_UPI_QR_Value").ToString)
                cfg_print_Terms_Conditions = (r("Print_Terms_Conditions").ToString)
                cfg_print_path = (r("Print_Path").ToString)
                cfg_Print_format = (r("Print_format").ToString)
                cfg_YN_print_item_MRP = YN_Boolean(r("Print_Item_MRP").ToString)
                cfg_YN_Barcode = YN_Boolean(r("Barcode_YN").ToString)
                cfg_YN_Stock_Journal_Production = YN_Boolean(r("Stock_Journal_Production_YN").ToString)
                cfg_communication_yn = YN_Boolean(r("Communication_YN").ToString)
                cfg_alter_account_details = YN_Boolean(r("YN_Account_Details_Alter").ToString)
                YN_item_description = YN_Boolean(r("YN_item_description").ToString)
                cfg_Item_Discount = YN_Boolean(r("YN_item_Discount").ToString)



                If cfg_print_head.Trim = Nothing Then
                    cfg_print_head = VC_Formate
                End If

            End While
        End If

        If To_Country.ToLower = "india" Or To_Country = Nothing Then
        Else
            If Export_LUT_No <> Nothing Then
                cfg_YN_GST = False
            End If
        End If


        If cfg_Roud_Up = Nothing Then
            cfg_Roud_Up = "Not Applicable"
        End If


        Voucher_Name_LB.Text = VC_Name
        Voucher_Type_LB.Text = VC_Under

        Narration_TXT.Visible = cfg_YN_narration
        Label9.Visible = cfg_YN_narration

        Other_Fechers_(cfg_YN_Transport, Transport_Panel)
        Other_Fechers_(cfg_YN_Payment_Details, Payment_Details_Panel)

        If Voucher_all_inventory() = True Then
            Sp_controls1.Refresh_cfg()
            'Sp_controls1.Closing_Fill()
            Sp_controls1.Vc_GST_summary_ctrl1.Visible = cfg_YN_GST
            Sp_controls1.SUM()
        End If

        Ledger_List_Value = Find_DT_Value(Database_File.lnk, "cfg_Vouchers", "Value", "[Name] = 'List Display Value'")


        Order_No_Panel.Visible = cfg_YN_Order_details

        Panel11.Visible = cfg_alter_account_details

    End Function
    Public Function Voucher_type_() As String
        With VC_Formate
            If .ToString = "Inward Register" Or .ToString = "Purchase Order" Or .ToString = "Purchase" Or .ToString = "Sales Return" Or .ToString = "Credit Note" Then
                Return "Inward"
            ElseIf .ToString = "Outward Register" Or .ToString = "Sales Order" Or .ToString = "Sales" Or .ToString = "Purchase Return" Or .ToString = "Debit Note" Then
                Return "Outward"
            End If
        End With
    End Function
    Public Function Voucher_all_inventory() As Boolean
        With VC_Formate
            If .ToString = "Inward Register" Or .ToString = "Purchase Order" Or .ToString = "Purchase" Or .ToString = "Sales Return" Or .ToString = "Debit Note" Or .ToString = "Outward Register" Or .ToString = "Sales Order" Or .ToString = "Sales" Or .ToString = "Purchase Return" Or .ToString = "Credit Note" Then
                Return True
            Else
                Return False
            End If
        End With
    End Function
    Private Sub Voucher_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End
        Add_Hander_Remove_Handel(False)
        'Frm_foCus()
    End Sub

    'Button Managment Proccess||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
    Private Function Button_Manage()
        Button_Clear()
        BG_frm.B_1.Text = "&E : Exit"
        BG_frm.B_2.Text = "&S : Save"
        If Communication_YN = True Then
            BG_frm.B_5.Text = "|&O : Commun."
        End If
        BG_frm.B_6.Text = "|&P : Print"
        If VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close" Then
            BG_frm.B_3.Text = "&D : Delete"
        End If
        If Login_Type = "Admin Account" And (VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close") Then
            'BG_frm.B_7.Text = "|&O : Audit"
        End If
        BG_frm.R_2.Text = "F2 : Date"
        BG_frm.R_3.Text = "|&M : Merge Voucher"
        If cfg_YN_Barcode = True Then
            BG_frm.B_8.Text = "|&B : Barcode"
        End If


        BG_frm.R_5.Text = "F3 : Purchase"
        BG_frm.R_6.Text = "|F3 : Sales"

        BG_frm.R_7.Text = "F4 : Purchase Order"
        BG_frm.R_8.Text = "|F4 : Sales Order"

        BG_frm.R_9.Text = "F5 : Credit Note"
        BG_frm.R_10.Text = "|F5 : Debit Note"

        BG_frm.R_11.Text = "F6 : Inward Register"
        BG_frm.R_12.Text = "|F6 : Outward Register"

        BG_frm.R_13.Text = "F7 : Stock Journal"

        BG_frm.R_14.Text = "F10 : Other Vouchers"


        BG_frm.R_22.Text = "F12 : Configuration"
    End Function
    Private Function Add_Hander_Remove_Handel(Ans As Boolean)
        If Ans = True Then
            AddHandler BG_frm.KeyDown, AddressOf Me.BG_Keydown
            AddHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            AddHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
            AddHandler BG_frm.B_3.Click, AddressOf Me.B_3_Click
            AddHandler BG_frm.B_5.Click, AddressOf Me.B_5_Click
            AddHandler BG_frm.B_6.Click, AddressOf Me.B_6_Click

            If Login_Type = "Admin Account" And (VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close") Then
                AddHandler BG_frm.B_7.Click, AddressOf Me.B_7_Click
            End If
            If cfg_YN_Barcode = True Then
                AddHandler BG_frm.B_8.Click, AddressOf Me.B_8_Click
            End If

            AddHandler BG_frm.R_5.Click, AddressOf Me.Purchase_btn
            AddHandler BG_frm.R_6.Click, AddressOf Me.Sales_btn
            AddHandler BG_frm.R_7.Click, AddressOf Me.Purchase_Order_btn
            AddHandler BG_frm.R_8.Click, AddressOf Me.Sales_Order_btn
            AddHandler BG_frm.R_9.Click, AddressOf Me.Credit_Note_btn
            AddHandler BG_frm.R_10.Click, AddressOf Me.Debit_Note_btn
            AddHandler BG_frm.R_11.Click, AddressOf Me.Inward_Register_btn
            AddHandler BG_frm.R_12.Click, AddressOf Me.Outward_Register_btn
            AddHandler BG_frm.R_13.Click, AddressOf Me.Stock_Journal_btn

            AddHandler BG_frm.R_14.Click, AddressOf Me.Other_Vch_btn


            AddHandler BG_frm.R_2.Click, AddressOf Me.R_2_Click
            AddHandler BG_frm.R_3.Click, AddressOf Me.R_3_Click
            AddHandler BG_frm.R_22.Click, AddressOf Me.R_22_Click
        Else
            RemoveHandler BG_frm.KeyDown, AddressOf Me.BG_Keydown
            RemoveHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            RemoveHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
            RemoveHandler BG_frm.B_3.Click, AddressOf Me.B_3_Click
            RemoveHandler BG_frm.B_5.Click, AddressOf Me.B_5_Click
            RemoveHandler BG_frm.B_6.Click, AddressOf Me.B_6_Click

            RemoveHandler BG_frm.B_7.Click, AddressOf Me.B_7_Click
            RemoveHandler BG_frm.B_8.Click, AddressOf Me.B_8_Click


            RemoveHandler BG_frm.R_5.Click, AddressOf Me.Purchase_btn
            RemoveHandler BG_frm.R_6.Click, AddressOf Me.Sales_btn
            RemoveHandler BG_frm.R_7.Click, AddressOf Me.Purchase_Order_btn
            RemoveHandler BG_frm.R_8.Click, AddressOf Me.Sales_Order_btn
            RemoveHandler BG_frm.R_9.Click, AddressOf Me.Credit_Note_btn
            RemoveHandler BG_frm.R_10.Click, AddressOf Me.Debit_Note_btn
            RemoveHandler BG_frm.R_11.Click, AddressOf Me.Inward_Register_btn
            RemoveHandler BG_frm.R_12.Click, AddressOf Me.Outward_Register_btn
            RemoveHandler BG_frm.R_13.Click, AddressOf Me.Stock_Journal_btn

            RemoveHandler BG_frm.R_14.Click, AddressOf Me.Other_Vch_btn


            RemoveHandler BG_frm.R_2.Click, AddressOf Me.R_2_Click
            RemoveHandler BG_frm.R_3.Click, AddressOf Me.R_3_Click
            RemoveHandler BG_frm.R_22.Click, AddressOf Me.R_22_Click
        End If
    End Function
    Private Sub BG_Keydown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.F2 Then
            BG_frm.R_2.PerformClick()
        End If

        If e.KeyCode = Keys.F3 AndAlso e.Modifiers = Keys.Alt Then

        ElseIf e.KeyCode = Keys.F3 AndAlso e.Modifiers = Keys.Control Then
            BG_frm.R_6.PerformClick()
        ElseIf e.KeyCode = Keys.F3 Then
            BG_frm.R_5.PerformClick()
        End If

        If e.KeyCode = Keys.F4 AndAlso e.Modifiers = Keys.Alt Then

        ElseIf e.KeyCode = Keys.F4 AndAlso e.Modifiers = Keys.Control Then
            BG_frm.R_8.PerformClick()
        ElseIf e.KeyCode = Keys.F4 Then
            BG_frm.R_7.PerformClick()
        End If

        If e.KeyCode = Keys.F5 AndAlso e.Modifiers = Keys.Alt Then

        ElseIf e.KeyCode = Keys.F5 AndAlso e.Modifiers = Keys.Control Then
            BG_frm.R_10.PerformClick()
        ElseIf e.KeyCode = Keys.F5 Then
            BG_frm.R_9.PerformClick()
        End If

        If e.KeyCode = Keys.F6 AndAlso e.Modifiers = Keys.Alt Then

        ElseIf e.KeyCode = Keys.F6 AndAlso e.Modifiers = Keys.Control Then
            BG_frm.R_12.PerformClick()
        ElseIf e.KeyCode = Keys.F6 Then
            BG_frm.R_11.PerformClick()
        End If

        If e.KeyCode = Keys.F7 AndAlso e.Modifiers = Keys.Alt Then

        ElseIf e.KeyCode = Keys.F7 AndAlso e.Modifiers = Keys.Control Then

        ElseIf e.KeyCode = Keys.F7 Then
            BG_frm.R_13.PerformClick()
        End If

        If e.KeyCode = Keys.F10 AndAlso e.Modifiers = Keys.Alt Then

        ElseIf e.KeyCode = Keys.F10 AndAlso e.Modifiers = Keys.Control Then

        ElseIf e.KeyCode = Keys.F10 Then
            BG_frm.R_14.PerformClick()
        End If

        If e.KeyCode = Keys.F12 AndAlso e.Modifiers = Keys.Alt Then

        ElseIf e.KeyCode = Keys.F12 AndAlso e.Modifiers = Keys.Control Then

        ElseIf e.KeyCode = Keys.F12 Then
            BG_frm.R_22.PerformClick()
        End If

        If e.KeyCode = Keys.O AndAlso e.Modifiers = Keys.Alt Then

        ElseIf e.KeyCode = Keys.O AndAlso e.Modifiers = Keys.Control Then
            BG_frm.B_5.PerformClick()
        ElseIf e.KeyCode = Keys.O Then
        End If


    End Sub

    Private Sub Purchase_btn(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Cell("Filter", "Change Voucher:Purchase", BG_frm.HADE_TXT.Text)
        End If
    End Sub
    Private Sub Sales_btn(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Cell("Filter", "Change Voucher:Sales", BG_frm.HADE_TXT.Text)
        End If
    End Sub

    Private Sub Purchase_Order_btn(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Cell("Filter", "Change Voucher:Purchase Order", BG_frm.HADE_TXT.Text)
        End If
    End Sub
    Private Sub Sales_Order_btn(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Cell("Filter", "Change Voucher:Sales Order", BG_frm.HADE_TXT.Text)
        End If
    End Sub
    Private Sub Credit_Note_btn(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Cell("Filter", "Change Voucher:Credit Note", BG_frm.HADE_TXT.Text)
        End If
    End Sub
    Private Sub Debit_Note_btn(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Cell("Filter", "Change Voucher:Debit Note", BG_frm.HADE_TXT.Text)
        End If
    End Sub

    Private Sub Inward_Register_btn(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Cell("Filter", "Change Voucher:Inward Register", BG_frm.HADE_TXT.Text)
        End If
    End Sub

    Private Sub Outward_Register_btn(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Cell("Filter", "Change Voucher:Outward Register", BG_frm.HADE_TXT.Text)
        End If
    End Sub

    Private Sub Stock_Journal_btn(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Cell("Filter", "Change Voucher:Stock Journal", BG_frm.HADE_TXT.Text)
        End If
    End Sub

    Private Sub Other_Vch_btn(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Cell("Filter", "Change Voucher:All Vouchers", BG_frm.HADE_TXT.Text)
        End If
    End Sub


    Private Sub B_1_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Me.Dispose()
        End If
    End Sub

    Private Sub B_2_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            If Ledger_Credit_Expire_Action = "No Save" And Credit_Warning = True Then
                Msg(NOT_Type.Warning, "Credit Limit Expired !", "The credit limit of your selected ledger '" & Account_TXT.Text & "' was set at Rs " & "" & ", as per the voucher the credit of '" & Account_TXT.Text & "' has increased to Rs " & Label28.Text & ".")
                Account_TXT.Focus()
                Exit Sub
            End If
            Save_Data()
        ElseIf BG_frm.HADE_TXT.Text = "Ledger Details" Then
            Account_TXT.Focus()
        End If
    End Sub
    Private Sub B_7_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Cell("Audit Analysis", "", Voucher_Type_LB.Text, Tra_ID)
        End If
    End Sub
    Private Sub B_8_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            vb_barcode_frm.ShowDialog()
        End If
    End Sub
    Private Sub B_3_Click(sender As Object, e As EventArgs)
        If VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close" Then
            If BG_frm.From_ID = From_ID Then
                If Msg_Delete_YN(Voucher_No_TXT, Voucher_Name_LB.Text) = DialogResult.Yes Then
                    If Delete_Vouchers(Tra_ID, Voucher_Type_LB.Text) = True Then
                        Dim cn As New SQLiteConnection
                        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                            'BG_frm.Voucher_BS.DataSource = Nothing
                            'BG_frm.Voucher_BS.DataSource = Fill_Vouchhers(cn)
                        End If
                        Clear_all()
                    Else
                        Msg(NOT_Type.Erro, Not_Delete_Error_head, Not_Delete_Error_msg)
                    End If
                End If
            End If
        End If
    End Sub
    Private Function Chack_Delete_Allow() As Boolean
        If Chack_Duplicate(Database_File.cre, "TBL_VC", "ID", "(Order_No = '" & Tra_ID & "' or Register_No = '" & Tra_ID & "') and (Visible = 'Approval' OR Visible = 'Pending')") = True Then
            Return False
        End If
        Return True
    End Function
    Private Sub B_5_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Communication_send()
        End If
    End Sub
    Private Sub B_6_Click(sender As Object, e As EventArgs)
        Dim vl As String
        If Save_Requr() = True Then
            Print_Page()
        End If
    End Sub
    Public Print_IVC_No_ As String
    Public Supp_GST As String
    Public Supp_PAN As String
    Public Supp_Bank As String
    Public Supp_BankAcc As String
    Public Supp_IFSC As String
    Public Supp_Branch As String

    Public TOTAL_AMOUNT_VALUE As Decimal = 0.00

    Dim m_currentPageIndex As Integer
    Dim m_streams As IList(Of Stream)
    Private rdlc_report_data() As ReportDataSource
    Private rdlc_report_name As String
    Private Sub B_Print()
        'Dim Head_ As String = Find_DT_Value(Database_File.lnk, "prt_Vouchers", "Value", "Filter = 'SP' AND Name = 'Title'")
        'Dim Type_ As String = Find_DT_Value(Database_File.lnk, "TBL_Print", "Value", "Filter = 'SP' AND Name = 'Type'")
        'Dim QR_Data_ As String = Find_DT_Value(Database_File.lnk, "TBL_Print", "Value", "Filter = 'Voucher' AND Name = 'QR Code'")
        'Dim Stamp_Sig_ As String = Find_DT_Value(Database_File.lnk, "TBL_Print", "Value", "Filter = 'Voucher' AND Name = 'Stamp & Signature'")
        'Dim Prov_Bal_YN As String = Find_DT_Value(Database_File.lnk, "TBL_Print", "Value", "Filter = 'Voucher' AND Name = 'Provisional Balance'")
        'Dim Trams_Condition As String = Find_DT_Value(Database_File.lnk, "TBL_Print", "Value", "Filter = 'SP' AND Name = 'Terms & Conditions'")

        Dim Account_ As String

        If Voucher_type_() = "Inward" Then
            Print_IVC_No_ = supplier_vc_no
            'Account_ = Company_Name_str
            Supp_GST = Find_DT_Value(Database_File.cre, "TBL_Ledger", "GSTNo", "ID = '" & Acc_ID & "'")
            Supp_PAN = Find_DT_Value(Database_File.cre, "TBL_Ledger", "PANCardNo", "ID = '" & Acc_ID & "'")
            Supp_Bank = Find_DT_Value(Database_File.cre, "TBL_Ledger", "BankName", "ID = '" & Acc_ID & "'")
            Supp_BankAcc = Find_DT_Value(Database_File.cre, "TBL_Ledger", "AccountNo", "ID = '" & Acc_ID & "'")
            Supp_Branch = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Branch", "ID = '" & Acc_ID & "'")
            Supp_IFSC = Find_DT_Value(Database_File.cre, "TBL_Ledger", "IFSCCode", "ID = '" & Acc_ID & "'")
        Else
            Print_IVC_No_ = Voucher_No_TXT.Text
            Supp_GST = Find_DT_Value(Database_File.cmp, "TBL_Company_Creation", "GSTNo", "Company_ID = '" & Company_ID_str & "'")
            Supp_PAN = Find_DT_Value(Database_File.cmp, "TBL_Company_Creation", "PANCard", "Company_ID = '" & Company_ID_str & "'")
            Supp_Bank = Find_DT_Value(Database_File.cmp, "TBL_Company_Creation", "Bank", "Company_ID = '" & Company_ID_str & "'")
            Supp_BankAcc = Find_DT_Value(Database_File.cmp, "TBL_Company_Creation", "AccountNo", "Company_ID = '" & Company_ID_str & "'")
            Supp_Branch = Find_DT_Value(Database_File.cmp, "TBL_Company_Creation", "Branch", "Company_ID = '" & Company_ID_str & "'")
            Supp_IFSC = Find_DT_Value(Database_File.cmp, "TBL_Company_Creation", "IFCCode", "Company_ID = '" & Company_ID_str & "'")
        End If

        Account_ = To_Name

        If Tra_ID = Nothing Then
            Tra_ID = Tra_ID_Search(Tra_ID, VC_Type_)
        End If

        Dim ds As New Print_dt
        Dim dt As New DataTable
        Dim dr As DataRow
        'QR_COde

        Dim gen As New QRCodeGenerator
        Dim QR_ID As String

        QR_ID = $"No.:{Voucher_No_TXT.Text};Date:{CDate(Date_TXT.Text).ToString("dd-MM-yyyy")};Type:{Voucher_Type_LB.Text};Amount:{Val(Sp_controls1.Amounr_Label.Text)};"


        Dim QR = gen.CreateQrCode(QR_ID, QRCodeGenerator.ECCLevel.Q)
        Dim Q_Code As New QRCode(QR)
        Dim img_QR As Image
        img_QR = Q_Code.GetGraphic(6)

        Dim img_stm_QR As MemoryStream = New MemoryStream
        'If QR_Data_ <> "Not Applicable" Then
        img_QR.Save(img_stm_QR, Imaging.ImageFormat.Png)
        'End If

        'Barcode
        Dim Barc As Barcode = New Barcode()
        Dim forcolore As Color = Color.Black
        Dim backcolore As Color = Color.Transparent

        If Print_IVC_No_ = Nothing Then
            Print_IVC_No_ = "N/A"
        End If

        Dim img As Image
        img = (Barc.Encode(TYPE.CODE128, Print_IVC_No_, forcolore, backcolore, CInt(302), CInt(82)))
        Dim img_barcode_stm As MemoryStream = New System.IO.MemoryStream
        img.Save(img_barcode_stm, Imaging.ImageFormat.Png)

        Dim img_provinoal As Image
        img_provinoal = (Barc.Encode(TYPE.CODE128, Label8.Text, forcolore, backcolore, CInt(302), CInt(82)))
        Dim img_barcode_provinoal As MemoryStream = New System.IO.MemoryStream
        img_provinoal.Save(img_barcode_provinoal, Imaging.ImageFormat.Png)



        Dim num As Integer = 1
        If Voucher_all_inventory() = True Then
            Dim Dt1 As New DataTable
            'TBL_ivc
            Dt1 = ds.Tables("TBL_ivc")
            dr = Dt1.NewRow

            dr("Date") = Date_TXT.Text
            dr("Day") = Day_Label.Text
            dr("Voucher_Type") = Voucher_Type_LB.Text
            dr("Voucher_No") = Print_IVC_No_
            dr("Invoice_Type") = "Original Receipt"
            dr("Account") = To_Name
            dr("Address") = To_Address1

            dr("Refrence_Type") = Label10.Text
            dr("Refrence_No") = Order_YN.Text
            dr("Print_Date") = Now.Date.ToString("dddd, dd MMMM,yyyy")
            dr("Amount") = Format(Val(Sp_controls1.Amounr_Label.Text), "N2")

            Dim QR_NSU As Byte()
            QR_NSU = img_stm_QR.GetBuffer

            dr("QR") = QR_NSU

            'UPI Code
            SET_UPI_ivc(dr)


            Dt1.Rows.Add(dr)

            Dim BATcode_NSU As Byte()
            BATcode_NSU = img_barcode_stm.GetBuffer

            Dim BATcode_Provisnoal As Byte()
            BATcode_Provisnoal = img_barcode_provinoal.GetBuffer

            dr("Barcode") = BATcode_NSU
            dr("Provinoal_Barcode") = BATcode_Provisnoal
            'Item Details nsurdt
            Dim Dt2 As New DataTable
            Dt2 = ds.Tables("TBL_ivc_item_details")

            Dim P_ As New Queue(Of sp_control_under)()
            For Each bg_p As sp_control_under In Sp_controls1.stock_panel.Controls.OfType(Of sp_control_under)()
                P_.Enqueue(bg_p)
            Next

            For Each c As sp_control_under In P_.Reverse

                Dim particuls_ As String = c.Item_TXT.Text
                Dim description_ As String = c.Discription_Label.Text
                'Dim pack_per As String = Find_DT_Value(Database_File.cre, "TBL_Stock_Item", "Alter_Unit_val1", $"Name = '{particuls_}'")
                Dim qty_ As String = c.Qty_TXT.Text
                Dim Unit_ As String = c.Unit_Lst.Text
                Dim Rate_ As String = c.Rate_TXT.Text
                Dim Discount_per As String = c.DiscountP_TXT.Text
                Dim Discount_amt As String = c.DiscountP_TXT.Data_Link_
                Dim GST_per As String = c.GST_Per
                Dim GST_amt As String = c.GST_Amount
                Dim cess_per As String = c.Cess_Per
                Dim cess_amt As String = c.Cess_Amount
                Dim subtotal_ As String = c.Amount_TXT.Text
                Dim Unit2_ As String = $"{c.Qty_Alte_Lab.Text} {c.Unit_Alte_Lab.Text}"
                Dim mRP As Decimal = Val(Find_DT_Value(Database_File.cre, "TBL_Stock_Item", "MRP", "Name = '" & particuls_ & "' and " & Company_Visible_Filter()))
                dr = Dt2.NewRow

                If cfg_YN_GST = False Then
                    GST_per = 0
                    GST_amt = 0
                End If


                dr("ID") = num
                dr("Item") = particuls_
                dr("HSN") = Find_DT_Value(Database_File.cre, "TBL_Stock_Item", "HSN_Code", "Name = '" & particuls_ & "' and " & Company_Visible_Filter())
                If cfg_YN_print_item_MRP = True And mRP <> 0 Then
                    dr("MRP") = vbNewLine & "     M.R.P. : " & N2_FORMATE(mRP)
                Else
                    dr("MRP") = ""
                End If
                If description_.Trim <> Nothing Then
                    dr("Description") = vbNewLine & description_
                Else
                    dr("Description") = ""
                End If
                dr("Quantity") = Format(Val(qty_), "N2")
                dr("Unit") = Unit_
                dr("Rate") = Format(Val(Rate_), "N2")
                dr("Subtotal") = Format(Val(subtotal_), "N2")
                If nUmBeR_FORMATE(GST_amt) <> 0 Then
                    dr("Discount_P") = $"{Format(Val(Discount_per), "N2")}%"
                    dr("Discount_A") = $"{vbNewLine}{Format(Val(Discount_amt), "N2")}₹"
                Else
                    dr("Discount_P") = ""
                    dr("Discount_A") = ""
                End If

                If nUmBeR_FORMATE(GST_amt) <> 0 Then
                    dr("GST") = $"{Format(Val(GST_per), "N2")}%"
                    dr("GST_Amt") = $"{vbNewLine}{Format(Val(GST_amt), "N2")}₹"
                Else
                    dr("GST") = ""
                    dr("GST_Amt") = ""
                End If

                dr("Amount") = Format(Val(subtotal_) + Val(GST_amt), "N2")
                dr("Category") = ""
                dr("Batch_No") = ""

                dr("Subtotal_Total") = Format(Val(Sp_controls1.sub_total_label.Text), "N2")
                dr("GST_Amt_Total") = Format(Val(Sp_controls1.Label7.Text), "N2")
                dr("Amount_Total") = Format(Val(Val(Sp_controls1.Amounr_Label.Text)), "N2")


                If Unit2_ <> Nothing Then
                    dr("Qty2") = $"{vbNewLine}{Unit2_.Split(" ")(0)}"
                    dr("Unit2") = $"{vbNewLine}{Unit2_.Split(" ")(1)}"
                Else
                    dr("Qty2") = ""
                    dr("Unit2") = ""
                End If

                Dt2.Rows.Add(dr)

                num += 1
            Next
            'Exp Details nsurdt
            Dim Dt3 As New DataTable
            Dt3 = ds.Tables("TBL_ivc_exp")
            Dim nu As Integer = 1

            Dim P1_ As New Queue(Of Panel)()
            For Each bg_p As Panel In Sp_controls1.exp_panel.Controls.OfType(Of Panel)()
                P1_.Enqueue(bg_p)
            Next

            For Each bg_p As Panel In P1_.Reverse
                Dim idx As Integer = Sp_controls1.Find_Idx(bg_p)

                Dim name_ As String = Sp_controls1.Find_exp_TXT(idx).Text
                Dim vlu_ As String = Sp_controls1.Find_exp_amt_TXT(idx).Text
                dr = Dt3.NewRow
                dr("ID") = nu
                dr("Name") = name_
                dr("Value") = Format(Val(Val(vlu_)), "N2")
                Dt3.Rows.Add(dr)
                nu += 1
            Next
            'GST_Summary Details nsurdt
            Dim dt4 As New DataTable
            dt4 = ds.Tables("TBL_ivc_gst")


            rdlc_report_name = $"{Voucher_Type_LB.Text}({Voucher_No_TXT.Text})"
            rdlc_report_name = path_validation(rdlc_report_name, "-")

            rdlc_report_data = {New ReportDataSource("DataSet1", Dt1),
                New ReportDataSource("dt_item_details", Dt2),
                New ReportDataSource("dt_exp", Dt3),
                New ReportDataSource("dt_gst", dt4),
                New ReportDataSource("dt_cmp", Print_DT_Company)}

            Print_Path_setup()

        End If
    End Sub
    Private Function Print_Path_setup()
        If Voucher_Type_LB.Text = "Sales" Or Voucher_Type_LB.Text = "Purchase" Then
            If cfg_print_path = Nothing Then
                cfg_print_path = Application.StartupPath & "\Print_\Voucher\ivc\ivc"
            End If
        ElseIf Voucher_Type_LB.Text = "Sales Order" Or Voucher_Type_LB.Text = "Purchase Order" Then
            If cfg_print_path = Nothing Then
                cfg_print_path = Application.StartupPath & "\Print_\Voucher\order\Order_A4"
            End If
        ElseIf Voucher_Type_LB.Text = "Inward Register" Or Voucher_Type_LB.Text = "Outward Register" Then
            If cfg_print_path = Nothing Then
                cfg_print_path = Application.StartupPath & "\Print_\Voucher\register\register_A4"
            End If

        End If



    End Function
    Public Function Print_Register_Details() As String
        Dim str As String = ""
        If Register_Panel.Visible = False Then
            str = "Not Applicable"
        Else
            If VC_Formate = "Sales" Or VC_Formate = "Outward Register" Then
                str = $"OW No. : {Label38.Text}"
            ElseIf VC_Formate = "Purchase" Or VC_Formate = "Inward Register" Then
                str = $"PO No. : {Label38.Text}"
            End If

            str &= $"{vbNewLine}Date : {Label37.Text}"
        End If


        Return str
    End Function
    Public Function Print_Order_Details() As String
        Dim str As String = ""
        If Order_Panel.Visible = False Then
            str = "Not Applicable"
        Else
            If VC_Formate = "Sales" Or VC_Formate = "Outward Register" Then
                str = $"SO No. : {Label29.Text}"
            ElseIf VC_Formate = "Purchase" Or VC_Formate = "Inward Register" Then
                str = $"PO No. : {Label29.Text}"
            End If

            str &= $"{vbNewLine}Date : {Label30.Text}"
        End If


        Return str
    End Function
    Public Function Print_Page()
        B_Print()
        Printing_Direct_frm.Frm_ = Me
        Printing_Direct_frm.cfg_frm = New ivc_Print_cfg_ctrl
        Dim Nm As String = path_validation($"{VC_Formate} ({Voucher_No_TXT.Text})", "_")
        Printing_Direct_frm.Printing_(cfg_print_path, rdlc_report_name, Nm, rdlc_report_data)
    End Function
    Private Function CreateStream(name As String, extension As String, encoding As Encoding, mimeType As String, willSeek As Boolean) As Stream
        Throw New NotImplementedException()
    End Function

    Private Function SET_UPI_ivc(dr As DataRow)
        Dim gen As New QRCodeGenerator
        'Dim UPI_YN As String = Find_DT_Value(Database_File.lnk, "TBL_Print", "Value", "Filter = 'SP' AND Name = 'UPI QR Code'")
        Dim UPI_YN As String = "Current Value"

        If UPI_YN = "Not Applicable" Then

        ElseIf UPI_YN = "Manual Pay" Then
            UPI_YN = "upi://pay?pa=" & Company_UPI_str
        ElseIf UPI_YN = "Current Value" Then
            UPI_YN = "upi://pay?pa=" & Company_UPI_str & "&pn=" & Company_Name_str & "&am=" & Val(Sp_controls1.Amounr_Label.Text) & "&cu=INR&"
        ElseIf UPI_YN = "Provisional Value" Then
            Dim vlu As String = Val(Acc_Balance) + Val(Sp_controls1.Amounr_Label.Text)

            UPI_YN = "upi://pay?pa=" & Company_UPI_str & "&pn=" & Company_Name_str & "&am=" & Val(vlu) & "&cu=INR&"
        End If

        Dim QR = gen.CreateQrCode(UPI_YN, QRCodeGenerator.ECCLevel.Q)
        Dim Q_Code As New QRCode(QR)
        Dim img_QR As Image
        img_QR = Q_Code.GetGraphic(6)

        Dim img_stm_QR As System.IO.MemoryStream = New System.IO.MemoryStream
        If UPI_YN <> "Not Applicable" Then
            img_QR.Save(img_stm_QR, System.Drawing.Imaging.ImageFormat.Png)
        End If

        Dim QR_NSU As Byte()
        QR_NSU = img_stm_QR.GetBuffer

        dr("QR_Pay") = QR_NSU
    End Function
    Public Function Print_Address_set(ID As String) As String

        Dim Address_ As String
        Dim Phone_ As String
        Dim Email_ As String
        Dim GST_ As String
        Dim PAN_ As String

        'If Voucher_Type_LB.Text = "Purchase" Or Voucher_Type_LB.Text = "Sales Return" Then
        'Address_ = Find_DT_Value(Database_File.cmp, "TBL_Company_Creation", "Address", "Company_ID = '" & Company_ID_str & "'")
        'Phone_ = Find_DT_Value(Database_File.cmp, "TBL_Company_Creation", "Phone", "Company_ID = '" & Company_ID_str & "'")
        'Email_ = Find_DT_Value(Database_File.cmp, "TBL_Company_Creation", "Email", "Company_ID = '" & Company_ID_str & "'")
        'GST_ = Find_DT_Value(Database_File.cmp, "TBL_Company_Creation", "GSTNo", "Company_ID = '" & Company_ID_str & "'")
        'PAN_ = Find_DT_Value(Database_File.cmp, "TBL_Company_Creation", "PANCard", "Company_ID = '" & Company_ID_str & "'")
        'Else

        Address_ = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Address", "ID = '" & ID & "'")
        Phone_ = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Phone", "ID = '" & ID & "'")
        Email_ = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Email", "ID = '" & ID & "'")
        GST_ = Find_DT_Value(Database_File.cre, "TBL_Ledger", "GSTNo", "ID = '" & ID & "'")
        PAN_ = Find_DT_Value(Database_File.cre, "TBL_Ledger", "PANCardNo", "ID = '" & ID & "'")
        'End If

        Dim St As String

        If Address_.ToString.Trim <> Nothing Then
            St = Address_
        End If
        If Phone_.ToString.Trim <> Nothing Then
            St &= "," & vbNewLine & "Phone No.  : " & Phone_
        End If
        If Email_.ToString.Trim <> Nothing Then
            St &= "," & vbNewLine & "Email : " & Email_
        End If
        If GST_.ToString.Trim <> Nothing Then
            St &= "," & vbNewLine & "GST No. : " & GST_
        End If
        If PAN_.ToString.Trim <> Nothing Then
            St &= "," & vbNewLine & "PAN No. : " & PAN_
        End If
        If St = "" Then
            St = ""
        End If
        Return St
    End Function
    Private Sub R_3_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Cell("Merge Voucher")
        End If
    End Sub
    Private Sub R_2_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Set_Date(False, Me)
        End If
    End Sub
    Public Function Apply_Date_Filter(ifPeriod As Boolean)
        Date_TXT.Text = Date_Formate(Date_3)
    End Function
    Private Sub Contra_Pass()
        Add_Hander_Remove_Handel(False)
        Link_Valu(2) = "Contra"
        Dim e As EventArgs
        Me.Voucher_frm_Load(e, e)
    End Sub
    Private Sub Sales_Order_Pass()
        Add_Hander_Remove_Handel(False)
        Link_Valu(2) = "Sales Order"
        Dim e As EventArgs
        Me.Voucher_frm_Load(e, e)
    End Sub
    Private Sub Outward_Register_Pass()
        Add_Hander_Remove_Handel(False)
        Link_Valu(2) = "Outward Register"
        Dim e As EventArgs
        Me.Voucher_frm_Load(e, e)
    End Sub
    Private Sub Sales_Pass()
        Add_Hander_Remove_Handel(False)
        Link_Valu(2) = "Sales"
        Dim e As EventArgs
        Me.Voucher_frm_Load(e, e)
    End Sub
    Private Sub Inward_Register_Pass()
        Add_Hander_Remove_Handel(False)
        Link_Valu(2) = "Inward Register"
        Dim e As EventArgs
        Me.Voucher_frm_Load(e, e)
    End Sub
    Private Sub Purchase_Order_Pass()
        Add_Hander_Remove_Handel(False)
        Link_Valu(2) = "Purchase Order"
        Dim e As EventArgs
        Me.Voucher_frm_Load(e, e)
    End Sub
    Private Sub Purchase_Pass()
        Add_Hander_Remove_Handel(False)
        Link_Valu(2) = "Purchase"
        Dim e As EventArgs
        Me.Voucher_frm_Load(e, e)
    End Sub
    Private Sub R_22_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Cell("Vouchers Configuration", "", VC_Type_, VC_Formate_ID)
        End If
    End Sub
    Private Sub Sales_Frmt()
        If BG_frm.From_ID = From_ID Then
            Voucher_Type_LB.Text = "Sales"
            Color_bg = Color.OldLace

            Bg_Panel.Dock = DockStyle.Fill

            Bg_Panel.Show()
            Voucher_Setup(VC_Formate_ID)

            Sp_controls1.Color_bg = Color_bg
            Sp_controls1.Color_manag()
        End If
    End Sub
    Private Sub Sales_Return_Frmt()
        If BG_frm.From_ID = From_ID Then
            Voucher_Type_LB.Text = "Sales Return"
            Color_bg = Color.FromArgb(255, 242, 240)

            Ship_ID = Company_ID_str


            Bg_Panel.Dock = DockStyle.Fill

            Bg_Panel.Show()
            Voucher_Setup(VC_Formate_ID)

            Sp_controls1.Color_bg = Color_bg
            Sp_controls1.Color_manag()
        End If
    End Sub
    Private Sub Sales_Order_Frmt()
        If BG_frm.From_ID = From_ID Then
            Voucher_Type_LB.Text = "Sales Order"
            Color_bg = Color.FromArgb(255, 238, 240)

            Bg_Panel.Dock = DockStyle.Fill

            Bg_Panel.Show()
            Voucher_Setup(VC_Formate_ID)

            Sp_controls1.Color_bg = Color_bg
            Sp_controls1.Color_manag()
        End If
    End Sub
    Private Sub Outward_Register_Frmt()
        If BG_frm.From_ID = From_ID Then
            Voucher_Type_LB.Text = "Outward Register"

            Color_bg = Color.FromArgb(238, 255, 255)



            Bg_Panel.Dock = DockStyle.Fill

            Bg_Panel.Show()
            Voucher_Setup(VC_Formate_ID)

            Sp_controls1.Color_bg = Color_bg
            Sp_controls1.Color_manag()
        End If
    End Sub
    Private Sub Purchase_Frmt()
        If BG_frm.From_ID = From_ID Then
            Voucher_Type_LB.Text = "Purchase"
            Ship_ID = Company_ID_str
            Color_bg = Color.FromArgb(247, 255, 245)



            Bg_Panel.Dock = DockStyle.Fill

            Bg_Panel.Show()
            Voucher_Setup(VC_Formate_ID)

            Sp_controls1.Color_bg = Color_bg
            Sp_controls1.Color_manag()
        End If
    End Sub
    Private Sub Purchase_Return_Frmt()
        If BG_frm.From_ID = From_ID Then
            Voucher_Type_LB.Text = "Purchase Return"

            Color_bg = Color.FromArgb(229, 239, 240)



            Bg_Panel.Dock = DockStyle.Fill

            Bg_Panel.Show()
            Voucher_Setup(VC_Formate_ID)

            Sp_controls1.Color_bg = Color_bg
            Sp_controls1.Color_manag()
        End If
    End Sub
    Private Sub Stock_Journal_Frmt()
        If BG_frm.From_ID = From_ID Then
            Voucher_Type_LB.Text = "Stock Journal"

            Bg_Panel.Dock = DockStyle.Fill

            Bg_Panel.Show()
            Voucher_Setup(VC_Formate_ID)

        End If
    End Sub
    Private Sub Credit_Note_Frmt()
        If BG_frm.From_ID = From_ID Then
            Voucher_Type_LB.Text = "Credit Note"

            Color_bg = Color.FromArgb(229, 239, 240)

            Bg_Panel.Dock = DockStyle.Fill

            Bg_Panel.Show()
            Voucher_Setup(VC_Formate_ID)

            Sp_controls1.Color_bg = Color_bg
            Sp_controls1.Color_manag()
        End If
    End Sub
    Private Sub Debit_Note_Frmt()
        If BG_frm.From_ID = From_ID Then
            Voucher_Type_LB.Text = "Debit Note"

            Color_bg = Color.FromArgb(244, 245, 254)


            Bg_Panel.Dock = DockStyle.Fill

            Bg_Panel.Show()
            Voucher_Setup(VC_Formate_ID)

            Sp_controls1.Color_bg = Color_bg
            Sp_controls1.Color_manag()
        End If
    End Sub

    Private Sub Purchase_Order_Frmt()
        If BG_frm.From_ID = From_ID Then
            Voucher_Type_LB.Text = "Purchase Order"




            Bg_Panel.Dock = DockStyle.Fill

            Bg_Panel.Show()
            Voucher_Setup(VC_Formate_ID)

            Sp_controls1.Color_bg = Color_bg
            Sp_controls1.Color_manag()
        End If
    End Sub
    Private Sub Inward_Register_Frmt()
        If BG_frm.From_ID = From_ID Then
            Voucher_Type_LB.Text = "Inward Register"

            Ship_ID = Company_ID_str



            Bg_Panel.Dock = DockStyle.Fill

            Bg_Panel.Show()
            Voucher_Setup(VC_Formate_ID)


            Sp_controls1.Color_bg = Color_bg
            Sp_controls1.Color_manag()
        End If
    End Sub
    Private Function Save_Data()
        If BG_frm.From_ID = From_ID Then
            'If Chack_Duplicate(Database_File.cre, "TBL_VC", "Order_No", $"Order_No = '{Tra_ID}' and Visible = 'Approval'") = True Then
            '    Msg_Custom_YN(NOT_Location.Center, Color.Red, My.Resources.notaccess_anumation_gif, Dialoag_Button.Ok, "Error", "Voucher Error", $"Sorry, you cannot amend the {Voucher_Type_LB.Text}<nl>because it is linked to another voucher so if the {Voucher_Type_LB.Text} is amended,<nl>the voucher linked to this voucher will get an error.")

            '    Exit Function
            'End If
            If Save_Requr() = True Then
                If Audit_Vouchers(Tra_ID) = True Then
                    Tra_ID = Tra_ID_Search(Tra_ID, VC_Type_)
                    If Data_Save_Manag() = True Then
                        If Document_Save() = True Then
                            If Communication_send() = True Then
                                If Print_DIrect_Save() = True Then
                                    Clear_all()
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Function
    Private Function Print_DIrect_Save() As Boolean
        If cfg_print_derect = True Then
            Print_Page()
        End If
        Return True
    End Function
    Private Function Create_File_Name() As String
        Dim OPT_Hint As String = ((Val(Now.Date.Day) + Val(Now.Date.Millisecond) + Val(Now.Date.Second) & Val(Val(Now.TimeOfDay.Hours + Now.TimeOfDay.Minutes & Now.Date.Month + Now.Date.Day)) + Val(Val(Now.Date.Year))) - Val(Now.TimeOfDay.Seconds) + Val(Now.TimeOfDay.Milliseconds)) * 12552
        Return Val(OPT_Hint) * 999
    End Function
    Private Function Communication_send() As Boolean
        If Features_mod.Communication_YN = True And cfg_communication_yn = True Then
            If Msg_Custom_YN(NOT_Location.Bottom_Right, Color.Black, My.Resources.Communication_animation_icn, Dialoag_Button.Yes_No, "Question?", "Communication", "Do you want to send this<nl>report on WhatsApp and email") = DialogResult.Yes Then
                With Sp_controls1
                    B_Print()
                    Dim path As String = Application.StartupPath & $"\_other_savefiles\{Create_File_Name()}.pdf"
                    Export_PDF(cfg_print_path, path, rdlc_report_data)
                    Communication_Pass(path, rdlc_report_name)
                End With
                Direct_Communication_frm.ShowDialog()
            End If
        End If
        Return True
    End Function
    Private Function Communication_Pass(path_of_file As String, name_ As String)
        Dim name As String = Account_TXT.Text
        Dim id As String = Acc_ID
        Dim wh As String = ""
        Dim em As String = ""
        Dim subject As String = $"{Voucher_Name_LB.Text}({Voucher_No_TXT.Text})"
        Dim whatsapp_allow As Boolean = Chack_Communication_allow(id, "Communication_Whatsapp")
        Dim email_allow As Boolean = Chack_Communication_allow(id, "Communication_Email")

        If email_allow = True Then
            em = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Email", $"id = '{id}'")
        End If
        If whatsapp_allow = True Then
            wh = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Phone", $"id = '{id}'")
        End If

        If whatsapp_allow = True Or email_allow = True Then
            Direct_Communication_frm.Add_list(name, wh, em, subject, CDate(Date_TXT.Text).ToString("dd-MMM-yyyy"), "Document", path_of_file, path_of_file.Split(".").Last)
        End If


        If cfg_YN_GST = True Then
            If Account_Phone = Nothing Then
                whatsapp_allow = False
            Else
                whatsapp_allow = True
            End If
            If Account_Email = Nothing Then
                email_allow = False
            Else
                email_allow = True
            End If
            If whatsapp_allow = True Or email_allow = True Then
                Whatsapp_Sending_list.Add_to_list("Account", Account_Phone, Account_Email, subject, CDate(Date_TXT.Text).ToString("dd-MMM-yyyy"), "Document", path_of_file, path_of_file.Split(".").Last, "Pending", "Pending")
            End If
        End If
    End Function

    Private Function Save_Requr() As Boolean
        If Voucher_all_inventory() = True Then
            Sp_controls1.SUM()
        End If

        If Date_TXT.Text = "" Then
            NOT_("Please enter date and try agin", NOT_Type.Erro)
            Msg_Blank(Date_TXT, "Voucher Date")
            Date_TXT.Focus()
            Return False
            Exit Function
        End If
        If Voucher_all_inventory() = True Then
            If Chack_Duplicate(Database_File.cre, "TBL_Ledger", "Name", "Name = '" & Account_TXT.Text & "'") = False Then
                NOT_("Account select error, Please select again", NOT_Type.Erro)
                Msg_InputError(Account_TXT, "Account")

                Account_TXT.Focus()
                Return False
                Exit Function
            Else
                Acc_ID = Find_DT_Value(Database_File.cre, "TBL_Ledger", "ID", "Name = '" & Account_TXT.Text & "'")
            End If
            If Account_TXT.Text = "" Then
                NOT_("Please select account and try agin", NOT_Type.Erro)
                Msg_Blank(Account_TXT, "Account")
                Account_TXT.Focus()
                Return False
                Exit Function
            End If
        End If
        If Voucher_Bo_aLlow() = False Then
            NOT_("Voucher number is duplicate", NOT_Type.Erro)
            Voucher_No_TXT.Focus()
            Msg_Duplicat(Voucher_No_TXT, "Voucher No")
            Return False
            Exit Function
        End If
        If cfg_warning__credil_expiar = True Then
            If Val(Label28.Text) < 0 Then
                If Msg_Credit_Warning_Dialoag(Account_TXT.Text, (Label28.Text)) <> DialogResult.Yes Then
                    SendKeys.Send("{BACKSPACE}")
                    Return False
                End If
            End If
        End If

        If Grid_Status_Chack() = False Then
            Return False
        End If



        If Order_Type = "Inward Register" Or Order_Type = "Outward Register" Then
            Effect_Stock = False
        ElseIf Voucher_Type_LB.Text = "Sales" Or Voucher_Type_LB.Text = "Purchase" Or Voucher_Type_LB.Text = "Inward Register" Or Voucher_Type_LB.Text = "Outward Register" Or Voucher_Type_LB.Text = "Stock Journal" Or Voucher_Type_LB.Text = "Credit Note" Or Voucher_Type_LB.Text = "Debit Note" Then
            Effect_Stock = True
        Else
            Effect_Stock = False
        End If

        If Order_YN.Text <> "Yes" Then
            Order_Tra_ID = ""
            Order_Type = ""
        End If

        Return True
    End Function
    Private Function Grid_Status_Chack() As Boolean
        If Voucher_all_inventory() = True Then
            With Sp_controls1
                For Each c As sp_control_under In .stock_panel.Controls.OfType(Of sp_control_under)()
                    Dim qty As Object = c.Qty_TXT

                    If c.Item_TXT.Data_Link_ <> "" Then
                        If Val(qty.Text) <= 0 Then
                            qty.Focus()
                            Return False
                        End If
                    Else
                        c.Dispose()
                    End If
                Next

                For Each bg_p As Panel In .exp_panel.Controls.OfType(Of Panel)()
                    Dim idx As Integer = .Find_Idx(bg_p)
                    Dim itm As Object = .Find_exp_TXT(idx)
                    Dim amt As Object = .Find_exp_amt_TXT(idx)

                    If Chack_Duplicate(Database_File.cre, "TBL_Ledger", "Name", "Name = '" & itm.Text.ToString.Trim & "'") = False Or itm.Text.ToString.Trim = "" Then
                        .exp_panel.Controls.Remove(bg_p)
                    End If
                Next
            End With
        ElseIf Voucher_Type_LB.Text = "Stock Journal" Then
            For Each bg_p As Panel In Stock_journal_controls1.Source_P.Controls.OfType(Of Panel)()
                Dim idx As Integer = Stock_journal_controls1.Find_Idx(bg_p)
                Dim itm As Object = Stock_journal_controls1.Find_Particuls_TXT(idx, True)
                Dim qty As Object = Stock_journal_controls1.Find_qty_TXT(idx, True)

                If Chack_Duplicate(Database_File.cre, "TBL_Stock_Item", "Name", "Name = '" & itm.Text.ToString.Trim & "'") = False Or itm.Text.ToString.Trim = "" Then
                    Stock_journal_controls1.Source_P.Controls.Remove(bg_p)
                Else
                    If cfg_YN_zero = False Then
                        If Val(qty.Text) <= 0 Then
                            qty.Focus()
                            Return False
                        End If
                    End If
                End If
            Next

            For Each bg_p As Panel In Stock_journal_controls1.Production_P.Controls.OfType(Of Panel)()
                Dim idx As Integer = Stock_journal_controls1.Find_Idx(bg_p)
                Dim itm As Object = Stock_journal_controls1.Find_Particuls_TXT(idx, False)
                Dim qty As Object = Stock_journal_controls1.Find_qty_TXT(idx, False)

                If Chack_Duplicate(Database_File.cre, "TBL_Stock_Item", "Name", $"Name = '{itm.Text.ToString.Trim}'") = False Or itm.Text.ToString.Trim = "" Then
                    Stock_journal_controls1.Production_P.Controls.Remove(bg_p)
                Else
                    If cfg_YN_zero = False Then
                        If Val(qty.Text) <= 0 Then
                            qty.Focus()
                            Return False
                        End If
                    End If
                End If
            Next
        End If
        Return True
    End Function
    Private Function Data_Save_Manag() As Boolean
        Dim cn As New SQLiteConnection


        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            If Insurt_Head(cn) = True Then
                If Insurt_Item(cn) = True Then
                    If Insurt_EwayBill_data(cn) = True Then

                    End If
                End If
            End If

            'Transport Other, and Ewaybill Details
            If Insurt_Value_VC_other() = True Then
                If Order_Complit_Fll(cn, Order_Tra_ID) = True Then
                    If Order_Complit_Fll(cn, Tra_ID) = True Then
                        Return True
                    End If
                End If
            End If
            cn.Close()
        End If
    End Function
    Private Function Insurt_Head_Data(cn As SQLiteConnection, dt As DataTable) As Boolean
        Dim q As String = "INSERT INTO TBL_VC_Ledger 
(Type,Date,Tra_ID,Ledger,Dr,Cr) VALUES 
(@Type,@Date_,@Tra_ID,@Ledger,@Dr,@Cr)"

        Dim IDGroups = dt.AsEnumerable().GroupBy(Function(row) row.Field(Of String)("ID"))
        Dim tableResult = dt.Clone()
        For Each grp In IDGroups
            Dim Head_ID As String = grp.First().Field(Of String)("ID")
            Dim Head_amt As String = grp.Sum(Function(row) row.Field(Of Decimal)("Amt"))

            If Head_ID <> Nothing Then
                cmd = New SQLiteCommand(q, cn)
                With cmd.Parameters
                    .AddWithValue("@Type", $"{Voucher_Type_LB.Text} Account")
                    .AddWithValue("@Date_", CDate(Date_TXT.Text))
                    .AddWithValue("@Tra_ID", Tra_ID)

                    .AddWithValue("@Ledger", Head_ID)

                    If Voucher_type_() = "Inward" Then
                        .AddWithValue("@Dr", nUmBeR_FORMATE(Head_amt))
                        .AddWithValue("@Cr", "")
                    ElseIf Voucher_type_() = "Outward" Then
                        .AddWithValue("@Cr", nUmBeR_FORMATE(Head_amt))
                        .AddWithValue("@Dr", "")
                    End If
                    cmd.ExecuteNonQuery()
                End With
            End If
        Next

    End Function
    Private Function Insurt_GST_Data(cn As SQLiteConnection, dt As DataTable) As Boolean
        Dim q As String = "INSERT INTO TBL_VC_Ledger 
(Type,Date,Tra_ID,Ledger,Dr,Cr) VALUES 
(@Type,@Date_,@Tra_ID,@Ledger,@Dr,@Cr)"

        Dim IDGroups = dt.AsEnumerable().GroupBy(Function(row)
                                                     Return row.Field(Of String)("ID")
                                                 End Function)
        Dim tableResult = dt.Clone()

        For Each grp In IDGroups

            Dim GST_ID As String = grp.First().Field(Of String)("ID")
            Dim GST_amt As String = grp.Sum(Function(row) row.Field(Of Decimal)("Amt"))

            If GST_ID <> Nothing Then
                cmd = New SQLiteCommand(q, cn)
                With cmd.Parameters
                    .AddWithValue("@Type", $"GST")
                    .AddWithValue("@Date_", CDate(Date_TXT.Text))
                    .AddWithValue("@Tra_ID", Tra_ID)
                    .AddWithValue("@Ledger", GST_ID)

                    If Voucher_type_() = "Inward" Then
                        .AddWithValue("@Dr", nUmBeR_FORMATE(GST_amt))
                        .AddWithValue("@Cr", "")
                    ElseIf Voucher_type_() = "Outward" Then
                        .AddWithValue("@Cr", nUmBeR_FORMATE(GST_amt))
                        .AddWithValue("@Dr", "")
                    End If

                    cmd.ExecuteNonQuery()
                End With
            End If
        Next
    End Function

    Private Function Insurt_Head(cn As SQLiteConnection) As Boolean

        Try

            If Voucher_all_inventory() = True Then
                Dim amt As Decimal
                amt = nUmBeR_FORMATE(Sp_controls1.Amounr_Label.Text)
                cmd = New SQLiteCommand("INSERT INTO TBL_VC (Tra_ID,Voucher_ID,Voucher_No,Voucher_Type,Cr_Dr_note_resion,Supplier_IVC_No,Supplier_IVC_Date,Supplier_Nerration,Voucher_Type_ID,Date,Type,Particuls,Account,Unit,Branch,Godown,Narration,User,PC,Date_install,EwayBill_YN,Transport_YN,Bill_No,Order_No,Delivery_Date,Register_No,Visible,Company,Ledger,Rate,Credit_Amount,Debit_Amount,Payment_Details_YN,Effect_Stock,Effect_Ledger,Round_Off) VALUES (@Tra_ID,@Voucher_ID,@Voucher_No,@Voucher_Type,@Cr_Dr_note_resion,@Supplier_IVC_No,@Supplier_IVC_Date,@Supplier_Nerration,@Voucher_Type_ID,@Date_,@Type,@Particuls,@Account,@Unit,@Branch,@Godown,@Narration,@User,@PC,@Install_,@EwayBill_YN,@Transport_YN,@Bill_No,@Order_No,@Delivery_Date,@Register_No,@Visible,@Company,@Ledger,@Rate,@Credit_Amount,@Debit_Amount,@Payment_Details_YN,@Effect_Stock,@Effect_Ledger,@Round_Off)", cn)
                With cmd.Parameters
                    .AddWithValue("@Cr_Dr_note_resion", credit_note_resion)
                    .AddWithValue("@Supplier_IVC_No", supplier_vc_no)
                    .AddWithValue("@Supplier_Nerration", supplier_narration)

                    If Date_Formate(supplier_date).ToString = Nothing Then
                        .AddWithValue("@Supplier_IVC_Date", CDate(Date_TXT.Text))
                    Else
                        .AddWithValue("@Supplier_IVC_Date", CDate(supplier_date))
                    End If

                    .AddWithValue("@Tra_ID", Tra_ID)
                    .AddWithValue("@Voucher_ID", Voucher_ID)
                    .AddWithValue("@Voucher_No", Voucher_No_TXT.Text.Trim)


                    .AddWithValue("@Voucher_Type", Voucher_Type_LB.Text.Trim)


                    .AddWithValue("@Voucher_Type_ID", VC_Formate_ID)
                    .AddWithValue("@Type", "Head")
                    .AddWithValue("@Date_", CDate(Date_TXT.Text))

                    .AddWithValue("@Particuls", "")

                    .AddWithValue("@Account", "")
                    .AddWithValue("@Rate", "0")
                    .AddWithValue("@Ledger", Acc_ID)



                    If Voucher_type_() = "Outward" Then
                        .AddWithValue("@Credit_Amount", "0.00".Trim)
                        .AddWithValue("@Debit_Amount", amt)
                    ElseIf Voucher_type_() = "Inward" Then
                        .AddWithValue("@Credit_Amount", amt)
                        .AddWithValue("@Debit_Amount", "0.00".Trim)
                    End If

                    .AddWithValue("@Round_Off", Val(Sp_controls1.roundup_val_Lab.Text))

                    .AddWithValue("@Unit", "")
                    .AddWithValue("@Branch", "0")
                    .AddWithValue("@Godown", "")
                    .AddWithValue("@Narration", Narration_TXT.Text.Trim)
                    .AddWithValue("@Company", Company_ID_str)
                    .AddWithValue("@User", LOGIN_ID)
                    .AddWithValue("@PC", PC_ID.Trim)
                    .AddWithValue("@Install_", CDate(DateTime.Now))
                    .AddWithValue("@EwayBill_YN", Yn1.Text.Trim)
                    .AddWithValue("@Transport_YN", Yn2.Text.Trim)
                    .AddWithValue("@Payment_Details_YN", Yn3.Text.Trim)
                    .AddWithValue("@Bill_No", "")


                    .AddWithValue("@Effect_Stock", Boolean_TXT(Effect_Stock).ToString)
                    .AddWithValue("@Effect_Ledger", Boolean_TXT(Effect_Ledger).ToString)

                    If Voucher_Type_LB.Text = "Purchase Order" Or Voucher_Type_LB.Text = "Sales Order" Then
                        .AddWithValue("@Visible", "Approval")
                        .AddWithValue("@Order_No", "")
                        .AddWithValue("@Delivery_Date", CDate(Delivery_Date_TXT.Text))
                        .AddWithValue("@Register_No", "")
                    Else
                        .AddWithValue("@Order_No", Order_Tra_ID)
                        .AddWithValue("@Delivery_Date", CDate(Date_TXT.Text))
                        .AddWithValue("@Register_No", "")

                        .AddWithValue("@Visible", "Approval")
                    End If
                    cmd.ExecuteNonQuery()
                End With

                'TBL_VC_Ledger -----------------------------------------------------------------------------
                cmd = New SQLiteCommand("INSERT INTO TBL_VC_Ledger 
(Type,Date,Tra_ID,Ledger,Dr,Cr) VALUES 
(@Type,@Date_,@Tra_ID,@Ledger,@Dr,@Cr)", cn)
                With cmd.Parameters

                    .AddWithValue("@Type", "Head")
                    .AddWithValue("@Date_", CDate(Date_TXT.Text))
                    .AddWithValue("@Tra_ID", Tra_ID)

                    .AddWithValue("@Ledger", Acc_ID)

                    If Voucher_type_() = "Outward" Then
                        .AddWithValue("@Cr", "0.00")
                        .AddWithValue("@Dr", amt)
                    ElseIf Voucher_type_() = "Inward" Then
                        .AddWithValue("@Cr", amt)
                        .AddWithValue("@Dr", "0.00")
                    End If
                    cmd.ExecuteNonQuery()
                End With

                'Insurt Expance -----------------------------------------------------------------------------
                Dim P1_ As New Queue(Of Panel)()
                For Each bg_p As Panel In Sp_controls1.exp_panel.Controls.OfType(Of Panel)()
                    P1_.Enqueue(bg_p)
                Next

                For Each bg_p As Panel In P1_.Reverse
                    Dim idx As Integer = Sp_controls1.Find_Idx(bg_p)
                    Dim exp_ As String = Find_DT_Value(Database_File.cre, "TBL_Ledger", "ID", $"Name = '{Sp_controls1.Find_exp_TXT(idx).Text}'")
                    Dim rate_ As String = Sp_controls1.Find_exp_rate_TXT(idx).Text
                    Dim Type_of_Calculation As String = Sp_controls1.Find_Exp_Bg(idx).Tag.ToString
                    Dim amt_ As String = Sp_controls1.Find_exp_amt_TXT(idx).Text

                    cmd = New SQLiteCommand("INSERT INTO TBL_VC_Ledger 
(Type,Date,Tra_ID,Ledger,Rate,Dr,Cr,Type_of_Calculation,Rounding_Method,Rounding_Limit) VALUES 
(@Type,@Date_,@Tra_ID,@Ledger,@Rate,@Dr,@Cr,@Type_of_Calculation,@Rounding_Method,@Rounding_Limit)", cn)

                    With cmd.Parameters
                        .AddWithValue("@Type", "Exp")
                        .AddWithValue("@Date_", CDate(Date_TXT.Text))
                        .AddWithValue("@Tra_ID", Tra_ID)

                        .AddWithValue("@Ledger", exp_)
                        .AddWithValue("@Rate", rate_)
                        .AddWithValue("@Type_of_Calculation", Type_of_Calculation)
                        .AddWithValue("@Rounding_Method", Sp_controls1.Find_Round_(idx).Text)
                        .AddWithValue("@Rounding_Limit", Val(Sp_controls1.Find_Round_(idx).Tag.ToString))

                        If Voucher_type_() = "Outward" Then
                            .AddWithValue("@Dr", "0.00")
                            .AddWithValue("@Cr", amt_)
                        ElseIf Voucher_type_() = "Inward" Then
                            .AddWithValue("@Dr", amt_)
                            .AddWithValue("@Cr", "0.00")
                        End If

                        cmd.ExecuteNonQuery()
                    End With
                Next
            ElseIf Voucher_Type_LB.Text = "Stock Journal" Then
                cmd = New SQLiteCommand("INSERT INTO TBL_VC (Tra_ID,Voucher_ID,Voucher_No,Voucher_Type,Voucher_Type_ID,Date,Supplier_IVC_Date,Type,Branch,Narration,User,PC,Date_install,Visible,Company,Credit_Amount,Debit_Amount,Effect_Stock,Effect_Ledger) VALUES (@Tra_ID,@Voucher_ID,@Voucher_No,@Voucher_Type,@Voucher_Type_ID,@Date_,@Date_,@Type,@Branch,@Narration,@User,@PC,@Install_,@Visible,@Company,@Credit_Amount,@Debit_Amount,@Effect_Stock,@Effect_Ledger)", cn)
                With cmd.Parameters

                    .AddWithValue("@Tra_ID", Tra_ID)
                    .AddWithValue("@Voucher_ID", Voucher_ID)
                    .AddWithValue("@Voucher_No", Voucher_No_TXT.Text.Trim)

                    .AddWithValue("@Voucher_Type", Voucher_Type_LB.Text.Trim)

                    .AddWithValue("@Voucher_Type_ID", VC_Formate_ID)
                    .AddWithValue("@Type", "Head")
                    .AddWithValue("@Date_", CDate(Date_TXT.Text))

                    .AddWithValue("@Credit_Amount", "0.00".Trim)
                    .AddWithValue("@Debit_Amount", "0.00")

                    .AddWithValue("@Branch", "0")
                    .AddWithValue("@Narration", Narration_TXT.Text.Trim)
                    .AddWithValue("@Company", Company_ID_str)
                    .AddWithValue("@User", LOGIN_ID)
                    .AddWithValue("@PC", PC_ID.Trim)
                    .AddWithValue("@Install_", CDate(DateTime.Now))


                    .AddWithValue("@Effect_Stock", Boolean_TXT(True).ToString)
                    .AddWithValue("@Effect_Ledger", Boolean_TXT(False).ToString)

                    .AddWithValue("@Visible", "Approval")
                    ''Addetnoal Details
                    cmd.ExecuteNonQuery()
                End With
            End If

        Catch ex As Exception
            Msg(NOT_Type.Erro, "Data Save Error - Head", ex.Message)
            Return False
        End Try
        Return True
    End Function
    Private Function Insurt_EwayBill_data(cn As SQLiteConnection) As Boolean
        Dim q As String = "INSERT INTO TBL_EwayBill (Tra_ID,ewaybill_no,Date,Sub_Type,Document_Type,Consignee_F,Address1_F,Address2_F,Please_F,Pincode_F,GSTIN_F,State_F,Consignee_T,Address1_T,Address2_T,Please_T,Pincode_T,GSTIN_T,State_T,Mode,Distance,Transport_Name,Transport_ID,Vehicle_No,Vehicle_Type,LR_No,Dispatch_State,Ship_State) VALUES (@Tra_ID,@ewaybill_no,@Date_,@Sub_Type,@Document_Type,@Consignee_F,@Address1_F,@Address2_F,@Please_F,@Pincode_F,@GSTIN_F,@State_F,@Consignee_T,@Address1_T,@Address2_T,@Please_T,@Pincode_T,@GSTIN_T,@State_T,@Mode,@Distance,@Transport_Name,@Transport_ID,@Vehicle_No,@Vehicle_Type,@LR_No,@Dispatch_State,@Ship_State)"

        If YN_Boolean(Yn1.Text) = True Then
            Try
                cmd = New SQLiteCommand(q, cn)
                With cmd.Parameters
                    .AddWithValue("@Tra_ID", Tra_ID)
                    .AddWithValue("@ewaybill_no", eb_ewaybill_no.ToString)
                    .AddWithValue("@Date_", CDate(eb_date))
                    .AddWithValue("@Sub_Type", eb_Sub_Type.ToString)
                    .AddWithValue("@Document_Type", eb_Document_Type.ToString)
                    .AddWithValue("@Consignee_F", eb_Consignee_F.ToString)
                    .AddWithValue("@Address1_F", eb_Address1_F.ToString)
                    .AddWithValue("@Address2_F", eb_Address2_F.ToString)
                    .AddWithValue("@Please_F", eb_Please_F.ToString)
                    .AddWithValue("@Pincode_F", eb_Pincode_F.ToString)
                    .AddWithValue("@GSTIN_F", eb_GSTIN_F.ToString)
                    .AddWithValue("@State_F", eb_State_F.ToString)
                    .AddWithValue("@Consignee_T", eb_Consignee_T.ToString)
                    .AddWithValue("@Address1_T", eb_Address1_T.ToString)
                    .AddWithValue("@Address2_T", eb_Address2_T.ToString)
                    .AddWithValue("@Please_T", eb_Please_T.ToString)
                    .AddWithValue("@Dispatch_State", eb_State_dispath_T.ToString)
                    .AddWithValue("@Ship_State", eb_State_ship_T.ToString)
                    .AddWithValue("@Pincode_T", eb_Pincode_T.ToString)
                    .AddWithValue("@GSTIN_T", eb_GSTIN_T.ToString)
                    .AddWithValue("@State_T", eb_State_T.ToString)
                    .AddWithValue("@Mode", eb_Mode.ToString)
                    .AddWithValue("@Distance", eb_Distance.ToString)
                    .AddWithValue("@Transport_Name", eb_Transport_Name.ToString)
                    .AddWithValue("@Transport_ID", eb_Transport_ID.ToString)
                    .AddWithValue("@Vehicle_No", eb_Vehicle_No.ToString)
                    .AddWithValue("@Vehicle_Type", eb_Vehicle_Type.ToString)
                    .AddWithValue("@LR_No", eb_LR_No.ToString)
                    cmd.ExecuteNonQuery()
                End With
            Catch ex As Exception
                Msg(NOT_Type.Erro, "E-waybill Data Save Error", ex.Message)
                Return False
            End Try
        End If

        Return True
    End Function
    Public Function Insurt_Item_Type() As String
        Select Case Voucher_Type_LB.Text
            Case "Purchase"
                Return "Credit"
            Case "Inward Register"
                Return "Credit"
            Case "Sales Return"
                Return "Credit"
            Case "Credit Note"
                Return "Credit"

            Case "Sales"
                Return "Debit"
            Case "Outward Register"
                Return "Debit"
            Case "Purchase Return"
                Return "Debit"
            Case "Debit Note"
                Return "Debit"
            Case "Stock Journal"
                Return "SJ"

        End Select

    End Function
    Private Function Insurt_Item(cn As SQLiteConnection) As Boolean
        Dim type_ As String = Insurt_Item_Type()
        'Item Grid Insurt
        If Voucher_all_inventory() = True Then
            Dim P_ As New Queue(Of sp_control_under)()
            For Each bg_p As sp_control_under In Sp_controls1.stock_panel.Controls.OfType(Of sp_control_under)()
                P_.Enqueue(bg_p)
            Next

            Dim dt_GST As New DataTable
            dt_GST.Columns.Add("ID")
            dt_GST.Columns.Add("Amt").DataType = GetType(Decimal)

            Dim dt_Head As New DataTable
            dt_Head.Columns.Add("ID")
            dt_Head.Columns.Add("Amt").DataType = GetType(Decimal)

            For Each c As sp_control_under In P_.Reverse
                Dim itm As String = c.Item_TXT.Data_Link_
                Dim vlu As String = c.Amount_TXT.Text
                Dim tax_per As String = c.GST_Per
                Dim tax_vlu As String = c.GST_Amount
                Dim cess_id As String = c.Cess_ID
                Dim cess_per As String = c.Cess_Per
                Dim cess_vlu As String = c.Cess_Amount
                Dim qty As String = c.Qty_TXT.Text
                Dim rate_ As String = c.Rate_TXT.Text
                Dim discountP_ As String = c.DiscountP_TXT.Text
                Dim discountA_ As String = c.DiscountP_TXT.Data_Link_
                Dim description_ As String = c.Discription_Label.Text
                Dim CGSTID_ As String = c.CGST_ID
                Dim SGSTID_ As String = c.SGST_ID
                Dim IGSTID_ As String = c.IGST_ID
                Dim HeadID_ As String = c.Head_Account_ID

                dt_GST.Rows.Add(cess_id, Val(cess_vlu))
                If cfg_YN_GST = True Then
                    If TAX_Type = "CS" Then
                        dt_GST.Rows.Add(CGSTID_, Val(nUmBeR_FORMATE(tax_vlu) / 2))
                        dt_GST.Rows.Add(SGSTID_, Val(nUmBeR_FORMATE(tax_vlu) / 2))
                    Else
                        dt_GST.Rows.Add(IGSTID_, Val(nUmBeR_FORMATE(tax_vlu)))
                    End If
                Else
                    tax_vlu = 0
                    cess_per = 0
                    cess_vlu = 0
                    CGSTID_ = ""
                    SGSTID_ = ""
                    IGSTID_ = ""
                End If
                dt_Head.Rows.Add(HeadID_, Val(nUmBeR_FORMATE(vlu)))
                cmd = New SQLiteCommand("INSERT INTO TBL_VC_item_Details (Tra_ID,Date,Item,HSN_Code,Qty,Unit_Type,Rate,Discount_P,Discount_A,GST_per,GST_Type,Cess_ID,Cess_per,Cess_Amt,CGST,SGST,IGST,Amount,Type,Description,CGST_ID,SGST_ID,IGST_ID,Ledger_ID,Unit1,Unit2,Qty1,Qty2,Unit,Rate1,Rate2) VALUES (@Tra_ID,@Date_,@Item,@HSN_Code,@Qty,@Unit_Type,@Rate,@Discount_P,@Discount_A,@GST_per,@GST_Type,@Cess_ID,@Cess_per,@Cess_Amt,@CGST,@SGST,@IGST,@Amount,@Type,@Description,@CGST_ID,@SGST_ID,@IGST_ID,@Ledger_ID,@Unit1,@Unit2,@Qty1,@Qty2,@Unit,@Rate1,@Rate2)", cn)
                With cmd.Parameters
                    .AddWithValue("@Tra_ID", Tra_ID)
                    .AddWithValue("@Date_", CDate(Date_TXT.Text))
                    .AddWithValue("@Item", itm)
                    .AddWithValue("@HSN_Code", "")
                    .AddWithValue("@Qty", Val(qty))
                    .AddWithValue("@Unit_Type", "")
                    .AddWithValue("@Rate", nUmBeR_FORMATE(rate_))
                    .AddWithValue("@GST_per", nUmBeR_FORMATE(tax_per))
                    .AddWithValue("@GST_Type", TAX_Type)
                    .AddWithValue("@Type", type_)
                    .AddWithValue("@Description", description_)

                    .AddWithValue("@Ledger_ID", HeadID_)

                    .AddWithValue("@Cess_ID", cess_id)
                    .AddWithValue("@Cess_per", nUmBeR_FORMATE(cess_per))
                    .AddWithValue("@Cess_Amt", nUmBeR_FORMATE(cess_vlu))

                    .AddWithValue("@Discount_P", nUmBeR_FORMATE(discountP_))
                    .AddWithValue("@Discount_A", nUmBeR_FORMATE(discountA_))

                    .AddWithValue("@Unit1", c.Unit1_ID)
                    .AddWithValue("@Unit2", c.Unit2_ID)
                    .AddWithValue("@Qty1", c.Qty1)
                    .AddWithValue("@Qty2", c.Qty2)
                    .AddWithValue("@Unit", c.Unit_Lst.Data_Link_)

                    .AddWithValue("@Rate1", c.Rate1)
                    .AddWithValue("@Rate2", c.Rate2)

                    If TAX_Type = "CS" Then
                        .AddWithValue("@CGST", nUmBeR_FORMATE(tax_vlu) / 2)
                        .AddWithValue("@SGST", nUmBeR_FORMATE(tax_vlu) / 2)
                        .AddWithValue("@IGST", "0")

                        .AddWithValue("@CGST_ID", CGSTID_)
                        .AddWithValue("@SGST_ID", SGSTID_)
                        .AddWithValue("@IGST_ID", "")
                    Else
                        .AddWithValue("@CGST", "")
                        .AddWithValue("@SGST", "")
                        .AddWithValue("@IGST", nUmBeR_FORMATE(tax_vlu))

                        .AddWithValue("@CGST_ID", "")
                        .AddWithValue("@SGST_ID", "")
                        .AddWithValue("@IGST_ID", IGSTID_)
                    End If

                    .AddWithValue("@Amount", nUmBeR_FORMATE(vlu))
                    cmd.ExecuteNonQuery()
                End With
            Next

            Insurt_Head_Data(cn, dt_Head)
            Insurt_GST_Data(cn, dt_GST)
        ElseIf Voucher_Type_LB.Text = "Stock Journal" Then

            Dim P_ As New Queue(Of Panel)()

            P_ = New Queue(Of Panel)()
            For Each bg_p As Panel In Stock_journal_controls1.Production_P.Controls.OfType(Of Panel)()
                P_.Enqueue(bg_p)
            Next

            For Each bg_p As Panel In P_.Reverse
                Dim idx As Integer = Stock_journal_controls1.Find_Idx(bg_p)
                Dim itm As String = Stock_journal_controls1.Find_AccID_Label(idx, False).Text
                Dim qty As String = Stock_journal_controls1.Find_qty_TXT(idx, False).Text


                Dim Unit1 As String = Stock_journal_controls1.Find_Unit1_Label(idx, False).Text
                Dim Unit2 As String = Stock_journal_controls1.Find_Unit2_Label(idx, False).Text

                Dim Qty1 As String = Stock_journal_controls1.Find_Qty1(idx, False).Text
                Dim Qty2 As String = Stock_journal_controls1.Find_Qty2(idx, False).Text

                Dim Unit_ As String = "Frist"

                cmd = New SQLiteCommand("INSERT INTO TBL_VC_item_Details (Tra_ID,Date,Item,HSN_Code,Qty,Unit_Type,Rate,Discount_P,Discount_A,GST_per,GST_Type,Cess_ID,Cess_per,Cess_Amt,CGST,SGST,IGST,Amount,Type,Description,CGST_ID,SGST_ID,IGST_ID,Ledger_ID,Unit1,Unit2,Qty1,Qty2,Unit,Rate1,Rate2) VALUES (@Tra_ID,@Date_,@Item,@HSN_Code,@Qty,@Unit_Type,@Rate,@Discount_P,@Discount_A,@GST_per,@GST_Type,@Cess_ID,@Cess_per,@Cess_Amt,@CGST,@SGST,@IGST,@Amount,@Type,@Description,@CGST_ID,@SGST_ID,@IGST_ID,@Ledger_ID,@Unit1,@Unit2,@Qty1,@Qty2,@Unit,@Rate1,@Rate2)", cn)
                With cmd.Parameters
                    .AddWithValue("@Tra_ID", Tra_ID)
                    .AddWithValue("@Date_", CDate(Date_TXT.Text))
                    .AddWithValue("@Item", itm)
                    .AddWithValue("@HSN_Code", "")
                    .AddWithValue("@Qty", nUmBeR_FORMATE(qty))
                    .AddWithValue("@Unit_Type", Unit_)
                    .AddWithValue("@Rate", nUmBeR_FORMATE("0.00"))
                    .AddWithValue("@GST_per", nUmBeR_FORMATE("0.00"))
                    .AddWithValue("@GST_Type", TAX_Type)

                    .AddWithValue("@Unit1", Unit1)
                    .AddWithValue("@Unit2", Unit2)
                    .AddWithValue("@Qty1", Qty1)
                    .AddWithValue("@Qty2", Qty2)
                    .AddWithValue("@Unit", Qty1)

                    .AddWithValue("@Rate1", "")
                    .AddWithValue("@Rate2", "")


                    .AddWithValue("@Discount_P", nUmBeR_FORMATE("0.00"))
                    .AddWithValue("@Discount_A", nUmBeR_FORMATE("0.00"))

                    .AddWithValue("@Type", "Credit")
                    .AddWithValue("@Description", "")
                    .AddWithValue("@Ledger_ID", "")

                    .AddWithValue("@CGST", "0")
                    .AddWithValue("@SGST", "0")
                    .AddWithValue("@IGST", "0")

                    .AddWithValue("@Cess_ID", "0")
                    .AddWithValue("@Cess_per", "0")
                    .AddWithValue("@Cess_Amt", "0")

                    .AddWithValue("@CGST_ID", "")
                    .AddWithValue("@SGST_ID", "")
                    .AddWithValue("@IGST_ID", "")

                    .AddWithValue("@Amount", "0")
                    cmd.ExecuteNonQuery()
                End With
                Dim Data_ As String = Stock_journal_controls1.Find_Other_data(idx, False).Text
            Next

            P_ = New Queue(Of Panel)()

            For Each bg_p As Panel In Stock_journal_controls1.Source_P.Controls.OfType(Of Panel)()
                P_.Enqueue(bg_p)
            Next

            For Each bg_p As Panel In P_.Reverse
                Dim idx As Integer = Stock_journal_controls1.Find_Idx(bg_p)
                Dim itm As String = Stock_journal_controls1.Find_AccID_Label(idx, True).Text
                Dim qty As String = Stock_journal_controls1.Find_qty_TXT(idx, True).Text

                Dim Unit1 As String = Stock_journal_controls1.Find_Unit1_Label(idx, True).Text
                Dim Unit2 As String = Stock_journal_controls1.Find_Unit2_Label(idx, True).Text

                Dim Qty1 As String = Stock_journal_controls1.Find_Qty1(idx, True).Text
                Dim Qty2 As String = Stock_journal_controls1.Find_Qty2(idx, True).Text

                Dim Unit_ As String = "Frist"

                cmd = New SQLiteCommand("INSERT INTO TBL_VC_item_Details (Tra_ID,Date,Item,HSN_Code,Qty,Unit_Type,Rate,Discount_P,Discount_A,GST_per,GST_Type,Cess_ID,Cess_per,Cess_Amt,CGST,SGST,IGST,Amount,Type,Description,CGST_ID,SGST_ID,IGST_ID,Ledger_ID,Unit1,Unit2,Qty1,Qty2,Unit,Rate1,Rate2) VALUES (@Tra_ID,@Date_,@Item,@HSN_Code,@Qty,@Unit_Type,@Rate,@Discount_P,@Discount_A,@GST_per,@GST_Type,@Cess_ID,@Cess_per,@Cess_Amt,@CGST,@SGST,@IGST,@Amount,@Type,@Description,@CGST_ID,@SGST_ID,@IGST_ID,@Ledger_ID,@Unit1,@Unit2,@Qty1,@Qty2,@Unit,@Rate1,@Rate2)", cn)
                With cmd.Parameters
                    .AddWithValue("@Tra_ID", Tra_ID)
                    .AddWithValue("@Date_", CDate(Date_TXT.Text))
                    .AddWithValue("@Item", itm)
                    .AddWithValue("@HSN_Code", "")
                    .AddWithValue("@Qty", nUmBeR_FORMATE(qty))
                    .AddWithValue("@Unit_Type", Unit_)
                    .AddWithValue("@Rate", nUmBeR_FORMATE("0.00"))
                    .AddWithValue("@GST_per", nUmBeR_FORMATE("0.00"))
                    .AddWithValue("@GST_Type", TAX_Type)
                    .AddWithValue("@Description", "")
                    .AddWithValue("@Ledger_ID", "")

                    .AddWithValue("@Discount_P", nUmBeR_FORMATE("0.00"))
                    .AddWithValue("@Discount_A", nUmBeR_FORMATE("0.00"))

                    .AddWithValue("@Unit1", Unit1)
                    .AddWithValue("@Unit2", Unit2)
                    .AddWithValue("@Qty1", Qty1)
                    .AddWithValue("@Qty2", Qty2)
                    .AddWithValue("@Unit", Qty1)

                    .AddWithValue("@Rate1", "")
                    .AddWithValue("@Rate2", "")


                    .AddWithValue("@Type", "Debit")

                    .AddWithValue("@Cess_ID", "0")
                    .AddWithValue("@Cess_per", "0")
                    .AddWithValue("@Cess_Amt", "0")

                    .AddWithValue("@CGST", "0")
                    .AddWithValue("@SGST", "0")
                    .AddWithValue("@IGST", "0")

                    .AddWithValue("@CGST_ID", "")
                    .AddWithValue("@SGST_ID", "")
                    .AddWithValue("@IGST_ID", "")

                    .AddWithValue("@Amount", "0")


                    cmd.ExecuteNonQuery()
                End With
                Dim Data_ As String = Stock_journal_controls1.Find_Other_data(idx, True).Text
            Next
        End If


        Return True
    End Function
    Private Function Insurt_Value_VC_other() As Boolean
        If open_MSSQL(Database_File.cre) = True Then
            cmd = New SQLiteCommand("INSERT INTO TBL_VC_Other (Vebrij_Gross,Vebrij_Vehical,Vebrij_Net,Dispatch_Doc_No,Dispatch_Through,Carrier_Name_Agent,Dispatch_Date,Tra_ID,[Date],Transport_Mode,Transport_Distance,Transportation_Name,Transport_ID,Vihical_No,Vihical_Type,LR_No,Driver_Name,Driver_Phone,Driver_License,eWay_Bill_No,ewayBill_Type,ewayBill_Document_Type,From_Address1,From_Address2,From_Please,From_Pincode,To_Name,To_GST,To_Address1,To_Address2,To_Please,To_Pincode,To_Country,To_State,To_GST_Type,Ship_Mailing_Name,Ship_Name,Ship_Address,Ship_ID,Ship_Country,Place_of_Receipt_by_Shipper,Port_of_Loading,Port_of_Discharge,Shipping_Bill_No,Export_LUT,Export_Date,Port_Code,Ship_State,Ship_Pincode,Ship_GST_Type,Ship_GST,Terms_of_payment,Payment_reference,terms_of_delivery,YN_Transport,YN_Ewaybill,Company,[User],Date_Install,PC) VALUES (@Vebrij_Gross,@Vebrij_Vehical,@Vebrij_Net,@Dispatch_Doc_No,@Dispatch_Through,@Carrier_Name_Agent,@Dispatch_Date,@Tra_ID,@Date_,@Transport_Mode,@Transport_Distance,@Transportation_Name,@Transport_ID,@Vihical_No,@Vihical_Type,@LR_No,@Driver_Name,@Driver_Phone,@Driver_License,@eWay_Bill_No,@ewayBill_Type,@ewayBill_Document_Type,@From_Address1,@From_Address2,@From_Please,@From_Pincode,@To_Name,@To_GST,@To_Address1,@To_Address2,@To_Please,@To_Pincode,@To_Country,@To_State,@To_GST_Type,@Ship_Mailing_Name,@Ship_Name,@Ship_Address,@Ship_ID,@Ship_Country,@Place_of_Receipt_by_Shipper,@Port_of_Loading,@Port_of_Discharge,@Shipping_Bill_No,@Export_LUT,@Export_Date,@Port_Code,@Ship_State,@Ship_Pincode,@Ship_GST_Type,@Ship_GST,@Terms_of_payment,@Payment_reference,@terms_of_delivery,@YN_Transport,@YN_Ewaybill,@Company,@User,@Install_,@PC)", con)
            With cmd.Parameters
                .AddWithValue("@Tra_ID", Tra_ID.Trim)
                .AddWithValue("@Date_", CDate(Date_TXT.Text))
                .AddWithValue("@Dispatch_Doc_No", Dispatch_Doc.Trim)
                .AddWithValue("@Dispatch_Through", Dispatch_through.Trim)
                .AddWithValue("@Carrier_Name_Agent", Dispatch_Carrier_Name_agent.Trim)
                .AddWithValue("@Dispatch_Date", CDate(Dispatch_date))

                .AddWithValue("@Vebrij_Gross", Vebrij_Gross.Trim)
                .AddWithValue("@Vebrij_Vehical", Vebrij_Vihical.Trim)
                .AddWithValue("@Vebrij_Net", Vebrij_Net.Trim)

                .AddWithValue("@Transport_Mode", Transport_Mode.Trim)
                .AddWithValue("@Transport_Distance", Transport_Distance.Trim)
                .AddWithValue("@Transportation_Name", Transport_Name.Trim)
                .AddWithValue("@Transport_ID", Transport_ID.Trim)
                .AddWithValue("@Vihical_No", Vihicale_No.Trim)
                .AddWithValue("@Vihical_Type", Vihicale_Type.Trim)
                .AddWithValue("@LR_No", LR_No.Trim)
                .AddWithValue("@Driver_Name", Driver_Name.Trim)
                .AddWithValue("@Driver_Phone", Driver_Phone.Trim)
                .AddWithValue("@Driver_License", Driver_License.Trim)
                .AddWithValue("@eWay_Bill_No", eWay_Bill_No.Trim)
                .AddWithValue("@ewayBill_Type", ewayBill_Type.Trim)
                .AddWithValue("@ewayBill_Document_Type", ewayBill_Document_Type.Trim)
                .AddWithValue("@From_Address1", From_Address1.Trim)
                .AddWithValue("@From_Address2", From_Address2.Trim)
                .AddWithValue("@From_Please", From_Please.Trim)
                .AddWithValue("@From_Pincode", From_Pincode.Trim)
                .AddWithValue("@To_Name", To_Name.Trim)
                .AddWithValue("@To_GST", To_GST.Trim)
                .AddWithValue("@To_Address1", To_Address1.Trim)
                .AddWithValue("@To_Address2", To_Address2.Trim)
                .AddWithValue("@To_Please", To_Please.Trim)
                .AddWithValue("@To_Pincode", To_Pincode.Trim)
                .AddWithValue("@To_Country", To_Country.Trim)
                .AddWithValue("@To_State", To_State.Trim)
                .AddWithValue("@To_GST_Type", To_GST_Type.Trim)


                .AddWithValue("@Ship_Name", Ship_Name.Trim)
                .AddWithValue("@Ship_Mailing_Name", Ship_Mailing.Trim)
                .AddWithValue("@Ship_Address", Ship_Address.Trim)
                .AddWithValue("@Ship_ID", Ship_ID)
                .AddWithValue("@Ship_Country", Ship_Country.Trim)
                .AddWithValue("@Ship_State", Ship_State.Trim)
                .AddWithValue("@Ship_Pincode", Ship_Pincode.Trim)
                .AddWithValue("@Ship_GST_Type", Ship_GST_Type.Trim)
                .AddWithValue("@Ship_GST", Ship_GST.Trim)

                .AddWithValue("@Place_of_Receipt_by_Shipper", Export_shipper.Trim)
                .AddWithValue("@Port_of_Loading", Export_port_loading.Trim)
                .AddWithValue("@Port_of_Discharge", Export_port_discharge.Trim)
                .AddWithValue("@Shipping_Bill_No", Export_shipping_bill.Trim)

                .AddWithValue("@Export_Date", CDate(Export_Date))
                .AddWithValue("@Export_LUT", Export_LUT_No.Trim)
                .AddWithValue("@Port_Code", Export_Port_Code.Trim)



                .AddWithValue("@YN_Transport", Yn2.Text.Trim)
                .AddWithValue("@Payment_Details_YN", Yn3.Text.Trim)
                .AddWithValue("@YN_Ewaybill", Yn1.Text.Trim)

                .AddWithValue("@Terms_of_payment", Terms_of_payment.Trim)
                .AddWithValue("@Payment_reference", Payment_reference.Trim)
                .AddWithValue("@terms_of_delivery", terms_of_delivery.Trim)

                .AddWithValue("@Company", Company_ID_str)
                .AddWithValue("@User", LOGIN_ID)
                .AddWithValue("@PC", PC_ID.Trim)
                .AddWithValue("@Install_", CDate(DateTime.Now))
                cmd.ExecuteNonQuery()
            End With
        End If
        Return True
    End Function

    Private Function Document_Save() As Boolean
        If open_MSSQL(Database_File.rec) = True Then
            qury = "INSERT INTO TBL_Attage (Name,Narration,TBL,TBL_ID,Attage,Attage_Type,Password,[User],Date_install,PC,Visible) VALUES (@Name,@Narration,@TBL,@TBL_ID,@Attage,@Attage_Type,@Password,@User,@Install_,@PC,@Visible)"
            For i As Integer = 0 To DataGridView1.Rows.Count - 1
                Dim ro As DataGridViewRow = DataGridView1.Rows(i)
                If ro.Cells(0).Value = "0" Then
                    cmd = New SQLiteCommand(qury, con)
                    Dim Byt As Byte()
                    Byt = DirectCast(ro.Cells(4).Value, Byte())

                    Try
                        With cmd.Parameters
                            .AddWithValue("@Name", ro.Cells(1).Value)
                            .AddWithValue("@Narration", ro.Cells(2).Value)
                            .AddWithValue("@TBL", "TBL_VC")
                            .AddWithValue("@TBL_ID", Tra_ID)
                            .AddWithValue("@Attage", Byt)
                            .AddWithValue("@Attage_Type", ro.Cells(3).Value)
                            .AddWithValue("@Password", ro.Cells(5).Value)
                            .AddWithValue("@User", LOGIN_ID)
                            .AddWithValue("@Install_", CDate(DateTime.Now))
                            .AddWithValue("@PC", PC_ID.Trim)
                            .AddWithValue("@Visible", "Approval")
                            cmd.ExecuteNonQuery()
                        End With
                    Catch ex As Exception
                        Msg(NOT_Type.Erro, "Data Save Error", ex.Message)
                        Return False
                    End Try
                End If
            Next
        End If
        Return True
    End Function
    Private Function Order_Fll(cn As SQLiteConnection, ID As String) As Boolean
        Dim istrue As Boolean = False

        cmd = New SQLiteCommand($"Select vi.Item,SUM(vi.Qty) as Ord,

(Select SUM(vi1.Qty) From TBL_VC_item_Details vi1 where vi1.Item = vi.Item and (Select vc.Order_No From TBL_VC vc where vc.Tra_ID = vi1.Tra_ID and vc.Type = 'Head' and vc.Visible = 'Approval') = vi.Tra_ID) as Com 

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
    Private Function Order_Complit_Fll(cn As SQLiteConnection, ID As String) As Boolean
        If YN_Boolean(Order_YN.Text) = True Then
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



                'As per Stock Value Register or Invoice ?
                If Voucher_all_inventory() = True Then
                    If Sp_controls1.Txt1.Visible = True Then
                        If Sp_controls1.Txt1.Text = "Sales" Or Sp_controls1.Txt1.Text = "Purchase" Then
                            qury = $"UPDATE TBL_VC Set Effect_Stock = 'Yes' WHERE Tra_ID = '{Tra_ID }';
UPDATE TBL_VC Set Effect_Stock = 'No' WHERE Tra_ID = '{Order_Tra_ID }'
"
                            cmd = New SQLiteCommand(qury, cn)
                            cmd.ExecuteNonQuery()
                        ElseIf Sp_controls1.Txt1.Text = "Inward Register" Or Sp_controls1.Txt1.Text = "Outward Register" Then
                            qury = $"UPDATE TBL_VC Set Effect_Stock = 'Yes' WHERE Tra_ID = '{Order_Tra_ID }';
UPDATE TBL_VC Set Effect_Stock = 'No' WHERE Tra_ID = '{Tra_ID }'
"
                            cmd = New SQLiteCommand(qury, cn)
                            cmd.ExecuteNonQuery()
                        End If
                    End If
                End If
            End If
        End If
        Return True
    End Function
    Private Function Clear_all()
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            'BG_frm.Voucher_BS.DataSource = Nothing
            'BG_frm.Voucher_BS.DataSource = Fill_Vouchhers(cn)
        End If
        Account_TXT.Text = ""
        Narration_TXT.Text = ""
        Label8.Text = "0.00"
        Label28.Text = "0.00"

        If VC_Type_ = "Create" Then
            If Voucher_all_inventory() = True Then
                Sp_controls1.stock_panel.Controls.Clear()
                Sp_controls1.exp_panel.Controls.Clear()
                Sp_controls1.Clear_All_SUM()
                Sp_controls1.Add_New()
                Sp_controls1.Add_New_exp("User Defined Value", "Not Applicable", 0)
            Else
                Stock_journal_controls1.Production_P.Controls.Clear()
                Stock_journal_controls1.Source_P.Controls.Clear()
                Stock_journal_controls1.Add_New_S()
            End If


            Voucher_Setup(VC_Formate_ID)
            Account_TXT.Text = " "
            Date_TXT.Focus()
            Tra_ID = "0"

            Fill_Source()
            NOT_("The entry you entered has been successfully accepted", NOT_Type.Success)
        Else
            Voucher_BG_frm.Dispose()
            Update_Report = True
            Frm_foCus()
        End If

    End Function
    Public Function Voucher_No_Setup()

        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select Voucher_ID as C From TBL_VC where Voucher_Type = '{Voucher_Type_LB.Text}' and Voucher_Type_ID = '{VC_Formate_ID }' and {Company_Visible_Filter()} Order By Voucher_ID DESC limit 1", cn)
            Dim r As SQLiteDataReader = cmd.ExecuteReader
            While r.Read
                Voucher_ID = Val(r("C").ToString) + 1
            End While
            r.Close()
        End If
        cn.Close()
        If Val(Voucher_ID) <= Val(vc_start) Then
            Voucher_ID = Val(vc_start)
        End If

        If Val(Voucher_ID) = 0 Then
            Voucher_ID = 1
        End If

        If VC_VoucherNo_Method = "Automatitic" Then
            Voucher_No_TXT.Text = Voucher_ID
            Voucher_No_TXT.Enabled = True
        ElseIf VC_VoucherNo_Method = "Automatic (Manual Override)" Then
            Voucher_No_TXT.Text = Voucher_ID
            Voucher_No_TXT.Enabled = False
        ElseIf VC_VoucherNo_Method = "Manual" Then
            Voucher_ID = ""
            Voucher_No_TXT.Text = Voucher_ID
            Voucher_No_TXT.Enabled = False
        ElseIf VC_VoucherNo_Method = "Custom" Then
            Voucher_No_TXT.Text = VC_VoucherNo_Frist & Voucher_ID & VC_VoucherNo_Last
            Voucher_No_TXT.Enabled = True
        End If


    End Function


    Private Function Voucher_Setup(vc As String)
        Cfg_Link()

        'Serial No Set---------------+++++++++++++++++-----------------

        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Or VC_Type_ = "Duplicate" Or VC_Type_ = "Duplicate_Close" Or VC_Type_ = "Voucher Transfer" Then
            Voucher_No_Setup()
        End If


        If Voucher_Type_LB.Text = "Purchase" Or Voucher_Type_LB.Text = "Inward Register" Or Voucher_Type_LB.Text = "Credit Note" Or Voucher_Type_LB.Text = "Debit Note" Then
            Panel28.Show()
        Else
            Panel28.Hide()
        End If

        Order_No_Panel.Visible = cfg_YN_Order_details

        If Voucher_Type_LB.Text = "Purchase Order" Or Voucher_Type_LB.Text = "Sales Order" Then
            Delivery_Date_Panel.Visible = True
        Else
            Delivery_Date_Panel.Visible = False
        End If

        DataFilll_Class_List()

        If (VC_Type_ = "Create" Or VC_Type_ = "Create_Close") Then
            If (Class_list.List_Grid.Rows.Count <= 1) Then
                Bg_Panel.Visible = True
                Class_Panel.Visible = False
            Else
                Bg_Panel.Visible = False
                Class_Panel.Visible = True
                Class_TXT.Focus()
            End If
        End If


        With VC_Formate
            If .ToString = "Purchase" Or .ToString = "Sales Return" Or .ToString = "Debit Note" Or .ToString = "Sales" Or .ToString = "Purchase Return" Or .ToString = "Credit Note" Then
                Effect_Ledger = True
            Else
                Effect_Ledger = False
            End If
        End With

    End Function
    Private Function DataFilll_Class_List()
        Dim cn As New SQLiteConnection
        Dim dt As New DataTable
        dt.Columns.Add("Name")
        dt.Columns.Add("ID")

        dt.Rows.Add("Not Applicable", "0")

        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select * From TBL_Vouchers_Class where VC_ID = '{VC_Formate_ID}'", cn)
            Dim r As SQLiteDataReader = cmd.ExecuteReader
            While r.Read
                dt.Rows.Add(r("Name").ToString, r("ID").ToString)
            End While
            r.Close()
        End If

        Class_Source.DataSource = dt
    End Function

    Private Sub Date_TXT_Enter(sender As Object, e As EventArgs) Handles Date_TXT.Enter
        Date_TXT_TextChanged(e, e)
    End Sub
    Private Sub Date_TXT_TextChanged(sender As Object, e As EventArgs) Handles Date_TXT.TextChanged
        Date_fOrmate_lIV()
    End Sub

    Dim privoice_date As Date
    Private Sub Date_TXT_Lostfocus(sender As Object, e As EventArgs) Handles Date_TXT.LostFocus
        If Date_fOrmate_lIV() = True Then
            Date_TXT.Text = CDate(Date_Formate(Date_TXT.Text)).ToString(Date_Format_fech)
        Else
            Date_TXT.Text = CDate(Date_3).ToString(Date_Format_fech)
        End If

        'If DateDiff(DateInterval.Day, Cfg_Setting.Default.Frm_Date, CDate(Date_TXT.Text)) < 0 Or DateDiff(DateInterval.Day, Cfg_Setting.Default.To_Date, CDate(Date_TXT.Text)) > 0 Then
        '    Msg_Custom_YN(NOT_Location.Bottom_Right, Color.Red, My.Resources.datetime_animation_gif, Dialoag_Button.Ok, "Date", "Date is outside the time period.", $"You cannot select a date outside the selected period.<nl>{Cfg_Setting.Default.Frm_Date.ToString(Date_Format_fech)} to {Cfg_Setting.Default.To_Date.ToString(Date_Format_fech)}")
        '    Date_TXT.Focus()
        '    Exit Sub
        'End If

        Fill_Source()

        If privoice_date = Dispatch_date Or Dispatch_date = Nothing Then
            Dispatch_date = Date_Formate(Date_TXT.Text)
        End If

        If privoice_date = Export_Date Or Export_Date = Nothing Then
            Export_Date = Date_Formate(Date_TXT.Text)
        End If

        privoice_date = Date_Formate(Date_TXT.Text)

        If Delivery_Date_TXT.Text <> Nothing Then
            Label21.Text = $"{DateDiff(DateInterval.Day, CDate(Date_TXT.Text), CDate(Delivery_Date_TXT.Text))} Days"
        End If
    End Sub
    Private Function Date_fOrmate_lIV() As Boolean
        If Date_Brack(Date_TXT.Text) = True Then
            Day_Label.Text = Date_TO_Day(Date_TXT.Text)
            Return True
        End If
        Return False
    End Function
    Private Sub Account_TXT_Lostfocus(sender As Object, e As EventArgs) Handles Account_TXT.LostFocus
        If Account_TXT.Lost_Key = "Enter" Then
            Account_TXT.Lost_Key = ""

            Dim txt As Object = CType(sender, Object)
            If GetNextControl(txt, True).Focus = True Then
                Acc_ID = Find_DT_Value(Database_File.cre, "TBL_Ledger", "ID", "Name = '" & Account_TXT.Text & "'")
            End If
        End If

        'Acc_Balance = Val(Val((Ledger_Balance(Acc_ID, CDate(Date_TXT.Text), Tra_ID))))

        'Acc_Credit = Val(Find_DT_Value(Database_File.cre, "TBL_Ledger", "Cradit", "Name = '" & Account_TXT.Text & "' and " & Company_Visible_Filter))

        'Closing_Balance_Set()

        'GST_Type_()

        If Voucher_all_inventory() = True Then
            Sp_controls1.Refresh_cfg()
        End If


    End Sub
    Public Acc_Balance As Decimal = 0.00
    Public Acc_Credit As Decimal = 0.00
    Private Sub Account_TXT_Enter(sender As Object, e As EventArgs) Handles Account_TXT.Enter

    End Sub
    Dim Fiter_String_of_ledger As String = ""
    Dim Account_Balance_ As Decimal
    Public Function Closing_Balance_Set()
        If Acc_ID <> Nothing Then
            If Voucher_type_() = "Inward" Then
                Label8.Text = Val(Val(Acc_Balance) - Val(Sp_controls1.Amounr_Label.Text))

                Label28.Text = (Acc_Credit + Val(Sp_controls1.Amounr_Label.Text))
            ElseIf Voucher_type_() = "Outward" Then
                Label8.Text = Val(Val(Acc_Balance) + Val(Sp_controls1.Amounr_Label.Text))

                Label28.Text = ((Acc_Credit - (Acc_Balance)) - Val(Sp_controls1.Amounr_Label.Text))
            End If
        End If


        Try
            If (Label8.Text) <= 0 Then
                Label8.ForeColor = Color.Red
                Label8.Text = N2_FORMATE((Val(Label8.Text) * -1)) & " Cr"
            Else
                Label8.ForeColor = Color.DimGray
                Label8.Text = N2_FORMATE(Label8.Text) & " Dr"
            End If
        Catch ex As Exception

        End Try

        Try
            If (Label28.Text) <= 0 Then
                Label28.ForeColor = Color.Red
                Label28.Text = N2_FORMATE((Val(Label28.Text)))
            Else
                Label28.ForeColor = Color.DimGray
                Label28.Text = N2_FORMATE(Label28.Text)
            End If
        Catch ex As Exception

        End Try
    End Function
    Private Sub Branch_TXT_TextChanged(sender As Object, e As EventArgs)

    End Sub
    Private Sub Narration_TXT_Lostfocus(sender As Object, e As EventArgs)
        sender.BackColor = Color.OldLace
    End Sub
    Private Sub Narration_TXT_Enter(sender As Object, e As EventArgs)
        sender.BackColor = Color.FromArgb(254, 197, 48)
    End Sub
    Dim Grid_Balance_Noti As Boolean = True
    Private Sub TextBox1_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs)

    End Sub
    Private Sub Voucher_No_TXT_Enter(sender As Object, e As EventArgs) Handles Voucher_No_TXT.Enter
        Voucher_Bo_aLlow()
    End Sub
    Private Sub Voucher_No_TXT_TextChanged(sender As Object, e As EventArgs) Handles Voucher_No_TXT.TextChanged
        Voucher_Bo_aLlow()
    End Sub
    Private Sub Voucher_No_TXT_Lostfocus(sender As Object, e As EventArgs) Handles Voucher_No_TXT.LostFocus
        If Voucher_Bo_aLlow() = False Then
            Voucher_No_TXT.Focus()
        End If
    End Sub
    Private Function Voucher_Bo_aLlow() As Boolean
        Dim frm_ As String
        If Voucher_Type_LB.Text = "Attendance" Then
            frm_ = "TBL_Attendance_VC"
        Else
            frm_ = "TBL_VC"
        End If

        Dim Duplicate_Type As String

        If cfg_YN_Duplicate_No = False Then
            If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Or VC_Type_ = "Duplicate" Or VC_Type_ = "Voucher Transfer" Then
                Duplicate_Type = $" Voucher_No = '{Voucher_No_TXT.Text}' and Voucher_Type_ID = '{VC_Formate_ID }' and (Visible <> 'Delete')"
            Else
                Duplicate_Type = $" Voucher_No = '{Voucher_No_TXT.Text}' and (Voucher_No <> '{VC_ID_}') and Type = 'Head' and Voucher_Type_ID = '{VC_Formate_ID}' and (Visible <> 'Delete')"
                'My.Computer.Clipboard.SetText(Duplicate_Type)
            End If


            If Voucher_No_TXT.Text = "" Then
                NOT_("Not Valid Without a Blank 'Voucher No'", NOT_Type.Warning)
                'Msg_Blank(Voucher_No_TXT, "Voucher No")

                Return False
            End If

            If Chack_Duplicate(Database_File.cre, frm_, "Name", Duplicate_Type) = True Then
                NOT_("The Voucher No Entered is a 'Duplicate'", NOT_Type.Warning)
                'Msg_Duplicat(Voucher_No_TXT, "Voucher No")

                Return False
            Else
                NOT_Clear()
                Return True
            End If
        End If
        Return True
    End Function

    Private Function Setup_Panel(ParamArray oj() As Object)
        Panel7.Hide()
        For i As Integer = 0 To oj.Count - 1
            Dim ob As Object = oj(i)
            ob.Show()
        Next
    End Function
    Public TAX_Type As String = "CS"

    Public Function GST_Type_()
        Dim Company_State As String = Company_State_str.ToLower()
        Dim Party_State As String = To_State.ToLower()
        Dim Party_Country As String = To_Country.ToLower()

        If Party_Country.ToLower = "india" Or Party_Country = Nothing Then
            If (Company_State = "not applicable" Or Party_State = "not applicable") Then
                TAX_Type = "CS"
                Exit Function
            End If

            If Company_State = Nothing Or Party_State = Nothing Then
                TAX_Type = "CS"
                Exit Function
            End If


            If (Company_State = Party_State) Then
                TAX_Type = "CS"
            Else
                TAX_Type = "I"
            End If
        Else
            TAX_Type = "I"
        End If


    End Function
    'Public Alter_Amount_ As Decimal = 0.00
    Public Marge_Voucher_Filter As String
    Public Function Marge_Fill_and_calculation(cn As SQLiteConnection, Filter_ As String)




        Sp_controls1.stock_panel.Controls.Clear()
        Sp_controls1.Clear_All_SUM()
        ProgressBar1.Value = 0
        Dim q As String = $"Select vi.Item,
(Select it.name From TBL_Stock_Item it where it.id = vi.Item) as Item_Name,
(Select u.Symbol From TBL_Inventory_Unit u where u.id = (Select it.unit From TBL_Stock_Item it where it.id = vi.Item)) as Unit_Name,
(Select ifnull(t.Percentage,0.00) From TBL_TAX t where t.id = (Select it.Tax_Type From TBL_Stock_Item it where it.id = vi.Item)) as GST,
ifnull(SUM(vi.Qty),0) as Qty,ifnull(SUM(vi.Amount),0) as Amt
From TBL_VC_item_Details vi
LEFT JOIN TBL_VC VC on vc.Tra_ID = vi.Tra_ID
{Filter_ }
Group By vi.Item"

        cmd = New SQLiteCommand($"Select count(*) as count From ({q})", cn)
        Dim rC As SQLiteDataReader
        rC = cmd.ExecuteReader
        While rC.Read
            ProgressBar1.Maximum = Val(rC("count"))
        End While
        rC.Close()

        cmd = New SQLiteCommand(q, cn)
        Using r As SQLiteDataReader = cmd.ExecuteReader
            While r.Read
                ProgressBar1.Value += 1
                Dim Item As String = r("Item_Name").ToString
                Dim Unit As String = r("Unit_Name").ToString
                Dim Va As Decimal = Format(Val(r("Amt")), "0.00")

                Dim qty_ As String = Val(r("Qty").ToString)
                If qty_ > 0 Then
                    Dim c As sp_control_under = Sp_controls1.Add_New()
                    With c

                        .Item_TXT.Text = Item.Trim
                        .Item_TXT.Data_Link_ = r("Item").ToString
                        .Qty_TXT.Text = Val(qty_)
                        .Rate_TXT.Text = nUmBeR_FORMATE(Val(Va) / Val(qty_))
                        .Amount_TXT.Text = Va

                        .GST_Per = (r("GST").ToString)

                        If Val((r("GST").ToString)) <> 0 Then
                            .GST_Enable = True
                        Else
                            .GST_Enable = False
                        End If


                        .Unit_Details_Fill()
                        .SubTotal_Cal()
                    End With
                End If
            End While
        End Using

        If Sp_controls1.exp_panel.Controls.Count = 0 Then
            Sp_controls1.Add_New_exp("User Defined Value", "Not Applicable", 0)
        End If

        cstm_control_mng(Sp_controls1)

        Sp_controls1.SUM()

        'End If
    End Function
    Private Function order_Fill_and_calculation(cn As SQLiteConnection, Tra_ID_ As String)

        Sp_controls1.stock_panel.Controls.Clear()
        Sp_controls1.Clear_All_SUM()
        ProgressBar1.Value = 0
        Dim q As String = $"SELECT *,(Select it.name From TBL_Stock_Item it where it.id = item) as item_name,(Select un.Symbol From TBL_Inventory_Unit un where un.id = (Select it.Unit From TBL_Stock_Item it where it.id = item)) as Unit_Name,vi.Qty
From TBL_VC_item_Details vi
LEFT JOIN TBL_VC vc On vc.Order_No = vi.Tra_ID and vc.Visible = 'Approval'
WHERE vi.Tra_ID = '{Tra_ID_}' and (Select vc.Visible From TBL_VC vc where vc.Tra_ID = vi.Tra_ID) = 'Approval'"

        cmd = New SQLiteCommand($"Select count(*) as count From ({q})", cn)
        Dim rC As SQLiteDataReader
        rC = cmd.ExecuteReader
        While rC.Read
            ProgressBar1.Maximum = Val(rC("count"))
        End While
        rC.Close()


        cmd = New SQLiteCommand(q, cn)
        'My.Computer.Clipboard.SetText(cmd.CommandText)

        Using r As SQLiteDataReader = cmd.ExecuteReader
            While r.Read
                ProgressBar1.Value += 1
                Dim Item As String = r("item_name").ToString
                Dim Unit As String = r("Unit_Name").ToString
                Dim Va As Decimal = Format(Val(r("Amount")), "0.00")

                Dim qty_ As String = Val(r("Qty").ToString)
                If qty_ > 0 Then
                    Dim c As sp_control_under = Sp_controls1.Add_New()
                    With c
                        .Item_TXT.Text = Item.Trim
                        .Item_TXT.Data_Link_ = r("item").ToString
                        .Qty_TXT.Text = Val(qty_)
                        .Rate_TXT.Text = r("Rate").ToString
                        .Amount_TXT.Text = Va
                        .GST_Per = (r("GST_Per").ToString)

                        If Val(r("GST_Per").ToString) <> 0 Then
                            .GST_Enable = True
                        Else
                            .GST_Enable = False
                        End If

                        .Unit_Details_Fill()
                        .SubTotal_Cal()
                    End With
                End If
            End While
        End Using


        cmd = New SQLiteCommand("Select * From TBL_VC_Other where Tra_ID = '" & Tra_ID_ & "'", cn)
        Using r As SQLiteDataReader = cmd.ExecuteReader

            While r.Read
                Dispatch_Doc = r("Dispatch_Doc_No").ToString
                Dispatch_through = r("Dispatch_Through").ToString
                Dispatch_Carrier_Name_agent = r("Carrier_Name_Agent").ToString
                Dispatch_date = CDate(r("Dispatch_Date").ToString)

                Terms_of_payment = (r("Terms_of_payment").ToString)
                Payment_reference = (r("Payment_reference").ToString)
                terms_of_delivery = (r("terms_of_delivery").ToString)

                Yn2.Text = (r("YN_Transport").ToString)
                Yn1.Text = (r("YN_Ewaybill").ToString)

                Transport_Mode = r("Transport_Mode").ToString
                Transport_Distance = r("Transport_Distance").ToString
                Transport_Name = r("Transportation_Name").ToString
                Transport_ID = r("Transport_ID").ToString
                Vihicale_No = r("Vihical_No").ToString
                Vihicale_Type = r("Vihical_Type").ToString
                LR_No = r("LR_No").ToString
                Driver_Name = r("Driver_Name").ToString
                Driver_Phone = r("Driver_Phone").ToString
                Driver_License = r("Driver_License").ToString
                eWay_Bill_No = r("eWay_Bill_No").ToString
                ewayBill_Type = r("ewayBill_Type").ToString
                ewayBill_Document_Type = r("ewayBill_Document_Type").ToString
                From_Address1 = r("From_Address1").ToString
                From_Address2 = r("From_Address2").ToString
                From_Please = r("From_Please").ToString
                From_Pincode = r("From_Pincode").ToString
                To_Name = r("To_Name").ToString
                To_GST = r("To_GST").ToString
                To_Address1 = r("To_Address1").ToString.Trim
                To_Address2 = r("To_Address2").ToString
                To_Please = r("To_Please").ToString
                To_Pincode = r("To_Pincode").ToString
                Ship_Name = r("Ship_Name").ToString
                Ship_Mailing = r("Ship_Mailing_Name").ToString
                Ship_Address = r("Ship_Address").ToString
                To_Country = r("To_Country").ToString
                To_State = r("To_State").ToString
                To_GST_Type = r("To_GST_Type").ToString
                Ship_ID = r("Ship_ID").ToString
                Ship_Country = r("Ship_Country").ToString
                Ship_State = r("Ship_State").ToString


                Export_shipper = r("Place_of_Receipt_by_Shipper").ToString
                Export_port_loading = r("Port_of_Loading").ToString
                Export_port_discharge = r("Port_of_Discharge").ToString
                Export_shipping_bill = r("Shipping_Bill_No").ToString
                Export_Date = r("Export_Date").ToString
                Export_Port_Code = r("Port_Code").ToString
                Export_LUT_No = r("Export_LUT").ToString


                Ship_Pincode = r("Ship_Pincode").ToString
                Ship_GST_Type = r("Ship_GST_Type").ToString
                Ship_GST = r("Ship_GST").ToString

            End While
        End Using

        If Sp_controls1.exp_panel.Controls.Count = 0 Then
            Sp_controls1.Add_New_exp("User Defined Value", "Not Applicable", 0)
        End If

        cstm_control_mng(Sp_controls1)
        'End If
    End Function
    Private Function sj_Fill_All_Data(cn As SQLiteConnection, TBL_ As String, Tra_ID_ As String)
        Stock_journal_controls1.Source_P.Controls.Clear()
        Stock_journal_controls1.Production_P.Controls.Clear()

        ProgressBar1.Value = 0
        Dim q As String = $"Select *,(Select it.name From TBL_Stock_Item it where it.id = item) as item_name,
(Select it.Tax_Type From TBL_Stock_Item it where it.id = item) as TAX_ID,
(Select un.Symbol From TBL_Inventory_Unit un where un.id = (Select it.Unit From TBL_Stock_Item it where it.id = item)) as Unit_Name,
(Select it.Batch_YN From TBL_Stock_Item it where it.id = item) as Batch_YN,
(Select it.Mfg_YN From TBL_Stock_Item it where it.id = item) as Mfg_YN,
(Select it.Exp_YN From TBL_Stock_Item it where it.id = item) as Exp_YN
    From {TBL_} where Tra_ID = '{Tra_ID_}'"

        cmd = New SQLiteCommand($"Select count(*) as count From ({q})", cn)
        Dim rC As SQLiteDataReader
        rC = cmd.ExecuteReader
        While rC.Read
            ProgressBar1.Maximum = Val(rC("count"))
        End While
        rC.Close()




        cmd = New SQLiteCommand(q, cn)
        Using r As SQLiteDataReader = cmd.ExecuteReader
            While r.Read
                ProgressBar1.Value += 1
                Dim Item As String = r("item_name").ToString
                Dim Unit As String = r("Unit_Name").ToString
                Dim Va As Decimal = Format(Val(r("Amount")), "0.00")

                If r("Type") = "Debit" Then
                    With Stock_journal_controls1
                        .Add_New_S()
                        Dim idx As Integer = (.Source_P.Controls.Count)
                        .Find_Particuls_TXT(idx, True).Text = Item.Trim

                        .Find_AccID_Label(idx, True).Text = r("item")
                        .Find_qty_TXT(idx, True).Text = r("Qty").ToString
                        .Find_unit_lab(idx, True).Text = r("Unit_Name").ToString

                        '.find_stock_lab(idx, True).Text = Val(Item_Stock(.Find_AccID_Label(idx, True).Text, Date_TXT.Text, Tra_ID_))

                        .Find_Other_data(idx, True).Text = Fill_vc_Item_Other_Data(cn, r("ID"))
                        If Batches_YN = True Then
                            .Find_Batch_YN_Label(idx, True).Text = r("Batch_YN").ToString
                            .Find_mfg_YN_Label(idx, True).Text = r("Mfg_YN").ToString
                            .Find_exp_YN_Label(idx, True).Text = r("Exp_YN").ToString
                        Else
                            .Find_Batch_YN_Label(idx, True).Text = "No"
                            .Find_mfg_YN_Label(idx, True).Text = "No"
                            .Find_exp_YN_Label(idx, True).Text = "No"
                        End If

                        .fill_balance_S(.Find_Particuls_TXT(idx, True))
                    End With
                ElseIf r("Type") = "Credit" Then
                    With Stock_journal_controls1
                        .Add_New_P()
                        Dim idx As Integer = (.Production_P.Controls.Count)
                        .Find_Particuls_TXT(idx, False).Text = Item.Trim

                        .Find_AccID_Label(idx, False).Text = r("item")
                        .Find_qty_TXT(idx, False).Text = r("Qty").ToString

                        .Find_unit_lab(idx, False).Text = r("Unit_Name").ToString

                        '.find_stock_lab(idx, False).Text = Val(Item_Stock(.Find_AccID_Label(idx, False).Text, Date_TXT.Text, Tra_ID_))

                        .Find_Other_data(idx, False).Text = Fill_vc_Item_Other_Data(cn, r("ID"))
                        If Batches_YN = True Then
                            .Find_Batch_YN_Label(idx, False).Text = r("Batch_YN").ToString
                            .Find_mfg_YN_Label(idx, False).Text = r("Mfg_YN").ToString
                            .Find_exp_YN_Label(idx, False).Text = r("Exp_YN").ToString
                        Else
                            .Find_Batch_YN_Label(idx, False).Text = "No"
                            .Find_mfg_YN_Label(idx, False).Text = "No"
                            .Find_exp_YN_Label(idx, False).Text = "No"
                        End If
                        .fill_balance_P(.Find_Particuls_TXT(idx, False))
                    End With
                End If
            End While
        End Using

        cstm_control_mng(Stock_journal_controls1)
        With Stock_journal_controls1
            If .Source_P.Controls.Count = 0 Then
                .Add_New_S()
            End If
            If .Production_P.Controls.Count = 0 Then
                .Add_New_P()
            End If
        End With
    End Function

    Public Function Sp_Fill_All_Data(cn As SQLiteConnection, Tra_ID_ As String, isorder As Boolean)
        Sp_controls1.Clear_All_SUM()

        Sp_controls1.stock_panel.Controls.Clear()
        Sp_controls1.exp_panel.Controls.Clear()

        ProgressBar1.Value = 0

        Dim q As String = $"Select *,
(Select ifnull(SUM(vvi.Qty),0) -

(Select ifnull(SUM(vi1.Qty),0) From TBL_VC_item_Details vi1 where vi1.Item = vvi.Item and (Select vc.Order_No From TBL_VC vc where vc.Tra_ID = vi1.Tra_ID and vc.Type = 'Head' and vc.Visible = 'Approval' and vc.Tra_ID <> {Tra_ID}) = vvi.Tra_ID)

From TBL_VC_item_Details vvi
where vvi.Tra_ID = vi.Tra_ID and vvi.Item = vi.Item) as Order_Qty,
(Select it.name From TBL_Stock_Item it where it.id = item) as item_name,
(Select un.Symbol From TBL_Inventory_Unit un where un.id = vi.Unit) as Unit_Curr,
(Select un.Decimal From TBL_Inventory_Unit un where un.id = vi.Unit) as Unit_Decimal_Curr,
(Select un.Symbol From TBL_Inventory_Unit un where un.id = vi.Unit1) as Unit_1,
(Select un.Decimal From TBL_Inventory_Unit un where un.id = vi.Unit1) as Unit_Decimal_1,
(Select un.Symbol From TBL_Inventory_Unit un where un.id = vi.Unit2) as Unit_2,
(Select un.Decimal From TBL_Inventory_Unit un where un.id = vi.Unit2) as Unit_Decimal_2,
(Select it.Alter_Unit_Val1 From TBL_Stock_Item it where it.id = item) as Unit_Valuation_1,
(Select it.Alter_Unit_Val2 From TBL_Stock_Item it where it.id = item) as Unit_Valuation_2,
(Select it.Batch_YN From TBL_Stock_Item it where it.id = item) as Batch_YN,
(Select it.Mfg_YN From TBL_Stock_Item it where it.id = item) as Mfg_YN,
(Select it.Exp_YN From TBL_Stock_Item it where it.id = item) as Exp_YN
    From TBL_VC_item_Details vi where Tra_ID = '{Tra_ID_}'"

        cmd = New SQLiteCommand($"Select count(*) as count From ({q})", cn)
        Dim rC As SQLiteDataReader
        rC = cmd.ExecuteReader
        While rC.Read
            ProgressBar1.Maximum = Val(rC("count"))
        End While
        rC.Close()

        cmd = New SQLiteCommand(q, cn)
        Using r As SQLiteDataReader = cmd.ExecuteReader
            While r.Read
                ProgressBar1.Value += 1
                Dim Item As String = r("item_name").ToString
                Dim Unit As String = ""
                Dim qty As String = (r("Order_Qty").ToString)
                Dim unit_type As String = (r("Unit_Type").ToString)
                Dim alter_unit As String = ""
                Dim actule_qty As String = ""

                If isorder = True Then
                    qty = (r("Order_Qty").ToString)
                Else
                    qty = (r("Qty").ToString)
                End If


                Dim Va As Decimal = Format(Val(r("Amount")), "0.00")

                Dim c As sp_control_under = Sp_controls1.Add_New()
                With c
                    .Item_TXT.Text = Item.Trim
                    .Item_TXT.Data_Link_ = r("item")
                    .Qty_TXT.Text = qty
                    .Qty_TXT.Decimal_ = Val(r("Unit_Decimal_Curr").ToString)
                    .Qty1 = Val(r("Qty1").ToString)
                    .Qty2 = Val(r("Qty2").ToString)
                    .Rate_TXT.Text = r("Rate").ToString
                    .Amount_TXT.Text = Va

                    .Unit_Lst.Text = r("Unit_Curr").ToString
                    .Unit_Lst.Data_Link_ = r("Unit").ToString

                    .Unit1_ID = r("Unit1").ToString
                    .Unit1_Symbol = r("Unit_1").ToString
                    .Unit1_Decimal = r("Unit_Decimal_1").ToString
                    .Unit1_Value = Val(r("Unit_Valuation_1").ToString)

                    .Unit2_ID = r("Unit2").ToString
                    .Unit2_Symbol = r("Unit_2").ToString
                    .Unit2_Decimal = r("Unit_Decimal_2").ToString
                    .Unit2_Value = Val(r("Unit_Valuation_2").ToString)

                    .Qty1 = r("Qty1").ToString
                    .Qty2 = r("Qty2").ToString

                    .DiscountP_TXT.Text = nUmBeR_FORMATE(r("Discount_P").ToString)
                    .DiscountP_TXT.Data_Link_ = Val(r("Discount_A").ToString)

                    .GST_Per = (r("GST_Per").ToString)
                    .GST_Amount = Val(r("CGST").ToString) + Val(r("SGST").ToString) + Val(r("IGST").ToString) '& "₹"

                    .Cess_Per = (r("Cess_Per").ToString)
                    .Cess_Amount = (r("Cess_Amt").ToString)

                    .Discription_Label.Text = (r("Description").ToString)

                    If Val((r("GST_Per").ToString)) <> 0 Then
                        .GST_Enable = True
                    Else
                        .GST_Enable = False
                    End If

                    .CGST_ID = r("CGST_ID").ToString
                    .SGST_ID = r("SGST_ID").ToString
                    .IGST_ID = r("IGST_ID").ToString
                    .Cess_ID = r("Cess_ID").ToString

                    .Head_Account_ID = r("Ledger_ID").ToString


                    .Unit_data_fill()
                    .SubTotal_Cal()
                    .Set_Object_()


                End With
            End While
            Sp_controls1.SUM()
        End Using


        cmd = New SQLiteCommand($"Select *,(Select l.Name From TBL_Ledger l where l.ID = vl.Ledger) as Ledger_Name From TBL_VC_Ledger vl Where vl.Tra_ID = '{Tra_ID}' And vl.Type = 'Exp'", cn)
        Using r As SQLiteDataReader = cmd.ExecuteReader
            While r.Read
                Sp_controls1.Add_New_exp("User Defined Value", "Not Applicable", 0)
                Dim idx As Integer = Sp_controls1.exp_panel.Controls.Count

                Sp_controls1.Find_Exp_Bg(idx).Tag = r("Type_of_Calculation").ToString
                Sp_controls1.Find_Round_(idx).Text = r("Rounding_Method").ToString
                Sp_controls1.Find_Round_(idx).Tag = Val(r("Rounding_Limit").ToString)
                Sp_controls1.Find_exp_TXT(idx).Text = r("Ledger_Name").ToString
                Sp_controls1.Find_exp_TXT(idx).Data_Link_ = r("Ledger").ToString
                Sp_controls1.Find_exp_rate_TXT(idx).Text = Val(r("Rate").ToString)
                Sp_controls1.Find_exp_amt_TXT(idx).Text = Val(r("Dr").ToString) + Val(r("Cr").ToString)
            End While
            r.Close()
        End Using

        ProgressBar1.Value = 0

        cmd = New SQLiteCommand("Select * From TBL_VC_Other where Tra_ID = '" & Tra_ID_ & "'", cn)
        Using r As SQLiteDataReader = cmd.ExecuteReader

            While r.Read
                Dispatch_Doc = r("Dispatch_Doc_No").ToString
                Dispatch_through = r("Dispatch_Through").ToString
                Dispatch_Carrier_Name_agent = r("Carrier_Name_Agent").ToString
                Dispatch_date = CDate(r("Dispatch_Date").ToString)

                Terms_of_payment = (r("Terms_of_payment").ToString)
                Payment_reference = (r("Payment_reference").ToString)
                terms_of_delivery = (r("terms_of_delivery").ToString)

                Yn2.Text = (r("YN_Transport").ToString)
                Yn1.Text = (r("YN_Ewaybill").ToString)

                Vebrij_Gross = r("Vebrij_Gross").ToString
                Vebrij_Net = r("Vebrij_Net").ToString
                Vebrij_Vihical = r("Vebrij_Vehical").ToString

                Transport_Mode = r("Transport_Mode").ToString
                Transport_Distance = r("Transport_Distance").ToString
                Transport_Name = r("Transportation_Name").ToString
                Transport_ID = r("Transport_ID").ToString
                Vihicale_No = r("Vihical_No").ToString
                Vihicale_Type = r("Vihical_Type").ToString
                LR_No = r("LR_No").ToString
                Driver_Name = r("Driver_Name").ToString
                Driver_Phone = r("Driver_Phone").ToString
                Driver_License = r("Driver_License").ToString
                eWay_Bill_No = r("eWay_Bill_No").ToString
                ewayBill_Type = r("ewayBill_Type").ToString
                ewayBill_Document_Type = r("ewayBill_Document_Type").ToString
                From_Address1 = r("From_Address1").ToString
                From_Address2 = r("From_Address2").ToString
                From_Please = r("From_Please").ToString
                From_Pincode = r("From_Pincode").ToString
                To_Name = r("To_Name").ToString
                To_GST = r("To_GST").ToString
                To_Address1 = r("To_Address1").ToString.Trim
                To_Address2 = r("To_Address2").ToString
                To_Please = r("To_Please").ToString
                To_Pincode = r("To_Pincode").ToString
                Ship_Mailing = r("Ship_Mailing_Name").ToString
                Ship_Name = r("Ship_Name").ToString
                Ship_Address = r("Ship_Address").ToString
                To_Country = r("To_Country").ToString
                To_State = r("To_State").ToString
                To_GST_Type = r("To_GST_Type").ToString
                Ship_ID = r("Ship_ID").ToString
                Ship_Country = r("Ship_Country").ToString
                Ship_State = r("Ship_State").ToString
                Ship_Pincode = r("Ship_Pincode").ToString
                Ship_GST_Type = r("Ship_GST_Type").ToString
                Ship_GST = r("Ship_GST").ToString

                Export_shipper = r("Place_of_Receipt_by_Shipper").ToString
                Export_port_loading = r("Port_of_Loading").ToString
                Export_port_discharge = r("Port_of_Discharge").ToString
                Export_shipping_bill = r("Shipping_Bill_No").ToString
                If r("Export_Date").ToString = Nothing Then
                    Export_Date = CDate(r("Date").ToString)
                Else
                    Export_Date = CDate(r("Export_Date").ToString)
                End If
                Export_Port_Code = r("Port_Code").ToString
                Export_LUT_No = r("Export_LUT").ToString
            End While
        End Using
        Cfg_Link()

        If Sp_controls1.exp_panel.Controls.Count = 0 Then
            Sp_controls1.Add_New_exp("User Defined Value", "Not Applicable", 0)
        End If

        cstm_control_mng(Sp_controls1)


        Sp_controls1.Vc_GST_summary_ctrl1.Refresh_Data_()



        'End If
    End Function
    Private Function Fill_vc_Item_Other_Data(cn As SQLiteConnection, TBL_VI As String) As String
        Dim data As String = ""
        cmd = New SQLiteCommand($"Select * From TBL_VC_Item_Other_Details where TBL_VI = '{TBL_VI}'", cn)
        Dim r As SQLiteDataReader
        r = cmd.ExecuteReader
        While r.Read
            data &= $"{r("Godown").ToString}‼{r("Batch").ToString}‼{r("Qty").ToString}‼{r("Rate").ToString}‼{r("Amount").ToString}‼{r("Mfg").ToString}‼{r("Exp").ToString}│"
        End While
        r.Close()

        Return data
    End Function
    Public Function Order_Fill_details(tra_id As String)
        If Order_Tra_ID <> tra_id Then
            Sp_controls1.stock_panel.Controls.Clear()
            Sp_controls1.exp_panel.Controls.Clear()
            Sp_controls1.Clear_All_SUM()

            Dim Voucher_Type As String
            'Dim Voucher_TYpe_ID As String
            Dim Order_No As String
            Dim Register_No As String

            Dim Acc As String
            Dim Branch As String

            Dim conn As New SQLiteConnection
            If open_MSSQL_Cstm(Database_File.cre, conn) = True Then

                cmd = New SQLiteCommand($"Select *,(Select ld.name From TBL_Ledger ld where ld.id = Ledger) as Ladger_Name From TBL_VC where Tra_ID = '{tra_id}'", conn)

                Dim r As SQLiteDataReader
                r = cmd.ExecuteReader

                While r.Read
                    If r("Type") = "Head" Then
                        Branch = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Name", "ID = '" & r("Branch") & "'")

                        Order_Tra_ID = tra_id
                        Acc_ID = r("Ledger")
                        Acc = r("Ladger_Name")
                        To_ID = Acc_ID

                        Narration_TXT.Text = r("Narration")

                        Yn1.Text = "No"
                        Yn2.Text = r("Transport_YN").ToString
                        Yn3.Text = r("Payment_Details_YN").ToString
                    ElseIf r("Type") = "Exp" Then
                        Sp_controls1.Add_New_exp("User Defined Value", "Not Applicable", 0)
                        Dim idx As Integer = Sp_controls1.exp_panel.Controls.Count

                        Sp_controls1.Find_exp_TXT(idx).Text = r("Ladger_Name")
                        Sp_controls1.Find_exp_rate_TXT(idx).Text = Val(r("Rate").ToString)
                        Sp_controls1.Find_exp_amt_TXT(idx).Text = Val(r("Debit_Amount").ToString) + Val(r("Credit_Amount").ToString)
                    End If

                End While
                r.Close()

                Account_TXT.Text = Acc

                cstm_control_mng(Item_Progress_Panel)

                Timer_Order_Load.Start()
            End If
            GST_Type_()
            Cfg_Link()
        End If
    End Function
    Public Function Display_all_Data(isOrder As Boolean, Order_ID As String)
        If VC_Formate <> "Stock Journal" Then
            Sp_controls1.stock_panel.Controls.Clear()
            Sp_controls1.exp_panel.Controls.Clear()
            Sp_controls1.Clear_All_SUM()
        End If


        If isOrder = False Then
            Tra_ID = Link_Valu(0)
        End If

        Dim ID As String

        If isOrder = False Then
            ID = Tra_ID
        Else
            ID = Order_ID
        End If

        Dim Voucher_Type As String
        Dim Order_No As String

        Dim Acc As String
        Dim Branch As String

        Dim conn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, conn) = True Then

            cmd = New SQLiteCommand($"Select *,
(Select ld.name From TBL_Ledger ld where ld.id = Ledger) as Ladger_Name,
(Select vcc.Visible From TBL_vc vcc where vcc.Tra_Id = vcM.Order_No) as Order_Next
From TBL_VC vcM where Tra_ID = '{ID}'", conn)

            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                If r("Type") = "Head" Then
                    'Voucher_No Details.////////////////////////////////////
                    If isOrder = False Then
                        If r("Order_Next").ToString = "Approval" Then
                            Order_Next = True
                        Else
                            Order_Next = False
                        End If

                        Voucher_ID = r("Voucher_ID")
                        Voucher_Type = r("Voucher_Type")
                        VC_Formate_ID = r("Voucher_Type_ID")
                        VC_ID_ = r("Voucher_No")
                    End If

                    'Ordre Details///////////////////////////////////////////
                    If isOrder = False Then
                        If r("Order_No").ToString.Trim <> Nothing Then
                            Order_Tra_ID = r("Order_No")
                            Order_Type = Find_DT_Value(Database_File.cre, "TBL_VC", "Voucher_Type", "Tra_ID" & " = '" & r("Order_No") & "'")
                            Order_No = Find_DT_Value(Database_File.cre, "TBL_VC", "Voucher_No", "Tra_ID" & " = '" & Order_Tra_ID & "'")
                            Order_YN.Text = "Yes"
                        ElseIf r("Register_No").ToString.Trim <> Nothing Then
                            Order_Tra_ID = r("Register_No")
                            Order_Type = Find_DT_Value(Database_File.cre, "TBL_VC", "Voucher_Type", "Tra_ID" & " = '" & r("Register_No") & "'")
                            Order_YN.Text = "Yes"
                        End If

                        If VC_Type_ <> "Duplicate" Then
                            If isOrder = False Then
                                Voucher_No_TXT.Text = r("Voucher_No").ToString
                            End If
                            supplier_vc_no = r("Supplier_IVC_No").ToString
                            credit_note_resion = r("Cr_Dr_note_resion").ToString
                            supplier_narration = r("Supplier_Nerration").ToString

                            If Date_Formate((r("Supplier_IVC_Date").ToString)) <> Nothing Then
                                If CDate((r("Date").ToString)) <> CDate((r("Supplier_IVC_Date").ToString)) Then
                                    supplier_date = CDate((r("Supplier_IVC_Date").ToString)).ToString(Date_Format_fech)
                                End If
                            End If

                        End If
                    End If
                    'Other Details

                    Branch = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Name", "ID = '" & r("Branch") & "'")

                    If isOrder = False Then
                        Date_TXT.Text = r("Date").ToString
                        Delivery_Date_TXT.Text = Date_Formate(r("Delivery_Date").ToString)

                    End If

                    Acc_ID = r("Ledger").ToString

                    Acc = r("Ladger_Name").ToString
                    To_ID = Acc_ID

                    Narration_TXT.Text = r("Narration")

                    Yn1.Text = r("EwayBill_YN").ToString
                    Yn2.Text = r("Transport_YN").ToString
                    Yn3.Text = r("Payment_Details_YN").ToString

                    Round_UP_Vlu = Val(r("Round_Off").ToString)



                    If r("Voucher_Type").ToString = "Sales" Then
                        If r("Effect_Stock").ToString = "Yes" Then
                            Sp_controls1.Txt1.Text = "Sales"
                        Else
                            Sp_controls1.Txt1.Text = "Outward Register"
                        End If
                    ElseIf r("Voucher_Type").ToString = "Purchase" Then
                        If r("Effect_Stock").ToString = "Yes" Then
                            Sp_controls1.Txt1.Text = "Purchase"
                        Else
                            Sp_controls1.Txt1.Text = "Inward Register"
                        End If
                    End If
                End If
                '
            End While
            r.Close()


            Voucher_Setup(VC_Formate_ID)

            Account_TXT.Text = Acc

            If VC_Type_ = "Duplicate" Then
                Order_YN.Text = "No"
            Else
                'Order_YN.Enabled = False
            End If

            If VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close" Then
                Acc_Balance = Val(Val((Ledger_Balance(Acc_ID, CDate(Date_TXT.Text), Tra_ID, Branch_ID_)))) * -1
            Else
                Acc_Balance = Val(Val((Ledger_Balance(Acc_ID, CDate(Date_TXT.Text), "0", Branch_ID_)))) * -1
            End If
        End If

        cstm_control_mng(Item_Progress_Panel)

        If isOrder = False Then
            Timer1.Start()
        Else
            Order_Timer.Start()
        End If
        'Closing_Balance_Set()

        'Order Details Fill
        If isOrder = False Then
            If Order_Type = "Sales Order" Or Order_Type = "Purchase Order" Then
                Label29.Text = Order_No
                Label30.Text = Date_Formate(Find_DT_Value(Database_File.cre, "TBL_VC", "Date", "Tra_ID" & " = '" & Order_Tra_ID & "'"))
                Label31.Text = Date_Formate(Find_DT_Value(Database_File.cre, "TBL_VC", "Delivery_Date", "Tra_ID" & " = '" & Order_Tra_ID & "'"))
                Order_Panel.Visible = True
                Register_Panel.Visible = False
            ElseIf Order_Type = "Inward Register" Or Order_Type = "Outward Register" Then
                Label38.Text = Order_No
                Label37.Text = Date_Formate(Find_DT_Value(Database_File.cre, "TBL_VC", "Date", "Tra_ID" & " = '" & Order_Tra_ID & "'"))

                Register_Panel.Visible = True


                Dim cn As New SQLiteConnection
                If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                    cmd = New SQLiteCommand($"Select * From TBL_VC vc where vc.Tra_ID = '{Find_DT_Value(Database_File.cre, "TBL_VC", "Order_No", "Tra_ID" & " = '" & Order_Tra_ID & "'")}' and vc.Type = 'Head'", cn)
                    Dim r As SQLiteDataReader
                    r = cmd.ExecuteReader
                    While r.Read
                        Dim vc_type As String = r("Voucher_Type").ToString
                        If vc_type = "Sales Order" Or vc_type = "Purchase Order" Then
                            Label29.Text = r("Voucher_No").ToString
                            Label30.Text = Date_Formate(r("Date").ToString)
                            Label31.Text = Date_Formate(r("Delivery_Date").ToString)
                            Order_Panel.Visible = True
                        End If
                    End While
                    cn.Close()
                End If
            Else
                Order_Panel.Visible = False
                Register_Panel.Visible = False
            End If
        End If

        If VC_Formate <> "Stock Journal" Then
            If Order_Type = "Inward Register" Or Order_Type = "Outward Register" Then
                Sp_controls1.custome_stock_Panel.Visible = True
            Else
                Sp_controls1.custome_stock_Panel.Visible = False
            End If
        End If

        Fill_Attage()
        GST_Type_()

        '
        Cfg_Link()

        Fill_Attage()
        Fill_EwayBill()

        'Tra_ID = ""
    End Function
    Dim Round_UP_Vlu As Decimal = 0
    Dim s As Integer = 0
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        s += 1
        If s = 2 Then
            Dim cn As New SQLiteConnection
            sender.Stop()
            If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                If Voucher_all_inventory() = True Then
                    Sp_controls1.roundup_val_Lab.Text = Round_UP_Vlu
                    Sp_Fill_All_Data(cn, Tra_ID, False)

                ElseIf Voucher_Type_LB.Text = "Stock Journal" Then
                    sj_Fill_All_Data(cn, "TBL_VC_item_Details", Tra_ID)
                End If
            End If
            If VC_Type_ = "Duplicate" Then
                Tra_ID = ""
            End If


            s = 0
        End If
    End Sub
    Private Sub Order_Timer_Tick(sender As Object, e As EventArgs) Handles Order_Timer.Tick
        s += 1
        If s = 2 Then
            Dim cn As New SQLiteConnection
            sender.Stop()
            If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                If Voucher_all_inventory() = True Then
                    Sp_controls1.roundup_val_Lab.Text = Round_UP_Vlu
                    Sp_Fill_All_Data(cn, Order_Tra_ID, True)
                End If
            End If
            s = 0
        End If
    End Sub


    Private Sub Timer_Order_Load_Tick(sender As Object, e As EventArgs) Handles Timer_Order_Load.Tick
        s += 1
        If s = 2 Then
            Dim cn As New SQLiteConnection
            sender.Stop()
            If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                order_Fill_and_calculation(cn, Order_Tra_ID)
            End If
            s = 0
        End If
    End Sub
    Private Sub Marge_Timer_Tick(sender As Object, e As EventArgs) Handles Marge_Timer.Tick
        s += 1
        If s = 2 Then
            Dim cn As New SQLiteConnection
            sender.Stop()
            If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                Marge_Fill_and_calculation(cn, Marge_Voucher_Filter)
            End If
            s = 0
        End If
    End Sub

    Private Function Fill_EwayBill()
        If VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close" Then
            Dim cn As New SQLiteConnection
            If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                cmd = New SQLiteCommand($"Select * From TBL_EwayBill eb where eb.Tra_ID = '{Tra_ID}'", cn)
                Dim r As SQLiteDataReader
                r = cmd.ExecuteReader
                While r.Read
                    eb_ewaybill_no = r("ewaybill_no").ToString
                    eb_date = r("Date").ToString
                    eb_Sub_Type = r("Sub_Type").ToString
                    eb_Document_Type = r("Document_Type").ToString
                    eb_Consignee_F = r("Consignee_F").ToString
                    eb_Address1_F = r("Address1_F").ToString
                    eb_Address2_F = r("Address2_F").ToString
                    eb_Please_F = r("Please_F").ToString
                    eb_Pincode_F = r("Pincode_F").ToString
                    eb_GSTIN_F = r("GSTIN_F").ToString
                    eb_State_F = r("State_F").ToString
                    eb_Consignee_T = r("Consignee_T").ToString
                    eb_Address1_T = r("Address1_T").ToString
                    eb_Address2_T = r("Address2_T").ToString
                    eb_Please_T = r("Please_T").ToString
                    eb_State_dispath_T = r("Dispatch_State").ToString
                    eb_State_ship_T = r("Ship_State").ToString
                    eb_Pincode_T = r("Pincode_T").ToString
                    eb_GSTIN_T = r("GSTIN_T").ToString
                    eb_State_T = r("State_T").ToString
                    eb_Mode = r("Mode").ToString
                    eb_Distance = r("Distance").ToString
                    eb_Transport_Name = r("Transport_Name").ToString
                    eb_Transport_ID = r("Transport_ID").ToString
                    eb_Vehicle_No = r("Vehicle_No").ToString
                    eb_Vehicle_Type = r("Vehicle_Type").ToString
                    eb_LR_No = r("LR_No").ToString
                End While
                r.Close()
            End If
            cn.Close()
        End If
    End Function
    Private Function Fill_Attage()
        If VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close" Then
            If open_MSSQL(Database_File.rec) = True Then
                DataGridView1.Rows.Clear()
                qury = "Select * From TBL_Attage where TBL = 'TBL_VC' and TBL_ID = '" & Tra_ID & "' and Visible = 'Approval'"
                cmd = New SQLiteCommand(qury, con)
                Dim r As SQLiteDataReader
                r = cmd.ExecuteReader
                While r.Read
                    DataGridView1.Rows.Add(r("ID"), r("Name"), r("Narration"), r("Attage_Type"), r("Attage"), r("Password"))
                End While
            End If
            Label20.Text = DataGridView1.Rows.Count
        End If
    End Function
    Dim Credit_Warning As Boolean = False
    Private Sub Label28_TextChanged(sender As Object, e As EventArgs) Handles Label28.TextChanged
        If Ledger_Credit_Expire_Action <> "Not Applicable" Then
            If Val(Label28.Text) < 0 Then
                NOT_($"Credit Limit Expired ({Label28.Text})", NOT_Type.Erro)
            Else
                NOT_Clear()
            End If
        End If
    End Sub

    Private Sub Yn1_KeyDown(sender As Object, e As KeyEventArgs) Handles Yn1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Yn1.Text = "Yes" Then
                Cell("EwayBill")
            End If
        End If
    End Sub

    Private Sub Yn2_KeyDown(sender As Object, e As KeyEventArgs) Handles Yn2.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Yn2.Text = "Yes" Then
                'Dim pop As Popup
                'Dim Audit_cfg_pop As Object
                'Audit_cfg_pop = New vc_transport_ctrl
                'pop = New Popup(Audit_cfg_pop)

                'pop.FocusOnOpen = True
                'Audit_cfg_pop.obj = sender

                'pop.AnimationDuration = 1
                'pop.Show(sender)

                Cell("Vouchers Transport")
            End If
        End If
    End Sub

    Public Function Other_Fechers_(Bo As Boolean, ParamArray Pn As Panel())
        For Each P As Panel In Pn
            P.Visible = Bo
        Next

        EwayBill_Panel.BringToFront()
        Transport_Panel.BringToFront()
        Payment_Details_Panel.BringToFront()

        If (Voucher_Type_LB.Text = "Sales" Or Voucher_Type_LB.Text = "Sales Order" Or Voucher_Type_LB.Text = "Purchase" Or Voucher_Type_LB.Text = "Purchase Order") Then
        Else
            Payment_Details_Panel.Visible = False
        End If
    End Function


    Private Sub Branch_TXT_LostFocus(sender As Object, e As EventArgs)
        Fill_Source()
    End Sub
    Private Sub Yn2_TextChanged(sender As Object, e As EventArgs) Handles Yn2.TextChanged

    End Sub

    Private Sub Yn3_TextChanged(sender As Object, e As EventArgs) Handles Yn3.TextChanged

    End Sub

    Private Sub Order_YN_TextChanged(sender As Object, e As EventArgs) Handles Order_YN.TextChanged

    End Sub
    Private Sub Order_YN_KeyDown(sender As Object, e As KeyEventArgs) Handles Order_YN.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Order_YN.Text = "Yes" Then
                'Dim pop As Popup
                'Dim Audit_cfg_pop As Object
                'Audit_cfg_pop = New vc_order_details_ctrl
                'pop = New Popup(Audit_cfg_pop)

                'pop.FocusOnOpen = True
                'Audit_cfg_pop.obj = sender

                'pop.AutoSize = True

                ''pop.AutosizeMode
                'pop.AnimationDuration = 1
                'pop.Show(sender)

                Cell("Vouchers Order Details")
            End If
        End If
    End Sub

    Private Sub Txt3_TextChanged(sender As Object, e As EventArgs) Handles Txt3.TextChanged

    End Sub

    Private Sub Yn3_KeyDown(sender As Object, e As KeyEventArgs) Handles Yn3.KeyDown
        If e.KeyCode = Keys.Enter Then
            If sender.Text = "Yes" Then
                Dim pop As Popup
                Dim Audit_cfg_pop As Object
                Audit_cfg_pop = New vc_payment_terms_ctrl
                pop = New Popup(Audit_cfg_pop)

                pop.FocusOnOpen = True
                Audit_cfg_pop.obj = sender

                pop.AnimationDuration = 1
                pop.Show(sender)
            End If
        End If
    End Sub

    Private Sub Txt3_Enter(sender As Object, e As EventArgs) Handles Txt3.Enter
        Dim result As DialogResult = Msg_Save_YN(Voucher_No_TXT, Voucher_Name_LB.Text)

        If result = DialogResult.Yes Then
            Save_Data()
        ElseIf result = DialogResult.No Then
            Date_TXT.Focus()
        ElseIf result = DialogResult.Cancel Then
            SendKeys.Send("{BACKSPACE}")
        End If
    End Sub

    Private Sub Panel30_Paint(sender As Object, e As PaintEventArgs) Handles Panel30.Paint

    End Sub

    Private Sub Order_YN_LostFocus(sender As Object, e As EventArgs) Handles Order_YN.LostFocus
        If Order_YN.Text <> "Yes" Then
            Order_Tra_ID = ""
            Order_Type = ""
        End If
    End Sub

    Private Sub Account_TXT_TextChanged(sender As Object, e As EventArgs) Handles Account_TXT.TextChanged

    End Sub

    Private Sub Panel11_Paint(sender As Object, e As PaintEventArgs)
        obj_center(sender, Me)
    End Sub

    Private Sub Txt4_TextChanged(sender As Object, e As EventArgs)

    End Sub
    Private Function Create_Ledger(txt As TXT)
        Cell("Account Ledger", "", "Create_Close", "")
        With Ledger_frm
            .close_focus_obj = txt
            .Name_TXT.Text = txt.Text
            If Voucher_Type_LB.Text = "Sales" Or Voucher_Type_LB.Text = "Sales Order" Or Voucher_Type_LB.Text = "Outward Register" Or Voucher_Type_LB.Text = "Debit Note" Or Voucher_Type_LB.Text = "Purchase Return" Then
                .Group_TXT.Text = "Sundry Debtors"
            Else
                .Group_TXT.Text = "Sundry Creditors"
            End If
        End With

    End Function
    Private Sub Account_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles Account_TXT.KeyDown
        If e.KeyCode = Keys.Enter Then
            If acc_list.List_Grid.CurrentRow.Cells(1).Value = "Create Ledger" Then
                Create_Ledger(sender)
                Exit Sub
            End If
            Acc_ID = acc_list.List_Grid.CurrentRow.Cells(2).Value
            'Account_TXT.Text = acc_list.List_Grid.CurrentRow.Cells(0).Value

            Fill_Account_Details()
            Select_Ledger()

            Cfg_Link()

        End If


        If e.KeyCode = Keys.C AndAlso e.Modifiers = Keys.Alt Then
            Create_Ledger(sender)
        ElseIf e.KeyCode = Keys.Enter AndAlso e.Modifiers = Keys.Control Then
            Cell("Account Ledger", "", "Alter_Close", Acc_ID)
            Ledger_frm.close_focus_obj = sender
        ElseIf e.KeyCode = Keys.Enter Then
            If cfg_alter_account_details = True Then
                'Cell("VC Ledger Details")
            Else
            End If
        End If
    End Sub
    Public Function Select_Ledger()
        Acc_Balance = nUmBeR_FORMATE(acc_list.List_Grid.CurrentRow.Cells(7).Value)

        Acc_Credit = Val(Find_DT_Value(Database_File.cre, "TBL_Ledger", "Cradit", $"Name = '{Account_TXT.Text}'"))

        If To_Country.ToLower = "india" Or To_Country = Nothing Then
            export_panle.Visible = False
            Yn6.Text = "No"
        Else
            export_panle.Visible = True
        End If

        Closing_Balance_Set()
        GST_Type_()

        Chack_GSTR()
    End Function

    Private Function Fill_Account_Details()
        If To_ID <> Acc_ID Then
            Dim cn As New SQLiteConnection
            If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                cmd = New SQLiteCommand($"Select Country,State,GSTNo,Pincode,GST_Type From TBL_Ledger ld where ld.id = '{Acc_ID}'", cn)
                Dim r As SQLiteDataReader
                r = cmd.ExecuteReader
                While r.Read
                    To_Country = r("Country").ToString
                    To_State = r("State").ToString
                    To_GST = r("GSTNo").ToString
                    To_Pincode = r("Pincode").ToString
                    To_GST_Type = r("GST_Type").ToString

                    If Voucher_type_() = "Outward" Then
                        Ship_Country = r("Country").ToString
                        Ship_State = r("State").ToString
                        Ship_GST = r("GSTNo").ToString
                        Ship_GST_Type = r("GST_Type").ToString
                        Ship_Pincode = r("Pincode").ToString
                    ElseIf Voucher_type_() = "Inward" Then
                        Ship_Country = "India"
                        Ship_State = Company_State_str
                        Ship_GST = Company_GST_str
                        Ship_GST_Type = Company_GST_Type_str
                        Ship_Pincode = Company_Pincode_str
                    End If
                End While
                r.Close()
            End If

            If Voucher_type_() = "Inward" Then
                Ship_Address = Address_set_Company(Acc_ID)
                Ship_Name = Company_Name_str
                Ship_Mailing = Company_Name_str
                Ship_ID = 0
            Else
                Ship_Name = acc_list.List_Grid.CurrentRow.Cells(0).Value.ToString()
                Ship_Mailing = acc_list.List_Grid.CurrentRow.Cells(0).Value.ToString()
                Ship_ID = acc_list.List_Grid.CurrentRow.Cells(2).Value
                Ship_Address = Address_set(Acc_ID)
            End If

            To_Address1 = Address_set(Acc_ID)
        End If


        To_Name = acc_list.List_Grid.CurrentRow.Cells(0).Value.ToString()
        To_ID = acc_list.List_Grid.CurrentRow.Cells(2).Value


        If To_Country = "India" Or To_Country = Nothing Then
            export_panle.Visible = False
            Yn6.Text = "No"
        Else
            export_panle.Visible = True
        End If
    End Function

    Public Function Address_set_Company(id As String)
        Dim Address As String = Company_Address_str
        Dim Phone As String = Company_Phone_str
        Dim PAN As String = Company_PAN_str
        Dim GST As String = Company_GST_str

        If Phone <> "" Then
            Address &= $",{vbNewLine} Phone : {Phone}"
        End If
        If GST <> "" Then
            Address &= $",{vbNewLine} GST : {GST}"
        End If

        If PAN <> "" Then
            Address &= $",{vbNewLine} GST : {PAN}"
        End If

        Return Address
    End Function
    Public Function Address_set(id As String)
        Dim Address As String = ""
        Dim Phone As String = ""
        Dim GST As String = ""


        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select * From TBL_Ledger ld where ld.id = '{id}'", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                Address = r("Address").ToString
                Phone = r("Phone").ToString
                GST = r("GSTNo").ToString
            End While
            r.Close()
        End If

        If Phone <> "" Then
            Address &= $",{vbNewLine} Phone : {Phone}"
        End If
        If GST <> "" Then
            Address &= $",{vbNewLine} GST : {GST}"
        End If

        Return Address
    End Function

    Private Sub Yn4_TextChanged(sender As Object, e As EventArgs) Handles Yn4.TextChanged

    End Sub

    Private Sub Panel10_Paint(sender As Object, e As PaintEventArgs) Handles Panel10.Paint
        obj_center(sender, Item_Progress_Panel)
    End Sub

    Private Sub Panel11_Paint_1(sender As Object, e As PaintEventArgs) Handles Panel11.Paint

    End Sub

    Private Sub Head_Acc_TXT_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Yn4_KeyDown(sender As Object, e As KeyEventArgs) Handles Yn4.KeyDown
        If e.KeyCode = Keys.Enter Then
            If sender.Text = "Yes" Then
                Cell("VC Ledger Details")
            End If
        End If
    End Sub
    Public Function Chack_GSTR()
        Dim error_string As String = ""
        If Voucher_Type_LB.Text.ToLower = "sales" Then
            'Chack GSTR1
            error_string = ""
            If To_Country.ToLower <> "india" Then error_string &= ", Country"
            If nUmBeR_FORMATE(Sp_controls1.GST_Total.Text) = 0 Then error_string &= ", GST Rate"
            If To_GST_Type.ToLower <> "regular" Then error_string &= ", GST Type"
            If gstr1_frm.State_Filter(To_State) = False Then error_string &= ", State"
            If To_GST.Length = 16 Then error_string &= ", GST No."

            If error_string = "" Then
                GSTR_Set($"This voucher is eligible for GSTR.", Color.Green)
                Exit Function
            Else
                GSTR_Set($"This voucher is eligible for GSTR{error_string}", Color.Red)
            End If
        End If
    End Function
    Private Function GSTR_Set(str As String, color_ As Color)
        Label1.Text = str
        Label1.ForeColor = color_
    End Function

    Private Sub Label17_Click(sender As Object, e As EventArgs) Handles Label19.Click, Label20.Click, PictureBox5.Click
        With attage_display
            .Grid_ = Me.DataGridView1
            .ShowDialog()
            Label20.Text = DataGridView1.Rows.Count
        End With
    End Sub

    Private Sub Label33_Click(sender As Object, e As EventArgs) Handles Label33.Click

    End Sub

    Private Sub Delivery_Date_TXT_TextChanged(sender As Object, e As EventArgs) Handles Delivery_Date_TXT.TextChanged

    End Sub

    Private Sub Date_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles Date_TXT.KeyDown
        If e.KeyCode = Keys.Enter Then

        End If
    End Sub

    Private Sub Label30_Click(sender As Object, e As EventArgs) Handles Label30.Click

    End Sub

    Private Sub Yn5_TextChanged(sender As Object, e As EventArgs) Handles Yn5.TextChanged

    End Sub

    Private Sub Delivery_Date_TXT_LostFocus(sender As Object, e As EventArgs) Handles Delivery_Date_TXT.LostFocus
        If sender.Text = "" Then
            Delivery_Date_TXT.Text = Date_Formate(Date_TXT.Text)
        End If
        If CDate(Delivery_Date_TXT.Text) < CDate(Date_TXT.Text) Then
            Delivery_Date_TXT.Focus()
            Exit Sub
        End If
        Label21.Text = $"{DateDiff(DateInterval.Day, CDate(Date_TXT.Text), CDate(Delivery_Date_TXT.Text))} Days"
    End Sub

    Private Sub TableLayoutPanel7_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel7.Paint

    End Sub

    Private Sub Yn6_TextChanged(sender As Object, e As EventArgs) Handles Yn6.TextChanged

    End Sub

    Private Sub Yn5_KeyDown(sender As Object, e As KeyEventArgs) Handles Yn5.KeyDown
        If e.KeyCode = Keys.Enter Then
            If sender.Text = "Yes" Then
                Cell("VC Supplier Details")
            End If
        End If
    End Sub

    Private Sub Yn6_KeyDown(sender As Object, e As KeyEventArgs) Handles Yn6.KeyDown
        If e.KeyCode = Keys.Enter Then
            If sender.Text = "Yes" Then
                Cell("Inventory Voucher Export Details")
            End If
        End If
    End Sub

    Private Sub Class_TXT_TextChanged(sender As Object, e As EventArgs) Handles Class_TXT.TextChanged

    End Sub

    Private Sub Class_Panel_Paint(sender As Object, e As PaintEventArgs) Handles Class_Panel.Paint
        obj_top(Class_Panel)
    End Sub

    Private Sub Class_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles Class_TXT.KeyDown
        If e.KeyCode = Keys.Enter Then
            Bg_Panel.Visible = True
            Class_Panel.Visible = False
            Class_TXT.Data_Link_ = Class_list.List_Grid.CurrentRow.Cells(1).Value
            Class_Data_fill(Class_TXT.Data_Link_)
        End If
    End Sub

    Dim Head_Filter_on_CLass As String = ""
    Private Function Class_Data_fill(Class_ID As String)

        'Head Filter
        Dim Temp_FIlter As String = "Primary Filter"
        Dim Filter_arr As New List(Of String)

        Dim cn As New SQLiteConnection
        Dim r As SQLiteDataReader
        open_MSSQL_Cstm(Database_File.cre, cn)
        cmd = New SQLiteCommand($"Select * From TBL_Vouchers_Class_Head_Filter where Class_ID = '{Class_ID}'", cn)
        r = cmd.ExecuteReader
        While r.Read
            If r("Status").ToString = "Not Allowed" Then
                Temp_FIlter = "Custome Filter"
                Filter_arr.Add($"(LD.[Group] <> '{r("Group_ID").ToString}')")
            ElseIf r("Status").ToString = "Allow" Then
                Temp_FIlter = "Custome Filter"
                Filter_arr.Add($"(LD.[Group] = '{r("Group_ID").ToString}')")
            End If
        End While
        r.Close()

        If Temp_FIlter = "Primary Filter" Then
            Head_Filter_on_CLass = $" AND ((LD.[Group] = '27') or (LD.[Group] = '22') or (LD.[Group] = '26') or (LD.[Group] = '7'))"
        ElseIf Temp_FIlter = "Custome Filter" Then
            For i As Integer = 0 To Filter_arr.Count - 1
                If i = 0 Then
                    Head_Filter_on_CLass = $"{Filter_arr(i).ToString}"
                Else
                    Head_Filter_on_CLass &= $" OR {Filter_arr(i).ToString}"
                End If
            Next
            Head_Filter_on_CLass = $" AND ({Head_Filter_on_CLass})"
        End If
        Fill_Source()

        'Under Filter
        Sp_controls1.exp_panel.Controls.Clear()

        Sp_controls1.Enable_Expance = True
        cmd = New SQLiteCommand($"Select *,(Select L.Name From TBL_Ledger L where L.ID = vc.Ledger_ID) as Ledger_Name
From TBL_Vouchers_Class_Additional_Entries vc where Class_ID = '{Class_ID}'", cn)
        r = cmd.ExecuteReader
        While r.Read
            With Sp_controls1
                .Enable_Expance = False
                .Add_New_exp(r("Type_of_Calculation").ToString, r("Rounding_Method").ToString, Val(r("Rounding_Limit").ToString))

                Dim idx As Integer = .exp_panel.Controls.Count - 0
                .Find_exp_TXT(idx).Text = r("Ledger_Name").ToString
                .Find_exp_TXT(idx).Data_Link_ = r("Ledger_ID").ToString

                .Find_exp_rate_TXT(idx).Text = Val(r("Default_Value").ToString)

            End With
        End While
        r.Close()

        With Sp_controls1
            If .exp_panel.Controls.Count = 0 Then
                .Add_New_exp("User Defined Value", "Not Applicable", 0)
            End If
        End With
    End Function

    Private Sub Inventory_Vouchers_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
    End Sub
End Class