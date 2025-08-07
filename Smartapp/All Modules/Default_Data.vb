Module Default_Data
    Public Application_Name As String = "Cryptonix"
    Public PC_Owner As String = ""
    Public Login_Type As String = ""
    Public Branch_Name As String = ""
    Public Branch_ID As String = ""
    Public Login_Name As String = ""
    Public Login_Phone As String = ""
    Public LOGIN_ID As String = ""

    Public User_FName As String = ""
    Public User_MName As String = ""
    Public User_LName As String = ""

    Public Login_UserName As String = ""
    Public Login_Email As String = ""

    Public PC_ID As String = ""

    Public Company_ID_str As String = ""
    Public Company_Name_str As String
    Public Company_Serial_str As String
    Public Company_Class_str As String
    Public Company_Address_str As String
    Public Company_Place_str As String
    Public Company_Phone_str As String
    Public Company_Email_str As String
    Public Company_GST_str As String
    Public Company_GST_Type_str As String
    Public Company_State_str As String
    Public Company_PAN_str As String
    Public Company_Bank_Name_str As String
    Public Company_Bank_Account_No_str As String
    Public Company_Bank_Branch_str As String
    Public Company_Bank_IFSC_Code_str As String
    Public Company_RegNo_str As String
    Public Company_UPI_str As String
    Public Company_City_str As String
    Public Company_Pincode_str As String
    Public Company_Book_frm As Date
    Public Update_Report As Boolean
    Public Login_YN As Boolean = False
    Public Lite_date_Format As String = "yyyy-MM-dd"
    Public Company_Ststus_str As String
    Public Auto_Logout_YN As Boolean = False
    Public Auto_Logout_Sec As Integer = 300

    Public Login_Type_str As String

    Public Company_Server_str As String = ""
    Public Company_Server_Database_str As String = ""
    Public Company_Server_UserName_str As String = ""
    Public Company_Server_Password_str As String = ""

    Public Company_Icn As Image = My.Resources.No_Image
    Public Company_stmp As Image = My.Resources.No_Image
    Public Company_sig As Image = My.Resources.No_Image

    Public dft_Godown_Name As String = "All Godown"

    Public LC_ID_str As String = "NA"
    Public LC_Name As String = ""
    Public LC_Phone As String = ""
    Public LC_Email As String = ""
    Public LC_Status As String = ""
    Public LC_Message As String = ""
    Public LC_Expir As Date
    Public LC_Timer As Integer
    Public Device_Name_str As String = ""
    Public LC_Photo As Image


    Public User_Icn As Image = My.Resources.No_Image
    Public Print_DT_Company As New DataTable
    Public Duplicate_Screen As Boolean = False
    Public User_Full_Name As String = ""
    Public User_Branch_ID As String = ""
    Public User_Branch_Name As String = ""
    Public User_Phone As String = ""
    Public User_Email As String = ""
    Public User_ID As String = ""
    Public User_Name As String = ""

    Public Login_Password As String = ""
End Module
