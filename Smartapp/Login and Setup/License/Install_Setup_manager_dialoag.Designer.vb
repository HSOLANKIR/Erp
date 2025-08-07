<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Install_Setup_manager_dialoag
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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New Tools.ProgressBag_Custom()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Download_Background = New System.ComponentModel.BackgroundWorker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Download_Panel = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.Download_Panel.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.ProgressBar1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 107)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(598, 67)
        Me.Panel1.TabIndex = 19
        Me.Panel1.Visible = False
        '
        'Label4
        '
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Font = New System.Drawing.Font("Arial Black", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(225, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(148, 42)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "0%"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(373, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(225, 42)
        Me.Label6.TabIndex = 15
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label7
        '
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(0, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(225, 42)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Download Setup Manager"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'ProgressBar1
        '
        Me.ProgressBar1.BackColor = System.Drawing.Color.White
        Me.ProgressBar1.Display_Value = False
        Me.ProgressBar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ProgressBar1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProgressBar1.Last_TXT = "%"
        Me.ProgressBar1.Location = New System.Drawing.Point(0, 42)
        Me.ProgressBar1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ProgressBar1.Maximum = 100
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Progress_color = System.Drawing.Color.DarkOrange
        Me.ProgressBar1.Size = New System.Drawing.Size(598, 25)
        Me.ProgressBar1.TabIndex = 34
        Me.ProgressBar1.Value_ForColor = System.Drawing.Color.Black
        '
        'Panel2
        '
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 174)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(598, 8)
        Me.Panel2.TabIndex = 20
        '
        'Download_Background
        '
        Me.Download_Background.WorkerReportsProgress = True
        Me.Download_Background.WorkerSupportsCancellation = True
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Arial Black", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.ForestGreen
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(598, 42)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "Download Setup Manager"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Download_Panel
        '
        Me.Download_Panel.BackColor = System.Drawing.Color.White
        Me.Download_Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Download_Panel.Controls.Add(Me.Panel1)
        Me.Download_Panel.Controls.Add(Me.Panel2)
        Me.Download_Panel.Controls.Add(Me.Label1)
        Me.Download_Panel.Location = New System.Drawing.Point(12, 12)
        Me.Download_Panel.Name = "Download_Panel"
        Me.Download_Panel.Size = New System.Drawing.Size(600, 184)
        Me.Download_Panel.TabIndex = 38
        '
        'Install_Setup_manager_dialoag
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Honeydew
        Me.ClientSize = New System.Drawing.Size(632, 254)
        Me.Controls.Add(Me.Download_Panel)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Install_Setup_manager_dialoag"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cryptonix Technology Private Limited"
        Me.Panel1.ResumeLayout(False)
        Me.Download_Panel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents ProgressBar1 As Tools.ProgressBag_Custom
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Download_Background As System.ComponentModel.BackgroundWorker
    Friend WithEvents Label1 As Label
    Friend WithEvents Download_Panel As Panel
End Class
