<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Communication_frm
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
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Communication_ctrl1 = New Management.Communication_ctrl()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Txt2 = New Tools.TXT()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Txt1 = New Tools.TXT()
        Me.bg_Panel = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.bg_Panel.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Khaki
        Me.Label22.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label22.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(0, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(429, 21)
        Me.Label22.TabIndex = 11
        Me.Label22.Text = "Communication"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Communication_ctrl1)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Label22)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(431, 458)
        Me.Panel1.TabIndex = 1
        '
        'Communication_ctrl1
        '
        Me.Communication_ctrl1.BackColor = System.Drawing.Color.White
        Me.Communication_ctrl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Communication_ctrl1.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Communication_ctrl1.Location = New System.Drawing.Point(0, 122)
        Me.Communication_ctrl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Communication_ctrl1.Name = "Communication_ctrl1"
        Me.Communication_ctrl1.Size = New System.Drawing.Size(429, 334)
        Me.Communication_ctrl1.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Txt2)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Txt1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 21)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(429, 101)
        Me.Panel2.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Gray
        Me.Label2.Location = New System.Drawing.Point(0, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(429, 39)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Enter the number of the accountant of the company and when the bill with GST is g" &
    "enerated, it will be sent to WhatsApp and email."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(16, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 16)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "E-Mail Addres :"
        '
        'Txt2
        '
        Me.Txt2.Auto_Cleane = True
        Me.Txt2.Back_color = System.Drawing.Color.White
        Me.Txt2.BackColor = System.Drawing.Color.White
        Me.Txt2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Txt2.Data_Link_ = ""
        Me.Txt2.Decimal_ = 2
        Me.Txt2.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Txt2.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Txt2.Font_Size = 10
        Me.Txt2.Font_Style = System.Drawing.FontStyle.Bold
        Me.Txt2.Format_ = "dd-MM-yyyy"
        Me.Txt2.Keydown_Support = True
        Me.Txt2.Location = New System.Drawing.Point(121, 39)
        Me.Txt2.Msg_Object = Nothing
        Me.Txt2.Name = "Txt2"
        Me.Txt2.Select_Auto_Show = True
        Me.Txt2.Select_Column_Color = "NA"
        Me.Txt2.Select_Columns = 0
        Me.Txt2.Select_Filter = Nothing
        Me.Txt2.Select_Hide_Columns = "NA"
        Me.Txt2.Select_Object = Nothing
        Me.Txt2.Select_Source = Nothing
        Me.Txt2.Size = New System.Drawing.Size(303, 16)
        Me.Txt2.TabIndex = 17
        Me.Txt2.Type_ = "TXT"
        Me.Txt2.Val_max = 1000000000
        Me.Txt2.Val_min = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 16)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Whatsapp No. :"
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(429, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Accountant Details"
        '
        'Txt1
        '
        Me.Txt1.Auto_Cleane = True
        Me.Txt1.Back_color = System.Drawing.Color.White
        Me.Txt1.BackColor = System.Drawing.Color.White
        Me.Txt1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Txt1.Data_Link_ = ""
        Me.Txt1.Decimal_ = 2
        Me.Txt1.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Txt1.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Txt1.Font_Size = 10
        Me.Txt1.Font_Style = System.Drawing.FontStyle.Bold
        Me.Txt1.Format_ = "dd-MM-yyyy"
        Me.Txt1.Keydown_Support = True
        Me.Txt1.Location = New System.Drawing.Point(121, 20)
        Me.Txt1.Msg_Object = Nothing
        Me.Txt1.Name = "Txt1"
        Me.Txt1.Select_Auto_Show = True
        Me.Txt1.Select_Column_Color = "NA"
        Me.Txt1.Select_Columns = 0
        Me.Txt1.Select_Filter = Nothing
        Me.Txt1.Select_Hide_Columns = "NA"
        Me.Txt1.Select_Object = Nothing
        Me.Txt1.Select_Source = Nothing
        Me.Txt1.Size = New System.Drawing.Size(94, 16)
        Me.Txt1.TabIndex = 15
        Me.Txt1.Type_ = "TXT"
        Me.Txt1.Val_max = 1000000000
        Me.Txt1.Val_min = 0
        '
        'bg_Panel
        '
        Me.bg_Panel.Controls.Add(Me.Panel1)
        Me.bg_Panel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bg_Panel.Location = New System.Drawing.Point(0, 0)
        Me.bg_Panel.Name = "bg_Panel"
        Me.bg_Panel.Size = New System.Drawing.Size(955, 543)
        Me.bg_Panel.TabIndex = 2
        '
        'Communication_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Cornsilk
        Me.ClientSize = New System.Drawing.Size(955, 543)
        Me.Controls.Add(Me.bg_Panel)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Communication_frm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Communication_frm"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.bg_Panel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label22 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Communication_ctrl1 As Communication_ctrl
    Friend WithEvents bg_Panel As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Txt2 As Tools.TXT
    Friend WithEvents Label3 As Label
    Friend WithEvents Txt1 As Tools.TXT
End Class
