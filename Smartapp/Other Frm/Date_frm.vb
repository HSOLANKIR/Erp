Imports System.Data.SqlClient

Public Class Date_frm
    Dim From_ID As String
    Public Path_End As String
    Public Frm_Obj As Object
    Public To_Obj As Object
    Public Curr_Obj As Object()
    Public Doubal_ As Boolean
    Public obj As Object

    Private Sub Date_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text
        If Doubal_ = True Then
            Frm_TXT.Text = Date_1.ToString(Date_Format_fech)
            To_TXT.Text = Date_2.ToString(Date_Format_fech)
            Period_Panel.Visible = True
            Panel1.Visible = False
        Else
            Period_Panel.Visible = False
            Panel1.Visible = True
            curr_TXT.Text = Date_3.ToString(Date_Format_fech)
        End If
    End Sub
    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles To_TXT.TextChanged
        Date_Set(sender)
        Try
            Label4.Text = CDate(sender.Text).ToString("dddd")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Date_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.HADE_TXT.Text = "Date"
        BG_frm.TYP_TXT.Text = "Alteration"
        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text

        Button_Clear()
        If Doubal_ = True Then
            Frm_TXT.Focus()
        Else
            curr_TXT.Focus()
        End If


    End Sub

    Private Sub Date_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End
        Frm_foCus()
    End Sub

    Private Sub Date_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = DialogResult.No
            Me.Dispose()
        End If
    End Sub
    Private Function Date_Set(Sender As Object) As Boolean


        If Date_Formate(Sender.Text) = Nothing Then
            Sender.Focus()
            Return False
        Else
        End If
        Return True
    End Function
    Private Function Date_set2() As Boolean
        Dim dt1 As Date
        Dim dt2 As Date
        If Date_Formate(Frm_TXT.Text) = Nothing Then
            Exit Function
        End If
        If Date_Formate(To_TXT.Text) = Nothing Then
            Exit Function
        End If
        dt1 = CDate(Frm_TXT.Text).ToString(Date_Format_fech)
        dt2 = CDate(To_TXT.Text).ToString(Date_Format_fech)

        If dt1 > dt2 Then
            Return False
        End If
        Return True
    End Function
    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles To_TXT.KeyDown
        If e.KeyCode = Keys.Enter Then
            If To_TXT.Text = "" Then
                To_TXT.Text = Date_Formate(Date.Now)
            End If

            If Date_Formate(Frm_TXT.Text) = Nothing Then
                Frm_TXT.Focus()
                Exit Sub
            End If
            If Date_Formate(To_TXT.Text) = Nothing Then
                To_TXT.Focus()
                Exit Sub
            End If
            If Date_set2() = False Then
                To_TXT.Focus()
                Exit Sub
            End If

            Date_1 = CDate(Frm_TXT.Text).ToString(Date_Format_fech)
            Date_2 = CDate(To_TXT.Text).ToString(Date_Format_fech)

            obj.Apply_Date_Filter(True)
            Me.Dispose()
        End If
    End Sub

    Private Sub Txt2_TextChanged(sender As Object, e As EventArgs) Handles curr_TXT.TextChanged
        Date_Set(sender)
        Try
            Label6.Text = CDate(sender.Text).ToString("dddd")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txt2_KeyDown(sender As Object, e As KeyEventArgs) Handles curr_TXT.KeyDown
        If e.KeyCode = Keys.Enter Then
            If curr_TXT.Text = "" Then
                curr_TXT.Text = Date.Now.ToString(Date_Format_fech)
            End If
            If Date_Brack(curr_TXT.Text) = Nothing Then
                curr_TXT.Focus()
                Exit Sub
            End If
            Date_3 = CDate(curr_TXT.Text).ToString(Date_Format_fech)

            obj.Apply_Date_Filter(False)
            Me.Dispose()
        End If
    End Sub
    Private Sub Txt1_TextChanged(sender As Object, e As EventArgs) Handles Frm_TXT.TextChanged
        Try
            Label3.Text = CDate(sender.Text).ToString("dddd")
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Frm_TXT_LostFocus(sender As Object, e As EventArgs) Handles Frm_TXT.LostFocus, To_TXT.LostFocus
        If Frm_TXT.Text = "" Then
            Frm_TXT.Text = Date_Formate(Date.Now)
        End If

        sender.Text = Date_Formate(sender.Text)

        If sender.Text = Nothing Then
            sender.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub Period_Panel_Paint(sender As Object, e As PaintEventArgs) Handles Period_Panel.Paint
        obj_center(sender, Me)
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        obj_center(sender, Me)
    End Sub

    Private Sub curr_TXT_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs)

    End Sub

    Private Sub Date_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
        If Doubal_ = True Then
            Frm_TXT.Focus()
        Else
            curr_TXT.Focus()
        End If
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub
End Class