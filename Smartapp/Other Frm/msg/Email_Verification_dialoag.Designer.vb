<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Email_Verification_dialoag
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Email_Verification_dialoag))
        Me.SEDING_EMAIL_MESSAGE_TXT = New System.Windows.Forms.Label()
        Me.SEDING_EMAIL_HEAD_TXT = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Email_Sendin_Panel = New System.Windows.Forms.Panel()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Email_Verification_Panel = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Email_Verified_TXT = New System.Windows.Forms.MaskedTextBox()
        Me.Email_Sec_Lab = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Email_Sending_OTP_Background = New System.ComponentModel.BackgroundWorker()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Email_Sendin_Panel.SuspendLayout()
        Me.Panel10.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Email_Verification_Panel.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SEDING_EMAIL_MESSAGE_TXT
        '
        Me.SEDING_EMAIL_MESSAGE_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SEDING_EMAIL_MESSAGE_TXT.Location = New System.Drawing.Point(5, 144)
        Me.SEDING_EMAIL_MESSAGE_TXT.Name = "SEDING_EMAIL_MESSAGE_TXT"
        Me.SEDING_EMAIL_MESSAGE_TXT.Size = New System.Drawing.Size(313, 170)
        Me.SEDING_EMAIL_MESSAGE_TXT.TabIndex = 12
        Me.SEDING_EMAIL_MESSAGE_TXT.Text = "Head"
        Me.SEDING_EMAIL_MESSAGE_TXT.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'SEDING_EMAIL_HEAD_TXT
        '
        Me.SEDING_EMAIL_HEAD_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SEDING_EMAIL_HEAD_TXT.Location = New System.Drawing.Point(5, 118)
        Me.SEDING_EMAIL_HEAD_TXT.Name = "SEDING_EMAIL_HEAD_TXT"
        Me.SEDING_EMAIL_HEAD_TXT.Size = New System.Drawing.Size(313, 22)
        Me.SEDING_EMAIL_HEAD_TXT.TabIndex = 11
        Me.SEDING_EMAIL_HEAD_TXT.Text = "Head"
        Me.SEDING_EMAIL_HEAD_TXT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox4
        '
        Me.PictureBox4.BackgroundImage = CType(resources.GetObject("PictureBox4.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox4.Image = Global.Management.My.Resources.Resources.email_send_animation_icn
        Me.PictureBox4.Location = New System.Drawing.Point(106, 3)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(110, 110)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox4.TabIndex = 10
        Me.PictureBox4.TabStop = False
        '
        'Email_Sendin_Panel
        '
        Me.Email_Sendin_Panel.Controls.Add(Me.Panel10)
        Me.Email_Sendin_Panel.Controls.Add(Me.PictureBox1)
        Me.Email_Sendin_Panel.Controls.Add(Me.PictureBox4)
        Me.Email_Sendin_Panel.Controls.Add(Me.SEDING_EMAIL_MESSAGE_TXT)
        Me.Email_Sendin_Panel.Controls.Add(Me.SEDING_EMAIL_HEAD_TXT)
        Me.Email_Sendin_Panel.Location = New System.Drawing.Point(0, 0)
        Me.Email_Sendin_Panel.Name = "Email_Sendin_Panel"
        Me.Email_Sendin_Panel.Size = New System.Drawing.Size(323, 378)
        Me.Email_Sendin_Panel.TabIndex = 13
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.Button1)
        Me.Panel10.Controls.Add(Me.Button2)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel10.Location = New System.Drawing.Point(0, 318)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(323, 60)
        Me.Panel10.TabIndex = 16
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Location = New System.Drawing.Point(173, 15)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(118, 37)
        Me.Button1.TabIndex = 15
        Me.Button1.Text = "&CANCEL"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Turquoise
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Black
        Me.Button2.Location = New System.Drawing.Point(29, 15)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(118, 37)
        Me.Button2.TabIndex = 14
        Me.Button2.Text = "&SEND"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Image = Global.Management.My.Resources.Resources.Loding_Progress
        Me.PictureBox1.Location = New System.Drawing.Point(135, 318)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 14
        Me.PictureBox1.TabStop = False
        '
        'Email_Verification_Panel
        '
        Me.Email_Verification_Panel.Controls.Add(Me.Panel1)
        Me.Email_Verification_Panel.Controls.Add(Me.Label2)
        Me.Email_Verification_Panel.Controls.Add(Me.Label1)
        Me.Email_Verification_Panel.Controls.Add(Me.Email_Verified_TXT)
        Me.Email_Verification_Panel.Controls.Add(Me.Email_Sec_Lab)
        Me.Email_Verification_Panel.Controls.Add(Me.Label9)
        Me.Email_Verification_Panel.Controls.Add(Me.Panel4)
        Me.Email_Verification_Panel.Controls.Add(Me.PictureBox2)
        Me.Email_Verification_Panel.Controls.Add(Me.PictureBox3)
        Me.Email_Verification_Panel.Location = New System.Drawing.Point(328, 0)
        Me.Email_Verification_Panel.Name = "Email_Verification_Panel"
        Me.Email_Verification_Panel.Size = New System.Drawing.Size(323, 378)
        Me.Email_Verification_Panel.TabIndex = 14
        Me.Email_Verification_Panel.Visible = False
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Green
        Me.Label1.Location = New System.Drawing.Point(0, 285)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(323, 39)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Verification code is successfully sent" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Please check email and enter Verification" &
    " code"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Email_Verified_TXT
        '
        Me.Email_Verified_TXT.BackColor = System.Drawing.Color.White
        Me.Email_Verified_TXT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Email_Verified_TXT.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Email_Verified_TXT.Location = New System.Drawing.Point(72, 117)
        Me.Email_Verified_TXT.Mask = "###-###"
        Me.Email_Verified_TXT.Name = "Email_Verified_TXT"
        Me.Email_Verified_TXT.Size = New System.Drawing.Size(176, 24)
        Me.Email_Verified_TXT.TabIndex = 19
        Me.Email_Verified_TXT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Email_Sec_Lab
        '
        Me.Email_Sec_Lab.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Email_Sec_Lab.ForeColor = System.Drawing.Color.Blue
        Me.Email_Sec_Lab.Location = New System.Drawing.Point(38, 169)
        Me.Email_Sec_Lab.Name = "Email_Sec_Lab"
        Me.Email_Sec_Lab.Size = New System.Drawing.Size(245, 22)
        Me.Email_Sec_Lab.TabIndex = 17
        Me.Email_Sec_Lab.Text = "120"
        Me.Email_Sec_Lab.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(38, 194)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(245, 22)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Seconds valid"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Button3)
        Me.Panel4.Controls.Add(Me.Button4)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 324)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(323, 54)
        Me.Panel4.TabIndex = 16
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.Black
        Me.Button3.Location = New System.Drawing.Point(173, 9)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(118, 37)
        Me.Button3.TabIndex = 15
        Me.Button3.Text = "&CANCEL"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Turquoise
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.Black
        Me.Button4.Location = New System.Drawing.Point(29, 9)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(118, 37)
        Me.Button4.TabIndex = 14
        Me.Button4.Text = "&VERIFY NOW"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox2.Image = Global.Management.My.Resources.Resources.Loding_Progress
        Me.PictureBox2.Location = New System.Drawing.Point(135, 324)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 14
        Me.PictureBox2.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackgroundImage = CType(resources.GetObject("PictureBox3.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox3.Image = Global.Management.My.Resources.Resources.email_recevied_animation_icn
        Me.PictureBox3.Location = New System.Drawing.Point(106, 3)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(110, 110)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 10
        Me.PictureBox3.TabStop = False
        '
        'Email_Sending_OTP_Background
        '
        '
        'Timer1
        '
        Me.Timer1.Interval = 830
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(12, 145)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(298, 17)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Refrence No : PFP/005/05"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Silver
        Me.Panel1.Location = New System.Drawing.Point(30, 166)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(262, 1)
        Me.Panel1.TabIndex = 22
        '
        'Email_Verification_dialoag
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(666, 379)
        Me.Controls.Add(Me.Email_Verification_Panel)
        Me.Controls.Add(Me.Email_Sendin_Panel)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Email_Verification_dialoag"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Email Verification"
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Email_Sendin_Panel.ResumeLayout(False)
        Me.Panel10.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Email_Verification_Panel.ResumeLayout(False)
        Me.Email_Verification_Panel.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SEDING_EMAIL_MESSAGE_TXT As Label
    Friend WithEvents SEDING_EMAIL_HEAD_TXT As Label
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents Email_Sendin_Panel As Panel
    Friend WithEvents Panel10 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Email_Verification_Panel As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Email_Verified_TXT As MaskedTextBox
    Friend WithEvents Email_Sec_Lab As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Email_Sending_OTP_Background As System.ComponentModel.BackgroundWorker
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel1 As Panel
End Class
