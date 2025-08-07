Imports System.Data.SqlClient
Imports System.Data.SQLite
Imports System.IO
Imports Microsoft.Reporting.WinForms

Public Class Loan_sanction_frm
    Dim Path_End As String
    Dim VC_ID_ As String
    Dim VC_Type_ As String
    Dim ID_ As String

    Dim ds As New Print_dt
    Dim dt_print As New DataTable
    Private Sub Loan_sanction_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Path_End = BG_frm.BG_Path_TXT.Text
        ID_ = Link_Valu(0)
        VC_Type_ = Link_Valu(1)
        VC_ID_ = Link_Valu(2)

        BG_frm.HADE_TXT.Text = "Loan Sanction"
        BG_frm.TYP_TXT.Text = VC_Type_

        SanctionDate_txt.Text = Now.Date.ToString("dd-MM-yyyy")
        If VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close" Then
            Display_alt()
        End If
        Fill_()

        Button_Manage()

    End Sub
    Private Function Allow_thi_employee() As Boolean
        If BG_frm.HADE_TXT.Text = "Loan Sanction" = True Then

            Dim aadhaar As String
            Dim pan As String
            Dim Nominee As String
            Dim Name As String
            Dim ID As String

            Dim cn As New SQLiteConnection
            If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                cmd = New SQLiteCommand("Select * From TBL_Payroll_Employee where ID = '" & VC_ID_ & "' and Visible = 'Approval'", cn)
                Dim r As SQLiteDataReader
                r = cmd.ExecuteReader
                While r.Read
                    ID = r("ID").ToString
                    Name = r("Name").ToString
                    aadhaar = r("Aadhaar").ToString
                    pan = r("PAN").ToString
                    Nominee = r("Nominee").ToString
                End While

                If aadhaar.Trim = Nothing Then
                    Msg(NOT_Type.Warning, "Aadhaar Input Error", "Aadhaar number of '" & Name & "' is not available so this employee is not eligible for loan")
                    If Msg_Yn("Set Aadhaar No.", "Do you want to enter Aadhaar number from here?") = DialogResult.Yes Then
                        Me.Dispose()
                        Cell("Payroll Employee", "", "Alter", ID)
                        Frm_foCus()
                        Payroll_Employee_frm.Seatutory_YN.Text = "Yes"
                        Payroll_Employee_frm.Aadhaar_TXT.Focus()
                    Else
                        Me.Dispose()
                    End If
                    Return False
                End If

                If pan.Trim = Nothing Then
                    Msg(NOT_Type.Warning, "PAN No. Input Error", "PAN number of '" & Name & "' is not available so this employee is not eligible for loan")
                    If Msg_Yn("Set PAN No.", "Do you want to enter PAN number from here?") = DialogResult.Yes Then
                        Me.Dispose()
                        Cell("Payroll Employee", "", "Alter", ID)
                        Frm_foCus()
                        Payroll_Employee_frm.Seatutory_YN.Text = "Yes"
                        Payroll_Employee_frm.PAN_TXT.Focus()
                    Else
                        Me.Dispose()
                    End If
                    Return False
                End If
                If Nominee.Trim = Nothing Then
                    Msg(NOT_Type.Warning, "Nominee Name Input Error", "Nominee of '" & Name & "' is not available so this employee is not eligible for loan")
                    If Msg_Yn("Set Nominee Name", "Do you want to enter Nominee Name from here?") = DialogResult.Yes Then
                        Me.Dispose()
                        Cell("Payroll Employee", "", "Alter", ID)
                        Frm_foCus()
                        Payroll_Employee_frm.Seatutory_YN.Text = "Yes"
                        Payroll_Employee_frm.Nominee_TXT.Focus()
                    Else
                        Me.Dispose()
                    End If
                    Return False
                End If
            End If
        End If
    End Function
    Private Function Button_Manage()
        Button_Clear()
        BG_frm.B_1.Text = "&E : Exit"
        BG_frm.B_2.Text = "&S : Save"
        BG_frm.B_3.Text = "&P : Print"

        If VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close" Then
            BG_frm.B_4.Text = "&D : Delete"
        End If

        If Login_Type = "Admin Account" And (VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close") Then
            BG_frm.B_5.Text = "|&O : Audit"
        End If
    End Function
    Private Function Add_Hander_Remove_Handel(Ans As Boolean)
        If Ans = True Then
            AddHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            AddHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
            AddHandler BG_frm.B_3.Click, AddressOf Me.B_3_Click

            If Login_Type = "Admin Account" And (VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close") Then
                AddHandler BG_frm.B_4.Click, AddressOf Me.B_5_Click
            End If
        Else
            RemoveHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            RemoveHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
            RemoveHandler BG_frm.B_3.Click, AddressOf Me.B_3_Click

            If Login_Type = "Admin Account" And (VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close") Then
                RemoveHandler BG_frm.B_4.Click, AddressOf Me.B_5_Click
            End If
        End If
    End Function
    Private Sub B_1_Click(sender As Object, e As EventArgs)
        If BG_frm.HADE_TXT.Text = "Loan Sanction" Then
            Me.Dispose()
        End If
    End Sub
    Private Sub B_2_Click(sender As Object, e As EventArgs)
        If BG_frm.HADE_TXT.Text = "Loan Sanction" Then
            Save_data()
        End If
    End Sub
    Private Sub B_3_Click(sender As Object, e As EventArgs)
        If BG_frm.HADE_TXT.Text = "Loan Sanction" Then
            Print_Priew_frm.ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("cmp_dt", Print_DT_Company))
            Print_Priew_frm.ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dt_", dt_print))
            Dim paramtr(0) As ReportParameter
            Print_Priew_frm.Print_Privew(Application.StartupPath & "\Print_\Report\Loan_Sanction", Email_LAB.Text, paramtr)
        End If
    End Sub
    Private Sub B_5_Click(sender As Object, e As EventArgs)
        If BG_frm.HADE_TXT.Text = "Loan Sanction" Then
            If Chack_delete_() = True Then
                If Msg_Yn("Are you soure", "Delete this loan ?") = DialogResult.Yes Then
                    Delete_()
                End If
            End If
        End If
    End Sub
    Private Function Delete_()
        If Delete_Report_Install(ID_) = True Then
            If open_MSSQL(Database_File.cre) = True Then
                qury = "UPDATE TBL_Loan_sanction SET Visible = @Visible,[User] = @User,Date_Install = @Date_Install,PC = @PC WHERE ID Like N'" & ID_ & "'

Delete From TBL_Loan_Installments where Loan_ID = '" & ID_ & "'

"



                cmd = New SQLiteCommand(qury, con)
                With cmd.Parameters
                    .AddWithValue("@Visible", "Delete")
                    .AddWithValue("@User", LOGIN_ID.Trim)
                    .AddWithValue("@PC", PC_ID.Trim)
                    .AddWithValue("@Date_install", SqlDbType.DateTime).Value = DateTime.Now
                    cmd.ExecuteNonQuery()
                End With
                Me.Dispose()
            End If
        End If
    End Function
    Public Function Delete_Report_Install(ID As String) As Boolean
        Dim cn As New SQLiteConnection
        Try
            If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                cmd = New SQLiteCommand("INSERT INTO DEL_Loan_sanction (Employee_ID,Sanction_Date,Instalments_Date,Guarantor_ID,Head_of_Department,Loan_Amount,Loan_Type,Particuls,Particuls_Type,Instalments,Last_Instalments,Interest_Rate,Company,Visible,[User],Date_Install,PC) SELECT Employee_ID,Sanction_Date,Instalments_Date,Guarantor_ID,Head_of_Department,Loan_Amount,Loan_Type,Particuls,Particuls_Type,Instalments,Last_Instalments,Interest_Rate,Company,Visible,[User],Date_Install,PC FROM TBL_Loan_sanction where ID = '" & ID & "'", cn)
                cmd.ExecuteNonQuery()
            End If
            Return True
        Catch ex As Exception
            Msg(NOT_Type.Erro, "Delete report error", ex.Message)
            Return False
        End Try
    End Function
    Private Function Chack_delete_() As Boolean
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand("Select Count(ls.ID) as cnt From TBL_Loan_installments ls where ls.Loan_ID = '" & ID_ & "'", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                If Val(r("cnt")) > 1 Then
                    Msg(NOT_Type.Info, "You cannot delete a loan", "The installments of the loan you want to delete are full so you cannot delete this loan.")
                    r.Close()
                    Return False
                    Exit While
                End If
            End While
        End If
        Return True
    End Function
    Private Function Save_Requr() As Boolean
        If Cal_() = True Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function Save_data()
        If Save_Requr() = True Then
            If Insurt_Value() = True Then
                Clear_all()
            End If
        End If
    End Function
    Private Function Clear_all()

        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            'BG_frm.Loan_sections_BS.DataSource = Nothing
            'BG_frm.Loan_sections_BS.DataSource = Fill_Loan_section(cn)
        End If


        If VC_Type_ = "Create" Then
            LoanAmt_TXT.Focus()
            LoanAmt_TXT.Text = ""
            particuls_txt.Text = ""
            intrest_txt.Text = ""

            Grid1.Rows.Clear()
            Label34.Text = "0.00"
            Moanth_Intrest_LAB.Text = "0.00"
            Month_Payment_LAB.Text = "0.00"
            Last_instalment_LAB.Text = "0.00"
            Total_Payment_LAB.Text = "0.00"
            Total_Intrest_LAB.Text = "0.00"

            Label10.Text = "0.00"
            Label33.Text = "0.00"
            Label65.Text = ""
            Frist_instalment_Date_LAB.Text = "0.00"
            Last_instalment_Date_LAB.Text = ""
            Period_instalment_LAB.Text = ""


            NOT_("The entry you entered has been successfully accepted", NOT_Type.Success)
        Else
            Me.Dispose()
        End If
    End Function
    Private Function Insurt_Value()
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
                cmd = New SQLiteCommand("INSERT INTO TBL_Loan_sanction (Employee_ID,Sanction_Date,Instalments_Date,Guarantor_ID,Head_of_Department,Loan_Amount,Loan_Type,Particuls,Particuls_Type,Instalments,Last_Instalments,Interest_Rate,Company,Visible,[User],Date_Install,PC) VALUES (@Employee_ID,@Sanction_Date,@Instalments_Date,@Guarantor_ID,@Head_of_Department,@Loan_Amount,@Loan_Type,@Particuls,@Particuls_Type,@Instalments,@Last_Instalments,@Interest_Rate,@Company,@Visible,@User,@Date_Install,@PC)", cn)
                Try
                    With cmd.Parameters
                        .AddWithValue("@Employee_ID", VC_ID_.Trim)
                        .AddWithValue("@Sanction_Date", CDate(SanctionDate_txt.Text))
                        .AddWithValue("@Instalments_Date", CDate(Insalmentsdate_txt.Text))
                        .AddWithValue("@Guarantor_ID", Find_DT_Value(Database_File.cre, "TBL_Payroll_Employee", "ID", "Name = '" & gu_Name_TXT.Text & "' and Visible = 'Approval'").Trim)
                        .AddWithValue("@Head_of_Department", Head_department_TXT.Text.Trim)
                        .AddWithValue("@Loan_Amount", nUmBeR_FORMATE(LoanAmt_TXT.Text))
                        .AddWithValue("@Loan_Type", Loan_Type_select.Txt1.Text.Trim)
                        .AddWithValue("@Particuls", nUmBeR_FORMATE(particuls_txt.Text))
                        .AddWithValue("@Particuls_Type", Select_ctrl1.Txt1.Text.Trim)
                        .AddWithValue("@Interest_Rate", nUmBeR_FORMATE(intrest_txt.Text))
                        .AddWithValue("@Instalments", nUmBeR_FORMATE(Month_Payment_LAB.Text))
                        .AddWithValue("@Last_Instalments", nUmBeR_FORMATE(Last_instalment_LAB.Text))


                        .AddWithValue("@Company", Company_ID_str)
                        .AddWithValue("@User", LOGIN_ID)
                        .AddWithValue("@Date_install", SqlDbType.DateTime).Value = DateTime.Now
                        .AddWithValue("@PC", PC_ID.Trim)
                        .AddWithValue("@Visible", "Approval")
                        cmd.ExecuteNonQuery()
                    End With
                    Insurt_TBL_Loan_installments(cn)
                    Return True
                Catch ex As Exception
                    Msg(NOT_Type.Erro, "Data Save Error", ex.Message)
                    Return False
                End Try
                '////////////////////////////////////////////////////////////////////////
            ElseIf VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close" Then
                cmd = New SQLiteCommand("UPDATE TBL_Loan_sanction SET Employee_ID = @Employee_ID,Sanction_Date = @Sanction_Date,Instalments_Date = @Instalments_Date,Guarantor_ID = @Guarantor_ID,Head_of_Department = @Head_of_Department,Loan_Amount = @Loan_Amount,Loan_Type = @Loan_Type,Particuls = @Particuls,Particuls_Type = @Particuls_Type,Instalments = @Instalments,Last_Instalments = @Last_Instalments,Interest_Rate = @Interest_Rate WHERE ID Like N'" & ID_ & "'", cn)
                Try
                    With cmd.Parameters
                        .AddWithValue("@Employee_ID", VC_ID_.Trim)
                        .AddWithValue("@Sanction_Date", CDate(SanctionDate_txt.Text))
                        .AddWithValue("@Instalments_Date", CDate(Insalmentsdate_txt.Text))
                        .AddWithValue("@Guarantor_ID", Find_DT_Value(Database_File.cre, "TBL_Payroll_Employee", "ID", "Name = '" & gu_Name_TXT.Text & "' and Visible = 'Approval'").Trim)
                        .AddWithValue("@Head_of_Department", Head_department_TXT.Text.Trim)
                        .AddWithValue("@Loan_Amount", nUmBeR_FORMATE(LoanAmt_TXT.Text))
                        .AddWithValue("@Loan_Type", Loan_Type_select.Txt1.Text.Trim)
                        .AddWithValue("@Particuls", nUmBeR_FORMATE(particuls_txt.Text))
                        .AddWithValue("@Particuls_Type", Select_ctrl1.Txt1.Text.Trim)
                        .AddWithValue("@Interest_Rate", nUmBeR_FORMATE(intrest_txt.Text))
                        .AddWithValue("@Instalments", nUmBeR_FORMATE(Month_Payment_LAB.Text))
                        .AddWithValue("@Last_Instalments", nUmBeR_FORMATE(Last_instalment_LAB.Text))


                        .AddWithValue("@Date_install", SqlDbType.DateTime).Value = DateTime.Now
                        cmd.ExecuteNonQuery()
                    End With
                    Insurt_TBL_Loan_installments(cn)
                    Return True
                Catch ex As Exception
                    Msg(NOT_Type.Erro, "Data Save Error", ex.Message)
                    Return False
                End Try
            End If
        End If
    End Function
    Private Function Insurt_TBL_Loan_installments(cn As SQLiteConnection) As Boolean
        Dim id__ As Integer

        cmd = New SQLiteCommand("Select top 1 * From TBL_Loan_sanction Order By Id DESC", cn)
        Dim r As SQLiteDataReader
        r = cmd.ExecuteReader
        While r.Read
            id__ = r("ID")
        End While
        r.Close()

        Dim diff As Integer = DateDiff(DateInterval.Day, CDate(SanctionDate_txt.Text), CDate(Insalmentsdate_txt.Text))

        Dim intr As Decimal = ((Val(LoanAmt_TXT.Text) * Val(Val(Moanth_Intrest_LAB.Text) / 30)) / 100) * diff


        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            cmd = New SQLiteCommand("INSERT INTO TBL_Loan_Installments (Tra_ID,Loan_ID,Loan_Type,Employee_ID,[From],[To],Loan_Amount,Interest,Installment) VALUES (@Tra_ID,@Loan_ID,@Loan_Type,@Employee_ID,@From,@To,@Loan_Amount,@Interest,@Installment)", cn)
            Try
                With cmd.Parameters
                    .AddWithValue("@Tra_ID", "0")
                    .AddWithValue("@Loan_ID", id__)
                    .AddWithValue("@Loan_Type", "Advance Installment")
                    .AddWithValue("@Employee_ID", VC_ID_)
                    .AddWithValue("@From", CDate(SanctionDate_txt.Text))
                    .AddWithValue("@To", CDate(Insalmentsdate_txt.Text))
                    .AddWithValue("@Installment", Val("0"))
                    .AddWithValue("@Loan_Amount", Val(LoanAmt_TXT.Text))
                    .AddWithValue("@Interest", Val(intr))
                    cmd.ExecuteNonQuery()
                End With
                Return True
            Catch ex As Exception
                Msg(NOT_Type.Erro, "Data Save Error", ex.Message)
                Return False
            End Try
        ElseIf VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close" Then
            cmd = New SQLiteCommand("UPDATE TBL_Loan_Installments SET [From] = @From,[To] = @To,Loan_Amount = @Loan_Amount,Installment = @Installment,Interest = @Interest where Loan_ID = '" & ID_ & "'", cn)
            Try
                With cmd.Parameters
                    .AddWithValue("@From", CDate(SanctionDate_txt.Text))
                    .AddWithValue("@To", CDate(Insalmentsdate_txt.Text))
                    .AddWithValue("@Installment", Val("0"))
                    .AddWithValue("@Loan_Amount", Val(LoanAmt_TXT.Text))
                    .AddWithValue("@Interest", Val(intr))
                    cmd.ExecuteNonQuery()
                End With
                Return True
            Catch ex As Exception
                Msg(NOT_Type.Erro, "Data Save Error", ex.Message)
                Return False
            End Try
        End If
    End Function
    Private Function Display_alt()
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand("Select * From TBL_Loan_Sanction where ID = '" & ID_ & "' and " & Company_Visible_Filter, cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                VC_ID_ = r("Employee_ID")
                SanctionDate_txt.Text = CDate(r("Sanction_Date"))
                Insalmentsdate_txt.Text = CDate(r("Instalments_Date"))
                gu_Name_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Payroll_Employee", "Name", "ID = '" & r("Guarantor_ID") & "' and " & Company_Visible_Filter)
                Head_department_TXT.Text = (r("Head_of_Department"))
                LoanAmt_TXT.Text = nUmBeR_FORMATE(r("Loan_Amount"))
                Loan_Type_select.Txt1.Text = (r("Loan_Type"))
                particuls_txt.Text = nUmBeR_FORMATE(r("Particuls"))
                Select_ctrl1.Txt1.Text = (r("Particuls_Type"))
                intrest_txt.Text = nUmBeR_FORMATE(r("Interest_Rate"))
            End While
        End If
        Cal_()
    End Function
    Dim Logo_ As Byte()
    Private Function Fill_()
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand("Select *,(Select [Name] From TBL_Stock_Group where id = Em.Under) as Group_ From TBL_Payroll_Employee EM where em.ID = '" & VC_ID_ & "'", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                ID_LAB.Text = r("ID").ToString
                Name_LAB.Text = r("Name").ToString
                Alias_LAB.Text = r("alias").ToString
                Father_LAB.Text = r("Father_Name").ToString
                Gender_LAB.Text = r("Gender").ToString
                Under_LAB.Text = r("Group_").ToString
                joining_LAB.Text = CDate(r("Date_of_joining").ToString).ToString("dd-MM-yyyy")
                Mobile_LAB.Text = r("Mobile1").ToString & ", " & r("Mobile2").ToString
                Father_LAB.Text = r("Father_Mobile").ToString
                Email_LAB.Text = r("Email").ToString
                Aadhaar_LAB.Text = r("Aadhaar").ToString
                PAN_LAB.Text = r("PAN").ToString
                Nominee_LAB.Text = r("Nominee").ToString
                Address_LAB.Text = r("Address").ToString
                Try
                    Logo_ = DirectCast(r("Photo"), Byte())
                Catch ex As Exception

                End Try
            End While
        End If

        Dim ms As New MemoryStream
        Try
            ms = New MemoryStream(Logo_)
            PictureBox1.Image = Image.FromStream(ms)
        Catch ex As Exception

        End Try

    End Function
    Private Sub Loan_sanction_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.HADE_TXT.Text = "Loan Sanction"
        BG_frm.TYP_TXT.Text = VC_Type_
        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text

        Button_Clear()
        Button_Manage()
        Add_Hander_Remove_Handel(True)

        If Allow_thi_employee() = True Then

        End If

        SanctionDate_txt.Focus()
    End Sub
    Public share_prise As Decimal
    Public share_per As Decimal
    Private Sub Loan_sanction_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If Msg_Yn("Exit ?", "") = DialogResult.Yes Then
                Me.Dispose()
            End If
        End If
    End Sub

    Private Sub Loan_sanction_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End
        Add_Hander_Remove_Handel(False)
        List_frm.Dispose()
        Frm_foCus()
    End Sub


    Private Sub Txt1_Enter(sender As Object, e As EventArgs)
        List_frm.Dispose()
        Mini_List_frm.Dispose()
        SendKeys.Send("{Right}")
        Select_Currant(sender.Text)
    End Sub
    Private Sub Txt2_Enter(sender As Object, e As EventArgs)
        List_frm.Dispose()
        Mini_List_frm.Dispose()
        SendKeys.Send("{Right}")
        Select_Currant(sender.Text)
    End Sub


    Private Sub Txt1_KeyDown(sender As Object, e As KeyEventArgs)
        source1_Fill_data(sender)
        If e.KeyCode = Keys.Up Then
            BindingSource1.MovePrevious()
        End If
        If e.KeyCode = Keys.Down Then
            BindingSource1.MoveNext()
        End If
        If e.KeyCode = Keys.Enter Then
            sender.Text = List_frm.List_Grid.CurrentRow.Cells(0).Value.ToString()
        End If
    End Sub
    Private Sub Txt2_KeyDown(sender As Object, e As KeyEventArgs)
        source2_Fill_data(sender)
        If e.KeyCode = Keys.Up Then
            BindingSource2.MovePrevious()
        End If
        If e.KeyCode = Keys.Down Then
            BindingSource2.MoveNext()
        End If
        If e.KeyCode = Keys.Enter Then
            sender.Text = List_frm.List_Grid.CurrentRow.Cells(0).Value.ToString()
        End If
    End Sub
    Public Function source2_Fill_data(sender As Object)
        Dim dt As New DataTable
        dt.Columns.Add("Name")
        dt.Columns.Add("null")

        dt.Rows.Add("Month")
        dt.Rows.Add("Years")

        BindingSource2.DataSource = dt

        If List_frm.Visible = False Then

        End If
    End Function
    Public Function source1_Fill_data(sender As Object)
        Dim dt As New DataTable
        dt.Columns.Add("Name")
        dt.Columns.Add("null")

        dt.Rows.Add("Monthly Payment (EMI)")
        dt.Rows.Add("Number of Instalments")

        BindingSource1.DataSource = dt

        If List_frm.Visible = False Then

        End If
    End Function
    Public Function Select_Currant(TXT As String)
        Try
            If List_frm.Visible = True Then
                For i As Integer = 0 To List_frm.List_Grid.Rows.Count - 1
                    Dim ro As DataGridViewRow = List_frm.List_Grid.Rows(i)
                    If ro.Cells(1).Value = TXT Then
                        List_frm.List_Grid.CurrentCell = List_frm.List_Grid.Rows(i).Cells(1)
                        Exit For
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Function

    Private Sub Txt1_LostFocus(sender As Object, e As EventArgs)
        List_frm.Dispose()
        Mini_List_frm.Dispose()
    End Sub
    Private Sub Txt2_LostFocus(sender As Object, e As EventArgs)
        List_frm.Dispose()
        Mini_List_frm.Dispose()
    End Sub
    Dim Rt As Decimal = 0
    Private Sub Label19_Click(sender As Object, e As EventArgs)

    End Sub

    Private Function Cal_() As Boolean
        If Val(LoanAmt_TXT.Text) = 0 Then
            Msg(NOT_Type.Warning, "Input Error - Value is Null", "Please enter the loan amount, try again")
            LoanAmt_TXT.Focus()
            Return False
        End If
        If Val(particuls_txt.Text) = 0 Then
            Msg(NOT_Type.Warning, "Input Error - Value is Null", "Please enter the " & Label16.Text & ", try again")
            particuls_txt.Focus()
            Return False
        End If
        If Heda_of_Dipartment_valid() = False Then
            Head_department_TXT.Text = ""
            Head_department_TXT.Focus()
            Return False
        End If
        If Particuls_vlu_cal() = False Then
            particuls_txt.Text = ""
            particuls_txt.Focus()
            Return False
        End If
        If Val(intrest_txt.Text) > 18 Then
            Msg(NOT_Type.Warning, "Intrets is Not Valid", "Minimum 1 and Maximum 18")
            intrest_txt.Text = ""
            intrest_txt.Focus()
            Return False
        End If
        If ins_date_valid() = False Then
            Insalmentsdate_txt.Text = ""
            Insalmentsdate_txt.Focus()
            Return False
        End If
        If san_date_valid() = False Then
            SanctionDate_txt.Text = ""
            SanctionDate_txt.Focus()
            Return False
        End If

        dt_print.Rows.Clear()

        Month_Payment_LAB.Text = Month_Payment()
        Label34.Text = Loan_Amount()
        Moanth_Intrest_LAB.Text = Intrest_rate()
        Total_Payment_LAB.Text = Total_payment()
        Total_Intrest_LAB.Text = Total_Intrest()
        Last_instalment_LAB.Text = Last_Instalment()
        Month_Payment_LAB.Text = Format(Val(Month_Payment_LAB.Text), "0.000")
        Label36.Text = EMI_Calculation_sub(0) & " Monthly Payment (EMI)"

        If Val(Last_instalment_LAB.Text) = 0 Then
            Panel12.Hide()
        Else
            Panel12.Show()
        End If

        EMI_Calculation()
        Frist_instalment_Date_LAB.Text = CDate(Insalmentsdate_txt.Text)
        Period_instalment_LAB.Text = DateDiff(DateInterval.Day, CDate(Frist_instalment_Date_LAB.Text), CDate(Last_instalment_Date_LAB.Text)) & " Days"


        If Find_DT_Value(Database_File.cmp, "TBL_Features", "Value", "Head = 'Using Shareholder Method' and Type = 'Payroll'") = "Yes" Then

            share_per = Find_DT_Value(Database_File.cmp, "TBL_Features", "Value", "Head = 'Loan holder investment in shares' and Type = 'Payroll'")
            share_prise = Find_DT_Value(Database_File.cmp, "TBL_Features", "Value", "Head = 'Organisation Share Price' and Type = 'Payroll'")

            Label35.Text = "Share Dedution (" & share_prise & "%)"


            Label10.Text = Val(Loan_Amount) - (Val(Loan_Amount) * Val(share_per)) / 100
            Label33.Text = ((Val(Loan_Amount) * Val(share_per)) / 100)

            Dim shar_qty As Decimal = Val(((Val(Loan_Amount) * Val(share_per)) / 100) / share_prise)

            Label65.Text = "Shares (" & shar_qty & ") X (" & share_per & ") = ₹(" & ((Val(Loan_Amount) * Val(share_per)) / 100) & ") Share Deduction"
        Else
            Label10.Text = ""
            Label33.Text = ""
            Label65.Text = ""
        End If
        Return True
    End Function
    Public Function Total_Intrest() As Decimal
        If Loan_Type_select.Txt1.Text = "Monthly Payment (EMI)" Then
            Return nUmBeR_FORMATE(Val(Total_Payment_LAB.Text) - Val(Label34.Text))
        ElseIf Loan_Type_select.Txt1.Text = "Number of Instalments" Then
            Return Format(Val(Val(Total_Payment_LAB.Text) - Val(Label34.Text)), "0.00")
        End If
    End Function
    Public Function Total_payment() As Decimal
        If Loan_Type_select.Txt1.Text = "Monthly Payment (EMI)" Then
            Return Format(Val(EMI_Calculation_sub(3)), "0.00")
        ElseIf Loan_Type_select.Txt1.Text = "Number of Instalments" Then
            Return Format(Val(Val(Month_Payment_LAB.Text) * Val(Number_of_month)), "0.00")
        End If

    End Function
    Public Function Last_Instalment() As Decimal
        Return Format(Val(EMI_Calculation_sub(4)), "0.00")
    End Function
    Public Function Number_of_month() As Decimal

        If Loan_Type_select.Txt1.Text = "Monthly Payment (EMI)" Then
            Return EMI_Calculation_sub(1)
        ElseIf Loan_Type_select.Txt1.Text = "Number of Instalments" Then
            If Loan_Type_select.Txt1.Text = "Years" Then
                Return Val(Rt) * 12
            ElseIf Select_ctrl1.Txt1.Text = "Month" Then
                Return Val(Rt) * 12
            End If
        End If
    End Function
    Public Function Month_Payment() As Decimal
        If Loan_Type_select.Txt1.Text = "Monthly Payment (EMI)" Then
            Return Val(particuls_txt.Text)
        ElseIf Loan_Type_select.Txt1.Text = "Number of Instalments" Then
            If Select_ctrl1.Txt1.Text = "Years" Then
                Rt = Val(particuls_txt.Text)
            ElseIf Select_ctrl1.Txt1.Text = "Month" Then
                Rt = Val(particuls_txt.Text) / 12
            End If

            Dim amt As Decimal = 0

            If CDate(SanctionDate_txt.Text) = CDate(Insalmentsdate_txt.Text) Then
                amt = Val(LoanAmt_TXT.Text)
            Else
                Dim count_day As Integer = DateDiff(DateInterval.Day, CDate(SanctionDate_txt.Text), CDate(Insalmentsdate_txt.Text))

                Dim intrest_ As Decimal = Val(Intrest_rate) / 30

                Dim calculat_ As Decimal = (Val(Val(Loan_Amount) * intrest_) / 100) * count_day

                amt = Val(Loan_Amount) + calculat_
            End If

            Dim rate_ As Decimal = Val(intrest_txt.Text.Trim) / 100
            Return Pmt(rate_ / 12, Val(Rt) * 12, -1 * amt)
        End If

    End Function
    Public Function Intrest_rate() As Decimal
        Return Format(Val(Val(intrest_txt.Text) / 12), "0.000")
    End Function
    Public Function Loan_Amount() As Decimal
        Return Val(LoanAmt_TXT.Text)
    End Function
    Public Function EMI_Calculation_sub() As Decimal()
        Dim int As Integer = ((((Val(Loan_Amount) * Val(intrest_txt.Text)) / 100) + Val(Loan_Amount)) / Val(Month_Payment)) * 5

        Dim amt As Decimal = LoanAmt_TXT.Text
        Dim rt As Decimal = 0
        Dim cl_AMT As Decimal = 0
        Dim count_ As Integer = 0
        Dim count_TO As Integer = 0
        Dim Total_Payment As Integer = 0

        Dim Last_installment_Date As Date

        If CDate(SanctionDate_txt.Text) <> CDate(Insalmentsdate_txt.Text) Then
            Dim count_day As Integer = DateDiff(DateInterval.Day, CDate(SanctionDate_txt.Text), CDate(Insalmentsdate_txt.Text))

            Dim intrest_ As Decimal = Val(Intrest_rate) / 30

            Dim calculat_ As Decimal = (Val(Val(Loan_Amount) * intrest_) / 100) * count_day
            amt = Val(Loan_Amount) + calculat_
        End If

        For i As Integer = 1 To int
            Dim curr_rt As Decimal = ((Val(amt) * Val(Intrest_rate)) / 100)

            rt = rt + curr_rt
            amt = amt + curr_rt



            If amt >= Val(Month_Payment) And amt <> 0 Then
                amt = amt - (Val(Month_Payment))

                Total_Payment += (Val(Month_Payment))

                count_ += 1
                count_TO += 1
            Else
                cl_AMT = amt

                Total_Payment += (Val(amt))

                amt = amt - amt

                count_TO += 1
                Exit For
            End If
        Next

        Dim st As Decimal()
        st = {count_, count_TO, rt, Total_Payment, cl_AMT}
        Return st
    End Function
    Private Function EMI_Calculation() As Decimal
        Grid1.Rows.Clear()

        Dim int As Integer = ((((Val(Loan_Amount) * Val(intrest_txt.Text)) / 100) + Val(Loan_Amount)) / Val(Month_Payment)) * 5

        Dim amt As Decimal = LoanAmt_TXT.Text
        Dim rt As Decimal = 0
        Dim install_ As Decimal = 0
        Dim count_ As Integer = 0
        Dim count_TO As Integer = 0
        Dim Date_ As Date = CDate(Insalmentsdate_txt.Text)
        Dim Last_installment_Date As Date

        Date_ = Date_.AddMonths(-1)
        'dt_print.Rows.Clear()

        dt_print = ds.Tables("TBL_Loan_Sanction")
        If CDate(SanctionDate_txt.Text) <> CDate(Insalmentsdate_txt.Text) Then
            Dim count_day As Integer = DateDiff(DateInterval.Day, CDate(SanctionDate_txt.Text), CDate(Insalmentsdate_txt.Text))

            Dim intrest_ As Decimal = Val(Intrest_rate) / 30

            Dim calculat_ As Decimal = (Val(Val(Loan_Amount) * intrest_) / 100) * count_day

            amt = Val(Loan_Amount) + calculat_

            Dim Distance As String = DateDiff(DateInterval.Day, CDate(SanctionDate_txt.Text), CDate(Insalmentsdate_txt.Text)) & "Days"

            Grid1.Rows.Add("0", CDate(SanctionDate_txt.Text).ToString("dd-MM-yyyy"), CDate(Insalmentsdate_txt.Text).ToString("dd-MM-yyyy"), Distance, N2_FORMATE(Loan_Amount), N2_FORMATE(calculat_), "0.00", N2_FORMATE(amt))


            Fill_Print_data("0", CDate(SanctionDate_txt.Text).ToString("dd-MM-yyyy"), CDate(Insalmentsdate_txt.Text).ToString("dd-MM-yyyy"), Distance, N2_FORMATE(Loan_Amount), N2_FORMATE(calculat_), "0.00", N2_FORMATE(amt))

            'dt_print.Rows.Add("0", CDate(SanctionDate_txt.Text).ToString("dd-MM-yyyy"), CDate(Insalmentsdate_txt.Text).ToString("dd-MM-yyyy"), N2_FORMATE(Loan_Amount), N2_FORMATE(calculat_), "0.00", N2_FORMATE(amt), Distance)
        End If

        Dim CL_ As Decimal = amt


        For i As Integer = 1 To int
            Dim curr_rt As Decimal = ((Val(amt) * Val(Intrest_rate)) / 100)

            rt = rt + curr_rt

            'CL_ = amt
            Date_ = Date_.AddMonths(1)

            amt = amt + curr_rt

            If amt >= Val(Month_Payment) And amt <> 0 Then
                amt = amt - (Val(Month_Payment))
                install_ = (Val(Month_Payment))

                count_ += 1
                count_TO += 1

            Else
                install_ = amt
                amt = amt - amt
                count_TO += 1
            End If
            Dim dt2_ As Date = CDate(Date_).AddMonths(1)

            Dim Distance As String = DateDiff(DateInterval.Day, CDate(Date_), CDate(dt2_)) & "Days"

            Dim LOGO As Byte()
            Try
                'Company_Logo
                Dim Photo As Image
                If IsNothing(Photo) Then
                Else

                    Dim img As Image
                    img = Photo
                    Dim img_stm As System.IO.MemoryStream = New System.IO.MemoryStream
                    img.Save(img_stm, System.Drawing.Imaging.ImageFormat.Png)
                    LOGO = img_stm.GetBuffer
                End If
            Catch ex As Exception

            End Try

            Grid1.Rows.Add(i, Date_.ToString("dd-MM-yyyy"), dt2_.ToString("dd-MM-yyyy"), Distance, N2_FORMATE(CL_), N2_FORMATE(curr_rt), N2_FORMATE(install_), N2_FORMATE(amt))


            Fill_Print_data(i, Date_.ToString("dd-MM-yyyy"), dt2_.ToString("dd-MM-yyyy"), Distance, Val(CL_), Val(curr_rt), Val(install_), Val(amt))

            If amt <= 0 Then
                Exit For
            End If

            CL_ = amt

            Last_installment_Date = dt2_.ToString("dd-MM-yyyy")
        Next

        Last_instalment_Date_LAB.Text = CDate(Last_installment_Date)
    End Function
    Private Function Fill_Print_data(No As String, Frm As Date, to_ As Date, distance As String, Loan_amt As Decimal, intrext As Decimal, installment As Decimal, closing As Decimal)
        Dim dr As DataRow

        dr = dt_print.NewRow
        dr("No") = No
        dr("From") = CDate(Frm).ToString("dd-MM-yyyy")
        dr("To") = CDate(to_).ToString("dd-MM-yyyy")
        dr("Destance") = (distance)
        dr("Loan_Amount") = N2_FORMATE(Loan_amt)
        dr("Interest") = N2_FORMATE(intrext)
        dr("Instalments") = N2_FORMATE(installment)
        dr("Closing") = N2_FORMATE(closing)
        If dt_print.Rows.Count = 0 Then
            Try
                Dim photo As Image = PictureBox1.Image
                If IsNothing(photo) Then
                Else
                    Dim img As Image
                    img = photo
                    Dim img_stm As System.IO.MemoryStream = New System.IO.MemoryStream
                    img.Save(img_stm, System.Drawing.Imaging.ImageFormat.Png)
                    Dim LOGO As Byte()
                    LOGO = img_stm.GetBuffer
                    dr("Photo") = LOGO
                End If
            Catch ex As Exception

            End Try
        End If

        dt_print.Rows.Add(dr)
    End Function
    Private Sub LoanAmt_TXT_TextChanged(sender As Object, e As EventArgs) Handles LoanAmt_TXT.TextChanged

    End Sub

    Private Function Loan_Max_cal() As Boolean

        Dim Max_lanth_of_emp As String
        Dim cfg_pr As String = Find_DT_Value(Database_File.cmp, "TBL_Features", "Value", "Head = 'Loan limit from net salary' and Type = 'Payroll'")

        Dim emp_salary As String = Val(Salary_LAB.Text)

        Max_lanth_of_emp = (Val(emp_salary) * Val(cfg_pr)) / 100

        If Val(Max_lanth_of_emp) < Val(LoanAmt_TXT.Text) Then
            Msg(NOT_Type.Warning, "Loan Amount Limit Over !", "The salary of the employee you selected is " & N2_FORMATE(emp_salary) & ", as per the rule " & N2_FORMATE(cfg_pr) & "% of the salary can be loaned, so this employee can be given a maximum loan of " & N2_FORMATE(Max_lanth_of_emp) & "₹.")
            LoanAmt_TXT.Text = ""
            LoanAmt_TXT.Focus()
            Return False
        End If
        Return True
    End Function
    Private Sub SanctionDate_txt_TextChanged(sender As Object, e As EventArgs) Handles SanctionDate_txt.TextChanged

    End Sub

    Private Sub SanctionDate_txt_LostFocus(sender As Object, e As EventArgs) Handles SanctionDate_txt.LostFocus
        If Date_Formate(SanctionDate_txt.Text) <> "" Then
            If san_date_valid() = False Then
                SanctionDate_txt.Text = ""
                SanctionDate_txt.Focus()
            Else
                If Insalmentsdate_txt.Text = "" Then
                    Insalmentsdate_txt.Text = SanctionDate_txt.Text
                End If
                Dim find_hd As String = Find_DT_Value(Database_File.cre, "TBL_Payhead", "ID", "Name = 'Salary A/c'")
                Salary_LAB.Text = Val(Flat_Rate_cal(VC_ID_, find_hd, CDate(Company_Book_frm), CDate(SanctionDate_txt.Text), "0")(1))
            End If
        Else
            sender.Focus()
        End If
    End Sub

    Private Function san_date_valid() As Boolean
        If Date_Formate(SanctionDate_txt.Text) <> "" Then
            Dim cfg_date_count As Integer = Find_DT_Value(Database_File.cmp, "TBL_Features", "Value", "Head = 'Loans for how old employees' and Type = 'Payroll'")

            Dim emp_jo_date As Date = CDate(Find_DT_Value(Database_File.cre, "TBL_Payroll_Employee", "Date_of_Joining", "ID = '" & VC_ID_ & "'"))

            Dim day_count As Integer = DateDiff(DateInterval.Day, emp_jo_date, CDate(SanctionDate_txt.Text))

            If day_count < cfg_date_count Then
                Msg(NOT_Type.Warning, Name_LAB.Text & " is not eligible for loan", "As Per the Rules of The Company You Can Try for The Loan After " & cfg_date_count - day_count & " Days " & vbNewLine & " Date of attempt " & emp_jo_date.AddDays(cfg_date_count) & "")
                Return False
            End If
        Else
            'Return False
        End If
        Return True
    End Function
    Private Sub Insalmentsdate_txt_TextChanged(sender As Object, e As EventArgs) Handles Insalmentsdate_txt.TextChanged

    End Sub

    Private Sub Insalmentsdate_txt_LostFocus(sender As Object, e As EventArgs) Handles Insalmentsdate_txt.LostFocus
        If Date_Formate(Insalmentsdate_txt.Text) <> "" Then
            Return
        End If
        If ins_date_valid() = False Then
            Insalmentsdate_txt.Text = ""
            Insalmentsdate_txt.Focus()
        End If
    End Sub
    Private Function ins_date_valid() As Boolean
        If Date_Formate(Insalmentsdate_txt.Text) <> "" And Date_Formate(SanctionDate_txt.Text) <> "" Then
            Dim cfg_date_count As Integer = Find_DT_Value(Database_File.cmp, "TBL_Features", "Value", "Head = 'Limit of days without installments' and Type = 'Payroll'")

            Dim count_ As Integer = DateDiff(DateInterval.Day, CDate(SanctionDate_txt.Text), CDate(Insalmentsdate_txt.Text))


            If count_ > cfg_date_count Then
                Msg(NOT_Type.Warning, "", "Installment Date cannot exceed " & count_ & " Days of loan sanction, Please Try to Reduce the Date")
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub particuls_txt_TextChanged(sender As Object, e As EventArgs) Handles particuls_txt.TextChanged

    End Sub

    Private Sub particuls_txt_LostFocus(sender As Object, e As EventArgs) Handles particuls_txt.LostFocus
        If Particuls_vlu_cal() = False Then
            particuls_txt.Text = ""
            particuls_txt.Focus()
        End If
    End Sub
    Private Function Particuls_vlu_cal() As Boolean
        If Loan_Type_select.Txt1.Text = "Monthly Payment (EMI)" Then
            Dim cfg_count As Integer = Find_DT_Value(Database_File.cmp, "TBL_Features", "Value", "Head = 'Installment limit for loan' and Type = 'Payroll'")

            If Val(particuls_txt.Text) = 0 Then
                Msg(NOT_Type.Warning, "Value is not Accepted", "The installment is empty, please enter the installment amount and try again")
                Return False
            End If
            Dim amt As Decimal = (Val(Loan_Amount) * cfg_count / 100)
            Dim amt1 As Decimal = (Val(Loan_Amount) * 20 / 100)
            If Val(particuls_txt.Text) > (Val(Val(LoanAmt_TXT.Text) * 20) / 100) Then
                Msg(NOT_Type.Warning, "Value is not Accepted", "As per rule the maximum installment amount should be 20% of the loan amount entered, the maximum installment can be ₹" & N2_FORMATE(amt1) & ".")
                Return False
            End If
            If Val(particuls_txt.Text) < amt Then
                Msg(NOT_Type.Warning, "Value is not Accepted", "As per rule the minimum installment amount should be " & cfg_count & "% of the loan amount entered, the minimum installment can be " & N2_FORMATE(amt) & "₹.")
                Return False
            End If
        ElseIf Loan_Type_select.Txt1.Text = "Number of Instalments" Then
            If Val(particuls_txt.Text) = 0 Then
                Msg(NOT_Type.Warning, "Value is not Accepted", "The installment is empty, please enter the installment number and try again")
                Return False
            End If
        End If
        Return True
    End Function
    Private Sub intrest_txt_LostFocus(sender As Object, e As EventArgs) Handles intrest_txt.LostFocus
        If Val(intrest_txt.Text) > 18 Then
            Msg(NOT_Type.Warning, "Intrets is Not Valid", "Minimum 1 and Maximum 18")
            intrest_txt.Text = ""
            intrest_txt.Focus()
        End If
    End Sub

    Private Sub Panel10_Paint(sender As Object, e As PaintEventArgs) Handles Panel10.Paint

    End Sub

    Private Sub LoanAmt_TXT_LostFocus(sender As Object, e As EventArgs) Handles LoanAmt_TXT.LostFocus
        Loan_Max_cal()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Cal_()
    End Sub

    Private Sub gn_Name_TXT_TextChanged(sender As Object, e As EventArgs) Handles gu_Name_TXT.TextChanged
        gu_emp_Filter()
    End Sub
    Private Function gu_emp_Filter()
        'BG_frm.Payroll_Employee_BS.Filter = $"(Name LIKE '%{gu_Name_TXT.Text.Trim}%') and ID <> '" & VC_ID_ & "' and Name <> 'End of List'"
    End Function
    Private Function List_emp()
        If List_frm.Visible = False Then

        End If
        gu_emp_Filter()
    End Function
    Private Sub gn_Name_TXT_Enter(sender As Object, e As EventArgs) Handles gu_Name_TXT.Enter
        List_frm.Dispose()
        Mini_List_frm.Dispose()
        SendKeys.Send("{Right}")
        gu_emp_Filter()
        Select_Currant(gu_Name_TXT.Text)
    End Sub

    Private Sub gu_Name_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles gu_Name_TXT.KeyDown
        List_emp()
        If e.KeyCode = Keys.Up Then
            'BG_frm.Payroll_Employee_BS.MovePrevious()
        End If
        If e.KeyCode = Keys.Down Then
            'BG_frm.Payroll_Employee_BS.MoveNext()
        End If
        If e.KeyCode = Keys.Enter Then
            If GU_Cack_KYC(List_frm.List_Grid.CurrentRow.Cells(0).Value) = False Then
                sender.Text = ""
                'sender.Focus()
            Else
                sender.Text = List_frm.List_Grid.CurrentRow.Cells(1).Value
            End If
        End If
    End Sub
    Private Function GU_Cack_KYC(emp As String) As Boolean
        If BG_frm.HADE_TXT.Text = "Loan Sanction" = True Then

            Dim aadhaar As String
            Dim pan As String
            Dim Nominee As String
            Dim Name As String
            Dim ID As String

            Dim cn As New SQLiteConnection
            If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                cmd = New SQLiteCommand("Select * From TBL_Payroll_Employee where ID = '" & emp & "' and Visible = 'Approval'", cn)
                Dim r As SQLiteDataReader
                r = cmd.ExecuteReader
                While r.Read
                    ID = r("ID").ToString
                    Name = r("Name").ToString
                    aadhaar = r("Aadhaar").ToString
                    pan = r("PAN").ToString
                    Nominee = r("Nominee").ToString
                End While

                If aadhaar.Trim = Nothing Then
                    Msg(NOT_Type.Warning, "Aadhaar Input Error", "Aadhaar number of '" & Name & "' is not available so this Co-Applicant/Guarantor is not eligible")
                    If Msg_Yn("Set Aadhaar No.", "Do you want to enter Aadhaar number from here?") = DialogResult.Yes Then
                        'Return False
                        Cell("Payroll Employee", "", "Alter", ID)
                        'Frm_foCus()
                        Payroll_Employee_frm.Seatutory_YN.Text = "Yes"
                        Payroll_Employee_frm.Aadhaar_TXT.Focus()
                    End If
                    Return False
                End If

                If pan.Trim = Nothing Then
                    Msg(NOT_Type.Warning, "PAN No. Input Error", "PAN number of '" & Name & "' is not available so this Co-Applicant/Guarantor is not eligible")
                    If Msg_Yn("Set PAN No.", "Do you want to enter PAN number from here?") = DialogResult.Yes Then
                        'Return False
                        Cell("Payroll Employee", "", "Alter", ID)
                        'Frm_foCus()
                        Payroll_Employee_frm.Seatutory_YN.Text = "Yes"
                        Payroll_Employee_frm.PAN_TXT.Focus()
                    End If
                    Return False
                End If
            End If
        End If
        Return True
    End Function
    Private Sub gu_Name_TXT_LostFocus(sender As Object, e As EventArgs) Handles gu_Name_TXT.LostFocus
        List_frm.Dispose()
    End Sub

    Private Sub Select_ctrl1_Load(sender As Object, e As EventArgs) Handles Loan_Type_select.Load
        Dim dt As New DataTable
        dt.Columns.Add("Name")
        dt.Rows.Add("Monthly Payment (EMI)")
        dt.Rows.Add("Number of Instalments")
        Loan_Type_select.dt_ = dt
    End Sub

    Private Sub Loan_Type_select_TextChanged(sender As Object, e As EventArgs) Handles Loan_Type_select.TextChanged
        If Loan_Type_select.Txt1.Text = "Monthly Payment (EMI)" Then
            Select_ctrl1.Hide()
        ElseIf Loan_Type_select.Txt1.Text = "Number of Instalments" Then
            Select_ctrl1.Show()
        End If
        particuls_txt.Text = ""
        Label16.Text = Loan_Type_select.Txt1.Text
    End Sub

    Private Sub Select_ctrl1_Load_1(sender As Object, e As EventArgs) Handles Select_ctrl1.Load
        Dim dt As New DataTable
        dt.Columns.Add("Name")
        dt.Rows.Add("Month")
        dt.Rows.Add("Years")
        Select_ctrl1.dt_ = dt
    End Sub

    Private Sub Select_ctrl1_TextChanged(sender As Object, e As EventArgs) Handles Select_ctrl1.TextChanged
        If Select_ctrl1.Txt1.Text = "Years" Then
            Rt = Val(particuls_txt.Text)
        ElseIf Select_ctrl1.Txt1.Text = "Month" Then
            Rt = Val(particuls_txt.Text) / 12
        End If
    End Sub

    Private Sub intrest_txt_TextChanged(sender As Object, e As EventArgs) Handles intrest_txt.TextChanged

    End Sub

    Private Sub Head_department_TXT_TextChanged(sender As Object, e As EventArgs) Handles Head_department_TXT.TextChanged

    End Sub

    Private Sub Head_department_TXT_LostFocus(sender As Object, e As EventArgs) Handles Head_department_TXT.LostFocus
        If Heda_of_Dipartment_valid() = False Then
            Head_department_TXT.Focus()
        End If
    End Sub
    Private Function Heda_of_Dipartment_valid() As Boolean
        If Head_department_TXT.Text.Trim = Nothing Then
            Msg(NOT_Type.Erro, "Input Error - Head of Department", "Entering Name of Head of Department of '" & Name_LAB.Text & "' is mandatory, please enter the name of Head of Department.")
            Return False
        End If
        Return True
    End Function
End Class