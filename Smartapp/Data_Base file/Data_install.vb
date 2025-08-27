Imports System.Data.SqlClient
Imports System.Data.SQLite

Module Data_install
	Public Class_ As String
	Public Function Fill_All_Data(st As String, VC_ID_ As String, Path_TXT As String)

	End Function

	Public Function cmp_qry() As String
		Return $"CREATE TABLE 'TBL_Company_Creation' (
	'Id'	INTEGER NOT NULL UNIQUE,
	'CompanyName'	TEXT,
	'Book_Frm'	DATE,
	'Address'	TEXT,
	'CompanySerial'	TEXT,
	'RegNo'	TEXT,
	'GST_Type'	TEXT,
	'GSTNo'	TEXT,
	'PANCard'	TEXT,
	'Email'	TEXT,
	'Phone'	TEXT,
	'PinCode'	TEXT,
	'Country'	TEXT,
	'State'	TEXT,
	'District'	TEXT,
	'Taluk'	TEXT,
	'City'	TEXT,
	'LocationID'	TEXT,
	'Bank'	TEXT,
	'Branch'	TEXT,
	'AccountNo'	TEXT,
	'IFCCode'	TEXT,
	'UPI'	TEXT,
	'UserName'	TEXT,
	'Password'	TEXT,
	'Class'	TEXT,
	'User'	TEXT,
	'Photo'	BLOB COLLATE BINARY,
	'Stamp'	BLOB COLLATE BINARY,
	'Signatory'	BLOB COLLATE BINARY,
	'Approval'	TEXT,
	'Branch_Division'	TEXT,
	'Godown'	TEXT,
	'Online'	TEXT,
	'Android'	TEXT,
	'Date'	DATE,
	'Package_Name'	TEXT,
	'Package_ID'	TEXT,
	'Package_Date'	DATETIME,
	'Package_Due_Date'	DATETIME,
	'Company_ID'	TEXT,
	'DB_Version'	TEXT,
	'Server_Name'	TEXT,
	'Server_Database'	TEXT,
	'Server_UserName'	TEXT,
	'Server_Password'	TEXT,
	'Audit_YN'	TEXT,
	PRIMARY KEY('Id' AUTOINCREMENT)
);

CREATE TABLE 'TBL_Features' (
	'Id'	INTEGER NOT NULL UNIQUE,
	'Head'	TEXT,
	'Value'	TEXT,
	'Discription'	TEXT,
	'Type'	TEXT,
	PRIMARY KEY('Id' AUTOINCREMENT)
);

CREATE TABLE 'TBL_Device' (
	'Device_ID'	TEXT,
	'Name'	TEXT,
	'PC_Name'	TEXT,
	'Type'	TEXT
);

CREATE TABLE 'TBL_User' (
	'User_ID'	INTEGER,
	'UserName'	TEXT,
	'Name'	TEXT,
	'Phone'	TEXT,
	'EMail'	TEXT
);

CREATE TABLE 'TBL_Email_Login' (
	'ID'	INTEGER NOT NULL UNIQUE,
	'Email Gateway'	TEXT,
	'Outgoing SMTP'	TEXT,
	'Server Port'	TEXT,
	'Email Address'	TEXT,
	'Password'	TEXT,
	PRIMARY KEY('ID' AUTOINCREMENT)

);

CREATE TABLE 'TBL_User_Authority' (
	'ID'	INTEGER NOT NULL UNIQUE,
	'Head'	TEXT,
	'Value'	TEXT,
	PRIMARY KEY('ID' AUTOINCREMENT)
);

CREATE TABLE 'TBL_Info' ('ID' INTEGER NOT NULL UNIQUE,	'Head'	TEXT,	'Value'	TEXT,	PRIMARY KEY('ID' AUTOINCREMENT));
INSERT INTO TBL_Info (Head,Value) VALUES ('Verification','0');

{cmp_Login_Details()}
"
	End Function
	Public Function cmp_Login_Details()
		Return "CREATE TABLE 'TBL_Login_Details' (
	'ID'	INTEGER,
	'Type'	TEXT,
	'UserName'	TEXT,
	'FullName'	TEXT,
	'Email'	TEXT,
	'Phone'	TEXT,
	'Signature'	BLOB COLLATE BINARY
);
"
	End Function
	Public Function cre_qry() As String
		Return $"CREATE TABLE 'TBL_Acc_Group' (
	'Id'	INTEGER NOT NULL UNIQUE,
	'Name'	TEXT,
	'Nickname'	TEXT,
	'UserGroup'	TEXT,
	'HeadGroup'	TEXT,
	'Company'	TEXT,
	'User'	TEXT,
	'Date_install'	DATETIME,
	'PC'	TEXT,
	'Visible'	TEXT,
	'Head'	TEXT,
	'Communication_Whatsapp'	TEXT,
	'Communication_Email'	TEXT,
	PRIMARY KEY('Id' AUTOINCREMENT)
);

CREATE TABLE 'TBL_Attendance_VC' (
	'Id'	INTEGER NOT NULL UNIQUE,
	'Date'	DATE,
	'Payroll_ID'	TEXT,
	'Voucher_Type_ID'	TEXT,
	'Voucher_ID'	TEXT,
	'Voucher_No'	TEXT,
	'Voucher_Type'	TEXT,
	'Account'	TEXT,
	'CR_DR'	TEXT,
	'Branch'	TEXT,
	'Particuls'	TEXT,
	'Payhead'	TEXT,
	'Narrtion'	TEXT,
	'Value'	NUMERIC,
	'Amount'	NUMERIC,
	'Balance'	TEXT,
	'Pay'	TEXT,
	'Tra_ID'	INT,
	'Visible'	TEXT,
	'Company'	TEXT,
	'User'	TEXT,
	'Date_install'	DATETIME,
	'PC'	TEXT,
	'Employee'	TEXT,
	'Attendance_ID'	TEXT,
	'TBL_VC_ID'	TEXT,
	PRIMARY KEY('Id' AUTOINCREMENT)
);
CREATE TABLE 'TBL_Batch' (
	'ID'	INTEGER NOT NULL UNIQUE,
	'Item'	INTEGER,
	'Name'	TEXT,
	'Production_Qty'	TEXT,
	'Company'	TEXT,
	'User'	TEXT,
	'PC'	TEXT,
	'Date_install'	DATETIME,
	PRIMARY KEY('ID' AUTOINCREMENT)
);
CREATE TABLE 'TBL_Batch_Item' (
	'ID'	INTEGER NOT NULL UNIQUE,
	'Batch'	TEXT,
	'Item'	INTEGER,
	'Qty'	INTEGER,
	PRIMARY KEY('ID' AUTOINCREMENT)
);
CREATE TABLE 'TBL_BOM' ('Id' INTEGER NOT NULL UNIQUE,'Production_Item' TEXT NULL ,'Production_Quantity' TEXT NULL ,'Item_Source' TEXT NULL ,'Quantity_Source' TEXT NULL ,'Company' TEXT NULL ,'User' TEXT NULL ,'PC' TEXT NULL ,'Date_install' DATETIME NULL ,PRIMARY KEY('Id' AUTOINCREMENT));
CREATE TABLE 'TBL_E-mandi' (
	'Id'	INTEGER NOT NULL UNIQUE,
	'Tra_ID'	INT,
	'Date'	DATE,
	'Vepari'	TEXT,
	'Item'	TEXT,
	'Unit'	TEXT,
	'Dagina'	TEXT,
	'Dagina_Kona'	TEXT,
	'Qty'	TEXT,
	'Rate'	TEXT,
	'Amount'	TEXT,
	'Commission'	TEXT,
	'Chrage'	TEXT,
	'TBL_VC_ID'	TEXT,
	'TBL_IT_ID'	TEXT,
	'Cash_ID'	TEXT,
	'Farmer_ID'	TEXT,
	'Tra_ID_Farmer'	TEXT,
	'User'	TEXT,
	'Date_Install'	DATETIME,
	'PC'	TEXT,
	'Visible'	TEXT,
	PRIMARY KEY('Id' AUTOINCREMENT)
);
CREATE TABLE 'TBL_EwayBill' (
	'ID'	INTEGER NOT NULL UNIQUE,
	'Tra_ID'	INTEGER,
	'ewaybill_no'	TEXT,
	'Date'	DATETIME,
	'Sub_Type'	TEXT,
	'Document_Type'	TEXT,
	'Consignee_F'	TEXT,
	'Address1_F'	TEXT,
	'Address2_F'	TEXT,
	'Please_F'	TEXT,
	'Pincode_F'	TEXT,
	'GSTIN_F'	TEXT,
	'State_F'	TEXT,
	'Consignee_T'	TEXT,
	'Address1_T'	TEXT,
	'Address2_T'	TEXT,
	'Please_T'	TEXT,
	'Pincode_T'	TEXT,
	'GSTIN_T'	TEXT,
	'State_T'	TEXT,
	'Mode'	TEXT,
	'Distance'	TEXT,
	'Transport_Name'	TEXT,
	'Transport_ID'	TEXT,
	'Vehicle_No'	TEXT,
	'Vehicle_Type'	TEXT,
	'LR_No'	TEXT,
	'Dispatch_State'	TEXT,
	'Ship_State'	TEXT,
	PRIMARY KEY('ID' AUTOINCREMENT)
);
CREATE TABLE 'TBL_Inventory_Unit' ('Id' INTEGER NOT NULL UNIQUE,'Type' TEXT NOT NULL ,'Symbol' TEXT NULL ,'Formal_Name' TEXT NULL ,'UQC' TEXT NULL ,'Decimal' DECIMAL (1) NULL ,'Unit1' TEXT NULL ,'Conversion' TEXT NULL ,'Unit2' TEXT NULL ,'Company' TEXT NULL ,'Visible' TEXT NULL ,'Head' TEXT NULL ,'User' TEXT NULL ,'PC' TEXT NULL ,'Date_install' DATETIME NULL ,PRIMARY KEY('Id' AUTOINCREMENT));
CREATE TABLE 'TBL_Ledger' (
	'Id'	INTEGER NOT NULL UNIQUE,
	'Name'	TEXT NOT NULL,
	'Alise'	TEXT,
	'Group'	TEXT NOT NULL,
	'Phone'	TEXT,
	'Email'	TEXT,
	'DOB'	DATE,
	'Gender'	TEXT,
	'Country'	TEXT,
	'PinCode'	TEXT,
	'State'	TEXT,
	'Dis'	TEXT,
	'Taluka'	TEXT,
	'City'	TEXT,
	'Address'	TEXT,
	'OB_CR'	NUMERIC,
	'OB_DR'	NUMERIC,
	'Cradit'	NUMERIC,
	'Cradit_Days'	NUMERIC,
	'Discription'	TEXT,
	'Note'	TEXT,
	'GST_Type'	TEXT,
	'GSTNo'	TEXT,
	'PANCardNo'	TEXT,
	'DocumentType'	TEXT,
	'DocumentNo'	TEXT,
	'Photo'	BLOB COLLATE BINARY,
	'BankName'	TEXT,
	'AccountNo'	TEXT,
	'Branch'	TEXT,
	'IFSCCode'	TEXT,
	'Company'	TEXT,
	'Visible'	TEXT,
	'TAX_Type'	TEXT,
	'TypeOfDuty'	TEXT,
	'PercentageOfCalculation'	NUMERIC,
	'TAX_Class'	TEXT,
	'User'	TEXT,
	'PC'	TEXT,
	'Date_install'	DATETIME,
	'Communication_Type'	TEXT,
	'Communication_Whatsapp'	TEXT,
	'Communication_Email'	TEXT,
	'CHEQUE_Print'	TEXT,
	'Aadhaar'	TEXT,
	PRIMARY KEY('Id' AUTOINCREMENT)
);

