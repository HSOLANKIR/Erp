<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Voucher_cfg
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Type_ = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.focus_txt = New Tools.TXT()
        Me.Sp_voucher_create_ctrl1 = New Management.sp_voucher_create_ctrl()
        Me.cprj = New Management.prcj_voucher_create_ctrl()
        Me.Stock_journal_create_ctrl1 = New Management.stock_journal_create_ctrl()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Payroll = New Management.payroll_voucher_create_ctrl()
        Me.Panel23 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel23)
        Me.Panel1.Controls.Add(Me.Type_)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1364, 53)
        Me.Panel1.TabIndex = 0
        '
        'Type_
        '
        Me.Type_.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Type_.Location = New System.Drawing.Point(151, 25)
        Me.Type_.Name = "Type_"
        Me.Type_.Size = New System.Drawing.Size(521, 18)
        Me.Type_.TabIndex = 1
        Me.Type_.Text = "Label2"
        Me.Type_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(132, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(11, 16)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = ":"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(151, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(521, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Label1"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(132, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(11, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = ":"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 18)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Voucher Type"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 18)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Voucher Name"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'focus_txt
        '
        Me.focus_txt.Auto_Cleane = True
        Me.focus_txt.Back_color = System.Drawing.Color.White
        Me.focus_txt.BackColor = System.Drawing.Color.White
        Me.focus_txt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.focus_txt.Data_Link_ = ""
        Me.focus_txt.Decimal_ = 2
        Me.focus_txt.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.focus_txt.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.focus_txt.Font_Size = 11
        Me.focus_txt.Font_Style = System.Drawing.FontStyle.Bold
        Me.focus_txt.Format_ = "dd-MM-yyyy"
        Me.focus_txt.Keydown_Support = True
        Me.focus_txt.Location = New System.Drawing.Point(797, 0)
        Me.focus_txt.Msg_Object = Nothing
        Me.focus_txt.Name = "focus_txt"
        Me.focus_txt.Select_Auto_Show = True
        Me.focus_txt.Select_Column_Color = "NA"
        Me.focus_txt.Select_Columns = 0
        Me.focus_txt.Select_Filter = Nothing
        Me.focus_txt.Select_Hide_Columns = "NA"
        Me.focus_txt.Select_Object = Nothing
        Me.focus_txt.Select_Source = Nothing
        Me.focus_txt.Size = New System.Drawing.Size(1, 17)
        Me.focus_txt.TabIndex = 3
        Me.focus_txt.Type_ = "TXT"
        Me.focus_txt.Val_max = 1000000000
        Me.focus_txt.Val_min = 0
        '
        'Sp_voucher_create_ctrl1
        '
        Me.Sp_voucher_create_ctrl1.BackColor = System.Drawing.Color.White
        Me.Sp_voucher_create_ctrl1.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.Sp_voucher_create_ctrl1.Location = New System.Drawing.Point(16, 18)
        Me.Sp_voucher_create_ctrl1.Margin = New System.Windows.Forms.Padding(4)
        Me.Sp_voucher_create_ctrl1.Name = "Sp_voucher_create_ctrl1"
        Me.Sp_voucher_create_ctrl1.Size = New System.Drawing.Size(82, 145)
        Me.Sp_voucher_create_ctrl1.TabIndex = 87
        Me.Sp_voucher_create_ctrl1.Visible = False
        '
        'cprj
        '
        Me.cprj.AutoScroll = True
        Me.cprj.BackColor = System.Drawing.Color.White
        Me.cprj.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cprj.Location = New System.Drawing.Point(156, 81)
        Me.cprj.Margin = New System.Windows.Forms.Padding(4)
        Me.cprj.Name = "cprj"
        Me.cprj.Size = New System.Drawing.Size(100, 100)
        Me.cprj.TabIndex = 1
        Me.cprj.Visible = False
        '
        'Stock_journal_create_ctrl1
        '
        Me.Stock_journal_create_ctrl1.BackColor = System.Drawing.Color.White
        Me.Stock_journal_create_ctrl1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Stock_journal_create_ctrl1.ForeColor = System.Drawing.Color.Black
        Me.Stock_journal_create_ctrl1.Location = New System.Drawing.Point(186, 222)
        Me.Stock_journal_create_ctrl1.Margin = New System.Windows.Forms.Padding(4)
        Me.Stock_journal_create_ctrl1.Name = "Stock_journal_create_ctrl1"
        Me.Stock_journal_create_ctrl1.Size = New System.Drawing.Size(91, 39)
        Me.Stock_journal_create_ctrl1.TabIndex = 88
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.focus_txt)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 729)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1364, 20)
        Me.Panel2.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Payroll)
        Me.Panel3.Controls.Add(Me.cprj)
        Me.Panel3.Controls.Add(Me.Sp_voucher_create_ctrl1)
        Me.Panel3.Controls.Add(Me.Stock_journal_create_ctrl1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 53)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1364, 676)
        Me.Panel3.TabIndex = 0
        '
        'Payroll
        '
        Me.Payroll.BackColor = System.Drawing.Color.White
        Me.Payroll.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Payroll.Location = New System.Drawing.Point(435, 108)
        Me.Payroll.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Payroll.Name = "Payroll"
        Me.Payroll.Size = New System.Drawing.Size(37, 102)
        Me.Payroll.TabIndex = 89
        '
        'Panel23
        '
        Me.Panel23.BackColor = System.Drawing.Color.Silver
        Me.Panel23.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel23.Location = New System.Drawing.Point(0, 52)
        Me.Panel23.Name = "Panel23"
        Me.Panel23.Size = New System.Drawing.Size(1364, 1)
        Me.Panel23.TabIndex = 90
        '
        'Voucher_cfg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1364, 749)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Voucher_cfg"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Voucher_cfg"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents cprj As prcj_voucher_create_ctrl
    Friend WithEvents Label1 As Label
    Friend WithEvents Type_ As Label
    Friend WithEvents focus_txt As Tools.TXT
    Friend WithEvents Sp_voucher_create_ctrl1 As sp_voucher_create_ctrl
    Friend WithEvents Stock_journal_create_ctrl1 As stock_journal_create_ctrl
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Payroll As payroll_voucher_create_ctrl
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel23 As Panel
End Class
