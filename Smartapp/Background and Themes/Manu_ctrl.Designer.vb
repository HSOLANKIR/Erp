<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Manu_ctrl
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
        Me.bg_Panel = New System.Windows.Forms.Panel()
        Me.Label82 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'bg_Panel
        '
        Me.bg_Panel.AutoSize = True
        Me.bg_Panel.Location = New System.Drawing.Point(0, 31)
        Me.bg_Panel.Margin = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.bg_Panel.Name = "bg_Panel"
        Me.bg_Panel.Size = New System.Drawing.Size(299, 18)
        Me.bg_Panel.TabIndex = 1
        '
        'Label82
        '
        Me.Label82.BackColor = System.Drawing.Color.Tan
        Me.Label82.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label82.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label82.Location = New System.Drawing.Point(0, 0)
        Me.Label82.Name = "Label82"
        Me.Label82.Size = New System.Drawing.Size(299, 21)
        Me.Label82.TabIndex = 5
        Me.Label82.Text = "List of Manu"
        Me.Label82.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 21)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(299, 10)
        Me.Panel3.TabIndex = 6
        '
        'Manu_ctrl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.OldLace
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.bg_Panel)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Label82)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Manu_ctrl"
        Me.Size = New System.Drawing.Size(299, 59)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bg_Panel As Panel
    Friend WithEvents Label82 As Label
    Friend WithEvents Panel3 As Panel
End Class
