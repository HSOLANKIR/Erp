Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Data.SQLite

Public Class dealer_party_vouchers
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
    Private Sub dealer_party_vouchers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Frm_Design(Me)
        Path_End = BG_frm.BG_Path_TXT.Text

        VC_Type_ = Link_Valu(0)
        Label1.Text = Link_Valu(1) & " - " & VC_Type_
        VC_ID_ = Link_Valu(1)

        Branch_ID = Link_Valu(2)
        Frm_Date_LB.Text = Date_Formate(Link_Valu(3))
        To_Date_LB.Text = Date_Formate(Link_Valu(4))

        BG_frm.HADE_TXT.Text = "Dealer\Party Vouchers"
        BG_frm.TYP_TXT.Text = ""

        'Button_Manage()
        'Add_Hander_Remove_Handel(True)

        Branch = Find_Branch_Name(Branch_ID)
        Label17.Text = Branch
        Grid1.Focus()
    End Sub

    Private Sub dealer_party_vouchers_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.HADE_TXT.Text = "Dealer\Party Vouchers"
        BG_frm.TYP_TXT.Text = VC_Type_

        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text
        Button_Clear()
        'Config_Fill()
        'If Update_Report = True Then
        Fill_Grid()
        'End If
        Grid1.Focus()
    End Sub

    Private Sub dealer_party_vouchers_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub dealer_party_vouchers_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
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
    Private Function B2B_GSTR1()
        Dim vc As String
        Dim cnn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cnn) = True Then
            qury = "Select (Select [ID] From TBL_Ledger where ID = vc.Account) as [ID],
(Select [Name] From TBL_Ledger where ID = vc.Account) as [Name],
(Select [Country] From TBL_Ledger where ID = vc.Account) as [Country_],
(Select [GST_Type] From TBL_Ledger where ID = vc.Account) as GST_Type,
(Select [GSTNo] From TBL_Ledger where ID = vc.Account) as GST,
Count(vc.Account) as [Count],
(SUM(vc.Cr) + SUM(vc.Dr)) - SUM(vc.Tax_Value) as [Taxable],
SUM(CASE WHEN vc.Tax_Type = 'I' THEN
(vc.Tax_Value)
END) as IGST,
SUM(CASE WHEN vc.Tax_Type = 'CS' THEN
(vc.Tax_Value) / 2
END) as CSGST,
SUM(vc.Tax_Value) as Total_TAX,
(SUM(vc.Cr) + SUM(vc.Dr)) as Invoice_Amount

From TBL_VC vc
where vc.CR_DR = 'Head' and (vc.Voucher_Type = 'Sales' or vc.Voucher_Type = 'Purchase Return') and vc.Visible = 'Approval' " & Where_Filter() & " and  (Date BETWEEN @Frm_Date and @To_Date) Group By  vc.Account"

            Dim r As SQLiteDataReader
            cmd = New SQLiteCommand(qury, cnn)
            With cmd.Parameters
                .AddWithValue("@Frm_Date", Frm_date.ToString("MM-dd-yyyy"))
                .AddWithValue("@To_Date", to_date.ToString("MM-dd-yyyy"))
                r = cmd.ExecuteReader
                While r.Read
                    If r("Country_").ToString = "India" Or r("Country_").ToString = Nothing Then
                        If Val(r("Total_TAX").ToString) <> 0 Then
                            If r("GST_Type").ToString = "Regular" Then
                                Grid1.Rows.Add(r("ID").ToString, r("Name").ToString, r("GST").ToString, "", N2_FORMATE(r("Taxable").ToString), N2_FORMATE(r("IGST").ToString), N2_FORMATE(r("CSGST").ToString), N2_FORMATE(r("CSGST").ToString), N2_FORMATE(r("Total_TAX").ToString), N2_FORMATE(r("Invoice_Amount").ToString))
                            End If
                        End If
                    Else
                    End If
                End While
                r.Close()
            End With
        End If
    End Function
    Private Function B2B_GSTR2()
        Dim vc As String
        Dim cnn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cnn) = True Then
            qury = "Select (Select [ID] From TBL_Ledger where ID = vc.Account) as [ID],
(Select [Name] From TBL_Ledger where ID = vc.Account) as [Name],
(Select [Country] From TBL_Ledger where ID = vc.Account) as [Country_],
(Select [GSTNo] From TBL_Ledger where ID = vc.Account) as GST,
(Select [GST_Type] From TBL_Ledger where ID = vc.Account) as GST_Type,
Count(vc.Account) as [Count],
(SUM(vc.Cr) + SUM(vc.Dr)) - SUM(vc.Tax_Value) as [Taxable],
SUM(CASE WHEN vc.Tax_Type = 'I' THEN
(vc.Tax_Value)
END) as IGST,
SUM(CASE WHEN vc.Tax_Type = 'CS' THEN
(vc.Tax_Value) / 2
END) as CSGST,
SUM(vc.Tax_Value) as Total_TAX,
(SUM(vc.Cr) + SUM(vc.Dr)) as Invoice_Amount

