Imports System.Data.SQLite
Imports Tools
Public Class Communication_ctrl
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

        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select *,(Select ag.name From TBL_Acc_Group ag where ag.id = ld.[Group]) as Under_Name From TBL_Ledger ld where {Company_Visible_Filter()}", cn)

            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                dt.Rows.Add(r("Name"), r("Under_Name"), r("ID"))
            End While
            r.Close()
            Ledger_Source.DataSource = dt

            dt = New DataTable
            dt.Columns.Add("Name")
            dt.Columns.Add("Under")
            dt.Columns.Add("ID")
            dt.Rows.Add("End of List", "", "0")

            cmd = New SQLiteCommand($"Select *,(Select ag.name From TBL_Acc_Group ag where ag.id = ld.UserGroup) as Under_Name From TBL_Acc_Group ld where {Company_Visible_Filter}", cn)

            r = cmd.ExecuteReader
            While r.Read
                dt.Rows.Add(r("Name"), r("Under_Name"), r("ID"))
            End While
            r.Close()
            Group_Source.DataSource = dt
        End If

    End Function
    Dim ag_list As List_frm
    Private Function List_set(idx As Integer)
        ag_list = New List_frm
        List_Setup("List of Account Groups", Select_List.Right_Dock, Select_List_Format.Defolt, Find_Particuls(idx), ag_list, Group_Source, 320)


    End Function
    Public Function Load_data_Under()

    End Function
    Public Function Add_New()
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

        Particuls_Panel_ctrl(particals_panel)

        platform.Controls.Add(bg_p)
        bg_p.BringToFront()

        List_set((curr_count + 1))
    End Function
    Private Function Particuls_Panel_ctrl(Pan As Panel)
        Dim particuls_id As Label = New Label
        Dim data_ As Label = New Label
        Dim particuls_txt As TXT = New TXT
        Dim Whatsapp As YN = New YN
        Dim Emai As YN = New YN
        Dim customize As YN = New YN

        Pan.Controls.Add(particuls_txt)
        Pan.Controls.Add(data_)
        Pan.Controls.Add(Whatsapp)
        Pan.Controls.Add(Emai)
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
        particuls_txt.Text = ""
        particuls_txt.Font = New Font("Arial", 10, FontStyle.Bold)
        particuls_txt.Type_ = "Select"
        particuls_txt.Select_Filter = "Name LIKE '%<value>%' or Under LIKE '%<value>%'"

        AddHandler particuls_txt.LostFocus, AddressOf Particuls_LostFocus
        AddHandler particuls_txt.KeyDown, AddressOf Particuls_KeyDown

        Whatsapp.Name = "wa_" & (curr_count + 1)
        Whatsapp.Width = 75
        Whatsapp.Dock = DockStyle.Right
        Whatsapp.Text = ""
        Whatsapp.TextAlign = HorizontalAlignment.Center

        Whatsaap_Arryr.Add(Whatsapp)
        'AddHandler Whatsapp.TextChanged, AddressOf Applica_TextChange
        'AddHandler Whatsapp.LostFocus, AddressOf Bal_LostFocus


        Emai.Name = "em_" & (curr_count + 1)
        Emai.Width = 75
        Emai.Dock = DockStyle.Right
        Emai.Text = ""
        Emai.TextAlign = HorizontalAlignment.Center
        Whatsaap_Arryr.Add(Emai)
        AddHandler Emai.KeyDown, AddressOf email_Keydown

        customize.Name = "cus_" & (curr_count + 1)
        customize.Width = 75
        customize.Dock = DockStyle.Right
        customize.Text = ""
        customize.TextAlign = HorizontalAlignment.Center
        AddHandler customize.KeyDown, AddressOf customize_Keydown

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
            If sender.Text = "Yes" Then
                With Communication_frm
                    .Panel2.Visible = False
                    Dim frm_ As New Communication_ledger_ctrl

                    frm_.Data = find_data(Find_Idx(sender))
                    frm_.Idx = Find_Idx(sender)
                    frm_.Dock = DockStyle.Fill

                    .Communication_ctrl1.Hide()
                    .Panel1.Controls.Add(frm_)
                    frm_.BringToFront()

                    obj_center(frm_, .bg_Panel)

                End With
            End If
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
            Add_New()
        End If
    End Function
    Private Sub Particuls_LostFocus(sender As Object, e As EventArgs)
        Group_Source.MoveFirst()
        Dim idx As Integer = Find_Idx(sender)

        If sender.Text = "End of List" Then
            Find_Whatsapp(idx).Text = ""
            Find_Whatsapp(idx).Enabled = False

            Find_Email(idx).Text = ""
            Find_Email(idx).Enabled = False

            Find_Customer(idx).Text = ""
            Find_Customer(idx).Enabled = False

        Else
            Find_Whatsapp(idx).Enabled = True
            Find_Email(idx).Enabled = True
            Find_Customer(idx).Enabled = True
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
    Public Function find_data(index As Integer) As Label
        Try
            Return CType(platform.Controls.Find(("data_" & index), True).First, Label)
        Catch ex As Exception

        End Try
    End Function

    Public Function Find_Email(index As Integer) As YN
        Try
            Return CType(platform.Controls.Find(("em_" & index), True).First, YN)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Customer(index As Integer) As YN
        Try
            Return CType(platform.Controls.Find(("cus_" & index), True).First, YN)
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
        Find_Customer(idx).Back_color = col

        Find_Whatsapp(idx).BackColor = col
        Find_Email(idx).BackColor = col
        Find_Particuls(idx).BackColor = col
        Find_Customer(idx).BackColor = col

    End Sub
    Private Sub bg_panel_Leave(sender As Object, e As EventArgs)
        Dim col As Color = platform.BackColor
        sender.BackColor = col

        Dim idx As Integer = Find_Idx(sender)
        Find_Whatsapp(idx).Back_color = col
        Find_Email(idx).Back_color = col
        Find_Particuls(idx).Back_color = col
        Find_Customer(idx).Back_color = col

        Find_Whatsapp(idx).BackColor = col
        Find_Email(idx).BackColor = col
        Find_Particuls(idx).BackColor = col
        Find_Customer(idx).BackColor = col
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Txt1_TextChanged(sender As Object, e As EventArgs) Handles Txt1.TextChanged

    End Sub

    Private Sub Txt1_Enter(sender As Object, e As EventArgs) Handles Txt1.Enter
        If Msg_Custom_YN(NOT_Location.Bottom_Right, Color.Black, My.Resources.Question_animation_icn, Dialoag_Button.Yes_No, "Question?", "Save Communication", "") = DialogResult.Yes Then
            Chack_al()
            Save_data()
            Communication_frm.Dispose()
            cmp_cfg_bg_frm.Communication_Manu.Object_.Yn4.Focus()
            'SendKeys.Send("{TAB}")
        Else

        End If
    End Sub
    Public Function Save_data()
        Dim Group_Update As String = "UPDATE TBL_Acc_Group SET Communication_Whatsapp = @w,Communication_Email = @e"


        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then


            Dim q As String = Group_Update
            q = q.Replace("@w", "'No'")
            q = q.Replace("@e", "'No'")
            cmd = New SQLiteCommand(q, cn)
            'My.Computer.Clipboard.SetText(cmd.CommandText)
            cmd.ExecuteNonQuery()
            Dim P_ As New Queue(Of Panel)()
            For Each bg_p As Panel In platform.Controls.OfType(Of Panel)()
                P_.Enqueue(bg_p)
            Next
            For Each bg_p As Panel In P_.Reverse
                Dim idx As Integer = Find_Idx(bg_p)
                Dim id As String = Find_Particuls_ID(idx).Text
                Dim w As String = Find_Whatsapp(idx).Text
                Dim e As String = Find_Email(idx).Text
                q = Group_Update
                q = q.Replace("@w", $"'{w}'")
                q = q.Replace("@e", $"'{e}'")

                cmd = New SQLiteCommand($"{q} where id = '{id}'", cn)
                cmd.ExecuteNonQuery()
            Next

            cmd = New SQLiteCommand($"UPDATE TBL_Ledger SET Communication_Type = 'By Group (Default)', Communication_Whatsapp = (Select ag.Communication_Whatsapp From TBL_Acc_Group ag where ag.id = [Group]),Communication_Email = (Select ag.Communication_Email From TBL_Acc_Group ag where ag.id = [Group])", cn)
            cmd.ExecuteNonQuery()

            For Each bg_p As Panel In P_.Reverse
                Dim idx As Integer = Find_Idx(bg_p)

                Dim data_() As String = find_data(idx).Text.Split(",")
                For Each s As String In data_
                    If s.Length > 3 Then

                        Dim d() As String = s.Split("-")
                        Dim id_L As String = d(0)
                        Dim w_L As String = d(1)
                        Dim e_L As String = d(2)
                        cmd = New SQLiteCommand($"UPDATE TBL_Ledger SET Communication_Type = 'Custom',Communication_Whatsapp = '{w_L}',Communication_Email = '{e_L}' where id = '{id_L}'", cn)
                        cmd.ExecuteNonQuery()
                    End If
                Next
            Next
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

    Private Sub Ledger_Source_CurrentChanged(sender As Object, e As EventArgs) Handles Ledger_Source.CurrentChanged

    End Sub

    Private Sub Communication_ctrl_Enter(sender As Object, e As EventArgs) Handles Me.Enter

    End Sub
End Class
