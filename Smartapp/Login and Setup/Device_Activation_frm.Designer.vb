Imports Tools

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Device_Activation_frm
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
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBox2 = New Tools.TXT()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TextBox1 = New Tools.TXT()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Serial_Panel = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Serial_TXT = New Tools.TXT()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.cmp_details_Panel = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Device_Panel = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Load_Panel = New System.Windows.Forms.Panel()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Txt1 = New Tools.TXT()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Serial_Panel.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmp_details_Panel.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Device_Panel.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Load_Panel.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.LightSalmon
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(454, 250)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(87, 28)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "BACK"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(235, 228)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(407, 18)
        Me.Label9.TabIndex = 15
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Turquoise
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(555, 250)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(87, 28)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "NEXT"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(235, 208)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(407, 18)
        Me.Label10.TabIndex = 14
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(235, 187)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(407, 18)
        Me.Label11.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(117, 228)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 16)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Class"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(117, 208)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 16)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Company Serial"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(117, 187)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 16)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Company Name"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(219, 228)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(15, 16)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = " :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(219, 208)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(15, 16)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = " :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(219, 187)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(15, 16)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = " :"
        '
        'TextBox2
        '
        Me.TextBox2.Auto_Cleane = True
        Me.TextBox2.Back_color = System.Drawing.Color.White
        Me.TextBox2.BackColor = System.Drawing.Color.White
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox2.Data_Link_ = ""
        Me.TextBox2.Decimal_ = 2
        Me.TextBox2.Font = New System.Drawing.Font("Arial", 11.0!)
        Me.TextBox2.Font_Size = 11
        Me.TextBox2.Font_Style = System.Drawing.FontStyle.Bold
        Me.TextBox2.Format_ = "dd-MM-yyyy"
        Me.TextBox2.Keydown_Support = True
        Me.TextBox2.Location = New System.Drawing.Point(238, 54)
        Me.TextBox2.Msg_Object = Nothing
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Select_Auto_Show = True
        Me.TextBox2.Select_Column_Color = "NA"
        Me.TextBox2.Select_Columns = 0
        Me.TextBox2.Select_Filter = Nothing
        Me.TextBox2.Select_Hide_Columns = "NA"
        Me.TextBox2.Select_Object = Nothing
        Me.TextBox2.Select_Source = Nothing
        Me.TextBox2.Size = New System.Drawing.Size(200, 67)
        Me.TextBox2.TabIndex = 14
        Me.TextBox2.Type_ = "TXT"
        Me.TextBox2.Val_max = 1000000000
        Me.TextBox2.Val_min = 0
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(218, 54)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(15, 16)
        Me.Label13.TabIndex = 13
        Me.Label13.Text = " :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(116, 54)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(72, 16)
        Me.Label12.TabIndex = 12
        Me.Label12.Text = "Description"
        '
        'TextBox1
        '
        Me.TextBox1.Auto_Cleane = True
        Me.TextBox1.Back_color = System.Drawing.Color.White
        Me.TextBox1.BackColor = System.Drawing.Color.White
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Data_Link_ = ""
        Me.TextBox1.Decimal_ = 2
        Me.TextBox1.Font = New System.Drawing.Font("Arial", 11.0!)
        Me.TextBox1.Font_Size = 11
        Me.TextBox1.Font_Style = System.Drawing.FontStyle.Bold
        Me.TextBox1.Format_ = "dd-MM-yyyy"
        Me.TextBox1.Keydown_Support = True
        Me.TextBox1.Location = New System.Drawing.Point(238, 33)
        Me.TextBox1.Msg_Object = Nothing
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Select_Auto_Show = True
        Me.TextBox1.Select_Column_Color = "NA"
        Me.TextBox1.Select_Columns = 0
        Me.TextBox1.Select_Filter = Nothing
        Me.TextBox1.Select_Hide_Columns = "NA"
        Me.TextBox1.Select_Object = Nothing
        Me.TextBox1.Select_Source = Nothing
        Me.TextBox1.Size = New System.Drawing.Size(200, 17)
        Me.TextBox1.TabIndex = 11
        Me.TextBox1.Type_ = "TXT"
        Me.TextBox1.Val_max = 1000000000
        Me.TextBox1.Val_min = 0
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.LightSalmon
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(245, 136)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(68, 28)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "BACK"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Turquoise
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Location = New System.Drawing.Point(319, 136)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(123, 28)
        Me.Button4.TabIndex = 3
        Me.Button4.Text = "SEND REQUEST"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(116, 33)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(83, 16)
        Me.Label17.TabIndex = 6
        Me.Label17.Text = "Device Name"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(218, 33)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(15, 16)
        Me.Label21.TabIndex = 10
        Me.Label21.Text = " :"
        '
        'Serial_Panel
        '
        Me.Serial_Panel.BackColor = System.Drawing.Color.White
        Me.Serial_Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Serial_Panel.Controls.Add(Me.Label2)
        Me.Serial_Panel.Controls.Add(Me.Panel2)
        Me.Serial_Panel.Controls.Add(Me.Serial_TXT)
        Me.Serial_Panel.Controls.Add(Me.PictureBox5)
        Me.Serial_Panel.Controls.Add(Me.Label22)
        Me.Serial_Panel.Location = New System.Drawing.Point(12, 171)
        Me.Serial_Panel.Name = "Serial_Panel"
        Me.Serial_Panel.Size = New System.Drawing.Size(362, 216)
        Me.Serial_Panel.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(21, 188)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(319, 21)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Enter Company Serial Number and Enter Key Press"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DimGray
        Me.Panel2.Location = New System.Drawing.Point(21, 184)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(319, 1)
        Me.Panel2.TabIndex = 13
        '
        'Serial_TXT
        '
        Me.Serial_TXT.Auto_Cleane = True
        Me.Serial_TXT.Back_color = System.Drawing.Color.White
        Me.Serial_TXT.BackColor = System.Drawing.Color.White
        Me.Serial_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Serial_TXT.Data_Link_ = ""
        Me.Serial_TXT.Decimal_ = 2
        Me.Serial_TXT.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Serial_TXT.Font_Size = 10
        Me.Serial_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Serial_TXT.Format_ = "dd-MM-yyyy"
        Me.Serial_TXT.Keydown_Support = True
        Me.Serial_TXT.Location = New System.Drawing.Point(6, 160)
        Me.Serial_TXT.Msg_Object = Nothing
        Me.Serial_TXT.Name = "Serial_TXT"
        Me.Serial_TXT.Select_Auto_Show = True
        Me.Serial_TXT.Select_Column_Color = "NA"
        Me.Serial_TXT.Select_Columns = 0
        Me.Serial_TXT.Select_Filter = Nothing
        Me.Serial_TXT.Select_Hide_Columns = "NA"
        Me.Serial_TXT.Select_Object = Nothing
        Me.Serial_TXT.Select_Source = Nothing
        Me.Serial_TXT.Size = New System.Drawing.Size(349, 19)
        Me.Serial_TXT.TabIndex = 13
        Me.Serial_TXT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Serial_TXT.Type_ = "TXT"
        Me.Serial_TXT.Val_max = 1000000000
        Me.Serial_TXT.Val_min = 0
        '
        'PictureBox5
        '
        Me.PictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox5.Image = Global.Management.My.Resources.Resources.tikit_animation_icn
        Me.PictureBox5.Location = New System.Drawing.Point(6, 25)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(349, 131)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox5.TabIndex = 11
        Me.PictureBox5.TabStop = False
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Linen
        Me.Label22.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label22.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(0, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(360, 21)
        Me.Label22.TabIndex = 10
        Me.Label22.Text = "Company Serial"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmp_details_Panel
        '
        Me.cmp_details_Panel.BackColor = System.Drawing.Color.White
        Me.cmp_details_Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cmp_details_Panel.Controls.Add(Me.Panel4)
        Me.cmp_details_Panel.Controls.Add(Me.Label15)
        Me.cmp_details_Panel.Controls.Add(Me.Panel3)
        Me.cmp_details_Panel.Controls.Add(Me.PictureBox3)
        Me.cmp_details_Panel.Controls.Add(Me.Button2)
        Me.cmp_details_Panel.Controls.Add(Me.PictureBox1)
        Me.cmp_details_Panel.Controls.Add(Me.Button1)
        Me.cmp_details_Panel.Controls.Add(Me.Label9)
        Me.cmp_details_Panel.Controls.Add(Me.Label1)
        Me.cmp_details_Panel.Controls.Add(Me.Label11)
        Me.cmp_details_Panel.Controls.Add(Me.Label10)
        Me.cmp_details_Panel.Controls.Add(Me.Label8)
        Me.cmp_details_Panel.Controls.Add(Me.Label7)
        Me.cmp_details_Panel.Controls.Add(Me.Label6)
        Me.cmp_details_Panel.Controls.Add(Me.Label4)
        Me.cmp_details_Panel.Controls.Add(Me.Label5)
        Me.cmp_details_Panel.Controls.Add(Me.Label3)
        Me.cmp_details_Panel.Location = New System.Drawing.Point(402, 360)
        Me.cmp_details_Panel.Name = "cmp_details_Panel"
        Me.cmp_details_Panel.Size = New System.Drawing.Size(649, 312)
        Me.cmp_details_Panel.TabIndex = 11
        Me.cmp_details_Panel.Visible = False
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.DimGray
        Me.Panel4.Location = New System.Drawing.Point(4, 173)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(639, 1)
        Me.Panel4.TabIndex = 19
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Blue
        Me.Label15.Location = New System.Drawing.Point(3, 288)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(641, 19)
        Me.Label15.TabIndex = 17
        Me.Label15.Text = "Confirm your Company details and Continue"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.DimGray
        Me.Panel3.Location = New System.Drawing.Point(3, 284)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(641, 1)
        Me.Panel3.TabIndex = 18
        '
        'PictureBox3
        '
        Me.PictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox3.Location = New System.Drawing.Point(3, 179)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(105, 100)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 16
        Me.PictureBox3.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Image = Global.Management.My.Resources.Resources.Info_animation_icn
        Me.PictureBox1.Location = New System.Drawing.Point(3, 25)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(641, 149)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 11
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Linen
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(647, 21)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Company Details"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Device_Panel
        '
        Me.Device_Panel.BackColor = System.Drawing.Color.White
        Me.Device_Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Device_Panel.Controls.Add(Me.Panel1)
        Me.Device_Panel.Controls.Add(Me.Button3)
        Me.Device_Panel.Controls.Add(Me.TextBox2)
        Me.Device_Panel.Controls.Add(Me.Button4)
        Me.Device_Panel.Controls.Add(Me.PictureBox2)
        Me.Device_Panel.Controls.Add(Me.Label13)
        Me.Device_Panel.Controls.Add(Me.Label14)
        Me.Device_Panel.Controls.Add(Me.Label12)
        Me.Device_Panel.Controls.Add(Me.Label17)
        Me.Device_Panel.Controls.Add(Me.TextBox1)
        Me.Device_Panel.Controls.Add(Me.Label21)
        Me.Device_Panel.Location = New System.Drawing.Point(880, 36)
        Me.Device_Panel.Name = "Device_Panel"
        Me.Device_Panel.Size = New System.Drawing.Size(447, 170)
        Me.Device_Panel.TabIndex = 12
        Me.Device_Panel.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkGray
        Me.Panel1.Location = New System.Drawing.Point(3, 131)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(439, 1)
        Me.Panel1.TabIndex = 13
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox2.Image = Global.Management.My.Resources.Resources.device_animation_icn
        Me.PictureBox2.Location = New System.Drawing.Point(3, 25)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(105, 100)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 11
        Me.PictureBox2.TabStop = False
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Linen
        Me.Label14.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(0, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(445, 21)
        Me.Label14.TabIndex = 10
        Me.Label14.Text = "Device Details"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'Load_Panel
        '
        Me.Load_Panel.BackColor = System.Drawing.Color.White
        Me.Load_Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Load_Panel.Controls.Add(Me.PictureBox4)
        Me.Load_Panel.Controls.Add(Me.Label16)
        Me.Load_Panel.Controls.Add(Me.Txt1)
        Me.Load_Panel.Location = New System.Drawing.Point(473, 112)
        Me.Load_Panel.Name = "Load_Panel"
        Me.Load_Panel.Size = New System.Drawing.Size(362, 216)
        Me.Load_Panel.TabIndex = 13
        Me.Load_Panel.Visible = False
        '
        'PictureBox4
        '
        Me.PictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox4.Image = Global.Management.My.Resources.Resources.Server_connection_animation_gof
        Me.PictureBox4.Location = New System.Drawing.Point(6, 25)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(349, 183)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox4.TabIndex = 11
        Me.PictureBox4.TabStop = False
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Linen
        Me.Label16.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(0, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(360, 21)
        Me.Label16.TabIndex = 10
        Me.Label16.Text = "Load Server"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Txt1
        '
        Me.Txt1.Auto_Cleane = True
        Me.Txt1.Back_color = System.Drawing.Color.White
        Me.Txt1.BackColor = System.Drawing.Color.White
        Me.Txt1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Txt1.Data_Link_ = ""
        Me.Txt1.Decimal_ = 2
        Me.Txt1.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Txt1.Font_Size = 10
        Me.Txt1.Font_Style = System.Drawing.FontStyle.Bold
        Me.Txt1.Format_ = "dd-MM-yyyy"
        Me.Txt1.Keydown_Support = True
        Me.Txt1.Location = New System.Drawing.Point(27, 187)
        Me.Txt1.Msg_Object = Nothing
        Me.Txt1.Name = "Txt1"
        Me.Txt1.ReadOnly = True
        Me.Txt1.Select_Auto_Show = True
        Me.Txt1.Select_Column_Color = "NA"
        Me.Txt1.Select_Columns = 0
        Me.Txt1.Select_Filter = Nothing
        Me.Txt1.Select_Hide_Columns = "NA"
        Me.Txt1.Select_Object = Nothing
        Me.Txt1.Select_Source = Nothing
        Me.Txt1.Size = New System.Drawing.Size(10, 16)
        Me.Txt1.TabIndex = 14
        Me.Txt1.Type_ = "TXT"
        Me.Txt1.Val_max = 1000000000
        Me.Txt1.Val_min = 0
        '
        'Device_Activation_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1364, 705)
        Me.Controls.Add(Me.Load_Panel)
        Me.Controls.Add(Me.Device_Panel)
        Me.Controls.Add(Me.cmp_details_Panel)
        Me.Controls.Add(Me.Serial_Panel)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Device_Activation_frm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Device_Activation_frm"
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Serial_Panel.ResumeLayout(False)
        Me.Serial_Panel.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmp_details_Panel.ResumeLayout(False)
        Me.cmp_details_Panel.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Device_Panel.ResumeLayout(False)
        Me.Device_Panel.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Load_Panel.ResumeLayout(False)
        Me.Load_Panel.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents Button2 As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents TextBox2 As Tools.TXT
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents TextBox1 As Tools.TXT
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Label17 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Serial_Panel As Panel
    Friend WithEvents Label22 As Label
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents cmp_details_Panel As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Device_Panel As Panel
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Serial_TXT As TXT
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Load_Panel As Panel
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Txt1 As TXT
    Friend WithEvents Label15 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
End Class
