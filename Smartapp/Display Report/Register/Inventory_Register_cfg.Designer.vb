<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Inventory_Register_cfg
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
        Me.Transport_Panel = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Transport_YN = New Tools.YN()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GST_YN = New Tools.YN()
        Me.Narration_Panel = New System.Windows.Forms.Panel()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Narration_YN = New Tools.YN()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.T5 = New System.Windows.Forms.Panel()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Driver_Phone_YN = New Tools.YN()
        Me.T4 = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Driver_YN = New Tools.YN()
        Me.T3 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Vehicle_No_YN = New Tools.YN()
        Me.T2 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Vehicle_Type_YN = New Tools.YN()
        Me.T1 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Tra_Name_YN = New Tools.YN()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Sorting_Panel = New System.Windows.Forms.Panel()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.path_TXT = New Tools.TXT()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Transport_Panel.SuspendLayout()
        Me.Narration_Panel.SuspendLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.T5.SuspendLayout()
        Me.T4.SuspendLayout()
        Me.T3.SuspendLayout()
        Me.T2.SuspendLayout()
        Me.T1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.SuspendLayout()
        '
        'Transport_Panel
        '
        Me.Transport_Panel.AutoSize = True
        Me.Transport_Panel.Controls.Add(Me.Label5)
        Me.Transport_Panel.Controls.Add(Me.Label6)
        Me.Transport_Panel.Controls.Add(Me.Transport_YN)
        Me.Transport_Panel.Dock = System.Windows.Forms.DockStyle.Top
        Me.Transport_Panel.Location = New System.Drawing.Point(0, 0)
        Me.Transport_Panel.Name = "Transport_Panel"
        Me.Transport_Panel.Size = New System.Drawing.Size(255, 21)
        Me.Transport_Panel.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label5.Location = New System.Drawing.Point(4, 4)
        Me.Label5.Margin = New System.Windows.Forms.Padding(1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(106, 16)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Transport Details"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(175, 4)
        Me.Label6.Margin = New System.Windows.Forms.Padding(1)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(16, 16)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = ": "
        '
        'Transport_YN
        '
        Me.Transport_YN.Back_color = System.Drawing.Color.White
        Me.Transport_YN.BackColor = System.Drawing.Color.White
        Me.Transport_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Transport_YN.Data_Link_ = "Branch_YN"
        Me.Transport_YN.Defolt_ = "No"
        Me.Transport_YN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Transport_YN.Location = New System.Drawing.Point(194, 5)
        Me.Transport_YN.Margin = New System.Windows.Forms.Padding(1)
        Me.Transport_YN.Name = "Transport_YN"
        Me.Transport_YN.ReadOnly = True
        Me.Transport_YN.Size = New System.Drawing.Size(34, 15)
        Me.Transport_YN.TabIndex = 6
        Me.Transport_YN.Text = "No"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label1.Location = New System.Drawing.Point(4, 4)
        Me.Label1.Margin = New System.Windows.Forms.Padding(1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "GST Details"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(175, 4)
        Me.Label2.Margin = New System.Windows.Forms.Padding(1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(16, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = ": "
        '
        'GST_YN
        '
        Me.GST_YN.Back_color = System.Drawing.Color.White
        Me.GST_YN.BackColor = System.Drawing.Color.White
        Me.GST_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GST_YN.Data_Link_ = "Branch_YN"
        Me.GST_YN.Defolt_ = "No"
        Me.GST_YN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GST_YN.Location = New System.Drawing.Point(194, 5)
        Me.GST_YN.Margin = New System.Windows.Forms.Padding(1)
        Me.GST_YN.Name = "GST_YN"
        Me.GST_YN.ReadOnly = True
        Me.GST_YN.Size = New System.Drawing.Size(34, 15)
        Me.GST_YN.TabIndex = 6
        Me.GST_YN.Text = "No"
        '
        'Narration_Panel
        '
        Me.Narration_Panel.AutoSize = True
        Me.Narration_Panel.Controls.Add(Me.Label1)
        Me.Narration_Panel.Controls.Add(Me.Label2)
        Me.Narration_Panel.Controls.Add(Me.GST_YN)
        Me.Narration_Panel.Dock = System.Windows.Forms.DockStyle.Top
        Me.Narration_Panel.Location = New System.Drawing.Point(0, 47)
        Me.Narration_Panel.Name = "Narration_Panel"
        Me.Narration_Panel.Size = New System.Drawing.Size(255, 21)
        Me.Narration_Panel.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Narration_YN)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 26)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(255, 21)
        Me.Panel1.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label3.Location = New System.Drawing.Point(4, 4)
        Me.Label3.Margin = New System.Windows.Forms.Padding(1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Narration"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(175, 4)
        Me.Label4.Margin = New System.Windows.Forms.Padding(1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(16, 16)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = ": "
        '
        'Narration_YN
        '
        Me.Narration_YN.Back_color = System.Drawing.Color.White
        Me.Narration_YN.BackColor = System.Drawing.Color.White
        Me.Narration_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Narration_YN.Data_Link_ = ""
        Me.Narration_YN.Defolt_ = "No"
        Me.Narration_YN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Narration_YN.Location = New System.Drawing.Point(194, 5)
        Me.Narration_YN.Margin = New System.Windows.Forms.Padding(1)
        Me.Narration_YN.Name = "Narration_YN"
        Me.Narration_YN.ReadOnly = True
        Me.Narration_YN.Size = New System.Drawing.Size(34, 15)
        Me.Narration_YN.TabIndex = 6
        Me.Narration_YN.Text = "No"
        '
        'Panel2
        '
        Me.Panel2.AutoSize = True
        Me.Panel2.Controls.Add(Me.T5)
        Me.Panel2.Controls.Add(Me.T4)
        Me.Panel2.Controls.Add(Me.T3)
        Me.Panel2.Controls.Add(Me.T2)
        Me.Panel2.Controls.Add(Me.T1)
        Me.Panel2.Controls.Add(Me.Transport_Panel)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 68)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(255, 121)
        Me.Panel2.TabIndex = 3
        '
        'T5
        '
        Me.T5.AutoSize = True
        Me.T5.Controls.Add(Me.Label15)
        Me.T5.Controls.Add(Me.Label16)
        Me.T5.Controls.Add(Me.Driver_Phone_YN)
        Me.T5.Dock = System.Windows.Forms.DockStyle.Top
        Me.T5.Location = New System.Drawing.Point(0, 101)
        Me.T5.Name = "T5"
        Me.T5.Size = New System.Drawing.Size(255, 20)
        Me.T5.TabIndex = 7
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(22, 3)
        Me.Label15.Margin = New System.Windows.Forms.Padding(1)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(82, 16)
        Me.Label15.TabIndex = 3
        Me.Label15.Text = "Driver Phone"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(175, 3)
        Me.Label16.Margin = New System.Windows.Forms.Padding(1)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(16, 16)
        Me.Label16.TabIndex = 5
        Me.Label16.Text = ": "
        '
        'Driver_Phone_YN
        '
        Me.Driver_Phone_YN.Back_color = System.Drawing.Color.White
        Me.Driver_Phone_YN.BackColor = System.Drawing.Color.White
        Me.Driver_Phone_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Driver_Phone_YN.Data_Link_ = "Branch_YN"
        Me.Driver_Phone_YN.Defolt_ = "No"
        Me.Driver_Phone_YN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Driver_Phone_YN.Location = New System.Drawing.Point(194, 4)
        Me.Driver_Phone_YN.Margin = New System.Windows.Forms.Padding(1)
        Me.Driver_Phone_YN.Name = "Driver_Phone_YN"
        Me.Driver_Phone_YN.ReadOnly = True
        Me.Driver_Phone_YN.Size = New System.Drawing.Size(34, 15)
        Me.Driver_Phone_YN.TabIndex = 6
        Me.Driver_Phone_YN.Text = "No"
        '
        'T4
        '
        Me.T4.AutoSize = True
        Me.T4.Controls.Add(Me.Label13)
        Me.T4.Controls.Add(Me.Label14)
        Me.T4.Controls.Add(Me.Driver_YN)
        Me.T4.Dock = System.Windows.Forms.DockStyle.Top
        Me.T4.Location = New System.Drawing.Point(0, 81)
        Me.T4.Name = "T4"
        Me.T4.Size = New System.Drawing.Size(255, 20)
        Me.T4.TabIndex = 6
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(22, 3)
        Me.Label13.Margin = New System.Windows.Forms.Padding(1)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(79, 16)
        Me.Label13.TabIndex = 3
        Me.Label13.Text = "Driver Name"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(175, 3)
        Me.Label14.Margin = New System.Windows.Forms.Padding(1)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(16, 16)
        Me.Label14.TabIndex = 5
        Me.Label14.Text = ": "
        '
        'Driver_YN
        '
        Me.Driver_YN.Back_color = System.Drawing.Color.White
        Me.Driver_YN.BackColor = System.Drawing.Color.White
        Me.Driver_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Driver_YN.Data_Link_ = "Branch_YN"
        Me.Driver_YN.Defolt_ = "No"
        Me.Driver_YN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Driver_YN.Location = New System.Drawing.Point(194, 4)
        Me.Driver_YN.Margin = New System.Windows.Forms.Padding(1)
        Me.Driver_YN.Name = "Driver_YN"
        Me.Driver_YN.ReadOnly = True
        Me.Driver_YN.Size = New System.Drawing.Size(34, 15)
        Me.Driver_YN.TabIndex = 6
        Me.Driver_YN.Text = "No"
        '
        'T3
        '
        Me.T3.AutoSize = True
        Me.T3.Controls.Add(Me.Label11)
        Me.T3.Controls.Add(Me.Label12)
        Me.T3.Controls.Add(Me.Vehicle_No_YN)
        Me.T3.Dock = System.Windows.Forms.DockStyle.Top
        Me.T3.Location = New System.Drawing.Point(0, 61)
        Me.T3.Name = "T3"
        Me.T3.Size = New System.Drawing.Size(255, 20)
        Me.T3.TabIndex = 5
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(22, 3)
        Me.Label11.Margin = New System.Windows.Forms.Padding(1)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(75, 16)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "Vehicle No."
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(175, 3)
        Me.Label12.Margin = New System.Windows.Forms.Padding(1)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(16, 16)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = ": "
        '
        'Vehicle_No_YN
        '
        Me.Vehicle_No_YN.Back_color = System.Drawing.Color.White
        Me.Vehicle_No_YN.BackColor = System.Drawing.Color.White
        Me.Vehicle_No_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Vehicle_No_YN.Data_Link_ = "Branch_YN"
        Me.Vehicle_No_YN.Defolt_ = "No"
        Me.Vehicle_No_YN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Vehicle_No_YN.Location = New System.Drawing.Point(194, 4)
        Me.Vehicle_No_YN.Margin = New System.Windows.Forms.Padding(1)
        Me.Vehicle_No_YN.Name = "Vehicle_No_YN"
        Me.Vehicle_No_YN.ReadOnly = True
        Me.Vehicle_No_YN.Size = New System.Drawing.Size(34, 15)
        Me.Vehicle_No_YN.TabIndex = 6
        Me.Vehicle_No_YN.Text = "No"
        '
        'T2
        '
        Me.T2.AutoSize = True
        Me.T2.Controls.Add(Me.Label9)
        Me.T2.Controls.Add(Me.Label10)
        Me.T2.Controls.Add(Me.Vehicle_Type_YN)
        Me.T2.Dock = System.Windows.Forms.DockStyle.Top
        Me.T2.Location = New System.Drawing.Point(0, 41)
        Me.T2.Name = "T2"
        Me.T2.Size = New System.Drawing.Size(255, 20)
        Me.T2.TabIndex = 4
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(22, 3)
        Me.Label9.Margin = New System.Windows.Forms.Padding(1)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(82, 16)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "Vehicle Type"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(175, 3)
        Me.Label10.Margin = New System.Windows.Forms.Padding(1)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(16, 16)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = ": "
        '
        'Vehicle_Type_YN
        '
        Me.Vehicle_Type_YN.Back_color = System.Drawing.Color.White
        Me.Vehicle_Type_YN.BackColor = System.Drawing.Color.White
        Me.Vehicle_Type_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Vehicle_Type_YN.Data_Link_ = "Branch_YN"
        Me.Vehicle_Type_YN.Defolt_ = "No"
        Me.Vehicle_Type_YN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Vehicle_Type_YN.Location = New System.Drawing.Point(194, 4)
        Me.Vehicle_Type_YN.Margin = New System.Windows.Forms.Padding(1)
        Me.Vehicle_Type_YN.Name = "Vehicle_Type_YN"
        Me.Vehicle_Type_YN.ReadOnly = True
        Me.Vehicle_Type_YN.Size = New System.Drawing.Size(34, 15)
        Me.Vehicle_Type_YN.TabIndex = 6
        Me.Vehicle_Type_YN.Text = "No"
        '
        'T1
        '
        Me.T1.AutoSize = True
        Me.T1.Controls.Add(Me.Label7)
        Me.T1.Controls.Add(Me.Label8)
        Me.T1.Controls.Add(Me.Tra_Name_YN)
        Me.T1.Dock = System.Windows.Forms.DockStyle.Top
        Me.T1.Location = New System.Drawing.Point(0, 21)
        Me.T1.Name = "T1"
        Me.T1.Size = New System.Drawing.Size(255, 20)
        Me.T1.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(22, 3)
        Me.Label7.Margin = New System.Windows.Forms.Padding(1)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 16)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Transport Name"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(175, 3)
        Me.Label8.Margin = New System.Windows.Forms.Padding(1)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(16, 16)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = ": "
        '
        'Tra_Name_YN
        '
        Me.Tra_Name_YN.Back_color = System.Drawing.Color.White
        Me.Tra_Name_YN.BackColor = System.Drawing.Color.White
        Me.Tra_Name_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Tra_Name_YN.Data_Link_ = "Branch_YN"
        Me.Tra_Name_YN.Defolt_ = "No"
        Me.Tra_Name_YN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tra_Name_YN.Location = New System.Drawing.Point(194, 4)
        Me.Tra_Name_YN.Margin = New System.Windows.Forms.Padding(1)
        Me.Tra_Name_YN.Name = "Tra_Name_YN"
        Me.Tra_Name_YN.ReadOnly = True
        Me.Tra_Name_YN.Size = New System.Drawing.Size(34, 15)
        Me.Tra_Name_YN.TabIndex = 6
        Me.Tra_Name_YN.Text = "No"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(255, 204)
        Me.Panel3.TabIndex = 4
        '
        'Panel4
        '
        Me.Panel4.AutoSize = True
        Me.Panel4.Controls.Add(Me.Sorting_Panel)
        Me.Panel4.Controls.Add(Me.Panel2)
        Me.Panel4.Controls.Add(Me.Narration_Panel)
        Me.Panel4.Controls.Add(Me.Panel1)
        Me.Panel4.Controls.Add(Me.Label21)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Padding = New System.Windows.Forms.Padding(0, 10, 0, 10)
        Me.Panel4.Size = New System.Drawing.Size(255, 199)
        Me.Panel4.TabIndex = 109
        '
        'Sorting_Panel
        '
        Me.Sorting_Panel.AutoSize = True
        Me.Sorting_Panel.Dock = System.Windows.Forms.DockStyle.Top
        Me.Sorting_Panel.Location = New System.Drawing.Point(0, 189)
        Me.Sorting_Panel.Name = "Sorting_Panel"
        Me.Sorting_Panel.Size = New System.Drawing.Size(255, 0)
        Me.Sorting_Panel.TabIndex = 4
        '
        'Label21
        '
        Me.Label21.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label21.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(0, 10)
        Me.Label21.Margin = New System.Windows.Forms.Padding(1)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(255, 16)
        Me.Label21.TabIndex = 4
        Me.Label21.Text = "General Details"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Panel6)
        Me.Panel5.Controls.Add(Me.Panel8)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel5.Location = New System.Drawing.Point(255, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(409, 204)
        Me.Panel5.TabIndex = 5
        '
        'Panel6
        '
        Me.Panel6.AutoSize = True
        Me.Panel6.Controls.Add(Me.Panel7)
        Me.Panel6.Controls.Add(Me.Label34)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(1, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Padding = New System.Windows.Forms.Padding(0, 10, 0, 10)
        Me.Panel6.Size = New System.Drawing.Size(408, 59)
        Me.Panel6.TabIndex = 109
        '
        'Panel7
        '
        Me.Panel7.AutoSize = True
        Me.Panel7.Controls.Add(Me.path_TXT)
        Me.Panel7.Controls.Add(Me.Label17)
        Me.Panel7.Controls.Add(Me.Label18)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(0, 26)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(408, 23)
        Me.Panel7.TabIndex = 6
        '
        'path_TXT
        '
        Me.path_TXT.Auto_Cleane = True
        Me.path_TXT.Back_color = System.Drawing.Color.White
        Me.path_TXT.BackColor = System.Drawing.Color.White
        Me.path_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.path_TXT.Data_Link_ = ""
        Me.path_TXT.Decimal_ = 2
        Me.path_TXT.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.path_TXT.Font_Size = 10
        Me.path_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.path_TXT.Format_ = "dd-MM-yyyy"
        Me.path_TXT.Keydown_Support = True
        Me.path_TXT.Location = New System.Drawing.Point(138, 4)
        Me.path_TXT.Msg_Object = Nothing
        Me.path_TXT.Name = "path_TXT"
        Me.path_TXT.Select_Auto_Show = True
        Me.path_TXT.Select_Column_Color = "NA"
        Me.path_TXT.Select_Columns = 0
        Me.path_TXT.Select_Filter = " "
        Me.path_TXT.Select_Hide_Columns = "NA"
        Me.path_TXT.Select_Object = Nothing
        Me.path_TXT.Select_Source = Nothing
        Me.path_TXT.Size = New System.Drawing.Size(251, 16)
        Me.path_TXT.TabIndex = 10
        Me.path_TXT.Type_ = "Select"
        Me.path_TXT.Val_max = 1000000000
        Me.path_TXT.Val_min = 0
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label17.Location = New System.Drawing.Point(18, 4)
        Me.Label17.Margin = New System.Windows.Forms.Padding(1)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(66, 16)
        Me.Label17.TabIndex = 3
        Me.Label17.Text = "Print Path"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(119, 4)
        Me.Label18.Margin = New System.Windows.Forms.Padding(1)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(16, 16)
        Me.Label18.TabIndex = 5
        Me.Label18.Text = ": "
        '
        'Label34
        '
        Me.Label34.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label34.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(0, 10)
        Me.Label34.Margin = New System.Windows.Forms.Padding(1)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(408, 16)
        Me.Label34.TabIndex = 4
        Me.Label34.Text = "Print Details"
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.DarkGray
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel8.Location = New System.Drawing.Point(0, 0)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(1, 204)
        Me.Panel8.TabIndex = 110
        '
        'Inventory_Register_cfg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel3)
        Me.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Inventory_Register_cfg"
        Me.Size = New System.Drawing.Size(669, 204)
        Me.Transport_Panel.ResumeLayout(False)
        Me.Transport_Panel.PerformLayout()
        Me.Narration_Panel.ResumeLayout(False)
        Me.Narration_Panel.PerformLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.T5.ResumeLayout(False)
        Me.T5.PerformLayout()
        Me.T4.ResumeLayout(False)
        Me.T4.PerformLayout()
        Me.T3.ResumeLayout(False)
        Me.T3.PerformLayout()
        Me.T2.ResumeLayout(False)
        Me.T2.PerformLayout()
        Me.T1.ResumeLayout(False)
        Me.T1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents Transport_Panel As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Transport_YN As Tools.YN
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents GST_YN As Tools.YN
    Friend WithEvents Narration_Panel As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Narration_YN As Tools.YN
    Friend WithEvents Panel2 As Panel
    Friend WithEvents T1 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Tra_Name_YN As Tools.YN
    Friend WithEvents T2 As Panel
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Vehicle_Type_YN As Tools.YN
    Friend WithEvents T3 As Panel
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Vehicle_No_YN As Tools.YN
    Friend WithEvents T4 As Panel
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Driver_YN As Tools.YN
    Friend WithEvents T5 As Panel
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Driver_Phone_YN As Tools.YN
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Sorting_Panel As Panel
    Friend WithEvents Label21 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label34 As Label
    Friend WithEvents Panel7 As Panel
    Friend WithEvents path_TXT As Tools.TXT
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Panel8 As Panel
End Class
