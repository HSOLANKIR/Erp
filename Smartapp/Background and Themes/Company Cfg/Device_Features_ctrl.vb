Imports System.Data.SQLite
Imports System.Drawing.Printing

Public Class Device_Features_ctrl
    Private Sub Device_Features_ctrl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Printer_Driver_Find()
        'Load()
        List_set()
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
    Dim ag_list As List_frm
    Private Function List_set()
        ag_list = New List_frm
        List_Setup("List of Printer", Select_List.Right, Select_List_Format.Singel, Defolt_Printer_Select, ag_list, Printer_Source, 250)

    End Function
    Private Function Applay_(St As String, vlu As String, dec As String)
        Select Case St
            Case "Defolt Printer"
                Defolt_Printer_Select.Text = vlu
            Case "Auto_Logout_YN"
                Yn4.Text = vlu
            Case "Auto_Logout_Sec"
                Auto_Logout_TXT.Text = vlu
        End Select
    End Function
    Public Function Save_()
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cfgs, cn) = True Then
            Update_(cn, Defolt_Printer_Select.Data_Link_, Defolt_Printer_Select.Text, "")
            Update_(cn, "Auto_Logout_YN", Yn4.Text, "")
            Update_(cn, "Auto_Logout_Sec", Val(Auto_Logout_TXT.Text), "")
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

    Private Function Printer_Driver_Find()
        Dim dt As New DataTable
        dt.Columns.Add("Name")
        Dim pkInstalledPrinters As String

        For Each pkInstalledPrinters In
            PrinterSettings.InstalledPrinters
            dt.Rows.Add(pkInstalledPrinters)
        Next pkInstalledPrinters

        Printer_Source.DataSource = dt
    End Function
    Private Sub Yn4_TextChanged(sender As Object, e As EventArgs) Handles Yn4.TextChanged

    End Sub

    Private Sub Yn4_KeyDown(sender As Object, e As KeyEventArgs) Handles Yn4.KeyDown
        If e.KeyCode = Keys.Enter Then
            Panel24.Visible = YN_Boolean(Yn4.Text)
        End If
    End Sub
End Class
