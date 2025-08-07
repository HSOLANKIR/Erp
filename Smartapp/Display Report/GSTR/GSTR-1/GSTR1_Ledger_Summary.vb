Imports System.ComponentModel
Imports System.Data.SQLite
Imports System.IO
Imports Microsoft.Reporting.WinForms
Imports Microsoft.Win32
Public Class GSTR1_Ledger_Summary
    Dim From_ID As String
    Private VC_Type_ As String
    Private VC_ID_ As String
    Private Path_End As String
    Dim YN_Details As Boolean
    Dim Acc_Under As String
    Dim Frm_date As Date
    Dim to_date As Date

    Public Narration_ As Boolean = False
    Public Sorting_Methoud_ As String = "Date (Decreasing)"
    Public Delete_Entry = False

    Dim ds_print As New Print_dt
    Dim dt_print As New DataTable

    Dim Defolt_Select_ID As String = 0
    Private Sub GSTR1_Ledger_Summary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text

        VC_Type_ = Link_Valu(0)
        VC_ID_ = Link_Valu(1)

        Frm_Date_LB.Text = Date_Formate(Date_1)
        To_Date_LB.Text = Date_Formate(Date_2)

        GSLab.Text = Company_GST_str
        Label3.Text = VC_ID_

        BG_frm.HADE_TXT.Text = "GSTR1 Summary"
        BG_frm.TYP_TXT.Text = VC_Type_

        Button_Manage()
        Add_Hander_Remove_Handel(True)

        Update_Report = True
    End Sub
    Private Function Panel_Manag(pa As Panel)
        Panel1.Visible = False
        nillrate_Panel.Visible = False


        pa.Dock = DockStyle.Fill
        pa.Visible = True
    End Function
    Private Sub GSTR1_Ledger_Summary_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.HADE_TXT.Text = "GSTR1 Summary"
        BG_frm.TYP_TXT.Text = VC_Type_

        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text


        Button_Clear()
        Button_Manage()
        'cfg_fill()
        If Update_Report = True Then
            Fill_Grid()
        End If
        If Grid1.Visible = True Then
            Grid1.Focus()
        ElseIf Grid2.Visible = True Then
            Grid2.Focus()
        End If
    End Sub

    Private Sub GSTR1_Ledger_Summary_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
        If e.KeyCode = Keys.F2 AndAlso e.Modifiers = Keys.Alt Then
            BG_frm.R_3.PerformClick()
        ElseIf e.KeyCode = Keys.F2 Then
            BG_frm.R_2.PerformClick()
        End If
    End Sub

    Private Sub GSTR1_Ledger_Summary_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
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
    Private Function Button_Manage()
        Button_Clear()
        BG_frm.R_2.Text = "F2 : Date"
        BG_frm.R_3.Text = "|F2 : Period"

        BG_frm.R_4.Text = "&X : CSV Exp."
    End Function
    Private Function Add_Hander_Remove_Handel(Ans As Boolean)
        If Ans = True Then
            AddHandler BG_frm.R_2.Click, AddressOf Me.R_2_Click
            AddHandler BG_frm.R_3.Click, AddressOf Me.R_3_Click
            AddHandler BG_frm.R_4.Click, AddressOf Me.R_4_Click
        Else
            RemoveHandler BG_frm.R_2.Click, AddressOf Me.R_2_Click
            RemoveHandler BG_frm.R_3.Click, AddressOf Me.R_3_Click
            RemoveHandler BG_frm.R_4.Click, AddressOf Me.R_4_Click
        End If
    End Function
    Private Sub R_2_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Set_Date(False, Me)
        End If
    End Sub
    Dim Export_Location As String
    Private Sub R_4_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Dim count_ As Integer = 1
            Dim cn As New SQLiteConnection
            If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                cmd = New SQLiteCommand($"Select SUM(C) as C From (
Select count(*) as C From TBL_VC_item_Details vi
LEFT JOIN TBL_VC vc on vc.Tra_ID = vi.Tra_ID
LEFT JOIN TBL_VC_Other vo on vo.Tra_ID = vi.Tra_ID 
where vc.Type = 'Head' and vc.Visible = 'Approval'  and vc.Voucher_Type = 'Sales' and (vc.Date BETWEEN '{CDate(Frm_date).ToString(Lite_date_Format)}' and '{CDate(to_date).AddDays(1).ToString(Lite_date_Format)}')
Group By vc.Voucher_No, vi.GST_per)", cn)
                Dim r As SQLiteDataReader
                r = cmd.ExecuteReader
                While r.Read
                    count_ = Val(r("C").ToString)
                End While
                r.Close()
            End If
            cn.Close()




            Dim SaveFileDialog1 As New SaveFileDialog
            With SaveFileDialog1
                .FileName = Label3.Text
                .Title = "Export csv"
                If .ShowDialog = True Then
                    Export_Location = .FileName
                    Export_CSV_Background.RunWorkerAsync()
                Else
                End If
            End With

        End If
    End Sub
    Private Sub R_3_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Set_Date(True, Me)
        End If
    End Sub
    Public Function Apply_Date_Filter(ifPeriod As Boolean)
        If ifPeriod = True Then
            Frm_Date_LB.Text = Date_Formate(Date_1)
            To_Date_LB.Text = Date_Formate(Date_2)
        Else
            Frm_Date_LB.Text = Date_Formate(Date_3)
            To_Date_LB.Text = Date_Formate(Date_3)
        End If
        Fill_Grid()
    End Function
    Private Sub nillPanel_Paint(sender As Object, e As PaintEventArgs) Handles nillrate_Panel.Paint
        Dim ctlpos As Point = Label24.PointToScreen(Label24.DisplayRectangle.Location)
        BN1.Location = New Point(ctlpos.X, 0)
        BN1.Height = sender.Height

        ctlpos = Label25.PointToScreen(Label25.DisplayRectangle.Location)
        BN2.Location = New Point(ctlpos.X, 0)
        BN2.Height = sender.Height

        ctlpos = Label26.PointToScreen(Label26.DisplayRectangle.Location)
        BN3.Location = New Point(ctlpos.X, 0)
        BN3.Height = sender.Height

    End Sub
    Private Sub pANEL1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        Dim ctlpos As Point = H1.PointToScreen(H1.DisplayRectangle.Location)
        B1.Location = New Point(ctlpos.X, 0)
        B1.Height = Panel1.Height

        ctlpos = H2.PointToScreen(H2.DisplayRectangle.Location)
        B2.Location = New Point(ctlpos.X, 0)
        B2.Height = Panel1.Height

        ctlpos = H3.PointToScreen(H3.DisplayRectangle.Location)
        B3.Location = New Point(ctlpos.X, 0)
        B3.Height = Panel1.Height

        ctlpos = H4.PointToScreen(H4.DisplayRectangle.Location)
        B4.Location = New Point(ctlpos.X, 0)
        B4.Height = Panel1.Height

        ctlpos = H5.PointToScreen(H5.DisplayRectangle.Location)
        B10.Location = New Point(ctlpos.X, 0)
        B10.Height = Panel1.Height

        ctlpos = H6.PointToScreen(H6.DisplayRectangle.Location)
        B5.Location = New Point(ctlpos.X, 0)
        B5.Height = Panel1.Height

        ctlpos = H7.PointToScreen(H7.DisplayRectangle.Location)
        B6.Location = New Point(ctlpos.X, 0)
        B6.Height = Panel1.Height

        ctlpos = H8.PointToScreen(H8.DisplayRectangle.Location)
        B7.Location = New Point(ctlpos.X, 0)
        B7.Height = Panel1.Height

        ctlpos = H9.PointToScreen(H9.DisplayRectangle.Location)
        B8.Location = New Point(ctlpos.X, 0)
        B8.Height = Panel1.Height

        ctlpos = H10.PointToScreen(H10.DisplayRectangle.Location)
        B9.Location = New Point(ctlpos.X, 0)
        B9.Height = Panel1.Height




    End Sub
    Public Function Fill_Grid()
        GSLab.Text = Company_GST_str
        If VC_ID_ = "B2B Invoices - 4A, 4B, 4C, 6B, 6C" Then
            B2B_Calculation()
            Panel_Manag(Panel1)
        ElseIf VC_ID_ = "B2C (Small) Invoices - 7" Or VC_ID_ = "B2C (Large) Invoices - SA, 6B" Then
            B2C_Calculation()
            Panel_Manag(Panel1)
        ElseIf VC_ID_ = "Exports Invoices - 6A" Then
            Exports_Calculation()
            Panel_Manag(Panel1)
        ElseIf VC_ID_ = "Credit Or Debit Notes (Registered) - 9B" Or VC_ID_ = "Credit Or Debit Notes (Unregistered) - 9B" Then
            Credit_Note_Register_Unregister()
            Panel_Manag(Panel1)
        ElseIf VC_ID_ = "Nil Rated Invoices - 8A, 8B, 8C, 8D" Then
            NillRate_Calculation()
            Panel_Manag(nillrate_Panel)
        End If

    End Function
    Private Function NillRate_Calculation()
        Grid2.Rows.Clear()


        Dim GJ_R_Nill As Decimal = 0
        Dim GJ_R_Exem As Decimal = 0
        Dim GJ_R_NONGST As Decimal = 0

        Dim GJ_U_Nill As Decimal = 0
        Dim GJ_U_Exem As Decimal = 0
        Dim GJ_U_NONGST As Decimal = 0

        Dim MR_R_NILL As Decimal = 0
        Dim MR_R_Exem As Decimal = 0
        Dim MR_R_NONGST As Decimal = 0

        Dim MR_U_NILL As Decimal = 0
        Dim MR_U_Exem As Decimal = 0
        Dim MR_U_NONGST As Decimal = 0


        Grid1.Rows.Clear()

        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select vo.To_State,vo.To_GST_Type,it.TAX_Type,vi.Amount,vo.To_Country
