Imports System.ComponentModel
Imports System.Data.SQLite
Imports System.IO
Imports ExcelDataReader
Public Class Excel_Import_dialoag
    Dim tbl As DataTableCollection
    Private Sub start_btn_Click(sender As Object, e As EventArgs) Handles start_btn.Click
        Try
            Dim dt As DataSet
            OpenFileDialog1.Filter = "All Files(*.*)|*.*|Excel Files (*.xlsx)|*.xlsx|Xls Files (*.xls)|*.xls"
            If OpenFileDialog1.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
                Using strim = File.Open(OpenFileDialog1.FileName, FileMode.Open, FileAccess.Read)
                    Using reder As IExcelDataReader = ExcelReaderFactory.CreateReader(strim)
                        dt = reder.AsDataSet(New ExcelDataSetConfiguration() With {
                                                          .ConfigureDataTable = Function(__) New ExcelDataTableConfiguration() With {.UseHeaderRow = True}})
                        tbl = dt.Tables
                        ComboBox1.Items.Clear()
                        For Each tabl As DataTable In tbl
                            ComboBox1.Items.Add(tabl.TableName)
                        Next
                        Try
                            ComboBox1.SelectedIndex = 0
                        Catch ex As Exception

                        End Try
                    End Using
                End Using
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Dim list_ As String()
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim dt As DataTable = tbl(ComboBox1.SelectedItem.ToString())
        Grid1.DataSource = dt

        Dim dt1 = New DataTable
        dt1.Columns.Add("Name")
        dt1.Rows.Add("Not Applicable")

        Dim arry(0 To dt.Columns.Count - 1) As String

        For i As Integer = 0 To dt.Columns.Count - 1
            arry(i) = dt.Columns(i).ToString
        Next
        list_ = arry

        For Each bg_p As Panel In FlowLayoutPanel1.Controls.OfType(Of Panel)()
            Dim i As Integer = Find_Idx(bg_p)
            Find_Combobox_TXT(i).Items.Clear()
            Find_Combobox_TXT(i).Items.AddRange(list_)
        Next

        BindingSource1.DataSource = dt1

        Label6.Text = Grid1.Rows.Count - 1
        Label7.Text = Grid1.Columns.Count
    End Sub

    Private Sub Excel_Import_dialoag_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Dim idx As Integer = 1
    Dim frm_ As Object
    Public Function Load_(frm As Object, ParamArray parameter() As String) As DialogResult
        For Each s As String In parameter
            Create_parameters(s)
        Next
        frm_ = frm
        Return Me.ShowDialog
    End Function

    Public Function Create_parameters(name As String)
        Dim bg_p As New Panel

        Dim com As New ComboBox
        Dim lab1 As New Label
        Dim border As New Panel


        bg_p.Controls.Add(com)
        bg_p.Controls.Add(lab1)
        bg_p.Controls.Add(border)
        bg_p.Location = New Point(272, 207)
        bg_p.Name = "bg_" & idx
        bg_p.Size = New Size(231, 24)
        bg_p.TabIndex = 0


        lab1.Dock = DockStyle.Left
        lab1.Location = New Point(1, 0)
        lab1.Name = "namelab_" & idx
        lab1.Size = New Size(117, 24)
        lab1.TabIndex = 1
        lab1.Text = name
        lab1.TextAlign = ContentAlignment.MiddleLeft


        com.Dock = System.Windows.Forms.DockStyle.Fill
        com.FormattingEnabled = True
        com.Location = New System.Drawing.Point(118, 0)
        com.Name = "com_" & idx
        com.Size = New System.Drawing.Size(113, 24)
        com.TabIndex = 1
        'com.Items.AddRange(list_)


        border.BackColor = Color.DarkGray
        border.Dock = DockStyle.Left
        border.Location = New Point(0, 0)
        border.Name = "bord_" & idx
        border.Size = New Size(1, 24)
        border.TabIndex = 2


        FlowLayoutPanel1.Controls.Add(bg_p)
        bg_p.SendToBack()

        idx = FlowLayoutPanel1.Controls.Count + 1
    End Function

    Private Sub Panel10_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Create_parameters(idx)
    End Sub
    Public Function Find_Idx(sender As Object) As Integer
        Return sender.Name.Split("_")(1)
    End Function
    Public Function Find_Combobox_TXT(Index As Integer) As ComboBox
        Try
            Dim Pan1_ As Panel = CType(FlowLayoutPanel1.Controls.Find(("bg_" & Index), True).First, Panel)
            Return CType(Pan1_.Controls.Find(("com_" & Index), True).First, ComboBox)
        Catch ex As Exception

        End Try
    End Function
    Private Sub Excel_Import_dialoag_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = DialogResult.Cancel
            Me.Dispose()
        End If
    End Sub

    Private Sub Excel_Import_dialoag_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Me.Dispose()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.DialogResult = DialogResult.OK
        frm_.Fill_excel()
        Me.Dispose()
    End Sub
End Class