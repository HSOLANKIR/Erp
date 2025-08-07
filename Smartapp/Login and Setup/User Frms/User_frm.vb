Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Data.SQLite
Imports System.IO

Public Class User_frm
    Dim From_ID As String
    Dim issuccess As Boolean
    Dim Path_End As String
    Dim VC_Type_ As String
    Dim VC_ID_ As String
    Dim Branch_ID As String

    Private Sub User_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text

        VC_Type_ = Link_Valu(1)
        VC_ID_ = Link_Valu(2)



        BG_frm.HADE_TXT.Text = "User Information"
        BG_frm.TYP_TXT.Text = VC_Type_

        Load_data_source()
        List_set()

        If VC_Type_ = "Display" Or VC_Type_ = "Display_Close" Then
            Display_Fill_All()
            Me.Enabled = False
        ElseIf VC_Type_ = "Alter" Then
            Me.Enabled = True
            Display_Fill_All()

        ElseIf VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
        End If


        Button_Manage()
        Add_Hander_Remove_Handel(True)
        F_Name_TXT.Focus()
    End Sub
    Private Function Display_Fill_All()
        Panel1.Visible = False
        Panel6.Visible = True

        BackgroundWorker1.RunWorkerAsync()
    End Function
    Dim branch_list As List_frm
    Private Function List_set()
        branch_list = New List_frm
        List_Setup("List of Branch", Select_List.Botom, Select_List_Format.Singel, Branch_TXT, branch_list, Branch_Source, Branch_TXT.Width)


    End Function
    Private Function Load_data_source()
        Dim cn As New SQLiteConnection

        Dim dt As New DataTable
        dt.Columns.Add("Name")
        dt.Columns.Add("Alias")
        dt.Columns.Add("ID")

        dt.Rows.Add("Primary", "", "0")
        If open_MSSQL_Cstm(Database_File.cre, cn) Then
            cmd = New SQLiteCommand("Select * From TBL_Ledger ld where ld.Visible = 'Approval' and ld.[Group] = '7'", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                dt.Rows.Add(r("Name"), r("Alise"), r("ID"))
            End While
        End If
        Branch_Source.DataSource = dt


        dt = New DataTable
        dt.Columns.Add("Name")
        If Company_Class_str = "Hospital Management" Then
            dt.Rows.Add("Cash")
            dt.Rows.Add("Doctor")
        End If

        Designation_Source.DataSource = dt
    End Function
    Private Sub User_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.TYP_TXT.Text = VC_Type_
        BG_frm.HADE_TXT.Text = "User Information"

        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text

        Load_data_source()

        Branch_Panel.Visible = Branch_Visible()

        Button_Clear()
        Button_Manage()
        F_Name_TXT.Focus()
    End Sub

    Private Sub User_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End
        Add_Hander_Remove_Handel(False)
        Frm_foCus()
    End Sub
    Private Function Button_Manage()
        Button_Clear()
        BG_frm.B_1.Text = "&S : Save"
        BG_frm.R_22.Text = "F12 : Configuration"
    End Function
    Private Function Add_Hander_Remove_Handel(Ans As Boolean)
        If Ans = True Then
            AddHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            AddHandler BG_frm.R_22.Click, AddressOf Me.R_22_Click
        Else
            RemoveHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            RemoveHandler BG_frm.R_22.Click, AddressOf Me.R_22_Click
        End If
    End Function
    Private Sub R_22_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            User_Raids_frm.Path_End = BG_frm.BG_Path_TXT.Text
            Cell("User Configuration", VC_ID_)
        End If
    End Sub
    Private Sub B_1_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Save_Date()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim OpenFile As New OpenFileDialog()
        Try
            With OpenFile
                .FileName = ""
                .Title = "Photo:"
                '.Filter = "User Photo : (*.png)|*.png"
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    Me.PictureBox1.Image = System.Drawing.Image.FromFile(.FileName)
                End If
            End With
        Catch ex As Exception

        End Try
    End Sub
    Private Function Save_Date()

        If F_Name_TXT.Text = "" Then
            'Msg(NOT_Type.Erro, "Input Error - Frist Name", "Please enter Frist Name and Try again")
            Msg_InputError(F_Name_TXT, "Frist Name")

            F_Name_TXT.Focus()
            Exit Function
        End If

        If M_Name_TXT.Text = "" Then
            'Msg(NOT_Type.Erro, "Input Error - Middle Name", "Please enter Middle Name and Try again")
            Msg_InputError(M_Name_TXT, "Middle Name")
            M_Name_TXT.Focus()
            Exit Function
        End If

        If L_Name_TXT.Text = "" Then
            'Msg(NOT_Type.Erro, "Input Error - Last Name", "Please enter Last Name and Try again")
            Msg_InputError(L_Name_TXT, "Last Name")
            L_Name_TXT.Focus()
            Exit Function
        End If

        If User_TXT.Text = "" Then
            'Msg(NOT_Type.Erro, "Input Error - UserName", "Please enter UserName and Try again")
            Msg_InputError(User_TXT, "UserName")
            User_TXT.Focus()
            Exit Function
        End If

        If Chack_Duplicate_User() = True Then
            'Msg(NOT_Type.Erro, "Duplicate - UserName", "Username is not allow, please change username and try agin")
            Msg_Duplicat(User_TXT, "UserName")
            User_TXT.Focus()
            Exit Function
        End If

        If Password_TXT.Text = "" Then
            'Msg(NOT_Type.Erro, "Input Error - Password", "Please enter Password and Try again")
            Msg_InputError(Password_TXT, "Password")
            Password_TXT.Focus()
            Exit Function
        End If

        If Password_TXT.Text <> Conform_Password_TXT.Text Then
            'Msg(NOT_Type.Erro, "Password not match", "Password is not match Please enter the correct password")
            Msg_InputError(Conform_Password_TXT, "Password")
            Password_TXT.Text = ""
            Conform_Password_TXT.Focus()
            Exit Function
        End If

        If Phone_TXT.Text = "" Then
            'Msg(NOT_Type.Erro, "Input Error - Phone", "Please enter Phone and Try again")
            Msg_InputError(Phone_TXT, "Phone")
            Phone_TXT.Focus()
            Exit Function
        End If

        If Email_TXT.Text = "" Then
            'Msg(NOT_Type.Erro, "Input Error - Email", "Please enter Email and Try again")
            Msg_InputError(Email_TXT, "Email")
            Email_TXT.Focus()
            Exit Function
        End If

        If Date_Of_Birt_TXT.Text = "" Then
            'Msg(NOT_Type.Erro, "Input Error - Date of Birth", "Please enter Date of Birth and Try again")
            Msg_InputError(Date_Of_Birt_TXT, "Date of Birth")
            Date_Of_Birt_TXT.Focus()
            Exit Function
        End If

        If Branch_TXT.Text = "" And Branch_Panel.Visible = True Then
            Msg_InputError(Branch_TXT, "Branch")
            'Msg(NOT_Type.Erro, "Input Error - Branch", "Please enter Branch and Try again")
            Branch_TXT.Focus()
            Exit Function
        End If

        If Branch_Panel.Visible = True Then
            'If Chack_Duplicate(Database_File.cre, "TBL_Ledger", "Name", "(Name  Like N'" & Branch_TXT.Text & "')") = False Then
            '    Msg(NOT_Type.Erro, "Selection Error - Branch", "Branch select error, Please select again")
            '    Branch_TXT.Focus()
            '    Return False
            '    Exit Function
            'Else
            '    Branch_ID = Find_DT_Value(Database_File.cre, "TBL_Ledger", "ID", " Name Like N'" & Branch_TXT.Text & "'")
            'End If
        End If



        Dim Emial_info As String = $"{F_Name_TXT.Text} {M_Name_TXT.Text} {L_Name_TXT.Text}"

        If Email_Verification("User Email Verification", "", Email_TXT.Text, "User Email Verification", Emial_info, 500) = DialogResult.Yes Then
            'If VC_Type_ = "Create" Then
            If Insurt_Dat_Online() = True Then
                'Msg(NOT_Type.Success, "Successfuly Create", "User is Succussfuly Created")
                Msg_Custom_YN(NOT_Location.Bottom_Right, Color.Green, My.Resources.Success_animation_icn, Dialoag_Button.Ok, "Information", "Success", $"{User_TXT.Text}<nl>Successfully Save User Details")
                Clear_()
            End If
            'End If
        End If
    End Function
    Private Function Clear_()
        F_Name_TXT.Text = ""
        M_Name_TXT.Text = ""
        L_Name_TXT.Text = ""

        User_TXT.Text = ""
        Password_TXT.Text = ""
        Conform_Password_TXT.Text = ""
        Phone_TXT.Text = ""
        Email_TXT.Text = ""
        Date_Of_Birt_TXT.Text = ""
        Address_TXT.Text = ""
        Branch_TXT.Text = ""
        PictureBox1.Image = Nothing
        F_Name_TXT.Focus()

        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
        Else
            Me.Dispose()
        End If
    End Function
    Private Function Insurt_Dat_Online() As Boolean
        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            Dim ms As New MemoryStream
            Dim img As Image = PictureBox1.Image
            If img IsNot Nothing Then
                qury = "INSERT INTO TBL_Login  (UserName,Password,FristName,MiddleName,LastName,DOB,Email,Phone,Address,Photo,CompanySerial,Branch,Approval) VALUES (@UserName,@Password,@FristName,@MiddleName,@LastName,@DOB,@Email,@Phone,@Address,@Photo,@CompanySerial,@Branch,@Approval)"
            Else
                qury = "INSERT INTO TBL_Login (UserName,Password,FristName,MiddleName,LastName,DOB,Email,Phone,Address,CompanySerial,Branch,Approval) VALUES (@UserName,@Password,@FristName,@MiddleName,@LastName,@DOB,@Email,@Phone,@Address,@CompanySerial,@Branch,@Approval)"
            End If
            Dim cn As New SqlConnection
            If Online_MSSQL(cn) = True Then
                Try
                    Dim cmd As New SqlCommand(qury, cn)
                    With cmd.Parameters
                        .AddWithValue("@FristName", F_Name_TXT.Text.Trim)
                        .AddWithValue("@MiddleName", M_Name_TXT.Text.Trim)
                        .AddWithValue("@LastName", L_Name_TXT.Text.Trim)
                        .AddWithValue("@UserName", User_TXT.Text.Trim)
                        .AddWithValue("@Password", Password_TXT.Text.Trim)
                        .AddWithValue("@DOB", CDate(Date_Of_Birt_TXT.Text))
                        .AddWithValue("@Email", Email_TXT.Text.Trim)
                        .AddWithValue("@Phone", Phone_TXT.Text.Trim)
                        .AddWithValue("@Address", Address_TXT.Text.Trim)
                        .AddWithValue("@CompanySerial", Company_ID_str)
                        .AddWithValue("@Approval", "Approval".Trim)

                        If Branch_Panel.Visible = True Then
                            .AddWithValue("@Branch", Branch_ID)
                        Else
                            .AddWithValue("@Branch", "0")
                        End If

                        If img IsNot Nothing Then
                            Dim bitmap As New Bitmap(img)
                            bitmap.Save(ms, Imaging.ImageFormat.Png)
                            Dim dat As Byte() = ms.GetBuffer
                            .AddWithValue("@Photo", SqlDbType.Image).Value = dat
                        End If
                        cmd.ExecuteNonQuery()
                        Save_Raids(cn)

                        Return True
                    End With
                Catch ex As Exception
                    Msg(NOT_Type.Erro, "Error Save User", ex.Message)
                    Return False
                End Try
            End If
            Return True
        Else
            Dim ms As New MemoryStream
            Dim img As Image = PictureBox1.Image
            If img IsNot Nothing Then
                qury = $"UPDATE TBL_Login SET UserName = @UserName,Password = @Password,FristName = @FristName,MiddleName = @MiddleName,LastName = @LastName,DOB = @DOB,Email = @Email,Phone = @Phone,Address = @Address,Photo = @Photo,CompanySerial = @CompanySerial,Branch = @Branch,Approval = @Approval where ID = '{VC_ID_}'"
            Else
                qury = $"UPDATE TBL_Login SET UserName = @UserName,Password = @Password,FristName = @FristName,MiddleName = @MiddleName,LastName = @LastName,DOB = @DOB,Email = @Email,Phone = @Phone,Address = @Address,CompanySerial = @CompanySerial,Branch = @Branch,Approval = @Approval where ID = '{VC_ID_}'"
            End If
            Dim cn As New SqlConnection
            If Online_MSSQL(cn) = True Then
                Try
                    Dim cmd As New SqlCommand(qury, cn)
                    With cmd.Parameters
                        .AddWithValue("@FristName", F_Name_TXT.Text.Trim)
                        .AddWithValue("@MiddleName", M_Name_TXT.Text.Trim)
                        .AddWithValue("@LastName", L_Name_TXT.Text.Trim)
                        .AddWithValue("@UserName", User_TXT.Text.Trim)
                        .AddWithValue("@Password", Password_TXT.Text.Trim)
                        .AddWithValue("@DOB", CDate(Date_Of_Birt_TXT.Text))
                        .AddWithValue("@Email", Email_TXT.Text.Trim)
                        .AddWithValue("@Phone", Phone_TXT.Text.Trim)
                        .AddWithValue("@Address", Address_TXT.Text.Trim)
                        .AddWithValue("@CompanySerial", Company_ID_str.Trim)
                        .AddWithValue("@Approval", "Approval".Trim)

                        If Branch_Panel.Visible = True Then
                            .AddWithValue("@Branch", Branch_ID)
                        Else
                            .AddWithValue("@Branch", "0")
                        End If

                        If img IsNot Nothing Then
                            Dim bitmap As New Bitmap(img)
                            bitmap.Save(ms, Imaging.ImageFormat.Png)
                            Dim dat As Byte() = ms.GetBuffer
                            .AddWithValue("@Photo", SqlDbType.Image).Value = dat
                        End If
                        cmd.ExecuteNonQuery()

                        Save_Raids(cn)
                        Return True
                    End With
                Catch ex As Exception
                    Msg(NOT_Type.Erro, "Error Save User", ex.Message)
                    Return False
                End Try
            End If
            Return True
        End If
    End Function
    Private Function Save_Raids(cn As SqlConnection)
        Dim cmd_o As SqlCommand

        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            cmd_o = New SqlCommand($"Select lo.ID From TBL_Login lo where lo.UserName Like N'{User_TXT.Text}' and CompanySerial Like N'{Company_ID_str}'", cn)
            Dim r As SqlDataReader
            r = cmd_o.ExecuteReader
            While r.Read
                VC_ID_ = r("ID")
            End While
            r.Close()
        End If


        cmd_o = New SqlCommand($"DELETE FROM TBL_User_Authority WHERE User_ID = '{VC_ID_}'", cn)
        cmd_o.ExecuteNonQuery()

        For Each ro As DataGridViewRow In DataGridView1.Rows
            Dim head As String = ro.Cells(0).Value
            Dim vlu As String = ro.Cells(1).Value
            cmd_o = New SqlCommand($"INSERT INTO TBL_User_Authority (User_ID,Head, Value) VALUES ('{VC_ID_}','{head}','{vlu}')", cn)
            cmd_o.ExecuteNonQuery()
        Next
    End Function
    Private Sub User_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If Msg_Exit_YN("User " & VC_Type_) = DialogResult.Yes Then
                Me.Dispose()
            End If
        End If
        If e.KeyCode = Keys.F12 Then
            BG_frm.R_22.PerformClick()
        End If
    End Sub
    Private Function Chack_Duplicate_User() As Boolean
        Dim cn As New SqlConnection
        Dim cmmd As New SqlCommand

        If Online_MSSQL(cn) = True Then
            cmmd = New SqlCommand($"Select * From TBL_Login where CompanySerial Like N'{Company_ID_str }' and UserName Like N'{User_TXT.Text }' and ID <> '{VC_ID_}'", cn)
            Dim r As SqlDataReader
            r = cmmd.ExecuteReader
            While r.Read
                Return True
            End While
            r.Close()

            cmmd = New SqlCommand($"Select * From TBL_Company_Creation where ID Like N'{Company_ID_str}' and UserName Like N'{User_TXT.Text}'", cn)
            r = cmmd.ExecuteReader
            While r.Read
                Return True
            End While
            Return False
        End If
    End Function

    Private Sub Phone_TXT_TextChanged(sender As Object, e As EventArgs) Handles Phone_TXT.TextChanged

    End Sub

    Private Sub Phone_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Phone_TXT.KeyPress
        allow_Number(e)
    End Sub
    Private Sub Branch_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles Branch_TXT.KeyDown
        If e.KeyCode = Keys.Enter Then
            Branch_ID = branch_list.List_Grid.CurrentRow.Cells(2).Value.ToString
        End If
    End Sub

    Private Sub Branch_TXT_TextChanged(sender As Object, e As EventArgs) Handles Branch_TXT.TextChanged

    End Sub

    Private Sub Panel6_Paint(sender As Object, e As PaintEventArgs) Handles Panel6.Paint
        obj_center(sender, Panel9)
    End Sub
    Dim F_nm As String
    Dim m_nm As String
    Dim l_nm As String
    Dim U_nm As String
    Dim pas_ As String
    Dim dob_ As Date
    Dim eml_ As String
    Dim ph_ As String
    Dim add_ As String
    Dim brch_ As String
    Dim Photo_() As Byte

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim cn As New SqlConnection
        If Online_MSSQL(cn) = True Then
            Dim cmd_o = New SqlCommand($"Select * From TBL_Login where ID = '{VC_ID_ }'", cn)
            Dim r As SqlDataReader
            r = cmd_o.ExecuteReader
            While r.Read
                F_nm = r("FristName").ToString
                m_nm = r("MiddleName").ToString
                l_nm = r("LastName").ToString
                U_nm = r("UserName").ToString
                pas_ = r("Password").ToString
                dob_ = CDate(r("DOB").ToString)
                eml_ = (r("Email").ToString)
                ph_ = (r("Phone").ToString)
                add_ = (r("Address").ToString)
                brch_ = (r("Branch").ToString)
                Try
                    Photo_ = DirectCast(r("Photo"), Byte())
                Catch ex As Exception
                End Try
            End While
            r.Close()


            dt_authority = New DataTable
            dt_authority.Columns.Add("Head")
            dt_authority.Columns.Add("Value")

            cmd_o = New SqlCommand($"Select * From TBL_User_Authority where User_ID = '{VC_ID_ }'", cn)
            r = cmd_o.ExecuteReader
            While r.Read
                dt_authority.Rows.Add(r("Head"), r("Value"))
            End While
            r.Close()
        End If
    End Sub
    Public dt_authority As DataTable
    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        F_Name_TXT.Text = F_nm
        M_Name_TXT.Text = m_nm
        L_Name_TXT.Text = l_nm
        User_TXT.Text = U_nm
        Password_TXT.Text = pas_
        Date_Of_Birt_TXT.Text = CDate(dob_)
        Email_TXT.Text = eml_
        Phone_TXT.Text = ph_
        Address_TXT.Text = add_
        Branch_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Name", $"ID = '{brch_}'")






        Dim ms As New MemoryStream
        Try
            ms = New MemoryStream(Photo_)
            PictureBox1.Image = Image.FromStream(ms)
        Catch ex As Exception

        End Try


        Panel1.Visible = True
        Panel6.Visible = False


        F_Name_TXT.Focus()


        DataGridView1.DataSource = dt_authority

    End Sub

    Private Sub User_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID

        F_Name_TXT.Focus()
    End Sub

    Private Sub Date_Of_Birt_TXT_TextChanged(sender As Object, e As EventArgs) Handles Date_Of_Birt_TXT.TextChanged

    End Sub

    Private Sub Date_Of_Birt_TXT_LostFocus(sender As Object, e As EventArgs) Handles Date_Of_Birt_TXT.LostFocus
        Date_Of_Birt_TXT.Text = Date_Formate(sender.Text)
    End Sub
End Class