Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Data.SQLite

Public Class GSTR2_frm
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

    Dim B2B As String()
    Dim B2B_UR As String()
    Dim Credit_Debit_Regular As String()
    Dim Credit_Debit_Unregular As String()
    Dim Import_Goods As String()
    Dim Import_Service As String()
    Dim Nill_Rated As String() = {0, 0, 0, 0, 0, 0, 0, 0, 0}

    Private Sub gstr1_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text

        VC_Type_ = Link_Valu(1)
        VC_ID_ = Link_Valu(2)

        Frm_Date_LB.Text = Date_Formate(Date_1)
        To_Date_LB.Text = Date_Formate(Date_2)

        BG_frm.HADE_TXT.Text = "GSTR2"
        BG_frm.TYP_TXT.Text = VC_Type_

        Button_Manage()
        Add_Hander_Remove_Handel(True)

        Branch_ID = Set_Branch()
        Branch = Find_Branch_Name(Branch_ID)
        Label17.Text = Branch
        Grid1.Focus()

    End Sub
    Private Function Button_Manage()
        Button_Clear()
        BG_frm.B_1.Text = "Enter : Alter"
        BG_frm.B_2.Text = "|&R : Refresh"
        BG_frm.B_3.Text = "|&P : Print"

        BG_frm.R_1.Text = "|F1 : Detailed"
        BG_frm.R_2.Text = "F2 : Date"
        BG_frm.R_3.Text = "|F2 : Period"
        If Branch_Visible() = True Then
            BG_frm.R_5.Text = "F4 : Branch"
        End If
        BG_frm.R_6.Text = "F5 : HSN Summary"

        BG_frm.R_22.Text = "F12 : Configuration"
    End Function
    Private Function Add_Hander_Remove_Handel(Ans As Boolean)
        If Ans = True Then
            AddHandler BG_frm.KeyDown, AddressOf Me.BG_Keydown
            AddHandler BG_frm.R_2.Click, AddressOf Me.R_3_Click
            AddHandler BG_frm.R_3.Click, AddressOf Me.R_4_Click
            AddHandler BG_frm.R_6.Click, AddressOf Me.R_6_Click
            If Branch_Visible() = True Then
                AddHandler BG_frm.R_5.Click, AddressOf Me.R_9_Click
            End If
        Else
            RemoveHandler BG_frm.KeyDown, AddressOf Me.BG_Keydown
            RemoveHandler BG_frm.R_2.Click, AddressOf Me.R_3_Click
            RemoveHandler BG_frm.R_3.Click, AddressOf Me.R_4_Click
            RemoveHandler BG_frm.R_6.Click, AddressOf Me.R_6_Click
            If Branch_Visible() = True Then
                RemoveHandler BG_frm.R_5.Click, AddressOf Me.R_9_Click
            End If
        End If
    End Function
    Private Sub BG_Keydown(sender As Object, e As KeyEventArgs)
        If BG_frm.From_ID = From_ID Then
            If e.KeyCode = Keys.F2 AndAlso e.Modifiers = Keys.Alt Then
                BG_frm.R_3.PerformClick()
            ElseIf e.KeyCode = Keys.F2 Then
                BG_frm.R_2.PerformClick()
            End If

            If e.KeyCode = Keys.F4 AndAlso e.Modifiers = Keys.Alt Then

            ElseIf e.KeyCode = Keys.F4 Then
                BG_frm.R_5.PerformClick()
            End If

            If e.KeyCode = Keys.F5 AndAlso e.Modifiers = Keys.Alt Then

            ElseIf e.KeyCode = Keys.F5 Then
                BG_frm.R_6.PerformClick()
            End If
        End If
    End Sub
    Private Sub R_9_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then

        End If
    End Sub
    Private Sub R_3_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            If Date_Set_Curr(False) = DialogResult.Yes Then
                Frm_Date_LB.Text = Date_3
                To_Date_LB.Text = Date_3
                Fill_Grid()
            End If
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
    Private Sub R_6_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Cell("HSN/SAC Summary", "")
        End If
    End Sub
    Private Function Fill_Grid()
        Grid1.Columns.Clear()
        Dim conn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, conn) = True Then
            Label1.Text = Company_GST_str
            Grid1.Columns.Add("Particulars", "P a r t i c u l a r s")
            Grid1.Columns.Add("Voucher_Count", "Voucher Count")
            Grid1.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            Grid1.Columns(1).Width = 150
            Grid1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Grid1.Rows.Add("Total Vouchers", Total_Voucher(conn))
            Grid1.Rows.Add("Included in Return", Included_in_Return(conn))
            Grid1.Rows.Add("Not relevant in the Return", Not_relevant_in_the_Return(conn))
            Grid1.Rows.Add("Uncertain Transactions (Corrections needed)", "")
            Grid_Auto_size(Grid1, 0)
            Grid1.DefaultCellStyle.Padding = New Padding(10, 0, 0, 0)

            Grid1.Rows(0).DefaultCellStyle.Font = New Font("Arial", 11, FontStyle.Bold)

            Grid1.Rows(1).DefaultCellStyle.Padding = New Padding(10, 0, 0, 0)
            Grid1.Rows(1).DefaultCellStyle.Padding = New Padding(0, 0, 0, 0)

        End If
        Fill_Grid2()
        Fill_Grid3()
    End Function
    Dim TOtal_Vouchers As Integer = 0
    Dim TOtal_Taxable_Amount As Decimal = 0
    Dim TOtal_Tax_Amount As Decimal = 0
    Dim TOtal_Ivc_Amount As Decimal = 0
    Dim TOtal_IGST_Amount As Decimal = 0
    Dim TOtal_CSGST_Amount As Decimal = 0
    Private Function Fill_Grid3()
        Grid3.Rows.Clear()
        Grid3.Rows.Add("HSN/SAC Summary - 12")
    End Function
    Private Function Fill_Grid2()
        TOtal_Vouchers = 0
        TOtal_Taxable_Amount = 0
        TOtal_Tax_Amount = 0
        TOtal_Ivc_Amount = 0
        TOtal_IGST_Amount = 0
        TOtal_CSGST_Amount = 0

        Dim conn As New SQLiteConnection
        Nill_Rated = {0, 0, 0, 0, 0, 0, 0, 0, 0}

        If open_MSSQL_Cstm(Database_File.cre, conn) = True Then
            Grid2.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 11, FontStyle.Bold)
            Grid2_Invoice(conn)
            Grid2_Credit_DebitNotes(conn)
            Grid2_Import_Goods_Service(conn)
        End If


        Grid2.Rows.Clear()

        Grid2.Rows.Add("Head", "To be reconciled with the GST portal")
        Grid2.Rows.Add(B2B)
        Grid2.Rows.Add(Credit_Debit_Regular)
        Grid2.Rows.Add("Head", "To be uploaded on the GST portal")
        Grid2.Rows.Add(B2B_UR)
        Grid2.Rows.Add(Import_Service)
        Grid2.Rows.Add(Import_Goods)
        Grid2.Rows.Add(Credit_Debit_Unregular)
        Grid2.Rows.Add(Nill_Rated)

        Grid2.Rows.Add("Total", "Total Inward Supplies", TOtal_Vouchers, N2_FORMATE(TOtal_Taxable_Amount), N2_FORMATE(TOtal_IGST_Amount), N2_FORMATE(TOtal_CSGST_Amount), N2_FORMATE(TOtal_CSGST_Amount), N2_FORMATE(TOtal_Tax_Amount), N2_FORMATE(TOtal_Ivc_Amount))


        Grid2.Columns(0).Visible = False
    End Function
    Private Function Total_Voucher(cnn As SQLiteConnection) As Decimal
        Dim vlu As Integer = 0
        qury = "SELECT Tra_ID
