Imports System.Data.SQLite
Imports System.IO
Imports Microsoft.Reporting.Map.WebForms.BingMaps
Imports Tools
Public Class sp_voucher_create_ctrl
    Public VC_Formate_ As String
    Public VC_ID_ As String
    Public VC_Type_ As String
    Private Sub sp_voucher_create_ctrl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'List_set()
        'Add_Class("")
    End Sub

    Private Sub UPI_QR_YN_TextChanged(sender As Object, e As EventArgs) Handles UPI_QR_YN.TextChanged
        If UPI_QR_YN.Text = "Yes" Then
            UPI_value_p.Visible = True
        Else
            UPI_value_p.Visible = False
        End If
    End Sub
    Public Function Fill_data()
        Fill_Source()
        List_set()

        Dim cn As New SQLiteConnection
        Dim r As SQLiteDataReader
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select * From TBL_Voucher_Create where id = '{VC_ID_}'", cn)
            r = cmd.ExecuteReader
            While r.Read
                VC_Formate_ = r("Under").ToString
                zero_YN.Text = r("Zerol_Value").ToString
                duplicate_YN.Text = r("Duplicate_No").ToString
                Communication_YN.Text = r("Communication_YN").ToString
                narration_YN.Text = r("YN_Narration").ToString
                direct_print_YN.Text = r("Print_after_seve").ToString
                print_head_txt.Text = r("Print_Head").ToString
                print_type_txt.Text = r("Print_Type").ToString
                print_narration_YN.Text = r("Print_Narration").ToString
                print_signature_YN.Text = r("Print_Signature").ToString
                print_stamp_YN.Text = r("Print_Stamp").ToString
                UPI_QR_YN.Text = r("Print_UPI_QR").ToString
                UPI_Value_TXT.Text = r("Print_UPI_QR_Value").ToString
                Provisnoal_TXT.Text = r("Print_Provisional").ToString
                print_path_txt.Text = r("Print_Path").ToString
                mrp_yn.Text = r("Print_Item_MRP").ToString
                Print_Terms_Conditions_txt.Text = r("Print_Terms_Conditions").ToString
                GST_YN.Text = r("YN_GST").ToString
                ewayill_YN.Text = r("YN_EwayBill").ToString
                transport_YN.Text = r("YN_Transport").ToString
                Order_YN.Text = r("Order_YN").ToString
                barcode_yn.Text = r("Barcode_YN").ToString
                payment_details_YN.Text = r("Payment_Details_YN").ToString
                Rate_Valuation_TXT.Text = r("Rate_Valuation").ToString
                Txt1.Text = r("Round_Vlu").ToString
                Alter_acc_details_YN.Text = r("YN_Account_Details_Alter").ToString
                Credit_Limit_Warning.Text = r("YN_Credit_Limit_Warning").ToString
                Stock_Limit_Warning.Text = r("YN_Stock_Warning").ToString
                item_discription.Text = r("YN_item_description").ToString
                Discount_YN.Text = r("YN_item_Discount").ToString


            End While
            r.Close()
        End If

        Filter_of_Type()


        cmd = New SQLiteCommand($"Select * From TBL_Vouchers_Class where VC_ID = '{VC_ID_}'", cn)
        r = cmd.ExecuteReader
        While r.Read
            Add_Class(r("Name").ToString, r("ID").ToString)
        End While
        r.Close()

        If Panel19.Controls.Count = 0 Then
            Add_Class("", "")
        End If

        Dim P_ As New Queue(Of voucher_class_list_ctrl)()
        For Each b As voucher_class_list_ctrl In Panel19.Controls.OfType(Of voucher_class_list_ctrl)()
            P_.Enqueue(b)
        Next
        For Each s As voucher_class_list_ctrl In P_.Reverse
            s.Ctrl.Panel8.Controls.Clear()
            s.Ctrl.Panel10.Controls.Clear()

            'MsgBox(s.Txt1.Data_Link_)

            cmd = New SQLiteCommand($"Select *,(Select g.Name From TBL_Acc_Group g where g.ID = vc.Group_ID) as G_Name From TBL_Vouchers_Class_Head_Filter vc where VC_ID = '{VC_ID_}' and Class_ID = '{s.Txt1.Data_Link_}'", cn)
            r = cmd.ExecuteReader
            While r.Read
                s.Ctrl.Add_Account_Group(r("G_Name").ToString, r("Status").ToString)
            End While
            r.Close()

            cmd = New SQLiteCommand($"Select *,(Select g.Name From TBL_Ledger g where g.ID = vc.Ledger_ID) as G_Name From TBL_Vouchers_Class_Additional_Entries vc where VC_ID = '{VC_ID_}' and Class_ID = '{s.Txt1.Data_Link_}'", cn)
            r = cmd.ExecuteReader
            While r.Read
                s.Ctrl.Add_Ledger(r("G_Name").ToString, r("Type_of_Calculation").ToString, nUmBeR_FORMATE(r("Default_Value").ToString), r("Rounding_Method").ToString, nUmBeR_FORMATE(r("Rounding_Limit").ToString))
            End While
            r.Close()

            If s.Ctrl.Panel8.Controls.Count = 0 Then
                s.Ctrl.Add_Account_Group("", "")
            End If
            If s.Ctrl.Panel10.Controls.Count = 0 Then
                s.Ctrl.Add_Ledger("", "", "", "", "")
            End If
        Next



        cn.Close()

        Communication_Panel.Visible = YN_Boolean(Features_mod.Communication_YN)

        For Each YN As YN In Me.Controls.OfType(Of YN)()
            If YN.Text <> "Yes" Then
                YN.Text = "No"
            End If
        Next
    End Function
    Private Function Voucher_type_() As String
        With VC_Formate_
            If .ToString = "Inward Register" Or .ToString = "Purchase Order" Or .ToString = "Purchase" Or .ToString = "Sales Return" Then
                Return "Inward"
            ElseIf .ToString = "Outward Register" Or .ToString = "Sales Order" Or .ToString = "Sales" Or .ToString = "Purchase Return" Then
                Return "Outward"
            End If
        End With
    End Function
    Public Function Filter_of_Type()
        If Voucher_Md_frm.Type_TXT.Text = "Inward Register" Or Voucher_Md_frm.Type_TXT.Text = "Outward Register" Then
            GST_P.Visible = False
            zero_P.Visible = False
            MRP_P.Visible = False
            UPI_QR_P.Visible = False
            Print_Provisnoal_P.Visible = False

            GST_YN.Text = "No"
            zero_YN.Text = "No"
            mrp_yn.Text = "No"
            UPI_QR_YN.Text = "No"
        Else
            GST_P.Visible = True
            zero_P.Visible = True
            MRP_P.Visible = True
            UPI_QR_P.Visible = True
            Print_Provisnoal_P.Visible = True
        End If
        If Voucher_Md_frm.Type_TXT.Text = "Sales Order" Or Voucher_Md_frm.Type_TXT.Text = "Purchase Order" Then
            Panel7.Visible = False
            Order_YN.Text = "No"
        Else
            Panel7.Visible = True
        End If

    End Function

    Public Function Save_data(nam As String) As Boolean
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            qury = $"UPDATE TBL_Voucher_Create SET Duplicate_No = @Duplicate_No,Communication_YN = @Communication_YN,YN_Narration_Cell = @YN_Narration_Cell,Zerol_Value = @Zerol_Value,YN_GST = @YN_GST,YN_EwayBill = @YN_EwayBill,YN_Transport = @YN_Transport,Order_YN = @Order_YN,Print_after_seve = @Print_after_seve,Print_Head = @Print_Head,Print_Type = @Print_Type,Print_Narration = @Print_Narration,Print_Signature = @Print_Signature,Print_Stamp = @Print_Stamp,Print_UPI_QR = @Print_UPI_QR,Print_UPI_QR_Value = @Print_UPI_QR_Value,Print_Provisional  = @Print_Provisional,YN_Narration = @YN_Narration,Print_Path = @Print_Path,Print_format = @Print_format,Print_Item_MRP = @Print_Item_MRP,Print_Terms_Conditions = @Print_Terms_Conditions,Barcode_YN = @Barcode_YN,Payment_Details_YN = @Payment_Details_YN,Rate_Valuation = @Rate_Valuation,Round_Vlu = @Round_Vlu,YN_Account_Details_Alter = @YN_Account_Details_Alter,YN_Credit_Limit_Warning = @YN_Credit_Limit_Warning,YN_Stock_Warning = @YN_Stock_Warning,YN_item_description = @YN_item_description,YN_item_Discount = @YN_item_Discount where name = '{nam}'"
        End If

        cmd = New SQLiteCommand(qury, cn)


        Try

            With cmd.Parameters
                '////
                .AddWithValue("@YN_Narration_Cell", "")

                .AddWithValue("@Zerol_Value", zero_YN.Text.Trim)
                .AddWithValue("@Duplicate_No", duplicate_YN.Text.Trim)
                .AddWithValue("@Communication_YN", Communication_YN.Text.Trim)
                .AddWithValue("@YN_GST", GST_YN.Text.Trim)
                .AddWithValue("@YN_EwayBill", ewayill_YN.Text.Trim)
                .AddWithValue("@YN_Transport", transport_YN.Text.Trim)
                .AddWithValue("@Order_YN", Order_YN.Text.Trim)

                .AddWithValue("@Print_after_seve", direct_print_YN.Text.Trim)
                .AddWithValue("@Print_Head", print_head_txt.Text.Trim)
                .AddWithValue("@Print_Type", print_type_txt.Text.Trim)
                .AddWithValue("@Print_Narration", print_narration_YN.Text.Trim)
                .AddWithValue("@Print_Signature", print_signature_YN.Text.Trim)
                .AddWithValue("@Print_Stamp", print_stamp_YN.Text.Trim)
                .AddWithValue("@Print_UPI_QR", UPI_QR_YN.Text.Trim)
                .AddWithValue("@Print_UPI_QR_Value", UPI_Value_TXT.Text.Trim)
                .AddWithValue("@Print_Provisional", Provisnoal_TXT.Text.Trim)
                .AddWithValue("@YN_Narration", narration_YN.Text.Trim)
                .AddWithValue("@Print_Path", print_path_txt.Text.Trim)
                .AddWithValue("@Print_format", "")
                .AddWithValue("@Print_Item_MRP", mrp_yn.Text.Trim)
                .AddWithValue("@Barcode_YN", barcode_yn.Text.Trim)
                .AddWithValue("@Payment_Details_YN", payment_details_YN.Text.Trim)
                .AddWithValue("@Print_Terms_Conditions", Print_Terms_Conditions_txt.Text.Trim)
                .AddWithValue("@Rate_Valuation", Rate_Valuation_TXT.Text.Trim)
                .AddWithValue("@Round_Vlu", Txt1.Text.Trim)
                .AddWithValue("@YN_Account_Details_Alter", Alter_acc_details_YN.Text.Trim)
                .AddWithValue("@YN_Credit_Limit_Warning", Credit_Limit_Warning.Text.Trim)
                .AddWithValue("@YN_Stock_Warning", Stock_Limit_Warning.Text.Trim)
                .AddWithValue("@YN_item_description", item_discription.Text.Trim)
                .AddWithValue("@YN_item_Discount", Discount_YN.Text.Trim)

                cmd.ExecuteNonQuery()
            End With
            Save_Class(cn, Find_DT_Value(Database_File.cre, "TBL_Voucher_Create", "ID", $"Name = '{nam}'"))

            Return True
        Catch ex As Exception
            Msg(NOT_Type.Erro, "Data Save Error", ex.Message)
            Return False
        End Try
    End Function
    Private Function Save_Class(cn As SQLiteConnection, ID As Integer)
        cmd = New SQLiteCommand($"Delete From TBL_Vouchers_Class where VC_ID = '{ID}';
Delete From TBL_Vouchers_Class_Head_Filter where VC_ID = '{ID}';
Delete From TBL_Vouchers_Class_Additional_Entries where VC_ID = '{ID}'
", cn)
        cmd.ExecuteNonQuery()

        Dim P_ As New Queue(Of voucher_class_list_ctrl)()
        For Each b As voucher_class_list_ctrl In Panel19.Controls.OfType(Of voucher_class_list_ctrl)()
            P_.Enqueue(b)
        Next
        For Each s As voucher_class_list_ctrl In P_.Reverse
            If s.Txt1.Text <> Nothing Then
                cmd = New SQLiteCommand($"INSERT INTO TBL_Vouchers_Class (VC_ID,Name) VALUES ('{ID}','{s.Txt1.Text}')", cn)
                cmd.ExecuteNonQuery()

                Dim Class_ID As Integer = Find_DT_Value(Database_File.cre, "TBL_Vouchers_Class", "ID", $"Name = '{s.Txt1.Text}' and VC_ID = '{ID}'")

                Try
                    Dim U_ As New Queue(Of vouchers_type_class_group_list_ctrl)()
                    For Each b As vouchers_type_class_group_list_ctrl In s.Ctrl.Panel8.Controls.OfType(Of vouchers_type_class_group_list_ctrl)()
                        U_.Enqueue(b)
                    Next
                    For Each s1 As vouchers_type_class_group_list_ctrl In U_.Reverse
                        Dim Acc_ID As String = Find_DT_Value(Database_File.cre, "TBL_Acc_Group", "ID", $"Name = '{s1.Txt1.Text}'")
                        If Val(Acc_ID) <> 0 Then
                            cmd = New SQLiteCommand($"INSERT INTO TBL_Vouchers_Class_Head_Filter (VC_ID,Class_ID,Group_ID,Status) VALUES ('{ID}','{Class_ID}','{Acc_ID}','{s1.statsu_txt.Text}')", cn)
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                Catch ex As Exception

                End Try

                Try
                    Dim U_ As New Queue(Of vouchers_type_class_ledger_list_ctrl)()
                    For Each b As vouchers_type_class_ledger_list_ctrl In s.Ctrl.Panel10.Controls.OfType(Of vouchers_type_class_ledger_list_ctrl)()
                        U_.Enqueue(b)
                    Next
                    For Each s1 As vouchers_type_class_ledger_list_ctrl In U_.Reverse
                        Dim Acc_ID As String = Find_DT_Value(Database_File.cre, "TBL_Ledger", "ID", $"Name = '{s1.Ledger_TXT.Text}'")
                        If Val(Acc_ID) <> 0 Then
                            cmd = New SQLiteCommand($"INSERT INTO TBL_Vouchers_Class_Additional_Entries (VC_ID,Class_ID,Ledger_ID,Type_of_Calculation,Default_Value,Rounding_Method,Rounding_Limit) VALUES ('{ID}','{Class_ID}','{Acc_ID}','{s1.calulation_TXT.Text}','{Val(s1.Dft_TXT.Text)}','{s1.Rounding_TXT.Text}','{Val(s1.Rounding_Limit.Text)}')", cn)
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                Catch ex As Exception

                End Try




            End If
        Next


    End Function
    Dim qr_list As List_frm
    Dim rdlcFile_list As List_frm
    Dim Printype_list As List_frm
    Dim Valuati_List As List_frm
    Dim RoundUP_List As List_frm
    Dim Provinoal_List As List_frm
    Public Function List_set()
        qr_list = New List_frm
        List_Setup("UPI Qrcode Type", Select_List.Right, Select_List_Format.Singel, UPI_Value_TXT, qr_list, upi_qr_source, 150)

        Printype_list = New List_frm
        List_Setup("Print Type", Select_List.Right, Select_List_Format.Defolt, print_type_txt, Printype_list, Prnt_Type_source, 300)
        Printype_list.List_Grid.Columns(1).Width = 80

        Valuati_List = New List_frm
        List_Setup("Rate Valuation", Select_List.Right, Select_List_Format.Singel, Rate_Valuation_TXT, Valuati_List, Valuation_Source, 150)

        RoundUP_List = New List_frm
        List_Setup("Rate Valuation", Select_List.Right, Select_List_Format.Singel, Txt1, RoundUP_List, round_up_source, 150)

        Provinoal_List = New List_frm
        List_Setup("Type of Provisional Balance", Select_List.Right, Select_List_Format.Singel, Provisnoal_TXT, Provinoal_List, provinoal_source, 150)


    End Function
    Public Function Fill_Source()
        Dim dt As New DataTable
        dt.Columns.Add("Name")

        dt.Rows.Add("Manual Pay")
        dt.Rows.Add("Current Value")
        dt.Rows.Add("Provisional Value")
        upi_qr_source.DataSource = dt

        Dim dt_valuation As New DataTable
        dt_valuation.Columns.Add("Name")

        dt_valuation.Rows.Add("Default")
        dt_valuation.Rows.Add("At Zero")
        dt_valuation.Rows.Add("Avg. Inward")
        dt_valuation.Rows.Add("Avg. Outward")
        dt_valuation.Rows.Add("Last Purchase")
        dt_valuation.Rows.Add("Last Sales")
        dt_valuation.Rows.Add("Standard Purchase")
        dt_valuation.Rows.Add("Standard Sales")
        dt_valuation.Rows.Add("Basic Purchase Rate")
        dt_valuation.Rows.Add("Basic Sales Rate")

        Valuation_Source.DataSource = dt_valuation

        dt_print = New DataTable
        'dt_print.Rows.Clear()

        dt_print.Columns.Add("Name")
        dt_print.Columns.Add("Type")
        dt_print.Columns.Add("id")
        dt_print.Rows.Add("", "Custom")
        dt_print.Rows.Add("Original Receipt")
        dt_print.Rows.Add("Duplicate Receipt")
        dt_print.Rows.Add("Triplicate Receipt")

        Prnt_Type_source.DataSource = dt_print



        dt = New DataTable
        dt.Columns.Add("Name")
        dt.Rows.Add("Not Applicable")
        dt.Rows.Add("Manual")
        dt.Rows.Add("Minimum")
        dt.Rows.Add("Normal")
        dt.Rows.Add("Maximum")
        round_up_source.DataSource = dt


        dt = New DataTable
        dt.Columns.Add("Name")

        dt.Rows.Add("Amount")
        dt.Rows.Add("Not Applicable")
        dt.Rows.Add("Barcode")
        provinoal_source.DataSource = dt


    End Function
    Dim dt_print As DataTable
    Private Sub GST_YN_TextChanged(sender As Object, e As EventArgs) Handles GST_YN.TextChanged
        If sender.Text = "Yes" Then
            ewaybill_p.Visible = True
        Else
            ewaybill_p.Visible = False
        End If

    End Sub

    Private Sub print_type_txt_TextChanged(sender As Object, e As EventArgs) Handles print_type_txt.TextChanged
        If Printype_list.List_Grid.Rows.Count = 1 Then
            dt_print.Rows(0)(0) = sender.Text
        Else
            dt_print.Rows(0)(0) = ""
            Printype_list.List_Grid.CurrentCell = Printype_list.List_Grid.Rows(1).Cells(0)
        End If
    End Sub

    Private Sub print_type_txt_Enter(sender As Object, e As EventArgs) Handles print_type_txt.Enter
        If Printype_list.List_Grid.Rows.Count = 1 Then
            dt_print.Rows(0)(0) = sender.Text
        Else
            dt_print.Rows(0)(0) = ""
        End If
    End Sub

    Private Sub Rate_Valuation_TXT_TextChanged(sender As Object, e As EventArgs) Handles Rate_Valuation_TXT.TextChanged

    End Sub

    Private Sub Txt1_TextChanged(sender As Object, e As EventArgs) Handles Txt1.TextChanged

    End Sub

    Private Sub Credit_Limit_Warning_TextChanged(sender As Object, e As EventArgs) Handles Credit_Limit_Warning.TextChanged

    End Sub

    Private Sub Stock_Limit_Warning_TextChanged(sender As Object, e As EventArgs) Handles Stock_Limit_Warning.TextChanged

    End Sub
    Public Function Add_Class(nm As String, id_ As String)
        Dim obj As New sp_vouchers_type_class_ctrl

        With obj
            .Dock = DockStyle.Top
            .Add_Account_Group("", "")
            .Add_Ledger("", "", "", "", "")
        End With

        Try
            Dim ob As New voucher_class_list_ctrl
            ob.Dock = DockStyle.Top
            ob.Bg_Panel = Panel19
            ob.obj = Me
            ob.Txt1.Text = nm
            ob.Txt1.Data_Link_ = id_
            ob.Ctrl = obj
            Panel19.Controls.Add(ob)
            ob.BringToFront()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Function

    Private Sub Panel19_Paint(sender As Object, e As PaintEventArgs) Handles Panel19.Paint

    End Sub
End Class

