Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Data.SQLite

Public Class GSTR_Update_vouchers_frm
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
    Private Sub GSTR_Update_vouchers_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text

        Label1.Text = Link_Valu(0) & " - Uncertain Vouchers"
        VC_ID_ = Link_Valu(0)
        VC_Type_ = Link_Valu(4)

        Frm_Date_LB.Text = Date_Formate(Link_Valu(2))
        To_Date_LB.Text = Date_Formate(Link_Valu(3))

        BG_frm.HADE_TXT.Text = "Uncertain Vouchers"
        BG_frm.TYP_TXT.Text = VC_Type_

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

    Private Sub GSTR_Update_vouchers_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.HADE_TXT.Text = "Uncertain Vouchers"
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

    Private Sub GSTR_Update_vouchers_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub GSTR_Update_vouchers_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
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
        Dim vt As String
        If VC_ID_ = "GSTR1" Then
            vt = "(vc.Voucher_type = 'Sales'  or vc.Voucher_type = 'Purchase Return')"
        ElseIf VC_ID_ = "GSTR2" Then
            vt = "(vc.Voucher_type = 'Purchase'  or vc.Voucher_type = 'Sales Return')"
        End If


        Grid1.Rows.Clear()
        Dim cnn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cnn) = True Then
            If VC_Type_ = "GST Number Errors" Then
                qury = "Select (Select [Name] from TBL_Ledger Where ID = vc.Account) as [Name],(Select [GSTNo] from TBL_Ledger Where ID = vc.Account) as GST
From TBL_VC vc 

where " & vt & " and vc.Visible = 'Approval' " & Where_Filter() & " and  (Date BETWEEN @Frm_Date and @To_Date) Group By Account"

                Dim r As SQLiteDataReader
                cmd = New SQLiteCommand(qury, cnn)
                With cmd.Parameters
                    .AddWithValue("@Frm_Date", Frm_date.ToString("MM-dd-yyyy"))
                    .AddWithValue("@To_Date", to_date.ToString("MM-dd-yyyy"))
                    r = cmd.ExecuteReader
                    While r.Read
                        If r("GST").ToString = Nothing Then
                            Grid1.Rows.Add(r("Name"), "GST/UIN is Not specified/invalid")
                        ElseIf r("GST").ToString = Company_GST_str Then
                            Grid1.Rows.Add(r("Name"), "Company GST No and Party GST No. is Same")
                        End If
                    End While
                    r.Close()
                End With
                '''
                qury = "Select (Select [Name] from TBL_Ledger Where ID = vc.Particuls) as [Name],(Select [GSTNo] from TBL_Ledger Where ID = vc.Particuls) as GST
From TBL_VC vc 

where (vc.Voucher_type = 'Credit Note') and vc.Visible = 'Approval' " & Where_Filter() & " and  (Date BETWEEN @Frm_Date and @To_Date) 
Group By Particuls"

                cmd = New SQLiteCommand(qury, cnn)
                With cmd.Parameters
                    .AddWithValue("@Frm_Date", Frm_date.ToString("MM-dd-yyyy"))
                    .AddWithValue("@To_Date", to_date.ToString("MM-dd-yyyy"))
                    r = cmd.ExecuteReader
                    While r.Read
                        If r("GST").ToString = Nothing Then
                            Grid1.Rows.Add(r("Name"), "GST/UIN is Not specified/invalid")
                        ElseIf r("GST").ToString = Company_GST_str Then
                            Grid1.Rows.Add(r("Name"), "Company GST No and Party GST No. is Same")
                        End If
                    End While
                    r.Close()
                End With
            ElseIf VC_Type_ = "Stock Unit Errors" Then
                qury = "Select (Select [Name] from TBL_Stock_Item Where ID = vc.Particuls) as [Name],(Select UQC from TBL_Inventory_Unit Where ID = (Select [Unit] from TBL_Stock_Item Where ID = vc.Particuls)) as Unit
From TBL_VC vc 

where vc.CR_DR = 'Under'  and " & vt & " and vc.Visible = 'Approval' " & Where_Filter() & " and  (Date BETWEEN @Frm_Date and @To_Date) 
Group By Particuls"

                Dim r As SQLiteDataReader
                cmd = New SQLiteCommand(qury, cnn)
                With cmd.Parameters
                    .AddWithValue("@Frm_Date", Frm_date.ToString("MM-dd-yyyy"))
                    .AddWithValue("@To_Date", to_date.ToString("MM-dd-yyyy"))
                    r = cmd.ExecuteReader
                    While r.Read
                        If r("Unit").ToString = Nothing Then
                            Grid1.Rows.Add(r("Name"), "Reporting Unit Quantity Code (UQC) not selected for stock items with multiple UQC")
                        End If
                    End While
                    r.Close()
                End With
            ElseIf VC_Type_ = "HSN Code Errors" Then
                qury = "Select (Select [Name] from TBL_Stock_Item Where ID = vc.Particuls) as [Name],(Select HSN_Code from TBL_Stock_Item Where ID = vc.Particuls) as [HSN]
From TBL_VC vc 

where vc.CR_DR = 'Under'  and " & vt & " and vc.Visible = 'Approval' " & Where_Filter() & " and  (Date BETWEEN @Frm_Date and @To_Date) 
Group By Particuls"

                Dim r As SQLiteDataReader
                cmd = New SQLiteCommand(qury, cnn)
                With cmd.Parameters
                    .AddWithValue("@Frm_Date", Frm_date.ToString("MM-dd-yyyy"))
                    .AddWithValue("@To_Date", to_date.ToString("MM-dd-yyyy"))
                    r = cmd.ExecuteReader
                    While r.Read
                        If r("HSN").ToString = Nothing Then
                            Grid1.Rows.Add(r("Name"), "HSN/SAC Code is Not Entered")
                        End If
                    End While
                    r.Close()
                End With
            End If
        End If

        Grid1.Columns(1).DefaultCellStyle.ForeColor = Color.Red
        Grid1.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Grid1.Columns(1).DefaultCellStyle.WrapMode = DataGridViewTriState.True
    End Function

    Private Sub Grid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid1.CellContentClick

    End Sub

    Private Sub Grid1_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim Name As String = Grid1.CurrentRow.Cells(0).Value.ToString.Trim
            Dim erro As String = Grid1.CurrentRow.Cells(1).Value.ToString.Trim
            Cell("Uncertain Resolution", VC_ID_, Branch_ID, Name, erro)
        End If
    End Sub

    Private Sub GSTR_Update_vouchers_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
    End Sub
End Class