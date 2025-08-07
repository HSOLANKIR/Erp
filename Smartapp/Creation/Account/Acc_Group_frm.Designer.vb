<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Acc_Group_frm
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.e_yn = New Tools.YN()
        Me.w_yn = New Tools.YN()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Txt1 = New Tools.TXT()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Group_TXT = New Tools.TXT()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Name_TXT = New Tools.TXT()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.Alias_TXT = New Tools.TXT()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(323, 749)
        Me.Panel1.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.Panel6)
        Me.Panel2.Controls.Add(Me.Txt1)
        Me.Panel2.Controls.Add(Me.Panel5)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(321, 747)
        Me.Panel2.TabIndex = 0
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.e_yn)
        Me.Panel6.Controls.Add(Me.w_yn)
        Me.Panel6.Controls.Add(Me.Label9)
        Me.Panel6.Controls.Add(Me.Label8)
        Me.Panel6.Controls.Add(Me.Label6)
        Me.Panel6.Controls.Add(Me.Label7)
        Me.Panel6.Controls.Add(Me.Label5)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 83)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(321, 60)
        Me.Panel6.TabIndex = 2
        '
        'e_yn
        '
        Me.e_yn.Back_color = System.Drawing.Color.White
        Me.e_yn.BackColor = System.Drawing.Color.White
        Me.e_yn.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.e_yn.Data_Link_ = ""
        Me.e_yn.Defolt_ = "No"
        Me.e_yn.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.e_yn.Font_ = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.e_yn.Location = New System.Drawing.Point(153, 39)
        Me.e_yn.Name = "e_yn"
        Me.e_yn.ReadOnly = True
        Me.e_yn.Size = New System.Drawing.Size(48, 16)
        Me.e_yn.TabIndex = 10
        Me.e_yn.Text = "No"
        '
        'w_yn
        '
        Me.w_yn.Back_color = System.Drawing.Color.White
        Me.w_yn.BackColor = System.Drawing.Color.White
        Me.w_yn.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.w_yn.Data_Link_ = ""
        Me.w_yn.Defolt_ = "No"
        Me.w_yn.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.w_yn.Font_ = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.w_yn.Location = New System.Drawing.Point(153, 21)
        Me.w_yn.Name = "w_yn"
        Me.w_yn.ReadOnly = True
        Me.w_yn.Size = New System.Drawing.Size(48, 16)
        Me.w_yn.TabIndex = 3
        Me.w_yn.Text = "No"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(129, 39)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(11, 16)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = ":"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(129, 21)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(11, 16)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = ":"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(22, 39)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 16)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "E-mail"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(22, 21)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 16)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Whatsapp"
        '
        'Label5
        '
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(0, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(321, 16)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Communication"
        '
        'Txt1
        '
        Me.Txt1.Auto_Cleane = True
        Me.Txt1.Back_color = System.Drawing.Color.White
        Me.Txt1.BackColor = System.Drawing.Color.White
        Me.Txt1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Txt1.Data_Link_ = ""
        Me.Txt1.Decimal_ = 2
        Me.Txt1.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Txt1.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Txt1.Font_Size = 11
        Me.Txt1.Font_Style = System.Drawing.FontStyle.Bold
        Me.Txt1.Format_ = "dd-MM-yyyy"
        Me.Txt1.Keydown_Support = True
        Me.Txt1.Location = New System.Drawing.Point(145, 427)
        Me.Txt1.Msg_Object = Nothing
        Me.Txt1.Name = "Txt1"
        Me.Txt1.Select_Auto_Show = True
        Me.Txt1.Select_Column_Color = "NA"
        Me.Txt1.Select_Columns = 0
        Me.Txt1.Select_Filter = Nothing
        Me.Txt1.Select_Hide_Columns = "NA"
        Me.Txt1.Select_Object = Nothing
        Me.Txt1.Select_Source = Nothing
        Me.Txt1.Size = New System.Drawing.Size(0, 17)
        Me.Txt1.TabIndex = 3
        Me.Txt1.Type_ = "TXT"
        Me.Txt1.Val_max = 1000000000
        Me.Txt1.Val_min = 0
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Controls.Add(Me.Label4)
        Me.Panel5.Controls.Add(Me.Group_TXT)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 60)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(321, 23)
        Me.Panel5.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Under Group"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(129, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(11, 16)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = ":"
        '
        'Group_TXT
        '
        Me.Group_TXT.Auto_Cleane = True
        Me.Group_TXT.Back_color = System.Drawing.Color.White
        Me.Group_TXT.BackColor = System.Drawing.Color.White
        Me.Group_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Group_TXT.Data_Link_ = ""
        Me.Group_TXT.Decimal_ = 2
        Me.Group_TXT.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Group_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Group_TXT.Font_Size = 11
        Me.Group_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Group_TXT.Format_ = "dd-MM-yyyy"
        Me.Group_TXT.Keydown_Support = True
        Me.Group_TXT.Location = New System.Drawing.Point(145, 5)
        Me.Group_TXT.Msg_Object = Nothing
        Me.Group_TXT.Name = "Group_TXT"
        Me.Group_TXT.Select_Auto_Show = True
        Me.Group_TXT.Select_Column_Color = "NA"
        Me.Group_TXT.Select_Columns = 0
        Me.Group_TXT.Select_Filter = "Name LIKE '%<value>%' or [Under Group] LIKE '%<value>%'"
        Me.Group_TXT.Select_Hide_Columns = "0"
        Me.Group_TXT.Select_Object = Nothing
        Me.Group_TXT.Select_Source = Me.BindingSource1
        Me.Group_TXT.Size = New System.Drawing.Size(172, 16)
        Me.Group_TXT.TabIndex = 2
        Me.Group_TXT.Type_ = "Select"
        Me.Group_TXT.Val_max = 1000000000
        Me.Group_TXT.Val_min = 0
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.Name_TXT)
        Me.Panel4.Controls.Add(Me.Label48)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.Label49)
        Me.Panel4.Controls.Add(Me.Alias_TXT)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(321, 60)
        Me.Panel4.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Name"
        '
        'Name_TXT
        '
        Me.Name_TXT.Auto_Cleane = True
        Me.Name_TXT.Back_color = System.Drawing.Color.White
        Me.Name_TXT.BackColor = System.Drawing.Color.White
        Me.Name_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Name_TXT.Data_Link_ = ""
        Me.Name_TXT.Decimal_ = 2
        Me.Name_TXT.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Name_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Name_TXT.Font_Size = 11
        Me.Name_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Name_TXT.Format_ = "dd-MM-yyyy"
        Me.Name_TXT.Keydown_Support = True
        Me.Name_TXT.Location = New System.Drawing.Point(109, 10)
        Me.Name_TXT.Msg_Object = Nothing
        Me.Name_TXT.Name = "Name_TXT"
        Me.Name_TXT.Select_Auto_Show = True
        Me.Name_TXT.Select_Column_Color = "NA"
        Me.Name_TXT.Select_Columns = 0
        Me.Name_TXT.Select_Filter = Nothing
        Me.Name_TXT.Select_Hide_Columns = "NA"
        Me.Name_TXT.Select_Object = Nothing
        Me.Name_TXT.Select_Source = Nothing
        Me.Name_TXT.Size = New System.Drawing.Size(204, 16)
        Me.Name_TXT.TabIndex = 0
        Me.Name_TXT.Type_ = "TXT"
        Me.Name_TXT.Val_max = 1000000000
        Me.Name_TXT.Val_min = 0
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Location = New System.Drawing.Point(92, 33)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(11, 16)
        Me.Label48.TabIndex = 71
        Me.Label48.Text = ":"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(92, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = ":"
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.Location = New System.Drawing.Point(8, 33)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(38, 17)
        Me.Label49.TabIndex = 69
        Me.Label49.Text = "alias"
        '
        'Alias_TXT
        '
        Me.Alias_TXT.Auto_Cleane = True
        Me.Alias_TXT.Back_color = System.Drawing.Color.White
        Me.Alias_TXT.BackColor = System.Drawing.Color.White
        Me.Alias_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Alias_TXT.Data_Link_ = ""
        Me.Alias_TXT.Decimal_ = 2
        Me.Alias_TXT.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Alias_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Alias_TXT.Font_Size = 11
        Me.Alias_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Alias_TXT.Format_ = "dd-MM-yyyy"
        Me.Alias_TXT.Keydown_Support = True
        Me.Alias_TXT.Location = New System.Drawing.Point(109, 33)
        Me.Alias_TXT.Msg_Object = Nothing
        Me.Alias_TXT.Name = "Alias_TXT"
        Me.Alias_TXT.Select_Auto_Show = True
        Me.Alias_TXT.Select_Column_Color = "NA"
        Me.Alias_TXT.Select_Columns = 0
        Me.Alias_TXT.Select_Filter = Nothing
        Me.Alias_TXT.Select_Hide_Columns = "NA"
        Me.Alias_TXT.Select_Object = Nothing
        Me.Alias_TXT.Select_Source = Nothing
        Me.Alias_TXT.Size = New System.Drawing.Size(144, 16)
        Me.Alias_TXT.TabIndex = 1
        Me.Alias_TXT.Type_ = "TXT"
        Me.Alias_TXT.Val_max = 1000000000
        Me.Alias_TXT.Val_min = 0
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.DarkGray
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 746)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(321, 1)
        Me.Panel3.TabIndex = 30
        Me.Panel3.TabStop = True
        '
        'Acc_Group_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1364, 749)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Acc_Group_frm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Acc_Group_frm"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Group_TXT As Tools.TXT
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label48 As Label
    Friend WithEvents Alias_TXT As Tools.TXT
    Friend WithEvents Label49 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Name_TXT As Tools.TXT
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents Txt1 As Tools.TXT
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents e_yn As Tools.YN
    Friend WithEvents w_yn As Tools.YN
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label5 As Label
End Class
