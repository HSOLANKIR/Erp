Public Class Voucher_BG_frm
    'Dim frm As Form
    Public Date_ As String = ""
    Public VC_Type_ As String
    Public Tra_ID As String
    'Cell("Voucher BG", "", "Create", "Contra")
    Private Sub Voucher_BG_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        VC_Type_ = Link_Valu(2)

        Try
            Date_ = Date_Formate(Link_Valu(4))
        Catch ex As Exception

        End Try

        Try
            Tra_ID = Link_Valu(5)
        Catch ex As Exception

        End Try

        If Link_Valu(1) = "Create" Or Link_Valu(1) = "Create_Close" Then
            'VC_ID_ = Link_Valu(3)
        End If
        Load_()
    End Sub

    Private Sub Voucher_BG_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If Msg_Exit_YN("Vouchers") = DialogResult.Yes Then
                Me.Dispose()
                Frm_foCus()
                Update_Report = False
            End If
        End If
    End Sub
    Public Function Load_()
        If VC_Type_ = "Payment" Or VC_Type_ = "Receipt" Or VC_Type_ = "Contra" Or VC_Type_ = "Journal" Then
            With Accounting_Voucher_frm
                .TopLevel = False
                Me.BG_Panel.Controls.Clear()
                Me.BG_Panel.Controls.Add(Accounting_Voucher_frm)
                .Dock = DockStyle.Fill
                .Show()
                .BringToFront()
                .Focus()

                If Date_.ToString <> Nothing Then
                    .Date_TXT.Text = Date_Formate(Date_)
                End If
                If Val(Tra_ID) <> 0 Then
                    .Tra_ID = Tra_ID
                End If
                .Date_TXT.Focus()
            End With
        ElseIf VC_Type_ = "Purchase" Or VC_Type_ = "Purchase Order" Or VC_Type_ = "Sales" Or VC_Type_ = "Sales Return" Or VC_Type_ = "Purchase Return" Or VC_Type_ = "Sales Order" Or VC_Type_ = "Inward Register" Or VC_Type_ = "Outward Register" Or VC_Type_ = "Credit Note" Or VC_Type_ = "Debit Note" Or VC_Type_ = "Stock Journal" Then

            With Inventory_Vouchers_frm
                .TopLevel = False
                Me.BG_Panel.Controls.Clear()
                Me.BG_Panel.Controls.Add(Inventory_Vouchers_frm)
                .Dock = DockStyle.Fill
                .Show()
                .BringToFront()
                .Focus()

                If Date_.ToString <> Nothing Then
                    .Date_TXT.Text = Date_Formate(Date_)
                End If
                If Val(Tra_ID) <> 0 Then
                    .Tra_ID = Tra_ID
                End If
                .Date_TXT.Focus()

            End With

        ElseIf VC_Type_ = "Attendance" Or VC_Type_ = "Payroll" Then
            With Payroll_Vouchers_frm
                .TopLevel = False
                Me.BG_Panel.Controls.Clear()
                Me.BG_Panel.Controls.Add(Payroll_Vouchers_frm)
                .Dock = DockStyle.Fill
                .Show()
                .BringToFront()
                .Focus()

                If Date_.ToString <> Nothing Then
                    .Date_TXT.Text = Date_Formate(Date_)
                End If
                If Val(Tra_ID) <> 0 Then
                    .Tra_ID = Tra_ID
                End If
                .Date_TXT.Focus()

            End With
        End If

    End Function

    Private Sub BG_Panel_Paint(sender As Object, e As PaintEventArgs) Handles BG_Panel.Paint

    End Sub

    Private Sub Voucher_BG_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed

    End Sub

    Private Sub Voucher_BG_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus

    End Sub

    Private Sub Voucher_BG_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter

    End Sub
End Class