Imports System.Data.SQLite
Imports System.IO

Public Class Day_Book_cfg
    Public obj As Object

    Private Sub Repoer_Ledger_cfg_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_()
        List_set()
    End Sub
    Public Function Load_()
        Txt3.Text = Find_DT_Value(Database_File.lnk, "cfg_DayBook", "Value", "Head = 'Print_Path'")

        Dim dt As New DataTable
        dt.Columns.Add("Name")

        'dt.Rows.Add("Alphabetical (A to Z)")
        'dt.Rows.Add("Alphabetical (Z to A)")
        'dt.Rows.Add("Amount (Decreasing)")
        'dt.Rows.Add("Amount (Increasing)")
        dt.Rows.Add("Date (Decreasing)")
        dt.Rows.Add("Date (Increasing)")

        BindingSource1.DataSource = dt

        With obj
            Narration_YN.Text = Boolean_TXT(.Narration_)
            Sorting_TXT.Text = .Sorting_Methoud_
            .Fill_Grid()
        End With

    End Function
    Public Function Save_Data()
        Update_cfg(Database_File.lnk, "cfg_DayBook", "Print_Path", Txt3.Text)
    End Function
    Dim sorting_list As List_frm
    Dim dt_rdlc As DataTable
    Private Function List_set()
        sorting_list = New List_frm
        List_Setup("Sorting Method", Select_List.Right, Select_List_Format.Singel, Sorting_TXT, sorting_list, BindingSource1, 200)

    End Function
    Public Function Save_()
        With obj
            .Narration_ = YN_Boolean(Narration_YN.Text)
            .Sorting_Methoud_ = Sorting_TXT.Text
            .Fill_Grid()
        End With
    End Function
    Private Sub Branch_YN_TextChanged(sender As Object, e As EventArgs) Handles Narration_YN.TextChanged

    End Sub

    Private Sub Repoer_Ledger_cfg_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        Me.Focus()
    End Sub

End Class
