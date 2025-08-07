Imports System.Data.SqlClient
Imports System.Data.SQLite
Imports Microsoft.Reporting.WinForms
Public Class Payroll_Sheett
    Dim From_ID As String
    Private VC_Type_ As String
    Private VC_ID_ As String
    Private Path_End As String
    Dim YN_Details As Boolean
    Dim Acc_Under As String
    Dim Frm_date As Date
    Dim to_date As Date

    Public Branch As String = "Primary"
    Public Narration_ As Boolean = False
    Public Delete_Entry = False


    Dim ds_print As New Print_dt
    Dim dt_print As New DataTable
    Private Sub Payroll_Register_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text

        VC_Type_ = Link_Valu(1)
        VC_ID_ = Link_Valu(2)

        Frm_Date_LB.Text = Date_Formate(Date_1)
        To_Date_LB.Text = Date_Formate(Date_2)

        BG_frm.HADE_TXT.Text = "Payroll Sheet"
        BG_frm.TYP_TXT.Text = VC_Type_

        Button_Manage()
        Add_Hander_Remove_Handel(True)
        Branch = Branch_Name

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
            Set_Date(False, Me)
        End If
    End Sub
    Private Sub R_4_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Set_Date(True, Me)
        End If
    End Sub
    Private Sub R_5_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then

        End If
    End Sub

    Private Sub Payroll_Sheett_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.HADE_TXT.Text = "Payroll Sheet"
        BG_frm.TYP_TXT.Text = VC_Type_

        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text
        Button_Clear()
        Button_Manage()
        'Config_Fill()
        Fill_Grid()
        Grid1.Focus()
    End Sub
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
    Dim SUM_tbl As DataTable
    Dim Defolt_Select_Emp As String = 0
    Dim Defolt_Select_pyHead As Integer = 0
    Public Function Fill_Grid()

        If Grid1.Rows.Count <> 0 Then
            Try
                Defolt_Select_Emp = Find_DT_Value(Database_File.cre, "TBL_Payroll_Employee", "ID", $"Name = '{Grid1.CurrentRow.Cells(0).Value.ToString}'")
                Defolt_Select_pyHead = Find_DT_Value(Database_File.cre, "TBL_Payhead", "ID", $"Name = '{Grid1.Columns(Grid1.CurrentCell.ColumnIndex).HeaderText}'")

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

        Dim Last_ As String = ""

        SUM_tbl = New DataTable

        'Create New Data Tabale
        Dim dt As New DataTable
        Dim cn As New SQLiteConnection
        dt.Columns.Add("Name")
        SUM_tbl.Columns.Add("Name")
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand("Select id,Name From TBL_PayHead where Visible = 'Approval'", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                dt.Columns.Add(r("Name"))
                SUM_tbl.Columns.Add(r("Name"))

                If Defolt_Select_pyHead = r("id").ToString Then
                    Defolt_Select_pyHead = dt.Columns.Count - 1
                End If
            End While
            r.Close()

            SUM_tbl.Rows.Add("")

            cmd = New SQLiteCommand($"Select em.ID as e_ID,em.Name as e_Name,phd.ID as a_ID,phd.Name as a_Name,
(Select ifnull(SUM(vc.Dr),0)-ifnull(SUM(vc.Cr),0) From TBL_VC_Payroll vc where vc.Employee = em.ID and vc.Payhead = phd.ID and (vc.Date BETWEEN '{CDate(Frm_date).ToString(Lite_date_Format)}' and '{CDate(to_date).AddDays(1).ToString(Lite_date_Format)}')) as Vlu
From TBL_Payroll_Employee em
CROSS JOIN TBL_PayHead phd
WHERE em.Visible = 'Approval' and phd.Visible = 'Approval'", cn)
            r = cmd.ExecuteReader
            Dim ro As DataRow
            Dim duplicat_ As String = "NA"
            While r.Read
                If duplicat_ <> r("e_Name") Then
                    If duplicat_ <> "NA" Then
                        dt.Rows.Add(ro)
                    End If
                    ro = dt.NewRow
                    ro("Name") = r("e_Name")
                    duplicat_ = r("e_Name")
                End If

                If Val(r("Vlu").ToString) <> 0 Then
                    Dim uni As String
                    Dim tot As Decimal = 0
                    If Val(r("Vlu").ToString) < 0 Then
                        uni = $"{N2_FORMATE(Val(r("Vlu")) * -1)} {Positive_Value_fech}"
                    Else
                        uni = $"{N2_FORMATE(Val(r("Vlu")))} {Negative_Value_fech}"
                    End If

                    ro(r("a_Name")) = $"{uni}"



                    SUM_tbl.Rows(0)(r("a_Name")) = Val(SUM_tbl.Rows(0)(r("a_Name")).ToString) + Val(r("Vlu"))
                End If


                If Defolt_Select_Emp = r("e_ID").ToString Then
                    Defolt_Select_Emp = dt.Rows.Count - 0
                End If

                Last_ = r("e_Name")
            End While

            If dt.Rows(dt.Rows.Count - 1)(0) <> Last_ Then
                dt.Rows.Add(ro)
            End If

            Grid1.DataSource = dt
        End If


        With Grid1

            For i As Integer = 1 To Grid1.ColumnCount - 1
                .Columns(i).Width = 100
                .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            Next

            .Columns(0).Width = 200
            .Columns(0).Frozen = True

            Dim total_h As Integer = Val(Grid1.ColumnCount - 1) * 100

            If total_h <= Grid1.Width Then
                .Columns(0).Frozen = False
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End If
        End With

        Total_Grid = Grid_Bottom(Panel1, Grid1)
        With Total_Grid.Rows(0)
            .Cells("Name").Value = "Total"
            For i As Integer = 1 To dt.Columns.Count - 1
                Dim amt_ As String = SUM_tbl.Rows(0)(i).ToString

                If nUmBeR_FORMATE(amt_) = 0 Then
                    amt_ = ""
                ElseIf nUmBeR_FORMATE(amt_) > 0 Then
                    amt_ = N2_FORMATE(amt_)
                    amt_ = $"{amt_} {Negative_Value_fech}"
                ElseIf nUmBeR_FORMATE(amt_) < 0 Then
                    amt_ = N2_FORMATE(amt_ * -1)
                    amt_ = $"{amt_} {Positive_Value_fech}"
                End If

                .Cells(dt.Columns(i).ColumnName).Value = amt_
            Next
        End With
        Grid1.Focus()

        For Each cl As DataGridViewColumn In Grid1.Columns
            Total_Grid.Columns(cl.Index).DisplayIndex = cl.DisplayIndex
        Next


        Try
            Grid1.CurrentCell = Grid1.Rows(Val(Defolt_Select_Emp)).Cells(1)
        Catch ex As Exception

        End Try

        Try
            Grid1.CurrentCell = Grid1.Rows(Val(Defolt_Select_Emp)).Cells(Defolt_Select_pyHead)
        Catch ex As Exception

        End Try

    End Function
    Private Sub Grid1_Paint(sender As Object, e As PaintEventArgs) Handles Grid1.Paint
        DrawLinePoint(e)
    End Sub

    Dim Total_Grid As DataGridView
    Public Sub DrawLinePoint(ByVal e As PaintEventArgs)
        If Grid1.Rows.Count <> 0 Then
            Dim blackPen As New Pen(Color.Gray, 1)

            Dim point1 As New Point(0, Grid1.ColumnHeadersHeight)
            Dim point2 As New Point(Grid1.Width, Grid1.ColumnHeadersHeight)
            e.Graphics.DrawLine(blackPen, point1, point2)

            point1 = New Point(0, 0)
            point2 = New Point(Grid1.Width, 0)
            e.Graphics.DrawLine(blackPen, point1, point2)

            For i As Integer = 0 To Grid1.ColumnCount - 1
                Dim ctlpos As Point = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(i, 0, False).Location)
                point1 = New Point(ctlpos.X, 0)
                point2 = New Point(ctlpos.X, Grid1.Height)
                e.Graphics.DrawLine(blackPen, point1, point2)
            Next


        End If
    End Sub
    Private Sub Payroll_Sheett_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub Payroll_Sheett_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
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
    Private Sub Grid1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles Grid1.CellFormatting
        If Grid1.CurrentCell IsNot Nothing Then
            If e.RowIndex = Grid1.CurrentCell.RowIndex And e.ColumnIndex = Grid1.CurrentCell.ColumnIndex Then
                e.CellStyle.SelectionBackColor = Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(48, Byte), Integer))
            Else
                e.CellStyle.SelectionBackColor = Grid1.DefaultCellStyle.SelectionBackColor
            End If
        End If
    End Sub

    Private Sub Grid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid1.CellContentClick

    End Sub

    Private Sub Grid1_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid1.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True

            Dim em As String = Grid1.CurrentRow.Cells(0).Value
            Dim at As String = Grid1.Columns(Grid1.CurrentCell.ColumnIndex).HeaderText.Trim

            If (Grid1.CurrentCell.ColumnIndex) > 0 Then
                em = Find_DT_Value(Database_File.cre, "TBL_Payroll_Employee", "ID", $"Name = '{em}' and Visible = 'Approval'")
                at = Find_DT_Value(Database_File.cre, "TBL_Payhead", "ID", $"Name = '{at.Trim}' and Visible = 'Approval'")

                Cell("Payroll Vouchers", em, at)
            End If
        End If

    End Sub

    Private Sub Payroll_Sheett_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID

        Grid1.Focus()
    End Sub
End Class
