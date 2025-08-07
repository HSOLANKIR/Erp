Imports System.Data.SQLite
Imports System.IO

Public Class vc_order_details_ctrl
    Public obj As Object
    Dim tra_ID As String
    Private Function Load_()
        tra_ID = Inventory_Vouchers_frm.Order_Tra_ID
        Tra_ID_TXT.Text = tra_ID

        Order_date_LB.Text = Date_Formate(Find_DT_Value(Database_File.cre, "TBL_VC", "Date", $"Tra_ID = '{Inventory_Vouchers_frm.Order_Tra_ID}'"))
    End Function
    Private Function Save_()
        'Inventory_Vouchers_frm.Order_Tra_ID = tra_ID
        If Inventory_Vouchers_frm.Terms_of_payment = Nothing Then
            Inventory_Vouchers_frm.Terms_of_payment = Label10.Text
            Inventory_Vouchers_frm.Payment_reference = Other_refrence_LB.Text
            Inventory_Vouchers_frm.terms_of_delivery = terms_delivry_LB.Text
        End If
    End Function

    Private Sub vc_transport_ctrl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_()
        Fill_data_source()

        Button1.Focus()

    End Sub
    Private Function Fill_data_source()
        Dim dt As New DataTable
        dt.Columns.Add("Tra_ID")
        dt.Columns.Add("Order_No")
        dt.Columns.Add("Vc_Type")
        If Branch_Visible() = True Then
            dt.Columns.Add("Branch")
        End If
        dt.Columns.Add("Order_Date")
        dt.Columns.Add("Particulars")

        dt.Rows.Add("Not Applicable", "Not Applicable")

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


        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then


            cmd = New SQLiteCommand($"Select * From (SELECT vvc.Tra_ID,vvc.Voucher_No,vvc.Voucher_Type,vvc.[date] as dt_vc,(Select ld.name From TBL_Ledger ld where ld.id = vvc.Branch) as Branch_Name,(Select ld.name From TBL_Ledger ld where ld.id = vvc.Ledger) as Ledger_Name,ifnull(vi.Qty,0)-(Select ifnull(SUM(vii.Qty),0) From TBL_VC_item_Details vii where vii.Item = vi.Item and vc.Order_No = vi.Tra_ID and vii.Tra_ID <> vi.Tra_ID and (Select vcv.Visible From TBL_VC vcv where vcv.Tra_ID = vii.Tra_ID) = 'Approval') as vlu
From TBL_VC_item_Details vi
LEFT JOIN TBL_VC vc On vc.Order_No = vi.Tra_ID and vc.Visible = 'Approval'
LEFT JOIN TBL_VC vvc On vvc.Tra_ID = vi.Tra_ID
WHERE vvc.Visible = 'Approval' and (vvc.[Date] <= '{CDate(Inventory_Vouchers_frm.Date_TXT.Text).AddDays(1).ToString(Lite_date_Format)}') and {vc_type_FIlter}
Group By vvc.Tra_ID)
Group By Tra_ID", cn)

            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            'My.Computer.Clipboard.SetText(cmd.CommandText)
            Dim dr As DataRow
            While r.Read
                If ((Val(r("vlu")) > 0) Or r("Tra_ID") = tra_ID) Then
                    dr = dt.NewRow
                    dr("Tra_ID") = r("Tra_ID")
                    dr("Order_No") = r("Voucher_No")
                    dr("Vc_Type") = r("Voucher_Type")
                    dr("Order_Date") = Date_Formate(r("dt_vc"))
                    dr("Particulars") = r("Ledger_Name")
                    If Branch_Visible() = True Then
                        dr("Branch") = r("Branch_Name")
                    End If
                    dt.Rows.Add(dr)
                End If
            End While
        End If

        Order_No_Source.DataSource = dt
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'If Msg_Yn("Are you source ?", $"Applay Order Details Order No is {Order_no_LB.Text}") = DialogResult.Yes Save_z

        Save_()
        Inventory_Vouchers_frm.Order_Type = vc_Type_Label.Text
        Inventory_Vouchers_frm.Order_Fill_details(Tra_ID_TXT.Text)
        'End If

        Me.Dispose()
        Inventory_Vouchers_frm.SelectNextControl(obj, True, True, True, True)
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

    Private Sub Order_No_TXT_TextChanged(sender As Object, e As EventArgs) Handles Tra_ID_TXT.TextChanged

    End Sub

    Private Sub Order_No_TXT_LostFocus(sender As Object, e As EventArgs) Handles Tra_ID_TXT.LostFocus
        tra_ID = Tra_ID_TXT.Text

        Order_no_LB.Text = Find_DT_Value(Database_File.cre, "TBL_VC", "Voucher_No", $" Tra_ID = '{tra_ID}'")
        vc_Type_Label.Text = Find_DT_Value(Database_File.cre, "TBL_VC", "Voucher_Type", $" Tra_ID = '{tra_ID}'")

        Order_date_LB.Text = Date_Formate(Find_DT_Value(Database_File.cre, "TBL_VC", "Date", $" Tra_ID = '{tra_ID}'"))

        Label10.Text = (Find_DT_Value(Database_File.cre, "TBL_VC_Other", "Terms_of_payment", $" Tra_ID = '{tra_ID}'"))

        Other_refrence_LB.Text = (Find_DT_Value(Database_File.cre, "TBL_VC_Other", "Payment_reference", $" Tra_ID = '{tra_ID}'"))

        terms_delivry_LB.Text = (Find_DT_Value(Database_File.cre, "TBL_VC_Other", "terms_of_delivery", $" Tra_ID = '{tra_ID}'"))


        If Tra_ID_TXT.Text = Nothing Then
            Tra_ID_TXT.Text = "Not Applicable"
            Order_date_LB.Text = ""
            NOT_Clear()
        End If

        Fill_Attage()

    End Sub

    Private Sub Panel8_Paint(sender As Object, e As PaintEventArgs) Handles Panel8.Paint

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

        DataGridView1.Height = Val(DataGridView1.Rows.Count * 20) + DataGridView1.ColumnHeadersHeight + 5
    End Function

    Private Sub DataGridView1_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles DataGridView1.RowsAdded
        DataGridView1.Rows(DataGridView1.Rows.Count - 1).Height = 20
    End Sub
End Class
