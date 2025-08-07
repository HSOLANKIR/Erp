Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Data.SQLite
Imports System.IO
Imports System.Net
Imports System.Text.RegularExpressions
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ListView
Imports Microsoft.Reporting
Imports Newtonsoft.Json.Linq
Public Class Main_Frm
    Public Filter_Word As String
    Public Property Active_ctrl As Control

    Private Function Button_Manage()
        Button_Clear()
        BG_frm.R_1.Text = "|F1 : Shut Company"
        BG_frm.R_3.Text = "F2 : Date"
        BG_frm.R_4.Text = "|F2 : Period"
        'BG_frm.R_5.Text = "|F4 : Search"
    End Function
    Private Sub R_1_Click()
        If BG_frm.HADE_TXT.Text = Application_Name Then
            Me.Dispose()
            Select_Company_frm.Dispose()

            Cell("Select Company", "", "Select", "")
        End If
    End Sub
    Private Sub R_3_Click()
        If BG_frm.HADE_TXT.Text = Application_Name Then
            Set_Date(False, Me)
        End If
    End Sub
    Private Sub R_4_Click()
        If BG_frm.HADE_TXT.Text = Application_Name Then
            Set_Date(True, Me)
        End If
    End Sub
    Private Sub R_5_Click()
        '    If BG_frm.HADE_TXT.Text = Application_Name Then
        '        If Search_Manu_frm.ShowDialog() <> DialogResult.Abort Then
        '            Frm_foCus()
        '        End If
        '    End If
    End Sub
    Private Sub R_6_Click()
        If BG_frm.HADE_TXT.Text = Application_Name Then
            With User_frm
                .TopLevel = False
                BG_frm.BG_PAN.Controls.Add(User_frm)
                .Show()
                .Dock = DockStyle.Fill
                .BringToFront()
                .Focus()
            End With
        End If
    End Sub
    Public Function Apply_Date_Filter(ifPeriod As Boolean)

    End Function
    Private Function Add_Hander_Remove_Handel(Ans As Boolean)
        If Ans = True Then
            AddHandler BG_frm.R_1.Click, AddressOf Me.R_1_Click
            AddHandler BG_frm.R_3.Click, AddressOf Me.R_3_Click
            AddHandler BG_frm.R_4.Click, AddressOf Me.R_4_Click

            AddHandler BG_frm.KeyDown, AddressOf Me.Kee_Down
        Else
            RemoveHandler BG_frm.R_1.Click, AddressOf Me.R_1_Click
            RemoveHandler BG_frm.R_3.Click, AddressOf Me.R_3_Click
            RemoveHandler BG_frm.R_4.Click, AddressOf Me.R_4_Click

            RemoveHandler BG_frm.KeyDown, AddressOf Me.Kee_Down
        End If
    End Function
    Private Sub Kee_Down(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.F1 AndAlso e.Modifiers = Keys.Alt Then
            R_1_Click()
        ElseIf e.KeyCode = Keys.F1 Then
        End If
        If e.KeyCode = Keys.F2 AndAlso e.Modifiers = Keys.Alt Then
            R_4_Click()
        ElseIf e.KeyCode = Keys.F2 Then
            R_3_Click()
        End If
        If e.KeyCode = Keys.F4 AndAlso e.Modifiers = Keys.Alt Then

        ElseIf e.KeyCode = Keys.F4 Then
            R_5_Click()
        End If
    End Sub
    Private Sub Main_Frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BG_frm.HADE_TXT.Text = Application_Name
        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text
        Button_Manage()


        Add_Hander_Remove_Handel(True)
        Frm_foCus()
        PictureBox2.Image = Company_Icn
        PictureBox3.Image = User_Icn
        CompanyName_LB.Text = Company_Name_str
        Serial_TXT.Text = Company_Serial_str
        GST_.Text = "GST : " & Company_GST_str
        Book_From_.Text = "Book From : " & Date_Formate(Company_Book_frm)
        Phone_.Text = Company_Phone_str
        Email_.Text = Company_Email_str
        LC_Name_.Text = LC_Name
        LC_.Text = LC_ID_str
        LC_Status_.Text = LC_Status
        Label8.Text = $"{LC_Expir.ToString("dd-MMM-yyyy")}"

        CompanyAddress_LB.Text = Company_Address_str
        Label10.Text = Login_Type

        If Label10.Text = "Admin Account" Then
            Panel15.Visible = False
        Else
            Panel15.Visible = True
        End If


        'User Details

        UserFull_Name.Text = User_Full_Name
        User_Phone_.Text = User_Phone
        User_Branch_.Text = User_Branch_Name



        Email_ic()
        WHLogin_B.RunWorkerAsync()



        If Company_Class_str = "Laboratory" Then
            Cell_Manu_Next("Gateway of Cryptonix")
        Else
            Cell_Manu_Next("Gateway of Cryptonix")
        End If


        BackgroundWorker1.RunWorkerAsync()
    End Sub
    Private Function Email_ic()
        If Find_DT_Value(Database_File.cmp, "TBL_Features", "Value", "Head = 'Email'") = "Yes" Then
            PictureBox8.Image = My.Resources.mail_on
        Else
            PictureBox8.Image = My.Resources.mail_off
        End If
    End Function
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim cn As New SqlConnection
        If Online_MSSQL(cn) = True Then
            Dim cmmd = New SqlCommand($"Select * From TBL_License where License = '{LC_ID_str}'", cn)
            Dim r As SqlDataReader
            r = cmmd.ExecuteReader
            While r.Read
                Try
                    Dim data As Byte() = DirectCast(r("Photo"), Byte())
                    Dim ms As New MemoryStream(data)
                    LC_Photo = Image.FromStream(ms)
                Catch ex As Exception

                End Try
            End While
            r.Close()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Label4.Text = Date_3.ToString("dddd, dd MMM,yyyy")
        Label3.Text = Date_1.ToString("dd-MM-yyyy") & " to " & Date_2.ToString("dd-MM-yyyy")


        'TableLayoutPanel2.Visible = Whatsapp_YN_fech

        'If Whatsapp_Sending_list.Enable_ = True Then
        '    whatsapp_icn.Image = My.Resources.whatsapp_enable_icn
        'Else
        '    whatsapp_icn.Image = My.Resources.whatsapp_disable_icn
        'End If
    End Sub


    Private Sub Main_Frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.HADE_TXT.Text = Application_Name
        Button_Clear()
        Button_Enabled()
        Button_Manage()
        Email_ic()


        Chart_01()
        Chart_02()
        Chart_03()

        If Chart_Background.IsBusy = False Then
            'Chart_Background.RunWorkerAsync()
        End If
    End Sub

    Dim BS As New BindingSource
    Public BackFocus As TextBox
    Public BackCtrl As Manu_ctrl
    Public Function Cell_Manu_Next(vlu As String)
        Dim ctrl As New Manu_ctrl
        ctrl.Head = vlu
        ctrl.Visible = False
        Panel3.Controls.Add(ctrl)
        ctrl.BringToFront()
        ctrl.Back_Focus = BackFocus
        ctrl.Back_Ctrl = BackCtrl

        If Company_Class_str = "Laboratory" Then
            If vlu = "Gateway of Cryptonix" Then Manu_list_laboratry(ctrl)
            If vlu = "Create" Then Create_list_laboratry(ctrl)
            If vlu = "Alter" Then Alter_list_laboratry(ctrl)
        Else
            If vlu = "Gateway of Cryptonix" Then Manu_list(ctrl)
            If vlu = "Create" Then Create_list(ctrl)
            If vlu = "Other Creation" Then Other_Create_list(ctrl)
            If vlu = "Other Alter" Then Other_Alter_list(ctrl)
            If vlu = "Alter" Then Alter_list(ctrl)
            If vlu = "Banking" Then Banking_list(ctrl)
            If vlu = "Display More Report" Then Display_More_Report(ctrl)
            If vlu = "Account Books" Then Accounting_Book(ctrl)
            If vlu = "Inventory Books" Then Inventory_Books(ctrl)
            If vlu = "Payroll Reports" Then Payroll_Reports(ctrl)
            If vlu = "Register" Then Register_All(ctrl)
            If vlu = "GST Reports" Then GST_Reports(ctrl)
        End If



        obj_center(ctrl, Panel3)

        ctrl.Visible = True
        ctrl.Focus()
    End Function

    Private Function Payroll_Reports(ctrl As Manu_ctrl)
        With ctrl
            .Add_Group("SUMMARY")
            .Add_Item("Pay Slip,P,Display List>PaySlip Summary,Display,Pay_Slip_Summary_BS", True, 17)
            .Add_Item("Payroll Sheet,R,Payroll Sheet,Display,", True, 17)
            .Add_Item("Attendance Sheet,A,Attendance Sheet,Display,", True, 17)

            .Add_Item("Payroll Statement,S,Payroll Statement,Display,", True, 22)
        End With
    End Function
    Private Function Inventory_Books(ctrl As Manu_ctrl)
        With ctrl
            .Add_Group("SUMMARY")
            .Add_Item("Stock Item,I,Display List>Stock Item Monthly,Display,Stock_Item_BS", True, 17)
            .Add_Item("Group Summary,G,Group Stock Summary,Display,", True, 17)

            '.Add_Item("Godown,O,Display List>Group Stock Summary (Godown),Display,Godown_BS,Godown", True, 22)
        End With
    End Function
    Private Function Accounting_Book(ctrl As Manu_ctrl)
        With ctrl
            .Add_Group("SUMMARY")
            .Add_Item("Ledger Statement,L,Display List>Report Ledger,Display,DAL_bs", True, 17)
            .Add_Item("Group Summary,G,Display List>Group Summary,Display,Acc_Group_BS", True, 17)
        End With
    End Function
    Private Function Register_All(ctrl As Manu_ctrl)
        With ctrl
            .Add_Group("ACCOUNTING REGISTERS")
            .Add_Item("Contra,C,Vouchers Register Summary,Display,,Contra", True, 17)
            .Add_Item("Payment,P,Vouchers Register Summary,Display,,Payment", True, 17)
            .Add_Item("Receipt,R,Vouchers Register Summary,Receipt,,Receipt", True, 17)
            .Add_Item("Journal,J,Vouchers Register Summary,Display,,Journal", True, 17)

            .Add_Item("Debit Note,E,Vouchers Register Summary,Display,,Debit Note", True, 22)
            .Add_Item("Credit Note,D,Vouchers Register Summary,Display,,Credit Note", True, 17)

            .Add_Group("INVENTORY REGISTERS")
            .Add_Item("Purchase,U,Vouchers Register Summary,Display,,Purchase", True, 17)
            .Add_Item("Sales,S,Vouchers Register Summary,Display,,Sales", True, 17)
            .Add_Item("Stock Journal,T,Vouchers Register Summary,Display,,Stock Journal", True, 17)

            .Add_Group("OTHER REGISTERS")
            .Add_Item("Purchase Oredr,H,Vouchers Register Summary,Display,,Purchase Order", True, 17)
            .Add_Item("Sales Order,A,Vouchers Register Summary,Display,,Sales Order", True, 17)

            .Add_Item("Inward,I,Vouchers Register Summary,Display,,Inward", True, 22)
            .Add_Item("Outward,W,Vouchers Register Summary,Display,,Outward", True, 17)
        End With
    End Function
    Private Function Display_More_Report(ctrl As Manu_ctrl)
        Dim DayBook As Boolean = From_Access("Day Book", "Display")
        Dim Acc_Statment As Boolean = From_Access("Account Statement", "Display")
        Dim Stock_Summary As Boolean = From_Access("Stock Summary", "Display")

        With ctrl
            .Add_Group("ACCOUNTING REPORTS")
            .Add_Item("Day Book,D,Day Book,Display,", DayBook, 17)

            .Add_Item("Account Books,A,manu,Account Books,", Acc_Statment, 22)
            .Add_Item("Registers,R,manu,Register,", True, 17)
            .Add_Item("GST Reports,G,manu,GST Reports,", True, 17)

            .Add_Group("INVENTORY REPORTS")
            .Add_Item("Inventory Books,I,manu,Inventory Books,", Stock_Summary, 17)

            If Payroll_YN = True Then
                .Add_Group("PAYROLL REPORTS")
                .Add_Item("Payroll Reports,P,manu,Payroll Reports,", Stock_Summary, 17)
            End If

            .Add_Group("EXCEPTION REPORTS")

            If YN_Boolean(Find_Features(Features_Type.Selected_Company, Features_Head.Inventory, "Stock_Reorder_YN"), False) = True Then
                .Add_Item("Re Order Quentity,Q,Reorder Stock Report,Display,", True, 17)
            End If
            .Add_Item("Receivable,E,Receivable Report,Display,", True, 17)
            .Add_Item("Payable,Y,Payable Report,Display,", True, 17)

        End With


    End Function

    Private Function GST_Reports(ctrl As Manu_ctrl)
        With ctrl
            .Add_Group("GSTR")
            .Add_Item("GSTR-1,1,GSTR1,Display,", True, 17)
            '.Add_Item("GSTR-2A,2,Day Book,Display,", True, 17)
            '.Add_Item("GSTR-3B,3,Day Book,Display,", True, 17)

            '.Add_Group("Other Reports")
            '.Add_Item("e-Way Bill,D,Day Book,Display,", True, 17)

        End With
    End Function
    Private Function Other_Alter_list(ctrl As Manu_ctrl)
        Dim Transport As Boolean = From_Access("Transportation", "Alter")

        ctrl.Add_Group("")
        ctrl.Add_Item("Transport,T,Display List>Transport,Alter,Transport_BS", Transport, 17)
        ctrl.Add_Item("WhatsApp Templates,W,Display List>WhatsApp Templates,Alter,WhatsApp_Templates_bs", Transport, 17)
    End Function
    Private Function Other_Create_list(ctrl As Manu_ctrl)
        Dim Transport As Boolean = From_Access("Transportation", "Create")

        ctrl.Add_Group("")
        ctrl.Add_Item("Transport,T,Transport,Create,", Transport, 17)
        ctrl.Add_Item("WhatsApp Templates,W,WhatsApp Templates,Create,", True, 17)
    End Function
    Private Function Banking_list(ctrl As Manu_ctrl)
        ctrl.Add_Group("CHEQUE")
        ctrl.Add_Item("Cheque Printing,P,Display List>CHEQUE,Display,List_Bank", True, 17)

    End Function
    Private Function Alter_list(ctrl As Manu_ctrl)
        Dim Ledger_A As Boolean = From_Access("Account Ledger", "Alter")
        Dim Group_A As Boolean = From_Access("Account Group", "Alter")


        Dim Stock_Group As Boolean = From_Access("Stock Group", "Alter")
        Dim Stock_Category As Boolean = From_Access("Stock Category", "Alter")
        Dim Stock_Unit As Boolean = From_Access("Stock Unit", "Alter")
        Dim Stock_Item As Boolean = From_Access("Stock Item", "Alter")
        Dim Stock_Godown As Boolean = From_Access("Stock Godown", "Alter")
        Dim Voucher_Type As Boolean = From_Access("Voucher Type", "Alter")

        ctrl.Add_Group("Accounting Master")
        ctrl.Add_Item("Group,G,Display List>Account Group,Alter,Acc_Group_BS", Group_A, 17)
        ctrl.Add_Item("Ledger,L,Display List>Account Ledger,Alter,Ledger_BS", Ledger_A, 17)


        ctrl.Add_Group("Inventory Master")
        ctrl.Add_Item("Group,R,Display List>Stock Group,Alter,Stock_Group_BS", Stock_Group, 17)
        ctrl.Add_Item("Unit,U,Display List>Stock Unit,Alter,Stock_Unit_BS,Stock Unit", Stock_Unit, 17)
        ctrl.Add_Item("Item,I,Display List>Stock Item,Alter,Stock_Item_BS", Stock_Godown, 17)

        If YN_Boolean(Find_Features(Features_Type.Selected_Company, Features_Head.Inventory, "Category_YN"), False) = True Then
            ctrl.Add_Item("Category,C,Display List>Stock Category,Alter,Stock_Category_BS", Stock_Category, 25)
        End If
        If YN_Boolean(Find_Features(Features_Type.Selected_Company, Features_Head.Inventory, "Godown_YN"), False) = True Then
            ctrl.Add_Item("Godown,D,Display List>Stock Godown,Alter,Stock_Godown", Stock_Godown, 17)
        End If



        If Payroll_YN = True Then
            ctrl.Add_Group("Payroll Master")
            ctrl.Add_Item("Employee Group,P,Display List>Payroll Group,Alter,Payroll_Group_BS", True, 17)
            ctrl.Add_Item("Employee,E,Display List>Payroll Employee,Alter,Payroll_Employee_BS", True, 17)
            ctrl.Add_Item("Units,T,Display List>Payroll Unit,Alter,Payroll_Unit_BS", True, 17)
            ctrl.Add_Item("Attendance\Production Type,A,Display List>Payroll Attendance\Production Type,Alter,Payroll_Att_Production_Type_BS", True, 17)
            ctrl.Add_Item("Pay Head,Y,Display List>Payroll Pay Head,Alter,Payroll_Payhead_BS", True, 17)

            'ctrl.Add_Item("Salary Details,S,Display List>Salary Details,Alter,Payroll_Employee_BS", True, 25)

            ctrl.Add_Item("Salary Details,S,Salary Details Type,Alter,Payroll_Employee_BS", True, 25)
        End If


        ctrl.Add_Group("Other")
        ctrl.Add_Item("Voucher Type,V,Display List>Voucher Create,Alter,Voucher_Data_BS", Voucher_Type, 17)

        ctrl.Add_Item("Other Alter,O,manu,Other Alter,", True, 17)
    End Function
    Private Function Manu_list_laboratry(ctrl As Manu_ctrl)
        With ctrl
            .admin_diaload = True

            .Add_Group("MASTERS")
            .Add_Item("Create,C,manu,Create,", True, 17)
            .Add_Item("Alter,A,manu,Alter,", True, 17)
            .Add_Item("Vouchers,V,Laboratry Vouchers,Create,", True, 17)
        End With

        Spacial_Report_Fill(ctrl)

    End Function
    Private Function Manu_list(ctrl As Manu_ctrl)
        With ctrl
            .admin_diaload = True

            Dim Stock_Summary As Boolean = From_Access("Stock Summary", "Display")
            Dim Balance_Sheet As Boolean = From_Access("Balance Sheet", "Display")
            Dim Profet_loss As Boolean = From_Access("Profit & Loss Account", "Display")
            Dim DayBook As Boolean = From_Access("Day Book", "Display")

            Dim Acc_Vouchers As Boolean = From_Access("Accounting Vouchers", "Create")
            Dim inv_Vouchers As Boolean = From_Access("Inventory Vouchers", "Create")

            Dim Data_entry As Boolean = False
            If Acc_Vouchers = True Or inv_Vouchers = True Then
                Data_entry = True
            Else
                Data_entry = False
            End If


            .Add_Group("MASTERS")
            .Add_Item("Create,C,manu,Create,", True, 17)
            .Add_Item("Alter,A,manu,Alter,", True, 17)

            .Add_Group("TRANSACTIONS")

            .Add_Item("Vouchers,V,Select Voucher>Voucher BG,Create,Voucher_Create", Data_entry, 17)
            .Add_Item("Day Book,K,Day Book,Display,", DayBook, 17)
            .Add_Item("Search Vouchers,R,Search Vouchers,Display,", True, 17)

            '.Add_Group("UTILITIES")
            '.Add_Item("Banking,N,manu,Banking,", True, 17)


            .Add_Group("REPORT")
            .Add_Item("Stock Summary,S,Group Stock Summary,Display,", Stock_Summary, 17)
            .Add_Item("Balance Sheet,B,Balance Sheet,Display,", Balance_Sheet, 17)
            .Add_Item("Profit & Loss Account,P,Profit & Loss Account,Display,", Profet_loss, 17)

            .Add_Item("Display More Report,D,manu,Display More Report,", True, 25)
        End With


        Spacial_Report_Fill(ctrl)
    End Function
    Private Function Alter_list_laboratry(ctrl As Manu_ctrl)
        ctrl.Add_Group("Accounting Master")
        ctrl.Add_Item("Doctor,D,Display List>Doctor Info,Alter,Laboratory_Doctor", True, 17)

        ctrl.Add_Group("Inventory Master")
        ctrl.Add_Item("Item,I,Display List>Item Info,Alter,Laboratory_Item", True, 17)
        ctrl.Add_Item("Group,G,Display List>Group Laboratory,Alter,Laboratory_Group", True, 17)
        ctrl.Add_Item("Unit,U,Display List>Unit Info,Alter,Laboratory_Unit", True, 17)

    End Function
    Private Function Create_list_laboratry(ctrl As Manu_ctrl)
        ctrl.Add_Group("Accounting Master")
        ctrl.Add_Item("Doctor,D,Doctor Info,Create,", True, 17)

        ctrl.Add_Group("Inventory Master")
        ctrl.Add_Item("Item,I,Item Info,Create,", True, 17)
        ctrl.Add_Item("Group,G,Group Laboratory,Create,", True, 17)
        ctrl.Add_Item("Unit,U,Unit Info,Create,", True, 17)


    End Function
    Private Function Create_list(ctrl As Manu_ctrl)

        Dim Acc_Ledger As Boolean = From_Access("Account Ledger", "Create")
        Dim Acc_Group As Boolean = From_Access("Account Group", "Create")

        Dim Stock_Group As Boolean = From_Access("Stock Group", "Create")
        Dim Stock_Category As Boolean = From_Access("Stock Category", "Create")
        Dim Stock_Unit As Boolean = From_Access("Stock Unit", "Create")
        Dim Stock_Item As Boolean = From_Access("Stock Item", "Create")
        Dim Stock_Godown As Boolean = From_Access("Stock Godown", "Create")
        Dim Voucher_Type As Boolean = From_Access("Voucher Type", "Create")


        ctrl.Add_Group("Accounting Master")
        ctrl.Add_Item("Group,G,Account Group,Create,", Acc_Group, 17)
        ctrl.Add_Item("Ledger,L,Account Ledger,Create,", Acc_Ledger, 17)

        ctrl.Add_Group("Inventory Master")
        ctrl.Add_Item("Group,R,Stock Group,Create,Stock_Group_BS", Stock_Group, 17)
        ctrl.Add_Item("Unit,U,Stock Unit,Create,Stock_Unit_BS", Stock_Unit, 17)
        ctrl.Add_Item("Item,I,Stock Item,Create,Stock_Item_BS", Stock_Godown, 17)

        If YN_Boolean(Find_Features(Features_Type.Selected_Company, Features_Head.Inventory, "Category_YN"), False) = True Then
            ctrl.Add_Item("Category,C,Stock Category,Create,Stock_Category_BS", Stock_Category, 25)
        End If
        If YN_Boolean(Find_Features(Features_Type.Selected_Company, Features_Head.Inventory, "Godown_YN"), False) = True Then
            ctrl.Add_Item("Godown,D,Stock Godown,Create,Stock_Godown", Stock_Godown, 17)
        End If

        If Payroll_YN = True Then
            ctrl.Add_Group("Payroll Master")
            ctrl.Add_Item("Employee Group,P,Payroll Group,Create,Payroll_Group_BS", True, 17)
            ctrl.Add_Item("Employee,E,Payroll Employee,Create,Payroll_Employee_BS", True, 17)
            ctrl.Add_Item("Units,T,Payroll Unit,Create,Payroll_Unit_BS", True, 17)
            ctrl.Add_Item("Attendance\Production Type,A,Payroll Attendance\Production Type,Create,Payroll_Att_Production_Type_BS", True, 17)
            ctrl.Add_Item("Pay Head,P,Payroll Pay Head,Create,Payroll_Payhead_BS", True, 17)

            ctrl.Add_Item("Salary Details,S,Salary Details Type,Alter,Payroll_Employee_BS", True, 25)
        End If

        '6



        ctrl.Add_Group("Other")
        ctrl.Add_Item("Voucher Type,V,Voucher Create,Create,", Voucher_Type, 17)
        ctrl.Add_Item("Other Creation,O,manu,Other Creation,", True, 17)


    End Function
    Public Function Exit_Dialoag()
        Panel21.Visible = True
        Panel21.Focus()
        bg_panels.Visible = False
        My.Computer.Audio.Play(My.Resources.Wharning_Sound, AudioPlayMode.Background)
    End Function
    Private Function Spacial_Report_Fill(ctrl As Manu_ctrl)
        ctrl.Add_Group("SPACIAL REPORT")

        For Each drive As String In Directory.GetDirectories(Application.StartupPath & "\Spacial Report")
            Dim folder_name As String
            folder_name = drive.Split("\").Last
            Dim directry As New DirectoryInfo(folder_name)

            If folder_name.Length > 4 Then
                If folder_name.Split(".").Last = "menu" Then
                    Dim dttt As String() = Find_Company_data(drive, folder_name)
                    If dttt(0) = "Y" Then
                        'dt.Rows.Add("", dttt(1), "UNDER", drive, "Sapcial Report", "GOS", "")
                        ctrl.Add_Item($"{dttt(1)},,{drive},Display,", True, 17)
                    End If
                End If
            End If
        Next

    End Function
    Private Function Find_Company_data(path_data As String, dt As String) As String()
        Dim cn As New SQLiteConnection
        Dim Name_ As String
        Dim Success_ As String

        Dim r As SQLiteDataReader
        Try
            If open_MSSQL_Custom_path(path_data & "\info.db", cn) = True Then
                cmd = New SQLiteCommand($"Select * From TBL_Info", cn)
                r = cmd.ExecuteReader
                r.Read()
                Name_ = r("Name").ToString.Trim
                Success_ = "Y"
                r.Close()
            End If
            cn.Close()
        Catch ex As Exception
            Success_ = "N"
            cn.Close()
        End Try


        Return {Success_, Name_}
    End Function


    Private Sub Main_Frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        Add_Hander_Remove_Handel(False)
    End Sub

    Private Function Chart_01()
        Me.Chart1.Series.Clear()
        Dim count_ As Integer = 0

        Dim Series01 As DataVisualization.Charting.Series = New DataVisualization.Charting.Series()
        Series01.ChartArea = "ChartArea1"
        Series01.ChartType = DataVisualization.Charting.SeriesChartType.Doughnut
        Series01.Font = New Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        Series01.IsValueShownAsLabel = True
        Series01.Legend = "Legend1"
        Series01.Name = "Series01"

        Me.Chart1.Series.Add(Series01)
        Dim cn As New SQLiteConnection
        Dim qr As String = $"Select *,count(Voucher_Type) as vlu From 
(SELECT Voucher_Type
FROM TBL_VC
where Visible = 'Approval' and (Date BETWEEN '{Date_1.ToString(Lite_date_Format) }' and '{Date_2.AddDays(1).ToString(Lite_date_Format) }') and {Company_Visible_Filter()}
GROUP BY Tra_ID)
GROUP BY Voucher_Type"

        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand(qr, cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                Chart1.Series(0).Points.AddXY(r("Voucher_Type"), Val(r("Vlu")))
                count_ += 1
            End While
            r.Close()

            Dim vc_count As Integer = 0
            cmd = New SQLiteCommand("Select count(ID) as C From TBL_VC", cn)
            r = cmd.ExecuteReader
            While r.Read
                vc_count = Val(r("C").ToString)
            End While
            r.Close()

            If vc_count = 0 Then
                Label14.Visible = True
                Chart1.Visible = True
                Chart1.Series(0).Points.AddXY("Sales", 20)
                Chart1.Series(0).Points.AddXY("Purchase", 15)
                Chart1.Series(0).Points.AddXY("Payment", 18)
                Chart1.Series(0).Points.AddXY("Receipt", 22)
                Chart1.Series(0).Points.AddXY("Contra", 8)
                Chart1.Series(0).Points.AddXY("Journal", 22)
                Chart1.Series(0).Points.AddXY("Productiion", 6)
                Chart1.Series(0).Points.AddXY("Attendance", 12)
                Chart1.Series(0).Points.AddXY("Payroll", 5)
                Chart1.Series(0).Points.AddXY("Credit Note", 1)
                Chart1.Series(0).Points.AddXY("Debit Note", 3)
            ElseIf count_ = 0 Then
                Label14.Visible = False
                Chart1.Visible = False
            Else
                Chart1.Visible = True
                Label14.Visible = False
            End If




        End If


    End Function
    Private Function Chart_02()
        Me.Chart2.Series.Clear()
        Dim count_ As Integer = 0

        Dim Series01 As DataVisualization.Charting.Series = New DataVisualization.Charting.Series()
        Series01.ChartArea = "ChartArea1"
        Series01.ChartType = DataVisualization.Charting.SeriesChartType.Pie
        Series01.Font = New Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        Series01.IsValueShownAsLabel = True
        Series01.Legend = "Legend1"
        Series01.Name = "Series01"

        Me.Chart2.Series.Add(Series01)
        Dim cn As New SQLiteConnection
        Dim qr As String = $"Select *,count(Voucher_Type) as vlu From 
(SELECT Voucher_Type
FROM TBL_VC
where Visible = 'Approval' and (Date BETWEEN '{Date_3.ToString(Lite_date_Format) }' and '{Date_3.AddDays(1).ToString(Lite_date_Format) }') and {Company_Visible_Filter()}
GROUP BY Tra_ID)
GROUP BY Voucher_Type"

        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand(qr, cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                Chart2.Series(0).Points.AddXY(r("Voucher_Type"), Val(r("Vlu")))
                count_ += 1

            End While
            r.Close()

            Dim vc_count As Integer = 0
            cmd = New SQLiteCommand("Select count(ID) as C From TBL_VC", cn)
            r = cmd.ExecuteReader
            While r.Read
                vc_count = Val(r("C").ToString)
            End While
            r.Close()

            If vc_count = 0 Then
                Label16.Visible = True
                Chart2.Visible = True
                Chart2.Series(0).Points.AddXY("Sales", 3)
                Chart2.Series(0).Points.AddXY("Purchase", 1)
                Chart2.Series(0).Points.AddXY("Payment", 2)
                Chart2.Series(0).Points.AddXY("Receipt", 3)
                Chart2.Series(0).Points.AddXY("Contra", 1)
                Chart2.Series(0).Points.AddXY("Journal", 5)
            ElseIf count_ = 0 Then
                Label16.Visible = False
                Chart2.Visible = False
            Else
                Chart2.Visible = True
                Label16.Visible = False
            End If
        End If


    End Function
    Private Function Chart_03()
        Me.Chart3.Series.Clear()
        Dim count_ As Integer = 0


        Dim Series1 As DataVisualization.Charting.Series = New DataVisualization.Charting.Series()
        Dim Series2 As DataVisualization.Charting.Series = New DataVisualization.Charting.Series()

        Series1.IsValueShownAsLabel = True
        Series2.IsValueShownAsLabel = True


        Series1.ChartArea = "ChartArea1"
        Series1.Color = Color.Blue
        Series1.Legend = "Legend1"
        Series1.Name = "Purchase"
        Series1.ChartType = DataVisualization.Charting.SeriesChartType.Line

        Series2.ChartArea = "ChartArea1"
        Series2.Color = Color.Red
        Series2.Legend = "Legend1"
        Series2.Name = "Sales"
        Series2.ChartType = DataVisualization.Charting.SeriesChartType.Line

        Chart3.Series.Clear()

        Me.Chart3.Series.Add(Series1)
        Me.Chart3.Series.Add(Series2)

        Me.Chart3.Size = New Size(1246, 209)
        Me.Chart3.Text = "Chart1"



        Dim F_Y As Date
        Dim curr As Date = CDate(Date_3)
        If curr >= CDate($"01-01-{curr.ToString("yyyy")}") And curr <= CDate($"31-03-{curr.ToString("yyyy")}") Then
            F_Y = $"01-04-{curr.AddYears(-1).ToString("yyyy")}"
            Label9.Text = $"Financial Year {curr.AddYears(-1).ToString("yyyy")}-{curr.AddYears(0).ToString("yy")} Sales & Purchase Summary"
        Else
            Label9.Text = $"Financial Year {curr.AddYears(0).ToString("yyyy")}-{curr.AddYears(1).ToString("yy")} Sales & Purchase Summary"
            F_Y = $"01-04-{curr.ToString("yyyy")}"
        End If


        Dim cn As New SQLiteConnection
        Dim r As SQLiteDataReader

        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            Dim vc_count As Integer = 0
            cmd = New SQLiteCommand("Select count(ID) as C From TBL_VC", cn)
            r = cmd.ExecuteReader
            While r.Read
                vc_count = Val(r("C").ToString)
            End While
            r.Close()


            If vc_count <> 0 Then
                For i As Integer = 1 To 12
                    Dim F As Date = F_Y
                    Dim L As Date = F_Y.AddMonths(1)
                    'MsgBox($"{F} - {L}")
                    'System.Threading.Thread.Sleep(100)
                    cmd = New SQLiteCommand($"Select count(vc.ID) as Sales,(Select count(vc1.ID) as Purchase From TBL_VC vc1 Where vc1.Voucher_Type = 'Purchase' and (vc1.Date >= '{F.ToString(Lite_date_Format)}' and vc1.Date < '{L.AddDays(0).ToString(Lite_date_Format)}')) as Purchase From TBL_VC vc Where Voucher_Type = 'Sales' and (vc.Date >= '{F.ToString(Lite_date_Format)}' and vc.Date < '{L.AddDays(0).ToString(Lite_date_Format)}')", cn)
                    r = cmd.ExecuteReader
                    While r.Read
                        Chart3.Series(0).Points.AddXY(F_Y.ToString("MMM."), Val(r("Purchase").ToString))
                        Chart3.Series(1).Points.AddXY(F_Y.ToString("MMM."), Val(r("Sales").ToString))

                        If Val(r("Purchase").ToString) + Val(r("Sales").ToString) <> 0 Then
                            count_ += 1
                        End If
                    End While
                    r.Close()
                    F_Y = F_Y.AddMonths(1)
                Next
            End If






            'MsgBox(count_)
            If vc_count = 0 Then
                Label17.Visible = True
                Chart3.Visible = True

                Chart3.Series(0).Points.AddXY("Apr", Val(10))
                Chart3.Series(1).Points.AddXY("Apr", Val(13))

                Chart3.Series(0).Points.AddXY("May", Val(15))
                Chart3.Series(1).Points.AddXY("May", Val(20))

                Chart3.Series(0).Points.AddXY("Jun", Val(10))
                Chart3.Series(1).Points.AddXY("Jun", Val(22))

                Chart3.Series(0).Points.AddXY("Jul", Val(8))
                Chart3.Series(1).Points.AddXY("Jul", Val(15))

                Chart3.Series(0).Points.AddXY("Aug", Val(24))
                Chart3.Series(1).Points.AddXY("Aug", Val(5))

                Chart3.Series(0).Points.AddXY("Sap", Val(12))
                Chart3.Series(1).Points.AddXY("Sap", Val(22))

                Chart3.Series(0).Points.AddXY("Oct", Val(13))
                Chart3.Series(1).Points.AddXY("Oct", Val(15))

                Chart3.Series(0).Points.AddXY("Nov", Val(18))
                Chart3.Series(1).Points.AddXY("Nov", Val(5))

                Chart3.Series(0).Points.AddXY("Dec", Val(4))
                Chart3.Series(1).Points.AddXY("Dec", Val(9))

                Chart3.Series(0).Points.AddXY("Jan", Val(22))
                Chart3.Series(1).Points.AddXY("Jan", Val(26))

                Chart3.Series(0).Points.AddXY("Feb", Val(16))
                Chart3.Series(1).Points.AddXY("Feb", Val(12))

                Chart3.Series(0).Points.AddXY("Mar", Val(11))
                Chart3.Series(1).Points.AddXY("Mar", Val(28))

            ElseIf count_ = 0 Then
                Label17.Visible = False
                Chart3.Visible = False
            Else
                Chart3.Visible = True
                Label17.Visible = False
            End If



        End If






    End Function

    Private Sub Panel3_Enter(sender As System.Object, e As System.EventArgs)

    End Sub
    Private Sub Txt1_TextChanged(sender As Object, e As EventArgs)

    End Sub
    Private Function Backup_data() As Boolean
        If Msg_Custom_YN(NOT_Location.Bottom_Right, Color.Blue, My.Resources.Database_Backu_gif, Dialoag_Button.Yes_No, "Question?", "Backup Data", $"Do you want to take data backup<nl>if you take data backup then last<nl>'{Auto_Backup_Max}' backup will remain<nl>previous backup will be<nl>deleted automatically.") = DialogResult.Yes Then
            Backup_db_frm.Auto_Backup = True
            Cell("Backup Database", "", "", "")
        Else
            Application.Exit()
        End If
    End Function
    Private Sub Main_Frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        If bg_panels.Visible = False Then
            If e.KeyCode = Keys.Enter Then
                If Directory.Exists(Auto_Backup_Path) And Auto_Backup_YN = True Then
                    Backup_data()
                Else
                    Application.Exit()
                End If
            Else
                Panel21.Visible = False
                bg_panels.Visible = True
                SendKeys.Send("{TAB}")
            End If
        End If
    End Sub

    Private Sub Panel21_Paint(sender As Object, e As PaintEventArgs) Handles Panel21.Paint
        Panel21.Location = New Point(Me.ClientSize.Width / 2 - Panel21.Size.Width / 2, Me.ClientSize.Height / 2 - Panel21.Size.Height / 2)
    End Sub

    Private Sub Label21_Click(sender As Object, e As EventArgs) Handles Label21.Click
        Application.Exit()
        Try
            'whatsapp_drv.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Label23_Click(sender As Object, e As EventArgs) Handles Label23.Click
        Panel21.Visible = False
    End Sub

    Private Sub Txt1_LostFocus(sender As Object, e As EventArgs)

    End Sub

    Private Sub Manu_Panel_Paint(sender As Object, e As PaintEventArgs)
        'Manu_Panel.Location = New Point(Panel3.ClientSize.Width / 2 - Manu_Panel.Size.Width / 2, Panel3.ClientSize.Height / 2 - Manu_Panel.Size.Height / 2)
    End Sub

    Private Sub Main_Frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        Try
            Active_ctrl.Focus()
        Catch ex As Exception

        End Try

        If IsNothing(BackFocus) Then
        Else
            BackCtrl.Show()
            BackFocus.Focus()
        End If
    End Sub

    Private Sub Label82_Click(sender As Object, e As EventArgs)
        Cell("Printing")
    End Sub

    Private Sub ListOfSendingWhatsappToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListOfSendingWhatsappToolStripMenuItem.Click
        Whatsapp_Sending_list.Show()
    End Sub

    Private Sub BulkSenderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BulkSenderToolStripMenuItem.Click
        'Whatsapp_Bulk_Sender_frm.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Cell("Email Login")
    End Sub
    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        PictureBox4.Image = LC_Photo
    End Sub
    Private Sub Manu_ctrl1_Paint(sender As Object, e As PaintEventArgs)
        obj_center(sender, Panel3)
    End Sub

    Private Sub WHLogin_B_DoWork(sender As Object, e As DoWorkEventArgs) Handles WHLogin_B.DoWork
        Try
            If Whatsapp_login_YN(Wh_Local_API, Wh_Local_No) = True Then
                PictureBox7.Image = My.Resources.whatsapp_enable_icn
            Else
                PictureBox7.Image = My.Resources.whatsapp_disable_icn
            End If
        Catch ex As Exception
            PictureBox7.Image = My.Resources.whatsapp_disable_icn
        End Try
    End Sub

    Private Sub WHLogin_B_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles WHLogin_B.RunWorkerCompleted

    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        Cell("Whatsapp")

    End Sub
    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        'With Spacial_Report_Opning_frm
        '    .path = "E:\PROGRAMS\Cryptonix®\Cryptonix Spacial Report\Hospital\Hospital\Hospital\bin\Debug\Hospital.exe"
        '    .Show()
        'End With

        'Create_aud($"{Connection_Path}\{Connection_Data}")


    End Sub

    Private Sub Chart_Background_DoWork(sender As Object, e As DoWorkEventArgs) Handles Chart_Background.DoWork
        Chart_01()
        Chart_02()
        Chart_03()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Process.Start("https://cryptonixtechnology.in/")
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click

    End Sub

    Private Sub Main_Frm_Leave(sender As Object, e As EventArgs) Handles Me.Leave
        'Active_ctrl = Me.ActiveControl
    End Sub

    Private Sub Main_Frm_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        'Active_ctrl = Me.ActiveControl
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub
End Class