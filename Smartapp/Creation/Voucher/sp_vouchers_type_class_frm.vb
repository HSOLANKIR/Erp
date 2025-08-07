Public Class sp_vouchers_type_class_frm
    Dim From_ID As String
    Dim Path_End As String
    Public VC_Type_ As String
    Public VC_ID_ As String
    Public Source_of_control As voucher_class_list_ctrl
    Private Sub sp_vouchers_type_class_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID


        Path_End = BG_frm.BG_Path_TXT.Text

        VC_Type_ = Link_Valu(1)

        BG_frm.HADE_TXT.Text = "Voucher Type Class"
        BG_frm.TYP_TXT.Text = VC_Type_



        Button_Manage()
        Add_Hander_Remove_Handel(True)
    End Sub

    Private Sub sp_vouchers_type_class_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End

        BG_frm.HADE_TXT.Text = "Voucher Type Class"
        BG_frm.TYP_TXT.Text = VC_Type_
        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text
        Button_Clear()
        Button_Manage()
    End Sub

    Private Sub sp_vouchers_type_class_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If Msg_Exit_YN("Voucher Type Class") = DialogResult.Yes Then
                Me.Dispose()
                Source_of_control.Yn1.Focus()
            End If
        End If
    End Sub

    Private Sub sp_vouchers_type_class_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End
        Add_Hander_Remove_Handel(False)
        'Frm_foCus()
    End Sub
    Private Function Button_Manage()
        Button_Clear()
        BG_frm.B_1.Text = "&S : Save"
    End Function
    Private Function Add_Hander_Remove_Handel(Ans As Boolean)
        If Ans = True Then
            AddHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
        Else
            RemoveHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
        End If
    End Function
    Private Sub B_1_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Save_data()
        End If
    End Sub
    Private Function Save_data()
        If BG_frm.HADE_TXT.Text = "Voucher Type Class" Then
            Copy_data(ctrl1, Source_of_control.Ctrl)
            Me.Dispose()
            Source_of_control.Yn1.Focus()
            SendKeys.Send("{TAB}")
        End If
    End Function

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        obj_top(Panel1)
    End Sub

    Public Function Copy_data(source As sp_vouchers_type_class_ctrl, obj As sp_vouchers_type_class_ctrl)
        obj.Panel8.Controls.Clear()
        obj.Panel10.Controls.Clear()

        Try
            Dim P_ As New Queue(Of vouchers_type_class_group_list_ctrl)()
            For Each b As vouchers_type_class_group_list_ctrl In source.Panel8.Controls.OfType(Of vouchers_type_class_group_list_ctrl)()
                P_.Enqueue(b)
            Next
            For Each s As vouchers_type_class_group_list_ctrl In P_.Reverse
                obj.Add_Account_Group(s.Txt1.Text, s.statsu_txt.Text)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        If obj.Panel8.Controls.Count = 0 Then
            obj.Add_Account_Group("", "")
        End If

        Try
            Dim P_ As New Queue(Of vouchers_type_class_ledger_list_ctrl)()

            For Each b As vouchers_type_class_ledger_list_ctrl In source.Panel10.Controls.OfType(Of vouchers_type_class_ledger_list_ctrl)()
                P_.Enqueue(b)
            Next
            For Each s As vouchers_type_class_ledger_list_ctrl In P_.Reverse
                obj.Add_Ledger(s.Ledger_TXT.Text, s.calulation_TXT.Text, s.Dft_TXT.Text, s.Rounding_TXT.Text, s.Rounding_Limit.Text)
            Next
        Catch ex As Exception

        End Try

        If obj.Panel10.Controls.Count = 0 Then
            obj.Add_Ledger("", "", "", "", "")
        End If
    End Function

    Private Sub Txt1_TextChanged(sender As Object, e As EventArgs) Handles Txt1.TextChanged

    End Sub

    Private Sub Txt1_Enter(sender As Object, e As EventArgs) Handles Txt1.Enter
        If Msg_Save_YN(Txt1, "Vouchers Class") = DialogResult.Yes Then
            Save_data()
        End If
    End Sub

    Private Sub sp_vouchers_type_class_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
    End Sub
End Class