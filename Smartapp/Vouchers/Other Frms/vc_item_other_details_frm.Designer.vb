<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class vc_item_other_details_frm
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
        Me.Vc_other_details_ctrl1 = New Management.vc_other_details_ctrl()
        Me.SAve_TXT = New Tools.TXT()
        Me.SuspendLayout()
        '
        'Vc_other_details_ctrl1
        '
        Me.Vc_other_details_ctrl1.BackColor = System.Drawing.Color.White
        Me.Vc_other_details_ctrl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Vc_other_details_ctrl1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Vc_other_details_ctrl1.Location = New System.Drawing.Point(174, 78)
        Me.Vc_other_details_ctrl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Vc_other_details_ctrl1.Name = "Vc_other_details_ctrl1"
        Me.Vc_other_details_ctrl1.Size = New System.Drawing.Size(647, 369)
        Me.Vc_other_details_ctrl1.TabIndex = 0
        '
        'SAve_TXT
        '
        Me.SAve_TXT.Auto_Cleane = True
        Me.SAve_TXT.Back_color = System.Drawing.Color.White
        Me.SAve_TXT.BackColor = System.Drawing.Color.White
        Me.SAve_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.SAve_TXT.Data_Link_ = ""
        Me.SAve_TXT.Decimal_ = 2
        Me.SAve_TXT.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.SAve_TXT.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.SAve_TXT.Font_Size = 10
        Me.SAve_TXT.Font_Style = System.Drawing.FontStyle.Bold
        Me.SAve_TXT.Format_ = "dd-MM-yyyy"
        Me.SAve_TXT.Keydown_Support = True
        Me.SAve_TXT.Location = New System.Drawing.Point(524, 474)
        Me.SAve_TXT.Msg_Object = Nothing
        Me.SAve_TXT.Name = "SAve_TXT"
        Me.SAve_TXT.Select_Auto_Show = True
        Me.SAve_TXT.Select_Column_Color = "NA"
        Me.SAve_TXT.Select_Columns = 0
        Me.SAve_TXT.Select_Filter = Nothing
        Me.SAve_TXT.Select_Hide_Columns = "NA"
        Me.SAve_TXT.Select_Object = Nothing
        Me.SAve_TXT.Select_Source = Nothing
        Me.SAve_TXT.Size = New System.Drawing.Size(0, 16)
        Me.SAve_TXT.TabIndex = 1
        Me.SAve_TXT.Type_ = "TXT"
        Me.SAve_TXT.Val_max = 1000000000
        Me.SAve_TXT.Val_min = 0
        '
        'vc_item_other_details_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LemonChiffon
        Me.ClientSize = New System.Drawing.Size(994, 525)
        Me.Controls.Add(Me.SAve_TXT)
        Me.Controls.Add(Me.Vc_other_details_ctrl1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "vc_item_other_details_frm"
        Me.Text = "vc_item_other_details_frm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Vc_other_details_ctrl1 As vc_other_details_ctrl
    Friend WithEvents SAve_TXT As Tools.TXT
End Class
