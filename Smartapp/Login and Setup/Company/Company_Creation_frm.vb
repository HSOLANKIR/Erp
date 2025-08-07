Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Data.SQLite
Imports System.IO
Imports Tools

Public Class Company_Creation_frm
    Dim From_ID As String
    Dim issuccess As Boolean
    Dim Path_End As String
    Dim VC_Type_ As String
    Dim VC_ID_ As String
    Dim cnc As New SQLiteConnection
    Private Sub Company_Creation_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Button_Manage()
        Path_End = BG_frm.BG_Path_TXT.Text
        BG_frm.HADE_TXT.Text = "Company Information"

        Path_TXT.Text = Connection_Path
        If Path_TXT.Text.Trim = Nothing Then
            Path_TXT.Text = Application.StartupPath & "\Data"
        End If

        VC_Type_ = Link_Valu(1)
        VC_ID_ = Link_Valu(2)
        BG_frm.TYP_TXT.Text = VC_Type_
        Financial_Year_TXT.Text = Now.Date.ToString("dd-MM-yyyy")


        If VC_Type_ = "Display" Or VC_Type_ = "Display_Close" Then
            Me.Enabled = False
            Display_Fill_All()
            Path_TXT.Enabled = False
        ElseIf VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close" Then
            Path_TXT.Enabled = False
            Path_TXT.Text = ""
            Load_(True, "Please Wait" + vbNewLine & "Load Company Data")
            If open_MSSQL_Cstm(Database_File.cmp, cnc) = True Then
                Load_Details.RunWorkerAsync()
            End If
        ElseIf VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            Email_TXT.Text = LC_Email
            Phone_TXT.Text = LC_Phone
            Load_(False, "")
            Path_TXT.Focus()
        End If
        Fill_Source()
        List_set()

        Add_Hander_Remove_Handel(True)

        Pincode_TXT.MaxLength = 6
    End Sub
    Private Function Button_Manage()
        Button_Clear()
        BG_frm.B_1.Text = "&E : Exit"
        BG_frm.B_2.Text = "&S : Save"
        If VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close" Then
            BG_frm.B_3.Text = "&D : Delete"
        End If

        BG_frm.HADE_TXT.Text = "Company Information"
    End Function
    Private Function Add_Hander_Remove_Handel(Ans As Boolean)
        If Ans = True Then
            AddHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            AddHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
            AddHandler BG_frm.B_3.Click, AddressOf Me.B_3_Click
        Else
            RemoveHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            RemoveHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
            RemoveHandler BG_frm.B_3.Click, AddressOf Me.B_3_Click
        End If
    End Function
    Private Sub B_1_Click(sender As Object, e As EventArgs)
        Me.Dispose()
    End Sub
    Dim cn As New SqlConnection
    Private Sub B_2_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Save_Company()
        End If
    End Sub
    Private Sub B_3_Click(sender As Object, e As EventArgs)
        If VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close" Then
            If BG_frm.From_ID = From_ID Then
                'Delete_Data()
            End If
        End If
    End Sub
    Private Sub B_4_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Dim OpenFile As New OpenFileDialog()
        Try
            With OpenFile
                .FileName = ""
                .Title = "LOGO:"
                .Filter = "Company Logo : (*.png)|*.png"
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    Logo_ = Byte_(.FileName)
                    Me.PictureBox1.Image = System.Drawing.Image.FromFile(.FileName)
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Error...")
        End Try
    End Sub

    Private Sub TextBox4_LostFocus(sender As Object, e As EventArgs) Handles Financial_Year_TXT.LostFocus
        Financial_Year_TXT.Text = Date_Formate(Financial_Year_TXT.Text)
        If Financial_Year_TXT.Text = Nothing Then
            Financial_Year_TXT.Text = Date_Formate(Now.Date)
        End If
    End Sub
    Private Function Company_Serial_create()
        Dim F1 As String = Now.Date.ToString("yy").Substring(0, 1)
        Dim F2 As String = Now.Date.ToString("yy").Substring(1, 1)
        Dim Y As String = Company_Name_TXT.Text.Length

        Dim H1 As String = "CS" & F1 & Format(Val(Y), "00") & F2


        Dim F3 As String = ABC_Find(Company_Name_TXT.Text.Substring(Company_Name_TXT.Text.Length - 1, 1).ToUpper)


        Dim F4 As String = ABC_Find(Company_Name_TXT.Text.Substring(0, 1).ToUpper)

        Dim H2 As String = F4 & Format(Val(CDate(Now.Date).ToString("dd")), "00") & Format(Val(CDate(Now.Date).ToString("MM")), "00") & F3

        Dim H3 As String = ""
        '

        Dim cmd As New SqlCommand("Select count(*) + 1 as c From TBL_Company_Creation", cn)
        Dim r As SqlDataReader
        r = cmd.ExecuteReader
        While r.Read
            Dim COU As Integer = Math.Ceiling(Val(Val(r("c").ToString) / 99))
            Dim id As String = Val(r("c").ToString)
            If COU = 1 Then
                id = ABC_To_num(COU) & ABC_To_num(Company_Name_TXT.Text.Length) & Format(Val(id), "00") & CDate(Now.Date).ToString("dddd").Substring(0, 2).ToUpper
            Else
                Dim ii As Integer = 99 * (COU - 1)
                id = ABC_To_num(COU) & ABC_To_num(Company_Name_TXT.Text.Length) & Format(Val(id - ii), "00") & CDate(Now.Date).ToString("dddd").Substring(0, 2).ToUpper
            End If
            H3 = id
        End While
        r.Close()

        Company_serial_No = H1 & "-" & H2 & "-" & H3

        Return True
    End Function
    Private Function Save_Company()
        If Company_Name_TXT.Text = "" Then
            Msg_InputError(Company_Name_TXT, "Company Name")
            cn.Close()
            Company_Name_TXT.Focus()
            Exit Function
        End If
        If Email_TXT.Text.Trim = "" Then
            Msg_InputError(Email_TXT, "Email")
            cn.Close()
            Email_TXT.Focus()
            Exit Function
        End If
        If Path_TXT.Text.Length < 1 And (VC_Type_ = "Create" Or VC_Type_ = "Create_Close") Then

            Msg_InputError(Path_TXT, "Company data path")

            cn.Close()
            Path_TXT.Focus()
            Exit Function
        End If
        If Financial_Year_TXT.Text.Length < 1 Then
            Msg_InputError(Financial_Year_TXT, "Books beginning from")
            cn.Close()
            Financial_Year_TXT.Focus()
            Exit Function
        End If
        If Class_Select.Text.Length < 1 Then
            Msg(NOT_Type.Erro, "Input Error - Company class", "Company class is not allowed to be blank so please Company class and try again")
            cn.Close()
            Class_Select.Focus()
            Exit Function
        End If
        If Phone_TXT.Text.Length < 1 Then
            Msg_InputError(Phone_TXT, "Phone")
            cn.Close()
            Phone_TXT.Focus()
        End If
        If User_TXT.Text.Length < 1 Then
            Msg_InputError(User_TXT, "Username")
            cn.Close()
            User_TXT.Focus()
            Exit Function
        End If
        If Password_TXT.Text.Length < 1 Then
            Msg_InputError(Password_TXT, "Password")
            cn.Close()
            Password_TXT.Focus()
            Exit Function
        End If
        If Conform_Password_TXT.Text.Length < 1 Then
            Msg_InputError(Conform_Password_TXT, "Conform Password")
            cn.Close()
            Conform_Password_TXT.Focus()
            Exit Function
        End If
        If Password_TXT.Text <> Conform_Password_TXT.Text Then
            Msg_(NOT_Type.Erro, NOT_Location.Bottom_Right, "Not Match - Password or Conform Password", "Password is not match Please enter the correct password", Password_TXT)
            cn.Close()
            Password_TXT.Text = ""
            Conform_Password_TXT.Text = ""
            Password_TXT.Focus()
            Exit Function
        End If
        If Class_Select.Text = "Hospital" Then
            If ServerName_TXT.Text = Nothing Then
                Msg_InputError(ServerName_TXT, "Server Name")
                cn.Close()
                ServerName_TXT.Focus()
                Exit Function
            End If
            If ServerDatabase_TXT.Text = Nothing Then
                Msg_InputError(ServerDatabase_TXT, "Database")
                cn.Close()
                ServerDatabase_TXT.Focus()
                Exit Function
            End If

            If ServerUser_TXT.Text <> Nothing And ServerPassword_TXT.Text = Nothing Then
                Msg_InputError(ServerPassword_TXT, "Server Password")
                cn.Close()
                ServerPassword_TXT.Focus()
                Exit Function
            End If
        End If

        Class_ = Class_Select.Text

        cn = New SqlConnection
        If Online_MSSQL(cn) = True Then
            If Chack_Duplicate_User() = True Then
                Msg_Duplicat(User_TXT, "Username")

                cn.Close()
                User_TXT.Focus()
                Exit Function
            End If

            If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
                If Chack_license_validity() = True Then
                    If Limit_ < (Axist + 1) Then
                        Msg_Custom_YN(NOT_Location.Bottom_Right, Color.Red, My.Resources.notaccess_anumation_gif, Dialoag_Button.Ok, "License", "Limitation of license", $"Your license is authorized for {Limit_} Company,<nl>and you already have {Axist} Company Create,<nl>so you cannot Create a new company.")
                        Exit Function
                    End If
                End If

                Dim msg As String = Company_Name_TXT.Text
                If Email_Verification("Company Email Verification", Company_Name_TXT.Text, Email_TXT.Text, "Create Company", msg, 300) = DialogResult.Yes Then
                    Load_(True, "Please Wait" + vbNewLine & "Save Company Data")
                    Insurt_TD_back.RunWorkerAsync()
                Else
                    cn.Close()
                End If
            ElseIf VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close" Then
                Dim msg As String = Company_Name_str

                If Email_Verification("Company Email Verification", Company_Name_str, Email_TXT.Text, "Company Alteration", msg, 500) = DialogResult.Yes Then
                    Load_(True, "Please Wait" + vbNewLine & "Update Company Data")
                    Insurt_TD_back.RunWorkerAsync()
                Else
                    cn.Close()
                End If
            End If
        End If
    End Function

    Dim Limit_ As Integer = 0
    Dim Axist As Integer = 0
    Private Function Chack_license_validity() As Boolean
        Dim st As Boolean = False
        Axist = 0
        Dim cn As New SqlConnection
        Dim cmmd As SqlCommand
        Try
            If Online_MSSQL(cn) = True Then
                cmmd = New SqlCommand($"Select lc.Max_Company
From TBL_License lc 
Left Join TBL_Lic_link_Cmp ll on ll.License_No = lc.License
where lc.License = '{LC_ID_str}' and ll.[Status] = 'Approval'", cn)

                Dim r As SqlDataReader
                r = cmmd.ExecuteReader
                While r.Read
                    Limit_ = Val(r("Max_Company").ToString)
                    Axist += 1
                    st = True
                End While
                r.Close()
            End If
        Catch ex As Exception
            st = False
        End Try

        Return st
    End Function
    Dim Company_serial_No As String

    Private Function Insurt_Dat_Offline() As Boolean
        Dim cn As New SQLiteConnection
        'cn.ConnectionString = "Data Source=" & Connection_Path & "\" & Connection_Data & "\cmp.db;Version=3;New=False;Compress=True;"
        If open_MSSQL_Custom_path(Connection_Path & "\" & Connection_Data & "\cmp.db", cn) = True Then
            Dim ms As New MemoryStream
            Dim img As Image = PictureBox1.Image
            Dim img_Stamp As Image = PictureBox2.Image
            Dim img_Sig As Image = PictureBox3.Image

            Dim q1 As String = "INSERT INTO TBL_Company_Creation (CompanyName,Book_Frm,Address,CompanySerial,RegNo,GSTNo,GST_Type,PANCard,Email,Phone,PinCode,Country,State,District,Taluk,City,LocationID,Bank,Branch,AccountNo,IFCCode,UPI,UserName,Password,Class,[User],Approval,Branch_Division,Godown,Online,Date,Company_ID,DB_Version,Server_Name,Server_Database,Server_UserName,Server_Password,Audit_YN"

            Dim q2 As String = "(@CompanyName,@Book_Frm,@Address,@CompanySerial,@RegNo,@GSTNo,@GST_Type,@PANCard,@Email,@Phone,@PinCode,@Country,@State,@District,@Taluk,@City,@LocationID,@Bank,@Branch,@AccountNo,@IFCCode,@UPI,@UserName,@Password,@Class,@User,@Approval,@Branch_Division,@Godown,@Online,@Date,@Company_ID,@DB_Version,@Server_Name,@Server_Database,@Server_UserName,@Server_Password,@Audit_YN"

            If img IsNot Nothing Then
                q1 &= ",Photo"
                q2 &= ",@Photo"
            End If
            If img_Stamp IsNot Nothing Then
                q1 &= ",Stamp"
                q2 &= ",@Stamp"
            End If
            If img_Sig IsNot Nothing Then
                q1 &= ",Signatory"
                q2 &= ",@Signatory"
            End If
            q1 &= ")"
            q2 &= ")"


            Dim qr As String = q1 & " VALUES " & q2
            Try
                Dim cmd As New SQLiteCommand(qr, cn)
                With cmd.Parameters
                    .AddWithValue("@CompanyName", Company_Name_TXT.Text.Trim)
                    .AddWithValue("@Book_Frm", CDate(Financial_Year_TXT.Text))

                    .AddWithValue("@Address", Address_TXT.Text.Trim)
                    .AddWithValue("@CompanySerial", Company_serial_No.Trim)
                    .AddWithValue("@GST_Type", Txt1.Text.Trim)
                    .AddWithValue("@GSTNo", GST_TXT.Text.Trim)
                    .AddWithValue("@RegNo", "")
                    .AddWithValue("@PANCard", PAN_TXT.Text.Trim)
                    .AddWithValue("@Email", Email_TXT.Text.Trim)
                    .AddWithValue("@Phone", Phone_TXT.Text.Trim)
                    .AddWithValue("@PinCode", Pincode_TXT.Text.Trim)
                    .AddWithValue("@Country", "")
                    .AddWithValue("@State", State_TXT.Text.Trim)
                    .AddWithValue("@District", "")
                    .AddWithValue("@Taluk", "")
                    .AddWithValue("@City", City_TXT.Text.Trim)
                    .AddWithValue("@LocationID", "")
                    .AddWithValue("@Bank", Bank_TXT.Text.Trim)
                    .AddWithValue("@Branch", Bank_Branch_TXT.Text.Trim)
                    .AddWithValue("@AccountNo", Account_TXT.Text.Trim)
                    .AddWithValue("@IFCCode", IFSC_Code_TXT.Text.Trim)
                    .AddWithValue("@UPI", Upi_TXT.Text.Trim)
                    .AddWithValue("@UserName", User_TXT.Text.Trim)
                    .AddWithValue("@Password", Password_TXT.Text.Trim)
                    .AddWithValue("@Class", Class_)
                    .AddWithValue("@User", "".Trim)
                    .AddWithValue("@Approval", "Approval".Trim)
                    .AddWithValue("@Branch_Division", "")
                    .AddWithValue("@DB_Version", My.Application.Info.Version.ToString.Trim)

                    .AddWithValue("@Godown", "No")
                    .AddWithValue("Audit_YN", Yn2.Text)
                    .AddWithValue("@Online", "Offline")
                    .AddWithValue("@Date", CDate(Now.Date))
                    .AddWithValue("@Company_ID", VC_ID_)

                    If Class_Select.Text = "Hospital" Then
                        .AddWithValue("@Server_Name", ServerName_TXT.Text)
                        .AddWithValue("@Server_Database", ServerDatabase_TXT.Text)
                        .AddWithValue("@Server_UserName", ServerUser_TXT.Text)
                        .AddWithValue("@Server_Password", ServerPassword_TXT.Text)
                    Else
                        .AddWithValue("@Server_Name", "")
                        .AddWithValue("@Server_Database", "")
                        .AddWithValue("@Server_UserName", "")
                        .AddWithValue("@Server_Password", "")
                    End If

                    If img IsNot Nothing Then
                        .Add("@Photo", DbType.Binary).Value = Logo_
                        ms.Close()
                    End If

                    If img_Stamp IsNot Nothing Then
                        .Add("@Stamp", DbType.Binary).Value = Stamp_
                        ms.Close()
                    End If

                    If img_Sig IsNot Nothing Then
                        .Add("@Signatory", DbType.Binary).Value = Sig_
                        ms.Close()
                    End If
                    cmd.ExecuteNonQuery()
                    cn.Close()

                    'Save_Image
                    issuccess = True
                End With
            Catch ex As Exception
                issuccess = False
                Msg(NOT_Type.Erro, "Company Data Save Error", ex.Message)
                cn.Close()
            End Try
            cn.Close()
        End If
        Return issuccess
    End Function
    Private Function Update_Dat_Offline() As Boolean
        Dim ms As New MemoryStream
        Dim ms1 As New MemoryStream
        Dim ms2 As New MemoryStream
        Dim img As Image = PictureBox1.Image
        Dim img_Stamp As Image = PictureBox2.Image
        Dim img_Sig As Image = PictureBox3.Image

        Dim Q1 As String = "UPDATE TBL_Company_Creation SET CompanyName = @CompanyName,Book_Frm = @Book_Frm,Address = @Address,RegNo = @RegNo,GSTNo = @GSTNo,GST_Type = @GST_Type,PANCard = @PANCard,Email = @Email,Phone = @Phone,PinCode = @PinCode,Country = @Country,State = @State,District = @District,Taluk = @Taluk,City = @City,LocationID = @LocationID,Bank = @Bank,Branch = @Branch,AccountNo = @AccountNo,IFCCode = @IFCCode,UPI = @UPI,UserName = @UserName,Password = @Password,Class = @Class,[User] = @User,Branch_Division = @Branch_Division,Godown = @Godown,Audit_YN = @Audit_YN"


        If img IsNot Nothing Then
            Q1 &= ",Photo = @Photo"
        End If
        If img_Stamp IsNot Nothing Then
            Q1 &= ",Stamp = @Stamp"
        End If
        If img_Sig IsNot Nothing Then
            Q1 &= ",Signatory = @Signatory"
        End If

        qury = Q1 & " WHERE Company_ID = '" & VC_ID_ & "'"
        Try
            Dim cmd As New SQLiteCommand(qury, con)
            With cmd.Parameters
                .AddWithValue("@CompanyName", Company_Name_TXT.Text.Trim)
                .AddWithValue("@Book_Frm", CDate(Financial_Year_TXT.Text))
                .AddWithValue("@Address", Address_TXT.Text.Trim)
                .AddWithValue("@GST_Type", Txt1.Text.Trim)
                .AddWithValue("@GSTNo", GST_TXT.Text.Trim)
                .AddWithValue("@RegNo", "")
                .AddWithValue("@PANCard", PAN_TXT.Text.Trim)
                .AddWithValue("@Email", Email_TXT.Text.Trim)
                .AddWithValue("@Phone", Phone_TXT.Text.Trim)
                .AddWithValue("@PinCode", Pincode_TXT.Text.Trim)
                .AddWithValue("@Country", "")
                .AddWithValue("@State", State_TXT.Text.Trim)
                .AddWithValue("@District", "")
                .AddWithValue("@Taluk", "")
                .AddWithValue("@City", City_TXT.Text.Trim)
                .AddWithValue("@LocationID", "")
                .AddWithValue("@Bank", Bank_TXT.Text.Trim)
                .AddWithValue("@Branch", Bank_Branch_TXT.Text.Trim)
                .AddWithValue("@AccountNo", Account_TXT.Text.Trim)
                .AddWithValue("@IFCCode", IFSC_Code_TXT.Text.Trim)
                .AddWithValue("@UPI", Upi_TXT.Text.Trim)
                .AddWithValue("@UserName", User_TXT.Text.Trim)
                .AddWithValue("@Password", Password_TXT.Text.Trim)
                .AddWithValue("@Class", Class_)
                .AddWithValue("@User", "".Trim)
                .AddWithValue("@Branch_Division", "")
                .AddWithValue("@Godown", "No")
                .AddWithValue("Audit_YN", Yn2.Text)
                If img IsNot Nothing Then
                    .Add("@Photo", DbType.Binary).Value = Logo_
                    ms.Close()
                End If

                If img_Stamp IsNot Nothing Then
                    .Add("@Stamp", DbType.Binary).Value = Stamp_
                    ms.Close()
                End If

                If img_Sig IsNot Nothing Then
                    .Add("@Signatory", DbType.Binary).Value = Sig_
                    ms.Close()
                End If
                cmd.ExecuteNonQuery()
                issuccess = True
            End With
        Catch ex As Exception
            issuccess = False
            Msg(NOT_Type.Erro, "Company Data Update Error - 02", ex.Message)
        End Try
        Return issuccess
    End Function
    Private Function Insurt_Dat_Online() As Boolean
        Dim ms As New MemoryStream
        Dim img As Image = PictureBox1.Image
        Dim img_Stamp As Image = PictureBox2.Image
        Dim img_Sig As Image = PictureBox3.Image

        Dim q1 As String = "INSERT INTO TBL_Company_Creation (CompanyName,Book_Frm,Address,CompanySerial,RegNo,GST_Type,GSTNo,PANCard,Email,Phone,PinCode,Country,State,District,Taluk,City,LocationID,Bank,Branch,AccountNo,IFCCode,UPI,UserName,Password,Class,[User],Approval,Branch_Division,Godown,Audit_YN,Online,Date,Server_Name,Server_Database,Server_UserName,Server_Password"

        Dim q2 As String = "(@CompanyName,@Book_Frm,@Address,@CompanySerial,@RegNo,@GST_Type,@GSTNo,@PANCard,@Email,@Phone,@PinCode,@Country,@State,@District,@Taluk,@City,@LocationID,@Bank,@Branch,@AccountNo,@IFCCode,@UPI,@UserName,@Password,@Class,@User,@Approval,@Branch_Division,@Godown,@Audit_YN,@Online,@Date,@Server_Name,@Server_Database,@Server_UserName,@Server_Password"


        If img IsNot Nothing Then
            q1 &= ",Photo"
            q2 &= ",@Photo"
        End If
        If img_Stamp IsNot Nothing Then
            q1 &= ",Stamp"
            q2 &= ",@Stamp"
        End If
        If img_Sig IsNot Nothing Then
            q1 &= ",Signatory"
            q2 &= ",@Signatory"
        End If
        q1 &= ")"
        q2 &= ")"

        qury = q1 & " VALUES " & q2




        Try
            Dim cmd As New SqlCommand(qury, cn)
            With cmd.Parameters
                .AddWithValue("@CompanyName", Company_Name_TXT.Text.Trim)
                .AddWithValue("@Book_Frm", SqlDbType.DateTime).Value = CDate(Financial_Year_TXT.Text).ToString("MM-dd-yyyy")
                .AddWithValue("@Address", Address_TXT.Text.Trim)
                .AddWithValue("@CompanySerial", Company_serial_No)
                .AddWithValue("@GST_Type", Txt1.Text.Trim)
                .AddWithValue("@GSTNo", GST_TXT.Text.Trim)
                .AddWithValue("@RegNo", "")
                .AddWithValue("@PANCard", PAN_TXT.Text.Trim)
                .AddWithValue("@Email", Email_TXT.Text.Trim)
                .AddWithValue("@Phone", Phone_TXT.Text.Trim)
                .AddWithValue("@PinCode", Pincode_TXT.Text.Trim)
                .AddWithValue("@Country", "")
                .AddWithValue("@State", State_TXT.Text.Trim)
                .AddWithValue("@District", "")
                .AddWithValue("@Taluk", "")
                .AddWithValue("@City", City_TXT.Text.Trim)
                .AddWithValue("@LocationID", "")
                .AddWithValue("@Bank", Bank_TXT.Text.Trim)
                .AddWithValue("@Branch", Bank_Branch_TXT.Text.Trim)
                .AddWithValue("@AccountNo", Account_TXT.Text.Trim)
                .AddWithValue("@IFCCode", IFSC_Code_TXT.Text.Trim)
                .AddWithValue("@UPI", Upi_TXT.Text.Trim)
                .AddWithValue("@UserName", User_TXT.Text.Trim)
                .AddWithValue("@Password", Password_TXT.Text.Trim)
                .AddWithValue("@Class", Class_)
                .AddWithValue("@User", "".Trim)
                .AddWithValue("@Approval", "Approval".Trim)
                .AddWithValue("@Branch_Division", "")
                .AddWithValue("@Godown", "No")
                .AddWithValue("Audit_YN", Yn2.Text)
                .AddWithValue("@Online", "Offline")
                .AddWithValue("@Date", Now.Date)
                If Class_Select.Text = "Hospital" Then
                    .AddWithValue("@Server_Name", ServerName_TXT.Text)
                    .AddWithValue("@Server_Database", ServerDatabase_TXT.Text)
                    .AddWithValue("@Server_UserName", ServerUser_TXT.Text)
                    .AddWithValue("@Server_Password", ServerPassword_TXT.Text)
                Else
                    .AddWithValue("@Server_Name", "")
                    .AddWithValue("@Server_Database", "")
                    .AddWithValue("@Server_UserName", "")
                    .AddWithValue("@Server_Password", "")
                End If

                If img IsNot Nothing Then
                    .AddWithValue("@Photo", SqlDbType.Image).Value = Logo_
                    ms.Close()
                End If

                If img_Stamp IsNot Nothing Then
                    .AddWithValue("@Stamp", SqlDbType.Image).Value = Stamp_
                    ms.Close()
                End If

                If img_Sig IsNot Nothing Then
                    .AddWithValue("@Signatory", SqlDbType.Image).Value = Sig_
                    ms.Close()
                End If
                cmd.ExecuteNonQuery()
                issuccess = True
            End With
            '/////////////////////////////////////////////
            qury = $"Select ID From TBL_Company_Creation Where CompanySerial = '{Company_serial_No}'"
            cmd = New SqlCommand(qury, cn)
            Dim r As SqlDataReader
            r = cmd.ExecuteReader
            While r.Read
                VC_ID_ = r("ID")
            End While
            r.Close()



            Dim qry As String = "INSERT INTO TBL_Lic_link_Cmp (Company_Serial,License_No,PC_Name,Install,Status) VALUES (@Company_Serial,@License_No,@PC_Name,@Install,@Status)"
            cmd = New SqlCommand(qry, cn)
            With cmd.Parameters
                .AddWithValue("@Company_Serial", Company_serial_No)
                .AddWithValue("@License_No", LC_ID_str)
                .AddWithValue("@PC_Name", "Admin")
                .AddWithValue("@Install", Now.Date)
                .AddWithValue("@Status", "Approval")
                cmd.ExecuteNonQuery()
            End With
        Catch ex As Exception
            issuccess = False
            Msg(NOT_Type.Erro, "Company Serial number error", ex.Message)
        End Try
        Return issuccess
    End Function
    Private Function Update_Dat_Online() As Boolean
        Dim ms As New MemoryStream
        Dim img As Image = PictureBox1.Image
        Dim img_Stamp As Image = PictureBox2.Image
        Dim img_Sig As Image = PictureBox3.Image

        Dim Q1 As String = "UPDATE TBL_Company_Creation SET CompanyName = @CompanyName,Book_Frm  = @Book_Frm,Address = @Address,RegNo = @RegNo,GSTNo = @GSTNo,GST_Type = @GST_Type,PANCard = @PANCard,Email = @Email,Phone = @Phone,PinCode = @PinCode,Country = @Country,State = @State,District = @District,Taluk = @Taluk,City = @City,LocationID = @LocationID,Bank = @Bank,Branch = @Branch,AccountNo = @AccountNo,IFCCode = @IFCCode,UPI = @UPI,UserName = @UserName,Password = @Password,Class = @Class,[User] = @uSER,Branch_Division = @Branch_Division,Godown = @Godown,Audit_YN = @Audit_YN"

        If img IsNot Nothing Then
            Q1 &= ",Photo = @Photo"
        End If
        If img_Stamp IsNot Nothing Then
            Q1 &= ",Stamp = @Stamp"
        End If
        If img_Sig IsNot Nothing Then
            Q1 &= ",Signatory = @Signatory"
        End If

        qury = Q1 & " WHERE ID Like N'" & VC_ID_ & "'"



        Try
            Dim cmd As New SqlCommand(qury, cn)
            With cmd.Parameters
                .AddWithValue("@CompanyName", Company_Name_TXT.Text.Trim)
                .AddWithValue("@Book_Frm", SqlDbType.DateTime).Value = CDate(Financial_Year_TXT.Text).ToString("MM-dd-yyyy")
                .AddWithValue("@Address", Address_TXT.Text.Trim)
                .AddWithValue("@GST_Type", Txt1.Text.Trim)
                .AddWithValue("@GSTNo", GST_TXT.Text.Trim)
                .AddWithValue("@RegNo", "")
                .AddWithValue("@PANCard", PAN_TXT.Text.Trim)
                .AddWithValue("@Email", Email_TXT.Text.Trim)
                .AddWithValue("@Phone", Phone_TXT.Text.Trim)
                .AddWithValue("@PinCode", Pincode_TXT.Text.Trim)
                .AddWithValue("@Country", "")
                .AddWithValue("@State", State_TXT.Text.Trim)
                .AddWithValue("@District", "")
                .AddWithValue("@Taluk", "")
                .AddWithValue("@City", City_TXT.Text.Trim)
                .AddWithValue("@LocationID", "")
                .AddWithValue("@Bank", Bank_TXT.Text.Trim)
                .AddWithValue("@Branch", Bank_Branch_TXT.Text.Trim)
                .AddWithValue("@AccountNo", Account_TXT.Text.Trim)
                .AddWithValue("@IFCCode", IFSC_Code_TXT.Text.Trim)
                .AddWithValue("@UPI", Upi_TXT.Text.Trim)
                .AddWithValue("@UserName", User_TXT.Text.Trim)
                .AddWithValue("@Password", Password_TXT.Text.Trim)
                .AddWithValue("@Class", Class_)
                .AddWithValue("@User", "".Trim)
                .AddWithValue("@Branch_Division", "")
                .AddWithValue("@Godown", "No")
                .AddWithValue("Audit_YN", Yn2.Text)
                If img IsNot Nothing Then
                    .AddWithValue("@Photo", SqlDbType.Image).Value = Logo_
                    ms.Close()
                End If

                If img_Stamp IsNot Nothing Then
                    .AddWithValue("@Stamp", SqlDbType.Image).Value = Stamp_
                    ms.Close()
                End If

                If img_Sig IsNot Nothing Then
                    .AddWithValue("@Signatory", SqlDbType.Image).Value = Sig_
                    ms.Close()
                End If
                cmd.ExecuteNonQuery()
                issuccess = True
            End With
        Catch ex As Exception
            issuccess = False
            Msg(NOT_Type.Erro, "Company Data Save Error - 01", ex.Message)
        End Try
        Return issuccess
    End Function
    Private Sub Insurt_TD_back_DoWork(sender As Object, e As DoWorkEventArgs) Handles Insurt_TD_back.DoWork
        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            If Company_Serial_create() = True Then
                If Insurt_Dat_Online() = True Then
                    issuccess = True
                Else
                    issuccess = False
                End If
            End If
        ElseIf VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close" Then
            If Update_Dat_Online() = True Then
                If open_MSSQL(Database_File.cmp) = True Then
                    If Update_Dat_Offline() = True Then
                        'Msg_Custom_YN(NOT_Location.Bottom_Right, Color.Green, My.Resources.Success_animation_icn, Dialoag_Button.Ok, "Successful", Company_Name_TXT.Text, "Company updated successfully")
                        issuccess = True
                    End If
                End If
            Else
                issuccess = False
            End If
        End If
    End Sub

    Private Sub Company_Name_TXT_TextChanged(sender As Object, e As EventArgs) Handles Company_Name_TXT.TextChanged
        Null_Notallow(sender, "Company Name")
    End Sub

    Private Sub Company_Creation_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If Msg_Exit_YN("Company " & VC_Type_) = DialogResult.Yes Then
                Me.Dispose()
            End If
        End If
    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Company_Creation_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        Button_Clear()
        Button_Manage()
        Path_TXT.Focus()

        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.TYP_TXT.Text = VC_Type_

        BG_frm.HADE_TXT.Text = "Company Information"
        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text

    End Sub

    Private Sub Company_Creation_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        Add_Hander_Remove_Handel(False)
        BG_frm.BG_Path_TXT.Text = Path_End
        Frm_foCus()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Dim OpenFile As New OpenFileDialog()
        Try
            With OpenFile
                .FileName = ""
                .Title = "Stamp:"
                .Filter = "Company Stamp : (*.png)|*.png"
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    Stamp_ = Byte_(.FileName)
                    Me.PictureBox2.Image = System.Drawing.Image.FromFile(.FileName)
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Error...")
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Dim OpenFile As New OpenFileDialog()
        Try
            With OpenFile
                .FileName = ""
                .Title = "Signatory:"
                .Filter = "Authorised Signatory : (*.png)|*.png"
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    Sig_ = Byte_(.FileName)
                    Me.PictureBox3.Image = System.Drawing.Image.FromFile(.FileName)
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Error...")
        End Try
    End Sub

    Private Sub Path_TXT_TextChanged(sender As Object, e As EventArgs) Handles Path_TXT.TextChanged

    End Sub

    Private Sub Path_TXT_LostFocus(sender As Object, e As EventArgs) Handles Path_TXT.LostFocus
        If Directory.Exists(Path_TXT.Text) Then
        Else
            Path_TXT.Text = Application.StartupPath & "\Data"
            Path_TXT.Focus()
        End If
    End Sub

    Private Sub Financial_Year_TXT_TextChanged(sender As Object, e As EventArgs) Handles Financial_Year_TXT.TextChanged

    End Sub
    Private Function Null_Notallow(ob As Object, error_name As String)
        If ob.Text = "" Then
            NOT_("Input Error - " & error_name, NOT_Type.Erro)
        Else
            NOT_Clear()
        End If
    End Function
    Private Function Email_Formate(ob As Object)
        If Formate_Email(ob.Text) = True Then
            NOT_("Email Formats is Ok", NOT_Type.Success)
        Else
            NOT_("Email Formats is not Ok", NOT_Type.Erro)
        End If
    End Function
    Private Function GST_Formate(ob As Object)
        If Formate_GST(ob.Text) = True Then
            NOT_("GST Formats is Ok", NOT_Type.Success)
        Else
            NOT_("GST Formats is not Ok", NOT_Type.Erro)
        End If
    End Function
    Private Function PAN_Formate(ob As Object)
        If Formate_PAN(ob.Text) = True Then
            NOT_("PAN Formats is Ok", NOT_Type.Success)
        Else
            NOT_("PAN Formats is not Ok", NOT_Type.Erro)
        End If
    End Function
    Private Function IFSC_Formate(ob As Object)
        If Formate_IFSC(ob.Text) = True Then
            NOT_("IFSC Formats is Ok", NOT_Type.Success)
        Else
            NOT_("IFSC Formats is not Ok", NOT_Type.Erro)
        End If
    End Function

    Private Sub Financial_Year_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Financial_Year_TXT.KeyPress

    End Sub

    Private Sub Financial_Year_TXT_Enter(sender As Object, e As EventArgs) Handles Financial_Year_TXT.Enter

    End Sub

    Private Sub Company_Name_TXT_Enter(sender As Object, e As EventArgs) Handles Company_Name_TXT.Enter
        Null_Notallow(sender, "Company Name")
    End Sub

    Private Sub Company_Name_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Company_Name_TXT.KeyPress
        Null_Notallow(sender, "Company Name")
    End Sub

    Private Sub Company_Name_TXT_LostFocus(sender As Object, e As EventArgs) Handles Company_Name_TXT.LostFocus
        Null_Notallow(sender, "Company Name")
    End Sub

    Private Sub Email_TXT_TextChanged(sender As Object, e As EventArgs) Handles Email_TXT.TextChanged
        Null_Notallow(sender, "Email Address")
        Email_Formate(sender)
    End Sub

    Private Sub Email_TXT_Enter(sender As Object, e As EventArgs) Handles Email_TXT.Enter
        Null_Notallow(sender, "Email Address")
        Email_Formate(sender)
    End Sub

    Private Sub Email_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Email_TXT.KeyPress
        Null_Notallow(sender, "Email Address")
        Email_Formate(sender)
    End Sub

    Private Sub Email_TXT_LostFocus(sender As Object, e As EventArgs) Handles Email_TXT.LostFocus
        Null_Notallow(sender, "Email Address")
        Email_Formate(sender)
    End Sub

    Private Sub Phone_TXT_TextChanged(sender As Object, e As EventArgs) Handles Phone_TXT.TextChanged
        Null_Notallow(sender, "Phone")
    End Sub

    Private Sub Phone_TXT_Enter(sender As Object, e As EventArgs) Handles Phone_TXT.Enter
        Null_Notallow(sender, "Phone")
    End Sub

    Private Sub Phone_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Phone_TXT.KeyPress
        Null_Notallow(sender, "Phone")
    End Sub

    Private Sub Phone_TXT_LostFocus(sender As Object, e As EventArgs) Handles Phone_TXT.LostFocus
        Null_Notallow(sender, "Phone")
    End Sub

    Private Sub User_TXT_TextChanged(sender As Object, e As EventArgs) Handles User_TXT.TextChanged
        Null_Notallow(sender, "User Name")
    End Sub

    Private Sub User_TXT_Enter(sender As Object, e As EventArgs) Handles User_TXT.Enter
        Null_Notallow(sender, "User Name")
    End Sub

    Private Sub User_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles User_TXT.KeyPress
        Null_Notallow(sender, "User Name")
    End Sub

    Private Sub User_TXT_LostFocus(sender As Object, e As EventArgs) Handles User_TXT.LostFocus
        Null_Notallow(sender, "User Name")
    End Sub


    Private Sub Password_TXT_Enter(sender As Object, e As EventArgs) Handles Password_TXT.Enter
        Null_Notallow(sender, "Password")
    End Sub

    Private Sub Password_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Password_TXT.KeyPress
        Null_Notallow(sender, "Password")
    End Sub

    Private Sub Password_TXT_LostFocus(sender As Object, e As EventArgs) Handles Password_TXT.LostFocus
        Null_Notallow(sender, "Password")
    End Sub

    Private Sub Conform_Password_TXT_TextChanged(sender As Object, e As EventArgs) Handles Conform_Password_TXT.TextChanged

    End Sub

    Private Sub Conform_Password_TXT_Enter(sender As Object, e As EventArgs) Handles Conform_Password_TXT.Enter
        Null_Notallow(sender, "Conferm Password")
    End Sub

    Private Sub Conform_Password_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Conform_Password_TXT.KeyPress
        Null_Notallow(sender, "Conferm Password")

    End Sub

    Private Sub Conform_Password_TXT_LostFocus(sender As Object, e As EventArgs) Handles Conform_Password_TXT.LostFocus
        Null_Notallow(sender, "Conferm Password")
    End Sub

    Private Sub GST_TXT_TextChanged(sender As Object, e As EventArgs) Handles GST_TXT.TextChanged
        GST_Formate(sender)
    End Sub

    Private Sub GST_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles GST_TXT.KeyPress
        GST_Formate(sender)

    End Sub

    Private Sub GST_TXT_LostFocus(sender As Object, e As EventArgs) Handles GST_TXT.LostFocus
        GST_Formate(sender)
    End Sub

    Private Sub GST_TXT_Enter(sender As Object, e As EventArgs) Handles GST_TXT.Enter
        GST_Formate(sender)
    End Sub

    Private Sub PAN_TXT_TextChanged(sender As Object, e As EventArgs) Handles PAN_TXT.TextChanged
        PAN_Formate(sender)
    End Sub

    Private Sub PAN_TXT_Enter(sender As Object, e As EventArgs) Handles PAN_TXT.Enter
        PAN_Formate(sender)
    End Sub

    Private Sub PAN_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles PAN_TXT.KeyPress
        PAN_Formate(sender)
    End Sub

    Private Sub PAN_TXT_LostFocus(sender As Object, e As EventArgs) Handles PAN_TXT.LostFocus
        PAN_Formate(sender)
    End Sub

    Private Sub IFSC_Code_TXT_TextChanged(sender As Object, e As EventArgs) Handles IFSC_Code_TXT.TextChanged
        IFSC_Formate(sender)
    End Sub

    Private Sub IFSC_Code_TXT_Enter(sender As Object, e As EventArgs) Handles IFSC_Code_TXT.Enter
        IFSC_Formate(sender)
    End Sub

    Private Sub IFSC_Code_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles IFSC_Code_TXT.KeyPress
        IFSC_Formate(sender)
    End Sub

    Private Sub IFSC_Code_TXT_LostFocus(sender As Object, e As EventArgs) Handles IFSC_Code_TXT.LostFocus
        IFSC_Formate(sender)
    End Sub

    Private Sub State_TXT_TextChanged(sender As Object, e As EventArgs) Handles State_TXT.TextChanged
    End Sub
    Private Sub State_TXT_Enter(sender As Object, e As EventArgs) Handles State_TXT.Enter

    End Sub

    Private Sub State_TXT_LostFocus(sender As Object, e As EventArgs) Handles State_TXT.LostFocus
    End Sub

    Private Sub State_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles State_TXT.KeyDown
        If e.KeyCode = Keys.Enter Then
            State_TXT.Text = State_list.List_Grid.CurrentRow.Cells(0).Value
        End If
    End Sub

    Private Sub Insurt_TD_back_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles Insurt_TD_back.RunWorkerCompleted
        Load_(False, "")
        If issuccess = True Then
            If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
                Connection_Path = Path_TXT.Text
                Connection_Data = VC_ID_ & ".dt"
                Company_Name_str = Company_Name_TXT.Text
                Company_ID_str = VC_ID_
                Company_ID_str = VC_ID_
                My.Settings.Save()
                Install_Local_Data_Base()
            Else
                Me.Dispose()
                Login_Frm.vc_Type_ = "Login Company"
                BG_frm.TYP_TXT.Text = Login_Frm.vc_Type_
                NOT_("Company Data is Updated Successfully", NOT_Type.Success)
            End If
            'Me.Dispose()
        Else
            Company_Name_TXT.Focus()
        End If
    End Sub
    Private Function Display_Fill_All()

    End Function
    Private Function Chack_Duplicate_User() As Boolean
        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            Return False
        End If

        Dim cmmd As New SqlCommand
        cmmd = New SqlCommand("Select * From TBL_Login where CompanySerial Like N'" & Company_ID_str & "' and UserName Like N'" & User_TXT.Text & "'", cn)
        Dim r As SqlDataReader
        r = cmmd.ExecuteReader
        While r.Read
            Return True
        End While
        r.Close()
        Return False
    End Function

    Dim Name_ As String
    Dim Address_ As String
    Dim Book_Frm_ As String
    Dim GSTtype_ As String
    Dim GSTNo_ As String
    Dim RegNo_ As String
    Dim PANCard_ As String
    Dim Email_ As String
    Dim Phone_ As String
    Dim State_ As String
    Dim City_ As String
    Dim Pincode_ As String
    Dim Bank_ As String
    Dim Branch_ As String
    Dim AccountNo_ As String
    Dim IFCCode_ As String
    Dim UPI_ As String
    Dim UserName_ As String
    Dim Password_ As String
    Dim Class_ As String
    Dim Audit_YN As String
    Dim Branch_Division_ As String
    Dim Godown_ As String
    Public Logo_() As Byte
    Public Stamp_() As Byte
    Public Sig_() As Byte
    Private Sub Load_Details_back_DoWork(sender As Object, e As DoWorkEventArgs) Handles Load_Details.DoWork
        qury = "Select * From TBL_Company_Creation where Company_ID = '" & VC_ID_ & "' and Approval = 'Approval'"
        Dim cmd As New SQLiteCommand(qury, cnc)
        Dim r As SQLiteDataReader
        r = cmd.ExecuteReader
        'My.Computer.Clipboard.SetText(qury)
        While r.Read
            Name_ = r("CompanyName").ToString
            Book_Frm_ = CDate(r("Book_Frm").ToString)
            Address_ = r("Address").ToString
            GSTtype_ = r("GST_Type").ToString
            GSTNo_ = r("GSTNo").ToString
            RegNo_ = r("RegNo").ToString
            PANCard_ = r("PANCard").ToString
            Email_ = r("Email").ToString
            Phone_ = r("Phone").ToString
            State_ = r("State").ToString
            City_ = r("City").ToString
            Pincode_ = r("Pincode").ToString
            Bank_ = r("Bank").ToString
            Branch_ = r("Branch").ToString
            AccountNo_ = r("AccountNo").ToString
            IFCCode_ = r("IFCCode").ToString
            UPI_ = r("UPI").ToString.ToString
            UserName_ = r("UserName").ToString
            Password_ = r("Password").ToString
            Class_ = r("Class").ToString
            Audit_YN = r("Audit_YN").ToString
            ServerName_TXT.Text = r("Server_Name").ToString
            ServerDatabase_TXT.Text = r("Server_Database").ToString
            ServerUser_TXT.Text = r("Server_UserName").ToString
            ServerPassword_TXT.Text = r("Server_Password").ToString

            Try
                Logo_ = DirectCast(r("Photo"), Byte())
            Catch ex As Exception

            End Try
            Try
                Stamp_ = DirectCast(r("Stamp"), Byte())
            Catch ex As Exception

            End Try
            Try
                Sig_ = DirectCast(r("Signatory"), Byte())
            Catch ex As Exception

            End Try
        End While
        r.Close()
        issuccess = True
    End Sub

    Private Sub Load_Details_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles Load_Details.RunWorkerCompleted
        If issuccess = True Then
            Load_(False, "")
            Company_Name_TXT.Text = Name_
            Financial_Year_TXT.Text = Book_Frm_
            Address_TXT.Text = Address_
            Txt1.Text = GSTtype_
            GST_TXT.Text = GSTNo_
            PAN_TXT.Text = PANCard_
            Email_TXT.Text = Email_
            Phone_TXT.Text = Phone_
            State_TXT.Text = State_
            City_TXT.Text = City_
            Pincode_TXT.Text = Pincode_
            Bank_TXT.Text = Bank_
            Bank_Branch_TXT.Text = Branch_
            Account_TXT.Text = AccountNo_
            IFSC_Code_TXT.Text = IFCCode_
            Upi_TXT.Text = UPI_
            User_TXT.Text = UserName_
            Password_TXT.Text = Password_
            Class_Select.Text = Class_
            Yn2.Text = Audit_YN


            Dim ms As New MemoryStream
            Try
                ms = New MemoryStream(Logo_)
                PictureBox1.Image = Image.FromStream(ms)
            Catch ex As Exception

            End Try

            Try
                ms = New MemoryStream(Stamp_)
                PictureBox2.Image = Image.FromStream(ms)
            Catch ex As Exception

            End Try

            Try
                ms = New MemoryStream(Sig_)
                PictureBox3.Image = Image.FromStream(ms)
            Catch ex As Exception

            End Try
            ms.Close()


            Company_Name_TXT.Focus()
        End If
    End Sub
    Private Function Load_(st As Boolean, TXT As String)
        Load_Panel.Location = New Point(Me.ClientSize.Width / 2 - Load_Panel.Size.Width / 2, Me.ClientSize.Height / 2 - Load_Panel.Size.Height / 2)

        If st = True Then
            Panel35.Hide()
            Load_Panel.Show()
        Else
            Panel35.Show()
            Load_Panel.Hide()
        End If
        Label54.Text = TXT
    End Function

    Private Function Install_Local_Data_Base()
        Directory.CreateDirectory(Path_TXT.Text & "\" & VC_ID_ & ".dt")
        'Dim st As String = "CREATE DATABASE [{1}\{2}.mdf] ON PRIMARY (NAME={2}, FILENAME = '{1}\{2}.mdf') LOG ON (NAME={2}_log, FILENAME = '{1}\{2}_logs.ldf')"

        'Create_cmp(st, VC_ID_, Path_TXT.Text)
        'Create_cre(st, VC_ID_, Path_TXT.Text)
        'Create_lnk(st, VC_ID_, Path_TXT.Text)
        'Create_rec(st, VC_ID_, Path_TXT.Text)

        Create_local_db_frm.st = ""
        Create_local_db_frm.VC_ID_ = VC_ID_
        Create_local_db_frm.Path_TXT = Path_TXT.Text & "\" & VC_ID_ & ".dt"

        Cell("Create Database", Class_Select.Text)

        AddHandler Create_local_db_frm.BackgroundWorker1.RunWorkerCompleted, AddressOf Databaseinstall_RunWorkerCompleted
    End Function
    Private Sub Databaseinstall_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs)
        If Insurt_Dat_Offline() = True Then
            EMAIL_sEnd(Email_TXT.Text, "Company Details", Email_HTML, True)
            Msg_yn_frm.head_lb.Font = New Font("Arial Black", 11.25!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
            Msg_Custom_YN(NOT_Location.Bottom_Right, Color.Green, My.Resources.tikit_animation_icn, Dialoag_Button.Ok, "Successful create a company", Company_serial_No, "The company has been successfully built,<nl>The serial number of the company<nl>has been sent to your email,<nl> the company will be identified from<nl>the serial number of the company.")

            Me.Dispose()
            Login_Frm.Dispose()
            Cell("Login", "", "Login Company")
            'Cell("Device Activation")
            'Device_Activation_frm.Serial_TXT.Text = Company_serial_No
            'Device_Activation_frm.Unlock_Serial = Company_serial_No
        End If
        Create_local_db_frm.Dispose()
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Txt1_TextChanged(sender As Object, e As EventArgs) Handles Class_Select.TextChanged
        If Class_Select.Text = "Hospital" Then
            Panel3.Visible = True
            Label49.Text = "Hospital Database Details"
        Else
            Panel3.Visible = False
        End If
    End Sub
    Dim State_list As List_frm
    Dim Class_list As List_frm
    Dim gst_type_contry_List As List_frm
    Dim City_list As List_frm
    Private Function List_set()
        State_list = New List_frm
        List_Setup("List of State", Select_List.Right_Dock, Select_List_Format.Singel, State_TXT, State_list, State_Bindingsource, 320)

        Class_list = New List_frm
        List_Setup("List of Class", Select_List.Botom, Select_List_Format.Singel, Class_Select, Class_list, Class_Source, 300)

        gst_type_contry_List = New List_frm
        List_Setup("List GST Type", Select_List.Right, Select_List_Format.Defolt, Txt1, gst_type_contry_List, GST_Type__BS, 150)
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

    End Function
    Private Function Fill_Source()
        Dim cn As New SQLiteConnection()
        If open_MSSQL_Cstm(Database_File.cfgs, cn) Then
            Dim dt As New DataTable
            Dim dr As DataRow

            dt.Clear()
            dt.Columns.Add("Name")
            dt.Columns.Add("ID")

            dt.Rows.Add("Not Applicable")
            Dim cm As New SQLiteCommand("Select * From TBL_State", cn)
            Dim r As SQLiteDataReader
            r = cm.ExecuteReader
            While r.Read
                dr = dt.NewRow
                dr("ID") = r("ID")
                dr("Name") = r("Name")
                dt.Rows.Add(dr)
            End While
            State_Bindingsource.DataSource = dt
        End If
        cn.Close()


        Dim dt1 As New DataTable
        dt1.Columns.Add("Name")
        dt1.Rows.Add("Management")
        dt1.Rows.Add("Hospital")

        Class_Source.DataSource = dt1

        Dim dt_gst As New DataTable
        dt_gst.Columns.Add("Head")
        dt_gst.Columns.Add("Under")
        dt_gst.Columns.Add("ID")

        dt_gst.Rows.Add("Composition")
        dt_gst.Rows.Add("Regular")
        dt_gst.Rows.Add("Unregistered")

        GST_Type__BS.DataSource = dt_gst



    End Function

    Private Sub Company_Creation_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
        Me.Focus()
    End Sub

    Private Sub Save_TXT_TextChanged(sender As Object, e As EventArgs) Handles Save_TXT.TextChanged

    End Sub

    Private Sub Save_TXT_Enter(sender As Object, e As EventArgs) Handles Save_TXT.Enter
        If Msg_Save_YN(sender, "Company") = DialogResult.Yes Then
            Save_Company()
        Else
            SendKeys.Send("{BACKSPACE}")
        End If
    End Sub
    Private Function Email_HTML()
        Dim st As String = "<!DOCTYPE HTML PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional //EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
<html xmlns=""http://www.w3.org/1999/xhtml"" xmlns:v=""urn:schemas-microsoft-com:vml"" xmlns:o=""urn:schemas-microsoft-com:office:office"">

<head>
  <!--[if gte mso 9]>
<xml>
  <o:OfficeDocumentSettings>
    <o:AllowPNG/>
    <o:PixelsPerInch>96</o:PixelsPerInch>
  </o:OfficeDocumentSettings>
</xml>
<![endif]-->
  <meta http-equiv=""Content-Type"" content=""text/html; charset=UTF-8"">
  <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
  <meta name=""x-apple-disable-message-reformatting"">
  <!--[if !mso]><!-->
  <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
  <!--<![endif]-->
  <title></title>

  <style type=""text/css"">
    @media only screen and (min-width: 620px) {
      .u-row {
        width: 600px !important;
      }
      .u-row .u-col {
        vertical-align: top;
      }
      .u-row .u-col-100 {
        width: 600px !important;
      }
    }
    
    @media (max-width: 620px) {
      .u-row-container {
        max-width: 100% !important;
        padding-left: 0px !important;
        padding-right: 0px !important;
      }
      .u-row .u-col {
        min-width: 320px !important;
        max-width: 100% !important;
        display: block !important;
      }
      .u-row {
        width: 100% !important;
      }
      .u-col {
        width: 100% !important;
      }
      .u-col>div {
        margin: 0 auto;
      }
    }
    
    body {
      margin: 0;
      padding: 0;
    }
    
    table,
    tr,
    td {
      vertical-align: top;
      border-collapse: collapse;
    }
    
    p {
      margin: 0;
    }
    
    .ie-container table,
    .mso-container table {
      table-layout: fixed;
    }
    
    * {
      line-height: inherit;
    }
    
    a[x-apple-data-detectors='true'] {
      color: inherit !important;
      text-decoration: none !important;
    }
    
    table,
    td {
      color: #000000;
    }
    
    @media (max-width: 480px) {
      #u_content_image_1 .v-container-padding-padding {
        padding: 14px !important;
      }
      #u_content_image_1 .v-src-width {
        width: auto !important;
      }
      #u_content_image_1 .v-src-max-width {
        max-width: 100% !important;
      }
    }
  </style>



  <!--[if !mso]><!-->
  <link href=""https://fonts.googleapis.com/css?family=Cabin:400,700"" rel=""stylesheet"" type=""text/css"">
  <!--<![endif]-->

