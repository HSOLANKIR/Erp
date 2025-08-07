<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Print_Page_Seting_dialoag
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
        Me.Panel24 = New System.Windows.Forms.Panel()
        Me.Panel25 = New System.Windows.Forms.Panel()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.l_margin = New System.Windows.Forms.NumericUpDown()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.r_margin = New System.Windows.Forms.NumericUpDown()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.b_margin = New System.Windows.Forms.NumericUpDown()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.t_margin = New System.Windows.Forms.NumericUpDown()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel24.SuspendLayout()
        CType(Me.l_margin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.r_margin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.b_margin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.t_margin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel24)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(547, 263)
        Me.Panel1.TabIndex = 0
        '
        'Panel24
        '
        Me.Panel24.Controls.Add(Me.Button1)
        Me.Panel24.Controls.Add(Me.Panel25)
        Me.Panel24.Controls.Add(Me.Label25)
        Me.Panel24.Controls.Add(Me.l_margin)
        Me.Panel24.Controls.Add(Me.Label23)
        Me.Panel24.Controls.Add(Me.r_margin)
        Me.Panel24.Controls.Add(Me.Label22)
        Me.Panel24.Controls.Add(Me.b_margin)
        Me.Panel24.Controls.Add(Me.Label21)
        Me.Panel24.Controls.Add(Me.t_margin)
        Me.Panel24.Controls.Add(Me.Label24)
        Me.Panel24.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel24.Location = New System.Drawing.Point(204, 1)
        Me.Panel24.Name = "Panel24"
        Me.Panel24.Size = New System.Drawing.Size(344, 262)
        Me.Panel24.TabIndex = 100
        '
        'Panel25
        '
        Me.Panel25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel25.Location = New System.Drawing.Point(107, 72)
        Me.Panel25.Name = "Panel25"
        Me.Panel25.Size = New System.Drawing.Size(100, 80)
        Me.Panel25.TabIndex = 3
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(66, 107)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(27, 16)
        Me.Label25.TabIndex = 107
        Me.Label25.Text = "cm"
        '
        'l_margin
        '
        Me.l_margin.DecimalPlaces = 2
        Me.l_margin.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.l_margin.Location = New System.Drawing.Point(6, 104)
        Me.l_margin.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.l_margin.Name = "l_margin"
        Me.l_margin.Size = New System.Drawing.Size(58, 22)
        Me.l_margin.TabIndex = 106
        Me.l_margin.Value = New Decimal(New Integer() {5, 0, 0, 65536})
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(306, 107)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(27, 16)
        Me.Label23.TabIndex = 105
        Me.Label23.Text = "cm"
        '
        'r_margin
        '
        Me.r_margin.DecimalPlaces = 2
        Me.r_margin.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.r_margin.Location = New System.Drawing.Point(246, 104)
        Me.r_margin.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.r_margin.Name = "r_margin"
        Me.r_margin.Size = New System.Drawing.Size(58, 22)
        Me.r_margin.TabIndex = 104
        Me.r_margin.Value = New Decimal(New Integer() {5, 0, 0, 65536})
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(189, 204)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(27, 16)
        Me.Label22.TabIndex = 103
        Me.Label22.Text = "cm"
        '
        'b_margin
        '
        Me.b_margin.DecimalPlaces = 2
        Me.b_margin.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.b_margin.Location = New System.Drawing.Point(129, 201)
        Me.b_margin.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.b_margin.Name = "b_margin"
        Me.b_margin.Size = New System.Drawing.Size(58, 22)
        Me.b_margin.TabIndex = 102
        Me.b_margin.Value = New Decimal(New Integer() {5, 0, 0, 65536})
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(189, 20)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(27, 16)
        Me.Label21.TabIndex = 101
        Me.Label21.Text = "cm"
        '
        't_margin
        '
        Me.t_margin.DecimalPlaces = 2
        Me.t_margin.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.t_margin.Location = New System.Drawing.Point(129, 17)
        Me.t_margin.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.t_margin.Name = "t_margin"
        Me.t_margin.Size = New System.Drawing.Size(58, 22)
        Me.t_margin.TabIndex = 100
        Me.t_margin.Value = New Decimal(New Integer() {5, 0, 0, 65536})
        '
        'Label24
        '
        Me.Label24.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label24.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(0, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(344, 16)
        Me.Label24.TabIndex = 2
        Me.Label24.Text = "Page Margin"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Silver
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(204, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(343, 1)
        Me.Panel2.TabIndex = 2
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox1.Image = Global.Management.My.Resources.Resources.page_setup_animation_gif
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(204, 263)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.PaleTurquoise
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(265, 228)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 30)
        Me.Button1.TabIndex = 108
        Me.Button1.Text = "Ok"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Print_Page_Seting_dialoag
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(547, 263)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Print_Page_Seting_dialoag"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Page Setup"
        Me.Panel1.ResumeLayout(False)
        Me.Panel24.ResumeLayout(False)
        Me.Panel24.PerformLayout()
        CType(Me.l_margin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.r_margin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.b_margin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.t_margin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel24 As Panel
    Friend WithEvents Panel25 As Panel
    Friend WithEvents Label25 As Label
    Friend WithEvents l_margin As NumericUpDown
    Friend WithEvents Label23 As Label
    Friend WithEvents r_margin As NumericUpDown
    Friend WithEvents Label22 As Label
    Friend WithEvents b_margin As NumericUpDown
    Friend WithEvents Label21 As Label
    Friend WithEvents t_margin As NumericUpDown
    Friend WithEvents Label24 As Label
    Friend WithEvents Button1 As Button
End Class
