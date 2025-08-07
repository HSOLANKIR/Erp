Imports System.IO

Public Class Attage_cre_frm
    Public Grid As DataGridView
    Private Sub Attage_cre_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Attage_cre_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        Txt1.Focus()
    End Sub

    Private Sub Attage_cre_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        List_frm.Dispose()
        Frm_foCus()
    End Sub
    Private Sub Attage_cre_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = DialogResult.Cancel
            Me.Dispose()
        End If
    End Sub

    Public Function Attage_Add()
        Dim fr As New Attage_cre_frm
        With fr
            .TopLevel = False
            BG_frm.BG_PAN.Controls.Add(fr)
            .Dock = DockStyle.Fill
            .Grid = Grid
            .Show()
            .BringToFront()
            .Focus()
        End With
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenFileDialog1.Filter = "(Document Files)|*.jpg;*.png;*.bmp;*.gif;*.pdf|Jpg, | *.jpg|Png, | *.png|Bmp, | *.bmp|Gif, | *.gif|Pdf | *.pdf"
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Title = "Document Upload"
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            Label62.Text = OpenFileDialog1.FileName
            Label63.Text = Path.GetExtension(OpenFileDialog1.FileName).ToLower
            Label64.Text = Format(Val(Val(FileLen(OpenFileDialog1.FileName)) / 1024 / 1024), "0.00") & " Mb"
            Label71.Text = OpenFileDialog1.SafeFileName
            Button2.Focus()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Chack_Allow() = True Then
            Grid.Rows.Add("0", Txt1.Text, Txt2.Text, Label63.Text, Byte_(Label62.Text), Txt3.Text)
            Txt1.Text = ""
            Txt2.Text = ""
            Label62.Text = ""
            Label63.Text = ""
            Label64.Text = ""
            Label71.Text = ""
            NOT_("Documents Attach Successfully", NOT_Type.Success)

            Me.DialogResult = DialogResult.OK
            Me.Dispose()
        End If
    End Sub
    Private Function Chack_Allow() As Boolean
        If Label62.Text <> "" Then
            If Txt1.Text = "" Then
                Msg(NOT_Type.Warning, "Input Error - Document Name", Text_Action(vl.Input_Error_Blank, ("Document Name")))
                Txt1.Focus()
                Return False
            End If
        Else
            Msg(NOT_Type.Warning, "Selection Error - Document", "Please select Document")
            Button1.Focus()
            Return False
        End If
        If Txt3.Text <> Txt4.Text Then
            Msg(NOT_Type.Warning, "Password Error", "Please enter correct confirm password")
            Txt3.Focus()
            Return False
        End If
        Return True
    End Function
    Private Sub Txt3_TextChanged(sender As Object, e As EventArgs) Handles Txt3.TextChanged
        If Txt3.Text = "" Then
            Txt4.Hide()
        Else
            Txt4.Show()
        End If
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Panel3_DragEnter(sender As Object, e As DragEventArgs) Handles Panel4.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub Panel3_DragDrop(sender As Object, e As DragEventArgs) Handles Panel4.DragDrop
        If Txt1.Text <> "" Then
            Dim pathh As String = e.Data.GetData(DataFormats.FileDrop)(0)
            Dim extension As String = Path.GetExtension(pathh)

            Label62.Text = pathh
            Label63.Text = extension
            Label71.Text = Path.GetFileName(pathh)
            Label64.Text = Format(Val(Val(FileLen(pathh)) / 1024 / 1024), "0.00") & " Mb"


            'Button2.PerformClick()
        Else
            Txt1.Focus()
        End If
    End Sub
    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint
        obj_center(sender, Me)
    End Sub
End Class