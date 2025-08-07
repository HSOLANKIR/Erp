Public Class Features_Manu_ctrl
    Public Property Head_ As String = ""
    Public Property Shortcut_ As Keys
    Public Property Img_ As Image = Nothing
    Public Property Object_ As Object = Nothing
    Private Sub Features_Manu_ctrl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Head.Text = Head_
        Shortcut.Text = Shortcut_.ToString.Replace("None", "")
        img.Image = Img_
    End Sub
    Public Function CLick_()
        Dim all_ = GetAllControls(cmp_cfg_bg_frm.Panel15).OfType(Of Features_Manu_ctrl)().ToList()

        all_.FindAll(Function(i)
                         i.BackColor = Color.Bisque
                         i.Panel1.BackColor = Color.Bisque
                         i.Font = New Font("Arial", 10, FontStyle.Regular)
                     End Function)

        Me.BackColor = Color.NavajoWhite
        Me.Panel1.BackColor = Color.Peru
        Me.Font = New Font("Arial", 9.75, FontStyle.Bold)

        With cmp_cfg_bg_frm
            .Set_ctrl(Object_)
            .Label1.Text = Head_
        End With
    End Function

    Private Sub Img_Click(sender As Object, e As EventArgs) Handles img.Click, TableLayoutPanel1.Click, Head.Click, Shortcut.Click, Panel1.Click
        CLick_()
    End Sub

    Private Sub img_Click_1(sender As Object, e As EventArgs) Handles img.Click

    End Sub
End Class
