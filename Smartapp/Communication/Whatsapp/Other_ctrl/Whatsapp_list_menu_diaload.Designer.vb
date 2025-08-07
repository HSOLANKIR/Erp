<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Whatsapp_list_menu_diaload
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.Panel39 = New System.Windows.Forms.Panel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.List_Panel = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel39.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel39
        '
        Me.Panel39.BackColor = System.Drawing.Color.Moccasin
        Me.Panel39.Controls.Add(Me.Label1)
        Me.Panel39.Controls.Add(Me.Label14)
        Me.Panel39.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel39.Location = New System.Drawing.Point(0, 0)
        Me.Panel39.Name = "Panel39"
        Me.Panel39.Size = New System.Drawing.Size(564, 34)
        Me.Panel39.TabIndex = 18
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(461, 9)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(91, 16)
        Me.Label14.TabIndex = 27
        Me.Label14.Text = "Add Menu (+)"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'List_Panel
        '
        Me.List_Panel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.List_Panel.Location = New System.Drawing.Point(0, 34)
        Me.List_Panel.Name = "List_Panel"
        Me.List_Panel.Size = New System.Drawing.Size(564, 290)
        Me.List_Panel.TabIndex = 19
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Label1.Size = New System.Drawing.Size(455, 34)
        Me.Label1.TabIndex = 28
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Whatsapp_list_menu_diaload
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Linen
        Me.ClientSize = New System.Drawing.Size(564, 324)
        Me.Controls.Add(Me.List_Panel)
        Me.Controls.Add(Me.Panel39)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Whatsapp_list_menu_diaload"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "WhatsApp List Manu"
        Me.Panel39.ResumeLayout(False)
        Me.Panel39.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel39 As Panel
    Friend WithEvents Label14 As Label
    Friend WithEvents List_Panel As Panel
    Friend WithEvents Label1 As Label
End Class
