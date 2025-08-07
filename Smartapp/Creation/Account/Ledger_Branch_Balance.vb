Imports System.Data.SQLite

Public Class Ledger_Branch_Balance
    Dim Path_End As String
    Public VC_ID_ As String
    Private Sub Ledger_Branch_Balance_ctrl1_Load(sender As Object, e As EventArgs) Handles Ledger_Branch_Balance_ctrl1.Load
        Ledger_Branch_Balance_ctrl1.Height = Me.Height - 200
        obj_top(Ledger_Branch_Balance_ctrl1)

    End Sub
    Private Function Load_Data()
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand("Select * From TBL_Ledger ld where ld.[Group] = '7' and ld.Visible = 'Approval'", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                With Ledger_Branch_Balance_ctrl1
                    .Add_New()
                    Dim idx As Integer = Ledger_Branch_Balance_ctrl1.platform.Controls.Count

                    Dim Applica_ As Boolean = False

                    If Find_DT_Value(Database_File.cre, "TBL_Ledger_Opning_Balance", "Applicable", $"Ledger_ID = '{VC_ID_}' and Branch_ID = '{r("ID")}'") = "No" Then
                        Applica_ = YN_Boolean("No")
                    Else
                        Applica_ = YN_Boolean("Yes")
                    End If

                    Dim Cr_ As String = Find_DT_Value(Database_File.cre, "TBL_Ledger_Opning_Balance", "OB_Cr", $"Ledger_ID = '{VC_ID_}' and Branch_ID = '{r("ID")}'")
                    Dim Dr_ As String = Find_DT_Value(Database_File.cre, "TBL_Ledger_Opning_Balance", "OB_Dr", $"Ledger_ID = '{VC_ID_}' and Branch_ID = '{r("ID")}'")


                    .Find_Particuls_TXT(idx).Text = r("Name").ToString
                    .Find_Branch_ID(idx).Text = r("ID").ToString
                    .Find_Applicap(idx).Text = Boolean_TXT(Applica_)

                    If Val(Dr_) <> 0 Then
                        .Find_Bal_Type(idx).Text = "Dr"
                        .Find_Bal_Vall(idx).Text = Val(Dr_)
                    ElseIf Val(Cr_) <> 0 Then
                        .Find_Bal_Type(idx).Text = "Cr"
                        .Find_Bal_Vall(idx).Text = Val(Cr_)
                    Else
                        .Find_Bal_Type(idx).Text = "Cr"
                        .Find_Bal_Vall(idx).Text = ""
                    End If
                End With
            End While
        End If
    End Function
    Private Sub Ledger_Branch_Balance_ctrl1_KeyDown(sender As Object, e As KeyEventArgs) Handles Ledger_Branch_Balance_ctrl1.KeyDown

    End Sub

    Private Sub Ledger_Branch_Balance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Path_End = BG_frm.BG_Path_TXT.Text
        VC_ID_ = Link_Valu(0)
        BG_frm.HADE_TXT.Text = "Accounting Ledger (Multi Branch Manager)"

        Load_Data()
    End Sub

    Private Sub Ledger_Branch_Balance_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.HADE_TXT.Text = "Accounting Ledger (Multi Branch Manager)"
        Button_Clear()

        Ledger_Branch_Balance_ctrl1.Ledger_LAB.Text = Ledger_frm.Name_TXT.Text
    End Sub

    Private Sub Ledger_Branch_Balance_ctrl1_Paint(sender As Object, e As PaintEventArgs) Handles Ledger_Branch_Balance_ctrl1.Paint
        obj_top(Ledger_Branch_Balance_ctrl1)
    End Sub

    Private Sub Save_TXT_Enter(sender As Object, e As EventArgs) Handles Save_TXT.Enter

        With Ledger_Branch_Balance_ctrl1
            Dim P_ As New Queue(Of Panel)()
            For Each bg_p As Panel In Ledger_Branch_Balance_ctrl1.platform.Controls.OfType(Of Panel)()
                P_.Enqueue(bg_p)
            Next
            Dim vl As Decimal = 0
            For Each bg_p As Panel In P_.Reverse
                If .Find_Applicap(.Find_Idx(bg_p)).Text = "Yes" Then
                    'Ledger_frm.Yn4.Text = "Yes"
                    Exit For
                End If
                'Ledger_frm.Yn4.Text = "No"
            Next
        End With


        Me.Hide()
        'Ledger_frm.Yn4.Focus()
        SendKeys.Send("{TAB}")
    End Sub

    Private Sub Ledger_Branch_Balance_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If Msg_Exit_YN("Ledger Branch Details ") = DialogResult.Yes Then
                Me.Hide()
                'Ledger_frm.Yn4.Focus()
            End If
        End If
    End Sub
End Class