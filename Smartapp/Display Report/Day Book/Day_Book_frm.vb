Imports System.Data.SQLite
Imports Microsoft.Reporting.WinForms
Imports PopupControl

Public Class Day_Book_frm
    Dim From_ID As String
    Private VC_Type_ As String
    Private VC_ID_ As String
    Private Path_End As String
    Dim YN_Details As Boolean
    Dim Acc_Under As String
    Dim Frm_date As Date
    Dim to_date As Date

    Public Narration_ As Boolean = False
    Public Sorting_Methoud_ As String = "Date (Increasing)"
    Public Delete_Entry = False

    Dim ds_print As New Print_dt
    Dim dt_print As New DataTable

    Dim Defolt_Select_ID As String = 0
    Private Sub Day_Book_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text

        VC_Type_ = Link_Valu(1)
        VC_ID_ = Link_Valu(2)

        Frm_Date_LB.Text = Date_Formate(Date_1)
        To_Date_LB.Text = Date_Formate(Date_2)

        BG_frm.HADE_TXT.Text = "Day Book"
        BG_frm.TYP_TXT.Text = VC_Type_

        Button_Manage()
        Add_Hander_Remove_Handel(True)

        Label14.Text = Dft_Voucher
        Label17.Text = Dft_Branch
        Update_Report = True
    End Sub

    Private Function Button_Manage()
        Button_Clear()
        BG_frm.B_1.Text = "Enter : Alter"
        BG_frm.B_2.Text = "|&D : Delete"
        BG_frm.B_3.Text = "|&R : Refresh"
        BG_frm.B_4.Text = "|&2 : Duplicate"
        BG_frm.B_5.Text = "|&A : Add Voucher"
        BG_frm.B_6.Text = "|&P : Print"
        BG_frm.B_7.Text = "&Spc. : Sel."
        BG_frm.B_8.Text = "&Spc. : Sel. All"

        BG_frm.R_1.Text = "|F1 : Detailed"
        BG_frm.R_2.Text = "F2 : Date"
        BG_frm.R_3.Text = "|F2 : Period"
        BG_frm.R_4.Text = "F3 : Voucher Type"
        If Branch_Visible() = True Then
            BG_frm.R_5.Text = "F4 : Branch"
        End If

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

            AddHandler BG_frm.R_1.Click, AddressOf Me.R_1_Click
            AddHandler BG_frm.R_2.Click, AddressOf Me.R_3_Click
            AddHandler BG_frm.R_3.Click, AddressOf Me.R_4_Click
            AddHandler BG_frm.R_4.Click, AddressOf Me.R_6_Click
            If Branch_Visible() = True Then
                AddHandler BG_frm.R_5.Click, AddressOf Me.R_9_Click
            End If
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


            RemoveHandler BG_frm.R_1.Click, AddressOf Me.R_1_Click
            RemoveHandler BG_frm.R_2.Click, AddressOf Me.R_3_Click
            RemoveHandler BG_frm.R_3.Click, AddressOf Me.R_4_Click
            RemoveHandler BG_frm.R_4.Click, AddressOf Me.R_6_Click
            If Branch_Visible() = True Then
                RemoveHandler BG_frm.R_5.Click, AddressOf Me.R_9_Click
            End If
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
                BG_frm.R_7.PerformClick()
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

            If e.KeyCode = Keys.F12 Then
                BG_frm.R_22.PerformClick()
            End If

            If e.KeyCode = Keys.F AndAlso e.Modifiers = Keys.Control Then
                BG_frm.R_6.PerformClick()
            End If
        End If
    End Sub
    Private Sub B_1_Click(sender As Object, e As EventArgs)
        If BG_frm.HADE_TXT.Text = "Day Book" Then
            If Grid1.Rows.Count > 0 Then
                'Defolt_Select_ID = Grid1.CurrentRow.Cells(8).Value.ToString
                Cell("Voucher BG", Grid1.CurrentRow.Cells(8).Value, "Alter_Close", Grid1.CurrentRow.Cells(3).Value)


            End If
        End If
    End Sub
    Private Sub B_2_Click(sender As Object, e As EventArgs)
        Dim ro As Integer
        If BG_frm.From_ID = From_ID Then
            If Msg_Yn("Are you source", "Delete Selected Voucher ?") = DialogResult.Yes Then
                For Each row_ As DataGridViewRow In Grid1.Rows
                    If row_.Cells(11).Value = True Then
                        If Delete_Vouchers(row_.Cells(8).Value, row_.Cells(3).Value) = False Then
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
            Cell("Voucher BG", Grid1.CurrentRow.Cells(8).Value, "Duplicate", Grid1.CurrentRow.Cells(3).Value)
        End If
    End Sub
    Private Sub B_5_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Cell("Voucher BG", Grid1.CurrentRow.Cells(8).Value, "Create_Close", Grid1.CurrentRow.Cells(3).Value, Grid1.CurrentRow.Cells(7).Value)
        End If
    End Sub
    Private Sub B_6_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Print_data_fill()
            Printing_Direct_frm.Printing_(cfg_print_path, rdlc_report_name, "", rdlc_report_data)
        End If
    End Sub

    Private Sub B_7_Click(sender As Object, e As EventArgs)
        If BG_frm.HADE_TXT.Text = "Day Book" And BG_Panel.Visible = True And Grid1.CurrentRow.Cells(0).Value = "Head" Then
            If Grid1.CurrentRow.Cells(11).Value = True Then
                Grid1.CurrentRow.Cells(11).Value = False
            ElseIf Grid1.CurrentRow.Cells(11).Value = False Then
                Grid1.CurrentRow.Cells(11).Value = True
            End If
        End If
    End Sub
    Private Sub B_8_Click(sender As Object, e As EventArgs)
        If BG_frm.HADE_TXT.Text = "Day Book" And BG_Panel.Visible = True And Grid1.CurrentRow.Cells(0).Value = "Head" Then
            For Each ro As DataGridViewRow In Grid1.Rows
                ro.Cells(11).Value = True
            Next
            Grid1.Refresh()
        End If
    End Sub
    Private Sub R_1_Click(sender As Object, e As EventArgs)
        If BG_frm.HADE_TXT.Text = "Day Book" Then
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
        'If BG_frm.R_7.Text = "|F3 : Format(Short)" Then
        '    BG_frm.R_7.Text = "|F3 : Format(Full)"
        '    Md = Moad.Full_
        '    Fill_Grid()
        'ElseIf BG_frm.R_7.Text = "|F3 : Format(Full)" Then
        '    BG_frm.R_7.Text = "|F3 : Format(Short)"
        '    Md = Moad.Short_
        '    Fill_Grid()
        'End If
    End Sub
    Private Sub R_9_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Cell("Filter", "Branch", BG_frm.HADE_TXT.Text)
        End If
    End Sub
    Private Sub R_22_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Dim obj_bg As Object = Cell("Configuration", "")
            Dim obj As Object = New Day_Book_cfg
            obj.obj = Me
            obj_bg.Set_Cfg(obj)
        End If
    End Sub
    'Dim Date_Filter As String
    Dim dt As New DataTable
    Public Function Filter_Apply()
        Label17.Text = Dft_Branch
        Label14.Text = Dft_Voucher

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
        Grid1.Focus()
        If Grid1.Rows.Count <> 0 Then
            Try
                Defolt_Select_ID = Grid1.CurrentRow.Cells(8).Value.ToString
            Catch ex As Exception

            End Try
        End If


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
        dt.Columns.Add("Debit").DataType = GetType(Decimal)
        dt.Columns.Add("Credit").DataType = GetType(Decimal)
        dt.Columns.Add("VC_ID")
        dt.Columns.Add("Tra_ID")
        dt.Columns.Add("Narration")
        dt.Columns.Add("Status")


        Fill_oTher_Group(dt, 0)

        Dim dv As New DataView(dt)
        Dim Dt_set As New DataTable


        'dv.Sort = $"Date {Date_Sorting_code}"
        Dt_set = dv.ToTable


        Source_.DataSource = dv
        Grid1.DataSource = Source_

        Grid1.Columns(0).Visible = False
        Grid1.Columns(7).Visible = False
        Grid1.Columns(8).Visible = False


        Grid1.Columns(9).Visible = False


        Grid1.Columns(1).Width = 100
        Grid1.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Grid1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        Grid1.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Grid1.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        Grid1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        Grid1.Columns(3).Width = 130
        Grid1.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Grid1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        Grid1.Columns(4).Width = 130
        Grid1.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Grid1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        Grid1.Columns(5).Width = 120
        Grid1.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Grid1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Grid1.Columns(6).Width = 120
        Grid1.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Grid1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Grid1.Columns(7).Width = 120
        Grid1.Columns(7).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Grid1.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        Grid1.Columns(8).Width = 120
        Grid1.Columns(8).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Grid1.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Grid1.Columns(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Grid1.Columns(9).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        Grid1.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        Grid1.Columns(10).Width = 80
        Grid1.Columns(10).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Grid1.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Grid1.Columns(10).Visible = False

        Dim chk As New DataGridViewCheckBoxColumn()
        Grid1.Columns.Add(chk)
        Grid1.Columns(11).Width = 30
        Grid1.Columns(11).Visible = False

        If Narration_ = True Then
            Grid1.Columns(9).DisplayIndex = 3
            Grid1.Columns(2).Width = 350
            Grid1.Columns(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            'Grid1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            Grid1.Columns(9).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        Else
            Grid1.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            Grid1.Columns(9).DefaultCellStyle.WrapMode = DataGridViewTriState.False
        End If

        Grid1.Columns(5).DefaultCellStyle.Format = "N2"
        Grid1.Columns(6).DefaultCellStyle.Format = "N2"



        BG_Panel.BringToFront()

        Grid1.Focus()
        If Grid1.Rows.Count > 0 Then
            Grid1.CurrentCell = Grid1.Rows(0).Cells(1)
        End If

        Try
            Grid1.CurrentCell = Grid1.Rows(Val(Defolt_Select_ID)).Cells(1)
        Catch ex As Exception

        End Try
    End Function
    Private Function Qry_Filters() As String
        Dim q As String
        q = $"and (vc.Date BETWEEN '{CDate(Frm_date).ToString(Lite_date_Format)}' and '{CDate(to_date).AddDays(1).ToString(Lite_date_Format)}')"

        If Dft_Voucher <> "All Vouchers" Then
            q &= $" AND vc.Voucher_Type = '{Dft_Voucher}'"
        End If
        If Dft_Branch <> "Primary" Then
            q &= " AND VC.Branch = '" & Find_DT_Value(Database_File.cre, "TBL_Ledger", "ID", "Name = '" & Dft_Branch & "'") & "'"
        End If
        q &= " AND (VC.Visible <> 'Delete')"

        Return q
    End Function
    Private Function Fill_oTher_Group(dt As DataTable, Closing_ As String)

        Dim Date_Sorting_code As String = ""
        If Sorting_Methoud_ = "Date (Decreasing)" Then
            Date_Sorting_code = "DESC"
        End If


        dt_print.Rows.Clear()
        dt_print = ds_print.Tables("TBL_DayBook")
        Dim dr_print As DataRow

        Dim cn As New SQLiteConnection
        Dim dr As DataRow
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select * From 
(Select 'Head' as Type,vc.Tra_ID,vc.Voucher_Type,vc.Voucher_No,vc.Date,vc.Voucher_Type_ID,vc.Visible,vc.Credit_Amount,vc.Debit_Amount,vc.Narration,
'' as Unit,
(Select ld.name From TBL_Ledger ld where ld.id = vc.Ledger) as Ledger_Name,
(Select ld.name From TBL_Payroll_Employee ld where ld.id = vc.Employee) as Employee_Name,
(Select i.name From TBL_Stock_Item i where i.id = (Select vi.Item From TBL_VC_Item_Details vi where vi.Tra_ID = vc.Tra_ID limit 1)) as Item_Name
From TBL_VC vc where vc.Tra_ID <> '0' {Qry_Filters()}

UNION ALL

Select 'Item',vi.Tra_ID,'','',vi.[Date],'','',vi.Amount,'','',
'',
(Select i.name From TBL_Stock_Item i where i.id = vi.Item) as Ledger_Name,
'' as Employee_Name,
'' as Item_Name
From TBL_VC_item_Details vi
Left Join TBL_VC vc on vc.Tra_ID = vi.Tra_ID
where vc.Tra_ID <> '0' {Qry_Filters()}

UNION ALL

Select 'Ledger',vl.Tra_ID,'','',vl.[Date],'','',vl.Cr,vl.Dr,'',
'',
(Select ld.name From TBL_Ledger ld where ld.id = vl.Ledger) as Ledger_Name,
'' as Employee_Name,
'' as Item_Name
From TBL_VC_Ledger vl
Left Join TBL_VC vc on vc.Tra_ID = vl.Tra_ID
where (vl.Type = 'Under' or vl.Type = 'Exp') {Qry_Filters()}

UNION ALL

Select 'Attendance',vc.Tra_ID,'','',vt.[Date],'','',vt.Value,'0','',
(Select U.Symbol From TBL_Inventory_Unit U Where U.ID = att.Unit) as Unit,
'' as Ledger_Name,
(Select e.name From TBL_Payroll_Employee e where e.id = vt.Employee) as Employee_Name,
att.Name as Item_Name
From TBL_Attendance_VC vt
Left Join TBL_VC vc on vc.Tra_ID = vt.Tra_ID
Left Join TBL_Payroll_Att_Production_Type att on vc.Tra_ID = vt.Tra_ID
where (vt.Employee <> '') {Qry_Filters()}

UNION ALL

Select 'Payroll',vc.Tra_ID,'','',vp.[Date],'','',vp.Cr,vp.Dr,'',
'',
'' as Ledger_Name,
(Select e.name From TBL_Payroll_Employee e where e.id = vp.Employee) as Employee_Name,
(Select e.name From TBL_Payhead e where e.id = vp.Payhead) as Item_Name
From TBL_VC_Payroll vp
Left Join TBL_VC vc on vc.Tra_ID = vp.Tra_ID
where (vp.Employee <> '') {Qry_Filters()}

)
Order By [Date] {Date_Sorting_code},Tra_ID", cn)


            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            'My.Computer.Clipboard.SetText(cmd.CommandText)
            While r.Read
                Dim Tra_id As String = r("Tra_ID").ToString
                Dim Type_ As String = r("Type").ToString
                Dim Voucher_Type As String = r("Voucher_Type").ToString
                Dim Voucher_No As String = r("Voucher_No").ToString
                Dim Date_ As String = CDate(r("Date").ToString).ToString(Date_Format_fech)
                Dim Ledger_ As String = r("Ledger_Name").ToString

                If (YN_Details = True) Or (YN_Details = False And Type_ = "Head") Then

                    dr = dt.NewRow
                    dr("Tra_ID") = Tra_id
                    dr("Type") = Type_
                    dr("Date") = Date_Formate(Date_)
                    dr("Voucher Type") = Voucher_Type
                    dr("Voucher No.") = Voucher_No
                    dr("VC_ID") = r("Voucher_Type_ID")

                    If r("Visible") = "Approval" Then
                        dr("Status") = "Active"
                    Else
                        dr("Status") = r("Visible").ToString
                    End If

                    If Type_ = "Head" Then
                        dr("Credit") = nUmBeR_FORMATE(r("Credit_Amount").ToString)
                        dr("Debit") = nUmBeR_FORMATE(r("Debit_Amount").ToString)
                    ElseIf Type_ = "Ledger" Then
                        dr("Credit") = 0
                        dr("Debit") = 0
                        If Val(r("Debit_Amount").ToString) <> 0 Then
                            Ledger_ = $"{Ledger_} - [{N2_FORMATE(r("Debit_Amount").ToString)} {Negative_Value_fech}]"
                        ElseIf Val(r("Credit_Amount").ToString) <> 0 Then
                            Ledger_ = $"{Ledger_} - [{N2_FORMATE(r("Credit_Amount").ToString)} {Positive_Value_fech}]"
                        End If
                    ElseIf Type_ = "Item" Then
                        If r("Voucher_Type").ToString = "Stock Journal" Then
                            Ledger_ = $"{Ledger_}"
                        Else
                            Ledger_ = $"{Ledger_} - [{N2_FORMATE(r("Credit_Amount").ToString)}₹]"
                        End If
                    ElseIf Type_ = "Attendance" Then
                        Dim U As String = r("Unit").ToString
                        Ledger_ = $"{r("Employee_Name").ToString} - {r("Item_Name").ToString} - [{N2_FORMATE(r("Credit_Amount").ToString)} {U}]"
                    ElseIf Type_ = "Payroll" Then
                        If Val(r("Debit_Amount").ToString) <> 0 Then
                            Ledger_ = $"{r("Employee_Name").ToString} - {r("Item_Name").ToString} - [{N2_FORMATE(r("Debit_Amount").ToString)} {Negative_Value_fech}]"
                        ElseIf Val(r("Credit_Amount").ToString) <> 0 Then
                            Ledger_ = $"{r("Employee_Name").ToString} - {r("Item_Name").ToString} - [{N2_FORMATE(r("Credit_Amount").ToString)} {Positive_Value_fech}]"
                        End If
                    End If
                    If Ledger_ = Nothing Then
                        Ledger_ = r("Item_Name").ToString
                    End If
                    If Ledger_ = Nothing Then
                        Ledger_ = r("Employee_Name").ToString
                    End If

                    dr("Particulars") = Ledger_


                    dt.Rows.Add(dr)

                    If Defolt_Select_ID = Tra_id Then
                        Defolt_Select_ID = dt.Rows.Count - 1
                    End If


                    If Narration_ = True Then
                        dr = dt.NewRow
                        dr("Tra_ID") = Tra_id
                        dr("Type") = "Narration"
                        dr("Date") = Date_Formate(Date_)
                        dr("Particulars") = r("Narration")
                        dr("Voucher Type") = ""
                        dr("Voucher No.") = ""
                        dr("VC_ID") = ""
                        dr("Status") = "Active"
                        'dr("Credit_Amount") = "0.00"
                        If r("Narration").ToString.Trim <> Nothing Then
                            dt.Rows.Add(dr)
                        End If
                    End If

                    'Prin_Data Fill
                    dr_print = dt_print.NewRow
                    dr_print("Type") = Type_



                    If Type_ = "Head" Then
                        dr_print("Date") = Date_Formate(Date_)
                        dr_print("Voucher_Type") = Voucher_Type
                        dr_print("Voucher_No") = Voucher_No
                        dr_print("Particulars") = Ledger_
                        If Narration_ = True And r("Narration").ToString <> Nothing Then
                            dr_print("Narration") = vbNewLine & r("Narration").ToString
                        End If
                        dr_print("Credit") = Val(r("Credit_Amount").ToString)
                        dr_print("Debit") = Val(r("Debit_Amount").ToString)
                        dt_print.Rows.Add(dr_print)
                    Else
                        dr_print("Date") = ""
                        dr_print("Voucher_Type") = ""
                        dr_print("Voucher_No") = ""
                        dr_print("Under") = $"     {Ledger_}"
                        dr_print("Credit") = Val(r("Credit_Amount").ToString)
                        dr_print("Debit") = Val(r("Debit_Amount").ToString)
                        dt_print.Rows.Add(dr_print)
                    End If


                End If




            End While
        End If
    End Function
    Dim cfg_print_path As String
    Dim rdlc_report_name As String
    Dim rdlc_report_data() As ReportDataSource
    Private Function Print_data_fill()
        rdlc_report_name = $"DayBook ({Frm_date.ToString("dd-MMM-yyyy")} to {to_date.ToString("dd-MMM-yyyy")})"
        rdlc_report_name = path_validation(rdlc_report_name, "-")

        rdlc_report_data = {New ReportDataSource("dt_daybook", dt_print), New ReportDataSource("dt_cmp", Print_DT_Company)}

    End Function
    Private Sub Frm_Date_LB_Click(sender As Object, e As EventArgs) Handles Frm_Date_LB.Click

    End Sub
    Private Sub Frm_Date_LB_TextChanged(sender As Object, e As EventArgs) Handles Frm_Date_LB.TextChanged
        Frm_date = Frm_Date_LB.Text
    End Sub
    Private Sub To_Date_LB_TextChanged(sender As Object, e As EventArgs) Handles To_Date_LB.TextChanged
        to_date = To_Date_LB.Text
    End Sub

    Private Sub Grid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid1.CellContentClick

    End Sub

    Private Sub Grid1_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles Grid1.RowsAdded
        'Grid1.Rows(Grid1.Rows.Count - 1).Height = 18
    End Sub

    Private Sub Day_Book_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub Day_Book_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        Add_Hander_Remove_Handel(False)
        BG_frm.BG_Path_TXT.Text = Path_End
        Frm_foCus()
    End Sub

    Private Sub Day_Book_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.HADE_TXT.Text = "Day Book"
        BG_frm.TYP_TXT.Text = VC_Type_

        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text


        Button_Clear()
        Button_Manage()
        cfg_fill()
        If Update_Report = True Then
            Fill_Grid()
        End If
        Grid1.Focus()
    End Sub
    Private Function cfg_fill()
        Create_Database_Table()

        Try
            cfg_print_path = Find_DT_Value(Database_File.lnk, "cfg_DayBook", "Value", "Head = 'Print_Path'")
            'cfg_print_path = cfg_print_path.Replace(".rdlc", "")
        Catch ex As Exception
            cfg_print_path = ""
        End Try

        If cfg_print_path = Nothing Then
            cfg_print_path = Application.StartupPath & "\Print_\Report\DayBook\DayBook"
        End If
        Label17.Visible = Branch_Visible()
    End Function
    Public Function Create_Database_Table()
        Dim cn As New SQLiteConnection
        Dim create_ As Boolean = False
        If open_MSSQL_Cstm(Database_File.lnk, cn) = True Then
            cmd = New SQLiteCommand("SELECT count(*) as c FROM sqlite_master WHERE type='table' AND name='cfg_DayBook'", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                If r("c") <> 1 Then
                    create_ = True
                End If
            End While
            r.Close()


            If create_ = True Then
                cmd = New SQLiteCommand("CREATE TABLE 'cfg_DayBook' (
	'Id'	INTEGER NOT NULL UNIQUE,
	'Head'	TEXT,
	'Value'	TEXT,
	PRIMARY KEY('Id' AUTOINCREMENT));", cn)

                cmd.ExecuteNonQuery()
            End If
        End If
    End Function
    Private Sub Grid1_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid1.KeyDown
        If e.KeyCode = Keys.Enter Then
            BG_frm.B_1.PerformClick()
            e.Handled = True
        End If
    End Sub
    Private Sub Grid1_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles Grid1.RowPrePaint
        Dim ro As DataGridViewRow = Grid1.Rows(e.RowIndex)
        If ro.Cells(0).Value = "Head" Then
            If YN_Details = True Then
                ro.DefaultCellStyle.Font = New Font("Arial", 9.75!, FontStyle.Bold)
            End If
        ElseIf ro.Cells(0).Value = "Item" Or ro.Cells(0).Value = "Ledger" Or ro.Cells(0).Value = "Payroll" Or ro.Cells(0).Value = "Attendance" Then

            If ro.Cells(10).Value <> "Delete" Then
                ro.DefaultCellStyle.ForeColor = Color.DimGray
            End If

            ro.DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Regular)
            ro.Cells(1).Style.SelectionBackColor = Color.White
            ro.Cells(1).Style.ForeColor = Color.White
            ro.Cells(1).Style.SelectionForeColor = Color.White
        ElseIf ro.Cells(0).Value = "Narration" Then
            Grid1.DefaultCellStyle.WrapMode = DataGridViewTriState.True
            Grid1.AutoResizeRow(e.RowIndex)

            If ro.Cells(10).Value <> "Delete" Then
                ro.DefaultCellStyle.ForeColor = Color.DimGray
            End If

            ro.DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Italic)
            ro.Cells(1).Style.SelectionBackColor = Color.White
            ro.Cells(1).Style.ForeColor = Color.White
            ro.Cells(1).Style.SelectionForeColor = Color.White
            ro.Cells(2).Style.Padding = New Padding(20, 0, 0, 0)
        End If

        If Grid1.Rows(e.RowIndex).Cells(11).Value = True Then
            ro.DefaultCellStyle.BackColor = Color_SELECT_back
            ro.DefaultCellStyle.ForeColor = Color_SELECT_fonr
        Else
            If Val(ro.Cells(5).Value.ToString) = 0 Then
                ro.Cells(5).Style.SelectionBackColor = Color.FromArgb(254, 197, 48)
                ro.Cells(5).Style.ForeColor = Color.White
                ro.Cells(5).Style.SelectionForeColor = Color.FromArgb(254, 197, 48)
            End If
            If Val(ro.Cells(6).Value.ToString) = 0 Then
                ro.Cells(6).Style.SelectionBackColor = Color.FromArgb(254, 197, 48)
                ro.Cells(6).Style.ForeColor = Color.White
                ro.Cells(6).Style.SelectionForeColor = Color.FromArgb(254, 197, 48)
            End If
            ro.DefaultCellStyle.BackColor = Color.White
            ro.DefaultCellStyle.SelectionBackColor = Color.FromArgb(254, 197, 48)
        End If

        If ro.Cells(10).Value = "Delete" Then
            ro.DefaultCellStyle.ForeColor = Color.Red
        End If
    End Sub
    Public Sub DrawLinePoint(ByVal e As PaintEventArgs)
        If Grid1.Columns.Count <> 0 Then
            Dim blackPen As New Pen(Color.Gray, 1)

            Dim x As Decimal = Val(Grid1.Columns(1).Width)
            Dim point1 As New Point(x, 0)
            Dim point2 As New Point(x, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)

            x = Val(Grid1.Columns(1).Width) + Val(Grid1.Columns(2).Width)
            point1 = New Point(x, 0)
            point2 = New Point(x, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)

            x = Val(Grid1.Columns(1).Width) + Val(Grid1.Columns(2).Width) + Val(Grid1.Columns(3).Width)
            point1 = New Point(x, 0)
            point2 = New Point(x, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)

            x = Val(Grid1.Columns(1).Width) + Val(Grid1.Columns(2).Width) + Val(Grid1.Columns(3).Width) + Val(Grid1.Columns(4).Width)
            point1 = New Point(x, 0)
            point2 = New Point(x, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)

            x = Val(Grid1.Columns(1).Width) + Val(Grid1.Columns(2).Width) + Val(Grid1.Columns(3).Width) + Val(Grid1.Columns(4).Width) + Val(Grid1.Columns(5).Width)
            point1 = New Point(x, 0)
            point2 = New Point(x, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)

            x = Val(Grid1.Columns(1).Width) + Val(Grid1.Columns(2).Width) + Val(Grid1.Columns(3).Width) + Val(Grid1.Columns(4).Width) + Val(Grid1.Columns(5).Width) + Val(Grid1.Columns(4).Width) + Val(Grid1.Columns(6).Width)
            point1 = New Point(x, 0)
            point2 = New Point(x, Grid1.Height)
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

    Private Sub Day_Book_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        Grid1.Focus()
        BG_frm.From_ID = From_ID

    End Sub
End Class