Public Class Head_Manu_ctrl
    Public Property Head As String = ""
    Public Property admin_diaload As Boolean = False
    Public Property Back_Focus As TextBox
    Public Property Back_Ctrl As Manu_ctrl
    Private Sub Head_Manu_ctrl_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Function Add_Group(Head As String)
        Dim idx As Integer = bg_Panel.Controls.Count + 0
        Dim bg_p As New Panel
        Dim Head_Lab As New Label

        bg_p.Controls.Add(Head_Lab)
        bg_p.Dock = DockStyle.Top
        bg_p.Size = New Size(250, 78)
        bg_p.Name = $"Group_{idx}"
        bg_p.Padding = New Padding(0, 0, 0, 5)
        bg_p.AutoSize = True

        Head_Lab.Dock = DockStyle.Top
        Head_Lab.Font = New Font("Arial", 9.0!, CType((FontStyle.Bold Or FontStyle.Italic), FontStyle), GraphicsUnit.Point, CType(0, Byte))
        Head_Lab.ForeColor = Color.SaddleBrown
        Head_Lab.Location = New Point(0, 0)
        Head_Lab.Name = $"Head_{idx}"
        Head_Lab.Padding = New Padding(5, 0, 0, 0)
        Head_Lab.Size = New Size(250, 18)
        Head_Lab.TabIndex = 0
        Head_Lab.Text = Head
        Head_Lab.TextAlign = ContentAlignment.MiddleLeft

        bg_Panel.Controls.Add(bg_p)
        bg_p.BringToFront()

    End Function
    Public Function Add_Item(link As String, Enable As Boolean, high As Integer) As String()
        Dim head As Panel = Find_Group_Panel(bg_Panel.Controls.Count - 1)
        Dim idx As String = Find_Idx(head) & "_" & head.Controls.Count + 1

        Dim bg_p As New Panel
        Dim Head_Lab As New Label
        Dim tx As New TextBox
        Dim lnk As New Label

        bg_p.AutoSize = False
        bg_p.Controls.Add(Head_Lab)
        bg_p.Controls.Add(tx)
        bg_p.Controls.Add(lnk)
        bg_p.Dock = DockStyle.Top
        bg_p.Location = New Point(0, 19)
        bg_p.Name = "particuls_" & idx
        bg_p.Size = New Size(250, high)
        bg_p.TabIndex = idx.Split("_").Last
        bg_p.Enabled = Enable

        AddHandler bg_p.Enter, AddressOf bg_panel_Enter
        AddHandler bg_p.Leave, AddressOf bg_panel_Leave


        With Head_Lab
            .Dock = DockStyle.Top
            .Font = New Font("Arial", 9.75!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
            .ForeColor = Color.Black
            .Location = New Point(0, 0)
            .Name = "ParticulsLab_" & idx
            .Padding = New Padding(20, 0, 0, 0)
            .Size = New Size(100, 15)
            .TabIndex = 1
            .Text = $"{link.Split(",")(0)}"
            .TextAlign = ContentAlignment.MiddleLeft
            .AutoSize = False
            .UseMnemonic = False
            .Cursor = Cursors.Hand
            AddHandler .Click, AddressOf Head_Lab_lick
        End With

        With tx
            .Location = New Point(0, 0)
            .Font = New Font("Arial", 5, FontStyle.Regular)
            .Size = New Size(0, 0)
            .Name = "tx_" & idx

            AddHandler tx.Click, AddressOf Label82_Click
            AddHandler tx.KeyPress, AddressOf panel_ctrl_KeyPress
            AddHandler tx.KeyDown, AddressOf panel_ctrl_KeyDown
        End With


        head.Controls.Add(bg_p)
        bg_p.BringToFront()

        Return {Find_Idx(head), head.Controls.Count + 0}
    End Function
    Private Sub bg_panel_Enter(sender As Object, e As EventArgs)
        Dim col As Color = Color.FromArgb(254, 197, 48)
        'sender.BackColor = col
        Dim idx As Integer = Find_Idx(sender)
        Dim idx1 As Integer = Find_Idx2(sender)


        Find_Particuls(idx, idx1).BackColor = col
    End Sub
    Private Sub bg_panel_Leave(sender As Object, e As EventArgs)
        Dim col As Color = bg_Panel.BackColor
        sender.BackColor = col

        Dim idx As Integer = Find_Idx(sender)
        Dim idx1 As Integer = Find_Idx2(sender)

        Find_Particuls(idx, idx1).BackColor = col

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
    Public Function Find_Group_Panel(index As Integer) As Panel
        Try
            Return CType(bg_Panel.Controls.Find(("Group_" & index), True).First, Panel)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Particuls(idx1 As Integer, idx2 As Integer) As Label
        Try
            Return CType(bg_Panel.Controls.Find(($"ParticulsLab_{idx1}_{idx2}"), True).First, Label)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Sortcus(idx1 As Integer, idx2 As Integer) As Label
        Try
            Return CType(bg_Panel.Controls.Find(($"sortcut_{idx1}_{idx2}"), True).First, Label)
        Catch ex As Exception

        End Try
    End Function

    Public Function Find_txt(idx1 As Integer, idx2 As Integer) As TextBox
        Try
            Return CType(bg_Panel.Controls.Find(($"tx_{idx1}_{idx2}"), True).First, TextBox)
        Catch ex As Exception

        End Try
    End Function

    Private Sub panel_ctrl_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim P_ As New Queue(Of Panel)()
        For Each bg_p As Panel In bg_Panel.Controls.OfType(Of Panel)()
            For Each bg_p1 As Panel In bg_p.Controls.OfType(Of Panel)()
                P_.Enqueue(bg_p1)
            Next
        Next

        For Each bg_p As Panel In P_.Reverse
            Dim idx1 As Integer = Find_Idx(bg_p)
            Dim idx2 As Integer = Find_Idx2(bg_p)

            'If Find_Sortcus(idx1, idx2).Text.ToUpper = e.KeyChar.ToString.ToUpper Then
            '    Find_txt(idx1, idx2).Focus()
            '    SendKeys.Send("{Enter}")
            '    Exit For
            'End If
        Next
    End Sub
    Private Sub panel_ctrl_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Dim idx1 As Integer = Find_Idx(sender)
            Dim idx2 As Integer = Find_Idx2(sender)


        End If
        If e.KeyCode = Keys.Up Then
            SendKeys.Send("+{TAB}")
        End If
        If e.KeyCode = Keys.Down Then
            SendKeys.Send("{TAB}")
        End If
        If e.KeyCode = Keys.Escape Then
            'Me.Dispose()
        End If
    End Sub

    Private Sub Manu_ctrl_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        'Me.AutoSize = True
    End Sub

    Private Sub Manu_ctrl_Leave(sender As Object, e As EventArgs) Handles Me.Leave
        'Me.AutoSize = False
        'Me.Size = New Size(0, 0)
    End Sub

    Private Sub Manu_ctrl_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        If IsNothing(Back_Focus) Then
        Else
            Back_Ctrl.Show()
            Back_Focus.Focus()
        End If

        If admin_diaload = True Then

        End If

    End Sub

    Private Sub Manu_ctrl_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint

    End Sub

    Public Sub Head_Lab_lick(sender As Object, e As EventArgs)
        Dim idx1 As Integer = Find_Idx(sender)
        Dim idx2 As Integer = Find_Idx2(sender)

        Find_txt(idx1, idx2).Focus()
        SendKeys.Send("{Enter}")

    End Sub
    Private Sub Label82_Click(sender As Object, e As EventArgs)
        Dim idx1 As Integer = Find_Idx(sender)
        Dim idx2 As Integer = Find_Idx2(sender)

        Find_txt(idx1, idx2).Focus()
        SendKeys.Send("{Enter}")
    End Sub
End Class