INSERT INTO TBL_Ledger ('Name', 'Group', 'Company', 'Visible', 'User', 'PC', 'Date_install') VALUES ('Cash', '27', 'Defolt', 'Approval','admin','0','2024-02-15 22:38:30.9023496');

CREATE TABLE 'TBL_Cheque_Design' (
	'ID'	INTEGER NOT NULL UNIQUE,
	'Ledger_ID'	INTEGER,
	'Width'	INTEGER,
	'Height'	INTEGER,
	'Cross_Top'	INTEGER,
	'Cross_Left'	INTEGER,
	'Date_Top'	INTEGER,
	'Date_Left'	INTEGER,
	'Date_Format'	TEXT,
	'Date_Separator'	TEXT,
	'Date_Distance'	INTEGER,
	'Party_Top'	INTEGER,
	'Party_Left'	INTEGER,
	'Party_Width'	INTEGER,
	'Amount_Word_1_Top'	INTEGER,
	'Amount_Word_1_Left'	INTEGER,
	'Amount_Word_1_Width'	INTEGER,
	'Amount_Word_2_Top'	INTEGER,
	'Amount_Word_2_Left'	INTEGER,
	'Amount_Word_2_Width'	INTEGER,
	'Amount_Top'	INTEGER,
	'Amount_Left'	INTEGER,
	'Amount_Width'	INTEGER,
	PRIMARY KEY('ID' AUTOINCREMENT)
);

CREATE TABLE 'TBL_Stock_Item_Opning_Stock' (
	'ID'	INTEGER NOT NULL UNIQUE,
	'Item_ID'	INTEGER,
	'Branch_ID'	INTEGER,
	'Applicable'	TEXT,
	'Stock'	TEXT,
	PRIMARY KEY('ID' AUTOINCREMENT)
);
CREATE TABLE 'TBL_Ledger_Opning_Balance' (
	'ID'	INTEGER NOT NULL UNIQUE,
	'Ledger_ID'	INTEGER,
	'Branch_ID'	INTEGER,
	'Applicable'	TEXT,
	'OB_Dr'	TEXT,
	'OB_Cr'	TEXT,
	PRIMARY KEY('ID' AUTOINCREMENT)
);
CREATE TABLE 'TBL_Loan_Installments' (
	'Id'	INTEGER NOT NULL UNIQUE,
	'Tra_ID'	TEXT,
	'Loan_ID'	TEXT,
	'Loan_Type'	TEXT,
	'Employee_ID'	TEXT,
	'From'	DATE,
	'To'	DATE,
	'Loan_Amount'	NUMERIC,
	'Interest'	NUMERIC,
	'Installment'	NUMERIC,
	'Closing'	TEXT,
	PRIMARY KEY('Id' AUTOINCREMENT)
);
CREATE TABLE 'TBL_Loan_sanction' ('Id' INTEGER NOT NULL UNIQUE,'Employee_ID' TEXT NULL ,'Sanction_Date' DATE NULL ,'Instalments_Date' DATE NULL ,'Guarantor_ID' TEXT NULL ,'Head_of_Department' TEXT NULL ,'Loan_Amount' NUMERIC NULL ,'Loan_Type' TEXT NULL ,'Particuls' NUMERIC NULL ,'Instalments' NUMERIC NULL ,'Last_Instalments' NUMERIC NULL ,'Particuls_Type' TEXT NULL ,'Interest_Rate' NUMERIC NULL ,'Company' TEXT NULL ,'Visible' TEXT NULL ,'User' TEXT NULL ,'Date_Install' DATETIME NULL ,'PC' TEXT NULL ,PRIMARY KEY('Id' AUTOINCREMENT));
CREATE TABLE 'TBL_PayHead' ('Id' INTEGER NOT NULL UNIQUE,'Name' TEXT NOT NULL ,'alias' TEXT NULL ,'Under' TEXT NOT NULL ,'Payhead_Type' TEXT NOT NULL ,'Cal_Type' TEXT NULL ,'Leave_without_pay' TEXT NULL ,'Cal' TEXT NULL ,'Production' TEXT NULL ,'Computed' TEXT NULL ,'OB_CR' NUMERIC NULL ,'OB_DR' NUMERIC NULL ,'Company' TEXT NOT NULL ,'Visible' TEXT NOT NULL ,'User' TEXT NOT NULL ,'Date_install' DATETIME NOT NULL ,'PC' TEXT NOT NULL ,PRIMARY KEY('Id' AUTOINCREMENT));
CREATE TABLE 'TBL_Payhead_Formula' ('Id' INTEGER NOT NULL ,'Tra_ID' TEXT NULL ,'Date' DATE NULL ,'From_amt' TEXT NULL ,'To_amt' TEXT NULL ,'Sub_type' TEXT NULL ,'Value_Basis' TEXT NULL ,'User' TEXT NOT NULL ,'Date_install' DATETIME NOT NULL ,'PC' TEXT NOT NULL );
CREATE TABLE 'TBL_Payroll_Att_Production_Type' ('Id' INTEGER NOT NULL UNIQUE,'Name' TEXT NOT NULL ,'alias' TEXT NULL ,'Attendance_Type' TEXT NOT NULL ,'Unit' TEXT NULL ,'Company' TEXT NULL ,'Visible' TEXT NULL ,'User' TEXT NULL ,'Date_install' DATETIME NULL ,'PC' TEXT NULL ,PRIMARY KEY('Id' AUTOINCREMENT));
CREATE TABLE 'TBL_Payroll_Employee' ('Id' INTEGER NOT NULL UNIQUE,'Name' TEXT NOT NULL ,'alias' TEXT NULL ,'Discription' TEXT NULL ,'Note' TEXT NULL ,'Under' TEXT NULL ,'Date_of_joining' DATE NOT NULL ,'Mobile1' TEXT NULL ,'Mobile2' TEXT NULL ,'Aadhaar' TEXT NULL ,'PAN' TEXT NULL ,'Salary' TEXT NULL ,'PF_No' TEXT NULL ,'Email' TEXT NULL ,'Gender' TEXT NULL ,'Date_of_birth' TEXT NULL ,'Father_Name' TEXT NULL ,'Father_Mobile' TEXT NULL ,'Nominee' TEXT NULL ,'Pincode' TEXT NULL ,'State' TEXT NULL ,'Dis' TEXT NULL ,'Taluka' TEXT NULL ,'City' TEXT NULL ,'Address' TEXT NULL ,'Bank_Name' TEXT NULL ,'Bank_Branch' TEXT NULL ,'Bank_IFSC_code' TEXT NULL ,'Bank_AccounNo' TEXT NULL ,'Photo' BLOB NULL ,'Company' TEXT NULL ,'Visible' TEXT NULL ,'User' TEXT NULL ,'Date_install' DATETIME NULL ,'PC' TEXT NULL ,PRIMARY KEY('Id' AUTOINCREMENT));
CREATE TABLE 'TBL_Payroll_SalaryDetails' ('Id' INTEGER NOT NULL UNIQUE,'Account' TEXT NULL ,'Under' TEXT NULL ,'Date' DATE NULL ,'Payhead' TEXT NULL ,'LoanAcc' TEXT NULL ,'Rate' TEXT NULL ,'Date_of_deduction' TEXT NULL ,'installment_period' TEXT NULL ,'Company' TEXT NULL ,'Visible' TEXT NULL ,'User' TEXT NULL ,'Date_install' DATETIME NULL ,'PC' TEXT NULL ,PRIMARY KEY('Id' AUTOINCREMENT));
CREATE TABLE 'TBL_Item_Rate' (
	'ID'	INTEGER NOT NULL UNIQUE,
	'Type'	TEXT,
	'Item'	INTEGER,
	'Date'	DATE,
	'Rate'	NUMERIC,
	'Unit'	TEXT,
	PRIMARY KEY('ID' AUTOINCREMENT)
);
CREATE TABLE 'TBL_Stock_Category' ('Id' INTEGER NOT NULL UNIQUE,'Name' TEXT NULL ,'Nickname' TEXT NULL ,'Under' TEXT NULL ,'Company' TEXT NULL ,'User' TEXT NULL ,'Date_install' DATETIME NULL ,'PC' TEXT NULL ,'Visible' TEXT NULL ,PRIMARY KEY('Id' AUTOINCREMENT));
CREATE TABLE 'TBL_Stock_Godown' ('Id' INTEGER NOT NULL UNIQUE,'Name' TEXT NULL ,'Nickname' TEXT NULL ,'Under' TEXT NULL ,'Company' TEXT NULL ,'Visible' TEXT NULL ,'User' TEXT NULL ,'PC' TEXT NULL ,'Date_install' DATETIME NULL ,PRIMARY KEY('Id' AUTOINCREMENT));
CREATE TABLE 'TBL_Stock_Group' ('Id' INTEGER NOT NULL UNIQUE,'Name' TEXT NOT NULL ,'Nickname' TEXT NULL ,'Under' TEXT NULL ,'Head' TEXT NULL ,'Company' TEXT NULL ,'User' TEXT NULL ,'Date_install' DATETIME NULL ,'PC' TEXT NULL ,'Visible' TEXT NULL ,PRIMARY KEY('Id' AUTOINCREMENT));

CREATE TABLE 'TBL_Stock_Item' (
	'Id'	INTEGER NOT NULL UNIQUE,
	'Name'	TEXT NOT NULL,
	'Alias'	TEXT,
	'Barcode'	TEXT,
	'Description'	TEXT,
	'Note'	TEXT,
	'Under'	TEXT NOT NULL,
	'Unit'	TEXT NOT NULL,
	'Alter_Unit'	TEXT,
	'Alter_Unit_Val1'	NUMERIC,
	'Alter_Unit_Val2'	NUMERIC,
	'HSN_Code'	TEXT,
	'Tax_Type'	TEXT,
	'GST_Type'	TEXT,
	'Tax_Value'	NUMERIC,
	'Cess_Value'	NUMERIC,
	'OB_Quantity'	NUMERIC,
	'OB_Rate'	NUMERIC,
	'OB_per'	NUMERIC,
	'OB_Value'	NUMERIC,
	'Company'	TEXT,
	'Visible'	TEXT,
	'Category'	TEXT,
	'Part_Name'	TEXT,
	'Alternative_Unit'	TEXT,
	'Costing_Method'	TEXT,
	'STD_Rate_YN'	TEXT,
	'BOM_YN'	TEXT,
	'MRP'	TEXT,
	'User'	TEXT,
	'PC'	TEXT,
	'Date_install'	DATETIME,
	'Color'	TEXT,
	'GST_Applicable'	TEXT,
	'Batch_YN'	TEXT,
	'Mfg_YN'	TEXT,
	'Exp_YN'	TEXT,
	'Costing_Value_Type'	TEXT,
	'Market_Value_Type'	TEXT,
	'Sales_Rate'	TEXT,
	'Purchase_Rate'	TEXT,
	'Reorder_Qty'	TEXT,
	PRIMARY KEY('Id' AUTOINCREMENT)
);