From TBL_VC vc
where vc.CR_DR = 'Head' and (vc.Voucher_Type = 'Purchase' or vc.Voucher_Type = 'Sales Return') and vc.Visible = 'Approval' and vc.Tax_Value <> 0 " & Where_Filter() & " and  (Date BETWEEN @Frm_Date and @To_Date) Group By vc.Account"

            Dim r As SQLiteDataReader
            cmd = New SQLiteCommand(qury, cnn)
            With cmd.Parameters
                .AddWithValue("@Frm_Date", Frm_date.ToString("MM-dd-yyyy"))
                .AddWithValue("@To_Date", to_date.ToString("MM-dd-yyyy"))
                r = cmd.ExecuteReader
                While r.Read
                    If r("Country_").ToString = "India" Or r("Country_").ToString = Nothing Then
                        If Val(r("Total_TAX").ToString) <> 0 Then
                            If r("GST_Type").ToString = "Regular" Then
                                Grid1.Rows.Add(r("ID").ToString, r("Name").ToString, r("GST").ToString, "", N2_FORMATE(r("Taxable").ToString), N2_FORMATE(r("IGST").ToString), N2_FORMATE(r("CSGST").ToString), N2_FORMATE(r("CSGST").ToString), N2_FORMATE(r("Total_TAX").ToString), N2_FORMATE(r("Invoice_Amount").ToString))
                            End If
                        End If
                    Else
                    End If
                End While
                r.Close()
            End With
        End If
    End Function
    Private Function B2BUR_GSTR2()
        Dim vc As String
        Dim cnn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cnn) = True Then
            qury = "Select (Select [ID] From TBL_Ledger where ID = vc.Account) as [ID],
(Select [Name] From TBL_Ledger where ID = vc.Account) as [Name],
(Select [Country] From TBL_Ledger where ID = vc.Account) as [Country_],
(Select [GSTNo] From TBL_Ledger where ID = vc.Account) as GST,
(Select [GST_Type] From TBL_Ledger where ID = vc.Account) as GST_Type,
Count(vc.Account) as [Count],
(SUM(vc.Cr) + SUM(vc.Dr)) - SUM(vc.Tax_Value) as [Taxable],
SUM(CASE WHEN vc.Tax_Type = 'I' THEN
(vc.Tax_Value)
END) as IGST,
SUM(CASE WHEN vc.Tax_Type = 'CS' THEN
(vc.Tax_Value) / 2
END) as CSGST,
SUM(vc.Tax_Value) as Total_TAX,
(SUM(vc.Cr) + SUM(vc.Dr)) as Invoice_Amount

From TBL_VC vc
where vc.CR_DR = 'Head' and (vc.Voucher_Type = 'Purchase' or vc.Voucher_Type = 'Sales Return') and vc.Visible = 'Approval' and vc.Tax_Value <> 0" & Where_Filter() & " and  (Date BETWEEN @Frm_Date and @To_Date) Group By  vc.Account"

            Dim r As SQLiteDataReader
            cmd = New SQLiteCommand(qury, cnn)
            With cmd.Parameters
                .AddWithValue("@Frm_Date", Frm_date.ToString("MM-dd-yyyy"))
                .AddWithValue("@To_Date", to_date.ToString("MM-dd-yyyy"))
                r = cmd.ExecuteReader
                While r.Read
                    If r("Country_").ToString = "India" Or r("Country_").ToString = Nothing Then
                        If Val(r("Total_TAX").ToString) <> 0 Then
                            If r("GST_Type").ToString = "Unregistered" Then
                                Grid1.Rows.Add(r("ID").ToString, r("Name").ToString, r("GST").ToString, "", N2_FORMATE(r("Taxable").ToString), N2_FORMATE(r("IGST").ToString), N2_FORMATE(r("CSGST").ToString), N2_FORMATE(r("CSGST").ToString), N2_FORMATE(r("Total_TAX").ToString), N2_FORMATE(r("Invoice_Amount").ToString))
                            End If
                        End If
                    Else
                    End If
                End While
                r.Close()
            End With
        End If
    End Function
    Private Function B2C_Large_GSTR1()
        Dim vc As String
        Dim cnn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cnn) = True Then
            qury = "Select (Select [ID] From TBL_Ledger where ID = vc.Account) as [ID],
