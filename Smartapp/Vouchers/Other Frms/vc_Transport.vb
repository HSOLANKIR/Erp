Imports System.Data.SQLite

Public Class vc_Transport
    Dim From_ID As String
    Dim Path_End As String
    Private Sub vc_Transport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        obj_top(Panel1)

        BG_frm.HADE_TXT.Text = "Vouchers Transport"
        BG_frm.TYP_TXT.Text = ""

        Button_Manage()
        NOT_Clear()
        Add_Hander_Remove_Handel(True)

        Load_()
        Fill_data_source()
        List_set()

    End Sub
    Private Function Button_Manage()
        BG_frm.B_1.Text = "&E : Exit"
        BG_frm.B_2.Text = "&S : Save"
    End Function
    Private Function Add_Hander_Remove_Handel(Ans As Boolean)
        If Ans = True Then
            AddHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            AddHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
        Else
            RemoveHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            RemoveHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
        End If
    End Function
    Private Sub B_1_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Me.Dispose()
        End If
    End Sub
    Private Sub B_2_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Save_()
            Me.Dispose()
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub vc_Transport_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.HADE_TXT.Text = "Vouchers Transport"
        BG_frm.TYP_TXT.Text = ""
        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text

        Button_Clear()
        Button_Manage()
        Fill_data_source()
        'Dis_Doc_TXT.Focus()
    End Sub

    Private Sub vc_Transport_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub vc_Transport_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End
        Add_Hander_Remove_Handel(False)
        Inventory_Vouchers_frm.Yn2.Focus()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        obj_top(Panel1)
    End Sub
    Private Function Load_()
        With Inventory_Vouchers_frm
            Dis_Doc_TXT.Text = .Dispatch_Doc
            Dis_through_TXT.Text = .Dispatch_through
            Transport_LR_TXT.Text = .LR_No
            Carrier_Name_TXT.Text = .Dispatch_Carrier_Name_agent
            Dis_date_TXT.Text = Date_Formate(.Dispatch_date)

            Transport_Name_TXT.Text = .Transport_Name

            Vehicle_Type.Text = .Vihicale_Type
            Vehicle_No_TXT.Text = .Vihicale_No

            Drive_Name_TXT.Text = .Driver_Name
            Drive_Phone_TXT.Text = .Driver_Phone
            Drive_Licence_TXT.Text = .Driver_License



            Vebrij_Gross = .Vebrij_Gross
            Vebrij_Vihical = .Vebrij_Vihical
            Vebrij_Net = .Vebrij_Net
        End With
    End Function
    Private Function Save_()
        With Inventory_Vouchers_frm
            .Dispatch_Doc = Dis_Doc_TXT.Text
            .Dispatch_through = Dis_through_TXT.Text
            .LR_No = Transport_LR_TXT.Text
            .Dispatch_Carrier_Name_agent = Carrier_Name_TXT.Text

            If Dis_date_TXT.Text <> Nothing Then
                .Dispatch_date = CDate(Dis_date_TXT.Text)
            End If


            .Transport_Name = Transport_Name_TXT.Text
            .LR_No = Transport_LR_TXT.Text

            .Vihicale_Type = Vehicle_Type.Text
            .Vihicale_No = Vehicle_No_TXT.Text

            .Driver_Name = Drive_Name_TXT.Text
            .Driver_Phone = Drive_Phone_TXT.Text
            .Driver_License = Drive_Licence_TXT.Text


            .Vebrij_Gross = Vebrij_Gross
            .Vebrij_Vihical = Vebrij_Vihical
            .Vebrij_Net = Vebrij_Net
        End With
    End Function
    Dim transport_list As List_frm
    Private Function List_set()
        transport_list = New List_frm
        List_Setup("List of Transport", Select_List.Right_Dock, Select_List_Format.Defolt, Transport_Name_TXT, transport_list, Transport_Source, 500)
        transport_list.System_Data_integer = 1

    End Function

    Private Function Fill_data_source()
        Dim dt As New DataTable
        dt.Columns.Add("Name")
        dt.Columns.Add("Vehicle No")
        dt.Columns.Add("ID")
        dt.Columns.Add("Vehicle Type")
        dt.Columns.Add("Phone")

        dt.Rows.Add("", "Create")
        dt.Rows.Add("Not Applicable")

        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand("Select * From TBL_Tranport where " & Company_Visible_Filter(), cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            Dim dr As DataRow
            While r.Read
                dr = dt.NewRow
                dr("Name") = r("Name")
                dr("Phone") = r("Phone")
                dr("ID") = r("ID")
                dr("Vehicle Type") = r("Vehicle_Type")
                dr("Vehicle No") = r("Vehicle_No")
                dt.Rows.Add(dr)
            End While
        End If

        Transport_Source.DataSource = dt
    End Function
    Private Sub Dis_date_TXT_LostFocus(sender As Object, e As EventArgs) Handles Dis_date_TXT.LostFocus
        Dis_date_TXT.Text = Date_Formate(Dis_date_TXT.Text)
    End Sub

    Private Sub Transport_Name_TXT_TextChanged(sender As Object, e As EventArgs) Handles Transport_Name_TXT.TextChanged

    End Sub

    Private Sub Transport_Name_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles Transport_Name_TXT.KeyDown

        If e.KeyCode = Keys.Enter Then
            Dim ro As DataGridViewRow = transport_list.List_Grid.CurrentRow
            If ro.Cells(1).Value.ToString = "Create" Then
                Create_Transport()
                Exit Sub
            End If

            Transport_Name_TXT.Data_Link_ = ro.Cells(2).Value.ToString

            If Transport_Name_TXT.Data_Link_ <> Nothing Then
                Transport_Phone_TXT.Text = ro.Cells(4).Value
                Vehicle_Type.Text = ro.Cells(3).Value
                Vehicle_No_TXT.Text = ro.Cells(1).Value
            Else
                Transport_Phone_TXT.Text = ""
                Vehicle_Type.Text = ""
                Vehicle_No_TXT.Text = ""
            End If
        End If

        If e.KeyCode = Keys.C AndAlso e.Modifiers = Keys.Alt Then
        ElseIf e.KeyCode = Keys.Enter AndAlso e.Modifiers = Keys.Control Then
            Cell("Transport", "", "Alter_Close", Transport_Name_TXT.Data_Link_)
            Transport_create_frm.close_focus_obj = Transport_Name_TXT
            Transport_create_frm.close_link_yn = True
        End If
    End Sub

    Private Function Create_Transport()
        Cell("Transport", "", "Create_Close", "")

        Transport_create_frm.close_link_yn = True
        Transport_create_frm.close_focus_obj = Transport_Name_TXT
        Transport_create_frm.Name_TXT.Text = Transport_Name_TXT.Text
    End Function
    Private Sub Dis_Doc_TXT_TextChanged(sender As Object, e As EventArgs) Handles Dis_Doc_TXT.TextChanged

    End Sub

    Private Sub Dis_Doc_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles Dis_Doc_TXT.KeyDown
        If e.KeyCode = Keys.Back Then
            Me.Dispose()
        End If
    End Sub

    Private Sub SAVE_TXT_TextChanged(sender As Object, e As EventArgs) Handles SAVE_TXT.TextChanged

    End Sub

    Private Sub SAVE_TXT_Enter(sender As Object, e As EventArgs) Handles SAVE_TXT.Enter
        BG_frm.B_2.PerformClick()
    End Sub

    Public Vebrij_Gross As String
    Public Vebrij_Vihical As String
    Public Vebrij_Net As String

    Private Sub Drive_Phone_TXT_TextChanged(sender As Object, e As EventArgs) Handles Drive_Phone_TXT.TextChanged

    End Sub

    Private Sub Yn1_TextChanged(sender As Object, e As EventArgs) Handles Yn1.TextChanged

    End Sub

    Private Sub Yn1_KeyDown(sender As Object, e As KeyEventArgs) Handles Yn1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If sender.Text = "Yes" Then
                If Transport_Tred_Details_diaload.ShowDialog() = DialogResult.OK Then
                    SendKeys.Send("{TAB}")
                End If
            End If
        End If
    End Sub

    Private Sub Drive_Licence_TXT_TextChanged(sender As Object, e As EventArgs) Handles Drive_Licence_TXT.TextChanged

    End Sub

    Private Sub vc_Transport_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

    End Sub
End Class