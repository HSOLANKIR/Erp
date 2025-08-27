<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Communication_Direct_list_ctrl
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
        Me.Wh_TXT = New Tools.TXT()
        Me.Email_TXT = New Tools.TXT()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.wh_status = New System.Windows.Forms.Label()
        Me.email_status = New System.Windows.Forms.Label()
        Me.Name_TXT = New Tools.TXT()
        Me.SuspendLayout()
        '
        'Wh_TXT
        '
        Me.Wh_TXT.Auto_Cleane = True
        Me.Wh_TXT.Back_color = System.Drawing.Color.White
        Me.Wh_TXT.BackColor = System.Drawing.Color.White
        Me.Wh_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Wh_TXT.Data_Link_ = ""
        Me.Wh_TXT.Decimal_ = 2
        Me.Wh_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Wh_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Wh_TXT.Font_Size = 10
        Me.Wh_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Wh_TXT.Format_ = "dd-MM-yyyy"
        Me.Wh_TXT.Keydown_Support = True
        Me.Wh_TXT.Location = New System.Drawing.Point(187, 3)
        Me.Wh_TXT.Msg_Object = Nothing
        Me.Wh_TXT.Name = "Wh_TXT"
        Me.Wh_TXT.Select_Auto_Show = True
        Me.Wh_TXT.Select_Column_Color = "NA"
        Me.Wh_TXT.Select_Columns = 0
        Me.Wh_TXT.Select_Filter = Nothing
        Me.Wh_TXT.Select_Hide_Columns = "NA"
        Me.Wh_TXT.Select_Object = Nothing
        Me.Wh_TXT.Select_Source = Nothing
        Me.Wh_TXT.Size = New System.Drawing.Size(129, 15)
        Me.Wh_TXT.TabIndex = 1
        Me.Wh_TXT.Type_ = "TXT"
        Me.Wh_TXT.Val_max = 1000000000
        Me.Wh_TXT.Val_min = 0
        '
        'Email_TXT
        '
        Me.Email_TXT.Auto_Cleane = True
        Me.Email_TXT.Back_color = System.Drawing.Color.White
        Me.Email_TXT.BackColor = System.Drawing.Color.White
        Me.Email_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Email_TXT.Data_Link_ = ""
        Me.Email_TXT.Decimal_ = 2
        Me.Email_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Email_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Email_TXT.Font_Size = 10
        Me.Email_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Email_TXT.Format_ = "dd-MM-yyyy"
        Me.Email_TXT.Keydown_Support = True
        Me.Email_TXT.Location = New System.Drawing.Point(322, 3)
        Me.Email_TXT.Msg_Object = Nothing
        Me.Email_TXT.Name = "Email_TXT"
        Me.Email_TXT.Select_Auto_Show = True
        Me.Email_TXT.Select_Column_Color = "NA"
        Me.Email_TXT.Select_Columns = 0
        Me.Email_TXT.Select_Filter = Nothing
        Me.Email_TXT.Select_Hide_Columns = "NA"
        Me.Email_TXT.Select_Object = Nothing
        Me.Email_TXT.Select_Source = Nothing
        Me.Email_TXT.Size = New System.Drawing.Size(257, 15)
        Me.Email_TXT.TabIndex = 2
        Me.Email_TXT.Type_ = "TXT"
        Me.Email_TXT.Val_max = 1000000000
        Me.Email_TXT.Val_min = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightGray
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 40)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(583, 1)
        Me.Panel1.TabIndex = 5
        '
        'wh_status
        '
        Me.wh_status.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.wh_status.ForeColor = System.Drawing.Color.OrangeRed
        Me.wh_status.Location = New System.Drawing.Point(188, 22)
        Me.wh_status.Name = "wh_status"
        Me.wh_status.Size = New System.Drawing.Size(128, 16)
        Me.wh_status.TabIndex = 6
        Me.wh_status.Text = "Pending"
        '
        'email_status
        '
        Me.email_status.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.email_status.ForeColor = System.Drawing.Color.OrangeRed
        Me.email_status.Location = New System.Drawing.Point(322, 22)
        Me.email_status.Name = "email_status"
        Me.email_status.Size = New System.Drawing.Size(257, 16)
        Me.email_status.TabIndex = 7
        Me.email_status.Text = "Pending"
        '
        'Name_TXT
        '
        Me.Name_TXT.Auto_Cleane = True
        Me.Name_TXT.Back_color = System.Drawing.Color.White
        Me.Name_TXT.BackColor = System.Drawing.Color.White
        Me.Name_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Name_TXT.Data_Link_ = ""
        Me.Name_TXT.Decimal_ = 2
        Me.Name_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Name_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Name_TXT.Font_Size = 10
        Me.Name_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Name_TXT.Format_ = "dd-MM-yyyy"
        Me.Name_TXT.Keydown_Support = True
        Me.Name_TXT.Location = New System.Drawing.Point(3, 3)
        Me.Name_TXT.Msg_Object = Nothing
        Me.Name_TXT.Name = "Name_TXT"
        Me.Name_TXT.Select_Auto_Show = True
        Me.Name_TXT.Select_Column_Color = "NA"
        Me.Name_TXT.Select_Columns = 0
        Me.Name_TXT.Select_Filter = "Name LIKE '%<value>%' or Alias LIKE '%<value>%' or WhatsApp LIKE '%<value>%' or E" &
    "mail LIKE '%<value>%' or (Alias LIKE 'End of List' or Alias LIKE 'Custom')"
        Me.Name_TXT.Select_Hide_Columns = "NA"
        Me.Name_TXT.Select_Object = Nothing
        Me.Name_TXT.Select_Source = Nothing
        Me.Name_TXT.Size = New System.Drawing.Size(177, 15)
        Me.Name_TXT.TabIndex = 0
        Me.Name_TXT.Type_ = "Select"
        Me.Name_TXT.Val_max = 1000000000
        Me.Name_TXT.Val_min = 0
        '
        'Communication_Direct_list_ctrl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.Name_TXT)
        Me.Controls.Add(Me.email_status)
        Me.Controls.Add(Me.wh_status)
        Me.Controls.Add(Me.Email_TXT)
        Me.Controls.Add(Me.Wh_TXT)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Communication_Direct_list_ctrl"
        Me.Size = New System.Drawing.Size(583, 41)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Wh_TXT As Tools.TXT
    Friend WithEvents Email_TXT As Tools.TXT
    Friend WithEvents Panel1 As Panel
    Friend WithEvents wh_status As Label
    Friend WithEvents email_status As Label
    Friend WithEvents Name_TXT As Tools.TXT
End Class