FROM TBL_VC vc
where (vc.Visible = 'Approval') " & Where_Filter() & " and (Date BETWEEN @Frm_Date and @To_Date)
GROUP BY Tra_ID
HAVING COUNT(*) > 1"
        Dim r As SQLiteDataReader
        cmd = New SQLiteCommand(qury, cnn)
        With cmd.Parameters
            .AddWithValue("@Frm_Date", Frm_date.ToString("MM-dd-yyyy"))
            .AddWithValue("@To_Date", to_date.ToString("MM-dd-yyyy"))
            r = cmd.ExecuteReader
            While r.Read
                vlu += 1
            End While
            r.Close()
        End With
        Return vlu
    End Function
    'Dim Allo_Vouchers_Type As String = "(vc.Voucher_Type = 'Sales' or vc.Voucher_Type = 'Purchase Return'  or vc.Voucher_Type = 'Credit Note')"
    'Dim NotAllo_Vouchers_Type As String = "(vc.Voucher_Type <> 'Sales' and vc.Voucher_Type <> 'Purchase')"
    Private Function Included_in_Return(cnn As SQLiteConnection) As Decimal
        Dim vlu As Decimal
        qury = "Select vc.Tra_ID From TBL_VC vc
where (vc.Voucher_Type = 'Purchase' or vc.Voucher_Type = 'Sales Return'  or vc.Voucher_Type = 'Debit Note') and (vc.Visible = 'Approval') " & Where_Filter() & " and (Date BETWEEN @Frm_Date and @To_Date) Group By vc.Tra_ID"
        Dim r As SQLiteDataReader
        cmd = New SQLiteCommand(qury, cnn)
        With cmd.Parameters
            .AddWithValue("@Frm_Date", Frm_date.ToString("MM-dd-yyyy"))
            .AddWithValue("@To_Date", to_date.ToString("MM-dd-yyyy"))
            r = cmd.ExecuteReader
            While r.Read
                vlu += 1
            End While
            r.Close()
        End With
        Return vlu
    End Function
    Private Function Not_relevant_in_the_Return(cnn As SQLiteConnection) As Decimal
        Dim vlu As Decimal
        qury = "Select vc.Tra_ID From TBL_VC vc
