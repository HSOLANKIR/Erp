<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class vc_Supplier_details_frm
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
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Acc_Address_TXT = New Tools.TXT()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Txt2 = New Tools.TXT()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Date_TXT = New Tools.TXT()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Acc_Mailing_TXT = New Tools.TXT()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.save_txt = New Tools.TXT()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.save_txt)
        Me.Panel1.Location = New System.Drawing.Point(410, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(620, 263)
        Me.Panel1.TabIndex = 1
        '
        'Panel4
        '
        Me.Panel4.AutoSize = True
        Me.Panel4.Controls.Add(Me.Label12)
        Me.Panel4.Controls.Add(Me.Acc_Address_TXT)
        Me.Panel4.Controls.Add(Me.Panel6)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 130)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.Panel4.Size = New System.Drawing.Size(618, 128)
        Me.Panel4.TabIndex = 2
        '
        'Label12
        '
        Me.Label12.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(0, 1)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(618, 24)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "Narration"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Acc_Address_TXT
        '
        Me.Acc_Address_TXT.Auto_Cleane = True
        Me.Acc_Address_TXT.Back_color = System.Drawing.Color.White
        Me.Acc_Address_TXT.BackColor = System.Drawing.Color.White
        Me.Acc_Address_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Acc_Address_TXT.Data_Link_ = ""
        Me.Acc_Address_TXT.Decimal_ = 2
        Me.Acc_Address_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Acc_Address_TXT.Font_Size = 11
        Me.Acc_Address_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Acc_Address_TXT.Format_ = "dd-MM-yyyy"
        Me.Acc_Address_TXT.Keydown_Support = True
        Me.Acc_Address_TXT.Location = New System.Drawing.Point(9, 32)
        Me.Acc_Address_TXT.Msg_Object = Nothing
        Me.Acc_Address_TXT.Multiline = True
        Me.Acc_Address_TXT.Name = "Acc_Address_TXT"
        Me.Acc_Address_TXT.Select_Auto_Show = True
        Me.Acc_Address_TXT.Select_Column_Color = "NA"
        Me.Acc_Address_TXT.Select_Columns = 0
        Me.Acc_Address_TXT.Select_Filter = Nothing
        Me.Acc_Address_TXT.Select_Hide_Columns = "NA"
        Me.Acc_Address_TXT.Select_Object = Nothing
        Me.Acc_Address_TXT.Select_Source = Nothing
        Me.Acc_Address_TXT.Size = New System.Drawing.Size(600, 83)
        Me.Acc_Address_TXT.TabIndex = 12
        Me.Acc_Address_TXT.Type_ = "TXT"
        Me.Acc_Address_TXT.Val_max = 1000000000
        Me.Acc_Address_TXT.Val_min = 0
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(618, 1)
        Me.Panel6.TabIndex = 15
        '
        'Panel3
        '
        Me.Panel3.AutoSize = True
        Me.Panel3.Controls.Add(Me.Txt2)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.Panel5)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 65)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.Panel3.Size = New System.Drawing.Size(618, 65)
        Me.Panel3.TabIndex = 1
        Me.Panel3.Visible = False
        '
        'Txt2
        '
        Me.Txt2.Auto_Cleane = True
        Me.Txt2.Back_color = System.Drawing.Color.White
        Me.Txt2.BackColor = System.Drawing.Color.White
        Me.Txt2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Txt2.Data_Link_ = ""
        Me.Txt2.Decimal_ = 2
        Me.Txt2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt2.Font_Size = 11
        Me.Txt2.Font_Style = System.Drawing.FontStyle.Bold
        Me.Txt2.Format_ = "dd-MM-yyyy"
        Me.Txt2.Keydown_Support = True
        Me.Txt2.Location = New System.Drawing.Point(170, 37)
        Me.Txt2.Msg_Object = Nothing
        Me.Txt2.Name = "Txt2"
        Me.Txt2.Select_Auto_Show = True
        Me.Txt2.Select_Column_Color = "NA"
        Me.Txt2.Select_Columns = 0
        Me.Txt2.Select_Filter = "Name LIKE '%<value>%'"
        Me.Txt2.Select_Hide_Columns = "NA"
        Me.Txt2.Select_Object = Nothing
        Me.Txt2.Select_Source = Nothing
        Me.Txt2.Size = New System.Drawing.Size(282, 15)
        Me.Txt2.TabIndex = 7
        Me.Txt2.Type_ = "Select"
        Me.Txt2.Val_max = 1000000000
        Me.Txt2.Val_min = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(153, 36)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(11, 16)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = ":"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(5, 36)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(139, 16)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "Reason of issuing note"
        '
        'Label11
        '
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(0, 1)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(618, 24)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "Credit/Debit Note Details"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(618, 1)
        Me.Panel5.TabIndex = 14
        '
        'Panel2
        '
        Me.Panel2.AutoSize = True
        Me.Panel2.Controls.Add(Me.Date_TXT)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Acc_Mailing_TXT)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.Panel2.Size = New System.Drawing.Size(618, 65)
        Me.Panel2.TabIndex = 0
        Me.Panel2.Visible = False
        '
        'Date_TXT
        '
        Me.Date_TXT.Auto_Cleane = True
        Me.Date_TXT.Back_color = System.Drawing.Color.White
        Me.Date_TXT.BackColor = System.Drawing.Color.White
        Me.Date_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Date_TXT.Data_Link_ = ""
        Me.Date_TXT.Decimal_ = 2
        Me.Date_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Date_TXT.Font_Size = 11
        Me.Date_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Date_TXT.Format_ = "dd-MM-yyyy"
        Me.Date_TXT.Keydown_Support = True
        Me.Date_TXT.Location = New System.Drawing.Point(477, 37)
        Me.Date_TXT.Msg_Object = Nothing
        Me.Date_TXT.Name = "Date_TXT"
        Me.Date_TXT.Select_Auto_Show = True
        Me.Date_TXT.Select_Column_Color = "NA"
        Me.Date_TXT.Select_Columns = 0
        Me.Date_TXT.Select_Filter = Nothing
        Me.Date_TXT.Select_Hide_Columns = "NA"
        Me.Date_TXT.Select_Object = Nothing
        Me.Date_TXT.Select_Source = Nothing
        Me.Date_TXT.Size = New System.Drawing.Size(131, 15)
        Me.Date_TXT.TabIndex = 11
        Me.Date_TXT.Type_ = "Date"
        Me.Date_TXT.Val_max = 1000000000
        Me.Date_TXT.Val_min = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(460, 36)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(11, 16)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = ":"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(307, 36)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(136, 16)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Supplier Voucher Date"
        '
        'Acc_Mailing_TXT
        '
        Me.Acc_Mailing_TXT.Auto_Cleane = True
        Me.Acc_Mailing_TXT.Back_color = System.Drawing.Color.White
        Me.Acc_Mailing_TXT.BackColor = System.Drawing.Color.White
        Me.Acc_Mailing_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Acc_Mailing_TXT.Data_Link_ = ""
        Me.Acc_Mailing_TXT.Decimal_ = 2
        Me.Acc_Mailing_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Acc_Mailing_TXT.Font_Size = 11
        Me.Acc_Mailing_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Acc_Mailing_TXT.Format_ = "dd-MM-yyyy"
        Me.Acc_Mailing_TXT.Keydown_Support = True
        Me.Acc_Mailing_TXT.Location = New System.Drawing.Point(170, 37)
        Me.Acc_Mailing_TXT.Msg_Object = Nothing
        Me.Acc_Mailing_TXT.Name = "Acc_Mailing_TXT"
        Me.Acc_Mailing_TXT.Select_Auto_Show = True
        Me.Acc_Mailing_TXT.Select_Column_Color = "NA"
        Me.Acc_Mailing_TXT.Select_Columns = 0
        Me.Acc_Mailing_TXT.Select_Filter = Nothing
        Me.Acc_Mailing_TXT.Select_Hide_Columns = "NA"
        Me.Acc_Mailing_TXT.Select_Object = Nothing
        Me.Acc_Mailing_TXT.Select_Source = Nothing
        Me.Acc_Mailing_TXT.Size = New System.Drawing.Size(120, 15)
        Me.Acc_Mailing_TXT.TabIndex = 7
        Me.Acc_Mailing_TXT.Type_ = "TXT"
        Me.Acc_Mailing_TXT.Val_max = 1000000000
        Me.Acc_Mailing_TXT.Val_min = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(153, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(11, 16)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = ":"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(129, 16)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Supplier Voucher No."
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(618, 24)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Supplier Details"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'save_txt
        '
        Me.save_txt.Auto_Cleane = True
        Me.save_txt.Back_color = System.Drawing.Color.White
        Me.save_txt.BackColor = System.Drawing.Color.White
        Me.save_txt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.save_txt.Data_Link_ = ""
        Me.save_txt.Decimal_ = 2
        Me.save_txt.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.save_txt.Font_Size = 10
        Me.save_txt.Font_Style = System.Drawing.FontStyle.Bold
        Me.save_txt.Format_ = "dd-MM-yyyy"
        Me.save_txt.Keydown_Support = True
        Me.save_txt.Location = New System.Drawing.Point(460, 161)
        Me.save_txt.Msg_Object = Nothing
        Me.save_txt.Name = "save_txt"
        Me.save_txt.Select_Auto_Show = True
        Me.save_txt.Select_Column_Color = "NA"
        Me.save_txt.Select_Columns = 0
        Me.save_txt.Select_Filter = Nothing
        Me.save_txt.Select_Hide_Columns = "NA"
        Me.save_txt.Select_Object = Nothing
        Me.save_txt.Select_Source = Nothing
        Me.save_txt.Size = New System.Drawing.Size(1, 16)
        Me.save_txt.TabIndex = 500
        Me.save_txt.Type_ = "TXT"
        Me.save_txt.Val_max = 1000000000
        Me.save_txt.Val_min = 0
        '
        'vc_Supplier_details_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Cornsilk
        Me.ClientSize = New System.Drawing.Size(1286, 705)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "vc_Supplier_details_frm"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents save_txt As Tools.TXT
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Acc_Mailing_TXT As Tools.TXT
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Date_TXT As Tools.TXT
    Friend WithEvents Acc_Address_TXT As Tools.TXT
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Txt2 As Tools.TXT
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label12 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents BindingSource1 As BindingSource
End Class
