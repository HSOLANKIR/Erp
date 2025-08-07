Imports System.Data.SqlClient
Imports System.Data.SQLite
Imports Microsoft.Reporting.WinForms
Public Class Expiry_Date_Item_Summary
    Dim From_ID As String
    Private VC_Type_ As String
    Private VC_ID_ As String
    Private Path_End As String
    Dim YN_Details As Boolean
    Dim Acc_Under As String
    Dim Frm_date As Date
    Dim to_date As Date

    Public Branch As String = "Primary"
    Public Branch_ID As String
    Public Narration_ As Boolean = False
    Public Delete_Entry = False


    Dim ds_print As New Print_dt
    Dim dt_print As New DataTable
    Private Sub Expiry_Date_Item_Summary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID


        Path_End = BG_frm.BG_Path_TXT.Text

        VC_ID_ = Link_Valu(0)
        Frm_Date_LB.Text = Link_Valu(1)
        To_Date_LB.Text = Link_Valu(2)

        Branch_ID = Link_Valu(3)

        Branch = Find_Branch_Name(Branch_ID)

        BG_frm.HADE_TXT.Text = "Stock Summary (Expiry Date Report)"
        BG_frm.TYP_TXT.Text = VC_Type_

        Button_Manage()
        Add_Hander_Remove_Handel(True)
        Branch = Branch_Name

        Label17.Text = "Branch : " & Branch
        Update_Report = True
    End Sub
    Private Function Button_Manage()
        BG_frm.R_1.Text = "|F1 : Detailed"
        BG_frm.R_2.Text = "F2 : Date"
        BG_frm.R_3.Text = "|F2 : Period"
        If Branch_Visible() = True Then
            BG_frm.R_5.Text = "F4 : Branch"
        End If

        BG_frm.B_1.Text = "|&P : Print"
    End Function
    Private Function Add_Hander_Remove_Handel(Ans As Boolean)
        If Ans = True Then
            AddHandler BG_frm.KeyDown, AddressOf Me.BG_Keydown
            AddHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click

            AddHandler BG_frm.R_1.Click, AddressOf Me.R_1_Click
            AddHandler BG_frm.R_2.Click, AddressOf Me.R_3_Click
            AddHandler BG_frm.R_3.Click, AddressOf Me.R_4_Click
            If Branch_Visible() = True Then
                AddHandler BG_frm.R_5.Click, AddressOf Me.R_9_Click
            End If
        Else
            RemoveHandler BG_frm.KeyDown, AddressOf Me.BG_Keydown
            RemoveHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            RemoveHandler BG_frm.R_1.Click, AddressOf Me.R_1_Click
            RemoveHandler BG_frm.R_2.Click, AddressOf Me.R_3_Click
            RemoveHandler BG_frm.R_3.Click, AddressOf Me.R_4_Click
            RemoveHandler BG_frm.R_5.Click, AddressOf Me.R_9_Click
        End If
    End Function
    Private Sub BG_Keydown(sender As Object, e As KeyEventArgs)
        If BG_frm.From_ID = From_ID Then
            If e.KeyCode = Keys.F1 AndAlso e.Modifiers = Keys.Alt Then
                BG_frm.R_1.PerformClick()
            End If
            If e.KeyCode = Keys.F2 AndAlso e.Modifiers = Keys.Alt Then
                BG_frm.R_3.PerformClick()
            ElseIf e.KeyCode = Keys.F2 Then
                BG_frm.R_2.PerformClick()
            End If
            If e.KeyCode = Keys.F4 AndAlso e.Modifiers = Keys.Alt Then

            ElseIf e.KeyCode = Keys.F4 Then
                BG_frm.R_5.PerformClick()
            End If
        End If
    End Sub
    Private Sub R_1_Click(sender As Object, e As EventArgs)
        If BG_frm.HADE_TXT.Text = "Stock Summary (Expiry Date Report)" Then
            If YN_Details = True Then
                YN_Details = False
                BG_frm.R_1.Text = "|F1 : Detailed"
            ElseIf YN_Details = False Then
                YN_Details = True
                BG_frm.R_1.Text = "|F1 : Condensed"
            End If
            Fill_Grid()
        End If
    End Sub
    Private Sub R_3_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            If Date_Set_Curr(False) = DialogResult.Yes Then
                To_Date_LB.Text = Date_3
                Fill_Grid()
            End If
        End If
    End Sub
    Private Sub R_9_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then

        End If
    End Sub
    Private Sub B_1_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Dim paramtr(2) As ReportParameter
            paramtr(0) = New ReportParameter("Item_Name_prmt", Acc_LB.Text)
            paramtr(1) = New ReportParameter("Date_prmt", To_Date_LB.Text)
            paramtr(2) = New ReportParameter("Total_prmt", Label2.Text)

            Print_Priew_frm.ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet2", dt_print))
            Print_Priew_frm.ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", Print_DT_Company))
            Print_Priew_frm.Print_Privew(Application.StartupPath & "\Print_\Report\Item_Stock_Expiry", "", paramtr)
        End If
    End Sub
    Private Sub R_4_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            If Date_Set_Curr(True) = DialogResult.Yes Then
                Frm_Date_LB.Text = Date_1
                To_Date_LB.Text = Date_2
                Fill_Grid()
            End If
        End If
    End Sub
    Private Sub Expiry_Date_Item_Summary_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.HADE_TXT.Text = "Stock Summary (Expiry Date Report)"
        BG_frm.TYP_TXT.Text = VC_Type_

        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text
        Button_Clear()
        Button_Manage()
        'Config_Fill()
        If Update_Report = True Then
            Fill_Grid()
        End If
        Grid1.Focus()
    End Sub

    Private Sub Expiry_Date_Item_Summary_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub Expiry_Date_Item_Summary_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
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
        Grid1.Rows(Grid1.Rows.Count - 1).Height = 18
    End Sub
    Private Function Fill_Grid()
        Acc_LB.Text = Find_DT_Value(Database_File.cre, "TBL_Stock_Group", "Name", "Id = '" & VC_ID_ & "'")

        dt_print.Rows.Clear()
        dt_print = ds_print.Tables("TBL_Stock_Item_Expiry_Date")

        Grid1.Rows.Clear()

        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            If Branch = "Primary" Then
                qury = "(Select IT.[Under],IT.[ID],IT.[Name],(Select [Symbol] From TBL_Inventory_Unit where ID = IT.Unit) as Unit,
