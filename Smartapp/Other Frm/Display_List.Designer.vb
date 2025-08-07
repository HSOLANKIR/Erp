Imports Tools

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Display_List
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
        Me.components = New System.ComponentModel.Container()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TX = New Tools.TXT()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BS = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel2.SuspendLayout()
        CType(Me.BS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.AutoSize = True
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.TX)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Location = New System.Drawing.Point(351, 160)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(361, 44)
        Me.Panel2.TabIndex = 0
        '
        'TX
        '
        Me.TX.Auto_Cleane = True
        Me.TX.Back_color = System.Drawing.Color.White
        Me.TX.BackColor = System.Drawing.Color.White
        Me.TX.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TX.Data_Link_ = ""
        Me.TX.Decimal_ = 2
        Me.TX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TX.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.TX.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TX.Font_Size = 10
        Me.TX.Font_Style = System.Drawing.FontStyle.Bold
        Me.TX.Format_ = "dd-MM-yyyy"
        Me.TX.Keydown_Support = False
        Me.TX.Location = New System.Drawing.Point(0, 22)
        Me.TX.Msg_Object = Nothing
        Me.TX.Name = "TX"
        Me.TX.Select_Auto_Show = True
        Me.TX.Select_Column_Color = "NA"
        Me.TX.Select_Columns = 1
        Me.TX.Select_Filter = Nothing
        Me.TX.Select_Hide_Columns = "NA"
        Me.TX.Select_Object = Nothing
        Me.TX.Select_Source = Nothing
        Me.TX.Size = New System.Drawing.Size(359, 16)
        Me.TX.TabIndex = 6
        Me.TX.Type_ = "Select"
        Me.TX.Val_max = 1000000000
        Me.TX.Val_min = 0
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(359, 22)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Search"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Display_List
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1364, 705)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Display_List"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Display_List"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.BS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TX As TXT
    Friend WithEvents Label2 As Label
    Friend WithEvents BS As BindingSource
End Class
