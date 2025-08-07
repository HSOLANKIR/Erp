Imports System.Data.SqlClient
Imports System.Data.SQLite
Imports Tools
Public Class cprj_controls
    Dim Vc_Type As String = ""
    Dim Ledger_List_Value As String = ""
    Private Sub cprj_controls_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim int As Integer = Me.Width

    End Sub

    Private Sub Txt2_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then

        End If
    End Sub
    Public curr_count As Integer = 0
    Dim focus_count As Integer = 0
    Public Color_bg As Color
    Public Function Add_New()
        Dim bg_p As Panel = New Panel
        Dim particuls_p As Panel = New Panel
        Dim Bal_p As Panel = New Panel
        'Panel4
        curr_count = bg_panel.Controls.OfType(Of Panel).ToList.Count
        focus_count += 1
        '
        bg_p.AutoSize = True
        bg_p.Controls.Add(Bal_p)
        bg_p.Controls.Add(particuls_p)
        bg_p.Dock = DockStyle.Top
        bg_p.Location = New Point(0, 0)
        bg_p.Name = "bg_" & (curr_count + 1)
        bg_p.Size = New Size(903, 20)
        bg_p.TabIndex = focus_count


        'Particuls_Panel
        Particuls_Panel_fun(particuls_p)
        Bal_Panel_fun(Bal_p)

        bg_panel.Controls.Add(bg_p)
        bg_p.BringToFront()

        If curr_count = 1 Then
            Fill_Particuls_data(False)
        End If

        List_set(curr_count + 1)



        Color_manag()
    End Function
    Public Function Color_manag()
        Me.BackColor = Color_bg
    End Function

    Private Function Qry_Filters() As String
        Dim q As String = ""
        With Accounting_Voucher_frm
            q &= $" and (vc.Visible = 'Approval')"
            'q &= $" and (vc.Type = 'Head')"
            q &= $" and (vc.[Date] <= '{CDate(.Date_TXT.Text).AddDays(1).ToString(Lite_date_Format)}')"

            If .Branch_ID <> 0 Then
                q &= " AND VC.Branch = '" & .Branch_ID & "'"
            End If

            If .VC_Type_ = "Alter" Or .VC_Type_ = "Alter_Close" Then
                q &= $" and (vc.Tra_ID <> '{ .Tra_ID}')"
            End If

        End With

        Return q
    End Function

    Public Function Fill_Particuls_data(if_frist As Boolean)
        Dim Positive As String = Find_DT_Value(Database_File.cmp, "TBL_Features", "Value", "Head = 'Positive Value'")
        Dim Negative As String = Find_DT_Value(Database_File.cmp, "TBL_Features", "Value", "Head = 'Negative Value'")


        Dim dt_particuls As New DataTable
        dt_particuls.Columns.Clear()
        dt_particuls.Columns.Add("Name")
        dt_particuls.Columns.Add("Curr. Balance")
        dt_particuls.Columns.Add("ID")
        dt_particuls.Columns.Add("Alias")
        dt_particuls.Columns.Add("Group")
        dt_particuls.Columns.Add("Curr. Credit")
        dt_particuls.Columns.Add("Color")
        dt_particuls.Columns.Add("balance_")

        dt_particuls.Rows.Add("", "Create")

        If if_frist = False Then
            dt_particuls.Rows.Add("End of List", "", "")
        End If

        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            Dim r As SQLiteDataReader
            cmd = New SQLiteCommand($"Select [ID],[Name],[Group],[Alise],[Cradit],
(Select ifnull((Select ifnull(SUM(vc.Cr),0)-ifnull(SUM(vc.Dr),0) From TBL_VC_Ledger vc Where vc.Ledger = LD.ID and vc.[Date] <= '{CDate(Accounting_Voucher_frm.Date_TXT.Text).AddDays(1).ToString(Lite_date_Format)}' and vc.Tra_ID <> '{Accounting_Voucher_frm.Tra_ID}'),0)+ifnull((Select ifnull(sum(lob.OB_Cr),0)-ifnull(sum(lob.OB_Dr),0) From TBL_Ledger_Opning_Balance lob where lob.Ledger_ID = LD.ID and lob.Branch_ID = '{Accounting_Voucher_frm.Branch_ID}'),0)) as Bal_
from TBL_Ledger LD where " & Company_Visible_Filter, cn)

            With cmd.Parameters
                .AddWithValue("@Filter_Date", CDate(Accounting_Voucher_frm.Date_TXT.Text).AddDays(1).ToString(Lite_date_Format))
                r = cmd.ExecuteReader

                'My.Computer.Clipboard.SetText(cmd.CommandText)
                While r.Read
                    Dim Vlu_ As String
                    Vlu_ = r("Bal_").ToString

                    If Val(Vlu_) > 0 Then
                        Vlu_ = N2_FORMATE(Val(Vlu_)) & " " & Positive
                    ElseIf Val(Vlu_) < 0 Then
                        Vlu_ = N2_FORMATE(Vlu_ * -1) & " " & Negative
                    Else
                        Vlu_ = ""
                    End If

                    Dim Credit_ As String
                    Dim Color_ As String
                    Credit_ = Val(r("Cradit").ToString) - Val(r("Bal_").ToString)
                    If Val(Credit_) < 0 Then
                        Color_ = "Red"
                    ElseIf Val(Credit_) > 0 Then
                        Color_ = "Black"
                    Else
                        Credit_ = ""
                        Color_ = "Black"
                    End If

                    If Accounting_Voucher_frm.Voucher_Type_LB.Text = "Payment" Or Accounting_Voucher_frm.Voucher_Type_LB.Text = "Receipt" Or Accounting_Voucher_frm.Voucher_Type_LB.Text = "Credit Note" Or Accounting_Voucher_frm.Voucher_Type_LB.Text = "Debit Note" Then
                        If r("Group") <> "17" And r("Group") <> "27" And r("Group") <> "28" Then
                            dt_particuls.Rows.Add(r("Name"), Vlu_, r("ID"), r("Alise"), r("Group"), Credit_, Color_, Val(r("Bal_").ToString) * 1)
                        End If
                    ElseIf Accounting_Voucher_frm.Voucher_Type_LB.Text = "Contra" Then
                        If r("Group") = "17" Or r("Group") = "27" Or r("Group") = "28" And (r("Group") <> "7") Then
                            dt_particuls.Rows.Add(r("Name"), Vlu_, r("ID"), r("Alise"), r("Group"), Credit_, Color_, Val(r("Bal_").ToString) * 1)
                        End If
                    ElseIf Vc_Type = "Journal" Then
                        dt_particuls.Rows.Add(r("Name"), Vlu_, r("ID"), r("Alise"), r("Group"), Credit_, Color_, Val(r("Bal_").ToString) * 1)
                    End If
                End While
                BindingSource1.DataSource = dt_particuls
            End With
        End If
    End Function
    Private Function Bal_Panel_fun(pan As Panel)
        Dim bal_ As Label = New Label
        Dim val_display As Label = New Label
        Dim credit_ As Label = New Label

        'balpan_
        '
        pan.Controls.Add(val_display)
        pan.Controls.Add(bal_)
        pan.Controls.Add(credit_)
        pan.Dock = DockStyle.Top
        pan.Location = New Point(0, 17)
        pan.Name = "BalPan_" & (curr_count + 1)
        pan.Size = New Size(903, 22)
        pan.TabIndex = 1
        pan.Visible = True

        credit_.Name = "creditcurr_" & (curr_count + 1)
        credit_.Visible = False


        'balval_
        '
        val_display.Dock = DockStyle.Left
        val_display.Font = New Font("Arial", 10.0, CType((FontStyle.Italic), FontStyle), GraphicsUnit.Point, CType(0, Byte))
        val_display.Location = New Point(96, 0)
        val_display.Name = "BalValLab_" & (curr_count + 1)
        val_display.Size = New Size(266, 17)
        val_display.TabIndex = 3
        val_display.Text = ""
        val_display.TextAlign = ContentAlignment.TopLeft

        'ballab_
        '
        bal_.Dock = DockStyle.Left
        bal_.Font = New Font("Arial", 10.0, FontStyle.Italic, GraphicsUnit.Point, CType(0, Byte))
        bal_.Location = New Point(0, 0)
        bal_.Name = "BalLab_" & (curr_count + 1)
        bal_.Size = New Size(96, 17)
        bal_.TabIndex = 2
        bal_.Text = "Cur. Bal. :"
        bal_.TextAlign = ContentAlignment.TopRight
    End Function
    Private Function Particuls_Panel_fun(pan As Panel)
        Dim amt_ As TXT = New TXT
        Dim acc_ As TXT = New TXT

        'particuls_panel
        '
        pan.Controls.Add(amt_)
        pan.Controls.Add(acc_)
        pan.Dock = DockStyle.Top
        pan.Location = New Point(0, 0)
        pan.Name = "AccPan_" & (curr_count + 1)
        pan.Size = New Size(903, 16)
        pan.TabIndex = 0
        pan.BackColor = Color_bg
        AddHandler pan.Enter, AddressOf bg_panel_Enter
        AddHandler pan.Leave, AddressOf bg_panel_Leave

        'amttxt_
        '
        amt_.Back_color = Color_bg
        amt_.BackColor = Color_bg
        amt_.BorderStyle = BorderStyle.None
        amt_.Data_Link_ = ""
        amt_.Decimal_ = 2
        amt_.Dock = DockStyle.Right
        amt_.Font = New Font("Arial", 10.0, FontStyle.Bold)
        amt_.Format_ = "dd-MM-yyyy"
        amt_.Keydown_Support = True
        amt_.Location = New Point(792, 0)
        amt_.Name = "AmtTxt_" & (curr_count + 1)
        amt_.Size = New Size(111, 17)
        amt_.TabIndex = 2
        amt_.Type_ = "Num"
        amt_.Enabled = False
        amt_.TextAlign = HorizontalAlignment.Right
        AddHandler amt_.Enter, AddressOf Amount_Enter
        AddHandler amt_.KeyDown, AddressOf Amount_Keydown
        AddHandler amt_.LostFocus, AddressOf Amt_Lostfocus

        'Txt1

        acc_.Back_color = Color_bg
        acc_.BackColor = Color_bg
        acc_.BorderStyle = BorderStyle.None
        acc_.Data_Link_ = ""
        acc_.Decimal_ = 1
        acc_.Dock = DockStyle.Left
        acc_.Font = New Font("Arial", 10.0, FontStyle.Bold)
        acc_.Format_ = "dd-MM-yyyy"
        acc_.Keydown_Support = True
        acc_.Location = New Point(0, 0)
        acc_.Name = "AccTxt_" & (curr_count + 1)
        acc_.Size = New Size(437, 17)
        acc_.TabIndex = 1
        acc_.Type_ = "Select"
        acc_.Select_Columns = 0
        acc_.Select_Auto_Show = False
        acc_.Select_Source = BindingSource1
        acc_.Select_Filter = Filter_()


        AddHandler acc_.TextChanged, AddressOf Particuls_Enter_TextChanged
        AddHandler acc_.Enter, AddressOf Particuls_Enter
        AddHandler acc_.LostFocus, AddressOf Particuls_Lostfocus
        AddHandler acc_.KeyDown, AddressOf Particuls_Keydown

    End Function
    Dim acc_list As List_frm
    Private Function List_set(idx As Integer)
        Dim tx As TXT = Find_Particuls_TXT(idx)

        acc_list = New List_frm
        List_Setup("List of Ledger", Select_List.Right_Dock, Select_List_Format.Defolt, tx, acc_list, BindingSource1, 400)
        acc_list.Set_COlor(6)
        acc_list.System_Data_integer = 1

    End Function

    Private Sub Amount_Keydown(sender As Object, e As KeyEventArgs)
        Dim TX_ As TXT = CType(sender, TXT)
        Dim index As Integer = Integer.Parse(TX_.Name.Split("_")(1))

        If e.KeyCode = Keys.Enter Then
            If Val(sender.Text) = 0 Then
                If Find_Particuls_TXT(index).Data_Link_ <> Nothing Then
                    e.SuppressKeyPress = True
                    NOT_("Please enter amount (value), and try again", NOT_Type.Warning)
                    sender.Text = ""
                    If Accounting_Voucher_frm.cfg_YN_zero = False Then
                        sender.Focus()
                        Exit Sub
                    End If
                End If
            Else
                If Accounting_Voucher_frm.cfg_warning__credil_expiar = True Then
                    Dim curr As Decimal = 0
                    If Accounting_Voucher_frm.Voucher_Type_LB.Text = "Payment" Then
                        curr = Val(Find_Amount_TXT(index).Text) * -1
                        Dim credit As String = Val(Find_Credit_curr_TXT(index).Text) + Val(curr)
                        If credit < 0 Then
                            If Msg_Credit_Warning_Dialoag(Find_Particuls_TXT(index).Text, credit) = DialogResult.Yes Then
                                SendKeys.Send("{TAB}")
                            Else
                                sender.Focus()
                            End If
                        End If
                    End If
                End If
            End If

            NOT_Clear()

            If bg_panel.Controls.Count = index Then
                If Find_Particuls_TXT(index).Data_Link_ <> Nothing Then
                    Add_New()
                    'SelectNextControl(Find_Amount_TXT(index), True, True, True, True)
                Else
                    'Accounting_Voucher_frm.SelectNextControl(Me, True, True, True, True)
                End If
            Else
                'SelectNextControl(Find_Amount_TXT(index), True, True, True, True)
            End If

        End If
    End Sub
    Private Sub Particuls_Keydown(sender As Object, e As KeyEventArgs)
        Dim index As Integer = Find_Idx(sender)
        If e.KeyCode = Keys.Enter Then
            If acc_list.List_Grid.CurrentRow.Cells(1).Value = "Create" Then
                Create_Cash_Ledger(sender)
                Exit Sub
            End If
            sender.Data_Link_ = acc_list.List_Grid.CurrentRow.Cells(2).Value.ToString
        End If

        If e.KeyCode = Keys.C AndAlso e.Modifiers = Keys.Alt Then
            Create_Cash_Ledger(sender)
        ElseIf e.KeyCode = Keys.Enter AndAlso e.Modifiers = Keys.Control Then
            Cell("Account Ledger", "", "Alter_Close", Find_Particuls_TXT(index).Data_Link_)
            Ledger_frm.close_focus_obj = sender
            e.Handled = True
            Exit Sub
        ElseIf e.KeyCode = Keys.Enter Then
            Find_Balance_Lab_TXT(index).Tag = Val(acc_list.List_Grid.CurrentRow.Cells(7).Value.ToString)
            Find_Credit_curr_TXT(index).Text = Val(acc_list.List_Grid.CurrentRow.Cells(5).Value.ToString)


            If Find_Particuls_TXT(index).Data_Link_ = Nothing Then
                Find_Amount_TXT(index).Enabled = False
                Find_Amount_TXT(index).Text = ""

                Find_balance_Panel(index).Visible = False
            Else
                Find_Amount_TXT(index).Enabled = True
                Find_balance_Panel(index).Visible = True
            End If
            fill_balance(sender)
        End If
    End Sub

    Private Function Create_Cash_Ledger(sender As TXT)
        Cell("Account Ledger", "", "Create_Close", "")
        Ledger_frm.Name_TXT.Text = sender.Text
        Ledger_frm.close_focus_obj = sender
    End Function
    Dim Fiter_String As String
    Public Function fill_balance(sender As Object)
        Vc_Type = Accounting_Voucher_frm.Voucher_Type_LB.Text
        Dim idx As Integer = Find_Idx(sender)

        Dim Positive As String = Positive_Value_fech
        Dim Negative As String = Negative_Value_fech


        With Accounting_Voucher_frm
            If .VC_Type_ = "Alter" Or .VC_Type_ = "Alter_Close" Then
                'Find_Balance_curr_TXT(idx).Text = Ledger_Balance(Find_AccID_TXT(idx).Text, CDate(.Date_TXT.Text), .Tra_ID, .Branch_ID)
            Else
                'Find_Balance_curr_TXT(idx).Text = Ledger_Balance(Find_AccID_TXT(idx).Text, CDate(.Date_TXT.Text), "0", .Branch_ID)
            End If
        End With

        'Find_Balance_Lab_TXT(idx).Text = Val(Find_Balance_curr_TXT(idx).Text) * -1


        If Accounting_Voucher_frm.Voucher_Type_LB.Text = "Payment" Then
            Find_Balance_Lab_TXT(idx).Text = nUmBeR_FORMATE(Val(Find_Balance_Lab_TXT(idx).Tag) - Val(Find_Amount_TXT(idx).Text))
        Else
            Find_Balance_Lab_TXT(idx).Text = nUmBeR_FORMATE(Val(Find_Balance_Lab_TXT(idx).Tag) + Val(Find_Amount_TXT(idx).Text))
        End If


        If Val(Find_Balance_Lab_TXT(idx).Text) >= 0 Then
            Find_Balance_Lab_TXT(idx).ForeColor = Color.Green
            Find_Balance_Lab_TXT(idx).Text = N2_FORMATE(Find_Balance_Lab_TXT(idx).Text) & " " & Positive
        Else
            Find_Balance_Lab_TXT(idx).ForeColor = Color.Red
            Dim vlu As Decimal = Val(Find_Balance_Lab_TXT(idx).Text)

            vlu *= -1

            Find_Balance_Lab_TXT(idx).Text = N2_FORMATE(vlu) & " " & Negative
        End If

        'MsgBox(Find_Balance_Lab_TXT(idx).Text)
    End Function
    Private Function Filter_() As String
        Vc_Type = Accounting_Voucher_frm.Voucher_Type_LB.Text
        Dim end_of_if_filter As String

        end_of_if_filter = "or Name = 'End of List'"

        Return "(Name LIKE '%<value>%' or Alias LIKE '%<value>%' or [Curr. Balance] LIKE 'Create')" & Fiter_String
    End Function
    Private Sub Amt_Lostfocus(sender As Object, e As EventArgs)
        fill_balance(sender)
        Shado_Color_(sender)
    End Sub
    Private Sub Particuls_Lostfocus(sender As Object, e As EventArgs)
        BindingSource1.MoveFirst()
    End Sub

    Private Sub Amount_Enter(sender As Object, e As EventArgs)
        Shado_Color_(sender)
    End Sub
    Public Shado_Color As Color = Color.FromArgb(255, 238, 178)
    Public Function Shado_Color_(sender As Object)
        Dim vlu As Decimal = 0.00
        For Each bg_p As Panel In bg_panel.Controls.OfType(Of Panel)()
            If bg_p.Visible = True Then
                vlu += Val(Find_Amount_TXT(bg_p.Name.Split("_")(1)).Text)
            End If
        Next

        Total_lab.Text = nUmBeR_FORMATE(vlu)

        Dim index As Integer = sender.Name.Split("_")(1)
    End Function
    Public Function Find_BG_Panel(Index As Integer) As Panel
        Try
            Return CType(bg_panel.Controls.Find(("bg_" & Index), True).First, Panel)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Particuls_Panel(Index As Integer) As Panel
        Try
            Dim Pan1_ As Panel = CType(bg_panel.Controls.Find(("bg_" & Index), True).First, Panel)
            Return CType(Pan1_.Controls.Find(("AccPan_" & Index), True).First, Panel)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_balance_Panel(Index As Integer) As Panel
        Try
            Dim Pan1_ As Panel = CType(bg_panel.Controls.Find(("bg_" & Index), True).First, Panel)
            Return CType(Pan1_.Controls.Find(("BalPan_" & Index), True).First, Panel)
        Catch ex As Exception

        End Try
    End Function

    Public Function Find_Particuls_TXT(Index As Integer) As TXT
        Try
            Dim Pan1_ As Panel = CType(bg_panel.Controls.Find(("bg_" & Index), True).First, Panel)
            Return CType(Pan1_.Controls.Find(("AccTxt_" & Index), True).First, TXT)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Amount_TXT(Index As Integer) As TXT
        Try
            Dim Pan1_ As Panel = CType(bg_panel.Controls.Find(("bg_" & Index), True).First, Panel)
            Return CType(Pan1_.Controls.Find(("AmtTxt_" & Index), True).First, TXT)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Narration_TXT(Index As Integer) As TXT
        Try
            Dim Pan1_ As Panel = CType(bg_panel.Controls.Find(("bg_" & Index), True).First, Panel)
            Return CType(Pan1_.Controls.Find(("Narrationtxt_" & Index), True).First, TXT)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Balance_Lab_TXT(Index As Integer) As Label
        Try
            Dim Pan1_ As Panel = CType(bg_panel.Controls.Find(("bg_" & Index), True).First, Panel)
            Return CType(Pan1_.Controls.Find(("BalValLab_" & Index), True).First, Label)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Credit_curr_TXT(Index As Integer) As Label
        Try
            Dim Pan1_ As Panel = CType(bg_panel.Controls.Find(("bg_" & Index), True).First, Panel)
            Return CType(Pan1_.Controls.Find(("creditcurr_" & Index), True).First, Label)
        Catch ex As Exception

        End Try
    End Function

    Public Function Select_Currant(TXT As String)
        Try
            If List_frm.Visible = True Then
                For i As Integer = 0 To List_frm.List_Grid.Rows.Count - 1
                    Dim ro As DataGridViewRow = List_frm.List_Grid.Rows(i)
                    If ro.Cells(1).Value = TXT Then
                        List_frm.List_Grid.CurrentCell = List_frm.List_Grid.Rows(i).Cells(1)
                        Exit For
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Idx(sender As Object) As Integer
        Return sender.Name.Split("_")(1)
    End Function
    Private Sub Particuls_Enter_TextChanged(sender As Object, e As EventArgs)

    End Sub
    Private Sub Particuls_Enter(sender As Object, e As EventArgs)

    End Sub
    Private Sub cprj_controls_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        Vc_Type = Accounting_Voucher_frm.Voucher_Type_LB.Text
        Ledger_List_Value = Find_DT_Value(Database_File.lnk, "cfg_Vouchers", "Value", "[Name] = 'List Display Value'")


        If curr_count >= 1 Then
            Fill_Particuls_data(False)
        Else
            Fill_Particuls_data(True)
        End If
    End Sub

    Private Sub Txt1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Total_lab_TextChanged(sender As Object, e As EventArgs) Handles Total_lab.TextChanged
        Label3.Text = NumberToText(Val(Total_lab.Text))
        Try
            Accounting_Voucher_frm.Closing_Balance_Set()
            Accounting_Voucher_frm.TOTAL_AMOUNT_VALUE = Val(Total_lab.Text)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub bg_panel_Enter(sender As Object, e As EventArgs)
        Dim col As Color = Color.FromArgb(254, 237, 194)
        'RGB(254, 237, 194)
        sender.BackColor = col
        Dim idx As Integer = Find_Idx(sender)

        Find_Particuls_TXT(idx).Back_color = col
        Find_Amount_TXT(idx).Back_color = col

        Find_Particuls_TXT(idx).BackColor = col
        Find_Amount_TXT(idx).BackColor = col

    End Sub
    Private Sub bg_panel_Leave(sender As Object, e As EventArgs)
        Dim col As Color = Panel5.BackColor
        sender.BackColor = col

        Dim idx As Integer = Find_Idx(sender)
        Find_Particuls_TXT(idx).Back_color = col
        Find_Amount_TXT(idx).Back_color = col

        Find_Particuls_TXT(idx).BackColor = col
        Find_Amount_TXT(idx).BackColor = col
    End Sub

    Private Sub Total_lab_Click(sender As Object, e As EventArgs) Handles Total_lab.Click

    End Sub
End Class
