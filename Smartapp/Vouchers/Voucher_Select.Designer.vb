Imports Tools

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Voucher_Select
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
        Me.components = New System.ComponentModel.Container()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.TX = New Tools.TXT()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel4.SuspendLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.TX)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Location = New System.Drawing.Point(306, 196)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(285, 44)
        Me.Panel4.TabIndex = 7
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
        Me.TX.Keydown_Support = True
        Me.TX.Location = New System.Drawing.Point(0, 22)
        Me.TX.Msg_Object = Nothing
        Me.TX.Name = "TX"
        Me.TX.Select_Auto_Show = True
        Me.TX.Select_Column_Color = "NA"
        Me.TX.Select_Columns = 0
        Me.TX.Select_Filter = "(Name LIKE '%<value>%') or (Under LIKE '%<value>%')"
        Me.TX.Select_Hide_Columns = "NA"
        Me.TX.Select_Object = Nothing
        Me.TX.Select_Source = Nothing
        Me.TX.Size = New System.Drawing.Size(283, 16)
        Me.TX.TabIndex = 6
        Me.TX.Type_ = "Select"
        Me.TX.Val_max = 1000000000
        Me.TX.Val_min = 0
        '
        'Label3
        '
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(283, 22)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Select Voucher"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Voucher_Select
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Bisque
        Me.ClientSize = New System.Drawing.Size(1364, 705)
        Me.Controls.Add(Me.Panel4)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Voucher_Select"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Voucher_Select"
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel4 As Panel
    Friend WithEvents TX As TXT
    Friend WithEvents Label3 As Label
    Friend WithEvents BindingSource1 As BindingSource
End Class
