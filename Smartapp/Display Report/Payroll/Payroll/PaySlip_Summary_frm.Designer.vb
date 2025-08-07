<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PaySlip_Summary_frm
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Acc_LB = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Frm_Date_LB = New System.Windows.Forms.Label()
        Me.To_Date_LB = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.T2 = New System.Windows.Forms.Panel()
        Me.T1 = New System.Windows.Forms.Panel()
        Me.L6 = New System.Windows.Forms.Panel()
        Me.L5 = New System.Windows.Forms.Panel()
        Me.L4 = New System.Windows.Forms.Panel()
        Me.L3 = New System.Windows.Forms.Panel()
        Me.L2 = New System.Windows.Forms.Panel()
        Me.L1 = New System.Windows.Forms.Panel()
        Me.Grid1 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel2.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.Grid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Linen
        Me.Panel2.Controls.Add(Me.Acc_LB)
        Me.Panel2.Controls.Add(Me.Panel6)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1234, 20)
        Me.Panel2.TabIndex = 1
        '
        'Acc_LB
        '
        Me.Acc_LB.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Acc_LB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Acc_LB.Location = New System.Drawing.Point(0, 0)
        Me.Acc_LB.Name = "Acc_LB"
        Me.Acc_LB.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Acc_LB.Size = New System.Drawing.Size(1000, 20)
        Me.Acc_LB.TabIndex = 1
        Me.Acc_LB.Text = "PaySlip"
        Me.Acc_LB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.Label13)
        Me.Panel6.Controls.Add(Me.Frm_Date_LB)
        Me.Panel6.Controls.Add(Me.To_Date_LB)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel6.Location = New System.Drawing.Point(1000, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(234, 20)
        Me.Panel6.TabIndex = 5
        '
        'Label13
        '
        Me.Label13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label13.Location = New System.Drawing.Point(100, 0)
        Me.Label13.Margin = New System.Windows.Forms.Padding(0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(34, 20)
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
        Me.Frm_Date_LB.Size = New System.Drawing.Size(100, 20)
        Me.Frm_Date_LB.TabIndex = 3
        Me.Frm_Date_LB.Text = "10-01-2022"
        Me.Frm_Date_LB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'To_Date_LB
        '
        Me.To_Date_LB.Dock = System.Windows.Forms.DockStyle.Right
        Me.To_Date_LB.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.To_Date_LB.ForeColor = System.Drawing.Color.SaddleBrown
        Me.To_Date_LB.Location = New System.Drawing.Point(134, 0)
        Me.To_Date_LB.Margin = New System.Windows.Forms.Padding(0)
        Me.To_Date_LB.Name = "To_Date_LB"
        Me.To_Date_LB.Size = New System.Drawing.Size(100, 20)
        Me.To_Date_LB.TabIndex = 2
        Me.To_Date_LB.Text = "10-01-2022"
        Me.To_Date_LB.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.T2)
        Me.Panel1.Controls.Add(Me.T1)
        Me.Panel1.Controls.Add(Me.L6)
        Me.Panel1.Controls.Add(Me.L5)
        Me.Panel1.Controls.Add(Me.L4)
        Me.Panel1.Controls.Add(Me.L3)
        Me.Panel1.Controls.Add(Me.L2)
        Me.Panel1.Controls.Add(Me.L1)
        Me.Panel1.Controls.Add(Me.Grid1)
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 20)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1234, 613)
        Me.Panel1.TabIndex = 3
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.DarkGray
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 591)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1234, 1)
        Me.Panel4.TabIndex = 15
        '
        'T2
        '
        Me.T2.BackColor = System.Drawing.Color.DarkGray
        Me.T2.Location = New System.Drawing.Point(900, 306)
        Me.T2.Margin = New System.Windows.Forms.Padding(4)
        Me.T2.Name = "T2"
        Me.T2.Size = New System.Drawing.Size(200, 1)
        Me.T2.TabIndex = 13
        '
        'T1
        '
        Me.T1.BackColor = System.Drawing.Color.DarkGray
        Me.T1.Location = New System.Drawing.Point(900, 231)
        Me.T1.Margin = New System.Windows.Forms.Padding(4)
        Me.T1.Name = "T1"
        Me.T1.Size = New System.Drawing.Size(200, 1)
        Me.T1.TabIndex = 12
        '
        'L6
        '
        Me.L6.BackColor = System.Drawing.Color.DarkGray
        Me.L6.Location = New System.Drawing.Point(657, 223)
        Me.L6.Margin = New System.Windows.Forms.Padding(4)
        Me.L6.Name = "L6"
        Me.L6.Size = New System.Drawing.Size(1, 247)
        Me.L6.TabIndex = 11
        '
        'L5
        '
        Me.L5.BackColor = System.Drawing.Color.DarkGray
        Me.L5.Location = New System.Drawing.Point(649, 215)
        Me.L5.Margin = New System.Windows.Forms.Padding(4)
        Me.L5.Name = "L5"
        Me.L5.Size = New System.Drawing.Size(1, 247)
        Me.L5.TabIndex = 10
        '
        'L4
        '
        Me.L4.BackColor = System.Drawing.Color.DarkGray
        Me.L4.Location = New System.Drawing.Point(641, 207)
        Me.L4.Margin = New System.Windows.Forms.Padding(4)
        Me.L4.Name = "L4"
        Me.L4.Size = New System.Drawing.Size(1, 247)
        Me.L4.TabIndex = 9
        '
        'L3
        '
        Me.L3.BackColor = System.Drawing.Color.DarkGray
        Me.L3.Location = New System.Drawing.Point(633, 199)
        Me.L3.Margin = New System.Windows.Forms.Padding(4)
        Me.L3.Name = "L3"
        Me.L3.Size = New System.Drawing.Size(1, 247)
        Me.L3.TabIndex = 8
        '
        'L2
        '
        Me.L2.BackColor = System.Drawing.Color.DarkGray
        Me.L2.Location = New System.Drawing.Point(625, 191)
        Me.L2.Margin = New System.Windows.Forms.Padding(4)
        Me.L2.Name = "L2"
        Me.L2.Size = New System.Drawing.Size(1, 247)
        Me.L2.TabIndex = 7
        '
        'L1
        '
        Me.L1.BackColor = System.Drawing.Color.DarkGray
        Me.L1.Location = New System.Drawing.Point(617, 183)
        Me.L1.Margin = New System.Windows.Forms.Padding(4)
        Me.L1.Name = "L1"
        Me.L1.Size = New System.Drawing.Size(1, 247)
        Me.L1.TabIndex = 6
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
        Me.Grid1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column9})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(48, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grid1.DefaultCellStyle = DataGridViewCellStyle3
        Me.Grid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid1.EnableHeadersVisualStyles = False
        Me.Grid1.GridColor = System.Drawing.Color.Silver
        Me.Grid1.Location = New System.Drawing.Point(0, 0)
        Me.Grid1.Margin = New System.Windows.Forms.Padding(0)
        Me.Grid1.Name = "Grid1"
        Me.Grid1.ReadOnly = True
        Me.Grid1.RowHeadersVisible = False
        Me.Grid1.RowTemplate.Height = 17
        Me.Grid1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Grid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid1.Size = New System.Drawing.Size(1234, 592)
        Me.Grid1.TabIndex = 4
        '
        'Column1
        '
        Me.Column1.HeaderText = "Type"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Visible = False
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column2.HeaderText = "Name"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "Bank"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 200
        '
        'Column4
        '
        Me.Column4.HeaderText = "Acc. No."
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 200
        '
        'Column5
        '
        Me.Column5.HeaderText = "Branch"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 150
        '
        'Column6
        '
        Me.Column6.HeaderText = "IFSC"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 130
        '
        'Column7
        '
        Me.Column7.HeaderText = "Phone"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Width = 130
        '
        'Column8
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column8.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column8.HeaderText = "Amount"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Width = 130
        '
        'Column9
        '
        Me.Column9.HeaderText = "ID"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Visible = False
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Label1)
        Me.Panel5.Controls.Add(Me.Label17)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel5.Location = New System.Drawing.Point(0, 592)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1234, 19)
        Me.Panel5.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.Label1.Size = New System.Drawing.Size(152, 19)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Total"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.White
        Me.Label17.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label17.Location = New System.Drawing.Point(1004, 0)
        Me.Label17.Margin = New System.Windows.Forms.Padding(0)
        Me.Label17.Name = "Label17"
        Me.Label17.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Label17.Size = New System.Drawing.Size(230, 19)
        Me.Label17.TabIndex = 7
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.DarkGray
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 611)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1234, 2)
        Me.Panel3.TabIndex = 14
        '
        'PaySlip_Summary_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1234, 633)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "PaySlip_Summary_frm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel2.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.Grid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents Acc_LB As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label13 As Label
    Friend WithEvents Frm_Date_LB As Label
    Friend WithEvents To_Date_LB As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Grid1 As DataGridView
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label17 As Label
    Friend WithEvents L4 As Panel
    Friend WithEvents L3 As Panel
    Friend WithEvents L2 As Panel
    Friend WithEvents L1 As Panel
    Friend WithEvents L6 As Panel
    Friend WithEvents L5 As Panel
    Friend WithEvents T2 As Panel
    Friend WithEvents T1 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
End Class
