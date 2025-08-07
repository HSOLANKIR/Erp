Imports Tools

Public Class Profi_Loss_ctrl
    Private Sub Profi_Loss_ctrl_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public curr_count As Integer = 0

    Public Enum Head_Type
        Head = 0
        Under = 1
        Gross_Profit_Loss = 2
        Total_ = 3
    End Enum

    Public Amount_Total As Decimal = 0
    Public Indirect_Total As Decimal = 0
    Public Function Clear_All()
        Amount_Total = 0
        Indirect_Total = 0
        platform.Controls.Clear()
        Under_Panel.Clear()


    End Function
    Public Function Gross_Calculation()

        Add_New("", Head_Type.Gross_Profit_Loss, "", 0, False, "")
        Add_New("", Head_Type.Total_, "", (Amount_Total), False, "")


    End Function
    Public Under_Panel As List(Of Panel) = New List(Of Panel)

    Public Function Add_New(idx As String, hd As Head_Type, nm As String, vlu As String, Focus As Boolean, Group As String)
        curr_count = platform.Controls.OfType(Of Panel).ToList.Count

        Dim bg_p As Panel = New Panel

        Dim Head_P As Panel = New Panel
        Dim Head_TX As Label = New Label
        Dim Head_Vlu As Label = New Label
        Dim TX As TextBox = New TextBox
        Dim Group_Label As Label = New Label

        With bg_p
            .Controls.Add(Head_P)
            .Controls.Add(Group_Label)
            .Dock = DockStyle.Top
            .Location = New Point(0, 0)
            If hd = 3 Then
                .Name = "totalP_"
                .AutoSize = False
            Else
                .Name = "bg_" & (curr_count + 1)
                .AutoSize = True
            End If

            .Tag = hd.ToString

            .TabIndex = curr_count
            .Size = New Size(903, 30)
            .Padding = New Padding(0, 5, 0, 0)
        End With

        With Group_Label
            .Name = $"GroupLabel_{(curr_count + 1)}"
            .Visible = False
            .Text = Group
        End With


        If hd = 3 Then
            Dim total_p1 As Panel = New Panel
            Dim total_p2 As Panel = New Panel
            Dim total_lab As Label = New Label
            Dim border1 As Panel = New Panel
            Dim border2 As Panel = New Panel

            With Head_P
                .Controls.Add(total_p1)
                .Dock = DockStyle.Bottom
                .Name = "HeadPanel_" & (curr_count + 1)
                .Size = New Size(903, 19)
            End With




            With total_p1
                .Controls.Add(total_p2)
                '.Controls.Add(total_lab)
                '.Controls.Add(border1)
                .Dock = DockStyle.Bottom
                .Height = 18
            End With
            With total_p2
                .Controls.Add(border1)
                .Controls.Add(total_lab)
                .Controls.Add(border2)
                .Size = New Size(130, 20)
                .Dock = DockStyle.Right
            End With

            With total_lab
                .Name = "subtotal_"
                .Dock = DockStyle.Right
                .TextAlign = ContentAlignment.MiddleRight
                .AutoSize = False
                .Width = 100
                .Font = New Font("Arial", 9.75!, FontStyle.Bold)
                .Text = N2_FORMATE(vlu)
                .Tag = TX

                '.BackColor = Color.Gainsboro
            End With

            With border1
                .Dock = DockStyle.Top
                .Height = 1
                .BackColor = Color.Silver
                .SendToBack()
            End With
            With border2
                .Dock = DockStyle.Bottom
                .Height = 1
                .BackColor = Color.Silver
                .SendToBack()
            End With
        Else
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
                .Name = "ID_" & (curr_count + 1)
                .Size = New Size(0, 0)
                .ReadOnly = True
                .Text = idx
                .Tag = hd
                AddHandler TX.KeyDown, AddressOf Head_KeyDown
            End With



            With Head_TX
                .Dock = DockStyle.Fill
                .AutoSize = False
                .TextAlign = ContentAlignment.TopLeft
                .Font = New Font("Arial", 9.75!, FontStyle.Bold)
                .Text = nm
                .Tag = TX

                If hd = 0 Then
                    .Name = "Headtxt_" & (curr_count + 1)
                    .Font = New Font("Arial", 9.75!, FontStyle.Bold)
                ElseIf hd = 2 Then
                    .Name = "grossprofitlosstxt_"
                    .Font = New Font("Arial", 9.75!, FontStyle.Bold Or FontStyle.Italic)
                End If
                AddHandler Head_TX.Click, AddressOf Click_
            End With


            With Head_Vlu
                .Dock = DockStyle.Right
                .AutoSize = False
                .TextAlign = ContentAlignment.TopRight
                .Size = New Size(100, 18)
                .Text = N2_FORMATE(vlu)
                .Tag = TX
                If hd = 2 Then
                    .Name = "grossprofitlossvlu_"
                    .Font = New Font("Arial", 9.75!, FontStyle.Bold Or FontStyle.Italic)
                Else
                    .Font = New Font("Arial", 9.75!, FontStyle.Bold)
                    .Name = "Headval_" & (curr_count + 1)
                End If
                .SendToBack()

                AddHandler Head_Vlu.Click, AddressOf Click_
            End With
        End If


        platform.Controls.Add(bg_p)
        bg_p.BringToFront()


        If Focus = True Then
            TX.Focus()
        End If
    End Function

    Public Function Add_Under_New(Head_idx As String, Curent_idx As String, idx As Integer, Nm As String, vlu As Decimal, Group As String)
        Dim id_ As Integer = Find_Head_bg_Panel(idx).Controls.OfType(Of Panel).ToList.Count
        Find_Head_Vlu(idx).Text = N2_FORMATE(nUmBeR_FORMATE(Find_Head_Vlu(idx).Text) + nUmBeR_FORMATE(vlu))

        If Head_idx = "14" Or Head_idx = "15" Then
            Indirect_Total += nUmBeR_FORMATE(vlu)
        End If

        Amount_Total += nUmBeR_FORMATE(vlu)


        Dim bg_p As Panel = New Panel
        Dim Head_P As Panel = New Panel
        Dim Head_TX As Label = New Label
        Dim Head_Vlu As Label = New Label
        Dim TX As TextBox = New TextBox


        bg_p.Controls.Add(Head_P)
        bg_p.Dock = DockStyle.Top
        bg_p.Location = New Point(0, 0)
        bg_p.Name = $"Ubg{idx}_{id_}"
        bg_p.TabIndex = id_ '+ 2
        bg_p.Size = New Size(903, 18)

        Under_Panel.Add(bg_p)

        Head_P.Controls.Add(Head_TX)
        Head_P.Controls.Add(Head_Vlu)
        Head_P.Controls.Add(TX)
        Head_P.Dock = DockStyle.Top
        Head_P.Name = $"UnderPanel{idx}_{id_}"
        Head_P.Size = New Size(903, 18)
        Head_P.Tag = Group

        AddHandler Head_P.Enter, AddressOf panel_Enter
        AddHandler Head_P.Leave, AddressOf pan_panel_Leave


        Head_TX.Dock = DockStyle.Fill
        Head_TX.AutoSize = False
        Head_TX.TextAlign = ContentAlignment.TopLeft
        Head_TX.Font = New Font("Arial", 10, FontStyle.Italic)
        Head_TX.Padding = New Padding(30, 0, 0, 0)
        Head_TX.Name = $"Undertxt{idx}_{id_}"
        Head_TX.Text = Nm
        Head_TX.Tag = TX
        AddHandler Head_TX.Click, AddressOf Click_



        Head_Vlu.Dock = DockStyle.Right
        Head_Vlu.AutoSize = False
        Head_Vlu.TextAlign = ContentAlignment.TopRight
        Head_Vlu.Size = New Size(200, 18)
        Head_Vlu.Padding = New Padding(0, 0, 100, 0)
        Head_Vlu.Font = New Font("Arial", 10, FontStyle.Italic)
        Head_Vlu.Name = $"Underval{idx}_{id_}"
        Head_Vlu.Text = N2_FORMATE(vlu)
        Head_Vlu.Tag = TX
        Head_Vlu.SendToBack()
        AddHandler Head_Vlu.Click, AddressOf Click_



        With TX
            .Name = $"IDUnder_{idx}_{id_}"
            .Size = New Size(1, 1)
            .ReadOnly = True
            .Text = Curent_idx
            .Tag = Head_Type.Under
            AddHandler TX.KeyDown, AddressOf Under_KeyDown
        End With

        Find_Head_bg_Panel(idx).Controls.Add(bg_p)
        bg_p.BringToFront()

    End Function
    Public Function Find_Head_bg_Panel(index As Integer) As Panel
        Try
            Return CType(platform.Controls.Find(("bg_" & index), True).First, Panel)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Head_Panel(index As Integer) As Panel
        Try
            Return CType(platform.Controls.Find(("HeadPanel_" & index), True).First, Panel)
        Catch ex As Exception

        End Try
    End Function

    Public Function Find_Total_Panel() As Panel
        Try
            Return CType(platform.Controls.Find(("totalP_"), True).First, Panel)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Total_Label() As Label
        Try
            Return CType(platform.Controls.Find(("subtotal_"), True).First, Label)
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

    Public Function Find_Head_Vlu(ix1 As Integer) As Label
        Try
            Return CType(platform.Controls.Find(($"Headval_{ix1}"), True).First, Label)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Group_Label(ix1 As Integer) As Label
        Try
            Return CType(platform.Controls.Find(($"GroupLabel_{ix1}"), True).First, Label)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Head_TXT(ix1 As Integer) As Label
        Try
            Return CType(platform.Controls.Find(($"Headtxt_{ix1}"), True).First, Label)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_ID_TXT(ix1 As Integer) As TextBox
        Try
            Return CType(platform.Controls.Find(($"ID_{ix1}"), True).First, TextBox)
        Catch ex As Exception

        End Try
    End Function

    Public Function Find_Under_ID(ix1 As Integer, ix2 As Integer) As TextBox
        Try
            Return CType(platform.Controls.Find(($"IDUnder{ix1}_{ix2}"), True).First, TextBox)
        Catch ex As Exception

        End Try
    End Function


    Public Function Find_Gross_profil_loss_TXT() As Label
        Try
            Return CType(platform.Controls.Find(($"grossprofitlosstxt_"), True).First, Label)
        Catch ex As Exception

        End Try
    End Function

    Public Function Find_Gross_profil_loss_vlu() As Label
        Try
            Return CType(platform.Controls.Find(($"grossprofitlossvlu_"), True).First, Label)
        Catch ex As Exception

        End Try
    End Function


    Public Function Find_U_bg_Panel(ix1 As Integer, ix2 As Integer) As Panel
        Try
            Return CType(platform.Controls.Find(($"Ubg{ix1}_{ix2}"), True).First, Panel)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Under_Panel(ix1 As Integer, ix2 As Integer) As Panel
        Try
            Return CType(platform.Controls.Find(($"UnderPanel{ix1}_{ix2}"), True).First, Panel)
        Catch ex As Exception

        End Try
    End Function


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

    Private Sub Under_KeyDown(sender As Object, e As KeyEventArgs)
        Dim i1 As Integer = sender.Name.Split("_")(1)
        Dim i2 As Integer = sender.Name.Split("_")(2)

        If e.KeyCode = Keys.Enter Then
            With Profit_Loss_frm

                If Find_Under_Panel(i1, i2).Tag = "Opning Stock" Then
                    Cell("Stock Summary", "", "Display", sender.Text, Company_Book_frm, .Frm_date, "")
                ElseIf Find_Under_Panel(i1, i2).Tag = "Closing Stock" Then
                    Cell("Stock Summary", "", "Display", sender.Text, .Frm_date, .to_date, "")
                ElseIf Find_Under_Panel(i1, i2).Tag = "Account_Ledger" Then
                    Cell("Report Ledger", "", "Display", sender.Text, .Frm_date, .to_date)
                ElseIf Find_Under_Panel(i1, i2).Tag = "Payroll" Then
                    Cell("Payroll Vouchers", 0, sender.Text)
                End If


                'Select Case Find_Head_TXT(idx).Text
                '    Case "Opning Stock"
                '        Cell("Stock Summary", "", "Display", sender.Text, Company_Book_frm, .Frm_date, "")
                '    Case "Closing Stock"
                '        Cell("Stock Summary", "", "Display", sender.Text, .Frm_date, .to_date, "")
                '    Case Else
                '        Cell("Report Ledger", "", "Display", sender.Text, .Frm_date, .to_date)

                'End Select
            End With
        ElseIf e.KeyCode = Keys.Up Then
            SendKeys.Send("+{TAB}")
        ElseIf e.KeyCode = Keys.Down Then
            SendKeys.Send("{TAB}")
        End If

    End Sub
    Private Sub Head_KeyDown(sender As Object, e As KeyEventArgs)
        Dim idx As Integer = Find_Idx(sender)
        Click_(sender, e)

        If e.KeyCode = Keys.Enter Then
            If Find_Group_Label(idx).Text = "Opning Stock" Then
                Cell("Group Stock Summary", "", "", "", "")
                Stock_Group_Summary_frm.To_Date_LB.Text = Profit_Loss_frm.Frm_date
                Stock_Group_Summary_frm.Fill_Grid()
            ElseIf Find_Group_Label(idx).Text = "Closing Stock" Then
                Cell("Group Stock Summary", "", "", "", "")
                Stock_Group_Summary_frm.To_Date_LB.Text = Profit_Loss_frm.to_date
                Stock_Group_Summary_frm.Fill_Grid()
            ElseIf Find_Group_Label(idx).Text = "Account_Group" Then
                Cell("Group Summary", "", "Display", sender.Text)
                Report_Group_Summary_frm.YN_Opning_Balance = False
                Report_Group_Summary_frm.Fill_Grid()
            ElseIf Find_Group_Label(idx).Text = "Payroll" Then
                Cell("Group Summary", "", "Display", sender.Text)
                Report_Group_Summary_frm.YN_Opning_Balance = False
                Report_Group_Summary_frm.Fill_Grid()
            End If


            'Select Case Find_Head_TXT(idx).Text
            '    Case "Opning Stock"
            '        Profit_Loss_frm.Focus_ID = "Opning Stock"
            '        Cell("Group Stock Summary", "", "", "", "")
            '        Stock_Group_Summary_frm.To_Date_LB.Text = Profit_Loss_frm.Frm_date
            '        Stock_Group_Summary_frm.Fill_Grid()
            '    Case "Closing Stock"
            '        Profit_Loss_frm.Focus_ID = "Closing Stock"
            '        Cell("Group Stock Summary", "", "", "", "")
            '        Stock_Group_Summary_frm.To_Date_LB.Text = Profit_Loss_frm.to_date
            '        Stock_Group_Summary_frm.Fill_Grid()
            '    Case Else
            '        If Val(sender.Text) <> 0 Then
            '            Cell("Group Summary", "", "Display", sender.Text)
            '            Report_Group_Summary_frm.YN_Opning_Balance = False
            '            Report_Group_Summary_frm.Fill_Grid()

            '        End If
            'End Select
        ElseIf e.KeyCode = Keys.Up Then
            SendKeys.Send("+{TAB}")
        ElseIf e.KeyCode = Keys.Down Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Click_(sender As Object, e As EventArgs)
        Dim i1 As Integer = 0
        Dim i2 As Integer = 0

        Try
            i1 = sender.Name.Split("_")(1)
            i2 = sender.Name.Split("_")(2)
        Catch ex As Exception

        End Try

        Try
            sender.Tag.Focus()
        Catch ex As Exception

        End Try

    End Sub
End Class
