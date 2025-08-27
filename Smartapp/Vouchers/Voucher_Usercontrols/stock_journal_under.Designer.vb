<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class stock_journal_under
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
        Me.Particuls_Panel = New System.Windows.Forms.Panel()
        Me.Qty_TXT = New Tools.TXT()
        Me.Item_TXT = New Tools.TXT()
        Me.Unit_Lst = New Tools.TXT()
        Me.Rate_TXT = New Tools.TXT()
        Me.Amount_TXT = New Tools.TXT()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Unit_Alte_Lab = New System.Windows.Forms.Label()
        Me.Qty_Alte_Lab = New System.Windows.Forms.Label()
        Me.Discription_Label = New System.Windows.Forms.Label()
        Me.Unit_Source = New System.Windows.Forms.BindingSource(Me.components)
        Me.batch_Panel = New System.Windows.Forms.Panel()
        Me.Exp_TXT = New Tools.TXT()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Mfg_TXT = New Tools.TXT()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Batch_TXT = New Tools.TXT()
        Me.Batch_Source = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Particuls_Panel.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.Unit_Source, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.batch_Panel.SuspendLayout()
        CType(Me.Batch_Source, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Particuls_Panel
        '
        Me.Particuls_Panel.Controls.Add(Me.Qty_TXT)
        Me.Particuls_Panel.Controls.Add(Me.Item_TXT)
        Me.Particuls_Panel.Controls.Add(Me.Unit_Lst)
        Me.Particuls_Panel.Controls.Add(Me.Rate_TXT)
        Me.Particuls_Panel.Controls.Add(Me.Amount_TXT)
        Me.Particuls_Panel.Dock = System.Windows.Forms.DockStyle.Top
        Me.Particuls_Panel.Location = New System.Drawing.Point(0, 0)
        Me.Particuls_Panel.Name = "Particuls_Panel"
        Me.Particuls_Panel.Size = New System.Drawing.Size(786, 16)
        Me.Particuls_Panel.TabIndex = 1
        '
        'Qty_TXT
        '
        Me.Qty_TXT.Auto_Cleane = True
        Me.Qty_TXT.Back_color = System.Drawing.Color.Empty
        Me.Qty_TXT.BackColor = System.Drawing.Color.White
        Me.Qty_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Qty_TXT.Data_Link_ = ""
        Me.Qty_TXT.Decimal_ = 2
        Me.Qty_TXT.Dock = System.Windows.Forms.DockStyle.Right
        Me.Qty_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Qty_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Qty_TXT.Font_Size = 10
        Me.Qty_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Qty_TXT.Format_ = "dd-MM-yyyy"
        Me.Qty_TXT.Keydown_Support = True
        Me.Qty_TXT.Location = New System.Drawing.Point(476, 0)
        Me.Qty_TXT.Msg_Object = Nothing
        Me.Qty_TXT.Name = "Qty_TXT"
        Me.Qty_TXT.Select_Auto_Show = True
        Me.Qty_TXT.Select_Column_Color = "NA"
        Me.Qty_TXT.Select_Columns = 0
        Me.Qty_TXT.Select_Filter = Nothing
        Me.Qty_TXT.Select_Hide_Columns = "NA"
        Me.Qty_TXT.Select_Object = Nothing
        Me.Qty_TXT.Select_Source = Nothing
        Me.Qty_TXT.Size = New System.Drawing.Size(70, 15)
        Me.Qty_TXT.TabIndex = 4
        Me.Qty_TXT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Qty_TXT.Type_ = "Num"
        Me.Qty_TXT.Val_max = 1000000000
        Me.Qty_TXT.Val_min = 0
        '
        'Item_TXT
        '
        Me.Item_TXT.Auto_Cleane = True
        Me.Item_TXT.Back_color = System.Drawing.Color.Empty
        Me.Item_TXT.BackColor = System.Drawing.Color.White
        Me.Item_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Item_TXT.Data_Link_ = ""
        Me.Item_TXT.Decimal_ = 2
        Me.Item_TXT.Dock = System.Windows.Forms.DockStyle.Left
        Me.Item_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Item_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Item_TXT.Font_Size = 10
        Me.Item_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Item_TXT.Format_ = "dd-MM-yyyy"
        Me.Item_TXT.Keydown_Support = True
        Me.Item_TXT.Location = New System.Drawing.Point(0, 0)
        Me.Item_TXT.Msg_Object = Nothing
        Me.Item_TXT.Name = "Item_TXT"
        Me.Item_TXT.Select_Auto_Show = True
        Me.Item_TXT.Select_Column_Color = "NA"
        Me.Item_TXT.Select_Columns = 0
        Me.Item_TXT.Select_Filter = "(Name Like '%<value>%' or Alias LIKE '%<value>%') or (Name = 'End of List') or (S" &
    "tock = 'Create')"
        Me.Item_TXT.Select_Hide_Columns = "NA"
        Me.Item_TXT.Select_Object = Nothing
        Me.Item_TXT.Select_Source = Nothing
        Me.Item_TXT.Size = New System.Drawing.Size(300, 15)
        Me.Item_TXT.TabIndex = 0
        Me.Item_TXT.Type_ = "Select"
        Me.Item_TXT.Val_max = 1000000000
        Me.Item_TXT.Val_min = 0
        '
        'Unit_Lst
        '
        Me.Unit_Lst.Auto_Cleane = True
        Me.Unit_Lst.Back_color = System.Drawing.Color.Empty
        Me.Unit_Lst.BackColor = System.Drawing.Color.White
        Me.Unit_Lst.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Unit_Lst.Data_Link_ = ""
        Me.Unit_Lst.Decimal_ = 2
        Me.Unit_Lst.Dock = System.Windows.Forms.DockStyle.Right
        Me.Unit_Lst.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Unit_Lst.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Unit_Lst.Font_Size = 10
        Me.Unit_Lst.Font_Style = System.Drawing.FontStyle.Bold
        Me.Unit_Lst.Format_ = "dd-MM-yyyy"
        Me.Unit_Lst.Keydown_Support = True
        Me.Unit_Lst.Location = New System.Drawing.Point(546, 0)
        Me.Unit_Lst.Msg_Object = Nothing
        Me.Unit_Lst.Name = "Unit_Lst"
        Me.Unit_Lst.Select_Auto_Show = True
        Me.Unit_Lst.Select_Column_Color = "NA"
        Me.Unit_Lst.Select_Columns = 0
        Me.Unit_Lst.Select_Filter = "(Name Like '%<value>%')"
        Me.Unit_Lst.Select_Hide_Columns = "NA"
        Me.Unit_Lst.Select_Object = Nothing
        Me.Unit_Lst.Select_Source = Nothing
        Me.Unit_Lst.Size = New System.Drawing.Size(50, 15)
        Me.Unit_Lst.TabIndex = 5
        Me.Unit_Lst.Type_ = "Select"
        Me.Unit_Lst.Val_max = 1000000000
        Me.Unit_Lst.Val_min = 0
        '
        'Rate_TXT
        '
        Me.Rate_TXT.Auto_Cleane = True
        Me.Rate_TXT.Back_color = System.Drawing.Color.Empty
        Me.Rate_TXT.BackColor = System.Drawing.Color.White
        Me.Rate_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Rate_TXT.Data_Link_ = ""
        Me.Rate_TXT.Decimal_ = 2
        Me.Rate_TXT.Dock = System.Windows.Forms.DockStyle.Right
        Me.Rate_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Rate_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Rate_TXT.Font_Size = 10
        Me.Rate_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Rate_TXT.Format_ = "dd-MM-yyyy"
        Me.Rate_TXT.Keydown_Support = True
        Me.Rate_TXT.Location = New System.Drawing.Point(596, 0)
        Me.Rate_TXT.Msg_Object = Nothing
        Me.Rate_TXT.Name = "Rate_TXT"
        Me.Rate_TXT.Select_Auto_Show = True
        Me.Rate_TXT.Select_Column_Color = "NA"
        Me.Rate_TXT.Select_Columns = 0
        Me.Rate_TXT.Select_Filter = Nothing
        Me.Rate_TXT.Select_Hide_Columns = "NA"
        Me.Rate_TXT.Select_Object = Nothing
        Me.Rate_TXT.Select_Source = Nothing
        Me.Rate_TXT.Size = New System.Drawing.Size(90, 15)
        Me.Rate_TXT.TabIndex = 7
        Me.Rate_TXT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Rate_TXT.Type_ = "Num"
        Me.Rate_TXT.Val_max = 1000000000
        Me.Rate_TXT.Val_min = 0
        '
        'Amount_TXT
        '
        Me.Amount_TXT.Auto_Cleane = True
        Me.Amount_TXT.Back_color = System.Drawing.Color.Empty
        Me.Amount_TXT.BackColor = System.Drawing.Color.White
        Me.Amount_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Amount_TXT.Data_Link_ = ""
        Me.Amount_TXT.Decimal_ = 2
        Me.Amount_TXT.Dock = System.Windows.Forms.DockStyle.Right
        Me.Amount_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Amount_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Amount_TXT.Font_Size = 10
        Me.Amount_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Amount_TXT.Format_ = "dd-MM-yyyy"
        Me.Amount_TXT.Keydown_Support = True
        Me.Amount_TXT.Location = New System.Drawing.Point(686, 0)
        Me.Amount_TXT.Msg_Object = Nothing
        Me.Amount_TXT.Name = "Amount_TXT"
        Me.Amount_TXT.Select_Auto_Show = True
        Me.Amount_TXT.Select_Column_Color = "NA"
        Me.Amount_TXT.Select_Columns = 0
        Me.Amount_TXT.Select_Filter = Nothing
        Me.Amount_TXT.Select_Hide_Columns = "NA"
        Me.Amount_TXT.Select_Object = Nothing
        Me.Amount_TXT.Select_Source = Nothing
        Me.Amount_TXT.Size = New System.Drawing.Size(100, 15)
        Me.Amount_TXT.TabIndex = 9
        Me.Amount_TXT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Amount_TXT.Type_ = "Num"
        Me.Amount_TXT.Val_max = 1000000000
        Me.Amount_TXT.Val_min = 0
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.Controls.Add(Me.Unit_Alte_Lab)
        Me.Panel1.Controls.Add(Me.Qty_Alte_Lab)
        Me.Panel1.Controls.Add(Me.Discription_Label)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 16)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(786, 16)
        Me.Panel1.TabIndex = 2
        '
        'Unit_Alte_Lab
        '
        Me.Unit_Alte_Lab.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Unit_Alte_Lab.ForeColor = System.Drawing.Color.DimGray
        Me.Unit_Alte_Lab.Location = New System.Drawing.Point(668, 0)
        Me.Unit_Alte_Lab.Name = "Unit_Alte_Lab"
        Me.Unit_Alte_Lab.Size = New System.Drawing.Size(91, 16)
        Me.Unit_Alte_Lab.TabIndex = 10
        '
        'Qty_Alte_Lab
        '
        Me.Qty_Alte_Lab.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Qty_Alte_Lab.ForeColor = System.Drawing.Color.DimGray
        Me.Qty_Alte_Lab.Location = New System.Drawing.Point(598, 0)
        Me.Qty_Alte_Lab.Name = "Qty_Alte_Lab"
        Me.Qty_Alte_Lab.Size = New System.Drawing.Size(91, 16)
        Me.Qty_Alte_Lab.TabIndex = 9
        Me.Qty_Alte_Lab.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Discription_Label
        '
        Me.Discription_Label.AutoSize = True
        Me.Discription_Label.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Discription_Label.ForeColor = System.Drawing.Color.DimGray
        Me.Discription_Label.Location = New System.Drawing.Point(16, 0)
        Me.Discription_Label.Name = "Discription_Label"
        Me.Discription_Label.Size = New System.Drawing.Size(0, 16)
        Me.Discription_Label.TabIndex = 2
        '
        'batch_Panel
        '
        Me.batch_Panel.AutoSize = True
        Me.batch_Panel.Controls.Add(Me.Exp_TXT)
        Me.batch_Panel.Controls.Add(Me.Label4)
        Me.batch_Panel.Controls.Add(Me.Label2)
        Me.batch_Panel.Controls.Add(Me.Mfg_TXT)
        Me.batch_Panel.Controls.Add(Me.Label1)
        Me.batch_Panel.Controls.Add(Me.Label3)
        Me.batch_Panel.Controls.Add(Me.Batch_TXT)
        Me.batch_Panel.Dock = System.Windows.Forms.DockStyle.Top
        Me.batch_Panel.Location = New System.Drawing.Point(0, 32)
        Me.batch_Panel.Name = "batch_Panel"
        Me.batch_Panel.Size = New System.Drawing.Size(786, 21)
        Me.batch_Panel.TabIndex = 3
        Me.batch_Panel.Visible = False
        '
        'Exp_TXT
        '
        Me.Exp_TXT.Auto_Cleane = True
        Me.Exp_TXT.Back_color = System.Drawing.Color.Empty
        Me.Exp_TXT.BackColor = System.Drawing.Color.White
        Me.Exp_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Exp_TXT.Data_Link_ = ""
        Me.Exp_TXT.Decimal_ = 2
        Me.Exp_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Exp_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Exp_TXT.Font_Size = 10
        Me.Exp_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Exp_TXT.Format_ = "dd-MM-yyyy"
        Me.Exp_TXT.Keydown_Support = True
        Me.Exp_TXT.Location = New System.Drawing.Point(495, 3)
        Me.Exp_TXT.Msg_Object = Nothing
        Me.Exp_TXT.Name = "Exp_TXT"
        Me.Exp_TXT.Select_Auto_Show = True
        Me.Exp_TXT.Select_Column_Color = "NA"
        Me.Exp_TXT.Select_Columns = 0
        Me.Exp_TXT.Select_Filter = "(Name Like '%<value>%' or Alias LIKE '%<value>%') or (Name = 'End of List') or (S" &
    "tock = 'Create')"
        Me.Exp_TXT.Select_Hide_Columns = "NA"
        Me.Exp_TXT.Select_Object = Nothing
        Me.Exp_TXT.Select_Source = Nothing
        Me.Exp_TXT.Size = New System.Drawing.Size(80, 15)
        Me.Exp_TXT.TabIndex = 6
        Me.Exp_TXT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Exp_TXT.Type_ = "Select"
        Me.Exp_TXT.Val_max = 1000000000
        Me.Exp_TXT.Val_min = 0
        Me.Exp_TXT.Visible = False
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(414, 2)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 16)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Exp Date :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(238, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 16)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Mfg Date :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Mfg_TXT
        '
        Me.Mfg_TXT.Auto_Cleane = True
        Me.Mfg_TXT.Back_color = System.Drawing.Color.Empty
        Me.Mfg_TXT.BackColor = System.Drawing.Color.White
        Me.Mfg_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Mfg_TXT.Data_Link_ = ""
        Me.Mfg_TXT.Decimal_ = 2
        Me.Mfg_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Mfg_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Mfg_TXT.Font_Size = 10
        Me.Mfg_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Mfg_TXT.Format_ = "dd-MM-yyyy"
        Me.Mfg_TXT.Keydown_Support = True
        Me.Mfg_TXT.Location = New System.Drawing.Point(319, 3)
        Me.Mfg_TXT.Msg_Object = Nothing
        Me.Mfg_TXT.Name = "Mfg_TXT"
        Me.Mfg_TXT.Select_Auto_Show = True
        Me.Mfg_TXT.Select_Column_Color = "NA"
        Me.Mfg_TXT.Select_Columns = 0
        Me.Mfg_TXT.Select_Filter = "(Name Like '%<value>%' or Alias LIKE '%<value>%') or (Name = 'End of List') or (S" &
    "tock = 'Create')"
        Me.Mfg_TXT.Select_Hide_Columns = "NA"
        Me.Mfg_TXT.Select_Object = Nothing
        Me.Mfg_TXT.Select_Source = Nothing
        Me.Mfg_TXT.Size = New System.Drawing.Size(88, 15)
        Me.Mfg_TXT.TabIndex = 5
        Me.Mfg_TXT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Mfg_TXT.Type_ = "Select"
        Me.Mfg_TXT.Val_max = 1000000000
        Me.Mfg_TXT.Val_min = 0
        Me.Mfg_TXT.Visible = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(3, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 16)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Batch No. :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(16, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 16)
        Me.Label3.TabIndex = 2
        '
        'Batch_TXT
        '
        Me.Batch_TXT.Auto_Cleane = True
        Me.Batch_TXT.Back_color = System.Drawing.Color.Empty
        Me.Batch_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Batch_TXT.Data_Link_ = ""
        Me.Batch_TXT.Decimal_ = 2
        Me.Batch_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Batch_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Batch_TXT.Font_Size = 10
        Me.Batch_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Batch_TXT.Format_ = "dd-MM-yyyy"
        Me.Batch_TXT.Keydown_Support = True
        Me.Batch_TXT.Location = New System.Drawing.Point(81, 3)
        Me.Batch_TXT.Msg_Object = Nothing
        Me.Batch_TXT.Name = "Batch_TXT"
        Me.Batch_TXT.Select_Auto_Show = True
        Me.Batch_TXT.Select_Column_Color = "NA"
        Me.Batch_TXT.Select_Columns = 0
        Me.Batch_TXT.Select_Filter = "(Name Like '%<value>%') or Stock Like 'Create Batch'"
        Me.Batch_TXT.Select_Hide_Columns = "NA"
        Me.Batch_TXT.Select_Object = Nothing
        Me.Batch_TXT.Select_Source = Nothing
        Me.Batch_TXT.Size = New System.Drawing.Size(151, 15)
        Me.Batch_TXT.TabIndex = 4
        Me.Batch_TXT.Type_ = "Select"
        Me.Batch_TXT.Val_max = 1000000000
        Me.Batch_TXT.Val_min = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.LightGray
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 53)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(786, 1)
        Me.Panel2.TabIndex = 4
        '
        'stock_journal_under
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.batch_Panel)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Particuls_Panel)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "stock_journal_under"
        Me.Size = New System.Drawing.Size(786, 172)
        Me.Particuls_Panel.ResumeLayout(False)
        Me.Particuls_Panel.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.Unit_Source, System.ComponentModel.ISupportInitialize).EndInit()
        Me.batch_Panel.ResumeLayout(False)
        Me.batch_Panel.PerformLayout()
        CType(Me.Batch_Source, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Particuls_Panel As Panel
    Friend WithEvents Qty_TXT As Tools.TXT
    Friend WithEvents Item_TXT As Tools.TXT
    Friend WithEvents Unit_Lst As Tools.TXT
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Unit_Alte_Lab As Label
    Friend WithEvents Qty_Alte_Lab As Label
    Friend WithEvents Discription_Label As Label
    Friend WithEvents Unit_Source As BindingSource
    Friend WithEvents Rate_TXT As Tools.TXT
    Friend WithEvents Amount_TXT As Tools.TXT
    Friend WithEvents Label3 As Label
    Public WithEvents batch_Panel As Panel
    Friend WithEvents Exp_TXT As Tools.TXT
    Friend WithEvents Mfg_TXT As Tools.TXT
    Friend WithEvents Batch_TXT As Tools.TXT
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Batch_Source As BindingSource
    Public WithEvents Panel2 As Panel
End Class
