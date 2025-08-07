Imports System.Data.SQLite
Imports Microsoft.Reporting.WinForms

Public Class Report_Ledger_frm
    Dim From_ID As String
    Private VC_Type_ As String
    Private VC_ID_ As String
    Private Path_End As String
    Dim YN_Details As Boolean
    Dim Acc_Under As String
    Dim Frm_date As Date
    Dim to_date As Date
    Dim Date_Filter As String
    Dim Date_Filter_OB As String
    Dim Count_ As Integer

    Public Sorting_Methoud_ As String = "Date (Increasing)"
    Public Sorting_Amt_F As String = "0"
    Public Sorting_Amt_E As String = "0"

    Public Delete_Entry = False
    Public Opning_Balance_YN = True

    Dim ds_print As New Print_dt
    Dim dt_print As New DataTable

    Dim Defolt_Select_ID As String = 0
    Dim Branch_ID As String = 0

    'Private footer As DGVfooter.DGVfooter_Basic

    Private Sub Report_Ledger_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text
        'footer = New DGVfooter.DGVfooter_Basic(Me.Grid1)
        Create_Database_Table()

        VC_Type_ = Link_Valu(1)
        VC_ID_ = Link_Valu(2)

        Frm_Date_LB.Text = Date_1
        To_Date_LB.Text = Date_2

        Try
            Frm_Date_LB.Text = Link_Valu(3)
            To_Date_LB.Text = Link_Valu(4)
        Catch ex As Exception
            Frm_Date_LB.Text = Date_1
            To_Date_LB.Text = Date_2
        End Try


        BG_frm.HADE_TXT.Text = "Report Ledger"

        BG_frm.TYP_TXT.Text = VC_Type_
        Button_Manage()
        Add_Hander_Remove_Handel(True)
        Md = Moad.Short_

        Update_Report = True
    End Sub
    Private Function Button_Manage()
        Button_Clear()
        BG_frm.B_1.Text = "Enter : Alter"
        BG_frm.B_2.Text = "&Delete"
        BG_frm.B_3.Text = "&Refresh"
        BG_frm.B_4.Text = "&2 : Duplicate"
        BG_frm.B_5.Text = "&Add vch."
        BG_frm.B_6.Text = "&Print"
        BG_frm.B_7.Text = "&Spc. : Sel."
        BG_frm.B_8.Text = "&Spc. : Sel. All"
        If Features_mod.Communication_YN = True Then
            BG_frm.B_9.Text = "&Communi."
        End If

        BG_frm.R_1.Text = "|F1 : Detailed"
        BG_frm.R_2.Text = "F2 : Date"
        BG_frm.R_3.Text = "|F2 : Period"
        BG_frm.R_4.Text = "F3 : Voucher Type"
        If Branch_Visible() = True Then
            BG_frm.R_5.Text = "F4 : Branch"
        Else '
        End If
        BG_frm.R_7.Text = "F5 : Monthly"
        BG_frm.R_8.Text = "F6 : Columns Cfg."

        BG_frm.R_22.Text = "F12 : Configuration"
    End Function
    Private Function Add_Hander_Remove_Handel(Ans As Boolean)
        If Ans = True Then
            AddHandler BG_frm.KeyDown, AddressOf Me.BG_Keydown
            AddHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            AddHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
            AddHandler BG_frm.B_3.Click, AddressOf Me.B_3_Click
            AddHandler BG_frm.B_4.Click, AddressOf Me.B_4_Click
            AddHandler BG_frm.B_5.Click, AddressOf Me.B_5_Click
            AddHandler BG_frm.B_6.Click, AddressOf Me.B_6_Click
            AddHandler BG_frm.B_7.Click, AddressOf Me.B_7_Click
            AddHandler BG_frm.B_8.Click, AddressOf Me.B_8_Click
            AddHandler BG_frm.B_9.Click, AddressOf Me.B_9_Click

            AddHandler BG_frm.R_1.Click, AddressOf Me.R_1_Click
            AddHandler BG_frm.R_2.Click, AddressOf Me.R_3_Click
            AddHandler BG_frm.R_3.Click, AddressOf Me.R_4_Click
            AddHandler BG_frm.R_4.Click, AddressOf Me.R_6_Click
            If Branch_Visible() = True Then
                AddHandler BG_frm.R_5.Click, AddressOf Me.R_9_Click
            End If
            AddHandler BG_frm.R_7.Click, AddressOf Me.R_12_Click
            AddHandler BG_frm.R_8.Click, AddressOf Me.R_8_Click
            AddHandler BG_frm.R_22.Click, AddressOf Me.R_22_Click
        Else
            RemoveHandler BG_frm.KeyDown, AddressOf Me.BG_Keydown
            RemoveHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            RemoveHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
            RemoveHandler BG_frm.B_3.Click, AddressOf Me.B_3_Click
            RemoveHandler BG_frm.B_4.Click, AddressOf Me.B_4_Click
            RemoveHandler BG_frm.B_5.Click, AddressOf Me.B_5_Click
            RemoveHandler BG_frm.B_6.Click, AddressOf Me.B_6_Click
            RemoveHandler BG_frm.B_7.Click, AddressOf Me.B_7_Click
            RemoveHandler BG_frm.B_8.Click, AddressOf Me.B_8_Click
            RemoveHandler BG_frm.B_9.Click, AddressOf Me.B_9_Click

            RemoveHandler BG_frm.R_1.Click, AddressOf Me.R_1_Click
            RemoveHandler BG_frm.R_2.Click, AddressOf Me.R_3_Click
            RemoveHandler BG_frm.R_3.Click, AddressOf Me.R_4_Click
            RemoveHandler BG_frm.R_4.Click, AddressOf Me.R_6_Click
            If Branch_Visible() = True Then
                RemoveHandler BG_frm.R_5.Click, AddressOf Me.R_9_Click
            End If
            RemoveHandler BG_frm.R_7.Click, AddressOf Me.R_12_Click
            RemoveHandler BG_frm.R_8.Click, AddressOf Me.R_8_Click
            RemoveHandler BG_frm.R_22.Click, AddressOf Me.R_22_Click
        End If
    End Function
    Private Sub BG_Keydown(sender As Object, e As KeyEventArgs)
        If BG_frm.From_ID = From_ID Then
            If e.KeyCode = Keys.R AndAlso e.Modifiers = Keys.Alt Then
                BG_frm.B_3.PerformClick()
            End If
            If e.KeyCode = Keys.D2 AndAlso e.Modifiers = Keys.Alt Then
                BG_frm.B_4.PerformClick()
            End If
            If e.KeyCode = Keys.A AndAlso e.Modifiers = Keys.Alt Then
                BG_frm.B_5.PerformClick()
            End If
            If e.KeyCode = Keys.Space AndAlso e.Modifiers = Keys.Control Then
                BG_frm.B_8.PerformClick()
            ElseIf e.KeyCode = Keys.Space Then
                BG_frm.B_7.PerformClick()
            End If

            If e.KeyCode = Keys.F1 AndAlso e.Modifiers = Keys.Alt Then
                BG_frm.R_1.PerformClick()
            End If
            If e.KeyCode = Keys.F2 AndAlso e.Modifiers = Keys.Alt Then
                BG_frm.R_3.PerformClick()
            ElseIf e.KeyCode = Keys.F2 Then
                BG_frm.R_2.PerformClick()
            End If
            If e.KeyCode = Keys.F3 AndAlso e.Modifiers = Keys.Alt Then

            ElseIf e.KeyCode = Keys.F3 Then
                BG_frm.R_4.PerformClick()
            End If
            If e.KeyCode = Keys.F4 AndAlso e.Modifiers = Keys.Alt Then

            ElseIf e.KeyCode = Keys.F4 Then
                BG_frm.R_5.PerformClick()
            End If

            If e.KeyCode = Keys.F5 AndAlso e.Modifiers = Keys.Alt Then
            ElseIf e.KeyCode = Keys.F5 Then
                BG_frm.R_7.PerformClick()
            End If
            If e.KeyCode = Keys.F6 Then
                BG_frm.R_8.PerformClick()
            End If
            If e.KeyCode = Keys.F12 Then
                BG_frm.R_22.PerformClick()
            End If
            If e.KeyCode = Keys.F AndAlso e.Modifiers = Keys.Control Then
                BG_frm.R_6.PerformClick()
            End If
        End If
    End Sub
    Private Sub B_1_Click(sender As Object, e As EventArgs)
        Dim ro As Integer
        If BG_frm.HADE_TXT.Text = "Report Ledger" Then
            If Grid1.Rows.Count > 0 Then
                Cell("Voucher BG", Grid1.CurrentRow.Cells(7).Value.ToString, "Alter_Close", Grid1.CurrentRow.Cells(8).Value.ToString)
            End If
        End If
    End Sub
    Private Sub B_2_Click(sender As Object, e As EventArgs)
        Dim ro As Integer
        If BG_frm.From_ID = From_ID Then
            Dim c As Integer = Grid1.Columns.Count - 1
            If Msg_Custom_YN(NOT_Location.Bottom_Right, Color.Red, My.Resources.Delete_animation_icn, Dialoag_Button.Yes_No, "Are you sure", "Delete Vouchers", "Do you want to<nl>delete selected vouchers?") = DialogResult.Yes Then
                For Each row_ As DataGridViewRow In Grid1.Rows
                    If row_.Cells(c).Value = True And row_.Cells(0).Value = "Head" Then
                        If Delete_Vouchers(row_.Cells(7).Value.ToString, row_.Cells(8).Value.ToString) = False Then

                        End If
                    End If
                Next

                Dim cn As New SQLiteConnection
                If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                    'BG_frm.Voucher_BS.DataSource = Nothing
                    'BG_frm.Voucher_BS.DataSource = Fill_Vouchhers(cn)
                End If
                Fill_Grid()
            End If
        End If
    End Sub
    Private Sub B_3_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Fill_Grid()
        End If
    End Sub
    Private Sub B_4_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            If Grid1.Rows.Count > 0 Then
                Cell("Voucher BG", Grid1.CurrentRow.Cells(7).Value.ToString, "Duplicate", Grid1.CurrentRow.Cells(8).Value.ToString)
            End If
        End If
    End Sub
    Private Sub B_5_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            If Grid1.Rows.Count > 0 Then
                Cell("Voucher BG", Grid1.CurrentRow.Cells(7).Value, "Create_Close", Grid1.CurrentRow.Cells(8).Value, Grid1.CurrentRow.Cells(9).Value)
            End If
        End If
    End Sub
    Dim cfg_print_path As String
    Dim rdlc_report_name As String
    Dim rdlc_report_data() As ReportDataSource
    Private Sub B_6_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Print_data_fill()
            print_prmt.Obj = Me
            Printing_Direct_frm.Printing_(cfg_print_path, rdlc_report_name, "", rdlc_report_data)
        End If
    End Sub
    Private Function Print_data_fill()
        rdlc_report_name = $"{Acc_LB.Text} ({Frm_date.ToString("dd-MMM-yyyy")} to {to_date.ToString("dd-MMM-yyyy")})"
        rdlc_report_name = path_validation(rdlc_report_name, "-")

        rdlc_report_data = {New ReportDataSource("dt_accbook", dt_print), New ReportDataSource("dt_cmp", Print_DT_Company)}
    End Function
    Private Sub B_7_Click(sender As Object, e As EventArgs)
        If BG_frm.HADE_TXT.Text = "Report Ledger" And BG_Panel.Visible = True And Grid1.CurrentRow.Cells(0).Value = "Head" Then
            Dim c As Integer = Grid1.Columns.Count - 1
            If Grid1.CurrentRow.Cells(c).Value = True Then
                Grid1.CurrentRow.Cells(c).Value = False
            ElseIf Grid1.CurrentRow.Cells(c).Value = False Then
                Grid1.CurrentRow.Cells(c).Value = True
            End If
        End If
    End Sub
    Private Sub B_8_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Dim c As Integer = Grid1.Columns.Count - 1
            For Each ro As DataGridViewRow In Grid1.Rows
                ro.Cells(c).Value = True
            Next
            Grid1.Refresh()
        End If
    End Sub
    Private Sub B_9_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            If Msg_Custom_YN(NOT_Location.Bottom_Right, Color.Black, My.Resources.Communication_animation_icn, Dialoag_Button.Yes_No, "Question?", "Communication", "Do you want to send this<nl>report on WhatsApp and email") = DialogResult.Yes Then
                Print_data_fill()
                Dim path As String = Application.StartupPath & $"\_other_savefiles\{rdlc_report_name}.pdf"
                Export_PDF(cfg_print_path, path, rdlc_report_data)

                Dim whatsapp_allow As Boolean = Chack_Communication_allow(VC_ID_, "Communication_Whatsapp")
                Dim email_allow As Boolean = Chack_Communication_allow(VC_ID_, "Communication_Email")
                Dim wh As String = ""
                Dim em As String = ""
                Dim subject As String = $"Statement ({Frm_date.ToString("dd-MMM-yyyy")} to {to_date.ToString("dd-MMM-yyyy")})"

                If email_allow = True Then
                    em = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Email", $"id = '{VC_ID_}'")
                End If
                If whatsapp_allow = True Then
                    wh = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Phone", $"id = '{VC_ID_}'")
                End If
                If whatsapp_allow = True Or email_allow = True Then
                    Whatsapp_Sending_list.Add_to_list(Acc_LB.Text, wh, em, subject, CDate(Now.Date).ToString("dd-MMM-yyyy"), "Document", path, path.Split(".").Last, "Pending", "Pending")
                End If

                Whatsapp_Sending_list.Start_()
            End If
        End If
    End Sub
    Private Sub R_1_Click(sender As Object, e As EventArgs)
        If BG_frm.HADE_TXT.Text = "Report Ledger" Then
            If YN_Details = True Then
                YN_Details = False
                BG_frm.R_1.Text = "|F1 : Detailed"
            ElseIf YN_Details = False Then
                YN_Details = True
                BG_frm.R_1.Text = "|F1 : Condensed"
            End If
            Fill_Grid()
        End If
    End Sub
    Private Sub R_3_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Set_Date(False, Me)
        End If
    End Sub
    Private Sub R_4_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Set_Date(True, Me)
        End If
    End Sub
    Private Sub R_6_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Cell("Filter", "Voucher Type", BG_frm.HADE_TXT.Text)
        End If
    End Sub
    Private Sub R_7_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then

        End If
    End Sub
    Private Sub R_9_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Cell("Filter", "Branch", BG_frm.HADE_TXT.Text)
        End If
    End Sub
    Private Sub R_8_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            'Cell("Configuration", "Report Ledger Columns Configuration")
            'cfg_Head_Form.Label1.Text = "Columns Configuration"

            Dim obj_bg As Object = Cell("Configuration", "")
            'obj_bg.Label1.Text = "Columns Configuration"
            Dim obj As Object = New DAL_Colunm_cfg
            obj.obj = Me
            obj_bg.Set_Cfg(obj)

        End If
    End Sub
    Private Sub R_12_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Dim YYear As FirstWeekOfYear = Date_3.ToString("yyyy")
            Cell("Report Ledger Monthly", "", "Display", VC_ID_, CDate("01-04-" & YYear).ToString("dd-MM-yyyy"), CDate("31-03-" & YYear + 1).ToString("dd-MM-yyyy"), Dft_Voucher, Dft_Branch, CDate(Frm_date).ToString("dd-MM-yyyy"))
        End If
    End Sub
    Private Sub R_22_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Dim obj_bg As Object = Cell("Configuration", "")
            Dim obj As Object = New Repoer_Ledger_cfg
            obj.obj = Me
            obj_bg.Set_Cfg(obj)
        End If
    End Sub
    Private Sub Report_Ledger_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub
    Private Sub Report_Ledger_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.HADE_TXT.Text = "Report Ledger"
        BG_frm.TYP_TXT.Text = VC_Type_

        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text
        Button_Clear()
        Button_Manage()
        cfg_fill()
        Acc_LB.Text = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Name", "ID = '" & VC_ID_ & "'")
        If Update_Report = True Then
            Fill_Grid()
        End If
        Grid1.Focus()
    End Sub
    Public col_cfg As Boolean
    Public Col_BuyerSupplier_Details As Boolean
    Public Col_ConsigneeParty_Details As Boolean
    Public Col_Voucher_Details As Boolean
    Public Col_Supplier_Voucher_Details As Boolean = True
    Public Col_Narration As Boolean = False
    Public Col_GSTValue_Details As Boolean = True
    Public Col_Qty_Details As Boolean = True
    Public Col_Rate_Details As Boolean = True
    Public Col_Amount_Details As Boolean = True
    Public Col_Transport_Name As Boolean = False
    Public Col_Vehical_No As Boolean = False

    Private Function cfg_fill()
        Branch_Name_LB.Text = Dft_Branch
        Voucher_Type_LB.Text = Dft_Voucher
        SortBy_LB.Text = Sorting_Methoud_

        Try
            cfg_print_path = Find_DT_Value(Database_File.lnk, "cfg_Accounting_Report", "Value", "Head = 'Print_Path'")
        Catch ex As Exception
            cfg_print_path = ""
        End Try
        If cfg_print_path = Nothing Then
            cfg_print_path = Application.StartupPath & "\Print_\Report\Account_Book\Account_Book"
        End If

        col_cfg = YN_Boolean(Find_DT_Value(Database_File.lnk, "cfg_Accounting_Report", "Value", "Head = 'Col_Cfg'"))

        If col_cfg = True Then
            Col_BuyerSupplier_Details = YN_Boolean(Find_DT_Value(Database_File.lnk, "cfg_Accounting_Report", "Value", "Head = 'Col_Buyer/Supplier Details'"))

            Col_ConsigneeParty_Details = YN_Boolean(Find_DT_Value(Database_File.lnk, "cfg_Accounting_Report", "Value", "Head = 'Consignee/Party_Details'"))
            Col_Qty_Details = YN_Boolean(Find_DT_Value(Database_File.lnk, "cfg_Accounting_Report", "Value", "Head = 'Col_Quantity_Details'"))
            Col_GSTValue_Details = YN_Boolean(Find_DT_Value(Database_File.lnk, "cfg_Accounting_Report", "Value", "Head = 'Col_GSTValue_Details'"))
            Col_Rate_Details = YN_Boolean(Find_DT_Value(Database_File.lnk, "cfg_Accounting_Report", "Value", "Head = 'Col_Rate_Details'"))
            Col_Amount_Details = YN_Boolean(Find_DT_Value(Database_File.lnk, "cfg_Accounting_Report", "Value", "Head = 'Col_Amount_Details'"))
            Col_Voucher_Details = YN_Boolean(Find_DT_Value(Database_File.lnk, "cfg_Accounting_Report", "Value", "Head = 'Col_Voucher_Details'"), True)
            Col_Supplier_Voucher_Details = YN_Boolean(Find_DT_Value(Database_File.lnk, "cfg_Accounting_Report", "Value", "Head = 'Col_Supplier_Voucher_Details'"))

            Col_Transport_Name = YN_Boolean(Find_DT_Value(Database_File.lnk, "cfg_Accounting_Report", "Value", "Head = 'Col_Transport_Name'"))
            Col_Vehical_No = YN_Boolean(Find_DT_Value(Database_File.lnk, "cfg_Accounting_Report", "Value", "Head = 'Col_Vehicle_Number'"))
        Else
            Col_BuyerSupplier_Details = YN_Boolean(Find_DT_Value(Database_File.lnk, "cfg_Accounting_Report", "Value", "Head = 'Col_Buyer/Supplier Details'"))

            Col_ConsigneeParty_Details = False
            Col_Qty_Details = False
            Col_GSTValue_Details = False
            Col_Rate_Details = False
            Col_Amount_Details = False
            Col_Voucher_Details = True
            Col_Supplier_Voucher_Details = False

            Col_Transport_Name = False
            Col_Vehical_No = False
        End If


        Branch_Panel.Visible = Branch_Visible()
        If Dft_Voucher = "All Vouchers" Or Dft_Voucher = Nothing Then
            Voucher_Type_Panel.Visible = False
        Else
            Voucher_Type_Panel.Visible = True
        End If


    End Function
    Private Sub Report_Ledger_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        Add_Hander_Remove_Handel(False)
        BG_frm.BG_Path_TXT.Text = Path_End
        Frm_foCus()
    End Sub

    Public Cr_Total As Decimal = 0
    Public Dr_Total As Decimal = 0
    Dim dt As New DataTable
    Public Function Filter_Apply()
        Branch_Name_LB.Text = Dft_Branch
        Voucher_Type_LB.Text = Dft_Voucher
        SortBy_LB.Text = Sorting_Methoud_

        Fill_Grid()
    End Function
    Public Function Apply_Date_Filter(ifPeriod As Boolean)
        If ifPeriod = True Then
            Frm_Date_LB.Text = Date_Formate(Date_1)
            To_Date_LB.Text = Date_Formate(Date_2)
        Else
            Frm_Date_LB.Text = Date_Formate(Date_3)
            To_Date_LB.Text = Date_Formate(Date_3)
        End If
        Fill_Grid()
    End Function

    Public Function Fill_Grid()

        'MsgBox(From_ID)

        Grid1.Focus()
        If Grid1.Rows.Count <> 0 Then
            Try
                Defolt_Select_ID = Grid1.CurrentRow.Cells(7).Value.ToString
            Catch ex As Exception

            End Try
        End If

        Acc_LB.Text = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Name", $"ID = '{VC_ID_}'")
        Acc_Under = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Group", $"ID = '{VC_ID_}'")

        Branch_ID = Branch_ID_()


        Cr_Total = 0
        Dr_Total = 0

        dt.Clear()
        dt.Columns.Clear()
        dt.Reset()
        Grid1.Columns.Clear()


        dt = New DataTable
        dt.Columns.Add("Type")
        dt.Columns.Add("Date").DataType = GetType(Date)
        dt.Columns.Add("Particulars")
        dt.Columns.Add("Voucher Type")
        dt.Columns.Add("Voucher No.")
        dt.Columns.Add("Debit")
        dt.Columns.Add("Credit")
        dt.Columns.Add("Tra_ID")
        dt.Columns.Add("VC_Type")
        dt.Columns.Add("VC_Type_ID")
        custome_colunm_details(True)


        Date_Filter = $"Date BETWEEN '{CDate(Frm_date).ToString(Lite_date_Format) }' and '{CDate(to_date).AddDays(1).ToString(Lite_date_Format)}'"
        Date_Filter_OB = $"Date < '{CDate(Frm_date).ToString(Lite_date_Format)}'"


        Fill_oTher_Group(Date_Filter, dt)



        Dim dv As New DataView(dt)
        Dim Dt_set As New DataTable


        'dv.Sort = $"Date {Date_Sorting_code}"
        Dt_set = dv.ToTable


        Source_.DataSource = dv
        Grid1.DataSource = Source_



        Dim chk As New DataGridViewCheckBoxColumn()
        Grid1.Columns.Add(chk)
        Grid1.Columns(dt.Columns.Count).Width = 30
        Grid1.Columns(dt.Columns.Count).Visible = False

        Label6.Text = ""
        Label7.Text = ""
        Closing_Balance()
        BG_Panel.BringToFront()
        Count_ = 0

        With Grid1
            .Columns(0).Visible = False
            .Columns(7).Visible = False
            .Columns(8).Visible = False
            .Columns(9).Visible = False

            .Columns(3).Visible = Col_Voucher_Details
            .Columns(4).Visible = Col_Voucher_Details

            .Columns(1).Width = 100
            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter

            .Columns(2).Width = 300
            '.Columns(2).Frozen = True

            'If col_cfg = True Then
            'Else
            '    .Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            'End If


            .Columns(3).Width = 120
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft

            .Columns(4).Width = 120
            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight

            .Columns(5).Width = 100
            .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight

            .Columns(6).Width = 100
            .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
        End With
        custome_colunm_details(False)

        If Grid1.Rows.Count > 0 Then
            Grid1.CurrentCell = Grid1.Rows(0).Cells(1)
        End If

        Try
            Grid1.CurrentCell = Grid1.Rows(Val(Defolt_Select_ID)).Cells(1)
        Catch ex As Exception

        End Try

        Dim total_h As Integer
        For c As Integer = 0 To Grid1.Columns.Count - 1
            Dim col As DataGridViewColumn = Grid1.Columns(c)
            If col.Visible = True Then
                total_h += col.Width
            End If
        Next

        If total_h <= Grid1.Width Then
            Grid1.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            Grid1.Columns(2).Frozen = True
        End If

        Total_Grid = Grid_Bottom(Panel1, Grid1)
        With Total_Grid.Rows(0)
            .Cells("Particulars").Value = "Grand Total"
            If Total_Unit_YN = True Then
                .Cells("Quantity").Value = N2_FORMATE(Total_Qty)
                .Cells("Unit").Value = (Total_Unit)
            Else
                .Cells("Quantity").Value = ""
                .Cells("Unit").Value = ""
            End If
            .Cells("Debit").Value = N2_FORMATE(Dr_Total)
            .Cells("Credit").Value = N2_FORMATE(Cr_Total)
            .Cells("Voucher No.").Value = $"Tot. Vch. {(Total_vch)}"

        End With
        Grid1.Focus()

        For Each cl As DataGridViewColumn In Grid1.Columns
            Total_Grid.Columns(cl.Index).DisplayIndex = cl.DisplayIndex
        Next
    End Function
    Dim Total_Grid As DataGridView
    Private Function custome_colunm_details(create As Boolean)
        transport_Details_col(create)
        Supplier_Voucher_Details_col(create)
        BuyerSupplier_col_details(create)
        qty_colunm_details(create)
    End Function
    Private Function transport_Details_col(create As Boolean)
        If create = True Then
            dt.Columns.Add("Transport Name")
            dt.Columns.Add("Vehicle Number")
        Else
            With Grid1
                .Columns("Transport Name").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft
                .Columns("Transport Name").Width = 120
                .Columns("Transport Name").DisplayIndex = 3
                .Columns("Transport Name").Visible = Col_Transport_Name

                .Columns("Vehicle Number").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Columns("Vehicle Number").Width = 100
                .Columns("Vehicle Number").DisplayIndex = 4
                .Columns("Vehicle Number").Visible = Col_Vehical_No

            End With
        End If
    End Function
    Private Function Supplier_Voucher_Details_col(create As Boolean)
        If create = True Then
            dt.Columns.Add("Supplier Invoice No")
            dt.Columns.Add("Supplier Invoice Date")
        Else
            With Grid1
                .Columns("Supplier Invoice No").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft
                .Columns("Supplier Invoice No").Width = 100
                .Columns("Supplier Invoice No").DisplayIndex = 3
                .Columns("Supplier Invoice No").Visible = Col_Supplier_Voucher_Details

                .Columns("Supplier Invoice Date").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Columns("Supplier Invoice Date").Width = 100
                .Columns("Supplier Invoice Date").DisplayIndex = 4
                .Columns("Supplier Invoice Date").Visible = Col_Supplier_Voucher_Details

            End With
        End If
    End Function
    Private Function BuyerSupplier_col_details(create As Boolean)
        If create = True Then
            dt.Columns.Add("Buyer/Supplier Name")
            dt.Columns.Add("Buyer/Supplier Address")

            dt.Columns.Add("Consignee/Party Name")
            dt.Columns.Add("Consignee/Party Address")
        Else
            With Grid1
                .Columns("Buyer/Supplier Name").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft
                .Columns("Buyer/Supplier Name").Width = 150
                .Columns("Buyer/Supplier Name").DisplayIndex = 3
                .Columns("Buyer/Supplier Name").Visible = Col_BuyerSupplier_Details

                .Columns("Buyer/Supplier Address").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft
                .Columns("Buyer/Supplier Address").Width = 200
                .Columns("Buyer/Supplier Address").DisplayIndex = 4
                .Columns("Buyer/Supplier Address").Visible = Col_BuyerSupplier_Details


                .Columns("Consignee/Party Name").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft
                .Columns("Consignee/Party Name").Width = 150
                .Columns("Consignee/Party Name").DisplayIndex = 5
                .Columns("Consignee/Party Name").Visible = Col_ConsigneeParty_Details

                .Columns("Consignee/Party Address").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft
                .Columns("Consignee/Party Address").Width = 200
                .Columns("Consignee/Party Address").DisplayIndex = 6
                .Columns("Consignee/Party Address").Visible = Col_ConsigneeParty_Details

            End With
        End If
    End Function
    Private Function qty_colunm_details(create As Boolean)
        If create = True Then
            dt.Columns.Add("Quantity")
            dt.Columns.Add("Unit")
            dt.Columns.Add("Rate")
            dt.Columns.Add("GST %")
            dt.Columns.Add("GST ₹")
            dt.Columns.Add("Net Amount")
            dt.Columns.Add("Gross Total")
        Else
            With Grid1
                .Columns("Quantity").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
                .Columns("Quantity").Width = 80
                .Columns("Quantity").DisplayIndex = 3
                .Columns("Quantity").Visible = Col_Qty_Details

                .Columns("Unit").HeaderText = ""
                .Columns("Unit").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft
                .Columns("Unit").Width = 50
                .Columns("Unit").DisplayIndex = 4
                .Columns("Unit").Visible = Col_Qty_Details

                .Columns("Rate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
                .Columns("Rate").Width = 70
                .Columns("Rate").DisplayIndex = 5
                .Columns("Rate").Visible = Col_Rate_Details

                .Columns("Gross Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
                .Columns("Gross Total").Width = 100
                .Columns("Gross Total").DisplayIndex = 6
                .Columns("Gross Total").Visible = Col_Amount_Details

                .Columns("GST %").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
                .Columns("GST %").Width = 60
                .Columns("GST %").DisplayIndex = 7
                .Columns("GST %").Visible = Col_GSTValue_Details

                .Columns("GST ₹").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
                .Columns("GST ₹").Width = 80
                .Columns("GST ₹").DisplayIndex = 8
                .Columns("GST ₹").Visible = Col_GSTValue_Details

                .Columns("Net Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
                .Columns("Net Amount").Width = 100
                .Columns("Net Amount").DisplayIndex = 9
                If Col_GSTValue_Details = True And Col_Amount_Details = True Then
                    .Columns("Net Amount").Visible = True
                Else
                    .Columns("Net Amount").Visible = False
                End If

            End With
        End If
    End Function
    Private Function Qry_Filters() As String
        Dim q As String

        q &= $" and (vc.Effect_Ledger = 'Yes')"
        q &= $"and (Date BETWEEN '{CDate(Frm_date).ToString(Lite_date_Format)}' and '{CDate(to_date).AddDays(1).ToString(Lite_date_Format)}')"

        If Dft_Voucher <> "All Vouchers" Then
            q &= $" AND Voucher_Type = '{Dft_Voucher}'"
        End If
        If Branch_ID <> 0 Then
            q &= " AND VC.Branch = '" & Branch_ID & "'"
        End If
        If Delete_Entry = True Then
            q &= " AND ((VC.Visible = 'Approval') or (VC.Visible = 'Delete'))"
        Else
            q &= " AND (VC.Visible <> 'Delete')"
        End If

        Return q
    End Function
    Private Function Qry_set() As String


        Dim date_filter As String = $" and vc.Date BETWEEN '{CDate(Frm_date).ToString(Lite_date_Format) }' and '{CDate(to_date).AddDays(1).ToString(Lite_date_Format)}'"


        Dim s1 As String = ""
        Dim s2 As String = ""

        Dim qty_1 As String = ""
        Dim qty_2 As String = ""
        Dim qty_3 As String = ""
        Dim qty_4 As String = ""

        Dim naration1 As String = ""
        Dim naration2 As String = ""
        Dim naration3 As String = ""
        Dim naration4 As String = ""

        Dim supplayer_n1 As String = ""
        Dim supplayer_n2 As String = ""
        Dim supplayer_n3 As String = ""
        Dim supplayer_n4 As String = ""

        Dim gst_P1 As String = ""
        Dim gst_P2 As String = ""
        Dim gst_P3 As String = ""
        Dim gst_P4 As String = ""

        Dim Transport_Name1 As String = ""
        Dim Transport_Name2 As String = ""
        Dim Transport_Name3 As String = ""
        Dim Transport_Name4 As String = ""

        Dim Vihical_No1 As String = ""
        Dim Vihical_No2 As String = ""
        Dim Vihical_No3 As String = ""
        Dim Vihical_No4 As String = ""

        If Col_Vehical_No = True Then
            Vihical_No1 = "vo.Vihical_No as Vihical_No,"
            Vihical_No2 = "'' as Vihical_No,"
            Vihical_No3 = "'' as Vihical_No,"
            Vihical_No4 = "'' as Vihical_No,"
        Else
            Vihical_No1 = "'' as Vihical_No,"
            Vihical_No2 = "'' as Vihical_No,"
            Vihical_No3 = "'' as Vihical_No,"
            Vihical_No4 = "'' as Vihical_No,"
        End If

        If Col_Transport_Name = True Then
            Transport_Name1 = "vo.Transportation_Name as Transport_Name,"
            Transport_Name2 = "'' as Transport_Name,"
            Transport_Name3 = "'' as Transport_Name,"
            Transport_Name4 = "'' as Transport_Name,"
        Else
            Transport_Name1 = "'' as Transport_Name,"
            Transport_Name2 = "'' as Transport_Name,"
            Transport_Name3 = "'' as Transport_Name,"
            Transport_Name4 = "'' as Transport_Name,"
        End If


        Dim Branch_Filter As String = ""
        If Dft_Branch <> "Primary" Then
            Branch_Filter = " AND VC.Branch = '" & Find_DT_Value(Database_File.cre, "TBL_Ledger", "ID", "Name = '" & Dft_Branch & "'") & "'"
        End If

        Dim Voucher_Type_Filter As String = ""
        If Dft_Voucher = "All Vouchers" Or Dft_Voucher = Nothing Then
        Else
            Voucher_Type_Filter = $" and (vc.Voucher_Type = '{Dft_Voucher}')"
        End If

        If Col_Narration = True Then
            naration1 = "vc.Narration,"
            naration2 = "'' as Narration,"
            naration3 = "'' as Narration,"
            naration4 = "'' as Narration,"
        Else
            naration1 = "'' as Narration,"
            naration2 = "'' as Narration,"
            naration3 = "'' as Narration,"
            naration4 = "'' as Narration,"
        End If

        If Col_BuyerSupplier_Details = True Then
            supplayer_n1 = "(Select vo.To_Name From TBL_VC_Other vo where vo.Tra_ID = vc.Tra_ID) as Supplier_Name,
(Select vo.To_Address1 From TBL_VC_Other vo where vo.Tra_ID = vc.Tra_ID) as Supplier_Address,
(Select vo.Ship_Mailing_Name From TBL_VC_Other vo where vo.Tra_ID = vc.Tra_ID) as Consignee_Name,
(Select vo.Ship_Address From TBL_VC_Other vo where vo.Tra_ID = vc.Tra_ID) as Consignee_Address,"
            supplayer_n2 = "'' as Supplier_Name,
'' as Supplier_Address,'' as Consignee_Name,
'' as Consignee_Address,"
            supplayer_n3 = "'' as Supplier_Name,
'' as Supplier_Address,'' as Consignee_Name,
'' as Consignee_Address,"
            supplayer_n4 = "'' as Supplier_Name,
'' as Supplier_Address,'' as Consignee_Name,
'' as Consignee_Address,"
        Else
            supplayer_n1 = "'' as Supplier_Name,
'' as Supplier_Address,'' as Consignee_Name,
'' as Consignee_Address,"
            supplayer_n2 = "'' as Supplier_Name,
'' as Supplier_Address,'' as Consignee_Name,
'' as Consignee_Address,"
            supplayer_n3 = "'' as Supplier_Name,
'' as Supplier_Address,'' as Consignee_Name,
'' as Consignee_Address,"
            supplayer_n4 = "'' as Supplier_Name,
'' as Supplier_Address,'' as Consignee_Name,
'' as Consignee_Address,"
        End If


        If Col_GSTValue_Details = True Then
            gst_P1 = "vi.GST_per as GST_P,"
            gst_P2 = "vi.GST_per as GST_P,"
            gst_P3 = "'' as GST_P,"
            gst_P4 = "'' as GST_P,"
        Else
            gst_P1 = "'' as GST_P,"
            gst_P2 = "'' as GST_P,"
            gst_P3 = "'' as GST_P,"
            gst_P4 = "'' as GST_P,"
        End If

        If Col_Qty_Details = True Then
            qty_1 = "SUM(vi.Qty) as Qty,
(CASE WHEN (Select SUM(c) From((Select count(vii.id) as c From TBL_VC_item_Details vii LEFT JOIN TBL_Stock_Item itm on itm.id = vii.Item where vii.Tra_ID = vl.Tra_ID Group By itm.Unit))) = 1
THEN (Select un.Symbol From TBL_Inventory_Unit un where un.id = (Select itm.Unit From TBL_Stock_Item itm where itm.id = vi.Item))
ELSE ''
END) as Unit,
(SUM(vi.Amount)/SUM(vi.Qty)) as Rate,
SUM(vi.Amount) as SubTotal,"

            qty_2 = "vi.Qty as Qty,
u.Symbol as Unit,
vi.Rate as Rate,
vi.Amount as SubTotal,"
            qty_3 = "'' as Qty,
	   '' as Unit,
	   '' as Rate,
	   '' as SubTotal,"
            qty_4 = "'' as Qty,
	   '' as Unit,
	   '' as Rate,
	   '' as SubTotal,"
        Else
            qty_1 = "'' as Qty,
	   '' as Unit,
	   '' as Rate,
	   '' as SubTotal,"
            qty_2 = "'' as Qty,
	   '' as Unit,
	   '' as Rate,
	   '' as SubTotal,"
            qty_3 = "'' as Qty,
	   '' as Unit,
	   '' as Rate,
	   '' as SubTotal,"
            qty_4 = "'' as Qty,
	   '' as Unit,
	   '' as Rate,
	   '' as SubTotal,"
        End If





        s1 = $"Select 'Head' as Type,
(Select l.Name From TBL_Ledger l where l.ID = (Select vl1.Ledger From TBL_VC_Ledger vl1 where vl1.Tra_ID = vl.Tra_ID and vl1.Ledger <> vl.Ledger limit 1)) as Ledger_Name,
(Select l.Name From TBL_Stock_Item l where l.ID = vi.Item) as Item_Name,
(Select l.Name From TBL_Payroll_Employee l where l.ID = vc.Employee) as Employee_Name,
(Select e.Name From TBL_Payhead e where e.ID = vc.Payhead) as Payhead,
vc.Tra_ID,
vc.[date],
vc.Voucher_No,
vc.Voucher_Type,
c.Name as Voucher_Name,
vc.Voucher_Type_ID,
{qty_1}
{naration1}
{supplayer_n1}
{gst_P1}
{Transport_Name1}
{Vihical_No1}
SUM(vi.CGST) as CGST,
SUM(vi.SGST) as SGST,
SUM(vi.IGST) as IGST,
SUM(ifnull(vi.Amount,0))+SUM(ifnull(vi.CGST,0))+SUM(ifnull(vi.SGST,0))+SUM(ifnull(vi.IGST,0)) as NET,
(Select SUM(ifnull(l.Cr,0)) From TBL_VC_Ledger l where l.Tra_ID = vl.Tra_ID and l.Ledger = vl.Ledger) as Credit_Amount,
(Select SUM(ifnull(l.Dr,0)) From TBL_VC_Ledger l where l.Tra_ID = vl.Tra_ID and l.Ledger = vl.Ledger) Debit_Amount

From TBL_VC_Ledger vl
Left Join TBL_VC vc on vc.Tra_ID = vl.Tra_ID
Left Join TBL_VC_item_Details vi on vi.Tra_ID = vl.Tra_ID
LEFT JOIN TBL_Voucher_Create c on c.ID = vc.Voucher_Type_ID
LEFT JOIN TBL_VC_Other vo on vo.Tra_ID = vc.Tra_ID
where vl.Ledger = '{VC_ID_}' and vc.Visible = 'Approval' {Branch_Filter}{Voucher_Type_Filter}{date_filter}
Group by vc.Tra_ID
"
        If YN_Details = True Then

            s2 = $"

UNION ALL

Select 'Under' as Type,
'' as Ledger_Name,
it.name as Item_Name,
'' as Employee_Name,
'' as Payhead,
vc.Tra_ID,
vc.[date],
'' as Voucher_No,
'' as Voucher_Type,
'' as Voucher_Name,
vc.Voucher_Type_ID,
{qty_2}
{naration2}
{supplayer_n2}
{gst_P2}
{Transport_Name2}
{Vihical_No2}
vi.CGST as CGST,
vi.SGST as SGST,
vi.IGST as IGST,
ifnull(vi.Amount,0)+ifnull(vi.CGST,0)+ifnull(vi.SGST,0)+ifnull(vi.IGST,0) as NET,
'' as Credit_Amount,
'' as Debit_Amount

From TBL_VC_item_Details vi
LEFT JOIN TBL_VC vc on vc.Tra_ID = vi.Tra_ID
LEFT JOIN TBL_Stock_Item it on it.ID = vi.Item
LEFT JOIN TBL_Inventory_Unit u on u.ID = it.Unit
where vc.Ledger = '{VC_ID_}' and vc.Visible = 'Approval' {Branch_Filter}{Voucher_Type_Filter}{date_filter}





UNION ALL






Select 'Under' as Type,
(Select ld.Name From TBL_Ledger ld where ld.id = vc.Ledger) as Ledger_Name,
'' as Item_Name,
'' as Employee_Name,
'' as Payhead,
vc.Tra_ID,
vc.[date],
'' as Voucher_No,
'' as Voucher_Type,
'' as Voucher_Name,
'' as Voucher_Type_ID,
	   	   {qty_3}
       {naration3}
       {supplayer_n3}
       {gst_P3}
       {Transport_Name3}
       {Vihical_No3}
	   '' as CGST,
	'' as SGST,
	'' as IGST,
	'' as NET,
(vc.Cr) as Credit_Amount,
(vc.Dr) as Debit_Amount

From TBL_VC_Ledger vc
LEFT JOIN TBL_VC_Ledger vvcc on vvcc.Ledger = '{VC_ID_}' 

where vc.Tra_ID = vvcc.Tra_ID and vc.Ledger <> '{VC_ID_}' and (vc.Type = 'Under' or vc.Type = 'Exp' or vc.Type = 'Head') {Branch_Filter}{Voucher_Type_Filter}{date_filter}




UNION ALL





Select 'Under' as Type,
'' as Ledger_Name,
'' as Item_Name,
(Select e.Name From TBL_Payroll_Employee e where e.ID = vp.Employee) as Employee_Name,
(Select e.Name From TBL_Payhead e where e.ID = vp.Payhead) as Payhead,
vc.Tra_ID,
vc.[date],
'' as Voucher_No,
'' as Voucher_Type,
'' as Voucher_Name,
'' as Voucher_Type_ID,
{qty_4}
{naration4}
{supplayer_n4}
{gst_P4}
{Transport_Name4}
{Vihical_No4}
'' as CGST,
'' as SGST,
'' as IGST,
'' as NET,
(vp.Cr) as Credit_Amount,
(vp.Dr) as Debit_Amount

From TBL_VC_Payroll vp
LEFT JOIN TBL_VC vc on vc.Tra_ID = vp.Tra_ID
LEFT JOIN TBL_VC_Ledger vl on vl.Tra_ID = vp.Tra_ID
where vl.Ledger = '{VC_ID_}' {Branch_Filter}{Voucher_Type_Filter}{date_filter}
"

        End If
        Return s1 & s2
    End Function
    Public Total_Unit_YN As Boolean = True
    Public Total_Unit As String
    Public Total_Qty As String
    Dim Total_vch As Integer

    Private Function Fill_oTher_Group(Date_Filter As String, dt As DataTable)


        dt_print.Rows.Clear()
        dt_print = ds_print.Tables("TBL_DayBook")

        Total_Qty = 0
        Total_vch = 0

        Dim Date_Sort As String = ""

        If Sorting_Methoud_ = "Date (Decreasing)" Then
            Date_Sort = "DESC"
        End If

        Dim cn As New SQLiteConnection
        Dim dr As DataRow
        Dim dr_Print As DataRow
        If open_MSSQL(Database_File.cre) = True Then
            cmd = New SQLiteCommand($"Select * From ({Qry_set()})
ORDER by [Date] {Date_Sort},Tra_ID", con)
            Dim r As SQLiteDataReader
            'My.Computer.Clipboard.SetText(cmd.CommandText)
            r = cmd.ExecuteReader
            Dim Unit_SUM As String = "Head"
            Dim vc_tp As String = ""
            While r.Read
                'MsgBox(r("Tra_ID").ToString)

                Dim Particuls As String
                Dim Date_ As Date = CDate(r("Date").ToString)
                Dim Type_ As String = r("Type").ToString
                Dim TRA_ID As String = r("Tra_ID").ToString
                Dim vc_Name As String = r("Voucher_Name").ToString
                Dim vc_No As String = r("Voucher_NO").ToString

                Dim qty As String = r("Qty").ToString
                Dim rate As String = r("Rate").ToString
                Dim Unit As String = r("Unit").ToString
                Dim subtotal As String = r("SubTotal").ToString

                Dim Dr_ As Decimal = Val(r("Debit_Amount").ToString)
                Dim Cr_ As Decimal = Val(r("Credit_Amount").ToString)



                Dim narration_str As String = ""
                Dim transport_Name As String = r("Transport_Name").ToString
                Dim Vihical_No As String = r("Vihical_No").ToString

                If r("Voucher_Type").ToString <> Nothing Then
                    vc_tp = r("Voucher_Type").ToString
                End If

                If Col_Narration = True Then
                    narration_str = r("Narration").ToString
                End If

                If vc_tp = "Inward Register" Or vc_tp = "Outward Register" Or vc_tp = "Sales Order" Or vc_tp = "Purchase Order" Then
                    Dr_ = 0
                    Cr_ = 0
                End If

                If Type_ = "Head" Then
                    If Unit_SUM = "Head" Then
                        If r("Unit").ToString <> Nothing Then
                            Unit_SUM = r("Unit")
                            Total_Unit = r("Unit")
                        End If
                    Else
                        If Unit_SUM <> r("Unit").ToString Then
                            If Val(qty) <> 0 Then
                                Total_Unit_YN = False
                                Total_Unit = ""
                            End If
                        End If
                    End If
                End If

                If Type_ = "Head" Then
                    If Unit = Nothing Then
                        qty = ""
                        Unit = ""
                    End If
                    Total_Qty = Val(Total_Qty) + Val(qty)
                    Total_vch += 1
                Else
                End If

                If r("Item_Name").ToString <> Nothing Then
                    Particuls = r("Item_Name").ToString
                ElseIf r("Ledger_Name").ToString <> Nothing Then
                    Particuls = r("Ledger_Name").ToString
                Else
                    'Particuls = r("Employee_Name").ToString
                End If
                If vc_tp = "Payroll" Then
                    Particuls = $"{r("Employee_Name").ToString} -> {r("Payhead").ToString}"
                End If


                If Type_ = "Head" And YN_Details = True Then
                    Particuls = "(as per details)"
                ElseIf Type_ <> "Head" Then

                End If


                If Particuls <> Acc_LB.Text Then

                    If Type_ <> "Head" Then
                        If Val(Dr_) <> 0 Then
                            Particuls = $"{Particuls}  - [{N2_FORMATE(Dr_)} {Negative_Value_fech}]"
                            Dr_ = 0
                        ElseIf Val(Cr_) <> 0 Then
                            Particuls = $"{Particuls}  - [{N2_FORMATE(Cr_)} {Positive_Value_fech}]"
                            Cr_ = 0
                        End If
                    End If

                    dr = dt.NewRow
                    dr("Type") = Type_
                    dr("Tra_ID") = TRA_ID
                    dr("Date") = Date_
                    dr("Particulars") = Particuls
                    dr("Voucher Type") = vc_Name
                    dr("Voucher No.") = vc_No
                    dr("Debit") = N2_FORMATE(Dr_)
                    dr("Credit") = N2_FORMATE(Cr_)
                    dr("VC_Type") = vc_tp
                    dr("VC_Type_ID") = r("Voucher_Type_ID")

                    dr("Buyer/Supplier Name") = r("Supplier_Name").ToString
                    dr("Buyer/Supplier Address") = r("Supplier_Address").ToString

                    dr("Consignee/Party Name") = r("Consignee_Name").ToString
                    dr("Consignee/Party Address") = r("Consignee_Address").ToString

                    dr("Quantity") = N2_FORMATE(qty)
                    If Val(qty) = 0 Then
                        dr("Unit") = ""
                        dr("Rate") = ""
                        dr("GST %") = ""
                    Else
                        dr("Unit") = Unit
                        dr("Rate") = N2_FORMATE(rate)
                        dr("GST %") = N2_FORMATE(r("GST_P").ToString) & "%"
                    End If
                    dr("Gross Total") = N2_FORMATE(subtotal)
                    dr("GST ₹") = N2_FORMATE(Val(r("CGST").ToString) + Val(r("SGST").ToString) + Val(r("IGST").ToString))
                    dr("Net Amount") = N2_FORMATE(r("NET").ToString)

                    dr("Transport Name") = transport_Name
                    dr("Vehicle Number") = Vihical_No



                    If Type_ = "Head" Then
                        Dr_Total += Dr_
                        Cr_Total += Cr_
                    End If
                    dt.Rows.Add(dr)

                    If Col_Narration = True Then
                        If Type_ = "Head" Then
                            If narration_str <> Nothing Then
                                dr = dt.NewRow
                                dr("Date") = CDate(r("Date").ToString)
                                dr("Type") = "Narration"
                                dr("Tra_ID") = TRA_ID
                                dr("Particulars") = narration_str
                                dt.Rows.Add(dr)
                            End If
                        End If
                    End If

                    'Print Data
                    dr_Print = dt_print.NewRow
                    dr_Print("Type") = Type_
                    If Type_ = "Head" Then
                        dr_Print("Date") = Date_Formate(Date_)
                        dr_Print("Particulars") = Particuls
                        dr_Print("Voucher_Type") = vc_Name
                        dr_Print("Voucher_No") = vc_No
                        dr_Print("Debit") = nUmBeR_FORMATE(Dr_)
                        dr_Print("Credit") = nUmBeR_FORMATE(Cr_)
                        dr_Print("Qty") = nUmBeR_FORMATE(qty)
                        dr_Print("Unit") = Unit
                        dr_Print("Rate") = nUmBeR_FORMATE(rate)
                        dr_Print("Gross_Total") = nUmBeR_FORMATE(subtotal)
                        dr_Print("Vehicle_Number") = Vihical_No
                        If narration_str <> Nothing Then
                            dr_Print("Narration") = vbNewLine & narration_str
                        End If
                    Else
                        dr_Print("Date") = ""
                        dr_Print("Particulars") = ""
                        dr_Print("Under") = "     " & Particuls
                        dr_Print("Voucher_Type") = ""
                        dr_Print("Voucher_No") = ""
                        dr_Print("Debit") = nUmBeR_FORMATE(Dr_)
                        dr_Print("Credit") = nUmBeR_FORMATE(Cr_)
                        dr_Print("Qty") = nUmBeR_FORMATE(qty)
                        dr_Print("Unit") = Unit
                        dr_Print("Rate") = nUmBeR_FORMATE(rate)
                        dr_Print("Gross_Total") = nUmBeR_FORMATE(subtotal)
                    End If
                    dt_print.Rows.Add(dr_Print)
                End If

                If Defolt_Select_ID = TRA_ID Then
                    Defolt_Select_ID = dt.Rows.Count - 1
                End If

            End While
            r.Close()
        End If
    End Function

    Private Function Closing_Balance()
        Label10.Text = ""

        Label6.Text = ""
        Label7.Text = ""

        Dim SubTO As Decimal = 0

        SubTO = Ledger_Balance(VC_ID_, CDate(Frm_date).AddDays(-1), "0", Branch_ID)

        If Opning_Balance_YN = True Then
            If SubTO < 0 Then
                Label7.Text = ""
                Label6.Text = Format(Val(Val(SubTO) * -1), "0.00")
            ElseIf SubTO > 0 Then
                Label7.Text = Format(Val(Val(SubTO)), "0.00")
                Label6.Text = ""
            End If
        End If

        SubTO = ((Val(Label6.Text) + Val(Dr_Total)) - (Val(Label7.Text) + Val(Cr_Total)))

        If SubTO < 0 Then
            Label10.Text = $"{N2_FORMATE(Val(SubTO) * -1)} {Positive_Value_fech}"
        ElseIf SubTO > 0 Then
            Label10.Text = $"{N2_FORMATE(Val(SubTO) * 1)} {Negative_Value_fech}"
        End If
    End Function
    Private Function Group() As String
        Dim Type_of_Duty As String = Find_DT_Value(Database_File.cre, "TBL_Ledger", "TypeOfDuty", "ID = '" & VC_ID_ & "'")
        Dim TAX_per As String = (Find_DT_Value(Database_File.cre, "TBL_TAX", "Under", "ID = '" & Type_of_Duty & "'"))

        If Acc_Under = "10" Then
            Return "Sales"
        ElseIf Acc_Under = "11" Then
            Return "Purchase"
        ElseIf Acc_Under = "20" Then
            If TAX_per = "INPUT" Then
                Return "Purchase"
            Else
                Return "Sales"
            End If
        Else
            Return "All"
        End If
    End Function

    Private Sub Grid1_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles Grid1.RowsAdded
        'Grid1.Rows(Grid1.Rows.Count - 1).Height = 18
    End Sub

    Private Sub Grid1_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid1.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            BG_frm.B_1.PerformClick()
        End If
    End Sub

    Private Sub Frm_Date_LB_TextChanged(sender As Object, e As EventArgs) Handles Frm_Date_LB.TextChanged
        Frm_date = Date_Formate(Frm_Date_LB.Text)
    End Sub
    Private Sub To_Date_LB_TextChanged(sender As Object, e As EventArgs) Handles To_Date_LB.TextChanged
        to_date = Date_Formate(To_Date_LB.Text)
    End Sub
    Dim Md As Moad
    Private Enum Moad
        Full_
        Short_
    End Enum
    Private Sub Grid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid1.CellContentClick

    End Sub

    Private Sub Report_Ledger_frm_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate

    End Sub

    Private Sub Grid1_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles Grid1.RowPrePaint
        Dim ro As DataGridViewRow = Grid1.Rows(e.RowIndex)
        ro.Cells("Quantity").Style.Padding = New Padding(0, 0, 0, 0)
        ro.Cells("Unit").Style.Padding = New Padding(0, 0, 0, 0)

        If ro.Cells(0).Value = "Head" Then
            Dim c As Integer = Grid1.Columns.Count - 1
            If ro.Cells(c).Value = True Then
                ro.DefaultCellStyle.BackColor = Color_SELECT_back
                ro.DefaultCellStyle.ForeColor = Color_SELECT_fonr
            Else
                ro.DefaultCellStyle.BackColor = Color.White
                ro.DefaultCellStyle.SelectionBackColor = Color.FromArgb(254, 197, 48)
            End If
        ElseIf ro.Cells(0).Value = "Under" Then
            ro.Cells(1).Style.WrapMode = DataGridViewTriState.True

            If ro.Cells(Grid1.ColumnCount - 1).Value <> "Delete" Then
                ro.DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64)
            End If

            ro.DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Regular)
            ro.Cells(2).Style.Padding = New Padding(40, 0, 0, 0)
            ro.Cells(1).Style.SelectionBackColor = Color.White
            ro.Cells(1).Style.ForeColor = Color.White
            ro.Cells(1).Style.SelectionForeColor = Color.White

        ElseIf ro.Cells(0).Value = "Narration" Then
            Grid1.DefaultCellStyle.WrapMode = DataGridViewTriState.True
            Grid1.AutoResizeRow(e.RowIndex)

            ro.DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Italic)
            ro.Cells(1).Style.SelectionBackColor = Color.White
            ro.Cells(1).Style.ForeColor = Color.White
            ro.Cells(1).Style.SelectionForeColor = Color.White
            ro.Cells(2).Style.Padding = New Padding(20, 0, 0, 0)
        ElseIf ro.Cells(0).Value = "Total" Then
            ro.Cells(1).Style.ForeColor = Color.BurlyWood
            ro.Cells(1).Style.SelectionForeColor = Color.BurlyWood
            ro.DefaultCellStyle.SelectionBackColor = Color.BurlyWood
            ro.DefaultCellStyle.BackColor = Color.BurlyWood
        End If

    End Sub
    Public Sub DrawLinePoint(ByVal e As PaintEventArgs)
        If Grid1.Rows.Count <> 0 Then
            Dim blackPen As New Pen(Color.Gray, 1)

            Dim ctlpos As Point = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(1, 0, False).Location)
            Dim point1 As New Point(ctlpos.X, 0)
            Dim point2 As New Point(ctlpos.X, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)

            ctlpos = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(2, 0, False).Location)
            point1 = New Point(ctlpos.X, 0)
            point2 = New Point(ctlpos.X, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)

            ctlpos = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(3, 0, False).Location)
            point1 = New Point(ctlpos.X, 0)
            point2 = New Point(ctlpos.X, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)

            ctlpos = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(4, 0, False).Location)
            point1 = New Point(ctlpos.X, 0)
            point2 = New Point(ctlpos.X, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)

            ctlpos = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(5, 0, False).Location)
            point1 = New Point(ctlpos.X, 0)
            point2 = New Point(ctlpos.X, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)

            ctlpos = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(6, 0, False).Location)
            point1 = New Point(ctlpos.X, 0)
            point2 = New Point(ctlpos.X, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)

            ctlpos = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(7, 0, False).Location)
            point1 = New Point(ctlpos.X, 0)
            point2 = New Point(ctlpos.X, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)

            ctlpos = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(8, 0, False).Location)
            point1 = New Point(ctlpos.X, 0)
            point2 = New Point(ctlpos.X, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)

            ctlpos = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(9, 0, False).Location)
            point1 = New Point(ctlpos.X, 0)
            point2 = New Point(ctlpos.X, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)

            ctlpos = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(10, 0, False).Location)
            point1 = New Point(ctlpos.X, 0)
            point2 = New Point(ctlpos.X, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)

            ctlpos = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(11, 0, False).Location)
            point1 = New Point(ctlpos.X, 0)
            point2 = New Point(ctlpos.X, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)

            ctlpos = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(12, 0, False).Location)
            point1 = New Point(ctlpos.X, 0)
            point2 = New Point(ctlpos.X, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)

            ctlpos = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(13, 0, False).Location)
            point1 = New Point(ctlpos.X, 0)
            point2 = New Point(ctlpos.X, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)

            ctlpos = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(14, 0, False).Location)
            point1 = New Point(ctlpos.X, 0)
            point2 = New Point(ctlpos.X, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)

            ctlpos = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(15, 0, False).Location)
            point1 = New Point(ctlpos.X, 0)
            point2 = New Point(ctlpos.X, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)

            ctlpos = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(16, 0, False).Location)
            point1 = New Point(ctlpos.X, 0)
            point2 = New Point(ctlpos.X, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)

            ctlpos = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(17, 0, False).Location)
            point1 = New Point(ctlpos.X, 0)
            point2 = New Point(ctlpos.X, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)

            ctlpos = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(18, 0, False).Location)
            point1 = New Point(ctlpos.X, 0)
            point2 = New Point(ctlpos.X, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)

            ctlpos = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(19, 0, False).Location)
            point1 = New Point(ctlpos.X, 0)
            point2 = New Point(ctlpos.X, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)

            ctlpos = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(20, 0, False).Location)
            point1 = New Point(ctlpos.X, 0)
            point2 = New Point(ctlpos.X, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)

            ctlpos = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(21, 0, False).Location)
            point1 = New Point(ctlpos.X, 0)
            point2 = New Point(ctlpos.X, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)

            ctlpos = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(22, 0, False).Location)
            point1 = New Point(ctlpos.X, 0)
            point2 = New Point(ctlpos.X, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)

            ctlpos = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(23, 0, False).Location)
            point1 = New Point(ctlpos.X, 0)
            point2 = New Point(ctlpos.X, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)

            ctlpos = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(24, 0, False).Location)
            point1 = New Point(ctlpos.X, 0)
            point2 = New Point(ctlpos.X, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)




            point1 = New Point(0, 20)
            point2 = New Point(Grid1.Width, 20)
            e.Graphics.DrawLine(blackPen, point1, point2)

            point1 = New Point(0, 0)
            point2 = New Point(Grid1.Width, 0)
            e.Graphics.DrawLine(blackPen, point1, point2)
        End If
    End Sub
    Private Sub Grid1_Paint(sender As Object, e As PaintEventArgs) Handles Grid1.Paint
        DrawLinePoint(e)
    End Sub
    Private Sub Report_Ledger_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
        Grid1.Focus()
    End Sub

    Private Sub Report_Ledger_frm_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        Try
            'Defolt_Select_ID = Grid1.CurrentRow.Cells(7).Value.ToString
        Catch ex As Exception

        End Try
    End Sub
    Public Function Create_Database_Table()
        Dim cn As New SQLiteConnection
        Dim create_ As Boolean = False
        If open_MSSQL_Cstm(Database_File.lnk, cn) = True Then
            cmd = New SQLiteCommand("SELECT count(*) as c FROM sqlite_master WHERE type='table' AND name='cfg_Accounting_Report'", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                If r("c") <> 1 Then
                    create_ = True
                End If
            End While
            r.Close()


            If create_ = True Then
                cmd = New SQLiteCommand("CREATE TABLE 'cfg_Accounting_Report' (
	'Id'	INTEGER NOT NULL UNIQUE,
	'Head'	TEXT,
	'Value'	TEXT,
	PRIMARY KEY('Id' AUTOINCREMENT));", cn)

                cmd.ExecuteNonQuery()
            End If
        End If
    End Function

    Private Sub Acc_LB_Click(sender As Object, e As EventArgs) Handles Acc_LB.Click

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        For Each cl As DataGridViewColumn In Grid1.Columns
            Total_Grid.Columns(cl.Index).DisplayIndex = cl.DisplayIndex
        Next
    End Sub

    Private Sub Load_Panel_Paint(sender As Object, e As PaintEventArgs) Handles Load_Panel.Paint
        obj_center(Load_Panel, Me)
    End Sub
End Class