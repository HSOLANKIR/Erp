Imports System.ComponentModel
Imports System.Runtime.InteropServices
Imports Microsoft.Win32

Public Class Whatsapp_No_Chack_Dialoag
    Private Sub Whatsapp_No_Chack_Dialoag_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Close_Fales(Me)
        Load_Combobx()
    End Sub
    Private Function Load_Combobx()
        ComboBox3.Items.Clear()

        For i As Integer = 0 To Whatsapp_Home.ComboBox3.Items.Count - 1
            ComboBox3.Items.Add(Whatsapp_Home.ComboBox3.Items(i))
        Next
    End Function

    Private Sub Server_Panel_Paint(sender As Object, e As PaintEventArgs)
        obj_center(sender, Me)
    End Sub

    Private Function Count_()
        Label2.Text = (Val(Label21.Text) + Val(Label6.Text) + Val(Label10.Text) + Val(Label13.Text) + Val(Label23.Text))
        Label12.Text = Val(Label18.Text) - (Val(Label2.Text) + Val(Label22.Text))
    End Function

    Private Sub Label18_Click(sender As Object, e As EventArgs) Handles Label18.Click

    End Sub

    Private Sub Label18_TextChanged(sender As Object, e As EventArgs) Handles Label18.TextChanged, Label21.TextChanged, Label6.TextChanged, Label10.TextChanged, Label22.TextChanged, Label13.TextChanged
        Count_()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Start_btn.Visible = True
        Stop_btn.Visible = True

        Whatsapp_Home.Push_Msg()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Stop_btn.Click
        Stop_btn.Visible = False
        Start_btn.Visible = True
        delete_btn.Visible = False
        Export_Panel.Visible = False

        Whatsapp_Home.Stop_Msg()

        'Me.Dispose()
    End Sub

    Private Sub start_btn_Click(sender As Object, e As EventArgs) Handles Start_btn.Click

        If Filter_chack.Checked = True Then
            If ComboBox3.SelectedIndex = -1 Then
                ComboBox3.Focus()
                Exit Sub
            End If
            If Find_TXT.Text.Trim = Nothing Then
                Find_TXT.Focus()
                Exit Sub
            End If
        End If


        With Whatsapp_Home
            .Button1.PerformClick()
            .Chack_duplicat_ = CheckBox1.Checked
            .Chack_blank_ = CheckBox2.Checked
            .Chack_invalid_ = CheckBox3.Checked
            .Chack_whatsapp_ = CheckBox4.Checked
            .Chack_Filter_ = Filter_chack.Checked
            .String_Filter_ = Find_TXT.Text
            .Valid_Filter_ = RadioButton1.Checked
            .Reject_Filter_ = RadioButton2.Checked
            .Filter_Column_ = ComboBox3.SelectedIndex

            .Chack_Background.RunWorkerAsync()
        End With
        Start_btn.Visible = False
        Stop_btn.Visible = True
        delete_btn.Visible = False
        Export_Panel.Visible = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Whatsapp_Home.Restart_Msg()
        start_btn_Click(e, e)
    End Sub

    Private Sub Whatsapp_No_Chack_Dialoag_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        Whatsapp_Home.Stop_Msg()
    End Sub

    Private Sub Whatsapp_No_Chack_Dialoag_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Me.Dispose()
    End Sub

    Private Sub delete_btn_Click(sender As Object, e As EventArgs) Handles delete_btn.Click
        Start_btn.Visible = False
        delete_btn.Visible = False
        Stop_btn.Visible = True

        Whatsapp_Home.Delete_invelid_back.RunWorkerAsync()
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged, CheckBox2.CheckedChanged, CheckBox3.CheckedChanged
        delete_btn.Visible = False
    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub

    Private Sub CheckBox6_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox5.CheckedChanged, CheckBox6.CheckedChanged
        If CheckBox6.Checked = False And CheckBox5.Checked = False Then
            Button5.Enabled = False
        Else
            Button5.Enabled = True
        End If
    End Sub
    Private Export_Path As String = ""

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Whatsapp_Home.Export_excel_to_Filter(CheckBox5.Checked, CheckBox6.Checked)
    End Sub

    Private Sub Export_background_DoWork(sender As Object, e As DoWorkEventArgs) Handles Export_background.DoWork
        Dim xlApp As Microsoft.Office.Interop.Excel.Application
        Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
        Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value
        Dim i As Integer
        Dim j As Integer

        xlApp = New Microsoft.Office.Interop.Excel.Application
        xlWorkBook = xlApp.Workbooks.Add(misValue)
        xlWorkSheet = xlWorkBook.Sheets("sheet1")

        With Whatsapp_Home
            Dim I2 As Integer = 0
            For i = 0 To .Grid1.RowCount - 2
                Dim ro As DataGridViewRow = .Grid1.Rows(i)
                If (CheckBox6.Checked = True And ro.DefaultCellStyle.BackColor = Color.LightCoral) Or (CheckBox5.Checked = True And ro.DefaultCellStyle.BackColor <> Color.LightCoral) Then
                    For j = 0 To .Grid1.ColumnCount - 1
                        For k As Integer = 1 To .Grid1.Columns.Count
                            xlWorkSheet.Cells(1, k) = .Grid1.Columns(k - 1).HeaderText
                            xlWorkSheet.Cells(i + 2, j + 1) = .Grid1(j, i).Value.ToString()
                        Next
                    Next
                    Export_background.ReportProgress(i)
                    I2 += 1
                End If
            Next
        End With


        xlWorkSheet.SaveAs(Export_Path)
        xlWorkBook.Close()
        xlApp.Quit()

        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(xlWorkSheet)
    End Sub
    Private Sub releaseObject(ByVal obj As Object)
        Try
            Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub Export_background_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles Export_background.ProgressChanged
        With ProgressBag_Custom1

            .Value = e.ProgressPercentage
            .Run(0)

            Label3.Text = $"{N2_FORMATE((Val(e.ProgressPercentage) * 100) / Val(.Maximum))} %"
        End With
    End Sub

    Private Sub Export_background_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles Export_background.RunWorkerCompleted
        Panel3.Visible = False
    End Sub

    Private Sub CheckBox10_CheckedChanged(sender As Object, e As EventArgs) Handles Filter_chack.CheckedChanged
        Panel9.Visible = Filter_chack.Checked

    End Sub

    Private Sub Panel20_Paint(sender As Object, e As PaintEventArgs) Handles Panel20.Paint
        obj_center(sender, Me)
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class