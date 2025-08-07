Public Class WhatsApp_List_Section_ctrl
    Public Property Obj As Whatsapp_list_menu_diaload
    Private Sub WhatsApp_List_Section_ctrl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim frm As New Whatsapp_list_menu_diaload
        Obj = frm
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Obj.Label1.Text = Txt1.Text
        Obj.ShowDialog()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Me.Dispose()
    End Sub
End Class
