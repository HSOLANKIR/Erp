Imports System.Data.SQLite

Public Class vouchers_type_class_ledger_list_ctrl
    Public Bg_Panel As Panel
    Public obj As Object
    Public Data_ As String
    Private Sub vouchers_type_class_ledger_list_ctrl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Name = $"bg_{Bg_Panel.Controls.Count}"

        Fill_Data()
        List_set()
    End Sub
    Private Function Fill_Data()
        Dim dt As New DataTable
        dt.Columns.Add("Name")

        dt.Rows.Add("Flat Rate")
        dt.Rows.Add("User Defined Value")
        dt.Rows.Add("Based on Quantity")
        dt.Rows.Add("Total Amount Rounding")
        dt.Rows.Add("Current SubTotal")
        dt.Rows.Add("Total Amount")

        Calculation_Source.DataSource = dt


        dt = New DataTable
        dt.Columns.Add("Name")

        dt.Rows.Add("Not Applicable")
        dt.Rows.Add("Downward Rounding")
        dt.Rows.Add("Normal Rounding")
        dt.Rows.Add("Upward Rounding")

        rounding_Source.DataSource = dt



        dt = New DataTable
        dt.Columns.Add("Name")
        dt.Columns.Add("Group")
        dt.Columns.Add("ID")
        dt.Columns.Add("Alias")
        dt.Rows.Add("End of List", "")

        Dim cn As New SQLiteConnection
        Dim r As SQLiteDataReader


        If open_MSSQL_Cstm(Database_File.cre, cn) Then
            cmd = New SQLiteCommand($"Select [ID],[Name],(Select ag.Name From TBL_Acc_Group ag where ag.id = ld.[Group]) as Group_Name,[Alise]
from TBL_Ledger LD where ([Group] = '13' or [Group] = '15')", cn)
            r = cmd.ExecuteReader
            While r.Read
                    dt.Rows.Add(r("Name").ToString, r("Group_Name").ToString, r("ID"), r("Alise").ToString)
            End While
            r.Close()
            Ledger_Source.DataSource = dt
        End If

    End Function
    Dim yn_list As List_frm
    Dim ag_list As List_frm
    Dim rounding_list As List_frm
    Private Function List_set()
        ag_list = New List_frm
        List_Setup("List of Account Ledger", Select_List.Right_Dock, Select_List_Format.Defolt, Ledger_TXT, ag_list, Ledger_Source, 320)

        yn_list = New List_frm
        List_Setup("Type of Calculation", Select_List.Right, Select_List_Format.Singel, calulation_TXT, yn_list, Calculation_Source, 200)

        rounding_list = New List_frm
        List_Setup("Type of Rounding Methods", Select_List.Right, Select_List_Format.Singel, Rounding_TXT, rounding_list, rounding_Source, 200)


    End Function
    Private Sub Txt2_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Txt2_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Dim index As Integer = Integer.Parse(Name.Split("_")(1))
            If Bg_Panel.Controls.Count = index Then

                obj.Add_Account_Group("", "")
            End If
        End If
    End Sub

    Private Sub Txt1_TextChanged(sender As Object, e As EventArgs) Handles Ledger_TXT.TextChanged

    End Sub

    Private Sub Txt1_KeyDown(sender As Object, e As KeyEventArgs) Handles Ledger_TXT.KeyDown
        If e.KeyCode = Keys.Enter Then
            Ledger_TXT.Data_Link_ = ag_list.List_Grid.CurrentRow.Cells("ID").Value.ToString


            If Val(Ledger_TXT.Data_Link_) = 0 Then
                calulation_TXT.Text = ""
                calulation_TXT.Enabled = False

                Dft_TXT.Text = ""
                Dft_TXT.Enabled = False

                Rounding_TXT.Text = ""
                Rounding_TXT.Enabled = False

                Rounding_Limit.Text = ""
                Rounding_Limit.Enabled = False
            Else
                calulation_TXT.Enabled = True
                Dft_TXT.Enabled = True
                Rounding_TXT.Enabled = True
                Rounding_Limit.Enabled = True
            End If
        End If
    End Sub

    Private Sub vouchers_type_class_ledger_list_ctrl_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        Dim col As Color = Color.FromArgb(254, 237, 194)
        Me.BackColor = col

        Ledger_TXT.BackColor = col
        Ledger_TXT.Back_color = col

        Dft_TXT.BackColor = col
        Dft_TXT.Back_color = col

        calulation_TXT.BackColor = col
        calulation_TXT.Back_color = col

        Rounding_TXT.BackColor = col
        Rounding_TXT.Back_color = col

        Rounding_Limit.BackColor = col
        Rounding_Limit.Back_color = col


    End Sub

    Private Sub vouchers_type_class_ledger_list_ctrl_Leave(sender As Object, e As EventArgs) Handles Me.Leave
        Dim col As Color = Color.White
        Me.BackColor = col

        Ledger_TXT.BackColor = col
        Ledger_TXT.Back_color = col

        Dft_TXT.BackColor = col
        Dft_TXT.Back_color = col

        calulation_TXT.BackColor = col
        calulation_TXT.Back_color = col

        Rounding_TXT.BackColor = col
        Rounding_TXT.Back_color = col

        Rounding_Limit.BackColor = col
        Rounding_Limit.Back_color = col
    End Sub

    Private Sub Rounding_TXT_TextChanged(sender As Object, e As EventArgs) Handles Rounding_TXT.TextChanged

    End Sub

    Private Sub Rounding_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles Rounding_TXT.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim index As Integer = Integer.Parse(Name.Split("_")(1))
            If rounding_list.List_Grid.CurrentRow.Cells(0).Value = "Not Applicable" Then
                Rounding_Limit.Enabled = False
                If Bg_Panel.Controls.Count = index Then
                    obj.Add_Ledger("", "", "", "", "")
                End If
            Else
                Rounding_Limit.Enabled = True
            End If
        End If
    End Sub

    Private Sub Rounding_Limit_TextChanged(sender As Object, e As EventArgs) Handles Rounding_Limit.TextChanged

    End Sub

    Private Sub Rounding_Limit_KeyDown(sender As Object, e As KeyEventArgs) Handles Rounding_Limit.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim index As Integer = Integer.Parse(Name.Split("_")(1))
            If Bg_Panel.Controls.Count = index Then
                obj.Add_Ledger("", "", "", "", "")
            End If
        End If
    End Sub

    Private Sub calulation_TXT_TextChanged(sender As Object, e As EventArgs) Handles calulation_TXT.TextChanged

    End Sub

    Private Sub calulation_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles calulation_TXT.KeyDown

    End Sub
End Class
