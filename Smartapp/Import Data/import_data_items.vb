Imports System.ComponentModel
Imports System.Data.SQLite
Public Class import_data_items
    Dim From_ID As String
    Dim Path_End As String
    Dim VC_Type_ As String
    Private Sub import_data_items_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text

        VC_Type_ = "Import"

        BG_frm.HADE_TXT.Text = "Stock Item Import"
        BG_frm.TYP_TXT.Text = VC_Type_

        Add_Hander_Remove_Handel(True)

    End Sub

    Private Sub import_data_Item_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.TYP_TXT.Text = VC_Type_

        BG_frm.HADE_TXT.Text = "Stock Item Import"
        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text


        Button_Manage()
    End Sub

    Private Sub import_data_Item_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        NOT_Clear()
        If e.KeyCode = Keys.Escape Then
            If Msg_Exit_YN("Ledger Import") = DialogResult.Yes Then
                Me.Dispose()
            End If
        End If
    End Sub

    Private Sub import_data_Item_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End
        Ledger_Branch_Balance.Dispose()
        Add_Hander_Remove_Handel(False)
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
        If BG_frm.From_ID = From_ID Then
            Me.Dispose()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Excel_Import_dialoag.Load_(Me,
                                   "Name",
                                   "Alias",
                                   "Barcode",
                                   "Under Group",
                                   "Unit",
                                   "GST Applicable",
                                   "TAX Type",
                                   "GST Rate",
                                   "Type of Supply",
                                   "HSN Code",
                                   "MRP",
                                   "Opning Stock",
                                   "Purchase Rate",
                                   "Sales Rate"
                                   )
    End Sub
    Dim Pending_ As Integer = 0
    Dim Success_ As Integer = 0
    Dim Reject_ As Integer = 0
    Public Function Fill_excel()
        Grid1.Rows.Clear()

        Pending_ = 0
        Success_ = 0
        Reject_ = 0

        Label6.Text = Pending_
        Label7.Text = Success_
        Label8.Text = Reject_

        Dim I_1 As Integer
        Dim I_2 As Integer
        Dim I_3 As Integer
        Dim I_4 As Integer
        Dim I_5 As Integer
        Dim I_6 As Integer
        Dim I_7 As Integer
        Dim I_8 As Integer
        Dim I_9 As Integer
        Dim I_10 As Integer
        Dim I_11 As Integer
        Dim I_12 As Integer
        Dim I_13 As Integer
        Dim I_14 As Integer

        With Excel_Import_dialoag
            I_1 = .Find_Combobox_TXT(1).SelectedIndex
            I_2 = .Find_Combobox_TXT(2).SelectedIndex
            I_3 = .Find_Combobox_TXT(3).SelectedIndex
            I_4 = .Find_Combobox_TXT(4).SelectedIndex
            I_5 = .Find_Combobox_TXT(5).SelectedIndex
            I_6 = .Find_Combobox_TXT(6).SelectedIndex
            I_7 = .Find_Combobox_TXT(7).SelectedIndex
            I_8 = .Find_Combobox_TXT(8).SelectedIndex
            I_9 = .Find_Combobox_TXT(9).SelectedIndex
            I_10 = .Find_Combobox_TXT(10).SelectedIndex
            I_11 = .Find_Combobox_TXT(11).SelectedIndex
            I_12 = .Find_Combobox_TXT(12).SelectedIndex
            I_13 = .Find_Combobox_TXT(13).SelectedIndex
            I_14 = .Find_Combobox_TXT(14).SelectedIndex

            For Each ro As DataGridViewRow In .Grid1.Rows
                Using r As DataGridViewRow = ro
                    Dim S1 As String = Not_Select_(ro, I_1)
                    Dim S2 As String = Not_Select_(ro, I_2)
                    Dim S3 As String = Not_Select_(ro, I_3)
                    Dim S4 As String = Not_Select_(ro, I_4)
                    Dim S5 As String = Not_Select_(ro, I_5)
                    Dim S6 As String = Not_Select_(ro, I_6)
                    Dim S7 As String = Not_Select_(ro, I_7)
                    Dim S8 As String = Not_Select_(ro, I_8)
                    Dim S9 As String = Not_Select_(ro, I_9)
                    Dim S10 As String = Not_Select_(ro, I_10)
                    Dim S11 As String = Not_Select_(ro, I_11)
                    Dim S12 As String = Not_Select_(ro, I_12)
                    Dim S13 As String = Not_Select_(ro, I_13)
                    Dim S14 As String = Not_Select_(ro, I_14)
                    Dim co As Integer = Grid1.Rows.Count + 1

                    Grid1.Rows.Add(co, S1, S2, S3, S4, S5, S6, S7, S8, S9, S10, S11, S12, S13, S14, "Pending")
                End Using
            Next
        End With

        If Grid1.Rows.Count <> 0 Then
            Button2.Visible = True
            Pending_ = Grid1.Rows.Count - 0
            Label6.Text = Pending_
            ProgressBag_Custom1.Maximum = Pending_
        Else
            'Button2.Visible = False
        End If
    End Function
    Private Function Not_Select_(ro As DataGridViewRow, str As Integer)
        If str <> -1 Then
            Return ro.Cells(str).Value.ToString
        Else
            Return ""
        End If
    End Function

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub Label6_TextChanged(sender As Object, e As EventArgs) Handles Label6.TextChanged, Label7.TextChanged, Label8.TextChanged
        Label10.Text = Val(Pending_) + Val(Success_) + Val(Reject_)
    End Sub

    Private Sub Grid1_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles Grid1.RowPrePaint
        Dim ro As DataGridViewRow = Grid1.Rows(e.RowIndex)
        Dim c As Integer = Grid1.Columns.Count - 1
        If ro.Cells(c).Value = "Pending" Then
            ro.DefaultCellStyle.ForeColor = Color.Black
        ElseIf ro.Cells(c).Value = "Success" Then
            ro.DefaultCellStyle.ForeColor = Color.Green
        Else
            ro.DefaultCellStyle.ForeColor = Color.Red
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Msg_Custom_YN(NOT_Location.Bottom_Right, Color.Black, My.Resources.import_animation_icn, Dialoag_Button.Yes_No, "Question", "Import Data", "Are you sure<nl>import data") = DialogResult.Yes Then
            Panel5.Visible = True
            'Button2.Visible = False
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub
    Dim Head_ As String
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            For Each ro As DataGridViewRow In Grid1.Rows
                Dim name_ As String = ro.Cells(1).Value.ToString.Trim
                Dim alias_ As String = ro.Cells(2).Value.ToString.Trim
                Dim Barcode_ As String = ro.Cells(3).Value.ToString.Trim
                Dim under_ As String = ro.Cells(4).Value.ToString.Trim
                Dim unit_ As String = ro.Cells(5).Value.ToString.Trim
                Dim GST_YN_ As String = ro.Cells(6).Value.ToString.Trim
                Dim TAX_Type As String = ro.Cells(7).Value.ToString.Trim
                Dim GST_Rate As String = ro.Cells(8).Value.ToString.Trim
                Dim Type_of_Supplay As String = ro.Cells(9).Value.ToString.Trim

                Head_ = name_
                BackgroundWorker1.ReportProgress(ro.Index)


                Dim alis_filter As String
                If alias_ = Nothing Then
                    alis_filter = ""
                Else
                    alis_filter = $"or it.Alias = '{alias_}' COLLATE NOCASE or it.Alias = '{name_}' COLLATE NOCASE"
                End If

                cmd = New SQLiteCommand($"Select count(it.id) as Duplicate,
(Select count(ag.id) From TBL_Stock_Group ag where ag.name = '{under_}' COLLATE NOCASE and ag.Visible = 'Approval') as Under_YN,
(Select count(u.id) From TBL_Inventory_Unit u where u.Symbol = '{unit_}' COLLATE NOCASE and u.Visible = 'Approval') as Unit_YN,
(Select count(it1.id) From TBL_Stock_Item it1 where it1.Barcode = '{Barcode_}' COLLATE NOCASE and it1.Visible = 'Approval') as Barcode_YN
From TBL_Stock_Item it 
where (it.Name = '{name_}' COLLATE NOCASE or it.Name = '{alias_}' COLLATE NOCASE {alis_filter}) and it.Visible = 'Approval'", cn)

                Dim r As SQLiteDataReader
                r = cmd.ExecuteReader
                Dim Duplicate As Boolean = False
                Dim Barcode_Dublicat As Boolean = False
                Dim Unit_Duplicat As Boolean = False
                Dim Under_YN As Boolean = False
                Dim TAX_Type_YN As Boolean = False


                r.Read()
                If r("Duplicate").ToString = "0" Then
                    Duplicate = True
                Else
                    Duplicate = False
                End If
                If r("Under_YN").ToString = "0" Then
                    If under_.ToLower = "primary" Or under_.Length = 0 Or CheckBox1.Checked = True Then
                        Under_YN = True
                    Else
                        Under_YN = False
                    End If
                Else
                    Under_YN = True
                End If
                If r("Unit_YN").ToString = "0" Then
                    If unit_.Length = 0 Then
                        Unit_Duplicat = True
                    Else
                        Unit_Duplicat = False
                    End If
                Else
                    Unit_Duplicat = True
                End If

                If r("Barcode_YN").ToString = "0" Then
                    Barcode_Dublicat = True
                Else
                    If Barcode_.Length = 0 Then
                        Barcode_Dublicat = True
                    Else
                        Barcode_Dublicat = False
                    End If
                End If

                If TAX_Type.Length = 0 Or TAX_Type = "Exempt" Or TAX_Type = "Nil Rated" Or TAX_Type = "Non-GST" Or TAX_Type = "Taxable" Then
                    TAX_Type_YN = True
                Else
                    TAX_Type_YN = False
                End If

                Dim IsInstall As Boolean = False

                If name_ <> Nothing Or under_ <> Nothing Then
                    If Duplicate = True Then
                        If Under_YN = True Then
                            If Barcode_Dublicat = True Then
                                If Unit_Duplicat = True Then
                                    If TAX_Type_YN = True Then
                                        IsInstall = True
                                        Success_ += 1
                                    Else
                                        ro.Cells(Grid1.Columns.Count - 1).Value = "Taxability Type is Not Valid"
                                        Reject_ += 1
                                    End If
                                Else
                                    ro.Cells(Grid1.Columns.Count - 1).Value = "Unit Not Found"
                                    Reject_ += 1
                                End If
                            Else
                                ro.Cells(Grid1.Columns.Count - 1).Value = "Duplicate Barcode"
                                Reject_ += 1
                            End If
                        Else
                            ro.Cells(Grid1.Columns.Count - 1).Value = "Under Group Not Found"
                            Reject_ += 1
                        End If
                    Else
                        ro.Cells(Grid1.Columns.Count - 1).Value = "Duplicate Name or Alias"
                        Reject_ += 1
                    End If
                Else
                    ro.Cells(Grid1.Columns.Count - 1).Value = "Name or Under is not allow blank"
                    Reject_ += 1
                End If
                r.Close()

                If IsInstall = True Then
                    If Insurt_Data(cn, ro) = True Then
                        ro.Cells(Grid1.Columns.Count - 1).Value = "Success"
                    End If
                End If
            Next

            If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                'BG_frm.Ledger_BS.DataSource = Nothing
                'BG_frm.Ledger_BS.DataSource = Fill_Ledger(cn)

                'BG_frm.Branch_BS.DataSource = Nothing
                'BG_frm.Branch_BS.DataSource = Fill_Branch(cn)
            End If
        End If

    End Sub
    Private Function Insurt_Data(cn As SQLiteConnection, ro As DataGridViewRow) As Boolean
        Dim Group_ID As String = Group_(cn, ro.Cells(4).Value.ToString)
        Dim Unit_ID As String = Unit_(cn, ro.Cells(5).Value.ToString)

        Try
            cmd = New SQLiteCommand("INSERT INTO TBL_Stock_Item (Name,Alias,[Under],Unit,HSN_Code,GST_Applicable,Tax_Type,TAX_Value,GST_Type,MRP,Barcode,Purchase_Rate,Sales_Rate,Costing_Value_Type,Market_Value_Type,Company,Visible,[User],Date_install,PC) VALUES (@Name,@Alias,@Under,@Unit,@HSN_Code,@GST_Applicable,@Tax_Type,@TAX_Value,@GST_Type,@MRP,@Barcode,@Purchase_Rate,@Sales_Rate,@Costing_Value_Type,@Market_Value_Type,@Company,@Visible, @User,@Install_,@PC)", cn)
            With cmd.Parameters
                .AddWithValue("@Name", ro.Cells(1).Value.ToString.Trim)
                .AddWithValue("@Alias", ro.Cells(2).Value.ToString.Trim)
                .AddWithValue("@Barcode", ro.Cells(3).Value.ToString.Trim)
                .AddWithValue("@Under", Group_ID)
                .AddWithValue("@Unit", Unit_ID)
                .AddWithValue("@GST_Applicable", ro.Cells(6).Value.ToString.Trim)
                .AddWithValue("@Tax_Type", ro.Cells(7).Value.ToString.Trim)
                .AddWithValue("@TAX_Value", ro.Cells(8).Value.ToString.Trim)
                .AddWithValue("@GST_Type", ro.Cells(9).Value.ToString.Trim)
                .AddWithValue("@HSN_Code", ro.Cells(10).Value.ToString.Trim)
                .AddWithValue("@MRP", ro.Cells(11).Value.ToString.Trim)

                .AddWithValue("@Purchase_Rate", nUmBeR_FORMATE(ro.Cells(13).Value.ToString.Trim))
                .AddWithValue("@Sales_Rate", nUmBeR_FORMATE(ro.Cells(14).Value.ToString.Trim))

                .AddWithValue("@Costing_Value_Type", "Basic Purchase Rate")
                .AddWithValue("@Market_Value_Type", "Basic Sales Rate")

                'Fix Data
                .AddWithValue("@Company", Company_ID_str.Trim)
                .AddWithValue("@Visible", "Approval".Trim)
                .AddWithValue("@User", LOGIN_ID.Trim)
                .AddWithValue("@PC", PC_ID.Trim)
                .AddWithValue("@Install_", CDate(DateTime.Now))
                cmd.ExecuteNonQuery()
            End With

            cmd = New SQLiteCommand("INSERT INTO TBL_Stock_Item_Opning_Stock (Item_ID,Branch_ID,Applicable,Stock) VALUES (@Item_ID,@Branch_ID,@Applicable,@Stock)", cn)
            cmd.Parameters.AddWithValue("@Item_ID", Find_Max_ID(Database_File.cre, "TBL_Stock_Item", "ID", "ID <> ''"))
            cmd.Parameters.AddWithValue("@Branch_ID", "0")
            cmd.Parameters.AddWithValue("@Applicable", "Yes")
            cmd.Parameters.AddWithValue("@Stock", Val(ro.Cells(12).Value.ToString))
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function
    Private Function Unit_(cn As SQLiteConnection, vl As String) As String
        Dim v As String = Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "ID", $"Symbol = '{vl}' COLLATE NOCASE")

        If v.ToString.Trim = Nothing And CheckBox2.Checked = True Then
            cmd = New SQLiteCommand($"INSERT INTO TBL_Inventory_Unit (Type,Symbol,Formal_Name,UQC,Decimal,Unit1,Conversion,Unit2,Head,Company,[User],Date_install,Visible,PC) VALUES ('Simple','{vl.Trim}','','','2','','','','Stock','{Company_ID_str}','{User_ID}','{CDate(DateTime.Now)}','Approval','{PC_ID.Trim}')", cn)
            cmd.ExecuteNonQuery()
            v = Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "ID", $"Symbol = '{vl}' COLLATE NOCASE")
        End If

        If v.Length = 0 Or v.ToLower = "primary" Then
            Return "0"
        Else
            Return v
        End If
    End Function
    Private Function Group_(cn As SQLiteConnection, vl As String) As String
        'Try
        If vl.ToLower = "primary" Or vl.Trim = Nothing Then
            Return "0"
        End If

        Dim v As String = Find_DT_Value(Database_File.cre, "TBL_Stock_Group", "ID", $"Name = '{vl}' COLLATE NOCASE")
        If v.ToString.Trim = Nothing Then
            cmd = New SQLiteCommand($"INSERT INTO TBL_Stock_Group (Name,Nickname,Head,Company,[User],Date_install,Visible,PC) VALUES ('{vl.Trim}', '','Stock','{Company_ID_str}','{User_ID}','{CDate(DateTime.Now)}','Approval','{PC_ID.Trim}')", cn)
            cmd.ExecuteNonQuery()
            v = Find_DT_Value(Database_File.cre, "TBL_Stock_Group", "ID", $"Name = '{vl}' COLLATE NOCASE")
        End If


        Return v
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

    End Function
    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        ProgressBag_Custom1.Run(e.ProgressPercentage)
        Label2.Text = Head_
        Pending_ = Pending_ - 1

        'Grid1.CurrentCell = Grid1.Rows(e.ProgressPercentage).Cells(0)

        Label6.Text = Pending_
        Label7.Text = Success_
        Label8.Text = Reject_


    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        'Button2.Visible = True
        Panel5.Visible = False

        Grid1.Refresh()
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

    Private Sub import_data_items_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
    End Sub
End Class