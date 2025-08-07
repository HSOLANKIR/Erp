Imports System.Data.SqlClient
Imports System.Data.SQLite
Imports System.Xml
Imports Tools.Grid

Public Class Inventory_BOM
    Dim From_ID As String
    Dim Path_End As String
    Public VC_ID_ As String
    Public Back_Obj As Object
    Private Sub Batch_ctrl1_Enter(sender As Object, e As EventArgs)
        Button_Clear()
    End Sub
    Public Function ctrl_manag(batch_ As String)
        If batch_ = "List" Then
            Head.Text = "Components list BOM"
            Me.BackColor = Color.MistyRose
            Batch_ctrl1.Visible = True
            Item_ctrl1.Dispose()
        Else
            Head.Text = "BOM Items Details"
            Me.BackColor = Color.LightYellow

            Item_ctrl1 = New Batch_Item_ctrl
            Item_ctrl1.Name = "Item_ctrl1"
            Me.Controls.Add(Item_ctrl1)
            AddHandler Item_ctrl1.Paint, AddressOf Item_ctrl1_Paint

            Batch_ctrl1.Visible = False
            Item_ctrl1.Visible = True

            Item_ctrl1.Batch_LAB.Text = batch_
            Item_ctrl1.Item_Label.Text = Batch_ctrl1.item_Lab.Text
            Item_ctrl1.Txt1.Focus()
        End If
    End Function
    Private Sub Batch_ctrl1_KeyDown(sender As Object, e As KeyEventArgs)

    End Sub

    Private Sub Inventory_BOM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text
        VC_ID_ = Link_Valu(0)
        BG_frm.HADE_TXT.Text = "Inventory Item Batch"

        Batch_ctrl1.ID_ = Val(VC_ID_)

        Item_ctrl1 = New Batch_Item_ctrl
        Item_ctrl1.Name = "Item_ctrl1"

        ctrl_manag("List")

        If VC_ID_ = 0 Or VC_ID_ = Nothing Then
            Item_ctrl1.Item_Label.Text = Stock_Item_frm.Name_TXT.Text
            Item_ctrl1.Label10.Text = Stock_Item_frm.Unit_TXT.Text
        Else
            Batch_ctrl1.item_Lab.Text = ": " & Find_DT_Value(Database_File.cre, "TBL_Stock_Item", "Name", $"ID = '{VC_ID_}'")
            Batch_ctrl1.Unit_ = Find_DT_Value(Database_File.cre, "TBL_Stock_Item", "Unit", $"ID = '{VC_ID_}'")
            Batch_ctrl1.Unit_ = Find_DT_Unit_Conves(Batch_ctrl1.Unit_)

            Item_ctrl1.Item_Label.Text = ": " & Find_DT_Value(Database_File.cre, "TBL_Stock_Item", "Name", $"ID = '{VC_ID_}'")
            Item_ctrl1.Label10.Text = Find_DT_Value(Database_File.cre, "TBL_Stock_Item", "Unit", $"ID = '{VC_ID_}'")
            Item_ctrl1.Label10.Text = Find_DT_Unit_Conves(Batch_ctrl1.Unit_)
        End If


        'Load_List()

    End Sub
    Public dt_batch As New XmlDocument
    Public dt_batch_item As New XmlDocument

    Public Item_ctrl1 As Batch_Item_ctrl
    Public Function List_Focus_value(Batch_idx As String, Next_Select As Boolean)
        With Batch_ctrl1
            If Next_Select = True Then
                .Find_Particuls_TXT(Batch_idx).Focus()
                SendKeys.Send("{TAB}")
            Else
                .Find_Particuls_TXT(Batch_idx).Focus()
            End If
        End With
    End Function
    Public Function Load_Item_Data(Panel_IDX As Integer)
        Item_ctrl1.Batch_list_Data_idx = Panel_IDX
        Dim data_ As String = Batch_ctrl1.Find_Data_Lab(Panel_IDX).Text
        Item_ctrl1.Txt1.Text = Batch_ctrl1.Find_Production_Qty_Lab(Panel_IDX).Text


        If data_ <> Nothing Then
            Dim local_xml As New XmlDataDocument
            local_xml.LoadXml(data_)

            'Item_ctrl1.platform.Controls.Clear()
            Dim nodes As XmlNodeList = local_xml.DocumentElement.SelectNodes("/Details/BOM")
            For Each node As XmlNode In nodes
                Item_ctrl1.Add_New()
                Dim idx As Integer = Item_ctrl1.platform.Controls.Count

                Dim batch_name As String = node.SelectSingleNode("Batch").InnerText
                Dim item_id As String = node.SelectSingleNode("Item").InnerText
                Dim item_name As String = Find_DT_Value(Database_File.cre, "TBL_Stock_Item", "Name", $"ID = '{item_id}'")
                Dim item_qty As String = node.SelectSingleNode("Qty").InnerText
                Dim item_unit As String = Find_DT_Value(Database_File.cre, "TBL_Stock_Item", "Unit", $"ID = '{item_id}'")
                item_unit = Find_DT_Unit_Conves(item_unit)

                With Item_ctrl1
                    .Find_AccID_Label(idx).Text = item_id
                    .Find_Particuls_TXT(idx).Text = item_name
                    .Find_qty_TXT(idx).Text = Val(item_qty)
                    .Find_unit_lab(idx).Text = item_unit
                End With
            Next
        End If
        If Item_ctrl1.platform.Controls.Count = 0 Then
            Item_ctrl1.Add_New()
        End If
    End Function
    Public Function Load_List()
        Batch_ctrl1.platform.Controls.Clear()

        Dim nodes As XmlNodeList = dt_batch.DocumentElement.SelectNodes("/List/Batch")
        For Each node As XmlNode In nodes
            Dim batch_name As String = node.SelectSingleNode("Name").InnerText
            Dim Production_qty As String = Val(node.SelectSingleNode("Qty_Production").InnerText)

            Dim nodes_it As XmlNodeList = dt_batch_item.DocumentElement.SelectNodes("/Batch_Details/Details")

            Dim data_ As String = "<Details>"
            For Each it As XmlNode In nodes_it
                Dim it_Batch_ As String = it.SelectSingleNode("Batch").InnerText
                Dim it_Name_ As String = it.SelectSingleNode("Item").InnerText
                Dim it_Qty_ As String = it.SelectSingleNode("Qty").InnerText

                If batch_name = it_Batch_ Then
                    data_ &= $"<BOM><Batch>{it_Batch_}</Batch>
