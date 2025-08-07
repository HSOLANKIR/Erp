Imports System.Data.SQLite
Imports System.IO
Imports Tools

Public Class Payroll_Employee_frm
    Dim From_ID As String
    Dim Under_ID As String
    Dim Under As String
    Dim Path_End As String
    Dim VC_Type_ As String
    Dim VC_ID_ As String

    Public close_focus_obj As TXT
    Public close_link_yn As Boolean = False

    Private Sub Payroll_Employee_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text
        VC_Type_ = Link_Valu(1)
        VC_ID_ = Link_Valu(2)
        BG_frm.HADE_TXT.Text = "Payroll Employee"
        BG_frm.TYP_TXT.Text = VC_Type_

        Date_of_Joining_TXT.Text = Now.Date.ToString("dd-MM-yyyy")

        Fill_Data_Source()
        List_set()


        If VC_Type_ = "Display" Or VC_Type_ = "Display_Close" Then
            Me.Enabled = False
            Display_Fill_All()
        ElseIf VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close" Then
            Me.Enabled = True
            Display_Fill_All()

            Label61.Visible = True
            Label62.Visible = True
            Yn1.Visible = True

        ElseIf VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
        End If
        Button_Manage()
        Add_Hander_Remove_Handel(True)
        YN_Fill()


        Name_TXT.Focus()

    End Sub
    Private Function Fill_Data_Source()
        Dim cn As New SQLiteConnection
        Dim dt As New DataTable

        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            Dim dr As DataRow

            dt.Clear()
            dt.Columns.Add("Name")
            dt.Columns.Add("Nickname")
            dt.Columns.Add("ID")

            dt.Rows.Add("", "Create", "0")
            dt.Rows.Add("Primary", "", "0")


            cmd = New SQLiteCommand("Select * From TBL_Stock_Group where (Head = 'Payroll' or Head = 'All') and Visible = 'Approval'", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                dr = dt.NewRow
                dr("Name") = r("Name")
                dr("Nickname") = r("Nickname")
                dr("ID") = r("ID")
                dt.Rows.Add(dr)
            End While
            r.Close()
            Under_Source.DataSource = dt
        End If
        cn.Close()


        dt = New DataTable
        dt.Columns.Add("Name")

        dt.Rows.Add("Unknown")
        dt.Rows.Add("Male")
        dt.Rows.Add("Female")
        Gender_Source.DataSource = dt

    End Function
    Dim group_list As List_frm
    Dim gender_list As List_frm
    Private Function List_set()
        group_list = New List_frm
        List_Setup("List of Account Groups", Select_List.Right_Dock, Select_List_Format.Defolt, Group_TXT, group_list, Under_Source, 320)
        group_list.System_Data_integer = 1

        gender_list = New List_frm
        List_Setup("Gender", Select_List.Right, Select_List_Format.Singel, Gender_TXT, gender_list, Gender_Source, 130)

    End Function
    Private Function Button_Manage()
        Button_Clear()
        BG_frm.B_1.Text = "|&E : Exit"
        BG_frm.B_2.Text = "|&S : Save"
        If VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close" Then
            BG_frm.B_3.Text = "&D : Delete"
        End If
        BG_frm.B_4.Text = "|&T : Attach"
    End Function
    Private Function Add_Hander_Remove_Handel(Ans As Boolean)
        If Ans = True Then
            AddHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            AddHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
            AddHandler BG_frm.B_3.Click, AddressOf Me.B_3_Click
            AddHandler BG_frm.B_4.Click, AddressOf Me.B_4_Click
        Else
            RemoveHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            RemoveHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
            RemoveHandler BG_frm.B_3.Click, AddressOf Me.B_3_Click
            RemoveHandler BG_frm.B_4.Click, AddressOf Me.B_4_Click
        End If
    End Function
    Private Sub B_1_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Me.Dispose()
        End If
    End Sub
    Private Sub B_2_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Save_Data()
        End If
    End Sub
    Private Sub B_3_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            If VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close" Then
                If BG_frm.From_ID = From_ID Then
                    Delete_Data()
                End If
            End If
        End If
    End Sub
    Private Sub B_4_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            With attage_display
                .Grid_ = DataGridView1
                .ShowDialog()
            End With
        End If
    End Sub
    Private Function Save_Data()
        If BG_frm.From_ID = From_ID Then
            If Save_Requr() = True Then
                If Insurt_Audit() = True Then
                    If Insurt_Value() = True Then
                        If Document_Save() = True Then
                            Clear_all()
                        End If
                    End If
                End If
            End If
        End If
    End Function
    Private Function Delete_Data()
        Dim cn As New SQLiteConnection
        open_MSSQL_Cstm(Database_File.cre, cn)


        If Chack_Delete_Allow() = True Then
            If Msg_Delete_YN(Name_TXT, "Employee") = DialogResult.Yes Then
                If Insurt_Audit() = True Then
                    qury = $"DELETE FROM TBL_Payroll_Employee Where ID = '{VC_ID_}';"
                    cmd = New SQLiteCommand(qury, cn)
                    cmd.ExecuteNonQuery()
                    Clear_all()
                End If
            End If
        Else
            Msg(NOT_Type.Info, "You cannot Employee", "You cannot delete this Employee because the Employee you selected is made up of vouchers")
        End If
    End Function
    Private Function Insurt_Audit() As Boolean
        If Val(VC_ID_) = 0 Then
            Return True
        End If

        If Audit_Save("TBL_Payroll_Employee", "ID", VC_ID_) = True Then
            Return True
        End If
    End Function
    Private Function Chack_Delete_Allow() As Boolean
        If Chack_Duplicate(Database_File.cre, "TBL_Attendance_VC", "ID", "Account = '" & VC_ID_ & "' and Visible = 'Approval'") = True Then
            Return False
        End If
        Return True
    End Function
    Dim Duplicate_Type As String
    Dim Duplicate_Type1 As String

    Dim Duplicate_Alias_Type As String
    Dim Duplicate_Alias_Type1 As String
    Private Function Save_Requr() As Boolean
        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            Duplicate_Type = " Name  = '" & Name_TXT.Text & "'"
        Else
            Duplicate_Type = " Name  = '" & Name_TXT.Text & "' and ID <> '" & VC_ID_ & "'"
        End If
        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            Duplicate_Type1 = " Alias  = '" & Name_TXT.Text & "'"
        Else
            Duplicate_Type1 = " Alias  = '" & Name_TXT.Text & "' and ID <> '" & VC_ID_ & "'"
        End If
        '//
        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            Duplicate_Alias_Type = " Name  = '" & Alias_TXT.Text & "'"
        Else
            Duplicate_Alias_Type = " Name  = '" & Alias_TXT.Text & "' and ID <> '" & VC_ID_ & "'"
        End If

        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            Duplicate_Alias_Type1 = " Alias  = '" & Alias_TXT.Text & "'"
        Else
            Duplicate_Alias_Type1 = " Alias  = '" & Alias_TXT.Text & "' and ID <> '" & VC_ID_ & "'"
        End If

        If Name_TXT.Text = "" Then
            Msg(NOT_Type.Warning, "Input Error!", "Please enter name and try agin")
            Name_TXT.Focus()
            Return False
            Exit Function
        End If
        If Chack_Duplicate(Database_File.cre, "TBL_Payroll_Employee", "Name", Duplicate_Type) = True Then
            Msg(NOT_Type.Warning, "Duplicate Name", "Name already exists please change name and try again")
            Name_TXT.Focus()
            Return False
            Exit Function
        End If
        If Chack_Duplicate(Database_File.cre, "TBL_Payroll_Employee", "Alias", Duplicate_Type1) = True And Alias_TXT.Text <> Nothing Then
            Msg(NOT_Type.Warning, "Duplicate Name", "Name already exists please change name and try again")
            Return False
            Exit Function
        End If
        ''
        If Chack_Duplicate(Database_File.cre, "TBL_Payroll_Employee", "Name", Duplicate_Alias_Type) = True Then
            Msg(NOT_Type.Warning, "Duplicate Alias", "Alias already exists please change name and try again")
            Return False
            Exit Function
        End If
        If Chack_Duplicate(Database_File.cre, "TBL_Payroll_Employee", "Alias", Duplicate_Alias_Type1) = True And Alias_TXT.Text <> Nothing Then
            Msg(NOT_Type.Warning, "Duplicate Alias", "Alias already exists please change name and try again")
            Alias_TXT.Focus()
            Return False
            Exit Function
        End If
        If Name_TXT.Text = Alias_TXT.Text Then
            Msg(NOT_Type.Warning, "Name and Alias Same", "Please change Name or Alias and try again")
            Alias_TXT.Focus()
            Return False
            Exit Function
        End If
        If Chack_Duplicate(Database_File.cre, "TBL_Stock_Group", "Name", " (Name  = '" & Group_TXT.Text & "') and (Head = 'Payroll' or Head = 'All')") = False Then
            If Group_TXT.Text = "Primary" Then
                Under_ID = "0"
            Else
                Msg(NOT_Type.Warning, "Selection Error", "Under Group select error, Please select again")
                Group_TXT.Focus()
                Return False
                Exit Function
            End If
        Else
            Under_ID = Find_DT_Value(Database_File.cre, "TBL_Stock_Group", "ID", " (Name  = '" & Group_TXT.Text & "') and (Head = 'Payroll' or Head = 'All')")
        End If
        If Date_of_Joining_TXT.Text = "" Then
            Msg(NOT_Type.Warning, "Input Error", "Please enter Date of joining, and try again")
            Date_of_Joining_TXT.Focus()
            Return False
            Exit Function
        End If
        Return True
    End Function
    Dim Logo_ As Byte()
    Private Function Insurt_Salary_details(Id As String)

        Dim Grup_ID As String = Find_DT_Value(Database_File.cre, "TBL_Stock_Group", "ID", $"Name = '{Group_TXT.Text}'")

        Dim dt_sd As New DataTable
        dt_sd.Columns.Add("Date")
        dt_sd.Columns.Add("Payhead")
        dt_sd.Columns.Add("Rate")

        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select sd.[Date],sd.Payhead,sd.Rate,PD.Payhead_Type,PD.Cal_Type,PD.Cal,
(Select [Unit] From TBL_Payroll_Att_Production_Type ff where ff.ID = PD.Production) as Unit_Name

From TBL_Payroll_SalaryDetails sd
LEFT JOIN TBL_Payhead PD ON PD.ID = sd.Payhead

where sd.Account = '{Grup_ID}' and (sd.Under = 'Group')", cn)

            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                dt_sd.Rows.Add(CDate(r("Date").ToString), r("Payhead").ToString, r("Rate").ToString)
            End While
            r.Close()
            For i As Integer = 0 To dt_sd.Rows.Count - 1
                cmd = New SQLiteCommand("INSERT INTO TBL_Payroll_SalaryDetails (Account,Under,Date,Payhead,Rate,Date_of_deduction,installment_period,Company,Visible,[User],Date_install,PC) VALUES (@Account,@Under,@Date,@Payhead,@Rate,@Date_of_deduction,@installment_period,@Company,@Visible,@User,@Install_,@PC)", cn)
                With cmd.Parameters
                    .AddWithValue("@Account", Id)
                    .AddWithValue("@Under", "Employee")
                    .AddWithValue("@Date", CDate(dt_sd(i)(0)))
                    .AddWithValue("@Payhead", dt_sd(i)(1))
                    .AddWithValue("@Rate", Val(dt_sd(i)(2)))
                    .AddWithValue("@Date_of_deduction", Val(0))
                    .AddWithValue("@installment_period", Val(0))
                    .AddWithValue("@Company", Company_ID_str)
                    .AddWithValue("@User", LOGIN_ID)
                    .AddWithValue("@PC", PC_ID.Trim)
                    .AddWithValue("@Install_", CDate(DateTime.Now))
                    .AddWithValue("@Visible", "Approval")
                    cmd.ExecuteNonQuery()
                End With
            Next

        End If
    End Function
    Private Function Insurt_Value() As Boolean
        Dim img As Image = PictureBox1.Image
        Dim ms As New MemoryStream

        If VC_Type_ = "Create" OrElse VC_Type_ = "Create_Close" Then
            If open_MSSQL(Database_File.cre) Then
                Dim q1 As String = "INSERT INTO TBL_Payroll_Employee (Name, alias, Under, Discription, Note, Date_of_joining, Mobile1, Mobile2, Aadhaar, PAN, Salary, PF_No, Nominee, Email, Gender, Date_of_birth, Father_Name, Father_Mobile, Pincode, State, Dis, Taluka, City, Address, Bank_Name, Bank_Branch, Bank_IFSC_code, Bank_AccounNo, Company, Visible, [User], Date_install, PC"

                Dim q2 As String = "(@Name,@alias,@Under,@Discription,@Note,@Date_of_joining,@Mobile1,@Mobile2,@Aadhaar,@PAN,@Salary,@PF_No,@Nominee,@Email,@Gender,@Date_of_birth,@Father_Name,@Father_Mobile,@Pincode,@State,@Dis,@Taluka,@City,@Address,@Bank_Name,@Bank_Branch,@Bank_IFSC_code,@Bank_AccounNo,@Company,@Visible,@User,@Install_,@PC"

                If img IsNot Nothing Then
                    q1 &= ", Photo"
                    q2 &= ",@Photo"
                End If

                q1 &= ")"
                q2 &= ")"

                qury = q1 & " VALUES " & q2

                cmd = New SQLiteCommand(qury, con)
                Try
                    With cmd.Parameters
                        .AddWithValue("@Name", Name_TXT.Text.Trim)
                        .AddWithValue("@Alias", Alias_TXT.Text.Trim)
                        .AddWithValue("@Under", Under_ID.Trim)
                        .AddWithValue("@Discription", Discription_TXT.Text.Trim)
                        .AddWithValue("@Note", Note_TXT.Text.Trim)
                        If Date_of_Joining_TXT.Text = Nothing Then
                            .AddWithValue("@Date_of_joining", "")
                        Else
                            .AddWithValue("@Date_of_joining", CDate(Date_of_Joining_TXT.Text))
                        End If

                        .AddWithValue("@Aadhaar", Aadhaar_TXT.Text.Trim)
                        .AddWithValue("@PAN", PAN_TXT.Text.Trim)
                        .AddWithValue("@Salary", "0")
                        .AddWithValue("@PF_No", PF_TXT.Text.Trim)
                        .AddWithValue("@Nominee", Nominee_TXT.Text.Trim)
                        .AddWithValue("@Mobile1", Mobile1_TXT.Text.Trim)
                        .AddWithValue("@Mobile2", Mobile2_TXT.Text.Trim)
                        .AddWithValue("@Email", Email_TXT.Text.Trim)
                        .AddWithValue("@Gender", Gender_TXT.Text.Trim)

                        If Date_of_birth_TXT.Text = Nothing Then
                            .AddWithValue("@Date_of_birth", "")
                        Else
                            .AddWithValue("@Date_of_birth", CDate(Date_of_birth_TXT.Text))
                        End If
                        .AddWithValue("@Father_Name", Father_Name_TXT.Text.Trim)
                        .AddWithValue("@Father_Mobile", Father_Mobile_TXT.Text.Trim)
                        .AddWithValue("@Pincode", Pincode_TXT.Text.Trim)
                        .AddWithValue("@State", State_TXT.Text.Trim)
                        .AddWithValue("@Dis", Dis_TXT.Text.Trim)
                        .AddWithValue("@Taluka", Taluka_TXT.Text.Trim)
                        .AddWithValue("@City", Cirt_TXT.Text.Trim)
                        .AddWithValue("@Address", OtherAddress_TXT.Text.Trim)
                        .AddWithValue("@Bank_Name", Bank_TXT.Text.Trim)
                        .AddWithValue("@Bank_Branch", BankBranch_TXT.Text.Trim)
                        .AddWithValue("@Bank_IFSC_code", Bank_IFSC_TXT.Text.Trim)
                        .AddWithValue("@Bank_AccounNo", BankAccount_TXT.Text.Trim)
                        .AddWithValue("@Company", Company_ID_str.Trim)
                        .AddWithValue("@Visible", "Approval".Trim)
                        .AddWithValue("@User", LOGIN_ID)
                        .AddWithValue("@Install_", CDate(DateTime.Now))
                        .AddWithValue("@PC", PC_ID.Trim)
                        If img IsNot Nothing Then
                            Logo_ = ImageToByteArray(PictureBox1.Image)
                            .Add("@Photo", DbType.Binary).Value = Logo_
                            ms.Close()
                        End If
                        cmd.ExecuteNonQuery()
                    End With
                    Return True
                Catch ex As Exception
                    Msg(NOT_Type.Erro, "Data Save Error", ex.Message)
                    Return False
                End Try
            End If
        Else
            If open_MSSQL(Database_File.cre) Then
                Dim Q1 As String = "UPDATE TBL_Payroll_Employee Set Name = @Name, Alias = @Alias, Under = @Under, Discription = @Discription, Note = @Note, Date_of_joining = @Date_of_joining, Mobile1 = @Mobile1, Mobile2 = @Mobile2,Aadhaar = @Aadhaar,PAN = @PAN,Salary = @Salary,PF_No = @PF_No,Nominee = @Nominee, Email = @Email, Gender = @Gender, Date_of_birth = @Date_of_birth, Father_Name = @Father_Name, Father_Mobile = @Father_Mobile, Pincode = @Pincode, State = @State, Dis = @Dis,Taluka = @Taluka, City = @City, Address = @Address, Bank_Name = @Bank_Name, Bank_Branch = @Bank_Branch, Bank_IFSC_code = @Bank_IFSC_code, Bank_AccounNo  = @Bank_AccounNo,[User] = @User,Date_install = @Install_,PC = @PC"

                If img IsNot Nothing Then
                    Q1 &= ",Photo = @Photo"
                End If

                qury = Q1 & " WHERE ID = '" & VC_ID_ & "'"
                cmd = New SQLiteCommand(qury, con)
                Try
                    With cmd.Parameters
                        .AddWithValue("@Name", Name_TXT.Text.Trim)
                        .AddWithValue("@alias", Alias_TXT.Text.Trim)
                        .AddWithValue("@Under", Under_ID.Trim)
                        .AddWithValue("@Discription", Discription_TXT.Text.Trim)
                        .AddWithValue("@Note", Note_TXT.Text.Trim)

                        If Date_of_Joining_TXT.Text = Nothing Then
                            .AddWithValue("@Date_of_joining", "")
                        Else
                            .AddWithValue("@Date_of_joining", CDate(Date_of_Joining_TXT.Text))
                        End If

                        .AddWithValue("@Mobile1", Mobile1_TXT.Text.Trim)
                        .AddWithValue("@Mobile2", Mobile2_TXT.Text.Trim)
                        .AddWithValue("@Aadhaar", Aadhaar_TXT.Text.Trim)
                        .AddWithValue("@PAN", PAN_TXT.Text.Trim)
                        .AddWithValue("@Salary", "0")
                        .AddWithValue("@PF_No", PF_TXT.Text.Trim)
                        .AddWithValue("@Nominee", Nominee_TXT.Text.Trim)
                        .AddWithValue("@Email", Email_TXT.Text.Trim)
                        .AddWithValue("@Gender", Gender_TXT.Text.Trim)

                        If Date_of_birth_TXT.Text = Nothing Then
                            .AddWithValue("@Date_of_birth", "")
                        Else
                            .AddWithValue("@Date_of_birth", CDate(Date_of_birth_TXT.Text))
                        End If


                        .AddWithValue("@Father_Name", Father_Name_TXT.Text.Trim)
                        .AddWithValue("@Father_Mobile", Father_Mobile_TXT.Text.Trim)
                        .AddWithValue("@Pincode", Pincode_TXT.Text.Trim)
                        .AddWithValue("@State", State_TXT.Text.Trim)
                        .AddWithValue("@Dis", Dis_TXT.Text.Trim)
                        .AddWithValue("@Taluka", Taluka_TXT.Text.Trim)
                        .AddWithValue("@City", Cirt_TXT.Text.Trim)
                        .AddWithValue("@Address", OtherAddress_TXT.Text.Trim)
                        .AddWithValue("@Bank_Name", Bank_TXT.Text.Trim)
                        .AddWithValue("@Bank_Branch", BankBranch_TXT.Text.Trim)
                        .AddWithValue("@Bank_IFSC_code", Bank_IFSC_TXT.Text.Trim)
                        .AddWithValue("@Bank_AccounNo", BankAccount_TXT.Text.Trim)
                        .AddWithValue("@User", LOGIN_ID)
                        .AddWithValue("@Install_", CDate(DateTime.Now))
                        .AddWithValue("@PC", PC_ID.Trim)
                        If img IsNot Nothing Then
                            Logo_ = ImageToByteArray(PictureBox1.Image)
                            .Add("@Photo", DbType.Binary).Value = Logo_
                            ms.Close()
                        Else
                            .Add("@Photo", DbType.Binary).Value = Nothing
                            ms.Close()
                        End If
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
    Private Function Document_Save() As Boolean
        If open_MSSQL(Database_File.rec) = True Then
            qury = "INSERT INTO TBL_Attage (Name,Narration,TBL,TBL_ID,Attage,Attage_Type,Password,[User],Date_install,PC,Visible) VALUES (@Name,@Narration,@TBL,@TBL_ID,@Attage,@Attage_Type,@Password,@User,@Install_,@PC,@Visible)"
            For i As Integer = 0 To DataGridView1.Rows.Count - 1
                Dim ro As DataGridViewRow = DataGridView1.Rows(i)
                If ro.Cells(0).Value = "0" Then
                    cmd = New SQLiteCommand(qury, con)

                    cmd = New SQLiteCommand(qury, con)
                    Dim Byt As Byte()
                    Byt = DirectCast(ro.Cells(4).Value, Byte())

                    Try
                        With cmd.Parameters
                            .AddWithValue("@Name", ro.Cells(1).Value)
                            .AddWithValue("@Narration", ro.Cells(2).Value)
                            .AddWithValue("@TBL", "Employee")
                            .AddWithValue("@TBL_ID", Find_DT_Value(Database_File.cre, "TBL_Payroll_Employee", "ID", "Name = '" & Name_TXT.Text & "'"))
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
            'BG_frm.Payroll_Employee_BS.DataSource = Nothing
            'BG_frm.Payroll_Employee_BS.DataSource = Fill_Payroll_Employee(cn)
        End If
        Dim id_ As String = Find_DT_Value(Database_File.cre, "TBL_Payroll_Employee", "ID", "Name = '" & Name_TXT.Text & "'")



        If VC_Type_ = "Create" Then
            Name_TXT.Text = ""
            Alias_TXT.Text = ""
            Discription_TXT.Text = ""
            Note_TXT.Text = ""
            Mobile1_TXT.Text = ""
            Mobile2_TXT.Text = ""
            Email_TXT.Text = ""
            Gender_TXT.Text = "Unknown"
            Date_of_birth_TXT.Text = ""
            Label19.Text = ""
            Father_Name_TXT.Text = ""
            Father_Mobile_TXT.Text = ""
            Pincode_TXT.Text = ""
            State_TXT.Text = ""
            Dis_TXT.Text = ""
            Taluka_TXT.Text = ""
            Cirt_TXT.Text = ""
            Bank_TXT.Text = ""
            BankBranch_TXT.Text = ""
            Bank_IFSC_TXT.Text = ""
            BankAccount_TXT.Text = ""
            PictureBox1.Image = Nothing
            DataGridView1.Rows.Clear()



            If Yn1.Text <> "Yes" Then
                Name_TXT.Focus()
            End If
            Insurt_Salary_details(id_)
            NOT_("The entry you entered has been successfully accepted", NOT_Type.Success)
        Else
            If VC_Type_ = "Create_Close" Then
                Insurt_Salary_details(id_)
            End If

            If close_link_yn = True Then
                close_focus_obj.Text = Name_TXT.Text
                close_focus_obj.Focus()
            End If

            Me.Dispose()
        End If
    End Function
    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles Pincode_TXT.TextChanged

    End Sub

    Private Sub TextBox8_KeyDown(sender As Object, e As KeyEventArgs) Handles Pincode_TXT.KeyDown

    End Sub

    Private Sub Gender_Combobo_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Payroll_Employee_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If Msg_Exit_YN("Employee " & VC_Type_) = DialogResult.Yes Then
                Me.Dispose()
                If VC_Type_ = "Alter_Close" Or VC_Type_ = "Create_Close" Then
                    close_focus_obj.Focus()
                End If
            End If
        End If
    End Sub
    Private Sub Payroll_Employee_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.TYP_TXT.Text = VC_Type_
        BG_frm.HADE_TXT.Text = "Payroll Employee"
        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text

        Button_Clear()
        Button_Manage()
        'Name_TXT.Focus()

        Fill_Data_Source()

    End Sub

    Private Sub Payroll_Employee_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End
        Add_Hander_Remove_Handel(False)
        Frm_foCus()
    End Sub

    Private Sub Mobile1_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Mobile1_TXT.KeyPress
        allow_Number(e)
    End Sub

    Private Sub Mobile2_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Mobile2_TXT.KeyPress
        allow_Number(e)
    End Sub

    Private Sub Father_Mobile_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Father_Mobile_TXT.KeyPress
        allow_Number(e)
    End Sub
    Private Sub Group_TXT_Enter(sender As Object, e As EventArgs) Handles Group_TXT.Enter

    End Sub
    Private Sub Group_TXT_TextChanged(sender As Object, e As EventArgs) Handles Group_TXT.TextChanged

    End Sub

    Private Sub Group_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles Group_TXT.KeyDown
        If e.KeyCode = Keys.Enter Then
            If group_list.List_Grid.CurrentRow.Cells(1).Value = "Create" Then
                Create_Group(sender)
                Exit Sub
            End If
        End If



        If e.KeyCode = Keys.C AndAlso e.Modifiers = Keys.Alt Then
            Create_Group(sender)
        ElseIf e.KeyCode = Keys.Enter AndAlso e.Modifiers = Keys.Control Then
            Cell("Payroll Group", "", "Alter_Close", group_list.List_Grid.CurrentRow.Cells(2).Value)
            Stock_Group_frm.close_focus_obj = sender
        ElseIf e.KeyCode = Keys.Enter Then
            Under_ID = group_list.List_Grid.CurrentRow.Cells(2).Value
        End If
    End Sub
    Private Function Create_Group(txt As TXT)
        Cell("Payroll Group", "", "Create_Close", "")
        With Stock_Group_frm
            .close_focus_obj = txt
            .Name_TXT.Text = txt.Text
        End With
    End Function

    Private Function Display_Fill_All()
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            Dim cmd = New SQLiteCommand("Select *,(Select [Name] From TBL_Stock_Group where ID = em.Under) as Group_Name From TBL_Payroll_Employee em where Id = '" & VC_ID_ & "' and em.Visible  = 'Approval'", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                Name_TXT.Text = r("Name").ToString
                Alias_TXT.Text = r("alias").ToString
                Discription_TXT.Text = r("Discription").ToString
                Note_TXT.Text = r("Note").ToString
                Under_ID = r("Under").ToString
                Under = r("Group_Name").ToString
                If Date_of_Joining_TXT.Text.ToString = Nothing Then
                    Date_of_Joining_TXT.Text = CDate(Now.Date)
                Else
                    Date_of_Joining_TXT.Text = CDate(r("Date_of_joining").ToString).ToString(Date_Format_fech)
                End If
                Mobile1_TXT.Text = r("Mobile1").ToString
                Mobile2_TXT.Text = r("Mobile2").ToString
                Aadhaar_TXT.Text = r("Aadhaar").ToString
                PF_TXT.Text = r("PF_No").ToString
                PAN_TXT.Text = r("PAN").ToString
                Email_TXT.Text = r("Email").ToString
                Gender_TXT.Text = r("Gender").ToString

                If r("Date_of_birth").ToString <> Nothing Then
                    Date_of_birth_TXT.Text = CDate(r("Date_of_birth").ToString).ToString(Date_Format_fech)
                End If

                Father_Name_TXT.Text = r("Father_Name").ToString
                Father_Mobile_TXT.Text = r("Father_Mobile").ToString
                Nominee_TXT.Text = r("Nominee").ToString

                Pincode_TXT.Text = r("Pincode").ToString
                State_TXT.Text = r("State").ToString
                Dis_TXT.Text = r("Dis").ToString
                Taluka_TXT.Text = r("Taluka").ToString
                Cirt_TXT.Text = r("City").ToString
                OtherAddress_TXT.Text = r("Address").ToString
                Bank_TXT.Text = r("Bank_Name").ToString
                BankBranch_TXT.Text = r("Bank_Branch").ToString
                Bank_IFSC_TXT.Text = r("Bank_IFSC_code").ToString
                BankAccount_TXT.Text = r("Bank_AccounNo").ToString


                Try
                    Logo_ = DirectCast(r("Photo"), Byte())
                Catch ex As Exception

                End Try
            End While

            If Under = Nothing Then
                Group_TXT.Text = "Primary"
            Else
                Group_TXT.Text = Under
            End If
        End If

        Dim ms As New MemoryStream
        Try
            ms = New MemoryStream(Logo_)
            PictureBox1.Image = Image.FromStream(ms)
        Catch ex As Exception

        End Try

        Fill_Attage()

        YN_Fill()
    End Function
    Private Function YN_Fill()
        If Pincode_TXT.Text.Trim = Nothing And Cirt_TXT.Text.Trim = Nothing And Taluka_TXT.Text.Trim = Nothing And Dis_TXT.Text.Trim = Nothing And State_TXT.Text.Trim = Nothing And OtherAddress_TXT.Text.Trim = Nothing Then
            Address_YN.Text = "No"
        Else
            Address_YN.Text = "Yes"
        End If

        If Bank_TXT.Text.Trim = Nothing And BankBranch_TXT.Text.Trim = Nothing And Bank_IFSC_TXT.Text.Trim = Nothing And BankAccount_TXT.Text.Trim = Nothing Then
            Bank_details_YN.Text = "No"
        Else
            Bank_details_YN.Text = "Yes"
        End If

        If Aadhaar_TXT.Text.Trim = Nothing And PAN_TXT.Text.Trim = Nothing And PF_TXT.Text.Trim = Nothing And Nominee_TXT.Text.Trim = Nothing Then
            Seatutory_YN.Text = "No"
        Else
            Seatutory_YN.Text = "Yes"
        End If

        Dim img As Image = PictureBox1.Image
        If img IsNot Nothing Then
            Photo_YN.Text = "Yes"
        Else
            Photo_YN.Text = "No"
        End If
    End Function

    Private Function Fill_Attage()
        If open_MSSQL(Database_File.rec) = True Then
            DataGridView1.Rows.Clear()
            qury = "Select * From TBL_Attage where TBL = 'Employee' and TBL_ID = '" & VC_ID_ & "' and Visible = 'Approval'"
            cmd = New SQLiteCommand(qury, con)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                DataGridView1.Rows.Add(r("ID"), r("Name"), r("Narration"), r("Attage_Type"), r("Attage"), r("Password"))
            End While
        End If
    End Function

    Private Sub BankAccount_TXT_TextChanged(sender As Object, e As EventArgs) Handles BankAccount_TXT.TextChanged

    End Sub
    Private Function Name_aLlow() As Boolean
        If BG_frm.From_ID = From_ID Then
            If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
                Duplicate_Type = "Name  = '" & Name_TXT.Text & "' and " & Company_Visible_Filter()
            Else
                Duplicate_Type = "Name  = '" & Name_TXT.Text & "' and ID <> '" & VC_ID_ & "' and " & Company_Visible_Filter()
            End If

            If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
                Duplicate_Type1 = "Alias  = '" & Name_TXT.Text & "' and " & Company_Visible_Filter()
            Else
                Duplicate_Type1 = "Alias  = '" & Name_TXT.Text & "' and ID <> '" & VC_ID_ & "' and " & Company_Visible_Filter()
            End If

            If Name_TXT.Text = "" Then
                NOT_("Not Valid Without a Blank 'Name'", NOT_Type.Warning)
                Return False
                Exit Function
            End If

            If Chack_Duplicate(Database_File.cre, "TBL_Payroll_Employee", "Name", Duplicate_Type) = True Then
                NOT_("The Name Entered is a 'Duplicate'", NOT_Type.Warning)
                Return False
                Exit Function
            ElseIf Chack_Duplicate(Database_File.cre, "TBL_Payroll_Employee", "Alias", Duplicate_Type1) = True And Alias_TXT.Text <> Nothing Then
                NOT_("The Name Entered is a 'Duplicate'", NOT_Type.Warning)
                Return False
                Exit Function
            Else
                NOT_Clear()
                Return True
            End If
        End If
        Return True
    End Function

    Private Sub Name_TXT_Enter(sender As Object, e As EventArgs) Handles Name_TXT.Enter
        Name_aLlow()
    End Sub
    Private Sub Name_TXT_TextChanged(sender As Object, e As EventArgs) Handles Name_TXT.TextChanged
        Name_aLlow()
    End Sub
    Private Sub Name_TXT_LostFocus(sender As Object, e As EventArgs) Handles Name_TXT.LostFocus
        If Name_aLlow() = False Then
            Name_TXT.Focus()
        End If
    End Sub
    Private Function Alias_aLlow() As Boolean
        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            Duplicate_Alias_Type = " Name  = '" & Alias_TXT.Text & "'"
        Else
            Duplicate_Alias_Type = " Name  = '" & Alias_TXT.Text & "' and ID <> '" & VC_ID_ & "'"
        End If

        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            Duplicate_Alias_Type1 = " Alias  = '" & Alias_TXT.Text & "'"
        Else
            Duplicate_Alias_Type1 = " Alias  = '" & Alias_TXT.Text & "' and ID <> '" & VC_ID_ & "'"

        End If
        If Alias_TXT.Text <> "" Then
            If Name_TXT.Text = Alias_TXT.Text Then
                NOT_("Name and Alias is Sam", NOT_Type.Warning)
                Return False
                Exit Function
            End If

            If Chack_Duplicate(Database_File.cre, "TBL_Payroll_Employee", "Alias", Duplicate_Alias_Type) = True Then
                NOT_("The Alias Entered is a 'Duplicate'", NOT_Type.Warning)
                Return False
                Exit Function
            ElseIf Chack_Duplicate(Database_File.cre, "TBL_Payroll_Employee", "Name", Duplicate_Alias_Type1) = True Then
                NOT_("The Alias Entered is a 'Duplicate'", NOT_Type.Warning)
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
        Alias_aLlow()
    End Sub
    Private Sub Alias_TXT_TextChanged(sender As Object, e As EventArgs) Handles Alias_TXT.TextChanged
        Alias_aLlow()
    End Sub
    Private Sub Alias_TXT_LostFocus(sender As Object, e As EventArgs) Handles Alias_TXT.LostFocus
        If Alias_aLlow() = False Then
            Alias_TXT.Focus()
        End If
    End Sub

    Private Sub Date_of_Joining_TXT_Enter(sender As Object, e As EventArgs) Handles Date_of_Joining_TXT.Enter
        Date_of_Joining_TXT_TextChanged(e, e)
    End Sub
    Private Sub Date_of_Joining_TXT_TextChanged(sender As Object, e As EventArgs) Handles Date_of_Joining_TXT.TextChanged

    End Sub
    Private Sub Date_of_Joining_TXT_LostFocus(sender As Object, e As EventArgs) Handles Date_of_Joining_TXT.LostFocus
        Date_of_Joining_TXT.Text = Date_Formate(Date_of_Joining_TXT.Text)
        If Date_of_Joining_TXT.Text = "" Then
            Date_of_Joining_TXT.Text = ""
        End If

        If Date_Brack(Date_of_Joining_TXT.Text) = False Then
            Date_of_Joining_TXT.Text = ""
            Exit Sub
        End If

    End Sub

    Private Sub Email_TXT_Enter(sender As Object, e As EventArgs) Handles Email_TXT.Enter
        If Formate_Email(Email_TXT.Text) = True Then
            NOT_Clear()
        Else
            NOT_("The email format you entered is incorrect", NOT_Type.Warning)
        End If
    End Sub
    Private Sub Email_TXT_TextChanged(sender As Object, e As EventArgs) Handles Email_TXT.TextChanged
        If Formate_Email(Email_TXT.Text) = True Then
            NOT_Clear()
        Else
            NOT_("The email format you entered is incorrect", NOT_Type.Warning)
        End If
    End Sub

    Private Sub Date_of_birth_TXT_Enter(sender As Object, e As EventArgs) Handles Date_of_birth_TXT.Enter
        Date_of_birth_TXT_TextChanged(e, e)
    End Sub
    Private Sub Date_of_birth_TXT_TextChanged(sender As Object, e As EventArgs) Handles Date_of_birth_TXT.TextChanged
        Dim st As String = Date_of_birth_TXT.Text
        st = Date_Formate(Date_of_birth_TXT.Text)
        If st <> "" Then
            Label19.Text = DateDiff(DateInterval.Year, CDate(Date_of_birth_TXT.Text), CDate(Now.Date.ToString("dd-MM-yyyy")))
            Label19.Text &= " Year Old"
            If Val(Label19.Text) >= 18 Then
                Label19.ForeColor = Color.Green
            Else
                Label19.ForeColor = Color.Red
            End If
        Else
            Label19.ForeColor = Color.Black
            Label19.Text = ""
        End If
    End Sub
    Private Sub Date_of_birth_TXT_LostFocus(sender As Object, e As EventArgs) Handles Date_of_birth_TXT.LostFocus
        If Date_of_birth_TXT.Text = "" Then
            'Date_of_birth_TXT.Focus()
            Return
        End If

        Date_of_birth_TXT.Text = Date_Formate(Date_of_birth_TXT.Text)
        If Date_of_birth_TXT.Text = "" Then
            Date_of_birth_TXT.Focus()
        End If
    End Sub

    Private Sub Bank_IFSC_TXT_Enter(sender As Object, e As EventArgs) Handles Bank_IFSC_TXT.Enter
        If Formate_IFSC(Bank_IFSC_TXT.Text) = True Then
            NOT_Clear()
        Else
            NOT_("The IFSC Code format you entered is incorrect", NOT_Type.Warning)
        End If
    End Sub
    Private Sub Bank_IFSC_TXT_TextChanged(sender As Object, e As EventArgs) Handles Bank_IFSC_TXT.TextChanged
        If Formate_IFSC(Bank_IFSC_TXT.Text) = True Then
            NOT_Clear()
        Else
            NOT_("The IFSC Code format you entered is incorrect", NOT_Type.Warning)
        End If
    End Sub

    Private Sub Group_TXT_LostFocus(sender As Object, e As EventArgs) Handles Group_TXT.LostFocus
        Under_ID =
        Under = Find_DT_Value(Database_File.cre, "TBL_Stock_Group", "Name", "ID = '" & Under_ID & "'")
    End Sub

    Private Sub Aadhaar_TXT_LostFocus(sender As Object, e As EventArgs) Handles Aadhaar_TXT.LostFocus

        If Aadhaar_TXT.Text.Trim <> Nothing Then
            If Aadhaar_TXT.Text.Length <> 14 Then
                Msg(NOT_Type.Info, "incomplete information - Aadhaar", "Please complit fill aadhaar card number")
                sender.Focus()
                Return
            End If
            If Chack_Duplicate(Database_File.cre, "TBL_Payroll_Employee", "Aadhaar", "Aadhaar = '" & Aadhaar_TXT.Text & "' and Visible = 'Approval' and ID <> '" & Val(VC_ID_) & "'") = True Then
                Msg(NOT_Type.Info, "Duplicate Details - Aadhaar", "The Aadhaar number you have entered is already entered by another employee")
                Aadhaar_TXT.Focus()
            End If
        End If
    End Sub

    Private Sub PAN_TXT_TextChanged(sender As Object, e As EventArgs) Handles PAN_TXT.TextChanged
        PAN_aLlow()
    End Sub
    Private Function PAN_aLlow() As Boolean
        If Formate_PAN(PAN_TXT.Text) = True Then
            NOT_Clear()
            Return True
        Else
            Return False
            NOT_("The PAN No. format you entered is incorrect", NOT_Type.Warning)
        End If
    End Function
    Private Sub PAN_TXT_LostFocus(sender As Object, e As EventArgs) Handles PAN_TXT.LostFocus
        If PAN_aLlow() = False Then
            sender.Text = ""
        Else
            If Chack_Duplicate(Database_File.cre, "TBL_Payroll_Employee", "PAN", "PAN = '" & PAN_TXT.Text & "' and Visible = 'Approval' and ID <> '" & Val(VC_ID_) & "'") = True Then
                Msg(NOT_Type.Info, "Duplicate Details - PAN", "The PAN number you have entered is already entered by another employee")
                PAN_TXT.Focus()
            End If
        End If
    End Sub

    Private Sub Yn1_TextChanged(sender As Object, e As EventArgs) Handles Address_YN.TextChanged
        If sender.Text = "Yes" Then
            Panel26.Visible = True
        Else
            Panel26.Visible = False
        End If
    End Sub

    Private Sub Bank_details_YN_TextChanged(sender As Object, e As EventArgs) Handles Bank_details_YN.TextChanged
        If sender.Text = "Yes" Then
            Panel14.Visible = True
        Else
            Panel14.Visible = False
        End If
    End Sub

    Private Sub Yn1_TextChanged_1(sender As Object, e As EventArgs) Handles Seatutory_YN.TextChanged
        If sender.Text = "Yes" Then
            Panel32.Visible = True
        Else
            Panel32.Visible = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim OpenFile As New OpenFileDialog()
        Try
            With OpenFile
                .FileName = ""
                .Title = "LOGO:"
                '.Filter = "Company Logo : (*.png)|*.png"
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    'Logo_ = Byte_(.FileName)
                    Me.PictureBox1.Image = System.Drawing.Image.FromFile(.FileName)
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Error...")
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Photo_YN_TextChanged(sender As Object, e As EventArgs) Handles Photo_YN.TextChanged
        If sender.Text = "Yes" Then
            Panel37.Visible = True
        Else
            Panel37.Visible = False
        End If
    End Sub

    Private Sub Aadhaar_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles Aadhaar_TXT.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TAB_TXT_TextChanged(sender As Object, e As EventArgs) Handles TAB_TXT.TextChanged

    End Sub

    Private Sub TAB_TXT_Enter(sender As Object, e As EventArgs) Handles TAB_TXT.Enter
        Dim result As DialogResult = Msg_Save_YN(Name_TXT, "Employee")

        If result = DialogResult.Yes Then
            Save_Data()
        ElseIf result = DialogResult.No Then
            Name_TXT.Focus()
        ElseIf result = DialogResult.Cancel Then
            SendKeys.Send("{BACKSPACE}")
        End If



        'If Msg_Yn("Save ?", "") = DialogResult.Yes Then
        '    Yn1.Focus()
        '    Save_Data()
        'Else
        '    Name_TXT.Focus()
        'End If
    End Sub

    Private Sub Yn1_TextChanged_2(sender As Object, e As EventArgs) Handles Yn1.TextChanged

    End Sub

    Private Sub Yn1_KeyDown(sender As Object, e As KeyEventArgs) Handles Yn1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Yn1.Text = "Yes" Then
                If VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close" Then
                    Cell("Salary Details", "", "Employee wise", VC_ID_)
                    Payroll_Salary_details_frm.Focus()
                    Payroll_Salary_details_frm.close_link_yn = True
                    Payroll_Salary_details_frm.close_focus_obj = sender
                    'Payroll_Salary_details_frm.ShowDialog()

                    AddHandler Payroll_Salary_details_frm.Disposed, AddressOf Salary_Details_Disposed
                End If
            End If
        End If
    End Sub
    Public Sub Salary_Details_Disposed(sender As Object, e As EventArgs)
        'Me.Yn1.Text = "No"
        'Me.Yn1.Focus()
        Frm_foCus()


        SendKeys.Send("{TAB}")
    End Sub

    Private Sub Gender_TXT_TextChanged(sender As Object, e As EventArgs) Handles Gender_TXT.TextChanged

    End Sub

    Private Sub Yn1_LostFocus(sender As Object, e As EventArgs) Handles Yn1.LostFocus

    End Sub

    Private Sub Label61_Click(sender As Object, e As EventArgs) Handles Label61.Click
        Cell("Salary Details", "", "Employee wise", VC_ID_)
        Payroll_Salary_details_frm.Focus()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        With webCam_frm
            If .ShowDialog() = DialogResult.Yes Then
                PictureBox1.Image = .img
                'Logo_ = ImageToByteArray(PictureBox1.Image)
            End If
        End With
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        PictureBox1.Image = Nothing
    End Sub

    Private Sub Payroll_Employee_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
    End Sub
End Class