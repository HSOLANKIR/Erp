<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Filter_frm
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
        Me.Save_TXT = New Tools.TXT()
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
        Me.Panel4.Location = New System.Drawing.Point(391, 255)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(285, 44)
        Me.Panel4.TabIndex = 8
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
        Me.TX.Select_Filter = "(Head LIKE '%<value>%') or (Under LIKE '%<value>%')"
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
        'Save_TXT
        '
        Me.Save_TXT.Auto_Cleane = True
        Me.Save_TXT.Back_color = System.Drawing.Color.White
        Me.Save_TXT.BackColor = System.Drawing.Color.White
        Me.Save_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Save_TXT.Data_Link_ = ""
        Me.Save_TXT.Decimal_ = 2
        Me.Save_TXT.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Save_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Save_TXT.Font_Size = 10
        Me.Save_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Save_TXT.Format_ = "dd-MM-yyyy"
        Me.Save_TXT.Keydown_Support = True
        Me.Save_TXT.Location = New System.Drawing.Point(578, 338)
        Me.Save_TXT.Msg_Object = Nothing
        Me.Save_TXT.Name = "Save_TXT"
        Me.Save_TXT.Select_Auto_Show = True
        Me.Save_TXT.Select_Column_Color = "NA"
        Me.Save_TXT.Select_Columns = 0
        Me.Save_TXT.Select_Filter = Nothing
        Me.Save_TXT.Select_Hide_Columns = "NA"
        Me.Save_TXT.Select_Object = Nothing
        Me.Save_TXT.Select_Source = Nothing
        Me.Save_TXT.Size = New System.Drawing.Size(0, 16)
        Me.Save_TXT.TabIndex = 9
        Me.Save_TXT.Type_ = "TXT"
        Me.Save_TXT.Val_max = 1000000000
        Me.Save_TXT.Val_min = 0
        '
        'Filter_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.PapayaWhip
        Me.ClientSize = New System.Drawing.Size(1067, 554)
        Me.Controls.Add(Me.Save_TXT)
        Me.Controls.Add(Me.Panel4)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Filter_frm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Filter_frm"
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel4 As Panel
    Friend WithEvents TX As Tools.TXT
    Friend WithEvents Label3 As Label
    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents Save_TXT As Tools.TXT
End Class
