Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Data.SQLite
Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Runtime.InteropServices
Imports System.Device.Location
Imports ExcelDataReader
Imports Microsoft.Office.Interop
Imports Microsoft.Owin
Imports Microsoft.Win32
Imports Newtonsoft.Json.Linq
Imports Tools

Public Class Whatsapp_Home
    Dim Path_End As String
    Private Sub Whatsapp_Home_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Path_End = BG_frm.BG_Path_TXT.Text

        BG_frm.HADE_TXT.Text = "Whatsapp"
        BG_frm.TYP_TXT.Text = ""

        Button_Manage()
        Add_Hander_Remove_Handel(True)

        'Excel_Column = {"Name", "WhatsaApp_No"}
        Excel_Column.Add("Name")
        Excel_Column.Add("WhatsaApp_No")
        Colunm_Set()

        Chack_conn.RunWorkerAsync()


        With Temp_Load_Panel
            .Dock = DockStyle.Fill
            .Hide()
        End With

        With Number_Panel
            .Dock = DockStyle.Fill
            .Show()
        End With
    End Sub

    Private Sub Whatsapp_Home_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub Whatsapp_Home_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.TYP_TXT.Text = ""

        BG_frm.HADE_TXT.Text = "Whatsapp"
        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text
    End Sub

    Private Sub Whatsapp_Home_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End
        Ledger_Branch_Balance.Dispose()
        'Add_Hander_Remove_Handel(False)
        Frm_foCus()
    End Sub
    Private Function Button_Manage()
        Button_Clear()
        BG_frm.B_1.Text = "&E : Exit"
    End Function
    Private Function Add_Hander_Remove_Handel(ans As Boolean)
        If ans = True Then
            AddHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
        Else
            RemoveHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
        End If
    End Function
    Private Sub B_1_Click(sender As Object, e As EventArgs)
        If BG_frm.HADE_TXT.Text = "Whatsapp" Then
            Me.Dispose()
        End If
    End Sub

    Private Sub Grid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid1.CellContentClick

    End Sub
    Private Sub Grid1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles Grid1.CellFormatting
        If Grid1.CurrentCell IsNot Nothing Then
            If e.RowIndex = Grid1.CurrentCell.RowIndex And e.ColumnIndex = Grid1.CurrentCell.ColumnIndex Then
                e.CellStyle.SelectionBackColor = Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(48, Byte), Integer))
            Else
                e.CellStyle.SelectionBackColor = Grid1.DefaultCellStyle.SelectionBackColor
            End If
        End If
    End Sub
    Private Sub Grid_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles Grid1.PreviewKeyDown
        'If e.KeyData = Keys.Enter Then
        '    e.IsInputKey = True
        '    SendKeys.Send("{TAB}")
        'End If
    End Sub
    Private Sub Grid1_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid1.KeyDown

    End Sub
    Dim tbl As DataTableCollection
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs)

    End Sub
    Public Function Fill_excel()
        Grid1.Rows.Clear()

        Dim I_1 As Integer
        Dim I_2 As Integer
        Dim I_3 As Integer

        With Excel_Import_dialoag
            I_1 = .Find_Combobox_TXT(1).SelectedIndex
            I_2 = .Find_Combobox_TXT(2).SelectedIndex
            I_3 = .Find_Combobox_TXT(3).SelectedIndex

            For Each ro As DataGridViewRow In .Grid1.Rows
                Using r As DataGridViewRow = ro
                    Dim S1 As String = Not_Select_(ro, I_1)
                    Dim S2 As String = Not_Select_(ro, I_2)
                    Dim S3 As String = Not_Select_(ro, I_3)
                    Dim co As Integer = Grid1.Rows.Count + 1

                    Grid1.Rows.Add(co, S1, S2, S3, "Pending")
                End Using
            Next
        End With
    End Function
    Private Function Not_Select_(ro As DataGridViewRow, str As Integer)
        If str <> -1 Then
            Return ro.Cells(str).Value.ToString
        Else
            Return ""
        End If
    End Function
    Dim list_ As String()
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim dt As DataTable = tbl(ComboBox1.SelectedItem.ToString())

        Grid1.Columns.Clear()
        Grid1.DataSource = dt

        Dim dt1 = New DataTable
        dt1.Columns.Add("Name")
        dt1.Rows.Add("Not Applicable")

        Dim arry(0 To dt.Columns.Count - 1) As String

        For i As Integer = 0 To dt.Columns.Count - 1
            arry(i) = dt.Columns(i).ToString
        Next
        list_ = arry


        Add_Parameter()
        BindingSource1.DataSource = dt1

    End Sub

    Private Function Chack_Grid() As Boolean
        If Grid1.Rows.Count <= 1 Then
            Msg_Custom_YN(NOT_Location.Center, Color.OrangeRed, My.Resources.Error_animation_icn, Dialoag_Button.Ok, "Input Error", "WhatsApp No.", "Please enter whatsapp number<nl>and try again")
            Grid1.Focus()
            Return False
        End If

        If excel_panel.Visible = True Then
            If ComboBox3.Text = "" Then
                Msg_Custom_YN(NOT_Location.Center, Color.OrangeRed, My.Resources.Error_animation_icn, Dialoag_Button.Ok, "Selection Error", "WhatsApp No.", "Please Select WhatsApp No. Column<nl>and try again")
                ComboBox3.Focus()
                Return False
            End If
        End If

        If t_Message.Checked = True Or t_Button.Checked = True Or t_List.Checked = True Then
            If Message_TXT.Text = Nothing Then
                Msg_Custom_YN(NOT_Location.Center, Color.OrangeRed, My.Resources.Error_animation_icn, Dialoag_Button.Ok, "Input Error", "Message", "Please Enter Message <nl>and try again")
                Message_TXT.Focus()
                Return False
            End If
        End If
        If t_Media.Checked = True Or t_Button.Checked = True Then
            If URL_TXT.Text = Nothing Then
                Msg_Custom_YN(NOT_Location.Center, Color.OrangeRed, My.Resources.Error_animation_icn, Dialoag_Button.Ok, "Input Error", "Attachment", "Please Enter Attachment Details <nl>and try again")
                Return False
            End If
        End If
        If t_Poll.Checked = True Then
            If Txt1.Text = "" Then
                Msg_Custom_YN(NOT_Location.Center, Color.OrangeRed, My.Resources.Error_animation_icn, Dialoag_Button.Ok, "Input Error", "Vote Name", "Please Enter Vote Name <nl>and try again")
                Txt1.Focus()
                Return False
            End If
            If vote_option_panel.Controls.Count <= 1 Then
                Msg_Custom_YN(NOT_Location.Center, Color.OrangeRed, My.Resources.Error_animation_icn, Dialoag_Button.Ok, "Input Error", "Vote Option", "Please Add Vote Option <nl>and try again")
                Return False
            End If
        End If
        If t_Button.Checked = True Then
            If button_option_panel.Controls.Count = 0 Then
                Msg_Custom_YN(NOT_Location.Center, Color.OrangeRed, My.Resources.Error_animation_icn, Dialoag_Button.Ok, "Input Error", "Button", "Please Add Button <nl>and try again")
                Return False
            End If
            Dim P_ As New Queue(Of WhatsApp_Button_Option_ctrl)()
            For Each bg_p As WhatsApp_Button_Option_ctrl In button_option_panel.Controls.OfType(Of WhatsApp_Button_Option_ctrl)()
                P_.Enqueue(bg_p)
            Next

            For Each TX As WhatsApp_Button_Option_ctrl In P_.Reverse
                With TX
                    Dim ty As String = .ComboBox1.Text.ToLower

                    If ty = "reply" Then
                        If .Txt1.Text = Nothing Then
                            Msg_Custom_YN(NOT_Location.Center, Color.OrangeRed, My.Resources.Error_animation_icn, Dialoag_Button.Ok, "Input Error", "Display Text", "Please Enter Display Text <nl>and try again")
                            .Txt1.Focus()
                            Return False
                        End If
                    ElseIf ty = "call" Then
                        If .Txt1.Text = Nothing Then
                            Msg_Custom_YN(NOT_Location.Center, Color.OrangeRed, My.Resources.Error_animation_icn, Dialoag_Button.Ok, "Input Error", "Display Text", "Please Enter Display Text <nl>and try again")
                            .Txt1.Focus()
                            Return False
                        End If
                        If .Txt2.Text = Nothing Then
                            Msg_Custom_YN(NOT_Location.Center, Color.OrangeRed, My.Resources.Error_animation_icn, Dialoag_Button.Ok, "Input Error", "Phone Number", "Please Enter Phone Number <nl>and try again")
                            .Txt2.Focus()
                            Return False
                        End If
                    ElseIf ty = "url" Then
                        If .Txt1.Text = Nothing Then
                            Msg_Custom_YN(NOT_Location.Center, Color.OrangeRed, My.Resources.Error_animation_icn, Dialoag_Button.Ok, "Input Error", "Display Text", "Please Enter Display Text <nl>and try again")
                            .Txt1.Focus()
                            Return False
                        End If
                        If .Txt2.Text = Nothing Then
                            Msg_Custom_YN(NOT_Location.Center, Color.OrangeRed, My.Resources.Error_animation_icn, Dialoag_Button.Ok, "Input Error", "Url", "Please Enter Url <nl>and try again")
                            .Txt2.Focus()
                            Return False
                        End If
                        If Formate_URL(.Txt2.Text) = False Then
                            Msg_Custom_YN(NOT_Location.Center, Color.OrangeRed, My.Resources.Error_animation_icn, Dialoag_Button.Ok, "Input Error", "Url", "Please Enter Valid Url <nl>and try again")
                            .Txt2.Focus()
                            Return False
                        End If
                    ElseIf ty = "copy" Then
                        If .Txt1.Text = Nothing Then
                            Msg_Custom_YN(NOT_Location.Center, Color.OrangeRed, My.Resources.Error_animation_icn, Dialoag_Button.Ok, "Input Error", "Display Text", "Please Enter Display Text <nl>and try again")
                            Txt1.Focus()
                            Return False
                        End If
                        If .Txt2.Text = Nothing Then
                            Msg_Custom_YN(NOT_Location.Center, Color.OrangeRed, My.Resources.Error_animation_icn, Dialoag_Button.Ok, "Input Error", "Copy Text", "Please Enter Copy Text <nl>and try again")
                            .Txt2.Focus()
                            Return False
                        End If
                    End If
                End With
            Next

        End If
        If t_List.Checked = True Then
            If list_section_panel.Controls.Count = 0 Then
                Msg_Custom_YN(NOT_Location.Center, Color.OrangeRed, My.Resources.Error_animation_icn, Dialoag_Button.Ok, "Input Error", "Section", "Please Add Section <nl>and try again")
                Return False
            End If


            Dim P_ As New Queue(Of WhatsApp_List_Section_ctrl)()
            For Each bg_p As WhatsApp_List_Section_ctrl In list_section_panel.Controls.OfType(Of WhatsApp_List_Section_ctrl)()
                P_.Enqueue(bg_p)

                If bg_p.Obj.List_Panel.Controls.Count = 0 Then
                    Msg_Custom_YN(NOT_Location.Center, Color.OrangeRed, My.Resources.Error_animation_icn, Dialoag_Button.Ok, "Input Error", "Menu", "Please Add Menu<nl>and try again")
                    bg_p.Button1.PerformClick()
                    Return False
                End If
            Next

            For Each H1 As WhatsApp_List_Section_ctrl In P_.Reverse
                With H1
                    Dim U_ As New Queue(Of whatsapp_list_menu_ctrl)()
                    For Each bg_p As whatsapp_list_menu_ctrl In H1.Obj.List_Panel.Controls.OfType(Of whatsapp_list_menu_ctrl)()
                        U_.Enqueue(bg_p)
                    Next
                    Dim Id As Integer = 0
                    For Each H2 As whatsapp_list_menu_ctrl In U_.Reverse

                        If H2.Txt1.Text = Nothing Then
                            Msg_Custom_YN(NOT_Location.Center, Color.OrangeRed, My.Resources.Error_animation_icn, Dialoag_Button.Ok, "Input Error", "Menu Title", "Please Enter Menu Title <nl>and try again")
                            H2.Txt1.Focus()
                            H1.Button1.PerformClick()
                            H2.Txt1.Focus()
                            Return False
                        End If
                    Next
                End With
            Next
        End If
        If t_Location.Checked = True Then
            If Txt4.Text = Nothing Then
                Msg_Custom_YN(NOT_Location.Center, Color.OrangeRed, My.Resources.Error_animation_icn, Dialoag_Button.Ok, "Input Error", "Latitude", "Please Enter Latitude <nl>and try again")
                Txt4.Focus()
                Return False
            End If
            If Txt5.Text = Nothing Then
                Msg_Custom_YN(NOT_Location.Center, Color.OrangeRed, My.Resources.Error_animation_icn, Dialoag_Button.Ok, "Input Error", "Longitude", "Please Enter Longitude <nl>and try again")
                Txt5.Focus()
                Return False
            End If
        End If
        If t_Vcard.Checked = True Then
            If Txt7.Text = Nothing Then
                Msg_Custom_YN(NOT_Location.Center, Color.OrangeRed, My.Resources.Error_animation_icn, Dialoag_Button.Ok, "Input Error", "Name", "Please Enter Name <nl>and try again")
                Txt7.Focus()
                Return False
            End If
            If Txt6.Text = Nothing And Txt8.Text = Nothing Then
                Msg_Custom_YN(NOT_Location.Center, Color.OrangeRed, My.Resources.Error_animation_icn, Dialoag_Button.Ok, "Input Error", "Number", "Please Enter Number <nl>and try again")
                Txt6.Focus()
                Return False
            End If
        End If


        Create_Status_Columns()

        Return True

    End Function
    Private Function Create_Status_Columns()
        Dim create_Ststus As Boolean = True
        For Each col As DataGridViewColumn In Grid1.Columns
            If col.HeaderText = "Ststus" Then
                create_Ststus = False
                Exit For
            End If
        Next

        If create_Ststus = True Then
            Grid1.Columns.Add("Ststus", "Ststus")
            Grid1.Columns("Ststus").DefaultCellStyle.NullValue = "Pending"
        End If
    End Function
    Private Sub start_btn_Click(sender As Object, e As EventArgs) Handles start_btn.Click
        If Chack_Grid() = True Then

            start_btn.Visible = False
            Attach_Panel.Enabled = False
            Panel15.Enabled = False
            Grid1.ReadOnly = True
            ComboBox3.Enabled = False


            Stop_ = False
            With Whatsapp_Home_Dialoag
                .Restart_btn.Visible = False
                .Push_btn.Visible = True
                .Stop_btn.Visible = True
                .Start_btn.Visible = False

                .Show()
            End With

            Sending_Background.RunWorkerAsync()
        End If



    End Sub
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        excel_panel.Hide()
        Grid1.DataSource = Nothing

        Grid1.Rows.Clear()
        Grid1.Columns.Clear()

        ColumnToolStripMenuItem.Visible = True
        TemplatesToolStripMenuItem.Visible = True

        Colunm_Set()
    End Sub
    Public Excel_Column As New List(Of String)
    Public Function Colunm_Set()
        Grid1.Columns.Clear()
        For Each s As String In Excel_Column
            Grid1.Columns.Add(s, s)
        Next


        Add_Parameter()
        ComboBox3.Text = "Phone"
        ComboBox3.Text = "PHONE"
        ComboBox3.Text = "WhatsaApp_No"
        ComboBox3.Text = "WhatsaApp"
        ComboBox3.Text = "whatsapp"
        ComboBox3.Text = "WHATSAPP"

    End Function

    Private Sub RadioButton6_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton6.CheckedChanged
        If RadioButton6.Checked = True Then
            Label31.Text = "Enter URL"
            Label26.Visible = False
        End If
    End Sub

    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged
        If RadioButton5.Checked = True Then
            Label31.Text = "Enter Location"
            Label26.Visible = True
        End If
    End Sub

    Private Sub Label26_Click(sender As Object, e As EventArgs) Handles Label26.Click
        Dim OpenFile As New OpenFileDialog()
        Try
            With OpenFile
                .FileName = ""
                .Title = "Attachment:"
                '.Filter = ".db|*.db"
                .Multiselect = False
                If .ShowDialog = True Then
                    URL_TXT.Text = .FileName
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Error...")
        End Try
    End Sub


    Dim duplicat As Integer = 0
    Dim non_whatsapp As Integer = 0
    Dim filter_found As Integer = 0
    Dim invalid As Integer = 0
    Dim blank As Integer = 0
    Dim wh_error As Integer = 0
    Dim Success_ As Integer = 0

    Public Stop_ As Boolean = True
    Public Upload_Attage As Boolean = False
    Private Function Duplicate_Chack(number As String, ro As DataGridViewRow)
        Dim wh_num As Integer = ComboBox3.SelectedIndex

        For i As Integer = ro.Index + 1 To Grid1.Rows.Count - 2
            Dim number1 = (Grid1.Rows(i).Cells(wh_num).Value).ToString.Trim
            If (number = number1) Or ($"91{number}" = number1) Or ($"+91{number}" = number1) Then
                If Grid1.Rows(i).DefaultCellStyle.BackColor <> Color.LightCoral Then
                    Grid1.Rows(i).DefaultCellStyle.BackColor = Color.LightCoral
                    duplicat += 1
                    Grid1.Rows(i).Cells("Ststus").Value = "Duplicate Number"
                End If
            End If
        Next
    End Function

    Private Function Number_Validation(ro As DataGridViewRow) As Boolean
        Dim wh_num As Integer = ComboBox3.SelectedIndex
        Dim number = (ro.Cells(wh_num).Value).ToString.Trim
        Dim ststus_col As DataGridViewCell = ro.Cells("Ststus")
        Dim chcck As Boolean = True

        If t_Channel.Checked = False Then
            If number = Nothing Then
                chcck = False
                ro.DefaultCellStyle.BackColor = Color.LightCoral
                blank += 1
                ststus_col.Value = "Invalid Number"
            ElseIf Val(number).ToString.Length <> 10 Then
                Dim Valid As Boolean = True
                If Val(number).ToString.Length < 10 Then
                    Valid = False
                Else
                    If (Val(number).ToString.Length = 12 And number.ToString.Substring(0, 2) = "91") Or ((number).ToString.Length = 13 And number.ToString.Substring(0, 3) = "+91") Then
                    Else
                        Valid = False
                    End If
                End If

                If Valid = False Then
                    chcck = False
                    ro.DefaultCellStyle.BackColor = Color.LightCoral
                    invalid += 1
                    ststus_col.Value = "Invalid Number"
                End If
            End If
        End If

        'Ckack Duplicate
        If chcck = True Then
            Duplicate_Chack(number, ro)
        End If
        Return chcck
    End Function
    Private Function Number_set_Formate(Number As String) As String
        Dim num As String = ""

        If t_Channel.Checked = False Then
            If Val(Number).ToString.Length = 10 Then
                num = $"91{Number}"
            ElseIf Val(Number).ToString.Length = 12 Then
                num = $"{Number}"
            ElseIf Val(Number).ToString.Length = 13 Then
                num = $"91{Number.Substring(3, 10)}"
            End If
        Else
            num = Number
        End If


        Return num
    End Function
    Dim isenable_dialoag As Boolean = True
    Private Sub Sending_Background_DoWork(sender As Object, e As DoWorkEventArgs) Handles Sending_Background.DoWork
        Dim wh_num As Integer = ComboBox3.SelectedIndex
        Dim wait_count_ As Integer = 0
        Upload_Attage = False
        Sending_Background.ReportProgress(0)
        If Whatsapp_login_YN(Wh_Local_API, Wh_Local_No) = True Then
            isConnected = True
            Dim Upload_st As String = Upload_()
            Upload_Attage = True
            Sending_Background.ReportProgress(1)
            Whatsapp_Home_Dialoag.Label1.Visible = True

            If (t_Media.Checked = True Or t_Button.Checked = True) And RadioButton5.Checked = True Then
                If Upload_st = "" Then
                    isenable_dialoag = False
                    Sending_Background.ReportProgress(0)

                    MessageBox.Show(Upload_Rspons, "File Upload Error!",MessageBoxButtons.OK,MessageBoxIcon.Error)
                    URL_TXT.Focus()
                    Exit Sub
                End If
            End If

            Try
                For Each ro As DataGridViewRow In Grid1.Rows
                    If Stop_ = True Then
                        Exit Sub
                    End If


                    Dim number = (ro.Cells(wh_num).Value).ToString.Trim
                    Dim ststus_col As DataGridViewCell = ro.Cells("Ststus")

                    If ro.DefaultCellStyle.BackColor <> Color.LightCoral And ro.DefaultCellStyle.BackColor <> Color.LightGreen Then
                        Grid1.CurrentCell = ststus_col
                        ststus_col.Value = $"Processing"

                        If Number_Validation(ro) = True Then
                            'Wait 1
                            If CheckBox4.Checked = True Then
                                If ro.DefaultCellStyle.BackColor <> Color.LightCoral Then
                                    ststus_col.Value = $"Wait {NumericUpDown1.Value} Second"
                                    Threading.Thread.Sleep(1000 * NumericUpDown1.Value)
                                End If
                            End If

                            ststus_col.Value = $"Processing"
                            Dim num As String = Number_set_Formate(number)

                            If Pass_Message(ro, num, Upload_st) = True Then
                                wait_count_ += 1
                                Success_ += 1
                            End If

                            'Wait 2
                            If CheckBox5.Checked = True Then
                                If NumericUpDown3.Value = wait_count_ Then
                                    ro.Cells("Ststus").Value = $"Wait {NumericUpDown2.Value} Second"
                                    wait_count_ = 0
                                    Threading.Thread.Sleep(1000 * NumericUpDown2.Value)
                                End If
                            End If
                        End If
                    End If

                    Sending_Background.ReportProgress(ro.Index)
                Next

            Catch ex As Exception

            End Try

            If Upload_st.ToString <> Nothing Then
                Whatsapp_delete_file(Upload_st)
            End If
        Else
            isConnected = False
            Msg_Custom_YN(NOT_Location.Center, Color.LightCoral, My.Resources.Server_connection_animation_gof, Dialoag_Button.Ok, "Server Error", "WhatsApp", "WhatsApp Server is not connected,<nl>Please connect to whatsapp server and try again")
            Threading.Thread.Sleep(1500)
        End If

    End Sub
    Private Function Pass_Message(ro As DataGridViewRow, num As String, Media_url As String) As Boolean
        If t_Message.Checked = True Then
            Return Message_(ro, num)
        End If
        If t_Media.Checked = True Then
            Return Media_(ro, num, Media_url)
        End If
        If t_Channel.Checked = True Then
            Return Channel_(ro, num)
        End If
        If t_Poll.Checked = True Then
            Return Poll_(ro, num)
        End If
        If t_Button.Checked = True Then
            Return Button_(ro, num, Media_url)
        End If
        If t_List.Checked = True Then
            Return List_Msg_(ro, num)
        End If
        If t_Location.Checked = True Then
            Return Location_(ro, num)
        End If
        If t_Vcard.Checked = True Then
            Return Vcard_(ro, num)
        End If
    End Function
    Private Function Vcard_(ro As DataGridViewRow, phone As String)
        Dim url As New String($"https://wh.cryptonixtechnology.in/send-vcard")

        'Pass Data on API
        Try
            Dim postParameters As New List(Of KeyValuePair(Of String, String))

            postParameters.Add(New KeyValuePair(Of String, String)("api_key", Wh_Local_API))
            postParameters.Add(New KeyValuePair(Of String, String)("sender", Wh_Local_No))
            postParameters.Add(New KeyValuePair(Of String, String)("number", phone))

            postParameters.Add(New KeyValuePair(Of String, String)("name", Txt7.Text))
            postParameters.Add(New KeyValuePair(Of String, String)("number", Txt6.Text))
            postParameters.Add(New KeyValuePair(Of String, String)("phone", Txt8.Text))

            Dim result As String() = Pass_API(url, postParameters)

            ro.Cells("Ststus").Value = result(1)
            If result(0).ToLower = "true" Then
                ro.DefaultCellStyle.BackColor = Color.LightGreen
                Return True
            Else
                ro.DefaultCellStyle.BackColor = Color.LightCoral
                wh_error += 1
                Return False
            End If

        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function Location_(ro As DataGridViewRow, phone As String)
        Dim url As New String($"https://wh.cryptonixtechnology.in/send-location")

        'Pass Data on API
        Try
            Dim postParameters As New List(Of KeyValuePair(Of String, String))

            postParameters.Add(New KeyValuePair(Of String, String)("api_key", Wh_Local_API))
            postParameters.Add(New KeyValuePair(Of String, String)("sender", Wh_Local_No))
            postParameters.Add(New KeyValuePair(Of String, String)("number", phone))
            postParameters.Add(New KeyValuePair(Of String, String)("latitude", Txt4.Text))
            postParameters.Add(New KeyValuePair(Of String, String)("longitude", Txt5.Text))

            Dim result As String() = Pass_API(url, postParameters)

            ro.Cells("Ststus").Value = result(1)
            If result(0).ToLower = "true" Then
                ro.DefaultCellStyle.BackColor = Color.LightGreen
                Return True
            Else
                ro.DefaultCellStyle.BackColor = Color.LightCoral
                wh_error += 1
                Return False
            End If

        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function List_Msg_(ro As DataGridViewRow, phone As String)
        Dim url As New String($"https://wh.cryptonixtechnology.in/send-list")
        'Set Parameter in Message
        Dim msg As String = ""
        msg = Message_TXT.Text
        For Each cl As DataGridViewColumn In Grid1.Columns
            Dim paramter = ro.Cells(cl.Index).Value
            Dim str As String = If(paramter IsNot Nothing, paramter.ToString(), "")
            msg = msg.Replace("{{" & cl.HeaderText & "}}", str)
        Next

        'Set Parameter in Footer
        Dim footer As String = ""
        footer = footer_txt.Text
        For Each cl As DataGridViewColumn In Grid1.Columns
            Dim paramter = ro.Cells(cl.Index).Value
            Dim str As String = If(paramter IsNot Nothing, paramter.ToString(), "")
            footer = footer.Replace("{{" & cl.HeaderText & "}}", str)
        Next

        'Pass Data on API
        Try
            Dim postParameters As New List(Of KeyValuePair(Of String, String))

            postParameters.Add(New KeyValuePair(Of String, String)("api_key", Wh_Local_API))
            postParameters.Add(New KeyValuePair(Of String, String)("sender", Wh_Local_No))
            postParameters.Add(New KeyValuePair(Of String, String)("number", phone))

            postParameters.Add(New KeyValuePair(Of String, String)("name", Txt2.Text))

            postParameters.Add(New KeyValuePair(Of String, String)("message", msg))
            postParameters.Add(New KeyValuePair(Of String, String)("footer", footer))

            postParameters.Add(New KeyValuePair(Of String, String)("title", "title list"))
            postParameters.Add(New KeyValuePair(Of String, String)("buttontext", Txt3.Text))

            Dim c As Integer = 0
            Dim P_ As New Queue(Of WhatsApp_List_Section_ctrl)()
            For Each bg_p As WhatsApp_List_Section_ctrl In list_section_panel.Controls.OfType(Of WhatsApp_List_Section_ctrl)()
                P_.Enqueue(bg_p)
            Next

            For Each H1 As WhatsApp_List_Section_ctrl In P_.Reverse
                With H1
                    postParameters.Add(New KeyValuePair(Of String, String)($"sections[{c}][title]", H1.Txt1.Text))

                    Dim U_ As New Queue(Of whatsapp_list_menu_ctrl)()
                    For Each bg_p As whatsapp_list_menu_ctrl In H1.Obj.List_Panel.Controls.OfType(Of whatsapp_list_menu_ctrl)()
                        U_.Enqueue(bg_p)
                    Next
                    Dim Id As Integer = 0
                    For Each H2 As whatsapp_list_menu_ctrl In U_.Reverse
                        postParameters.Add(New KeyValuePair(Of String, String)($"sections[{c}][rows][{Id}][title]", H2.Txt1.Text))
                        postParameters.Add(New KeyValuePair(Of String, String)($"sections[{c}][rows][{Id}][description]", H2.Txt2.Text))
                        Id += 1
                    Next
                    c += 1
                End With
            Next

            Dim result As String() = Pass_API(url, postParameters)

            ro.Cells("Ststus").Value = result(1)
            If result(0).ToLower = "true" Then
                ro.DefaultCellStyle.BackColor = Color.LightGreen
                Return True
            Else
                ro.DefaultCellStyle.BackColor = Color.LightCoral
                wh_error += 1
                Return False
            End If

        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function Button_(ro As DataGridViewRow, phone As String, Media_url As String)
        Dim url As New String($"https://wh.cryptonixtechnology.in/send-button")
        'Set Parameter in Message
        Dim msg As String = ""
        msg = Message_TXT.Text
        For Each cl As DataGridViewColumn In Grid1.Columns
            Dim paramter = ro.Cells(cl.Index).Value
            Dim str As String = If(paramter IsNot Nothing, paramter.ToString(), "")
            msg = msg.Replace("{{" & cl.HeaderText & "}}", str)
        Next

        'Set Parameter in Footer
        Dim footer As String = ""
        footer = footer_txt.Text
        For Each cl As DataGridViewColumn In Grid1.Columns
            Dim paramter = ro.Cells(cl.Index).Value
            Dim str As String = If(paramter IsNot Nothing, paramter.ToString(), "")
            footer = footer.Replace("{{" & cl.HeaderText & "}}", str)
        Next

        'Attach Set
        Dim file_ As String = ""
        If RadioButton5.Checked = True Then
            file_ = $"https://wh.cryptonixtechnology.in/public/Resource/{Media_url}"
        Else
            file_ = URL_TXT.Text
        End If

        'Pass Data on API
        Try
            Dim postParameters As New List(Of KeyValuePair(Of String, String))

            postParameters.Add(New KeyValuePair(Of String, String)("api_key", Wh_Local_API))
            postParameters.Add(New KeyValuePair(Of String, String)("sender", Wh_Local_No))
            postParameters.Add(New KeyValuePair(Of String, String)("number", phone))

            postParameters.Add(New KeyValuePair(Of String, String)("message", msg))
            postParameters.Add(New KeyValuePair(Of String, String)("footer", footer))
            postParameters.Add(New KeyValuePair(Of String, String)("url", file_))

            Dim c As Integer = 0
            Dim P_ As New Queue(Of WhatsApp_Button_Option_ctrl)()
            For Each bg_p As WhatsApp_Button_Option_ctrl In button_option_panel.Controls.OfType(Of WhatsApp_Button_Option_ctrl)()
                P_.Enqueue(bg_p)
            Next

            For Each TX As WhatsApp_Button_Option_ctrl In P_.Reverse
                With TX
                    Dim ty As String = .ComboBox1.Text.ToLower
                    If ty = "reply" Then
                        postParameters.Add(New KeyValuePair(Of String, String)($"button[{c}][type]", ty))
                        postParameters.Add(New KeyValuePair(Of String, String)($"button[{c}][displayText]", TX.Txt1.Text))
                    ElseIf ty = "call" Then
                        postParameters.Add(New KeyValuePair(Of String, String)($"button[{c}][type]", ty))
                        postParameters.Add(New KeyValuePair(Of String, String)($"button[{c}][displayText]", TX.Txt1.Text))
                        postParameters.Add(New KeyValuePair(Of String, String)($"button[{c}][phoneNumber]", TX.Txt2.Text))
                    ElseIf ty = "url" Then
                        postParameters.Add(New KeyValuePair(Of String, String)($"button[{c}][type]", ty))
                        postParameters.Add(New KeyValuePair(Of String, String)($"button[{c}][displayText]", TX.Txt1.Text))
                        postParameters.Add(New KeyValuePair(Of String, String)($"button[{c}][url]", TX.Txt2.Text))
                    ElseIf ty = "copy" Then
                        postParameters.Add(New KeyValuePair(Of String, String)($"button[{c}][type]", ty))
                        postParameters.Add(New KeyValuePair(Of String, String)($"button[{c}][displayText]", TX.Txt1.Text))
                        postParameters.Add(New KeyValuePair(Of String, String)($"button[{c}][copyText]", TX.Txt2.Text))
                    End If
                    c += 1
                End With
            Next

            Dim result As String() = Pass_API(url, postParameters)

            ro.Cells("Ststus").Value = result(1)
            If result(0).ToLower = "true" Then
                ro.DefaultCellStyle.BackColor = Color.LightGreen
                Return True
            Else
                ro.DefaultCellStyle.BackColor = Color.LightCoral
                wh_error += 1
                Return False
            End If

        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function Poll_(ro As DataGridViewRow, phone As String)
        Dim url As New String($"https://wh.cryptonixtechnology.in/send-poll")

        'Pass Data on API
        Try
            Dim postParameters As New List(Of KeyValuePair(Of String, String))

            postParameters.Add(New KeyValuePair(Of String, String)("api_key", Wh_Local_API))
            postParameters.Add(New KeyValuePair(Of String, String)("sender", Wh_Local_No))
            postParameters.Add(New KeyValuePair(Of String, String)("number", phone))
            postParameters.Add(New KeyValuePair(Of String, String)("name", Txt1.Text))

            If CheckBox1.Checked = True Then
                postParameters.Add(New KeyValuePair(Of String, String)("countable", "0".Trim))
            Else
                postParameters.Add(New KeyValuePair(Of String, String)("countable", "1".Trim))
            End If
            Dim c As Integer = 0
            Dim P_ As New Queue(Of WhatsApp_poll_Option_ctrl)()
            For Each bg_p As WhatsApp_poll_Option_ctrl In vote_option_panel.Controls.OfType(Of WhatsApp_poll_Option_ctrl)()
                P_.Enqueue(bg_p)
            Next

            For Each TX As WhatsApp_poll_Option_ctrl In P_.Reverse
                postParameters.Add(New KeyValuePair(Of String, String)($"option[{c}]", TX.Txt1.Text))
                c += 1
            Next

            Dim result As String() = Pass_API(url, postParameters)

            ro.Cells("Ststus").Value = result(1)
            If result(0).ToLower = "true" Then
                ro.DefaultCellStyle.BackColor = Color.LightGreen
                Return True
            Else
                ro.DefaultCellStyle.BackColor = Color.LightCoral
                wh_error += 1
                Return False
            End If

        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function Channel_(ro As DataGridViewRow, phone As String)
        Dim url As New String($"https://wh.cryptonixtechnology.in/send-text-channel")

        'Set Parameter in Message
        Dim msg As String = ""
        msg = Message_TXT.Text
        For Each cl As DataGridViewColumn In Grid1.Columns
            Dim paramter = ro.Cells(cl.Index).Value
            Dim str As String = If(paramter IsNot Nothing, paramter.ToString(), "")
            msg = msg.Replace("{{" & cl.HeaderText & "}}", str)
        Next

        'Set Parameter in Footer
        Dim footer As String = ""
        footer = footer_txt.Text
        For Each cl As DataGridViewColumn In Grid1.Columns
            Dim paramter = ro.Cells(cl.Index).Value
            Dim str As String = If(paramter IsNot Nothing, paramter.ToString(), "")
            footer = footer.Replace("{{" & cl.HeaderText & "}}", str)
        Next

        'Pass Data on API
        Try
            Dim postParameters As New List(Of KeyValuePair(Of String, String))

            Dim postdata As New JObject
            postParameters.Add(New KeyValuePair(Of String, String)("api_key", Wh_Local_API))
            postParameters.Add(New KeyValuePair(Of String, String)("sender", Wh_Local_No))
            postParameters.Add(New KeyValuePair(Of String, String)("url", phone))
            postParameters.Add(New KeyValuePair(Of String, String)("footer", footer))
            postParameters.Add(New KeyValuePair(Of String, String)("message", msg))

            Dim result As String() = Pass_API(url, postParameters)

            ro.Cells("Ststus").Value = result(1)
            If result(0).ToLower = "true" Then
                ro.DefaultCellStyle.BackColor = Color.LightGreen
                Return True
            Else
                ro.DefaultCellStyle.BackColor = Color.LightCoral
                wh_error += 1
                Return False
            End If

        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function Media_(ro As DataGridViewRow, phone As String, Media_url As String)
        Dim url As New String($"https://wh.cryptonixtechnology.in/send-media")

        'Set Parameter in Message
        Dim msg As String = ""
        msg = Message_TXT.Text
        For Each cl As DataGridViewColumn In Grid1.Columns
            Dim paramter = ro.Cells(cl.Index).Value
            Dim str As String = If(paramter IsNot Nothing, paramter.ToString(), "")
            msg = msg.Replace("{{" & cl.HeaderText & "}}", str)
        Next

        'Set Parameter in Footer
        Dim footer As String = ""
        footer = footer_txt.Text
        For Each cl As DataGridViewColumn In Grid1.Columns
            Dim paramter = ro.Cells(cl.Index).Value
            Dim str As String = If(paramter IsNot Nothing, paramter.ToString(), "")
            footer = footer.Replace("{{" & cl.HeaderText & "}}", str)
        Next

        'Attach Set
        Dim file_ As String = ""
        If RadioButton5.Checked = True Then
            file_ = $"https://wh.cryptonixtechnology.in/public/Resource/{Media_url}"
        Else
            file_ = URL_TXT.Text
        End If


        'Media Type
        Dim doc_type As String = ""
        If RadioButton1.Checked = True Then
            doc_type = "image"
        End If
        If RadioButton2.Checked = True Then
            doc_type = "video"
        End If
        If RadioButton4.Checked = True Then
            doc_type = "document"
        End If
        If RadioButton3.Checked = True Then
            doc_type = "audio"
        End If
        'Pass Data on API
        Try

            Dim postParameters As New List(Of KeyValuePair(Of String, String))


            postParameters.Add(New KeyValuePair(Of String, String)("api_key", Wh_Local_API))
            postParameters.Add(New KeyValuePair(Of String, String)("sender", Wh_Local_No))
            postParameters.Add(New KeyValuePair(Of String, String)("number", phone))
            postParameters.Add(New KeyValuePair(Of String, String)("footer", footer))
            postParameters.Add(New KeyValuePair(Of String, String)("media_type", doc_type))
            postParameters.Add(New KeyValuePair(Of String, String)("caption", msg))
            postParameters.Add(New KeyValuePair(Of String, String)("url", file_))

            Dim result As String() = Pass_API(url, postParameters)

            ro.Cells("Ststus").Value = result(1)
            If result(0).ToLower = "true" Then
                ro.DefaultCellStyle.BackColor = Color.LightGreen
                Return True
            Else
                ro.DefaultCellStyle.BackColor = Color.LightCoral
                wh_error += 1
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try

    End Function
    Private Function Message_(ro As DataGridViewRow, phone As String)
        Dim url As New String($"https://wh.cryptonixtechnology.in/send-message")

        'Set Parameter in Message
        Dim msg As String = ""
        msg = Message_TXT.Text
        For Each cl As DataGridViewColumn In Grid1.Columns
            Dim paramter As Object = ro.Cells(cl.Index).Value
            Dim str As String = If(paramter IsNot Nothing, paramter.ToString(), "")
            msg = msg.Replace("{{" & cl.HeaderText & "}}", str)
        Next

        'Set Parameter in Footer
        Dim footer As String = ""
        footer = footer_txt.Text
        For Each cl As DataGridViewColumn In Grid1.Columns
            Dim paramter = ro.Cells(cl.Index).Value
            Dim str As String = If(paramter IsNot Nothing, paramter.ToString(), "")
            footer = footer.Replace("{{" & cl.HeaderText & "}}", str)
        Next

        'Pass Data on API
        Try
            Dim postParameters As New List(Of KeyValuePair(Of String, String))

            postParameters.Add(New KeyValuePair(Of String, String)("api_key", Wh_Local_API))
            postParameters.Add(New KeyValuePair(Of String, String)("sender", Wh_Local_No))
            postParameters.Add(New KeyValuePair(Of String, String)("number", phone))
            postParameters.Add(New KeyValuePair(Of String, String)("footer", footer))
            postParameters.Add(New KeyValuePair(Of String, String)("message", msg))

            Dim result As String() = Pass_API(url, postParameters)

            ro.Cells("Ststus").Value = result(1)
            If result(0).ToLower = "true" Then
                ro.DefaultCellStyle.BackColor = Color.LightGreen
                Return True
            Else
                ro.DefaultCellStyle.BackColor = Color.LightCoral
                wh_error += 1
                Return False
            End If

        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function Pass_API(url As String, postParameters As List(Of KeyValuePair(Of String, String))) As String()
        Dim content As New FormUrlEncodedContent(postParameters)
        Dim status As String = "false"
        Dim msg As String = ""

        Try
            Using httpClient As New HttpClient()
                Dim response As HttpResponseMessage = httpClient.PostAsync(url, content).GetAwaiter().GetResult()
                response.EnsureSuccessStatusCode()
                Dim responseBody As String = response.Content.ReadAsStringAsync().GetAwaiter().GetResult()

                Dim r = JObject.Parse(responseBody)
                status = r.Item("status").ToString
                msg = r.Item("msg").ToString
            End Using
        Catch ex As Exception
            status = "false"
            msg = ex.Message

        End Try

        Return {status, msg}

    End Function
    Private Function Upload_() As String
        Dim st As String = ""
        If t_Media.Checked = True Or t_Button.Checked = True Then
            If RadioButton5.Checked = True Then
                Try
                    st = Whatsapp_Upload_file(URL_TXT.Text)
                Catch ex As Exception
                    st = ""
                    MessageBox.Show(ex.Message, "File Upload Error")
                End Try
            End If
        End If

        Return st
    End Function
    Private Sub Sending_Background_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles Sending_Background.ProgressChanged
        If isenable_dialoag = False Then
            Whatsapp_Home_Dialoag.Dispose()
            isenable_dialoag = True
        End If

        With Whatsapp_Home_Dialoag
            If Upload_Attage = True Then
                .Upload_Panel.Visible = False
                .Sending_panel.Visible = True
            Else
                .Upload_Panel.Visible = True
                .Sending_panel.Visible = False
            End If


            .Label18.Text = Grid1.Rows.Count - 1
            .Label21.Text = duplicat
            .Label6.Text = blank
            .Label10.Text = invalid
            .Label13.Text = wh_error
            .Label22.Text = Success_



            .ProgressBag_Custom1.Maximum = Grid1.Rows.Count - 1

            .ProgressBag_Custom1.Value = e.ProgressPercentage
            .ProgressBag_Custom1.Run(0)

            .Label3.Text = $"{N2_FORMATE((Val(e.ProgressPercentage) * 100) / Val(.ProgressBag_Custom1.Maximum))} %"
        End With

    End Sub

    Private Sub Sending_Background_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles Sending_Background.RunWorkerCompleted

        start_btn.Visible = True

        If Stop_ = False Then
            Stop_Msg()
            With Whatsapp_Home_Dialoag
                .Restart_btn.Visible = True
                .Push_btn.Visible = False
                .Stop_btn.Visible = False
                .Start_btn.Visible = False
            End With
        Else
            With Whatsapp_Home_Dialoag
                .Restart_btn.Visible = True
                .Push_btn.Visible = False
                .Stop_btn.Visible = True
                .Start_btn.Visible = True
            End With
        End If

    End Sub

    Private Sub Label28_Click(sender As Object, e As EventArgs) Handles Label28.Click

    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub Label34_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Grid1_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles Grid1.RowsAdded
        Whatsapp_Home_Dialoag.Label18.Text = $"{Grid1.Rows.Count - 1}"
        Label6.Text = $"Total Rows {Grid1.Rows.Count - 1}"
    End Sub

    Private Sub Grid1_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles Grid1.RowsRemoved
        Whatsapp_Home_Dialoag.Label18.Text = $"{Grid1.Rows.Count - 1}"
        Label6.Text = $"Total Rows {Grid1.Rows.Count - 1}"
    End Sub

    Dim isConnected As Boolean = False
    Private Sub Chack_conn_DoWork(sender As Object, e As DoWorkEventArgs) Handles Chack_conn.DoWork
        Try
            PictureBox12.Image = My.Resources.Loding_Progress
            Label1.Text = "Chacking..."
            Label1.ForeColor = Color.OrangeRed

            If Whatsapp_login_YN(Wh_Local_API, Wh_Local_No) = True Then
                PictureBox12.Image = My.Resources.whatsapp_enable_icn
                Label1.Text = "Connected"
                Label1.ForeColor = Color.Green
                isConnected = True
            Else
                PictureBox12.Image = My.Resources.whatsapp_disable_icn
                Label1.Text = "Disconnected"
                Label1.ForeColor = Color.Red
                isConnected = False
            End If
        Catch ex As Exception
            PictureBox12.Image = My.Resources.whatsapp_disable_icn
            Label1.Text = "Disconnected"
            Label1.ForeColor = Color.Red
            isConnected = False
        End Try
    End Sub

    Private Sub PictureBox12_Click(sender As Object, e As EventArgs) Handles PictureBox12.Click
        Chack_conn.RunWorkerAsync()
    End Sub

    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.CheckedChanged
        NumericUpDown1.Enabled = CheckBox4.Checked
    End Sub

    Private Sub CheckBox5_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox5.CheckedChanged
        NumericUpDown2.Enabled = CheckBox5.Checked
        NumericUpDown3.Enabled = CheckBox5.Checked
    End Sub

    Private Sub stop_btn_Click(sender As Object, e As EventArgs)
        start_btn.Visible = True

        Sending_Background.CancelAsync()
    End Sub

    Private Sub PictureBox13_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Grid1_ColumnAdded(sender As Object, e As DataGridViewColumnEventArgs) Handles Grid1.ColumnAdded
        e.Column.DefaultCellStyle.NullValue = ""
    End Sub
    Public Function Add_Parameter()
        FlowLayoutPanel1.Controls.Clear()
        ComboBox3.Items.Clear()

        For Each c As DataGridViewColumn In Grid1.Columns
            Dim btn_ As Windows.Forms.Button = New Windows.Forms.Button
            With btn_
                .AutoSize = True
                .AutoSizeMode = AutoSizeMode.GrowAndShrink
                .BackColor = Color.LightYellow
                .FlatStyle = FlatStyle.Flat
                .Text = c.HeaderText
                .TextAlign = ContentAlignment.MiddleLeft
                .UseVisualStyleBackColor = False

                AddHandler .Click, AddressOf Parameter_Click
            End With
            FlowLayoutPanel1.Controls.Add(btn_)

            ComboBox3.Items.Add(c.HeaderText)
        Next
    End Function

    Private Sub Parameter_Click(sender As Object, e As EventArgs)
        Message_TXT.Text &= "{{" & sender.Text & "}}"
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub
    Public Function Push_Msg()
        Stop_ = True
    End Function
    Public Function Stop_Msg()
        Stop_ = True

        duplicat = 0
        invalid = 0
        blank = 0
        wh_error = 0
        Success_ = 0
        non_whatsapp = 0
        filter_found = 0

        Whatsapp_Home_Dialoag.ProgressBag_Custom1.Value = 0
        Whatsapp_Home_Dialoag.ProgressBag_Custom1.Run(0)
        Whatsapp_Home_Dialoag.Label3.Text = ""

        Panel15.Enabled = True
        Attach_Panel.Enabled = True
        Grid1.ReadOnly = False
        start_btn.Visible = True
        ComboBox3.Enabled = True


        Grid1.CurrentCell = Grid1.Rows(0).Cells("Ststus")

    End Function
    Public Function Restart_Msg()
        Stop_Msg()

        For Each ro As DataGridViewRow In Grid1.Rows
            ro.DefaultCellStyle.BackColor = Grid1.BackgroundColor
            ro.Cells("Ststus").Value = "Pending"
        Next

        With Whatsapp_Home_Dialoag
            .Label18.Text = Grid1.Rows.Count - 1
            .Label21.Text = duplicat
            .Label6.Text = blank
            .Label10.Text = invalid
            .Label13.Text = wh_error
            .Label22.Text = Success_
        End With
    End Function

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged

    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs)

    End Sub



    Private Sub Excel_Export_DoWork(sender As Object, e As DoWorkEventArgs) Handles Excel_Export.DoWork
        Dim xlApp As Microsoft.Office.Interop.Excel.Application
        Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
        Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value
        Dim i As Integer
        Dim j As Integer

        xlApp = New Microsoft.Office.Interop.Excel.Application
        xlWorkBook = xlApp.Workbooks.Add(misValue)
        xlWorkSheet = xlWorkBook.Sheets("sheet1")


        For i = 0 To Grid1.RowCount - 2
            For j = 0 To Grid1.ColumnCount - 1
                For k As Integer = 1 To Grid1.Columns.Count
                    xlWorkSheet.Cells(1, k) = Grid1.Columns(k - 1).HeaderText
                    xlWorkSheet.Cells(i + 2, j + 1) = Grid1(j, i).Value.ToString()
                Next
            Next
            Excel_Export.ReportProgress(i)
        Next

        xlWorkSheet.SaveAs(Export_Path)
        xlWorkBook.Close()
        xlApp.Quit()

        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(xlWorkSheet)

    End Sub
    Private Sub releaseObject(ByVal obj As Object)
        Try
            Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub Excel_Export_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles Excel_Export.ProgressChanged
        With Progressbar_Box

            .Progress.Value = e.ProgressPercentage
            .Progress.Run(0)

            .count_label.Text = $"{N2_FORMATE((Val(e.ProgressPercentage) * 100) / Val(.Progress.Maximum))} %"
        End With
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Grid1.Rows.Count <= 1 Then
            Msg_Custom_YN(NOT_Location.Center, Color.OrangeRed, My.Resources.Error_animation_icn, Dialoag_Button.Ok, "Input Error", "WhatsApp No.", "Please enter whatsapp number<nl>and try again")
            Grid1.Focus()
            Exit Sub
        End If

        If excel_panel.Visible = True Then
            If ComboBox3.Text = "" Then
                Msg_Custom_YN(NOT_Location.Center, Color.OrangeRed, My.Resources.Error_animation_icn, Dialoag_Button.Ok, "Selection Error", "WhatsApp No.", "Please Select WhatsApp No. Column<nl>and try again")
                ComboBox3.Focus()
                Exit Sub
            End If
        End If

        Create_Status_Columns()

        ComboBox3.Enabled = False
        start_btn.Visible = False
        Attach_Panel.Enabled = False
        Panel15.Enabled = False
        Grid1.ReadOnly = True

        Stop_ = False
        With Whatsapp_No_Chack_Dialoag
            .Stop_btn.Visible = False
            .Start_btn.Visible = True

            .Show()
        End With

        'Chack_Background.RunWorkerAsync()
    End Sub
    Public String_Filter_ As String = True
    Public Valid_Filter_ As Boolean = True
    Public Reject_Filter_ As Boolean = True
    Public Filter_Column_ As Integer = 0

    Public Chack_Filter_ As Boolean = True
    Public Chack_duplicat_ As Boolean = True
    Public Chack_blank_ As Boolean = True
    Public Chack_invalid_ As Boolean = True
    Public Chack_whatsapp_ As Boolean = True

    Private Sub Chack_Background_DoWork(sender As Object, e As DoWorkEventArgs) Handles Chack_Background.DoWork

        For Each ro As DataGridViewRow In Grid1.Rows
            ro.DefaultCellStyle.BackColor = Grid1.BackgroundColor
            ro.Cells("Ststus").Value = "Pending"
            Chack_Background.ReportProgress(ro.Index)
        Next


        Dim wh_num As Integer = ComboBox3.SelectedIndex
        Dim count_success_ As Integer = 0
        Dim list_ As New List(Of DataGridViewRow)

        Try

            For Each ro As DataGridViewRow In Grid1.Rows
                If Stop_ = True Then
                    Exit Sub
                End If
                'System.Threading.Thread.Sleep(1)

                Dim number = (ro.Cells(wh_num).Value).ToString.Trim
                Dim chcck As Boolean = True
                Dim ststus_col As DataGridViewCell = ro.Cells("Ststus")


                If ro.DefaultCellStyle.BackColor <> Color.LightCoral And ro.DefaultCellStyle.BackColor <> Color.LightGreen Then
                    If number = Nothing Then
                        If Chack_blank_ = True Then
                            chcck = False
                            ro.DefaultCellStyle.BackColor = Color.LightCoral
                            blank += 1
                            ststus_col.Value = "Blank Number"
                            list_.Add(ro)
                        End If
                    ElseIf Val(number).ToString.Length <> 10 Then
                        Dim Valid As Boolean = True
                        If Chack_invalid_ = True Then
                            If Val(number).ToString.Length < 10 Then
                                Valid = False
                            Else
                                If (Val(number).ToString.Length = 12 And number.ToString.Substring(0, 2) = "91") Or ((number).ToString.Length = 13 And number.ToString.Substring(0, 3) = "+91") Then
                                Else
                                    Valid = False
                                End If
                            End If
                        End If
                        If Valid = False Then
                            chcck = False
                            ro.DefaultCellStyle.BackColor = Color.LightCoral
                            invalid += 1
                            ststus_col.Value = "Invalid Number"
                            list_.Add(ro)
                        End If
                    ElseIf Val(number).ToString.Substring(0, 1) < 6 Then
                        If Chack_invalid_ = True Then
                            chcck = False
                            ro.DefaultCellStyle.BackColor = Color.LightCoral
                            invalid += 1
                            ststus_col.Value = "Invalid Number"
                            list_.Add(ro)
                        End If
                    End If

                    If chcck = True Then
                        'Chack Filter
                        If Chack_Filter_ = True Then
                            Dim str = ro.Cells(Filter_Column_).Value.ToString
                            If CountCharacter(str.ToString.Trim, String_Filter_.Trim) <> 0 Then
                                If Reject_Filter_ = True Then
                                    ro.DefaultCellStyle.BackColor = Color.LightCoral
                                    filter_found += 1
                                    ststus_col.Value = "Filter Found"
                                End If
                            ElseIf valid_Filter_ = True Then
                                ro.DefaultCellStyle.BackColor = Color.LightCoral
                                filter_found += 1
                                ststus_col.Value = "Filter Found"
                            End If
                        End If

                        'Chack Duplicate
                        If Chack_duplicat_ = True And ro.DefaultCellStyle.BackColor <> Color.LightCoral Then
                            For i As Integer = ro.Index + 1 To Grid1.Rows.Count - 2
                                Dim number1 = (Grid1.Rows(i).Cells(wh_num).Value).ToString.Trim
                                If (number = number1) Or (($"91{number1}" = number) Or ($"+91{number1}" = number)) Or (($"91{number}" = number1) Or ($"+91{number}" = number1) Or ($"+91{number}" = $"91{number1}") Or ($"91{number}" = $"+91{number1}")) Then
                                    If Grid1.Rows(i).DefaultCellStyle.BackColor <> Color.LightCoral Then
                                        Grid1.Rows(i).DefaultCellStyle.BackColor = Color.LightCoral
                                        duplicat += 1
                                        Grid1.Rows(i).Cells("Ststus").Value = "Duplicate Number"
                                        list_.Add(ro)
                                    End If
                                End If
                            Next
                        End If
                        'Chack WhatsApp Number
                        If Chack_whatsapp_ = True And ro.DefaultCellStyle.BackColor <> Color.LightCoral Then
                            Dim num As String = ""
                            If Val(number).ToString.Length = 10 Then
                                num = $"91{number}"
                            ElseIf Val(number).ToString.Length = 12 Then
                                num = $"{number}"
                            ElseIf Val(number).ToString.Length = 13 Then
                                num = $"91{number.Substring(3, 10)}"
                            End If

                            If Chack_whatsAppNo(num) = False Then
                                non_whatsapp += 1
                                ro.DefaultCellStyle.BackColor = Color.LightCoral
                                ststus_col.Value = "Non-WhatsApp Users"
                                list_.Add(ro)
                            End If
                        End If
                        If ro.DefaultCellStyle.BackColor <> Color.LightCoral Then
                            Success_ += 1
                        End If
                    End If
                End If

                Chack_Background.ReportProgress(ro.Index)
            Next
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub
    Function CountCharacter(text As String, subStringToFind As String) As Integer
        Dim count As Integer = 0
        Dim index As Integer = text.IndexOf(subStringToFind)

        Do While index <> -1
            count += 1
            index = text.IndexOf(subStringToFind, index + subStringToFind.Length)
        Loop

        Return count
    End Function
    Private Function Chack_whatsAppNo(phone As String) As Boolean
        Dim url As New String($"https://wh.cryptonixtechnology.in/check-number")


        Dim status As String = "Non-WhatsApp Users"
        Try
            Dim postdata As New JObject
            postdata.Add("api_key", Wh_Local_API)
            postdata.Add("sender", Wh_Local_No)
            postdata.Add("number", phone)


            Dim finalString As String = postdata.ToString

            Dim httpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
            httpWebRequest.ContentType = "application/json"
            httpWebRequest.Method = "POST"
            'httpWebRequest.Timeout = 5000
            Using streamWriter = New StreamWriter(httpWebRequest.GetRequestStream())
                streamWriter.Write(finalString)
            End Using

            Dim httpResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)
            Dim responseText As String

            Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                responseText = streamReader.ReadToEnd()
            End Using

            Dim json As String = responseText
            Dim r = JObject.Parse(json)

            status = r.Item("status").ToString.ToLower
            httpResponse.Close()

            If status = "true" Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
            Return False
        End Try

        Return True
    End Function

    Private Sub Chack_Background_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles Chack_Background.ProgressChanged
        With Whatsapp_No_Chack_Dialoag
            .Label18.Text = Grid1.Rows.Count - 1
            .Label21.Text = duplicat
            .Label6.Text = blank
            .Label10.Text = invalid
            .Label22.Text = Success_
            .Label23.Text = filter_found
            .Label13.Text = non_whatsapp


            .Panel3.Visible = True

            .ProgressBag_Custom1.Maximum = Grid1.Rows.Count - 1

            .ProgressBag_Custom1.Value = e.ProgressPercentage
            .ProgressBag_Custom1.Run(0)

            .Label3.Text = $"{N2_FORMATE((Val(e.ProgressPercentage) * 100) / Val(.ProgressBag_Custom1.Maximum))} %"
        End With
    End Sub

    Private Sub Chack_Background_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles Chack_Background.RunWorkerCompleted
        Stop_Msg()

        With Whatsapp_No_Chack_Dialoag
            .Stop_btn.Visible = False
            .Start_btn.Visible = True
            .delete_btn.Visible = True
            .Export_Panel.Visible = True
            .Panel3.Visible = False

        End With
    End Sub
    Private Export_Path As String = ""
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        With SaveFileDialog1
            .Filter = "Excel File|*.xlsx"
            If .ShowDialog = DialogResult.OK Then
                Export_Path = .FileName
                Excel_Export.RunWorkerAsync()
                With Progressbar_Box
                    .Head.Text = "Please wait Export Excel..."
                    .Message.Text = ""
                    .Progress.Maximum = Grid1.Rows.Count - 2
                    .BackW = Excel_Export
                    .ShowDialog()
                End With
            End If
        End With
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs)
        Whatsapp_Tabale_Diaload.ShowDialog()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs)
        Load_Excel()
    End Sub
    Private Function Load_Excel()
        Try
            Dim dt As DataSet
            OpenFileDialog1.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
            If OpenFileDialog1.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
                Using strim = File.Open(OpenFileDialog1.FileName, FileMode.Open, FileAccess.Read)
                    Using reder As IExcelDataReader = ExcelReaderFactory.CreateReader(strim)
                        dt = reder.AsDataSet(New ExcelDataSetConfiguration() With {
                                                          .ConfigureDataTable = Function(__) New ExcelDataTableConfiguration() With {.UseHeaderRow = True}})
                        tbl = dt.Tables
                        ComboBox1.Items.Clear()
                        For Each tabl As DataTable In tbl
                            ComboBox1.Items.Add(tabl.TableName)
                        Next
                        Try
                            ComboBox1.SelectedIndex = 0
                        Catch ex As Exception

                        End Try
                        ColumnToolStripMenuItem.Visible = False
                        TemplatesToolStripMenuItem.Visible = False
                        Panel_Manage_Number(Number_Panel)

                    End Using
                End Using
                excel_panel.Show()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub LoadExcelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadExcelToolStripMenuItem.Click
        Load_Excel()
    End Sub

    Private Sub ConnectionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConnectionToolStripMenuItem.Click

    End Sub

    Private Sub WhatsAppSetupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WhatsAppSetupToolStripMenuItem.Click
        With Whatsapp_setup
            .API_TXT.Text = Wh_Local_API
            .Number_TXT.Text = Wh_Local_No
            .ShowDialog()
        End With
    End Sub

    Private Sub ChackConnectionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChackConnectionToolStripMenuItem.Click
        Chack_conn.RunWorkerAsync()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Chack_conn.RunWorkerAsync()

    End Sub

    Private Sub CreateTemplatesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateTemplatesToolStripMenuItem.Click
        Cell("WhatsApp Templates", "", "Create", "")
    End Sub

    Private Sub LoadTemplatesToolStripMenuItem_Click(sender As Object, e As EventArgs)
        WhatsApp_Select_temp.ShowDialog()

    End Sub

    Private Sub LoadTemplatesToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles LoadTemplatesToolStripMenuItem.Click
        Load_Temp_list()

        Panel_Manage_Number(Temp_Load_Panel)
    End Sub
    Private Function Panel_Manage_Number(p As Panel)
        Temp_Load_Panel.Visible = False
        Number_Panel.Visible = False

        With p
            .Dock = DockStyle.Fill
            .Show()
        End With
    End Function
    Private Function Load_Temp_list()
        Dim dt As New DataTable
        dt.Columns.Add("ID")
        dt.Columns.Add("Name")
        dt.Columns.Add("Type WhatsApp Number")
        dt.Columns.Add("Account Group")
        dt.Columns.Add("Ledger Permission")
        dt.Columns.Add("Ledger Filter")
        dt.Columns.Add("Message")

        Dim cn As New SQLiteConnection
        open_MSSQL_Cstm(Database_File.cre, cn)

        cmd = New SQLiteCommand("Select * From TBL_WhatsApp_Temp", cn)
        Dim r As SQLiteDataReader = cmd.ExecuteReader

        While r.Read
            dt.Rows.Add(r("ID").ToString, r("Name").ToString, r("WhatsApp_Number").ToString, r("Account_Group").ToString, r("Ledger_Permission").ToString, r("Ledger_Filter").ToString, r("Message").ToString)
        End While
        Temp_List_Source.DataSource = dt
        r.Close()

        With Grid2
            .DataSource = Temp_List_Source

            .Columns(0).Visible = False
            .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns(2).Width = 200
            .Columns(3).Visible = False
            .Columns(4).Visible = False
            .Columns(5).Visible = False
            .Columns(6).Visible = False
        End With

        If Grid2.Rows.Count - 0 <= 0 Then
            Button8.Visible = False
        Else
            Button8.Visible = True
        End If
    End Function

    Private Sub Button7_Click_1(sender As Object, e As EventArgs) Handles Button7.Click
        Cell("WhatsApp Templates", "", "Create", "")

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Panel_Manage_Number(Number_Panel)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Temp_List_Source.Filter = $"Name LIKE '%{TextBox1.Text.Trim}%' or Message LIKE '%{TextBox1.Text.Trim}%'"
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Load_Temp(Grid2.CurrentRow)
        Panel_Manage_Number(Number_Panel)
    End Sub
    Private Function Load_Temp(ro As DataGridViewRow)
        Dim ID_ As String = ro.Cells(0).Value
        Dim Name_ As String = ro.Cells(1).Value
        Dim Type_WhatsApp_Number As String = ro.Cells(2).Value
        Dim Account_Group As String = ro.Cells(3).Value
        Dim Ledger_Permission As String = ro.Cells(4).Value
        Dim Ledger_Filter As String = ro.Cells(5).Value
        Dim Message As String = ro.Cells(6).Value

        If Type_WhatsApp_Number = "Not Applicable" Then
            Message_TXT.Text = Message.ToString
            Exit Function
        End If

        If Type_WhatsApp_Number = "Custom" Then
            Temp_Set_Column(ro)
            Message_TXT.Text = Message.ToString
            Exit Function
        End If

        If Type_WhatsApp_Number = "Account Group" Then
            Temp_Set_Column(ro)
            Fill_Acc_Group_Temp(ro)
            Message_TXT.Text = Message.ToString
            Exit Function
        End If
    End Function

    Private Function Fill_Acc_Group_Temp(ro As DataGridViewRow)
        Dim ID_ As String = ro.Cells(0).Value
        Dim Name_ As String = ro.Cells(1).Value
        Dim Type_WhatsApp_Number As String = ro.Cells(2).Value
        Dim Account_Group As String = ro.Cells(3).Value
        Dim Ledger_Permission As String = ro.Cells(4).Value
        Dim Ledger_Filter As String = ro.Cells(5).Value
        Dim Message As String = ro.Cells(6).Value
        Dim adapter As New SQLiteDataAdapter

        Dim q As String = ""
        For Each col As DataGridViewColumn In Grid1.Columns
            q &= $"{Temp_Column_Link_TBL_Ledger(col)},"
        Next
        q = q.Substring(0, q.Length - 1)

        Grid1.Columns.Clear()


        Dim Ledger_Permission_Filter As String = ""
        If Ledger_Permission = "All" Then
            Ledger_Permission_Filter = ""
        ElseIf Ledger_Permission.ToLower = "only those with permission" Then
            Ledger_Permission_Filter = " and LD.Communication_Whatsapp <> 'No'"
        End If

        Dim Ledger_Filter_Filter As String = ""
        If Ledger_Filter.ToLower = "all ledgers" Then
            Ledger_Filter_Filter = ""
        ElseIf Ledger_Filter.ToLower = "credit limit has been exhausted." Then
            Ledger_Filter_Filter = "where Current_Cradit < 0"
        ElseIf Ledger_Filter.ToLower = "those with negative balances" Then
            Ledger_Filter_Filter = "where Current_Balance < 0"
        End If


        Dim cn As New SQLiteConnection
        open_MSSQL_Cstm(Database_File.cre, cn)

        Using cmd As New SQLiteCommand($"Select {q} From 
(Select *,ifnull(Cradit,0)+ifnull(Current_Balance,0) as Current_Cradit From
(Select *,(Select ifnull((Select ifnull(SUM(vc.Cr),0)-ifnull(SUM(vc.Dr),0) From TBL_VC_Ledger vc Where vc.Ledger = LD.ID and vc.[Date] <= '{CDate(Now.Date).AddDays(1).ToString(Lite_date_Format)}'),0)+ifnull((Select ifnull(sum(lob.OB_Cr),0)-ifnull(sum(lob.OB_Dr),0) From TBL_Ledger_Opning_Balance lob where lob.Ledger_ID = LD.ID),0)) as Current_Balance
From TBL_Ledger LD where [Group] = '{Account_Group}' {Ledger_Permission_Filter}) {Ledger_Filter_Filter})", cn)

            My.Computer.Clipboard.SetText(cmd.CommandText)
            Using sda As New SQLiteDataAdapter(cmd)
                Using dt As New DataTable()
                    sda.Fill(dt)
                    Grid1.DataSource = dt

                End Using
            End Using
        End Using
    End Function

    Private Function Temp_Column_Link_TBL_Ledger(c As DataGridViewColumn) As String
        Select Case c.HeaderText
            Case "Name"
                Return "[Name]"
            Case "Alias"
                Return "[Alise]"
            Case "Under Group"
                Return "[Group]"
            Case "Email"
                Return "[Email]"
            Case "Phone"
                Return "[Phone]"
            Case "Country"
                Return "[Country]"
            Case "Pincode"
                Return "[PinCode]"
            Case "State"
                Return "[State]"
            Case "District"
                Return "[Dis]"
            Case "Taluko"
                Return "[Taluka]"
            Case "City"
                Return "[City]"
            Case "Address"
                Return "[Address]"
            Case "Bank Name"
                Return "[BankName]"
            Case "Bank Branch"
                Return "[Branch]"
            Case "Bank Account No"
                Return "[AccountNo]"
            Case "IFSC Code"
                Return "[IFSCCode]"
            Case "GST No."
                Return "[GSTNo]"
            Case "PAN No."
                Return "[PANCardNo]"
            Case "Credit Limit"
                Return "[Cradit]"
            Case "Current Credit"
                Return "[Current_Cradit]"
            Case "Current Balance"
                Return "[Current_Balance]"
            Case Else
                Return $"'' as {c.HeaderText}"
        End Select
    End Function

    Private Function Temp_Set_Column(ro As DataGridViewRow)
        Dim ID_ As String = ro.Cells(0).Value

        Excel_Column.Clear()
        Dim cn As New SQLiteConnection
        open_MSSQL_Cstm(Database_File.cre, cn)
        cmd = New SQLiteCommand($"Select * From TBL_WhatsApp_Temp_column where Temp_ID = '{ID_}'", cn)
        Dim r As SQLiteDataReader = cmd.ExecuteReader
        While r.Read
            Excel_Column.Add(r("Column_Name").ToString)
        End While
        r.Close()

        Colunm_Set()
    End Function

    Private Sub Temp_btn_Click(sender As Object, e As EventArgs)
        Load_Temp_list()
        Panel_Manage_Number(Temp_Load_Panel)
    End Sub

    Private Sub Delete_invelid_back_DoWork(sender As Object, e As DoWorkEventArgs) Handles Delete_invelid_back.DoWork
        Whatsapp_No_Chack_Dialoag.ProgressBag_Custom1.Maximum = Grid1.Rows.Count - 1

        Dim ro_list As New List(Of DataGridViewRow)

        For Each ro As DataGridViewRow In Grid1.Rows
            'System.Threading.Thread.Sleep(1)
            If ro.DefaultCellStyle.BackColor = Color.LightCoral Then
                ro_list.Add(ro)
            End If
            Delete_invelid_back.ReportProgress(ro.Index)
        Next

        'ro_list.RemoveAll(Function(m)
        '                      Grid1.Rows.Remove(m)
        '                  End Function)

        For Each ro As DataGridViewRow In ro_list
            ' System.Threading.Thread.Sleep(1)
            Delete_invelid_back.ReportProgress(ro.Index)
            Grid1.Rows.Remove(ro)
        Next
    End Sub

    Private Sub Delete_invelid_back_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles Delete_invelid_back.ProgressChanged


        With Whatsapp_No_Chack_Dialoag
            .Panel3.Visible = True
            .ProgressBag_Custom1.Value = e.ProgressPercentage
            .ProgressBag_Custom1.Run(0)

            .Label3.Text = $"{N2_FORMATE((Val(e.ProgressPercentage) * 100) / Val(.ProgressBag_Custom1.Maximum))} %"
        End With
    End Sub

    Private Sub Delete_invelid_back_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles Delete_invelid_back.RunWorkerCompleted
        With Whatsapp_No_Chack_Dialoag
            .Panel3.Visible = False
            .delete_btn.Visible = True
            .Export_Panel.Visible = True
            .Start_btn.Visible = True
            .Stop_btn.Visible = False
        End With
    End Sub
    Dim Excel_Filter_Valid As Boolean = False
    Dim Excel_Filter_Reject As Boolean = False
    Public Function Export_excel_to_Filter(valid As Boolean, reject As Boolean)
        Excel_Filter_Valid = valid
        Excel_Filter_Reject = reject

        With SaveFileDialog1
            .Filter = "Excel File|*.xlsx"
            If .ShowDialog = DialogResult.OK Then
                Export_Path = .FileName
                Excel_ecport_filtre_background.RunWorkerAsync()
                With Whatsapp_No_Chack_Dialoag
                    .ProgressBag_Custom1.Maximum = Grid1.Rows.Count - 2
                End With
            End If
        End With
    End Function
    Private Sub Excel_ecport_filtre_background_DoWork(sender As Object, e As DoWorkEventArgs) Handles Excel_ecport_filtre_background.DoWork
        Dim xlApp As Microsoft.Office.Interop.Excel.Application
        Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
        Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value
        Dim i As Integer
        Dim j As Integer

        xlApp = New Microsoft.Office.Interop.Excel.Application
        xlWorkBook = xlApp.Workbooks.Add(misValue)
        xlWorkSheet = xlWorkBook.Sheets("sheet1")

        Dim I1 As Integer = 0

        For i = 0 To Grid1.RowCount - 2
            Dim ro As DataGridViewRow = Grid1.Rows(i)
            If (Excel_Filter_Reject = True And ro.DefaultCellStyle.BackColor = Color.LightCoral) Or (Excel_Filter_Valid = True And ro.DefaultCellStyle.BackColor <> Color.LightCoral) Then
                For j = 0 To Grid1.ColumnCount - 1
                    For k As Integer = 1 To Grid1.Columns.Count
                        xlWorkSheet.Cells(1, k) = Grid1.Columns(k - 1).HeaderText
                        xlWorkSheet.Cells(I1 + 2, j + 1) = Grid1(j, i).Value.ToString()
                    Next
                Next
                I1 += 1
            End If

            Excel_ecport_filtre_background.ReportProgress(i)
        Next

        xlWorkSheet.SaveAs(Export_Path)
        xlWorkBook.Close()
        xlApp.Quit()

        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(xlWorkSheet)
    End Sub

    Private Sub Excel_ecport_filtre_background_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles Excel_ecport_filtre_background.ProgressChanged
        With Whatsapp_No_Chack_Dialoag
            .Panel3.Visible = True
            .ProgressBag_Custom1.Value = e.ProgressPercentage
            .ProgressBag_Custom1.Run(0)

            .Label3.Text = $"{N2_FORMATE((Val(e.ProgressPercentage) * 100) / Val(.ProgressBag_Custom1.Maximum))} %"
        End With
    End Sub

    Private Sub Excel_ecport_filtre_background_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles Excel_ecport_filtre_background.RunWorkerCompleted
        With Whatsapp_No_Chack_Dialoag
            .Panel3.Visible = False

        End With

    End Sub

    Private Sub ColumnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ColumnToolStripMenuItem.Click
        Whatsapp_Tabale_Diaload.ShowDialog()

    End Sub

    Private Sub t_Message_CheckedChanged(sender As Object, e As EventArgs) Handles t_Message.CheckedChanged
        If sender.Checked = True Then
            Attach_Panel.Visible = False
            poll_Panel.Visible = False
            Panel17.Visible = True
            Button_Panel.Visible = False
            List_Message_Panel.Visible = False
            Location_Panel.Visible = False
            VCard_Panel.Visible = False

        End If
    End Sub

    Private Sub t_Media_CheckedChanged(sender As Object, e As EventArgs) Handles t_Media.CheckedChanged
        If sender.Checked = True Then
            Attach_Panel.Visible = True
            poll_Panel.Visible = False
            Panel17.Visible = True
            Button_Panel.Visible = False
            List_Message_Panel.Visible = False
            Location_Panel.Visible = False
            VCard_Panel.Visible = False

        End If
    End Sub

    Private Sub t_Channel_CheckedChanged(sender As Object, e As EventArgs) Handles t_Channel.CheckedChanged
        If sender.Checked = True Then
            Attach_Panel.Visible = False
            poll_Panel.Visible = False
            Panel17.Visible = True
            Button_Panel.Visible = False
            List_Message_Panel.Visible = False
            Location_Panel.Visible = False
            VCard_Panel.Visible = False

        End If
    End Sub

    Private Sub t_Poll_CheckedChanged(sender As Object, e As EventArgs) Handles t_Poll.CheckedChanged
        If sender.Checked = True Then
            poll_Panel.Visible = True
            Attach_Panel.Visible = False
            Panel17.Visible = False
            Button_Panel.Visible = False
            Button_Panel.Visible = False
            List_Message_Panel.Visible = False
            Location_Panel.Visible = False
            VCard_Panel.Visible = False

        End If
    End Sub
    Private Sub RadioButton11_CheckedChanged(sender As Object, e As EventArgs) Handles t_Button.CheckedChanged
        poll_Panel.Visible = False
        Attach_Panel.Visible = True
        Panel17.Visible = True
        Button_Panel.Visible = True
        List_Message_Panel.Visible = False
        Location_Panel.Visible = False
        VCard_Panel.Visible = False

    End Sub
    Private Sub RadioButton12_CheckedChanged(sender As Object, e As EventArgs) Handles t_List.CheckedChanged
        poll_Panel.Visible = False
        Attach_Panel.Visible = False
        Panel17.Visible = True
        Button_Panel.Visible = False
        List_Message_Panel.Visible = True
        Location_Panel.Visible = False
        VCard_Panel.Visible = False

    End Sub
    Private Sub RadioButton13_CheckedChanged(sender As Object, e As EventArgs) Handles t_Location.CheckedChanged
        Attach_Panel.Visible = False
        poll_Panel.Visible = False
        Panel17.Visible = False
        Button_Panel.Visible = False
        List_Message_Panel.Visible = False
        Location_Panel.Visible = True
        VCard_Panel.Visible = False
    End Sub
    Private Sub t_Vcard_CheckedChanged(sender As Object, e As EventArgs) Handles t_Vcard.CheckedChanged
        Attach_Panel.Visible = False
        poll_Panel.Visible = False
        Panel17.Visible = False
        Button_Panel.Visible = False
        List_Message_Panel.Visible = False
        Location_Panel.Visible = False
        VCard_Panel.Visible = True
    End Sub
    Private Sub Panel17_Paint(sender As Object, e As PaintEventArgs) Handles Panel17.Paint
        sender.Dock = DockStyle.Top
        Panel17.SendToBack()
        Panel17.Height = 200
    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click
        Dim ctrl As New WhatsApp_poll_Option_ctrl
        vote_option_panel.Controls.Add(ctrl)
        ctrl.Txt1.Focus()
        ctrl.Dock = DockStyle.Top
        ctrl.BringToFront()

    End Sub

    Private Sub poll_Panel_Paint(sender As Object, e As PaintEventArgs) Handles poll_Panel.Paint
        sender.Dock = DockStyle.Fill
        sender.BringToFront()
    End Sub

    Private Sub Button_Panel_Paint(sender As Object, e As PaintEventArgs) Handles Button_Panel.Paint
        Button_Panel.Dock = DockStyle.Fill
        Button_Panel.BringToFront()
    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click
        Dim ctrl As New WhatsApp_Button_Option_ctrl
        button_option_panel.Controls.Add(ctrl)
        ctrl.ComboBox1.Focus()
        ctrl.ComboBox1.SelectedItem = 0
        ctrl.Dock = DockStyle.Top
        ctrl.BringToFront()
    End Sub

    Private Sub button_option_panel_Paint(sender As Object, e As PaintEventArgs) Handles button_option_panel.Paint

    End Sub

    Private Sub button_option_panel_ControlAdded(sender As Object, e As ControlEventArgs) Handles button_option_panel.ControlAdded, button_option_panel.ControlRemoved
        If button_option_panel.Controls.Count = 5 Then
            Label13.Enabled = False
        Else
            Label13.Enabled = True
        End If
    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles Label14.Click
        Dim ctrl As New WhatsApp_List_Section_ctrl
        list_section_panel.Controls.Add(ctrl)
        ctrl.Txt1.Focus()
        ctrl.Dock = DockStyle.Top
        ctrl.BringToFront()
    End Sub

    Private Sub List_Message_Panel_Paint(sender As Object, e As PaintEventArgs) Handles List_Message_Panel.Paint
        List_Message_Panel.Dock = DockStyle.Fill
        List_Message_Panel.BringToFront()
    End Sub


    Private Sub Panel36_Paint(sender As Object, e As PaintEventArgs) Handles Location_Panel.Paint
        Location_Panel.Height = 80
    End Sub
    Private WithEvents Watcher As GeoCoordinateWatcher
    Private Function Find_Current_Location()
        Latitude_ = Txt4
        Longitude_ = Txt5
        Location_GPS_mod.Lca1()

        If Longitude_.Text = Nothing Then
            'MessageBox.Show("Location is Now Found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Function

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Find_Current_Location()
    End Sub

    Private Sub Panel36_Paint_1(sender As Object, e As PaintEventArgs) Handles VCard_Panel.Paint
        VCard_Panel.Height = 106
    End Sub

End Class