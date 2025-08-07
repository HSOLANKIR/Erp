<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Report_Group_Summary_cfg
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Opning_Balance_Panel = New System.Windows.Forms.Panel()
        Me.CL_YN = New Tools.YN()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Narration_Panel = New System.Windows.Forms.Panel()
        Me.OB_YN = New Tools.YN()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Percentage_YN = New Tools.YN()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Opning_Balance_Panel.SuspendLayout()
        Me.Narration_Panel.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.PaleTurquoise
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(283, 110)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(83, 28)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Ok"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Opning_Balance_Panel
        '
        Me.Opning_Balance_Panel.AutoSize = True
        Me.Opning_Balance_Panel.Controls.Add(Me.CL_YN)
        Me.Opning_Balance_Panel.Controls.Add(Me.Label4)
        Me.Opning_Balance_Panel.Dock = System.Windows.Forms.DockStyle.Top
        Me.Opning_Balance_Panel.Location = New System.Drawing.Point(0, 50)
        Me.Opning_Balance_Panel.Name = "Opning_Balance_Panel"
        Me.Opning_Balance_Panel.Size = New System.Drawing.Size(369, 27)
        Me.Opning_Balance_Panel.TabIndex = 1
        '
        'CL_YN
        '
        Me.CL_YN.Back_color = System.Drawing.Color.Bisque
        Me.CL_YN.BackColor = System.Drawing.Color.Bisque
        Me.CL_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.CL_YN.Data_Link_ = ""
        Me.CL_YN.Defolt_ = "No"
        Me.CL_YN.Font = New System.Drawing.Font("Arial", 11.0!)
        Me.CL_YN.Location = New System.Drawing.Point(313, 7)
        Me.CL_YN.Name = "CL_YN"
        Me.CL_YN.ReadOnly = True
        Me.CL_YN.Size = New System.Drawing.Size(47, 17)
        Me.CL_YN.TabIndex = 103
        Me.CL_YN.Text = "No"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(20, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(155, 17)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Show Closing Balance"
        '
        'Narration_Panel
        '
        Me.Narration_Panel.AutoSize = True
        Me.Narration_Panel.Controls.Add(Me.OB_YN)
        Me.Narration_Panel.Controls.Add(Me.Label3)
        Me.Narration_Panel.Dock = System.Windows.Forms.DockStyle.Top
        Me.Narration_Panel.Location = New System.Drawing.Point(0, 23)
        Me.Narration_Panel.Name = "Narration_Panel"
        Me.Narration_Panel.Size = New System.Drawing.Size(369, 27)
        Me.Narration_Panel.TabIndex = 0
        '
        'OB_YN
        '
        Me.OB_YN.Back_color = System.Drawing.Color.Bisque
        Me.OB_YN.BackColor = System.Drawing.Color.Bisque
        Me.OB_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.OB_YN.Data_Link_ = ""
        Me.OB_YN.Defolt_ = "No"
        Me.OB_YN.Font = New System.Drawing.Font("Arial", 11.0!)
        Me.OB_YN.Location = New System.Drawing.Point(313, 7)
        Me.OB_YN.Name = "OB_YN"
        Me.OB_YN.ReadOnly = True
        Me.OB_YN.Size = New System.Drawing.Size(47, 17)
        Me.OB_YN.TabIndex = 103
        Me.OB_YN.Text = "No"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(153, 17)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Show Opning Balance"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.SaddleBrown
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 22)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(369, 1)
        Me.Panel3.TabIndex = 113
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Black
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 21)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(369, 1)
        Me.Panel2.TabIndex = 111
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(369, 21)
        Me.Label1.TabIndex = 110
        Me.Label1.Text = "Ledger Group Summary Configuration"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.Controls.Add(Me.Percentage_YN)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 77)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(369, 27)
        Me.Panel1.TabIndex = 2
        '
        'Percentage_YN
        '
        Me.Percentage_YN.Back_color = System.Drawing.Color.Bisque
        Me.Percentage_YN.BackColor = System.Drawing.Color.Bisque
        Me.Percentage_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Percentage_YN.Data_Link_ = ""
        Me.Percentage_YN.Defolt_ = "No"
        Me.Percentage_YN.Font = New System.Drawing.Font("Arial", 11.0!)
        Me.Percentage_YN.Location = New System.Drawing.Point(313, 7)
        Me.Percentage_YN.Name = "Percentage_YN"
        Me.Percentage_YN.ReadOnly = True
        Me.Percentage_YN.Size = New System.Drawing.Size(47, 17)
        Me.Percentage_YN.TabIndex = 103
        Me.Percentage_YN.Text = "No"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 17)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Show Percentage"
        '
        'Report_Group_Summary_cfg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Moccasin
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Opning_Balance_Panel)
        Me.Controls.Add(Me.Narration_Panel)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Arial", 11.0!)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Report_Group_Summary_cfg"
        Me.Size = New System.Drawing.Size(369, 141)
        Me.Opning_Balance_Panel.ResumeLayout(False)
        Me.Opning_Balance_Panel.PerformLayout()
        Me.Narration_Panel.ResumeLayout(False)
        Me.Narration_Panel.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Opning_Balance_Panel As Panel
    Friend WithEvents CL_YN As Tools.YN
    Friend WithEvents Label4 As Label
    Friend WithEvents Narration_Panel As Panel
    Friend WithEvents OB_YN As Tools.YN
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Percentage_YN As Tools.YN
    Friend WithEvents Label2 As Label
End Class
