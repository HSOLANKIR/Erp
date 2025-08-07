Imports System.Data.SQLite
Imports Tools

Public Class Batch_Item_ctrl
    Dim curr_count As Integer = 0
    Public Function Add_New()
        curr_count = platform.Controls.OfType(Of Panel).ToList.Count
        Dim bg_p As Panel = New Panel
        Dim particals_panel As Panel = New Panel
        Dim Balance_panel As Panel = New Panel

        'bgpanel_
        '
        bg_p.Controls.Add(particals_panel)
        bg_p.Controls.Add(Balance_panel)
        bg_p.Dock = DockStyle.Top
        bg_p.Location = New Point(0, 0)
        bg_p.Name = "bg_" & (curr_count + 1)
        bg_p.TabIndex = curr_count
        bg_p.Size = New Size(903, 35)

        Particuls_Panel_ctrl(particals_panel)
        Balance_Panel_ctrl(Balance_panel)

        platform.Controls.Add(bg_p)
        bg_p.BringToFront()
    End Function
    Private Function Balance_Panel_ctrl(Pan As Panel)
        Dim bal_lab As Label = New Label
        Dim unit2_lab As Label = New Label
        'Dim null1_lab As Label = New Label
        'Dim null2_lab As Label = New Label

        'balancepan_
        '
        Pan.Controls.Add(bal_lab)
        Pan.Controls.Add(unit2_lab)
        'Pan.Controls.Add(null1_lab)
        'Pan.Controls.Add(null2_lab)
        Pan.Dock = DockStyle.Top
        Pan.Location = New Point(0, 19)
        Pan.Name = "balancepan_" & (curr_count + 1)
        Pan.Size = New Size(903, 15)
        Pan.TabIndex = 1
        Pan.BringToFront()


        'ballab_
        '
        bal_lab.Dock = DockStyle.Fill
        bal_lab.Font = New Font("Arial", 10, FontStyle.Italic, GraphicsUnit.Point, CType(0, Byte))
        bal_lab.Location = New Point(0, 0)
        bal_lab.Name = "ballab_" & (curr_count + 1)
        bal_lab.Padding = New Padding(30, 0, 0, 0)
        bal_lab.Size = New Size(512, 15)
        bal_lab.TabIndex = 11
        bal_lab.Text = ""
        bal_lab.TextAlign = ContentAlignment.MiddleLeft
        bal_lab.ForeColor = Color.DimGray

        'unit2lab_
        '
        unit2_lab.Dock = DockStyle.Right
        unit2_lab.Font = New Font("Arial", 10, FontStyle.Italic, GraphicsUnit.Point, CType(0, Byte))
        unit2_lab.Location = New Point(512, 0)
        unit2_lab.Name = "unit2lab_" & (curr_count + 1)
        unit2_lab.Size = New Size(171, 15)
        unit2_lab.TabIndex = 10
        unit2_lab.Text = ""
        unit2_lab.TextAlign = ContentAlignment.MiddleCenter

    End Function
    Private Function Particuls_Panel_ctrl(Pan As Panel)
        Dim particuls_txt As TXT = New TXT
        Dim qty_txt As TXT = New TXT
        Dim unit_lab As Label = New Label

        Dim batch_lab As Label = New Label
        Dim expiry As Label = New Label
        Dim mfg As Label = New Label
        Dim catagory As Label = New Label

        Dim acc_id As Label = New Label
        Dim unit_1 As Label = New Label
        Dim unit_2 As Label = New Label
        Dim unti_decimal As Label = New Label

        Dim stock_ As Label = New Label

        'particulspanel_
        '
        Pan.Controls.Add(particuls_txt)
        Pan.Controls.Add(qty_txt)
        Pan.Controls.Add(unit_lab)

        Pan.Controls.Add(batch_lab)
        Pan.Controls.Add(expiry)
        Pan.Controls.Add(mfg)
        Pan.Controls.Add(catagory)

        Pan.Controls.Add(acc_id)
        Pan.Controls.Add(unit_1)
        Pan.Controls.Add(unit_2)
        Pan.Controls.Add(unti_decimal)
        Pan.Controls.Add(stock_)

        Pan.Dock = DockStyle.Top
        Pan.Location = New Point(0, 0)
        Pan.Name = "particulspanel_" & (curr_count + 1)
        Pan.Size = New Size(903, 15)
        Pan.TabIndex = 0
        Pan.BackColor = Color.White
        Pan.Padding = New Padding(10, 0, 10, 0)

        AddHandler Pan.Enter, AddressOf bg_panel_Enter
        AddHandler Pan.Leave, AddressOf bg_panel_Leave

        'Acc_ID
        acc_id.Name = "AccID_" & (curr_count + 1)
        acc_id.Visible = False
        'Unit1
        unit_1.Name = "unit11lab_" & (curr_count + 1)
        unit_1.Visible = False
        'Unit2
        unit_2.Name = "unit22lab_" & (curr_count + 1)
        unit_2.Visible = False
        'Decimal
        unti_decimal.Name = "decimal_" & (curr_count + 1)
        unti_decimal.Visible = False
        'Stock
        stock_.Name = "stock_" & (curr_count + 1)
        stock_.Visible = False

        'particulstxt_
        '
        particuls_txt.Back_color = Color.White
        particuls_txt.BackColor = Color.White
        particuls_txt.BorderStyle = BorderStyle.None
        particuls_txt.Data_Link_ = ""
        particuls_txt.Dock = DockStyle.Fill
        particuls_txt.Font = New Font("Arial", 10.0, FontStyle.Bold)
        particuls_txt.Keydown_Support = True
        particuls_txt.Location = New Point(0, 0)
        particuls_txt.Name = "particulstxt_" & (curr_count + 1)
        particuls_txt.Size = New Size(512, 17)
        particuls_txt.TabIndex = 0
        particuls_txt.Type_ = "Select"
        particuls_txt.Select_Source = BindingSource1
        particuls_txt.Select_Column_Color = 5
        particuls_txt.Select_Auto_Show = False
        particuls_txt.Select_Filter = "(Name Like '%<value>%' or Alias LIKE '%<value>%') or (Name = 'End of List')"
        particuls_txt.Select_Columns = 0

        List_set(particuls_txt)

        AddHandler particuls_txt.LostFocus, AddressOf Particuls_LostFocus


        'qtytxt_
        '
        qty_txt.Back_color = Color.White
        qty_txt.BackColor = Color.White
        qty_txt.BorderStyle = BorderStyle.None
        qty_txt.Data_Link_ = ""
        qty_txt.Dock = DockStyle.Right
        qty_txt.Font = New Font("Arial", 10.0, FontStyle.Bold)
        qty_txt.Keydown_Support = False
        qty_txt.Location = New Point(512, 0)
        qty_txt.Name = "qtytxt_" & (curr_count + 1)
        qty_txt.Size = New Size(80, 17)
        qty_txt.TabIndex = 1
        qty_txt.TextAlign = HorizontalAlignment.Right
        qty_txt.Type_ = "Num"

        AddHandler qty_txt.KeyDown, AddressOf qty_Keydown
        AddHandler qty_txt.LostFocus, AddressOf qty_LostFocus


        'Label4
        '
        unit_lab.Dock = DockStyle.Right
        unit_lab.Font = New Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        unit_lab.Location = New Point(592, 0)
        unit_lab.Name = "unitlab_" & (curr_count + 1)
        unit_lab.Size = New Size(91, 19)
        unit_lab.TabIndex = 2
        unit_lab.Text = ""
        unit_lab.BackColor = Color.White


        'Other Details
        'Batch Label
        batch_lab.Font = New Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        batch_lab.Location = New Point(592, 0)
        batch_lab.Name = "batchno_" & (curr_count + 1)
        batch_lab.Visible = False
        batch_lab.Text = ""

        'expiry Label
        expiry.Font = New Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        expiry.Location = New Point(592, 0)
        expiry.Name = "expiry_" & (curr_count + 1)
        expiry.Visible = False
        expiry.Text = ""

        'mfg Label
        mfg.Font = New Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        mfg.Location = New Point(592, 0)
        mfg.Name = "mfg_" & (curr_count + 1)
        mfg.Visible = False
        mfg.Text = ""

        'catagory Label
        catagory.Font = New Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        catagory.Location = New Point(592, 0)
        catagory.Name = "catagory_" & (curr_count + 1)
        catagory.Visible = False
        catagory.Text = ""

    End Function
    Public Batch_list_Data_idx As Integer

    Private Sub bg_panel_Enter(sender As Object, e As EventArgs)
        Dim col As Color = Color.FromArgb(254, 197, 48)
        sender.BackColor = col
        Dim idx As Integer = Find_Idx(sender)

        Find_Particuls_TXT(idx).Back_color = col
        Find_qty_TXT(idx).Back_color = col

        Find_unit_lab(idx).BackColor = col
        Find_Particuls_TXT(idx).BackColor = col
        Find_qty_TXT(idx).BackColor = col
    End Sub
    Private Sub bg_panel_Leave(sender As Object, e As EventArgs)
        Dim col As Color = platform.BackColor
        sender.BackColor = col

        Dim idx As Integer = Find_Idx(sender)
        Find_Particuls_TXT(idx).Back_color = col
        Find_qty_TXT(idx).Back_color = col

        Find_unit_lab(idx).BackColor = col
        Find_Particuls_TXT(idx).BackColor = col
        Find_qty_TXT(idx).BackColor = col
    End Sub
    Public Function Save_data()
        Dim P_ As New Queue(Of Panel)()
        For Each bg_p As Panel In platform.Controls.OfType(Of Panel)()
            If Chack_Duplicate(Database_File.cre, "TBL_Stock_Item", "Name", $"Name = '{Find_Particuls_TXT(Find_Idx(bg_p)).Text}'") = False Then
                platform.Controls.Remove(bg_p)
            End If
        Next

        For Each bg_p As Panel In platform.Controls.OfType(Of Panel)()
            P_.Enqueue(bg_p)
        Next
        Dim data_ As String = "<Details>"
        For Each bg_p As Panel In P_.Reverse
            Dim idx As Integer = Find_Idx(bg_p)

            data_ &= $"<BOM><Batch>{Batch_LAB.Text}</Batch>
