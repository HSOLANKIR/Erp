<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Repoer_Ledger_cfg
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Sorting_TXT = New Tools.TXT()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.OB_Panel = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.OB_YN = New Tools.YN()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Txt2 = New Tools.TXT()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Txt1 = New Tools.TXT()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Sorting_Panel = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Txt3 = New Tools.TXT()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.print_panel = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Narration_Panel = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Narration_YN = New Tools.YN()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.OB_Panel.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Sorting_Panel.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.print_panel.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Narration_Panel.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.Controls.Add(Me.Sorting_TXT)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(394, 23)
        Me.Panel1.TabIndex = 2
        '
        'Sorting_TXT
        '
        Me.Sorting_TXT.Auto_Cleane = True
        Me.Sorting_TXT.Back_color = System.Drawing.Color.White
        Me.Sorting_TXT.BackColor = System.Drawing.Color.White
        Me.Sorting_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Sorting_TXT.Data_Link_ = ""
        Me.Sorting_TXT.Decimal_ = 2
        Me.Sorting_TXT.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Sorting_TXT.Font_Size = 10
        Me.Sorting_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Sorting_TXT.Format_ = "dd-MM-yyyy"
        Me.Sorting_TXT.Keydown_Support = True
        Me.Sorting_TXT.Location = New System.Drawing.Point(138, 4)
        Me.Sorting_TXT.Msg_Object = Nothing
        Me.Sorting_TXT.Name = "Sorting_TXT"
        Me.Sorting_TXT.Select_Auto_Show = True
        Me.Sorting_TXT.Select_Column_Color = "NA"
        Me.Sorting_TXT.Select_Columns = 0
        Me.Sorting_TXT.Select_Filter = " "
        Me.Sorting_TXT.Select_Hide_Columns = "NA"
        Me.Sorting_TXT.Select_Object = Nothing
        Me.Sorting_TXT.Select_Source = Me.BindingSource1
        Me.Sorting_TXT.Size = New System.Drawing.Size(135, 16)
        Me.Sorting_TXT.TabIndex = 10
        Me.Sorting_TXT.Type_ = "Select"
        Me.Sorting_TXT.Val_max = 1000000000
        Me.Sorting_TXT.Val_min = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label3.Location = New System.Drawing.Point(18, 4)
        Me.Label3.Margin = New System.Windows.Forms.Padding(1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Sorting Method"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(119, 4)
        Me.Label4.Margin = New System.Windows.Forms.Padding(1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(15, 16)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = ": "
        '
        'OB_Panel
        '
        Me.OB_Panel.AutoSize = True
        Me.OB_Panel.Controls.Add(Me.Label5)
        Me.OB_Panel.Controls.Add(Me.Label6)
        Me.OB_Panel.Controls.Add(Me.OB_YN)
        Me.OB_Panel.Dock = System.Windows.Forms.DockStyle.Top
        Me.OB_Panel.Location = New System.Drawing.Point(0, 47)
        Me.OB_Panel.Name = "OB_Panel"
        Me.OB_Panel.Size = New System.Drawing.Size(394, 21)
        Me.OB_Panel.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label5.Location = New System.Drawing.Point(18, 4)
        Me.Label5.Margin = New System.Windows.Forms.Padding(1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 16)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Opning Balance"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(119, 4)
        Me.Label6.Margin = New System.Windows.Forms.Padding(1)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(15, 16)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = ": "
        '
        'OB_YN
        '
        Me.OB_YN.Back_color = System.Drawing.Color.White
        Me.OB_YN.BackColor = System.Drawing.Color.White
        Me.OB_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.OB_YN.Data_Link_ = "Branch_YN"
        Me.OB_YN.Defolt_ = "No"
        Me.OB_YN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OB_YN.Location = New System.Drawing.Point(138, 5)
        Me.OB_YN.Margin = New System.Windows.Forms.Padding(1)
        Me.OB_YN.Name = "OB_YN"
        Me.OB_YN.ReadOnly = True
        Me.OB_YN.Size = New System.Drawing.Size(34, 15)
        Me.OB_YN.TabIndex = 6
        Me.OB_YN.Text = "No"
        '
        'Panel2
        '
        Me.Panel2.AutoSize = True
        Me.Panel2.Controls.Add(Me.Txt2)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.Txt1)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 23)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(394, 41)
        Me.Panel2.TabIndex = 3
        Me.Panel2.Visible = False
        '
        'Txt2
        '
        Me.Txt2.Auto_Cleane = True
        Me.Txt2.Back_color = System.Drawing.Color.White
        Me.Txt2.BackColor = System.Drawing.Color.White
        Me.Txt2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Txt2.Data_Link_ = ""
        Me.Txt2.Decimal_ = 2
        Me.Txt2.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Txt2.Font_Size = 10
        Me.Txt2.Font_Style = System.Drawing.FontStyle.Bold
        Me.Txt2.Format_ = "dd-MM-yyyy"
        Me.Txt2.Keydown_Support = True
        Me.Txt2.Location = New System.Drawing.Point(138, 22)
        Me.Txt2.Msg_Object = Nothing
        Me.Txt2.Name = "Txt2"
        Me.Txt2.Select_Auto_Show = True
        Me.Txt2.Select_Column_Color = "NA"
        Me.Txt2.Select_Columns = 0
        Me.Txt2.Select_Filter = " "
        Me.Txt2.Select_Hide_Columns = "NA"
        Me.Txt2.Select_Object = Nothing
        Me.Txt2.Select_Source = Nothing
        Me.Txt2.Size = New System.Drawing.Size(86, 16)
        Me.Txt2.TabIndex = 14
        Me.Txt2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Txt2.Type_ = "Num"
        Me.Txt2.Val_max = 1000000000
        Me.Txt2.Val_min = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(119, 22)
        Me.Label9.Margin = New System.Windows.Forms.Padding(1)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(15, 16)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = ": "
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DimGray
        Me.Label10.Location = New System.Drawing.Point(44, 22)
        Me.Label10.Margin = New System.Windows.Forms.Padding(1)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(21, 16)
        Me.Label10.TabIndex = 12
        Me.Label10.Text = "To"
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
        Me.Txt1.Location = New System.Drawing.Point(138, 4)
        Me.Txt1.Msg_Object = Nothing
        Me.Txt1.Name = "Txt1"
        Me.Txt1.Select_Auto_Show = True
        Me.Txt1.Select_Column_Color = "NA"
        Me.Txt1.Select_Columns = 0
        Me.Txt1.Select_Filter = " "
        Me.Txt1.Select_Hide_Columns = "NA"
        Me.Txt1.Select_Object = Nothing
        Me.Txt1.Select_Source = Nothing
        Me.Txt1.Size = New System.Drawing.Size(86, 16)
        Me.Txt1.TabIndex = 11
        Me.Txt1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Txt1.Type_ = "Num"
        Me.Txt1.Val_max = 1000000000
        Me.Txt1.Val_min = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(119, 4)
        Me.Label8.Margin = New System.Windows.Forms.Padding(1)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(15, 16)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = ": "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DimGray
        Me.Label7.Location = New System.Drawing.Point(44, 4)
        Me.Label7.Margin = New System.Windows.Forms.Padding(1)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 16)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "From"
        '
        'Sorting_Panel
        '
        Me.Sorting_Panel.AutoSize = True
        Me.Sorting_Panel.Controls.Add(Me.Panel2)
        Me.Sorting_Panel.Controls.Add(Me.Panel1)
        Me.Sorting_Panel.Dock = System.Windows.Forms.DockStyle.Top
        Me.Sorting_Panel.Location = New System.Drawing.Point(0, 68)
        Me.Sorting_Panel.Name = "Sorting_Panel"
        Me.Sorting_Panel.Size = New System.Drawing.Size(394, 64)
        Me.Sorting_Panel.TabIndex = 4
        '
        'Panel3
        '
        Me.Panel3.AutoSize = True
        Me.Panel3.Controls.Add(Me.Txt3)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.Label12)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 16)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(394, 23)
        Me.Panel3.TabIndex = 5
        '
        'Txt3
        '
        Me.Txt3.Auto_Cleane = True
        Me.Txt3.Back_color = System.Drawing.Color.White
        Me.Txt3.BackColor = System.Drawing.Color.White
        Me.Txt3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Txt3.Data_Link_ = ""
        Me.Txt3.Decimal_ = 2
        Me.Txt3.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Txt3.Font_Size = 10
        Me.Txt3.Font_Style = System.Drawing.FontStyle.Bold
        Me.Txt3.Format_ = "dd-MM-yyyy"
        Me.Txt3.Keydown_Support = True
        Me.Txt3.Location = New System.Drawing.Point(138, 4)
        Me.Txt3.Msg_Object = Nothing
        Me.Txt3.Name = "Txt3"
        Me.Txt3.Select_Auto_Show = True
        Me.Txt3.Select_Column_Color = "NA"
        Me.Txt3.Select_Columns = 0
        Me.Txt3.Select_Filter = " "
        Me.Txt3.Select_Hide_Columns = "NA"
        Me.Txt3.Select_Object = Nothing
        Me.Txt3.Select_Source = Me.BindingSource1
        Me.Txt3.Size = New System.Drawing.Size(251, 16)
        Me.Txt3.TabIndex = 10
        Me.Txt3.Type_ = "Select"
        Me.Txt3.Val_max = 1000000000
        Me.Txt3.Val_min = 0
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label11.Location = New System.Drawing.Point(18, 4)
        Me.Label11.Margin = New System.Windows.Forms.Padding(1)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 16)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "Print Path"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(119, 4)
        Me.Label12.Margin = New System.Windows.Forms.Padding(1)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(15, 16)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = ": "
        '
        'print_panel
        '
        Me.print_panel.AutoSize = True
        Me.print_panel.Controls.Add(Me.Panel3)
        Me.print_panel.Controls.Add(Me.Label13)
        Me.print_panel.Dock = System.Windows.Forms.DockStyle.Top
        Me.print_panel.Location = New System.Drawing.Point(0, 142)
        Me.print_panel.Name = "print_panel"
        Me.print_panel.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.print_panel.Size = New System.Drawing.Size(394, 49)
        Me.print_panel.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(0, 0)
        Me.Label13.Margin = New System.Windows.Forms.Padding(1)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(394, 16)
        Me.Label13.TabIndex = 4
        Me.Label13.Text = "Print Details"
        '
        'Panel4
        '
        Me.Panel4.AutoSize = True
        Me.Panel4.Controls.Add(Me.Sorting_Panel)
        Me.Panel4.Controls.Add(Me.OB_Panel)
        Me.Panel4.Controls.Add(Me.Narration_Panel)
        Me.Panel4.Controls.Add(Me.Label16)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Padding = New System.Windows.Forms.Padding(0, 10, 0, 10)
        Me.Panel4.Size = New System.Drawing.Size(394, 142)
        Me.Panel4.TabIndex = 0
        '
        'Narration_Panel
        '
        Me.Narration_Panel.AutoSize = True
        Me.Narration_Panel.Controls.Add(Me.Label1)
        Me.Narration_Panel.Controls.Add(Me.Label2)
        Me.Narration_Panel.Controls.Add(Me.Narration_YN)
        Me.Narration_Panel.Dock = System.Windows.Forms.DockStyle.Top
        Me.Narration_Panel.Location = New System.Drawing.Point(0, 26)
        Me.Narration_Panel.Name = "Narration_Panel"
        Me.Narration_Panel.Size = New System.Drawing.Size(394, 21)
        Me.Narration_Panel.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label1.Location = New System.Drawing.Point(18, 4)
        Me.Label1.Margin = New System.Windows.Forms.Padding(1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Show Narration"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(119, 4)
        Me.Label2.Margin = New System.Windows.Forms.Padding(1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(15, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = ": "
        '
        'Narration_YN
        '
        Me.Narration_YN.Back_color = System.Drawing.Color.White
        Me.Narration_YN.BackColor = System.Drawing.Color.White
        Me.Narration_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Narration_YN.Data_Link_ = "Branch_YN"
        Me.Narration_YN.Defolt_ = "No"
        Me.Narration_YN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Narration_YN.Location = New System.Drawing.Point(138, 5)
        Me.Narration_YN.Margin = New System.Windows.Forms.Padding(1)
        Me.Narration_YN.Name = "Narration_YN"
        Me.Narration_YN.ReadOnly = True
        Me.Narration_YN.Size = New System.Drawing.Size(34, 15)
        Me.Narration_YN.TabIndex = 6
        Me.Narration_YN.Text = "No"
        '
        'Label16
        '
        Me.Label16.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(0, 10)
        Me.Label16.Margin = New System.Windows.Forms.Padding(1)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(394, 16)
        Me.Label16.TabIndex = 4
        Me.Label16.Text = "General Details"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.print_panel)
        Me.Panel5.Controls.Add(Me.Panel4)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(394, 193)
        Me.Panel5.TabIndex = 2
        '
        'Repoer_Ledger_cfg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.Panel5)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Repoer_Ledger_cfg"
        Me.Size = New System.Drawing.Size(394, 193)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.OB_Panel.ResumeLayout(False)
        Me.OB_Panel.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Sorting_Panel.ResumeLayout(False)
        Me.Sorting_Panel.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.print_panel.ResumeLayout(False)
        Me.print_panel.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Narration_Panel.ResumeLayout(False)
        Me.Narration_Panel.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Sorting_TXT As Tools.TXT
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents OB_Panel As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents OB_YN As Tools.YN
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Txt1 As Tools.TXT
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Txt2 As Tools.TXT
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Sorting_Panel As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Txt3 As Tools.TXT
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents print_panel As Panel
    Friend WithEvents Label13 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label16 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Narration_Panel As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Narration_YN As Tools.YN
End Class
