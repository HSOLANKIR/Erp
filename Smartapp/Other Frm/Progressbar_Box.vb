Imports System.ComponentModel

Public Class Progressbar_Box
    Public BackW As BackgroundWorker
    Private Sub Progressbar_Box_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler BackW.RunWorkerCompleted, AddressOf BackgroundWorker1_RunWorkerCompleted
        AddHandler BackW.Disposed, AddressOf BackgroundWorker1_Disposed
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        obj_center(sender, Me)
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs)
        Me.Dispose()
    End Sub
    Private Sub BackgroundWorker1_Disposed(sender As Object, e As EventArgs) Handles BackgroundWorker1.Disposed
        Me.Dispose()
    End Sub
End Class