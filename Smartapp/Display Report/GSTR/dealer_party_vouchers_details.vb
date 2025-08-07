Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Data.SQLite

Public Class dealer_party_vouchers_details
    Dim From_ID As String
    Private VC_Type_ As String
    Private VC_ID_ As String
    Private Path_End As String
    Dim YN_Details As Boolean
    Dim Acc_Under As String
    Dim Frm_date As Date
    Dim to_date As Date

    Public Branch_ID As String = ""
    Public Account_VC As String = ""
    Public Branch As String = "Primary"
    Public Narration_ As Boolean = False

    Public Delete_Entry = False
    Private Sub dealer_party_vouchers_details_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Frm_Design(Me)
        Path_End = BG_frm.BG_Path_TXT.Text

        VC_Type_ = Link_Valu(0)
        Label1.Text = VC_Type_
        VC_ID_ = Link_Valu(1)
        Branch_ID = Link_Valu(2)
        Frm_Date_LB.Text = Date_Formate(Link_Valu(3))
        To_Date_LB.Text = Date_Formate(Link_Valu(4))
        Account_VC = Link_Valu(5)

        Label2.Text = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Name", "ID = '" & Account_VC & "'")
        Label3.Text = Find_DT_Value(Database_File.cre, "TBL_Ledger", "GSTNo", "ID = '" & Account_VC & "'")

        BG_frm.HADE_TXT.Text = "Dealer/Party Vouchers Summary"
        BG_frm.TYP_TXT.Text = ""

        'Button_Manage()
        'Add_Hander_Remove_Handel(True)

        Branch = Find_Branch_Name(Branch_ID)
        Label17.Text = Branch
        Grid1.Focus()
    End Sub

    Private Sub dealer_party_vouchers_details_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.HADE_TXT.Text = "Dealer/Party Vouchers Summary"
        BG_frm.TYP_TXT.Text = ""

        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text
        Button_Clear()
        'Config_Fill()
        'If Update_Report = True Then
        Fill_Grid()
        'End If
        Grid1.Focus()
    End Sub

    Private Sub dealer_party_vouchers_details_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub dealer_party_vouchers_details_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
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
    Dim Country_ As String
    Dim GST_Type As String
    Private Function Fill_Grid()
        Country_ = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Country", "ID = '" & Account_VC & "'")
        GST_Type = Find_DT_Value(Database_File.cre, "TBL_Ledger", "GST_Type", "ID = '" & Account_VC & "'")

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
                Grid1.Columns(4).Visible = False
                Grid1.Columns(5).Visible = False
                Grid1.Columns(6).Visible = False
                Grid1.Columns(7).Visible = False
            ElseIf VC_Type_ = "Nill Rated Invoices - 8A, 8B, 8C, 8D" Then
                Nill_Rated_ivc_GSTR1()
                Grid1.Columns(4).Visible = False
                Grid1.Columns(5).Visible = False
                Grid1.Columns(6).Visible = False
                Grid1.Columns(7).Visible = False
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

            ElseIf VC_Type_ = "Nill Rated Invoices - 8A, 8B, 8C, 8D" Then
                Nill_Rated_ivc_GSTR1()
                Grid1.Columns(4).Visible = False
                Grid1.Columns(5).Visible = False
                Grid1.Columns(6).Visible = False
                Grid1.Columns(7).Visible = False
            End If
        End If
    End Function
    Private Function B2B_GSTR1()
        Dim vc As String
        Dim cnn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cnn) = True Then
            qury = "Select vc.Tra_ID,vc.[Date],vc.Voucher_No,vc.Voucher_Type,(vc.cr + vc.Dr) - (vc.Tax_Value) as Taxble_Amount,
