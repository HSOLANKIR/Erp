Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Data.SQLite
Imports System.IO

Public Class Login_Frm
    Dim From_ID As String
    Declare Auto Function SendMessage Lib "user32.dll" (ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    Dim isSuccess As Boolean
    Dim isSuccess_Con As Boolean
    Dim isSuccess_Company_Chack As Boolean
    Dim isSuccess_Device_Chack As Boolean
    Dim isSuccess_Login_Chack As Boolean
    Dim CompanyIssuccess As New Boolean
    Dim Path_End As String
    Dim ll, II, PP As Integer
    Public vc_Type_ As String
    Private Sub Login_Frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        obj_center(Login_Panel, Me)

        Label1.Text = Company_Name_str
        Label4.Text = Company_Name_str & vbNewLine & "0% Complete"
        Button_Clear()
        PictureBox1.Image = My.Resources.Loding_Progress
        PictureBox2.Image = My.Resources.Loding_Progress
        PictureBox3.Image = My.Resources.Loding_Progress
        PictureBox4.Image = My.Resources.Loding_Progress



        Path_End = BG_frm.BG_Path_TXT.Text
        BG_frm.BG_Path_TXT.Text &= "Login"

        vc_Type_ = Link_Valu(1)

        BG_frm.TYP_TXT.Text = vc_Type_
        Add_Hander_Remove_Handel(True)

        'Live LAB
        Live_Tmr.Enabled = True
        Text = Company_Name_str & vbNewLine & "        "
        ll = Len(Text)
        II = 1
        PP = 1
        Live_TXT.Text = ""
        User_TXT.Focus()

        SendMessage(ProgressBar1.Handle, &H410, &H1, 0)

        'MsgBox(Me.FindForm.Name)

    End Sub
    Private Function Button_Manage()
        Button_Clear()
        BG_frm.R_3.Text = "F3 : Company Create"
        BG_frm.R_4.Text = "|F3 : Company Select"
        BG_frm.R_5.Text = "F4 : Import Company"
        BG_frm.R_7.Text = "F5 : Forgot Password"

    End Function
    Private Function Add_Hander_Remove_Handel(Ans As Boolean)
        If Ans = True Then
            AddHandler BG_frm.R_3.Click, AddressOf Me.R_3_Click
            AddHandler BG_frm.R_4.Click, AddressOf Me.R_4_Click
            AddHandler BG_frm.R_5.Click, AddressOf Me.R_5_Click
            AddHandler BG_frm.R_7.Click, AddressOf Me.R_6_Click
            AddHandler BG_frm.KeyDown, AddressOf Me.R_1_Keedown
        Else
            RemoveHandler BG_frm.R_3.Click, AddressOf Me.R_3_Click
            RemoveHandler BG_frm.R_4.Click, AddressOf Me.R_4_Click
            RemoveHandler BG_frm.R_5.Click, AddressOf Me.R_5_Click
            RemoveHandler BG_frm.R_7.Click, AddressOf Me.R_6_Click
            RemoveHandler BG_frm.KeyDown, AddressOf Me.R_1_Keedown
        End If
    End Function
    Private Sub R_3_Click()
        If BG_frm.From_ID = From_ID Then
            Cell("Company Information", "", "Create", "")
        End If
    End Sub
    Private Sub R_4_Click()
        If BG_frm.From_ID = From_ID Then
            Me.Dispose()
            With Select_Company_frm
                .TopLevel = False
                BG_frm.BG_PAN.Controls.Add(Select_Company_frm)
                .Show()
                .Dock = DockStyle.Fill
                .BringToFront()
                .Focus()
            End With
        End If
    End Sub
    Private Sub R_5_Click()
        If BG_frm.From_ID = From_ID Then
            Cell("Import Company", "", "Create", "")
        End If
    End Sub
    Private Sub R_6_Click()
        If BG_frm.From_ID = From_ID Then
            Cell("Password Manager", "", "Create", "")
        End If
    End Sub
    Private Sub R_1_Keedown(sender As Object, e As KeyEventArgs)
        If BG_frm.From_ID = From_ID Then
            If e.KeyCode = Keys.F3 AndAlso e.Modifiers = Keys.Alt Then
                R_4_Click()
            ElseIf e.KeyCode = Keys.F3 Then
                R_3_Click()
            End If
            If e.KeyCode = Keys.F4 Then
                R_5_Click()
            End If
            If e.KeyCode = Keys.F5 Then
                R_6_Click()
            End If
            If e.KeyCode = Keys.F12 Then
                Server_frm.ShowDialog()
            End If
        End If
    End Sub

    Private Sub Login_Frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        NOT_Clear()
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
            Cell("Select Company")
        End If
    End Sub

    Private Sub Login_Frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter

        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.TYP_TXT.Text = vc_Type_

        BG_frm.HADE_TXT.Text = "Login"
        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text

        Button_Clear()
        Button_Manage()
        User_TXT.Focus()
    End Sub

    Private Sub Password_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles Password_TXT.KeyDown
        If e.KeyCode = Keys.Enter Then
            'If My.Computer.Network.IsAvailable = True Then
            If User_TXT.Text = Nothing Then
                User_TXT.Focus()
                Exit Sub
            End If
            If Password_TXT.Text = Nothing Then
                Password_TXT.Focus()
                Exit Sub
            End If
            Panel_Manage(Server_Connection_Panel)
            User_Icn = Nothing


            PictureBox1.Image = My.Resources.Loding_Progress
            PictureBox2.Image = My.Resources.Loding_Progress
            PictureBox3.Image = My.Resources.Loding_Progress
            PictureBox4.Image = My.Resources.Loding_Progress

            Label9.Text = "Wait.."
            Label12.Text = "Wait.."
            Label13.Text = "Wait.."
            Label14.Text = "Wait.."

            Label7.ForeColor = Color.Black
            Label8.ForeColor = Color.Black
            Label10.ForeColor = Color.Black
            Label11.ForeColor = Color.Black

            Login_search_Background.RunWorkerAsync()
        End If
    End Sub

    Private Sub Login_search_Background_DoWork(sender As Object, e As DoWorkEventArgs) Handles Login_search_Background.DoWork

        isSuccess = LOGIN_SUCCESS()

    End Sub

    Dim eror_head As String = ""
    Dim eror_msgg As String = ""

    Private Function LOGIN_SUCCESS() As Boolean
        User_Icn = Nothing
        Dim cn As New SqlConnection

        If Online_MSSQL(cn) = True Then
            isSuccess_Con = True
            PictureBox1.Image = My.Resources.Success_PNG
            Label7.ForeColor = Color.Green
            Label9.Text = "Your Device is Connected Server"
            Login_search_Background.ReportProgress(25)
            If Chack_Company_Status(cn) = "Approval" Then
                isSuccess_Company_Chack = True
                PictureBox2.Image = My.Resources.Success_PNG
                Label8.ForeColor = Color.Green
                Label12.Text = "The Company is Approved."
                Login_search_Background.ReportProgress(50)
                If Chack_Device_Status(cn) = "Approval" Then
                    isSuccess_Device_Chack = True
                    PictureBox3.Image = My.Resources.Success_PNG
                    Label10.ForeColor = Color.Green
                    Label13.Text = "Your License is Valid For The Company."
                    Login_search_Background.ReportProgress(75)
                    If Chach_Login(cn) = True Then
                        Label14.Text = $"Login Successful ({Login_Type_str})"
                        Login_search_Background.ReportProgress(99)
                        isSuccess = True
                        isSuccess_Login_Chack = True
                        PictureBox4.Image = My.Resources.Success_PNG
                        Label11.ForeColor = Color.Green
                    Else
                        isSuccess = False
                        isSuccess_Login_Chack = False

                        PictureBox4.Image = My.Resources.Error_PNG
                        Label11.ForeColor = Color.Red
                        Label14.Text = $"Login Unsuccessful"
                    End If
                Else
                    isSuccess_Device_Chack = False
                    PictureBox3.Image = My.Resources.Error_PNG
                    Label10.ForeColor = Color.Red
                    Label13.Text = "Your License is Not Valid For The Company."
                End If
            Else
                isSuccess = False
                isSuccess_Company_Chack = False
                PictureBox2.Image = My.Resources.Error_PNG
                Label8.ForeColor = Color.Red
                Label12.Text = "Company Not Vaid."
            End If
        Else
            isSuccess = False
            isSuccess_Con = False
            PictureBox1.Image = My.Resources.Error_PNG
            Label7.ForeColor = Color.Red
            Label9.Text = "Your Device is Not Connected to the Server."
            'Msg_Custom_YN(NOT_Location.Bottom_Right, Color.Red, My.Resources.Database_Error_animation_icn, Dialoag_Button.Ok, "Error !", "Company Data", "Company data is not detected")
        End If
        con.Close()
        Return isSuccess
    End Function
    Dim red As SqlDataReader
    Private Function Chack_Company_Status(cn As SqlConnection) As String

        Company_Icn = Nothing
        Company_stmp = Nothing
        Company_sig = Nothing

        Dim st As String
        qury = $"SELECT ID,CompanyName,CompanySerial,Class,Address,Phone,Email,GSTNo,PANCard,State,Bank,Branch,AccountNo,IFCCode,UPI,City,RegNo,Pincode,Book_Frm,License_No,GST_Type,Approval,Branch_Division,Audit_YN FROM TBL_Company_Creation Where ID = '{Company_ID_str}'"

        Dim cmd As New SqlCommand(qury, cn)
        cmd.ExecuteNonQuery()
        red = cmd.ExecuteReader

        Dim instal_lic As Boolean = False


        While red.Read
            Try
                st = red("Approval")

                Company_Book_frm = red("Book_Frm").ToString
                Audit_YN = YN_Boolean(red("Audit_YN").ToString, False)

                Company_ID_str = red("ID").ToString
                Company_Name_str = red("CompanyName").ToString
                Company_Serial_str = red("CompanySerial").ToString
                Company_Class_str = red("Class").ToString
                Company_Address_str = red("Address").ToString
                Company_Phone_str = red("Phone").ToString
                Company_Email_str = red("Email").ToString
                Company_GST_str = red("GSTNo").ToString
                Company_PAN_str = red("PANCard").ToString
                Company_State_str = red("State").ToString
                Company_Bank_Name_str = red("Bank").ToString
                Company_Bank_Branch_str = red("Branch").ToString
                Company_Bank_Account_No_str = red("AccountNo").ToString
                Company_Bank_IFSC_Code_str = red("IFCCode").ToString
                Company_UPI_str = red("UPI").ToString
                Company_City_str = red("City").ToString
                Company_RegNo_str = red("RegNo").ToString
                Company_Pincode_str = red("Pincode").ToString
                Company_Book_frm = CDate(red("Book_Frm"))
                Company_Ststus_str = (red("Approval"))

                'Company_Server_str = (red("Server_Name"))
                'Company_Server_Database_str = (red("Server_Database"))
                'Company_Server_UserName_str = (red("Server_UserName"))
                'Company_Server_Password_str = (red("Server_Password"))


                If red("License_No").ToString.Length < 5 Then
                    instal_lic = True
                End If

                Try
                    Company_GST_Type_str = red("GST_Type").ToString
                Catch ex As Exception

                End Try
            Catch ex As Exception
                MsgBox(ex.Message)

            End Try
        End While
        red.Close()


        If instal_lic = True Then
            qury = $"UPDATE TBL_Company_Creation SET License_No = '{LC_ID_str}' Where ID = '{Company_ID_str}'"
            cmd = New SqlCommand(qury, cn)
            cmd.ExecuteNonQuery()
        End If

        DB_Version = Find_DT_Value(Database_File.cmp, "TBL_Company_Creation", "DB_Version", "ID <> '000'")

        'Update_Offile_data()

        Return st
    End Function

    Private Function Chack_Device_Status(cn As SqlConnection) As String
        Dim st As String = "NA"
        qury = $"SELECT * FROM TBL_Developers Where Serial = '{Computer_Serial()}' and Visible = 'Approval'"
        Dim cmd As New SqlCommand(qury, cn)
        cmd.ExecuteNonQuery()
        red = cmd.ExecuteReader

        While red.Read
            st = red("Visible").ToString
        End While
        red.Close()

        If st <> "Approval" Then
            qury = $"SELECT * FROM TBL_Lic_link_Cmp Where Company_Serial = '{Company_Serial_str}' AND License_No = '{LC_ID_str}'"
            cmd = New SqlCommand(qury, cn)
            cmd.ExecuteNonQuery()
            red = cmd.ExecuteReader
            While red.Read
                st = red("Status").ToString
                PC_ID = red("ID").ToString
            End While
            red.Close()
        End If
        Return st
    End Function
    Private Function Chach_Login(cn As SqlConnection) As Boolean
        If Chack_Company_User(cn) = True Then
            isSuccess = True
            CompanyIssuccess = True
            Fill_User_Authorty(cn, 0)
        Else
            CompanyIssuccess = False
            If Chach_User(cn) = True Then
                isSuccess = True
                'User_Login_Information(cn)
            Else
                isSuccess = False
            End If
        End If
        Fill_Settings()
        Return isSuccess
    End Function
    Private Function Fill_Settings()
        Date_3 = Now.Date

        Date_1 = CDate("01-" & Now.Month & "-" & Now.Year)

        Try
            Date_2 = CDate("31-" & Now.Month & "-" & Now.Year)
        Catch ex As Exception
            Try
                Date_2 = CDate("30-" & Now.Month & "-" & Now.Year)
            Catch ex0 As Exception
                Try
                    Date_2 = CDate("29-" & Now.Month & "-" & Now.Year)
                Catch ex1 As Exception
                    Try
                        Date_2 = CDate("28-" & Now.Month & "-" & Now.Year)
                    Catch ex2 As Exception

                    End Try
                End Try
            End Try
        End Try
    End Function
    Private Function Chack_Company_User(cn As SqlConnection) As Boolean
        'Dim st As String
        qury = $"SELECT UserName,CompanyName,Email,Phone FROM TBL_Company_Creation Where ID = '{Company_ID_str }' AND UserName = '{User_TXT.Text}' AND Password = '{Password_TXT.Text }'"
        Dim cmd As New SqlCommand(qury, cn)
        cmd.ExecuteNonQuery()
        red = cmd.ExecuteReader
        red.Read()

        Try
            'st = red("Approval")
            'Try
            '    Dim data As Byte() = DirectCast(red("Photo"), Byte())

            '    Dim ms As New MemoryStream(data)
            '    Dim im As Image = Image.FromStream(ms)
            '    User_Icn = Image.FromStream(ms)
            'Catch ex As Exception

            'End Try

            Login_Type_str = "Admin Account"
            Login_Type = "Admin Account"
            Branch_ID = "0"
            Branch_Name = "Primary"
            Dft_Branch = "Primary"

            User_Name = red("UserName")
            LOGIN_ID = "0"
            Login_Name = red("CompanyName")
            Login_Email = red("Email")
            Login_Phone = red("Phone")
            My.Settings.Save()

            isSuccess = True
        Catch ex As Exception
            isSuccess = False
        End Try
        red.Close()
        Return isSuccess
    End Function
    Private Function Company_Login_Information()

    End Function
    Private Function Chach_User(cn As SqlConnection) As Boolean
        Dim st As String
        qury = $"SELECT * FROM TBL_Login Where CompanySerial = '{Company_ID_str }' AND UserName = '{User_TXT.Text}' AND Password = '{Password_TXT.Text }'"
        Dim cmd As New SqlCommand(qury, cn)
        cmd.ExecuteNonQuery()
        red = cmd.ExecuteReader
        red.Read()
        Try
            st = red("Approval")

            Dim Frist As String = ""
            Dim Middal As String = ""
            Dim Last As String = ""
            Frist = red("FristName")
            Middal = red("MiddleName")
            Last = red("LastName")
            Login_Name = Frist & " " & Middal & " " & Last
            Branch_ID = red("Branch")
            Login_Phone = red("Phone")
            Login_Email = red("Email")
            LOGIN_ID = red("ID")
            Login_Type = "User Account"
            Login_Type_str = "User Account"

            User_Full_Name = Frist & " " & Middal & " " & Last
            User_Branch_ID = red("Branch")
            User_Phone = red("Phone")
            User_Email = red("Email")
            User_ID = red("ID")
            User_Name = red("UserName")

            User_Branch_Name = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Name", $"ID = '{User_Branch_ID}'")

            Try
                st = red("Approval")
                Dim data As Byte() = DirectCast(red("Photo"), Byte())
                Dim ms As New MemoryStream(data)
                Dim im As Image = Image.FromStream(ms)
                User_Icn = Image.FromStream(ms)
            Catch ex As Exception

            End Try
            red.Close()

            Fill_User_Authorty(cn, User_ID)
            isSuccess = True
        Catch ex As Exception
            isSuccess = False
        End Try


        If isSuccess = True Then
            Dim rd As SQLiteDataReader
            Dim cn1 As New SQLiteConnection
            Dim BA_N As String = ""
            If open_MSSQL_Cstm(Database_File.cre, cn1) Then
                qury = $"SELECT * FROM TBL_Ledger Where ID = '{Branch_ID}'"
                Dim cmd4 As New SQLiteCommand(qury, cn1)
                cmd4.ExecuteNonQuery()
                rd = cmd4.ExecuteReader
                rd.Read()

                Try
                    BA_N = rd("Name")
                Catch ex As Exception
                    BA_N = "Primary"
                End Try
                Branch_Name = BA_N
                Dft_Branch = BA_N
                rd.Close()
                My.Settings.Save()
                con.Close()
            End If
        End If

        red.Close()
        Return isSuccess
    End Function
    Private Function User_Login_Information(cn As SqlConnection)
        Login_Type = "User Account"
        Login_Type_str = "User Account"
        'Login Name
        qury = "SELECT * FROM TBL_Login Where CompanySerial = " & "'" & Company_ID_str & "' AND UserName = '" & User_TXT.Text & "' AND Password = '" & Password_TXT.Text & "'"
        Dim cmd As New SqlCommand(qury, cn)
        cmd.ExecuteNonQuery()
        red = cmd.ExecuteReader
        While red.Read
            Dim Frist As String = ""
            Dim Middal As String = ""
            Dim Last As String = ""
            Frist = red("FristName")
            Middal = red("MiddleName")
            Last = red("LastName")
            Login_Name = Frist & " " & Middal & " " & Last
            Branch_ID = red("Branch")
            Login_Phone = red("Phone")
            Login_Email = red("Email")
            LOGIN_ID = red("ID")

            User_Full_Name = Frist & " " & Middal & " " & Last
            User_Branch_ID = red("Branch")
            User_Phone = red("Phone")
            User_Email = red("Email")
            User_ID = red("ID")
            User_Name = red("UserName")

            User_Branch_Name = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Name", $"ID = '{User_Branch_ID}'")
        End While
        red.Close()

        My.Settings.Save()


        Dim rd As SQLiteDataReader
        Dim cn1 As New SQLiteConnection
        Dim BA_N As String = ""
        If open_MSSQL_Cstm(Database_File.cre, cn1) Then
            qury = "SELECT * FROM TBL_Ledger Where ID = '" & Branch_ID & "'"
            Dim cmd4 As New SQLiteCommand(qury, cn1)
            cmd4.ExecuteNonQuery()
            rd = cmd4.ExecuteReader
            rd.Read()

            Try
                BA_N = rd("Name")
            Catch ex As Exception
                BA_N = "Primary"
            End Try
            Branch_Name = BA_N
            Dft_Branch = BA_N
            rd.Close()
            My.Settings.Save()
            con.Close()
        End If
    End Function
    Private Function Fill_User_Authorty(cno As SqlConnection, id As String)
        Dim cn As New SQLiteConnection

        If open_MSSQL_Cstm(Database_File.cmp, cn) = True Then
            Dim str As String = "DELETE FROM TBL_User_Authority;" & vbNewLine

            Dim cmd_o As New SqlCommand($"Select * From TBL_User_Authority where User_ID = '{id}'", cno)
            Dim r As SqlDataReader
            r = cmd_o.ExecuteReader
            While r.Read
                str &= $"INSERT INTO TBL_User_Authority (Head, Value) VALUES ('{r("Head")}','{r("Value")}');" & vbNewLine
            End While

            cmd = New SQLiteCommand(str, cn)
            cmd.ExecuteNonQuery()
        End If
    End Function
    Dim DB_Version As String
    Private Sub Login_search_Background_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles Login_search_Background.RunWorkerCompleted
        If isSuccess_Con = False Then
            Msg_Custom_YN(NOT_Location.Bottom_Right, Color.Red, My.Resources.Database_Error_animation_icn, Dialoag_Button.Ok, "Error !", "Company Data", "Company data is not detected")
            Login_Fales()
            Exit Sub
        End If


        If isSuccess_Company_Chack = False Then
            Msg_Custom_YN(NOT_Location.Bottom_Right, Color.Red, My.Resources.Error_animation_icn, Dialoag_Button.Ok, "Error !", "Company Registration", "The company you selected is not a registered company")
            Login_Fales()
            Exit Sub
        End If


        If isSuccess_Device_Chack = False Then
            Msg_Custom_YN(NOT_Location.Bottom_Right, Color.Red, My.Resources.PC_Error_animation_icn, Dialoag_Button.Ok, "Error !", "License Error", "Your license is not valid<nl>for the company you selected.")
            Login_Fales()
            Exit Sub
        End If


        If isSuccess_Login_Chack = False Then
            Msg_Custom_YN(NOT_Location.Bottom_Right, Color.Red, My.Resources.Error_animation_icn, Dialoag_Button.Ok, "Error !", "Username or Password", "Please check username or password<nl> Username of Password is wrong<nl>Please enter correct username and password<nl> and try again")
            Login_Fales()
            Exit Sub
        End If

        If isSuccess = True Then
            Login_YN = True
            Login_Password = Password_TXT.Text
            'Compamy_Print_Data_INstall()

            If My.Computer.FileSystem.FileExists($"{Connection_Path}\{Connection_Data}\aud.db") = False Then
                Create_aud($"{Connection_Path}\{Connection_Data}")
            End If

            BG_Head_frm.CMP_TXT.Text = Company_Name_str
            open_MSSQL_Audit()


            If Database_verification_frm.Cheack_ = True Then
                Database_repair_frm.Databse_Version_Fatch($"{Connection_Path}\{Connection_Data}")
            End If
        Else
            Login_Fales()
            Exit Sub
        End If
    End Sub
    Private Function Login_Fales()
        Login_YN = False
        Panel_Manage(Login_Panel)
        User_TXT.Focus()
    End Function

    Public Function db_fatch_Success()
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cfgs, cn) = True Then
            cmd = New SQLiteCommand($"DELETE FROM TBL_dft_Company_Details;
INSERT INTO TBL_dft_Company_Details (Path,Cmp_ID,Name) VALUES ('{Connection_Path}','{Connection_Data.Split(".").First}','{Company_Name_str}')", cn)
            cmd.ExecuteReader()
        End If

        'With Cmpany_Data_import_offline_dialiag
        '    If .ShowDialog() <> DialogResult.Yes Then
        '        Me_Reset()
        '        Exit Function
        '    End If
        'End With

        If vc_Type_ = "Login Company" Then
            Me.Dispose()
            Cell("Load Data")
        ElseIf vc_Type_ = "Alteration Company" Then
            If Login_Type = "Admin Account" Then
                Cell("Company Information", "", "Alter", Company_ID_str)
            Else
                If Msg_Custom_YN(NOT_Location.Bottom_Right, Color.Red, My.Resources.Login_animation_icn, Dialoag_Button.Retry_Cancel, "Error", $"Login Error", $"Please login admin account,<nl>and try again") <> DialogResult.Retry Then
                    Me.Dispose()
                    Cell("Select Company")
                End If
            End If
            Panel_Manage(Login_Panel)
            Password_TXT.Text = ""
            User_TXT.Focus()


        ElseIf vc_Type_ = "Restore Database" Then
            Me.Dispose()
            Cell("Company Select", "", "", "")
            Cell("Restore Database", "", "", "")
            Restore_db_frm.Path_TXT.Focus()
        End If
    End Function
    Private Function Me_Reset()
        User_TXT.Text = ""
        Password_TXT.Text = ""

        PictureBox1.Image = My.Resources.Loding_Progress
        PictureBox2.Image = My.Resources.Loding_Progress
        PictureBox3.Image = My.Resources.Loding_Progress
        PictureBox4.Image = My.Resources.Loding_Progress

        Panel_Manage(Login_Panel)
    End Function

    Private Sub Login_search_Background_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles Login_search_Background.ProgressChanged
        ProgressBar1.Value = (e.ProgressPercentage)
        ProgressBar1.Run(0)
        Label4.Text = Company_Name_str & vbNewLine & ProgressBar1.Value & "% Complete"

        'If isSuccess_Con = True Then
        '    PictureBox1.Image = My.Resources.Success_PNG
        '    Label7.ForeColor = Color.Green
        'Else
        '    PictureBox1.Image = My.Resources.Error_PNG
        '    Label7.ForeColor = Color.Red
        'End If


        'If isSuccess_Company_Chack = True Then
        '    PictureBox2.Image = My.Resources.Success_PNG
        '    Label8.ForeColor = Color.Green
        'Else
        '    PictureBox2.Image = My.Resources.Error_PNG
        '    Label8.ForeColor = Color.Red
        'End If


        'If isSuccess_Device_Chack = True Then
        '    PictureBox3.Image = My.Resources.Success_PNG
        '    Label10.ForeColor = Color.Green
        'Else
        '    PictureBox3.Image = My.Resources.Error_PNG
        '    Label10.ForeColor = Color.Red
        'End If


        'If isSuccess_Login_Chack = True Then
        '    PictureBox4.Image = My.Resources.Success_PNG
        '    Label11.ForeColor = Color.Green
        'Else
        '    PictureBox4.Image = My.Resources.Error_PNG
        '    Label11.ForeColor = Color.Red
        'End If
    End Sub

    Private Sub Live_Tmr_Tick(sender As Object, e As EventArgs) Handles Live_Tmr.Tick
        Try
            Live_TXT.Text = Live_TXT.Text + Mid(Text, II, 1)
            If II > ll Then
                II = 0
                Live_TXT.Text = ""
            End If
            II = II + 1
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Password_TXT_TextChanged(sender As Object, e As EventArgs) Handles Password_TXT.TextChanged

    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Me.Dispose()
        Cell("Select Company")
    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub feebank_P_Paint_1(sender As Object, e As PaintEventArgs) Handles Login_Panel.Paint
        obj_center(Login_Panel, Me)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Dispose()
        Cell("Select Company")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Application.Exit()
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

    End Sub

    Private Sub Panel7_Paint(sender As Object, e As PaintEventArgs) Handles Server_Connection_Panel.Paint
        obj_center(sender, Me)
    End Sub

    Private Sub Label18_Click(sender As Object, e As EventArgs) Handles Label18.Click

    End Sub

    Private Sub Load_Company_Data_DoWork(sender As Object, e As DoWorkEventArgs)

    End Sub

    Private Sub Login_Frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End
        Add_Hander_Remove_Handel(True)
        'Frm_foCus()
    End Sub
    Private Sub Login_Frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
        User_TXT.Focus()
    End Sub

    Private Sub Import_Company_Data_Panel_Paint(sender As Object, e As PaintEventArgs)
        obj_center(sender, Me)
    End Sub

    Private Function Panel_Manage(p As Panel)
        Login_Panel.Visible = False
        Server_Connection_Panel.Visible = False


        p.Visible = True
    End Function

End Class