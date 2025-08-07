Imports System.Data.SQLite

Public Class vouchers_type_class_group_list_ctrl
    Public Bg_Panel As Panel
    Public obj As Object
    Public Data_ As String
    Private Sub vouchers_type_class_group_list_ctrl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Name = $"bg_{Bg_Panel.Controls.Count}"

        Fill_Data()
        List_set()
    End Sub
    Private Function Fill_Data()
        Dim dt As New DataTable
        dt.Columns.Add("Name")

        dt.Rows.Add("Allow")
        dt.Rows.Add("Not Allowed")

        BindingSource1.DataSource = dt

        dt = New DataTable
        dt.Columns.Add("Name")
        dt.Columns.Add("Under Group")
        dt.Columns.Add("ID")
        dt.Rows.Add("End of List", "", "")


        Dim cn As New SQLiteConnection
        Dim dr As DataRow

        If open_MSSQL_Cstm(Database_File.cre, cn) Then
            cmd = New SQLiteCommand("Select ID,Name,(Select [Name] From TBL_Acc_Group agg where agg.ID = ag.UserGroup) as Under_Group From TBL_Acc_Group ag where " & Company_Visible_Filter(), cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                If r("ID").ToString = "28" Or r("ID").ToString = "17" Or r("ID").ToString = "7" Or r("ID").ToString = "27" Or r("ID").ToString = "22" Or r("ID").ToString = "26" Then
                    dr = dt.NewRow
                    dr("ID") = r("ID").ToString
                    dr("Name") = r("Name").ToString
                    If r("Under_Group").ToString = Nothing Then
                        dr("Under Group") = "Primary"
                    Else
                        dr("Under Group") = r("Under_Group").ToString
                    End If
                    dt.Rows.Add(dr)
                End If
            End While
            r.Close()
            Group_Source.DataSource = dt
        End If

    End Function
    Dim yn_list As List_frm
    Dim ag_list As List_frm
    Private Function List_set()
        ag_list = New List_frm
        List_Setup("List of Account Groups", Select_List.Right_Dock, Select_List_Format.Defolt, Txt1, ag_list, Group_Source, 320)

        yn_list = New List_frm
        List_Setup("Status", Select_List.Right, Select_List_Format.Singel, statsu_txt, yn_list, BindingSource1, 150)

    End Function
    Private Sub Txt2_TextChanged(sender As Object, e As EventArgs) Handles statsu_txt.TextChanged

    End Sub

    Private Sub Txt2_KeyDown(sender As Object, e As KeyEventArgs) Handles statsu_txt.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim index As Integer = Integer.Parse(Name.Split("_")(1))
            If Bg_Panel.Controls.Count = index Then

                obj.Add_Account_Group("", "")
            End If
        End If
    End Sub

    Private Sub Txt1_TextChanged(sender As Object, e As EventArgs) Handles Txt1.TextChanged

    End Sub

    Private Sub Txt1_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Txt1.Data_Link_ = ag_list.List_Grid.CurrentRow.Cells("ID").Value.ToString

            If Val(Txt1.Data_Link_) = 0 Then
                statsu_txt.Text = ""
                statsu_txt.Enabled = False
            Else
                statsu_txt.Enabled = True
            End If
        End If
    End Sub

    Private Sub vouchers_type_class_group_list_ctrl_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        Dim col As Color = Color.FromArgb(254, 237, 194)
        Me.BackColor = col

        Txt1.BackColor = col
        Txt1.Back_color = col

        statsu_txt.BackColor = col
        statsu_txt.Back_color = col


    End Sub

    Private Sub vouchers_type_class_group_list_ctrl_Leave(sender As Object, e As EventArgs) Handles Me.Leave
        Dim col As Color = Color.White
        Me.BackColor = col

        Txt1.BackColor = col
        Txt1.Back_color = col

        statsu_txt.BackColor = col
        statsu_txt.Back_color = col
    End Sub
End Class
