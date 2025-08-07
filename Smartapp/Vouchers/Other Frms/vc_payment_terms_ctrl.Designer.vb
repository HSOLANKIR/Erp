<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class vc_payment_terms_ctrl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.Label36 = New System.Windows.Forms.Label()
        Me.terms_of_payment_txt = New Tools.TXT()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.terms_of_dilivry_txt = New Tools.TXT()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.other_reference_txt = New Tools.TXT()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel8.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(175, 28)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(11, 16)
        Me.Label36.TabIndex = 5
        Me.Label36.Text = ":"
        '
        'terms_of_payment_txt
        '
        Me.terms_of_payment_txt.Auto_Cleane = True
        Me.terms_of_payment_txt.Back_color = System.Drawing.Color.White
        Me.terms_of_payment_txt.BackColor = System.Drawing.Color.White
        Me.terms_of_payment_txt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.terms_of_payment_txt.Data_Link_ = ""
        Me.terms_of_payment_txt.Decimal_ = 2
        Me.terms_of_payment_txt.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.terms_of_payment_txt.Font_Size = 11
        Me.terms_of_payment_txt.Font_Style = System.Drawing.FontStyle.Bold
        Me.terms_of_payment_txt.Format_ = "dd-MM-yyyy"
        Me.terms_of_payment_txt.Keydown_Support = True
        Me.terms_of_payment_txt.Location = New System.Drawing.Point(190, 28)
        Me.terms_of_payment_txt.Msg_Object = Nothing
        Me.terms_of_payment_txt.Name = "terms_of_payment_txt"
        Me.terms_of_payment_txt.Select_Auto_Show = True
        Me.terms_of_payment_txt.Select_Column_Color = "NA"
        Me.terms_of_payment_txt.Select_Columns = 0
        Me.terms_of_payment_txt.Select_Filter = " "
        Me.terms_of_payment_txt.Select_Hide_Columns = "NA"
        Me.terms_of_payment_txt.Select_Object = Nothing
        Me.terms_of_payment_txt.Select_Source = Nothing
        Me.terms_of_payment_txt.Size = New System.Drawing.Size(171, 15)
        Me.terms_of_payment_txt.TabIndex = 0
        Me.terms_of_payment_txt.Type_ = "TXT"
        Me.terms_of_payment_txt.Val_max = 1000000000
        Me.terms_of_payment_txt.Val_min = 0
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(8, 28)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(148, 16)
        Me.Label37.TabIndex = 3
        Me.Label37.Text = "Mode/Terms of Payment"
        '
        'Label38
        '
        Me.Label38.BackColor = System.Drawing.Color.PaleTurquoise
        Me.Label38.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label38.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(0, 0)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(671, 22)
        Me.Label38.TabIndex = 2
        Me.Label38.Text = "Terms of Payment"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.LightSeaGreen
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(602, 84)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(68, 25)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Ok"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.Label3)
        Me.Panel8.Controls.Add(Me.terms_of_dilivry_txt)
        Me.Panel8.Controls.Add(Me.Label4)
        Me.Panel8.Controls.Add(Me.Label1)
        Me.Panel8.Controls.Add(Me.Label36)
        Me.Panel8.Controls.Add(Me.other_reference_txt)
        Me.Panel8.Controls.Add(Me.terms_of_payment_txt)
        Me.Panel8.Controls.Add(Me.Label2)
        Me.Panel8.Controls.Add(Me.Label37)
        Me.Panel8.Controls.Add(Me.Label38)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel8.Location = New System.Drawing.Point(0, 0)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(671, 81)
        Me.Panel8.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(175, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(11, 16)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = ":"
        '
        'terms_of_dilivry_txt
        '
        Me.terms_of_dilivry_txt.Auto_Cleane = True
        Me.terms_of_dilivry_txt.Back_color = System.Drawing.Color.White
        Me.terms_of_dilivry_txt.BackColor = System.Drawing.Color.White
        Me.terms_of_dilivry_txt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.terms_of_dilivry_txt.Data_Link_ = ""
        Me.terms_of_dilivry_txt.Decimal_ = 2
        Me.terms_of_dilivry_txt.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.terms_of_dilivry_txt.Font_Size = 11
        Me.terms_of_dilivry_txt.Font_Style = System.Drawing.FontStyle.Bold
        Me.terms_of_dilivry_txt.Format_ = "dd-MM-yyyy"
        Me.terms_of_dilivry_txt.Keydown_Support = True
        Me.terms_of_dilivry_txt.Location = New System.Drawing.Point(190, 47)
        Me.terms_of_dilivry_txt.Msg_Object = Nothing
        Me.terms_of_dilivry_txt.Multiline = True
        Me.terms_of_dilivry_txt.Name = "terms_of_dilivry_txt"
        Me.terms_of_dilivry_txt.Select_Auto_Show = True
        Me.terms_of_dilivry_txt.Select_Column_Color = "NA"
        Me.terms_of_dilivry_txt.Select_Columns = 0
        Me.terms_of_dilivry_txt.Select_Filter = " "
        Me.terms_of_dilivry_txt.Select_Hide_Columns = "NA"
        Me.terms_of_dilivry_txt.Select_Object = Nothing
        Me.terms_of_dilivry_txt.Select_Source = Nothing
        Me.terms_of_dilivry_txt.Size = New System.Drawing.Size(479, 28)
        Me.terms_of_dilivry_txt.TabIndex = 10
        Me.terms_of_dilivry_txt.Type_ = "TXT"
        Me.terms_of_dilivry_txt.Val_max = 1000000000
        Me.terms_of_dilivry_txt.Val_min = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 16)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Terms of Delivry"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(484, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(11, 16)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = ":"
        '
        'other_reference_txt
        '
        Me.other_reference_txt.Auto_Cleane = True
        Me.other_reference_txt.Back_color = System.Drawing.Color.White
        Me.other_reference_txt.BackColor = System.Drawing.Color.White
        Me.other_reference_txt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.other_reference_txt.Data_Link_ = ""
        Me.other_reference_txt.Decimal_ = 2
        Me.other_reference_txt.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.other_reference_txt.Font_Size = 11
        Me.other_reference_txt.Font_Style = System.Drawing.FontStyle.Bold
        Me.other_reference_txt.Format_ = "dd-MM-yyyy"
        Me.other_reference_txt.Keydown_Support = True
        Me.other_reference_txt.Location = New System.Drawing.Point(499, 29)
        Me.other_reference_txt.Msg_Object = Nothing
        Me.other_reference_txt.Name = "other_reference_txt"
        Me.other_reference_txt.Select_Auto_Show = True
        Me.other_reference_txt.Select_Column_Color = "NA"
        Me.other_reference_txt.Select_Columns = 0
        Me.other_reference_txt.Select_Filter = " "
        Me.other_reference_txt.Select_Hide_Columns = "NA"
        Me.other_reference_txt.Select_Object = Nothing
        Me.other_reference_txt.Select_Source = Nothing
        Me.other_reference_txt.Size = New System.Drawing.Size(171, 15)
        Me.other_reference_txt.TabIndex = 7
        Me.other_reference_txt.Type_ = "TXT"
        Me.other_reference_txt.Val_max = 1000000000
        Me.other_reference_txt.Val_min = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(366, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 16)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Other Reference"
        '
        'vc_payment_terms_ctrl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Panel8)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "vc_payment_terms_ctrl"
        Me.Size = New System.Drawing.Size(671, 110)
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label36 As Label
    Friend WithEvents terms_of_payment_txt As Tools.TXT
    Friend WithEvents Label37 As Label
    Friend WithEvents Label38 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents terms_of_dilivry_txt As Tools.TXT
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents other_reference_txt As Tools.TXT
End Class
