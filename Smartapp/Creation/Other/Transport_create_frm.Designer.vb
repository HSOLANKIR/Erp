<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Transport_create_frm
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Save_TXT = New Tools.TXT()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Vehicle_No = New Tools.TXT()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Vehicle_Type = New Tools.TXT()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Contect_Panel = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Phone_TXT = New Tools.TXT()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Name_TXT = New Tools.TXT()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Contect_Panel.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(310, 705)
        Me.Panel1.TabIndex = 3
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.Save_TXT)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Contect_Panel)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.Panel6)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(310, 705)
        Me.Panel2.TabIndex = 0
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
        Me.Save_TXT.Location = New System.Drawing.Point(126, 215)
        Me.Save_TXT.Msg_Object = Nothing
        Me.Save_TXT.Name = "Save_TXT"
        Me.Save_TXT.Select_Auto_Show = True
        Me.Save_TXT.Select_Column_Color = "NA"
        Me.Save_TXT.Select_Columns = 0
        Me.Save_TXT.Select_Filter = Nothing
        Me.Save_TXT.Select_Hide_Columns = "NA"
        Me.Save_TXT.Select_Object = Nothing
        Me.Save_TXT.Select_Source = Nothing
        Me.Save_TXT.Size = New System.Drawing.Size(1, 16)
        Me.Save_TXT.TabIndex = 37
        Me.Save_TXT.Type_ = "TXT"
        Me.Save_TXT.Val_max = 1000000000
        Me.Save_TXT.Val_min = 0
        '
        'Panel4
        '
        Me.Panel4.AutoSize = True
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.Controls.Add(Me.Label11)
        Me.Panel4.Controls.Add(Me.Panel5)
        Me.Panel4.Controls.Add(Me.Label5)
        Me.Panel4.Controls.Add(Me.Vehicle_No)
        Me.Panel4.Controls.Add(Me.Label7)
        Me.Panel4.Controls.Add(Me.Label8)
        Me.Panel4.Controls.Add(Me.Vehicle_Type)
        Me.Panel4.Controls.Add(Me.Label9)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 63)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(309, 66)
        Me.Panel4.TabIndex = 36
        '
        'Label11
        '
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.Label11.Location = New System.Drawing.Point(0, 1)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(309, 17)
        Me.Label11.TabIndex = 91
        Me.Label11.Text = "Vehicle details"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.DarkGray
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(309, 1)
        Me.Panel5.TabIndex = 83
        Me.Panel5.TabStop = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(96, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(11, 16)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = ":"
        '
        'Vehicle_No
        '
        Me.Vehicle_No.Auto_Cleane = True
        Me.Vehicle_No.Back_color = System.Drawing.Color.White
        Me.Vehicle_No.BackColor = System.Drawing.Color.White
        Me.Vehicle_No.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Vehicle_No.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Vehicle_No.Data_Link_ = ""
        Me.Vehicle_No.Decimal_ = 2
        Me.Vehicle_No.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Vehicle_No.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Vehicle_No.Font_Size = 10
        Me.Vehicle_No.Font_Style = System.Drawing.FontStyle.Bold
        Me.Vehicle_No.Format_ = "dd-MM-yyyy"
        Me.Vehicle_No.Keydown_Support = True
        Me.Vehicle_No.Location = New System.Drawing.Point(111, 48)
        Me.Vehicle_No.Msg_Object = Nothing
        Me.Vehicle_No.Name = "Vehicle_No"
        Me.Vehicle_No.Select_Auto_Show = True
        Me.Vehicle_No.Select_Column_Color = "NA"
        Me.Vehicle_No.Select_Columns = 0
        Me.Vehicle_No.Select_Filter = Nothing
        Me.Vehicle_No.Select_Hide_Columns = "NA"
        Me.Vehicle_No.Select_Object = Nothing
        Me.Vehicle_No.Select_Source = Nothing
        Me.Vehicle_No.Size = New System.Drawing.Size(145, 15)
        Me.Vehicle_No.TabIndex = 31
        Me.Vehicle_No.Type_ = "TXT"
        Me.Vehicle_No.Val_max = 1000000000
        Me.Vehicle_No.Val_min = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(8, 27)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 16)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Vehicle Type"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(8, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(73, 16)
        Me.Label8.TabIndex = 32
        Me.Label8.Text = "Vehicle No."
        '
        'Vehicle_Type
        '
        Me.Vehicle_Type.Auto_Cleane = True
        Me.Vehicle_Type.Back_color = System.Drawing.Color.White
        Me.Vehicle_Type.BackColor = System.Drawing.Color.White
        Me.Vehicle_Type.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Vehicle_Type.Data_Link_ = ""
        Me.Vehicle_Type.Decimal_ = 2
        Me.Vehicle_Type.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Vehicle_Type.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Vehicle_Type.Font_Size = 10
        Me.Vehicle_Type.Font_Style = System.Drawing.FontStyle.Bold
        Me.Vehicle_Type.Format_ = "dd-MM-yyyy"
        Me.Vehicle_Type.Keydown_Support = True
        Me.Vehicle_Type.Location = New System.Drawing.Point(111, 27)
        Me.Vehicle_Type.Msg_Object = Nothing
        Me.Vehicle_Type.Name = "Vehicle_Type"
        Me.Vehicle_Type.Select_Auto_Show = True
        Me.Vehicle_Type.Select_Column_Color = "NA"
        Me.Vehicle_Type.Select_Columns = 0
        Me.Vehicle_Type.Select_Filter = Nothing
        Me.Vehicle_Type.Select_Hide_Columns = "NA"
        Me.Vehicle_Type.Select_Object = Nothing
        Me.Vehicle_Type.Select_Source = Nothing
        Me.Vehicle_Type.Size = New System.Drawing.Size(184, 15)
        Me.Vehicle_Type.TabIndex = 0
        Me.Vehicle_Type.Type_ = "TXT"
        Me.Vehicle_Type.Val_max = 1000000000
        Me.Vehicle_Type.Val_min = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(96, 27)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(11, 16)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = ":"
        '
        'Contect_Panel
        '
        Me.Contect_Panel.AutoSize = True
        Me.Contect_Panel.BackColor = System.Drawing.Color.White
        Me.Contect_Panel.Controls.Add(Me.Label10)
        Me.Contect_Panel.Controls.Add(Me.Panel16)
        Me.Contect_Panel.Controls.Add(Me.Label3)
        Me.Contect_Panel.Controls.Add(Me.Phone_TXT)
        Me.Contect_Panel.Controls.Add(Me.Label1)
        Me.Contect_Panel.Controls.Add(Me.Label4)
        Me.Contect_Panel.Controls.Add(Me.Name_TXT)
        Me.Contect_Panel.Controls.Add(Me.Label2)
        Me.Contect_Panel.Dock = System.Windows.Forms.DockStyle.Top
        Me.Contect_Panel.Location = New System.Drawing.Point(0, 0)
        Me.Contect_Panel.Name = "Contect_Panel"
        Me.Contect_Panel.Size = New System.Drawing.Size(309, 63)
        Me.Contect_Panel.TabIndex = 35
        '
        'Label10
        '
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.Label10.Location = New System.Drawing.Point(0, 1)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(309, 17)
        Me.Label10.TabIndex = 90
        Me.Label10.Text = "Transport Details"
        '
        'Panel16
        '
        Me.Panel16.BackColor = System.Drawing.Color.DarkGray
        Me.Panel16.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel16.Location = New System.Drawing.Point(0, 0)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(309, 1)
        Me.Panel16.TabIndex = 83
        Me.Panel16.TabStop = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(96, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(11, 16)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = ":"
        '
        'Phone_TXT
        '
        Me.Phone_TXT.Auto_Cleane = True
        Me.Phone_TXT.Back_color = System.Drawing.Color.White
        Me.Phone_TXT.BackColor = System.Drawing.Color.White
        Me.Phone_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Phone_TXT.Data_Link_ = ""
        Me.Phone_TXT.Decimal_ = 2
        Me.Phone_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Phone_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Phone_TXT.Font_Size = 10
        Me.Phone_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Phone_TXT.Format_ = "dd-MM-yyyy"
        Me.Phone_TXT.Keydown_Support = True
        Me.Phone_TXT.Location = New System.Drawing.Point(111, 45)
        Me.Phone_TXT.Msg_Object = Nothing
        Me.Phone_TXT.Name = "Phone_TXT"
        Me.Phone_TXT.Select_Auto_Show = True
        Me.Phone_TXT.Select_Column_Color = "NA"
        Me.Phone_TXT.Select_Columns = 0
        Me.Phone_TXT.Select_Filter = Nothing
        Me.Phone_TXT.Select_Hide_Columns = "NA"
        Me.Phone_TXT.Select_Object = Nothing
        Me.Phone_TXT.Select_Source = Nothing
        Me.Phone_TXT.Size = New System.Drawing.Size(145, 15)
        Me.Phone_TXT.TabIndex = 31
        Me.Phone_TXT.Type_ = "TXT"
        Me.Phone_TXT.Val_max = 1000000000
        Me.Phone_TXT.Val_min = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Name"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 16)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "Phone No."
        '
        'Name_TXT
        '
        Me.Name_TXT.Auto_Cleane = True
        Me.Name_TXT.Back_color = System.Drawing.Color.White
        Me.Name_TXT.BackColor = System.Drawing.Color.White
        Me.Name_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Name_TXT.Data_Link_ = ""
        Me.Name_TXT.Decimal_ = 2
        Me.Name_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Name_TXT.Font_Size = 10
        Me.Name_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Name_TXT.Format_ = "dd-MM-yyyy"
        Me.Name_TXT.Keydown_Support = True
        Me.Name_TXT.Location = New System.Drawing.Point(111, 24)
        Me.Name_TXT.Msg_Object = Nothing
        Me.Name_TXT.Name = "Name_TXT"
        Me.Name_TXT.Select_Auto_Show = True
        Me.Name_TXT.Select_Column_Color = "NA"
        Me.Name_TXT.Select_Columns = 0
        Me.Name_TXT.Select_Filter = Nothing
        Me.Name_TXT.Select_Hide_Columns = "NA"
        Me.Name_TXT.Select_Object = Nothing
        Me.Name_TXT.Select_Source = Nothing
        Me.Name_TXT.Size = New System.Drawing.Size(184, 15)
        Me.Name_TXT.TabIndex = 0
        Me.Name_TXT.Type_ = "TXT"
        Me.Name_TXT.Val_max = 1000000000
        Me.Name_TXT.Val_min = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(96, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = ":"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.DarkGray
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 704)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(309, 1)
        Me.Panel3.TabIndex = 30
        Me.Panel3.TabStop = True
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.DarkGray
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel6.Location = New System.Drawing.Point(309, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1, 705)
        Me.Panel6.TabIndex = 38
        '
        'Transport_create_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1370, 705)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Transport_create_frm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Transport_create_frm"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Contect_Panel.ResumeLayout(False)
        Me.Contect_Panel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Name_TXT As Tools.TXT
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Phone_TXT As Tools.TXT
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Vehicle_No As Tools.TXT
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Vehicle_Type As Tools.TXT
    Friend WithEvents Label9 As Label
    Friend WithEvents Contect_Panel As Panel
    Friend WithEvents Panel16 As Panel
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Save_TXT As Tools.TXT
    Friend WithEvents Panel6 As Panel
End Class
