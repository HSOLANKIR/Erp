Imports System.Data.SQLite
Public Class payroll_voucher_create_ctrl
    Public VC_Formate_ As String
    Public VC_ID_ As String
    Public VC_Type_ As String
    Private Sub payroll_voucher_create_ctrl_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
                duplicate_YN.Text = r("Duplicate_No").ToString
                narration_YN.Text = r("YN_Narration").ToString
                Credit_Limit_Warning.Text = r("YN_Credit_Limit_Warning").ToString

            End While
            r.Close()
        End If
        cn.Close()
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

                .AddWithValue("@Zerol_Value", "No")
                .AddWithValue("@Duplicate_No", duplicate_YN.Text.Trim)
                .AddWithValue("@Communication_YN", "No")
                .AddWithValue("@Print_after_seve", "No")
                .AddWithValue("@Print_Head", "")
                .AddWithValue("@Print_Narration", "No")
                .AddWithValue("@Print_Signature", "No")
                .AddWithValue("@Print_Stamp", "No")
                .AddWithValue("@Print_UPI_QR", "No")
                .AddWithValue("@Print_UPI_QR_Value", "No")
                .AddWithValue("@Print_Provisional", "No")
                .AddWithValue("@YN_Narration", narration_YN.Text.Trim)
                .AddWithValue("@Print_Path", "No")
                .AddWithValue("@Print_format", "")
                .AddWithValue("@Print_Terms_Conditions", "")
                .AddWithValue("@YN_Credit_Limit_Warning", Credit_Limit_Warning.Text.Trim)

                cmd.ExecuteNonQuery()
            End With
            Return True
        Catch ex As Exception
            Msg(NOT_Type.Erro, "Data Save Error", ex.Message)
            Return False
        End Try
    End Function
    Public Function List_set()

    End Function
    Public Function Fill_Source()

    End Function
End Class
