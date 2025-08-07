Imports System.Data.SQLite

Public Class Voucher_Type_select_ctrl
    Public frm_ As Object
    Private Sub Voucher_Type_List_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Fill_Data()
        Grid_.DataSource = BindingSource1
        Grid_.Columns(0).Visible = False
        Grid_.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Txt1.Text = Dft_Voucher
        BindingSource1.Filter = Nothing
    End Sub
    Private Function Fill_Data()
        Dim dt As New DataTable
        Dim dr As DataRow

        dt.Clear()
        dt.Columns.Add("ID")
        dt.Columns.Add("Name")

        dt.Rows.Clear()
        dt.Rows.Add("All Vouchers", "All Vouchers")
        dt.Rows.Add("Attendance", "Attendance")
        dt.Rows.Add("Contra", "Contra")
        dt.Rows.Add("Credit Note", "Credit Note")
        dt.Rows.Add("Debit Note", "Debit Note")
        dt.Rows.Add("Journal", "Journal")
        dt.Rows.Add("Payment", "Payment")
        dt.Rows.Add("Payroll", "Payroll")
        dt.Rows.Add("Purchase", "Purchase")
        dt.Rows.Add("Purchase Order", "Purchase Oredr")
        dt.Rows.Add("Receipt", "Receipt")
        dt.Rows.Add("Sales", "Sales")
        dt.Rows.Add("Sales Order", "Sales Order")
        dt.Rows.Add("Outward Register", "Outward Register")
        dt.Rows.Add("Inward Register", "Inward Register")
        dt.Rows.Add("Stock Journal", "Stock Journal")


        BindingSource1.DataSource = dt
    End Function
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
            Dft_Voucher = Grid_.CurrentRow.Cells(1).Value
            frm_.Filter_Apply()
            Me.Dispose()
        End If
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub Grid__CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid_.CellContentClick

    End Sub

    Private Sub Grid__Enter(sender As Object, e As EventArgs) Handles Grid_.Enter
        Txt1.Focus()
    End Sub

    Private Sub Txt1_Disposed(sender As Object, e As EventArgs) Handles Txt1.Disposed

    End Sub
End Class
