<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Payroll_Atten_Production_Type_frm
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Type_TXT = New Tools.TXT()
        Me.Type_source = New System.Windows.Forms.BindingSource(Me.components)
        Me.TAB_txt = New Tools.TXT()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Unit_TXT = New Tools.TXT()
        Me.Unit_Source = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Alias_TXT = New Tools.TXT()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Name_TXT = New Tools.TXT()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.Type_source, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Unit_Source, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.Panel6)
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(377, 705)
        Me.Panel2.TabIndex = 6
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.Type_TXT)
        Me.Panel3.Controls.Add(Me.TAB_txt)
        Me.Panel3.Controls.Add(Me.Label13)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.Unit_TXT)
        Me.Panel3.Controls.Add(Me.Label12)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.Panel5)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 79)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(376, 626)
        Me.Panel3.TabIndex = 1
        '
        'Type_TXT
        '
        Me.Type_TXT.Auto_Cleane = True
        Me.Type_TXT.Back_color = System.Drawing.Color.White
        Me.Type_TXT.BackColor = System.Drawing.Color.White
        Me.Type_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Type_TXT.Data_Link_ = ""
        Me.Type_TXT.Decimal_ = 2
        Me.Type_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Type_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Type_TXT.Font_Size = 10
        Me.Type_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Type_TXT.Format_ = "dd-MM-yyyy"
        Me.Type_TXT.Keydown_Support = True
        Me.Type_TXT.Location = New System.Drawing.Point(152, 12)
        Me.Type_TXT.Msg_Object = Nothing
        Me.Type_TXT.Name = "Type_TXT"
        Me.Type_TXT.Select_Auto_Show = True
        Me.Type_TXT.Select_Column_Color = "NA"
        Me.Type_TXT.Select_Columns = 0
        Me.Type_TXT.Select_Filter = "Name LIKE '%<value>%'"
        Me.Type_TXT.Select_Hide_Columns = "NA"
        Me.Type_TXT.Select_Object = Nothing
        Me.Type_TXT.Select_Source = Me.Type_source
        Me.Type_TXT.Size = New System.Drawing.Size(200, 15)
        Me.Type_TXT.TabIndex = 0
        Me.Type_TXT.Type_ = "Select"
        Me.Type_TXT.Val_max = 1000000000
        Me.Type_TXT.Val_min = 0
        '
        'TAB_txt
        '
        Me.TAB_txt.Auto_Cleane = True
        Me.TAB_txt.Back_color = System.Drawing.Color.White
        Me.TAB_txt.BackColor = System.Drawing.Color.White
        Me.TAB_txt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TAB_txt.Data_Link_ = ""
        Me.TAB_txt.Decimal_ = 2
        Me.TAB_txt.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.TAB_txt.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TAB_txt.Font_Size = 11
        Me.TAB_txt.Font_Style = System.Drawing.FontStyle.Bold
        Me.TAB_txt.Format_ = "dd-MM-yyyy"
        Me.TAB_txt.Keydown_Support = True
        Me.TAB_txt.Location = New System.Drawing.Point(45, 167)
        Me.TAB_txt.Msg_Object = Nothing
        Me.TAB_txt.Name = "TAB_txt"
        Me.TAB_txt.Select_Auto_Show = True
        Me.TAB_txt.Select_Column_Color = "NA"
        Me.TAB_txt.Select_Columns = 0
        Me.TAB_txt.Select_Filter = Nothing
        Me.TAB_txt.Select_Hide_Columns = "NA"
        Me.TAB_txt.Select_Object = Nothing
        Me.TAB_txt.Select_Source = Nothing
        Me.TAB_txt.Size = New System.Drawing.Size(0, 17)
        Me.TAB_txt.TabIndex = 4300
        Me.TAB_txt.Type_ = "TXT"
        Me.TAB_txt.Val_max = 1000000000
        Me.TAB_txt.Val_min = 0
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(152, 69)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(208, 16)
        Me.Label13.TabIndex = 42
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(141, 51)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(11, 16)
        Me.Label10.TabIndex = 41
        Me.Label10.Text = ":"
        Me.Label10.Visible = False
        '
        'Unit_TXT
        '
        Me.Unit_TXT.Auto_Cleane = True
        Me.Unit_TXT.Back_color = System.Drawing.Color.White
        Me.Unit_TXT.BackColor = System.Drawing.Color.White
        Me.Unit_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Unit_TXT.Data_Link_ = ""
        Me.Unit_TXT.Decimal_ = 2
        Me.Unit_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Unit_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Unit_TXT.Font_Size = 10
        Me.Unit_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Unit_TXT.Format_ = "dd-MM-yyyy"
        Me.Unit_TXT.Keydown_Support = True
        Me.Unit_TXT.Location = New System.Drawing.Point(152, 51)
        Me.Unit_TXT.Msg_Object = Nothing
        Me.Unit_TXT.Name = "Unit_TXT"
        Me.Unit_TXT.Select_Auto_Show = True
        Me.Unit_TXT.Select_Column_Color = "NA"
        Me.Unit_TXT.Select_Columns = 0
        Me.Unit_TXT.Select_Filter = "Name LIKE '%<value>%'"
        Me.Unit_TXT.Select_Hide_Columns = ""
        Me.Unit_TXT.Select_Object = Nothing
        Me.Unit_TXT.Select_Source = Me.Unit_Source
        Me.Unit_TXT.Size = New System.Drawing.Size(200, 15)
        Me.Unit_TXT.TabIndex = 1
        Me.Unit_TXT.Type_ = "Select"
        Me.Unit_TXT.Val_max = 1000000000
        Me.Unit_TXT.Val_min = 0
        Me.Unit_TXT.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(7, 51)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(30, 16)
        Me.Label12.TabIndex = 40
        Me.Label12.Text = "Unit"
        Me.Label12.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(152, 32)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(30, 16)
        Me.Label9.TabIndex = 38
        Me.Label9.Text = "Day"
        Me.Label9.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(141, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(11, 16)
        Me.Label5.TabIndex = 37
        Me.Label5.Text = ":"
        Me.Label5.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 32)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 16)
        Me.Label8.TabIndex = 36
        Me.Label8.Text = "Period"
        Me.Label8.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(141, 11)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(11, 16)
        Me.Label6.TabIndex = 35
        Me.Label6.Text = ":"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 11)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 16)
        Me.Label7.TabIndex = 34
        Me.Label7.Text = "Attendance Type"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.DarkGray
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel5.Location = New System.Drawing.Point(0, 625)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(376, 1)
        Me.Panel5.TabIndex = 30
        Me.Panel5.TabStop = True
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.Label48)
        Me.Panel6.Controls.Add(Me.Alias_TXT)
        Me.Panel6.Controls.Add(Me.Label49)
        Me.Panel6.Controls.Add(Me.Label2)
        Me.Panel6.Controls.Add(Me.Name_TXT)
        Me.Panel6.Controls.Add(Me.Label1)
        Me.Panel6.Controls.Add(Me.Panel10)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(376, 79)
        Me.Panel6.TabIndex = 0
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Location = New System.Drawing.Point(74, 24)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(11, 16)
        Me.Label48.TabIndex = 71
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
        Me.Alias_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Alias_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Alias_TXT.Font_Size = 10
        Me.Alias_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Alias_TXT.Format_ = "dd-MM-yyyy"
        Me.Alias_TXT.Keydown_Support = True
        Me.Alias_TXT.Location = New System.Drawing.Point(86, 24)
        Me.Alias_TXT.Msg_Object = Nothing
        Me.Alias_TXT.Name = "Alias_TXT"
        Me.Alias_TXT.Select_Auto_Show = True
        Me.Alias_TXT.Select_Column_Color = "NA"
        Me.Alias_TXT.Select_Columns = 0
        Me.Alias_TXT.Select_Filter = Nothing
        Me.Alias_TXT.Select_Hide_Columns = "NA"
        Me.Alias_TXT.Select_Object = Nothing
        Me.Alias_TXT.Select_Source = Nothing
        Me.Alias_TXT.Size = New System.Drawing.Size(138, 15)
        Me.Alias_TXT.TabIndex = 1
        Me.Alias_TXT.Type_ = "TXT"
        Me.Alias_TXT.Val_max = 1000000000
        Me.Alias_TXT.Val_min = 0
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.Location = New System.Drawing.Point(7, 24)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(48, 17)
        Me.Label49.TabIndex = 69
        Me.Label49.Text = "(alias)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(74, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 16)
        Me.Label2.TabIndex = 3
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
        Me.Name_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Name_TXT.Font_Size = 10
        Me.Name_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Name_TXT.Format_ = "dd-MM-yyyy"
        Me.Name_TXT.Keydown_Support = True
        Me.Name_TXT.Location = New System.Drawing.Point(86, 6)
        Me.Name_TXT.Msg_Object = Nothing
        Me.Name_TXT.Name = "Name_TXT"
        Me.Name_TXT.Select_Auto_Show = True
        Me.Name_TXT.Select_Column_Color = "NA"
        Me.Name_TXT.Select_Columns = 0
        Me.Name_TXT.Select_Filter = Nothing
        Me.Name_TXT.Select_Hide_Columns = "NA"
        Me.Name_TXT.Select_Object = Nothing
        Me.Name_TXT.Select_Source = Nothing
        Me.Name_TXT.Size = New System.Drawing.Size(223, 15)
        Me.Name_TXT.TabIndex = 0
        Me.Name_TXT.Type_ = "TXT"
        Me.Name_TXT.Val_max = 1000000000
        Me.Name_TXT.Val_min = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Name"
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.DarkGray
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel10.Location = New System.Drawing.Point(0, 78)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(376, 1)
        Me.Panel10.TabIndex = 30
        Me.Panel10.TabStop = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gray
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(376, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1, 705)
        Me.Panel1.TabIndex = 4302
        '
        'Payroll_Atten_Production_Type_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1194, 705)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Payroll_Atten_Production_Type_frm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Payroll_Atten_Production_Type_frm"
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.Type_source, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Unit_Source, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label10 As Label
    Friend WithEvents Unit_TXT As Tools.TXT
    Friend WithEvents Label12 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label48 As Label
    Friend WithEvents Alias_TXT As Tools.TXT
    Friend WithEvents Label49 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Name_TXT As Tools.TXT
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel10 As Panel
    Friend WithEvents Label13 As Label
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents Type_source As BindingSource
    Friend WithEvents TAB_txt As Tools.TXT
    Friend WithEvents Type_TXT As Tools.TXT
    Friend WithEvents Unit_Source As BindingSource
    Friend WithEvents Panel1 As Panel
End Class
