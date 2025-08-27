Imports System.Data.SQLite
Imports System.IO
Imports System.Xml
Imports PopupControl
Imports Tools

Public Class Stock_Item_frm
    Dim From_ID As String
    Dim Under_ID As String
    Dim Under As String
    Dim Unit_ID As String
    Dim Unit_Type As String
    Dim Unit_A_ID As String
    Dim Unit_A_Type As String
    Dim Path_End As String
    Dim VC_Type_ As String
    Dim VC_ID_ As String
    Dim BOM_Alter_OPen As Boolean = False
    Public close_focus_obj As TXT

    Private Sub Stock_Item_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID


        Path_End = BG_frm.BG_Path_TXT.Text

        VC_Type_ = Link_Valu(1)
        VC_ID_ = Link_Valu(2)

        Update_Confi()

        DataGridView2.DataSource = BindingSource1

        ST_Rate_YN.Text = "No"
        BOM_YN.Text = "No"

        Fill_data_source()
        List_set()
        Set_msg()


        BG_frm.HADE_TXT.Text = "Stock Item"
        BG_frm.TYP_TXT.Text = VC_Type_
        If VC_Type_ = "Display" Or VC_Type_ = "Display_Close" Then
            Me.Enabled = False
            Display_Fill_All()
        ElseIf VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close" Then
            Me.Enabled = True
            Display_Fill_All()
        ElseIf VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then

        End If
        Batch_Data_Fill()

        Button_Manage()

        Add_Hander_Remove_Handel(True)
        Name_TXT.Focus()

    End Sub
    Dim sg_list As List_frm
    Dim unit_list As List_frm
    Dim unit_alter_list As List_frm
    Dim tax_list As List_frm
    Dim tax_per_list As List_frm
    Dim tax_type_list As List_frm
    Dim tax_applicapable_list As List_frm
    Dim Costing_List As List_frm
    Dim Marckating_List As List_frm
    Private Function List_set()
        sg_list = New List_frm
        List_Setup("List of Stock Groups", Select_List.Right_Dock, Select_List_Format.Defolt, Group_TXT, sg_list, Group_source, 320)
        sg_list.System_Data_integer = 1

        unit_list = New List_frm
        List_Setup("List of Units", Select_List.Right, Select_List_Format.Defolt, Unit_TXT, unit_list, Unit_Source, 320)
        unit_list.System_Data_integer = 1

        unit_alter_list = New List_frm
        List_Setup("List of Units", Select_List.Right, Select_List_Format.Defolt, Unit2TXT, unit_alter_list, UnitSource2, 320)
        unit_alter_list.System_Data_integer = 1

        tax_list = New List_frm
        List_Setup("Taxability Type", Select_List.Right, Select_List_Format.Singel, TAX_Type, tax_list, TAX_source, 100)

        tax_per_list = New List_frm
        List_Setup("GST Rate", Select_List.Right, Select_List_Format.Singel, Txt7, tax_per_list, GST_Prt_Source, 100)

        tax_type_list = New List_frm
        List_Setup("Supply Type", Select_List.Right, Select_List_Format.Singel, Txt1, tax_type_list, GST_Type_of_Supplay_BS, 150)
        tax_type_list.List_Grid.Columns(1).Visible = False
        tax_type_list.List_Grid.Columns(2).Visible = False

        tax_applicapable_list = New List_frm
        List_Setup("GST Applicable", Select_List.Right, Select_List_Format.Defolt, Txt2, tax_applicapable_list, GST_Applicable_Source, 150)
        tax_applicapable_list.List_Grid.Columns(1).Visible = False
        tax_applicapable_list.List_Grid.Columns(2).Visible = False

        Costing_List = New List_frm
        List_Setup("List of Costing Method", Select_List.Right, Select_List_Format.Singel, Txt4, Costing_List, Costing_Source, 200)

        Marckating_List = New List_frm
        List_Setup("List of Market Valuation", Select_List.Right, Select_List_Format.Singel, Txt3, Marckating_List, Marckating_Source, 200)
    End Function
    Dim msg_Name As Msg_frm
    Dim msg_alias As Msg_frm
    Private Function Set_msg()
        msg_Name = New Msg_frm
        Name_TXT.Msg_Object = msg_Name

        msg_alias = New Msg_frm
        Alias_TXT.Msg_Object = msg_alias
    End Function
    Public Discription_Note_YN As Boolean = False
    Public Alter_Unit_YN As Boolean = False
    Public GST_YN As Boolean = True
    Public Cess_YN As Boolean = False
    Public MRP_YN As Boolean = True
    Public Std_Rate_YN As Boolean = False
    Public BOM_YN_ As Boolean = False
    Public Costing_Method_YN As Boolean = False
    Public Market_Valuation_YN As Boolean = False

    Private Function Set_Cfg()
        Create_Database_Table()

        'Reorder Qty
        ReOrder_Panel.Visible = YN_Boolean(Find_Features(Features_Type.Selected_Company, Features_Head.Inventory, "Stock_Reorder_YN"), False)




        Dim cn As New SQLiteConnection
        Dim r As SQLiteDataReader
        open_MSSQL_Cstm(Database_File.lnk, cn)
        cmd = New SQLiteCommand("Select * From cfg_Item", cn)
        r = cmd.ExecuteReader()

        While r.Read
            Dim H As String = r("Head").ToString
            Dim V As String = r("Value").ToString


            If H = "Discription/Note_YN" Then Discription_Note_YN = YN_Boolean(V, False)
            If H = "Alternate_Units_YN" Then Alter_Unit_YN = YN_Boolean(V, False)
            If H = "Enable_GST_YN" Then GST_YN = YN_Boolean(V, True)
            If H = "Cess_Rate_YN" Then Cess_YN = YN_Boolean(V, False)
            If H = "MRP_YN" Then MRP_YN = YN_Boolean(V, True)
            If H = "Standard_Rate_YN" Then Std_Rate_YN = YN_Boolean(V, False)
            If H = "Costing_Method_YN" Then Costing_Method_YN = YN_Boolean(V, False)
            If H = "Market_Valuation_YN" Then Market_Valuation_YN = YN_Boolean(V, False)
        End While
        r.Close()

        'Branch


        Panel44.Visible = Discription_Note_YN
        Panel21.Visible = GST_YN
        'Cess
        Label53.Visible = Cess_YN
        Label58.Visible = Cess_YN
        Txt5.Visible = Cess_YN
        Label59.Visible = Cess_YN

        Panel36.Visible = MRP_YN
        Panel38.Visible = Std_Rate_YN
        Panel32.Visible = BOM_YN_

        Panel39.Visible = Costing_Method_YN
        Panel35.Visible = Market_Valuation_YN
    End Function
    Private Function Fill_data_source()
        Dim cn As New SQLiteConnection
        Dim dt As New DataTable
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            Dim dr As DataRow

            dt.Clear()
            dt.Columns.Add("Name")
            dt.Columns.Add("Nickname")
            dt.Columns.Add("ID")
            dt.Columns.Add("UnderID")
            dt.Columns.Add("Under")
            dt.Columns.Add("Head")
            dt.Rows.Add("", "Create")
            dt.Rows.Add("Primary", "", "0")
            cmd = New SQLiteCommand("Select * From TBL_Stock_Group where (Head = 'Stock' or Head = 'All') and Visible = 'Approval'", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                dr = dt.NewRow
                dr("Name") = r("Name").ToString
                dr("ID") = r("ID")
                dr("Nickname") = r("Nickname").ToString
                dr("UnderID") = r("Under").ToString
                dr("Under") = Find_DT_Value(Database_File.cre, "TBL_Stock_Group", "Name", "(Company = 'All' or Company = '" & Company_ID_str & "') and (Visible = 'Approval') and (ID = '" & r("Under") & "')")
                dr("Head") = r("Head").ToString
                dt.Rows.Add(dr)
            End While
            r.Close()

            Group_source.DataSource = dt

            Dim dt1 = New DataTable
            dt = New DataTable
            dt.Clear()
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

            dt.Rows.Add("", "Create", "", "", "", "", "", "", "")


            dt1.Clear()
            dt1.Columns.Add("Symbol")
            dt1.Columns.Add("Formal_Name")
            dt1.Columns.Add("ID")
            dt1.Columns.Add("Name")
            dt1.Columns.Add("Type")
            dt1.Columns.Add("UQC")
            dt1.Columns.Add("Decimal")
            dt1.Columns.Add("Unit1")
            dt1.Columns.Add("Conversion")
            dt1.Columns.Add("Unit2")

            dt1.Rows.Add("", "Create", "", "", "", "", "", "", "")
            dt1.Rows.Add("(Not Applicable)", "", "", "", "Not Applicable")

            cmd = New SQLiteCommand("Select * From TBL_Inventory_Unit where " & Company_Visible_Filter(), cn)
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


                dr = dt1.NewRow
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
                dt1.Rows.Add(dr)
            End While
            r.Close()

            Unit_Source.DataSource = dt
            UnitSource2.DataSource = dt1

            dt = New DataTable
            dt.Clear()
            dt.Columns.Add("Name")
            dt.Rows.Add("Taxable")
            dt.Rows.Add("Exempt")
            dt.Rows.Add("Nil Rated")
            dt.Rows.Add("Non-GST")

            TAX_source.DataSource = dt

            dt = New DataTable
            dt.Clear()
            dt.Columns.Add("Name")
            dt.Columns.Add("Per")

            'dt.Rows.Add("GST@0%", "0.00")
            dt.Rows.Add("GST@5%", "5")
            dt.Rows.Add("GST@18%", "18")
            dt.Rows.Add("GST@12%", "12")
            dt.Rows.Add("GST@28%", "28")

            GST_Prt_Source.DataSource = dt

            GST_Type_of_Supplay()
        End If
        cn.Close()


        dt = New DataTable
        dt.Columns.Add("Name")

        dt.Rows.Add("At Zero Price")
        dt.Rows.Add("Avg. Cost (as per period)")
        dt.Rows.Add("Last Vouchers")
        dt.Rows.Add("Std. Cost")
        dt.Rows.Add("Basic Purchase Rate")
        Costing_Source.DataSource = dt

        dt = New DataTable
        dt.Columns.Add("Name")

        dt.Rows.Add("At Zero Price")
        dt.Rows.Add("Avg. Price (as per period)")
        dt.Rows.Add("Last Sales Price")
        dt.Rows.Add("Std. Price")
        dt.Rows.Add("Basic Sales Rate")
        Marckating_Source.DataSource = dt


    End Function
    Private Function Fill_TAX(cn As SQLiteConnection) As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow

        dt.Clear()
        dt.Columns.Add("Name")
        dt.Columns.Add("NickName")
        dt.Columns.Add("ID")
        dt.Columns.Add("Per")
        'Name LIKE '%<value>%')
        cmd = New SQLiteCommand("Select * From TBL_TAX where Under = 'PURCHASE'", cn)
        Dim r As SQLiteDataReader
        r = cmd.ExecuteReader
        While r.Read
            dr = dt.NewRow
            dr("Name") = r("Name")
            dr("NickName") = ""
            dr("ID") = r("ID")
            dr("Per") = r("Percentage")
            dt.Rows.Add(dr)
        End While
        r.Close()

        Return dt
    End Function
    Public Function Button_Manage()
        Button_Clear()
        BG_frm.B_1.Text = "&E : Exit"
        BG_frm.B_2.Text = "&S : Save"

        If VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close" Then
            BG_frm.B_3.Text = "&D : Delete"
        End If
        BG_frm.B_4.Text = "|&T : Attach"
        If Login_Type = "Admin Account" And (VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close") Then
            BG_frm.B_5.Text = "|&O : Audit"
        End If

        BG_frm.R_3.Text = "|&I : Import Data"

        BG_frm.R_22.Text = "F12 : Configuration"

    End Function

    Private Function Add_Hander_Remove_Handel(Ans As Boolean)
        If Ans = True Then
            AddHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            AddHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
            AddHandler BG_frm.B_3.Click, AddressOf Me.B_3_Click
            AddHandler BG_frm.B_4.Click, AddressOf Me.B_4_Click
            AddHandler BG_frm.R_3.Click, AddressOf Me.R_3_Click


            If Login_Type = "Admin Account" And (VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close") Then
                AddHandler BG_frm.B_5.Click, AddressOf Me.B_5_Click
            End If

            AddHandler BG_frm.R_22.Click, AddressOf Me.B_11_Click

        Else
            RemoveHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            RemoveHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
            RemoveHandler BG_frm.B_3.Click, AddressOf Me.B_3_Click
            RemoveHandler BG_frm.B_4.Click, AddressOf Me.B_4_Click
            RemoveHandler BG_frm.R_3.Click, AddressOf Me.R_3_Click

            If Login_Type = "Admin Account" And (VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close") Then
                AddHandler BG_frm.B_5.Click, AddressOf Me.B_5_Click
            End If

            RemoveHandler BG_frm.R_22.Click, AddressOf Me.B_11_Click

        End If
    End Function
    Private Sub B_1_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Me.Dispose()
        End If
    End Sub
    Private Sub B_2_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Save_Data()
        End If
    End Sub
    Private Sub B_5_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Cell("Audit Analysis", "", "Stock Item", VC_ID_)
        End If
    End Sub
    Private Sub B_3_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            If VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close" Then
                If BG_frm.From_ID = From_ID Then
                    Delete_Data()
                End If
            End If
        End If
    End Sub
    Private Sub R_3_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Cell("Stock Item Import")
        End If
    End Sub
    Private Sub B_4_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            If VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close" Then
                Attage_cre_frm.Grid = Me.DataGridView1
                attage_display.Grid_ = DataGridView1

                Cell("Attach Display")
            End If
        End If
    End Sub
    Private Sub B_11_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Dim obj_bg As Object = Cell("Configuration", "")
            Dim obj As Object = New Item_cfg
            obj.obj = Me
            obj_bg.Set_Cfg(obj)
        End If
    End Sub
    Private Function Delete_Data()
        Dim cn As New SQLiteConnection
        open_MSSQL_Cstm(Database_File.cre, cn)


        If Chack_Delete_Allow() = True Then
            If Msg_Delete_YN(Name_TXT, "Stock Item") = DialogResult.Yes Then
                If Insurt_Audit() = True Then
                    cmd = New SQLiteCommand($"DELETE FROM TBL_Stock_Item Where ID = '{VC_ID_}';
DELETE FROM TBL_Stock_Item_Opning_Stock Where Item_ID = '{VC_ID_}';
DELETE FROM TBL_Batch Where Item = '{VC_ID_}';
DELETE FROM TBL_Batch_Item Where Item = '{VC_ID_}';
DELETE FROM TBL_Item_Rate Where Item = '{VC_ID_}';
", cn)
                    cmd.ExecuteNonQuery()
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
    Private Function Insurt_Audit() As Boolean
        If Val(VC_ID_) = 0 Then
            Return True
        End If

        If Audit_Save("TBL_Stock_Item", "ID", VC_ID_) = True Then
            If Audit_Save("TBL_Stock_Item_Opning_Stock", "Item_ID", VC_ID_) = True Then
                If Audit_Save("TBL_Batch", "Item", VC_ID_) = True Then
                    If Audit_Save("TBL_Batch_Item", "Item", VC_ID_) = True Then
                        If Audit_Save("TBL_Item_Rate", "Item", VC_ID_) = True Then

                            Return True
                        End If
                    End If
                End If
            End If
        End If
    End Function
    Private Function Save_Data()
        If BG_frm.HADE_TXT.Text = "Stock Item" Or BG_frm.HADE_TXT.Text = "Stock Item" Then
            If Save_Requr() = True Then
                If Insurt_Audit() = True Then
                    If Insurt_Value() = True Then
                        If Insurt_Requrid_Ledger() = True Then
                            If Insurt_Ledger_Branch_Value() = True Then
                                If Insurt_BOM_data() = True Then
                                    If Insurt_STD_Rate() = True Then
                                        If Document_Save() = True Then
                                            Clear_all()
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Function
    Private Sub Stock_Item_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.HADE_TXT.Text = "Stock Item"
        BG_frm.TYP_TXT.Text = VC_Type_
        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text
        Button_Clear()
        Button_Manage()



        Set_Cfg()

        Barcode_Panel.Visible = YN_Boolean(Find_DT_Value(Database_File.cmp, "TBL_Features", "Value", "Head = 'Barcode_YN'"))


        Fill_data_source()
        'Name_TXT.Focus()

        Batch_Panel.Visible = Batches_YN
    End Sub
    Dim Duplicate_Type As String
    Dim Duplicate_Type1 As String

    Dim Duplicate_Alias_Type As String
    Dim Duplicate_Alias_Type1 As String

    Dim Duplicate_Barcode As String
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
        If Barcode_TXT.Text <> Nothing Then
            If Chack_Duplicate(Database_File.cre, "TBL_Stock_Item", "Barcode", Duplicate_Barcode) = True And Alias_TXT.Text <> "" Then
                NOT_("Barcode already exists please change barcode and try again", NOT_Type.Erro)
                Return False
                Exit Function
            End If
        End If


        If Chack_Duplicate(Database_File.cre, "TBL_Stock_Group", "Name", " Name  = '" & Group_TXT.Text & "'") = False Then
            If Group_TXT.Text <> "Primary" Then
                NOT_("Under Group select error, Please select again", NOT_Type.Erro)
                Group_TXT.Focus()
                Return False
                Exit Function
            Else
                Under_ID = "0"
            End If
        Else
            Under_ID = Find_DT_Value(Database_File.cre, "TBL_Stock_Group", "ID", " Name  = '" & Group_TXT.Text & "'")
        End If

        'Compound Unit chack
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
        'Alter Chack

        If Unit2TXT.Visible = True Then
            If Unit_A_Type = "Simple" Then
                If Chack_Duplicate(Database_File.cre, "TBL_Inventory_Unit", "Symbol", " Symbol  = '" & Unit2TXT.Text & "'") = False Then
                    NOT_("Unit select error, Please select again", NOT_Type.Erro)
                    Unit2TXT.Focus()
                    Return False
                    Exit Function
                Else
                    Unit_A_ID = Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "ID", " Symbol  = '" & Unit2TXT.Text & "'")
                End If
            ElseIf Unit_A_Type = "Compound" Then
                If Chack_Duplicate_unit_copund(Unit_A_ID, Unit2TXT.Text) = False Then
                    NOT_("Unit select error, Please select again", NOT_Type.Erro)
                    Unit2TXT.Focus()
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

        If St_Rate_Chack() = False Then
            Exit Function
        End If

        If Unit_TXT.Text = "(Not Applicable)" Then
            Ob_Quanitity_TXT.Text = "0"
            Ob_Amt_TXT.Text = "0"
        End If

        'Chack_Rate_
        Return True
    End Function
    Private Function St_Rate_Chack() As Boolean
        If ST_Rate_YN.Text = "Yes" Then

        End If
        Return True
    End Function
    Private Function Insurt_Value() As Boolean
        If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
            If open_MSSQL(Database_File.cre) Then
                Dim St_ As String
                Dim St_1 As String
                For it As Integer = 0 To DataGridView2.Rows.Count - 1
                    Dim row As DataGridViewRow = DataGridView2.Rows(it)
                    If row.Cells(0).Value <> "@" And row.Cells(7).Value = "Under" Then
                        St_ &= "," & row.Cells(1).Value.ToString
                        St_1 &= ",@" & row.Cells(1).Value.ToString
                    End If
                Next
                qury = "INSERT INTO TBL_Stock_Item (Name,Alias,Barcode,Description,Under,Unit,HSN_Code,GST_Type,Tax_Type,OB_Quantity,OB_Rate,OB_per,OB_Value,Note,Costing_Method,Company,Visible,Alter_Unit,Alter_Unit_Val1,Alter_Unit_Val2,STD_Rate_YN,BOM_YN,MRP,[User],Date_install,PC,GST_Applicable,Batch_YN,Mfg_YN,Exp_YN,Costing_Value_Type,Market_Value_Type,TAX_Value,Cess_Value,Sales_Rate,Purchase_Rate,Reorder_Qty) VALUES (@Name,@Alias,@Barcode,@Description,@Under,@Unit,@HSN_Code,@GST_Type,@Tax_Type,@OB_Quantity,@OB_Rate,@OB_per,@OB_Value,@Note,@Costing_Method,@Company,@Visible,@Alter_Unit,@Alter_Unit_Val1,@Alter_Unit_Val2,@STD_Rate_YN,@BOM_YN,@MRP,@User,@Install_,@PC,@GST_Applicable,@Batch_YN,@Mfg_YN,@Exp_YN,@Costing_Value_Type,@Market_Value_Type,@TAX_Value,@Cess_Value,@Sales_Rate,@Purchase_Rate,@Reorder_Qty)"
                cmd = New SQLiteCommand(qury, con)
                Try
                    With cmd.Parameters
                        .AddWithValue("@Name", Name_TXT.Text.Trim)
                        .AddWithValue("@Alias", Alias_TXT.Text.Trim)
                        .AddWithValue("@Barcode", Barcode_TXT.Text.Trim)
                        .AddWithValue("@Description", Discription_TXT.Text.Trim)
                        If Group_TXT.Text = "Primary" Then
                            .AddWithValue("@Under", "0")
                        Else
                            .AddWithValue("@Under", Under_ID.ToString.Trim)
                        End If
                        .AddWithValue("@Unit", Unit_ID.ToString.Trim)
                        .AddWithValue("@HSN_Code", HSN_TXT.Text.Trim)
                        .AddWithValue("@GST_Type", Txt1.Text.ToString.Trim)
                        .AddWithValue("@Tax_Type", TAX_Type.Text.ToString.Trim)
                        .AddWithValue("@OB_Quantity", Val(Ob_Quanitity_TXT.Text))
                        .AddWithValue("@OB_Rate", "")
                        .AddWithValue("@OB_per", Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "ID", "Symbol  = '" & OB_Unit_Label.Text & "'").Trim)
                        .AddWithValue("@OB_Value", Val(Ob_Amt_TXT.Text))
                        .AddWithValue("@Note", Note_TXT.Text.Trim)
                        .AddWithValue("@Costing_Method", "")
                        .AddWithValue("@MRP", Val(MRP_TXT.Text))
                        .AddWithValue("@Company", Company_ID_str)
                        .AddWithValue("@User", LOGIN_ID)
                        .AddWithValue("@PC", PC_ID.Trim)
                        .AddWithValue("@Install_", CDate(DateTime.Now))
                        .AddWithValue("@Visible", "Approval")
                        .AddWithValue("@GST_Applicable", Txt2.Text)
                        .AddWithValue("@TAX_Value", nUmBeR_FORMATE(Label56.Text))
                        .AddWithValue("@Cess_Value", nUmBeR_FORMATE(Txt5.Text))
                        If Unit2TXT.Text = "(Not Applicable)" Then
                            .AddWithValue("@Alter_Unit", "0")
                            .AddWithValue("@Alter_Unit_Val1", "0")
                            .AddWithValue("@Alter_Unit_Val2", "0")
                        Else
                            .AddWithValue("@Alter_Unit", Unit_A_ID.ToString.Trim)
                            .AddWithValue("@Alter_Unit_Val1", TextBox2.Text.Trim)
                            .AddWithValue("@Alter_Unit_Val2", TextBox3.Text.Trim)
                        End If
                        If ST_Rate_YN.Visible = True Then
                            .AddWithValue("@STD_Rate_YN", ST_Rate_YN.Text.Trim)
                        Else
                            .AddWithValue("@STD_Rate_YN", "No".Trim)
                        End If
                        If BOM_YN.Visible = True Then
                            .AddWithValue("@BOM_YN", BOM_YN.Text.Trim)
                        Else
                            .AddWithValue("@BOM_YN", "No".Trim)
                        End If
                        If batch_YN.Text = "Yes" Then
                            .AddWithValue("@Batch_YN", "Yes".Trim)
                            .AddWithValue("@Mfg_YN", mfg_yn.Text.Trim)
                            .AddWithValue("@Exp_YN", exp_yn.Text.Trim)
                        Else
                            .AddWithValue("@Batch_YN", "No".Trim)
                            .AddWithValue("@Mfg_YN", "No".Trim)
                            .AddWithValue("@Exp_YN", "No".Trim)
                        End If
                        .AddWithValue("@Costing_Value_Type", Txt4.Text.Trim)
                        .AddWithValue("@Market_Value_Type", Txt3.Text.Trim)

                        .AddWithValue("@Sales_Rate", Val(0))
                        .AddWithValue("@Purchase_Rate", Val(0))
                        .AddWithValue("@Reorder_Qty", Val(Reorder_Qty_TXT.Text.Trim))

                        cmd.ExecuteNonQuery()
                    End With
                    Return True
                Catch ex As Exception
                    Msg(NOT_Type.Erro, "Data Save Error", ex.Message)
                    Return False
                End Try
            End If
        Else
            If open_MSSQL(Database_File.cre) Then
                qury = "UPDATE TBL_Stock_Item SET Name = @Name,Alias = @Alias,Barcode = @Barcode,Description = @Description,Under = @Under,Unit = @Unit,HSN_Code = @HSN_Code,Tax_Type = @Tax_Type,GST_Type = @GST_Type,OB_Quantity = @OB_Quantity,OB_Rate = @OB_Rate,OB_per = @OB_per,OB_Value = @OB_Value,Note = @Note,Costing_Method = @Costing_Method,Alter_Unit = @Alter_Unit,Alter_Unit_Val1 = @Alter_Unit_Val1,Alter_Unit_Val2 = @Alter_Unit_Val2,STD_Rate_YN = @STD_Rate_YN,BOM_YN = @BOM_YN,MRP = @MRP,[User] = @User,Date_install = @Install_,PC = @PC,GST_Applicable = @GST_Applicable,Batch_YN = @Batch_YN,Mfg_YN = @Mfg_YN,Exp_YN = @Exp_YN,Costing_Value_Type = @Costing_Value_Type,Market_Value_Type = @Market_Value_Type,TAX_Value = @TAX_Value,Cess_Value = @Cess_Value,Sales_Rate = @Sales_Rate,Purchase_Rate = @Purchase_Rate,Reorder_Qty = @Reorder_Qty WHERE ID = '" & VC_ID_ & "'"
                cmd = New SQLiteCommand(qury, con)
                Try
                    With cmd.Parameters
                        .AddWithValue("@Name", Name_TXT.Text.Trim)
                        .AddWithValue("@Alias", Alias_TXT.Text.Trim)
                        .AddWithValue("@Barcode", Barcode_TXT.Text.Trim)
                        .AddWithValue("@Description", Discription_TXT.Text.Trim)
                        If Group_TXT.Text = "Primary" Then
                            .AddWithValue("@Under", "0")
                        Else
                            .AddWithValue("@Under", Under_ID.ToString.Trim)
                        End If
                        .AddWithValue("@Unit", Unit_ID.ToString.Trim)
                        .AddWithValue("@HSN_Code", HSN_TXT.Text.Trim)
                        .AddWithValue("@Tax_Type", TAX_Type.Text.ToString.Trim)
                        .AddWithValue("@GST_Type", Txt1.Text.ToString.Trim)
                        .AddWithValue("@OB_Quantity", Ob_Quanitity_TXT.Text.Trim)
                        .AddWithValue("@OB_Rate", "0")
                        .AddWithValue("@OB_per", Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "ID", "Symbol  = '" & OB_Unit_Label.Text & "'").Trim)
                        .AddWithValue("@OB_Value", Val(Ob_Amt_TXT.Text))
                        .AddWithValue("@Note", Note_TXT.Text.Trim)
                        .AddWithValue("@Costing_Method", "")
                        .AddWithValue("@MRP", Val(MRP_TXT.Text))
                        .AddWithValue("@GST_Applicable", Txt2.Text)
                        .AddWithValue("@TAX_Value", nUmBeR_FORMATE(Label56.Text))
                        .AddWithValue("@Cess_Value", nUmBeR_FORMATE(Txt5.Text))
                        .AddWithValue("@Company", Company_ID_str)
                        .AddWithValue("@Visible", "Approval")
                        .AddWithValue("@User", LOGIN_ID)
                        .AddWithValue("@PC", PC_ID.Trim)
                        .AddWithValue("@Install_", CDate(DateTime.Now))
                        If Unit2TXT.Text = "(Not Applicable)" Then
                            .AddWithValue("@Alter_Unit", "0")
                            .AddWithValue("@Alter_Unit_Val1", "0")
                            .AddWithValue("@Alter_Unit_Val2", "0")
                        Else
                            .AddWithValue("@Alter_Unit", Unit_A_ID.ToString.Trim)
                            .AddWithValue("@Alter_Unit_Val1", TextBox2.Text.Trim)
                            .AddWithValue("@Alter_Unit_Val2", TextBox3.Text.Trim)
                        End If
                        If ST_Rate_YN.Visible = True Then
                            .AddWithValue("@STD_Rate_YN", ST_Rate_YN.Text.Trim)
                        Else
                            .AddWithValue("@STD_Rate_YN", "No".Trim)
                        End If
                        If BOM_YN.Visible = True Then
                            .AddWithValue("@BOM_YN", BOM_YN.Text.Trim)
                        Else
                            .AddWithValue("@BOM_YN", "No".Trim)
                        End If
                        If batch_YN.Text = "Yes" Then
                            .AddWithValue("@Batch_YN", "Yes".Trim)
                            .AddWithValue("@Mfg_YN", mfg_yn.Text.Trim)
                            .AddWithValue("@Exp_YN", exp_yn.Text.Trim)
                        Else
                            .AddWithValue("@Batch_YN", "No".Trim)
                            .AddWithValue("@Mfg_YN", "No".Trim)
                            .AddWithValue("@Exp_YN", "No".Trim)
                        End If
                        .AddWithValue("@Sales_Rate", Val(0))
                        .AddWithValue("@Purchase_Rate", Val(0))
                        .AddWithValue("@Reorder_Qty", Val(Reorder_Qty_TXT.Text.Trim))

                        .AddWithValue("@Costing_Value_Type", Txt4.Text.Trim)
                        .AddWithValue("@Market_Value_Type", Txt3.Text.Trim)
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

    Private Function Insurt_Requrid_Ledger() As Boolean
        Dim P As String = "11"
        Dim S As String = "10"


        Dim cn As New SQLiteConnection
        open_MSSQL_Cstm(Database_File.cre, cn)

        'Not Applicable
        Dim is_create_purchase_non_gst As Boolean = True
        Dim is_create_sales_non_gst As Boolean = True

        cmd = New SQLiteCommand($"Select [Group] as G From TBL_Ledger where ([Group] = '{S}' or [Group] = '{P}') and TAX_Type = 'Not Applicable' and Visible = 'Approval'", cn)
        Dim r As SQLiteDataReader = cmd.ExecuteReader
        While r.Read
            If r("G").ToString = P Then
                is_create_purchase_non_gst = False
            ElseIf r("G").ToString = S Then
                is_create_sales_non_gst = False
            End If
        End While
        r.Close()


        If is_create_sales_non_gst = True Then
            cmd = New SQLiteCommand($"INSERT INTO TBL_Ledger (Name,[Group],TAX_Type,PercentageOfCalculation,Visible,Company) VALUES ('Sales (Retail)','{S}','Not Applicable','0','Approval','All')", cn)
            cmd.ExecuteNonQuery()
        End If
        If is_create_purchase_non_gst = True Then
            cmd = New SQLiteCommand($"INSERT INTO TBL_Ledger (Name,[Group],TAX_Type,PercentageOfCalculation,Visible,Company) VALUES ('Purchase (Retail)','{P}','Not Applicable','0','Approval','All')", cn)
            cmd.ExecuteNonQuery()
        End If


        If Txt2.Text = "Applicable" Then
            'Exempt
            If TAX_Type.Text = "Exempt" Then
                If Find_DT_Value(Database_File.cre, "TBL_Ledger", "Name", $"[Group] = '{S}' and TAX_Type = 'GST' and TypeOfDuty = 'SALES EXEMPT' and Visible = 'Approval'") = Nothing Then
                    cmd = New SQLiteCommand($"INSERT INTO TBL_Ledger (Name,[Group],TAX_Type,TypeOfDuty,PercentageOfCalculation,Visible,Company) VALUES ('Sales (Exempt)','{S}','GST','SALES EXEMPT','0','Approval','All')", cn)
                    cmd.ExecuteNonQuery()
                End If

                If Find_DT_Value(Database_File.cre, "TBL_Ledger", "Name", $"[Group] = '{P}' and TAX_Type = 'GST' and TypeOfDuty = 'PURCHASE EXEMPT' and Visible = 'Approval'") = Nothing Then
                    cmd = New SQLiteCommand($"INSERT INTO TBL_Ledger (Name,[Group],TAX_Type,TypeOfDuty,PercentageOfCalculation,Visible,Company) VALUES ('Purchase (Exempt)','{P}','GST','PURCHASE EXEMPT','0','Approval','All')", cn)
                    cmd.ExecuteNonQuery()
                End If
            ElseIf TAX_Type.Text = "Nil Rated" Then
                If Find_DT_Value(Database_File.cre, "TBL_Ledger", "Name", $"[Group] = '{S}' and TAX_Type = 'GST' and TypeOfDuty = 'SALES NILL RATED' and Visible = 'Approval'") = Nothing Then
                    cmd = New SQLiteCommand($"INSERT INTO TBL_Ledger (Name,[Group],TAX_Type,TypeOfDuty,PercentageOfCalculation,Visible,Company) VALUES ('Sales (Nill Rated)','{S}','GST','SALES NILL RATED','0','Approval','All')", cn)
                    cmd.ExecuteNonQuery()
                End If

                If Find_DT_Value(Database_File.cre, "TBL_Ledger", "Name", $"[Group] = '{P}' and TAX_Type = 'GST' and TypeOfDuty = 'PURCHASE NILL RATED' and Visible = 'Approval'") = Nothing Then
                    cmd = New SQLiteCommand($"INSERT INTO TBL_Ledger (Name,[Group],TAX_Type,TypeOfDuty,PercentageOfCalculation,Visible,Company) VALUES ('Purchase (Nill Rated)','{P}','GST','PURCHASE NILL RATED','0','Approval','All')", cn)
                    cmd.ExecuteNonQuery()
                End If
            ElseIf TAX_Type.Text = "Non-GST" Then
                If Find_DT_Value(Database_File.cre, "TBL_Ledger", "Name", $"[Group] = '{S}' and TAX_Type = 'GST' and TypeOfDuty = 'SALES GST@0%' and Visible = 'Approval'") = Nothing Then
                    cmd = New SQLiteCommand($"INSERT INTO TBL_Ledger (Name,[Group],TAX_Type,TypeOfDuty,PercentageOfCalculation,Visible,Company) VALUES ('Sales (Non-GST)','{S}','GST','SALES GST@0%','0','Approval','All')", cn)
                    cmd.ExecuteNonQuery()
                End If

                If Find_DT_Value(Database_File.cre, "TBL_Ledger", "Name", $"[Group] = '{P}' and TAX_Type = 'GST' and TypeOfDuty = 'PURCHASE GST@0%' and Visible = 'Approval'") = Nothing Then
                    cmd = New SQLiteCommand($"INSERT INTO TBL_Ledger (Name,[Group],TAX_Type,TypeOfDuty,PercentageOfCalculation,Visible,Company) VALUES ('Purchase (Non-GST)','{P}','GST','PURCHASE GST@0%','0','Approval','All')", cn)
                    cmd.ExecuteNonQuery()
                End If
            ElseIf TAX_Type.Text = "Taxable" Then
                If Find_DT_Value(Database_File.cre, "TBL_Ledger", "Name", $"[Group] = '{S}' and TAX_Type = 'GST' and TypeOfDuty = 'SALES GST@{Label56.Text}%' and Visible = 'Approval'") = Nothing Then
                    cmd = New SQLiteCommand($"INSERT INTO TBL_Ledger (Name,[Group],TAX_Type,TypeOfDuty,PercentageOfCalculation,Visible,Company) VALUES ('Sales ({Label56.Text}%)','{S}','GST','SALES GST@{Label56.Text}%','{Label56.Text}','Approval','All')", cn)
                    cmd.ExecuteNonQuery()
                End If

                If Find_DT_Value(Database_File.cre, "TBL_Ledger", "Name", $"[Group] = '{P}' and TAX_Type = 'GST' and TypeOfDuty = 'PURCHASE GST@{Label56.Text}%' and Visible = 'Approval'") = Nothing Then
                    cmd = New SQLiteCommand($"INSERT INTO TBL_Ledger (Name,[Group],TAX_Type,TypeOfDuty,PercentageOfCalculation,Visible,Company) VALUES ('Purchase ({Label56.Text}%)','{P}','GST','PURCHASE GST@{Label56.Text}%','{Label56.Text}','Approval','All')", cn)
                    cmd.ExecuteNonQuery()
                End If
            End If


            'Insurt_GST
            If Find_DT_Value(Database_File.cre, "TBL_Ledger", "Name", $"[Group] = '20' and TypeOfDuty = 'CGST@{Val(Label56.Text) / 2}%' and Visible = 'Approval'") = Nothing Then
                cmd = New SQLiteCommand($"INSERT INTO TBL_Ledger (Name,[Group],TAX_Type,TypeOfDuty,PercentageOfCalculation,TAX_Class,Visible,Company) VALUES ('CGST@{Val(Label56.Text) / 2}%','20','GST','CGST@{Val(Label56.Text) / 2}%','{Val(Label56.Text) / 2}','CGST','Approval','All')", cn)
                cmd.ExecuteNonQuery()
            End If

            If Find_DT_Value(Database_File.cre, "TBL_Ledger", "Name", $"[Group] = '20' and TypeOfDuty = 'SGST/UTGST@{Val(Label56.Text) / 2}%' and Visible = 'Approval'") = Nothing Then
                cmd = New SQLiteCommand($"INSERT INTO TBL_Ledger (Name,[Group],TAX_Type,TypeOfDuty,PercentageOfCalculation,TAX_Class,Visible,Company) VALUES ('SGST/UTGST@{Val(Label56.Text) / 2}%','20','GST','SGST/UTGST@{Val(Label56.Text) / 2}%','{Val(Label56.Text) / 2}','SGST/UTGST','Approval','All')", cn)
                cmd.ExecuteNonQuery()
            End If

            If Find_DT_Value(Database_File.cre, "TBL_Ledger", "Name", $"[Group] = '20' and TypeOfDuty = 'IGST@{Val(Label56.Text)}%' and Visible = 'Approval'") = Nothing Then
                cmd = New SQLiteCommand($"INSERT INTO TBL_Ledger (Name,[Group],TAX_Type,TypeOfDuty,PercentageOfCalculation,TAX_Class,Visible,Company) VALUES ('IGST@{Val(Label56.Text)}%','20','GST','IGST@{Val(Label56.Text)}%','{Label56.Text}','IGST','Approval','All')", cn)
                cmd.ExecuteNonQuery()
            End If

        End If

        Return True
    End Function

    Private Function Insurt_Ledger_Branch_Value() As Boolean


        Dim id As String = Find_DT_Value(Database_File.cre, "TBL_Stock_Item", "ID", $"Name = '{Name_TXT.Text}'")
        Dim q As String = "INSERT INTO TBL_Stock_Item_Opning_Stock (Item_ID,Branch_ID,Applicable,Stock) VALUES (@Item_ID,@Branch_ID,@Applicable,@Stock)"

        Try
            Dim cn As New SQLiteConnection
            If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                If Branch_Visible() = True Then
                    cmd = New SQLiteCommand($"Delete From TBL_Stock_Item_Opning_Stock where Item_ID = '{VC_ID_}'", cn)
                    cmd.ExecuteNonQuery()
                Else 'If Branch_ID <> "0" Then
                    cmd = New SQLiteCommand($"Delete From TBL_Stock_Item_Opning_Stock where Item_ID = '{VC_ID_}' and (Branch_ID = {Branch_ID} or Branch_ID = '0')", cn)
                    cmd.ExecuteNonQuery()
                End If


                If Branch_Visible() = True Then
                    With Stock_Item_Branch_Stock.Stock_Item_Branch_Stock_ctrl1
                        Dim P_ As New Queue(Of Panel)()
                        For Each bg_p As Panel In .platform.Controls.OfType(Of Panel)()
                            P_.Enqueue(bg_p)
                        Next
                        Dim vl As Decimal = 0

                        Dim stock As Decimal = 0

                        For Each bg_p As Panel In P_.Reverse
                            Dim idx As Integer = .Find_Idx(bg_p)
                            'Branch Wais Save

                            stock = Val(.Find_Bal_Vall(idx).Text)

                            cmd = New SQLiteCommand(q, cn)
                            cmd.Parameters.AddWithValue("@Item_ID", id)
                            cmd.Parameters.AddWithValue("@Branch_ID", .Find_Branch_ID(idx).Text)
                            cmd.Parameters.AddWithValue("@Applicable", .Find_Applicap(idx).Text)
                            cmd.Parameters.AddWithValue("@Stock", Val(stock))
                            cmd.ExecuteNonQuery()
                        Next

                        'Head Save
                        cmd = New SQLiteCommand(q, cn)
                        cmd.Parameters.AddWithValue("@Item_ID", id)
                        cmd.Parameters.AddWithValue("@Branch_ID", "0")
                        cmd.Parameters.AddWithValue("@Applicable", "Yes")
                        cmd.Parameters.AddWithValue("@Stock", Val(Ob_Quanitity_TXT.Text))
                        cmd.ExecuteNonQuery()
                    End With
                Else
                    cmd = New SQLiteCommand(q, cn)
                    cmd.Parameters.AddWithValue("@Item_ID", id)
                    cmd.Parameters.AddWithValue("@Branch_ID", Branch_ID)
                    cmd.Parameters.AddWithValue("@Applicable", "Yes")
                    cmd.Parameters.AddWithValue("@Stock", Val(Ob_Quanitity_TXT.Text))
                    cmd.ExecuteNonQuery()


                    If Branch_ID <> "0" Then
                        'Alter Head ID
                        Dim vlu As Decimal = Val(Find_DT_Value_SUM(Database_File.cre, "TBL_Stock_Item_Opning_Stock", "Stock", $"Item_ID = '{id}'"))


                        cmd = New SQLiteCommand(q, cn)
                        cmd.Parameters.AddWithValue("@Item_ID", Find_DT_Value(Database_File.cre, "TBL_Stock_Item", "ID", $"Name = '{Name_TXT.Text}'"))
                        cmd.Parameters.AddWithValue("@Branch_ID", "0")
                        cmd.Parameters.AddWithValue("@Applicable", "Yes")
                        cmd.Parameters.AddWithValue("@Stock", Val(vlu))
                        cmd.ExecuteNonQuery()
                    End If

                End If
            End If

        Catch ex As Exception
            Msg(NOT_Type.Erro, "'Stock Branch Opning Stock' Save Error", ex.Message)
            Return False
        End Try

        Return True
    End Function
    Private Function Insurt_BOM_data() As Boolean
        VC_ID_ = Find_DT_Value(Database_File.cre, "TBL_Stock_Item", "ID", $"Name = '{Name_TXT.Text}'")


        Dim cn As New SQLiteConnection
        Dim q As String = "INSERT INTO TBL_Batch (Item,Name,Production_Qty,Company,User,PC,Date_install) VALUES (@Item,@Name,@Production_Qty,@Company,@User,@PC,@Install_)"
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            'Delete All Old Data
            cmd = New SQLiteCommand("Delete From TBL_Batch where Item = '" & VC_ID_ & "'", cn)
            cmd.ExecuteNonQuery()

            cmd = New SQLiteCommand("Delete From TBL_Batch_Item where (Select bc.Item From TBL_Batch bc where bc.id = Batch) = '" & VC_ID_ & "'", cn)
            cmd.ExecuteNonQuery()

            Try
                Dim nodes As XmlNodeList = dt_batch.DocumentElement.SelectNodes("/List/Batch")
                For Each node As XmlNode In nodes
                    cmd = New SQLiteCommand(q, cn)

                    Dim batch_name As String = node.SelectSingleNode("Name").InnerText
                    Dim Production_qty As String = Val(node.SelectSingleNode("Qty_Production").InnerText)

                    With cmd.Parameters
                        .AddWithValue("@Item", VC_ID_)
                        .AddWithValue("@Name", batch_name)
                        .AddWithValue("@Production_Qty", Val(Production_qty))
                        .AddWithValue("@Company", Company_ID_str)
                        .AddWithValue("@User", LOGIN_ID)
                        .AddWithValue("@PC", PC_ID.Trim)
                        .AddWithValue("@Install_", CDate(DateTime.Now))
                        cmd.ExecuteReader()
                    End With
                Next

                Dim nodes_it As XmlNodeList = dt_batch_item.DocumentElement.SelectNodes("/Batch_Details/Details")

                For Each it As XmlNode In nodes_it
                    Dim it_Batch_ As String = Find_DT_Value(Database_File.cre, "TBL_Batch", "ID", $"Name = '{it.SelectSingleNode("Batch").InnerText}' and Item = '{VC_ID_}'")
                    Dim it_Name_ As String = it.SelectSingleNode("Item").InnerText
                    Dim it_Qty_ As String = it.SelectSingleNode("Qty").InnerText

                    cmd = New SQLiteCommand($"INSERT INTO TBL_Batch_Item (Batch,Item,Qty) VALUES ('{it_Batch_}','{it_Name_}','{it_Qty_}')", cn)

                    cmd.ExecuteNonQuery()
                Next
            Catch ex As Exception
                Msg(NOT_Type.Erro, "BOM Save Erro", ex.Message)
                Return False
            End Try
        End If

        Return True
    End Function
    Private Function Insurt_STD_Rate() As Boolean
        If ST_Rate_YN.Text = "Yes" Then
            qury = $"Delete From TBL_Item_Rate where Item  = '{Find_DT_Value(Database_File.cre, "TBL_Stock_Item", "ID", "Name  = '" & Name_TXT.Text & "'")}' "
            cmd = New SQLiteCommand(qury, con)
            cmd.ExecuteNonQuery()



            For Each ro As DataGridViewRow In DataGridView3.Rows
                Dim Ty_ As String = (ro.Cells(0).Value)
                Dim Date_ As Date = CDate(ro.Cells(1).Value)
                Dim Rate_ As String = (ro.Cells(2).Value)
                Dim Unit_ As String = (ro.Cells(3).Value)

                qury = $"INSERT INTO TBL_Item_Rate (Type,Item,Date,Rate,Unit) VALUES (@Type,@Item,@Date,@Rate,@Unit)"

                cmd = New SQLiteCommand(qury, con)
                Try
                    With cmd.Parameters
                        .AddWithValue("@Item", Find_DT_Value(Database_File.cre, "TBL_Stock_Item", "ID", "Name  = '" & Name_TXT.Text & "'").Trim)
                        .AddWithValue("@Type", Ty_)
                        .AddWithValue("@Date", Date_)
                        .AddWithValue("@Rate", Rate_)
                        .AddWithValue("@Unit", Unit_)

                        cmd.ExecuteNonQuery()
                    End With
                Catch ex As Exception
                    Msg(NOT_Type.Erro, "Data Save Error", ex.Message)

                    Return False
                End Try
            Next
        End If
        Return True
    End Function
    Private Function Document_Save() As Boolean
        If open_MSSQL(Database_File.rec) = True Then
            qury = "INSERT INTO TBL_Attage (Name,Narration,TBL,TBL_ID,Attage,Attage_Type,Password,[User],Date_install,PC,Visible) VALUES (@Name,@Narration,@TBL,@TBL_ID,@Attage,@Attage_Type,@Password,@User,@Install_,@PC,@Visible)"
            For i As Integer = 0 To DataGridView1.Rows.Count - 1
                Dim ro As DataGridViewRow = DataGridView1.Rows(i)
                If ro.Cells(0).Value = "0" Then
                    cmd = New SQLiteCommand(qury, con)
                    Try
                        With cmd.Parameters
                            .AddWithValue("@Name", ro.Cells(1).Value)
                            .AddWithValue("@Narration", ro.Cells(2).Value)
                            .AddWithValue("@TBL", "Stock_Item")
                            .AddWithValue("@TBL_ID", Find_DT_Value(Database_File.cre, "TBL_Stock_Item", "ID", "Name = '" & Name_TXT.Text & "' and " & Company_Address_str))
                            .AddWithValue("@Attage", SqlDbType.Binary).Value = DirectCast(ro.Cells(4).Value, Byte())
                            .AddWithValue("@Attage_Type", ro.Cells(3).Value)
                            .AddWithValue("@Password", ro.Cells(5).Value)
                            .AddWithValue("@User", LOGIN_ID)
                            .AddWithValue("@Install_", CDate(DateTime.Now))
                            .AddWithValue("@PC", PC_ID.Trim)
                            .AddWithValue("@Visible", "Approval")
                            cmd.ExecuteNonQuery()
                        End With
                    Catch ex As Exception
                        Msg(NOT_Type.Erro, "Data Save Error", ex.Message)
                        Return False
                    End Try
                End If
            Next
        End If
        Return True
    End Function

    Private Function Clear_all()
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            'BG_frm.Stock_Item_BS.DataSource = Nothing
            'BG_frm.Stock_Item_BS.DataSource = Fill_Stock_Item(cn)
        End If

        Stock_Item_Branch_Stock.Dispose()
        If VC_Type_ = "Create" Then
            Name_TXT.Text = ""
            Alias_TXT.Text = ""
            Discription_TXT.Text = ""
            HSN_TXT.Text = ""


            TAX_Type.Text = ""
            Barcode_TXT.Text = ""
            Note_TXT.Text = ""
            DataGridView1.Rows.Clear()
            Name_TXT.Focus()
            VC_ID_ = ""


            dt_batch = New XmlDocument
            dt_batch_item = New XmlDocument
            Batch_Data_Fill()

            DataGridView3.Rows.Clear()


            NOT_("The entry you entered has been successfully accepted", NOT_Type.Success)


            Exit Function
        ElseIf VC_Type_ = "Alter_Close" Or VC_Type_ = "Create_Close" Then
            close_focus_obj.Text = Name_TXT.Text
            Me.Dispose()
            close_focus_obj.Focus()
        Else
            Me.Dispose()
        End If
    End Function
    Private Sub Stock_Item_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If BG_frm.From_ID = From_ID Then
            If e.KeyCode = Keys.Escape Then
                If Msg_Exit_YN("Stock Item " & VC_Type_) = DialogResult.Yes Then
                    Me.Dispose()
                    If VC_Type_ = "Alter_Close" Or VC_Type_ = "Create_Close" Then
                        close_focus_obj.Focus()
                    End If
                End If
            End If
            If e.KeyCode = Keys.F12 Then
                BG_frm.R_22.PerformClick()
            End If
        End If

    End Sub
    Private Sub Stock_Item_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End
        Add_Hander_Remove_Handel(False)
        Stock_Item_Branch_Stock.Dispose()
        Frm_foCus()
    End Sub

    Private Sub Unit_TXT_Enter(sender As Object, e As EventArgs) Handles Unit_TXT.Enter

    End Sub
    Private Function Unti_List()
        If List_frm.Visible = False Then


        End If
    End Function
    Private Sub Unit_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles Unit_TXT.KeyDown
        If e.KeyCode = Keys.Enter Then
            If unit_list.List_Grid.CurrentRow.Cells(1).Value.ToString = "Create" Then
                Cell("Stock Unit", "Stock Unit", "Create_Close", "")
                Unit_frm.close_focus_obj = sender
                Unit_frm.Symbol_TXT.Text = Unit_TXT.Text
                SendKeys.Send("+{TAB}")
                Exit Sub
            End If

            Unit_ID = unit_list.List_Grid.CurrentRow.Cells(2).Value.ToString
            Unit_Type = unit_list.List_Grid.CurrentRow.Cells(4).Value.ToString

            If Unit_ID = Nothing Then
                Exit Sub
            End If
        End If

        If e.KeyCode = Keys.C AndAlso e.Modifiers = Keys.Alt Then
            Cell("Stock Unit", "Stock Unit", "Create_Close", "")
            Unit_frm.close_focus_obj = sender
        ElseIf e.KeyCode = Keys.Enter AndAlso e.Modifiers = Keys.Control Then
            Cell("Stock Unit", "Stock Unit", "Alter_Close", Unit_ID)
            Unit_frm.close_focus_obj = sender
        End If
    End Sub
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
            Unit2TXT.Hide()
        ElseIf Alter_Unit_YN = True Then
            Label32.Text = Unit_TXT.Text
            Label33.Text = Unit2TXT.Text
            If Unit2TXT.Text = "(Not Applicable)" Then
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
            Unit2TXT.Show()
        End If
    End Function

    Private Sub HSN_TXT_TextChanged(sender As Object, e As EventArgs) Handles HSN_TXT.TextChanged
        Dim cn As New SQLiteConnection
        'If open_MSSQL_Cstm(Database_File.cfg, cn) = True Then
        Label11.Text = Find_DT_Value(Database_File.cfgs, "TBL_HSN", "Description", "HSN_Code  = '" & HSN_TXT.Text & "'")
        'End If

    End Sub

    Private Sub Group_TXT_Enter(sender As Object, e As EventArgs) Handles Group_TXT.Enter

    End Sub
    Private Function Group_Lits()
        If List_frm.Visible = False Then

        End If
    End Function
    Private Sub Group_TXT_TextChanged(sender As Object, e As EventArgs) Handles Group_TXT.TextChanged
    End Sub

    Private Sub Group_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles Group_TXT.KeyDown
        If e.KeyCode = Keys.Enter Then

            If sg_list.List_Grid.CurrentRow.Cells(1).Value.ToString = "Create" Then
                Cell("Stock Group", "", "Create_Close", "")
                Stock_Group_frm.close_focus_obj = sender
                Stock_Group_frm.Name_TXT.Text = Group_TXT.Text
                SendKeys.Send("+{TAB}")
                Exit Sub
            End If


            Under_ID = sg_list.List_Grid.CurrentRow.Cells(2).Value
            Under = sg_list.List_Grid.CurrentRow.Cells(0).Value

            If Under_ID = Nothing Then
                sender.Text = "Primary"
                Exit Sub
            End If
        End If
        If e.KeyCode = Keys.C AndAlso e.Modifiers = Keys.Alt Then
            Cell("Stock Group", "", "Create_Close", "")
            Stock_Group_frm.close_focus_obj = sender
            Stock_Group_frm.Name_TXT.Text = Group_TXT.Text
        ElseIf e.KeyCode = Keys.Enter AndAlso e.Modifiers = Keys.Control Then
            Cell("Stock Group", "", "Alter_Close", Under_ID)
            Stock_Group_frm.close_focus_obj = sender
        End If

    End Sub

    Private Sub TAX_TAX_Enter(sender As Object, e As EventArgs) Handles TAX_Type.Enter

    End Sub

    Private Sub TAX_TAX_TextChanged(sender As Object, e As EventArgs) Handles TAX_Type.TextChanged

    End Sub
    Private Sub Purchase_Rate_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Purchase_Rate_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Ob_Quanitity_TXT.KeyPress
        allow_Number(e)
    End Sub
    Private Function Display_Fill_All()

        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select *,
(Select sg.Name From TBL_Stock_Group sg where sg.ID = i.Under) as Under_Name,
(Select U.Type From TBL_Inventory_Unit u where U.ID = i.Unit) as Unit_Type,
(Select U.Type From TBL_Inventory_Unit u where U.ID = i.Alter_Unit) as A_Unit_Type
From TBL_Stock_Item i 
Where i.ID = '{VC_ID_}'", cn)
            Dim r As SQLiteDataReader = cmd.ExecuteReader
            While r.Read
                Name_TXT.Text = r("Name").ToString.Trim
                Alias_TXT.Text = r("Alias").ToString.Trim
                Barcode_TXT.Text = r("Barcode").ToString.Trim
                Under_ID = r("Under").ToString.Trim
                Under = r("Under_Name").ToString.Trim
                Group_TXT.Text = Under
                Discription_TXT.Text = r("Description").ToString.Trim
                Note_TXT.Text = r("Note").ToString.Trim

                Unit_ID = r("Unit").ToString.Trim
                Unit_Type = r("Unit_Type").ToString.Trim

                Unit_TXT.Text = Find_DT_Unit_Conves(Unit_ID)
                OB_Unit_Label.Text = Find_DT_Unit_Conves(Unit_ID)

                Unit_A_ID = r("Alter_Unit").ToString.Trim
                Unit_A_Type = r("A_Unit_Type").ToString.Trim
                Unit2TXT.Text = Find_DT_Unit_Conves(Unit_A_ID)

                TextBox2.Text = r("Alter_Unit_Val1").ToString.Trim

                Txt7.Text = $"GST@{Val(r("TAX_Value").ToString.Trim)}%"
                Label56.Text = (r("TAX_Value").ToString.Trim)
                Txt5.Text = nUmBeR_FORMATE(r("Cess_Value").ToString.Trim)
                TextBox3.Text = r("Alter_Unit_Val2").ToString.Trim
                HSN_TXT.Text = r("HSN_Code").ToString.Trim
                Txt2.Text = r("GST_Applicable").ToString.Trim
                TAX_Type.Text = r("Tax_Type").ToString.Trim
                Txt1.Text = r("GST_Type").ToString.Trim

                batch_YN.Text = r("Batch_YN").ToString.Trim
                mfg_yn.Text = r("Mfg_YN").ToString.Trim
                exp_yn.Text = r("Exp_YN").ToString.Trim

                Ob_Amt_TXT.Text = nUmBeR_FORMATE(r("OB_Value").ToString.Trim)
                Dim UT As String = r("OB_per").ToString.Trim
                ST_Rate_YN.Text = r("STD_Rate_YN").ToString.Trim
                BOM_YN.Text = r("BOM_YN").ToString.Trim
                MRP_TXT.Text = r("MRP").ToString.Trim

                Txt4.Text = r("Costing_Value_Type").ToString.Trim
                Txt3.Text = r("Market_Value_Type").ToString.Trim

                'Sales_Rate_TXT.Text = Val(r("Sales_Rate").ToString.Trim)
                'Purchase_Rate_TXT.Text = Val(r("Purchase_Rate").ToString.Trim)
                Reorder_Qty_TXT.Text = Val(r("Reorder_Qty").ToString.Trim)

            End While
            r.Close()
        End If


        Dim oQ As Decimal = 0
        If Branch_Visible() = True Or Branch_YN_fech = False Then
            oQ = Val(Find_DT_Value_SUM(Database_File.cre, "TBL_Stock_Item_Opning_Stock", "Stock", $"Item_ID = '{VC_ID_}' and Branch_Id = '0'"))
        Else
            oQ = Val(Find_DT_Value_SUM(Database_File.cre, "TBL_Stock_Item_Opning_Stock", "Stock", $"Item_ID = '{VC_ID_}' and Branch_Id = '{Branch_ID}'"))
        End If
        Ob_Quanitity_TXT.Text = oQ

        Alter_Unit_set()

        If Group_TXT.Text = "" Then
            Group_TXT.Text = "Primary"
        End If
        Fill_Attage()
        Fill_Std_Rate()

        Unit_Panel.Enabled = Chack_Delete_Allow()
    End Function
    Private Function Fill_Std_Rate()
        DataGridView3.Rows.Clear()
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            DataGridView2.Rows.Clear()
            cmd = New SQLiteCommand($"Select *,(Select U.Symbol From TBL_Inventory_Unit U where U.ID = ir.[Unit]) as Unit_Name From TBL_Item_Rate ir where ir.Item = '{VC_ID_}'", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                DataGridView3.Rows.Add(r("Type").ToString, r("Date").ToString, r("Rate").ToString, r("Unit").ToString)
            End While
            r.Close()
        End If
    End Function
    Private Function Fill_Attage()
        If open_MSSQL(Database_File.rec) = True Then
            DataGridView1.Rows.Clear()
            qury = "Select * From TBL_Attage where TBL = 'Stock_Item' and TBL_ID = '" & VC_ID_ & "' and Visible = 'Approval'"
            cmd = New SQLiteCommand(qury, con)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                DataGridView1.Rows.Add(r("ID"), r("Name"), r("Narration"), r("Attage_Type"), r("Attage"), r("Password"))
            End While
        End If
    End Function
    Private Function Barcode_aLlow() As Boolean
        If BG_frm.From_ID = From_ID Then
            Duplicate_Barcode = ""
            If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
                Duplicate_Barcode = " Barcode  = '" & Barcode_TXT.Text & "' COLLATE NOCASE  and " & Company_Visible_Filter()
            Else
                Duplicate_Barcode = " Barcode  = '" & Barcode_TXT.Text & "' COLLATE NOCASE  and ID <> '" & VC_ID_ & "' and " & Company_Visible_Filter()
            End If

            If Barcode_TXT.Text = "" Then
                Return True
                Exit Function
            End If

            If Chack_Duplicate(Database_File.cre, "TBL_Stock_Item", "Name", Duplicate_Barcode) = True Then
                NOT_("The Barcode Entered is a 'Duplicate'", NOT_Type.Warning)
                Msg_Duplicat(Barcode_TXT, "Barcode")
                Return False
                Exit Function
            Else
                NOT_Clear()
                Return True
            End If
        End If
        Return True

    End Function
    Private Function Name_aLlow() As Boolean
        If BG_frm.From_ID = From_ID Then
            Alias_aLlow()
            If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
                Duplicate_Type = " Name  = '" & Name_TXT.Text & "' COLLATE NOCASE  and " & Company_Visible_Filter()
            Else
                Duplicate_Type = " Name  = '" & Name_TXT.Text & "' COLLATE NOCASE  and ID <> '" & VC_ID_ & "' and " & Company_Visible_Filter()
            End If

            If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
                Duplicate_Type1 = " Alias  = '" & Name_TXT.Text & "' COLLATE NOCASE  and " & Company_Visible_Filter()
            Else
                Duplicate_Type1 = " Alias  = '" & Name_TXT.Text & "' COLLATE NOCASE  and ID <> '" & VC_ID_ & "' and " & Company_Visible_Filter()
            End If

            If Name_TXT.Text = "" Then
                'NOT_("Not Valid Without a Blank 'Name'", NOT_Type.Warning)
                Return False
                Exit Function
            End If

            If Chack_Duplicate(Database_File.cre, "TBL_Stock_Item", "Name", Duplicate_Type) = True Then
                NOT_("The Name Entered is a 'Duplicate'", NOT_Type.Warning)
                Msg_Duplicat(Name_TXT, "Stock Item")
                Return False
                Exit Function
            ElseIf Chack_Duplicate(Database_File.cre, "TBL_Stock_Item", "Alias", Duplicate_Type1) = True Then
                NOT_("The Name Entered is a 'Duplicate'", NOT_Type.Warning)
                Msg_Duplicat(Name_TXT, "Stock Item")
                Return False
                Exit Function
            Else
                NOT_Clear()
                Return True
            End If
        End If
        Return True
    End Function

    Private Sub Name_TXT_Enter(sender As Object, e As EventArgs) Handles Name_TXT.Enter
        Name_aLlow()
    End Sub
    Private Sub Name_TXT_TextChanged(sender As Object, e As EventArgs) Handles Name_TXT.TextChanged
        Name_aLlow()
    End Sub
    Private Sub Name_TXT_LostFocus(sender As Object, e As EventArgs) Handles Name_TXT.LostFocus
        If Name_aLlow() = False Then
            Name_TXT.Focus()
        End If
    End Sub
    Private Function Alias_aLlow() As Boolean
        If BG_frm.From_ID = From_ID Then
            If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
                Duplicate_Alias_Type = " Name  = '" & Alias_TXT.Text & "' COLLATE NOCASE  and " & Company_Visible_Filter()
            Else
                Duplicate_Alias_Type = " Name  = '" & Alias_TXT.Text & "' COLLATE NOCASE  and ID <> '" & VC_ID_ & "' and " & Company_Visible_Filter()
            End If

            If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
                Duplicate_Alias_Type1 = " Alias  = '" & Alias_TXT.Text & "' COLLATE NOCASE  and " & Company_Visible_Filter()
            Else
                Duplicate_Alias_Type1 = " Alias  = '" & Alias_TXT.Text & "' COLLATE NOCASE  and ID <> '" & VC_ID_ & "' and " & Company_Visible_Filter()

            End If
            If Alias_TXT.Text <> "" Then
                If Name_TXT.Text = Alias_TXT.Text Then
                    NOT_("Name and Alias is Sam", NOT_Type.Warning)
                    Msg_Duplicat(Alias_TXT, "Stock Item")
                    Return False
                    Exit Function
                End If

                If Chack_Duplicate(Database_File.cre, "TBL_Stock_Item", "Nickname", Duplicate_Alias_Type) = True Then
                    NOT_("The Alias Entered is a 'Duplicate'", NOT_Type.Warning)
                    Msg_Duplicat(Alias_TXT, "Stock Item")
                    Return False
                    Exit Function
                ElseIf Chack_Duplicate(Database_File.cre, "TBL_Stock_Item", "Name", Duplicate_Alias_Type1) = True Then
                    NOT_("The Alias Entered is a 'Duplicate'", NOT_Type.Warning)
                    Msg_Duplicat(Alias_TXT, "Stock Item")
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
            Name_TXT.Focus()
        End If
    End Sub

    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs) Handles Panel5.Paint

    End Sub

    Private Sub ComboBox3_KeyDown(sender As Object, e As KeyEventArgs) Handles ST_Rate_YN.KeyDown
        If e.KeyCode = Keys.Enter Then
            If ST_Rate_YN.Text = "Yes" Then
                Dim pop As Popup
                Dim Audit_cfg_pop As Object
                Audit_cfg_pop = New Rate_Set_popup
                pop = New Popup(Audit_cfg_pop)

                pop.FocusOnOpen = True
                Audit_cfg_pop.obj = sender

                pop.AnimationDuration = 1
                pop.Show(sender)

                Audit_cfg_pop.Display_Fill_All()

            End If
        End If

    End Sub

    Private Sub TextBox1_Enter(sender As Object, e As EventArgs) Handles Unit2TXT.Enter
        Unit2TXT.Select_Filter = $"((Name Like '%<value>%' and Name <> '{Unit_TXT.Text}') and Name <> '(Not Applicable)') or (Formal_Name = 'Create') "
    End Sub
    Private Function Alter_Unit_List()
        If List_frm.Visible = False Then

        End If
    End Function
    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles Unit2TXT.KeyDown
        If e.KeyCode = Keys.Enter Then
            If unit_alter_list.List_Grid.CurrentRow.Cells(1).Value.ToString = "Create" Then
                Cell("Stock Unit", "Stock Unit", "Create_Close", "")
                Unit_frm.close_focus_obj = sender
                Unit_frm.Symbol_TXT.Text = Unit2TXT.Text
                SendKeys.Send("+{TAB}")
                Exit Sub
            End If

            Unit_A_ID = unit_alter_list.List_Grid.CurrentRow.Cells(2).Value.ToString
            Unit_A_Type = unit_alter_list.List_Grid.CurrentRow.Cells(4).Value.ToString
        End If

        If e.KeyCode = Keys.C AndAlso e.Modifiers = Keys.Alt Then
            Cell("Stock Unit", "Stock Unit", "Create_Close", "")
            Unit_frm.close_focus_obj = sender
        ElseIf e.KeyCode = Keys.Enter AndAlso e.Modifiers = Keys.Control Then
            Cell("Stock Unit", "Stock Unit", "Alter_Close", Unit_A_ID)
            Unit_frm.close_focus_obj = sender
        End If
    End Sub

    Private Function Update_Confi()
        Dim Alter_Unit As String
        Dim STD_Rate As String
        Dim BOM As String

        Alter_Unit = "Yes"
        STD_Rate = "Yes"
        BOM = "Yes"

        If Alter_Unit = "Yes" Then
            Panel15.Visible = True
        Else
            Panel15.Visible = False
        End If
        If STD_Rate = "Yes" Then
            Label16.Visible = True
            Label15.Visible = True
            ST_Rate_YN.Visible = True
        Else
            Label16.Visible = False
            Label15.Visible = False
            ST_Rate_YN.Visible = False
        End If
        If BOM = "Yes" Then
            Label27.Visible = True
            Label26.Visible = True
            BOM_YN.Visible = True
        Else
            Label27.Visible = False
            Label26.Visible = False
            BOM_YN.Visible = False
        End If
    End Function

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim Byt As Byte()
        Byt = DirectCast(DataGridView1.CurrentRow.Cells(4).Value, Byte())

        Dim EditBTNDATA As String = DataGridView1.Columns(e.ColumnIndex).Name


        If EditBTNDATA = "Column6" Then
            If DataGridView1.CurrentRow.Cells(5).Value <> Nothing Then
                Attage_Password.Password = DataGridView1.CurrentRow.Cells(5).Value
                If Attage_Password.ShowDialog <> DialogResult.Yes Then
                    Exit Sub
                End If
            End If
            Dim Formett As String = DataGridView1.CurrentRow.Cells(3).Value.ToString
            If Formett = ".Jpeg" Or Formett = ".jpg" Or Formett = ".jpg2" Or Formett = ".png" Or Formett = ".gif" Or Formett = ".bmp" Then
                Document_view_frm.Byt = Byt
                Document_view_frm.Name = DataGridView1.CurrentRow.Cells(1).Value.ToString
                Document_view_frm.Formett = Formett
                Document_view_frm.Narra = DataGridView1.CurrentRow.Cells(2).Value.ToString
                Document_view_frm.ShowDialog()
            End If
        ElseIf EditBTNDATA = "Column7" Then
            Dim memory As New MemoryStream()
            Dim Formett As String
            If DataGridView1.CurrentRow.Cells(5).Value <> Nothing Then
                Attage_Password.Password = DataGridView1.CurrentRow.Cells(5).Value
                If Attage_Password.ShowDialog <> DialogResult.Yes Then
                    Exit Sub
                End If
            End If
            Formett = DataGridView1.CurrentRow.Cells(3).Value
            Dim ms As New MemoryStream(Byt)
            SaveFileDialog1.FileName = DataGridView1.CurrentRow.Cells(1).Value
            SaveFileDialog1.Title = Name_TXT.Text & " Save Document"
            If SaveFileDialog1.ShowDialog = DialogResult.OK Then
                Dim file As New FileStream(SaveFileDialog1.FileName & Formett, FileMode.Create, FileAccess.Write)
                ms.WriteTo(file)
                file.Close()
                ms.Close()
            End If


        ElseIf EditBTNDATA = "Column8" Then

            If DataGridView1.CurrentRow.Cells(0).Value <> "0" Then
                If DataGridView1.CurrentRow.Cells(5).Value <> Nothing Then
                    Attage_Password.Password = DataGridView1.CurrentRow.Cells(5).Value
                    If Attage_Password.ShowDialog <> DialogResult.Yes Then
                        Exit Sub
                    End If
                End If

                If Msg_Delete_YN(Name_TXT, "Stock Item") = DialogResult.Yes Then
                    If Data_Delete(Database_File.rec, "TBL_Attage", "Visible = 'Delete' WHERE ID = '" & DataGridView1.CurrentRow.Cells(0).Value & "'") = True Then
                        DataGridView1.Rows.Remove(DataGridView1.CurrentRow)
                    End If
                End If
            Else
                DataGridView1.Rows.Remove(DataGridView1.CurrentRow)
            End If
        End If
    End Sub

    Private Sub ST_Rate_YN_TextChanged(sender As Object, e As EventArgs) Handles ST_Rate_YN.TextChanged

    End Sub

    Private Sub Group_TXT_LostFocus(sender As Object, e As EventArgs) Handles Group_TXT.LostFocus

    End Sub

    Private Sub Unit_TXT_LostFocus(sender As Object, e As EventArgs) Handles Unit_TXT.LostFocus
        Alter_Unit_set()
        If Unit_TXT.Text = "(Not Applicable)" Then
            OB_Panel.Visible = False
        Else
            OB_Unit_Label.Text = Unit_TXT.Text
            OB_Panel.Visible = True
        End If
    End Sub

    Private Sub TextBox1_LostFocus(sender As Object, e As EventArgs) Handles Unit2TXT.LostFocus
        If Unit_A_ID = Unit_ID Then
            Msg(NOT_Type.Warning, "Input Error", "Unit and Alternate Units is same, Please change Alternate Units and try again")
            Unit2TXT.Text = "(Not Applicable)"
            Unit_Source.MoveFirst()
            Unit_A_ID = Nothing
            Unit2TXT.Focus()
        End If
    End Sub

    Private Sub TAX_TAX_LostFocus(sender As Object, e As EventArgs) Handles TAX_Type.LostFocus

    End Sub

    Private Sub Txt1_TextChanged(sender As Object, e As EventArgs) Handles Txt1.TextChanged
        If List_frm.Visible = True Then
            List_Curr_(sender)
        End If
    End Sub

    Private Sub Txt1_Enter(sender As Object, e As EventArgs) Handles Txt1.Enter

        Txt1_TextChanged(e, e)
    End Sub
    Private Function GST_Type_of_Supplay()
        Dim dt As New DataTable
        dt.Columns.Add("Head")
        dt.Columns.Add("Under")
        dt.Columns.Add("id")

        dt.Rows.Add("Capital Goods")
        dt.Rows.Add("Goods")
        dt.Rows.Add("Services")
        GST_Type_of_Supplay_BS.DataSource = dt
        '''
        Dim dt_ As New DataTable
        dt_.Columns.Add("Head")
        dt_.Columns.Add("Under")
        dt_.Columns.Add("id")

        dt_.Rows.Add("Not Applicable")
        dt_.Rows.Add("Applicable")
        GST_Applicable_Source.DataSource = dt_
    End Function

    Private Sub Txt1_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Txt1.Text = tax_type_list.List_Grid.CurrentRow.Cells(0).Value.ToString()
        End If
    End Sub

    Private Sub Txt1_LostFocus(sender As Object, e As EventArgs) Handles Txt1.LostFocus

    End Sub

    Private Sub Group_TXT_MarginChanged(sender As Object, e As EventArgs) Handles Group_TXT.MarginChanged

    End Sub

    Private Sub Focus_txt_TextChanged(sender As Object, e As EventArgs) Handles Focus_txt.TextChanged

    End Sub

    Private Sub Focus_txt_Enter(sender As Object, e As EventArgs) Handles Focus_txt.Enter
        Dim result As DialogResult = Msg_Save_YN(Name_TXT, "Stock Item")

        If result = DialogResult.Yes Then
            Save_Data()
        ElseIf result = DialogResult.No Then
            Name_TXT.Focus()
        ElseIf result = DialogResult.Cancel Then
            SendKeys.Send("{BACKSPACE}")
        End If
    End Sub

    Private Sub BOM_YN_TextChanged(sender As Object, e As EventArgs) Handles BOM_YN.TextChanged

    End Sub
    Public pop As Popup
    Private Sub BOM_YN_KeyDown(sender As Object, e As KeyEventArgs) Handles BOM_YN.KeyDown
        If e.KeyCode = Keys.Enter Then
            If BOM_YN.Text = "Yes" Then
                Inventory_BOM.dt_batch.LoadXml(dt_batch.InnerXml.ToString)
                Inventory_BOM.dt_batch_item.LoadXml(dt_batch_item.InnerXml.ToString)
                If VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
                    Cell("Inventory Item Batch", 0)
                Else
                    Cell("Inventory Item Batch", VC_ID_)
                End If
                Inventory_BOM.Back_Obj = BOM_YN
                Inventory_BOM.Load_List()
            End If
        End If
    End Sub
    Public dt_batch As New XmlDocument
    Public dt_batch_item As New XmlDocument
    Private Function Batch_Data_Fill()

        Dim List As XmlNode = dt_batch.CreateElement("List")
        Dim Batch_ As XmlNode
        Dim Name_ As XmlNode
        Dim Qty_production_ As XmlNode

        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select * from TBL_Batch bt where bt.Item = '{VC_ID_}'", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                Batch_ = dt_batch.CreateElement("Batch")

                Name_ = dt_batch.CreateElement("Name")
                Name_.InnerText = r("Name")
                Batch_.AppendChild(Name_)

                Qty_production_ = dt_batch.CreateElement("Qty_Production")
                Qty_production_.InnerText = r("Production_Qty")
                Batch_.AppendChild(Qty_production_)


                List.AppendChild(Batch_)
            End While
            r.Close()
            dt_batch.AppendChild(List)

            Dim Batch_Details As XmlNode = dt_batch_item.CreateElement("Batch_Details")
            Dim Details As XmlNode

            Dim it_ As XmlNode
            Dim qty_ As XmlNode

            cmd = New SQLiteCommand($"Select * from TBL_Batch_Item bi
LEFT JOIN TBL_Batch bt on bt.id = bi.Batch
where bt.item = '{VC_ID_}'", cn)
            r = cmd.ExecuteReader
            While r.Read
                Details = dt_batch_item.CreateElement("Details")

                Batch_ = dt_batch_item.CreateElement("Batch")
                Batch_.InnerText = r("Name")
                Details.AppendChild(Batch_)

                it_ = dt_batch_item.CreateElement("Item")
                it_.InnerText = r("Item")
                Details.AppendChild(it_)

                qty_ = dt_batch_item.CreateElement("Qty")
                qty_.InnerText = Val(r("Qty"))
                Details.AppendChild(qty_)

                Batch_Details.AppendChild(Details)
            End While
            r.Close()

            'nill entry
            Details = dt_batch_item.CreateElement("Details")

            Batch_ = dt_batch_item.CreateElement("Batch")
            Batch_.InnerText = ""
            Details.AppendChild(Batch_)

            it_ = dt_batch_item.CreateElement("Item")
            it_.InnerText = ""
            Details.AppendChild(it_)

            qty_ = dt_batch_item.CreateElement("Qty")
            qty_.InnerText = ""
            Details.AppendChild(qty_)

            Batch_Details.AppendChild(Details)
            dt_batch_item.AppendChild(Batch_Details)
        End If

    End Function

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles Unit2TXT.TextChanged
        Alter_Unit_set()
    End Sub

    Private Sub Unit_TXT_TextChanged(sender As Object, e As EventArgs) Handles Unit_TXT.TextChanged
        Alter_Unit_set()
        Label67.Text = sender.Text
    End Sub

    Private Sub Txt2_TextChanged(sender As Object, e As EventArgs) Handles Txt2.TextChanged
        If Txt2.Text = "Not Applicable" Then
            Panel18.Visible = False
            Panel41.Visible = False

            TAX_Type.Text = ""
            Txt7.Text = ""
            Label56.Text = ""
            Txt1.Text = ""
            HSN_TXT.Text = ""
        Else
            Panel18.Visible = True
            Panel41.Visible = True
        End If
    End Sub

    Private Sub Yn4_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Yn4_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            If sender.Text = "Yes" Then
                Cell("Stock Item (Multi Branch Manager)", VC_ID_)
            End If
        End If
    End Sub

    Private Sub Yn1_TextChanged(sender As Object, e As EventArgs) Handles batch_YN.TextChanged
        exp_panel.Visible = YN_Boolean(sender.Text)
        mfg_panel.Visible = YN_Boolean(sender.Text)

    End Sub

    Private Sub Barcode_TXT_TextChanged(sender As Object, e As EventArgs) Handles Barcode_TXT.TextChanged
        Barcode_aLlow()
    End Sub

    Private Sub Barcode_TXT_LostFocus(sender As Object, e As EventArgs) Handles Barcode_TXT.LostFocus
        If Barcode_aLlow() = False Then
            Barcode_TXT.Focus()
        End If
    End Sub

    Private Sub Barcode_TXT_Enter(sender As Object, e As EventArgs) Handles Barcode_TXT.Enter
        Barcode_aLlow()
    End Sub

    Private Sub Txt7_TextChanged(sender As Object, e As EventArgs) Handles Txt7.TextChanged

    End Sub

    Private Sub Txt7_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt7.KeyPress
        allow_Number(e)
    End Sub

    Private Sub TAX_Type_KeyDown(sender As Object, e As KeyEventArgs) Handles TAX_Type.KeyDown
        If e.KeyCode = Keys.Enter Then
            If tax_list.List_Grid.CurrentRow.Cells(0).Value = "Taxable" Then
                Txt7.Enabled = True
            Else
                Txt7.Enabled = False
                Txt7.Text = ""
                Label56.Text = "0"
            End If
        End If
    End Sub

    Private Sub Txt7_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt7.KeyDown
        If e.KeyCode = Keys.Enter Then
            Label56.Text = tax_per_list.List_Grid.CurrentRow.Cells(1).Value
        End If
    End Sub

    Private Sub Label56_Click(sender As Object, e As EventArgs) Handles Label56.Click

    End Sub

    Private Sub Label56_TextChanged(sender As Object, e As EventArgs) Handles Label56.TextChanged
        If Val(Label56.Text) = 0 Then
            Label57.Visible = False
            Label56.Visible = False
        Else
            Label57.Visible = True
            Label56.Visible = True
        End If
    End Sub
    Public Function Create_Database_Table()
        Dim cn As New SQLiteConnection
        Dim create_ As Boolean = False
        If open_MSSQL_Cstm(Database_File.lnk, cn) = True Then
            cmd = New SQLiteCommand("SELECT count(*) as c FROM sqlite_master WHERE type='table' AND name='cfg_Item'", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                If r("c") <> 1 Then
                    create_ = True
                End If
            End While
            r.Close()


            If create_ = True Then
                cmd = New SQLiteCommand("CREATE TABLE 'cfg_Item' (
	'Id'	INTEGER NOT NULL UNIQUE,
	'Head'	TEXT,
	'Value'	TEXT,
	PRIMARY KEY('Id' AUTOINCREMENT));", cn)

                cmd.ExecuteNonQuery()
            End If
        End If
    End Function

    Private Sub Panel6_Paint(sender As Object, e As PaintEventArgs) Handles Panel6.Paint

    End Sub

    Private Sub Stock_Item_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        Name_TXT.Focus()
        BG_frm.From_ID = From_ID
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub ReOrder_Panel_Paint(sender As Object, e As PaintEventArgs) Handles ReOrder_Panel.Paint

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub
End Class