where (vc.Voucher_Type <> 'Purchase' and vc.Voucher_Type <> 'Sales Return' and vc.Voucher_Type <> 'Debit Note') and (vc.Visible = 'Approval') " & Where_Filter() & " and (Date BETWEEN @Frm_Date and @To_Date) Group By vc.Tra_ID"
        Dim r As SQLiteDataReader
        cmd = New SQLiteCommand(qury, cnn)
        With cmd.Parameters
            .AddWithValue("@Frm_Date", Frm_date.ToString("MM-dd-yyyy"))
            .AddWithValue("@To_Date", to_date.ToString("MM-dd-yyyy"))
            r = cmd.ExecuteReader
            While r.Read
                vlu += 1
            End While
            r.Close()
        End With
        Return vlu
    End Function

    Private Function Included_in_HSN_Summary(cnn As SQLiteConnection) As Decimal
        Dim vlu As Decimal

        qury = "Select (Select HSN_Code From TBL_Stock_Item where ID = vc.Particuls) as Vlu From TBL_VC vc
where (vc.Voucher_Type = 'Sales' or vc.Voucher_Type = 'Purchase') and (vc.CR_DR = 'Under') and (vc.Visible = 'Approval') " & Where_Filter() & " and (Date BETWEEN @Frm_Date and @To_Date)"
        Dim r As SQLiteDataReader
        cmd = New SQLiteCommand(qury, cnn)
        With cmd.Parameters
            .AddWithValue("@Frm_Date", Frm_date.ToString("MM-dd-yyyy"))
            .AddWithValue("@To_Date", to_date.ToString("MM-dd-yyyy"))
            r = cmd.ExecuteReader
            While r.Read
                If r("Vlu").ToString.Trim <> "" Then
                    vlu += 1
                End If
            End While
            r.Close()
        End With
        Return vlu
    End Function
    Private Function Incomplete_information_in_HSN(cnn As SQLiteConnection) As Decimal
        Dim vlu As Decimal
        qury = "Select (Select HSN_Code From TBL_Stock_Item where ID = vc.Particuls) as Vlu From TBL_VC vc
where (vc.Voucher_Type = 'Sales' or vc.Voucher_Type = 'Purchase') and (vc.CR_DR = 'Under') and (vc.Visible = 'Approval') " & Where_Filter() & " and  (Date BETWEEN @Frm_Date and @To_Date)"
        Dim r As SQLiteDataReader
        cmd = New SQLiteCommand(qury, cnn)
        With cmd.Parameters
            .AddWithValue("@Frm_Date", Frm_date.ToString("MM-dd-yyyy"))
            .AddWithValue("@To_Date", to_date.ToString("MM-dd-yyyy"))
            r = cmd.ExecuteReader
            While r.Read
                If r("Vlu").ToString.Trim = "" Then
                    vlu += 1
                End If
            End While
            r.Close()
        End With

        Return vlu
    End Function
    Private Sub gstr1_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.HADE_TXT.Text = "GSTR2"
        BG_frm.TYP_TXT.Text = VC_Type_

        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text
        Button_Clear()
        Button_Manage()
        'Config_Fill()
        'If Update_Report = True Then
        Fill_Grid()
        'End If
        Grid2.DefaultCellStyle.SelectionBackColor = Color.FromArgb(254, 197, 48)
        Grid1.DefaultCellStyle.SelectionBackColor = Color.White
        Grid3.DefaultCellStyle.SelectionBackColor = Color.White
        Grid2.Focus()
    End Sub
    Private Function Grid2_Invoice(cnn As SQLiteConnection) As Decimal
        Dim Count_B2B As Integer = 0
        Dim Taxble_amt_B2B As Decimal = 0
        Dim Tax_amt_B2B As Decimal = 0
        Dim I_TAX_B2B As Decimal = 0
        Dim C_TAX_B2B As Decimal = 0
        Dim S_TAX_B2B As Decimal = 0
        Dim Ivc_amt_B2B As Decimal = 0

        Dim Count_B2BUN As Integer = 0
        Dim Taxble_amt_B2BUN As Decimal = 0
        Dim Tax_amt_B2BUN As Decimal = 0
        Dim I_TAX_B2BUN As Decimal = 0
        Dim C_TAX_B2BUN As Decimal = 0
        Dim S_TAX_B2BUN As Decimal = 0
        Dim Ivc_amt_B2BUN As Decimal = 0

        Dim Count_Nill As Integer = 0
        Dim Taxble_amt_Nill As Decimal = 0
        Dim Tax_amt_Nill As Decimal = 0
        Dim I_TAX_Nill As Decimal = 0
        Dim C_TAX_Nill As Decimal = 0
        Dim S_TAX_Nill As Decimal = 0
        Dim Ivc_amt_Nill As Decimal = 0

        qury = "Select vc.Voucher_Type,vc.Tax_Value,vc.Tax_Type,vc.Cr,vc.Dr,(Select Ac.GSTNo From TBL_Ledger Ac where ID = vc.Account) as GST_No,(Select Ac.GST_Type From TBL_Ledger Ac where ID = vc.Account) as GST_Type,(Select Ac.Country From TBL_Ledger Ac where ID = vc.Account) as Country_, 