(Select [Name] From TBL_Ledger where ID = vc.Account) as [Name],
(Select [Country] From TBL_Ledger where ID = vc.Account) as [Country_],
(Select [GST_Type] From TBL_Ledger where ID = vc.Account) as GST_Type,
(Select [GSTNo] From TBL_Ledger where ID = vc.Account) as GST,
Count(vc.Account) as [Count],
(SUM(vc.Cr) + SUM(vc.Dr)) - SUM(vc.Tax_Value) as [Taxable],
SUM(CASE WHEN vc.Tax_Type = 'I' THEN
(vc.Tax_Value)
END) as IGST,
SUM(CASE WHEN vc.Tax_Type = 'CS' THEN
(vc.Tax_Value) / 2
END) as CSGST,
SUM(vc.Tax_Value) as Total_TAX,
(SUM(vc.Cr) + SUM(vc.Dr)) as Invoice_Amount

From TBL_VC vc
where (vc.Cr >= 250000 or vc.Dr >= 250000) and vc.CR_DR = 'Head' and (vc.Voucher_Type = 'Sales' or vc.Voucher_Type = 'Purchase Return') and vc.Visible = 'Approval' " & Where_Filter() & " and  (Date BETWEEN @Frm_Date and @To_Date) Group By  vc.Account"

            Dim r As SQLiteDataReader
            cmd = New SQLiteCommand(qury, cnn)
            With cmd.Parameters
                .AddWithValue("@Frm_Date", Frm_date.ToString("MM-dd-yyyy"))
                .AddWithValue("@To_Date", to_date.ToString("MM-dd-yyyy"))
                r = cmd.ExecuteReader
                While r.Read
                    If r("Country_").ToString = "India" Or r("Country_").ToString = Nothing Then
                        If r("GST_Type").ToString <> "Regular" Then
                            'If Val(r("Total_TAX").ToString) <> 0 Then
                            If Val(r("Invoice_Amount").ToString) >= 250000 Then
                                Grid1.Rows.Add(r("ID").ToString, r("Name").ToString, r("GST").ToString, "", N2_FORMATE(r("Taxable").ToString), N2_FORMATE(r("IGST").ToString), N2_FORMATE(r("CSGST").ToString), N2_FORMATE(r("CSGST").ToString), N2_FORMATE(r("Total_TAX").ToString), N2_FORMATE(r("Invoice_Amount").ToString))
                            End If
                            'End If
                        End If
                    Else
                    End If
                End While
                r.Close()
            End With
        End If
    End Function
    Private Function B2C_Small_GSTR1()
        Dim vc As String
        Dim cnn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cnn) = True Then
            qury = "Select (Select [ID] From TBL_Ledger where ID = vc.Account) as [ID],
(Select [Name] From TBL_Ledger where ID = vc.Account) as [Name],
(Select [Country] From TBL_Ledger where ID = vc.Account) as [Country_],
(Select [GST_Type] From TBL_Ledger where ID = vc.Account) as GST_Type,
(Select [GSTNo] From TBL_Ledger where ID = vc.Account) as GST,
Count(vc.Account) as [Count],
(SUM(vc.Cr) + SUM(vc.Dr)) - SUM(vc.Tax_Value) as [Taxable],
SUM(CASE WHEN vc.Tax_Type = 'I' THEN
(vc.Tax_Value)
END) as IGST,
SUM(CASE WHEN vc.Tax_Type = 'CS' THEN
(vc.Tax_Value) / 2
END) as CSGST,
SUM(vc.Tax_Value) as Total_TAX,
(SUM(vc.Cr) + SUM(vc.Dr)) as Invoice_Amount

From TBL_VC vc
where (vc.Dr < 250000) and vc.CR_DR = 'Head' and (vc.Voucher_Type = 'Sales' or vc.Voucher_Type = 'Purchase Return') and vc.Visible = 'Approval' " & Where_Filter() & " and  (Date BETWEEN @Frm_Date and @To_Date) Group By  vc.Account"

            Dim r As SQLiteDataReader
            cmd = New SQLiteCommand(qury, cnn)
            With cmd.Parameters
                .AddWithValue("@Frm_Date", Frm_date.ToString("MM-dd-yyyy"))
                .AddWithValue("@To_Date", to_date.ToString("MM-dd-yyyy"))
                r = cmd.ExecuteReader
                While r.Read
                    If r("Country_").ToString = "India" Or r("Country_").ToString = Nothing Then
                        If r("GST_Type").ToString <> "Regular" Then
                            If Val(r("Total_TAX").ToString) <> 0 Then
                                'If Val(r("Invoice_Amount").ToString) < 250000 Then
                                Grid1.Rows.Add(r("ID").ToString, r("Name").ToString, r("GST").ToString, "", N2_FORMATE(r("Taxable").ToString), N2_FORMATE(r("IGST").ToString), N2_FORMATE(r("CSGST").ToString), N2_FORMATE(r("CSGST").ToString), N2_FORMATE(r("Total_TAX").ToString), N2_FORMATE(r("Invoice_Amount").ToString))
                                'End If
                            End If
                        End If
                    Else
                    End If
                End While
                r.Close()
            End With
        End If
    End Function
    Private Function Credit_Note_Registered_GSTR1()
        Dim vc As String
        Dim cnn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cnn) = True Then
            qury = "Select (Select [ID] From TBL_Ledger where ID = vc.Particuls) as [ID],