(CASE WHEN Vc.Tax_Type = 'I' THEN
vc.Tax_Value
END) as IGST,
(CASE WHEN Vc.Tax_Type = 'CS' THEN
vc.Tax_Value / 2
END) as CSGST,
vc.Tax_Value,
(vc.cr + vc.Dr) as Invoice_Amount
From TBL_VC vc
where vc.CR_DR = 'Head' and Account = '" & Account_VC & "' and (vc.Voucher_Type = 'Sales' or vc.Voucher_Type = 'Purchase Return') and vc.Visible = 'Approval' " & Where_Filter() & " and  (Date BETWEEN @Frm_Date and @To_Date)"

            Dim r As SQLiteDataReader
            cmd = New SQLiteCommand(qury, cnn)
            With cmd.Parameters
                .AddWithValue("@Frm_Date", Frm_date.ToString("MM-dd-yyyy"))
                .AddWithValue("@To_Date", to_date.ToString("MM-dd-yyyy"))
                r = cmd.ExecuteReader
                While r.Read
                    If Country_ = "India" Or Country_ = Nothing Then
                        If Val(r("Tax_Value").ToString) <> 0 Then
                            If GST_Type = "Regular" Then
                                Grid1.Rows.Add(CDate(r("Date")).ToString("dd-MM-yyyy"), r("Voucher_Type"), r("Voucher_no"), N2_FORMATE(r("Taxble_Amount").ToString), N2_FORMATE(r("IGST").ToString), N2_FORMATE(r("CSGST").ToString), N2_FORMATE(r("CSGST").ToString), N2_FORMATE(r("Tax_Value").ToString), N2_FORMATE(r("Invoice_Amount").ToString), r("Tra_ID").ToString)
                            End If
                        End If
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
            qury = "Select vc.Tra_ID,vc.[Date],vc.Voucher_No,vc.Voucher_Type,(vc.cr + vc.Dr) - (vc.Tax_Value) as Taxble_Amount,
(CASE WHEN Vc.Tax_Type = 'I' THEN
vc.Tax_Value
END) as IGST,
(CASE WHEN Vc.Tax_Type = 'CS' THEN
vc.Tax_Value / 2
END) as CSGST,
vc.Tax_Value,
(vc.cr + vc.Dr) as Invoice_Amount
From TBL_VC vc
where vc.CR_DR = 'Head' and Account = '" & Account_VC & "' and (vc.Voucher_Type = 'Purchase' or vc.Voucher_Type = 'Sales Return') and vc.Visible = 'Approval' " & Where_Filter() & " and  (Date BETWEEN @Frm_Date and @To_Date)"

            Dim r As SQLiteDataReader
            cmd = New SQLiteCommand(qury, cnn)
            With cmd.Parameters
                .AddWithValue("@Frm_Date", Frm_date.ToString("MM-dd-yyyy"))
                .AddWithValue("@To_Date", to_date.ToString("MM-dd-yyyy"))
                r = cmd.ExecuteReader
                While r.Read
                    If Val(r("Tax_Value")) <> 0 Then
                        Grid1.Rows.Add(CDate(r("Date")).ToString("dd-MM-yyyy"), r("Voucher_Type"), r("Voucher_no"), N2_FORMATE(r("Taxble_Amount").ToString), N2_FORMATE(r("IGST").ToString), N2_FORMATE(r("CSGST").ToString), N2_FORMATE(r("CSGST").ToString), N2_FORMATE(r("Tax_Value").ToString), N2_FORMATE(r("Invoice_Amount").ToString), r("Tra_ID").ToString)
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
            qury = "Select vc.Tra_ID,vc.[Date],
