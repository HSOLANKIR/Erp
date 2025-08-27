Imports System.Data.SQLite
Imports Microsoft.Reporting.Map.WebForms.BingMaps
Imports Tools

Public Class stock_journal_controls
    Private Sub stock_journal_controls_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Fill_data_source()
        Fil_BOM_List_data(0)
        List_set_dft()
        Apply_cfg()
    End Sub
    Private Function Qry_Filters() As String
        Dim q As String = ""
        q &= $" and (vc.Visible = 'Approval')"
        q &= $" and (vc.[Date] <= '{CDate(Inventory_Vouchers_frm.Date_TXT.Text).AddDays(1).ToString(Lite_date_Format)}')"
        If Dft_Branch <> "Primary" Then
            q &= " AND VC.Branch = '" & Find_DT_Value(Database_File.cre, "TBL_Ledger", "ID", "Name = '" & Dft_Branch & "'") & "'"
        End If
        q &= $" and (vc.Tra_ID <> '{Inventory_Vouchers_frm.Tra_ID}')"
        Return q
    End Function
    Dim dt_item As New DataTable
    Private Function Fill_data_source()
        Dim cn As New SQLiteConnection
        Dim r As SQLiteDataReader

        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            dt_item = New DataTable
            dt_item.Columns.Add("Name")
            dt_item.Columns.Add("Stock")
            dt_item.Columns.Add("ID")
            dt_item.Columns.Add("Alias")
            dt_item.Columns.Add("Group")
            dt_item.Columns.Add("Color")
            dt_item.Columns.Add("Tax_Type")
            dt_item.Columns.Add("Tax_Per")
            dt_item.Columns.Add("Unit_id")
            dt_item.Columns.Add("Unit_decimal")
            dt_item.Columns.Add("A_Unit_ID")
            dt_item.Columns.Add("Unit_Name")
            dt_item.Columns.Add("GST_Applicapable")
            dt_item.Columns.Add("Valuation")
            dt_item.Columns.Add("Stock_vlu")
            dt_item.Columns.Add("Batch_YN")
            dt_item.Columns.Add("Mfg")
            dt_item.Columns.Add("Exp")
            dt_item.Columns.Add("A_Unit_Symbol")
            dt_item.Columns.Add("A_Unit_decimal")
            dt_item.Columns.Add("A_Unit1_Value")
            dt_item.Columns.Add("A_Unit2_Value")

            dt_item.Rows.Add("", "Create")

            dt_item.Rows.Add("End of List", "")

            cmd = New SQLiteCommand($"Select itm.id,itm.Batch_Yn,itm.Mfg_YN,itm.Exp_YN,itm.name,itm.Alias,itm.Tax_Type,itm.GST_Applicable,itm.[Unit] as Unit_id,itm.Alter_Unit,itm.Unit,itm.Alter_Unit_Val1,itm.Alter_Unit_Val2,
(Select tx.Percentage From TBL_TAX tx where tx.id = itm.Tax_Type) as Tax_Per,
(Select sg.name From TBL_Stock_Group sg where sg.id = itm.Under) as Under,
(Select u.Symbol From TBL_Inventory_Unit u where u.id = itm.[Unit]) as Unit_Symbol,
(Select iu.Decimal From TBL_Inventory_Unit iu where iu.id = itm.[Unit]) as Unit_decimal,
(Select u.Symbol From TBL_Inventory_Unit u where u.id = itm.[Alter_Unit]) as A_Unit_Symbol,
(Select iu.Decimal From TBL_Inventory_Unit iu where iu.id = itm.[Alter_Unit]) as A_Unit_decimal,
(Select ifnull(SUM(vi.Qty1),0) + ifnull(itm.ob_Quantity,0) From TBL_VC_item_Details vi
LEFT JOIN TBL_VC vc on vc.Tra_ID = vi.Tra_ID
 where vi.Item = itm.id and vi.Type = 'Credit' and vc.Effect_Stock = 'Yes' and vc.Type = 'Head' {Qry_Filters()})-
 (Select ifnull(SUM(vi.Qty1),0) From TBL_VC_item_Details vi
LEFT JOIN TBL_VC vc on vc.Tra_ID = vi.Tra_ID
 where vi.Item = itm.id and vi.Type = 'Debit' and vc.Effect_Stock = 'Yes' and vc.Type = 'Head' {Qry_Filters()}) as Stock,'0' as Rate_valuation From TBL_Stock_Item itm where itm.Visible = 'Approval' Order By itm.[Name]
  ", cn)

            r = cmd.ExecuteReader
            Dim dr As DataRow
            While r.Read
                dr = dt_item.NewRow
                dr("ID") = r("ID")
                dr("Name") = r("Name")
                dr("Alias") = r("Alias")
                dr("Group") = r("Under")
                dr("Tax_Type") = r("Tax_Type")
                dr("Unit_decimal") = r("Unit_decimal")
                dr("Tax_Per") = r("Tax_Per")
                dr("Unit_id") = r("Unit")
                dr("Unit_Name") = r("Unit_Symbol")
                dr("GST_Applicapable") = r("GST_Applicable")
                dr("Valuation") = nUmBeR_FORMATE(r("Rate_valuation").ToString)
                dr("Stock_vlu") = nUmBeR_FORMATE(r("Stock"))
                dr("Batch_YN") = r("Batch_Yn").ToString
                dr("Mfg") = r("Mfg_YN").ToString
                dr("Exp") = r("Exp_YN").ToString
                dr("A_Unit_ID") = r("Alter_Unit").ToString
                dr("A_Unit_Symbol") = r("A_Unit_Symbol").ToString
                dr("A_Unit_decimal") = r("A_Unit_decimal").ToString
                dr("A_Unit1_Value") = r("Alter_Unit_Val1").ToString
                dr("A_Unit2_Value") = r("Alter_Unit_Val2").ToString


                Dim stok As Decimal = Val(r("Stock").ToString)
                If stok < 0 Then
                    dr("Color") = "Red"
                Else
                    dr("Color") = "Black"
                End If

                dr("Stock") = stok & " " & r("Unit_Symbol")

                dt_item.Rows.Add(dr)
            End While
            item_source.DataSource = dt_item

        End If
    End Function

    Dim idx_S As Integer = 0
    Dim idx_P As Integer = 0
    Public Function Add_New_S() As stock_journal_under
        Dim c As New stock_journal_under
        With c
            .Obj = Me
            .isSource = True
            Source_P.Controls.Add(c)
            .Me__Control_ID = Source_P.Controls.OfType(Of stock_journal_under).ToList.Count
            .Dock = DockStyle.Top
            .BringToFront()
            .Set_Object_()
            .List_set()
        End With
        Return c
    End Function
    Public Function Add_New_P() As stock_journal_under
        Dim c As New stock_journal_under
        With c
            .Obj = Me
            .isSource = False
            Production_P.Controls.Add(c)
            .Me__Control_ID = Production_P.Controls.OfType(Of stock_journal_under).ToList.Count
            .Dock = DockStyle.Top
            .BringToFront()
            .Set_Object_()
            .List_set()
        End With
        Return c
    End Function
    Dim it_list_dft As List_frm
    Dim bom_list_dft As List_frm
    Private Function List_set_dft()
        it_list_dft = New List_frm
        List_Setup("List of Stock Items", Select_List.Right_Dock, Select_List_Format.Defolt, Txt1, it_list_dft, item_source, 320)
        it_list_dft.System_Data_integer = 1
        it_list_dft.Set_COlor(5)

        bom_list_dft = New List_frm
        List_Setup("List of BOM", Select_List.Right, Select_List_Format.Singel, Txt2, bom_list_dft, BOM_source, 200)
    End Function

    Private Sub stock_journal_controls_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        Fill_data_source()
        Apply_cfg()
    End Sub

    Public Function Apply_cfg()
        Production_panel.Visible = Inventory_Vouchers_frm.cfg_YN_Stock_Journal_Production
    End Function

    Dim production_it_id As String = ""
    Dim production_BOM_id As String = "NA"
    Dim production_Qty As String = ""
    Private Sub Txt1_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt1.KeyDown

        If e.KeyCode = Keys.Enter Then
            With it_list_dft.List_Grid
                production_it_id = .CurrentRow.Cells(2).Value.ToString

                If production_it_id = Nothing Then
                    Label11.Text = ""

                    Txt2.Text = ""
                    Txt2.Enabled = False

                    Txt3.Text = ""
                    Txt3.Enabled = False
                Else
                    Fil_BOM_List_data(production_it_id)
                    Txt2.Enabled = True
                    Txt3.Enabled = True

                    Txt3.Decimal_ = Val(.CurrentRow.Cells(9).Value.ToString)
                    Label11.Text = .CurrentRow.Cells(11).Value.ToString
                End If

            End With
        End If
    End Sub
    Private Function Fil_BOM_List_data(it As Integer)
        Dim dt_ As New DataTable
        dt_.Columns.Add("Name")
        dt_.Columns.Add("ID")
        dt_.Columns.Add("Production_Qty")
        dt_.Rows.Add("Not Applicable", "", 0)

        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select bt.id,bt.name,bt.Production_Qty From TBL_Batch bt
where bt.Item = '{it}'", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                dt_.Rows.Add(r("Name"), r("ID"), Val(r("Production_Qty")))
            End While
        End If
        BOM_source.DataSource = dt_
    End Function

    Private Sub Txt3_TextChanged(sender As Object, e As EventArgs) Handles Txt3.TextChanged

    End Sub

    Private Sub Txt3_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt3.KeyDown
        If e.KeyCode = Keys.Enter Then
            If production_BOM_id <> "NA" Then
                Fill_production()
            End If
        End If
    End Sub
    Private Function Fill_production()
        Source_P.Controls.Clear()
        Production_P.Controls.Clear()

        idx_S = 0
        idx_P = 0

        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select *,(Select it.name From TBL_Stock_Item it where it.id = bi.Item) as Item_Name,
(Select u.Symbol From TBL_Inventory_Unit u where U.id = (Select it.Unit From TBL_Stock_Item it where it.id = bi.Item)) as Unit
From TBL_Batch_Item bi
where bi.Batch = '{production_BOM_id}'", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                With Add_New_S()
                    .Item_TXT.Text = r("Item_Name").ToString
                    .Item_TXT.Data_Link_ = r("Item").ToString
                    .Qty_TXT.Text = Val(Val(r("Qty").ToString) / Val(production_Qty)) * Val(Txt3.Text)
                    .Qty1 = Val(Val(r("Qty").ToString) / Val(production_Qty)) * Val(Txt3.Text)
                    .Unit_Lst.Text = (r("Unit").ToString)
                End With

            End While
            cn.Close()

            With Add_New_P()
                .Item_TXT.Text = Txt1.Text
                .Item_TXT.Data_Link_ = production_it_id
                .Qty_TXT.Text = Val(Txt3.Text)
                .Qty1 = Val(Txt3.Text)
                .Unit_Lst.Text = Label11.Text
            End With
            SUM()
        End If
    End Function

    Private Sub Txt2_TextChanged(sender As Object, e As EventArgs) Handles Txt2.TextChanged

    End Sub

    Private Sub Txt2_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt2.KeyDown
        If e.KeyCode = Keys.Enter Then
            If bom_list_dft.List_Grid.CurrentRow.Cells(0).Value.ToString = "Not Applicable" Then
                production_BOM_id = "NA"
                production_Qty = "NA"
            Else
                production_BOM_id = bom_list_dft.List_Grid.CurrentRow.Cells(1).Value.ToString
                production_Qty = Val(bom_list_dft.List_Grid.CurrentRow.Cells(2).Value.ToString)
            End If
        End If
    End Sub
    Public Function SUM()
        Try
            Dim cl As Decimal = 0
            Array.ForEach(Source_P.Controls.OfType(Of stock_journal_under)().ToArray(),
              Sub(lbl) cl += Val(lbl.Amount_TXT.Text))
            Label14.Text = N2_FORMATE(cl)

        Catch ex As Exception

        End Try

        Try
            Dim cl As Decimal = 0
            Array.ForEach(Production_P.Controls.OfType(Of stock_journal_under)().ToArray(),
              Sub(lbl) cl += Val(lbl.Amount_TXT.Text))
            Label15.Text = N2_FORMATE(cl)

        Catch ex As Exception

        End Try

        Label18.Text = nUmBeR_FORMATE(Label15.Text) - nUmBeR_FORMATE(Label14.Text)

        If Val(Label18.Text) < 0 Then
            Label18.ForeColor = Color.Red
            Label19.ForeColor = Color.Red
            Label19.Text = "Loss"
        Else
            Label18.ForeColor = Color.Green
            Label19.ForeColor = Color.Green
            Label19.Text = "Profit"
        End If
        Label18.Text = N2_FORMATE(Label18.Text)
    End Function
End Class