<Item>{it_Name_}</Item>
<Qty>{it_Qty_}</Qty>
</BOM>"
                End If
            Next
            'nill data add
            data_ &= $"<BOM><Batch>{batch_name}</Batch>
<Item></Item>
<Qty></Qty></BOM>"

            data_ &= "</Details>"

            Batch_ctrl1.Add_New(batch_name, data_, Val(Production_qty))
        Next
    End Function

    Public Function Save_List()
        dt_batch = New XmlDocument

        Dim List As XmlNode = dt_batch.CreateElement("List")
        Dim Batch_ As XmlNode
        Dim Name_ As XmlNode
        Dim Qty_Production As XmlNode

        'Item xml Data
        Dim Pass_dt As New XmlDocument
        Dim Batch_Details_i As XmlNode = Pass_dt.CreateElement("Batch_Details")

        With Batch_ctrl1


            Dim P_ As New Queue(Of Panel)()
            For Each bg_p As Panel In .platform.Controls.OfType(Of Panel)()
                P_.Enqueue(bg_p)
            Next
            For Each bg_p As Panel In P_.Reverse
                Dim idx As Integer = .Find_Idx(bg_p)

                If .Find_Particuls_TXT(idx).Text <> Nothing Then

                    Batch_ = dt_batch.CreateElement("Batch")
                    Name_ = dt_batch.CreateElement("Name")
                    Name_.InnerText = .Find_Particuls_TXT(idx).Text
                    Batch_.AppendChild(Name_)

                    Qty_Production = dt_batch.CreateElement("Qty_Production")
                    Qty_Production.InnerText = Val(.Find_Production_Qty_Lab(idx).Text)
                    Batch_.AppendChild(Qty_Production)


                    List.AppendChild(Batch_)

                    If .Find_Data_Lab(idx).Text <> Nothing Then
                        Dim item_data As New XmlDocument
                        item_data.LoadXml(.Find_Data_Lab(idx).Text)
                        Dim nodes As XmlNodeList = item_data.DocumentElement.SelectNodes("/Details/BOM")

                        Dim Details_i As XmlNode
                        Dim Batch_i As XmlNode
                        Dim Item_i As XmlNode
                        Dim Qty_i As XmlNode

                        For Each r As XmlNode In nodes
                            Details_i = Pass_dt.CreateElement("Details")

                            Batch_i = Pass_dt.CreateElement("Batch")
                            Batch_i.InnerText = r.SelectSingleNode("Batch").InnerText
                            Details_i.AppendChild(Batch_i)

                            Item_i = Pass_dt.CreateElement("Item")
                            Item_i.InnerText = r.SelectSingleNode("Item").InnerText
                            Details_i.AppendChild(Item_i)

                            Qty_i = Pass_dt.CreateElement("Qty")
                            Qty_i.InnerText = r.SelectSingleNode("Qty").InnerText
                            Details_i.AppendChild(Qty_i)

                            Batch_Details_i.AppendChild(Details_i)
                        Next
                    End If
                End If
            Next
            Pass_dt.AppendChild(Batch_Details_i)
        End With

        dt_batch.AppendChild(List)
        Stock_Item_frm.dt_batch.LoadXml(dt_batch.InnerXml)
        Stock_Item_frm.dt_batch_item.LoadXml(Pass_dt.InnerXml)

    End Function

    Private Sub Inventory_BOM_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If Head.Text = "Components list BOM" Then
                If Msg_Exit_YN("BOM List") = DialogResult.Yes Then
                    Me.Dispose()
                End If
            ElseIf Head.Text = "BOM Items Details" Then
                If Msg_Exit_YN("BOM Items Details") = DialogResult.Yes Then
                    ctrl_manag("List")
                End If
            End If
        End If
    End Sub

    Private Sub Inventory_BOM_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End
        Back_Obj.Focus()
        'Frm_foCus()
    End Sub

    Private Sub Batch_ctrl1_Paint(sender As Object, e As PaintEventArgs) Handles Batch_ctrl1.Paint
        obj_center(sender, Me)
    End Sub

    Private Sub Item_ctrl1_Load(sender As Object, e As EventArgs)


    End Sub

    Private Sub Item_ctrl1_Paint(sender As Object, e As PaintEventArgs)
        obj_center(sender, Me)
    End Sub

    Private Sub Inventory_BOM_Enter(sender As Object, e As EventArgs) Handles Me.Enter

    End Sub

    Private Sub Inventory_BOM_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
    End Sub
End Class