Imports System.Data.SqlClient

Public Class Find_Serial_frm
    Dim From_ID As String
    Dim Path_End As String
    Private Sub Find_Serial_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text
        User_Panel.Location = New Point(Me.ClientSize.Width / 2 - User_Panel.Size.Width / 2, Me.ClientSize.Height / 2 - User_Panel.Size.Height / 2)
        BG_frm.HADE_TXT.Text = "Forgot Company Serial"

    End Sub

    Private Sub Find_Serial_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.HADE_TXT.Text = "Forgot Company Serial"
        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text
        Button_Clear()
        User_TXT.Focus()
    End Sub

    Private Sub Find_Serial_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End
        NOT_Clear()
        Frm_foCus()
    End Sub

    Private Sub Find_Serial_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If User_Panel.Visible = True Then
                Me.Dispose()
            ElseIf Panel1.Visible = True Then
                User_Panel.Show()
                Panel1.Hide()
                User_TXT.Focus()
            End If
        End If
    End Sub

    Private Sub User_TXT_TextChanged(sender As Object, e As EventArgs) Handles User_TXT.TextChanged

    End Sub

    Private Sub User_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles User_TXT.KeyDown
        If e.KeyCode = Keys.Enter Then
            If User_TXT.Text.Trim = "" Then
                User_TXT.Focus()
            Else
                If Email_Verification("Forgot Company Serial", "", User_TXT.Text.Trim, "Forgot Company Serial", "", 500) = DialogResult.Yes Then
                    Fill_()
                    User_Panel.Hide()
                    Panel1.Dock = DockStyle.Fill
                    Panel1.Show()
                    Search_TXT.Focus()
                Else
                    User_TXT.Focus()
                End If
            End If
        End If
    End Sub
    Private Function Fill_()
        Dim count_ As Integer = 0
        Dim dt As New DataTable


        dt.Columns.Clear()
        dt.Rows.Clear()

        dt.Columns.Add("Company Name")
        dt.Columns.Add("Company Serial")
        dt.Columns.Add("Status")

        Dim cn As New SqlConnection
        If Online_MSSQL(cn) = True Then
            cmd_ = New SqlCommand("Select CompanyName,CompanySerial,Approval From TBL_Company_Creation WHERE Email = '" & User_TXT.Text & "'", cn)
            Dim r As SqlDataReader
            r = cmd_.ExecuteReader
            While r.Read
                Dim Name As String = r("CompanyName")
                Dim Serial As String = r("CompanySerial")
                Dim Status As String = r("Approval")

                If Status = "Approval" Then
                    Status = "Active"
                Else
                    Status = "Deactive"
                End If

                dt.Rows.Add(Name, Serial, Status)
                count_ += 1
            End While


            BindingSource1.DataSource = dt
            DataGridView2.DataSource = BindingSource1



            DataGridView2.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            DataGridView2.Columns(1).Width = 200
            DataGridView2.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            DataGridView2.Columns(2).Width = 80
            DataGridView2.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End If
        Label3.Text = count_
    End Function

    Private Sub User_Panel_Paint(sender As Object, e As PaintEventArgs) Handles User_Panel.Paint
        obj_center(sender, Me)
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        obj_center(sender, Me)
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

    Private Sub DataGridView2_Enter(sender As Object, e As EventArgs) Handles DataGridView2.Enter
        Search_TXT.Focus()
    End Sub

    Private Sub Find_Serial_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
        Search_TXT.Focus()
    End Sub

    Private Sub Search_TXT_TextChanged(sender As Object, e As EventArgs) Handles Search_TXT.TextChanged
        BindingSource1.Filter = $"([Company Name] LIKE '%{Search_TXT.Text.Trim}%') or ([Company Serial] = '%{Search_TXT.Text.Trim}%')"
    End Sub

    Private Sub Search_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles Search_TXT.KeyDown
        If e.KeyCode = Keys.Up Then
            BindingSource1.MovePrevious()
        End If
        If e.KeyCode = Keys.Down Then
            BindingSource1.MoveNext()
        End If
    End Sub

    Private Sub DataGridView2_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellDoubleClick
        ContextMenuStrip1.Show()
        ContextMenuStrip1.Location = Cursor.Position
    End Sub

    Private Sub CopySerialNumberToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopySerialNumberToolStripMenuItem.Click
        Try
            My.Computer.Clipboard.SetText(DataGridView2.CurrentRow.Cells(1).Value.ToString.Trim)
        Catch ex As Exception

        End Try
    End Sub
End Class