Imports System.ComponentModel
Imports System.Data.SqlClient

Public Class User_List_frm
    Dim From_ID As String
    Dim Path_End As String
    Dim VC_Type_ As String
    Dim VC_ID_ As String
    Dim cn As New SqlConnection
    Private Sub User_List_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text
        BG_frm.HADE_TXT.Text = "User Info."
        Load_.RunWorkerAsync()
    End Sub

    Private Sub User_List_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.HADE_TXT.Text = "User Info."
        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text
        Button_Clear()

        Txt1.Focus()
    End Sub

    Private Sub User_List_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If Msg_Exit_YN("User Info.") = DialogResult.Yes Then
                Me.Dispose()
            End If
        End If
    End Sub

    Private Sub User_List_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End
        Frm_foCus()
    End Sub
    Private Function Fill_Data()


    End Function

    Private Sub start_btn_Click(sender As Object, e As EventArgs) Handles start_btn.Click
        Cell("User Information", "", "Create", "")
    End Sub

    Private Sub Panel7_Paint(sender As Object, e As PaintEventArgs) Handles Panel7.Paint
        obj_center(sender, Me)
    End Sub

    Dim dt As DataTable
    Private Sub Load__DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles Load_.DoWork

        dt = New DataTable
        dt.Columns.Add("ID")
        dt.Columns.Add("Name")
        dt.Columns.Add("UserName")
        dt.Columns.Add("Phone")
        dt.Columns.Add("Email")
        dt.Columns.Add("Status")

        If cn.State <> ConnectionState.Open Then
            Online_MSSQL(cn)
        End If

        Dim cmd_o As New SqlCommand($"Select * From TBL_Login where CompanySerial = '{Company_ID_str}'", cn)
        Dim r As SqlDataReader
        r = cmd_o.ExecuteReader
        While r.Read
            Dim f As String = r("FristName")
            Dim m As String = r("MiddleName")
            Dim l As String = r("LastName")
            Dim stu As String = r("Approval")
            If stu = "Approval" Then
                stu = "Active"
            ElseIf stu = "Pending" Then
                stu = "Deactivate"
            End If

            dt.Rows.Add(r("ID"), $"{f} {m} {l}", r("UserName"), r("Phone"), r("Email"), stu)
        End While
        r.Close()
    End Sub

    Private Sub Load__RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles Load_.RunWorkerCompleted
        bg_panel.Dock = DockStyle.Fill
        bg_panel.Visible = True
        BindingSource1.DataSource = dt

        Grid1.DataSource = BindingSource1
        Txt1.Focus()



        Grid1.Columns(0).Visible = False
        Grid1.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Grid1.Columns(2).Width = 200
        Grid1.Columns(3).Width = 100
        Grid1.Columns(4).Width = 250
        Grid1.Columns(5).Width = 100
    End Sub

    Private Sub Txt1_TextChanged(sender As Object, e As EventArgs) Handles Txt1.TextChanged
        BindingSource1.Filter = $"Name LIKE '%{Txt1.Text}%' or UserName LIKE '%{Txt1.Text}%' or Phone LIKE '%{Txt1.Text}%' or Email LIKE '%{Txt1.Text}%'"
    End Sub

    Private Sub Txt1_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt1.KeyDown
        If e.KeyCode = Keys.Up Then
            BindingSource1.MovePrevious()
        End If
        If e.KeyCode = Keys.Down Then
            BindingSource1.MoveNext()
        End If
        If e.KeyCode = Keys.PageUp Then
            BindingSource1.MoveFirst()
        End If
        If e.KeyCode = Keys.PageDown Then
            BindingSource1.MoveLast()
        End If
        If e.KeyCode = Keys.Enter Then
            Cell("User Information", "", "Alter", Grid1.CurrentRow.Cells(0).Value)
        End If
    End Sub

    Private Sub Grid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid1.CellContentClick

    End Sub

    Private Sub Grid1_CellContextMenuStripNeeded(sender As Object, e As DataGridViewCellContextMenuStripNeededEventArgs) Handles Grid1.CellContextMenuStripNeeded
        NameToolStripMenuItem.Text = Grid1.CurrentRow.Cells(2).Value
    End Sub
    Dim ststus As String
    Dim ro As Integer
    Dim isSuccess As Boolean = False
    Dim error_ As String
    Private Sub Save_Background_DoWork(sender As Object, e As DoWorkEventArgs) Handles Save_Background.DoWork
        Try
            Dim cmd_o As New SqlCommand($"UPDATE TBL_Login SET Approval = '{ststus}' where id = '{Grid1.Rows(ro).Cells(0).Value}'", cn)
            cmd_o.ExecuteNonQuery()
            isSuccess = True
        Catch ex As Exception
            isSuccess = False
            error_ = ex.Message
        End Try
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        ststus = "Approval"
        ro = Grid1.CurrentRow.Index
        Label2.Text = $"Please wait{vbNewLine}Update User Data"
        bg_panel.Visible = False
        Save_Background.RunWorkerAsync()
    End Sub
    Private Sub Save_Background_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles Save_Background.RunWorkerCompleted
        bg_panel.Visible = True

        If isSuccess = True Then
            NOT_($"User is {ststus} Successfully", NOT_Type.Success)
            If ststus = "Approval" Then
                dt.Rows(ro).ItemArray(5) = "Active"
            ElseIf ststus = "Pending" Then
                dt.Rows(ro).ItemArray(5) = "Deactivate"
            End If
        Else
            If Msg_Custom_YN(NOT_Location.Bottom_Right, Color.Red, My.Resources.Error_animation_icn, Dialoag_Button.Retry_Cancel, "Error!", "User Data Update Error", error_) = DialogResult.Retry Then
                bg_panel.Visible = False
                Save_Background.RunWorkerAsync()
            Else

            End If
        End If
    End Sub

    Private Sub DeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeToolStripMenuItem.Click
        Label2.Text = $"Please wait{vbNewLine}Update User Data"
        ststus = "Pending"
        ro = Grid1.CurrentRow.Index
        Label2.Text = $"Please wait{vbNewLine}Update User Data"
        bg_panel.Visible = False
        Save_Background.RunWorkerAsync()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        bg_panel.Visible = False
        Load_.RunWorkerAsync()
    End Sub

    Private Sub Grid1_Enter(sender As Object, e As EventArgs) Handles Grid1.Enter
        Txt1.Focus()
    End Sub

    Private Sub User_List_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
    End Sub
End Class