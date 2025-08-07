<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Device_Features_ctrl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.Defolt_Print_Panel = New System.Windows.Forms.Panel()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Defolt_Printer_Select = New Tools.TXT()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Panel23 = New System.Windows.Forms.Panel()
        Me.Panel24 = New System.Windows.Forms.Panel()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Auto_Logout_TXT = New Tools.TXT()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Yn4 = New Tools.YN()
        Me.Printer_Source = New System.Windows.Forms.BindingSource(Me.components)
        Me.Defolt_Print_Panel.SuspendLayout()
        Me.Panel23.SuspendLayout()
        Me.Panel24.SuspendLayout()
        CType(Me.Printer_Source, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Defolt_Print_Panel
        '
        Me.Defolt_Print_Panel.AutoSize = True
        Me.Defolt_Print_Panel.Controls.Add(Me.Label16)
        Me.Defolt_Print_Panel.Controls.Add(Me.Defolt_Printer_Select)
        Me.Defolt_Print_Panel.Controls.Add(Me.Label15)
        Me.Defolt_Print_Panel.Dock = System.Windows.Forms.DockStyle.Top
        Me.Defolt_Print_Panel.Location = New System.Drawing.Point(0, 0)
        Me.Defolt_Print_Panel.Name = "Defolt_Print_Panel"
        Me.Defolt_Print_Panel.Size = New System.Drawing.Size(499, 21)
        Me.Defolt_Print_Panel.TabIndex = 6
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label16.Location = New System.Drawing.Point(210, 0)
        Me.Label16.Margin = New System.Windows.Forms.Padding(1)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(15, 16)
        Me.Label16.TabIndex = 5
        Me.Label16.Text = ": "
        '
        'Defolt_Printer_Select
        '
        Me.Defolt_Printer_Select.Auto_Cleane = True
        Me.Defolt_Printer_Select.Back_color = System.Drawing.Color.White
        Me.Defolt_Printer_Select.BackColor = System.Drawing.Color.White
        Me.Defolt_Printer_Select.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Defolt_Printer_Select.Data_Link_ = "Defolt Printer"
        Me.Defolt_Printer_Select.Decimal_ = 2
        Me.Defolt_Printer_Select.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Defolt_Printer_Select.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Defolt_Printer_Select.Font_Size = 10
        Me.Defolt_Printer_Select.Font_Style = System.Drawing.FontStyle.Bold
        Me.Defolt_Printer_Select.Format_ = "dd-MM-yyyy"
        Me.Defolt_Printer_Select.Keydown_Support = True
        Me.Defolt_Printer_Select.Location = New System.Drawing.Point(234, 3)
        Me.Defolt_Printer_Select.Msg_Object = Nothing
        Me.Defolt_Printer_Select.Name = "Defolt_Printer_Select"
        Me.Defolt_Printer_Select.Select_Auto_Show = True
        Me.Defolt_Printer_Select.Select_Column_Color = "NA"
        Me.Defolt_Printer_Select.Select_Columns = 0
        Me.Defolt_Printer_Select.Select_Filter = "Name LIKE '%<value>%'"
        Me.Defolt_Printer_Select.Select_Hide_Columns = "NA"
        Me.Defolt_Printer_Select.Select_Object = Nothing
        Me.Defolt_Printer_Select.Select_Source = Nothing
        Me.Defolt_Printer_Select.Size = New System.Drawing.Size(163, 15)
        Me.Defolt_Printer_Select.TabIndex = 9
        Me.Defolt_Printer_Select.Type_ = "Select"
        Me.Defolt_Printer_Select.Val_max = 1000000000
        Me.Defolt_Printer_Select.Val_min = 0
        '
        'Label15
        '
        Me.Label15.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(0, 0)
        Me.Label15.Margin = New System.Windows.Forms.Padding(1)
        Me.Label15.Name = "Label15"
        Me.Label15.Padding = New System.Windows.Forms.Padding(8, 0, 0, 0)
        Me.Label15.Size = New System.Drawing.Size(210, 21)
        Me.Label15.TabIndex = 3
        Me.Label15.Text = "Defolt Printer"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel23
        '
        Me.Panel23.AutoSize = True
        Me.Panel23.Controls.Add(Me.Panel24)
        Me.Panel23.Controls.Add(Me.Label25)
        Me.Panel23.Controls.Add(Me.Label26)
        Me.Panel23.Controls.Add(Me.Yn4)
        Me.Panel23.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel23.Location = New System.Drawing.Point(0, 21)
        Me.Panel23.Name = "Panel23"
        Me.Panel23.Size = New System.Drawing.Size(499, 21)
        Me.Panel23.TabIndex = 9
        '
        'Panel24
        '
        Me.Panel24.Controls.Add(Me.Label28)
        Me.Panel24.Controls.Add(Me.Auto_Logout_TXT)
        Me.Panel24.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel24.Location = New System.Drawing.Point(268, 0)
        Me.Panel24.Name = "Panel24"
        Me.Panel24.Size = New System.Drawing.Size(231, 21)
        Me.Panel24.TabIndex = 9
        Me.Panel24.Visible = False
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(186, 2)
        Me.Label28.Margin = New System.Windows.Forms.Padding(1)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(34, 16)
        Me.Label28.TabIndex = 11
        Me.Label28.Text = "Sec."
        '
        'Auto_Logout_TXT
        '
        Me.Auto_Logout_TXT.Auto_Cleane = True
        Me.Auto_Logout_TXT.Back_color = System.Drawing.Color.White
        Me.Auto_Logout_TXT.BackColor = System.Drawing.Color.White
        Me.Auto_Logout_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Auto_Logout_TXT.Data_Link_ = "Positive Value"
        Me.Auto_Logout_TXT.Decimal_ = 0
        Me.Auto_Logout_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Auto_Logout_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Auto_Logout_TXT.Font_Size = 10
        Me.Auto_Logout_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Auto_Logout_TXT.Format_ = "dd-MM-yyyy"
        Me.Auto_Logout_TXT.Keydown_Support = True
        Me.Auto_Logout_TXT.Location = New System.Drawing.Point(142, 3)
        Me.Auto_Logout_TXT.Msg_Object = Nothing
        Me.Auto_Logout_TXT.Name = "Auto_Logout_TXT"
        Me.Auto_Logout_TXT.Select_Auto_Show = True
        Me.Auto_Logout_TXT.Select_Column_Color = "NA"
        Me.Auto_Logout_TXT.Select_Columns = 0
        Me.Auto_Logout_TXT.Select_Filter = Nothing
        Me.Auto_Logout_TXT.Select_Hide_Columns = "NA"
        Me.Auto_Logout_TXT.Select_Object = Nothing
        Me.Auto_Logout_TXT.Select_Source = Nothing
        Me.Auto_Logout_TXT.Size = New System.Drawing.Size(40, 15)
        Me.Auto_Logout_TXT.TabIndex = 10
        Me.Auto_Logout_TXT.Text = "300"
        Me.Auto_Logout_TXT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Auto_Logout_TXT.Type_ = "Num"
        Me.Auto_Logout_TXT.Val_max = 1000000000
        Me.Auto_Logout_TXT.Val_min = 0
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label25.Location = New System.Drawing.Point(210, 0)
        Me.Label25.Margin = New System.Windows.Forms.Padding(1)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(15, 16)
        Me.Label25.TabIndex = 5
        Me.Label25.Text = ": "
        '
        'Label26
        '
        Me.Label26.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label26.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label26.Location = New System.Drawing.Point(0, 0)
        Me.Label26.Margin = New System.Windows.Forms.Padding(1)
        Me.Label26.Name = "Label26"
        Me.Label26.Padding = New System.Windows.Forms.Padding(8, 0, 0, 0)
        Me.Label26.Size = New System.Drawing.Size(210, 21)
        Me.Label26.TabIndex = 3
        Me.Label26.Text = "Auto Loagout"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Yn4
        '
        Me.Yn4.Back_color = System.Drawing.Color.White
        Me.Yn4.BackColor = System.Drawing.Color.White
        Me.Yn4.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Yn4.Data_Link_ = "Auto_Backup_YN"
        Me.Yn4.Defolt_ = "No"
        Me.Yn4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Yn4.Font_ = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Yn4.Location = New System.Drawing.Point(234, 5)
        Me.Yn4.Margin = New System.Windows.Forms.Padding(1)
        Me.Yn4.Name = "Yn4"
        Me.Yn4.ReadOnly = True
        Me.Yn4.Size = New System.Drawing.Size(39, 15)
        Me.Yn4.TabIndex = 6
        Me.Yn4.Text = "No"
        '
        'Device_Features_ctrl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.Panel23)
        Me.Controls.Add(Me.Defolt_Print_Panel)
        Me.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Device_Features_ctrl"
        Me.Size = New System.Drawing.Size(499, 57)
        Me.Defolt_Print_Panel.ResumeLayout(False)
        Me.Defolt_Print_Panel.PerformLayout()
        Me.Panel23.ResumeLayout(False)
        Me.Panel23.PerformLayout()
        Me.Panel24.ResumeLayout(False)
        Me.Panel24.PerformLayout()
        CType(Me.Printer_Source, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Defolt_Print_Panel As Panel
    Friend WithEvents Label16 As Label
    Friend WithEvents Defolt_Printer_Select As Tools.TXT
    Friend WithEvents Label15 As Label
    Friend WithEvents Panel23 As Panel
    Friend WithEvents Panel24 As Panel
    Friend WithEvents Label28 As Label
    Friend WithEvents Auto_Logout_TXT As Tools.TXT
    Friend WithEvents Label25 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents Yn4 As Tools.YN
    Friend WithEvents Printer_Source As BindingSource
End Class
