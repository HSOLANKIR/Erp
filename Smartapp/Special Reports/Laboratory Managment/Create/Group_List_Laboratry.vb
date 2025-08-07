Imports Tools
Imports PopupControl
Public Class Group_List_Laboratry
    Private Sub Group_List_Laboratry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BindingSource1.DataSource = Group_info_Laboratry.Item_Source
    End Sub
    Dim curr_count As Integer = 0

    Public Function Add_New()
        curr_count = platform.Controls.OfType(Of Panel).ToList.Count
        Dim bg_p As Panel = New Panel
        Dim particals_panel As Panel = New Panel
        Dim Formula_panel As Panel = New Panel

        'bgpanel_
        '
        bg_p.Controls.Add(particals_panel)
        bg_p.Controls.Add(Formula_panel)
        bg_p.Dock = System.Windows.Forms.DockStyle.Top
        bg_p.Location = New Point(0, 0)
        bg_p.Name = "bg_" & (curr_count + 1)
        bg_p.TabIndex = curr_count
        bg_p.Size = New Size(903, 35)



        Particuls_Panel_ctrl(particals_panel)
        Formula_Panel_ctrl(Formula_panel)

        platform.Controls.Add(bg_p)
        bg_p.BringToFront()
    End Function
    Private Function Formula_Panel_ctrl(Pan As Panel)
        Dim Formula As Label = New Label

        Pan.Controls.Add(Formula)

        Pan.Dock = DockStyle.Top
        Pan.Location = New Point(0, 0)
        Pan.Name = "formulapanel_" & (curr_count + 1)
        Pan.Size = New Size(903, 15)
        Pan.TabIndex = 0
        Pan.BackColor = Color.White
        Pan.Padding = New Padding(10, 0, 10, 0)
        Pan.BringToFront()
        Pan.Visible = False

        With Formula
            .Name = "formulalab_" & (curr_count + 1)
            .TextAlign = ContentAlignment.MiddleLeft
            .Font = New Font("Arial", 10, FontStyle.Italic)
            .AutoSize = False
            .Dock = DockStyle.Fill
            .Size = Label1.Size
            .Padding = New Padding(Label1.Width, 0, 0, 0)
            .Text = ""
            .SendToBack()
        End With

    End Function
    Private Function Particuls_Panel_ctrl(Pan As Panel)
        Dim particuls_txt As TXT = New TXT
        Dim ID_ As Label = New Label
        Dim Defolt_Value_ As Label = New Label
        Dim Rate_ As Label = New Label
        Dim Formula As YN = New YN


        Pan.Controls.Add(ID_)
        Pan.Controls.Add(particuls_txt)
        Pan.Controls.Add(Defolt_Value_)
        Pan.Controls.Add(Rate_)
        Pan.Controls.Add(Formula)

        Pan.Dock = DockStyle.Top
        Pan.Location = New Point(0, 0)
        Pan.Name = "particulspanel_" & (curr_count + 1)
        Pan.Size = New Size(903, 15)
        Pan.TabIndex = 0
        Pan.BackColor = Color.White
        Pan.Padding = New Padding(10, 0, 10, 0)



        With ID_
            .Name = "Particulsid_" & (curr_count + 1)
            .TextAlign = ContentAlignment.MiddleLeft
            .AutoSize = False
            .Dock = DockStyle.Left
            .Size = Label1.Size
            .Padding = New Padding(8, 0, 0, 0)
            .Text = ""
            .SendToBack()
        End With

        With particuls_txt
            .Back_color = Color.White
            .BackColor = Color.White
            .Dock = DockStyle.Left
            .Font = New Font("Arial", 10.0, FontStyle.Bold)
            .Keydown_Support = True
            .Location = New Point(0, 0)
            .Name = "particulstxt_" & (curr_count + 1)
            .Size = Label4.Size
            .Padding = Label4.Padding
            .TabIndex = 0
            .Type_ = "Select"
            .Select_Source = BindingSource1
            .Select_Auto_Show = False
            .Select_Filter = "(Name Like '%<value>%' or Alias LIKE '%<value>%') or (Name = 'End of List')"
            .Select_Columns = 0
            .BringToFront()
            List_set(particuls_txt)

            AddHandler .LostFocus, AddressOf Particuls_LostFocus
            AddHandler .KeyDown, AddressOf Particuls_Keydown

        End With

        With Defolt_Value_
            .Name = "defoltvallab_" & (curr_count + 1)
            .TextAlign = ContentAlignment.MiddleRight
            .AutoSize = False
            .Dock = DockStyle.Left
            .Size = Label2.Size
            .Padding = Label2.Padding
            .BringToFront()
            .Text = ""
        End With

        Rate_.Name = "ratelab_" & (curr_count + 1)
        Rate_.TextAlign = ContentAlignment.MiddleRight
        Rate_.AutoSize = False
        Rate_.Dock = DockStyle.Left
        Rate_.Size = Label2.Size
        Rate_.Padding = Label2.Padding
        Rate_.Text = "0.00"
        Rate_.BringToFront()
        Amount_TXT_Arrya.Add(Rate_)
        AddHandler Rate_.TextChanged, AddressOf rate_TXT_TextChanged




        Formula.Name = "formulayn_" & (curr_count + 1)
        Formula.Width = 45
        Formula.Dock = DockStyle.Right
        Formula.Text = ""
        Formula.TextAlign = HorizontalAlignment.Center
        Formula.Enabled = False

        AddHandler Formula.KeyDown, AddressOf foemula_Keydown
        AddHandler Formula.TextChanged, AddressOf foemula_TexhChamge

    End Function
    Private Sub foemula_TexhChamge(sender As Object, e As EventArgs)
        Dim idx As Integer = Find_Idx(sender)
        Find_Formula_Panel(idx).Visible = YN_Boolean(sender.Text, False)
        If Find_Formula_Panel(idx).Visible = True Then
            Find_bg_Panel(idx).Height = 35
        Else
            Find_bg_Panel(idx).Height = 15
        End If
    End Sub
    Private Sub rate_TXT_TextChanged(sender As Object, e As EventArgs)
        SUM()

    End Sub


    Private Sub foemula_Keydown(sender As Object, e As KeyEventArgs)
        Dim index As Integer = Find_Idx(sender)
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            If platform.Controls.Count = index Then
                Add_New()
            Else

            End If

            If sender.Text = "Yes" Then
                Dim pop As Popup
                Dim Audit_cfg_pop As Object
                Audit_cfg_pop = New Group_Formula_Laboratry_ctrl
                pop = New Popup(Audit_cfg_pop)

                pop.FocusOnOpen = True
                Audit_cfg_pop.obj = Find_Formula_Label(index)
                Audit_cfg_pop.Head = Find_Particuls_TXT(index).Text

                pop.AnimationDuration = 1
                pop.Show(sender)
            End If
        End If
    End Sub
    Private Sub Particuls_KeyDown(sender As Object, e As KeyEventArgs)
        Dim idx As Integer = Find_Idx(sender)
        If e.KeyCode = Keys.Enter Then
            If it_list.List_Grid.CurrentRow.Cells(0).Value = "End of List" Then
                Find_Formula_YN(idx).Enabled = False
            Else
                Find_Formula_YN(idx).Enabled = True
            End If
        End If
    End Sub
    Private Sub Particuls_LostFocus(sender As Object, e As EventArgs)
        BindingSource1.MoveFirst()
        Dim TX_ As TXT = CType(sender, TXT)
        Dim index As Integer = Integer.Parse(TX_.Name.Split("_")(1))

        If Find_Particuls_TXT(Find_Idx(sender)).Text = "End of List" Then
            Find_Particuls_ID_LAB(index).Text = ""


            Find_Rate_LAB(index).Text = ""
            Find_Rate_LAB(index).Enabled = False

            Find_Defolt_val_LAB(index).Text = ""
            Find_Defolt_val_LAB(index).Enabled = False

            Find_Formula_YN(index).Text = ""
            Find_Formula_YN(index).Enabled = False

            Exit Sub
        Else
            Find_Rate_LAB(index).Enabled = True
            Find_Defolt_val_LAB(index).Enabled = True
            Find_Formula_YN(index).Enabled = True
        End If

        If Find_Particuls_TXT(Find_Idx(sender)).Text.Trim <> Nothing Then
            Find_Particuls_ID_LAB(index).Text = Find_DT_Value(Database_File.cre, "TBL_Stock_Item", "ID", "Name = '" & sender.Text & "'")
            Find_Defolt_val_LAB(index).Text = Val(Find_DT_Value(Database_File.cre, "TBL_Stock_Item", "Defolt_Value", "Name = '" & sender.Text & "'"))
            Find_Rate_LAB(index).Text = Val(Find_DT_Value(Database_File.cre, "TBL_Stock_Item", "MRP", "Name = '" & sender.Text & "'"))
        End If
    End Sub
    Dim it_list As List_frm
    Private Function List_set(sender As Object)
        it_list = New List_frm
        it_list.Name = "List_" & sender.Text.ToString.Split("_").Last
        List_Setup("List of Test", Select_List.Right_Dock, Select_List_Format.Defolt, sender, it_list, BindingSource1, 350)
    End Function

    Public Amount_TXT_Arrya As New List(Of Label)

    Public Function SUM()
        Try
            Label6.Text = nUmBeR_FORMATE(Amount_TXT_Arrya.Sum(Function(m)
                                                                  Return Val(m.Text)
                                                              End Function))
        Catch ex As Exception

        End Try
    End Function
    Public Function Clear_All_SUM()
        Amount_TXT_Arrya.Clear()
        Label6.Text = "0"
    End Function
    Public Function Find_Idx(sender As Object) As Integer
        Try
            Return sender.Name.Split("_")(1)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Particuls_TXT(index As Integer) As TXT
        Try
            Return CType(platform.Controls.Find(("Particulstxt_" & index), True).First, TXT)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Rate_LAB(index As Integer) As Label
        Try
            Return CType(platform.Controls.Find(("ratelab_" & index), True).First, Label)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Defolt_val_LAB(index As Integer) As Label
        Try
            Return CType(platform.Controls.Find(("defoltvallab_" & index), True).First, Label)
        Catch ex As Exception

        End Try
    End Function

    Public Function Find_Particuls_ID_LAB(index As Integer) As Label
        Try
            Return CType(platform.Controls.Find(("Particulsid_" & index), True).First, Label)
        Catch ex As Exception

        End Try
    End Function

    Public Function Find_Formula_YN(index As Integer) As YN
        Try
            Return CType(platform.Controls.Find(("formulayn_" & index), True).First, YN)
        Catch ex As Exception

        End Try
    End Function

    Public Function Find_Formula_Panel(index As Integer) As Panel
        Try
            Return CType(platform.Controls.Find(("formulapanel_" & index), True).First, Panel)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Formula_Label(index As Integer) As Label
        Try
            Return CType(platform.Controls.Find(("formulalab_" & index), True).First, Label)
        Catch ex As Exception

        End Try
    End Function

    Public Function Find_bg_Panel(index As Integer) As Panel
        Try
            Return CType(platform.Controls.Find(("bg_" & index), True).First, Panel)
        Catch ex As Exception

        End Try
    End Function


End Class
