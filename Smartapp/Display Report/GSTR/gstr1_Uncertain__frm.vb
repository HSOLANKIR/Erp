Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Data.SQLite

Public Class gstr1_Uncertain__frm
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
    Private Sub gstr1_Uncertain__frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text

        VC_ID_ = Link_Valu(0)
        Label1.Text = VC_ID_ & " - Uncertain Transactions"

        Frm_Date_LB.Text = Date_Formate(Link_Valu(2))
        To_Date_LB.Text = Date_Formate(Link_Valu(3))

        BG_frm.HADE_TXT.Text = "Uncertain Transactions"
        BG_frm.TYP_TXT.Text = VC_ID_

        Button_Manage()
        Add_Hander_Remove_Handel(True)

        Branch_ID = Link_Valu(1)
        Branch = Find_Branch_Name(Branch_ID)
        Label17.Text = Branch
        Grid1.Focus()
    End Sub
    Private Function Button_Manage()
        Button_Clear()
        BG_frm.B_2.Text = "|&R : Refresh"
    End Function
    Private Function Add_Hander_Remove_Handel(Ans As Boolean)
        If Ans = True Then
            AddHandler BG_frm.R_2.Click, AddressOf Me.R_3_Click
        Else
            RemoveHandler BG_frm.R_2.Click, AddressOf Me.R_3_Click
        End If

    End Function
    Private Sub R_3_Click(sender As Object, e As EventArgs)
        If BG_frm.HADE_TXT.Text = VC_Type_ Then

        End If
    End Sub

    Private Sub gstr1_Uncertain__frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.HADE_TXT.Text = "Uncertain Transactions"
        BG_frm.TYP_TXT.Text = VC_Type_

        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text
        Button_Clear()
        Button_Manage()
        'Config_Fill()
        'If Update_Report = True Then
        Fill_Grid()
        'End If

        Grid1.Focus()
    End Sub

    Private Sub gstr1_Uncertain__frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub gstr1_Uncertain__frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
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
    Private Function Fill_Grid()
        Grid1.Rows.Clear()
        GST_ = 0
        Unit_ = 0
        Hsn_ = 0
        Dim cnn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cnn) = True Then
            GST_Ck(cnn)
            Unit_Ck(cnn)
            HSN_Ck(cnn)
        End If
        If GST_ <> 0 Then
            Grid1.Rows.Add("GST Number Errors", GST_)
        End If
        If Unit_ <> 0 Then
            Grid1.Rows.Add("Stock Unit Errors", Unit_)
        End If
        If Hsn_ <> 0 Then
            Grid1.Rows.Add("HSN Code Errors", Hsn_)
        End If
    End Function
    Dim GST_ As Integer = 0
    Dim Unit_ As Integer = 0
    Dim Hsn_ As Integer = 0
    Private Function GST_Ck(cnn As SQLiteConnection) As Boolean
        Dim vt As String
        If VC_ID_ = "GSTR1" Then
            vt = "(vc.Voucher_type = 'Sales'  or vc.Voucher_type = 'Purchase Return')"
        ElseIf VC_ID_ = "GSTR2" Then
            vt = "(vc.Voucher_type = 'Purchase'  or vc.Voucher_type = 'Sales Return')"
        End If

        'GST No
        qury = "Select (Select [GSTNo] from TBL_Ledger where ID = vc.Account) as GSTNo_A
From TBL_VC vc 

where vc.CR_DR = 'Head' and " & vt & " and vc.Visible = 'Approval' " & Where_Filter() & " and  (Date BETWEEN @Frm_Date and @To_Date) 
Group By vc.Account"

        Dim r As SQLiteDataReader
        cmd = New SQLiteCommand(qury, cnn)
        With cmd.Parameters
            .AddWithValue("@Frm_Date", Frm_date.ToString("MM-dd-yyyy"))
            .AddWithValue("@To_Date", to_date.ToString("MM-dd-yyyy"))
            r = cmd.ExecuteReader
            While r.Read
                If r("GSTNo_A").ToString = Nothing Or r("GSTNo_A").ToString = Company_GST_str Then
                    GST_ += 1
                End If
            End While
            r.Close()
        End With
        'GST No
        qury = "Select (Select [GSTNo] from TBL_Ledger where ID = vc.Particuls) as GSTNo_P
