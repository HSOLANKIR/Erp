Imports System.Data.SQLite
Imports Tools

Public Class Account_Features_ctrl
    Private Sub Account_Features_ctrl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Load_()
        List_set()
        TableLayoutPanel1.Visible = YN_Boolean(Account_YN.Text)

    End Sub
    Public Function Load_()
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cmp, cn) = True Then
            cmd = New SQLiteCommand("Select * From TBL_Features where Type = 'Account'", cn)
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
            Case Account_YN.Data_Link_
                Account_YN.Text = vlu
            Case Contra_YN.Data_Link_
                Contra_YN.Text = vlu
            Case Payment_YN.Data_Link_
                Payment_YN.Text = vlu
            Case Receipt_YN.Data_Link_
                Receipt_YN.Text = vlu
            Case Journal_YN.Data_Link_
                Journal_YN.Text = vlu

        End Select
    End Function
    Public Function Save_()
        Try
            Dim cn As New SQLiteConnection
            If open_MSSQL_Cstm(Database_File.cmp, cn) = True Then
                Update_(cn, Account_YN.Data_Link_, Account_YN.Text, "")

                Update_(cn, Contra_YN.Data_Link_, Contra_YN.Text, "")
                Update_(cn, Payment_YN.Data_Link_, Payment_YN.Text, "")
                Update_(cn, Receipt_YN.Data_Link_, Receipt_YN.Text, "")
                Update_(cn, Journal_YN.Data_Link_, Journal_YN.Text, "")
                cn.Close()
            End If
        Catch ex As Exception

        End Try
    End Function
    Private Function Update_(cn As SQLiteConnection, Head As String, Vlu As String, dec As String)
        Dim create_ As Boolean = True
        cmd = New SQLiteCommand("Select * From TBL_Features WHERE Head = '" & Head & "' and Type = 'Account'", cn)
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
VALUES('{Head}','Account')", cn)
            cmd.ExecuteNonQuery()
        End If



        qury = "UPDATE TBL_Features SET Value = '" & Vlu & "',Discription = '" & dec & "' WHERE Head = '" & Head & "' and Type = 'Account'"
        cmd = New SQLiteCommand(qury, cn)
        cmd.ExecuteNonQuery()

        Fill_Account_Features_Mod(Head, Vlu, dec)
    End Function
    Private Sub Inventory_YN_TextChanged(sender As Object, e As EventArgs) Handles Account_YN.TextChanged

    End Sub

    Private Sub Account_YN_KeyDown(sender As Object, e As KeyEventArgs) Handles Account_YN.KeyDown
        If e.KeyCode = Keys.Enter Then
            TableLayoutPanel1.Visible = YN_Boolean(Account_YN.Text)
        End If
    End Sub
End Class