CREATE TABLE 'TBL_TAX' ('Id' INTEGER NOT NULL UNIQUE,'Name' TEXT NULL ,'NickName' TEXT NULL ,'Under' TEXT NULL ,'Percentage' TEXT NULL ,'Discription' TEXT NULL ,'Company' TEXT NULL ,'Visible' TEXT NULL ,PRIMARY KEY('Id' AUTOINCREMENT));
CREATE TABLE 'TBL_Tranport' ('Id' INTEGER NOT NULL UNIQUE,'Name' TEXT NULL ,'Phone' TEXT NULL ,'Vehicle_Type' TEXT NULL ,'Vehicle_No' TEXT NULL ,'Company' TEXT NULL ,'Visible' TEXT NULL ,'User' TEXT NULL ,'Date_Install' DATETIME NULL ,'PC' TEXT NULL ,PRIMARY KEY('Id' AUTOINCREMENT));
CREATE TABLE 'TBL_UQC' ('Id' INTEGER NOT NULL UNIQUE,'Shortcut' TEXT NULL ,'Full_Name' TEXT NULL ,PRIMARY KEY('Id' AUTOINCREMENT));

CREATE TABLE 'TBL_VC' (
	'Id'	INTEGER NOT NULL UNIQUE,
	'Tra_ID'	INT NOT NULL,
	'Voucher_ID'	INT NOT NULL,
	'Voucher_No'	TEXT NOT NULL,
	'Head'	TEXT,
	'Supplier_IVC_No'	TEXT,
	'Supplier_IVC_Date'	DATE,
	'Order_No'	TEXT,
	'Delivery_Date'	DATE,
	'Register_No'	TEXT,
	'Bill_No'	TEXT,
	'Voucher_Type'	TEXT NOT NULL,
	'Voucher_Type_ID'	TEXT NOT NULL,
	'CR_DR'	TEXT,
	'Date'	DATE NOT NULL,
	'Under'	TEXT,
	'Account'	TEXT,
	'Particuls'	TEXT,
	'Fat'	TEXT,
	'Quantity'	NUMERIC,
	'Unit'	TEXT,
	'Rate'	NUMERIC,
	'Cr'	NUMERIC,
	'Dr'	NUMERIC,
	'Tax_Type'	TEXT,
	'Tax_Value'	NUMERIC,
	'TAX_per'	NUMERIC,
	'Payhead'	TEXT,
	'Loan_ID'	TEXT,
	'Loan_Type'	TEXT,
	'Branch'	TEXT,
	'Godown'	TEXT,
	'Narration'	TEXT,
	'Auto_Entry'	TEXT,
	'Auto_Date1'	DATE,
	'Auto_Date2'	DATE,
	'Mfg_Date'	DATE,
	'Expiry_Date'	DATE,
	'Batch_No'	TEXT,
	'Categoty'	TEXT,
	'EwayBill_YN'	TEXT,
	'Transport_YN'	TEXT,
	'Payment_Details_YN'	TEXT,
	'Company'	TEXT NOT NULL,
	'User'	TEXT NOT NULL,
	'Date_install'	DATETIME NOT NULL,
	'Visible'	TEXT NOT NULL,
	'PC'	TEXT NOT NULL,
	'Chrage'	NUMERIC,
	'Farmer'	TEXT,
	'Commition'	INTEGER,
	'Terms_Payment'	TEXT,
	'Ledger'	INTEGER,
	'Credit_Amount'	TEXT,
	'Debit_Amount'	TEXT,
	'Employee'	TEXT,
	'Type'	TEXT,
	'Effect_Stock'	TEXT,
	'Effect_Ledger'	TEXT,
	'Effect_PayHead'	TEXT,
	'Effect_Employee'	TEXT,
	'Round_Off'	TEXT,
	'Supplier_Nerration'	TEXT,
	'Cr_Dr_note_resion'	TEXT,
	'Ledger_Closing'	TEXT,
	'Class_ID'	INTEGER,
	PRIMARY KEY('Id' AUTOINCREMENT));

CREATE TABLE 'TBL_VC_Ledger' (
	'ID'	INTEGER NOT NULL UNIQUE,
	'Type'	TEXT,
	'Date'	Date,
	'Tra_ID'	INTEGER,
	'Ledger'	INTEGER,
	'Rate'	INTEGER,
	'Type_of_Calculation'	TEXT,
	'Rounding_Method'	TEXT,
	'Rounding_Limit'	TEXT,
	'Dr'	TEXT,
	'Cr'	TEXT,
	'Narration'	TEXT,
	PRIMARY KEY('ID' AUTOINCREMENT));

CREATE TABLE 'TBL_VC_Other' (
	'Id'	INTEGER NOT NULL UNIQUE,
	'Tra_ID'	TEXT,
	'Date'	DATE,
	'Transport_Mode'	TEXT,
	'Transport_Distance'	TEXT,
	'Transportation_Name'	TEXT,
	'Transport_ID'	TEXT,
	'Vihical_No'	TEXT,
	'Vihical_Type'	TEXT,
	'LR_No'	TEXT,
	'Driver_Name'	TEXT,
	'Driver_Phone'	TEXT,
	'Driver_License'	TEXT,
	'eWay_Bill_No'	TEXT,
	'ewayBill_Type'	TEXT,
	'ewayBill_Document_Type'	TEXT,
	'From_Address1'	TEXT,
	'From_Address2'	TEXT,
	'From_Please'	TEXT,
	'From_Pincode'	TEXT,
	'To_Name'	TEXT,
	'To_GST_Type'	TEXT,
	'To_GST'	TEXT,
	'To_Address1'	TEXT,
	'To_Address2'	TEXT,
	'To_Please'	TEXT,
	'To_Pincode'	TEXT,
	'To_State'	TEXT,
	'Ship_ID'	TEXT,
	'Ship_Name'	TEXT,
	'Ship_Mailing_Name'	TEXT,
	'Ship_Address'	TEXT,
	'Ship_State'	TEXT,
	'Ship_Pincode'	TEXT,
	'Ship_GST_Type'	TEXT,
	'Ship_GST'	TEXT,
	'Company'	TEXT,
	'User'	TEXT,
	'Date_Install'	DATETIME,
	'PC'	TEXT,
	'Dispatch_Doc_No'	TEXT,
	'Dispatch_Through'	TEXT,
	'Carrier_Name_Agent'	TEXT,
	'Dispatch_Date'	DATETIME,
	'Terms_of_payment'	TEXT,
	'Payment_reference'	TEXT,
	'terms_of_delivery'	TEXT,
	'YN_Transport'	TEXT,
	'YN_Ewaybill'	TEXT,
	'To_Country'	TEXT,
	'Ship_Country'	TEXT,
	'Place_of_Receipt_by_Shipper'	TEXT,
	'Port_of_Loading'	TEXT,
	'Port_of_Discharge'	TEXT,
	'Shipping_Bill_No'	TEXT,
	'Export_Date'	Date,
	'Port_Code'	TEXT,
	'Export_LUT'	TEXT,
	'Vebrij_Gross'	TEXT,
	'Vebrij_Vehical'	TEXT,
	'Vebrij_Net'	TEXT,
	PRIMARY KEY('Id' AUTOINCREMENT)
);

CREATE TABLE 'TBL_VC_item_Details' (
	'ID'	INTEGER NOT NULL UNIQUE,
	'Tra_ID'	INTEGER,
	'Date'	Date,
	'Item'	INTEGER,
	'HSN_Code'	TEXT,
	'Qty'	TEXT,
	'Rate'	TEXT,
	'Discount_P'	TEXT,
	'Discount_A'	TEXT,
	'GST_per'	TEXT,
	'GST_Type'	TEXT,
	'CGST'	TEXT,
	'SGST'	TEXT,
	'IGST'	TEXT,
	'Cess_Per'	TEXT,
	'Cess_Amt'	TEXT,
	'Cess_ID'	TEXT,
	'Amount'	TEXT,
	'VC_ID'	INTEGER,
	'Type'	TEXT,
	'Description'	TEXT,
	'CGST_ID'	TEXT,
	'SGST_ID'	TEXT,
	'IGST_ID'	TEXT,
	'Ledger_ID'	TEXT,
	'Unit_Type'	TEXT,
	'Unit1'	INTEGER,
	'Unit2'	INTEGER,
	'Unit'	INTEGER,
	'Qty1'	TEXT,
	'Qty2'	TEXT,
	'Rate1'	TEXT,
	'Rate2'	TEXT,
	'Amount1'	TEXT,
	'Amount2'	TEXT,
	'Batch_No'	TEXT,
	'Mfg_Date'	Date,
	'Exp_Date'	Date,
	PRIMARY KEY('ID' AUTOINCREMENT)
);

CREATE TABLE 'TBL_Communication' (
	'ID'	INTEGER NOT NULL UNIQUE,
	'Vc_ID'	INTEGER,
	'Ledger'	INTEGER,
	'Whatsapp'	TEXT,
	'Email'	TEXT,
	PRIMARY KEY('ID' AUTOINCREMENT)
);
CREATE TABLE 'TBL_Voucher_Create' (
	'Id'	INTEGER NOT NULL UNIQUE,
	'Name'	TEXT,
	'Alias'	TEXT,
	'Under'	TEXT,
	'Voucher_No_Method'	TEXT,
	'Voucher_No_Prefix'	TEXT,
	'Voucher_No_Suffix'	TEXT,
	'Narration_Method'	TEXT,
	'Narration_Type'	TEXT,
	'YN_Group_Cell'	TEXT,
	'YN_Godown_Cell'	TEXT,
	'YN_Narration_Cell'	TEXT,
	'YN_Link_Voucher'	TEXT,
	'YN_GST'	TEXT,
	'YN_AddiAdditional'	TEXT,
	'YN_Batch'	TEXT,
	'YN_Category'	TEXT,
	'YN_Transport'	TEXT,
	'Communication_YN'	TEXT,
	'Company'	TEXT,
	'Visible'	TEXT,
	'Zerol_Value'	TEXT,
	'Print_after_seve'	TEXT,
	'Print_Head'	TEXT,
	'Print_Narration'	TEXT,
	'Print_Signature'	TEXT,
	'Print_Stamp'	TEXT,
	'Print_UPI_QR'	TEXT,
	'Print_UPI_QR_Value'	TEXT,
	'Print_Provisional'	TEXT,
	'YN_Narration'	TEXT,
	'Print_Path'	TEXT,
	'Print_format'	TEXT,
	'Duplicate_No'	TEXT,
	'Print_Terms_Conditions'	TEXT,
	'YN_EwayBill'	TEXT,
	'Print_Type'	TEXT,
	'Print_Item_MRP'	TEXT,
	'Order_YN'	TEXT,
	'Barcode_YN'	TEXT,
	'Payment_Details_YN'	TEXT,
	'Rate_Valuation'	TEXT,
	'Stock_Journal_Production_YN'	TEXT,
	'Round_Vlu'	TEXT,
	'YN_Account_Details_Alter'	TEXT,
	'YN_Credit_Limit_Warning'	TEXT,
	'YN_Stock_Warning'	TEXT,
	'YN_item_description'	TEXT,
	'Filter_Sundry_Creditors'	TEXT,
	'Filter_Sundry_Debitors'	TEXT,
	'Filter_Branch_Divisions'	TEXT,
	'Voucher_Start'	TEXT,
	'YN_item_Discount'	TEXT,
	PRIMARY KEY('Id' AUTOINCREMENT)
);

