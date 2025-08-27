Imports System.Data.SQLite
Imports Tools

Public Class stock_journal_under
    Public Property Me__Control_ID As Integer = 0
    Public Obj As stock_journal_controls
    Public Property Head_Account_ID As String
    Public Property MUlty_Head_acc_yn As Boolean = True
    Public Property isSource As Boolean
    'GST Details
    Public Property Cess_ID As String
    Public Property Cess_Per As Integer
    Public Property Cess_Amount As Decimal
    Public Property Batch_Enable As Boolean = False
    Public Property Mfg_Enable As Boolean = False
    Public Property Exp_Enable As Boolean = False

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
    Private Sub stock_journal_under_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Set_Object_()
    End Sub
    Public Function Set_Object_()
        With Obj
            Amount_TXT.Width = .Head_Amount.Width
            Rate_TXT.Width = .Head_Rate.Width
            Unit_Lst.Width = Val(.Label5.Width / 2) - 10
            Qty_TXT.Width = Val(.Label5.Width / 2) + 10


            Qty_Alte_Lab.Width = Qty_TXT.Width
            Unit_Alte_Lab.Width = Unit_Lst.Width
        End With

        If Batches_YN = True And Batch_Enable = True Then
            batch_Panel.Visible = True
        End If


        Array.ForEach(Me.Controls.OfType(Of TXT)().ToArray(),
              Sub(lbl) lbl.BackColor = Obj.BackColor)

        Array.ForEach(Me.Controls.OfType(Of TXT)().ToArray(),
              Sub(lbl) lbl.Back_color = Obj.BackColor)

    End Function
    Dim it_list As List_frm
    Dim un_list As List_frm
    Dim batch_list As List_frm

    Public Function List_set()
        it_list = New List_frm
        Dim ty As Select_List

        If isSource = True Then
            ty = Select_List.Right_Dock
        Else
            ty = Select_List.Botom
        End If

        List_Setup("List of Stock Items", ty, Select_List_Format.Defolt, Item_TXT, it_list, Obj.item_source, 420)
        it_list.Set_COlor(5)
        If Me__Control_ID = 1 Then
            it_list.System_Data_integer = 2
        Else
            it_list.System_Data_integer = 1
        End If

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


        Dt_Batch = New DataTable
        Dt_Batch.Columns.Add("Name")
        Dt_Batch.Columns.Add("Mfg")
        Dt_Batch.Columns.Add("Exp")
        Dt_Batch.Columns.Add("Stock")
        If Inventory_Vouchers_frm.Voucher_type_ = "Inward" Then
            Dt_Batch.Rows.Add("", "", "", "Create Batch")
        End If

        Dt_Batch.Rows.Add("Primary Batch", "", "", "")
        Batch_Source.DataSource = Dt_Batch

        batch_list = New List_frm
        List_Setup("List of Batch", Select_List.Botom, Select_List_Format.Custome, Batch_TXT, batch_list, Batch_Source, 500)
        batch_list.List_Grid.ColumnHeadersVisible = True
        batch_list.List_Grid.Columns(0).HeaderText = "Batch No."
        batch_list.List_Grid.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        batch_list.List_Grid.Columns(1).Width = 90
        batch_list.List_Grid.Columns(2).Width = 90
        batch_list.List_Grid.Columns(3).Width = 150
        batch_list.List_Grid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        If isSource = False Then
            batch_list.System_Data_integer = 1
        End If
    End Function
    Dim Dt_Unit As DataTable
    Private Sub Item_TXT_LostFocus(sender As Object, e As EventArgs) Handles Item_TXT.LostFocus
        Obj.item_source.MoveFirst()
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

                Amount_TXT.Text = ""
                Amount_TXT.Enabled = False

                Batch_TXT.Text = ""
                Batch_TXT.Enabled = False

                Mfg_TXT.Text = ""
                Mfg_TXT.Enabled = False

                Exp_TXT.Text = ""
                Exp_TXT.Enabled = False


                SubTotal_Cal()
                Obj.SUM()
                Exit Sub
            Else
                Qty_TXT.Enabled = True
                Unit_Lst.Enabled = True
                Rate_TXT.Enabled = True
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

                Batch_Enable = YN_Boolean(it_list.List_Grid.CurrentRow.Cells("Batch_YN").Value.ToString, False)
                Mfg_Enable = YN_Boolean(it_list.List_Grid.CurrentRow.Cells("Mfg").Value.ToString, False)
                Exp_Enable = YN_Boolean(it_list.List_Grid.CurrentRow.Cells("Exp").Value.ToString, False)

                If Batches_YN = True And Batch_Enable = True Then
                    batch_Panel.Visible = True
                    Batch_TXT.Visible = True
                    Batch_data_Fill()

                    If Mfg_Enable = True Then
                        Mfg_TXT.Visible = True
                        Label2.Visible = True
                    Else
                        Mfg_TXT.Visible = False
                        Label2.Visible = False
                    End If

                    If Exp_Enable = True Then
                        Exp_TXT.Visible = True
                        Label4.Visible = True
                    Else
                        Exp_TXT.Visible = False
                        Label4.Visible = False
                    End If
                Else
                    batch_Panel.Visible = False
                    Batch_TXT.Text = ""
                    Batch_TXT.Visible = False

                    Mfg_TXT.Text = ""
                    Mfg_TXT.Visible = False

                    Exp_TXT.Text = ""
                    Exp_TXT.Visible = False
                End If
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
                SubTotal_Cal()
            End If
        End If
    End Sub
    Dim Dt_Batch As DataTable
    Private Function Batch_data_Fill()
        Dim cn As New SQLiteConnection
        Dim r As SQLiteDataReader
        Dt_Batch.Rows.Clear()
        If isSource = False Then
            Dt_Batch.Rows.Add("", "", "", "Create Batch")
        End If

        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"SELECT vi.Item, vi.Batch_No,vi.Mfg_Date,vi.Exp_Date,
