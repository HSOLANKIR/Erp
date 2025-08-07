<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class std_rate_ctrl
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
        Me.components = New System.ComponentModel.Container()
        Me.platform = New System.Windows.Forms.Panel()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'platform
        '
        Me.platform.AutoScroll = True
        Me.platform.Dock = System.Windows.Forms.DockStyle.Fill
        Me.platform.Location = New System.Drawing.Point(0, 0)
        Me.platform.Name = "platform"
        Me.platform.Padding = New System.Windows.Forms.Padding(0, 9, 0, 0)
        Me.platform.Size = New System.Drawing.Size(355, 465)
        Me.platform.TabIndex = 2
        '
        'std_rate_ctrl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Beige
        Me.Controls.Add(Me.platform)
        Me.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "std_rate_ctrl"
        Me.Size = New System.Drawing.Size(355, 465)
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents platform As Panel
    Friend WithEvents BindingSource1 As BindingSource
End Class
