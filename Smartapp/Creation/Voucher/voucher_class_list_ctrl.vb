Imports System.Reflection
Imports Tools

Public Class voucher_class_list_ctrl
    Public Bg_Panel As Panel
    Public obj As Object
    Public Data_ As String
    Public Ctrl As sp_vouchers_type_class_ctrl

    Private Sub Yn1_TextChanged(sender As Object, e As EventArgs) Handles Yn1.TextChanged

    End Sub

    Private Sub Yn1_KeyDown(sender As Object, e As KeyEventArgs) Handles Yn1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim index As Integer = Integer.Parse(Name.Split("_")(1))
            If Bg_Panel.Controls.Count = index Then
                If Txt1.Text <> Nothing Then
                    obj.Add_Class("", "")
                End If
            End If

            If sender.Text = "Yes" Then

                Ctrl.Label3.Text = Txt1.Text
                Ctrl.Label4.Text = obj.VC_Formate_
                Cell("Voucher Type Class", "", BG_frm.TYP_TXT.Text)


                With sp_vouchers_type_class_frm
                    .ctrl1.Label3.Text = Txt1.Text
                    .ctrl1.Label4.Text = obj.VC_Formate_
                    .Source_of_control = Me

                    .Copy_data(Ctrl, .ctrl1)

                    .Focus()
                End With

                'obj.Panel30.Controls.Add(Ctrl)

            End If
        End If
    End Sub

    Private Sub voucher_class_list_ctrl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Name = $"classbg_{Bg_Panel.Controls.Count}"
    End Sub

    Private Sub Txt1_TextChanged(sender As Object, e As EventArgs) Handles Txt1.TextChanged

    End Sub

    Private Sub Txt1_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Txt1.Text = "" Then
                Yn1.Enabled = False
            Else
                Yn1.Enabled = True
                Dim all_ = GetAllControls(obj.Panel19).OfType(Of voucher_class_list_ctrl)().ToList()
                all_.FindAll(Function(i)
                                 If i.Txt1.Text = Txt1.Text AndAlso i.Name <> Me.Name Then
                                     Msg_Custom_YN(NOT_Location.Bottom_Right, Color.Red, My.Resources.Warning_animation_icn, Dialoag_Button.Ok, "Duplicate Class", "Voucher Type Class", $"'{Txt1.Text}' already exists.")
                                     Txt1.Focus()
                                     Exit Function
                                 End If
                             End Function)

            End If
        End If
    End Sub
End Class
