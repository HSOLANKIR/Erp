Imports System.Data.SQLite
Imports Tools

Public Class Item_info_Laboratory
    Dim Path_End As String
    Dim VC_Type_ As String
    Dim VC_ID_ As String

    Dim Unit_Type As String
    Dim Unit_A_Type As String

    Public close_focus_obj As TXT
    Private Sub Item_info_Laboratory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Path_End = BG_frm.BG_Path_TXT.Text
        VC_Type_ = Link_Valu(1)
        VC_ID_ = Link_Valu(2)
        data_cfg()

        BG_frm.HADE_TXT.Text = "Item Info"
        BG_frm.TYP_TXT.Text = VC_Type_

        Load_Data()
        List_set()

        If VC_Type_ = "Display" Or VC_Type_ = "Display_Close" Then
            Display_Fill_All()
            Me.Enabled = False
        ElseIf VC_Type_ = "Alter" Then
            Me.Enabled = True
            Display_Fill_All()
        ElseIf VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then

        End If

        Button_Manage()
        Add_Hander_Remove_Handel(True)
        Name_TXT.Focus()
    End Sub

    Private Sub Item_info_Laboratory_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.HADE_TXT.Text = "Item Info"
        BG_frm.TYP_TXT.Text = VC_Type_
        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text

        Button_Clear()
        Button_Manage()
        cfg_fill()

        Load_Data()

        Name_TXT.Focus()
    End Sub
    Private Function data_cfg()
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then

        End If
    End Function
    Private Function Load_Data()
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            Dim dt As New DataTable
            dt.Columns.Add("Symbol")
            dt.Columns.Add("Formal_Name")
            dt.Columns.Add("ID")
            dt.Columns.Add("Name")
            dt.Columns.Add("Type")
            dt.Columns.Add("UQC")
            dt.Columns.Add("Decimal")
            dt.Columns.Add("Unit1")
            dt.Columns.Add("Conversion")
            dt.Columns.Add("Unit2")
            dt.Rows.Add("(Not Applicable)", "", "", "", "Not Applicable")

            cmd = New SQLiteCommand("Select * From TBL_Inventory_Unit where " & Company_Visible_Filter, cn)
            Dim r As SQLiteDataReader
            Dim dr As DataRow
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
            Unit_Source.DataSource = dt
        End If
    End Function
    Dim unit_list As List_frm
    Dim unit_alter_list As List_frm
    Private Function List_set()
        unit_list = New List_frm
        List_Setup("List of Units", Select_List.Right, Select_List_Format.Defolt, Unit_TXT, unit_list, Unit_Source, 320, {"Create|Alt + C", "Alter|Ctrl + Enter"})

        unit_alter_list = New List_frm
        List_Setup("List of Units", Select_List.Right, Select_List_Format.Defolt, TextBox1, unit_alter_list, Unit_Source, 320, {"Create|Alt + C", "Alter|Ctrl + Enter"})
    End Function
    Private Function cfg_fill()

    End Function

    Private Sub Item_info_Laboratory_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If Msg_Exit_YN("Unit " & VC_Type_) = DialogResult.Yes Then
                Me.Dispose()
                If VC_Type_ = "Alter_Close" Or VC_Type_ = "Create_Close" Then
                    close_focus_obj.Focus()
                End If
            End If
        End If
    End Sub
    Private Function Display_Fill_All()
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select * From TBL_Stock_Item where ID = '{VC_ID_}'", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                Name_TXT.Text = r("Name").ToString
                Alias_TXT.Text = r("Alias").ToString
                Unit_ID = r("Unit").ToString
                Unit_A_ID = r("Alter_Unit").ToString
                defolt_value_txt.Text = r("Defolt_Value").ToString
                Rate_TXT.Text = r("MRP").ToString
                TextBox2.Text = r("Alter_Unit_Val1").ToString
                TextBox3.Text = r("Alter_Unit_Val2").ToString

                M_H.Text = r("Male_H").ToString
                M_L.Text = r("Male_L").ToString

                F_H.Text = r("Female_H").ToString
                F_L.Text = r("Female_L").ToString

                CM_H.Text = r("Child_M_H").ToString
                CM_L.Text = r("Child_M_L").ToString

                CF_H.Text = r("Child_F_H").ToString
                CF_L.Text = r("Child_F_L").ToString

            End While
            r.Close()
        End If
        cn.Close()

        Unit_TXT.Text = Find_DT_Unit_Conves(Unit_ID)
        TextBox1.Text = Find_DT_Unit_Conves(Unit_A_ID)


        Unit_Type = Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "Type", "ID = '" & Unit_ID & "'")
        Unit_A_Type = Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "Type", "ID = '" & Unit_A_ID & "'")

        Name_aLlow()
        Alias_aLlow()

        Alter_Unit_set()

    End Function

    Private Sub Item_info_Laboratory_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End
        Add_Hander_Remove_Handel(False)
        Frm_foCus()
    End Sub
    Private Function Button_Manage()
        Button_Clear()
        BG_frm.B_1.Text = "&E : Exit"
        BG_frm.B_2.Text = "&S : Save"
        If VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close" Then
            BG_frm.B_3.Text = "&D : Delete"
        End If

        If Login_Type = "Admin Account" And (VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close") Then
            'BG_frm.B_4.Text = "|&O : Audit"
        End If
    End Function
    Private Function Add_Hander_Remove_Handel(Ans As Boolean)
        If Ans = True Then
            AddHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            AddHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
            AddHandler BG_frm.B_3.Click, AddressOf Me.B_3_Click
        Else
            RemoveHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            RemoveHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
            RemoveHandler BG_frm.B_3.Click, AddressOf Me.B_3_Click
        End If
    End Function
    Private Sub B_1_Click(sender As Object, e As EventArgs)
        If BG_frm.HADE_TXT.Text = "Item Info" Then
            Me.Dispose()
        End If
    End Sub
    Private Sub B_2_Click(sender As Object, e As EventArgs)
        If BG_frm.HADE_TXT.Text = "Item Info" Then
            Save_Data()
        End If
    End Sub
    Private Sub B_3_Click(sender As Object, e As EventArgs)
        If BG_frm.HADE_TXT.Text = "Item Info" Then
            If VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close" Then
                Delete_Data()
            End If
        End If
    End Sub
    Private Function Save_Data()
        If Save_Requr() = True Then
            If Insurt_Value() = True Then
                Clear_all()
            End If
        End If
    End Function
    Private Function Delete_Data()
        Dim cn As New SQLiteConnection
        If Chack_Delete_Allow() = True Then
            If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                If Msg_Delete_YN(Name_TXT, "Stock Item") = DialogResult.Yes Then
                    qury = "UPDATE TBL_Stock_Item SET Visible = @Visible,[User] = @User,Date_Install = @Install_,PC = @PC WHERE ID  = '" & VC_ID_ & "'"
                    cmd = New SQLiteCommand(qury, cn)
                    With cmd.Parameters
                        .AddWithValue("@Visible", "Delete")
                        .AddWithValue("@User", LOGIN_ID.Trim)
                        .AddWithValue("@PC", PC_ID.Trim)
                        .AddWithValue("@Install_", CDate(DateTime.Now))
                        cmd.ExecuteNonQuery()
                    End With
                    Clear_all()
                End If
            End If
        Else
                Msg(NOT_Type.Info, "You cannot delete", "You cannot delete this godown because the godown you selected is made up of vouchers")
            End If
            End Function
    Private Function Chack_Delete_Allow() As Boolean
        Dim isavalable As Boolean = True
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select count(*) as count, 'Vouchers' as Type From TBL_VC_item_Details vi where 
(vi.Item = '{VC_ID_}') and 
(Select vc.Visible From TBL_VC vc where vc.Tra_ID = vi.Tra_ID) = 'Approval'
UNION ALL
Select count(*) as count, 'Stock Item BOM' as Type From TBL_Batch_Item bi where 
(bi.Item = '{VC_ID_}') and 
(Select it.Visible From TBL_Stock_Item it where it.id = (Select B.Item From TBL_Batch B where B.id = bi.Batch)) = 'Approval'
UNION ALL

Select count(*), 'Defolt Stock Item' as Type From TBL_Stock_Item it WHERE
it.id = '{VC_ID_}' and
it.Company = 'All'", cn)

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
    Private Function Insurt_Value() As Boolean
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
                Dim qry As String = "INSERT INTO TBL_Stock_Item (Name,Under,Alias,Unit,Company,Visible,Alter_Unit,Alter_Unit_Val1,Alter_Unit_Val2,MRP,[User],Date_install,PC,Defolt_Value,Male_H,Male_L,Female_H,Female_L,Child_M_H,Child_M_L,Child_F_H,Child_F_L) VALUES (@Name,@Under,@Alias,@Unit,@Company,@Visible,@Alter_Unit,@Alter_Unit_Val1,@Alter_Unit_Val2,@MRP,@User,@Install_,@PC,@Defolt_Value,@Male_H,@Male_L,@Female_H,@Female_L,@Child_M_H,@Child_M_L,@Child_F_H,@Child_F_L)"
                cmd = New SQLiteCommand(qry, cn)

                Try
                    With cmd.Parameters
                        .AddWithValue("@Name", Name_TXT.Text.Trim)
                        .AddWithValue("@Under", "NA")
                        .AddWithValue("@Alias", Alias_TXT.Text.Trim)
                        .AddWithValue("@Unit", Unit_ID.ToString.Trim)
                        .AddWithValue("@MRP", Val(Rate_TXT.Text))
                        .AddWithValue("@Company", Company_ID_str)
                        .AddWithValue("@User", LOGIN_ID)
                        .AddWithValue("@PC", PC_ID.Trim)
                        .AddWithValue("@Install_", CDate(DateTime.Now))
                        .AddWithValue("@Visible", "Approval")
                        If TextBox1.Text = "(Not Applicable)" Then
                            .AddWithValue("@Alter_Unit", "0")
                            .AddWithValue("@Alter_Unit_Val1", "0")
                            .AddWithValue("@Alter_Unit_Val2", "0")
                        Else
                            .AddWithValue("@Alter_Unit", Unit_A_ID.ToString.Trim)
                            .AddWithValue("@Alter_Unit_Val1", TextBox2.Text.Trim)
                            .AddWithValue("@Alter_Unit_Val2", TextBox3.Text.Trim)
                        End If
                        .AddWithValue("@Defolt_Value", defolt_value_txt.Text.Trim)
                        .AddWithValue("@Male_H", M_H.Text.Trim)
                        .AddWithValue("@Male_L", M_L.Text.Trim)
                        .AddWithValue("@Female_H", F_H.Text.Trim)
                        .AddWithValue("@Female_L", F_L.Text.Trim)
                        .AddWithValue("@Child_M_H", CM_H.Text.Trim)
                        .AddWithValue("@Child_M_L", CM_L.Text.Trim)
                        .AddWithValue("@Child_F_H", CF_H.Text.Trim)
                        .AddWithValue("@Child_F_L", CF_L.Text.Trim)
                        cmd.ExecuteNonQuery()
                    End With
                    Return True
                Catch ex As Exception
                    Msg_Custom_YN(NOT_Location.Bottom_Right, Color.Red, My.Resources.Error_animation_icn, Dialoag_Button.Ok, "Error !", "Data Save Error", ex.Message)
                    Return False
                End Try
            Else
                Dim qry As String = "UPDATE TBL_Stock_Item SET Name = @Name,Alias = @Alias,Unit = @Unit,Alter_Unit = @Alter_Unit,Alter_Unit_Val1 = @Alter_Unit_Val1,Alter_Unit_Val2 = @Alter_Unit_Val2,MRP = @MRP,[User] = @User,Date_install = @Install_,PC = @PC,Defolt_Value = @Defolt_Value,Male_H = @Male_H,Male_L = @Male_L,Female_H = @Female_H,Female_L = @Female_L,Child_M_H = @Child_M_H,Child_M_L = @Child_M_L,Child_F_H = @Child_F_H,Child_F_L = @Child_F_L WHERE ID = '" & VC_ID_ & "'"
                cmd = New SQLiteCommand(qry, cn)
                Try
                    With cmd.Parameters
                        .AddWithValue("@Name", Name_TXT.Text.Trim)
                        .AddWithValue("@Alias", Alias_TXT.Text.Trim)
                        .AddWithValue("@Unit", Unit_ID.ToString.Trim)
                        .AddWithValue("@MRP", Val(Rate_TXT.Text))
                        .AddWithValue("@User", LOGIN_ID)
                        .AddWithValue("@PC", PC_ID.Trim)
                        .AddWithValue("@Install_", CDate(DateTime.Now))
                        If TextBox1.Text = "(Not Applicable)" Then
                            .AddWithValue("@Alter_Unit", "0")
                            .AddWithValue("@Alter_Unit_Val1", "0")
                            .AddWithValue("@Alter_Unit_Val2", "0")
                        Else
                            .AddWithValue("@Alter_Unit", Unit_A_ID.ToString.Trim)
                            .AddWithValue("@Alter_Unit_Val1", TextBox2.Text.Trim)
                            .AddWithValue("@Alter_Unit_Val2", TextBox3.Text.Trim)
                        End If
                        .AddWithValue("@Defolt_Value", defolt_value_txt.Text.Trim)
                        .AddWithValue("@Male_H", M_H.Text.Trim)
                        .AddWithValue("@Male_L", M_L.Text.Trim)
                        .AddWithValue("@Female_H", F_H.Text.Trim)
                        .AddWithValue("@Female_L", F_L.Text.Trim)
                        .AddWithValue("@Child_M_H", CM_H.Text.Trim)
                        .AddWithValue("@Child_M_L", CM_L.Text.Trim)
                        .AddWithValue("@Child_F_H", CF_H.Text.Trim)
                        .AddWithValue("@Child_F_L", CF_L.Text.Trim)
                        cmd.ExecuteNonQuery()
                    End With
                    Return True
                Catch ex As Exception
                    Msg(NOT_Type.Erro, "Data Save Error", ex.Message)
                    Return False
                End Try
            End If
        End If
    End Function
    Private Function Save_Requr() As Boolean
        If Name_TXT.Text = "" Then
            NOT_("Please enter name and try agin", NOT_Type.Erro)
            MsgBox("")
            Name_TXT.Focus()
            Return False
            Exit Function
        End If
        If Name_TXT.Text = Alias_TXT.Text Then
            NOT_("Please change (alias)", NOT_Type.Erro)
            Alias_TXT.Focus()
            Return False
            Exit Function
        End If
        If Chack_Duplicate(Database_File.cre, "TBL_Stock_Item", "Name", Duplicate_Type) = True Then
            NOT_("Name already exists please change name and try again", NOT_Type.Erro)

            Name_TXT.Focus()
            Return False
            Exit Function
        End If
        If Chack_Duplicate(Database_File.cre, "TBL_Stock_Item", "Alias", Duplicate_Type1) = True Then
            NOT_("Name already exists please change name and try again", NOT_Type.Erro)
            Return False
            Exit Function
        End If
        ''
        If Chack_Duplicate(Database_File.cre, "TBL_Stock_Item", "Name", Duplicate_Alias_Type) = True Then
            NOT_("Alias already exists please change name and try again", NOT_Type.Erro)
            Return False
            Exit Function
        End If

        If Chack_Duplicate(Database_File.cre, "TBL_Stock_Item", "Alias", Duplicate_Alias_Type1) = True And Alias_TXT.Text <> "" Then
            NOT_("Alias already exists please change name and try again", NOT_Type.Erro)
            Return False
            Exit Function
        End If

        If Unit_Type = "Simple" Then
            If Chack_Duplicate(Database_File.cre, "TBL_Inventory_Unit", "Symbol", " Symbol  = '" & Unit_TXT.Text & "'") = False Then
                NOT_("Unit select error, Please select again", NOT_Type.Erro)
                Unit_TXT.Focus()
                Return False
                Exit Function
            Else
                Unit_ID = Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "ID", " Symbol  = '" & Unit_TXT.Text & "'")
            End If
        ElseIf Unit_Type = "Compound" Then
            If Chack_Duplicate_unit_copund(Unit_ID, Unit_TXT.Text) = False Then
                NOT_("Unit select error, Please select again", NOT_Type.Erro)
                Unit_TXT.Focus()
                Return False
                Exit Function
            Else
                'Unit_ID = Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "ID", " Symbol  = '" & Unit_TXT.Text & "'")
            End If
        End If

        If TextBox1.Visible = True Then
            If Unit_A_Type = "Simple" Then
                If Chack_Duplicate(Database_File.cre, "TBL_Inventory_Unit", "Symbol", " Symbol  = '" & TextBox1.Text & "'") = False Then
                    NOT_("Unit select error, Please select again", NOT_Type.Erro)
                    TextBox1.Focus()
                    Return False
                    Exit Function
                Else
                    Unit_A_ID = Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "ID", " Symbol  = '" & TextBox1.Text & "'")
                End If
            ElseIf Unit_A_Type = "Compound" Then
                If Chack_Duplicate_unit_copund(Unit_A_ID, TextBox1.Text) = False Then
                    NOT_("Unit select error, Please select again", NOT_Type.Erro)
                    TextBox1.Focus()
                    Return False
                    Exit Function
                Else
                    'Unit_ID = Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "ID", " Symbol  = '" & Unit_TXT.Text & "'")
                End If
            End If

            If Val(TextBox2.Text) <= 0 And TextBox2.Visible = True Then
                NOT_("Value '0' is not allow", NOT_Type.Erro)
                TextBox2.Focus()
                Return False
                Exit Function
            End If

            If Val(TextBox3.Text) <= 0 And TextBox3.Visible = True Then
                NOT_("Value '0' is not allow", NOT_Type.Erro)
                TextBox3.Focus()
                Return False
                Exit Function
            End If
        End If
        Return True
    End Function
    Private Function Clear_all()
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            'BG_frm.Stock_Item_BS.DataSource = Nothing
            'BG_frm.Stock_Item_BS.DataSource = Fill_Stock_Item(cn)
        End If

        If VC_Type_ = "Create" Then
            Name_TXT.Text = ""
            Alias_TXT.Text = ""
            Unit_TXT.Text = ""
            TextBox1.Text = ""

            M_H.Text = ""
            M_L.Text = ""
            F_H.Text = ""
            F_L.Text = ""
            CM_H.Text = ""
            CM_L.Text = ""
            CF_H.Text = ""
            CF_L.Text = ""

            Name_TXT.Focus()

            NOT_("The entry you entered has been successfully accepted", NOT_Type.Success)
        ElseIf VC_Type_ = "Alter_Close" Or VC_Type_ = "Create_Close" Then
            close_focus_obj.Text = Name_TXT.Text
            Me.Dispose()
            close_focus_obj.Focus()
        ElseIf VC_Type_ = "Alter" Then
            Me.Dispose()
        End If
    End Function
    Private Sub Name_TXT_Enter(sender As Object, e As EventArgs) Handles Name_TXT.Enter
        Name_aLlow()
    End Sub
    Private Sub Name_TXT_TextChanged(sender As Object, e As EventArgs) Handles Name_TXT.TextChanged
        Name_aLlow()
    End Sub
    Private Sub Name_TXT_Lost_Focus(sender As Object, e As EventArgs) Handles Name_TXT.LostFocus
        If Name_aLlow() = False Then
            Name_TXT.Focus()
        End If
    End Sub
    Dim Duplicate_Type As String
    Dim Duplicate_Type1 As String
    Private Function Name_aLlow() As Boolean
        If BG_frm.HADE_TXT.Text = "Item Info" Then
            If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
                Duplicate_Type = " Name = '" & Name_TXT.Text & "' COLLATE NOCASE and " & Company_Visible_Filter
            Else
                Duplicate_Type = " Name = '" & Name_TXT.Text & "' COLLATE NOCASE and ID <> '" & VC_ID_ & "' and " & Company_Visible_Filter
            End If

            If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
                Duplicate_Type1 = " Alias = '" & Name_TXT.Text & "' COLLATE NOCASE  and " & Company_Visible_Filter
            Else
                Duplicate_Type1 = " Alias = '" & Name_TXT.Text & "' COLLATE NOCASE  and ID <> '" & VC_ID_ & "' and " & Company_Visible_Filter
            End If

            If Name_TXT.Text = "" Then
                'NOT_("Not Valid Without a Blank 'Name'", NOT_Type.Warning)
                Return False
                Exit Function
            End If

            If Chack_Duplicate(Database_File.cre, "TBL_Stock_Item", "Name", Duplicate_Type) = True Then
                NOT_("The Name Entered is a 'Duplicate'", NOT_Type.Warning)
                Msg_Duplicat(Name_TXT, "Item")
                Return False
                Exit Function
            ElseIf Chack_Duplicate(Database_File.cre, "TBL_Stock_Item", "Name", Duplicate_Type1) = True Then
                NOT_("The Name Entered is a 'Duplicate'", NOT_Type.Warning)
                Msg_Duplicat(Name_TXT, "Item")
                Return False
                Exit Function
            Else
                NOT_Clear()
                Return True
            End If
        End If
        Return True
    End Function
    Dim Unit_ID As String
    Dim Unit_A_ID As String
    Private Function Alter_Unit_set()
        If Unit_ID = Nothing Then
            Label31.Hide()
            Label30.Hide()
            Label32.Hide()
            Label33.Hide()
            TextBox2.Hide()
            TextBox3.Hide()
            Label29.Hide()
            Label28.Hide()
            TextBox1.Hide()
        Else
            Label32.Text = Unit_TXT.Text
            Label33.Text = TextBox1.Text
            If TextBox1.Text = "(Not Applicable)" Then
                Label31.Hide()
                Label30.Hide()
                Label32.Hide()
                Label33.Hide()
                TextBox2.Hide()
                TextBox3.Hide()
            Else
                Label31.Show()
                Label30.Show()
                Label32.Show()
                Label33.Show()
                TextBox2.Show()
                TextBox3.Show()
            End If
            Label29.Show()
            Label28.Show()
            TextBox1.Show()
        End If
    End Function

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Unit_A_ID = unit_list.List_Grid.CurrentRow.Cells(2).Value.ToString
            Unit_A_Type = unit_list.List_Grid.CurrentRow.Cells(4).Value.ToString
            If Unit_A_ID = Nothing Then
                Exit Sub
            End If
        End If

        If e.KeyCode = Keys.C AndAlso e.Modifiers = Keys.Alt Then
            Cell("Unit Info.", "", "Create_Close", "")
            Unit_frm.close_focus_obj = sender
        ElseIf e.KeyCode = Keys.Enter AndAlso e.Modifiers = Keys.Control Then
            Cell("Unit Info.", "", "Alter_Close", Unit_A_ID)
            Unit_frm.close_focus_obj = sender
        End If
    End Sub
    Private Sub Unit_KeyDown(sender As Object, e As KeyEventArgs) Handles Unit_TXT.KeyDown
        If e.KeyCode = Keys.Enter Then
            Unit_ID = unit_list.List_Grid.CurrentRow.Cells(2).Value.ToString
            Unit_Type = unit_list.List_Grid.CurrentRow.Cells(4).Value.ToString
            If Unit_ID = Nothing Then
                Exit Sub
            End If
        End If

        If e.KeyCode = Keys.C AndAlso e.Modifiers = Keys.Alt Then
            Cell("Unit Info.", "", "Create_Close", "")
            Unit_frm.close_focus_obj = sender
        ElseIf e.KeyCode = Keys.Enter AndAlso e.Modifiers = Keys.Control Then
            Cell("Unit Info.", "", "Alter_Close", Unit_ID)
            Unit_frm.close_focus_obj = sender
        End If
    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Alter_Unit_set()
    End Sub

    Private Sub Unit_TXT_TextChanged(sender As Object, e As EventArgs) Handles Unit_TXT.TextChanged
        Alter_Unit_set()
    End Sub
    Private Sub Unit_TXT_LostFocus(sender As Object, e As EventArgs) Handles Unit_TXT.LostFocus
        Alter_Unit_set()
    End Sub

    Private Sub Label29_Click(sender As Object, e As EventArgs) Handles Label29.Click

    End Sub

    Private Sub Panel21_Paint(sender As Object, e As PaintEventArgs) Handles Panel21.Paint

    End Sub
    Dim Duplicate_Alias_Type As String
    Dim Duplicate_Alias_Type1 As String

    Private Function Alias_aLlow() As Boolean
        If BG_frm.HADE_TXT.Text = "Item Info" Then
            If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
                Duplicate_Alias_Type = " Name  = '" & Alias_TXT.Text & "' COLLATE NOCASE  and " & Company_Visible_Filter
            Else
                Duplicate_Alias_Type = " Name  = '" & Alias_TXT.Text & "' COLLATE NOCASE  and ID <> '" & VC_ID_ & "' and " & Company_Visible_Filter
            End If

            If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
                Duplicate_Alias_Type1 = " Alias  = '" & Alias_TXT.Text & "' COLLATE NOCASE  and " & Company_Visible_Filter
            Else
                Duplicate_Alias_Type1 = " Alias  = '" & Alias_TXT.Text & "' COLLATE NOCASE  and ID <> '" & VC_ID_ & "' and " & Company_Visible_Filter

            End If
            If Alias_TXT.Text <> "" Then
                If Name_TXT.Text = Alias_TXT.Text Then
                    NOT_("Name and Alias is Sam", NOT_Type.Warning)
                    Msg_Duplicat(Alias_TXT, "Item")
                    Return False
                    Exit Function
                End If

                If Chack_Duplicate(Database_File.cre, "TBL_Stock_Item", "Nickname", Duplicate_Alias_Type) = True Then
                    NOT_("The Alias Entered is a 'Duplicate'", NOT_Type.Warning)
                    Msg_Duplicat(Alias_TXT, "Item")
                    Return False
                    Exit Function
                ElseIf Chack_Duplicate(Database_File.cre, "TBL_Stock_Item", "Name", Duplicate_Alias_Type1) = True Then
                    NOT_("The Alias Entered is a 'Duplicate'", NOT_Type.Warning)
                    Msg_Duplicat(Alias_TXT, "Item")
                    Return False
                    Exit Function
                Else
                    NOT_Clear()
                    Return True
                End If
            Else
                Return True
            End If
        End If
    End Function
    Private Sub Alias_TXT_Enter(sender As Object, e As EventArgs) Handles Alias_TXT.Enter
        Alias_aLlow()
    End Sub
    Private Sub Alias_TXT_TextChanged(sender As Object, e As EventArgs) Handles Alias_TXT.TextChanged
        Alias_aLlow()
    End Sub
    Private Sub Alias_TXT_LostFocus(sender As Object, e As EventArgs) Handles Alias_TXT.LostFocus
        If Alias_aLlow() = False Then
            Alias_TXT.Focus()
        End If
    End Sub

    Private Sub Txt9_TextChanged(sender As Object, e As EventArgs) Handles Rate_TXT.TextChanged

    End Sub

    Private Sub Txt9_LostFocus(sender As Object, e As EventArgs) Handles Rate_TXT.LostFocus
        Rate_TXT.Text = nUmBeR_FORMATE(Rate_TXT.Text)
    End Sub

    Private Sub Txt9_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Rate_TXT.KeyPress
        allow_Number(e)
    End Sub
    Private Sub save_TXT_Enter(sender As Object, e As EventArgs) Handles save_TXT.Enter
        Dim result As DialogResult = Msg_Save_YN(Name_TXT, "Group")

        If result = DialogResult.Yes Then
            Save_Data()
        ElseIf result = DialogResult.No Then
            Name_TXT.Focus()
        ElseIf result = DialogResult.Cancel Then
            SendKeys.Send("{BACKSPACE}")
        End If
    End Sub
End Class