(CASE WHEN vc.TAX_Type = 'I' THEN
vc.Tax_Value
END) AS IGST,
(CASE WHEN vc.TAX_Type = 'CS' THEN
vc.Tax_Value / 2
END) AS CSGST
From TBL_VC VC
where (vc.Voucher_Type = 'Purchase' or vc.Voucher_Type = 'Sales Return') and vc.CR_DR = 'Head' and vc.Visible = 'Approval' " & Where_Filter() & " and  (Date BETWEEN @Frm_Date and @To_Date)"
        Dim r As SQLiteDataReader
        cmd = New SQLiteCommand(qury, cnn)
        With cmd.Parameters
            .AddWithValue("@Frm_Date", Frm_date.ToString("MM-dd-yyyy"))
            .AddWithValue("@To_Date", to_date.ToString("MM-dd-yyyy"))
            r = cmd.ExecuteReader
            While r.Read
                Dim sub_ As Decimal = Val(r("Cr")) + Val(r("Dr"))
                If r("Country_").ToString = "India" Or r("Country_").ToString = Nothing Then
                    If Val(r("Tax_Value").ToString) <> 0 Then
                        If r("GST_Type").ToString = "Regular" Then
                            Count_B2B += 1
                            Taxble_amt_B2B = Val(Taxble_amt_B2B) + (Val(sub_) - Val(r("Tax_Value")))
                            Tax_amt_B2B = Val(Tax_amt_B2B) + Val(r("Tax_Value"))
                            Ivc_amt_B2B = Val(Ivc_amt_B2B) + Val(sub_)

                            I_TAX_B2B = Val(I_TAX_B2B) + Val(r("IGST").ToString)
                            C_TAX_B2B = Val(C_TAX_B2B) + Val(r("CSGST").ToString)
                            S_TAX_B2B = Val(S_TAX_B2B) + Val(r("CSGST").ToString)
                        ElseIf r("GST_Type").ToString = "Unregistered" Then
                            Count_B2BUN += 1
                            Taxble_amt_B2BUN = Val(Taxble_amt_B2BUN) + (Val(sub_) - Val(r("Tax_Value")))
                            Tax_amt_B2BUN = Val(Tax_amt_B2BUN) + Val(r("Tax_Value"))
                            Ivc_amt_B2BUN = Val(Ivc_amt_B2BUN) + Val(sub_)

                            I_TAX_B2BUN = Val(I_TAX_B2BUN) + Val(r("IGST").ToString)
                            C_TAX_B2BUN = Val(C_TAX_B2BUN) + Val(r("CSGST").ToString)
                            S_TAX_B2BUN = Val(S_TAX_B2BUN) + Val(r("CSGST").ToString)
                        Else
                            Count_Nill += 1
                            Taxble_amt_Nill = Val(Taxble_amt_Nill) + (Val(sub_) - Val(r("Tax_Value")))
                            'Tax_amt_Nill = Val(Tax_amt_Nill) + Val(r("Tax_Value"))
                            'Ivc_amt_Nill = Val(Ivc_amt_Nill) + Val(sub_)

                            'I_TAX_Nill = Val(I_TAX_Nill) + Val(r("IGST").ToString)
                            'C_TAX_Nill = Val(C_TAX_Nill) + Val(r("CSGST").ToString)
                            'S_TAX_Nill = Val(S_TAX_Nill) + Val(r("CSGST").ToString)
                        End If
                    Else
                        Count_Nill += 1
                        Taxble_amt_Nill = Val(Taxble_amt_Nill) + (Val(sub_) - Val(r("Tax_Value")))
                        'Tax_amt_Nill = Val(Tax_amt_Nill) + Val(r("Tax_Value"))
                        'Ivc_amt_Nill = Val(Ivc_amt_Nill) + Val(sub_)

                        'I_TAX_Nill = Val(I_TAX_Nill) + Val(r("IGST").ToString)
                        'C_TAX_Nill = Val(C_TAX_Nill) + Val(r("CSGST").ToString)
                        'S_TAX_Nill = Val(S_TAX_Nill) + Val(r("CSGST").ToString)
                    End If
                Else

                End If
            End While
            r.Close()
        End With


        B2B = {"Under", "B2B Invoice - 3, 4A", Count_B2B, N2_FORMATE(Taxble_amt_B2B), N2_FORMATE(I_TAX_B2B), N2_FORMATE(C_TAX_B2B), N2_FORMATE(S_TAX_B2B), N2_FORMATE(Tax_amt_B2B), N2_FORMATE(Ivc_amt_B2B)}


        B2B_UR = {"Under", "B2BUR Invoice - 4B", Count_B2BUN, N2_FORMATE(Taxble_amt_B2BUN), N2_FORMATE(I_TAX_B2BUN), N2_FORMATE(C_TAX_B2BUN), N2_FORMATE(S_TAX_B2BUN), N2_FORMATE(Tax_amt_B2BUN), N2_FORMATE(Ivc_amt_B2BUN)}

        Nill_Rated = {"Under", "Nill Rated Invoices - 7 (Summary)", Val(Count_Nill), Val(Taxble_amt_Nill), Val(I_TAX_Nill), Val(C_TAX_Nill), Val(S_TAX_Nill), Val(Tax_amt_Nill), Val(Ivc_amt_Nill)}

        TOtal_Vouchers = Val(TOtal_Vouchers) + Count_B2B + Count_B2BUN + Count_Nill
        TOtal_Taxable_Amount = Val(TOtal_Taxable_Amount) + Taxble_amt_B2B + Taxble_amt_B2BUN + Taxble_amt_Nill
        TOtal_Tax_Amount = Val(TOtal_Tax_Amount) + Tax_amt_B2B + Tax_amt_B2BUN + Tax_amt_Nill
        TOtal_Ivc_Amount = Val(TOtal_Ivc_Amount) + Ivc_amt_B2B + Ivc_amt_B2BUN + Ivc_amt_Nill

        TOtal_IGST_Amount = Val(TOtal_IGST_Amount) + I_TAX_B2B + I_TAX_B2BUN
        TOtal_CSGST_Amount = Val(TOtal_CSGST_Amount) + C_TAX_B2B + C_TAX_B2BUN
    End Function
    Private Function Grid2_Import_Goods_Service(cnn As SQLiteConnection) As Decimal
        Dim Count_G As Integer = 0
        Dim Taxble_amt_G As Decimal = 0
        Dim Tax_amt_G As Decimal = 0
        Dim Ivc_amt_G As Decimal = 0

        Dim I_TAX_G As Decimal = 0
        Dim C_TAX_G As Decimal = 0
        Dim S_TAX_G As Decimal = 0

        Dim Count_S As Integer = 0
        Dim Taxble_amt_S As Decimal = 0
        Dim Tax_amt_S As Decimal = 0
        Dim Ivc_amt_S As Decimal = 0

        Dim I_TAX_S As Decimal = 0
        Dim C_TAX_S As Decimal = 0
        Dim S_TAX_S As Decimal = 0

        qury = "Select vc.Voucher_Type,vc.Tax_Value,vc.Cr,vc.Dr,(Select Ac.Country From TBL_Ledger Ac where ID = Vc.Account) as Country_,(Select it.GST_Type From TBL_Stock_Item it where ID = Vc.Particuls) as GST_Type,
