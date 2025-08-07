Imports System.Data.SQLite

Public Class Registers_Summary_cfg
    Public obj As Object
    Private Sub Registers_Summary_cfg_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_()
        List_set()
    End Sub
    Private Sub Narration_YN_TextChanged(sender As Object, e As EventArgs) Handles Chart_YN.TextChanged
        Panel1.Visible = YN_Boolean(sender.Text)

    End Sub
    Public Function Load_()
        With obj
            Chart_Type_TXT.Text = .Chart_Type
            Chart_YN.Text = Boolean_TXT(.Chart_YN)
            path_TXT.Text = (.cfg_print_path)
            Txt1.Text = (.Periodicity)
            Average_YN.Text = Boolean_TXT(.Average_YN)
        End With

        Dim dt As New DataTable
        dt.Columns.Add("Name")

        dt.Rows.Add("Column")
        dt.Rows.Add("Line")
        dt.Rows.Add("Spline")
        dt.Rows.Add("Area")
        dt.Rows.Add("Range")

        Chart_Type_Source.DataSource = dt

        dt = New DataTable
        dt.Columns.Add("Head")

        dt.Rows.Add("Fortnightly")
        dt.Rows.Add("Half Yearly")
        dt.Rows.Add("Monthly")
        dt.Rows.Add("Quarterly")
        dt.Rows.Add("Yearly")


        Periodicity_SOurce.DataSource = dt
    End Function
    Dim chart_list As List_frm
    Dim periodicity_list As List_frm
    Private Function List_set()
        chart_list = New List_frm
        List_Setup("Chart Type", Select_List.Right, Select_List_Format.Singel, Chart_Type_TXT, chart_list, Chart_Type_Source, 150)

        periodicity_list = New List_frm
        List_Setup("Periodicity", Select_List.Right, Select_List_Format.Singel, Txt1, periodicity_list, Periodicity_SOurce, 150)

    End Function
    Public Function Save_()
        obj.cfg_fill()

    End Function
    Public Function Save_Data()
        Update_cfg(Database_File.lnk, "cfg_Registers_Summary", "Chart_YN", Chart_YN.Text)
        Update_cfg(Database_File.lnk, "cfg_Registers_Summary", "Chart_Type", Chart_Type_TXT.Text)
        Update_cfg(Database_File.lnk, "cfg_Registers_Summary", "Print_Path", path_TXT.Text)
        Update_cfg(Database_File.lnk, "cfg_Registers_Summary", "Periodicity", Txt1.Text)
        Update_cfg(Database_File.lnk, "cfg_Registers_Summary", "Average", Average_YN.Text)
    End Function
End Class
