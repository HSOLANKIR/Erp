Imports System.ComponentModel
Imports System.Data.SQLite
Imports System.IO
Imports System.Threading.Tasks

Public Class Select_Company_frm
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
        BG_frm.R_3.Text = "F3 : Company Create"
        BG_frm.R_4.Text = "F4 : Import Company"

        BG_frm.B_1.Text = "Enter : Select"
        BG_frm.B_2.Text = "||Enter : Alter Cmp."


        BG_frm.HADE_TXT.Text = "Select Company"
    End Function
    Private Function Add_Hander_Remove_Handel(Ans As Boolean)
        If Ans = True Then
            AddHandler BG_frm.KeyDown, AddressOf Me.R_1_Keedown
            AddHandler BG_frm.R_3.Click, AddressOf Me.R_3_Click
            AddHandler BG_frm.R_4.Click, AddressOf Me.R_4_Click
            AddHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            AddHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
        Else
            RemoveHandler BG_frm.KeyDown, AddressOf Me.R_1_Keedown
            RemoveHandler BG_frm.R_3.Click, AddressOf Me.R_3_Click
            RemoveHandler BG_frm.R_4.Click, AddressOf Me.R_4_Click
            RemoveHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            RemoveHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
        End If
    End Function
    Private Sub R_3_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Cell("Company Information", "", "Create", "")
        End If
    End Sub
    Private Sub R_4_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Cell("Import Company", "", "Create", "")
        End If
    End Sub
    Private Sub R_1_Keedown(sender As Object, e As KeyEventArgs)
        If BG_frm.From_ID = From_ID Then
            If e.KeyCode = Keys.F3 Then
                BG_frm.R_3.PerformClick()
            End If
            If e.KeyCode = Keys.F4 Then
                BG_frm.R_4.PerformClick()
            End If
        End If
    End Sub
    Private Sub B_2_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Select_Comany("Alteration Company")
        End If
    End Sub
    Private Sub B_1_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            'Login_Frm.Dispose()
            Select_Comany("Login Company")

            Login_Frm.Password_TXT.Focus()
            Login_Frm.Password_TXT.Focus()
        End If
    End Sub
    Private Sub Select_Company_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Button_Manage()
        Path_ = Connection_Path
        Path_End = BG_frm.BG_Path_TXT.Text
        Login_YN = False
        'MsgBox("")

        BG_frm.HADE_TXT.Text = "Select Company"
        'BG_frm.BG_Path_TXT.Text = "Select Company"
        Add_Hander_Remove_Handel(True)

        'Load_()

    End Sub
    Private Function Load_()
        Refresh_Col()
        dtt.Rows.Add("", Path_, "", "", "Location")
        Drive_Folder_(Path_)
    End Function
    Private Function Select_dft()
        Dim dft_data As String = Connection_Data
        If dft_data.Trim <> Nothing Then
            dft_data = Connection_Data.Split(".")(0)
        End If
        For Each ro As DataGridViewRow In Grid1.Rows
            If dft_data.ToString <> Nothing Then
                If ro.Cells(2).Value.ToString = (dft_data) Then
                    Grid1.CurrentCell = ro.Cells(1)
                    Exit For
                End If
            End If
        Next
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
            If Msg_Exit_YN("Exit Application") = DialogResult.No Then
                Application.Exit()
                Try
                    'whatsapp_drv.Dispose()
                Catch ex As Exception

                End Try
            End If
        End If
    End Sub
    Private Function Offline_Data() As Boolean
        DataGridView3.DataSource = Nothing
        Try
            Dim FOl As New DirectoryInfo(Search_TXT.Text)
            Dim files As New List(Of IO.DirectoryInfo)(FOl.GetDirectories("*.dt?"))

            BS.DataSource = files
            DataGridView3.DataSource = BS

        Catch ex As Exception
            'BS.Clear()
            Search_TXT.Focus()
            DataGridView3.DataSource = BS
        End Try
        If DataGridView3.Rows.Count = 0 Then
            Msg(NOT_Type.Erro, "Company is Not Found", "")
            Search_TXT.Focus()
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

    Private Sub Search_TXT_TextChanged(sender As Object, e As EventArgs) Handles Search_TXT.TextChanged
        BindingSource1.Filter = $"(CompanyName LIKE '%{Search_TXT.Text.Trim}%') or (Type = 'Defolt' or Type = 'Location')"

        If Grid1.RowCount = 5 Then
            Grid1.Rows(2).Cells(1).Value = Search_TXT.Text
            Grid1.CurrentCell = Grid1.Rows(2).Cells(1)
        Else
            'Grid1.Rows(2).Cells(1).Value = ""
            If Grid1.Rows.Count > 5 Then
                Grid1.CurrentCell = Grid1.Rows(5).Cells(1)
            Else
                'Grid1.CurrentCell = Grid1.Rows(0).Cells(1)
            End If
        End If
        Grid1.Rows(3).Frozen = True
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid1.CellContentClick

    End Sub

    Private Sub DataGridView2_Enter(sender As Object, e As EventArgs) Handles Grid1.Enter
        Search_TXT.Focus()
    End Sub

    Private Sub Search_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles Search_TXT.KeyDown
        If e.KeyCode = Keys.Up Then
            BindingSource1.MovePrevious()
        End If
        If e.KeyCode = Keys.Down Then
            BindingSource1.MoveNext()
        End If
        If e.KeyCode = Keys.PageUp Then
            BindingSource1.MoveFirst()
        End If
        If e.KeyCode = Keys.PageDown Then
            BindingSource1.MoveLast()
        End If

        If e.KeyCode = Keys.Enter AndAlso e.Modifiers = Keys.Control Then
            BG_frm.B_2.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Then
            If Grid1.CurrentRow.Cells(4).Value = "Defolt" Then
                If Grid1.CurrentRow.Cells(3).Value = "Create Company" Then
                    Cell("Company Information", "", "Create", "")

                    Dim path As String = Grid1.Rows(4).Cells(1).Value.ToString
                    If Chck_Directry(path) = True Then
                        Company_Creation_frm.Path_TXT.Text = path
                    End If
                ElseIf Grid1.CurrentRow.Cells(3).Value = "Import Company" Then
                    Cell("Import Company", "", "Create", "")
                ElseIf Grid1.CurrentRow.Cells(3).Value = "Select Remote Company" Then
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
                    Me.Dispose()
                End If
            End If

        End If

        If e.KeyCode = Keys.Back Then
            If Search_TXT.Text = Nothing Then

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

                    If Grid1.RowCount > 5 Then
                        Grid1.CurrentCell = Grid1.Rows(5).Cells(1)
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
            Search_TXT.Text = ""
        End If
    End Function
    Dim back_path As String
    Private Function Drive_Folder_(path As String)
        Refresh_Col()
        back_path = Path_


        If Chck_Directry(path) = True Then
            Path_ = path
        Else
            Path_ = $"{Application.StartupPath}\Data"
        End If

        dtt.Rows.Add("", Path_, "", "", "Location")


        For Each drive As String In Directory.GetDirectories(Path_ & "\")
            Dim folder_name As String
            folder_name = drive.Split("\").Last
            Dim directry As New System.IO.DirectoryInfo(folder_name)

            'If (directry.Attributes <> FileAttributes.Hidden) Then
            If folder_name.Length > 2 Then
                If folder_name.Split(".").Last = "dt" And My.Computer.FileSystem.FileExists(drive & "\cmp.db") = True Then

                    Dim dt As String() = Find_Company_data(drive, folder_name)
                    dtt.Rows.Add(dt(0), dt(1), dt(2), dt(3), dt(4), dt(5))
                Else
                    dtt.Rows.Add("", folder_name, "Folder", "", "Folder")
                End If
            Else
                dtt.Rows.Add("", folder_name, "Folder", "", "Folder")
            End If
            'End If
        Next
        Search_TXT.Text = ""
        If Grid1.RowCount > 5 Then
            Grid1.CurrentCell = Grid1.Rows(5).Cells(1)
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

        Dim r As SQLiteDataReader
        Try
            If open_MSSQL_Custom_path(path_data & "\cmp.db", cn) = True Then
                cmd = New SQLiteCommand($"ATTACH DATABASE '{path_data & "\cre.db"}' As 'cre';
Select *,
(SELECT vc.[date] from cre.TBL_VC vc where vc.Visible <> 'Delete' Order by vc.[Date] DESC LIMIT 1) as Last_date
From TBL_Company_Creation ", cn)
                r = cmd.ExecuteReader
                r.Read()

                version_ = r("DB_Version").ToString

                If version_ <> My.Application.Info.Version.ToString Then
                    warnings_ = $"Migration Required ({version_})"
                Else
                    warnings_ = ""
                End If
                Folder_ = r("Company_ID").ToString '& " Update Requirements"

                id_ = r("Company_ID").ToString
                Name_ = r("CompanyName").ToString

                If Date_Formate(r("Last_date").ToString) <> Nothing Then
                    last_date_ = CDate(r("Last_date").ToString).ToString("dd-MMM-yyyy")
                Else
                    last_date_ = "No Voucher Entry"
                End If
                status_ = "Company"

                If Folder_ <> dt.Split(".").First Then
                    warnings_ &= ",The data has been tampered with"
                End If
                r.Close()
                cmd = New SQLiteCommand($"DETACH DATABASE 'cre'", cn)
                cmd.ExecuteNonQuery()
            End If
            cn.Close()


        Catch ex As Exception
            cn.Close()
            warnings_ &= "," & ex.Message
            id_ = "Error"
            Name_ = "The database has been tampered with"
            Folder_ = "Folder"
            last_date_ = ""
            status_ = "Error"
        End Try


        Return {id_, Name_, Folder_, last_date_, status_, warnings_}
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

        Search_TXT.Text = ""

    End Function
    Private Function Refresh_Col()
        dtt = New DataTable

        dtt.Clear()
        dtt.Columns.Clear()
        dtt.Rows.Clear()

        dtt.Columns.Add("ID")
        dtt.Columns.Add("CompanyName")
        dtt.Columns.Add("Number")
        dtt.Columns.Add("Last Entry")
        dtt.Columns.Add("Type")
        dtt.Columns.Add("Warning/Error")

        dtt.Rows.Add("", "", "", "Create Company", "Defolt")
        dtt.Rows.Add("", "", "", "Import Company", "Defolt")
        dtt.Rows.Add("", "", "", "Specify Path", "Defolt")
        dtt.Rows.Add("", "", "", "Select form Drive", "Defolt")




        BindingSource1.DataSource = dtt
        Grid1.DataSource = BindingSource1
        Grid1.Columns(0).Width = 0
        Grid1.Columns(0).Visible = False
        Grid1.Columns(4).Visible = False

        Grid1.Rows(3).Frozen = True

        Grid1.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Grid1.Columns(1).DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Regular)

        Grid1.Columns(2).Width = 90
        Grid1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Grid1.Columns(2).DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Italic)

        Grid1.Columns(5).DisplayIndex = 3
        Grid1.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Grid1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        Grid1.Columns(5).DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Italic)


        Grid1.Columns(3).Width = 130
        Grid1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Grid1.Columns(3).DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Italic)

        Grid1.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft
        Grid1.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter
        Grid1.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopRight
    End Function
    Private Function Select_Comany(Type_ As String)
        If Grid1.Rows.Count > 0 Then
            Connection_Path = Grid1.Rows(4).Cells(1).Value.ToString
            Company_ID_str = Grid1.CurrentRow.Cells(0).Value.ToString
            Connection_Data = Grid1.CurrentRow.Cells(2).Value.ToString & ".dt"
            Company_Name_str = Grid1.CurrentRow.Cells(1).Value.ToString
            Company_Serial_str = Grid1.CurrentRow.Cells(3).Value.ToString

            My.Settings.Save()

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
        Search_TXT.Focus()

        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.TYP_TXT.Text = ""

        BG_frm.HADE_TXT.Text = "Select Company"
        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text

        Path_ = Connection_Path

        Load_()

        Select_dft()
    End Sub

    Private Sub Select_Company_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        'BG_frm.BG_Path_TXT.Text = Path_End
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

        'For i As Integer = 0 To DataGridView3.RowCount - 1
        '    fol_name = DataGridView3.Rows(i).Cells(1).Value.ToString
        '    fol_number = DataGridView3.Rows(i).Cells(0).Value.ToString

        '    Dim con_01 As New SQLiteConnection()
        '    Dim r As SQLiteDataReader

        '    Try
        '        con_01.ConnectionString = "Data Source=" & fol_name & "\cmp.db;Version=3;"
        '        con_01.Open()
        '        Dim cmd01 As New SQLiteCommand("SELECT * FROM TBL_Company_Creation", con_01)
        '        r = cmd01.ExecuteReader
        '        r.Read()
        '        dtt.Rows.Add(r("Company_ID"), r("CompanyName"), fol_number, r("CompanySerial"))
        '        r.Close()
        '        con_01.Close()
        '    Catch ex As Exception
        '        Try
        '            con_01.Close()
        '        Catch ex1 As Exception
        '            MsgBox(ex.Message)
        '        End Try
        '    End Try
        'Next


        BindingSource1.DataSource = Nothing

        Refresh_Col()

        If Grid1.RowCount = 0 Then
            Search_TXT.Focus()
            Return False
        Else
            Search_TXT.Focus()
            'Grid1.CurrentCell = Grid1.Rows(0).Cells(1)
        End If
        Return True
    End Function
    Private Function Refresh_Load()
        If Offline_Data() = True Then
            Panel4.Location = New Point(Panel3.ClientSize.Width / 2 - Panel4.Size.Width / 2, Panel3.ClientSize.Height / 2 - Panel4.Size.Height / 2)
            'Search_TXT.Enabled = False
            If Fill_data() = True Then
                Search_TXT.Focus()
            End If
        End If
    End Function

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted

    End Sub
    Private Sub Search_TXT_Enter(sender As Object, e As EventArgs) Handles Search_TXT.Enter
        Panel1.Show()
    End Sub

    Private Sub Grid1_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles Grid1.RowsAdded

    End Sub

    Private Sub DataGridView2_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles Grid1.RowPrePaint
        Dim ro As DataGridViewRow = Grid1.Rows(e.RowIndex)
        If ro.Cells(4).Value.ToString = "Location" Then
            ro.DefaultCellStyle.Font = New Font("Arial", 9.5, FontStyle.Bold)
        ElseIf ro.Cells(4).Value.ToString = "Company" Then
            'ro.DefaultCellStyle.Font = New Font(Dft_Font, Dft_Font_Size, FontStyle.Bold)
            ro.DefaultCellStyle.ForeColor = Color.Blue
            ro.DefaultCellStyle.Font = New Font("Arial", 9.5, FontStyle.Bold)
        ElseIf ro.Cells(4).Value.ToString = "Error" Then
            'ro.DefaultCellStyle.Font = New Font(Dft_Font, Dft_Font_Size, FontStyle.Bold)
            ro.DefaultCellStyle.ForeColor = Color.Red
        End If
    End Sub

    Private Sub Grid1_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles Grid1.RowPostPaint
        Dim ro As DataGridViewRow = Grid1.Rows(e.RowIndex)
        Dim blackPen As New Pen(Color.Gainsboro, 1)

        If e.RowIndex = 3 Then
            Dim visibleColumsWidth As Integer = Grid1.Columns.GetColumnsWidth(DataGridViewElementStates.Visible)

            Dim rect = New Rectangle(Grid1.RowHeadersWidth, e.RowBounds.Bottom - 1, visibleColumsWidth, 1)
            e.Graphics.DrawRectangle(Pens.Silver, rect)

        End If


        Dim point1 As New Point(0, Grid1.ColumnHeadersHeight)
        Dim point2 As New Point(Grid1.Width, Grid1.ColumnHeadersHeight)
        e.Graphics.DrawLine(blackPen, point1, point2)

        point1 = New Point(0, 0)
        point2 = New Point(Grid1.Width, 0)
        e.Graphics.DrawLine(blackPen, point1, point2)

    End Sub

    Private Sub Select_Company_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID

        Search_TXT.Focus()
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint
        'obj_top(sender)
    End Sub

    Private Sub Grid1_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid1.KeyDown

    End Sub
End Class