--Inward
isnull((select SUM(Quantity)
From TBL_VC VC
where ((((VC.Voucher_Type = 'Purchase' or VC.Voucher_Type = 'Sales Return') and VC.CR_DR = 'Under' and  VC.Particuls = IT.ID) or (VC.Voucher_Type = 'Stock Journal' and VC.CR_DR = 'Head' and  VC.Account = IT.ID)) AND (VC.Visible = @Visible and VC.Company = @Company)) AND ([Date] < @Frm_Date)),0) + (it.OB_Quantity) as Inward_OB,
(select SUM(Quantity)
From TBL_VC VC
where ((((VC.Voucher_Type = 'Purchase' or VC.Voucher_Type = 'Sales Return') and VC.CR_DR = 'Under' and  VC.Particuls = IT.ID) or (VC.Voucher_Type = 'Stock Journal' and VC.CR_DR = 'Head' and  VC.Account = IT.ID)) AND (VC.Visible = @Visible and VC.Company = @Company)) AND (Date BETWEEN @Frm_Date and @To_Date)) as Inward,
--Outward
(select SUM(Quantity)
From TBL_VC VC
where (((((VC.Voucher_Type = 'Sales' or VC.Voucher_Type = 'Purchase Return') or VC.Voucher_Type = 'Purchase Return') and VC.CR_DR = 'Under' and  VC.Particuls = IT.ID) or (VC.Voucher_Type = 'Stock Journal' and VC.CR_DR = 'Under' and  VC.Particuls = IT.ID)) AND (VC.Visible = @Visible and VC.Company = @Company)) AND ([Date] < @Frm_Date)) as Outward_OB,
(select SUM(Quantity)
From TBL_VC VC
where (((((VC.Voucher_Type = 'Sales' or VC.Voucher_Type = 'Purchase Return') or VC.Voucher_Type = 'Purchase Return') and VC.CR_DR = 'Under' and  VC.Particuls = IT.ID) or (VC.Voucher_Type = 'Stock Journal' and VC.CR_DR = 'Under' and  VC.Particuls = IT.ID)) AND (VC.Visible = @Visible and VC.Company = @Company)) AND (Date BETWEEN @Frm_Date and @To_Date)) as Outward

