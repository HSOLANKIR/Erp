Public Class WhatsApp_Button_Option_ctrl
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "Reply" Then
            Label1.Visible = False
            Txt2.Visible = False
        ElseIf ComboBox1.Text = "Call" Then
            Label1.Text = "Phone Number"
            Label1.Visible = True
            Txt2.Visible = True
        ElseIf ComboBox1.Text = "Url" Then
            Label1.Text = "Url"
            Label1.Visible = True
            Txt2.Visible = True
        ElseIf ComboBox1.Text = "Copy" Then
            Label1.Text = "Copy Text"
            Label1.Visible = True
            Txt2.Visible = True
        End If
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Me.Dispose()
    End Sub
End Class
