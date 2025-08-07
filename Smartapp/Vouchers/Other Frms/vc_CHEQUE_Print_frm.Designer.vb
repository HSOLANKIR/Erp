<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class vc_CHEQUE_Print_frm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(vc_CHEQUE_Print_frm))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Pay_ = New Tools.TXT()
        Me.DATE_TXT = New System.Windows.Forms.Label()
        Me.amt_w1 = New System.Windows.Forms.Label()
        Me.amt_w2 = New System.Windows.Forms.Label()
        Me.Amount_ = New System.Windows.Forms.Label()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PrintDialog2 = New System.Windows.Forms.PrintDialog()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Defolt_Printer_Select = New Tools.TXT()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Yn1 = New Tools.YN()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Printer_Source = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.Printer_Source, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Pay_)
        Me.Panel1.Controls.Add(Me.DATE_TXT)
        Me.Panel1.Controls.Add(Me.amt_w1)
        Me.Panel1.Controls.Add(Me.amt_w2)
        Me.Panel1.Controls.Add(Me.Amount_)
        Me.Panel1.Location = New System.Drawing.Point(17, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(855, 376)
        Me.Panel1.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(248, 26)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(124, 41)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 400004
        Me.PictureBox1.TabStop = False
        '
        'Pay_
        '
        Me.Pay_.Auto_Cleane = True
        Me.Pay_.Back_color = System.Drawing.Color.White
        Me.Pay_.BackColor = System.Drawing.Color.White
        Me.Pay_.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Pay_.Data_Link_ = ""
        Me.Pay_.Decimal_ = 2
        Me.Pay_.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Pay_.Font_ = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Pay_.Font_Size = 10
        Me.Pay_.Font_Style = System.Drawing.FontStyle.Bold
        Me.Pay_.Format_ = "dd-MM-yyyy"
        Me.Pay_.Keydown_Support = True
        Me.Pay_.Location = New System.Drawing.Point(71, 115)
        Me.Pay_.Msg_Object = Nothing
        Me.Pay_.Name = "Pay_"
        Me.Pay_.Select_Auto_Show = True
        Me.Pay_.Select_Column_Color = "NA"
        Me.Pay_.Select_Columns = 0
        Me.Pay_.Select_Filter = Nothing
        Me.Pay_.Select_Hide_Columns = "NA"
        Me.Pay_.Select_Object = Nothing
        Me.Pay_.Select_Source = Nothing
        Me.Pay_.Size = New System.Drawing.Size(761, 22)
        Me.Pay_.TabIndex = 0
        Me.Pay_.Type_ = "TXT"
        Me.Pay_.Val_max = 1000000000
        Me.Pay_.Val_min = 0
        '
        'DATE_TXT
        '
        Me.DATE_TXT.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DATE_TXT.Location = New System.Drawing.Point(649, 51)
        Me.DATE_TXT.Name = "DATE_TXT"
        Me.DATE_TXT.Size = New System.Drawing.Size(183, 16)
        Me.DATE_TXT.TabIndex = 1
        Me.DATE_TXT.Text = "1"
        Me.DATE_TXT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'amt_w1
        '
        Me.amt_w1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.amt_w1.Location = New System.Drawing.Point(158, 162)
        Me.amt_w1.Name = "amt_w1"
        Me.amt_w1.Size = New System.Drawing.Size(674, 21)
        Me.amt_w1.TabIndex = 400002
        Me.amt_w1.Text = "**Ninety Nine Lakh Ninety Nine Thousand Nine Hundred Ninety Nine Only"
        '
        'amt_w2
        '
        Me.amt_w2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.amt_w2.Location = New System.Drawing.Point(26, 206)
        Me.amt_w2.Name = "amt_w2"
        Me.amt_w2.Size = New System.Drawing.Size(462, 21)
        Me.amt_w2.TabIndex = 400003
        '
        'Amount_
        '
        Me.Amount_.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Amount_.Location = New System.Drawing.Point(606, 198)
        Me.Amount_.Name = "Amount_"
        Me.Amount_.Size = New System.Drawing.Size(183, 23)
        Me.Amount_.TabIndex = 400001
        Me.Amount_.Text = "**99,99,999/-"
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'PrintDialog2
        '
        Me.PrintDialog2.UseEXDialog = True
        '
        'PrintDocument1
        '
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.00001!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 493)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1107, 209)
        Me.TableLayoutPanel1.TabIndex = 400001
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.Panel6)
        Me.Panel2.Controls.Add(Me.Panel5)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(356, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(394, 203)
        Me.Panel2.TabIndex = 0
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.MistyRose
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(103, 162)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(90, 31)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Cancel"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.LightYellow
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(200, 162)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(90, 31)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Print"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Defolt_Printer_Select)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel3.Location = New System.Drawing.Point(0, 43)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(392, 18)
        Me.Panel3.TabIndex = 5
        '
        'Defolt_Printer_Select
        '
        Me.Defolt_Printer_Select.Auto_Cleane = True
        Me.Defolt_Printer_Select.Back_color = System.Drawing.Color.White
        Me.Defolt_Printer_Select.BackColor = System.Drawing.Color.White
        Me.Defolt_Printer_Select.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Defolt_Printer_Select.Data_Link_ = "Defolt Printer"
        Me.Defolt_Printer_Select.Decimal_ = 2
        Me.Defolt_Printer_Select.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Defolt_Printer_Select.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Defolt_Printer_Select.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Defolt_Printer_Select.Font_Size = 10
        Me.Defolt_Printer_Select.Font_Style = System.Drawing.FontStyle.Bold
        Me.Defolt_Printer_Select.Format_ = "dd-MM-yyyy"
        Me.Defolt_Printer_Select.Keydown_Support = True
        Me.Defolt_Printer_Select.Location = New System.Drawing.Point(195, 0)
        Me.Defolt_Printer_Select.Msg_Object = Nothing
        Me.Defolt_Printer_Select.Name = "Defolt_Printer_Select"
        Me.Defolt_Printer_Select.Select_Auto_Show = True
        Me.Defolt_Printer_Select.Select_Column_Color = "NA"
        Me.Defolt_Printer_Select.Select_Columns = 0
        Me.Defolt_Printer_Select.Select_Filter = "Name LIKE '%<value>%'"
        Me.Defolt_Printer_Select.Select_Hide_Columns = "NA"
        Me.Defolt_Printer_Select.Select_Object = Nothing
        Me.Defolt_Printer_Select.Select_Source = Nothing
        Me.Defolt_Printer_Select.Size = New System.Drawing.Size(197, 15)
        Me.Defolt_Printer_Select.TabIndex = 10
        Me.Defolt_Printer_Select.Type_ = "Select"
        Me.Defolt_Printer_Select.Val_max = 1000000000
        Me.Defolt_Printer_Select.Val_min = 0
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(180, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(15, 18)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = ":"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.Label2.Size = New System.Drawing.Size(180, 18)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Printer"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.Yn1)
        Me.Panel6.Controls.Add(Me.Label6)
        Me.Panel6.Controls.Add(Me.Label3)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel6.Location = New System.Drawing.Point(0, 25)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(392, 18)
        Me.Panel6.TabIndex = 3
        '
        'Yn1
        '
        Me.Yn1.Back_color = System.Drawing.Color.White
        Me.Yn1.BackColor = System.Drawing.Color.White
        Me.Yn1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Yn1.Data_Link_ = ""
        Me.Yn1.Defolt_ = "No"
        Me.Yn1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Yn1.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Yn1.Font_ = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Yn1.Location = New System.Drawing.Point(195, 0)
        Me.Yn1.Name = "Yn1"
        Me.Yn1.ReadOnly = True
        Me.Yn1.Size = New System.Drawing.Size(47, 16)
        Me.Yn1.TabIndex = 4
        Me.Yn1.Text = "Yes"
        '
        'Label6
        '
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(180, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(15, 18)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = ":"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.Label3.Size = New System.Drawing.Size(180, 18)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Cheque Cross (A/c Payee)"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Label4)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(392, 25)
        Me.Panel5.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(0, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(161, 25)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Configuration"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'vc_CHEQUE_Print_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Beige
        Me.ClientSize = New System.Drawing.Size(1107, 702)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "vc_CHEQUE_Print_frm"
        Me.Text = "vc_CHEQUE_Print_frm"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        CType(Me.Printer_Source, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents DATE_TXT As Label
    Friend WithEvents Amount_ As Label
    Friend WithEvents amt_w2 As Label
    Friend WithEvents amt_w1 As Label
    Friend WithEvents PrintPreviewDialog1 As PrintPreviewDialog
    Friend WithEvents PrintDialog2 As PrintDialog
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents Pay_ As Tools.TXT
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Yn1 As Tools.YN
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Defolt_Printer_Select As Tools.TXT
    Friend WithEvents Printer_Source As BindingSource
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
End Class