(Select [Name] From TBL_Ledger where ID = vc.Particuls) as [Name],
(Select [GSTNo] From TBL_Ledger where ID = vc.Particuls) as GST,
(Select [GST_Type] From TBL_Ledger where ID = vc.Particuls) as GST_Type,
Count(vc.Particuls) as [Count],
(SUM(vc.Cr) + SUM(vc.Dr)) - SUM(vc.Tax_Value) as [Taxable],
SUM(CASE WHEN vc.Tax_Type = 'I' THEN
(vc.Tax_Value)
END) as IGST,
SUM(CASE WHEN vc.Tax_Type = 'CS' THEN
(vc.Tax_Value) / 2
END) as CSGST,
SUM(vc.Tax_Value) as Total_TAX,
(SUM(vc.Cr) + SUM(vc.Dr)) as Invoice_Amount

From TBL_VC vc
where vc.CR_DR = 'Under' and (vc.Voucher_Type = 'Credit Note') and vc.Visible = 'Approval' " & Where_Filter() & " and  (Date BETWEEN @Frm_Date and @To_Date) Group By  vc.Particuls"

            Dim r As SQLiteDataReader
            cmd = New SQLiteCommand(qury, cnn)
            With cmd.Parameters
                .AddWithValue("@Frm_Date", Frm_date.ToString("MM-dd-yyyy"))
                .AddWithValue("@To_Date", to_date.ToString("MM-dd-yyyy"))
                r = cmd.ExecuteReader
                While r.Read
                    If r("GST_Type").ToString = "Regular" Then
                        Grid1.Rows.Add(r("ID").ToString, r("Name").ToString, r("GST").ToString, "", N2_FORMATE(r("Taxable").ToString), N2_FORMATE(r("IGST").ToString), N2_FORMATE(r("CSGST").ToString), N2_FORMATE(r("CSGST").ToString), N2_FORMATE(r("Total_TAX").ToString), N2_FORMATE(r("Invoice_Amount").ToString))
                    Else
                    End If
                End While
                r.Close()
            End With
        End If
    End Function
    Private Function Credit_Note_Regular_GSTR2()
        Dim vc As String
        Dim cnn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cnn) = True Then
            qury = "Select (Select [ID] From TBL_Ledger where ID = vc.Particuls) as [ID],
(Select [Name] From TBL_Ledger where ID = vc.Particuls) as [Name],
(Select [GSTNo] From TBL_Ledger where ID = vc.Particuls) as GST,
(Select [GST_Type] From TBL_Ledger where ID = vc.Particuls) as GST_Type,
(Select [Country] From TBL_Ledger where ID = vc.Particuls) as Country_,
Count(vc.Particuls) as [Count],
(SUM(vc.Cr) + SUM(vc.Dr)) - SUM(vc.Tax_Value) as [Taxable],
SUM(CASE WHEN vc.Tax_Type = 'I' THEN
(vc.Tax_Value)
END) as IGST,
SUM(CASE WHEN vc.Tax_Type = 'CS' THEN
(vc.Tax_Value) / 2
END) as CSGST,
SUM(vc.Tax_Value) as Total_TAX,
(SUM(vc.Cr) + SUM(vc.Dr)) as Invoice_Amount

From TBL_VC vc
where vc.CR_DR = 'Under' and (vc.Voucher_Type = 'Debit Note') and vc.Visible = 'Approval'  " & Where_Filter() & " and  (Date BETWEEN @Frm_Date and @To_Date) Group By  vc.Particuls"

            Dim r As SQLiteDataReader
            cmd = New SQLiteCommand(qury, cnn)
            With cmd.Parameters
                .AddWithValue("@Frm_Date", Frm_date.ToString("MM-dd-yyyy"))
                .AddWithValue("@To_Date", to_date.ToString("MM-dd-yyyy"))
                r = cmd.ExecuteReader
                While r.Read
                    If r("Country_").ToString = "India" Or r("Country_").ToString = Nothing Then
                        If r("GST_Type").ToString = "Regular" Then
                            Grid1.Rows.Add(r("ID").ToString, r("Name").ToString, r("GST").ToString, "", N2_FORMATE(r("Taxable").ToString), N2_FORMATE(r("IGST").ToString), N2_FORMATE(r("CSGST").ToString), N2_FORMATE(r("CSGST").ToString), N2_FORMATE(r("Total_TAX").ToString), N2_FORMATE(r("Invoice_Amount").ToString))
                        Else
                        End If
                    End If
                End While
                r.Close()
            End With
        End If
    End Function
    Private Function Credit_Note_Unregisterd_GSTR2()
        Dim vc As String
        Dim cnn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cnn) = True Then
            qury = "Select (Select [ID] From TBL_Ledger where ID = vc.Particuls) as [ID],
