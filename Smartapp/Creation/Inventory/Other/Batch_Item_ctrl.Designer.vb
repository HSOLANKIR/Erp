<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Batch_Item_ctrl
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
        Me.platform = New System.Windows.Forms.Panel()
        Me.bg_Panel = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Txt1 = New Tools.TXT()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Item_Label = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Batch_LAB = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.bg_Panel.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'platform
        '
        Me.platform.AutoScroll = True
        Me.platform.Dock = System.Windows.Forms.DockStyle.Fill
        Me.platform.Location = New System.Drawing.Point(0, 90)
        Me.platform.Name = "platform"
        Me.platform.Padding = New System.Windows.Forms.Padding(0, 9, 0, 0)
        Me.platform.Size = New System.Drawing.Size(336, 391)
        Me.platform.TabIndex = 1
        '
        'bg_Panel
        '
        Me.bg_Panel.Controls.Add(Me.platform)
        Me.bg_Panel.Controls.Add(Me.Panel4)
        Me.bg_Panel.Controls.Add(Me.Panel1)
        Me.bg_Panel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bg_Panel.Location = New System.Drawing.Point(0, 0)
        Me.bg_Panel.Name = "bg_Panel"
        Me.bg_Panel.Size = New System.Drawing.Size(336, 481)
        Me.bg_Panel.TabIndex = 1
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Label9)
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.Panel3)
        Me.Panel4.Controls.Add(Me.Panel2)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 71)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(336, 19)
        Me.Panel4.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(224, 2)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(112, 16)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Quantity"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(0, 2)
        Me.Label4.Name = "Label4"
        Me.Label4.Padding = New System.Windows.Forms.Padding(9, 0, 0, 0)
        Me.Label4.Size = New System.Drawing.Size(166, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Item"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.DimGray
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 18)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(336, 1)
        Me.Panel3.TabIndex = 5
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DimGray
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(336, 2)
        Me.Panel2.TabIndex = 7
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Txt1)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Item_Label)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Batch_LAB)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(336, 71)
        Me.Panel1.TabIndex = 0
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(169, 50)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(169, 16)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "Bags"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.Txt1.Font_Size = 11
        Me.Txt1.Format_ = "dd-MM-yyyy"
        Me.Txt1.Keydown_Support = True
        Me.Txt1.Location = New System.Drawing.Point(124, 50)
        Me.Txt1.Name = "Txt1"
        Me.Txt1.Select_Auto_Show = True
        Me.Txt1.Select_Column_Color = "NA"
        Me.Txt1.Select_Columns = 0
        Me.Txt1.Select_Filter = Nothing
        Me.Txt1.Select_Hide_Columns = "NA"
        Me.Txt1.Select_Object = Nothing
        Me.Txt1.Select_Source = Nothing
        Me.Txt1.Size = New System.Drawing.Size(39, 15)
        Me.Txt1.TabIndex = 7
        Me.Txt1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Txt1.Type_ = "TXT"
        Me.Txt1.Val_max = 1000000000
        Me.Txt1.Val_min = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(116, 50)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(12, 18)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = ":"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(3, 50)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(74, 16)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Unit of Mfg."
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Item_Label
        '
        Me.Item_Label.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Item_Label.Location = New System.Drawing.Point(116, 31)
        Me.Item_Label.Name = "Item_Label"
        Me.Item_Label.Size = New System.Drawing.Size(220, 16)
        Me.Item_Label.TabIndex = 4
        Me.Item_Label.Text = ": POLLAN Prom"
        Me.Item_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 31)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 16)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Stock Item"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Batch_LAB
        '
        Me.Batch_LAB.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Batch_LAB.Location = New System.Drawing.Point(116, 13)
        Me.Batch_LAB.Name = "Batch_LAB"
        Me.Batch_LAB.Size = New System.Drawing.Size(220, 16)
        Me.Batch_LAB.TabIndex = 2
        Me.Batch_LAB.Text = ": POLLAN Prom"
        Me.Batch_LAB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "BOM Name"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Batch_Item_ctrl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.bg_Panel)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Batch_Item_ctrl"
        Me.Size = New System.Drawing.Size(336, 481)
        Me.bg_Panel.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents platform As Panel
    Friend WithEvents bg_Panel As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Batch_LAB As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Item_Label As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Txt1 As Tools.TXT
End Class
