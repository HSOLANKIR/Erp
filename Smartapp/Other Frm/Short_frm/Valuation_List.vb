Public Class Valuation_List
    Public Return_String As String
    Private Sub Valuation_List_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dt As New DataTable
        dt.Columns.Add("Name")

        dt.Rows.Add("At Zero")
        dt.Rows.Add("Avg. Inward")
        dt.Rows.Add("Avg. Outward")
        dt.Rows.Add("Last Purchase")
        dt.Rows.Add("Last Sales")
        dt.Rows.Add("Standard Purchase")
        dt.Rows.Add("Standard Sales")

        BindingSource1.DataSource = dt
        Grid_.DataSource = BindingSource1

        Grid_.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub
    Private Sub Txt1_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt1.KeyDown
        If e.KeyCode = Keys.Up Then
            BindingSource1.MovePrevious()
        End If
        If e.KeyCode = Keys.Down Then
            BindingSource1.MoveNext()
        End If
        If e.KeyCode = Keys.Enter Then
            Me.DialogResult = DialogResult.Yes
            Me.Close()
            Return_String = Grid_.CurrentRow.Cells(0).Value
        End If
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = DialogResult.No
            Me.Dispose()
        End If
    End Sub
End Class