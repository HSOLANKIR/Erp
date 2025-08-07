Imports System.Data.SQLite
Imports Microsoft.Reporting.WinForms
Public Class GSTR1_Ledger_Vouchers
    Dim From_ID As String
    Private VC_Type_ As String
    Private Details_Of As String
    Private Voucher_Of As String
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
    Private Sub GSTR1_Ledger_Vouchers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text

        VC_Type_ = Link_Valu(0)
        Details_Of = Link_Valu(1)
        Voucher_Of = Link_Valu(2)

        Frm_Date_LB.Text = Date_Formate(Date_1)
        To_Date_LB.Text = Date_Formate(Date_2)

        GSLab.Text = Company_GST_str
        Label3.Text = Details_Of
        Label7.Text = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Name", $"ID = '{Voucher_Of}'")

        BG_frm.HADE_TXT.Text = "GSTR1 Voucher Register"
        BG_frm.TYP_TXT.Text = VC_Type_


        If Details_Of = "HSN/SAC Summary" Then
            HSN_ = Link_Valu(2)
            UQC_ = Link_Valu(3)
            GST_Rate_ = nUmBeR_FORMATE(Link_Valu(4).Replace("%", ""))
        End If
        Button_Manage()
        Add_Hander_Remove_Handel(True)

        Update_Report = True
    End Sub

    Private Sub GSTR1_Ledger_Summary_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.HADE_TXT.Text = "GSTR1 Voucher Register"
        BG_frm.TYP_TXT.Text = VC_Type_

        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text


        Button_Clear()
        Button_Manage()
        'cfg_fill()
        If Update_Report = True Then
            Fill_Grid()
        End If
        Grid1.Focus()
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
    End Function
    Private Function Add_Hander_Remove_Handel(Ans As Boolean)
        If Ans = True Then
            AddHandler BG_frm.R_2.Click, AddressOf Me.R_2_Click
            AddHandler BG_frm.R_3.Click, AddressOf Me.R_3_Click
        Else
            RemoveHandler BG_frm.R_2.Click, AddressOf Me.R_2_Click
            RemoveHandler BG_frm.R_3.Click, AddressOf Me.R_3_Click
        End If
    End Function
    Private Sub R_2_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Set_Date(False, Me)
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
        If Details_Of = "B2B Invoices - 4A, 4B, 4C, 6B, 6C" Then
            B2B_Calculation()
            Panel4.Visible = True
            Panel11.Visible = False
        ElseIf Details_Of = "B2C (Small) Invoices - 7" Or Details_Of = "B2C (Large) Invoices - SA, 6B" Then
            B2C_Calculation()
            Panel4.Visible = True
            Panel11.Visible = False
        ElseIf Details_Of = "Exports Invoices - 6A" Then
            Exports_Calculation()
            Panel4.Visible = True
            Panel11.Visible = False
        ElseIf Details_Of = "Credit Or Debit Notes (Registered) - 9B" Or Details_Of = "Credit Or Debit Notes (Unregistered) - 9B" Then
            Credit_Note_Register_Unregister()
            Panel4.Visible = True
            Panel11.Visible = False
        ElseIf Details_Of = "HSN/SAC Summary" Then
            HSN_Summary()
            Panel4.Visible = False
            Panel11.Visible = True
        Else
            Interstate_supplies_to_registered_person()
            Panel4.Visible = True
            Panel11.Visible = False
        End If
    End Function

    Dim HSN_ As String
    Dim UQC_ As String
    Dim GST_Rate_ As String
    Private Function HSN_Summary()
        Label10.Text = HSN_
        Label16.Text = UQC_
        Label17.Text = GST_Rate_

        Dim Tra_ID As String = ""

        Dim Date_ As String = ""
        Dim Particuls As String = Label7.Text
        Dim vc_No_ As String = ""
        Dim vc_Type_ As String = ""
        Dim Taxable As String = ""
        Dim IGST As String = ""
        Dim CGST As String = ""
        Dim SGST As String = ""
        Dim Cess As String = ""
        Dim TAX_Amt As String = ""
        Dim Ivc_Amt As String = ""

        Dim vc_No_Total As Decimal = 0
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
            cmd = New SQLiteCommand($"Select vc.[Date],(Select ld.name From TBL_Ledger ld where ld.ID = vc.Ledger) as Ledger_Name,vc.Voucher_Type,vc.Voucher_No,vi.Tra_ID,U.UQC,ifnull(vc.Debit_Amount,0)-ifnull(vc.Credit_Amount,0) as Ivc_Amt,
(CASE WHEN vi.Type = 'Debit' THEN
ifnull(SUM(vi.Qty),0)
ELSE(
ifnull(SUM(vi.Qty),0) * -1
)END) as Qty,

(CASE WHEN vi.Type = 'Debit' THEN
ifnull(SUM(vi.CGST),0)
ELSE(
ifnull(SUM(vi.CGST),0) * -1
)END) as CGST,

(CASE WHEN vi.Type = 'Debit' THEN
ifnull(SUM(vi.SGST),0)
ELSE(
ifnull(SUM(vi.SGST),0) * -1
)END) as SGST,

(CASE WHEN vi.Type = 'Debit' THEN
ifnull(SUM(vi.IGST),0)
ELSE(
ifnull(SUM(vi.IGST),0) * -1
)END) as IGST,

(CASE WHEN vi.Type = 'Debit' THEN
ifnull(SUM(vi.Amount),0)
ELSE(
ifnull(SUM(vi.Amount),0) * -1
)END) as Amt


From TBL_VC_Item_Details vi
LEFT JOIN TBL_VC vc on vc.Tra_ID = vi.Tra_ID
LEFT JOIN TBL_Stock_Item it on it.ID = vi.Item
LEFT JOIN TBL_Inventory_Unit U on U.ID = it.Unit
WHERE vc.Visible = 'Approval' and vc.Type = 'Head' and (vc.Voucher_Type = 'Sales' or vc.Voucher_Type = 'Credit Note' or vc.Voucher_Type = 'Debit Note') and it.HSN_Code = '{HSN_}' and vi.GST_per = '{GST_Rate_}' and U.UQC = '{UQC_}' and (vc.Date BETWEEN '{CDate(Frm_date).ToString(Lite_date_Format)}' and '{CDate(to_date).AddDays(1).ToString(Lite_date_Format)}')
Group By vi.Tra_ID", cn)
            Dim r As SQLiteDataReader = cmd.ExecuteReader
            While r.Read
                Dim to_gst As Decimal = Val(Val(r("IGST").ToString) + Val(r("CGST").ToString) + Val(r("SGST").ToString))



                Date_ = CDate(r("Date").ToString)
                vc_Type_ = (r("Voucher_Type").ToString)
                vc_No_ = (r("Voucher_No").ToString)
                Particuls = (r("Ledger_Name").ToString)


                Taxable = Val(r("Amt").ToString)
                IGST = Val(r("IGST").ToString)
                SGST = Val(r("SGST").ToString)
                CGST = Val(r("CGST").ToString)
                TAX_Amt = Val(Val(r("IGST").ToString) + Val(r("SGST").ToString) + Val(r("CGST").ToString))
                Ivc_Amt = Val(r("Ivc_Amt"))

                Tra_ID = r("Tra_ID").ToString




                Grid1.Rows.Add(Date_, Particuls, vc_Type_, vc_No_,
            N2_FORMATE(Taxable),
            N2_FORMATE(IGST), N2_FORMATE(CGST), N2_FORMATE(SGST),
            N2_FORMATE(Cess),
            N2_FORMATE(TAX_Amt),
            N2_FORMATE(Ivc_Amt),
            Tra_ID)


                vc_No_Total += 1
                Taxable_Total += Val(Taxable)
                IGST_Total += Val(IGST)
                SGST_Total += Val(SGST)
                CGST_Total += Val(CGST)
                TAX_Amt_Total += Val(TAX_Amt)
                Ivc_Amt_Total += Val(Ivc_Amt)
            End While

            Label30.Text = N2_FORMATE(Ivc_Amt_Total)
            Label29.Text = N2_FORMATE(TAX_Amt_Total)
            Label28.Text = ""
            Label27.Text = N2_FORMATE(SGST_Total)
            Label26.Text = N2_FORMATE(CGST_Total)
            Label25.Text = N2_FORMATE(IGST_Total)
            Label24.Text = N2_FORMATE(Taxable_Total)
            Label23.Text = N2_FORMATE(vc_No_Total)
        End If

    End Function
    Private Function Interstate_supplies_to_registered_person()
        Dim Tra_ID As String = ""

        Dim Date_ As String = ""
        Dim Particuls As String = Label7.Text
        Dim vc_No_ As String = ""
        Dim vc_Type_ As String = ""
        Dim Taxable As String = ""
        Dim IGST As String = ""
        Dim CGST As String = ""
        Dim SGST As String = ""
        Dim Cess As String = ""
        Dim TAX_Amt As String = ""
        Dim Ivc_Amt As String = ""


        Dim vc_No_Total As Decimal = 0
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

            cmd = New SQLiteCommand($"Select vc.Tra_ID,vc.Date as Date_,vc.Voucher_Type,vc.Voucher_No as vc_No,vo.To_State,vo.To_GST_Type,it.TAX_Type,SUM(vi.Amount) as Amount,(vc.Debit_Amount) as Ivc_Amt,vo.To_Country
From TBL_VC_item_Details vi
LEFT JOIN TBL_VC vc on VC.Tra_ID = vi.Tra_ID
LEFT JOIN TBL_Stock_Item it on it.ID = vi.Item
LEFT JOIN TBL_Voucher_Create v on v.ID = vc.Voucher_Type_ID
LEFT JOIN TBL_VC_Other vo on vo.Tra_ID = vc.Tra_ID
where vc.Visible = 'Approval' and vc.Voucher_Type = 'Sales' and vc.Type = 'Head' and it.GST_Applicable = 'Applicable' and it.Tax_Value = '0' and v.YN_GST = 'Yes' and it.TAX_Type = '{Label7.Text}' and (vc.Date BETWEEN '{CDate(Frm_date).ToString(Lite_date_Format)}' and '{CDate(to_date).AddDays(1).ToString(Lite_date_Format)}')
Group By vc.Tra_ID", cn)
            Dim r As SQLiteDataReader = cmd.ExecuteReader
            While r.Read
                If r("To_Country").ToString.ToLower = "india" Then
                    If Label3.Text = "Interstate supplies to registered person" Then
                        If r("To_GST_Type").ToString = "Regular" Then
                            If r("To_State").ToString.ToLower <> Company_State_str.ToLower Then
                                Date_ = CDate(r("Date_").ToString)
                                vc_Type_ = (r("Voucher_Type").ToString)
                                vc_No_ = (r("vc_No").ToString)

                                Taxable = Val(r("Amount").ToString)
                                IGST = Val(0)
                                SGST = Val(0)
                                CGST = Val(0)
                                TAX_Amt = Val(0)
                                Ivc_Amt = Val(r("Ivc_Amt"))

                                Tra_ID = r("Tra_ID").ToString


                                Grid1.Rows.Add(Date_, Particuls, vc_Type_, vc_No_,
                            N2_FORMATE(Taxable),
                            N2_FORMATE(IGST), N2_FORMATE(CGST), N2_FORMATE(SGST),
                            N2_FORMATE(Cess),
                            N2_FORMATE(TAX_Amt),
                            N2_FORMATE(Ivc_Amt),
                            Tra_ID)

                                vc_No_Total += 1
                                Taxable_Total += Val(Taxable)
                                IGST_Total += Val(IGST)
                                SGST_Total += Val(SGST)
                                CGST_Total += Val(CGST)
                                TAX_Amt_Total += Val(TAX_Amt)
                                Ivc_Amt_Total += Val(Ivc_Amt)
                            End If
                        End If
                    ElseIf Label3.Text = "Interstate supplies to unregistered person" Then
                        If r("To_GST_Type").ToString <> "Regular" Then
                            If r("To_State").ToString.ToLower <> Company_State_str.ToLower Then
                                Date_ = CDate(r("Date_").ToString)
                                vc_Type_ = (r("Voucher_Type").ToString)
                                vc_No_ = (r("vc_No").ToString)

                                Taxable = Val(r("Amount").ToString)
                                IGST = Val(0)
                                SGST = Val(0)
                                CGST = Val(0)
                                TAX_Amt = Val(0)
                                Ivc_Amt = Val(r("Ivc_Amt"))

                                Tra_ID = r("Tra_ID").ToString


                                Grid1.Rows.Add(Date_, Particuls, vc_Type_, vc_No_,
                            N2_FORMATE(Taxable),
                            N2_FORMATE(IGST), N2_FORMATE(CGST), N2_FORMATE(SGST),
                            N2_FORMATE(Cess),
                            N2_FORMATE(TAX_Amt),
                            N2_FORMATE(Ivc_Amt),
                            Tra_ID)

                                vc_No_Total += 1
                                Taxable_Total += Val(Taxable)
                                IGST_Total += Val(IGST)
                                SGST_Total += Val(SGST)
                                CGST_Total += Val(CGST)
                                TAX_Amt_Total += Val(TAX_Amt)
                                Ivc_Amt_Total += Val(Ivc_Amt)
                            End If
                        End If

                    ElseIf Label3.Text = "Intrastate supplies to registered person" Then

                        If r("To_GST_Type").ToString = "Regular" Then
                            If r("To_State").ToString.ToLower = Company_State_str.ToLower Then
                                Date_ = CDate(r("Date_").ToString)
                                vc_Type_ = (r("Voucher_Type").ToString)
                                vc_No_ = (r("vc_No").ToString)

                                Taxable = Val(r("Amount").ToString)
                                IGST = Val(0)
                                SGST = Val(0)
                                CGST = Val(0)
                                TAX_Amt = Val(0)
                                Ivc_Amt = Val(r("Ivc_Amt"))

                                Tra_ID = r("Tra_ID").ToString


                                Grid1.Rows.Add(Date_, Particuls, vc_Type_, vc_No_,
                            N2_FORMATE(Taxable),
                            N2_FORMATE(IGST), N2_FORMATE(CGST), N2_FORMATE(SGST),
                            N2_FORMATE(Cess),
                            N2_FORMATE(TAX_Amt),
                            N2_FORMATE(Ivc_Amt),
                            Tra_ID)

                                vc_No_Total += 1
                                Taxable_Total += Val(Taxable)
                                IGST_Total += Val(IGST)
                                SGST_Total += Val(SGST)
                                CGST_Total += Val(CGST)
                                TAX_Amt_Total += Val(TAX_Amt)
                                Ivc_Amt_Total += Val(Ivc_Amt)
                            End If
                        End If
                    ElseIf Label3.Text = "Intrastate supplies to unregistered person" Then
                        If r("To_GST_Type").ToString <> "Regular" Then
                            If r("To_State").ToString.ToLower = Company_State_str.ToLower Then
                                Date_ = CDate(r("Date_").ToString)
                                vc_Type_ = (r("Voucher_Type").ToString)
                                vc_No_ = (r("vc_No").ToString)

                                Taxable = Val(r("Amount").ToString)
                                IGST = Val(0)
                                SGST = Val(0)
                                CGST = Val(0)
                                TAX_Amt = Val(0)
                                Ivc_Amt = Val(r("Ivc_Amt"))

                                Tra_ID = r("Tra_ID").ToString


                                Grid1.Rows.Add(Date_, Particuls, vc_Type_, vc_No_,
                            N2_FORMATE(Taxable),
                            N2_FORMATE(IGST), N2_FORMATE(CGST), N2_FORMATE(SGST),
                            N2_FORMATE(Cess),
                            N2_FORMATE(TAX_Amt),
                            N2_FORMATE(Ivc_Amt),
                            Tra_ID)

                                vc_No_Total += 1
                                Taxable_Total += Val(Taxable)
                                IGST_Total += Val(IGST)
                                SGST_Total += Val(SGST)
                                CGST_Total += Val(CGST)
                                TAX_Amt_Total += Val(TAX_Amt)
                                Ivc_Amt_Total += Val(Ivc_Amt)
                            End If
                        End If
                    End If







                End If
            End While

            Label30.Text = N2_FORMATE(Ivc_Amt_Total)
            Label29.Text = N2_FORMATE(TAX_Amt_Total)
            Label28.Text = ""
            Label27.Text = N2_FORMATE(SGST_Total)
            Label26.Text = N2_FORMATE(CGST_Total)
            Label25.Text = N2_FORMATE(IGST_Total)
            Label24.Text = N2_FORMATE(Taxable_Total)
            Label23.Text = N2_FORMATE(vc_No_Total)
        End If

    End Function
    Private Function Exports_Calculation()
        Dim Tra_ID As String = ""

        Dim Date_ As String = ""
        Dim Particuls As String = Label7.Text
        Dim vc_No_ As String = ""
        Dim vc_Type_ As String = ""
        Dim Taxable As String = ""
        Dim IGST As String = ""
        Dim CGST As String = ""
        Dim SGST As String = ""
        Dim Cess As String = ""
        Dim TAX_Amt As String = ""
        Dim Ivc_Amt As String = ""



        Dim vc_No_Total As Decimal = 0
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
            cmd = New SQLiteCommand($"Select vc_No,Date_,Tra_I,Amount,IGST,CGST,SGST,GST_Type,Voucher_Type,Ledger_ID,Ledger_Name,GST,Country,ifnull(SUM(vc.Debit_Amount),0) as Dr,ifnull(SUM(vc.Credit_Amount),0) as Cr From (
Select vi.Tra_ID as Tra_I,
SUM(vi.Amount) as Amount,
SUM(vi.IGST) as IGST,
SUM(vi.CGST) as CGST,
SUM(vi.SGST) as SGST,
vo.To_GST_Type as GST_Type,
vc.Ledger as Ledger_ID,
vc.Voucher_No as vc_No,
vc.[Date] as Date_,
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
                    Date_ = CDate(r("Date_").ToString)
                    vc_Type_ = (r("Voucher_Type").ToString)
                    vc_No_ = (r("vc_No").ToString)

                    Taxable = Val(r("Amount").ToString)
                    IGST = Val(r("IGST").ToString)
                    SGST = Val(r("SGST").ToString)
                    CGST = Val(r("CGST").ToString)
                    TAX_Amt = Val(Val(r("IGST").ToString) + Val(r("SGST").ToString) + Val(r("CGST").ToString))
                    Ivc_Amt = Val(r("Dr"))

                    Tra_ID = r("Tra_I").ToString




                    Grid1.Rows.Add(Date_, Particuls, vc_Type_, vc_No_,
                    N2_FORMATE(Taxable),
                    N2_FORMATE(IGST), N2_FORMATE(CGST), N2_FORMATE(SGST),
                    N2_FORMATE(Cess),
                    N2_FORMATE(TAX_Amt),
                    N2_FORMATE(Ivc_Amt),
                    Tra_ID)

                    vc_No_Total += 1
                    Taxable_Total += Val(Taxable)
                    IGST_Total += Val(IGST)
                    SGST_Total += Val(SGST)
                    CGST_Total += Val(CGST)
                    TAX_Amt_Total += Val(TAX_Amt)
                    Ivc_Amt_Total += Val(Ivc_Amt)
                End If
            End While

            Label30.Text = N2_FORMATE(Ivc_Amt_Total)
            Label29.Text = N2_FORMATE(TAX_Amt_Total)
            Label28.Text = ""
            Label27.Text = N2_FORMATE(SGST_Total)
            Label26.Text = N2_FORMATE(CGST_Total)
            Label25.Text = N2_FORMATE(IGST_Total)
            Label24.Text = N2_FORMATE(Taxable_Total)
            Label23.Text = N2_FORMATE(vc_No_Total)
        End If
    End Function
    Private Function Credit_Note_Register_Unregister()
        Dim isregister As Boolean

        If Details_Of = "Credit Or Debit Notes (Registered) - 9B" Then
            isregister = True
        Else
            isregister = False
        End If


        Dim Tra_ID As String = ""

        Dim Date_ As String = ""
        Dim Particuls As String = Label7.Text
        Dim vc_No_ As String = ""
        Dim vc_Type_ As String = ""
        Dim Taxable As String = ""
        Dim IGST As String = ""
        Dim CGST As String = ""
        Dim SGST As String = ""
        Dim Cess As String = ""
        Dim TAX_Amt As String = ""
        Dim Ivc_Amt As String = ""


        Dim vc_No_Total As Decimal = 0
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
            cmd = New SQLiteCommand($"Select Tra_I,Date_,vc_No,Amount,IGST,CGST,SGST,GST_Type,To_State,Voucher_Type,Ledger_ID,Ledger_Name,GST,Country,ifnull(SUM(vc.Debit_Amount),0) as Dr,ifnull(SUM(vc.Credit_Amount),0) as Cr From (
Select vi.Tra_ID as Tra_I,
SUM(vi.Amount) as Amount,
SUM(vi.IGST) as IGST,
SUM(vi.CGST) as CGST,
SUM(vi.SGST) as SGST,
vo.To_GST_Type as GST_Type,
vo.To_State as To_State,
vc.Ledger as Ledger_ID,
vc.Voucher_No as vc_No,
vc.[Date] as Date_,
(Select ld.name From TBL_Ledger ld where ld.ID = vc.Ledger) as Ledger_Name,
(Select ld.GSTNo From TBL_Ledger ld where ld.ID = vc.Ledger) as GST,
(Select ld.Country From TBL_Ledger ld where ld.ID = vc.Ledger) as Country
From TBL_VC_item_Details vi
LEFT JOIN TBL_VC vc on vc.Tra_ID = vi.Tra_ID
LEFT JOIN TBL_VC_Other vo on vo.Tra_ID = vi.Tra_ID 
WHERE  vc.Type = 'Head' and vc.Visible = 'Approval' and (vc.Voucher_Type = 'Credit Note' or vc.Voucher_Type = 'Debit Note') and vc.Ledger = '{Voucher_Of}' and (vc.Date BETWEEN '{CDate(Frm_date).ToString(Lite_date_Format)}' and '{CDate(to_date).AddDays(1).ToString(Lite_date_Format)}')
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

                            Date_ = CDate(r("Date_").ToString)
                            vc_Type_ = (r("Voucher_Type").ToString)
                            vc_No_ = (r("vc_No").ToString)

                            Taxable = (Val(r("Amount").ToString) * nagitive_vlu)
                            IGST = (Val(r("IGST").ToString) * nagitive_vlu)
                            SGST = (Val(r("SGST").ToString) * nagitive_vlu)
                            CGST = (Val(r("CGST").ToString) * nagitive_vlu)
                            TAX_Amt = (Val(Val(r("IGST").ToString) + Val(r("SGST").ToString) + Val(r("CGST").ToString)) * nagitive_vlu)



                            If Vc_type = "credit note" Then
                                Ivc_Amt = (Val(r("Dr")) * nagitive_vlu)
                            Else
                                Ivc_Amt = (Val(r("Cr")) * nagitive_vlu)
                            End If



                            Tra_ID = r("Tra_I").ToString



                            Grid1.Rows.Add(Date_, Particuls, vc_Type_, vc_No_,
                        N2_FORMATE(Taxable),
                        N2_FORMATE(IGST), N2_FORMATE(CGST), N2_FORMATE(SGST),
                        N2_FORMATE(Cess),
                        N2_FORMATE(TAX_Amt),
                        N2_FORMATE(Ivc_Amt),
                        Tra_ID)

                            vc_No_Total += 1
                            Taxable_Total += Val(Taxable)
                            IGST_Total += Val(IGST)
                            SGST_Total += Val(SGST)
                            CGST_Total += Val(CGST)
                            TAX_Amt_Total += Val(TAX_Amt)
                            Ivc_Amt_Total += Val(Ivc_Amt)
                        End If
                    Else
                        If r("GST_Type").ToString.ToLower <> "regular" Then
                            Date_ = CDate(r("Date_").ToString)
                            vc_Type_ = (r("Voucher_Type").ToString)
                            vc_No_ = (r("vc_No").ToString)

                            Taxable = (Val(r("Amount").ToString) * nagitive_vlu)
                            IGST = (Val(r("IGST").ToString) * nagitive_vlu)
                            SGST = (Val(r("SGST").ToString) * nagitive_vlu)
                            CGST = (Val(r("CGST").ToString) * nagitive_vlu)
                            TAX_Amt = (Val(Val(r("IGST").ToString) + Val(r("SGST").ToString) + Val(r("CGST").ToString)) * nagitive_vlu)



                            If Vc_type = "credit note" Then
                                Ivc_Amt = (Val(r("Dr")) * nagitive_vlu)
                            Else
                                Ivc_Amt = (Val(r("Cr")) * nagitive_vlu)
                            End If



                            Tra_ID = r("Tra_I").ToString



                            Grid1.Rows.Add(Date_, Particuls, vc_Type_, vc_No_,
                        N2_FORMATE(Taxable),
                        N2_FORMATE(IGST), N2_FORMATE(CGST), N2_FORMATE(SGST),
                        N2_FORMATE(Cess),
                        N2_FORMATE(TAX_Amt),
                        N2_FORMATE(Ivc_Amt),
                        Tra_ID)

                            vc_No_Total += 1
                            Taxable_Total += Val(Taxable)
                            IGST_Total += Val(IGST)
                            SGST_Total += Val(SGST)
                            CGST_Total += Val(CGST)
                            TAX_Amt_Total += Val(TAX_Amt)
                            Ivc_Amt_Total += Val(Ivc_Amt)
                        End If
                    End If
                End If
            End While

            Label30.Text = N2_FORMATE(Ivc_Amt_Total)
            Label29.Text = N2_FORMATE(TAX_Amt_Total)
            Label28.Text = ""
            Label27.Text = N2_FORMATE(SGST_Total)
            Label26.Text = N2_FORMATE(CGST_Total)
            Label25.Text = N2_FORMATE(IGST_Total)
            Label24.Text = N2_FORMATE(Taxable_Total)
            Label23.Text = N2_FORMATE(vc_No_Total)
        End If
    End Function
    Private Function B2C_Calculation()
        Dim isSmall As Boolean

        If Details_Of = "B2C (Small) Invoices - 7" Then
            isSmall = True
        Else
            isSmall = False
        End If


        Dim Tra_ID As String = ""

        Dim Date_ As String = ""
        Dim Particuls As String = Label7.Text
        Dim vc_No_ As String = ""
        Dim vc_Type_ As String = ""
        Dim Taxable As String = ""
        Dim IGST As String = ""
        Dim CGST As String = ""
        Dim SGST As String = ""
        Dim Cess As String = ""
        Dim TAX_Amt As String = ""
        Dim Ivc_Amt As String = ""


        Dim vc_No_Total As Decimal = 0
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
            cmd = New SQLiteCommand($"Select Tra_I,Date_,Amount,IGST,CGST,SGST,GST_Type,To_State,Voucher_Type,vc_No,Ledger_ID,Ledger_Name,GST,Country,ifnull(SUM(vc.Debit_Amount),0) as Dr,ifnull(SUM(vc.Credit_Amount),0) as Cr From (
Select vi.Tra_ID as Tra_I,
SUM(vi.Amount) as Amount,
SUM(vi.IGST) as IGST,
SUM(vi.CGST) as CGST,
SUM(vi.SGST) as SGST,
vo.To_GST_Type as GST_Type,
vo.To_State as To_State,
vc.Ledger as Ledger_ID,
vc.Voucher_No as vc_No,
vc.[Date] as Date_,
(Select ld.name From TBL_Ledger ld where ld.ID = vc.Ledger) as Ledger_Name,
(Select ld.GSTNo From TBL_Ledger ld where ld.ID = vc.Ledger) as GST,
(Select ld.Country From TBL_Ledger ld where ld.ID = vc.Ledger) as Country
From TBL_VC_item_Details vi
LEFT JOIN TBL_VC vc on vc.Tra_ID = vi.Tra_ID
LEFT JOIN TBL_VC_Other vo on vo.Tra_ID = vi.Tra_ID 
WHERE  vc.Type = 'Head' and vc.Visible = 'Approval'  and vc.Voucher_Type = 'Sales' and vo.To_GST_Type = 'Consumer' and vc.Ledger = '{Voucher_Of}' and (vc.Date BETWEEN '{CDate(Frm_date).ToString(Lite_date_Format)}' and '{CDate(to_date).AddDays(1).ToString(Lite_date_Format)}')
Group By vi.Tra_ID)
LEFT JOIN TBL_VC vc on vc.Tra_ID = Tra_I
Group By vc.Tra_ID
Order By Ledger_ID", cn)
            Dim r As SQLiteDataReader = cmd.ExecuteReader


            While r.Read
                Dim to_gst As Decimal = Val(Val(r("IGST").ToString) + Val(r("CGST").ToString) + Val(r("SGST").ToString))
                Dim AMT As Decimal = Val(r("Dr"))

                If r("Country").ToString.ToLower = "india" Then
                    If State_Filter(r("To_State").ToString) = True Then
                        If isSmall = True Then
                            If AMT <= 250000 Then
                                If Val(to_gst) <> 0 Then
                                    Date_ = CDate(r("Date_").ToString)
                                    vc_Type_ = (r("Voucher_Type").ToString)
                                    vc_No_ = (r("vc_No").ToString)

                                    Taxable = Val(r("Amount").ToString)
                                    IGST = Val(r("IGST").ToString)
                                    SGST = Val(r("SGST").ToString)
                                    CGST = Val(r("CGST").ToString)
                                    TAX_Amt = Val(Val(r("IGST").ToString) + Val(r("SGST").ToString) + Val(r("CGST").ToString))
                                    Ivc_Amt = Val(r("Dr"))

                                    Tra_ID = r("Tra_I").ToString




                                    Grid1.Rows.Add(Date_, Particuls, vc_Type_, vc_No_,
                                N2_FORMATE(Taxable),
                                N2_FORMATE(IGST), N2_FORMATE(CGST), N2_FORMATE(SGST),
                                N2_FORMATE(Cess),
                                N2_FORMATE(TAX_Amt),
                                N2_FORMATE(Ivc_Amt),
                                Tra_ID)

                                    vc_No_Total += 1
                                    Taxable_Total += Val(Taxable)
                                    IGST_Total += Val(IGST)
                                    SGST_Total += Val(SGST)
                                    CGST_Total += Val(CGST)
                                    TAX_Amt_Total += Val(TAX_Amt)
                                    Ivc_Amt_Total += Val(Ivc_Amt)
                                End If
                            End If
                        Else
                            If AMT > 250000 Then
                                If Val(to_gst) <> 0 Then
                                    Date_ = CDate(r("Date_").ToString)
                                    vc_Type_ = (r("Voucher_Type").ToString)
                                    vc_No_ = (r("vc_No").ToString)

                                    Taxable = Val(r("Amount").ToString)
                                    IGST = Val(r("IGST").ToString)
                                    SGST = Val(r("SGST").ToString)
                                    CGST = Val(r("CGST").ToString)
                                    TAX_Amt = Val(Val(r("IGST").ToString) + Val(r("SGST").ToString) + Val(r("CGST").ToString))
                                    Ivc_Amt = Val(r("Dr"))

                                    Tra_ID = r("Tra_I").ToString




                                    Grid1.Rows.Add(Date_, Particuls, vc_Type_, vc_No_,
                                N2_FORMATE(Taxable),
                                N2_FORMATE(IGST), N2_FORMATE(CGST), N2_FORMATE(SGST),
                                N2_FORMATE(Cess),
                                N2_FORMATE(TAX_Amt),
                                N2_FORMATE(Ivc_Amt),
                                Tra_ID)

                                    vc_No_Total += 1
                                    Taxable_Total += Val(Taxable)
                                    IGST_Total += Val(IGST)
                                    SGST_Total += Val(SGST)
                                    CGST_Total += Val(CGST)
                                    TAX_Amt_Total += Val(TAX_Amt)
                                    Ivc_Amt_Total += Val(Ivc_Amt)
                                End If
                            End If
                        End If
                    End If
                End If
            End While

            Label30.Text = N2_FORMATE(Ivc_Amt_Total)
            Label29.Text = N2_FORMATE(TAX_Amt_Total)
            Label28.Text = ""
            Label27.Text = N2_FORMATE(SGST_Total)
            Label26.Text = N2_FORMATE(CGST_Total)
            Label25.Text = N2_FORMATE(IGST_Total)
            Label24.Text = N2_FORMATE(Taxable_Total)
            Label23.Text = N2_FORMATE(vc_No_Total)
        End If
    End Function
    Private Function State_Filter(str As String) As Boolean
        If (str.ToString.ToLower = "not applicable") Or (str.ToString.Length <= 2) Then
            Return False
        Else
            Return True
        End If
    End Function
    Private Function B2B_Calculation()
        Dim Tra_ID As String = ""

        Dim Date_ As String = ""
        Dim Particuls As String = Label7.Text
        Dim vc_Type_ As String = ""
        Dim vc_No_ As String = ""
        Dim Taxable As String = ""
        Dim IGST As String = ""
        Dim CGST As String = ""
        Dim SGST As String = ""
        Dim Cess As String = ""
        Dim TAX_Amt As String = ""
        Dim Ivc_Amt As String = ""




        Dim vc_No_Total As Decimal = 0
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
            cmd = New SQLiteCommand($"Select Date_,Tra_I,Amount,IGST,CGST,SGST,GST_Type,To_State,Voucher_Type,vc_No,Ledger_ID,Ledger_Name,GST,Country,ifnull(SUM(vc.Debit_Amount),0) as Dr,ifnull(SUM(vc.Credit_Amount),0) as Cr From (
Select vi.Tra_ID as Tra_I,
SUM(vi.Amount) as Amount,
SUM(vi.IGST) as IGST,
SUM(vi.CGST) as CGST,
SUM(vi.SGST) as SGST,
vo.To_GST_Type as GST_Type,
vo.To_State as To_State,
vc.Ledger as Ledger_ID,
vc.[Date] as Date_,
vc.Voucher_No as vc_No,
(Select ld.name From TBL_Ledger ld where ld.ID = vc.Ledger) as Ledger_Name,
vo.To_GST as GST,
(Select ld.Country From TBL_Ledger ld where ld.ID = vc.Ledger) as Country
From TBL_VC_item_Details vi
LEFT JOIN TBL_VC vc on vc.Tra_ID = vi.Tra_ID
LEFT JOIN TBL_VC_Other vo on vo.Tra_ID = vi.Tra_ID 
WHERE  vc.Type = 'Head' and vc.Visible = 'Approval'  and vc.Voucher_Type = 'Sales' and vc.Ledger = '{Voucher_Of}' and vo.To_GST_Type = 'Regular' and (vc.Date BETWEEN '{CDate(Frm_date).ToString(Lite_date_Format)}' and '{CDate(to_date).AddDays(1).ToString(Lite_date_Format)}')
Group By vi.Tra_ID)
LEFT JOIN TBL_VC vc on vc.Tra_ID = Tra_I
Group By vc.Tra_ID
Order By Ledger_ID", cn)
            Dim r As SQLiteDataReader = cmd.ExecuteReader


            While r.Read
                Dim to_gst As Decimal = Val(Val(r("IGST").ToString) + Val(r("CGST").ToString) + Val(r("SGST").ToString))
                If Val(to_gst) <> 0 Then
                    If r("Country").ToString.ToLower = "india" Then
                        If State_Filter(r("To_State").ToString) = True Then
                            Date_ = CDate(r("Date_").ToString)
                            vc_Type_ = (r("Voucher_Type").ToString)
                            vc_No_ = (r("vc_No").ToString)

                            Taxable = Val(r("Amount").ToString)
                            IGST = Val(r("IGST").ToString)
                            SGST = Val(r("SGST").ToString)
                            CGST = Val(r("CGST").ToString)
                            TAX_Amt = Val(Val(r("IGST").ToString) + Val(r("SGST").ToString) + Val(r("CGST").ToString))
                            Ivc_Amt = Val(r("Dr"))

                            Tra_ID = r("Tra_I").ToString




                            Grid1.Rows.Add(Date_, Particuls, vc_Type_, vc_No_,
                            N2_FORMATE(Taxable),
                            N2_FORMATE(IGST), N2_FORMATE(CGST), N2_FORMATE(SGST),
                            N2_FORMATE(Cess),
                            N2_FORMATE(TAX_Amt),
                            N2_FORMATE(Ivc_Amt),
                            Tra_ID)


                            vc_No_Total += 1
                            Taxable_Total += Val(Taxable)
                            IGST_Total += Val(IGST)
                            SGST_Total += Val(SGST)
                            CGST_Total += Val(CGST)
                            TAX_Amt_Total += Val(TAX_Amt)
                            Ivc_Amt_Total += Val(Ivc_Amt)
                        End If
                    End If
                End If
            End While

        End If


        Label30.Text = N2_FORMATE(Ivc_Amt_Total)
        Label29.Text = N2_FORMATE(TAX_Amt_Total)
        Label28.Text = ""
        Label27.Text = N2_FORMATE(SGST_Total)
        Label26.Text = N2_FORMATE(CGST_Total)
        Label25.Text = N2_FORMATE(IGST_Total)
        Label24.Text = N2_FORMATE(Taxable_Total)
        Label23.Text = N2_FORMATE(vc_No_Total)

    End Function

    Private Sub Grid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid1.CellContentClick

    End Sub

    Private Sub Grid1_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cell("Voucher BG", Grid1.CurrentRow.Cells(11).Value, "Alter_Close", Grid1.CurrentRow.Cells(2).Value)
        End If
    End Sub

    Private Sub GSTR1_Ledger_Vouchers_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID

        Grid1.Focus()
    End Sub
End Class