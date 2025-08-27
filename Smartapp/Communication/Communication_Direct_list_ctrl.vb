Public Class Communication_Direct_list_ctrl
    Public Property Name_ As String
    Public Property Subject_ As String
    Public Property Message_ As String
    Public Property Type_of_message_ As String
    Public Property Attached_ As String
    Public Property Attached_Type_ As String
    Public Property ID_ As Integer
    Private Sub Communication_Direct_list_strl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Wh_TXT.Visible = Whatsapp_YN_fech
        wh_status.Visible = Whatsapp_YN_fech

        Email_TXT.Visible = Email_YN_fech
        email_status.Visible = Email_YN_fech
    End Sub
    Dim acc_list As List_frm
    Public Function List_set()
        With acc_list
            acc_list = New List_frm
            List_Setup("List of Ledger", Select_List.Right, Select_List_Format.Defolt, Name_TXT, acc_list, Direct_Communication_frm.Ledger_Source, 350)
            acc_list.System_Data_integer = 1
        End With
    End Function
    Public Function Color_(co As Color)
        Me.BackColor = co
        Wh_TXT.BackColor = co
        Email_TXT.BackColor = co
        Name_TXT.BackColor = co

        Wh_TXT.Back_color = co
        Email_TXT.Back_color = co
        Name_TXT.Back_color = co
    End Function

    Private Sub Email_TXT_TextChanged(sender As Object, e As EventArgs) Handles Email_TXT.TextChanged

    End Sub

    Private Sub Email_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles Email_TXT.KeyDown
        If e.KeyCode = Keys.Enter Then
            If ID_ = Direct_Communication_frm.bg_Panel.Controls.Count Then
                If Wh_TXT.Text <> "" Or Email_TXT.Text <> "" Then
                    With Direct_Communication_frm.Add_New()
                        .List_set()
                    End With
                End If
            End If
        End If
    End Sub

    Private Sub Name_TXT_TextChanged(sender As Object, e As EventArgs) Handles Name_TXT.TextChanged

    End Sub

    Private Sub Name_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles Name_TXT.KeyDown
        If e.KeyCode = Keys.Enter Then
            If acc_list.List_Grid.CurrentRow.Cells(0).Value = "End of List" Then
                Wh_TXT.Enabled = False
                Email_TXT.Enabled = False

                Wh_TXT.Text = ""
                Email_TXT.Text = ""
            Else
                Wh_TXT.Enabled = True
                Email_TXT.Enabled = True
                If acc_list.List_Grid.CurrentRow.Cells(1).Value <> "Custom" Then
                    Dim Old_ID As String = Name_TXT.Text

                    If Old_ID <> acc_list.List_Grid.CurrentRow.Cells("Name").Value Then
                        Wh_TXT.Text = acc_list.List_Grid.CurrentRow.Cells("WhatsApp").Value
                        Email_TXT.Text = acc_list.List_Grid.CurrentRow.Cells("Email").Value
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub Wh_TXT_TextChanged(sender As Object, e As EventArgs) Handles Wh_TXT.TextChanged

    End Sub

    Private Sub Wh_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles Wh_TXT.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Email_YN_fech = False Then
                If ID_ = Direct_Communication_frm.bg_Panel.Controls.Count Then
                    If Wh_TXT.Text <> "" Or Email_TXT.Text <> "" Then
                        With Direct_Communication_frm.Add_New()
                            .List_set()
                        End With
                    End If
                End If
            End If
        End If
    End Sub
End Class
