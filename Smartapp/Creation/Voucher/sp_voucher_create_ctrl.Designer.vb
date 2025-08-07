<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class sp_voucher_create_ctrl
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
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.UPI_value_p = New System.Windows.Forms.Panel()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.UPI_Value_TXT = New Tools.TXT()
        Me.upi_qr_source = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label10 = New System.Windows.Forms.Label()
        Me.UPI_QR_P = New System.Windows.Forms.Panel()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.UPI_QR_YN = New Tools.YN()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.print_signature_P = New System.Windows.Forms.Panel()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.print_signature_YN = New Tools.YN()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.print_save_P = New System.Windows.Forms.Panel()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.direct_print_YN = New Tools.YN()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.print_head_P = New System.Windows.Forms.Panel()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.print_head_txt = New Tools.TXT()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.print_narration_P = New System.Windows.Forms.Panel()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.print_narration_YN = New Tools.YN()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Print_Stamp_P = New System.Windows.Forms.Panel()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.print_stamp_YN = New Tools.YN()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.item_discription = New Tools.YN()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Stock_Limit_Warning = New Tools.YN()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Credit_Limit_Warning = New Tools.YN()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Alter_acc_details_YN = New Tools.YN()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.Communication_Panel = New System.Windows.Forms.Panel()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Communication_YN = New Tools.YN()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.RoundUP_Panel = New System.Windows.Forms.Panel()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Txt1 = New Tools.TXT()
        Me.Valuation_Source = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Order_YN = New Tools.YN()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Rate_Valuation_Panel = New System.Windows.Forms.Panel()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Rate_Valuation_TXT = New Tools.TXT()
        Me.payment_details_Panel = New System.Windows.Forms.Panel()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.payment_details_YN = New Tools.YN()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.barcode_panel = New System.Windows.Forms.Panel()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.barcode_yn = New Tools.YN()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.transport_P = New System.Windows.Forms.Panel()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.transport_YN = New Tools.YN()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Panel23 = New System.Windows.Forms.Panel()
        Me.ewaybill_p = New System.Windows.Forms.Panel()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.ewayill_YN = New Tools.YN()
        Me.panel500 = New System.Windows.Forms.Label()
        Me.GST_P = New System.Windows.Forms.Panel()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.GST_YN = New Tools.YN()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.duplicate_no_P = New System.Windows.Forms.Panel()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.duplicate_YN = New Tools.YN()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.yn_narration_P = New System.Windows.Forms.Panel()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.narration_YN = New Tools.YN()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.zero_P = New System.Windows.Forms.Panel()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.zero_YN = New Tools.YN()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.term_condition_P = New System.Windows.Forms.Panel()
        Me.Print_Terms_Conditions_txt = New Tools.TXT()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.Print_Path_P = New System.Windows.Forms.Panel()
        Me.print_path_txt = New Tools.TXT()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Print_Provisnoal_P = New System.Windows.Forms.Panel()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.Provisnoal_TXT = New Tools.TXT()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.MRP_P = New System.Windows.Forms.Panel()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.mrp_yn = New Tools.YN()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.print_type_P = New System.Windows.Forms.Panel()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.print_type_txt = New Tools.TXT()
        Me.Prnt_Type_source = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Panel20 = New System.Windows.Forms.Panel()
        Me.Panel21 = New System.Windows.Forms.Panel()
        Me.Panel22 = New System.Windows.Forms.Panel()
        Me.Panel26 = New System.Windows.Forms.Panel()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Discount_YN = New Tools.YN()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.Label73 = New System.Windows.Forms.Label()
        Me.Panel27 = New System.Windows.Forms.Panel()
        Me.G_Panel = New System.Windows.Forms.Panel()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.Panel51 = New System.Windows.Forms.Panel()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.Panel19 = New System.Windows.Forms.Panel()
        Me.Panel25 = New System.Windows.Forms.Panel()
        Me.Panel28 = New System.Windows.Forms.Panel()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.Panel29 = New System.Windows.Forms.Panel()
        Me.Panel41 = New System.Windows.Forms.Panel()
        Me.Panel40 = New System.Windows.Forms.Panel()
        Me.Label89 = New System.Windows.Forms.Label()
        Me.Panel24 = New System.Windows.Forms.Panel()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.round_up_source = New System.Windows.Forms.BindingSource(Me.components)
        Me.provinoal_source = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel12.SuspendLayout()
        Me.UPI_value_p.SuspendLayout()
        CType(Me.upi_qr_source, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UPI_QR_P.SuspendLayout()
        Me.print_signature_P.SuspendLayout()
        Me.print_save_P.SuspendLayout()
        Me.print_head_P.SuspendLayout()
        Me.print_narration_P.SuspendLayout()
        Me.Print_Stamp_P.SuspendLayout()
        Me.Panel13.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Communication_Panel.SuspendLayout()
        Me.RoundUP_Panel.SuspendLayout()
        CType(Me.Valuation_Source, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel7.SuspendLayout()
        Me.Rate_Valuation_Panel.SuspendLayout()
        Me.payment_details_Panel.SuspendLayout()
        Me.barcode_panel.SuspendLayout()
        Me.transport_P.SuspendLayout()
        Me.Panel23.SuspendLayout()
        Me.ewaybill_p.SuspendLayout()
        Me.GST_P.SuspendLayout()
        Me.duplicate_no_P.SuspendLayout()
        Me.yn_narration_P.SuspendLayout()
        Me.zero_P.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.term_condition_P.SuspendLayout()
        Me.Panel14.SuspendLayout()
        Me.Print_Path_P.SuspendLayout()
        Me.Print_Provisnoal_P.SuspendLayout()
        Me.MRP_P.SuspendLayout()
        Me.print_type_P.SuspendLayout()
        CType(Me.Prnt_Type_source, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel21.SuspendLayout()
        Me.Panel22.SuspendLayout()
        Me.Panel26.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.G_Panel.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.Panel25.SuspendLayout()
        Me.Panel40.SuspendLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.round_up_source, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.provinoal_source, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel12
        '
        Me.Panel12.AutoSize = True
        Me.Panel12.Controls.Add(Me.UPI_value_p)
        Me.Panel12.Controls.Add(Me.UPI_QR_P)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel12.Location = New System.Drawing.Point(0, 188)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(327, 49)
        Me.Panel12.TabIndex = 7
        '
        'UPI_value_p
        '
        Me.UPI_value_p.AutoSize = True
        Me.UPI_value_p.Controls.Add(Me.Label49)
        Me.UPI_value_p.Controls.Add(Me.UPI_Value_TXT)
        Me.UPI_value_p.Controls.Add(Me.Label10)
        Me.UPI_value_p.Dock = System.Windows.Forms.DockStyle.Top
        Me.UPI_value_p.Location = New System.Drawing.Point(0, 25)
        Me.UPI_value_p.Name = "UPI_value_p"
        Me.UPI_value_p.Size = New System.Drawing.Size(327, 24)
        Me.UPI_value_p.TabIndex = 1
        Me.UPI_value_p.Visible = False
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.Location = New System.Drawing.Point(169, 1)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(25, 19)
        Me.Label49.TabIndex = 107
        Me.Label49.Text = " : "
        '
        'UPI_Value_TXT
        '
        Me.UPI_Value_TXT.Auto_Cleane = True
        Me.UPI_Value_TXT.Back_color = System.Drawing.Color.White
        Me.UPI_Value_TXT.BackColor = System.Drawing.Color.White
        Me.UPI_Value_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.UPI_Value_TXT.Data_Link_ = ""
        Me.UPI_Value_TXT.Decimal_ = 2
        Me.UPI_Value_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UPI_Value_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.UPI_Value_TXT.Font_Size = 11
        Me.UPI_Value_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.UPI_Value_TXT.Format_ = "dd-MM-yyyy"
        Me.UPI_Value_TXT.Keydown_Support = True
        Me.UPI_Value_TXT.Location = New System.Drawing.Point(194, 2)
        Me.UPI_Value_TXT.Msg_Object = Nothing
        Me.UPI_Value_TXT.Name = "UPI_Value_TXT"
        Me.UPI_Value_TXT.Select_Auto_Show = True
        Me.UPI_Value_TXT.Select_Column_Color = "NA"
        Me.UPI_Value_TXT.Select_Columns = 0
        Me.UPI_Value_TXT.Select_Filter = " "
        Me.UPI_Value_TXT.Select_Hide_Columns = "NA"
        Me.UPI_Value_TXT.Select_Object = Nothing
        Me.UPI_Value_TXT.Select_Source = Me.upi_qr_source
        Me.UPI_Value_TXT.Size = New System.Drawing.Size(126, 19)
        Me.UPI_Value_TXT.TabIndex = 89
        Me.UPI_Value_TXT.Type_ = "Select"
        Me.UPI_Value_TXT.Val_max = 1000000000
        Me.UPI_Value_TXT.Val_min = 0
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(31, 1)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 20)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "QR Value"
        '
        'UPI_QR_P
        '
        Me.UPI_QR_P.AutoSize = True
        Me.UPI_QR_P.Controls.Add(Me.Label45)
        Me.UPI_QR_P.Controls.Add(Me.UPI_QR_YN)
        Me.UPI_QR_P.Controls.Add(Me.Label9)
        Me.UPI_QR_P.Dock = System.Windows.Forms.DockStyle.Top
        Me.UPI_QR_P.Location = New System.Drawing.Point(0, 0)
        Me.UPI_QR_P.Name = "UPI_QR_P"
        Me.UPI_QR_P.Size = New System.Drawing.Size(327, 25)
        Me.UPI_QR_P.TabIndex = 0
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.Location = New System.Drawing.Point(252, 2)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(25, 19)
        Me.Label45.TabIndex = 105
        Me.Label45.Text = " : "
        '
        'UPI_QR_YN
        '
        Me.UPI_QR_YN.Back_color = System.Drawing.Color.White
        Me.UPI_QR_YN.BackColor = System.Drawing.Color.White
        Me.UPI_QR_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.UPI_QR_YN.Data_Link_ = ""
        Me.UPI_QR_YN.Defolt_ = "No"
        Me.UPI_QR_YN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UPI_QR_YN.Font_ = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.UPI_QR_YN.Location = New System.Drawing.Point(278, 3)
        Me.UPI_QR_YN.Name = "UPI_QR_YN"
        Me.UPI_QR_YN.ReadOnly = True
        Me.UPI_QR_YN.Size = New System.Drawing.Size(42, 19)
        Me.UPI_QR_YN.TabIndex = 103
        Me.UPI_QR_YN.Text = "No"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label9.Location = New System.Drawing.Point(18, 3)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(177, 19)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "UPI Payment QR Code"
        '
        'print_signature_P
        '
        Me.print_signature_P.AutoSize = True
        Me.print_signature_P.Controls.Add(Me.Label43)
        Me.print_signature_P.Controls.Add(Me.print_signature_YN)
        Me.print_signature_P.Controls.Add(Me.Label7)
        Me.print_signature_P.Dock = System.Windows.Forms.DockStyle.Top
        Me.print_signature_P.Location = New System.Drawing.Point(0, 138)
        Me.print_signature_P.Name = "print_signature_P"
        Me.print_signature_P.Size = New System.Drawing.Size(327, 25)
        Me.print_signature_P.TabIndex = 5
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.Location = New System.Drawing.Point(252, 2)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(25, 19)
        Me.Label43.TabIndex = 105
        Me.Label43.Text = " : "
        '
        'print_signature_YN
        '
        Me.print_signature_YN.Back_color = System.Drawing.Color.White
        Me.print_signature_YN.BackColor = System.Drawing.Color.White
        Me.print_signature_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.print_signature_YN.Data_Link_ = ""
        Me.print_signature_YN.Defolt_ = "No"
        Me.print_signature_YN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.print_signature_YN.Font_ = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.print_signature_YN.Location = New System.Drawing.Point(278, 3)
        Me.print_signature_YN.Name = "print_signature_YN"
        Me.print_signature_YN.ReadOnly = True
        Me.print_signature_YN.Size = New System.Drawing.Size(42, 19)
        Me.print_signature_YN.TabIndex = 103
        Me.print_signature_YN.Text = "No"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label7.Location = New System.Drawing.Point(18, 3)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(115, 19)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Print signature"
        '
        'print_save_P
        '
        Me.print_save_P.AutoSize = True
        Me.print_save_P.Controls.Add(Me.Label40)
        Me.print_save_P.Controls.Add(Me.direct_print_YN)
        Me.print_save_P.Controls.Add(Me.Label4)
        Me.print_save_P.Dock = System.Windows.Forms.DockStyle.Top
        Me.print_save_P.Location = New System.Drawing.Point(0, 15)
        Me.print_save_P.Name = "print_save_P"
        Me.print_save_P.Size = New System.Drawing.Size(327, 25)
        Me.print_save_P.TabIndex = 0
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(252, 2)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(25, 19)
        Me.Label40.TabIndex = 105
        Me.Label40.Text = " : "
        '
        'direct_print_YN
        '
        Me.direct_print_YN.Back_color = System.Drawing.Color.White
        Me.direct_print_YN.BackColor = System.Drawing.Color.White
        Me.direct_print_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.direct_print_YN.Data_Link_ = ""
        Me.direct_print_YN.Defolt_ = "No"
        Me.direct_print_YN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.direct_print_YN.Font_ = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.direct_print_YN.Location = New System.Drawing.Point(278, 3)
        Me.direct_print_YN.Name = "direct_print_YN"
        Me.direct_print_YN.ReadOnly = True
        Me.direct_print_YN.Size = New System.Drawing.Size(42, 19)
        Me.direct_print_YN.TabIndex = 103
        Me.direct_print_YN.Text = "No"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label4.Location = New System.Drawing.Point(18, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(195, 19)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Print voucher after saving"
        '
        'print_head_P
        '
        Me.print_head_P.AutoSize = True
        Me.print_head_P.Controls.Add(Me.Label47)
        Me.print_head_P.Controls.Add(Me.print_head_txt)
        Me.print_head_P.Controls.Add(Me.Label3)
        Me.print_head_P.Dock = System.Windows.Forms.DockStyle.Top
        Me.print_head_P.Location = New System.Drawing.Point(0, 40)
        Me.print_head_P.Name = "print_head_P"
        Me.print_head_P.Size = New System.Drawing.Size(327, 24)
        Me.print_head_P.TabIndex = 1
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.Location = New System.Drawing.Point(169, 3)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(25, 19)
        Me.Label47.TabIndex = 106
        Me.Label47.Text = " : "
        '
        'print_head_txt
        '
        Me.print_head_txt.Auto_Cleane = True
        Me.print_head_txt.Back_color = System.Drawing.Color.White
        Me.print_head_txt.BackColor = System.Drawing.Color.White
        Me.print_head_txt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.print_head_txt.Data_Link_ = ""
        Me.print_head_txt.Decimal_ = 2
        Me.print_head_txt.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.print_head_txt.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.print_head_txt.Font_Size = 11
        Me.print_head_txt.Font_Style = System.Drawing.FontStyle.Bold
        Me.print_head_txt.Format_ = "dd-MM-yyyy"
        Me.print_head_txt.Keydown_Support = True
        Me.print_head_txt.Location = New System.Drawing.Point(194, 2)
        Me.print_head_txt.Msg_Object = Nothing
        Me.print_head_txt.Name = "print_head_txt"
        Me.print_head_txt.Select_Auto_Show = True
        Me.print_head_txt.Select_Column_Color = "NA"
        Me.print_head_txt.Select_Columns = 0
        Me.print_head_txt.Select_Filter = Nothing
        Me.print_head_txt.Select_Hide_Columns = "NA"
        Me.print_head_txt.Select_Object = Nothing
        Me.print_head_txt.Select_Source = Nothing
        Me.print_head_txt.Size = New System.Drawing.Size(126, 19)
        Me.print_head_txt.TabIndex = 88
        Me.print_head_txt.Type_ = "TXT"
        Me.print_head_txt.Val_max = 1000000000
        Me.print_head_txt.Val_min = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label3.Location = New System.Drawing.Point(18, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(156, 19)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Print voucher HEAD"
        '
        'print_narration_P
        '
        Me.print_narration_P.AutoSize = True
        Me.print_narration_P.Controls.Add(Me.Label42)
        Me.print_narration_P.Controls.Add(Me.print_narration_YN)
        Me.print_narration_P.Controls.Add(Me.Label6)
        Me.print_narration_P.Dock = System.Windows.Forms.DockStyle.Top
        Me.print_narration_P.Location = New System.Drawing.Point(0, 113)
        Me.print_narration_P.Name = "print_narration_P"
        Me.print_narration_P.Size = New System.Drawing.Size(327, 25)
        Me.print_narration_P.TabIndex = 4
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(252, 2)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(25, 19)
        Me.Label42.TabIndex = 105
        Me.Label42.Text = " : "
        '
        'print_narration_YN
        '
        Me.print_narration_YN.Back_color = System.Drawing.Color.White
        Me.print_narration_YN.BackColor = System.Drawing.Color.White
        Me.print_narration_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.print_narration_YN.Data_Link_ = ""
        Me.print_narration_YN.Defolt_ = "No"
        Me.print_narration_YN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.print_narration_YN.Font_ = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.print_narration_YN.Location = New System.Drawing.Point(278, 3)
        Me.print_narration_YN.Name = "print_narration_YN"
        Me.print_narration_YN.ReadOnly = True
        Me.print_narration_YN.Size = New System.Drawing.Size(42, 19)
        Me.print_narration_YN.TabIndex = 103
        Me.print_narration_YN.Text = "No"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label6.Location = New System.Drawing.Point(18, 3)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(115, 19)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Print Narration"
        '
        'Print_Stamp_P
        '
        Me.Print_Stamp_P.AutoSize = True
        Me.Print_Stamp_P.Controls.Add(Me.Label44)
        Me.Print_Stamp_P.Controls.Add(Me.print_stamp_YN)
        Me.Print_Stamp_P.Controls.Add(Me.Label8)
        Me.Print_Stamp_P.Dock = System.Windows.Forms.DockStyle.Top
        Me.Print_Stamp_P.Location = New System.Drawing.Point(0, 163)
        Me.Print_Stamp_P.Name = "Print_Stamp_P"
        Me.Print_Stamp_P.Size = New System.Drawing.Size(327, 25)
        Me.Print_Stamp_P.TabIndex = 6
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.Location = New System.Drawing.Point(252, 2)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(25, 19)
        Me.Label44.TabIndex = 105
        Me.Label44.Text = " : "
        '
        'print_stamp_YN
        '
        Me.print_stamp_YN.Back_color = System.Drawing.Color.White
        Me.print_stamp_YN.BackColor = System.Drawing.Color.White
        Me.print_stamp_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.print_stamp_YN.Data_Link_ = ""
        Me.print_stamp_YN.Defolt_ = "No"
        Me.print_stamp_YN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.print_stamp_YN.Font_ = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.print_stamp_YN.Location = New System.Drawing.Point(278, 3)
        Me.print_stamp_YN.Name = "print_stamp_YN"
        Me.print_stamp_YN.ReadOnly = True
        Me.print_stamp_YN.Size = New System.Drawing.Size(42, 19)
        Me.print_stamp_YN.TabIndex = 103
        Me.print_stamp_YN.Text = "No"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label8.Location = New System.Drawing.Point(18, 3)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(163, 19)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Print company stamp"
        '
        'Panel13
        '
        Me.Panel13.AutoSize = True
        Me.Panel13.Controls.Add(Me.Label55)
        Me.Panel13.Controls.Add(Me.item_discription)
        Me.Panel13.Controls.Add(Me.Label56)
        Me.Panel13.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel13.Location = New System.Drawing.Point(0, 18)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(327, 25)
        Me.Panel13.TabIndex = 0
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.Location = New System.Drawing.Point(252, 2)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(25, 19)
        Me.Label55.TabIndex = 106
        Me.Label55.Text = " : "
        '
        'item_discription
        '
        Me.item_discription.Back_color = System.Drawing.Color.White
        Me.item_discription.BackColor = System.Drawing.Color.White
        Me.item_discription.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.item_discription.Data_Link_ = ""
        Me.item_discription.Defolt_ = "No"
        Me.item_discription.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.item_discription.Font_ = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.item_discription.Location = New System.Drawing.Point(278, 3)
        Me.item_discription.Name = "item_discription"
        Me.item_discription.ReadOnly = True
        Me.item_discription.Size = New System.Drawing.Size(42, 19)
        Me.item_discription.TabIndex = 103
        Me.item_discription.Text = "No"
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label56.Location = New System.Drawing.Point(18, 3)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(250, 19)
        Me.Label56.TabIndex = 0
        Me.Label56.Text = "Additional Description Stock Item"
        '
        'Panel10
        '
        Me.Panel10.AutoSize = True
        Me.Panel10.Controls.Add(Me.Label52)
        Me.Panel10.Controls.Add(Me.Stock_Limit_Warning)
        Me.Panel10.Controls.Add(Me.Label53)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel10.Location = New System.Drawing.Point(0, 66)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(327, 25)
        Me.Panel10.TabIndex = 2
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.Location = New System.Drawing.Point(252, 2)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(25, 19)
        Me.Label52.TabIndex = 106
        Me.Label52.Text = " : "
        '
        'Stock_Limit_Warning
        '
        Me.Stock_Limit_Warning.Back_color = System.Drawing.Color.White
        Me.Stock_Limit_Warning.BackColor = System.Drawing.Color.White
        Me.Stock_Limit_Warning.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Stock_Limit_Warning.Data_Link_ = "YN_Account_Details_Alter"
        Me.Stock_Limit_Warning.Defolt_ = "No"
        Me.Stock_Limit_Warning.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Stock_Limit_Warning.Font_ = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Stock_Limit_Warning.Location = New System.Drawing.Point(278, 3)
        Me.Stock_Limit_Warning.Name = "Stock_Limit_Warning"
        Me.Stock_Limit_Warning.ReadOnly = True
        Me.Stock_Limit_Warning.Size = New System.Drawing.Size(42, 19)
        Me.Stock_Limit_Warning.TabIndex = 103
        Me.Stock_Limit_Warning.Text = "No"
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label53.Location = New System.Drawing.Point(18, 3)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(184, 19)
        Me.Label53.TabIndex = 0
        Me.Label53.Text = "Negative Stock Warning"
        Me.Label53.UseMnemonic = False
        '
        'Panel9
        '
        Me.Panel9.AutoSize = True
        Me.Panel9.Controls.Add(Me.Label13)
        Me.Panel9.Controls.Add(Me.Credit_Limit_Warning)
        Me.Panel9.Controls.Add(Me.Label27)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel9.Location = New System.Drawing.Point(0, 217)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(327, 25)
        Me.Panel9.TabIndex = 9
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(252, 2)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(25, 19)
        Me.Label13.TabIndex = 106
        Me.Label13.Text = " : "
        '
        'Credit_Limit_Warning
        '
        Me.Credit_Limit_Warning.Back_color = System.Drawing.Color.White
        Me.Credit_Limit_Warning.BackColor = System.Drawing.Color.White
        Me.Credit_Limit_Warning.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Credit_Limit_Warning.Data_Link_ = "YN_Account_Details_Alter"
        Me.Credit_Limit_Warning.Defolt_ = "No"
        Me.Credit_Limit_Warning.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Credit_Limit_Warning.Font_ = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Credit_Limit_Warning.Location = New System.Drawing.Point(278, 3)
        Me.Credit_Limit_Warning.Name = "Credit_Limit_Warning"
        Me.Credit_Limit_Warning.ReadOnly = True
        Me.Credit_Limit_Warning.Size = New System.Drawing.Size(42, 19)
        Me.Credit_Limit_Warning.TabIndex = 103
        Me.Credit_Limit_Warning.Text = "No"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label27.Location = New System.Drawing.Point(18, 3)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(159, 19)
        Me.Label27.TabIndex = 0
        Me.Label27.Text = "Credit Limit Warning"
        Me.Label27.UseMnemonic = False
        '
        'Panel6
        '
        Me.Panel6.AutoSize = True
        Me.Panel6.Controls.Add(Me.Label50)
        Me.Panel6.Controls.Add(Me.Alter_acc_details_YN)
        Me.Panel6.Controls.Add(Me.Label51)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 166)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(327, 25)
        Me.Panel6.TabIndex = 5
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.Location = New System.Drawing.Point(252, 2)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(25, 19)
        Me.Label50.TabIndex = 106
        Me.Label50.Text = " : "
        '
        'Alter_acc_details_YN
        '
        Me.Alter_acc_details_YN.Back_color = System.Drawing.Color.White
        Me.Alter_acc_details_YN.BackColor = System.Drawing.Color.White
        Me.Alter_acc_details_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Alter_acc_details_YN.Data_Link_ = "YN_Account_Details_Alter"
        Me.Alter_acc_details_YN.Defolt_ = "No"
        Me.Alter_acc_details_YN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Alter_acc_details_YN.Font_ = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Alter_acc_details_YN.Location = New System.Drawing.Point(278, 3)
        Me.Alter_acc_details_YN.Name = "Alter_acc_details_YN"
        Me.Alter_acc_details_YN.ReadOnly = True
        Me.Alter_acc_details_YN.Size = New System.Drawing.Size(42, 19)
        Me.Alter_acc_details_YN.TabIndex = 103
        Me.Alter_acc_details_YN.Text = "No"
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label51.Location = New System.Drawing.Point(18, 3)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(245, 19)
        Me.Label51.TabIndex = 0
        Me.Label51.Text = "Alter Account & Shipping Details"
        Me.Label51.UseMnemonic = False
        '
        'Communication_Panel
        '
        Me.Communication_Panel.AutoSize = True
        Me.Communication_Panel.Controls.Add(Me.Label39)
        Me.Communication_Panel.Controls.Add(Me.Communication_YN)
        Me.Communication_Panel.Controls.Add(Me.Label28)
        Me.Communication_Panel.Dock = System.Windows.Forms.DockStyle.Top
        Me.Communication_Panel.Location = New System.Drawing.Point(0, 93)
        Me.Communication_Panel.Name = "Communication_Panel"
        Me.Communication_Panel.Size = New System.Drawing.Size(327, 26)
        Me.Communication_Panel.TabIndex = 3
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(252, 4)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(25, 19)
        Me.Label39.TabIndex = 107
        Me.Label39.Text = " : "
        '
        'Communication_YN
        '
        Me.Communication_YN.Back_color = System.Drawing.Color.White
        Me.Communication_YN.BackColor = System.Drawing.Color.White
        Me.Communication_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Communication_YN.Data_Link_ = ""
        Me.Communication_YN.Defolt_ = "No"
        Me.Communication_YN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Communication_YN.Font_ = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Communication_YN.Location = New System.Drawing.Point(278, 4)
        Me.Communication_YN.Name = "Communication_YN"
        Me.Communication_YN.ReadOnly = True
        Me.Communication_YN.Size = New System.Drawing.Size(42, 19)
        Me.Communication_YN.TabIndex = 103
        Me.Communication_YN.Text = "No"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(18, 4)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(177, 19)
        Me.Label28.TabIndex = 0
        Me.Label28.Text = "Enable Communication"
        '
        'RoundUP_Panel
        '
        Me.RoundUP_Panel.AutoSize = True
        Me.RoundUP_Panel.Controls.Add(Me.Label37)
        Me.RoundUP_Panel.Controls.Add(Me.Txt1)
        Me.RoundUP_Panel.Controls.Add(Me.Label5)
        Me.RoundUP_Panel.Dock = System.Windows.Forms.DockStyle.Top
        Me.RoundUP_Panel.Location = New System.Drawing.Point(0, 191)
        Me.RoundUP_Panel.Name = "RoundUP_Panel"
        Me.RoundUP_Panel.Size = New System.Drawing.Size(327, 26)
        Me.RoundUP_Panel.TabIndex = 8
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(169, 3)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(25, 19)
        Me.Label37.TabIndex = 106
        Me.Label37.Text = " : "
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
        Me.Txt1.Location = New System.Drawing.Point(194, 4)
        Me.Txt1.Msg_Object = Nothing
        Me.Txt1.Name = "Txt1"
        Me.Txt1.Select_Auto_Show = True
        Me.Txt1.Select_Column_Color = "NA"
        Me.Txt1.Select_Columns = 0
        Me.Txt1.Select_Filter = " "
        Me.Txt1.Select_Hide_Columns = "NA"
        Me.Txt1.Select_Object = Nothing
        Me.Txt1.Select_Source = Me.Valuation_Source
        Me.Txt1.Size = New System.Drawing.Size(126, 19)
        Me.Txt1.TabIndex = 90
        Me.Txt1.Text = "Not Applicable"
        Me.Txt1.Type_ = "Select"
        Me.Txt1.Val_max = 1000000000
        Me.Txt1.Val_min = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label5.Location = New System.Drawing.Point(18, 3)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(141, 19)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Amount Round Up"
        '
        'Panel7
        '
        Me.Panel7.AutoSize = True
        Me.Panel7.Controls.Add(Me.Label36)
        Me.Panel7.Controls.Add(Me.Order_YN)
        Me.Panel7.Controls.Add(Me.Label26)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(0, 92)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(327, 25)
        Me.Panel7.TabIndex = 3
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(252, 2)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(25, 19)
        Me.Label36.TabIndex = 106
        Me.Label36.Text = " : "
        '
        'Order_YN
        '
        Me.Order_YN.Back_color = System.Drawing.Color.White
        Me.Order_YN.BackColor = System.Drawing.Color.White
        Me.Order_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Order_YN.Data_Link_ = ""
        Me.Order_YN.Defolt_ = "No"
        Me.Order_YN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Order_YN.Font_ = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Order_YN.Location = New System.Drawing.Point(278, 3)
        Me.Order_YN.Name = "Order_YN"
        Me.Order_YN.ReadOnly = True
        Me.Order_YN.Size = New System.Drawing.Size(42, 19)
        Me.Order_YN.TabIndex = 103
        Me.Order_YN.Text = "No"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label26.Location = New System.Drawing.Point(18, 3)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(144, 19)
        Me.Label26.TabIndex = 0
        Me.Label26.Text = "Allow Order details"
        '
        'Rate_Valuation_Panel
        '
        Me.Rate_Valuation_Panel.AutoSize = True
        Me.Rate_Valuation_Panel.Controls.Add(Me.Label38)
        Me.Rate_Valuation_Panel.Controls.Add(Me.Label24)
        Me.Rate_Valuation_Panel.Controls.Add(Me.Rate_Valuation_TXT)
        Me.Rate_Valuation_Panel.Dock = System.Windows.Forms.DockStyle.Top
        Me.Rate_Valuation_Panel.Location = New System.Drawing.Point(0, 43)
        Me.Rate_Valuation_Panel.Name = "Rate_Valuation_Panel"
        Me.Rate_Valuation_Panel.Size = New System.Drawing.Size(327, 23)
        Me.Rate_Valuation_Panel.TabIndex = 1
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(169, 1)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(25, 19)
        Me.Label38.TabIndex = 107
        Me.Label38.Text = " : "
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label24.Location = New System.Drawing.Point(18, 2)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(113, 19)
        Me.Label24.TabIndex = 90
        Me.Label24.Text = "Rate Valuation"
        '
        'Rate_Valuation_TXT
        '
        Me.Rate_Valuation_TXT.Auto_Cleane = True
        Me.Rate_Valuation_TXT.Back_color = System.Drawing.Color.White
        Me.Rate_Valuation_TXT.BackColor = System.Drawing.Color.White
        Me.Rate_Valuation_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Rate_Valuation_TXT.Data_Link_ = ""
        Me.Rate_Valuation_TXT.Decimal_ = 2
        Me.Rate_Valuation_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rate_Valuation_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Rate_Valuation_TXT.Font_Size = 11
        Me.Rate_Valuation_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Rate_Valuation_TXT.Format_ = "dd-MM-yyyy"
        Me.Rate_Valuation_TXT.Keydown_Support = True
        Me.Rate_Valuation_TXT.Location = New System.Drawing.Point(194, 1)
        Me.Rate_Valuation_TXT.Msg_Object = Nothing
        Me.Rate_Valuation_TXT.Name = "Rate_Valuation_TXT"
        Me.Rate_Valuation_TXT.Select_Auto_Show = True
        Me.Rate_Valuation_TXT.Select_Column_Color = "NA"
        Me.Rate_Valuation_TXT.Select_Columns = 0
        Me.Rate_Valuation_TXT.Select_Filter = " "
        Me.Rate_Valuation_TXT.Select_Hide_Columns = "NA"
        Me.Rate_Valuation_TXT.Select_Object = Nothing
        Me.Rate_Valuation_TXT.Select_Source = Me.Valuation_Source
        Me.Rate_Valuation_TXT.Size = New System.Drawing.Size(126, 19)
        Me.Rate_Valuation_TXT.TabIndex = 89
        Me.Rate_Valuation_TXT.Text = "Default"
        Me.Rate_Valuation_TXT.Type_ = "Select"
        Me.Rate_Valuation_TXT.Val_max = 1000000000
        Me.Rate_Valuation_TXT.Val_min = 0
        '
        'payment_details_Panel
        '
        Me.payment_details_Panel.AutoSize = True
        Me.payment_details_Panel.Controls.Add(Me.Label35)
        Me.payment_details_Panel.Controls.Add(Me.payment_details_YN)
        Me.payment_details_Panel.Controls.Add(Me.Label23)
        Me.payment_details_Panel.Dock = System.Windows.Forms.DockStyle.Top
        Me.payment_details_Panel.Location = New System.Drawing.Point(0, 68)
        Me.payment_details_Panel.Name = "payment_details_Panel"
        Me.payment_details_Panel.Size = New System.Drawing.Size(327, 25)
        Me.payment_details_Panel.TabIndex = 2
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(252, 2)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(25, 19)
        Me.Label35.TabIndex = 106
        Me.Label35.Text = " : "
        '
        'payment_details_YN
        '
        Me.payment_details_YN.Back_color = System.Drawing.Color.White
        Me.payment_details_YN.BackColor = System.Drawing.Color.White
        Me.payment_details_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.payment_details_YN.Data_Link_ = ""
        Me.payment_details_YN.Defolt_ = "No"
        Me.payment_details_YN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.payment_details_YN.Font_ = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.payment_details_YN.Location = New System.Drawing.Point(278, 3)
        Me.payment_details_YN.Name = "payment_details_YN"
        Me.payment_details_YN.ReadOnly = True
        Me.payment_details_YN.Size = New System.Drawing.Size(42, 19)
        Me.payment_details_YN.TabIndex = 103
        Me.payment_details_YN.Text = "No"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label23.Location = New System.Drawing.Point(18, 3)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(127, 19)
        Me.Label23.TabIndex = 0
        Me.Label23.Text = "Payment Details"
        '
        'barcode_panel
        '
        Me.barcode_panel.AutoSize = True
        Me.barcode_panel.Controls.Add(Me.Label34)
        Me.barcode_panel.Controls.Add(Me.barcode_yn)
        Me.barcode_panel.Controls.Add(Me.Label20)
        Me.barcode_panel.Dock = System.Windows.Forms.DockStyle.Top
        Me.barcode_panel.Location = New System.Drawing.Point(0, 43)
        Me.barcode_panel.Name = "barcode_panel"
        Me.barcode_panel.Size = New System.Drawing.Size(327, 25)
        Me.barcode_panel.TabIndex = 1
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(252, 2)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(25, 19)
        Me.Label34.TabIndex = 106
        Me.Label34.Text = " : "
        '
        'barcode_yn
        '
        Me.barcode_yn.Back_color = System.Drawing.Color.White
        Me.barcode_yn.BackColor = System.Drawing.Color.White
        Me.barcode_yn.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.barcode_yn.Data_Link_ = ""
        Me.barcode_yn.Defolt_ = "No"
        Me.barcode_yn.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.barcode_yn.Font_ = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.barcode_yn.Location = New System.Drawing.Point(278, 3)
        Me.barcode_yn.Name = "barcode_yn"
        Me.barcode_yn.ReadOnly = True
        Me.barcode_yn.Size = New System.Drawing.Size(42, 19)
        Me.barcode_yn.TabIndex = 103
        Me.barcode_yn.Text = "No"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label20.Location = New System.Drawing.Point(18, 3)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(115, 19)
        Me.Label20.TabIndex = 0
        Me.Label20.Text = "Using barcode"
        '
        'transport_P
        '
        Me.transport_P.AutoSize = True
        Me.transport_P.Controls.Add(Me.Label33)
        Me.transport_P.Controls.Add(Me.transport_YN)
        Me.transport_P.Controls.Add(Me.Label18)
        Me.transport_P.Dock = System.Windows.Forms.DockStyle.Top
        Me.transport_P.Location = New System.Drawing.Point(0, 18)
        Me.transport_P.Name = "transport_P"
        Me.transport_P.Size = New System.Drawing.Size(327, 25)
        Me.transport_P.TabIndex = 0
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(252, 2)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(25, 19)
        Me.Label33.TabIndex = 106
        Me.Label33.Text = " : "
        '
        'transport_YN
        '
        Me.transport_YN.Back_color = System.Drawing.Color.White
        Me.transport_YN.BackColor = System.Drawing.Color.White
        Me.transport_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.transport_YN.Data_Link_ = ""
        Me.transport_YN.Defolt_ = "No"
        Me.transport_YN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.transport_YN.Font_ = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.transport_YN.Location = New System.Drawing.Point(278, 3)
        Me.transport_YN.Name = "transport_YN"
        Me.transport_YN.ReadOnly = True
        Me.transport_YN.Size = New System.Drawing.Size(42, 19)
        Me.transport_YN.TabIndex = 103
        Me.transport_YN.Text = "No"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label18.Location = New System.Drawing.Point(18, 3)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(166, 19)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "Allow transport details"
        '
        'Panel23
        '
        Me.Panel23.AutoSize = True
        Me.Panel23.Controls.Add(Me.ewaybill_p)
        Me.Panel23.Controls.Add(Me.GST_P)
        Me.Panel23.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel23.Location = New System.Drawing.Point(0, 117)
        Me.Panel23.Name = "Panel23"
        Me.Panel23.Size = New System.Drawing.Size(327, 49)
        Me.Panel23.TabIndex = 4
        '
        'ewaybill_p
        '
        Me.ewaybill_p.AutoSize = True
        Me.ewaybill_p.Controls.Add(Me.Label32)
        Me.ewaybill_p.Controls.Add(Me.ewayill_YN)
        Me.ewaybill_p.Controls.Add(Me.panel500)
        Me.ewaybill_p.Dock = System.Windows.Forms.DockStyle.Top
        Me.ewaybill_p.Location = New System.Drawing.Point(0, 25)
        Me.ewaybill_p.Name = "ewaybill_p"
        Me.ewaybill_p.Size = New System.Drawing.Size(327, 24)
        Me.ewaybill_p.TabIndex = 1
        Me.ewaybill_p.Visible = False
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(252, 2)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(25, 19)
        Me.Label32.TabIndex = 106
        Me.Label32.Text = " : "
        '
        'ewayill_YN
        '
        Me.ewayill_YN.Back_color = System.Drawing.Color.White
        Me.ewayill_YN.BackColor = System.Drawing.Color.White
        Me.ewayill_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ewayill_YN.Data_Link_ = ""
        Me.ewayill_YN.Defolt_ = "No"
        Me.ewayill_YN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ewayill_YN.Font_ = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.ewayill_YN.Location = New System.Drawing.Point(278, 2)
        Me.ewayill_YN.Name = "ewayill_YN"
        Me.ewayill_YN.ReadOnly = True
        Me.ewayill_YN.Size = New System.Drawing.Size(42, 19)
        Me.ewayill_YN.TabIndex = 103
        Me.ewayill_YN.Text = "No"
        '
        'panel500
        '
        Me.panel500.AutoSize = True
        Me.panel500.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panel500.Location = New System.Drawing.Point(35, 3)
        Me.panel500.Name = "panel500"
        Me.panel500.Size = New System.Drawing.Size(122, 20)
        Me.panel500.TabIndex = 0
        Me.panel500.Text = "Allow E-waybill"
        '
        'GST_P
        '
        Me.GST_P.AutoSize = True
        Me.GST_P.Controls.Add(Me.Label31)
        Me.GST_P.Controls.Add(Me.GST_YN)
        Me.GST_P.Controls.Add(Me.Label17)
        Me.GST_P.Dock = System.Windows.Forms.DockStyle.Top
        Me.GST_P.Location = New System.Drawing.Point(0, 0)
        Me.GST_P.Name = "GST_P"
        Me.GST_P.Size = New System.Drawing.Size(327, 25)
        Me.GST_P.TabIndex = 0
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(252, 2)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(25, 19)
        Me.Label31.TabIndex = 106
        Me.Label31.Text = " : "
        '
        'GST_YN
        '
        Me.GST_YN.Back_color = System.Drawing.Color.White
        Me.GST_YN.BackColor = System.Drawing.Color.White
        Me.GST_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GST_YN.Data_Link_ = ""
        Me.GST_YN.Defolt_ = "No"
        Me.GST_YN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GST_YN.Font_ = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GST_YN.Location = New System.Drawing.Point(278, 3)
        Me.GST_YN.Name = "GST_YN"
        Me.GST_YN.ReadOnly = True
        Me.GST_YN.Size = New System.Drawing.Size(42, 19)
        Me.GST_YN.TabIndex = 103
        Me.GST_YN.Text = "No"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label17.Location = New System.Drawing.Point(18, 3)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(275, 19)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "Allow GST (Goods and Services Tax)"
        '
        'duplicate_no_P
        '
        Me.duplicate_no_P.AutoSize = True
        Me.duplicate_no_P.Controls.Add(Me.Label30)
        Me.duplicate_no_P.Controls.Add(Me.duplicate_YN)
        Me.duplicate_no_P.Controls.Add(Me.Label15)
        Me.duplicate_no_P.Dock = System.Windows.Forms.DockStyle.Top
        Me.duplicate_no_P.Location = New System.Drawing.Point(0, 17)
        Me.duplicate_no_P.Name = "duplicate_no_P"
        Me.duplicate_no_P.Size = New System.Drawing.Size(327, 25)
        Me.duplicate_no_P.TabIndex = 0
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(252, 2)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(25, 19)
        Me.Label30.TabIndex = 105
        Me.Label30.Text = " : "
        '
        'duplicate_YN
        '
        Me.duplicate_YN.Back_color = System.Drawing.Color.White
        Me.duplicate_YN.BackColor = System.Drawing.Color.White
        Me.duplicate_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.duplicate_YN.Data_Link_ = ""
        Me.duplicate_YN.Defolt_ = "No"
        Me.duplicate_YN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.duplicate_YN.Font_ = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.duplicate_YN.Location = New System.Drawing.Point(278, 3)
        Me.duplicate_YN.Name = "duplicate_YN"
        Me.duplicate_YN.ReadOnly = True
        Me.duplicate_YN.Size = New System.Drawing.Size(42, 19)
        Me.duplicate_YN.TabIndex = 103
        Me.duplicate_YN.Text = "No"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label15.Location = New System.Drawing.Point(18, 3)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(210, 19)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "Allow Duplicate Voucher No"
        '
        'yn_narration_P
        '
        Me.yn_narration_P.AutoSize = True
        Me.yn_narration_P.Controls.Add(Me.Label29)
        Me.yn_narration_P.Controls.Add(Me.narration_YN)
        Me.yn_narration_P.Controls.Add(Me.Label2)
        Me.yn_narration_P.Dock = System.Windows.Forms.DockStyle.Top
        Me.yn_narration_P.Location = New System.Drawing.Point(0, 42)
        Me.yn_narration_P.Name = "yn_narration_P"
        Me.yn_narration_P.Size = New System.Drawing.Size(327, 25)
        Me.yn_narration_P.TabIndex = 1
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(252, 2)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(25, 19)
        Me.Label29.TabIndex = 105
        Me.Label29.Text = " : "
        '
        'narration_YN
        '
        Me.narration_YN.Back_color = System.Drawing.Color.White
        Me.narration_YN.BackColor = System.Drawing.Color.White
        Me.narration_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.narration_YN.Data_Link_ = ""
        Me.narration_YN.Defolt_ = "No"
        Me.narration_YN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.narration_YN.Font_ = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.narration_YN.Location = New System.Drawing.Point(278, 3)
        Me.narration_YN.Name = "narration_YN"
        Me.narration_YN.ReadOnly = True
        Me.narration_YN.Size = New System.Drawing.Size(42, 19)
        Me.narration_YN.TabIndex = 103
        Me.narration_YN.Text = "Yes"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label2.Location = New System.Drawing.Point(18, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(202, 19)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Allow Narration in Voucher"
        '
        'zero_P
        '
        Me.zero_P.AutoSize = True
        Me.zero_P.Controls.Add(Me.Label19)
        Me.zero_P.Controls.Add(Me.zero_YN)
        Me.zero_P.Controls.Add(Me.Label1)
        Me.zero_P.Dock = System.Windows.Forms.DockStyle.Top
        Me.zero_P.Location = New System.Drawing.Point(0, 67)
        Me.zero_P.Name = "zero_P"
        Me.zero_P.Size = New System.Drawing.Size(327, 25)
        Me.zero_P.TabIndex = 2
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(252, 2)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(25, 19)
        Me.Label19.TabIndex = 104
        Me.Label19.Text = " : "
        '
        'zero_YN
        '
        Me.zero_YN.Back_color = System.Drawing.Color.White
        Me.zero_YN.BackColor = System.Drawing.Color.White
        Me.zero_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.zero_YN.Data_Link_ = ""
        Me.zero_YN.Defolt_ = "No"
        Me.zero_YN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.zero_YN.Font_ = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.zero_YN.Location = New System.Drawing.Point(278, 3)
        Me.zero_YN.Name = "zero_YN"
        Me.zero_YN.ReadOnly = True
        Me.zero_YN.Size = New System.Drawing.Size(42, 19)
        Me.zero_YN.TabIndex = 103
        Me.zero_YN.Text = "No"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label1.Location = New System.Drawing.Point(18, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(236, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Allow Zero-Valued Transactions"
        '
        'Panel4
        '
        Me.Panel4.AutoScroll = True
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.Controls.Add(Me.Panel5)
        Me.Panel4.Controls.Add(Me.Panel20)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel4.Location = New System.Drawing.Point(328, 0)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(328, 703)
        Me.Panel4.TabIndex = 1
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.term_condition_P)
        Me.Panel5.Controls.Add(Me.Panel14)
        Me.Panel5.Controls.Add(Me.Print_Provisnoal_P)
        Me.Panel5.Controls.Add(Me.Panel12)
        Me.Panel5.Controls.Add(Me.Print_Stamp_P)
        Me.Panel5.Controls.Add(Me.print_signature_P)
        Me.Panel5.Controls.Add(Me.print_narration_P)
        Me.Panel5.Controls.Add(Me.MRP_P)
        Me.Panel5.Controls.Add(Me.print_type_P)
        Me.Panel5.Controls.Add(Me.print_head_P)
        Me.Panel5.Controls.Add(Me.print_save_P)
        Me.Panel5.Controls.Add(Me.Panel3)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(327, 389)
        Me.Panel5.TabIndex = 87
        '
        'term_condition_P
        '
        Me.term_condition_P.AutoSize = True
        Me.term_condition_P.Controls.Add(Me.Print_Terms_Conditions_txt)
        Me.term_condition_P.Controls.Add(Me.Label16)
        Me.term_condition_P.Dock = System.Windows.Forms.DockStyle.Top
        Me.term_condition_P.Location = New System.Drawing.Point(0, 285)
        Me.term_condition_P.Name = "term_condition_P"
        Me.term_condition_P.Size = New System.Drawing.Size(327, 69)
        Me.term_condition_P.TabIndex = 10
        '
        'Print_Terms_Conditions_txt
        '
        Me.Print_Terms_Conditions_txt.Auto_Cleane = True
        Me.Print_Terms_Conditions_txt.Back_color = System.Drawing.Color.White
        Me.Print_Terms_Conditions_txt.BackColor = System.Drawing.Color.White
        Me.Print_Terms_Conditions_txt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Print_Terms_Conditions_txt.Data_Link_ = ""
        Me.Print_Terms_Conditions_txt.Decimal_ = 2
        Me.Print_Terms_Conditions_txt.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Print_Terms_Conditions_txt.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Print_Terms_Conditions_txt.Font_Size = 11
        Me.Print_Terms_Conditions_txt.Font_Style = System.Drawing.FontStyle.Bold
        Me.Print_Terms_Conditions_txt.Format_ = "dd-MM-yyyy"
        Me.Print_Terms_Conditions_txt.Keydown_Support = True
        Me.Print_Terms_Conditions_txt.Location = New System.Drawing.Point(18, 20)
        Me.Print_Terms_Conditions_txt.Msg_Object = Nothing
        Me.Print_Terms_Conditions_txt.Multiline = True
        Me.Print_Terms_Conditions_txt.Name = "Print_Terms_Conditions_txt"
        Me.Print_Terms_Conditions_txt.Select_Auto_Show = True
        Me.Print_Terms_Conditions_txt.Select_Column_Color = "NA"
        Me.Print_Terms_Conditions_txt.Select_Columns = 0
        Me.Print_Terms_Conditions_txt.Select_Filter = Nothing
        Me.Print_Terms_Conditions_txt.Select_Hide_Columns = "NA"
        Me.Print_Terms_Conditions_txt.Select_Object = Nothing
        Me.Print_Terms_Conditions_txt.Select_Source = Nothing
        Me.Print_Terms_Conditions_txt.Size = New System.Drawing.Size(292, 46)
        Me.Print_Terms_Conditions_txt.TabIndex = 88
        Me.Print_Terms_Conditions_txt.Type_ = "TXT"
        Me.Print_Terms_Conditions_txt.Val_max = 1000000000
        Me.Print_Terms_Conditions_txt.Val_min = 0
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label16.Location = New System.Drawing.Point(18, 3)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(189, 19)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "Print Terms & Conditions"
        Me.Label16.UseMnemonic = False
        '
        'Panel14
        '
        Me.Panel14.AutoSize = True
        Me.Panel14.Controls.Add(Me.Print_Path_P)
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel14.Location = New System.Drawing.Point(0, 262)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(327, 23)
        Me.Panel14.TabIndex = 9
        '
        'Print_Path_P
        '
        Me.Print_Path_P.AutoSize = True
        Me.Print_Path_P.Controls.Add(Me.print_path_txt)
        Me.Print_Path_P.Controls.Add(Me.Label12)
        Me.Print_Path_P.Dock = System.Windows.Forms.DockStyle.Top
        Me.Print_Path_P.Location = New System.Drawing.Point(0, 0)
        Me.Print_Path_P.Name = "Print_Path_P"
        Me.Print_Path_P.Size = New System.Drawing.Size(327, 23)
        Me.Print_Path_P.TabIndex = 10
        '
        'print_path_txt
        '
        Me.print_path_txt.Auto_Cleane = True
        Me.print_path_txt.Back_color = System.Drawing.Color.White
        Me.print_path_txt.BackColor = System.Drawing.Color.White
        Me.print_path_txt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.print_path_txt.Data_Link_ = ""
        Me.print_path_txt.Decimal_ = 2
        Me.print_path_txt.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.print_path_txt.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.print_path_txt.Font_Size = 11
        Me.print_path_txt.Font_Style = System.Drawing.FontStyle.Bold
        Me.print_path_txt.Format_ = "dd-MM-yyyy"
        Me.print_path_txt.Keydown_Support = True
        Me.print_path_txt.Location = New System.Drawing.Point(102, 1)
        Me.print_path_txt.Msg_Object = Nothing
        Me.print_path_txt.Name = "print_path_txt"
        Me.print_path_txt.Select_Auto_Show = True
        Me.print_path_txt.Select_Column_Color = "NA"
        Me.print_path_txt.Select_Columns = 0
        Me.print_path_txt.Select_Filter = Nothing
        Me.print_path_txt.Select_Hide_Columns = "NA"
        Me.print_path_txt.Select_Object = Nothing
        Me.print_path_txt.Select_Source = Nothing
        Me.print_path_txt.Size = New System.Drawing.Size(218, 19)
        Me.print_path_txt.TabIndex = 89
        Me.print_path_txt.Type_ = "TXT"
        Me.print_path_txt.Val_max = 1000000000
        Me.print_path_txt.Val_min = 0
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label12.Location = New System.Drawing.Point(18, 3)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(79, 19)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Print path"
        '
        'Print_Provisnoal_P
        '
        Me.Print_Provisnoal_P.AutoSize = True
        Me.Print_Provisnoal_P.Controls.Add(Me.Label46)
        Me.Print_Provisnoal_P.Controls.Add(Me.Provisnoal_TXT)
        Me.Print_Provisnoal_P.Controls.Add(Me.Label11)
        Me.Print_Provisnoal_P.Dock = System.Windows.Forms.DockStyle.Top
        Me.Print_Provisnoal_P.Location = New System.Drawing.Point(0, 237)
        Me.Print_Provisnoal_P.Name = "Print_Provisnoal_P"
        Me.Print_Provisnoal_P.Size = New System.Drawing.Size(327, 25)
        Me.Print_Provisnoal_P.TabIndex = 8
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.Location = New System.Drawing.Point(169, 2)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(25, 19)
        Me.Label46.TabIndex = 109
        Me.Label46.Text = " : "
        '
        'Provisnoal_TXT
        '
        Me.Provisnoal_TXT.Auto_Cleane = True
        Me.Provisnoal_TXT.Back_color = System.Drawing.Color.White
        Me.Provisnoal_TXT.BackColor = System.Drawing.Color.White
        Me.Provisnoal_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Provisnoal_TXT.Data_Link_ = ""
        Me.Provisnoal_TXT.Decimal_ = 2
        Me.Provisnoal_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Provisnoal_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Provisnoal_TXT.Font_Size = 11
        Me.Provisnoal_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Provisnoal_TXT.Format_ = "dd-MM-yyyy"
        Me.Provisnoal_TXT.Keydown_Support = True
        Me.Provisnoal_TXT.Location = New System.Drawing.Point(194, 3)
        Me.Provisnoal_TXT.Msg_Object = Nothing
        Me.Provisnoal_TXT.Name = "Provisnoal_TXT"
        Me.Provisnoal_TXT.Select_Auto_Show = True
        Me.Provisnoal_TXT.Select_Column_Color = "NA"
        Me.Provisnoal_TXT.Select_Columns = 0
        Me.Provisnoal_TXT.Select_Filter = " "
        Me.Provisnoal_TXT.Select_Hide_Columns = "NA"
        Me.Provisnoal_TXT.Select_Object = Nothing
        Me.Provisnoal_TXT.Select_Source = Me.upi_qr_source
        Me.Provisnoal_TXT.Size = New System.Drawing.Size(126, 19)
        Me.Provisnoal_TXT.TabIndex = 108
        Me.Provisnoal_TXT.Type_ = "Select"
        Me.Provisnoal_TXT.Val_max = 1000000000
        Me.Provisnoal_TXT.Val_min = 0
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label11.Location = New System.Drawing.Point(18, 3)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(191, 19)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Print Provisional Balance"
        '
        'MRP_P
        '
        Me.MRP_P.AutoSize = True
        Me.MRP_P.Controls.Add(Me.Label41)
        Me.MRP_P.Controls.Add(Me.mrp_yn)
        Me.MRP_P.Controls.Add(Me.Label22)
        Me.MRP_P.Dock = System.Windows.Forms.DockStyle.Top
        Me.MRP_P.Location = New System.Drawing.Point(0, 88)
        Me.MRP_P.Name = "MRP_P"
        Me.MRP_P.Size = New System.Drawing.Size(327, 25)
        Me.MRP_P.TabIndex = 3
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(252, 2)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(25, 19)
        Me.Label41.TabIndex = 105
        Me.Label41.Text = " : "
        '
        'mrp_yn
        '
        Me.mrp_yn.Back_color = System.Drawing.Color.White
        Me.mrp_yn.BackColor = System.Drawing.Color.White
        Me.mrp_yn.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.mrp_yn.Data_Link_ = ""
        Me.mrp_yn.Defolt_ = "No"
        Me.mrp_yn.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mrp_yn.Font_ = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.mrp_yn.Location = New System.Drawing.Point(278, 3)
        Me.mrp_yn.Name = "mrp_yn"
        Me.mrp_yn.ReadOnly = True
        Me.mrp_yn.Size = New System.Drawing.Size(42, 19)
        Me.mrp_yn.TabIndex = 103
        Me.mrp_yn.Text = "No"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label22.Location = New System.Drawing.Point(18, 3)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(131, 19)
        Me.Label22.TabIndex = 0
        Me.Label22.Text = "Print item M.R.P."
        '
        'print_type_P
        '
        Me.print_type_P.AutoSize = True
        Me.print_type_P.Controls.Add(Me.Label48)
        Me.print_type_P.Controls.Add(Me.print_type_txt)
        Me.print_type_P.Controls.Add(Me.Label21)
        Me.print_type_P.Dock = System.Windows.Forms.DockStyle.Top
        Me.print_type_P.Location = New System.Drawing.Point(0, 64)
        Me.print_type_P.Name = "print_type_P"
        Me.print_type_P.Size = New System.Drawing.Size(327, 24)
        Me.print_type_P.TabIndex = 2
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label48.Location = New System.Drawing.Point(169, 3)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(25, 19)
        Me.Label48.TabIndex = 107
        Me.Label48.Text = " : "
        '
        'print_type_txt
        '
        Me.print_type_txt.Auto_Cleane = True
        Me.print_type_txt.Back_color = System.Drawing.Color.White
        Me.print_type_txt.BackColor = System.Drawing.Color.White
        Me.print_type_txt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.print_type_txt.Data_Link_ = ""
        Me.print_type_txt.Decimal_ = 2
        Me.print_type_txt.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.print_type_txt.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.print_type_txt.Font_Size = 11
        Me.print_type_txt.Font_Style = System.Drawing.FontStyle.Bold
        Me.print_type_txt.Format_ = "dd-MM-yyyy"
        Me.print_type_txt.Keydown_Support = True
        Me.print_type_txt.Location = New System.Drawing.Point(194, 2)
        Me.print_type_txt.Msg_Object = Nothing
        Me.print_type_txt.Name = "print_type_txt"
        Me.print_type_txt.Select_Auto_Show = True
        Me.print_type_txt.Select_Column_Color = "NA"
        Me.print_type_txt.Select_Columns = 0
        Me.print_type_txt.Select_Filter = "Name LIKE '%<value>%' or Type = 'Custom'"
        Me.print_type_txt.Select_Hide_Columns = "NA"
        Me.print_type_txt.Select_Object = Nothing
        Me.print_type_txt.Select_Source = Me.Prnt_Type_source
        Me.print_type_txt.Size = New System.Drawing.Size(126, 19)
        Me.print_type_txt.TabIndex = 88
        Me.print_type_txt.Type_ = "Select"
        Me.print_type_txt.Val_max = 1000000000
        Me.print_type_txt.Val_min = 0
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label21.Location = New System.Drawing.Point(18, 3)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(146, 19)
        Me.Label21.TabIndex = 0
        Me.Label21.Text = "Print voucher Type"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label25)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(327, 15)
        Me.Panel3.TabIndex = 103
        '
        'Label25
        '
        Me.Label25.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label25.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(0, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(327, 15)
        Me.Label25.TabIndex = 94
        Me.Label25.Text = "Printing details"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel20
        '
        Me.Panel20.BackColor = System.Drawing.Color.DarkGray
        Me.Panel20.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel20.Location = New System.Drawing.Point(327, 0)
        Me.Panel20.Name = "Panel20"
        Me.Panel20.Size = New System.Drawing.Size(1, 703)
        Me.Panel20.TabIndex = 89
        '
        'Panel21
        '
        Me.Panel21.AutoScroll = True
        Me.Panel21.BackColor = System.Drawing.Color.White
        Me.Panel21.Controls.Add(Me.Panel22)
        Me.Panel21.Controls.Add(Me.Panel51)
        Me.Panel21.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel21.Location = New System.Drawing.Point(0, 0)
        Me.Panel21.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel21.Name = "Panel21"
        Me.Panel21.Size = New System.Drawing.Size(328, 703)
        Me.Panel21.TabIndex = 0
        '
        'Panel22
        '
        Me.Panel22.AutoSize = True
        Me.Panel22.Controls.Add(Me.Panel26)
        Me.Panel22.Controls.Add(Me.Panel2)
        Me.Panel22.Controls.Add(Me.G_Panel)
        Me.Panel22.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel22.Location = New System.Drawing.Point(0, 0)
        Me.Panel22.Name = "Panel22"
        Me.Panel22.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.Panel22.Size = New System.Drawing.Size(327, 517)
        Me.Panel22.TabIndex = 87
        '
        'Panel26
        '
        Me.Panel26.AutoSize = True
        Me.Panel26.Controls.Add(Me.Communication_Panel)
        Me.Panel26.Controls.Add(Me.payment_details_Panel)
        Me.Panel26.Controls.Add(Me.barcode_panel)
        Me.Panel26.Controls.Add(Me.transport_P)
        Me.Panel26.Controls.Add(Me.Label71)
        Me.Panel26.Controls.Add(Me.Panel1)
        Me.Panel26.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel26.Location = New System.Drawing.Point(0, 378)
        Me.Panel26.Name = "Panel26"
        Me.Panel26.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.Panel26.Size = New System.Drawing.Size(327, 129)
        Me.Panel26.TabIndex = 2
        '
        'Label71
        '
        Me.Label71.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label71.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label71.Location = New System.Drawing.Point(0, 1)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(327, 17)
        Me.Label71.TabIndex = 87
        Me.Label71.Text = "Extra Features"
        Me.Label71.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkGray
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(327, 1)
        Me.Panel1.TabIndex = 89
        '
        'Panel2
        '
        Me.Panel2.AutoSize = True
        Me.Panel2.Controls.Add(Me.Panel8)
        Me.Panel2.Controls.Add(Me.Panel10)
        Me.Panel2.Controls.Add(Me.Rate_Valuation_Panel)
        Me.Panel2.Controls.Add(Me.Panel13)
        Me.Panel2.Controls.Add(Me.Label73)
        Me.Panel2.Controls.Add(Me.Panel27)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 252)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.Panel2.Size = New System.Drawing.Size(327, 126)
        Me.Panel2.TabIndex = 1
        '
        'Panel8
        '
        Me.Panel8.AutoSize = True
        Me.Panel8.Controls.Add(Me.Label14)
        Me.Panel8.Controls.Add(Me.Discount_YN)
        Me.Panel8.Controls.Add(Me.Label54)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel8.Location = New System.Drawing.Point(0, 91)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(327, 25)
        Me.Panel8.TabIndex = 90
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(252, 2)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(25, 19)
        Me.Label14.TabIndex = 106
        Me.Label14.Text = " : "
        '
        'Discount_YN
        '
        Me.Discount_YN.Back_color = System.Drawing.Color.White
        Me.Discount_YN.BackColor = System.Drawing.Color.White
        Me.Discount_YN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Discount_YN.Data_Link_ = ""
        Me.Discount_YN.Defolt_ = "No"
        Me.Discount_YN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Discount_YN.Font_ = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Discount_YN.Location = New System.Drawing.Point(278, 3)
        Me.Discount_YN.Name = "Discount_YN"
        Me.Discount_YN.ReadOnly = True
        Me.Discount_YN.Size = New System.Drawing.Size(42, 19)
        Me.Discount_YN.TabIndex = 103
        Me.Discount_YN.Text = "No"
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label54.Location = New System.Drawing.Point(18, 3)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(115, 19)
        Me.Label54.TabIndex = 0
        Me.Label54.Text = "Allow Discount"
        '
        'Label73
        '
        Me.Label73.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label73.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label73.Location = New System.Drawing.Point(0, 1)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(327, 17)
        Me.Label73.TabIndex = 87
        Me.Label73.Text = "Item Details"
        Me.Label73.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel27
        '
        Me.Panel27.BackColor = System.Drawing.Color.DarkGray
        Me.Panel27.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel27.Location = New System.Drawing.Point(0, 0)
        Me.Panel27.Name = "Panel27"
        Me.Panel27.Size = New System.Drawing.Size(327, 1)
        Me.Panel27.TabIndex = 89
        '
        'G_Panel
        '
        Me.G_Panel.AutoSize = True
        Me.G_Panel.Controls.Add(Me.Panel9)
        Me.G_Panel.Controls.Add(Me.RoundUP_Panel)
        Me.G_Panel.Controls.Add(Me.Panel6)
        Me.G_Panel.Controls.Add(Me.Panel23)
        Me.G_Panel.Controls.Add(Me.Panel7)
        Me.G_Panel.Controls.Add(Me.zero_P)
        Me.G_Panel.Controls.Add(Me.yn_narration_P)
        Me.G_Panel.Controls.Add(Me.duplicate_no_P)
        Me.G_Panel.Controls.Add(Me.Label64)
        Me.G_Panel.Dock = System.Windows.Forms.DockStyle.Top
        Me.G_Panel.Location = New System.Drawing.Point(0, 0)
        Me.G_Panel.Name = "G_Panel"
        Me.G_Panel.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.G_Panel.Size = New System.Drawing.Size(327, 252)
        Me.G_Panel.TabIndex = 0
        '
        'Label64
        '
        Me.Label64.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label64.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label64.Location = New System.Drawing.Point(0, 0)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(327, 17)
        Me.Label64.TabIndex = 87
        Me.Label64.Text = "General"
        Me.Label64.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel51
        '
        Me.Panel51.BackColor = System.Drawing.Color.DarkGray
        Me.Panel51.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel51.Location = New System.Drawing.Point(327, 0)
        Me.Panel51.Name = "Panel51"
        Me.Panel51.Size = New System.Drawing.Size(1, 703)
        Me.Panel51.TabIndex = 88
        '
        'Panel11
        '
        Me.Panel11.AutoScroll = True
        Me.Panel11.BackColor = System.Drawing.Color.White
        Me.Panel11.Controls.Add(Me.Panel19)
        Me.Panel11.Controls.Add(Me.Panel25)
        Me.Panel11.Controls.Add(Me.Panel41)
        Me.Panel11.Controls.Add(Me.Panel40)
        Me.Panel11.Controls.Add(Me.Panel24)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel11.Location = New System.Drawing.Point(656, 0)
        Me.Panel11.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(330, 703)
        Me.Panel11.TabIndex = 2
        '
        'Panel19
        '
        Me.Panel19.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel19.Location = New System.Drawing.Point(0, 43)
        Me.Panel19.Name = "Panel19"
        Me.Panel19.Size = New System.Drawing.Size(328, 660)
        Me.Panel19.TabIndex = 87
        '
        'Panel25
        '
        Me.Panel25.Controls.Add(Me.Panel28)
        Me.Panel25.Controls.Add(Me.Label66)
        Me.Panel25.Controls.Add(Me.Label65)
        Me.Panel25.Controls.Add(Me.Panel29)
        Me.Panel25.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel25.Location = New System.Drawing.Point(0, 15)
        Me.Panel25.Name = "Panel25"
        Me.Panel25.Size = New System.Drawing.Size(328, 28)
        Me.Panel25.TabIndex = 106
        '
        'Panel28
        '
        Me.Panel28.BackColor = System.Drawing.Color.LightGray
        Me.Panel28.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel28.Location = New System.Drawing.Point(0, 27)
        Me.Panel28.Name = "Panel28"
        Me.Panel28.Size = New System.Drawing.Size(328, 1)
        Me.Panel28.TabIndex = 107
        '
        'Label66
        '
        Me.Label66.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label66.Location = New System.Drawing.Point(143, 4)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(179, 19)
        Me.Label66.TabIndex = 4
        Me.Label66.Text = "Configuration"
        Me.Label66.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label65.Location = New System.Drawing.Point(6, 4)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(115, 19)
        Me.Label65.TabIndex = 1
        Me.Label65.Text = "Name of Class"
        '
        'Panel29
        '
        Me.Panel29.BackColor = System.Drawing.Color.LightGray
        Me.Panel29.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel29.Location = New System.Drawing.Point(0, 0)
        Me.Panel29.Name = "Panel29"
        Me.Panel29.Size = New System.Drawing.Size(328, 1)
        Me.Panel29.TabIndex = 108
        '
        'Panel41
        '
        Me.Panel41.BackColor = System.Drawing.Color.DarkGray
        Me.Panel41.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel41.Location = New System.Drawing.Point(328, 15)
        Me.Panel41.Name = "Panel41"
        Me.Panel41.Size = New System.Drawing.Size(1, 688)
        Me.Panel41.TabIndex = 89
        '
        'Panel40
        '
        Me.Panel40.Controls.Add(Me.Label89)
        Me.Panel40.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel40.Location = New System.Drawing.Point(0, 0)
        Me.Panel40.Name = "Panel40"
        Me.Panel40.Size = New System.Drawing.Size(329, 15)
        Me.Panel40.TabIndex = 104
        '
        'Label89
        '
        Me.Label89.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label89.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label89.Location = New System.Drawing.Point(0, 0)
        Me.Label89.Name = "Label89"
        Me.Label89.Size = New System.Drawing.Size(329, 15)
        Me.Label89.TabIndex = 94
        Me.Label89.Text = "Class"
        Me.Label89.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel24
        '
        Me.Panel24.BackColor = System.Drawing.Color.DarkGray
        Me.Panel24.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel24.Location = New System.Drawing.Point(329, 0)
        Me.Panel24.Name = "Panel24"
        Me.Panel24.Size = New System.Drawing.Size(1, 703)
        Me.Panel24.TabIndex = 105
        '
        'sp_voucher_create_ctrl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.Panel11)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel21)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "sp_voucher_create_ctrl"
        Me.Size = New System.Drawing.Size(1687, 703)
        Me.Panel12.ResumeLayout(False)
        Me.Panel12.PerformLayout()
        Me.UPI_value_p.ResumeLayout(False)
        Me.UPI_value_p.PerformLayout()
        CType(Me.upi_qr_source, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UPI_QR_P.ResumeLayout(False)
        Me.UPI_QR_P.PerformLayout()
        Me.print_signature_P.ResumeLayout(False)
        Me.print_signature_P.PerformLayout()
        Me.print_save_P.ResumeLayout(False)
        Me.print_save_P.PerformLayout()
        Me.print_head_P.ResumeLayout(False)
        Me.print_head_P.PerformLayout()
        Me.print_narration_P.ResumeLayout(False)
        Me.print_narration_P.PerformLayout()
        Me.Print_Stamp_P.ResumeLayout(False)
        Me.Print_Stamp_P.PerformLayout()
        Me.Panel13.ResumeLayout(False)
        Me.Panel13.PerformLayout()
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Communication_Panel.ResumeLayout(False)
        Me.Communication_Panel.PerformLayout()
        Me.RoundUP_Panel.ResumeLayout(False)
        Me.RoundUP_Panel.PerformLayout()
        CType(Me.Valuation_Source, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Rate_Valuation_Panel.ResumeLayout(False)
        Me.Rate_Valuation_Panel.PerformLayout()
        Me.payment_details_Panel.ResumeLayout(False)
        Me.payment_details_Panel.PerformLayout()
        Me.barcode_panel.ResumeLayout(False)
        Me.barcode_panel.PerformLayout()
        Me.transport_P.ResumeLayout(False)
        Me.transport_P.PerformLayout()
        Me.Panel23.ResumeLayout(False)
        Me.Panel23.PerformLayout()
        Me.ewaybill_p.ResumeLayout(False)
        Me.ewaybill_p.PerformLayout()
        Me.GST_P.ResumeLayout(False)
        Me.GST_P.PerformLayout()
        Me.duplicate_no_P.ResumeLayout(False)
        Me.duplicate_no_P.PerformLayout()
        Me.yn_narration_P.ResumeLayout(False)
        Me.yn_narration_P.PerformLayout()
        Me.zero_P.ResumeLayout(False)
        Me.zero_P.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.term_condition_P.ResumeLayout(False)
        Me.term_condition_P.PerformLayout()
        Me.Panel14.ResumeLayout(False)
        Me.Panel14.PerformLayout()
        Me.Print_Path_P.ResumeLayout(False)
        Me.Print_Path_P.PerformLayout()
        Me.Print_Provisnoal_P.ResumeLayout(False)
        Me.Print_Provisnoal_P.PerformLayout()
        Me.MRP_P.ResumeLayout(False)
        Me.MRP_P.PerformLayout()
        Me.print_type_P.ResumeLayout(False)
        Me.print_type_P.PerformLayout()
        CType(Me.Prnt_Type_source, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel21.ResumeLayout(False)
        Me.Panel21.PerformLayout()
        Me.Panel22.ResumeLayout(False)
        Me.Panel22.PerformLayout()
        Me.Panel26.ResumeLayout(False)
        Me.Panel26.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.G_Panel.ResumeLayout(False)
        Me.G_Panel.PerformLayout()
        Me.Panel11.ResumeLayout(False)
        Me.Panel25.ResumeLayout(False)
        Me.Panel25.PerformLayout()
        Me.Panel40.ResumeLayout(False)
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.round_up_source, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.provinoal_source, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel12 As Panel
    Friend WithEvents UPI_value_p As Panel
    Friend WithEvents UPI_Value_TXT As Tools.TXT
    Friend WithEvents upi_qr_source As BindingSource
    Friend WithEvents Label10 As Label
    Friend WithEvents UPI_QR_P As Panel
    Friend WithEvents UPI_QR_YN As Tools.YN
    Friend WithEvents Label9 As Label
    Friend WithEvents print_signature_P As Panel
    Friend WithEvents print_signature_YN As Tools.YN
    Friend WithEvents Label7 As Label
    Friend WithEvents print_save_P As Panel
    Friend WithEvents direct_print_YN As Tools.YN
    Friend WithEvents Label4 As Label
    Friend WithEvents print_head_P As Panel
    Friend WithEvents print_head_txt As Tools.TXT
    Friend WithEvents Label3 As Label
    Friend WithEvents print_narration_P As Panel
    Friend WithEvents print_narration_YN As Tools.YN
    Friend WithEvents Label6 As Label
    Friend WithEvents Print_Stamp_P As Panel
    Friend WithEvents print_stamp_YN As Tools.YN
    Friend WithEvents Label8 As Label
    Friend WithEvents duplicate_no_P As Panel
    Friend WithEvents duplicate_YN As Tools.YN
    Friend WithEvents Label15 As Label
    Friend WithEvents yn_narration_P As Panel
    Friend WithEvents narration_YN As Tools.YN
    Friend WithEvents Label2 As Label
    Friend WithEvents zero_P As Panel
    Friend WithEvents zero_YN As Tools.YN
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents term_condition_P As Panel
    Friend WithEvents Print_Terms_Conditions_txt As Tools.TXT
    Friend WithEvents Label16 As Label
    Friend WithEvents Panel14 As Panel
    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents Print_Provisnoal_P As Panel
    Friend WithEvents Label11 As Label
    Friend WithEvents GST_P As Panel
    Friend WithEvents GST_YN As Tools.YN
    Friend WithEvents Label17 As Label
    Friend WithEvents Panel23 As Panel
    Friend WithEvents ewaybill_p As Panel
    Friend WithEvents ewayill_YN As Tools.YN
    Friend WithEvents panel500 As Label
    Friend WithEvents transport_P As Panel
    Friend WithEvents transport_YN As Tools.YN
    Friend WithEvents Label18 As Label
    Friend WithEvents print_type_txt As Tools.TXT
    Friend WithEvents Prnt_Type_source As BindingSource
    Friend WithEvents Label21 As Label
    Friend WithEvents MRP_P As Panel
    Friend WithEvents mrp_yn As Tools.YN
    Friend WithEvents Label22 As Label
    Friend WithEvents print_type_P As Panel
    Friend WithEvents barcode_panel As Panel
    Friend WithEvents barcode_yn As Tools.YN
    Friend WithEvents Label20 As Label
    Friend WithEvents payment_details_Panel As Panel
    Friend WithEvents payment_details_YN As Tools.YN
    Friend WithEvents Label23 As Label
    Friend WithEvents Rate_Valuation_Panel As Panel
    Friend WithEvents Label24 As Label
    Friend WithEvents Rate_Valuation_TXT As Tools.TXT
    Friend WithEvents Valuation_Source As BindingSource
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label25 As Label
    Friend WithEvents RoundUP_Panel As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Txt1 As Tools.TXT
    Friend WithEvents round_up_source As BindingSource
    Friend WithEvents Communication_Panel As Panel
    Friend WithEvents Communication_YN As Tools.YN
    Friend WithEvents Label28 As Label
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Order_YN As Tools.YN
    Friend WithEvents Label26 As Label
    Friend WithEvents Label37 As Label
    Friend WithEvents Label36 As Label
    Friend WithEvents Label35 As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label38 As Label
    Friend WithEvents Label39 As Label
    Friend WithEvents Label49 As Label
    Friend WithEvents Label45 As Label
    Friend WithEvents Label43 As Label
    Friend WithEvents Label40 As Label
    Friend WithEvents Label47 As Label
    Friend WithEvents Label42 As Label
    Friend WithEvents Label44 As Label
    Friend WithEvents Label41 As Label
    Friend WithEvents Label48 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label50 As Label
    Friend WithEvents Alter_acc_details_YN As Tools.YN
    Friend WithEvents Label51 As Label
    Friend WithEvents Print_Path_P As Panel
    Friend WithEvents print_path_txt As Tools.TXT
    Friend WithEvents Label12 As Label
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Label13 As Label
    Friend WithEvents Credit_Limit_Warning As Tools.YN
    Friend WithEvents Label27 As Label
    Friend WithEvents Panel10 As Panel
    Friend WithEvents Label52 As Label
    Friend WithEvents Stock_Limit_Warning As Tools.YN
    Friend WithEvents Label53 As Label
    Friend WithEvents Panel13 As Panel
    Friend WithEvents Label55 As Label
    Friend WithEvents item_discription As Tools.YN
    Friend WithEvents Label56 As Label
    Friend WithEvents Panel20 As Panel
    Friend WithEvents Panel21 As Panel
    Friend WithEvents Panel22 As Panel
    Friend WithEvents Panel51 As Panel
    Friend WithEvents G_Panel As Panel
    Friend WithEvents Label64 As Label
    Friend WithEvents Panel26 As Panel
    Friend WithEvents Label71 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label73 As Label
    Friend WithEvents Panel27 As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Label14 As Label
    Friend WithEvents Discount_YN As Tools.YN
    Friend WithEvents Label54 As Label
    Friend WithEvents Label46 As Label
    Friend WithEvents Provisnoal_TXT As Tools.TXT
    Friend WithEvents provinoal_source As BindingSource
    Friend WithEvents Panel11 As Panel
    Friend WithEvents Panel41 As Panel
    Friend WithEvents Panel40 As Panel
    Friend WithEvents Label89 As Label
    Friend WithEvents Panel24 As Panel
    Friend WithEvents Panel25 As Panel
    Friend WithEvents Label65 As Label
    Friend WithEvents Panel28 As Panel
    Friend WithEvents Label66 As Label
    Friend WithEvents Panel29 As Panel
    Public WithEvents Panel19 As Panel
End Class