From TBL_VC_item_Details vi
LEFT JOIN TBL_VC vc on VC.Tra_ID = vi.Tra_ID
LEFT JOIN TBL_Stock_Item it on it.ID = vi.Item
LEFT JOIN TBL_Voucher_Create v on v.ID = vc.Voucher_Type_ID
LEFT JOIN TBL_VC_Other vo on vo.Tra_ID = vc.Tra_ID
where vc.Visible = 'Approval' and vc.Voucher_Type = 'Sales' and vc.Type = 'Head' and it.GST_Applicable = 'Applicable' and it.Tax_Value = '0' and v.YN_GST = 'Yes' and (vc.Date BETWEEN '{CDate(Frm_date).ToString(Lite_date_Format)}' and '{CDate(to_date).AddDays(1).ToString(Lite_date_Format)}')
", cn)
            Dim r As SQLiteDataReader = cmd.ExecuteReader
            While r.Read

                If r("To_Country").ToString.ToLower = "india" Then
                    If r("TAX_Type").ToString = "Nil Rated" Then
                        If r("To_GST_Type").ToString = "Regular" Then
                            If r("To_State").ToString.ToLower = Company_State_str.ToLower Then
                                GJ_R_Nill += Val(r("Amount").ToString)
                            Else
                                MR_R_NILL += Val(r("Amount").ToString)
                            End If
                        Else
                            If r("To_State").ToString.ToLower = Company_State_str.ToLower Then
                                GJ_U_Nill += Val(r("Amount").ToString)
                            Else
                                MR_U_NILL += Val(r("Amount").ToString)
                            End If
                        End If
                    ElseIf r("TAX_Type").ToString = "Exempt" Then
                        If r("To_GST_Type").ToString = "Regular" Then
                            If r("To_State").ToString.ToLower = Company_State_str.ToLower Then
                                GJ_R_Exem += Val(r("Amount").ToString)
                            Else
                                MR_R_Exem += Val(r("Amount").ToString)
                            End If
                        Else
                            If r("To_State").ToString.ToLower = Company_State_str.ToLower Then
                                GJ_U_Exem += Val(r("Amount").ToString)
                            Else
                                MR_U_Exem += Val(r("Amount").ToString)
                            End If
                        End If
                    Else
                        If r("To_GST_Type").ToString = "Regular" Then
                            If r("To_State").ToString.ToLower = Company_State_str.ToLower Then
                                GJ_R_NONGST += Val(r("Amount").ToString)
                            Else
                                MR_R_NONGST += Val(r("Amount").ToString)
                            End If
                        Else
                            If r("To_State").ToString.ToLower = Company_State_str.ToLower Then
                                GJ_U_NONGST += Val(r("Amount").ToString)
                            Else
                                MR_U_NONGST += Val(r("Amount").ToString)
                            End If
                        End If
                    End If
                End If
            End While
        End If


        Grid2.Rows.Add("Interstate supplies to registered person", N2_FORMATE(MR_R_NILL), N2_FORMATE(MR_R_Exem), N2_FORMATE(MR_R_NONGST))
        Grid2.Rows.Add("Interstate supplies to unregistered person", N2_FORMATE(MR_U_NILL), N2_FORMATE(MR_U_Exem), N2_FORMATE(MR_U_NONGST))
        Grid2.Rows.Add("Intrastate supplies to registered person", N2_FORMATE(GJ_R_Nill), N2_FORMATE(GJ_R_Exem), N2_FORMATE(GJ_R_NONGST))
        Grid2.Rows.Add("Intrastate supplies to unregistered person", N2_FORMATE(GJ_U_Nill), N2_FORMATE(GJ_U_Exem), N2_FORMATE(GJ_U_NONGST))


        Label33.Text = Val(GJ_R_Nill) + Val(GJ_U_Nill) + Val(MR_U_NILL) + Val(MR_R_NILL)
        Label35.Text = Val(GJ_R_Exem) + Val(GJ_U_Exem) + Val(MR_U_Exem) + Val(MR_R_Exem)
        Label36.Text = Val(GJ_R_NONGST) + Val(GJ_U_NONGST) + Val(MR_U_NONGST) + Val(MR_R_NONGST)


    End Function
    Private Function Exports_Calculation()
        Dim Ledger_ID As String = ""
        Dim Ledger_Name As String = ""
        Dim GSTNo As String = ""

        Dim Vch_total As String = ""
        Dim Taxable As String = ""
        Dim IGST As String = ""
        Dim CGST As String = ""
        Dim SGST As String = ""
        Dim Cess As String = ""
        Dim TAX_Amt As String = ""
        Dim Ivc_Amt As String = ""


        Dim Vch_total_Total As Decimal = 0
        Dim Taxable_Total As Decimal = 0
        Dim IGST_Total As Decimal = 0
        Dim CGST_Total As Decimal = 0
        Dim SGST_Total As Decimal = 0
        Dim Cess_Total As Decimal = 0
        Dim TAX_Amt_Total As Decimal = 0
        Dim Ivc_Amt_Total As Decimal = 0


        Grid1.Rows.Clear()

        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select Tra_I,Amount,IGST,CGST,SGST,GST_Type,Voucher_Type,Ledger_ID,Ledger_Name,GST,Country,ifnull(SUM(vc.Debit_Amount),0) as Dr,ifnull(SUM(vc.Credit_Amount),0) as Cr From (
Select vi.Tra_ID as Tra_I,
SUM(vi.Amount) as Amount,
SUM(vi.IGST) as IGST,
SUM(vi.CGST) as CGST,
SUM(vi.SGST) as SGST,
vo.To_GST_Type as GST_Type,
vc.Ledger as Ledger_ID,
(Select ld.name From TBL_Ledger ld where ld.ID = vc.Ledger) as Ledger_Name,
(Select ld.GSTNo From TBL_Ledger ld where ld.ID = vc.Ledger) as GST,
(Select ld.Country From TBL_Ledger ld where ld.ID = vc.Ledger) as Country
From TBL_VC_item_Details vi
LEFT JOIN TBL_VC vc on vc.Tra_ID = vi.Tra_ID
LEFT JOIN TBL_VC_Other vo on vo.Tra_ID = vi.Tra_ID 
WHERE  vc.Type = 'Head' and vc.Visible = 'Approval' and vc.Voucher_Type = 'Sales' and vo.To_GST_Type = 'Regular' and (vc.Date BETWEEN '{CDate(Frm_date).ToString(Lite_date_Format)}' and '{CDate(to_date).AddDays(1).ToString(Lite_date_Format)}')
Group By vi.Tra_ID)
LEFT JOIN TBL_VC vc on vc.Tra_ID = Tra_I
Group By vc.Tra_ID
Order By Ledger_ID", cn)
            Dim r As SQLiteDataReader = cmd.ExecuteReader


            While r.Read
                Dim to_gst As Decimal = Val(Val(r("IGST").ToString) + Val(r("CGST").ToString) + Val(r("SGST").ToString))



                If r("Country").ToString.ToLower <> "india" Or r("Country").ToString.Trim = Nothing Then
                    If Ledger_ID = r("Ledger_ID").ToString Or Ledger_ID = "" Then
                    Else
                        Grid1.Rows.Add(Ledger_Name, GSTNo, Vch_total,
N2_FORMATE(Taxable),
N2_FORMATE(IGST), N2_FORMATE(CGST), N2_FORMATE(SGST),
N2_FORMATE(Cess),
N2_FORMATE(TAX_Amt),
N2_FORMATE(Ivc_Amt)
)

                        Vch_total_Total += Val(Vch_total)
                        Taxable_Total += Val(Taxable)
                        IGST_Total += Val(IGST)
                        SGST_Total += Val(SGST)
                        CGST_Total += Val(CGST)
                        TAX_Amt_Total += Val(TAX_Amt)
                        Ivc_Amt_Total += Val(Ivc_Amt)


                        Vch_total = 0
                        Taxable = 0
                        IGST = 0
                        SGST = 0
                        CGST = 0
                        TAX_Amt = 0
                        Ivc_Amt = 0

                        Ledger_ID = r("Ledger_ID").ToString
                        Ledger_Name = r("Ledger_Name").ToString
                        GSTNo = r("GST").ToString
                    End If



                    Vch_total = Val(Vch_total) + 1
                    Taxable = Val(Taxable) + Val(r("Amount").ToString)
                    IGST = Val(IGST) + Val(r("IGST").ToString)
                    SGST = Val(SGST) + Val(r("SGST").ToString)
                    CGST = Val(CGST) + Val(r("CGST").ToString)
                    TAX_Amt = Val(TAX_Amt) + Val(Val(r("IGST").ToString) + Val(r("SGST").ToString) + Val(r("CGST").ToString))
                    Ivc_Amt = Val(Ivc_Amt) + Val(r("Dr"))

                    Ledger_ID = r("Ledger_ID").ToString
                    Ledger_Name = r("Ledger_Name").ToString
                    GSTNo = r("GST").ToString
                End If
            End While

            Grid1.Rows.Add(Ledger_Name, GSTNo, Vch_total,
N2_FORMATE(Taxable),
N2_FORMATE(IGST), N2_FORMATE(CGST), N2_FORMATE(SGST),
N2_FORMATE(Cess),
N2_FORMATE(TAX_Amt),
N2_FORMATE(Ivc_Amt)
)

            Vch_total_Total += Val(Vch_total)
            Taxable_Total += Val(Taxable)
            IGST_Total += Val(IGST)
            SGST_Total += Val(SGST)
            CGST_Total += Val(CGST)
            TAX_Amt_Total += Val(TAX_Amt)
            Ivc_Amt_Total += Val(Ivc_Amt)

            Label16.Text = N2_FORMATE(Ivc_Amt_Total)
            Label15.Text = N2_FORMATE(TAX_Amt_Total)
            Label14.Text = ""
            Label12.Text = N2_FORMATE(SGST_Total)
            Label11.Text = N2_FORMATE(CGST_Total)
            Label10.Text = N2_FORMATE(IGST_Total)
            Label9.Text = N2_FORMATE(Taxable_Total)
            Label8.Text = N2_FORMATE(Vch_total_Total)

        End If
    End Function
    Private Function Credit_Note_Register_Unregister()
        Dim isregister As Boolean

        If VC_ID_ = "Credit Or Debit Notes (Registered) - 9B" Then
            isregister = True
        Else
            isregister = False
        End If


        Dim Ledger_ID As String = ""
        Dim Ledger_Name As String = ""
        Dim GSTNo As String = ""

        Dim Vch_total As String = ""
        Dim Taxable As String = ""
        Dim IGST As String = ""
        Dim CGST As String = ""
        Dim SGST As String = ""
        Dim Cess As String = ""
        Dim TAX_Amt As String = ""
        Dim Ivc_Amt As String = ""


        Dim Vch_total_Total As Decimal = 0
        Dim Taxable_Total As Decimal = 0
        Dim IGST_Total As Decimal = 0
        Dim CGST_Total As Decimal = 0
        Dim SGST_Total As Decimal = 0
        Dim Cess_Total As Decimal = 0
        Dim TAX_Amt_Total As Decimal = 0
        Dim Ivc_Amt_Total As Decimal = 0


        Grid1.Rows.Clear()

        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select Tra_I,Amount,IGST,CGST,SGST,GST_Type,To_State,Voucher_Type,Ledger_ID,Ledger_Name,GST,Country,ifnull(SUM(vc.Debit_Amount),0) as Dr,ifnull(SUM(vc.Credit_Amount),0) as Cr From (
Select vi.Tra_ID as Tra_I,
SUM(vi.Amount) as Amount,
SUM(vi.IGST) as IGST,
SUM(vi.CGST) as CGST,
SUM(vi.SGST) as SGST,
vo.To_GST_Type as GST_Type,
vo.To_State as To_State,
vc.Ledger as Ledger_ID,
(Select ld.name From TBL_Ledger ld where ld.ID = vc.Ledger) as Ledger_Name,
(Select ld.GSTNo From TBL_Ledger ld where ld.ID = vc.Ledger) as GST,
(Select ld.Country From TBL_Ledger ld where ld.ID = vc.Ledger) as Country
From TBL_VC_item_Details vi
LEFT JOIN TBL_VC vc on vc.Tra_ID = vi.Tra_ID
LEFT JOIN TBL_VC_Other vo on vo.Tra_ID = vi.Tra_ID 
WHERE  vc.Type = 'Head' and vc.Visible = 'Approval' and (vc.Voucher_Type = 'Credit Note' or vc.Voucher_Type = 'Debit Note') and (vc.Date BETWEEN '{CDate(Frm_date).ToString(Lite_date_Format)}' and '{CDate(to_date).AddDays(1).ToString(Lite_date_Format)}')
Group By vi.Tra_ID)
LEFT JOIN TBL_VC vc on vc.Tra_ID = Tra_I
Group By vc.Tra_ID
Order By Ledger_ID", cn)
            Dim r As SQLiteDataReader = cmd.ExecuteReader


            While r.Read
                Dim to_gst As Decimal = Val(Val(r("IGST").ToString) + Val(r("CGST").ToString) + Val(r("SGST").ToString))
                Dim Vc_type As String = r("Voucher_Type").ToString.ToLower

                Dim nagitive_vlu As Decimal = 0
                If Vc_type = "credit note" Then
                    nagitive_vlu = -1
                Else
                    nagitive_vlu = 1
                End If

                If State_Filter(r("To_State").ToString) = True Then
                    If isregister = True Then
                        If r("GST_Type").ToString.ToLower = "regular" Then
                            If Ledger_ID = r("Ledger_ID").ToString Or Ledger_ID = "" Then
                            Else
                                Grid1.Rows.Add(Ledger_Name, GSTNo, Vch_total,
        N2_FORMATE(Taxable),
        N2_FORMATE(IGST), N2_FORMATE(CGST), N2_FORMATE(SGST),
        N2_FORMATE(Cess),
        N2_FORMATE(TAX_Amt),
        N2_FORMATE(Ivc_Amt)
        )

                                Vch_total_Total += Val(Vch_total)
                                Taxable_Total += Val(Taxable)
                                IGST_Total += Val(IGST)
                                SGST_Total += Val(SGST)
                                CGST_Total += Val(CGST)
                                TAX_Amt_Total += Val(TAX_Amt)
                                Ivc_Amt_Total += Val(Ivc_Amt)


                                Vch_total = 0
                                Taxable = 0
                                IGST = 0
                                SGST = 0
                                CGST = 0
                                TAX_Amt = 0
                                Ivc_Amt = 0

                                Ledger_ID = r("Ledger_ID").ToString
                                Ledger_Name = r("Ledger_Name").ToString
                                GSTNo = r("GST").ToString
                            End If



                            Vch_total = Val(Vch_total) + 1
                            Taxable = Val(Taxable) + (Val(r("Amount").ToString) * nagitive_vlu)
                            IGST = Val(IGST) + (Val(r("IGST").ToString) * nagitive_vlu)
                            SGST = Val(SGST) + (Val(r("SGST").ToString) * nagitive_vlu)
                            CGST = Val(CGST) + (Val(r("CGST").ToString) * nagitive_vlu)
                            TAX_Amt = Val(TAX_Amt) + (Val(Val(r("IGST").ToString) + Val(r("SGST").ToString) + Val(r("CGST").ToString)) * nagitive_vlu)

                            If Vc_type = "credit note" Then
                                Ivc_Amt = Val(Ivc_Amt) + (Val(r("Dr")) * nagitive_vlu)
                            Else
                                Ivc_Amt = Val(Ivc_Amt) + (Val(r("Cr")) * nagitive_vlu)
                            End If



                            Ledger_ID = r("Ledger_ID").ToString
                            Ledger_Name = r("Ledger_Name").ToString
                            GSTNo = r("GST").ToString
                        End If
                    Else
                        If r("GST_Type").ToString.ToLower <> "regular" Then
                            If Ledger_ID = r("Ledger_ID").ToString Or Ledger_ID = "" Then
                            Else
                                Grid1.Rows.Add(Ledger_Name, GSTNo, Vch_total,
        N2_FORMATE(Taxable),
        N2_FORMATE(IGST), N2_FORMATE(CGST), N2_FORMATE(SGST),
        N2_FORMATE(Cess),
        N2_FORMATE(TAX_Amt),
        N2_FORMATE(Ivc_Amt)
        )

                                Vch_total_Total += Val(Vch_total)
                                Taxable_Total += Val(Taxable)
                                IGST_Total += Val(IGST)
                                SGST_Total += Val(SGST)
                                CGST_Total += Val(CGST)
                                TAX_Amt_Total += Val(TAX_Amt)
                                Ivc_Amt_Total += Val(Ivc_Amt)



                                Vch_total = 0
                                Taxable = 0
                                IGST = 0
                                SGST = 0
                                CGST = 0
                                TAX_Amt = 0
                                Ivc_Amt = 0

                                Ledger_ID = r("Ledger_ID").ToString
                                Ledger_Name = r("Ledger_Name").ToString
                                GSTNo = r("GST").ToString
                            End If



                            Vch_total = Val(Vch_total) + 1
                            Taxable = Val(Taxable) + (Val(r("Amount").ToString) * nagitive_vlu)
                            IGST = Val(IGST) + (Val(r("IGST").ToString) * nagitive_vlu)
                            SGST = Val(SGST) + (Val(r("SGST").ToString) * nagitive_vlu)
                            CGST = Val(CGST) + (Val(r("CGST").ToString) * nagitive_vlu)
                            TAX_Amt = Val(TAX_Amt) + (Val(Val(r("IGST").ToString) + Val(r("SGST").ToString) + Val(r("CGST").ToString)) * nagitive_vlu)

                            If Vc_type = "credit note" Then
                                Ivc_Amt = Val(Ivc_Amt) + (Val(r("Dr")) * nagitive_vlu)
                            Else
                                Ivc_Amt = Val(Ivc_Amt) + (Val(r("Cr")) * nagitive_vlu)
                            End If



                            Ledger_ID = r("Ledger_ID").ToString
                            Ledger_Name = r("Ledger_Name").ToString
                            GSTNo = r("GST").ToString
                        End If
                    End If
                End If
            End While

            Grid1.Rows.Add(Ledger_Name, GSTNo, Vch_total,
N2_FORMATE(Taxable),
N2_FORMATE(IGST), N2_FORMATE(CGST), N2_FORMATE(SGST),
N2_FORMATE(Cess),
N2_FORMATE(TAX_Amt),
N2_FORMATE(Ivc_Amt)
)


            Vch_total_Total += Val(Vch_total)
            Taxable_Total += Val(Taxable)
            IGST_Total += Val(IGST)
            SGST_Total += Val(SGST)
            CGST_Total += Val(CGST)
            TAX_Amt_Total += Val(TAX_Amt)
            Ivc_Amt_Total += Val(Ivc_Amt)

            Label16.Text = N2_FORMATE(Ivc_Amt_Total)
            Label15.Text = N2_FORMATE(TAX_Amt_Total)
            Label14.Text = ""
            Label12.Text = N2_FORMATE(SGST_Total)
            Label11.Text = N2_FORMATE(CGST_Total)
            Label10.Text = N2_FORMATE(IGST_Total)
            Label9.Text = N2_FORMATE(Taxable_Total)
            Label8.Text = N2_FORMATE(Vch_total_Total)

        End If
    End Function
    Private Function B2C_Calculation()
        Dim isSmall As Boolean

        If VC_ID_ = "B2C (Small) Invoices - 7" Then
            isSmall = True
        Else
            isSmall = False
        End If


        Dim Ledger_ID As String = ""
        Dim Ledger_Name As String = ""
        Dim GSTNo As String = ""

        Dim Vch_total As String = ""
        Dim Taxable As String = ""
        Dim IGST As String = ""
        Dim CGST As String = ""
        Dim SGST As String = ""
        Dim Cess As String = ""
        Dim TAX_Amt As String = ""
        Dim Ivc_Amt As String = ""


        Dim Vch_total_Total As Decimal = 0
        Dim Taxable_Total As Decimal = 0
        Dim IGST_Total As Decimal = 0
        Dim CGST_Total As Decimal = 0
        Dim SGST_Total As Decimal = 0
        Dim Cess_Total As Decimal = 0
        Dim TAX_Amt_Total As Decimal = 0
        Dim Ivc_Amt_Total As Decimal = 0


        Grid1.Rows.Clear()

        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select Tra_I,Amount,IGST,CGST,SGST,GST_Type,To_State ,Voucher_Type,Ledger_ID,Ledger_Name,GST,Country,ifnull(SUM(vc.Debit_Amount),0) as Dr,ifnull(SUM(vc.Credit_Amount),0) as Cr From (
Select vi.Tra_ID as Tra_I,
SUM(vi.Amount) as Amount,
SUM(vi.IGST) as IGST,
SUM(vi.CGST) as CGST,
SUM(vi.SGST) as SGST,
vo.To_GST_Type as GST_Type,
vo.To_State as To_State,
vc.Ledger as Ledger_ID,
(Select ld.name From TBL_Ledger ld where ld.ID = vc.Ledger) as Ledger_Name,
(Select ld.GSTNo From TBL_Ledger ld where ld.ID = vc.Ledger) as GST,
(Select ld.Country From TBL_Ledger ld where ld.ID = vc.Ledger) as Country
From TBL_VC_item_Details vi
LEFT JOIN TBL_VC vc on vc.Tra_ID = vi.Tra_ID
LEFT JOIN TBL_VC_Other vo on vo.Tra_ID = vi.Tra_ID 
WHERE  vc.Type = 'Head' and vc.Visible = 'Approval'  and vc.Voucher_Type = 'Sales' and vo.To_GST_Type = 'Consumer' and (vc.Date BETWEEN '{CDate(Frm_date).ToString(Lite_date_Format)}' and '{CDate(to_date).AddDays(1).ToString(Lite_date_Format)}')
Group By vi.Tra_ID)
LEFT JOIN TBL_VC vc on vc.Tra_ID = Tra_I
Group By vc.Tra_ID
Order By Ledger_ID", cn)
            Dim r As SQLiteDataReader = cmd.ExecuteReader


            While r.Read
                Dim to_gst As Decimal = Val(Val(r("IGST").ToString) + Val(r("CGST").ToString) + Val(r("SGST").ToString))
                Dim AMT As Decimal = Val(r("Dr"))

                If State_Filter(r("To_State").ToString) = True Then
                    If Val(to_gst) <> 0 Then
                        If isSmall = True Then
                            If AMT <= 250000 Then
                                If r("Country").ToString.ToLower = "india" Then
                                    If Ledger_ID = r("Ledger_ID").ToString Or Ledger_ID = "" Then
                                    Else
                                        Grid1.Rows.Add(Ledger_Name, GSTNo, Vch_total,
            N2_FORMATE(Taxable),
            N2_FORMATE(IGST), N2_FORMATE(CGST), N2_FORMATE(SGST),
            N2_FORMATE(Cess),
            N2_FORMATE(TAX_Amt),
            N2_FORMATE(Ivc_Amt)
            )


                                        Vch_total_Total += Val(Vch_total)
                                        Taxable_Total += Val(Taxable)
                                        IGST_Total += Val(IGST)
                                        SGST_Total += Val(SGST)
                                        CGST_Total += Val(CGST)
                                        TAX_Amt_Total += Val(TAX_Amt)
                                        Ivc_Amt_Total += Val(Ivc_Amt)



                                        Vch_total = 0
                                        Taxable = 0
                                        IGST = 0
                                        SGST = 0
                                        CGST = 0
                                        TAX_Amt = 0
                                        Ivc_Amt = 0

                                        Ledger_ID = r("Ledger_ID").ToString
                                        Ledger_Name = r("Ledger_Name").ToString
                                        GSTNo = r("GST").ToString
                                    End If



                                    Vch_total = Val(Vch_total) + 1
                                    Taxable = Val(Taxable) + Val(r("Amount").ToString)
                                    IGST = Val(IGST) + Val(r("IGST").ToString)
                                    SGST = Val(SGST) + Val(r("SGST").ToString)
                                    CGST = Val(CGST) + Val(r("CGST").ToString)
                                    TAX_Amt = Val(TAX_Amt) + Val(Val(r("IGST").ToString) + Val(r("SGST").ToString) + Val(r("CGST").ToString))
                                    Ivc_Amt = Val(Ivc_Amt) + Val(r("Dr"))

                                    Ledger_ID = r("Ledger_ID").ToString
                                    Ledger_Name = r("Ledger_Name").ToString
                                    GSTNo = r("GST").ToString
                                End If
                            End If
                        Else
                            If AMT > 250000 Then
                                If r("Country").ToString.ToLower = "india" Then
                                    If Ledger_ID = r("Ledger_ID").ToString Or Ledger_ID = "" Then
                                    Else
                                        Grid1.Rows.Add(Ledger_Name, GSTNo, Vch_total,
            N2_FORMATE(Taxable),
            N2_FORMATE(IGST), N2_FORMATE(CGST), N2_FORMATE(SGST),
            N2_FORMATE(Cess),
            N2_FORMATE(TAX_Amt),
            N2_FORMATE(Ivc_Amt)
            )

                                        Vch_total_Total += Val(Vch_total)
                                        Taxable_Total += Val(Taxable)
                                        IGST_Total += Val(IGST)
                                        SGST_Total += Val(SGST)
                                        CGST_Total += Val(CGST)
                                        TAX_Amt_Total += Val(TAX_Amt)
                                        Ivc_Amt_Total += Val(Ivc_Amt)


                                        Vch_total = 0
                                        Taxable = 0
                                        IGST = 0
                                        SGST = 0
                                        CGST = 0
                                        TAX_Amt = 0
                                        Ivc_Amt = 0

                                        Ledger_ID = r("Ledger_ID").ToString
                                        Ledger_Name = r("Ledger_Name").ToString
                                        GSTNo = r("GST").ToString
                                    End If



                                    Vch_total = Val(Vch_total) + 1
                                    Taxable = Val(Taxable) + Val(r("Amount").ToString)
                                    IGST = Val(IGST) + Val(r("IGST").ToString)
                                    SGST = Val(SGST) + Val(r("SGST").ToString)
                                    CGST = Val(CGST) + Val(r("CGST").ToString)
                                    TAX_Amt = Val(TAX_Amt) + Val(Val(r("IGST").ToString) + Val(r("SGST").ToString) + Val(r("CGST").ToString))
                                    Ivc_Amt = Val(Ivc_Amt) + Val(r("Dr"))

                                    Ledger_ID = r("Ledger_ID").ToString
                                    Ledger_Name = r("Ledger_Name").ToString
                                    GSTNo = r("GST").ToString
                                End If
                            End If
                        End If
                    End If
                End If

            End While

            Grid1.Rows.Add(Ledger_Name, GSTNo, Vch_total,
N2_FORMATE(Taxable),
N2_FORMATE(IGST), N2_FORMATE(CGST), N2_FORMATE(SGST),
N2_FORMATE(Cess),
N2_FORMATE(TAX_Amt),
N2_FORMATE(Ivc_Amt)
)

            Vch_total_Total += Val(Vch_total)
            Taxable_Total += Val(Taxable)
            IGST_Total += Val(IGST)
            SGST_Total += Val(SGST)
            CGST_Total += Val(CGST)
            TAX_Amt_Total += Val(TAX_Amt)
            Ivc_Amt_Total += Val(Ivc_Amt)


            Label16.Text = N2_FORMATE(Ivc_Amt_Total)
            Label15.Text = N2_FORMATE(TAX_Amt_Total)
            Label14.Text = ""
            Label12.Text = N2_FORMATE(SGST_Total)
            Label11.Text = N2_FORMATE(CGST_Total)
            Label10.Text = N2_FORMATE(IGST_Total)
            Label9.Text = N2_FORMATE(Taxable_Total)
            Label8.Text = N2_FORMATE(Vch_total_Total)

        End If
    End Function
    Private Function B2B_Calculation()
        Dim Ledger_ID As String = ""
        Dim Ledger_Name As String = ""
        Dim GSTNo As String = ""

        Dim Vch_total As String = ""
        Dim Taxable As String = ""
        Dim IGST As String = ""
        Dim CGST As String = ""
        Dim SGST As String = ""
        Dim Cess As String = ""
        Dim TAX_Amt As String = ""
        Dim Ivc_Amt As String = ""

        Dim Vch_total_Total As Decimal = 0
        Dim Taxable_Total As Decimal = 0
        Dim IGST_Total As Decimal = 0
        Dim CGST_Total As Decimal = 0
        Dim SGST_Total As Decimal = 0
        Dim Cess_Total As Decimal = 0
        Dim TAX_Amt_Total As Decimal = 0
        Dim Ivc_Amt_Total As Decimal = 0




        Grid1.Rows.Clear()

        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select Tra_I,Amount,IGST,CGST,SGST,GST_Type,To_State,Voucher_Type,Ledger_ID,Ledger_Name,GST,Country,ifnull(SUM(vc.Debit_Amount),0) as Dr,ifnull(SUM(vc.Credit_Amount),0) as Cr From (
Select vi.Tra_ID as Tra_I,
SUM(vi.Amount) as Amount,
SUM(vi.IGST) as IGST,
SUM(vi.CGST) as CGST,
SUM(vi.SGST) as SGST,
vo.To_GST_Type as GST_Type,
vc.Ledger as Ledger_ID,
vo.To_State as To_State,
(Select ld.name From TBL_Ledger ld where ld.ID = vc.Ledger) as Ledger_Name,
(Select ld.GSTNo From TBL_Ledger ld where ld.ID = vc.Ledger) as GST,
(Select ld.Country From TBL_Ledger ld where ld.ID = vc.Ledger) as Country
From TBL_VC_item_Details vi
LEFT JOIN TBL_VC vc on vc.Tra_ID = vi.Tra_ID
LEFT JOIN TBL_VC_Other vo on vo.Tra_ID = vi.Tra_ID 
WHERE  vc.Type = 'Head' and vc.Visible = 'Approval'  and vc.Voucher_Type = 'Sales' and vo.To_GST_Type = 'Regular' and (vc.Date BETWEEN '{CDate(Frm_date).ToString(Lite_date_Format)}' and '{CDate(to_date).AddDays(1).ToString(Lite_date_Format)}')
Group By vi.Tra_ID)
LEFT JOIN TBL_VC vc on vc.Tra_ID = Tra_I
Group By vc.Tra_ID
Order By Ledger_ID", cn)
            Dim r As SQLiteDataReader = cmd.ExecuteReader


            While r.Read
                Dim to_gst As Decimal = Val(Val(r("IGST").ToString) + Val(r("CGST").ToString) + Val(r("SGST").ToString))


                If Val(to_gst) <> 0 Then
                    If r("Country").ToString.ToLower = "india" Then
                        If State_Filter(r("To_State")) = True Then
                            If Ledger_ID = r("Ledger_ID").ToString Or Ledger_ID = "" Then
                            Else
                                Grid1.Rows.Add(Ledger_Name, GSTNo, Vch_total,
    N2_FORMATE(Taxable),
    N2_FORMATE(IGST), N2_FORMATE(CGST), N2_FORMATE(SGST),
    N2_FORMATE(Cess),
    N2_FORMATE(TAX_Amt),
    N2_FORMATE(Ivc_Amt)
    )

                                Vch_total_Total += Val(Vch_total)
                                Taxable_Total += Val(Taxable)
                                IGST_Total += Val(IGST)
                                SGST_Total += Val(SGST)
                                CGST_Total += Val(CGST)
                                TAX_Amt_Total += Val(TAX_Amt)
                                Ivc_Amt_Total += Val(Ivc_Amt)



                                Vch_total = 0
                                Taxable = 0
                                IGST = 0
                                SGST = 0
                                CGST = 0
                                TAX_Amt = 0
                                Ivc_Amt = 0

                                Ledger_ID = r("Ledger_ID").ToString
                                Ledger_Name = r("Ledger_Name").ToString
                                GSTNo = r("GST").ToString
                            End If



                            Vch_total = Val(Vch_total) + 1
                            Taxable = Val(Taxable) + Val(r("Amount").ToString)
                            IGST = Val(IGST) + Val(r("IGST").ToString)
                            SGST = Val(SGST) + Val(r("SGST").ToString)
                            CGST = Val(CGST) + Val(r("CGST").ToString)
                            TAX_Amt = Val(TAX_Amt) + Val(Val(r("IGST").ToString) + Val(r("SGST").ToString) + Val(r("CGST").ToString))
                            Ivc_Amt = Val(Ivc_Amt) + Val(r("Dr"))



                            Ledger_ID = r("Ledger_ID").ToString
                            Ledger_Name = r("Ledger_Name").ToString
                            GSTNo = r("GST").ToString
                        End If
                    End If
                End If
            End While

            Grid1.Rows.Add(Ledger_Name, GSTNo, Vch_total,
N2_FORMATE(Taxable),
N2_FORMATE(IGST), N2_FORMATE(CGST), N2_FORMATE(SGST),
N2_FORMATE(Cess),
N2_FORMATE(TAX_Amt),
N2_FORMATE(Ivc_Amt)
)

            Vch_total_Total += Val(Vch_total)
            Taxable_Total += Val(Taxable)
            IGST_Total += Val(IGST)
            SGST_Total += Val(SGST)
            CGST_Total += Val(CGST)
            TAX_Amt_Total += Val(TAX_Amt)
            Ivc_Amt_Total += Val(Ivc_Amt)

        End If



        Label16.Text = N2_FORMATE(Ivc_Amt_Total)
        Label15.Text = N2_FORMATE(TAX_Amt_Total)
        Label14.Text = ""
        Label12.Text = N2_FORMATE(SGST_Total)
        Label11.Text = N2_FORMATE(CGST_Total)
        Label10.Text = N2_FORMATE(IGST_Total)
        Label9.Text = N2_FORMATE(Taxable_Total)
        Label8.Text = N2_FORMATE(Vch_total_Total)

    End Function

    Private Function State_Filter(str As String) As Boolean
        If (str.ToString.ToLower = "not applicable") Or (str.ToString.Length <= 2) Then
            Return False
        Else
            Return True
        End If
    End Function
    Private Sub Grid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid1.CellContentClick

    End Sub

    Private Sub Grid1_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim id As String = Find_DT_Value(Database_File.cre, "TBL_Ledger", "ID", $"Name = '{Grid1.CurrentRow.Cells(0).Value.ToString}'")

            Cell("GSTR1 Voucher Register", VC_Type_, Label3.Text, id)
        End If
    End Sub
    Private Function Panel_Manage(pa As Panel)
        BG_Panel.Visible = False
        pa.Visible = True
    End Function
    Private Sub Export_CSV_Background_DoWork(sender As Object, e As DoWorkEventArgs) Handles Export_CSV_Background.DoWork
        If VC_ID_ = "B2B Invoices - 4A, 4B, 4C, 6B, 6C" Then
            B2B_Csv(Frm_date, to_date, False)
        ElseIf VC_ID_ = "B2C (Large) Invoices - SA, 6B" Then
            B2CL_Csv(Frm_date, to_date, False)
        ElseIf VC_ID_ = "B2C (Small) Invoices - 7" Then
            B2CS_Csv(Frm_date, to_date, False)
        ElseIf VC_ID_ = "Credit Or Debit Notes (Registered) - 9B" Then
            Crdr_R_Csv(Frm_date, to_date, False)
        ElseIf VC_ID_ = "Credit Or Debit Notes (Unregistered) - 9B" Then
            Crdr_un_Csv(Frm_date, to_date, False)
        ElseIf VC_ID_ = "Exports Invoices - 6A" Then
            EXPORT_un_Csv(Frm_date, to_date, False)
        ElseIf VC_ID_ = "Nil Rated Invoices - 8A, 8B, 8C, 8D" Then
            NillRate_un_Csv(Frm_date, to_date, False)
        End If




    End Sub

    Public Function NillRate_un_Csv(frm_ As Date, To_ As Date, ifexcel As Boolean) As DataTable
        Dim GJ_R_Nill As Decimal = 0
        Dim GJ_R_Exem As Decimal = 0
        Dim GJ_R_NONGST As Decimal = 0

        Dim GJ_U_Nill As Decimal = 0
        Dim GJ_U_Exem As Decimal = 0
        Dim GJ_U_NONGST As Decimal = 0

        Dim MR_R_NILL As Decimal = 0
        Dim MR_R_Exem As Decimal = 0
        Dim MR_R_NONGST As Decimal = 0

        Dim MR_U_NILL As Decimal = 0
        Dim MR_U_Exem As Decimal = 0
        Dim MR_U_NONGST As Decimal = 0



        dt_export = New DataTable
        dt_export.Columns.Add("Description")
        dt_export.Columns.Add("Nil Rated Supplies")
        dt_export.Columns.Add("Exempted(other than nil rated/non GST supply)")
        dt_export.Columns.Add("Non-GST Supplies")

        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select vo.To_State,vo.To_GST_Type,it.TAX_Type,vi.Amount,vo.To_Country
