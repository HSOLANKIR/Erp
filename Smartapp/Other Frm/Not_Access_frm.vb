Public Class Not_Access_frm
    Dim From_ID As String

    Dim Path_End As String
    Dim VC_Type_ As String
    Private Sub Not_Access_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text
        VC_Type_ = Link_Valu(0)

        BG_frm.HADE_TXT.Text = "Not Access"
        BG_frm.TYP_TXT.Text = VC_Type_

        Label3.Text = VC_Type_
    End Sub
    Private Sub Backup_Panel_Paint(sender As Object, e As PaintEventArgs) Handles Backup_Panel.Paint
        obj_center(sender, Me)
    End Sub

    Private Sub Not_Access_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.HADE_TXT.Text = "Not Access"
        BG_frm.TYP_TXT.Text = VC_Type_
        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text

        Button_Clear()
    End Sub

    Private Sub Not_Access_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        'If e.KeyCode = Keys.Escape Then
        Me.Dispose()
        'End If
    End Sub

    Private Sub Not_Access_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End
        Frm_foCus()



    End Sub

    Private Sub Not_Access_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
    End Sub
End Class