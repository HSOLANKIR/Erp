<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class stock_journal_create_ctrl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.manufacturing_yn = New Tools.YN()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel20 = New System.Windows.Forms.Panel()
        Me.duplicate_YN = New Tools.YN()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.narration_YN = New Tools.YN()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.zero_YN = New Tools.YN()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel27 = New System.Windows.Forms.Panel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.Panel19 = New System.Windows.Forms.Panel()
        Me.print_format_txt = New Tools.TXT()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Panel18 = New System.Windows.Forms.Panel()
        Me.print_path_txt = New Tools.TXT()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel17 = New System.Windows.Forms.Panel()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.FlowLayoutPanel3 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.print_stamp_YN = New Tools.YN()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.print_signature_YN = New Tools.YN()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.print_narration_YN = New Tools.YN()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.direct_print_YN = New Tools.YN()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.Panel20.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel27.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel14.SuspendLayout()
        Me.Panel19.SuspendLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel18.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel4, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(655, 425)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BackColor = System.Drawing.Color.Beige
        Me.Panel1.Controls.Add(Me.Panel8)
        Me.Panel1.Controls.Add(Me.Panel27)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(1, 1)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(326, 423)
        Me.Panel1.TabIndex = 0
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.Panel12)
        Me.Panel8.Controls.Add(Me.Panel20)
        Me.Panel8.Controls.Add(Me.Panel3)
        Me.Panel8.Controls.Add(Me.Panel2)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel8.Location = New System.Drawing.Point(0, 15)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(326, 116)
        Me.Panel8.TabIndex = 87
        '
        'Panel12
        '
        Me.Panel12.AutoSize = True
        Me.Panel12.Controls.Add(Me.manufacturing_yn)
        Me.Panel12.Controls.Add(Me.Label5)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel12.Location = New System.Drawing.Point(0, 66)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(326, 22)
        Me.Panel12.TabIndex = 98
        '
        'manufacturing_yn
        '
        Me.manufacturing_yn.Back_color = System.Drawing.Color.Beige
        Me.manufacturing_yn.BackColor = System.Drawing.Color.Beige
        Me.manufacturing_yn.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.manufacturing_yn.Data_Link_ = ""
        Me.manufacturing_yn.Defolt_ = "No"
        Me.manufacturing_yn.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.manufacturing_yn.Location = New System.Drawing.Point(278, 4)
        Me.manufacturing_yn.Name = "manufacturing_yn"
        Me.manufacturing_yn.ReadOnly = True
        Me.manufacturing_yn.Size = New System.Drawing.Size(42, 15)
        Me.manufacturing_yn.TabIndex = 103
        Me.manufacturing_yn.Text = "No"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(18, 5)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(145, 16)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Use as a Manufacturing"
        '
        'Panel20
        '
        Me.Panel20.AutoSize = True
        Me.Panel20.Controls.Add(Me.duplicate_YN)
        Me.Panel20.Controls.Add(Me.Label15)
        Me.Panel20.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel20.Location = New System.Drawing.Point(0, 44)
        Me.Panel20.Name = "Panel20"
        Me.Panel20.Size = New System.Drawing.Size(326, 22)
        Me.Panel20.TabIndex = 97
        '
        'duplicate_YN
        '
        Me.duplicate_YN.Back_color = System.Drawing.Color.Beige
        Me.duplicate_YN.BackColor = System.Drawing.Color.Beige
        Me.duplicate_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.duplicate_YN.Data_Link_ = ""
        Me.duplicate_YN.Defolt_ = "No"
        Me.duplicate_YN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.duplicate_YN.Location = New System.Drawing.Point(278, 4)
        Me.duplicate_YN.Name = "duplicate_YN"
        Me.duplicate_YN.ReadOnly = True
        Me.duplicate_YN.Size = New System.Drawing.Size(42, 15)
        Me.duplicate_YN.TabIndex = 103
        Me.duplicate_YN.Text = "No"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(18, 5)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(159, 16)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "allow duplicate voucher no"
        '
        'Panel3
        '
        Me.Panel3.AutoSize = True
        Me.Panel3.Controls.Add(Me.narration_YN)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 22)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(326, 22)
        Me.Panel3.TabIndex = 96
        '
        'narration_YN
        '
        Me.narration_YN.Back_color = System.Drawing.Color.Beige
        Me.narration_YN.BackColor = System.Drawing.Color.Beige
        Me.narration_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.narration_YN.Data_Link_ = ""
        Me.narration_YN.Defolt_ = "No"
        Me.narration_YN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.narration_YN.Location = New System.Drawing.Point(278, 4)
        Me.narration_YN.Name = "narration_YN"
        Me.narration_YN.ReadOnly = True
        Me.narration_YN.Size = New System.Drawing.Size(42, 15)
        Me.narration_YN.TabIndex = 103
        Me.narration_YN.Text = "Yes"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(18, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(153, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "allow narration in voucher"
        '
        'Panel2
        '
        Me.Panel2.AutoSize = True
        Me.Panel2.Controls.Add(Me.zero_YN)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(326, 22)
        Me.Panel2.TabIndex = 95
        '
        'zero_YN
        '
        Me.zero_YN.Back_color = System.Drawing.Color.Beige
        Me.zero_YN.BackColor = System.Drawing.Color.Beige
        Me.zero_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.zero_YN.Data_Link_ = ""
        Me.zero_YN.Defolt_ = "No"
        Me.zero_YN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.zero_YN.Location = New System.Drawing.Point(278, 4)
        Me.zero_YN.Name = "zero_YN"
        Me.zero_YN.ReadOnly = True
        Me.zero_YN.Size = New System.Drawing.Size(42, 15)
        Me.zero_YN.TabIndex = 103
        Me.zero_YN.Text = "No"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(181, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "allow zero-valued transactions"
        '
        'Panel27
        '
        Me.Panel27.Controls.Add(Me.Label14)
        Me.Panel27.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel27.Location = New System.Drawing.Point(0, 0)
        Me.Panel27.Name = "Panel27"
        Me.Panel27.Size = New System.Drawing.Size(326, 15)
        Me.Panel27.TabIndex = 108
        '
        'Label14
        '
        Me.Label14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.Label14.Location = New System.Drawing.Point(0, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(326, 15)
        Me.Label14.TabIndex = 94
        Me.Label14.Text = "Vouchers details"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel4
        '
        Me.Panel4.AutoScroll = True
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.Panel4.Controls.Add(Me.Panel5)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(328, 1)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(326, 423)
        Me.Panel4.TabIndex = 1
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Panel14)
        Me.Panel5.Controls.Add(Me.FlowLayoutPanel3)
        Me.Panel5.Controls.Add(Me.Panel11)
        Me.Panel5.Controls.Add(Me.Panel10)
        Me.Panel5.Controls.Add(Me.Panel9)
        Me.Panel5.Controls.Add(Me.FlowLayoutPanel1)
        Me.Panel5.Controls.Add(Me.Panel7)
        Me.Panel5.Controls.Add(Me.Panel6)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(326, 360)
        Me.Panel5.TabIndex = 87
        '
        'Panel14
        '
        Me.Panel14.AutoSize = True
        Me.Panel14.Controls.Add(Me.Panel19)
        Me.Panel14.Controls.Add(Me.Panel18)
        Me.Panel14.Controls.Add(Me.Panel17)
        Me.Panel14.Controls.Add(Me.Panel16)
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel14.Location = New System.Drawing.Point(0, 105)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(326, 45)
        Me.Panel14.TabIndex = 105
        '
        'Panel19
        '
        Me.Panel19.AutoSize = True
        Me.Panel19.Controls.Add(Me.print_format_txt)
        Me.Panel19.Controls.Add(Me.Label13)
        Me.Panel19.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel19.Location = New System.Drawing.Point(0, 23)
        Me.Panel19.Name = "Panel19"
        Me.Panel19.Size = New System.Drawing.Size(326, 21)
        Me.Panel19.TabIndex = 109
        Me.Panel19.Visible = False
        '
        'print_format_txt
        '
        Me.print_format_txt.Auto_Cleane = True
        Me.print_format_txt.Back_color = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.print_format_txt.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.print_format_txt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.print_format_txt.Data_Link_ = ""
        Me.print_format_txt.Decimal_ = 2
        Me.print_format_txt.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.print_format_txt.Font_Size = 11
        Me.print_format_txt.Format_ = "dd-MM-yyyy"
        Me.print_format_txt.Keydown_Support = True
        Me.print_format_txt.Location = New System.Drawing.Point(140, 3)
        Me.print_format_txt.Name = "print_format_txt"
        Me.print_format_txt.Select_Auto_Show = True
        Me.print_format_txt.Select_Column_Color = "NA"
        Me.print_format_txt.Select_Columns = 0
        Me.print_format_txt.Select_Filter = " "
        Me.print_format_txt.Select_Hide_Columns = "NA"
        Me.print_format_txt.Select_Object = Nothing
        Me.print_format_txt.Select_Source = Me.BindingSource1
        Me.print_format_txt.Size = New System.Drawing.Size(180, 15)
        Me.print_format_txt.TabIndex = 89
        Me.print_format_txt.Type_ = "Select"
        Me.print_format_txt.Val_max = 1000000000
        Me.print_format_txt.Val_min = 0
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(31, 4)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(88, 16)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "default format"
        '
        'Panel18
        '
        Me.Panel18.AutoSize = True
        Me.Panel18.Controls.Add(Me.print_path_txt)
        Me.Panel18.Controls.Add(Me.Label12)
        Me.Panel18.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel18.Location = New System.Drawing.Point(0, 1)
        Me.Panel18.Name = "Panel18"
        Me.Panel18.Size = New System.Drawing.Size(326, 22)
        Me.Panel18.TabIndex = 108
        '
        'print_path_txt
        '
        Me.print_path_txt.Auto_Cleane = True
        Me.print_path_txt.Back_color = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.print_path_txt.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.print_path_txt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.print_path_txt.Data_Link_ = ""
        Me.print_path_txt.Decimal_ = 2
        Me.print_path_txt.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.print_path_txt.Font_Size = 11
        Me.print_path_txt.Format_ = "dd-MM-yyyy"
        Me.print_path_txt.Keydown_Support = True
        Me.print_path_txt.Location = New System.Drawing.Point(102, 4)
        Me.print_path_txt.Name = "print_path_txt"
        Me.print_path_txt.Select_Auto_Show = True
        Me.print_path_txt.Select_Column_Color = "NA"
        Me.print_path_txt.Select_Columns = 0
        Me.print_path_txt.Select_Filter = Nothing
        Me.print_path_txt.Select_Hide_Columns = "NA"
        Me.print_path_txt.Select_Object = Nothing
        Me.print_path_txt.Select_Source = Nothing
        Me.print_path_txt.Size = New System.Drawing.Size(218, 15)
        Me.print_path_txt.TabIndex = 89
        Me.print_path_txt.Type_ = "TXT"
        Me.print_path_txt.Val_max = 1000000000
        Me.print_path_txt.Val_min = 0
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(18, 5)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(64, 16)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Print path"
        '
        'Panel17
        '
        Me.Panel17.BackColor = System.Drawing.Color.DimGray
        Me.Panel17.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel17.Location = New System.Drawing.Point(0, 44)
        Me.Panel17.Name = "Panel17"
        Me.Panel17.Size = New System.Drawing.Size(326, 1)
        Me.Panel17.TabIndex = 107
        '
        'Panel16
        '
        Me.Panel16.BackColor = System.Drawing.Color.DimGray
        Me.Panel16.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel16.Location = New System.Drawing.Point(0, 0)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(326, 1)
        Me.Panel16.TabIndex = 106
        '
        'FlowLayoutPanel3
        '
        Me.FlowLayoutPanel3.BackColor = System.Drawing.Color.DarkGray
        Me.FlowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.FlowLayoutPanel3.Location = New System.Drawing.Point(0, 104)
        Me.FlowLayoutPanel3.Name = "FlowLayoutPanel3"
        Me.FlowLayoutPanel3.Size = New System.Drawing.Size(326, 1)
        Me.FlowLayoutPanel3.TabIndex = 102
        '
        'Panel11
        '
        Me.Panel11.AutoSize = True
        Me.Panel11.Controls.Add(Me.print_stamp_YN)
        Me.Panel11.Controls.Add(Me.Label8)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel11.Location = New System.Drawing.Point(0, 82)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(326, 22)
        Me.Panel11.TabIndex = 99
        '
        'print_stamp_YN
        '
        Me.print_stamp_YN.Back_color = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.print_stamp_YN.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.print_stamp_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.print_stamp_YN.Data_Link_ = ""
        Me.print_stamp_YN.Defolt_ = "No"
        Me.print_stamp_YN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.print_stamp_YN.Location = New System.Drawing.Point(278, 4)
        Me.print_stamp_YN.Name = "print_stamp_YN"
        Me.print_stamp_YN.ReadOnly = True
        Me.print_stamp_YN.Size = New System.Drawing.Size(42, 15)
        Me.print_stamp_YN.TabIndex = 103
        Me.print_stamp_YN.Text = "No"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(18, 5)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(132, 16)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Print company stamp"
        '
        'Panel10
        '
        Me.Panel10.AutoSize = True
        Me.Panel10.Controls.Add(Me.print_signature_YN)
        Me.Panel10.Controls.Add(Me.Label7)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel10.Location = New System.Drawing.Point(0, 60)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(326, 22)
        Me.Panel10.TabIndex = 98
        '
        'print_signature_YN
        '
        Me.print_signature_YN.Back_color = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.print_signature_YN.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.print_signature_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.print_signature_YN.Data_Link_ = ""
        Me.print_signature_YN.Defolt_ = "No"
        Me.print_signature_YN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.print_signature_YN.Location = New System.Drawing.Point(278, 4)
        Me.print_signature_YN.Name = "print_signature_YN"
        Me.print_signature_YN.ReadOnly = True
        Me.print_signature_YN.Size = New System.Drawing.Size(42, 15)
        Me.print_signature_YN.TabIndex = 103
        Me.print_signature_YN.Text = "No"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(18, 5)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(92, 16)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Print signature"
        '
        'Panel9
        '
        Me.Panel9.AutoSize = True
        Me.Panel9.Controls.Add(Me.print_narration_YN)
        Me.Panel9.Controls.Add(Me.Label6)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel9.Location = New System.Drawing.Point(0, 38)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(326, 22)
        Me.Panel9.TabIndex = 97
        '
        'print_narration_YN
        '
        Me.print_narration_YN.Back_color = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.print_narration_YN.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.print_narration_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.print_narration_YN.Data_Link_ = ""
        Me.print_narration_YN.Defolt_ = "No"
        Me.print_narration_YN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.print_narration_YN.Location = New System.Drawing.Point(278, 4)
        Me.print_narration_YN.Name = "print_narration_YN"
        Me.print_narration_YN.ReadOnly = True
        Me.print_narration_YN.Size = New System.Drawing.Size(42, 15)
        Me.print_narration_YN.TabIndex = 103
        Me.print_narration_YN.Text = "No"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(18, 5)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(91, 16)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Print Narration"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.DarkGray
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 37)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(326, 1)
        Me.FlowLayoutPanel1.TabIndex = 89
        '
        'Panel7
        '
        Me.Panel7.AutoSize = True
        Me.Panel7.Controls.Add(Me.direct_print_YN)
        Me.Panel7.Controls.Add(Me.Label4)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(0, 15)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(326, 22)
        Me.Panel7.TabIndex = 95
        '
        'direct_print_YN
        '
        Me.direct_print_YN.Back_color = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.direct_print_YN.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.direct_print_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.direct_print_YN.Data_Link_ = ""
        Me.direct_print_YN.Defolt_ = "No"
        Me.direct_print_YN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.direct_print_YN.Location = New System.Drawing.Point(278, 4)
        Me.direct_print_YN.Name = "direct_print_YN"
        Me.direct_print_YN.ReadOnly = True
        Me.direct_print_YN.Size = New System.Drawing.Size(42, 15)
        Me.direct_print_YN.TabIndex = 103
        Me.direct_print_YN.Text = "No"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(18, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(152, 16)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Print voucher after saving"
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.Label3)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(326, 15)
        Me.Panel6.TabIndex = 108
        '
        'Label3
        '
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(326, 15)
        Me.Label3.TabIndex = 94
        Me.Label3.Text = "Printing details"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'stock_journal_create_ctrl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "stock_journal_create_ctrl"
        Me.Size = New System.Drawing.Size(1100, 425)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.Panel12.ResumeLayout(False)
        Me.Panel12.PerformLayout()
        Me.Panel20.ResumeLayout(False)
        Me.Panel20.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel27.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel14.ResumeLayout(False)
        Me.Panel14.PerformLayout()
        Me.Panel19.ResumeLayout(False)
        Me.Panel19.PerformLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel18.ResumeLayout(False)
        Me.Panel18.PerformLayout()
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Panel20 As Panel
    Friend WithEvents duplicate_YN As Tools.YN
    Friend WithEvents Label15 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents narration_YN As Tools.YN
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents zero_YN As Tools.YN
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel14 As Panel
    Friend WithEvents Panel19 As Panel
    Friend WithEvents print_format_txt As Tools.TXT
    Friend WithEvents Label13 As Label
    Friend WithEvents Panel18 As Panel
    Friend WithEvents print_path_txt As Tools.TXT
    Friend WithEvents Label12 As Label
    Friend WithEvents Panel17 As Panel
    Friend WithEvents Panel16 As Panel
    Friend WithEvents FlowLayoutPanel3 As FlowLayoutPanel
    Friend WithEvents Panel11 As Panel
    Friend WithEvents print_stamp_YN As Tools.YN
    Friend WithEvents Label8 As Label
    Friend WithEvents Panel10 As Panel
    Friend WithEvents print_signature_YN As Tools.YN
    Friend WithEvents Label7 As Label
    Friend WithEvents Panel9 As Panel
    Friend WithEvents print_narration_YN As Tools.YN
    Friend WithEvents Label6 As Label
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents direct_print_YN As Tools.YN
    Friend WithEvents Label4 As Label
    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents Panel27 As Panel
    Friend WithEvents Label14 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel12 As Panel
    Friend WithEvents manufacturing_yn As Tools.YN
    Friend WithEvents Label5 As Label
End Class
