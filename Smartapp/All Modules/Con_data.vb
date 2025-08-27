Imports System.Data.SqlClient
Imports System.Data.SQLite
Imports System.Environment
Module Con_data
    Public Connection_Path As String
    Public Connection_Data As String
    'try
    Public con_ As New SqlConnection()
    Public con As New SQLiteConnection()
    Public con_2 As New SQLiteConnection()
    Public con_3 As New SQLiteConnection()
    Public con_4 As New SQLiteConnection()
    'Public con_Online As New SqlConnection()
    Public qury As String
    Dim result As Boolean
    Dim con_String As String
    Dim con_String2 As String
    Public cmd_ As New SqlCommand(qury, con_)
    Public cmd As New SQLiteCommand(qury, con)
    Public cmd_2 As New SQLiteCommand(qury, con_2)
    Public cmd_3 As New SQLiteCommand(qury, con_3)
    Public cmd_4 As New SQLiteCommand(qury, con_4)
    Public Function open_MSSQL(Files As Database_File) As Boolean
        Try
            If Files.ToString = "cfgs" Then
                con_String = "Data Source=" & Application.StartupPath & "\" & Files.ToString & ".db;Version=3;New=True;Compress=True;"
            Else
                con_String = "Data Source=" & Connection_Path & "\" & Connection_Data & "\" & Files.ToString & ".db;Version=3;New=True;Compress=True;"
            End If
            If con.State = ConnectionState.Closed Then
                con.ConnectionString = con_String

                con.SetPassword("Opens@Db2558")
                con.Open()
                result = True
            Else
                con.Close()
                con.ConnectionString = con_String
                con.SetPassword("Opens@Db2558")
                con.Open()
                result = True
            End If
        Catch ex As Exception
            result = False
            'MessageBox.Show(ex.Message)
        End Try

        Return result
    End Function
    Public Function open_MSSQL_2(Files As Database_File) As Boolean
        If Files.ToString = "cfgs" Then
            con_String2 = "Data Source=" & Application.StartupPath & "\" & Files.ToString & ".db;Version=3;New=False;Pooling=true;Compress=True;"
        Else
            con_String2 = "Data Source=" & Connection_Path & "\" & Connection_Data & "\" & Files.ToString & ".db;Version=3;New=False;Pooling=true;Compress=True;"
        End If


        Try
            If con_2.State = ConnectionState.Closed Then
                con_2.ConnectionString = con_String2
                con_2.SetPassword("Opens@Db2558")
                con_2.Open()
                result = True
            Else
                con_2.Close()
                con_2.ConnectionString = con_String2
                con_2.SetPassword("Opens@Db2558")
                con_2.Open()
                result = True
            End If
        Catch ex As Exception
            result = False
            MessageBox.Show(ex.Message)
        End Try

        Return result
    End Function
    Public Function open_MSSQL_3(Files As Database_File) As Boolean
        If Files.ToString = "cfgs" Then
            con_String2 = "Data Source=" & Application.StartupPath & "\" & Files.ToString & ".db;Version=3;New=False;Pooling=true;Compress=True;"
        Else
            con_String2 = "Data Source=" & Connection_Path & "\" & Connection_Data & "\" & Files.ToString & ".db;Version=3;New=False;Pooling=true;Compress=True;"
        End If
        Try
            If con_3.State = ConnectionState.Closed Then
                con_3.ConnectionString = con_String2
                con_3.SetPassword("Opens@Db2558")
                con_3.Open()
                result = True
            Else
                con_3.Close()
                con_3.ConnectionString = con_String2
                con_3.SetPassword("Opens@Db2558")
                con_3.Open()
                result = True
            End If
        Catch ex As Exception
            result = False
            MessageBox.Show(ex.Message)
        End Try

        Return result
    End Function
    Public Function open_MSSQL_4(Files As Database_File) As Boolean
        If Files.ToString = "cfgs" Then
            con_String2 = "Data Source=" & Application.StartupPath & "\" & Files.ToString & ".db;Version=3;New=False;Pooling=true;Compress=True;"
        Else
            con_String2 = "Data Source=" & Connection_Path & "\" & Connection_Data & "\" & Files.ToString & ".db;Version=3;New=False;Pooling=true;Compress=True;"
        End If
        Try
            If con_4.State = ConnectionState.Closed Then
                con_4.ConnectionString = con_String2
                con_4.SetPassword("Opens@Db2558")
                con_4.Open()
                result = True
            Else
                con_4.Close()
                con_4.ConnectionString = con_String2
                con_4.SetPassword("Opens@Db2558")
                con_4.Open()
                result = True
            End If
        Catch ex As Exception
            result = False
            MessageBox.Show(ex.Message)
        End Try

        Return result
    End Function
    Public Function open_MSSQL_Cstm(Files As Database_File, connn As SQLiteConnection) As Boolean
        If Files.ToString = "cfgs" Then
            con_String2 = "Data Source=" & Application.StartupPath & "\" & Files.ToString & ".db;Version=3;New=False;Pooling=true;Compress=True;"
        Else
            con_String2 = "Data Source=" & Connection_Path & "\" & Connection_Data & "\" & Files.ToString & ".db;Version=3;New=False;Pooling=true;Compress=True;"
        End If
        Try
            If connn.State = ConnectionState.Closed Then
                connn.ConnectionString = con_String2
                connn.SetPassword("Opens@Db2558")
                connn.Open()
                result = True
            Else
                connn.Close()
                connn.ConnectionString = con_String2
                connn.SetPassword("Opens@Db2558")
                connn.Open()
                result = True
            End If
        Catch ex As Exception
            result = False
            MessageBox.Show(ex.Message)
        End Try

        Return result
    End Function

    Public cn_audit As New SQLiteConnection
    Public Function open_MSSQL_Audit() As SqlConnection
        cn_audit = New SQLiteConnection
        con_String2 = $"Data Source={Connection_Path}\{Connection_Data}\cre.db;Version=3;New=False;Pooling=true;Compress=True;"
        Try
            If cn_audit.State = ConnectionState.Closed Then
            Else
                cn_audit.Close()
            End If

            cn_audit.ConnectionString = con_String2
            cn_audit.SetPassword("Opens@Db2558")
            cn_audit.Open()

            cmd = New SQLiteCommand($"attach database '{Connection_Path}\{Connection_Data}\aud.db' as aud;", cn_audit)
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            result = False
            MessageBox.Show(ex.Message)
        End Try
    End Function

    Public Function open_MSSQL_Custom_path(Files As String, connn As SQLiteConnection) As Boolean
        Try
            con_String2 = "Data Source=" & Files & ";Version=3;New=False;Pooling=true;Compress=True;"
            If connn.State = ConnectionState.Closed Then
                connn.ConnectionString = con_String2
                connn.SetPassword("Opens@Db2558")
                connn.Open()
                result = True
            Else
                connn.Close()
                connn.ConnectionString = con_String2
                connn.SetPassword("Opens@Db2558")
                connn.Open()
                result = True
            End If
        Catch ex As Exception
            result = False
            MessageBox.Show(ex.Message)
        End Try


        Return result
    End Function
    'સ્ટાર્ટ મેનૂમાં "Edit the system environment variables" સર્ચ કરો અને તેને ખોલો.
    Public Server_Name As String = "sql5097.site4now.net" 'GetEnvironmentVariable("Cryptonix Server")
    Public Server_Database As String = "db_a9a8f3_cryptonix"
    Public Server_UserName As String = "db_a9a8f3_cryptonix_admin"
    Public Server_Password As String = "Opens@Server2558"
    Public Function Online_MSSQL(cn As SqlConnection) As Boolean
        Try
            con_String = $"Server={Server_Name};Database={Server_Database};User Id={Server_UserName};Password={Server_Password}"
            'con_String = String.Format("Server=HIT-WINDOWS;Database=DT_SM;Trusted_Connection=True")
            'con_String = String.Format("Server=192.168.1.11,1433;Database=DT_SM;Trusted_Connection=True")
            cn.ConnectionString = con_String
            cn.Open()
            result = True
        Catch ex As Exception
            result = False
            'MessageBox.Show(ex.Message)
        End Try
        Return result
    End Function
    Public Enum Database_File
        cmp
        cre
        lnk
        rec
        aud
        cfgs
    End Enum
End Module
