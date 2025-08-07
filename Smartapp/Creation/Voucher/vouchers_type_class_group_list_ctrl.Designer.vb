<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class vouchers_type_class_group_list_ctrl
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
        Me.Txt1 = New Tools.TXT()
        Me.statsu_txt = New Tools.TXT()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Group_Source = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Group_Source, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Txt1
        '
        Me.Txt1.Auto_Cleane = True
        Me.Txt1.Back_color = System.Drawing.Color.White
        Me.Txt1.BackColor = System.Drawing.Color.White
        Me.Txt1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Txt1.Data_Link_ = ""
        Me.Txt1.Decimal_ = 2
        Me.Txt1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Txt1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Txt1.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Txt1.Font_Size = 10
        Me.Txt1.Font_Style = System.Drawing.FontStyle.Bold
        Me.Txt1.Format_ = "dd-MM-yyyy"
        Me.Txt1.Keydown_Support = True
        Me.Txt1.Location = New System.Drawing.Point(5, 2)
        Me.Txt1.Msg_Object = Nothing
        Me.Txt1.Name = "Txt1"
        Me.Txt1.Select_Auto_Show = True
        Me.Txt1.Select_Column_Color = "NA"
        Me.Txt1.Select_Columns = 0
        Me.Txt1.Select_Filter = "Name LIKE '%<value>%'"
        Me.Txt1.Select_Hide_Columns = "NA"
        Me.Txt1.Select_Object = Nothing
        Me.Txt1.Select_Source = Nothing
        Me.Txt1.Size = New System.Drawing.Size(323, 19)
        Me.Txt1.TabIndex = 0
        Me.Txt1.Type_ = "Select"
        Me.Txt1.Val_max = 1000000000
        Me.Txt1.Val_min = 0
        '
        'statsu_txt
        '
        Me.statsu_txt.Auto_Cleane = True
        Me.statsu_txt.Back_color = System.Drawing.Color.White
        Me.statsu_txt.BackColor = System.Drawing.Color.White
        Me.statsu_txt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.statsu_txt.Data_Link_ = ""
        Me.statsu_txt.Decimal_ = 2
        Me.statsu_txt.Dock = System.Windows.Forms.DockStyle.Right
        Me.statsu_txt.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.statsu_txt.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.statsu_txt.Font_Size = 10
        Me.statsu_txt.Font_Style = System.Drawing.FontStyle.Bold
        Me.statsu_txt.Format_ = "dd-MM-yyyy"
        Me.statsu_txt.Keydown_Support = True
        Me.statsu_txt.Location = New System.Drawing.Point(677, 2)
        Me.statsu_txt.Msg_Object = Nothing
        Me.statsu_txt.Name = "statsu_txt"
        Me.statsu_txt.Select_Auto_Show = True
        Me.statsu_txt.Select_Column_Color = "NA"
        Me.statsu_txt.Select_Columns = 0
        Me.statsu_txt.Select_Filter = "Name LIKE '%<value>%'"
        Me.statsu_txt.Select_Hide_Columns = "NA"
        Me.statsu_txt.Select_Object = Nothing
        Me.statsu_txt.Select_Source = Nothing
        Me.statsu_txt.Size = New System.Drawing.Size(100, 19)
        Me.statsu_txt.TabIndex = 1
        Me.statsu_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.statsu_txt.Type_ = "Select"
        Me.statsu_txt.Val_max = 1000000000
        Me.statsu_txt.Val_min = 0
        '
        'vouchers_type_class_group_list_ctrl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.statsu_txt)
        Me.Controls.Add(Me.Txt1)
        Me.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "vouchers_type_class_group_list_ctrl"
        Me.Padding = New System.Windows.Forms.Padding(5, 2, 5, 0)
        Me.Size = New System.Drawing.Size(782, 19)
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Group_Source, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Txt1 As Tools.TXT
    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents Group_Source As BindingSource
    Friend WithEvents statsu_txt As Tools.TXT
End Class
