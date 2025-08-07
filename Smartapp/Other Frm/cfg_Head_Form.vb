Public Class cfg_Head_Form
    Dim From_ID As String
    Private Path_End As String
    Private VC_Type_ As String
    Private Sub cfg_Head_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text
        BG_frm.HADE_TXT.Text = "Configuration"

        VC_Type_ = Link_Valu(0)

        Button_Manage()
        Add_Hander_Remove_Handel(True)
    End Sub
    Private Function Button_Manage()
        Button_Clear()
        BG_frm.B_1.Text = "|&E : Exit"
        BG_frm.B_2.Text = "|&S : Save"
    End Function
    Private Function Add_Hander_Remove_Handel(Ans As Boolean)
        If Ans = True Then
            AddHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            AddHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
        Else
            RemoveHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            RemoveHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
        End If
    End Function
    Private Sub B_1_Click(sender As Object, e As EventArgs)
        Dim ro As Integer
        If BG_frm.From_ID = From_ID Then
            Me.Dispose()
        End If
    End Sub
    Private Sub B_2_Click(sender As Object, e As EventArgs)
        Dim ro As Integer
        If BG_frm.From_ID = From_ID Then
            obj.Save_Data()
            Save_()
        End If
    End Sub

    Private Sub cfg_Head_Form_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.HADE_TXT.Text = "Configuration"
        BG_frm.TYP_TXT.Text = VC_Type_

        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text
        Button_Clear()
        Button_Manage()

    End Sub

    Private Sub cfg_Head_Form_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If Msg_Exit_YN(VC_Type_ & " Configuration") = DialogResult.Yes Then
                Me.Dispose()
            End If
        End If
    End Sub

    Private Sub cfg_Head_Form_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        Add_Hander_Remove_Handel(False)
        BG_frm.BG_Path_TXT.Text = Path_End
        Frm_foCus()
    End Sub
    Private Sub bg_Paint(sender As Object, e As PaintEventArgs) Handles bg.Paint
        obj_center(sender, Me)
    End Sub
    Dim obj As Object

    Public Function Set_Cfg(ctrl As Object)
        obj = ctrl
        With obj
            bg.Controls.Add(obj)
            .Location = New Point(15, Panel1.Height + 0)
            .Show()
            .BringToFront()
            .Focus()
        End With
        bg.AutoSize = True
        bg.AutoSizeMode = AutoSizeMode.GrowAndShrink
    End Function

    Private Sub Save_TXT_TextChanged(sender As Object, e As EventArgs) Handles Save_TXT.TextChanged

    End Sub

    Private Sub Save_TXT_Enter(sender As Object, e As EventArgs) Handles Save_TXT.Enter
        If Msg_Custom_YN(NOT_Location.Bottom_Right, Color.Black, My.Resources.Question_animation_icn, Dialoag_Button.Yes_No, "Applay Configuration?", VC_Type_, "Are you sure<nl>apply configuration") = DialogResult.Yes Then
            obj.Save_Data()
            Save_()
        Else
            obj.Focus()
        End If
    End Sub
    Private Function Save_()
        obj.Save_()
        Me.Dispose()
    End Function

    Private Sub cfg_Head_Form_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
    End Sub
End Class