Imports System.Data.SQLite
Imports System.Windows.Controls
Imports Tools
Imports PopupControl

Public Class sp_control_under
    Public Property Me__Control_ID As Integer = 0
    Public Obj As sp_controls
    Public Property Head_Account_ID As String
    Public Property MUlty_Head_acc_yn As Boolean = True
    'GST Details
    Public Property Cess_ID As String
    Public Property Cess_Per As Integer
    Public Property Cess_Amount As Decimal

    Public Property GST_Enable As Boolean = False
    Public Property GST_Type As String
    Public Property GST_Per As Decimal
    Public Property GST_Amount As Decimal
    Public Property CGST_ID As String
    Public Property SGST_ID As String
    Public Property IGST_ID As String

    Public Property Curr_Stock As Decimal
    Public Property Unit1_ID As String
    Public Property Unit1_Symbol As String
    Public Property Unit1_Decimal As String
    Public Property Unit2_ID As String
    Public Property Unit2_Symbol As String
    Public Property Unit2_Decimal As String
    Public Property Unit1_Value As String
    Public Property Unit2_Value As String

    Public Property Qty1 As Decimal
    Public Property Qty2 As Decimal
    Public Property Rate1 As Decimal
    Public Property Rate2 As Decimal
    Private Sub sp_control_under_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Set_Object_()
    End Sub
    Public Function Set_Object_()
        With Obj
            Amount_TXT.Width = .Head_Amount.Width
            DiscountP_TXT.Width = .Head_Discount.Width
            discount_amt_lab.Width = .Head_Discount.Width + .Head_Rate.Width
            Rate_TXT.Width = .Head_Rate.Width
            Unit_Lst.Width = Val(.Head_Quantity.Width / 2) - 10
            Qty_TXT.Width = Val(.Head_Quantity.Width / 2) + 10


            Qty_Alte_Lab.Width = Qty_TXT.Width
            Unit_Alte_Lab.Width = Unit_Lst.Width
        End With

        Obj.Panel16.Location = New Point(GSTAmt_Lab.Location.X, 10)
        Obj.Panel46.Location = New Point(CessAmt_Lab.Location.X, 10)
        Obj.Panel12.Location = New Point(Amount_TXT.Location.X, 10)
        discount_amt_lab.Location = Rate_TXT.Location


        Array.ForEach(Me.Controls.OfType(Of TXT)().ToArray(),
              Sub(lbl) lbl.BackColor = Obj.BackColor)

        Array.ForEach(Me.Controls.OfType(Of TXT)().ToArray(),
              Sub(lbl) lbl.Back_color = Obj.BackColor)

    End Function
    Dim it_list As List_frm
    Dim un_list As List_frm

    Public Function List_set()
        it_list = New List_frm
        List_Setup("List of Stock Items", Select_List.Right_Dock, Select_List_Format.Defolt, Item_TXT, it_list, Obj.BindingSource1, 420)
        it_list.Set_COlor(5)
        it_list.System_Data_integer = 1

        Dt_Unit = New DataTable
        Dt_Unit.Columns.Add("Name")
        Dt_Unit.Columns.Add("ID")
        Dt_Unit.Columns.Add("Decimal")
        Dt_Unit.Rows.Add("NA")
        Unit_Source.DataSource = Dt_Unit

        un_list = New List_frm
        List_Setup("List of Unit", Select_List.Right, Select_List_Format.Custome, Unit_Lst, un_list, Unit_Source, 100)
        For Each Col As DataGridViewColumn In un_list.List_Grid.Columns
            Col.Visible = False
        Next
        un_list.List_Grid.Columns(0).Visible = True
        un_list.List_Grid.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Function

    Private Sub Item_TXT_TextChanged(sender As Object, e As EventArgs) Handles Item_TXT.TextChanged

    End Sub

    Private Sub Item_TXT_LostFocus(sender As Object, e As EventArgs) Handles Item_TXT.LostFocus
        Obj.BindingSource1.MoveFirst()
    End Sub

    Private Sub Item_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles Item_TXT.KeyDown
        If e.KeyCode = Keys.C AndAlso e.Modifiers = Keys.Alt Then
            Create_Item(sender)
        ElseIf e.KeyCode = Keys.Enter AndAlso e.Modifiers = Keys.Control Then
            Cell("Stock Item", "", "Alter_Close", it_list.List_Grid.CurrentRow.Cells(2).Value.ToString)
            Stock_Item_frm.close_focus_obj = sender
        ElseIf e.KeyCode = Keys.Enter Then
            If it_list.List_Grid.CurrentRow.Cells(1).Value = "Create" Then
                Create_Item(sender)
                Exit Sub
            End If
            Dim Old_ID As String = Item_TXT.Data_Link_
            If Item_TXT.Data_Link_ <> it_list.List_Grid.CurrentRow.Cells(2).Value.ToString Then
                Rate_TXT.Text = ""
            End If
            Item_TXT.Data_Link_ = it_list.List_Grid.CurrentRow.Cells(2).Value.ToString
            If Item_TXT.Data_Link_ = Nothing Then
                Qty_TXT.Text = ""
                Qty_TXT.Enabled = False

                Unit_Lst.Text = ""
                Unit_Lst.Enabled = False

                Rate_TXT.Text = ""
                Rate_TXT.Enabled = False

                DiscountP_TXT.Text = ""
                DiscountP_TXT.Enabled = False

                Amount_TXT.Text = ""
                Amount_TXT.Enabled = False


                SP_acc_details_fill()
                SubTotal_Cal()
                Obj.SUM()
                Exit Sub
            Else
                Qty_TXT.Enabled = True
                Unit_Lst.Enabled = True
                Rate_TXT.Enabled = True
                DiscountP_TXT.Enabled = True
                Amount_TXT.Enabled = True

                GST_Type = it_list.List_Grid.CurrentRow.Cells("Tax_Type").Value.ToString
                Curr_Stock = Val(it_list.List_Grid.CurrentRow.Cells("Stock_vlu").Value.ToString)

                Unit1_ID = it_list.List_Grid.CurrentRow.Cells("Unit_id").Value.ToString
                Unit1_Symbol = it_list.List_Grid.CurrentRow.Cells("Unit_Name").Value.ToString
                Unit1_Decimal = it_list.List_Grid.CurrentRow.Cells("Unit_decimal").Value.ToString

                Unit2_ID = it_list.List_Grid.CurrentRow.Cells("A_Unit_ID").Value.ToString
                Unit2_Symbol = it_list.List_Grid.CurrentRow.Cells("A_Unit_Symbol").Value.ToString
                Unit2_Decimal = it_list.List_Grid.CurrentRow.Cells("A_Unit_decimal").Value.ToString

                Unit1_Value = it_list.List_Grid.CurrentRow.Cells("A_Unit1_Value").Value.ToString
                Unit2_Value = it_list.List_Grid.CurrentRow.Cells("A_Unit2_Value").Value.ToString

                Unit_data_fill()

                If Old_ID <> Item_TXT.Data_Link_ Then
                    Unit_Lst.Text = Unit1_Symbol
                    Unit_Lst.Data_Link_ = Unit1_ID
                    Qty_TXT.Decimal_ = Val(it_list.List_Grid.CurrentRow.Cells("Unit_decimal").Value.ToString)

                    Unit_Details_Fill()
                    Qty_Decimal_set(Qty_TXT.Decimal_)
                End If
                If it_list.List_Grid.CurrentRow.Cells("GST_Applicapable").Value.ToString = "Applicable" Or it_list.List_Grid.CurrentRow.Cells("GST_Applicapable").Value.ToString = "Undefined" Then
                    GST_Enable = (True)
                Else
                    GST_Enable = (False)
                End If
                If Val(Rate_TXT.Text) = 0 Then
                    Rate_TXT.Text = Rate_Valu()
                End If
                Unit_Details_Fill()
                SP_acc_details_fill()
                SubTotal_Cal()
            End If
        End If
    End Sub
    Private Function Rate_Valu() As Decimal
        Dim Rate As Decimal = 0
        With Inventory_Vouchers_frm
            If .Voucher_Type_LB.Text = "Purchase" Or .Voucher_Type_LB.Text = "Purchase Order" Or .Voucher_Type_LB.Text = "Inward Register" Then
                Rate = Rate_Valuation(Inventory_Vouchers_frm.cfg_rate_valuation, Item_TXT.Data_Link_, CDate(Inventory_Vouchers_frm.Date_TXT.Text), "0", "Inward")
            Else
                Rate = Rate_Valuation(Inventory_Vouchers_frm.cfg_rate_valuation, Item_TXT.Data_Link_, CDate(Inventory_Vouchers_frm.Date_TXT.Text), "0", "Outward")
            End If
        End With
        Return Rate
    End Function
    Private Function Create_Item(txt As TXT)
        Cell("Stock Item", "", "Create_Close", "")
        With Stock_Item_frm
            .close_focus_obj = txt
            .Name_TXT.Text = txt.Text
        End With
    End Function
    Public Function Unit_Details_Fill()
        Qty_Alte_Lab.Location = Qty_TXT.Location
        Unit_Alte_Lab.Location = Unit_Lst.Location

        If Unit2_Value <> 0 Then
            Qty_Alte_Lab.Visible = True
            Unit_Alte_Lab.Visible = True

            If Unit_Lst.Data_Link_ = Unit1_ID Then
                Dim v As Decimal = Unit2_Value / Unit1_Value
                Dim Q As Decimal = v * Val(Qty_TXT.Text)

                Qty1 = Val(Qty_TXT.Text)
                Qty2 = Q

                Qty_Alte_Lab.Text = Value_Decimal_set(Q, Unit2_Decimal)
                Unit_Alte_Lab.Text = Unit2_Symbol

                Dim R As Decimal = Val(Val(Qty_TXT.Text) * Val(Rate_TXT.Text))
                Rate1 = Val(Rate_TXT.Text)
                If R = 0 Then
                    Rate2 = R
                Else
                    Rate2 = R / (Q)
                End If
            ElseIf Unit_Lst.Data_Link_ = Unit2_ID Then
                Dim v As Decimal = Unit1_Value / Unit2_Value
                Dim Q As Decimal = v * Val(Qty_TXT.Text)

                Qty2 = Val(Qty_TXT.Text)
                Qty1 = Q

                Qty_Alte_Lab.Text = Value_Decimal_set(Q, Unit1_Decimal)
                Unit_Alte_Lab.Text = Unit1_Symbol


                Dim R As Decimal = Val(Val(Qty_TXT.Text) * Val(Rate_TXT.Text))
                Rate2 = Val(Rate_TXT.Text)
                If R = 0 Then
                    Rate1 = 0
                Else
                    Rate1 = R / (Q)
                End If
            End If
        Else
            Qty_Alte_Lab.Visible = False
            Unit_Alte_Lab.Visible = False
            Qty1 = Val(Qty_TXT.Text)
            Qty2 = Val(0)
            Rate1 = Val(Rate_TXT.Text)
            Rate2 = Val(0)
        End If
    End Function
    Private Function SP_acc_details_fill()
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            Dim Filter_Format As String = ""
            With Inventory_Vouchers_frm
                If .VC_Formate = "Purchase" Or .VC_Formate = "Purchase Return" Or .VC_Formate = "Debit Note" Or .VC_Formate = "Inward Register" Then
                    Filter_Format = "Purchase"
                Else
                    Filter_Format = "Sales"
                End If

                Dim GST_Per As Decimal = nUmBeR_FORMATE(Val(Find_DT_Value(Database_File.cre, "TBL_Stock_Item", "TAX_Value", $"ID = '{Item_TXT.Data_Link_}'")))
                Dim Cess_Per As Decimal = nUmBeR_FORMATE(Val(Find_DT_Value(Database_File.cre, "TBL_Stock_Item", "Cess_Value", $"ID = '{Item_TXT.Data_Link_}'")))
                Dim Tax_Type_Item As String = ((Find_DT_Value(Database_File.cre, "TBL_Stock_Item", "Tax_Type", $"ID = '{Item_TXT.Data_Link_}'")))

                GST_details_fill(Cess_Per, GST_Per)

                Dim r As SQLiteDataReader
                Dim filter As String = ""

                If YN_Boolean(Inventory_Vouchers_frm.cfg_YN_GST) = True Then
                    If Val(GST_Per) = 0 Then
                        If Tax_Type_Item = "Exempt" Then
                            filter = $"ld.TypeOfDuty = '{Filter_Format.ToUpper} EXEMPT'"
                        ElseIf Tax_Type_Item = "Nil Rated" Then
                            filter = $"ld.TypeOfDuty = '{Filter_Format.ToUpper} NILL RATED'"
                        Else
                            filter = $"ld.PercentageOfCalculation = '{GST_Per}'"
                        End If
                    Else
                        filter = $"ld.PercentageOfCalculation = '{GST_Per}'"
                    End If
                Else
                    filter = $"ld.TAX_Type = 'Not Applicable'"
                End If


                Dim filter_id As String = ""
                If Filter_Format = "Sales" Then
                    filter_id = "10"
                ElseIf Filter_Format = "Purchase" Then
                    filter_id = "11"
                End If
                cmd = New SQLiteCommand($"Select *,count(*) as C_ From TBL_Ledger ld where ld.[Group] = '{filter_id}' and ld.Visible = 'Approval' and ({filter})", cn)
                r = cmd.ExecuteReader
                While r.Read
                    If Val(r("C_").ToString) = 0 Then

                    ElseIf Val(r("C_").ToString) = 1 Then
                        MUlty_Head_acc_yn = False
                        Head_Account_ID = r("ID").ToString
                    Else
                        MUlty_Head_acc_yn = True
                    End If
                End While
            End With
        End If
    End Function
    Private Function GST_details_fill(Cess_Per_ As Decimal, GST_Per_ As Decimal)
        If Obj.GST_YN = True And GST_Type = "Taxable" Then
            If Cess_Per_ <> 0 Then
                Cess_ID = Find_DT_Value(Database_File.cre, "TBL_Ledger", "ID", $"Visible = 'Approval' and TAX_Type = 'GST' and TAX_Class = 'Cess'")
                Cess_Per = Cess_Per_
            Else
                Cess_ID = ""
                Cess_Amount = 0
                Cess_Per = 0
            End If

            If Obj.TAX_Type = "CS" Then
                CGST_ID = Find_DT_Value(Database_File.cre, "TBL_Ledger", "ID", $"Visible = 'Approval' and TAX_Type = 'GST' and TAX_Class = 'CGST' and PercentageOfCalculation = '{nUmBeR_FORMATE(nUmBeR_FORMATE(GST_Per) / 2)}'")
                SGST_ID = Find_DT_Value(Database_File.cre, "TBL_Ledger", "ID", $"Visible = 'Approval' and TAX_Type = 'GST' and TAX_Class = 'SGST/UTGST' and PercentageOfCalculation = '{nUmBeR_FORMATE(nUmBeR_FORMATE(GST_Per) / 2)}'")
            Else
                IGST_ID = Find_DT_Value(Database_File.cre, "TBL_Ledger", "ID", $"Visible = 'Approval' and TAX_Type = 'GST' and TAX_Class = 'IGST' and PercentageOfCalculation = '{nUmBeR_FORMATE(GST_Per)}'")
            End If

            GST_Per = nUmBeR_FORMATE(GST_Per_)
        Else
            Cess_ID = ""
            Cess_Amount = 0
            Cess_Per = 0

            CGST_ID = ""
            SGST_ID = ""
            IGST_ID = ""
            GST_Per = nUmBeR_FORMATE(0)
        End If
        GST_Calculation()
    End Function
    Private Function GST_Calculation()
        If Val(Amount_TXT.Text) <> 0 Then
            Dim GST_ As Decimal = Val(Val(Val(Amount_TXT.Text) * Val(GST_Per)) / 100)
            Dim Cess_ As Decimal = Val(Val(Val(Amount_TXT.Text) * Val(Cess_Per)) / 100)

            GST_Amount = (GST_)
            Cess_Amount = (Cess_)

        Else
            GST_Amount = 0
            Cess_Amount = 0
        End If

        GSTPer_Lab.Text = $"{N2_FORMATE(GST_Per)}%"
        GSTAmt_Lab.Text = $"{N2_FORMATE(GST_Amount)}₹"

        CessPer_Lab.Text = $"{N2_FORMATE(Cess_Per)}%"
        CessAmt_Lab.Text = $"{N2_FORMATE(Cess_Amount)}₹"

        If Cess_Per = 0 Then
            CessAmt_Lab.Visible = False
            CessPer_Lab.Visible = False
            Cess_Lab.Visible = False
        Else
            CessAmt_Lab.Visible = True
            CessPer_Lab.Visible = True
            Cess_Lab.Visible = True
        End If

    End Function
    Public Function SubTotal_Cal()
        Dim SubTo As Decimal = nUmBeR_FORMATE(Val(Qty_TXT.Text) * Val(Rate_TXT.Text))
        Dim Dis_ As Decimal = 0

        If Inventory_Vouchers_frm.cfg_Item_Discount = True Then
            If nUmBeR_FORMATE(DiscountP_TXT.Text) = 100 Then
                Dis_ = SubTo
            Else
                Dis_ = nUmBeR_FORMATE(Val(SubTo * nUmBeR_FORMATE(DiscountP_TXT.Text)) / 100)
            End If
            DiscountP_TXT.Data_Link_ = Dis_
            discount_amt_lab.Text = $"{Dis_}₹"
        End If

        Amount_TXT.Text = SubTo - nUmBeR_FORMATE(Dis_)

        GST_Calculation()
    End Function
    Dim Dt_Unit As DataTable
    Public Function Unit_data_fill()
        Dt_Unit.Rows.Clear()

        If Unit2_Symbol = Nothing Then
            Unit_Lst.Enabled = False
        Else
            Unit_Lst.Enabled = True
            Dt_Unit.Rows.Add(Unit1_Symbol, Unit1_ID, Unit1_Decimal)
            Dt_Unit.Rows.Add(Unit2_Symbol, Unit2_ID, Unit2_Decimal)
        End If

        Unit_Details_Fill()
        Qty_Decimal_set(Qty_TXT.Decimal_)

    End Function
    Public Function Qty_Decimal_set(decimal_ As Integer)
        Qty_TXT.Decimal_ = decimal_
        Qty_TXT.Text = Value_Decimal_set(Qty_TXT.Text, decimal_)
    End Function

    Private Sub Unit_Lst_TextChanged(sender As Object, e As EventArgs) Handles Unit_Lst.TextChanged

    End Sub

    Private Sub Unit_Lst_KeyDown(sender As Object, e As KeyEventArgs) Handles Unit_Lst.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim Old_ID As String = Unit_Lst.Data_Link_

            Unit_Lst.Data_Link_ = un_list.List_Grid.CurrentRow.Cells("ID").Value
            Qty_TXT.Decimal_ = un_list.List_Grid.CurrentRow.Cells("Decimal").Value

            Unit_Details_Fill()
            Qty_Decimal_set(Qty_TXT.Decimal_)

            If Old_ID <> Unit_Lst.Data_Link_ Then
                If Unit_Lst.Data_Link_ = Unit1_ID Then
                    Rate_TXT.Text = Rate_Valu()
                ElseIf Unit_Lst.Data_Link_ = Unit2_ID Then
                    Dim Rat As Decimal = Rate_Valu()
                    Dim v As Decimal = Unit1_Value / Unit2_Value
                    Rate_TXT.Text = nUmBeR_FORMATE(v * Rat)
                End If
            End If
        End If
    End Sub

    Private Sub Qty_TXT_TextChanged(sender As Object, e As EventArgs) Handles Qty_TXT.TextChanged
        With Inventory_Vouchers_frm.Voucher_Type_LB
            If .Text = "Sales" Or .Text = "Sales Order" Or .Text = "Outward Register" Then
                'If (Val(Find_Aqtule_Qty(idx).Text) > Val(find_stock_lab(Find_Idx(sender)).Text)) And Me.Visible = True Then
                '    NOT_($"Negative Stock", NOT_Type.Warning)
                'Else
                '    NOT_Clear()
                'End If
            End If
        End With

        Unit_Details_Fill()
        SubTotal_Cal()
        Obj.SUM()
    End Sub

    Private Sub LostFocusRefresh_LostFocus(sender As Object, e As EventArgs) Handles Qty_TXT.LostFocus
        Unit_Details_Fill()
        SubTotal_Cal()
        Obj.SUM()
        NOT_Clear()
    End Sub

    Private Sub Qty_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles Qty_TXT.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Unit_Lst.Enabled = False Then
                Qty_Decimal_set(Qty_TXT.Decimal_)
            End If
        End If
    End Sub

    Private Sub Rate_TXT_TextChanged(sender As Object, e As EventArgs) Handles Rate_TXT.TextChanged
        Unit_Details_Fill()
        SubTotal_Cal()
        Obj.SUM()
    End Sub

    Private Sub Rate_TXT_LostFocus(sender As Object, e As EventArgs) Handles Rate_TXT.LostFocus
        SubTotal_Cal()
        Obj.SUM()
    End Sub

    Private Sub DiscountP_TXT_LostFocus(sender As Object, e As EventArgs) Handles DiscountP_TXT.LostFocus
        SubTotal_Cal()
        Obj.SUM()
    End Sub

    Private Sub DiscountP_TXT_TextChanged(sender As Object, e As EventArgs) Handles DiscountP_TXT.TextChanged
        SubTotal_Cal()
        Obj.SUM()
    End Sub

    Private Sub Amount_TXT_TextChanged(sender As Object, e As EventArgs) Handles Amount_TXT.TextChanged, Amount_TXT.LostFocus
        Obj.SUM()
    End Sub

    Private Sub Amount_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles Amount_TXT.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            amt_vlu()
            Unit_Details_Fill()
            SubTotal_Cal()

            If Val(sender.Text) = 0 Then
                e.SuppressKeyPress = True
                NOT_("Please enter amount (value), and try again", NOT_Type.Warning)
                sender.Text = ""
                If Inventory_Vouchers_frm.cfg_YN_zero = False Then
                    sender.Focus()
                    Exit Sub
                End If
            End If
            NOT_Clear()
            Dim Me_index As Integer = Obj.stock_panel.Controls.IndexOf(Me) + 1


            If Obj.stock_panel.Controls.Count = Me__Control_ID Then
                Obj.Add_New()
            End If
            If MUlty_Head_acc_yn = True Or Inventory_Vouchers_frm.YN_item_description = True Then
                Dim pop As Popup
                Dim Audit_cfg_pop As Object
                Audit_cfg_pop = New vc_item_gst_details
                pop = New Popup(Audit_cfg_pop)

                pop.FocusOnOpen = True
                Audit_cfg_pop.obj = Me

                pop.AnimationDuration = 1
                Audit_cfg_pop.Fill_Source()
                pop.Show(sender)

                Audit_cfg_pop.List_set()
                Audit_cfg_pop.load()
            End If
        End If
    End Sub
    Private Function amt_vlu()
        Dim Amt As Decimal = Val(Amount_TXT.Text)

        If Inventory_Vouchers_frm.cfg_Item_Discount = True And Val(DiscountP_TXT.Text) <> 0 Then
            Amt = Val(nUmBeR_FORMATE(Amount_TXT.Text) * 100) / Val(100 - nUmBeR_FORMATE(DiscountP_TXT.Text))
        End If
        Rate_TXT.Text = Val(Amt) / Val(Qty_TXT.Text)
        Rate_TXT.Text = nUmBeR_FORMATE(Rate_TXT.Text)

        SubTotal_Cal()
    End Function

    Private Sub Unit_Alte_Lab_Click(sender As Object, e As EventArgs) Handles Unit_Alte_Lab.Click
    End Sub

    Private Sub sp_control_under_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        Set_Object_()
        Dim col As Color = Color.FromArgb(253, 233, 180)
        Particuls_Panel.BackColor = col

        Array.ForEach(Particuls_Panel.Controls.OfType(Of TXT)().ToArray(),
              Sub(lbl) lbl.BackColor = col)

        Array.ForEach(Particuls_Panel.Controls.OfType(Of TXT)().ToArray(),
              Sub(lbl) lbl.Back_color = col)

    End Sub

    Private Sub sp_control_under_Leave(sender As Object, e As EventArgs) Handles Me.Leave
        Dim col As Color = Obj.BackColor
        Particuls_Panel.BackColor = col

        Array.ForEach(Particuls_Panel.Controls.OfType(Of TXT)().ToArray(),
              Sub(lbl) lbl.BackColor = col)

        Array.ForEach(Particuls_Panel.Controls.OfType(Of TXT)().ToArray(),
              Sub(lbl) lbl.Back_color = col)

        Obj.Vc_GST_summary_ctrl1.Refresh_Data_()
    End Sub

    Private Sub GSTType_Lab_Click(sender As Object, e As EventArgs) Handles GSTType_Lab.Click

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class
