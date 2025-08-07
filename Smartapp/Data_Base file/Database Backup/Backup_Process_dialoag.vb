Imports System.ComponentModel
Imports System.Data.SQLite
Imports System.IO

Public Class Backup_Process_dialoag
    Public Backup_Path As String
    Public Backup_Name As String
    Public Backup_Dec As String
    Private Sub Backup_Process_dialoag_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Offline_Data()


        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim result As String = Connection_Data.Split(".").First
        Dim path As String = ""

        For i As Integer = 1 To 10000
            Dim fi As String = Format(i, "0000")
            If Directory.Exists(Backup_Path & "\" & Company_ID_str & $"_Backup({fi}).bk") = False Then
                path = Backup_Path & "\" & Company_ID_str & $"_Backup({fi}).bk"
                Exit For
            End If
        Next



        If Not Directory.Exists(path) Then
            Directory.CreateDirectory(path)
        End If

        Dim cn As New SQLiteConnection
        Try
            If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                Create_Backup_files("info.db", path)
                BackgroundWorker1.ReportProgress(10)
                Create_Backup_files("cmp.db", path)
                BackgroundWorker1.ReportProgress(25)
                Create_Backup_files("cre.db", path)
                BackgroundWorker1.ReportProgress(50)
                Create_Backup_files("lnk.db", path)
                BackgroundWorker1.ReportProgress(70)
                Create_Backup_files("rec.db", path)
                BackgroundWorker1.ReportProgress(100)
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
    Private Function Create_Backup_files(file As String, path As String)
        Dim File_Name As String = file
        Dim Location As String = IO.Path.Combine(path, File_Name)
        Dim create_qury As String = String.Format("Data Source = {0}", Location)

        Dim tbl_ As String = cmp_qry()

        If file = "cmp.db" Then
            'tbl_ = cmp_qry()
        ElseIf file = "cre.db" Then
            'tbl_ = cre_qry()
        ElseIf file = "lnk.db" Then
            'tbl_ = lnk_qry()
        ElseIf file = "rec.db" Then
            'tbl_ = rec_qry()
        ElseIf file = "info.db" Then
            tbl_ = "CREATE TABLE 'TBL_Backup_info' (
	'Id'	INTEGER NOT NULL UNIQUE,
	'Name'	TEXT,
	'Description'	TEXT,
	'Cmp_id'	TEXT,
	'Date'	DATETIME,
	'Device'	TEXT,
	PRIMARY KEY('Id' AUTOINCREMENT)
);"

        End If

        If file <> "info.db" Then
            Dim Orignal_path As String = Connection_Path & "\" & Connection_Data & "\" & File_Name
            IO.File.Copy(Orignal_path, Location, True)
        Else
            Dim cn As New SQLiteConnection(create_qury)
            cn.Open()
            cn.ChangePassword("Opens@Db2558")

            Dim cmd As New SQLiteCommand(tbl_, cn)
            cmd.ExecuteNonQuery()
            cn.Close()

            Dim TBL_List As String = ""

            If open_MSSQL_Custom_path(path & "\" & File_Name, cn) = True Then
                Dim cmd_m As SQLiteCommand = New SQLiteCommand($"SELECT * FROM sqlite_master WHERE type='table'", cn)
                Dim r As SQLiteDataReader
                r = cmd_m.ExecuteReader
                While r.Read
                    TBL_List &= $"[{r("name")}];"
                End While
                r.Close()
            End If

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
        End If
    End Function
    Private Function backup_fill(cn As SQLiteConnection, path As String, T As String)
        Dim Tbl As String() = T.Split(";")
        For Each s As String In Tbl
            If s <> Nothing Then
                cmd = New SQLiteCommand("DELETE FROM " & s & ";" & vbNewLine & $"INSERT INTO {s} SELECT * FROM D.{s};", cn)
                cmd.ExecuteNonQuery()
            End If
        Next
    End Function

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        ProgressBag_Custom1.Value = e.ProgressPercentage
        ProgressBag_Custom1.Run(1)
    End Sub
    Private Function Delete_Last_Backup()
        'MsgBox(Auto_Backup_Max & " - " & dt.Rows.Count - 0)
        If Auto_Backup_Max <= dt.Rows.Count - 0 Then
            Dim dv As New DataView(dt)
            Dim Dt_set As New DataTable

            dv.Sort = "Date"
            Dt_set = dv.ToTable

            For i As Integer = 0 To Val(dt.Rows.Count - 0) - Auto_Backup_Max
                'MsgBox(Dt_set.Rows(i).Item(2))
                If Msg_Custom_YN(NOT_Location.Bottom_Right, Color.Red, My.Resources.Warning_animation_icn, Dialoag_Button.Yes_No, "Warning", "Delete First Backup", $"Can keep total {Auto_Backup_Max} backups<nl>for above specified condition,<nl>want to delete backup before<nl>limit is reached") = DialogResult.Yes Then
                    Directory.Delete(Dt_set.Rows(i).Item(2), True)
                Else
                    Exit For
                End If
            Next
        End If
    End Function
    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If success = True Then
            Delete_Last_Backup()
            Me.DialogResult = DialogResult.Yes
            Me.Dispose()
        Else
            If Msg_Custom_YN(NOT_Location.Bottom_Right, Color.Red, My.Resources.Error_animation_icn, Dialoag_Button.Retry_Cancel, "Error!", "Backup Error", ero_msg) = DialogResult.Retry Then
                BackgroundWorker1.RunWorkerAsync()
            Else
                Me.DialogResult = DialogResult.Cancel
                Me.Dispose()
            End If
        End If
    End Sub
    Dim dt As DataTable
    Private Function Offline_Data() As Boolean
        dt = New DataTable
        dt.Columns.Add("ID")
        dt.Columns.Add("Date").DataType = GetType(Date)
        dt.Columns.Add("File")


        For Each drive As String In Directory.GetDirectories(Backup_Path & "\")
            Dim folder_name As String
            folder_name = drive.Split("\").Last

            If folder_name.Length > 2 Then
                If folder_name.Split(".").Last = "bk" And My.Computer.FileSystem.FileExists(drive & "\info.db") = True Then
                    Dim dtt As String() = Find_Company_Data(drive, folder_name)
                    If dtt(0) = Company_ID_str Then
                        dt.Rows.Add(dtt)
                    End If
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
                r.Read()
                str = {r("Cmp_ID").ToString.Trim, CDate(r("Date")), path_data}
                r.Close()
            End If
            cn.Close()
        Catch ex As Exception
            r.Close()
            cn.Close()
        End Try

        Return str
    End Function

    Private Sub Backup_Process_dialoag_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Me.Dispose()
    End Sub
End Class