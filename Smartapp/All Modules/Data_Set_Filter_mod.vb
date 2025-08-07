Imports System.Data.SqlClient
Imports System.Data.SQLite

Module Data_Set_Filter_mod

    Public Function Fill_Ledger(cn As SQLiteConnection) As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow

        dt.Clear()
        dt.Columns.Add("ID")
        dt.Columns.Add("Name")
        dt.Columns.Add("Alise")
        dt.Columns.Add("Groupid")
        dt.Columns.Add("Group")
        dt.Columns.Add("Phone")
        dt.Columns.Add("Email")
        dt.Columns.Add("OB_CR")
        dt.Columns.Add("OB_DR")
        dt.Columns.Add("Cradit")
        dt.Columns.Add("PinCode")
        dt.Columns.Add("State")
        dt.Columns.Add("Dis")
        dt.Columns.Add("Taluka")
        dt.Columns.Add("City")
        dt.Columns.Add("GSTNo")
        dt.Columns.Add("PANCardNo")
        dt.Columns.Add("PercentageOfCalculation")
        dt.Columns.Add("TypeOfDuty")
        dt.Columns.Add("Balance")

        dt.Rows.Add("0", "End of List", "", "End of List", "", "")

        cmd = New SQLiteCommand("Select * From TBL_Ledger WHERE Visible = 'Approval'", cn)
        Dim r As SQLiteDataReader
        r = cmd.ExecuteReader
        While r.Read
            dr = dt.NewRow
            dr("ID") = r("ID")
            dr("Name") = r("Name")
            dr("Alise") = r("Alise")
            dr("Groupid") = r("Group")
            dr("Group") = Find_DT_Value(Database_File.cre, "TBL_Acc_Group", "Name", "ID = '" & r("Group") & "'")
            dr("Phone") = r("Phone")
            dr("Email") = r("Email")
            dr("OB_CR") = r("OB_CR")
            dr("OB_DR") = r("OB_DR")
            dr("Cradit") = r("Cradit")
            dr("PinCode") = r("PinCode")
            dr("State") = r("State")
            dr("Dis") = r("Dis")
            dr("Taluka") = r("Taluka")
            dr("City") = r("City")
            dr("GSTNo") = r("GSTNo")
            dr("PANCardNo") = r("PANCardNo")
            dr("PercentageOfCalculation") = r("PercentageOfCalculation")
            dr("TypeOfDuty") = r("TypeOfDuty")
            dr("Balance") = ""
            dt.Rows.Add(dr)
        End While
        r.Close()
        Return dt
    End Function
    Public Function Fill_Branch(cn As SQLiteConnection) As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow

        dt.Clear()
        dt.Columns.Add("ID")
        dt.Columns.Add("Name")
        dt.Columns.Add(" ")

        dt.Rows.Add("0", "Primary")

        cmd = New SQLiteCommand("Select * From TBL_Ledger WHERE Visible = 'Approval' and [Group] = '7'", cn)
        Dim r As SQLiteDataReader
        r = cmd.ExecuteReader
        While r.Read
            dr = dt.NewRow
            dr("ID") = r("ID")
            dr("Name") = r("Name")
            dr(" ") = " "
            dt.Rows.Add(dr)
        End While
        r.Close()
        Return dt
    End Function
    Public Function Fill_Acc_Group(cn As SQLiteConnection) As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow

        dt.Clear()
        dt.Columns.Add("ID")
        dt.Columns.Add("Name")
        dt.Columns.Add("Nickname")
        dt.Columns.Add("UserGroup_id")
        dt.Columns.Add("UserGroup")
        dt.Columns.Add("Company")

        dt.Rows.Add("0", "Primary", "Primary", "0", "Primary", Company_ID_str)

        cmd = New SQLiteCommand("Select * From TBL_Acc_Group where (Company = 'All' or Company = '" & Company_ID_str & "') and Visible = 'Approval'", cn)
        Dim r As SQLiteDataReader
        r = cmd.ExecuteReader
        While r.Read
            dr = dt.NewRow
            dr("ID") = r("ID")
            dr("Name") = r("Name")
            dr("Nickname") = r("Nickname")
            dr("UserGroup_id") = r("UserGroup")
            If r("UserGroup") <> "Primary" Then
                dr("UserGroup") = Find_DT_Value(Database_File.cre, "TBL_Acc_Group", "Name", "(Company = 'All' or Company = '" & Company_ID_str & "') and (Visible = 'Approval') and (ID = '" & r("UserGroup") & "')")
            Else
                dr("UserGroup") = "Primary"
            End If
            dr("Company") = r("Company")

            dt.Rows.Add(dr)
        End While
        r.Close()
        Return dt
    End Function
    Public Function Fill_Transport(cn As SQLiteConnection) As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow

        dt.Clear()
        dt.Columns.Add("ID")
        dt.Columns.Add("Name")
        dt.Columns.Add("Phone")
        dt.Columns.Add("Vehicle_Type")
        dt.Columns.Add("Vehicle_No")

        dt.Rows.Add("0", "Not Applicable")

        cmd = New SQLiteCommand("Select * From TBL_Tranport where (Company = 'All' or Company = '" & Company_ID_str & "') and Visible = 'Approval'", cn)
        Dim r As SQLiteDataReader
        r = cmd.ExecuteReader
        While r.Read
            dr = dt.NewRow
            dr("ID") = r("ID")
            dr("Name") = r("Name")
            dr("Phone") = r("Phone")
            dr("Vehicle_Type") = r("Vehicle_Type")
            dr("Vehicle_No") = r("Vehicle_No")
            dt.Rows.Add(dr)
        End While
        r.Close()
        Return dt
    End Function

    Public Function Fill_Loan_section(cn As SQLiteConnection) As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow

        dt.Clear()
        dt.Columns.Add("ID")
        dt.Columns.Add("Name")
        dt.Columns.Add("Sanction_Date").DataType = GetType(Date)
        dt.Columns.Add("Instalments_Date").DataType = GetType(Date)
        dt.Columns.Add("Employee_ID")
        dt.Rows.Add("Not Applicable", "0", CDate(Company_Book_frm), CDate(Company_Book_frm))
        cmd = New SQLiteCommand("Select *,(Select [Name] from TBL_Payroll_Employee where ID = ls.Employee_ID) as Employee From TBL_Loan_sanction ls where " & Company_Visible_Filter, cn)
        Dim r As SQLiteDataReader
        r = cmd.ExecuteReader
        While r.Read
            dr = dt.NewRow
            dr("ID") = r("ID")
            dr("Name") = r("Employee")
            dr("Sanction_Date") = CDate(r("Sanction_Date"))
            dr("Instalments_Date") = CDate(r("Instalments_Date"))
            dr("Employee_ID") = (r("Employee_ID"))
            dt.Rows.Add(dr)
        End While
        r.Close()
        Return dt
    End Function
    Public Function Filter_Acc_Ledger(ob As String) As String
        Dim St As String
        If open_MSSQL(Database_File.cre) = True Then
            St = $"(Name LIKE '%{ob.Trim}%'" & $"OR Alise LIKE '%{ob.Trim}%'" & $"OR Group LIKE '%{ob.Trim}%'" & $"OR Phone LIKE '%{ob.Trim}%'" & $"OR Email LIKE '%{ob.Trim}%'" & $"OR PinCode LIKE '%{ob.Trim}%'" & $"OR State LIKE '%{ob.Trim}%'" & $"OR Dis LIKE '%{ob.Trim}%'" & $"OR Taluka LIKE '%{ob.Trim}%'" & $"OR GSTNo LIKE '%{ob.Trim}%'" & $"OR City LIKE '%{ob.Trim}%'" & $"OR PANCardNo LIKE '%{ob.Trim}%')"
            Return St
        End If
    End Function

    Public Function Fill_Vouchhers(cn As SQLiteConnection) As DataTable

        Dim dt As New DataTable
        Dim dr As DataRow

        dt.Clear()
        dt.Columns.Add("ID")
        dt.Columns.Add("Tra_ID")
        dt.Columns.Add("Voucher_ID")
        dt.Columns.Add("Voucher_No")
        dt.Columns.Add("Voucher_Type")
        'dt.Columns.Add("CR_DR")
        'dt.Columns.Add("Date").DataType = GetType(Date)
        'dt.Columns.Add("AccountID")
        'dt.Columns.Add("Account")
        'dt.Columns.Add("Cr").DataType = GetType(Decimal)
        'dt.Columns.Add("Dr").DataType = GetType(Decimal)
        'dt.Columns.Add("Narration")
        dt.Columns.Add("Visible")

        dt.Rows.Add("0", "0", "0", "End of List", "End of List")

        cmd = New SQLiteCommand("Select * From TBL_VC where (Company = '" & Company_ID_str & "') AND CR_DR = 'Head'", cn)
        Dim r As SQLiteDataReader
        r = cmd.ExecuteReader
        While r.Read
            dr = dt.NewRow
            dr("ID") = r("ID")
            dr("Tra_ID") = r("Tra_ID")
            dr("Voucher_ID") = r("Voucher_ID")
            dr("Voucher_No") = r("Voucher_No")
            dr("Voucher_Type") = r("Voucher_Type")
            'dr("CR_DR") = r("CR_DR")
            'dr("Date") = r("Date")
            'dr("AccountID") = r("Account")
            'dr("Account") = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Name", "ID = '" & r("Account") & "'")
            'dr("Cr") = r("Cr")
            'dr("Dr") = r("Dr")
            'dr("Narration") = r("Narration")
            dr("Visible") = r("Visible")

            dt.Rows.Add(dr)
        End While

        r.Close()
        Return dt
    End Function
    Public Function Fill_Godown(cn As SQLiteConnection) As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow

        dt.Clear()
        dt.Columns.Add("ID")
        dt.Columns.Add("Name")
        dt.Columns.Add("Nickname")
        dt.Columns.Add("UnderID")
        dt.Columns.Add("Under")

        dt.Rows.Add("0", "Primary")

        cmd = New SQLiteCommand("Select * From TBL_Stock_Godown where Visible = 'Approval' and (Company = 'All' or Company = '" & Company_ID_str & "')", cn)
        Dim r As SQLiteDataReader
        r = cmd.ExecuteReader
        While r.Read
            dr = dt.NewRow
            dr("ID") = r("ID")
            dr("Name") = r("Name")
            dr("Nickname") = r("Nickname")
            dt.Rows.Add(dr)
        End While
        r.Close()
        Return dt
    End Function
    Public Function Fill_Stock_Category(cn As SQLiteConnection) As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow

        dt.Clear()
        dt.Columns.Add("ID")
        dt.Columns.Add("Name")
        dt.Columns.Add("Nickname")
        dt.Columns.Add("UnderID")
        dt.Columns.Add("Under")

        cmd = New SQLiteCommand("Select * From TBL_Stock_Category where Visible = 'Approval' and (Company = 'All' or Company = '" & Company_ID_str & "')", cn)
        Dim r As SQLiteDataReader
        r = cmd.ExecuteReader
        While r.Read
            dr = dt.NewRow
            dr("ID") = r("ID")
            dr("Name") = r("Name")
            dr("Nickname") = r("Nickname")
            dt.Rows.Add(dr)
        End While
        r.Close()
        Return dt
    End Function
    Public Function Fill_State(cn As SQLiteConnection) As DataTable
        Dim connn As New SQLiteConnection()

        Dim dt As New DataTable
        Dim dr As DataRow

        dt.Clear()
        dt.Columns.Add("ID")
        dt.Columns.Add("Name")

        dt.Rows.Add("0", "(Not Applicable)")
        Dim cmd As New SQLiteCommand("Select * From TBL_State", cn)
        Dim r As SQLiteDataReader
        r = cmd.ExecuteReader
        While r.Read
            dr = dt.NewRow
            dr("ID") = r("ID")
            dr("Name") = r("Name")
        End While
        r.Close()
        Return dt
    End Function
    Public Function Filter_Vouchers(ob As String) As String
        Dim St As String
        If open_MSSQL(Database_File.cre) = True Then
            Try
                St = $"(Voucher_No LIKE '%{ob.Trim}%')"
            Catch ex As Exception

            End Try
            Return St
        End If
    End Function
    Public Function Fill_Voucher_Create() As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow

        dt.Clear()
        dt.Columns.Add("ID")
        dt.Columns.Add("Name")

        dt.Rows.Clear()
        dt.Rows.Add("All Vouchers", "All Vouchers")
        dt.Rows.Add("Attendance", "Attendance")
        dt.Rows.Add("Contra", "Contra")
        dt.Rows.Add("Credit Note", "Credit Note")
        dt.Rows.Add("Debit Note", "Debit Note")
        dt.Rows.Add("Journal", "Journal")
        dt.Rows.Add("Payment", "Payment")
        dt.Rows.Add("Payroll", "Payroll")
        dt.Rows.Add("Purchase", "Purchase")
        dt.Rows.Add("Purchase Order", "Purchase Oredr")
        dt.Rows.Add("Receipt", "Receipt")
        dt.Rows.Add("Sales", "Sales")
        dt.Rows.Add("Sales Order", "Sales Order")
        dt.Rows.Add("Outward Register", "Outward Register")
        dt.Rows.Add("Inward Register", "Inward Register")
        dt.Rows.Add("Stock Journal", "Stock Journal")

        Return dt
    End Function
    Public Function Fill_Stock_Item(cn As SQLiteConnection) As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow

        dt.Clear()
        dt.Columns.Add("ID")
        dt.Columns.Add("Name")
        dt.Columns.Add("Alias")
        dt.Columns.Add("Description")
        dt.Columns.Add("Note")
        dt.Columns.Add("UnderID")
        dt.Columns.Add("Under")
        dt.Columns.Add("UnitID")
        dt.Columns.Add("Unit")
        dt.Columns.Add("HSN_Code")
        dt.Columns.Add("Tax_Type")
        dt.Columns.Add("OB_Quantity")
        dt.Columns.Add("OB_Rate")
        dt.Columns.Add("OB_per")
        dt.Columns.Add("OB_Value")
        dt.Columns.Add("Category")
        dt.Columns.Add("Part_Name")
        dt.Columns.Add("Alternative_Unit")
        dt.Columns.Add("Costing_Method")
        dt.Columns.Add("BOM_YN")
        dt.Columns.Add("Stock")

        dt.Rows.Add("0", "End of List", "", "", "", "End of List")

        cmd = New SQLiteCommand("Select * From TBL_Stock_Item where (Company = 'All' or Company = '" & Company_ID_str & "') and Visible = 'Approval'", cn)
        Dim r As SQLiteDataReader
        r = cmd.ExecuteReader
        While r.Read
            dr = dt.NewRow
            dr("ID") = r("ID")
            dr("Name") = r("Name")
            dr("Alias") = r("Alias")
            dr("Description") = r("Description")
            dr("Note") = r("Note")
            dr("UnderID") = r("Under")
            dr("Under") = "" 'Find_DT_Value(Database_File.cre, "TBL_Stock_Group", "Name", "ID = '" & r("Under") & "'")
            dr("UnitID") = r("Unit")
            dr("Unit") = Find_DT_Unit_Conves(r("Unit"))
            dr("HSN_Code") = r("HSN_Code")
            dr("Tax_Type") = r("Tax_Type")
            dr("OB_Quantity") = r("OB_Quantity")
            dr("OB_Rate") = r("OB_Rate")
            dr("OB_per") = r("OB_per")
            dr("OB_Value") = r("OB_Value")
            dr("Category") = r("Category")
            dr("Part_Name") = r("Part_Name")
            dr("Alternative_Unit") = r("Alternative_Unit")
            dr("Costing_Method") = r("Costing_Method")
            dr("BOM_YN") = r("BOM_YN")
            dr("Stock") = "" 'nUmBeR_FORMATE(Item_Closing_Stock(r("ID"), Date_)) & " " & Find_DT_Unit_Conves(r("Unit"))

            dt.Rows.Add(dr)
        End While
        r.Close()

        Return dt
    End Function
    Public Function Fill_Stock_Group(cn As SQLiteConnection) As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow

        dt.Clear()
        dt.Columns.Add("Name")
        dt.Columns.Add("Nickname")
        dt.Columns.Add("ID")
        dt.Columns.Add("UnderID")
        dt.Columns.Add("Under")
        dt.Columns.Add("Head")
        dt.Rows.Add("Primary", "", "0")
        cmd = New SQLiteCommand("Select * From TBL_Stock_Group where (Head = 'Stock' or Head = 'All') and Visible = 'Approval'", cn)
        Dim r As SQLiteDataReader
        r = cmd.ExecuteReader
        While r.Read
            dr = dt.NewRow
            dr("Name") = r("Name")
            dr("ID") = r("ID")
            dr("Nickname") = r("Nickname")
            dr("UnderID") = r("Under")
            dr("Under") = Find_DT_Value(Database_File.cre, "TBL_Stock_Group", "Name", "(Company = 'All' or Company = '" & Company_ID_str & "') and (Visible = 'Approval') and (ID = '" & r("Under") & "')")
            dr("Head") = r("Head")
            dt.Rows.Add(dr)
        End While
        r.Close()
        Return dt
    End Function
    Public Function Fill_Payroll_Group(cn As SQLiteConnection) As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow

        dt.Clear()
        dt.Columns.Add("ID")
        dt.Columns.Add("Name")
        dt.Columns.Add("Nickname")
        dt.Columns.Add("UnderID")
        dt.Columns.Add("Under")

        dt.Rows.Add("0", "Primary", "", "", "")

        cmd = New SQLiteCommand("Select * From TBL_Stock_Group where (Head = 'Payroll' or Head = 'All') and Visible = 'Approval'", cn)
        Dim r As SQLiteDataReader
        r = cmd.ExecuteReader
        While r.Read
            dr = dt.NewRow
            dr("ID") = r("ID")
            dr("Name") = r("Name")
            dr("Nickname") = r("Nickname")
            dr("UnderID") = r("Under")
            dr("Under") = Find_DT_Value(Database_File.cre, "TBL_Stock_Group", "Name", "(Company = 'All' or Company = '" & Company_ID_str & "') and (Visible = 'Approval') and (ID = '" & r("Under") & "')")
            dt.Rows.Add(dr)
        End While
        r.Close()

        Return dt
    End Function

    Public Function Fill_All_Unit(cn As SQLiteConnection) As DataTable

        Dim dt As New DataTable
        Dim dr As DataRow

        dt.Clear()
        dt.Columns.Add("Name")
        dt.Columns.Add("Formal_Name")
        dt.Columns.Add("ID")
        dt.Columns.Add("Symbol")
        dt.Columns.Add("Type")
        dt.Columns.Add("UQC")
        dt.Columns.Add("Decimal")
        dt.Columns.Add("Unit1")
        dt.Columns.Add("Conversion")
        dt.Columns.Add("Unit2")
        dt.Rows.Add("(Not Applicable)", "", "", "", "Not Applicable")

        cmd = New SQLiteCommand("Select * From TBL_Inventory_Unit where " & Company_Visible_Filter, cn)
        Dim r As SQLiteDataReader
        r = cmd.ExecuteReader
        While r.Read
            dr = dt.NewRow
            dr("ID") = r("ID")
            If r("Type") = "Compound" Then
                dr("Name") = Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "Symbol", "ID = '" & r("Unit1") & "'") & " of " & r("Conversion") & " " & Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "Symbol", "ID = '" & r("Unit2") & "'")
            Else
                dr("Name") = r("Symbol")
            End If
            dr("Type") = r("Type")
            dr("Symbol") = r("Symbol")
            dr("Formal_Name") = r("Formal_Name")
            dr("UQC") = r("UQC")
            dr("Decimal") = r("Decimal")
            dr("Unit1") = r("Unit1")
            dr("Conversion") = r("Conversion")
            dr("Unit2") = r("Unit2")
            dt.Rows.Add(dr)
        End While
        r.Close()
        Return dt
    End Function

    Public Function Fill_Payroll_Attenda_Production_Type(cn As SQLiteConnection) As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow

        dt.Clear()
        dt.Columns.Add("ID")
        dt.Columns.Add("Name")
        dt.Columns.Add("UnderId")
        dt.Columns.Add("Under")
        dt.Columns.Add("alias")
        dt.Columns.Add("Attendance_Type")
        dt.Columns.Add("UnitID")
        dt.Columns.Add("Unit")


        cmd = New SQLiteCommand("Select * From TBL_Payroll_Att_Production_Type where " & Company_Visible_Filter, cn)
        Dim r As SQLiteDataReader
        r = cmd.ExecuteReader
        While r.Read
            dr = dt.NewRow
            dr("ID") = r("ID")
            dr("Name") = r("Name")
            dr("alias") = r("alias")
            dr("Attendance_Type") = r("Attendance_Type")
            dr("UnitID") = r("Unit")
            If r("Attendance_Type") = "Production" Then
                dr("Unit") = Find_DT_Unit_Conves(r("Unit"))
            Else
                dr("Unit") = "Day"
            End If

            dt.Rows.Add(dr)
        End While
        r.Close()

        Return dt
    End Function
    Public Function Fill_Payroll_Employee(cn As SQLiteConnection) As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow

        dt.Clear()
        dt.Columns.Add("ID")
        dt.Columns.Add("Name")
        dt.Columns.Add("UnderID")
        dt.Columns.Add("Under")
        dt.Columns.Add("Date_of_joining")
        dt.Columns.Add("Mobile1")
        dt.Columns.Add("Mobile2")
        dt.Columns.Add("Email")
        dt.Columns.Add("Gender")
        dt.Columns.Add("Date_of_birth")
        dt.Columns.Add("Father_Name")
        dt.Columns.Add("Father_Mobile")
        dt.Columns.Add("Pincode")
        dt.Columns.Add("State")
        dt.Columns.Add("Dis")
        dt.Columns.Add("Taluka")
        dt.Columns.Add("City")
        dt.Columns.Add("Address")
        dt.Columns.Add("Bank_Name")
        dt.Columns.Add("Bank_Branch")
        dt.Columns.Add("Bank_IFSC_code")
        dt.Columns.Add("Bank_AccounNo")

        dt.Rows.Add("0", "End of List")
        cmd = New SQLiteCommand("Select * From TBL_Payroll_Employee where " & Company_Visible_Filter, cn)
        Dim r As SQLiteDataReader
        r = cmd.ExecuteReader
        While r.Read
            dr = dt.NewRow
            dr("ID") = r("ID")
            dr("Name") = r("Name")
            dr("UnderID") = r("Under")
            dr("Under") = Find_DT_Value(Database_File.cre, "TBL_Stock_Group", "Name", "(ID = '" & r("Under") & "') and Head = 'Payroll'")
            dr("Date_of_joining") = r("Date_of_joining")
            dr("Mobile1") = r("Mobile1")
            dr("Mobile2") = r("Mobile2")
            dr("Email") = r("Email")
            dr("Gender") = r("Gender")
            dr("Date_of_birth") = r("Date_of_birth")
            dr("Father_Name") = r("Father_Name")
            dr("Father_Mobile") = r("Father_Mobile")
            dr("Pincode") = r("Pincode")
            dr("State") = r("State")
            dr("Dis") = r("Dis")
            dr("Taluka") = r("Taluka")
            dr("City") = r("City")
            dr("Address") = r("Address")
            dr("Bank_Name") = r("Bank_Name")
            dr("Bank_Branch") = r("Bank_Branch")
            dr("Bank_IFSC_code") = r("Bank_IFSC_code")
            dr("Bank_AccounNo") = r("Bank_AccounNo")
            dt.Rows.Add(dr)
        End While
        r.Close()

        Return dt
    End Function
    Public Function Fill_Payroll_Payhead(cn As SQLiteConnection) As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow

        dt.Clear()
        dt.Columns.Add("ID")
        dt.Columns.Add("Name")
        dt.Columns.Add("alias")
        dt.Columns.Add("UnderId")
        dt.Columns.Add("Under")
        dt.Columns.Add("Payhead_Type")
        dt.Columns.Add("Cal_Type")
        dt.Columns.Add("Leave_without_pay")
        dt.Columns.Add("Cal")
        dt.Columns.Add("Production")
        dt.Columns.Add("OB_CR")
        dt.Columns.Add("OB_DR")

        dt.Rows.Add("0", "End of List", "", "", "", "", "", "", "", "", "", "")

        cmd = New SQLiteCommand("Select * From TBL_PayHead where " & Company_Visible_Filter, cn)
        Dim r As SQLiteDataReader
        r = cmd.ExecuteReader
        While r.Read
            dr = dt.NewRow
            dr("ID") = r("ID")
            dr("Name") = r("Name")
            dr("alias") = r("alias")
            dr("UnderId") = r("Under")
            dr("Under") = Find_DT_Value(Database_File.cre, "TBL_PayHead", "Name", "(ID = '" & r("Under") & "')")
            dr("Payhead_Type") = r("Payhead_Type")
            dr("Cal_Type") = r("Cal_Type")
            dr("Leave_without_pay") = r("Leave_without_pay")
            dr("Cal") = r("Cal")
            dr("Production") = r("Production")
            dr("OB_CR") = r("OB_CR")
            dr("OB_DR") = r("OB_DR")
            dt.Rows.Add(dr)
        End While
        r.Close()
        Return dt
    End Function
    Public Function Fill_Currency(cn As SQLiteConnection) As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow
        dt.Clear()
        dt.Columns.Add("Code")
        dt.Columns.Add("Country_Name")
        dt.Columns.Add("Currency_Name")
        dt.Columns.Add("Symbol")
        dt.Columns.Add("Name")
        cmd = New SQLiteCommand("Select * From TBL_Currency", cn)
        Dim r As SQLiteDataReader
        r = cmd.ExecuteReader
        While r.Read
            dr = dt.NewRow
            dr("Code") = r("Code")
            dr("Country_Name") = r("Country_Name")
            dr("Currency_Name") = r("Currency_Name")
            dr("Symbol") = r("Symbol")
            dr("Name") = r("Code") & " (" & r("Currency_Name") & ")"
            dt.Rows.Add(dr)
        End While
        r.Close()
        Return dt
    End Function
    Public Function Fill_Country(cn As SQLiteConnection) As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow
        dt.Clear()
        dt.Columns.Add("Country_Name")
        dt.Columns.Add("Code")
        cmd = New SQLiteCommand("Select * From TBL_Currency", con)
        Dim r As SQLiteDataReader
        r = cmd.ExecuteReader
        While r.Read
            dr = dt.NewRow
            dr("Country_Name") = r("Country_Name")
            dr("Code") = r("Code")
            dt.Rows.Add(dr)
        End While
        r.Close()
        Return dt
    End Function
    Public Function Fill_TAX(cn As SQLiteConnection) As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow

        dt.Clear()
        dt.Columns.Add("Name")
        dt.Columns.Add("NickName")
        dt.Columns.Add("ID")
        dt.Columns.Add("Under")
        dt.Columns.Add("Percentage")
        dt.Columns.Add("Discription")
        dt.Columns.Add("Company")
        dt.Columns.Add("Visible")

        cmd = New SQLiteCommand("Select * From TBL_TAX", cn)
        Dim r As SQLiteDataReader
        r = cmd.ExecuteReader
        While r.Read
            dr = dt.NewRow
            dr("Name") = r("Name")
            dr("NickName") = r("NickName")
            dr("Under") = r("Under")
            dr("Percentage") = r("Percentage")
            dr("Discription") = r("Discription")
            dr("Company") = r("Company")
            dr("Visible") = r("Visible")
            dt.Rows.Add(dr)
        End While
        r.Close()

        Return dt
    End Function
    Public Function Fill_UQC(cn As SQLiteConnection) As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow

        dt.Clear()
        dt.Columns.Add("ID")
        dt.Columns.Add("Shortcut")
        dt.Columns.Add("Full_Name")

        cmd = New SQLiteCommand("Select * From TBL_UQC", cn)
        Dim r As SQLiteDataReader
        r = cmd.ExecuteReader
        While r.Read
            dr = dt.NewRow
            dr("ID") = r("ID")
            dr("Shortcut") = r("Shortcut")
            dr("Full_Name") = r("Full_Name")
            dt.Rows.Add(dr)
        End While
        r.Close()

        Return dt
    End Function
    Public Function Fill_HSN_Code(cn As SQLiteConnection) As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow

        dt.Clear()
        dt.Columns.Add("HSN_Code")
        dt.Columns.Add("Description")

        cmd = New SQLiteCommand("Select * From TBL_HSN", cn)
        Dim r As SQLiteDataReader
        r = cmd.ExecuteReader
        While r.Read
            dr = dt.NewRow
            dr("HSN_Code") = r("HSN_Code")
            dr("Description") = r("Description")
            dt.Rows.Add(dr)
        End While
        r.Close()
        Return dt
    End Function
    Public Function Fill_Address(cn As SQLiteConnection) As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow
        dt.Clear()
        dt.Columns.Add("Pincode")
        dt.Columns.Add("City")
        dt.Columns.Add("Taluka")
        dt.Columns.Add("Dis")
        dt.Columns.Add("State")

        cmd = New SQLiteCommand("Select * From TBL_Address", cn)
        Dim r As SQLiteDataReader
        r = cmd.ExecuteReader
        While r.Read
            dr = dt.NewRow
            dr("Pincode") = r("Pincode")
            dr("City") = r("City")
            dr("Taluka") = r("Taluka")
            dr("Dis") = r("Dis")
            dr("State") = r("State")
            dt.Rows.Add(dr)
        End While
        r.Close()
        Return dt
    End Function
    Public Function Fill_Voucher_Data(cn As SQLiteConnection) As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow
        dt.Clear()
        dt.Columns.Add("ID")
        dt.Columns.Add("Name")

        cmd = New SQLiteCommand("Select * From TBL_Voucher_Create where Visible = 'Approval'", cn)
        Dim r As SQLiteDataReader
        r = cmd.ExecuteReader
        While r.Read
            dr = dt.NewRow
            dr("ID") = r("ID")
            dr("Name") = r("Name")
            dt.Rows.Add(dr)
        End While
        r.Close()
        Return dt
    End Function
    Public Function Shortcut_create(frm As Form, sender As Object)
        sHortcut_open_frm(frm, sender, "", "Create_Close", "")
        Link_to_frm = {"Stock Group"}
    End Function
    Public Function Fill_All_Table()
        'Fill_Acc_Group()
        'Fill_Ledger(Now.Date)
        'Fill_Branch()
        'Fill_TAX()
        'Fill_UQC()
        'Fill_Stock_Group()
        'Fill_Stock_Category()
        'Fill_Godown()
        'Fill_HSN_Code()
        'Fill_Payroll_Group()
        'Fill_Stock_Item(Now.Date)
        'Fill_Address()
        'Fill_Payroll_Employee()
        'Fill_Payroll_Attenda_Production_Type()
        'Fill_Payroll_Payhead()
        'Fill_Voucher_Create()
        'Fill_Voucher_Data()
        'Fill_State()
        'Fill_All_Unit()
        'Fill_Vouchhers()
        'Fill_Currency()
    End Function
End Module
