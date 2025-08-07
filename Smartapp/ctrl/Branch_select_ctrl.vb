Imports System.Data.SQLite

Public Class Branch_select_ctrl
    Public frm_ As Object
    Private Sub Voucher_Type_List_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Fill_Data()
        Grid_.DataSource = BindingSource1
        Grid_.Columns(0).Visible = False
        Grid_.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Txt1.Text = Dft_Branch
        BindingSource1.Filter = Nothing
    End Sub
    Private Function Fill_Data()
        Dim cn As New SQLiteConnection

        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            Dim dt As New DataTable
            Dim dr As DataRow

            dt.Clear()
            dt.Columns.Add("ID")
            dt.Columns.Add("Name")
            dt.Columns.Add(" ")

            dt.Rows.Add("0", "Primary")

            cmd = New SQLiteCommand("Select * From TBL_Ledger WHERE Visible = 'Approval' and [Group] = '7'", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                dr = dt.NewRow
                dr("ID") = r("ID")
                dr("Name") = r("Name")
                dr(" ") = " "
                dt.Rows.Add(dr)
            End While
            r.Close()

            BindingSource1.DataSource = dt
        End If
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
            Dft_Branch = Grid_.CurrentRow.Cells(1).Value
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
End Class
