Public Class Valuation_select_ctrl
    Public frm_ As Object
    Private Sub Voucher_Type_List_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dt As New DataTable
        dt.Columns.Add("Name")

        dt.Rows.Add("At Zero Price")
        dt.Rows.Add("Avg. Price")
        dt.Rows.Add("Last Sales Price")
        dt.Rows.Add("Std. Price")


        BindingSource1.DataSource = dt
        Grid_.DataSource = BindingSource1
        Grid_.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Txt1.Text = Dft_Valuation
        BindingSource1.Filter = Nothing
        Select_Currant(Txt1.Text)
    End Sub

    Private Sub Txt1_TextChanged(sender As Object, e As EventArgs) Handles Txt1.TextChanged
        BindingSource1.Filter = $"(Name Like '%{Txt1.Text.ToString.Trim}%')"
    End Sub

    Private Sub Txt1_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt1.KeyDown
        If e.KeyCode = Keys.Up Then
            BindingSource1.MovePrevious()
        End If
        If e.KeyCode = Keys.Down Then
            BindingSource1.MoveNext()
        End If
        If e.KeyCode = Keys.Enter Then
            Dft_Valuation = Grid_.CurrentRow.Cells(0).Value
            frm_.Filter_Apply()
            Me.Dispose()
        End If
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub
    Private Sub Grid__Enter(sender As Object, e As EventArgs) Handles Grid_.Enter
        Txt1.Focus()
    End Sub

    Public Function Select_Currant(TXT As String)
        Try
            For i As Integer = 0 To Grid_.Rows.Count - 1
                Dim ro As DataGridViewRow = Grid_.Rows(i)
                If ro.Cells(1).Value = TXT Then
                    Grid_.CurrentCell = Grid_.Rows(i).Cells(0)
                    Exit For
                End If
            Next
        Catch ex As Exception

        End Try
    End Function
End Class
