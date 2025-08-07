Imports System.Data.SQLite
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView
Imports QRCoder.PayloadGenerator
Imports Tools
Public Class Payroll_Vouchers_frm
    Dim From_ID As String
    Public VC_Type_ As String
    Dim VC_ID_ As String
    Public Tra_ID As String

    Public VC_Formate As String
    Public VC_Formate_ID As String
    Dim Path_End As String
    Public Branch_ID As String
    Public Voucher_ID As Integer
    Public Attendance_Lock As Boolean = False

    Private Sub Payroll_Vouchers_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text

        VC_Formate = Link_Valu(2)
        VC_Type_ = Link_Valu(1)
        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Or VC_Type_ = "Voucher Transfer" Then
            VC_Formate_ID = Link_Valu(3)
        End If

        BG_frm.HADE_TXT.Text = "Payroll Voucher"
        BG_frm.TYP_TXT.Text = VC_Type_
        Date_TXT.Text = Now.Date
        Branch_ID = Branch_ID_()
        Branch_TXT.Text = Dft_Branch

        Fill_Source()
        List_set()

        controls_add(VC_Formate.ToLower)

        If VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close" Or VC_Type_ = "Duplicate" Then
            Display_all_Data("TBL_VC", "Tra_ID")
        ElseIf VC_Type_ = "Audit" Then
            'Audit_ID = Link_Valu(3)
            Display_all_Data("DEL_VC", "Audit_ID")
        ElseIf VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Or VC_Type_ = "Voucher Transfer" Then
            Defolt_Set_Voucher()
            Tra_ID = "0"
        End If


        Button_Manage()
        Add_Hander_Remove_Handel(True)

        Date_TXT.Focus()

    End Sub
    Private Function Display_all_Data(TBL_ As String, ID_Head As String)
        If VC_Formate.ToLower = "attendance" Then
            Attendance_ctrl.bg_panel.Controls.Clear()
        ElseIf VC_Formate.ToLower = "payroll" Then
            PAYROLL_ctrl.bg_panel.Controls.Clear()
        End If
        Tra_ID = Link_Valu(0)
        Dim ID As String = Tra_ID

        Dim Voucher_Type As String
        Dim Head_ID As String

        Dim conn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, conn) = True Then
            cmd = New SQLiteCommand($"Select ID,Voucher_ID,Voucher_Type,Voucher_Type_ID,Voucher_No,Date,Ledger,Narration,
(Select ld.[Name] From TBL_Ledger ld where ld.id  = Ledger) as Ledger_Name,
(Select ld.[Name] From TBL_Ledger ld where ld.id  = Branch) as Branch_Name From {TBL_} where {ID_Head} = '{ID}' LIMIT 1", conn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                Head_ID = r("ID")
                Voucher_ID = r("Voucher_ID")
                Voucher_Type = r("Voucher_Type")
                VC_Formate_ID = r("Voucher_Type_ID")
                VC_ID_ = r("Voucher_No")
                Date_TXT.Text = r("Date")

                If VC_Type_ <> "Duplicate" Then
                    Voucher_No_TXT.Text = r("Voucher_No").ToString
                End If

                Account_TXT.Text = r("Ledger_Name").ToString
                Acc_ID = r("Ledger").ToString
                Branch_TXT.Text = r("Branch_Name").ToString
                Narration_TXT.Text = r("Narration")
            End While
            r.Close()

            Voucher_Setup(VC_Formate_ID)

            If Voucher_Type_LB.Text = "Attendance" Then
                cmd = New SQLiteCommand($"Select *,ty.Name as Attendance_Name,ty.Attendance_Type as Attendance_Type,
(Select emp.Name From TBL_Payroll_Employee emp where emp.id = att.Employee) as Employee_Name,
(Select u.Symbol From TBL_Inventory_Unit u where u.ID = ty.[Unit]) as Unit_Name,
(Select SUM(vt.Value) as Vlu From TBL_Attendance_VC vt LEFT JOIN TBL_VC vc on vc.Tra_ID = vt.Tra_ID where vt.Employee = att.Employee and vt.Attendance_ID = att.Attendance_ID and vc.Visible = 'Approval' and vc.[Date] < '{CDate(Date_TXT.Text).AddDays(1).ToString(Lite_date_Format)}') as Balance_
From TBL_Attendance_VC att 
LEFT JOIN TBL_Payroll_Att_Production_Type ty on ty.ID = att.Attendance_ID
where att.Tra_ID = '{ID}' and att.Visible = 'Approval'", conn)
                r = cmd.ExecuteReader
                While r.Read
                    With Attendance_ctrl
                        .Add_New(True)
                        Dim i As Integer = .bg_panel.Controls.Count

                        .Find_Employee_TXT(i).Data_Link_ = r("Employee").ToString
                        .Find_Employee_TXT(i).Text = r("Employee_Name").ToString

                        .Find_Attendance_TXT(i).Data_Link_ = r("Attendance_ID").ToString
                        .Find_Attendance_TXT(i).Text = r("Attendance_Name").ToString

                        .Find_Value_TXT(i).Text = Val(r("Value").ToString)

                        .Find_balvlu_Lab(i).Text = N2_FORMATE(r("Balance_").ToString)

                        If r("TBL_VC_ID") = "NA" Then
                            .Find_Bg_Panel(i).Enabled = True
                        Else
                            .Find_Bg_Panel(i).Enabled = False
                        End If
                        If r("Attendance_Type") = "Production" Then
                            .Find_Unit_Lab(i).Text = r("Unit_Name").ToString
                            .Find_balunit_Lab(i).Text = r("Unit_Name").ToString
                        Else
                            .Find_Unit_Lab(i).Text = "Day"
                            .Find_balunit_Lab(i).Text = "Day"
                        End If
                        If r("TBL_VC_ID") <> "NA" Then
                            Attendance_Lock = True
                        End If

                    End With
                End While
                If Attendance_Lock = True Then
                    Date_TXT.Enabled = False
                    Note_Label.Visible = True
                    Note_Label.Text = "This voucher is for viewing only, no corrections can be made within this, as payroll is generated based on the presence of this voucher."

                End If
            ElseIf Voucher_Type_LB.Text = "Payroll" Then
                cmd = New SQLiteCommand($"Select *,
(Select emp.Name From TBL_Payroll_Employee emp where emp.id = py.Employee) as Employee_Name,
(Select phd.Name From TBL_PayHead phd where phd.id = py.PayHead) as Payhead_Name
--(Select vc.Auto_Entry From TBL_VC vc where vc.Tra_ID = {ID} and vc.Visible = 'Approval') as Auto_Entry
From TBL_VC_Payroll py
where py.Tra_ID = '{ID}'", conn)
                r = cmd.ExecuteReader
                'My.Computer.Clipboard.SetText(cmd.CommandText)
                Dim Emp_ As String = ""
                While r.Read
                    With PAYROLL_ctrl
                        If Emp_ <> r("Employee").ToString Or Emp_ = Nothing Then
                            .Add_New(True)
                            Dim ii As Integer = .bg_panel.Controls.Count
                            .Find_Employee_TXT(ii).Data_Link_ = r("Employee").ToString
                            .Find_Employee_TXT(ii).Text = r("Employee_Name").ToString
                            Emp_ = r("Employee")
                        End If

                        Dim i As Integer = .bg_panel.Controls.Count
                        .Add_Under(i)
                        Dim i2 As Integer = .Find_bg_Under(i).Controls.Count

                        .Find_Payhead_TXT(i, i2).Data_Link_ = r("Payhead").ToString
                        .Find_Payhead_TXT(i, i2).Text = r("Payhead_Name").ToString

                        If Val(r("Dr").ToString) > 0 Then
                            .Find_Amount_Under_TXT(i, i2).Text = Val(r("Dr").ToString)
                            .Find_Amount_Type_Under_TXT(i, i2).Text = "Dr"
                        ElseIf Val(r("Cr").ToString) > 0 Then
                            .Find_Amount_Under_TXT(i, i2).Text = Val(r("Cr").ToString)
                            .Find_Amount_Type_Under_TXT(i, i2).Text = "Cr"
                        Else
                            .Find_Amount_Type_Under_TXT(i, i2).Text = ""
                            .Find_Amount_Under_TXT(i, i2).Text = ""
                        End If


                        'Auto_Entry = YN_Boolean(r("Auto_Entry").ToString, False)
                    End With
                End While
            End If
        End If



        Fill_Attage()

        Cfg_Link()

        Acc_Balance = Val(Val((Ledger_Balance(Acc_ID, CDate(Date_TXT.Text).AddDays(1), Tra_ID, Branch_ID))))
        Acc_Credit = Val(Find_DT_Value(Database_File.cre, "TBL_Ledger", "Cradit", "ID = '" & Acc_ID & "' and " & Company_Visible_Filter()))

        Label17.Text = "Attach Files : " & DataGridView1.Rows.Count

        Closing_Balance_Set()
    End Function
    Private Function Fill_Attage()
        If VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close" Then
            If open_MSSQL(Database_File.rec) = True Then
                DataGridView1.Rows.Clear()
                qury = "Select * From TBL_Attage where TBL = 'TBL_VC' and TBL_ID = '" & Tra_ID & "' and Visible = 'Approval'"
                cmd = New SQLiteCommand(qury, con)
                Dim r As SQLiteDataReader
                r = cmd.ExecuteReader
                While r.Read
                    DataGridView1.Rows.Add(r("ID"), r("Name"), r("Narration"), r("Attage_Type"), r("Attage"), r("Password"))
                End While
            End If
        End If
    End Function
    Private Function Button_Manage()
        Button_Clear()
        BG_frm.B_1.Text = "&E : Exit"
        BG_frm.B_2.Text = "&S : Save"
        BG_frm.B_5.Text = "|&T : Attach"
        BG_frm.B_6.Text = "|&P : Print"

        If Login_Type = "Admin Account" And (VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close") Then
            'BG_frm.B_7.Text = "|&O : Audit"
        End If
        BG_frm.R_2.Text = "F2 : Date"
        BG_frm.R_4.Text = "F4 : Attendance"
        BG_frm.R_5.Text = "F5 : Payroll"
        BG_frm.R_6.Text = "10 : Other Vouchers"

        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Or VC_Type_ = "Voucher Transfer" Then
            BG_frm.R_3.Text = "&F : Auto Fill"
        ElseIf VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close" Then
            BG_frm.B_3.Text = "&D : Delete"
        End If

        BG_frm.R_22.Text = "F12 : Configuration"
    End Function
    Private Function Add_Hander_Remove_Handel(Ans As Boolean)
        If Ans = True Then
            AddHandler BG_frm.KeyDown, AddressOf Me.BG_Keydown
            AddHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            AddHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
            AddHandler BG_frm.B_3.Click, AddressOf Me.B_3_Click
            AddHandler BG_frm.B_5.Click, AddressOf Me.B_5_Click
            AddHandler BG_frm.B_6.Click, AddressOf Me.B_6_Click


            AddHandler BG_frm.R_2.Click, AddressOf Me.R_2_Click
            AddHandler BG_frm.R_3.Click, AddressOf Me.R_3_Click
            AddHandler BG_frm.R_4.Click, AddressOf Me.R_4_Click
            AddHandler BG_frm.R_5.Click, AddressOf Me.R_5_Click
            AddHandler BG_frm.R_6.Click, AddressOf Me.R_6_Click


            AddHandler BG_frm.R_22.Click, AddressOf Me.R_22_Click
        Else
            RemoveHandler BG_frm.KeyDown, AddressOf Me.BG_Keydown
            RemoveHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            RemoveHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
            RemoveHandler BG_frm.B_3.Click, AddressOf Me.B_3_Click
            RemoveHandler BG_frm.B_5.Click, AddressOf Me.B_5_Click
            RemoveHandler BG_frm.B_6.Click, AddressOf Me.B_6_Click

            RemoveHandler BG_frm.R_2.Click, AddressOf Me.R_2_Click
            RemoveHandler BG_frm.R_3.Click, AddressOf Me.R_3_Click

            RemoveHandler BG_frm.R_4.Click, AddressOf Me.R_4_Click
            RemoveHandler BG_frm.R_5.Click, AddressOf Me.R_5_Click
            RemoveHandler BG_frm.R_6.Click, AddressOf Me.R_6_Click

            RemoveHandler BG_frm.R_22.Click, AddressOf Me.R_22_Click
        End If
    End Function
    Private Sub BG_Keydown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.F2 Then
            BG_frm.R_2.PerformClick()
        End If

        If e.KeyCode = Keys.F4 Then
            BG_frm.R_4.PerformClick()
        End If
        If e.KeyCode = Keys.F5 Then
            BG_frm.R_5.PerformClick()
        End If
        If e.KeyCode = Keys.F10 Then
            BG_frm.R_6.PerformClick()
        End If
        If e.KeyCode = Keys.F6 Then
            BG_frm.R_7.PerformClick()
        End If

        If e.KeyCode = Keys.F7 Then
            BG_frm.R_8.PerformClick()
        End If

        If e.KeyCode = Keys.F12 Then
            BG_frm.R_22.PerformClick()
        End If
    End Sub
    Private Sub B_1_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Voucher_BG_frm.Dispose()
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
                If Msg_Delete_YN(Voucher_No_TXT, Voucher_Name_LB.Text) = DialogResult.Yes Then
                    If Delete_Vouchers(Tra_ID, Voucher_Type_LB.Text) = True Then
                        Dim cn As New SQLiteConnection
                        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                            'BG_frm.Voucher_BS.DataSource = Nothing
                            'BG_frm.Voucher_BS.DataSource = Fill_Vouchhers(cn)
                        End If
                        Clear_all()
                    Else
                        Msg_Custom_YN(NOT_Location.Bottom_Right, Color.Red, My.Resources.Error_animation_icn, Dialoag_Button.Ok, "Error!", "Entry is not delete", Not_Delete_Error_msg)
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub B_5_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            attage_display.Grid_ = Me.DataGridView1
            Cell("Attach Display")
        End If
    End Sub
    Private Sub B_6_Click(sender As Object, e As EventArgs)
        If Save_Requr() = True Then

        End If
    End Sub

    Private Sub R_4_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Cell("Filter", "Change Voucher:Attendance", BG_frm.HADE_TXT.Text)
        End If
    End Sub
    Private Sub R_5_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Cell("Filter", "Change Voucher:Payroll", BG_frm.HADE_TXT.Text)
        End If
    End Sub
    Private Sub R_6_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Cell("Filter", "Change Voucher:All Vouchers", BG_frm.HADE_TXT.Text)
        End If
    End Sub

    Private Sub R_3_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            With Payroll_Auto_Fill_Dialoag
                .Fill_Data()
                .List_set()
            End With

            Cell("Payroll Auto Fill", Voucher_Type_LB.Text)

        End If
    End Sub
    Private Sub R_2_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Set_Date(False, Me)
        End If
    End Sub

    Private Sub R_22_Click(sender As Object, e As EventArgs)
        Cell("Vouchers Configuration", "", VC_Type_, VC_Formate_ID)
    End Sub
    Dim auto_frm As Date
    Dim auto_to As Date
    Dim auto_type As String
    Public Function Payroll_Auto_Fill(typ As String, IDD As String)
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            With PAYROLL_ctrl
                .bg_panel.Controls.Clear()
                auto_frm = CDate(Payroll_Auto_Fill_Dialoag.frm_date.Text)
                auto_to = CDate(Payroll_Auto_Fill_Dialoag.To_date.Text)
                auto_type = Payroll_Auto_Fill_Dialoag.Txt2.Text

                Date_TXT.Text = auto_to

                If typ = "Employee" Then
                    cmd = New SQLiteCommand($"Select em.ID as em_ID,em.Name as em_Name,phd.iD as phd_ID,phd.name as Phd_Name,
(Select ifnull(SUM(vc.Dr),0) - ifnull(SUM(vc.Cr),0) From TBL_VC_Payroll vc where vc.Employee = em.ID and vc.Payhead = phd.ID and (vc.Date BETWEEN '{CDate(auto_frm).ToString(Lite_date_Format)}' and '{CDate(auto_to).AddDays(1).ToString(Lite_date_Format)}'))  as Vl1,
(SELECT ifnull(SUM(vlu),0)
From (SELECT ifnull(atvc.Value,0) *
(Select ifnull(sd.Rate,0) From TBL_Payroll_SalaryDetails sd where sd.Under = 'Employee' and sd.Account = em.ID and sd.Payhead = phd.ID and sd.[Date] = (Select sd1.[Date] From TBL_Payroll_SalaryDetails sd1 where sd1.Account = em.ID and sd1.[Date]<= atvc.[Date] ORDER By sd1.[Date] DESC LIMIT 1)) as Vlu
From TBL_Attendance_VC atvc

where atvc.Visible = 'Approval' and (atvc.Attendance_ID = phd.Leave_without_pay or atvc.Attendance_ID = phd.Production) and atvc.Employee = em.ID and (atvc.Date BETWEEN '{CDate(auto_frm).ToString(Lite_date_Format)}' and '{CDate(auto_to).AddDays(1).ToString(Lite_date_Format)}'))) as Vl3
From TBL_Payroll_Employee em
CROSS JOIN TBL_PayHead phd
where em.Visible = 'Approval' and phd.Visible = 'Approval' and em.ID = '{IDD}'", cn)

                ElseIf typ = "Group" Then

                    cmd = New SQLiteCommand($"Select em.ID as em_ID,em.Name as em_Name,phd.iD as phd_ID,phd.name as Phd_Name,
(Select ifnull(SUM(vc.Dr),0) - ifnull(SUM(vc.Cr),0) From TBL_VC_Payroll vc where vc.Employee = em.ID and vc.Payhead = phd.ID and (vc.Date BETWEEN '{CDate(auto_frm).ToString(Lite_date_Format)}' and '{CDate(auto_to).AddDays(1).ToString(Lite_date_Format)}'))  as Vl1,
(SELECT ifnull(SUM(vlu),0)
From (SELECT ifnull(atvc.Value,0) *
(Select ifnull(sd.Rate,0) From TBL_Payroll_SalaryDetails sd where sd.Under = 'Employee' and sd.Account = em.ID and sd.Payhead = phd.ID and sd.[Date] = (Select sd1.[Date] From TBL_Payroll_SalaryDetails sd1 where sd1.Account = em.ID and sd1.[Date]<= atvc.[Date] ORDER By sd1.[Date] DESC LIMIT 1)) as Vlu
From TBL_Attendance_VC atvc

where atvc.Visible = 'Approval' and (atvc.Attendance_ID = phd.Leave_without_pay or atvc.Attendance_ID = phd.Production) and atvc.Employee = em.ID and (atvc.Date BETWEEN '{CDate(auto_frm).ToString(Lite_date_Format)}' and '{CDate(auto_to).AddDays(1).ToString(Lite_date_Format)}'))) as Vl3
From TBL_Payroll_Employee em
CROSS JOIN TBL_PayHead phd
where em.Visible = 'Approval' and phd.Visible = 'Approval' and em.Under = '{IDD}'", cn)

                    My.Computer.Clipboard.SetText(cmd.CommandText)
                Else

                    cmd = New SQLiteCommand($"Select em.ID as em_ID,em.Name as em_Name,phd.iD as phd_ID,phd.name as Phd_Name,
(Select ifnull(SUM(vc.Dr),0) - ifnull(SUM(vc.Cr),0) From TBL_VC_Payroll vc where vc.Employee = em.ID and vc.Payhead = phd.ID and (vc.Date BETWEEN '{CDate(auto_frm).ToString(Lite_date_Format)}' and '{CDate(auto_to).AddDays(1).ToString(Lite_date_Format)}'))  as Vl1,
(SELECT ifnull(SUM(vlu),0)
From (SELECT ifnull(atvc.Value,0) *
(Select ifnull(sd.Rate,0) From TBL_Payroll_SalaryDetails sd where sd.Account = em.ID and sd.Payhead = phd.ID and sd.[Date] = (Select sd1.[Date] From TBL_Payroll_SalaryDetails sd1 where sd1.Account = em.ID and sd1.[Date]<= atvc.[Date] ORDER By sd1.[Date] DESC LIMIT 1)) as Vlu
From TBL_Attendance_VC atvc

where atvc.Visible = 'Approval' and (atvc.Attendance_ID = phd.Leave_without_pay or atvc.Attendance_ID = phd.Production) and atvc.Employee = em.ID and (atvc.Date BETWEEN '{CDate(auto_frm).ToString(Lite_date_Format)}' and '{CDate(auto_to).AddDays(1).ToString(Lite_date_Format)}'))) as Vl3
From TBL_Payroll_Employee em
CROSS JOIN TBL_PayHead phd
where em.Visible = 'Approval' and phd.Visible = 'Approval'", cn)

                End If

                Dim r As SQLiteDataReader = cmd.ExecuteReader
                Dim emp_ As String = "NA"
                While r.Read
                    Dim vlu_ As String = Val(r("Vl3")) - (Val(r("Vl1")))
                    Dim i As Integer = .bg_panel.Controls.Count
                    If emp_ <> r("em_ID").ToString Then
                        .Add_New(True)
                        i = .bg_panel.Controls.Count
                        .Find_Employee_TXT(i).Data_Link_ = r("em_ID").ToString
                        .Find_Employee_TXT(i).Text = r("em_Name").ToString
                        emp_ = r("em_ID").ToString
                    End If
                    If Val(vlu_) <> 0 Then
                        .Add_Under(i)
                        Dim i2 As Integer = .Find_bg_Under(i).Controls.Count

                        .Find_Payhead_TXT(i, i2).Data_Link_ = r("phd_ID").ToString
                        .Find_Payhead_TXT(i, i2).Text = r("Phd_Name").ToString

                        If Val(vlu_) < 0 Then
                            .Find_Amount_Under_TXT(i, i2).Text = Val(vlu_) * -1
                            .Find_Amount_Type_Under_TXT(i, i2).Text = "Cr"
                        Else
                            .Find_Amount_Under_TXT(i, i2).Text = Val(vlu_)
                            .Find_Amount_Type_Under_TXT(i, i2).Text = "Dr"
                        End If

                        .Find_Amount_Under_TXT(i, i2).Data_Link_ = Val(r("Vl3")) - Val(r("Vl1"))

                        .Balance_Online(i, i2)
                        .Balance_Offline(i, i2)
                        emp_ = r("em_ID").ToString
                    End If
                End While
                r.Close()
            End With
        End If

        'PAYROLL_ctrl.Enabled = False
        Payroll_Auto_Fill_Dialoag.Dispose()

    End Function
    Public Function Attendance_Auto_Fill()
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            With Attendance_ctrl
                .bg_panel.Controls.Clear()

                Dim Att_ID As String = Payroll_Auto_Fill_Dialoag.Atendance_Select.Data_Link_
                Dim Att_Unit As String = Find_DT_Value(Database_File.cre, "TBL_Payroll_Att_Production_Type", "Unit", $"Name = '{Payroll_Auto_Fill_Dialoag.Atendance_Select.Text}'")

                Att_Unit = Find_DT_Unit_Conves(Att_Unit)

                If Att_Unit = Nothing Then
                    Att_Unit = "Day"
                End If

                If Payroll_Auto_Fill_Dialoag.Type_TXT.Text = "All Employee" Then
                    cmd = New SQLiteCommand($"Select em.Name,em.ID,
(Select SUM(vt.Value) as Vlu From TBL_Attendance_VC vt LEFT JOIN TBL_VC vc on vc.Tra_ID = vt.Tra_ID where vt.Employee = em.ID and vt.Attendance_ID = '{Att_ID}' and vc.Visible = 'Approval' and vc.[Date] < '{CDate(Date_TXT.Text).AddDays(1).ToString(Lite_date_Format)}' and vc.Tra_ID <> '{Tra_ID}') as Balance_
From TBL_Payroll_Employee em where {Company_Visible_Filter()}", cn)
                    Dim r As SQLiteDataReader = cmd.ExecuteReader
                    While r.Read
                        .Add_New(False)
                        Dim i As Integer = .bg_panel.Controls.Count
                        .Find_Employee_TXT(i).Text = r("Name").ToString
                        .Find_Employee_TXT(i).Data_Link_ = r("ID").ToString


                        .Find_Attendance_TXT(i).Text = Payroll_Auto_Fill_Dialoag.Atendance_Select.Text
                        .Find_Attendance_TXT(i).Data_Link_ = Att_ID
                        .Find_Value_TXT(i).Text = Val(Payroll_Auto_Fill_Dialoag.vlu_TXT.Text)
                        .Find_Value_TXT(i).Decimal_ = Payroll_Auto_Fill_Dialoag.vlu_TXT.Decimal_
                        .Find_Unit_Lab(i).Text = Att_Unit
                        .Find_balunit_Lab(i).Text = Att_Unit
                        .Find_balvlu_Lab(i).Text = N2_FORMATE(Val(r("Balance_").ToString) + Val(Payroll_Auto_Fill_Dialoag.vlu_TXT.Text))
                    End While

                ElseIf Payroll_Auto_Fill_Dialoag.Type_TXT.Text = "Employee Group wise" Then
                    Dim Group_ID As String = Payroll_Auto_Fill_Dialoag.Filter_ID

                    cmd = New SQLiteCommand($"Select em.Name,em.ID,
(Select SUM(vt.Value) as Vlu From TBL_Attendance_VC vt LEFT JOIN TBL_VC vc on vc.Tra_ID = vt.Tra_ID where vt.Employee = em.ID and vt.Attendance_ID = '{Att_ID}' and vc.Visible = 'Approval' and vc.[Date] < '{CDate(Date_TXT.Text).AddDays(1).ToString(Lite_date_Format)}' and vc.Tra_ID <> '{Tra_ID}') as Balance_
From TBL_Payroll_Employee em where em.Under = '{Group_ID}' and {Company_Visible_Filter()}", cn)
                    Dim r As SQLiteDataReader = cmd.ExecuteReader
                    While r.Read
                        .Add_New(False)
                        Dim i As Integer = .bg_panel.Controls.Count
                        .Find_Employee_TXT(i).Text = r("Name").ToString
                        .Find_Employee_TXT(i).Data_Link_ = r("ID").ToString


                        .Find_Attendance_TXT(i).Text = Payroll_Auto_Fill_Dialoag.Atendance_Select.Text
                        .Find_Attendance_TXT(i).Data_Link_ = Att_ID
                        .Find_Value_TXT(i).Text = Val(Payroll_Auto_Fill_Dialoag.vlu_TXT.Text)
                        .Find_Value_TXT(i).Decimal_ = Payroll_Auto_Fill_Dialoag.vlu_TXT.Decimal_
                        .Find_Unit_Lab(i).Text = Att_Unit
                        .Find_balunit_Lab(i).Text = Att_Unit
                        .Find_balvlu_Lab(i).Text = N2_FORMATE(Val(r("Balance_").ToString) + Val(Payroll_Auto_Fill_Dialoag.vlu_TXT.Text))
                    End While

                ElseIf Payroll_Auto_Fill_Dialoag.Type_TXT.Text = "Employee wise" Then
                    Dim Group_ID As String = Payroll_Auto_Fill_Dialoag.Filter_ID

                    cmd = New SQLiteCommand($"Select em.Name,em.ID,
(Select SUM(vt.Value) as Vlu From TBL_Attendance_VC vt LEFT JOIN TBL_VC vc on vc.Tra_ID = vt.Tra_ID where vt.Employee = em.ID and vt.Attendance_ID = '{Att_ID}' and vc.Visible = 'Approval' and vc.[Date] < '{CDate(Date_TXT.Text).AddDays(1).ToString(Lite_date_Format)}' and vc.Tra_ID <> '{Tra_ID}') as Balance_
From TBL_Payroll_Employee em where em.ID = '{Group_ID}' and {Company_Visible_Filter()}", cn)
                    Dim r As SQLiteDataReader = cmd.ExecuteReader
                    While r.Read
                        .Add_New(False)
                        Dim i As Integer = .bg_panel.Controls.Count
                        .Find_Employee_TXT(i).Text = r("Name").ToString
                        .Find_Employee_TXT(i).Data_Link_ = r("ID").ToString


                        .Find_Attendance_TXT(i).Text = Payroll_Auto_Fill_Dialoag.Atendance_Select.Text
                        .Find_Attendance_TXT(i).Data_Link_ = Att_ID
                        .Find_Value_TXT(i).Text = Val(Payroll_Auto_Fill_Dialoag.vlu_TXT.Text)
                        .Find_Value_TXT(i).Decimal_ = Payroll_Auto_Fill_Dialoag.vlu_TXT.Decimal_
                        .Find_Unit_Lab(i).Text = Att_Unit
                        .Find_balunit_Lab(i).Text = Att_Unit
                        .Find_balvlu_Lab(i).Text = N2_FORMATE(Val(r("Balance_").ToString) + Val(Payroll_Auto_Fill_Dialoag.vlu_TXT.Text))
                    End While
                End If

                If .bg_panel.Controls.Count = 0 Then
                    .Add_New(False)
                End If


                Payroll_Auto_Fill_Dialoag.Dispose()
                .Find_Value_TXT(1).Focus()
            End With


        End If

    End Function
    Public Function Apply_Date_Filter(ifPeriod As Boolean)
        Date_TXT.Text = Date_Formate(Date_3)
    End Function
    Private Function Save_Requr()
        If Date_TXT.Text = "" Then
            NOT_("Please enter date and try agin", NOT_Type.Erro)
            Date_TXT.Focus()
            'Msg_Blank(Date_TXT, "Voucher Date")
            Return False
            Exit Function
        End If
        If Branch_TXT.Text = "" And Branch_Panel.Visible = True Then
            NOT_("Please select branch and try agin", NOT_Type.Erro)
            Branch_TXT.Focus()
            'Msg_Blank(Branch_TXT, "Branch")
            Return False
            Exit Function
        End If

        If Branch_Visible() = True And Branch_Panel.Visible = True Then
            If Branch_TXT.Text = "Primary".Trim Then
                Branch_ID = "0"
            ElseIf (Chack_Duplicate(Database_File.cre, "TBL_Ledger", "Name", "Name = '" & Branch_TXT.Text.ToString.Trim & "'") = False) Then
                NOT_("Branch select error, Please select again", NOT_Type.Erro)
                'Msg_InputError(Branch_TXT, "Branch")
                Branch_TXT.Focus()
                Return False
                Exit Function
            Else
                Branch_ID = Find_DT_Value(Database_File.cre, "TBL_Ledger", "ID", "Name = '" & Branch_TXT.Text.ToString.Trim & "'")
            End If
        End If

        If Chack_Duplicate(Database_File.cre, "TBL_Ledger", "Name", "Name = '" & Account_TXT.Text & "'") = False And Account_TXT.Visible = True Then
            NOT_("Account select error, Please select again", NOT_Type.Erro)
            Account_TXT.Focus()
            'Msg_InputError(Account_TXT, "Account")
            Return False
            Exit Function
        Else
            Acc_ID = Find_DT_Value(Database_File.cre, "TBL_Ledger", "ID", "Name = '" & Account_TXT.Text & "'")
        End If

        If Account_TXT.Text = "" And Account_TXT.Visible = True Then
            NOT_("Please select account and try agin", NOT_Type.Erro)
            Account_TXT.Focus()
            'Msg_Blank(Account_TXT, "Account")
            Return False
            Exit Function
        End If

        If Voucher_Bo_aLlow() = False Then
            NOT_("Voucher number is duplicate", NOT_Type.Erro)
            Voucher_No_TXT.Focus()
            Msg_Duplicat(Voucher_No_TXT, "Voucher No")
            Return False
            Exit Function
        End If


        Return Grid_Status_Chack()
    End Function
    Private Function Grid_Status_Chack() As Boolean
        If Voucher_Type_LB.Text = "Attendance" Then
            With Attendance_ctrl
                For Each bg_p As Panel In .bg_panel.Controls.OfType(Of Panel)()
                    Dim i As Integer = .Find_Idx(bg_p)

                    If Chack_Duplicate(Database_File.cre, "TBL_Payroll_Employee", "Name", "Name = '" & .Find_Employee_TXT(i).Text & "'") = False Then
                        .Find_Employee_TXT(i).Data_Link_ = ""
                        .Find_Attendance_TXT(i).Data_Link_ = ""
                    ElseIf Chack_Duplicate(Database_File.cre, "TBL_Payroll_Att_Production_Type", "Name", "Name = '" & .Find_Attendance_TXT(i).Text & "'") = False Then
                        .Find_Attendance_TXT(i).Focus()
                        Return False
                    End If
                Next
            End With
        ElseIf Voucher_Type_LB.Text = "Payroll" Then
            With PAYROLL_ctrl
                'For Each bg_p As Panel In .bg_panel.Controls.OfType(Of Panel)()
                '    Dim i As Integer = .Find_Idx(bg_p)
                '    If Chack_Duplicate(Database_File.cre, "TBL_Payroll_Employee", "Name", "Name = '" & .Find_Employee_TXT(i).Text & "'") = False Then
                '        .Find_Employee_TXT(i).Data_Link_ = ""
                '    Else
                '        For Each p As Panel In .Find_bg_Under(i).Controls.OfType(Of Panel)()
                '            If Chack_Duplicate(Database_File.cre, "TBL_PayHead", "Name", "Name = '" & .Find_Employee_TXT(i).Text & "'") = True Then

                '            End If
                '        Next
                '        Return False
                '    End If
                'Next
            End With
        End If
        Return True
    End Function
    Private Function Save_Data()
        If BG_frm.From_ID = From_ID Then
            If Save_Requr() = True Then
                If Audit_Vouchers(Tra_ID) = True Then
                    Tra_ID = Tra_ID_Search(Tra_ID, VC_Type_)
                    If Data_Save_Manag() = True Then
                        If Document_Save() = True Then
                            Clear_all()
                        End If
                    End If
                End If
            End If
        End If
    End Function
    Private Function Clear_all()
        Dim cn As New SQLiteConnection
        Account_TXT.Text = ""
        Narration_TXT.Text = ""
        Label8.Text = "0.00"
        Label28.Text = "0.00"

        If VC_Type_ = "Create" Then
            Voucher_Setup(VC_Formate_ID)
            Date_TXT.Focus()

            NOT_("The entry you entered has been successfully accepted", NOT_Type.Success)
            Tra_ID = "0"
            Fill_Source()

            If Voucher_Type_LB.Text = "Attendance" Then
                If Attendance_ctrl.Visible = True Then
                    Attendance_ctrl.bg_panel.Controls.Clear()
                    Attendance_ctrl.Add_New(True)
                End If
            ElseIf Voucher_Type_LB.Text = "Payroll" Then
                If PAYROLL_ctrl.Visible = True Then
                    PAYROLL_ctrl.bg_panel.Controls.Clear()
                    PAYROLL_ctrl.Add_New(True)
                End If
            End If
        Else
            Voucher_BG_frm.Dispose()
            Update_Report = True
            Frm_foCus()
        End If

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
                            .AddWithValue("@TBL", "TBL_VC")
                            .AddWithValue("@TBL_ID", Tra_ID)
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
    Private Function Data_Save_Manag() As Boolean
        Dim ins_qry As String
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            If Voucher_Type_LB.Text = "Attendance" Then
                If Insurt_Value_Attendance("TBL_Attendance_VC", cn) = True Then
                    cn.Close()
                    Return True
                End If
            ElseIf Voucher_Type_LB.Text = "Payroll" Then
                If Insurt_Value_Payroll("TBL_PayHead", cn) = True Then
                    cn.Close()
                    Return True
                End If
            End If
        End If
    End Function
    Private Function Insurt_Head(cn As SQLiteConnection) As Boolean
        If Voucher_Type_LB.Text = "Attendance" Then
            Dim Q As String = "INSERT INTO TBL_VC 
(Tra_ID,Voucher_ID,Voucher_No,Voucher_Type,Voucher_Type_ID,Date,Branch,Narration,User,PC,Date_install,Visible,Company,Employee,Credit_Amount,Debit_Amount,Effect_Stock,Effect_Ledger,Effect_PayHead,Type) VALUES 
(@Tra_ID,@Voucher_ID,@Voucher_No,@Voucher_Type,@Voucher_Type_ID,@Date_,@Branch,@Narration,@User,@PC,@Install_,@Visible,@Company,@Employee,@Credit_Amount,@Debit_Amount,'No','No','No',@Type)"


            Dim Employee_ As String

            Dim P_ As New Queue(Of Panel)()
            For Each bg_p As Panel In Attendance_ctrl.bg_panel.Controls.OfType(Of Panel)()
                P_.Enqueue(bg_p)
            Next
            For Each bg_p As Panel In P_.Reverse
                With Attendance_ctrl
                    Employee_ = .Find_Employee_TXT(.Find_Idx(bg_p)).Data_Link_
                End With
            Next


            Try
                cmd = New SQLiteCommand(Q, cn)

                With cmd.Parameters
                    .AddWithValue("@Tra_ID", Tra_ID)
                    .AddWithValue("@Voucher_ID", Voucher_ID)
                    .AddWithValue("@Voucher_No", Voucher_No_TXT.Text.Trim)
                    .AddWithValue("@Voucher_Type", Voucher_Type_LB.Text.Trim)

                    .AddWithValue("@Voucher_Type_ID", VC_Formate_ID)
                    .AddWithValue("@Date_", CDate(Date_TXT.Text))

                    .AddWithValue("@Type", "Head")
                    '.AddWithValue("@Ledger", "")
                    .AddWithValue("@Employee", Employee_)
                    .AddWithValue("@Credit_Amount", "")
                    .AddWithValue("@Debit_Amount", "")

                    .AddWithValue("@Branch", Branch_ID.Trim)
                    .AddWithValue("@Narration", Narration_TXT.Text.Trim)
                    .AddWithValue("@Company", Company_ID_str)
                    .AddWithValue("@User", LOGIN_ID)
                    .AddWithValue("@PC", PC_ID.Trim)
                    .AddWithValue("@Install_", CDate(DateTime.Now))

                    .AddWithValue("@Visible", "Approval")

                    cmd.ExecuteNonQuery()
                End With
            Catch ex As Exception
                Msg(NOT_Type.Erro, "Data Save Error - Head", ex.Message)
                Return False
            End Try

        ElseIf Voucher_Type_LB.Text = "Payroll" Then
            Dim Dr_ As String = ""
            Dim Cr_ As String = ""


            If PAYROLL_ctrl.Label4.Text = "Dr" Then
                Dr_ = nUmBeR_FORMATE(PAYROLL_ctrl.Label3.Text)
                Cr_ = 0
            ElseIf PAYROLL_ctrl.Label4.Text = "Cr" Then
                Cr_ = nUmBeR_FORMATE(PAYROLL_ctrl.Label3.Text)
                Dr_ = 0
            End If

            Dim Employee_ As String
            Dim Payhead_ As String

            Dim P_ As New Queue(Of Panel)()
            For Each bg_p As Panel In PAYROLL_ctrl.bg_panel.Controls.OfType(Of Panel)()
                P_.Enqueue(bg_p)
            Next
            For Each bg_p As Panel In P_.Reverse
                With PAYROLL_ctrl
                    Employee_ = .Find_Employee_TXT(.Find_Idx(bg_p)).Data_Link_


                    For Each bg_p1 As Panel In PAYROLL_ctrl.Find_bg_Under(.Find_Idx(bg_p)).Controls.OfType(Of Panel)()
                        Payhead_ = .Find_Payhead_TXT(.Find_Idx(bg_p), .Find_Idx2(bg_p1)).Data_Link_
                    Next
                End With
                Exit For
            Next


            Dim Q As String = "INSERT INTO TBL_VC 
(Tra_ID,Voucher_ID,Voucher_No,Voucher_Type,Voucher_Type_ID,Date,Branch,Narration,User,PC,Date_install,Visible,Company,Ledger,Employee,Payhead,Credit_Amount,Debit_Amount,Effect_Stock,Effect_Ledger,Effect_PayHead,Type,Auto_Entry) VALUES 
(@Tra_ID,@Voucher_ID,@Voucher_No,@Voucher_Type,@Voucher_Type_ID,@Date_,@Branch,@Narration,@User,@PC,@Install_,@Visible,@Company,@Ledger,@Employee,@Payhead,@Credit_Amount,@Debit_Amount,'No','Yes','No',@Type,@Auto_Entry)"

            Try
                cmd = New SQLiteCommand(Q, cn)
                With cmd.Parameters
                    .AddWithValue("@Tra_ID", Tra_ID)
                    .AddWithValue("@Voucher_ID", Voucher_ID)
                    .AddWithValue("@Voucher_No", Voucher_No_TXT.Text.Trim)
                    .AddWithValue("@Voucher_Type", Voucher_Type_LB.Text.Trim)

                    .AddWithValue("@Voucher_Type_ID", VC_Formate_ID)
                    .AddWithValue("@Date_", CDate(Date_TXT.Text))

                    .AddWithValue("@Type", "Head")
                    .AddWithValue("@Ledger", Acc_ID)
                    .AddWithValue("@Employee", Employee_)
                    .AddWithValue("@Payhead", Payhead_)

                    .AddWithValue("@Auto_Entry", Boolean_TXT(False).ToString)

                    .AddWithValue("@Credit_Amount", nUmBeR_FORMATE(Cr_))
                    .AddWithValue("@Debit_Amount", nUmBeR_FORMATE(Dr_))

                    .AddWithValue("@Branch", Branch_ID.Trim)
                    .AddWithValue("@Narration", Narration_TXT.Text.Trim)
                    .AddWithValue("@Company", Company_ID_str)
                    .AddWithValue("@User", LOGIN_ID)
                    .AddWithValue("@PC", PC_ID.Trim)
                    .AddWithValue("@Install_", CDate(DateTime.Now))

                    .AddWithValue("@Visible", "Approval")

                    cmd.ExecuteNonQuery()
                End With

                'TBL_VC_Ledger
                cmd = New SQLiteCommand("INSERT INTO TBL_VC_Ledger 
(Type,Date,Tra_ID,Ledger,Dr,Cr) VALUES 
(@Type,@Date_,@Tra_ID,@Ledger,@Dr,@Cr)", cn)
                With cmd.Parameters

                    .AddWithValue("@Type", "Head")
                    .AddWithValue("@Date_", CDate(Date_TXT.Text))
                    .AddWithValue("@Tra_ID", Tra_ID.ToString.Trim)

                    .AddWithValue("@Ledger", Acc_ID)

                    .AddWithValue("@Cr", nUmBeR_FORMATE(Cr_))
                    .AddWithValue("@Dr", nUmBeR_FORMATE(Dr_))

                    cmd.ExecuteNonQuery()
                End With
            Catch ex As Exception
                Msg(NOT_Type.Erro, "Data Save Error - Head", ex.Message)
                Return False
            End Try




        End If


        Return True
    End Function

    Private Function Insurt_Value_Payroll(TBL As String, cn As SQLiteConnection) As Boolean
        'Insurt_Head_Payroll(TBL, cn)
        Insurt_Head(cn)



        Dim P_ As New Queue(Of Panel)()
        For Each bg_p As Panel In PAYROLL_ctrl.bg_panel.Controls.OfType(Of Panel)()
            P_.Enqueue(bg_p)
        Next
        For Each bg_p As Panel In P_.Reverse
            Dim i As Integer = PAYROLL_ctrl.Find_Idx(bg_p)
            Dim emp As String = PAYROLL_ctrl.Find_Employee_TXT(i).Data_Link_
            Dim amt_type As String = PAYROLL_ctrl.Find_Value_Type_H_TXT(i).Text
            Dim amt_ As String = nUmBeR_FORMATE(PAYROLL_ctrl.Find_Value_H_TXT(i).Text)

            'Payhead Data Install
            Dim Q_U As String = "INSERT INTO TBL_VC_Payroll 
(Tra_ID,Date,Employee,Payhead,Dr,Cr) VALUES 
(@Tra_ID,@Date_,@Employee,@Payhead,@Dr,@Cr)"


            Try
                Dim P1_ As New Queue(Of Panel)()
                For Each bg_p1 As Panel In PAYROLL_ctrl.Find_bg_Under(i).Controls.OfType(Of Panel)()
                    P1_.Enqueue(bg_p1)
                Next

                For Each bg_p1 As Panel In P1_.Reverse
                    Dim i2 As Integer = PAYROLL_ctrl.Find_Idx2(bg_p1)

                    Dim phd As String = PAYROLL_ctrl.Find_Payhead_TXT(i, i2).Data_Link_
                    Dim amt_u_Type As String = PAYROLL_ctrl.Find_Amount_Type_Under_TXT(i, i2).Text
                    Dim amt_u As TXT = PAYROLL_ctrl.Find_Amount_Under_TXT(i, i2)


                    If Val(phd) <> 0 Then
                        cmd = New SQLiteCommand(Q_U, cn)

                        With cmd.Parameters
                            .AddWithValue("@Tra_ID", Tra_ID)
                            .AddWithValue("@Date_", CDate(Date_TXT.Text))

                            .AddWithValue("@Payhead", phd)
                            .AddWithValue("@Employee", emp)

                            Dim vlu As Decimal = nUmBeR_FORMATE(amt_u.Text)

                            If amt_u_Type = "Dr" Then
                                .AddWithValue("@Cr", "0")
                                .AddWithValue("@Dr", vlu)
                            ElseIf amt_u_Type = "Cr" Then
                                .AddWithValue("@Cr", vlu)
                                .AddWithValue("@Dr", "")
                            End If

                            cmd.ExecuteNonQuery()
                        End With
                    End If
                Next

            Catch ex As Exception

            End Try
        Next

        Return True
    End Function

    Private Function Insurt_Value_Attendance(TBL As String, cn As SQLiteConnection) As Boolean
        Insurt_Head(cn)
        Dim q As String = "INSERT INTO TBL_Attendance_VC 
(Tra_ID,Date,Branch,Narrtion,Employee,Attendance_ID,Value,Visible,Company,User,Date_install,PC,Pay,TBL_VC_ID) VALUES 
(@Tra_ID,@Date_,@Branch,@Narrtion,@Employee,@Attendance_ID,@Value,@Visible,@Company,@User,@install_,@PC,@Pay,@TBL_VC_ID)"

        If Voucher_Type_LB.Text = "Attendance" Then
            Dim P_ As New Queue(Of Panel)()
            For Each bg_p As Panel In Attendance_ctrl.bg_panel.Controls.OfType(Of Panel)()
                P_.Enqueue(bg_p)
            Next
            For Each bg_p As Panel In P_.Reverse
                Dim i As Integer = Attendance_ctrl.Find_Idx(bg_p)

                If Val(Attendance_ctrl.Find_Employee_TXT(i).Data_Link_) <> 0 Then
                    If Attendance_ctrl.Find_Bg_Panel(i).Enabled = True Then
                        cmd = New SQLiteCommand(q, cn)

                        Dim employee_id As String
                        Dim attendance_id As String
                        Dim vlu As String

                        With Attendance_ctrl
                            employee_id = .Find_Employee_TXT(i).Data_Link_
                            attendance_id = .Find_Attendance_TXT(i).Data_Link_

                            vlu = Val(.Find_Value_TXT(i).Text)
                        End With

                        With cmd.Parameters

                            .AddWithValue("@Tra_ID", Tra_ID)
                            .AddWithValue("@Date_", CDate(Date_TXT.Text))
                            .AddWithValue("@Company", Company_ID_str)
                            .AddWithValue("@Visible", "Approval")
                            .AddWithValue("@User", LOGIN_ID)
                            .AddWithValue("@PC", PC_ID.Trim)
                            .AddWithValue("@Install_", CDate(DateTime.Now))

                            .AddWithValue("@Branch", Branch_ID)
                            .AddWithValue("@Narrtion", "")

                            .AddWithValue("@Pay", "0.00")

                            .AddWithValue("@Employee", employee_id)
                            .AddWithValue("@Attendance_ID", attendance_id)
                            .AddWithValue("@Value", Val(vlu))
                            .AddWithValue("@TBL_VC_ID", "NA")

                            cmd.ExecuteNonQuery()
                        End With
                    End If
                End If
            Next
        End If

        Return True
    End Function

    'Private Function Tra_ID_Search()
    '    If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Or VC_Type_ = "Duplicate" Or VC_Type_ = "Duplicate_Close" Then
    '        Tra_ID = Find_MAX_VLU(Database_File.cre, "TBL_VC", "Tra_ID")
    '    Else
    '        If open_MSSQL(Database_File.cre) Then
    '            qury = $"Delete From TBL_VC where Tra_ID = '{Tra_ID}'"
    '            cmd = New SQLiteCommand(qury, con)
    '            cmd.ExecuteNonQuery()
    '            'Other Details
    '            qury = $"Delete From TBL_VC_Other where Tra_ID = '{Tra_ID}'"
    '            cmd = New SQLiteCommand(qury, con)
    '            cmd.ExecuteNonQuery()
    '            'Delete Attendance Tabalae data

    '            qury = $"Delete From TBL_Attendance_VC where Tra_ID = '{Tra_ID}' and TBL_VC_ID = 'NA'"
    '            cmd = New SQLiteCommand(qury, con)
    '            cmd.ExecuteNonQuery()

    '            'Delete Payroll Tabalae data
    '            qury = $"Delete From TBL_Payroll_VC where Tra_ID = '{Tra_ID}'"
    '            cmd = New SQLiteCommand(qury, con)
    '            cmd.ExecuteNonQuery()
    '        End If
    '    End If

    '    '    Audit_ID = Find_MAX_VLU(Database_File.cre, "DEL_VC", "Audit_ID")


    'End Function
    Public Function Defolt_Set_Voucher()
        If VC_Formate = "Attendance" Then
            Attendance_Frmt()
        ElseIf VC_Formate = "Payroll" Then
            Payroll_Frmt()
        End If
    End Function


    Private Sub Attendance_Frmt()
        If BG_frm.From_ID = From_ID Then
            Voucher_Type_LB.Text = "Attendance"


            Attendance_ctrl.bg_panel.Controls.Clear()
            Attendance_ctrl.Add_New(True)

            bg_Panel.Dock = DockStyle.Fill
            bg_Panel.Show()
            Voucher_Setup(VC_Formate_ID)
        End If
    End Sub

    Private Sub Payroll_Frmt()
        If BG_frm.From_ID = From_ID Then
            Voucher_Type_LB.Text = "Payroll"


            PAYROLL_ctrl.bg_panel.Controls.Clear()
            PAYROLL_ctrl.Add_New(True)

            bg_Panel.Dock = DockStyle.Fill
            bg_Panel.Show()
            Voucher_Setup(VC_Formate_ID)
        End If
    End Sub

    Public Function Voucher_No_Setup()
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select Voucher_ID as C From TBL_VC where Voucher_Type = '{Voucher_Type_LB.Text}' and Voucher_Type_ID = '{VC_Formate_ID }' and {Company_Visible_Filter()} Order By Voucher_ID DESC limit 1", cn)
            Dim r As SQLiteDataReader = cmd.ExecuteReader
            While r.Read
                Voucher_ID = Val(r("C").ToString) + 1
            End While
            r.Close()
        End If

        If Voucher_ID = 0 Then
            Voucher_ID = 1
        End If

        cn.Close()
        If Val(Voucher_ID) <= Val(vc_start) Then
            Voucher_ID = Val(vc_start)
        End If


        If VC_VoucherNo_Method = "Automatitic" Then
            Voucher_No_TXT.Text = Voucher_ID
            Voucher_No_TXT.Enabled = True
        ElseIf VC_VoucherNo_Method = "Automatic (Manual Override)" Then
            Voucher_No_TXT.Text = Voucher_ID
            Voucher_No_TXT.Enabled = False
        ElseIf VC_VoucherNo_Method = "Manual" Then
            Voucher_ID = ""
            Voucher_No_TXT.Text = Voucher_ID
            Voucher_No_TXT.Enabled = False
        ElseIf VC_VoucherNo_Method = "Custom" Then
            Voucher_No_TXT.Text = VC_VoucherNo_Frist & Voucher_ID & VC_VoucherNo_Last
            Voucher_No_TXT.Enabled = True
        End If


        If Val(Voucher_ID) = 0 Then
            Voucher_ID = 1
        End If
    End Function

    Private Function Voucher_Setup(vc As String)
        Branch_Setup()
        Cfg_Link()

        'Serial No Set---------------+++++++++++++++++-----------------
        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Or VC_Type_ = "Duplicate" Or VC_Type_ = "Duplicate_Close" Or VC_Type_ = "Voucher Transfer" Then
            Voucher_No_Setup()
        End If

        Panel7.Show()

        If Voucher_Type_LB.Text = "Attendance" Then
            Account_Panel.Visible = False
        Else
            Account_Panel.Visible = True
        End If

        sp_option_panel.Visible = True
    End Function

    Public VC_Name As String
    Public VC_Under As String
    Public vc_start As String
    Public VC_VoucherNo_Method As String
    Public VC_VoucherNo_Frist As String
    Public VC_VoucherNo_Last As String
    Public VC_YN_Narration_Cell As String


    Public cfg_YN_Duplicate_No As Boolean = False
    Public cfg_YN_zero As Boolean = False
    Public cfg_YN_narration As Boolean = False
    Public cfg_print_head As String = ""
    Public cfg_print_type As String = ""

    Public cfg_communication_yn As Boolean = False
    Public cfg_print_derect As Boolean = False
    Public cfg_print_signature As Boolean = False
    Public cfg_print_stamp As Boolean = False
    Public cfg_print_Terms_Conditions As String = ""
    Public cfg_print_Provisnoal As String = ""


    Private Function Cfg_Link()
        Dim cn As New SQLiteConnection()
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select * From TBL_Voucher_Create where id = '{VC_Formate_ID}' and {Company_Visible_Filter()}", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                VC_Name = r("Name").ToString
                VC_Under = r("Under").ToString
                VC_VoucherNo_Method = r("Voucher_No_Method").ToString
                VC_VoucherNo_Frist = r("Voucher_No_Prefix").ToString
                VC_VoucherNo_Last = r("Voucher_No_Suffix").ToString
                VC_YN_Narration_Cell = r("YN_Narration_Cell").ToString
                vc_start = r("Voucher_Start").ToString


                cfg_YN_zero = YN_Boolean(r("Zerol_Value").ToString)
                cfg_YN_Duplicate_No = YN_Boolean(r("Duplicate_No").ToString)
                cfg_YN_narration = YN_Boolean(r("YN_Narration").ToString)
                cfg_print_head = (r("Print_Head").ToString)
                cfg_print_type = (r("Print_Type").ToString)

                cfg_print_derect = YN_Boolean(r("Print_after_seve").ToString)
                cfg_communication_yn = YN_Boolean(r("Communication_YN").ToString)
                cfg_print_signature = YN_Boolean(r("Print_Signature").ToString)
                cfg_print_stamp = YN_Boolean(r("Print_Stamp").ToString)
                cfg_print_Provisnoal = YN_Boolean(r("Print_Provisional").ToString)
                cfg_print_Terms_Conditions = (r("Print_Terms_Conditions").ToString)
            End While
        End If

        Voucher_Name_LB.Text = VC_Name
        Voucher_Type_LB.Text = VC_Under

        Narration_TXT.Visible = cfg_YN_narration
        Label9.Visible = cfg_YN_narration

    End Function
    Private Function Branch_Setup()
        If Branch_Visible() = True Then
            Label1.Show()
            Label12.Show()
            Branch_Panel.Show()
            If Branch_TXT.Text = Nothing Then
                Branch_TXT.Text = Dft_Branch
            End If
        Else
            Label1.Hide()
            Label12.Hide()
            Branch_Panel.Hide()
        End If
        Branch_ID = Branch_ID_()
    End Function


    Dim Attendance_ctrl As attandance_controls
    Dim PAYROLL_ctrl As payroll_controls
    Public Function controls_add(typ_ As String)
        If typ_ = "attendance" Then
            Attendance_ctrl = New attandance_controls
            Panel30.Controls.Add(Attendance_ctrl)

            Attendance_ctrl.Dock = DockStyle.Fill
            Attendance_ctrl.Fill_Data_Source(CDate(Date_TXT.Text), True)
            Attendance_ctrl.Add_New(True)
        ElseIf typ_ = "payroll" Then
            PAYROLL_ctrl = New payroll_controls
            Panel30.Controls.Add(PAYROLL_ctrl)

            PAYROLL_ctrl.Dock = DockStyle.Fill
            PAYROLL_ctrl.Fill_Data_Source(CDate(Date_TXT.Text))
            PAYROLL_ctrl.Add_New(True)
        End If
    End Function

    Private Sub Date_TXT_TextChanged(sender As Object, e As EventArgs) Handles Date_TXT.TextChanged
        Date_fOrmate_lIV()
    End Sub

    Dim privoice_date As Date
    Private Sub Date_TXT_Lostfocus(sender As Object, e As EventArgs) Handles Date_TXT.LostFocus
        If Date_fOrmate_lIV() = True Then
            Date_TXT.Text = CDate(Date_Formate(Date_TXT.Text)).ToString(Date_Format_fech)
        Else
            Date_TXT.Text = Now.Date.ToString(Date_Format_fech)
        End If

        Fill_Source()

        privoice_date = Date_Formate(Date_TXT.Text)
    End Sub
    Private Function Date_fOrmate_lIV() As Boolean
        If Date_Brack(Date_TXT.Text) = True Then
            Day_Label.Text = Date_TO_Day(Date_TXT.Text)
            Return True
        End If
        Return False
    End Function
    Dim acc_list As List_frm
    Dim branch_list As List_frm
    Private Function List_set()
        acc_list = New List_frm
        List_Setup("List of Ledger", Select_List.Right_Dock, Select_List_Format.Defolt, Account_TXT, acc_list, Account_Source, 320)
        acc_list.Set_COlor(6)
        acc_list.System_Data_integer = 1

        branch_list = New List_frm
        List_Setup("List of Branch", Select_List.Right, Select_List_Format.Defolt, Branch_TXT, branch_list, Branch_source, 300)
    End Function
    Private Function Fill_Source()
        Dim Positive As String = Find_DT_Value(Database_File.cmp, "TBL_Features", "Value", "Head = 'Positive Value'")
        Dim Negative As String = Find_DT_Value(Database_File.cmp, "TBL_Features", "Value", "Head = 'Negative Value'")

        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            Dim dt_cash As New DataTable
            dt_cash.Columns.Clear()
            dt_cash.Columns.Add("Name")
            dt_cash.Columns.Add("Curr. Balance")
            dt_cash.Columns.Add("ID")
            dt_cash.Columns.Add("Alias")
            dt_cash.Columns.Add("Group")
            dt_cash.Columns.Add("Curr. Credit")
            dt_cash.Columns.Add("Color")
            dt_cash.Columns.Add("balance_")

            dt_cash.Rows.Add("", "Create")

            Dim r As SQLiteDataReader



            Dim q As String = ""
            q &= $" and (vc.Effect_Ledger = 'Yes')"
            q &= $" and (vc.Visible = 'Approval')"
            q &= $" and (vc.[Date] <= '{CDate(Date_TXT.Text).AddDays(1).ToString(Lite_date_Format)}')"
            If Branch_ID <> 0 Then
                q &= " AND VC.Branch = '" & Branch_ID & "'"
            End If
            q &= $" and (vc.Tra_ID <> '{Tra_ID}')"




            cmd = New SQLiteCommand($"Select [ID],[Name],[Group],[Alise],[Cradit],
(Select ifnull((Select ifnull(SUM(vc.Cr),0)-ifnull(SUM(vc.Dr),0) From TBL_VC_Ledger vc Where vc.Ledger = LD.ID and vc.[Date] <= '{CDate(Date_TXT.Text).AddDays(1).ToString(Lite_date_Format)}' and vc.Tra_ID <> '{Tra_ID}'),0)+ifnull((Select ifnull(sum(lob.OB_Cr),0)-ifnull(sum(lob.OB_Dr),0) From TBL_Ledger_Opning_Balance lob where lob.Ledger_ID = LD.ID and lob.Branch_ID = '{Branch_ID}'),0)) as Bal_
from TBL_Ledger LD where {Branch_Enable_Ledger("LD.id", Branch_ID)} and (LD.[Group] = '17' or LD.[Group] = '27' or LD.[Group] = '28') and " & Company_Visible_Filter(), cn)

            With cmd.Parameters
                '.AddWithValue("@Filter_Date", CDate(Date_TXT.Text).AddDays(1).ToString(Lite_date_Format))

                r = cmd.ExecuteReader
                While r.Read
                    Dim Vlu_ As String
                    Vlu_ = r("Bal_").ToString
                    If Val(Vlu_) > 0 Then
                        Vlu_ = N2_FORMATE(Val(Vlu_)) & " " & Positive
                    ElseIf Val(Vlu_) < 0 Then
                        Vlu_ = N2_FORMATE(Vlu_ * -1) & " " & Negative
                    Else
                        Vlu_ = ""
                    End If

                    Dim Credit_ As String
                    Dim Color_ As String
                    Credit_ = Val(r("Bal_").ToString) - Val(r("Cradit").ToString)
                    If Val(Credit_) < 0 Then
                        Color_ = "Red"
                    ElseIf Val(Credit_) > 0 Then
                        Color_ = "Black"
                    Else
                        Credit_ = ""
                        Color_ = "Black"
                    End If

                    If r("Group") = "17" Or r("Group") = "27" Or r("Group") = "28" Then
                        dt_cash.Rows.Add(r("Name"), Vlu_, r("ID"), r("Alise"), r("Group"), Credit_, Color_, Val(r("Bal_").ToString))
                    End If
                End While
                r.Close()
                Account_Source.DataSource = dt_cash
                Account_filter_set()

                Branch_source.DataSource = Fill_Branch_data(cn)
            End With

            If VC_Formate = "Attendance" Then

            End If
        End If
    End Function
    Private Function Account_filter_set()
        Account_TXT.Select_Filter = "(Name LIKE '%<value>%' or Alias LIKE '%<value>%' or [Curr. Balance] LIKE 'Create')"
    End Function
    Public Function Fill_Branch_data(cn As SQLiteConnection) As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow

        dt.Clear()
        dt.Columns.Add("Name")
        dt.Columns.Add("Alias")
        dt.Columns.Add("ID")

        dt.Rows.Add("Primary")

        cmd = New SQLiteCommand("Select * From TBL_Ledger WHERE Visible = 'Approval' and [Group] = '7'", cn)
        Dim r As SQLiteDataReader
        r = cmd.ExecuteReader
        While r.Read
            dr = dt.NewRow
            dr("ID") = r("ID")
            dr("Name") = r("Name")
            dr("Alias") = r("Alise")
            dt.Rows.Add(dr)
        End While
        r.Close()
        Return dt
    End Function
    Private Sub Voucher_No_TXT_Enter(sender As Object, e As EventArgs) Handles Voucher_No_TXT.Enter
        Voucher_Bo_aLlow()
    End Sub
    Private Sub Voucher_No_TXT_TextChanged(sender As Object, e As EventArgs) Handles Voucher_No_TXT.TextChanged
        Voucher_Bo_aLlow()
    End Sub
    Private Sub Voucher_No_TXT_Lostfocus(sender As Object, e As EventArgs) Handles Voucher_No_TXT.LostFocus
        If Voucher_Bo_aLlow() = False Then
            Voucher_No_TXT.Focus()
        End If
    End Sub
    Private Function Voucher_Bo_aLlow() As Boolean
        Dim frm_ As String = "TBL_VC"
        Dim Duplicate_Type As String

        If cfg_YN_Duplicate_No = False Then
            If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Or VC_Type_ = "Duplicate" Or VC_Type_ = "Voucher Transfer" Then
                Duplicate_Type = $" Voucher_No = '{Voucher_No_TXT.Text}' and Voucher_Type_ID = '{VC_Formate_ID }' and {Company_Visible_Filter()}"
            Else
                Duplicate_Type = $" Voucher_No = '{Voucher_No_TXT.Text}' and (Voucher_No <> '{VC_ID_}') and CR_DR = 'Head' and Voucher_Type_ID = '{VC_Formate_ID}' and {Company_Visible_Filter()}"
            End If


            If Voucher_No_TXT.Text = "" Then
                NOT_("Not Valid Without a Blank 'Voucher No'", NOT_Type.Warning)
                'Msg_Blank(Voucher_No_TXT, "Voucher No")

                Return False
                Exit Function
            End If

            If Chack_Duplicate(Database_File.cre, frm_, "Name", Duplicate_Type) = True Then
                NOT_("The Voucher No Entered is a 'Duplicate'", NOT_Type.Warning)
                'Msg_Duplicat(Voucher_No_TXT, "Voucher No")

                Return False
                Exit Function
            Else
                NOT_Clear()
                Return True
            End If
        End If
        Return True
    End Function

    Private Sub Account_TXT_TextChanged(sender As Object, e As EventArgs) Handles Account_TXT.TextChanged

    End Sub
    Public Acc_ID As String
    Public Acc_Balance As Decimal = 0.00
    Public Acc_Credit As Decimal = 0.00
    Private Sub Account_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles Account_TXT.KeyDown

        If e.KeyCode = Keys.Enter Then
            If acc_list.List_Grid.CurrentRow.Cells(1).Value = "Create" Then
                Create_Cash_Ledger(sender)
                Exit Sub
            End If
            Acc_ID = acc_list.List_Grid.CurrentRow.Cells(2).Value
        End If


        If e.KeyCode = Keys.C AndAlso e.Modifiers = Keys.Alt Then
            Create_Cash_Ledger(sender)
        ElseIf e.KeyCode = Keys.Enter AndAlso e.Modifiers = Keys.Control Then
            Cell("Account Ledger", "", "Alter_Close", Acc_ID)
            Ledger_frm.close_focus_obj = sender
        ElseIf e.KeyCode = Keys.Enter Then
            Acc_Balance = Val(Val((Ledger_Balance(Acc_ID, CDate(Date_TXT.Text).AddDays(1), Tra_ID, Branch_ID))))

            Acc_Credit = Val(Find_DT_Value(Database_File.cre, "TBL_Ledger", "Cradit", "ID = '" & Acc_ID & "' and " & Company_Visible_Filter()))

            Closing_Balance_Set()
        End If
    End Sub
    Private Function Create_Cash_Ledger(sender As TXT)
        Cell("Account Ledger", "", "Create_Close", "")
        Ledger_frm.Name_TXT.Text = sender.Text
        Ledger_frm.close_focus_obj = sender
    End Function
    Public Function Closing_Balance_Set()
        If Acc_ID <> Nothing Then
            If Voucher_Type_LB.Text = "Payroll" Then
                With PAYROLL_ctrl
                    If .Label4.Text = "Dr" Then
                        Label8.Text = Val(Val(Acc_Balance) + nUmBeR_FORMATE(.Label3.Text))
                        Label28.Text = (Acc_Credit - nUmBeR_FORMATE(.Label3.Text))
                    ElseIf .Label4.Text = "Cr" Then
                        Label8.Text = Val(Val(Acc_Balance) - nUmBeR_FORMATE(.Label3.Text))
                        Label28.Text = (Acc_Credit + nUmBeR_FORMATE(.Label3.Text))
                    End If
                End With

            End If
        End If


        Try
            If (Label8.Text) <= 0 Then
                Label8.ForeColor = Color.DimGray
                Label8.Text = N2_FORMATE((Val(Label8.Text) * -1)) & " Cr"
            Else
                Label8.ForeColor = Color.Red
                Label8.Text = N2_FORMATE(Label8.Text) & " Dr"
            End If
        Catch ex As Exception

        End Try



        Try
            If (Label28.Text) <= 0 Then
                Label28.ForeColor = Color.Red
                Label28.Text = ((Val(Label28.Text)))
            Else
                Label28.ForeColor = Color.DimGray
                Label28.Text = (Label28.Text)
            End If
        Catch ex As Exception

        End Try
    End Function

    Private Sub Payroll_Vouchers_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End
        Add_Hander_Remove_Handel(False)
    End Sub

    Private Sub Payroll_Vouchers_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.HADE_TXT.Text = "Payroll Voucher"
        BG_frm.TYP_TXT.Text = VC_Type_

        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text
        Button_Clear()
        Cfg_Link()
        Button_Manage()

        Fill_Source()

        Date_TXT.Focus()
    End Sub

    Private Sub Payroll_Vouchers_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
        Date_TXT.Focus()
    End Sub

    Private Sub Save_TXT_Enter(sender As Object, e As EventArgs) Handles Save_TXT.Enter
        Dim result As DialogResult = Msg_Save_YN(Voucher_No_TXT, Voucher_Name_LB.Text)

        If result = DialogResult.Yes Then
            Save_Data()
        ElseIf result = DialogResult.No Then
            Date_TXT.Focus()
        ElseIf result = DialogResult.Cancel Then
            SendKeys.Send("{BACKSPACE}")
        End If

    End Sub
End Class