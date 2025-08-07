<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Day_Book_frm
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
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Acc_LB = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Frm_Date_LB = New System.Windows.Forms.Label()
        Me.To_Date_LB = New System.Windows.Forms.Label()
        Me.Source_ = New System.Windows.Forms.BindingSource(Me.components)
        Me.BG_Panel.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.Grid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel6.SuspendLayout()
        CType(Me.Source_, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BG_Panel
        '
        Me.BG_Panel.BackColor = System.Drawing.Color.White
        Me.BG_Panel.Controls.Add(Me.Panel1)
        Me.BG_Panel.Controls.Add(Me.Panel5)
        Me.BG_Panel.Controls.Add(Me.Panel2)
        Me.BG_Panel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BG_Panel.Location = New System.Drawing.Point(0, 0)
        Me.BG_Panel.Name = "BG_Panel"
        Me.BG_Panel.Size = New System.Drawing.Size(1364, 705)
        Me.BG_Panel.TabIndex = 3
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Grid1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 20)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1364, 668)
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
        Me.Grid1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Grid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid1.Size = New System.Drawing.Size(1364, 668)
        Me.Grid1.TabIndex = 3
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Panel5.Controls.Add(Me.Label17)
        Me.Panel5.Controls.Add(Me.Label14)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel5.Location = New System.Drawing.Point(0, 688)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1364, 17)
        Me.Panel5.TabIndex = 1
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Bisque
        Me.Label17.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label17.Location = New System.Drawing.Point(183, 0)
        Me.Label17.Margin = New System.Windows.Forms.Padding(0)
        Me.Label17.Name = "Label17"
        Me.Label17.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Label17.Size = New System.Drawing.Size(259, 17)
        Me.Label17.TabIndex = 6
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.PaleTurquoise
        Me.Label14.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label14.Location = New System.Drawing.Point(0, 0)
        Me.Label14.Margin = New System.Windows.Forms.Padding(0)
        Me.Label14.Name = "Label14"
        Me.Label14.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Label14.Size = New System.Drawing.Size(183, 17)
        Me.Label14.TabIndex = 7
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.Panel2.Size = New System.Drawing.Size(1364, 20)
        Me.Panel2.TabIndex = 0
        '
        'Acc_LB
        '
        Me.Acc_LB.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Acc_LB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Acc_LB.Location = New System.Drawing.Point(0, 0)
        Me.Acc_LB.Name = "Acc_LB"
        Me.Acc_LB.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Acc_LB.Size = New System.Drawing.Size(1130, 20)
        Me.Acc_LB.TabIndex = 1
        Me.Acc_LB.Text = "Day Book"
        Me.Acc_LB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.Label13)
        Me.Panel6.Controls.Add(Me.Frm_Date_LB)
        Me.Panel6.Controls.Add(Me.To_Date_LB)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel6.Location = New System.Drawing.Point(1130, 0)
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
        'Day_Book_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1364, 705)
        Me.Controls.Add(Me.BG_Panel)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Day_Book_frm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Day_Book_frm"
        Me.BG_Panel.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.Grid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        CType(Me.Source_, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BG_Panel As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label13 As Label
    Friend WithEvents Frm_Date_LB As Label
    Friend WithEvents To_Date_LB As Label
    Friend WithEvents Acc_LB As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Grid1 As DataGridView
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Source_ As BindingSource
    Friend WithEvents Label17 As Label
    Friend WithEvents Label14 As Label
End Class
