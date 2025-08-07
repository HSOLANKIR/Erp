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
            dt_item.Columns.Add("Batches")
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
                dr("Batches") = r("Batch_Yn").ToString
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
    Public Function Add_New_S()
        idx_S = Source_P.Controls.OfType(Of Panel).ToList.Count + 1

        Dim bg_p As Panel = New Panel
        Dim particult_P As Panel = New Panel
        Dim Balance_panel As Panel = New Panel

        bg_p.Controls.Add(particult_P)
        bg_p.Controls.Add(Balance_panel)
        bg_p.Dock = System.Windows.Forms.DockStyle.Top
        bg_p.Location = New System.Drawing.Point(0, 0)
        bg_p.Name = "bgS_" & idx_S
        bg_p.TabIndex = idx_S
        bg_p.Size = New System.Drawing.Size(903, 40)
        bg_p.AutoSize = True

        cr_particuls_S(particult_P, "S", idx_S)
        Balance_Panel_ctrl(Balance_panel, "S", idx_S)

        Source_P.Controls.Add(bg_p)
        bg_p.BringToFront()

        List_set_it(idx_S, True)

    End Function
    Public Function Add_New_P()
        idx_P = Production_P.Controls.OfType(Of Panel).ToList.Count + 1

        Dim bg_p As Panel = New Panel
        Dim particult_P As Panel = New Panel
        Dim Balance_panel As Panel = New Panel

        bg_p.Controls.Add(particult_P)
        bg_p.Controls.Add(Balance_panel)
        bg_p.Dock = System.Windows.Forms.DockStyle.Top
        bg_p.Location = New System.Drawing.Point(0, 0)
        bg_p.Name = "bgP_" & idx_P
        bg_p.TabIndex = idx_P
        bg_p.Size = New System.Drawing.Size(903, 40)
        bg_p.AutoSize = True

        cr_particuls_S(particult_P, "P", idx_P)
        Balance_Panel_ctrl(Balance_panel, "P", idx_P)

        Production_P.Controls.Add(bg_p)
        bg_p.BringToFront()

        List_set_it(idx_P, False)
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
    Dim it_list As List_frm
    Private Function List_set_it(idx As Integer, isSource As Boolean)
        Dim particuls As TXT
        Dim type_ As Select_List
        Dim with_ As Integer

        particuls = Find_Particuls_TXT(idx, isSource)

        If isSource = True Then
            type_ = Select_List.Right_Dock
            with_ = 320
        Else
            type_ = Select_List.Botom
            with_ = Val(particuls.Width)
        End If

        it_list = New List_frm
        List_Setup("List of Stock Items", type_, Select_List_Format.Defolt, particuls, it_list, item_source, with_)
        it_list.System_Data_integer = 1
        it_list.Set_COlor(5)
    End Function
    Private Function Balance_Panel_ctrl(Pan As Panel, T As String, idx As Integer)
        Dim bal_lab As Label = New Label
        Dim unit2_lab As Label = New Label

        'balancepan_
        '
        Pan.Controls.Add(bal_lab)
        Pan.Controls.Add(unit2_lab)
        'Pan.Controls.Add(null1_lab)
        'Pan.Controls.Add(null2_lab)
        Pan.Dock = System.Windows.Forms.DockStyle.Top
        Pan.Location = New System.Drawing.Point(0, 19)
        Pan.Name = $"balancepan{T}_" & idx
        Pan.Size = New System.Drawing.Size(903, 22)
        Pan.TabIndex = 1
        Pan.Visible = False
        Pan.BringToFront()


        'ballab_
        '
        bal_lab.Dock = System.Windows.Forms.DockStyle.Fill
        bal_lab.Font = New System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        bal_lab.Location = New System.Drawing.Point(0, 0)
        bal_lab.Name = $"ballab{T}_" & idx
        bal_lab.Padding = New System.Windows.Forms.Padding(30, 0, 0, 0)
        bal_lab.Size = New System.Drawing.Size(512, 15)
        bal_lab.TabIndex = 11
        bal_lab.Text = ""
        bal_lab.TextAlign = System.Drawing.ContentAlignment.TopCenter
        bal_lab.ForeColor = Color.DimGray

        'unit2lab_
        '
        unit2_lab.Dock = System.Windows.Forms.DockStyle.Right
        unit2_lab.Font = New System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        unit2_lab.Location = New System.Drawing.Point(512, 0)
        unit2_lab.Name = $"unit2lab{T}_" & idx
        unit2_lab.Size = New System.Drawing.Size(171, 15)
        unit2_lab.TabIndex = 10
        unit2_lab.Text = ""
        unit2_lab.TextAlign = System.Drawing.ContentAlignment.TopCenter

    End Function
    Private Function cr_particuls_S(p As Panel, T As String, idx As Integer)
        Dim particuls_txt As TXT = New TXT
        Dim qty_txt As TXT = New TXT
        Dim unit_lab As Label = New Label
        Dim other_data As Label = New Label

        Dim it_id As Label = New Label
        Dim unit_1 As Label = New Label
        Dim unit_2 As Label = New Label
        Dim unti_decimal As Label = New Label
        Dim godownyn_ As Label = New Label
        Dim batchyn_ As Label = New Label
        Dim mfgyn_ As Label = New Label
        Dim expyn_ As Label = New Label

        Dim Unit1_Vlu As Label = New Label
        Dim Unit2_Vlu As Label = New Label

        Dim Qty1 As Label = New Label
        Dim Qty2 As Label = New Label

        Dim stock_ As Label = New Label

        p.Controls.Add(particuls_txt)
        p.Controls.Add(qty_txt)
        p.Controls.Add(unit_lab)

        p.Controls.Add(it_id)
        p.Controls.Add(unit_1)
        p.Controls.Add(unit_2)
        p.Controls.Add(Unit1_Vlu)
        p.Controls.Add(Unit2_Vlu)
        p.Controls.Add(Qty1)
        p.Controls.Add(Qty2)

        p.Controls.Add(unti_decimal)

        p.Controls.Add(stock_)
        p.Controls.Add(godownyn_)
        p.Controls.Add(batchyn_)
        p.Controls.Add(mfgyn_)
        p.Controls.Add(expyn_)
        p.Controls.Add(other_data)

        'Acc_ID
        it_id.Name = $"AccID{T}_" & idx
        it_id.Visible = False
        'Unit1
        unit_1.Name = $"unit11lab{T}_" & idx
        unit_1.Visible = False
        'Unit2
        unit_2.Name = $"unit22lab{T}_" & idx
        unit_2.Visible = False

        'Unit_Values
        Unit1_Vlu.Name = $"unit1vlulab{T}_" & idx
        Unit1_Vlu.Visible = False

        Unit2_Vlu.Name = $"unit2vlulab{T}_" & idx
        Unit2_Vlu.Visible = False

        'Qty
        Qty1.Name = $"qty1{T}_" & idx
        Qty1.Visible = False

        Qty2.Name = $"qty2{T}_" & idx
        Qty2.Visible = False


        'Decimal
        unti_decimal.Name = $"decimal{T}_" & idx
        unti_decimal.Visible = False
        'Stock
        stock_.Name = $"stock{T}_" & idx
        stock_.Visible = False
        'Godown
        godownyn_.Name = $"godownyn{T}_" & idx
        godownyn_.Visible = False
        'Batch
        batchyn_.Name = $"batchyn{T}_" & idx
        batchyn_.Visible = False
        'mfgyn_
        mfgyn_.Name = $"mfgyn{T}_" & idx
        mfgyn_.Visible = False
        'expyn_
        expyn_.Name = $"expyn{T}_" & idx
        expyn_.Visible = False
        'other Data
        other_data.Name = $"otherdata{T}_" & idx
        other_data.Visible = False
        other_data.Text = ""

        p.Dock = System.Windows.Forms.DockStyle.Top
        p.Location = New System.Drawing.Point(0, 0)
        p.Name = $"particulspanel{T}_" & idx
        p.Size = New System.Drawing.Size(903, 16)
        p.TabIndex = 0
        p.BackColor = Color.White

        If T = "S" Then
            AddHandler p.Enter, AddressOf bg_panel_Enter_S
            AddHandler p.Leave, AddressOf bg_panel_Leave_S
        Else
            AddHandler p.Enter, AddressOf bg_panel_Enter_P
            AddHandler p.Leave, AddressOf bg_panel_Leave_P
        End If

        particuls_txt.Back_color = Color.White
        particuls_txt.BackColor = Color.White
        particuls_txt.BorderStyle = System.Windows.Forms.BorderStyle.None
        particuls_txt.Data_Link_ = ""
        particuls_txt.Dock = System.Windows.Forms.DockStyle.Fill
        particuls_txt.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        particuls_txt.Keydown_Support = True
        particuls_txt.Location = New System.Drawing.Point(0, 0)
        particuls_txt.Name = $"Particulstxt{T}_" & idx
        particuls_txt.Size = New System.Drawing.Size(512, 17)
        particuls_txt.TabIndex = 0
        particuls_txt.Type_ = "Select"
        particuls_txt.Select_Source = item_source
        particuls_txt.Select_Column_Color = 5
        particuls_txt.Select_Auto_Show = False
        particuls_txt.Select_Filter = "(Name Like '%<value>%' or Alias LIKE '%<value>%') or(Name = 'End of List')"
        particuls_txt.Select_Columns = 0
        particuls_txt.ReadOnly = False
        particuls_txt.Font_Size = 10

        If T = "S" Then
            AddHandler particuls_txt.Enter, AddressOf Particuls_Enter_S
            AddHandler particuls_txt.LostFocus, AddressOf Particuls_LostFocus_S
            AddHandler particuls_txt.KeyDown, AddressOf particuls_Keydown_S
        Else
            AddHandler particuls_txt.Enter, AddressOf Particuls_Enter_P
            AddHandler particuls_txt.LostFocus, AddressOf Particuls_LostFocus_P
            AddHandler particuls_txt.KeyDown, AddressOf particuls_Keydown_P
        End If

        qty_txt.Back_color = Color.White
        qty_txt.BackColor = Color.White
        qty_txt.BorderStyle = System.Windows.Forms.BorderStyle.None
        qty_txt.Data_Link_ = ""
        qty_txt.Dock = System.Windows.Forms.DockStyle.Right
        qty_txt.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        qty_txt.Keydown_Support = False
        qty_txt.Location = New System.Drawing.Point(512, 0)
        qty_txt.Name = $"qtytxt{T}_" & idx
        qty_txt.Size = New System.Drawing.Size(80, 17)
        qty_txt.TabIndex = 1
        qty_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        qty_txt.Type_ = "Num"
        qty_txt.Font_Size = 10

        If T = "S" Then
            AddHandler qty_txt.TextChanged, AddressOf qty_TXT_TextChanged_S
            AddHandler qty_txt.KeyDown, AddressOf qty_Keydown_S
        Else
            AddHandler qty_txt.TextChanged, AddressOf qty_TXT_TextChanged_P
            AddHandler qty_txt.KeyDown, AddressOf qty_Keydown_P
        End If



        unit_lab.Dock = System.Windows.Forms.DockStyle.Right
        unit_lab.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        unit_lab.Location = New System.Drawing.Point(592, 0)
        unit_lab.Name = $"unitlab{T}_" & idx
        unit_lab.Size = New System.Drawing.Size(91, 19)
        unit_lab.TabIndex = 2
        unit_lab.Text = ""
        unit_lab.BackColor = Color.White

    End Function
    Private Sub Particuls_LostFocus_P(sender As Object, e As EventArgs)
        'Dim TX_ As TXT = CType(sender, TXT)
        'Dim index As Integer = Integer.Parse(TX_.Name.Split("_")(1))

        'If Find_Particuls_TXT(Find_Idx(sender), False).Text = "End of List" Or Find_Particuls_TXT(Find_Idx(sender), False).Text.Trim = Nothing Then
        '    Find_qty_TXT(index, False).Text = ""
        '    Find_qty_TXT(index, False).Enabled = False

        '    fill_balance_P(sender)
        '    'Closing_Fill()

        '    'Inventory_Vouchers_frm.SelectNextControl(Inventory_Vouchers_frm.Panel30, True, True, False, True)
        '    Exit Sub
        'Else
        '    Find_qty_TXT(index, False).Enabled = True
        'End If

        'If Find_Particuls_TXT(Find_Idx(sender), False).Text.Trim <> Nothing Then

        '    Find_AccID_Label(Find_Idx(sender), False).Text = Find_DT_Value(Database_File.cre, "TBL_Stock_Item", "ID", "Name = '" & sender.Text & "'")

        '    'find_stock_lab(Find_Idx(sender), False).Text = Val(Item_Stock(Find_AccID_Label(Find_Idx(sender), False).Text, Inventory_Vouchers_frm.Date_TXT.Text, Inventory_Vouchers_frm.Branch_ID, Inventory_Vouchers_frm.Tra_ID))

        '    Dim unit As String = it_list.List_Grid.CurrentRow.Cells(8).Value.ToString

        '    Find_Unit1_Label(Find_Idx(sender), False).Text = unit

        '    find_decimal_lab(Find_Idx(sender), False).Text = Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "Decimal", "Symbol = '" & unit & "'")

        '    unit = Find_DT_Value(Database_File.cre, "TBL_Stock_Item", "Alter_Unit", "ID = '" & Find_AccID_Label(Find_Idx(sender), False).Text & "'")

        '    Find_Unit2_Label(Find_Idx(sender), False).Text = unit
        '    Find_unit_lab(Find_Idx(sender), False).Text = Find_Unit1_Label(Find_Idx(sender), False).Text

        '    fill_balance_S(sender)
        '    'Closing_Fill()

        'End If
    End Sub
    Private Sub Particuls_Enter_S(sender As Object, e As EventArgs)
        item_source.MoveFirst()
    End Sub
    Private Sub Particuls_Enter_P(sender As Object, e As EventArgs)
        item_source.MoveFirst()
    End Sub
    Private Sub particuls_Keydown_P(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Dim TX_ As TXT = CType(sender, TXT)
            Dim index As Integer = Integer.Parse(TX_.Name.Split("_")(1))

            Find_AccID_Label(Find_Idx(sender), False).Text = it_list.List_Grid.CurrentRow.Cells("ID").Value.ToString

            If Find_AccID_Label(Find_Idx(sender), False).Text = Nothing Then
                Find_qty_TXT(index, False).Text = ""
                Find_qty_TXT(index, False).Enabled = False

                Find_unit_lab(index, False).Text = ""

                fill_balance_P(sender)
            Else
                Find_qty_TXT(index, False).Enabled = True
                find_stock_lab(Find_Idx(sender), False).Text = Val(it_list.List_Grid.CurrentRow.Cells("Stock_vlu").Value.ToString)



                Find_Unit1_Label(Find_Idx(sender), False).Text = it_list.List_Grid.CurrentRow.Cells("Unit_id").Value.ToString
                find_decimal_lab(Find_Idx(sender), False).Text = Val(it_list.List_Grid.CurrentRow.Cells("Unit_decimal").Value.ToString)

                Find_Unit2_Label(Find_Idx(sender), False).Text = it_list.List_Grid.CurrentRow.Cells("A_Unit_ID").Value.ToString
                Find_unit_lab(Find_Idx(sender), False).Text = it_list.List_Grid.CurrentRow.Cells("Unit_Name").Value.ToString

                Find_Unit1_Value(Find_Idx(sender), False).Text = it_list.List_Grid.CurrentRow.Cells("A_Unit1_Value").Value.ToString
                Find_Unit2_Value(Find_Idx(sender), False).Text = it_list.List_Grid.CurrentRow.Cells("A_Unit2_Value").Value.ToString

                Unit_Details_Fill(Find_Idx(sender), False)

                fill_balance_P(sender)
            End If
        End If
    End Sub
    Private Sub particuls_Keydown_S(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Dim TX_ As TXT = CType(sender, TXT)
            Dim index As Integer = Integer.Parse(TX_.Name.Split("_")(1))

            Find_AccID_Label(Find_Idx(sender), True).Text = it_list.List_Grid.CurrentRow.Cells("ID").Value.ToString

            If Find_AccID_Label(Find_Idx(sender), True).Text = Nothing Then
                Find_qty_TXT(index, True).Text = ""
                Find_qty_TXT(index, True).Enabled = False

                fill_balance_S(sender)

                'Inventory_Vouchers_frm.SelectNextControl(Inventory_Vouchers_frm.Panel30, True, True, False, True)
                Exit Sub
            Else
                Find_qty_TXT(index, True).Enabled = True
                find_stock_lab(Find_Idx(sender), True).Text = Val(it_list.List_Grid.CurrentRow.Cells("Stock_vlu").Value.ToString)


                Find_Unit1_Label(Find_Idx(sender), True).Text = it_list.List_Grid.CurrentRow.Cells("Unit_id").Value.ToString
                find_decimal_lab(Find_Idx(sender), True).Text = Val(it_list.List_Grid.CurrentRow.Cells("Unit_decimal").Value.ToString)

                Find_Unit2_Label(Find_Idx(sender), True).Text = it_list.List_Grid.CurrentRow.Cells("A_Unit_ID").Value.ToString
                Find_unit_lab(Find_Idx(sender), True).Text = it_list.List_Grid.CurrentRow.Cells("Unit_Name").Value.ToString

                Find_Unit1_Value(Find_Idx(sender), True).Text = it_list.List_Grid.CurrentRow.Cells("A_Unit1_Value").Value.ToString
                Find_Unit2_Value(Find_Idx(sender), True).Text = it_list.List_Grid.CurrentRow.Cells("A_Unit2_Value").Value.ToString

                Unit_Details_Fill(Find_Idx(sender), True)

                fill_balance_S(sender)
            End If
        End If
    End Sub
    Public Function Unit_Details_Fill(idx As Integer, isSource As Boolean)
        If Val(Find_Unit2_Value(idx, isSource).Text) <> 0 Then
            Dim v As Decimal = Val(Find_Unit2_Value(idx, isSource).Text) / Val(Find_Unit1_Value(idx, isSource).Text)
            Dim Q As Decimal = v * Val(Find_qty_TXT(idx, isSource).Text)

            Find_Qty1(idx, isSource).Text = Val(Find_qty_TXT(idx, isSource).Text)
            Find_Qty2(idx, isSource).Text = Q
        Else
            Find_Qty1(idx, isSource).Text = Val(Find_qty_TXT(idx, isSource).Text)
            Find_Qty2(idx, isSource).Text = ""
        End If
    End Function

    Public Function Other_details(idx As Integer, isSource As Boolean) As Boolean
        Find_godown_YN_Label(idx, isSource).Text = Boolean_TXT(Godown_YN)
        'With it_list.List_Grid.CurrentRow
        '    If Batches_YN = True Then
        '        Find_Batch_YN_Label(idx, isSource).Text = (.Cells(13).Value.ToString)
        '        Find_mfg_YN_Label(idx, isSource).Text = (.Cells(14).Value.ToString)
        '        Find_exp_YN_Label(idx, isSource).Text = (.Cells(15).Value.ToString)
        '    Else
        '        Find_Batch_YN_Label(idx, isSource).Text = "No"
        '        Find_mfg_YN_Label(idx, isSource).Text = "No"
        '        Find_exp_YN_Label(idx, isSource).Text = "No"
        '    End If
        'End With
        If YN_Boolean(Find_Batch_YN_Label(idx, isSource).Text) = True Or YN_Boolean(Find_godown_YN_Label(idx, isSource).Text) = True Then
            Return True
        Else
            Return False
        End If

    End Function
    Private Sub Particuls_LostFocus_S(sender As Object, e As EventArgs)

        If Production_P.Controls.Count = 0 Then
            Add_New_P()
        End If

        'Dim TX_ As TXT = CType(sender, TXT)
        'Dim index As Integer = Integer.Parse(TX_.Name.Split("_")(1))

        'If Find_Particuls_TXT(Find_Idx(sender), True).Text = "End of List" Or Find_Particuls_TXT(Find_Idx(sender), True).Text.Trim = Nothing Then
        '    Find_qty_TXT(index, True).Text = ""
        '    Find_qty_TXT(index, True).Enabled = False

        '    fill_balance_S(sender)

        '    If Production_P.Controls.Count = 0 Then
        '        Add_New_P()
        '    End If
        '    Inventory_Vouchers_frm.SelectNextControl(Inventory_Vouchers_frm.Panel30, True, True, False, True)
        '    Exit Sub
        'Else
        '    Find_qty_TXT(index, True).Enabled = True
        'End If

        'If Find_Particuls_TXT(Find_Idx(sender), True).Text.Trim <> Nothing Then

        '    Find_AccID_Label(Find_Idx(sender), True).Text = Find_DT_Value(Database_File.cre, "TBL_Stock_Item", "ID", "Name = '" & sender.Text & "'")

        '    find_stock_lab(Find_Idx(sender), True).Text = Val(Item_Stock(Find_AccID_Label(Find_Idx(sender), True).Text, Inventory_Vouchers_frm.Date_TXT.Text, Inventory_Vouchers_frm.Branch_ID, Inventory_Vouchers_frm.Tra_ID))


        '    Dim unit As String = Find_DT_Unit_Conves(Find_DT_Value(Database_File.cre, "TBL_Stock_Item", "Unit", "ID = '" & Find_AccID_Label(Find_Idx(sender), True).Text & "'"))

        '    Find_Unit1_Label(Find_Idx(sender), True).Text = unit

        '    find_decimal_lab(Find_Idx(sender), True).Text = Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "Decimal", "Symbol = '" & unit & "'")

        '    unit = Find_DT_Value(Database_File.cre, "TBL_Stock_Item", "Alter_Unit", "ID = '" & Find_AccID_Label(Find_Idx(sender), True).Text & "'")

        '    Find_Unit2_Label(Find_Idx(sender), True).Text = unit
        '    Find_unit_lab(Find_Idx(sender), True).Text = Find_Unit1_Label(Find_Idx(sender), True).Text

        '    fill_balance_S(sender)
        '    'Closing_Fill()

        'End If
    End Sub
    Private Sub qty_TXT_TextChanged_S(sender As Object, e As EventArgs)
        Unit_Details_Fill(Find_Idx(sender), True)

        If Val(sender.Text) > Val(find_stock_lab(Find_Idx(sender), True).Text) Then
            NOT_("Negative Stock", NOT_Type.Warning)
        Else
            NOT_Clear()
        End If
    End Sub
    Private Sub qty_TXT_TextChanged_P(sender As Object, e As EventArgs)
        Unit_Details_Fill(Find_Idx(sender), False)

        'If Val(sender.Text) > Val(find_stock_lab(Find_Idx(sender), False).Text) Then
        '    NOT_("Negative Stock", NOT_Type.Warning)
        'Else
        '    NOT_Clear()
        'End If
    End Sub
    Private Sub qty_Keydown_S(sender As Object, e As KeyEventArgs)
        Dim TX_ As TXT = CType(sender, TXT)
        Dim index As Integer = Find_Idx(sender)

        'amt_vlu(sender)
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            fill_balance_S(sender)

            'Closing_Fill()

            If Inventory_Vouchers_frm.cfg_YN_zero = False Then
                If Val(sender.Text) = 0 Then
                    e.SuppressKeyPress = True
                    NOT_("Please enter quantity, and try again", NOT_Type.Warning)
                    sender.Text = ""
                    If Inventory_Vouchers_frm.cfg_YN_zero = False Then
                        sender.Focus()
                        Exit Sub
                    End If
                End If
            End If
            NOT_Clear()
            If Source_P.Controls.Count = index Then
                Add_New_S()
                'SendKeys.Send("{TAB}")
            Else
                'SendKeys.Send("{TAB}")
            End If
        End If
    End Sub
    Private Sub qty_Keydown_P(sender As Object, e As KeyEventArgs)
        Dim TX_ As TXT = CType(sender, TXT)
        Dim index As Integer = Find_Idx(sender)

        'amt_vlu(sender)
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            fill_balance_P(sender)

            'Closing_Fill()

            If Inventory_Vouchers_frm.cfg_YN_zero = False Then
                If Val(sender.Text) = 0 Then
                    e.SuppressKeyPress = True
                    NOT_("Please enter quantity, and try again", NOT_Type.Warning)
                    sender.Text = ""
                    If Inventory_Vouchers_frm.cfg_YN_zero = False Then
                        sender.Focus()
                        Exit Sub
                    End If
                End If
            End If
            NOT_Clear()
            If Production_P.Controls.Count = index Then
                Add_New_P()
                'SendKeys.Send("{TAB}")
            Else
                'SendKeys.Send("{TAB}")
            End If
        End If
    End Sub
    Public Function fill_balance_S(sender As Object)
        Dim idx As Integer = Find_Idx(sender)
        Dim id As String = Find_AccID_Label(Find_Idx(sender), True).Text

        Find_qty_TXT(Find_Idx(sender), True).Decimal_ = Val(find_decimal_lab(Find_Idx(sender), True).Text)

        'Find_unit_lab(Find_Idx(sender), True).Text = Find_Unit1_Label(Find_Idx(sender), True).Text

        If Val(id) <> 0 Then
            Find_unit1_lab(Find_Idx(sender), True).Text = Find_alter_unit_vlu(Find_AccID_Label(Find_Idx(sender), True).Text, Val(Find_qty_TXT(Find_Idx(sender), True).Text), False, False, True)
        End If




        If Find_unit1_lab(idx, True).Text = Nothing Then
            Find_Balance_Panel(idx, True).Visible = False
        Else
            Find_Balance_Panel(idx, True).Visible = True
        End If


        Dim closing_ As Decimal
        Dim curr As Decimal = 0.00

        curr = Val(Find_qty_TXT(Find_Idx(sender), True).Text) * -1


        closing_ = Val(find_stock_lab(Find_Idx(sender), True).Text) - curr

        If Val(closing_) <= 0 Then
            Find_lab_lab(Find_Idx(sender), True).ForeColor = Color.Red
        Else
            Find_lab_lab(Find_Idx(sender), True).ForeColor = Color.Green
        End If

        'Find_lab_lab(Find_Idx(sender), True).Text = "Curr. Stock : " & closing_ & " " & Find_Unit1_Label(Find_Idx(sender), True).Text

    End Function
    Public Function fill_balance_P(sender As Object)
        Dim idx As Integer = Find_Idx(sender)
        Dim id As String = Find_AccID_Label(Find_Idx(sender), False).Text

        Find_qty_TXT(Find_Idx(sender), False).Decimal_ = Val(find_decimal_lab(Find_Idx(sender), False).Text)

        If Val(id) <> 0 Then
            Find_unit1_lab(Find_Idx(sender), False).Text = Find_alter_unit_vlu(Find_AccID_Label(Find_Idx(sender), False).Text, Val(Find_qty_TXT(Find_Idx(sender), False).Text), False, False, True)
        End If

        If Find_unit1_lab(idx, False).Text = Nothing Then
            Find_Balance_Panel(idx, False).Visible = False
        Else
            Find_Balance_Panel(idx, False).Visible = True
        End If

        Dim closing_ As Decimal
        Dim curr As Decimal = 0.00

        curr = Val(Find_qty_TXT(Find_Idx(sender), False).Text) * -1

        'closing_ = Val(find_stock_lab(Find_Idx(sender), False).Text) - curr

        If Val(closing_) <= 0 Then
            Find_lab_lab(Find_Idx(sender), False).ForeColor = Color.Red
        Else
            Find_lab_lab(Find_Idx(sender), False).ForeColor = Color.Green
        End If

        'Find_lab_lab(Find_Idx(sender), False).Text = "Curr. Stock : " & closing_ & " " & Find_Unit1_Label(Find_Idx(sender), False).Text

    End Function
    Public Function Find_lab_lab(index As Integer, isSource As Boolean) As Label
        Dim f As String
        If isSource = True Then
            f = "S"
        Else
            f = "P"
        End If
        Try
            Return CType(bg_Panel.Controls.Find(($"ballab{f}_" & index), True).First, Label)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Balance_Panel(index As Integer, isSource As Boolean) As Panel
        Dim f As String
        If isSource = True Then
            f = "S"
        Else
            f = "P"
        End If
        Try
            Return CType(bg_Panel.Controls.Find(($"balancepan{f}_" & index), True).First, Panel)
        Catch ex As Exception

        End Try
    End Function

    Public Function Find_unit_lab(index As Integer, isSource As Boolean) As Label
        Dim f As String
        If isSource = True Then
            f = "S"
        Else
            f = "P"
        End If

        Try
            Return CType(bg_Panel.Controls.Find(($"unitlab{f}_" & index), True).First, Label)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_unit1_lab(index As Integer, isSource As Boolean) As Label
        Dim f As String
        If isSource = True Then
            f = "S"
        Else
            f = "P"
        End If
        Try
            Return CType(bg_Panel.Controls.Find(($"unit2lab{f}_" & index), True).First, Label)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_AccID_Label(index As Integer, isSource As Boolean) As Label
        Dim f As String
        If isSource = True Then
            f = "S"
        Else
            f = "P"
        End If

        Try
            Return CType(bg_Panel.Controls.Find(($"AccID{f}_" & index), True).First, Label)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Particuls_TXT(index As Integer, isSource As Boolean) As TXT
        Dim f As String
        If isSource = True Then
            f = "S"
        Else
            f = "P"
        End If
        Try
            Return CType(bg_Panel.Controls.Find(($"Particulstxt{f}_" & index), True).First, TXT)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_qty_TXT(index As Integer, isSource As Boolean) As TXT
        Dim f As String
        If isSource = True Then
            f = "S"
        Else
            f = "P"
        End If
        Try
            Return CType(bg_Panel.Controls.Find(($"qtytxt{f}_" & index), True).First, TXT)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Idx(sender As Object) As Integer
        Try
            Return sender.Name.Split("_")(1)
        Catch ex As Exception

        End Try
    End Function
    Public Function find_stock_lab(index As Integer, isSource As Boolean) As Label
        Dim f As String
        If isSource = True Then
            f = "S"
        Else
            f = "P"
        End If
        Try
            Return CType(bg_Panel.Controls.Find(($"stock{f}_" & index), True).First, Label)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_godown_YN_Label(index As Integer, isSource As Boolean) As Label
        Dim f As String
        If isSource = True Then
            f = "S"
        Else
            f = "P"
        End If
        Try
            Return CType(bg_Panel.Controls.Find(($"godownyn{f}_" & index), True).First, Label)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Batch_YN_Label(index As Integer, isSource As Boolean) As Label
        Dim f As String
        If isSource = True Then
            f = "S"
        Else
            f = "P"
        End If
        Try
            Return CType(bg_Panel.Controls.Find(($"batchyn{f}_" & index), True).First, Label)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_mfg_YN_Label(index As Integer, isSource As Boolean) As Label
        Dim f As String
        If isSource = True Then
            f = "S"
        Else
            f = "P"
        End If
        Try
            Return CType(bg_Panel.Controls.Find(($"mfgyn{f}_" & index), True).First, Label)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_exp_YN_Label(index As Integer, isSource As Boolean) As Label
        Dim f As String
        If isSource = True Then
            f = "S"
        Else
            f = "P"
        End If
        Try
            Return CType(bg_Panel.Controls.Find(($"expyn{f}_" & index), True).First, Label)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Other_data(index As Integer, isSource As Boolean) As Label
        Dim f As String
        If isSource = True Then
            f = "S"
        Else
            f = "P"
        End If
        Try
            Return CType(bg_Panel.Controls.Find(($"otherdata{f}_" & index), True).First, Label)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Unit1_Label(index As Integer, isSource As Boolean) As Label
        Dim f As String
        If isSource = True Then
            f = "S"
        Else
            f = "P"
        End If
        Try
            Return CType(bg_Panel.Controls.Find(($"unit11lab{f}_" & index), True).First, Label)
        Catch ex As Exception

        End Try
    End Function
    Public Function find_decimal_lab(index As Integer, isSource As Boolean) As Label
        Dim f As String
        If isSource = True Then
            f = "S"
        Else
            f = "P"
        End If
        Try
            Return CType(bg_Panel.Controls.Find(($"decimal{f}_" & index), True).First, Label)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Unit2_Label(index As Integer, isSource As Boolean) As Label
        Dim f As String
        If isSource = True Then
            f = "S"
        Else
            f = "P"
        End If
        Try
            Return CType(bg_Panel.Controls.Find(($"unit22lab{f}_" & index), True).First, Label)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Unit1_Value(index As Integer, isSource As Boolean) As Label
        Dim f As String
        If isSource = True Then
            f = "S"
        Else
            f = "P"
        End If
        Try
            Return CType(bg_Panel.Controls.Find(($"unit1vlulab{f}_" & index), True).First, Label)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Unit2_Value(index As Integer, isSource As Boolean) As Label
        Dim f As String
        If isSource = True Then
            f = "S"
        Else
            f = "P"
        End If
        Try
            Return CType(bg_Panel.Controls.Find(($"unit2vlulab{f}_" & index), True).First, Label)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Qty1(index As Integer, isSource As Boolean) As Label
        Dim f As String
        If isSource = True Then
            f = "S"
        Else
            f = "P"
        End If
        Try
            Return CType(bg_Panel.Controls.Find(($"qty1{f}_" & index), True).First, Label)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Qty2(index As Integer, isSource As Boolean) As Label
        Dim f As String
        If isSource = True Then
            f = "S"
        Else
            f = "P"
        End If
        Try
            Return CType(bg_Panel.Controls.Find(($"qty2{f}_" & index), True).First, Label)
        Catch ex As Exception

        End Try
    End Function


    Private Sub bg_panel_Enter_S(sender As Object, e As EventArgs)
        Dim col As Color = Color.FromArgb(253, 233, 180)
        sender.BackColor = col
        Dim idx As Integer = Find_Idx(sender)

        Find_Particuls_TXT(idx, True).Back_color = col
        Find_qty_TXT(idx, True).Back_color = col

        Find_unit_lab(idx, True).BackColor = col
        Find_Particuls_TXT(idx, True).BackColor = col
        Find_qty_TXT(idx, True).BackColor = col

    End Sub
    Private Sub bg_panel_Leave_S(sender As Object, e As EventArgs)
        Dim col As Color = Source_P.BackColor
        sender.BackColor = col

        Dim idx As Integer = Find_Idx(sender)
        Find_Particuls_TXT(idx, True).Back_color = col
        Find_qty_TXT(idx, True).Back_color = col

        Find_unit_lab(idx, True).BackColor = col
        Find_Particuls_TXT(idx, True).BackColor = col
        Find_qty_TXT(idx, True).BackColor = col
    End Sub
    Private Sub bg_panel_Enter_P(sender As Object, e As EventArgs)
        Dim col As Color = Color.FromArgb(253, 233, 180)
        sender.BackColor = col
        Dim idx As Integer = Find_Idx(sender)

        Find_Particuls_TXT(idx, False).Back_color = col
        Find_qty_TXT(idx, False).Back_color = col

        Find_unit_lab(idx, False).BackColor = col
        Find_Particuls_TXT(idx, False).BackColor = col
        Find_qty_TXT(idx, False).BackColor = col

    End Sub
    Private Sub bg_panel_Leave_P(sender As Object, e As EventArgs)
        Dim col As Color = Source_P.BackColor
        sender.BackColor = col

        Dim idx As Integer = Find_Idx(sender)
        Find_Particuls_TXT(idx, False).Back_color = col
        Find_qty_TXT(idx, False).Back_color = col

        Find_unit_lab(idx, False).BackColor = col
        Find_Particuls_TXT(idx, False).BackColor = col
        Find_qty_TXT(idx, False).BackColor = col
    End Sub

    Private Sub stock_journal_controls_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        Fill_data_source()
        Apply_cfg()
    End Sub

    Public Function Apply_cfg()
        Production_panel.Visible = Inventory_Vouchers_frm.cfg_YN_Stock_Journal_Production
    End Function

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Add_New_P()

    End Sub

    Private Sub Txt1_TextChanged(sender As Object, e As EventArgs) Handles Txt1.TextChanged

    End Sub
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
                Add_New_S()
                Find_Particuls_TXT(idx_S, True).Text = r("Item_Name").ToString
                Find_AccID_Label(idx_S, True).Text = r("Item").ToString
                Find_qty_TXT(idx_S, True).Text = Val(Val(r("Qty").ToString) / Val(production_Qty)) * Val(Txt3.Text)
                Find_unit_lab(idx_S, True).Text = (r("Unit").ToString)
                fill_balance_S(Find_Particuls_TXT(idx_S, True))
            End While
            cn.Close()

            Add_New_P()
            Find_Particuls_TXT(idx_P, False).Text = Txt1.Text
            Find_AccID_Label(idx_P, False).Text = production_it_id
            Find_qty_TXT(idx_P, False).Text = Val(Txt3.Text)
            Find_unit_lab(idx_P, False).Text = Label11.Text
            fill_balance_P(Find_Particuls_TXT(idx_P, False))
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
End Class
