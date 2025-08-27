Imports System.ComponentModel
Imports System.Data.SQLite
Imports System.IO
Imports System.IO.Path
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar
Imports Tools

Public Class Backup_db_frm
    Dim From_ID As String
    Dim Path_End As String
    Dim VC_Type_ As String
    Dim VC_ID_ As String

    Public Backup_Path As String
    Public Backup_Name As String
    Public Backup_Dec As String

    Public Auto_Backup As Boolean = False

    Private Sub Backup_db_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text
        BG_frm.HADE_TXT.Text = "Backup Database"

        Panel_Manage(Backup_Panel)

        Label1.Text = Company_Name_str & " Data Backup"

        Name_TXT.Text = Date_Formate(Now.Date)
        Path_TXT.Text = Auto_Backup_Path

        Dim size As Int64 = (From strFile In My.Computer.FileSystem.GetFiles(Connection_Path & "\" & Connection_Data,
              FileIO.SearchOption.SearchAllSubDirectories)
                             Select New System.IO.FileInfo(strFile).Length).Sum()

        Label5.Text = $"Backup Size : {N2_FORMATE(Val(Val(size) / 1024) / 1024)} MB"

        If Auto_Backup = True Then
            Button2.PerformClick()
        End If
    End Sub
    Private Function BackUP_Data() As Boolean
        Backup_Path = Path_TXT.Text
        Backup_Name = Name_TXT.Text
        Backup_Dec = Dec_TXT.Text


        Panel_Manage(Prossess_Panel)

        Find_Avalbel_Backup()
        Backup_Background.RunWorkerAsync()
    End Function
    Private Function Panel_Manage(p As Panel)
        obj_center(p, Me)

        Backup_Panel.Visible = False
        Prossess_Panel.Visible = False
        Backup_increased_Panel.Visible = False
        Delete_Backup_Panel.Visible = False
        success_Panel.Visible = False

        p.Visible = True
    End Function

    Private Sub Backup_db_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        If Auto_Backup = False Then
            BG_frm.BG_Path_TXT.Text = Path_End
            List_frm.Dispose()
            Frm_foCus()
        Else
            Application.Exit()
        End If
    End Sub

    Private Sub Backup_db_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If Msg_Exit_YN("Backup Data") = DialogResult.Yes Then
                Me.Dispose()
            End If
        End If
    End Sub

    Private Sub Backup_db_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.HADE_TXT.Text = "Backup Database"
        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text
        Button_Clear()
        Name_TXT.Focus()
    End Sub

    Private Sub Serial_Panel_Paint(sender As Object, e As PaintEventArgs) Handles Backup_Panel.Paint
        obj_center(sender, Me)
    End Sub

    Private Sub Backup_db_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Chck_Directry(Path_TXT.Text) = True Then
            BackUP_Data()
        Else
            Path_TXT.Focus()
        End If
    End Sub


    Private Sub Backup_Background_DoWork(sender As Object, e As DoWorkEventArgs) Handles Backup_Background.DoWork
        Dim path As String = ""
        Label6.Text = "Finding Backup Path..."
        ProgressBag1.Progress_color = Color.LightSeaGreen
        For i As Integer = 1 To 100
            Backup_Background.ReportProgress(i / 1)

            ProgressBag1.Value += 1
            ProgressBag1.Run(0)
            Label8.Text = $"{N2_FORMATE(Val(ProgressBag1.Value * 100) / Val(ProgressBag1.Maximum))} %"


            Dim fi As String = Format(i, "0000")
            If path = Nothing Then
                If Directory.Exists(Backup_Path & "\" & Company_ID_str & $"_Backup({fi}).bk") = False Then
                    path = Backup_Path & "\" & Company_ID_str & $"_Backup({fi}).bk"
                    'Exit For
                End If
            End If
            'Threading.Thread.Sleep(2)
        Next

        Label6.Text = "Backup..."
        ProgressBag1.Progress_color = Color.Orange

        If Not Directory.Exists(path) Then
            Directory.CreateDirectory(path)
        End If
        Dim cn As New SQLiteConnection
        Try
            If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                Dim tbl_q As String = "CREATE TABLE 'TBL_Backup_info' (
	'Id'	INTEGER NOT NULL UNIQUE,
	'Name'	TEXT,
	'Description'	TEXT,
	'Cmp_id'	TEXT,
	'Date'	DATETIME,
	'Device'	TEXT,
	PRIMARY KEY('Id' AUTOINCREMENT)
);"
                Create_Dummmu_Database(Combine(path, "info.db"), tbl_q)
                info_file_Fill_data(Combine(path, "info.db"))
                Label6.Text = "Backup Company Data"
                Create_Backup_files("cmp.db", path, cmp_qry())
                Label6.Text = "Backup Transaction Data"
                Create_Backup_files("cre.db", path, cre_qry())
                Label6.Text = "Backup Format/Link Data"
                Create_Backup_files("lnk.db", path, lnk_qry())
                Label6.Text = "Backup Attachment Data"
                Create_Backup_files("rec.db", path, rec_qry())
                Label6.Text = "Backup Audit Data"
                Create_Backup_files("aud.db", path, aud_qry())
                success = True
            End If
            cn.Close()
        Catch ex As Exception
            cn.Close()
            Msg(NOT_Type.Erro, "Backup Error", ex.Message)
            ero_msg = ex.Message
            success = False
        End Try

    End Sub
    Dim success As Boolean = False
    Dim ero_msg As String
    Private Function Create_Backup_files(file As String, path As String, tbl_q As String)
        Dim Backup_Path As String = Combine(path, file)
        Dim current_data_path As String = Combine(Connection_Path, Connection_Data, file)

        Dim create_qury As String = String.Format("Data Source = {0}", Backup_Path)

        If file = "aud.db" Then
            Create_aud(path)
        Else
            Create_Dummmu_Database(Backup_Path, tbl_q)
        End If

        Dim cn As New SQLiteConnection()

        Dim coun_ As Integer = 1
        Dim TBL_List As String = ""
        If open_MSSQL_Custom_path(Backup_Path, cn) = True Then
            Dim cmd_m As SQLiteCommand = New SQLiteCommand($"SELECT * FROM sqlite_master WHERE type='table'", cn)
            Dim r As SQLiteDataReader
            r = cmd_m.ExecuteReader
            While r.Read
                coun_ += 1
                TBL_List &= $"[{r("name").ToString}];"
            End While
            r.Close()
        End If
        ProgressBag1.Maximum = coun_
        cmd = New SQLiteCommand($"ATTACH DATABASE '{current_data_path}' AS D;", cn)
        cmd.ExecuteNonQuery()
        backup_fill(cn, Backup_Path, TBL_List)
        cn.Close()

    End Function
    Private Function backup_fill(cn As SQLiteConnection, path As String, T As String)
        Dim Tbl As String() = T.Split(";")
        Dim count_ As Integer = 0
        ProgressBag1.Value = 0
        ProgressBag1.Run(0)
        For Each s As String In Tbl
            If s <> Nothing Then
                If s.Substring(1, 3) = "TBL" Then
                    cmd = New SQLiteCommand("DELETE FROM " & s & ";" & vbNewLine & $"INSERT INTO {s} SELECT * FROM D.{s};", cn)
                    cmd.ExecuteNonQuery()
                End If
            End If
            count_ += 1
            Backup_Background.ReportProgress(count_)
            'Threading.Thread.Sleep(10)
            ProgressBag1.Value += 1
            ProgressBag1.Run(0)
            Label8.Text = $"{N2_FORMATE(Val(ProgressBag1.Value * 100) / Val(ProgressBag1.Maximum))} %"
        Next
    End Function
    Private Function info_file_Fill_data(path As String) As Boolean
        Dim cn As New SQLiteConnection()
        open_MSSQL_Custom_path(path, cn)
        cmd = New SQLiteCommand($"INSERT INTO TBL_Backup_info (Name,Description, Cmp_ID, [Date]) VALUES (@Name,@Description,@cmp_id,@Install_)", cn)
        With cmd.Parameters
            .AddWithValue("@Name", Backup_Name)
            .AddWithValue("@Description", Backup_Dec)
            .AddWithValue("@cmp_id", Company_ID_str)
            .AddWithValue("@Install_", CDate(DateTime.Now))
            .AddWithValue("@Device", PC_ID)
        End With
        cmd.ExecuteNonQuery()
        cn.Close()
    End Function
    Private Function Create_Dummmu_Database(path_, tbl_Q)
        Dim create_qury As String = String.Format("Data Source = {0}", path_)

        Dim cn As New SQLiteConnection(create_qury)
        cn.Open()
        cn.ChangePassword("Opens@Db2558")

        Dim cmd As New SQLiteCommand(tbl_Q, cn)
        cmd.ExecuteNonQuery()
        cn.Close()
    End Function

    Dim dt As DataTable
    Private Function Find_Avalbel_Backup() As Boolean
        dt = New DataTable
        dt.Columns.Add("ID")
        dt.Columns.Add("Date").DataType = GetType(Date)
        dt.Columns.Add("File")


        For Each drive As String In Directory.GetDirectories(Backup_Path & "\")
            Dim folder_name As String
            folder_name = drive.Split("\").Last


            If folder_name.Length > 2 Then
                If folder_name.Split(".").Last = "bk" And My.Computer.FileSystem.FileExists(drive & "\info.db") = True Then
                    Try
                        Dim dtt As String() = Find_Company_Data(drive, folder_name)
                        If dtt(0) = Company_ID_str Then
                            dt.Rows.Add(dtt)
                        End If
                    Catch ex As Exception

                    End Try
                End If
            End If
        Next
    End Function
    Private Function Find_Company_Data(path_data As String, dt As String) As String()
        Dim cn As New SQLiteConnection
        Dim r As SQLiteDataReader

        Dim str() As String
        Try
            If open_MSSQL_Custom_path(path_data & "\info.db", cn) = True Then
                cmd = New SQLiteCommand("Select * From TBL_Backup_Info", cn)
                r = cmd.ExecuteReader
                While r.Read
                    str = {r("Cmp_ID").ToString.Trim, CDate(r("Date").ToString), path_data}
                End While
                r.Close()
            End If
            cn.Close()
        Catch ex As Exception
            r.Close()
            cn.Close()
        End Try

        Return str
    End Function

    Private Sub Backup_Background_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles Backup_Background.RunWorkerCompleted
        If success = True Then
            Delete_Last_Backup()
            'Me.Dispose()
        Else
            If Msg_Custom_YN(NOT_Location.Bottom_Right, Color.Red, My.Resources.Error_animation_icn, Dialoag_Button.Retry_Cancel, "Error!", "Backup Error", ero_msg) = DialogResult.Retry Then
                Backup_Background.RunWorkerAsync()
            Else
                Me.DialogResult = DialogResult.Cancel
                Me.Dispose()
            End If
        End If
    End Sub
    Private Function Delete_Last_Backup()
        'MsgBox(Auto_Backup_Max & " - " & dt.Rows.Count - 0)
        If Auto_Backup_Max <= dt.Rows.Count - 0 Then
            Label17.Text = Auto_Backup_Max
            Label14.Text = dt.Rows.Count + 1
            Label21.Text = $"Your last {(Val(Label14.Text) - Val(Label17.Text))} backups will be deleted and {Auto_Backup_Max} backups will remain safe."

            Panel_Manage(Backup_increased_Panel)
            Button4.Focus()

        Else
            Me.Dispose()
        End If
    End Function

    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs) Handles Prossess_Panel.Paint
        obj_center(sender, Me)
    End Sub

    Private Sub Backup_Background_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles Backup_Background.ProgressChanged
        'ProgressBag1.Value = e.ProgressPercentage
        'ProgressBag1.Run(1)
        'Label8.Text = $"{N2_FORMATE(Val(ProgressBag1.Value * 100) / Val(ProgressBag1.Maximum))} %"
    End Sub

    Private Sub Panel10_Paint(sender As Object, e As PaintEventArgs) Handles Panel10.Paint

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Dispose()
    End Sub

    Private Sub Backup_increased_Panel_Paint(sender As Object, e As PaintEventArgs) Handles Backup_increased_Panel.Paint
        obj_center(sender, Me)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If Chck_Directry(Path_TXT.Text) = True Then
            FolderBrowserDialog1.SelectedPath = Path_TXT.Text
        End If
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            Path_TXT.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub Delete_Backup_Panel_Paint(sender As Object, e As PaintEventArgs) Handles Delete_Backup_Panel.Paint
        obj_center(sender, Me)
    End Sub

    Private Sub Deletebackup_Back_DoWork(sender As Object, e As DoWorkEventArgs) Handles Deletebackup_Back.DoWork
        Dim dv As New DataView(dt)
        Dim Dt_set As New DataTable

        dv.Sort = "Date"
        Dt_set = dv.ToTable

        For i As Integer = 0 To Val(dt.Rows.Count - 0) - Auto_Backup_Max
            Try
                TextBox1.Text &= $"Delete Backup {Dt_set.Rows(i).Item(2)}{vbNewLine}"
                TextBox1.SelectionStart = TextBox1.TextLength - 1
                Deletebackup_Back.ReportProgress(i)
                Directory.Delete(Dt_set.Rows(i).Item(2), True)
                TextBox1.Text &= $"Success..{vbNewLine}"
                TextBox1.SelectionStart = TextBox1.TextLength - 1
                'Threading.Thread.Sleep(20)
            Catch ex As Exception
                TextBox1.Text &= $"Error..{vbNewLine}"
                TextBox1.SelectionStart = TextBox1.TextLength - 1

            End Try
        Next
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Panel_Manage(Delete_Backup_Panel)
        TextBox1.ScrollBars = ScrollBars.Both
        Deletebackup_Back.RunWorkerAsync()
    End Sub

    Private Sub Deletebackup_Back_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles Deletebackup_Back.ProgressChanged
        Delete_Prossess.Maximum = (dt.Rows.Count - Auto_Backup_Max) + 2

        Delete_Prossess.Value = e.ProgressPercentage
        Delete_Prossess.Run(1)
        Label24.Text = $"{N2_FORMATE(Val(Delete_Prossess.Value * 100) / Val(Delete_Prossess.Maximum))} %"

        Threading.Thread.Sleep(30)
    End Sub

    Private Sub Deletebackup_Back_Disposed(sender As Object, e As EventArgs) Handles Deletebackup_Back.Disposed

    End Sub

    Private Sub success_Panel_Paint(sender As Object, e As PaintEventArgs) Handles success_Panel.Paint
        obj_center(sender, Me)
    End Sub

    Private Sub Deletebackup_Back_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles Deletebackup_Back.RunWorkerCompleted
        Panel_Manage(success_Panel)
        Timer1.Start()
        Button7.Focus()
    End Sub
    Dim au_ As Integer = 6
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        au_ -= 1
        Button7.Text = $"Ok ({au_})"

        If au_ = 0 Then
            Button7.PerformClick()
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Timer1.Stop()
        Me.Dispose()
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

    Private Sub Dec_TXT_TextChanged(sender As Object, e As EventArgs) Handles Dec_TXT.TextChanged

    End Sub
End Class