</head>

<body class=""clean-body u_body"" style=""margin: 0;padding: 0;-webkit-text-size-adjust: 100%;background-color: #f9f9f9;color: #000000"">
  <!--[if IE]><div class=""ie-container""><![endif]-->
  <!--[if mso]><div class=""mso-container""><![endif]-->
  <table style=""border-collapse: collapse;table-layout: fixed;border-spacing: 0;mso-table-lspace: 0pt;mso-table-rspace: 0pt;vertical-align: top;min-width: 320px;Margin: 0 auto;background-color: #f9f9f9;width:100%"" cellpadding=""0"" cellspacing=""0"">
    <tbody>
      <tr style=""vertical-align: top"">
        <td style=""word-break: break-word;border-collapse: collapse !important;vertical-align: top"">
          <!--[if (mso)|(IE)]><table width=""100%"" cellpadding=""0"" cellspacing=""0"" border=""0""><tr><td align=""center"" style=""background-color: #f9f9f9;""><![endif]-->



          <div class=""u-row-container"" style=""padding: 0px;background-color: transparent"">
            <div class=""u-row"" style=""margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #ffffff;"">
              <div style=""border-collapse: collapse;display: table;width: 100%;height: 100%;background-color: transparent;"">
                <!--[if (mso)|(IE)]><table width=""100%"" cellpadding=""0"" cellspacing=""0"" border=""0""><tr><td style=""padding: 0px;background-color: transparent;"" align=""center""><table cellpadding=""0"" cellspacing=""0"" border=""0"" style=""width:600px;""><tr style=""background-color: #ffffff;""><![endif]-->

                <!--[if (mso)|(IE)]><td align=""center"" width=""600"" style=""width: 600px;padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;"" valign=""top""><![endif]-->
                <div class=""u-col u-col-100"" style=""max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;"">
                  <div style=""height: 100%;width: 100% !important;"">
                    <!--[if (!mso)&(!IE)]><!-->
                    <div style=""box-sizing: border-box; height: 100%; padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;"">
                      <!--<![endif]-->

                      <table id=""u_content_image_1"" style=""font-family:'Cabin',sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">
                        <tbody>
                          <tr>
                            <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:20px;font-family:'Cabin',sans-serif;"" align=""left"">

                              <table width=""100%"" cellpadding=""0"" cellspacing=""0"" border=""0"">
                                <tr>
                                  <td style=""padding-right: 0px;padding-left: 0px;"" align=""center"">

                                    <img align=""center"" border=""0"" src=""https://onedrive.live.com/embed?resid=9961498AAC9FBC66%21225&authkey=%21ADCEY40c5sUOJ10&width=1479&height=328"" alt=""Image"" title=""Image"" style=""outline: none;text-decoration: none;-ms-interpolation-mode: bicubic;clear: both;display: inline-block !important;border: none;height: auto;float: none;width: 85%;max-width: 476px;""
                                      width=""476"" class=""v-src-width v-src-max-width"" />

                                  </td>
                                </tr>
                              </table>

                            </td>
                          </tr>
                        </tbody>
                      </table>

                      <table style=""font-family:'Cabin',sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">
                        <tbody>
                          <tr>
                            <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:13px;font-family:'Cabin',sans-serif;"" align=""left"">

                              <table height=""0px"" align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" width=""71%"" style=""border-collapse: collapse;table-layout: fixed;border-spacing: 0;mso-table-lspace: 0pt;mso-table-rspace: 0pt;vertical-align: top;border-top: 1px dashed #000000;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%"">
                                <tbody>
                                  <tr style=""vertical-align: top"">
                                    <td style=""word-break: break-word;border-collapse: collapse !important;vertical-align: top;font-size: 0px;line-height: 0px;mso-line-height-rule: exactly;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%"">
                                      <span>&#160;</span>
                                    </td>
                                  </tr>
                                </tbody>
                              </table>

                            </td>
                          </tr>
                        </tbody>
                      </table>

                      <!--[if (!mso)&(!IE)]><!-->
                    </div>
                    <!--<![endif]-->
                  </div>
                </div>
                <!--[if (mso)|(IE)]></td><![endif]-->
                <!--[if (mso)|(IE)]></tr></table></td></tr></table><![endif]-->
              </div>
            </div>
          </div>





          <div class=""u-row-container"" style=""padding: 0px;background-color: transparent"">
            <div class=""u-row"" style=""margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #ef7f1a;"">
              <div style=""border-collapse: collapse;display: table;width: 100%;height: 100%;background-color: transparent;"">
                <!--[if (mso)|(IE)]><table width=""100%"" cellpadding=""0"" cellspacing=""0"" border=""0""><tr><td style=""padding: 0px;background-color: transparent;"" align=""center""><table cellpadding=""0"" cellspacing=""0"" border=""0"" style=""width:600px;""><tr style=""background-color: #ef7f1a;""><![endif]-->

                <!--[if (mso)|(IE)]><td align=""center"" width=""600"" style=""width: 600px;padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;"" valign=""top""><![endif]-->
                <div class=""u-col u-col-100"" style=""max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;"">
                  <div style=""height: 100%;width: 100% !important;"">
                    <!--[if (!mso)&(!IE)]><!-->
                    <div style=""box-sizing: border-box; height: 100%; padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;"">
                      <!--<![endif]-->

                      <table style=""font-family:'Cabin',sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">
                        <tbody>
                          <tr>
                            <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:3px;font-family:'Cabin',sans-serif;"" align=""left"">

                              <table width=""100%"" cellpadding=""0"" cellspacing=""0"" border=""0"">
                                <tr>
                                  <td style=""padding-right: 0px;padding-left: 0px;"" align=""center"">

                                    <img align=""center"" border=""0"" src=""https://cdn.templates.unlayer.com/assets/1597218650916-xxxxc.png"" alt=""Image"" title=""Image"" style=""outline: none;text-decoration: none;-ms-interpolation-mode: bicubic;clear: both;display: inline-block !important;border: none;height: auto;float: none;width: 22%;max-width: 130.68px;""
                                      width=""130.68"" class=""v-src-width v-src-max-width"" />

                                  </td>
                                </tr>
                              </table>

                            </td>
                          </tr>
                        </tbody>
                      </table>

                      <table style=""font-family:'Cabin',sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">
                        <tbody>
                          <tr>
                            <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:5px;font-family:'Cabin',sans-serif;"" align=""left"">

                              <div style=""font-size: 14px; color: #e5eaf5; line-height: 140%; text-align: center; word-wrap: break-word;"">
                                <p style=""font-size: 14px; line-height: 140%;""><span style=""color: #ecf0f1; line-height: 19.6px;""><strong>T H A N K S&nbsp; &nbsp;F O R&nbsp; &nbsp;U S I N G</strong></span></p>
                              </div>

                            </td>
                          </tr>
                        </tbody>
                      </table>

                      <table style=""font-family:'Cabin',sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">
                        <tbody>
                          <tr>
                            <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:0px 10px 3px;font-family:'Cabin',sans-serif;"" align=""left"">

                              <div style=""font-size: 14px; color: #e5eaf5; line-height: 240%; text-align: center; word-wrap: break-word;"">
                                <h1>{type}</h1>
                              </div>

                            </td>
                          </tr>
                        </tbody>
                      </table>

                      <!--[if (!mso)&(!IE)]><!-->
                    </div>
                    <!--<![endif]-->
                  </div>
                </div>
                <!--[if (mso)|(IE)]></td><![endif]-->
                <!--[if (mso)|(IE)]></tr></table></td></tr></table><![endif]-->
              </div>
            </div>
          </div>





          <div class=""u-row-container"" style=""padding: 0px;background-color: transparent"">
            <div class=""u-row"" style=""margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #ffffff;"">
              <div style=""border-collapse: collapse;display: table;width: 100%;height: 100%;background-color: transparent;"">
                <!--[if (mso)|(IE)]><table width=""100%"" cellpadding=""0"" cellspacing=""0"" border=""0""><tr><td style=""padding: 0px;background-color: transparent;"" align=""center""><table cellpadding=""0"" cellspacing=""0"" border=""0"" style=""width:600px;""><tr style=""background-color: #ffffff;""><![endif]-->

                <!--[if (mso)|(IE)]><td align=""center"" width=""600"" style=""width: 600px;padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;"" valign=""top""><![endif]-->
                <div class=""u-col u-col-100"" style=""max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;"">
                  <div style=""height: 100%;width: 100% !important;"">
                    <!--[if (!mso)&(!IE)]><!-->
                    <div style=""box-sizing: border-box; height: 100%; padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;"">
                      <!--<![endif]-->

                      <table style=""font-family:'Cabin',sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">
                        <tbody>
                          <tr>
                            <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:14px 10px 19px;font-family:'Cabin',sans-serif;"" align=""left"">

                              <div style=""font-size: 14px; line-height: 160%; text-align: center; word-wrap: break-word;"">
                                <p style=""font-size: 18px; line-height: 160%;"">Congratulations <strong><span style=""font-size: 22px; line-height: 35.2px;"">{name}</span></strong>,</p>
                                <p style=""font-size: 18px; line-height: 160%;"">Serials of your company <strong>'{cmp}'</strong> have been successfully generated, serials have also been sent to your email, please save the serials, further serials are required.</p>
                              </div>

                            </td>
                          </tr>
                        </tbody>
                      </table>

                      <table style=""font-family:'Cabin',sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">
                        <tbody>
                          <tr>
                            <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:10px;font-family:'Cabin',sans-serif;"" align=""left"">

                              <!--[if mso]><table width=""100%""><tr><td><![endif]-->
                              <h1 style=""margin: 0px; color: #ff6600; line-height: 220%; text-align: center; word-wrap: break-word; font-family: arial,helvetica,sans-serif; font-size: 23px; font-weight: 700;""><span><span><span><span><span><span><span><span><span><span><span style=""line-height: 50.6px;""><span style=""line-height: 50.6px;""><span style=""line-height: 50.6px;"">{cmp}</span></span>
                                </span>
                                </span>
                                </span>
                                </span>
                                </span>
                                </span>
                                </span>
                                </span>
                                </span>
                                </span>
                                </span>
                              </h1>
                              <!--[if mso]></td></tr></table><![endif]-->

                            </td>
                          </tr>
                        </tbody>
                      </table>

                      <!--[if (!mso)&(!IE)]><!-->
                    </div>
                    <!--<![endif]-->
                  </div>
                </div>
                <!--[if (mso)|(IE)]></td><![endif]-->
                <!--[if (mso)|(IE)]></tr></table></td></tr></table><![endif]-->
              </div>
            </div>
          </div>





          <div class=""u-row-container"" style=""padding: 8px 50px;background-color: transparent"">
            <div class=""u-row"" style=""margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: transparent;"">
              <div style=""border-collapse: collapse;display: table;width: 100%;height: 100%;background-color: transparent;"">
                <!--[if (mso)|(IE)]><table width=""100%"" cellpadding=""0"" cellspacing=""0"" border=""0""><tr><td style=""padding: 8px 50px;background-color: transparent;"" align=""center""><table cellpadding=""0"" cellspacing=""0"" border=""0"" style=""width:600px;""><tr style=""background-color: transparent;""><![endif]-->

                <!--[if (mso)|(IE)]><td align=""center"" width=""596"" style=""width: 596px;padding: 0px;border-top: 2px dashed #5c68e2;border-left: 2px dashed #5c68e2;border-right: 2px dashed #5c68e2;border-bottom: 2px dashed #5c68e2;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;"" valign=""top""><![endif]-->
                <div class=""u-col u-col-100"" style=""max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;"">
                  <div style=""height: 100%;width: 100% !important;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;"">
                    <!--[if (!mso)&(!IE)]><!-->
                    <div style=""box-sizing: border-box; height: 100%; padding: 0px;border-top: 2px dashed #5c68e2;border-left: 2px dashed #5c68e2;border-right: 2px dashed #5c68e2;border-bottom: 2px dashed #5c68e2;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;"">
                      <!--<![endif]-->

                      <table style=""font-family:'Cabin',sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">
                        <tbody>
                          <tr>
                            <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:16px 7px 10px;font-family:'Cabin',sans-serif;"" align=""left"">

                              <div style=""font-family: arial,helvetica,sans-serif; font-size: 23px; font-weight: 700; line-height: 100%; text-align: center; word-wrap: break-word;"">
                                <p style=""line-height: 100%;"">Company Serial No.</p>
                              </div>

                            </td>
                          </tr>
                        </tbody>
                      </table>

                      <table style=""font-family:'Cabin',sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">
                        <tbody>
                          <tr>
                            <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:0px 0px 16px;font-family:'Cabin',sans-serif;"" align=""left"">

                              <div style=""font-family: arial,helvetica,sans-serif; font-size: 35px; font-weight: 700; line-height: 110%; text-align: center; word-wrap: break-word;"">
                                <p style=""line-height: 110%;""><span style=""color: #5c68e2; line-height: 44px;"">{LC}</span></p>
                              </div>

                            </td>
                          </tr>
                        </tbody>
                      </table>

                      <!--[if (!mso)&(!IE)]><!-->
                    </div>
                    <!--<![endif]-->
                  </div>
                </div>
                <!--[if (mso)|(IE)]></td><![endif]-->
                <!--[if (mso)|(IE)]></tr></table></td></tr></table><![endif]-->
              </div>
            </div>
          </div>





          <div class=""u-row-container"" style=""padding: 0px;background-color: transparent"">
            <div class=""u-row"" style=""margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: transparent;"">
              <div style=""border-collapse: collapse;display: table;width: 100%;height: 100%;background-color: transparent;"">
                <!--[if (mso)|(IE)]><table width=""100%"" cellpadding=""0"" cellspacing=""0"" border=""0""><tr><td style=""padding: 0px;background-color: transparent;"" align=""center""><table cellpadding=""0"" cellspacing=""0"" border=""0"" style=""width:600px;""><tr style=""background-color: transparent;""><![endif]-->

                <!--[if (mso)|(IE)]><td align=""center"" width=""600"" style=""width: 600px;padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;"" valign=""top""><![endif]-->
                <div class=""u-col u-col-100"" style=""max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;"">
                  <div style=""height: 100%;width: 100% !important;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;"">
                    <!--[if (!mso)&(!IE)]><!-->
                    <div style=""box-sizing: border-box; height: 100%; padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;"">
                      <!--<![endif]-->

                      <table style=""font-family:'Cabin',sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">
                        <tbody>
                          <tr>
                            <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:10px 10px 9px;font-family:'Cabin',sans-serif;"" align=""left"">

                              <div style=""font-family: arial,helvetica,sans-serif; font-size: 17px; line-height: 140%; text-align: center; word-wrap: break-word;"">
                                <p style=""line-height: 140%;"">{date}</p>
                              </div>

                            </td>
                          </tr>
                        </tbody>
                      </table>

                      <table style=""font-family:'Cabin',sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">
                        <tbody>
                          <tr>
                            <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:23px 10px 5px;font-family:'Cabin',sans-serif;"" align=""left"">

                              <div style=""font-size: 19px; line-height: 140%; text-align: center; word-wrap: break-word;"">
                                <p style=""line-height: 140%;""><span style=""line-height: 26.6px;"">Thanks,</span></p>
                                <p style=""line-height: 140%;""><span style=""line-height: 26.6px;"">The Company Team</span></p>
                              </div>

                            </td>
                          </tr>
                        </tbody>
                      </table>

                      <!--[if (!mso)&(!IE)]><!-->
                    </div>
                    <!--<![endif]-->
                  </div>
                </div>
                <!--[if (mso)|(IE)]></td><![endif]-->
                <!--[if (mso)|(IE)]></tr></table></td></tr></table><![endif]-->
              </div>
            </div>
          </div>





          <div class=""u-row-container"" style=""padding: 0px;background-color: transparent"">
            <div class=""u-row"" style=""margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #fcefe6;"">
              <div style=""border-collapse: collapse;display: table;width: 100%;height: 100%;background-color: transparent;"">
                <!--[if (mso)|(IE)]><table width=""100%"" cellpadding=""0"" cellspacing=""0"" border=""0""><tr><td style=""padding: 0px;background-color: transparent;"" align=""center""><table cellpadding=""0"" cellspacing=""0"" border=""0"" style=""width:600px;""><tr style=""background-color: #fcefe6;""><![endif]-->

                <!--[if (mso)|(IE)]><td align=""center"" width=""600"" style=""width: 600px;padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;"" valign=""top""><![endif]-->
                <div class=""u-col u-col-100"" style=""max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;"">
                  <div style=""height: 100%;width: 100% !important;"">
                    <!--[if (!mso)&(!IE)]><!-->
                    <div style=""box-sizing: border-box; height: 100%; padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;"">
                      <!--<![endif]-->

                      <table style=""font-family:'Cabin',sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">
                        <tbody>
                          <tr>
                            <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:41px 55px 18px;font-family:'Cabin',sans-serif;"" align=""left"">

                              <div style=""font-size: 14px; color: #003399; line-height: 160%; text-align: center; word-wrap: break-word;"">
                                <p style=""font-size: 14px; line-height: 160%;""><span style=""font-size: 20px; line-height: 32px; color: #000000;""><strong>Contact Us</strong></span></p>
                                <p style=""font-size: 14px; line-height: 160%;""><span style=""font-size: 16px; line-height: 25.6px; color: #000000;"">Phone: +91 63531 61009, +91 94288 37047</span></p>
                                <p style=""font-size: 14px; line-height: 160%;""><span style=""font-size: 16px; line-height: 25.6px; color: #000000;"">Email: cryptonixtechnology@gmail.com</span></p>
                              </div>

                            </td>
                          </tr>
                        </tbody>
                      </table>

                      <!--[if (!mso)&(!IE)]><!-->
                    </div>
                    <!--<![endif]-->
                  </div>
                </div>
                <!--[if (mso)|(IE)]></td><![endif]-->
                <!--[if (mso)|(IE)]></tr></table></td></tr></table><![endif]-->
              </div>
            </div>
          </div>





          <div class=""u-row-container"" style=""padding: 0px;background-color: transparent"">
            <div class=""u-row"" style=""margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #ff6600;"">
              <div style=""border-collapse: collapse;display: table;width: 100%;height: 100%;background-color: transparent;"">
                <!--[if (mso)|(IE)]><table width=""100%"" cellpadding=""0"" cellspacing=""0"" border=""0""><tr><td style=""padding: 0px;background-color: transparent;"" align=""center""><table cellpadding=""0"" cellspacing=""0"" border=""0"" style=""width:600px;""><tr style=""background-color: #ff6600;""><![endif]-->

                <!--[if (mso)|(IE)]><td align=""center"" width=""600"" style=""width: 600px;padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;"" valign=""top""><![endif]-->
                <div class=""u-col u-col-100"" style=""max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;"">
                  <div style=""height: 100%;width: 100% !important;"">
                    <!--[if (!mso)&(!IE)]><!-->
                    <div style=""box-sizing: border-box; height: 100%; padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;"">
                      <!--<![endif]-->

                      <table style=""font-family:'Cabin',sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">
                        <tbody>
                          <tr>
                            <td class=""v-container-padding-padding"" style=""overflow-wrap:break-word;word-break:break-word;padding:10px;font-family:'Cabin',sans-serif;"" align=""left"">

                              <div style=""font-size: 14px; color: #fafafa; line-height: 180%; text-align: center; word-wrap: break-word;"">
                                <p style=""font-size: 14px; line-height: 180%;""><span style=""font-size: 16px; line-height: 28.8px;"">Copyrights © Company All Rights Reserved</span></p>
                              </div>

                            </td>
                          </tr>
                        </tbody>
                      </table>

                      <!--[if (!mso)&(!IE)]><!-->
                    </div>
                    <!--<![endif]-->
                  </div>
                </div>
                <!--[if (mso)|(IE)]></td><![endif]-->
                <!--[if (mso)|(IE)]></tr></table></td></tr></table><![endif]-->
              </div>
            </div>
          </div>



          <!--[if (mso)|(IE)]></td></tr></table><![endif]-->
        </td>
      </tr>
    </tbody>
  </table>
  <!--[if mso]></div><![endif]-->
  <!--[if IE]></div><![endif]-->
