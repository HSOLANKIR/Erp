Imports System.Data.SQLite

Public Class vc_export_frm
    Dim From_ID As String
    Dim Path_End As String
    Private Sub vc_export_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        obj_top(Panel1)

        BG_frm.HADE_TXT.Text = "Inventory Voucher Export Details"
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
    Private Function Load_()
        With Inventory_Vouchers_frm
            Dis_Doc_TXT.Text = .Export_shipper
            Transport_LR_TXT.Text = .Export_port_loading
            Txt1.Text = .Export_port_discharge

            Dis_through_TXT.Text = .Export_shipping_bill
            Carrier_Name_TXT.Text = .Export_Date
            Dis_date_TXT.Text = .Export_Port_Code
            LUT_TXT.Text = .Export_LUT_No

        End With
    End Function
    Private Function Save_()
        With Inventory_Vouchers_frm
            .Export_shipper = Dis_Doc_TXT.Text
            .Export_port_loading = Transport_LR_TXT.Text
            .Export_port_discharge = Txt1.Text

            .Export_shipping_bill = Dis_through_TXT.Text
            .Export_Date = Carrier_Name_TXT.Text
            .Export_Port_Code = Dis_date_TXT.Text
            .Export_LUT_No = LUT_TXT.Text

        End With
    End Function
    Private Sub vc_export_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.HADE_TXT.Text = "Inventory Voucher Export Details"
        BG_frm.TYP_TXT.Text = ""
        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text

        Button_Clear()
        Button_Manage()
        Fill_data_source()
        Dis_Doc_TXT.Focus()
    End Sub

    Private Sub vc_export_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub vc_export_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End
        Add_Hander_Remove_Handel(False)
        Inventory_Vouchers_frm.Yn6.Focus()
    End Sub
    Private Function Fill_data_source()
        Dim dt As New DataTable
        dt.Columns.Add("Name")
        dt.Columns.Add("Code")

        dt.Rows.Add("Not Applicable", "")

        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cfgs, cn) = True Then
            cmd = New SQLiteCommand("Select * From TBL_PORT_CODE", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                dt.Rows.Add(r("Name").ToString, r("Code").ToString)
            End While
        End If
        Port_Source.DataSource = dt
    End Function
    Dim port_list As List_frm
    Private Function List_set()
        port_list = New List_frm
        List_Setup("List of Port Codes", Select_List.Right, Select_List_Format.Defolt, Dis_date_TXT, port_list, Port_Source, 350)

    End Function
    Private Sub SAVE_TXT_Enter(sender As Object, e As EventArgs) Handles SAVE_TXT.Enter
        BG_frm.B_2.PerformClick()
    End Sub

    Private Sub Carrier_Name_TXT_TextChanged(sender As Object, e As EventArgs) Handles Carrier_Name_TXT.TextChanged

    End Sub

    Private Sub Carrier_Name_TXT_LostFocus(sender As Object, e As EventArgs) Handles Carrier_Name_TXT.LostFocus
        Carrier_Name_TXT.Text = Date_Formate(Carrier_Name_TXT.Text)

        If Carrier_Name_TXT.Text = Nothing Then
            Carrier_Name_TXT.Text = CDate(Now.Date)
        End If
    End Sub

    Private Sub Txt2_TextChanged(sender As Object, e As EventArgs) Handles LUT_TXT.TextChanged

    End Sub

    Private Sub vc_export_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
    End Sub
End Class