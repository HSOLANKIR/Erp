Public Class Whatsapp_list_menu_diaload
    Private Sub Whatsapp_list_menu_diaload_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles Label14.Click
        Dim ctrl As New whatsapp_list_menu_ctrl
        List_Panel.Controls.Add(ctrl)
        ctrl.Dock = DockStyle.Top
        ctrl.Txt1.Focus()
        ctrl.BringToFront()
    End Sub
End Class