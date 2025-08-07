Public Class Other_details_Fill_frm
    Dim List_Fing_Bs As BindingSource
    Public sou_bs As BindingSource
    Dim Path_End As String
    Private Sub Other_details_Fill_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Grid_.Focus()
        SendKeys.Send("{Right}")

        Path_End = BG_frm.BG_Path_TXT.Text
        BG_frm.BG_Path_TXT.Text &= "->" & "More Details"
    End Sub

    Private Sub Other_details_Fill_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Throw_Data()
            Me.Dispose()
            Frm_foCus()
        End If
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        For i As Integer = 0 To Grid_.Rows.Count - 1
            Dim Rows As DataGridViewRow = Grid_.Rows(i)
            If Rows.Cells(7).Value.ToString = "Head" Then
                Grid_.Rows(i).DefaultCellStyle.Font = New Font("Microsoft YaHei", 9, FontStyle.Bold)
                Grid_.Rows(i).ReadOnly = True
            Else
                Grid_.Rows(i).Cells(1).Style.Padding = New Padding(10, 0, 0, 0)
            End If
        Next

        Try
            Grid_.Columns(0).Visible = False
            Grid_.Columns(3).Visible = False
            Grid_.Columns(4).Visible = False
            Grid_.Columns(5).Visible = False
            Grid_.Columns(6).Visible = False
            Grid_.Columns(7).Visible = False

            Grid_.Columns(0).ReadOnly = True
            Grid_.Columns(1).ReadOnly = True
            Grid_.Columns(3).ReadOnly = True
            Grid_.Columns(4).ReadOnly = True
            Grid_.Columns(5).ReadOnly = True
            Grid_.Columns(6).ReadOnly = True
            Grid_.Columns(7).ReadOnly = True

            Grid_.Columns(1).Visible = True
            Grid_.Columns(1).Width = 300
            Grid_.Columns(2).Visible = True
            Grid_.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            Grid_.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            For i As Integer = 0 To Grid_.Rows.Count - 1
                Grid_.Rows(i).Height = 20
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid_.CellContentClick

    End Sub

    Private Sub DataGridView2_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grid_.CellEnter
        List_frm.Dispose()
        If e.ColumnIndex = 1 Then
            SendKeys.Send("{Right}")
        End If
        If e.ColumnIndex = 1 Or e.ColumnIndex = 2 Then
            If Grid_.CurrentRow.Cells(4).Value.ToString = "select" Then
                Dim result As String() = Grid_.CurrentRow.Cells(5).Value.ToString.Split(New String() {"/"}, StringSplitOptions.None)

                List_Fing_Bs = bIndingsource_fInd(result(1))

            End If
        End If
    End Sub

    Private Sub DataGridView2_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid_.KeyDown
        If e.KeyCode = Keys.Up Then
            If Grid_.CurrentRow.Cells(4).Value = "select" Then
                List_Fing_Bs.MovePrevious()
                e.Handled = True
            End If
        End If
        If e.KeyCode = Keys.Down Then
            If Grid_.CurrentRow.Cells(4).Value = "select" Then
                List_Fing_Bs.MoveNext()
                e.Handled = True
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            If Grid_.CurrentRow.Cells(4).Value = "select" Then
                Grid_.CurrentRow.Cells(2).Value = List_frm.List_Grid.CurrentRow.Cells(1).Value.ToString
                Grid_.CurrentRow.Cells(3).Value = List_frm.List_Grid.CurrentRow.Cells(0).Value.ToString
                e.Handled = False
            End If
        End If
    End Sub

    Private Function Throw_Data()
        Dim dt As New DataTable
        Dim dr As DataRow

        dt.Clear()
        dt.Columns.Clear()
        'dt.Columns.Add("ID")
        'dt.Columns.Add("Name")
        'dt.Columns.Add("Value")
        'dt.Columns.Add("Value_ID")
        'dt.Columns.Add("Type")
        'dt.Columns.Add("List_Link")
        'dt.Columns.Add("Null_allow")
        'dt.Columns.Add("Head")
        For i As Integer = 0 To Grid_.Columns.Count - 1
            dt.Columns.Add(Grid_.Columns(i).HeaderText)
        Next

        For r As Integer = 0 To Grid_.Rows.Count - 1
            Dim row As DataGridViewRow = Grid_.Rows(r)
            dr = dt.NewRow
            For c As Integer = 0 To Grid_.Columns.Count - 1
                Dim cell As DataGridViewColumn = Grid_.Columns(c)
                dr(cell.HeaderText) = row.Cells(c).Value.ToString
            Next
            dt.Rows.Add(dr)
        Next
        sou_bs.DataSource = Nothing
        sou_bs.DataSource = dt
    End Function

    Private Sub Other_details_Fill_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End

    End Sub
End Class