<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Report_Ledger_frm
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.BG_Panel = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Grid1 = New System.Windows.Forms.DataGridView()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Acc_LB = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Frm_Date_LB = New System.Windows.Forms.Label()
        Me.To_Date_LB = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Godown_Panel = New System.Windows.Forms.Panel()
        Me.SortBy_LB = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Branch_Panel = New System.Windows.Forms.Panel()
        Me.Branch_Name_LB = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Panel15 = New System.Windows.Forms.Panel()
        Me.Voucher_Type_Panel = New System.Windows.Forms.Panel()
        Me.Voucher_Type_LB = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Panel24 = New System.Windows.Forms.Panel()
        Me.Panel25 = New System.Windows.Forms.Panel()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Load_Panel = New System.Windows.Forms.Panel()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.BackgroundWorker2 = New System.ComponentModel.BackgroundWorker()
        Me.Source_ = New System.Windows.Forms.BindingSource(Me.components)
        Me.BG_Panel.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.Grid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel8.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.Godown_Panel.SuspendLayout()
        Me.Branch_Panel.SuspendLayout()
        Me.Voucher_Type_Panel.SuspendLayout()
        Me.Load_Panel.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Source_, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BG_Panel
        '
        Me.BG_Panel.Controls.Add(Me.Panel1)
        Me.BG_Panel.Controls.Add(Me.Panel8)
        Me.BG_Panel.Controls.Add(Me.Panel7)
        Me.BG_Panel.Controls.Add(Me.Panel2)
        Me.BG_Panel.Controls.Add(Me.Panel9)
        Me.BG_Panel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BG_Panel.Location = New System.Drawing.Point(0, 0)
        Me.BG_Panel.Name = "BG_Panel"
        Me.BG_Panel.Size = New System.Drawing.Size(1364, 705)
        Me.BG_Panel.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Grid1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 39)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1364, 631)
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
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grid1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grid1.ColumnHeadersHeight = 20
        Me.Grid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(48, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grid1.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid1.EnableHeadersVisualStyles = False
        Me.Grid1.GridColor = System.Drawing.Color.Silver
        Me.Grid1.Location = New System.Drawing.Point(0, 0)
        Me.Grid1.Margin = New System.Windows.Forms.Padding(0)
        Me.Grid1.Name = "Grid1"
        Me.Grid1.ReadOnly = True
        Me.Grid1.RowHeadersVisible = False
        Me.Grid1.RowTemplate.Height = 17
        Me.Grid1.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Grid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid1.Size = New System.Drawing.Size(1364, 631)
        Me.Grid1.TabIndex = 3
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.White
        Me.Panel8.Controls.Add(Me.Label6)
        Me.Panel8.Controls.Add(Me.Label3)
        Me.Panel8.Controls.Add(Me.Label7)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel8.Location = New System.Drawing.Point(0, 21)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(1364, 18)
        Me.Panel8.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(1116, 0)
        Me.Label6.Margin = New System.Windows.Forms.Padding(0)
        Me.Label6.Name = "Label6"
        Me.Label6.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Label6.Size = New System.Drawing.Size(124, 18)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "0.00"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Label3.Size = New System.Drawing.Size(323, 18)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Opning Balance"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(1240, 0)
        Me.Label7.Margin = New System.Windows.Forms.Padding(0)
        Me.Label7.Name = "Label7"
        Me.Label7.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Label7.Size = New System.Drawing.Size(124, 18)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "0.00"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.SaddleBrown
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(0, 20)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(1364, 1)
        Me.Panel7.TabIndex = 3
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.OldLace
        Me.Panel2.Controls.Add(Me.Acc_LB)
        Me.Panel2.Controls.Add(Me.Panel6)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1364, 20)
        Me.Panel2.TabIndex = 1
        '
        'Acc_LB
        '
        Me.Acc_LB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Acc_LB.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Acc_LB.Location = New System.Drawing.Point(66, 0)
        Me.Acc_LB.Name = "Acc_LB"
        Me.Acc_LB.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Acc_LB.Size = New System.Drawing.Size(1078, 20)
        Me.Acc_LB.TabIndex = 1
        Me.Acc_LB.Text = "Cash"
        Me.Acc_LB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.Label13)
        Me.Panel6.Controls.Add(Me.Frm_Date_LB)
        Me.Panel6.Controls.Add(Me.To_Date_LB)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel6.Location = New System.Drawing.Point(1144, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(220, 20)
        Me.Panel6.TabIndex = 5
        '
        'Label13
        '
        Me.Label13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(82, 0)
        Me.Label13.Margin = New System.Windows.Forms.Padding(0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(56, 20)
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
        Me.Frm_Date_LB.Size = New System.Drawing.Size(82, 20)
        Me.Frm_Date_LB.TabIndex = 3
        Me.Frm_Date_LB.Text = "10-01-2022"
        Me.Frm_Date_LB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'To_Date_LB
        '
        Me.To_Date_LB.Dock = System.Windows.Forms.DockStyle.Right
        Me.To_Date_LB.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.To_Date_LB.ForeColor = System.Drawing.Color.SaddleBrown
        Me.To_Date_LB.Location = New System.Drawing.Point(138, 0)
        Me.To_Date_LB.Margin = New System.Windows.Forms.Padding(0)
        Me.To_Date_LB.Name = "To_Date_LB"
        Me.To_Date_LB.Size = New System.Drawing.Size(82, 20)
        Me.To_Date_LB.TabIndex = 2
        Me.To_Date_LB.Text = "10-01-2022"
        Me.To_Date_LB.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Label1.Size = New System.Drawing.Size(66, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ledger :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.OldLace
        Me.Panel9.Controls.Add(Me.TableLayoutPanel5)
        Me.Panel9.Controls.Add(Me.Godown_Panel)
        Me.Panel9.Controls.Add(Me.Label10)
        Me.Panel9.Controls.Add(Me.Branch_Panel)
        Me.Panel9.Controls.Add(Me.Voucher_Type_Panel)
        Me.Panel9.Controls.Add(Me.Panel25)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel9.Location = New System.Drawing.Point(0, 670)
        Me.Panel9.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(1364, 35)
        Me.Panel9.TabIndex = 7
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 1
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.Label5, 0, 0)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Right
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(1066, 1)
        Me.TableLayoutPanel5.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 1
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(158, 34)
        Me.TableLayoutPanel5.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Label5.Size = New System.Drawing.Size(152, 34)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Closing Balance :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Godown_Panel
        '
        Me.Godown_Panel.Controls.Add(Me.SortBy_LB)
        Me.Godown_Panel.Controls.Add(Me.Label8)
        Me.Godown_Panel.Controls.Add(Me.Panel14)
        Me.Godown_Panel.Dock = System.Windows.Forms.DockStyle.Left
        Me.Godown_Panel.Location = New System.Drawing.Point(373, 1)
        Me.Godown_Panel.Name = "Godown_Panel"
        Me.Godown_Panel.Size = New System.Drawing.Size(203, 34)
        Me.Godown_Panel.TabIndex = 8
        '
        'SortBy_LB
        '
        Me.SortBy_LB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SortBy_LB.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SortBy_LB.Location = New System.Drawing.Point(0, 15)
        Me.SortBy_LB.Margin = New System.Windows.Forms.Padding(0)
        Me.SortBy_LB.Name = "SortBy_LB"
        Me.SortBy_LB.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.SortBy_LB.Size = New System.Drawing.Size(202, 19)
        Me.SortBy_LB.TabIndex = 7
        Me.SortBy_LB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(0, 0)
        Me.Label8.Margin = New System.Windows.Forms.Padding(0)
        Me.Label8.Name = "Label8"
        Me.Label8.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Label8.Size = New System.Drawing.Size(202, 15)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Sort By"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel14
        '
        Me.Panel14.BackColor = System.Drawing.Color.DimGray
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel14.Location = New System.Drawing.Point(202, 0)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(1, 34)
        Me.Panel14.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label10.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(1224, 1)
        Me.Label10.Margin = New System.Windows.Forms.Padding(0)
        Me.Label10.Name = "Label10"
        Me.Label10.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Label10.Size = New System.Drawing.Size(140, 34)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "0.00"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Branch_Panel
        '
        Me.Branch_Panel.Controls.Add(Me.Branch_Name_LB)
        Me.Branch_Panel.Controls.Add(Me.Label18)
        Me.Branch_Panel.Controls.Add(Me.Panel15)
        Me.Branch_Panel.Dock = System.Windows.Forms.DockStyle.Left
        Me.Branch_Panel.Location = New System.Drawing.Point(170, 1)
        Me.Branch_Panel.Name = "Branch_Panel"
        Me.Branch_Panel.Size = New System.Drawing.Size(203, 34)
        Me.Branch_Panel.TabIndex = 1
        Me.Branch_Panel.Visible = False
        '
        'Branch_Name_LB
        '
        Me.Branch_Name_LB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Branch_Name_LB.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Branch_Name_LB.Location = New System.Drawing.Point(0, 15)
        Me.Branch_Name_LB.Margin = New System.Windows.Forms.Padding(0)
        Me.Branch_Name_LB.Name = "Branch_Name_LB"
        Me.Branch_Name_LB.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Branch_Name_LB.Size = New System.Drawing.Size(202, 19)
        Me.Branch_Name_LB.TabIndex = 7
        Me.Branch_Name_LB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label18
        '
        Me.Label18.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label18.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(0, 0)
        Me.Label18.Margin = New System.Windows.Forms.Padding(0)
        Me.Label18.Name = "Label18"
        Me.Label18.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Label18.Size = New System.Drawing.Size(202, 15)
        Me.Label18.TabIndex = 5
        Me.Label18.Text = "Branch"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel15
        '
        Me.Panel15.BackColor = System.Drawing.Color.DimGray
        Me.Panel15.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel15.Location = New System.Drawing.Point(202, 0)
        Me.Panel15.Name = "Panel15"
        Me.Panel15.Size = New System.Drawing.Size(1, 34)
        Me.Panel15.TabIndex = 6
        '
        'Voucher_Type_Panel
        '
        Me.Voucher_Type_Panel.Controls.Add(Me.Voucher_Type_LB)
        Me.Voucher_Type_Panel.Controls.Add(Me.Label20)
        Me.Voucher_Type_Panel.Controls.Add(Me.Panel24)
        Me.Voucher_Type_Panel.Dock = System.Windows.Forms.DockStyle.Left
        Me.Voucher_Type_Panel.Location = New System.Drawing.Point(0, 1)
        Me.Voucher_Type_Panel.Name = "Voucher_Type_Panel"
        Me.Voucher_Type_Panel.Size = New System.Drawing.Size(170, 34)
        Me.Voucher_Type_Panel.TabIndex = 0
        '
        'Voucher_Type_LB
        '
        Me.Voucher_Type_LB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Voucher_Type_LB.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Voucher_Type_LB.Location = New System.Drawing.Point(0, 15)
        Me.Voucher_Type_LB.Margin = New System.Windows.Forms.Padding(0)
        Me.Voucher_Type_LB.Name = "Voucher_Type_LB"
        Me.Voucher_Type_LB.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Voucher_Type_LB.Size = New System.Drawing.Size(169, 19)
        Me.Voucher_Type_LB.TabIndex = 7
        Me.Voucher_Type_LB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label20
        '
        Me.Label20.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label20.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(0, 0)
        Me.Label20.Margin = New System.Windows.Forms.Padding(0)
        Me.Label20.Name = "Label20"
        Me.Label20.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Label20.Size = New System.Drawing.Size(169, 15)
        Me.Label20.TabIndex = 5
        Me.Label20.Text = "Voucher Type"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel24
        '
        Me.Panel24.BackColor = System.Drawing.Color.DimGray
        Me.Panel24.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel24.Location = New System.Drawing.Point(169, 0)
        Me.Panel24.Name = "Panel24"
        Me.Panel24.Size = New System.Drawing.Size(1, 34)
        Me.Panel24.TabIndex = 6
        '
        'Panel25
        '
        Me.Panel25.BackColor = System.Drawing.Color.DimGray
        Me.Panel25.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel25.Location = New System.Drawing.Point(0, 0)
        Me.Panel25.Name = "Panel25"
        Me.Panel25.Size = New System.Drawing.Size(1364, 1)
        Me.Panel25.TabIndex = 7
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        '
        'Load_Panel
        '
        Me.Load_Panel.Controls.Add(Me.PictureBox4)
        Me.Load_Panel.Controls.Add(Me.Label54)
        Me.Load_Panel.Location = New System.Drawing.Point(540, 262)
        Me.Load_Panel.Name = "Load_Panel"
        Me.Load_Panel.Size = New System.Drawing.Size(325, 202)
        Me.Load_Panel.TabIndex = 66
        '
        'PictureBox4
        '
        Me.PictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox4.Image = Global.Management.My.Resources.Resources.Gare_Refresh_gif
        Me.PictureBox4.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(325, 161)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox4.TabIndex = 0
        Me.PictureBox4.TabStop = False
        '
        'Label54
        '
        Me.Label54.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label54.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label54.Location = New System.Drawing.Point(0, 161)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(325, 41)
        Me.Label54.TabIndex = 1
        Me.Label54.Text = "Please wait," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Load Transaction Data"
        Me.Label54.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BackgroundWorker2
        '
        Me.BackgroundWorker2.WorkerReportsProgress = True
        Me.BackgroundWorker2.WorkerSupportsCancellation = True
        '
        'Report_Ledger_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1364, 705)
        Me.Controls.Add(Me.BG_Panel)
        Me.Controls.Add(Me.Load_Panel)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Report_Ledger_frm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Report_Ledger_frm"
        Me.BG_Panel.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.Grid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel8.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel9.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.Godown_Panel.ResumeLayout(False)
        Me.Branch_Panel.ResumeLayout(False)
        Me.Voucher_Type_Panel.ResumeLayout(False)
        Me.Load_Panel.ResumeLayout(False)
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Source_, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BG_Panel As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Acc_LB As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents To_Date_LB As Label
    Friend WithEvents Grid1 As DataGridView
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label13 As Label
    Friend WithEvents Frm_Date_LB As Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Load_Panel As Panel
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents Label54 As Label
    Friend WithEvents BackgroundWorker2 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Source_ As BindingSource
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Godown_Panel As Panel
    Friend WithEvents SortBy_LB As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Panel14 As Panel
    Friend WithEvents Branch_Panel As Panel
    Friend WithEvents Branch_Name_LB As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Panel15 As Panel
    Friend WithEvents Voucher_Type_Panel As Panel
    Friend WithEvents Voucher_Type_LB As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Panel24 As Panel
    Friend WithEvents Panel25 As Panel
    Friend WithEvents TableLayoutPanel5 As TableLayoutPanel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label10 As Label
End Class
