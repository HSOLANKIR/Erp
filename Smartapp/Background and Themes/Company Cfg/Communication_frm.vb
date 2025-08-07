Imports System.Data.SQLite

Public Class Communication_frm
    Dim Path_End As String
    Dim VC_Type_ As String
    Dim VC_ID_ As String
    'Public focus_ As Object
    Private Sub Communication_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Path_End = BG_frm.BG_Path_TXT.Text
        BG_frm.HADE_TXT.Text = "Communication Configuration"
        Communication_ctrl1.Load_data()
        Load_data()

        Txt1.Focus()
    End Sub
    Private Function Load_data()
        With Communication_ctrl1

            Dim cn As New SQLiteConnection
            If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                cmd = New SQLiteCommand("Select * From (
Select 'Under' as Type,ag.id as ag_ID,ld.id as ID,ifnull(ld.Communication_Whatsapp,'No') as W,ifnull(ld.Communication_Email,'No') as E From TBL_Ledger ld left JOIN TBL_Acc_Group ag on ag.id = ld.[Group]
where ld.Communication_Type <> 'By Group (Default)' and ld.Visible = 'Approval' and ag.Visible = 'Approval'
UNION ALL
Select 'Head' as Type,ag.id as ag_ID,ag.ID as ID,ifnull(ag.Communication_Whatsapp,'No') as W,ifnull(ag.Communication_Email,'No') as E From TBL_Acc_Group ag LEFT JOIN TBL_Ledger ld on ld.[Group] = ag.id
where ((ag.Communication_Whatsapp <> ld.Communication_Whatsapp or ag.Communication_Email <> ld.Communication_Email) or ag.Communication_Whatsapp = 'Yes' or ag.Communication_Email = 'Yes') and ld.Visible = 'Approval' and ag.Visible = 'Approval'
group by ag.id
)
Order By ag_id", cn)

                Dim r As SQLiteDataReader
                r = cmd.ExecuteReader

                Dim data_ As String = ""

                While r.Read
                    Dim type As String = r("Type")
                    Dim Particuls As String = r("ID")
                    Dim Group_ID As String = r("ag_ID")
                    Dim w As String = r("w")
                    Dim e As String = r("e")

                    With Communication_ctrl1
                        If type = "Head" Then
                            .Add_New()
                            Dim idx As Integer = .platform.Controls.Count - 0
                            .Find_Particuls_ID(idx).Text = Particuls
                            .Find_Particuls(idx).Text = Find_DT_Value(Database_File.cre, "TBL_Acc_Group", "Name", $"id = '{Particuls}'")

                            .Find_Whatsapp(idx).Text = w
                            .Find_Email(idx).Text = e

                            .find_data(idx).Text = data_
                            data_ = ""
                        ElseIf type = "Under" Then
                            data_ &= $"{Particuls}-{w}-{e},"
                        End If
                    End With
                End While
            End If


            If .platform.Controls.Count - 0 = 0 Then
                .Add_New()
            End If
        End With


    End Function
    Private Sub Communication_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If Msg_Exit_YN("Communication") = DialogResult.Yes Then
                Me.Dispose()
                cmp_cfg_bg_frm.Communication_Manu.Object_.Yn4.Focus()
                cmp_cfg_bg_frm.Communication_Manu.Object_.Yn4.Text = "No"
            End If
        End If
    End Sub

    Private Sub Communication_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End
        'focus_.Focus()
        SendKeys.Send("{TAB}")
    End Sub

    Private Sub Communication_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.HADE_TXT.Text = "Communication Configuration"
        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text
        Button_Clear()
    End Sub
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        obj_center(sender, Me)
        Panel1.Height = Me.Height - 50
    End Sub

    Private Sub Yn1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Yn1_LostFocus(sender As Object, e As EventArgs)
        If sender.Text = "No" Then
            Communication_ctrl1.Whatsaap_Arryr.All(Function(i)
                                                       i.Visible = False
                                                   End Function)
        Else
            Communication_ctrl1.Whatsaap_Arryr.All(Function(i)
                                                       i.Visible = True
                                                   End Function)
        End If
    End Sub

    Private Sub bg_Panel_Paint(sender As Object, e As PaintEventArgs) Handles bg_Panel.Paint

    End Sub
End Class