CREATE TABLE 'TBL_VC_Item_Other_Details' (
	'ID'	INTEGER NOT NULL UNIQUE,
	'TBL_VI'	INTEGER,
	'Batch'	TEXT,
	'Mfg'	TEXT,
	'Exp'	TEXT,
	'Qty'	TEXT,
	'Rate'	TEXT,
	'Amount'	TEXT,
	'Type'	TEXT,
	'Godown'	TEXT,
	'Item'	TEXT,
	'Tra_ID'	TEXT,
	PRIMARY KEY('ID' AUTOINCREMENT)
);

CREATE TABLE 'TBL_VC_Payroll' (
	'ID'	INTEGER NOT NULL UNIQUE,
	'Date'	INTEGER,
	'Tra_ID'	TEXT,
	'Employee'	TEXT,
	'Payhead'	TEXT,
	'Dr'	INTEGER,
	'Cr'	INTEGER,
	PRIMARY KEY('ID' AUTOINCREMENT)
);

CREATE TABLE 'TBL_Payroll_VC' (
	'ID'	INTEGER NOT NULL UNIQUE,
	'Tra_ID'	TEXT,
	'Type'	TEXT,
	'Acc_ID'	TEXT,
	'Dr'	TEXT,
	'Cr'	TEXT,
	PRIMARY KEY('ID' AUTOINCREMENT)
);

CREATE TABLE 'TBL_WhatsApp_Temp' (
	'ID'	INTEGER NOT NULL UNIQUE,
	'Name'	TEXT,
	'WhatsApp_Number'	TEXT,
	'Account_Group'	TEXT,
	'Ledger_Permission'	TEXT,
	'Ledger_Filter'	TEXT,
	'Message'	TEXT,
	PRIMARY KEY('ID' AUTOINCREMENT)
);

CREATE TABLE 'TBL_WhatsApp_Temp_column' (
	'ID'	INTEGER NOT NULL UNIQUE,
	'Temp_ID'	INTEGER,
	'Column_Name'	TEXT,
	PRIMARY KEY('ID' AUTOINCREMENT)
);

CREATE TABLE 'TBL_Vouchers_Class' (
	'ID'	INTEGER NOT NULL UNIQUE,
	'VC_ID'	INTEGER,
	'Name'	TEXT,
	PRIMARY KEY('ID' AUTOINCREMENT)
);

CREATE TABLE 'TBL_Vouchers_Class_Head_Filter' (
	'ID'	INTEGER NOT NULL UNIQUE,
	'VC_ID'	INTEGER,
	'Class_ID'	INTEGER,
	'Group_ID'	INTEGER,
	'Status'	TEXT,
	PRIMARY KEY('ID' AUTOINCREMENT)
);

CREATE TABLE 'TBL_Vouchers_Class_Additional_Entries' (
	'ID'	INTEGER NOT NULL UNIQUE,
	'Class_ID'	INTEGER,
	'VC_ID'	INTEGER,
	'Ledger_ID'	INTEGER,
	'Type_of_Calculation'	TEXT,
	'Default_Value'	TEXT,
	'Rounding_Method'	TEXT,
	'Rounding_Limit'	TEXT,
	PRIMARY KEY('ID' AUTOINCREMENT)
);

CREATE TABLE 'TBL_Info' ('ID' INTEGER NOT NULL UNIQUE,	'Head'	TEXT,	'Value'	TEXT,	PRIMARY KEY('ID' AUTOINCREMENT));
INSERT INTO TBL_Info (Head,Value) VALUES ('Verification','0');

" & Spacial_Custome_Colunm() & vbNewLine & cre_defolt_data()
	End Function
	Private Function Spacial_Custome_Colunm() As String
		If Class_ = "Laboratory" Then
			Return Laboratry_Custome_Data()
		End If
	End Function
	Private Function Laboratry_Custome_Data()
		Return "ALTER TABLE [TBL_Stock_Item] ADD [Defolt_Value] TEXT;
ALTER TABLE [TBL_Stock_Item] ADD [Male_H] TEXT;
ALTER TABLE [TBL_Stock_Item] ADD [Male_L] TEXT;
ALTER TABLE [TBL_Stock_Item] ADD [Female_H] TEXT;
ALTER TABLE [TBL_Stock_Item] ADD [Female_L] TEXT;
ALTER TABLE [TBL_Stock_Item] ADD [Child_M_H] TEXT;
ALTER TABLE [TBL_Stock_Item] ADD [Child_M_L] TEXT;
ALTER TABLE [TBL_Stock_Item] ADD [Child_F_H] TEXT;
ALTER TABLE [TBL_Stock_Item] ADD [Child_F_L] TEXT;

CREATE TABLE 'TBL_Laboratry_Group' (
	'ID'	INTEGER NOT NULL UNIQUE,
	'Name'	TEXT,
	'Alias'	TEXT,
	'Rate'	TEXT,
	'Visible'	TEXT,
	PRIMARY KEY('ID' AUTOINCREMENT)
);

CREATE TABLE 'TBL_Laboratry_Group_list' (
	'ID'	INTEGER NOT NULL UNIQUE,
	'Group_ID'	INTEGER,
	'Test_ID'	INTEGER,
	'Formula'	TEXT,
	PRIMARY KEY('ID' AUTOINCREMENT)
);
"
	End Function
	Public Function lnk_qry() As String
		Return "CREATE TABLE 'cfg_E_Mandi_Vepari_Report' (
	'Id'	INTEGER NOT NULL UNIQUE,
	'Head'	TEXT,
	'Value'	TEXT,
	PRIMARY KEY('Id' AUTOINCREMENT)
);

CREATE TABLE 'cfg_Emandi_Unit_Report' (
	'Id'	INTEGER NOT NULL UNIQUE,
	'Head'	TEXT,
	'Value'	TEXT,
	PRIMARY KEY('Id' AUTOINCREMENT)
);

CREATE TABLE 'cfg_Ledger' (
	'Id'	INTEGER NOT NULL UNIQUE,
	'Head'	TEXT,
	'Value'	TEXT,
	PRIMARY KEY('Id' AUTOINCREMENT)
);

CREATE TABLE 'cfg_Marketing_Auction_VC' (
	'Id'	INTEGER NOT NULL UNIQUE,
	'Head'	TEXT,
	'Value'	TEXT,
	PRIMARY KEY('Id' AUTOINCREMENT)
);

CREATE TABLE 'cfg_VC' (
	'Id'	INTEGER NOT NULL UNIQUE,
	'Head'	TEXT,
	'Value'	TEXT,
	PRIMARY KEY('Id' AUTOINCREMENT)
);

CREATE TABLE 'cfg_Vouchers' (
	'Id'	INTEGER NOT NULL UNIQUE,
	'Head'	TEXT,
	'Type'	TEXT,
	'Name'	TEXT,
	'Value'	TEXT,
	'Filter'	TEXT,
	'Data'	TEXT,
	'User'	TEXT,
	PRIMARY KEY('Id' AUTOINCREMENT)
);

CREATE TABLE 'TBL_Info' ('ID' INTEGER NOT NULL UNIQUE,	'Head'	TEXT,	'Value'	TEXT,	PRIMARY KEY('ID' AUTOINCREMENT));
INSERT INTO TBL_Info (Head,Value) VALUES ('Verification','0');

" & lnk_defolt_data()
	End Function
	Public Function rec_qry() As String
		Return "CREATE TABLE [TBL_Attage] (
    [Id]	INTEGER NOT NULL UNIQUE,
    [Name]         TEXT  NULL,
    [Narration]    TEXT  NULL,
    [TBL]          TEXT  NULL,
    [TBL_ID]       TEXT  NULL,
    [Attage]       BLOB COLLATE BINARY,
    [Attage_Type]  TEXT  NULL,
    [Password]     TEXT  NULL,
    [User]         TEXT  NULL,
    [Date_install] DATETIME        NULL,
    [PC]           TEXT  NULL,
    [Visible]      TEXT  NULL,
    PRIMARY KEY([Id] AUTOINCREMENT)
);

CREATE TABLE 'TBL_Info' ('ID' INTEGER NOT NULL UNIQUE,	'Head'	TEXT,	'Value'	TEXT,	PRIMARY KEY('ID' AUTOINCREMENT));
INSERT INTO TBL_Info (Head,Value) VALUES ('Verification','0');

"
	End Function
	Public Function aud_qry() As String
		Dim str As String = cre_qry()


		Return str
	End Function
	Public Function Create_cmp(Path_TXT As String)
		Dim File_Name As String = "cmp.db"
		Dim Location As String = System.IO.Path.Combine(Path_TXT, File_Name)
		Dim create_qury As String = String.Format("Data Source = {0}", Location)
		'Create Tabales
		Dim tbl_ As String = cmp_qry()

		Dim cn As New SQLiteConnection(create_qury)
		cn.Open()
		cn.ChangePassword("Opens@Db2558")
		Dim cmd As New SQLiteCommand(tbl_, cn)
		cmd.ExecuteNonQuery()
		TBL_Features_Fill(cn)
		cn.Close()

		'cn.Open()
		'cn.Close()

	End Function
	Public Function TBL_Features_Fill(cn As SQLiteConnection)
		TBL_Features_Find(cn, "Loans for how old employees", "30", "", "Payroll")
		TBL_Features_Find(cn, "Loan limit from net salary", "2000.00", "", "Payroll")
		TBL_Features_Find(cn, "Limit of days without installments", "90.00", "", "Payroll")
		TBL_Features_Find(cn, "Installment limit for loan", "2.00", "", "Payroll")
		TBL_Features_Find(cn, "Organisation Share Price", "10", "", "Payroll")
		TBL_Features_Find(cn, "Loan holder investment in shares", "10", "", "Payroll")
		TBL_Features_Find(cn, "Using Shareholder Method", "Yes", "", "Payroll")

		TBL_Features_Find(cn, "Using Loan Method", "No", "", "Payroll")
		TBL_Features_Find(cn, "Payroll_YN", "No", "", "Payroll")
		TBL_Features_Find(cn, "Branch_YN", "No", "", "General")
		TBL_Features_Find(cn, "Whatsapp", "No", "", "General")
		TBL_Features_Find(cn, "Positive Value", "Cr", "", "General")
		TBL_Features_Find(cn, "Negative Value", "Dr", "", "General")
		TBL_Features_Find(cn, "Date Format", "dd-MM-yyyy", "", "General")
	End Function
	Private Function TBL_Features_Find(cn As SQLiteConnection, Head As String, Vlu As String, Discription As String, Type As String)
		If Chack_Duplicate(Database_File.cmp, "TBL_Features", "Head", "Head = '" & Head & "'") = False Then

			cmd = New SQLiteCommand("INSERT INTO TBL_Features (Head, Value, Discription, Type) VALUES ('" & Head & "', '" & Vlu & "', '" & Discription & "', '" & Type & "')", cn)
			cmd.ExecuteNonQuery()
		End If
	End Function
	Public Function Create_cre(Path_TXT As String)
		Dim File_Name As String = "cre.db"
		Dim Location As String = System.IO.Path.Combine(Path_TXT, File_Name)
		Dim create_qury As String = String.Format("Data Source = {0}", Location)
		'Create Tabales
		Dim tbl_ As String = cre_qry()

		Dim cn As New SQLiteConnection(create_qury)
		cn.Open()
		cn.ChangePassword("Opens@Db2558")
		Dim cmd As New SQLiteCommand(tbl_, cn)
		cmd.ExecuteNonQuery()
		cn.Close()

	End Function
	Dim Cmp_Class As String
	Private Function cre_defolt_data() As String
		Dim st As String

		st &= "INSERT INTO [TBL_Acc_Group] ([Name], [Nickname], [UserGroup], [HeadGroup], [Company], [User], [Date_install], [PC], [Visible], [Head]) VALUES ('Capital Account', NULL, 0, NULL, 'All', 0, NULL, NULL, 'Approval', 'Liabilities');
