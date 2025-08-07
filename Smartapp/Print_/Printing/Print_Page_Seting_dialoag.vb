Imports System.ComponentModel

Public Class Print_Page_Seting_dialoag
    Private Sub Panel25_Paint(sender As Object, e As PaintEventArgs) Handles Panel25.Paint
        obj_center(sender, Panel24)
    End Sub

    Private Sub Print_Page_Seting_dialoag_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With Printing_frm
            If .isLandscape = True Then
                Panel25.Size = New Size(110, 90)
            Else
                Panel25.Size = New Size(90, 110)
            End If

            t_margin.Value = Val(.t_m) / 100
            l_margin.Value = Val(.l_m) / 100
            r_margin.Value = Val(.r_m) / 100
            b_margin.Value = Val(.b_m) / 100
        End With
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With Printing_frm
            .t_m = t_margin.Value * 100
            .l_m = l_margin.Value * 100
            .r_m = r_margin.Value * 100
            .b_m = b_margin.Value * 100
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End With
    End Sub

    Private Sub Print_Page_Seting_dialoag_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Me.Dispose()
    End Sub

    Private Sub Print_Page_Seting_dialoag_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = DialogResult.Cancel
            Me.Dispose()
        End If
    End Sub
End Class