Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Data.SQLite
Imports System.IO
Imports Microsoft.Win32

Public Class Splash_Screen_frm
    Dim issu As Boolean
    Private Sub Splash_Screen_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If File.Exists($"{Application.StartupPath}\exit.txt") Then
            File.Delete($"{Application.StartupPath}\exit.txt")
        End If
        Install_Registry()

        Dim date_form As String = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern()
        If date_form = "dd-MM-yyyy" Or date_form = "dd/MM/yyyy" Then
        Else
            If Msg_Custom_YN(NOT_Location.Center, Color.OrangeRed, My.Resources.datetime_animation_gif, Dialoag_Button.Yes_No, "Question", "Date Format !", "Your system's date format is not valid for this software,<nl>do you want the software to set a valid date format?") = DialogResult.Yes Then
                Date_Formate_Change()
                Application.Exit()
                Process.Start(Application.StartupPath & "\Management.exe")
            Else
                Application.Exit()
            End If
        End If

        'Load_URL_Data()




        'Date_Formate_Change()

        Timer1.Start()
        Date_3 = Now.Date.ToString("dd-MM-yyyy")
        Old_Version = My.Application.Info.Version.ToString
        Label3.Text = "System Version : " & Old_Version
        Me.Icon = My.Resources.Erp_icn
        Spacial_report_path()
        _other_savefiles_path()

    End Sub
    Private Function Load_URL_Data()
        Dim args As String() = Environment.GetCommandLineArgs()
        Dim urlArgument As String = args(1)
        Try
            Dim uri As New Uri(urlArgument)
            Dim data As String = uri.Host
            MessageBox.Show("Data received from URL: " & data)
        Catch ex As UriFormatException
            MessageBox.Show("An invalid URL was passed: " & urlArgument)
        End Try
    End Function

    Private Function Date_Formate_Change()
        Dim key As RegistryKey = Registry.CurrentUser.OpenSubKey("Control Panel\International", True)
        key.SetValue("sShortDate", "dd-MM-yyyy")
    End Function
    Dim Old_Version As String
    Dim New_Version As String
    Dim New_Description As String
    Dim New_Link As String
    Dim New_Update_YN As Boolean
    Dim Head_ As String

    Private Function _other_savefiles_path()
        Dim path As String = Application.StartupPath & "\_other_savefiles"
        If Chck_Directry(path) = True Then
            For Each filepath As String In Directory.GetFiles(path)
                File.Delete(filepath)
            Next
        Else
            Directory.CreateDirectory(path)
        End If
    End Function
    Private Function Spacial_report_path()
        Dim path As String = Application.StartupPath & "\Spacial Report"
        If Chck_Directry(path) = False Then
            Directory.CreateDirectory(path)
        End If

    End Function
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim cmmd As New SqlCommand
        Dim cn As New SqlConnection
        Status_Label.Text = "Chacking..."
        Status_Label.ForeColor = Color.SaddleBrown
        If Chack_cfg_Database() = True Then
            If Online_MSSQL(cn) = True Then
                Status_Label.Text = "Online"
                Status_Label.ForeColor = Color.Green

                Head_ = "Check Update..."
                Label4.ForeColor = Color.Green
                BackgroundWorker1.ReportProgress(1)
                cmmd = New SqlCommand("Select System_Version,Description,Update_Link,Compulsory_YN From TBL_Update_Manager where System_Code = '001'", cn)
                Dim r As SqlDataReader
                r = cmmd.ExecuteReader
                While r.Read
                    New_Version = r("System_Version").ToString
                    New_Description = r("Description").ToString
                    New_Link = r("Update_Link").ToString
                    New_Update_YN = YN_Boolean(r("Compulsory_YN").ToString)
                End While
                r.Close()
                cmmd = New SqlCommand("Select * From TBL_Admin", cn)
                r = cmmd.ExecuteReader
                Head_ = "Parameters Install.."
                BackgroundWorker1.ReportProgress(2)
                While r.Read
                    If r("Str1") = "Smtp Server" Then
                        Send_Email = r("Str2").ToString
                        Send_Email_Password = r("Str3").ToString
                    ElseIf r("Str1") = "Whatsapp" Then
                        Wh_Admin_API = r("Str2").ToString
                        Wh_Admin_No = r("Str3").ToString
                    End If
                End While
                r.Close()
                Head_ = "Check License Details..."
                BackgroundWorker1.ReportProgress(3)
                cmmd = New SqlCommand($"Select License,Device_Name From TBL_License_Device where Device_ID = '{Computer_Serial()}'", cn)
                r = cmmd.ExecuteReader
                While r.Read
                    LC_ID_str = r("License").ToString
                    Device_Name_str = r("Device_Name").ToString
                End While
                r.Close()



                Head_ = "License Install.."
                BackgroundWorker1.ReportProgress(3)
                cmmd = New SqlCommand($"Select License,Fill_Name,Phone,Email,Status,Exp_Date,(SELECT DATEADD(MINUTE, 90, GETDATE()) AS vlu) as Time_ From TBL_License where License = '{LC_ID_str}'", cn)
                r = cmmd.ExecuteReader
                While r.Read
                    LC_ID_str = r("License").ToString
                    'Device_Name_str = r("Device_Name").ToString
                    LC_Name = r("Fill_Name").ToString
                    LC_Phone = r("Phone").ToString
                    LC_Email = r("Email").ToString
                    LC_Status = r("Status").ToString
                    LC_Expir = CDate(r("Exp_Date").ToString)
                    LC_Timer = (DateDiff(DateInterval.Second, CDate(r("Time_").ToString), CDate(LC_Expir)))

                End While
                r.Close()
                'End If

                cmmd = New SqlCommand($"UPDATE TBL_License_Device SET Version = '{My.Application.Info.Version.ToString}',Last_Login = SYSDATETIME() WHERE Device_ID = '{Computer_Serial()}'", cn)
                cmmd.ExecuteReader()
            Else
                Next_diaload = Msg_Custom_YN(NOT_Location.Center, Color.Red, My.Resources.PC_Error_animation_icn, Dialoag_Button.Retry_Cancel, "Error", $"Connection Error", $"An error occurred connecting the software to the server<nl>1). Check the internet connection.<nl>2). Check system update.<nl>3). Contact the company")
                Status_Label.Text = "Connection Error"
                Status_Label.ForeColor = Color.Red
                Exit Sub
        End If

        Next_diaload = DialogResult.OK

        Dim cn_l As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cfgs, cn_l) = True Then
            cmd = New SQLiteCommand("Select * From TBL_dft_Company_Details", cn_l)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                Company_Name_str = r("Name")
                Connection_Path = r("path")
                Connection_Data = r("cmp_id") & ".dt"
                Company_ID_str = r("cmp_id")
                End While
                r.Close()
            End If


            If Directory.Exists(Connection_Path & "\" & Connection_Data) Then
                issu = True
            Else
                issu = False
            End If
        End If
    End Sub

    Dim Next_diaload As DialogResult


    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        License_Count_frm.Show()
        License_Count_frm.Hide()

        If Next_diaload = DialogResult.OK Then
            If LC_ID_str = "NA" Or LC_ID_str = Nothing Then
                License_LInk_frm.Panel_Manage(License_LInk_frm.Not_Found)
                If License_LInk_frm.ShowDialog() = DialogResult.Yes Then
                    BackgroundWorker1.RunWorkerAsync()
                Else
                    Me.Dispose()
                End If
            Else
                BG_Head_frm.Show()
                BG_Head_frm.CMP_TXT.Text = Company_Name_str
                If issu = True Then
                    Cell("Login", "", "Login Company")
                    My.Computer.Audio.Play(My.Resources.Welcome_Sound, AudioPlayMode.Background)
                Else
                    My.Computer.Audio.Play(My.Resources.Welcome_Sound, AudioPlayMode.Background)
                    Cell("Company Select", "", "Company Select", "")
                    Select_Company_frm.Search_TXT.Text = Application.StartupPath & "\Data"
                    Frm_foCus()
                End If
                Me.Hide()
                If Old_Version <> New_Version Then
                    If New_Version <> My.Settings.Update_Ignore_Version Then
                        Cell("System Update", "", "", "")
                    End If
                End If
            End If

        ElseIf Next_diaload = DialogResult.Retry Then
            BackgroundWorker1.RunWorkerAsync()
        Else
            Application.Exit()
        End If
    End Sub

    Private Function Chack_cfg_Database() As Boolean
        Try
            Dim cn As New SQLiteConnection
            Dim cmd As SQLiteCommand
                        If open_MSSQL_Cstm(Database_File.cfgs, cn) = True Then
                cmd = New SQLiteCommand($"SELECT name FROM sqlite_master WHERE type='table' AND name = 'TBL_Features'", cn)
                Dim r As SQLiteDataReader
                r = cmd.ExecuteReader
                Dim exist_ As Boolean = False
                While r.Read
                    If r("name") = "TBL_Features" Then
                        exist_ = True
                    End If
                End While
                r.Close()

                If exist_ = False Then
                    cmd = New SQLiteCommand("CREATE TABLE 'TBL_Features' (
	'Id'	INTEGER NOT NULL UNIQUE,
	'Head'	TEXT,
	'Value'	TEXT,
	'Discription'	TEXT,
	'Type'	TEXT,
	PRIMARY KEY('Id' AUTOINCREMENT)
);", cn)
                    cmd.ExecuteNonQuery()
                End If
                cn.Close()
            End If
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
    Dim tim As Integer = 2
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        tim -= 1
        If tim <= 0 Then
            Label4.Text = "Connecting to Cryptonix Server"
            BackgroundWorker1.RunWorkerAsync()
            Timer1.Stop()
            'PictureBox2.Image = My.Resources.Loding_Progress
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        Panel1.Location = New Point(Me.ClientSize.Width / 2 - Panel1.Size.Width / 2, Me.ClientSize.Height / 2 - Panel1.Size.Height / 2)
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        Label4.Text = Head_
    End Sub
    Private Function Install_Registry()
        Dim regKey As RegistryKey = Nothing
        regKey = Registry.ClassesRoot.CreateSubKey("Cryptonix\Install.Path")
        regKey.SetValue($"{Application.ExecutablePath}", "001", RegistryValueKind.String)
        regKey.Close()
    End Function

    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs) Handles Panel5.Paint
        obj_center(sender, Me)
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub
End Class