Imports System.Data.SqlClient
Imports System.Data.SQLite

Public Class Paysheet_frm
    Dim From_ID As String
    Private VC_Type_ As String
    Private VC_ID_ As String
    Private Path_End As String
    Dim YN_Details As Boolean
    Dim Acc_Under As String
    Dim Frm_date As Date
    Dim to_date As Date

    Public Branch As String = "Primary"
    Public Voucher_Type As String = "All Vouchers"
    Public Narration_ As Boolean = False
    Public Delete_Entry = False
    Public Branch_ID As String

    Dim ds_print As New Print_dt
    Dim dt_print As New DataTable
    Private Sub Paysheet_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID
        Path_End = BG_frm.BG_Path_TXT.Text

        VC_Type_ = Link_Valu(1)
        VC_ID_ = Link_Valu(2)

        Frm_Date_LB.Text = Date_Formate(Date_1)
        To_Date_LB.Text = Date_Formate(Date_2)

        BG_frm.HADE_TXT.Text = "Pay Sheet"
        BG_frm.TYP_TXT.Text = VC_Type_

        Button_Manage()
        Add_Hander_Remove_Handel(True)
        Branch = Branch_Name
        Branch_ID = Set_Branch()

        Label17.Text = Branch
        Update_Report = True
    End Sub
    Private Function Button_Manage()
        Button_Clear()
        BG_frm.B_1.Text = "|&R : Refresh"
        BG_frm.B_2.Text = "|&A : Add Voucher"
        BG_frm.B_3.Text = "|&P : Print"
        BG_frm.B_4.Text = "|Space : Select"

        BG_frm.R_1.Text = "|F1 : Detailed"
        BG_frm.R_2.Text = "F2 : Date"
        BG_frm.R_3.Text = "|F2 : Period"
        If Branch_Visible() = True Then
            BG_frm.R_5.Text = "F4 : Branch"
        End If
        BG_frm.R_6.Text = "||F : Filter"

        BG_frm.R_22.Text = "F12 : Configuration"
    End Function
    Private Function Add_Hander_Remove_Handel(Ans As Boolean)
        If Ans = True Then
            AddHandler BG_frm.KeyDown, AddressOf Me.BG_Keydown
            AddHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            AddHandler BG_frm.R_2.Click, AddressOf Me.R_3_Click
            AddHandler BG_frm.R_3.Click, AddressOf Me.R_4_Click
            AddHandler BG_frm.R_5.Click, AddressOf Me.R_5_Click
        Else
            RemoveHandler BG_frm.KeyDown, AddressOf Me.BG_Keydown
            RemoveHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            RemoveHandler BG_frm.R_2.Click, AddressOf Me.R_3_Click
            RemoveHandler BG_frm.R_3.Click, AddressOf Me.R_4_Click
            RemoveHandler BG_frm.R_5.Click, AddressOf Me.R_5_Click
        End If
    End Function
    Private Sub BG_Keydown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.F1 AndAlso e.Modifiers = Keys.Alt Then
            BG_frm.R_1.PerformClick()
        End If
        If e.KeyCode = Keys.F2 AndAlso e.Modifiers = Keys.Alt Then
            BG_frm.R_3.PerformClick()
        ElseIf e.KeyCode = Keys.F2 Then
            BG_frm.R_2.PerformClick()
        End If
        If e.KeyCode = Keys.F4 AndAlso e.Modifiers = Keys.Alt Then

        ElseIf e.KeyCode = Keys.F4 Then
            BG_frm.R_5.PerformClick()
        End If
    End Sub
    Private Sub B_1_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Fill_Grid()
        End If
    End Sub
    Private Sub R_3_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            If Date_Set_Curr(False) = DialogResult.Yes Then
                Frm_Date_LB.Text = Date_3
                To_Date_LB.Text = Date_3
                Fill_Grid()
            End If
        End If
    End Sub
    Private Sub R_4_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            If Date_Set_Curr(True) = DialogResult.Yes Then
                Frm_Date_LB.Text = Date_1
                To_Date_LB.Text = Date_2
                Fill_Grid()
            End If
        End If
    End Sub
    Private Sub R_5_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then

        End If
    End Sub

    Private Sub Paysheet_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.HADE_TXT.Text = "Pay Sheet"
        BG_frm.TYP_TXT.Text = VC_Type_

        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text
        Button_Clear()
        Button_Manage()
        'Config_Fill()
        Fill_Grid()
        Grid1.Focus()
    End Sub

    Private Sub Paysheet_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub Paysheet_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        Add_Hander_Remove_Handel(False)
        BG_frm.BG_Path_TXT.Text = Path_End
        Frm_foCus()
    End Sub
    Private Sub Grid1_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles Grid1.RowsAdded
        Grid1.Rows(Grid1.Rows.Count - 1).Height = 18
    End Sub
    Private Sub Frm_Date_LB_TextChanged(sender As Object, e As EventArgs) Handles Frm_Date_LB.TextChanged
        Frm_date = Frm_Date_LB.Text
    End Sub
    Private Sub To_Date_LB_TextChanged(sender As Object, e As EventArgs) Handles To_Date_LB.TextChanged
        to_date = To_Date_LB.Text
    End Sub
    Private Sub Grid1_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles Grid1.RowPrePaint
        Dim ro As DataGridViewRow = Grid1.Rows(e.RowIndex)
        If ro.Cells(0).Value = "Head" Then
            ro.DefaultCellStyle.Font = Defolt_Fonts_Bold
            ro.DefaultCellStyle.Padding = New Padding(5, 0, 0, 0)
        Else
            ro.DefaultCellStyle.Font = Defolt_Fonts
            ro.DefaultCellStyle.Padding = New Padding(25, 0, 0, 0)
        End If
    End Sub
    Public Function Fill_Grid()
        dt.Rows.Clear()
        dt.Columns.Clear()
        dt.Columns.Add("Type")
        dt.Columns.Add("Particulars")
        Add_Data()

        Try
            Grid1.Columns(1).Frozen = False
        Catch ex As Exception

        End Try
        BindingSource1.DataSource = dt
        Grid1.DataSource = BindingSource1

        Grid1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Grid1.Columns(0).Visible = False

        Try
            Grid1.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Catch ex As Exception

        End Try

        Grid1.Columns(1).Frozen = True
        Grid1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
    End Function
    Dim dt As New DataTable
    Dim dr As DataRow
    Dim Total_Earning_Com As Integer = 0
    Dim Total_Deduction_com As Integer = 0
    Dim Total_Net_Amt_com As Integer = 0
    Private Function Add_Data()

        'Dim vlu As String

        'If Pyhd_ = "Earnings for Employees" Then
        '    vlu = "Dr"
        '    Pyhd_ = "(Payhead_Type = 'Earnings for Employees')"
        'Else
        '    vlu = "Cr"
        '    Pyhd_ = "(Payhead_Type = 'Deductions From Employees' or Payhead_Type = 'Loans and Advances')"
        'End If

        Dim qry As String = ""
        'Craeate Qury (Table NAme Data)
        Dim list_name As New ArrayList
        Dim list_Group_ID As New ArrayList
        Dim list_Group_Name As New ArrayList

        If open_MSSQL(Database_File.cre) = True Then
            cmd = New SQLiteCommand("Select * From TBL_PayHead where Visible = 'Approval' and (Company = 'All' or Company = '" & Company_ID_str & "')", con)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                If Branch = "Primary" Then
                    qry &= ",isnull((Select SUM(ATT.[Dr]) from TBL_VC ATT 
