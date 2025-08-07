Imports System.Data.SqlClient
Imports System.Data.SQLite
Imports Tools
Public Class Salary_details_cc
    Dim curr_count As Integer = 0
    Dim tab_count As Integer = 0

    Private Sub Salary_details_cc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Fill_Source_data()
    End Sub
    Public Function Add_New()
        curr_count = bg_panel.Controls.OfType(Of Panel).ToList.Count
        tab_count += 1
        Dim bg_p As Panel = New Panel
        Dim Date_panel As Panel = New Panel

        'bg_
        '
        bg_p.AutoSize = True
        bg_p.Controls.Add(Date_panel)
        bg_p.Dock = DockStyle.Top
        bg_p.Location = New Point(0, 0)
        bg_p.Name = "bg_" & (curr_count + 1)
        bg_p.Size = New Size(903, 34)
        bg_p.TabIndex = tab_count
        bg_p.BringToFront()



        Date_Panel_cntr(Date_panel)

        bg_panel.Controls.Add(bg_p)
        bg_p.BringToFront()

        List_set_auto_fill(curr_count + 1)

    End Function

    Public Function Payhead_Panel_cntr(Pan As Panel)
        Dim gen_count As Integer = 0
        Dim phd_count As Integer = 0

        gen_count = Find_Idx(Pan)
        phd_count = Pan.Controls.OfType(Of Panel).ToList.Count

        Dim name_ As String = (gen_count) & "_" & (phd_count + 1)

        Dim gb_payroll As Panel = New Panel

        Dim phd_tat As TXT = New TXT
        Dim rate_tat As TXT = New TXT
        Dim per_lab As Label = New Label
        Dim phd_type_txt As Label = New Label
        Dim cal_type_txt As Label = New Label
        Dim blank_pan As Panel = New Panel

        Dim phd_id_ As Label = New Label
        'phdpanel_
        '
        gb_payroll.Controls.Add(phd_tat)
        gb_payroll.Controls.Add(rate_tat)
        gb_payroll.Controls.Add(per_lab)
        gb_payroll.Controls.Add(phd_type_txt)
        gb_payroll.Controls.Add(cal_type_txt)
        gb_payroll.Controls.Add(blank_pan)

        gb_payroll.Controls.Add(phd_id_)

        gb_payroll.Dock = DockStyle.Top
        gb_payroll.Location = New Point(0, 17)
        gb_payroll.Name = "phdpanel_" & name_
        gb_payroll.Size = New Size(903, 17)
        gb_payroll.TabIndex = phd_count + 0 + 0
        gb_payroll.BringToFront()

        AddHandler gb_payroll.Enter, AddressOf panel_Enter
        AddHandler gb_payroll.Leave, AddressOf pan_panel_Leave

        phd_id_.Name = "phdid_" & name_
        phd_id_.Visible = False


        'payheadtxt_
        '
        phd_tat.Back_color = Color.White
        phd_tat.BackColor = Color.White
        phd_tat.BorderStyle = BorderStyle.None
        phd_tat.Data_Link_ = ""
        phd_tat.Decimal_ = 2
        phd_tat.Dock = DockStyle.Left
        phd_tat.Font = New Font("Arial", 9.75, FontStyle.Bold)
        phd_tat.Format_ = "dd-MM-yyyy"
        phd_tat.Keydown_Support = True
        phd_tat.Select_Auto_Show = False
        phd_tat.Location = New Point(123, 0)
        phd_tat.Name = "payheadtxt_" & name_
        phd_tat.Size = New Size(234, 17)
        phd_tat.TabIndex = 1
        phd_tat.Type_ = "Select"
        'phd_tat.Text = ""
        phd_tat.Select_Columns = "0"
        phd_tat.Select_Source = phd_source
        phd_tat.Select_Filter = "(Name Like '%<value>%' or Name = 'End of List')"
        AddHandler phd_tat.LostFocus, AddressOf Payhead_Lostfocus
        AddHandler phd_tat.KeyDown, AddressOf Payhead_KeyDown

        'ratetxt_
        '
        rate_tat.Back_color = Color.White
        rate_tat.BackColor = Color.White
        rate_tat.BorderStyle = BorderStyle.None
        rate_tat.Data_Link_ = ""
        rate_tat.Decimal_ = 2
        rate_tat.TextAlign = HorizontalAlignment.Right
        rate_tat.Dock = DockStyle.Right
        rate_tat.Font = New Font("Arial", 9.75, FontStyle.Bold)
        rate_tat.Format_ = "dd-MM-yyyy"
        rate_tat.Keydown_Support = False
        rate_tat.Location = New Point(357, 0)
        rate_tat.Name = "ratetxt_" & name_
        rate_tat.Size = New Size(Label3.Width, 17)
        rate_tat.TabIndex = 3
        rate_tat.Type_ = "TXT"
        AddHandler rate_tat.KeyDown, AddressOf rate_Keydown
        AddHandler rate_tat.LostFocus, AddressOf rate_Lostfocus
        'perlab_
        '
        per_lab.Dock = DockStyle.Right
        per_lab.Font = New Font("Arial", 9.75, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        per_lab.Location = New Point(464, 0)
        per_lab.Margin = New Padding(4, 0, 4, 0)
        per_lab.Name = "perlab_" & name_
        per_lab.Size = New Size(Label2.Width, 17)
        per_lab.TabIndex = 11
        per_lab.Text = ""
        per_lab.TextAlign = ContentAlignment.MiddleLeft
        per_lab.Padding = New Padding(5, 0, 0, 0)
        'AddHandler per_lab.Click, AddressOf clll

        'payheadtypelab_
        '
        phd_type_txt.Dock = DockStyle.Right
        phd_type_txt.Font = New Font("Arial", 9.75, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        phd_type_txt.Location = New Point(568, 0)
        phd_type_txt.Margin = New Padding(4, 0, 4, 0)
        phd_type_txt.Name = "payheadtypelab_" & name_
        phd_type_txt.Size = New Size(Label5.Width, 17)
        phd_type_txt.TabIndex = 0
        phd_type_txt.Text = ""
        phd_type_txt.TextAlign = ContentAlignment.MiddleLeft

        'caltypelab_
        '
        cal_type_txt.Dock = DockStyle.Right
        cal_type_txt.Font = New Font("Arial", 9.75, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        cal_type_txt.Location = New Point(755, 0)
        cal_type_txt.Margin = New Padding(4, 0, 4, 0)
        cal_type_txt.Name = "caltypelab_" & name_
        cal_type_txt.Size = New Size(Label6.Width, 17)
        cal_type_txt.TabIndex = 9
        cal_type_txt.Text = ""
        cal_type_txt.TextAlign = ContentAlignment.MiddleLeft

        'blankpanel_
        '
        blank_pan.Dock = DockStyle.Left
        blank_pan.Location = New Point(0, 0)
        blank_pan.Name = "blankpanel_" & name_
        blank_pan.Size = New Size(Label1.Width, 17)
        blank_pan.TabIndex = 2


        Pan.Controls.Add(gb_payroll)
        gb_payroll.BringToFront()


        List_set_payhead(phd_tat)
        'phd_tat.Focus()
    End Function
    Private Function Date_Panel_cntr(Pan As Panel)
        Dim Date_txt As TXT = New TXT
        Dim autofill_tx As TXT = New TXT
        'Datepanel_
        '

        Pan.Controls.Add(autofill_tx)
        Pan.Controls.Add(Date_txt)
        Pan.Dock = DockStyle.Top
        Pan.Location = New Point(0, 0)
        Pan.Name = "Datepanel_" & (curr_count + 1)
        Pan.Size = New Size(903, 17)
        Pan.TabIndex = 0


        'DateTXT_
        '
        Date_txt.Back_color = Color.White
        Date_txt.BackColor = Color.White
        Date_txt.BorderStyle = BorderStyle.None
        Date_txt.Data_Link_ = ""
        Date_txt.Decimal_ = 2
        Date_txt.Dock = DockStyle.Left
        Date_txt.Font = New Font("Arial", 9.75, FontStyle.Bold)
        Date_txt.Format_ = "dd-MM-yyyy"
        Date_txt.Keydown_Support = True
        Date_txt.Location = New Point(0, 0)
        Date_txt.Name = "DateTXT_" & (curr_count + 1)
        Date_txt.Size = New Size(Label1.Width, 17)
        Date_txt.TabIndex = 0
        Date_txt.Type_ = "Date"

        AddHandler Date_txt.Enter, AddressOf Date_Enter
        AddHandler Date_txt.KeyDown, AddressOf date_Keydown
        AddHandler Date_txt.LostFocus, AddressOf date_Lostfocus

        'autofill_txt
        '
        autofill_tx.Back_color = Color.White
        autofill_tx.BackColor = Color.White
        autofill_tx.BorderStyle = BorderStyle.None
        autofill_tx.Data_Link_ = ""
        autofill_tx.Decimal_ = 2
        autofill_tx.Dock = DockStyle.Left
        autofill_tx.Font = New Font("Arial", 10.0, FontStyle.Italic)
        autofill_tx.Format_ = "dd-MM-yyyy"
        autofill_tx.Keydown_Support = True
        autofill_tx.Select_Auto_Show = False
        autofill_tx.Location = New Point(123, 0)
        autofill_tx.Name = "autofilltxt_" & (curr_count + 1)
        autofill_tx.Size = New Size(Label4.Width, 17)
        autofill_tx.TabIndex = 1
        autofill_tx.Type_ = "Select"
        autofill_tx.Select_Source = BindingSource1
        autofill_tx.Select_Columns = 0
        autofill_tx.Select_Filter = " "

        autofill_tx.TextAlign = HorizontalAlignment.Right
        If curr_count = 0 Then
            autofill_tx.Visible = False
        Else
            autofill_tx.Visible = True
        End If
        AddHandler autofill_tx.Enter, AddressOf Auto_Enter
        AddHandler autofill_tx.KeyDown, AddressOf Auto_Kaydown

    End Function
    Private Sub balance_Lostfocus(sender As Object, e As EventArgs)
        fill_balance(sender)
    End Sub
    Public Function fill_balance(sender As Object)
        Dim idx1 As Integer = Find_Idx(sender)
        Dim idx2 As Integer = Find_Idx_idx(sender)

        Dim id_ As Object = Find_pay_ID(idx1, idx2)
        Dim per As Object = Find_per_lab(idx1, idx2)
        Dim cal_phd_type As Object = Find_phd_type_lab(idx1, idx2)
        Dim cal_type As Object = Find_cal_type_lab(idx1, idx2)

        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand("Select *,
(Select [Unit] From TBL_Payroll_Att_Production_Type where ID = PD.Production) as Unit
From TBL_Payhead PD where ID = '" & id_.Text & "'", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                If r("Cal_Type") = "On Production" Then
                    per.Text = Find_DT_Unit_Conves(r("Unit"))
                Else
                    per.Text = r("Cal")
                End If
                cal_phd_type.Text = r("Payhead_Type")
                cal_type.Text = r("Cal_Type")
            End While
        End If


        Find_auto_TXT(Find_Idx(sender)).Width = Val(Label4.Width) - 3
    End Function
    Private Sub date_Keydown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then

            Dim idx As Integer = Find_Idx(sender)

            If Find_Date_TXT(idx).Text = "" Then
                bg_panel.Controls.Remove(Find_bg_Panel(idx))
                Payroll_Salary_details_frm.Save_data()
                Exit Sub
            End If

            If Find_bg_Panel(idx).Controls.Count = 1 And Find_auto_TXT(idx).Visible = False Then
                Payhead_Panel_cntr(Find_bg_Panel(idx))
                sender.Focus()
            End If


            If Find_bg_Panel(idx).Controls.Count = 1 Then
                Find_auto_TXT(idx).Enabled = True
            Else
                Find_auto_TXT(idx).Enabled = False
            End If
        End If
    End Sub
    Private Sub rate_Lostfocus(sender As Object, e As EventArgs)
        Dim idx As Integer = Find_Idx(sender)
        Dim idx1 As Integer = Find_Idx_idx(sender)
        If Find_phd_type_lab(idx, idx1).Text = "Deductions From Employees" Then
            If Val(sender.Text) > 0 Then
                sender.Text = Val(sender.Text) * -1
            End If
        End If
    End Sub
    Private Sub rate_Keydown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Dim index_under As Integer = Find_Idx_idx(sender)
            Dim bg_vartual As Panel = Find_bg_Panel(Find_Idx(sender))

            If bg_vartual.Controls.Count = index_under Then
                Payhead_Panel_cntr(Find_bg_Panel(Find_Idx(sender)))
            End If
            e.SuppressKeyPress = True
        End If
    End Sub
    Private Sub Date_Enter(sender As Object, e As EventArgs)

    End Sub
    Private Sub Auto_Enter(sender As Object, e As EventArgs)
        BindingSource1.MoveFirst()
    End Sub
    Private Sub Auto_Kaydown(sender As Object, e As KeyEventArgs)


        If e.KeyCode = Keys.Enter Then
            Dim bol As Boolean = False
            If Find_bg_Panel(Find_Idx(sender)).Controls.Count = 1 Then
                If auto_list.List_Grid.CurrentRow.Cells(0).Value.ToString = "Copy From Previous Value" Then
                    Dim U_ As New Queue(Of Panel)()
                    For Each P As Panel In bg_panel.Controls.OfType(Of Panel)()
                        If bol = True Then
                            For Each U As Panel In Find_bg_Panel(Find_Idx(P)).Controls.OfType(Of Panel)()
                                U_.Enqueue(U)
                            Next

                            For Each U As Panel In U_.Reverse
                                If U.Name <> "Datepanel_" & Find_Idx(P) Then
                                    Dim idx1 As Integer = Find_Idx(U)
                                    Dim idx2 As Integer = Find_Idx_idx(U)
                                    Dim id As String = Find_pay_ID(idx1, idx2).Text
                                    If Val(id) <> 0 Then
                                        Add_data(Find_Date_TXT(Find_Idx(sender)).Text, id, Find_rate_txt(idx1, idx2).Text, Find_per_lab(idx1, idx2).Text, Find_phd_type_lab(idx1, idx2).Text, Find_cal_type_lab(idx1, idx2).Text, False)
                                    End If
                                End If
                            Next
                            Payhead_Panel_cntr(Find_bg_Panel(Find_Idx(P) + 1))
                            Exit Sub
                        End If
                        If Find_bg_Panel(Find_Idx(sender)).Name = Find_bg_Panel(Find_Idx(P)).Name Then
                            bol = True
                        End If
                    Next
                ElseIf auto_list.List_Grid.CurrentRow.Cells(0).Value = "Start Afresh" Then
                    If Find_bg_Panel(Find_Idx(sender)).Controls.Count = 1 Then
                        Payhead_Panel_cntr(Find_bg_Panel(Find_Idx(sender)))
                    End If
                End If

            End If
        End If
    End Sub
    Public Function Add_data(Dt As Date, phd As String, vlu As String, per As String, phd_typ As String, cal_typ As String, bol As Boolean)
        Dim phd_name As String = Find_DT_Value(Database_File.cre, "TBL_Payhead", "Name", "ID = '" & phd & "'")
        If bg_panel.Controls.Count = 0 Then
            Add_New()
            Find_Date_TXT(1).Text = Dt.ToString("dd-MM-yyyy")
        End If
        Dim idx As Integer = bg_panel.Controls.Count
        Dim date_txt As Object = Find_Date_TXT(idx)

        If CDate(date_txt.Text) = Dt Then
            Payhead_Panel_cntr(Find_bg_Panel(idx))
        Else
            If bol = True Then
                Add_New()
                Payhead_Panel_cntr(Find_bg_Panel(idx + 1))
            Else
                Payhead_Panel_cntr(Find_bg_Panel(idx))
            End If
        End If

        idx = bg_panel.Controls.Count
        Dim idx2 As Integer = Find_bg_Panel(idx).Controls.Count

        Find_payhead_panel(idx, idx2).Enabled = False

        date_txt = Find_Date_TXT(idx)
        Dim phd_txt As Object = Find_phd_txt(idx, idx2)
        Dim phd_id As Object = Find_pay_ID(idx, idx2)
        Dim rate_ As Object = Find_rate_txt(idx, idx2)
        Dim per_ As Object = Find_per_lab(idx, idx2)
        Dim phd_typr_ As Object = Find_phd_type_lab(idx, idx2)
        Dim cal_typr_ As Object = Find_cal_type_lab(idx, idx2)

        date_txt.Text = CDate(Dt).ToString("dd-MM-yyyy")
        phd_txt.Text = phd_name
        phd_id.Text = phd
        rate_.Text = Val(vlu)
        per_.Text = per
        phd_typr_.Text = phd_typ
        cal_typr_.Text = cal_typ

        Find_payhead_panel(idx, idx2).Enabled = True

    End Function
    Private Sub date_Lostfocus(sender As Object, e As EventArgs)
        If Date_Formate(sender.Text) <> "" Then
            Dim chack_ As Boolean = False
            For Each P As Panel In bg_panel.Controls.OfType(Of Panel)()
                Dim idx As Integer = Find_Idx(P)
                If chack_ = True Then
                    Date_is_allow(P, sender)
                    Exit Sub
                End If

                If Find_Date_TXT(idx).Name = sender.Name Then
                    chack_ = True
                End If
                NOT_Clear()
            Next
        End If
    End Sub
    Public Vc_Last_Date As String
    Private Function Date_is_allow(o1 As Object, o2 As Object)
        Dim idx As Integer = Find_Idx(o1)
        If CDate(Find_Date_TXT(idx).Text) >= CDate(o2.Text) Then
            Msg_Custom_YN(NOT_Location.Bottom_Right, Color.Red, My.Resources.Error_animation_icn, Dialoag_Button.Ok, "Error", "Effective from Input Error", "The date should be after<nl>" & Find_Date_TXT(idx).Text)

            o2.Focus()
            Exit Function
        End If
        If CDate(Company_Book_frm) >= CDate(o2.Text) Then
            Msg_Custom_YN(NOT_Location.Bottom_Right, Color.Red, My.Resources.Error_animation_icn, Dialoag_Button.Ok, "Error", "Effective from Input Error", "The Date should be after<nl>" & Company_Book_frm)
            o2.Focus()
            Exit Function
        End If


    End Function
    Private Function Create_PayHead(txt As TXT)
        Cell("Payroll Pay Head", "", "Create_Close", "")
        With Payroll_Payhead_frm
            .close_focus_obj = txt
            .close_link_yn = True
            .Name_TXT.Text = txt.Text
        End With
    End Function
    Private Sub Payhead_KeyDown(sender As Object, e As KeyEventArgs)
        Dim i1 As Integer = Find_Idx(sender)
        Dim i2 As Integer = Find_Idx_idx(sender)

        If e.KeyCode = Keys.Enter Then
            If phd_list.List_Grid.CurrentRow.Cells(3).Value = "Create" Then
                Create_PayHead(sender)
                Exit Sub
            End If
        End If


        If e.KeyCode = Keys.C AndAlso e.Modifiers = Keys.Alt Then
            Create_PayHead(sender)
        ElseIf e.KeyCode = Keys.Enter AndAlso e.Modifiers = Keys.Control Then
            Cell("Payroll Pay Head", "", "Alter_Close", phd_list.List_Grid.CurrentRow.Cells(5).Value)
            Payroll_Payhead_frm.close_focus_obj = sender
        ElseIf e.KeyCode = Keys.Enter Then
            Find_pay_ID(i1, i2).Text = phd_list.List_Grid.CurrentRow.Cells(5).Value.ToString

            If Find_pay_ID(i1, i2).Text = Nothing Then
                Find_rate_txt(i1, i2).Enabled = False
                Find_rate_txt(i1, i2).Text = ""

                Find_phd_type_lab(i1, i2).Text = ""
                Find_cal_type_lab(i1, i2).Text = ""


                If Find_bg_Panel(i1).Controls.Count = i2 - 0 Then
                    If bg_panel.Controls.Count = i1 Then
                        Add_New()
                    End If
                End If
            Else
                Find_rate_txt(i1, i2).Enabled = True

            End If
        End If

    End Sub
    Private Sub Payhead_Lostfocus(sender As Object, e As EventArgs)
        'Dim index As Integer = Find_Idx(sender)
        'Dim index_under As Integer = Find_Idx_idx(sender)

        'Dim bg_vartual As Panel = Find_bg_Panel(index)

        'If sender.Text = "End of List" Then
        '    Dim bg_Pan As Panel = Find_payhead_panel(index, index_under)

        '    RemoveHandler Find_phd_txt(index, index_under).LostFocus, AddressOf Payhead_Lostfocus

        '    If bg_vartual.Controls.Count = index_under - 0 Then
        '        If bg_panel.Controls.Count = index Then
        '            Add_New()
        '        End If
        '    End If

        '    SelectNextControl(bg_Pan, False, True, True, True)
        '    bg_vartual.Controls.Remove(bg_Pan)
        '    Exit Sub
        'Else
        'End If

        phd_source.MoveFirst()

        Find_pay_ID(Find_Idx(sender), Find_Idx_idx(sender)).Text = Find_DT_Value(Database_File.cre, "TBL_Payhead", "ID", "Name = '" & Find_phd_txt(Find_Idx(sender), Find_Idx_idx(sender)).Text & "'")


            fill_balance(sender)
    End Sub
    'Database Filtera
    Public Function Loan_Data_List_Fill(sender As Object)
        If List_frm.Visible = False Then


        End If
    End Function
    Dim auto_list As List_frm
    Private Function List_set_auto_fill(obj As Integer)
        Dim tx As TXT = Find_auto_TXT(obj)

        auto_list = New List_frm
        List_Setup("Start Type", Select_List.Right, Select_List_Format.Singel, tx, auto_list, BindingSource1, 200)

    End Function

    Dim phd_list As List_frm
    Private Function List_set_payhead(obj As Object)
        Dim tx As TXT = obj

        phd_list = New List_frm
        List_Setup("List of Payhead", Select_List.Right_Dock, Select_List_Format.Custome, tx, phd_list, phd_source, 500)
        phd_list.System_Data_integer = 1

        With phd_list.List_Grid
            .Columns(1).Visible = False
            .Columns(4).Visible = False
            .Columns(5).Visible = False

            .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns(2).Width = 180

            .Columns(3).Width = 150
            .Columns(3).DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Italic)
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        End With


    End Function

    Public Function Fill_Source_data()
        Dim cn As New SQLiteConnection
        Dim dt As New DataTable
        Dim dr As DataRow
        dt.Clear()
        dt.Columns.Add("Name")
        dt.Columns.Add("Under")
        dt.Columns.Add("Payhead_Type")
        dt.Columns.Add("Calculation_Type")
        dt.Columns.Add("alias")
        dt.Columns.Add("ID")

        dt.Rows.Add("", "", "", "Create")
        dt.Rows.Add("End of List", "", "", "")

        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand("Select *,(Select ag.name From TBL_Acc_Group ag where ag.id = ph.Under) as Under_Name From TBL_PayHead ph where " & Company_Visible_Filter, cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                dr = dt.NewRow
                dr("ID") = r("ID")
                dr("Name") = r("Name")
                dr("alias") = r("alias")
                dr("Under") = r("Under_Name")
                dr("Payhead_Type") = r("Payhead_Type")
                dr("Calculation_Type") = r("Cal_Type")
                dt.Rows.Add(dr)
            End While
            r.Close()
        End If
        phd_source.DataSource = dt


        dt = New DataTable
        dt.Columns.Add("Name")

        dt.Rows.Add("Copy From Previous Value")
        dt.Rows.Add("Start Afresh")

        BindingSource1.DataSource = dt
    End Function
    Public Function Auto_Data_List_Fill(sender As Object)
    End Function
    Public Function Select_Currant(TXT As String, col As Integer)
        Try
            If List_frm.Visible = True Then
                For i As Integer = 0 To List_frm.List_Grid.Rows.Count - 1
                    Dim ro As DataGridViewRow = List_frm.List_Grid.Rows(i)
                    If ro.Cells(col).Value = TXT Then
                        List_frm.List_Grid.CurrentCell = List_frm.List_Grid.Rows(i).Cells(1)
                        Exit For
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Function












    'Find all Objects
    Public Function Find_Idx(sender As Object) As Integer
        Return sender.Name.Split("_")(1)
    End Function
    Public Function Find_Idx_idx(sender As Object) As Integer
        Return sender.Name.Split("_")(2)
    End Function
    Public Function Find_bg_Panel(Index As Integer) As Panel
        Try
            Return CType(bg_panel.Controls.Find(("bg_" & Index), True).First, Panel)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Date_TXT(Index As Integer) As TXT
        Try
            Dim Pan1_ As Panel = CType(bg_panel.Controls.Find(("bg_" & Index), True).First, Panel)
            Return CType(Pan1_.Controls.Find(("datetxt_" & Index), True).First, TXT)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_auto_TXT(Index As Integer) As TXT
        Try
            Dim Pan1_ As Panel = CType(bg_panel.Controls.Find(("bg_" & Index), True).First, Panel)
            Return CType(Pan1_.Controls.Find(("autofilltxt_" & Index), True).First, TXT)
        Catch ex As Exception

        End Try
    End Function

    Public Function Find_phd_txt(Index As Integer, index2 As Integer) As TXT
        Try
            Return CType(bg_panel.Controls.Find(("payheadtxt_" & Index & "_" & index2), True).First, TXT)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_rate_txt(Index As Integer, index2 As Integer) As TXT
        Try
            Return CType(bg_panel.Controls.Find(("ratetxt_" & Index & "_" & index2), True).First, TXT)
        Catch ex As Exception

        End Try
    End Function

    Public Function Find_per_lab(Index As Integer, index2 As Integer) As Label
        Try
            Return CType(bg_panel.Controls.Find(("perlab_" & Index & "_" & index2), True).First, Label)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_phd_type_lab(Index As Integer, index2 As Integer) As Label
        Try
            Return CType(bg_panel.Controls.Find(("payheadtypelab_" & Index & "_" & index2), True).First, Label)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_cal_type_lab(Index As Integer, index2 As Integer) As Label
        Try
            Return CType(bg_panel.Controls.Find(("caltypelab_" & Index & "_" & index2), True).First, Label)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_payhead_panel(Index As Integer, index2 As Integer) As Panel
        Try
            Return CType(bg_panel.Controls.Find(("phdpanel_" & Index & "_" & index2), True).First, Panel)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_pay_ID(Index As Integer, index2 As Integer) As Label
        Try
            Return CType(bg_panel.Controls.Find(("phdid_" & Index & "_" & index2), True).First, Label)
        Catch ex As Exception

        End Try
    End Function

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Find_bg_Panel(2).SelectNextControl(Find_payhead_panel(2, 1), True, True, True, True)
    End Sub

    Public Sub panel_Enter(sender As Object, e As EventArgs)
        Dim col As Color = Color.FromArgb(255, 238, 178)
        'sender.BackColor = col
        Dim idx As Integer = Find_Idx(sender)
        Dim idx2 As Integer = Find_Idx_idx(sender)

        sender.BackColor = col
        Find_phd_txt(idx, idx2).BackColor = col
        Find_rate_txt(idx, idx2).BackColor = col

        Find_phd_txt(idx, idx2).Back_color = col
        Find_rate_txt(idx, idx2).Back_color = col

    End Sub
    Private Sub pan_panel_Leave(sender As Object, e As EventArgs)
        Dim col As Color = bg_panel.BackColor

        Dim idx As Integer = Find_Idx(sender)
        Dim idx2 As Integer = Find_Idx_idx(sender)

        sender.BackColor = col
        Find_phd_txt(idx, idx2).BackColor = col
        Find_rate_txt(idx, idx2).BackColor = col

        Find_phd_txt(idx, idx2).Back_color = col
        Find_rate_txt(idx, idx2).Back_color = col
    End Sub

    Private Sub Salary_details_cc_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim ctlpos As Point = Label4.PointToScreen(Label4.DisplayRectangle.Location)
        date_L.Location = New Point(ctlpos.X, 0)
        date_L.Height = Me.Height

        ctlpos = New Point
        ctlpos = Label3.PointToScreen(Label3.DisplayRectangle.Location)
        phdType_L.Location = New Point(ctlpos.X, 0)
        phdType_L.Height = Me.Height


        ctlpos = New Point
        ctlpos = Label2.PointToScreen(Label2.DisplayRectangle.Location)
        per_L.Location = New Point(ctlpos.X, 0)
        per_L.Height = Me.Height

        ctlpos = New Point
        ctlpos = Label5.PointToScreen(Label5.DisplayRectangle.Location)
        Rate_L.Location = New Point(ctlpos.X, 0)
        Rate_L.Height = Me.Height

        ctlpos = New Point
        ctlpos = Label6.PointToScreen(Label6.DisplayRectangle.Location)
        phd_L.Location = New Point(ctlpos.X, 0)
        phd_L.Height = Me.Height


    End Sub

    Private Sub Salary_details_cc_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        Fill_Source_data()
    End Sub
End Class
