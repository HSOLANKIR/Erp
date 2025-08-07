<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Batch_ctrl
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
        Me.bg_Panel = New System.Windows.Forms.Panel()
        Me.platform = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.item_Lab = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.bg_Panel.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bg_Panel
        '
        Me.bg_Panel.Controls.Add(Me.platform)
        Me.bg_Panel.Controls.Add(Me.Panel3)
        Me.bg_Panel.Controls.Add(Me.Label4)
        Me.bg_Panel.Controls.Add(Me.Panel2)
        Me.bg_Panel.Controls.Add(Me.Panel1)
        Me.bg_Panel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bg_Panel.Location = New System.Drawing.Point(0, 0)
        Me.bg_Panel.Name = "bg_Panel"
        Me.bg_Panel.Size = New System.Drawing.Size(303, 513)
        Me.bg_Panel.TabIndex = 0
        '
        'platform
        '
        Me.platform.AutoScroll = True
        Me.platform.Dock = System.Windows.Forms.DockStyle.Fill
        Me.platform.Location = New System.Drawing.Point(0, 56)
        Me.platform.Name = "platform"
        Me.platform.Size = New System.Drawing.Size(303, 457)
        Me.platform.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.DimGray
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 55)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(303, 1)
        Me.Panel3.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label4.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(0, 36)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(303, 19)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Name of BOM"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DimGray
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 34)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(303, 2)
        Me.Panel2.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.item_Lab)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(303, 34)
        Me.Panel1.TabIndex = 0
        '
        'item_Lab
        '
        Me.item_Lab.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.item_Lab.Location = New System.Drawing.Point(45, 11)
        Me.item_Lab.Name = "item_Lab"
        Me.item_Lab.Size = New System.Drawing.Size(255, 17)
        Me.item_Lab.TabIndex = 2
        Me.item_Lab.Text = ": POLLAN Prom"
        Me.item_Lab.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Item"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Batch_ctrl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.bg_Panel)
        Me.Font = New System.Drawing.Font("Arial", 11.25!)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Batch_ctrl"
        Me.Size = New System.Drawing.Size(303, 513)
        Me.bg_Panel.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents bg_Panel As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents item_Lab As Label
    Friend WithEvents platform As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents BindingSource1 As BindingSource
End Class
