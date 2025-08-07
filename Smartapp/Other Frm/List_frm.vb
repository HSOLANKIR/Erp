Imports Tools

Public Class List_frm
    Public Source As BindingSource
    Public TX As TXT
    Public Direct_Create_Datatable As DataTable
    Public Direct_Create As Boolean = False
    Public Direct_Create_row_idx As Integer
    Public Direct_Create_col_idx As Integer
    Public System_Data_integer As Integer = 0
    Private Sub List_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler TX.Enter, AddressOf TX_Enter_TXT
        AddHandler TX.TextChanged, AddressOf TX_Change_TXT
        AddHandler TX.KeyDown, AddressOf TX_Keydown_TXT


    End Sub
    Private Sub TX_Keydown_TXT(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Up Then
            Source.MovePrevious()
        End If
        If e.KeyCode = Keys.Down Then
            Source.MoveNext()
        End If
        If e.KeyCode = Keys.PageUp Then
            Source.MoveFirst()
        End If
        If e.KeyCode = Keys.PageDown Then
            Source.MoveLast()
        End If
    End Sub
    Private Function Direct_Alter_Function(Enter_ As Boolean)
        If Direct_Create = True Then
            If List_Grid.Rows.Count - 1 = Direct_Create_row_idx Or Enter_ = True Then
                List_Grid.Rows(Direct_Create_row_idx).Cells(Direct_Create_col_idx).Value = TX.Text
                Direct_Create_Datatable.Rows(Direct_Create_row_idx)(Direct_Create_col_idx) = TX.Text
            End If
        End If
    End Function
    Private Sub TX_Enter_TXT(sender As Object, e As EventArgs)
        Direct_Alter_Function(False)
    End Sub
    Private Sub TX_Change_TXT(sender As Object, e As EventArgs)

        If TX.Select_Filter.Trim <> Nothing Then
            If Me.Visible = True Then
                Source.Filter = TX.Select_Filter.Replace("<value>", TX.Text.ToString.Trim)
                Me.Size_()
                If List_Grid.Rows.Count = 0 Then
                    SendKeys.Send("{BACKSPACE}")
                    Msg_InputError(TX, List_Head_TXT.Text)
                End If
            End If
        End If

        Direct_Alter_Function(False)

    End Sub
    Private Sub Grid1_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles List_Grid.RowsAdded, Paramert_grid.RowsAdded
        sender.Rows(sender.Rows.Count - 1).Height = 18

        Paramert_grid.Height = Val(Paramert_grid.Rows.Count) * 18

        If Paramert_grid.Rows.Count = 0 Then
            Panel4.Hide()
        Else
            Panel4.Show()
        End If
    End Sub
    Private Sub List_frm_MouseWheel(sender As Object, e As MouseEventArgs) Handles Me.MouseWheel
        If e.Delta < 1 Then
            Source.MoveNext()
        Else
            Source.MovePrevious()
        End If
    End Sub
    Dim color_colunm As Integer
    Public Function Set_COlor(col As Integer)
        Dim column As DataGridViewColumn = List_Grid.Columns(col)
        color_colunm = col

        AddHandler List_Grid.CellPainting, AddressOf List_Grid_CellPainting
    End Function
    Private Sub List_Grid_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles List_Grid.RowPrePaint
        Dim ro As DataGridViewRow = List_Grid.Rows(e.RowIndex)
    End Sub

    Private Sub List_frm_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        Style_()
        Size_()
        If Me.Visible = True Then
            If TX.Select_Filter.Trim <> Nothing Then
                Source.Filter = Nothing
            End If

            Try
                If List_Grid.Rows.Count >= System_Data_integer Then
                    List_Grid.CurrentCell = List_Grid.Rows(System_Data_integer).Cells(TX.Select_Columns)
                End If
            Catch ex As Exception

            End Try

            For Each ro As DataGridViewRow In List_Grid.Rows
                If TX.Text.ToString <> Nothing Then
                    If ro.Cells(TX.Select_Columns).Value.ToString.StartsWith(TX.Text) Then
                        List_Grid.CurrentCell = ro.Cells(TX.Select_Columns)
                        Exit For
                    End If
                End If
            Next


            Direct_Alter_Function(True)

        End If
    End Sub
    Public Type_ As Integer
    Public Function Size_()
        With Me
            If Type_ <> 2 Then
                Dim colunm_H As Integer
                If List_Grid.ColumnHeadersVisible = True Then
                    colunm_H = List_Grid.ColumnHeadersHeight
                End If

                '.Height = h.Y

                Dim auto_H As Integer = (.List_Grid.Rows.Count * 18) + (.Paramert_grid.Height) + (.List_Head_TXT.Height) + colunm_H + .Panel3.Height + 5

                Dim point_H As Integer = BG_frm.BG_PAN.Height - (Me.PointToScreen(New Point(0, 0)).Y) + (BG_frm.BG_PAN.PointToScreen(New Point(0, 0)).Y)

                If auto_H > point_H Then
                    .Height = point_H
                Else
                    .Height = auto_H
                End If

            End If
        End With
    End Function
    Public Function Style_()
        With Me
            Dim ctlpos As Point = TX.PointToScreen(New Point(0, 0))
            Dim main_frm As Point = BG_frm.BG_PAN.PointToScreen(New Point(0, 0))

            .StartPosition = FormStartPosition.Manual
            If Type_ = 0 Then
                .Location = New Point(ctlpos.X, ctlpos.Y + TX.Height + 2)
            ElseIf Type_ = 1 Then
                .Location = New Point(ctlpos.X + TX.Width + 2, ctlpos.Y)
            ElseIf Type_ = 2 Then
                .Location = New Point(BG_frm.BG_PAN.Width - .Width, main_frm.Y)
                .Height = BG_frm.BG_PAN.Height
            ElseIf Type_ = 3 Then
                Dim w As Point = New Point((BG_frm.BG_PAN.Width - Me.Width) \ 2, 0)
                .Location = New Point(w.X, ctlpos.Y + TX.Height + 2)
            End If
        End With
    End Function
    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim ret As CreateParams = MyBase.CreateParams
            ret.Style = CInt(&H40000000)
            Return ret
        End Get
    End Property

    Private Sub List_Grid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles List_Grid.CellContentClick

    End Sub

    Private Sub List_Grid_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs)
        Dim col As DataGridViewCell = List_Grid.Rows(e.RowIndex).Cells(color_colunm)


        Dim color As Color = Color.FromName(col.Value.ToString)
        List_Grid.Rows(e.RowIndex).DefaultCellStyle.ForeColor = color



    End Sub

    Private Sub Paramert_grid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub List_Grid_DoubleClick(sender As Object, e As EventArgs) Handles List_Grid.DoubleClick
        SendKeys.Send("{Enter}")
    End Sub
End Class