(Select Country From TBL_Ledger where ID = vc.Particuls) as Country_,
vc.Voucher_No,vc.Voucher_Type,(vc.cr + vc.Dr) - (vc.Tax_Value) as Taxble_Amount,
(CASE WHEN Vc.Tax_Type = 'I' THEN
vc.Tax_Value
END) as IGST,
(CASE WHEN Vc.Tax_Type = 'CS' THEN
vc.Tax_Value / 2
END) as CSGST,
vc.Tax_Value,
(vc.cr + vc.Dr) as Invoice_Amount
From TBL_VC vc
where vc.CR_DR = 'Under' and Particuls = '" & Account_VC & "' and (vc.Voucher_Type = 'Debit Note' ) and vc.Visible = 'Approval' " & Where_Filter() & " and  (Date BETWEEN @Frm_Date and @To_Date)"

            Dim r As SQLiteDataReader
            cmd = New SQLiteCommand(qury, cnn)
            With cmd.Parameters
                .AddWithValue("@Frm_Date", Frm_date.ToString("MM-dd-yyyy"))
                .AddWithValue("@To_Date", to_date.ToString("MM-dd-yyyy"))
                r = cmd.ExecuteReader
                While r.Read
                    Grid1.Rows.Add(CDate(r("Date")).ToString("dd-MM-yyyy"), r("Voucher_Type"), r("Voucher_no"), N2_FORMATE(r("Taxble_Amount").ToString), N2_FORMATE(r("IGST").ToString), N2_FORMATE(r("CSGST").ToString), N2_FORMATE(r("CSGST").ToString), N2_FORMATE(r("Tax_Value").ToString), N2_FORMATE(r("Invoice_Amount").ToString), r("Tra_ID").ToString)
                End While
                r.Close()
            End With
        End If
    End Function
    Private Function Import_GSTR2(Type As String)
        Dim vc As String
        Dim cnn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cnn) = True Then
            qury = "Select vc.Tra_ID,vc.[Date],(Select GST_Type From TBL_Stock_Item where ID = vc.Particuls) as GST_Type,
(Select Country From TBL_Ledger where ID = vc.Account) as Country_,
vc.Voucher_No,vc.Voucher_Type,(vc.cr + vc.Dr) as Taxble_Amount,
(CASE WHEN Vc.Tax_Type = 'I' THEN
vc.Tax_Value
END) as IGST,
(CASE WHEN Vc.Tax_Type = 'CS' THEN
vc.Tax_Value / 2
END) as CSGST,
vc.Tax_Value,
(vc.cr + vc.Dr) + (vc.Tax_Value) as Invoice_Amount
From TBL_VC vc
where vc.CR_DR = 'Under' and Account = '" & Account_VC & "' and (vc.Voucher_Type = 'Purchase' or vc.Voucher_Type = 'Sales Return') and vc.Visible = 'Approval' " & Where_Filter() & " and  (Date BETWEEN @Frm_Date and @To_Date)"

            Dim r As SQLiteDataReader
            cmd = New SQLiteCommand(qury, cnn)
            With cmd.Parameters
                .AddWithValue("@Frm_Date", Frm_date.ToString("MM-dd-yyyy"))
                .AddWithValue("@To_Date", to_date.ToString("MM-dd-yyyy"))
                r = cmd.ExecuteReader
                While r.Read
                    If r("Country_").ToString = "India" Or r("Country_").ToString = Nothing Then
                    Else
                        If r("GST_Type") = Type Then
                            Grid1.Rows.Add(CDate(r("Date")).ToString("dd-MM-yyyy"), r("Voucher_Type"), r("Voucher_no"), N2_FORMATE(r("Taxble_Amount").ToString), N2_FORMATE(r("IGST").ToString), N2_FORMATE(r("CSGST").ToString), N2_FORMATE(r("CSGST").ToString), N2_FORMATE(r("Tax_Value").ToString), N2_FORMATE(r("Invoice_Amount").ToString), r("Tra_ID").ToString)
                        End If
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
            qury = "Select vc.Tra_ID,vc.[Date],vc.Voucher_No,vc.Voucher_Type,(vc.cr + vc.Dr) - (vc.Tax_Value) as Taxble_Amount,
