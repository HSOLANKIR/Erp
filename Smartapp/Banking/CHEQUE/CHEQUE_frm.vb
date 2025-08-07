Imports System.Data.SqlClient
Imports System.Data.SQLite
Imports Tools

Public Class CHEQUE_frm
    Dim Under_ID As String
    Dim Under As String
    Dim Path_End As String
    Dim VC_Type_ As String
    Dim VC_ID_ As String
    Public close_focus_obj As TXT
    'Cell(Head/VC_Type/VC_No)
    Private Sub CHEQUE_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Path_End = BG_frm.BG_Path_TXT.Text
        VC_Type_ = Link_Valu(1)
        VC_ID_ = Link_Valu(2)

        BG_frm.HADE_TXT.Text = "CHEQUE"
        BG_frm.TYP_TXT.Text = VC_Type_

        If From_Access(BG_frm.HADE_TXT.Text, BG_frm.TYP_TXT.Text) = False Then
            Me.Dispose()
            Cell("Not Access", BG_frm.HADE_TXT.Text & $"({BG_frm.TYP_TXT.Text})")
            Exit Sub
        End If



        Load_data_source()
        List_set()



        If VC_Type_ = "Display" Or VC_Type_ = "Display_Close" Then
            Display_Fill_All()
        ElseIf VC_Type_ = "Alter" Then
            Display_Fill_All()

        ElseIf VC_Type_ = "Create" Or VC_Type_ = "Create_Close" Then
        End If


        Button_Manage()
        NOT_Clear()
        Add_Hander_Remove_Handel(True)
    End Sub
    Dim ag_list As List_frm
    Private Function List_set()

    End Function
    Private Function Load_data_source()
        Dim cn As New SQLiteConnection
        Dim dt As New DataTable
        dt.Columns.Add("Name")
        dt.Columns.Add("Under Group")
        dt.Columns.Add("ID")

        Dim dr As DataRow

        If open_MSSQL_Cstm(Database_File.cre, cn) Then
            cmd = New SQLiteCommand("Select ID,Name,(Select [Name] From TBL_Acc_Group agg where agg.ID = ag.UserGroup) as Under_Group From TBL_Acc_Group ag where Company = 'All'", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                dr = dt.NewRow
                dr("ID") = r("ID")
                dr("Name") = r("Name")
                dr("Under Group") = r("Under_Group")
                dt.Rows.Add(dr)
            End While
            r.Close()
        End If
        cn.Close()

        BindingSource1.DataSource = dt
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

            If Login_Type = "Admin Account" And (VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close") Then
                AddHandler BG_frm.B_4.Click, AddressOf Me.B_5_Click
            End If
        Else
            RemoveHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click

            If Login_Type = "Admin Account" And (VC_Type_ = "Alter" Or VC_Type_ = "Alter_Close") Then
                RemoveHandler BG_frm.B_4.Click, AddressOf Me.B_5_Click
            End If
        End If
    End Function
    Private Sub B_1_Click(sender As Object, e As EventArgs)
        If BG_frm.HADE_TXT.Text = "CHEQUE" Or BG_frm.HADE_TXT.Text = "CHEQUE" Then
            Me.Dispose()
        End If
    End Sub
    Private Sub B_5_Click(sender As Object, e As EventArgs)
        If BG_frm.HADE_TXT.Text = "CHEQUE" Then
            Cell("Audit Analysis", "", "CHEQUE", VC_ID_)
        End If
    End Sub
    Private Sub Group_TXT_TextChanged(sender As Object, e As EventArgs)
        'BindingSource1.Filter = $""
    End Sub
    Private Sub CHEQUE_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If Msg_Exit_YN("Acc. Group " & VC_Type_) = DialogResult.Yes Then
                Me.Dispose()
                If VC_Type_ = "Alter_Close" Or VC_Type_ = "Create_Close" Then
                    close_focus_obj.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub CHEQUE_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.HADE_TXT.Text = "CHEQUE"
        BG_frm.TYP_TXT.Text = VC_Type_
        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text

        Button_Clear()
        Button_Manage()
    End Sub
    Private Function Display_Fill_All() As Boolean

        Return True
    End Function
    Dim is_save As Boolean = False
    Private Sub CHEQUE_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End
        Add_Hander_Remove_Handel(False)
        Frm_foCus()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        PrintDocument1.PrinterSettings.PrinterName = "Canon LBP2900"
        PrintDocument1.Print()
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        e.Graphics.PageUnit = GraphicsUnit.Millimeter
        PrintDocument1.OriginAtMargins = False
        e.Graphics.DrawString("POLLAN FERTILIZER PRIVATE LIMITED", Font, Brushes.Black, New RectangleF(50, 50, Width, Height))

    End Sub
End Class
