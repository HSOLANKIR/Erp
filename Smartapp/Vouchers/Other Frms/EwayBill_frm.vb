Imports System.ComponentModel
Imports System.Data.SQLite
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Public Class EwayBill_frm
    Dim From_ID As String
    Dim Path_End As String
    Private Sub EwayBill_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        obj_top(Panel2)

        Path_End = BG_frm.BG_Path_TXT.Text

        BG_frm.HADE_TXT.Text = "E-Way Bill"
        BG_frm.TYP_TXT.Text = ""

        Sub_Type_TXT.Text = "Supply"
        Moad_TXT.Text = "Road"
        doc_type_TXT.Text = "Tax Invoice"
        Vehical_Type_TXT.Text = "Regular"

        Button_Manage()
        NOT_Clear()
        Add_Hander_Remove_Handel(True)

        Load_data()
        List_set()

        If Inventory_Vouchers_frm.eb_Consignee_T = Nothing Then
            Txt1.Text = "Auto Fill from Voucher"
        Else
            Txt1.Text = "Custom Data"
        End If
        Load_()
    End Sub
    Private Function Button_Manage()
        BG_frm.B_1.Text = "&E : Exit"
        BG_frm.B_2.Text = "&S : Save"
        BG_frm.R_3.Text = "&J : Json Export"
    End Function
    Private Function Add_Hander_Remove_Handel(Ans As Boolean)
        If Ans = True Then
            AddHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            AddHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
            AddHandler BG_frm.R_3.Click, AddressOf Me.R_3_Click
        Else
            RemoveHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            RemoveHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
            RemoveHandler BG_frm.R_3.Click, AddressOf Me.R_3_Click
        End If
    End Function
    Private Sub B_1_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Me.Dispose()
        End If
    End Sub
    Private Sub B_2_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Save_()
            Me.Dispose()
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub R_3_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Save_()
            If Company_GST_str.Trim = "" Then
                Msg(NOT_Type.Erro, "Company GST No.", "Your company's gst number is not entered, please enter your company's gst number and then try")
                Exit Sub
            End If
            If Company_Address_str.Trim = "" Then
                Msg(NOT_Type.Erro, "Company Address", "Your company's address is not entered, please enter your company's address and then try")
                Exit Sub
            End If
            If Company_City_str.Trim = "" Then
                Msg(NOT_Type.Erro, "Company City(Please)", "Your company's City(Please) is not entered, please enter your company's City(Please) and then try")
                Exit Sub
            End If
            If Company_Pincode_str.Trim = "" Then
                Msg(NOT_Type.Erro, "Company Pincode", "Your company's Pincode is not entered, please enter your company's Pincode and then try")
                Exit Sub
            End If
            If Company_State_str.Trim = "" Then
                Msg(NOT_Type.Erro, "Company State", "Your company's State is not entered, please enter your company's State and then try")
                Exit Sub
            End If
            If Consignee_to_TXT.Text.Trim = "" Then
                Msg(NOT_Type.Erro, "Consignee Name", "Please enter Consignee Name and try again")
                Consignee_to_TXT.Focus()
                Exit Sub
            End If
            If GST_To_TXT.Text.Trim = "" Then
                Msg(NOT_Type.Erro, "Consignee GST No.", "Pleaese enter Consignee GST No. and try again")
                GST_To_TXT.Focus()
                Exit Sub
            End If
            If Add1_to_TXT.Text.Trim = "" Then
                Msg(NOT_Type.Erro, "Consignee Address", "Pleaese enter Consignee Address and try again")
                Add1_to_TXT.Focus()
                Exit Sub
            End If
            If Plase_To_TXT.Text.Trim = "" Then
                Msg(NOT_Type.Erro, "Consignee Please", "Pleaese enter Consignee Please and try again")
                Plase_To_TXT.Focus()
                Exit Sub
            End If
            If Pincode_To_TXT.Text.Trim = "" Then
                Msg(NOT_Type.Erro, "Consignee Pincode", "Pleaese enter Consignee Pincode and try again")
                Pincode_To_TXT.Focus()
                Exit Sub
            End If
            If Distance_TXT.Text.Trim = "" Then
                Msg(NOT_Type.Erro, "Transport Distance", "Pleaese enter Transport Distance and try again")
                Distance_TXT.Focus()
                Exit Sub
            End If
            Json()
            no_TXT.Focus()
        End If
    End Sub
    Private Sub EwayBill_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub
    Dim Type_list As List_frm
    Dim sub_type_list As List_frm
    Dim doc_type_list As List_frm
    Dim moad_list As List_frm
    Dim state_list As List_frm
    Dim state_list_dispathe_ As List_frm
    Dim state_list_to_shit As List_frm
    Dim Vehical_Type_list As List_frm
    Private Function List_set()
        state_list = New List_frm
        List_Setup("List of States", Select_List.Right_Dock, Select_List_Format.Singel, State_To_TXT, state_list, State_Source, 300)

        state_list_dispathe_ = New List_frm
        List_Setup("List of States", Select_List.Right_Dock, Select_List_Format.Singel, State_dispatch_Frm_TXT, state_list_dispathe_, State_Source, 300)

        state_list_to_shit = New List_frm
        List_Setup("List of States", Select_List.Right_Dock, Select_List_Format.Singel, State_ship_To_TXT, state_list_to_shit, State_Source, 300)

        Type_list = New List_frm
        List_Setup("Data Fill Type", Select_List.Botom, Select_List_Format.Singel, Txt1, Type_list, Fill_Type_Source, Txt1.Width)

        sub_type_list = New List_frm
        List_Setup("Sub Type", Select_List.Right, Select_List_Format.Singel, Sub_Type_TXT, sub_type_list, Sub_Type_Source, 170)

        doc_type_list = New List_frm
        List_Setup("Document Type", Select_List.Right, Select_List_Format.Singel, doc_type_TXT, doc_type_list, doc_type_Source, 170)

        moad_list = New List_frm
        List_Setup("Mode", Select_List.Right, Select_List_Format.Singel, Moad_TXT, moad_list, Mode_Source, 100)

        Vehical_Type_list = New List_frm
        List_Setup("Vehicle Type", Select_List.Right, Select_List_Format.Singel, Vehical_Type_TXT, Vehical_Type_list, Vehical_Type_Source, 200)

    End Function
    Private Function Load_data()
        Dim dt As DataTable
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cfgs, cn) = True Then
            dt = New DataTable
            dt.Columns.Add("Name")

            cmd = New SQLiteCommand("Select * From TBL_State", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                dt.Rows.Add(r("Name"))
            End While
            State_Source.DataSource = dt
        End If

        dt = New DataTable
        dt.Columns.Add("Name")
        dt.Rows.Add("Not Applicable")
        dt.Rows.Add("Exhibition or Fairs")
        dt.Rows.Add("Export")
        dt.Rows.Add("For Own Use")
        dt.Rows.Add("Job Work")
        dt.Rows.Add("Lines Sales")
        dt.Rows.Add("Others")
        dt.Rows.Add("Recipient Not Known")
        dt.Rows.Add("SKD/CKD/Lots")
        dt.Rows.Add("Supply")
        Sub_Type_Source.DataSource = dt


        dt = New DataTable
        dt.Columns.Add("Name")
        dt.Rows.Add("Not Applicable")
        dt.Rows.Add("Bill of Entry")
        dt.Rows.Add("Bill of Supply")
        dt.Rows.Add("Delivery Challan")
        dt.Rows.Add("Others")
        dt.Rows.Add("Tax Invoice")
        doc_type_Source.DataSource = dt


        dt = New DataTable
        dt.Columns.Add("Name")
        dt.Rows.Add("Air")
        dt.Rows.Add("Rail")
        dt.Rows.Add("Road")
        dt.Rows.Add("Ship")
        Mode_Source.DataSource = dt

        dt = New DataTable
        dt.Columns.Add("Name")
        dt.Rows.Add("Auto Fill from Voucher")
        dt.Rows.Add("Custom Data")
        Fill_Type_Source.DataSource = dt

        dt = New DataTable
        dt.Columns.Add("Name")
        dt.Rows.Add("Over Dimensional Cargo")
        dt.Rows.Add("Regular")
        Vehical_Type_Source.DataSource = dt


    End Function
    Private Function Load_()
        With Inventory_Vouchers_frm
            State_To_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Ledger", "State", "ID = '" & .To_ID & "'")
            If State_To_TXT.Text = "" Then
                State_To_TXT.Text = Company_State_str
            End If

            no_TXT.Text = .eb_ewaybill_no
            Date_TXT.Text = .eb_date
            Sub_Type_TXT.Text = .eb_Sub_Type
            doc_type_TXT.Text = .eb_Document_Type
            Consignee_frm_TXT.Text = .eb_Consignee_F
            Add1_Frm_TXT.Text = .eb_Address1_F
            Add2_Frm_TXT.Text = .eb_Address2_F
            Plase_Frm_TXT.Text = .eb_Please_F
            Pincode_Frm_TXT.Text = .eb_Pincode_F
            GST_Frm_TXT.Text = .eb_GSTIN_F
            State_Frm_TXT.Text = .eb_State_F
            Consignee_to_TXT.Text = .eb_Consignee_T
            Add1_to_TXT.Text = .eb_Address1_T
            Add2_To_TXT.Text = .eb_Address2_T
            State_dispatch_Frm_TXT.Text = .eb_State_dispath_T
            State_ship_To_TXT.Text = .eb_State_ship_T
            Plase_To_TXT.Text = .eb_Please_T
            Pincode_To_TXT.Text = .eb_Pincode_T
            GST_To_TXT.Text = .eb_GSTIN_T
            State_To_TXT.Text = .eb_State_T
            Moad_TXT.Text = .eb_Mode
            Distance_TXT.Text = .eb_Distance
            Transport_TXT.Text = .eb_Transport_Name
            Transport_ID_TXT.Text = .eb_Transport_ID
            Vehical_TXT.Text = .eb_Vehicle_No
            Vehical_Type_TXT.Text = .eb_Vehicle_Type
            LR_No_TXT.Text = .eb_LR_No
        End With

    End Function
    Private Function Save_()
        With Inventory_Vouchers_frm
            .eb_ewaybill_no = no_TXT.Text
            .eb_date = Date_TXT.Text
            .eb_Sub_Type = Sub_Type_TXT.Text
            .eb_Document_Type = doc_type_TXT.Text
            .eb_Consignee_F = Consignee_frm_TXT.Text
            .eb_Address1_F = Add1_Frm_TXT.Text
            .eb_Address2_F = Add2_Frm_TXT.Text
            .eb_Please_F = Plase_Frm_TXT.Text
            .eb_Pincode_F = Pincode_Frm_TXT.Text
            .eb_GSTIN_F = GST_Frm_TXT.Text
            .eb_State_F = State_Frm_TXT.Text
            .eb_Consignee_T = Consignee_to_TXT.Text
            .eb_Address1_T = Add1_to_TXT.Text
            .eb_Address2_T = Add2_To_TXT.Text
            .eb_State_dispath_T = State_dispatch_Frm_TXT.Text
            .eb_State_ship_T = State_ship_To_TXT.Text
            .eb_Please_T = Plase_To_TXT.Text
            .eb_Pincode_T = Pincode_To_TXT.Text
            .eb_GSTIN_T = GST_To_TXT.Text
            .eb_State_T = State_To_TXT.Text
            .eb_Mode = Moad_TXT.Text
            .eb_Distance = Distance_TXT.Text
            .eb_Transport_Name = Transport_TXT.Text
            .eb_Transport_ID = Transport_ID_TXT.Text
            .eb_Vehicle_No = Vehical_TXT.Text
            .eb_Vehicle_Type = Vehical_Type_TXT.Text
            .eb_LR_No = LR_No_TXT.Text
        End With

    End Function
    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub
    Private Function Json()
        Dim I_W As String = ""
        Select Case Inventory_Vouchers_frm.Voucher_Type_LB.Text
            Case "Sales"
                I_W = "O"
            Case "Purchase"
                I_W = "I"
        End Select
        Dim subSupplyType As String
        Select Case Sub_Type_TXT.Text
            Case "Supply"
                subSupplyType = "1"
            Case "Export"
                subSupplyType = "2"
            Case "Job Work"
                subSupplyType = "3"
            Case "SKD/CKD/Lots"
                subSupplyType = "4"
            Case "Recipient Not Known"
                subSupplyType = "5"
            Case "For Own Use"
                subSupplyType = "6"
            Case "Exhibition or Fairs"
                subSupplyType = "7"
            Case "Line Sales"
                subSupplyType = "8"
            Case Else
                subSupplyType = "9"
        End Select
        Dim docType As String
        Select Case doc_type_TXT.Text
            Case "Delivery Challan"
                docType = "CHL"
            Case "Bill of Entry"
                docType = "BOE"
            Case "Bill of Supply"
                docType = "BIL"
            Case "Others"
                docType = "OTH"
            Case "Tax Invoice"
                docType = "INV"
        End Select

        Dim transMode As String
        Select Case Moad_TXT.Text
            Case "Air"
                transMode = "3"
            Case "Rail"
                transMode = "2"
            Case "Road"
                transMode = "1"
            Case "Ship"
                transMode = "4"
        End Select

        Dim Vehical_Type As String
        Select Case Vehical_Type_TXT.Text
            Case "Regular"
                Vehical_Type = "R"
            Case "Over Dimensional Cargo"
                Vehical_Type = "O"
        End Select

        Dim DT1 As Date = CDate(Inventory_Vouchers_frm.Date_TXT.Text)

        Dim DT As String = DT1.ToString("dd") & "/" & DT1.ToString("MM") & "/" & DT1.ToString("yyyy")

        Dim item_ans = Item_()

        Try
            If item_ans = False Then
                Exit Function
            End If
        Catch ex As Exception

        End Try
        Dim json_String As String = $"<
    'version': '1.0.0219', 
    'billLists': [
      <
        'userGstin': '{GST_Frm_TXT.Text}',
        'supplyType': '{I_W}',
        'subSupplyType': {subSupplyType},
        'docType': '{docType }',
        'docNo': '{Json_I_O_Data("invoice_no")}',
        'docDate': '{DT }',
        'transType': 1,
        'fromGstin': '{Json_I_O_Data("f_gst")}',
        'fromTrdName': '{Json_I_O_Data("f_name")}',
        'fromAddr1': '{Json_I_O_Data("f_add1")}',
        'fromAddr2': '{Json_I_O_Data("f_add2")}',
        'fromPlace': '{Json_I_O_Data("f_place")}',
        'fromPincode': {Json_I_O_Data("f_pincode")},
        'fromStateCode': {Json_I_O_Data("f_state_code")},
        'actualFromStateCode': {Json_I_O_Data("f_state_dispath_code")},
        'toGstin': '{Json_I_O_Data("t_gst")}',
        'toTrdName': '{Json_I_O_Data("t_name")}',
        'toAddr1': '{Json_I_O_Data("t_add1")}',
        'toAddr2': '{Json_I_O_Data("t_add2")}',
        'toPlace': '{Json_I_O_Data("t_place")}',
        'toPincode': {Json_I_O_Data("t_pincode")},
        'toStateCode': {Json_I_O_Data("t_state_code")},
        'actualToStateCode': {Json_I_O_Data("t_state_ship_code")},
        'totalValue': {Json_I_O_Data("totalValue")},
        'cgstValue': {Json_I_O_Data("cs_gstvalue")},
        'sgstValue': {Json_I_O_Data("cs_gstvalue")},
        'igstValue': {Json_I_O_Data("i_gstvalue")},
        'cessValue': 0.00,
        'TotNonAdvolVal': 0.00,
        'OthValue': 0.00,
        'totInvValue': {Json_I_O_Data("totInvValue")},
        'transMode': {transMode},
        'transDistance': {Val(Distance_TXT.Text)},
        'transporterName': '{Transport_TXT.Text }',
        'transporterId': '{Transport_ID_TXT.Text }',
        'transDocNo': '{LR_No_TXT.Text }',
        'transDocDate': '{DT }',
        'vehicleNo': '{Vehical_TXT.Text }',
        'vehicleType': '{Vehical_Type}',
        'mainHsnCode': {Find_Main_HSN_Code()},
        'itemList': [
          {item_ans}
        ]
      >
    ]
>"

        json_String = json_String.Replace("<", "{")
        json_String = json_String.Replace(">", "}")
        json_String = json_String.Replace("'", """")
        SaveFileDialog1.Filter = "Json Files (*.json*)|*.json"
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, json_String, True)
        End If

    End Function
    Private Function Find_Main_HSN_Code() As String
        Dim P_ As New Queue(Of sp_control_under)()
        For Each bg_p As sp_control_under In Inventory_Vouchers_frm.Sp_controls1.stock_panel.Controls.OfType(Of sp_control_under)()
            P_.Enqueue(bg_p)
        Next

        For Each c As sp_control_under In P_.Reverse
            Dim particuls_id As String = c.Item_TXT.Data_Link_
            If particuls_id <> Nothing Then
                Return Find_DT_Value(Database_File.cre, "TBL_Stock_Item", "HSN_Code", "ID = '" & particuls_id & "'")
            End If
        Next
    End Function
    Private Function Json_I_O_Data(str As String)
        str = str.ToLower

        Select Case str
            Case "totalValue"
                str = Format(Val(Val(Inventory_Vouchers_frm.Sp_controls1.sub_total_label.Text)), "0.00")
            Case "totInvValue"
                str = Format(Val(Val(Inventory_Vouchers_frm.Sp_controls1.amt_total_label.Text)), "0.00")
            Case "cs_gstvalue"
                If State_Frm_TXT.Text = State_To_TXT.Text Then
                    str = nUmBeR_FORMATE(Val(Inventory_Vouchers_frm.Sp_controls1.Label7.Text) / 2)
                Else
                    str = 0
                End If
            Case "i_gstvalue"
                If State_Frm_TXT.Text <> State_To_TXT.Text Then
                    str = nUmBeR_FORMATE(Val(Inventory_Vouchers_frm.Sp_controls1.Label7.Text) / 2)
                Else
                    str = 0
                End If


        End Select

        If Inventory_Vouchers_frm.Voucher_Type_LB.Text = "Sales" Then
            Select Case str
                Case "f_gst"
                    str = GST_Frm_TXT.Text
                Case "invoice_no"
                    str = Inventory_Vouchers_frm.Voucher_No_TXT.Text


                Case "f_name"
                    str = Consignee_frm_TXT.Text
                Case "f_add1"
                    str = Add1_Frm_TXT.Text
                Case "f_add2"
                    str = Add2_Frm_TXT.Text
                Case "f_place"
                    str = Plase_Frm_TXT.Text
                Case "f_pincode"
                    str = Pincode_Frm_TXT.Text
                Case "f_state_code"
                    str = Find_DT_Value(Database_File.cfgs, "TBL_State_GSTCode", "StateCode", "StateName = '" & State_Frm_TXT.Text & "' COLLATE NOCASE")
                Case "f_state_dispath_code"
                    str = Find_DT_Value(Database_File.cfgs, "TBL_State_GSTCode", "StateCode", "StateName = '" & State_dispatch_Frm_TXT.Text & "' COLLATE NOCASE")

                Case "t_gst"
                    str = GST_To_TXT.Text
                Case "t_name"
                    str = Consignee_to_TXT.Text
                Case "t_add1"
                    str = Add1_to_TXT.Text
                Case "t_add2"
                    str = Add2_To_TXT.Text
                Case "t_place"
                    str = Plase_To_TXT.Text
                Case "t_pincode"
                    str = Pincode_To_TXT.Text
                Case "t_state_code"
                    str = Find_DT_Value(Database_File.cfgs, "TBL_State_GSTCode", "StateCode", "StateName = '" & State_To_TXT.Text & "' COLLATE NOCASE")
                Case "t_state_ship_code"
                    str = Find_DT_Value(Database_File.cfgs, "TBL_State_GSTCode", "StateCode", "StateName = '" & State_ship_To_TXT.Text & "' COLLATE NOCASE")

            End Select
        ElseIf Inventory_Vouchers_frm.Voucher_Type_LB.Text = "Purchase" Then
            Select Case str
                Case "invoice_no"
                    str = Inventory_Vouchers_frm.supplier_vc_no
                Case "t_gst"
                    str = GST_Frm_TXT.Text
                Case "t_name"
                    str = Consignee_frm_TXT.Text
                Case "t_add1"
                    str = Add1_Frm_TXT.Text
                Case "t_add2"
                    str = Add2_Frm_TXT.Text
                Case "t_place"
                    str = Plase_Frm_TXT.Text
                Case "t_pincode"
                    str = Pincode_Frm_TXT.Text
                Case "t_state_code"
                    str = Find_DT_Value(Database_File.cfgs, "TBL_State_GSTCode", "StateCode", "StateName = '" & State_Frm_TXT.Text & "' COLLATE NOCASE")

                Case "f_gst"
                    str = GST_To_TXT.Text
                Case "f_name"
                    str = Consignee_to_TXT.Text
                Case "f_add1"
                    str = Add1_to_TXT.Text
                Case "f_add2"
                    str = Add2_To_TXT.Text
                Case "f_place"
                    str = Plase_To_TXT.Text
                Case "f_pincode"
                    str = Pincode_To_TXT.Text
                Case "f_state_code"
                    str = Find_DT_Value(Database_File.cfgs, "TBL_State_GSTCode", "StateCode", "StateName = '" & State_To_TXT.Text & "' COLLATE NOCASE")
                Case "f_state_dispath_code"
                    str = Find_DT_Value(Database_File.cfgs, "TBL_State_GSTCode", "StateCode", "StateName = '" & State_ship_To_TXT.Text & "' COLLATE NOCASE")
                Case "t_state_ship_code"
                    str = Find_DT_Value(Database_File.cfgs, "TBL_State_GSTCode", "StateCode", "StateName = '" & State_dispatch_Frm_TXT.Text & "' COLLATE NOCASE")
            End Select
        End If

        If str <> Nothing Then
            str = Replace(str, vbCrLf, vbNullString).ToString.Trim
        Else
            str = ""
        End If

        Return str
    End Function

    Private Function Item_()
        Dim it As String
        Dim P_ As New Queue(Of sp_control_under)()
        For Each bg_p As sp_control_under In Inventory_Vouchers_frm.Sp_controls1.stock_panel.Controls.OfType(Of sp_control_under)()
            P_.Enqueue(bg_p)
        Next

        For Each c As sp_control_under In P_.Reverse
            Dim particuls_id As String = c.Item_TXT.Data_Link_
            Dim particuls_ As String = c.Item_TXT.Text
            Dim GST_vlu As String = c.GST_Per
            Dim qty As String = c.Qty_TXT.Text
            Dim rate_ As String = c.Rate_TXT.Text
            Dim unit_ As String = c.Unit_Lst.Text
            Dim amt_ As String = c.Amount_TXT.Text

            Dim Last_ As String


            If particuls_id <> Nothing Then
                If Inventory_Vouchers_frm.Sp_controls1.stock_panel.Controls.Count = 1 Then
                    Last_ = ">"
                Else
                    Last_ = ">,"
                End If

                Dim hsn As String = Find_DT_Value(Database_File.cre, "TBL_Stock_Item", "HSN_Code", "ID = '" & particuls_id & "'")
                If hsn.Trim = "" Then
                    Msg(NOT_Type.Erro, "HSN Code", particuls_ & " Hsn Code is missing, Please " & particuls_ & " Enter Hsn Code and Try again")
                    Return False
                End If

                Dim CS_GST As Decimal = 0.00
                Dim I_GST As Decimal = 0.00

                If State_Frm_TXT.Text = State_To_TXT.Text Then
                    CS_GST = Format(Val(Val(GST_vlu) / 2), "0.00")
                Else
                    I_GST = Format(Val(Val(GST_vlu)), "0.00")
                End If

                it &= $"<
            'productName': '{particuls_}',
            'productDesc': '{particuls_}',
            'hsnCode': {hsn},
            'quantity': {qty},
            'qtyUnit': '{unit_}',
            'cgstRate': {CS_GST},
            'sgstRate': {CS_GST},
            'igstRate': {I_GST},
            'cessRate': 0.00,
            'cessNonadvol': 0,
            'taxableAmount': " & Val(amt_) & vbNewLine & Last_
            End If
        Next
        Return it
    End Function

    Private Sub EwayBill_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.HADE_TXT.Text = "E-Way Bill"
        BG_frm.TYP_TXT.Text = ""
        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text

        Button_Clear()
        Button_Manage()

    End Sub

    Private Sub EwayBill_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End
        Add_Hander_Remove_Handel(False)
        Inventory_Vouchers_frm.Yn1.Focus()
    End Sub

    Private Sub Txt2_TextChanged(sender As Object, e As EventArgs) Handles Date_TXT.TextChanged

    End Sub

    Private Sub Txt2_LostFocus(sender As Object, e As EventArgs) Handles Date_TXT.LostFocus
        Date_TXT.Text = Date_Formate(Date_TXT.Text)
    End Sub

    Private Sub Txt1_TextChanged(sender As Object, e As EventArgs) Handles Txt1.TextChanged

    End Sub

    Private Sub Txt1_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Type_list.List_Grid.CurrentRow.Cells(0).Value.ToString = "Auto Fill from Voucher" Then
                Fill_Auto()
            End If
        End If
    End Sub
    Private Function Fill_Auto()
        With Inventory_Vouchers_frm
            no_TXT.Text = .eb_ewaybill_no
            Date_TXT.Text = .Date_TXT.Text
            Sub_Type_TXT.Text = "Supply"
            doc_type_TXT.Text = "Tax Invoice"
            Consignee_frm_TXT.Text = Company_Name_str
            Add1_Frm_TXT.Text = Company_Address_str
            Add2_Frm_TXT.Text = ""
            Plase_Frm_TXT.Text = Company_Place_str
            Pincode_Frm_TXT.Text = Company_Pincode_str
            GST_Frm_TXT.Text = Company_GST_str
            State_Frm_TXT.Text = State_Frm_TXT.Text
            State_dispatch_Frm_TXT.Text = Company_State_str
            Consignee_to_TXT.Text = .To_Name
            Add1_to_TXT.Text = .To_Address1
            Add2_To_TXT.Text = ""
            Plase_To_TXT.Text = .To_Please
            Pincode_To_TXT.Text = .To_Pincode
            GST_To_TXT.Text = .To_GST
            State_To_TXT.Text = .To_State
            State_ship_To_TXT.Text = .To_State
            Moad_TXT.Text = "Road"
            Distance_TXT.Text = ""
            Transport_TXT.Text = .Transport_Name
            Transport_ID_TXT.Text = .Transport_ID
            Vehical_TXT.Text = .Vihicale_No
            Vehical_Type_TXT.Text = .Vihicale_Type
            LR_No_TXT.Text = .LR_No
        End With
    End Function

    Private Sub Save_TXT_TextChanged(sender As Object, e As EventArgs) Handles Save_TXT.TextChanged

    End Sub

    Private Sub Save_TXT_Enter(sender As Object, e As EventArgs) Handles Save_TXT.Enter
        BG_frm.B_2.PerformClick()
    End Sub

    Private Sub Pincode_Frm_TXT_TextChanged(sender As Object, e As EventArgs) Handles Pincode_Frm_TXT.TextChanged

    End Sub

    Private Sub Pincode_To_TXT_TextChanged(sender As Object, e As EventArgs) Handles Pincode_To_TXT.TextChanged

    End Sub

    Private Sub State_Frm_TXT_TextChanged(sender As Object, e As EventArgs) Handles State_Frm_TXT.TextChanged

    End Sub

    Private Sub State_To_TXT_TextChanged(sender As Object, e As EventArgs) Handles State_To_TXT.TextChanged

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint
        obj_top(Panel2)
    End Sub

    Private Sub EwayBill_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
    End Sub
End Class