Imports System.Data.SQLite
Imports Tools

Public Class Backup_Restore_Features_ctrl
    Private Sub Backup_Restore_Features_ctrl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Maximum_Panel.Visible = YN_Boolean(Backup_YN.Text)
    End Sub
    Public Function Load_()
        Dim cn As New SQLiteConnection
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
            Case "Auto_Backup_Data"
                Backup_YN.Text = vlu
                Txt1.Text = dec
            Case "Auto_Backup_Data_Max"
                Txt2.Text = (vlu)

        End Select
    End Function
    Public Function Save_()
        Try
            Dim cn As New SQLiteConnection
            If open_MSSQL_Cstm(Database_File.cfgs, cn) = True Then
                Update_(cn, "Auto_Backup_Data", Backup_YN.Text, Txt1.Text)
                Update_(cn, "Auto_Backup_Data_Max", Val(Txt2.Text), "")
            End If
        Catch ex As Exception

        End Try
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
    Private Sub Backup_YN_TextChanged(sender As Object, e As EventArgs) Handles Backup_YN.TextChanged

    End Sub

    Private Sub Txt1_TextChanged(sender As Object, e As EventArgs) Handles Txt1.TextChanged

    End Sub

    Private Sub Txt1_LostFocus(sender As Object, e As EventArgs) Handles Txt1.LostFocus
        If Chck_Directry(Txt1.Text) = False Then
            Txt1.Text = Nothing
        End If

        If Txt1.Text = Nothing Then
            Panel4.Visible = False
            Backup_YN.Text = "No"
            SendKeys.Send("{TAB}")
            Exit Sub
        Else
            'Panel4.Visible = True
        End If



    End Sub

    Private Sub Backup_YN_KeyDown(sender As Object, e As KeyEventArgs) Handles Backup_YN.KeyDown
        If e.KeyCode = Keys.Enter Then
            Maximum_Panel.Visible = YN_Boolean(Backup_YN.Text)
        End If
    End Sub

    Private Sub Txt1_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Chck_Directry(Txt1.Text) = True Then
                Panel4.Visible = True
                'Maximum_Panel.Visible = True
            Else
                Panel4.Visible = False
                'Maximum_Panel.Visible = False
            End If
        End If
    End Sub
End Class
