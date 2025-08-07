<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Search_Vouchers_frm
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.bg_Panel = New System.Windows.Forms.Panel()
        Me.Grid1 = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Acc_LB = New System.Windows.Forms.Label()
        Me.Head_Source = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Search_TXT = New Tools.TXT()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TX = New Tools.TXT()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Type_Source = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Godown_Panel = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.Branch_Panel = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.bg_Panel.SuspendLayout()
        CType(Me.Grid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.Head_Source, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.Type_Source, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Godown_Panel.SuspendLayout()
        Me.Branch_Panel.SuspendLayout()
        Me.SuspendLayout()
        '
        'bg_Panel
        '
        Me.bg_Panel.Controls.Add(Me.Grid1)
        Me.bg_Panel.Controls.Add(Me.Panel2)
        Me.bg_Panel.Controls.Add(Me.Panel1)
        Me.bg_Panel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bg_Panel.Location = New System.Drawing.Point(0, 0)
        Me.bg_Panel.Name = "bg_Panel"
        Me.bg_Panel.Size = New System.Drawing.Size(1364, 705)
        Me.bg_Panel.TabIndex = 0
        Me.bg_Panel.Visible = False
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
        Me.Grid1.ColumnHeadersHeight = 20
        Me.Grid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
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
        Me.Grid1.Location = New System.Drawing.Point(0, 20)
        Me.Grid1.Margin = New System.Windows.Forms.Padding(0)
        Me.Grid1.Name = "Grid1"
        Me.Grid1.ReadOnly = True
        Me.Grid1.RowHeadersVisible = False
        Me.Grid1.RowTemplate.Height = 17
        Me.Grid1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Grid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid1.Size = New System.Drawing.Size(1364, 650)
        Me.Grid1.TabIndex = 4
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Linen
        Me.Panel2.Controls.Add(Me.Acc_LB)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1364, 20)
        Me.Panel2.TabIndex = 1
        '
        'Acc_LB
        '
        Me.Acc_LB.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Acc_LB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Acc_LB.Location = New System.Drawing.Point(0, 0)
        Me.Acc_LB.Name = "Acc_LB"
        Me.Acc_LB.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Acc_LB.Size = New System.Drawing.Size(1364, 20)
        Me.Acc_LB.TabIndex = 1
        Me.Acc_LB.Text = "Search Vouchers"
        Me.Acc_LB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.Search_TXT)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.TX)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Location = New System.Drawing.Point(501, 35)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(393, 74)
        Me.Panel4.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 16)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Search Value"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Search_TXT
        '
        Me.Search_TXT.Auto_Cleane = True
        Me.Search_TXT.Back_color = System.Drawing.Color.White
        Me.Search_TXT.BackColor = System.Drawing.Color.White
        Me.Search_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Search_TXT.Data_Link_ = ""
        Me.Search_TXT.Decimal_ = 2
        Me.Search_TXT.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Search_TXT.Font_Size = 10
        Me.Search_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Search_TXT.Format_ = "dd-MM-yyyy"
        Me.Search_TXT.Keydown_Support = True
        Me.Search_TXT.Location = New System.Drawing.Point(115, 47)
        Me.Search_TXT.Msg_Object = Nothing
        Me.Search_TXT.Name = "Search_TXT"
        Me.Search_TXT.Select_Auto_Show = True
        Me.Search_TXT.Select_Column_Color = "NA"
        Me.Search_TXT.Select_Columns = 0
        Me.Search_TXT.Select_Filter = "(Name LIKE '%<value>%') or (Under LIKE '%<value>%')"
        Me.Search_TXT.Select_Hide_Columns = "NA"
        Me.Search_TXT.Select_Object = Nothing
        Me.Search_TXT.Select_Source = Nothing
        Me.Search_TXT.Size = New System.Drawing.Size(273, 16)
        Me.Search_TXT.TabIndex = 8
        Me.Search_TXT.Type_ = "Select"
        Me.Search_TXT.Val_max = 1000000000
        Me.Search_TXT.Val_min = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 16)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Search Type"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TX
        '
        Me.TX.Auto_Cleane = True
        Me.TX.Back_color = System.Drawing.Color.White
        Me.TX.BackColor = System.Drawing.Color.White
        Me.TX.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TX.Data_Link_ = ""
        Me.TX.Decimal_ = 2
        Me.TX.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.TX.Font_Size = 10
        Me.TX.Font_Style = System.Drawing.FontStyle.Bold
        Me.TX.Format_ = "dd-MM-yyyy"
        Me.TX.Keydown_Support = True
        Me.TX.Location = New System.Drawing.Point(115, 25)
        Me.TX.Msg_Object = Nothing
        Me.TX.Name = "TX"
        Me.TX.Select_Auto_Show = True
        Me.TX.Select_Column_Color = "NA"
        Me.TX.Select_Columns = 0
        Me.TX.Select_Filter = " "
        Me.TX.Select_Hide_Columns = "NA"
        Me.TX.Select_Object = Nothing
        Me.TX.Select_Source = Nothing
        Me.TX.Size = New System.Drawing.Size(167, 16)
        Me.TX.TabIndex = 6
        Me.TX.Text = "Full Search"
        Me.TX.Type_ = "Select"
        Me.TX.Val_max = 1000000000
        Me.TX.Val_min = 0
        '
        'Label3
        '
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(391, 22)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Search"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Godown_Panel)
        Me.Panel1.Controls.Add(Me.Branch_Panel)
        Me.Panel1.Controls.Add(Me.Panel6)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 670)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1364, 35)
        Me.Panel1.TabIndex = 5
        '
        'Godown_Panel
        '
        Me.Godown_Panel.Controls.Add(Me.Label4)
        Me.Godown_Panel.Controls.Add(Me.Label7)
        Me.Godown_Panel.Controls.Add(Me.Panel10)
        Me.Godown_Panel.Dock = System.Windows.Forms.DockStyle.Left
        Me.Godown_Panel.Location = New System.Drawing.Point(203, 1)
        Me.Godown_Panel.Name = "Godown_Panel"
        Me.Godown_Panel.Size = New System.Drawing.Size(203, 34)
        Me.Godown_Panel.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(0, 15)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0)
        Me.Label4.Name = "Label4"
        Me.Label4.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Label4.Size = New System.Drawing.Size(202, 19)
        Me.Label4.TabIndex = 7
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(0, 0)
        Me.Label7.Margin = New System.Windows.Forms.Padding(0)
        Me.Label7.Name = "Label7"
        Me.Label7.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Label7.Size = New System.Drawing.Size(202, 15)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Godown"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.DimGray
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel10.Location = New System.Drawing.Point(202, 0)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(1, 34)
        Me.Panel10.TabIndex = 6
        '
        'Branch_Panel
        '
        Me.Branch_Panel.Controls.Add(Me.Label5)
        Me.Branch_Panel.Controls.Add(Me.Label6)
        Me.Branch_Panel.Controls.Add(Me.Panel5)
        Me.Branch_Panel.Dock = System.Windows.Forms.DockStyle.Left
        Me.Branch_Panel.Location = New System.Drawing.Point(0, 1)
        Me.Branch_Panel.Name = "Branch_Panel"
        Me.Branch_Panel.Size = New System.Drawing.Size(203, 34)
        Me.Branch_Panel.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(0, 15)
        Me.Label5.Margin = New System.Windows.Forms.Padding(0)
        Me.Label5.Name = "Label5"
        Me.Label5.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Label5.Size = New System.Drawing.Size(202, 19)
        Me.Label5.TabIndex = 7
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(0, 0)
        Me.Label6.Margin = New System.Windows.Forms.Padding(0)
        Me.Label6.Name = "Label6"
        Me.Label6.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Label6.Size = New System.Drawing.Size(202, 15)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Branch"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.DimGray
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel5.Location = New System.Drawing.Point(202, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1, 34)
        Me.Panel5.TabIndex = 6
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.DimGray
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1364, 1)
        Me.Panel6.TabIndex = 7
        '
        'Search_Vouchers_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1364, 705)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.bg_Panel)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Search_Vouchers_frm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Search_Vouchers_frm"
        Me.bg_Panel.ResumeLayout(False)
        CType(Me.Grid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.Head_Source, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.Type_Source, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Godown_Panel.ResumeLayout(False)
        Me.Branch_Panel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents bg_Panel As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Acc_LB As Label
    Friend WithEvents Grid1 As DataGridView
    Friend WithEvents Head_Source As BindingSource
    Friend WithEvents Panel4 As Panel
    Friend WithEvents TX As Tools.TXT
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Search_TXT As Tools.TXT
    Friend WithEvents Type_Source As BindingSource
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Godown_Panel As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Panel10 As Panel
    Friend WithEvents Branch_Panel As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel6 As Panel
End Class
