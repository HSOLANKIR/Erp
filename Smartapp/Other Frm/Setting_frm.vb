Imports System.Data.SqlClient
Imports System.Data.SQLite

Public Class Setting_frm

    Private Sub Setting_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        M1_Click(e, e)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
    End Sub
    Private Function Button_Manage(Btn As Label)
        M1.BackColor = Panel8.BackColor
        M2.BackColor = Panel8.BackColor

        Btn.BackColor = Panel6.BackColor
    End Function

    Private Sub M1_Click(sender As Object, e As EventArgs) Handles M1.Click
        Button_Manage(M1)
        hEAD_txt.Text = "General Settings"

        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cmp, cn) = True Then
            cmd = New SQLiteCommand("Select * From TBL_Setting", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                Dim Head As String = r("Head")
                Dim Vlu As String = r("Value")

                Applay_(Head, Vlu)
            End While
        End If
    End Sub
    Private Function Applay_(St As String, vlu As String)
        Select Case St
            Case "Branch_YN"
                Branch_YN.Text = vlu
            Case "Payroll_YN"
                Payroll_YN.Text = vlu
            Case "Category_YN"
                Category_YN.Text = vlu
            Case "EwayBill_YN"
                Eway_Bill_YN.Text = vlu
            Case "Delivery_Chalan_YN"
                Delivery_Chalan_YN.Text = vlu

        End Select
    End Function

    Private Sub M2_Click(sender As Object, e As EventArgs) Handles M2.Click
        Button_Manage(sender)
    End Sub
    Private Function Alter_Data(Colu As String, Vlu As String)
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cmp, cn) = True Then
            cmd = New SQLiteCommand("UPDATE TBL_Setting SET Value = '" & Vlu & "' where Head = '" & Colu & "'", cn)
            cmd.ExecuteNonQuery()
        End If
    End Function

    Private Sub Branch_YN_TextChanged(sender As Object, e As EventArgs) Handles Branch_YN.TextChanged

        Alter_Data("Branch_YN", Branch_YN.Text)
    End Sub

    Private Sub Payroll_YN_TextChanged(sender As Object, e As EventArgs) Handles Payroll_YN.TextChanged
        Alter_Data("Payroll_YN", Payroll_YN.Text)
    End Sub

    Private Sub Category_YN_TextChanged(sender As Object, e As EventArgs) Handles Category_YN.TextChanged
        Alter_Data("Category_YN", Category_YN.Text)
    End Sub

    Private Sub Setting_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub Eway_Bill_YN_TextChanged(sender As Object, e As EventArgs) Handles Eway_Bill_YN.TextChanged
        Alter_Data("EwayBill_YN", Eway_Bill_YN.Text)
    End Sub

    Private Sub Yn1_TextChanged(sender As Object, e As EventArgs) Handles Delivery_Chalan_YN.TextChanged
        Alter_Data("Delivery_Chalan_YN", Delivery_Chalan_YN.Text)
    End Sub
End Class