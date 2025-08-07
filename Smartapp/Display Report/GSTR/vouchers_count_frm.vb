Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Data.SQLite

Public Class vouchers_count_frm
    Dim From_ID As String
    Private VC_Type_ As String
    Private VC_ID_ As String
    Private Path_End As String
    Dim YN_Details As Boolean
    Dim Acc_Under As String
    Dim Frm_date As Date
    Dim to_date As Date

    Public Branch_ID As String = ""
    Public Branch As String = "Primary"
    Public Voucher_Type As String = "All Vouchers"
    Public Narration_ As Boolean = False

    Public Delete_Entry = False
    Private Sub vouchers_count_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text

        VC_ID_ = Link_Valu(0)

        Branch_ID = Link_Valu(1)
        Branch = Find_Branch_Name(Branch_ID)

        Frm_Date_LB.Text = Date_Formate(Date_1)
        To_Date_LB.Text = Date_Formate(Date_2)

        BG_frm.HADE_TXT.Text = "Vouchers Count"
        BG_frm.TYP_TXT.Text = VC_Type_

        Button_Manage()
        Add_Hander_Remove_Handel(True)

        Label17.Text = Branch
        Grid1.Focus()
    End Sub
    Private Function Button_Manage()
        Button_Clear()
        BG_frm.B_1.Text = "Enter : Alter"
        BG_frm.B_2.Text = "|&R : Refresh"
        BG_frm.B_3.Text = "|&P : Print"

        BG_frm.R_2.Text = "F2 : Date"
        BG_frm.R_3.Text = "|F2 : Period"
        If Branch_Visible() = True Then
            BG_frm.R_5.Text = "F4 : Branch"
        End If
    End Function
    Private Function Add_Hander_Remove_Handel(Ans As Boolean)
        If Ans = True Then
            AddHandler BG_frm.KeyDown, AddressOf Me.BG_Keydown
            AddHandler BG_frm.R_2.Click, AddressOf Me.R_3_Click
            AddHandler BG_frm.R_3.Click, AddressOf Me.R_4_Click
            If Branch_Visible() = True Then
                AddHandler BG_frm.R_5.Click, AddressOf Me.R_9_Click
            End If
        Else

        End If
    End Function
    Private Sub BG_Keydown(sender As Object, e As KeyEventArgs)
        If BG_frm.From_ID = From_ID Then
            If e.KeyCode = Keys.F2 AndAlso e.Modifiers = Keys.Alt Then
                BG_frm.R_3.PerformClick()
            ElseIf e.KeyCode = Keys.F2 Then
                BG_frm.R_2.PerformClick()
            End If

            If e.KeyCode = Keys.F4 AndAlso e.Modifiers = Keys.Alt Then

            ElseIf e.KeyCode = Keys.F4 Then
                BG_frm.R_5.PerformClick()
            End If

            If e.KeyCode = Keys.F5 AndAlso e.Modifiers = Keys.Alt Then

            ElseIf e.KeyCode = Keys.F5 Then
                BG_frm.R_6.PerformClick()
            End If
        End If
    End Sub
    Private Sub R_9_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then

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
    Private Function Fill_Grid()
        Grid1.Rows.Clear()
        Grid1.ColumnHeadersDefaultCellStyle.Font = Defolt_Fonts_Bold
        Grid2.ColumnHeadersDefaultCellStyle.Font = Defolt_Fonts_Bold


        Dim dt As New DataTable
        dt = Fill_Voucher_Create()

        Dim vlu As Integer = 0
        Dim conn As New SQLiteConnection
        Dim r As SQLiteDataReader
        If open_MSSQL_Cstm(Database_File.cre, conn) = True Then
            For i As Integer = 0 To dt.Rows.Count - 1
                qury = "SELECT Tra_ID
