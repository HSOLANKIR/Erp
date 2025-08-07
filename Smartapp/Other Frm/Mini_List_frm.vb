Public Class Mini_List_frm
    Dim loca As Point
    Private Sub Mini_List_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Function list_MANU(Head As String, Source As BindingSource, Frist_Colum As Integer, Last_Colum As Integer, Location As Point)
        'Me.Visible = False
        Grid.DataSource = Nothing
        Grid.DataSource = Source

        For i As Integer = 0 To Grid.Columns.Count
            Try
                Grid.Columns(i).Visible = False
                Grid.Columns(i).Width = 0

            Catch ex As Exception
                Exit Try
            End Try
        Next

        Grid.Columns(Frist_Colum).Visible = True
        Grid.Columns(Last_Colum).Visible = True

        Grid.Columns(Frist_Colum).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Grid.Columns(Frist_Colum).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        Grid.Columns(Frist_Colum).DefaultCellStyle.Font = New Font("Microsoft YaHei", 9, FontStyle.Regular)

        Grid.Columns(Last_Colum).Width = 110
        Grid.Columns(Last_Colum).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Grid.Columns(Last_Colum).DefaultCellStyle.Font = New Font("Microsoft YaHei", 9, FontStyle.Italic)

        List_Head_TXT.Text = Head
        Me.BringToFront()
        Me.Location = Location
        Me.Show()
    End Function

    Private Sub Grid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid.CellContentClick

    End Sub

    Private Sub Grid_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.Dispose()
        End If
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        For i As Integer = 0 To Grid.Rows.Count - 1
            Grid.Rows(i).Height = 18
        Next
    End Sub

    Private Sub Grid_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles Grid.RowsAdded
        Dim ro As Integer = (Grid.Rows.Count) * 19
        Me.Height = ro + Val(List_Head_TXT.Height)
    End Sub
End Class