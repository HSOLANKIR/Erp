Imports System.ComponentModel

Public Class Whatsapp_Tabale_Diaload
    Private Sub Whatsapp_Tabale_Diaload_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Grid1.Rows.Clear()

        For Each s As String In Whatsapp_Home.Excel_Column
            Grid1.Rows.Add(s)
        Next
    End Sub

    Private Sub Whatsapp_Tabale_Diaload_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Me.Dispose()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        With Whatsapp_Home
            .Excel_Column.Clear()
            For Each ro As DataGridViewRow In Grid1.Rows
                If ro.Cells(0).Value <> Nothing Then
                    .Excel_Column.Add(ro.Cells(0).Value)
                End If
            Next
            .Colunm_Set()
        End With
        Me.Dispose()
    End Sub
End Class