INSERT INTO [TBL_Acc_Group] ([Name], [Nickname], [UserGroup], [HeadGroup], [Company], [User], [Date_install], [PC], [Visible], [Head]) VALUES ('Loans (Liability)', NULL, 0, NULL, 'All', 0, NULL, NULL, 'Approval', 'Liabilities');
INSERT INTO [TBL_Acc_Group] ([Name], [Nickname], [UserGroup], [HeadGroup], [Company], [User], [Date_install], [PC], [Visible], [Head]) VALUES ('Current Liabilities', NULL, 0, NULL, 'All', 0, NULL, NULL, 'Approval', 'Liabilities');
INSERT INTO [TBL_Acc_Group] ([Name], [Nickname], [UserGroup], [HeadGroup], [Company], [User], [Date_install], [PC], [Visible], [Head]) VALUES ('Fixed Assets', NULL, 0, NULL, 'All', 0, NULL, NULL, 'Approval', 'Assets');
INSERT INTO [TBL_Acc_Group] ([Name], [Nickname], [UserGroup], [HeadGroup], [Company], [User], [Date_install], [PC], [Visible], [Head]) VALUES ('Investments', NULL, 0, NULL, 'All', 0, NULL, NULL, 'Approval', 'Assets');
INSERT INTO [TBL_Acc_Group] ([Name], [Nickname], [UserGroup], [HeadGroup], [Company], [User], [Date_install], [PC], [Visible], [Head]) VALUES ('Current Assets', NULL, 0, NULL, 'All', 0, NULL, NULL, 'Approval', 'Assets');
INSERT INTO [TBL_Acc_Group] ([Name], [Nickname], [UserGroup], [HeadGroup], [Company], [User], [Date_install], [PC], [Visible], [Head]) VALUES ('Branch / Divisions', NULL, 0, NULL, 'All', 0, NULL, NULL, 'Approval', 'Liabilities');
INSERT INTO [TBL_Acc_Group] ([Name], [Nickname], [UserGroup], [HeadGroup], [Company], [User], [Date_install], [PC], [Visible], [Head]) VALUES ('Misc. Expenses (ASSET)', NULL, 0, NULL, 'All', 0, NULL, NULL, 'Approval', 'Assets');
INSERT INTO [TBL_Acc_Group] ([Name], [Nickname], [UserGroup], [HeadGroup], [Company], [User], [Date_install], [PC], [Visible], [Head]) VALUES ('Suspense A/c', NULL, 0, NULL, 'All', 0, NULL, NULL, 'Approval', 'Liabilities');
INSERT INTO [TBL_Acc_Group] ([Name], [Nickname], [UserGroup], [HeadGroup], [Company], [User], [Date_install], [PC], [Visible], [Head]) VALUES ( 'Sales Accounts', NULL, 0, NULL, 'All', 0, NULL, NULL, 'Approval', 'Income');
INSERT INTO [TBL_Acc_Group] ([Name], [Nickname], [UserGroup], [HeadGroup], [Company], [User], [Date_install], [PC], [Visible], [Head]) VALUES ( 'Purchase Accounts', NULL, 0, NULL, 'All', 0, NULL, NULL, 'Approval', 'Expenses');
INSERT INTO [TBL_Acc_Group] ([Name], [Nickname], [UserGroup], [HeadGroup], [Company], [User], [Date_install], [PC], [Visible], [Head]) VALUES ( 'Direct Incomes', NULL, 0, NULL, 'All', 0, NULL, NULL, 'Approval', 'Income');
INSERT INTO [TBL_Acc_Group] ([Name], [Nickname], [UserGroup], [HeadGroup], [Company], [User], [Date_install], [PC], [Visible], [Head]) VALUES ( 'Direct Expenses', NULL, 0, NULL, 'All', 0, NULL, NULL, 'Approval', 'Expenses');
INSERT INTO [TBL_Acc_Group] ([Name], [Nickname], [UserGroup], [HeadGroup], [Company], [User], [Date_install], [PC], [Visible], [Head]) VALUES ( 'Indirect Incomes', NULL, 0, NULL, 'All', 0, NULL, NULL, 'Approval', 'Income');
INSERT INTO [TBL_Acc_Group] ([Name], [Nickname], [UserGroup], [HeadGroup], [Company], [User], [Date_install], [PC], [Visible], [Head]) VALUES ( 'Indirect Expenses', NULL, 0, NULL, 'All', 0, NULL, NULL, 'Approval', 'Expenses');
INSERT INTO [TBL_Acc_Group] ([Name], [Nickname], [UserGroup], [HeadGroup], [Company], [User], [Date_install], [PC], [Visible], [Head]) VALUES ( 'Reserves & Surplus', NULL, 1, NULL, 'All', 0, NULL, NULL, 'Approval', NULL);
INSERT INTO [TBL_Acc_Group] ([Name], [Nickname], [UserGroup], [HeadGroup], [Company], [User], [Date_install], [PC], [Visible], [Head]) VALUES ( 'Bank OD A/c', NULL, 2, NULL, 'All', 0, NULL, NULL, 'Approval', NULL);
INSERT INTO [TBL_Acc_Group] ([Name], [Nickname], [UserGroup], [HeadGroup], [Company], [User], [Date_install], [PC], [Visible], [Head]) VALUES ( 'Secured Loans', NULL, 2, NULL, 'All', 0, NULL, NULL, 'Approval', NULL);
INSERT INTO [TBL_Acc_Group] ([Name], [Nickname], [UserGroup], [HeadGroup], [Company], [User], [Date_install], [PC], [Visible], [Head]) VALUES ( 'Unsecured Loans', NULL, 2, NULL, 'All', 0, NULL, NULL, 'Approval', NULL);
INSERT INTO [TBL_Acc_Group] ([Name], [Nickname], [UserGroup], [HeadGroup], [Company], [User], [Date_install], [PC], [Visible], [Head]) VALUES ( 'Duties & Taxes', NULL, 3, NULL, 'All', 0, NULL, NULL, 'Approval', NULL);
INSERT INTO [TBL_Acc_Group] ([Name], [Nickname], [UserGroup], [HeadGroup], [Company], [User], [Date_install], [PC], [Visible], [Head]) VALUES ( 'Provisions', NULL, 3, NULL, 'All', 0, NULL, NULL, 'Approval', NULL);
INSERT INTO [TBL_Acc_Group] ([Name], [Nickname], [UserGroup], [HeadGroup], [Company], [User], [Date_install], [PC], [Visible], [Head]) VALUES ( 'Sundry Creditors', NULL, 3, NULL, 'All', 0, NULL, NULL, 'Approval', NULL);
INSERT INTO [TBL_Acc_Group] ([Name], [Nickname], [UserGroup], [HeadGroup], [Company], [User], [Date_install], [PC], [Visible], [Head]) VALUES ( 'Stock-in-Hand', NULL, 6, NULL, 'All', 0, NULL, NULL, 'Approval', NULL);
INSERT INTO [TBL_Acc_Group] ([Name], [Nickname], [UserGroup], [HeadGroup], [Company], [User], [Date_install], [PC], [Visible], [Head]) VALUES ( 'Deposits (Asset)', NULL, 6, NULL, 'All', 0, NULL, NULL, 'Approval', NULL);
INSERT INTO [TBL_Acc_Group] ([Name], [Nickname], [UserGroup], [HeadGroup], [Company], [User], [Date_install], [PC], [Visible], [Head]) VALUES ( 'Loans & Advances (Asset)', NULL, 6, NULL, 'All', 0, NULL, NULL, 'Approval', NULL);
INSERT INTO [TBL_Acc_Group] ([Name], [Nickname], [UserGroup], [HeadGroup], [Company], [User], [Date_install], [PC], [Visible], [Head]) VALUES ( 'Sundry Debtors', NULL, 6, NULL, 'All', 0, NULL, NULL, 'Approval', NULL);
INSERT INTO [TBL_Acc_Group] ([Name], [Nickname], [UserGroup], [HeadGroup], [Company], [User], [Date_install], [PC], [Visible], [Head]) VALUES ( 'Cash-in-Hand', NULL, 6, NULL, 'All', 0, NULL, NULL, 'Approval', NULL);
INSERT INTO [TBL_Acc_Group] ([Name], [Nickname], [UserGroup], [HeadGroup], [Company], [User], [Date_install], [PC], [Visible], [Head]) VALUES ( 'Bank Accounts', NULL, 6, NULL, 'All', 0, NULL, NULL, 'Approval', NULL);

"

		st &= "INSERT INTO [TBL_Stock_Godown] ([Name], [Nickname], [Under], [Company], [Visible], [User], [PC], [Date_install]) VALUES ('Main Location', '', '', 'All', 'Approval', '0', 'Admin', '2000-01-01 00:00:00');
"

		st &= "INSERT INTO [TBL_TAX] ([Name], [NickName], [Under], [Percentage], [Discription], [Company], [Visible]) VALUES ('INPUT @ CGST / SGST  : 0.00%', NULL, 'INPUT', '0.00', NULL, 'All', 'Approval');
