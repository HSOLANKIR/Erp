Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Data.SQLite
Imports System.IO
Imports Tools

Public Class Fill_Data_Loading
    Dim From_ID As String
    Dim Path_End As String
    Private Sub Fill_Data_Loading_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        obj_center(Import_Company_Data_Panel, Me)

        Path_End = BG_frm.BG_Path_TXT.Text

        BG_frm.HADE_TXT.Text = "Load Data"
        BG_frm.TYP_TXT.Text = ""



        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub Fill_Data_Loading_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.HADE_TXT.Text = "Load Data"
        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text

        Button_Clear()
    End Sub

    Private Sub Fill_Data_Loading_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        'BG_frm.BG_Path_TXT.Text = Path_End
        Frm_foCus()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cmp, cn) = True Then
            Label1.Text = "Chack Company Features"
            Fill_Fichars(cn)
            BackgroundWorker1.ReportProgress(20)
            Label1.Text = "Chack Company Details"
            Fill_User_Device(cn)
            BackgroundWorker1.ReportProgress(50)
            Label1.Text = "Save Company Details"
            Fill_Company_data()
            BackgroundWorker1.ReportProgress(60)
            Label1.Text = "Save Device & Login Details"
            TBL_Login_Details()
            BackgroundWorker1.ReportProgress(70)
            Label1.Text = "Save Company Printing Data"
            Compamy_Print_Data_INstall()
            BackgroundWorker1.ReportProgress(90)

        End If
    End Sub

    Private Function Fill_Company_data()
        Company_Icn = Nothing
        Company_stmp = Nothing
        Company_sig = Nothing
        Dim cn As New SqlConnection
        If Online_MSSQL(cn) = True Then
            qury = $"SELECT * FROM TBL_Company_Creation Where ID = '{Company_ID_str}'"
            Dim cmd As New SqlCommand(qury, cn)
            cmd.ExecuteNonQuery()
            Dim red As SqlDataReader = cmd.ExecuteReader
            While red.Read
                Try
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
                    Company_GST_Type_str = red("GST_Type").ToString

                    Company_Server_str = (red("Server_Name").ToString)
                    Company_Server_Database_str = (red("Server_Database").ToString)
                    Company_Server_UserName_str = (red("Server_UserName").ToString)
                    Company_Server_Password_str = (red("Server_Password").ToString)

                    Dim ms As New MemoryStream
                    Try
                        Dim data As Byte() = DirectCast(red("Photo"), Byte())
                        ms = New MemoryStream(data)
                        Company_Icn = Image.FromStream(ms)

                        If Login_Type_str = "Admin Account" Then
                            User_Icn = Image.FromStream(ms)
                        End If
                    Catch ex As Exception

                    End Try

                    Try
                        Dim data_stmp As Byte() = DirectCast(red("Stamp"), Byte())
                        ms = New MemoryStream(data_stmp)
                        Company_stmp = Image.FromStream(ms)
                    Catch ex As Exception

                    End Try

                    Try
                        Dim data_sig As Byte() = DirectCast(red("Signatory"), Byte())
                        ms = New MemoryStream(data_sig)
                        Company_sig = Image.FromStream(ms)
                    Catch ex As Exception

                    End Try
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End While
            red.Close()
        End If


        Try
            Dim cn_o = New SQLiteConnection
            If open_MSSQL_Cstm(Database_File.cmp, cn_o) = True Then
                Dim q As String = "UPDATE TBL_Company_Creation SET CompanyName = @CompanyName,Book_Frm = @Book_Frm,Address = @Address,GSTNo = @GSTNo,GST_Type = @GST_Type,PANCard = @PANCard,Email = @Email,Phone = @Phone,PinCode = @PinCode,Country = @Country,State = @State,District = @District,Taluk = @Taluk,City = @City,Bank = @Bank,Branch = @Branch,AccountNo = @AccountNo,IFCCode = @IFCCode,UPI = @UPI,Approval = @Approval,Server_Name = @Server_Name,Server_Database = @Server_Database,Server_UserName = @Server_UserName,Server_Password = @Server_Password where ID <> '0'"
                cmd = New SQLiteCommand(q, cn_o)
                With cmd.Parameters
                    .AddWithValue("@CompanyName", Company_Name_str.ToString.Trim)
                    .AddWithValue("@Book_Frm", CDate(Company_Book_frm))
                    .AddWithValue("@Address", Company_Address_str.ToString.Trim)
                    .AddWithValue("@GSTNo", Company_GST_str.ToString.Trim)
                    .AddWithValue("@GST_Type", Company_GST_Type_str.ToString.Trim)
                    .AddWithValue("@PANCard", Company_PAN_str.ToString.Trim)
                    .AddWithValue("@Email", Company_Email_str.ToString.Trim)
                    .AddWithValue("@Phone", Company_Phone_str.ToString.Trim)
                    .AddWithValue("@PinCode", Company_Pincode_str.ToString.Trim)
                    .AddWithValue("@Country", "India")
                    .AddWithValue("@State", Company_State_str.ToString.Trim)
                    .AddWithValue("@District", "")
                    .AddWithValue("@Taluk", "")
                    .AddWithValue("@City", Company_City_str.ToString.Trim)
                    .AddWithValue("@Bank", Company_Bank_Name_str.ToString.Trim)
                    .AddWithValue("@Branch", Company_Bank_Branch_str.ToString.Trim)
                    .AddWithValue("@AccountNo", Company_Bank_Account_No_str.ToString.Trim)
                    .AddWithValue("@IFCCode", Company_Bank_IFSC_Code_str.ToString.Trim)
                    .AddWithValue("@UPI", Company_UPI_str.ToString.Trim)
                    .AddWithValue("@Approval", Company_Ststus_str.ToString.Trim)

                    .AddWithValue("@Server_Name", Company_Server_str.ToString.Trim)
                    .AddWithValue("@Server_Database", Company_Server_Database_str.ToString.Trim)
                    .AddWithValue("@Server_UserName", Company_Server_UserName_str.ToString.Trim)
                    .AddWithValue("@Server_Password", Company_Server_Password_str.ToString.Trim)

                    cmd.ExecuteNonQuery()
                End With
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Private Function TBL_Login_Details()
        Dim iscreate As Boolean = True

        Dim cn = New SQLiteConnection
        open_MSSQL_Cstm(Database_File.cmp, cn)

        cmd = New SQLiteCommand($"SELECT name FROM sqlite_master WHERE type='table' AND name='TBL_Login_Details'", cn)
        Dim r As SQLiteDataReader = cmd.ExecuteReader
        While r.Read
            iscreate = False
        End While
        r.Close()

        If iscreate = True Then
            cmd = New SQLiteCommand(cmp_Login_Details, cn)
            cmd.ExecuteNonQuery()
        End If

        cmd = New SQLiteCommand("DELETE FROM TBL_Login_Details", cn)
        cmd.ExecuteNonQuery()

        cmd = New SQLiteCommand("INSERT INTO TBL_Login_Details (ID,Type,UserName,FullName,Email,Phone) VALUES (@ID,@Type,@UserName,@FullName,@Email,@Phone)", cn)
        With cmd.Parameters
            If Login_Type_str = "User Account" Then
                .AddWithValue("@ID", User_ID)
                .AddWithValue("@FullName", User_Full_Name)
                .AddWithValue("@Email", User_Email)
                .AddWithValue("@Phone", User_Phone)
            Else
                .AddWithValue("@ID", Company_ID_str)
                .AddWithValue("@FullName", Company_Name_str)
                .AddWithValue("@Email", Company_Email_str)
                .AddWithValue("@Phone", Company_Phone_str)
            End If
            .AddWithValue("@UserName", User_Name)
            .AddWithValue("@Type", Login_Type_str)
            cmd.ExecuteNonQuery()

        End With
    End Function
    Private Function Compamy_Print_Data_INstall()
        Dim ds As New Print_dt
        Dim dr As DataRow

        Print_DT_Company = ds.Tables("TBL_cmp")
        dr = Print_DT_Company.NewRow
        dr("CompanyName") = Company_Name_str
        dr("CompanyAddress") = Company_Address_str
        dr("CompanyEmail") = Company_Email_str
        dr("CompanyPhone") = Company_Phone_str
        dr("CompanyGST") = Company_GST_str
        dr("CompanyPAN") = Company_PAN_str
        dr("CompanyBankName") = Company_Bank_Name_str
        dr("CompanyBankAccount") = Company_Bank_Account_No_str
        dr("CompanyBankBrabch") = Company_Bank_Branch_str
        dr("CompanyBankIFSC") = Company_Bank_IFSC_Code_str
        dr("Reg_No") = Company_RegNo_str
        dr("City") = Company_City_str

        Try
            'Company_Logo
            If IsNothing(Company_Icn) Then

            Else

                Dim img As Image
                img = Company_Icn
                Dim img_stm As System.IO.MemoryStream = New System.IO.MemoryStream
                img.Save(img_stm, System.Drawing.Imaging.ImageFormat.Png)
                Dim LOGO As Byte()
                LOGO = img_stm.GetBuffer
                dr("LOGO") = LOGO
            End If
        Catch ex As Exception
        End Try

        Try
            'Company_Stamp
            If IsNothing(Company_stmp) Then

            Else
                Dim stmp_ As Image
                stmp_ = Company_stmp

                Dim stmp_stm As System.IO.MemoryStream = New System.IO.MemoryStream
                stmp_.Save(stmp_stm, System.Drawing.Imaging.ImageFormat.Png)
                Dim STMP As Byte()
                STMP = stmp_stm.GetBuffer
                dr("Stamp") = STMP
            End If
        Catch ex As Exception

        End Try

        Try
            If IsNothing(Company_sig) Then
            Else
                'Company_Sig
                Dim sig_ As Image
                sig_ = Company_sig
                Dim sig_stm As System.IO.MemoryStream = New System.IO.MemoryStream
                sig_.Save(sig_stm, System.Drawing.Imaging.ImageFormat.Png)
                Dim SIG As Byte()
                SIG = sig_stm.GetBuffer
                dr("Signature") = SIG
            End If
        Catch ex As Exception

        End Try

        Print_DT_Company.Rows.Add(dr)
    End Function
    Private Function Fill_Fichars(cn As SQLiteConnection)
        'Fill Company Fichars
        cmd = New SQLiteCommand("Select * From TBL_Features", cn)
        Dim r As SQLiteDataReader
        r = cmd.ExecuteReader
        While r.Read
            Dim Head As String = r("Head").ToString
            Dim Vlu As String = r("Value").ToString
            Dim dec As String = r("Discription").ToString
            Fill_Features_Mod(Head, Vlu, dec)
        End While
        r.Close()

        'Fill Device Fichars
        Dim cnn As New SQLiteConnection
        open_MSSQL_Cstm(Database_File.cfgs, cnn)
        cmd = New SQLiteCommand("Select * From TBL_Features", cnn)
        r = cmd.ExecuteReader
        While r.Read
            Dim Head As String = r("Head").ToString
            Dim Vlu As String = r("Value").ToString
            Dim dec As String = r("Discription").ToString
            Fill_Features_Mod(Head, Vlu, dec)
        End While
        r.Close()

    End Function
    Private Function Fill_User_Device(cn As SQLiteConnection)
        cmd = New SQLiteCommand("DELETE FROM TBL_User", cn)
        cmd.ExecuteNonQuery()

        cmd = New SQLiteCommand("DELETE FROM TBL_Device", cn)
        cmd.ExecuteNonQuery()


        Dim cn_on As New SqlConnection
        If Online_MSSQL(cn_on) = True Then
            Dim cm As New SqlCommand("Select * From TBL_Login where CompanySerial = '" & Company_ID_str & "'", cn_on)
            Dim r_ As SqlDataReader
            r_ = cm.ExecuteReader
            While r_.Read
                Dim id_ As String = r_("ID")
                Dim User_ As String = r_("UserName")
                Dim Name_ As String = r_("FristName") & "" & r_("MiddleName") & " " & r_("LastName")
                Dim Phone_ As String = r_("Phone")
                Dim E_mail_ As String = r_("Email")

                cmd = New SQLiteCommand(String.Format("INSERT INTO TBL_User (User_ID,UserName,Name,Phone,Email) VALUES ('{0}','{1}','{2}','{3}','{4}')", id_, User_, Name_, Phone_, E_mail_), cn)
                cmd.ExecuteNonQuery()
            End While
            r_.Close()

            'device Details
            cm = New SqlCommand("Select * From TBL_Device_Details where Serial = '" & Company_Serial_str & "'", cn_on)
            r_ = cm.ExecuteReader
            While r_.Read
                Dim id_ As String = r_("ID")
                Dim Name_ As String = r_("Name")
                Dim PC_Name As String = r_("ComputerName")
                Dim Type_ As String = r_("Device")

                cmd = New SQLiteCommand(String.Format("INSERT INTO TBL_Device (Device_ID,name,PC_Name,Type) VALUES ('{0}','{1}','{2}','{3}')", id_, Name_, PC_Name, Type_), cn)
                cmd.ExecuteNonQuery()
            End While
        End If

    End Function

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        ProgressBar1.Value = (e.ProgressPercentage)
        ProgressBar1.Run(0)

        Label9.Text = $"{N2_FORMATE((Val(e.ProgressPercentage) * 100) / Val(ProgressBar1.Maximum))} %"
    End Sub
    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        'Main_Frm.Dispose()

        If Company_Class_str = "Hospital" And Login_Type_str = "User Account" Then
            Dim pth As String = Application.StartupPath & "\Spacial Report\Hospital.menu"
            If My.Computer.FileSystem.DirectoryExists(pth) Then
                With Spacial_Report_Opning_frm
                    .path = $"{pth}\Program.exe"
                    .Show()
                End With
            Else
                Msg_Custom_YN(NOT_Location.Center, Color.Red, My.Resources.package_gif, Dialoag_Button.Ok, "Package", "Package is not install", "You cannot log in because<nl>the hospital management package<nl>is not installed in your software.")
                Application.Exit()
            End If
        Else
            With Main_Frm
                .TopLevel = False
                BG_frm.BG_PAN.Controls.Add(Main_Frm)
                .Show()
                .Dock = DockStyle.Fill
                .BringToFront()
            End With
        End If

        BG_Head_frm.CMP_TXT.Text = Company_Name_str

        If Communication_YN = True Then
            Whatsapp_Sending_list.Show()
            Whatsapp_Sending_list.Hide()
        End If
        Me.Dispose()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs)

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)
        obj_center(sender, Me)
    End Sub

    Private Sub ProgressBar2_Load(sender As Object, e As EventArgs)

    End Sub

    Private Sub Fill_Data_Loading_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
    End Sub

    Private Sub Import_Company_Data_Panel_Paint(sender As Object, e As PaintEventArgs) Handles Import_Company_Data_Panel.Paint
        obj_center(Import_Company_Data_Panel, Me)
    End Sub
End Class