<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Ledger_cfg
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
        Me.Address_YN = New Tools.YN()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.Panel17 = New System.Windows.Forms.Panel()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.BindingSource2 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Sorting_Panel = New System.Windows.Forms.Panel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Bank_YN = New Tools.YN()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GST_YN = New Tools.YN()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Credit_YN = New Tools.YN()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Credit_Day_YN = New Tools.YN()
        Me.Narration_Panel.SuspendLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel14.SuspendLayout()
        CType(Me.BindingSource2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Narration_Panel
        '
        Me.Narration_Panel.AutoSize = True
        Me.Narration_Panel.Controls.Add(Me.Label1)
        Me.Narration_Panel.Controls.Add(Me.Label2)
        Me.Narration_Panel.Controls.Add(Me.Address_YN)
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
        Me.Label1.Size = New System.Drawing.Size(98, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Enable Address"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(152, 4)
        Me.Label2.Margin = New System.Windows.Forms.Padding(1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(15, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = ": "
        '
        'Address_YN
        '
        Me.Address_YN.Back_color = System.Drawing.Color.White
        Me.Address_YN.BackColor = System.Drawing.Color.White
        Me.Address_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Address_YN.Data_Link_ = "Branch_YN"
        Me.Address_YN.Defolt_ = "No"
        Me.Address_YN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Address_YN.Font_ = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Address_YN.Location = New System.Drawing.Point(171, 5)
        Me.Address_YN.Margin = New System.Windows.Forms.Padding(1)
        Me.Address_YN.Name = "Address_YN"
        Me.Address_YN.ReadOnly = True
        Me.Address_YN.Size = New System.Drawing.Size(34, 15)
        Me.Address_YN.TabIndex = 6
        Me.Address_YN.Text = "No"
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
        Me.Panel4.Controls.Add(Me.Panel5)
        Me.Panel4.Controls.Add(Me.Panel3)
        Me.Panel4.Controls.Add(Me.Panel2)
        Me.Panel4.Controls.Add(Me.Panel1)
        Me.Panel4.Controls.Add(Me.Narration_Panel)
        Me.Panel4.Controls.Add(Me.Sorting_Panel)
        Me.Panel4.Controls.Add(Me.Label17)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 2)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Padding = New System.Windows.Forms.Padding(0, 10, 0, 10)
        Me.Panel4.Size = New System.Drawing.Size(392, 141)
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
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Bank_YN)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 47)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(392, 21)
        Me.Panel1.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label3.Location = New System.Drawing.Point(18, 4)
        Me.Label3.Margin = New System.Windows.Forms.Padding(1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(125, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Enable Bank Details"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(152, 4)
        Me.Label4.Margin = New System.Windows.Forms.Padding(1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(15, 16)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = ": "
        '
        'Bank_YN
        '
        Me.Bank_YN.Back_color = System.Drawing.Color.White
        Me.Bank_YN.BackColor = System.Drawing.Color.White
        Me.Bank_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Bank_YN.Data_Link_ = "Branch_YN"
        Me.Bank_YN.Defolt_ = "No"
        Me.Bank_YN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bank_YN.Font_ = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Bank_YN.Location = New System.Drawing.Point(171, 5)
        Me.Bank_YN.Margin = New System.Windows.Forms.Padding(1)
        Me.Bank_YN.Name = "Bank_YN"
        Me.Bank_YN.ReadOnly = True
        Me.Bank_YN.Size = New System.Drawing.Size(34, 15)
        Me.Bank_YN.TabIndex = 6
        Me.Bank_YN.Text = "No"
        '
        'Panel2
        '
        Me.Panel2.AutoSize = True
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.GST_YN)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 68)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(392, 21)
        Me.Panel2.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label5.Location = New System.Drawing.Point(18, 4)
        Me.Label5.Margin = New System.Windows.Forms.Padding(1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(121, 16)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Enable GST Details"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(152, 4)
        Me.Label6.Margin = New System.Windows.Forms.Padding(1)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(15, 16)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = ": "
        '
        'GST_YN
        '
        Me.GST_YN.Back_color = System.Drawing.Color.White
        Me.GST_YN.BackColor = System.Drawing.Color.White
        Me.GST_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GST_YN.Data_Link_ = "Branch_YN"
        Me.GST_YN.Defolt_ = "No"
        Me.GST_YN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GST_YN.Font_ = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GST_YN.Location = New System.Drawing.Point(171, 5)
        Me.GST_YN.Margin = New System.Windows.Forms.Padding(1)
        Me.GST_YN.Name = "GST_YN"
        Me.GST_YN.ReadOnly = True
        Me.GST_YN.Size = New System.Drawing.Size(34, 15)
        Me.GST_YN.TabIndex = 6
        Me.GST_YN.Text = "No"
        '
        'Panel3
        '
        Me.Panel3.AutoSize = True
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.Credit_YN)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 89)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(392, 21)
        Me.Panel3.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label7.Location = New System.Drawing.Point(18, 4)
        Me.Label7.Margin = New System.Windows.Forms.Padding(1)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(128, 16)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Enable Ledger Credit"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(152, 4)
        Me.Label8.Margin = New System.Windows.Forms.Padding(1)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(15, 16)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = ": "
        '
        'Credit_YN
        '
        Me.Credit_YN.Back_color = System.Drawing.Color.White
        Me.Credit_YN.BackColor = System.Drawing.Color.White
        Me.Credit_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Credit_YN.Data_Link_ = "Branch_YN"
        Me.Credit_YN.Defolt_ = "No"
        Me.Credit_YN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Credit_YN.Font_ = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Credit_YN.Location = New System.Drawing.Point(171, 5)
        Me.Credit_YN.Margin = New System.Windows.Forms.Padding(1)
        Me.Credit_YN.Name = "Credit_YN"
        Me.Credit_YN.ReadOnly = True
        Me.Credit_YN.Size = New System.Drawing.Size(34, 15)
        Me.Credit_YN.TabIndex = 6
        Me.Credit_YN.Text = "No"
        '
        'Panel5
        '
        Me.Panel5.AutoSize = True
        Me.Panel5.Controls.Add(Me.Label9)
        Me.Panel5.Controls.Add(Me.Label10)
        Me.Panel5.Controls.Add(Me.Credit_Day_YN)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 110)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(392, 21)
        Me.Panel5.TabIndex = 8
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label9.Location = New System.Drawing.Point(18, 4)
        Me.Label9.Margin = New System.Windows.Forms.Padding(1)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(119, 16)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "Enable Credit Days"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(152, 4)
        Me.Label10.Margin = New System.Windows.Forms.Padding(1)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(15, 16)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = ": "
        '
        'Credit_Day_YN
        '
        Me.Credit_Day_YN.Back_color = System.Drawing.Color.White
        Me.Credit_Day_YN.BackColor = System.Drawing.Color.White
        Me.Credit_Day_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Credit_Day_YN.Data_Link_ = "Branch_YN"
        Me.Credit_Day_YN.Defolt_ = "No"
        Me.Credit_Day_YN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Credit_Day_YN.Font_ = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Credit_Day_YN.Location = New System.Drawing.Point(171, 5)
        Me.Credit_Day_YN.Margin = New System.Windows.Forms.Padding(1)
        Me.Credit_Day_YN.Name = "Credit_Day_YN"
        Me.Credit_Day_YN.ReadOnly = True
        Me.Credit_Day_YN.Size = New System.Drawing.Size(34, 15)
        Me.Credit_Day_YN.TabIndex = 6
        Me.Credit_Day_YN.Text = "No"
        '
        'Ledger_cfg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel14)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Ledger_cfg"
        Me.Size = New System.Drawing.Size(392, 146)
        Me.Narration_Panel.ResumeLayout(False)
        Me.Narration_Panel.PerformLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel14.ResumeLayout(False)
        CType(Me.BindingSource2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Narration_Panel As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Address_YN As Tools.YN
    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents Panel14 As Panel
    Friend WithEvents Panel17 As Panel
    Friend WithEvents Panel16 As Panel
    Friend WithEvents BindingSource2 As BindingSource
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Sorting_Panel As Panel
    Friend WithEvents Label17 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Bank_YN As Tools.YN
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents GST_YN As Tools.YN
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Credit_YN As Tools.YN
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Credit_Day_YN As Tools.YN
End Class
