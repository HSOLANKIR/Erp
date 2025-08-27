Imports System.Data.SQLite
Imports System.IO
Imports Tools

Public Class Ledger_frm
    Dim Under_ID As String
    Dim Under As String
    Dim Path_End As String
    Dim VC_Type_ As String
    Dim VC_ID_ As String
    Public close_focus_obj As TXT
    Public close_link_yn As Boolean = True
    Dim From_ID As String

    Private Sub Ledger_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text

        VC_Type_ = Link_Valu(1)
        VC_ID_ = Link_Valu(2)

        BG_frm.HADE_TXT.Text = "Account Ledger"
        BG_frm.TYP_TXT.Text = VC_Type_

        If From_Access(BG_frm.HADE_TXT.Text, BG_frm.TYP_TXT.Text) = False Then
            Me.Dispose()
            Cell("Not Access", BG_frm.HADE_TXT.Text & $"({BG_frm.TYP_TXT.Text})")
            Exit Sub
        End If


        Load_data_source()
        List_set()

        If VC_Type_ = "Display" Or VC_Type_ = "Display_Close" Then
            Me.Enabled = False
            Display_Fill_All()
        ElseIf VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close" Then
            Me.Enabled = True
            Display_Fill_All()
        ElseIf VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
        End If

        Total_Opning_balance()
        Button_Manage()
        Add_Hander_Remove_Handel(True)
        Name_TXT.Focus()
        SendKeys.Send("{TAB}")
    End Sub
    Private Function Load_data_source()
        Dim cn As New SQLiteConnection

        Dim dt As New DataTable
        dt.Columns.Add("Name")
        dt.Columns.Add("Under Group")
        dt.Columns.Add("ID")

        dt.Rows.Add("", "Create")

        Dim dr As DataRow
        If open_MSSQL_Cstm(Database_File.cre, cn) Then
            cmd = New SQLiteCommand("Select ID,Name,(Select [Name] From TBL_Acc_Group agg where agg.ID = ag.UserGroup) as Under_Group From TBL_Acc_Group ag where " & Company_Visible_Filter(), cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                dr = dt.NewRow
                dr("ID") = r("ID").ToString
                dr("Name") = r("Name").ToString
                If r("Under_Group").ToString = Nothing Then
                    dr("Under Group") = "Primary"
                Else
                    dr("Under Group") = r("Under_Group").ToString
                End If
                dt.Rows.Add(dr)
            End While
            r.Close()
            Group_Source.DataSource = dt


            Dim dt_tx As New DataTable
            dt_tx.Columns.Add("Name")
            dt_tx.Rows.Add("Not Applicable")
            dt_tx.Rows.Add("GST")
            TAX_Type_Source.DataSource = dt_tx

            dt_tx = New DataTable
            dt_tx.Columns.Add("Name")
            dt_tx.Columns.Add("Pr")
            dt_tx.Rows.Add("Not Applicable", "")

            TAX_Source.DataSource = dt_tx

            dt_tx = New DataTable
            dt_tx.Columns.Add("Name")
            dt_tx.Columns.Add("Pr")
            dt_tx.Rows.Add("IGST", "")
            dt_tx.Rows.Add("CGST", "")
            dt_tx.Rows.Add("SGST/UTGST", "")
            dt_tx.Rows.Add("Cess", "")

            GST_Classs_Source.DataSource = dt_tx
        End If
        cn.Close()
        'Load Tax Data==============================
        Dim dt_country As New DataTable
        dt_country.Columns.Clear()
        dt_country.Clear()
        dt_country.Columns.Add("Country_Name")
        dt_country.Columns.Add("Code")
        dt_country.Columns.Add("ID")

        If open_MSSQL(Database_File.cfgs) = True Then
            cmd = New SQLiteCommand("Select * From TBL_Currency", con)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                dt_country.Rows.Add(r("Country_Name"), r("Code"))
            End While
            r.Close()
            Country_BS.DataSource = dt_country


            Dim dt_ As New DataTable
            dt_.Columns.Add("Name")
            dt_.Rows.Add("Not Applicable")

            cmd = New SQLiteCommand("Select * From TBL_State", con)
            r = cmd.ExecuteReader
            While r.Read
                dt_.Rows.Add(r("Name"))
            End While
            r.Close()
            State_Source.DataSource = dt_
        End If



        'Gst typr
        Dim dt_gst As New DataTable
        dt_gst.Columns.Add("Head")
        dt_gst.Columns.Add("Under")
        dt_gst.Columns.Add("ID")

        dt_gst.Rows.Add("Composition")
        dt_gst.Rows.Add("Consumer")
        dt_gst.Rows.Add("Regular")
        dt_gst.Rows.Add("Unregistered")

        GST_Type__BS.DataSource = dt_gst


        dt = New DataTable
        dt.Columns.Add("Name")
        dt.Rows.Add("By Group (Default)")
        dt.Rows.Add("Custom")

        communication_type_source.DataSource = dt

        Label56.Text = "Attach Files : " & DataGridView1.Rows.Count


        dt = New DataTable
        dt.Columns.Add("Name")
        dt.Rows.Add("Cr")
        dt.Rows.Add("Dr")
        Crdr_Source.DataSource = dt
    End Function
    Private Function Button_Manage()
        Button_Clear()
        BG_frm.B_1.Text = "&E : Exit"
        BG_frm.B_2.Text = "&S : Save"
        BG_frm.B_4.Text = "&T : Attach"

        If Login_Type = "Admin Account" And (VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close") And Audit_YN = True Then
            BG_frm.B_5.Text = "|&O : Audit"
        End If

        If VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close" Then
            BG_frm.B_3.Text = "&D : Delete"
        End If
        BG_frm.R_2.Text = "|&G : Direct GST"
        BG_frm.R_3.Text = "|&I : Import Data"
        BG_frm.R_22.Text = "F12 : Configuration"
    End Function
    Private Function Add_Hander_Remove_Handel(ans As Boolean)
        If ans = True Then
            AddHandler BG_frm.KeyDown, AddressOf Me.BG_Keydown
            AddHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            AddHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
            AddHandler BG_frm.B_3.Click, AddressOf Me.B_3_Click
            AddHandler BG_frm.B_4.Click, AddressOf Me.B_4_Click

            AddHandler BG_frm.R_2.Click, AddressOf Me.R_2_Click

            If Login_Type = "Admin Account" And (VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close") Then
                AddHandler BG_frm.B_5.Click, AddressOf Me.B_5_Click
            End If
            AddHandler BG_frm.R_22.Click, AddressOf Me.B_11_Click
            AddHandler BG_frm.R_3.Click, AddressOf Me.R_3_Click
        Else
            RemoveHandler BG_frm.KeyDown, AddressOf Me.BG_Keydown
            RemoveHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            RemoveHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
            RemoveHandler BG_frm.B_3.Click, AddressOf Me.B_3_Click
            RemoveHandler BG_frm.B_4.Click, AddressOf Me.B_4_Click

            RemoveHandler BG_frm.R_2.Click, AddressOf Me.R_2_Click

            If Login_Type = "Admin Account" And (VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close") Then
                RemoveHandler BG_frm.B_5.Click, AddressOf Me.B_5_Click
            End If
            RemoveHandler BG_frm.R_22.Click, AddressOf Me.B_11_Click
            RemoveHandler BG_frm.R_3.Click, AddressOf Me.R_3_Click
        End If
    End Function
    Private Sub BG_Keydown(sender As Object, e As KeyEventArgs)
        If BG_frm.From_ID = From_ID Then
            If e.KeyCode = Keys.F12 Then
                BG_frm.R_22.PerformClick()
            End If
        End If
    End Sub
    Private Sub B_1_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Me.Dispose()
        End If
    End Sub
    Private Sub R_2_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Cell("GST Search", VC_Type_, "")
        End If
    End Sub
    Private Sub B_2_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Save_Data()
        End If
    End Sub
    Private Sub B_3_Click(sender As Object, e As EventArgs)
        If VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close" Then
            If BG_frm.From_ID = From_ID Then
                Delete_Data()
            End If
        End If
    End Sub
    Private Sub B_4_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            With attage_display
                .Grid_ = Me.DataGridView1
                .ShowDialog()
                Label56.Text = "Attach Files : " & DataGridView1.Rows.Count
            End With
        End If

    End Sub
    Private Sub B_5_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Dim str As String() = {"Name", "Alise", "Group"}
            Audit_Analysis.Colunm = str
            Cell("Audit Analysis", "", "Account Ledger", VC_ID_, "TBL_Ledger")
        End If
    End Sub
    Private Sub R_3_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Cell("Account Ledger Import")
        End If
    End Sub
    Private Sub B_11_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Dim obj_bg As Object = Cell("Configuration", "")
            Dim obj As Object = New Ledger_cfg
            obj.obj = Me
            obj_bg.Set_Cfg(obj)
        End If
    End Sub


    Private Sub Ledger_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        NOT_Clear()
        If e.KeyCode = Keys.Escape Then
            If Msg_Exit_YN("Ledger " & VC_Type_) = DialogResult.Yes Then
                Me.Dispose()
                If VC_Type_ = "Alter_Close" Or VC_Type_ = "Create_Close" Then
                    close_focus_obj.Focus()
                End If
            End If
        End If
    End Sub
    Private Sub Name_TXT_Enter(sender As Object, e As EventArgs) Handles Name_TXT.Enter
        Name_aLlow()
    End Sub
    Private Sub Name_TXT_TextChanged(sender As Object, e As EventArgs) Handles Name_TXT.TextChanged
        Name_aLlow()
    End Sub
    Private Sub Name_TXT_Lost_Focus(sender As Object, e As EventArgs) Handles Name_TXT.LostFocus
        If Name_aLlow() = False Then
            Name_TXT.Focus()
        End If
    End Sub

    Private Function Total_Opning_balance()
        Dim Arr As ArrayList = Company_Opning_Balance(Branch_ID_)
        Label45.Text = Arr(0)
        Label44.Text = Arr(1)
        Label46.Text = Arr(2)
    End Function

    Private Sub Phone_TXT_TextLostFocus(sender As Object, e As EventArgs) Handles Phone_TXT.LostFocus
        Lost_(sender)
    End Sub

    Private Sub Phone_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Phone_TXT.KeyPress
        Formate_Phone(sender, e)
    End Sub
    Private Function Group_Under_Find() As String
        Dim cmp_ As String = Find_DT_Value(Database_File.cre, "TBL_Acc_Group", "Company", $"Name = '{Group_TXT.Text.Trim}'")

        If cmp_ = "All" Then
            Return Group_TXT.Text.Trim
        Else
            Dim id As String = Find_DT_Value(Database_File.cre, "TBL_Acc_Group", "UserGroup", $"ID = '{Under_ID}'")

            Return Find_DT_Value(Database_File.cre, "TBL_Acc_Group", "Name", $"ID = '{id}'")
        End If
    End Function
    Private Function Set_Under(und As String)

        Select Case und
            Case "Capital Account"
                und = und
            Case "Loans (Liability)"
                und = und
            Case "Current Liabilities"
                und = und
            Case "Fixed Assets"
                und = und
            Case "Investments"
                und = und
            Case "Current Assets"
                und = und
            Case "Branch / Divisions"
                und = und
            Case "Misc. Expenses (ASSET)"
                und = und
            Case "Suspense A/c"
                und = und
            Case "Sales Accounts"
                und = und
            Case "Purchase Accounts"
                und = und
            Case "Direct Incomes"
                und = und
            Case "Direct Expenses"
                und = und
            Case "Indirect Incomes"
                und = und
            Case "Indirect Expenses"
                und = und



            Case "Reserves & Surplus"
                und = und
            Case "Bank OD A/c"
                und = und
            Case "Secured Loans"
                und = und
            Case "Unsecured Loans"
                und = und
            Case "Duties & Taxes"
                und = und
            Case "Provisions"
                und = und
            Case "Sundry Creditors"
                und = und
            Case "Stock-in-Hand"
                und = und
            Case "Deposits (Asset)"
                und = und
            Case "Loans & Advances (Asset)"
                und = und
            Case "Sundry Debtors"
                und = und
            Case "Cash-in-Hand"
                und = und
            Case "Bank Accounts"
                und = und
            Case Else
                Dim id As String = Find_DT_Value(Database_File.cre, "TBL_Acc_Group", "UserGroup", "ID = '" & Under_ID & "'")
                und = Find_DT_Value(Database_File.cre, "TBL_Acc_Group", "Name", "ID = '" & id & "'")
        End Select



        If und = "Direct Incomes" Or und = "Direct Incomes" Or und = "Direct Expenses" Or und = "Indirect Incomes" Or und = "Indirect Expenses" Then
            Social_Midia_Group(False)
            TAX_Registration_Group(False)
            Address_Group(False)
            Bank_Group(False)
            Administrative_Group(True)
            Duty_And_TAX_Group(False)
            CHEQUE_details_Group(False)
            Other_Details_Group(False)
        ElseIf und = "Duties & Taxes" Or und = "Sales Accounts" Or und = "Purchase Accounts" Then
            Duty_And_TAX_Group(True)
            TAX_Registration_Group(False)
            Address_Group(False)
            Social_Midia_Group(False)
            Bank_Group(False)
            Administrative_Group(True)
            CHEQUE_details_Group(False)
            Other_Details_Group(False)
            If und = "Duties & Taxes" Then
                Duty_TAX_Source_fill("Duties & Taxes")
                Txt6.Enabled = True
            ElseIf und = "Sales Accounts" Then
                Txt6.Enabled = False
                Txt6.Text = ""
                Duty_TAX_Source_fill("Sales Account")
            ElseIf und = "Purchase Accounts" Then
                Txt6.Text = ""
                Txt6.Enabled = False
                Duty_TAX_Source_fill("Purchase Account")
            End If
        ElseIf und = "Branch / Divisions" Or und = "Sundry Creditors" Or und = "Sundry Debtors" Then
            Duty_And_TAX_Group(False)
            TAX_Registration_Group(True)
            Social_Midia_Group(True)
            Address_Group(True)
            Bank_Group(True)
            Administrative_Group(True)
            CHEQUE_details_Group(False)
            Other_Details_Group(True)
        ElseIf und = "Bank Accounts" Then
            CHEQUE_details_Group(True)
            Duty_And_TAX_Group(False)
            TAX_Registration_Group(True)
            Social_Midia_Group(True)
            Address_Group(True)
            Bank_Group(True)
            Administrative_Group(True)
            Other_Details_Group(False)
        ElseIf und = "Capital Account" Then
            Duty_And_TAX_Group(False)
            TAX_Registration_Group(False)
            Social_Midia_Group(True)
            Address_Group(True)
            Bank_Group(True)
            Administrative_Group(True)
            Other_Details_Group(True)
        ElseIf und = "Loans (Liability)" Then
            Duty_And_TAX_Group(False)
            TAX_Registration_Group(False)
            Social_Midia_Group(True)
            Address_Group(True)
            Bank_Group(True)
            Administrative_Group(True)
            CHEQUE_details_Group(False)
            Other_Details_Group(False)
        ElseIf und = "Current Liabilities" Then
            Duty_And_TAX_Group(False)
            TAX_Registration_Group(False)
            Social_Midia_Group(True)
            Address_Group(True)
            Bank_Group(True)
            Administrative_Group(True)
            Other_Details_Group(False)
        ElseIf und = "Fixed Assets" Then
            Duty_And_TAX_Group(False)
            TAX_Registration_Group(False)
            Social_Midia_Group(False)
            Address_Group(False)
            Bank_Group(False)
            Administrative_Group(True)
            CHEQUE_details_Group(False)
            Other_Details_Group(False)
        ElseIf und = "Investments" Then
            Duty_And_TAX_Group(False)
            TAX_Registration_Group(False)
            Social_Midia_Group(False)
            Address_Group(True)
            Bank_Group(False)
            Administrative_Group(True)
            CHEQUE_details_Group(False)
            Other_Details_Group(False)
        ElseIf und = "Current Assets" Then
            Duty_And_TAX_Group(False)
            TAX_Registration_Group(False)
            Social_Midia_Group(True)
            Address_Group(True)
            Bank_Group(False)
            Administrative_Group(True)
            CHEQUE_details_Group(False)
            Other_Details_Group(False)
        ElseIf und = "Branch / Divisions" Then
            Duty_And_TAX_Group(False)
            TAX_Registration_Group(True)
            Social_Midia_Group(True)
            Address_Group(True)
            Bank_Group(True)
            Administrative_Group(True)
            CHEQUE_details_Group(False)
            Other_Details_Group(False)
        ElseIf und = "Misc. Expenses (ASSET)" Then
            Duty_And_TAX_Group(False)
            TAX_Registration_Group(False)
            Social_Midia_Group(False)
            Address_Group(True)
            Bank_Group(False)
            Administrative_Group(True)
            CHEQUE_details_Group(False)
            Other_Details_Group(False)
        ElseIf und = "Suspense A/c" Then
            Duty_And_TAX_Group(False)
            TAX_Registration_Group(False)
            Social_Midia_Group(True)
            Address_Group(True)
            Bank_Group(True)
            Administrative_Group(True)
            CHEQUE_details_Group(False)
            Other_Details_Group(False)
        ElseIf und = "Direct Incomes" Then
            Duty_And_TAX_Group(False)
            TAX_Registration_Group(False)
            Social_Midia_Group(False)
            Address_Group(False)
            Bank_Group(False)
            Administrative_Group(True)
            CHEQUE_details_Group(False)
            Other_Details_Group(False)
        ElseIf und = "Indirect Incomes" Then
            Duty_And_TAX_Group(False)
            TAX_Registration_Group(False)
            Social_Midia_Group(False)
            Address_Group(False)
            Bank_Group(False)
            Administrative_Group(True)
            CHEQUE_details_Group(False)
            Other_Details_Group(False)
        ElseIf und = "Direct Expenses" Then
            Duty_And_TAX_Group(False)
            TAX_Registration_Group(False)
            Social_Midia_Group(False)
            Address_Group(False)
            Bank_Group(False)
            Administrative_Group(True)
            Other_Details_Group(False)
        ElseIf und = "Indirect Expenses" Then
            Duty_And_TAX_Group(False)
            TAX_Registration_Group(False)
            Social_Midia_Group(False)
            Address_Group(False)
            Bank_Group(False)
            Administrative_Group(True)
            CHEQUE_details_Group(False)
            Other_Details_Group(False)
        ElseIf und = "Reserves & Surplus" Then
            Duty_And_TAX_Group(False)
            TAX_Registration_Group(False)
            Social_Midia_Group(False)
            Address_Group(False)
            Bank_Group(False)
            Administrative_Group(True)
            CHEQUE_details_Group(False)
            Other_Details_Group(False)
        ElseIf und = "Bank OD A/c" Then
            CHEQUE_details_Group(True)
            Duty_And_TAX_Group(False)
            TAX_Registration_Group(False)
            Social_Midia_Group(False)
            Address_Group(True)
            Bank_Group(True)
            Administrative_Group(True)
            Other_Details_Group(False)
        ElseIf und = "Secured Loans" Then
            Duty_And_TAX_Group(False)
            TAX_Registration_Group(False)
            Social_Midia_Group(False)
            Address_Group(True)
            Bank_Group(True)
            Administrative_Group(True)
            CHEQUE_details_Group(False)
            Other_Details_Group(False)
        ElseIf und = "Provisions" Then
            Duty_And_TAX_Group(False)
            TAX_Registration_Group(False)
            Social_Midia_Group(False)
            Address_Group(False)
            Bank_Group(False)
            Administrative_Group(True)
            CHEQUE_details_Group(False)
            Other_Details_Group(False)
        ElseIf und = "Sundry Creditors" Then
            Duty_And_TAX_Group(False)
            TAX_Registration_Group(True)
            Social_Midia_Group(True)
            Address_Group(True)
            Bank_Group(True)
            Administrative_Group(True)
            CHEQUE_details_Group(False)
            Other_Details_Group(True)
        ElseIf und = "Stock-in-Hand" Then
            Duty_And_TAX_Group(False)
            TAX_Registration_Group(False)
            Social_Midia_Group(False)
            Address_Group(False)
            Bank_Group(False)
            Administrative_Group(True)
            CHEQUE_details_Group(False)
            Other_Details_Group(False)
        ElseIf und = "Deposits (Asset)" Then
            Duty_And_TAX_Group(False)
            TAX_Registration_Group(False)
            Social_Midia_Group(True)
            Address_Group(True)
            Bank_Group(True)
            Administrative_Group(True)
            CHEQUE_details_Group(False)
            Other_Details_Group(False)
        ElseIf und = "Loans & Advances (Asset)" Then
            Duty_And_TAX_Group(False)
            TAX_Registration_Group(False)
            Social_Midia_Group(True)
            Address_Group(True)
            Bank_Group(True)
            Administrative_Group(True)
            CHEQUE_details_Group(False)
            Other_Details_Group(False)
        ElseIf und = "Sundry Debtors" Then
            Duty_And_TAX_Group(False)
            TAX_Registration_Group(False)
            Social_Midia_Group(True)
            Address_Group(True)
            Bank_Group(True)
            Administrative_Group(True)
            CHEQUE_details_Group(False)
            Other_Details_Group(True)
        ElseIf und = "Cash-in-Hand" Then
            Duty_And_TAX_Group(False)
            TAX_Registration_Group(False)
            Social_Midia_Group(True)
            Address_Group(False)
            Bank_Group(True)
            Administrative_Group(True)
            CHEQUE_details_Group(False)
            Other_Details_Group(True)
        End If
        Set_Frm()
        Panel9.Visible = Address_Panel.Visible
        'cfg_()
    End Function
    Private Function Other_Details_Group(Ob As Boolean)
        If Ob = True And cfg_other_YN = True Then
            otherdetails_Panel.Visible = True
        Else
            otherdetails_Panel.Visible = False
        End If
    End Function
    Private Function Social_Midia_Group(Ob As Boolean)
        If Communication_YN = True And Ob = True And cfg_Communication_YN = True Then
            communication_panel.Visible = True
        Else
            communication_panel.Visible = False
        End If

        Contect_Panel.Visible = Ob
    End Function
    Private Function TAX_Registration_Group(Ob As Boolean)
        If cfg_GST_Details_YN = True Then
            Tax_Registration_Panel.Visible = Ob
        Else
            Tax_Registration_Panel.Visible = False
        End If
    End Function
    Private Function Address_Group(Ob As Boolean)
        Address_Panel.Visible = Ob
    End Function
    Private Function Bank_Group(Ob As Boolean)
        If cfg_Bank_Details_YN = True Then
            Bank_Panel.Visible = Ob
        Else
            Bank_Panel.Visible = False
        End If

    End Function
    Private Function Administrative_Group(Ob As Boolean)
        Administrative_panel.Visible = Ob

    End Function
    Private Function Duty_And_TAX_Group(Ob As Boolean)
        Duty_TAX_Panel.Visible = Ob
    End Function
    Private Function CHEQUE_details_Group(Ob As Boolean)
        CHEQUE_details.Visible = Ob
    End Function

    Private Function Duty_TAX_Source_fill(under As String)

        Dim dt_tx As New DataTable
        dt_tx.Columns.Add("Name")
        dt_tx.Columns.Add("Pr")
        'dt_tx.Rows.Add("Not Applicable", "")

        If under = "Duties & Taxes" Then
            dt_tx = New DataTable
            dt_tx.Columns.Add("Name")
            dt_tx.Rows.Add("GST")

            TAX_Type_Source.DataSource = dt_tx


            dt_tx = New DataTable
            dt_tx.Columns.Add("Name")
            dt_tx.Columns.Add("Pr")


            If Txt6.Text = "IGST" Then
                dt_tx.Rows.Add("IGST@0%", "0.00")
                dt_tx.Rows.Add("IGST@5%", "5.00")
                dt_tx.Rows.Add("IGST@12%", "12.00")
                dt_tx.Rows.Add("IGST@18%", "18.00")
                dt_tx.Rows.Add("IGST@28%", "28.00")

            ElseIf Txt6.Text = "CGST" Then
                dt_tx.Rows.Add("CGST@0%", "0.00")
                dt_tx.Rows.Add("CGST@2.5%", "2.50")
                dt_tx.Rows.Add("CGST@6%", "6.00")
                dt_tx.Rows.Add("CGST@9%", "9.00")
                dt_tx.Rows.Add("CGST@14%", "14.00")

            ElseIf Txt6.Text = "SGST/UTGST" Then
                dt_tx.Rows.Add("SGST/UTGST@0%", "0.00")
                dt_tx.Rows.Add("SGST/UTGST@2.5%", "2.50")
                dt_tx.Rows.Add("SGST/UTGST@6%", "6.00")
                dt_tx.Rows.Add("SGST/UTGST@9%", "9.00")
                dt_tx.Rows.Add("SGST/UTGST@14%", "14.00")
            End If

        ElseIf under = "Sales Account" Then

            dt_tx = New DataTable
            dt_tx.Columns.Add("Name")
            dt_tx.Rows.Add("Not Applicable")
            dt_tx.Rows.Add("GST")
            TAX_Type_Source.DataSource = dt_tx

            dt_tx = New DataTable
            dt_tx.Columns.Add("Name")
            dt_tx.Columns.Add("Pr")

            dt_tx.Rows.Add("SALES EXEMPT", "0.00")
            dt_tx.Rows.Add("SALES NILL RATED", "0.00")
            'dt_tx.Rows.Add("SALES NON-GST", "0.00")
            dt_tx.Rows.Add("SALES GST@0%", "0.00")
            dt_tx.Rows.Add("SALES GST@5%", "5.00")
            dt_tx.Rows.Add("SALES GST@12%", "12.00")
            dt_tx.Rows.Add("SALES GST@18%", "18.00")
            dt_tx.Rows.Add("SALES GST@28%", "28.00")
        ElseIf under = "Purchase Account" Then
            dt_tx = New DataTable
            dt_tx.Columns.Add("Name")
            dt_tx.Rows.Add("Not Applicable")
            dt_tx.Rows.Add("GST")
            TAX_Type_Source.DataSource = dt_tx

            dt_tx = New DataTable
            dt_tx.Columns.Add("Name")
            dt_tx.Columns.Add("Pr")

            dt_tx.Rows.Add("PURCHASE EXEMPT", "0.00")
            dt_tx.Rows.Add("PURCHASE NILL RATED", "0.00")
            'dt_tx.Rows.Add("SALES NON-GST", "0.00")
            dt_tx.Rows.Add("PURCHASE GST@0%", "0.00")
            dt_tx.Rows.Add("PURCHASE GST@5%", "5.00")
            dt_tx.Rows.Add("PURCHASE GST@12%", "12.00")
            dt_tx.Rows.Add("PURCHASE GST@18%", "18.00")
            dt_tx.Rows.Add("PURCHASE GST@28%", "28.00")
        End If


        TAX_Source.DataSource = dt_tx
    End Function
    Private Function Set_Frm()

        Contect_Panel.BringToFront()
        Address_Panel.BringToFront()
        Under_Panel.BringToFront()
        CHEQUE_details.BringToFront()
        Under_Panel.SendToBack()
        Panel5.SendToBack()

        Tax_Registration_Panel.BringToFront()
        communication_panel.BringToFront()
        otherdetails_Panel.BringToFront()
    End Function

    Private Sub Type_of_Duty_TXT_TextChanged(sender As Object, e As EventArgs) Handles Type_of_Duty_TXT.TextChanged

    End Sub
    Private Sub AccountNo_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles AccountNo_TXT.KeyPress
        allow_Number(e)
    End Sub

    Private Sub Opning_Balance_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Opning_Balance_TXT.KeyPress
        allow_Number(e)
    End Sub

    Private Sub Credit_Limit_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Credit_Limit_TXT.KeyPress
        allow_Number(e)
    End Sub

    Private Sub Ledger_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.TYP_TXT.Text = VC_Type_

        BG_frm.HADE_TXT.Text = "Account Ledger"
        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text

        cfg_()
        Total_Opning_balance()
        Button_Clear()
        Button_Manage()
        Load_data_source()

        Branch_Balance_set()

        Name_TXT.Focus()
        'SendKeys.Send("{TAB}")
    End Sub
    Private Function Branch_Balance_set()
        If Branch_Visible() = False Or Group_TXT.Data_Link_ = "7" Then
            Opning_Balance_TXT.ReadOnly = False
        Else
            'Panel21.Visible = True
            'Opning_Balance_TXT.ReadOnly = True

            Opning_Balance_TXT.ReadOnly = False
        End If

    End Function
    Private Function cfg_()
        Create_Database_Table()

        Dim cn As New SQLiteConnection
        open_MSSQL_Cstm(Database_File.lnk, cn)
        cmd = New SQLiteCommand("Select * From cfg_Ledger", cn)
        Dim r As SQLiteDataReader = cmd.ExecuteReader
        While r.Read
            Dim H As String = r("Head").ToString
            Dim V As String = r("Value").ToString


            If H = "Address_YN" Then cfg_Address_YN = YN_Boolean(V, True)
            If H = "Bank_Details_YN" Then cfg_Bank_Details_YN = YN_Boolean(V, False)
            If H = "GST_Details_YN" Then cfg_GST_Details_YN = YN_Boolean(V, True)
            If H = "Credit_Limit_YN" Then cfg_Credit_Limit_YN = YN_Boolean(V, False)
            If H = "Credit_Days_YN" Then cfg_Credit_Days_YN = YN_Boolean(V, False)
            If H = "Communication_YN" Then cfg_Communication_YN = YN_Boolean(V, False)
            If H = "other_YN" Then cfg_other_YN = YN_Boolean(V, False)
        End While
        r.Close()

        Panel10.Visible = cfg_Address_YN
        Bank_Panel.Visible = cfg_Bank_Details_YN
        Tax_Registration_Panel.Visible = cfg_GST_Details_YN
        Credit_Panel.Visible = cfg_Credit_Limit_YN
        Credit_Days_Panel.Visible = cfg_Credit_Days_YN

    End Function
    Private Function Applay_cfg()

    End Function
    Private Sub Ledger_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End
        Ledger_Branch_Balance.Dispose()
        Add_Hander_Remove_Handel(False)
        Frm_foCus()
    End Sub
    Private Function Save_Data()
        If Save_Requr() = True Then
            If Insurt_Audit() = True Then
                If Insurt_Value() = True Then
                    If Insurt_Cheaqu_data() = True Then
                        If Insurt_Ledger_Branch_Value() = True Then
                            If Document_Save() = True Then
                                Clear_all()
                            End If
                        Else

                        End If
                    End If
                End If
            End If
        Else
        End If
    End Function
    Private Function Delete_Data()
        Dim cn As New SQLiteConnection
        open_MSSQL_Cstm(Database_File.cre, cn)

        If Chack_Delete_Allow() = True Then
            If Msg_Delete_YN(Name_TXT, "Ledger") = DialogResult.Yes Then
                If Insurt_Audit() = True Then
                    If open_MSSQL(Database_File.cre) = True Then
                        qury = $"DELETE FROM TBL_Ledger Where ID = '{VC_ID_}';
DELETE FROM TBL_Ledger_Opning_Balance Where Ledger_ID = '{VC_ID_}';
"
                        cmd = New SQLiteCommand(qury, cn)
                        cmd.ExecuteNonQuery()
                        Clear_all()
                    End If
                End If
            End If
        Else
            Msg(NOT_Type.Info, "You cannot delete", "You cannot delete this ledger because the ledger you selected is made up of vouchers")
        End If
    End Function
    Dim visible As String = "Approval"
    Private Function Chack_Delete_Allow() As Boolean
        Dim isavalable As Boolean = True
        If visible = "Defolt" Then
            Return False
        End If

        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select count(*) as count, 'Vouchers' as Type From TBL_VC_Ledger vc where 
(vc.Ledger = '{VC_ID_}')

UNION ALL

Select count(*) as count, 'Defolt Ledger' as Type From TBL_Ledger ld WHERE
ld.id = '{VC_ID_}' and
ld.Company = 'All'", cn)

            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                If Val(r("count")) <> 0 Then
                    If isavalable = True Then
                        isavalable = False
                    End If
                End If
            End While
        End If

        Return isavalable
    End Function

    Dim Duplicate_Type As String
    Dim Duplicate_Type1 As String

    Dim Duplicate_Alias_Type As String
    Dim Duplicate_Alias_Type1 As String
    Private Function Save_Requr() As Boolean
        If Name_TXT.Text = "" Then
            Msg_Custom_YN(NOT_Location.Center, Color.OrangeRed, My.Resources.Error_animation_icn, Dialoag_Button.Ok, "Input Error", "Name", "Please enter name and try agin")
            Name_TXT.Focus()
            Return False
            Exit Function
        End If
        If Name_TXT.Text = Alias_TXT.Text Then
            Msg_Custom_YN(NOT_Location.Center, Color.OrangeRed, My.Resources.Error_animation_icn, Dialoag_Button.Ok, "Duplicate", "Name & Alias", "Name and Alias are the same")

            Alias_TXT.Focus()
            Return False
            Exit Function
        End If
        If Chack_Duplicate(Database_File.cre, "TBL_Ledger", "Name", Duplicate_Type) = True Then
            Msg_Custom_YN(NOT_Location.Center, Color.OrangeRed, My.Resources.Error_animation_icn, Dialoag_Button.Ok, "Duplicate", "Name", "Name already exists please change name and try again")

            Name_TXT.Focus()
            Return False
            Exit Function
        End If
        If Chack_Duplicate(Database_File.cre, "TBL_Ledger", "Alise", Duplicate_Type1) = True Then
            Msg(NOT_Type.Erro, "Duplicate - Name", "Name already exists please change name and try again")
            Name_TXT.Focus()
            Return False
            Exit Function
        End If
        '//
        If Chack_Duplicate(Database_File.cre, "TBL_Ledger", "Name", Duplicate_Alias_Type) = True Then
            Msg(NOT_Type.Erro, "Duplicate - Alias", "Alias already exists please change alias and try again")
            Name_TXT.Focus()
            Return False
            Exit Function
        End If
        If Chack_Duplicate(Database_File.cre, "TBL_Ledger", "Alise", Duplicate_Alias_Type1) = True And Alias_TXT.Text <> "" Then
            Msg(NOT_Type.Erro, "Duplicate - Alias", "Alias already exists please change alias and try again")
            Name_TXT.Focus()
            Return False
            Exit Function
        End If
        If Group_TXT.Text = "Primary" Then
            Under_ID = "0"
        ElseIf Chack_Duplicate(Database_File.cre, "TBL_Acc_Group", "Name", " Name = '" & Group_TXT.Text & "'") = False Then
            Msg(NOT_Type.Erro, "Selection Error - Under Group", "Under Group select error, Please select again")
            Group_TXT.Focus()
            Return False
            Exit Function
        Else
            Under_ID = Find_DT_Value(Database_File.cre, "TBL_Acc_Group", "ID", " Name = '" & Group_TXT.Text & "'")
        End If

        If Chack_Duty_data() = False Then
            Txt6.Focus()
            Exit Function
        End If

        Return True
    End Function
    Private Function Chack_Duty_data() As Boolean
        Dim cn As New SQLiteConnection

        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            If Group_TXT.Text = "Duties & Taxes" Then
                cmd = New SQLiteCommand($"Select PercentageOfCalculation as p From TBL_Ledger where TAX_Type = '{Txt5.Text}' and TAX_Class = '{Txt6.Text}' and Visible = 'Approval'", cn)
                Dim r As SQLiteDataReader
                r = cmd.ExecuteReader
                While r.Read
                    If Val(r("p").ToString) = Val(Label72.Text) Then
                        r.Close()
                        cn.Close()
                        Msg_Custom_YN(NOT_Location.Bottom_Right, Color.Red, My.Resources.Error_animation_icn, Dialoag_Button.Ok, "Oops!", Type_of_Duty_TXT.Text, "Since the tax you entered has<nl>already been created,<nl>you cannot create more than<nl>1 tax of the same percentage.")
                        Return False
                    End If
                End While
            End If

        End If





        Return True
    End Function
    Private Function Insurt_Audit() As Boolean
        If Val(VC_ID_) = 0 Then
            Return True
        End If

        If Audit_Save("TBL_Ledger", "ID", VC_ID_) = True Then
            If Audit_Save("TBL_Ledger_Opning_Balance", "Ledger_ID", VC_ID_) = True Then
                Return True
            End If
        End If
    End Function
    Private Function Insurt_Value() As Boolean
        If VC_Type_ = "Create" OrElse VC_Type_ = "Create_Close" Then
            If open_MSSQL(Database_File.cre) = True Then
                qury = "INSERT INTO TBL_Ledger (Name,Alise,[Group],Phone,Email,Country,PinCode,State,Dis,Taluka,City,Address,OB_CR,OB_DR,Cradit,Cradit_Days,GST_Type,GSTNo,PANCardNo,DocumentType,DocumentNo,BankName,AccountNo,Branch,IFSCCode,Company,Visible,TypeOfDuty,TAX_Type,TAX_Class,PercentageOfCalculation,Discription,Note,[User],Date_install,PC,Communication_Type,Communication_Whatsapp,Communication_Email,CHEQUE_Print,Aadhaar,DOB) 
VALUES 
(@Name, @Alise, @Group, @Phone, @Email,@Country, @PinCode, @State, @Dis,@Taluka, @City, @Address, @OB_CR, @OB_DR, @Cradit,@Cradit_Days, @GST_Type,@GSTNo, @PANCardNo, @DocumentType, @DocumentNo, @BankName, @AccountNo, @Branch, @IFSCCode, @Company, @Visible, @TypeOfDuty, @TAX_Type, @TAX_Class,@PercentageOfCalculation,@Discription,@Note,@User,@Install_,@PC,@comType,@w,@e,@CHEQUE_Print,@Aadhaar,@DOB)"
                cmd = New SQLiteCommand(qury, con)
                Try
                    With cmd.Parameters
                        .AddWithValue("@Name", Name_TXT.Text.Trim)
                        .AddWithValue("@Alise", Alias_TXT.Text.Trim)
                        .AddWithValue("@Group", Under_ID.Trim)
                        .AddWithValue("@Phone", Phone_TXT.Text.Trim)
                        .AddWithValue("@Email", Email_TXT.Text.Trim)
                        .AddWithValue("@Country", Txt1.Text.Trim)
                        .AddWithValue("@PinCode", Pincode_TXT.Text.Trim)
                        .AddWithValue("@State", State_TXT.Text.Trim)
                        .AddWithValue("@Dis", Districe_TXT.Text.Trim)
                        .AddWithValue("@Taluka", Taluka_TXT.Text.Trim)
                        .AddWithValue("@City", City_TXT.Text.Trim)
                        .AddWithValue("@Address", Address_TXT.Text.Trim)

                        .AddWithValue("@comType", Txt4.Text)
                        .AddWithValue("@w", whatsapp_yn.Text)
                        .AddWithValue("@e", email_yn.Text)

                        .AddWithValue("@Aadhaar", Aadhaar_TXT.Text)
                        If DOB_TXT.Text = Nothing Then
                            .AddWithValue("@DOB", DBNull.Value)
                        Else
                            .AddWithValue("@DOB", CDate(DOB_TXT.Text))
                        End If

                        If Txt3.Text = "Cr" Then
                            .AddWithValue("@OB_CR", Val(Opning_Balance_TXT.Text.Trim))
                            .AddWithValue("@OB_DR", "0.00")
                        Else
                            .AddWithValue("@OB_CR", "0.00")
                            .AddWithValue("@OB_DR", Val(Opning_Balance_TXT.Text.Trim))
                        End If



                        .AddWithValue("@Cradit", Val(Credit_Limit_TXT.Text.Trim))
                        .AddWithValue("@Cradit_Days", Val(Txt9.Text.Trim))
                        .AddWithValue("@GST_Type", Txt2.Text.Trim)
                        .AddWithValue("@GSTNo", GST_TXT.Text.Trim)
                        .AddWithValue("@PANCardNo", PAN_TXT.Text.Trim)
                        .AddWithValue("@DocumentType", "".Trim)
                        .AddWithValue("@DocumentNo", "".Trim)
                        .AddWithValue("@BankName", Bank_TXT.Text.Trim)
                        .AddWithValue("@AccountNo", AccountNo_TXT.Text.Trim)
                        .AddWithValue("@Branch", Branch_TXT.Text.Trim)
                        .AddWithValue("@IFSCCode", IFSC_TXT.Text.Trim)
                        .AddWithValue("@Company", Company_ID_str.Trim)
                        .AddWithValue("@Visible", visible)
                        .AddWithValue("@Discription", Discription_TXT.Text.Trim)
                        .AddWithValue("@Note", Note_TXT.Text.Trim)

                        .AddWithValue("@TypeOfDuty", Type_of_Duty_TXT.Text.Trim)

                        .AddWithValue("@CHEQUE_Print", Yn5.Text)

                        .AddWithValue("@TAX_Type", (Txt5.Text))
                        .AddWithValue("@PercentageOfCalculation", Val(Label72.Text))
                        .AddWithValue("@TAX_Class", (Txt6.Text))
                        .AddWithValue("@User", LOGIN_ID.Trim)
                        .AddWithValue("@PC", PC_ID.Trim)
                        .AddWithValue("@Install_", CDate(DateTime.Now))
                        cmd.ExecuteNonQuery()
                    End With
                    VC_ID_ = Find_DT_Value(Database_File.cre, "TBL_Ledger", "ID", $"Name = '{Name_TXT.Text}'")
                    Return True
                Catch ex As Exception
                    Msg(NOT_Type.Erro, "Data Save Error", ex.Message)
                    Return False
                End Try
            End If
        Else
            If open_MSSQL(Database_File.cre) Then
                qury = $"UPDATE TBL_Ledger SET Name = @Name,Alise = @Alise,[Group] = @Group,Phone = @Phone,Email = @Email,Country = @Country,PinCode = @PinCode,State = @State,Dis = @Dis,Taluka = @Taluka,City = @City,Address = @Address,OB_CR = @OB_CR,OB_DR = @OB_DR,Cradit = @Cradit,Cradit_Days = @Cradit_Days,GSTNo = @GSTNo,GST_Type = @GST_Type,PANCardNo = @PANCardNo,DocumentType = @DocumentType,DocumentNo = @DocumentNo,BankName = @BankName,AccountNo = @AccountNo,Branch = @Branch,IFSCCode = @IFSCCode,Visible = @Visible,TypeOfDuty = @TypeOfDuty,TAX_Type = @TAX_Type,TAX_Class = @TAX_Class,PercentageOfCalculation = @PercentageOfCalculation,Discription = @Discription,Note = @Note,[User] = @User,Date_Install = @Install_,PC = @PC,Communication_Type = @comType,Communication_Whatsapp = @w,Communication_Email = @e,CHEQUE_Print = @CHEQUE_Print,Aadhaar = @Aadhaar,DOB = @DOB WHERE ID = '{VC_ID_}'"
                cmd = New SQLiteCommand(qury, con)

                Try
                    With cmd.Parameters
                        .AddWithValue("@Name", Name_TXT.Text.Trim)
                        .AddWithValue("@Alise", Alias_TXT.Text.Trim)
                        .AddWithValue("@Group", Under_ID.Trim)
                        .AddWithValue("@Phone", Phone_TXT.Text.Trim)
                        .AddWithValue("@Email", Email_TXT.Text.Trim)
                        .AddWithValue("@Country", Txt1.Text.Trim)
                        .AddWithValue("@PinCode", Pincode_TXT.Text.Trim)
                        .AddWithValue("@State", State_TXT.Text.Trim)
                        .AddWithValue("@Dis", Districe_TXT.Text.Trim)
                        .AddWithValue("@Taluka", Taluka_TXT.Text.Trim)
                        .AddWithValue("@City", City_TXT.Text.Trim)
                        .AddWithValue("@Address", Address_TXT.Text.Trim)

                        .AddWithValue("@comType", Txt4.Text)
                        .AddWithValue("@w", whatsapp_yn.Text)
                        .AddWithValue("@e", email_yn.Text)

                        .AddWithValue("@Aadhaar", Aadhaar_TXT.Text)
                        If DOB_TXT.Text = Nothing Then
                            .AddWithValue("@DOB", DBNull.Value)
                        Else
                            .AddWithValue("@DOB", CDate(DOB_TXT.Text))
                        End If
                        .AddWithValue("@CHEQUE_Print", Yn5.Text)


                        If Branch_Visible() = True Or Branch_YN_fech = False Then
                            If Txt3.Text = "Cr" Then
                                .AddWithValue("@OB_CR", Val(Opning_Balance_TXT.Text.Trim))
                                .AddWithValue("@OB_DR", "0.00")
                            Else
                                .AddWithValue("@OB_CR", "0.00")
                                .AddWithValue("@OB_DR", Val(Opning_Balance_TXT.Text.Trim))
                            End If
                        ElseIf Branch_ID <> "0" Then
                            .AddWithValue("@OB_CR", Find_DT_Value(Database_File.cre, "TBL_Ledger", "OB_CR", $"Id = '{VC_ID_}'"))
                            .AddWithValue("@OB_DR", Find_DT_Value(Database_File.cre, "TBL_Ledger", "OB_DR", $"Id = '{VC_ID_}'"))
                        End If
                        .AddWithValue("@Cradit", Val(Credit_Limit_TXT.Text.Trim))
                        .AddWithValue("@Cradit_Days", Val(Txt9.Text.Trim))
                        .AddWithValue("@GST_Type", Txt2.Text.Trim)
                        .AddWithValue("@GSTNo", GST_TXT.Text.Trim)
                        .AddWithValue("@PANCardNo", PAN_TXT.Text.Trim)
                        .AddWithValue("@DocumentType", "".Trim)
                        .AddWithValue("@DocumentNo", "".Trim)
                        .AddWithValue("@BankName", Bank_TXT.Text.Trim)
                        .AddWithValue("@AccountNo", AccountNo_TXT.Text.Trim)
                        .AddWithValue("@Branch", Branch_TXT.Text.Trim)
                        .AddWithValue("@IFSCCode", IFSC_TXT.Text.Trim)
                        .AddWithValue("@C_ID", Company_ID_str.Trim)
                        .AddWithValue("@Visible", visible)
                        .AddWithValue("@Discription", Discription_TXT.Text.Trim)
                        .AddWithValue("@Note", Note_TXT.Text.Trim)

                        .AddWithValue("@TypeOfDuty", Type_of_Duty_TXT.Text.Trim)

                        .AddWithValue("@PercentageOfCalculation", Val(Label72.Text))
                        .AddWithValue("@TAX_Class", (Txt6.Text))
                        .AddWithValue("@TAX_Type", (Txt5.Text))
                        .AddWithValue("@User", LOGIN_ID.Trim)
                        .AddWithValue("@PC", PC_ID.Trim)
                        .AddWithValue("@Install_", CDate(DateTime.Now))
                        cmd.ExecuteNonQuery()
                    End With
                    Return True
                Catch ex As Exception
                    Msg(NOT_Type.Erro, "Data Save Error", ex.Message)
                    Return False
                End Try
            End If
        End If
    End Function
    Private Function Insurt_Cheaqu_data() As Boolean
        If (Group_TXT.Text = "Bank Accounts" Or Label16.Text = "Bank Accounts") Or (Group_TXT.Text = "Bank OD A/c" Or Label16.Text = "Bank OD A/c") Then
            Dim cn As New SQLiteConnection
            If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                cmd = New SQLiteCommand($"Delete From TBL_Cheque_Design where Ledger_ID = '{VC_ID_}'", cn)
                cmd.ExecuteNonQuery()

                cmd = New SQLiteCommand($"INSERT INTO TBL_Cheque_Design (Ledger_ID,Width,Height,Cross_Top,Cross_Left,Date_Top,Date_Left,Date_Format,Date_Separator,Date_Distance,Party_Top,Party_Left,Party_Width,Amount_Word_1_Top,Amount_Word_1_Left,Amount_Word_1_Width,Amount_Word_2_Top,Amount_Word_2_Left,Amount_Word_2_Width,Amount_Top,Amount_Left,Amount_Width) VALUES (@Ledger_ID,@Width,@Height,@Cross_Top,@Cross_Left,@Date_Top,@Date_Left,@Date_Format,@Date_Separator,@Date_Distance,@Party_Top,@Party_Left,@Party_Width,@Amount_Word_1_Top,@Amount_Word_1_Left,@Amount_Word_1_Width,@Amount_Word_2_Top,@Amount_Word_2_Left,@Amount_Word_2_Width,@Amount_Top,@Amount_Left,@Amount_Width)", cn)
                Try
                    With cmd.Parameters
                        .AddWithValue("@Ledger_ID", VC_ID_)
                        .AddWithValue("@Width", Cheque_Width)
                        .AddWithValue("@Height", Cheque_Height)
                        .AddWithValue("@Cross_Top", Cheque_Cross_Top)
                        .AddWithValue("@Cross_Left", Cheque_Cross_Left)
                        .AddWithValue("@Date_Top", Cheque_Date_Top)
                        .AddWithValue("@Date_Left", Cheque_Date_Left)
                        .AddWithValue("@Date_Format", Cheque_Date_Format)
                        .AddWithValue("@Date_Separator", Cheque_Date_Separator)
                        .AddWithValue("@Date_Distance", Cheque_Date_Distance)
                        .AddWithValue("@Party_Top", Cheque_Party_Top)
                        .AddWithValue("@Party_Left", Cheque_Party_Left)
                        .AddWithValue("@Party_Width", Cheque_Party_area)
                        .AddWithValue("@Amount_Word_1_Top", Cheque_AmountW1_Top)
                        .AddWithValue("@Amount_Word_1_Left", Cheque_AmountW1_Left)
                        .AddWithValue("@Amount_Word_1_Width", Cheque_AmountW1_Width)
                        .AddWithValue("@Amount_Word_2_Top", Cheque_AmountW2_Top)
                        .AddWithValue("@Amount_Word_2_Left", Cheque_AmountW2_Left)
                        .AddWithValue("@Amount_Word_2_Width", Cheque_AmountW2_Width)
                        .AddWithValue("@Amount_Top", Cheque_Amount_Top)
                        .AddWithValue("@Amount_Left", Cheque_Amount_Left)
                        .AddWithValue("@Amount_Width", Cheque_Amount_Width)
                        cmd.ExecuteNonQuery()
                    End With
                Catch ex As Exception

                End Try
            End If
        End If

        Return True
    End Function
    Private Function Insurt_Ledger_Branch_Value() As Boolean
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            If Branch_Visible() = True Then
                cmd = New SQLiteCommand($"Delete From TBL_Ledger_Opning_Balance where Ledger_ID = '{VC_ID_}'", cn)
                cmd.ExecuteNonQuery()
            Else 'If Branch_ID <> "0" Then
                cmd = New SQLiteCommand($"Delete From TBL_Ledger_Opning_Balance where Ledger_ID = '{VC_ID_}' and (Branch_ID = {Branch_ID} or Branch_ID = '0')", cn)
                cmd.ExecuteNonQuery()
            End If

            If ((Ob_Panel.Visible = True)) Then

                'Return True
            End If

            Dim id As String = Find_DT_Value(Database_File.cre, "TBL_Ledger", "ID", $"Name = '{Name_TXT.Text}' and Visible = 'Approval'")

            Dim q As String = "INSERT INTO TBL_Ledger_Opning_Balance (Ledger_ID,Branch_ID,Applicable,OB_Dr,OB_Cr) VALUES (@Ledger_ID,@Branch_ID,@Applicable,@OB_Dr,@OB_Cr)"

            Try
                If Branch_Visible() = True Then
                    With Ledger_Branch_Balance.Ledger_Branch_Balance_ctrl1
                        Dim P_ As New Queue(Of Panel)()
                        For Each bg_p As Panel In .platform.Controls.OfType(Of Panel)()
                            P_.Enqueue(bg_p)
                        Next
                        Dim vl As Decimal = 0

                        Dim dr As Decimal = 0
                        Dim cr As Decimal = 0

                        For Each bg_p As Panel In P_.Reverse
                            Dim idx As Integer = .Find_Idx(bg_p)
                            'Branch Wais Save

                            If .Find_Bal_Type(idx).Text = "Dr" Then
                                dr = Val(.Find_Bal_Vall(idx).Text)
                                cr = 0
                            Else
                                cr = Val(.Find_Bal_Vall(idx).Text)
                                dr = 0
                            End If

                            cmd = New SQLiteCommand(q, cn)
                            cmd.Parameters.AddWithValue("@Ledger_ID", id)
                            cmd.Parameters.AddWithValue("@Branch_ID", .Find_Branch_ID(idx).Text)
                            cmd.Parameters.AddWithValue("@Applicable", .Find_Applicap(idx).Text)
                            cmd.Parameters.AddWithValue("@OB_Dr", Val(dr))
                            cmd.Parameters.AddWithValue("@OB_Cr", Val(cr))
                            cmd.ExecuteNonQuery()
                        Next

                        If Txt3.Text = "Dr" Then
                            dr = Val(Opning_Balance_TXT.Text)
                            cr = 0
                        Else
                            cr = Val(Opning_Balance_TXT.Text)
                            dr = 0
                        End If

                        'Head Save
                        cmd = New SQLiteCommand(q, cn)
                        cmd.Parameters.AddWithValue("@Ledger_ID", id)
                        cmd.Parameters.AddWithValue("@Branch_ID", "0")
                        cmd.Parameters.AddWithValue("@Applicable", "Yes")
                        cmd.Parameters.AddWithValue("@OB_Dr", Val(dr))
                        cmd.Parameters.AddWithValue("@OB_Cr", Val(cr))
                        cmd.ExecuteNonQuery()
                    End With
                Else
                    Dim dr As Decimal = 0
                    Dim cr As Decimal = 0

                    If Txt3.Text = "Dr" Then
                        dr = Val(Opning_Balance_TXT.Text)
                        cr = 0
                    Else
                        cr = Val(Opning_Balance_TXT.Text)
                        dr = 0
                    End If

                    cmd = New SQLiteCommand(q, cn)
                    cmd.Parameters.AddWithValue("@Ledger_ID", id)
                    cmd.Parameters.AddWithValue("@Branch_ID", Branch_ID)
                    cmd.Parameters.AddWithValue("@Applicable", "Yes")
                    cmd.Parameters.AddWithValue("@OB_Dr", Val(dr))
                    cmd.Parameters.AddWithValue("@OB_Cr", Val(cr))
                    cmd.ExecuteNonQuery()


                    'Alter Head ID

                    If Branch_ID <> "0" Then
                        dr = Val(Find_DT_Value_SUM(Database_File.cre, "TBL_Ledger_Opning_Balance", "OB_Dr", $"Ledger_ID = '{id}'"))
                        cr = Val(Find_DT_Value_SUM(Database_File.cre, "TBL_Ledger_Opning_Balance", "OB_Cr", $"Ledger_ID = '{id}'"))

                        Dim vlu As Decimal = cr - dr

                        cmd = New SQLiteCommand(q, cn)
                        cmd.Parameters.AddWithValue("@Ledger_ID", Find_DT_Value(Database_File.cre, "TBL_Ledger", "ID", $"Name = '{Name_TXT.Text}'"))
                        cmd.Parameters.AddWithValue("@Branch_ID", "0")
                        cmd.Parameters.AddWithValue("@Applicable", "Yes")
                        If vlu = 0 Then
                            dr = 0
                            cr = 0
                        ElseIf vlu > 0 Then
                            dr = 0
                            cr = vlu
                        Else
                            cr = 0
                            dr = (vlu * -1)
                        End If

                        cmd.Parameters.AddWithValue("@OB_Dr", Val(dr))
                        cmd.Parameters.AddWithValue("@OB_Cr", Val(cr))
                        cmd.ExecuteNonQuery()
                    End If

                End If

            Catch ex As Exception
                Msg(NOT_Type.Erro, "'Ledger Branch Opning Balance' Save Error", ex.Message)
                Return False
            End Try
        End If

        Return True
    End Function
    Private Function Document_Save() As Boolean
        If open_MSSQL(Database_File.rec) = True Then
            qury = "INSERT INTO TBL_Attage (Name,Narration,TBL,TBL_ID,Attage,Attage_Type,Password,[User],Date_install,PC,Visible) VALUES (@Name,@Narration,@TBL,@TBL_ID,@Attage,@Attage_Type,@Password,@User,@Install_,@PC,@Visible)"
            For i As Integer = 0 To DataGridView1.Rows.Count - 1
                Dim ro As DataGridViewRow = DataGridView1.Rows(i)
                If ro.Cells(0).Value = "0" Then
                    cmd = New SQLiteCommand(qury, con)
                    Dim Byt As Byte()
                    Byt = DirectCast(ro.Cells(4).Value, Byte())
                    Try
                        With cmd.Parameters
                            .AddWithValue("@Name", ro.Cells(1).Value)
                            .AddWithValue("@Narration", ro.Cells(2).Value)
                            .AddWithValue("@TBL", "Ledger")
                            .AddWithValue("@TBL_ID", Find_DT_Value(Database_File.cre, "TBL_Ledger", "ID", "Name = '" & Name_TXT.Text & "'"))
                            .AddWithValue("@Attage", Byt)
                            .AddWithValue("@Attage_Type", ro.Cells(3).Value)
                            .AddWithValue("@Password", ro.Cells(5).Value)
                            .AddWithValue("@User", LOGIN_ID)
                            .AddWithValue("@Install_", CDate(DateTime.Now))
                            .AddWithValue("@PC", PC_ID.Trim)
                            .AddWithValue("@Visible", "Approval")
                            cmd.ExecuteNonQuery()
                        End With
                    Catch ex As Exception
                        Msg(NOT_Type.Erro, "Data Save Error", ex.Message)
                        Return False
                    End Try
                End If
            Next
        End If
        Return True
    End Function
    Private Function Clear_all()
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            'BG_frm.Ledger_BS.DataSource = Nothing
            'BG_frm.Ledger_BS.DataSource = Fill_Ledger(cn)

            'BG_frm.Branch_BS.DataSource = Nothing
            'BG_frm.Branch_BS.DataSource = Fill_Branch(cn)
        End If

        Ledger_Branch_Balance.Dispose()
        If VC_Type_ = "Create" Then
            Total_Opning_balance()
            Name_TXT.Text = ""
            Alias_TXT.Text = ""
            Type_of_Duty_TXT.Text = ""
            Label72.Text = ""
            Email_TXT.Text = ""
            Phone_TXT.Text = ""
            GST_TXT.Text = ""
            PAN_TXT.Text = ""
            Pincode_TXT.Text = ""
            State_TXT.Text = ""
            Districe_TXT.Text = ""
            Taluka_TXT.Text = ""
            City_TXT.Text = ""
            Bank_TXT.Text = ""
            Branch_TXT.Text = ""
            IFSC_TXT.Text = ""
            AccountNo_TXT.Text = ""
            Opning_Balance_TXT.Text = ""
            Credit_Limit_TXT.Text = ""
            Aadhaar_TXT.Text = ""
            DOB_TXT.Text = ""
            Name_TXT.Focus()
            NOT_("The entry you entered has been successfully accepted", NOT_Type.Success)
            DataGridView1.Rows.Clear()
        ElseIf VC_Type_ = "Alter_Close" Or VC_Type_ = "Create_Close" Then
            If close_link_yn = True Then
                close_focus_obj.Text = Name_TXT.Text
            End If

            Me.Dispose()
            close_focus_obj.Focus()
        ElseIf VC_Type_ = "Alter" Then
            Me.Dispose()
        End If
    End Function

    Private Function Display_Fill_All()
        Name_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Name", "ID = '" & VC_ID_ & "'")
        Alias_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Alise", "ID = '" & VC_ID_ & "'")
        Discription_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Discription", "ID = '" & VC_ID_ & "'")
        Note_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Note", "ID = '" & VC_ID_ & "'")
        Under_ID = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Group", "ID = '" & VC_ID_ & "'")
        Under = Find_DT_Value(Database_File.cre, "TBL_Acc_Group", "Name", "ID = '" & Under_ID & "'")
        Label16.Text = Under

        Group_TXT.Data_Link_ = Under_ID

        If Under <> "" Then
            Group_TXT.Text = Under
        Else
            Group_TXT.Text = "Primary"
        End If

        Txt5.Text = Find_DT_Value(Database_File.cre, "TBL_Ledger", "TAX_Type", "ID = '" & VC_ID_ & "'")
        Type_of_Duty_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Ledger", "TypeOfDuty", "ID = '" & VC_ID_ & "'")

        Label72.Text = nUmBeR_FORMATE(Find_DT_Value(Database_File.cre, "TBL_Ledger", "PercentageOfCalculation", "ID = '" & VC_ID_ & "'"))
        Txt6.Text = (Find_DT_Value(Database_File.cre, "TBL_Ledger", "TAX_Class", "ID = '" & VC_ID_ & "'"))

        Email_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Email", "ID = '" & VC_ID_ & "'")

        Phone_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Phone", "ID = '" & VC_ID_ & "'")

        Txt2.Text = Find_DT_Value(Database_File.cre, "TBL_Ledger", "GST_Type", "ID = '" & VC_ID_ & "'").ToString.Trim

        GST_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Ledger", "GSTNo", "ID = '" & VC_ID_ & "'")

        PAN_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Ledger", "PANCardNo", "ID = '" & VC_ID_ & "'")

        Txt1.Text = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Country", "ID = '" & VC_ID_ & "'")

        Pincode_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Ledger", "PinCode", "ID = '" & VC_ID_ & "'")

        State_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Ledger", "State", "ID = '" & VC_ID_ & "'")

        Districe_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Dis", "ID = '" & VC_ID_ & "'")

        Taluka_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Taluka", "ID = '" & VC_ID_ & "'")

        City_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Ledger", "City", "ID = '" & VC_ID_ & "'")

        Address_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Address", "ID = '" & VC_ID_ & "'")

        Bank_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Ledger", "BankName", "ID = '" & VC_ID_ & "'")

        Branch_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Branch", "ID = '" & VC_ID_ & "'")

        IFSC_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Ledger", "IFSCCode", "ID = '" & VC_ID_ & "'")

        AccountNo_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Ledger", "AccountNo", "ID = '" & VC_ID_ & "'")

        Credit_Limit_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Cradit", "ID = '" & VC_ID_ & "'")
        Txt9.Text = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Cradit_Days", "ID = '" & VC_ID_ & "'")

        visible = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Visible", "ID = '" & VC_ID_ & "'")

        Yn5.Text = (Find_DT_Value(Database_File.cre, "TBL_Ledger", "CHEQUE_Print", "ID = '" & VC_ID_ & "'"))

        Txt4.Text = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Communication_Type", "ID = '" & VC_ID_ & "'")
        whatsapp_yn.Text = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Communication_Whatsapp", "ID = '" & VC_ID_ & "'")
        email_yn.Text = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Communication_Email", "ID = '" & VC_ID_ & "'")

        Aadhaar_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Aadhaar", "ID = '" & VC_ID_ & "'")
        Try
            DOB_TXT.Text = CDate(Find_DT_Value(Database_File.cre, "TBL_Ledger", "DOB", "ID = '" & VC_ID_ & "'"))
        Catch ex As Exception

        End Try

        If Txt4.Text = Nothing Then
            Txt4.Text = "By Group (Default)"
        End If

        Dim Cr_o As Decimal = 0
        Dim Dr_o As Decimal = 0

        If Branch_Visible() = True Or Branch_YN_fech = False Then
            Cr_o = Val(Find_DT_Value_SUM(Database_File.cre, "TBL_Ledger_Opning_Balance", "OB_Cr", $"Ledger_ID = '{VC_ID_}' and Branch_Id = '0'"))
            Dr_o = Val(Find_DT_Value_SUM(Database_File.cre, "TBL_Ledger_Opning_Balance", "OB_Dr", $"Ledger_ID = '{VC_ID_}' and Branch_Id = '0'"))
        Else
            Cr_o = Val(Find_DT_Value_SUM(Database_File.cre, "TBL_Ledger_Opning_Balance", "OB_Cr", $"Ledger_ID = '{VC_ID_}' and Branch_Id = '{Branch_ID}'"))
            Dr_o = Val(Find_DT_Value_SUM(Database_File.cre, "TBL_Ledger_Opning_Balance", "OB_Dr", $"Ledger_ID = '{VC_ID_}' and Branch_Id = '{Branch_ID}'"))
        End If

        Dim Balance_ As Decimal = Cr_o - Dr_o

        If Balance_ > 0 Then
            Opning_Balance_TXT.Text = Balance_
            Txt3.Text = "Cr"
        ElseIf Balance_ < 0 Then
            Opning_Balance_TXT.Text = (Balance_ * -1)
            Txt3.Text = "Dr"
        End If

        Set_Under(Under)
        Fill_Attage()
        Load_Cheaqe_data()

    End Function
    Private Function Load_Cheaqe_data()
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select * From TBL_Cheque_Design where Ledger_ID = '{VC_ID_}'", cn)
            Dim r As SQLiteDataReader = cmd.ExecuteReader
            While r.Read
                Cheque_Width = Val(r("Width").ToString)
                Cheque_Height = Val(r("Height").ToString)
                Cheque_Cross_Top = Val(r("Cross_Top").ToString)
                Cheque_Cross_Left = Val(r("Cross_Left").ToString)
                Cheque_Date_Top = Val(r("Date_Top").ToString)
                Cheque_Date_Left = Val(r("Date_Left").ToString)
                Cheque_Date_Format = (r("Date_Format").ToString)
                Cheque_Date_Separator = (r("Date_Separator").ToString)
                Cheque_Date_Distance = Val(r("Date_Distance").ToString)
                Cheque_Party_Top = Val(r("Party_Top").ToString)
                Cheque_Party_Left = Val(r("Party_Left").ToString)
                Cheque_Party_area = Val(r("Party_Width").ToString)
                Cheque_AmountW1_Top = Val(r("Amount_Word_1_Top").ToString)
                Cheque_AmountW1_Left = Val(r("Amount_Word_1_Left").ToString)
                Cheque_AmountW1_Width = Val(r("Amount_Word_1_Width").ToString)
                Cheque_AmountW2_Top = Val(r("Amount_Word_2_Top").ToString)
                Cheque_AmountW2_Left = Val(r("Amount_Word_2_Left").ToString)
                Cheque_AmountW2_Width = Val(r("Amount_Word_2_Width").ToString)
                Cheque_Amount_Top = Val(r("Amount_Top").ToString)
                Cheque_Amount_Left = Val(r("Amount_Left").ToString)
                Cheque_Amount_Width = Val(r("Amount_Width").ToString)

            End While
            r.Close()
        End If
    End Function
    Private Function Fill_Attage()
        If open_MSSQL(Database_File.rec) = True Then
            DataGridView1.Rows.Clear()
            qury = "Select * From TBL_Attage where TBL = 'Ledger' and TBL_ID = '" & VC_ID_ & "' and Visible = 'Approval'"
            cmd = New SQLiteCommand(qury, con)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                DataGridView1.Rows.Add(r("ID"), r("Name"), r("Narration"), r("Attage_Type"), r("Attage"), r("Password"))
            End While
        End If
    End Function
    Private Sub Pincode_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles Pincode_TXT.KeyDown

        If e.KeyCode = Keys.F10 Then

        End If

    End Sub

    Private Sub Email_TXT_LostFocus(sender As Object, e As EventArgs) Handles Email_TXT.LostFocus

    End Sub

    Private Sub Email_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Email_TXT.KeyPress
        If e.KeyChar = ChrW(Keys.Space) Then
            e.Handled = True
        End If
    End Sub
    Private Function Name_aLlow() As Boolean
        If BG_frm.From_ID = From_ID Then
            Alisa_aLlow()
            If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
                Duplicate_Type = " Name = '" & Name_TXT.Text & "' COLLATE NOCASE and " & Company_Visible_Filter()
            Else
                Duplicate_Type = " Name = '" & Name_TXT.Text & "' COLLATE NOCASE and ID <> '" & VC_ID_ & "' and " & Company_Visible_Filter()
            End If

            If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
                Duplicate_Type1 = " Alise = '" & Name_TXT.Text & "' COLLATE NOCASE  and " & Company_Visible_Filter()
            Else
                Duplicate_Type1 = " Alise = '" & Name_TXT.Text & "' COLLATE NOCASE  and ID <> '" & VC_ID_ & "' and " & Company_Visible_Filter()
            End If

            If Name_TXT.Text = "" Then
                'NOT_("Not Valid Without a Blank 'Name'", NOT_Type.Warning)
                Return False
                Exit Function
            End If

            If Chack_Duplicate(Database_File.cre, "TBL_Ledger", "Name", Duplicate_Type) = True Then
                NOT_("The Name Entered is a 'Duplicate'", NOT_Type.Warning)
                'Msg_Duplicat(Name_TXT, "Ledger")
                Return False
                Exit Function
            ElseIf Chack_Duplicate(Database_File.cre, "TBL_Ledger", "Alise", Duplicate_Type1) = True Then
                NOT_("The Name Entered is a 'Duplicate'", NOT_Type.Warning)
                'Msg_Duplicat(Name_TXT, "Ledger")
                Return False
                Exit Function
            Else
                NOT_Clear()
                Return True
            End If
        End If
        Return True
    End Function
    Private Function Alisa_aLlow() As Boolean
        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            Duplicate_Alias_Type = " Name = '" & Alias_TXT.Text & " COLLATE NOCASE '"
        Else
            Duplicate_Alias_Type = " Name = '" & Alias_TXT.Text & "' COLLATE NOCASE  and ID <> '" & VC_ID_ & "'"
        End If

        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            Duplicate_Alias_Type1 = " Alise = '" & Alias_TXT.Text & "' COLLATE NOCASE "
        Else
            Duplicate_Alias_Type1 = " Alise = '" & Alias_TXT.Text & "' COLLATE NOCASE  and ID <> '" & VC_ID_ & "'"
        End If
        If Alias_TXT.Text <> "" Then
            If Name_TXT.Text = Alias_TXT.Text Then
                NOT_("Name and Alias is Sam", NOT_Type.Warning)
                Msg_Duplicat(Alias_TXT, "Alias")
                Return False
                Exit Function
            End If

            If Chack_Duplicate(Database_File.cre, "TBL_Ledger", "Alise", Duplicate_Alias_Type) = True Then
                NOT_("The Alias Entered is a 'Duplicate'", NOT_Type.Warning)
                'Msg_Duplicat(Alias_TXT, "Alias")
                Return False
                Exit Function
            ElseIf Chack_Duplicate(Database_File.cre, "TBL_Ledger", "Name", Duplicate_Alias_Type1) = True Then
                NOT_("The Alias Entered is a 'Duplicate'", NOT_Type.Warning)
                'Msg_Duplicat(Alias_TXT, "Alias")
                Return False
                Exit Function
            Else
                NOT_Clear()
                Return True
            End If
        Else
            Return True
        End If
    End Function

    Private Sub Alias_TXT_Enter(sender As Object, e As EventArgs) Handles Alias_TXT.Enter
        Alisa_aLlow()
    End Sub
    Private Sub Alias_TXT_TextChanged(sender As Object, e As EventArgs) Handles Alias_TXT.TextChanged
        Alisa_aLlow()
    End Sub
    Private Sub Alias_TXT_LostFocus(sender As Object, e As EventArgs) Handles Alias_TXT.LostFocus
        If Alisa_aLlow() = False Then
            Alias_TXT.Focus()
        End If
    End Sub
    Private Sub Email_TXT_Enter(sender As Object, e As EventArgs) Handles Email_TXT.Enter
        Email_aLlow()
    End Sub

    Private Sub Email_TXT_TextChanged(sender As Object, e As EventArgs) Handles Email_TXT.TextChanged
        Email_aLlow()
    End Sub

    Private Function Email_aLlow() As Boolean
        If Formate_Email(Email_TXT.Text) = True Then
            NOT_Clear()
        Else
            NOT_("The email format you entered is incorrect", NOT_Type.Warning)
        End If
    End Function
    Private Function GST_aLlow() As Boolean
        If Formate_GST(GST_TXT.Text) = True Then
            NOT_Clear()
            Return True
        Else
            NOT_("The GST No. format you entered is incorrect", NOT_Type.Warning)
        End If
    End Function
    Private Function PAN_aLlow() As Boolean
        If Formate_PAN(PAN_TXT.Text) = True Then
            If GST_aLlow() = True Then
                If PAN_TXT.Text <> GST_TXT.Text.Substring(2, 10) Then
                    NOT_("The PAN No. and GST No. Is not match", NOT_Type.Warning)
                    Return False
                End If
            End If
            NOT_Clear()
        Else
            NOT_("The PAN No. format you entered is incorrect", NOT_Type.Warning)
        End If
    End Function
    Private Function IFSC_aLlow() As Boolean
        If Formate_IFSC(IFSC_TXT.Text) = True Then
            NOT_Clear()
        Else
            NOT_("The IFSC Code format you entered is incorrect", NOT_Type.Warning)
        End If
    End Function

    Private Sub GST_TXT_Enter(sender As Object, e As EventArgs) Handles GST_TXT.Enter
        GST_aLlow()
    End Sub
    Private Sub GST_TXT_TextChanged(sender As Object, e As EventArgs) Handles GST_TXT.TextChanged
        GST_aLlow()
    End Sub
    Private Sub PAN_TXT_Enter(sender As Object, e As EventArgs) Handles PAN_TXT.Enter
        PAN_aLlow()

        If PAN_TXT.Text = Nothing Then
            If GST_aLlow() = True Then
                PAN_TXT.Text = GST_TXT.Text.Substring(2, 10)
            End If
        End If
    End Sub
    Private Sub PAN_TXT_TextChanged(sender As Object, e As EventArgs) Handles PAN_TXT.TextChanged
        PAN_aLlow()
    End Sub
    Private Sub IFSC_TXT_Enter(sender As Object, e As EventArgs) Handles IFSC_TXT.Enter
        IFSC_aLlow()
    End Sub
    Private Sub IFSC_TXT_TextChanged(sender As Object, e As EventArgs) Handles IFSC_TXT.TextChanged
        IFSC_aLlow()
    End Sub
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim Byt As Byte()
        Byt = DirectCast(DataGridView1.CurrentRow.Cells(4).Value, Byte())

        Dim EditBTNDATA As String = DataGridView1.Columns(e.ColumnIndex).Name

        If EditBTNDATA = "Column6" Then
            If DataGridView1.CurrentRow.Cells(5).Value <> Nothing Then
                Attage_Password.Password = DataGridView1.CurrentRow.Cells(5).Value
                If Attage_Password.ShowDialog <> DialogResult.Yes Then
                    Exit Sub
                End If
            End If
            Dim Formett As String = DataGridView1.CurrentRow.Cells(3).Value.ToString
            If Formett = ".Jpeg" Or Formett = ".jpg" Or Formett = ".jpg2" Or Formett = ".png" Or Formett = ".gif" Or Formett = ".bmp" Then
                Document_view_frm.Byt = Byt
                Document_view_frm.Name = DataGridView1.CurrentRow.Cells(1).Value.ToString
                Document_view_frm.Formett = Formett
                Document_view_frm.Narra = DataGridView1.CurrentRow.Cells(2).Value.ToString
                Document_view_frm.ShowDialog()
            End If
        ElseIf EditBTNDATA = "Column7" Then
            Dim memory As New MemoryStream()
            Dim Formett As String
            If DataGridView1.CurrentRow.Cells(5).Value <> Nothing Then
                Attage_Password.Password = DataGridView1.CurrentRow.Cells(5).Value
                If Attage_Password.ShowDialog <> DialogResult.Yes Then
                    Exit Sub
                End If
            End If


            Formett = DataGridView1.CurrentRow.Cells(3).Value
            Dim ms As New MemoryStream(Byt)
            SaveFileDialog1.FileName = DataGridView1.CurrentRow.Cells(1).Value
            SaveFileDialog1.Title = Name_TXT.Text & " Save Document"
            If SaveFileDialog1.ShowDialog = DialogResult.OK Then
                Dim file As New FileStream(SaveFileDialog1.FileName & Formett, FileMode.Create, FileAccess.Write)
                ms.WriteTo(file)
                file.Close()
                ms.Close()
            End If


        ElseIf EditBTNDATA = "Column8" Then

            If DataGridView1.CurrentRow.Cells(0).Value <> "0" Then
                If DataGridView1.CurrentRow.Cells(5).Value <> Nothing Then
                    Attage_Password.Password = DataGridView1.CurrentRow.Cells(5).Value
                    If Attage_Password.ShowDialog <> DialogResult.Yes Then
                        Exit Sub
                    End If
                End If

                If Msg_Delete_YN(DataGridView1.CurrentRow.Cells(1).Value, "Document") = DialogResult.Yes Then
                    If Data_Delete(Database_File.rec, "TBL_Attage", "Visible = 'Delete' WHERE ID = '" & DataGridView1.CurrentRow.Cells(0).Value & "'") = True Then
                        DataGridView1.Rows.Remove(DataGridView1.CurrentRow)
                    End If
                End If
            Else
                DataGridView1.Rows.Remove(DataGridView1.CurrentRow)
            End If
        End If
    End Sub
    Private Function GST_State_Chack() As Boolean
        Dim gst As String = GST_TXT.Text.ToUpper
        Dim state As String = State_TXT.Text.ToUpper
        Try
            If GST_TXT.Text.Trim <> Nothing And State_TXT.Text.Trim <> Nothing Then
                If Find_DT_Value(Database_File.cfgs, "TBL_State_GSTCode", "StateName", "StateCode = '" & gst.ToString.Substring(0, 2) & "'").ToUpper <> state Then
                    GST_TXT.Focus()
                    NOT_("GST Number is wrong as per your state", NOT_Type.Warning)
                    Return False
                End If
            End If
        Catch ex As Exception
            Return False
        End Try
        NOT_Clear()
        Return True
    End Function

    Private Sub GST_TXT_LostFocus(sender As Object, e As EventArgs) Handles GST_TXT.LostFocus
        GST_State_Chack()
    End Sub

    Private Sub State_TXT_TextChanged(sender As Object, e As EventArgs) Handles State_TXT.TextChanged

    End Sub

    Private Sub State_TXT_LostFocus(sender As Object, e As EventArgs) Handles State_TXT.LostFocus
        GST_State_Chack()
        Set_State()
    End Sub

    Private Sub Txt1_TextChanged(sender As Object, e As EventArgs) Handles Txt1.TextChanged
        If Txt1.Text = "India" Then
            Panel10.Visible = True
            Tax_Registration_Panel.Visible = True
            cfg_()
        Else
            Tax_Registration_Panel.Visible = False
            Panel10.Visible = False
        End If
    End Sub

    Private Sub Txt2_TextChanged(sender As Object, e As EventArgs)
        If Txt2.Text = "Unregistered" Or Txt2.Text = "Consumer" Then
            GST_TXT.Enabled = False
        Else
            GST_TXT.Enabled = True
        End If
    End Sub

    Private Sub Txt2_Enter(sender As Object, e As EventArgs)

    End Sub
    Private Sub Txt2_KeyDown(sender As Object, e As KeyEventArgs)

    End Sub

    Private Sub Txt2_LostFocus(sender As Object, e As EventArgs)

    End Sub

    Private Sub Txt3_TextChanged(sender As Object, e As EventArgs) Handles Txt3.TextChanged

    End Sub

    Private Sub Txt3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt3.KeyPress

    End Sub

    Private Sub Txt3_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt3.KeyDown
        If Branch_Visible() = False Then
            If e.KeyCode = Keys.C Then
                Txt3.Text = "Cr"
            ElseIf e.KeyCode = Keys.D Then
                Txt3.Text = "Dr"
            End If
        End If
    End Sub

    Private Sub Opning_Balance_TXT_TextChanged(sender As Object, e As EventArgs) Handles Opning_Balance_TXT.TextChanged
        If Val(Opning_Balance_TXT.Text) = 0 Then
            Txt3.Enabled = False
        Else
            Txt3.Enabled = True
        End If
    End Sub
    Dim ag_list As List_frm
    Dim State_list As List_frm
    Dim tx_GST_list As List_frm
    Dim tx_type_list As List_frm
    Dim tx_class_list As List_frm
    Dim ag_contry As List_frm
    Dim gst_type_contry_List As List_frm
    Dim City_list As List_frm
    Dim communitcatio_list As List_frm
    Dim crdr_list As List_frm
    Private Function List_set()
        ag_list = New List_frm
        List_Setup("List of Account Groups", Select_List.Right_Dock, Select_List_Format.Defolt, Group_TXT, ag_list, Group_Source, 320)
        ag_list.System_Data_integer = 1

        State_list = New List_frm
        List_Setup("List of State", Select_List.Right_Dock, Select_List_Format.Singel, State_TXT, State_list, State_Source, 320)

        tx_GST_list = New List_frm
        List_Setup("Type of GST", Select_List.Right, Select_List_Format.Singel, Type_of_Duty_TXT, tx_GST_list, TAX_Source, 150)

        tx_type_list = New List_frm
        List_Setup("Type of Duty/TAX", Select_List.Right, Select_List_Format.Singel, Txt5, tx_type_list, TAX_Type_Source, 150)

        tx_class_list = New List_frm
        List_Setup("GST Class", Select_List.Right, Select_List_Format.Singel, Txt6, tx_class_list, GST_Classs_Source, 100)

        ag_contry = New List_frm
        List_Setup("List of Countries", Select_List.Right_Dock, Select_List_Format.Defolt, Txt1, ag_contry, Country_BS, 320)

        communitcatio_list = New List_frm
        List_Setup("Type of Communication", Select_List.Right, Select_List_Format.Singel, Txt4, communitcatio_list, communication_type_source, 180)

        gst_type_contry_List = New List_frm
        List_Setup("List GST Type", Select_List.Right, Select_List_Format.Defolt, Txt2, gst_type_contry_List, GST_Type__BS, 150)
        gst_type_contry_List.List_Grid.Columns(1).Visible = False
        gst_type_contry_List.List_Grid.Columns(2).Visible = False

        City_list = New List_frm
        city_Datatabale = New DataTable
        city_Datatabale.Columns.Add("Name")
        city_Datatabale.Columns.Add("Taluka")
        city_Datatabale.Columns.Add("id")
        city_Datatabale.Rows.Add("", "Other City")

        City_Source.DataSource = city_Datatabale
        List_Setup("List City/Village", Select_List.Right, Select_List_Format.Defolt, City_TXT, City_list, City_Source, 320)

        crdr_list = New List_frm
        List_Setup("Cr/Dr", Select_List.Right, Select_List_Format.Singel, Txt3, crdr_list, Crdr_Source, 100)


    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Process.Start("https://app.signalx.ai/gstin-verification/" & GST_TXT.Text)
    End Sub

    Private Sub Label56_Click(sender As Object, e As EventArgs) Handles Label56.Click
        B_4_Click(e, e)
    End Sub
    Private Sub Group_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles Group_TXT.KeyDown
        If e.KeyCode = Keys.Enter Then
            If ag_list.List_Grid.CurrentRow.Cells(1).Value = "Create" Then
                Cell("Account Group", "", "Create_Close", "")
                Acc_Group_frm.close_focus_obj = sender
                Exit Sub
            End If


            Under_ID = ag_list.List_Grid.CurrentRow.Cells(2).Value
            Group_TXT.Data_Link_ = ag_list.List_Grid.CurrentRow.Cells(2).Value
            Under = ag_list.List_Grid.CurrentRow.Cells(0).Value

            Set_Under(Under)

            If Under_ID = Nothing Then
                sender.Focus
                Exit Sub
            End If

            Communication_set_auto()
            Label16.Text = ag_list.List_Grid.CurrentRow.Cells(1).Value.ToString


            If Val(Txt3.Text) = 0 Then
                If Under_ID = "4" Or Under_ID = "5" Or Under_ID = "6" Or Under_ID = "7" Or Under_ID = "8" Or Under_ID = "9" Or Under_ID = "23" Or Under_ID = "24" Or Under_ID = "25" Or Under_ID = "26" Or Under_ID = "27" Or Under_ID = "28" Then
                    Txt3.Text = "Dr"
                Else
                    Txt3.Text = "Cr"
                End If
            End If
        End If

        If e.KeyCode = Keys.C AndAlso e.Modifiers = Keys.Alt Then
            Cell("Account Group", "", "Create_Close", "")
            Acc_Group_frm.close_focus_obj = sender
        ElseIf e.KeyCode = Keys.Enter AndAlso e.Modifiers = Keys.Control Then
            Cell("Account Group", "", "Alter", Under_ID)
            Acc_Group_frm.close_focus_obj = sender
        End If
    End Sub

    Private Sub Under_Panel_Paint(sender As Object, e As PaintEventArgs) Handles Under_Panel.Paint

    End Sub

    Private Sub GST_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles GST_TXT.KeyDown

    End Sub

    Private Sub Yn1_TextChanged(sender As Object, e As EventArgs) Handles Yn1.TextChanged

    End Sub

    Private Sub Yn1_KeyDown(sender As Object, e As KeyEventArgs) Handles Yn1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Yn1.Text = "Yes" Then
                Dim str As String() = Find_IfscCode(IFSC_TXT.Text)

                Bank_TXT.Text = str(0)
                Branch_TXT.Text = str(1)
            End If
        End If
    End Sub

    Private Sub Yn2_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Pincode_TXT_TextChanged(sender As Object, e As EventArgs) Handles Pincode_TXT.TextChanged

    End Sub

    Private Sub Yn3_TextChanged(sender As Object, e As EventArgs) Handles Yn3.TextChanged

    End Sub
    Dim city_Datatabale As DataTable
    Private Sub Yn3_KeyDown(sender As Object, e As KeyEventArgs) Handles Yn3.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Yn3.Text = "Yes" Then
                city_Datatabale.Rows.Clear()
                city_Datatabale.Rows.Add("", "Other City")

                City_TXT.Type_ = "Select"

                State_TXT.Text = ""
                Districe_TXT.Text = ""
                Taluka_TXT.Text = ""



                Dim cn As New SQLiteConnection
                If open_MSSQL_Cstm(Database_File.cfgs, cn) = True Then
                    cmd = New SQLiteCommand($"Select * From TBL_Address where Pincode = '{Pincode_TXT.Text.Trim}'", cn)
                    Dim r As SQLiteDataReader
                    r = cmd.ExecuteReader
                    While r.Read
                        If r("Taluka").ToString <> "NA" Then
                            State_TXT.Text = r("State")
                            Districe_TXT.Text = r("Dis")
                            Taluka_TXT.Text = r("Taluka")
                        End If
                        city_Datatabale.Rows.Add(r("City").ToString.Replace(" B.O", ""), "", "")
                    End While
                    r.Close()
                    City_Source.DataSource = city_Datatabale
                End If
            Else
                City_TXT.Type_ = "TXT"
            End If
            Set_State()
        End If
    End Sub
    Private Function Set_State()
        Dim str As String = State_TXT.Text
        If str.Length = 0 Then
            Exit Function
        End If
        State_TXT.Text = str.Substring(0, 1).ToUpper
        State_TXT.Text &= str.Substring(1, str.Length - 1).ToLower



    End Function
    Private Sub City_TXT_TextChanged(sender As Object, e As EventArgs) Handles City_TXT.TextChanged
        If City_list.List_Grid.Rows.Count = 1 Then
            city_Datatabale.Rows(0)(0) = City_TXT.Text
        Else
            city_Datatabale.Rows(0)(0) = ""
            City_list.List_Grid.CurrentCell = City_list.List_Grid.Rows(1).Cells(0)
        End If
    End Sub

    Private Sub City_TXT_Enter(sender As Object, e As EventArgs) Handles City_TXT.Enter
        If City_list.List_Grid.Rows.Count = 1 Then
            city_Datatabale.Rows(0)(0) = City_TXT.Text
        Else
            city_Datatabale.Rows(0)(0) = ""
        End If
    End Sub

    Private Sub Yn4_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Yn4_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            If sender.Text = "Yes" Then
                Cell("Accounting Ledger (Multi Branch Manager)", VC_ID_)
            Else
                Opning_Balance_TXT.Text = ""
            End If
        End If
    End Sub

    Private Sub Save_TXT_TextChanged(sender As Object, e As EventArgs) Handles Save_TXT.TextChanged

    End Sub
    Private Sub Save_TXT_Enter(sender As Object, e As EventArgs) Handles Save_TXT.Enter
        Dim result As DialogResult = Msg_Save_YN(Name_TXT, "Ledger")

        If result = DialogResult.Yes Then
            Save_Data()
        ElseIf result = DialogResult.No Then
            Name_TXT.Focus()
        ElseIf result = DialogResult.Cancel Then
            SendKeys.Send("{BACKSPACE}")
        End If
    End Sub

    Private Sub Panel23_Paint(sender As Object, e As PaintEventArgs)
        'sender.Height = Me.Height
        obj_center(sender, Me)
    End Sub

    Private Sub Ledger_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        Name_TXT.Focus()
        BG_frm.From_ID = From_ID
    End Sub

    Private Sub Name_TXT_GotFocus(sender As Object, e As EventArgs) Handles Name_TXT.GotFocus

    End Sub

    Private Sub Tax_Registration_Panel_Paint(sender As Object, e As PaintEventArgs) Handles Tax_Registration_Panel.Paint

    End Sub

    Private Sub IFSC_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles IFSC_TXT.KeyDown

    End Sub

    Private Sub Txt4_TextChanged(sender As Object, e As EventArgs) Handles Txt4.TextChanged
        If sender.Text = "Custom" Then
            whatsapp_yn.Enabled = True
            email_yn.Enabled = True
        Else
            whatsapp_yn.Enabled = False
            email_yn.Enabled = False
        End If
    End Sub

    Private Sub Txt4_LostFocus(sender As Object, e As EventArgs) Handles Txt4.LostFocus
        If sender.Text = "By Group (Default)" Then
            Communication_set_auto()
        End If
    End Sub
    Private Function Communication_set_auto()
        whatsapp_yn.Text = Find_DT_Value(Database_File.cre, "TBL_Acc_Group", "Communication_Whatsapp", $"id = '{Under_ID}'")
        email_yn.Text = Find_DT_Value(Database_File.cre, "TBL_Acc_Group", "Communication_Email", $"id = '{Under_ID}'")
    End Function

    Private Sub Group_TXT_TextChanged(sender As Object, e As EventArgs) Handles Group_TXT.TextChanged

    End Sub

    Private Sub Label72_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label72_KeyPress(sender As Object, e As KeyPressEventArgs)
        allow_Number(e)
    End Sub

    Private Sub Type_of_Duty_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles Type_of_Duty_TXT.KeyDown
        If e.KeyCode = Keys.Enter Then
            Label72.Text = (tx_GST_list.List_Grid.CurrentRow.Cells(1).Value)
        End If
    End Sub

    Private Sub Txt5_TextChanged(sender As Object, e As EventArgs) Handles Txt5.TextChanged
        If sender.Text = "GST" Then
            Panel29.Visible = True
        Else
            Panel29.Visible = False
        End If
    End Sub

    Private Sub Txt5_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt5.KeyDown
        If e.KeyCode = Keys.Enter Then
            If tx_type_list.List_Grid.CurrentRow.Cells(0).Value = "GST" Then
                Panel29.Visible = True
            Else
                Panel29.Visible = False
                Type_of_Duty_TXT.Text = ""
                Label72.Text = ""
            End If
        End If
    End Sub

    Private Sub Txt6_TextChanged(sender As Object, e As EventArgs) Handles Txt6.TextChanged
        If sender.Text = "Cess" Then
            Label6.Visible = False
            Label5.Visible = False
            Type_of_Duty_TXT.Visible = False
            Type_of_Duty_TXT.Text = ""


            Label7.Visible = False
            Label70.Visible = False
            Label72.Visible = False
            Label71.Visible = False

            Label72.Text = ""
        Else
            Label6.Visible = True
            Label5.Visible = True
            Type_of_Duty_TXT.Visible = True

            Label7.Visible = True
            Label70.Visible = True
            Label72.Visible = True
            Label71.Visible = True
        End If


        Duty_TAX_Source_fill("Duties & Taxes")
    End Sub

    Private Sub Txt2_TextChanged_1(sender As Object, e As EventArgs) Handles Txt2.TextChanged
        If Txt2.Text = "Composition" Then
            GST_TXT.Enabled = True
            PAN_TXT.Enabled = True
        ElseIf Txt2.Text = "Consumer" Then
            GST_TXT.Enabled = False
            PAN_TXT.Enabled = True
        ElseIf Txt2.Text = "Regular" Then
            GST_TXT.Enabled = True
            PAN_TXT.Enabled = True
        ElseIf Txt2.Text = "Unregistered" Then
            GST_TXT.Enabled = False
            PAN_TXT.Enabled = False
        End If
    End Sub

    Private Sub State_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles State_TXT.KeyDown

    End Sub

    Private Sub Yn5_TextChanged(sender As Object, e As EventArgs) Handles Yn5.TextChanged
        If sender.Text = "Yes" Then
            Label77.Visible = True
            Label78.Visible = True
            Yn2.Visible = True
        Else
            Label77.Visible = False
            Label78.Visible = False
            Yn2.Visible = False
        End If
    End Sub

    Private Sub Yn2_TextChanged_1(sender As Object, e As EventArgs) Handles Yn2.TextChanged

    End Sub

    Private Sub Yn2_KeyDown(sender As Object, e As KeyEventArgs) Handles Yn2.KeyDown
        If e.KeyCode = Keys.Enter Then
            If sender.Text = "Yes" Then
                Cell("Cheque Configuration", VC_ID_)
                Cheque_Refresh()
            End If
        End If
    End Sub
    Private Function Cheque_Refresh()
        With Cheque_Set_frm
            .Cheque_Height.Text = Cheque_Height
            .Cheque_Width.Text = Cheque_Width

            .Cross_Top.Text = Cheque_Cross_Top
            .Cross_Left.Text = Cheque_Cross_Left

            .Date_Top.Text = Cheque_Date_Top
            .Date_Left.Text = Cheque_Date_Left

            .Date_Format.Text = Cheque_Date_Format
            .Date_Sparator.Text = Cheque_Date_Separator
            .Date_Distance.Text = Cheque_Date_Distance

            .Party_Top.Text = Cheque_Party_Top
            .Party_Left.Text = Cheque_Party_Left
            .Party_Width.Text = Cheque_Party_area

            .Amount_W1_Top.Text = Cheque_AmountW1_Top
            .Amount_W1_Left.Text = Cheque_AmountW1_Left
            .Amount_W1_Width.Text = Cheque_AmountW1_Width

            .Amount_W2_Top.Text = Cheque_AmountW2_Top
            .Amount_W2_Left.Text = Cheque_AmountW2_Left
            .Amount_W2_width.Text = Cheque_AmountW2_Width

            .Amount_Top.Text = Cheque_Amount_Top
            .Amount_Left.Text = Cheque_Amount_Left
            .Amount_Width.Text = Cheque_Amount_Width

        End With
    End Function
    Public Cheque_Width As Integer = 0
    Public Cheque_Height As Integer = 0

    Public Cheque_Cross_Top As Integer = 0
    Public Cheque_Cross_Left As Integer = 0

    Public Cheque_Date_Top As Integer = 0
    Public Cheque_Date_Left As Integer = 0
    Public Cheque_Date_Format As String = ""
    Public Cheque_Date_Separator As String = ""
    Public Cheque_Date_Distance As Integer = 0

    Public Cheque_Party_Top As Integer = 0
    Public Cheque_Party_Left As Integer = 0
    Public Cheque_Party_area As Integer = 0

    Public Cheque_AmountW1_Top As Integer = 0
    Public Cheque_AmountW1_Left As Integer = 0
    Public Cheque_AmountW1_Width As Integer = 0

    Public Cheque_AmountW2_Top As Integer = 0
    Public Cheque_AmountW2_Left As Integer = 0
    Public Cheque_AmountW2_Width As Integer = 0

    Public Cheque_Amount_Top As Integer = 0
    Public Cheque_Amount_Left As Integer = 0
    Public Cheque_Amount_Width As Integer = 0

    Public cfg_Address_YN As Boolean = True
    Public cfg_Bank_Details_YN As Boolean = False
    Public cfg_GST_Details_YN As Boolean = True
    Public cfg_Credit_Limit_YN As Boolean = False
    Public cfg_Credit_Days_YN As Boolean = False
    Public cfg_Communication_YN As Boolean = False
    Public cfg_other_YN As Boolean = False
    Public Function Create_Database_Table()
        Dim cn As New SQLiteConnection
        Dim create_ As Boolean = False
        If open_MSSQL_Cstm(Database_File.lnk, cn) = True Then
            cmd = New SQLiteCommand("SELECT count(*) as c FROM sqlite_master WHERE type='table' AND name='cfg_Ledger'", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                If r("c") <> 1 Then
                    create_ = True
                End If
            End While
            r.Close()


            If create_ = True Then
                cmd = New SQLiteCommand("CREATE TABLE 'cfg_Ledger' (
	'Id'	INTEGER NOT NULL UNIQUE,
	'Head'	TEXT,
	'Value'	TEXT,
	PRIMARY KEY('Id' AUTOINCREMENT));", cn)

                cmd.ExecuteNonQuery()
            End If
        End If
    End Function

    Private Sub Txt4_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt4.KeyDown

    End Sub

    Private Sub bg_Panel_Paint(sender As Object, e As PaintEventArgs) Handles bg_Panel.Paint

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Update_cfg(Database_File.lnk, "cfg_Ledger", "Address_YN", "No")
    End Sub

    Private Sub Txt8_TextChanged(sender As Object, e As EventArgs) Handles DOB_TXT.TextChanged

    End Sub

    Private Sub Txt8_LostFocus(sender As Object, e As EventArgs) Handles DOB_TXT.LostFocus
        Try
            DOB_TXT.Text = CDate(Date_Formate(DOB_TXT.Text)).ToString(Date_Format_fech)
        Catch ex As Exception

        End Try
    End Sub
End Class
