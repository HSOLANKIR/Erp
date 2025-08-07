Imports System.Data.Entity.Core.Common.EntitySql
Imports System.Data.SQLite
Imports System.IO

Public Class vc_Order_Details_frm
    Dim Path_End As String
    Dim From_ID As String
    Private Sub vc_Order_Details_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        BG_frm.HADE_TXT.Text = "Vouchers Order Details"
        BG_frm.TYP_TXT.Text = ""
        obj_top(Panel1)

        Button_Manage()
        NOT_Clear()
        Add_Hander_Remove_Handel(True)

        Load_()
        Fill_data_source()
        List_set()
    End Sub
    Private Function Button_Manage()
        BG_frm.B_1.Text = "&E : Exit"
        BG_frm.B_2.Text = "&S : Save"
    End Function
    Private Function Add_Hander_Remove_Handel(Ans As Boolean)
        If Ans = True Then
            AddHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            AddHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
        Else
            RemoveHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            RemoveHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
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
        End If
    End Sub

    Private Sub vc_Order_Details_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.HADE_TXT.Text = "Vouchers Order Details"
        BG_frm.TYP_TXT.Text = ""
        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text

        Button_Clear()
        Button_Manage()

        'Dis_Doc_TXT.Focus()
    End Sub

    Private Sub vc_Order_Details_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub vc_Order_Details_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End
        Add_Hander_Remove_Handel(False)
        'Frm_foCus()
        Inventory_Vouchers_frm.Order_YN.Focus()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        obj_top(Panel1)
        order_list.Style_()
        order_list.Size_()
    End Sub
    Dim tra_ID As String
    Dim order_Under_tra_id As String
    Private Function Load_()


        tra_ID = Inventory_Vouchers_frm.Order_Tra_ID

        Order_date_LB.Text = Date_Formate(Find_DT_Value(Database_File.cre, "TBL_VC", "Date", $"Tra_ID = '{tra_ID}'"))
        Tra_ID_TXT.Text = (Find_DT_Value(Database_File.cre, "TBL_VC", "Voucher_No", $"Tra_ID = '{tra_ID}'"))


    End Function
    Private Function Save_()
        'Inventory_Vouchers_frm.Order_Tra_ID = tra_ID


        With Inventory_Vouchers_frm
                If .Terms_of_payment = Nothing Then
                    .Terms_of_payment = Label10.Text
                    .Payment_reference = Other_refrence_LB.Text
                    .terms_of_delivery = terms_delivry_LB.Text
                End If

            .Order_Type = vc_Type_Label.Text
            .Order_Tra_ID = tra_ID

                Dim cn As New SQLiteConnection


            If vc_Type_Label.Text = "Sales Order" Or vc_Type_Label.Text = "Purchase Order" Then
                .Label29.Text = Tra_ID_TXT.Text
                .Label30.Text = Order_date_LB.Text
                .Label31.Text = Delivery_Date_LB.Text
                .Order_Panel.Visible = True
                .Register_Panel.Visible = False
                .Sp_controls1.custome_stock_Panel.Visible = False
            ElseIf vc_Type_Label.Text = "Inward Register" Or vc_Type_Label.Text = "Outward Register" Then
                .Label38.Text = Tra_ID_TXT.Text
                .Label37.Text = Order_date_LB.Text

                .Register_Panel.Visible = True
                .Sp_controls1.custome_stock_Panel.Visible = True

                If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                    cmd = New SQLiteCommand($"Select * From TBL_VC vc where vc.Tra_ID = '{order_Under_tra_id}' and vc.Type = 'Head'", cn)
                    Dim r As SQLiteDataReader
                    r = cmd.ExecuteReader
                    While r.Read
                        Dim vc_type As String = r("Voucher_Type").ToString
                        If vc_type = "Sales Order" Or vc_type = "Purchase Order" Then
                            .Label29.Text = r("Voucher_No").ToString
                            .Label30.Text = Date_Formate(r("Date").ToString)
                            .Label31.Text = Date_Formate(r("Delivery_Date").ToString)
                            .Order_Panel.Visible = True
                        End If
                    End While
                    cn.Close()
                End If
            Else
                .Order_Panel.Visible = False
                .Register_Panel.Visible = False
                .Sp_controls1.Panel111.Visible = True
            End If
            If Yn2.Text = "Yes" Then
                .Display_all_Data(True, tra_ID)
            End If
        End With


        Me.Dispose()
        SendKeys.Send("{TAB}")

    End Function
    Dim order_list As List_frm
    Private Function List_set()
        Dim w As Integer = 0
        If Branch_Visible() = True Then
            w = 650
        Else
            w = 750
        End If

        order_list = New List_frm
        List_Setup("List Vouchers", Select_List.Botom, Select_List_Format.Custome, Tra_ID_TXT, order_list, Order_No_Source, w)

        With order_list.List_Grid
            .ColumnHeadersVisible = True
            .Columns(0).Visible = False
            .Columns(1).Width = 100
            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(2).Width = 100
            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(3).Width = 80
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(4).Width = 140
            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(5).Width = 150
            .Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns(6).Width = 90
            .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(7).Visible = False


            If Branch_Visible() = True Then
                .Columns(8).Width = 100
                .Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End If

        End With
    End Function
    Private Function Fill_data_source()
        Dim dt As New DataTable
        dt.Columns.Add("Tra_ID")
        dt.Columns.Add("Order_No")
        dt.Columns.Add("Vc_Type")
        dt.Columns.Add("Order_Date")
        dt.Columns.Add("Delivery_Date")
        dt.Columns.Add("Particulars")
        dt.Columns.Add("Amount")
        dt.Columns.Add("Order_ID")
        If Branch_Visible() = True Then
            dt.Columns.Add("Branch")
        End If


        dt.Rows.Add("", "Not Applicable")

        Dim vc_type_FIlter As String = ""

        If Inventory_Vouchers_frm.Voucher_Type_LB.Text = "Sales" Then
            vc_type_FIlter = " (vvc.Voucher_Type = 'Sales Order' or vvc.Voucher_Type = 'Outward Register')"
        ElseIf Inventory_Vouchers_frm.Voucher_Type_LB.Text = "Purchase" Then
            vc_type_FIlter = " (vvc.Voucher_Type = 'Purchase Order' or vvc.Voucher_Type = 'Inward Register')"
        ElseIf Inventory_Vouchers_frm.Voucher_Type_LB.Text = "Inward Register" Then
            vc_type_FIlter = " (vvc.Voucher_Type = 'Purchase Order')"
        ElseIf Inventory_Vouchers_frm.Voucher_Type_LB.Text = "Outward Register" Then
            vc_type_FIlter = " (vvc.Voucher_Type = 'Sales Order')"
        End If


        Dim Old_back_Order_ID As String = Find_DT_Value(Database_File.cre, "TBL_VC", "Order_No", $"Tra_ID = '{Inventory_Vouchers_frm.Tra_ID}'")

        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then


            cmd = New SQLiteCommand($"Select * From 
(SELECT vvc.Tra_ID,vvc.Order_No,vvc.Voucher_No,vvc.Voucher_Type,ifnull(vvc.Debit_Amount,0)+ifnull(vvc.Credit_Amount,0) as AMT,vvc.[date] as dt_vc,vvc.[Delivery_Date] as Delivery_Date,
(Select ld.name From TBL_Ledger ld where ld.id = vvc.Branch) as Branch_Name,
(Select ld.name From TBL_Ledger ld where ld.id = vvc.Ledger) as Ledger_Name,
vvc.Visible
From TBL_VC_item_Details vi
LEFT JOIN TBL_VC vc On vc.Order_No = vi.Tra_ID
LEFT JOIN TBL_VC vvc On vvc.Tra_ID = vi.Tra_ID
WHERE vvc.Type = 'Head' and (vvc.[Date] <= '{CDate(Inventory_Vouchers_frm.Date_TXT.Text).AddDays(1).ToString(Lite_date_Format)}') and {vc_type_FIlter}
Group By vvc.Tra_ID)
Group By Tra_ID", cn)

            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            Dim dr As DataRow
            While r.Read
                If r("Tra_ID").ToString = Old_back_Order_ID Or r("Visible").ToString = "Approval" Then
                    dr = dt.NewRow
                    dr("Tra_ID") = r("Tra_ID").ToString
                    dr("Order_No") = r("Voucher_No").ToString
                    dr("Vc_Type") = r("Voucher_Type").ToString
                    dr("Order_Date") = Date_Formate(r("dt_vc"))
                    dr("Particulars") = r("Ledger_Name").ToString
                    dr("Amount") = N2_FORMATE(r("AMT").ToString)
                    dr("Order_ID") = (r("Order_No").ToString)

                    If r("Voucher_Type").ToString = "Sales Order" Or r("Voucher_Type").ToString = "Purcgase Order" Then

                        If r("Delivery_Date").ToString <> Nothing Then
                            Dim dif As String = DateDiff(DateInterval.Day, CDate(Inventory_Vouchers_frm.Date_TXT.Text), CDate(r("Delivery_Date").ToString)) & " Days"
                            dr("Delivery_Date") = $"{Date_Formate(r("Delivery_Date").ToString)} ({dif})"
                        End If
                    End If
                    If Branch_Visible() = True Then
                        If r("Branch_Name").ToString = Nothing Then
                            dr("Branch") = "Primary"
                        Else
                            dr("Branch") = r("Branch_Name").ToString
                        End If
                    End If
                    dt.Rows.Add(dr)
                End If
            End While
        End If

        Order_No_Source.DataSource = dt
    End Function
    Private Sub Tra_ID_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles Tra_ID_TXT.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim ro As DataGridViewRow = order_list.List_Grid.CurrentRow

            If ro.Cells(1).Value.ToString = "Not Applicable" Then
                Yn2.Enabled = False
                Inventory_Vouchers_frm.Order_YN.Text = "No"

                Exit Sub
            End If


            tra_ID = ro.Cells(0).Value.ToString
            vc_Type_Label.Text = ro.Cells(2).Value.ToString
            Order_date_LB.Text = ro.Cells(3).Value.ToString
            Delivery_Date_LB.Text = ro.Cells(4).Value.ToString
            Particuls_no_LB.Text = ro.Cells(5).Value.ToString
            Label21.Text = ro.Cells(6).Value.ToString
            order_Under_tra_id = ro.Cells(7).Value.ToString

            Label10.Text = (Find_DT_Value(Database_File.cre, "TBL_VC_Other", "Terms_of_payment", $" Tra_ID = '{tra_ID}'"))
            Other_refrence_LB.Text = (Find_DT_Value(Database_File.cre, "TBL_VC_Other", "Payment_reference", $" Tra_ID = '{tra_ID}'"))
            terms_delivry_LB.Text = (Find_DT_Value(Database_File.cre, "TBL_VC_Other", "terms_of_delivery", $" Tra_ID = '{tra_ID}'"))

            Fill_Attage()

            'Tra_ID_TXT.Text = ro.Cells(1).Value.ToString
        End If
    End Sub
    Private Function Fill_Attage()

        If open_MSSQL(Database_File.rec) = True Then
            DataGridView1.Rows.Clear()
            qury = "Select * From TBL_Attage where TBL = 'TBL_VC' and TBL_ID = '" & tra_ID & "' and Visible = 'Approval'"
            cmd = New SQLiteCommand(qury, con)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                DataGridView1.Rows.Add(r("ID"), r("Name"), r("Narration"), r("Attage_Type"), r("Attage"), r("Password"))
            End While
        End If

        If DataGridView1.Rows.Count = 0 Then
            Attage_Panel.Visible = False
        Else
            Attage_Panel.Visible = True
        End If

        DataGridView1.Height = Val(DataGridView1.Rows.Count * 18) + DataGridView1.ColumnHeadersHeight + 5
    End Function
    Private Sub DataGridView1_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles DataGridView1.RowsAdded
        DataGridView1.Rows(DataGridView1.Rows.Count - 1).Height = 18
    End Sub
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim Byt As Byte()
        Byt = DirectCast(DataGridView1.CurrentRow.Cells(4).Value, Byte())

        Dim EditBTNDATA As String = DataGridView1.Columns(e.ColumnIndex).Name

        If EditBTNDATA = "DataGridViewImageColumn1" Then
            If DataGridView1.CurrentRow.Cells(5).Value <> Nothing Then
                Attage_Password.Password = DataGridView1.CurrentRow.Cells(5).Value
                If Attage_Password.ShowDialog <> DialogResult.Yes Then
                    Exit Sub
                End If
            End If
            Dim Formett As String = DataGridView1.CurrentRow.Cells(3).Value.ToString
            If Formett = ".Jpeg" Or Formett = ".jpg" Or Formett = ".jpg2" Or Formett = ".png" Or Formett = ".gif" Or Formett = ".bmp" Then
                Document_view_frm.Byt = Byt
                Document_view_frm.Name = DataGridView1.CurrentRow.Cells(1).Value.ToString
                Document_view_frm.Formett = Formett
                Document_view_frm.Narra = DataGridView1.CurrentRow.Cells(2).Value.ToString
                Document_view_frm.ShowDialog()
            End If
        ElseIf EditBTNDATA = "DataGridViewImageColumn2" Then
            Dim memory As New MemoryStream()
            Dim Formett As String
            If DataGridView1.CurrentRow.Cells(5).Value <> Nothing Then
                Attage_Password.Password = DataGridView1.CurrentRow.Cells(5).Value
                If Attage_Password.ShowDialog <> DialogResult.Yes Then
                    Exit Sub
                End If
            End If
            Formett = DataGridView1.CurrentRow.Cells(3).Value
            Dim ms As New MemoryStream(Byt)
            SaveFileDialog1.FileName = DataGridView1.CurrentRow.Cells(1).Value
            SaveFileDialog1.Title = "Save Document"
            If SaveFileDialog1.ShowDialog = DialogResult.OK Then
                Dim file As New FileStream(SaveFileDialog1.FileName & Formett, FileMode.Create, FileAccess.Write)
                ms.WriteTo(file)
                file.Close()
                ms.Close()
            End If


        ElseIf EditBTNDATA = "DataGridViewImageColumn3" Then

            If DataGridView1.CurrentRow.Cells(0).Value <> "0" Then
                If DataGridView1.CurrentRow.Cells(5).Value <> Nothing Then
                    Attage_Password.Password = DataGridView1.CurrentRow.Cells(5).Value
                    If Attage_Password.ShowDialog <> DialogResult.Yes Then
                        Exit Sub
                    End If
                End If

                If Msg_Yn("Are you source", "Delete Permanently Document") = DialogResult.Yes Then
                    If Data_Delete(Database_File.rec, "TBL_Attage", "Visible = 'Delete' WHERE ID = '" & DataGridView1.CurrentRow.Cells(0).Value & "'") = True Then
                        DataGridView1.Rows.Remove(DataGridView1.CurrentRow)
                    End If
                End If
            Else
                DataGridView1.Rows.Remove(DataGridView1.CurrentRow)
            End If
        End If
    End Sub

    Private Sub Panel1_LocationChanged(sender As Object, e As EventArgs) Handles Panel1.LocationChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Save_()
    End Sub

    Private Sub Button1_KeyDown(sender As Object, e As KeyEventArgs) Handles Button1.KeyDown
        If e.KeyCode = Keys.Back Then
            SendKeys.Send("+{TAB}")
        End If
        If e.KeyCode = Keys.Enter Then
            'Save_()
            Button1.PerformClick()
        End If
    End Sub

    Private Sub Tra_ID_TXT_TextChanged(sender As Object, e As EventArgs) Handles Tra_ID_TXT.TextChanged

    End Sub

    Private Sub vc_Order_Details_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
    End Sub
End Class