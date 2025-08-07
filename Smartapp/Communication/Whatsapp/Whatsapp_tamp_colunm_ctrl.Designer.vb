<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Whatsapp_tamp_colunm_ctrl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Whatsapp_tamp_colunm_ctrl))
        Me.btn_colunm = New System.Windows.Forms.Button()
        Me.Name_Label = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btn_colunm
        '
        Me.btn_colunm.BackColor = System.Drawing.Color.MistyRose
        Me.btn_colunm.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_colunm.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_colunm.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_colunm.Image = CType(resources.GetObject("btn_colunm.Image"), System.Drawing.Image)
        Me.btn_colunm.Location = New System.Drawing.Point(164, 0)
        Me.btn_colunm.Margin = New System.Windows.Forms.Padding(2, 4, 2, 2)
        Me.btn_colunm.Name = "btn_colunm"
        Me.btn_colunm.Size = New System.Drawing.Size(31, 34)
        Me.btn_colunm.TabIndex = 102
        Me.btn_colunm.TabStop = False
        Me.btn_colunm.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_colunm.UseVisualStyleBackColor = False
        '
        'Name_Label
        '
        Me.Name_Label.Dock = System.Windows.Forms.DockStyle.Left
        Me.Name_Label.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name_Label.Location = New System.Drawing.Point(0, 0)
        Me.Name_Label.Name = "Name_Label"
        Me.Name_Label.Size = New System.Drawing.Size(156, 34)
        Me.Name_Label.TabIndex = 103
        Me.Name_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Whatsapp_tamp_colunm_ctrl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.Name_Label)
        Me.Controls.Add(Me.btn_colunm)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "Whatsapp_tamp_colunm_ctrl"
        Me.Size = New System.Drawing.Size(195, 34)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_colunm As Button
    Friend WithEvents Name_Label As Label
End Class
