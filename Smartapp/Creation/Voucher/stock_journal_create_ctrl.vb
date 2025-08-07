Imports System.Data.SQLite
Imports System.IO

Public Class stock_journal_create_ctrl
    Public VC_Formate_ As String
    Public VC_ID_ As String
    Public VC_Type_ As String
    Private Sub stock_journal_create_ctrl_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Dim dt_rdlc As DataTable

    Dim rdlcFile_list As List_frm
    Public Function List_set()
        rdlcFile_list = New List_frm
        dt_rdlc = New DataTable
        dt_rdlc.Columns.Add("Name")
        dt_rdlc.Rows.Add("Not Applicable")
        BindingSource1.DataSource = dt_rdlc

        List_Setup("Select .rdlc file", Select_List.Botom, Select_List_Format.Singel, print_format_txt, rdlcFile_list, BindingSource1, print_format_txt.Width)
    End Function
    Public Function Fill_data()
        List_set()

        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select * From TBL_Voucher_Create where id = '{VC_ID_}'", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                VC_Formate_ = r("Under").ToString
                zero_YN.Text = r("Zerol_Value").ToString
                duplicate_YN.Text = r("Duplicate_No").ToString
                manufacturing_yn.Text = r("Stock_Journal_Production_YN").ToString
                narration_YN.Text = r("YN_Narration").ToString
                direct_print_YN.Text = r("Print_after_seve").ToString
                print_narration_YN.Text = r("Print_Narration").ToString
                print_signature_YN.Text = r("Print_Signature").ToString
                print_stamp_YN.Text = r("Print_Stamp").ToString
                print_path_txt.Text = r("Print_Path").ToString
                print_format_txt.Text = r("Print_format").ToString
            End While
            r.Close()
        End If
        cn.Close()

    End Function
    Public Function Save_data(nam As String) As Boolean
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            qury = $"UPDATE TBL_Voucher_Create SET Duplicate_No = @Duplicate_No,YN_Narration_Cell = @YN_Narration_Cell,Zerol_Value = @Zerol_Value,Print_after_seve = @Print_after_seve,Print_Head = @Print_Head,Print_Narration = @Print_Narration,Print_Signature = @Print_Signature,Print_Stamp = @Print_Stamp,Print_UPI_QR = @Print_UPI_QR,Print_UPI_QR_Value = @Print_UPI_QR_Value,Print_Provisional  = @Print_Provisional,YN_Narration = @YN_Narration,Print_Path = @Print_Path,Print_format = @Print_format,Print_Terms_Conditions = @Print_Terms_Conditions,Stock_Journal_Production_YN = @Stock_Journal_Production_YN where name = '{nam}'"
        End If

        cmd = New SQLiteCommand(qury, cn)


        Try

            With cmd.Parameters
                .AddWithValue("@YN_Narration_Cell", "")

                .AddWithValue("@Zerol_Value", zero_YN.Text.Trim)
                .AddWithValue("@Duplicate_No", duplicate_YN.Text.Trim)
                .AddWithValue("@Stock_Journal_Production_YN", manufacturing_yn.Text.Trim)
                .AddWithValue("@Print_after_seve", direct_print_YN.Text.Trim)
                .AddWithValue("@Print_Head", "")
                .AddWithValue("@Print_Narration", print_narration_YN.Text.Trim)
                .AddWithValue("@Print_Signature", print_signature_YN.Text.Trim)
                .AddWithValue("@Print_Stamp", print_stamp_YN.Text.Trim)
                .AddWithValue("@Print_UPI_QR", "")
                .AddWithValue("@Print_UPI_QR_Value", "")
                .AddWithValue("@Print_Provisional", "")
                .AddWithValue("@YN_Narration", narration_YN.Text.Trim)
                .AddWithValue("@Print_Path", print_path_txt.Text.Trim)
                .AddWithValue("@Print_format", print_format_txt.Text.Trim)
                .AddWithValue("@Print_Terms_Conditions", "")
                cmd.ExecuteNonQuery()
            End With
            Return True
        Catch ex As Exception
            Msg(NOT_Type.Erro, "Data Save Error", ex.Message)
            Return False
        End Try
    End Function
    Private Sub print_path_txt_LostFocus(sender As Object, e As EventArgs) Handles print_path_txt.LostFocus

    End Sub

    Private Sub print_path_txt_TextChanged(sender As Object, e As EventArgs) Handles print_path_txt.TextChanged

        If Directory.Exists(print_path_txt.Text) Then
            Panel19.Visible = True
        Else
            Panel19.Visible = False
            If print_path_txt.Text <> Nothing Then
                print_path_txt.Text = ""
                print_path_txt.Focus()
                Exit Sub
            End If
        End If

        If print_path_txt.Text <> Nothing Then

            dt_rdlc.Rows.Clear()
            dt_rdlc.Rows.Add("Not Applicable")

            Dim di As New IO.DirectoryInfo(print_path_txt.Text)
            Dim aryFi As IO.FileInfo() = di.GetFiles("*.rdlc")
            Dim fi As IO.FileInfo

            For Each fi In aryFi
                dt_rdlc.Rows.Add(fi.Name)
            Next
        End If


        BindingSource1.DataSource = dt_rdlc
    End Sub
End Class
