Public Class Search_Manu_frm
    Private Sub Search_Manu_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_()
    End Sub

    Private Sub Search_Manu_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub
    Private Function Load_()
        List_Grid.DataSource = BindingSource1
        List_Grid.Columns(0).Visible = False
        List_Grid.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        List_Grid.Columns(2).Visible = False
        List_Grid.Columns(3).Visible = False
        List_Grid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        List_Grid.Columns(5).Visible = False
        List_Grid.Columns(6).Visible = False

        List_Grid.DataSource = BindingSource1

        BindingSource1.Filter = Defolt_Filter

    End Function
    Dim Defolt_Filter As String = "(Type = 'UNDER')"
    Private Sub List_Grid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles List_Grid.CellContentClick

    End Sub

    Private Sub List_Grid_Enter(sender As Object, e As EventArgs) Handles List_Grid.Enter
        Txt1.Focus()
    End Sub

    Private Sub Txt1_TextChanged(sender As Object, e As EventArgs) Handles Txt1.TextChanged
        BindingSource1.Filter = $"(Name LIKE '%{Txt1.Text.Trim}%') and " & Defolt_Filter
    End Sub

    Private Sub Txt1_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt1.KeyDown
        If e.KeyCode = Keys.Up Then
            BindingSource1.MovePrevious()
        End If
        If e.KeyCode = Keys.Down Then
            BindingSource1.MoveNext()
        End If
        If e.KeyCode = Keys.Enter Then
            Dim frm As String() = List_Grid.CurrentRow.Cells(3).Value.ToString.Split(New String() {">"}, StringSplitOptions.None)

            Cell(frm(0), List_Grid.CurrentRow.Cells(1).Value.ToString, List_Grid.CurrentRow.Cells(4).Value.ToString, List_Grid.CurrentRow.Cells(3).Value.ToString, List_Grid.CurrentRow.Cells(6).Value.ToString)

            Me.Dispose()

            Frm_foCus()
        End If
    End Sub

    Private Sub List_Grid_Paint(sender As Object, e As PaintEventArgs) Handles List_Grid.Paint

    End Sub

    Private Sub List_Grid_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles List_Grid.RowPrePaint
        Dim cel As DataGridViewCell = List_Grid.Rows(e.RowIndex).Cells(4)

        If cel.Value = "Create" Or cel.Value = "Display" Or cel.Value = "Alter" Then
        Else
            cel.Style.BackColor = Color.OldLace
            cel.Style.ForeColor = Color.OldLace
            cel.Style.SelectionForeColor = Color.FromArgb(254, 197, 48)
        End If
    End Sub

    Private Sub Search_Manu_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        Frm_foCus()
    End Sub
End Class