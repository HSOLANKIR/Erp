<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Email_Login_frm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Email_Login_frm))
        Me.Label8 = New System.Windows.Forms.Label()
        Me.PORT_TXT = New Tools.TXT()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.SMTP_TXT = New Tools.TXT()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Pass_TXT = New Tools.TXT()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Email_TXT = New Tools.TXT()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Gateway_ = New Tools.TXT()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Login_P = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Login_P.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(156, 59)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(19, 16)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = " : "
        '
        'PORT_TXT
        '
        Me.PORT_TXT.Auto_Cleane = True
        Me.PORT_TXT.Back_color = System.Drawing.Color.White
        Me.PORT_TXT.BackColor = System.Drawing.Color.White
        Me.PORT_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.PORT_TXT.Data_Link_ = ""
        Me.PORT_TXT.Decimal_ = 2
        Me.PORT_TXT.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.PORT_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.PORT_TXT.Font_Size = 10
        Me.PORT_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.PORT_TXT.Format_ = "dd-MM-yyyy"
        Me.PORT_TXT.Keydown_Support = True
        Me.PORT_TXT.Location = New System.Drawing.Point(182, 59)
        Me.PORT_TXT.Msg_Object = Nothing
        Me.PORT_TXT.Name = "PORT_TXT"
        Me.PORT_TXT.Select_Auto_Show = True
        Me.PORT_TXT.Select_Column_Color = "NA"
        Me.PORT_TXT.Select_Columns = 0
        Me.PORT_TXT.Select_Filter = Nothing
        Me.PORT_TXT.Select_Hide_Columns = "NA"
        Me.PORT_TXT.Select_Object = Nothing
        Me.PORT_TXT.Select_Source = Nothing
        Me.PORT_TXT.Size = New System.Drawing.Size(60, 16)
        Me.PORT_TXT.TabIndex = 2
        Me.PORT_TXT.Type_ = "TXT"
        Me.PORT_TXT.Val_max = 1000000000
        Me.PORT_TXT.Val_min = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 59)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(79, 16)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "Server Port"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(156, 37)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(19, 16)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = " : "
        '
        'SMTP_TXT
        '
        Me.SMTP_TXT.Auto_Cleane = True
        Me.SMTP_TXT.Back_color = System.Drawing.Color.White
        Me.SMTP_TXT.BackColor = System.Drawing.Color.White
        Me.SMTP_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.SMTP_TXT.Data_Link_ = ""
        Me.SMTP_TXT.Decimal_ = 2
        Me.SMTP_TXT.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.SMTP_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.SMTP_TXT.Font_Size = 10
        Me.SMTP_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.SMTP_TXT.Format_ = "dd-MM-yyyy"
        Me.SMTP_TXT.Keydown_Support = True
        Me.SMTP_TXT.Location = New System.Drawing.Point(182, 37)
        Me.SMTP_TXT.Msg_Object = Nothing
        Me.SMTP_TXT.Name = "SMTP_TXT"
        Me.SMTP_TXT.Select_Auto_Show = True
        Me.SMTP_TXT.Select_Column_Color = "NA"
        Me.SMTP_TXT.Select_Columns = 0
        Me.SMTP_TXT.Select_Filter = Nothing
        Me.SMTP_TXT.Select_Hide_Columns = "NA"
        Me.SMTP_TXT.Select_Object = Nothing
        Me.SMTP_TXT.Select_Source = Nothing
        Me.SMTP_TXT.Size = New System.Drawing.Size(192, 16)
        Me.SMTP_TXT.TabIndex = 1
        Me.SMTP_TXT.Type_ = "TXT"
        Me.SMTP_TXT.Val_max = 1000000000
        Me.SMTP_TXT.Val_min = 0
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 37)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(106, 16)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "Outgoing SMTP"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(156, 110)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(19, 16)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = " : "
        '
        'Pass_TXT
        '
        Me.Pass_TXT.Auto_Cleane = True
        Me.Pass_TXT.Back_color = System.Drawing.Color.White
        Me.Pass_TXT.BackColor = System.Drawing.Color.White
        Me.Pass_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Pass_TXT.Data_Link_ = ""
        Me.Pass_TXT.Decimal_ = 2
        Me.Pass_TXT.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Pass_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Pass_TXT.Font_Size = 10
        Me.Pass_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Pass_TXT.Format_ = "dd-MM-yyyy"
        Me.Pass_TXT.Keydown_Support = True
        Me.Pass_TXT.Location = New System.Drawing.Point(182, 110)
        Me.Pass_TXT.Msg_Object = Nothing
        Me.Pass_TXT.Name = "Pass_TXT"
        Me.Pass_TXT.Select_Auto_Show = True
        Me.Pass_TXT.Select_Column_Color = "NA"
        Me.Pass_TXT.Select_Columns = 0
        Me.Pass_TXT.Select_Filter = Nothing
        Me.Pass_TXT.Select_Hide_Columns = "NA"
        Me.Pass_TXT.Select_Object = Nothing
        Me.Pass_TXT.Select_Source = Nothing
        Me.Pass_TXT.Size = New System.Drawing.Size(120, 16)
        Me.Pass_TXT.TabIndex = 4
        Me.Pass_TXT.Type_ = "TXT"
        Me.Pass_TXT.UseSystemPasswordChar = True
        Me.Pass_TXT.Val_max = 1000000000
        Me.Pass_TXT.Val_min = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 110)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 16)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Password"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(156, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(19, 16)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = " : "
        '
        'Email_TXT
        '
        Me.Email_TXT.Auto_Cleane = True
        Me.Email_TXT.Back_color = System.Drawing.Color.White
        Me.Email_TXT.BackColor = System.Drawing.Color.White
        Me.Email_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Email_TXT.Data_Link_ = ""
        Me.Email_TXT.Decimal_ = 2
        Me.Email_TXT.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Email_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Email_TXT.Font_Size = 10
        Me.Email_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Email_TXT.Format_ = "dd-MM-yyyy"
        Me.Email_TXT.Keydown_Support = True
        Me.Email_TXT.Location = New System.Drawing.Point(182, 88)
        Me.Email_TXT.Msg_Object = Nothing
        Me.Email_TXT.Name = "Email_TXT"
        Me.Email_TXT.Select_Auto_Show = True
        Me.Email_TXT.Select_Column_Color = "NA"
        Me.Email_TXT.Select_Columns = 0
        Me.Email_TXT.Select_Filter = Nothing
        Me.Email_TXT.Select_Hide_Columns = "NA"
        Me.Email_TXT.Select_Object = Nothing
        Me.Email_TXT.Select_Source = Nothing
        Me.Email_TXT.Size = New System.Drawing.Size(192, 16)
        Me.Email_TXT.TabIndex = 3
        Me.Email_TXT.Type_ = "TXT"
        Me.Email_TXT.Val_max = 1000000000
        Me.Email_TXT.Val_min = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 88)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 16)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Email Address"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(156, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(19, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = " : "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Email Gateway"
        '
        'Gateway_
        '
        Me.Gateway_.Auto_Cleane = True
        Me.Gateway_.Back_color = System.Drawing.Color.White
        Me.Gateway_.BackColor = System.Drawing.Color.White
        Me.Gateway_.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Gateway_.Data_Link_ = ""
        Me.Gateway_.Decimal_ = 2
        Me.Gateway_.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Gateway_.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Gateway_.Font_Size = 10
        Me.Gateway_.Font_Style = System.Drawing.FontStyle.Bold
        Me.Gateway_.Format_ = "dd-MM-yyyy"
        Me.Gateway_.Keydown_Support = True
        Me.Gateway_.Location = New System.Drawing.Point(182, 7)
        Me.Gateway_.Msg_Object = Nothing
        Me.Gateway_.Name = "Gateway_"
        Me.Gateway_.Select_Auto_Show = True
        Me.Gateway_.Select_Column_Color = "NA"
        Me.Gateway_.Select_Columns = 0
        Me.Gateway_.Select_Filter = " "
        Me.Gateway_.Select_Hide_Columns = "NA"
        Me.Gateway_.Select_Object = Nothing
        Me.Gateway_.Select_Source = Nothing
        Me.Gateway_.Size = New System.Drawing.Size(192, 16)
        Me.Gateway_.TabIndex = 0
        Me.Gateway_.Type_ = "Select"
        Me.Gateway_.Val_max = 1000000000
        Me.Gateway_.Val_min = 0
        '
        'Login_P
        '
        Me.Login_P.BackColor = System.Drawing.Color.White
        Me.Login_P.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Login_P.Controls.Add(Me.Label12)
        Me.Login_P.Controls.Add(Me.Label1)
        Me.Login_P.Controls.Add(Me.Button2)
        Me.Login_P.Controls.Add(Me.Panel6)
        Me.Login_P.Controls.Add(Me.Panel5)
        Me.Login_P.Controls.Add(Me.Panel1)
        Me.Login_P.Controls.Add(Me.Label25)
        Me.Login_P.Controls.Add(Me.Label26)
        Me.Login_P.Controls.Add(Me.Label27)
        Me.Login_P.Controls.Add(Me.Label28)
        Me.Login_P.Controls.Add(Me.Label29)
        Me.Login_P.Controls.Add(Me.Panel4)
        Me.Login_P.Controls.Add(Me.Label30)
        Me.Login_P.Controls.Add(Me.Panel7)
        Me.Login_P.Controls.Add(Me.PictureBox1)
        Me.Login_P.Location = New System.Drawing.Point(95, 80)
        Me.Login_P.Name = "Login_P"
        Me.Login_P.Size = New System.Drawing.Size(630, 380)
        Me.Login_P.TabIndex = 10
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.DimGray
        Me.Label12.Location = New System.Drawing.Point(10, 313)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(239, 16)
        Me.Label12.TabIndex = 27
        Me.Label12.Text = "5). Your password will be on the display."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DimGray
        Me.Label1.Location = New System.Drawing.Point(10, 288)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(321, 16)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "4). Enter the App name 'CRYPTONIX' and Click Create"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.PaleTurquoise
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(266, 341)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(97, 29)
        Me.Button2.TabIndex = 20
        Me.Button2.Text = "Save"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.LightGray
        Me.Panel6.Location = New System.Drawing.Point(6, 334)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(617, 1)
        Me.Panel6.TabIndex = 23
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Gateway_)
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Controls.Add(Me.Label8)
        Me.Panel5.Controls.Add(Me.Label2)
        Me.Panel5.Controls.Add(Me.PORT_TXT)
        Me.Panel5.Controls.Add(Me.Label6)
        Me.Panel5.Controls.Add(Me.Label5)
        Me.Panel5.Controls.Add(Me.Label11)
        Me.Panel5.Controls.Add(Me.Pass_TXT)
        Me.Panel5.Controls.Add(Me.SMTP_TXT)
        Me.Panel5.Controls.Add(Me.Email_TXT)
        Me.Panel5.Controls.Add(Me.Label9)
        Me.Panel5.Controls.Add(Me.Label7)
        Me.Panel5.Controls.Add(Me.Label10)
        Me.Panel5.Controls.Add(Me.Label4)
        Me.Panel5.Location = New System.Drawing.Point(163, 27)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(417, 139)
        Me.Panel5.TabIndex = 10
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightGray
        Me.Panel1.Location = New System.Drawing.Point(4, 201)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(617, 1)
        Me.Panel1.TabIndex = 22
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label25.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Blue
        Me.Label25.Location = New System.Drawing.Point(309, 213)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(183, 16)
        Me.Label25.TabIndex = 23
        Me.Label25.Text = "https://myaccount.google.com"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.DimGray
        Me.Label26.Location = New System.Drawing.Point(10, 263)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(303, 16)
        Me.Label26.TabIndex = 25
        Me.Label26.Text = "3). Enter Your GMAIL Account Password and Login"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.DimGray
        Me.Label27.Location = New System.Drawing.Point(10, 238)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(364, 16)
        Me.Label27.TabIndex = 24
        Me.Label27.Text = "2). Search for 'App Password' and go to App Password Option"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.DimGray
        Me.Label28.Location = New System.Drawing.Point(10, 213)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(293, 16)
        Me.Label28.TabIndex = 22
        Me.Label28.Text = "1). Open Google Account Settings in any browser"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label29
        '
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(10, 181)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(611, 16)
        Me.Label29.TabIndex = 18
        Me.Label29.Text = "Find Password"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.LightGray
        Me.Panel4.Location = New System.Drawing.Point(4, 176)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(617, 1)
        Me.Panel4.TabIndex = 1
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.Color.MistyRose
        Me.Label30.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label30.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.DarkRed
        Me.Label30.Location = New System.Drawing.Point(0, 0)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(628, 21)
        Me.Label30.TabIndex = 10
        Me.Label30.Text = "Email Setup"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.Maroon
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel7.Location = New System.Drawing.Point(0, 375)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(628, 3)
        Me.Panel7.TabIndex = 1
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 27)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(139, 139)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'Email_Login_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Linen
        Me.ClientSize = New System.Drawing.Size(821, 540)
        Me.Controls.Add(Me.Login_P)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Email_Login_frm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Login_P.ResumeLayout(False)
        Me.Login_P.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Email_TXT As Tools.TXT
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Pass_TXT As Tools.TXT
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents PORT_TXT As Tools.TXT
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents SMTP_TXT As Tools.TXT
    Friend WithEvents Label11 As Label
    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents Gateway_ As Tools.TXT
    Friend WithEvents Login_P As Panel
    Friend WithEvents Button2 As Button
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label25 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label30 As Label
    Friend WithEvents Panel7 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label12 As Label
End Class