INSERT INTO [TBL_TAX] ([Name], [NickName], [Under], [Percentage], [Discription], [Company], [Visible]) VALUES ('INPUT @ CGST / SGST  : 0.25%', NULL, 'INPUT', '0.25', NULL, 'All', 'Approval');
INSERT INTO [TBL_TAX] ([Name], [NickName], [Under], [Percentage], [Discription], [Company], [Visible]) VALUES ('INPUT @ CGST / SGST  : 3%', NULL, 'INPUT', '3.00', NULL, 'All', 'Approval');
INSERT INTO [TBL_TAX] ([Name], [NickName], [Under], [Percentage], [Discription], [Company], [Visible]) VALUES ('INPUT @ CGST / SGST  : 5%', NULL, 'INPUT', '5.00', NULL, 'All', 'Approval');
INSERT INTO [TBL_TAX] ([Name], [NickName], [Under], [Percentage], [Discription], [Company], [Visible]) VALUES ('INPUT @ CGST / SGST  : 12%', NULL, 'INPUT', '12.00', NULL, 'All', 'Approval');
INSERT INTO [TBL_TAX] ([Name], [NickName], [Under], [Percentage], [Discription], [Company], [Visible]) VALUES ('INPUT @ CGST / SGST  : 18%', NULL, 'INPUT', '18.00', NULL, 'All', 'Approval');
INSERT INTO [TBL_TAX] ([Name], [NickName], [Under], [Percentage], [Discription], [Company], [Visible]) VALUES ('INPUT @ CGST / SGST  : 28%', NULL, 'INPUT', '28.00', NULL, 'All', 'Approval');
INSERT INTO [TBL_TAX] ([Name], [NickName], [Under], [Percentage], [Discription], [Company], [Visible]) VALUES ('OUTPUT @ CGST / SGST  : 0.00%', NULL, 'OUTPUT', '0.00', NULL, 'All', 'Approval');
INSERT INTO [TBL_TAX] ([Name], [NickName], [Under], [Percentage], [Discription], [Company], [Visible]) VALUES ('OUTPUT @ CGST / SGST  : 0.25%', NULL, 'OUTPUT', '0.25', NULL, 'All', 'Approval');
INSERT INTO [TBL_TAX] ([Name], [NickName], [Under], [Percentage], [Discription], [Company], [Visible]) VALUES ('OUTPUT @ CGST / SGST  : 3%', NULL, 'OUTPUT', '3.00', NULL, 'All', 'Approval');
INSERT INTO [TBL_TAX] ([Name], [NickName], [Under], [Percentage], [Discription], [Company], [Visible]) VALUES ('OUTPUT @ CGST / SGST  : 5%', NULL, 'OUTPUT', '5.00', NULL, 'All', 'Approval');
INSERT INTO [TBL_TAX] ([Name], [NickName], [Under], [Percentage], [Discription], [Company], [Visible]) VALUES ('OUTPUT @ CGST / SGST  : 12%', NULL, 'OUTPUT', '12.00', NULL, 'All', 'Approval');
INSERT INTO [TBL_TAX] ([Name], [NickName], [Under], [Percentage], [Discription], [Company], [Visible]) VALUES ('OUTPUT @ CGST / SGST  : 18%', NULL, 'OUTPUT', '18.00', NULL, 'All', 'Approval');
INSERT INTO [TBL_TAX] ([Name], [NickName], [Under], [Percentage], [Discription], [Company], [Visible]) VALUES ('OUTPUT @ CGST / SGST  : 28%', NULL, 'OUTPUT', '28.00', NULL, 'All', 'Approval');
INSERT INTO [TBL_TAX] ([Name], [NickName], [Under], [Percentage], [Discription], [Company], [Visible]) VALUES ('PURCHASE & SALES @  : 0.00%', 'PURCHASE & SALES @  : 0.00%', 'PURCHASE', '0.00', NULL, 'All', 'Approval');
INSERT INTO [TBL_TAX] ([Name], [NickName], [Under], [Percentage], [Discription], [Company], [Visible]) VALUES ('PURCHASE & SALES @  : 0.25%', 'PURCHASE & SALES @  : 0.25%', 'PURCHASE', '0.25', NULL, 'All', 'Approval');
INSERT INTO [TBL_TAX] ([Name], [NickName], [Under], [Percentage], [Discription], [Company], [Visible]) VALUES ('PURCHASE & SALES @  : 3%', 'PURCHASE & SALES @  : 3%', 'PURCHASE', '3.00', NULL, 'All', 'Approval');
INSERT INTO [TBL_TAX] ([Name], [NickName], [Under], [Percentage], [Discription], [Company], [Visible]) VALUES ('PURCHASE & SALES @  : 5%', 'PURCHASE & SALES @  : 5%', 'PURCHASE', '5.00', NULL, 'All', 'Approval');
INSERT INTO [TBL_TAX] ([Name], [NickName], [Under], [Percentage], [Discription], [Company], [Visible]) VALUES ('PURCHASE & SALES @  : 12%', 'PURCHASE & SALES @  : 12%', 'PURCHASE', '12.00', NULL, 'All', 'Approval');
INSERT INTO [TBL_TAX] ([Name], [NickName], [Under], [Percentage], [Discription], [Company], [Visible]) VALUES ('PURCHASE & SALES @  : 18%', 'PURCHASE & SALES @  : 18%', 'PURCHASE', '18.00', NULL, 'All', 'Approval');
INSERT INTO [TBL_TAX] ([Name], [NickName], [Under], [Percentage], [Discription], [Company], [Visible]) VALUES ('PURCHASE & SALES @  : 28%', 'PURCHASE & SALES @  : 28%', 'PURCHASE', '28.00', NULL, 'All', 'Approval');
INSERT INTO [TBL_TAX] ([Name], [NickName], [Under], [Percentage], [Discription], [Company], [Visible]) VALUES ('PURCHASE & SALES @  : 0.00%', 'PURCHASE & SALES @  : 0.00%', 'SALES', '0.00', NULL, 'All', 'Approval');
INSERT INTO [TBL_TAX] ([Name], [NickName], [Under], [Percentage], [Discription], [Company], [Visible]) VALUES ('PURCHASE & SALES @  : 0.25%', 'PURCHASE & SALES @  : 0.25%', 'SALES', '0.25', NULL, 'All', 'Approval');
INSERT INTO [TBL_TAX] ([Name], [NickName], [Under], [Percentage], [Discription], [Company], [Visible]) VALUES ('PURCHASE & SALES @  : 3%', 'PURCHASE & SALES @  : 3%', 'SALES', '3.00', NULL, 'All', 'Approval');
INSERT INTO [TBL_TAX] ([Name], [NickName], [Under], [Percentage], [Discription], [Company], [Visible]) VALUES ('PURCHASE & SALES @  : 5%', 'PURCHASE & SALES @  : 5%', 'SALES', '5.00', NULL, 'All', 'Approval');
INSERT INTO [TBL_TAX] ([Name], [NickName], [Under], [Percentage], [Discription], [Company], [Visible]) VALUES ('PURCHASE & SALES @  : 12%', 'PURCHASE & SALES @  : 12%', 'SALES', '12.00', NULL, 'All', 'Approval');
INSERT INTO [TBL_TAX] ([Name], [NickName], [Under], [Percentage], [Discription], [Company], [Visible]) VALUES ('PURCHASE & SALES @  : 18%', 'PURCHASE & SALES @  : 18%', 'SALES', '18.00', NULL, 'All', 'Approval');
INSERT INTO [TBL_TAX] ([Name], [NickName], [Under], [Percentage], [Discription], [Company], [Visible]) VALUES ('PURCHASE & SALES @  : 28%', 'PURCHASE & SALES @  : 28%', 'SALES', '28.00', NULL, 'All', 'Approval');

"

		st &= "INSERT INTO [TBL_UQC] ([Shortcut], [Full_Name]) VALUES ('BAG-BAGS', '');
