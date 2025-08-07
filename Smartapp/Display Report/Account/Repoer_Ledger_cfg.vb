Imports System.Data.SQLite
Public Class Repoer_Ledger_cfg
    Public obj As Object
    Private Sub Repoer_Ledger_cfg_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_()
        List_set()
    End Sub
    Public Function Save_Data()
        Update_cfg(Database_File.lnk, "cfg_Accounting_Report", "Print_Path", Txt3.Text)

    End Function
    Public Function Load_()
        Txt3.Text = Find_DT_Value(Database_File.lnk, "cfg_Accounting_Report", "Value", "Head = 'Print_Path'")
        Dim dt As New DataTable
        dt.Columns.Add("Name")

        'dt.Rows.Add("Alphabetical (A to Z)")
        'dt.Rows.Add("Alphabetical (Z to A)")
        'dt.Rows.Add("Amount (Decreasing)")
        'dt.Rows.Add("Amount (Increasing)")
        'dt.Rows.Add("Amount (Between)")
        dt.Rows.Add("Date (Decreasing)")
        dt.Rows.Add("Date (Increasing)")

        BindingSource1.DataSource = dt



        With obj

            Narration_YN.Text = Boolean_TXT(.Col_Narration)

            OB_YN.Text = Boolean_TXT(.Opning_Balance_YN)
            Txt1.Text = Val(.Sorting_Amt_F)
            Txt2.Text = Val(.Sorting_Amt_E)
            Sorting_TXT.Text = obj.Sorting_Methoud_
            '.Fill_Grid()
        End With

    End Function
    Dim sorting_list As List_frm
    Private Function List_set()
        sorting_list = New List_frm
        List_Setup("Sorting Method", Select_List.Right, Select_List_Format.Singel, Sorting_TXT, sorting_list, BindingSource1, 200)
    End Function
    Public Function Save_()
        With obj
            .Col_Narration = YN_Boolean(Narration_YN.Text)
            .Opning_Balance_YN = YN_Boolean(OB_YN.Text)
            .Sorting_Amt_F = Val(Txt1.Text)
            .Sorting_Amt_E = Val(Txt2.Text)
            .Sorting_Methoud_ = Sorting_TXT.Text
            .Fill_Grid()
        End With
    End Function
    Private Sub Branch_YN_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Repoer_Ledger_cfg_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        Me.Focus()
    End Sub

    Private Sub Sorting_TXT_TextChanged(sender As Object, e As EventArgs) Handles Sorting_TXT.TextChanged
        If sender.Text = "Amount (Between)" Then
            Panel2.Visible = True
        Else
            Panel2.Visible = False
        End If

    End Sub

    Private Sub Txt3_TextChanged(sender As Object, e As EventArgs) Handles Txt3.TextChanged
        If Chck_Directry(Txt3.Text) = True Then
            Label11.ForeColor = Color.Green
        Else
            Label11.ForeColor = Color.Red
        End If
    End Sub
    Private Sub Txt3_LostFocus(sender As Object, e As EventArgs) Handles Txt3.LostFocus
        If Chck_Directry(Txt3.Text) = True Then

        Else
            'Txt3.Text = ""
        End If
    End Sub
End Class

