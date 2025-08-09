Imports System.ComponentModel
Imports System.IO
Imports Microsoft.Win32
Imports Tools

Public Class BG_Head_frm
    Private Sub BG_Head_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Panel3.Dock = DockStyle.Fill

        CMP_TXT.Text = Company_Name_str
        Panel3.Width = Me.Width
        Dim frm1 As New BG_frm
        With BG_frm
            .Dock = DockStyle.Fill
            .TopLevel = False
            Panel3.Controls.Add(BG_frm)
        End With
        LOAD_TOP_Manu()

        ProgressBag_Custom1.Maximum = 60

        Version_Label.Text = $"V{My.Application.Info.Version.ToString}"
    End Sub
    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

        'If Label4.Enabled = True Then
        Top_Panel_Manag(Company_Manu)
        Dim ctlpos As Point = Label4.PointToScreen(New Point(0, 0))
        Company_Manu.Location = New Point(ctlpos.X, ctlpos.Y + Label4.Height + 2)

        Company_Manu.Focus()
        'End If
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        If Label1.Enabled = True Then
            Top_Panel_Manag(Data_Manu)
            Dim ctlpos As Point = Label1.PointToScreen(New Point(0, 0))
            Data_Manu.Location = New Point(ctlpos.X, ctlpos.Y + Label1.Height + 2)

            Data_Manu.Focus()
        End If
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        If Label2.Enabled = True Then
            Top_Panel_Manag(System_Manu)
            Dim ctlpos As Point = Label2.PointToScreen(New Point(0, 0))
            System_Manu.Location = New Point(ctlpos.X, ctlpos.Y + Label2.Height + 2)
            System_Manu.Focus()
        End If
    End Sub

    Private Sub BG_Head_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F1 AndAlso e.Modifiers = Keys.Alt Then

        ElseIf e.KeyCode = Keys.F1 AndAlso e.Modifiers = Keys.Control Then

        ElseIf e.KeyCode = Keys.F1 Then
            Label6_Click(e, e)
        End If

        If e.KeyCode = Keys.D1 AndAlso e.Modifiers = Keys.Alt Then
            Label3_Click(e, e)
        ElseIf e.KeyCode = Keys.D1 AndAlso e.Modifiers = Keys.Control Then

        ElseIf e.KeyCode = Keys.D1 Then
        End If
        If e.KeyCode = Keys.K AndAlso e.Modifiers = Keys.Alt Then
            Label4_Click(e, e)
        End If
        If e.KeyCode = Keys.Y AndAlso e.Modifiers = Keys.Alt Then
            Label1_Click(e, e)
        End If
        If e.KeyCode = Keys.Z AndAlso e.Modifiers = Keys.Alt Then
            Label2_Click(e, e)
        End If
        If e.KeyCode = Keys.F AndAlso e.Modifiers = Keys.Alt Then
            Label12_Click(e, e)
        End If
        If e.KeyCode = Keys.N AndAlso e.Modifiers = Keys.Alt Then

        End If
        If e.KeyCode = Keys.Q AndAlso e.Modifiers = Keys.Alt Then

        End If
        If e.KeyCode = Keys.O AndAlso e.Modifiers = Keys.Alt Then

        End If

        If e.KeyCode = Keys.F4 AndAlso e.Modifiers = Keys.Control Then

        End If
        If e.KeyCode = Keys.F11 Then
            FetchersCompany()
        End If
    End Sub

    Private Function Top_Panel_Manag(Pan As Object)
        Panel3.Hide()
        Company_Manu.Hide()
        Data_Manu.Hide()
        System_Manu.Hide()
        Help_Manu.Hide()
        Package_Menu.Hide()

        Pan.Show()
    End Function
    Private Function LOAD_TOP_Manu()
        With Company_Manu
            .Add_Group("MASTERS")

            Dim nm As String() = .Add_Item("Create Company", True, 17)
            AddHandler .Find_Particuls(nm(0), nm(1)).Click, AddressOf CreateCompany
            AddHandler .Find_txt(nm(0), nm(1)).KeyDown, AddressOf CreateCompany_Keydown

            nm = .Add_Item("Alteration Company", True, 17)
            AddHandler .Find_Particuls(nm(0), nm(1)).Click, AddressOf AlterCompany
            AddHandler .Find_txt(nm(0), nm(1)).KeyDown, AddressOf AlterCompany_Keydown

            nm = .Add_Item("Select Company", True, 17)
            AddHandler .Find_Particuls(nm(0), nm(1)).Click, AddressOf SelectCompany
            AddHandler .Find_txt(nm(0), nm(1)).KeyDown, AddressOf SelectCompany_Keydown

            nm = .Add_Item("Import Company", True, 17)
            AddHandler .Find_Particuls(nm(0), nm(1)).Click, AddressOf ImportCompany
            AddHandler .Find_txt(nm(0), nm(1)).KeyDown, AddressOf ImportCompany_Keydown

            .Add_Group("SECURITY")

            nm = .Add_Item("Company User", True, 17)
            AddHandler .Find_Particuls(nm(0), nm(1)).Click, AddressOf UserCompany
            AddHandler .Find_txt(nm(0), nm(1)).KeyDown, AddressOf UserCompany_Keydown

            .Add_Group("CONFIGURATION")
            nm = .Add_Item("Features", True, 17)
            AddHandler .Find_Particuls(nm(0), nm(1)).Click, AddressOf FetchersCompany
            AddHandler .Find_txt(nm(0), nm(1)).KeyDown, AddressOf FetchersCompany_Keydown

        End With

        With Data_Manu
            .Add_Group("COMPANY DATA")

            Dim nm As String() = .Add_Item("Backup", True, 17)
            AddHandler .Find_Particuls(nm(0), nm(1)).Click, AddressOf BackupData
            AddHandler .Find_txt(nm(0), nm(1)).KeyDown, AddressOf BackupData_Keydown

            nm = .Add_Item("Restore", True, 17)
            AddHandler .Find_Particuls(nm(0), nm(1)).Click, AddressOf RestoreData
            AddHandler .Find_txt(nm(0), nm(1)).KeyDown, AddressOf RestoreData_Keydown
        End With

        With System_Manu
            .Add_Group("SYSTEM")

            Dim nm As String() = .Add_Item("System Update", True, 17)
            AddHandler .Find_Particuls(nm(0), nm(1)).Click, AddressOf SystemUpdateSystem
            AddHandler .Find_txt(nm(0), nm(1)).KeyDown, AddressOf SystemUpdate_Keydown

        End With


        With Help_Manu
            .Add_Group("")

            Dim nm As String() = .Add_Item("Website", True, 17)
            AddHandler .Find_Particuls(nm(0), nm(1)).Click, AddressOf Website_Help
            AddHandler .Find_txt(nm(0), nm(1)).KeyDown, AddressOf Website_Help_Keydown

            nm = .Add_Item("About", True, 17)
            AddHandler .Find_Particuls(nm(0), nm(1)).Click, AddressOf About_Help
            AddHandler .Find_txt(nm(0), nm(1)).KeyDown, AddressOf About_Help_Keydown

            nm = .Add_Item("FeedBank", True, 17)
            AddHandler .Find_Particuls(nm(0), nm(1)).Click, AddressOf Feedbank_Help
            AddHandler .Find_txt(nm(0), nm(1)).KeyDown, AddressOf Feedbank_Help_Keydown

            nm = .Add_Item("Features", True, 17)
            AddHandler .Find_Particuls(nm(0), nm(1)).Click, AddressOf Features_Help
            AddHandler .Find_txt(nm(0), nm(1)).KeyDown, AddressOf Features_Help_Keydown

            nm = .Add_Item("AnyDesk", True, 17)
            AddHandler .Find_Particuls(nm(0), nm(1)).Click, AddressOf AnyDesk_Help
            AddHandler .Find_txt(nm(0), nm(1)).KeyDown, AddressOf AnyDesk_Help_Keydown
        End With

        With Package_Menu
            .Add_Group("Installed Package")
            Pckage_()
        End With

    End Function
    Private Function AnyDesk_Help()
        Process.Start($"{Application.StartupPath}\AnyDesk.exe")

        Top_Panel_Manag(Panel3)
        Frm_foCus()
    End Function
    Private Function AnyDesk_Help_Keydown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            AnyDesk_Help()
        End If

        If e.KeyCode = Keys.Escape Then
            Top_Panel_Manag(Panel3)
            Frm_foCus()
        End If
    End Function
    Private Function Features_Help()
        FetchersCompany()

        Top_Panel_Manag(Panel3)
        Frm_foCus()
    End Function
    Private Function Features_Help_Keydown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Features_Help()
        End If

        If e.KeyCode = Keys.Escape Then
            Top_Panel_Manag(Panel3)
            Frm_foCus()
        End If
    End Function
    Private Function Feedbank_Help()
        Cell("Feedbank", "", "Create", "")

        Top_Panel_Manag(Panel3)
        Frm_foCus()
    End Function
    Private Function Feedbank_Help_Keydown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Feedbank_Help()
        End If

        If e.KeyCode = Keys.Escape Then
            Top_Panel_Manag(Panel3)
            Frm_foCus()
        End If
    End Function
    Private Function About_Help()

    End Function
    Private Function About_Help_Keydown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            About_Help()
        End If

        If e.KeyCode = Keys.Escape Then
            Top_Panel_Manag(Panel3)
            Frm_foCus()
        End If
    End Function
    Private Function Website_Help()
        Process.Start("https://cryptonixtechnology.in/")

        Top_Panel_Manag(Panel3)
        Frm_foCus()
    End Function
    Private Function Website_Help_Keydown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Website_Help()
        End If

        If e.KeyCode = Keys.Escape Then
            Top_Panel_Manag(Panel3)
            Frm_foCus()
        End If
    End Function
    Private Function CreateCompany()
        Cell("Company Information", "", "Create", "")
        Top_Panel_Manag(Panel3)
        Company_Creation_frm.Class_Select.Focus()
    End Function
    Private Function CreateCompany_Keydown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            CreateCompany()
        End If

        If e.KeyCode = Keys.Escape Then
            Top_Panel_Manag(Panel3)
            Frm_foCus()
        End If
    End Function

    Private Function AlterCompany()
        Login_Frm.Dispose()
        Cell("Login", "", "Alteration Company")
        Top_Panel_Manag(Panel3)
    End Function
    Private Function AlterCompany_Keydown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            AlterCompany()
        End If

        If e.KeyCode = Keys.Escape Then
            Top_Panel_Manag(Panel3)
            Frm_foCus()
        End If
    End Function
    Private Function SelectCompany()
        Cell("Company Select", "", "", "")
        Top_Panel_Manag(Panel3)
        Select_Company_frm.Search_TXT.Focus()
    End Function
    Private Function SelectCompany_Keydown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            SelectCompany()
        End If

        If e.KeyCode = Keys.Escape Then
            Top_Panel_Manag(Panel3)
            Frm_foCus()
        End If
    End Function

    Private Function ImportCompany()
        Cell("Import Company", "", "Create", "")
        Top_Panel_Manag(Panel3)
    End Function
    Private Function ImportCompany_Keydown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            ImportCompany()
        End If

        If e.KeyCode = Keys.Escape Then
            Top_Panel_Manag(Panel3)
            Frm_foCus()
        End If
    End Function
    Private Function UserCompany()
        Cell("User Info.", "", "", "")
        Top_Panel_Manag(Panel3)
        Frm_foCus()
    End Function
    Private Function UserCompany_Keydown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            UserCompany()
        End If

        If e.KeyCode = Keys.Escape Then
            Top_Panel_Manag(Panel3)
            Frm_foCus()
        End If
    End Function
    Private Function FetchersCompany()
        If Login_YN = True Then
            Top_Panel_Manag(Panel3)
            Cell("Company Features")
        Else
            Msg(NOT_Type.Info, "Login", "Please login comapny and try again")
        End If
    End Function
    Private Function FetchersCompany_Keydown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            FetchersCompany()
        End If

        If e.KeyCode = Keys.Escape Then
            Top_Panel_Manag(Panel3)
            Frm_foCus()
        End If
    End Function


    Private Function BackupData()
        Cell("Backup Database", "", "", "")
        Top_Panel_Manag(Panel3)
        Backup_db_frm.Path_TXT.Focus()
    End Function
    Private Function BackupData_Keydown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            BackupData()
        End If

        If e.KeyCode = Keys.Escape Then
            Top_Panel_Manag(Panel3)
            Frm_foCus()
        End If
    End Function

    Private Function RestoreData()
        If Login_YN = True Then
            Cell("Restore Database", "", "", "")
            Top_Panel_Manag(Panel3)
            Restore_db_frm.Path_TXT.Focus()
            'e.Handled = True
        Else
            Msg_Custom_YN(NOT_Location.Center, Color.OrangeRed, My.Resources.Warning_animation_icn, Dialoag_Button.Ok, "Warning", "Login Company", "Please login company<nl>and try again")
        End If
    End Function
    Private Function RestoreData_Keydown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            RestoreData()
        End If

        If e.KeyCode = Keys.Escape Then
            Top_Panel_Manag(Panel3)
            Frm_foCus()
        End If
    End Function


    Private Function SystemUpdateSystem()
        Cell("System Update", "", "", "")
        Top_Panel_Manag(Panel3)
        System_Update_Frm.Button1.Focus()
    End Function
    Private Function SystemUpdate_Keydown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            SystemUpdateSystem()
        End If

        If e.KeyCode = Keys.Escape Then
            Top_Panel_Manag(Panel3)
            Frm_foCus()
        End If
    End Function

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

        If Msg_Custom_YN(NOT_Location.Center, Color.Red, My.Resources.Exit_animation_icn, Dialoag_Button.Yes_No, "Question?", "Exit Application", "are you sure exit this application") = DialogResult.Yes Then
            Application.Exit()
            Try
                'whatsapp_drv.Dispose()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        If Search_Manu_frm.ShowDialog() <> DialogResult.Abort Then
            Frm_foCus()
        End If
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        If Label6.Enabled = True Then
            Top_Panel_Manag(Help_Manu)
            Dim ctlpos As Point = Label6.PointToScreen(New Point(0, 0))
            Help_Manu.Location = New Point(ctlpos.X, ctlpos.Y + Label6.Height + 5)
            Help_Manu.Focus()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label10.Text = TimeOfDay.ToString("hh:mm:ss tt")
        Label9.Text = Now.Date.ToString("dddd") & ", " & Now.Date.ToString("dd-MM-yyyy")

        ProgressBag_Custom1.Value = TimeOfDay.ToString("ss")
        ProgressBag_Custom1.Run(0)



        'Label6.Enabled = Login_YN
        Label1.Enabled = Login_YN
        PictureBox3.Visible = Login_YN
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        'License_LInk_frm.ShowDialog()
        Dim Succ As Boolean = False
        Using key As RegistryKey = Registry.ClassesRoot.OpenSubKey("Cryptonix\shell\open\command")
            Dim subKeyNames() As String = key.GetSubKeyNames()
            Dim valueNames() As String = key.GetValueNames()
            For Each valueName As String In valueNames
                Dim value As Object = key.GetValue(valueName)
                If File.Exists(value.ToString.Replace(" ""%1""", "").Replace("""", "")) Then
                    Succ = True
                    Process.Start("cryptonix://license_details")
                End If
            Next
        End Using
        If Succ = False Then
            Install_Setup_manager_dialoag.ShowDialog()
        End If
    End Sub

    Private Sub communication_grid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        'Calculator.Show()

        With Calculator
            .TopLevel = False
            BG_frm.BG_PAN.Controls.Add(Calculator)
            .Dock = DockStyle.Left
            .Show()
            .BringToFront()
            .Focus()
        End With
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        With Lock_frm
            .TopLevel = False
            Me.Controls.Add(Lock_frm)
            .Dock = DockStyle.Fill
            .Show()
            .BringToFront()
            .Focus()
        End With
    End Sub

    Private Sub Help_Manu_Load(sender As Object, e As EventArgs) Handles Help_Manu.Load

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        If Label3.Enabled = True Then
            Top_Panel_Manag(Package_Menu)
            Dim ctlpos As Point = Label3.PointToScreen(New Point(0, 0))
            Package_Menu.Location = New Point(ctlpos.X, ctlpos.Y + Label3.Height + 5)
            Package_Menu.Focus()
        End If
    End Sub
    Private Function Pckage_()
        Dim Succ As Boolean = False
        Using key As RegistryKey = Registry.ClassesRoot.OpenSubKey("Cryptonix\Install.Path")
            Dim subKeyNames() As String = key.GetSubKeyNames()
            Dim valueNames() As String = key.GetValueNames()
            For Each valueName As String In valueNames
                Dim value As Object = key.GetValue(valueName)
                If File.Exists(valueName) Then
                    If value <> "001" Then
                        Dim Cur_v As String = FileVersionInfo.GetVersionInfo(valueName).FileVersion.ToString
                        Dim Name_ As String = Find_Software_Details(value.ToString, "Name")
                        Dim L_Version As String = Find_Software_Details(value.ToString, "System_Version")

                        With Package_Menu
                            Try
                                Dim nm As String() = .Add_Item(Name_, True, 17)
                                .Find_Particuls(nm(0), nm(1)).Tag = valueName
                                AddHandler .Find_Particuls(nm(0), nm(1)).Click, AddressOf Package_Run
                                AddHandler .Find_txt(nm(0), nm(1)).KeyDown, AddressOf Package_Run_Keydown
                            Catch ex As Exception

                            End Try
                        End With
                    End If
                Else
                    Dim regKey As RegistryKey = Registry.ClassesRoot.CreateSubKey("Cryptonix\Install.Path")
                    regKey.DeleteValue(valueName)
                End If
            Next
        End Using
    End Function
    Private Sub Package_Run(sender As Object, e As EventArgs)
        Process.Start(sender.Tag)


        Top_Panel_Manag(Panel3)
        Company_Creation_frm.Class_Select.Focus()
    End Sub
    Private Sub Package_Run_Keydown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Process.Start(Package_Menu.Find_Particuls(Package_Menu.Find_Idx(sender), Package_Menu.Find_Idx2(sender)).Tag)

            Top_Panel_Manag(Panel3)
            Company_Creation_frm.Class_Select.Focus()
        End If

        If e.KeyCode = Keys.Escape Then
            Top_Panel_Manag(Panel3)
            Frm_foCus()
        End If
    End Sub
End Class