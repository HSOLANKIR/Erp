Imports System.Data.SqlClient
Imports System.Data.SQLite

Public Class Voucher_cfg
    Dim From_ID As String
    Dim Path_End As String
    Dim VC_Type_ As String
    Dim VC_ID_ As String
    Private Sub Voucher_cfg_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text

        VC_Type_ = Link_Valu(1)
        VC_ID_ = Link_Valu(2)


        BG_frm.HADE_TXT.Text = "Vouchers Configuration"
        BG_frm.TYP_TXT.Text = ""


        Button_Manage()
        Add_Hander_Remove_Handel(True)

        Load_()

        Setup_VC()
    End Sub
    Private Function Button_Manage()
        Button_Clear()
        BG_frm.B_1.Text = "&E : Exit"
        BG_frm.B_2.Text = "&S : Save"
    End Function
    Public Function Load_()
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select * From TBL_Voucher_Create where id = '{VC_ID_}'", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                Label1.Text = r("Name")
                Type_.Text = r("Under")
            End While
            r.Close()
        End If
        cn.Close()
    End Function
    Private Function Add_Hander_Remove_Handel(ans As Boolean)
        If ans = True Then
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
            Save_data()
        End If
    End Sub
    Private Function Save_data()
        ctrl.Save_Data(Label1.Text)
        Me.Dispose()
    End Function
    Private Sub Voucher_cfg_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        Panel1.Location = New Point(Me.ClientSize.Width / 2 - Panel1.Size.Width / 2, Me.ClientSize.Height / 2 - Panel1.Size.Height / 2)

        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.HADE_TXT.Text = "Vouchers Configuration"
        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text

        ctrl.Focus
    End Sub

    Private Sub Voucher_cfg_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If Msg_Exit_YN(Label1.Text) = DialogResult.Yes Then
                Me.Dispose()
                NOT_Clear()
            End If
        End If
    End Sub

    Private Sub Voucher_cfg_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End
        Add_Hander_Remove_Handel(False)
        Frm_foCus()
        SendKeys.Send("{TAB}")
    End Sub
    Dim ctrl As Object
    Private Function Setup_VC()


        If Type_.Text = "Payment" Or Type_.Text = "Receipt" Or Type_.Text = "Contra" Or Type_.Text = "Journal" Then
            ctrl_manage(cprj)
        ElseIf Type_.Text = "Purchase" Or Type_.Text = "Purchase Order" Or Type_.Text = "Sales" Or Type_.Text = "Sales Order" Or Type_.Text = "Sales Return" Or Type_.Text = "Purchase Return" Or Type_.Text = "Inward Register" Or Type_.Text = "Outward Register" Or Type_.Text = "Credit Note" Or Type_.Text = "Debit Note" Then
            ctrl_manage(Sp_voucher_create_ctrl1)
        ElseIf Type_.Text = "Stock Journal" Then
            ctrl_manage(Stock_journal_create_ctrl1)
        ElseIf Type_.Text = "Attendance" Or Type_.Text = "Payroll" Then
            ctrl_manage(Payroll)
        End If
    End Function
    Private Function ctrl_manage(pan As Object)
        cprj.Visible = False
        Sp_voucher_create_ctrl1.Visible = False
        Stock_journal_create_ctrl1.Visible = False
        Payroll.Visible = False

        ctrl = pan
        ctrl.Dock = DockStyle.Fill
        ctrl.VC_Formate_ = Type_.Text
        ctrl.VC_ID_ = VC_ID_
        ctrl.VC_Type_ = VC_Type_
        ctrl.Visible = True
        ctrl.Fill_data()
    End Function

    Private Sub focus_txt_TextChanged(sender As Object, e As EventArgs) Handles focus_txt.TextChanged

    End Sub

    Private Sub focus_txt_Enter(sender As Object, e As EventArgs) Handles focus_txt.Enter
        If Msg_Save_YN(focus_txt, Label1.Text) = DialogResult.Yes Then
            Save_data()
        Else
            SelectNextControl(Me, False, False, False, True)
        End If
    End Sub

    Private Sub Voucher_cfg_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
    End Sub
End Class