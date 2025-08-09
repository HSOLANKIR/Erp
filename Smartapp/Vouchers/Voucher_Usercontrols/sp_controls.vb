Imports System.Data.SQLite
Imports System.Security.Cryptography
Imports Management.All_Message_And_Text
Imports PopupControl
Imports Tools
Public Class sp_controls
    Public GST_YN As Boolean = False
    Public TAX_Type As String
    Public Enable_Expance As Boolean = True
    Private Sub sp_controls_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Fill_data_source()
        List_set()
    End Sub
    Private Function Qry_Filters() As String
        Dim q As String = ""

        With Inventory_Vouchers_frm
            q &= $" and (vc.Visible = 'Approval')"
            q &= $" and (vc.[Date] <= '{CDate(Inventory_Vouchers_frm.Date_TXT.Text).AddDays(1).ToString(Lite_date_Format)}')"
            If Dft_Branch <> "Primary" Then
                q &= " AND VC.Branch = '" & Find_DT_Value(Database_File.cre, "TBL_Ledger", "ID", "Name = '" & Dft_Branch & "'") & "'"
            End If
            If .VC_Type_ = "Alter" Or .VC_Type_ = "Alter_Close" Then
                q &= $" and (vc.Tra_ID <> '{Inventory_Vouchers_frm.Tra_ID}')"
            End If
        End With
        Return q
    End Function
    Dim dt_item As New DataTable
    Dim dt_exp As New DataTable

    Public Function Fill_Item_data(ifstart As Boolean)
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

            If ifstart = False Then
                dt_item.Rows.Add("End of List", "")
            End If


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
            BindingSource1.DataSource = dt_item

        End If
    End Function
    Private Function Fill_data_source()

        'Fill_Item_data(True)

        Dim cn As New SQLiteConnection
        Dim r As SQLiteDataReader

        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            dt_exp = New DataTable
            dt_exp.Columns.Clear()
            dt_exp.Columns.Add("Name")
            dt_exp.Columns.Add("Group")
            dt_exp.Columns.Add("ID")
            dt_exp.Columns.Add("Alias")

            dt_exp.Rows.Add("", "Create")
            dt_exp.Rows.Add("End of List", "")

            cmd = New SQLiteCommand($"Select [ID],[Name],(Select ag.Name From TBL_Acc_Group ag where ag.id = ld.[Group]) as Group_Name,[Alise],[Cradit]
from TBL_Ledger LD where ([Group] = '13' or [Group] = '15')", cn)

            With cmd.Parameters
                .AddWithValue("@Filter_Date", CDate(Inventory_Vouchers_frm.Date_TXT.Text).AddDays(1).ToString(Lite_date_Format))

                r = cmd.ExecuteReader

                While r.Read
                    dt_exp.Rows.Add(r("Name").ToString, r("Group_Name").ToString, r("ID"), r("Alise").ToString)
                End While
            End With
            r.Close()
            BindingSource2.DataSource = dt_exp
        End If


        If Inventory_Vouchers_frm.VC_Formate = "Sales" Then
            Dim dt_so As New DataTable
            dt_so.Columns.Add("Name")
            dt_so.Rows.Add("Outward Register")
            dt_so.Rows.Add("Sales")
            Stock_as_per_Source.DataSource = dt_so
        ElseIf Inventory_Vouchers_frm.VC_Formate = "Purchase" Then
            Dim dt_so As New DataTable
            dt_so.Columns.Add("Name")
            dt_so.Rows.Add("Inward Register")
            dt_so.Rows.Add("Purchase")
            Stock_as_per_Source.DataSource = dt_so
        Else
            Dim dt_so As New DataTable
            dt_so.Columns.Add("Name")
            dt_so.Rows.Add("NA")
            Stock_as_per_Source.DataSource = dt_so
        End If

    End Function

    Dim curr_count As Integer = 0
    Dim curr_count_exp As Integer = 0
    Public Function Add_New_exp(typ As String, rounding_type As String, rounding_limit As Integer)
        curr_count_exp = exp_panel.Controls.OfType(Of Panel).ToList.Count
        Dim bg_p As Panel = New Panel
        Dim particals_panel As Panel = New Panel
        Dim Balance_panel As Panel = New Panel

        'exp_
        '
        bg_p.Controls.Add(particals_panel)
        bg_p.Dock = DockStyle.Top
        bg_p.Location = New Point(0, 0)
        bg_p.Name = "exp_" & (curr_count_exp + 1)
        bg_p.Size = New Size(903, 20)
        bg_p.TabIndex = curr_count_exp
        bg_p.Visible = True
        bg_p.AutoSize = True
        bg_p.Padding = New Padding(0, 5, 0, 0)
        bg_p.Tag = typ.ToString

        Particuls_Panel_exp_ctrl(particals_panel, typ, rounding_type, rounding_limit)

        exp_panel.Controls.Add(bg_p)
        bg_p.BringToFront()

        List_set_exp((curr_count_exp + 1))
    End Function


    Private Function Particuls_Panel_exp_ctrl(sender As Panel, typ As String, rounding_type As String, rounding_limit As Integer)
        Dim particuls_txt As TXT = New TXT
        Dim rate_txt As TXT = New TXT
        Dim per_ As Label = New Label
        Dim Amt_txt As TXT = New TXT
        Dim Rounding_Methoud As Label = New Label

        'expparticuls_pan
        '
        With sender
            .Controls.Add(particuls_txt)
            .Controls.Add(rate_txt)
            .Controls.Add(per_)
            .Controls.Add(Amt_txt)
            .Controls.Add(Rounding_Methoud)

            .Dock = DockStyle.Top
            .Location = New Point(0, 0)
            .Name = "expparticulspan_" & (curr_count_exp + 1)
            .Size = New Size(903, 16)
            .TabIndex = 1
            .BackColor = Color_bg
            .Visible = True

            AddHandler .Enter, AddressOf exp_panel_Enter
            AddHandler .Leave, AddressOf exp_panel_Leave
        End With

        With Rounding_Methoud
            .Name = "Rounding_" & (curr_count_exp + 1)
            .Visible = False
            .Text = rounding_type
            .Tag = Val(rounding_limit)
        End With

        'exp_txt
        '
        With particuls_txt
            .Back_color = Color_bg
            .BackColor = Color_bg
            .BorderStyle = BorderStyle.None
            .Data_Link_ = ""
            .Decimal_ = 2
            .Dock = DockStyle.Left
            .Font = New Font("Arial", 10.0, FontStyle.Bold)
            .Keydown_Support = True
            .Location = New Point(0, 0)
            .Name = "exptxt_" & (curr_count_exp + 1)
            .Size = New Size(300, 17)
            .TabIndex = 0
            .Type_ = "Select"
            .Select_Filter = "(Name LIKE '%<value>%' or Alias LIKE '%<value>%') or (Name = 'End of List') or (Group = 'Create')"
            .Select_Columns = 0
            .Enabled = Enable_Expance

            AddHandler .Enter, AddressOf Balance_Enter_exp
            AddHandler .KeyDown, AddressOf exp_Keydown
            AddHandler .LostFocus, AddressOf exp_Lostfocus_exp
        End With



        'expper_txt
        '
        With rate_txt
            .Back_color = Color_bg
            .BackColor = Color_bg
            .BorderStyle = BorderStyle.None
            .Data_Link_ = ""
            .Decimal_ = 2
            .Dock = DockStyle.Right
            .Font = New Font("Arial", 10.0, FontStyle.Bold)
            .Keydown_Support = True
            .Location = New Point(683, 0)
            .Name = "expratetxt_" & (curr_count_exp + 1)
            .Size = New Size(40, 17)
            .TabIndex = 2
            .TextAlign = HorizontalAlignment.Right
            .Type_ = "TXT"

            If typ = "User Defined Value" Then
                .Enabled = True
            Else
                .Enabled = False
            End If

            AddHandler .Enter, AddressOf Balance_Enter_exp
            AddHandler .LostFocus, AddressOf Balance_LostFocus_exp
            AddHandler .KeyDown, AddressOf Rate_KeyDown_exp
        End With

        'Label6
        '
        With per_
            .Dock = DockStyle.Right
            .Font = New Font("Arial", 10.0, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
            .Location = New Point(759, 0)
            .Name = "expper_" & (curr_count_exp + 1)
            .Size = New Size(22, 19)
            .TabIndex = 10
            .TextAlign = ContentAlignment.MiddleRight

            If typ = "User Defined Value" Then
                .Text = "%"
            Else
                .Text = ""
            End If
        End With

        'expamt_txt
        '
        With Amt_txt
            .Back_color = Color_bg
            .BackColor = Color_bg
            .BorderStyle = BorderStyle.None
            .Data_Link_ = ""
            .Decimal_ = 2
            .Dock = DockStyle.Right
            .Font = New Font("Arial", 10.0, FontStyle.Bold)
            .Keydown_Support = False
            .Location = New Point(783, 0)
            .Name = "expamttxt_" & (curr_count_exp + 1)
            .Size = New Size(120, 17)
            .TabIndex = 3
            .TextAlign = HorizontalAlignment.Right
            .Type_ = "TXT"
            Exp_TXT_Arrya.Add(Amt_txt)

            If typ = "User Defined Value" Then
                .Enabled = True
            Else
                .Enabled = False
            End If

            AddHandler .Enter, AddressOf Balance_Enter_exp
            AddHandler .LostFocus, AddressOf amt_Lostfocus_exp
            AddHandler .KeyDown, AddressOf Amt_Keydown_exp
            AddHandler .TextChanged, AddressOf amt_Textchange

        End With

    End Function
    Public Function Refresh_cfg()
        TAX_Type = Inventory_Vouchers_frm.TAX_Type
        GST_YN = YN_Boolean(Inventory_Vouchers_frm.cfg_YN_GST)

        With Inventory_Vouchers_frm
            If .cfg_Roud_Up = "Not Applicable" Then
                roundup_Panel.Visible = False
            Else
                roundup_Panel.Visible = True
            End If
            GST_Panel.Visible = GST_YN
            Cess_Panel.Visible = GST_YN
        End With
        'Panel32.Height = (Val(Val(Panel31.Controls.OfType(Of Panel).Count) * 17) + 10)

        Me.BackColor = Color_bg
    End Function
    Public Function Add_New() As sp_control_under
        Refresh_cfg()
        Dim c As New sp_control_under
        With c
            .Obj = Me
            stock_panel.Controls.Add(c)
            .Dock = DockStyle.Top
            .BringToFront()
            .Me__Control_ID = stock_panel.Controls.OfType(Of sp_control_under).ToList.Count
            .Set_Object_()
            .List_set()
        End With
        curr_count = stock_panel.Controls.OfType(Of sp_control_under).ToList.Count
        If curr_count = 1 Then
            Fill_Item_data(False)
        End If

        Return c
    End Function
    Public Color_bg As Color
    Public Function Color_manag()
        Me.BackColor = Color_bg

    End Function

    Dim it_list As List_frm
    Dim Order_Type_list As List_frm
    Public Function List_set()
        Order_Type_list = New List_frm
        List_Setup("Type of List", Select_List.Right, Select_List_Format.Singel, Txt1, Order_Type_list, Stock_as_per_Source, 150)
    End Function
    Dim exp_list As List_frm
    Private Function List_set_exp(idx As Integer)
        Dim exp As TXT = Find_exp_TXT(idx)

        exp_list = New List_frm
        List_Setup("List of Ledger", Select_List.Right, Select_List_Format.Defolt, exp, exp_list, BindingSource2, 400)
        exp_list.System_Data_integer = 1
    End Function

    Private Sub Amt_Keydown_exp(sender As Object, e As KeyEventArgs)
        Dim TX_ As TXT = CType(sender, TXT)
        Dim index As Integer = Find_Idx(sender)

        If e.KeyCode = Keys.Enter Then
            If Val(sender.Text) = 0 Then
                e.SuppressKeyPress = True
                NOT_("Please enter value, and try again", NOT_Type.Warning)
                sender.Focus()
                sender.Text = ""
                Exit Sub
            End If
            NOT_Clear()
            If exp_panel.Controls.Count = index Then
                If Enable_Expance = True Then
                    Add_New_exp("User Defined Value", "Not Applicable", 0)
                End If
                'SendKeys.Send("{TAB}")
            Else
                'SendKeys.Send("{TAB}")
            End If
        Else
            'Find_exp_rate_TXT(Find_Idx(sender)).Text = ""
        End If
    End Sub
    Private Sub exp_Lostfocus_exp(sender As Object, e As EventArgs)
        BindingSource2.MoveFirst()
    End Sub
    Private Sub amt_Lostfocus_exp(sender As Object, e As EventArgs)
        SUM()
    End Sub
    Private Function rate_vlu_exp(sender As Object)
        If Val((Find_exp_rate_TXT(Find_Idx(sender)).Text)) <> 0 Then
            Find_exp_amt_TXT(Find_Idx(sender)).Text = (Val(Find_exp_rate_TXT(Find_Idx(sender)).Text) * Val(sub_total_label.Text)) / 100
            Find_exp_amt_TXT(Find_Idx(sender)).Text = nUmBeR_FORMATE(Find_exp_amt_TXT(Find_Idx(sender)).Text)
        End If
    End Function
    Private Sub Balance_LostFocus_exp(sender As Object, e As EventArgs)
        SUM()
    End Sub
    Private Sub Balance_Enter_exp(sender As Object, e As EventArgs)
        'rate_vlu_exp(sender)
    End Sub
    Private Sub Rate_KeyDown_exp(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            If Val(sender.Text) <> 0 Then
                Find_exp_amt_TXT(Find_Idx(sender)).Text = nUmBeR_FORMATE((Val(Find_exp_rate_TXT(Find_Idx(sender)).Text) * Val(sub_total_label.Text)) / 100)
            End If
        End If
    End Sub


    Public Amount_TXT_Arrya As New List(Of TXT)
    Public TAX_TXT_Arrya As New List(Of Label)
    Public Exp_TXT_Arrya As New List(Of TXT)
    Public qty_TXT_Arrya As New List(Of TXT)
    Public unit_TXT_Arrya As New List(Of TXT)
    Public gst_panel_Arrya As New List(Of Panel)
    Public gst_label_Arrya As New List(Of Label)
    Public cess_amt_Arrya As New List(Of Label)
    Public discount_txt_Arrya As New List(Of TXT)
    Public discount_amt_Arrya As New List(Of Label)

    Public Function Clear_All_SUM()
        Amount_TXT_Arrya.Clear()
        cess_amt_Arrya.Clear()
        TAX_TXT_Arrya.Clear()
        Exp_TXT_Arrya.Clear()
        qty_TXT_Arrya.Clear()
        unit_TXT_Arrya.Clear()
        gst_panel_Arrya.Clear()
        discount_txt_Arrya.Clear()
        gst_label_Arrya.Clear()

        sub_total_label.Text = "0"
        Label10.Text = "0"
        GST_Total.Text = "0"
        Cess_Total.Text = "0"
        amt_total_label.Text = "0"
        Amounr_Label.Text = "0"
        Vc_GST_summary_ctrl1.bg_panel.Controls.Clear()



    End Function
    Public Function SUM()
        Try
            Dim cl As Decimal = 0
            Array.ForEach(stock_panel.Controls.OfType(Of sp_control_under)().ToArray(),
              Sub(lbl) cl += Val(lbl.Amount_TXT.Text))
            sub_total_label.Text = nUmBeR_FORMATE(cl)

        Catch ex As Exception

        End Try

        Try

            Label10.Text = nUmBeR_FORMATE(Exp_TXT_Arrya.Sum(Function(m)
                                                                Return Val(m.Text)
                                                            End Function))
        Catch ex As Exception

        End Try

        Try
            If GST_YN = True Then
                Dim cl As Decimal = 0
                Array.ForEach(stock_panel.Controls.OfType(Of sp_control_under)().ToArray(),
              Sub(lbl) cl += lbl.GST_Amount)
                GST_Total.Text = nUmBeR_FORMATE(cl)
            Else
                GST_Total.Text = ""
            End If
        Catch ex As Exception

        End Try

        Try
            If GST_YN = True Then
                Dim cl As Decimal = 0
                Array.ForEach(stock_panel.Controls.OfType(Of sp_control_under)().ToArray(),
              Sub(lbl) cl += lbl.Cess_Amount)
                Cess_Total.Text = nUmBeR_FORMATE(cl)
            Else
                Cess_Total.Text = ""
            End If

        Catch ex As Exception

        End Try

        Try
            If Inventory_Vouchers_frm.cfg_Item_Discount = True Then
                Dim cl As Decimal = 0
                Array.ForEach(stock_panel.Controls.OfType(Of sp_control_under)().ToArray(),
              Sub(lbl) cl += Val(lbl.DiscountP_TXT.Data_Link_))
                Discount_Total_Label.Text = nUmBeR_FORMATE(cl)
            Else
                Discount_Total_Label.Text = ""
            End If

        Catch ex As Exception

        End Try


        amt_total_label.Text = nUmBeR_FORMATE((Val(sub_total_label.Text) + Val(Label10.Text)) + Val(Discount_Total_Label.Text))
        Dim amount_ As Decimal = SUBTotal_cal()

        amount_ -= Discount_cal()
        amount_ += GST_cal()
        amount_ += Cess_cal()
        amount_ += Round_up(amount_)

        Amounr_Label.Text = nUmBeR_FORMATE(amount_)
        Label8.Text = NumberToText(Val(amount_))

        Refresh_All()
        Amount_value_Change_Evant()
        Exp_Auto_Calculation()
        Inventory_Vouchers_frm.Chack_GSTR()
    End Function
    Private Function Exp_Auto_Calculation()
        'Add_New_exp()

        Dim all_ = GetAllControls(exp_panel).OfType(Of Panel)().ToList()
        all_.FindAll(Function(i)
                         Dim idx As Integer = Find_Idx(i)
                         If i.Tag = "Flat Rate" Then
                             Rounding_set(idx, Val(Find_exp_rate_TXT(idx).Text))
                         ElseIf i.Tag = "User Defined Value" Then
                             If Val(Find_exp_rate_TXT(idx).Text) <> 0 Then
                                 Rounding_set(idx, Val(Find_exp_rate_TXT(idx).Text) * Val(Find_exp_rate_TXT(idx).Text))
                             End If
                         ElseIf i.Tag = "Based on Quantity" Then
                             Dim Qty As Decimal = 0
                             Try
                                 Qty = Val(0)
                             Catch ex As Exception

                             End Try
                             Dim vlu As Decimal = (Val(Find_exp_rate_TXT(idx).Text) * Qty)
                             Rounding_set(idx, vlu)
                         ElseIf i.Tag = "Total Amount Rounding" Then
                             Dim vlu As Decimal = Val(sub_total_label.Text)
                             Try
                                 Dim P_ As New Queue(Of Panel)()
                                 For Each bg_p As Panel In exp_panel.Controls.OfType(Of Panel)()
                                     If Find_Idx(bg_p) < Find_Idx(i) Then
                                         P_.Enqueue(bg_p)
                                     End If
                                 Next
                                 For Each bg_p As Panel In P_.Reverse
                                     Dim id As Integer = Find_Idx(bg_p)
                                     vlu += Val(Find_exp_amt_TXT(id).Text)
                                 Next
                             Catch ex As Exception

                             End Try

                             Dim typ As Rounding_Type = Rounding_Type.Not_Applicable
                             If Find_Round_(idx).Text = "Not Applicable" Then typ = Rounding_Type.Not_Applicable
                             If Find_Round_(idx).Text = "Downward Rounding" Then typ = Rounding_Type.Down
                             If Find_Round_(idx).Text = "Upward Rounding" Then typ = Rounding_Type.Up
                             If Find_Round_(idx).Text = "Normal Rounding" Then typ = Rounding_Type.Normal

                             Dim Round As Decimal = nUmBeR_FORMATE(RoundNumber(typ, vlu, Find_Round_(idx).Tag))
                             Find_exp_amt_TXT(idx).Text = Round
                         ElseIf i.Tag = "Current SubTotal" Then
                             Dim vlu As Decimal = Val(sub_total_label.Text)
                             Try
                                 Dim P_ As New Queue(Of Panel)()
                                 For Each bg_p As Panel In exp_panel.Controls.OfType(Of Panel)()
                                     If Find_Idx(bg_p) < Find_Idx(i) Then
                                         P_.Enqueue(bg_p)
                                     End If
                                 Next
                                 For Each bg_p As Panel In P_.Reverse
                                     Dim id As Integer = Find_Idx(bg_p)
                                     vlu += Val(Find_exp_amt_TXT(id).Text)
                                 Next
                             Catch ex As Exception

                             End Try

                             vlu = nUmBeR_FORMATE(Val(Val(Find_exp_rate_TXT(idx).Text) * vlu) / 100)
                             Rounding_set(idx, vlu)
                         ElseIf i.Tag = "Total Amount" Then
                             Dim vlu As Decimal = Val(sub_total_label.Text)
                             vlu = nUmBeR_FORMATE(Val(Val(Find_exp_rate_TXT(idx).Text) * vlu) / 100)
                             Rounding_set(idx, vlu)
                         End If

                     End Function)

    End Function
    Private Function Rounding_set(idx As Integer, Vlu As Decimal)
        Dim typ As Rounding_Type = Rounding_Type.Not_Applicable
        If Find_Round_(idx).Text = "Not Applicable" Then typ = Rounding_Type.Not_Applicable
        If Find_Round_(idx).Text = "Downward Rounding" Then typ = Rounding_Type.Down
        If Find_Round_(idx).Text = "Upward Rounding" Then typ = Rounding_Type.Up
        If Find_Round_(idx).Text = "Normal Rounding" Then typ = Rounding_Type.Normal

        Dim Round As Decimal = nUmBeR_FORMATE(RoundNumber(typ, Vlu, Find_Round_(idx).Tag))
        Find_exp_amt_TXT(idx).Text = Val(Vlu) + Round
    End Function
    Private Function Refresh_All()

        Try
            Array.ForEach(stock_panel.Controls.OfType(Of sp_control_under)().ToArray(),
Sub(lbl) If GST_YN = True And lbl.GST_Enable = True Then lbl.GST_Panel.Visible = True Else lbl.GST_Panel.Visible = False
    )
        Catch ex As Exception

        End Try


        Try


            Array.ForEach(stock_panel.Controls.OfType(Of sp_control_under)().ToArray(),
Sub(lbl) If Inventory_Vouchers_frm.cfg_Item_Discount = True Then lbl.DiscountP_TXT.Visible = True Else lbl.DiscountP_TXT.Visible = False
    )


        Catch ex As Exception

        End Try


        If Inventory_Vouchers_frm.cfg_Item_Discount = True Then
            Head_Discount.Visible = True
            Discount_Panel.Visible = True
        Else
            Head_Discount.Visible = False
            Discount_Panel.Visible = False
        End If


        If GST_YN = True Then
            If TAX_Type = "CS" Then
                Array.ForEach(stock_panel.Controls.OfType(Of sp_control_under)().ToArray(),
              Sub(lbl) lbl.GSTType_Lab.Text = "CGST & SGST :")
            Else
                Array.ForEach(stock_panel.Controls.OfType(Of sp_control_under)().ToArray(),
              Sub(lbl) lbl.GSTType_Lab.Text = "IGST :")
            End If
        End If

    End Function
    Private Function Amount_value_Change_Evant()
        Try
            Inventory_Vouchers_frm.Closing_Balance_Set()
            With Inventory_Vouchers_frm
                If .cfg_YN_Ewaybill = True And Val(amt_total_label.Text) >= 50000 Then
                    .Other_Fechers_(True, .EwayBill_Panel)
                Else
                    .Other_Fechers_(False, .EwayBill_Panel)
                End If
            End With
        Catch ex As Exception

        End Try
    End Function
    Private Function SUBTotal_cal() As Decimal
        Return Val(nUmBeR_FORMATE(sub_total_label.Text) + nUmBeR_FORMATE(Label10.Text)) + nUmBeR_FORMATE(Discount_Total_Label.Text)
    End Function
    Private Function Discount_cal() As Decimal
        If Inventory_Vouchers_frm.cfg_Item_Discount = True Then
            Label19.Text = nUmBeR_FORMATE(nUmBeR_FORMATE(amt_total_label.Text) - nUmBeR_FORMATE(Discount_Total_Label.Text))
            Return nUmBeR_FORMATE(Discount_Total_Label.Text)
        Else
            Return nUmBeR_FORMATE(0)
        End If
    End Function
    Private Function GST_cal() As Decimal
        If GST_YN = True Then
            If TAX_Type = "CS" Then
                Label4.Text = "GST (C+S)"
            Else
                Label4.Text = "GST (I)"
            End If
            Label7.Text = $"{nUmBeR_FORMATE(GST_Total.Text)}₹"

            If nUmBeR_FORMATE(GST_Total.Text) = 0 Then
                Panel16.Visible = False
            Else
                Panel16.Visible = True
            End If

            Return Val(GST_Total.Text)
        Else
            Label7.Text = ""
            Panel16.Visible = False
            Return Val(0)
        End If
    End Function
    Private Function Cess_cal() As Decimal
        If GST_YN = True Then
            Label14.Text = nUmBeR_FORMATE(Cess_Total.Text) & "₹"
            If nUmBeR_FORMATE(Cess_Total.Text) = 0 Then
                Panel46.Visible = False
            Else
                Panel46.Visible = True
            End If
            Return Val(Cess_Total.Text)
        Else
            Panel46.Visible = False
            Return Val(0)
        End If
    End Function
    Private Function Round_up(amount_ As Decimal) As Decimal

        Dim round_amt As Decimal = 0
        roundup_val_Lab.Enabled = False
        With Inventory_Vouchers_frm
            If .cfg_Roud_Up <> "Not Applicable" Then
                If .cfg_Roud_Up = "Minimum" Then
                    amount_ = Math.Floor(Val(amount_))
                ElseIf .cfg_Roud_Up = "Manual" Then
                    roundup_val_Lab.Enabled = True
                    amount_ = Val(amount_) + Val(roundup_val_Lab.Text)
                ElseIf .cfg_Roud_Up = "Normal" Then
                    amount_ = Math.Round(Val(amount_))
                ElseIf .cfg_Roud_Up = "Maximum" Then
                    amount_ = Math.Ceiling(Val(amount_))
                End If

                If .cfg_Roud_Up <> "Manual" Then
                    roundup_val_Lab.Text = nUmBeR_FORMATE(Val(amount_) - (Val(amt_total_label.Text) + Val(GST_Total.Text) + Val(Cess_Total.Text)))
                End If

                If Val(roundup_val_Lab.Text) = 0 Then
                    roundup_val_Lab.ForeColor = Color.Black
                    Label6.ForeColor = Color.Black
                    Label6.Text = "Round off"
                ElseIf Val(roundup_val_Lab.Text) < 0 Then
                    roundup_val_Lab.ForeColor = Color.Red
                    Label6.ForeColor = Color.Red
                    Label6.Text = "(-) Round off"
                ElseIf Val(roundup_val_Lab.Text) > 0 Then
                    roundup_val_Lab.ForeColor = Color.Green
                    Label6.ForeColor = Color.Green
                    Label6.Text = "(+) Round off"
                End If

            End If
        End With
        Return nUmBeR_FORMATE(roundup_val_Lab.Text)
    End Function

    Private Function Create_Exp(txt As TXT)
        Cell("Account Ledger", "", "Create_Close", "")
        With Ledger_frm
            .close_focus_obj = txt
            .Name_TXT.Text = txt.Text
            .Group_TXT.Text = "Direct Expenses"
        End With

    End Function
    Private Sub exp_Keydown(sender As Object, e As KeyEventArgs)
        Dim TX_ As TXT = CType(sender, TXT)
        Dim index As Integer = Integer.Parse(TX_.Name.Split("_")(1))

        If e.KeyCode = Keys.Enter Then
            If exp_list.List_Grid.CurrentRow.Cells(0).Value.ToString.ToLower <> sender.Text.ToString.ToLower Then
                Find_Exp_Bg(index).Tag = "User Defined Value"
            End If
            If exp_list.List_Grid.CurrentRow.Cells(1).Value = "Create" Then
                Create_Exp(sender)
                Exit Sub
            End If

            Find_exp_TXT(index).Data_Link_ = exp_list.List_Grid.CurrentRow.Cells(2).Value.ToString

            If Find_exp_TXT(index).Data_Link_ = Nothing Then

                Find_exp_rate_TXT(index).Text = ""
                Find_exp_rate_TXT(index).Enabled = False

                Find_exp_amt_TXT(index).Text = ""
                Find_exp_amt_TXT(index).Enabled = False
                Exit Sub
            Else
                Find_exp_rate_TXT(index).Enabled = True
                Find_exp_amt_TXT(index).Enabled = True
            End If
        End If


        If e.KeyCode = Keys.C AndAlso e.Modifiers = Keys.Alt Then
            Create_Exp(sender)
        ElseIf e.KeyCode = Keys.Enter AndAlso e.Modifiers = Keys.Control Then
            Cell("Account Ledger", "", "Alter_Close", Find_exp_TXT(index).Data_Link_)
            Ledger_frm.close_focus_obj = sender
        End If
    End Sub


    Public Function Find_exp_TXT(index As Integer) As TXT
        Try
            Return CType(exp_panel.Controls.Find(("exptxt_" & index), True).First, TXT)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Round_(index As Integer) As Label
        Try
            Return CType(exp_panel.Controls.Find(("Rounding_" & index), True).First, Label)
        Catch ex As Exception

        End Try
    End Function

    Public Function Find_Exp_Bg(index As Integer) As Panel
        Try
            Return CType(exp_panel.Controls.Find(("exp_" & index), True).First, Panel)
        Catch ex As Exception

        End Try
    End Function

    Public Function Find_exp_rate_TXT(index As Integer) As TXT
        Try
            Return CType(exp_panel.Controls.Find(("expratetxt_" & index), True).First, TXT)
        Catch ex As Exception

        End Try
    End Function

    Public Function Find_exp_per_TXT(index As Integer) As Label
        Try
            Return CType(exp_panel.Controls.Find(("expper_" & index), True).First, Label)
        Catch ex As Exception

        End Try
    End Function

    Public Function Find_exp_amt_TXT(index As Integer) As TXT
        Try
            Return CType(exp_panel.Controls.Find(("expamttxt_" & index), True).First, TXT)
        Catch ex As Exception

        End Try
    End Function

    Public Function Find_bg_pan(index As Integer) As Panel
        Try
            Return CType(stock_panel.Controls.Find(("bg_" & index), True).First, Panel)
        Catch ex As Exception

        End Try
    End Function

    Public Function Find_Idx(sender As Object) As Integer
        Try
            Return sender.Name.Split("_")(1)
        Catch ex As Exception

        End Try
    End Function
    Private Sub sp_controls_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        Fill_data_source()
        If curr_count >= 1 Then
            Fill_Item_data(False)
        Else
            Fill_Item_data(True)
        End If


        GST_YN = YN_Boolean(Inventory_Vouchers_frm.cfg_YN_GST)
        SUM()
    End Sub

    Private Sub amt_total_label_TextChanged(sender As Object, e As EventArgs) Handles amt_total_label.TextChanged

        SUM()

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub

    Private Sub Label10_TextChanged(sender As Object, e As EventArgs) Handles Label10.TextChanged
        If Val(Label10.Text) = 0 Then
            Panel19.Visible = False
        Else
            Panel19.Visible = True
        End If
    End Sub

    Private Sub Label7_TextChanged(sender As Object, e As EventArgs) Handles Label7.TextChanged
        If Val(Label7.Text) = 0 Then
            'Panel16.Visible = False
        Else
            'Panel16.Visible = True
        End If
    End Sub
    Private Sub sub_total_label_TextChanged(sender As Object, e As EventArgs) Handles sub_total_label.TextChanged
        If Val(sub_total_label.Text) = 0 Then
            Panel12.Visible = False
        Else
            Panel12.Visible = True
        End If
    End Sub
    Private Sub amt_Textchange(sender As Object, e As EventArgs)
        SUM()
    End Sub
    Private Sub exp_panel_Enter(sender As Object, e As EventArgs)
        Dim col As Color = Color.FromArgb(253, 233, 180)
        sender.BackColor = col
        Dim idx As Integer = Find_Idx(sender)

        Find_exp_TXT(idx).Back_color = col
        Find_exp_rate_TXT(idx).Back_color = col
        Find_exp_amt_TXT(idx).Back_color = col

        Find_exp_TXT(idx).BackColor = col
        Find_exp_rate_TXT(idx).BackColor = col
        Find_exp_amt_TXT(idx).BackColor = col
        Find_exp_per_TXT(idx).BackColor = col

    End Sub
    Private Sub exp_panel_Leave(sender As Object, e As EventArgs)
        Dim col As Color = stock_panel.BackColor
        sender.BackColor = col

        Dim idx As Integer = Find_Idx(sender)

        Find_exp_TXT(idx).Back_color = col
        Find_exp_rate_TXT(idx).Back_color = col
        Find_exp_amt_TXT(idx).Back_color = col

        Find_exp_TXT(idx).BackColor = col
        Find_exp_rate_TXT(idx).BackColor = col
        Find_exp_amt_TXT(idx).BackColor = col
        Find_exp_per_TXT(idx).BackColor = col
    End Sub

    Private Sub roundup_val_Lab_TextChanged(sender As Object, e As EventArgs) Handles roundup_val_Lab.TextChanged

    End Sub

    Private Sub roundup_val_Lab_LostFocus(sender As Object, e As EventArgs) Handles roundup_val_Lab.LostFocus
        SUM()
    End Sub

    Private Sub Vc_GST_summary_ctrl1_Paint(sender As Object, e As PaintEventArgs) Handles Vc_GST_summary_ctrl1.Paint
        Panel7.Width = Vc_GST_summary_ctrl1.Width
    End Sub

    Private Sub Panel31_Paint(sender As Object, e As PaintEventArgs) Handles Panel31.Paint
        Panel41.Width = Panel31.Width
    End Sub
    Private Sub Vc_GST_summary_ctrl1_VisibleChanged(sender As Object, e As EventArgs) Handles Vc_GST_summary_ctrl1.VisibleChanged
        Panel7.Visible = Vc_GST_summary_ctrl1.Visible
    End Sub

    Private Sub Vc_GST_summary_ctrl1_Load(sender As Object, e As EventArgs)

    End Sub
End Class
