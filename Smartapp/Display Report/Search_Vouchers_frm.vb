Imports System.Data.SQLite

Public Class Search_Vouchers_frm
    Dim From_ID As String
    Private VC_Type_ As String
    Private VC_ID_ As String
    Private Path_End As String
    Private Sub Search_Vouchers_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text

        BG_frm.HADE_TXT.Text = "Search Vouchers"
        BG_frm.TYP_TXT.Text = "Display"

        Button_Manage()
        Add_Hander_Remove_Handel(True)

        Fill_Source()

        me_list = New List_frm
        List_Setup("Filter Type", Select_List.Right, Select_List_Format.Singel, TX, me_list, Type_Source, 150)
    End Sub
    Dim me_list As List_frm
    Private Function Fill_Source()
        Dim dt As New DataTable
        dt.Columns.Add("Head")

        dt.Rows.Add("Full Search")
        dt.Rows.Add("Voucher No")
        dt.Rows.Add("Voucher Amount")
        dt.Rows.Add("Transportation")
        dt.Rows.Add("e-wayBill Details")

        Type_Source.DataSource = dt

    End Function
    Dim Defolt_Select_ID As String = 0
    Private Sub Search_Vouchers_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.HADE_TXT.Text = "Search Vouchers"
        BG_frm.TYP_TXT.Text = "Display"

        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text


        Button_Clear()
        Button_Manage()
        cfg_fill()

        If bg_Panel.Visible = True Then
            Fill_Grid()
        End If

        Grid1.Focus()
    End Sub
    Private Function G_Voucher_No() As String
        Dim Filter_ As String = ""
        Filter_ &= $"vc.Voucher_No like '%{Search_TXT.Text}%'"
        Filter_ &= $"or vc.Supplier_IVC_No like '%{Search_TXT.Text}%'"

        Return Filter_
    End Function
    Private Function G_Amount() As String
        Dim Filter_ As String = ""
        Filter_ &= $"vc.Debit_Amount like '%{Search_TXT.Text}%'"
        Filter_ &= $"or vc.Credit_Amount like '%{Search_TXT.Text}%'"

        Return Filter_
    End Function
    Private Function G_Transportation() As String
        Dim Filter_ As String = ""
        Filter_ &= $"vo.Transportation_Name like '%{Search_TXT.Text}%'"
        Filter_ &= $"or vo.Transport_ID like '%{Search_TXT.Text}%'"
        Filter_ &= $"or vo.Vihical_No like '%{Search_TXT.Text}%'"
        Filter_ &= $"or vo.Vihical_Type like '%{Search_TXT.Text}%'"
        Filter_ &= $"or vo.LR_No like '%{Search_TXT.Text}%'"
        Filter_ &= $"or vo.Driver_Name like '%{Search_TXT.Text}%'"
        Filter_ &= $"or vo.Driver_Phone like '%{Search_TXT.Text}%'"
        Return Filter_
    End Function
    Private Function G_EwayBill() As String
        Dim Filter_ As String = ""
        Filter_ &= $"vo.eWay_Bill_No like '%{Search_TXT.Text}%'"

        Return Filter_
    End Function
    Private Function Fill_Grid()
        Try
            If Grid1.Rows.Count <> 0 Then
                Defolt_Select_ID = Grid1.CurrentRow.Cells(0).Value.ToString
            End If
        Catch ex As Exception

        End Try

        Dim dt As New DataTable
        dt.Columns.Add("Tra_ID")
        dt.Columns.Add("Date")
        dt.Columns.Add("Voucher No")
        dt.Columns.Add("Voucher Type")
        dt.Columns.Add("Particulars")
        dt.Columns.Add("Value")
        dt.Columns.Add("vc_id")
        dt.Columns.Add("vc_type")


        Dim Filter_ As String = ""
        If TX.Text = "Full Search" Then
            Filter_ &= G_Voucher_No()
            Filter_ &= "or " & G_Amount()
            Filter_ &= "or " & G_Transportation()
            Filter_ &= "or " & G_EwayBill()

        ElseIf TX.Text = "Voucher No" Then
            Filter_ = G_Voucher_No()
        ElseIf TX.Text = "Voucher Amount" Then
            Filter_ = G_Amount()
        ElseIf TX.Text = "Transportation" Then
            Filter_ = G_Transportation()
        ElseIf TX.Text = "e-wayBill Details" Then
            Filter_ = G_EwayBill()
        End If

        Dim Branch_Filter As String
        If Dft_Branch <> "Primary" Then
            Branch_Filter = " AND VC.Branch = '" & Find_DT_Value(Database_File.cre, "TBL_Ledger", "ID", "Name = '" & Dft_Branch & "'") & "'"
        End If

        Dim f As String = $"%{Search_TXT.Text}%"
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            cmd = New SQLiteCommand($"Select * ,(Select ld.name From TBL_Ledger ld where ld.ID = vc.Ledger) as Ledger_Name,(Select c.name From TBL_Voucher_Create c where c.ID = vc.Voucher_Type_ID) as Voucher_Name
From TBL_VC vc
LEFT JOIN TBL_VC_Other vo on vo.Tra_ID = vc.Tra_ID
Where (vc.Tra_ID <> '0')
and ({Filter_}) and vc.Visible = 'Approval' {Branch_Filter}
Group By vc.Tra_ID", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            Dim dr As DataRow
            While r.Read
                Dim Date_ As String = CDate(r("Date")).ToString(Date_Format_fech)

                dr = dt.NewRow
                dr("Tra_ID") = r("Tra_ID")
                dr("Date") = Date_Formate(Date_)
                dr("Voucher No") = r("Voucher_No")
                dr("Voucher Type") = r("Voucher_Name")
                dr("vc_type") = r("Voucher_Type")
                dr("Particulars") = r("Ledger_Name")
                dr("vc_id") = r("Voucher_Type_ID")
                dr("Value") = N2_FORMATE(Val(r("Credit_Amount")) + Val(r("Debit_Amount")))
                dt.Rows.Add(dr)

                If Defolt_Select_ID = r("Tra_ID") Then
                    Defolt_Select_ID = dt.Rows.Count - 1
                End If

            End While
            r.Close()
        End If

        Head_Source.DataSource = dt
        Grid1.DataSource = Head_Source


        Grid1.Columns(0).Visible = False
        Grid1.Columns(6).Visible = False
        Grid1.Columns(7).Visible = False

        Grid1.Columns(1).Width = 100
        Grid1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        Grid1.Columns(2).Width = 150
        Grid1.Columns(3).Width = 150
        Grid1.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        Grid1.Columns(5).Width = 100
        Grid1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


        If Grid1.Rows.Count > Val(Defolt_Select_ID) Then
            Grid1.CurrentCell = Grid1.Rows(Val(Defolt_Select_ID)).Cells(1)
        End If
    End Function
    Private Sub Search_Vouchers_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If bg_Panel.Visible = True Then
                Panel_Manag(Panel4)
                Search_TXT.Focus()
            ElseIf Panel4.Visible = True Then
                Me.Dispose()
            End If
        End If

        If e.KeyCode = Keys.D2 AndAlso e.Modifiers = Keys.Alt Then
            BG_frm.B_2.PerformClick()
        End If
        If e.KeyCode = Keys.F4 AndAlso e.Modifiers = Keys.Alt Then

        ElseIf e.KeyCode = Keys.F4 Then
            BG_frm.R_5.PerformClick()
        End If

        If e.KeyCode = Keys.F6 AndAlso e.Modifiers = Keys.Alt Then

        ElseIf e.KeyCode = Keys.F6 Then
            BG_frm.R_7.PerformClick()
        End If
    End Sub

    Private Sub Search_Vouchers_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        Add_Hander_Remove_Handel(False)
        BG_frm.BG_Path_TXT.Text = Path_End
        Frm_foCus()
    End Sub

    Private Function cfg_fill()
        Branch_Panel.Visible = Branch_Visible()
        Godown_Panel.Visible = Godown_YN

        Label5.Text = Dft_Branch
        Label4.Text = dft_Godown_Name
    End Function

    Private Function Button_Manage()
        Button_Clear()
        BG_frm.B_1.Text = "Enter : Alter"
        BG_frm.B_2.Text = "&2 : Duplicate"
        BG_frm.B_3.Text = "&Add vch."
        If Branch_Visible() = True Then
            BG_frm.R_5.Text = "F4 : Branch"
        End If
        If Godown_YN = True Then
            BG_frm.R_7.Text = "F6 : Godown"
        End If

    End Function
    Private Function Add_Hander_Remove_Handel(Ans As Boolean)
        If Ans = True Then
            AddHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            AddHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
            AddHandler BG_frm.B_3.Click, AddressOf Me.B_3_Click
            If Branch_Visible() = True Then
                AddHandler BG_frm.R_5.Click, AddressOf Me.R_5_Click
            End If
            If Godown_YN = True Then
                AddHandler BG_frm.R_7.Click, AddressOf Me.R_11_Click
            End If
        Else
            RemoveHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            RemoveHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
            RemoveHandler BG_frm.B_3.Click, AddressOf Me.B_3_Click
            RemoveHandler BG_frm.R_5.Click, AddressOf Me.R_5_Click
            RemoveHandler BG_frm.R_7.Click, AddressOf Me.R_11_Click

        End If
    End Function
    Private Sub B_3_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Cell("Voucher BG", Grid1.CurrentRow.Cells(0).Value.ToString, "Create_Close", Grid1.CurrentRow.Cells(3).Value.ToString, Grid1.CurrentRow.Cells(6).Value.ToString)
        End If
    End Sub
    Private Sub B_2_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            If Grid1.Rows.Count > 0 Then
                Cell("Voucher BG", Grid1.CurrentRow.Cells(0).Value.ToString, "Duplicate", Grid1.CurrentRow.Cells(3).Value.ToString)
            End If
        End If
    End Sub
    Private Sub B_1_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            If Grid1.Rows.Count > 0 Then
                Cell("Voucher BG", Grid1.CurrentRow.Cells(0).Value.ToString, "Alter_Close", Grid1.CurrentRow.Cells(7).Value.ToString)
            End If
        End If
    End Sub
    Private Sub R_5_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Cell("Filter", "Branch", BG_frm.HADE_TXT.Text)
        End If
    End Sub
    Private Sub R_11_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            Cell("Filter", "Godown", BG_frm.HADE_TXT.Text)
        End If
    End Sub



    Private Sub Search_Vouchers_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID

        If bg_Panel.Visible = True Then
            Grid1.Focus()
        ElseIf Panel4.Visible = True Then
            Search_TXT.Focus()
        End If

    End Sub

    Private Sub Txt1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Txt1_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Fill_Grid()
        End If
    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint
        obj_top(sender)
    End Sub

    Private Sub Txt2_KeyDown(sender As Object, e As KeyEventArgs) Handles Search_TXT.KeyDown
        If e.KeyCode = Keys.Enter Then
            Fill_Grid()
            Panel_Manag(bg_Panel)
        End If
    End Sub
    Private Function Panel_Manag(p As Panel)
        bg_Panel.Visible = False
        Panel4.Visible = False

        p.Visible = True
    End Function

    Private Sub Search_TXT_TextChanged(sender As Object, e As EventArgs) Handles Search_TXT.TextChanged

    End Sub
    Private Sub Grid1_Paint(sender As Object, e As PaintEventArgs) Handles Grid1.Paint
        DrawLinePoint(e)
    End Sub
    Public Sub DrawLinePoint(ByVal e As PaintEventArgs)
        If Grid1.Rows.Count <> 0 Then
            Dim blackPen As New Pen(Color.Gray, 1)
            Dim font_ As Font = New Font("Arial", 10, FontStyle.Bold)
            Dim Brsh As New SolidBrush(Color.Black)

            Dim ctlpos As Point = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(1, 0, False).Location)
            Dim point1 As New Point(ctlpos.X, 0)
            Dim point2 As New Point(ctlpos.X, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)

            ctlpos = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(2, 0, False).Location)
            point1 = New Point(ctlpos.X, 0)
            point2 = New Point(ctlpos.X, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)

            ctlpos = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(3, 0, False).Location)
            point1 = New Point(ctlpos.X, 0)
            point2 = New Point(ctlpos.X, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)

            ctlpos = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(4, 0, False).Location)
            point1 = New Point(ctlpos.X, 0)
            point2 = New Point(ctlpos.X, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)

            ctlpos = Grid1.PointToScreen(Grid1.GetCellDisplayRectangle(5, 0, False).Location)
            point1 = New Point(ctlpos.X, 0)
            point2 = New Point(ctlpos.X, Grid1.Height)
            e.Graphics.DrawLine(blackPen, point1, point2)


            point1 = New Point(0, Grid1.ColumnHeadersHeight)
            point2 = New Point(Grid1.Width, Grid1.ColumnHeadersHeight)
            e.Graphics.DrawLine(blackPen, point1, point2)

            point1 = New Point(0, 0)
            point2 = New Point(Grid1.Width, 0)
            e.Graphics.DrawLine(blackPen, point1, point2)
        End If
    End Sub

    Private Sub Grid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid1.CellContentClick

    End Sub

    Private Sub Grid1_RowValidating(sender As Object, e As DataGridViewCellCancelEventArgs) Handles Grid1.RowValidating

    End Sub

    Private Sub Grid1_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid1.KeyDown
        If e.KeyCode = Keys.Enter Then
            BG_frm.B_1.PerformClick()
        End If
    End Sub
End Class