FROM TBL_VC vc
where (vc.Visible = 'Approval') " & Where_Filter() & " and vc.Voucher_Type = '" & dt.Rows(i).ItemArray(0) & "' and (Date BETWEEN @Frm_Date and @To_Date)
GROUP BY Tra_ID
HAVING COUNT(*) > 1"
                cmd = New SQLiteCommand(qury, conn)
                With cmd.Parameters
                    .AddWithValue("@Frm_Date", Frm_date.ToString("MM-dd-yyyy"))
                    .AddWithValue("@To_Date", to_date.ToString("MM-dd-yyyy"))
                    r = cmd.ExecuteReader
                    While r.Read
                        vlu += 1
                    End While
                    r.Close()
                End With
                If vlu <> 0 Then
                    Grid1.Rows.Add(dt.Rows(i).ItemArray(0), vlu)
                Else
                    Grid1.Rows.Add(dt.Rows(i).ItemArray(0), "")
                End If
                vlu = 0
            Next
            cmd = New SQLiteCommand("Select (Select Count(ID) From TBL_Acc_Group where Visible = 'Approval' " & Where_Filter() & ") as Account_Group,
(Select Count(ID) From TBL_Ledger where Visible = 'Approval' " & Where_Filter() & ") as Account_Ledger,
(Select Count(ID) From TBL_Stock_Group where Visible = 'Approval' and Head = 'Stock' " & Where_Filter() & ") as Stock_Group,
(Select Count(ID) From TBL_Stock_Item where Visible = 'Approval' " & Where_Filter() & ") as Stock_Item,
(Select Count(ID) From TBL_Voucher_Create where Visible = 'Approval' " & Where_Filter() & ") as Voucher_Type,
(Select Count(ID) From TBL_Inventory_Unit where Visible = 'Approval' " & Where_Filter() & ") as Unit,
(Select Count(ID) From TBL_Payroll_Att_Production_Type where Visible = 'Approval' " & Where_Filter() & ") as Attendance_Production_Type,
(Select Count(ID) From TBL_Stock_Group where Visible = 'Approval' and Head = 'Payroll' " & Where_Filter() & ") as Payroll_Group,
(Select Count(ID) From TBL_Stock_Group where Visible = 'Approval' " & Where_Filter() & ") as Employee", conn)
            With cmd.Parameters
                .AddWithValue("@Frm_Date", Frm_date.ToString("MM-dd-yyyy"))
                .AddWithValue("@To_Date", to_date.ToString("MM-dd-yyyy"))
                r = cmd.ExecuteReader
                While r.Read
                    Grid2.Rows.Add("Account Group", r("Account_Group"))
                    Grid2.Rows.Add("Ledger", r("Account_Ledger"))
                    Grid2.Rows.Add("Stock Group", r("Stock_Group"))
                    Grid2.Rows.Add("Stock Item", r("Stock_Item"))
                    Grid2.Rows.Add("Voucher Type", r("Voucher_Type"))
                    Grid2.Rows.Add("Unit", r("Unit"))
                    Grid2.Rows.Add("Attendance/Production Type", r("Attendance_Production_Type"))
                    Grid2.Rows.Add("Payroll Group", r("Payroll_Group"))
                    Grid2.Rows.Add("Employee", r("Employee"))
                End While
                r.Close()
            End With
        End If
    End Function

    Private Sub vouchers_count_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.HADE_TXT.Text = "Vouchers Count"
        BG_frm.TYP_TXT.Text = VC_Type_

        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text
        Button_Clear()
        Button_Manage()
        'Config_Fill()
        'If Update_Report = True Then
        Fill_Grid()
        'End If
        Grid1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(254, 197, 48)
        Grid2.DefaultCellStyle.SelectionBackColor = Color.White
        Grid1.Focus()
    End Sub

    Private Sub vouchers_count_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub
    Private Sub vouchers_count_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        Add_Hander_Remove_Handel(False)
        BG_frm.BG_Path_TXT.Text = Path_End
        Frm_foCus()
    End Sub
    Private Sub Frm_Date_LB_TextChanged(sender As Object, e As EventArgs) Handles Frm_Date_LB.TextChanged
        Frm_date = Frm_Date_LB.Text
    End Sub
    Private Sub To_Date_LB_TextChanged(sender As Object, e As EventArgs) Handles To_Date_LB.TextChanged
        to_date = To_Date_LB.Text
    End Sub
    Private Function Where_Filter() As String
        Dim q As String
        If Branch <> "Primary" Then
            q &= " AND VC.Branch = '" & Find_DT_Value(Database_File.cre, "TBL_Ledger", "ID", "Name = '" & Branch & "'") & "'"
        End If
        Return q
    End Function

    Private Sub Grid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid1.CellContentClick

    End Sub

    Private Sub Grid1_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid1.KeyDown
        If e.KeyCode = Keys.Right Then
            Grid2.Focus()
        End If
    End Sub
    Private Sub Grid2_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid2.KeyDown
        If e.KeyCode = Keys.Left Then
            Grid1.Focus()
        End If
    End Sub
    Private Sub Grid_LostFocus(sender As Object, e As EventArgs) Handles Grid1.LostFocus, Grid2.LostFocus
        sender.DefaultCellStyle.SelectionBackColor = Color.White
    End Sub
    Private Sub Grid_Enter(sender As Object, e As EventArgs) Handles Grid1.Enter, Grid2.Enter
        sender.DefaultCellStyle.SelectionBackColor = Color.FromArgb(254, 197, 48)
    End Sub

    Private Sub vouchers_count_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
    End Sub
End Class