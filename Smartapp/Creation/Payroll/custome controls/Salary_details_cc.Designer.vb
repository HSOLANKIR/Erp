<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Salary_details_cc
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.date_L = New System.Windows.Forms.Panel()
        Me.bg_panel = New System.Windows.Forms.Panel()
        Me.bg_ = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.phd_L = New System.Windows.Forms.Panel()
        Me.Rate_L = New System.Windows.Forms.Panel()
        Me.per_L = New System.Windows.Forms.Panel()
        Me.phdType_L = New System.Windows.Forms.Panel()
        Me.phd_source = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel1.SuspendLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.phd_source, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1023, 38)
        Me.Panel1.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(108, 1)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Padding = New System.Windows.Forms.Padding(11, 0, 0, 0)
        Me.Label4.Size = New System.Drawing.Size(324, 36)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Pay head"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label3
        '
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(432, 1)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 36)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Rate"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(503, 1)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 36)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "per"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 1)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(11, 0, 0, 0)
        Me.Label1.Size = New System.Drawing.Size(108, 36)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Effective" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "from"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label5
        '
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(597, 1)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(230, 36)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Payhead Type"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label6
        '
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(827, 1)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(196, 36)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Calculation Type"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.DarkGray
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1023, 1)
        Me.Panel3.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkGray
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 37)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1023, 1)
        Me.Panel2.TabIndex = 1
        '
        'date_L
        '
        Me.date_L.BackColor = System.Drawing.Color.DarkGray
        Me.date_L.Location = New System.Drawing.Point(663, 0)
        Me.date_L.Margin = New System.Windows.Forms.Padding(4)
        Me.date_L.Name = "date_L"
        Me.date_L.Size = New System.Drawing.Size(1, 247)
        Me.date_L.TabIndex = 4
        '
        'bg_panel
        '
        Me.bg_panel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bg_panel.Location = New System.Drawing.Point(0, 47)
        Me.bg_panel.Margin = New System.Windows.Forms.Padding(4)
        Me.bg_panel.Name = "bg_panel"
        Me.bg_panel.Size = New System.Drawing.Size(1023, 419)
        Me.bg_panel.TabIndex = 8
        '
        'bg_
        '
        Me.bg_.AutoSize = True
        Me.bg_.Dock = System.Windows.Forms.DockStyle.Top
        Me.bg_.Location = New System.Drawing.Point(0, 0)
        Me.bg_.Name = "bg_"
        Me.bg_.Size = New System.Drawing.Size(1023, 0)
        Me.bg_.TabIndex = 0
        Me.bg_.Visible = False
        '
        'Panel4
        '
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 38)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1023, 9)
        Me.Panel4.TabIndex = 9
        '
        'phd_L
        '
        Me.phd_L.BackColor = System.Drawing.Color.DarkGray
        Me.phd_L.Location = New System.Drawing.Point(395, 109)
        Me.phd_L.Margin = New System.Windows.Forms.Padding(4)
        Me.phd_L.Name = "phd_L"
        Me.phd_L.Size = New System.Drawing.Size(1, 247)
        Me.phd_L.TabIndex = 10
        '
        'Rate_L
        '
        Me.Rate_L.BackColor = System.Drawing.Color.DarkGray
        Me.Rate_L.Location = New System.Drawing.Point(402, 117)
        Me.Rate_L.Margin = New System.Windows.Forms.Padding(4)
        Me.Rate_L.Name = "Rate_L"
        Me.Rate_L.Size = New System.Drawing.Size(1, 247)
        Me.Rate_L.TabIndex = 11
        '
        'per_L
        '
        Me.per_L.BackColor = System.Drawing.Color.DarkGray
        Me.per_L.Location = New System.Drawing.Point(409, 124)
        Me.per_L.Margin = New System.Windows.Forms.Padding(4)
        Me.per_L.Name = "per_L"
        Me.per_L.Size = New System.Drawing.Size(1, 247)
        Me.per_L.TabIndex = 12
        '
        'phdType_L
        '
        Me.phdType_L.BackColor = System.Drawing.Color.DarkGray
        Me.phdType_L.Location = New System.Drawing.Point(416, 132)
        Me.phdType_L.Margin = New System.Windows.Forms.Padding(4)
        Me.phdType_L.Name = "phdType_L"
        Me.phdType_L.Size = New System.Drawing.Size(1, 247)
        Me.phdType_L.TabIndex = 13
        '
        'Salary_details_cc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.phdType_L)
        Me.Controls.Add(Me.per_L)
        Me.Controls.Add(Me.Rate_L)
        Me.Controls.Add(Me.phd_L)
        Me.Controls.Add(Me.date_L)
        Me.Controls.Add(Me.bg_panel)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.bg_)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Salary_details_cc"
        Me.Size = New System.Drawing.Size(1023, 466)
        Me.Panel1.ResumeLayout(False)
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.phd_source, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents date_L As Panel
    Friend WithEvents bg_panel As Panel
    Friend WithEvents bg_ As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents phd_L As Panel
    Friend WithEvents Rate_L As Panel
    Friend WithEvents per_L As Panel
    Friend WithEvents phdType_L As Panel
    Friend WithEvents phd_source As BindingSource
End Class