From TBL_VC_item_Details vi
LEFT JOIN TBL_VC vc on VC.Tra_ID = vi.Tra_ID
LEFT JOIN TBL_Stock_Item it on it.ID = vi.Item
LEFT JOIN TBL_Voucher_Create v on v.ID = vc.Voucher_Type_ID
LEFT JOIN TBL_VC_Other vo on vo.Tra_ID = vc.Tra_ID
where vc.Visible = 'Approval' and vc.Voucher_Type = 'Sales' and vc.Type = 'Head' and it.GST_Applicable = 'Applicable' and it.Tax_Value = '0' and v.YN_GST = 'Yes' and (vc.Date BETWEEN '{CDate(frm_).ToString(Lite_date_Format)}' and '{CDate(To_).AddDays(1).ToString(Lite_date_Format)}')
", cn)


            Dim r As SQLiteDataReader = cmd.ExecuteReader
            While r.Read
                If r("To_Country").ToString.ToLower = "india" Then
                    If r("TAX_Type").ToString = "Nil Rated" Then
                        If r("To_GST_Type").ToString = "Regular" Then
                            If r("To_State").ToString.ToLower = Company_State_str.ToLower Then
                                GJ_R_Nill += Val(r("Amount").ToString)
                            Else
                                MR_R_NILL += Val(r("Amount").ToString)
                            End If
                        Else
                            If r("To_State").ToString.ToLower = Company_State_str.ToLower Then
                                GJ_U_Nill += Val(r("Amount").ToString)
                            Else
                                MR_U_NILL += Val(r("Amount").ToString)
                            End If
                        End If
                    ElseIf r("TAX_Type").ToString = "Exempt" Then
                        If r("To_GST_Type").ToString = "Regular" Then
                            If r("To_State").ToString.ToLower = Company_State_str.ToLower Then
                                GJ_R_Exem += Val(r("Amount").ToString)
                            Else
                                MR_R_Exem += Val(r("Amount").ToString)
                            End If
                        Else
                            If r("To_State").ToString.ToLower = Company_State_str.ToLower Then
                                GJ_U_Exem += Val(r("Amount").ToString)
                            Else
                                MR_U_Exem += Val(r("Amount").ToString)
                            End If
                        End If
                    Else
                        If r("To_GST_Type").ToString = "Regular" Then
                            If r("To_State").ToString.ToLower = Company_State_str.ToLower Then
                                GJ_R_NONGST += Val(r("Amount").ToString)
                            Else
                                MR_R_NONGST += Val(r("Amount").ToString)
                            End If
                        Else
                            If r("To_State").ToString.ToLower = Company_State_str.ToLower Then
                                GJ_U_NONGST += Val(r("Amount").ToString)
                            Else
                                MR_U_NONGST += Val(r("Amount").ToString)
                            End If
                        End If
                    End If
                End If
            End While
        End If

        With Grid2
            dt_export.Rows.Add("Inter-State supplies to registered persons", N2_FORMATE(MR_R_NILL), N2_FORMATE(MR_R_Exem), N2_FORMATE(MR_R_NONGST))
            dt_export.Rows.Add("Inter-State supplies to unregistered persons", N2_FORMATE(MR_U_NILL), N2_FORMATE(MR_U_Exem), N2_FORMATE(MR_U_NONGST))
            dt_export.Rows.Add("Intra-State supplies to registered persons", N2_FORMATE(GJ_R_Nill), N2_FORMATE(GJ_R_Exem), N2_FORMATE(GJ_R_NONGST))
            dt_export.Rows.Add("Intra-State supplies to unregistered persons", N2_FORMATE(GJ_U_Nill), N2_FORMATE(GJ_U_Exem), N2_FORMATE(GJ_U_NONGST))



            'Grid2.Rows.Add("Interstate supplies to registered person", N2_FORMATE(MR_R_NILL), N2_FORMATE(MR_R_Exem), N2_FORMATE(MR_R_NONGST))
            'Grid2.Rows.Add("Interstate supplies to unregistered person", N2_FORMATE(MR_U_NILL), N2_FORMATE(MR_U_Exem), N2_FORMATE(MR_U_NONGST))
            'Grid2.Rows.Add("Intrastate supplies to registered person", N2_FORMATE(GJ_R_Nill), N2_FORMATE(GJ_R_Exem), N2_FORMATE(GJ_R_NONGST))
            'Grid2.Rows.Add("Intrastate supplies to unregistered person", N2_FORMATE(GJ_U_Nill), N2_FORMATE(GJ_U_Exem), N2_FORMATE(GJ_U_NONGST))
        End With

        Return dt_export
    End Function
    Public Function EXPORT_un_Csv(frm_ As Date, To_ As Date, ifexcel As Boolean) As DataTable
        dt_export = New DataTable
        dt_export.Columns.Add("Export Type")
        dt_export.Columns.Add("Invoice Number")
        dt_export.Columns.Add("Invoice date")
        dt_export.Columns.Add("Invoice Value")
        dt_export.Columns.Add("Port Code")
        dt_export.Columns.Add("Shipping Bill Number")
        dt_export.Columns.Add("Shipping Bill Date")
        dt_export.Columns.Add("Rate")

        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select 
