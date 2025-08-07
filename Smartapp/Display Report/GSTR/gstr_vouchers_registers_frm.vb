Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Data.SQLite

Public Class gstr_vouchers_registers_frm
    Dim From_ID As String
    Private VC_Type_ As String
    Private VC_ID_ As String
    Private Path_End As String
    Dim YN_Details As Boolean
    Dim Acc_Under As String
    Dim Frm_date As Date
    Dim to_date As Date

    Public Branch_ID As String = ""
    Public Voucher_Type As String = ""
    Public Branch As String = "Primary"
    Public Narration_ As Boolean = False

    Public Delete_Entry = False
    Private Sub gstr_vouchers_registers_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID
        Path_End = BG_frm.BG_Path_TXT.Text

        Label1.Text = Link_Valu(4)
        VC_ID_ = Link_Valu(0)
        VC_Type_ = ""
        Branch_ID = Link_Valu(1)
        Frm_Date_LB.Text = Date_Formate(Link_Valu(2))
        To_Date_LB.Text = Date_Formate(Link_Valu(3))
        Voucher_Type = Link_Valu(4)

        BG_frm.HADE_TXT.Text = "GSTR Vouchers Register"
        BG_frm.TYP_TXT.Text = ""

        'Button_Manage()
        'Add_Hander_Remove_Handel(True)

        Branch = Find_Branch_Name(Branch_ID)
        Label17.Text = Branch
        Grid1.Focus()
    End Sub

    Private Sub gstr_vouchers_registers_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.HADE_TXT.Text = "GSTR Vouchers Register"
        BG_frm.TYP_TXT.Text = VC_Type_

        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text
        Button_Clear()
        'Config_Fill()
        'If Update_Report = True Then
        Fill_Grid()
        'End If
        Grid1.Focus()
    End Sub

    Private Sub gstr_vouchers_registers_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub Included_in_return_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End
        Frm_foCus()
    End Sub
    Private Sub Frm_Date_LB_TextChanged(sender As Object, e As EventArgs) Handles Frm_Date_LB.TextChanged
        Frm_date = Frm_Date_LB.Text
    End Sub
    Private Sub To_Date_LB_TextChanged(sender As Object, e As EventArgs) Handles To_Date_LB.TextChanged
        to_date = To_Date_LB.Text
    End Sub
    Private Sub Grid1_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles Grid1.RowsAdded
        sender.Rows(sender.Rows.Count - 1).Height = 18
    End Sub
    Private Function Where_Filter() As String
        Dim q As String
        If Branch <> "Primary" Then
            q &= " AND VC.Branch = '" & Find_DT_Value(Database_File.cre, "TBL_Ledger", "ID", "Name = '" & Branch & "'") & "'"
        End If
        Return q
    End Function
    Private Function Fill_Grid_GSTR1()
        Dim cnn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cnn) = True Then
            Dim vc_ As String
            If VC_ID_ = "GSTR1" Then
                vc_ = "(vc.voucher_Type = 'Sales' or vc.voucher_Type = 'Purchase Return')"
            ElseIf VC_ID_ = "GSTR1" Then
                vc_ = "(vc.voucher_Type = 'Purchase' or vc.voucher_Type = 'Sales Return')"
            End If

            If Voucher_Type = "Incomplete information in HSN/SAC Summary (Corrections needed)" Then
                qury = "Select vc.Tra_ID,vc.[Date],(Select [Name] From TBL_Ledger where id = vc.Account) as Account,vc.Voucher_Type,vc.Voucher_No,vc.Dr,vc.Cr From TBL_VC vc

LEFT JOIN TBL_Stock_Item IT
ON VC.Particuls = IT.[ID]

where (it.HSN_Code = '' or it.HSN_Code = NULL) and vc.CR_DR = 'Under' and vc.Visible = 'Approval' and " & vc_ & " " & Where_Filter() & " and  (Date BETWEEN @Frm_Date and @To_Date) Order By vc.[Date]"

                Dim r As SQLiteDataReader
                cmd = New SQLiteCommand(qury, cnn)
                With cmd.Parameters
                    .AddWithValue("@Frm_Date", Frm_date.ToString("MM-dd-yyyy"))
                    .AddWithValue("@To_Date", to_date.ToString("MM-dd-yyyy"))
                    r = cmd.ExecuteReader
                    Dim Duplicate_ID As String
                    While r.Read
                        If r("Tra_ID") <> Duplicate_ID Then
                            Dim Cr As String
                            Dim Dr As String
                            If Val(r("Cr")) <> 0 Then
                                Cr = N2_FORMATE(r("Cr"))
                                Dr = ""
                            Else
                                Dr = N2_FORMATE(r("Dr"))
                                Cr = ""
                            End If
                            Grid1.Rows.Add(CDate(r("Date")).ToString("dd-MM-yyyy"), r("Account"), r("Voucher_Type"), r("Voucher_No"), Dr, Cr, r("Tra_ID"))
                            Duplicate_ID = r("Tra_ID")
                        End If
                    End While
                    r.Close()
                End With
            Else
                qury = "Select vc.Tra_ID,vc.[Date],(Select [Name] From TBL_Ledger where id = vc.Account) as Account,vc.Voucher_Type,vc.Voucher_No,vc.Dr,vc.Cr From TBL_VC vc
where vc.CR_DR = 'Head' and vc.Visible = 'Approval' and (vc.voucher_Type= '" & Voucher_Type & "') " & Where_Filter() & " and  (Date BETWEEN @Frm_Date and @To_Date) Order By vc.[Date]"

                Dim r As SQLiteDataReader
                cmd = New SQLiteCommand(qury, cnn)
                With cmd.Parameters
                    .AddWithValue("@Frm_Date", Frm_date.ToString("MM-dd-yyyy"))
                    .AddWithValue("@To_Date", to_date.ToString("MM-dd-yyyy"))
                    r = cmd.ExecuteReader
                    While r.Read
                        Dim Cr As String
                        Dim Dr As String
                        If Val(r("Cr")) <> 0 Then
                            Cr = N2_FORMATE(r("Cr"))
                            Dr = ""
                        Else
                            Dr = N2_FORMATE(r("Dr"))
                            Cr = ""
                        End If
                        Grid1.Rows.Add(CDate(r("Date")).ToString("dd-MM-yyyy"), r("Account"), r("Voucher_Type"), r("Voucher_No"), Dr, Cr, r("Tra_ID"))
                    End While
                    r.Close()
                End With
            End If
        End If
    End Function
    Private Function Fill_Grid()
        Grid1.Rows.Clear()

        Fill_Grid_GSTR1()
    End Function

    Private Sub Grid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid1.CellContentClick

    End Sub

    Private Sub Grid1_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cell("Voucher BG", Grid1.CurrentRow.Cells(6).Value, "Alter_Close", Grid1.CurrentRow.Cells(2).Value)
        End If
    End Sub

    Private Sub gstr_vouchers_registers_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
    End Sub
End Class