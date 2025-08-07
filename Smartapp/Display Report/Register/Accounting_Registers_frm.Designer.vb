<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Accounting_Registers_frm
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.BG_Panel = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Grid1 = New System.Windows.Forms.DataGridView()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Total_Vouchers_Label = New System.Windows.Forms.Label()
        Me.Total_Labale = New System.Windows.Forms.Label()
        Me.TableLayoutPanel13 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Frm_Date_LB = New System.Windows.Forms.Label()
        Me.To_Date_LB = New System.Windows.Forms.Label()
        Me.Acc_LB = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Txt1 = New Tools.TXT()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Ledgeer_Filter_TXT = New Tools.TXT()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Ledger_Source = New System.Windows.Forms.BindingSource(Me.components)
        Me.BG_Panel.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.Grid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel7.SuspendLayout()
        Me.TableLayoutPanel13.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.Ledger_Source, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BG_Panel
        '
        Me.BG_Panel.BackColor = System.Drawing.Color.White
        Me.BG_Panel.Controls.Add(Me.Panel1)
        Me.BG_Panel.Controls.Add(Me.Panel7)
        Me.BG_Panel.Controls.Add(Me.Panel2)
        Me.BG_Panel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BG_Panel.Location = New System.Drawing.Point(0, 0)
        Me.BG_Panel.Name = "BG_Panel"
        Me.BG_Panel.Size = New System.Drawing.Size(1370, 705)
        Me.BG_Panel.TabIndex = 4
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Grid1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 20)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1370, 665)
        Me.Panel1.TabIndex = 0
        '
        'Grid1
        '
        Me.Grid1.AllowUserToAddRows = False
        Me.Grid1.AllowUserToDeleteRows = False
        Me.Grid1.BackgroundColor = System.Drawing.Color.White
        Me.Grid1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Grid1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.Grid1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grid1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(48, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grid1.DefaultCellStyle = DataGridViewCellStyle4
        Me.Grid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid1.EnableHeadersVisualStyles = False
        Me.Grid1.GridColor = System.Drawing.Color.Silver
        Me.Grid1.Location = New System.Drawing.Point(0, 0)
        Me.Grid1.Margin = New System.Windows.Forms.Padding(0)
        Me.Grid1.Name = "Grid1"
        Me.Grid1.ReadOnly = True
        Me.Grid1.RowHeadersVisible = False
        Me.Grid1.RowTemplate.Height = 18
        Me.Grid1.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Grid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid1.Size = New System.Drawing.Size(1370, 665)
        Me.Grid1.TabIndex = 3
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.OldLace
        Me.Panel7.Controls.Add(Me.Total_Vouchers_Label)
        Me.Panel7.Controls.Add(Me.Total_Labale)
        Me.Panel7.Controls.Add(Me.TableLayoutPanel13)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel7.Location = New System.Drawing.Point(0, 685)
        Me.Panel7.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(1370, 20)
        Me.Panel7.TabIndex = 2
        '
        'Total_Vouchers_Label
        '
        Me.Total_Vouchers_Label.Dock = System.Windows.Forms.DockStyle.Right
        Me.Total_Vouchers_Label.Location = New System.Drawing.Point(1110, 0)
        Me.Total_Vouchers_Label.Name = "Total_Vouchers_Label"
        Me.Total_Vouchers_Label.Size = New System.Drawing.Size(130, 20)
        Me.Total_Vouchers_Label.TabIndex = 8
        Me.Total_Vouchers_Label.Text = "0.00"
        Me.Total_Vouchers_Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Total_Labale
        '
        Me.Total_Labale.Dock = System.Windows.Forms.DockStyle.Right
        Me.Total_Labale.Location = New System.Drawing.Point(1240, 0)
        Me.Total_Labale.Name = "Total_Labale"
        Me.Total_Labale.Size = New System.Drawing.Size(130, 20)
        Me.Total_Labale.TabIndex = 7
        Me.Total_Labale.Text = "0.00"
        Me.Total_Labale.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TableLayoutPanel13
        '
        Me.TableLayoutPanel13.BackColor = System.Drawing.Color.Bisque
        Me.TableLayoutPanel13.ColumnCount = 1
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.TableLayoutPanel13.Controls.Add(Me.Label17, 0, 1)
        Me.TableLayoutPanel13.Dock = System.Windows.Forms.DockStyle.Left
        Me.TableLayoutPanel13.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel13.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel13.Name = "TableLayoutPanel13"
        Me.TableLayoutPanel13.RowCount = 2
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17.0!))
        Me.TableLayoutPanel13.Size = New System.Drawing.Size(271, 20)
        Me.TableLayoutPanel13.TabIndex = 5
        '
        'Label17
        '
        Me.Label17.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(0, 3)
        Me.Label17.Margin = New System.Windows.Forms.Padding(0)
        Me.Label17.Name = "Label17"
        Me.Label17.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.Label17.Size = New System.Drawing.Size(271, 17)
        Me.Label17.TabIndex = 5
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.OldLace
        Me.Panel2.Controls.Add(Me.Panel6)
        Me.Panel2.Controls.Add(Me.Acc_LB)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1370, 20)
        Me.Panel2.TabIndex = 1
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.Label13)
        Me.Panel6.Controls.Add(Me.Frm_Date_LB)
        Me.Panel6.Controls.Add(Me.To_Date_LB)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel6.Location = New System.Drawing.Point(1076, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(294, 20)
        Me.Panel6.TabIndex = 5
        '
        'Label13
        '
        Me.Label13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label13.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(114, 0)
        Me.Label13.Margin = New System.Windows.Forms.Padding(0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(66, 20)
        Me.Label13.TabIndex = 4
        Me.Label13.Text = "To"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Frm_Date_LB
        '
        Me.Frm_Date_LB.Dock = System.Windows.Forms.DockStyle.Left
        Me.Frm_Date_LB.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frm_Date_LB.ForeColor = System.Drawing.Color.SaddleBrown
        Me.Frm_Date_LB.Location = New System.Drawing.Point(0, 0)
        Me.Frm_Date_LB.Margin = New System.Windows.Forms.Padding(0)
        Me.Frm_Date_LB.Name = "Frm_Date_LB"
        Me.Frm_Date_LB.Size = New System.Drawing.Size(114, 20)
        Me.Frm_Date_LB.TabIndex = 3
        Me.Frm_Date_LB.Text = "10-01-2022"
        Me.Frm_Date_LB.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'To_Date_LB
        '
        Me.To_Date_LB.Dock = System.Windows.Forms.DockStyle.Right
        Me.To_Date_LB.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.To_Date_LB.ForeColor = System.Drawing.Color.SaddleBrown
        Me.To_Date_LB.Location = New System.Drawing.Point(180, 0)
        Me.To_Date_LB.Margin = New System.Windows.Forms.Padding(0)
        Me.To_Date_LB.Name = "To_Date_LB"
        Me.To_Date_LB.Size = New System.Drawing.Size(114, 20)
        Me.To_Date_LB.TabIndex = 2
        Me.To_Date_LB.Text = "10-01-2022"
        Me.To_Date_LB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Acc_LB
        '
        Me.Acc_LB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Acc_LB.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Acc_LB.Location = New System.Drawing.Point(0, 0)
        Me.Acc_LB.Name = "Acc_LB"
        Me.Acc_LB.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.Acc_LB.Size = New System.Drawing.Size(1370, 20)
        Me.Acc_LB.TabIndex = 1
        Me.Acc_LB.Text = "Cash"
        Me.Acc_LB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Panel3)
        Me.Panel4.Location = New System.Drawing.Point(378, 114)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(537, 100)
        Me.Panel4.TabIndex = 5
        '
        'Panel3
        '
        Me.Panel3.AutoSize = True
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Txt1)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.Ledgeer_Filter_TXT)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Location = New System.Drawing.Point(26, 17)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(428, 55)
        Me.Panel3.TabIndex = 3
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
        Me.Txt1.Keydown_Support = False
        Me.Txt1.Location = New System.Drawing.Point(73, 34)
        Me.Txt1.Msg_Object = Nothing
        Me.Txt1.Name = "Txt1"
        Me.Txt1.Select_Auto_Show = True
        Me.Txt1.Select_Column_Color = "NA"
        Me.Txt1.Select_Columns = 1
        Me.Txt1.Select_Filter = "Name Like '%<value>%'"
        Me.Txt1.Select_Hide_Columns = "NA"
        Me.Txt1.Select_Object = Nothing
        Me.Txt1.Select_Source = Nothing
        Me.Txt1.Size = New System.Drawing.Size(1, 16)
        Me.Txt1.TabIndex = 12
        Me.Txt1.Type_ = "Select"
        Me.Txt1.Val_max = 1000000000
        Me.Txt1.Val_min = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(122, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(11, 16)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = ":"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 30)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 16)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Acc. Ledger"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Ledgeer_Filter_TXT
        '
        Me.Ledgeer_Filter_TXT.Auto_Cleane = True
        Me.Ledgeer_Filter_TXT.Back_color = System.Drawing.Color.White
        Me.Ledgeer_Filter_TXT.BackColor = System.Drawing.Color.White
        Me.Ledgeer_Filter_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Ledgeer_Filter_TXT.Data_Link_ = ""
        Me.Ledgeer_Filter_TXT.Decimal_ = 2
        Me.Ledgeer_Filter_TXT.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Ledgeer_Filter_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Ledgeer_Filter_TXT.Font_Size = 10
        Me.Ledgeer_Filter_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Ledgeer_Filter_TXT.Format_ = "dd-MM-yyyy"
        Me.Ledgeer_Filter_TXT.Keydown_Support = False
        Me.Ledgeer_Filter_TXT.Location = New System.Drawing.Point(143, 30)
        Me.Ledgeer_Filter_TXT.Msg_Object = Nothing
        Me.Ledgeer_Filter_TXT.Name = "Ledgeer_Filter_TXT"
        Me.Ledgeer_Filter_TXT.Select_Auto_Show = True
        Me.Ledgeer_Filter_TXT.Select_Column_Color = "NA"
        Me.Ledgeer_Filter_TXT.Select_Columns = 0
        Me.Ledgeer_Filter_TXT.Select_Filter = "Name Like '%<value>%'"
        Me.Ledgeer_Filter_TXT.Select_Hide_Columns = "NA"
        Me.Ledgeer_Filter_TXT.Select_Object = Nothing
        Me.Ledgeer_Filter_TXT.Select_Source = Nothing
        Me.Ledgeer_Filter_TXT.Size = New System.Drawing.Size(280, 16)
        Me.Ledgeer_Filter_TXT.TabIndex = 9
        Me.Ledgeer_Filter_TXT.Type_ = "Select"
        Me.Ledgeer_Filter_TXT.Val_max = 1000000000
        Me.Ledgeer_Filter_TXT.Val_min = 0
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(426, 22)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Register Filter"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Accounting_Registers_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1370, 705)
        Me.Controls.Add(Me.BG_Panel)
        Me.Controls.Add(Me.Panel4)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Accounting_Registers_frm"
        Me.Text = "AAccounting_Registers_frm"
        Me.BG_Panel.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.Grid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel7.ResumeLayout(False)
        Me.TableLayoutPanel13.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.Ledger_Source, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BG_Panel As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Grid1 As DataGridView
    Friend WithEvents Panel7 As Panel
    Friend WithEvents TableLayoutPanel13 As TableLayoutPanel
    Friend WithEvents Label17 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label13 As Label
    Friend WithEvents Frm_Date_LB As Label
    Friend WithEvents To_Date_LB As Label
    Friend WithEvents Acc_LB As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Txt1 As Tools.TXT
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Ledgeer_Filter_TXT As Tools.TXT
    Friend WithEvents Label2 As Label
    Friend WithEvents Ledger_Source As BindingSource
    Friend WithEvents Total_Labale As Label
    Friend WithEvents Total_Vouchers_Label As Label
End Class
