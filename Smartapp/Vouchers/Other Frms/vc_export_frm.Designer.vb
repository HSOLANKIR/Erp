<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class vc_export_frm
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SAVE_TXT = New Tools.TXT()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Txt1 = New Tools.TXT()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Dis_date_TXT = New Tools.TXT()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Carrier_Name_TXT = New Tools.TXT()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Transport_LR_TXT = New Tools.TXT()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Dis_through_TXT = New Tools.TXT()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Dis_Doc_TXT = New Tools.TXT()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Port_Source = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LUT_TXT = New Tools.TXT()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel8.SuspendLayout()
        CType(Me.Port_Source, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.SAVE_TXT)
        Me.Panel1.Controls.Add(Me.Panel8)
        Me.Panel1.Location = New System.Drawing.Point(191, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(724, 120)
        Me.Panel1.TabIndex = 1
        '
        'SAVE_TXT
        '
        Me.SAVE_TXT.Auto_Cleane = True
        Me.SAVE_TXT.Back_color = System.Drawing.Color.White
        Me.SAVE_TXT.BackColor = System.Drawing.Color.White
        Me.SAVE_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.SAVE_TXT.Data_Link_ = ""
        Me.SAVE_TXT.Decimal_ = 2
        Me.SAVE_TXT.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.SAVE_TXT.Font_Size = 10
        Me.SAVE_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.SAVE_TXT.Format_ = "dd-MM-yyyy"
        Me.SAVE_TXT.Keydown_Support = True
        Me.SAVE_TXT.Location = New System.Drawing.Point(347, 318)
        Me.SAVE_TXT.Msg_Object = Nothing
        Me.SAVE_TXT.Name = "SAVE_TXT"
        Me.SAVE_TXT.Select_Auto_Show = True
        Me.SAVE_TXT.Select_Column_Color = "NA"
        Me.SAVE_TXT.Select_Columns = 0
        Me.SAVE_TXT.Select_Filter = Nothing
        Me.SAVE_TXT.Select_Hide_Columns = "NA"
        Me.SAVE_TXT.Select_Object = Nothing
        Me.SAVE_TXT.Select_Source = Nothing
        Me.SAVE_TXT.Size = New System.Drawing.Size(1, 16)
        Me.SAVE_TXT.TabIndex = 400000
        Me.SAVE_TXT.Type_ = "TXT"
        Me.SAVE_TXT.Val_max = 1000000000
        Me.SAVE_TXT.Val_min = 0
        '
        'Panel8
        '
        Me.Panel8.AutoSize = True
        Me.Panel8.BackColor = System.Drawing.Color.White
        Me.Panel8.Controls.Add(Me.Label3)
        Me.Panel8.Controls.Add(Me.LUT_TXT)
        Me.Panel8.Controls.Add(Me.Label4)
        Me.Panel8.Controls.Add(Me.Label1)
        Me.Panel8.Controls.Add(Me.Txt1)
        Me.Panel8.Controls.Add(Me.Label2)
        Me.Panel8.Controls.Add(Me.Label20)
        Me.Panel8.Controls.Add(Me.Dis_date_TXT)
        Me.Panel8.Controls.Add(Me.Label21)
        Me.Panel8.Controls.Add(Me.Label6)
        Me.Panel8.Controls.Add(Me.Carrier_Name_TXT)
        Me.Panel8.Controls.Add(Me.Label7)
        Me.Panel8.Controls.Add(Me.Label32)
        Me.Panel8.Controls.Add(Me.Transport_LR_TXT)
        Me.Panel8.Controls.Add(Me.Label33)
        Me.Panel8.Controls.Add(Me.Label34)
        Me.Panel8.Controls.Add(Me.Dis_through_TXT)
        Me.Panel8.Controls.Add(Me.Label35)
        Me.Panel8.Controls.Add(Me.Label36)
        Me.Panel8.Controls.Add(Me.Dis_Doc_TXT)
        Me.Panel8.Controls.Add(Me.Label37)
        Me.Panel8.Controls.Add(Me.Label38)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel8.Location = New System.Drawing.Point(0, 0)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Padding = New System.Windows.Forms.Padding(0, 0, 0, 8)
        Me.Panel8.Size = New System.Drawing.Size(722, 114)
        Me.Panel8.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(175, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(11, 16)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = ":"
        '
        'Txt1
        '
        Me.Txt1.Auto_Cleane = True
        Me.Txt1.Back_color = System.Drawing.Color.White
        Me.Txt1.BackColor = System.Drawing.Color.White
        Me.Txt1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Txt1.Data_Link_ = ""
        Me.Txt1.Decimal_ = 2
        Me.Txt1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt1.Font_Size = 11
        Me.Txt1.Font_Style = System.Drawing.FontStyle.Bold
        Me.Txt1.Format_ = "dd-MM-yyyy"
        Me.Txt1.Keydown_Support = True
        Me.Txt1.Location = New System.Drawing.Point(190, 68)
        Me.Txt1.Msg_Object = Nothing
        Me.Txt1.Name = "Txt1"
        Me.Txt1.Select_Auto_Show = True
        Me.Txt1.Select_Column_Color = "NA"
        Me.Txt1.Select_Columns = 0
        Me.Txt1.Select_Filter = Nothing
        Me.Txt1.Select_Hide_Columns = "NA"
        Me.Txt1.Select_Object = Nothing
        Me.Txt1.Select_Source = Nothing
        Me.Txt1.Size = New System.Drawing.Size(178, 15)
        Me.Txt1.TabIndex = 2
        Me.Txt1.Type_ = "TXT"
        Me.Txt1.Val_max = 1000000000
        Me.Txt1.Val_min = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label2.Location = New System.Drawing.Point(8, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 16)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Port of Discharge"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(175, 87)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(11, 16)
        Me.Label20.TabIndex = 17
        Me.Label20.Text = ":"
        '
        'Dis_date_TXT
        '
        Me.Dis_date_TXT.Auto_Cleane = True
        Me.Dis_date_TXT.Back_color = System.Drawing.Color.White
        Me.Dis_date_TXT.BackColor = System.Drawing.Color.White
        Me.Dis_date_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Dis_date_TXT.Data_Link_ = ""
        Me.Dis_date_TXT.Decimal_ = 2
        Me.Dis_date_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dis_date_TXT.Font_Size = 11
        Me.Dis_date_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Dis_date_TXT.Format_ = "dd-MM-yyyy"
        Me.Dis_date_TXT.Keydown_Support = True
        Me.Dis_date_TXT.Location = New System.Drawing.Point(190, 88)
        Me.Dis_date_TXT.Msg_Object = Nothing
        Me.Dis_date_TXT.Name = "Dis_date_TXT"
        Me.Dis_date_TXT.Select_Auto_Show = True
        Me.Dis_date_TXT.Select_Column_Color = "NA"
        Me.Dis_date_TXT.Select_Columns = 1
        Me.Dis_date_TXT.Select_Filter = "(Name LIKE '%<value>%') or (Code LIKE '%<value>%')"
        Me.Dis_date_TXT.Select_Hide_Columns = "NA"
        Me.Dis_date_TXT.Select_Object = Nothing
        Me.Dis_date_TXT.Select_Source = Nothing
        Me.Dis_date_TXT.Size = New System.Drawing.Size(127, 15)
        Me.Dis_date_TXT.TabIndex = 3
        Me.Dis_date_TXT.Type_ = "Select"
        Me.Dis_date_TXT.Val_max = 1000000000
        Me.Dis_date_TXT.Val_min = 0
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label21.Location = New System.Drawing.Point(8, 87)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(65, 16)
        Me.Label21.TabIndex = 15
        Me.Label21.Text = "Port Code"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(520, 47)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(11, 16)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = ":"
        '
        'Carrier_Name_TXT
        '
        Me.Carrier_Name_TXT.Auto_Cleane = True
        Me.Carrier_Name_TXT.Back_color = System.Drawing.Color.White
        Me.Carrier_Name_TXT.BackColor = System.Drawing.Color.White
        Me.Carrier_Name_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Carrier_Name_TXT.Data_Link_ = ""
        Me.Carrier_Name_TXT.Decimal_ = 2
        Me.Carrier_Name_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Carrier_Name_TXT.Font_Size = 11
        Me.Carrier_Name_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Carrier_Name_TXT.Format_ = "dd-MM-yyyy"
        Me.Carrier_Name_TXT.Keydown_Support = True
        Me.Carrier_Name_TXT.Location = New System.Drawing.Point(535, 48)
        Me.Carrier_Name_TXT.Msg_Object = Nothing
        Me.Carrier_Name_TXT.Name = "Carrier_Name_TXT"
        Me.Carrier_Name_TXT.Select_Auto_Show = True
        Me.Carrier_Name_TXT.Select_Column_Color = "NA"
        Me.Carrier_Name_TXT.Select_Columns = 0
        Me.Carrier_Name_TXT.Select_Filter = Nothing
        Me.Carrier_Name_TXT.Select_Hide_Columns = "NA"
        Me.Carrier_Name_TXT.Select_Object = Nothing
        Me.Carrier_Name_TXT.Select_Source = Nothing
        Me.Carrier_Name_TXT.Size = New System.Drawing.Size(98, 15)
        Me.Carrier_Name_TXT.TabIndex = 5
        Me.Carrier_Name_TXT.Type_ = "Date"
        Me.Carrier_Name_TXT.Val_max = 1000000000
        Me.Carrier_Name_TXT.Val_min = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label7.Location = New System.Drawing.Point(383, 47)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(34, 16)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Date"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(175, 47)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(11, 16)
        Me.Label32.TabIndex = 11
        Me.Label32.Text = ":"
        '
        'Transport_LR_TXT
        '
        Me.Transport_LR_TXT.Auto_Cleane = True
        Me.Transport_LR_TXT.Back_color = System.Drawing.Color.White
        Me.Transport_LR_TXT.BackColor = System.Drawing.Color.White
        Me.Transport_LR_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Transport_LR_TXT.Data_Link_ = ""
        Me.Transport_LR_TXT.Decimal_ = 2
        Me.Transport_LR_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Transport_LR_TXT.Font_Size = 11
        Me.Transport_LR_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Transport_LR_TXT.Format_ = "dd-MM-yyyy"
        Me.Transport_LR_TXT.Keydown_Support = True
        Me.Transport_LR_TXT.Location = New System.Drawing.Point(190, 48)
        Me.Transport_LR_TXT.Msg_Object = Nothing
        Me.Transport_LR_TXT.Name = "Transport_LR_TXT"
        Me.Transport_LR_TXT.Select_Auto_Show = True
        Me.Transport_LR_TXT.Select_Column_Color = "NA"
        Me.Transport_LR_TXT.Select_Columns = 0
        Me.Transport_LR_TXT.Select_Filter = Nothing
        Me.Transport_LR_TXT.Select_Hide_Columns = "NA"
        Me.Transport_LR_TXT.Select_Object = Nothing
        Me.Transport_LR_TXT.Select_Source = Nothing
        Me.Transport_LR_TXT.Size = New System.Drawing.Size(178, 15)
        Me.Transport_LR_TXT.TabIndex = 1
        Me.Transport_LR_TXT.Type_ = "TXT"
        Me.Transport_LR_TXT.Val_max = 1000000000
        Me.Transport_LR_TXT.Val_min = 0
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label33.Location = New System.Drawing.Point(8, 48)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(94, 16)
        Me.Label33.TabIndex = 9
        Me.Label33.Text = "Port of Loading"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(520, 27)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(11, 16)
        Me.Label34.TabIndex = 8
        Me.Label34.Text = ":"
        '
        'Dis_through_TXT
        '
        Me.Dis_through_TXT.Auto_Cleane = True
        Me.Dis_through_TXT.Back_color = System.Drawing.Color.White
        Me.Dis_through_TXT.BackColor = System.Drawing.Color.White
        Me.Dis_through_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Dis_through_TXT.Data_Link_ = ""
        Me.Dis_through_TXT.Decimal_ = 2
        Me.Dis_through_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dis_through_TXT.Font_Size = 11
        Me.Dis_through_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Dis_through_TXT.Format_ = "dd-MM-yyyy"
        Me.Dis_through_TXT.Keydown_Support = True
        Me.Dis_through_TXT.Location = New System.Drawing.Point(535, 28)
        Me.Dis_through_TXT.Msg_Object = Nothing
        Me.Dis_through_TXT.Name = "Dis_through_TXT"
        Me.Dis_through_TXT.Select_Auto_Show = True
        Me.Dis_through_TXT.Select_Column_Color = "NA"
        Me.Dis_through_TXT.Select_Columns = 0
        Me.Dis_through_TXT.Select_Filter = Nothing
        Me.Dis_through_TXT.Select_Hide_Columns = "NA"
        Me.Dis_through_TXT.Select_Object = Nothing
        Me.Dis_through_TXT.Select_Source = Nothing
        Me.Dis_through_TXT.Size = New System.Drawing.Size(178, 15)
        Me.Dis_through_TXT.TabIndex = 4
        Me.Dis_through_TXT.Type_ = "TXT"
        Me.Dis_through_TXT.Val_max = 1000000000
        Me.Dis_through_TXT.Val_min = 0
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label35.Location = New System.Drawing.Point(383, 27)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(103, 16)
        Me.Label35.TabIndex = 6
        Me.Label35.Text = "Shipping Bill No."
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(175, 28)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(11, 16)
        Me.Label36.TabIndex = 5
        Me.Label36.Text = ":"
        '
        'Dis_Doc_TXT
        '
        Me.Dis_Doc_TXT.Auto_Cleane = True
        Me.Dis_Doc_TXT.Back_color = System.Drawing.Color.White
        Me.Dis_Doc_TXT.BackColor = System.Drawing.Color.White
        Me.Dis_Doc_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Dis_Doc_TXT.Data_Link_ = ""
        Me.Dis_Doc_TXT.Decimal_ = 2
        Me.Dis_Doc_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dis_Doc_TXT.Font_Size = 11
        Me.Dis_Doc_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Dis_Doc_TXT.Format_ = "dd-MM-yyyy"
        Me.Dis_Doc_TXT.Keydown_Support = True
        Me.Dis_Doc_TXT.Location = New System.Drawing.Point(190, 28)
        Me.Dis_Doc_TXT.Msg_Object = Nothing
        Me.Dis_Doc_TXT.Name = "Dis_Doc_TXT"
        Me.Dis_Doc_TXT.Select_Auto_Show = True
        Me.Dis_Doc_TXT.Select_Column_Color = "NA"
        Me.Dis_Doc_TXT.Select_Columns = 0
        Me.Dis_Doc_TXT.Select_Filter = " "
        Me.Dis_Doc_TXT.Select_Hide_Columns = "NA"
        Me.Dis_Doc_TXT.Select_Object = Nothing
        Me.Dis_Doc_TXT.Select_Source = Nothing
        Me.Dis_Doc_TXT.Size = New System.Drawing.Size(178, 15)
        Me.Dis_Doc_TXT.TabIndex = 0
        Me.Dis_Doc_TXT.Type_ = "TXT"
        Me.Dis_Doc_TXT.Val_max = 1000000000
        Me.Dis_Doc_TXT.Val_min = 0
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(8, 28)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(168, 16)
        Me.Label37.TabIndex = 3
        Me.Label37.Text = "Place of Receipt by Shipper"
        '
        'Label38
        '
        Me.Label38.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label38.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(0, 0)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(722, 21)
        Me.Label38.TabIndex = 2
        Me.Label38.Text = "Export Details"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(520, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(11, 16)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = ":"
        '
        'LUT_TXT
        '
        Me.LUT_TXT.Auto_Cleane = True
        Me.LUT_TXT.Back_color = System.Drawing.Color.White
        Me.LUT_TXT.BackColor = System.Drawing.Color.White
        Me.LUT_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LUT_TXT.Data_Link_ = ""
        Me.LUT_TXT.Decimal_ = 2
        Me.LUT_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LUT_TXT.Font_Size = 11
        Me.LUT_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.LUT_TXT.Format_ = "dd-MM-yyyy"
        Me.LUT_TXT.Keydown_Support = True
        Me.LUT_TXT.Location = New System.Drawing.Point(535, 68)
        Me.LUT_TXT.Msg_Object = Nothing
        Me.LUT_TXT.Name = "LUT_TXT"
        Me.LUT_TXT.Select_Auto_Show = True
        Me.LUT_TXT.Select_Column_Color = "NA"
        Me.LUT_TXT.Select_Columns = 0
        Me.LUT_TXT.Select_Filter = Nothing
        Me.LUT_TXT.Select_Hide_Columns = "NA"
        Me.LUT_TXT.Select_Object = Nothing
        Me.LUT_TXT.Select_Source = Nothing
        Me.LUT_TXT.Size = New System.Drawing.Size(178, 15)
        Me.LUT_TXT.TabIndex = 6
        Me.LUT_TXT.Type_ = "TXT"
        Me.LUT_TXT.Val_max = 1000000000
        Me.LUT_TXT.Val_min = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label4.Location = New System.Drawing.Point(383, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 16)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "LUT/Bond No."
        '
        'vc_export_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Beige
        Me.ClientSize = New System.Drawing.Size(1107, 702)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "vc_export_frm"
        Me.Text = "vc_export_frm"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        CType(Me.Port_Source, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents SAVE_TXT As Tools.TXT
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Label20 As Label
    Friend WithEvents Dis_date_TXT As Tools.TXT
    Friend WithEvents Label21 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Carrier_Name_TXT As Tools.TXT
    Friend WithEvents Label7 As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents Transport_LR_TXT As Tools.TXT
    Friend WithEvents Label33 As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents Dis_through_TXT As Tools.TXT
    Friend WithEvents Label35 As Label
    Friend WithEvents Label36 As Label
    Friend WithEvents Dis_Doc_TXT As Tools.TXT
    Friend WithEvents Label37 As Label
    Friend WithEvents Label38 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Txt1 As Tools.TXT
    Friend WithEvents Label2 As Label
    Friend WithEvents Port_Source As BindingSource
    Friend WithEvents Label3 As Label
    Friend WithEvents LUT_TXT As Tools.TXT
    Friend WithEvents Label4 As Label
End Class
