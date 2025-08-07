<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CPR_Ctrl
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
        Me.Particuls_TXT = New Tools.TXT()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Amount_Panel = New System.Windows.Forms.Panel()
        Me.Amount_TXT = New Tools.TXT()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Narration_TXT = New Tools.TXT()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Amount_Panel.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Particuls_TXT
        '
        Me.Particuls_TXT.Auto_Cleane = True
        Me.Particuls_TXT.Back_color = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Particuls_TXT.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Particuls_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Particuls_TXT.Data_Link_ = ""
        Me.Particuls_TXT.Decimal_ = 2
        Me.Particuls_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Particuls_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Particuls_TXT.Font_Size = 10
        Me.Particuls_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Particuls_TXT.Format_ = "dd-MM-yyyy"
        Me.Particuls_TXT.Keydown_Support = False
        Me.Particuls_TXT.Location = New System.Drawing.Point(7, 5)
        Me.Particuls_TXT.Msg_Object = Nothing
        Me.Particuls_TXT.Name = "Particuls_TXT"
        Me.Particuls_TXT.Select_Auto_Show = True
        Me.Particuls_TXT.Select_Column_Color = "NA"
        Me.Particuls_TXT.Select_Columns = 0
        Me.Particuls_TXT.Select_Filter = Nothing
        Me.Particuls_TXT.Select_Hide_Columns = "NA"
        Me.Particuls_TXT.Select_Object = Nothing
        Me.Particuls_TXT.Select_Source = Nothing
        Me.Particuls_TXT.Size = New System.Drawing.Size(358, 15)
        Me.Particuls_TXT.TabIndex = 1
        Me.Particuls_TXT.Type_ = "TXT"
        Me.Particuls_TXT.Val_max = 1000000000
        Me.Particuls_TXT.Val_min = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Particuls_TXT)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(500, 43)
        Me.Panel1.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DimGray
        Me.Label6.Location = New System.Drawing.Point(114, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(11, 16)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = ":"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DimGray
        Me.Label4.Location = New System.Drawing.Point(131, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(124, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "0.00"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(6, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Curr. Bal."
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Amount_Panel
        '
        Me.Amount_Panel.Controls.Add(Me.Amount_TXT)
        Me.Amount_Panel.Dock = System.Windows.Forms.DockStyle.Right
        Me.Amount_Panel.Location = New System.Drawing.Point(500, 0)
        Me.Amount_Panel.Name = "Amount_Panel"
        Me.Amount_Panel.Size = New System.Drawing.Size(120, 43)
        Me.Amount_Panel.TabIndex = 2
        '
        'Amount_TXT
        '
        Me.Amount_TXT.Auto_Cleane = True
        Me.Amount_TXT.Back_color = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Amount_TXT.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Amount_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Amount_TXT.Data_Link_ = ""
        Me.Amount_TXT.Decimal_ = 2
        Me.Amount_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Amount_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Amount_TXT.Font_Size = 10
        Me.Amount_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Amount_TXT.Format_ = "dd-MM-yyyy"
        Me.Amount_TXT.Keydown_Support = True
        Me.Amount_TXT.Location = New System.Drawing.Point(9, 5)
        Me.Amount_TXT.Msg_Object = Nothing
        Me.Amount_TXT.Name = "Amount_TXT"
        Me.Amount_TXT.Select_Auto_Show = True
        Me.Amount_TXT.Select_Column_Color = "NA"
        Me.Amount_TXT.Select_Columns = 0
        Me.Amount_TXT.Select_Filter = Nothing
        Me.Amount_TXT.Select_Hide_Columns = "NA"
        Me.Amount_TXT.Select_Object = Nothing
        Me.Amount_TXT.Select_Source = Nothing
        Me.Amount_TXT.Size = New System.Drawing.Size(108, 15)
        Me.Amount_TXT.TabIndex = 1
        Me.Amount_TXT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Amount_TXT.Type_ = "Num"
        Me.Amount_TXT.Val_max = 1000000000
        Me.Amount_TXT.Val_min = 0
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Panel1)
        Me.Panel3.Controls.Add(Me.Amount_Panel)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(620, 44)
        Me.Panel3.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Silver
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 43)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(620, 1)
        Me.Panel4.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(114, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(11, 16)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = ":"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Narration_TXT
        '
        Me.Narration_TXT.Auto_Cleane = True
        Me.Narration_TXT.Back_color = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Narration_TXT.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Narration_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Narration_TXT.Data_Link_ = ""
        Me.Narration_TXT.Decimal_ = 2
        Me.Narration_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Narration_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Narration_TXT.Font_Size = 10
        Me.Narration_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Narration_TXT.Format_ = "dd-MM-yyyy"
        Me.Narration_TXT.Keydown_Support = True
        Me.Narration_TXT.Location = New System.Drawing.Point(131, 49)
        Me.Narration_TXT.Msg_Object = Nothing
        Me.Narration_TXT.Name = "Narration_TXT"
        Me.Narration_TXT.Select_Auto_Show = True
        Me.Narration_TXT.Select_Column_Color = "NA"
        Me.Narration_TXT.Select_Columns = 0
        Me.Narration_TXT.Select_Filter = Nothing
        Me.Narration_TXT.Select_Hide_Columns = "NA"
        Me.Narration_TXT.Select_Object = Nothing
        Me.Narration_TXT.Select_Source = Nothing
        Me.Narration_TXT.Size = New System.Drawing.Size(486, 15)
        Me.Narration_TXT.TabIndex = 6
        Me.Narration_TXT.Type_ = "TXT"
        Me.Narration_TXT.Val_max = 1000000000
        Me.Narration_TXT.Val_min = 0
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(6, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 16)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Narration"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CPR_Ctrl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Narration_TXT)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Panel3)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "CPR_Ctrl"
        Me.Size = New System.Drawing.Size(620, 68)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Amount_Panel.ResumeLayout(False)
        Me.Amount_Panel.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Particuls_TXT As Tools.TXT
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Amount_Panel As Panel
    Friend WithEvents Amount_TXT As Tools.TXT
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents Narration_TXT As Tools.TXT
    Friend WithEvents Label8 As Label
End Class
