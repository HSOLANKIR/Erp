Module Features_mod
    Public Date_Format_fech As String = "dd-MM-yyyy"
    Public Negative_Value_fech As String = "Dr"
    Public Positive_Value_fech As String = "Cr"
    Public Whatsapp_YN_fech As Boolean
    Public Email_YN_fech As Boolean
    Public Whatsapp_ID_fech As String
    Public Branch_YN_fech As Boolean
    Public Branch_Primary_fech As String
    Public Primary_Printer As String
    Public Batches_YN As Boolean = False
    Public Godown_YN As Boolean = False
    Public Auto_Backup_YN As Boolean = False
    Public Auto_Backup_Path As String
    Public Auto_Backup_Max As Integer = 1
    Public Communication_YN As Boolean
    Public Account_Phone As String
    Public Account_Email As String
    Public Payroll_YN As Boolean = False
    Public Audit_YN As Boolean = False

    Public Function Fill_Features_Mod(head As String, vlu As String, dec As String)
        Select Case head
            Case "Date Format"
                Date_Format_fech = vlu
            Case "Positive Value"
                Positive_Value_fech = vlu
            Case "Negative Value"
                Negative_Value_fech = vlu
            Case "Branch_YN"
                If vlu = "Yes" Then
                    Branch_YN_fech = True
                    Branch_Primary_fech = dec
                Else
                    Branch_Primary_fech = ""
                    Branch_YN_fech = False
                End If
            Case "Whatsapp"
                If vlu = "Yes" Then
                    Whatsapp_YN_fech = True
                    Whatsapp_ID_fech = dec
                Else
                    Whatsapp_ID_fech = ""
                    Whatsapp_YN_fech = False
                End If
            Case "Email"
                Email_YN_fech = YN_Boolean(vlu)
            Case "Defolt Printer"
                Primary_Printer = vlu
            Case "Batches_YN"
                Batches_YN = YN_Boolean(vlu)
            Case "Godown_YN"
                Godown_YN = YN_Boolean(vlu)
            Case "Auto_Backup_Data"
                Auto_Backup_YN = YN_Boolean(vlu)
                Auto_Backup_Path = dec
            Case "Auto_Backup_Data_Max"
                Auto_Backup_Max = Val(vlu)
                If Auto_Backup_Max <= 0 Then
                    Auto_Backup_Max = 1
                End If
            Case "Communication_YN"
                Communication_YN = YN_Boolean(vlu)
            Case "Account_Phone"
                Account_Phone = (vlu)
            Case "Account_Email"
                Account_Email = (vlu)
            Case "Payroll_YN"
                Payroll_YN = YN_Boolean(vlu)
            Case "Whatsapp_API"
                Wh_Local_API = (vlu)
                Wh_Local_No = (dec)
            Case "Auto_Logout_YN"
                Auto_Logout_YN = YN_Boolean(vlu)
            Case "Auto_Logout_Sec"
                Auto_Logout_Sec = Val(vlu)


        End Select
    End Function
    Public Account_YN As Boolean = True
    Public Acc_Contra_YN As Boolean = True
    Public Acc_Payment_YN As Boolean = True
    Public Acc_Receipt_YN As Boolean = True
    Public Acc_Journal_YN As Boolean = True
    Public Function Fill_Account_Features_Mod(head As String, vlu As String, dec As String)
        Select Case head
            Case "Account_YN"
                Account_YN = YN_Boolean(vlu)
            Case "Contra_YN"
                Acc_Contra_YN = YN_Boolean(vlu)
            Case "Payment_YN"
                Acc_Payment_YN = YN_Boolean(vlu)
            Case "Receipt_YN"
                Acc_Receipt_YN = YN_Boolean(vlu)
            Case "Journal_YN"
                Acc_Journal_YN = YN_Boolean(vlu)

        End Select
    End Function
End Module
