Imports System.ComponentModel
Imports System.Data.SQLite
Imports BarcodeLib
Imports Tools
Module Database_Update_mod

    Public Function Update_custo(db_v As String, frm As Database_repair_frm)
        If Val(db_v.ToString.Replace(".", "")) <= 1038 Then
            cfg_update_1037()
        End If
        If Val(db_v.ToString.Replace(".", "")) <= 1039 Then
            u_1039()
            cfg_update_port_code()
        End If
        If Val(db_v.ToString.Replace(".", "")) <= 1048 Then
            u_1048(frm)
        End If
        If Val(db_v.ToString.Replace(".", "")) <= 1050 Then
            u_1050(frm)
        End If
        If Val(db_v.ToString.Replace(".", "")) <= 1051 Then
            u_1051(frm)
        End If
        If Val(db_v.ToString.Replace(".", "")) <= 1052 Then
            u_1052(frm)
        End If
        If Val(db_v.ToString.Replace(".", "")) <= 1058 Then
            u_1058(frm)
        End If
        If Val(db_v.ToString.Replace(".", "")) <= 1059 Then
            u_1059(frm)
        End If


    End Function
    Private Function u_1059(frm As Database_repair_frm) As Boolean
        Dim Qry_str As List(Of String) = New List(Of String)
        Try
            Dim cn As New SQLiteConnection
            If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                cmd = New SQLiteCommand("UPDATE TBL_VC_item_Details
SET Batch_No = 'Primary Batch'
WHERE Batch_No IS NULL or Batch_No = '';", cn)
                cmd.ExecuteNonQuery()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            MessageBox.Show(ex.Message, "Update Version : 1.0.5.9", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
        Return True
    End Function
    Private Function u_1058(frm As Database_repair_frm) As Boolean
        Dim r As SQLiteDataReader
        frm.ProgressBag2.Value = 1
        frm.ProgressBag2.Maximum = 0

        Dim Qry_str As List(Of String) = New List(Of String)

        Try
            Dim cn As New SQLiteConnection
            If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                cmd = New SQLiteCommand("Select count(ID) as C From TBL_VC_item_Details", cn)
                r = cmd.ExecuteReader
                While r.Read
                    frm.ProgressBag2.Maximum = Val(r("C").ToString)
                End While
                r.Close()
                'Insurt 
                cmd = New SQLiteCommand("Select vi.Unit_Type as Unit_Type,
i.Unit as Unit,
i.Alter_Unit as Alter_Unit,
i.Alter_Unit_Val1 as Alter_Unit_Val1,
i.Alter_Unit_Val2 as Alter_Unit_Val2,
vi.Qty as Qty,
vi.Rate as Rate,
vi.ID as ID

From TBL_VC_item_Details vi
LEFT JOIN TBL_Stock_Item i on i.id = vi.Item", cn)
                r = cmd.ExecuteReader
                While r.Read
                    Dim Unit_Type As String = r("Unit_Type").ToString

                    Dim Unit1_id As String = r("Unit").ToString
                    Dim Unit2_id As String = r("Alter_Unit").ToString

                    Dim Unit1_vlu As Decimal = Val(r("Alter_Unit_Val1").ToString)
                    Dim Unit2_vlu As Decimal = Val(r("Alter_Unit_Val2").ToString)

                    Dim Qty As Decimal = Val(r("Qty").ToString)
                    Dim Rate As Decimal = Val(r("Rate").ToString)

                    Dim Qty1 As Decimal = 0
                    Dim Qty2 As Decimal = 0

                    Dim Rate1 As Decimal = 0
                    Dim Rate2 As Decimal = 0



                    Dim Unit_Curr As String
                    If Unit2_vlu <> 0 Then
                        If Unit_Type = "Second" Then
                            Dim v As Decimal = Unit1_vlu / Unit2_vlu
                            Dim Q As Decimal = v * Val(Qty)

                            Unit_Curr = Unit2_id

                            Qty2 = Val(Qty)
                            Qty1 = Q

                            Dim Rt As Decimal = Val(Val(Qty) * Val(Rate))
                            Rate2 = Val(Rate)
                            If Rt = 0 Then
                                Rate1 = 0
                            Else
                                Rate1 = Rt / (Q)
                            End If
                        Else
                            Dim v As Decimal = Unit2_vlu / Unit1_vlu
                            Dim Q As Decimal = v * Val(Qty)

                            Unit_Curr = Unit1_id

                            Qty1 = Val(Qty)
                            Qty2 = Q

                            Dim Rt As Decimal = Val(Val(Qty) * Val(Rate))
                            Rate1 = Val(Rate)
                            If Rt = 0 Then
                                Rate2 = Rt
                            Else
                                Rate2 = Rt / (Q)
                            End If
                        End If
                    Else
                        Qty1 = Val(Qty)
                        Qty2 = Val(0)
                        Rate1 = Val(Rate)
                        Rate2 = Val(0)
                        Unit_Curr = Unit1_id

                    End If

                    Dim Amount1 As Decimal = Qty1 * Rate1
                    Dim Amount2 As Decimal = Qty2 * Rate2

                    Qry_str.Add($"UPDATE TBL_VC_Item_Details SET [Unit1]='{Unit1_id}',[Unit2]='{Unit2_id}',[Qty1]='{Qty1}',[Qty2]='{Qty2}',[Rate1]='{Rate1}',[Rate2]='{Rate2}',[Unit]='{Unit_Curr}',[Amount1]='{Amount1}',[Amount2]='{Amount2}' Where ID = '{r("ID").ToString}'")

                    With frm
                        .ProgressBag2.Value = .ProgressBag2.Value + 1
                        .ProgressBag2.Run(0)

                        .BackgroundWorker1.ReportProgress(0)
                        .Label6.Text = $"{ .ProgressBag2.Value} / { .ProgressBag2.Maximum} Priparing Vouchers"
                        .ProgressBag2.vlu_label.Text = $"{N2_FORMATE(Val(.ProgressBag2.Value * 100) / Val(.ProgressBag2.Maximum))} %"

                    End With
                End While
                r.Close()
                frm.ProgressBag2.Value = 0

                For Each s As String In Qry_str
                    cmd = New SQLiteCommand(s, cn)
                    cmd.ExecuteNonQuery()


                    With frm
                        .ProgressBag2.Value = .ProgressBag2.Value + 1
                        .ProgressBag2.Run(0)

                        .BackgroundWorker1.ReportProgress(0)
                        .Label6.Text = $"{ .ProgressBag2.Value} / { .ProgressBag2.Maximum} Update Vouchers"
                        .ProgressBag2.vlu_label.Text = $"{N2_FORMATE(Val(.ProgressBag2.Value * 100) / Val(.ProgressBag2.Maximum))} %"

                    End With
                Next
            End If

            If open_MSSQL_Cstm(Database_File.cmp, cn) = True Then
                Try
                    cmd = New SQLiteCommand("DROP TABLE [TBL_WhatsApp];", cn)
                    cmd.ExecuteNonQuery()
                Catch ex As Exception

                End Try
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            MessageBox.Show(ex.Message, "Update Version : 1.0.5.8", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
        Return True
    End Function
    Private Function u_1052(frm As Database_repair_frm) As Boolean
        Dim cn As New SQLiteConnection
        Try

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Private Function u_1051(frm As Database_repair_frm) As Boolean
        Dim cn As New SQLiteConnection
        Try
            If open_MSSQL_Cstm(Database_File.cfgs, cn) = True Then
                cmd = New SQLiteCommand("CREATE TABLE 'TBL_Features' (
	'Id'	INTEGER NOT NULL UNIQUE,
	'Head'	TEXT,
	'Value'	TEXT,
	'Discription'	TEXT,
	'Type'	TEXT,
	PRIMARY KEY('Id' AUTOINCREMENT)
);", cn)
                cmd.ExecuteNonQuery()
            End If
            cn.Close()


        Catch ex As Exception
            cn.Close()
        End Try

        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand("ALTER TABLE [TBL_Voucher_Create] ADD [YN_item_Discount] TEXT;", cn)
            cmd.ExecuteNonQuery()

            cmd = New SQLiteCommand("ALTER TABLE [TBL_VC_item_Details] ADD [Discount_P] TEXT;
ALTER TABLE [TBL_VC_item_Details] ADD [Discount_A] TEXT;
", cn)
            cmd.ExecuteNonQuery()


        End If


    End Function
    Private Function u_1050(frm As Database_repair_frm) As Boolean
        Try
            Dim cn As New SQLiteConnection
            If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                cmd = New SQLiteCommand("UPDATE TBL_Acc_Group SET [Name] = 'Bank Accounts' where ID = '28'", cn)
                cmd.ExecuteNonQuery()
            End If
            'Create info Tabale
            Dim Code As String = ((Val(Now.Date.Day) + Val(Now.Date.Minute) + Val(Now.Date.Hour) & Val(Val(Now.TimeOfDay.Hours + Now.TimeOfDay.Minutes & Now.Date.Month + Now.Date.Day)) + Val(Val(Now.Date.Year))) - Val(Now.TimeOfDay.Minutes) + Val(Now.TimeOfDay.Minutes)) * 12552

            If open_MSSQL_Cstm(Database_File.cmp, cn) = True Then
                cmd = New SQLiteCommand($"INSERT INTO TBL_Info (Head,Value) VALUES ('Verification','{Code}')", cn)
                cmd.ExecuteNonQuery()
            End If
            If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                cmd = New SQLiteCommand($"INSERT INTO TBL_Info (Head,Value) VALUES ('Verification','{Code}')", cn)
                cmd.ExecuteNonQuery()
            End If
            If open_MSSQL_Cstm(Database_File.lnk, cn) = True Then
                cmd = New SQLiteCommand($"INSERT INTO TBL_Info (Head,Value) VALUES ('Verification','{Code}')", cn)
                cmd.ExecuteNonQuery()
            End If
            If open_MSSQL_Cstm(Database_File.rec, cn) = True Then
                cmd = New SQLiteCommand($"INSERT INTO TBL_Info (Head,Value) VALUES ('Verification','{Code}')", cn)
                cmd.ExecuteNonQuery()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Private Function u_1048(frm As Database_repair_frm) As Boolean
        Dim r As SQLiteDataReader
        frm.ProgressBag2.Value = 1
        frm.ProgressBag2.Maximum = 0
        Try
            Dim cn As New SQLiteConnection
            If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                cmd = New SQLiteCommand("Select count(ID) as C From TBL_VC Where Visible = 'Approval' and Effect_Ledger = 'Yes'", cn)
                r = cmd.ExecuteReader
                While r.Read
                    frm.ProgressBag2.Maximum = Val(r("C").ToString)
                End While
                r.Close()
                'Insurt 
                Dim count_ As Integer = 1
                cmd = New SQLiteCommand("Select *, vc.Ledger,
(Select L.[Group] From TBL_Ledger L where L.ID = vc.Ledger) as G
From TBL_VC vc where vc.Visible = 'Approval' and vc.Effect_Ledger = 'Yes'", cn)
                r = cmd.ExecuteReader
                While r.Read
                    With frm
                        .ProgressBag2.Value = .ProgressBag2.Value + 1
                        .ProgressBag2.Run(0)

                        .BackgroundWorker1.ReportProgress(0)
                        .Label6.Text = $"{ .ProgressBag2.Value} / { .ProgressBag2.Maximum} Vouchers"


                        .ProgressBag2.vlu_label.Text = $"{N2_FORMATE(Val(.ProgressBag2.Value * 100) / Val(.ProgressBag2.Maximum))} %"
                        For i As Integer = 1 To 100 Step 10
                            .ProgressBag_Custom2.Value = i
                            .ProgressBag_Custom2.Run(0)
                        Next
                    End With

                    Dim Typ As String = r("Type").ToString
                    If (r("Voucher_Type").ToString = "Purchase Order" Or r("Voucher_Type").ToString = "Sales Order") Or (r("Voucher_Type").ToString = "Purchase" Or r("Voucher_Type").ToString = "Sales") Or (r("Voucher_Type").ToString = "Inward Register" Or r("Voucher_Type").ToString = "Outward Register") Or (r("Voucher_Type").ToString = "Credit Note" Or r("Voucher_Type").ToString = "Debit Note") Then
                        If r("G").ToString = "10" Then
                            Typ = "Sales Account"
                        ElseIf r("G").ToString = "11" Then
                            Typ = "Purchase Account"
                        ElseIf r("G").ToString = "20" Then
                            Typ = "GST"
                        End If
                    Else

                    End If

                    cmd = New SQLiteCommand($"INSERT INTO TBL_VC_Ledger (Type,Date,Tra_ID,Ledger,Dr,Cr) VALUES ('{Typ}','{CDate(r("Date").ToString).ToString(Lite_date_Format)}','{r("Tra_ID").ToString}','{r("Ledger").ToString}','{Val(r("Debit_Amount").ToString)}','{Val(r("Credit_Amount").ToString)}')", cn)
                    cmd.ExecuteNonQuery()
                    count_ += 1
                End While
                r.Close()

                cmd = New SQLiteCommand($"DELETE FROM TBL_VC Where Type <> 'Head'", cn)
                cmd.ExecuteNonQuery()

                cmd = New SQLiteCommand($"UPDATE TBL_VC_Item_Details SET [Date] = (Select vc.[Date] From TBL_VC vc where vc.Tra_ID = TBL_VC_Item_Details.Tra_ID)", cn)
                cmd.ExecuteNonQuery()

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
        Return True
    End Function

    Private Function u_1039() As Boolean
        Try
            Dim cn As New SQLiteConnection
            If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                cmd = New SQLiteCommand("UPDATE TBL_Voucher_Create SET Voucher_Start = '1'", cn)
                cmd.ExecuteNonQuery()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
        Return True
    End Function

    Public Function cfg_update_port_code() As Boolean
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cfgs, cn) = True Then
            cmd = New SQLiteCommand("SELECT name FROM sqlite_master WHERE type='table' AND name='TBL_PORT_CODE';", cn)
            Dim r As SQLiteDataReader = cmd.ExecuteReader
            Dim TBL_PORT_CODE As Boolean = False
            While r.Read
                TBL_PORT_CODE = True
            End While
            r.Close()

            Try
                If TBL_PORT_CODE = False Then
                    Dim q As String = "CREATE TABLE 'TBL_PORT_CODE' (
	'Name'	TEXT,
	'Code'	TEXT,
	'Mode'	TEXT,
	'State'	TEXT
);

INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('AACHIVS SEZ/NOIDA', 'INDEA6', 'ICD', 'UTTAR PRADESH');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('AAL-SEZ/Visakhapatnam', 'INNRP6', 'ICD', 'Andhra Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('AA-SEZ AHMEDABAD', 'INAPI6', 'ICD', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Achra', 'INACH1', 'SEA', 'Maharashlra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Adalaj', 'INADA6', 'ICD', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('AEPL SEZ/GURGAON', 'INGGE6', 'ICD', 'HARYANA');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Agartala', 'INAGT8', 'ROAD', 'Tripura');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Agatti Island', 'INAGI1', 'SEA', 'Lakshadweep');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Agra', 'INAGR4', 'AIR', 'Uttar Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Agra', 'INBLJ6', 'ICD', 'Uttar Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Ahmedabad', 'INAMD4', 'AIR', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('ALANG SBY', 'INALA1', 'SEA', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Alibag', 'INABG1', 'SEA', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Allepey', 'INALF1', 'SEA', 'Kerala');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Amingaon(Gauhati)', 'INAMG6', 'ICD', 'Assam');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Amini IsTand', 'INAMI1', 'SEA', 'Lakshadweep');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Amritsar', 'INASR6', 'ICD', 'Punjab');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Amritsar Railway Station', 'INASR2', 'RAILWAY', 'Punjab');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('AN FTWZ LTD - FTWZ/ BULANDSHAHR', 'INBUL6', 'ICD', 'Uttar Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('ANANT SEZ/SONEPAT', 'INSNR6', 'ICD', 'HARYANA');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Anaparthi', 'INAPT6', 'ICD', 'Andhra Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Androth Island', 'INADI1', 'SEA', 'Lakshadweep');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Anijengo', 'INANG1', 'SEA', 'Kerala');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Ankleshwar', 'INAKV6', 'ICD', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('ANSAL IT CITY SEZ/NOIDA', 'INDIT6', 'ICD', 'UTTAR PRADESH');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('ANSAL SEZ/GURGAON', 'INGAS6', 'ICD', 'HARYANA');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('ANSAL SEZ/SONEPAT', 'INSNA6', 'ICD', 'HARYANA');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('APIIC/SEZ/Cuddapah', 'INCDP6', 'ICD', 'Andhra Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('APIICL SEZ/Visakhapatnam', 'INAKP6', 'ICD', 'Andhra Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('APIICL/Medak District', 'INFMA6', 'ICD', 'Andhra Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('APIIC-SEZ/Vill-Lalgadi Distt.-Ranga Reddy', 'INMEA6', 'ICD', 'Andhra Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('APPSEZ/Doddakanahalli', 'INKJA6', 'ICD', 'Karnataka');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Arakkonam - Melpakkam - Chennai ICD', 'INAJJ6', 'ICD', 'Tamil Nadu');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Arnala', 'INANL1', 'SEA', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Aroor', 'INARR6', 'ICD', 'Kerala');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Arshiya International Ltd SEZ /Panvel', 'INPNV6', 'ICD', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Attari Railway Station', 'INATT2', 'RAILWAY', 'Punjab');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Attari Road', 'INATR8', 'ROAD', 'Punjab');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Azhikkal', 'INAZK1', 'SEA', 'Kerala');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Babarpur', 'INPNP6', 'ICD', 'Haryana');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Badagara', 'INBDG1', 'SEA', 'Kerala');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Bagdogra', 'INIXB4', 'AIR', 'West Bengal');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Baghmara', 'INBGM8', 'ROAD', 'Meghalaya');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('BAGMANESEZ/Bangalore', 'INKJB6', 'ICD', 'Karnataka');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Bahabal Pur', 'INBBP1', 'SEA', 'Orissa');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Baindur', 'INBDR1', 'SEA', 'Karnataka');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Bairgania', 'INBGU8', 'ROAD', 'Bihar');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Balet', 'INBLT8', 'ROAD', 'Meghalaya');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Banbasa', 'INBSA8', 'ROAD', 'Uttar Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Bandra', 'INBND1', 'SEA', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Bangalore', 'INWFD6', 'ICD', 'Karnataka');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Banglore Air Cargo', 'INBLR4', 'AIR', 'Karnataka');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Bankot', 'INBKT1', 'SEA', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Bareilly', 'INBEK4', 'AIR', 'Uttar Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Bari Brahma', 'INBBM6', 'ICD', 'Jammu Kashmir');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Barmer Railway Station', 'INBMR2', 'RAILWAY', 'Rajasthan');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Baroda', 'INBRC6', 'ICD', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Barsora', 'INBRA8', 'ROAD', 'Meghalaya');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Bassein', 'INBSN1', 'SEA', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Bedi(Including Rozi-Jamnagar)', 'INBED1', 'SEA', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Belapur', 'INBLP1', 'SEA', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Belekeri', 'INBKR1', 'SEA', 'Karnataka');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Belekeri', 'INBLK1', 'SEA', 'Karnataka');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Belgaum - Desur', 'INDRU6', 'ICD', 'Karnataka');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Berhni', 'INBNY8', 'ROAD', 'Uttar Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Betul', 'INBET1', 'SEA', 'Goa');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Beyt', 'INBYT1', 'SEA', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Bhagat ki Kothi - Jodhpur ICD', 'INBGK6', 'ICD', 'Rajasthan');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Bhagwa', 'INBGW1', 'SEA', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Bhatinda', 'INBTI6', 'ICD', 'Punjab');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Bhatkal', 'INBTK1', 'SEA', 'Karnataka');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Bhavanagar', 'INBHU1', 'SEA', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Bheemunipatnam', 'INBNP1', 'SEA', 'Andhra Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Bhilwara', 'INBHL6', 'ICD', 'Rajasthan');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Bhimnagar', 'INBNR8', 'ROAD', 'Bihar');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Bhithamore(Sursnad)', 'INBTM8', 'ROAD', 'Bihar');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Bhiwadi', 'INBWD6', 'ICD', 'Rajasthan');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Bhiwandi', 'INBWN1', 'SEA', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Bhubaneswar', 'INBBI4', 'AIR', 'Orissa');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Bhusaval ICD', 'INBSL6', 'ICD', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('BIACPL SEZ/Visakhapatnam', 'INAKB6', 'ICD', 'Andhra Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Bilimora', 'INBLM1', 'SEA', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Biocon SEZ / Bangalore', 'INSBC6', 'ICD', 'Karnataka');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Bitra Island', 'INBTR1', 'SEA', 'Lakshadweep');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Bolanganj', 'INBOL8', 'ROAD', 'Meghalaya');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Bombay Air Cargo', 'INBOM4', 'AIR', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Bombay Sea', 'INBOM1', 'SEA', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Borlai - Mandla', 'INBRM1', 'SEA', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Borya', 'INBRY1', 'SEA', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('BRIGADEENTERSEZ/Kannada', 'INMAB6', 'ICD', 'Karnataka');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Broach', 'INBRH1', 'SEA', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('BTSL SEZ/PUNE', 'INPNB6', 'ICD', 'MAHARASHTRA');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Bulsar', 'INBSR1', 'SEA', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('C.H. Kozikode', 'INCCJ1', 'SEA', 'Kerala');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Cambay', 'INCMB1', 'SEA', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Cannanore', 'INCNN1', 'SEA', 'Kerala');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('CANTON SEZ/GURGAON', 'INGHC6', 'ICD', 'HARYANA');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('CARBODUNDUMUNIVERSALSEZ/Ernakulam', 'INKLC6', 'ICD', 'Kerala');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Car-Nicobar', 'INCNB1', 'SEA', 'Andaman and Nicobar');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('CCIPL-SEZ/AHMEDABAD', 'INADC6', 'ICD', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('CESSNAGARDENSEZ/Bangalore', 'INBLC6', 'ICD', 'Karnataka');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('CGRPL-SEZ/AHMEDABAD', 'INADR6', 'ICD', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Champai', 'INCHP8', 'ROAD', 'Mizoram');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Chamurchi', 'INCHM8', 'ROAD', 'Sikkim');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Changrabandh', 'INCBD8', 'ROAD', 'West Bengal');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Chapora', 'INCHR1', 'SEA', 'Goa');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Chengalpattu (MWCD Ltd. - Apparels-SEZ)', 'INCGA6', 'ICD', 'Tamilnadu');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Chengalpattu (MWCD Ltd.-Auto Ancillaries-SEZ)', 'INCGL6', 'ICD', 'Tamilnadu');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Chengalpattu (MWCD Ltd.-IT SEZ)', 'INCGI6', 'ICD', 'Tamilnadu');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Chennai (EPZ/SEZ)', 'INMAA6', 'ICD', 'Tamil Nadu');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Chennai Air Cargo', 'INMAA4', 'AIR', 'Tamilnadu');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Chennai Sea', 'INMAA1', 'SEA', 'Tamilnadu');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Chettat Island', 'INCTI1', 'SEA', 'Lakshadweep');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Chinchwad ( ICD)', 'INCCH6', 'ICD', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Chirala', 'INCLX6', 'ICD', 'Andhra Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('CMTL ICD/THIMMAPUR', 'INTMX6', 'ICD', 'ANDHRA PRADESH');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Cochin', 'INCOK4', 'AIR', 'Kerala');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Cochin (EPZ/SEZ)', 'INCOK6', 'ICD', 'Kerala');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Cochin Sea', 'INCOK1', 'SEA', 'Kerala');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Coimbatore', 'INCBE6', 'ICD', 'Tamilnadu');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Coimbatore', 'INCJB4', 'AIR', 'Tamilnadu');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Coimbatore - Irugur ICD', 'INIGU6', 'ICD', 'Tamil Nadu');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Coimbatore (SE & C Pvt. Ltd.-SEZ', 'INCBS6', 'ICD', 'Tamilnadu');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Colachel', 'INCHL1', 'SEA', 'Tamilnadu');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('CONCOR-ICD/BALLABHGARH', 'INBVC6', 'ICD', 'Haryana');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Coondapur (Ganguly)', 'INCDP1', 'SEA', 'Karnataka');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Coondapur (Ganguly)', 'INCOO1', 'SEA', 'Karnataka');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Cornwallis', 'INCRN1', 'SEA', 'Andaman and Nicobar');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Cuddalore', 'INCDL1', 'SEA', 'Tamilnadu');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Dabhol Port', 'INDHP1', 'SEA', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Dabolim', 'INGOI4', 'AIR', 'Goa');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Dadri - STTPL (CFS)', 'INSTT6', 'ICD', 'Uttar Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Dadri TTPL', 'INTTP6', 'ICD', 'Uttar Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Dadri-ACPL CFS', 'INAPL6', 'ICD', 'Uttar Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Dadri-CGML', 'INCPL6', 'ICD', 'Uttar Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Dahanu', 'INDHN1', 'SEA', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Dahanu', 'INDHU1', 'SEA', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Dahej', 'INDAH1', 'SEA', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Dahez SEZ', 'INBHD6', 'ICD', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Dalu', 'INDLU8', 'ROAD', 'Meghalaya');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Daman & Diu', 'INDAM1', 'SEA', 'Daman &Diu');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Dantiwara', 'INDTW1', 'SEA', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('DAPPER', 'INDPR6', 'ICD', 'Punjab');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Darranga', 'INDRG8', 'ROAD', 'Assam');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Daulatabad ICD', 'INDLB6', 'ICD', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Dawki', 'INDWK8', 'ROAD', 'Meghalaya');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('DCA-I SEZ/CHANDIGARH', 'INCDD6', 'ICD', 'CHANDIGARH');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('DCA-II SEZ/CHANDIGARH', 'INCDC6', 'ICD', 'CHANDIGARH');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Delhi Air Cargo', 'INDEL4', 'AIR', 'Delhi');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Delhi Railway Station', 'INDLI2', 'RAILWAY', 'Delhi');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Demagir', 'INDMR8', 'ROAD', 'Nagaland');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Deogad', 'INDEG1', 'SEA', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Dhalaighat', 'INDHL8', 'ROAD', 'Tripura');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Dhanu - Shkodi', 'INDSK1', 'SEA', 'Tamilnadu');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Dharamtar', 'INDMT1', 'SEA', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Dharchula', 'INDLA8', 'ROAD', 'Uttar Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Dholera', 'INDHR1', 'SEA', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Dhubri Steamerghat', 'INDHB8', 'ROAD', 'Assam');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Dighi Port', 'INDIG1', 'SEA', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Dighi(Pune)', 'INDIG6', 'ICD', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Div', 'INDIV1', 'SEA', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('DIVYASREETECNOPARKSEZ/Bangalore', 'INKJD6', 'ICD', 'Karnataka');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('DLF SEZ/GURGAON', 'INGGD6', 'ICD', 'HARYANA');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('DLF/SEZ/Rangareddy', 'INLPD6', 'ICD', 'Andhra Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('DLFCYBER CITY SEZ/GURGAON', 'INGDL6', 'ICD', 'HARYANA');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('DLL SEZ/Visakhapatnam', 'INVZM6', 'ICD', 'Andhra Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('DSIL SEZ/RANGA REDDY', 'INLPS6', 'ICD', 'ANDHRA PRADESH');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Dwarka (Rupen)', 'INDRK1', 'SEA', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('E-Complex SEZ / Amreli', 'INJBL6', 'ICD', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('EKIPL SEZ/PUNE', 'INPEK6', 'ICD', 'MAHARASHTRA');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('ELECTRONICSTECHPARK-IIISEZ/Thiruvananthapuram', 'INKZP6', 'ICD', 'Kerala');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('ELECTRONICSTECHPARK-IISEZ/Thiruvananthapuram', 'INKZT6', 'ICD', 'Kerala');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('ELECTRONICTECH-ISEZ/Thiruvananthapuram', 'INKZE6', 'ICD', 'Kerala');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Elphinstone Harbour', 'INESH1', 'SEA', 'Andaman and Nicobar');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Ennore', 'INENR1', 'SEA', 'Tamilnadu');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Erode (ETLISL-SEZ)', 'INUKL6', 'ICD', 'Tamilnadu');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Erode (SIPCOT-SEZ)', 'INPYS6', 'ICD', 'Tamilnadu');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('ESPIRE SEZ/FARIDABAD', 'INFBE6', 'ICD', 'HARYANA');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Euro Multivision Bhachau SEZ / Kutch', 'INBCO6', 'ICD', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Falta (EPZ/SEZ)', 'INFLT6', 'ICD', 'West Bengal');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Faridabad', 'INFBD6', 'ICD', 'Haryana');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('FRESH HPL SEZ/GURGAON', 'INGGF6', 'ICD', 'HARYANA');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Fulbari', 'INFBR8', 'ROAD', 'West Bengal');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Galgalia', 'INGAL8', 'ROAD', 'Bihar');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('GALLANT SEZ/NOIDA', 'INDGI6', 'ICD', 'UTTAR PRADESH');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Gandhidham', 'INGIN6', 'ICD', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Gangavaram Port', 'INGGV1', 'SEA', 'Andhra Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Garhi Harsaru - Gurgaon ICD', 'INGHR6', 'ICD', 'Haryana');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Gauhati', 'INGAU4', 'AIR', 'Assam');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Gauhati Steamerghat', 'INGHW8', 'ROAD', 'Assam');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Gauriphanta', 'INGAI8', 'ROAD', 'Uttar Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Gaya', 'INGAY4', 'AIR', 'Bihar');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Gede Railway Station', 'INGED2', 'RAILWAY', 'West Bengal');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Gem and Jwewllwey-SEZ/Ulwe(Distt. Raigad)', 'INBAG6', 'ICD', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('GENPECT SEZ/JAIPUR', 'INJGI6', 'ICD', 'RAJASTHAN');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Getandah', 'INGTZ8', 'ROAD', 'West Bengal');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Ghasuapara', 'INGHP8', 'ROAD', 'Meghalaya');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('GHB-SEZ SURAT', 'INUDN6', 'ICD', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('GHI SEZ/GURGAON', 'INGGG6', 'ICD', 'HARYANA');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Ghogha', 'INGHA1', 'SEA', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Ghojadanga', 'INGJX8', 'ROAD', 'West Bengal');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('GIDC-SEZ/GANDHINAGAR', 'INGNG6', 'ICD', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('GIL SEZ/GURGAON', 'INGGI6', 'ICD', 'HARYANA');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('GIPL-SEZ/AHMEDABAD', 'INADG6', 'ICD', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Gitaldah road', 'INGTG8', 'ROAD', 'Assam');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('GLOBALVILLAGESEZ/Bangalore', 'INKGG6', 'ICD', 'Karnataka');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Goa Sea', 'INMRM1', 'SEA', 'Goa');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Gogha', 'INGGA1', 'SEA', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Golakganj (LCS )', 'INGKJ8', 'ROAD', 'Assam');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Golakganj Raiiway Station', 'INGKJ2', 'RAILWAY', 'Assam');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('GOLDEN SEZ/NOIDA', 'INDGT6', 'ICD', 'UTTAR PRADESH');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('GOPALANGLOBALSEZ/Bangalore', 'INKJG6', 'ICD', 'Karnataka');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Gopalpur', 'INGPR1', 'SEA', 'Orissa');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('GPRL SEZ/GURGAON', 'INGRL6', 'ICD', 'HARYANA');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Greater Noida-Surajpur', 'INSJR6', 'ICD', 'Uttar Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Gunji', 'INGJI8', 'ROAD', 'Uttar Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Haldia', 'INHAL1', 'SEA', 'West Bengal');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Haldibari Railway Station', 'INHLD2', 'RAILWAY', 'Assam');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Hangarkatta', 'INHGT1', 'SEA', 'Karnataka');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('HARI SEZ/VARANASI', 'INBCH6', 'ICD', 'UTTAR PRADESH');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Harnai', 'INHRN1', 'SEA', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Hatisar', 'INHTS8', 'ROAD', 'Assam');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Hazira SEZ / Surat', 'INHZA6', 'ICD', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('HCL SEZ/NOIDA', 'INDEH6', 'ICD', 'UTTAR PRADESH');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('HCLTECHSEZ/Bangalore/Karnataka', 'INKJH6', 'ICD', 'Karnataka');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('hgsezl/Ranga Reddy', 'INFMH6', 'ICD', 'Andhra Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Hilli', 'INHLI8', 'ROAD', 'West Bengal');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Hingalganj', 'INHGL8', 'ROAD', 'West Bengal');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('HINGAWADI,PHASE-III,PUNE', 'INPUM6', 'ICD', 'MAHARASHTRA');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('HIPL SEZ/Visakhapatnam', 'INTNI6', 'ICD', 'Andhra Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Honawar', 'INHWR1', 'SEA', 'Karnataka');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Hyderabad', 'INSNF6', 'ICD', 'Andhra Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Hyderabad Air Cargo', 'INHYD4', 'AIR', 'Andhra Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('ICD Badohi', 'INBDH6', 'ICD', 'Uttar Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('ICD Durgapur', 'INDUR6', 'ICD', 'West Bengal');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('ICD HASAN', 'INHAS6', 'ICD', 'Karnataka');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('ICD HAZIRA SURAT', 'INHZR6', 'ICD', 'GUJRAT');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('ICD Loni', 'INLON6', 'ICD', 'Uttar Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('ICD Maliwada', 'INMWA6', 'ICD', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('ICD TONDIARPET', 'INTVT6', 'ICD', 'Chennai');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('IIFFCO/SEZ/Nellore', 'INTMI6', 'ICD', 'Andhra Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Imphal', 'INIMF4', 'AIR', 'Manipur');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Indore', 'INIDR4', 'AIR', 'Madhya Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Indore (EPZ/SEZ)', 'INIDR6', 'ICD', 'Madhya Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Indore-Dhannad', 'INDHA6', 'ICD', 'Madhya Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('INFOPARKSEZ/Ernakulam', 'INKLI6', 'ICD', 'Kerala');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('INFORMATIONTECHPARKSEZ/Bangalore', 'INWFI6', 'ICD', 'Karnataka');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('INFOSYSSEZ/Bangalore', 'INSBL6', 'ICD', 'Karnataka');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('INFOSYSSEZ/Mangalore', 'INMAI6', 'ICD', 'Karnataka');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('INFOSYSSEZ/MYSORE', 'INHEI6', 'ICD', 'Karnataka');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('IT/ITES-A-SEZ/Ulwe(Distt.Raigad)', 'INBAU6', 'ICD', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('IT/ITES-B-SEZ/Ulwe(Distt.Raigad)', 'INBAI6', 'ICD', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('IT/ITES-C SEZ/Ulwe', 'INBAT6', 'ICD', 'Maharasthra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('ITL SEZ/PUNE', 'INPIT6', 'ICD', 'MAHARASHTRA');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('ITL SEZ/RANGA REDDY', 'INGTI6', 'ICD', 'ANDHRA PRADESH');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('IVR SEZ/NOIDA', 'INDEI6', 'ICD', 'UTTAR PRADESH');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('J T/SEZ/Rangareddy', 'INFMJ6', 'ICD', 'Andhra Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Jafrabad', 'INJBD1', 'SEA', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Jaigad', 'INJGD1', 'SEA', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Jaigaon', 'INJIG8', 'ROAD', 'West Bengal');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Jaipur', 'INJAI4', 'AIR', 'Rajasthan');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES (X'4a616970757220c2962053697461707572202845505a2f53455a29', 'INJSZ6', 'ICD', 'Rajasthan');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Jaipur ICD', 'INJAI6', 'ICD', 'Rajasthan');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Jaitapur', 'INJTP1', 'SEA', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Jakhau', 'INJAK1', 'SEA', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Jalandhar', 'INJUC6', 'ICD', 'Punjab');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Jalgaon', 'INJAL6', 'ICD', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Jalpaiguri', 'INJPG8', 'ROAD', 'West Bengal');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Jamshedpur (ICD)', 'INIXW6', 'ICD', 'Jharkhand');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Jamshedpur (ICD)', 'INTAT6', 'ICD', 'Jharkhand');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Jarwa', 'INJWA8', 'ROAD', 'Uttar Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Jayanagar', 'INJAY8', 'ROAD', 'Bihar');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Jhulaghat (Pithoragarh)', 'INJHO8', 'ROAD', 'Uttar Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Jodhpur', 'INJUX6', 'ICD', 'Rajasthan');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Jodhpur- Boranda (EPZ/SEZ)', 'INBRN6', 'ICD', 'Rajasthan');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Jodia', 'INJDA1', 'SEA', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Jogbani', 'INJBN8', 'ROAD', 'Bihar');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('JUBILANT SEZ/NOIDA', 'INDEJ6', 'ICD', 'UTTAR PRADESH');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Kadmat lsland', 'INKDI1', 'SEA', 'Lakshadweep');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Kakinada', 'INKAK1', 'SEA', 'Andhra Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Kakinada', 'INCOI6', 'ICD', 'Andhra Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Kakinada (Kakinada SEZ Pvt. Ltd.-SEZ)', 'INCOA6', 'ICD', 'Andhra Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Kakinada (Parry Infrastructure Co. Pvt. Ltd.-SEZ)', 'INCOP6', 'ICD', 'Andhra Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Kallai', 'INKAL1', 'SEA', 'Kerala');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Kalyan', 'INKLY1', 'SEA', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Kanakpura - Jaipur ICD', 'INKKU6', 'ICD', 'Rajasthan');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Kancheepuram (PHPL-SEZ)', 'INTBM6', 'ICD', 'Tamilnadu');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Kandla', 'INIXY1', 'SEA', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Kandla (EPZ/SEZ)', 'INIXY6', 'ICD', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Kandla SEZ / Gandhidham', 'INKDL6', 'ICD', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Kankudy', 'INKND1', 'SEA', 'Kerala');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Kanpur', 'INCPC6', 'ICD', 'Uttar Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Kanpur', 'INKNU4', 'AIR', 'Uttar Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Kanpur - JRY (ICD )', 'INKNU6', 'ICD', 'Uttar Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Kapadra(Surat)', 'INKAP6', 'ICD', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Karaikal', 'INKRK1', 'SEA', 'Pondicheri');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Karanja', 'INKRN1', 'SEA', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Karedu', 'INKDD6', 'ICD', 'Andhra Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Karimganj Railway Station', 'INKXJ2', 'RAILWAY', 'Assam');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Karimganj Steamerghat and Ferry Ghat', 'INKGJ8', 'ROAD', 'Assam');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Karipur(Calicut)', 'INCCJ4', 'AIR', 'Kerala');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('KARUR', 'INKAR6', 'ICD', 'Tamil Nadu');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Karwar(including Sardeshivagad)', 'INKRW1', 'SEA', 'Karnataka');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Kasargod', 'INKSG1', 'SEA', 'Kerala');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Katarniyaghat', 'INKTG8', 'ROAD', 'Uttar Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Kathihar', 'INKTR8', 'ROAD', 'Bihar');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('KATTUPALLI VILLAGE,PONNERI TALUK,TIRUVALLUR', 'INKAT1', 'SEA', 'TAMILNADU');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Kavaratti Island', 'INKVT1', 'SEA', 'Lakshadweep');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Kavi', 'INKVI1', 'SEA', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('KBITS SEZ / Bangalore', 'INBNC6', 'ICD', 'Karnataka');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Kel Sahar Subdivision', 'INKEL8', 'ROAD', 'Tripura');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Kelshi', 'INKSH1', 'SEA', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Kelwa', 'INKIW1', 'SEA', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('KEONICSSEZ/Shimoga', 'INSMK6', 'ICD', 'Karnataka');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Kheda -Dhar ICD', 'INKHD6', 'ICD', 'Madhya Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Khopta (EPZ/SEZ)', 'INKHP6', 'ICD', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Khowaighat', 'INKWG8', 'ROAD', 'Tripura');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Khunwa', 'INKWA8', 'ROAD', 'Uttar Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('KIADBAEROSEZ/Bangalore', 'INSBK6', 'ICD', 'Karnataka');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('KIADBFP SEZ / Hassan', 'INHSF6', 'ICD', 'Karnataka');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('KIADBP SEZ / Hassan', 'INHSP6', 'ICD', 'Karnataka');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('KIADBSEZ/MANGALORE', 'INMQK6', 'ICD', 'Karnataka');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('KIADBT SEZ / Hassan', 'INHST6', 'ICD', 'Karnataka');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Kilakari', 'INKKR1', 'SEA', 'Tamilnadu');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Kiltan Island', 'INKTI1', 'SEA', 'Lakshadweep');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('KINFRAA SEZ / Thiruvananthapuram', 'INTVC6', 'ICD', 'Kerala');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('KINFRAELECSEZ/Kanayannoor', 'INKLK6', 'ICD', 'Kerala');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('KINFRAFP SEZ / Kozhikkode', 'INCCT6', 'ICD', 'Kerala');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('KIPSEZ/NorthBangalore', 'INYNK6', 'ICD', 'Karnataka');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Kiranpani', 'INKRP1', 'SEA', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('KLPPL PANKI', 'INPNK6', 'ICD', 'Uttar Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Kodinar(Muldwarka)', 'INKDN1', 'SEA', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Koka', 'INKOK1', 'SEA', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Kolkata Air Cargo', 'INCCU4', 'AIR', 'West Bengal');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Kolkata Sea', 'INCCU1', 'SEA', 'West Bengal');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Kondiapetnam', 'INKDP1', 'SEA', 'Kerala');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Kota', 'INKTT6', 'ICD', 'Rajasthan');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Kota-Ravtha Road', 'INRDT6', 'ICD', 'Uttar Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Kotawalighat (Mohedipur)', 'INMHD8', 'ROAD', 'West Bengal');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Kotda', 'INKTD1', 'SEA', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Koteshwar', 'INKTW1', 'SEA', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('KOTTAYAM', 'INKYM6', 'ICD', 'Kerala');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Kovalam', 'INKVL1', 'SEA', 'Kerala');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Kovvur (WFPML-SEZ)', 'INKVR6', 'ICD', 'Andhra Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Krishnapatnam', 'INKRI1', 'SEA', 'Andhra Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('KSITILASEZ/Alappuzha', 'INSRK6', 'ICD', 'Kerala');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('KSITILSEZ/Alappuzha', 'INAMK6', 'ICD', 'Kerala');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('KSITILSEZ/Kollam', 'INKUK6', 'ICD', 'Kerala');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('KSITILSEZ/Kozhikode', 'INCLK6', 'ICD', 'Kerala');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('KSITILSEZ/Payyanoor', 'INPAK6', 'ICD', 'Kerala');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Kulasekarapatnam', 'INKSP1', 'SEA', 'Tamilnadu');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Kumbharu', 'INKMB1', 'SEA', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Kunauli', 'INKNL8', 'ROAD', 'Bihar');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Kundli', 'INNUR6', 'ICD', 'Haryana');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('L and T Ltd. /SEZ/Vadodara', 'INBRL6', 'ICD', 'GUJARAT');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Lalgola Town', 'INLGL8', 'ROAD', 'West Bengal');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('LANDTSEZ/Mysore', 'INMYL6', 'ICD', 'Karnataka');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Latu Bazar', 'INLTB8', 'ROAD', 'Assam');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Leapuram', 'INLPR1', 'SEA', 'Kerala');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('LIPL-ICD/Marripalem, Guntur', 'INGNR6', 'ICD', 'Andhra Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('LSPL SEZ/ RAJNANDGAON', 'INRJN6', 'ICD', 'CHHATTISGARH');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Lucknow', 'INLKO4', 'AIR', 'Uttar Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Ludhiana', 'INLUD6', 'ICD', 'Punjab');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Ludhiana', 'INLDH6', 'ICD', 'Punjab');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('LUXOR SEZ/GURGAON', 'INGGL6', 'ICD', 'HARYANA');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('M/s ALPL CFS,Dadri,Gautam Budh Nagar', 'INALP6', 'ICD', 'Uttar Pardesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('MADCL SEZ/ NAGPUR', 'INKRM6', 'ICD', 'MAHARASHTRA');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Madhosingh ICD', 'INMBS6', 'ICD', 'Uttar Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Madurai ICD', 'INIXM6', 'ICD', 'Tamil Nadu');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Magdalla', 'INMDA1', 'SEA', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Mahaboobnagar (APIIC Ltd.-SEZ)', 'INGLY6', 'ICD', 'Andhra Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Mahe', 'INMHE1', 'SEA', 'Kerala');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Mahendraganj', 'INMGH8', 'ROAD', 'Meghalaya');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('MAHINDRA SEZ/JAIPUR', 'INJPM6', 'ICD', 'RAJASTHAN');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('MAHINDRA SEZ/SANGANER', 'INJPW6', 'ICD', 'RAJASTHAN');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('MAHINDRAWORLD SEZ/JAIPUR', 'INJMW6', 'ICD', 'RAJASTHAN');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Mahisashan Railway Station', 'INMHN2', 'RAILWAY', 'Assam');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Mahurighat', 'INMHG8', 'ROAD', 'Tripura');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Mahuva', 'INMHA1', 'SEA', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Malanpur ICD', 'INMPR6', 'ICD', 'Madhya Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Malanpur(Gwalior)', 'INGWL6', 'ICD', 'Madhya Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Mallipuram', 'INMLP1', 'SEA', 'Kerala');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Malpe', 'INMAL1', 'SEA', 'Karnataka');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Malwan', 'INMLW1', 'SEA', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Mandapam', 'INMDP1', 'SEA', 'Tamilnadu');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Mandideep', 'INMDD6', 'ICD', 'Madhya Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Mandvi', 'INMDV1', 'SEA', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Mandwa', 'INMNW1', 'SEA', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Mangalore', 'INIXE1', 'SEA', 'Karnataka');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Mangalore Sea', 'INNML1', 'SEA', 'Karnataka');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Mangalore SEZ', 'INMAQ6', 'ICD', 'Karnataka');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Mangrol', 'INMGR1', 'SEA', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Manikarchar', 'INMKC8', 'ROAD', 'Assam');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Manori', 'INMNR1', 'SEA', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Manu', 'INMNU8', 'ROAD', 'Assam');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Margao', 'INMDG6', 'ICD', 'Goa');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Maroli', 'INMLI1', 'SEA', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Masulipatnam', 'INMAP1', 'SEA', 'Andhra Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Mayabandar', 'INMYB1', 'SEA', 'Andaman and Nicobar');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Meadows', 'INMDW1', 'SEA', 'Andaman and Nicobar');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('MEBPSEZ/Bangalore', 'INHEM6', 'ICD', 'Karnataka');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Medak (APPIIC Ltd.-SEZ)', 'INMDE6', 'ICD', 'Andhra Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Meerut', 'INMTC6', 'ICD', 'Uttar Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('METRO SEZ/GURGAON', 'INFBM6', 'ICD', 'HARYANA');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Metwad', 'INMTW1', 'SEA', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('MIDPL SEZ/GURGAON', 'INGMI6', 'ICD', 'HARYANA');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('MIDPvt.Ltd. SEZ/GURGAON', 'INGID6', 'ICD', 'HARYANA');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('MIKADO SEZ/GURGAON', 'INMKD6', 'ICD', 'HARYANA');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('MILESTONEBUILDCONSEZ/Bangalore', 'INYNM6', 'ICD', 'Karnataka');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Minicoy Island', 'INMCI1', 'SEA', 'Kerala');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('MIPPL SEZ/GURGAON', 'INGGM6', 'ICD', 'HARYANA');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Miraj', 'INMRJ6', 'ICD', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('MITTAL SEZ/PANIPAT', 'INPNI6', 'ICD', 'HARYANA');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Mora', 'INMRA1', 'SEA', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Moradabad (EPZ/SEZ)', 'INMBC6', 'ICD', 'Uttar Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Moreh', 'INMRE8', 'ROAD', 'Manipur');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('MOSERBAER SEZ/NOIDA', 'INDEM6', 'ICD', 'UTTAR PRADESH');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('MRPL-SEZ/AHMEDABAD', 'INADM6', 'ICD', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('MTDCCL SEZ/PUNE', 'INPMT6', 'ICD', 'MAHARASHTRA');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Muldwarka', 'INMDK1', 'SEA', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Multi Service-SEZ/Ulwe(Distt. Raigad)', 'INBAM6', 'ICD', 'Maharasthra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('MultiService-SEZ /Dronagiri(Distt.Navi Mumbai)', 'INBAP6', 'ICD', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('MultiService-SEZ/Kalamboli(Distt. Navi Mumbai)', 'INKLM6', 'ICD', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Mulund', 'INMUL6', 'ICD', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Mumbai (EPZ/SEZ)', 'INBOM6', 'ICD', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Mumbai -DP-I', 'INGRR6', 'ICD', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Mumbai DP-II', 'INGRD6', 'ICD', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Munabao Railway Station', 'INMNB2', 'RAILWAY', 'Rajasthan');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Mundra', 'INMUN1', 'SEA', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Mundra Port SEZ', 'INAJM6', 'ICD', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Murad', 'INMRD1', 'SEA', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('MWCL SEZ/JAIPUR', 'INJPC6', 'ICD', 'RAJASTHAN');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Nagapattinam', 'INNPT1', 'SEA', 'Tamilnadu');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Nagpur', 'INNGP6', 'ICD', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Nagpur', 'INNAG4', 'AIR', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Namkhana', 'INNKN8', 'ROAD', 'West Bengal');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Nampong', 'INNPG8', 'ROAD', 'Arunachal Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Nancowrie', 'INNAN1', 'SEA', 'Andaman and Nicobar Isl.');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Nandgaon', 'INNDG1', 'SEA', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Nanguneri (AMRL International Tech City Ltd.-SEZ)', 'INNNN6', 'ICD', 'Tamilnadu');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Nashik-Janori ACC', 'INJNR4', 'AIR', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Nashik-Janori ICD', 'INJNR6', 'ICD', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Nasik', 'INNSK6', 'ICD', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Navabunder', 'INNVB1', 'SEA', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Navaspur', 'INNVP1', 'SEA', 'Andhra Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Navi Mumbai SEZ Pvt Ltd', 'INKLN6', 'ICD', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Navlakhi', 'INNAV1', 'SEA', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Neamati steamer Ghat', 'INNMT8', 'ROAD', 'Assam');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Neendakara', 'INNEE1', 'SEA', 'Kerala');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Nellore (ASDI Pvt. Ltd.-SEZ)', 'INSPE6', 'ICD', 'Andhra Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Nepalgunj Road', 'INNGR8', 'ROAD', 'Uttar Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Newapur', 'INNWP1', 'SEA', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Nhava Sheva Sea', 'INNSA1', 'SEA', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('NIIT SEZ/NOIDA', 'INDEN6', 'ICD', 'UTTAR PRADESH');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Nivti', 'INNVT1', 'SEA', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Noida (EPZ/SEZ)', 'INNDA6', 'ICD', 'Uttar Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Noida-Dadri (ICD)', 'INDER6', 'ICD', 'Uttar Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Okha', 'INOKH1', 'SEA', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Old Mundra', 'INOMU1', 'SEA', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Old Raghna Bazar', 'INRGB8', 'ROAD', 'Tripura');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Onjal', 'INONJ1', 'SEA', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('OPTOINFRASEZ/HASSAN', 'INHAO6', 'ICD', 'Karnataka');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('OPTOINFRASEZ/MYSORE', 'INMYO6', 'ICD', 'Karnataka');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('ORIENT/ SEZ/GURGAON', 'INGGC6', 'ICD', 'HARYANA');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('ORIENTCRAFT SEZ/GURGAON', 'INGGO6', 'ICD', 'HARYANA');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('OSE SEZ/NOIDA', 'INNGO6', 'ICD', 'UTTAR PRADESH');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Padubidri Minor Port', 'INPDD1', 'SEA', 'Karnataka');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Pakwara (Moradabad)', 'INMBD6', 'ICD', 'Uttar Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Palshet', 'INPSH1', 'SEA', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Pamban', 'INPMB1', 'SEA', 'Tamilnadu');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Pan itanki (Naxabari)', 'INPNT8', 'ROAD', 'West Bengal');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Panaji Port', 'INPAN1', 'SEA', 'Goa');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Panjim', 'INPNJ1', 'SEA', 'Goa');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Panvel', 'INPVL6', 'ICD', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Paradeep', 'INPRT1', 'SEA', 'Orissa');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Patli ICD', 'INPTL6', 'ICD', 'Haryana');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Patna', 'INPAT4', 'AIR', 'Bihar');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Patparganj', 'INPPG6', 'ICD', 'Delhi');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Patrapole', 'INPTP8', 'ROAD', 'West Bengal');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Pellet Plant Jetty at Shiroda', 'INPPJ1', 'SEA', 'Goa');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('PERFECT SEZ/NOIDA', 'INPSN6', 'ICD', 'UTTAR PRADESH');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('PERPETUAL SEZ/FARIDABAD', 'INFBP6', 'ICD', 'HARYANA');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Petrapole Road', 'INPTP8', 'ROAD', 'West Bengal');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Phulbari', 'INPHB8', 'ROAD', 'Assam');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Pimpri', 'INPMP6', 'ICD', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Pindhara', 'INPIN1', 'SEA', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Pipavav(Victor) Port', 'INPAV1', 'SEA', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Pithampur', 'ININD6', 'ICD', 'Madhya Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Piyala/Ballabhgarh ICD', 'INBFR6', 'ICD', 'Haryana');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Pondicherry', 'INPNY1', 'SEA', 'Pondicheri');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Pondicherry ICD', 'INPNY6', 'ICD', 'Pondicherry');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Ponnani', 'INPNN1', 'SEA', 'Kerala');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Porbandar', 'INPBD1', 'SEA', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Port Blair', 'INIXZ1', 'SEA', 'Andaman and Nicobar Isl.');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Port Blair', 'INIXZ4', 'AIR', 'Andaman and Nicobar Isl.');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Portonovo', 'INPTN1', 'SEA', 'Tamilnadu');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('PRITECHPARKSEZ/Bangalore', 'INBCP6', 'ICD', 'Karnataka');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('PROGRESSIVE SEZ/GURGAON', 'INGPB6', 'ICD', 'HARYANA');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Pune', 'INPNQ4', 'AIR', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Pune-Talegoan ICD', 'INTLG6', 'ICD', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Purangad', 'INPRG1', 'SEA', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Puthuvypeen SEZ / Ernakulam', 'INERP6', 'ICD', 'Kerala');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('QUARKCITY SEZ/MOHALI', 'INCDQ6', 'ICD', 'PUNJAB');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Quest SEZ Belgaum', 'INBGQ6', 'ICD', 'Karnataka');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Raddipalem', 'INRPL6', 'ICD', 'Andhra Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Radhikapur Railway Station', 'INRDP2', 'RAILWAY', 'West Bengal');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('RAHEJA SEZ/GURGAON', 'INGRS6', 'ICD', 'HARYANA');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Raipur', 'INRAI6', 'ICD', 'Chhattisgarh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Rajakkamangalam', 'INRKG1', 'SEA', 'Kerala');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Rajasansi(Amritsar)', 'INATQ4', 'AIR', 'Punjab');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Rajkot', 'INRAJ6', 'ICD', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Rajpara', 'INRJP1', 'SEA', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Rajpuri', 'INRJR1', 'SEA', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Rameshwaram', 'INRWR1', 'SEA', 'Tamilnadu');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Rameshwaram', 'INRAM1', 'SEA', 'Tamilnadu');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Ranaghat Railway Station', 'INRNG2', 'RAILWAY', 'West Bengal');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('RANBAXY SEZ/MOHALI', 'INCDR6', 'ICD', 'PUNJAB');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Ranghat Bay', 'INRGT1', 'SEA', 'Andaman and Nicobar');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Ranpar', 'INRNR1', 'SEA', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Rassi/SEZ/Anantpur', 'INHUR6', 'ICD', 'Andhra Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('RATLAM', 'INRTM6', 'ICD', 'Madhya Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Ratnagiri', 'INRTC1', 'SEA', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Raxaul', 'INRXL8', 'ROAD', 'Bihar');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('RCIPL SEZ/NOIDA', 'INDRC6', 'ICD', 'UTTAR PRADESH');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Reddy r/SEZ/Srikakulam', 'INVZR6', 'ICD', 'Andhra Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Redi', 'INRED1', 'SEA', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Reliance SEZ/ Jamnagar', 'INLPJ6', 'ICD', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('RELIANCE SEZ/GURGAON', 'INGRN6', 'ICD', 'HARYANA');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Revdanda', 'INRVD1', 'SEA', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Rewari', 'INREA6', 'ICD', 'Haryana');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Rexaul', 'INRXL8', 'ROAD', 'Bihar');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('RLL-SEZ/Medak', 'INKOH6', 'ICD', 'Andhra Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('RNBIPL SEZ/BIKANER', 'INBRI6', 'ICD', 'RAJASTHAN');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('RPCIPL SEZ/Visakhapatnam', 'INAKR6', 'ICD', 'Andhra Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Ryngku', 'INRGU8', 'ROAD', 'Meghalaya');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Sabarmati ICD', 'INSBI6', 'ICD', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Sabroom', 'INSAB8', 'ROAD', 'Tripura');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Sachin(Surat)', 'INSAC6', 'ICD', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Saharanpur', 'INSRE6', 'ICD', 'Uttar Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Salaya', 'INSAL1', 'SEA', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Salem', 'INSXT6', 'ICD', 'Tamilnadu');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Salt Lake (EPZ/SEZ)', 'INSLT6', 'ICD', 'West Bengal');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('SANTA-SEZ/Vill-Muppireddipally Distt.-Medak', 'INDBS6', 'ICD', 'Andhra Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('SAP-SEZ SURAT', 'INSCH6', 'ICD', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Satpati', 'INSTP1', 'SEA', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('SBPL SEZ/GURGAON', 'INGGB6', 'ICD', 'HARYANA');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('SBPP - SEZ,Hadapsar,Pune', 'INPNQ6', 'ICD', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('SCPL SEZ/MULUND', 'INMUC6', 'ICD', 'MAHARASHTRA');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('SEAVIEW SEZ/NOIDA', 'INDES6', 'ICD', 'UTTAR PRADESH');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('SELECTO SEZ/FARIDABAD', 'INFBS6', 'ICD', 'HARYANA');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('SGS SEZ/Ernakulam', 'INKLG6', 'ICD', 'Kerala');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Shella Bazar', 'INSBZ8', 'ROAD', 'Meghalaya');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('SHENDRE INDUSTRIAL AREA, DISTRICT AURANGABAD', 'INAWW6', 'ICD', 'MAHARASHTRA');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('SHENDRE,INDUSTRIAL AREA,DISTRICT AURANGABAD', 'INAWM6', 'ICD', 'MAHARASHTRA');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Shriwardhan', 'INSWD1', 'SEA', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Sikka', 'INSIK1', 'SEA', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Silcher R.M.S. Office', 'INSLR2', 'RAILWAY', 'Assam');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Silcher Steamerghat', 'INSLR8', 'ROAD', 'Assam');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Simor', 'INSMR1', 'SEA', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Sinbhour', 'INSBH1', 'SEA', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Sinbhour Port', 'INSHP1', 'SEA', 'Daman and Diu');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Singabad Railway Station', 'INSNG2', 'RAILWAY', 'West Bengal');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Singnallur', 'INSLL6', 'ICD', 'Tamilnadu');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('SIPL SEZ/PUNE', 'INPSI6', 'ICD', 'MAHARASHTRA');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Sitai', 'INSTI8', 'ROAD', 'West Bengal');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('SMARTCITYSEZ/Ernakulam', 'INKLS6', 'ICD', 'Kerala');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('SMRTPL SEZ/NOIDA', 'INDSM6', 'ICD', 'UTTAR PRADESH');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('SOMANI SEZ/BHIWADI', 'INAWS6', 'ICD', 'RAJASTHAN');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Sonabarsa', 'INSNB8', 'ROAD', 'Bihar');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Sonauli', 'INSNL8', 'ROAD', 'Uttar Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('SREHPL-SEZ/GANDHINAGAR', 'INGNS6', 'ICD', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('SRI CITY PVT. LTD-SEZ/Satyavedu and Vardayyapalem', 'INTAS6', 'ICD', 'Andhra Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Srimantapur', 'INSMP8', 'ROAD', 'Tripura');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Srinagar', 'INSXR4', 'AIR', 'Jammu & Kashmir');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Sriperumbudur (FTIL-SEZ)', 'INCJF6', 'ICD', 'Tamilnadu');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Sriperumbudur (NIPL-SEZ)', 'INCJN6', 'ICD', 'Tamilnadu');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Sriperumbudur (SIPCOT Hi-Tech-SEZ)', 'INCJS6', 'ICD', 'Tamilnadu');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Sriperumbudur (SIPCOT Hi-Tech-SEZ-Oragadam)', 'INCJO6', 'ICD', 'Tamilnadu');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Stargaze/Rangareddy/SEZ', 'INFM6', 'ICD', 'Andhra Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Sukhia Pokhari', 'INSKP8', 'ROAD', 'West Bengal');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('SUNCITY SEZ/GURGAON', 'INGGS6', 'ICD', 'HARYANA');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Sundew/SEZ/Rangareddy', 'INLPI6', 'ICD', 'Andhra Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('SUNWISE SEZ/GURGAON', 'INGGP6', 'ICD', 'HARYANA');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Surasani - Yanam', 'INSRV1', 'SEA', 'Andhra Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Surat (EPZ/SEZ)', 'INSTV6', 'ICD', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Sutarkandi', 'INSTR8', 'ROAD', 'Assam');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('SVRL SEZ/ RAIGAD', 'INPNS6', 'ICD', 'MAHARASHTRA');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Synefra-SEZ/Udupi', 'INUDI6', 'ICD', 'Karnataka');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('T ankari', 'INTNK1', 'SEA', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('T.T. Shed (Kidcerpore)', 'INTTS8', 'ROAD', 'West Bengal');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Tadri', 'INTRI1', 'SEA', 'Karnataka');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Talaja', 'INTJA1', 'SEA', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Talpona', 'INTPN1', 'SEA', 'Goa');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Tarapur', 'INTRP1', 'SEA', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('TCS-SEZ/GANDHINAGAR', 'INGNT6', 'ICD', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Tellichery', 'INTEL1', 'SEA', 'Kerala');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Tezpur Steamerghat', 'INTJP8', 'ROAD', 'Assam');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Thal', 'INTHL1', 'SEA', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Thana', 'INTNA1', 'SEA', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Thar Dry Port - Jodhpur ICD', 'INTHA6', 'ICD', 'Rajasthan');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Thar Dry Port ICD/Ahmedabad', 'INSAU6', 'ICD', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Thirruvallur (FLLPL-SEZ)', 'INGDP6', 'ICD', 'Tamilnadu');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Thopputhurai', 'INTPH1', 'SEA', 'Tamilnadu');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Thrissur ICD', 'INTCR6', 'ICD', 'Kerala');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Tikonia', 'INTKN8', 'ROAD', 'Uttar Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Tiruchirapalli', 'INTRZ4', 'AIR', 'Tamilnadu');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Tirukkadayyur', 'INTYR1', 'SEA', 'Tamilnadu');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Tirunelveli (SIPCOT-Gangaikodan-SEZ)', 'INTEN6', 'ICD', 'Tamilnadu');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Tiruppur - Chettipalayam CFS', 'INCHE6', 'ICD', 'Tamil Nadu');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Tiruppur - Thottiplayam ICD', 'INTHO6', 'ICD', 'Tamilnadu');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Tirupur', 'INTUP6', 'ICD', 'Tamilnadu');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Tiruvallur ICD', 'INTRL6', 'ICD', 'Tamilnadu');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Tiruvallur-ILP ICD', 'INILP6', 'ICD', 'Tamilnadu');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Tondi', 'INTND1', 'SEA', 'Tamilnadu');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Trivendrun Air Cargo', 'INTRV4', 'AIR', 'Kerala');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Trombay', 'INTMP1', 'SEA', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Tudiyalur - Coimbatore ICD', 'INTDE6', 'ICD', 'Tamilnadu');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Tughlakabad', 'INTKD6', 'ICD', 'Delhi');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Tuna', 'INTUN1', 'SEA', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Tungi', 'INTNG8', 'ROAD', 'West Bengal');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Tuticorin (CCCL Infrasturcture Ltd.-SEZ)', 'INTNC6', 'ICD', 'Tamilnadu');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Tuticorin ICD', 'INTUT6', 'ICD', 'Tamilnadu');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Tuticorin Sea', 'INTUT1', 'SEA', 'Tamilnadu');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Udaipur', 'INUDZ6', 'ICD', 'Rajasthan');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('ULCCSSEZ/Kozhikode', 'INCLU6', 'ICD', 'Kerala');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Ultapani', 'INULP8', 'ROAD', 'Assam');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Ulwa', 'INULW1', 'SEA', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Umarsadi', 'INUMR1', 'SEA', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Umbergoan', 'INUMB1', 'SEA', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('UNITECH HI-TECH SEZ/NOIDA', 'INDET6', 'ICD', 'UTTAR PRADESH');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('UNITECH REALITY SEZ/GURGAON', 'INGGU6', 'ICD', 'HARYANA');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('UNITECHINFRA SEZ/NOIDA', 'INDEU6', 'ICD', 'UTTAR PRADESH');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Uttan', 'INUTN1', 'SEA', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Vadarevu', 'INVRU1', 'SEA', 'Andhra Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Vadinar', 'INVAD1', 'SEA', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Vadodara - Chhani', 'INCHN6', 'ICD', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Valinokkam', 'INVKM1', 'SEA', 'Tamilnadu');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Vallarpadom SEZ / Ernakulam', 'INERV6', 'ICD', 'Kerala');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Valvada ICD', 'INVAL6', 'ICD', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Vansi-Borsi', 'INVSI1', 'SEA', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Vapi', 'INVPI6', 'ICD', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Varanasi', 'INBSB6', 'ICD', 'Uttar Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Varanasi', 'INVNS4', 'AIR', 'Uttar Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Varavda', 'INVRD1', 'SEA', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Varsava', 'INVSV1', 'SEA', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('VATIKA SEZ/JAIPUR', 'INJPV6', 'ICD', 'RAJASTHAN');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Vazhinjam', 'INVZJ1', 'SEA', 'Kerala');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('VBTL-SEZ/Medak', 'INMOV6', 'ICD', 'Andhra Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Vellore (CHEYYAR-SEZ)', 'INVTC6', 'ICD', 'Tamilnadu');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Vengurla', 'INVNG1', 'SEA', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Veppalodai', 'INVEP1', 'SEA', 'Tamilnadu');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Veraval', 'INVVA1', 'SEA', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Vijaydurg', 'INVYD1', 'SEA', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('VILLAGE KESURDE,DISTRICT-SATARA', 'INSTU6', 'ICD', 'MAHARASHTRA');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('VILLAGE KRUSHNOOR,TALUKA-NAIGAON,DISTRICT NANDED', 'INDID6', 'ICD', 'MAHARASHTRA');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Village Namgaya Shipkila', 'INNGS8', 'ROAD', 'Himachal Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('VILLAGE SURVADU AND NANDAL,PHALTAN,DISTRICT-SATARA', 'INSTM6', 'ICD', 'MAHARASHTRA');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('VILLAGE, PHURSUNGI,TALUKA-HAVELI,DISTRICT- PUNE', 'INPNU6', 'ICD', 'MAHARASHTRA');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('VILLAGE-KALAMBOLI,NAVI MUMBAI,DISTRICT RAIGAD', 'INKLE6', 'ICD', 'MAHARASHTRA');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Visakhapatnam (EPZ/SEZ)', 'INVTZ6', 'ICD', 'Andhra Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Vishakapatnam', 'INVTZ4', 'AIR', 'Andhra Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Vizac Sea', 'INVTZ1', 'SEA', 'Andhra Pradesh');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Waluj(Aurangabad)', 'INWAL6', 'ICD', 'Maharashtra');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('Welspun Anjar SEZ / Anjar', 'INAJE6', 'ICD', 'Gujarat');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('WIPRO SEZ/NOIDA', 'INDEW6', 'ICD', 'UTTAR PRADESH');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('WIPROELECCITYSEZ/Bangalore', 'INSBW6', 'ICD', 'Karnataka');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('WIPROSARJAPURSEZ/Bangalore', 'INCRW6', 'ICD', 'Karnataka');
INSERT INTO 'main'.'TBL_PORT_CODE' ('Name', 'Code', 'Mode', 'State') VALUES ('ZIPL-SEZ AHMEDABAD', 'INZIP6', 'ICD', 'Gujarat');

"
                    cmd = New SQLiteCommand(q, cn)
                    cmd.ExecuteNonQuery()

                End If
                cn.Close()
                Return True
            Catch ex As Exception
                MsgBox(ex.Message)
                cn.Close()
                Return False
            End Try
        End If
    End Function
    Public Function cfg_update_1037() As Boolean
        Try
            Dim cn As New SQLiteConnection
            If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                cmd = New SQLiteCommand("UPDATE TBL_VC SET Effect_Ledger = 'Yes' where Type = 'Head' and (Voucher_Type = 'Sales' or Voucher_Type = 'Purchase')", cn)
                cmd.ExecuteNonQuery()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
        Return True
    End Function
End Module
