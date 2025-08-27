Imports System.ComponentModel
Imports Tools

Public Class Create_Batch_Dialoag
    Public Batch_ As TXT
    Public Exp_ As TXT
    Public Mfg_ As TXT
    Private Sub Create_Batch_Dialoag_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Txt1.Text = Batch_.Text
        Txt2.Text = Exp_.Text
        Txt3.Text = Mfg_.Text

    End Sub
    Dim Result As DialogResult = DialogResult.No
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Batch_.Text = Txt1.Text
        Exp_.Text = Txt2.Text
        Mfg_.Text = Txt3.Text


        Result = DialogResult.Yes
        Me.Close()
    End Sub

    Private Sub Txt2_TextChanged(sender As Object, e As EventArgs) Handles Txt2.TextChanged

    End Sub

    Private Sub Txt2_LostFocus(sender As Object, e As EventArgs) Handles Txt2.LostFocus, Txt3.LostFocus
        sender.Text = Date_Formate(sender.Text)
    End Sub

    Private Sub Create_Batch_Dialoag_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Me.DialogResult = Result
    End Sub
End Class