SUM(vi.Amount) as Amount,
vc.Voucher_Type as Voucher_Type,
SUM(vi.IGST) as IGST,
SUM(vi.CGST) as CGST,
SUM(vi.SGST) as SGST,
SUM(vi.Cess_Amt) as Cess_Amt,
(vi.GST_per) as GST_per,
vo.To_Country as To_Country,
vo.Port_Code as Port_Code,
vo.Shipping_Bill_No as Shipping_Bill,
vo.Export_Date as Shipping_Date,
vo.Export_LUT as Export_LUT,
vo.To_GST_Type as GST_Type,
vc.Ledger as Ledger_ID,
vc.[Date] as Date_,
vc.Voucher_No as vc_No,
vo.To_State as State,
ifnull(SUM(vc.Credit_Amount),0)+ifnull(SUM(vc.Debit_Amount),0) as ivc_amt,
(Select ld.name From TBL_Ledger ld where ld.ID = vc.Ledger) as Ledger_Name,
vo.To_GST as GST,
(Select ld.Country From TBL_Ledger ld where ld.ID = vc.Ledger) as Country
From TBL_VC_item_Details vi
LEFT JOIN TBL_VC_Other vo on vo.Tra_ID = vi.Tra_ID  
LEFT JOIN TBL_VC vc on vc.Tra_ID = vi.Tra_ID
where vc.Type = 'Head' and vc.Visible = 'Approval' and (vc.Voucher_Type = 'Sales' ) and (vo.To_Country <> 'India') and (vc.Date BETWEEN '{CDate(frm_).ToString(Lite_date_Format)}' and '{CDate(To_).AddDays(1).ToString(Lite_date_Format)}')
Group By vc.Tra_ID, vi.GST_per
Order By vc.Tra_ID", cn)

            Dim r As SQLiteDataReader = cmd.ExecuteReader
            Dim count_ As Integer = 0
            While r.Read
                If r("Shipping_Bill").ToString <> Nothing Then
                    Dim t As String = ""
                    If r("Export_LUT").ToString = Nothing Then
                        t = "WPAY"
                    Else
                        t = "WOPAY"
                    End If


                    dt_export.Rows.Add(t,
                                   (r("vc_no").ToString),
                                   CDate(r("Date_")).ToString("dd-MMM-yy"),
                                   nUmBeR_FORMATE(r("ivc_amt").ToString),
                                   (r("Port_Code").ToString),
                                   (r("Shipping_Bill").ToString),
                                   CDate(r("Shipping_Date")).ToString("dd-MMM-yy"),
                                   "0"
)

                    count_ += 1
                    If ifexcel = False Then
                        Export_CSV_Background.ReportProgress(count_)
                    End If
                End If
            End While

        End If
        Return dt_export
    End Function
    Public Function Crdr_un_Csv(frm_ As Date, To_ As Date, ifexcel As Boolean) As DataTable
        dt_export = New DataTable
        dt_export.Columns.Add("UR Type")
        dt_export.Columns.Add("Note Number")
        dt_export.Columns.Add("Note Date")
        dt_export.Columns.Add("Note Type")
        dt_export.Columns.Add("Place Of Supply")
        dt_export.Columns.Add("Note Value")
        dt_export.Columns.Add("Applicable % of Tax Rate")
        dt_export.Columns.Add("Rate")
        dt_export.Columns.Add("Taxable Value")
        dt_export.Columns.Add("Cess Amount")


        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then

            cmd = New SQLiteCommand($"Select 
SUM(vi.Amount) as Amount,
vc.Voucher_Type as Voucher_Type,
SUM(vi.IGST) as IGST,
SUM(vi.CGST) as CGST,
SUM(vi.SGST) as SGST,
SUM(vi.Cess_Amt) as Cess_Amt,
(vi.GST_per) as GST_per,
vo.To_GST_Type as GST_Type,
vc.Ledger as Ledger_ID,
vc.[Date] as Date_,
vc.Voucher_No as vc_No,
vo.To_State as State,
ifnull(SUM(vc.Credit_Amount),0)+ifnull(SUM(vc.Debit_Amount),0) as ivc_amt,
(Select ld.name From TBL_Ledger ld where ld.ID = vc.Ledger) as Ledger_Name,
vo.To_GST as GST,
(Select ld.Country From TBL_Ledger ld where ld.ID = vc.Ledger) as Country
From TBL_VC_item_Details vi
LEFT JOIN TBL_VC_Other vo on vo.Tra_ID = vi.Tra_ID  
LEFT JOIN TBL_VC vc on vc.Tra_ID = vi.Tra_ID
where vc.Type = 'Head' and vc.Visible = 'Approval' and (vc.Voucher_Type = 'Credit Note' or vc.Voucher_Type = 'Debit Note') and vo.To_GST_Type <> 'Regular' and (vc.Date BETWEEN '{CDate(frm_).ToString(Lite_date_Format)}' and '{CDate(To_).AddDays(1).ToString(Lite_date_Format)}')
Group By vc.Tra_ID, vi.GST_per
Order By vc.Tra_ID", cn)

            Dim r As SQLiteDataReader = cmd.ExecuteReader
            Dim count_ As Integer = 0
            While r.Read
                Dim State_Code As String = Find_DT_Value(Database_File.cfgs, "TBL_State_GSTCode", "StateCode", $"StateName = '{r("State").ToString}' COLLATE NOCASE")
                Dim State_Name As String = Find_DT_Value(Database_File.cfgs, "TBL_State_GSTCode", "StateName", $"StateName = '{r("State").ToString}' COLLATE NOCASE")

                If State_Name.Length <> 0 Then
                    Dim t As String = ""
                    If r("Voucher_Type").ToString = "Credit Note" Then
                        t = "C"
                    ElseIf r("Voucher_Type").ToString = "Debit Note" Then
                        t = "D"
                    End If
                    If State_Filter(r("State").ToString) = True Then
                        dt_export.Rows.Add("B2CL",
                                   r("vc_no").ToString,
                                   CDate(r("Date_")).ToString("dd-MMM-yy"),
                                   t,
                                            ($"{State_Code}-{State_Name}"),
                                           nUmBeR_FORMATE(r("ivc_amt").ToString),
                                           (""),
                                            nUmBeR_FORMATE(r("GST_per").ToString),
                                            nUmBeR_FORMATE(r("Amount").ToString),
                                            nUmBeR_FORMATE(r("Cess_Amt").ToString)
)
                    End If

                    count_ += 1
                    If ifexcel = False Then
                        Export_CSV_Background.ReportProgress(count_)
                    End If
                End If
            End While
        End If
        Return dt_export
    End Function

    Public Function Crdr_R_Csv(frm_ As Date, To_ As Date, ifexcel As Boolean) As DataTable
        dt_export = New DataTable
        dt_export.Columns.Add("GSTIN/UIN of Recipient")
        dt_export.Columns.Add("Receiver Name")
        dt_export.Columns.Add("Note Number")
        dt_export.Columns.Add("Note Date")
        dt_export.Columns.Add("Note Type")
        dt_export.Columns.Add("Place Of Supply")
        dt_export.Columns.Add("Reverse Charge")
        dt_export.Columns.Add("Note Supply Type")
        dt_export.Columns.Add("Note Value")
        dt_export.Columns.Add("Applicable % of Tax Rate")
        dt_export.Columns.Add("Rate")
        dt_export.Columns.Add("Taxable Value")
        dt_export.Columns.Add("Cess Amount")


        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then

            cmd = New SQLiteCommand($"Select 
SUM(vi.Amount) as Amount,
vc.Voucher_Type as Voucher_Type,
SUM(vi.IGST) as IGST,
SUM(vi.CGST) as CGST,
SUM(vi.SGST) as SGST,
SUM(vi.Cess_Amt) as Cess_Amt,
(vi.GST_per) as GST_per,
vo.To_GST_Type as GST_Type,
vc.Ledger as Ledger_ID,
vc.[Date] as Date_,
vc.Voucher_No as vc_No,
vo.To_State as State,
ifnull(SUM(vc.Credit_Amount),0)+ifnull(SUM(vc.Debit_Amount),0) as ivc_amt,
(Select ld.name From TBL_Ledger ld where ld.ID = vc.Ledger) as Ledger_Name,
vo.To_GST as GST,
(Select ld.Country From TBL_Ledger ld where ld.ID = vc.Ledger) as Country
From TBL_VC_item_Details vi
LEFT JOIN TBL_VC_Other vo on vo.Tra_ID = vi.Tra_ID  
LEFT JOIN TBL_VC vc on vc.Tra_ID = vi.Tra_ID
where vc.Type = 'Head' and vc.Visible = 'Approval' and (vc.Voucher_Type = 'Credit Note' or vc.Voucher_Type = 'Debit Note') and vo.To_GST_Type = 'Regular' and (vc.Date BETWEEN '{CDate(frm_).ToString(Lite_date_Format)}' and '{CDate(To_).AddDays(1).ToString(Lite_date_Format)}')
Group By vc.Tra_ID, vi.GST_per
Order By vc.Tra_ID", cn)

            Dim r As SQLiteDataReader = cmd.ExecuteReader
            Dim count_ As Integer = 0
            While r.Read

                If nUmBeR_FORMATE(r("GST_per").ToString) <> 0 Then
                    Dim State_Code As String = Find_DT_Value(Database_File.cfgs, "TBL_State_GSTCode", "StateCode", $"StateName = '{r("State").ToString}' COLLATE NOCASE")
                    Dim State_Name As String = Find_DT_Value(Database_File.cfgs, "TBL_State_GSTCode", "StateName", $"StateName = '{r("State").ToString}' COLLATE NOCASE")

                    Dim t As String = ""
                    If r("Voucher_Type").ToString = "Credit Note" Then
                        t = "C"
                    ElseIf r("Voucher_Type").ToString = "Debit Note" Then
                        t = "D"
                    End If

                    If State_Filter(r("State").ToString) = True Then
                        dt_export.Rows.Add(r("GST").ToString,
                                   r("Ledger_Name").ToString,
                                   r("vc_no").ToString,
                                   CDate(r("Date_")).ToString("dd-MMM-yy"),
                                   t,
                                            ($"{State_Code}-{State_Name}"),
                                            "N",
                                            ("Regular B2B"),
                                           nUmBeR_FORMATE(r("ivc_amt").ToString),
                                           (""),
                                            nUmBeR_FORMATE(r("GST_per").ToString),
                                            nUmBeR_FORMATE(r("Amount").ToString),
                                            nUmBeR_FORMATE(r("Cess_Amt").ToString)
)
                    End If

                    count_ += 1

                    If ifexcel = False Then
                        Export_CSV_Background.ReportProgress(count_)
                    End If
                End If

            End While
        End If
        Return dt_export
    End Function
    Public Function B2CS_Csv(frm_ As Date, To_ As Date, ifexcel As Boolean) As DataTable
        dt_export = New DataTable
        dt_export.Columns.Add("Type")
        dt_export.Columns.Add("Place Of Supply")
        dt_export.Columns.Add("Rate")
        dt_export.Columns.Add("Applicable % of Tax Rate")
        dt_export.Columns.Add("Taxable Value")
        dt_export.Columns.Add("Cess Amount")
        dt_export.Columns.Add("E-Commerce GSTIN")



        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select State,GST_per,SUM(Amount) as Taxable_Value,SUM(Cess_Amt) as Cess_Amt From (Select 
SUM(vi.Amount) as Amount,
CAST(ifnull(SUM(vc.Debit_Amount),0)as Decimal) as Dr,
ifnull(SUM(vi.IGST),0) + ifnull(SUM(vi.CGST),0) + ifnull(SUM(vi.SGST),0) as GST_vlu,
SUM(vi.Cess_Amt) as Cess_Amt,
(vi.GST_per) as GST_per,
vo.To_GST_Type as GST_Type,
vc.Ledger as Ledger_ID,
vc.[Date] as Date_,
vc.Voucher_No as vc_No,
vo.To_State as State,
ifnull(SUM(vc.Debit_Amount),0) as ivc_amt,
(Select ld.name From TBL_Ledger ld where ld.ID = vc.Ledger) as Ledger_Name,
vo.To_GST as GST,
(Select ld.Country From TBL_Ledger ld where ld.ID = vc.Ledger) as Country
From TBL_VC_item_Details vi
LEFT JOIN TBL_VC_Other vo on vo.Tra_ID = vi.Tra_ID 
LEFT JOIN TBL_VC vc on vc.Tra_ID = vi.Tra_ID
where vc.Type = 'Head' and vc.Visible = 'Approval'  and vc.Voucher_Type = 'Sales' and vo.To_GST_Type = 'Consumer' and (vc.Date BETWEEN '{CDate(frm_).ToString(Lite_date_Format)}' and '{CDate(To_).AddDays(1).ToString(Lite_date_Format)}')
Group By vc.Voucher_No, vi.GST_per
Order By vc.Voucher_No)
where Country = 'India' and Dr <= 250000 and GST_vlu <> 0
Group By GST_per,State
", cn)
            Dim r As SQLiteDataReader = cmd.ExecuteReader
            Dim count_ As Integer = 0
            While r.Read
                Try
                    If State_Filter(r("State").ToString) = True Then
                        If nUmBeR_FORMATE(r("GST_per").ToString) <> 0 Then
                            Dim State_Code As String = Find_DT_Value(Database_File.cfgs, "TBL_State_GSTCode", "StateCode", $"StateName = '{r("State").ToString}' COLLATE NOCASE")
                            Dim State_Name As String = Find_DT_Value(Database_File.cfgs, "TBL_State_GSTCode", "StateName", $"StateName = '{r("State").ToString}' COLLATE NOCASE")

                            dt_export.Rows.Add("OE",
                                            ($"{State_Code}-{State_Name}"),
                                            nUmBeR_FORMATE(r("GST_per").ToString),
                                            ($""),
                                           nUmBeR_FORMATE(r("Taxable_Value").ToString),
                                           nUmBeR_FORMATE(r("Cess_Amt").ToString),
                                            ""
)
                            count_ += 1
                            If ifexcel = False Then
                                Export_CSV_Background.ReportProgress(count_)
                            End If
                        End If
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End While
        End If
        Return dt_export

    End Function
    Public Function B2CL_Csv(frm_ As Date, To_ As Date, ifexcel As Boolean) As DataTable

        dt_export = New DataTable
        dt_export.Columns.Add("Invoice Number")
        dt_export.Columns.Add("Invoice date")
        dt_export.Columns.Add("Invoice Value")
        dt_export.Columns.Add("Place Of Supply")
        dt_export.Columns.Add("Applicable % of Tax Rate")
        dt_export.Columns.Add("Rate")
        dt_export.Columns.Add("Taxable Value")
        dt_export.Columns.Add("Cess Amount")
        dt_export.Columns.Add("E-Commerce GSTIN")

        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select 
SUM(vi.Amount) as Amount,
ifnull(SUM(vc.Debit_Amount),0) as Dr,
SUM(vi.IGST) as IGST,
SUM(vi.CGST) as CGST,
SUM(vi.SGST) as SGST,
SUM(vi.Cess_Amt) as Cess_Amt,
(vi.GST_per) as GST_per,
vo.To_GST_Type as GST_Type,
vc.Ledger as Ledger_ID,
vc.[Date] as Date_,
vc.Voucher_No as vc_No,
vo.To_State as State,
ifnull(SUM(vc.Debit_Amount),0) as ivc_amt,
(Select ld.name From TBL_Ledger ld where ld.ID = vc.Ledger) as Ledger_Name,
vo.To_GST as GST,
(Select ld.Country From TBL_Ledger ld where ld.ID = vc.Ledger) as Country
From TBL_VC_item_Details vi
LEFT JOIN TBL_VC_Other vo on vo.Tra_ID = vi.Tra_ID 
LEFT JOIN TBL_VC vc on vc.Tra_ID = vi.Tra_ID
where vc.Type = 'Head' and vc.Visible = 'Approval'  and vc.Voucher_Type = 'Sales' and vo.To_GST_Type = 'Consumer' and (vc.Date BETWEEN '{CDate(frm_).ToString(Lite_date_Format)}' and '{CDate(To_).AddDays(1).ToString(Lite_date_Format)}')
Group By vc.Voucher_No, vi.GST_per
Order By vc.Voucher_No", cn)
            Dim r As SQLiteDataReader = cmd.ExecuteReader
            Dim count_ As Integer = 0
            While r.Read
                Dim to_gst As Decimal = Val(Val(r("IGST").ToString) + Val(r("CGST").ToString) + Val(r("SGST").ToString))
                Dim AMT As Decimal = Val(r("Dr"))
                If r("Country").ToString.ToLower = "india" Then
                    If State_Filter(r("State")) = True Then
                        If AMT > 250000 Then
                            If Val(to_gst) <> 0 Then
                                Dim State_Code As String = Find_DT_Value(Database_File.cfgs, "TBL_State_GSTCode", "StateCode", $"StateName = '{r("State").ToString}' COLLATE NOCASE")
                                Dim State_Name As String = Find_DT_Value(Database_File.cfgs, "TBL_State_GSTCode", "StateName", $"StateName = '{r("State").ToString}' COLLATE NOCASE")

                                dt_export.Rows.Add(r("vc_No").ToString,
                                                CDate(r("Date_")).ToString("dd-MMM-yy"),
                                                nUmBeR_FORMATE(AMT),
                                                ($"{State_Code}-{State_Name}"),
                                                ($""),
                                                nUmBeR_FORMATE(r("GST_per").ToString),
                                                nUmBeR_FORMATE(r("Amount").ToString),
                                                nUmBeR_FORMATE(r("Cess_Amt").ToString),
                                                ("")
)
                            End If
                        End If
                    End If
                End If

                count_ += 1

                If ifexcel = False Then
                    Export_CSV_Background.ReportProgress(count_)
                End If

            End While
        End If
        Return dt_export

    End Function
    Public Function B2B_Csv(frm_ As Date, To_ As Date, ifexcel As Boolean) As DataTable
        dt_export = New DataTable
        dt_export.Columns.Add("GSTIN/UIN of Recipient")
        dt_export.Columns.Add("Receiver Name")
        dt_export.Columns.Add("Invoice Number")
        dt_export.Columns.Add("Invoice date")
        dt_export.Columns.Add("Invoice Value")
        dt_export.Columns.Add("Place Of Supply")
        dt_export.Columns.Add("Reverse Charge")
        dt_export.Columns.Add("Applicable % of Tax Rate")
        dt_export.Columns.Add("Invoice Type")
        dt_export.Columns.Add("E-Commerce GSTIN")
        dt_export.Columns.Add("Rate")
        dt_export.Columns.Add("Taxable Value")
        dt_export.Columns.Add("Cess Amount")

        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select 
SUM(vi.Amount) as Amount,
SUM(vi.IGST) as IGST,
SUM(vi.CGST) as CGST,
SUM(vi.SGST) as SGST,
SUM(vi.Cess_Amt) as Cess_Amt,
(vi.GST_per) as GST_per,
vo.To_GST_Type as GST_Type,
vc.Ledger as Ledger_ID,
vc.[Date] as Date_,
vc.Voucher_No as vc_No,
vo.To_State as State,
ifnull(SUM(vc.Debit_Amount),0) as ivc_amt,
(Select ld.name From TBL_Ledger ld where ld.ID = vc.Ledger) as Ledger_Name,
vo.To_GST as GST,
(Select ld.Country From TBL_Ledger ld where ld.ID = vc.Ledger) as Country
From TBL_VC_item_Details vi
LEFT JOIN TBL_VC_Other vo on vo.Tra_ID = vi.Tra_ID 
LEFT JOIN TBL_VC vc on vc.Tra_ID = vi.Tra_ID
where vc.Type = 'Head' and vc.Visible = 'Approval'  and vc.Voucher_Type = 'Sales' and vo.To_GST_Type = 'Regular' and (vc.Date BETWEEN '{CDate(frm_).ToString(Lite_date_Format)}' and '{CDate(To_).AddDays(1).ToString(Lite_date_Format)}')
Group By vc.Voucher_No, vi.GST_per
Order By vc.Voucher_No", cn)
            Dim r As SQLiteDataReader = cmd.ExecuteReader
            Dim count_ As Integer = 0
            While r.Read
                Dim to_gst As Decimal = Val(Val(r("IGST").ToString) + Val(r("CGST").ToString) + Val(r("SGST").ToString))
                If Val(to_gst) <> 0 Then
                    If r("Country").ToString.ToLower = "india" Then
                        If State_Filter(r("State")) = True Then
                            Dim State_Code As String = Find_DT_Value(Database_File.cfgs, "TBL_State_GSTCode", "StateCode", $"StateName = '{r("State").ToString}' COLLATE NOCASE")
                            Dim State_Name As String = Find_DT_Value(Database_File.cfgs, "TBL_State_GSTCode", "StateName", $"StateName = '{r("State").ToString}' COLLATE NOCASE")

                            dt_export.Rows.Add(r("GST").ToString,
                                r("Ledger_Name").ToString,
                                r("vc_No").ToString,
                                CDate(r("Date_")).ToString("dd-MMM-yy"),
                                nUmBeR_FORMATE(r("ivc_amt").ToString),
                                ($"{State_Code}-{State_Name}"),
                                ("N"),
                                (""),
                                ("Regular B2B"),
                                (""),
                                r("GST_per"),
                                nUmBeR_FORMATE(r("Amount").ToString),
                                nUmBeR_FORMATE(r("Cess_Amt").ToString)
)
                        End If

                    End If
                End If

                count_ += 1
                If ifexcel = False Then
                    Export_CSV_Background.ReportProgress(count_)
                End If
            End While
        End If

        Return dt_export
    End Function


    Private Sub Panel12_Paint(sender As Object, e As PaintEventArgs)
        obj_center(sender, Me)
    End Sub
    Public dt_export As DataTable
    Private Sub Export_CSV_Background_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles Export_CSV_Background.RunWorkerCompleted
        DataGridView1.DataSource = dt_export
        Export_csv(DataGridView1, $"{Export_Location}.csv")

    End Sub

    Private Sub Export_CSV_Background_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles Export_CSV_Background.ProgressChanged

    End Sub

    Private Sub GSTR1_Ledger_Summary_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID

        If Grid1.Visible = True Then
            Grid1.Focus()
        ElseIf Grid2.Visible = True Then
            Grid2.Focus()
        End If
    End Sub
    Private Sub Grid2_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles Grid2.CellFormatting
        If Grid2.CurrentCell IsNot Nothing Then
            If e.RowIndex = Grid2.CurrentCell.RowIndex And e.ColumnIndex = Grid2.CurrentCell.ColumnIndex Then
                e.CellStyle.SelectionBackColor = Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(48, Byte), Integer))
            Else
                e.CellStyle.SelectionBackColor = Grid2.DefaultCellStyle.SelectionBackColor
            End If
        End If
    End Sub
    Private Sub Grid2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid2.CellContentClick

    End Sub

    Private Sub Grid2_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid2.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True

            If (Grid2.CurrentCell.ColumnIndex) > 0 Then
                Cell("GSTR1 Voucher Register", VC_Type_, Grid2.CurrentRow.Cells(0).Value.ToString, "")
                If (Grid2.CurrentCell.ColumnIndex) = 1 Then
                    GSTR1_Ledger_Vouchers.Label7.Text = "Nil Rated"
                    GSTR1_Ledger_Vouchers.Fill_Grid()
                ElseIf (Grid2.CurrentCell.ColumnIndex) = 2 Then
                    GSTR1_Ledger_Vouchers.Label7.Text = "Exempt"
                    GSTR1_Ledger_Vouchers.Fill_Grid()
                ElseIf (Grid2.CurrentCell.ColumnIndex) = 3 Then
                    GSTR1_Ledger_Vouchers.Label7.Text = "Non-GST"
                    GSTR1_Ledger_Vouchers.Fill_Grid()
                End If
            End If
        End If
    End Sub
End Class