Imports System.IO

Module Excel_mod
    Public Function Export_csv(Grid As DataGridView, Export_path As String) As Boolean


        Try
            'Dim Grid As DataGridView
            'Grid = New DataGridView
            'Grid.Columns.Clear()

            'Grid.DataSource = dt

            'MsgBox(Grid.Rows.Count)

            Dim csv As String = String.Empty

            For Each column As DataGridViewColumn In Grid.Columns
                csv += column.HeaderText & ","c
            Next

            csv += vbCr & vbLf

            For Each row As DataGridViewRow In Grid.Rows
                For Each cell As DataGridViewCell In row.Cells

                    Dim str As String = cell.Value.ToString().Replace(",", ";") & ","c
                    csv += cell.Value.ToString().Replace(",", ";") & ","c
                Next
                csv += vbCr & vbLf
            Next
            File.WriteAllText(Export_path, csv)

            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

    End Function
End Module
