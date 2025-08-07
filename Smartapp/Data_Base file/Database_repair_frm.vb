Imports System.ComponentModel
Imports System.Data.SQLite
Imports System.IO
Imports Tools

Public Class Database_repair_frm
    Dim From_ID As String

    Dim Path_End As String
    Dim TYP_TXT_old As String
    Public dami_dt_path As String = Application.StartupPath & "\temp_database\" & My.Application.Info.Version.ToString.Trim '& "\cre.db"
    Public Update_Qry As String = ""
    Private Sub Database_repair_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text
        TYP_TXT_old = BG_frm.TYP_TXT.Text
        Dim cnn As New SQLiteConnection

        BG_frm.HADE_TXT.Text = "Database Update"
        BG_frm.TYP_TXT.Text = ""


        'Databse_Version_Fatch()
    End Sub
    Private Function Progress_bar_max_vlu_set()
        Dim cn_m As New SQLiteConnection
        If open_MSSQL_Custom_path($"{dami_dt_path}\cmp.db", cn_m) = True Then
            Dim cmd_m As SQLiteCommand = New SQLiteCommand("Select count(*) as count_ From (SELECT * FROM sqlite_master WHERE type='table')", cn_m)
            Dim m As SQLiteDataReader
            m = cmd_m.ExecuteReader
            While m.Read
                ProgressBag2.Maximum = Val(m("count_"))
            End While
            m.Close()
        End If
        If open_MSSQL_Custom_path($"{dami_dt_path}\cre.db", cn_m) = True Then
            Dim cmd_m As SQLiteCommand = New SQLiteCommand("Select count(*) as count_ From (SELECT * FROM sqlite_master WHERE type='table')", cn_m)
            Dim m As SQLiteDataReader
            m = cmd_m.ExecuteReader
            While m.Read
                ProgressBag2.Maximum += Val(m("count_"))
            End While
            m.Close()
        End If
        If open_MSSQL_Custom_path($"{dami_dt_path}\lnk.db", cn_m) = True Then
            Dim cmd_m As SQLiteCommand = New SQLiteCommand("Select count(*) as count_ From (SELECT * FROM sqlite_master WHERE type='table')", cn_m)
            Dim m As SQLiteDataReader
            m = cmd_m.ExecuteReader
            While m.Read
                ProgressBag2.Maximum += Val(m("count_"))
            End While
            m.Close()
        End If
        If open_MSSQL_Custom_path($"{dami_dt_path}\rec.db", cn_m) = True Then
            Dim cmd_m As SQLiteCommand = New SQLiteCommand("Select count(*) as count_ From (SELECT * FROM sqlite_master WHERE type='table')", cn_m)
            Dim m As SQLiteDataReader
            m = cmd_m.ExecuteReader
            While m.Read
                ProgressBag2.Maximum += Val(m("count_"))
            End While
            m.Close()
        End If
        If open_MSSQL_Custom_path($"{dami_dt_path}\aud.db", cn_m) = True Then
            Dim cmd_m As SQLiteCommand = New SQLiteCommand("Select count(*) as count_ From (SELECT * FROM sqlite_master WHERE type='table')", cn_m)
            Dim m As SQLiteDataReader
            m = cmd_m.ExecuteReader
            While m.Read
                ProgressBag2.Maximum += Val(m("count_"))
            End While
            m.Close()
        End If

        cn_m.Close()
    End Function
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        obj_center(sender, Me)
    End Sub

    Private Sub Database_repair_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.HADE_TXT.Text = "Database Update"
        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text

        Button_Clear()
    End Sub

    Private Sub Database_repair_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        'BG_frm.BG_Path_TXT.Text = Path_End
        List_frm.Dispose()
        Frm_foCus()
    End Sub
    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        'ProgressBag2.Value = e.ProgressPercentage
        'ProgressBag2.Run(0)

        Label5.Text = $"{N2_FORMATE(Val(ProgressBag2.Value * 100) / Val(ProgressBag2.Maximum))} %"

        'Label6.Text = $"{ProgressBag2.Value} Table / {ProgressBag2.Maximum} Table"
        'ProgressBag2.vlu_label.Text = $"{N2_FORMATE(Val(ProgressBag2.Value * 100) / Val(ProgressBag2.Maximum))} %"
    End Sub
    Dim current_file As Database_File
    Dim file_prossess As Integer
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Label11.Text = "Please wait Update Data..."

        current_file = Database_File.cmp
        Update_Qry = ""
        start($"cmp.db")
        current_file = Database_File.cre
        Update_Qry = ""
        start($"cre.db")
        current_file = Database_File.lnk
        Update_Qry = ""
        start($"lnk.db")
        current_file = Database_File.rec
        Update_Qry = ""
        start($"rec.db")
        current_file = Database_File.aud
        Update_Qry = ""
        start($"aud.db")


        Threading.Thread.Sleep(1000)
        ProgressBag2.Value = 0
        ProgressBag2.Run(0)

        Update_custo(Db_V, Me)

        Label6.Text = "Preparing Database"
    End Sub
    Private Function start(file As String)

        Dim cn_m As New SQLiteConnection
        If open_MSSQL_Custom_path($"{dami_dt_path}\{file}", cn_m) = True Then
            Dim cmd_m As SQLiteCommand = New SQLiteCommand("SELECT * FROM sqlite_master WHERE type='table'", cn_m)
            Dim m As SQLiteDataReader
            m = cmd_m.ExecuteReader
            While m.Read
                Dim cn_d As New SQLiteConnection
                If open_MSSQL_Custom_path($"{Current_Data_Path}\{file}", cn_d) = True Then
                    Dim cmd_d As SQLiteCommand = New SQLiteCommand($"SELECT name FROM sqlite_master WHERE type='table' AND name='{m("name")}'", cn_d)
                    Dim r As SQLiteDataReader
                    r = cmd_d.ExecuteReader
                    Dim exist_ As Boolean = False
                    While r.Read
                        'For i As Integer = 0 To 100000
                        If r("name") = m("name") Then
                            exist_ = True
                        End If
                        'Next
                    End While
                    If exist_ = False Then
                        Update_Qry &= vbNewLine & create_tbl(file, m("name"))
                    Else
                        Chack_colunms(file, m("name"))
                    End If
                    r.Close()
                End If
                cn_d.Close()

                ProgressBag2.Value = ProgressBag2.Value + 1
                ProgressBag2.Run(0)

                BackgroundWorker1.ReportProgress(0)

                Label6.Text = $"{ProgressBag2.Value} Table / {ProgressBag2.Maximum} Table"
                ProgressBag2.vlu_label.Text = $"{N2_FORMATE(Val(ProgressBag2.Value * 100) / Val(ProgressBag2.Maximum))} %"
                For i As Integer = 1 To 100 Step 5
                    ProgressBag_Custom2.Value = i
                    ProgressBag_Custom2.Run(0)
                Next
            End While
        End If


        Dim cn As New SQLiteConnection
        If open_MSSQL_Custom_path($"{Current_Data_Path}\{file}", cn) = True Then
            cmd = New SQLiteCommand(Update_Qry, cn)
            cmd.ExecuteReader()
        End If
        cn_m.Close()

    End Function
    Private Function create_tbl(file As String, tbl_name As String) As String
        Dim cn_m As New SQLiteConnection
        Dim qry As String = $"CREATE TABLE '{tbl_name}' ("

        If open_MSSQL_Custom_path($"{dami_dt_path}\{file}", cn_m) = True Then
            Dim cmd_d As SQLiteCommand = New SQLiteCommand($"PRAGMA table_info('{tbl_name}')", cn_m)
            Dim r As SQLiteDataReader
            r = cmd_d.ExecuteReader
            Dim primary_ As String = ""
            While r.Read
                Dim not_null As String = ""
                Dim auto_id As String = ""
                If r("notnull") <> "0" Then
                    not_null = "NOT NULL"
                Else
                    not_null = "NULL"
                End If

                If r("pk") <> "0" Then
                    auto_id = "UNIQUE"
                    primary_ = r("name")
                Else
                    auto_id = ""
                End If


                Dim typ As String = r("type").ToString.Trim
                If typ = "BLOB" Then
                    typ = "BLOB COLLATE BINARY"
                End If

                qry &= $"'{r("name")}' {typ} {not_null} {auto_id},"
            End While
            If primary_ <> Nothing Then
                qry &= $"PRIMARY KEY('{primary_}' AUTOINCREMENT)"
            Else
                qry = qry.Substring(0, qry.Length - 1)
            End If
        End If
        cn_m.Close()

        Return qry & ")" & ";"
    End Function
    Private Function Chack_colunms(file As String, tbl_name As String)
        Dim cn_m As New SQLiteConnection
        If open_MSSQL_Custom_path($"{dami_dt_path}\{file}", cn_m) = True Then
            Dim cmd_m As SQLiteCommand = New SQLiteCommand($"PRAGMA table_info('{tbl_name}')", cn_m)
            Dim m As SQLiteDataReader
            m = cmd_m.ExecuteReader
            While m.Read
                Dim cn_d As New SQLiteConnection
                If open_MSSQL_Custom_path($"{Current_Data_Path}\{file}", cn_d) = True Then
                    Dim cmd_d As SQLiteCommand = New SQLiteCommand($"PRAGMA table_info('{tbl_name}')", cn_d)
                    Dim r As SQLiteDataReader
                    r = cmd_d.ExecuteReader
                    Dim exist_ As Boolean = False
                    While r.Read
                        If r("name") = m("name") Then
                            exist_ = True
                            If (r("type") = m("type")) And (r("notnull") = m("notnull")) Then
                            Else
                                Dim null_ As Boolean
                                If Val(r("notnull")) = 0 Then
                                    null_ = True
                                Else
                                    null_ = False
                                End If
                                Update_Qry &= vbNewLine & Alter_Colunm(tbl_name, r("name"), m("type"), null_)
                            End If
                            Exit While
                        Else
                            exist_ = False
                        End If
                    End While
                    If exist_ = False Then
                        Update_Qry &= vbNewLine & add_Colunm(tbl_name, m("name"), m("type"))
                    End If
                End If
                cn_d.Close()
            End While
        End If
        cn_m.Close()
    End Function
    Private Function Alter_Colunm(TBL_ As String, col_ As String, type_ As String, null_ As Boolean)

        Return $"UPDATE [{TBL_}] 
       SET [{col_}] = CAST([{col_}] as {type_});" & vbNewLine & Alter_dataType(TBL_, col_, type_, null_)
    End Function
    Private Function Alter_dataType(TBL_ As String, col_ As String, type_ As String, null_ As Boolean)

        Dim null_vlu As String
        If null_ = True Then
            null_vlu = "NULL"
        Else
            null_vlu = "NOT NULL"
        End If

        Return ""
    End Function
    Private Function add_Colunm(TBL_ As String, col_ As String, type_ As String)

        Return $"ALTER TABLE [{TBL_}] ADD '{col_}' {type_};"
    End Function

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        ProgressBag2.Value = 0
        ProgressBag2.Run(0)
        ProgressBag2.Progress_color = Color.Turquoise

        ProgressBag_Custom2.Value = 0
        ProgressBag_Custom2.Run(0)

        For i As Integer = 1 To 100
            ProgressBag2.Value = i
            ProgressBag2.Run(0)
            Threading.Thread.Sleep(50)
        Next

        Dim cn As New SQLiteConnection
        If open_MSSQL_Custom_path($"{Current_Data_Path}\cmp.db", cn) = True Then
            cmd = New SQLiteCommand("UPDATE TBL_Company_Creation SET DB_Version = '" & My.Application.Info.Version.ToString.Trim & "'", cn)
            cmd.ExecuteNonQuery()

            Me.Dispose()
            BG_frm.TYP_TXT.Text = TYP_TXT_old


            If Type_of_db = db_Type.Database Then
                Login_Frm.db_fatch_Success()
            ElseIf Type_of_db = db_Type.Backup Then
                Restore_db_frm.Restore_data()
            End If
        End If
    End Sub
    Dim Db_V As String
    Dim Current_Data_Path As String = ""
    Public Function Backup_Version_Fatch(BackupPath As String) As Boolean
        Current_Data_Path = BackupPath
        Dim v As String = 0
        Dim cn As New SQLiteConnection
        If open_MSSQL_Custom_path($"{BackupPath}\cmp.db", cn) Then
            cmd = New SQLiteCommand("SELECT * FROM TBL_Company_Creation", cn)
            Dim r As SQLiteDataReader = cmd.ExecuteReader
            While r.Read
                v = r("DB_Version").ToString
            End While
            r.Close()
        End If

        If Val(v.ToString.Replace(".", "")) < Val(My.Application.Info.Version.ToString.Replace(".", "")) Then
            Cell("Database Update") '<--Me Visible
            Type_of_db = db_Type.Backup

            Label7.Text = ": " & v.ToString
            Label4.Text = ": " & My.Application.Info.Version.ToString.Trim
            Label17.Text = "Backup Migration Required"
            Label14.Text = "Your Backup is in old version, do you want to update your Backup to new version"

            Label20.Text = "Backup is Being Migrated"
            Label18.Text = "Changes made through updates are being made within the backup."
            create_dami_database()

        ElseIf Val(v.ToString.Replace(".", "")) > Val(My.Application.Info.Version.ToString.Replace(".", "")) Then
            Msg_Custom_YN(NOT_Location.Center, Color.Red, My.Resources.Error_animation_icn, Dialoag_Button.Ok, "Error !", "Backup Version is Large", $"Sorry, you cannot restore this backup because<nl>the software version is {My.Application.Info.Version.ToString} and the backup version is {v},<nl>the backup version is older than the software.<nl>If you want to import the backup,<nl>please update the software to the new version.")
            Return False
        ElseIf Val(v.ToString.Replace(".", "")) = Val(My.Application.Info.Version.ToString.Replace(".", "")) Then
            Return True
        End If
    End Function
    Public Function Databse_Version_Fatch(path As String) As Boolean
        Current_Data_Path = path
        Db_V = Find_DT_Value(Database_File.cmp, "TBL_Company_Creation", "DB_Version", "ID <> '000'")
        Dim cn As New SQLiteConnection
        If Db_V = My.Application.Info.Version.ToString.Trim Then
            Me.Dispose()
            Login_Frm.db_fatch_Success()
            Return True
        Else
            Cell("Database Update") '<--Me Visible
            Type_of_db = db_Type.Database


            Label7.Text = ": " & Find_DT_Value(Database_File.cmp, "TBL_Company_Creation", "DB_Version", "ID <> '000'")
            Label4.Text = ": " & My.Application.Info.Version.ToString.Trim

            Label17.Text = "Database Migration Required"
            Label14.Text = "Your Database is in old version, do you want to update your Database to new version"

            Label20.Text = "Database is Being Migrated"
            Label18.Text = "Changes made through updates are being made within the Database."
            create_dami_database()
        End If
    End Function
    Dim Type_of_db As db_Type
    Public Enum db_Type
        Database = 0
        Backup = 1
    End Enum
    Dim path_dami As String = ""
    Private Function create_dami_database()
        Data_install.Class_ = Company_Class_str
        path_dami = Application.StartupPath & "\temp_database\" & My.Application.Info.Version.ToString.Trim

        Panel_Manag(Panel8)
        DamiDatabase_Background.RunWorkerAsync()
    End Function
    Private Function Panel_Manag(pan As Panel)
        Panel4.Visible = False
        Panel1.Visible = False
        Panel8.Visible = False

        pan.Visible = True
    End Function

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint
        obj_center(sender, Me)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Back_Database() = True Then
            Progress_bar_max_vlu_set()
            Panel_Manag(Panel1)
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub
    Private Function Back_Database()
        Dim frm_path As String = Connection_Path & "\" & Connection_Data
        Dim to_path As String = Connection_Path & "\" & Company_ID_str & ".backup"

        If Directory.Exists(to_path) = False Then
            Directory.CreateDirectory(to_path)
        End If

        For i As Integer = 1 To 10000
            If Directory.Exists(to_path & "\" & Company_ID_str & $"({i}).bak") = False Then
                to_path = to_path & "\" & Company_ID_str & $"({i}).bak"
                Directory.CreateDirectory(to_path)
                FileIO.FileSystem.CopyDirectory(frm_path, to_path)
                Return True
            End If
        Next
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Login_Frm.Dispose()
        Cell("Company Select")
        Me.Dispose()
    End Sub

    Private Function Chack_Dami_Avalable() As Boolean
        Return Chck_Directry(path_dami)
    End Function
    Private Sub DamiDatabase_Background_DoWork(sender As Object, e As DoWorkEventArgs) Handles DamiDatabase_Background.DoWork
        Label11.Text = "Searching for new updates"
        If Chack_Dami_Avalable() = True Then
            Exit Sub
        Else
            Directory.CreateDirectory(path_dami)
            Threading.Thread.Sleep(1000)
        End If


        '1 Load
        Label11.Text = $"1 Database / 5 Database"
        Create_cmp(path_dami)

        For i As Integer = 1 To 100
            DamiDatabase_Background.ReportProgress(i)
            'Threading.Thread.Sleep(1)
            ProgressBag_Custom1.Progress_color = Color.Orange
        Next


        '2
        Label11.Text = $"2 Database / 5 Database"
        Create_cre(path_dami)

        For i As Integer = 1 To 100
            DamiDatabase_Background.ReportProgress(i)
            'Threading.Thread.Sleep(1)
            ProgressBag_Custom1.Progress_color = Color.Orange
        Next


        '3
        Label11.Text = $"3 Database / 5 Database"
        Create_lnk(path_dami)

        For i As Integer = 1 To 100
            DamiDatabase_Background.ReportProgress(i)
            'Threading.Thread.Sleep(1)
            ProgressBag_Custom1.Progress_color = Color.Orange
        Next

        '4
        Label11.Text = $"4 Database / 5 Database"
        Create_rec(path_dami)

        For i As Integer = 1 To 100
            DamiDatabase_Background.ReportProgress(i)
            'Threading.Thread.Sleep(1)
            ProgressBag_Custom1.Progress_color = Color.Orange
        Next

        '5
        Label11.Text = $"5 Database / 5 Database"
        Create_aud(path_dami)

        For i As Integer = 1 To 100
            DamiDatabase_Background.ReportProgress(i)
            'Threading.Thread.Sleep(1)
            ProgressBag_Custom1.Progress_color = Color.Orange
        Next



        Label11.Text = "Verifying database update"
        'Extra Load


        For i As Integer = 1 To 100
            DamiDatabase_Background.ReportProgress(i)
            Threading.Thread.Sleep(1)
        Next

        Label11.Text = "Database has been successfully verified."
        Threading.Thread.Sleep(1000)

    End Sub

    Private Sub DamiDatabase_Background_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles DamiDatabase_Background.RunWorkerCompleted
        Panel_Manag(Panel4)

        Button1.Focus()
    End Sub

    Private Sub Panel8_Paint(sender As Object, e As PaintEventArgs) Handles Panel8.Paint
        obj_center(sender, Me)
    End Sub

    Private Sub DamiDatabase_Background_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles DamiDatabase_Background.ProgressChanged
        If e.ProgressPercentage = 100 Then
            ProgressBag_Custom1.Progress_color = Color.Turquoise
        End If
        ProgressBag_Custom1.Value = e.ProgressPercentage
        ProgressBag_Custom1.Run(0)
    End Sub

    Private Sub Database_repair_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
    End Sub

    Private Sub Panel1_Paint_1(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Panel8_Paint_1(sender As Object, e As PaintEventArgs) Handles Panel8.Paint

    End Sub

    Private Sub Panel4_Paint_1(sender As Object, e As PaintEventArgs) Handles Panel4.Paint

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub DamiDatabase_Background_Disposed(sender As Object, e As EventArgs) Handles DamiDatabase_Background.Disposed

    End Sub
End Class