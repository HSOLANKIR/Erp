<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Day_Book_cfg
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Narration_Panel = New System.Windows.Forms.Panel()
        Me.Neration_YN = New Tools.YN()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.admin_panel = New System.Windows.Forms.Panel()
        Me.Delete_Entry_Panel = New System.Windows.Forms.Panel()
        Me.Delete_Entry_YN = New Tools.YN()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Narration_Panel.SuspendLayout()
        Me.admin_panel.SuspendLayout()
        Me.Delete_Entry_Panel.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.PaleTurquoise
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(283, 113)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(83, 28)
        Me.Button1.TabIndex = 130
        Me.Button1.Text = "Ok"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Narration_Panel
        '
        Me.Narration_Panel.AutoSize = True
        Me.Narration_Panel.Controls.Add(Me.Neration_YN)
        Me.Narration_Panel.Controls.Add(Me.Label3)
        Me.Narration_Panel.Dock = System.Windows.Forms.DockStyle.Top
        Me.Narration_Panel.Location = New System.Drawing.Point(0, 50)
        Me.Narration_Panel.Name = "Narration_Panel"
        Me.Narration_Panel.Size = New System.Drawing.Size(369, 27)
        Me.Narration_Panel.TabIndex = 128
        '
        'Neration_YN
        '
        Me.Neration_YN.Back_color = System.Drawing.Color.Bisque
        Me.Neration_YN.BackColor = System.Drawing.Color.Bisque
        Me.Neration_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Neration_YN.Data_Link_ = ""
        Me.Neration_YN.Defolt_ = "No"
        Me.Neration_YN.Font = New System.Drawing.Font("Arial", 11.0!)
        Me.Neration_YN.Location = New System.Drawing.Point(313, 7)
        Me.Neration_YN.Name = "Neration_YN"
        Me.Neration_YN.ReadOnly = True
        Me.Neration_YN.Size = New System.Drawing.Size(47, 17)
        Me.Neration_YN.TabIndex = 103
        Me.Neration_YN.Text = "No"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 17)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Show Narration"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.SaddleBrown
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 49)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(369, 1)
        Me.Panel3.TabIndex = 127
        '
        'admin_panel
        '
        Me.admin_panel.AutoSize = True
        Me.admin_panel.Controls.Add(Me.Delete_Entry_Panel)
        Me.admin_panel.Dock = System.Windows.Forms.DockStyle.Top
        Me.admin_panel.Location = New System.Drawing.Point(0, 22)
        Me.admin_panel.Name = "admin_panel"
        Me.admin_panel.Size = New System.Drawing.Size(369, 27)
        Me.admin_panel.TabIndex = 126
        '
        'Delete_Entry_Panel
        '
        Me.Delete_Entry_Panel.AutoSize = True
        Me.Delete_Entry_Panel.Controls.Add(Me.Delete_Entry_YN)
        Me.Delete_Entry_Panel.Controls.Add(Me.Label2)
        Me.Delete_Entry_Panel.Dock = System.Windows.Forms.DockStyle.Top
        Me.Delete_Entry_Panel.Location = New System.Drawing.Point(0, 0)
        Me.Delete_Entry_Panel.Name = "Delete_Entry_Panel"
        Me.Delete_Entry_Panel.Size = New System.Drawing.Size(369, 27)
        Me.Delete_Entry_Panel.TabIndex = 106
        '
        'Delete_Entry_YN
        '
        Me.Delete_Entry_YN.Back_color = System.Drawing.Color.Bisque
        Me.Delete_Entry_YN.BackColor = System.Drawing.Color.Bisque
        Me.Delete_Entry_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Delete_Entry_YN.Data_Link_ = ""
        Me.Delete_Entry_YN.Defolt_ = "No"
        Me.Delete_Entry_YN.Font = New System.Drawing.Font("Arial", 11.0!)
        Me.Delete_Entry_YN.Location = New System.Drawing.Point(313, 7)
        Me.Delete_Entry_YN.Name = "Delete_Entry_YN"
        Me.Delete_Entry_YN.ReadOnly = True
        Me.Delete_Entry_YN.Size = New System.Drawing.Size(47, 17)
        Me.Delete_Entry_YN.TabIndex = 103
        Me.Delete_Entry_YN.Text = "No"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(129, 17)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Show Delete Entry"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Black
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 21)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(369, 1)
        Me.Panel2.TabIndex = 125
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(369, 21)
        Me.Label1.TabIndex = 124
        Me.Label1.Text = "Day Book Configuration"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Day_Book_cfg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Bisque
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Narration_Panel)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.admin_panel)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Arial", 11.0!)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "Day_Book_cfg"
        Me.Size = New System.Drawing.Size(369, 144)
        Me.Narration_Panel.ResumeLayout(False)
        Me.Narration_Panel.PerformLayout()
        Me.admin_panel.ResumeLayout(False)
        Me.admin_panel.PerformLayout()
        Me.Delete_Entry_Panel.ResumeLayout(False)
        Me.Delete_Entry_Panel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Narration_Panel As Panel
    Friend WithEvents Neration_YN As Tools.YN
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents admin_panel As Panel
    Friend WithEvents Delete_Entry_Panel As Panel
    Friend WithEvents Delete_Entry_YN As Tools.YN
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
End Class
