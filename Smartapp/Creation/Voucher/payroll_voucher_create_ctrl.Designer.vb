<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class payroll_voucher_create_ctrl
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Panel19 = New System.Windows.Forms.Panel()
        Me.Credit_Limit_Warning = New Tools.YN()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Panel20 = New System.Windows.Forms.Panel()
        Me.duplicate_YN = New Tools.YN()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.narration_YN = New Tools.YN()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel27 = New System.Windows.Forms.Panel()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel19.SuspendLayout()
        Me.Panel20.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel27.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BackColor = System.Drawing.Color.Beige
        Me.Panel1.Controls.Add(Me.Panel8)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(326, 452)
        Me.Panel1.TabIndex = 1
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.Panel19)
        Me.Panel8.Controls.Add(Me.Panel20)
        Me.Panel8.Controls.Add(Me.Panel3)
        Me.Panel8.Controls.Add(Me.Panel27)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel8.Location = New System.Drawing.Point(0, 0)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(325, 216)
        Me.Panel8.TabIndex = 87
        '
        'Panel19
        '
        Me.Panel19.AutoSize = True
        Me.Panel19.Controls.Add(Me.Credit_Limit_Warning)
        Me.Panel19.Controls.Add(Me.Label27)
        Me.Panel19.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel19.Location = New System.Drawing.Point(0, 59)
        Me.Panel19.Name = "Panel19"
        Me.Panel19.Size = New System.Drawing.Size(325, 21)
        Me.Panel19.TabIndex = 100
        '
        'Credit_Limit_Warning
        '
        Me.Credit_Limit_Warning.Back_color = System.Drawing.Color.Beige
        Me.Credit_Limit_Warning.BackColor = System.Drawing.Color.Beige
        Me.Credit_Limit_Warning.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Credit_Limit_Warning.Data_Link_ = "YN_Account_Details_Alter"
        Me.Credit_Limit_Warning.Defolt_ = "No"
        Me.Credit_Limit_Warning.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Credit_Limit_Warning.Location = New System.Drawing.Point(278, 3)
        Me.Credit_Limit_Warning.Name = "Credit_Limit_Warning"
        Me.Credit_Limit_Warning.ReadOnly = True
        Me.Credit_Limit_Warning.Size = New System.Drawing.Size(42, 15)
        Me.Credit_Limit_Warning.TabIndex = 103
        Me.Credit_Limit_Warning.Text = "No"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(18, 3)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(125, 16)
        Me.Label27.TabIndex = 0
        Me.Label27.Text = "Credit Limit Warning"
        Me.Label27.UseMnemonic = False
        '
        'Panel20
        '
        Me.Panel20.AutoSize = True
        Me.Panel20.Controls.Add(Me.duplicate_YN)
        Me.Panel20.Controls.Add(Me.Label15)
        Me.Panel20.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel20.Location = New System.Drawing.Point(0, 37)
        Me.Panel20.Name = "Panel20"
        Me.Panel20.Size = New System.Drawing.Size(325, 22)
        Me.Panel20.TabIndex = 97
        '
        'duplicate_YN
        '
        Me.duplicate_YN.Back_color = System.Drawing.Color.Beige
        Me.duplicate_YN.BackColor = System.Drawing.Color.Beige
        Me.duplicate_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.duplicate_YN.Data_Link_ = ""
        Me.duplicate_YN.Defolt_ = "No"
        Me.duplicate_YN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.duplicate_YN.Location = New System.Drawing.Point(278, 4)
        Me.duplicate_YN.Name = "duplicate_YN"
        Me.duplicate_YN.ReadOnly = True
        Me.duplicate_YN.Size = New System.Drawing.Size(42, 15)
        Me.duplicate_YN.TabIndex = 103
        Me.duplicate_YN.Text = "No"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(18, 4)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(158, 16)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "allow duplicate voucher no"
        '
        'Panel3
        '
        Me.Panel3.AutoSize = True
        Me.Panel3.Controls.Add(Me.narration_YN)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 15)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(325, 22)
        Me.Panel3.TabIndex = 96
        '
        'narration_YN
        '
        Me.narration_YN.Back_color = System.Drawing.Color.Beige
        Me.narration_YN.BackColor = System.Drawing.Color.Beige
        Me.narration_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.narration_YN.Data_Link_ = ""
        Me.narration_YN.Defolt_ = "No"
        Me.narration_YN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.narration_YN.Location = New System.Drawing.Point(278, 4)
        Me.narration_YN.Name = "narration_YN"
        Me.narration_YN.ReadOnly = True
        Me.narration_YN.Size = New System.Drawing.Size(42, 15)
        Me.narration_YN.TabIndex = 103
        Me.narration_YN.Text = "Yes"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(18, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(152, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "allow narration in voucher"
        '
        'Panel27
        '
        Me.Panel27.Controls.Add(Me.Label18)
        Me.Panel27.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel27.Location = New System.Drawing.Point(0, 0)
        Me.Panel27.Name = "Panel27"
        Me.Panel27.Size = New System.Drawing.Size(325, 15)
        Me.Panel27.TabIndex = 98
        '
        'Label18
        '
        Me.Label18.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label18.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.Label18.Location = New System.Drawing.Point(0, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(325, 15)
        Me.Label18.TabIndex = 94
        Me.Label18.Text = "Vouchers details"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Silver
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(325, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1, 452)
        Me.Panel2.TabIndex = 88
        '
        'payroll_voucher_create_ctrl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "payroll_voucher_create_ctrl"
        Me.Size = New System.Drawing.Size(917, 452)
        Me.Panel1.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.Panel19.ResumeLayout(False)
        Me.Panel19.PerformLayout()
        Me.Panel20.ResumeLayout(False)
        Me.Panel20.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel27.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Panel19 As Panel
    Friend WithEvents Credit_Limit_Warning As Tools.YN
    Friend WithEvents Label27 As Label
    Friend WithEvents Panel20 As Panel
    Friend WithEvents duplicate_YN As Tools.YN
    Friend WithEvents Label15 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents narration_YN As Tools.YN
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel27 As Panel
    Friend WithEvents Label18 As Label
    Friend WithEvents Panel2 As Panel
End Class
