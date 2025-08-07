<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Stock_Category_frm
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Alias_TXT = New Tools.TXT()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Name_TXT = New Tools.TXT()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.end_TXT = New Tools.TXT()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel5.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(333, 705)
        Me.Panel1.TabIndex = 4
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.Panel5)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(331, 703)
        Me.Panel2.TabIndex = 0
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Panel6)
        Me.Panel5.Controls.Add(Me.Label48)
        Me.Panel5.Controls.Add(Me.Panel7)
        Me.Panel5.Controls.Add(Me.Alias_TXT)
        Me.Panel5.Controls.Add(Me.Label15)
        Me.Panel5.Controls.Add(Me.Label49)
        Me.Panel5.Controls.Add(Me.Panel11)
        Me.Panel5.Controls.Add(Me.Label2)
        Me.Panel5.Controls.Add(Me.Label1)
        Me.Panel5.Controls.Add(Me.Name_TXT)
        Me.Panel5.Controls.Add(Me.end_TXT)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(331, 69)
        Me.Panel5.TabIndex = 105
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.DarkGray
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 18)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(331, 1)
        Me.Panel6.TabIndex = 93
        Me.Panel6.TabStop = True
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Location = New System.Drawing.Point(86, 43)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(11, 16)
        Me.Label48.TabIndex = 71
        Me.Label48.Text = ":"
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.DarkGray
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel7.Location = New System.Drawing.Point(0, 68)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(331, 1)
        Me.Panel7.TabIndex = 105
        Me.Panel7.TabStop = True
        '
        'Alias_TXT
        '
        Me.Alias_TXT.Auto_Cleane = True
        Me.Alias_TXT.Back_color = System.Drawing.Color.White
        Me.Alias_TXT.BackColor = System.Drawing.Color.White
        Me.Alias_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Alias_TXT.Data_Link_ = ""
        Me.Alias_TXT.Decimal_ = 2
        Me.Alias_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Alias_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Alias_TXT.Font_Size = 11
        Me.Alias_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Alias_TXT.Format_ = "dd-MM-yyyy"
        Me.Alias_TXT.Keydown_Support = True
        Me.Alias_TXT.Location = New System.Drawing.Point(101, 43)
        Me.Alias_TXT.Msg_Object = Nothing
        Me.Alias_TXT.Name = "Alias_TXT"
        Me.Alias_TXT.Select_Auto_Show = True
        Me.Alias_TXT.Select_Column_Color = "NA"
        Me.Alias_TXT.Select_Columns = 0
        Me.Alias_TXT.Select_Filter = Nothing
        Me.Alias_TXT.Select_Hide_Columns = "NA"
        Me.Alias_TXT.Select_Object = Nothing
        Me.Alias_TXT.Select_Source = Nothing
        Me.Alias_TXT.Size = New System.Drawing.Size(137, 15)
        Me.Alias_TXT.TabIndex = 1
        Me.Alias_TXT.Type_ = "TXT"
        Me.Alias_TXT.Val_max = 1000000000
        Me.Alias_TXT.Val_min = 0
        '
        'Label15
        '
        Me.Label15.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(0, 1)
        Me.Label15.Name = "Label15"
        Me.Label15.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Label15.Size = New System.Drawing.Size(331, 17)
        Me.Label15.TabIndex = 94
        Me.Label15.Text = "Name and alias"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.Location = New System.Drawing.Point(11, 43)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(34, 16)
        Me.Label49.TabIndex = 69
        Me.Label49.Text = "alias"
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.DarkGray
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel11.Location = New System.Drawing.Point(0, 0)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(331, 1)
        Me.Panel11.TabIndex = 92
        Me.Panel11.TabStop = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(86, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = ":"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 23)
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
        Me.Name_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Name_TXT.Font_Size = 11
        Me.Name_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Name_TXT.Format_ = "dd-MM-yyyy"
        Me.Name_TXT.Keydown_Support = True
        Me.Name_TXT.Location = New System.Drawing.Point(101, 23)
        Me.Name_TXT.Msg_Object = Nothing
        Me.Name_TXT.Name = "Name_TXT"
        Me.Name_TXT.Select_Auto_Show = True
        Me.Name_TXT.Select_Column_Color = "NA"
        Me.Name_TXT.Select_Columns = 0
        Me.Name_TXT.Select_Filter = Nothing
        Me.Name_TXT.Select_Hide_Columns = "NA"
        Me.Name_TXT.Select_Object = Nothing
        Me.Name_TXT.Select_Source = Nothing
        Me.Name_TXT.Size = New System.Drawing.Size(220, 15)
        Me.Name_TXT.TabIndex = 0
        Me.Name_TXT.Type_ = "TXT"
        Me.Name_TXT.Val_max = 1000000000
        Me.Name_TXT.Val_min = 0
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.DarkGray
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 702)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(331, 1)
        Me.Panel3.TabIndex = 30
        Me.Panel3.TabStop = True
        '
        'Panel4
        '
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(333, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1031, 705)
        Me.Panel4.TabIndex = 46
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'end_TXT
        '
        Me.end_TXT.Auto_Cleane = True
        Me.end_TXT.Back_color = System.Drawing.Color.White
        Me.end_TXT.BackColor = System.Drawing.Color.White
        Me.end_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.end_TXT.Data_Link_ = ""
        Me.end_TXT.Decimal_ = 2
        Me.end_TXT.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.end_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.end_TXT.Font_Size = 11
        Me.end_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.end_TXT.Format_ = "dd-MM-yyyy"
        Me.end_TXT.Keydown_Support = True
        Me.end_TXT.Location = New System.Drawing.Point(121, 75)
        Me.end_TXT.Msg_Object = Nothing
        Me.end_TXT.Name = "end_TXT"
        Me.end_TXT.Select_Auto_Show = True
        Me.end_TXT.Select_Column_Color = "NA"
        Me.end_TXT.Select_Columns = 0
        Me.end_TXT.Select_Filter = Nothing
        Me.end_TXT.Select_Hide_Columns = "NA"
        Me.end_TXT.Select_Object = Nothing
        Me.end_TXT.Select_Source = Nothing
        Me.end_TXT.Size = New System.Drawing.Size(88, 17)
        Me.end_TXT.TabIndex = 107
        Me.end_TXT.Type_ = "TXT"
        Me.end_TXT.Val_max = 1000000000
        Me.end_TXT.Val_min = 0
        '
        'Stock_Category_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1364, 705)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Stock_Category_frm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventory_Category_frm"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label48 As Label
    Friend WithEvents Alias_TXT As Tools.TXT
    Friend WithEvents Label49 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Name_TXT As Tools.TXT
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Label15 As Label
    Friend WithEvents Panel11 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents end_TXT As Tools.TXT
End Class
