<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Database_verification_frm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Database_verification_frm))
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Verification_TXT = New Tools.TXT()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Chack_BackgroundWorker = New System.ComponentModel.BackgroundWorker()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.PictureBox13 = New System.Windows.Forms.PictureBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel10.SuspendLayout()
        CType(Me.PictureBox13, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(95, 348)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(242, 18)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Verification Code is mismatch"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label8.Visible = False
        '
        'Verification_TXT
        '
        Me.Verification_TXT.Auto_Cleane = True
        Me.Verification_TXT.Back_color = System.Drawing.Color.White
        Me.Verification_TXT.BackColor = System.Drawing.Color.White
        Me.Verification_TXT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Verification_TXT.Data_Link_ = ""
        Me.Verification_TXT.Decimal_ = 2
        Me.Verification_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Verification_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Verification_TXT.Font_Size = 10
        Me.Verification_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Verification_TXT.Format_ = "dd-MM-yyyy"
        Me.Verification_TXT.Keydown_Support = True
        Me.Verification_TXT.Location = New System.Drawing.Point(134, 323)
        Me.Verification_TXT.Msg_Object = Nothing
        Me.Verification_TXT.Name = "Verification_TXT"
        Me.Verification_TXT.Select_Auto_Show = True
        Me.Verification_TXT.Select_Column_Color = "NA"
        Me.Verification_TXT.Select_Columns = 0
        Me.Verification_TXT.Select_Filter = Nothing
        Me.Verification_TXT.Select_Hide_Columns = "NA"
        Me.Verification_TXT.Select_Object = Nothing
        Me.Verification_TXT.Select_Source = Nothing
        Me.Verification_TXT.Size = New System.Drawing.Size(164, 22)
        Me.Verification_TXT.TabIndex = 3
        Me.Verification_TXT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Verification_TXT.Type_ = "TXT"
        Me.Verification_TXT.Val_max = 1000000000
        Me.Verification_TXT.Val_min = 0
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DimGray
        Me.Label6.Location = New System.Drawing.Point(6, 275)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(421, 36)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "To repair the database a security code will have to be entered, which will have t" &
    "o be obtained from the software developer."
        '
        'Label7
        '
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(6, 255)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(312, 18)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "How to Repair Data"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(6, 185)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(407, 18)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Important Note"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkRed
        Me.Label3.Location = New System.Drawing.Point(6, 205)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(421, 38)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Since the database has been tampered with, the company will no longer be responsi" &
    "ble for the database."
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Image = Global.Management.My.Resources.Resources.error_gif
        Me.PictureBox1.Location = New System.Drawing.Point(0, 74)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(430, 106)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox2.Image = Global.Management.My.Resources.Resources.Loding_Progress
        Me.PictureBox2.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(200, 60)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 2
        Me.PictureBox2.TabStop = False
        '
        'Chack_BackgroundWorker
        '
        Me.Chack_BackgroundWorker.WorkerReportsProgress = True
        Me.Chack_BackgroundWorker.WorkerSupportsCancellation = True
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Label9)
        Me.Panel4.Controls.Add(Me.PictureBox2)
        Me.Panel4.Location = New System.Drawing.Point(1063, 454)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(200, 87)
        Me.Panel4.TabIndex = 3
        '
        'Label9
        '
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(0, 60)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(200, 18)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "Please wait..."
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Controls.Add(Me.Panel10)
        Me.Panel1.Controls.Add(Me.Panel6)
        Me.Panel1.Location = New System.Drawing.Point(39, 77)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(734, 395)
        Me.Panel1.TabIndex = 14
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.PictureBox1)
        Me.Panel5.Controls.Add(Me.Label8)
        Me.Panel5.Controls.Add(Me.Label12)
        Me.Panel5.Controls.Add(Me.Verification_TXT)
        Me.Panel5.Controls.Add(Me.Label13)
        Me.Panel5.Controls.Add(Me.Label6)
        Me.Panel5.Controls.Add(Me.Label7)
        Me.Panel5.Controls.Add(Me.Label5)
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(302, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(430, 390)
        Me.Panel5.TabIndex = 105
        '
        'Label13
        '
        Me.Label13.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label13.Font = New System.Drawing.Font("Arial Black", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Red
        Me.Label13.Location = New System.Drawing.Point(0, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(430, 29)
        Me.Label13.TabIndex = 98
        Me.Label13.Text = "Database Tampering Detected"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.PictureBox13)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel10.Location = New System.Drawing.Point(0, 0)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(302, 390)
        Me.Panel10.TabIndex = 99
        '
        'PictureBox13
        '
        Me.PictureBox13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox13.Image = CType(resources.GetObject("PictureBox13.Image"), System.Drawing.Image)
        Me.PictureBox13.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox13.Name = "PictureBox13"
        Me.PictureBox13.Size = New System.Drawing.Size(302, 390)
        Me.PictureBox13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox13.TabIndex = 1
        Me.PictureBox13.TabStop = False
        '
        'Label12
        '
        Me.Label12.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.DimGray
        Me.Label12.Location = New System.Drawing.Point(0, 29)
        Me.Label12.Name = "Label12"
        Me.Label12.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.Label12.Size = New System.Drawing.Size(430, 45)
        Me.Label12.TabIndex = 97
        Me.Label12.Text = "The database is configured according to our method, changes are visible within it" &
    ". Sorry, that's why you can't log in."
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Red
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel6.Location = New System.Drawing.Point(0, 390)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(732, 3)
        Me.Panel6.TabIndex = 106
        '
        'Database_verification_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Cornsilk
        Me.ClientSize = New System.Drawing.Size(1364, 705)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel4)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Database_verification_frm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Database_verification_frm"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel10.ResumeLayout(False)
        CType(Me.PictureBox13, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Verification_TXT As Tools.TXT
    Friend WithEvents Chack_BackgroundWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents Label8 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label9 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label13 As Label
    Friend WithEvents Panel10 As Panel
    Friend WithEvents PictureBox13 As PictureBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Panel6 As Panel
End Class
