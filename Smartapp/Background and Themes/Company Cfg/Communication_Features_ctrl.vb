Imports System.Data.SQLite
Imports Tools

Public Class Communication_Features_ctrl
    Public Whatsapp_ID As String
    Private Sub Communication_Features_ctrl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel2.Visible = YN_Boolean(Communication_YN.Text)
    End Sub
    Public Function Load_()
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cmp, cn) = True Then
            cmd = New SQLiteCommand("Select * From TBL_Features where Type = 'General'", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                Dim Head As String = r("Head").ToString
                Dim Vlu As String = r("Value").ToString
                Dim dec As String = r("Discription").ToString
                Applay_(Head, Vlu, dec)
            End While
            r.Close()
            cn.Close()
        End If

        If open_MSSQL_Cstm(Database_File.cfgs, cn) = True Then
            cmd = New SQLiteCommand("Select * From TBL_Features where Type = 'General'", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                Dim Head As String = r("Head").ToString
                Dim Vlu As String = r("Value").ToString
                Dim dec As String = r("Discription").ToString
                Applay_(Head, Vlu, dec)
            End While
            r.Close()
            cn.Close()
        End If
    End Function
    Private Function Applay_(St As String, vlu As String, dec As String)
        Select Case St
            Case "Communication_YN"
                Communication_YN.Text = vlu
            Case "Whatsapp"
                Whatsapp_YN.Text = vlu
                Whatsapp_ID = dec
            Case "Email"
                Email_YN.Text = vlu
        End Select
    End Function
    Public Function Save_()
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cmp, cn) = True Then
            Update_(cn, Whatsapp_YN.Data_Link_, Whatsapp_YN.Text, "")
            Update_(cn, Email_YN.Data_Link_, Email_YN.Text, "")
        End If
        cn.Close()

        If open_MSSQL_Cstm(Database_File.cfgs, cn) = True Then
            Update_(cn, "Communication_YN", Communication_YN.Text, "")
        End If
        cn.Close()

    End Function
    Private Function Update_(cn As SQLiteConnection, Head As String, Vlu As String, dec As String)
        Dim create_ As Boolean = True
        cmd = New SQLiteCommand($"Select * From TBL_Features WHERE Head = '{Head }' and Type = 'General'", cn)
        Dim r As SQLiteDataReader
        r = cmd.ExecuteReader()
        While r.Read
            If Head = r("Head") Then
                create_ = False
            End If
        End While
        r.Close()

        If create_ = True Then
            cmd = New SQLiteCommand($"INSERT INTO TBL_Features (Head,Type)
VALUES('{Head}','General')", cn)
            cmd.ExecuteNonQuery()
        End If

        qury = $"UPDATE TBL_Features SET Value = '{Vlu }',Discription = '{dec}' WHERE Head = '{Head }' and Type = 'General'"
        cmd = New SQLiteCommand(qury, cn)
        cmd.ExecuteNonQuery()

        Fill_Features_Mod(Head, Vlu, dec)
    End Function

    Private Sub Yn1_TextChanged(sender As Object, e As EventArgs) Handles Yn1.TextChanged

    End Sub

    Private Sub Yn1_KeyDown(sender As Object, e As KeyEventArgs) Handles Yn1.KeyDown
        If sender.Text = "Yes" Then
            If e.KeyCode = Keys.Enter Then
                With Whatsapp_setup
                    .API_TXT.Text = Wh_Local_API
                    .Number_TXT.Text = Wh_Local_No

                    If .ShowDialog() <> DialogResult.OK Then
                        Yn1.Text = "No"
                    End If
                    SendKeys.Send("{TAB}")
                End With

            End If
        End If
    End Sub

    Private Sub Yn2_TextChanged(sender As Object, e As EventArgs) Handles Yn2.TextChanged

    End Sub

    Private Sub Yn2_KeyDown(sender As Object, e As KeyEventArgs) Handles Yn2.KeyDown
        If sender.Text = "Yes" Then
            If e.KeyCode = Keys.Enter Then
                'Frm_foCus()

                Email_Login_frm.focus_YN = True
                Email_Login_frm.focus_Obj = sender

                Email_Login_frm.ShowDialog()
            End If
        End If
    End Sub

    Private Sub Yn4_TextChanged(sender As Object, e As EventArgs) Handles Yn4.TextChanged

    End Sub

    Private Sub Yn4_KeyDown(sender As Object, e As KeyEventArgs) Handles Yn4.KeyDown
        If e.KeyData = Keys.Enter Then
            If Yn4.Text = "Yes" Then
                Cell("Communication Configuration")
            End If
        End If
    End Sub

    Private Sub Whatsapp_YN_TextChanged(sender As Object, e As EventArgs) Handles Whatsapp_YN.TextChanged

    End Sub

    Private Sub Email_YN_TextChanged(sender As Object, e As EventArgs) Handles Email_YN.TextChanged

    End Sub

    Private Sub Communication_YN_TextChanged(sender As Object, e As EventArgs) Handles Communication_YN.TextChanged

    End Sub

    Private Sub Communication_YN_KeyDown(sender As Object, e As KeyEventArgs) Handles Communication_YN.KeyDown
        If e.KeyCode = Keys.Enter Then
            Panel2.Visible = YN_Boolean(Communication_YN.Text)
        End If
    End Sub

    Private Sub Whatsapp_YN_KeyDown(sender As Object, e As KeyEventArgs) Handles Whatsapp_YN.KeyDown
        If e.KeyCode = Keys.Enter Then
            Panel12.Visible = YN_Boolean(Whatsapp_YN.Text)
        End If
    End Sub

    Private Sub Email_YN_KeyDown(sender As Object, e As KeyEventArgs) Handles Email_YN.KeyDown
        If e.KeyCode = Keys.Enter Then
            Panel13.Visible = YN_Boolean(Email_YN.Text)
        End If
    End Sub
End Class
