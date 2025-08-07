Imports System.Data.SQLite

Public Class Cheque_Set_frm
    Dim From_ID As String
    Dim Path_End As String
    Public VC_ID_ As String
    Public Focus_Obj As Object
    Private Function Load_Data()

    End Function
    Private Sub Cheque_Set_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'From_ID = New Random().Next()
        'BG_frm.From_ID = From_ID


        Path_End = BG_frm.BG_Path_TXT.Text
        VC_ID_ = Link_Valu(0)
        BG_frm.HADE_TXT.Text = "Cheque Configuration"

        Load_Data()
    End Sub

    Private Sub Cheque_Set_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.HADE_TXT.Text = "Cheque Configuration"
        Button_Clear()

    End Sub


    Private Sub Save_TXT_Enter(sender As Object, e As EventArgs) Handles Save_TXT.Enter
        save()
        Me.Dispose()
        Ledger_frm.Yn2.Focus()
        SendKeys.Send("{TAB}")
    End Sub

    Private Sub Cheque_Set_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If Msg_Exit_YN("Cheque Configuration ") = DialogResult.Yes Then
                Me.Dispose()
                'Ledger_frm.Yn4.Focus()
            End If
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        obj_top(sender)
    End Sub
    Private Function save()
        With Ledger_frm
            .Cheque_Height = Cheque_Height.Text
            .Cheque_Width = Cheque_Width.Text

            .Cheque_Cross_Top = Cross_Top.Text
            .Cheque_Cross_Left = Cross_Left.Text

            .Cheque_Date_Top = Date_Top.Text
            .Cheque_Date_Left = Date_Left.Text

            .Cheque_Date_Format = Date_Format.Text
            .Cheque_Date_Separator = Date_Sparator.Text
            .Cheque_Date_Distance = Date_Distance.Text

            .Cheque_Party_Top = Party_Top.Text
            .Cheque_Party_Left = Party_Left.Text
            .Cheque_Party_area = Party_Width.Text

            .Cheque_AmountW1_Top = Amount_W1_Top.Text
            .Cheque_AmountW1_Left = Amount_W1_Left.Text
            .Cheque_AmountW1_Width = Amount_W1_Width.Text

            .Cheque_AmountW2_Top = Amount_W2_Top.Text
            .Cheque_AmountW2_Left = Amount_W2_Left.Text
            .Cheque_AmountW2_Width = Amount_W2_width.Text

            .Cheque_Amount_Top = Amount_Top.Text
            .Cheque_Amount_Left = Amount_Left.Text
            .Cheque_Amount_Width = Amount_Width.Text

        End With
    End Function
End Class