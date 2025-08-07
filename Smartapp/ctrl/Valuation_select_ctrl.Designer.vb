<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Valuation_select_ctrl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Grid_ = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Txt1 = New Tools.TXT()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grid_, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Grid_
        '
        Me.Grid_.BackgroundColor = System.Drawing.Color.PapayaWhip
        Me.Grid_.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Grid_.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.Grid_.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Tan
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 11.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Tan
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grid_.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grid_.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Grid_.ColumnHeadersVisible = False
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 11.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(48, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grid_.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grid_.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid_.EnableHeadersVisualStyles = False
        Me.Grid_.GridColor = System.Drawing.Color.Silver
        Me.Grid_.Location = New System.Drawing.Point(0, 22)
        Me.Grid_.Name = "Grid_"
        Me.Grid_.RowHeadersVisible = False
        Me.Grid_.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid_.Size = New System.Drawing.Size(199, 271)
        Me.Grid_.TabIndex = 7
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Txt1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(199, 22)
        Me.Panel1.TabIndex = 6
        '
        'Txt1
        '
        Me.Txt1.Back_color = System.Drawing.Color.White
        Me.Txt1.BackColor = System.Drawing.Color.White
        Me.Txt1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Txt1.Data_Link_ = ""
        Me.Txt1.Decimal_ = 2
        Me.Txt1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Txt1.Font = New System.Drawing.Font("Arial", 11.0!)
        Me.Txt1.Font_Size = 11
        Me.Txt1.Format_ = "dd-MM-yyyy"
        Me.Txt1.Keydown_Support = True
        Me.Txt1.Location = New System.Drawing.Point(0, 0)
        Me.Txt1.Name = "Txt1"
        Me.Txt1.Select_Auto_Show = True
        Me.Txt1.Select_Column_Color = "NA"
        Me.Txt1.Select_Columns = 0
        Me.Txt1.Select_Filter = Nothing
        Me.Txt1.Select_Hide_Columns = "NA"
        Me.Txt1.Select_Source = Nothing
        Me.Txt1.Size = New System.Drawing.Size(199, 17)
        Me.Txt1.TabIndex = 0
        Me.Txt1.Type_ = "TXT"
        Me.Txt1.Val_max = 1000000000
        Me.Txt1.Val_min = 0
        '
        'Valuation_select_ctrl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.PapayaWhip
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.Grid_)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 11.0!)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Valuation_select_ctrl"
        Me.Size = New System.Drawing.Size(199, 293)
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grid_, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents Grid_ As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Txt1 As Tools.TXT
End Class
