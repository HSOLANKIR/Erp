<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Account_Features_ctrl
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
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Account_YN = New Tools.YN()
        Me.Panel21 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.Journal_P = New System.Windows.Forms.Panel()
        Me.Journal_YN = New Tools.YN()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Receipt_P = New System.Windows.Forms.Panel()
        Me.Receipt_YN = New Tools.YN()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Payment_P = New System.Windows.Forms.Panel()
        Me.Payment_YN = New Tools.YN()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Contra_P = New System.Windows.Forms.Panel()
        Me.Contra_YN = New Tools.YN()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Panel19 = New System.Windows.Forms.Panel()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel9.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel14.SuspendLayout()
        Me.Journal_P.SuspendLayout()
        Me.Receipt_P.SuspendLayout()
        Me.Payment_P.SuspendLayout()
        Me.Contra_P.SuspendLayout()
        Me.Panel19.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel9
        '
        Me.Panel9.Controls.Add(Me.Label14)
        Me.Panel9.Controls.Add(Me.Account_YN)
        Me.Panel9.Controls.Add(Me.Panel21)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel9.Location = New System.Drawing.Point(0, 0)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(580, 20)
        Me.Panel9.TabIndex = 10004
        '
        'Label14
        '
        Me.Label14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(0, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Padding = New System.Windows.Forms.Padding(9, 0, 0, 0)
        Me.Label14.Size = New System.Drawing.Size(536, 19)
        Me.Label14.TabIndex = 94
        Me.Label14.Text = "Maintain Account"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Account_YN
        '
        Me.Account_YN.Back_color = System.Drawing.Color.White
        Me.Account_YN.BackColor = System.Drawing.Color.White
        Me.Account_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Account_YN.Data_Link_ = "Account_YN"
        Me.Account_YN.Defolt_ = "No"
        Me.Account_YN.Dock = System.Windows.Forms.DockStyle.Right
        Me.Account_YN.Font = New System.Drawing.Font("Arial", 11.0!)
        Me.Account_YN.Font_ = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Account_YN.Location = New System.Drawing.Point(536, 0)
        Me.Account_YN.Name = "Account_YN"
        Me.Account_YN.ReadOnly = True
        Me.Account_YN.Size = New System.Drawing.Size(44, 17)
        Me.Account_YN.TabIndex = 0
        Me.Account_YN.Text = "No"
        Me.Account_YN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel21
        '
        Me.Panel21.BackColor = System.Drawing.Color.LightGray
        Me.Panel21.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel21.Location = New System.Drawing.Point(0, 19)
        Me.Panel21.Name = "Panel21"
        Me.Panel21.Size = New System.Drawing.Size(580, 1)
        Me.Panel21.TabIndex = 95
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 260.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel4, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 20)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(580, 247)
        Me.TableLayoutPanel1.TabIndex = 10005
        Me.TableLayoutPanel1.Visible = False
        '
        'Panel3
        '
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(320, 247)
        Me.Panel3.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Panel14)
        Me.Panel4.Controls.Add(Me.Panel6)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(320, 0)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(260, 247)
        Me.Panel4.TabIndex = 1
        '
        'Panel14
        '
        Me.Panel14.AutoSize = True
        Me.Panel14.Controls.Add(Me.Journal_P)
        Me.Panel14.Controls.Add(Me.Receipt_P)
        Me.Panel14.Controls.Add(Me.Payment_P)
        Me.Panel14.Controls.Add(Me.Contra_P)
        Me.Panel14.Controls.Add(Me.Panel19)
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel14.Location = New System.Drawing.Point(1, 0)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(259, 90)
        Me.Panel14.TabIndex = 3
        '
        'Journal_P
        '
        Me.Journal_P.AutoSize = True
        Me.Journal_P.Controls.Add(Me.Journal_YN)
        Me.Journal_P.Controls.Add(Me.Label30)
        Me.Journal_P.Controls.Add(Me.Label31)
        Me.Journal_P.Dock = System.Windows.Forms.DockStyle.Top
        Me.Journal_P.Location = New System.Drawing.Point(0, 72)
        Me.Journal_P.Name = "Journal_P"
        Me.Journal_P.Size = New System.Drawing.Size(259, 18)
        Me.Journal_P.TabIndex = 8
        '
        'Journal_YN
        '
        Me.Journal_YN.Back_color = System.Drawing.Color.White
        Me.Journal_YN.BackColor = System.Drawing.Color.White
        Me.Journal_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Journal_YN.Data_Link_ = "Journal_YN"
        Me.Journal_YN.Defolt_ = "No"
        Me.Journal_YN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Journal_YN.Font_ = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Journal_YN.Location = New System.Drawing.Point(210, 2)
        Me.Journal_YN.Margin = New System.Windows.Forms.Padding(1)
        Me.Journal_YN.Name = "Journal_YN"
        Me.Journal_YN.ReadOnly = True
        Me.Journal_YN.Size = New System.Drawing.Size(39, 15)
        Me.Journal_YN.TabIndex = 9
        Me.Journal_YN.Text = "No"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(188, -1)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(15, 16)
        Me.Label30.TabIndex = 8
        Me.Label30.Text = ": "
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.Black
        Me.Label31.Location = New System.Drawing.Point(14, -1)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(108, 16)
        Me.Label31.TabIndex = 7
        Me.Label31.Text = "Journal Vouchers"
        '
        'Receipt_P
        '
        Me.Receipt_P.AutoSize = True
        Me.Receipt_P.Controls.Add(Me.Receipt_YN)
        Me.Receipt_P.Controls.Add(Me.Label24)
        Me.Receipt_P.Controls.Add(Me.Label25)
        Me.Receipt_P.Dock = System.Windows.Forms.DockStyle.Top
        Me.Receipt_P.Location = New System.Drawing.Point(0, 54)
        Me.Receipt_P.Name = "Receipt_P"
        Me.Receipt_P.Size = New System.Drawing.Size(259, 18)
        Me.Receipt_P.TabIndex = 7
        '
        'Receipt_YN
        '
        Me.Receipt_YN.Back_color = System.Drawing.Color.White
        Me.Receipt_YN.BackColor = System.Drawing.Color.White
        Me.Receipt_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Receipt_YN.Data_Link_ = "Receipt_YN"
        Me.Receipt_YN.Defolt_ = "No"
        Me.Receipt_YN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Receipt_YN.Font_ = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Receipt_YN.Location = New System.Drawing.Point(210, 2)
        Me.Receipt_YN.Margin = New System.Windows.Forms.Padding(1)
        Me.Receipt_YN.Name = "Receipt_YN"
        Me.Receipt_YN.ReadOnly = True
        Me.Receipt_YN.Size = New System.Drawing.Size(39, 15)
        Me.Receipt_YN.TabIndex = 9
        Me.Receipt_YN.Text = "No"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(188, -1)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(15, 16)
        Me.Label24.TabIndex = 8
        Me.Label24.Text = ": "
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Black
        Me.Label25.Location = New System.Drawing.Point(14, -1)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(110, 16)
        Me.Label25.TabIndex = 7
        Me.Label25.Text = "Receipt Vouchers"
        '
        'Payment_P
        '
        Me.Payment_P.AutoSize = True
        Me.Payment_P.Controls.Add(Me.Payment_YN)
        Me.Payment_P.Controls.Add(Me.Label22)
        Me.Payment_P.Controls.Add(Me.Label23)
        Me.Payment_P.Dock = System.Windows.Forms.DockStyle.Top
        Me.Payment_P.Location = New System.Drawing.Point(0, 36)
        Me.Payment_P.Name = "Payment_P"
        Me.Payment_P.Size = New System.Drawing.Size(259, 18)
        Me.Payment_P.TabIndex = 6
        '
        'Payment_YN
        '
        Me.Payment_YN.Back_color = System.Drawing.Color.White
        Me.Payment_YN.BackColor = System.Drawing.Color.White
        Me.Payment_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Payment_YN.Data_Link_ = "Payment_YN"
        Me.Payment_YN.Defolt_ = "No"
        Me.Payment_YN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Payment_YN.Font_ = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Payment_YN.Location = New System.Drawing.Point(210, 2)
        Me.Payment_YN.Margin = New System.Windows.Forms.Padding(1)
        Me.Payment_YN.Name = "Payment_YN"
        Me.Payment_YN.ReadOnly = True
        Me.Payment_YN.Size = New System.Drawing.Size(39, 15)
        Me.Payment_YN.TabIndex = 9
        Me.Payment_YN.Text = "No"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(188, -1)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(15, 16)
        Me.Label22.TabIndex = 8
        Me.Label22.Text = ": "
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(14, -1)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(117, 16)
        Me.Label23.TabIndex = 7
        Me.Label23.Text = "Payment Vouchers"
        '
        'Contra_P
        '
        Me.Contra_P.AutoSize = True
        Me.Contra_P.Controls.Add(Me.Contra_YN)
        Me.Contra_P.Controls.Add(Me.Label20)
        Me.Contra_P.Controls.Add(Me.Label21)
        Me.Contra_P.Dock = System.Windows.Forms.DockStyle.Top
        Me.Contra_P.Location = New System.Drawing.Point(0, 18)
        Me.Contra_P.Name = "Contra_P"
        Me.Contra_P.Size = New System.Drawing.Size(259, 18)
        Me.Contra_P.TabIndex = 5
        '
        'Contra_YN
        '
        Me.Contra_YN.Back_color = System.Drawing.Color.White
        Me.Contra_YN.BackColor = System.Drawing.Color.White
        Me.Contra_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Contra_YN.Data_Link_ = "Contra_YN"
        Me.Contra_YN.Defolt_ = "No"
        Me.Contra_YN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Contra_YN.Font_ = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Contra_YN.Location = New System.Drawing.Point(210, 2)
        Me.Contra_YN.Margin = New System.Windows.Forms.Padding(1)
        Me.Contra_YN.Name = "Contra_YN"
        Me.Contra_YN.ReadOnly = True
        Me.Contra_YN.Size = New System.Drawing.Size(39, 15)
        Me.Contra_YN.TabIndex = 9
        Me.Contra_YN.Text = "No"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(188, -1)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(15, 16)
        Me.Label20.TabIndex = 8
        Me.Label20.Text = ": "
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(14, -1)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(104, 16)
        Me.Label21.TabIndex = 7
        Me.Label21.Text = "Contra Vouchers"
        '
        'Panel19
        '
        Me.Panel19.Controls.Add(Me.Label36)
        Me.Panel19.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel19.Location = New System.Drawing.Point(0, 0)
        Me.Panel19.Name = "Panel19"
        Me.Panel19.Size = New System.Drawing.Size(259, 18)
        Me.Panel19.TabIndex = 0
        '
        'Label36
        '
        Me.Label36.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label36.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(0, 0)
        Me.Label36.Margin = New System.Windows.Forms.Padding(1)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(259, 18)
        Me.Label36.TabIndex = 3
        Me.Label36.Text = "Accounting Vouchers"
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.LightGray
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1, 247)
        Me.Panel6.TabIndex = 4
        '
        'Account_Features_ctrl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Panel9)
        Me.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Account_Features_ctrl"
        Me.Size = New System.Drawing.Size(580, 267)
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel14.ResumeLayout(False)
        Me.Panel14.PerformLayout()
        Me.Journal_P.ResumeLayout(False)
        Me.Journal_P.PerformLayout()
        Me.Receipt_P.ResumeLayout(False)
        Me.Receipt_P.PerformLayout()
        Me.Payment_P.ResumeLayout(False)
        Me.Payment_P.PerformLayout()
        Me.Contra_P.ResumeLayout(False)
        Me.Contra_P.PerformLayout()
        Me.Panel19.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel9 As Panel
    Friend WithEvents Label14 As Label
    Friend WithEvents Account_YN As Tools.YN
    Friend WithEvents Panel21 As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel14 As Panel
    Friend WithEvents Journal_P As Panel
    Friend WithEvents Journal_YN As Tools.YN
    Friend WithEvents Label30 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents Receipt_P As Panel
    Friend WithEvents Receipt_YN As Tools.YN
    Friend WithEvents Label24 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Payment_P As Panel
    Friend WithEvents Payment_YN As Tools.YN
    Friend WithEvents Label22 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Contra_P As Panel
    Friend WithEvents Contra_YN As Tools.YN
    Friend WithEvents Label20 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Panel19 As Panel
    Friend WithEvents Label36 As Label
    Friend WithEvents Panel6 As Panel
End Class
