<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Progressbar_Box
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Head = New System.Windows.Forms.Label()
        Me.Message = New System.Windows.Forms.Label()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Progress = New Tools.ProgressBag_Custom()
        Me.count_label = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.count_label)
        Me.Panel1.Controls.Add(Me.Progress)
        Me.Panel1.Controls.Add(Me.Head)
        Me.Panel1.Controls.Add(Me.Message)
        Me.Panel1.Location = New System.Drawing.Point(36, 32)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(468, 225)
        Me.Panel1.TabIndex = 0
        '
        'Head
        '
        Me.Head.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Head.ForeColor = System.Drawing.Color.Blue
        Me.Head.Location = New System.Drawing.Point(0, 117)
        Me.Head.Name = "Head"
        Me.Head.Size = New System.Drawing.Size(466, 16)
        Me.Head.TabIndex = 1
        Me.Head.Text = "Label1"
        Me.Head.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Message
        '
        Me.Message.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Message.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Message.ForeColor = System.Drawing.Color.DimGray
        Me.Message.Location = New System.Drawing.Point(0, 133)
        Me.Message.Name = "Message"
        Me.Message.Size = New System.Drawing.Size(466, 90)
        Me.Message.TabIndex = 2
        Me.Message.Text = "Label2"
        Me.Message.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BackgroundWorker1
        '
        '
        'Progress
        '
        Me.Progress.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Progress.Display_Value = False
        Me.Progress.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Progress.Last_TXT = "%"
        Me.Progress.Location = New System.Drawing.Point(4, 76)
        Me.Progress.Margin = New System.Windows.Forms.Padding(4)
        Me.Progress.Maximum = 100
        Me.Progress.Name = "Progress"
        Me.Progress.Progress_color = System.Drawing.Color.Turquoise
        Me.Progress.Size = New System.Drawing.Size(458, 25)
        Me.Progress.TabIndex = 3
        Me.Progress.Value_ForColor = System.Drawing.Color.Black
        '
        'count_label
        '
        Me.count_label.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.count_label.ForeColor = System.Drawing.Color.Black
        Me.count_label.Location = New System.Drawing.Point(0, 20)
        Me.count_label.Name = "count_label"
        Me.count_label.Size = New System.Drawing.Size(466, 47)
        Me.count_label.TabIndex = 4
        Me.count_label.Text = "0%"
        Me.count_label.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Progressbar_Box
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.OldLace
        Me.ClientSize = New System.Drawing.Size(540, 289)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Progressbar_Box"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Head As Label
    Friend WithEvents Message As Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Progress As Tools.ProgressBag_Custom
    Friend WithEvents count_label As Label
End Class
