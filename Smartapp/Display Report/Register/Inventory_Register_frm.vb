Imports System.Data.SQLite
Imports Microsoft.Reporting.WinForms
Imports PopupControl
Public Class Inventory_Register_frm
    Dim From_ID As String
    Private VC_Type_ As String
    Private VC_ID_ As String
    Private RG_Yype_ As String
    Private Path_End As String
    Dim YN_Details As Boolean
    Dim Acc_Under As String
    Dim Frm_date As Date
    Dim to_date As Date
    Dim Count_ As Integer

    Dim ds_print As New Print_dt
    Dim dt_print As New DataTable

    Dim Branch_ID As String = 0
    Public it_id As Integer = 0
    Public it_name As String = ""

    Public ld_id As Integer = 0
    Public ld_name As String = ""

    Private Sub Report_Sales_Purchase_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text

        RG_Yype_ = Link_Valu(0)
        VC_Type_ = Link_Valu(1)
        VC_ID_ = Link_Valu(2)
        Frm_Date_LB.Text = Link_Valu(3)
        To_Date_LB.Text = Link_Valu(4)

        Acc_LB.Text = RG_Yype_ & " Register"
        BG_frm.HADE_TXT.Text = "Inventory Register"
        BG_frm.TYP_TXT.Text = VC_Type_
        Button_Manage()
        Add_Hander_Remove_Handel(True)

        fill_Data()
        List_Fill()

        Panel_manag(BG_Panel)
    End Sub
    Private Function Button_Manage()
        Button_Clear()
        BG_frm.B_1.Text = "Enter : Alter"
        BG_frm.B_2.Text = "|&D : Delete"
        BG_frm.B_3.Text = "|&R : Refresh"
        BG_frm.B_4.Text = "|&2 : Duplicate"
        BG_frm.B_5.Text = "|&A : Add Voucher"
        BG_frm.B_6.Text = "|&P : Print"
        BG_frm.B_7.Text = "||Space : Select All"

        BG_frm.R_1.Text = "|F1 : Detailed"
        BG_frm.R_2.Text = "F2 : Date"
        BG_frm.R_3.Text = "|F2 : Period"
        BG_frm.R_4.Text = ""
        If Branch_Visible() = True Then
            BG_frm.R_5.Text = "F4 : Branch"
        End If
        BG_frm.R_6.Text = "F5 : Item"
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

            AddHandler BG_frm.R_1.Click, AddressOf Me.R_1_Click
            AddHandler BG_frm.R_2.Click, AddressOf Me.R_3_Click
            AddHandler BG_frm.R_3.Click, AddressOf Me.R_4_Click
            AddHandler BG_frm.R_4.Click, AddressOf Me.R_6_Click
            AddHandler BG_frm.R_5.Click, AddressOf Me.R_9_Click
            AddHandler BG_frm.R_6.Click, AddressOf Me.R_7_Click
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

            RemoveHandler BG_frm.R_1.Click, AddressOf Me.R_1_Click
            RemoveHandler BG_frm.R_2.Click, AddressOf Me.R_3_Click
            RemoveHandler BG_frm.R_3.Click, AddressOf Me.R_4_Click
            RemoveHandler BG_frm.R_4.Click, AddressOf Me.R_6_Click
            RemoveHandler BG_frm.R_5.Click, AddressOf Me.R_9_Click
            RemoveHandler BG_frm.R_6.Click, AddressOf Me.R_7_Click
            RemoveHandler BG_frm.R_22.Click, AddressOf Me.R_22_Click
        End If
    End Function
    Private Sub BG_Keydown(sender As Object, e As KeyEventArgs)
        If BG_frm.From_ID = From_ID Then
            If e.KeyCode = Keys.D AndAlso e.Modifiers = Keys.Alt Then
                BG_frm.B_2.PerformClick()
            End If
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
                BG_frm.B_7.PerformClick()
            ElseIf e.KeyCode = Keys.Space Then
                BG_frm.B_6.PerformClick()
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
                BG_frm.R_6.PerformClick()
            End If
            If e.KeyCode = Keys.F12 Then
                BG_frm.R_22.PerformClick()
            End If
        End If
    End Sub
    Private Sub B_1_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Defolt_Select_ID = Grid1.CurrentRow.Cells(14).Value.ToString
            Cell("Voucher BG", Grid1.CurrentRow.Cells(14).Value, "Alter_Close", RG_Yype_)
        End If
    End Sub
    Private Sub R_22_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Dim obj_bg As Object = Cell("Configuration", "")
            Dim obj As Object = New Inventory_Register_cfg
            obj.obj = Me
            obj_bg.Set_Cfg(obj)
        End If
    End Sub
    Private Sub B_2_Click(sender As Object, e As EventArgs)
        Dim ro As Integer
        If BG_frm.From_ID = From_ID Then

        End If
    End Sub
    Private Sub B_3_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Fill_Grid()
        End If
    End Sub
    Private Sub B_4_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Cell("Voucher BG", Grid1.CurrentRow.Cells(14).Value, "Duplicate", RG_Yype_)
        End If
    End Sub
    Private Sub B_5_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Cell("Voucher BG", Grid1.CurrentRow.Cells(14).Value, "Create_Close", RG_Yype_)
        End If
    End Sub
    Private Sub B_6_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then

            rdlc_report_name = $"{Acc_LB.Text } ({CDate(Frm_Date_LB.Text).ToString("dd-MMM-yyyy")} to {CDate(To_Date_LB.Text).ToString("dd-MMM-yyyy")})"
            rdlc_report_name = path_validation(rdlc_report_name, "-")
            rdlc_report_data = {New ReportDataSource("dt_report", dt_print), New ReportDataSource("dt_cmp", Print_DT_Company)}

            If cfg_print_path = Nothing Then
                cfg_print_path = Application.StartupPath & "\Print_\Report\Registers\Inventory\sp_register"
            End If


            Printing_Direct_frm.Printing_(cfg_print_path, rdlc_report_name, "", rdlc_report_data)
        End If
    End Sub
    Private Sub B_7_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            If Grid1.DefaultCellStyle.BackColor = Color.FromArgb(170, 251, 236) Then
                Grid1.DefaultCellStyle.BackColor = Color.White
                Grid1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(254, 197, 48)
            Else
                Grid1.DefaultCellStyle.BackColor = Color.FromArgb(170, 251, 236)
                Grid1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(63, 239, 182)
            End If
        End If
    End Sub
    Private Sub R_1_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
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

    End Sub
    Private Sub R_7_Click(sender As Object, e As EventArgs)
        Panel_manag(Panel4)
        TX.Focus()
    End Sub
    Private Sub R_9_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Dim pop As Popup
            Dim Audit_cfg_pop As Object

            Audit_cfg_pop = New Branch_select_ctrl
            Audit_cfg_pop.frm_ = Me
            pop = New Popup(Audit_cfg_pop)

            pop.FocusOnOpen = True

            pop.AnimationDuration = 1
            pop.Show(sender)
        End If
    End Sub
    Public Function Filter_Apply()
        Label17.Text = Dft_Branch
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
    Private Sub Report_Sales_Purchase_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.HADE_TXT.Text = "Inventory Register"
        BG_frm.TYP_TXT.Text = VC_Type_

        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text

        cfg_fill()

        Button_Clear()
        Button_Manage()

        Fill_Grid()
    End Sub
    Private Function cfg_fill()
        Dim New_Tb As Boolean = Create_Database_Table()

        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.lnk, cn) = True Then
            cmd = New SQLiteCommand("Select * From cfg_Inventory_Register", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                If r("Head") = "Print_Path" Then
                    cfg_print_path = (r("Value"))
                ElseIf r("Head") = "Narration" Then
                    Narration_YN = YN_Boolean(r("Value"))
                ElseIf r("Head") = "GST Details" Then
                    GST_YN = YN_Boolean(r("Value"))
                ElseIf r("Head") = "Transport_Details" Then
                    Transport_YN = YN_Boolean(r("Value"))
                ElseIf r("Head") = "Transport_Name" Then
                    Tra_Name_YN = YN_Boolean(r("Value"))
                ElseIf r("Head") = "Vehicle_Type" Then
                    Vehicle_Type_YN = YN_Boolean(r("Value"))
                ElseIf r("Head") = "Vehicle_No" Then
                    Vehicle_No_YN = YN_Boolean(r("Value"))
                ElseIf r("Head") = "Driver Name" Then
                    Driver_YN = YN_Boolean(r("Value"))
                ElseIf r("Head") = "Driver Phone" Then
                    Driver_Phone_YN = YN_Boolean(r("Value"))
                End If
            End While
            r.Close()
        End If
    End Function
    Public Function Create_Database_Table() As Boolean
        Dim cn As New SQLiteConnection
        Dim create_ As Boolean = False
        If open_MSSQL_Cstm(Database_File.lnk, cn) = True Then
            cmd = New SQLiteCommand("SELECT count(*) as c FROM sqlite_master WHERE type='table' AND name='cfg_Inventory_Register'", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                If r("c") <> 1 Then
                    create_ = True
                End If
            End While
            r.Close()


            If create_ = True Then
                cmd = New SQLiteCommand("CREATE TABLE 'cfg_Inventory_Register' (
	'Id'	INTEGER NOT NULL UNIQUE,
	'Head'	TEXT,
	'Value'	TEXT,
	PRIMARY KEY('Id' AUTOINCREMENT));", cn)

                cmd.ExecuteNonQuery()
            End If
        End If

        Return create_
    End Function
    Private Sub Report_Sales_Purchase_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub Report_Sales_Purchase_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        Add_Hander_Remove_Handel(False)
        BG_frm.BG_Path_TXT.Text = Path_End
        Frm_foCus()
    End Sub
    Public Unit_YN As Boolean = False
    Public Unit_TO As String = "NA"
    Public Qty_TO As Decimal = 0
    Public SUB_TO As Decimal = 0
    Public CGST As Decimal = 0
    Public SGST As Decimal = 0
    Public IGST As Decimal = 0
    Public GROSS As Decimal = 0
    Dim dt As New DataTable
    Public Function Fill_Grid()
        Branch_ID = Branch_ID_()

        Unit_YN = True
        Unit_TO = "NA"
        Qty_TO = 0
        SUB_TO = 0
        CGST = 0
        SGST = 0
        IGST = 0
        GROSS = 0

        dt.Clear()
        dt.Columns.Clear()
        dt.Reset()
        dt = New DataTable
        dt.Columns.Add("Type")
        dt.Columns.Add("Date").DataType = GetType(Date)
        dt.Columns.Add("Particulars")
        dt.Columns.Add("Voucher No.")
        dt.Columns.Add("GST No.")
        dt.Columns.Add("Narrstion")
        dt.Columns.Add("Quantity")
        dt.Columns.Add("Unit")
        dt.Columns.Add("Rate")
        dt.Columns.Add("SUB TOTAL")
        dt.Columns.Add("CGST")
        dt.Columns.Add("SGST")
        dt.Columns.Add("IGST")
        dt.Columns.Add("Net Amt")
        dt.Columns.Add("Tra_ID")
        dt.Columns.Add("Supplier Voucher No.")
        dt.Columns.Add("Transport Name")
        dt.Columns.Add("Vehicle Type")
        dt.Columns.Add("Vehicle No.")
        dt.Columns.Add("Driver Name")
        dt.Columns.Add("Driver Phone")

        'BG_Panel.Hide()

        Fill_oTher_Group(dt)

        Dim dv As New DataView(dt)
        Dim Dt_set As New DataTable
        dv.Sort = "Date"
        Dt_set = dv.ToTable


        Grid1.DataSource = dv



        Grid1.Columns(0).Visible = False
        Grid1.Columns(14).Visible = False
        If RG_Yype_ = "Sales" Then
            Grid1.Columns(15).Visible = False
        Else
            Grid1.Columns(15).DisplayIndex = 4
            Grid1.Columns(15).Visible = True
        End If

        Grid1.Columns(1).Width = 100
        Grid1.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Grid1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        Grid1.Columns(2).Width = 300
        Grid1.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        Grid1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        Grid1.Columns(2).Frozen = True

        Grid1.Columns(3).Width = 100
        Grid1.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Grid1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        Grid1.Columns(15).Width = 100
        Grid1.Columns(15).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Grid1.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        Grid1.Columns(4).Width = 150
        Grid1.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Grid1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        Grid1.Columns(5).Width = 150
        Grid1.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Grid1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        'Grid1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        Grid1.Columns(5).DefaultCellStyle.WrapMode = DataGridViewTriState.True

        Grid1.Columns(6).Width = 80
        Grid1.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Grid1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Grid1.Columns(7).Width = 60
        Grid1.Columns(7).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Grid1.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        Grid1.Columns(7).HeaderText = ""

        Grid1.Columns(8).Width = 80
        Grid1.Columns(8).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Grid1.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Grid1.Columns(9).Width = 100
        Grid1.Columns(9).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Grid1.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Grid1.Columns(10).Width = 80
        Grid1.Columns(10).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Grid1.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Grid1.Columns(11).Width = 80
        Grid1.Columns(11).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Grid1.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Grid1.Columns(12).Width = 80
        Grid1.Columns(12).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Grid1.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Grid1.Columns(13).Width = 120
        Grid1.Columns(13).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        Grid1.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Grid1.Columns(16).Width = 150
        Grid1.Columns(17).Width = 120
        Grid1.Columns(18).Width = 100
        Grid1.Columns(19).Width = 130
        Grid1.Columns(20).Width = 110

        BG_Panel.BringToFront()
        Count_ = 0

        Label17.Text = Dft_Branch
        Grid1.Focus()
        If Grid1.Rows.Count > 0 Then
            Grid1.CurrentCell = Grid1.Rows(0).Cells(1)
        End If

        Colunm_Filter_Apply()


        If Grid1.Rows.Count > Val(Defolt_Select_ID) Then
            Grid1.CurrentCell = Grid1.Rows(Val(Defolt_Select_ID)).Cells(1)
        End If


        Total_Grid = Grid_Bottom(Panel1, Grid1)
        With Total_Grid.Rows(0)
            .Cells("Particulars").Value = "Total"
            If Unit_YN = True Then
                .Cells("Quantity").Value = N2_FORMATE(Qty_TO)
                .Cells("Unit").Value = Unit_TO
            Else
                .Cells("Quantity").Value = ""
                .Cells("Unit").Value = ""
            End If

            .Cells("Sub Total").Value = N2_FORMATE(SUB_TO)
            .Cells("Net Amt").Value = N2_FORMATE(GROSS)

            .Cells("CGST").Value = N2_FORMATE(CGST)
            .Cells("SGST").Value = N2_FORMATE(SGST)
            .Cells("IGST").Value = N2_FORMATE(IGST)
        End With
        Grid1.Focus()
        For Each cl As DataGridViewColumn In Grid1.Columns
            Total_Grid.Columns(cl.Index).DisplayIndex = cl.DisplayIndex
        Next

        'TOTAL_Set
    End Function
    Public Total_Grid As DataGridView
    Public GST_YN As Boolean = True
    Public Transport_YN As Boolean = True
    Public Narration_YN As Boolean = False
    Public Tra_Name_YN As Boolean = True
    Public Vehicle_Type_YN As Boolean = True
    Public Vehicle_No_YN As Boolean = True
    Public Driver_YN As Boolean = False
    Public Driver_Phone_YN As Boolean = False

    Public cfg_print_path As String
    Dim rdlc_report_name As String
    Dim rdlc_report_data() As ReportDataSource
    Private Function Colunm_Filter_Apply()
        Grid1.Columns(4).Visible = GST_YN
        Grid1.Columns(10).Visible = GST_YN
        Grid1.Columns(11).Visible = GST_YN
        Grid1.Columns(12).Visible = GST_YN
        Grid1.Columns(13).Visible = GST_YN

        Grid1.Columns(5).Visible = Narration_YN

        If Transport_YN = True Then
            Grid1.Columns(16).Visible = Tra_Name_YN
            Grid1.Columns(17).Visible = Vehicle_Type_YN
            Grid1.Columns(18).Visible = Vehicle_No_YN
            Grid1.Columns(19).Visible = Driver_YN
            Grid1.Columns(20).Visible = Driver_Phone_YN
        Else
            Grid1.Columns(16).Visible = False
            Grid1.Columns(17).Visible = False
            Grid1.Columns(18).Visible = False
            Grid1.Columns(19).Visible = False
            Grid1.Columns(20).Visible = False
        End If


    End Function
    Dim Defolt_Select_ID As String = 0
    Private Function Fill_oTher_Group(dt As DataTable)
        Dim dr_Print As DataRow
        dt_print.Rows.Clear()
        dt_print = ds_print.Tables("TBL_sp_Register")
        Dim DAte_Filter As String = " (Date BETWEEN '" & CDate(Frm_date).ToString(Lite_date_Format) & "' and '" & CDate(to_date).AddDays(1).ToString(Lite_date_Format) & "')"

        Dim Branch_Filter As String = ""
        If Branch_ID <> 0 Then
            Branch_Filter &= " AND Branch = '" & Branch_ID & "'"
        End If

        Dim vc_Filter As String = ""
        vc_Filter = $" and (Voucher_Type = '{RG_Yype_}')"

        Dim itm_filter As String = ""
        Dim ledger_filter As String = ""

        If it_id = 0 Then
            itm_filter = ""
        Else
            itm_filter = $"and vi.Item = '{it_id}'"
        End If

        If ld_id = 0 Then
            ledger_filter = ""
        Else
            ledger_filter = $"and vc.Ledger = '{ld_id}'"
        End If

        'MsgBox(RG_Yype_)

        Dim dr As DataRow
        If open_MSSQL(Database_File.cre) = True Then
            cmd = New SQLiteCommand($"Select * From (Select 'Head' as Type,vc.Tra_ID,vc.[date],
(Select ld.name From TBL_Ledger ld where ld.id = vc.Ledger) as Ledger_Name,
(Select i.name From TBL_Stock_Item i where i.id = (Select vi.Item From TBL_VC_Item_Details vi where vi.Tra_ID = vc.Tra_ID Limit 1)) as Item_Name,
vc.Branch as Branch,
vc.Voucher_Type,
vc.Voucher_No,
vc.Supplier_IVC_No as Supplier_IVC_No,
(Select vo.To_GST From TBL_VC_Other vo where vo.Tra_ID = vc.Tra_ID) as To_GST,
vc.Narration,
ifnull(vc.Credit_Amount,0)+ifnull(vc.Debit_Amount,0) as NetAmount,
(Select ifnull(SUM(vi.Qty),'') From TBL_VC_item_Details vi where vi.Tra_ID = vc.Tra_ID and vi.Item = '{it_id}') as Qty,
(Select iu.Symbol From TBL_Inventory_Unit iu where iu.id = (Select si.Unit From TBL_Stock_Item si where si.id = '{it_id}')) as Unit,
(Select ifnull(SUM(vi.Amount),0)/ifnull(SUM(vi.Qty),0) From TBL_VC_item_Details vi where vi.Tra_ID = vc.Tra_ID and vi.Item = '{it_id}') as Rate,
(Select ifnull(SUM(vi.CGST),0) From TBL_VC_item_Details vi where vi.Tra_ID = vc.Tra_ID {itm_filter}) as CGST,
(Select ifnull(SUM(vi.SGST),0) From TBL_VC_item_Details vi where vi.Tra_ID = vc.Tra_ID {itm_filter}) as SGST,
(Select ifnull(SUM(vi.IGST),0) From TBL_VC_item_Details vi where vi.Tra_ID = vc.Tra_ID {itm_filter}) as IGST,
(Select ifnull(SUM(vi.Amount),0) From TBL_VC_item_Details vi where vi.Tra_ID = vc.Tra_ID {itm_filter}) as SubTotal,
vo.Transportation_Name,
vo.Vihical_Type,
vo.Vihical_No,
vo.Driver_Name,
vo.Driver_Phone
From TBL_VC vc
LEFT join TBL_VC_Other vo on vo.Tra_ID = vc.Tra_ID
where vc.Visible <> 'Delete' and vc.Type = 'Head' {ledger_filter}

UNION ALL

SELECT 'Under',
vi.Tra_ID,
vc.[Date] as Date,
(Select it.name From TBL_Stock_Item it where it.id = vi.Item),
'' as Item_Name,
vc.Branch as Branch,
vc.Voucher_Type as Voucher_Type,
'',
'' as Supplier_IVC_No,
'',
'',
ifnull(vi.Amount,0)+ifnull(vi.CGST,0)+ifnull(vi.SGST,0)+ifnull(vi.IGST,0) as NetAmount,
ifnull(vi.Qty,0) as Qty,
(Select iu.Symbol From TBL_Inventory_Unit iu where iu.id = (Select si.Unit From TBL_Stock_Item si where si.id = vi.Item)) as Unit,
ifnull(vi.Rate,0) as Rate,
ifnull(vi.CGST,0) as CGST,
ifnull(vi.SGST,0) as SGST,
ifnull(vi.IGST,0) as IGST,
ifnull(vi.Amount,0) as SubTotal,
'',
'',
'',
'',
''
 From TBL_VC_item_Details vi LEFT JOIN TBL_VC vc on vc.Tra_ID = vi.Tra_ID and vc.Type = 'Head' {ledger_filter}
where vc.Visible <> 'Delete'

UNION ALL

Select 'Exp' as Type,vc.Tra_ID,vc.[date],
(Select ld.name From TBL_Ledger ld where ld.id = vl.Ledger) as Ledger_Name,
 '' as Item_Name,
vc.Branch as Branch,
vc.Voucher_Type,
'' as Voucher_No,
'' as Supplier_IVC_No,
'' as To_GST,
vc.Narration,
ifnull(vl.Cr,0)+ifnull(vl.Dr,0) as NetAmount,
'' as Qty,
'' as Unit,
'' as Rate,
'' as CGST,
'' as SGST,
'' as IGST,
ifnull(vl.Cr,0)+ifnull(vl.Dr,0) as SubTotal,
'',
'',
'',
'',
''
From TBL_VC_Ledger vl 

LEFT join TBL_VC vc on vc.Tra_ID = vl.Tra_ID
where vc.Visible <> 'Delete' and vl.Type = 'Exp' 

)
 where {DAte_Filter}{Branch_Filter}{vc_Filter}
ORDER By [date],Tra_ID", con)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                'MsgBox(r("Type").ToString)
                If (r("Type").ToString = "Head") Or ((r("Type").ToString = "Under" Or r("Type").ToString = "Exp") And YN_Details = True) Then
                    If (it_id = 0) Or (it_id <> 0 And Val(r("Qty").ToString) <> 0) Then
                        dr = dt.NewRow
                        dr_Print = dt_print.NewRow
                        dr("Tra_ID") = r("Tra_ID")
                        dr("Type") = r("Type")
                        dr("Date") = CDate(r("Date")).ToString(Date_Format_fech)
                        dr("Voucher No.") = r("Voucher_No")
                        dr("Supplier Voucher No.") = r("Supplier_IVC_No").ToString

                        dr("Quantity") = N2_FORMATE(r("Qty"))
                        dr("GST No.") = r("To_GST")
                        dr("Narrstion") = r("Narration")
                        dr("Unit") = r("Unit")
                        dr("Rate") = N2_FORMATE(r("Rate").ToString)

                        If r("Ledger_Name").ToString = Nothing Then
                            dr("Particulars") = r("Item_Name").ToString
                        Else
                            dr("Particulars") = r("Ledger_Name").ToString
                        End If
                        dr("Transport Name") = r("Transportation_Name")
                        dr("Vehicle Type") = r("Vihical_Type")
                        dr("Vehicle No.") = r("Vihical_No")
                        dr("Driver Name") = r("Driver_Name")
                        dr("Driver Phone") = r("Driver_Phone")

                        dr_Print("Partiiculars") = r("Ledger_Name")
                        dr_Print("Date") = CDate(r("Date")).ToString(Date_Format_fech)
                        dr_Print("Voucher_No") = r("Voucher_No")
                        dr_Print("GST") = r("To_GST")
                        dr_Print("Quantity") = N2_FORMATE(r("Qty"))
                        dr_Print("Unit") = r("Unit")
                        dr_Print("Rate") = N2_FORMATE(r("Rate").ToString)
                        dr_Print("Truck_no") = r("Vihical_No").ToString


                        dr("Sub Total") = N2_FORMATE(r("SubTotal"))
                        dr_Print("Subtotal") = N2_FORMATE(r("SubTotal"))
                        dr("Net Amt") = N2_FORMATE(r("NetAmount"))
                        dr_Print("Total") = N2_FORMATE(r("NetAmount"))


                        If r("Type") = "Head" Then
                            GROSS += Val(r("NetAmount"))
                        End If

                        dr("CGST") = N2_FORMATE(Val(r("CGST")))
                        dr("SGST") = N2_FORMATE(Val(r("SGST")))
                        dr("IGST") = N2_FORMATE(Val(r("IGST")))

                        dr_Print("CGST") = N2_FORMATE(Val(r("CGST")))
                        dr_Print("SGST") = N2_FORMATE(Val(r("SGST")))
                        dr_Print("IGST") = N2_FORMATE(Val(r("IGST")))

                        If r("Type") = "Under" Then
                            If it_id = 0 Then
                                If Unit_TO = r("Unit") Or Unit_TO = "NA" Then
                                    Qty_TO += Val(r("Qty"))
                                    Unit_TO = (r("Unit"))
                                Else
                                    Unit_YN = False
                                End If
                            End If
                        ElseIf r("Type") = "Head" Then
                            SUB_TO += Val(r("SubTotal"))
                            CGST += Val(r("CGST"))
                            SGST += Val(r("SGST"))
                            IGST += Val(r("IGST"))
                            If it_id <> 0 Then
                                Qty_TO += Val(r("Qty"))
                                Unit_TO = (r("Unit"))
                                Unit_YN = True
                            End If
                        End If

                        dt.Rows.Add(dr)
                        dt_print.Rows.Add(dr_Print)

                        If Defolt_Select_ID = r("Tra_ID") Then
                            Defolt_Select_ID = dt.Rows.Count - 1
                        End If
                    End If
                End If

            End While
            r.Close()
        End If




    End Function
    Private Sub Frm_Date_LB_TextChanged(sender As Object, e As EventArgs) Handles Frm_Date_LB.TextChanged
        Frm_date = Date_Formate(Frm_Date_LB.Text)
    End Sub
    Private Sub To_Date_LB_TextChanged(sender As Object, e As EventArgs) Handles To_Date_LB.TextChanged
        to_date = Date_Formate(To_Date_LB.Text)
    End Sub
    Private Sub Grid1_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid1.KeyDown
        If e.KeyCode = Keys.Enter Then
            BG_frm.B_1.PerformClick()
        End If
    End Sub
    Private Sub Grid1_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles Grid1.RowPrePaint
        Dim ro As DataGridViewRow = Grid1.Rows(e.RowIndex)
        If ro.Cells(0).Value = "Head" Or ro.Cells(0).Value = "Total" Then
            Count_ += 1

        Else
            ro.Visible = YN_Details
            ro.DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Italic)
            ro.DefaultCellStyle.ForeColor = Color.DimGray
            ro.Cells(1).Style.SelectionBackColor = Color.White
            ro.Cells(1).Style.ForeColor = Color.White
            ro.Cells(1).Style.SelectionForeColor = Color.White
        End If

        If ro.Cells(0).Value = "Total" Then
            ro.DefaultCellStyle.BackColor = Color.NavajoWhite

            ro.Cells(1).Style.SelectionBackColor = Color.NavajoWhite
            ro.Cells(1).Style.ForeColor = Color.NavajoWhite
            ro.Cells(1).Style.SelectionForeColor = Color.NavajoWhite
        Else
            ro.DefaultCellStyle.SelectionBackColor = Color.FromArgb(254, 197, 48)
            ro.DefaultCellStyle.BackColor = Color.White
        End If


    End Sub

    Private Sub Grid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid1.CellContentClick

    End Sub

    Private Sub Grid1_Paint(sender As Object, e As PaintEventArgs) Handles Grid1.Paint
        DrawLinePoint(e)
    End Sub
    Public Sub DrawLinePoint(ByVal e As PaintEventArgs)
        If Grid1.Rows.Count <> 0 Then
            Dim blackPen As New Pen(Color.Gray, 1)
            Dim font_ As Font = New Font("Arial", 10, FontStyle.Bold)
            Dim Brsh As New SolidBrush(Color.Black)

            Dim recf As New RectangleF(0, 0, 100, 20)
            Dim hh As New StringFormat
            hh.Alignment = StringAlignment.Far


            Dim ctlpos As Point = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(1, 0, False).Location)
            Dim point1 As New Point(ctlpos.X, 0)
            Dim point2 As New Point(ctlpos.X, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)


            ctlpos = New Point
            ctlpos = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(2, 0, False).Location)
            point1 = New Point(ctlpos.X, 0)
            point2 = New Point(ctlpos.X, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)

            ctlpos = New Point
            ctlpos = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(3, 0, False).Location)
            point1 = New Point(ctlpos.X, 0)
            point2 = New Point(ctlpos.X, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)

            ctlpos = New Point
            ctlpos = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(4, 0, False).Location)
            point1 = New Point(ctlpos.X, 0)
            point2 = New Point(ctlpos.X, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)

            ctlpos = New Point
            ctlpos = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(5, 0, False).Location)
            point1 = New Point(ctlpos.X, 0)
            point2 = New Point(ctlpos.X, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)

            ctlpos = New Point
            ctlpos = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(6, 0, False).Location)
            point1 = New Point(ctlpos.X, 0)
            point2 = New Point(ctlpos.X, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)

            If Unit_YN = True Then
                recf = New RectangleF(ctlpos.X, Grid1.Height - 18, Grid1.Columns(6).Width, 20)
                'e.Graphics.DrawString(N2_FORMATE(Qty_TO), font_, Brsh, recf, hh)
            End If

            ctlpos = New Point
            ctlpos = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(7, 0, False).Location)
            point1 = New Point(ctlpos.X, 0)
            point2 = New Point(ctlpos.X, Grid1.Height)
            'e.Graphics.DrawLine(blackPen, point1, point2)
            If Unit_YN = True Then
                recf = New RectangleF(ctlpos.X, Grid1.Height - 18, Grid1.Columns(7).Width, 20)
                Dim hh_ As New StringFormat
                hh_.Alignment = StringAlignment.Near
                'e.Graphics.DrawString(Unit_TO, font_, Brsh, recf, hh_)
            End If

            ctlpos = New Point
            ctlpos = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(8, 0, False).Location)
            point1 = New Point(ctlpos.X, 0)
            point2 = New Point(ctlpos.X, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)

            recf = New RectangleF(ctlpos.X, Grid1.Height - 18, Grid1.Columns(8).Width, 20)
            'e.Graphics.DrawString("", font_, Brsh, recf, hh)

            ctlpos = New Point
            ctlpos = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(9, 0, False).Location)
            point1 = New Point(ctlpos.X, 0)
            point2 = New Point(ctlpos.X, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)

            recf = New RectangleF(ctlpos.X, Grid1.Height - 18, Grid1.Columns(9).Width, 20)
            'e.Graphics.DrawString(N2_FORMATE(SUB_TO), font_, Brsh, recf, hh)

            ctlpos = New Point
            ctlpos = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(10, 0, False).Location)
            point1 = New Point(ctlpos.X, 0)
            point2 = New Point(ctlpos.X, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)

            recf = New RectangleF(ctlpos.X, Grid1.Height - 18, Grid1.Columns(10).Width, 20)
            'e.Graphics.DrawString(N2_FORMATE(CGST), font_, Brsh, recf, hh)

            ctlpos = New Point
            ctlpos = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(11, 0, False).Location)
            point1 = New Point(ctlpos.X, 0)
            point2 = New Point(ctlpos.X, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)

            recf = New RectangleF(ctlpos.X, Grid1.Height - 18, Grid1.Columns(11).Width, 20)
            ' e.Graphics.DrawString(N2_FORMATE(SGST), font_, Brsh, recf, hh)

            ctlpos = New Point
            ctlpos = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(12, 0, False).Location)
            point1 = New Point(ctlpos.X, 0)
            point2 = New Point(ctlpos.X, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)

            recf = New RectangleF(ctlpos.X, Grid1.Height - 18, Grid1.Columns(12).Width, 20)
            'e.Graphics.DrawString(N2_FORMATE(IGST), font_, Brsh, recf, hh)


            ctlpos = New Point
            ctlpos = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(13, 0, False).Location)
            point1 = New Point(ctlpos.X, 0)
            point2 = New Point(ctlpos.X, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)

            recf = New RectangleF(ctlpos.X, Grid1.Height - 18, Grid1.Columns(13).Width, 20)
            'e.Graphics.DrawString(N2_FORMATE(GROSS), font_, Brsh, recf, hh)

            ctlpos = New Point
            ctlpos = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(14, 0, False).Location)
            point1 = New Point(ctlpos.X, 0)
            point2 = New Point(ctlpos.X, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)

            ctlpos = New Point
            ctlpos = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(15, 0, False).Location)
            point1 = New Point(ctlpos.X, 0)
            point2 = New Point(ctlpos.X, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)

            ctlpos = New Point
            ctlpos = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(16, 0, False).Location)
            point1 = New Point(ctlpos.X, 0)
            point2 = New Point(ctlpos.X, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)

            ctlpos = New Point
            ctlpos = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(17, 0, False).Location)
            point1 = New Point(ctlpos.X, 0)
            point2 = New Point(ctlpos.X, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)

            ctlpos = New Point
            ctlpos = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(18, 0, False).Location)
            point1 = New Point(ctlpos.X, 0)
            point2 = New Point(ctlpos.X, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)

            ctlpos = New Point
            ctlpos = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(19, 0, False).Location)
            point1 = New Point(ctlpos.X, 0)
            point2 = New Point(ctlpos.X, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)

            ctlpos = New Point
            ctlpos = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(20, 0, False).Location)
            point1 = New Point(ctlpos.X, 0)
            point2 = New Point(ctlpos.X, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)


            point1 = New Point(0, Grid1.ColumnHeadersHeight)
            point2 = New Point(Grid1.Width, Grid1.ColumnHeadersHeight)
            e.Graphics.DrawLine(blackPen, point1, point2)

            point1 = New Point(0, 0)
            point2 = New Point(Grid1.Width, 0)
            e.Graphics.DrawLine(blackPen, point1, point2)



            point1 = New Point(0, Grid1.Rows.Count * 18)
            point2 = New Point(Grid1.Width, Grid1.Rows.Count * 18)
            'e.Graphics.DrawLine(blackPen, point1, point2)

            point1 = New Point(0, Grid1.Height - 0)
            point2 = New Point(Grid1.Width, Grid1.Height - 0)
            'e.Graphics.DrawLine(New Pen(Color.Black, 4), point1, point2)

        End If
    End Sub
    Private Sub Report_Ledger_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
        Grid1.Focus()
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs)
        obj_top(sender)
    End Sub

    Private Sub Panel3_Paint_1(sender As Object, e As PaintEventArgs) Handles Panel3.Paint
        obj_top(sender)
    End Sub

    Private Sub TX_TextChanged(sender As Object, e As EventArgs) Handles TX.TextChanged

    End Sub
    Dim me_list As List_frm
    Dim ledger_list As List_frm
    Private Function List_Fill()
        obj_top(Panel3)
        me_list = New List_frm
        List_Setup("List of Stock Items", Select_List.Botom_Center, Select_List_Format.Defolt, TX, me_list, Item_Source, TX.Width + 100)

        ledger_list = New List_frm
        List_Setup("List of Accounting Ledger", Select_List.Botom_Center, Select_List_Format.Defolt, Ledgeer_Filter_TXT, ledger_list, Ledger_Source, Ledgeer_Filter_TXT.Width + 100)


    End Function
    Private Function fill_Data()
        Dim dt As New DataTable
        dt.Columns.Add("Name")
        dt.Columns.Add("Group")
        dt.Columns.Add("ID")

        dt.Rows.Add("Not Applicable", "", "0")

        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand("Select it.name,it.id,(select sg.name From TBL_Stock_Group sg where sg.id = it.Under) as Under_Name From TBL_Stock_Item it where it.Visible = 'Approval'", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                dt.Rows.Add(r("Name"), r("Under_Name"), r("ID"))
            End While
            r.Close()
            Item_Source.DataSource = dt

            dt = New DataTable
            dt.Columns.Add("Name")
            dt.Columns.Add("Group")
            dt.Columns.Add("ID")
            dt.Rows.Add("Not Applicable", "", "0")


            cmd = New SQLiteCommand("Select ld.name,ld.id,(select ag.name From TBL_Acc_Group ag where ag.id = ld.[Group]) as Under_Name From TBL_Ledger ld where ld.Visible = 'Approval'", cn)
            r = cmd.ExecuteReader
            While r.Read
                dt.Rows.Add(r("Name"), r("Under_Name"), r("ID"))
            End While
            r.Close()
            Ledger_Source.DataSource = dt

        End If

    End Function
    Private Function Panel_manag(pan As Panel)
        Panel4.Visible = False
        BG_Panel.Visible = False

        pan.Dock = DockStyle.Fill
        pan.Visible = True
    End Function

    Private Sub TX_KeyDown(sender As Object, e As KeyEventArgs) Handles TX.KeyDown
        If e.KeyCode = Keys.Enter Then
            it_id = me_list.List_Grid.CurrentRow.Cells(2).Value
            it_name = me_list.List_Grid.CurrentRow.Cells(0).Value.ToString
        End If
    End Sub
    Public Function Save_Data()

    End Function

    Private Sub Ledgeer_Filter_TXT_TextChanged(sender As Object, e As EventArgs) Handles Ledgeer_Filter_TXT.TextChanged

    End Sub

    Private Sub Ledgeer_Filter_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles Ledgeer_Filter_TXT.KeyDown
        If e.KeyCode = Keys.Enter Then
            ld_id = ledger_list.List_Grid.CurrentRow.Cells(2).Value
            ld_name = ledger_list.List_Grid.CurrentRow.Cells(0).Value.ToString
        End If
    End Sub

    Private Sub Txt1_TextChanged(sender As Object, e As EventArgs) Handles Txt1.TextChanged

    End Sub

    Private Sub Txt1_Enter(sender As Object, e As EventArgs) Handles Txt1.Enter
        Fill_Grid()
        Panel_manag(BG_Panel)
        Grid1.Focus()
    End Sub
End Class