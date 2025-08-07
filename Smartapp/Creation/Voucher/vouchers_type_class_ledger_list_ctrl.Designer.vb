<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class vouchers_type_class_ledger_list_ctrl
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
        Me.Ledger_TXT = New Tools.TXT()
        Me.calulation_TXT = New Tools.TXT()
        Me.Dft_TXT = New Tools.TXT()
        Me.Rounding_TXT = New Tools.TXT()
        Me.Calculation_Source = New System.Windows.Forms.BindingSource(Me.components)
        Me.Ledger_Source = New System.Windows.Forms.BindingSource(Me.components)
        Me.rounding_Source = New System.Windows.Forms.BindingSource(Me.components)
        Me.Rounding_Limit = New Tools.TXT()
        CType(Me.Calculation_Source, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ledger_Source, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rounding_Source, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Ledger_TXT
        '
        Me.Ledger_TXT.Auto_Cleane = True
        Me.Ledger_TXT.Back_color = System.Drawing.Color.White
        Me.Ledger_TXT.BackColor = System.Drawing.Color.White
        Me.Ledger_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Ledger_TXT.Data_Link_ = ""
        Me.Ledger_TXT.Decimal_ = 2
        Me.Ledger_TXT.Dock = System.Windows.Forms.DockStyle.Left
        Me.Ledger_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Ledger_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Ledger_TXT.Font_Size = 10
        Me.Ledger_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Ledger_TXT.Format_ = "dd-MM-yyyy"
        Me.Ledger_TXT.Keydown_Support = True
        Me.Ledger_TXT.Location = New System.Drawing.Point(5, 0)
        Me.Ledger_TXT.Msg_Object = Nothing
        Me.Ledger_TXT.Name = "Ledger_TXT"
        Me.Ledger_TXT.Select_Auto_Show = True
        Me.Ledger_TXT.Select_Column_Color = "NA"
        Me.Ledger_TXT.Select_Columns = 0
        Me.Ledger_TXT.Select_Filter = "Name LIKE '%<value>%'"
        Me.Ledger_TXT.Select_Hide_Columns = "NA"
        Me.Ledger_TXT.Select_Object = Nothing
        Me.Ledger_TXT.Select_Source = Nothing
        Me.Ledger_TXT.Size = New System.Drawing.Size(190, 19)
        Me.Ledger_TXT.TabIndex = 0
        Me.Ledger_TXT.Type_ = "Select"
        Me.Ledger_TXT.Val_max = 1000000000
        Me.Ledger_TXT.Val_min = 0
        '
        'calulation_TXT
        '
        Me.calulation_TXT.Auto_Cleane = True
        Me.calulation_TXT.Back_color = System.Drawing.Color.White
        Me.calulation_TXT.BackColor = System.Drawing.Color.White
        Me.calulation_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.calulation_TXT.Data_Link_ = ""
        Me.calulation_TXT.Decimal_ = 2
        Me.calulation_TXT.Dock = System.Windows.Forms.DockStyle.Left
        Me.calulation_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.calulation_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.calulation_TXT.Font_Size = 10
        Me.calulation_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.calulation_TXT.Format_ = "dd-MM-yyyy"
        Me.calulation_TXT.Keydown_Support = True
        Me.calulation_TXT.Location = New System.Drawing.Point(195, 0)
        Me.calulation_TXT.Msg_Object = Nothing
        Me.calulation_TXT.Name = "calulation_TXT"
        Me.calulation_TXT.Select_Auto_Show = True
        Me.calulation_TXT.Select_Column_Color = "NA"
        Me.calulation_TXT.Select_Columns = 0
        Me.calulation_TXT.Select_Filter = "Name LIKE '%<value>%'"
        Me.calulation_TXT.Select_Hide_Columns = "NA"
        Me.calulation_TXT.Select_Object = Nothing
        Me.calulation_TXT.Select_Source = Nothing
        Me.calulation_TXT.Size = New System.Drawing.Size(180, 19)
        Me.calulation_TXT.TabIndex = 2
        Me.calulation_TXT.Type_ = "Select"
        Me.calulation_TXT.Val_max = 1000000000
        Me.calulation_TXT.Val_min = 0
        '
        'Dft_TXT
        '
        Me.Dft_TXT.Auto_Cleane = True
        Me.Dft_TXT.Back_color = System.Drawing.Color.White
        Me.Dft_TXT.BackColor = System.Drawing.Color.White
        Me.Dft_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Dft_TXT.Data_Link_ = ""
        Me.Dft_TXT.Decimal_ = 2
        Me.Dft_TXT.Dock = System.Windows.Forms.DockStyle.Left
        Me.Dft_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Dft_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Dft_TXT.Font_Size = 10
        Me.Dft_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Dft_TXT.Format_ = "dd-MM-yyyy"
        Me.Dft_TXT.Keydown_Support = True
        Me.Dft_TXT.Location = New System.Drawing.Point(375, 0)
        Me.Dft_TXT.Msg_Object = Nothing
        Me.Dft_TXT.Name = "Dft_TXT"
        Me.Dft_TXT.Select_Auto_Show = True
        Me.Dft_TXT.Select_Column_Color = "NA"
        Me.Dft_TXT.Select_Columns = 0
        Me.Dft_TXT.Select_Filter = "Name LIKE '%<value>%'"
        Me.Dft_TXT.Select_Hide_Columns = "NA"
        Me.Dft_TXT.Select_Object = Nothing
        Me.Dft_TXT.Select_Source = Nothing
        Me.Dft_TXT.Size = New System.Drawing.Size(80, 19)
        Me.Dft_TXT.TabIndex = 3
        Me.Dft_TXT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Dft_TXT.Type_ = "Num"
        Me.Dft_TXT.Val_max = 1000000000
        Me.Dft_TXT.Val_min = 0
        '
        'Rounding_TXT
        '
        Me.Rounding_TXT.Auto_Cleane = True
        Me.Rounding_TXT.Back_color = System.Drawing.Color.White
        Me.Rounding_TXT.BackColor = System.Drawing.Color.White
        Me.Rounding_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Rounding_TXT.Data_Link_ = ""
        Me.Rounding_TXT.Decimal_ = 2
        Me.Rounding_TXT.Dock = System.Windows.Forms.DockStyle.Right
        Me.Rounding_TXT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Rounding_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Rounding_TXT.Font_Size = 10
        Me.Rounding_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.Rounding_TXT.Format_ = "dd-MM-yyyy"
        Me.Rounding_TXT.Keydown_Support = True
        Me.Rounding_TXT.Location = New System.Drawing.Point(470, 0)
        Me.Rounding_TXT.Msg_Object = Nothing
        Me.Rounding_TXT.Name = "Rounding_TXT"
        Me.Rounding_TXT.Select_Auto_Show = True
        Me.Rounding_TXT.Select_Column_Color = "NA"
        Me.Rounding_TXT.Select_Columns = 0
        Me.Rounding_TXT.Select_Filter = "Name LIKE '%<value>%'"
        Me.Rounding_TXT.Select_Hide_Columns = "NA"
        Me.Rounding_TXT.Select_Object = Nothing
        Me.Rounding_TXT.Select_Source = Nothing
        Me.Rounding_TXT.Size = New System.Drawing.Size(145, 19)
        Me.Rounding_TXT.TabIndex = 4
        Me.Rounding_TXT.Type_ = "Select"
        Me.Rounding_TXT.Val_max = 1000000000
        Me.Rounding_TXT.Val_min = 0
        '
        'Rounding_Limit
        '
        Me.Rounding_Limit.Auto_Cleane = True
        Me.Rounding_Limit.Back_color = System.Drawing.Color.White
        Me.Rounding_Limit.BackColor = System.Drawing.Color.White
        Me.Rounding_Limit.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Rounding_Limit.Data_Link_ = ""
        Me.Rounding_Limit.Decimal_ = 2
        Me.Rounding_Limit.Dock = System.Windows.Forms.DockStyle.Right
        Me.Rounding_Limit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Rounding_Limit.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Rounding_Limit.Font_Size = 10
        Me.Rounding_Limit.Font_Style = System.Drawing.FontStyle.Bold
        Me.Rounding_Limit.Format_ = "dd-MM-yyyy"
        Me.Rounding_Limit.Keydown_Support = True
        Me.Rounding_Limit.Location = New System.Drawing.Point(615, 0)
        Me.Rounding_Limit.Msg_Object = Nothing
        Me.Rounding_Limit.Name = "Rounding_Limit"
        Me.Rounding_Limit.Select_Auto_Show = True
        Me.Rounding_Limit.Select_Column_Color = "NA"
        Me.Rounding_Limit.Select_Columns = 0
        Me.Rounding_Limit.Select_Filter = "Name LIKE '%<value>%'"
        Me.Rounding_Limit.Select_Hide_Columns = "NA"
        Me.Rounding_Limit.Select_Object = Nothing
        Me.Rounding_Limit.Select_Source = Nothing
        Me.Rounding_Limit.Size = New System.Drawing.Size(90, 19)
        Me.Rounding_Limit.TabIndex = 5
        Me.Rounding_Limit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Rounding_Limit.Type_ = "Num"
        Me.Rounding_Limit.Val_max = 1000000000
        Me.Rounding_Limit.Val_min = 0
        '
        'vouchers_type_class_ledger_list_ctrl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.Rounding_TXT)
        Me.Controls.Add(Me.Dft_TXT)
        Me.Controls.Add(Me.calulation_TXT)
        Me.Controls.Add(Me.Ledger_TXT)
        Me.Controls.Add(Me.Rounding_Limit)
        Me.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "vouchers_type_class_ledger_list_ctrl"
        Me.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Size = New System.Drawing.Size(710, 16)
        CType(Me.Calculation_Source, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ledger_Source, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rounding_Source, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Ledger_TXT As Tools.TXT
    Friend WithEvents Calculation_Source As BindingSource
    Friend WithEvents Ledger_Source As BindingSource
    Friend WithEvents calulation_TXT As Tools.TXT
    Friend WithEvents Dft_TXT As Tools.TXT
    Friend WithEvents Rounding_TXT As Tools.TXT
    Friend WithEvents rounding_Source As BindingSource
    Public WithEvents Rounding_Limit As Tools.TXT
End Class