(Select [Name] From TBL_Ledger where ID = vc.Particuls) as [Name],
(Select [GSTNo] From TBL_Ledger where ID = vc.Particuls) as GST,
(Select [GST_Type] From TBL_Ledger where ID = vc.Particuls) as GST_Type,
(Select [Country] From TBL_Ledger where ID = vc.Particuls) as Country_,
Count(vc.Particuls) as [Count],
(SUM(vc.Cr) + SUM(vc.Dr)) - SUM(vc.Tax_Value) as [Taxable],
SUM(CASE WHEN vc.Tax_Type = 'I' THEN
(vc.Tax_Value)
END) as IGST,
SUM(CASE WHEN vc.Tax_Type = 'CS' THEN
(vc.Tax_Value) / 2
END) as CSGST,
SUM(vc.Tax_Value) as Total_TAX,
(SUM(vc.Cr) + SUM(vc.Dr)) as Invoice_Amount

From TBL_VC vc
where vc.CR_DR = 'Under' and (vc.Voucher_Type = 'Debit Note') and vc.Visible = 'Approval'  " & Where_Filter() & " and  (Date BETWEEN @Frm_Date and @To_Date) Group By  vc.Particuls"

            Dim r As SQLiteDataReader
            cmd = New SQLiteCommand(qury, cnn)
            With cmd.Parameters
                .AddWithValue("@Frm_Date", Frm_date.ToString("MM-dd-yyyy"))
                .AddWithValue("@To_Date", to_date.ToString("MM-dd-yyyy"))
                r = cmd.ExecuteReader
                While r.Read
                    If r("Country_").ToString = "India" Or r("Country_").ToString = Nothing Then
                        If r("GST_Type").ToString <> "Regular" Then
                            Grid1.Rows.Add(r("ID").ToString, r("Name").ToString, "", "", N2_FORMATE(r("Taxable").ToString), N2_FORMATE(r("IGST").ToString), N2_FORMATE(r("CSGST").ToString), N2_FORMATE(r("CSGST").ToString), N2_FORMATE(r("Total_TAX").ToString), N2_FORMATE(r("Invoice_Amount").ToString))
                        End If
                    End If
                End While
                r.Close()
            End With
        End If
    End Function
    Private Function Credit_Note_Unregistered_GSTR1()
        Dim vc As String
        Dim cnn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cnn) = True Then
            qury = "Select (Select [ID] From TBL_Ledger where ID = vc.Particuls) as [ID],
(Select [Name] From TBL_Ledger where ID = vc.Particuls) as [Name],
(Select [GSTNo] From TBL_Ledger where ID = vc.Particuls) as GST,
(Select [GST_Type] From TBL_Ledger where ID = vc.Particuls) as GST_Type,
Count(vc.Particuls) as [Count],
(SUM(vc.Cr) + SUM(vc.Dr)) - SUM(vc.Tax_Value) as [Taxable],
SUM(CASE WHEN vc.Tax_Type = 'I' THEN
(vc.Tax_Value)
END) as IGST,
SUM(CASE WHEN vc.Tax_Type = 'CS' THEN
(vc.Tax_Value) / 2
END) as CSGST,
SUM(vc.Tax_Value) as Total_TAX,
(SUM(vc.Cr) + SUM(vc.Dr)) as Invoice_Amount

From TBL_VC vc
where vc.CR_DR = 'Under' and (vc.Voucher_Type = 'Credit Note') and vc.Visible = 'Approval' " & Where_Filter() & " and  (Date BETWEEN @Frm_Date and @To_Date) Group By  vc.Particuls"

            Dim r As SQLiteDataReader
            cmd = New SQLiteCommand(qury, cnn)
            With cmd.Parameters
                .AddWithValue("@Frm_Date", Frm_date.ToString("MM-dd-yyyy"))
                .AddWithValue("@To_Date", to_date.ToString("MM-dd-yyyy"))
                r = cmd.ExecuteReader
                While r.Read
                    If r("GST_Type").ToString <> "Regular" Then
                        Grid1.Rows.Add(r("ID").ToString, r("Name").ToString, r("GST").ToString, "", N2_FORMATE(r("Taxable").ToString), N2_FORMATE(r("IGST").ToString), N2_FORMATE(r("CSGST").ToString), N2_FORMATE(r("CSGST").ToString), N2_FORMATE(r("Total_TAX").ToString), N2_FORMATE(r("Invoice_Amount").ToString))
                    Else
                    End If
                End While
                r.Close()
            End With
        End If
    End Function
    Private Function Export_ivc_GSTR1()
        Dim vc As String
        Dim cnn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cnn) = True Then
            qury = "Select (Select [ID] From TBL_Ledger where ID = vc.Account) as [ID],
