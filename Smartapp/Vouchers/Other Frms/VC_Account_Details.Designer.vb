<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class VC_Account_Details
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Txt2 = New Tools.TXT()
        Me.Country_Source = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Ship_Pincode_TXT = New Tools.TXT()
        Me.State_Source = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Ship_GST_Type_TXT = New Tools.TXT()
        Me.GST_Type_Source = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Ship_GST_TXT = New Tools.TXT()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Ship_State_TXT = New Tools.TXT()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Ship_Name_TXT = New Tools.TXT()
        Me.Ship_Mailing_TXT = New Tools.TXT()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Ship_Address_TXT = New Tools.TXT()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Txt1 = New Tools.TXT()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Acc_Pincode_TXT = New Tools.TXT()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Acc_GST_Type_TXT = New Tools.TXT()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Acc_GST_TXT = New Tools.TXT()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Acc_State_TXT = New Tools.TXT()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Acc_Address_TXT = New Tools.TXT()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Acc_Mailing_TXT = New Tools.TXT()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Acc_Name_TXT = New Tools.TXT()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.save_txt = New Tools.TXT()
        Me.Account_Source = New System.Windows.Forms.BindingSource(Me.components)
        Me.Account_Source01 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.Country_Source, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.State_Source, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GST_Type_Source, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.Account_Source, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Account_Source01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.save_txt)
        Me.Panel1.Location = New System.Drawing.Point(154, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(921, 341)
        Me.Panel1.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel5, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 24)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(919, 315)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Label16)
        Me.Panel5.Controls.Add(Me.Txt2)
        Me.Panel5.Controls.Add(Me.Label35)
        Me.Panel5.Controls.Add(Me.Label21)
        Me.Panel5.Controls.Add(Me.Ship_Pincode_TXT)
        Me.Panel5.Controls.Add(Me.Label22)
        Me.Panel5.Controls.Add(Me.Label23)
        Me.Panel5.Controls.Add(Me.Ship_GST_Type_TXT)
        Me.Panel5.Controls.Add(Me.Label24)
        Me.Panel5.Controls.Add(Me.Label31)
        Me.Panel5.Controls.Add(Me.Ship_GST_TXT)
        Me.Panel5.Controls.Add(Me.Label32)
        Me.Panel5.Controls.Add(Me.Label33)
        Me.Panel5.Controls.Add(Me.Ship_State_TXT)
        Me.Panel5.Controls.Add(Me.Label34)
        Me.Panel5.Controls.Add(Me.Panel7)
        Me.Panel5.Controls.Add(Me.Ship_Name_TXT)
        Me.Panel5.Controls.Add(Me.Ship_Mailing_TXT)
        Me.Panel5.Controls.Add(Me.Label18)
        Me.Panel5.Controls.Add(Me.Label25)
        Me.Panel5.Controls.Add(Me.Ship_Address_TXT)
        Me.Panel5.Controls.Add(Me.Label26)
        Me.Panel5.Controls.Add(Me.Label27)
        Me.Panel5.Controls.Add(Me.Label28)
        Me.Panel5.Controls.Add(Me.Label29)
        Me.Panel5.Controls.Add(Me.Label30)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(461, 2)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(456, 311)
        Me.Panel5.TabIndex = 3
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(165, 206)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(11, 16)
        Me.Label16.TabIndex = 40
        Me.Label16.Text = ":"
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
        Me.Txt2.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Txt2.Font_Size = 11
        Me.Txt2.Font_Style = System.Drawing.FontStyle.Bold
        Me.Txt2.Format_ = "dd-MM-yyyy"
        Me.Txt2.Keydown_Support = True
        Me.Txt2.Location = New System.Drawing.Point(182, 207)
        Me.Txt2.Msg_Object = Nothing
        Me.Txt2.Name = "Txt2"
        Me.Txt2.Select_Auto_Show = True
        Me.Txt2.Select_Column_Color = "NA"
        Me.Txt2.Select_Columns = 0
        Me.Txt2.Select_Filter = "(Country_Name LIKE '%<value>%')"
        Me.Txt2.Select_Hide_Columns = "NA"
        Me.Txt2.Select_Object = Nothing
        Me.Txt2.Select_Source = Me.Country_Source
        Me.Txt2.Size = New System.Drawing.Size(263, 15)
        Me.Txt2.TabIndex = 4
        Me.Txt2.Type_ = "Select"
        Me.Txt2.Val_max = 1000000000
        Me.Txt2.Val_min = 0
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(10, 206)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(52, 16)
        Me.Label35.TabIndex = 39
        Me.Label35.Text = "Country"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(165, 227)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(11, 16)
        Me.Label21.TabIndex = 37
        Me.Label21.Text = ":"
        '
        'Ship_Pincode_TXT
        '
        Me.Ship_Pincode_TXT.Auto_Cleane = True
        Me.Ship_Pincode_TXT.Back_color = System.Drawing.Color.White
        Me.Ship_Pincode_TXT.BackColor = System.Drawing.Color.White
        Me.Ship_Pincode_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Ship_Pincode_TXT.Data_Link_ = ""
        Me.Ship_Pincode_TXT.Decimal_ = 2
        Me.Ship_Pincode_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ship_Pincode_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Ship_Pincode_TXT.Font_Size = 11
        Me.Ship_Pincode_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Ship_Pincode_TXT.Format_ = "dd-MM-yyyy"
        Me.Ship_Pincode_TXT.Keydown_Support = True
        Me.Ship_Pincode_TXT.Location = New System.Drawing.Point(182, 227)
        Me.Ship_Pincode_TXT.MaxLength = 6
        Me.Ship_Pincode_TXT.Msg_Object = Nothing
        Me.Ship_Pincode_TXT.Name = "Ship_Pincode_TXT"
        Me.Ship_Pincode_TXT.Select_Auto_Show = True
        Me.Ship_Pincode_TXT.Select_Column_Color = "NA"
        Me.Ship_Pincode_TXT.Select_Columns = 0
        Me.Ship_Pincode_TXT.Select_Filter = "(Name LIKE '%<value>%')"
        Me.Ship_Pincode_TXT.Select_Hide_Columns = "NA"
        Me.Ship_Pincode_TXT.Select_Object = Nothing
        Me.Ship_Pincode_TXT.Select_Source = Me.State_Source
        Me.Ship_Pincode_TXT.Size = New System.Drawing.Size(58, 15)
        Me.Ship_Pincode_TXT.TabIndex = 5
        Me.Ship_Pincode_TXT.Type_ = "Select"
        Me.Ship_Pincode_TXT.Val_max = 1000000000
        Me.Ship_Pincode_TXT.Val_min = 0
        '
        'State_Source
        '
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(10, 227)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(54, 16)
        Me.Label22.TabIndex = 36
        Me.Label22.Text = "Pincode"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(165, 263)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(11, 16)
        Me.Label23.TabIndex = 35
        Me.Label23.Text = ":"
        '
        'Ship_GST_Type_TXT
        '
        Me.Ship_GST_Type_TXT.Auto_Cleane = True
        Me.Ship_GST_Type_TXT.Back_color = System.Drawing.Color.White
        Me.Ship_GST_Type_TXT.BackColor = System.Drawing.Color.White
        Me.Ship_GST_Type_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Ship_GST_Type_TXT.Data_Link_ = ""
        Me.Ship_GST_Type_TXT.Decimal_ = 2
        Me.Ship_GST_Type_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ship_GST_Type_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Ship_GST_Type_TXT.Font_Size = 11
        Me.Ship_GST_Type_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Ship_GST_Type_TXT.Format_ = "dd-MM-yyyy"
        Me.Ship_GST_Type_TXT.Keydown_Support = True
        Me.Ship_GST_Type_TXT.Location = New System.Drawing.Point(182, 263)
        Me.Ship_GST_Type_TXT.Msg_Object = Nothing
        Me.Ship_GST_Type_TXT.Name = "Ship_GST_Type_TXT"
        Me.Ship_GST_Type_TXT.ReadOnly = True
        Me.Ship_GST_Type_TXT.Select_Auto_Show = True
        Me.Ship_GST_Type_TXT.Select_Column_Color = "NA"
        Me.Ship_GST_Type_TXT.Select_Columns = 0
        Me.Ship_GST_Type_TXT.Select_Filter = " "
        Me.Ship_GST_Type_TXT.Select_Hide_Columns = "NA"
        Me.Ship_GST_Type_TXT.Select_Object = Nothing
        Me.Ship_GST_Type_TXT.Select_Source = Me.GST_Type_Source
        Me.Ship_GST_Type_TXT.Size = New System.Drawing.Size(122, 15)
        Me.Ship_GST_Type_TXT.TabIndex = 6
        Me.Ship_GST_Type_TXT.Type_ = "Select"
        Me.Ship_GST_Type_TXT.Val_max = 1000000000
        Me.Ship_GST_Type_TXT.Val_min = 0
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(10, 263)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(135, 16)
        Me.Label24.TabIndex = 34
        Me.Label24.Text = "GST Registration type"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(165, 284)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(11, 16)
        Me.Label31.TabIndex = 33
        Me.Label31.Text = ":"
        '
        'Ship_GST_TXT
        '
        Me.Ship_GST_TXT.Auto_Cleane = True
        Me.Ship_GST_TXT.Back_color = System.Drawing.Color.White
        Me.Ship_GST_TXT.BackColor = System.Drawing.Color.White
        Me.Ship_GST_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Ship_GST_TXT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Ship_GST_TXT.Data_Link_ = ""
        Me.Ship_GST_TXT.Decimal_ = 2
        Me.Ship_GST_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ship_GST_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Ship_GST_TXT.Font_Size = 11
        Me.Ship_GST_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Ship_GST_TXT.Format_ = "dd-MM-yyyy"
        Me.Ship_GST_TXT.Keydown_Support = True
        Me.Ship_GST_TXT.Location = New System.Drawing.Point(182, 284)
        Me.Ship_GST_TXT.Msg_Object = Nothing
        Me.Ship_GST_TXT.Name = "Ship_GST_TXT"
        Me.Ship_GST_TXT.Select_Auto_Show = True
        Me.Ship_GST_TXT.Select_Column_Color = "NA"
        Me.Ship_GST_TXT.Select_Columns = 0
        Me.Ship_GST_TXT.Select_Filter = Nothing
        Me.Ship_GST_TXT.Select_Hide_Columns = "NA"
        Me.Ship_GST_TXT.Select_Object = Nothing
        Me.Ship_GST_TXT.Select_Source = Nothing
        Me.Ship_GST_TXT.Size = New System.Drawing.Size(263, 15)
        Me.Ship_GST_TXT.TabIndex = 7
        Me.Ship_GST_TXT.Type_ = "TXT"
        Me.Ship_GST_TXT.Val_max = 1000000000
        Me.Ship_GST_TXT.Val_min = 0
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(10, 284)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(70, 16)
        Me.Label32.TabIndex = 32
        Me.Label32.Text = "GSTIN/UIN"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(165, 184)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(11, 16)
        Me.Label33.TabIndex = 31
        Me.Label33.Text = ":"
        '
        'Ship_State_TXT
        '
        Me.Ship_State_TXT.Auto_Cleane = True
        Me.Ship_State_TXT.Back_color = System.Drawing.Color.White
        Me.Ship_State_TXT.BackColor = System.Drawing.Color.White
        Me.Ship_State_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Ship_State_TXT.Data_Link_ = ""
        Me.Ship_State_TXT.Decimal_ = 2
        Me.Ship_State_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ship_State_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Ship_State_TXT.Font_Size = 11
        Me.Ship_State_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Ship_State_TXT.Format_ = "dd-MM-yyyy"
        Me.Ship_State_TXT.Keydown_Support = True
        Me.Ship_State_TXT.Location = New System.Drawing.Point(182, 185)
        Me.Ship_State_TXT.Msg_Object = Nothing
        Me.Ship_State_TXT.Name = "Ship_State_TXT"
        Me.Ship_State_TXT.Select_Auto_Show = True
        Me.Ship_State_TXT.Select_Column_Color = "NA"
        Me.Ship_State_TXT.Select_Columns = 0
        Me.Ship_State_TXT.Select_Filter = "(Name LIKE '%<value>%')"
        Me.Ship_State_TXT.Select_Hide_Columns = "NA"
        Me.Ship_State_TXT.Select_Object = Nothing
        Me.Ship_State_TXT.Select_Source = Me.State_Source
        Me.Ship_State_TXT.Size = New System.Drawing.Size(263, 15)
        Me.Ship_State_TXT.TabIndex = 3
        Me.Ship_State_TXT.Type_ = "Select"
        Me.Ship_State_TXT.Val_max = 1000000000
        Me.Ship_State_TXT.Val_min = 0
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(10, 184)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(38, 16)
        Me.Label34.TabIndex = 30
        Me.Label34.Text = "State"
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.Silver
        Me.Panel7.Location = New System.Drawing.Point(13, 174)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(432, 1)
        Me.Panel7.TabIndex = 23
        '
        'Ship_Name_TXT
        '
        Me.Ship_Name_TXT.Auto_Cleane = True
        Me.Ship_Name_TXT.Back_color = System.Drawing.Color.White
        Me.Ship_Name_TXT.BackColor = System.Drawing.Color.White
        Me.Ship_Name_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Ship_Name_TXT.Data_Link_ = ""
        Me.Ship_Name_TXT.Decimal_ = 2
        Me.Ship_Name_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ship_Name_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Ship_Name_TXT.Font_Size = 11
        Me.Ship_Name_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Ship_Name_TXT.Format_ = "dd-MM-yyyy"
        Me.Ship_Name_TXT.Keydown_Support = True
        Me.Ship_Name_TXT.Location = New System.Drawing.Point(182, 27)
        Me.Ship_Name_TXT.Msg_Object = Nothing
        Me.Ship_Name_TXT.Name = "Ship_Name_TXT"
        Me.Ship_Name_TXT.Select_Auto_Show = True
        Me.Ship_Name_TXT.Select_Column_Color = "NA"
        Me.Ship_Name_TXT.Select_Columns = 0
        Me.Ship_Name_TXT.Select_Filter = "(Name LIKE '%<value>%' or Alias = 'Create')"
        Me.Ship_Name_TXT.Select_Hide_Columns = "NA"
        Me.Ship_Name_TXT.Select_Object = Nothing
        Me.Ship_Name_TXT.Select_Source = Nothing
        Me.Ship_Name_TXT.Size = New System.Drawing.Size(263, 15)
        Me.Ship_Name_TXT.TabIndex = 0
        Me.Ship_Name_TXT.Type_ = "Select"
        Me.Ship_Name_TXT.Val_max = 1000000000
        Me.Ship_Name_TXT.Val_min = 0
        '
        'Ship_Mailing_TXT
        '
        Me.Ship_Mailing_TXT.Auto_Cleane = True
        Me.Ship_Mailing_TXT.Back_color = System.Drawing.Color.White
        Me.Ship_Mailing_TXT.BackColor = System.Drawing.Color.White
        Me.Ship_Mailing_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Ship_Mailing_TXT.Data_Link_ = ""
        Me.Ship_Mailing_TXT.Decimal_ = 2
        Me.Ship_Mailing_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ship_Mailing_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Ship_Mailing_TXT.Font_Size = 11
        Me.Ship_Mailing_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Ship_Mailing_TXT.Format_ = "dd-MM-yyyy"
        Me.Ship_Mailing_TXT.Keydown_Support = True
        Me.Ship_Mailing_TXT.Location = New System.Drawing.Point(182, 47)
        Me.Ship_Mailing_TXT.Msg_Object = Nothing
        Me.Ship_Mailing_TXT.Name = "Ship_Mailing_TXT"
        Me.Ship_Mailing_TXT.Select_Auto_Show = True
        Me.Ship_Mailing_TXT.Select_Column_Color = "NA"
        Me.Ship_Mailing_TXT.Select_Columns = 0
        Me.Ship_Mailing_TXT.Select_Filter = Nothing
        Me.Ship_Mailing_TXT.Select_Hide_Columns = "NA"
        Me.Ship_Mailing_TXT.Select_Object = Nothing
        Me.Ship_Mailing_TXT.Select_Source = Nothing
        Me.Ship_Mailing_TXT.Size = New System.Drawing.Size(263, 15)
        Me.Ship_Mailing_TXT.TabIndex = 1
        Me.Ship_Mailing_TXT.Type_ = "TXT"
        Me.Ship_Mailing_TXT.Val_max = 1000000000
        Me.Ship_Mailing_TXT.Val_min = 0
        '
        'Label18
        '
        Me.Label18.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label18.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.DimGray
        Me.Label18.Location = New System.Drawing.Point(0, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(456, 15)
        Me.Label18.TabIndex = 21
        Me.Label18.Text = "Consignee (Ship to)"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(165, 67)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(11, 16)
        Me.Label25.TabIndex = 11
        Me.Label25.Text = ":"
        '
        'Ship_Address_TXT
        '
        Me.Ship_Address_TXT.Auto_Cleane = True
        Me.Ship_Address_TXT.Back_color = System.Drawing.Color.White
        Me.Ship_Address_TXT.BackColor = System.Drawing.Color.White
        Me.Ship_Address_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Ship_Address_TXT.Data_Link_ = ""
        Me.Ship_Address_TXT.Decimal_ = 2
        Me.Ship_Address_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ship_Address_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Ship_Address_TXT.Font_Size = 11
        Me.Ship_Address_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Ship_Address_TXT.Format_ = "dd-MM-yyyy"
        Me.Ship_Address_TXT.Keydown_Support = True
        Me.Ship_Address_TXT.Location = New System.Drawing.Point(13, 86)
        Me.Ship_Address_TXT.Msg_Object = Nothing
        Me.Ship_Address_TXT.Multiline = True
        Me.Ship_Address_TXT.Name = "Ship_Address_TXT"
        Me.Ship_Address_TXT.Select_Auto_Show = True
        Me.Ship_Address_TXT.Select_Column_Color = "NA"
        Me.Ship_Address_TXT.Select_Columns = 0
        Me.Ship_Address_TXT.Select_Filter = Nothing
        Me.Ship_Address_TXT.Select_Hide_Columns = "NA"
        Me.Ship_Address_TXT.Select_Object = Nothing
        Me.Ship_Address_TXT.Select_Source = Nothing
        Me.Ship_Address_TXT.Size = New System.Drawing.Size(432, 83)
        Me.Ship_Address_TXT.TabIndex = 2
        Me.Ship_Address_TXT.Type_ = "TXT"
        Me.Ship_Address_TXT.Val_max = 1000000000
        Me.Ship_Address_TXT.Val_min = 0
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(10, 67)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(55, 16)
        Me.Label26.TabIndex = 9
        Me.Label26.Text = "Address"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(165, 47)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(11, 16)
        Me.Label27.TabIndex = 8
        Me.Label27.Text = ":"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(10, 47)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(86, 16)
        Me.Label28.TabIndex = 6
        Me.Label28.Text = "Mailing Name"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(165, 27)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(11, 16)
        Me.Label29.TabIndex = 5
        Me.Label29.Text = ":"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(10, 27)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(121, 16)
        Me.Label30.TabIndex = 3
        Me.Label30.Text = "Consignee (Ship to)"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Controls.Add(Me.Txt1)
        Me.Panel2.Controls.Add(Me.Label15)
        Me.Panel2.Controls.Add(Me.Label19)
        Me.Panel2.Controls.Add(Me.Acc_Pincode_TXT)
        Me.Panel2.Controls.Add(Me.Label20)
        Me.Panel2.Controls.Add(Me.Panel6)
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.Acc_GST_Type_TXT)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.Acc_GST_TXT)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Acc_State_TXT)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Acc_Address_TXT)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Acc_Mailing_TXT)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Acc_Name_TXT)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(2, 2)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(455, 311)
        Me.Panel2.TabIndex = 2
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(165, 206)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(11, 16)
        Me.Label14.TabIndex = 28
        Me.Label14.Text = ":"
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
        Me.Txt1.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Txt1.Font_Size = 11
        Me.Txt1.Font_Style = System.Drawing.FontStyle.Bold
        Me.Txt1.Format_ = "dd-MM-yyyy"
        Me.Txt1.Keydown_Support = True
        Me.Txt1.Location = New System.Drawing.Point(182, 207)
        Me.Txt1.Msg_Object = Nothing
        Me.Txt1.Name = "Txt1"
        Me.Txt1.Select_Auto_Show = True
        Me.Txt1.Select_Column_Color = "NA"
        Me.Txt1.Select_Columns = 0
        Me.Txt1.Select_Filter = "(Country_Name LIKE '%<value>%')"
        Me.Txt1.Select_Hide_Columns = "NA"
        Me.Txt1.Select_Object = Nothing
        Me.Txt1.Select_Source = Me.Country_Source
        Me.Txt1.Size = New System.Drawing.Size(263, 15)
        Me.Txt1.TabIndex = 4
        Me.Txt1.Type_ = "Select"
        Me.Txt1.Val_max = 1000000000
        Me.Txt1.Val_min = 0
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(10, 206)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(52, 16)
        Me.Label15.TabIndex = 27
        Me.Label15.Text = "Country"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(165, 228)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(11, 16)
        Me.Label19.TabIndex = 25
        Me.Label19.Text = ":"
        '
        'Acc_Pincode_TXT
        '
        Me.Acc_Pincode_TXT.Auto_Cleane = True
        Me.Acc_Pincode_TXT.Back_color = System.Drawing.Color.White
        Me.Acc_Pincode_TXT.BackColor = System.Drawing.Color.White
        Me.Acc_Pincode_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Acc_Pincode_TXT.Data_Link_ = ""
        Me.Acc_Pincode_TXT.Decimal_ = 2
        Me.Acc_Pincode_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Acc_Pincode_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Acc_Pincode_TXT.Font_Size = 11
        Me.Acc_Pincode_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Acc_Pincode_TXT.Format_ = "dd-MM-yyyy"
        Me.Acc_Pincode_TXT.Keydown_Support = True
        Me.Acc_Pincode_TXT.Location = New System.Drawing.Point(182, 228)
        Me.Acc_Pincode_TXT.MaxLength = 6
        Me.Acc_Pincode_TXT.Msg_Object = Nothing
        Me.Acc_Pincode_TXT.Name = "Acc_Pincode_TXT"
        Me.Acc_Pincode_TXT.Select_Auto_Show = True
        Me.Acc_Pincode_TXT.Select_Column_Color = "NA"
        Me.Acc_Pincode_TXT.Select_Columns = 0
        Me.Acc_Pincode_TXT.Select_Filter = "(Name LIKE '%<value>%')"
        Me.Acc_Pincode_TXT.Select_Hide_Columns = "NA"
        Me.Acc_Pincode_TXT.Select_Object = Nothing
        Me.Acc_Pincode_TXT.Select_Source = Me.State_Source
        Me.Acc_Pincode_TXT.Size = New System.Drawing.Size(58, 15)
        Me.Acc_Pincode_TXT.TabIndex = 5
        Me.Acc_Pincode_TXT.Type_ = "Select"
        Me.Acc_Pincode_TXT.Val_max = 1000000000
        Me.Acc_Pincode_TXT.Val_min = 0
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(10, 228)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(54, 16)
        Me.Label20.TabIndex = 24
        Me.Label20.Text = "Pincode"
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Silver
        Me.Panel6.Location = New System.Drawing.Point(13, 174)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(432, 1)
        Me.Panel6.TabIndex = 22
        '
        'Label17
        '
        Me.Label17.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.DimGray
        Me.Label17.Location = New System.Drawing.Point(0, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(455, 15)
        Me.Label17.TabIndex = 21
        Me.Label17.Text = "Buyer (Bill to)"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(165, 264)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(11, 16)
        Me.Label12.TabIndex = 20
        Me.Label12.Text = ":"
        '
        'Acc_GST_Type_TXT
        '
        Me.Acc_GST_Type_TXT.Auto_Cleane = True
        Me.Acc_GST_Type_TXT.Back_color = System.Drawing.Color.White
        Me.Acc_GST_Type_TXT.BackColor = System.Drawing.Color.White
        Me.Acc_GST_Type_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Acc_GST_Type_TXT.Data_Link_ = ""
        Me.Acc_GST_Type_TXT.Decimal_ = 2
        Me.Acc_GST_Type_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Acc_GST_Type_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Acc_GST_Type_TXT.Font_Size = 11
        Me.Acc_GST_Type_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Acc_GST_Type_TXT.Format_ = "dd-MM-yyyy"
        Me.Acc_GST_Type_TXT.Keydown_Support = True
        Me.Acc_GST_Type_TXT.Location = New System.Drawing.Point(182, 264)
        Me.Acc_GST_Type_TXT.Msg_Object = Nothing
        Me.Acc_GST_Type_TXT.Name = "Acc_GST_Type_TXT"
        Me.Acc_GST_Type_TXT.ReadOnly = True
        Me.Acc_GST_Type_TXT.Select_Auto_Show = True
        Me.Acc_GST_Type_TXT.Select_Column_Color = "NA"
        Me.Acc_GST_Type_TXT.Select_Columns = 0
        Me.Acc_GST_Type_TXT.Select_Filter = " "
        Me.Acc_GST_Type_TXT.Select_Hide_Columns = "NA"
        Me.Acc_GST_Type_TXT.Select_Object = Nothing
        Me.Acc_GST_Type_TXT.Select_Source = Me.GST_Type_Source
        Me.Acc_GST_Type_TXT.Size = New System.Drawing.Size(122, 15)
        Me.Acc_GST_Type_TXT.TabIndex = 6
        Me.Acc_GST_Type_TXT.Type_ = "Select"
        Me.Acc_GST_Type_TXT.Val_max = 1000000000
        Me.Acc_GST_Type_TXT.Val_min = 0
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(10, 264)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(135, 16)
        Me.Label13.TabIndex = 18
        Me.Label13.Text = "GST Registration type"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(165, 285)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(11, 16)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = ":"
        '
        'Acc_GST_TXT
        '
        Me.Acc_GST_TXT.Auto_Cleane = True
        Me.Acc_GST_TXT.Back_color = System.Drawing.Color.White
        Me.Acc_GST_TXT.BackColor = System.Drawing.Color.White
        Me.Acc_GST_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Acc_GST_TXT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Acc_GST_TXT.Data_Link_ = ""
        Me.Acc_GST_TXT.Decimal_ = 2
        Me.Acc_GST_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Acc_GST_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Acc_GST_TXT.Font_Size = 11
        Me.Acc_GST_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Acc_GST_TXT.Format_ = "dd-MM-yyyy"
        Me.Acc_GST_TXT.Keydown_Support = True
        Me.Acc_GST_TXT.Location = New System.Drawing.Point(182, 285)
        Me.Acc_GST_TXT.Msg_Object = Nothing
        Me.Acc_GST_TXT.Name = "Acc_GST_TXT"
        Me.Acc_GST_TXT.Select_Auto_Show = True
        Me.Acc_GST_TXT.Select_Column_Color = "NA"
        Me.Acc_GST_TXT.Select_Columns = 0
        Me.Acc_GST_TXT.Select_Filter = Nothing
        Me.Acc_GST_TXT.Select_Hide_Columns = "NA"
        Me.Acc_GST_TXT.Select_Object = Nothing
        Me.Acc_GST_TXT.Select_Source = Nothing
        Me.Acc_GST_TXT.Size = New System.Drawing.Size(263, 15)
        Me.Acc_GST_TXT.TabIndex = 7
        Me.Acc_GST_TXT.Type_ = "TXT"
        Me.Acc_GST_TXT.Val_max = 1000000000
        Me.Acc_GST_TXT.Val_min = 0
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(10, 285)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 16)
        Me.Label11.TabIndex = 15
        Me.Label11.Text = "GSTIN/UIN"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(165, 185)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(11, 16)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = ":"
        '
        'Acc_State_TXT
        '
        Me.Acc_State_TXT.Auto_Cleane = True
        Me.Acc_State_TXT.Back_color = System.Drawing.Color.White
        Me.Acc_State_TXT.BackColor = System.Drawing.Color.White
        Me.Acc_State_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Acc_State_TXT.Data_Link_ = ""
        Me.Acc_State_TXT.Decimal_ = 2
        Me.Acc_State_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Acc_State_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Acc_State_TXT.Font_Size = 11
        Me.Acc_State_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Acc_State_TXT.Format_ = "dd-MM-yyyy"
        Me.Acc_State_TXT.Keydown_Support = True
        Me.Acc_State_TXT.Location = New System.Drawing.Point(182, 185)
        Me.Acc_State_TXT.Msg_Object = Nothing
        Me.Acc_State_TXT.Name = "Acc_State_TXT"
        Me.Acc_State_TXT.Select_Auto_Show = True
        Me.Acc_State_TXT.Select_Column_Color = "NA"
        Me.Acc_State_TXT.Select_Columns = 0
        Me.Acc_State_TXT.Select_Filter = "(Name LIKE '%<value>%')"
        Me.Acc_State_TXT.Select_Hide_Columns = "NA"
        Me.Acc_State_TXT.Select_Object = Nothing
        Me.Acc_State_TXT.Select_Source = Me.State_Source
        Me.Acc_State_TXT.Size = New System.Drawing.Size(263, 15)
        Me.Acc_State_TXT.TabIndex = 3
        Me.Acc_State_TXT.Type_ = "Select"
        Me.Acc_State_TXT.Val_max = 1000000000
        Me.Acc_State_TXT.Val_min = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(10, 185)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(38, 16)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "State"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(165, 67)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(11, 16)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = ":"
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
        Me.Acc_Address_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Acc_Address_TXT.Font_Size = 11
        Me.Acc_Address_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Acc_Address_TXT.Format_ = "dd-MM-yyyy"
        Me.Acc_Address_TXT.Keydown_Support = True
        Me.Acc_Address_TXT.Location = New System.Drawing.Point(13, 86)
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
        Me.Acc_Address_TXT.Size = New System.Drawing.Size(432, 83)
        Me.Acc_Address_TXT.TabIndex = 2
        Me.Acc_Address_TXT.Type_ = "TXT"
        Me.Acc_Address_TXT.Val_max = 1000000000
        Me.Acc_Address_TXT.Val_min = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(10, 67)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 16)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Address"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(165, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(11, 16)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = ":"
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
        Me.Acc_Mailing_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Acc_Mailing_TXT.Font_Size = 11
        Me.Acc_Mailing_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Acc_Mailing_TXT.Format_ = "dd-MM-yyyy"
        Me.Acc_Mailing_TXT.Keydown_Support = True
        Me.Acc_Mailing_TXT.Location = New System.Drawing.Point(182, 47)
        Me.Acc_Mailing_TXT.Msg_Object = Nothing
        Me.Acc_Mailing_TXT.Name = "Acc_Mailing_TXT"
        Me.Acc_Mailing_TXT.Select_Auto_Show = True
        Me.Acc_Mailing_TXT.Select_Column_Color = "NA"
        Me.Acc_Mailing_TXT.Select_Columns = 0
        Me.Acc_Mailing_TXT.Select_Filter = Nothing
        Me.Acc_Mailing_TXT.Select_Hide_Columns = "NA"
        Me.Acc_Mailing_TXT.Select_Object = Nothing
        Me.Acc_Mailing_TXT.Select_Source = Nothing
        Me.Acc_Mailing_TXT.Size = New System.Drawing.Size(263, 15)
        Me.Acc_Mailing_TXT.TabIndex = 1
        Me.Acc_Mailing_TXT.Type_ = "TXT"
        Me.Acc_Mailing_TXT.Val_max = 1000000000
        Me.Acc_Mailing_TXT.Val_min = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(10, 47)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 16)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Mailing Name"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(165, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(11, 16)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = ":"
        '
        'Acc_Name_TXT
        '
        Me.Acc_Name_TXT.Auto_Cleane = True
        Me.Acc_Name_TXT.Back_color = System.Drawing.Color.White
        Me.Acc_Name_TXT.BackColor = System.Drawing.Color.White
        Me.Acc_Name_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Acc_Name_TXT.Data_Link_ = ""
        Me.Acc_Name_TXT.Decimal_ = 2
        Me.Acc_Name_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Acc_Name_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Acc_Name_TXT.Font_Size = 11
        Me.Acc_Name_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Acc_Name_TXT.Format_ = "dd-MM-yyyy"
        Me.Acc_Name_TXT.Keydown_Support = True
        Me.Acc_Name_TXT.Location = New System.Drawing.Point(182, 27)
        Me.Acc_Name_TXT.Msg_Object = Nothing
        Me.Acc_Name_TXT.Name = "Acc_Name_TXT"
        Me.Acc_Name_TXT.Select_Auto_Show = True
        Me.Acc_Name_TXT.Select_Column_Color = "NA"
        Me.Acc_Name_TXT.Select_Columns = 0
        Me.Acc_Name_TXT.Select_Filter = "(Name LIKE '%<value>%') or Alias = 'Create'"
        Me.Acc_Name_TXT.Select_Hide_Columns = "NA"
        Me.Acc_Name_TXT.Select_Object = Nothing
        Me.Acc_Name_TXT.Select_Source = Nothing
        Me.Acc_Name_TXT.Size = New System.Drawing.Size(263, 15)
        Me.Acc_Name_TXT.TabIndex = 0
        Me.Acc_Name_TXT.Type_ = "Select"
        Me.Acc_Name_TXT.Val_max = 1000000000
        Me.Acc_Name_TXT.Val_min = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Buyer (Bill to)"
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(919, 24)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Party Details"
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
        Me.save_txt.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
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
        Me.save_txt.TabIndex = 5
        Me.save_txt.Type_ = "TXT"
        Me.save_txt.Val_max = 1000000000
        Me.save_txt.Val_min = 0
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Chart1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 485)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1286, 220)
        Me.Panel3.TabIndex = 1
        '
        'Chart1
        '
        Me.Chart1.BackColor = System.Drawing.Color.LightYellow
        Me.Chart1.BorderlineColor = System.Drawing.Color.LightYellow
        ChartArea1.AxisX.IsStartedFromZero = False
        ChartArea1.AxisX.LabelAutoFitMaxFontSize = 8
        ChartArea1.AxisX.LogarithmBase = 24.0R
        ChartArea1.AxisX.MajorGrid.Enabled = False
        ChartArea1.AxisX.MajorTickMark.Enabled = False
        ChartArea1.AxisX.MajorTickMark.TickMarkStyle = System.Windows.Forms.DataVisualization.Charting.TickMarkStyle.InsideArea
        ChartArea1.AxisY.MajorGrid.Enabled = False
        ChartArea1.BackColor = System.Drawing.Color.LightYellow
        ChartArea1.IsSameFontSizeForAllAxes = True
        ChartArea1.Name = "ChartArea1"
        ChartArea1.Position.Auto = False
        ChartArea1.Position.Height = 99.0!
        ChartArea1.Position.Width = 93.0!
        ChartArea1.Position.X = 1.0!
        ChartArea1.Position.Y = 1.0!
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Me.Chart1.Dock = System.Windows.Forms.DockStyle.Fill
        Legend1.BackColor = System.Drawing.Color.LightYellow
        Legend1.Name = "Legend1"
        Legend1.Position.Auto = False
        Legend1.Position.Height = 17.0!
        Legend1.Position.Width = 8.0!
        Legend1.Position.X = 92.0!
        Legend1.Position.Y = 4.0!
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(0, 0)
        Me.Chart1.Name = "Chart1"
        Series1.ChartArea = "ChartArea1"
        Series1.Color = System.Drawing.Color.Blue
        Series1.IsValueShownAsLabel = True
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Series2.ChartArea = "ChartArea1"
        Series2.Color = System.Drawing.Color.Red
        Series2.Legend = "Legend1"
        Series2.Name = "Series2"
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Series.Add(Series2)
        Me.Chart1.Size = New System.Drawing.Size(1286, 220)
        Me.Chart1.TabIndex = 4
        Me.Chart1.Text = "Chart1"
        '
        'VC_Account_Details
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightYellow
        Me.ClientSize = New System.Drawing.Size(1286, 705)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "VC_Account_Details"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Account Details"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.Country_Source, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.State_Source, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GST_Type_Source, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.Account_Source, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Account_Source01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Acc_Name_TXT As Tools.TXT
    Friend WithEvents Label3 As Label
    Friend WithEvents Account_Source As BindingSource
    Friend WithEvents Account_Source01 As BindingSource
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Label12 As Label
    Friend WithEvents Acc_GST_Type_TXT As Tools.TXT
    Friend WithEvents Label13 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Acc_GST_TXT As Tools.TXT
    Friend WithEvents Label11 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Acc_State_TXT As Tools.TXT
    Friend WithEvents Label9 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Acc_Address_TXT As Tools.TXT
    Friend WithEvents Label7 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Acc_Mailing_TXT As Tools.TXT
    Friend WithEvents Label5 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label18 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Ship_Address_TXT As Tools.TXT
    Friend WithEvents Label26 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents Ship_Mailing_TXT As Tools.TXT
    Friend WithEvents Label28 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents Ship_Name_TXT As Tools.TXT
    Friend WithEvents State_Source As BindingSource
    Friend WithEvents GST_Type_Source As BindingSource
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label19 As Label
    Friend WithEvents Acc_Pincode_TXT As Tools.TXT
    Friend WithEvents Label20 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Ship_Pincode_TXT As Tools.TXT
    Friend WithEvents Label22 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Ship_GST_Type_TXT As Tools.TXT
    Friend WithEvents Label24 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents Ship_GST_TXT As Tools.TXT
    Friend WithEvents Label32 As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents Ship_State_TXT As Tools.TXT
    Friend WithEvents Label34 As Label
    Friend WithEvents save_txt As Tools.TXT
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents Label14 As Label
    Friend WithEvents Txt1 As Tools.TXT
    Friend WithEvents Label15 As Label
    Friend WithEvents Country_Source As BindingSource
    Friend WithEvents Label16 As Label
    Friend WithEvents Txt2 As Tools.TXT
    Friend WithEvents Label35 As Label
End Class