INSERT INTO [TBL_UQC] ([Shortcut], [Full_Name]) VALUES ('BAL-BALE', '');
INSERT INTO [TBL_UQC] ([Shortcut], [Full_Name]) VALUES ('BDL-BUNDLES', '');
INSERT INTO [TBL_UQC] ([Shortcut], [Full_Name]) VALUES ('BKL-BUCKLES', '');
INSERT INTO [TBL_UQC] ([Shortcut], [Full_Name]) VALUES ('BOU-BILLION OF UNITS', '');
INSERT INTO [TBL_UQC] ([Shortcut], [Full_Name]) VALUES ('BOX-BOX', '');
INSERT INTO [TBL_UQC] ([Shortcut], [Full_Name]) VALUES ('BTL-BOTTLES', '');
INSERT INTO [TBL_UQC] ([Shortcut], [Full_Name]) VALUES ('BU-BUNCHES', '');
INSERT INTO [TBL_UQC] ([Shortcut], [Full_Name]) VALUES ('CA-CANS', '');
INSERT INTO [TBL_UQC] ([Shortcut], [Full_Name]) VALUES ('CBM-CUBIC METERS', '');
INSERT INTO [TBL_UQC] ([Shortcut], [Full_Name]) VALUES ('CCM-CUBIC CENTIMETERS', '');
INSERT INTO [TBL_UQC] ([Shortcut], [Full_Name]) VALUES ('CMS-CENTIMETERS', '');
INSERT INTO [TBL_UQC] ([Shortcut], [Full_Name]) VALUES ('CT-CARTONS', '');
INSERT INTO [TBL_UQC] ([Shortcut], [Full_Name]) VALUES ('DOZ-DOZENS', '');
INSERT INTO [TBL_UQC] ([Shortcut], [Full_Name]) VALUES ('DRM-DRUMS', '');
INSERT INTO [TBL_UQC] ([Shortcut], [Full_Name]) VALUES ('GGK-GREAT GROSS', '');
INSERT INTO [TBL_UQC] ([Shortcut], [Full_Name]) VALUES ('GMS-GRAMMES', '');
INSERT INTO [TBL_UQC] ([Shortcut], [Full_Name]) VALUES ('GRS-GROSS', '');
INSERT INTO [TBL_UQC] ([Shortcut], [Full_Name]) VALUES ('GYD-GROSS YARDS', '');
INSERT INTO [TBL_UQC] ([Shortcut], [Full_Name]) VALUES ('KGS-KILOGRAMS', '');
INSERT INTO [TBL_UQC] ([Shortcut], [Full_Name]) VALUES ('KLR-KILOLITRE', '');
INSERT INTO [TBL_UQC] ([Shortcut], [Full_Name]) VALUES ('KME-KILOMETRE', '');
INSERT INTO [TBL_UQC] ([Shortcut], [Full_Name]) VALUES ('MLT-MILILITRE', '');
INSERT INTO [TBL_UQC] ([Shortcut], [Full_Name]) VALUES ('MTR-METERS', '');
INSERT INTO [TBL_UQC] ([Shortcut], [Full_Name]) VALUES ('MTS-METRIC TO', '');
INSERT INTO [TBL_UQC] ([Shortcut], [Full_Name]) VALUES ('NOS-NUMBERS', '');
INSERT INTO [TBL_UQC] ([Shortcut], [Full_Name]) VALUES ('OTH-OTHERS', '');
INSERT INTO [TBL_UQC] ([Shortcut], [Full_Name]) VALUES ('PAC-PACKS', '');
INSERT INTO [TBL_UQC] ([Shortcut], [Full_Name]) VALUES ('PCS-PIECES', '');
INSERT INTO [TBL_UQC] ([Shortcut], [Full_Name]) VALUES ('PRS-PAIRS', '');
INSERT INTO [TBL_UQC] ([Shortcut], [Full_Name]) VALUES ('QTL-QUINTAL', '');
INSERT INTO [TBL_UQC] ([Shortcut], [Full_Name]) VALUES ('ROL-ROLLS', '');
INSERT INTO [TBL_UQC] ([Shortcut], [Full_Name]) VALUES ('SET-SETS', '');
INSERT INTO [TBL_UQC] ([Shortcut], [Full_Name]) VALUES ('SQF-SQUARE FEET', '');
INSERT INTO [TBL_UQC] ([Shortcut], [Full_Name]) VALUES ('SQM-SQUARE METERS', '');
INSERT INTO [TBL_UQC] ([Shortcut], [Full_Name]) VALUES ('SQY-SQUARE YARDS', '');
INSERT INTO [TBL_UQC] ([Shortcut], [Full_Name]) VALUES ('TBS-TABLETS', '');
INSERT INTO [TBL_UQC] ([Shortcut], [Full_Name]) VALUES ('TGM-TEN GROSS', '');
INSERT INTO [TBL_UQC] ([Shortcut], [Full_Name]) VALUES ('THD-THOUSANDS', '');
INSERT INTO [TBL_UQC] ([Shortcut], [Full_Name]) VALUES ('TO-TONNES', '');
INSERT INTO [TBL_UQC] ([Shortcut], [Full_Name]) VALUES ('TUB-TUBES', '');
INSERT INTO [TBL_UQC] ([Shortcut], [Full_Name]) VALUES ('UGS-US GALLONS', '');
INSERT INTO [TBL_UQC] ([Shortcut], [Full_Name]) VALUES ('UNT-UNITS', '');
INSERT INTO [TBL_UQC] ([Shortcut], [Full_Name]) VALUES ('YDS-YARDS', '');
"

		st &= "INSERT INTO TBL_Voucher_Create ([Name], [Alias], [Under], [Voucher_No_Method], [Voucher_No_Prefix], [Voucher_No_Suffix], [Narration_Method], [Narration_Type], [YN_Group_Cell], [YN_Godown_Cell], [YN_Narration_Cell], [YN_Link_Voucher], [YN_GST], [YN_AddiAdditional], [YN_Batch], [YN_Category], [YN_Transport], [Company], [Visible], [Zerol_Value], [Print_after_seve], [Print_Head], [Print_Narration], [Print_Signature], [Print_Stamp], [Print_UPI_QR], [Print_UPI_QR_Value], [Print_Provisional], [YN_Narration], [Print_Path], [Print_format], [Duplicate_No], [Print_Terms_Conditions], [YN_EwayBill], [Print_Type], [Print_Item_MRP], [Order_YN], [Barcode_YN], [Payment_Details_YN], [Rate_Valuation], [Stock_Journal_Production_YN]) VALUES ('Contra', NULL, 'Contra', 'Automatitic', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'All', 'Approval', 'No', 'No', NULL, 'No', 'No', 'No', 'No', NULL, 'Yes', 'Yes', NULL, NULL, 'No', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO TBL_Voucher_Create ([Name], [Alias], [Under], [Voucher_No_Method], [Voucher_No_Prefix], [Voucher_No_Suffix], [Narration_Method], [Narration_Type], [YN_Group_Cell], [YN_Godown_Cell], [YN_Narration_Cell], [YN_Link_Voucher], [YN_GST], [YN_AddiAdditional], [YN_Batch], [YN_Category], [YN_Transport], [Company], [Visible], [Zerol_Value], [Print_after_seve], [Print_Head], [Print_Narration], [Print_Signature], [Print_Stamp], [Print_UPI_QR], [Print_UPI_QR_Value], [Print_Provisional], [YN_Narration], [Print_Path], [Print_format], [Duplicate_No], [Print_Terms_Conditions], [YN_EwayBill], [Print_Type], [Print_Item_MRP], [Order_YN], [Barcode_YN], [Payment_Details_YN], [Rate_Valuation], [Stock_Journal_Production_YN]) VALUES ('Payment', NULL, 'Payment', 'Automatitic', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'All', 'Approval', 'No', 'No', NULL, 'No', 'No', 'No', 'No', NULL, 'Yes', 'Yes', NULL, NULL, 'No', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO TBL_Voucher_Create ([Name], [Alias], [Under], [Voucher_No_Method], [Voucher_No_Prefix], [Voucher_No_Suffix], [Narration_Method], [Narration_Type], [YN_Group_Cell], [YN_Godown_Cell], [YN_Narration_Cell], [YN_Link_Voucher], [YN_GST], [YN_AddiAdditional], [YN_Batch], [YN_Category], [YN_Transport], [Company], [Visible], [Zerol_Value], [Print_after_seve], [Print_Head], [Print_Narration], [Print_Signature], [Print_Stamp], [Print_UPI_QR], [Print_UPI_QR_Value], [Print_Provisional], [YN_Narration], [Print_Path], [Print_format], [Duplicate_No], [Print_Terms_Conditions], [YN_EwayBill], [Print_Type], [Print_Item_MRP], [Order_YN], [Barcode_YN], [Payment_Details_YN], [Rate_Valuation], [Stock_Journal_Production_YN]) VALUES ('Receipt', NULL, 'Receipt', 'Automatitic', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'All', 'Approval', 'No', 'No', NULL, 'No', 'No', 'No', 'No', NULL, 'Yes', 'Yes', NULL, NULL, 'No', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO TBL_Voucher_Create ([Name], [Alias], [Under], [Voucher_No_Method], [Voucher_No_Prefix], [Voucher_No_Suffix], [Narration_Method], [Narration_Type], [YN_Group_Cell], [YN_Godown_Cell], [YN_Narration_Cell], [YN_Link_Voucher], [YN_GST], [YN_AddiAdditional], [YN_Batch], [YN_Category], [YN_Transport], [Company], [Visible], [Zerol_Value], [Print_after_seve], [Print_Head], [Print_Narration], [Print_Signature], [Print_Stamp], [Print_UPI_QR], [Print_UPI_QR_Value], [Print_Provisional], [YN_Narration], [Print_Path], [Print_format], [Duplicate_No], [Print_Terms_Conditions], [YN_EwayBill], [Print_Type], [Print_Item_MRP], [Order_YN], [Barcode_YN], [Payment_Details_YN], [Rate_Valuation], [Stock_Journal_Production_YN]) VALUES ('Journal', NULL, 'Journal', 'Automatitic', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'All', 'Approval', 'No', 'No', NULL, 'No', 'No', 'No', 'No', NULL, 'Yes', 'Yes', NULL, NULL, 'No', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO TBL_Voucher_Create  ([Name], [Alias], [Under], [Voucher_No_Method], [Voucher_No_Prefix], [Voucher_No_Suffix], [Narration_Method], [Narration_Type], [YN_Group_Cell], [YN_Godown_Cell], [YN_Narration_Cell], [YN_Link_Voucher], [YN_GST], [YN_AddiAdditional], [YN_Batch], [YN_Category], [YN_Transport], [Company], [Visible], [Zerol_Value], [Print_after_seve], [Print_Head], [Print_Narration], [Print_Signature], [Print_Stamp], [Print_UPI_QR], [Print_UPI_QR_Value], [Print_Provisional], [YN_Narration], [Print_Path], [Print_format], [Duplicate_No], [Print_Terms_Conditions], [YN_EwayBill], [Print_Type], [Print_Item_MRP], [Order_YN], [Barcode_YN], [Payment_Details_YN], [Rate_Valuation], [Stock_Journal_Production_YN]) VALUES ('Sales - Retail', NULL, 'Sales', 'Automatitic', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'No', NULL, NULL, NULL, 'No', 'All', 'Approval', 'No', 'No', NULL, 'No', 'Yes', 'No', 'No', NULL, 'Yes', 'Yes', NULL, NULL, 'No', NULL, 'No', 'Original Receipt', 'Yes', 'No', 'No', 'No', 'Last Sales', NULL);
INSERT INTO TBL_Voucher_Create  ([Name], [Alias], [Under], [Voucher_No_Method], [Voucher_No_Prefix], [Voucher_No_Suffix], [Narration_Method], [Narration_Type], [YN_Group_Cell], [YN_Godown_Cell], [YN_Narration_Cell], [YN_Link_Voucher], [YN_GST], [YN_AddiAdditional], [YN_Batch], [YN_Category], [YN_Transport], [Company], [Visible], [Zerol_Value], [Print_after_seve], [Print_Head], [Print_Narration], [Print_Signature], [Print_Stamp], [Print_UPI_QR], [Print_UPI_QR_Value], [Print_Provisional], [YN_Narration], [Print_Path], [Print_format], [Duplicate_No], [Print_Terms_Conditions], [YN_EwayBill], [Print_Type], [Print_Item_MRP], [Order_YN], [Barcode_YN], [Payment_Details_YN], [Rate_Valuation], [Stock_Journal_Production_YN]) VALUES ('Sales - GST', NULL, 'Sales', 'Custom', 'GST/', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'Yes', NULL, NULL, NULL, 'Yes', 'All', 'Approval', 'No', 'No', 'TAX INVOICE', 'No', 'Yes', 'No', 'No', NULL, 'Yes', 'Yes', NULL, NULL, 'No', NULL, 'Yes', 'Original Receipt', 'Yes', 'Yes', 'No', 'Yes', 'Last Sales', NULL);
INSERT INTO TBL_Voucher_Create  ([Name], [Alias], [Under], [Voucher_No_Method], [Voucher_No_Prefix], [Voucher_No_Suffix], [Narration_Method], [Narration_Type], [YN_Group_Cell], [YN_Godown_Cell], [YN_Narration_Cell], [YN_Link_Voucher], [YN_GST], [YN_AddiAdditional], [YN_Batch], [YN_Category], [YN_Transport], [Company], [Visible], [Zerol_Value], [Print_after_seve], [Print_Head], [Print_Narration], [Print_Signature], [Print_Stamp], [Print_UPI_QR], [Print_UPI_QR_Value], [Print_Provisional], [YN_Narration], [Print_Path], [Print_format], [Duplicate_No], [Print_Terms_Conditions], [YN_EwayBill], [Print_Type], [Print_Item_MRP], [Order_YN], [Barcode_YN], [Payment_Details_YN], [Rate_Valuation], [Stock_Journal_Production_YN]) VALUES ('Purchase - Retail', NULL, 'Purchase', 'Automatitic', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'No', NULL, NULL, NULL, 'No', 'All', 'Approval', 'No', 'No', NULL, 'No', 'Yes', 'No', 'No', NULL, 'Yes', 'Yes', NULL, NULL, 'No', NULL, 'No', 'Original Receipt', 'No', 'No', 'No', 'No', 'Last Purchase', NULL);
INSERT INTO TBL_Voucher_Create  ([Name], [Alias], [Under], [Voucher_No_Method], [Voucher_No_Prefix], [Voucher_No_Suffix], [Narration_Method], [Narration_Type], [YN_Group_Cell], [YN_Godown_Cell], [YN_Narration_Cell], [YN_Link_Voucher], [YN_GST], [YN_AddiAdditional], [YN_Batch], [YN_Category], [YN_Transport], [Company], [Visible], [Zerol_Value], [Print_after_seve], [Print_Head], [Print_Narration], [Print_Signature], [Print_Stamp], [Print_UPI_QR], [Print_UPI_QR_Value], [Print_Provisional], [YN_Narration], [Print_Path], [Print_format], [Duplicate_No], [Print_Terms_Conditions], [YN_EwayBill], [Print_Type], [Print_Item_MRP], [Order_YN], [Barcode_YN], [Payment_Details_YN], [Rate_Valuation], [Stock_Journal_Production_YN]) VALUES ('Purchase - GST', NULL, 'Purchase', 'Automatitic', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'Yes', NULL, NULL, NULL, 'Yes', 'All', 'Approval', 'No', 'No', 'TAX INVOICE', 'No', 'Yes', 'No', 'No', NULL, 'Yes', 'Yes', NULL, NULL, 'No', NULL, 'Yes', 'Original Receipt', 'No', 'Yes', 'No', 'Yes', 'Last Purchase', NULL);
INSERT INTO TBL_Voucher_Create  ([Name], [Alias], [Under], [Voucher_No_Method], [Voucher_No_Prefix], [Voucher_No_Suffix], [Narration_Method], [Narration_Type], [YN_Group_Cell], [YN_Godown_Cell], [YN_Narration_Cell], [YN_Link_Voucher], [YN_GST], [YN_AddiAdditional], [YN_Batch], [YN_Category], [YN_Transport], [Company], [Visible], [Zerol_Value], [Print_after_seve], [Print_Head], [Print_Narration], [Print_Signature], [Print_Stamp], [Print_UPI_QR], [Print_UPI_QR_Value], [Print_Provisional], [YN_Narration], [Print_Path], [Print_format], [Duplicate_No], [Print_Terms_Conditions], [YN_EwayBill], [Print_Type], [Print_Item_MRP], [Order_YN], [Barcode_YN], [Payment_Details_YN], [Rate_Valuation], [Stock_Journal_Production_YN]) VALUES ('Inward Register', NULL, 'Inward Register', 'Automatitic', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'No', NULL, NULL, NULL, 'Yes', 'All', 'Approval', 'No', 'No', NULL, 'No', 'Yes', 'No', 'No', NULL, 'Yes', 'Yes', NULL, NULL, 'No', NULL, 'Yes', 'Original Receipt', 'No', 'Yes', 'No', 'Yes', 'Avg. Inward', NULL);
INSERT INTO TBL_Voucher_Create  ([Name], [Alias], [Under], [Voucher_No_Method], [Voucher_No_Prefix], [Voucher_No_Suffix], [Narration_Method], [Narration_Type], [YN_Group_Cell], [YN_Godown_Cell], [YN_Narration_Cell], [YN_Link_Voucher], [YN_GST], [YN_AddiAdditional], [YN_Batch], [YN_Category], [YN_Transport], [Company], [Visible], [Zerol_Value], [Print_after_seve], [Print_Head], [Print_Narration], [Print_Signature], [Print_Stamp], [Print_UPI_QR], [Print_UPI_QR_Value], [Print_Provisional], [YN_Narration], [Print_Path], [Print_format], [Duplicate_No], [Print_Terms_Conditions], [YN_EwayBill], [Print_Type], [Print_Item_MRP], [Order_YN], [Barcode_YN], [Payment_Details_YN], [Rate_Valuation], [Stock_Journal_Production_YN]) VALUES ('Outward Register', NULL, 'Outward Register', 'Automatitic', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'No', NULL, NULL, NULL, 'Yes', 'All', 'Approval', 'No', 'No', NULL, 'No', 'Yes', 'No', 'No', NULL, 'Yes', 'Yes', NULL, NULL, 'No', NULL, 'Yes', 'Original Receipt', 'No', 'Yes', 'No', 'Yes', 'Avg. Outward', NULL);
INSERT INTO TBL_Voucher_Create  ([Name], [Alias], [Under], [Voucher_No_Method], [Voucher_No_Prefix], [Voucher_No_Suffix], [Narration_Method], [Narration_Type], [YN_Group_Cell], [YN_Godown_Cell], [YN_Narration_Cell], [YN_Link_Voucher], [YN_GST], [YN_AddiAdditional], [YN_Batch], [YN_Category], [YN_Transport], [Company], [Visible], [Zerol_Value], [Print_after_seve], [Print_Head], [Print_Narration], [Print_Signature], [Print_Stamp], [Print_UPI_QR], [Print_UPI_QR_Value], [Print_Provisional], [YN_Narration], [Print_Path], [Print_format], [Duplicate_No], [Print_Terms_Conditions], [YN_EwayBill], [Print_Type], [Print_Item_MRP], [Order_YN], [Barcode_YN], [Payment_Details_YN], [Rate_Valuation], [Stock_Journal_Production_YN]) VALUES ('Material Transfer', NULL, 'Stock Journal', 'Automatitic', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'All', 'Approval', 'No', 'No', NULL, 'No', 'No', 'No', NULL, NULL, NULL, 'Yes', NULL, NULL, 'No', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'No');
INSERT INTO TBL_Voucher_Create  ([Name], [Alias], [Under], [Voucher_No_Method], [Voucher_No_Prefix], [Voucher_No_Suffix], [Narration_Method], [Narration_Type], [YN_Group_Cell], [YN_Godown_Cell], [YN_Narration_Cell], [YN_Link_Voucher], [YN_GST], [YN_AddiAdditional], [YN_Batch], [YN_Category], [YN_Transport], [Company], [Visible], [Zerol_Value], [Print_after_seve], [Print_Head], [Print_Narration], [Print_Signature], [Print_Stamp], [Print_UPI_QR], [Print_UPI_QR_Value], [Print_Provisional], [YN_Narration], [Print_Path], [Print_format], [Duplicate_No], [Print_Terms_Conditions], [YN_EwayBill], [Print_Type], [Print_Item_MRP], [Order_YN], [Barcode_YN], [Payment_Details_YN], [Rate_Valuation], [Stock_Journal_Production_YN]) VALUES ('Production', NULL, 'Stock Journal', 'Automatitic', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'All', 'Approval', 'No', 'No', NULL, 'No', 'No', 'No', NULL, NULL, NULL, 'Yes', NULL, NULL, 'No', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'Yes');
"

		Return st
	End Function
	Private Function lnk_defolt_data() As String
		Dim st As String
		st &= "INSERT INTO [cfg_E_Mandi_Vepari_Report] ([Head], [Value]) VALUES ('Whatsapp Message', 'Hello');