where ((Att.Particuls = EM.Id) and (Att.Payhead = '" & r("ID") & "') and (Att.Visible = 'Approval')) and (Att.Voucher_Type = 'Payroll') and ((Date BETWEEN '" & Frm_date.ToString("MM-dd-yyyy") & "' and '" & to_date.ToString("MM-dd-yyyy") & "'))),0) as [" & r("Name") & "_Dr],
isnull((Select SUM(ATT.[Cr]) from TBL_VC ATT 
where ((Att.Particuls = EM.Id) and (Att.Payhead = '" & r("ID") & "') and (Att.Visible = 'Approval')) and (Att.Voucher_Type = 'Payroll') and ((Date BETWEEN '" & Frm_date.ToString("MM-dd-yyyy") & "' and '" & to_date.ToString("MM-dd-yyyy") & "'))),0) as [" & r("Name") & "_Cr]"
                Else
                    qry &= ",isnull((Select SUM(ATT.[Dr]) from TBL_VC ATT 
where ((Att.Particuls = EM.Id) and (Att.Payhead = '" & r("ID") & "') and (Att.Visible = 'Approval') and (Branch = '" & Branch_ID & "')) and (Att.Voucher_Type = 'Payroll') and ((Date BETWEEN '" & Frm_date.ToString("MM-dd-yyyy") & "' and '" & to_date.ToString("MM-dd-yyyy") & "'))),0) as [" & r("Name") & "_Dr],
isnull((Select SUM(ATT.[Cr]) from TBL_VC ATT 
where ((Att.Particuls = EM.Id) and (Att.Payhead = '" & r("ID") & "') and (Att.Visible = 'Approval') and (Branch = '" & Branch_ID & "')) and (Att.Voucher_Type = 'Payroll') and ((Date BETWEEN '" & Frm_date.ToString("MM-dd-yyyy") & "' and '" & to_date.ToString("MM-dd-yyyy") & "'))),0) as [" & r("Name") & "_Cr]"
                End If
                list_name.Add(r("Name"))
            End While
        End If


        For i As Integer = 0 To list_name.Count - 1
            dt.Columns.Add(list_name(i))
        Next

        dt.Columns.Add("Net Amount")

        If open_MSSQL(Database_File.cre) = True Then
            cmd = New SQLiteCommand("Select * From TBL_Stock_Group where Head = 'Payroll' and visible = 'Approval' and (Company = 'All' or Company = '" & Company_ID_str & "')", con)
            Dim r1 As SQLiteDataReader
            r1 = cmd.ExecuteReader
            While r1.Read
                list_Group_ID.Add(r1("ID"))
                list_Group_Name.Add(r1("Name"))
            End While
            r1.Close()
            Dim to_vl As Decimal = 0
            For i As Integer = 0 To list_Group_ID.Count - 1
                dt.Rows.Add("Head", list_Group_Name(i))
                cmd = New SQLiteCommand("SELECT EM.[ID],EM.[Name]" & qry & "
From TBL_Payroll_Employee EM where [Under] = '" & list_Group_ID(i) & "' and Visible = 'Approval' and (Company = 'All' or Company = '" & Company_ID_str & "')", con)
                Dim r As SQLiteDataReader
                r = cmd.ExecuteReader
                While r.Read
                    to_vl = 0
                    dr = dt.NewRow
                    dr("Particulars") = r("Name")
                    dr("Type") = "Under"

                    For i1 As Integer = 0 To list_name.Count - 1
                        Dim vl As String = Val(Format(Val(r(list_name(i1) & "_Dr")), "#.##")) - Val(Format(Val(r(list_name(i1) & "_Cr")), "#.##"))
                        If Val(vl) = 0 Then
                            dr(list_name(i1)) = ""
                        Else
                            dr(list_name(i1)) = Format(Val(vl), "0.00")
                            to_vl = Val(to_vl) + vl
                        End If
                    Next
                    dr("Net Amount") = Format(Val(to_vl), "0.00")
                    dt.Rows.Add(dr)
                End While
                r.Close()
            Next
        End If
    End Function

    Private Sub Paysheet_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
    End Sub
End Class