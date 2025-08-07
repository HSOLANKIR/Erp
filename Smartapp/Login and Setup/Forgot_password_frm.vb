Imports System.Data.SqlClient
Imports System.IO

Public Class Forgot_password_frm
    Dim From_ID As String
    Dim User_ID As String
    Dim Path_End As String

    Private Sub Forgot_password_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Path_End = BG_frm.BG_Path_TXT.Text

        User_Panel.Location = New Point(BG_Panel.ClientSize.Width / 2 - User_Panel.Size.Width / 2, BG_Panel.ClientSize.Height / 2 - User_Panel.Size.Height / 2)
        User_Details_Panel.Location = New Point(BG_Panel.ClientSize.Width / 2 - User_Details_Panel.Size.Width / 2, BG_Panel.ClientSize.Height / 2 - User_Details_Panel.Size.Height / 2)
        Panel1.Location = New Point(BG_Panel.ClientSize.Width / 2 - Panel1.Size.Width / 2, BG_Panel.ClientSize.Height / 2 - Panel1.Size.Height / 2)
        Admin_Permission_Panel.Location = New Point(BG_Panel.ClientSize.Width / 2 - Admin_Permission_Panel.Size.Width / 2, BG_Panel.ClientSize.Height / 2 - Admin_Permission_Panel.Size.Height / 2)
        User_Permission_Panel.Location = New Point(BG_Panel.ClientSize.Width / 2 - User_Permission_Panel.Size.Width / 2, BG_Panel.ClientSize.Height / 2 - User_Permission_Panel.Size.Height / 2)
        PictureBox2.Image = My.Resources.Loding_Progress
        PictureBox3.Image = My.Resources.Loding_Progress
        PictureBox4.Image = My.Resources.Loding_Progress
        PictureBox5.Image = My.Resources.Loding_Progress
        PictureBox6.Image = My.Resources.Loding_Progress
        BG_frm.HADE_TXT.Text = "Password Manager"
    End Sub

    Private Sub User_TXT_TextChanged(sender As Object, e As EventArgs) Handles User_TXT.TextChanged

    End Sub

    Private Sub User_TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles User_TXT.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Online_MSSQL(cn) = True Then
                If Chack_User() = True Then
                    Hide_pAnel(User_Details_Panel)
                    TextBox1.Text = User_TXT.Text
                    PictureBox2.Image = My.Resources.Success_PNG
                Else
                    PictureBox2.Image = My.Resources.Error_PNG
                End If
            End If
        End If
    End Sub

    Private Sub Forgot_password_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If User_Permission_Panel.Visible = True Then
            If e.KeyCode = Keys.Y Then
                If Email_Verification("User Permission (User Forgot Password)", "", TextBox4.Text, "User Forgot Password", "", 500) = DialogResult.Yes Then
                    Hide_pAnel(Panel1)
                    PictureBox4.Image = My.Resources.Success_PNG
                Else
                    PictureBox4.Image = My.Resources.Error_PNG
                End If
            End If
            If e.KeyCode = Keys.N Then
                Hide_pAnel(User_Details_Panel)
            End If
        End If

        If Admin_Permission_Panel.Visible = True Then
            If e.KeyCode = Keys.Y Then
                If Email_Verification("Admin Permission (User Forgot Password)", Company_Name_str, User_Email, "Admin Permission (User Forgot Password)", "", 500) = DialogResult.Yes Then
                    Hide_pAnel(User_Permission_Panel)
                    PictureBox6.Image = My.Resources.Success_PNG
                Else
                    PictureBox6.Image = My.Resources.Error_PNG
                End If
            End If
            If e.KeyCode = Keys.N Then
                Hide_pAnel(User_Details_Panel)
            End If
        End If

        If e.KeyCode = Keys.Escape Then
            If User_Panel.Visible = True Then
                If Msg_Yn("Exit ?", "") = DialogResult.Yes Then
                    Me.Dispose()
                End If
            End If
            If User_Details_Panel.Visible = True Then
                Hide_pAnel(User_Panel)
            End If
            If Admin_Permission_Panel.Visible = True Then
                Hide_pAnel(User_Details_Panel)
            End If
            If User_Permission_Panel.Visible = True Then
                Hide_pAnel(User_Details_Panel)
            End If
            If Panel1.Visible = True Then
                If Msg_Yn("Want to stop midway", "") = DialogResult.Yes Then
                    Hide_pAnel(User_Details_Panel)
                End If
            End If
        End If
    End Sub

    Private Sub Forgot_password_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.HADE_TXT.Text = "Password Manager"
        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text
        Button_Clear()
        User_TXT.Focus()
    End Sub

    Private Sub Forgot_password_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End
        NOT_Clear()
        Frm_foCus()
    End Sub

    Private Function Chack_User() As Boolean
        Dim r As SqlDataReader
        qury = "SELECT * FROM TBL_Login Where CompanySerial = " & "'" & Company_ID_str & "' AND UserName = '" & User_TXT.Text & "'"
        cmd_ = New SqlCommand(qury, cn)
        r = cmd_.ExecuteReader
        While r.Read
            If r("Approval") = "Approval" Then
                User_ID = r("ID")
                NOT_Clear()
                Return True
            Else
                User_ID = ""
                NOT_("User is not allow (" & r("Approval") & ")", NOT_Type.Erro)
            End If
        End While
        r.Close()
        NOT_("User is not found", NOT_Type.Erro)
    End Function

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If TextBox2.Text = "Forgot Password" Or TextBox2.Text = "F" Then
            TextBox2.UseSystemPasswordChar = False
        Else
            TextBox2.UseSystemPasswordChar = True
        End If
    End Sub
    Private Sub Enter_All(sender As Object, e As EventArgs) Handles TextBox1.Enter, TextBox2.Enter, TextBox3.Enter, TextBox4.Enter
        Enter_(sender)
    End Sub
    Private Sub Lostfocus_All(sender As Object, e As EventArgs) Handles TextBox1.LostFocus, TextBox2.LostFocus, TextBox3.LostFocus, TextBox4.LostFocus
        Lost_(sender)
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBox2.Enabled = False
            Panel9.Show()
        Else
            TextBox2.Enabled = True
            TextBox2.Focus()
            Panel9.Hide()
        End If
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub TextBox4_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox4.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Msg_Yn("Chack details", "") = DialogResult.Yes Then
                If Chack_User_details() = True Then
                    If CheckBox1.Checked = True Then
                        Hide_pAnel(Admin_Permission_Panel)
                        PictureBox3.Image = My.Resources.Success_PNG
                    Else
                        Hide_pAnel(User_Permission_Panel)
                        PictureBox3.Image = My.Resources.Success_PNG
                    End If
                Else
                    PictureBox3.Image = My.Resources.Error_PNG
                    TextBox2.Focus()
                End If
            End If
        End If
    End Sub
    Dim cn As New SqlConnection
    Private Function Chack_User_details() As Boolean
        Dim r As SqlDataReader
        If Online_MSSQL(cn) = True Then
            qury = "SELECT * FROM TBL_Login Where ID = " & "'" & User_ID & "'"
            cmd_ = New SqlCommand(qury, cn)
            r = cmd_.ExecuteReader
            While r.Read
                Dim data As Byte() = DirectCast(r("Photo"), Byte())
                Dim ms As New MemoryStream(data)
                Dim im As Image = Image.FromStream(ms)
                PictureBox1.Image = Image.FromStream(ms)
                If CheckBox1.Checked = True Then
                    If r("Phone") = TextBox3.Text And r("Email") = TextBox4.Text Then
                        NOT_("User Details is match", NOT_Type.Success)
                        Return True
                    Else
                        NOT_("User details is not match", NOT_Type.Erro)
                        Return False
                    End If
                Else
                    If r("Password") = TextBox2.Text And r("Phone") = TextBox3.Text And r("Email") = TextBox4.Text Then
                        NOT_("User Details is match", NOT_Type.Success)
                        Return True
                    Else
                        NOT_("User details is not match", NOT_Type.Erro)
                        Return False
                    End If
                End If
            End While
            r.Close()
            NOT_("User is not found", NOT_Type.Erro)
        End If

    End Function
    Private Function Hide_pAnel(Pa As Panel)
        User_Panel.Hide()
        User_Details_Panel.Hide()
        Panel1.Hide()
        Admin_Permission_Panel.Hide()
        User_Permission_Panel.Hide()

        User_Panel.Enabled = False
        User_Details_Panel.Enabled = False
        Panel1.Enabled = False
        Admin_Permission_Panel.Enabled = False
        User_Permission_Panel.Enabled = False

        Pa.Show()
        Pa.Enabled = True
        Pa.BringToFront()
        Pa.Focus()
    End Function

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        If TextBox8.Text = TextBox5.Text Then
            NOT_Clear()
        Else
            NOT_("Confor Password is not match", NOT_Type.Erro)
        End If
    End Sub

    Private Sub TextBox5_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox5.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TextBox8.Text = TextBox5.Text Then
                If Msg_Yn("Update Password ?", "") = DialogResult.Yes Then
                    Try
                        qury = "UPDATE TBL_Login SET Password = '" & TextBox5.Text & "' WHERE ID = '" & User_ID & "'"
                        cmd_ = New SqlCommand(qury, cn)
                        cmd_.ExecuteNonQuery()

                        My.Computer.Audio.Play(My.Resources.apple_pay, AudioPlayMode.Background)
                        NOT_("Password Updated Successfully", NOT_Type.Success)
                        PictureBox5.Image = My.Resources.Success_PNG
                        Me.Dispose()
                    Catch ex As Exception
                        My.Computer.Audio.Play(My.Resources.z_error, AudioPlayMode.Background)
                        NOT_("Password Updated Faild", NOT_Type.Erro)
                        PictureBox5.Image = My.Resources.Error_PNG
                    End Try
                End If
            Else
                NOT_("Confor Password is not match", NOT_Type.Erro)
                TextBox5.Text = ""
                TextBox5.Focus()
            End If
        End If
    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged
        TextBox5_TextChanged(e, e)
    End Sub

    Private Sub Panel1_VisibleChanged(sender As Object, e As EventArgs) Handles Panel1.VisibleChanged
        If sender.Visible = True Then
            TextBox8.Focus()
        End If
    End Sub
    Private Sub User_Panel_VisibleChanged(sender As Object, e As EventArgs) Handles User_Panel.VisibleChanged
        If sender.Visible = True Then
            User_TXT.Focus()
        End If
    End Sub
    Private Sub User_Details_Panel_VisibleChanged(sender As Object, e As EventArgs) Handles User_Details_Panel.VisibleChanged
        If sender.Visible = True Then
            TextBox1.Focus()
        End If
    End Sub

    Private Sub BG_Panel_Paint(sender As Object, e As PaintEventArgs) Handles BG_Panel.Paint

    End Sub

    Private Sub Label28_Click(sender As Object, e As EventArgs) Handles Label28.Click

    End Sub

    Private Sub Forgot_password_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
    End Sub
End Class