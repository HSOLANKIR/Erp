Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.IO

Public Class FeedBank_frm
    Dim Path_End As String
    Dim VC_Type_ As String
    Dim VC_ID_ As String
    Private Sub FeedBank_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Path_End = BG_frm.BG_Path_TXT.Text
        VC_Type_ = Link_Valu(1)
        VC_ID_ = Link_Valu(2)

        BG_frm.HADE_TXT.Text = "Feedbank"
        BG_frm.TYP_TXT.Text = VC_Type_


        Name_TXT.Text = LC_Name
        Phone_TXT.Text = LC_Phone
        Email_txt.Text = LC_Email

        Button_Manage()

        Txt1.Focus()
    End Sub

    Private Sub FeedBank_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.HADE_TXT.Text = "Feedbank"
        BG_frm.TYP_TXT.Text = VC_Type_
        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text

        Button_Clear()
        Button_Manage()
    End Sub

    Private Sub FeedBank_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub FeedBank_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End
        Add_Hander_Remove_Handel(False)
        Frm_foCus()
    End Sub
    Private Function Add_Hander_Remove_Handel(Ans As Boolean)
        If Ans = True Then
            AddHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            AddHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
        Else
            RemoveHandler BG_frm.B_1.Click, AddressOf Me.B_1_Click
            RemoveHandler BG_frm.B_2.Click, AddressOf Me.B_2_Click
        End If
    End Function
    Private Sub B_1_Click(sender As Object, e As EventArgs)
        If BG_frm.HADE_TXT.Text = "Account Group" Or BG_frm.HADE_TXT.Text = "Account Group" Then
            Me.Dispose()
        End If
    End Sub
    Private Sub B_2_Click(sender As Object, e As EventArgs)
        Save_Data()
    End Sub
    Private Function Save_Data()

    End Function
    Private Function Button_Manage()
        Button_Clear()
        BG_frm.B_1.Text = "&E : Exit"
        BG_frm.B_2.Text = "&S : Save"
    End Function

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs)
        obj_center(sender, Panel2)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        BackgroundWorker1.RunWorkerAsync()
        Button2.Hide()
    End Sub
    Private Function Panel_manag(pa As Panel)
        Success_p.Visible = False
        feebank_P.Visible = False

        pa.Visible = True
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'OpenFileDialog1.Filter = "(Document Files)|*.jpg;*.png;*.bmp;*.gif;*.pdf|Jpg, | *.jpg|Png, | *.png|Bmp, | *.bmp|Gif, | *.gif|Pdf | *.pdf"
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Title = "Document Upload"
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            Dim MB As Decimal = Format(Val(Val(FileLen(OpenFileDialog1.FileName)) / 1024 / 1024), "0.00")
            If MB > 10 Then
                Msg_Custom_YN(NOT_Location.Bottom_Right, Color.Red, My.Resources.Error_animation_icn, Dialoag_Button.Ok, "Error", "Limit Cross", $"You can only upload files under 10 mb,<nl>you have selected a {MB} mb file")
                Label8.Text = ""
                Button1.PerformClick()
                Exit Sub
            End If
            Label16.Text = $"{MB} MB"
            Label8.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Dim issuccess As Boolean = False
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork


        Dim cn As New SqlConnection
        If Online_MSSQL(cn) = True Then
            Dim q1 As String = "(Name,Phone,Email,Subject,Message"

            Dim q2 As String = "(@Name,@Phone,@Email,@Subject,@Message"

            If Label8.Text <> Nothing Then
                q1 &= ",Attage"
                q2 &= ",@Attage"
            End If
            q1 &= ")"
            q2 &= ")"

            qury = $"INSERT INTO TBL_Feedbank {q1} VALUES {q2}"

            Try
                Dim cmd As New SqlCommand(qury, cn)
                With cmd.Parameters
                    .AddWithValue("@Name", "")
                    .AddWithValue("@Phone", "")
                    .AddWithValue("@Email", "")
                    .AddWithValue("@Subject", Txt1.Text.Trim)
                    .AddWithValue("@Message", Txt2.Text.Trim)
                    If Label8.Text <> Nothing Then
                        .AddWithValue("@Attage", SqlDbType.VarBinary).Value = File.ReadAllBytes(Label8.Text)
                    End If
                    cmd.ExecuteNonQuery()
                End With

                issuccess = True
            Catch ex As Exception
                issuccess = False
                Msg_Custom_YN(NOT_Location.Bottom_Right, Color.Red, My.Resources.Error_animation_icn, Dialoag_Button.Ok, "Error", "Feedbank Submit Error", ex.Message)
            End Try

        End If
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If issuccess = True Then
            Panel_manag(Success_p)
        Else
            Button2.Show()
            Button2.BringToFront()
        End If
    End Sub

    Private Sub Panel9_Paint(sender As Object, e As PaintEventArgs) Handles Success_p.Paint
        obj_center(sender, Panel2)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Dispose()
    End Sub

    Private Sub feebank_P_Paint(sender As Object, e As PaintEventArgs) Handles feebank_P.Paint
        obj_center(sender, Me)
    End Sub
End Class