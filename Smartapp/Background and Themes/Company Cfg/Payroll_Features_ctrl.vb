Imports System.Data.SQLite
Imports Tools

Public Class Payroll_Features_ctrl
    Private Sub Payeoll_Features_ctrl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        List_set()
    End Sub
    Public Function Load_()
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cmp, cn) = True Then
            cmd = New SQLiteCommand("Select * From TBL_Features where Type = 'Payroll'", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                Dim Head As String = r("Head")
                Dim Vlu As String = r("Value")
                Applay_(Head, Vlu)
            End While
            r.Close()
            cn.Close()
        End If
        TableLayoutPanel1.Visible = YN_Boolean(Payroll_YN.Text, False)

    End Function
    Dim ag_list As List_frm
    Private Function List_set()

    End Function
    Private Function Applay_(St As String, vlu As String)
        Select Case St
            Case "Payroll_YN"
                Payroll_YN.Text = vlu
        End Select
    End Function
    Public Function Save_()
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cmp, cn) = True Then
            Update_(cn, Payroll_YN.Data_Link_, Payroll_YN.Text)
        End If

        cn.Close()
    End Function
    Private Function Update_(cn As SQLiteConnection, Head As String, Vlu As String)
        Dim create_ As Boolean = True
        cmd = New SQLiteCommand("Select * From TBL_Features WHERE Head = '" & Head & "' and Type = 'Payroll'", cn)
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
VALUES('{Head}','Payroll')", cn)
            cmd.ExecuteNonQuery()
        End If


        qury = "UPDATE TBL_Features SET Value = '" & Vlu & "' WHERE Head = '" & Head & "' and Type = 'Payroll'"
        cmd = New SQLiteCommand(qury, cn)

        cmd.ExecuteNonQuery()



        Fill_Features_Mod(Head, Vlu, "")

    End Function
    Private Sub Yn1_TextChanged1(sender As Object, e As EventArgs) Handles Payroll_YN.TextChanged
        TableLayoutPanel1.Visible = YN_Boolean(Payroll_YN.Text, False)
    End Sub
End Class
