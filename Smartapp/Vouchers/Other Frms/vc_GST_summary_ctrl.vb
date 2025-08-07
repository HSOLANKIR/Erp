Imports Tools

Public Class vc_GST_summary_ctrl
    Private Sub vc_GST_summary_ctrl_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Dim curr_count As Integer = 0

    Public Function Refresh_Data_()
        bg_panel.Controls.Clear()
        CGST_List.Clear()
        SGST_List.Clear()
        IGST_List.Clear()



        Dim Head As String
        With Inventory_Vouchers_frm.Voucher_Type_LB
            If .Text = "Sales" Or .Text = "Sales Order" Or .Text = "Purchase Return" Then
                Head = "OUTPUT"
            ElseIf .Text = "Purchase" Or .Text = "Purchase Order" Or .Text = "Sales Return" Then
                Head = "INPUT"
            End If
        End With

        With Inventory_Vouchers_frm.Sp_controls1

            Dim G5 As Decimal = 0
            Array.ForEach(.stock_panel.Controls.OfType(Of sp_control_under)().ToArray(),
              Sub(t) If t.GST_Per = 5 Then G5 += t.GST_Amount)
            If G5 <> 0 Then
                Add_New($"{Head} GST 5%", G5)
            End If

            Dim G12 As Decimal = 0
            Array.ForEach(.stock_panel.Controls.OfType(Of sp_control_under)().ToArray(),
              Sub(t) If t.GST_Per = 12 Then G12 += t.GST_Amount)
            If G12 <> 0 Then
                Add_New($"{Head} GST 12%", G12)
            End If

            Dim G18 As Decimal = 0
            Array.ForEach(.stock_panel.Controls.OfType(Of sp_control_under)().ToArray(),
              Sub(t) If t.GST_Per = 18 Then G18 += t.GST_Amount)
            If G18 <> 0 Then
                Add_New($"{Head} GST 18%", G18)
            End If

            Dim G28 As Decimal = 0
            Array.ForEach(.stock_panel.Controls.OfType(Of sp_control_under)().ToArray(),
              Sub(t) If t.GST_Per = 28 Then G28 += t.GST_Amount)
            If G28 <> 0 Then
                Add_New($"{Head} GST 28%", G28)
            End If

        End With




        Try
            Label7.Text = N2_FORMATE(CGST_List.Sum(Function(m)
                                                       Return nUmBeR_FORMATE(m.Text)
                                                   End Function))
        Catch ex As Exception

        End Try

        Try
            Label8.Text = N2_FORMATE(SGST_List.Sum(Function(m)
                                                       Return nUmBeR_FORMATE(m.Text)
                                                   End Function))
        Catch ex As Exception

        End Try

        Try
            Label9.Text = N2_FORMATE(IGST_List.Sum(Function(m)
                                                       Return nUmBeR_FORMATE(m.Text)
                                                   End Function))
        Catch ex As Exception

        End Try

    End Function

    Public Function Add_New(head As String, GST_ As String)
        Dim IGST As String = 0
        If Inventory_Vouchers_frm.TAX_Type = "CS" Then
            GST_ = (nUmBeR_FORMATE(GST_ / 2))
            IGST = ""
        Else
            IGST = (GST_)
            GST_ = ""
        End If



        curr_count = bg_panel.Controls.OfType(Of Panel).ToList.Count
        Dim bg_p As Panel = New Panel
        Dim particuls_txt As Label = New Label
        Dim amt_txt As Label = New Label

        Dim CGST_txt As Label = New Label
        Dim SGST_txt As Label = New Label
        Dim IGST_txt As Label = New Label

        bg_p.Controls.Add(particuls_txt)
        bg_p.Controls.Add(CGST_txt)
        bg_p.Controls.Add(SGST_txt)
        bg_p.Controls.Add(IGST_txt)
        bg_p.Controls.Add(amt_txt)

        bg_p.Dock = DockStyle.Top
        bg_p.Location = New Point(0, 0)
        bg_p.Name = "bg_" & (curr_count + 1)
        bg_p.TabIndex = curr_count
        bg_p.Size = New Size(903, 17)



        particuls_txt.Name = "headtxt_" & (curr_count + 1)
        particuls_txt.TextAlign = ContentAlignment.MiddleLeft
        particuls_txt.AutoSize = False
        particuls_txt.Dock = DockStyle.Fill
        particuls_txt.Size = Label1.Size
        'particuls_txt.Padding = Label4.Padding
        particuls_txt.Text = head
        particuls_txt.BringToFront()


        CGST_txt.Name = "cgattxt_" & (curr_count + 1)
        CGST_txt.TextAlign = ContentAlignment.MiddleRight
        CGST_txt.AutoSize = False
        CGST_txt.Dock = DockStyle.Right
        CGST_txt.Size = Label2.Size
        CGST_txt.Text = N2_FORMATE(GST_)
        CGST_txt.SendToBack()
        AddHandler CGST_txt.TextChanged, AddressOf Total_TextChanged
        CGST_List.Add(CGST_txt)

        SGST_txt.Name = "sgattxt_" & (curr_count + 1)
        SGST_txt.TextAlign = ContentAlignment.MiddleRight
        SGST_txt.AutoSize = False
        SGST_txt.Dock = DockStyle.Right
        SGST_txt.Size = Label2.Size
        SGST_txt.Text = N2_FORMATE(GST_)
        SGST_txt.SendToBack()
        AddHandler SGST_txt.TextChanged, AddressOf Total_TextChanged
        SGST_List.Add(SGST_txt)


        IGST_txt.Name = "igattxt_" & (curr_count + 1)
        IGST_txt.TextAlign = ContentAlignment.MiddleRight
        IGST_txt.AutoSize = False
        IGST_txt.Dock = DockStyle.Right
        IGST_txt.Size = Label2.Size
        IGST_txt.Text = N2_FORMATE(IGST)
        IGST_txt.SendToBack()
        IGST_List.Add(IGST_txt)

        AddHandler CGST_txt.TextChanged, AddressOf Total_TextChanged


        amt_txt.Name = "amttxt_" & (curr_count + 1)
        amt_txt.TextAlign = ContentAlignment.MiddleRight
        amt_txt.Font = New Font("Arial", 9.75, FontStyle.Bold)
        amt_txt.AutoSize = False
        amt_txt.Dock = DockStyle.Right
        amt_txt.Size = Label2.Size
        'amt_txt.Padding = Label4.Padding
        amt_txt.Text = nUmBeR_FORMATE(Val(Val(GST_) * 2) + Val(IGST))
        amt_txt.SendToBack()

        AddHandler amt_txt.TextChanged, AddressOf Amt_Label_ChangeTxt


        bg_panel.Controls.Add(bg_p)
        bg_p.BringToFront()
    End Function
    Public Function Find_Idx(sender As Object) As Integer
        Try
            Return sender.Name.Split("_")(1)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Head_ID(index As Integer) As Label
        Try
            Return CType(bg_panel.Controls.Find(("headtxt_" & index), True).First, Label)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Total_TXT(index As Integer) As Label
        Try
            Return CType(bg_panel.Controls.Find(("amttxt_" & index), True).First, Label)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_CGST_ID(index As Integer) As Label
        Try
            Return CType(bg_panel.Controls.Find(("cgattxt_" & index), True).First, Label)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_SGST_ID(index As Integer) As Label
        Try
            Return CType(bg_panel.Controls.Find(("sgattxt_" & index), True).First, Label)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_IGST_ID(index As Integer) As Label
        Try
            Return CType(bg_panel.Controls.Find(("igattxt_" & index), True).First, Label)
        Catch ex As Exception

        End Try
    End Function


    Public Function Find_bg_panel(index As Integer) As Panel
        Try
            Return CType(bg_panel.Controls.Find(("bg_" & index), True).First, Panel)
        Catch ex As Exception

        End Try
    End Function

    Private Sub Amt_Label_ChangeTxt(sender As Object, e As EventArgs)
        Dim idx As Integer = Find_Idx(sender)

        If Val(Find_Total_TXT(idx).Text) = 0 Then
            bg_panel.Controls.Remove(Find_bg_panel(idx))
        End If

    End Sub

    Private Sub Total_TextChanged(sender As Object, e As EventArgs)
        Dim idx As Integer = Find_Idx(sender)

        Find_Total_TXT(idx).Text = nUmBeR_FORMATE(Val(Find_CGST_ID(idx).Text) + Val(Find_SGST_ID(idx).Text) + Val(Find_IGST_ID(idx).Text))

        MsgBox(Find_Total_TXT(idx).Text)
    End Sub

    Private Sub vc_GST_summary_ctrl_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim ctlpos As Point = Label5.PointToScreen(Label5.DisplayRectangle.Location)
        B01.Location = New Point(ctlpos.X, 0)
        B01.Height = Me.Height

        ctlpos = New Point
        ctlpos = Label4.PointToScreen(Label4.DisplayRectangle.Location)
        B02.Location = New Point(ctlpos.X, 0)
        B02.Height = Me.Height

        ctlpos = New Point
        ctlpos = Label3.PointToScreen(Label3.DisplayRectangle.Location)
        B03.Location = New Point(ctlpos.X, 0)
        B03.Height = Me.Height

        ctlpos = New Point
        ctlpos = Label2.PointToScreen(Label2.DisplayRectangle.Location)
        B04.Location = New Point(ctlpos.X, 0)
        B04.Height = Me.Height


    End Sub
    Private CGST_List As New List(Of Label)
    Private SGST_List As New List(Of Label)
    Private IGST_List As New List(Of Label)

    Private Sub Total_Balance(sender As Object, e As EventArgs) Handles Label7.TextChanged, Label8.TextChanged, Label9.TextChanged
        Label10.Text = N2_FORMATE(nUmBeR_FORMATE(Label7.Text) + nUmBeR_FORMATE(Label8.Text) + nUmBeR_FORMATE(Label9.Text))
    End Sub
End Class
