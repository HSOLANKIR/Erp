Imports Tools
Public Class Ledger_Branch_Balance_ctrl
    Dim curr_count As Integer = 0
    Private Sub Ledger_Branch_Balance_ctrl_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Function Add_New()
        curr_count = platform.Controls.OfType(Of Panel).ToList.Count
        Dim bg_p As Panel = New Panel
        Dim particals_panel As Panel = New Panel
        Dim Balance_panel As Panel = New Panel

        'bgpanel_
        '
        bg_p.Controls.Add(particals_panel)
        bg_p.Dock = DockStyle.Top
        bg_p.Location = New Point(0, 0)
        bg_p.Name = "bg_" & (curr_count + 1)
        bg_p.TabIndex = curr_count
        bg_p.Size = New Size(903, 20)

        Particuls_Panel_ctrl(particals_panel)

        platform.Controls.Add(bg_p)
        bg_p.BringToFront()
    End Function
    Private Function Particuls_Panel_ctrl(Pan As Panel)
        Dim particuls_txt As Label = New Label
        Dim Applica_ As YN = New YN
        Dim bal_val_ As TXT = New TXT
        Dim bal_type_ As TXT = New TXT
        Dim bra_id_ As Label = New Label


        Pan.Controls.Add(particuls_txt)
        Pan.Controls.Add(Applica_)
        Pan.Controls.Add(bal_val_)
        Pan.Controls.Add(bal_type_)

        Pan.Controls.Add(bra_id_)


        Pan.Dock = System.Windows.Forms.DockStyle.Top
        Pan.Location = New Point(0, 0)
        Pan.Name = "particulspanel_" & (curr_count + 1)
        Pan.Size = New Size(903, 15)
        Pan.TabIndex = 0
        Pan.BackColor = Color.White
        Pan.Padding = New Padding(10, 0, 10, 0)

        AddHandler Pan.Enter, AddressOf bg_panel_Enter
        AddHandler Pan.Leave, AddressOf bg_panel_Leave


        bra_id_.Name = "BranchID_" & (curr_count + 1)
        bra_id_.Visible = False

        'Particuls_TXT


        particuls_txt.Name = "particulstxt_" & (curr_count + 1)
        particuls_txt.TextAlign = ContentAlignment.MiddleLeft
        particuls_txt.AutoSize = False
        particuls_txt.Dock = DockStyle.Left
        particuls_txt.Size = Label4.Size
        particuls_txt.Padding = Label4.Padding
        particuls_txt.Text = ""

        Applica_.Name = "Applicable_" & (curr_count + 1)
        Applica_.Width = 45
        Applica_.Dock = DockStyle.Right
        Applica_.Text = ""
        Applica_.TextAlign = HorizontalAlignment.Center

        AddHandler Applica_.TextChanged, AddressOf Applica_TextChange
        AddHandler Applica_.LostFocus, AddressOf Bal_LostFocus

        bal_val_.Name = "balval_" & (curr_count + 1)
        bal_val_.Width = 80
        bal_val_.Dock = DockStyle.Right
        bal_val_.Text = ""
        bal_val_.Type_ = "Num"

        bal_val_.TextAlign = HorizontalAlignment.Right
        AddHandler bal_val_.LostFocus, AddressOf Bal_LostFocus

        bal_type_.Name = "baltype_" & (curr_count + 1)
        bal_type_.Width = 30
        bal_type_.Dock = DockStyle.Right
        bal_type_.Text = ""
        bal_type_.Type_ = "TXT"
        bal_type_.ReadOnly = True
        bal_type_.TextAlign = HorizontalAlignment.Center
        AddHandler bal_type_.KeyDown, AddressOf bal_type_Keydown
        AddHandler bal_type_.LostFocus, AddressOf Bal_LostFocus

    End Function
    Private Sub bal_type_Keydown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.C Then
            sender.Text = "Cr"
        ElseIf e.KeyCode = Keys.D Then
            sender.Text = "Dr"
        End If
    End Sub
    Private Sub Bal_LostFocus(sender As Object, e As EventArgs)
        If sender.Text = "" Then
            sender.Text = "Cr"
        End If


        Dim P_ As New Queue(Of Panel)()
        For Each bg_p As Panel In platform.Controls.OfType(Of Panel)()
            P_.Enqueue(bg_p)
        Next
        Dim vl As Decimal = 0
        For Each bg_p As Panel In P_.Reverse
            Dim idx As Integer = Find_Idx(bg_p)
            If Find_Bal_Type(idx).Text = "Cr" Then
                vl += Val(Find_Bal_Vall(idx).Text)
            Else
                vl += (Val(Find_Bal_Vall(idx).Text) * -1)
            End If
        Next

        If vl = 0 Then
            Label6.Text = "0"
        ElseIf vl < 0 Then
            Label6.Text = vl * -1
            Label3.Text = "Dr"
        Else
            Label6.Text = vl
            Label3.Text = "Cr"
        End If

        Ledger_frm.Opning_Balance_TXT.Text = Val(Label6.Text)
        Ledger_frm.Txt3.Text = (Label3.Text)
    End Sub
    Private Sub Applica_TextChange(sender As Object, e As EventArgs)
        Dim idx As Integer = Find_Idx(sender)
        If sender.Text = "Yes" Then
            Find_Bal_Vall(idx).Enabled = True
            Find_Bal_Type(idx).Enabled = True

        Else
            Find_Bal_Vall(idx).Enabled = False
            Find_Bal_Type(idx).Enabled = False

            Find_Bal_Vall(idx).Text = ""
            Find_Bal_Type(idx).Text = ""
        End If
    End Sub
    Private Sub bg_panel_Enter(sender As Object, e As EventArgs)
        Dim col As Color = Color.FromArgb(254, 197, 48)
        sender.BackColor = col
        Dim idx As Integer = Find_Idx(sender)

        Find_Bal_Vall(idx).Back_color = col
        Find_Bal_Type(idx).Back_color = col
        Find_Applicap(idx).Back_color = col

        Find_Particuls_TXT(idx).BackColor = col
        Find_Bal_Vall(idx).BackColor = col
        Find_Bal_Type(idx).BackColor = col
        Find_Applicap(idx).BackColor = col
    End Sub
    Private Sub bg_panel_Leave(sender As Object, e As EventArgs)
        Dim col As Color = platform.BackColor
        sender.BackColor = col

        Dim idx As Integer = Find_Idx(sender)
        Find_Bal_Vall(idx).Back_color = col
        Find_Bal_Type(idx).Back_color = col
        Find_Applicap(idx).Back_color = col

        Find_Particuls_TXT(idx).BackColor = col
        Find_Bal_Vall(idx).BackColor = col
        Find_Bal_Type(idx).BackColor = col
        Find_Applicap(idx).BackColor = col
    End Sub
    Public Function Find_Idx(sender As Object) As Integer
        Try
            Return sender.Name.Split("_")(1)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Branch_ID(index As Integer) As Label
        Try
            Return CType(platform.Controls.Find(("BranchID_" & index), True).First, Label)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Particuls_TXT(index As Integer) As Label
        Try
            Return CType(platform.Controls.Find(("Particulstxt_" & index), True).First, Label)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Applicap(index As Integer) As YN
        Try
            Return CType(platform.Controls.Find(("Applicable_" & index), True).First, YN)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Bal_Vall(index As Integer) As TXT
        Try
            Return CType(platform.Controls.Find(("balval_" & index), True).First, TXT)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Bal_Type(index As Integer) As TXT
        Try
            Return CType(platform.Controls.Find(("baltype_" & index), True).First, TXT)
        Catch ex As Exception

        End Try
    End Function

    Public Function Find_Particuls_Panel(index As Integer) As Panel
        Try
            Return CType(platform.Controls.Find(("Particulspanel_" & index), True).First, Panel)
        Catch ex As Exception

        End Try
    End Function

    Private Sub platform_Paint(sender As Object, e As PaintEventArgs) Handles platform.Paint

    End Sub

    Private Sub Ledger_LAB_Click(sender As Object, e As EventArgs) Handles Ledger_LAB.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub bg_Panel_Paint(sender As Object, e As PaintEventArgs) Handles bg_Panel.Paint

    End Sub

    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs) Handles Panel5.Paint

    End Sub

    Private Sub Panel6_Paint(sender As Object, e As PaintEventArgs) Handles Panel6.Paint

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Panel7_Paint(sender As Object, e As PaintEventArgs) Handles Panel7.Paint

    End Sub

    Private Sub Panel8_Paint(sender As Object, e As PaintEventArgs) Handles Panel8.Paint

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class
