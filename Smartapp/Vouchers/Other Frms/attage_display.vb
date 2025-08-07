Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.IO

Public Class attage_display
    Public Grid_ As DataGridView
    Private Sub vc_attage_display_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Button_Manage()
        'Add_Hander_Remove_Handel(True)
        Load()
    End Sub
    Private Function Load()
        For Each ro As DataGridViewRow In Grid_.Rows
            DataGridView1.Rows.Add(ro.Cells(0).Value, ro.Cells(1).Value, ro.Cells(2).Value, ro.Cells(3).Value, ro.Cells(4).Value, ro.Cells(5).Value)
        Next
    End Function
    Private Sub vc_attage_display_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        Panel1.Location = New Point(Me.ClientSize.Width / 2 - Panel1.Size.Width / 2, Me.ClientSize.Height / 2 - Panel1.Size.Height / 2)


        Button_Clear()
        'Button_Manage()
    End Sub

    Private Sub vc_attage_display_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub
    Private Function Save_()
        Grid_.Rows.Clear()
        For Each ro As DataGridViewRow In DataGridView1.Rows
            Grid_.Rows.Add(ro.Cells(0).Value, ro.Cells(1).Value, ro.Cells(2).Value, ro.Cells(3).Value, ro.Cells(4).Value, ro.Cells(5).Value)
        Next
        Me.Dispose()
    End Function
    Private Sub vc_attage_display_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed

        Frm_foCus()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim Byt As Byte()
        Byt = DirectCast(DataGridView1.CurrentRow.Cells(4).Value, Byte())
        Dim EditBTNDATA As String = DataGridView1.Columns(e.ColumnIndex).Name

        If EditBTNDATA = "DataGridViewImageColumn1" Then
            If DataGridView1.CurrentRow.Cells(5).Value <> Nothing Then
                Attage_Password.Password = DataGridView1.CurrentRow.Cells(5).Value
                If Attage_Password.ShowDialog <> DialogResult.Yes Then
                    Exit Sub
                End If
            End If
            Dim Formett As String = DataGridView1.CurrentRow.Cells(3).Value.ToString
            If Formett = ".Jpeg" Or Formett = ".jpg" Or Formett = ".jpg2" Or Formett = ".png" Or Formett = ".gif" Or Formett = ".bmp" Then
                Document_view_frm.Byt = Byt
                Document_view_frm.Name = DataGridView1.CurrentRow.Cells(1).Value.ToString
                Document_view_frm.Formett = Formett
                Document_view_frm.Narra = DataGridView1.CurrentRow.Cells(2).Value.ToString
                Document_view_frm.ShowDialog()
            Else
                Using tmp As New FileStream(Application.StartupPath & "\_other_savefiles\tmp_rec" & Formett, FileMode.Create)
                    tmp.Write(Byt, 0, Byt.Length)
                End Using
                Process.Start(Application.StartupPath & "\_other_savefiles\tmp_rec" & Formett)
            End If

        ElseIf EditBTNDATA = "DataGridViewImageColumn2" Then
            Dim memory As New MemoryStream()
            Dim Formett As String
            If DataGridView1.CurrentRow.Cells(5).Value <> Nothing Then
                Attage_Password.Password = DataGridView1.CurrentRow.Cells(5).Value
                If Attage_Password.ShowDialog <> DialogResult.Yes Then
                    Exit Sub
                End If

            End If
            Formett = DataGridView1.CurrentRow.Cells(3).Value
            Dim ms As New MemoryStream(Byt)
            SaveFileDialog1.FileName = DataGridView1.CurrentRow.Cells(1).Value
            SaveFileDialog1.Title = "Save Document"
            If SaveFileDialog1.ShowDialog = DialogResult.OK Then
                Dim file As New FileStream(SaveFileDialog1.FileName & Formett, FileMode.Create, FileAccess.Write)
                ms.WriteTo(file)
                file.Close()
                ms.Close()
            End If


        ElseIf EditBTNDATA = "DataGridViewImageColumn3" Then

            If DataGridView1.CurrentRow.Cells(0).Value <> "0" Then
                If DataGridView1.CurrentRow.Cells(5).Value <> Nothing Then
                    Attage_Password.Password = DataGridView1.CurrentRow.Cells(5).Value
                    If Attage_Password.ShowDialog <> DialogResult.Yes Then
                        Exit Sub
                    End If
                End If

                If Msg_Yn("Are you source", "Delete Permanently Document") = DialogResult.Yes Then
                    If Data_Delete(Database_File.rec, "TBL_Attage", "Visible = 'Delete' WHERE ID = '" & DataGridView1.CurrentRow.Cells(0).Value & "'") = True Then
                        DataGridView1.Rows.Remove(DataGridView1.CurrentRow)
                    End If
                End If
            Else
                DataGridView1.Rows.Remove(DataGridView1.CurrentRow)
            End If
        End If
    End Sub

    Private Sub Label18_Click(sender As Object, e As EventArgs) Handles Label18.Click

    End Sub

    Private Sub attage_display_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Me.Dispose()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Save_()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        With Attage_cre_frm
            .Grid = Me.DataGridView1
            If .ShowDialog() = DialogResult.OK Then
                Button1.Focus()
            End If
        End With
    End Sub
End Class