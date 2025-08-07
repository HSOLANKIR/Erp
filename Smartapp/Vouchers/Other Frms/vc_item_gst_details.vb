Imports System.Data.SQLite

Public Class vc_item_gst_details
    Public obj As sp_control_under
    Public Filter_Format As String = ""
    Private Sub vc_item_description_ctrl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Fill_Source()
        'List_set()
        'load()

        Txt1.Text = obj.Discription_Label.Text

        With Inventory_Vouchers_frm
            If .VC_Formate = "Purchase" Or .VC_Formate = "Purchase Return" Or .VC_Formate = "Debit Note" Or .VC_Formate = "Inward Register" Then
                Filter_Format = "Purchase"
            Else
                Filter_Format = "Sales"
            End If
        End With

        Label51.Text = Filter_Format
        'Txt2.Focus()

        If obj.MUlty_Head_acc_yn = True Then
            Panel12.Enabled = True
        Else
            Panel12.Enabled = False
        End If

    End Sub
    Dim TAX_Type As String
    Public GST_YN As Boolean = False
    Public Description_YN As Boolean = False
    Public Item_GST_Type As String = ""
    Public SUB_Total As Decimal = 0


    Dim GST_Per As Decimal = 0.00
    Dim Cess_Per As Decimal = 0.00
    Dim Tax_Type_Item As String = ""
    Dim Head_Acc_ID As String = ""
    Public Function load()
        With Inventory_Vouchers_frm
            If .VC_Formate = "Purchase" Or .VC_Formate = "Purchase Return" Or .VC_Formate = "Debit Note" Or .VC_Formate = "Inward Register" Then
                Filter_Format = "Purchase"
            Else
                Filter_Format = "Sales"
            End If
        End With


        TAX_Type = Inventory_Vouchers_frm.TAX_Type
        GST_YN = YN_Boolean(Inventory_Vouchers_frm.cfg_YN_GST)
        Description_YN = YN_Boolean(Inventory_Vouchers_frm.YN_item_description)
        Item_GST_Type = obj.GST_Type
        SUB_Total = Val(obj.Amount_TXT.Text)
        Head_Acc_ID = Val(obj.Head_Account_ID)

        GST_Panel.Visible = GST_YN

        'Apply all condition

        Txt3.Text = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Name", $"ID = '{Head_Acc_ID}'")

        Panel8.Visible = Description_YN
        If GST_YN = True And Item_GST_Type = "Taxable" Then
            GST_Panel.Visible = True

            With obj
                Cess_ID = .Cess_ID
                Cess_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Name", $"ID = '{Cess_ID}'")

                Cess_Panel.Visible = True

                Label33.Text = nUmBeR_FORMATE(Cess_Per)

                If TAX_Type = "CS" Then
                    State_GST_Panel.Visible = True
                    IGST_Panel.Visible = False


                    CGST_ID = .CGST_ID
                    SGST_ID = .SGST_ID

                    CGST_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Name", $"ID = '{CGST_ID}'")
                    SGST_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Name", $"ID = '{SGST_ID}'")


                    Label26.Text = nUmBeR_FORMATE(Val(GST_Per) / 2)
                    Label25.Text = nUmBeR_FORMATE(Val(GST_Per) / 2)

                Else
                    IGST_ID = .IGST_ID
                    IGST_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Name", $"ID = '{IGST_ID}'")

                    State_GST_Panel.Visible = False
                    IGST_Panel.Visible = True

                    Label24.Text = nUmBeR_FORMATE(GST_Per)
                End If
            End With
        Else
            GST_Panel.Visible = False
        End If

        Me.Refresh()
    End Function
    Dim Ledger_list As List_frm
    Public Function List_set()
        Ledger_list = New List_frm
        List_Setup("List of Ledger Acc.", Select_List.Botom, Select_List_Format.Singel, Txt3, Ledger_list, Ledger_Source, Txt3.Width)


    End Function
    Dim I_list_count As Integer = 0
    Dim S_list_count As Integer = 0
    Dim C_list_count As Integer = 0


    Dim CGST_ID As String = ""
    Dim SGST_ID As String = ""
    Dim IGST_ID As String = ""
    Dim Cess_ID As String = ""

    Public Function Fill_Source()
        With Inventory_Vouchers_frm
            If .VC_Formate = "Purchase" Or .VC_Formate = "Purchase Return" Or .VC_Formate = "Debit Note" Or .VC_Formate = "Inward Register" Then
                Filter_Format = "Purchase"
            Else
                Filter_Format = "Sales"
            End If
        End With


        GST_Per = nUmBeR_FORMATE(Val(Find_DT_Value(Database_File.cre, "TBL_Stock_Item", "TAX_Value", $"ID = '{obj.Item_TXT.Data_Link_}'")))
        Cess_Per = nUmBeR_FORMATE(Val(Find_DT_Value(Database_File.cre, "TBL_Stock_Item", "Cess_Value", $"ID = '{obj.Item_TXT.Data_Link_}'")))
        Tax_Type_Item = ((Find_DT_Value(Database_File.cre, "TBL_Stock_Item", "Tax_Type", $"ID = '{obj.Item_TXT.Data_Link_}'")))


        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            Dim dt As New DataTable
            dt.Columns.Add("Name")
            dt.Columns.Add("Alias")
            dt.Columns.Add("ID")
            dt.Columns.Add("TAX_Type")
            dt.Columns.Add("TAX_Class")
            dt.Columns.Add("TypeOfDuty")



            Dim r As SQLiteDataReader
            Dim filter As String = ""

            If YN_Boolean(Inventory_Vouchers_frm.cfg_YN_GST) = True Then
                If Val(GST_Per) = 0 Then
                    If Tax_Type_Item = "Exempt" Then
                        filter = $"ld.TypeOfDuty = '{Filter_Format.ToUpper} EXEMPT'"
                        Label29.Text = "GST EXEMPT"
                    ElseIf Tax_Type_Item = "Nil Rated" Then
                        filter = $"ld.TypeOfDuty = '{Filter_Format.ToUpper} NILL RATED'"
                        Label29.Text = "GST NILL RATE"
                    Else
                        filter = $"ld.PercentageOfCalculation = '{GST_Per}'"
                        Label29.Text = "NON-GST"
                    End If
                Else
                    filter = $"ld.PercentageOfCalculation = '{GST_Per}'"
                    Label29.Text = $"GST {nUmBeR_FORMATE(GST_Per)}%"
                End If
            Else
                filter = $"ld.TAX_Type = 'Not Applicable'"
                Label29.Text = $"GST : Not Applicable"
            End If

            If Filter_Format = "Sales" Then
                cmd = New SQLiteCommand($"Select * From TBL_Ledger ld where ld.[Group] = '10' and ld.Visible = 'Approval' and ({filter})", cn)
                r = cmd.ExecuteReader
                While r.Read
                    dt.Rows.Add(r("Name"), r("Alise"), r("ID"), r("TAX_Type"), r("TAX_Class"), r("TypeOfDuty"))
                End While
            ElseIf Filter_Format = "Purchase" Then
                cmd = New SQLiteCommand($"Select * From TBL_Ledger ld where ld.[Group] = '11' and ld.Visible = 'Approval' and ({filter})", cn)
                r = cmd.ExecuteReader
                While r.Read
                    dt.Rows.Add(r("Name"), r("Alise"), r("ID"), r("TAX_Type"), r("TAX_Class"), r("TypeOfDuty"))
                End While
            End If

            If dt.Rows.Count = 0 Then
                dt.Rows.Add("Create", "", "Create", "", "", "")
            ElseIf dt.Rows.Count = 1 Then

            End If
            Ledger_Source.DataSource = dt
        End If
        cn.Close()
    End Function
    Private Sub Txt1_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt1.KeyDown

        If e.KeyCode = Keys.Enter AndAlso e.Modifiers = Keys.Shift Then

        ElseIf e.KeyCode = Keys.Enter Then

        End If
    End Sub
    Private Sub Label26_TextChange(sender As Object, e As EventArgs) Handles Label26.TextChanged
        Label12.Text = nUmBeR_FORMATE((Val(SUB_Total) * Val(sender.Text)) / 100)
    End Sub
    Private Sub Label25_TextChange(sender As Object, e As EventArgs) Handles Label25.TextChanged
        Label10.Text = nUmBeR_FORMATE((Val(SUB_Total) * Val(sender.Text)) / 100)
    End Sub
    Private Sub Label24_TextChange(sender As Object, e As EventArgs) Handles Label24.TextChanged
        Label16.Text = nUmBeR_FORMATE((Val(SUB_Total) * Val(sender.Text)) / 100)
    End Sub
    Private Sub tOTAL_gst_amt_TextChanged(sender As Object, e As EventArgs) Handles Label12.TextChanged, Label10.TextChanged, Label16.TextChanged
        Label19.Text = nUmBeR_FORMATE(Val(Label12.Text) + Val(Label10.Text) + Val(Label16.Text) + Val(Label35.Text))
    End Sub
    Private Sub tOTAL_gst_rate_TextChanged(sender As Object, e As EventArgs) Handles Label12.TextChanged, Label10.TextChanged, Label16.TextChanged
        Label21.Text = nUmBeR_FORMATE(Val(Label26.Text) + Val(Label25.Text) + Val(Label24.Text) + Val(Label33.Text))
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If GST_Panel.Visible = True Then
            If TAX_Type = "CS" Then
                If CGST_TXT.Text = "" Then
                    If Msg_Custom_YN(NOT_Location.Bottom_Right, Color.Red, My.Resources.Warning_animation_icn, Dialoag_Button.Yes_No, "Error", "CGST Not Found", "Ledger account of CGST is not created,<nl>so you cannot add CGST.<nl><nl>Do you want to create a CGST account?") = DialogResult.Yes Then
                        Cell("Account Ledger", "", "Create_Close", "")

                        With Ledger_frm
                            .Txt5.Text = "GST"
                            .Txt6.Text = "CGST"
                            .Type_of_Duty_TXT.Text = $"CGST@{Val(Val(GST_Per) / 2)}%"

                            .close_focus_obj = obj.Amount_TXT
                            .close_link_yn = False
                            .Group_TXT.Text = $"Duties & Taxes"
                            .Name_TXT.Text = $"CGST@{Val(Val(GST_Per) / 2)}%"

                        End With
                    Else

                    End If
                    Exit Sub
                End If
                If SGST_TXT.Text = "" Then
                    If Msg_Custom_YN(NOT_Location.Bottom_Right, Color.Red, My.Resources.Warning_animation_icn, Dialoag_Button.Yes_No, "Error", "SGST/UTGST Not Found", "Ledger account of SGST/UTGST is not created,<nl>so you cannot add SGST/UTGST.<nl><nl>Do you want to create a SGST/UTGST account?") = DialogResult.Yes Then
                        Cell("Account Ledger", "", "Create_Close", "")

                        With Ledger_frm
                            .Txt5.Text = "GST"
                            .Txt6.Text = "SGST/UTGST"
                            .Type_of_Duty_TXT.Text = $"SGST/UTG ST@{Val(Val(GST_Per) / 2)}%"

                            .close_focus_obj = obj.Amount_TXT
                            .close_link_yn = False
                            .Group_TXT.Text = $"Duties & Taxes"
                            .Name_TXT.Text = $"SGST/UTGST@{Val(Val(GST_Per) / 2)}%"

                        End With
                    Else

                    End If
                    Exit Sub
                End If
            ElseIf TAX_Type = "I" Then
                If IGST_TXT.Text = "" Then
                    If Msg_Custom_YN(NOT_Location.Bottom_Right, Color.Red, My.Resources.Warning_animation_icn, Dialoag_Button.Yes_No, "Error", "IGST Not Found", "Ledger account of IGST is not created,<nl>so you cannot add IGST.<nl><nl>Do you want to create a IGST account?") = DialogResult.Yes Then
                        Cell("Account Ledger", "", "Create_Close", "")

                        With Ledger_frm
                            .Txt5.Text = "GST"
                            .Txt6.Text = "IGST"
                            .Type_of_Duty_TXT.Text = $"IGST@{Val(Val(GST_Per))}%"

                            .close_focus_obj = obj.Amount_TXT
                            .close_link_yn = False
                            .Group_TXT.Text = $"Duties & Taxes"
                            .Name_TXT.Text = $"IGST@{Val(Val(GST_Per))}%"

                        End With
                    Else

                    End If
                    Exit Sub
                End If
            End If
        End If



        With obj


            .Discription_Label.Text = Txt1.Text
            .GST_Per = Val(Label26.Text) + Val(Label25.Text) + Val(Label24.Text)
            .GST_Amount = nUmBeR_FORMATE(Val(Label19.Text) - Val(Label35.Text))
            .Head_Account_ID = Head_Acc_ID
            .Cess_Per = Label33.Text
            .Cess_Amount = Label35.Text

            .CGST_ID = CGST_ID
            .SGST_ID = SGST_ID
            .IGST_ID = IGST_ID
            .Cess_ID = Cess_ID

            .Obj.Vc_GST_summary_ctrl1.Refresh_Data_()
        End With

        Me.Dispose()
        SendKeys.Send("{TAB}")
    End Sub

    Private Sub Button1_KeyDown(sender As Object, e As KeyEventArgs) Handles Button1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1_Click(e, e)
        End If
        If e.KeyCode = Keys.Back Then
            SendKeys.Send("+{TAB}")
        End If
    End Sub

    Private Sub Txt1_LostFocus(sender As Object, e As EventArgs) Handles Txt2.LostFocus
        sender.Enabled = False
    End Sub

    Private Sub Txt3_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt3.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Ledger_list.List_Grid.CurrentRow.Cells(2).Value = "Create" Then
                Cell("Account Ledger", "", "Create_Close", "")

                With Ledger_frm
                    .close_focus_obj = sender
                    .Group_TXT.Text = $"{Filter_Format} Account"

                    If YN_Boolean(Inventory_Vouchers_frm.cfg_YN_GST) = True Then
                        .Txt5.Text = "GST"
                        If Val(GST_Per) = 0 Then
                            If Tax_Type_Item = "Exempt" Then
                                .Type_of_Duty_TXT.Text = $"{Filter_Format.ToUpper} EXEMPT"
                                .Name_TXT.Text = $"{Filter_Format} GST@EXEMPT"
                            ElseIf Tax_Type_Item = "Nil Rated" Then
                                .Type_of_Duty_TXT.Text = $"{Filter_Format.ToUpper} NILL RATED"
                                .Name_TXT.Text = $"{Filter_Format} GST@NILL RATED"

                            Else
                                .Type_of_Duty_TXT.Text = $"{Filter_Format.ToUpper} GST@0%"
                                .Name_TXT.Text = $"{Filter_Format} GST@0%"
                            End If
                        Else
                            .Type_of_Duty_TXT.Text = $"{Filter_Format.ToUpper} GST@{nUmBeR_FORMATE(GST_Per)}%"
                            .Name_TXT.Text = $"{Filter_Format} GST@{nUmBeR_FORMATE(GST_Per)}%"

                        End If
                    Else
                        .Txt5.Text = "Not Applicable"
                        .Name_TXT.Text = $"{Filter_Format} WITHOUT GST"
                    End If
                End With
                SendKeys.Send("{Escape}")
            Else
                Head_Acc_ID = Ledger_list.List_Grid.CurrentRow.Cells(2).Value

                If GST_YN = True And Item_GST_Type = "Taxable" Then

                    If Cess_Per <> 0 Then
                        Cess_ID = Find_DT_Value(Database_File.cre, "TBL_Ledger", "ID", $"Visible = 'Approval' and TAX_Type = 'GST' and TAX_Class = 'Cess'")
                        Cess_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Name", $"ID = '{Cess_ID}'")
                    Else
                        Cess_ID = ""
                        Cess_TXT.Text = ""
                    End If

                    If TAX_Type = "CS" Then
                        CGST_ID = Find_DT_Value(Database_File.cre, "TBL_Ledger", "ID", $"Visible = 'Approval' and TAX_Type = 'GST' and TAX_Class = 'CGST' and PercentageOfCalculation = '{nUmBeR_FORMATE(nUmBeR_FORMATE(GST_Per) / 2)}'")
                        SGST_ID = Find_DT_Value(Database_File.cre, "TBL_Ledger", "ID", $"Visible = 'Approval' and TAX_Type = 'GST' and TAX_Class = 'SGST/UTGST' and PercentageOfCalculation = '{nUmBeR_FORMATE(nUmBeR_FORMATE(GST_Per) / 2)}'")

                        CGST_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Name", $"ID = '{CGST_ID}'")
                        SGST_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Name", $"ID = '{SGST_ID}'")

                    Else
                        IGST_ID = Find_DT_Value(Database_File.cre, "TBL_Ledger", "ID", $"Visible = 'Approval' and TAX_Type = 'GST' and TAX_Class = 'IGST' and PercentageOfCalculation = '{nUmBeR_FORMATE(GST_Per)}'")
                        IGST_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Name", $"ID = '{IGST_ID}'")
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub Txt3_TextChanged(sender As Object, e As EventArgs) Handles Txt3.TextChanged

    End Sub

    Private Sub Txt3_Enter(sender As Object, e As EventArgs) Handles Txt3.Enter
        'If Ledger_list.List_Grid.Rows.Count = 1 Then
        '    SendKeys.Send("{Enter}")
        'End If
    End Sub

    Private Sub Label24_Click(sender As Object, e As EventArgs) Handles Label24.Click

    End Sub

    Private Sub Label33_Click(sender As Object, e As EventArgs) Handles Label33.Click

    End Sub

    Private Sub Label33_TextChanged(sender As Object, e As EventArgs) Handles Label33.TextChanged
        Label35.Text = nUmBeR_FORMATE((Val(SUB_Total) * Val(sender.Text)) / 100)
    End Sub

    Private Sub Label19_Click(sender As Object, e As EventArgs) Handles Label19.Click

    End Sub

    Private Sub Txt1_TextChanged(sender As Object, e As EventArgs) Handles Txt1.TextChanged

    End Sub

    Private Sub Panel10_Paint(sender As Object, e As PaintEventArgs) Handles Panel10.Paint

    End Sub
End Class
