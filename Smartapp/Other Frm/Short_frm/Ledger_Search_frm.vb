Imports System.Data.SqlClient
Imports System.Data.SQLite

Public Class Ledger_Search_frm
    Public Filter As String
    Public Name As TextBox
    Private Sub Ledger_Search_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FIll_()
        Txt1.Text = Name.Text
        Txt1.Focus()
    End Sub

    Private Sub Txt1_TextChanged(sender As Object, e As EventArgs) Handles Txt1.TextChanged
        BindingSource1.Filter = "ID LIKE'" & Txt1.Text & "%' or " & $"(Name LIKE '%{Txt1.Text.Trim}%') or " & $"(Alias LIKE '%{Txt1.Text.Trim}%') or " & $"(Phone LIKE '%{Txt1.Text.Trim}%') or " & $"(Email LIKE '%{Txt1.Text.Trim}%') or " & $"(Address LIKE '%{Txt1.Text.Trim}%') or " & $"(GSTNo LIKE '%{Txt1.Text.Trim}%') or " & $"(PAN LIKE '%{Txt1.Text.Trim}%')"
    End Sub

    Private Sub Txt1_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt1.KeyDown
        If e.KeyCode = Keys.Up Then
            BindingSource1.MovePrevious()
        End If
        If e.KeyCode = Keys.Down Then
            BindingSource1.MoveNext()
        End If
        If e.KeyCode = Keys.Enter Then
            Click_()
        End If
    End Sub

    Private Sub Ledger_Search_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        Txt1.Focus()
    End Sub

    Private Function Click_()
        Name.Text = DataGridView1.CurrentRow.Cells(1).Value
        Me.Dispose()
        Name.Focus()
    End Function
    Private Function FIll_()
        Dim Dt As New DataTable
        Dim dr As DataRow
        Dt.Columns.Add("ID")
        Dt.Columns.Add("Name")
        Dt.Columns.Add("Alias")
        Dt.Columns.Add("Group")
        Dt.Columns.Add("Phone")
        Dt.Columns.Add("Email")
        Dt.Columns.Add("Address")
        Dt.Columns.Add("GSTNo")
        Dt.Columns.Add("PAN")
        Dim cn As New SQLiteConnection
        Dim r As SQLiteDataReader
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            If Filter <> Nothing Then
                Filter = " and " & Filter
            End If

            cmd = New SQLiteCommand("Select * From TBL_Ledger where " & Company_Visible_Filter & Filter, cn)
            r = cmd.ExecuteReader
            While r.Read
                dr = Dt.NewRow
                dr("ID") = r("ID")
                dr("Name") = r("Name")
                dr("Alias") = r("Alise")
                dr("Group") = r("Group")
                dr("Phone") = r("Phone")
                dr("Email") = r("Email")
                dr("Address") = r("Address")
                dr("GSTNo") = r("GSTNo")
                dr("PAN") = r("PANCardNo")
                Dt.Rows.Add(dr)
            End While
        End If
        BindingSource1.DataSource = Dt
        DataGridView1.DataSource = BindingSource1

        DataGridView1.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DataGridView1.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DataGridView1.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DataGridView1.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DataGridView1.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DataGridView1.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DataGridView1.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DataGridView1.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DataGridView1.Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
    End Function

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_EditModeChanged(sender As Object, e As EventArgs) Handles DataGridView1.EditModeChanged

    End Sub

    Private Sub DataGridView1_Enter(sender As Object, e As EventArgs) Handles DataGridView1.Enter
        Txt1.Focus()
    End Sub
End Class