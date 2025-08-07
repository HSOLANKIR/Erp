<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Voucher_Md_frm
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
        Dim bg_Panel As System.Windows.Forms.Panel
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Sp_voucher_create_ctrl1 = New Management.sp_voucher_create_ctrl()
        Me.cprj = New Management.prcj_voucher_create_ctrl()
        Me.Payroll = New Management.payroll_voucher_create_ctrl()
        Me.Stock_journal_create_ctrl1 = New Management.stock_journal_create_ctrl()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Save_TXT = New Tools.TXT()
        Me.Bank_Panel = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Type_TXT = New Tools.TXT()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel27 = New System.Windows.Forms.Panel()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Txt1 = New Tools.TXT()
        Me.BindingSource2 = New System.Windows.Forms.BindingSource(Me.components)
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Txt2 = New Tools.TXT()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Suffix_TXT = New Tools.TXT()
        Me.Prefix_TXT = New Tools.TXT()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Name_TXT = New Tools.TXT()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.Alias_TXT = New Tools.TXT()
        Me.Label3 = New System.Windows.Forms.Label()
        bg_Panel = New System.Windows.Forms.Panel()
        bg_Panel.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Bank_Panel.SuspendLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        Me.Panel27.SuspendLayout()
        CType(Me.BindingSource2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'bg_Panel
        '
        bg_Panel.BackColor = System.Drawing.Color.White
        bg_Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        bg_Panel.Controls.Add(Me.Panel1)
        bg_Panel.Controls.Add(Me.Panel3)
        bg_Panel.Controls.Add(Me.Bank_Panel)
        bg_Panel.Dock = System.Windows.Forms.DockStyle.Fill
        bg_Panel.Location = New System.Drawing.Point(0, 0)
        bg_Panel.Name = "bg_Panel"
        bg_Panel.Size = New System.Drawing.Size(1364, 705)
        bg_Panel.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Sp_voucher_create_ctrl1)
        Me.Panel1.Controls.Add(Me.cprj)
        Me.Panel1.Controls.Add(Me.Payroll)
        Me.Panel1.Controls.Add(Me.Stock_journal_create_ctrl1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 96)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1362, 587)
        Me.Panel1.TabIndex = 1
        '
        'Sp_voucher_create_ctrl1
        '
        Me.Sp_voucher_create_ctrl1.BackColor = System.Drawing.Color.White
        Me.Sp_voucher_create_ctrl1.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.Sp_voucher_create_ctrl1.Location = New System.Drawing.Point(21, 4)
        Me.Sp_voucher_create_ctrl1.Margin = New System.Windows.Forms.Padding(4)
        Me.Sp_voucher_create_ctrl1.Name = "Sp_voucher_create_ctrl1"
        Me.Sp_voucher_create_ctrl1.Size = New System.Drawing.Size(105, 135)
        Me.Sp_voucher_create_ctrl1.TabIndex = 86
        Me.Sp_voucher_create_ctrl1.Visible = False
        '
        'cprj
        '
        Me.cprj.AutoScroll = True
        Me.cprj.BackColor = System.Drawing.Color.White
        Me.cprj.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cprj.Location = New System.Drawing.Point(309, 4)
        Me.cprj.Margin = New System.Windows.Forms.Padding(4)
        Me.cprj.Name = "cprj"
        Me.cprj.Size = New System.Drawing.Size(89, 61)
        Me.cprj.TabIndex = 85
        Me.cprj.Visible = False
        '
        'Payroll
        '
        Me.Payroll.BackColor = System.Drawing.Color.White
        Me.Payroll.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Payroll.Location = New System.Drawing.Point(488, 68)
        Me.Payroll.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Payroll.Name = "Payroll"
        Me.Payroll.Size = New System.Drawing.Size(68, 41)
        Me.Payroll.TabIndex = 89
        Me.Payroll.Visible = False
        '
        'Stock_journal_create_ctrl1
        '
        Me.Stock_journal_create_ctrl1.BackColor = System.Drawing.Color.White
        Me.Stock_journal_create_ctrl1.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.Stock_journal_create_ctrl1.ForeColor = System.Drawing.Color.Black
        Me.Stock_journal_create_ctrl1.Location = New System.Drawing.Point(165, 4)
        Me.Stock_journal_create_ctrl1.Margin = New System.Windows.Forms.Padding(4)
        Me.Stock_journal_create_ctrl1.Name = "Stock_journal_create_ctrl1"
        Me.Stock_journal_create_ctrl1.Size = New System.Drawing.Size(90, 61)
        Me.Stock_journal_create_ctrl1.TabIndex = 87
        Me.Stock_journal_create_ctrl1.Visible = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Save_TXT)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 683)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1362, 20)
        Me.Panel3.TabIndex = 2
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
        Me.Save_TXT.Location = New System.Drawing.Point(1260, 36)
        Me.Save_TXT.Msg_Object = Nothing
        Me.Save_TXT.Name = "Save_TXT"
        Me.Save_TXT.Select_Auto_Show = True
        Me.Save_TXT.Select_Column_Color = "NA"
        Me.Save_TXT.Select_Columns = 0
        Me.Save_TXT.Select_Filter = Nothing
        Me.Save_TXT.Select_Hide_Columns = "NA"
        Me.Save_TXT.Select_Object = Nothing
        Me.Save_TXT.Select_Source = Nothing
        Me.Save_TXT.Size = New System.Drawing.Size(10, 20)
        Me.Save_TXT.TabIndex = 100
        Me.Save_TXT.Type_ = "TXT"
        Me.Save_TXT.Val_max = 1000000000
        Me.Save_TXT.Val_min = 0
        '
        'Bank_Panel
        '
        Me.Bank_Panel.BackColor = System.Drawing.Color.OldLace
        Me.Bank_Panel.Controls.Add(Me.Panel2)
        Me.Bank_Panel.Controls.Add(Me.Type_TXT)
        Me.Bank_Panel.Controls.Add(Me.Panel6)
        Me.Bank_Panel.Controls.Add(Me.Label1)
        Me.Bank_Panel.Controls.Add(Me.Panel4)
        Me.Bank_Panel.Controls.Add(Me.Name_TXT)
        Me.Bank_Panel.Controls.Add(Me.Label4)
        Me.Bank_Panel.Controls.Add(Me.Label2)
        Me.Bank_Panel.Controls.Add(Me.Label48)
        Me.Bank_Panel.Controls.Add(Me.Label49)
        Me.Bank_Panel.Controls.Add(Me.Alias_TXT)
        Me.Bank_Panel.Controls.Add(Me.Label3)
        Me.Bank_Panel.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bank_Panel.Location = New System.Drawing.Point(0, 0)
        Me.Bank_Panel.Name = "Bank_Panel"
        Me.Bank_Panel.Size = New System.Drawing.Size(1362, 96)
        Me.Bank_Panel.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Silver
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(958, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1, 95)
        Me.Panel2.TabIndex = 86
        '
        'Type_TXT
        '
        Me.Type_TXT.Auto_Cleane = True
        Me.Type_TXT.Back_color = System.Drawing.Color.OldLace
        Me.Type_TXT.BackColor = System.Drawing.Color.OldLace
        Me.Type_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Type_TXT.Data_Link_ = ""
        Me.Type_TXT.Decimal_ = 2
        Me.Type_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Type_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Type_TXT.Font_Size = 11
        Me.Type_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Type_TXT.Format_ = "dd-MM-yyyy"
        Me.Type_TXT.Keydown_Support = True
        Me.Type_TXT.Location = New System.Drawing.Point(171, 67)
        Me.Type_TXT.Msg_Object = Nothing
        Me.Type_TXT.Name = "Type_TXT"
        Me.Type_TXT.Select_Auto_Show = True
        Me.Type_TXT.Select_Column_Color = "NA"
        Me.Type_TXT.Select_Columns = 0
        Me.Type_TXT.Select_Filter = "Name LIKE '%<value>%'"
        Me.Type_TXT.Select_Hide_Columns = "NA"
        Me.Type_TXT.Select_Object = Nothing
        Me.Type_TXT.Select_Source = Me.BindingSource1
        Me.Type_TXT.Size = New System.Drawing.Size(231, 19)
        Me.Type_TXT.TabIndex = 83
        Me.Type_TXT.Type_ = "Select"
        Me.Type_TXT.Val_max = 1000000000
        Me.Type_TXT.Val_min = 0
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Azure
        Me.Panel6.Controls.Add(Me.Panel27)
        Me.Panel6.Controls.Add(Me.Txt1)
        Me.Panel6.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel6.Controls.Add(Me.Label37)
        Me.Panel6.Controls.Add(Me.Label36)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel6.Location = New System.Drawing.Point(959, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(403, 95)
        Me.Panel6.TabIndex = 85
        '
        'Panel27
        '
        Me.Panel27.Controls.Add(Me.Label18)
        Me.Panel27.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel27.Location = New System.Drawing.Point(0, 0)
        Me.Panel27.Name = "Panel27"
        Me.Panel27.Size = New System.Drawing.Size(403, 15)
        Me.Panel27.TabIndex = 99
        '
        'Label18
        '
        Me.Label18.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label18.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.Label18.Location = New System.Drawing.Point(0, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(403, 15)
        Me.Label18.TabIndex = 94
        Me.Label18.Text = "Vouchers No."
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Txt1
        '
        Me.Txt1.Auto_Cleane = True
        Me.Txt1.Back_color = System.Drawing.Color.Azure
        Me.Txt1.BackColor = System.Drawing.Color.Azure
        Me.Txt1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Txt1.Data_Link_ = ""
        Me.Txt1.Decimal_ = 2
        Me.Txt1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt1.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Txt1.Font_Size = 11
        Me.Txt1.Font_Style = System.Drawing.FontStyle.Bold
        Me.Txt1.Format_ = "dd-MM-yyyy"
        Me.Txt1.Keydown_Support = True
        Me.Txt1.Location = New System.Drawing.Point(171, 21)
        Me.Txt1.Msg_Object = Nothing
        Me.Txt1.Name = "Txt1"
        Me.Txt1.ReadOnly = True
        Me.Txt1.Select_Auto_Show = True
        Me.Txt1.Select_Column_Color = "NA"
        Me.Txt1.Select_Columns = 0
        Me.Txt1.Select_Filter = " "
        Me.Txt1.Select_Hide_Columns = "NA"
        Me.Txt1.Select_Object = Nothing
        Me.Txt1.Select_Source = Me.BindingSource2
        Me.Txt1.Size = New System.Drawing.Size(221, 19)
        Me.Txt1.TabIndex = 0
        Me.Txt1.Type_ = "Select"
        Me.Txt1.Val_max = 1000000000
        Me.Txt1.Val_min = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.Controls.Add(Me.Txt2, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Suffix_TXT, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Prefix_TXT, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label7, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(9, 44)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.78049!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.21951!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(385, 40)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'Txt2
        '
        Me.Txt2.Auto_Cleane = True
        Me.Txt2.Back_color = System.Drawing.Color.Azure
        Me.Txt2.BackColor = System.Drawing.Color.Azure
        Me.Txt2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Txt2.Data_Link_ = ""
        Me.Txt2.Decimal_ = 0
        Me.Txt2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Txt2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt2.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Txt2.Font_Size = 11
        Me.Txt2.Font_Style = System.Drawing.FontStyle.Bold
        Me.Txt2.Format_ = "dd-MM-yyyy"
        Me.Txt2.Keydown_Support = True
        Me.Txt2.Location = New System.Drawing.Point(131, 22)
        Me.Txt2.Margin = New System.Windows.Forms.Padding(2)
        Me.Txt2.Msg_Object = Nothing
        Me.Txt2.Name = "Txt2"
        Me.Txt2.Select_Auto_Show = True
        Me.Txt2.Select_Column_Color = "NA"
        Me.Txt2.Select_Columns = 0
        Me.Txt2.Select_Filter = Nothing
        Me.Txt2.Select_Hide_Columns = "NA"
        Me.Txt2.Select_Object = Nothing
        Me.Txt2.Select_Source = Nothing
        Me.Txt2.Size = New System.Drawing.Size(123, 19)
        Me.Txt2.TabIndex = 1
        Me.Txt2.Text = "0"
        Me.Txt2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Txt2.Type_ = "TXT"
        Me.Txt2.Val_max = 1000000000
        Me.Txt2.Val_min = 0
        '
        'Label6
        '
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(132, 1)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(121, 18)
        Me.Label6.TabIndex = 99
        Me.Label6.Text = "Starting Number"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Suffix_TXT
        '
        Me.Suffix_TXT.Auto_Cleane = True
        Me.Suffix_TXT.Back_color = System.Drawing.Color.Azure
        Me.Suffix_TXT.BackColor = System.Drawing.Color.Azure
        Me.Suffix_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Suffix_TXT.Data_Link_ = ""
        Me.Suffix_TXT.Decimal_ = 2
        Me.Suffix_TXT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Suffix_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Suffix_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Suffix_TXT.Font_Size = 11
        Me.Suffix_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Suffix_TXT.Format_ = "dd-MM-yyyy"
        Me.Suffix_TXT.Keydown_Support = True
        Me.Suffix_TXT.Location = New System.Drawing.Point(259, 22)
        Me.Suffix_TXT.Margin = New System.Windows.Forms.Padding(2)
        Me.Suffix_TXT.Msg_Object = Nothing
        Me.Suffix_TXT.Name = "Suffix_TXT"
        Me.Suffix_TXT.Select_Auto_Show = True
        Me.Suffix_TXT.Select_Column_Color = "NA"
        Me.Suffix_TXT.Select_Columns = 0
        Me.Suffix_TXT.Select_Filter = Nothing
        Me.Suffix_TXT.Select_Hide_Columns = "NA"
        Me.Suffix_TXT.Select_Object = Nothing
        Me.Suffix_TXT.Select_Source = Nothing
        Me.Suffix_TXT.Size = New System.Drawing.Size(123, 19)
        Me.Suffix_TXT.TabIndex = 2
        Me.Suffix_TXT.Type_ = "TXT"
        Me.Suffix_TXT.Val_max = 1000000000
        Me.Suffix_TXT.Val_min = 0
        '
        'Prefix_TXT
        '
        Me.Prefix_TXT.Auto_Cleane = True
        Me.Prefix_TXT.Back_color = System.Drawing.Color.Azure
        Me.Prefix_TXT.BackColor = System.Drawing.Color.Azure
        Me.Prefix_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Prefix_TXT.Data_Link_ = ""
        Me.Prefix_TXT.Decimal_ = 2
        Me.Prefix_TXT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Prefix_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Prefix_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Prefix_TXT.Font_Size = 11
        Me.Prefix_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Prefix_TXT.Format_ = "dd-MM-yyyy"
        Me.Prefix_TXT.Keydown_Support = True
        Me.Prefix_TXT.Location = New System.Drawing.Point(3, 22)
        Me.Prefix_TXT.Margin = New System.Windows.Forms.Padding(2)
        Me.Prefix_TXT.Msg_Object = Nothing
        Me.Prefix_TXT.Name = "Prefix_TXT"
        Me.Prefix_TXT.Select_Auto_Show = True
        Me.Prefix_TXT.Select_Column_Color = "NA"
        Me.Prefix_TXT.Select_Columns = 0
        Me.Prefix_TXT.Select_Filter = Nothing
        Me.Prefix_TXT.Select_Hide_Columns = "NA"
        Me.Prefix_TXT.Select_Object = Nothing
        Me.Prefix_TXT.Select_Source = Nothing
        Me.Prefix_TXT.Size = New System.Drawing.Size(123, 19)
        Me.Prefix_TXT.TabIndex = 0
        Me.Prefix_TXT.Type_ = "TXT"
        Me.Prefix_TXT.Val_max = 1000000000
        Me.Prefix_TXT.Val_min = 0
        '
        'Label7
        '
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(260, 1)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(121, 18)
        Me.Label7.TabIndex = 98
        Me.Label7.Text = "Suffix Details"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(4, 1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(121, 18)
        Me.Label5.TabIndex = 96
        Me.Label5.Text = "Prefix Details"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(12, 21)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(144, 19)
        Me.Label37.TabIndex = 41
        Me.Label37.Text = "Method of voucher"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(153, 21)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(15, 19)
        Me.Label36.TabIndex = 43
        Me.Label36.Text = ":"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 19)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Name"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Silver
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 95)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1362, 1)
        Me.Panel4.TabIndex = 82
        '
        'Name_TXT
        '
        Me.Name_TXT.Auto_Cleane = True
        Me.Name_TXT.Back_color = System.Drawing.Color.OldLace
        Me.Name_TXT.BackColor = System.Drawing.Color.OldLace
        Me.Name_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Name_TXT.Data_Link_ = ""
        Me.Name_TXT.Decimal_ = 2
        Me.Name_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Name_TXT.Font_Size = 11
        Me.Name_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Name_TXT.Format_ = "dd-MM-yyyy"
        Me.Name_TXT.Keydown_Support = True
        Me.Name_TXT.Location = New System.Drawing.Point(89, 8)
        Me.Name_TXT.Msg_Object = Nothing
        Me.Name_TXT.Name = "Name_TXT"
        Me.Name_TXT.Select_Auto_Show = True
        Me.Name_TXT.Select_Column_Color = "NA"
        Me.Name_TXT.Select_Columns = 0
        Me.Name_TXT.Select_Filter = Nothing
        Me.Name_TXT.Select_Hide_Columns = "NA"
        Me.Name_TXT.Select_Object = Nothing
        Me.Name_TXT.Select_Source = Nothing
        Me.Name_TXT.Size = New System.Drawing.Size(255, 19)
        Me.Name_TXT.TabIndex = 0
        Me.Name_TXT.Type_ = "TXT"
        Me.Name_TXT.Val_max = 1000000000
        Me.Name_TXT.Val_min = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(154, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(15, 19)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = ":"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(76, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(15, 19)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = ":"
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Location = New System.Drawing.Point(76, 26)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(15, 19)
        Me.Label48.TabIndex = 71
        Me.Label48.Text = ":"
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.Location = New System.Drawing.Point(10, 26)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(64, 23)
        Me.Label49.TabIndex = 69
        Me.Label49.Text = "(alias)"
        '
        'Alias_TXT
        '
        Me.Alias_TXT.Auto_Cleane = True
        Me.Alias_TXT.Back_color = System.Drawing.Color.OldLace
        Me.Alias_TXT.BackColor = System.Drawing.Color.OldLace
        Me.Alias_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Alias_TXT.Data_Link_ = ""
        Me.Alias_TXT.Decimal_ = 2
        Me.Alias_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Alias_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Alias_TXT.Font_Size = 11
        Me.Alias_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Alias_TXT.Format_ = "dd-MM-yyyy"
        Me.Alias_TXT.Keydown_Support = True
        Me.Alias_TXT.Location = New System.Drawing.Point(89, 26)
        Me.Alias_TXT.Msg_Object = Nothing
        Me.Alias_TXT.Name = "Alias_TXT"
        Me.Alias_TXT.Select_Auto_Show = True
        Me.Alias_TXT.Select_Column_Color = "NA"
        Me.Alias_TXT.Select_Columns = 0
        Me.Alias_TXT.Select_Filter = Nothing
        Me.Alias_TXT.Select_Hide_Columns = "NA"
        Me.Alias_TXT.Select_Object = Nothing
        Me.Alias_TXT.Select_Source = Nothing
        Me.Alias_TXT.Size = New System.Drawing.Size(158, 19)
        Me.Alias_TXT.TabIndex = 1
        Me.Alias_TXT.Type_ = "TXT"
        Me.Alias_TXT.Val_max = 1000000000
        Me.Alias_TXT.Val_min = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(126, 19)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Type of voucher"
        '
        'Voucher_Md_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AntiqueWhite
        Me.ClientSize = New System.Drawing.Size(1364, 705)
        Me.Controls.Add(bg_Panel)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Voucher_Md_frm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        bg_Panel.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Bank_Panel.ResumeLayout(False)
        Me.Bank_Panel.PerformLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel27.ResumeLayout(False)
        CType(Me.BindingSource2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bank_Panel As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Name_TXT As Tools.TXT
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label48 As Label
    Friend WithEvents Label49 As Label
    Friend WithEvents Alias_TXT As Tools.TXT
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Label7 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label37 As Label
    Friend WithEvents Label36 As Label
    Friend WithEvents Suffix_TXT As Tools.TXT
    Friend WithEvents Prefix_TXT As Tools.TXT
    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents Type_TXT As Tools.TXT
    Friend WithEvents cprj As prcj_voucher_create_ctrl
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Txt1 As Tools.TXT
    Friend WithEvents BindingSource2 As BindingSource
    Friend WithEvents Sp_voucher_create_ctrl1 As sp_voucher_create_ctrl
    Friend WithEvents Stock_journal_create_ctrl1 As stock_journal_create_ctrl
    Friend WithEvents Panel27 As Panel
    Friend WithEvents Label18 As Label
    Friend WithEvents Save_TXT As Tools.TXT
    Friend WithEvents Payroll As payroll_voucher_create_ctrl
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents Txt2 As Tools.TXT
End Class
