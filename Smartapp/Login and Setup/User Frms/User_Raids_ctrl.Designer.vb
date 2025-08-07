<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class User_Raids_ctrl
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
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.platform = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Txt1 = New Tools.TXT()
        Me.bg_panel = New System.Windows.Forms.Panel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Ledger_Source = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Type_Source = New System.Windows.Forms.BindingSource(Me.components)
        Me.Txt2 = New Tools.TXT()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Txt3 = New Tools.TXT()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.bg_panel.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ledger_Source, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Type_Source, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.Panel2)
        Me.Panel4.Controls.Add(Me.Panel3)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 48)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(486, 21)
        Me.Panel4.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(0, 2)
        Me.Label4.Name = "Label4"
        Me.Label4.Padding = New System.Windows.Forms.Padding(9, 0, 0, 0)
        Me.Label4.Size = New System.Drawing.Size(362, 18)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Particulars"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(362, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 18)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Type of Access"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DimGray
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(486, 2)
        Me.Panel2.TabIndex = 7
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.DimGray
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 20)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(486, 1)
        Me.Panel3.TabIndex = 5
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Txt3)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Txt2)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(486, 48)
        Me.Panel1.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(230, 16)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Days allowed for Back Dated vouchers"
        '
        'platform
        '
        Me.platform.AutoScroll = True
        Me.platform.Dock = System.Windows.Forms.DockStyle.Fill
        Me.platform.Location = New System.Drawing.Point(0, 77)
        Me.platform.Name = "platform"
        Me.platform.Padding = New System.Windows.Forms.Padding(0, 9, 0, 0)
        Me.platform.Size = New System.Drawing.Size(486, 392)
        Me.platform.TabIndex = 11
        '
        'Panel5
        '
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 69)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(486, 8)
        Me.Panel5.TabIndex = 10
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
        Me.Txt1.Font_Size = 10
        Me.Txt1.Font_Style = System.Drawing.FontStyle.Bold
        Me.Txt1.Format_ = "dd-MM-yyyy"
        Me.Txt1.Keydown_Support = True
        Me.Txt1.Location = New System.Drawing.Point(159, 231)
        Me.Txt1.Msg_Object = Nothing
        Me.Txt1.Name = "Txt1"
        Me.Txt1.Select_Auto_Show = True
        Me.Txt1.Select_Column_Color = "NA"
        Me.Txt1.Select_Columns = 0
        Me.Txt1.Select_Filter = Nothing
        Me.Txt1.Select_Hide_Columns = "NA"
        Me.Txt1.Select_Object = Nothing
        Me.Txt1.Select_Source = Nothing
        Me.Txt1.Size = New System.Drawing.Size(1, 16)
        Me.Txt1.TabIndex = 13
        Me.Txt1.Type_ = "TXT"
        Me.Txt1.Val_max = 1000000000
        Me.Txt1.Val_min = 0
        '
        'bg_panel
        '
        Me.bg_panel.Controls.Add(Me.platform)
        Me.bg_panel.Controls.Add(Me.Panel9)
        Me.bg_panel.Controls.Add(Me.Panel5)
        Me.bg_panel.Controls.Add(Me.Panel4)
        Me.bg_panel.Controls.Add(Me.Panel1)
        Me.bg_panel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bg_panel.Location = New System.Drawing.Point(0, 0)
        Me.bg_panel.Name = "bg_panel"
        Me.bg_panel.Size = New System.Drawing.Size(486, 479)
        Me.bg_panel.TabIndex = 0
        '
        'Panel9
        '
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel9.Location = New System.Drawing.Point(0, 469)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(486, 10)
        Me.Panel9.TabIndex = 13
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.Label2)
        Me.Panel7.Controls.Add(Me.PictureBox1)
        Me.Panel7.Location = New System.Drawing.Point(106, 203)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(221, 169)
        Me.Panel7.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 136)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(221, 33)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Please Wait" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Server Connection"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Image = Global.Management.My.Resources.Resources.Server_connection_animation_gof
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(221, 136)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 15
        Me.PictureBox1.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(219, 16)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Cut-off date for Back Dated vouchers"
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
        Me.Txt2.Font_Size = 10
        Me.Txt2.Font_Style = System.Drawing.FontStyle.Bold
        Me.Txt2.Format_ = "dd-MM-yyyy"
        Me.Txt2.Keydown_Support = True
        Me.Txt2.Location = New System.Drawing.Point(290, 5)
        Me.Txt2.Msg_Object = Nothing
        Me.Txt2.Name = "Txt2"
        Me.Txt2.Select_Auto_Show = True
        Me.Txt2.Select_Column_Color = "NA"
        Me.Txt2.Select_Columns = 0
        Me.Txt2.Select_Filter = Nothing
        Me.Txt2.Select_Hide_Columns = "NA"
        Me.Txt2.Select_Object = Nothing
        Me.Txt2.Select_Source = Nothing
        Me.Txt2.Size = New System.Drawing.Size(49, 16)
        Me.Txt2.TabIndex = 21
        Me.Txt2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Txt2.Type_ = "TXT"
        Me.Txt2.Val_max = 1000000000
        Me.Txt2.Val_min = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(272, 5)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(12, 16)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = ":"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(272, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(12, 16)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = ":"
        '
        'Txt3
        '
        Me.Txt3.Auto_Cleane = True
        Me.Txt3.Back_color = System.Drawing.Color.White
        Me.Txt3.BackColor = System.Drawing.Color.White
        Me.Txt3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Txt3.Data_Link_ = ""
        Me.Txt3.Decimal_ = 2
        Me.Txt3.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Txt3.Font_Size = 10
        Me.Txt3.Font_Style = System.Drawing.FontStyle.Bold
        Me.Txt3.Format_ = "dd-MM-yyyy"
        Me.Txt3.Keydown_Support = True
        Me.Txt3.Location = New System.Drawing.Point(290, 25)
        Me.Txt3.Msg_Object = Nothing
        Me.Txt3.Name = "Txt3"
        Me.Txt3.Select_Auto_Show = True
        Me.Txt3.Select_Column_Color = "NA"
        Me.Txt3.Select_Columns = 0
        Me.Txt3.Select_Filter = Nothing
        Me.Txt3.Select_Hide_Columns = "NA"
        Me.Txt3.Select_Object = Nothing
        Me.Txt3.Select_Source = Nothing
        Me.Txt3.Size = New System.Drawing.Size(93, 16)
        Me.Txt3.TabIndex = 23
        Me.Txt3.Type_ = "TXT"
        Me.Txt3.Val_max = 1000000000
        Me.Txt3.Val_min = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(345, 5)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(38, 16)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "Days"
        '
        'User_Raids_ctrl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.bg_panel)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.Txt1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "User_Raids_ctrl"
        Me.Size = New System.Drawing.Size(486, 479)
        Me.Panel4.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.bg_panel.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ledger_Source, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Type_Source, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents platform As Panel
    Friend WithEvents Panel5 As Panel
    Public WithEvents Ledger_Source As BindingSource
    Friend WithEvents Txt1 As Tools.TXT
    Friend WithEvents bg_panel As Panel
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label1 As Label
    Public WithEvents Type_Source As BindingSource
    Friend WithEvents Label7 As Label
    Friend WithEvents Txt3 As Tools.TXT
    Friend WithEvents Label6 As Label
    Friend WithEvents Txt2 As Tools.TXT
    Friend WithEvents Label8 As Label
End Class
