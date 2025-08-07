<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Registers_Summary_cfg
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Chart_Type_TXT = New Tools.TXT()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Narration_Panel = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Chart_YN = New Tools.YN()
        Me.Sorting_Panel = New System.Windows.Forms.Panel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Chart_Type_Source = New System.Windows.Forms.BindingSource(Me.components)
        Me.print_panel = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.path_TXT = New Tools.TXT()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Txt1 = New Tools.TXT()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Periodicity_SOurce = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Average_YN = New Tools.YN()
        Me.Panel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Narration_Panel.SuspendLayout()
        CType(Me.Chart_Type_Source, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.print_panel.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.Periodicity_SOurce, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel4
        '
        Me.Panel4.AutoSize = True
        Me.Panel4.Controls.Add(Me.Panel1)
        Me.Panel4.Controls.Add(Me.Narration_Panel)
        Me.Panel4.Controls.Add(Me.Sorting_Panel)
        Me.Panel4.Controls.Add(Me.Panel2)
        Me.Panel4.Controls.Add(Me.Panel5)
        Me.Panel4.Controls.Add(Me.Label17)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Padding = New System.Windows.Forms.Padding(0, 10, 0, 10)
        Me.Panel4.Size = New System.Drawing.Size(392, 118)
        Me.Panel4.TabIndex = 108
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.Controls.Add(Me.Chart_Type_TXT)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 87)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(392, 21)
        Me.Panel1.TabIndex = 3
        '
        'Chart_Type_TXT
        '
        Me.Chart_Type_TXT.Auto_Cleane = True
        Me.Chart_Type_TXT.Back_color = System.Drawing.Color.White
        Me.Chart_Type_TXT.BackColor = System.Drawing.Color.White
        Me.Chart_Type_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Chart_Type_TXT.Data_Link_ = ""
        Me.Chart_Type_TXT.Decimal_ = 2
        Me.Chart_Type_TXT.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Chart_Type_TXT.Font_Size = 10
        Me.Chart_Type_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Chart_Type_TXT.Format_ = "dd-MM-yyyy"
        Me.Chart_Type_TXT.Keydown_Support = True
        Me.Chart_Type_TXT.Location = New System.Drawing.Point(138, 2)
        Me.Chart_Type_TXT.Msg_Object = Nothing
        Me.Chart_Type_TXT.Name = "Chart_Type_TXT"
        Me.Chart_Type_TXT.Select_Auto_Show = True
        Me.Chart_Type_TXT.Select_Column_Color = "NA"
        Me.Chart_Type_TXT.Select_Columns = 0
        Me.Chart_Type_TXT.Select_Filter = " "
        Me.Chart_Type_TXT.Select_Hide_Columns = "NA"
        Me.Chart_Type_TXT.Select_Object = Nothing
        Me.Chart_Type_TXT.Select_Source = Nothing
        Me.Chart_Type_TXT.Size = New System.Drawing.Size(135, 16)
        Me.Chart_Type_TXT.TabIndex = 10
        Me.Chart_Type_TXT.Type_ = "Select"
        Me.Chart_Type_TXT.Val_max = 1000000000
        Me.Chart_Type_TXT.Val_min = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label3.Location = New System.Drawing.Point(18, 2)
        Me.Label3.Margin = New System.Windows.Forms.Padding(1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Chart Style"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(119, 2)
        Me.Label4.Margin = New System.Windows.Forms.Padding(1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(16, 16)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = ": "
        '
        'Narration_Panel
        '
        Me.Narration_Panel.AutoSize = True
        Me.Narration_Panel.Controls.Add(Me.Label1)
        Me.Narration_Panel.Controls.Add(Me.Label2)
        Me.Narration_Panel.Controls.Add(Me.Chart_YN)
        Me.Narration_Panel.Dock = System.Windows.Forms.DockStyle.Top
        Me.Narration_Panel.Location = New System.Drawing.Point(0, 66)
        Me.Narration_Panel.Name = "Narration_Panel"
        Me.Narration_Panel.Size = New System.Drawing.Size(392, 21)
        Me.Narration_Panel.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label1.Location = New System.Drawing.Point(18, 4)
        Me.Label1.Margin = New System.Windows.Forms.Padding(1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Show Chart"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(119, 4)
        Me.Label2.Margin = New System.Windows.Forms.Padding(1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(16, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = ": "
        '
        'Chart_YN
        '
        Me.Chart_YN.Back_color = System.Drawing.Color.White
        Me.Chart_YN.BackColor = System.Drawing.Color.White
        Me.Chart_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Chart_YN.Data_Link_ = "Branch_YN"
        Me.Chart_YN.Defolt_ = "No"
        Me.Chart_YN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chart_YN.Location = New System.Drawing.Point(138, 5)
        Me.Chart_YN.Margin = New System.Windows.Forms.Padding(1)
        Me.Chart_YN.Name = "Chart_YN"
        Me.Chart_YN.ReadOnly = True
        Me.Chart_YN.Size = New System.Drawing.Size(34, 15)
        Me.Chart_YN.TabIndex = 6
        Me.Chart_YN.Text = "No"
        '
        'Sorting_Panel
        '
        Me.Sorting_Panel.AutoSize = True
        Me.Sorting_Panel.Dock = System.Windows.Forms.DockStyle.Top
        Me.Sorting_Panel.Location = New System.Drawing.Point(0, 66)
        Me.Sorting_Panel.Name = "Sorting_Panel"
        Me.Sorting_Panel.Size = New System.Drawing.Size(392, 0)
        Me.Sorting_Panel.TabIndex = 4
        '
        'Label17
        '
        Me.Label17.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(0, 10)
        Me.Label17.Margin = New System.Windows.Forms.Padding(1)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(392, 16)
        Me.Label17.TabIndex = 4
        Me.Label17.Text = "General Details"
        '
        'print_panel
        '
        Me.print_panel.AutoSize = True
        Me.print_panel.Controls.Add(Me.Panel3)
        Me.print_panel.Controls.Add(Me.Label13)
        Me.print_panel.Dock = System.Windows.Forms.DockStyle.Top
        Me.print_panel.Location = New System.Drawing.Point(0, 118)
        Me.print_panel.Name = "print_panel"
        Me.print_panel.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.print_panel.Size = New System.Drawing.Size(392, 49)
        Me.print_panel.TabIndex = 109
        '
        'Panel3
        '
        Me.Panel3.AutoSize = True
        Me.Panel3.Controls.Add(Me.path_TXT)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.Label12)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 16)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(392, 23)
        Me.Panel3.TabIndex = 5
        '
        'path_TXT
        '
        Me.path_TXT.Auto_Cleane = True
        Me.path_TXT.Back_color = System.Drawing.Color.White
        Me.path_TXT.BackColor = System.Drawing.Color.White
        Me.path_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.path_TXT.Data_Link_ = ""
        Me.path_TXT.Decimal_ = 2
        Me.path_TXT.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.path_TXT.Font_Size = 10
        Me.path_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.path_TXT.Format_ = "dd-MM-yyyy"
        Me.path_TXT.Keydown_Support = True
        Me.path_TXT.Location = New System.Drawing.Point(138, 4)
        Me.path_TXT.Msg_Object = Nothing
        Me.path_TXT.Name = "path_TXT"
        Me.path_TXT.Select_Auto_Show = True
        Me.path_TXT.Select_Column_Color = "NA"
        Me.path_TXT.Select_Columns = 0
        Me.path_TXT.Select_Filter = " "
        Me.path_TXT.Select_Hide_Columns = "NA"
        Me.path_TXT.Select_Object = Nothing
        Me.path_TXT.Select_Source = Nothing
        Me.path_TXT.Size = New System.Drawing.Size(251, 16)
        Me.path_TXT.TabIndex = 10
        Me.path_TXT.Type_ = "Select"
        Me.path_TXT.Val_max = 1000000000
        Me.path_TXT.Val_min = 0
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label11.Location = New System.Drawing.Point(18, 4)
        Me.Label11.Margin = New System.Windows.Forms.Padding(1)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(66, 16)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "Print Path"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(119, 4)
        Me.Label12.Margin = New System.Windows.Forms.Padding(1)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(16, 16)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = ": "
        '
        'Label13
        '
        Me.Label13.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(0, 0)
        Me.Label13.Margin = New System.Windows.Forms.Padding(1)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(392, 16)
        Me.Label13.TabIndex = 4
        Me.Label13.Text = "Print Details"
        '
        'Panel2
        '
        Me.Panel2.AutoSize = True
        Me.Panel2.Controls.Add(Me.Txt1)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 45)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(392, 21)
        Me.Panel2.TabIndex = 1
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
        Me.Txt1.Location = New System.Drawing.Point(138, 2)
        Me.Txt1.Msg_Object = Nothing
        Me.Txt1.Name = "Txt1"
        Me.Txt1.Select_Auto_Show = True
        Me.Txt1.Select_Column_Color = "NA"
        Me.Txt1.Select_Columns = 0
        Me.Txt1.Select_Filter = " "
        Me.Txt1.Select_Hide_Columns = "NA"
        Me.Txt1.Select_Object = Nothing
        Me.Txt1.Select_Source = Nothing
        Me.Txt1.Size = New System.Drawing.Size(135, 16)
        Me.Txt1.TabIndex = 10
        Me.Txt1.Type_ = "Select"
        Me.Txt1.Val_max = 1000000000
        Me.Txt1.Val_min = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label5.Location = New System.Drawing.Point(18, 2)
        Me.Label5.Margin = New System.Windows.Forms.Padding(1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 16)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Periodicity"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(119, 2)
        Me.Label6.Margin = New System.Windows.Forms.Padding(1)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(16, 16)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = ": "
        '
        'Panel5
        '
        Me.Panel5.AutoSize = True
        Me.Panel5.Controls.Add(Me.Label7)
        Me.Panel5.Controls.Add(Me.Label8)
        Me.Panel5.Controls.Add(Me.Average_YN)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 26)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(392, 19)
        Me.Panel5.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label7.Location = New System.Drawing.Point(18, 2)
        Me.Label7.Margin = New System.Windows.Forms.Padding(1)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 16)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Show Average"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(119, 2)
        Me.Label8.Margin = New System.Windows.Forms.Padding(1)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(16, 16)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = ": "
        '
        'Average_YN
        '
        Me.Average_YN.Back_color = System.Drawing.Color.White
        Me.Average_YN.BackColor = System.Drawing.Color.White
        Me.Average_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Average_YN.Data_Link_ = "Branch_YN"
        Me.Average_YN.Defolt_ = "No"
        Me.Average_YN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Average_YN.Location = New System.Drawing.Point(138, 3)
        Me.Average_YN.Margin = New System.Windows.Forms.Padding(1)
        Me.Average_YN.Name = "Average_YN"
        Me.Average_YN.ReadOnly = True
        Me.Average_YN.Size = New System.Drawing.Size(34, 15)
        Me.Average_YN.TabIndex = 6
        Me.Average_YN.Text = "No"
        '
        'Registers_Summary_cfg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.print_panel)
        Me.Controls.Add(Me.Panel4)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Registers_Summary_cfg"
        Me.Size = New System.Drawing.Size(392, 170)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Narration_Panel.ResumeLayout(False)
        Me.Narration_Panel.PerformLayout()
        CType(Me.Chart_Type_Source, System.ComponentModel.ISupportInitialize).EndInit()
        Me.print_panel.ResumeLayout(False)
        Me.print_panel.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.Periodicity_SOurce, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Chart_Type_TXT As Tools.TXT
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Narration_Panel As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Chart_YN As Tools.YN
    Friend WithEvents Sorting_Panel As Panel
    Friend WithEvents Label17 As Label
    Friend WithEvents Chart_Type_Source As BindingSource
    Friend WithEvents print_panel As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents path_TXT As Tools.TXT
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Txt1 As Tools.TXT
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Periodicity_SOurce As BindingSource
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Average_YN As Tools.YN
End Class
