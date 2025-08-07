Imports Tools

Public Class std_rate_ctrl
    Private Sub std_rate_ctrl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Fill_data_source()
    End Sub
    Private Function Fill_data_source()
        Dim dt As New DataTable
        dt.Columns.Add("Name")

        dt.Rows.Add(Stock_Item_frm.Unit_TXT.Text)
        dt.Rows.Add(Stock_Item_frm.Unit2TXT.Text)


        BindingSource1.DataSource = dt
    End Function
    Dim curr_count As Integer = 0
    Public Function Add_New(Date_ As String, Rate_ As String, Unit_ As String)
        curr_count = platform.Controls.OfType(Of Panel).ToList.Count
        Dim bg_p As Panel = New Panel
        Dim particals_panel As Panel = New Panel
        Dim Balance_panel As Panel = New Panel

        'bgpanel_
        '
        bg_p.Controls.Add(particals_panel)
        bg_p.Controls.Add(Balance_panel)
        bg_p.Dock = DockStyle.Top
        bg_p.Location = New Point(0, 0)
        bg_p.Name = "bg_" & (curr_count + 1)
        bg_p.TabIndex = curr_count
        bg_p.Size = New Size(903, 20)

        Particuls_Panel_ctrl(particals_panel, Date_, Rate_, Unit_)



        platform.Controls.Add(bg_p)
        bg_p.BringToFront()
    End Function
    Private Function Particuls_Panel_ctrl(Pan As Panel, Date_T As String, Rate_T As String, Unit_T As String)
        Dim date_ As TXT = New TXT
        Dim Rate_ As TXT = New TXT
        Dim Unit_ As TXT = New TXT

        Pan.Controls.Add(date_)
        Pan.Controls.Add(Rate_)
        Pan.Controls.Add(Unit_)

        Pan.Dock = DockStyle.Top
        Pan.Location = New Point(0, 0)
        Pan.Name = "particulspanel_" & (curr_count + 1)
        Pan.Size = New Size(903, 15)
        Pan.TabIndex = 0
        Pan.BackColor = Color.Beige
        Pan.Padding = New Padding(10, 0, 10, 0)

        AddHandler Pan.Enter, AddressOf bg_panel_Enter
        AddHandler Pan.Leave, AddressOf bg_panel_Leave

        With date_
            .Back_color = Color.Beige
            .BackColor = Color.Beige
            .BorderStyle = BorderStyle.None
            .Data_Link_ = ""
            .Dock = DockStyle.Left
            .Font = New Font("Arial", 9.75, FontStyle.Bold)
            .Keydown_Support = True
            .Name = "datetxt_" & (curr_count + 1)
            .Size = New Size(80, 17)
            .TabIndex = 0
            .TextAlign = HorizontalAlignment.Center
            .Type_ = "TXT"
            .Text = Date_T
            .BringToFront()

            AddHandler .LostFocus, AddressOf Date_LostFocus
            AddHandler .KeyDown, AddressOf Date_Keydown
        End With

        With Rate_
            .Back_color = Color.Beige
            .BackColor = Color.Beige
            .BorderStyle = BorderStyle.None
            .Data_Link_ = ""
            .Dock = DockStyle.Right
            .Font = New Font("Arial", 9.75, FontStyle.Bold)
            .Keydown_Support = False
            .Location = New Point(512, 0)
            .Name = "ratetxt_" & (curr_count + 1)
            .Size = New Size(80, 17)
            .TabIndex = 1
            .TextAlign = HorizontalAlignment.Right
            .Type_ = "Num"
            .Text = nUmBeR_FORMATE(Rate_T)
            .SendToBack()
            AddHandler .KeyDown, AddressOf Rate_Keydown
        End With

        With Unit_
            .Back_color = Color.Beige
            .BackColor = Color.Beige
            .BorderStyle = BorderStyle.None
            .Data_Link_ = ""
            .Dock = DockStyle.Right
            .Font = New Font("Arial", 10.0, FontStyle.Bold)
            .Keydown_Support = True
            .Location = New Point(0, 0)
            .Name = "unittxt_" & (curr_count + 1)
            .Size = New Size(80, 17)
            .TabIndex = 2
            .Type_ = "Select"
            .Select_Source = BindingSource1
            .Select_Column_Color = 5
            .Select_Auto_Show = False
            .Select_Filter = " "
            .Select_Columns = 0
            .SendToBack()

            List_set(Unit_)

            If Stock_Item_frm.Unit2TXT.Text = "(Not Applicable)" Then
                .Enabled = False
            End If

            .Text = Stock_Item_frm.Unit_TXT.Text
            .Text = Unit_T


            AddHandler .KeyDown, AddressOf Unit_Keydown

        End With
    End Function
    Dim it_list As List_frm
    Private Function List_set(sender As Object)
        it_list = New List_frm
        it_list.Name = "List_" & sender.Text.ToString.Split("_").Last
        List_Setup("List of Unit", Select_List.Right, Select_List_Format.Singel, sender, it_list, BindingSource1, 200)
    End Function
    Private Sub Date_LostFocus(sender As Object, e As EventArgs)
        If sender.Text = "NA" Then
            sender.Text = ""
            sender.Focus()
            Exit Sub
        End If

        Dim idx As Integer = Find_Idx(sender)
        sender.Text = Date_Formate(sender.Text)

    End Sub
    Private Sub Date_Keydown(sender As Object, e As KeyEventArgs)
        Dim idx As Integer = Find_Idx(sender)

        If e.KeyCode = Keys.Enter Then
            sender.Text = Date_Formate(sender.Text)

            If sender.Text = Nothing Then
                Find_Rate_TXT(idx).Text = ""
                Find_Rate_TXT(idx).Enabled = False

                Find_Unit_TXT(idx).Text = ""
                Find_Unit_TXT(idx).Enabled = False

            Else
                Find_Rate_TXT(idx).Enabled = True
                If Stock_Item_frm.Unit2TXT.Text = "(Not Applicable)" Then
                    Find_Unit_TXT(idx).Enabled = False
                Else
                    Find_Unit_TXT(idx).Enabled = True
                End If


                Date_Upper(sender)


            End If
        End If

    End Sub
    Private Function Date_Upper(sender As Object)
        Dim idx As Integer = Find_Idx(sender)

        For i As Integer = idx - 1 To 1 Step -1
            If Find_Date_TXT(i).Text <> Nothing Then
                Dim Dte_ As Date = CDate(Find_Date_TXT(i).Text)

                If CDate(sender.Text) <= Dte_ Then
                    sender.Text = "NA"
                    sender.Focus()
                    Exit Function
                End If
            End If
        Next
    End Function
    Private Sub Unit_Keydown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            Dim index As Integer = Find_Idx(sender)
            If platform.Controls.Count = index Then
                Add_New("", "", "")
            End If
        End If
    End Sub
    Private Sub Rate_Keydown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            Dim index As Integer = Find_Idx(sender)

            If Find_Unit_TXT(index).Enabled = False Then
                If platform.Controls.Count = index Then
                    Add_New("", "", "")
                End If
            End If

        End If
    End Sub
    Private Sub bg_panel_Enter(sender As Object, e As EventArgs)
        Dim col As Color = Color.FromArgb(254, 197, 48)
        sender.BackColor = col
        Dim idx As Integer = Find_Idx(sender)

        Find_Date_TXT(idx).Back_color = col
        Find_Rate_TXT(idx).Back_color = col
        Find_Unit_TXT(idx).Back_color = col

        Find_Date_TXT(idx).BackColor = col
        Find_Rate_TXT(idx).BackColor = col
        Find_Unit_TXT(idx).BackColor = col
    End Sub
    Private Sub bg_panel_Leave(sender As Object, e As EventArgs)
        Dim col As Color = Color.Beige
        sender.BackColor = col

        Dim idx As Integer = Find_Idx(sender)
        Find_Date_TXT(idx).Back_color = col
        Find_Rate_TXT(idx).Back_color = col
        Find_Unit_TXT(idx).Back_color = col


        Find_Date_TXT(idx).BackColor = col
        Find_Rate_TXT(idx).BackColor = col
        Find_Unit_TXT(idx).BackColor = col
    End Sub






    Public Function Find_Idx(sender As Object) As Integer
        Try
            Return sender.Name.Split("_")(1)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Particuls_Panel(index As Integer) As Panel
        Try
            Return CType(platform.Controls.Find(("Particulspanel_" & index), True).First, Panel)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Date_TXT(index As Integer) As TXT
        Try
            Return CType(platform.Controls.Find(("datetxt_" & index), True).First, TXT)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Rate_TXT(index As Integer) As TXT
        Try
            Return CType(platform.Controls.Find(("ratetxt_" & index), True).First, TXT)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Unit_TXT(index As Integer) As TXT
        Try
            Return CType(platform.Controls.Find(("unittxt_" & index), True).First, TXT)
        Catch ex As Exception

        End Try
    End Function
End Class