From TBL_VC vc 

where vc.CR_DR = 'Under' and (vc.Voucher_type = 'Credit Note') and vc.Visible = 'Approval' " & Where_Filter() & " and  (Date BETWEEN @Frm_Date and @To_Date) 
Group By vc.Particuls"

        cmd = New SQLiteCommand(qury, cnn)
        With cmd.Parameters
            .AddWithValue("@Frm_Date", Frm_date.ToString("MM-dd-yyyy"))
            .AddWithValue("@To_Date", to_date.ToString("MM-dd-yyyy"))
            r = cmd.ExecuteReader
            While r.Read
                If r("GSTNo_P").ToString = Nothing Or r("GSTNo_P").ToString = Company_GST_str Then
                    GST_ += 1
                End If
            End While
            r.Close()
        End With
    End Function
    Private Function Unit_Ck(cnn As SQLiteConnection) As Boolean
        Dim vt As String
        If VC_ID_ = "GSTR1" Then
            vt = "(vc.Voucher_type = 'Sales'  or vc.Voucher_type = 'Purchase Return')"
        ElseIf VC_ID_ = "GSTR2" Then
            vt = "(vc.Voucher_type = 'Purchase'  or vc.Voucher_type = 'Sales Return')"
        End If

        qury = "Select (Select UQC from TBL_Inventory_Unit where ID = (Select Unit from TBL_Stock_Item where ID = vc.Particuls)) as Unit
From TBL_VC vc 

where vc.CR_DR = 'Under' and " & vt & " and vc.Visible = 'Approval' " & Where_Filter() & " and  (Date BETWEEN @Frm_Date and @To_Date) 
Group By vc.Particuls"

        Dim r As SQLiteDataReader
        cmd = New SQLiteCommand(qury, cnn)
        With cmd.Parameters
            .AddWithValue("@Frm_Date", Frm_date.ToString("MM-dd-yyyy"))
            .AddWithValue("@To_Date", to_date.ToString("MM-dd-yyyy"))
            r = cmd.ExecuteReader
            While r.Read
                If r("Unit").ToString = Nothing Then
                    Unit_ += 1
                End If
            End While
            r.Close()
        End With
    End Function
    Private Function HSN_Ck(cnn As SQLiteConnection) As Boolean
        Dim vt As String
        If VC_ID_ = "GSTR1" Then
            vt = "(vc.Voucher_type = 'Sales'  or vc.Voucher_type = 'Purchase Return')"
        ElseIf VC_ID_ = "GSTR2" Then
            vt = "(vc.Voucher_type = 'Purchase'  or vc.Voucher_type = 'Sales Return')"
        End If

        qury = "Select (Select HSN_Code from TBL_Stock_Item where ID = vc.Particuls) as HSN
From TBL_VC vc 

where vc.CR_DR = 'Under' and " & vt & " and vc.Visible = 'Approval' " & Where_Filter() & " and  (Date BETWEEN @Frm_Date and @To_Date) 
Group By vc.Particuls"

        Dim r As SQLiteDataReader
        cmd = New SQLiteCommand(qury, cnn)
        With cmd.Parameters
            .AddWithValue("@Frm_Date", Frm_date.ToString("MM-dd-yyyy"))
            .AddWithValue("@To_Date", to_date.ToString("MM-dd-yyyy"))
            r = cmd.ExecuteReader
            While r.Read
                If r("HSN").ToString = Nothing Then
                    Hsn_ += 1
                End If
            End While
            r.Close()
        End With
    End Function

    Private Sub Grid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid1.CellContentClick

    End Sub

    Private Sub Grid1_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cell("Uncertain Vouchers", VC_ID_, Branch_ID, Frm_date, to_date, Grid1.CurrentRow.Cells(0).Value)
        End If
    End Sub

    Private Sub gstr1_Uncertain__frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus

        BG_frm.From_ID = From_ID
    End Sub
End Class