(CASE WHEN Vc.Tax_Type = 'I' THEN
vc.Tax_Value
END) as IGST,
(CASE WHEN Vc.Tax_Type = 'CS' THEN
vc.Tax_Value / 2
END) as CSGST,
vc.Tax_Value,
(vc.cr + vc.Dr) as Invoice_Amount
From TBL_VC vc
where vc.CR_DR = 'Head' and Account = '" & Account_VC & "' and (vc.Voucher_Type = 'Purchase' or vc.Voucher_Type = 'Sales Return') and vc.Visible = 'Approval' " & Where_Filter() & " and  (Date BETWEEN @Frm_Date and @To_Date)"

            Dim r As SQLiteDataReader
            cmd = New SQLiteCommand(qury, cnn)
            With cmd.Parameters
                .AddWithValue("@Frm_Date", Frm_date.ToString("MM-dd-yyyy"))
                .AddWithValue("@To_Date", to_date.ToString("MM-dd-yyyy"))
                r = cmd.ExecuteReader
                While r.Read
                    If Val(r("Tax_Value")) <> 0 Then
                        Grid1.Rows.Add(CDate(r("Date")).ToString("dd-MM-yyyy"), r("Voucher_Type"), r("Voucher_no"), N2_FORMATE(r("Taxble_Amount").ToString), N2_FORMATE(r("IGST").ToString), N2_FORMATE(r("CSGST").ToString), N2_FORMATE(r("CSGST").ToString), N2_FORMATE(r("Tax_Value").ToString), N2_FORMATE(r("Invoice_Amount").ToString), r("Tra_ID").ToString)
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
            qury = "Select vc.Tra_ID,vc.[Date],(Select Country From TBL_Ledger where ID = vc.Account) as Country_,vc.Voucher_No,vc.Voucher_Type,(vc.cr + vc.Dr) - (vc.Tax_Value) as Taxble_Amount,
(CASE WHEN Vc.Tax_Type = 'I' THEN
vc.Tax_Value
END) as IGST,
(CASE WHEN Vc.Tax_Type = 'CS' THEN
vc.Tax_Value / 2
END) as CSGST,
vc.Tax_Value,
(vc.cr + vc.Dr) as Invoice_Amount
From TBL_VC vc
where vc.CR_DR = 'Head' and Account = '" & Account_VC & "' and  (vc.Voucher_Type = 'Sales' or vc.Voucher_Type = 'Purchase Return') and vc.Visible = 'Approval' " & Where_Filter() & " and  (Date BETWEEN @Frm_Date and @To_Date)"

            Dim r As SQLiteDataReader
            cmd = New SQLiteCommand(qury, cnn)
            With cmd.Parameters
                .AddWithValue("@Frm_Date", Frm_date.ToString("MM-dd-yyyy"))
                .AddWithValue("@To_Date", to_date.ToString("MM-dd-yyyy"))
                r = cmd.ExecuteReader
                While r.Read

                    If Country_ = "India" Or Country_ = Nothing Then
                        If GST_Type <> "Regular" Then
                            If Val(r("Tax_Value").ToString) <> 0 Then
                                If Val(r("Invoice_Amount").ToString) >= 250000 Then
                                    Grid1.Rows.Add(CDate(r("Date")).ToString("dd-MM-yyyy"), r("Voucher_Type"), r("Voucher_no"), N2_FORMATE(r("Taxble_Amount").ToString), N2_FORMATE(r("IGST").ToString), N2_FORMATE(r("CSGST").ToString), N2_FORMATE(r("CSGST").ToString), N2_FORMATE(r("Tax_Value").ToString), N2_FORMATE(r("Invoice_Amount").ToString), r("Tra_ID").ToString)
                                End If
                            End If
                        End If
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
            qury = "Select vc.Tra_ID,vc.[Date],(Select Country From TBL_Ledger where ID = vc.Account) as Country_,vc.Voucher_No,vc.Voucher_Type,(vc.cr + vc.Dr) - (vc.Tax_Value) as Taxble_Amount,
