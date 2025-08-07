<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class cprj_Print_cfg_ctrl
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
        Me.BindingSource2 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Yn2 = New Tools.YN()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Yn3 = New Tools.YN()
        Me.Txt1 = New Tools.TXT()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Yn1 = New Tools.YN()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Yn4 = New Tools.YN()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.BindingSource2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.NavajoWhite
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(200, 0)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(133, 30)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Apply Changes "
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.Button1)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel6.Location = New System.Drawing.Point(0, 144)
        Me.Panel6.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(333, 30)
        Me.Panel6.TabIndex = 55
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 58)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 16)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "Print Narration"
        Me.Label4.UseMnemonic = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 16)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "Head"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel2.Location = New System.Drawing.Point(0, 45)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(759, 1)
        Me.Panel2.TabIndex = 47
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(258, 98)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(11, 16)
        Me.Label15.TabIndex = 50
        Me.Label15.Text = ":"
        '
        'Yn2
        '
        Me.Yn2.Back_color = System.Drawing.Color.White
        Me.Yn2.BackColor = System.Drawing.Color.White
        Me.Yn2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Yn2.Data_Link_ = ""
        Me.Yn2.Defolt_ = "No"
        Me.Yn2.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.Yn2.Location = New System.Drawing.Point(275, 78)
        Me.Yn2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Yn2.Name = "Yn2"
        Me.Yn2.ReadOnly = True
        Me.Yn2.Size = New System.Drawing.Size(51, 16)
        Me.Yn2.TabIndex = 33
        Me.Yn2.Text = "No"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 78)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(103, 16)
        Me.Label7.TabIndex = 38
        Me.Label7.Text = "Print Signature"
        Me.Label7.UseMnemonic = False
        '
        'Yn3
        '
        Me.Yn3.Back_color = System.Drawing.Color.White
        Me.Yn3.BackColor = System.Drawing.Color.White
        Me.Yn3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Yn3.Data_Link_ = ""
        Me.Yn3.Defolt_ = "No"
        Me.Yn3.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.Yn3.Location = New System.Drawing.Point(275, 98)
        Me.Yn3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Yn3.Name = "Yn3"
        Me.Yn3.ReadOnly = True
        Me.Yn3.Size = New System.Drawing.Size(51, 16)
        Me.Yn3.TabIndex = 36
        Me.Yn3.Text = "No"
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
        Me.Txt1.Location = New System.Drawing.Point(14, 23)
        Me.Txt1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Txt1.Msg_Object = Nothing
        Me.Txt1.Name = "Txt1"
        Me.Txt1.Select_Auto_Show = True
        Me.Txt1.Select_Column_Color = "NA"
        Me.Txt1.Select_Columns = 0
        Me.Txt1.Select_Filter = Nothing
        Me.Txt1.Select_Hide_Columns = "NA"
        Me.Txt1.Select_Object = Nothing
        Me.Txt1.Select_Source = Nothing
        Me.Txt1.Size = New System.Drawing.Size(165, 16)
        Me.Txt1.TabIndex = 29
        Me.Txt1.Type_ = "TXT"
        Me.Txt1.Val_max = 1000000000
        Me.Txt1.Val_min = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(258, 78)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(11, 16)
        Me.Label9.TabIndex = 49
        Me.Label9.Text = ":"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(258, 119)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(11, 16)
        Me.Label14.TabIndex = 51
        Me.Label14.Text = ":"
        '
        'Yn1
        '
        Me.Yn1.Back_color = System.Drawing.Color.White
        Me.Yn1.BackColor = System.Drawing.Color.White
        Me.Yn1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Yn1.Data_Link_ = ""
        Me.Yn1.Defolt_ = "No"
        Me.Yn1.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.Yn1.Location = New System.Drawing.Point(275, 58)
        Me.Yn1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Yn1.Name = "Yn1"
        Me.Yn1.ReadOnly = True
        Me.Yn1.Size = New System.Drawing.Size(51, 16)
        Me.Yn1.TabIndex = 31
        Me.Yn1.Text = "No"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 98)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(146, 16)
        Me.Label6.TabIndex = 40
        Me.Label6.Text = "Print Company Stamp"
        Me.Label6.UseMnemonic = False
        '
        'Yn4
        '
        Me.Yn4.Back_color = System.Drawing.Color.White
        Me.Yn4.BackColor = System.Drawing.Color.White
        Me.Yn4.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Yn4.Data_Link_ = ""
        Me.Yn4.Defolt_ = "No"
        Me.Yn4.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.Yn4.Location = New System.Drawing.Point(275, 119)
        Me.Yn4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Yn4.Name = "Yn4"
        Me.Yn4.ReadOnly = True
        Me.Yn4.Size = New System.Drawing.Size(51, 16)
        Me.Yn4.TabIndex = 37
        Me.Yn4.Text = "No"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(258, 58)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(11, 16)
        Me.Label8.TabIndex = 48
        Me.Label8.Text = ":"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 119)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(168, 16)
        Me.Label5.TabIndex = 42
        Me.Label5.Text = "Print Provisional Balance"
        Me.Label5.UseMnemonic = False
        '
        'cprj_Print_cfg_ctrl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Yn2)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Yn3)
        Me.Controls.Add(Me.Txt1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Yn1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Yn4)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label5)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "cprj_Print_cfg_ctrl"
        Me.Size = New System.Drawing.Size(333, 174)
        CType(Me.BindingSource2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BindingSource2 As BindingSource
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel6 As Panel
    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label15 As Label
    Friend WithEvents Yn2 As Tools.YN
    Friend WithEvents Label7 As Label
    Friend WithEvents Yn3 As Tools.YN
    Friend WithEvents Txt1 As Tools.TXT
    Friend WithEvents Label9 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Yn1 As Tools.YN
    Friend WithEvents Label6 As Label
    Friend WithEvents Yn4 As Tools.YN
    Friend WithEvents Label8 As Label
    Friend WithEvents Label5 As Label
End Class
