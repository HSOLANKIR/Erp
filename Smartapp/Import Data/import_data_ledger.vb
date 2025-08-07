Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Data.SQLite
Imports System.IO

Public Class import_data_ledger
    Dim From_ID As String
    Dim Path_End As String
    Dim VC_Type_ As String
    Private Sub import_data_ledger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text

        VC_Type_ = "Import"

        BG_frm.HADE_TXT.Text = "Account Ledger Import"
        BG_frm.TYP_TXT.Text = VC_Type_

        Add_Hander_Remove_Handel(True)
    End Sub

    Private Sub import_data_ledger_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.TYP_TXT.Text = VC_Type_

        BG_frm.HADE_TXT.Text = "Account Ledger Import"
        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text


        Button_Manage()
    End Sub

    Private Sub import_data_ledger_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        NOT_Clear()
        If e.KeyCode = Keys.Escape Then
            If Msg_Exit_YN("Ledger Import") = DialogResult.Yes Then
                Me.Dispose()
            End If
        End If
    End Sub

    Private Sub import_data_ledger_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
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
                                   "Under Group",
                                   "Phone", "Email",
                                   "Pincode",
                                   "State",
                                   "District",
                                   "Taluka",
                                   "City",
                                   "Address",
                                   "Opning Balance Cr",
                                   "Opning Balance Dr",
                                   "Credit Limit",
                                   "Discription",
                                   "Note",
                                   "GST Type",
                                   "GSTNo",
                                   "PANCardNo",
                                   "BankName",
                                   "AccountNo",
                                   "BankBranch",
                                   "IFSCCode")



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
        Dim I_15 As Integer
        Dim I_16 As Integer
        Dim I_17 As Integer
        Dim I_18 As Integer
        Dim I_19 As Integer
        Dim I_20 As Integer
        Dim I_21 As Integer
        Dim I_22 As Integer
        Dim I_23 As Integer

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
            I_15 = .Find_Combobox_TXT(15).SelectedIndex
            I_16 = .Find_Combobox_TXT(16).SelectedIndex
            I_17 = .Find_Combobox_TXT(17).SelectedIndex
            I_18 = .Find_Combobox_TXT(18).SelectedIndex
            I_19 = .Find_Combobox_TXT(19).SelectedIndex
            I_20 = .Find_Combobox_TXT(20).SelectedIndex
            I_21 = .Find_Combobox_TXT(21).SelectedIndex
            I_22 = .Find_Combobox_TXT(22).SelectedIndex
            I_23 = .Find_Combobox_TXT(23).SelectedIndex

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
                    Dim S11 = Not_Select_(ro, I_11)
                    Dim S12 As String = Not_Select_(ro, I_12)
                    Dim S13 As String = Not_Select_(ro, I_13)
                    Dim S14 As String = Not_Select_(ro, I_14)
                    Dim S15 As String = Not_Select_(ro, I_15)
                    Dim S16 As String = Not_Select_(ro, I_16)
                    Dim S17 As String = Not_Select_(ro, I_17)
                    Dim S18 As String = Not_Select_(ro, I_18)
                    Dim S19 As String = Not_Select_(ro, I_19)
                    Dim S20 As String = Not_Select_(ro, I_20)
                    Dim S21 As String = Not_Select_(ro, I_21)
                    Dim S22 As String = Not_Select_(ro, I_22)
                    Dim S23 As String = Not_Select_(ro, I_23)

                    Dim co As Integer = Grid1.Rows.Count + 1
                    Grid1.Rows.Add(co, S1, S2, S3, S4, S5, S6, S7, S8, S9, S10, S11, S12, S13, S14, S15, S16, S17, S18, S19, S20, S21, S22, S23, "Pending")
                End Using
            Next
        End With

        If Grid1.Rows.Count <> 0 Then
            Button2.Visible = True
            Pending_ = Grid1.Rows.Count - 0
            Label6.Text = Pending_
            ProgressBag_Custom1.Maximum = Pending_
        Else
            Button2.Visible = False
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
            Button2.Visible = False

            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub
    Dim Head_ As String
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            For Each ro As DataGridViewRow In Grid1.Rows
                Dim name_ As String = ro.Cells(1).Value.ToString
                Dim alias_ As String = ro.Cells(2).Value.ToString
                Dim under_ As String = ro.Cells(3).Value.ToString
                Dim ob_Cr_ As String = ro.Cells(12).Value.ToString
                Dim ob_Dr_ As String = ro.Cells(13).Value.ToString
                Head_ = name_
                BackgroundWorker1.ReportProgress(ro.Index)


                Dim alis_filter As String
                If alias_ = Nothing Then
                    alis_filter = ""
                Else
                    alis_filter = $"or ld.Alise = '{alias_}' COLLATE NOCASE or ld.Alise = '{name_}' COLLATE NOCASE"
                End If

                cmd = New SQLiteCommand($"Select count(ld.id) as Duplicate,(Select count(ag.id) From TBL_Acc_Group ag where ag.name = '{under_}' COLLATE NOCASE and ag.Visible = 'Approval') as Under_YN From TBL_Ledger ld 
where (ld.Name = '{name_}' COLLATE NOCASE or ld.Name = '{alias_}' COLLATE NOCASE {alis_filter}) and ld.Visible = 'Approval'", cn)

                Dim r As SQLiteDataReader
                r = cmd.ExecuteReader
                Dim Duplicate As Boolean = False
                Dim Under_YN As Boolean = False
                r.Read()
                If r("Duplicate").ToString = "0" Then
                    Duplicate = True
                Else
                    Duplicate = False
                End If
                If r("Under_YN").ToString = "0" Then
                    Under_YN = False
                Else
                    Under_YN = True
                End If

                Dim IsInstall As Boolean = False

                If name_ <> Nothing Or under_ <> Nothing Then
                    If Duplicate = True Then
                        If Under_YN = True Then
                            If (Val(ob_Cr_) <> 0 And Val(ob_Dr_) <> 0) Then
                                ro.Cells(Grid1.Columns.Count - 1).Value = "Opning Balance Error"
                                Reject_ += 1
                            Else
                                IsInstall = True
                                Success_ += 1
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
        cmd = New SQLiteCommand("INSERT INTO TBL_Ledger (Name,Alise,[Group],Phone,Email,Country,PinCode,State,Dis,Taluka,City,Address,OB_CR,OB_DR,Cradit,GST_Type,GSTNo,PANCardNo,BankName,AccountNo,IFSCCode,Company,Visible,Discription,Note,[User],Date_install,PC) VALUES (@Name, @Alise, @Group, @Phone, @Email,@Country, @PinCode, @State, @Dis,@Taluka, @City, @Address, @OB_CR, @OB_DR, @Cradit, @GST_Type,@GSTNo, @PANCardNo, @BankName, @AccountNo, @IFSCCode, @Company, @Visible, @Discription,@Note,@User,@Install_,@PC)", cn)
        Try
            With cmd.Parameters
                .AddWithValue("@Name", ro.Cells(1).Value.ToString)
                .AddWithValue("@Alise", ro.Cells(2).Value.ToString)
                .AddWithValue("@Group", Find_DT_Value(Database_File.cre, "TBL_Acc_Group", "ID", $"Name = '{ro.Cells(3).Value.ToString}'"))
                .AddWithValue("@Phone", ro.Cells(4).Value.ToString)
                .AddWithValue("@Email", ro.Cells(5).Value.ToString)
                .AddWithValue("@Country", "India")
                .AddWithValue("@PinCode", ro.Cells(6).Value.ToString)
                .AddWithValue("@State", ro.Cells(7).Value.ToString)
                .AddWithValue("@Dis", ro.Cells(8).Value.ToString)
                .AddWithValue("@Taluka", ro.Cells(9).Value.ToString)
                .AddWithValue("@City", ro.Cells(10).Value.ToString)
                .AddWithValue("@Address", ro.Cells(11).Value.ToString)


                .AddWithValue("@OB_CR", Val(ro.Cells(12).Value.ToString))
                .AddWithValue("@OB_DR", Val(ro.Cells(13).Value.ToString))



                .AddWithValue("@Cradit", Val(ro.Cells(14).Value.ToString))
                .AddWithValue("@GST_Type", ro.Cells(17).Value.ToString)
                .AddWithValue("@GSTNo", ro.Cells(18).Value.ToString)
                .AddWithValue("@PANCardNo", ro.Cells(19).Value.ToString)
                .AddWithValue("@BankName", ro.Cells(20).Value.ToString)
                .AddWithValue("@AccountNo", ro.Cells(21).Value.ToString)
                .AddWithValue("@Branch", ro.Cells(22).Value.ToString)
                .AddWithValue("@IFSCCode", ro.Cells(23).Value.ToString)
                .AddWithValue("@Company", Company_ID_str.Trim)
                .AddWithValue("@Visible", "Approval".Trim)
                .AddWithValue("@Discription", ro.Cells(15).Value.ToString)
                .AddWithValue("@Note", ro.Cells(16).Value.ToString)
                .AddWithValue("@User", LOGIN_ID.Trim)
                .AddWithValue("@PC", PC_ID.Trim)
                .AddWithValue("@Install_", CDate(DateTime.Now))
                cmd.ExecuteNonQuery()
            End With

            cmd = New SQLiteCommand("INSERT INTO TBL_Ledger_Opning_Balance (Ledger_ID,Branch_ID,Applicable,OB_Dr,OB_Cr) VALUES (@Ledger_ID,@Branch_ID,@Applicable,@OB_Dr,@OB_Cr)", cn)
            cmd.Parameters.AddWithValue("@Ledger_ID", Find_Max_ID(Database_File.cre, "TBL_Ledger", "ID", "ID <> ''"))
            cmd.Parameters.AddWithValue("@Branch_ID", "0")
            cmd.Parameters.AddWithValue("@Applicable", "Yes")
            cmd.Parameters.AddWithValue("@OB_Cr", Val(ro.Cells(12).Value.ToString))
            cmd.Parameters.AddWithValue("@OB_Dr", Val(ro.Cells(13).Value.ToString))
            cmd.ExecuteNonQuery()

            Return True
        Catch ex As Exception
            Return False
        End Try

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

    Private Sub import_data_ledger_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
    End Sub
End Class