INSERT INTO [cfg_E_Mandi_Vepari_Report] ([Head], [Value]) VALUES ('Farmer Show', 'Yes');

INSERT INTO [cfg_Emandi_Unit_Report] ([Head], [Value]) VALUES ('Total Unit', 'Yes');
INSERT INTO [cfg_Emandi_Unit_Report] ([Head], [Value]) VALUES ('Whatsapp Message', '-');
INSERT INTO [cfg_Emandi_Unit_Report] ([Head], [Value]) VALUES ('Whatsapp', 'Yes');

INSERT INTO [cfg_Ledger] ([Head], [Value]) VALUES ('Descriptio', 'Yes');
INSERT INTO [cfg_Ledger] ([Head], [Value]) VALUES ('Note', 'Yes');
INSERT INTO [cfg_Ledger] ([Head], [Value]) VALUES ('Opning Balance', 'Yes');
INSERT INTO [cfg_Ledger] ([Head], [Value]) VALUES ('Credit Limit', 'Yes');
INSERT INTO [cfg_Ledger] ([Head], [Value]) VALUES ('Attach', 'Yes');
INSERT INTO [cfg_Ledger] ([Head], [Value]) VALUES ('Multi Address', 'Yes');
INSERT INTO [cfg_Ledger] ([Head], [Value]) VALUES ('Tax Registratio', 'Yes');
INSERT INTO [cfg_Ledger] ([Head], [Value]) VALUES ('Contact Details', 'Yes');
INSERT INTO [cfg_Ledger] ([Head], [Value]) VALUES ('Bank Details', 'Yes');

INSERT INTO [cfg_Marketing_Auction_VC] ([Head], [Value]) VALUES ('Commission', 7.5);
INSERT INTO [cfg_Marketing_Auction_VC] ([Head], [Value]) VALUES ('Whatsapp Message', NULL);
INSERT INTO [cfg_Marketing_Auction_VC] ([Head], [Value]) VALUES ('Back Entry Defolt', NULL);
INSERT INTO [cfg_Marketing_Auction_VC] ([Head], [Value]) VALUES ('Unit Chrage', NULL);
INSERT INTO [cfg_Marketing_Auction_VC] ([Head], [Value]) VALUES ('Carate_Chrage', 3);
INSERT INTO [cfg_Marketing_Auction_VC] ([Head], [Value]) VALUES ('Guni_Chrage', 2);
INSERT INTO [cfg_Marketing_Auction_VC] ([Head], [Value]) VALUES ('Zabhla_Chrage', 1);
INSERT INTO [cfg_Marketing_Auction_VC] ([Head], [Value]) VALUES ('Theli_Chrage', 2);
INSERT INTO [cfg_Marketing_Auction_VC] ([Head], [Value]) VALUES ('Kapda_Chrage', 1);

INSERT INTO [cfg_VC] ([Head], [Value]) VALUES ('Show Delete Entry', 'No');

INSERT INTO [cfg_Vouchers] ([Head], [Type], [Name], [Value], [Filter], [Data], [User]) VALUES ('HEAD', NULL, 'General Details', NULL, 'Voucher', NULL, 'All');
INSERT INTO [cfg_Vouchers] ([Head], [Type], [Name], [Value], [Filter], [Data], [User]) VALUES ('UNDER', 'Y', 'Show Account Current Balance', 'No', 'Voucher', NULL, 'All');
INSERT INTO [cfg_Vouchers] ([Head], [Type], [Name], [Value], [Filter], [Data], [User]) VALUES ('UNDER', 'Y', 'Show Account Current Credit', 'No', 'Voucher', NULL, 'All');
INSERT INTO [cfg_Vouchers] ([Head], [Type], [Name], [Value], [Filter], [Data], [User]) VALUES ('UNDER', 'SELECT', 'List Display Value', 'Current Balance', 'Voucher', 'Not Applicable\Account Group\Current Balance\Current Credit', 'All');
INSERT INTO [cfg_Vouchers] ([Head], [Type], [Name], [Value], [Filter], [Data], [User]) VALUES ('UNDER', 'SELECT', 'Credit limit expiry actio', 'Warning', 'Voucher', 'Not Applicable\Warning\No Save', 'All');

"


		Return st
	End Function

	Public Function Create_lnk(Path_TXT As String)
		Dim File_Name As String = "lnk.db"
		Dim Location As String = System.IO.Path.Combine(Path_TXT, File_Name)
		Dim create_qury As String = String.Format("Data Source = {0}", Location)
		'Create Tabales
		Dim tbl_ As String = lnk_qry()

		Dim cn As New SQLiteConnection(create_qury)
		cn.Open()
		cn.ChangePassword("Opens@Db2558")
		Dim cmd As New SQLiteCommand(tbl_, cn)
		cmd.ExecuteNonQuery()
		cn.Close()


	End Function
	Public Function Create_rec(Path_TXT As String)
		Dim File_Name As String = "rec.db"
		Dim Location As String = System.IO.Path.Combine(Path_TXT, File_Name)
		Dim create_qury As String = String.Format("Data Source = {0}", Location)
		'Create Tabales
		Dim tbl_ As String = rec_qry()
		Dim cn As New SQLiteConnection(create_qury)
		cn.Open()
		cn.ChangePassword("Opens@Db2558")

		Dim cmd As New SQLiteCommand(tbl_, cn)
		cmd.ExecuteNonQuery()
		cn.Close()
	End Function
	Public Function Create_aud(Path_TXT As String)
		Dim File_Name As String = "aud.db"
		Dim Location As String = IO.Path.Combine(Path_TXT, File_Name)
		Dim create_qury As String = String.Format("Data Source = {0}", Location)
		'Create Tabales
		Dim tbl_ As String = aud_qry()
		Dim cn As New SQLiteConnection(create_qury)
		cn.Open()
		cn.ChangePassword("Opens@Db2558")

		Dim cmd As New SQLiteCommand(tbl_, cn)
		cmd.ExecuteNonQuery()
		cn.Close()

		If open_MSSQL_Custom_path($"{Location}", cn) = True Then
			cmd = New SQLiteCommand("SELECT * FROM sqlite_master WHERE type='table'", cn)
			Dim Qry_Audit_Col As String = ""
			Dim Qry_Delete_Row As String = ""
			Dim r As SQLiteDataReader = cmd.ExecuteReader
			While r.Read
				Dim n As String = r("name").ToString
				If n <> "sqlite_sequence" Then
					Qry_Audit_Col &= $"
ALTER TABLE [{r("name").ToString}] ADD [Audit_ID] INTEGER;
ALTER TABLE [{r("name").ToString}] ADD [Original_ID] INTEGER;"

					If n <> "TBL_Info" Then
						Qry_Delete_Row &= $"
DELETE FROM [{r("name").ToString}];"
					End If
				End If
			End While
			r.Close()

			cmd = New SQLiteCommand(Qry_Audit_Col, cn)
			cmd.ExecuteNonQuery()

			cmd = New SQLiteCommand(Qry_Delete_Row, cn)
			cmd.ExecuteNonQuery()
		End If

	End Function
End Module