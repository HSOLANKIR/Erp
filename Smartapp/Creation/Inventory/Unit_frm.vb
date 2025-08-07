Imports System.Data.SqlClient
Imports System.Data.SQLite
Imports Tools

Public Class Unit_frm
    Dim From_ID As String
    Dim Path_End As String
    Dim VC_Type_ As String
    Dim VC_ID_ As String
    Dim Stock_Pay As String

    Dim Unit1_ID As String
    Dim Unit2_ID As String
    Public close_focus_obj As TXT
    Private Sub Unit_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text

        VC_Type_ = Link_Valu(1)
        VC_ID_ = Link_Valu(2)
        Stock_Pay = Link_to_frm(0)


        Fill_Source()
        List_set()
        Set_msg()


        Type_TXT.Text = "Simple"

        If Stock_Pay = "Stock Unit" Then
            BG_frm.HADE_TXT.Text = "Stock Unit"
        ElseIf Stock_Pay = "Payroll Unit" Then
            BG_frm.HADE_TXT.Text = "Payroll Unit"
        End If



        BG_frm.TYP_TXT.Text = VC_Type_
        If VC_Type_ = "Display" Or VC_Type_ = "Display_Close" Then
            Me.Enabled = False
            Display_Fill_All()
        ElseIf VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close" Then
            Me.Enabled = True
            Type_TXT.Enabled = False
            Display_Fill_All()
        ElseIf VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            Type_TXT.Enabled = True
        End If
        Button_Manage()
        Add_Hander_Remove_Handel(True)

        Symbol_TXT.Focus()
    End Sub
    Dim msg_Name As Msg_frm
    Dim msg_alias As Msg_frm
    Private Function Set_msg()
        msg_Name = New Msg_frm
        Symbol_TXT.Msg_Object = msg_Name

        msg_alias = New Msg_frm
        Formal_TXT.Msg_Object = msg_alias
    End Function
    Dim unit_list As List_frm
    Dim Type_list As List_frm
    Dim comp_list As List_frm
    Dim comp_list1 As List_frm
    Private Function List_set()
        unit_list = New List_frm
        List_Setup("List of QUCs", Select_List.Right, Select_List_Format.Defolt, QUC_TXT, unit_list, BindingSource1, 320)

        Type_list = New List_frm
        List_Setup("Unit Type", Select_List.Right, Select_List_Format.Defolt, Type_TXT, Type_list, BindingSource2, 150)
        Type_list.List_Grid.Columns(1).Visible = False

        comp_list = New List_frm
        List_Setup("List of Units", Select_List.Right, Select_List_Format.Defolt, Unit1_TXT, comp_list, Unit_Source, 320)

        comp_list1 = New List_frm
        List_Setup("List of Units", Select_List.Right, Select_List_Format.Defolt, Unit2_TXT, comp_list1, Unit_Source, 320)
    End Function
    Private Function Fill_Source()
        Dim cn As New SQLiteConnection
        Dim dt As New DataTable
        dt.Columns.Add("Shortcut")
        dt.Columns.Add("Full Name")
        dt.Columns.Add("ID")

        dt.Rows.Add("Not Applicable", "", "")

        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand("Select * From TBL_UQC", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader

            While r.Read
                dt.Rows.Add(r("Shortcut"), r("Full_Name"))
            End While
        End If
        BindingSource1.DataSource = dt

        Dim dt1 As New DataTable
        dt1.Columns.Add("Head")
        dt1.Columns.Add("blank")
        dt1.Columns.Add("ID")

        dt1.Rows.Add("Simple")
        dt1.Rows.Add("Compound")

        BindingSource2.DataSource = dt1


        Dim dt_Unit As New DataTable
        dt_Unit.Columns.Add("Symbol")
        dt_Unit.Columns.Add("Formal Name")
        dt_Unit.Columns.Add("UQC")
        dt_Unit.Columns.Add("Decimal")
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand("Select * From TBL_Inventory_Unit where Type = 'Simple' and Visible = 'Approval'", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader

            While r.Read
                dt_Unit.Rows.Add(r("Symbol"), r("Formal_Name"), r("UQC"), r("Decimal"))
            End While
        End If
        Unit_Source.DataSource = dt_Unit

        Compund_UnitFilter_set()
    End Function
    Private Function Button_Manage()
        Button_Clear()
        BG_frm.B_1.Text = "&E : Exit"
        BG_frm.B_2.Text = "&S : Save"
        If VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close" Then
            BG_frm.B_3.Text = "&D : Delete"
        End If
        If Login_Type = "Admin Account" And (VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close") Then
            BG_frm.B_4.Text = "|&O : Audit"
        End If
    End Function
    Private Function Add_Hander_Remove_Handel(Ans As Boolean)
        If Ans = True Then
            AddHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            AddHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
            AddHandler BG_frm.B_3.Click, AddressOf Me.B_3_Click
            If Login_Type = "Admin Account" And (VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close") Then
                AddHandler BG_frm.B_4.Click, AddressOf Me.B_4_Click
            End If
        Else
            RemoveHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            RemoveHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
            RemoveHandler BG_frm.B_3.Click, AddressOf Me.B_3_Click
            If Login_Type = "Admin Account" And (VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close") Then
                AddHandler BG_frm.B_4.Click, AddressOf Me.B_4_Click
            End If
        End If
    End Function
    Private Sub B_4_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Cell("Audit Analysis", "", "Stock Unit", VC_ID_)
        End If
        If BG_frm.From_ID = From_ID Then
            Cell("Audit Analysis", "", "Payroll Unit", VC_ID_)
        End If
    End Sub
    Private Sub B_1_Click(sender As Object, e As EventArgs)
        Me.Dispose()
    End Sub
    Private Sub B_2_Click(sender As Object, e As EventArgs)
        Save_Data()
    End Sub
    Private Sub B_3_Click(sender As Object, e As EventArgs)
        If VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close" Then
            If BG_frm.From_ID = From_ID Then
                Delete_Data()
            End If
        End If
    End Sub
    Private Function Insurt_Audit() As Boolean
        If Val(VC_ID_) = 0 Then
            Return True
        End If

        If Audit_Save("TBL_Inventory_Unit", "ID", VC_ID_) = True Then
            Return True
        End If
    End Function
    Private Function Save_Data()
        If BG_frm.From_ID = From_ID Then
            If Save_Requr() = True Then
                If Insurt_Audit() = True Then
                    If Insurt_Value() = True Then
                        Clear_all()
                    End If
                End If
            End If
        End If
    End Function
    Private Function Delete_Data()
        Dim cn As New SQLiteConnection
        open_MSSQL_Cstm(Database_File.cre, cn)

        If Chack_Delete_Allow() = True Then
            If Msg_Delete_YN(Symbol_TXT, Stock_Pay) = DialogResult.Yes Then
                If Insurt_Audit() = True Then
                    qury = $"DELETE FROM TBL_Inventory_Unit Where ID = '{VC_ID_}';"
                    cmd = New SQLiteCommand(qury, cn)
                    cmd.ExecuteNonQuery()
                    Clear_all()
                End If
            End If
        Else
            Msg(NOT_Type.Info, "You cannot delete", "You cannot delete this Unit because the Unit you selected is made up of vouchers")
        End If
    End Function
    Private Function Chack_Delete_Allow() As Boolean
        Dim isavalable As Boolean = True
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select count(*) as count, 'Stock Item' as Type From TBL_Stock_Item st where 
(st.[Unit] = '{VC_ID_}') and 
st.Visible = 'Approval'
UNION ALL
Select count(*) as count, 'Inventory Unit Compound' as Type From TBL_Inventory_Unit u where 
(u.Unit1 = '{VC_ID_}' or u.Unit2 = '{VC_ID_}') and 
u.Visible = 'Approval'
UNION ALL
Select count(*), 'Defolt Stock Unit' as Type From TBL_Inventory_Unit u WHERE
U.id = '{VC_ID_}' and
U.Company = 'All'", cn)

            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                If Val(r("count")) <> 0 Then
                    If isavalable = True Then
                        isavalable = False
                    End If
                End If
            End While
        End If

        Return isavalable
    End Function
    Private Sub Unit_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If Msg_Exit_YN(Stock_Pay & VC_Type_) = DialogResult.Yes Then
                Me.Dispose()
                If VC_Type_ = "Alter_Close" Or VC_Type_ = "Create_Close" Then
                    close_focus_obj.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub QUC_TXT_TextChanged(sender As Object, e As EventArgs) Handles QUC_TXT.TextChanged
        'BG_frm.UQC_BS.Filter = $"Shortcut LIKE '%{QUC_TXT.Text.Trim()}%'" & $"or Full_Name LIKE '%{QUC_TXT.Text.Trim()}%'"
        'If List_frm.Visible = True Then
        '    List_Curr_(sender)
        'End If
    End Sub

    Private Sub QUC_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles QUC_TXT.KeyDown

    End Sub
    Private Function Compund_UnitFilter_set()
        If BG_frm.From_ID = From_ID Then
            Unit1_TXT.Select_Filter = "(Symbol <> '" & Unit2_TXT.Text & "')" & "AND (Symbol LIKE'" & Unit1_TXT.Text & "%'" & "OR [Formal Name] LIKE'<value>%')"

            Unit2_TXT.Select_Filter = "(Symbol <> '" & Unit1_TXT.Text & "')" & "AND (Symbol LIKE'<value>%'" & "OR [Formal Name] LIKE'<value>%')"
        Else
            Unit1_TXT.Select_Filter = "(Symbol <> '" & Unit2_TXT.Text & "')" & "AND (Symbol LIKE'<value>%'" & "OR [Formal Name] LIKE'<value>%')"

            Unit2_TXT.Select_Filter = "(Symbol <> '" & Unit1_TXT.Text & "')" & "AND (Symbol LIKE'<value>%'" & "OR [Formal Name] LIKE'<value>%')"
        End If

    End Function
    Private Sub Unit1_TXT_Enter(sender As Object, e As EventArgs) Handles Unit1_TXT.Enter
        Compund_UnitFilter_set()
    End Sub
    Private Sub Decimal_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Decimal_TXT.KeyPress
        allow_Number(e)
    End Sub

    Private Sub Unit_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.TYP_TXT.Text = VC_Type_
        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text

        Button_Clear()
        Button_Manage()

        Fill_Source()

        Type_TXT.Focus()
    End Sub
    Private Function Display_Fill_All()
        Type_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "Type", "ID = '" & VC_ID_ & "'")

        Symbol_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "Symbol", "ID = '" & VC_ID_ & "'")

        Formal_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "Formal_Name", "ID = '" & VC_ID_ & "'")

        QUC_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "UQC", "ID = '" & VC_ID_ & "'")

        Decimal_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "Decimal", "ID = '" & VC_ID_ & "'")

        Unit1_ID = Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "Unit1", "ID = '" & VC_ID_ & "'")

        Conversion_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "Conversion", "ID = '" & VC_ID_ & "'")

        Unit2_ID = Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "Unit2", "ID = '" & VC_ID_ & "'")

        Unit1_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "Symbol", "ID = '" & Unit1_ID & "'")
        Unit2_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "Symbol", "ID = '" & Unit2_ID & "'")
    End Function
    Private Sub Unit_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End
        Add_Hander_Remove_Handel(False)
        List_frm.Dispose()
        Frm_foCus()
    End Sub
    Dim Duplicate_Type As String
    Dim Duplicate_Type1 As String

    Dim Duplicate_Alias_Type As String
    Dim Duplicate_Alias_Type1 As String

    Dim Head_Type As String
    Private Function Save_Requr() As Boolean

        If Type_TXT.Text = "Compound" Then
            If Val(Conversion_TXT.Text) <= 1 Then
                Msg(NOT_Type.Warning, "Input Error", "Conversion Not allowed 0 or 1")
                Conversion_TXT.Focus()
                Exit Function
            End If
            If Chack_Duplicate(Database_File.cre, "TBL_Inventory_Unit", "Symbol", " Symbol = '" & Unit1_TXT.Text & "'") = False Then
                Msg(NOT_Type.Warning, "Unit1 select error", Text_Action(vl.Select_Current, ("Unit 1")))
                Unit1_TXT.Focus()
                Return False
                Exit Function
            Else
                Unit1_ID = Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "ID", " Symbol = '" & Unit1_TXT.Text & "'")
            End If

            If Chack_Duplicate(Database_File.cre, "TBL_Inventory_Unit", "Symbol", " Symbol = '" & Unit2_TXT.Text & "'") = False Then
                Msg(NOT_Type.Warning, "Unit2 select error", Text_Action(vl.Select_Current, ("Unit 2")))
                Unit2_TXT.Focus()
                Return False
                Exit Function
            Else
                Unit2_ID = Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "ID", " Symbol = '" & Unit2_TXT.Text & "'")
            End If
        ElseIf Type_TXT.Text = "Simple" Then
            If Symbol_TXT.Text = "" Then
                Msg(NOT_Type.Warning, "Input Error - Symbol", Text_Action(vl.Input_Error_Blank, ("Symbol")))
                Symbol_TXT.Focus()
                Return False
                Exit Function
            End If
            If Symbol_TXT.Text = Formal_TXT.Text Then
                Msg(NOT_Type.Warning, "Match - Symbol and formal", "Symbol and formal name is sam, please change symbol or formal name")
                Symbol_TXT.Focus()
                Return False
                Exit Function
            End If
            If Chack_Duplicate(Database_File.cre, "TBL_Inventory_Unit", "Symbol", Duplicate_Type) = True Then
                Msg(NOT_Type.Warning, "Duplicate - Unit", Text_Action(vl.Already_Exists, ("Unit")))
                Return False
                Exit Function
            End If
            If Chack_Duplicate(Database_File.cre, "TBL_Inventory_Unit", "Formal_Name", Duplicate_Type1) = True Then
                Msg(NOT_Type.Warning, "Duplicate - Unit", Text_Action(vl.Already_Exists, ("Unit")))
                Return False
                Exit Function
            End If
            ''
            If Chack_Duplicate(Database_File.cre, "TBL_Inventory_Unit", "Symbol", Duplicate_Alias_Type) = True Then
                Msg(NOT_Type.Warning, "Duplicate - Formal Name", Text_Action(vl.Already_Exists, ("Formal Name")))
                Return False
                Exit Function
            End If

            If Chack_Duplicate(Database_File.cre, "TBL_Inventory_Unit", "Formal_Name", Duplicate_Alias_Type1) = True And Formal_TXT.Text <> "" Then
                Msg(NOT_Type.Warning, "Duplicate - Formal Name", Text_Action(vl.Already_Exists, ("Formal Name")))
                Return False
                Exit Function
            End If
        End If

        Return True
    End Function
    Private Function Insurt_Value() As Boolean
        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            If open_MSSQL(Database_File.cre) Then
                qury = "INSERT INTO TBL_Inventory_Unit (Type,Symbol,Formal_Name,UQC,Decimal,Unit1,Conversion,Unit2,Head,Company,[User],Date_install,Visible,PC) VALUES (@Type,@Symbol,@Formal_Name,@UQC,@Decimal,@Unit1,@Conversion,@Unit2,@Head,@Company,@User,@Install_,@Visible,@PC)"
                cmd = New SQLiteCommand(qury, con)
                Try
                    With cmd.Parameters
                        .AddWithValue("@Type", Type_TXT.Text.Trim)
                        If Type_TXT.Text = "Compound" Then
                            .AddWithValue("@Symbol", Unit1_TXT.Text & " of " & Val(Conversion_TXT.Text) & " " & Unit2_TXT.Text)
                            .AddWithValue("@Formal_Name", "".Trim)
                            .AddWithValue("@UQC", "".Trim)
                            .AddWithValue("@Decimal", "0")
                            .AddWithValue("@Unit1", Unit1_ID)
                            .AddWithValue("@Conversion", Val(Conversion_TXT.Text))
                            .AddWithValue("@Unit2", Unit2_ID)
                        Else
                            .AddWithValue("@Symbol", Symbol_TXT.Text.Trim)
                            .AddWithValue("@Formal_Name", Formal_TXT.Text.Trim)
                            .AddWithValue("@UQC", QUC_TXT.Text.Trim)
                            .AddWithValue("@Decimal", Val(Decimal_TXT.Text))
                            .AddWithValue("@Unit1", "")
                            .AddWithValue("@Conversion", "0")
                            .AddWithValue("@Unit2", "")
                        End If
                        .AddWithValue("@Company", Company_ID_str)
                        .AddWithValue("@User", LOGIN_ID)
                        .AddWithValue("@PC", PC_ID.Trim)
                        .AddWithValue("@Install_", CDate(DateTime.Now))
                        .AddWithValue("@Visible", "Approval")
                        If BG_frm.From_ID = From_ID Then
                            .AddWithValue("@Head", "Stock")
                        ElseIf BG_frm.From_ID = From_ID Then
                            .AddWithValue("@Head", "Payroll")
                        End If
                        cmd.ExecuteNonQuery()
                    End With
                    Return True
                Catch ex As Exception
                    Msg(NOT_Type.Erro, "Data save error", ex.Message)
                    Return False
                End Try
            End If
        Else
            If open_MSSQL(Database_File.cre) Then
                qury = "UPDATE TBL_Inventory_Unit SET Type = @Type,Symbol = @Symbol,Formal_Name = @Formal_Name,UQC = @UQC,Decimal = @Decimal,Unit1 = @Unit1,Conversion = @Conversion,Unit2 = @Unit2,[User] = @User,Date_install = @Install_,PC = @PC WHERE ID = '" & VC_ID_ & "'"
                cmd = New SQLiteCommand(qury, con)
                Try
                    With cmd.Parameters
                        .AddWithValue("@Type", Type_TXT.Text.Trim)
                        If Type_TXT.Text = "Compound" Then
                            .AddWithValue("@Symbol", Unit1_TXT.Text & " of " & Val(Conversion_TXT.Text) & " " & Unit2_TXT.Text)
                            .AddWithValue("@Formal_Name", "".Trim)
                            .AddWithValue("@UQC", "".Trim)
                            .AddWithValue("@Decimal", "0")
                            .AddWithValue("@Unit1", Unit1_ID)
                            .AddWithValue("@Conversion", Val(Conversion_TXT.Text))
                            .AddWithValue("@Unit2", Unit2_ID)
                        Else
                            .AddWithValue("@Symbol", Symbol_TXT.Text.Trim)
                            .AddWithValue("@Formal_Name", Formal_TXT.Text.Trim)
                            .AddWithValue("@UQC", QUC_TXT.Text.Trim)
                            .AddWithValue("@Decimal", Val(Decimal_TXT.Text))
                            .AddWithValue("@Unit1", "")
                            .AddWithValue("@Conversion", "0")
                            .AddWithValue("@Unit2", "")
                        End If
                        .AddWithValue("@User", LOGIN_ID)
                        .AddWithValue("@PC", PC_ID.Trim)
                        .AddWithValue("@Install_", CDate(DateTime.Now))
                        cmd.ExecuteNonQuery()
                    End With
                    Return True
                Catch ex As Exception
                    Msg(NOT_Type.Erro, "Data save error", ex.Message)
                    Return False
                End Try
            End If
        End If
    End Function
    Private Function Clear_all()
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            'BG_frm.All_Unit_BS.DataSource = Nothing
            'BG_frm.All_Unit_BS.DataSource = Fill_All_Unit(cn)
        End If
        If VC_Type_ = "Create" Then
            Symbol_TXT.Text = ""
            Formal_TXT.Text = ""
            QUC_TXT.Text = ""
            Decimal_TXT.Text = "0"

            Unit1_TXT.Text = ""
            Conversion_TXT.Text = ""
            Unit2_TXT.Text = ""

            If Type_TXT.Text = "Compound" Then
                Unit1_TXT.Focus()
                NOT_("The entry you entered has been successfully accepted", NOT_Type.Success)
            Else
                Symbol_TXT.Focus()
                NOT_("The entry you entered has been successfully accepted", NOT_Type.Success)
            End If
        ElseIf VC_Type_ = "Alter_Close" Or VC_Type_ = "Create_Close" Then

            If Type_TXT.Text = "Compound" Then
                close_focus_obj.Text = Unit1_TXT.Text & " of " & Val(Conversion_TXT.Text) & " " & Unit2_TXT.Text
            Else
                close_focus_obj.Text = Symbol_TXT.Text
            End If

            Me.Dispose()
            close_focus_obj.Focus()
        Else
            Me.Dispose()
        End If
    End Function

    Private Sub Decimal_TXT_TextChanged(sender As Object, e As EventArgs) Handles Decimal_TXT.TextChanged
        Decimal_TXT.MaxLength = 1
    End Sub

    Private Function Name_aLlow() As Boolean
        If BG_frm.From_ID = From_ID Then
            Head_Type = " and Head = 'Stock'"
        ElseIf BG_frm.From_ID = From_ID Then
            Head_Type = " and Head = 'Payroll'"
        End If

        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            Duplicate_Type = " Symbol = '" & Symbol_TXT.Text & "' COLLATE NOCASE " & Head_Type
        Else
            Duplicate_Type = " (Symbol = '" & Symbol_TXT.Text & "' COLLATE NOCASE  and ID <> '" & VC_ID_ & "')" & Head_Type
        End If
        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            Duplicate_Type1 = " Formal_Name = '" & Symbol_TXT.Text & "' COLLATE NOCASE " & Head_Type
        Else
            Duplicate_Type1 = " Formal_Name = '" & Symbol_TXT.Text & "' COLLATE NOCASE  and ID <> '" & VC_ID_ & "'" & Head_Type
        End If

        If Symbol_TXT.Text = "" Then
            NOT_("Not Valid Without a Blank 'Name'", NOT_Type.Warning)
            Return False
        End If


        If Chack_Duplicate(Database_File.cre, "TBL_Inventory_Unit", "Symbol", Duplicate_Type) = True Then
            NOT_("The Symbol Entered is a 'Duplicate'", NOT_Type.Warning)
            Msg_Duplicat(Symbol_TXT, "Symbol")

            Return False
            Exit Function
        ElseIf Chack_Duplicate(Database_File.cre, "TBL_Inventory_Unit", "Formal_Name", Duplicate_Type1) = True Then
            NOT_("The Symbol Entered is a 'Duplicate'", NOT_Type.Warning)
            Msg_Duplicat(Symbol_TXT, "Symbol")
            Return False
            Exit Function
        Else
            NOT_Clear()
            Return True
        End If
        Return True
    End Function

    Private Sub Symbol_TXT_Enter(sender As Object, e As EventArgs) Handles Symbol_TXT.Enter
        Name_aLlow()
    End Sub
    Private Sub Symbol_TXT_TextChanged(sender As Object, e As EventArgs) Handles Symbol_TXT.TextChanged
        Name_aLlow()
    End Sub
    Private Sub Symbol_TXT_LostFocus(sender As Object, e As EventArgs) Handles Symbol_TXT.LostFocus

    End Sub
    Private Function Alias_aLlow() As Boolean
        If BG_frm.From_ID = From_ID Then
            Head_Type = " and Head = 'Stock'"
        ElseIf BG_frm.From_ID = From_ID Then
            Head_Type = " and Head = 'Payroll'"
        End If

        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            Duplicate_Alias_Type = " Symbol = '" & Formal_TXT.Text & "' COLLATE NOCASE " & Head_Type
        Else
            Duplicate_Alias_Type = " Symbol = '" & Formal_TXT.Text & "' COLLATE NOCASE  and ID <> '" & VC_ID_ & "'" & Head_Type
        End If

        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            Duplicate_Alias_Type1 = " Formal_Name = '" & Formal_TXT.Text & "' COLLATE NOCASE " & Head_Type
        Else
            Duplicate_Alias_Type1 = " Formal_Name = '" & Formal_TXT.Text & "' COLLATE NOCASE  and ID <> '" & VC_ID_ & "'" & Head_Type
        End If

        If Formal_TXT.Text <> "" Then
            If Symbol_TXT.Text = Formal_TXT.Text Then
                NOT_("Symbol and Formal Name is Sam", NOT_Type.Warning)
                Msg_Duplicat(Formal_TXT, "Formal Name")
                Return False
                Exit Function
            End If

            If Chack_Duplicate(Database_File.cre, "TBL_Inventory_Unit", "Formal_Name", Duplicate_Alias_Type) = True Then
                NOT_("The Formal Name Entered is a 'Duplicate'", NOT_Type.Warning)
                Msg_Duplicat(Formal_TXT, "Formal Name")
                Return False
                Exit Function
            ElseIf Chack_Duplicate(Database_File.cre, "TBL_Inventory_Unit", "Symbol", Duplicate_Alias_Type1) = True Then
                NOT_("The Formal Name Entered is a 'Duplicate'", NOT_Type.Warning)
                Msg_Duplicat(Formal_TXT, "Formal Name")
                Return False
                Exit Function
            Else
                NOT_Clear()
                Return True
            End If
        Else
            Return True
        End If
    End Function
    Private Sub FormalName_TXT_Enter(sender As Object, e As EventArgs) Handles Formal_TXT.Enter
        Alias_aLlow()
    End Sub
    Private Sub FormalName_TXT_TextChanged(sender As Object, e As EventArgs) Handles Formal_TXT.TextChanged
        Alias_aLlow()
    End Sub
    Private Sub FormalName_TXT_LostFocus(sender As Object, e As EventArgs) Handles Formal_TXT.LostFocus
        If Alias_aLlow() = False Then
            Formal_TXT.Focus()
        End If
    End Sub
    Private Sub Decimal_TXT_LostFocus(sender As Object, e As EventArgs) Handles Decimal_TXT.LostFocus
        If Val(Decimal_TXT.Text) > 5 Then
            Decimal_TXT.Focus()
        End If
    End Sub

    Private Sub Unit1_TXT_LostFocus(sender As Object, e As EventArgs) Handles Unit1_TXT.LostFocus
        Compund_UnitFilter_set()
    End Sub

    Private Sub Unit2_TXT_LostFocus(sender As Object, e As EventArgs) Handles Unit2_TXT.LostFocus

        If Unit2_ID = Unit1_ID Then
            Msg(NOT_Type.Warning, "Input Error", "Unit and Alternate Units is same, Please change Alternate Units and try again")
            Unit2_TXT.Text = ""
            Unit_Source.MoveFirst()
            Unit2_ID = Nothing
            Unit2_TXT.Focus()
        End If

        Compund_UnitFilter_set()
    End Sub

    Private Sub QUC_TXT_DragOver(sender As Object, e As DragEventArgs) Handles QUC_TXT.DragOver

    End Sub

    Private Sub Txt1_TextChanged(sender As Object, e As EventArgs) Handles Type_TXT.TextChanged
        If Type_TXT.Text = "Compound" Then
            Panel8.Hide()
            Panel7.Show()
        ElseIf Type_TXT.Text = "Simple" Then
            Panel8.Show()
            Panel7.Hide()
        End If
    End Sub

    Private Sub Unit1_TXT_TextChanged(sender As Object, e As EventArgs) Handles Unit1_TXT.TextChanged

    End Sub

    Private Sub Unit2_TXT_TextChanged(sender As Object, e As EventArgs) Handles Unit2_TXT.TextChanged

    End Sub

    Private Sub Unit2_TXT_Enter(sender As Object, e As EventArgs) Handles Unit2_TXT.Enter
        Compund_UnitFilter_set()
    End Sub

    Private Sub Focus_TXT_TextChanged(sender As Object, e As EventArgs) Handles Focus_TXT.TextChanged

    End Sub

    Private Sub Focus_TXT_Enter(sender As Object, e As EventArgs) Handles Focus_TXT.Enter
        If Type_TXT.Text = "Compound" Then
            If Unit2_ID = Unit1_ID Then
                Unit2_TXT.Focus()
                Exit Sub
            End If
        End If


        Dim result As DialogResult = Msg_Save_YN(Symbol_TXT, Stock_Pay)

        If result = DialogResult.Yes Then
            Save_Data()
        ElseIf result = DialogResult.No Then
            Symbol_TXT.Focus()
        ElseIf result = DialogResult.Cancel Then
            SendKeys.Send("{BACKSPACE}")
        End If
    End Sub

    Private Sub Unit1_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles Unit1_TXT.KeyDown
        If e.KeyCode = Keys.Enter Then
            Unit1_ID = comp_list.List_Grid.CurrentRow.Cells(2).Value
        End If
    End Sub

    Private Sub Unit2_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles Unit2_TXT.KeyDown
        If e.KeyCode = Keys.Enter Then
            Unit2_ID = comp_list.List_Grid.CurrentRow.Cells(2).Value
        End If
    End Sub

    Private Sub Unit_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
    End Sub
End Class