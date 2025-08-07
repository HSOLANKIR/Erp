Imports System.ComponentModel
Imports System.Net.Mail
Public Class Mix_frm
    Dim x, y As Integer
    Dim Issuccess As Boolean
    Private Sub Mix_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub
    Public Function Network_pop()
        Dim ms As New Mix_frm
        With ms
            .BackColor = Color.White
            .StartPosition = FormStartPosition.CenterScreen
            .FormBorderStyle = FormBorderStyle.None
            .WindowState = FormWindowState.Normal
            .Size = Network_error_ctrl1.Size

            .Network_error_ctrl1.Visible = True
            .Network_error_ctrl1.obj_ = ms
            .Network_error_ctrl1.Timer1.Start()
            .Network_error_ctrl1.Dock = DockStyle.Fill
            ms.Location = New Point(BG_frm.BG_PAN.ClientSize.Width / 2 - ms.Size.Width / 2, BG_frm.BG_PAN.ClientSize.Height / 2 - ms.Size.Height / 2)

            .ShowDialog()
        End With
    End Function
    Public Function Msg(NOT_Ty As String, Head As String, Message As String)
        Dim ms As New Mix_frm
        With ms
            .BackColor = Color.SeaShell
            .StartPosition = FormStartPosition.CenterScreen
            .FormBorderStyle = FormBorderStyle.None
            .Size = New Size(362, 252)
            .Panel1.Dock = DockStyle.Fill
            .Panel1.Visible = True
            .Msg_Head_LB.Text = Head
            .Label1.Text = Message
            .Panel1.BorderStyle = BorderStyle.None
            .Opacity = 100
            If NOT_Ty = "Success" Then
                .PictureBox1.Image = My.Resources.Success_PNG
                .Panel2.BackColor = Color.Green
                .Panel8.BackColor = Color.Green
                .Panel10.BackColor = Color.Green
                .Panel11.BackColor = Color.Green
                .Msg_Head_LB.ForeColor = Color.Green
            End If
            If NOT_Ty = "Erro" Then
                .PictureBox1.Image = My.Resources.Error_PNG
                .Panel2.BackColor = Color.Red
                .Panel8.BackColor = Color.Red
                .Panel10.BackColor = Color.Red
                .Panel11.BackColor = Color.Red
                .Msg_Head_LB.ForeColor = Color.Red
            End If
            If NOT_Ty = "Info" Then
                .PictureBox1.Image = My.Resources.Information_PNG
                .Panel2.BackColor = Color.DeepSkyBlue
                .Panel8.BackColor = Color.DeepSkyBlue
                .Panel10.BackColor = Color.DeepSkyBlue
                .Panel11.BackColor = Color.DeepSkyBlue
                .Msg_Head_LB.ForeColor = Color.DeepSkyBlue
            End If
            If NOT_Ty = "Warning" Then
                .PictureBox1.Image = My.Resources.Exclamation_PNG
                .Panel2.BackColor = Color.OrangeRed
                .Panel8.BackColor = Color.OrangeRed
                .Panel10.BackColor = Color.OrangeRed
                .Panel11.BackColor = Color.OrangeRed
                .Msg_Head_LB.ForeColor = Color.OrangeRed
            End If
            AddHandler ms.KeyDown, AddressOf ms.msg_anyKey_pres_exit
            ms.Location = New Point(BG_frm.BG_PAN.ClientSize.Width / 2 - ms.Size.Width / 2, BG_frm.BG_PAN.ClientSize.Height / 2 - ms.Size.Height / 2)

            .ShowDialog()
        End With
    End Function
    Public Function YN(Head As String, Message As String) As DialogResult
        Dim ms As New Mix_frm
        With ms
            .BackColor = Color.SeaShell
            .StartPosition = FormStartPosition.CenterScreen
            .FormBorderStyle = FormBorderStyle.None
            .Size = New Size(210, 200)
            .Panel3.Dock = DockStyle.Fill
            .Panel3.Visible = True
            .Label3.Text = Head
            .Label4.Text = Message
            .Panel3.BorderStyle = BorderStyle.None
            AddHandler ms.KeyDown, AddressOf ms.yn_anyKey_pres_exit
            My.Computer.Audio.Play(My.Resources.Wharning_Sound, AudioPlayMode.Background)
        End With

        Return ms.ShowDialog
    End Function
    Public Function LOAD(Head As String)
        Dim ms As New Mix_frm
        With ms
            .BackColor = Color.OldLace
            .StartPosition = FormStartPosition.CenterScreen
            .FormBorderStyle = FormBorderStyle.None
            .Size = New Size(200, 200)
            .Panel5.Dock = DockStyle.Fill
            .Panel5.Visible = True
            .Label12.Text = Head
            .Panel5.BorderStyle = BorderStyle.FixedSingle
            .Show()
        End With
    End Function
    Dim Email_Add As String
    Dim Email_Subj As String
    Dim Email_Mess As String
    Public Function EMAIL(Email_Address As String, SubJect As String, Message As String) As DialogResult
        Dim ms As New Mix_frm
        With ms
            .Email_Add = Email_Address
            .Email_Subj = SubJect
            .Email_Mess = Message
            .BackColor = Color.OldLace
            .StartPosition = FormStartPosition.CenterScreen
            .FormBorderStyle = FormBorderStyle.None
            .Size = New Size(200, 200)
            .Panel5.Dock = DockStyle.Fill
            .Panel5.Visible = True
            .Label12.Text = "E-mail Sending..."
            .Panel5.BorderStyle = BorderStyle.FixedSingle
            .Email_Sending_Background.RunWorkerAsync()
        End With
        Return ms.ShowDialog()
    End Function
    Private Sub Email_Verified_TXT_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs)

    End Sub

    Private Sub msg_anyKey_pres_exit(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Or e.KeyCode = Keys.Enter Then
            Me.Dispose()
        End If
    End Sub
    Private Sub yn_anyKey_pres_exit(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Y Then
            Me.DialogResult = DialogResult.Yes
            Me.Dispose()
        End If

        If e.KeyCode = Keys.N Then
            Me.DialogResult = DialogResult.No
            Me.Dispose()
        End If

        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = DialogResult.Cancel
            Me.Dispose()
        End If
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Me.DialogResult = DialogResult.Yes
        Me.Dispose()
        List_frm.Dispose()
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Me.DialogResult = DialogResult.No
        Me.Dispose()
    End Sub

    Private Sub Email_Sending_Background_DoWork_1(sender As Object, e As DoWorkEventArgs) Handles Email_Sending_Background.DoWork
        Try
            Dim mail As New MailMessage
            Dim SMTPServee As New SmtpClient
            mail.From = New MailAddress(Send_Email)
            mail.Subject = Email_Subj
            mail.To.Add(Email_Add)
            mail.Body = Email_Mess
            Dim SMTP As New SmtpClient("smtp.gmail.com")
            SMTP.EnableSsl = True
            SMTP.Credentials = New Net.NetworkCredential(Send_Email, Send_Email_Password)
            SMTP.Port = "587"
            SMTP.Send(mail)
            Issuccess = True
        Catch ex As Exception
            Issuccess = False
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Email_Sending_Background_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles Email_Sending_Background.RunWorkerCompleted
        If Issuccess = True Then
            Me.DialogResult = DialogResult.Yes
        Else
            Me.DialogResult = DialogResult.No
        End If
        Me.Dispose()
    End Sub
End Class