From TBL_Stock_Item IT where IT.Under = @SG_Vlu)"
            Else
                qury = "(Select IT.[Under],IT.[ID],IT.[Name],(Select [Symbol] From TBL_Inventory_Unit where ID = IT.Unit) as Unit,
--Inward
isnull((select SUM(Quantity)
From TBL_VC VC
where ((((VC.Voucher_Type = 'Purchase' or VC.Voucher_Type = 'Sales Return') and VC.CR_DR = 'Under' and  VC.Particuls = IT.ID) or (VC.Voucher_Type = 'Stock Journal' and VC.CR_DR = 'Head' and  VC.Account = IT.ID)) AND (VC.Visible = @Visible and VC.Branch = '" & Branch_ID & "' and VC.Company = @Company)) AND ([Date] < @Frm_Date)),0) + (it.OB_Quantity) as Inward_OB,
(select SUM(Quantity)
From TBL_VC VC
where ((((VC.Voucher_Type = 'Purchase' or VC.Voucher_Type = 'Sales Return') and VC.CR_DR = 'Under' and  VC.Particuls = IT.ID) or (VC.Voucher_Type = 'Stock Journal' and VC.CR_DR = 'Head' and  VC.Account = IT.ID)) AND (VC.Visible = @Visible and VC.Branch = '" & Branch_ID & "' and VC.Company = @Company)) AND (Date BETWEEN @Frm_Date and @To_Date)) as Inward,
--Outward
(select SUM(Quantity)
From TBL_VC VC
where (((((VC.Voucher_Type = 'Sales' or VC.Voucher_Type = 'Purchase Return') or VC.Voucher_Type = 'Purchase Return') and VC.CR_DR = 'Under' and  VC.Particuls = IT.ID) or (VC.Voucher_Type = 'Stock Journal' and VC.CR_DR = 'Under' and  VC.Particuls = IT.ID)) AND (VC.Visible = @Visible and VC.Branch = '" & Branch_ID & "' and VC.Company = @Company)) AND ([Date] < @Frm_Date)) as Outward_OB,
(select SUM(Quantity)
From TBL_VC VC
where (((((VC.Voucher_Type = 'Sales' or VC.Voucher_Type = 'Purchase Return') or VC.Voucher_Type = 'Purchase Return') and VC.CR_DR = 'Under' and  VC.Particuls = IT.ID) or (VC.Voucher_Type = 'Stock Journal' and VC.CR_DR = 'Under' and  VC.Particuls = IT.ID)) AND (VC.Visible = @Visible and VC.Branch = '" & Branch_ID & "' and VC.Company = @Company)) AND (Date BETWEEN @Frm_Date and @To_Date)) as Outward

