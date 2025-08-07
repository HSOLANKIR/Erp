Imports System.Data.SqlClient
Public Class Bill_wise_details_frm
    Dim VC_Type_ As String
    Dim Ledger_List_Value As String
    Dim Date_TXT As Date
    Dim Branch_ID As String

    Dim VC_ID_ As String
    Dim Tra_ID As String
    Dim Audit_ID As String
    Dim VC_Formate As String
    Dim VC_Formate_ID As String
    Dim Vlu As String

    Dim Acc_ID As String
    Dim Path_End As String
    Private Sub Bill_wise_details_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Path_End = BG_frm.BG_Path_TXT.Text

        VC_ID_ = Link_Valu(0)
        Vlu = (Link_Valu(1))
        If Val(Vlu) > 0 Then
            Vlu = Format(Val(Vlu), "N2") & "Cr"
            VC_Type_ = "Cr"
        Else
            Vlu = Format(Val(Val(Vlu) * -1), "N2") & "Dr"
            VC_Type_ = "Dr"
        End If

        Label3.Text = Link_Valu(1)

        BG_frm.HADE_TXT.Text = "Bill-Wise Details"
        BG_frm.TYP_TXT.Text = VC_Type_

        Label4.Text = VC_ID_

    End Sub

    Private Sub Bill_wise_details_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.HADE_TXT.Text = "Bill-Wise Details"
        BG_frm.TYP_TXT.Text = VC_Type_

        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text
        Button_Clear()
    End Sub

    Private Sub Bill_wise_details_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If Msg_Yn("Are you sure", "") = DialogResult.Yes Then
                Me.Dispose()
            End If
        End If
    End Sub

    Private Sub Bill_wise_details_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End
        Frm_foCus()
    End Sub
End Class