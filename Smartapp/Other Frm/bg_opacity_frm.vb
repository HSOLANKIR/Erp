Public Class bg_opacity_frm
    Private Sub bg_opacity_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs)

    End Sub

    Private Sub bg_opacity_frm_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged

    End Sub

    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim ret As CreateParams = MyBase.CreateParams
            ret.Style = CInt(&H40000000)
            Return ret
        End Get
    End Property
End Class