From TBL_Stock_Item IT where IT.Under = @SG_Vlu)"
            End If
            cmd = New SQLiteCommand(qury, cn)
            Dim r As SQLiteDataReader
            With cmd.Parameters
                .AddWithValue("@Company", Company_ID_str)
                .AddWithValue("@Visible", "Approval")
                .AddWithValue("@SG_Vlu", VC_ID_)
                .AddWithValue("@Branch", Branch_ID)
                .AddWithValue("@Frm_Date", Frm_date.ToString("MM-dd-yyyy"))
                .AddWithValue("@To_Date", to_date.ToString("MM-dd-yyyy"))
                r = cmd.ExecuteReader
                While r.Read
                    Dim vlu As Decimal = Val(Val(r("Inward").ToString) - Val(r("Outward").ToString))
                    Dim vlu_Ob As Decimal = Val(Val(r("Inward_OB").ToString) - Val(r("Outward_OB").ToString))

                    Grid1.Rows.Add("Head", r("Name").ToString, r("Unit"), "", "", N2_FORMATE(vlu_Ob), N2_FORMATE(r("Inward").ToString), N2_FORMATE(r("Outward").ToString), N2_FORMATE(vlu + vlu_Ob))


                    dt_print.Rows.Add(r("Name").ToString, "", r("Unit"), "", "", N2_FORMATE(vlu_Ob), N2_FORMATE(r("Inward").ToString), N2_FORMATE(r("Outward").ToString), N2_FORMATE(vlu + vlu_Ob))

                    If YN_Details = True Then
                        Fill_Batch(r("ID"), r("Unit"))
                    End If
                End While
            End With
        End If
    End Function
    Private Function Fill_Batch(ID, Unit)
        Dim cn As New SQLiteConnection
        Dim Group_By As String
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            Dim qy As String
            If Branch = "Primary" Then
                qy = "select vc.[Batch_No],
(Select top 1([Expiry_Date]) From TBL_VC where Batch_No = VC.Batch_No and Particuls = @SG_Vlu and (Voucher_Type = 'Purchase' or Voucher_Type = 'Sales Return') and Visible = 'Approval') as Expiry_,
isnull((Select SUM(Quantity) From TBL_VC where (Voucher_Type = 'Purchase' or Voucher_Type = 'Sales Return') and Particuls = @SG_Vlu AND CR_DR = 'Under' AND Visible = 'Approval' and Batch_No = vc.Batch_No and ([Date] < @Frm_Date)),0) as Inward_OB,
isnull((Select SUM(Quantity) From TBL_VC where (Voucher_Type = 'Purchase' or Voucher_Type = 'Sales Return') and Particuls = @SG_Vlu AND CR_DR = 'Under' AND Visible = 'Approval' and Batch_No = vc.Batch_No and (Date BETWEEN @Frm_Date and @To_Date)),0) as Inward,

isnull((Select SUM(Quantity) From TBL_VC where (Voucher_Type = 'Sales' or Voucher_Type = 'Purchase Return') and Particuls = @SG_Vlu AND CR_DR = 'Under' AND Visible = 'Approval' and Batch_No = vc.Batch_No and ([Date] < @Frm_Date)),0) as Outward_OB,
isnull((Select SUM(Quantity) From TBL_VC where (Voucher_Type = 'Sales' or Voucher_Type = 'Purchase Return') and Particuls = @SG_Vlu AND CR_DR = 'Under' AND Visible = 'Approval' and Batch_No = vc.Batch_No and (Date BETWEEN @Frm_Date and @To_Date)),0) as Outward

From TBL_VC vc
where (vc.Voucher_Type = 'Purchase' or vc.Voucher_Type = 'Sales Return') and vc.CR_DR = 'Under' and (vc.Particuls = @SG_Vlu)
Group By vc.[Batch_No]"
            Else
                qy = "select vc.[Batch_No],
(Select top 1([Expiry_Date]) From TBL_VC where Batch_No = VC.Batch_No and Particuls = @SG_Vlu and (Voucher_Type = 'Purchase' or Voucher_Type = 'Sales Return') and Visible = 'Approval' and Branch = '" & Branch_ID & "') as Expiry_,
isnull((Select SUM(Quantity) From TBL_VC where (Voucher_Type = 'Purchase' or Voucher_Type = 'Sales Return') and Particuls = @SG_Vlu AND CR_DR = 'Under' AND Visible = 'Approval' and Branch = '" & Branch_ID & "' and Batch_No = vc.Batch_No and ([Date] < @Frm_Date)),0) as Inward_OB,
isnull((Select SUM(Quantity) From TBL_VC where (Voucher_Type = 'Purchase' or Voucher_Type = 'Sales Return') and Particuls = @SG_Vlu AND CR_DR = 'Under' AND Visible = 'Approval' and Branch = '" & Branch_ID & "' and Batch_No = vc.Batch_No and (Date BETWEEN @Frm_Date and @To_Date)),0) as Inward,

