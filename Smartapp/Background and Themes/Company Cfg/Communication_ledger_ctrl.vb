Imports System.Data.SQLite
Imports Tools

Public Class Communication_ledger_ctrl
    Dim curr_count As Integer = 0
    Dim Ledger_Source As New BindingSource
    Public Data As Label
    Public Idx As Integer
    Private Sub Communication_ctrl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_data()
    End Sub
    Public Function Load_data()
        'Ledger_Source = Communication_ctrl.Ledger_
        Dim cn As New SQLiteConnection
        Dim dt As New DataTable
        dt.Columns.Add("Name")
        dt.Columns.Add("Under")
        dt.Columns.Add("ID")

        dt.Rows.Add("End of List", "", "0")

        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select *,(Select ag.name From TBL_Acc_Group ag where ag.id = ld.[Group]) as Under_Name From TBL_Ledger ld where ld.[Group] = {Communication_frm.Communication_ctrl1.Find_Particuls_ID(Idx).Text} and {Company_Visible_Filter}", cn)

            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                dt.Rows.Add(r("Name"), r("Under_Name"), r("ID"))
            End While
            r.Close()
            Ledger_Source.DataSource = dt
        End If





        Label2.Text = Find_DT_Value(Database_File.cre, "TBL_Acc_Group", "Name", $"ID = '{Communication_frm.Communication_ctrl1.Find_Particuls_ID(Idx).Text}'")


        Yn1.Text = Boolean_TXT(YN_Boolean(Communication_frm.Communication_ctrl1.Find_Whatsapp(Idx).Text))
        Yn2.Text = Boolean_TXT(YN_Boolean(Communication_frm.Communication_ctrl1.Find_Email(Idx).Text))

        'MsgBox(Data.Text)
        Dim data_() As String = Data.Text.Split(",")
        If data_.Length <> 1 Then
            For Each s As String In data_
                If s.Length > 3 Then
                    Dim d() As String = s.Split("-")
                    Dim id As String = d(0)
                    Dim name As String = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Name", $"ID = '{id}'")
                    Dim w As String = d(1)
                    Dim e As String = d(2)

                    Add_New(name, w, e)
                End If
            Next
        End If

        If platform.Controls.Count = 0 Then
            Add_New("", "Yes", "Yes")
        End If
    End Function
    Dim ag_list As List_frm
    Private Function List_set(idx As Integer)
        ag_list = New List_frm
        List_Setup("List of Ledger", Select_List.Right_Dock, Select_List_Format.Defolt, Find_Particuls(idx), ag_list, Ledger_Source, 320)


    End Function
    Public Function Add_New(name As String, w As String, e As String)
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

        Particuls_Panel_ctrl(particals_panel, name, w, e)

        platform.Controls.Add(bg_p)
        bg_p.BringToFront()

        List_set(curr_count + 1)
    End Function
    Private Function Particuls_Panel_ctrl(Pan As Panel, name As String, w As String, e As String)
        Dim particuls_id As Label = New Label
        Dim particuls_txt As TXT = New TXT
        Dim Whatsapp As YN = New YN
        Dim Emai As YN = New YN

        Pan.Controls.Add(particuls_txt)
        Pan.Controls.Add(Whatsapp)
        Pan.Controls.Add(Emai)

        Pan.Controls.Add(particuls_id)


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

        'Particuls_TXT

        particuls_txt.Name = "particulstxt_" & (curr_count + 1)
        particuls_txt.Dock = DockStyle.Fill
        particuls_txt.Size = Label4.Size
        particuls_txt.Padding = Label4.Padding
        particuls_txt.Text = name
        particuls_txt.Font = New Font("Arial", 10, FontStyle.Bold)
        particuls_txt.Type_ = "Select"
        particuls_txt.Select_Filter = "Name LIKE '%<value>%' or Under LIKE '%<value>%'"

        AddHandler particuls_txt.LostFocus, AddressOf Particuls_LostFocus
        AddHandler particuls_txt.KeyDown, AddressOf Particuls_KeyDown

        Whatsapp.Name = "wa_" & (curr_count + 1)
        Whatsapp.Width = 80
        Whatsapp.Dock = DockStyle.Right
        Whatsapp.Text = w
        Whatsapp.TextAlign = HorizontalAlignment.Center

        Whatsaap_Arryr.Add(Whatsapp)
        'AddHandler Whatsapp.TextChanged, AddressOf Applica_TextChange
        'AddHandler Whatsapp.LostFocus, AddressOf Bal_LostFocus


        Emai.Name = "em_" & (curr_count + 1)
        Emai.Width = 80
        Emai.Dock = DockStyle.Right
        Emai.Text = e
        Emai.TextAlign = HorizontalAlignment.Center
        Whatsaap_Arryr.Add(Emai)
        AddHandler Emai.KeyDown, AddressOf email_Keydown

    End Function
    Public Whatsaap_Arryr As New List(Of YN)
    Public Email_Arryr As New List(Of YN)
    Private Sub Particuls_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Dim idx As Integer = Find_Idx(sender)
            Find_Particuls_ID(idx).Text = ag_list.List_Grid.CurrentRow.Cells(2).Value
        End If
    End Sub
    Private Sub email_Keydown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            Add_New_condition(sender)
        End If
    End Sub
    Private Function Add_New_condition(sender As Object)
        Dim index As Integer = Find_Idx(sender)
        If platform.Controls.Count = index Then
            Add_New("", "Yes", "Yes")
        End If
    End Function
    Private Sub Particuls_LostFocus(sender As Object, e As EventArgs)
        Ledger_Source.MoveFirst()
        Dim idx As Integer = Find_Idx(sender)

        If sender.Text = "End of List" Then
            Find_Whatsapp(idx).Text = ""
            Find_Whatsapp(idx).Enabled = False

            Find_Email(idx).Text = ""
            Find_Email(idx).Enabled = False
        Else
            Find_Whatsapp(idx).Enabled = True
            Find_Email(idx).Enabled = True
        End If
    End Sub

    Public Function Find_Idx(sender As Object) As Integer
        Try
            Return sender.Name.Split("_")(1)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Whatsapp(index As Integer) As YN
        Try
            Return CType(platform.Controls.Find(("wa_" & index), True).First, YN)
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
    Public Function Find_Email(index As Integer) As YN
        Try
            Return CType(platform.Controls.Find(("em_" & index), True).First, YN)
        Catch ex As Exception

        End Try
    End Function
    Private Sub bg_panel_Enter(sender As Object, e As EventArgs)
        Dim col As Color = Color.FromArgb(254, 197, 48)
        sender.BackColor = col
        Dim idx As Integer = Find_Idx(sender)

        Find_Whatsapp(idx).Back_color = col
        Find_Email(idx).Back_color = col
        Find_Particuls(idx).Back_color = col

        Find_Whatsapp(idx).BackColor = col
        Find_Email(idx).BackColor = col
        Find_Particuls(idx).BackColor = col

    End Sub
    Private Sub bg_panel_Leave(sender As Object, e As EventArgs)
        Dim col As Color = platform.BackColor
        sender.BackColor = col

        Dim idx As Integer = Find_Idx(sender)
        Find_Whatsapp(idx).Back_color = col
        Find_Email(idx).Back_color = col
        Find_Particuls(idx).Back_color = col

        Find_Whatsapp(idx).BackColor = col
        Find_Email(idx).BackColor = col
        Find_Particuls(idx).BackColor = col
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Txt1_TextChanged(sender As Object, e As EventArgs) Handles Txt1.TextChanged

    End Sub

    Private Sub Txt1_Enter(sender As Object, e As EventArgs) Handles Txt1.Enter
        'Chack_al()
        With Communication_frm
            .Communication_ctrl1.Find_Whatsapp(Idx).Text = Boolean_TXT(YN_Boolean(Yn1.Text))
            .Communication_ctrl1.Find_Email(Idx).Text = Boolean_TXT(YN_Boolean(Yn2.Text))
            .Communication_ctrl1.find_data(Idx).Text = Data_List()
            .Panel2.Visible = True
        End With
        Me.Dispose()

    End Sub
    Private Function Data_List() As String
        Dim P_ As New Queue(Of Panel)()
        For Each bg_p As Panel In platform.Controls.OfType(Of Panel)()
            If Find_Particuls_ID(Find_Idx(bg_p)).Text = "0" Then
                platform.Controls.Remove(bg_p)
            End If
        Next
        For Each bg_p As Panel In platform.Controls.OfType(Of Panel)()
            P_.Enqueue(bg_p)
        Next
        Dim str As String = ""
        For Each bg_p As Panel In P_.Reverse
            Dim idx As Integer = Find_Idx(bg_p)

            Dim w As String = Boolean_TXT(YN_Boolean(Find_Whatsapp(idx).Text))
            Dim e As String = Boolean_TXT(YN_Boolean(Find_Email(idx).Text))


            str &= $"{Find_Particuls_ID(Find_Idx(bg_p)).Text}-{w}-{e},"
        Next

        If str.Length > 2 Then
            Return str.Substring(0, str.Length - 1)
        Else
            Return ""
        End If
    End Function
    Private Function Chack_al()
        Dim P_ As New Queue(Of Panel)()
        For Each bg_p As Panel In platform.Controls.OfType(Of Panel)()
            If Find_Particuls_ID(Find_Idx(bg_p)).Text = "0" Then
                platform.Controls.Remove(bg_p)
            End If
        Next
    End Function

    Private Sub Communication_ledger_ctrl_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        With Communication_frm
            .Communication_ctrl1.Show()
            .Communication_ctrl1.Find_Customer(Idx).Focus()
            SendKeys.Send("{TAB}")
        End With
    End Sub
End Class
