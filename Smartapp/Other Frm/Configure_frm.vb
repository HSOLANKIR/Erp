Imports System.Data.SqlClient
Imports System.Data.SQLite

Public Class Configure_frm
    Private VC_Type_ As String
    Public VC_ID_ As String
    Public TBL_ As String
    Private Path_End As String
    Private Sub Configure_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel2.Location = New Point(Me.ClientSize.Width / 2 - Panel2.Size.Width / 2, Me.ClientSize.Height / 2 - Panel2.Size.Height / 2)

        Path_End = BG_frm.BG_Path_TXT.Text

        VC_Type_ = Link_Valu(0)
        Try
            VC_ID_ = Link_Valu(1)
        Catch ex As Exception

        End Try
        TBL_ = Link_Valu(2)

        BG_frm.HADE_TXT.Text = "Configuration"
        Button_Manage()
        Add_Hander_Remove_Handel(True)
        Load_()
    End Sub

    Private Sub Configure_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.HADE_TXT.Text = "Configuration"
        BG_frm.TYP_TXT.Text = VC_Type_

        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text
        Button_Clear()
        Button_Manage()
        Grid1.Focus()
    End Sub

    Private Sub Configure_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If TableLayoutPanel1.Visible = True Then
                If Msg_Yn("Save Change", "") = DialogResult.Yes Then
                    Save_As()
                Else
                    Me.Dispose()
                End If
            Else
                TableLayoutPanel1.Visible = True
                TableLayoutPanel1.BringToFront()
                Grid1.Focus()
            End If
        End If
    End Sub

    Private Sub Configure_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        Add_Hander_Remove_Handel(False)
        BG_frm.BG_Path_TXT.Text = Path_End
        Frm_foCus()
    End Sub

    Private Function Button_Manage()
        Button_Clear()
        BG_frm.B_1.Text = "|&S : Save"

    End Function
    Private Function Add_Hander_Remove_Handel(Ans As Boolean)
        If Ans = True Then
            AddHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
        Else
            RemoveHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
        End If
    End Function
    Private Sub B_1_Click(sender As Object, e As EventArgs)
        If BG_frm.HADE_TXT.Text = "Configuration" Then
            MsgBox("")
            Save_As()
        End If
    End Sub
    Private Function Save_As()
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.lnk, cn) = True Then
            For Each ro As DataGridViewRow In Grid1.Rows
                cmd = New SQLiteCommand("UPDATE " & TBL_ & " SET [Value] = '" & ro.Cells(4).Value.ToString & "' WHERE ID Like N'" & ro.Cells(0).Value.ToString & "'", cn)
                cmd.ExecuteNonQuery()
            Next
        End If
        Me.Dispose()
    End Function
    Private Function Where_Filter() As String
        Dim q As String
        If My.Settings.Login_Type = "Admin Account" Then
            q = "AND ([User] = 'Admin' or [User] = 'All')"
        Else
            q = "AND ([User] = 'All')"
        End If
        Return q
    End Function
    Dim dt As New DataTable
    Private Function Load_()
        dt.Clear()
        dt.Columns.Clear()
        dt.Reset()

        Grid1.Columns.Clear()
        dt = New DataTable
        dt.Columns.Add("ID")
        dt.Columns.Add("Head")
        dt.Columns.Add("Type")
        dt.Columns.Add("Name")
        dt.Columns.Add("Value")
        dt.Columns.Add("Filter")
        dt.Columns.Add("Data")
        dt.Columns.Add("User")



        Dim dr As DataRow
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.lnk, cn) = True Then
            Dim Arr As String() = String_Part_(VC_Type_, "\")
            Dim Filter As String = ""

            For i As Integer = 0 To Arr.Length - 1
                If i = 0 Then
                    Filter &= "(Filter = '" & Arr(i) & "')"
                Else
                    Filter &= "OR (Filter = '" & Arr(i) & "')"
                End If
            Next


            cmd = New SQLiteCommand("Select * From " & TBL_ & " Where " & Filter & Where_Filter(), cn)
            Dim r As SQLiteDataReader

            r = cmd.ExecuteReader
            While r.Read
                dr = dt.NewRow
                dr("ID") = r("ID")
                dr("Head") = r("Head")
                dr("Type") = r("Type")
                dr("Name") = r("Name")
                dr("Value") = r("Value")
                dr("Data") = r("Data")
                dr("Filter") = r("Filter")
                dr("User") = r("User")
                dt.Rows.Add(dr)
            End While
            Grid1.DataSource = dt

            Grid1.Columns(0).Visible = False
            Grid1.Columns(1).Visible = False
            Grid1.Columns(2).Visible = False
            Grid1.Columns(5).Visible = False
            Grid1.Columns(6).Visible = False
            Grid1.Columns(7).Visible = False


            Grid1.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            Grid1.Columns(4).Width = 100
            Grid1.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            Grid1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            Panel1.Height = (Val(Grid1.Rows.Count) * 19) + Val(Label1.Height)

            Try
                Grid1.CurrentCell = Grid1.Rows(1).Cells(3)
            Catch ex As Exception

            End Try
        End If
    End Function
    Private Sub Grid1_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles Grid1.RowsAdded
        Grid1.Rows(Grid1.Rows.Count - 1).Height = 18
    End Sub
    Private Sub Grid2_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles Grid_Select.RowsAdded
        Grid_Select.Rows(Grid_Select.Rows.Count - 1).Height = 18
        Panel3.Height = ((Grid_Select.Rows.Count) * 19) + Val(Label3.Height)
    End Sub

    Private Sub Grid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid1.CellContentClick

    End Sub

    Private Sub Grid1_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid1.KeyDown
        e.SuppressKeyPress = True
        e.Handled = True
        If e.KeyCode = Keys.Down Then
            If Grid1.CurrentRow.Index + 1 <> Grid1.Rows.Count Then
                If Grid1.Rows(Grid1.CurrentRow.Index + 1).Cells(1).Value = "HEAD" Then
                    Grid1.CurrentCell = Grid1.Rows(Val(Grid1.CurrentRow.Index) + 2).Cells(3)
                Else
                    Grid1.CurrentCell = Grid1.Rows(Val(Grid1.CurrentRow.Index) + 1).Cells(3)
                End If
            End If
        End If

        Try
            If e.KeyCode = Keys.Up Then
                If Grid1.CurrentRow.Index <> 1 Then
                    If Grid1.Rows(Grid1.CurrentRow.Index - 1).Cells(1).Value = "HEAD" Then
                        Grid1.CurrentCell = Grid1.Rows(Val(Grid1.CurrentRow.Index) - 2).Cells(3)
                    Else
                        Grid1.CurrentCell = Grid1.Rows(Val(Grid1.CurrentRow.Index) - 1).Cells(3)
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
        If e.KeyCode = Keys.Enter Then
            If Grid1.CurrentRow.Cells(2).Value = "YN" Then
                If Grid1.CurrentRow.Cells(4).Value = "Yes" Then
                    Grid1.CurrentRow.Cells(4).Value = "No"
                ElseIf Grid1.CurrentRow.Cells(4).Value = "No" Then
                    Grid1.CurrentRow.Cells(4).Value = "Yes"
                End If
            ElseIf Grid1.CurrentRow.Cells(2).Value = "SELECT" Then
                SELECT_Set(Grid1.CurrentRow.Cells(3).Value.ToString, Grid1.CurrentRow.Cells(4).Value, String_Part_(Grid1.CurrentRow.Cells(6).Value.ToString, "\"))
            ElseIf Grid1.CurrentRow.Cells(2).Value = "TXT" Then
                SELECT_Set(Grid1.CurrentRow.Cells(3).Value.ToString, Grid1.CurrentRow.Cells(4).Value)
            End If
        End If
        If e.KeyCode = Keys.Y Then
            If Grid1.CurrentRow.Cells(2).Value = "YN" Then
                Grid1.CurrentRow.Cells(4).Value = "Yes"
            End If
        End If
        If e.KeyCode = Keys.N Then
            If Grid1.CurrentRow.Cells(2).Value = "YN" Then
                Grid1.CurrentRow.Cells(4).Value = "No"
            End If
        End If
    End Sub
    Private Function SELECT_Set(Head_ As String, TX As String, ParamArray Vlu() As String)
        Dim dt As New DataTable
        dt.Columns.Add("Par")
        For i As Integer = 0 To Vlu.Length - 1
            dt.Rows.Add(Vlu(i))
        Next
        Select_BS.DataSource = dt
        Grid_Select.DataSource = Select_BS
        Grid_Select.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        TableLayoutPanel1.Hide()
        Label2.Text = Head_

        Txt1.Text = TX
        Txt1.Focus()
    End Function
    Private Sub Txt1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Grid1_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles Grid1.RowPrePaint
        Dim i As DataGridViewRow = Grid1.Rows(e.RowIndex)
        If i.Cells(1).Value.ToString = "HEAD" Then
            i.DefaultCellStyle.ForeColor = Color.SaddleBrown
            i.DefaultCellStyle.SelectionForeColor = Color.SaddleBrown
            i.DefaultCellStyle.SelectionBackColor = Color.White
            i.Cells(3).Style.Font = New Font(Dft_Font, Dft_Font_Size_Bold, FontStyle.Bold Or FontStyle.Italic)
        Else
            i.Cells(3).Style.Padding = New Padding(15, 0, 0, 0)
        End If
    End Sub

    Private Sub Grid_Select_Paint(sender As Object, e As PaintEventArgs) Handles Grid_Select.Paint
        Panel3.Location = New Point(Val(Panel2.Location.X) + Val(Panel2.Width), Val(Panel2.Location.Y) + Val(Label2.Height))
    End Sub

    Private Sub Txt1_TextChanged_1(sender As Object, e As EventArgs) Handles Txt1.TextChanged

    End Sub

    Private Sub Txt1_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt1.KeyDown
        If e.KeyCode = Keys.Up Then
            Select_BS.MovePrevious()
        End If
        If e.KeyCode = Keys.Down Then
            Select_BS.MoveNext()
        End If
        If e.KeyCode = Keys.Enter Then
            TableLayoutPanel1.Show()
            TableLayoutPanel1.BringToFront()
            Grid1.CurrentRow.Cells(4).Value = Grid_Select.CurrentRow.Cells(0).Value.ToString
            Grid1.Focus()
        End If
    End Sub

    Private Sub Grid_Select_Enter(sender As Object, e As EventArgs) Handles Grid_Select.Enter
        Txt1.Focus()
    End Sub
End Class