(Select [Name] From TBL_Ledger where ID = vc.Account) as [Name],
(Select [Country] From TBL_Ledger where ID = vc.Account) as [Country_],
(Select [GSTNo] From TBL_Ledger where ID = vc.Account) as GST,
Count(vc.Account) as [Count],
(SUM(vc.Cr) + SUM(vc.Dr)) - SUM(vc.Tax_Value) as [Taxable],
SUM(CASE WHEN vc.Tax_Type = 'I' THEN
(vc.Tax_Value)
END) as IGST,
SUM(CASE WHEN vc.Tax_Type = 'CS' THEN
(vc.Tax_Value) / 2
END) as CSGST,
SUM(vc.Tax_Value) as Total_TAX,
(SUM(vc.Cr) + SUM(vc.Dr)) as Invoice_Amount

From TBL_VC vc
where vc.CR_DR = 'Head' and (vc.Voucher_Type = 'Sales' or vc.Voucher_Type = 'Purchase Return') and vc.Visible = 'Approval' " & Where_Filter() & " and  (Date BETWEEN @Frm_Date and @To_Date) Group By  vc.Account"

            Dim r As SQLiteDataReader
            cmd = New SQLiteCommand(qury, cnn)
            With cmd.Parameters
                .AddWithValue("@Frm_Date", Frm_date.ToString("MM-dd-yyyy"))
                .AddWithValue("@To_Date", to_date.ToString("MM-dd-yyyy"))
                r = cmd.ExecuteReader
                While r.Read
                    If r("Country_").ToString = "India" Or r("Country_").ToString = Nothing Then
                    Else
                        Grid1.Rows.Add(r("ID").ToString, r("Name").ToString, r("GST").ToString, "", N2_FORMATE(r("Taxable").ToString), N2_FORMATE(r("IGST").ToString), N2_FORMATE(r("CSGST").ToString), N2_FORMATE(r("CSGST").ToString), N2_FORMATE(r("Total_TAX").ToString), N2_FORMATE(r("Invoice_Amount").ToString), r("Country_"))
                    End If
                End While
                r.Close()
            End With
        End If
    End Function
    Private Function Import_GSTR2(Type As String)
        Dim vc As String
        Dim cnn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cnn) = True Then
            qury = "Select (Select [ID] From TBL_Ledger where id = vc.Account) as ID_,
(Select [Name] From TBL_Ledger where id = vc.Account) as [Name],
(Select [GSTNo] From TBL_Ledger where id = vc.Account) as [GST],
(Select Country From TBL_Ledger where id = vc.Account) as Country_,
(Select GST_Type From TBL_Stock_Item where id = vc.Particuls) as GST_Type,
((vc.Cr) + (vc.Dr)) as [Taxable],
(CASE WHEN vc.Tax_Type = 'I' THEN
(vc.Tax_Value)
END) as IGST,
(CASE WHEN vc.Tax_Type = 'CS' THEN
(vc.Tax_Value) / 2
END) as CSGST,
(vc.Tax_Value) as Total_TAX,
((vc.Cr) + (vc.Dr)) + (vc.Tax_Value) as Invoice_Amount

 From TBL_VC vc
 where vc.CR_DR = 'Under' and (vc.Voucher_Type = 'Purchase' or vc.Voucher_Type = 'Sales Return') and vc.Visible = 'Approval' " & Where_Filter() & " and  (Date BETWEEN @Frm_Date and @To_Date) 