SUM(CASE WHEN vi.Type = 'Credit' THEN vi.Qty1 ELSE -vi.Qty1 END) AS Stock
FROM TBL_VC_item_Details vi
where vi.Item = '{Item_TXT.Data_Link_}'
GROUP BY vi.Item, vi.Batch_No,vi.Mfg_Date,vi.Exp_Date
ORDER BY CASE WHEN Batch_No = 'Primary Batch' THEN 1 ELSE 2 END,vi.Exp_Date;", cn)

            'My.Computer.Clipboard.SetText(cmd.CommandText)
            r = cmd.ExecuteReader
            Dim dr As DataRow
            While r.Read
                dr = Dt_Batch.NewRow
                dr("Name") = r("Batch_No").ToString
                dr("Mfg") = Date_Formate(r("Mfg_Date").ToString)
                dr("Exp") = Date_Formate(r("Exp_Date").ToString)
                dr("Stock") = $"{Val(r("Stock").ToString)} {Unit1_Symbol}"
                Dt_Batch.Rows.Add(dr)
            End While
            r.Close()
        End If
        If isSource = False Then
            If Dt_Batch.Rows.Count = 1 Then
                Dt_Batch.Rows.Add("Primary Batch", "", "", "")
            End If
        Else
            If Dt_Batch.Rows.Count = 0 Then
                Dt_Batch.Rows.Add("Primary Batch", "", "", "")
            End If
        End If

    End Function
    Public Function SubTotal_Cal()
        Dim SubTo As Decimal = nUmBeR_FORMATE(Val(Qty_TXT.Text) * Val(Rate_TXT.Text))
        Amount_TXT.Text = SubTo
    End Function
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
    Private Function Rate_Valu() As Decimal
        Dim Rate As Decimal = 0
        With Inventory_Vouchers_frm
            If isSource = False Then
                Rate = Rate_Valuation(Inventory_Vouchers_frm.cfg_rate_valuation, Item_TXT.Data_Link_, CDate(Inventory_Vouchers_frm.Date_TXT.Text), "0", "Inward")
            Else
                Rate = Rate_Valuation(Inventory_Vouchers_frm.cfg_rate_valuation, Item_TXT.Data_Link_, CDate(Inventory_Vouchers_frm.Date_TXT.Text), "0", "Outward")
            End If
        End With
        Return Rate
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
    Private Function Create_Item(txt As TXT)
        Cell("Stock Item", "", "Create_Close", "")
        With Stock_Item_frm
            .close_focus_obj = txt
            .Name_TXT.Text = txt.Text
        End With
    End Function
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
            If isSource = True Then
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

    Private Sub Amount_TXT_TextChanged(sender As Object, e As EventArgs) Handles Amount_TXT.TextChanged, Amount_TXT.LostFocus
        Obj.SUM()
    End Sub
    Private Function amt_vlu()
        Dim Amt As Decimal = Val(Amount_TXT.Text)

        Rate_TXT.Text = Val(Amt) / Val(Qty_TXT.Text)
        Rate_TXT.Text = nUmBeR_FORMATE(Rate_TXT.Text)

        SubTotal_Cal()
    End Function
    Private Sub sp_control_under_Enter(sender As Object, e As EventArgs) Handles MyBase.Enter
        Set_Object_()
        Dim col As Color = Color.FromArgb(253, 233, 180)
        Particuls_Panel.BackColor = col

        Array.ForEach(Particuls_Panel.Controls.OfType(Of TXT)().ToArray(),
              Sub(lbl) lbl.BackColor = col)

        Array.ForEach(Particuls_Panel.Controls.OfType(Of TXT)().ToArray(),
              Sub(lbl) lbl.Back_color = col)

    End Sub

    Private Sub sp_control_under_Leave(sender As Object, e As EventArgs) Handles MyBase.Leave
        Dim col As Color = Obj.BackColor
        Particuls_Panel.BackColor = col

        Array.ForEach(Particuls_Panel.Controls.OfType(Of TXT)().ToArray(),
              Sub(lbl) lbl.BackColor = col)

        Array.ForEach(Particuls_Panel.Controls.OfType(Of TXT)().ToArray(),
              Sub(lbl) lbl.Back_color = col)

    End Sub

    Private Sub Amount_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles Amount_TXT.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            amt_vlu()
            Unit_Details_Fill()
            SubTotal_Cal()

            NOT_Clear()


            If isSource = True Then
                If Me.Parent.Controls.Count = Me__Control_ID Then
                    Obj.Add_New_S()
                End If
            ElseIf isSource = False Then
                If Me.Parent.Controls.Count = Me__Control_ID Then
                    Obj.Add_New_P()
                End If
            End If
        End If
    End Sub

    Private Sub Mfg_TXT_TextChanged(sender As Object, e As EventArgs) Handles Mfg_TXT.TextChanged, Exp_TXT.TextChanged
        Batch_Period_Cal()
    End Sub
    Private Function Batch_Period_Cal()

        Try
            Dim D1 As Date = CDate(Mfg_TXT.Text)
            Dim D2 As Date = CDate(Exp_TXT.Text)

            'Batch_Period_Label.Text = $"{DateDiff(DateInterval.Day, D1, D2)} Days"
        Catch ex As Exception
            'Batch_Period_Label.Text = ""
        End Try

    End Function
    Private Sub Mfg_TXT_LostFocus(sender As Object, e As EventArgs) Handles Mfg_TXT.LostFocus, Exp_TXT.LostFocus
        sender.Text = Date_Formate(sender.Text)
    End Sub
    Private Sub Batch_TXT_VisibleChanged(sender As Object, e As EventArgs) Handles Batch_TXT.VisibleChanged
        Mfg_TXT.Visible = Batch_TXT.Visible
        Exp_TXT.Visible = Batch_TXT.Visible

        Exp_TXT.BringToFront()
    End Sub

    Private Sub Batch_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles Batch_TXT.KeyDown
        If e.KeyCode = Keys.Enter Then
            If batch_list.List_Grid.CurrentRow.Cells("Stock").Value = "Create Batch" Then
                batch_list.List_Grid.CurrentRow.Cells("Name").Value = Batch_TXT.Text
                Exit Sub
            End If

            Dim Old_Batch As String = Batch_TXT.Text
            If Old_Batch <> batch_list.List_Grid.CurrentRow.Cells("Name").Value Then
                Try
                    Mfg_TXT.Text = CDate(batch_list.List_Grid.CurrentRow.Cells("Mfg").Value)
                Catch ex As Exception
                    Mfg_TXT.Text = ""
                End Try
                Try
                    Exp_TXT.Text = CDate(batch_list.List_Grid.CurrentRow.Cells("Exp").Value)
                Catch ex As Exception
                    Exp_TXT.Text = ""
                End Try
            End If
        End If
    End Sub

    Private Sub Exp_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles Exp_TXT.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                If CDate(Mfg_TXT.Text) > CDate(Exp_TXT.Text) Then
                    Mfg_TXT.Focus()
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub Item_TXT_TextChanged(sender As Object, e As EventArgs) Handles Item_TXT.TextChanged

    End Sub
End Class
