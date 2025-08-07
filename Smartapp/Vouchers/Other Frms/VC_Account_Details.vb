Imports System.Data.SQLite
Imports Tools
Public Class VC_Account_Details
    Dim From_ID As String
    Dim Path_End As String
    Dim Load_ID, shiping_load_id As String
    Private Sub VC_Account_Details_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        obj_top(Panel1)

        Path_End = BG_frm.BG_Path_TXT.Text
        BG_frm.HADE_TXT.Text = "VC Ledger Details"
        BG_frm.TYP_TXT.Text = ""


        Button_Manage()
        NOT_Clear()
        Add_Hander_Remove_Handel(True)

        Load_data()
        List_set()
        Load_()


        Fill_Chart()
        Fill_Chart_data()

        If Voucher_Type() = "Inward" Then
            Panel5.Enabled = False
        Else
            Panel5.Enabled = True
        End If
    End Sub
    Private Function Fill_Chart_data()
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select vc.[Date],SUM(vc.Debit_Amount) as Dr,SUM(vc.Credit_Amount) as Cr From TBL_VC vc where vc.Ledger = '{Load_ID}' and vc.Visible = 'Approval'
GROUP BY STRFTIME('%m-%Y', [Date]);", cn)
            Dim r As SQLiteDataReader = cmd.ExecuteReader
            While r.Read

                Chart1.Series(0).Points.AddXY(CDate(r("Date").ToString).ToString("MMM-yy"), Val(r("Cr").ToString))
                Chart1.Series(1).Points.AddXY(CDate(r("Date").ToString).ToString("MMM-yy"), Val(r("Dr").ToString))

            End While
        End If
        cn.Close()
    End Function
    Private Function Fill_Chart()






        Dim Series1 As DataVisualization.Charting.Series = New DataVisualization.Charting.Series()
        Dim Series2 As DataVisualization.Charting.Series = New DataVisualization.Charting.Series()

        Series1.IsValueShownAsLabel = True
        Series2.IsValueShownAsLabel = True


        Series1.ChartArea = "ChartArea1"
        Series1.Color = Color.Blue
        Series1.Legend = "Legend1"
        Series1.Name = "Purchase"
        Series1.ChartType = DataVisualization.Charting.SeriesChartType.Column

        Series2.ChartArea = "ChartArea1"
        Series2.Color = Color.Red
        Series2.Legend = "Legend1"
        Series2.Name = "Sales"
        Series2.ChartType = DataVisualization.Charting.SeriesChartType.Column

        Chart1.Series.Clear()

        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Series.Add(Series2)

        Me.Chart1.Size = New Size(1246, 209)
        Me.Chart1.Text = "Chart1"
    End Function
    Private Function Button_Manage()
        BG_frm.B_1.Text = "&E : Exit"
        BG_frm.B_2.Text = "&S : Save"
    End Function
    Private Function Add_Hander_Remove_Handel(Ans As Boolean)
        If Ans = True Then
            AddHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            AddHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
        Else
            RemoveHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            RemoveHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
        End If
    End Function
    Private Sub B_1_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Succ_ = False
            Me.Dispose()
        End If
    End Sub
    Private Sub B_2_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Save_()
            Succ_ = True
            Me.Dispose()
        End If
    End Sub

    Private Sub VC_Account_Details_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.HADE_TXT.Text = "VC Ledger Details"
        BG_frm.TYP_TXT.Text = ""
        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text

        Button_Clear()
        Button_Manage()

        Load_data()


        Acc_Name_TXT.Focus()
    End Sub

    Private Sub VC_Account_Details_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Succ_ = False
            Me.Dispose()
        End If
    End Sub
    Dim Succ_ As Boolean = False
    Private Sub VC_Account_Details_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End
        Add_Hander_Remove_Handel(False)
        'Frm_foCus()
        'Inventory_Vouchers_frm.Yn4.Focus()
        If Succ_ = True Then
            'SendKeys.Send("{TAB}")
            Inventory_Vouchers_frm.SelectNextControl(Inventory_Vouchers_frm.Yn4, True, True, True, True)
        Else
            Inventory_Vouchers_frm.Yn4.Focus()
        End If
    End Sub
    Dim acc_list As List_frm
    Dim shiping_list As List_frm
    Dim state_list As List_frm
    Dim gst_type_list As List_frm
    Dim ag_contry As List_frm
    Dim ag_contry2 As List_frm
    Private Function List_set()
        acc_list = New List_frm
        List_Setup("List of Ledger", Select_List.Right_Dock, Select_List_Format.Defolt, Acc_Name_TXT, acc_list, Account_Source, 400)

        shiping_list = New List_frm
        List_Setup("List of Ledger", Select_List.Botom, Select_List_Format.Defolt, Ship_Name_TXT, shiping_list, Account_Source01, 400)

        state_list = New List_frm
        List_Setup("List of States", Select_List.Right_Dock, Select_List_Format.Singel, Acc_State_TXT, state_list, State_Source, 300)


        gst_type_list = New List_frm
        List_Setup("List GST Type", Select_List.Right, Select_List_Format.Singel, Acc_GST_Type_TXT, gst_type_list, GST_Type_Source, 150)
        ''

        state_list = New List_frm
        List_Setup("List of States", Select_List.Right_Dock, Select_List_Format.Singel, Ship_State_TXT, state_list, State_Source, 300)

        gst_type_list = New List_frm
        List_Setup("List GST Type", Select_List.Right, Select_List_Format.Singel, Ship_GST_Type_TXT, gst_type_list, GST_Type_Source, 150)

        ag_contry = New List_frm
        List_Setup("List of Countries", Select_List.Right_Dock, Select_List_Format.Defolt, Txt1, ag_contry, Country_Source, 320)

        ag_contry2 = New List_frm
        List_Setup("List of Countries", Select_List.Right_Dock, Select_List_Format.Defolt, Txt2, ag_contry2, Country_Source, 320)


    End Function
    Private Function Load_()

        With Inventory_Vouchers_frm
            Load_ID = .To_ID
            shiping_load_id = .Ship_ID

            Acc_id = .Acc_ID
            Acc_Name_TXT.Text = .Account_TXT.Text
            Acc_Mailing_TXT.Text = .To_Name
            Acc_Address_TXT.Text = .To_Address1

            Txt1.Text = .To_Country
            Acc_State_TXT.Text = .To_State
            Acc_GST_TXT.Text = .To_GST
            Acc_GST_Type_TXT.Text = .To_GST_Type


            Ship_Name_TXT.Text = .Ship_Name
            Ship_Mailing_TXT.Text = .Ship_Mailing
            Ship_Address_TXT.Text = .Ship_Address

            Txt2.Text = .Ship_Country
            Ship_State_TXT.Text = .Ship_State
            Ship_Pincode_TXT.Text = .Ship_Pincode
            Ship_GST_Type_TXT.Text = .Ship_GST_Type
            Ship_GST_TXT.Text = .Ship_GST
        End With


        If Voucher_Type() = "Inward" Then
            If Ship_Name_TXT.Text = Nothing Then
                Ship_Name_TXT.Text = Company_Name_str
                Ship_Mailing_TXT.Text = Company_Name_str

                Ship_Address_TXT.Text = Company_Address_str
                Ship_Pincode_TXT.Text = Company_Pincode_str
                Ship_State_TXT.Text = Company_State_str
                Ship_GST_TXT.Text = Company_GST_str
            End If
        End If
    End Function
    Dim dt_1 As New DataTable
    Private Function Load_data()
        Dim Positive As String = Find_DT_Value(Database_File.cmp, "TBL_Features", "Value", "Head = 'Positive Value'")
        Dim Negative As String = Find_DT_Value(Database_File.cmp, "TBL_Features", "Value", "Head = 'Negative Value'")

        Dim cn As New SQLiteConnection
        Dim dt_ As New DataTable
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            dt_.Columns.Clear()
            dt_.Columns.Add("Name")
            dt_.Columns.Add("Alias")
            dt_.Columns.Add("ID")

            dt_.Rows.Add("", "Create")

            dt_1 = New DataTable
            dt_1.Columns.Clear()
            dt_1.Columns.Add("Name")
            dt_1.Columns.Add("Alias")
            dt_1.Columns.Add("ID")

            dt_1.Rows.Add("", "Create")

            'dt_1.Rows.Add("", "New Party", "0")
            Dim r As SQLiteDataReader
            cmd = New SQLiteCommand($"Select [ID],[Name],[Group],[Alise],[Cradit]
from TBL_Ledger LD where ([Group] = '22' or [Group] = '26' or [Group] = '27') Order By [Name]", cn)

            With cmd.Parameters
                r = cmd.ExecuteReader
                While r.Read
                    If Voucher_Type() = "Outward" Then
                        dt_1.Rows.Add(r("Name"), r("Alise"), r("ID"))
                    End If
                    dt_.Rows.Add(r("Name").ToString, r("Alise").ToString, r("ID"))
                End While
            End With
            r.Close()

            If Voucher_Type() = "Outward" Then
            Else
                With Inventory_Vouchers_frm
                    'If .Ship_Name <> Company_Name_str Then
                    dt_1.Rows.Add(Company_Name_str, "", Company_ID_str)
                    If .Ship_Name <> Nothing Then
                        'dt_1.Rows.Add(.Ship_Name, "", "")
                    End If
                    'End If
                End With
            End If
            Account_Source.DataSource = dt_
            Account_Source01.DataSource = dt_1
        End If

        If open_MSSQL_Cstm(Database_File.cfgs, cn) = True Then
            dt_ = New DataTable
            dt_.Columns.Add("Name")
            dt_.Rows.Add("Not Applicable")

            cmd = New SQLiteCommand("Select * From TBL_State", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                dt_.Rows.Add(r("Name"))
            End While
            State_Source.DataSource = dt_
        End If


        Dim dt_country As New DataTable
        dt_country.Columns.Clear()
        dt_country.Clear()
        dt_country.Columns.Add("Country_Name")
        dt_country.Columns.Add("Code")
        dt_country.Columns.Add("ID")

        If open_MSSQL(Database_File.cfgs) = True Then
            cmd = New SQLiteCommand("Select * From TBL_Currency", con)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                dt_country.Rows.Add(r("Country_Name"), r("Code"))
            End While
            r.Close()
            Country_Source.DataSource = dt_country
        End If

        Dim dt_gst As New DataTable
        dt_gst.Columns.Add("Head")

        dt_gst.Rows.Add("Unknown")
        dt_gst.Rows.Add("Composition")
        dt_gst.Rows.Add("Consumer")
        dt_gst.Rows.Add("Regular")
        dt_gst.Rows.Add("Unregistered")

        GST_Type_Source.DataSource = dt_gst
    End Function
    Private Function Save_()
        With Inventory_Vouchers_frm
            .Acc_ID = Acc_id
            .To_ID = Acc_id

            .Account_TXT.Text = Acc_Name_TXT.Text
            .To_Name = Acc_Mailing_TXT.Text
            .To_Address1 = Acc_Address_TXT.Text
            .To_GST = Acc_GST_TXT.Text
            .To_GST_Type = Acc_GST_Type_TXT.Text
            .To_Pincode = Acc_Pincode_TXT.Text
            .To_State = Acc_State_TXT.Text
            .To_Country = Txt1.Text

            .Ship_ID = shiping_id
            .Ship_Name = Ship_Name_TXT.Text
            .Ship_Mailing = Ship_Mailing_TXT.Text
            .Ship_Address = Ship_Address_TXT.Text
            .Ship_State = Ship_State_TXT.Text
            .Ship_Pincode = Ship_Pincode_TXT.Text
            .Ship_GST = Ship_GST_TXT.Text
            .Ship_GST_Type = Ship_GST_Type_TXT.Text
            .Ship_Country = Txt2.Text

            .GST_Type_()

            .Select_Ledger()
        End With

    End Function

    Private Sub Transport_Name_TXT_TextChanged(sender As Object, e As EventArgs) Handles Acc_Name_TXT.TextChanged

    End Sub

    Dim Acc_id As String
    Private Sub Account_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles Acc_Name_TXT.KeyDown
        If e.KeyCode = Keys.Enter Then
            If acc_list.List_Grid.CurrentRow.Cells(1).Value = "Create" Then
                Create_Ledger(sender)
                Exit Sub
            End If

            If Load_ID <> acc_list.List_Grid.CurrentRow.Cells(2).Value.ToString() Then

                Acc_Mailing_TXT.Text = acc_list.List_Grid.CurrentRow.Cells(0).Value.ToString()
                Acc_id = acc_list.List_Grid.CurrentRow.Cells(2).Value
                Acc_Address_TXT.Text = Inventory_Vouchers_frm.Address_set(Acc_id)

                Dim cn As New SQLiteConnection
                If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                    cmd = New SQLiteCommand($"Select * From TBL_Ledger ld where ld.id = '{Acc_id}'", cn)
                    Dim r As SQLiteDataReader
                    r = cmd.ExecuteReader
                    While r.Read
                        Txt1.Text = r("Country").ToString
                        Acc_State_TXT.Text = r("State").ToString
                        Acc_GST_TXT.Text = r("GSTNo").ToString
                        Acc_GST_Type_TXT.Text = r("GST_Type").ToString
                        Acc_Pincode_TXT.Text = r("Pincode").ToString
                    End While
                    r.Close()
                End If

                If Voucher_Type() = "Outward" Then
                    If Acc_id = shiping_load_id Or shiping_load_id = Nothing Then
                        shiping_load_id = Load_ID
                        Ship_Name_TXT.Text = acc_list.List_Grid.CurrentRow.Cells(0).Value.ToString()
                        Ship_Mailing_TXT.Text = acc_list.List_Grid.CurrentRow.Cells(0).Value.ToString()
                        shiping_id = acc_list.List_Grid.CurrentRow.Cells(2).Value
                        Ship_Address_TXT.Text = Inventory_Vouchers_frm.Address_set(Acc_id)

                        Txt2.Text = Txt1.Text
                        Ship_State_TXT.Text = Acc_State_TXT.Text
                        Ship_GST_Type_TXT.Text = Acc_GST_Type_TXT.Text
                        Ship_GST_TXT.Text = Acc_GST_TXT.Text
                    End If
                End If
                Load_ID = Acc_id
            End If
            Fill_Chart()
            Fill_Chart_data()
        End If

        If e.KeyCode = Keys.C AndAlso e.Modifiers = Keys.Alt Then
            Create_Ledger(sender)
        ElseIf e.KeyCode = Keys.Enter AndAlso e.Modifiers = Keys.Control Then
            Cell("Account Ledger", "", "Alter_Close", Acc_id)
            Ledger_frm.close_focus_obj = sender
        ElseIf e.KeyCode = Keys.Enter Then

        End If
    End Sub
    Private Function Create_Ledger(txt As TXT)
        Cell("Account Ledger", "", "Create_Close", "")
        With Ledger_frm
            .close_focus_obj = txt
            .Name_TXT.Text = txt.Text
            If Inventory_Vouchers_frm.Voucher_Type_LB.Text = "Sales" Or Inventory_Vouchers_frm.Voucher_Type_LB.Text = "Sales Order" Or Inventory_Vouchers_frm.Voucher_Type_LB.Text = "Outward Register" Or Inventory_Vouchers_frm.Voucher_Type_LB.Text = "Debit Note" Or Inventory_Vouchers_frm.Voucher_Type_LB.Text = "Purchase Return" Then
                .Group_TXT.Text = "Sundry Debtors"
            Else
                .Group_TXT.Text = "Sundry Creditors"
            End If
        End With

    End Function
    Private Function Voucher_Type() As String
        Dim str As String = Inventory_Vouchers_frm.Voucher_Type_LB.Text
        If str = "Purchase" Or str = "Purchase Order" Or str = "Inward Register" Then
            Return "Inward"
        Else
            Return "Outward"
        End If
    End Function
    Private Sub Acc_State_TXT_TextChanged(sender As Object, e As EventArgs) Handles Acc_State_TXT.TextChanged, Ship_State_TXT.TextChanged
        'If Voucher_Type() = "Inward" Then
        '    Label16.Text = Acc_State_TXT.Text & " to " & Ship_State_TXT.Text
        'Else
        '    Label16.Text = Company_State_str & " to " & Acc_State_TXT.Text
        'End If
    End Sub

    Private Sub Select_1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Ship_Address_TXT_TextChanged(sender As Object, e As EventArgs) Handles Ship_Address_TXT.TextChanged

    End Sub

    Private Sub Ship_Address_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles Ship_Address_TXT.KeyDown
        If e.KeyCode = Keys.Enter Then
            'Save_()
            'Succ_ = False
            'Me.Dispose()
        End If
    End Sub
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        obj_top(Panel1)
    End Sub

    Private Sub Acc_Name_TXT_Enter(sender As Object, e As EventArgs) Handles Acc_Name_TXT.Enter
        Txt1_TextChanged(sender, e)
    End Sub

    Private Sub Txt1_TextChanged(sender As Object, e As EventArgs) Handles Ship_Name_TXT.TextChanged
        'If shiping_list.List_Grid.Rows.Count = 1 Then
        '    dt_1.Rows(0)(0) = sender.Text
        'Else
        '    dt_1.Rows(0)(0) = ""
        'End If
    End Sub
    Dim shiping_id As String

    Private Sub Acc_GST_Type_TXT_TextChanged(sender As Object, e As EventArgs) Handles Acc_GST_Type_TXT.TextChanged
        If Acc_GST_Type_TXT.Text = "Consumer" Or Acc_GST_Type_TXT.Text = "Unregistered" Then
            Acc_GST_TXT.Text = ""
            Acc_GST_TXT.Enabled = False
        Else
            Acc_GST_TXT.Enabled = True
        End If
    End Sub

    Private Sub Txt1_KeyDown(sender As Object, e As KeyEventArgs) Handles Ship_Name_TXT.KeyDown
        If e.KeyCode = Keys.Enter Then
            If shiping_list.List_Grid.CurrentRow.Cells(1).Value.ToString() = "Create" Then
                Create_Ledger(sender)
                Exit Sub
            End If
            If shiping_load_id <> shiping_list.List_Grid.CurrentRow.Cells(2).Value.ToString() Then
                'MsgBox(shiping_load_id & "-" & shiping_list.List_Grid.CurrentRow.Cells(0).Value.ToString())
                Ship_Mailing_TXT.Text = shiping_list.List_Grid.CurrentRow.Cells(0).Value.ToString()
                shiping_id = shiping_list.List_Grid.CurrentRow.Cells(2).Value.ToString

                Ship_Address_TXT.Text = Inventory_Vouchers_frm.Address_set(shiping_id)

                Ship_State_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Ledger", "State", "ID = '" & shiping_id & "'")
                Ship_Pincode_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Ledger", "Pincode", "ID = '" & shiping_id & "'")
                Ship_GST_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Ledger", "GSTNo", "ID = '" & shiping_id & "'")
                Ship_GST_Type_TXT.Text = Find_DT_Value(Database_File.cre, "TBL_Ledger", "GST_Type", "ID = '" & shiping_id & "'")

                shiping_load_id = shiping_id
            End If
        End If
    End Sub

    Private Sub Ship_GST_TXT_TextChanged(sender As Object, e As EventArgs) Handles Ship_GST_TXT.TextChanged

    End Sub

    Private Sub Acc_Address_TXT_TextChanged(sender As Object, e As EventArgs) Handles Acc_Address_TXT.TextChanged

    End Sub

    Private Sub save_txt_Enter(sender As Object, e As EventArgs) Handles save_txt.Enter
        Save_()
        Succ_ = True
        Me.Dispose()
    End Sub

    Private Sub Acc_Address_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles Acc_Address_TXT.KeyDown
        If e.KeyCode = Keys.C AndAlso e.Modifiers = Keys.Alt Then

        ElseIf e.KeyCode = Keys.Enter AndAlso e.Modifiers = Keys.Shift Then

        ElseIf e.KeyCode = Keys.Enter Then
            'SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub acc_State_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles Acc_State_TXT.KeyDown
        If e.KeyCode = Keys.Enter Then
            If state_list.List_Grid.CurrentRow.Cells(0).Value = "Not Applicable" Then

                Txt1.Enabled = True
            Else
                Txt1.Text = "India"
                Txt1.Enabled = False
            End If
        End If
    End Sub

    Private Sub Txt1_TextChanged_1(sender As Object, e As EventArgs) Handles Txt1.TextChanged
        If Txt1.Text <> "India" Then
            Acc_GST_Type_TXT.Text = ""
            Acc_GST_Type_TXT.Enabled = False

            Acc_GST_TXT.Text = ""
            Acc_GST_TXT.Enabled = False

        Else
            Acc_GST_Type_TXT.Enabled = True
            Acc_GST_TXT.Enabled = True
        End If
    End Sub

    Private Sub Txt2_TextChanged(sender As Object, e As EventArgs) Handles Txt2.TextChanged
        If Txt2.Text <> "India" Then
            Ship_GST_Type_TXT.Text = ""
            Ship_GST_Type_TXT.Enabled = False

            Ship_GST_TXT.Text = ""
            Ship_GST_TXT.Enabled = False

        Else
            Ship_GST_Type_TXT.Enabled = True
            Ship_GST_TXT.Enabled = True
        End If
    End Sub

    Private Sub Ship_State_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles Ship_State_TXT.KeyDown
        If e.KeyCode = Keys.Enter Then
            If state_list.List_Grid.CurrentRow.Cells(0).Value = "Not Applicable" Then

                Txt2.Enabled = True
            Else
                Txt2.Text = "India"
                Txt2.Enabled = False
            End If
        End If
    End Sub

    Private Sub State_Source_CurrentChanged(sender As Object, e As EventArgs) Handles State_Source.CurrentChanged

    End Sub

    Private Sub VC_Account_Details_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
    End Sub
End Class