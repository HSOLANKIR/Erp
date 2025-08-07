Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Data.SQLite

Public Class Included_in_return_frm
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
    Public Narration_ As Boolean = False

    Public Delete_Entry = False
    Private Sub gstr1_included_in_return_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text

        VC_Type_ = Link_Valu(0)
        Label1.Text = Link_Valu(1) & " - " & VC_Type_
        VC_ID_ = Link_Valu(1)

        Branch_ID = Link_Valu(2)
        Frm_Date_LB.Text = Date_Formate(Link_Valu(3))
        To_Date_LB.Text = Date_Formate(Link_Valu(4))

        BG_frm.HADE_TXT.Text = VC_Type_
        BG_frm.TYP_TXT.Text = ""

        'Button_Manage()
        'Add_Hander_Remove_Handel(True)

        Branch = Find_Branch_Name(Branch_ID)
        Label17.Text = Branch
        Grid1.Focus()
    End Sub

    Private Sub Included_in_return_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.HADE_TXT.Text = VC_Type_
        BG_frm.TYP_TXT.Text = VC_Type_

        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text
        Button_Clear()
        'Config_Fill()
        'If Update_Report = True Then
        Fill_Grid()
        'End If
        Grid1.Focus()
    End Sub

    Private Sub Included_in_return_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
        Dim vc As String
        If VC_Type_ = "Included in Return" Then
            vc = "(vc.voucher_Type = 'Sales' or vc.voucher_Type= 'Purchase Return' or vc.voucher_Type= 'Credit Note')"
        Else
            vc = "(vc.voucher_Type <> 'Sales' and vc.voucher_Type <> 'Purchase Return' and vc.voucher_Type <> 'Credit Note')"

        End If
        Dim cnn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cnn) = True Then
            qury = "Select vc.Voucher_Type,count(vc.tra_ID) as vlu From TBL_VC vc
where vc.CR_DR = 'Head' and " & vc & " " & Where_Filter() & " and vc.Visible = 'Approval' and (Date BETWEEN @Frm_Date and @To_Date) Group By  vc.Voucher_Type"

            Dim r As SQLiteDataReader
            cmd = New SQLiteCommand(qury, cnn)
            With cmd.Parameters
                .AddWithValue("@Frm_Date", Frm_date.ToString("MM-dd-yyyy"))
                .AddWithValue("@To_Date", to_date.ToString("MM-dd-yyyy"))
                r = cmd.ExecuteReader
                Dim vlu As Integer
                While r.Read
                    If Val(r("Vlu")) <> 0 Then
                        Grid1.Rows.Add(r("Voucher_Type"), Val(r("Vlu")))
                        vlu += Val(r("Vlu"))
                    Else
                    End If
                End While
                r.Close()
                Label2.Text = vlu
            End With
        End If
    End Function
    Private Function Fill_Grid_GSTR2()
        Dim vc As String
        If VC_Type_ = "Included in Return" Then
            vc = "(vc.voucher_Type = 'Purchase' or vc.voucher_Type= 'Sales Return' or vc.voucher_Type= 'Debit Note')"
        Else
            vc = "(vc.voucher_Type <> 'Purchase' and vc.voucher_Type <> 'Sales Return' and vc.voucher_Type <> 'Debit Note')"

        End If
        Dim cnn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cnn) = True Then
            qury = "Select vc.Voucher_Type,count(vc.tra_ID) as vlu From TBL_VC vc
where vc.CR_DR = 'Head' and " & vc & " " & Where_Filter() & " and vc.Visible = 'Approval' and (Date BETWEEN @Frm_Date and @To_Date) Group By  vc.Voucher_Type"

            Dim r As SQLiteDataReader
            cmd = New SQLiteCommand(qury, cnn)
            With cmd.Parameters
                .AddWithValue("@Frm_Date", Frm_date.ToString("MM-dd-yyyy"))
                .AddWithValue("@To_Date", to_date.ToString("MM-dd-yyyy"))
                r = cmd.ExecuteReader
                Dim vlu As Integer
                While r.Read
                    If Val(r("Vlu")) <> 0 Then
                        Grid1.Rows.Add(r("Voucher_Type"), Val(r("Vlu")))
                        vlu += Val(r("Vlu"))
                    Else
                    End If
                End While
                r.Close()
                Label2.Text = vlu
            End With
        End If
    End Function
    Private Function Fill_Grid()
        Grid1.Rows.Clear()

        If VC_ID_ = "GSTR1" Then
            Fill_Grid_GSTR1()
        ElseIf VC_ID_ = "GSTR2" Then
            Fill_Grid_GSTR2()
        End If
    End Function

    Private Sub Grid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid1.CellContentClick

    End Sub

    Private Sub Grid1_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cell("GSTR Vouchers Register", VC_ID_, Branch_ID, Frm_date, to_date, Grid1.CurrentRow.Cells(0).Value.ToString)
        End If
    End Sub

    Private Sub Included_in_return_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
    End Sub
End Class