(CASE WHEN Vc.Tax_Type = 'I' THEN
vc.Tax_Value
END) as IGST,
(CASE WHEN Vc.Tax_Type = 'CS' THEN
vc.Tax_Value / 2
END) as CSGST,
vc.Tax_Value,
(vc.cr + vc.Dr) as Invoice_Amount
From TBL_VC vc
where vc.CR_DR = 'Head' and Account = '" & Account_VC & "' and  (vc.Voucher_Type = 'Sales' or vc.Voucher_Type = 'Purchase Return') and vc.Visible = 'Approval' " & Where_Filter() & " and  (Date BETWEEN @Frm_Date and @To_Date)"

            Dim r As SQLiteDataReader
            cmd = New SQLiteCommand(qury, cnn)
            With cmd.Parameters
                .AddWithValue("@Frm_Date", Frm_date.ToString("MM-dd-yyyy"))
                .AddWithValue("@To_Date", to_date.ToString("MM-dd-yyyy"))
                r = cmd.ExecuteReader
                While r.Read
                    If Country_ = "India" Or Country_ = Nothing Then
                        If GST_Type <> "Regular" Then
                            If Val(r("Tax_Value").ToString) <> 0 Then
                                If Val(r("Invoice_Amount").ToString) < 250000 Then
                                    Grid1.Rows.Add(CDate(r("Date")).ToString("dd-MM-yyyy"), r("Voucher_Type"), r("Voucher_no"), N2_FORMATE(r("Taxble_Amount").ToString), N2_FORMATE(r("IGST").ToString), N2_FORMATE(r("CSGST").ToString), N2_FORMATE(r("CSGST").ToString), N2_FORMATE(r("Tax_Value").ToString), N2_FORMATE(r("Invoice_Amount").ToString), r("Tra_ID").ToString)
                                End If
                            End If
                        End If
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
            qury = "Select vc.Tra_ID,vc.[Date],vc.Voucher_No,vc.Voucher_Type,(vc.cr + vc.Dr) - (vc.Tax_Value) as Taxble_Amount,
(CASE WHEN Vc.Tax_Type = 'I' THEN
vc.Tax_Value
END) as IGST,
(CASE WHEN Vc.Tax_Type = 'CS' THEN
vc.Tax_Value / 2
END) as CSGST,
vc.Tax_Value,
(vc.cr + vc.Dr) as Invoice_Amount

From TBL_VC vc
where vc.CR_DR = 'Under' and Particuls = '" & Account_VC & "' and (vc.Voucher_Type = 'Credit Note') and vc.Visible = 'Approval' " & Where_Filter() & " and  (Date BETWEEN @Frm_Date and @To_Date)"

            Dim r As SQLiteDataReader
            cmd = New SQLiteCommand(qury, cnn)
            With cmd.Parameters
                .AddWithValue("@Frm_Date", Frm_date.ToString("MM-dd-yyyy"))
                .AddWithValue("@To_Date", to_date.ToString("MM-dd-yyyy"))
                r = cmd.ExecuteReader
                While r.Read
                    Grid1.Rows.Add(CDate(r("Date")).ToString("dd-MM-yyyy"), r("Voucher_Type"), r("Voucher_no"), N2_FORMATE(r("Taxble_Amount").ToString), N2_FORMATE(r("IGST").ToString), N2_FORMATE(r("CSGST").ToString), N2_FORMATE(r("CSGST").ToString), N2_FORMATE(r("Tax_Value").ToString), N2_FORMATE(r("Invoice_Amount").ToString), r("Tra_ID").ToString)
                End While
                r.Close()
            End With
        End If
    End Function
    Private Function Credit_Note_Regular_GSTR2()
        Dim vc As String
        Dim cnn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cnn) = True Then
            qury = "Select vc.Tra_ID,vc.[Date],vc.Voucher_No,vc.Voucher_Type,(vc.cr + vc.Dr) - (vc.Tax_Value) as Taxble_Amount,
