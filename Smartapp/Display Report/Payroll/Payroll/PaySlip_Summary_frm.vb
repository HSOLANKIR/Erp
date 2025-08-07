Imports System.Data.SQLite

Public Class PaySlip_Summary_frm
    Dim From_ID As String
    Private VC_Type_ As String
    Private VC_ID_ As String
    Private Path_End As String

    Dim Frm_date As Date
    Dim to_date As Date

    Dim Type_ As String

    Private Sub PaySlip_Summary_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text

        VC_Type_ = Link_Valu(1)
        VC_ID_ = Link_Valu(2)

        Type_ = Display_List.me_list.List_Grid.CurrentRow.Cells(2).Value

        Frm_Date_LB.Text = Date_Formate(Date_1)
        To_Date_LB.Text = Date_Formate(Date_2)

        BG_frm.HADE_TXT.Text = "PaySlip Summary"
        BG_frm.TYP_TXT.Text = VC_Type_

        Button_Manage()
        Add_Hander_Remove_Handel(True)

        Update_Report = True
    End Sub
    Private Function Button_Manage()
        Button_Clear()
        BG_frm.B_1.Text = "|&R : Refresh"

        BG_frm.R_2.Text = "F2 : Date"
        BG_frm.R_3.Text = "|F2 : Period"

    End Function
    Private Function Add_Hander_Remove_Handel(Ans As Boolean)
        If Ans = True Then
            AddHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            AddHandler BG_frm.R_2.Click, AddressOf Me.R_3_Click
            AddHandler BG_frm.R_3.Click, AddressOf Me.R_4_Click

        Else
            RemoveHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click

            RemoveHandler BG_frm.R_2.Click, AddressOf Me.R_3_Click
            RemoveHandler BG_frm.R_3.Click, AddressOf Me.R_4_Click
        End If
    End Function
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
    Private Sub B_1_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then

        End If
    End Sub

    Private Sub PaySlip_Summary_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.HADE_TXT.Text = "PaySlip Summary"
        BG_frm.TYP_TXT.Text = VC_Type_

        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text


        Button_Clear()
        Button_Manage()
        'cfg_fill()
        If Update_Report = True Then
            Fill_Grid()
        End If
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

    Private Sub PaySlip_Summary_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If

        If e.KeyCode = Keys.F2 AndAlso e.Modifiers = Keys.Alt Then
            BG_frm.R_3.PerformClick()
        ElseIf e.KeyCode = Keys.F2 Then
            BG_frm.R_2.PerformClick()
        End If


    End Sub

    Private Sub PaySlip_Summary_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
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
    Public Function Fill_Grid()
        Grid1.Rows.Clear()
        Dim FIlter_ As String
        Dim total_ As Decimal = 0

        If Type_ = "Employee" Then
            FIlter_ = $" and em.ID = '{VC_ID_}'"
        ElseIf Type_ = "Group" Then
            FIlter_ = $" and em.Under = '{VC_ID_}'"
        End If


        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select em_ID,em_Name,ifnull(SUM(Vlu),0) as Value_,Bank_Name,Bank_Branch,Bank_IFSC_code,Bank_AccounNo,Mobile1 From (Select em.ID as em_ID,em.Name as em_Name,em.Bank_Name,em.Bank_Branch,Bank_IFSC_code,Bank_AccounNo,Mobile1,
(Select ifnull(SUM(vc.Dr),0)-ifnull(SUM(vc.Cr),0) From TBL_VC_Payroll vc WHERE vc.Payhead = phd.ID and vc.Employee = em.ID and (vc.Date BETWEEN '{CDate(Frm_date).ToString(Lite_date_Format)}' and '{CDate(to_date).AddDays(1).ToString(Lite_date_Format)}')) as Vlu
From TBL_Payroll_Employee em
CROSS JOIN TBL_PayHead phd
where em.Visible = 'Approval' and phd.Visible = 'Approval' {FIlter_}) Group By em_ID", cn)

            Dim r As SQLiteDataReader = cmd.ExecuteReader
            'My.Computer.Clipboard.SetText(cmd.CommandText)
            While r.Read
                Grid1.Rows.Add("", r("em_Name").ToString, r("Bank_Name").ToString, r("Bank_AccounNo").ToString, r("Bank_Branch").ToString, r("Bank_IFSC_code").ToString, r("Mobile1").ToString, N2_FORMATE(r("Value_").ToString), r("em_ID"))
                total_ += Val(r("Value_").ToString)
            End While
        End If

        Label17.Text = N2_FORMATE(total_)
    End Function

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        If Grid1.Rows.Count <> 0 Then
            Dim ctlpos = Grid1.GetCellDisplayRectangle(2, 0, False)

            L1.Location = New Point(ctlpos.X, 0)
            L1.Height = Me.Height
            L1.Visible = True


            ctlpos = Grid1.GetCellDisplayRectangle(3, 0, False)
            L2.Location = New Point(ctlpos.X, 0)
            L2.Height = Me.Height
            L2.Visible = True

            ctlpos = Grid1.GetCellDisplayRectangle(4, 0, False)
            L3.Location = New Point(ctlpos.X, 0)
            L3.Height = Me.Height
            L3.Visible = True

            ctlpos = Grid1.GetCellDisplayRectangle(5, 0, False)
            L4.Location = New Point(ctlpos.X, 0)
            L4.Height = Me.Height
            L4.Visible = True

            ctlpos = Grid1.GetCellDisplayRectangle(6, 0, False)
            L5.Location = New Point(ctlpos.X, 0)
            L5.Height = Me.Height
            L5.Visible = True

            ctlpos = Grid1.GetCellDisplayRectangle(7, 0, False)
            L6.Location = New Point(ctlpos.X, 0)
            L6.Height = Me.Height
            L6.Visible = True
        End If


        T1.Location = New Point(0, 0)
        T1.Width = Me.Width

        T2.Location = New Point(0, 20)
        T2.Width = Me.Width

    End Sub

    Private Sub Grid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid1.CellContentClick

    End Sub

    Private Sub Grid1_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cell("Payslip", Grid1.CurrentRow.Cells(8).Value)
        End If
    End Sub

    Private Sub PaySlip_Summary_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
    End Sub
End Class