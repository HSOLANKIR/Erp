Imports System.Data.SQLite
Imports Tools

Public Class General_Features_ctrl
    Private Sub General_Features_ctrl_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        List_set()
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

    End Function
    Dim ag_list As List_frm
    Private Function List_set()

    End Function
    Private Function Applay_(St As String, vlu As String, dec As String)
        Select Case St
            Case "Positive Value"
                Positive_TXT.Text = vlu
            Case "Negative Value"
                Negative_TXT.Text = vlu
            Case "Date Format"
                Date_Format_TXT.Text = vlu

        End Select
    End Function
    Public Function Save_()
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cmp, cn) = True Then
            Update_(cn, Positive_TXT.Data_Link_, Positive_TXT.Text, "")
            Update_(cn, Negative_TXT.Data_Link_, Negative_TXT.Text, "")
            Update_(cn, Date_Format_TXT.Data_Link_, Date_Format_TXT.Text, "")
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
    Private Sub Date_Format_TXT_TextChanged(sender As Object, e As EventArgs) Handles Date_Format_TXT.TextChanged
        Label17.Text = CDate(Now.Date).ToString(Date_Format_TXT.Text)
    End Sub
    Private Sub Date_Format_TXT_LostFocus(sender As Object, e As EventArgs) Handles Date_Format_TXT.LostFocus
        If Date_Formate(Label17.Text) = "" Then
            Date_Format_TXT.Focus()
        End If

    End Sub
End Class
