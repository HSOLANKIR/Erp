Imports System.Data.SQLite
Public Class prcj_voucher_create_ctrl
    Public VC_Formate_ As String
    Public VC_ID_ As String
    Public VC_Type_ As String
    Private Sub prcj_voucher_create_ctrl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'List_set()
    End Sub

    Private Sub UPI_QR_YN_TextChanged(sender As Object, e As EventArgs) Handles UPI_QR_YN.TextChanged
        If UPI_QR_YN.Text = "Yes" Then
            UPI_value_p.Visible = True
        Else
            UPI_value_p.Visible = False
        End If
    End Sub
    Public Function Fill_data()
        Fill_Source()
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
                Communication_YN.Text = r("Communication_YN").ToString
                narration_YN.Text = r("YN_Narration").ToString
                direct_print_YN.Text = r("Print_after_seve").ToString
                print_head_txt.Text = r("Print_Head").ToString
                print_narration_YN.Text = r("Print_Narration").ToString
                print_signature_YN.Text = r("Print_Signature").ToString
                print_stamp_YN.Text = r("Print_Stamp").ToString
                UPI_QR_YN.Text = r("Print_UPI_QR").ToString
                UPI_Value_TXT.Text = r("Print_UPI_QR_Value").ToString
                provisnoal_YN.Text = r("Print_Provisional").ToString
                print_path_txt.Text = r("Print_Path").ToString
                Print_Terms_Conditions_txt.Text = r("Print_Terms_Conditions").ToString
                Credit_Limit_Warning.Text = r("YN_Credit_Limit_Warning").ToString

            End While
            r.Close()
        End If
        cn.Close()
        'zero_YN.Focus()
        Communication_Panel.Visible = YN_Boolean(Features_mod.Communication_YN)
    End Function
    Public Function Save_data(nam As String) As Boolean
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            qury = $"UPDATE TBL_Voucher_Create SET Duplicate_No = @Duplicate_No,Communication_YN = @Communication_YN,YN_Narration_Cell = @YN_Narration_Cell,Zerol_Value = @Zerol_Value,Print_after_seve = @Print_after_seve,Print_Head = @Print_Head,Print_Narration = @Print_Narration,Print_Signature = @Print_Signature,Print_Stamp = @Print_Stamp,Print_UPI_QR = @Print_UPI_QR,Print_UPI_QR_Value = @Print_UPI_QR_Value,Print_Provisional  = @Print_Provisional,YN_Narration = @YN_Narration,Print_Path = @Print_Path,Print_format = @Print_format,Print_Terms_Conditions = @Print_Terms_Conditions,YN_Credit_Limit_Warning = @YN_Credit_Limit_Warning where name = '{nam}'"
        End If

        cmd = New SQLiteCommand(qury, cn)
        Try

            With cmd.Parameters
                '////
                .AddWithValue("@YN_Narration_Cell", "")

                .AddWithValue("@Zerol_Value", zero_YN.Text.Trim)
                .AddWithValue("@Duplicate_No", duplicate_YN.Text.Trim)
                .AddWithValue("@Communication_YN", Communication_YN.Text.Trim)
                .AddWithValue("@Print_after_seve", direct_print_YN.Text.Trim)
                .AddWithValue("@Print_Head", print_head_txt.Text.Trim)
                .AddWithValue("@Print_Narration", print_narration_YN.Text.Trim)
                .AddWithValue("@Print_Signature", print_signature_YN.Text.Trim)
                .AddWithValue("@Print_Stamp", print_stamp_YN.Text.Trim)
                .AddWithValue("@Print_UPI_QR", UPI_QR_YN.Text.Trim)
                .AddWithValue("@Print_UPI_QR_Value", UPI_Value_TXT.Text.Trim)
                .AddWithValue("@Print_Provisional", provisnoal_YN.Text.Trim)
                .AddWithValue("@YN_Narration", narration_YN.Text.Trim)
                .AddWithValue("@Print_Path", print_path_txt.Text.Trim)
                .AddWithValue("@Print_format", "")
                .AddWithValue("@Print_Terms_Conditions", Print_Terms_Conditions_txt.Text.Trim)
                .AddWithValue("@YN_Credit_Limit_Warning", Credit_Limit_Warning.Text.Trim)

                cmd.ExecuteNonQuery()
            End With
            Return True
        Catch ex As Exception
            Msg(NOT_Type.Erro, "Data Save Error", ex.Message)
            Return False
        End Try
    End Function
    Private Sub print_path_txt_LostFocus(sender As Object, e As EventArgs) Handles print_path_txt.LostFocus
        'If print_path_txt.Text <> Nothing Then
        '    print_path_txt.Text = ""
        '    print_path_txt.Focus()
        '    Exit Sub
        'End If
    End Sub

    Dim qr_list As List_frm
    'Dim rdlcFile_list As List_frm
    Public Function List_set()
        qr_list = New List_frm
        List_Setup("UPI Qrcode Type", Select_List.Right, Select_List_Format.Singel, UPI_Value_TXT, qr_list, upi_qr_source, 150)

    End Function

    Private Sub UPI_Value_TXT_Enter(sender As Object, e As EventArgs) Handles UPI_Value_TXT.Enter
        'Fill_UPI_Source()
    End Sub
    Public Function Fill_Source()
        Dim dt As New DataTable
        dt.Columns.Add("Name")
        If VC_Formate_ = "Payment" Or VC_Formate_ = "Contra" Then
            dt.Rows.Add("Manual Pay")
            dt.Rows.Add("Current Value")
            dt.Rows.Add("Provisional Value")
        ElseIf VC_Formate_ = "Receipt" Then
            dt.Rows.Add("Manual Pay")
            dt.Rows.Add("Provisional Value")
        ElseIf VC_Formate_ = "Journal" Then
            dt.Rows.Add("Manual Pay")
        End If

        upi_qr_source.DataSource = dt
    End Function

    Private Sub print_path_txt_TextChanged(sender As Object, e As EventArgs) Handles print_path_txt.TextChanged

    End Sub

    Private Sub print_format_txt_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Credit_Limit_Warning_TextChanged(sender As Object, e As EventArgs) Handles Credit_Limit_Warning.TextChanged

    End Sub
End Class
