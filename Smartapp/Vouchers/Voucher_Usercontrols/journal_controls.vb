Imports System.Data.SqlClient
Imports System.Data.SQLite
Imports Tools
Public Class journal_controls
    Dim Ledger_List_Value As String = ""
    Private Sub journal_controls_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Label2.Width = 110
        'Label3.Width = 110

        'Panel7.Width = 225
        'Panel1.Height = 21

        Data_List_Fill()
    End Sub
    Dim curr_count As Integer = 0
    Public Color_bg As Color = Color_bg
    Public Function Add_New()
        curr_count = bg_panel.Controls.OfType(Of Panel).ToList.Count
        Dim bg_p As Panel = New Panel
        Dim particals_panel As Panel = New Panel
        Dim Balance_panel As Panel = New Panel

        'bg_panel
        bg_p.Controls.Add(particals_panel)
        bg_p.Controls.Add(Balance_panel)
        bg_p.Dock = DockStyle.Top
        bg_p.Location = New Point(0, 0)
        bg_p.Name = "bg_" & (curr_count + 1)
        bg_p.Size = New Size(903, 37)
        bg_p.TabIndex = curr_count


        Particuls_Panel_ctrl(particals_panel)
        Balance_Panel_ctrl(Balance_panel)

        bg_panel.Controls.Add(bg_p)
        bg_p.BringToFront()

        List_set(curr_count + 1)

        Me.BackColor = Color_bg
    End Function
    Dim acc_list As List_frm
    Dim typ_list As List_frm
    Private Function List_set(idx As Integer)
        Dim tx As TXT = Find_Particuls_TXT(idx)

        acc_list = New List_frm
        List_Setup("List of Ledger", Select_List.Right_Dock, Select_List_Format.Defolt, tx, acc_list, BindingSource1, 400)
        acc_list.Set_COlor(6)
        acc_list.System_Data_integer = 1


        tx = Find_crdr_TXT(idx)

        typ_list = New List_frm
        List_Setup("Cr/Dr", Select_List.Right, Select_List_Format.Singel, tx, typ_list, BindingSource2, 100)

    End Function
    Private Function Balance_Panel_ctrl(Pan As Panel)
        Dim Bal_val As Label = New Label
        Dim Bal_lab As Label = New Label


        'balancepanel_
        '
        Pan.Controls.Add(Bal_val)
        Pan.Controls.Add(Bal_lab)
        Pan.Dock = DockStyle.Top
        Pan.Location = New Point(0, 16)
        Pan.Name = "balancepanel_" & (curr_count + 1)
        Pan.Size = New Size(903, 16)
        Pan.TabIndex = 1
        Pan.Visible = True
        Pan.BringToFront()

        'BalValue_
        '
        Bal_val.AutoSize = True
        Bal_val.Dock = DockStyle.Left
        Bal_val.Font = New Font("Arial", 9.75, FontStyle.Italic Or FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        Bal_val.ForeColor = Color.DimGray
        Bal_val.Location = New Point(130, 0)
        Bal_val.Name = "BalValue_" & (curr_count + 1)
        Bal_val.Size = New Size(130, 17)
        Bal_val.TabIndex = 3
        Bal_val.Text = "0"
        Bal_val.TextAlign = ContentAlignment.MiddleLeft
        Bal_val.BringToFront()


        'BalLabel_
        '
        Bal_lab.Dock = DockStyle.Left
        Bal_lab.Font = New Font("Arial", 10, FontStyle.Italic, GraphicsUnit.Point, CType(0, Byte))
        Bal_lab.ForeColor = Color.DimGray
        Bal_lab.Location = New Point(0, 0)
        Bal_lab.Name = "BalLabel_" & (curr_count + 1)
        Bal_lab.Padding = New Padding(20, 0, 0, 0)
        Bal_lab.Size = New Size(120, 16)
        Bal_lab.TabIndex = 2
        Bal_lab.Text = "Cur Bal. :"
        Bal_lab.TextAlign = ContentAlignment.TopRight
    End Function
    Private Function Particuls_Panel_ctrl(Pan As Panel)
        Dim drcr_txt As TXT = New TXT
        Dim particuls_txt As TXT = New TXT
        Dim dr_txt As TXT = New TXT
        Dim cr_txt As TXT = New TXT

        Dim balcurr_ As Label = New Label


        Pan.Controls.Add(particuls_txt)
        Pan.Controls.Add(dr_txt)
        Pan.Controls.Add(cr_txt)
        Pan.Controls.Add(drcr_txt)

        Pan.Controls.Add(balcurr_)
        Pan.Dock = DockStyle.Top
        Pan.Location = New Point(0, 0)
        Pan.Name = "ParticulsPanel_" & (curr_count + 1)
        Pan.Size = New Size(903, 16)
        Pan.TabIndex = 0
        Pan.BackColor = Color_bg
        AddHandler Pan.Enter, AddressOf bg_panel_Enter
        AddHandler Pan.Leave, AddressOf bg_panel_Leave



        balcurr_.Name = "balcurr_" & (curr_count + 1)
        balcurr_.Visible = False



        'crdrtxt_
        '
        drcr_txt.Back_color = Color_bg
        drcr_txt.BackColor = Color_bg
        drcr_txt.BorderStyle = BorderStyle.None
        drcr_txt.Data_Link_ = ""
        drcr_txt.Dock = DockStyle.Left
        drcr_txt.Font = New Font("Arial", 10, FontStyle.Regular)
        drcr_txt.Keydown_Support = True
        drcr_txt.Location = New Point(0, 0)
        drcr_txt.Name = "crdrtxt_" & (curr_count + 1)
        drcr_txt.Size = New Size(35, 16)
        drcr_txt.TabIndex = 0
        drcr_txt.Text = ""
        drcr_txt.Select_Filter = "(Name LIKE '%<value>%')"
        drcr_txt.Type_ = "Select"
        drcr_txt.ReadOnly = True
        AddHandler drcr_txt.Enter, AddressOf All_Enter
        AddHandler drcr_txt.KeyPress, AddressOf crdr_keyPress
        AddHandler drcr_txt.TextChanged, AddressOf crdr_TextChanged
        AddHandler drcr_txt.LostFocus, AddressOf Particuls_Lostfocus

        'particulstxt_
        '
        particuls_txt.Back_color = Color_bg
        particuls_txt.BackColor = Color_bg
        particuls_txt.BorderStyle = BorderStyle.None
        particuls_txt.Data_Link_ = ""
        particuls_txt.Dock = DockStyle.Left
        particuls_txt.Font = New Font("Arial", 10, FontStyle.Regular)
        particuls_txt.Keydown_Support = True
        particuls_txt.Location = New Point(35, 0)
        particuls_txt.Name = "particulstxt_" & (curr_count + 1)
        particuls_txt.Size = New Size(430, 16)
        particuls_txt.TabIndex = 1
        particuls_txt.Text = ""
        particuls_txt.Type_ = "Select"
        particuls_txt.Select_Auto_Show = False
        particuls_txt.Select_Filter = "(Name LIKE '%<value>%') or [Curr. Balance] LIKE 'Create'"
        particuls_txt.Select_Source = BindingSource1
        particuls_txt.Select_Columns = 0
        particuls_txt.Enabled = False

        AddHandler particuls_txt.Enter, AddressOf All_Enter
        AddHandler particuls_txt.Enter, AddressOf Particuls_Enter
        AddHandler particuls_txt.LostFocus, AddressOf Particuls_Lostfocus
        AddHandler particuls_txt.KeyDown, AddressOf Particuls_Keydown


        'drtxt_
        '
        dr_txt.Back_color = Color_bg
        dr_txt.BackColor = Color_bg
        dr_txt.BorderStyle = BorderStyle.None
        dr_txt.Data_Link_ = ""
        dr_txt.Dock = DockStyle.Right
        dr_txt.Font = New Font("Arial", 10, FontStyle.Regular)
        dr_txt.Keydown_Support = False
        dr_txt.Location = New Point(647, 0)
        dr_txt.Name = "drtxt_" & (curr_count + 1)
        dr_txt.Size = Label2.Size
        dr_txt.TabIndex = 2
        dr_txt.Text = ""
        dr_txt.TextAlign = HorizontalAlignment.Right
        dr_txt.Type_ = "Num"
        dr_txt.Enabled = False
        AddHandler dr_txt.KeyDown, AddressOf Amount_Keydown
        AddHandler dr_txt.LostFocus, AddressOf Amount_Lostfocus
        'AddHandler dr_txt.Enter, AddressOf All_Enter
        AddHandler dr_txt.TextChanged, AddressOf All_Enter


        'crtxt_
        '
        cr_txt.Back_color = Color_bg
        cr_txt.BackColor = Color_bg
        cr_txt.BorderStyle = BorderStyle.None
        cr_txt.Data_Link_ = ""
        cr_txt.Dock = DockStyle.Right
        cr_txt.Font = New Font("Arial", 10, FontStyle.Regular)
        cr_txt.Keydown_Support = False
        cr_txt.Location = New Point(777, 0)
        cr_txt.Name = "crtxt_" & (curr_count + 1)
        cr_txt.Size = Label3.Size
        cr_txt.TabIndex = 3
        cr_txt.Text = ""
        cr_txt.TextAlign = HorizontalAlignment.Right
        cr_txt.Type_ = "Num"
        cr_txt.Enabled = False

        AddHandler cr_txt.KeyDown, AddressOf Amount_Keydown
        AddHandler cr_txt.LostFocus, AddressOf Amount_Lostfocus
        AddHandler cr_txt.TextChanged, AddressOf All_Enter

    End Function

    Private Sub crdr_keyPress(sender As Object, e As KeyPressEventArgs)
        Closing_Fill()
        'If e.KeyChar = "C" Or e.KeyChar = "c" Then
        '    sender.Text = "Cr"
        'ElseIf e.KeyChar = "D" Or e.KeyChar = "d" Then
        '    sender.Text = "Dr"
        'End If
        value_enable(sender)
    End Sub
    Private Sub crdr_TextChanged(sender As Object, e As EventArgs)
        value_enable(sender)
        Dim idx As Integer = Find_Idx(sender)

        If sender.Text = "Cr" Then
            If Val(Find_cr_TXT(idx).Text) = 0 Then
                Find_cr_TXT(idx).Text = Val(Label5.Text)
            End If
        ElseIf sender.Text = "Dr" Then
            If Val(Find_dr_TXT(idx).Text) = 0 Then
                Find_dr_TXT(idx).Text = Val(Label4.Text)
            End If
        End If

    End Sub
    Private Function value_enable(sender As Object)
        If Find_crdr_TXT(Find_Idx(sender)).Text = "Cr" Then
            Find_cr_TXT(Find_Idx(sender)).Enabled = True
            Find_cr_TXT(Find_Idx(sender)).Type_ = "Num"

            'If Val(Find_dr_TXT(Find_Idx(sender)).Text) <> 0 Then
            '    Find_cr_TXT(Find_Idx(sender)).Text = Find_dr_TXT(Find_Idx(sender)).Text
            'End If


            Find_dr_TXT(Find_Idx(sender)).Enabled = False
            Find_dr_TXT(Find_Idx(sender)).Type_ = "TXT"
            Find_dr_TXT(Find_Idx(sender)).Text = ""

            Find_Particuls_TXT(Find_Idx(sender)).Enabled = True
        ElseIf Find_crdr_TXT(Find_Idx(sender)).Text = "Dr" Then
            Find_dr_TXT(Find_Idx(sender)).Enabled = True
            Find_dr_TXT(Find_Idx(sender)).Type_ = "Num"

            'If Val(Find_cr_TXT(Find_Idx(sender)).Text) <> 0 Then
            '    Find_dr_TXT(Find_Idx(sender)).Text = Find_cr_TXT(Find_Idx(sender)).Text
            'End If

            Find_cr_TXT(Find_Idx(sender)).Enabled = False
            Find_cr_TXT(Find_Idx(sender)).Type_ = "TXT"
            Find_cr_TXT(Find_Idx(sender)).Text = ""

            Find_Particuls_TXT(Find_Idx(sender)).Enabled = True
        Else
            Find_cr_TXT(Find_Idx(sender)).Enabled = False
            Find_cr_TXT(Find_Idx(sender)).Type_ = "TXT"
            Find_cr_TXT(Find_Idx(sender)).Text = ""

            Find_dr_TXT(Find_Idx(sender)).Enabled = False
            Find_dr_TXT(Find_Idx(sender)).Type_ = "TXT"
            Find_dr_TXT(Find_Idx(sender)).Text = ""

            Find_Particuls_TXT(Find_Idx(sender)).Enabled = False
            Find_Particuls_TXT(Find_Idx(sender)).Text = ""
        End If
    End Function
    Private Sub Particuls_Keydown(sender As Object, e As KeyEventArgs)
        Dim index As Integer = Find_Idx(sender)
        If e.KeyCode = Keys.Enter Then
            If acc_list.List_Grid.CurrentRow.Cells(1).Value = "Create" Then
                Create_Cash_Ledger(sender)
                Exit Sub
            End If
        End If

        If e.KeyCode = Keys.C AndAlso e.Modifiers = Keys.Alt Then
            Create_Cash_Ledger(sender)
        ElseIf e.KeyCode = Keys.Enter AndAlso e.Modifiers = Keys.Control Then
            Cell("Account Ledger", "", "Alter_Close", Find_Particuls_TXT(index).Data_Link_)
            Ledger_frm.close_focus_obj = sender
            e.Handled = True
            Exit Sub
        ElseIf e.KeyCode = Keys.Enter Then
            sender.Data_Link_ = acc_list.List_Grid.CurrentRow.Cells(2).Value.ToString
            Find_Balance_Lab_TXT(index).Tag = Val(acc_list.List_Grid.CurrentRow.Cells(7).Value.ToString)


            fill_balance(sender)

            If Val(CL_Cr.Text) < Val(CL_Dr.Text) Then
                If Find_crdr_TXT(Find_Idx(sender)).Text = "Cr" And Val(Find_cr_TXT(Find_Idx(sender)).Text) = 0 Then
                    Find_cr_TXT(Find_Idx(sender)).Text = Val(CL_Dr.Text) - Val(CL_Cr.Text)
                End If
            End If

            Find_Balance_PAN_TXT(index).Visible = True
        End If
    End Sub
    Private Function Create_Cash_Ledger(sender As TXT)
        Cell("Account Ledger", "", "Create_Close", "")
        Ledger_frm.Name_TXT.Text = sender.Text
        Ledger_frm.close_focus_obj = sender
    End Function
    Private Sub Amount_Keydown(sender As Object, e As KeyEventArgs)
        Dim TX_ As TXT = CType(sender, TXT)
        Dim index As Integer = Find_Idx(sender)

        If e.KeyCode = Keys.Enter Then
            Closing_Fill()
            If Val(sender.Text) = 0 Then
                e.SuppressKeyPress = True
                NOT_("Please enter value, And try again", NOT_Type.Warning)
                sender.Focus()
                sender.Text = ""
                Exit Sub
            End If
            NOT_Clear()
            If bg_panel.Controls.Count = index Then
                If Val(CL_Cr.Text) <> Val(CL_Dr.Text) Then
                    Add_New()
                    'CType(bg_panel.Controls.Find(("crdrtxt_" & index + 1), True).First, TXT).Focus()

                    'If Val(CL_Cr.Text) > Val(CL_Dr.Text) Then
                    '    CType(bg_panel.Controls.Find(("crdrtxt_" & index + 1), True).First, TXT).Text = "Dr"
                    '    CType(bg_panel.Controls.Find(("drtxt_" & index + 1), True).First, TXT).Enabled = False
                    'Else
                    '    CType(bg_panel.Controls.Find(("crdrtxt_" & index + 1), True).First, TXT).Text = "Cr"
                    '    CType(bg_panel.Controls.Find(("crtxt_" & index + 1), True).First, TXT).Enabled = False
                    'End If
                Else
                    'Accounting_Voucher_frm.SelectNextControl(Accounting_Voucher_frm.ActiveControl, True, True, True, True)
                End If
            Else
                'SendKeys.Send("{TAB}")
            End If
        End If
    End Sub
    Private Function Closing_Fill()
        Dim Dr_ As Decimal = 0.00
        Dim Cr_ As Decimal = 0.00
        For Each bg_p As Panel In bg_panel.Controls.OfType(Of Panel)()
            Dr_ += Val(Find_dr_TXT(bg_p.Name.Split("_")(1)).Text)
            Cr_ += Val(Find_cr_TXT(bg_p.Name.Split("_")(1)).Text)
        Next
        CL_Dr.Text = nUmBeR_FORMATE(Dr_)
        CL_Cr.Text = nUmBeR_FORMATE(Cr_)
    End Function
    Private Sub Amount_Lostfocus(sender As Object, e As EventArgs)
        Closing_Fill()
        fill_balance(sender)
    End Sub
    Private Sub All_Enter(sender As Object, e As EventArgs)
        If Find_crdr_TXT(Find_Idx(sender)).Text = Nothing Then
            Find_crdr_TXT(Find_Idx(sender)).Text = "Dr"
        End If

        Fil_Data_Crdr()
        fill_balance(sender)
        Closing_Fill()
    End Sub
    Private Sub Particuls_Enter(sender As Object, e As EventArgs)
        
    End Sub
    Private Sub Particuls_Lostfocus(sender As Object, e As EventArgs)
        BindingSource1.MoveFirst()
    End Sub
    Public Shado_Color As Color = Color.FromArgb(255, 238, 178)
    Public Function Color_manag()
        Me.BackColor = Color_bg
    End Function
    Private Function Qry_Filters() As String
        Dim q As String = ""
        q &= $" And (vc.Effect_Ledger = 'Yes')"
        q &= $" and (vc.Visible = 'Approval')"
        q &= $" and (vc.[Date] <= '{CDate(Accounting_Voucher_frm.Date_TXT.Text).AddDays(1).ToString(Lite_date_Format)}')"
        If Dft_Branch <> "Primary" Then
            q &= " AND vc.Branch = '" & Find_DT_Value(Database_File.cre, "TBL_Ledger", "ID", $"Name = '{Dft_Branch}'") & "'"
        End If
        q &= $" and (vc.Tra_ID <> '{Accounting_Voucher_frm.Tra_ID}')"
        Return q
    End Function
    Public Function Data_List_Fill()
        Dim Positive As String = Find_DT_Value(Database_File.cmp, "TBL_Features", "Value", "Head = 'Positive Value'")
        Dim Negative As String = Find_DT_Value(Database_File.cmp, "TBL_Features", "Value", "Head = 'Negative Value'")

        Dim dt_particuls As New DataTable

        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
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

            Dim r As SQLiteDataReader
            cmd = New SQLiteCommand($"Select [ID],[Name],[Group],[Alise],[Cradit],
(Select ifnull((Select ifnull(SUM(vc.Cr),0)-ifnull(SUM(vc.Dr),0) From TBL_VC_Ledger vc Where vc.Ledger = LD.ID and vc.[Date] <= '{CDate(Accounting_Voucher_frm.Date_TXT.Text).AddDays(1).ToString(Lite_date_Format)}' and vc.Tra_ID <> '{Accounting_Voucher_frm.Tra_ID}'),0)+ifnull((Select ifnull(sum(lob.OB_Cr),0)-ifnull(sum(lob.OB_Dr),0) From TBL_Ledger_Opning_Balance lob where lob.Ledger_ID = LD.ID and lob.Branch_ID = '{Accounting_Voucher_frm.Branch_ID}'),0)) as Bal_
from TBL_Ledger LD where (Select lob.Applicable From TBL_Ledger_Opning_Balance lob where lob.Ledger_ID = ld.ID and lob.Branch_ID = '{Accounting_Voucher_frm.Branch_ID}') <> 'No'", cn)

            With cmd.Parameters
                .AddWithValue("@Filter_Date", CDate(Accounting_Voucher_frm.Date_TXT.Text).AddDays(1).ToString(Lite_date_Format))
                r = cmd.ExecuteReader
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

                    dt_particuls.Rows.Add(r("Name"), Vlu_, r("ID"), r("Alise"), r("Group"), Credit_, Color_, Val(r("Bal_").ToString) * 1)

                End While
            End With
            r.Close()
        End If


        Dim Fiter_String As String = ""
        BindingSource1.DataSource = dt_particuls

        Fil_Data_Crdr()

    End Function
    Private Function Fil_Data_Crdr()
        Dim dt As New DataTable
        dt.Columns.Add("Name")

        If CL_Dr.Text = CL_Cr.Text Then
            If Val(CL_Dr.Text) <> 0 Then
                dt.Rows.Add("End of List")
            End If
        End If


        dt.Rows.Add("Cr")
        dt.Rows.Add("Dr")

        BindingSource2.DataSource = dt
    End Function
    Public Function fill_balance(sender As Object)
        Dim idx As Integer = Find_Idx(sender)

        Dim Positive As String = Positive_Value_fech
        Dim Negative As String = Negative_Value_fech


        'Find_Balance_curr_TXT(idx).Text = Ledger_Balance(Find_Particuls_TXT(idx).Data_Link_, CDate(Accounting_Voucher_frm.Date_TXT.Text), Accounting_Voucher_frm.Tra_ID, Accounting_Voucher_frm.Branch_ID)

        'Find_Balance_Lab_TXT(idx).Text = Val(Find_Balance_curr_TXT(idx).Text)

        If Find_crdr_TXT(Find_Idx(sender)).Text = "Cr" Then
            Find_Balance_Lab_TXT(Find_Idx(sender)).Text = nUmBeR_FORMATE(Val(Find_Balance_Lab_TXT(Find_Idx(sender)).Tag) + Val(Find_cr_TXT(Find_Idx(sender)).Text))
        Else
            Find_Balance_Lab_TXT(Find_Idx(sender)).Text = nUmBeR_FORMATE(Val(Find_Balance_Lab_TXT(Find_Idx(sender)).Tag) - +++Val(Find_dr_TXT(Find_Idx(sender)).Text))
        End If


        If Val(Find_Balance_Lab_TXT(Find_Idx(sender)).Text) >= 0 Then
            Find_Balance_Lab_TXT(Find_Idx(sender)).ForeColor = Color.Green
            Find_Balance_Lab_TXT(Find_Idx(sender)).Text = N2_FORMATE(Find_Balance_Lab_TXT(Find_Idx(sender)).Text) & " " & Positive
        Else
            Find_Balance_Lab_TXT(Find_Idx(sender)).ForeColor = Color.Red
            Dim vlu As Decimal = Val(Find_Balance_Lab_TXT(Find_Idx(sender)).Text)

            vlu *= -1
            Find_Balance_Lab_TXT(Find_Idx(sender)).Text = N2_FORMATE(vlu) & " " & Negative
        End If
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
    Public Function Find_Particuls_Panel(index As Integer) As Panel
        Try
            Return CType(bg_panel.Controls.Find(("Particulspanel_" & index), True).First, Panel)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Particuls_TXT(Index As Integer) As TXT
        Try
            Dim Pan1_ As Panel = CType(bg_panel.Controls.Find(("bg_" & Index), True).First, Panel)
            Return CType(Pan1_.Controls.Find(("Particulstxt_" & Index), True).First, TXT)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_crdr_TXT(Index As Integer) As TXT
        Try
            Dim Pan1_ As Panel = CType(bg_panel.Controls.Find(("bg_" & Index), True).First, Panel)
            Return CType(Pan1_.Controls.Find(("crdrtxt_" & Index), True).First, TXT)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Balance_curr_TXT(Index As Integer) As Label
        Try
            Dim Pan1_ As Panel = CType(bg_panel.Controls.Find(("bg_" & Index), True).First, Panel)
            Return CType(Pan1_.Controls.Find(("balcurr_" & Index), True).First, Label)
        Catch ex As Exception

        End Try
    End Function

    Public Function Find_dr_TXT(Index As Integer) As TXT
        Try
            Dim Pan1_ As Panel = CType(bg_panel.Controls.Find(("bg_" & Index), True).First, Panel)
            Return CType(Pan1_.Controls.Find(("drtxt_" & Index), True).First, TXT)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_cr_TXT(Index As Integer) As TXT
        Try
            Dim Pan1_ As Panel = CType(bg_panel.Controls.Find(("bg_" & Index), True).First, Panel)
            Return CType(Pan1_.Controls.Find(("crtxt_" & Index), True).First, TXT)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Balance_Lab_TXT(Index As Integer) As Label
        Try
            Dim Pan1_ As Panel = CType(bg_panel.Controls.Find(("bg_" & Index), True).First, Panel)
            Return CType(Pan1_.Controls.Find(("BalValue_" & Index), True).First, Label)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Balance_PAN_TXT(Index As Integer) As Panel
        Try
            Dim Pan1_ As Panel = CType(bg_panel.Controls.Find(("bg_" & Index), True).First, Panel)
            Return CType(Pan1_.Controls.Find(("balancepanel_" & Index), True).First, Panel)
        Catch ex As Exception

        End Try
    End Function

    Public Function Find_Idx(sender As Object) As Integer
        Return sender.Name.Split("_")(1)
    End Function

    Private Sub journal_controls_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        'Ledger_List_Value = Find_DT_Value(Database_File.lnk, "cfg_Vouchers", "Value", "[Name] = 'List Display Value'")

        Data_List_Fill()
    End Sub

    Private Sub CL_Cr_Click(sender As Object, e As EventArgs) Handles CL_Cr.Click

    End Sub

    Private Sub CL_Cr_TextChanged(sender As Object, e As EventArgs) Handles CL_Cr.TextChanged, CL_Dr.TextChanged
        calculation_()
    End Sub
    Private Function calculation_()
        If Val(CL_Dr.Text) = Val(CL_Cr.Text) Then
            Label4.Text = ""
            Label5.Text = ""
        ElseIf Val(CL_Dr.Text) > Val(CL_Cr.Text) Then
            Label4.Text = ""
            Label5.Text = Val(CL_Dr.Text) - Val(CL_Cr.Text)
        ElseIf Val(CL_Dr.Text) < Val(CL_Cr.Text) Then
            Label5.Text = ""
            Label4.Text = Val(CL_Cr.Text) - Val(CL_Dr.Text)
        End If
    End Function
    Private Sub bg_panel_Enter(sender As Object, e As EventArgs)
        Dim col As Color = Color.FromArgb(254, 237, 194)
        'RGB(254, 237, 194)
        sender.BackColor = col
        Dim idx As Integer = Find_Idx(sender)

        Find_Particuls_TXT(idx).Back_color = col
        Find_crdr_TXT(idx).Back_color = col
        Find_cr_TXT(idx).Back_color = col
        Find_dr_TXT(idx).Back_color = col

        Find_Particuls_TXT(idx).BackColor = col
        Find_crdr_TXT(idx).BackColor = col
        Find_cr_TXT(idx).BackColor = col
        Find_dr_TXT(idx).BackColor = col

    End Sub
    Private Sub bg_panel_Leave(sender As Object, e As EventArgs)
        Dim col As Color = Panel5.BackColor
        sender.BackColor = col

        Dim idx As Integer = Find_Idx(sender)
        Find_Particuls_TXT(idx).Back_color = col
        Find_crdr_TXT(idx).Back_color = col
        Find_cr_TXT(idx).Back_color = col
        Find_dr_TXT(idx).Back_color = col

        Find_Particuls_TXT(idx).BackColor = col
        Find_crdr_TXT(idx).BackColor = col
        Find_cr_TXT(idx).BackColor = col
        Find_dr_TXT(idx).BackColor = col
    End Sub
End Class
