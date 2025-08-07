Public Class User_Raids_frm
    Dim From_ID As String
    Public Path_End As String
    Dim VC_Type_ As String
    Dim VC_ID_ As String
    Public focus_ As Object
    Public User_ID As String
    Private Sub User_Raids_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        'Path_End = BG_frm.BG_Path_TXT.Text
        BG_frm.HADE_TXT.Text = "User Configuration"
        User_ID = Link_Valu(0)

        User_Raids_ctrl1.Load_data()

    End Sub

    Private Sub User_Raids_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.HADE_TXT.Text = "User Configuration"
        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text
        Button_Clear()
    End Sub

    Private Sub User_Raids_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If Msg_Exit_YN("User Configuration") = DialogResult.Yes Then
                Me.Dispose()
            End If
        End If
    End Sub

    Private Sub User_Raids_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End
        Frm_foCus()
        'SendKeys.Send("{TAB}")
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        obj_center(sender, Me)
    End Sub

    Private Sub User_Raids_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
    End Sub
End Class