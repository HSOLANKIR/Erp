Public Class Salary_details_type
    Dim From_ID As String
    Dim Path_End As String

    Private Sub Salary_details_type_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text
        BG_frm.HADE_TXT.Text = "Salary Details Type"



        Dim dt As New DataTable
        dt.Columns.Add("Name")

        dt.Rows.Add("Employee wise")
        dt.Rows.Add("Group wise")

        BindingSource1.DataSource = dt
        List_set()

        Txt1.Focus()
    End Sub
    Dim _list As List_frm
    Private Function List_set()

        obj_top(Panel2)


        _list = New List_frm
        List_Setup("Salary Details Type", Select_List.Botom_Center, Select_List_Format.Singel, Txt1, _list, BindingSource1, Panel2.Width + 50)


    End Function
    Private Sub Salary_details_type_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        Me.Dock = DockStyle.Fill

        BG_frm.HADE_TXT.Text = "Salary Details Type"
        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text

        Button_Clear()
        Txt1.Focus()
    End Sub

    Private Sub Salary_details_type_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub Salary_details_type_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End
        List_frm.Dispose()
        Frm_foCus()
    End Sub


    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint
        'obj_center(Panel2, Me)
        obj_top(Panel2)
    End Sub

    Private Sub Txt1_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim str As String = _list.List_Grid.CurrentRow.Cells(0).Value
            If str = "Employee wise" Then
                Cell("Display List", "", str, "Display List>Salary Details", "Payroll_Employee_BS", "")

            ElseIf str = "Group wise" Then
                Cell("Display List", "", str, "Display List>Salary Details", "Payroll_Group_BS", "")
            End If
        End If
    End Sub

    Private Sub Salary_details_type_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        Txt1.Focus()
        BG_frm.From_ID = From_ID
    End Sub

    Private Sub Txt1_TextChanged(sender As Object, e As EventArgs) Handles Txt1.TextChanged

    End Sub
End Class