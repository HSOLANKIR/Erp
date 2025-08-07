<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Payroll_Auto_Fill_Dialoag
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Attendance_Panel = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.vlu_TXT = New Tools.TXT()
        Me.Atendance_Select = New Tools.TXT()
        Me.Filter_TXT = New Tools.TXT()
        Me.Type_TXT = New Tools.TXT()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Type_Source = New System.Windows.Forms.BindingSource(Me.components)
        Me.Filter_Source = New System.Windows.Forms.BindingSource(Me.components)
        Me.Attendance_Source = New System.Windows.Forms.BindingSource(Me.components)
        Me.Payroll_Panel = New System.Windows.Forms.Panel()
        Me.To_date = New Tools.TXT()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Txt2 = New Tools.TXT()
        Me.frm_date = New Tools.TXT()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Employee_Group_Source = New System.Windows.Forms.BindingSource(Me.components)
        Me.Attendance_Panel.SuspendLayout()
        CType(Me.Type_Source, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Filter_Source, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Attendance_Source, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Payroll_Panel.SuspendLayout()
        CType(Me.Employee_Group_Source, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Attendance_Panel
        '
        Me.Attendance_Panel.AutoSize = True
        Me.Attendance_Panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Attendance_Panel.BackColor = System.Drawing.Color.White
        Me.Attendance_Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Attendance_Panel.Controls.Add(Me.Button1)
        Me.Attendance_Panel.Controls.Add(Me.vlu_TXT)
        Me.Attendance_Panel.Controls.Add(Me.Atendance_Select)
        Me.Attendance_Panel.Controls.Add(Me.Filter_TXT)
        Me.Attendance_Panel.Controls.Add(Me.Type_TXT)
        Me.Attendance_Panel.Controls.Add(Me.Label14)
        Me.Attendance_Panel.Controls.Add(Me.Label16)
        Me.Attendance_Panel.Controls.Add(Me.Label6)
        Me.Attendance_Panel.Controls.Add(Me.Label7)
        Me.Attendance_Panel.Controls.Add(Me.Label5)
        Me.Attendance_Panel.Controls.Add(Me.Label4)
        Me.Attendance_Panel.Controls.Add(Me.Label3)
        Me.Attendance_Panel.Controls.Add(Me.Label2)
        Me.Attendance_Panel.Controls.Add(Me.Label1)
        Me.Attendance_Panel.Location = New System.Drawing.Point(47, 39)
        Me.Attendance_Panel.Name = "Attendance_Panel"
        Me.Attendance_Panel.Size = New System.Drawing.Size(436, 196)
        Me.Attendance_Panel.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.PaleTurquoise
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(339, 159)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(92, 32)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Apply"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'vlu_TXT
        '
        Me.vlu_TXT.Auto_Cleane = True
        Me.vlu_TXT.Back_color = System.Drawing.Color.White
        Me.vlu_TXT.BackColor = System.Drawing.Color.White
        Me.vlu_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.vlu_TXT.Data_Link_ = ""
        Me.vlu_TXT.Decimal_ = 2
        Me.vlu_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vlu_TXT.Font_Size = 10
        Me.vlu_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.vlu_TXT.Format_ = "dd-MM-yyyy"
        Me.vlu_TXT.Keydown_Support = True
        Me.vlu_TXT.Location = New System.Drawing.Point(200, 133)
        Me.vlu_TXT.Msg_Object = Nothing
        Me.vlu_TXT.Name = "vlu_TXT"
        Me.vlu_TXT.Select_Auto_Show = True
        Me.vlu_TXT.Select_Column_Color = "6"
        Me.vlu_TXT.Select_Columns = 0
        Me.vlu_TXT.Select_Filter = Nothing
        Me.vlu_TXT.Select_Hide_Columns = ""
        Me.vlu_TXT.Select_Object = Nothing
        Me.vlu_TXT.Select_Source = Nothing
        Me.vlu_TXT.Size = New System.Drawing.Size(57, 15)
        Me.vlu_TXT.TabIndex = 17
        Me.vlu_TXT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.vlu_TXT.Type_ = "Num"
        Me.vlu_TXT.Val_max = 1000000000
        Me.vlu_TXT.Val_min = 0
        '
        'Atendance_Select
        '
        Me.Atendance_Select.Auto_Cleane = True
        Me.Atendance_Select.Back_color = System.Drawing.Color.White
        Me.Atendance_Select.BackColor = System.Drawing.Color.White
        Me.Atendance_Select.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Atendance_Select.Data_Link_ = ""
        Me.Atendance_Select.Decimal_ = 2
        Me.Atendance_Select.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Atendance_Select.Font_Size = 10
        Me.Atendance_Select.Font_Style = System.Drawing.FontStyle.Bold
        Me.Atendance_Select.Format_ = "dd-MM-yyyy"
        Me.Atendance_Select.Keydown_Support = True
        Me.Atendance_Select.Location = New System.Drawing.Point(200, 111)
        Me.Atendance_Select.Msg_Object = Nothing
        Me.Atendance_Select.Name = "Atendance_Select"
        Me.Atendance_Select.Select_Auto_Show = True
        Me.Atendance_Select.Select_Column_Color = "6"
        Me.Atendance_Select.Select_Columns = 0
        Me.Atendance_Select.Select_Filter = "(Name LIKE '%<value>%')"
        Me.Atendance_Select.Select_Hide_Columns = ""
        Me.Atendance_Select.Select_Object = Nothing
        Me.Atendance_Select.Select_Source = Nothing
        Me.Atendance_Select.Size = New System.Drawing.Size(226, 15)
        Me.Atendance_Select.TabIndex = 16
        Me.Atendance_Select.Type_ = "Select"
        Me.Atendance_Select.Val_max = 1000000000
        Me.Atendance_Select.Val_min = 0
        '
        'Filter_TXT
        '
        Me.Filter_TXT.Auto_Cleane = True
        Me.Filter_TXT.Back_color = System.Drawing.Color.White
        Me.Filter_TXT.BackColor = System.Drawing.Color.White
        Me.Filter_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Filter_TXT.Data_Link_ = ""
        Me.Filter_TXT.Decimal_ = 2
        Me.Filter_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Filter_TXT.Font_Size = 10
        Me.Filter_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Filter_TXT.Format_ = "dd-MM-yyyy"
        Me.Filter_TXT.Keydown_Support = True
        Me.Filter_TXT.Location = New System.Drawing.Point(200, 70)
        Me.Filter_TXT.Msg_Object = Nothing
        Me.Filter_TXT.Name = "Filter_TXT"
        Me.Filter_TXT.Select_Auto_Show = True
        Me.Filter_TXT.Select_Column_Color = "6"
        Me.Filter_TXT.Select_Columns = 0
        Me.Filter_TXT.Select_Filter = "(Name LIKE '%<value>%')"
        Me.Filter_TXT.Select_Hide_Columns = ""
        Me.Filter_TXT.Select_Object = Nothing
        Me.Filter_TXT.Select_Source = Nothing
        Me.Filter_TXT.Size = New System.Drawing.Size(226, 15)
        Me.Filter_TXT.TabIndex = 15
        Me.Filter_TXT.Type_ = "Select"
        Me.Filter_TXT.Val_max = 1000000000
        Me.Filter_TXT.Val_min = 0
        '
        'Type_TXT
        '
        Me.Type_TXT.Auto_Cleane = True
        Me.Type_TXT.Back_color = System.Drawing.Color.White
        Me.Type_TXT.BackColor = System.Drawing.Color.White
        Me.Type_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Type_TXT.Data_Link_ = ""
        Me.Type_TXT.Decimal_ = 2
        Me.Type_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Type_TXT.Font_Size = 10
        Me.Type_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Type_TXT.Format_ = "dd-MM-yyyy"
        Me.Type_TXT.Keydown_Support = True
        Me.Type_TXT.Location = New System.Drawing.Point(200, 48)
        Me.Type_TXT.Msg_Object = Nothing
        Me.Type_TXT.Name = "Type_TXT"
        Me.Type_TXT.Select_Auto_Show = True
        Me.Type_TXT.Select_Column_Color = "6"
        Me.Type_TXT.Select_Columns = 0
        Me.Type_TXT.Select_Filter = "(Name LIKE '%<value>%')"
        Me.Type_TXT.Select_Hide_Columns = ""
        Me.Type_TXT.Select_Object = Nothing
        Me.Type_TXT.Select_Source = Nothing
        Me.Type_TXT.Size = New System.Drawing.Size(151, 15)
        Me.Type_TXT.TabIndex = 14
        Me.Type_TXT.Type_ = "Select"
        Me.Type_TXT.Val_max = 1000000000
        Me.Type_TXT.Val_min = 0
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(182, 132)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(11, 16)
        Me.Label14.TabIndex = 13
        Me.Label14.Text = ":"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 132)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(76, 16)
        Me.Label16.TabIndex = 12
        Me.Label16.Text = "Defolt Value"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(182, 110)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(11, 16)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = ":"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 110)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(170, 16)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Attendance/Production Type"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(182, 69)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(11, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = ":"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(182, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(11, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = ":"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Filter Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Filter Type"
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(434, 22)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Auto Fill Attendance"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Payroll_Panel
        '
        Me.Payroll_Panel.AutoSize = True
        Me.Payroll_Panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Payroll_Panel.BackColor = System.Drawing.Color.White
        Me.Payroll_Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Payroll_Panel.Controls.Add(Me.To_date)
        Me.Payroll_Panel.Controls.Add(Me.Button2)
        Me.Payroll_Panel.Controls.Add(Me.Txt2)
        Me.Payroll_Panel.Controls.Add(Me.frm_date)
        Me.Payroll_Panel.Controls.Add(Me.Label10)
        Me.Payroll_Panel.Controls.Add(Me.Label11)
        Me.Payroll_Panel.Controls.Add(Me.Label12)
        Me.Payroll_Panel.Controls.Add(Me.Label13)
        Me.Payroll_Panel.Controls.Add(Me.Label15)
        Me.Payroll_Panel.Controls.Add(Me.Label17)
        Me.Payroll_Panel.Controls.Add(Me.Label18)
        Me.Payroll_Panel.Location = New System.Drawing.Point(674, 172)
        Me.Payroll_Panel.Name = "Payroll_Panel"
        Me.Payroll_Panel.Size = New System.Drawing.Size(433, 169)
        Me.Payroll_Panel.TabIndex = 1
        '
        'To_date
        '
        Me.To_date.Auto_Cleane = True
        Me.To_date.Back_color = System.Drawing.Color.White
        Me.To_date.BackColor = System.Drawing.Color.White
        Me.To_date.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.To_date.Data_Link_ = ""
        Me.To_date.Decimal_ = 2
        Me.To_date.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.To_date.Font_Size = 10
        Me.To_date.Font_Style = System.Drawing.FontStyle.Bold
        Me.To_date.Format_ = "dd-MM-yyyy"
        Me.To_date.Keydown_Support = True
        Me.To_date.Location = New System.Drawing.Point(200, 70)
        Me.To_date.Msg_Object = Nothing
        Me.To_date.Name = "To_date"
        Me.To_date.Select_Auto_Show = True
        Me.To_date.Select_Column_Color = "6"
        Me.To_date.Select_Columns = 0
        Me.To_date.Select_Filter = "(Name LIKE '%<value>%')"
        Me.To_date.Select_Hide_Columns = ""
        Me.To_date.Select_Object = Nothing
        Me.To_date.Select_Source = Nothing
        Me.To_date.Size = New System.Drawing.Size(110, 15)
        Me.To_date.TabIndex = 1
        Me.To_date.Type_ = "TXT"
        Me.To_date.Val_max = 1000000000
        Me.To_date.Val_min = 0
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.PaleTurquoise
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(336, 132)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(92, 32)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Apply"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Txt2
        '
        Me.Txt2.Auto_Cleane = True
        Me.Txt2.Back_color = System.Drawing.Color.White
        Me.Txt2.BackColor = System.Drawing.Color.White
        Me.Txt2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Txt2.Data_Link_ = ""
        Me.Txt2.Decimal_ = 2
        Me.Txt2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt2.Font_Size = 10
        Me.Txt2.Font_Style = System.Drawing.FontStyle.Bold
        Me.Txt2.Format_ = "dd-MM-yyyy"
        Me.Txt2.Keydown_Support = True
        Me.Txt2.Location = New System.Drawing.Point(200, 111)
        Me.Txt2.Msg_Object = Nothing
        Me.Txt2.Name = "Txt2"
        Me.Txt2.Select_Auto_Show = True
        Me.Txt2.Select_Column_Color = "6"
        Me.Txt2.Select_Columns = 0
        Me.Txt2.Select_Filter = "(Name LIKE '%<value>%')"
        Me.Txt2.Select_Hide_Columns = ""
        Me.Txt2.Select_Object = Nothing
        Me.Txt2.Select_Source = Nothing
        Me.Txt2.Size = New System.Drawing.Size(226, 15)
        Me.Txt2.TabIndex = 2
        Me.Txt2.Type_ = "Select"
        Me.Txt2.Val_max = 1000000000
        Me.Txt2.Val_min = 0
        '
        'frm_date
        '
        Me.frm_date.Auto_Cleane = True
        Me.frm_date.Back_color = System.Drawing.Color.White
        Me.frm_date.BackColor = System.Drawing.Color.White
        Me.frm_date.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.frm_date.Data_Link_ = ""
        Me.frm_date.Decimal_ = 2
        Me.frm_date.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frm_date.Font_Size = 10
        Me.frm_date.Font_Style = System.Drawing.FontStyle.Bold
        Me.frm_date.Format_ = "dd-MM-yyyy"
        Me.frm_date.Keydown_Support = True
        Me.frm_date.Location = New System.Drawing.Point(200, 48)
        Me.frm_date.Msg_Object = Nothing
        Me.frm_date.Name = "frm_date"
        Me.frm_date.Select_Auto_Show = True
        Me.frm_date.Select_Column_Color = "6"
        Me.frm_date.Select_Columns = 0
        Me.frm_date.Select_Filter = "(Name LIKE '%<value>%')"
        Me.frm_date.Select_Hide_Columns = ""
        Me.frm_date.Select_Object = Nothing
        Me.frm_date.Select_Source = Nothing
        Me.frm_date.Size = New System.Drawing.Size(110, 15)
        Me.frm_date.TabIndex = 0
        Me.frm_date.Type_ = "TXT"
        Me.frm_date.Val_max = 1000000000
        Me.frm_date.Val_min = 0
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(182, 110)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(11, 16)
        Me.Label10.TabIndex = 7
        Me.Label10.Text = ":"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 110)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(104, 16)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "Employee/Group"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(182, 69)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(11, 16)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = ":"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(182, 47)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(11, 16)
        Me.Label13.TabIndex = 3
        Me.Label13.Text = ":"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 69)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(20, 16)
        Me.Label15.TabIndex = 2
        Me.Label15.Text = "To"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(6, 47)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(37, 16)
        Me.Label17.TabIndex = 1
        Me.Label17.Text = "From"
        '
        'Label18
        '
        Me.Label18.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label18.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(0, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(431, 22)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "Auto Fill Payroll"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Payroll_Auto_Fill_Dialoag
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.OldLace
        Me.ClientSize = New System.Drawing.Size(1289, 554)
        Me.Controls.Add(Me.Payroll_Panel)
        Me.Controls.Add(Me.Attendance_Panel)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Payroll_Auto_Fill_Dialoag"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Payroll_Auto_Fill_Dialoag"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Attendance_Panel.ResumeLayout(False)
        Me.Attendance_Panel.PerformLayout()
        CType(Me.Type_Source, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Filter_Source, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Attendance_Source, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Payroll_Panel.ResumeLayout(False)
        Me.Payroll_Panel.PerformLayout()
        CType(Me.Employee_Group_Source, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Attendance_Panel As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Type_Source As BindingSource
    Friend WithEvents Label14 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Filter_TXT As Tools.TXT
    Friend WithEvents Atendance_Select As Tools.TXT
    Friend WithEvents vlu_TXT As Tools.TXT
    Friend WithEvents Filter_Source As BindingSource
    Friend WithEvents Attendance_Source As BindingSource
    Friend WithEvents Button1 As Button
    Friend WithEvents Type_TXT As Tools.TXT
    Friend WithEvents Payroll_Panel As Panel
    Friend WithEvents Button2 As Button
    Friend WithEvents Txt2 As Tools.TXT
    Friend WithEvents frm_date As Tools.TXT
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents To_date As Tools.TXT
    Friend WithEvents Employee_Group_Source As BindingSource
End Class
