<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Date_frm
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
        Me.Period_Panel = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Frm_TXT = New Tools.TXT()
        Me.To_TXT = New Tools.TXT()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.curr_TXT = New Tools.TXT()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Period_Panel.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Period_Panel
        '
        Me.Period_Panel.AutoSize = True
        Me.Period_Panel.BackColor = System.Drawing.Color.White
        Me.Period_Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Period_Panel.Controls.Add(Me.Panel4)
        Me.Period_Panel.Controls.Add(Me.Label4)
        Me.Period_Panel.Controls.Add(Me.Label3)
        Me.Period_Panel.Controls.Add(Me.Panel3)
        Me.Period_Panel.Controls.Add(Me.Panel2)
        Me.Period_Panel.Controls.Add(Me.Frm_TXT)
        Me.Period_Panel.Controls.Add(Me.To_TXT)
        Me.Period_Panel.Controls.Add(Me.Label5)
        Me.Period_Panel.Controls.Add(Me.Label2)
        Me.Period_Panel.Controls.Add(Me.Label1)
        Me.Period_Panel.Location = New System.Drawing.Point(65, 32)
        Me.Period_Panel.Name = "Period_Panel"
        Me.Period_Panel.Size = New System.Drawing.Size(270, 102)
        Me.Period_Panel.TabIndex = 0
        Me.Period_Panel.Visible = False
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.LightGray
        Me.Panel4.Location = New System.Drawing.Point(9, 48)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(251, 1)
        Me.Panel4.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(138, 71)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(123, 16)
        Me.Label4.TabIndex = 4
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(7, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(123, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.LightGray
        Me.Panel3.Location = New System.Drawing.Point(134, 26)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1, 67)
        Me.Panel3.TabIndex = 3
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.LightGray
        Me.Panel2.Location = New System.Drawing.Point(9, 26)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(251, 1)
        Me.Panel2.TabIndex = 2
        '
        'Frm_TXT
        '
        Me.Frm_TXT.Auto_Cleane = True
        Me.Frm_TXT.Back_color = System.Drawing.Color.White
        Me.Frm_TXT.BackColor = System.Drawing.Color.White
        Me.Frm_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Frm_TXT.Data_Link_ = ""
        Me.Frm_TXT.Decimal_ = 2
        Me.Frm_TXT.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Frm_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Frm_TXT.Font_Size = 10
        Me.Frm_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Frm_TXT.Format_ = "dd-MM-yyyy"
        Me.Frm_TXT.Keydown_Support = True
        Me.Frm_TXT.Location = New System.Drawing.Point(7, 52)
        Me.Frm_TXT.Msg_Object = Nothing
        Me.Frm_TXT.Name = "Frm_TXT"
        Me.Frm_TXT.Select_Auto_Show = True
        Me.Frm_TXT.Select_Column_Color = "NA"
        Me.Frm_TXT.Select_Columns = 0
        Me.Frm_TXT.Select_Filter = Nothing
        Me.Frm_TXT.Select_Hide_Columns = "NA"
        Me.Frm_TXT.Select_Object = Nothing
        Me.Frm_TXT.Select_Source = Nothing
        Me.Frm_TXT.Size = New System.Drawing.Size(123, 16)
        Me.Frm_TXT.TabIndex = 8
        Me.Frm_TXT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Frm_TXT.Type_ = "TXT"
        Me.Frm_TXT.Val_max = 1000000000
        Me.Frm_TXT.Val_min = 0
        '
        'To_TXT
        '
        Me.To_TXT.Auto_Cleane = True
        Me.To_TXT.Back_color = System.Drawing.Color.White
        Me.To_TXT.BackColor = System.Drawing.Color.White
        Me.To_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.To_TXT.Data_Link_ = ""
        Me.To_TXT.Decimal_ = 2
        Me.To_TXT.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.To_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.To_TXT.Font_Size = 10
        Me.To_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.To_TXT.Format_ = "dd-MM-yyyy"
        Me.To_TXT.Keydown_Support = True
        Me.To_TXT.Location = New System.Drawing.Point(138, 52)
        Me.To_TXT.Msg_Object = Nothing
        Me.To_TXT.Name = "To_TXT"
        Me.To_TXT.Select_Auto_Show = True
        Me.To_TXT.Select_Column_Color = "NA"
        Me.To_TXT.Select_Columns = 0
        Me.To_TXT.Select_Filter = Nothing
        Me.To_TXT.Select_Hide_Columns = "NA"
        Me.To_TXT.Select_Object = Nothing
        Me.To_TXT.Select_Source = Nothing
        Me.To_TXT.Size = New System.Drawing.Size(123, 16)
        Me.To_TXT.TabIndex = 7
        Me.To_TXT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.To_TXT.Type_ = "TXT"
        Me.To_TXT.Val_max = 1000000000
        Me.To_TXT.Val_min = 0
        '
        'Label5
        '
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(0, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(268, 18)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Set Period"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(187, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(22, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "To"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(47, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "From"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.curr_TXT)
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Controls.Add(Me.Panel6)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Location = New System.Drawing.Point(403, 159)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(168, 97)
        Me.Panel1.TabIndex = 1
        Me.Panel1.Visible = False
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(5, 73)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(156, 16)
        Me.Label6.TabIndex = 12
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'curr_TXT
        '
        Me.curr_TXT.Auto_Cleane = True
        Me.curr_TXT.Back_color = System.Drawing.Color.White
        Me.curr_TXT.BackColor = System.Drawing.Color.White
        Me.curr_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.curr_TXT.Data_Link_ = ""
        Me.curr_TXT.Decimal_ = 2
        Me.curr_TXT.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.curr_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.curr_TXT.Font_Size = 10
        Me.curr_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.curr_TXT.Format_ = "dd-MM-yyyy"
        Me.curr_TXT.Keydown_Support = True
        Me.curr_TXT.Location = New System.Drawing.Point(22, 53)
        Me.curr_TXT.Msg_Object = Nothing
        Me.curr_TXT.Name = "curr_TXT"
        Me.curr_TXT.Select_Auto_Show = True
        Me.curr_TXT.Select_Column_Color = "NA"
        Me.curr_TXT.Select_Columns = 0
        Me.curr_TXT.Select_Filter = Nothing
        Me.curr_TXT.Select_Hide_Columns = "NA"
        Me.curr_TXT.Select_Object = Nothing
        Me.curr_TXT.Select_Source = Nothing
        Me.curr_TXT.Size = New System.Drawing.Size(123, 16)
        Me.curr_TXT.TabIndex = 8
        Me.curr_TXT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.curr_TXT.Type_ = "TXT"
        Me.curr_TXT.Val_max = 1000000000
        Me.curr_TXT.Val_min = 0
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.LightGray
        Me.Panel5.Location = New System.Drawing.Point(7, 48)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(153, 1)
        Me.Panel5.TabIndex = 11
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.LightGray
        Me.Panel6.Location = New System.Drawing.Point(7, 26)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(153, 1)
        Me.Panel6.TabIndex = 10
        '
        'Label7
        '
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(0, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(166, 21)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Set Current Date"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(63, 29)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 16)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "From"
        '
        'Date_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.NavajoWhite
        Me.ClientSize = New System.Drawing.Size(937, 318)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Period_Panel)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Date_frm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Date_frm"
        Me.Period_Panel.ResumeLayout(False)
        Me.Period_Panel.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Period_Panel As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents To_TXT As Tools.TXT
    Friend WithEvents Frm_TXT As Tools.TXT
    Friend WithEvents curr_TXT As Tools.TXT
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label6 As Label
End Class
