<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Day_Book_cfg
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
        Me.Narration_Panel = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Narration_YN = New Tools.YN()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Sorting_TXT = New Tools.TXT()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.Panel17 = New System.Windows.Forms.Panel()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.BindingSource2 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Sorting_Panel = New System.Windows.Forms.Panel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.print_panel = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Txt3 = New Tools.TXT()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Narration_Panel.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel14.SuspendLayout()
        CType(Me.BindingSource2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.print_panel.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
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
        Me.Narration_Panel.Size = New System.Drawing.Size(392, 21)
        Me.Narration_Panel.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label1.Location = New System.Drawing.Point(18, 4)
        Me.Label1.Margin = New System.Windows.Forms.Padding(1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Show Narration"
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
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.Controls.Add(Me.Sorting_TXT)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 47)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(392, 23)
        Me.Panel1.TabIndex = 5
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
        Me.Label3.Size = New System.Drawing.Size(96, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Sorting Method"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(119, 4)
        Me.Label4.Margin = New System.Windows.Forms.Padding(1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(16, 16)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = ": "
        '
        'Panel14
        '
        Me.Panel14.AutoSize = True
        Me.Panel14.Controls.Add(Me.Panel17)
        Me.Panel14.Controls.Add(Me.Panel16)
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel14.Location = New System.Drawing.Point(0, 0)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(392, 2)
        Me.Panel14.TabIndex = 106
        Me.Panel14.Visible = False
        '
        'Panel17
        '
        Me.Panel17.BackColor = System.Drawing.Color.DimGray
        Me.Panel17.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel17.Location = New System.Drawing.Point(0, 1)
        Me.Panel17.Name = "Panel17"
        Me.Panel17.Size = New System.Drawing.Size(392, 1)
        Me.Panel17.TabIndex = 107
        '
        'Panel16
        '
        Me.Panel16.BackColor = System.Drawing.Color.DimGray
        Me.Panel16.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel16.Location = New System.Drawing.Point(0, 0)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(392, 1)
        Me.Panel16.TabIndex = 106
        '
        'Panel4
        '
        Me.Panel4.AutoSize = True
        Me.Panel4.Controls.Add(Me.Panel1)
        Me.Panel4.Controls.Add(Me.Narration_Panel)
        Me.Panel4.Controls.Add(Me.Sorting_Panel)
        Me.Panel4.Controls.Add(Me.Label17)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 2)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Padding = New System.Windows.Forms.Padding(0, 10, 0, 10)
        Me.Panel4.Size = New System.Drawing.Size(392, 80)
        Me.Panel4.TabIndex = 107
        '
        'Sorting_Panel
        '
        Me.Sorting_Panel.AutoSize = True
        Me.Sorting_Panel.Dock = System.Windows.Forms.DockStyle.Top
        Me.Sorting_Panel.Location = New System.Drawing.Point(0, 26)
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
        Me.print_panel.Location = New System.Drawing.Point(0, 82)
        Me.print_panel.Name = "print_panel"
        Me.print_panel.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.print_panel.Size = New System.Drawing.Size(392, 49)
        Me.print_panel.TabIndex = 108
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
        Me.Panel3.Size = New System.Drawing.Size(392, 23)
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
        'Day_Book_cfg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.print_panel)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel14)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Day_Book_cfg"
        Me.Size = New System.Drawing.Size(392, 148)
        Me.Narration_Panel.ResumeLayout(False)
        Me.Narration_Panel.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel14.ResumeLayout(False)
        CType(Me.BindingSource2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.print_panel.ResumeLayout(False)
        Me.print_panel.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Narration_Panel As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Narration_YN As Tools.YN
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Sorting_TXT As Tools.TXT
    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel14 As Panel
    Friend WithEvents Panel17 As Panel
    Friend WithEvents Panel16 As Panel
    Friend WithEvents BindingSource2 As BindingSource
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Sorting_Panel As Panel
    Friend WithEvents Label17 As Label
    Friend WithEvents print_panel As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Txt3 As Tools.TXT
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
End Class
