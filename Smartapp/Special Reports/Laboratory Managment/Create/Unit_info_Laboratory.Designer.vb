<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Unit_info_Laboratory
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Unit_info_Laboratory))
        Me.Label49 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Symbol_TXT = New Tools.TXT()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.FormalName_TXT = New Tools.TXT()
        Me.Column7 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Deciaml_TXT = New Tools.TXT()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label49.Location = New System.Drawing.Point(6, 26)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(94, 16)
        Me.Label49.TabIndex = 76
        Me.Label49.Text = "Formal Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(106, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 16)
        Me.Label2.TabIndex = 75
        Me.Label2.Text = ":"
        '
        'Symbol_TXT
        '
        Me.Symbol_TXT.Auto_Cleane = True
        Me.Symbol_TXT.Back_color = System.Drawing.Color.White
        Me.Symbol_TXT.BackColor = System.Drawing.Color.White
        Me.Symbol_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Symbol_TXT.Data_Link_ = ""
        Me.Symbol_TXT.Decimal_ = 2
        Me.Symbol_TXT.Font = New System.Drawing.Font("Arial", 11.0!)
        Me.Symbol_TXT.Font_Size = 11
        Me.Symbol_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Symbol_TXT.Format_ = "dd-MM-yyyy"
        Me.Symbol_TXT.Keydown_Support = True
        Me.Symbol_TXT.Location = New System.Drawing.Point(125, 8)
        Me.Symbol_TXT.Msg_Object = Nothing
        Me.Symbol_TXT.Name = "Symbol_TXT"
        Me.Symbol_TXT.Select_Auto_Show = True
        Me.Symbol_TXT.Select_Column_Color = "NA"
        Me.Symbol_TXT.Select_Columns = 0
        Me.Symbol_TXT.Select_Filter = Nothing
        Me.Symbol_TXT.Select_Hide_Columns = "NA"
        Me.Symbol_TXT.Select_Object = Nothing
        Me.Symbol_TXT.Select_Source = Nothing
        Me.Symbol_TXT.Size = New System.Drawing.Size(98, 17)
        Me.Symbol_TXT.TabIndex = 72
        Me.Symbol_TXT.Type_ = "TXT"
        Me.Symbol_TXT.Val_max = 1000000000
        Me.Symbol_TXT.Val_min = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 74
        Me.Label1.Text = "Symbol"
        '
        'Column1
        '
        Me.Column1.HeaderText = "Doc.ID"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Visible = False
        '
        'Column2
        '
        Me.Column2.HeaderText = "Name"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 120
        '
        'Column4
        '
        Me.Column4.HeaderText = "Attage"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 80
        '
        'Column5
        '
        Me.Column5.HeaderText = "Data"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Visible = False
        '
        'Column9
        '
        Me.Column9.HeaderText = "Password"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Visible = False
        '
        'Column6
        '
        Me.Column6.HeaderText = ""
        Me.Column6.Image = CType(resources.GetObject("Column6.Image"), System.Drawing.Image)
        Me.Column6.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 37
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column3.HeaderText = "Narration"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column8
        '
        Me.Column8.HeaderText = ""
        Me.Column8.Image = CType(resources.GetObject("Column8.Image"), System.Drawing.Image)
        Me.Column8.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Width = 37
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Location = New System.Drawing.Point(106, 26)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(12, 16)
        Me.Label48.TabIndex = 77
        Me.Label48.Text = ":"
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Deciaml_TXT)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label48)
        Me.Panel1.Controls.Add(Me.FormalName_TXT)
        Me.Panel1.Controls.Add(Me.Label49)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Symbol_TXT)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.Panel1.Size = New System.Drawing.Size(353, 75)
        Me.Panel1.TabIndex = 0
        '
        'FormalName_TXT
        '
        Me.FormalName_TXT.Auto_Cleane = True
        Me.FormalName_TXT.Back_color = System.Drawing.Color.White
        Me.FormalName_TXT.BackColor = System.Drawing.Color.White
        Me.FormalName_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.FormalName_TXT.Data_Link_ = ""
        Me.FormalName_TXT.Decimal_ = 2
        Me.FormalName_TXT.Font = New System.Drawing.Font("Arial", 11.0!)
        Me.FormalName_TXT.Font_Size = 11
        Me.FormalName_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.FormalName_TXT.Format_ = "dd-MM-yyyy"
        Me.FormalName_TXT.Keydown_Support = True
        Me.FormalName_TXT.Location = New System.Drawing.Point(125, 26)
        Me.FormalName_TXT.Msg_Object = Nothing
        Me.FormalName_TXT.Name = "FormalName_TXT"
        Me.FormalName_TXT.Select_Auto_Show = True
        Me.FormalName_TXT.Select_Column_Color = "NA"
        Me.FormalName_TXT.Select_Columns = 0
        Me.FormalName_TXT.Select_Filter = Nothing
        Me.FormalName_TXT.Select_Hide_Columns = "NA"
        Me.FormalName_TXT.Select_Object = Nothing
        Me.FormalName_TXT.Select_Source = Nothing
        Me.FormalName_TXT.Size = New System.Drawing.Size(204, 17)
        Me.FormalName_TXT.TabIndex = 73
        Me.FormalName_TXT.Type_ = "TXT"
        Me.FormalName_TXT.Val_max = 1000000000
        Me.FormalName_TXT.Val_min = 0
        '
        'Column7
        '
        Me.Column7.HeaderText = ""
        Me.Column7.Image = CType(resources.GetObject("Column7.Image"), System.Drawing.Image)
        Me.Column7.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Width = 37
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(355, 512)
        Me.Panel2.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(106, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(12, 16)
        Me.Label3.TabIndex = 80
        Me.Label3.Text = ":"
        '
        'Deciaml_TXT
        '
        Me.Deciaml_TXT.Auto_Cleane = True
        Me.Deciaml_TXT.Back_color = System.Drawing.Color.White
        Me.Deciaml_TXT.BackColor = System.Drawing.Color.White
        Me.Deciaml_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Deciaml_TXT.Data_Link_ = ""
        Me.Deciaml_TXT.Decimal_ = 2
        Me.Deciaml_TXT.Font = New System.Drawing.Font("Arial", 11.0!)
        Me.Deciaml_TXT.Font_Size = 11
        Me.Deciaml_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Deciaml_TXT.Format_ = "dd-MM-yyyy"
        Me.Deciaml_TXT.Keydown_Support = True
        Me.Deciaml_TXT.Location = New System.Drawing.Point(125, 45)
        Me.Deciaml_TXT.Msg_Object = Nothing
        Me.Deciaml_TXT.Name = "Deciaml_TXT"
        Me.Deciaml_TXT.Select_Auto_Show = True
        Me.Deciaml_TXT.Select_Column_Color = "NA"
        Me.Deciaml_TXT.Select_Columns = 0
        Me.Deciaml_TXT.Select_Filter = Nothing
        Me.Deciaml_TXT.Select_Hide_Columns = "NA"
        Me.Deciaml_TXT.Select_Object = Nothing
        Me.Deciaml_TXT.Select_Source = Nothing
        Me.Deciaml_TXT.Size = New System.Drawing.Size(20, 17)
        Me.Deciaml_TXT.TabIndex = 78
        Me.Deciaml_TXT.Type_ = "TXT"
        Me.Deciaml_TXT.Val_max = 1000000000
        Me.Deciaml_TXT.Val_min = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 16)
        Me.Label4.TabIndex = 79
        Me.Label4.Text = "Decimal"
        '
        'Unit_info_Laboratory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AntiqueWhite
        Me.ClientSize = New System.Drawing.Size(776, 512)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Unit_info_Laboratory"
        Me.Text = "Unit_info_Laboratory"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label49 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewImageColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewImageColumn
    Friend WithEvents Label48 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents FormalName_TXT As Tools.TXT
    Friend WithEvents Column7 As DataGridViewImageColumn
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Deciaml_TXT As Tools.TXT
    Friend WithEvents Label4 As Label
    Friend WithEvents Symbol_TXT As Tools.TXT
End Class
