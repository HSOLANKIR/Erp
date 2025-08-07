Imports System.Data.SqlClient
Imports System.Data.SQLite

Module Payroll_Cal
    Public Arr_ID As New ArrayList

    Public Function Payroll_BValue_fIND_TO_Auto(Ac As String, Pyhd As String, D1 As Date, D2 As Date, Minul_cal As Boolean) As Decimal
        Dim Vlu As Decimal = 0.00
        Dim Date_arr As Date
        Dim Date_duplicate_chach As Date
        Dim Company_DAte As Date = CDate(Find_DT_Value(Database_File.cmp, "TBL_Company_Creation", "Opning_Date", "CompanySerial Like N'" & Company_Serial_str & "'"))

        Dim Payhead_Type As String = Find_DT_Value(Database_File.cre, "TBL_Payhead", "Payhead_Type", "ID Like N'" & Pyhd & "'")
        Dim Cal_Type As String = Find_DT_Value(Database_File.cre, "TBL_Payhead", "Cal_Type", "ID Like N'" & Pyhd & "'")
        Dim Cal_Unit As String = Find_DT_Value(Database_File.cre, "TBL_Payhead", "Cal", "ID Like N'" & Pyhd & "'")
        Dim Leave_without_pay As String = Find_DT_Value(Database_File.cre, "TBL_Payhead", "Leave_without_pay", "ID Like N'" & Pyhd & "'")
        Dim Production As String = Find_DT_Value(Database_File.cre, "TBL_Payhead", "Production", "ID Like N'" & Pyhd & "'")
        Dim Attendance_Production As String
        Dim DD1 As Date
        Dim DD2 As Date

        If Cal_Type = "On Attendance" Then
            Attendance_Production = Leave_without_pay
        ElseIf Cal_Type = "On Production" Then
            Attendance_Production = Production
        End If


        If open_MSSQL(Database_File.cre) Then
            qury = "Select * From TBL_Attendance_VC where Account Like N'" & Ac & "' and Particuls Like N'" & Attendance_Production & "' and Date BETWEEN '" & D1.ToString("MM-dd-yyyy") & "' and '" & D2.ToString("MM-dd-yyyy") & "'"
            cmd = New SQLiteCommand(qury, con)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                Dim Date_ As Date = CDate(r("Date"))
                Dim Value_of_att As Decimal = Val(r("Value"))
                Dim Pay_Value As Decimal = Val(r("Pay"))
                Arr_ID.Add(r("ID"))

                If open_MSSQL_3(Database_File.cre) Then
                    qury = "Select * From TBL_Payroll_SalaryDetails where Account Like N'" & Ac & "' and Payhead Like N'" & Pyhd & "' and Date BETWEEN '" & Company_DAte.ToString("MM-dd-yyyy") & "' and '" & D2.ToString("MM-dd-yyyy") & "'"
                    cmd_3 = New SQLiteCommand(qury, con_3)
                    Dim r2 As SQLiteDataReader
                    r2 = cmd_3.ExecuteReader
                    While r2.Read
                        If Date_ >= CDate(r2("Date")) Then
                            Date_arr = CDate(r2("Date"))
                        End If
                    End While
                End If
                If open_MSSQL_3(Database_File.cre) Then
                    qury = "Select * From TBL_Payroll_SalaryDetails where Account Like N'" & Ac & "' and Payhead Like N'" & Pyhd & "' and Date = '" & CDate(Date_arr).ToString("MM-dd-yyyy") & "'"
                    cmd_3 = New SQLiteCommand(qury, con_3)
                    Dim r1 As SQLiteDataReader
                    r1 = cmd_3.ExecuteReader
                    While r1.Read
                        If Minul_cal = True Then
                            Vlu += (Val(Value_of_att) * Val(r1("Rate")) - Val(Pay_Value))
                        Else
                            Vlu += (Val(Value_of_att) * Val(r1("Rate")))
                        End If
                    End While
                End If
            End While
            r.Close()
            '///
        End If
        Return Vlu
    End Function
    Public Function Empployee_Balance(Acc As String, Pyhd As String, D1 As Date, d2 As Date) As Decimal
        Dim Dr As Decimal
        Dim Cr As Decimal
        Dim aMt As Decimal
        Dim con_P As New SQLiteConnection()

        Dim Payhead_Type As String = Find_DT_Value(Database_File.cre, "TBL_Payhead", "Payhead_Type", "ID Like N'" & Pyhd & "'")

        qury = "Select * From TBL_VC where Particuls Like N'" & Acc & "' and Payhead Like N'" & Pyhd & "' and Date BETWEEN '" & D1.ToString("MM-dd-yyyy") & "' and '" & d2.ToString("MM-dd-yyyy") & "'"
        If open_MSSQL_Cstm(Database_File.cre, con_P) Then
            Dim cmd_P = New SQLiteCommand(qury, con_P)
            Dim r2 As SQLiteDataReader
            r2 = cmd_P.ExecuteReader
            While r2.Read
                Cr = Val(Cr) + Val(r2("Cr"))
                Dr = Val(Dr) + Val(r2("Dr"))
            End While
        End If


        If Payhead_Type = "Earnings for Employees" Then
            Dr = Payroll_BValue_fIND_TO_Auto(Acc, Pyhd, D1, d2, False) - Dr
        Else
            Cr = Payroll_BValue_fIND_TO_Auto(Acc, Pyhd, D1, d2, False) - Cr
        End If

        Return Val(Dr) - Val(Cr)
    End Function
End Module