(CASE WHEN vc.TAX_Type = 'I' THEN
vc.Tax_Value
END) AS IGST,
(CASE WHEN vc.TAX_Type = 'CS' THEN
vc.Tax_Value / 2
END) AS CSGST
From TBL_VC VC
where vc.CR_DR = 'Under' and vc.Visible = 'Approval' and (vc.Voucher_Type = 'Purchase' or vc.Voucher_Type = 'Sales Return') " & Where_Filter() & " and (Date BETWEEN @Frm_Date and @To_Date)"

        Dim r As SQLiteDataReader
        cmd = New SQLiteCommand(qury, cnn)
        With cmd.Parameters
            .AddWithValue("@Frm_Date", Frm_date.ToString("MM-dd-yyyy"))
            .AddWithValue("@To_Date", to_date.ToString("MM-dd-yyyy"))
            r = cmd.ExecuteReader
            While r.Read
                If r("Country_").ToString = "India" Or r("Country_").ToString = Nothing Then
                Else
                    Dim sub_ As Decimal = Val(r("Cr")) + Val(r("Dr"))
                    If r("GST_Type").ToString = "Goods" Then
                        Count_G += 1
                        Taxble_amt_G = Val(Taxble_amt_G) + (Val(sub_))
                        Tax_amt_G = Val(Tax_amt_G) + Val(r("Tax_Value"))
                        Ivc_amt_G = Val(Ivc_amt_G) + Val(sub_) + Val(r("Tax_Value"))

                        I_TAX_G = Val(I_TAX_G) + Val(r("IGST").ToString)
                        C_TAX_G = Val(C_TAX_G) + Val(r("CSGST").ToString)
                        S_TAX_G = Val(S_TAX_G) + Val(r("CSGST").ToString)
                    ElseIf r("GST_Type").ToString = "Services" Then
                        Count_S += 1
                        Taxble_amt_S = Val(Taxble_amt_S) + (Val(sub_))
                        Tax_amt_S = Val(Tax_amt_S) + Val(r("Tax_Value"))
                        Ivc_amt_S = Val(Ivc_amt_S) + Val(sub_) + Val(r("Tax_Value"))

                        I_TAX_S = Val(I_TAX_S) + Val(r("IGST").ToString)
                        C_TAX_S = Val(C_TAX_S) + Val(r("CSGST").ToString)
                        S_TAX_S = Val(S_TAX_S) + Val(r("CSGST").ToString)
                    End If
                End If
            End While
            r.Close()
        End With

        Import_Goods = {"Under", "Impoer of Goods - 5", Count_G, N2_FORMATE(Taxble_amt_G), N2_FORMATE(I_TAX_G), N2_FORMATE(C_TAX_G), N2_FORMATE(S_TAX_G), N2_FORMATE(Tax_amt_G), N2_FORMATE(Ivc_amt_G)}
        Import_Service = {"Under", "Impoer of Services - 4C", Count_S, N2_FORMATE(Taxble_amt_S), N2_FORMATE(I_TAX_S), N2_FORMATE(C_TAX_S), N2_FORMATE(S_TAX_S), N2_FORMATE(Tax_amt_S), N2_FORMATE(Ivc_amt_S)}

        TOtal_Vouchers = Val(TOtal_Vouchers) + Count_S + Count_G
        TOtal_Taxable_Amount = Val(TOtal_Taxable_Amount) + Taxble_amt_S + Taxble_amt_G
        TOtal_Tax_Amount = Val(TOtal_Tax_Amount) + Tax_amt_S + Tax_amt_G
        TOtal_Ivc_Amount = Val(TOtal_Ivc_Amount) + Ivc_amt_S + Ivc_amt_G

        TOtal_IGST_Amount = Val(TOtal_IGST_Amount) + I_TAX_S + I_TAX_G
        TOtal_CSGST_Amount = Val(TOtal_CSGST_Amount) + C_TAX_S + C_TAX_G
    End Function
    Private Function Grid2_Credit_DebitNotes(cnn As SQLiteConnection) As Decimal
        Dim Count_R As Integer = 0
        Dim Taxble_amt_R As Decimal = 0
        Dim Tax_amt_R As Decimal = 0
        Dim Ivc_amt_R As Decimal = 0

        Dim I_TAX_R As Decimal = 0
        Dim C_TAX_R As Decimal = 0
        Dim S_TAX_R As Decimal = 0

        Dim Count_Nill As Integer = 0
        Dim Taxble_amt_Nill As Decimal = 0
        Dim Tax_amt_Nill As Decimal = 0
        Dim Ivc_amt_Nill As Decimal = 0


        Dim Count_U As Integer = 0
        Dim Taxble_amt_U As Decimal = 0
        Dim Tax_amt_U As Decimal = 0
        Dim Ivc_amt_u As Decimal = 0

        Dim I_TAX_U As Decimal = 0
        Dim C_TAX_U As Decimal = 0
        Dim S_TAX_U As Decimal = 0

        qury = "Select vc.Voucher_Type,vc.Tax_Value,vc.Cr,vc.Dr,(Select Ac.GSTNo From TBL_Ledger Ac where ID = Vc.Particuls) as GST_No,(Select Ac.GST_Type From TBL_Ledger Ac where ID = Vc.Particuls) as GST_Type,(Select Ac.Country From TBL_Ledger Ac where ID = Vc.Particuls) as Country_,
