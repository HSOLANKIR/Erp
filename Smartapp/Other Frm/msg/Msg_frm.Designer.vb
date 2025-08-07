<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Msg_frm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Msg_frm))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.type_lb = New System.Windows.Forms.Label()
        Me.head_lb = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.msg_lb = New System.Windows.Forms.Label()
        Me.T = New System.Windows.Forms.Panel()
        Me.B = New System.Windows.Forms.Panel()
        Me.R = New System.Windows.Forms.Panel()
        Me.L = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(2, 24)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(133, 72)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'type_lb
        '
        Me.type_lb.Dock = System.Windows.Forms.DockStyle.Top
        Me.type_lb.Location = New System.Drawing.Point(2, 2)
        Me.type_lb.Name = "type_lb"
        Me.type_lb.Size = New System.Drawing.Size(133, 21)
        Me.type_lb.TabIndex = 0
        Me.type_lb.Text = "Warning"
        Me.type_lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'head_lb
        '
        Me.head_lb.AutoSize = True
        Me.head_lb.Location = New System.Drawing.Point(5, 96)
        Me.head_lb.Name = "head_lb"
        Me.head_lb.Size = New System.Drawing.Size(82, 16)
        Me.head_lb.TabIndex = 2
        Me.head_lb.Text = "Input Error !"
        Me.head_lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DimGray
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(2, 23)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(133, 1)
        Me.Panel1.TabIndex = 3
        '
        'msg_lb
        '
        Me.msg_lb.AutoSize = True
        Me.msg_lb.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msg_lb.ForeColor = System.Drawing.Color.DimGray
        Me.msg_lb.Location = New System.Drawing.Point(5, 119)
        Me.msg_lb.Margin = New System.Windows.Forms.Padding(3)
        Me.msg_lb.Name = "msg_lb"
        Me.msg_lb.Size = New System.Drawing.Size(10, 16)
        Me.msg_lb.TabIndex = 4
        Me.msg_lb.Text = "|"
        Me.msg_lb.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'T
        '
        Me.T.BackColor = System.Drawing.Color.Black
        Me.T.Dock = System.Windows.Forms.DockStyle.Top
        Me.T.Location = New System.Drawing.Point(2, 0)
        Me.T.Name = "T"
        Me.T.Size = New System.Drawing.Size(133, 2)
        Me.T.TabIndex = 6
        '
        'B
        '
        Me.B.BackColor = System.Drawing.Color.Black
        Me.B.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.B.Location = New System.Drawing.Point(2, 161)
        Me.B.Name = "B"
        Me.B.Size = New System.Drawing.Size(133, 2)
        Me.B.TabIndex = 7
        '
        'R
        '
        Me.R.BackColor = System.Drawing.Color.Black
        Me.R.Dock = System.Windows.Forms.DockStyle.Right
        Me.R.Location = New System.Drawing.Point(135, 0)
        Me.R.Name = "R"
        Me.R.Size = New System.Drawing.Size(2, 163)
        Me.R.TabIndex = 8
        '
        'L
        '
        Me.L.BackColor = System.Drawing.Color.Black
        Me.L.Dock = System.Windows.Forms.DockStyle.Left
        Me.L.Location = New System.Drawing.Point(0, 0)
        Me.L.Name = "L"
        Me.L.Size = New System.Drawing.Size(2, 163)
        Me.L.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DimGray
        Me.Label4.Location = New System.Drawing.Point(2, 140)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(133, 21)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Press any key to continue"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Msg_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(137, 163)
        Me.Controls.Add(Me.msg_lb)
        Me.Controls.Add(Me.head_lb)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.type_lb)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.T)
        Me.Controls.Add(Me.B)
        Me.Controls.Add(Me.R)
        Me.Controls.Add(Me.L)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Msg_frm"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents type_lb As Label
    Friend WithEvents head_lb As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents msg_lb As Label
    Friend WithEvents T As Panel
    Friend WithEvents B As Panel
    Friend WithEvents R As Panel
    Friend WithEvents L As Panel
    Friend WithEvents Label4 As Label
End Class
