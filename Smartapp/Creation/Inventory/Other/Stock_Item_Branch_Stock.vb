Imports System.Data.SQLite

Public Class Stock_Item_Branch_Stock
    Dim Path_End As String
    Public VC_ID_ As String
    Dim From_ID As String
    Private Sub Stock_Item_Branch_Stock_ctrl1_Load(sender As Object, e As EventArgs) Handles Stock_Item_Branch_Stock_ctrl1.Load

    End Sub
    Private Function Load_Data()
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand("Select * From TBL_Ledger ld where ld.[Group] = '7' and ld.Visible = 'Approval'", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                With Stock_Item_Branch_Stock_ctrl1
                    .Add_New()
                    Dim idx As Integer = Stock_Item_Branch_Stock_ctrl1.platform.Controls.Count

                    Dim Applica_ As Boolean = True

                    If Find_DT_Value(Database_File.cre, "TBL_Stock_Item_Opning_Stock", "Applicable", $"Item_ID = '{VC_ID_}' and Branch_ID = '{r("ID")}'") = "No" Then
                        Applica_ = YN_Boolean("No")
                    End If

                    Dim Stock_ As String = Find_DT_Value(Database_File.cre, "TBL_Stock_Item_Opning_Stock", "Stock", $"Item_ID = '{VC_ID_}' and Branch_ID = '{r("ID")}'")


                    .Find_Particuls_TXT(idx).Text = r("Name").ToString
                    .Find_Branch_ID(idx).Text = r("ID").ToString
                    .Find_Applicap(idx).Text = Boolean_TXT(Applica_)

                    .Find_Bal_Type(idx).Text = Stock_Item_frm.Unit_TXT.Text
                    .Find_Bal_Vall(idx).Text = Val(Stock_)
                End With
            End While
        End If
    End Function
    Private Sub Ledger_Branch_Balance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text
        VC_ID_ = Link_Valu(0)
        BG_frm.HADE_TXT.Text = "Stock Item (Multi Branch Manager)"

        Load_Data()
    End Sub

    Private Sub Ledger_Branch_Balance_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.HADE_TXT.Text = "Stock Item (Multi Branch Manager)"
        Button_Clear()

        Stock_Item_Branch_Stock_ctrl1.Ledger_LAB.Text = Stock_Item_frm.Name_TXT.Text
    End Sub

    Private Sub Stock_Item_Branch_Stock_ctrl1_Paint(sender As Object, e As PaintEventArgs) Handles Stock_Item_Branch_Stock_ctrl1.Paint
        obj_center(sender, Me)
    End Sub

    Private Sub Save_TXT_Enter(sender As Object, e As EventArgs) Handles Save_TXT.Enter
        Me.Hide()
        SendKeys.Send("{TAB}")
    End Sub

    Private Sub Ledger_Branch_Balance_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If Msg_Exit_YN("Stock Item Branch Details") = DialogResult.Yes Then
                Me.Hide()
            End If
        End If
    End Sub

    Private Sub Stock_Item_Branch_Stock_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
    End Sub
End Class