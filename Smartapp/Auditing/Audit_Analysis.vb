Imports System.Data.SQLite
Imports Microsoft.Reporting.WinForms
Imports PopupControl

Public Class Audit_Analysis
    Private VC_Type_ As String
    Private VC_ID_ As String
    Private TBL As String
    Private Path_End As String
    Dim YN_Details As Boolean
    Public Colunm() As String
    Dim Frm_date As Date
    Dim to_date As Date

    Public Narration_ As Boolean = False
    Public Sorting_Methoud_ As String = "Date (Increasing)"
    Public Delete_Entry = False

    Dim ds_print As New Print_dt
    Dim dt_print As New DataTable

    Dim Defolt_Select_ID As String = 0
    Private Sub Audit_Analysis_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Path_End = BG_frm.BG_Path_TXT.Text

        VC_Type_ = Link_Valu(1)
        VC_ID_ = Link_Valu(2)
        TBL = Link_Valu(3)

        Acc_LB.Text = Link_Valu(1)

        Frm_Date_LB.Text = Date_Formate(Date_1)
        To_Date_LB.Text = Date_Formate(Date_2)

        BG_frm.HADE_TXT.Text = "Audit Analysis"
        BG_frm.TYP_TXT.Text = VC_Type_

        Button_Manage()
        Add_Hander_Remove_Handel(True)

        Update_Report = True
    End Sub

    Private Function Button_Manage()
        Button_Clear()
        BG_frm.B_1.Text = "Enter : Alter"

        BG_frm.R_2.Text = "F2 : Date"
        BG_frm.R_3.Text = "|F2 : Period"
    End Function
    Private Function Add_Hander_Remove_Handel(Ans As Boolean)
        If Ans = True Then
            AddHandler BG_frm.KeyDown, AddressOf Me.BG_Keydown
            AddHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            AddHandler BG_frm.R_2.Click, AddressOf Me.R_2_Click
            AddHandler BG_frm.R_3.Click, AddressOf Me.R_3_Click
        Else
            RemoveHandler BG_frm.KeyDown, AddressOf Me.BG_Keydown
            RemoveHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            RemoveHandler BG_frm.R_2.Click, AddressOf Me.R_2_Click
            RemoveHandler BG_frm.R_3.Click, AddressOf Me.R_3_Click
        End If
    End Function
    Private Sub BG_Keydown(sender As Object, e As KeyEventArgs)
        If BG_frm.HADE_TXT.Text = "Audit Analysis" And BG_Panel.Visible = True Then
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
        If BG_frm.HADE_TXT.Text = "Audit Analysis" Then
            If Grid1.Rows.Count > 0 Then

            End If
        End If
    End Sub
    Private Sub R_2_Click(sender As Object, e As EventArgs)
        If BG_frm.HADE_TXT.Text = "Audit Analysis" And BG_Panel.Visible = True Then
            Set_Date(False, Me)
        End If
    End Sub
    Private Sub R_3_Click(sender As Object, e As EventArgs)
        If BG_frm.HADE_TXT.Text = "Audit Analysis" And BG_Panel.Visible = True Then
            Set_Date(True, Me)
        End If
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
    Public Function Fill_Grid()
        Dim dt As New DataTable
        Dim cn As New SQLiteConnection
        open_MSSQL_Cstm(Database_File.aud, cn)

        If TBL = "TBL_Ledger" Then TBL_Ledger(cn, dt)


        Grid1.Focus()
    End Function

    Private Function TBL_Ledger(cn As SQLiteConnection, dt As DataTable)

        'Txt1.Select_Filter = "Name LIKE '%<value>%'"

        cmd = New SQLiteCommand($"attach database '{Connection_Path}\{Connection_Data}\cmp.db' as cmp;
Select Name,Alise,(Select ag.Name From TBL_Acc_Group ag where ag.ID = ld.[Group]) as [Group],
Phone,Email,Address,OB_CR as Opning_Cr,OB_DR as Opning_Dr,Cradit as Cradit_Limit,Discription,Note,BankName,AccountNo,Branch,IFSCCode,(Select U.Name From cmp.TBL_User U where U.User_ID = Ld.User) as User,
PC,Date_install as DateTime,Audit_ID From TBL_Ledger ld where ld.Original_ID = '{VC_ID_}' and (ld.Date_install BETWEEN '{CDate(Frm_date).ToString(Lite_date_Format)}' and '{CDate(to_date).AddDays(1).ToString(Lite_date_Format)}')", cn)
        Dim r As SQLiteDataReader = cmd.ExecuteReader
        dt.Load(r)
        r.Close()


        Grid1.DataSource = dt
        Grid1.AutoResizeColumns()
        'Grid1.Columns(Grid1.Columns.Count - 5).Frozen = True
    End Function
    Private Function Fill_oTher_Group(dt As DataTable, Closing_ As String)

    End Function
    Private Sub Frm_Date_LB_TextChanged(sender As Object, e As EventArgs) Handles Frm_Date_LB.TextChanged
        Frm_date = Frm_Date_LB.Text
    End Sub
    Private Sub To_Date_LB_TextChanged(sender As Object, e As EventArgs) Handles To_Date_LB.TextChanged
        to_date = To_Date_LB.Text
    End Sub
    Private Sub Audit_Analysis_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub Audit_Analysis_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        Add_Hander_Remove_Handel(False)
        BG_frm.BG_Path_TXT.Text = Path_End
        Frm_foCus()
    End Sub

    Private Sub Audit_Analysis_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.HADE_TXT.Text = "Audit Analysis"
        BG_frm.TYP_TXT.Text = VC_Type_

        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text


        Button_Clear()
        Button_Manage()
        If Update_Report = True Then
            Fill_Grid()
        End If
        Grid1.Focus()
    End Sub
    Private Sub Grid1_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid1.KeyDown
        If e.KeyCode = Keys.Enter Then
            BG_frm.B_1.PerformClick()
            e.Handled = True
        End If
    End Sub
    Private Sub Grid1_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles Grid1.RowPrePaint
        Dim ro As DataGridViewRow = Grid1.Rows(e.RowIndex)

    End Sub
    Private Sub Audit_Analysis_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        Grid1.Focus()
    End Sub
End Class