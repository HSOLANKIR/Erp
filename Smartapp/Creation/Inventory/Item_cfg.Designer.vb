<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Item_cfg
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
        Me.Narration_Panel = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Alter_Unit_YN = New Tools.YN()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.Panel17 = New System.Windows.Forms.Panel()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.BindingSource2 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.BOM_YN = New Tools.YN()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Std_Rate_YN = New Tools.YN()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.MRP_YN = New Tools.YN()
        Me.GST_Panel = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GST_Cess_YN = New Tools.YN()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GST_YN = New Tools.YN()
        Me.Sorting_Panel = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Description_Note_YN = New Tools.YN()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Costing_Method_YN = New Tools.YN()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Market_Valuation_YN = New Tools.YN()
        Me.Narration_Panel.SuspendLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel14.SuspendLayout()
        CType(Me.BindingSource2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GST_Panel.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.SuspendLayout()
        '
        'Narration_Panel
        '
        Me.Narration_Panel.AutoSize = True
        Me.Narration_Panel.Controls.Add(Me.Label1)
        Me.Narration_Panel.Controls.Add(Me.Label2)
        Me.Narration_Panel.Controls.Add(Me.Alter_Unit_YN)
        Me.Narration_Panel.Dock = System.Windows.Forms.DockStyle.Top
        Me.Narration_Panel.Location = New System.Drawing.Point(0, 47)
        Me.Narration_Panel.Name = "Narration_Panel"
        Me.Narration_Panel.Size = New System.Drawing.Size(392, 21)
        Me.Narration_Panel.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label1.Location = New System.Drawing.Point(18, 4)
        Me.Label1.Margin = New System.Windows.Forms.Padding(1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Enable Alternate Units"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(179, 4)
        Me.Label2.Margin = New System.Windows.Forms.Padding(1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(15, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = ": "
        '
        'Alter_Unit_YN
        '
        Me.Alter_Unit_YN.Back_color = System.Drawing.Color.White
        Me.Alter_Unit_YN.BackColor = System.Drawing.Color.White
        Me.Alter_Unit_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Alter_Unit_YN.Data_Link_ = "Branch_YN"
        Me.Alter_Unit_YN.Defolt_ = "No"
        Me.Alter_Unit_YN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Alter_Unit_YN.Font_ = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Alter_Unit_YN.Location = New System.Drawing.Point(198, 5)
        Me.Alter_Unit_YN.Margin = New System.Windows.Forms.Padding(1)
        Me.Alter_Unit_YN.Name = "Alter_Unit_YN"
        Me.Alter_Unit_YN.ReadOnly = True
        Me.Alter_Unit_YN.Size = New System.Drawing.Size(34, 15)
        Me.Alter_Unit_YN.TabIndex = 6
        Me.Alter_Unit_YN.Text = "No"
        '
        'Panel14
        '
        Me.Panel14.AutoSize = True
        Me.Panel14.Controls.Add(Me.Panel17)
        Me.Panel14.Controls.Add(Me.Panel16)
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel14.Location = New System.Drawing.Point(0, 0)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(392, 2)
        Me.Panel14.TabIndex = 106
        Me.Panel14.Visible = False
        '
        'Panel17
        '
        Me.Panel17.BackColor = System.Drawing.Color.DimGray
        Me.Panel17.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel17.Location = New System.Drawing.Point(0, 1)
        Me.Panel17.Name = "Panel17"
        Me.Panel17.Size = New System.Drawing.Size(392, 1)
        Me.Panel17.TabIndex = 107
        '
        'Panel16
        '
        Me.Panel16.BackColor = System.Drawing.Color.DimGray
        Me.Panel16.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel16.Location = New System.Drawing.Point(0, 0)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(392, 1)
        Me.Panel16.TabIndex = 106
        '
        'Panel4
        '
        Me.Panel4.AutoSize = True
        Me.Panel4.Controls.Add(Me.Panel9)
        Me.Panel4.Controls.Add(Me.Panel8)
        Me.Panel4.Controls.Add(Me.Panel6)
        Me.Panel4.Controls.Add(Me.Panel5)
        Me.Panel4.Controls.Add(Me.Panel2)
        Me.Panel4.Controls.Add(Me.GST_Panel)
        Me.Panel4.Controls.Add(Me.Narration_Panel)
        Me.Panel4.Controls.Add(Me.Sorting_Panel)
        Me.Panel4.Controls.Add(Me.Panel7)
        Me.Panel4.Controls.Add(Me.Label17)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 2)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Padding = New System.Windows.Forms.Padding(0, 10, 0, 10)
        Me.Panel4.Size = New System.Drawing.Size(392, 225)
        Me.Panel4.TabIndex = 107
        '
        'Panel6
        '
        Me.Panel6.AutoSize = True
        Me.Panel6.Controls.Add(Me.Label11)
        Me.Panel6.Controls.Add(Me.Label12)
        Me.Panel6.Controls.Add(Me.BOM_YN)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 152)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(392, 21)
        Me.Panel6.TabIndex = 5
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label11.Location = New System.Drawing.Point(18, 4)
        Me.Label11.Margin = New System.Windows.Forms.Padding(1)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(143, 16)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "Components list (BOM)"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(179, 4)
        Me.Label12.Margin = New System.Windows.Forms.Padding(1)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(15, 16)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = ": "
        '
        'BOM_YN
        '
        Me.BOM_YN.Back_color = System.Drawing.Color.White
        Me.BOM_YN.BackColor = System.Drawing.Color.White
        Me.BOM_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.BOM_YN.Data_Link_ = "Branch_YN"
        Me.BOM_YN.Defolt_ = "No"
        Me.BOM_YN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BOM_YN.Font_ = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.BOM_YN.Location = New System.Drawing.Point(198, 5)
        Me.BOM_YN.Margin = New System.Windows.Forms.Padding(1)
        Me.BOM_YN.Name = "BOM_YN"
        Me.BOM_YN.ReadOnly = True
        Me.BOM_YN.Size = New System.Drawing.Size(34, 15)
        Me.BOM_YN.TabIndex = 6
        Me.BOM_YN.Text = "No"
        '
        'Panel5
        '
        Me.Panel5.AutoSize = True
        Me.Panel5.Controls.Add(Me.Label9)
        Me.Panel5.Controls.Add(Me.Label10)
        Me.Panel5.Controls.Add(Me.Std_Rate_YN)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 131)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(392, 21)
        Me.Panel5.TabIndex = 4
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label9.Location = New System.Drawing.Point(18, 4)
        Me.Label9.Margin = New System.Windows.Forms.Padding(1)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(134, 16)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "Enable Standard Rate"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(179, 4)
        Me.Label10.Margin = New System.Windows.Forms.Padding(1)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(15, 16)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = ": "
        '
        'Std_Rate_YN
        '
        Me.Std_Rate_YN.Back_color = System.Drawing.Color.White
        Me.Std_Rate_YN.BackColor = System.Drawing.Color.White
        Me.Std_Rate_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Std_Rate_YN.Data_Link_ = "Branch_YN"
        Me.Std_Rate_YN.Defolt_ = "No"
        Me.Std_Rate_YN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Std_Rate_YN.Font_ = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Std_Rate_YN.Location = New System.Drawing.Point(198, 5)
        Me.Std_Rate_YN.Margin = New System.Windows.Forms.Padding(1)
        Me.Std_Rate_YN.Name = "Std_Rate_YN"
        Me.Std_Rate_YN.ReadOnly = True
        Me.Std_Rate_YN.Size = New System.Drawing.Size(34, 15)
        Me.Std_Rate_YN.TabIndex = 6
        Me.Std_Rate_YN.Text = "No"
        '
        'Panel2
        '
        Me.Panel2.AutoSize = True
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.MRP_YN)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 110)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(392, 21)
        Me.Panel2.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label7.Location = New System.Drawing.Point(18, 4)
        Me.Label7.Margin = New System.Windows.Forms.Padding(1)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(90, 16)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Enable M.R.P."
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(179, 4)
        Me.Label8.Margin = New System.Windows.Forms.Padding(1)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(15, 16)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = ": "
        '
        'MRP_YN
        '
        Me.MRP_YN.Back_color = System.Drawing.Color.White
        Me.MRP_YN.BackColor = System.Drawing.Color.White
        Me.MRP_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.MRP_YN.Data_Link_ = "Branch_YN"
        Me.MRP_YN.Defolt_ = "No"
        Me.MRP_YN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MRP_YN.Font_ = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.MRP_YN.Location = New System.Drawing.Point(198, 5)
        Me.MRP_YN.Margin = New System.Windows.Forms.Padding(1)
        Me.MRP_YN.Name = "MRP_YN"
        Me.MRP_YN.ReadOnly = True
        Me.MRP_YN.Size = New System.Drawing.Size(34, 15)
        Me.MRP_YN.TabIndex = 6
        Me.MRP_YN.Text = "No"
        '
        'GST_Panel
        '
        Me.GST_Panel.AutoSize = True
        Me.GST_Panel.Controls.Add(Me.Panel3)
        Me.GST_Panel.Controls.Add(Me.Panel1)
        Me.GST_Panel.Dock = System.Windows.Forms.DockStyle.Top
        Me.GST_Panel.Location = New System.Drawing.Point(0, 68)
        Me.GST_Panel.Name = "GST_Panel"
        Me.GST_Panel.Size = New System.Drawing.Size(392, 42)
        Me.GST_Panel.TabIndex = 2
        '
        'Panel3
        '
        Me.Panel3.AutoSize = True
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.GST_Cess_YN)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 21)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(392, 21)
        Me.Panel3.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(39, 4)
        Me.Label5.Margin = New System.Windows.Forms.Padding(1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 16)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Cess Rate"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(179, 4)
        Me.Label6.Margin = New System.Windows.Forms.Padding(1)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(15, 16)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = ": "
        '
        'GST_Cess_YN
        '
        Me.GST_Cess_YN.Back_color = System.Drawing.Color.White
        Me.GST_Cess_YN.BackColor = System.Drawing.Color.White
        Me.GST_Cess_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GST_Cess_YN.Data_Link_ = "Branch_YN"
        Me.GST_Cess_YN.Defolt_ = "No"
        Me.GST_Cess_YN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GST_Cess_YN.Font_ = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GST_Cess_YN.Location = New System.Drawing.Point(198, 5)
        Me.GST_Cess_YN.Margin = New System.Windows.Forms.Padding(1)
        Me.GST_Cess_YN.Name = "GST_Cess_YN"
        Me.GST_Cess_YN.ReadOnly = True
        Me.GST_Cess_YN.Size = New System.Drawing.Size(34, 15)
        Me.GST_Cess_YN.TabIndex = 6
        Me.GST_Cess_YN.Text = "No"
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.GST_YN)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(392, 21)
        Me.Panel1.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label3.Location = New System.Drawing.Point(18, 4)
        Me.Label3.Margin = New System.Windows.Forms.Padding(1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Enable GST"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(179, 4)
        Me.Label4.Margin = New System.Windows.Forms.Padding(1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(15, 16)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = ": "
        '
        'GST_YN
        '
        Me.GST_YN.Back_color = System.Drawing.Color.White
        Me.GST_YN.BackColor = System.Drawing.Color.White
        Me.GST_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GST_YN.Data_Link_ = "Branch_YN"
        Me.GST_YN.Defolt_ = "No"
        Me.GST_YN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GST_YN.Font_ = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GST_YN.Location = New System.Drawing.Point(198, 5)
        Me.GST_YN.Margin = New System.Windows.Forms.Padding(1)
        Me.GST_YN.Name = "GST_YN"
        Me.GST_YN.ReadOnly = True
        Me.GST_YN.Size = New System.Drawing.Size(34, 15)
        Me.GST_YN.TabIndex = 6
        Me.GST_YN.Text = "No"
        '
        'Sorting_Panel
        '
        Me.Sorting_Panel.AutoSize = True
        Me.Sorting_Panel.Dock = System.Windows.Forms.DockStyle.Top
        Me.Sorting_Panel.Location = New System.Drawing.Point(0, 47)
        Me.Sorting_Panel.Name = "Sorting_Panel"
        Me.Sorting_Panel.Size = New System.Drawing.Size(392, 0)
        Me.Sorting_Panel.TabIndex = 4
        '
        'Panel7
        '
        Me.Panel7.AutoSize = True
        Me.Panel7.Controls.Add(Me.Label13)
        Me.Panel7.Controls.Add(Me.Label14)
        Me.Panel7.Controls.Add(Me.Description_Note_YN)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(0, 26)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(392, 21)
        Me.Panel7.TabIndex = 0
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label13.Location = New System.Drawing.Point(18, 4)
        Me.Label13.Margin = New System.Windows.Forms.Padding(1)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(143, 16)
        Me.Label13.TabIndex = 3
        Me.Label13.Text = "Enable Discription/Note"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(179, 4)
        Me.Label14.Margin = New System.Windows.Forms.Padding(1)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(15, 16)
        Me.Label14.TabIndex = 5
        Me.Label14.Text = ": "
        '
        'Description_Note_YN
        '
        Me.Description_Note_YN.Back_color = System.Drawing.Color.White
        Me.Description_Note_YN.BackColor = System.Drawing.Color.White
        Me.Description_Note_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Description_Note_YN.Data_Link_ = "Branch_YN"
        Me.Description_Note_YN.Defolt_ = "No"
        Me.Description_Note_YN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Description_Note_YN.Font_ = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Description_Note_YN.Location = New System.Drawing.Point(198, 5)
        Me.Description_Note_YN.Margin = New System.Windows.Forms.Padding(1)
        Me.Description_Note_YN.Name = "Description_Note_YN"
        Me.Description_Note_YN.ReadOnly = True
        Me.Description_Note_YN.Size = New System.Drawing.Size(34, 15)
        Me.Description_Note_YN.TabIndex = 6
        Me.Description_Note_YN.Text = "No"
        '
        'Label17
        '
        Me.Label17.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(0, 10)
        Me.Label17.Margin = New System.Windows.Forms.Padding(1)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(392, 16)
        Me.Label17.TabIndex = 4
        Me.Label17.Text = "General Details"
        '
        'Panel8
        '
        Me.Panel8.AutoSize = True
        Me.Panel8.Controls.Add(Me.Label15)
        Me.Panel8.Controls.Add(Me.Label16)
        Me.Panel8.Controls.Add(Me.Costing_Method_YN)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel8.Location = New System.Drawing.Point(0, 173)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(392, 21)
        Me.Panel8.TabIndex = 6
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label15.Location = New System.Drawing.Point(18, 4)
        Me.Label15.Margin = New System.Windows.Forms.Padding(1)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(98, 16)
        Me.Label15.TabIndex = 3
        Me.Label15.Text = "Costing Method"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(179, 4)
        Me.Label16.Margin = New System.Windows.Forms.Padding(1)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(15, 16)
        Me.Label16.TabIndex = 5
        Me.Label16.Text = ": "
        '
        'Costing_Method_YN
        '
        Me.Costing_Method_YN.Back_color = System.Drawing.Color.White
        Me.Costing_Method_YN.BackColor = System.Drawing.Color.White
        Me.Costing_Method_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Costing_Method_YN.Data_Link_ = "Branch_YN"
        Me.Costing_Method_YN.Defolt_ = "No"
        Me.Costing_Method_YN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Costing_Method_YN.Font_ = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Costing_Method_YN.Location = New System.Drawing.Point(198, 5)
        Me.Costing_Method_YN.Margin = New System.Windows.Forms.Padding(1)
        Me.Costing_Method_YN.Name = "Costing_Method_YN"
        Me.Costing_Method_YN.ReadOnly = True
        Me.Costing_Method_YN.Size = New System.Drawing.Size(34, 15)
        Me.Costing_Method_YN.TabIndex = 6
        Me.Costing_Method_YN.Text = "No"
        '
        'Panel9
        '
        Me.Panel9.AutoSize = True
        Me.Panel9.Controls.Add(Me.Label18)
        Me.Panel9.Controls.Add(Me.Label19)
        Me.Panel9.Controls.Add(Me.Market_Valuation_YN)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel9.Location = New System.Drawing.Point(0, 194)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(392, 21)
        Me.Panel9.TabIndex = 7
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label18.Location = New System.Drawing.Point(18, 4)
        Me.Label18.Margin = New System.Windows.Forms.Padding(1)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(104, 16)
        Me.Label18.TabIndex = 3
        Me.Label18.Text = "Market Valuation"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(179, 4)
        Me.Label19.Margin = New System.Windows.Forms.Padding(1)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(15, 16)
        Me.Label19.TabIndex = 5
        Me.Label19.Text = ": "
        '
        'Market_Valuation_YN
        '
        Me.Market_Valuation_YN.Back_color = System.Drawing.Color.White
        Me.Market_Valuation_YN.BackColor = System.Drawing.Color.White
        Me.Market_Valuation_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Market_Valuation_YN.Data_Link_ = "Branch_YN"
        Me.Market_Valuation_YN.Defolt_ = "No"
        Me.Market_Valuation_YN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Market_Valuation_YN.Font_ = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Market_Valuation_YN.Location = New System.Drawing.Point(198, 5)
        Me.Market_Valuation_YN.Margin = New System.Windows.Forms.Padding(1)
        Me.Market_Valuation_YN.Name = "Market_Valuation_YN"
        Me.Market_Valuation_YN.ReadOnly = True
        Me.Market_Valuation_YN.Size = New System.Drawing.Size(34, 15)
        Me.Market_Valuation_YN.TabIndex = 6
        Me.Market_Valuation_YN.Text = "No"
        '
        'Item_cfg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel14)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Item_cfg"
        Me.Size = New System.Drawing.Size(392, 228)
        Me.Narration_Panel.ResumeLayout(False)
        Me.Narration_Panel.PerformLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel14.ResumeLayout(False)
        CType(Me.BindingSource2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GST_Panel.ResumeLayout(False)
        Me.GST_Panel.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Narration_Panel As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Alter_Unit_YN As Tools.YN
    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents Panel14 As Panel
    Friend WithEvents Panel17 As Panel
    Friend WithEvents Panel16 As Panel
    Friend WithEvents BindingSource2 As BindingSource
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Sorting_Panel As Panel
    Friend WithEvents Label17 As Label
    Friend WithEvents GST_Panel As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents GST_YN As Tools.YN
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents GST_Cess_YN As Tools.YN
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents MRP_YN As Tools.YN
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Std_Rate_YN As Tools.YN
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents BOM_YN As Tools.YN
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Description_Note_YN As Tools.YN
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Costing_Method_YN As Tools.YN
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Market_Valuation_YN As Tools.YN
End Class
