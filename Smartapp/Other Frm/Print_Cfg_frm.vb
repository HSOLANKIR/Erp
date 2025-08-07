Imports System.Data.SQLite
Public Class Print_Cfg_frm
    Public Dt As DataTable
    Private Sub Configure_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub
    Public Function Load_()
        Dt = New DataTable
        Dt.Columns.Add("Head")
        Dt.Columns.Add("Value")
        Dt.Columns.Add("Type")

        Dt.Rows.Add("Printer Name", Primary_Printer, "Select")
        Dt.Rows.Add("Copy", "1", "Num")

        BindingSource1.DataSource = Dt

        Grid1.DataSource = BindingSource1

        With Grid1
            .Columns(0).Width = 200
            .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns(1).DefaultCellStyle.Padding = New Padding(10, 0, 0, 0)
            .Columns(2).Visible = False
        End With
    End Function
    Public Function Save_()
        For Each ro As DataGridViewRow In Grid1.Rows
            Try
                Dim obj As Object = (ro.Cells(3).Value)
                obj = (ro.Cells(3).Value)
            Catch ex As Exception

            End Try
        Next
    End Function

    Private Sub Print_Cfg_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Save_()
            Me.Dispose()
        End If
    End Sub

    Private Sub Grid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid1.CellContentClick

    End Sub

    Private Sub Grid1_Enter(sender As Object, e As EventArgs) Handles Grid1.Enter
        Search_TXT.Focus()
    End Sub

    Private Sub Search_TXT_TextChanged(sender As Object, e As EventArgs) Handles Search_TXT.TextChanged

    End Sub

    Private Sub Search_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles Search_TXT.KeyDown
        If e.KeyCode = Keys.Up Then
            BindingSource1.MovePrevious()
        End If
        If e.KeyCode = Keys.Down Then
            BindingSource1.MoveNext()
        End If
        If e.KeyCode = Keys.Enter Then
            With Grid1.CurrentRow
                If .Cells(2).Value = "YN" Then
                    If .Cells(1).Value = "Yes" Then
                        .Cells(1).Value = "No"
                    Else
                        .Cells(1).Value = "Yes"
                    End If
                End If
            End With
        End If
    End Sub
End Class