<Item>{Find_AccID_Label(idx).Text}</Item>
<Qty>{Val(Find_qty_TXT(idx).Text)}</Qty>
</BOM>"

        Next
        data_ &= "</Details>"


        With Inventory_BOM.Batch_ctrl1
            .Find_Data_Lab(Batch_list_Data_idx).Text = data_
            .Find_Production_Qty_Lab(Batch_list_Data_idx).Text = Val(Txt1.Text)
        End With
        'Batch_list_Data_Obj = Batch_LAB

    End Function

    Private Sub qty_LostFocus(sender As Object, e As EventArgs)
        Find_unit1_lab(Find_Idx(sender)).Text = Find_alter_unit_vlu(Find_AccID_Label(Find_Idx(sender)).Text, Val(Find_qty_TXT(Find_Idx(sender)).Text), False, False, True)
    End Sub
    Private Sub qty_Keydown(sender As Object, e As KeyEventArgs)
        Dim index As Integer = Find_Idx(sender)

        'amt_vlu(sender)
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
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
            If platform.Controls.Count = index Then
                Add_New()
            End If
        End If
    End Sub
    Private Sub Particuls_LostFocus(sender As Object, e As EventArgs)
        BindingSource1.MoveFirst()

        Dim TX_ As TXT = CType(sender, TXT)
        Dim index As Integer = Integer.Parse(TX_.Name.Split("_")(1))

        If Find_Particuls_TXT(Find_Idx(sender)).Text = "End of List" Then
            Find_qty_TXT(index).Text = ""
            Find_qty_TXT(index).Enabled = False
            sender.Enabled = False

            If platform.Controls.Count = Find_Idx(sender) Then
                Save_data()
                Inventory_BOM.ctrl_manag("List")
                Inventory_BOM.List_Focus_value(Batch_list_Data_idx, True)
            End If
            Exit Sub
        Else
            Find_qty_TXT(index).Enabled = True
        End If

        If Find_Particuls_TXT(Find_Idx(sender)).Text.Trim <> Nothing Then

            Find_AccID_Label(Find_Idx(sender)).Text = Find_DT_Value(Database_File.cre, "TBL_Stock_Item", "ID", "Name = '" & sender.Text & "'")

            Dim unit As String = Find_DT_Unit_Conves(Find_DT_Value(Database_File.cre, "TBL_Stock_Item", "Unit", "ID = '" & Find_AccID_Label(Find_Idx(sender)).Text & "'"))

            Find_Unit1_Label(Find_Idx(sender)).Text = unit

            find_decimal_lab(Find_Idx(sender)).Text = Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "Decimal", "ID = '" & unit & "'")

            unit = Find_DT_Value(Database_File.cre, "TBL_Stock_Item", "Alter_Unit", "ID = '" & Find_AccID_Label(Find_Idx(sender)).Text & "'")

            Find_Unit2_Label(Find_Idx(sender)).Text = unit
            Find_unit_lab(Find_Idx(sender)).Text = Find_Unit1_Label(Find_Idx(sender)).Text

            Find_unit1_lab(Find_Idx(sender)).Text = Find_alter_unit_vlu(Find_AccID_Label(Find_Idx(sender)).Text, Val(Find_qty_TXT(Find_Idx(sender)).Text), False, False, True)
        End If
    End Sub
    Private Sub Batch_Item_ctrl_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Function Qry_Filters() As String
        Dim q As String = ""
        q &= $" and (vc.Visible = 'Approval')"
        q &= $" and (vc.[Date] <= '{CDate(Date_3).AddDays(1).ToString(Lite_date_Format)}')"
        If Dft_Branch <> "Primary" Then
            q &= " AND VC.Branch = '" & Find_DT_Value(Database_File.cre, "TBL_Ledger", "ID", "Name = '" & Dft_Branch & "'") & "'"
        End If
        Return q
    End Function
    Dim it_list As List_frm
    Private Function List_set(sender As Object)
        it_list = New List_frm
        it_list.Name = "List_" & sender.Text.ToString.Split("_").Last
        List_Setup("List of Stock Items", Select_List.Right_Dock, Select_List_Format.Defolt, sender, it_list, BindingSource1, 350)
    End Function
    Private Function Fill_data_source()
        Dim Positive As String = Find_DT_Value(Database_File.cmp, "TBL_Features", "Value", "Head = 'Positive Value'")
        Dim Negative As String = Find_DT_Value(Database_File.cmp, "TBL_Features", "Value", "Head = 'Negative Value'")

        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            'Item Source Fill Data
            Dim dt_itm As New DataTable
            dt_itm.Columns.Add("Name")
            dt_itm.Columns.Add("Group")
            dt_itm.Columns.Add("ID")
            dt_itm.Columns.Add("Alias")

            dt_itm.Rows.Add("End of List")

            cmd = New SQLiteCommand($"Select itm.id,itm.name,itm.Alias,(Select sg.name From TBL_Stock_Group sg where sg.id = itm.Under) as Under,(Select u.Symbol From TBL_Inventory_Unit u where u.id = itm.Unit) as Unit From TBL_Stock_Item itm where itm.Visible = 'Approval' and itm.id <> '{Inventory_BOM.VC_ID_}'", cn)

            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            Dim dr As DataRow
            While r.Read
                dr = dt_itm.NewRow
                dr("ID") = r("ID")
                dr("Name") = r("Name")
                dr("Alias") = r("Alias")

                If r("Under").ToString = Nothing Then
                    dr("Group") = "Primary"
                Else
                    dr("Group") = r("Under")
                End If

                dt_itm.Rows.Add(dr)
            End While
            r.Close()
            BindingSource1.DataSource = dt_itm

        End If
    End Function
    Public Function Find_Particuls_Panel(index As Integer) As Panel
        Try
            Return CType(platform.Controls.Find(("Particulspanel_" & index), True).First, Panel)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_list_frm(index As Integer) As List_frm
        Try
            Return CType(platform.Controls.Find(("List_" & index), True).First, List_frm)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_AccID_Label(index As Integer) As Label
        Try
            Return CType(platform.Controls.Find(("AccID_" & index), True).First, Label)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Unit1_Label(index As Integer) As Label
        Try
            Return CType(platform.Controls.Find(("unit11lab_" & index), True).First, Label)
        Catch ex As Exception

        End Try
    End Function

    Public Function Find_Unit2_Label(index As Integer) As Label
        Try
            Return CType(platform.Controls.Find(("unit22lab_" & index), True).First, Label)
        Catch ex As Exception

        End Try
    End Function
    Public Function find_decimal_lab(index As Integer) As Label
        Try
            Return CType(platform.Controls.Find(("decimal_" & index), True).First, Label)
        Catch ex As Exception

        End Try
    End Function
    Public Function find_stock_lab(index As Integer) As Label
        Try
            Return CType(platform.Controls.Find(("stock_" & index), True).First, Label)
        Catch ex As Exception

        End Try
    End Function

    Public Function Find_Particuls_TXT(index As Integer) As TXT
        Try
            Return CType(platform.Controls.Find(("Particulstxt_" & index), True).First, TXT)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_qty_TXT(index As Integer) As TXT
        Try
            Return CType(platform.Controls.Find(("qtytxt_" & index), True).First, TXT)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_unit_lab(index As Integer) As Label
        Try
            Return CType(platform.Controls.Find(("unitlab_" & index), True).First, Label)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_lab_lab(index As Integer) As Label
        Try
            Return CType(platform.Controls.Find(("ballab_" & index), True).First, Label)
        Catch ex As Exception

        End Try
    End Function

    Public Function Find_unit1_lab(index As Integer) As Label
        Try
            Return CType(platform.Controls.Find(("unit2lab_" & index), True).First, Label)
        Catch ex As Exception

        End Try
    End Function

    Public Function Find_batchNo_lab(index As Integer) As Label
        Try
            Return CType(platform.Controls.Find(("batchno_" & index), True).First, Label)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_expiry_lab(index As Integer) As Label
        Try
            Return CType(platform.Controls.Find(("expiry_" & index), True).First, Label)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_mfg_lab(index As Integer) As Label
        Try
            Return CType(platform.Controls.Find(("mfg_" & index), True).First, Label)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_catagory_lab(index As Integer) As Label
        Try
            Return CType(platform.Controls.Find(("catagory_" & index), True).First, Label)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_gstpanel_pan(index As Integer) As Panel
        Try
            Return CType(platform.Controls.Find(("gstpanel_" & index), True).First, Panel)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_bg_pan(index As Integer) As Panel
        Try
            Return CType(platform.Controls.Find(("bg_" & index), True).First, Panel)
        Catch ex As Exception

        End Try
    End Function

    Public Function Find_Idx(sender As Object) As Integer
        Try
            Return sender.Name.Split("_")(1)
        Catch ex As Exception

        End Try
    End Function

    Private Sub Batch_Item_ctrl_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        Fill_data_source()
    End Sub

    Private Sub Txt1_TextChanged(sender As Object, e As EventArgs) Handles Txt1.TextChanged
        If Val(Txt1.Text) <= 0 Then
            platform.Enabled = False
        Else
            platform.Enabled = True
        End If
    End Sub
End Class
