Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Data.SQLite
Imports Tools
Public Class User_Raids_ctrl
    Dim curr_count As Integer = 0
    Private Sub Communication_ctrl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Load_data()
    End Sub
    Public Function Load_data()
        Dim cn As New SQLiteConnection
        Dim dt As New DataTable
        dt.Columns.Add("Name")
        dt.Columns.Add("Under")
        dt.Columns.Add("ID")

        dt.Rows.Add("End of List", "", "0")

        dt.Rows.Add("Account Group", "", "1")
        dt.Rows.Add("Account Ledger", "", "1")
        dt.Rows.Add("Stock Group", "", "1")
        dt.Rows.Add("Stock Category", "", "1")
        dt.Rows.Add("Stock Unit", "", "1")
        dt.Rows.Add("Stock Item", "", "1")
        dt.Rows.Add("Stock Godown", "", "1")
        dt.Rows.Add("Transportation", "", "1")
        dt.Rows.Add("Voucher Type", "", "1")
        dt.Rows.Add("Accounting Vouchers", "Create", "1")
        dt.Rows.Add("Inventory Vouchers", "", "1")
        dt.Rows.Add("Day Book", "Display", "2")
        dt.Rows.Add("Account Statement", "Display", "2")
        dt.Rows.Add("Sales Register", "Display", "2")
        dt.Rows.Add("Purchase Register", "Display", "2")

        dt.Rows.Add("Stock Summary", "Display", "2")
        dt.Rows.Add("Balance Sheet", "Display", "2")
        dt.Rows.Add("Profit & Loss Account", "Display", "2")

        Ledger_Source.DataSource = dt

        dt = New DataTable
        dt.Columns.Add("Name")
        dt.Columns.Add("Group")

        dt.Rows.Add("Full Access", "1")
        dt.Rows.Add("Not Access", "1")
        'dt.Rows.Add("Create/Alter", "1")
        dt.Rows.Add("Create Not Access", "1")
        dt.Rows.Add("Alter Not Access", "1")
        'dt.Rows.Add("Display Only", "1")

        dt.Rows.Add("Full Access", "2")
        dt.Rows.Add("Not Access", "2")
        dt.Rows.Add("Print Not Access", "2")
        'dt.Rows.Add("Display Only", "2")

        Type_Source.DataSource = dt

        With User_frm.DataGridView1
            For Each ro As DataGridViewRow In .Rows
                If ro.Cells(0).Value = "Days allowed for Back Dated vouchers" Then
                    Txt2.Text = ro.Cells(1).Value
                ElseIf ro.Cells(0).Value = "Cut-off date for Back Dated vouchers" Then
                    Txt3.Text = Date_Formate(ro.Cells(1).Value)
                Else
                    Add_New(ro.Cells(0).Value, ro.Cells(1).Value)
                End If
            Next
        End With

        If platform.Controls.Count = 0 Then
            Add_New("", "")
        End If

        Txt2.Focus()
    End Function
    Dim ag_list As List_frm
    Dim type_list As List_frm
    Private Function List_set(idx As Integer)
        ag_list = New List_frm
        List_Setup("List of Features", Select_List.Right_Dock, Select_List_Format.Defolt, Find_Particuls(idx), ag_list, Ledger_Source, 320)

        type_list = New List_frm
        List_Setup("Type of Access", Select_List.Right, Select_List_Format.Singel, Find_Customer(idx), type_list, Type_Source, 150)


    End Function
    Public Function Load_data_Under()

    End Function
    Public Function Add_New(Head As String, vl As String)
        curr_count = platform.Controls.OfType(Of Panel).ToList.Count
        Dim bg_p As Panel = New Panel
        Dim particals_panel As Panel = New Panel
        Dim Balance_panel As Panel = New Panel

        'bgpanel_
        '
        bg_p.Controls.Add(particals_panel)
        bg_p.Dock = DockStyle.Top
        bg_p.Location = New System.Drawing.Point(0, 0)
        bg_p.Name = "bg_" & (curr_count + 1)
        bg_p.TabIndex = curr_count
        bg_p.Size = New System.Drawing.Size(903, 20)

        Particuls_Panel_ctrl(particals_panel, Head, vl)

        platform.Controls.Add(bg_p)
        bg_p.BringToFront()

        List_set((curr_count + 1))
    End Function
    Private Function Particuls_Panel_ctrl(Pan As Panel, Head As String, vl As String)
        Dim particuls_id As Label = New Label
        Dim data_ As Label = New Label
        Dim particuls_txt As TXT = New TXT
        Dim customize As TXT = New TXT

        Pan.Controls.Add(particuls_txt)
        Pan.Controls.Add(data_)

        Pan.Controls.Add(customize)

        Pan.Controls.Add(particuls_id)

        data_.Visible = False
        data_.Name = "data_" & (curr_count + 1)

        Pan.Dock = DockStyle.Top
        Pan.Location = New System.Drawing.Point(0, 0)
        Pan.Name = "particulspanel_" & (curr_count + 1)
        Pan.Size = New System.Drawing.Size(903, 15)
        Pan.TabIndex = 0
        Pan.BackColor = Color.White
        Pan.Padding = New Padding(10, 0, 10, 0)


        AddHandler Pan.Enter, AddressOf bg_panel_Enter
        AddHandler Pan.Leave, AddressOf bg_panel_Leave


        particuls_id.Name = "particulsid_" & (curr_count + 1)
        particuls_id.Visible = False
        particuls_id.Text = ""

        'Particuls_TXT

        particuls_txt.Name = "particulstxt_" & (curr_count + 1)
        particuls_txt.Dock = DockStyle.Fill
        particuls_txt.Size = Label4.Size
        particuls_txt.Padding = Label4.Padding
        particuls_txt.Text = Head
        particuls_txt.Font = New Font("Arial", 10, FontStyle.Bold)
        particuls_txt.Type_ = "Select"
        particuls_txt.Select_Filter = "Name LIKE '%<value>%' or Under LIKE '%<value>%'"


        AddHandler particuls_txt.LostFocus, AddressOf Particuls_LostFocus
        AddHandler particuls_txt.KeyDown, AddressOf Particuls_KeyDown

        customize.Name = "cus_" & (curr_count + 1)
        customize.Size = Label1.Size
        customize.Dock = DockStyle.Right
        customize.Text = vl
        customize.TextAlign = HorizontalAlignment.Left
        customize.Type_ = "Select"
        customize.Select_Filter = " "
        AddHandler customize.KeyDown, AddressOf customize_Keydown
        AddHandler customize.Enter, AddressOf Custome_Enter

    End Function
    Public Whatsaap_Arryr As New List(Of YN)
    Public Email_Arryr As New List(Of YN)
    Private Sub Particuls_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Dim idx As Integer = Find_Idx(sender)
            Find_Particuls_ID(idx).Text = ag_list.List_Grid.CurrentRow.Cells(2).Value
        End If
    End Sub
    Private Sub customize_Keydown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Add_New_condition(sender)
        End If
    End Sub
    Private Sub email_Keydown(sender As Object, e As KeyEventArgs)
        'If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
        '    Add_New_condition(sender)
        'End If
    End Sub
    Private Function Add_New_condition(sender As Object)
        Dim index As Integer = Find_Idx(sender)
        If platform.Controls.Count = index Then
            Add_New("", "")
        End If
    End Function
    Private Sub Particuls_LostFocus(sender As Object, e As EventArgs)
        Ledger_Source.MoveFirst()
        Dim idx As Integer = Find_Idx(sender)

        If sender.Text = "End of List" Then
            Find_Customer(idx).Text = ""
            Find_Customer(idx).Enabled = False
        Else
            Find_Customer(idx).Enabled = True
        End If
    End Sub

    Public Function Find_Idx(sender As Object) As Integer
        Try
            Return sender.Name.Split("_")(1)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Particuls(index As Integer) As TXT
        Try
            Return CType(platform.Controls.Find(("particulstxt_" & index), True).First, TXT)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Particuls_ID(index As Integer) As Label
        Try
            Return CType(platform.Controls.Find(("particulsid_" & index), True).First, Label)
        Catch ex As Exception

        End Try
    End Function
    Public Function find_data(index As Integer) As Label
        Try
            Return CType(platform.Controls.Find(("data_" & index), True).First, Label)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Customer(index As Integer) As TXT
        Try
            Return CType(platform.Controls.Find(("cus_" & index), True).First, TXT)
        Catch ex As Exception

        End Try
    End Function

    Private Sub Custome_Enter(sender As Object, e As EventArgs)
        Dim idx As Integer = Find_Idx(sender)
        Find_Customer(idx).Select_Source.Filter = $"Group = '{Find_Particuls_ID(idx).Text}'"
    End Sub
    Private Sub bg_panel_Enter(sender As Object, e As EventArgs)
        Dim col As Color = Color.FromArgb(254, 197, 48)
        sender.BackColor = col
        Dim idx As Integer = Find_Idx(sender)

        Find_Particuls(idx).Back_color = col
        Find_Customer(idx).Back_color = col

        Find_Particuls(idx).BackColor = col
        Find_Customer(idx).BackColor = col

    End Sub
    Private Sub bg_panel_Leave(sender As Object, e As EventArgs)
        Dim col As Color = platform.BackColor
        sender.BackColor = col

        Dim idx As Integer = Find_Idx(sender)
        Find_Particuls(idx).Back_color = col
        Find_Customer(idx).Back_color = col

        Find_Particuls(idx).BackColor = col
        Find_Customer(idx).BackColor = col
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Txt1_TextChanged(sender As Object, e As EventArgs) Handles Txt1.TextChanged

    End Sub

    Private Sub Txt1_Enter(sender As Object, e As EventArgs) Handles Txt1.Enter
        If Msg_Custom_YN(NOT_Location.Bottom_Right, Color.Black, My.Resources.Question_animation_icn, Dialoag_Button.Yes_No, "Question?", "Save Changes", "") = DialogResult.Yes Then
            Chack_al()
            Save_data()
            User_Raids_frm.Dispose()
        Else

        End If
    End Sub
    Public Function Save_data()
        Dim P_ As New Queue(Of Panel)()
        User_frm.dt_authority.Rows.Clear()
        User_frm.dt_authority.Rows.Add("Days allowed for Back Dated vouchers", Txt2.Text)
        User_frm.dt_authority.Rows.Add("Cut-off date for Back Dated vouchers", Txt3.Text)

        For Each bg_p As Panel In platform.Controls.OfType(Of Panel)()
            P_.Enqueue(bg_p)
        Next
        For Each bg_p As Panel In P_.Reverse
            Dim idx As Integer = Find_Idx(bg_p)
            Dim acc As String = Find_Particuls(idx).Text
            Dim vlu As String = Find_Customer(idx).Text
            User_frm.dt_authority.Rows.Add(acc, vlu)
        Next
    End Function
    Private Function Chack_al()
        Dim P_ As New Queue(Of Panel)()
        For Each bg_p As Panel In platform.Controls.OfType(Of Panel)()
            If Find_Particuls(Find_Idx(bg_p)).Text = "End of List" Or Find_Particuls(Find_Idx(bg_p)).Text = Nothing Then
                platform.Controls.Remove(bg_p)
            End If
        Next
    End Function

    Private Sub Panel7_Paint(sender As Object, e As PaintEventArgs) Handles Panel7.Paint
        obj_center(sender, Me)
    End Sub
    Dim hd As String
    Dim vl As String

    Private Sub Load_Nackround_ProgressChanged(sender As Object, e As ProgressChangedEventArgs)
        Add_New(hd, vl)
    End Sub

    Private Sub Txt3_TextChanged(sender As Object, e As EventArgs) Handles Txt3.TextChanged

    End Sub

    Private Sub Txt3_LostFocus(sender As Object, e As EventArgs) Handles Txt3.LostFocus
        Txt3.Text = Date_Formate(Txt3.Text)
    End Sub
End Class

