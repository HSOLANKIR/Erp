<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Inventory_BOM
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
        Me.Head = New System.Windows.Forms.Label()
        Me.Batch_ctrl1 = New Management.Batch_ctrl()
        Me.SuspendLayout()
        '
        'Head
        '
        Me.Head.Dock = System.Windows.Forms.DockStyle.Top
        Me.Head.Font = New System.Drawing.Font("Arial", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Head.Location = New System.Drawing.Point(0, 0)
        Me.Head.Name = "Head"
        Me.Head.Size = New System.Drawing.Size(1364, 26)
        Me.Head.TabIndex = 2
        Me.Head.Text = "Components list BOM"
        Me.Head.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Batch_ctrl1
        '
        Me.Batch_ctrl1.AutoScroll = True
        Me.Batch_ctrl1.BackColor = System.Drawing.Color.White
        Me.Batch_ctrl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Batch_ctrl1.Font = New System.Drawing.Font("Arial", 11.25!)
        Me.Batch_ctrl1.Location = New System.Drawing.Point(230, 50)
        Me.Batch_ctrl1.Margin = New System.Windows.Forms.Padding(4)
        Me.Batch_ctrl1.Name = "Batch_ctrl1"
        Me.Batch_ctrl1.Size = New System.Drawing.Size(303, 513)
        Me.Batch_ctrl1.TabIndex = 3
        Me.Batch_ctrl1.Visible = False
        '
        'Inventory_BOM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.MistyRose
        Me.ClientSize = New System.Drawing.Size(1364, 749)
        Me.Controls.Add(Me.Batch_ctrl1)
        Me.Controls.Add(Me.Head)
        Me.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Inventory_BOM"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventory_BOM"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Head As Label
    Friend WithEvents Batch_ctrl1 As Batch_ctrl
End Class
