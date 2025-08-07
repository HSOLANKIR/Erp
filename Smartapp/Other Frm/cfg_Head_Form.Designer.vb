<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cfg_Head_Form
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
        Me.bg = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Save_TXT = New Tools.TXT()
        Me.bg.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'bg
        '
        Me.bg.AutoSize = True
        Me.bg.BackColor = System.Drawing.Color.White
        Me.bg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.bg.Controls.Add(Me.Panel1)
        Me.bg.Controls.Add(Me.Panel3)
        Me.bg.Controls.Add(Me.Panel4)
        Me.bg.Controls.Add(Me.Panel5)
        Me.bg.Location = New System.Drawing.Point(144, 107)
        Me.bg.Name = "bg"
        Me.bg.Size = New System.Drawing.Size(513, 311)
        Me.bg.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(10, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(491, 27)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.Label1.Size = New System.Drawing.Size(491, 26)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Configuration"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Silver
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 26)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(491, 1)
        Me.Panel2.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(10, 299)
        Me.Panel3.TabIndex = 1
        '
        'Panel4
        '
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(501, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(10, 299)
        Me.Panel4.TabIndex = 2
        '
        'Panel5
        '
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel5.Location = New System.Drawing.Point(0, 299)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(511, 10)
        Me.Panel5.TabIndex = 3
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
        Me.Save_TXT.Font_Size = 10
        Me.Save_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Save_TXT.Format_ = "dd-MM-yyyy"
        Me.Save_TXT.Keydown_Support = True
        Me.Save_TXT.Location = New System.Drawing.Point(411, 27)
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
        Me.Save_TXT.TabIndex = 2
        Me.Save_TXT.Type_ = "TXT"
        Me.Save_TXT.Val_max = 1000000000
        Me.Save_TXT.Val_min = 0
        '
        'cfg_Head_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Beige
        Me.ClientSize = New System.Drawing.Size(800, 525)
        Me.Controls.Add(Me.Save_TXT)
        Me.Controls.Add(Me.bg)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "cfg_Head_Form"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "cfg_Head_Form"
        Me.bg.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents bg As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Save_TXT As Tools.TXT
End Class
