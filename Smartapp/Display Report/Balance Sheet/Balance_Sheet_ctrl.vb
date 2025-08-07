Public Class Balance_Sheet_ctrl
    Public Property Name_ As String = ""

    Private Sub Balance_Sheet_ctrl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label4.Text = Name_
    End Sub

    Public curr_count As Integer = 0

    Public Enum Head_Type
        Head_Group = 0
        Under_Group = 1
        Under = 2
    End Enum

    Public Amount_Total As Decimal = 0
    Public Function Clear_All()
        Amount_Total = 0
        platform.Controls.Clear()
        Under_Panel.Clear()
    End Function
    Public Function Total_()
        Total_Label.Text = N2_FORMATE(Amount_Total)
    End Function

    Public Under_Panel As List(Of Panel) = New List(Of Panel)
    Public Function Add_New(id_ As String, nm As String, vlu As Decimal, Type_s As String)
        curr_count = platform.Controls.OfType(Of Panel).ToList.Count

        Dim bg_p As Panel = New Panel
        Dim top_border As Panel = New Panel

        Dim Head_P As Panel = New Panel
        Dim Head_TX As Label = New Label
        Dim Head_Vlu As Label = New Label
        Dim Type_ As Label = New Label
        Dim TX As TextBox = New TextBox


        With bg_p
            .Controls.Add(Head_P)
            .Controls.Add(Type_)
            .Dock = DockStyle.Top
            .Location = New Point(0, 0)

            .Name = "bg_" & (curr_count + 1)
            .AutoSize = True

            .TabIndex = curr_count
            .Size = New Size(903, 30)
            .Padding = New Padding(0, 5, 0, 0)

        End With

        With Type_
            .Name = "Type_" & (curr_count + 1)
            .Visible = False
            .Text = Type_s
        End With

        With Head_P
            .Controls.Add(TX)
            .Controls.Add(Head_TX)
            .Controls.Add(Head_Vlu)
            .Dock = DockStyle.Top
            .Name = "HeadPanel_" & (curr_count + 1)
            .Size = New Size(903, 18)

            AddHandler Head_P.Enter, AddressOf panel_Enter
            AddHandler Head_P.Leave, AddressOf pan_panel_Leave

        End With

        With TX
            .Name = $"ID_{(curr_count + 1)}_0"
            .Size = New Size(0, 0)
            .ReadOnly = True
            .Text = id_
            AddHandler TX.KeyDown, AddressOf Head_KeyDown
        End With

        With Head_TX
            .Dock = DockStyle.Fill
            .AutoSize = False
            .TextAlign = ContentAlignment.TopLeft
            .Font = New Font("Arial", 9.75!, FontStyle.Bold)
            .Text = nm
            .UseMnemonic = False
            .Name = "Headtxt_" & (curr_count + 1)
            .Font = New Font("Arial", 9.75!, FontStyle.Bold)
        End With


        With Head_Vlu
            .Dock = DockStyle.Right
            .AutoSize = False
            .TextAlign = ContentAlignment.TopRight
            .Size = New Size(100, 18)
            .Text = N2_FORMATE(vlu)


            .Font = New Font("Arial", 9.75!, FontStyle.Bold)
            .Name = "Headval_" & (curr_count + 1)
            .UseMnemonic = False
            .SendToBack()
        End With

        platform.Controls.Add(bg_p)
        bg_p.BringToFront()
    End Function
    Public Function Add_Under_New(Ht As Head_Type, Curent_idx As String, idx As Integer, Nm As String, vlu As String, Type_s As String)
        Dim id_ As Integer = Find_Head_bg_Panel(idx).Controls.OfType(Of Panel).ToList.Count
        Find_Head_Vlu(idx).Text = N2_FORMATE(nUmBeR_FORMATE(Find_Head_Vlu(idx).Text) + Val(vlu))

        Amount_Total += Val(vlu)

        'MsgBox($"{Nm} {Val(vlu)} {N2_FORMATE(vlu)}")

        Dim bg_p As Panel = New Panel
        Dim Head_P As Panel = New Panel
        Dim Head_TX As Label = New Label
        Dim Head_Vlu As Label = New Label
        Dim Type_ As Label = New Label
        Dim TX As TextBox = New TextBox


        bg_p.Controls.Add(Head_P)
        bg_p.Controls.Add(Type_)
        bg_p.Dock = DockStyle.Top
        bg_p.Location = New Point(0, 0)
        bg_p.Name = $"Ubg{idx}_{id_}"
        bg_p.TabIndex = id_ '+ 2
        bg_p.Size = New Size(903, 18)
        bg_p.Tag = Ht.ToString

        If Ht = 1 Then
            bg_p.Font = New Font("Arial", 10, FontStyle.Regular)
        Else
            bg_p.Font = New Font("Arial", 10, FontStyle.Italic)
        End If

        Under_Panel.Add(bg_p)

        With Type_
            .Name = $"Type_{idx}_{id_}"
            .Visible = False
            .Text = Type_s
        End With


        Head_P.Controls.Add(Head_TX)
        Head_P.Controls.Add(Head_Vlu)
        Head_P.Controls.Add(TX)
        Head_P.Dock = DockStyle.Top
        Head_P.Name = $"UnderPanel{idx}_{id_}"
        Head_P.Size = New Size(903, 18)

        AddHandler Head_P.Enter, AddressOf panel_Enter
        AddHandler Head_P.Leave, AddressOf pan_panel_Leave

        Head_TX.Dock = DockStyle.Fill
        Head_TX.AutoSize = False
        Head_TX.TextAlign = ContentAlignment.TopLeft
        Head_TX.Padding = New Padding(30, 0, 0, 0)
        Head_TX.Name = $"Undertxt{idx}_{id_}"
        Head_TX.Text = Nm



        Head_Vlu.Dock = DockStyle.Right
        Head_Vlu.AutoSize = False
        Head_Vlu.TextAlign = ContentAlignment.TopRight
        Head_Vlu.Size = New Size(200, 18)
        Head_Vlu.Padding = New Padding(0, 0, 100, 0)
        Head_Vlu.Name = $"Underval{idx}_{id_}"
        Head_Vlu.Text = N2_FORMATE(vlu)
        Head_Vlu.SendToBack()

        With TX
            .Name = $"ID_{idx}_{id_}"
            .Size = New Size(1, 1)
            .ReadOnly = True
            .Text = Curent_idx
            AddHandler TX.KeyDown, AddressOf Under_KeyDown

        End With

        Find_Head_bg_Panel(idx).Controls.Add(bg_p)
        bg_p.BringToFront()

    End Function

    Private Sub Head_KeyDown(sender As Object, e As KeyEventArgs)

        If e.KeyCode = Keys.Enter Then
            Dim idx As Integer = Find_Idx(sender)
            Dim typ As String = Find_Type_Head_Vlu(idx).Text
            With Balance_Sheet_frm
                If typ = "Acc_Group" Then
                    Dim Frm As Object = Cell("Group Summary", "", "Display", sender.Text)
                    With Frm
                        .YN_Opning_Balance = True
                        .Fill_Grid()
                    End With

                ElseIf typ = "Closing_Stock" Then
                    Cell("Group Stock Summary", "", "", "", "")
                    Stock_Group_Summary_frm.To_Date_LB.Text = .to_date
                    Stock_Group_Summary_frm.Fill_Grid()
                ElseIf typ = "Acc_Ledger" Then
                    Cell("Report Ledger", "", "Display", sender.Text, .Frm_date, .to_date)
                ElseIf typ = "Profit&Loss" Then
                    Cell("Profit & Loss Account", "", "Display", "", "", "")

                End If
            End With
        ElseIf e.KeyCode = Keys.Up Then
            SendKeys.Send("+{TAB}")
        ElseIf e.KeyCode = Keys.Down Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Under_KeyDown(sender As Object, e As KeyEventArgs)
        Dim idx As Integer = Find_Idx(sender)
        Dim idx2 As Integer = Find_Idx2(sender)


        If e.KeyCode = Keys.Enter Then
            Dim typ As String = Find_Type_Under_Vlu(idx, idx2).Text

            With Balance_Sheet_frm
                If typ = "Acc_Group" Then
                    Cell("Group Summary", "", "Display", sender.Text)
                    Report_Group_Summary_frm.YN_Opning_Balance = True
                    Report_Group_Summary_frm.Fill_Grid()
                ElseIf typ = "Closing_Stock" Then
                    Cell("Group Stock Summary", "", "", "", "")
                    Stock_Group_Summary_frm.To_Date_LB.Text = .to_date
                    Stock_Group_Summary_frm.Fill_Grid()
                ElseIf typ = "Acc_Ledger" Then
                    Cell("Report Ledger", "", "Display", sender.Text, .Frm_date, .to_date)

                End If
            End With
        ElseIf e.KeyCode = Keys.Up Then
            SendKeys.Send("+{TAB}")
        ElseIf e.KeyCode = Keys.Down Then
            SendKeys.Send("{TAB}")
        End If

    End Sub


    Public Function Focus_Color(idx As Object)
        Dim col As Color = Color.FromArgb(254, 197, 48)
        idx.BackColor = col
    End Function
    Public Sub panel_Enter(sender As Object, e As EventArgs)
        Dim col As Color = Color.FromArgb(254, 197, 48)
        'sender.BackColor = col
        Dim idx As Integer = Find_Idx(sender)

        Focus_Color(sender)

    End Sub
    Private Sub pan_panel_Leave(sender As Object, e As EventArgs)
        Dim col As Color = platform.BackColor
        sender.BackColor = col
    End Sub

    Public Function Find_Idx(sender As Object) As Integer
        Try
            Return sender.Name.Split("_")(1)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Idx2(sender As Object) As Integer
        Try
            Return sender.Name.Split("_")(2)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Head_bg_Panel(index As Integer) As Panel
        Try
            Return CType(platform.Controls.Find(("bg_" & index), True).First, Panel)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Head_Vlu(ix1 As Integer) As Label
        Try
            Return CType(platform.Controls.Find(($"Headval_{ix1}"), True).First, Label)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Head_TXT(ix1 As Integer) As Label
        Try
            Return CType(platform.Controls.Find(($"Headtxt_{ix1}"), True).First, Label)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Under_TXT(ix1 As Integer, ix2 As Integer) As Label
        Try
            Return CType(platform.Controls.Find(($"Undertxt{ix1}_{ix2}"), True).First, Label)
        Catch ex As Exception

        End Try
    End Function

    Public Function Find_Under_Vlu(ix1 As Integer, ix2 As Integer) As Label
        Try
            Return CType(platform.Controls.Find(($"Underval{ix1}_{ix2}"), True).First, Label)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Type_Head_Vlu(ix1 As Integer) As Label
        Try
            Return CType(platform.Controls.Find(($"Type_{ix1}"), True).First, Label)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Type_Under_Vlu(ix1 As Integer, ix2 As Integer) As Label
        Try
            Return CType(platform.Controls.Find(($"Type_{ix1}_{ix2}"), True).First, Label)
        Catch ex As Exception

        End Try
    End Function


    Public Function find_ID(ix1 As Integer, ix2 As Integer) As TextBox
        Try
            Return CType(platform.Controls.Find(($"ID_{ix1}_{ix2}"), True).First, TextBox)
        Catch ex As Exception

        End Try
    End Function

    Private Sub platform_Paint(sender As Object, e As PaintEventArgs) Handles platform.Paint

    End Sub
End Class