Order By [ID_]"

            Dim Duplicate_ID As String = ""
            Dim r As SQLiteDataReader
            cmd = New SQLiteCommand(qury, cnn)
            With cmd.Parameters
                .AddWithValue("@Frm_Date", Frm_date.ToString("MM-dd-yyyy"))
                .AddWithValue("@To_Date", to_date.ToString("MM-dd-yyyy"))
                r = cmd.ExecuteReader
                While r.Read
                    If r("Country_").ToString = "India" Or r("Country_").ToString = Nothing Then
                    Else
                        If r("GST_Type").ToString = Type Then
                            If Duplicate_ID = r("ID_").ToString Then
                                Dim ro As DataGridViewRow = Grid1.Rows(Grid1.Rows.Count - 1)
                                Grid1.Rows(ro.Index).SetValues(r("ID_").ToString, r("Name").ToString, r("GST").ToString, "", N2_FORMATE(Val(ro.Cells(4).Value) + Val(r("Taxable").ToString)), N2_FORMATE(Val(ro.Cells(5).Value) + Val(r("IGST").ToString)), N2_FORMATE(Val(ro.Cells(6).Value) + Val(r("CSGST").ToString)), N2_FORMATE(Val(ro.Cells(7).Value) + Val(r("CSGST").ToString)), N2_FORMATE(Val(ro.Cells(8).Value) + Val(r("Total_TAX").ToString)), N2_FORMATE(Val(ro.Cells(9).Value) + Val(r("Invoice_Amount").ToString)), r("Country_"))
                            Else
                                Grid1.Rows.Add(r("ID_").ToString, r("Name").ToString, r("GST").ToString, "", Val(r("Taxable").ToString), Val(r("IGST").ToString), Val(r("CSGST").ToString), Val(r("CSGST").ToString), Val(r("Total_TAX").ToString), Val(r("Invoice_Amount").ToString), r("Country_"))
                            End If
                            Duplicate_ID = r("ID_").ToString
                        End If
                    End If
                End While
                r.Close()
            End With
        End If
    End Function
    Private Function Nill_Rated_ivc_GSTR1()
        Dim vc As String
        Dim cnn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cnn) = True Then
            qury = "Select (Select [ID] From TBL_Ledger where ID = vc.Account) as [ID],
(Select [Name] From TBL_Ledger where ID = vc.Account) as [Name],
(Select [Country] From TBL_Ledger where ID = vc.Account) as [Country_],
(Select [GSTNo] From TBL_Ledger where ID = vc.Account) as GST,
Count(vc.Account) as [Count],
(SUM(vc.Cr) + SUM(vc.Dr)) - SUM(vc.Tax_Value) as [Taxable],
SUM(CASE WHEN vc.Tax_Type = 'I' THEN
(vc.Tax_Value)
END) as IGST,
SUM(CASE WHEN vc.Tax_Type = 'CS' THEN
(vc.Tax_Value) / 2
END) as CSGST,
SUM(vc.Tax_Value) as Total_TAX,
(SUM(vc.Cr) + SUM(vc.Dr)) as Invoice_Amount

From TBL_VC vc
where vc.Tax_Value = '0' and vc.CR_DR = 'Head' and (vc.Voucher_Type = 'Sales' or vc.Voucher_Type = 'Purchase Return') and vc.Visible = 'Approval' " & Where_Filter() & " and  (Date BETWEEN @Frm_Date and @To_Date) Group By  vc.Account"

            Dim r As SQLiteDataReader
            cmd = New SQLiteCommand(qury, cnn)
            With cmd.Parameters
                .AddWithValue("@Frm_Date", Frm_date.ToString("MM-dd-yyyy"))
                .AddWithValue("@To_Date", to_date.ToString("MM-dd-yyyy"))
                r = cmd.ExecuteReader
                While r.Read
                    If r("Country_").ToString = "India" Or r("Country_").ToString = Nothing Then
                        'If Val(r("Total_TAX").ToString) = 0 Then
                        Grid1.Rows.Add(r("ID").ToString, r("Name").ToString, r("GST").ToString, "", N2_FORMATE(r("Taxable").ToString), N2_FORMATE(r("IGST").ToString), N2_FORMATE(r("CSGST").ToString), N2_FORMATE(r("CSGST").ToString), N2_FORMATE(r("Total_TAX").ToString), N2_FORMATE(r("Invoice_Amount").ToString), r("Country_"))
                        'End If
                    End If
                End While
                r.Close()
            End With
        End If
    End Function
    Private Function Nill_Rated_ivc_GSTR2()
        Dim vc As String
        Dim cnn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cnn) = True Then
            qury = "Select (Select [ID] From TBL_Ledger where ID = vc.Account) as [ID],
(Select [Name] From TBL_Ledger where ID = vc.Account) as [Name],
(Select [Country] From TBL_Ledger where ID = vc.Account) as [Country_],
(Select [GSTNo] From TBL_Ledger where ID = vc.Account) as GST,
(Select [GST_Type] From TBL_Ledger where ID = vc.Account) as GST_Type,
Count(vc.Account) as [Count],
(SUM(vc.Cr) + SUM(vc.Dr)) - SUM(vc.Tax_Value) as [Taxable],
SUM(CASE WHEN vc.Tax_Type = 'I' THEN
(vc.Tax_Value)
END) as IGST,
SUM(CASE WHEN vc.Tax_Type = 'CS' THEN
(vc.Tax_Value) / 2
END) as CSGST,
SUM(vc.Tax_Value) as Total_TAX,
(SUM(vc.Cr) + SUM(vc.Dr)) as Invoice_Amount