(CASE WHEN vc.TAX_Type = 'I' THEN
vc.Tax_Value
END) AS IGST,
(CASE WHEN vc.TAX_Type = 'CS' THEN
vc.Tax_Value / 2
END) AS CSGST
From TBL_VC VC
where vc.CR_DR = 'Under' and vc.Visible = 'Approval' and (vc.Voucher_Type = 'Debit Note') " & Where_Filter() & " and (Date BETWEEN @Frm_Date and @To_Date)"

        Dim r As SQLiteDataReader
        cmd = New SQLiteCommand(qury, cnn)
        With cmd.Parameters
            .AddWithValue("@Frm_Date", Frm_date.ToString("MM-dd-yyyy"))
            .AddWithValue("@To_Date", to_date.ToString("MM-dd-yyyy"))
            r = cmd.ExecuteReader
            While r.Read
                Dim sub_ As Decimal = Val(r("Cr")) + Val(r("Dr"))
                If r("Country_").ToString = "India" Or r("Country_").ToString = Nothing Then
                    If r("GST_Type").ToString = "Regular" Then
                        Count_R += 1
                        Taxble_amt_R = Val(Taxble_amt_R) + (Val(sub_) - Val(r("Tax_Value")))
                        Tax_amt_R = Val(Tax_amt_R) + Val(r("Tax_Value"))
                        Ivc_amt_R = Val(Ivc_amt_R) + Val(sub_)

                        I_TAX_R = Val(I_TAX_R) + Val(r("IGST").ToString)
                        C_TAX_R = Val(C_TAX_R) + Val(r("CSGST").ToString)
                        S_TAX_R = Val(S_TAX_R) + Val(r("CSGST").ToString)
                    Else
                        Count_U += 1
                        Taxble_amt_U = Val(Taxble_amt_U) + (Val(sub_) - Val(r("Tax_Value")))
                        Tax_amt_U = Val(Tax_amt_U) + Val(r("Tax_Value"))
                        Ivc_amt_u = Val(Ivc_amt_u) + Val(sub_)

                        I_TAX_U = Val(I_TAX_U) + Val(r("IGST").ToString)
                        C_TAX_U = Val(C_TAX_U) + Val(r("CSGST").ToString)
                        S_TAX_U = Val(S_TAX_U) + Val(r("CSGST").ToString)
                    End If
                End If
            End While
            r.Close()
        End With
        Taxble_amt_R = Taxble_amt_R * -1
        Tax_amt_R = Tax_amt_R * -1
        Ivc_amt_R = Ivc_amt_R * -1

        Taxble_amt_U = Taxble_amt_U * -1
        Tax_amt_U = Tax_amt_U * -1
        Ivc_amt_u = Ivc_amt_u * -1

        Taxble_amt_Nill = Taxble_amt_Nill * -1
        Tax_amt_Nill = Tax_amt_Nill * -1
        Ivc_amt_Nill = Ivc_amt_Nill * -1

        I_TAX_R = I_TAX_R * -1
        C_TAX_R = C_TAX_R * -1
        S_TAX_R = S_TAX_R * -1

        I_TAX_U = I_TAX_U * -1
        C_TAX_U = C_TAX_U * -1
        S_TAX_U = S_TAX_U * -1


        Credit_Debit_Regular = {"Under", "Credit/Debit Notes Regular - 6C", Count_R, N2_FORMATE(Taxble_amt_R), N2_FORMATE(I_TAX_R), N2_FORMATE(C_TAX_R), N2_FORMATE(S_TAX_R), N2_FORMATE(Tax_amt_R), N2_FORMATE(Ivc_amt_R)}
        Credit_Debit_Unregular = {"Under", "Credit/Debit Notes Unregistered - 6C", Count_U, N2_FORMATE(Taxble_amt_U), N2_FORMATE(I_TAX_U), N2_FORMATE(C_TAX_U), N2_FORMATE(S_TAX_U), N2_FORMATE(Tax_amt_U), N2_FORMATE(Ivc_amt_u)}
        'Nill_Rated = {"Under", "Nill Rated Invoices - 7 (Summary)", Val(Nill_Rated(2)) + Val(Count_Nill), (Val(Nill_Rated(3)) + Val(Taxble_amt_Nill)), (Val(Nill_Rated(4)) + Val(0)), (Val(Nill_Rated(5)) + Val(0)), (Val(Nill_Rated(6)) + Val(0)), (Val(Nill_Rated(7)) + Val(Tax_amt_Nill)), (Val(Nill_Rated(8)) + Val(Ivc_amt_Nill))}


        TOtal_Vouchers = Val(TOtal_Vouchers) + Count_U + Count_R + Count_Nill
        TOtal_Taxable_Amount = Val(TOtal_Taxable_Amount) + Taxble_amt_U + Taxble_amt_R + Taxble_amt_Nill
        TOtal_Tax_Amount = Val(TOtal_Tax_Amount) + Tax_amt_U + Tax_amt_R
        TOtal_Ivc_Amount = Val(TOtal_Ivc_Amount) + Ivc_amt_u + Ivc_amt_R

        TOtal_IGST_Amount = Val(TOtal_IGST_Amount) + I_TAX_U + I_TAX_R
        TOtal_CSGST_Amount = Val(TOtal_CSGST_Amount) + C_TAX_U + C_TAX_R
    End Function
    Private Function Advance_Value_Aubjst(cnn As SQLiteConnection) As Decimal

    End Function
    Private Sub gstr1_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub gstr1_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        Add_Hander_Remove_Handel(False)
        BG_frm.BG_Path_TXT.Text = Path_End
        Frm_foCus()
    End Sub

    Private Sub Grid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid1.CellContentClick

    End Sub

    Private Sub Grid1_Paint(sender As Object, e As PaintEventArgs) Handles Grid1.Paint, Grid2.Paint, Grid3.Paint
        Try
            sender.Height = (Val(sender.Rows.Count) * Val(20)) + Val(50)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Grid1_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles Grid1.RowsAdded, Grid2.RowsAdded, Grid3.RowsAdded
        sender.Rows(sender.Rows.Count - 1).Height = 20
    End Sub
    Private Sub Frm_Date_LB_TextChanged(sender As Object, e As EventArgs) Handles Frm_Date_LB.TextChanged
        Frm_date = Frm_Date_LB.Text
    End Sub
    Private Sub To_Date_LB_TextChanged(sender As Object, e As EventArgs) Handles To_Date_LB.TextChanged
        to_date = To_Date_LB.Text
    End Sub
    Private Function Where_Filter() As String
        Dim q As String
        If Branch <> "Primary" Then
            q &= " AND VC.Branch = '" & Find_DT_Value(Database_File.cre, "TBL_Ledger", "ID", "Name = '" & Branch & "'") & "'"
        End If
        Return q
    End Function
    Private Sub Grid_LostFocus(sender As Object, e As EventArgs) Handles Grid1.LostFocus, Grid2.LostFocus, Grid3.LostFocus
        sender.DefaultCellStyle.SelectionBackColor = Color.White
    End Sub
    Private Sub Grid_Enter(sender As Object, e As EventArgs) Handles Grid1.Enter, Grid2.Enter, Grid3.Enter
        sender.DefaultCellStyle.SelectionBackColor = Color.FromArgb(254, 197, 48)
    End Sub
    Private Sub Grid1_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid1.KeyDown
        If e.KeyCode = Keys.Down Then
            If Grid1.CurrentRow.Index = Grid1.Rows.Count - 1 Then
                Grid2.CurrentCell = Grid2.Rows(0).Cells(3)
                Grid2.Focus()
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            If Grid1.CurrentRow.Cells(0).Value = "Total Vouchers" Then
                Cell("Vouchers Count", "", Branch_ID)
            ElseIf Grid1.CurrentRow.Cells(0).Value = "Uncertain Transactions (Corrections needed)" Then
                Cell("Uncertain Transactions", "GSTR2", Branch_ID, Frm_date, to_date)
            ElseIf Grid1.CurrentRow.Cells(0).Value = "Included in Return" Then
                Cell("Included in Return", "Included in Return", "GSTR2", Branch_ID, Frm_date, to_date)
                'ElseIf Grid1.CurrentRow.Cells(0).Value = "Included in HSN/SAC Summary" Then
                'Cell("GSTR Vouchers Register", "GSTR2", Branch_ID, Frm_date, to_date, "Included in HSN/SAC Summary")
                'ElseIf Grid1.CurrentRow.Cells(0).Value = "Incomplete information in HSN/SAC Summary (Corrections needed)" Then
                'Cell("GSTR Vouchers Register", "GSTR2", Branch_ID, Frm_date, to_date, "Incomplete information in HSN/SAC Summary (Corrections needed)")
            ElseIf Grid1.CurrentRow.Cells(0).Value = "Not relevant in the Return" Then
                Cell("Not relevant in the Return", "Not relevant in the Return", "GSTR2", Branch_ID, Frm_date, to_date)
            End If
        End If
    End Sub

    Private Sub Grid2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid2.CellContentClick

    End Sub

    Private Sub Grid2_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid2.KeyDown
        If e.KeyCode = Keys.Up Then
            If Grid2.CurrentRow.Index = 0 Then
                Grid1.CurrentCell = Grid1.Rows(Grid1.Rows.Count - 1).Cells(0)
                Grid1.Focus()
            End If
        End If
        If e.KeyCode = Keys.Down Then
            If Grid2.CurrentRow.Index = Grid2.Rows.Count - 1 Or Grid2.CurrentRow.Index = Grid2.Rows.Count - 2 Then
                Grid3.CurrentCell = Grid3.Rows(0).Cells(0)
                Grid3.Focus()
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            Cell("Dealer\Party Vouchers", Grid2.CurrentRow.Cells(1).Value.ToString, "GSTR2", Branch_ID, Frm_date, to_date)
        End If
    End Sub
    Private Sub Grid3_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid3.KeyDown
        If e.KeyCode = Keys.Up Then
            If Grid3.CurrentRow.Index = 0 Then
                'Grid2.CurrentCell = Grid2.Rows(Grid2.Rows.Count - 1).Cells(0)
                Grid2.Focus()
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            If Grid3.CurrentRow.Cells(0).Value.ToString = "HSN/SAC Summary - 12" Then
                Cell("HSN/SAC Summary", "")
                HSN_Summary_frm.Frm_Date_LB.Text = Frm_Date_LB.Text
                HSN_Summary_frm.To_Date_LB.Text = To_Date_LB.Text
            End If
        End If
    End Sub

    Private Sub Grid3_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid3.CellContentClick

    End Sub

    Private Sub Grid2_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles Grid2.RowPrePaint

        Dim ro As DataGridViewRow = Grid2.Rows(e.RowIndex)
        If ro.Cells(0).Value = "Head" Then
            ro.DefaultCellStyle.Font = Defolt_Fonts_Bold
            ro.DefaultCellStyle.Padding = New Padding(0, 0, 0, 0)
        ElseIf ro.Cells(0).Value = "Under" Then
            ro.DefaultCellStyle.Font = New Font(Dft_Font, Dft_Font_Size, FontStyle.Regular)
            ro.DefaultCellStyle.Padding = New Padding(20, 0, 0, 0)
        ElseIf ro.Cells(0).Value = "Total" Then
            ro.DefaultCellStyle.BackColor = Color.NavajoWhite
            ro.DefaultCellStyle.Font = Defolt_Fonts_Bold
        End If
    End Sub

    Private Sub GSTR2_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus

        BG_frm.From_ID = From_ID
    End Sub
End Class