(CASE WHEN Vc.Tax_Type = 'I' THEN
vc.Tax_Value
END) as IGST,
(CASE WHEN Vc.Tax_Type = 'CS' THEN
vc.Tax_Value / 2
END) as CSGST,
vc.Tax_Value,
(vc.cr + vc.Dr) as Invoice_Amount

From TBL_VC vc
where vc.CR_DR = 'Under' and Particuls = '" & Account_VC & "' and (vc.Voucher_Type = 'Debit Note') and vc.Visible = 'Approval' " & Where_Filter() & " and  (Date BETWEEN @Frm_Date and @To_Date)"

            Dim r As SQLiteDataReader
            cmd = New SQLiteCommand(qury, cnn)
            With cmd.Parameters
                .AddWithValue("@Frm_Date", Frm_date.ToString("MM-dd-yyyy"))
                .AddWithValue("@To_Date", to_date.ToString("MM-dd-yyyy"))
                r = cmd.ExecuteReader
                While r.Read
                    Grid1.Rows.Add(CDate(r("Date")).ToString("dd-MM-yyyy"), r("Voucher_Type"), r("Voucher_no"), N2_FORMATE(r("Taxble_Amount").ToString), N2_FORMATE(r("IGST").ToString), N2_FORMATE(r("CSGST").ToString), N2_FORMATE(r("CSGST").ToString), N2_FORMATE(r("Tax_Value").ToString), N2_FORMATE(r("Invoice_Amount").ToString), r("Tra_ID").ToString)
                End While
                r.Close()
            End With
        End If
    End Function
    Private Function Credit_Note_Unregistered_GSTR1()
        Dim vc As String
        Dim cnn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cnn) = True Then
            qury = "Select vc.Tra_ID,vc.[Date],vc.Voucher_No,vc.Voucher_Type,(vc.cr + vc.Dr) - (vc.Tax_Value) as Taxble_Amount,
(CASE WHEN Vc.Tax_Type = 'I' THEN
vc.Tax_Value
END) as IGST,
(CASE WHEN Vc.Tax_Type = 'CS' THEN
vc.Tax_Value / 2
END) as CSGST,
vc.Tax_Value,
(vc.cr + vc.Dr) as Invoice_Amount

From TBL_VC vc
where vc.CR_DR = 'Under' and Particuls = '" & Account_VC & "' and (vc.Voucher_Type = 'Credit Note') and vc.Visible = 'Approval' " & Where_Filter() & " and  (Date BETWEEN @Frm_Date and @To_Date)"

            Dim r As SQLiteDataReader
            cmd = New SQLiteCommand(qury, cnn)
            With cmd.Parameters
                .AddWithValue("@Frm_Date", Frm_date.ToString("MM-dd-yyyy"))
                .AddWithValue("@To_Date", to_date.ToString("MM-dd-yyyy"))
                r = cmd.ExecuteReader
                While r.Read
                    Grid1.Rows.Add(CDate(r("Date")).ToString("dd-MM-yyyy"), r("Voucher_Type"), r("Voucher_no"), N2_FORMATE(r("Taxble_Amount").ToString), N2_FORMATE(r("IGST").ToString), N2_FORMATE(r("CSGST").ToString), N2_FORMATE(r("CSGST").ToString), N2_FORMATE(r("Tax_Value").ToString), N2_FORMATE(r("Invoice_Amount").ToString), r("Tra_ID").ToString)
                End While
                r.Close()
            End With
        End If
    End Function
    Private Function Export_ivc_GSTR1()
        Dim vc As String
        Dim cnn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cnn) = True Then
            qury = "Select vc.Tra_ID,vc.[Date],vc.Voucher_No,vc.Voucher_Type,(vc.cr + vc.Dr) - (vc.Tax_Value) as Taxble_Amount,
