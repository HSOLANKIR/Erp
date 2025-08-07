<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Doctor_info_Laboratory
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Doctor_info_Laboratory))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Txt2 = New Tools.TXT()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Contect_Panel = New System.Windows.Forms.Panel()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.Phone_TXT = New Tools.TXT()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Email_TXT = New Tools.TXT()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Alias_TXT = New Tools.TXT()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Name_TXT = New Tools.TXT()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Contect_Panel.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.Contect_Panel)
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(355, 510)
        Me.Panel2.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.AutoSize = True
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.Txt2)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 114)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(353, 40)
        Me.Panel3.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.Label3.Location = New System.Drawing.Point(0, 1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(353, 17)
        Me.Label3.TabIndex = 87
        Me.Label3.Text = "Refrence Details"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 16)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Ref. %"
        '
        'Txt2
        '
        Me.Txt2.Auto_Cleane = True
        Me.Txt2.Back_color = System.Drawing.Color.White
        Me.Txt2.BackColor = System.Drawing.Color.White
        Me.Txt2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Txt2.Data_Link_ = ""
        Me.Txt2.Decimal_ = 2
        Me.Txt2.Font = New System.Drawing.Font("Arial", 11.0!)
        Me.Txt2.Font_Size = 11
        Me.Txt2.Font_Style = System.Drawing.FontStyle.Bold
        Me.Txt2.Format_ = "dd-MM-yyyy"
        Me.Txt2.Keydown_Support = True
        Me.Txt2.Location = New System.Drawing.Point(147, 20)
        Me.Txt2.Msg_Object = Nothing
        Me.Txt2.Name = "Txt2"
        Me.Txt2.Select_Auto_Show = True
        Me.Txt2.Select_Column_Color = "NA"
        Me.Txt2.Select_Columns = 0
        Me.Txt2.Select_Filter = Nothing
        Me.Txt2.Select_Hide_Columns = "NA"
        Me.Txt2.Select_Object = Nothing
        Me.Txt2.Select_Source = Nothing
        Me.Txt2.Size = New System.Drawing.Size(30, 17)
        Me.Txt2.TabIndex = 11
        Me.Txt2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Txt2.Type_ = "TXT"
        Me.Txt2.Val_max = 1000000000
        Me.Txt2.Val_min = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(134, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(12, 16)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = ":"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.DarkGray
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(353, 1)
        Me.Panel4.TabIndex = 83
        Me.Panel4.TabStop = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(179, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(18, 16)
        Me.Label6.TabIndex = 88
        Me.Label6.Text = "%"
        '
        'Contect_Panel
        '
        Me.Contect_Panel.AutoSize = True
        Me.Contect_Panel.Controls.Add(Me.Label54)
        Me.Contect_Panel.Controls.Add(Me.Phone_TXT)
        Me.Contect_Panel.Controls.Add(Me.Label9)
        Me.Contect_Panel.Controls.Add(Me.Email_TXT)
        Me.Contect_Panel.Controls.Add(Me.Label8)
        Me.Contect_Panel.Controls.Add(Me.Label11)
        Me.Contect_Panel.Controls.Add(Me.Label10)
        Me.Contect_Panel.Controls.Add(Me.Panel16)
        Me.Contect_Panel.Dock = System.Windows.Forms.DockStyle.Top
        Me.Contect_Panel.Location = New System.Drawing.Point(0, 56)
        Me.Contect_Panel.Name = "Contect_Panel"
        Me.Contect_Panel.Size = New System.Drawing.Size(353, 58)
        Me.Contect_Panel.TabIndex = 2
        '
        'Label54
        '
        Me.Label54.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label54.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.Label54.Location = New System.Drawing.Point(0, 1)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(353, 17)
        Me.Label54.TabIndex = 87
        Me.Label54.Text = "Contect Details"
        '
        'Phone_TXT
        '
        Me.Phone_TXT.Auto_Cleane = True
        Me.Phone_TXT.Back_color = System.Drawing.Color.White
        Me.Phone_TXT.BackColor = System.Drawing.Color.White
        Me.Phone_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Phone_TXT.Data_Link_ = ""
        Me.Phone_TXT.Decimal_ = 2
        Me.Phone_TXT.Font = New System.Drawing.Font("Arial", 11.0!)
        Me.Phone_TXT.Font_Size = 11
        Me.Phone_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Phone_TXT.Format_ = "dd-MM-yyyy"
        Me.Phone_TXT.Keydown_Support = True
        Me.Phone_TXT.Location = New System.Drawing.Point(147, 38)
        Me.Phone_TXT.Msg_Object = Nothing
        Me.Phone_TXT.Name = "Phone_TXT"
        Me.Phone_TXT.Select_Auto_Show = True
        Me.Phone_TXT.Select_Column_Color = "NA"
        Me.Phone_TXT.Select_Columns = 0
        Me.Phone_TXT.Select_Filter = Nothing
        Me.Phone_TXT.Select_Hide_Columns = "NA"
        Me.Phone_TXT.Select_Object = Nothing
        Me.Phone_TXT.Select_Source = Nothing
        Me.Phone_TXT.Size = New System.Drawing.Size(197, 17)
        Me.Phone_TXT.TabIndex = 14
        Me.Phone_TXT.Type_ = "TXT"
        Me.Phone_TXT.Val_max = 1000000000
        Me.Phone_TXT.Val_min = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(14, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(44, 16)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "Email"
        '
        'Email_TXT
        '
        Me.Email_TXT.Auto_Cleane = True
        Me.Email_TXT.Back_color = System.Drawing.Color.White
        Me.Email_TXT.BackColor = System.Drawing.Color.White
        Me.Email_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Email_TXT.Data_Link_ = ""
        Me.Email_TXT.Decimal_ = 2
        Me.Email_TXT.Font = New System.Drawing.Font("Arial", 11.0!)
        Me.Email_TXT.Font_Size = 11
        Me.Email_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Email_TXT.Format_ = "dd-MM-yyyy"
        Me.Email_TXT.Keydown_Support = True
        Me.Email_TXT.Location = New System.Drawing.Point(147, 20)
        Me.Email_TXT.Msg_Object = Nothing
        Me.Email_TXT.Name = "Email_TXT"
        Me.Email_TXT.Select_Auto_Show = True
        Me.Email_TXT.Select_Column_Color = "NA"
        Me.Email_TXT.Select_Columns = 0
        Me.Email_TXT.Select_Filter = Nothing
        Me.Email_TXT.Select_Hide_Columns = "NA"
        Me.Email_TXT.Select_Object = Nothing
        Me.Email_TXT.Select_Source = Nothing
        Me.Email_TXT.Size = New System.Drawing.Size(197, 17)
        Me.Email_TXT.TabIndex = 11
        Me.Email_TXT.Type_ = "TXT"
        Me.Email_TXT.Val_max = 1000000000
        Me.Email_TXT.Val_min = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(134, 20)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(12, 16)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = ":"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(14, 38)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(49, 16)
        Me.Label11.TabIndex = 13
        Me.Label11.Text = "Phone"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(134, 38)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(12, 16)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = ":"
        '
        'Panel16
        '
        Me.Panel16.BackColor = System.Drawing.Color.DarkGray
        Me.Panel16.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel16.Location = New System.Drawing.Point(0, 0)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(353, 1)
        Me.Panel16.TabIndex = 83
        Me.Panel16.TabStop = True
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.Controls.Add(Me.Label48)
        Me.Panel1.Controls.Add(Me.Alias_TXT)
        Me.Panel1.Controls.Add(Me.Label49)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Name_TXT)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.Panel1.Size = New System.Drawing.Size(353, 56)
        Me.Panel1.TabIndex = 0
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Location = New System.Drawing.Point(64, 26)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(12, 16)
        Me.Label48.TabIndex = 77
        Me.Label48.Text = ":"
        '
        'Alias_TXT
        '
        Me.Alias_TXT.Auto_Cleane = True
        Me.Alias_TXT.Back_color = System.Drawing.Color.White
        Me.Alias_TXT.BackColor = System.Drawing.Color.White
        Me.Alias_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Alias_TXT.Data_Link_ = ""
        Me.Alias_TXT.Decimal_ = 2
        Me.Alias_TXT.Font = New System.Drawing.Font("Arial", 11.0!)
        Me.Alias_TXT.Font_Size = 11
        Me.Alias_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Alias_TXT.Format_ = "dd-MM-yyyy"
        Me.Alias_TXT.Keydown_Support = True
        Me.Alias_TXT.Location = New System.Drawing.Point(78, 26)
        Me.Alias_TXT.Msg_Object = Nothing
        Me.Alias_TXT.Name = "Alias_TXT"
        Me.Alias_TXT.Select_Auto_Show = True
        Me.Alias_TXT.Select_Column_Color = "NA"
        Me.Alias_TXT.Select_Columns = 0
        Me.Alias_TXT.Select_Filter = Nothing
        Me.Alias_TXT.Select_Hide_Columns = "NA"
        Me.Alias_TXT.Select_Object = Nothing
        Me.Alias_TXT.Select_Source = Nothing
        Me.Alias_TXT.Size = New System.Drawing.Size(261, 17)
        Me.Alias_TXT.TabIndex = 73
        Me.Alias_TXT.Type_ = "TXT"
        Me.Alias_TXT.Val_max = 1000000000
        Me.Alias_TXT.Val_min = 0
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label49.Location = New System.Drawing.Point(6, 26)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(59, 16)
        Me.Label49.TabIndex = 76
        Me.Label49.Text = "Hospital"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(64, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 16)
        Me.Label2.TabIndex = 75
        Me.Label2.Text = ":"
        '
        'Name_TXT
        '
        Me.Name_TXT.Auto_Cleane = True
        Me.Name_TXT.Back_color = System.Drawing.Color.White
        Me.Name_TXT.BackColor = System.Drawing.Color.White
        Me.Name_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Name_TXT.Data_Link_ = ""
        Me.Name_TXT.Decimal_ = 2
        Me.Name_TXT.Font = New System.Drawing.Font("Arial", 11.0!)
        Me.Name_TXT.Font_Size = 11
        Me.Name_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Name_TXT.Format_ = "dd-MM-yyyy"
        Me.Name_TXT.Keydown_Support = True
        Me.Name_TXT.Location = New System.Drawing.Point(78, 8)
        Me.Name_TXT.Msg_Object = Nothing
        Me.Name_TXT.Name = "Name_TXT"
        Me.Name_TXT.Select_Auto_Show = True
        Me.Name_TXT.Select_Column_Color = "NA"
        Me.Name_TXT.Select_Columns = 0
        Me.Name_TXT.Select_Filter = Nothing
        Me.Name_TXT.Select_Hide_Columns = "NA"
        Me.Name_TXT.Select_Object = Nothing
        Me.Name_TXT.Select_Source = Nothing
        Me.Name_TXT.Size = New System.Drawing.Size(261, 17)
        Me.Name_TXT.TabIndex = 72
        Me.Name_TXT.Type_ = "TXT"
        Me.Name_TXT.Val_max = 1000000000
        Me.Name_TXT.Val_min = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 16)
        Me.Label1.TabIndex = 74
        Me.Label1.Text = "Name"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.BurlyWood
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.BurlyWood
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column9, Me.Column6, Me.Column7, Me.Column8})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(204, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(204, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridView1.EnableHeadersVisualStyles = False
        Me.DataGridView1.GridColor = System.Drawing.Color.DimGray
        Me.DataGridView1.Location = New System.Drawing.Point(609, 1)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(196, 354)
        Me.DataGridView1.TabIndex = 43
        Me.DataGridView1.Visible = False
        '
        'Column1
        '
        Me.Column1.HeaderText = "Doc.ID"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Visible = False
        '
        'Column2
        '
        Me.Column2.HeaderText = "Name"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 120
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column3.HeaderText = "Narration"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "Attage"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 80
        '
        'Column5
        '
        Me.Column5.HeaderText = "Data"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Visible = False
        '
        'Column9
        '
        Me.Column9.HeaderText = "Password"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Visible = False
        '
        'Column6
        '
        Me.Column6.HeaderText = ""
        Me.Column6.Image = CType(resources.GetObject("Column6.Image"), System.Drawing.Image)
        Me.Column6.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 37
        '
        'Column7
        '
        Me.Column7.HeaderText = ""
        Me.Column7.Image = CType(resources.GetObject("Column7.Image"), System.Drawing.Image)
        Me.Column7.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Width = 37
        '
        'Column8
        '
        Me.Column8.HeaderText = ""
        Me.Column8.Image = CType(resources.GetObject("Column8.Image"), System.Drawing.Image)
        Me.Column8.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Width = 37
        '
        'Label7
        '
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.Label7.Location = New System.Drawing.Point(355, 493)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(541, 17)
        Me.Label7.TabIndex = 88
        Me.Label7.Text = "|"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Doctor_info_Laboratory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Beige
        Me.ClientSize = New System.Drawing.Size(896, 510)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Doctor_info_Laboratory"
        Me.Text = "Doctor_info_Laboratory"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Contect_Panel.ResumeLayout(False)
        Me.Contect_Panel.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label48 As Label
    Friend WithEvents Alias_TXT As Tools.TXT
    Friend WithEvents Label49 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Name_TXT As Tools.TXT
    Friend WithEvents Label1 As Label
    Friend WithEvents Contect_Panel As Panel
    Friend WithEvents Label54 As Label
    Friend WithEvents Phone_TXT As Tools.TXT
    Friend WithEvents Label9 As Label
    Friend WithEvents Email_TXT As Tools.TXT
    Friend WithEvents Label8 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Panel16 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Txt2 As Tools.TXT
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewImageColumn
    Friend WithEvents Column7 As DataGridViewImageColumn
    Friend WithEvents Column8 As DataGridViewImageColumn
    Friend WithEvents Label7 As Label
End Class
