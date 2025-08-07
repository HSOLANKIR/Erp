Imports System.ComponentModel
Imports System.Data.SQLite
Imports System.IO

Public Class Restore_db_frm
    Dim From_ID As String
    Dim red As SQLiteDataReader
    Dim DT As New DataSet
    Dim TBL As New DataTable
    Dim BS As New BindingSource
    Dim issuccess As New Boolean
    Dim Path_End As String
    Dim Path_ As String
    Private Function Button_Manage()
        Button_Clear()
        BG_frm.R_3.Text = "F3 : Create Backup"

        BG_frm.B_1.Text = "Enter : Select"

        BG_frm.HADE_TXT.Text = "Restore Database"
    End Function
    Private Function Add_Hander_Remove_Handel(Ans As Boolean)
        If Ans = True Then
            AddHandler BG_frm.KeyDown, AddressOf Me.R_1_Keedown
            AddHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            AddHandler BG_frm.R_3.Click, AddressOf Me.R_3_Click
        Else
            RemoveHandler BG_frm.KeyDown, AddressOf Me.R_1_Keedown
            RemoveHandler BG_frm.R_3.Click, AddressOf Me.R_3_Click
            RemoveHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
        End If
    End Function
    Private Sub B_1_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            If Msg_Custom_YN(NOT_Location.Bottom_Right, Color.OrangeRed, My.Resources.Database_Backu_gif, Dialoag_Button.Yes_No, "Restore Data ?", Grid1.CurrentRow.Cells(1).Value, "Are you sure<nl>you want to restore the data,<nl> data restore will automatically overwrite<nl>the data contained in the current<nl>backup file.") = DialogResult.Yes Then
                BackupPath = Grid1.Rows(3).Cells(1).Value.ToString & "\" & Grid1.CurrentRow.Cells(7).Value.ToString
                Restore_data()
            End If
        End If
    End Sub
    Public Function Restore_data()
        If Database_repair_frm.Backup_Version_Fatch(BackupPath) = True Then
            Panel_manag(Progress_Panel)
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Function
    Private BackupPath As String
    Private Sub R_3_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Cell("Backup Database")
        End If
    End Sub
    Private Sub R_1_Keedown(sender As Object, e As KeyEventArgs)
        If BG_frm.From_ID = From_ID Then
            If e.KeyCode = Keys.F3 Then
                BG_frm.R_3.PerformClick()
            End If
        End If
    End Sub
    Private Sub Select_Company_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID
        bg_Panel.Dock = DockStyle.Fill

        Button_Manage()
        Path_ = Auto_Backup_Path
        Path_End = BG_frm.BG_Path_TXT.Text

        BG_frm.HADE_TXT.Text = "Restore Database"
        'BG_frm.BG_Path_TXT.Text = "Restore Database"
        Add_Hander_Remove_Handel(True)

        'Load_()

    End Sub
    Private Function Load_()
        Refresh_Col()
        dtt.Rows.Add("", Path_, "", "", "Location")
        Drive_Folder_(Path_)
    End Function
    Private Sub List_frm_MouseWheel(sender As Object, e As MouseEventArgs) Handles Me.MouseWheel
        If e.Delta < 1 Then
            BindingSource1.MoveNext()
        Else
            BindingSource1.MovePrevious()
        End If
    End Sub
    Private Sub Select_Company_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If Msg_Exit_YN("Exit Application") = DialogResult.Yes Then
                Me.Dispose()
            End If
        End If
    End Sub
    Private Function Offline_Data() As Boolean
        DataGridView3.DataSource = Nothing
        Try
            Dim FOl As New DirectoryInfo(Path_TXT.Text)
            Dim files As New List(Of IO.DirectoryInfo)(FOl.GetDirectories("*.bk?"))

            BS.DataSource = files
            DataGridView3.DataSource = BS
        Catch ex As Exception
            'BS.Clear()
            Path_TXT.Focus()
            DataGridView3.DataSource = BS
        End Try
        If DataGridView3.Rows.Count = 0 Then
            Msg(NOT_Type.Erro, "Company Is Not Found", "")
            Path_TXT.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub Path_TXT_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Path_TXT_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Refresh_Load()
        End If
    End Sub

    Private Sub Search_TXT_TextChanged(sender As Object, e As EventArgs) Handles Path_TXT.TextChanged
        BindingSource1.Filter = $"([Backup Name] Like '%{Path_TXT.Text.Trim}%' or [Warning/Message] LIKE '%{Path_TXT.Text.Trim}%' ) or (Type = 'Defolt' or Type = 'Location')"

        If Grid1.RowCount = 4 Then
            Grid1.Rows(1).Cells(1).Value = Path_TXT.Text
            Grid1.CurrentCell = Grid1.Rows(1).Cells(1)
        Else
            Grid1.Rows(1).Cells(1).Value = ""
            If Grid1.Rows.Count > 4 Then
                Grid1.CurrentCell = Grid1.Rows(4).Cells(1)
            Else
                Grid1.CurrentCell = Grid1.Rows(0).Cells(1)
            End If
        End If
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid1.CellContentClick

    End Sub

    Private Sub DataGridView2_Enter(sender As Object, e As EventArgs) Handles Grid1.Enter
        Path_TXT.Focus()
    End Sub

    Private Sub Search_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles Path_TXT.KeyDown
        If e.KeyCode = Keys.Up Then
            BindingSource1.MovePrevious()
        End If
        If e.KeyCode = Keys.Down Then
            BindingSource1.MoveNext()
        End If
        If e.KeyCode = Keys.Enter AndAlso e.Modifiers = Keys.Control Then
            BG_frm.B_2.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Then
            If Grid1.CurrentRow.Cells(4).Value = "Defolt" Then
                If Grid1.CurrentRow.Cells(3).Value = "Create Backup" Then
                    Cell("Backup Database")
                ElseIf Grid1.CurrentRow.Cells(3).Value = "Specify Path" Then
                    Specify_path(Grid1.CurrentRow.Cells(1).Value)
                ElseIf Grid1.CurrentRow.Cells(3).Value = "Select form Drive" Then
                    Select_form_drive()
                End If
            Else
                If Grid1.CurrentRow.Cells(2).Value = "Drive" And Grid1.CurrentRow.Cells(2).Value = "Drive" Then
                    Drive_Folder_(Grid1.CurrentRow.Cells(1).Value)
                ElseIf Grid1.CurrentRow.Cells(2).Value = "Folder" Then
                    If Grid1.CurrentRow.Cells(4).Value = "Folder" Then
                        Drive_Folder_(Path_ & "\" & Grid1.CurrentRow.Cells(1).Value)
                    ElseIf Grid1.CurrentRow.Cells(4).Value = "Desktop" Then
                        Drive_Folder_(Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString)
                    ElseIf Grid1.CurrentRow.Cells(4).Value = "Documents" Then
                        Drive_Folder_(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).ToString)

                    End If

                ElseIf Grid1.CurrentRow.Cells(4).Value = "Company" Then
                    BG_frm.B_1.PerformClick()
                End If
            End If

        End If

        If e.KeyCode = Keys.Back Then
            If Path_TXT.Text = Nothing Then

                If Grid1.Rows(2).Cells(1).Value.ToString.Trim = Nothing Then
                    Dim str As String() = Path_.Split(New String() {"\"}, StringSplitOptions.None)
                    Dim cmd_ As String
                    If str.Length <> 1 Then
                        For i As Integer = 0 To str.Length - 2
                            If i = 0 Then
                                cmd_ = str(i)
                            Else
                                cmd_ &= "\" & str(i)
                            End If
                        Next
                        Drive_Folder_(cmd_)
                    Else
                        Select_form_drive()
                    End If

                    If Grid1.RowCount > 4 Then
                        Grid1.CurrentCell = Grid1.Rows(4).Cells(1)
                    Else
                        Grid1.CurrentCell = Grid1.Rows(0).Cells(1)
                    End If
                End If
            End If
        End If
    End Sub
    Private Function Specify_path(path As String)
        If My.Computer.FileSystem.DirectoryExists(path) Then
            Drive_Folder_(path)
            Path_TXT.Text = ""
        End If
    End Function
    Dim back_path As String
    Private Function Drive_Folder_(path As String)
        Refresh_Col()
        back_path = Path_

        Path_ = path

        dtt.Rows.Add("", Path_, "", "", "Location")
        For Each drive As String In Directory.GetDirectories(path & "\")
            Dim folder_name As String
            folder_name = drive.Split("\").Last
            Dim directry As New System.IO.DirectoryInfo(folder_name)

            If folder_name.Length > 2 Then
                If folder_name.Split(".").Last = "bk" Then
                    Dim dt As String() = Find_Company_data(drive, folder_name)
                    dtt.Rows.Add(dt(0), dt(1), dt(2), dt(3), dt(4), dt(5), dt(6), folder_name)
                Else
                    dtt.Rows.Add("", folder_name, "Folder", "", "Folder")
                End If
            Else
                dtt.Rows.Add("", folder_name, "Folder", "", "Folder")
            End If
        Next
        Path_TXT.Text = ""
        If Grid1.RowCount > 4 Then
            Grid1.CurrentCell = Grid1.Rows(4).Cells(1)
        Else
            Grid1.CurrentCell = Grid1.Rows(0).Cells(1)
        End If

    End Function
    Private Function Find_Company_data(path_data As String, dt As String) As String()
        Dim cn As New SQLiteConnection
        Dim id_ As String
        Dim Name_ As String
        Dim Folder_ As String
        Dim version_ As String
        Dim last_date_ As String
        Dim status_ As String
        Dim warnings_ As String
        Dim bk_date_ As String
        Dim Folder_Name As String

        Dim r As SQLiteDataReader
        Try
            If open_MSSQL_Custom_path(path_data & "\info.db", cn) = True Then
                cmd = New SQLiteCommand($"ATTACH DATABASE '{path_data & "\cre.db"}' As 'cre';
ATTACH DATABASE '{path_data & "\cmp.db"}' As 'cmp';
Select *,
(SELECT vc.[date] from cre.TBL_VC vc where vc.Visible <> 'Delete' ORder by vc.[Date] DESC LIMIT 1) as Last_date,
(SELECT vc.[DB_Version] from cmp.TBL_Company_Creation vc LIMIT 1) as DB_Version
From TBL_Backup_Info 
", cn)
                r = cmd.ExecuteReader
                r.Read()

                version_ = r("DB_Version")
                If version_ <> My.Application.Info.Version.ToString Then
                    warnings_ = $"Migration Required ({version_})"
                Else
                    warnings_ = $""
                End If

                id_ = r("Cmp_ID").ToString.Trim
                Folder_Name = ""

                If id_ = Company_ID_str Then
                    Folder_ = dt.Split("(")(1)
                    Folder_ = Folder_.Split(")")(0)
                    Name_ = $"{r("Name").ToString.Trim}"
                    If r("Description").ToString.Trim <> Nothing Then
                        Name_ &= $"{vbNewLine}{r("Description").ToString.Trim}"
                    End If
                    If Date_Formate(r("Last_date").ToString) <> Nothing Then
                        last_date_ = CDate(r("Last_date").ToString).ToString(Date_Format_fech)
                    Else
                        last_date_ = "No Voucher Entry"
                    End If
                    bk_date_ = CDate(r("Date").ToString).ToString("dd-MMM-yyyy hh:mm tt")
                    status_ = "Company"
                Else
                    Folder_ = "Other Backup"
                    Name_ = "Other Company Backup"
                    'warnings_ = ""
                    last_date_ = ""
                    bk_date_ = ""
                    status_ = ""
                End If

                r.Close()
                cmd = New SQLiteCommand($"DETACH DATABASE 'cre'", cn)
                cmd.ExecuteNonQuery()
                cmd = New SQLiteCommand($"DETACH DATABASE 'cmp'", cn)
                cmd.ExecuteNonQuery()
            End If
            cn.Close()


        Catch ex As Exception
            Try
                r.Close()
            Catch ex1 As Exception

            End Try
            cn.Close()
            warnings_ &= "," & ex.Message
            id_ = "Error"
            Name_ = "Error"
            Folder_ = "Folder"
            last_date_ = ""
            status_ = "Error"
            bk_date_ = ""
        End Try


        Return {id_, Name_, Folder_, last_date_, status_, warnings_, bk_date_}
    End Function

    Private Function Select_form_drive()
        Refresh_Col()

        dtt.Rows.Add("", "• Primary", "", "", "Location")
        Dim drives As String() = System.IO.Directory.GetLogicalDrives()
        For Each drive As String In drives
            dtt.Rows.Add("", drive.Split("\").First, "Drive", "", "Drive")
        Next

        dtt.Rows.Add("", "Desktop", "Folder", "", "Desktop")
        dtt.Rows.Add("", "Documents", "Folder", "", "Documents")

        Path_TXT.Text = ""

    End Function
    Private Function Refresh_Col()
        dtt = New DataTable

        dtt.Clear()
        dtt.Columns.Clear()
        dtt.Rows.Clear()

        dtt.Columns.Add("ID") '0
        dtt.Columns.Add("Backup Name") '1
        dtt.Columns.Add("Number") '2
        dtt.Columns.Add("Last Entry") '4
        dtt.Columns.Add("Type")
        dtt.Columns.Add("Warning/Message")
        dtt.Columns.Add("Backup Date & Time") '3
        dtt.Columns.Add("Folder_Name") '3

        dtt.Rows.Add("", "", "", "Create Backup", "Defolt")
        dtt.Rows.Add("", "", "", "Specify Path", "Defolt")
        dtt.Rows.Add("", "", "", "Select form Drive", "Defolt")


        Dim dv As New DataView(dtt)
        Dim Dt_set As New DataTable

        dv.Sort = "[Backup Date & Time]"
        Dt_set = dv.ToTable

        BindingSource1.DataSource = dv
        Grid1.DataSource = BindingSource1
        Grid1.Columns(0).Width = 0
        Grid1.Columns(4).Visible = False
        Grid1.Columns(7).Visible = False


        Grid1.Columns(1).Width = 200
        Grid1.Columns(1).DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Regular)

        Grid1.Columns(2).Width = 70
        Grid1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Grid1.Columns(2).DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Italic)

        Grid1.Columns(5).DisplayIndex = 4
        Grid1.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Grid1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        Grid1.Columns(5).DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Italic)


        Grid1.Columns(3).Width = 200
        Grid1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Grid1.Columns(3).DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Italic)

        Grid1.Columns(6).DisplayIndex = 3
        Grid1.Columns(6).Width = 170
        Grid1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        Grid1.Columns(6).DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Italic)


        Grid1.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft
        Grid1.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter
        Grid1.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopRight
    End Function
    Private Function Select_Comany(Type_ As String)
        If Grid1.Rows.Count > 0 Then
            BG_Head_frm.CMP_TXT.Text = Company_Name_str
            'Login_Frm.Dispose()
            Cell("Login", "", Type_)
        Else
            Msg(NOT_Type.Erro, "Company is not Found", "Company is not found, Please select current company and try again")
        End If
    End Function
    Private Sub Select_Company_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        Button_Clear()
        Button_Enabled()
        Button_Manage()
        Path_TXT.Focus()

        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.TYP_TXT.Text = ""

        BG_frm.HADE_TXT.Text = "Restore Database"
        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text

        Path_ = Auto_Backup_Path

        Load_()
    End Sub

    Private Sub Select_Company_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End
        Ledger_Branch_Balance.Dispose()
        Add_Hander_Remove_Handel(False)
        Frm_foCus()
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Dim dtt As New DataTable
    Private Function Fill_data() As Boolean

        Dim fol_name As String
        Dim fol_number As String


        BindingSource1.DataSource = Nothing

        Refresh_Col()

        If Grid1.RowCount = 0 Then
            Path_TXT.Focus()
            Return False
        Else
            Path_TXT.Focus()
            'Grid1.CurrentCell = Grid1.Rows(0).Cells(1)
        End If
        Return True
    End Function
    Private Function Refresh_Load()
        If Offline_Data() = True Then
            'Search_TXT.Enabled = False
            If Fill_data() = True Then
                Path_TXT.Focus()
            End If
        End If
    End Function

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If success = True Then
            Msg_Custom_YN(NOT_Location.Bottom_Right, Color.Green, My.Resources.Success_animation_icn, Dialoag_Button.Ok, "Success", "Restore Success", "Your data has been<nl>Restore successfully")
            Me.Dispose()
            Cell("Load Data")
        End If
    End Sub
    Private Sub Search_TXT_Enter(sender As Object, e As EventArgs) Handles Path_TXT.Enter
        Panel1.Show()
    End Sub

    Private Sub DataGridView2_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles Grid1.RowPrePaint
        Dim ro As DataGridViewRow = Grid1.Rows(e.RowIndex)
        If ro.Cells(4).Value.ToString = "Location" Then
            ro.DefaultCellStyle.Font = New Font("Arial", 9.75, FontStyle.Bold)
        ElseIf ro.Cells(4).Value.ToString = "Company" Then
            'ro.DefaultCellStyle.Font = New Font(Dft_Font, Dft_Font_Size, FontStyle.Bold)
            ro.DefaultCellStyle.ForeColor = Color.Blue
        ElseIf ro.Cells(4).Value.ToString = "Error" Then
            'ro.DefaultCellStyle.Font = New Font(Dft_Font, Dft_Font_Size, FontStyle.Bold)
            ro.DefaultCellStyle.ForeColor = Color.Red
        End If
    End Sub

    Private Sub Grid1_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles Grid1.RowPostPaint
        Dim ro As DataGridViewRow = Grid1.Rows(e.RowIndex)
        If e.RowIndex = 2 Then
            Dim visibleColumsWidth As Integer = Grid1.Columns.GetColumnsWidth(DataGridViewElementStates.Visible)

            Dim rect = New Rectangle(Grid1.RowHeadersWidth, e.RowBounds.Bottom - 1, visibleColumsWidth, 1)
            e.Graphics.DrawRectangle(Pens.DimGray, rect)
        End If
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Grid1_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles Grid1.RowPrePaint
        If Grid1.Rows(e.RowIndex).Cells(5).Value.ToString <> Nothing Then
            Grid1.DefaultCellStyle.WrapMode = DataGridViewTriState.True
            Grid1.AutoResizeRow(e.RowIndex)
        End If
    End Sub
    Dim success As Boolean = False
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim cn As New SQLiteConnection
            If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                Label4.Text = "Fill Company Data"
                Apply_Backup_files("cmp.db", BackupPath)
                Label4.Text = "Fill Transaction Data"
                Apply_Backup_files("cre.db", BackupPath)
                Label4.Text = "Fill Format/Link Data"
                Apply_Backup_files("lnk.db", BackupPath)
                Label4.Text = "Fill Attachment Data"
                Apply_Backup_files("rec.db", BackupPath)
                Label4.Text = "Fill Audit Data"
                Apply_Backup_files("aud.db", BackupPath)
                success = True
            End If
        Catch ex As Exception
            Msg(NOT_Type.Erro, "Backup Error", ex.Message)
            success = False
        End Try
    End Sub
    Private Function Apply_Backup_files(file As String, path As String)
        Dim File_Name As String = file
        Dim TBL_List As String = ""
        Dim cn As New SQLiteConnection
        Dim coun_ As Integer = 0
        If open_MSSQL_Custom_path(Connection_Path & "\" & Connection_Data & "\" & File_Name, cn) = True Then
            Dim cmd_m As SQLiteCommand = New SQLiteCommand($"SELECT * FROM sqlite_master WHERE type='table'", cn)
            Dim r As SQLiteDataReader
            r = cmd_m.ExecuteReader
            While r.Read
                coun_ += 1
                If r("name").ToString <> "TBL_Info" Then
                    TBL_List &= $"[{r("name").ToString}];"
                End If
            End While
            r.Close()
        End If

        ProgressBag1.Maximum = coun_

        cmd = New SQLiteCommand($"ATTACH DATABASE '{path & "\" & File_Name}' AS D;", cn)
        cmd.ExecuteNonQuery()
        backup_fill(cn, Connection_Path & "\" & Connection_Data & "\" & File_Name, TBL_List)

    End Function
    Private Function backup_fill(cn As SQLiteConnection, path As String, T As String)
        Dim Tbl As String() = T.Split(";")
        Dim count_ As Integer = 0
        For Each s As String In Tbl
            If s <> Nothing Then
                If s.Substring(1, 3) = "TBL" Then
                    cmd = New SQLiteCommand("DELETE FROM " & s & ";" & vbNewLine & $"INSERT INTO {s} SELECT * FROM D.{s};", cn)
                    cmd.ExecuteNonQuery()
                End If
            End If
            count_ += 1
            BackgroundWorker1.ReportProgress(count_)
            Threading.Thread.Sleep(5)
        Next
    End Function
    Private Function Panel_manag(p As Panel)
        bg_Panel.Visible = False
        Progress_Panel.Visible = False

        p.Visible = True
    End Function

    Private Sub Progress_Panel_Paint(sender As Object, e As PaintEventArgs) Handles Progress_Panel.Paint
        obj_center(sender, Me)
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        ProgressBag1.Value = e.ProgressPercentage
        ProgressBag1.Run(1)
        Label8.Text = $"{N2_FORMATE(Val(ProgressBag1.Value * 100) / Val(ProgressBag1.Maximum))} %"
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Restore_db_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
        Path_TXT.Focus()
    End Sub

    Private Sub ProgressBag1_Load(sender As Object, e As EventArgs) Handles ProgressBag1.Load

    End Sub
End Class