(CASE WHEN Vc.Tax_Type = 'I' THEN
vc.Tax_Value
END) as IGST,
(CASE WHEN Vc.Tax_Type = 'CS' THEN
vc.Tax_Value / 2
END) as CSGST,
vc.Tax_Value,
(vc.cr + vc.Dr) as Invoice_Amount

From TBL_VC vc
where vc.CR_DR = 'Head' and Account = '" & Account_VC & "' and (vc.Voucher_Type = 'Sales' or vc.Voucher_Type = 'Purchase Return') and vc.Visible = 'Approval' " & Where_Filter() & " and  (Date BETWEEN @Frm_Date and @To_Date)"

            Dim r As SQLiteDataReader
            cmd = New SQLiteCommand(qury, cnn)
            With cmd.Parameters
                .AddWithValue("@Frm_Date", Frm_date.ToString("MM-dd-yyyy"))
                .AddWithValue("@To_Date", to_date.ToString("MM-dd-yyyy"))
                r = cmd.ExecuteReader
                While r.Read
                    Grid1.Rows.Add(CDate(r("Date")).ToString("dd-MM-yyyy"), r("Voucher_Type"), r("Voucher_no"), N2_FORMATE(r("Taxble_Amount").ToString), N2_FORMATE(r("IGST").ToString), N2_FORMATE(r("CSGST").ToString), N2_FORMATE(r("CSGST").ToString), N2_FORMATE(r("Tax_Value").ToString), N2_FORMATE(r("Invoice_Amount").ToString), r("Tra_ID").ToString)
                End While
                r.Close()
            End With
        End If
    End Function
    Private Function Nill_Rated_ivc_GSTR1()
        Dim vc As String
        Dim cnn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cnn) = True Then
            qury = "Select vc.Tra_ID,vc.[Date],vc.Voucher_No,vc.Voucher_Type,(vc.cr + vc.Dr) - (vc.Tax_Value) as Taxble_Amount,
(CASE WHEN Vc.Tax_Type = 'I' THEN
vc.Tax_Value
END) as IGST,
(CASE WHEN Vc.Tax_Type = 'CS' THEN
vc.Tax_Value / 2
END) as CSGST,
vc.Tax_Value,
(vc.cr + vc.Dr) as Invoice_Amount

From TBL_VC vc
where (vc.Tax_Value = '0') and vc.CR_DR = 'Head' and Account = '" & Account_VC & "' and (vc.Voucher_Type = 'Sales' or vc.Voucher_Type = 'Purchase Return') and vc.Visible = 'Approval' " & Where_Filter() & " and  (Date BETWEEN @Frm_Date and @To_Date)"

            Dim r As SQLiteDataReader
            cmd = New SQLiteCommand(qury, cnn)
            With cmd.Parameters
                .AddWithValue("@Frm_Date", Frm_date.ToString("MM-dd-yyyy"))
                .AddWithValue("@To_Date", to_date.ToString("MM-dd-yyyy"))
                r = cmd.ExecuteReader
                While r.Read
                    Grid1.Rows.Add(CDate(r("Date")).ToString("dd-MM-yyyy"), r("Voucher_Type"), r("Voucher_no"), N2_FORMATE(r("Taxble_Amount").ToString), N2_FORMATE(r("IGST").ToString), N2_FORMATE(r("CSGST").ToString), N2_FORMATE(r("CSGST").ToString), N2_FORMATE(r("Tax_Value").ToString), N2_FORMATE(r("Invoice_Amount").ToString), r("Tra_ID").ToString)
                End While
                r.Close()
            End With
        End If
    End Function
    Private Sub Grid1_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cell("Voucher BG", Grid1.CurrentRow.Cells(9).Value, "Alter_Close", Grid1.CurrentRow.Cells(1).Value)
        End If
    End Sub

    Private Sub dealer_party_vouchers_details_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
    End Sub
End Class