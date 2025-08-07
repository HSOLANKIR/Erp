Imports System.ComponentModel
Imports System.Data.SQLite

Public Class Display_List
    Dim From_ID As String
    Dim Path_End As String
    Dim VC_Type_ As String
    Dim VC_ID_ As String
    Dim VC_OPen_frm As String
    'Dim BS As New BindingSource
    Dim Other_Parameters As String
    Dim SOurce_str As String
    Private Sub Display_List_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text

        VC_Type_ = Link_Valu(1)
        VC_ID_ = Link_Valu(2)
        Other_Parameters = Link_Valu(4)
        SOurce_str = Link_Valu(3)

        VC_OPen_frm = String_Part_(Link_Valu(2), ">")(1)


        BG_frm.HADE_TXT.Text = "Display List"
        BG_frm.TYP_TXT.Text = VC_Type_

        Create_Database_Table()

        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text

        'BS = bIndingsource_fInd(Link_Valu(3))

        Fill_Source()
        List_Fill()

        TX.Focus()

        Button_Manage()
        Add_Hander_Remove_Handel(True)


    End Sub
    Private Function Button_Manage()
        Button_Clear()
        If BG_frm.From_ID = From_ID Then
            BG_frm.R_22.Text = "F12 : Configuration"
        End If
    End Function
    Private Function Add_Hander_Remove_Handel(Ans As Boolean)
        If BG_frm.From_ID = From_ID Then
            If Ans = True Then
                AddHandler BG_frm.R_22.Click, AddressOf Me.DAL_F12
                AddHandler Me.KeyDown, AddressOf Me.DAL_KeyDown
            Else
                RemoveHandler Me.KeyDown, AddressOf Me.DAL_KeyDown
                RemoveHandler BG_frm.R_22.Click, AddressOf Me.DAL_F12
            End If
        End If
    End Function
    Private Sub DAL_KeyDown(sender As Object, e As KeyEventArgs)
        If VC_OPen_frm = "Report Ledger" And Me.Visible = True Then
            If e.KeyCode = Keys.F12 Then
                BG_frm.R_22.PerformClick()
            End If
        End If
    End Sub
    Private Sub DAL_F12(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Dim obj_bg As Object = Cell("Configuration", "")
            Dim obj As Object = New Report_Ladger_list_cfg
            obj_bg.Set_Cfg(obj)
        End If
    End Sub
    Private Sub Display_List_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.HADE_TXT.Text = "Display List"
        BG_frm.TYP_TXT.Text = VC_Type_


        'BS = bIndingsource_fInd(Link_Valu(3))

        Fill_Source()
        'List_Fill()

        Button_Clear()
        Refresh_()
        TX.Focus()
    End Sub
    Private Function Fill_Source()
        Managment_data_fill()
        Fill_Laboratry_data()
    End Function
    Private Function Fill_Laboratry_data()
        Dim cn As New SQLiteConnection
        Dim dt As New DataTable

        If SOurce_str = "Laboratory_Doctor" Then
            dt.Columns.Add("ID")
            dt.Columns.Add("Name")
            dt.Columns.Add("Hospital")

            If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                cmd = New SQLiteCommand("Select * From TBL_Ledger ld
LEFT JOIN TBL_Acc_Group ag on ag.id = ld.[Group]
where ld.Visible = 'Approval' and ag.Name = 'Doctor'", cn)
                Dim r As SQLiteDataReader
                r = cmd.ExecuteReader
                While r.Read
                    dt.Rows.Add(r("ID"), r("Name"), r("Alise"))
                    If return_id = r("ID") Then
                        return_id = dt.Rows.Count
                    End If
                End While

                BS.DataSource = dt
            End If
        ElseIf SOurce_str = "Laboratory_Unit" Then
            dt.Columns.Add("ID")
            dt.Columns.Add("Name")
            dt.Columns.Add("FormalName")
            If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                cmd = New SQLiteCommand("Select * From TBL_Inventory_Unit u
where u.Visible = 'Approval'", cn)
                Dim r As SQLiteDataReader
                r = cmd.ExecuteReader
                While r.Read
                    dt.Rows.Add(r("ID"), r("Symbol"), r("Formal_Name"))
                    If return_id = r("ID") Then
                        return_id = dt.Rows.Count
                    End If
                End While

                BS.DataSource = dt
            End If
        ElseIf SOurce_str = "Laboratory_Item" Then
            dt.Columns.Add("ID")
            dt.Columns.Add("Name")
            dt.Columns.Add("Alias")
            If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                cmd = New SQLiteCommand("Select * From TBL_Stock_Item it
where it.Visible = 'Approval'", cn)
                Dim r As SQLiteDataReader
                r = cmd.ExecuteReader
                While r.Read
                    dt.Rows.Add(r("ID"), r("Name"), r("Alias"))
                    If return_id = r("ID") Then
                        return_id = dt.Rows.Count
                    End If
                End While

                BS.DataSource = dt
            End If

        ElseIf SOurce_str = "Laboratory_Group" Then
            dt.Columns.Add("ID")
            dt.Columns.Add("Name")
            dt.Columns.Add("Alias")
            If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                cmd = New SQLiteCommand("Select * From TBL_Laboratry_Group g
where g.Visible = 'Approval'", cn)
                Dim r As SQLiteDataReader
                r = cmd.ExecuteReader
                While r.Read
                    dt.Rows.Add(r("ID"), r("Name"), r("Alias"))
                    If return_id = r("ID") Then
                        return_id = dt.Rows.Count
                    End If
                End While

                BS.DataSource = dt
            End If

        End If
    End Function
    Private Function Managment_data_fill()
        Dim cn As New SQLiteConnection
        Dim dt As New DataTable
        Dim dr As DataRow

        Dim r As SQLiteDataReader

        dt.Columns.Add("ID")
        dt.Columns.Add("Name")
        dt.Columns.Add("Alias")
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            If SOurce_str = "Acc_Group_BS" Then
                cmd = New SQLiteCommand("Select * From TBL_Acc_Group where (Company = 'All' or Company = '" & Company_ID_str & "') and Visible = 'Approval'", cn)
                r = cmd.ExecuteReader
                While r.Read
                    dr = dt.NewRow
                    dr("ID") = r("ID")
                    dr("Name") = r("Name")
                    dr("Alias") = r("Nickname")
                    dt.Rows.Add(dr)
                End While

                BS.DataSource = dt
            ElseIf SOurce_str = "Ledger_BS" Then
                cmd = New SQLiteCommand("Select *,(Select ag.Name From TBL_Acc_Group ag where ag.id = ld.[Group]) as Under_Name From TBL_Ledger ld WHERE Visible = 'Approval'", cn)
                r = cmd.ExecuteReader
                While r.Read
                    dr = dt.NewRow
                    dr("ID") = r("ID")
                    dr("Name") = r("Name")
                    dr("Alias") = r("Under_Name")
                    dt.Rows.Add(dr)
                End While

                BS.DataSource = dt
            ElseIf SOurce_str = "All_Unit_BS" Then
                cmd = New SQLiteCommand("Select * From TBL_Inventory_Unit where " & Company_Visible_Filter(), cn)
                r = cmd.ExecuteReader
                While r.Read
                    dr = dt.NewRow
                    dr("ID") = r("ID")
                    If r("Type") = "Compound" Then
                        dr("Name") = Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "Symbol", "ID = '" & r("Unit1") & "'") & " of " & r("Conversion") & " " & Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "Symbol", "ID = '" & r("Unit2") & "'")
                    Else
                        dr("Name") = r("Symbol")
                    End If
                    dr("Alias") = r("Formal_Name")
                    dt.Rows.Add(dr)
                End While

                BS.DataSource = dt

            ElseIf SOurce_str = "Stock_Unit_BS" Then
                cmd = New SQLiteCommand("Select * From TBL_Inventory_Unit where Head = 'Stock' and " & Company_Visible_Filter(), cn)
                r = cmd.ExecuteReader
                While r.Read
                    dr = dt.NewRow
                    dr("ID") = r("ID")
                    If r("Type") = "Compound" Then
                        dr("Name") = Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "Symbol", "ID = '" & r("Unit1") & "'") & " of " & r("Conversion") & " " & Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "Symbol", "ID = '" & r("Unit2") & "'")
                    Else
                        dr("Name") = r("Symbol")
                    End If
                    dr("Alias") = r("Formal_Name")
                    dt.Rows.Add(dr)
                End While

                BS.DataSource = dt

            ElseIf SOurce_str = "Payroll_Unit_BS" Then
                cmd = New SQLiteCommand("Select * From TBL_Inventory_Unit where Head = 'Payroll' and " & Company_Visible_Filter(), cn)
                r = cmd.ExecuteReader
                While r.Read
                    dr = dt.NewRow
                    dr("ID") = r("ID")
                    If r("Type") = "Compound" Then
                        dr("Name") = Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "Symbol", "ID = '" & r("Unit1") & "'") & " of " & r("Conversion") & " " & Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "Symbol", "ID = '" & r("Unit2") & "'")
                    Else
                        dr("Name") = r("Symbol")
                    End If
                    dr("Alias") = r("Formal_Name")
                    dt.Rows.Add(dr)
                End While

                BS.DataSource = dt


            ElseIf SOurce_str = "Stock_Group_BS" Then
                cmd = New SQLiteCommand("Select * From TBL_Stock_Group where (Head = 'Stock' or Head = 'All') and Visible = 'Approval'", cn)
                r = cmd.ExecuteReader
                While r.Read
                    dr = dt.NewRow
                    dr("Name") = r("Name")
                    dr("ID") = r("ID")
                    dr("Alias") = r("Nickname")
                    dt.Rows.Add(dr)
                End While

                BS.DataSource = dt
            ElseIf SOurce_str = "Payroll_Group_BS" Then
                cmd = New SQLiteCommand("Select * From TBL_Stock_Group where (Head = 'Payroll' or Head = 'All') and Visible = 'Approval'", cn)
                r = cmd.ExecuteReader
                While r.Read
                    dr = dt.NewRow
                    dr("Name") = r("Name")
                    dr("ID") = r("ID")
                    dr("Alias") = r("Nickname")
                    dt.Rows.Add(dr)
                End While

                BS.DataSource = dt
            ElseIf SOurce_str = "Payroll_Employee_BS" Then
                cmd = New SQLiteCommand("Select * From TBL_Payroll_Employee where " & Company_Visible_Filter(), cn)
                r = cmd.ExecuteReader
                While r.Read
                    dr = dt.NewRow
                    dr("Name") = r("Name")
                    dr("ID") = r("ID")
                    dr("Alias") = r("Alias")
                    dt.Rows.Add(dr)
                End While

                BS.DataSource = dt
            ElseIf SOurce_str = "Payroll_Att_Production_Type_BS" Then
                cmd = New SQLiteCommand("Select * From TBL_Payroll_Att_Production_Type where " & Company_Visible_Filter(), cn)
                r = cmd.ExecuteReader
                While r.Read
                    dr = dt.NewRow
                    dr("Name") = r("Name")
                    dr("ID") = r("ID")
                    dr("Alias") = r("alias")
                    dt.Rows.Add(dr)
                End While

                BS.DataSource = dt
            ElseIf SOurce_str = "Payroll_Payhead_BS" Then
                cmd = New SQLiteCommand("Select * From TBL_PayHead where " & Company_Visible_Filter(), cn)

                r = cmd.ExecuteReader
                While r.Read
                    dr = dt.NewRow
                    dr("Name") = r("Name")
                    dr("ID") = r("ID")
                    dr("Alias") = r("alias")
                    dt.Rows.Add(dr)
                End While

                BS.DataSource = dt
            ElseIf SOurce_str = "Pay_Slip_Summary_BS" Then
                cmd = New SQLiteCommand($"Select ID,Name,'Group' as Type From TBL_Stock_Group where Head = 'Payroll' and {Company_Visible_Filter()}
UNION ALL
Select ID,Name,'Employee' as Type From TBL_Payroll_Employee where {Company_Visible_Filter()}", cn)

                r = cmd.ExecuteReader
                dt.Rows.Add("0", "All Employee", "")
                While r.Read
                    dr = dt.NewRow
                    dr("Name") = r("Name")
                    dr("ID") = r("ID")
                    dr("Alias") = r("Type")
                    dt.Rows.Add(dr)
                End While

                BS.DataSource = dt
            ElseIf SOurce_str = "Stock_Item_BS" Then
                cmd = New SQLiteCommand($"Select * From TBL_Stock_Item it where it.Visible = 'Approval'", cn)

                r = cmd.ExecuteReader
                While r.Read
                    dr = dt.NewRow
                    dr("Name") = r("Name")
                    dr("ID") = r("ID")
                    dr("Alias") = r("Alias")
                    dt.Rows.Add(dr)
                End While

                BS.DataSource = dt
            ElseIf SOurce_str = "Stock_Category_BS" Then
                cmd = New SQLiteCommand($"Select * From TBL_Stock_Category it where it.Visible = 'Approval'", cn)

                r = cmd.ExecuteReader
                While r.Read
                    dr = dt.NewRow
                    dr("Name") = r("Name")
                    dr("ID") = r("ID")
                    dr("Alias") = r("Nickname")
                    dt.Rows.Add(dr)
                End While

                BS.DataSource = dt
            ElseIf SOurce_str = "Stock_Godown" Then
                cmd = New SQLiteCommand($"Select * From TBL_Stock_Godown it where it.Visible = 'Approval'", cn)

                r = cmd.ExecuteReader
                While r.Read
                    dr = dt.NewRow
                    dr("Name") = r("Name")
                    dr("ID") = r("ID")
                    dr("Alias") = r("Nickname")
                    dt.Rows.Add(dr)
                End While

                BS.DataSource = dt
            ElseIf SOurce_str = "Voucher_Data_BS" Then
                cmd = New SQLiteCommand($"Select * From TBL_Voucher_Create v where v.Visible = 'Approval'", cn)

                r = cmd.ExecuteReader
                While r.Read
                    dr = dt.NewRow
                    dr("Name") = r("Name")
                    dr("ID") = r("ID")
                    dr("Alias") = r("Alias")
                    dt.Rows.Add(dr)
                End While
                BS.DataSource = dt
            ElseIf SOurce_str = "Transport_BS" Then
                cmd = New SQLiteCommand($"Select * From TBL_Tranport v where v.Visible = 'Approval'", cn)

                r = cmd.ExecuteReader
                While r.Read
                    dr = dt.NewRow
                    dr("Name") = r("Name")
                    dr("ID") = r("ID")
                    dr("Alias") = r("Vehicle_No")
                    dt.Rows.Add(dr)
                End While
                BS.DataSource = dt
            ElseIf SOurce_str = "WhatsApp_Templates_bs" Then
                cmd = New SQLiteCommand($"Select * From TBL_WhatsApp_Temp", cn)

                r = cmd.ExecuteReader
                While r.Read
                    dr = dt.NewRow
                    dr("Name") = r("Name")
                    dr("ID") = r("ID")
                    dr("Alias") = r("WhatsApp_Number")
                    dt.Rows.Add(dr)
                End While
                BS.DataSource = dt

            ElseIf SOurce_str = "DAL_bs" Then
                cmd = New SQLiteCommand($"Select * From TBL_Ledger ld 
Left Join TBL_Acc_Group ag on ag.ID = ld.[Group]
Where ({DAL_Filter()}) and ld.Visible = 'Approval'", cn)

                r = cmd.ExecuteReader
                While r.Read
                    dr = dt.NewRow
                    dr("Name") = r("Name")
                    dr("ID") = r("ID")
                    dr("Alias") = r("Alise")
                    dt.Rows.Add(dr)
                End While
                BS.DataSource = dt

            ElseIf SOurce_str = "List_Bank" Then
                cmd = New SQLiteCommand($"Select * From TBL_Ledger ld 
Left Join TBL_Acc_Group ag on ag.ID = ld.[Group]
Where (ld.Visible = 'Approval' and ag.ID = '28')", cn)

                r = cmd.ExecuteReader
                While r.Read
                    dr = dt.NewRow
                    dr("Name") = r("Name")
                    dr("ID") = r("ID")
                    dr("Alias") = r("Alise")
                    dt.Rows.Add(dr)
                End While
                BS.DataSource = dt




            End If
        End If
    End Function
    Private Function DAL_Filter() As String
        Dim str As String = $"(ld.[Group] = '1' or ld.[Group] = '22' or ld.[Group] = '26' or ld.[Group] = '27'"

        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.lnk, cn) = True Then
            cmd = New SQLiteCommand("Select * From cfg_Accounting_Report_list Where Value = 'Yes'", cn)
            Dim r As SQLiteDataReader = cmd.ExecuteReader
            While r.Read
                str &= $" OR ag.[Name] = '{r("Head")}'"

            End While
        End If
        str &= ")"

        Return str
    End Function
    Private Sub Display_List_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub Display_List_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        Add_Hander_Remove_Handel(False)
        BG_frm.BG_Path_TXT.Text = Path_End
        Frm_foCus()
    End Sub
    Dim return_id As String = 0
    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TX.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            return_id = me_list.List_Grid.CurrentRow.Cells("ID").Value.ToString
            Cell(VC_OPen_frm, "", VC_Type_, me_list.List_Grid.CurrentRow.Cells("ID").Value.ToString, Other_Parameters)
            SendKeys.Send("{BACKSPACE}")
        End If
    End Sub
    Public me_list As List_frm
    Private Function List_Fill()
        TX.Select_Filter = "Name Like '%<value>%' AND (Name <> 'Primary' And Name <> 'End of List') And Name <> '(Not Applicable)'"

        obj_top(Panel2)

        me_list = New List_frm
        List_Setup("Display of List", Select_List.Botom_Center, Select_List_Format.Custome, TX, me_list, BS, TX.Width + 300)

        Refresh_()


    End Function
    Private Function Refresh_()


        With me_list.List_Grid
            '.DataSource = BS
            For c As Integer = 0 To .Columns.Count - 1
                .Columns(c).Visible = False
            Next
            .Columns(1).Visible = True
            .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill


            If return_id <= .Rows.Count - 1 Then
                .CurrentCell = .Rows(return_id).Cells(1)
            End If

            '.Sort(.Columns("Name"), ListSortDirection.Ascending)
        End With


    End Function

    Private Sub Display_List_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        TX.Focus()
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint
        obj_top(Panel2)
    End Sub

    Private Sub TX_Enter(sender As Object, e As EventArgs) Handles TX.Enter
        If sender.Text = Nothing Then
            SendKeys.Send(" ")
            SendKeys.Send("{BACKSPACE}")

        End If
    End Sub

    Private Sub TX_TextChanged(sender As Object, e As EventArgs) Handles TX.TextChanged

    End Sub
    Public Function Create_Database_Table()
        Dim cn As New SQLiteConnection
        Dim create_ As Boolean = False


        If BG_frm.From_ID = From_ID Then
            If open_MSSQL_Cstm(Database_File.lnk, cn) = True Then
                cmd = New SQLiteCommand("SELECT count(*) as c FROM sqlite_master WHERE type='table' AND name='cfg_Accounting_Report_list'", cn)
                Dim r As SQLiteDataReader
                r = cmd.ExecuteReader
                While r.Read
                    If r("c") <> 1 Then
                        create_ = True
                    End If
                End While
                r.Close()


                If create_ = True Then
                    cmd = New SQLiteCommand("CREATE TABLE 'cfg_Accounting_Report_list' (
	'Id'	INTEGER NOT NULL UNIQUE,
	'Head'	TEXT,
	'Value'	TEXT,
	PRIMARY KEY('Id' AUTOINCREMENT));", cn)

                    cmd.ExecuteNonQuery()
                End If
            End If
        End If
    End Function
End Class