</body>

</html>"

        st = st.Replace("{type}", "Company Create Successfully")
        st = st.Replace("{name}", LC_Name)
        st = st.Replace("{cmp}", Company_Name_TXT.Text)
        st = st.Replace("{LC}", Company_serial_No)
        st = st.Replace("{date}", Now.Date.ToString("dddd, dd MMMM yyyy"))

        Return st
    End Function
    Public Function ABC_Find(i As String) As String
        Select Case i
            Case "A"
                Return "A"
            Case "B"
                Return "B"
            Case "C"
                Return "C"
            Case "D"
                Return "D"
            Case "E"
                Return "E"
            Case "F"
                Return "F"
            Case "G"
                Return "G"
            Case "H"
                Return "H"
            Case "I"
                Return "I"
            Case "J"
                Return "J"
            Case "K"
                Return "K"
            Case "L"
                Return "L"
            Case "M"
                Return "M"
            Case "N"
                Return "N"
            Case "O"
                Return "O"
            Case "P"
                Return "P"
            Case "Q"
                Return "Q"
            Case "R"
                Return "R"
            Case "S"
                Return "S"
            Case "T"
                Return "T"
            Case "U"
                Return "U"
            Case "V"
                Return "V"
            Case "W"
                Return "W"
            Case "X"
                Return "X"
            Case "Y"
                Return "Y"
            Case "Z"
                Return "Z"
            Case Else
                Return "Z"
        End Select

    End Function

    Private Sub Button6_Click(sender As Object, e As EventArgs)
        PictureBox1.Image = Nothing
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)
        PictureBox2.Image = Nothing
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        PictureBox3.Image = Nothing
    End Sub

    Private Sub Label19_Click(sender As Object, e As EventArgs)
        Company_Create_resource_dialog.ShowDialog()
    End Sub

    Private Sub Yn1_TextChanged(sender As Object, e As EventArgs) Handles Yn1.TextChanged

    End Sub

    Private Sub Yn1_KeyDown(sender As Object, e As KeyEventArgs) Handles Yn1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If sender.Text = "Yes" Then
                Company_Create_resource_dialog.ShowDialog()
            End If
        End If
    End Sub

    Private Sub Panel12_Paint(sender As Object, e As PaintEventArgs) Handles Panel12.Paint

    End Sub

    Private Sub Txt1_TextChanged_1(sender As Object, e As EventArgs) Handles Txt1.TextChanged
        If Txt1.Text = "Unregistered" Then
            GST_TXT.Text = ""
            GST_TXT.Enabled = False

        Else
            GST_TXT.Enabled = True
        End If
    End Sub

    Private Sub Yn3_TextChanged(sender As Object, e As EventArgs) Handles Yn3.TextChanged

    End Sub

    Private Sub Yn3_KeyDown(sender As Object, e As KeyEventArgs) Handles Yn3.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Yn3.Text = "Yes" Then
                Dim str As String() = Find_IfscCode(IFSC_Code_TXT.Text)

                Bank_TXT.Text = str(0)
                Bank_Branch_TXT.Text = str(1)

            End If
        End If
    End Sub

    Private Sub Yn4_TextChanged(sender As Object, e As EventArgs) Handles Yn4.TextChanged

    End Sub
    Dim city_Datatabale As DataTable

    Private Sub Yn4_KeyDown(sender As Object, e As KeyEventArgs) Handles Yn4.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Yn4.Text = "Yes" Then
                city_Datatabale.Rows.Clear()
                city_Datatabale.Rows.Add("", "Other City")

                City_TXT.Type_ = "Select"

                State_TXT.Text = ""

                Dim cn As New SQLiteConnection
                If open_MSSQL_Cstm(Database_File.cfgs, cn) = True Then
                    cmd = New SQLiteCommand($"Select * From TBL_Address where Pincode = '{Pincode_TXT.Text}'", cn)
                    Dim r As SQLiteDataReader
                    r = cmd.ExecuteReader
                    While r.Read
                        If r("Taluka").ToString <> "NA" Then
                            State_TXT.Text = r("State").ToString
                        End If
                        city_Datatabale.Rows.Add(r("City"), "", "")
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

    Private Sub Label69_Click(sender As Object, e As EventArgs) Handles Label69.Click
        Label69.Visible = False
        Label68.Text = "Chacking..."
        Label68.ForeColor = Color.Orange
        Database_chack_Background.RunWorkerAsync()
    End Sub

    Private Sub Database_chack_Background_DoWork(sender As Object, e As DoWorkEventArgs) Handles Database_chack_Background.DoWork
        Dim con_String = ""
        Dim cn As New SqlConnection

        If ServerUser_TXT.Text = Nothing Then
            con_String = String.Format($"Server={ServerName_TXT.Text};Database={ServerDatabase_TXT.Text};Trusted_Connection=True")
        Else
            con_String = String.Format($"Server={ServerName_TXT.Text};Database={ServerDatabase_TXT.Text};User Id={ServerUser_TXT.Text};Password={ServerPassword_TXT.Text}")
        End If

        Try
            cn.ConnectionString = con_String
            cn.Open()
            issuccess = True
        Catch ex As Exception
            issuccess = False
        End Try
        cn.Close()

    End Sub

    Private Sub Database_chack_Background_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles Database_chack_Background.RunWorkerCompleted
        Label69.Visible = True
        If issuccess = True Then
            Label68.Text = "Connected"
            Label68.ForeColor = Color.Green
        Else
            Label68.Text = "Disconnected"
            Label68.ForeColor = Color.Red
        End If
    End Sub

    Private Sub ServerUser_TXT_TextChanged(sender As Object, e As EventArgs) Handles ServerUser_TXT.TextChanged
        If ServerUser_TXT.Text = Nothing Then
            ServerPassword_TXT.Enabled = False
        Else
            ServerPassword_TXT.Enabled = True
        End If
    End Sub

    Private Sub ServerName_TXT_TextChanged(sender As Object, e As EventArgs) Handles ServerName_TXT.TextChanged

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

    Private Sub Panel36_Paint(sender As Object, e As PaintEventArgs) Handles Panel36.Paint

    End Sub

    Private Sub Company_Creation_frm_GiveFeedback(sender As Object, e As GiveFeedbackEventArgs) Handles Me.GiveFeedback

    End Sub
End Class