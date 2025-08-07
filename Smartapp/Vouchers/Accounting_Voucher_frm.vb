Imports System.Data.SQLite
Imports BarcodeLib
Imports Microsoft.Reporting.WinForms
Imports QRCoder
Imports System.IO
Imports System.Text
Imports Tools

Public Class Accounting_Voucher_frm
    Dim From_ID As String
    Public Property Active_ctrl As Control

    Public VC_Type_ As String
    Public VC_ID_ As String
    Public Tra_ID As String
    Dim Audit_ID As String
    Public VC_Formate As String
    Public VC_Formate_ID As String

    Dim Path_End As String
    Dim List_Fing_Bs As BindingSource
    Dim Voucher_ID As Integer
    'Voucher_Setup Variabels\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    Dim Payroll_Date1, Payroll_Date2 As Date

    Dim Ledger_Credit_Expire_Action As String
    '
    Dim Acc_Phone As String
    Dim Acc_Email As String
    Dim Acc_Address As String


    'Transportation Details
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

    Public Ship_Name As String
    Public Ship_Address As String

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

        BG_frm.HADE_TXT.Text = "Accounting Voucher"
        BG_frm.TYP_TXT.Text = VC_Type_
        Date_TXT.Text = Now.Date
        Branch_ID = Branch_ID_()
        Branch_TXT.Text = Dft_Branch


        Fill_Source()
        List_set()
        Set_msg()

        controls_add(VC_Formate.ToLower)
        Branch_Setup()


        If VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close" Or VC_Type_ = "Duplicate" Then
            If vc_Transfer = False Then
                Display_all_Data()
            End If
        ElseIf VC_Type_ = "Audit" Then
            Audit_ID = Link_Valu(3)
            Display_all_Data()
        ElseIf VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Or VC_Type_ = "Voucher Transfer" Then
            Defolt_Set_Voucher()
            Tra_ID = "0"
        End If

        Button_Manage()
        Add_Hander_Remove_Handel(True)

        Date_TXT.Focus()
    End Sub
    Private Function Qry_Filters(yn_branch As Boolean) As String
        Dim q As String = ""
        q &= $" and (vc.Effect_Ledger = 'Yes')"
        q &= $" and (vc.Visible = 'Approval')"
        'q &= $" and (vc.Type = 'Head')"
        q &= $" and (vc.[Date] <= '{CDate(Date_TXT.Text).AddDays(1).ToString(Lite_date_Format)}')"
        If Branch_ID <> 0 And yn_branch = True Then
            q &= " AND VC.Branch = '" & Branch_ID & "'"
        End If

        If VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close" Then
            q &= $" and (vc.Tra_ID <> '{Tra_ID}')"
        End If
        Return q
    End Function
    Dim msg_Acc As Msg_frm
    Dim msg_date As Msg_frm
    Dim msg_branch As Msg_frm
    Dim msg_vc_no As Msg_frm
    Private Function Set_msg()
        msg_Acc = New Msg_frm
        Account_TXT.Msg_Object = msg_Acc

        msg_date = New Msg_frm
        Date_TXT.Msg_Object = msg_date

        msg_branch = New Msg_frm
        Branch_TXT.Msg_Object = msg_branch

        msg_vc_no = New Msg_frm
        Voucher_No_TXT.Msg_Object = msg_vc_no
    End Function
    Dim acc_list As List_frm
    Dim branch_list As List_frm
    Dim vc_type_list As List_frm
    Private Function List_set()

        acc_list = New List_frm
        List_Setup("List of Ledger", Select_List.Right_Dock, Select_List_Format.Defolt, Account_TXT, acc_list, Account_Source, 450)
        acc_list.Set_COlor(6)
        acc_list.System_Data_integer = 1

        branch_list = New List_frm
        List_Setup("List of Branch", Select_List.Right, Select_List_Format.Defolt, Branch_TXT, branch_list, Branch_source, 300)
        branch_list.Set_COlor(4)
        branch_list.System_Data_integer = 1

    End Function
    Private Function Fill_Source()
        Dim Positive As String = Find_DT_Value(Database_File.cmp, "TBL_Features", "Value", "Head = 'Positive Value'")
        Dim Negative As String = Find_DT_Value(Database_File.cmp, "TBL_Features", "Value", "Head = 'Negative Value'")

        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            Dim dt_cash As New DataTable
            dt_cash.Columns.Clear()
            dt_cash.Columns.Add("Name")
            dt_cash.Columns.Add("Curr. Balance")
            dt_cash.Columns.Add("ID")
            dt_cash.Columns.Add("Alias")
            dt_cash.Columns.Add("Group")
            dt_cash.Columns.Add("Curr. Credit")
            dt_cash.Columns.Add("Color")
            dt_cash.Columns.Add("balance_")

            dt_cash.Rows.Add("", "Create")

            'dt_.Rows.Add("End of List")
            Dim r As SQLiteDataReader
            cmd = New SQLiteCommand($"Select [ID],[Name],[Group],[Alise],[Cradit],
(Select ifnull((Select ifnull(SUM(vc.Cr),0)-ifnull(SUM(vc.Dr),0) From TBL_VC_Ledger vc Where vc.Ledger = LD.ID and vc.[Date] <= '{CDate(Date_TXT.Text).AddDays(1).ToString(Lite_date_Format)}' and vc.Tra_ID <> '{Tra_ID}'),0)+ifnull((Select ifnull(sum(lob.OB_Cr),0)-ifnull(sum(lob.OB_Dr),0) From TBL_Ledger_Opning_Balance lob where lob.Ledger_ID = LD.ID and lob.Branch_ID = '{Branch_ID}'),0)) as Bal_
from TBL_Ledger LD where {Branch_Enable_Ledger("LD.id", Branch_ID)} and " & Company_Visible_Filter(), cn)

            'My.Computer.Clipboard.SetText(Company_Visible_Filter)

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

                    If r("Group") = "17" Or r("Group") = "27" Or r("Group") = "28" Then
                        dt_cash.Rows.Add(r("Name"), Vlu_, r("ID"), r("Alise"), r("Group"), Credit_, Color_, Val(r("Bal_").ToString))
                    End If
                End While
            End With
            r.Close()
            Account_Source.DataSource = dt_cash
            'Fill_Particuls_data(True)
            Account_filter_set()
            'Direct Fill Source

            Branch_source.DataSource = Fill_Branch_data(cn)
            Order_Source.DataSource = Fill_Vouchhers(cn)


        End If
    End Function
    Public Function Fill_Branch_data(cn As SQLiteConnection) As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow

        dt.Clear()
        dt.Columns.Add("Name")
        dt.Columns.Add("Bal")
        dt.Columns.Add("Alias")
        dt.Columns.Add("Bal_val")
        dt.Columns.Add("Color")
        dt.Columns.Add("ID")

        dt.Rows.Add("", "Create", "", "", "", "")
        dt.Rows.Add("Primary", "", "", "", "", "")

        cmd = New SQLiteCommand($"Select *,
(Select (ifnull(SUM(vc.Credit_Amount),0) - ifnull(SUM(vc.Debit_Amount),0))+(Select ifnull(sum(lob.OB_Cr),0)-ifnull(sum(lob.OB_Dr),0) From TBL_Ledger_Opning_Balance lob where lob.Ledger_ID = ld.id) From TBL_VC vc where vc.Branch = ld.id and vc.Effect_Ledger = 'Yes' {Qry_Filters(False)}) as Bal_
From TBL_Ledger ld WHERE ld.Visible = 'Approval' and ld.[Group] = '7'", cn)
        Dim r As SQLiteDataReader
        r = cmd.ExecuteReader
        'My.Computer.Clipboard.SetText(cmd.CommandText)
        While r.Read
            dr = dt.NewRow
            dr("ID") = r("ID")
            dr("Name") = r("Name")
            dr("Alias") = r("Alise")
            If Val(r("Bal_")) > 0 Then
                dr("Bal") = $"{Val(r("Bal_"))} {Negative_Value_fech}"
                dr("Color") = "Red"
            ElseIf Val(r("Bal_")) < 0 Then
                dr("Bal") = $"{Val(r("Bal_")) * -1} {Positive_Value_fech}"
                dr("Color") = "Black"
            Else
                dr("Color") = "Black"
                dr("Bal") = ""
            End If

            dr("Bal_val") = Val(r("Bal_"))
            dt.Rows.Add(dr)
        End While
        r.Close()
        Return dt
    End Function
    Public Function Defolt_Set_Voucher()
        If VC_Formate = "Contra" Then
            Contra_Frmt()
        ElseIf VC_Formate = "Payment" Then
            Payment_Frmt()
        ElseIf VC_Formate = "Receipt" Then
            Receipt_Frmt()
        ElseIf VC_Formate = "Journal" Then
            Journal_Frmt()
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


        Me.BackColor = Color_bg
    End Function
    Private Function GetAllControls(control As Control) As IEnumerable(Of Control)
        Dim controls = control.Controls.Cast(Of Control)()
        Return controls.SelectMany(Function(ctrl) GetAllControls(ctrl)).Concat(controls)
    End Function

    Dim Journal_controls1 As journal_controls
    Public Cprj_controls1 As cprj_controls

    Public Color_bg As Color = Color.White
    Public Function controls_add(typ_ As String)
        If typ_ = "payment" Or typ_ = "receipt" Or typ_ = "contra" Then
            Cprj_controls1 = New cprj_controls

            With Cprj_controls1
                Panel30.Controls.Add(Cprj_controls1)
                .Dock = DockStyle.Fill
                .Fill_Particuls_data(False)
                Defolt_Set_Voucher()
                .Color_bg = Color_bg
                .Add_New()
            End With
        ElseIf typ_ = "journal" Then

            Journal_controls1 = New journal_controls
            Panel30.Controls.Add(Journal_controls1)
            With Journal_controls1
                Defolt_Set_Voucher()
                .Color_bg = Color_bg
                .Dock = DockStyle.Fill
                .Add_New()
            End With
        End If
    End Function
    Private Sub Voucher_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.From_ID = From_ID
        BG_frm.HADE_TXT.Text = "Accounting Voucher"
        BG_frm.TYP_TXT.Text = VC_Type_

        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text
        Button_Clear()
        Cfg_Link()
        Button_Manage()

        Fill_Source()

        If Branch_TXT.Text = "" And Branch_Panel.Visible = True Then
            Branch_TXT.Focus()
        Else
            Date_TXT.Focus()
        End If
    End Sub
    Public VC_Name As String
    Public VC_Under As String
    Public VC_VoucherNo_Method As String
    Public vc_start As String
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

    Public cfg_communication_yn As Boolean = False
    Public cfg_print_derect As Boolean = False
    Public cfg_print_signature As Boolean = False
    Public cfg_print_stamp As Boolean = False
    Public cfg_YN_print_pay_qry As Boolean = False
    Public cfg_print_pay_value As String = ""
    Public cfg_print_Terms_Conditions As String = ""
    Public cfg_print_Provisnoal As String = ""
    Public cfg_YN_print_item_MRP As Boolean = False
    Public cfg_warning__credil_expiar As Boolean = False

    Public cfg_print_path As String = ""
    'Public cfg_Print_format As String = ""
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
                vc_start = r("Voucher_Start").ToString
                VC_VoucherNo_Frist = r("Voucher_No_Prefix").ToString
                VC_VoucherNo_Last = r("Voucher_No_Suffix").ToString
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

                cfg_print_derect = YN_Boolean(r("Print_after_seve").ToString)
                cfg_communication_yn = YN_Boolean(r("Communication_YN").ToString)
                cfg_print_signature = YN_Boolean(r("Print_Signature").ToString)
                cfg_print_stamp = YN_Boolean(r("Print_Stamp").ToString)
                cfg_YN_print_pay_qry = YN_Boolean(r("Print_UPI_QR").ToString)
                cfg_print_Provisnoal = YN_Boolean(r("Print_Provisional").ToString)
                cfg_print_pay_value = (r("Print_UPI_QR_Value").ToString)
                cfg_print_Terms_Conditions = (r("Print_Terms_Conditions").ToString)
                cfg_print_path = (r("Print_Path").ToString)
                'cfg_Print_format = (r("Print_format").ToString)
                cfg_YN_print_item_MRP = YN_Boolean(r("Print_Item_MRP").ToString)
                cfg_warning__credil_expiar = YN_Boolean(r("YN_Credit_Limit_Warning").ToString)
            End While
        End If

        Voucher_Name_LB.Text = VC_Name
        Voucher_Type_LB.Text = VC_Under

        Narration_TXT.Visible = cfg_YN_narration
        Label9.Visible = cfg_YN_narration

    End Function
    Private Sub Voucher_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End
        Add_Hander_Remove_Handel(False)
        'Frm_foCus()
    End Sub
    Private Function Button_Manage()
        Button_Clear()
        BG_frm.B_1.Text = "&E : Exit"
        BG_frm.B_2.Text = "&S : Save"
        BG_frm.B_6.Text = "|&P : Print"
        If VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close" Then
            BG_frm.B_3.Text = "&D : Delete"
        End If
        If Login_Type = "Admin Account" And (VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close") Then
            'BG_frm.B_7.Text = "|&O : Audit"
        End If
        BG_frm.R_2.Text = "F2 : Date"

        'If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
        'BG_frm.R_3.Text = "F3 : Account Vch."
        BG_frm.R_5.Text = "F4 : Contra"
        BG_frm.R_6.Text = "F5 : Payment"
        BG_frm.R_7.Text = "F6 : Receipt"
        BG_frm.R_8.Text = "F7 : Journal"
        'End If
        BG_frm.R_9.Text = "F10 : Other Vouchers"
        BG_frm.R_22.Text = "F12 : Configuration"
    End Function
    Private Function Add_Hander_Remove_Handel(Ans As Boolean)
        If Ans = True Then
            AddHandler BG_frm.KeyDown, AddressOf Me.BG_Keydown
            AddHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            AddHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
            AddHandler BG_frm.B_3.Click, AddressOf Me.B_3_Click
            AddHandler BG_frm.B_6.Click, AddressOf Me.B_6_Click

            AddHandler BG_frm.B_7.Click, AddressOf Me.B_7_Click

            AddHandler BG_frm.R_2.Click, AddressOf Me.R_2_Click

            AddHandler BG_frm.R_3.Click, AddressOf Me.R_33_Click
            AddHandler BG_frm.R_5.Click, AddressOf Me.R_3_Click
            AddHandler BG_frm.R_6.Click, AddressOf Me.R_4_Click
            AddHandler BG_frm.R_7.Click, AddressOf Me.R_5_Click
            AddHandler BG_frm.R_8.Click, AddressOf Me.R_6_Click
            AddHandler BG_frm.R_9.Click, AddressOf Me.R_21_Click

            AddHandler BG_frm.R_22.Click, AddressOf Me.R_22_Click
        Else
            RemoveHandler BG_frm.KeyDown, AddressOf Me.BG_Keydown
            RemoveHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            RemoveHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
            RemoveHandler BG_frm.B_3.Click, AddressOf Me.B_3_Click
            RemoveHandler BG_frm.B_6.Click, AddressOf Me.B_6_Click

            RemoveHandler BG_frm.B_7.Click, AddressOf Me.B_7_Click

            RemoveHandler BG_frm.R_2.Click, AddressOf Me.R_2_Click

            RemoveHandler BG_frm.R_3.Click, AddressOf Me.R_33_Click
            RemoveHandler BG_frm.R_5.Click, AddressOf Me.R_3_Click
            RemoveHandler BG_frm.R_6.Click, AddressOf Me.R_4_Click
            RemoveHandler BG_frm.R_7.Click, AddressOf Me.R_5_Click
            RemoveHandler BG_frm.R_8.Click, AddressOf Me.R_6_Click
            RemoveHandler BG_frm.R_9.Click, AddressOf Me.R_21_Click

            RemoveHandler BG_frm.R_22.Click, AddressOf Me.R_22_Click
        End If
    End Function
    Private Sub BG_Keydown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.F2 Then
            BG_frm.R_2.PerformClick()
        End If

        If e.KeyCode = Keys.F4 Then
            BG_frm.R_5.PerformClick()
        End If
        If e.KeyCode = Keys.F5 Then
            BG_frm.R_6.PerformClick()
        End If
        If e.KeyCode = Keys.F6 Then
            BG_frm.R_7.PerformClick()
        End If

        If e.KeyCode = Keys.F7 Then
            BG_frm.R_8.PerformClick()
        End If

        If e.KeyCode = Keys.F12 Then
            BG_frm.R_22.PerformClick()
        End If

        If e.KeyCode = Keys.F10 AndAlso e.Modifiers = Keys.Alt Then

        ElseIf e.KeyCode = Keys.F10 AndAlso e.Modifiers = Keys.Control Then

        ElseIf e.KeyCode = Keys.F10 Then
            BG_frm.R_9.PerformClick()
        End If
    End Sub

    Private Sub B_1_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Me.Dispose()
        End If
    End Sub

    Private Sub B_2_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            If cfg_warning__credil_expiar = True Then
                If Msg_Credit_Warning_Dialoag(Account_TXT.Text, N2_FORMATE(Label28.Text)) <> DialogResult.Yes Then
                    Account_TXT.Focus()
                    Exit Sub
                End If
            End If
            Save_Data()
        ElseIf BG_frm.HADE_TXT.Text = "Ledger Details" Then
            Account_TXT.Focus()
        End If
    End Sub
    Private Sub B_7_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub R_33_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Voucher_BG_frm.Dispose()
            Cell("Voucher BG", "", "Create", "Purchase")
        End If
    End Sub
    Private Sub R_3_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Cell("Filter", "Change Voucher:Contra", BG_frm.HADE_TXT.Text)
            'Contra_Frmt()
        End If
    End Sub
    Private Sub R_4_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Cell("Filter", "Change Voucher:Payment", BG_frm.HADE_TXT.Text)
            'Payment_Frmt()
        End If
    End Sub
    Private Sub R_5_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Cell("Filter", "Change Voucher:Receipt", BG_frm.HADE_TXT.Text)
            'Receipt_Frmt()
        End If
    End Sub
    Private Sub R_6_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Cell("Filter", "Change Voucher:Journal", BG_frm.HADE_TXT.Text)
            'Journal_Frmt()
        End If
    End Sub
    Private Sub R_21_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Cell("Filter", "Change Voucher:All Vouchers", BG_frm.HADE_TXT.Text)
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
                        Msg(NOT_Type.Erro, "Data is not delete", "")
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
    Private Sub B_6_Click(sender As Object, e As EventArgs)
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

    Private Function Print_data_CPRJ(idx As Integer, dt As DataTable, img_stm_QR As MemoryStream, img_barcode_stm As MemoryStream) As DataTable()
        Dim ds As New Print_dt
        Dim dr As DataRow

        If Voucher_Type_LB.Text = "Payment" Or Voucher_Type_LB.Text = "Receipt" Or Voucher_Type_LB.Text = "Contra" Then
            dt = ds.Tables("TBL_cprj")

            Dim total_amount As Decimal = 0
            If idx = 0 Then
                total_amount = Format(Val(Cprj_controls1.Total_lab.Text), "0.00")
            Else
                total_amount = Format(Val(Cprj_controls1.Find_Amount_TXT(idx).Text), "0.00")
            End If

            Dim P_ As New Queue(Of Panel)()
            If idx = 0 Then
                For Each bg_p As Panel In Cprj_controls1.bg_panel.Controls.OfType(Of Panel)()
                    P_.Enqueue(bg_p)
                Next
            Else
                P_.Enqueue(Cprj_controls1.Find_BG_Panel(idx))
            End If

            For Each bg_p As Panel In P_.Reverse
                Dim Particuls_ As String = Cprj_controls1.Find_Particuls_TXT(Cprj_controls1.Find_Idx(bg_p)).Text
                Dim Amt_ As String = Cprj_controls1.Find_Amount_TXT(Cprj_controls1.Find_Idx(bg_p)).Text

                dr = dt.NewRow
                dr("Company_Name") = Company_Name_str
                dr("Company_Address") = Company_Address_str
                dr("Voucher_Type") = Voucher_Type_LB.Text
                dr("Voucher_No") = Print_IVC_No_
                dr("Date") = Date_TXT.Text
                dr("Day") = Day_Label.Text
                dr("Account") = Account_TXT.Text
                dr("Partiiculars") = Particuls_


                dr("Amount_Word") = NumberToText(Val(total_amount)) & " Only/-"
                dr("Date_Time") = Now.Date.ToString("dddd, dd MMMM,yyyy")
                dr("Narration_P") = ""

                If cfg_YN_narration = True Then
                    dr("Narration_G") = Narration_TXT.Text.Trim
                Else
                    dr("Narration_G") = ""
                End If

                If Voucher_Type_LB.Text = "Payment" Then
                    dr("Dr") = Format(Val(Amt_), "0.00")
                    dr("Cr") = ""
                    dr("cr_dr") = "Dr"
                Else
                    dr("Cr") = Format(Val(Amt_), "0.00")
                    dr("Dr") = ""
                    dr("cr_dr") = "Cr"
                End If


                Dim QR_NSU As Byte()
                QR_NSU = img_stm_QR.GetBuffer
                dr("QR") = QR_NSU

                SET_UPI_cprj(dr)

                Dim BATcode_NSU As Byte()
                BATcode_NSU = img_barcode_stm.GetBuffer

                dr("Barcode") = BATcode_NSU

                If cfg_print_Provisnoal = True Then
                    dr("Provisnoal") = (Cprj_controls1.Find_Balance_Lab_TXT(Cprj_controls1.Find_Idx(bg_p)).Text)
                Else
                    dr("Provisnoal") = "N/A"
                End If

                dt.Rows.Add(dr)
            Next

            dr = dt.NewRow
            If Voucher_Type_LB.Text = "Payment" Then
                dr("Partiiculars") = $"{Account_TXT.Text}"
                dr("Dr") = ""
                dr("Cr") = Format(Val(total_amount), "0.00")
                dr("cr_dr") = "Cr"
                dr("Provisnoal") = "N/A"
            Else
                dr("Partiiculars") = $"{Account_TXT.Text}"
                dr("Cr") = ""
                dr("Dr") = Format(Val(total_amount), "0.00")
                dr("cr_dr") = "Dr"
                dr("Provisnoal") = "N/A"
            End If

            dt.Rows.Add(dr)
        Else
            dt = ds.Tables("TBL_cprj")
            For Each bg_p As Panel In Journal_controls1.bg_panel.Controls.OfType(Of Panel)()
                Dim Particuls_ As String = Journal_controls1.Find_Particuls_TXT(Journal_controls1.Find_Idx(bg_p)).Text
                Dim Crdr_ As String = Journal_controls1.Find_crdr_TXT(Journal_controls1.Find_Idx(bg_p)).Text
                Dim dr_ As String = Journal_controls1.Find_dr_TXT(Journal_controls1.Find_Idx(bg_p)).Text
                Dim cr_ As String = Journal_controls1.Find_cr_TXT(Journal_controls1.Find_Idx(bg_p)).Text

                dr = dt.NewRow
                dr("Voucher_Type") = "Journal"
                dr("Voucher_No") = Print_IVC_No_
                dr("Date") = Date_TXT.Text
                dr("Day") = Day_Label.Text
                dr("cr_dr") = Crdr_

                If Crdr_ = "Dr" Then
                    dr("Dr") = Format(Val(dr_), "N2")
                    dr("Cr") = ""
                ElseIf Crdr_ = "Cr" Then
                    dr("Dr") = ""
                    dr("Cr") = Format(Val(cr_), "N2")
                End If

                dr("Date_Time") = Now.Date.ToString("dddd, dd MMMM,yyyy")
                If Crdr_ = "Dr" Then
                    dr("Partiiculars") = Particuls_
                ElseIf Crdr_ = "Cr" Then
                    dr("Partiiculars") = Particuls_
                End If

                dr("Narration_P") = ""

                If cfg_YN_narration = True Then
                    dr("Narration_G") = Narration_TXT.Text.Trim
                Else
                    dr("Narration_G") = ""
                End If

                Dim QR_NSU As Byte()
                QR_NSU = img_stm_QR.GetBuffer

                dr("QR") = QR_NSU

                Dim BATcode_NSU As Byte()
                BATcode_NSU = img_barcode_stm.GetBuffer

                dr("Barcode") = BATcode_NSU

                If cfg_print_Provisnoal = True Then
                    dr("Provisnoal") = "N/A"
                Else
                    dr("Provisnoal") = "N/A"
                End If


                SET_UPI_cprj(dr)

                dt.Rows.Add(dr)
            Next
        End If

        Return {dt, Print_DT_Company}
    End Function
    Private rdlc_report_data() As ReportDataSource
    Private rdlc_report_name As String
    Private Sub B_Print(idx As Integer)
        Dim Account_ As String
        Print_IVC_No_ = Voucher_No_TXT.Text
        Supp_GST = Find_DT_Value(Database_File.cmp, "TBL_Company_Creation", "GSTNo", "Company_ID = '" & Company_ID_str & "'")
        Supp_PAN = Find_DT_Value(Database_File.cmp, "TBL_Company_Creation", "PANCard", "Company_ID = '" & Company_ID_str & "'")
        Supp_Bank = Find_DT_Value(Database_File.cmp, "TBL_Company_Creation", "Bank", "Company_ID = '" & Company_ID_str & "'")
        Supp_BankAcc = Find_DT_Value(Database_File.cmp, "TBL_Company_Creation", "AccountNo", "Company_ID = '" & Company_ID_str & "'")
        Supp_Branch = Find_DT_Value(Database_File.cmp, "TBL_Company_Creation", "Branch", "Company_ID = '" & Company_ID_str & "'")
        Supp_IFSC = Find_DT_Value(Database_File.cmp, "TBL_Company_Creation", "IFCCode", "Company_ID = '" & Company_ID_str & "'")

        Account_ = To_Name

        If Tra_ID = Nothing Then
            Tra_ID = Tra_ID_Search(Tra_ID, VC_Type_)
        End If


        Dim ds As New Print_dt
        Dim dt As New DataTable
        Dim dr As DataRow
        'QR_COde



        Dim gen As New QRCodeGenerator
        Dim QR_ID As String = "NA"

        Dim amt As Decimal = 0
        If idx = 0 Then
            amt = Val(TOTAL_AMOUNT_VALUE)
        Else
            'amt = Val(Cprj_controls1.Find_Amount_TXT(idx).Text)
        End If

        QR_ID = $"No.:{Voucher_No_TXT.Text};Date:{CDate(Date_TXT.Text).ToString("dd-MM-yyyy")};Type:{Voucher_Type_LB.Text};Amount:{Val(amt)};"


        Dim QR = gen.CreateQrCode(QR_ID, QRCodeGenerator.ECCLevel.Q)
        Dim Q_Code As New QRCode(QR)
        Dim img_QR As Image
        img_QR = Q_Code.GetGraphic(6)

        Dim img_stm_QR As MemoryStream = New MemoryStream
        img_QR.Save(img_stm_QR, Imaging.ImageFormat.Png)

        'Barcode
        Dim Barc As Barcode = New Barcode()
        Dim forcolore As Color = Color.Black
        Dim backcolore As Color = Color.Transparent

        Dim img As Image
        img = (Barc.Encode(TYPE.CODE128, Print_IVC_No_, forcolore, backcolore, CInt(302), CInt(82)))
        Dim img_barcode_stm As MemoryStream = New MemoryStream
        img.Save(img_barcode_stm, Imaging.ImageFormat.Png)


        Dim dt_tbl() As DataTable = Print_data_CPRJ(idx, dt, img_stm_QR, img_barcode_stm)
        rdlc_report_data = {New ReportDataSource("DataSet1", dt_tbl(0)), New ReportDataSource("dt_cmp", dt_tbl(1))}
        rdlc_report_name = $"{Voucher_Type_LB.Text}({Voucher_No_TXT.Text})"

        rdlc_report_name = rdlc_report_name.Replace("\", "-")
        rdlc_report_name = rdlc_report_name.Replace("/", "-")
        rdlc_report_name = rdlc_report_name.Replace(":", "-")
        rdlc_report_name = rdlc_report_name.Replace("*", "-")
        rdlc_report_name = rdlc_report_name.Replace("?", "-")
        rdlc_report_name = rdlc_report_name.Replace("|", "-")
        rdlc_report_name = rdlc_report_name.Replace("<", "-")
        rdlc_report_name = rdlc_report_name.Replace(">", "-")

        If Voucher_Type_LB.Text = "Payment" Or Voucher_Type_LB.Text = "Receipt" Or Voucher_Type_LB.Text = "Contra" Then
            If cfg_print_path = Nothing Then
                cfg_print_path = Application.StartupPath & "\Print_\Voucher\cpr\cprj"
            Else
                ' cfg_print_path &= "\" & cfg_Print_format.Substring(0, cfg_Print_format.Length - 5)
            End If
        ElseIf Voucher_Type_LB.Text = "Journal" Then
            If cfg_print_path = Nothing Then
                cfg_print_path = Application.StartupPath & "\Print_\Voucher\cpr\cprj"
            Else
                'cfg_print_path &= "\" & cfg_Print_format.Substring(0, cfg_Print_format.Length - 5)
            End If
        End If
    End Sub

    Private Function CreateStream(name As String, extension As String, encoding As Encoding, mimeType As String, willSeek As Boolean) As Stream
        Throw New NotImplementedException()
    End Function

    Private Function SET_UPI_cprj(dr As DataRow)
        Dim gen As New QRCodeGenerator
        Dim vlu_ As String = ""

        If cfg_print_pay_value = "Not Applicable" Then

        ElseIf cfg_print_pay_value = "Manual Pay" Then
            vlu_ = "upi://pay?pa=" & Company_UPI_str
            cfg_YN_print_pay_qry = True
        ElseIf cfg_print_pay_value = "Current Value" Then
            vlu_ = "upi://pay?pa=" & Company_UPI_str & "&pn=" & Company_Name_str & "&am=" & Val(Cprj_controls1.Total_lab.Text) & "&cu=INR&"

            If Voucher_Type_LB.Text = "Receipt" Then
                cfg_YN_print_pay_qry = False
            Else
                cfg_YN_print_pay_qry = True
            End If
        ElseIf cfg_print_pay_value = "Provisional Value" Then
            Dim vlu As String = Val(Acc_Balance) + Val(Cprj_controls1.Total_lab.Text)

            vlu_ = "upi://pay?pa=" & Company_UPI_str & "&pn=" & Company_Name_str & "&am=" & Val(vlu) & "&cu=INR&"

            If Val(vlu) > 0 Then
                cfg_YN_print_pay_qry = True
            Else
                cfg_YN_print_pay_qry = False
            End If

        End If

        Dim QR = gen.CreateQrCode(vlu_, QRCodeGenerator.ECCLevel.Q)
        Dim Q_Code As New QRCode(QR)
        Dim img_QR As Image
        img_QR = Q_Code.GetGraphic(6)

        Dim img_stm_QR As MemoryStream = New MemoryStream


        img_QR.Save(img_stm_QR, Imaging.ImageFormat.Png)

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
    Private Sub Payment_Pass()
        Add_Hander_Remove_Handel(False)
        Link_Valu(2) = "Payment"
        Dim e As EventArgs
        Me.Voucher_frm_Load(e, e)
    End Sub
    Private Sub Receipt_Pass()
        Add_Hander_Remove_Handel(False)
        Link_Valu(2) = "Receipt"
        Dim e As EventArgs
        Me.Voucher_frm_Load(e, e)
    End Sub
    Private Sub Journal_Pass()
        Add_Hander_Remove_Handel(False)
        Link_Valu(2) = "Journal"
        Dim e As EventArgs
        Me.Voucher_frm_Load(e, e)
    End Sub
    Private Sub R_22_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Cell("Vouchers Configuration", "", VC_Type_, VC_Formate_ID)
        End If
    End Sub
    Private Sub Contra_Frmt()
        If BG_frm.From_ID = From_ID Then
            Voucher_Type_LB.Text = "Contra"
            Color_bg = Color.OldLace

            'Cprj_controls1.bg_panel.Controls.Clear()
            'Cprj_controls1.Add_New()

            Bg_Panel.Dock = DockStyle.Fill
            Bg_Panel.Show()
            Voucher_Setup(VC_Formate_ID)

            Cprj_controls1.Color_bg = Color_bg
            Cprj_controls1.Color_manag()
        End If
    End Sub
    Private Sub Payment_Frmt()
        If BG_frm.From_ID = From_ID Then
            Voucher_Type_LB.Text = "Payment"
            Color_bg = Color.FromArgb(255, 240, 240)

            'Cprj_controls1.bg_panel.Controls.Clear()
            'Cprj_controls1.Add_New()

            Bg_Panel.Dock = DockStyle.Fill
            Bg_Panel.Show()
            Voucher_Setup(VC_Formate_ID)

            Cprj_controls1.Color_bg = Color_bg
            Cprj_controls1.Color_manag()
        End If
    End Sub
    Private Sub Credit_Note_Frmt()
        If BG_frm.From_ID = From_ID Then
            Voucher_Type_LB.Text = "Credit Note"


            Bg_Panel.Dock = DockStyle.Fill
            Bg_Panel.Show()
            Voucher_Setup(VC_Formate_ID)
        End If
    End Sub
    Private Sub Debit_Note_Frmt()
        If BG_frm.From_ID = From_ID Then
            Voucher_Type_LB.Text = "Debit Note"


            Bg_Panel.Dock = DockStyle.Fill
            Bg_Panel.Show()
            Voucher_Setup(VC_Formate_ID)
        End If
    End Sub
    Private Sub Receipt_Frmt()
        If BG_frm.From_ID = From_ID Then
            Voucher_Type_LB.Text = "Receipt"
            Color_bg = Color.FromArgb(245, 255, 250)


            'Cprj_controls1.bg_panel.Controls.Clear()
            'Cprj_controls1.Add_New()

            Bg_Panel.Dock = DockStyle.Fill
            Bg_Panel.Show()
            Voucher_Setup(VC_Formate_ID)

            Cprj_controls1.Color_bg = Color_bg
            Cprj_controls1.Color_manag()
        End If
    End Sub
    Private Sub Journal_Frmt()
        If BG_frm.From_ID = From_ID Then
            Voucher_Type_LB.Text = "Journal"
            Color_bg = Color.FromArgb(245, 245, 255)

            'Journal_controls1.bg_panel.Controls.Clear()
            'Journal_controls1.Add_New()


            Bg_Panel.Dock = DockStyle.Fill
            Bg_Panel.Show()
            Voucher_Setup(VC_Formate_ID)

            Journal_controls1.Color_bg = Color_bg
            Journal_controls1.Color_manag()
        End If
    End Sub
    Private Function Save_Data()
        If BG_frm.From_ID = From_ID Then
            Try
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
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Function
    Private Function Print_DIrect_Save() As Boolean
        If cfg_print_derect = True Then
            Print_Page()
        End If
        Return True
    End Function
    Public Function Print_Page()
        B_Print(0)
        Printing_Direct_frm.cfg_frm = New cprj_Print_cfg_ctrl
        Dim Nm As String = path_validation($"{VC_Formate} ({Voucher_No_TXT.Text})", "_")
        Printing_Direct_frm.Printing_(cfg_print_path, rdlc_report_name, Nm, rdlc_report_data)
    End Function
    Private Function Create_File_Name() As String
        Dim OPT_Hint As String = ((Val(Now.Date.Day) + Val(Now.Date.Millisecond) + Val(Now.Date.Second) & Val(Val(Now.TimeOfDay.Hours + Now.TimeOfDay.Minutes & Now.Date.Month + Now.Date.Day)) + Val(Val(Now.Date.Year))) - Val(Now.TimeOfDay.Seconds) + Val(Now.TimeOfDay.Milliseconds)) * 12552
        Return Val(OPT_Hint) * 999
    End Function
    Private Function Communication_send() As Boolean
        If Features_mod.Communication_YN = True And cfg_communication_yn = True Then
            If Msg_Custom_YN(NOT_Location.Bottom_Right, Color.Black, My.Resources.Communication_animation_icn, Dialoag_Button.Yes_No, "Question?", "Communication", "Do you want to send this<nl>report on WhatsApp and email") = DialogResult.Yes Then
                If Voucher_Type_LB.Text = "Payment" Or Voucher_Type_LB.Text = "Receipt" Or Voucher_Type_LB.Text = "Contra" Then
                    With Cprj_controls1
                        'sending head data
                        B_Print(0)
                        Dim path As String = Application.StartupPath & $"\_other_savefiles\{Create_File_Name()}.pdf"
                        Export_PDF(cfg_print_path, path, rdlc_report_data)
                        Communication_Pass(0, path, rdlc_report_name)
                        'sending under data
                        For Each bg_p As Panel In .bg_panel.Controls.OfType(Of Panel)()
                            Dim idx As Integer = .Find_Idx(bg_p)
                            B_Print(idx)
                            path = Application.StartupPath & $"\_other_savefiles\{Create_File_Name()}({idx}).pdf"
                            Export_PDF(cfg_print_path, path, rdlc_report_data)
                            Communication_Pass(idx, path, rdlc_report_name)
                        Next
                        Direct_Communication_frm.ShowDialog()
                    End With
                Else
                    With Journal_controls1
                        For Each bg_p As Panel In .bg_panel.Controls.OfType(Of Panel)()
                            Dim idx As Integer = .Find_Idx(bg_p)
                            B_Print(idx)
                            Dim path As String = Application.StartupPath & $"\_other_savefiles\{Create_File_Name()}({idx}).pdf"
                            Export_PDF(cfg_print_path, path, rdlc_report_data)
                            Communication_Pass(idx, path, rdlc_report_name)
                        Next
                        Direct_Communication_frm.ShowDialog()
                    End With
                End If
            End If
        End If
        Return True
    End Function
    Private Function Communication_Pass(idx As String, path_of_file As String, name_ As String)
        If Voucher_Type_LB.Text = "Payment" Or Voucher_Type_LB.Text = "Receipt" Or Voucher_Type_LB.Text = "Contra" Then
            'If Chack_Communication_allow(Account_TXT.Data_Link_, "Communication_Whatsapp") = True Then
            'Whatsapp_Sending_list.Add_to_list(Account_TXT.Text, Account_TXT.Data_Link_, name_, "Document", path_of_file, path_of_file.Split(".").Length, "Pending")
            'End If
            Dim subject As String = $"{Voucher_Name_LB.Text}({Voucher_No_TXT.Text})"
            If idx <> 0 Then
                With Cprj_controls1
                    Dim name As String = .Find_Particuls_TXT(idx).Text
                    Dim id As String = .Find_Particuls_TXT(idx).Data_Link_
                    Dim wh As String = ""
                    Dim em As String = ""

                    Dim whatsapp_allow As Boolean = Chack_Communication_allow(id, "Communication_Whatsapp")
                    Dim email_allow As Boolean = Chack_Communication_allow(id, "Communication_Email")


                    If email_allow = True Then
                        em = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Email", $"id = '{id}'")
                    End If
                    If whatsapp_allow = True Then
                        wh = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Phone", $"id = '{id}'")
                    End If
                    If whatsapp_allow = True Or email_allow = True Then
                        'Whatsapp_Sending_list.Add_to_list(name, wh, em, subject, CDate(Date_TXT.Text).ToString("dd-MMM-yyyy"), "Document", path_of_file, path_of_file.Split(".").Last, "Pending", "Pending")
                        Direct_Communication_frm.Add_list(name, wh, em, subject, CDate(Date_TXT.Text).ToString("dd-MMM-yyyy"), "Document", path_of_file, path_of_file.Split(".").Last)
                    End If
                End With
            Else
                Dim whatsapp_allow As Boolean = Chack_Communication_allow(Account_TXT.Data_Link_, "Communication_Whatsapp")
                Dim email_allow As Boolean = Chack_Communication_allow(Account_TXT.Data_Link_, "Communication_Email")

                Dim em As String = ""
                Dim wh As String = ""

                If whatsapp_allow = True Then
                    em = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Email", $"id = '{Account_TXT.Data_Link_}'")
                End If
                If whatsapp_allow = True Then
                    wh = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Phone", $"id = '{Account_TXT.Data_Link_}'")
                End If

                'Whatsapp_Sending_list.Add_to_list(Account_TXT.Text, wh, em, subject, CDate(Date_TXT.Text).ToString("dd-MMM-yyyy"), "Document", path_of_file, path_of_file.Split(".").Length, "Pending", "Pending")
                Direct_Communication_frm.Add_list(Account_TXT.Text, wh, em, subject, CDate(Date_TXT.Text).ToString("dd-MMM-yyyy"), "Document", path_of_file, path_of_file.Split(".").Length)
            End If

        ElseIf Voucher_Type_LB.Text = "Journal" Then
            With Journal_controls1
                Dim name As String = .Find_Particuls_TXT(idx).Text
                Dim id As String = .Find_Particuls_TXT(idx).Data_Link_
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
            End With
        End If
    End Function
    'Private Function Tra_ID_Search()
    '    If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Or VC_Type_ = "Duplicate" Or VC_Type_ = "Duplicate_Close" Then
    '        If Voucher_Type_LB.Text = "Attendance" Then
    '            Tra_ID = Find_MAX_VLU(Database_File.cre, "TBL_Attendance_VC", "Tra_ID")
    '        Else
    '            Tra_ID = Find_MAX_VLU(Database_File.cre, "TBL_VC", "Tra_ID")
    '        End If
    '    Else
    '        If open_MSSQL(Database_File.cre) Then
    '            If Voucher_Type_LB.Text = "Attendance" Then
    '                qury = "Delete From TBL_Attendance_VC where Tra_ID = '" & Tra_ID & "'"
    '                cmd = New SQLiteCommand(qury, con)
    '                cmd.ExecuteNonQuery()
    '            Else
    '                'TBL_VC
    '                qury = $"Delete From TBL_VC where Tra_ID = '{Tra_ID }'"
    '                cmd = New SQLiteCommand(qury, con)
    '                cmd.ExecuteNonQuery()
    '                'TBL_VC_Ledger
    '                qury = $"Delete From TBL_VC_Ledger where Tra_ID = '{Tra_ID}'"
    '                cmd = New SQLiteCommand(qury, con)
    '                cmd.ExecuteNonQuery()
    '                'Other Details
    '                qury = $"Delete From TBL_VC_Other where Tra_ID = '{Tra_ID }'"
    '                cmd = New SQLiteCommand(qury, con)
    '                cmd.ExecuteNonQuery()

    '            End If
    '        End If
    '    End If

    '    If Voucher_Type_LB.Text = "Attendance" Then
    '        Audit_ID = Find_MAX_VLU(Database_File.cre, "DEL_Attendance_VC", "Audit_ID")
    '    Else
    '        Audit_ID = Find_MAX_VLU(Database_File.cre, "DEL_VC", "Audit_ID")
    '    End If
    'End Function
    Private Function Save_Requr() As Boolean

        If Date_TXT.Text = "" Then
            NOT_("Please enter date and try agin", NOT_Type.Erro)
            Date_TXT.Focus()
            Return False
            Exit Function
        End If
        If Voucher_Type_LB.Text = "Payment" Or Voucher_Type_LB.Text = "Receipt" Or Voucher_Type_LB.Text = "Contra" Or Voucher_Type_LB.Text = "Journal" Then
            If Branch_TXT.Text = "" And Branch_Panel.Visible = True Then
                NOT_("Please select branch and try agin", NOT_Type.Erro)
                Branch_TXT.Focus()
                Return False
                Exit Function
            End If
            If Branch_Visible() = True And Branch_Panel.Visible = True Then
                If Branch_TXT.Text = "Primary".Trim Then
                    Branch_ID = "0"
                ElseIf (Chack_Duplicate(Database_File.cre, "TBL_Ledger", "Name", "Name = '" & Branch_TXT.Text.ToString.Trim & "'") = False) Then
                    NOT_("Branch select error, Please select again", NOT_Type.Erro)
                    Msg_InputError(Branch_TXT, "Branch")
                    Branch_TXT.Focus()
                    Return False
                    Exit Function
                Else
                    Branch_ID = Find_DT_Value(Database_File.cre, "TBL_Ledger", "ID", "Name = '" & Branch_TXT.Text.ToString.Trim & "'")
                End If
            End If
            If Chack_Duplicate(Database_File.cre, "TBL_Ledger", "Name", "Name = '" & Account_TXT.Text & "'") = False And Account_TXT.Visible = True Then
                NOT_("Account select error, Please select again", NOT_Type.Erro)
                Account_TXT.Focus()
                Msg_InputError(Account_TXT, "Account")
                Return False
                Exit Function
            Else
                Account_TXT.Data_Link_ = Find_DT_Value(Database_File.cre, "TBL_Ledger", "ID", "Name = '" & Account_TXT.Text & "'")
            End If
            If Account_TXT.Text = "" And Account_TXT.Visible = True Then
                NOT_("Please select account and try agin", NOT_Type.Erro)
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
        If Val(Label28.Text) < 0 Then
            If cfg_warning__credil_expiar = True Then
                If Msg_Credit_Warning_Dialoag(Account_TXT.Text, N2_FORMATE(Label28.Text)) <> DialogResult.Yes Then
                    SendKeys.Send("{BACKSPACE}")
                    Return False
                End If
            End If
        End If

        If Grid_Status_Chack() = False Then
            Return False
        End If
        Return True
    End Function
    Private Function Grid_Status_Chack() As Boolean
        If Voucher_Type_LB.Text = "Journal" Then
            For Each bg_p As Panel In Journal_controls1.bg_panel.Controls.OfType(Of Panel)()
                If Chack_Duplicate(Database_File.cre, "TBL_Ledger", "Name", "Name = '" & Journal_controls1.Find_Particuls_TXT(Journal_controls1.Find_Idx(bg_p)).Text & "'") = False Then
                    Journal_controls1.Find_Particuls_TXT(Journal_controls1.Find_Idx(bg_p)).Focus()
                Else
                    If Val(Journal_controls1.CL_Cr.Text) <> Val(Journal_controls1.CL_Dr.Text) Then
                        Journal_controls1.Focus()
                        Return False
                    End If

                    If Journal_controls1.Find_crdr_TXT(Journal_controls1.Find_Idx(bg_p)).Text = "Cr" Then
                        If Val(Journal_controls1.Find_cr_TXT(Journal_controls1.Find_Idx(bg_p)).Text) = 0 Then
                            Journal_controls1.Find_cr_TXT(Journal_controls1.Find_Idx(bg_p)).Focus()
                            Return False
                        End If
                    ElseIf Journal_controls1.Find_crdr_TXT(Journal_controls1.Find_Idx(bg_p)).Text = "Dr" Then
                        If Val(Journal_controls1.Find_dr_TXT(Journal_controls1.Find_Idx(bg_p)).Text) = 0 Then
                            Journal_controls1.Find_dr_TXT(Journal_controls1.Find_Idx(bg_p)).Focus()
                            Return False
                        End If
                    Else
                    End If

                    If Val(Journal_controls1.Find_cr_TXT(Journal_controls1.Find_Idx(bg_p)).Text) = 0 And Val(Journal_controls1.Find_dr_TXT(Journal_controls1.Find_Idx(bg_p)).Text) = 0 Then
                        Journal_controls1.bg_panel.Controls.Remove(bg_p)
                    End If
                End If
            Next
        Else
            TOTAL_AMOUNT_VALUE = Val(Cprj_controls1.Total_lab.Text)
            Cprj_controls1.Shado_Color_(Cprj_controls1.Find_Particuls_TXT(Cprj_controls1.bg_panel.Controls.Count))
            For Each bg_p As Panel In Cprj_controls1.bg_panel.Controls.OfType(Of Panel)()
                If Chack_Duplicate(Database_File.cre, "TBL_Ledger", "Name", "Name = '" & Cprj_controls1.Find_Particuls_TXT(Cprj_controls1.Find_Idx(bg_p)).Text & "'") = False Then
                    'Return False
                    Cprj_controls1.bg_panel.Controls.Remove(bg_p)
                Else
                    If cfg_YN_zero = False Then
                        If Val(Cprj_controls1.Find_Amount_TXT(Cprj_controls1.Find_Idx(bg_p)).Text) = 0 Then
                            Cprj_controls1.Find_Amount_TXT(Cprj_controls1.Find_Idx(bg_p)).Focus()
                            Return False
                        End If
                    End If
                End If
            Next
        End If
        Return True
    End Function
    Private Function Data_Save_Manag() As Boolean
        Dim ins_qry As String
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then

            ins_qry = "INSERT INTO TBL_VC 
(Tra_ID,Voucher_ID,Voucher_No,Voucher_Type,Voucher_Type_ID,Date,Branch,Narration,User,PC,Date_install,Visible,Company,Ledger,Credit_Amount,Debit_Amount,Effect_Stock,Effect_Ledger,Type) VALUES 
(@Tra_ID,@Voucher_ID,@Voucher_No,@Voucher_Type,@Voucher_Type_ID,@Date_,@Branch,@Narration,@User,@PC,@Install_,@Visible,@Company,@Ledger,@Credit_Amount,@Debit_Amount,'No','Yes',@Type)"

            If Insurt_Value(cn, ins_qry) = True Then
                cn.Close()
                Return True
            End If
        End If
    End Function
    Private Function Insurt_Head(cn As SQLiteConnection, ins_qry As String)
        cmd = New SQLiteCommand(ins_qry, cn)

        Try
            If Voucher_Type_LB.Text = "Journal" Then
                Dim P_ As New Queue(Of Panel)()
                For Each bg_p As Panel In Journal_controls1.bg_panel.Controls.OfType(Of Panel)()
                    Account_TXT.Data_Link_ = Journal_controls1.Find_Particuls_TXT(Journal_controls1.Find_Idx(bg_p)).Data_Link_
                Next

                With cmd.Parameters
                    .AddWithValue("@Tra_ID", Tra_ID)
                    .AddWithValue("@Voucher_ID", Voucher_ID)
                    .AddWithValue("@Voucher_No", Voucher_No_TXT.Text.Trim)
                    .AddWithValue("@Voucher_Type", Voucher_Type_LB.Text.Trim)

                    .AddWithValue("@Voucher_Type_ID", VC_Formate_ID)
                    .AddWithValue("@Date_", CDate(Date_TXT.Text))

                    .AddWithValue("@Type", "Head")
                    .AddWithValue("@Ledger", Account_TXT.Data_Link_)
                    .AddWithValue("@Credit_Amount", nUmBeR_FORMATE(Journal_controls1.CL_Cr.Text))
                    .AddWithValue("@Debit_Amount", nUmBeR_FORMATE(Journal_controls1.CL_Dr.Text))


                    .AddWithValue("@Branch", Branch_ID.Trim)
                    .AddWithValue("@Narration", Narration_TXT.Text.Trim)
                    .AddWithValue("@Company", Company_ID_str)
                    .AddWithValue("@User", LOGIN_ID)
                    .AddWithValue("@PC", PC_ID.Trim)
                    .AddWithValue("@Install_", CDate(DateTime.Now))

                    .AddWithValue("@Visible", "Approval")

                    cmd.ExecuteNonQuery()
                End With
            Else
                Dim Credit_Amt As String
                Dim Debit_amt As String

                Dim Particuls_value As String
                For Each bg_p As Panel In Cprj_controls1.bg_panel.Controls.OfType(Of Panel)()
                    Particuls_value = Cprj_controls1.Find_Particuls_TXT(Cprj_controls1.Find_Idx(bg_p)).Text
                Next

                With cmd.Parameters
                    .AddWithValue("@Tra_ID", Tra_ID)
                    .AddWithValue("@Voucher_ID", Voucher_ID)
                    .AddWithValue("@Voucher_No", Voucher_No_TXT.Text.Trim)
                    .AddWithValue("@Voucher_Type", Voucher_Type_LB.Text.Trim)

                    .AddWithValue("@Voucher_Type_ID", VC_Formate_ID)
                    .AddWithValue("@Date_", CDate(Date_TXT.Text))



                    If Voucher_Type_LB.Text = "Payment" Then
                        Debit_amt = 0
                        Credit_Amt = nUmBeR_FORMATE(Val(Cprj_controls1.Total_lab.Text))
                    ElseIf Voucher_Type_LB.Text = "Receipt" Or Voucher_Type_LB.Text = "Contra" Then
                        Debit_amt = nUmBeR_FORMATE(Val(Cprj_controls1.Total_lab.Text))
                        Credit_Amt = 0
                    End If

                    .AddWithValue("@Type", "Head")
                    .AddWithValue("@Ledger", Account_TXT.Data_Link_)
                    .AddWithValue("@Credit_Amount", Credit_Amt)
                    .AddWithValue("@Debit_Amount", Debit_amt)

                    Dim amt As Decimal
                    If Voucher_Type_LB.Text = "Payment" Or Voucher_Type_LB.Text = "Receipt" Or Voucher_Type_LB.Text = "Contra" Then
                        amt = Val(Cprj_controls1.Total_lab.Text)
                    End If

                    .AddWithValue("@Branch", Branch_ID.Trim)
                    .AddWithValue("@Narration", Narration_TXT.Text.Trim)
                    .AddWithValue("@Company", Company_ID_str)
                    .AddWithValue("@User", LOGIN_ID)
                    .AddWithValue("@PC", PC_ID.Trim)
                    .AddWithValue("@Install_", CDate(DateTime.Now))

                    .AddWithValue("@Visible", "Approval")

                    cmd.ExecuteNonQuery()
                End With

                'TBL_VC_Ledger
                cmd = New SQLiteCommand("INSERT INTO TBL_VC_Ledger 
(Type,Date,Tra_ID,Ledger,Dr,Cr) VALUES 
(@Type,@Date_,@Tra_ID,@Ledger,@Dr,@Cr)", cn)
                With cmd.Parameters

                    .AddWithValue("@Type", "Head")
                    .AddWithValue("@Date_", CDate(Date_TXT.Text))
                    .AddWithValue("@Tra_ID", Tra_ID)

                    .AddWithValue("@Ledger", Account_TXT.Data_Link_)
                    .AddWithValue("@Cr", Credit_Amt)
                    .AddWithValue("@Dr", Debit_amt)
                End With

                cmd.ExecuteNonQuery()
            End If
        Catch ex As Exception
            Msg(NOT_Type.Erro, "Data Save Error - Head", ex.Message)
            Return False
        End Try
    End Function
    Private Function Insurt_Value(cn As SQLiteConnection, ins_qry As String) As Boolean
        Insurt_Head(cn, ins_qry)
        If Voucher_Type_LB.Text = "Journal" Then

            Dim P_ As New Queue(Of Panel)()
            For Each bg_p As Panel In Journal_controls1.bg_panel.Controls.OfType(Of Panel)()
                P_.Enqueue(bg_p)
            Next
            For Each bg_p As Panel In P_.Reverse
                Dim crdr As String = Journal_controls1.Find_crdr_TXT(Journal_controls1.Find_Idx(bg_p)).Text
                Dim Particuls_ As String = Journal_controls1.Find_Particuls_TXT(Journal_controls1.Find_Idx(bg_p)).Data_Link_
                Dim cR_ As String = Journal_controls1.Find_cr_TXT(Journal_controls1.Find_Idx(bg_p)).Text
                Dim dR_ As String = Journal_controls1.Find_dr_TXT(Journal_controls1.Find_Idx(bg_p)).Text


                cmd = New SQLiteCommand("INSERT INTO TBL_VC_Ledger 
(Type,Date,Tra_ID,Ledger,Dr,Cr) VALUES 
(@Type,@Date_,@Tra_ID,@Ledger,@Dr,@Cr)", cn)
                With cmd.Parameters

                    .AddWithValue("@Type", "Under")
                    .AddWithValue("@Date_", CDate(Date_TXT.Text))
                    .AddWithValue("@Tra_ID", Tra_ID.ToString.Trim)

                    .AddWithValue("@Ledger", Particuls_)
                    .AddWithValue("@Cr", cR_)
                    .AddWithValue("@Dr", dR_)

                    cmd.ExecuteNonQuery()
                End With


            Next
        Else
            Dim P_ As New Queue(Of Panel)()
            For Each bg_p As Panel In Cprj_controls1.bg_panel.Controls.OfType(Of Panel)()
                P_.Enqueue(bg_p)
            Next
            For Each bg_p As Panel In P_.Reverse
                Dim Particuls_ As String = Cprj_controls1.Find_Particuls_TXT(Cprj_controls1.Find_Idx(bg_p)).Data_Link_
                Dim Amt_ As String = nUmBeR_FORMATE(Cprj_controls1.Find_Amount_TXT(Cprj_controls1.Find_Idx(bg_p)).Text)
                Dim Narration_ As String = ""
                If VC_YN_Narration_Cell = "Yes" Then
                    Narration_ = Cprj_controls1.Find_Narration_TXT(Cprj_controls1.Find_Idx(bg_p)).Text
                End If


                Dim Credit_Amt As String
                Dim Debit_amt As String

                If Voucher_Type_LB.Text = "Payment" Then
                    Debit_amt = Amt_
                    Credit_Amt = 0
                ElseIf Voucher_Type_LB.Text = "Receipt" Or Voucher_Type_LB.Text = "Contra" Then
                    Debit_amt = 0
                    Credit_Amt = Amt_
                End If


                cmd = New SQLiteCommand("INSERT INTO TBL_VC_Ledger 
(Type,Date,Tra_ID,Ledger,Dr,Cr) VALUES 
(@Type,@Date_,@Tra_ID,@Ledger,@Dr,@Cr)", cn)
                With cmd.Parameters

                    .AddWithValue("@Type", "Under")
                    .AddWithValue("@Date_", CDate(Date_TXT.Text))
                    .AddWithValue("@Tra_ID", Tra_ID.ToString.Trim)

                    .AddWithValue("@Ledger", Particuls_)
                    .AddWithValue("@Cr", Credit_Amt)
                    .AddWithValue("@Dr", Debit_amt)

                    cmd.ExecuteNonQuery()
                End With
            Next

        End If
        'Expance Insurt
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
        Label3.Text = "0.00"

        If VC_Type_ = "Create" Then
            Voucher_Setup(VC_Formate_ID)
            Account_TXT.Text = " "
            Date_TXT.Focus()

            NOT_("The entry you entered has been successfully accepted", NOT_Type.Success)
            Tra_ID = "0"
            Fill_Source()

            If Voucher_Type_LB.Text = "Payment" Or Voucher_Type_LB.Text = "Receipt" Or Voucher_Type_LB.Text = "Contra" Then

                If Cprj_controls1.Visible = True Then
                    Cprj_controls1.bg_panel.Controls.Clear()
                    Cprj_controls1.Total_lab.Text = "0.00"
                    Cprj_controls1.Add_New()
                End If
            ElseIf Voucher_Type_LB.Text = "Journal" Then
                If Journal_controls1.Visible = True Then
                    Journal_controls1.bg_panel.Controls.Clear()
                    Journal_controls1.CL_Cr.Text = "0.00"
                    Journal_controls1.CL_Dr.Text = "0.00"
                    Journal_controls1.Add_New()
                End If
            End If
        Else
            Voucher_BG_frm.Dispose()
            Update_Report = True
            Frm_foCus()
        End If

    End Function
    Private Function Voucher_Setup(vc As String)
        Cfg_Link()

        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Or VC_Type_ = "Duplicate" Or VC_Type_ = "Duplicate_Close" Or VC_Type_ = "Voucher Transfer" Then
            Voucher_No_Setup()
        End If

        Panel7.Show()

        If Voucher_Type_LB.Text = "Journal" Then
            Account_Panel.Visible = False
        Else
            Account_Panel.Visible = True
        End If

        sp_option_panel.Visible = True
    End Function
    Public Function Voucher_No_Setup()
        Voucher_ID = 0
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select Voucher_ID as C From TBL_VC where Voucher_Type = '{Voucher_Type_LB.Text}' and Voucher_Type_ID = '{VC_Formate_ID}' and {Company_Visible_Filter()} Order By Voucher_ID DESC limit 1", cn)
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

    Public Branch_ID As String
    Private Function Branch_Setup()
        If Branch_Visible() = True Then
            Label1.Show()
            Label12.Show()
            Branch_Panel.Show()
            If Branch_TXT.Text = Nothing Then
                Branch_TXT.Text = Dft_Branch
            End If
        Else
            Label1.Hide()
            Label12.Hide()
            Branch_Panel.Hide()
        End If
        Branch_ID = Branch_ID_()
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


        privoice_date = Date_Formate(Date_TXT.Text)
    End Sub
    Private Function Date_fOrmate_lIV() As Boolean
        If Date_Brack(Date_TXT.Text) = True Then
            Day_Label.Text = Date_TO_Day(Date_TXT.Text)
            Return True
        End If
        Return False
    End Function
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

    End Sub

    Private Sub Account_TXT_Lostfocus(sender As Object, e As EventArgs) Handles Account_TXT.LostFocus
        Credit_Pop = True
    End Sub
    Public Branch_Balance_val As Decimal = 0.00
    Public Acc_Balance As Decimal = 0.00
    Public Acc_Credit As Decimal = 0.00
    Private Sub Account_TXT_Enter(sender As Object, e As EventArgs) Handles Account_TXT.Enter
        Account_filter_set()
    End Sub
    Dim Fiter_String_of_ledger As String = ""
    Private Function Account_filter_set()
        Account_TXT.Select_Filter = "(Name LIKE '%<value>%' or Alias LIKE '%<value>%' or [Curr. Balance] LIKE 'Create')"
    End Function

    Private Function Narration_Set_Auto()
        Dim index As Integer = 0
        If Narration_TXT.Text.Contains("<Date>") Then
            Narration_TXT.Text = Replace(Narration_TXT.Text, "<Date>", Date_TXT.Text)
        End If
        If Narration_TXT.Text.Contains("<Day>") Then
            Narration_TXT.Text = Replace(Narration_TXT.Text, "<Day>", Day_Label.Text)
        End If
        If Narration_TXT.Text.Contains("<Voucher No>") Then
            Narration_TXT.Text = Replace(Narration_TXT.Text, "<Voucher No>", Voucher_No_TXT.Text)
        End If
        If Narration_TXT.Text.Contains("<Voucher Type>") Then
            Narration_TXT.Text = Replace(Narration_TXT.Text, "<Voucher Type>", Voucher_Type_LB.Text)
        End If
        If Narration_TXT.Text.Contains("<Account>") Then
            Narration_TXT.Text = Replace(Narration_TXT.Text, "<Account>", Account_TXT.Text)
        End If
        If Narration_TXT.Text.Contains("<Amount>") Then
            Narration_TXT.Text = Replace(Narration_TXT.Text, "<Amount>", "")
        End If
    End Function

    Dim Account_Balance_ As Decimal
    Public Function Closing_Balance_Set()
        'If Account_TXT.Data_Link_ <> Nothing Then
        If Voucher_Type_LB.Text = "Payment" Then
            Label8.Text = Val(Val(Acc_Balance) + Val(Cprj_controls1.Total_lab.Text))
            Label28.Text = (Acc_Credit + Val(Cprj_controls1.Total_lab.Text))

            Label3.Text = Val(Val(Branch_Balance_val) + Val(Cprj_controls1.Total_lab.Text))

        ElseIf Voucher_Type_LB.Text = "Receipt" Or Voucher_Type_LB.Text = "Contra" Then
            Label8.Text = Val(Val(Acc_Balance) - Val(Cprj_controls1.Total_lab.Text))
            Label28.Text = (Acc_Credit - Val(Cprj_controls1.Total_lab.Text))

            Label3.Text = Val(Val(Branch_Balance_val) - Val(Cprj_controls1.Total_lab.Text))
        End If
        'End If


        Try
            If Val(Label8.Text) >= 0 Then
                Label8.ForeColor = Color.DimGray
                Label8.Text = N2_FORMATE((Val(Label8.Text))) & $" {Positive_Value_fech}"
            ElseIf Val(Label8.Text) < 0 Then
                Label8.ForeColor = Color.Red
                Label8.Text = N2_FORMATE(Val(Label8.Text) * -1) & $" {Negative_Value_fech}"
            End If
        Catch ex As Exception

        End Try

        Try
            If (Label28.Text) <= 0 Then
                Label28.ForeColor = Color.Red
                Label28.Text = ((Val(Label28.Text)))
            Else
                Label28.ForeColor = Color.DimGray
                Label28.Text = (Label28.Text)
            End If
        Catch ex As Exception

        End Try

        Try
            If (Label3.Text) <= 0 Then
                Label3.ForeColor = Color.DimGray
                Label3.Text = N2_FORMATE((Val(Label3.Text) * -1)) & $" {Positive_Value_fech}"
            Else
                Label3.ForeColor = Color.Red
                Label3.Text = N2_FORMATE(Label3.Text) & $" {Negative_Value_fech}"
            End If
        Catch ex As Exception

        End Try
    End Function
    Dim Grid_Balance_Noti As Boolean = True
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
        Dim frm_ As String = "TBL_VC"
        Dim Duplicate_Type As String

        If cfg_YN_Duplicate_No = False Then
            If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Or VC_Type_ = "Duplicate" Or VC_Type_ = "Voucher Transfer" Then
                Duplicate_Type = $" Voucher_No = '{Voucher_No_TXT.Text}' and Voucher_Type_ID = '{VC_Formate_ID }' and {Company_Visible_Filter()}"
            Else
                Duplicate_Type = $" Voucher_No = '{Voucher_No_TXT.Text}' and (Voucher_No <> '{VC_ID_}') and Type = 'Head' and Voucher_Type_ID = '{VC_Formate_ID}' and {Company_Visible_Filter()}"
            End If


            If Voucher_No_TXT.Text = "" Then
                NOT_("Not Valid Without a Blank 'Voucher No'", NOT_Type.Warning)

                Return False
            End If

            If Chack_Duplicate(Database_File.cre, frm_, "Name", Duplicate_Type) = True Then
                NOT_("The Voucher No Entered is a 'Duplicate'", NOT_Type.Warning)

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
    Public TAX_Type As String = ""

    Private Function GST_Type_()

        Dim Company_State As String = Find_DT_Value(Database_File.cmp, "TBL_Company_Creation", "State", "CompanyName  = '" & Company_Name_str & "'").ToUpper()

        Dim Party_State As String = Find_DT_Value(Database_File.cre, "TBL_Ledger", "State", "Name  = '" & Account_TXT.Text & "'").ToUpper()

        If Company_State = Nothing Or Company_State = "(Not Applicable)" Or Party_State = Nothing Then
            TAX_Type = "CS"
        ElseIf Company_State = Party_State Then
            TAX_Type = "CS"
        Else
            TAX_Type = "I"
        End If

    End Function
    Private Function Display_all_Data()

        If VC_Formate.ToLower = "payment" Or VC_Formate.ToLower = "receipt" Or VC_Formate.ToLower = "contra" Then
            Cprj_controls1.bg_panel.Controls.Clear()
        ElseIf VC_Formate.ToLower = "journal" Then
            Journal_controls1.bg_panel.Controls.Clear()
        End If

        Tra_ID = Link_Valu(0)

        Dim Voucher_Type As String
        Dim Head_ID As String

        Dim conn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, conn) = True Then
            cmd = New SQLiteCommand($"Select ID,Voucher_ID,Voucher_Type,Voucher_Type_ID,Voucher_No,Date,Branch,Ledger,Narration,Credit_Amount,Debit_Amount,
(Select ld.[Name] From TBL_Ledger ld where ld.id  = Ledger) as Ledger_Name,
(Select ld.[Name] From TBL_Ledger ld where ld.id = vc.Branch) as Branch_Name From TBL_VC vc where vc.Tra_ID = '{Tra_ID}' LIMIT 1", conn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            'My.Computer.Clipboard.SetText(cmd.CommandText)
            While r.Read
                'Voucher_No Details.////////////////////////////////////
                Head_ID = r("ID")
                Voucher_ID = r("Voucher_ID")
                Voucher_Type = r("Voucher_Type")
                VC_Formate_ID = r("Voucher_Type_ID")
                VC_ID_ = r("Voucher_No")
                Date_TXT.Text = r("Date")

                If VC_Type_ <> "Duplicate" Then
                    Voucher_No_TXT.Text = r("Voucher_No").ToString
                End If

                Branch_ID = r("Branch").ToString

                Account_TXT.Text = r("Ledger_Name").ToString
                Account_TXT.Data_Link_ = r("Ledger")
                To_ID = Account_TXT.Data_Link_
                Branch_TXT.Text = r("Branch_Name").ToString
                Narration_TXT.Text = r("Narration")


            End While
            r.Close()




            conn.Close()
            Voucher_Setup(VC_Formate_ID)


            If open_MSSQL_Cstm(Database_File.cre, conn) = True Then
                cmd = New SQLiteCommand($"Select *,
(Select ld.[Name] From TBL_Ledger ld where ld.id = vl.Ledger) as Ledger_Name,
(Select ifnull((Select ifnull(SUM(vc.Cr),0)-ifnull(SUM(vc.Dr),0) From TBL_VC_Ledger vc Where vc.Ledger = vl.Ledger and vc.[Date] <= '{CDate(Date_TXT.Text).AddDays(1).ToString(Lite_date_Format)}' and vc.Tra_ID <> '{Tra_ID}'),0)+ifnull((Select ifnull(sum(lob.OB_Cr),0)-ifnull(sum(lob.OB_Dr),0) From TBL_Ledger_Opning_Balance lob where lob.Ledger_ID = vl.Ledger and lob.Branch_ID = '{Branch_ID}'),0)) as Bal_
From TBL_VC_Ledger vl
where Tra_ID = '{Tra_ID}' and Type = 'Under'", conn)


                r = cmd.ExecuteReader
                While r.Read
                    Dim Va As Decimal
                    Va = nUmBeR_FORMATE(Val(r("Cr")) + Val(r("Dr")))
                    If Voucher_Type_LB.Text = "Payment" Or Voucher_Type_LB.Text = "Receipt" Or Voucher_Type_LB.Text = "Contra" Then
                        Cprj_controls1.Add_New()
                        Dim obj_int As Integer = Cprj_controls1.bg_panel.Controls.Count

                        Cprj_controls1.Find_Particuls_TXT(obj_int).Text = r("Ledger_Name").ToString
                        Cprj_controls1.Find_Particuls_TXT(obj_int).Data_Link_ = r("Ledger").ToString
                        Cprj_controls1.Find_Amount_TXT(obj_int).Text = Va
                        If VC_YN_Narration_Cell = "Yes" Then
                            Cprj_controls1.Find_Narration_TXT(obj_int).Text = r("Narration").ToString
                        End If

                        Cprj_controls1.Find_Balance_Lab_TXT(obj_int).Tag = Val(r("Bal_").ToString)
                        Cprj_controls1.fill_balance(Cprj_controls1.Find_Particuls_TXT(obj_int))
                    ElseIf Voucher_Type_LB.Text = "Journal" Then
                        Journal_controls1.Add_New()
                        Journal_controls1.Find_Particuls_TXT(Journal_controls1.bg_panel.Controls.Count).Data_Link_ = r("Ledger").ToString
                        Journal_controls1.Find_Particuls_TXT(Journal_controls1.bg_panel.Controls.Count).Text = r("Ledger_Name").ToString

                        If Val(r("Dr")) <> 0 Then
                            Journal_controls1.Find_crdr_TXT(Journal_controls1.bg_panel.Controls.Count).Text = "Dr"
                            Journal_controls1.Find_dr_TXT(Journal_controls1.bg_panel.Controls.Count).Text = nUmBeR_FORMATE(r("Dr").ToString)
                        Else
                            Journal_controls1.Find_crdr_TXT(Journal_controls1.bg_panel.Controls.Count).Text = "Cr"
                            Journal_controls1.Find_cr_TXT(Journal_controls1.bg_panel.Controls.Count).Text = nUmBeR_FORMATE(r("Cr").ToString)
                        End If

                        Dim obj_int As Integer = Journal_controls1.bg_panel.Controls.Count
                        Journal_controls1.Find_Balance_Lab_TXT(obj_int).Tag = Val(r("Bal_").ToString)
                        Journal_controls1.fill_balance(Journal_controls1.Find_Particuls_TXT(obj_int))
                    End If
                End While
            End If


            'Account_TXT.Text = Acc
            'Branch_TXT.Text = Branch

        End If

        If Voucher_Type_LB.Text = "Payment" Or Voucher_Type_LB.Text = "Receipt" Or Voucher_Type_LB.Text = "Contra" Then
            'Shado_Color_
            Cprj_controls1.Shado_Color_(Cprj_controls1.Find_Particuls_TXT(Cprj_controls1.bg_panel.Controls.Count))
        End If


        Fill_Attage()

        '
        Cfg_Link()


        If VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close" Then
            Acc_Balance = Val(Val((Ledger_Balance(Account_TXT.Data_Link_, CDate(Date_TXT.Text).AddDays(1), Tra_ID, 0))))
            Branch_Balance_val = Val(Val((Branch_Balance(Branch_ID, CDate(Date_TXT.Text).AddDays(1), Tra_ID))))
        Else
            Acc_Balance = Val(Val((Ledger_Balance(Account_TXT.Data_Link_, CDate(Date_TXT.Text).AddDays(1), "0", 0))))
            Branch_Balance_val = Val(Val((Branch_Balance(Branch_ID, CDate(Date_TXT.Text).AddDays(1), 0))))
        End If

        Acc_Credit = Val(Find_DT_Value(Database_File.cre, "TBL_Ledger", "Cradit", "ID = '" & Account_TXT.Data_Link_ & "' and " & Company_Visible_Filter()))

        Closing_Balance_Set()
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
        End If
        Label17.Text = DataGridView1.Rows.Count & " Files"
    End Function
    Dim Credit_Warning As Boolean = False
    Private Sub Button2_Click(sender As Object, e As EventArgs)
        EwayBill_frm.Show()
    End Sub

    Dim Credit_Pop As Boolean = True
    Private Sub Label28_TextChanged(sender As Object, e As EventArgs) Handles Label28.TextChanged
        If Ledger_Credit_Expire_Action <> "Not Applicable" Then
            If Val(Label28.Text) < 0 Then
            Else
                NOT_Clear()
            End If
        End If
    End Sub
    Private Sub Branch_TXT_LostFocus(sender As Object, e As EventArgs) Handles Branch_TXT.LostFocus
        Fill_Source()
    End Sub
    Private Sub Account_TXT_TextChanged(sender As Object, e As EventArgs) Handles Account_TXT.TextChanged

    End Sub

    Private Sub Txt3_TextChanged(sender As Object, e As EventArgs) Handles Txt3.TextChanged

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

    Private Sub Branch_TXT_TextChanged(sender As Object, e As EventArgs) Handles Branch_TXT.TextChanged
        'Dft_Branch = Branch_TXT.Text
    End Sub

    Private Sub Account_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles Account_TXT.KeyDown
        If e.KeyCode = Keys.Enter Then
            If acc_list.List_Grid.CurrentRow.Cells(1).Value = "Create" Then
                Create_Cash_Ledger(sender, "")
                Exit Sub
            End If
            Account_TXT.Data_Link_ = acc_list.List_Grid.CurrentRow.Cells(2).Value
        End If



        If e.KeyCode = Keys.C AndAlso e.Modifiers = Keys.Alt Then
            Create_Cash_Ledger(sender, "")
        ElseIf e.KeyCode = Keys.Enter AndAlso e.Modifiers = Keys.Control Then
            Cell("Account Ledger", "", "Alter_Close", Account_TXT.Data_Link_)
            Ledger_frm.close_focus_obj = sender
        ElseIf e.KeyCode = Keys.Enter Then
            If Find_DT_Value(Database_File.cre, "TBL_Ledger", "CHEQUE_Print", $"ID = '{Account_TXT.Data_Link_}'") = "Yes" And Voucher_Type_LB.Text = "Payment" Then
                cheque_panel.Visible = True
            Else
                cheque_panel.Visible = False
            End If
            If VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close" Then
                Acc_Balance = nUmBeR_FORMATE(acc_list.List_Grid.CurrentRow.Cells(7).Value)
            Else
                Acc_Balance = nUmBeR_FORMATE(acc_list.List_Grid.CurrentRow.Cells(7).Value)
            End If


            Acc_Credit = Val(Find_DT_Value(Database_File.cre, "TBL_Ledger", "Cradit", "ID = '" & Account_TXT.Data_Link_ & "' and " & Company_Visible_Filter()))

            Closing_Balance_Set()
        End If
    End Sub
    Private Function Create_Cash_Ledger(sender As TXT, under As String)
        Cell("Account Ledger", "", "Create_Close", "")
        Ledger_frm.Name_TXT.Text = sender.Text
        Ledger_frm.Group_TXT.Text = under
        Ledger_frm.close_focus_obj = sender
    End Function
    Private Sub Panel8_Paint(sender As Object, e As PaintEventArgs)
        obj_top(sender)
    End Sub

    Private Sub Voucher_type_Grid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub Txt1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Journal_controls1_Load(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label17_Click(sender As Object, e As EventArgs) Handles Label17.Click, Label16.Click, PictureBox1.Click
        With attage_display
            .Grid_ = Me.DataGridView1
            .ShowDialog()
            Label17.Text = DataGridView1.Rows.Count
        End With
    End Sub

    Private Sub Voucher_Name_LB_Click(sender As Object, e As EventArgs) Handles Voucher_Name_LB.Click

    End Sub

    Private Sub Save_background_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles Save_background.DoWork
        Save_Data()
    End Sub

    Private Sub Branch_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles Branch_TXT.KeyDown
        If e.KeyCode = Keys.Enter Then
            If branch_list.List_Grid.CurrentRow.Cells(1).Value = "Create" Then
                Create_Cash_Ledger(sender, "Branch / Divisions")
                Exit Sub
            End If
            Branch_ID = Val(branch_list.List_Grid.CurrentRow.Cells(5).Value.ToString)
        End If


        If e.KeyCode = Keys.C AndAlso e.Modifiers = Keys.Alt Then
            Create_Cash_Ledger(sender, "Branch / Divisions")
        ElseIf e.KeyCode = Keys.Enter AndAlso e.Modifiers = Keys.Control Then
            Cell("Account Ledger", "", "Alter_Close", Branch_ID)
            Ledger_frm.close_focus_obj = sender
        ElseIf e.KeyCode = Keys.Enter Then
            If VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close" Then
                Branch_Balance_val = Val(branch_list.List_Grid.CurrentRow.Cells(3).Value)
            Else
                Branch_Balance_val = Val(branch_list.List_Grid.CurrentRow.Cells(3).Value)
            End If

            Closing_Balance_Set()
        End If

    End Sub

    Private Sub Yn3_TextChanged(sender As Object, e As EventArgs) Handles Yn3.TextChanged

    End Sub

    Private Sub Accounting_Voucher_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Active_ctrl = Me.ActiveControl
    End Sub

    Private Sub Panel30_Paint(sender As Object, e As PaintEventArgs) Handles Panel30.Paint

    End Sub

    Private Sub Yn3_KeyDown(sender As Object, e As KeyEventArgs) Handles Yn3.KeyDown
        If e.KeyCode = Keys.Enter Then
            If sender.Text = "Yes" Then
                vc_CHEQUE_Print_frm.Date_ = CDate(Date_TXT.Text)
                vc_CHEQUE_Print_frm.Ledger_ID = Account_TXT.Data_Link_
                vc_CHEQUE_Print_frm.Amount = nUmBeR_FORMATE(Cprj_controls1.Total_lab.Text).ToString.Replace(".00", "")
                For Each bg_p As Panel In Cprj_controls1.bg_panel.Controls.OfType(Of Panel)()
                    vc_CHEQUE_Print_frm.Ledger_Name = Cprj_controls1.Find_Particuls_TXT(Cprj_controls1.Find_Idx(bg_p)).Text
                Next
                vc_CHEQUE_Print_frm.focus_Object = Yn3
                Cell("Cheque Print")
            End If
        End If
    End Sub

    Private Sub Accounting_Voucher_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID

        Try
            Active_ctrl.Focus()
        Catch ex As Exception
            Date_TXT.Focus()
        End Try
    End Sub

    Private Sub Accounting_Voucher_frm_LostFocus(sender As Object, e As EventArgs) Handles Me.LostFocus

    End Sub

    Private Sub Accounting_Voucher_frm_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        Active_ctrl = Me.ActiveControl
    End Sub
End Class