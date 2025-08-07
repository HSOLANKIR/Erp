<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Stock_Item_Branch_Stock
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
        Me.Stock_Item_Branch_Stock_ctrl1 = New Management.Stock_Item_Branch_Stock_ctrl()
        Me.Save_TXT = New Tools.TXT()
        Me.SuspendLayout()
        '
        'Stock_Item_Branch_Stock_ctrl1
        '
        Me.Stock_Item_Branch_Stock_ctrl1.BackColor = System.Drawing.Color.White
        Me.Stock_Item_Branch_Stock_ctrl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Stock_Item_Branch_Stock_ctrl1.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Stock_Item_Branch_Stock_ctrl1.ForeColor = System.Drawing.Color.Black
        Me.Stock_Item_Branch_Stock_ctrl1.Location = New System.Drawing.Point(389, 77)
        Me.Stock_Item_Branch_Stock_ctrl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Stock_Item_Branch_Stock_ctrl1.Name = "Stock_Item_Branch_Stock_ctrl1"
        Me.Stock_Item_Branch_Stock_ctrl1.Size = New System.Drawing.Size(455, 479)
        Me.Stock_Item_Branch_Stock_ctrl1.TabIndex = 0
        '
        'Save_TXT
        '
        Me.Save_TXT.Auto_Cleane = True
        Me.Save_TXT.Back_color = System.Drawing.Color.White
        Me.Save_TXT.BackColor = System.Drawing.Color.White
        Me.Save_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Save_TXT.Data_Link_ = ""
        Me.Save_TXT.Decimal_ = 2
        Me.Save_TXT.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Save_TXT.Font_Size = 10
        Me.Save_TXT.Format_ = "dd-MM-yyyy"
        Me.Save_TXT.Keydown_Support = True
        Me.Save_TXT.Location = New System.Drawing.Point(850, 527)
        Me.Save_TXT.Name = "Save_TXT"
        Me.Save_TXT.Select_Auto_Show = True
        Me.Save_TXT.Select_Column_Color = "NA"
        Me.Save_TXT.Select_Columns = 0
        Me.Save_TXT.Select_Filter = Nothing
        Me.Save_TXT.Select_Hide_Columns = "NA"
        Me.Save_TXT.Select_Object = Nothing
        Me.Save_TXT.Select_Source = Nothing
        Me.Save_TXT.Size = New System.Drawing.Size(1, 16)
        Me.Save_TXT.TabIndex = 6
        Me.Save_TXT.Type_ = "TXT"
        Me.Save_TXT.Val_max = 1000000000
        Me.Save_TXT.Val_min = 0
        '
        'Stock_Item_Branch_Stock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.PaleTurquoise
        Me.ClientSize = New System.Drawing.Size(1364, 749)
        Me.Controls.Add(Me.Save_TXT)
        Me.Controls.Add(Me.Stock_Item_Branch_Stock_ctrl1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Stock_Item_Branch_Stock"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Stock_Item_Branch_Stock_ctrl1 As Stock_Item_Branch_Stock_ctrl
    Friend WithEvents Save_TXT As Tools.TXT
End Class