isnull((Select SUM(Quantity) From TBL_VC where (Voucher_Type = 'Sales' or Voucher_Type = 'Purchase Return') and Particuls = @SG_Vlu AND CR_DR = 'Under' AND Visible = 'Approval' and Branch = '" & Branch_ID & "' and Batch_No = vc.Batch_No and ([Date] < @Frm_Date)),0) as Outward_OB,
isnull((Select SUM(Quantity) From TBL_VC where (Voucher_Type = 'Sales' or Voucher_Type = 'Purchase Return') and Particuls = @SG_Vlu AND CR_DR = 'Under' AND Visible = 'Approval' and Branch = '" & Branch_ID & "' and Batch_No = vc.Batch_No and (Date BETWEEN @Frm_Date and @To_Date)),0) as Outward

From TBL_VC vc
where (vc.Voucher_Type = 'Purchase' or vc.Voucher_Type = 'Sales Return') and vc.CR_DR = 'Under' and Visible = 'Approval' and Branch = '" & Branch_ID & "' and (vc.Particuls = @SG_Vlu)
Group By vc.[Batch_No]"
            End If

            cmd = New SQLiteCommand(qy, cn)
            Dim r As SQLiteDataReader
            With cmd.Parameters
                .AddWithValue("@Company", Company_ID_str)
                .AddWithValue("@Visible", "Approval")
                .AddWithValue("@SG_Vlu", ID)
                .AddWithValue("@Branch", Branch_ID)
                .AddWithValue("@Frm_Date", Frm_date.ToString("MM-dd-yyyy"))
                .AddWithValue("@To_Date", to_date.ToString("MM-dd-yyyy"))
                r = cmd.ExecuteReader
                While r.Read
                    Dim vlu As Decimal = Val(Val(r("Inward").ToString) - Val(r("Outward").ToString))
                    Dim vlu_Ob As Decimal = Val(Val(r("Inward_OB").ToString) - Val(r("Outward_OB").ToString))
                    Dim dt As String = Date_Formate(r("Expiry_").ToString)
                    Dim dt_deff As String = ""
                    If dt <> Nothing Then
                        dt_deff = DateDiff(DateInterval.Day, CDate(Now.Date), CDate(dt)) & " Day"
                    End If

                    Grid1.Rows.Add("Under", r("Batch_No").ToString, Unit, dt, dt_deff, N2_FORMATE(vlu_Ob), N2_FORMATE(r("Inward").ToString), N2_FORMATE(r("Outward").ToString), N2_FORMATE(vlu + vlu_Ob))

                    dt_print.Rows.Add("", r("Batch_No").ToString, Unit, dt, dt_deff, N2_FORMATE(vlu_Ob), N2_FORMATE(r("Inward").ToString), N2_FORMATE(r("Outward").ToString), N2_FORMATE(vlu + vlu_Ob))
                End While
            End With
        End If
    End Function
    Private Sub Grid1_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles Grid1.RowPrePaint
        Dim ro As DataGridViewRow = Grid1.Rows(e.RowIndex)
        If ro.Cells(0).Value = "Head" Then
            If YN_Details = True Then
                ro.DefaultCellStyle.Font = Defolt_Fonts_Bold
            End If
        Else
            If YN_Details = True Then
                ro.DefaultCellStyle.ForeColor = Color.DimGray
                ro.DefaultCellStyle.Font = New Font(Dft_Font, Dft_Font_Size, FontStyle.Italic)
                ro.Cells(1).Style.Padding = New Padding(15, 0, 0, 0)
            End If
        End If
        ro.DefaultCellStyle.BackColor = Color.White
        ro.DefaultCellStyle.SelectionBackColor = Color.FromArgb(254, 197, 48)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
        Fill_Grid()
    End Sub

    Private Sub Expiry_Date_Item_Summary_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
    End Sub
End Class