From TBL_VC vc
where vc.CR_DR = 'Head' and (vc.Voucher_Type = 'Purchase' or vc.Voucher_Type = 'Sales Return') and vc.Visible = 'Approval' " & Where_Filter() & " and  (Date BETWEEN @Frm_Date and @To_Date) Group By  vc.Account"

            Dim r As SQLiteDataReader
            cmd = New SQLiteCommand(qury, cnn)
            With cmd.Parameters
                .AddWithValue("@Frm_Date", Frm_date.ToString("MM-dd-yyyy"))
                .AddWithValue("@To_Date", to_date.ToString("MM-dd-yyyy"))
                r = cmd.ExecuteReader
                While r.Read
                    If r("Country_").ToString = "India" Or r("Country_").ToString = Nothing Then
                        If Val(r("Total_TAX").ToString) = 0 Then
                            Grid1.Rows.Add(r("ID").ToString, r("Name").ToString, r("GST").ToString, "", N2_FORMATE(r("Taxable").ToString), N2_FORMATE(r("IGST").ToString), N2_FORMATE(r("CSGST").ToString), N2_FORMATE(r("CSGST").ToString), N2_FORMATE(r("Total_TAX").ToString), N2_FORMATE(r("Invoice_Amount").ToString), r("Country_"))
                        End If
                    End If
                End While
                r.Close()
            End With
        End If
    End Function
    Private Function Fill_Grid()
        Grid1.Rows.Clear()

        If VC_ID_ = "GSTR1" Then
            If VC_Type_ = "B2B Invoice - 4A, 4B, 4C, 6B, 6C" Then
                B2B_GSTR1()
            ElseIf VC_Type_ = "B2C (Large) Invoice - 5A, 5B" Then
                B2C_Large_GSTR1()
            ElseIf VC_Type_ = "B2C (Small) Invoice - 7" Then
                B2C_Small_GSTR1()
            ElseIf VC_Type_ = "Credit/Debit Notes (Registered) - 9B" Then
                Credit_Note_Registered_GSTR1()
            ElseIf VC_Type_ = "Credit/Debit Notes (Unregistered) - 9B" Then
                Credit_Note_Unregistered_GSTR1()
            ElseIf VC_Type_ = "Export Invoices - 6A" Then
                Export_ivc_GSTR1()
                Grid1.Columns(10).Visible = True
                Grid1.Columns(10).DisplayIndex = 2
                Grid1.Columns(2).Visible = False
                Grid1.Columns(5).Visible = False
                Grid1.Columns(6).Visible = False
                Grid1.Columns(7).Visible = False
            ElseIf VC_Type_ = "Nill Rated Invoices - 8A, 8B, 8C, 8D" Then
                Nill_Rated_ivc_GSTR1()
                Grid1.Columns(2).Visible = False
                Grid1.Columns(5).Visible = False
                Grid1.Columns(6).Visible = False
                Grid1.Columns(7).Visible = False
                Grid1.Columns(8).Visible = False
            End If
        ElseIf VC_ID_ = "GSTR2" Then
            If VC_Type_ = "B2B Invoice - 3, 4A" Then
                B2B_GSTR2()
            ElseIf VC_Type_ = "Credit/Debit Notes Regular - 6C" Then
                Credit_Note_Regular_GSTR2()
            ElseIf VC_Type_ = "B2BUR Invoice - 4B" Then
                B2BUR_GSTR2()
            ElseIf VC_Type_ = "Impoer of Services - 4C" Then
                Import_GSTR2("Services")
            ElseIf VC_Type_ = "Impoer of Goods - 5" Then
                Import_GSTR2("Goods")
            ElseIf VC_Type_ = "Credit/Debit Notes Unregistered - 6C" Then
                Credit_Note_Unregisterd_GSTR2()
            ElseIf VC_Type_ = "Nill Rated Invoices - 7 (Summary)" Then
                Nill_Rated_ivc_GSTR2()
                Grid1.Columns(2).Visible = False
                Grid1.Columns(5).Visible = False
                Grid1.Columns(6).Visible = False
                Grid1.Columns(7).Visible = False
                Grid1.Columns(8).Visible = False
            End If
        End If
    End Function

    Private Sub Grid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid1.CellContentClick

    End Sub

    Private Sub Grid1_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cell("Dealer/Party Vouchers Summary", VC_Type_, VC_ID_, Branch_ID, Frm_date, to_date, Grid1.CurrentRow.Cells(0).Value.ToString)
        End If
    End Sub

    Private Sub Grid1_Paint(sender As Object, e As PaintEventArgs) Handles Grid1.Paint
        Grid1.DefaultCellStyle.Font = Defolt_Fonts
    End Sub

    Private Sub dealer_party_vouchers_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
    End Sub
End Class