<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class journal_controls
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
        Me.components = New System.ComponentModel.Container()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.bg_panel = New System.Windows.Forms.Panel()
        Me.bg_ = New System.Windows.Forms.Panel()
        Me.balancepanel_ = New System.Windows.Forms.Panel()
        Me.BalValue_ = New System.Windows.Forms.Label()
        Me.BalLabel_ = New System.Windows.Forms.Label()
        Me.ParticulsPanel_ = New System.Windows.Forms.Panel()
        Me.particulstxt_ = New Tools.TXT()
        Me.drtxt_ = New Tools.TXT()
        Me.crtxt_ = New Tools.TXT()
        Me.crdrtxt_ = New Tools.TXT()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.CL_Dr = New System.Windows.Forms.Label()
        Me.CL_Cr = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.BindingSource2 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel1.SuspendLayout()
        Me.bg_.SuspendLayout()
        Me.balancepanel_.SuspendLayout()
        Me.ParticulsPanel_.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel12.SuspendLayout()
        CType(Me.BindingSource2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 46)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1204, 20)
        Me.Panel1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 2)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(40, 0, 0, 0)
        Me.Label1.Size = New System.Drawing.Size(1004, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Particulars"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(1004, 2)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 17)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Debit"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(1104, 2)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Credit"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.LightGray
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 19)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1204, 1)
        Me.Panel2.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Silver
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1204, 2)
        Me.Panel3.TabIndex = 2
        '
        'Panel8
        '
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel8.Location = New System.Drawing.Point(0, 66)
        Me.Panel8.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(1204, 6)
        Me.Panel8.TabIndex = 5
        '
        'bg_panel
        '
        Me.bg_panel.AutoScroll = True
        Me.bg_panel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bg_panel.Location = New System.Drawing.Point(0, 72)
        Me.bg_panel.Margin = New System.Windows.Forms.Padding(4)
        Me.bg_panel.Name = "bg_panel"
        Me.bg_panel.Size = New System.Drawing.Size(1204, 487)
        Me.bg_panel.TabIndex = 6
        '
        'bg_
        '
        Me.bg_.Controls.Add(Me.balancepanel_)
        Me.bg_.Controls.Add(Me.ParticulsPanel_)
        Me.bg_.Dock = System.Windows.Forms.DockStyle.Top
        Me.bg_.Location = New System.Drawing.Point(0, 0)
        Me.bg_.Margin = New System.Windows.Forms.Padding(4)
        Me.bg_.Name = "bg_"
        Me.bg_.Size = New System.Drawing.Size(1204, 46)
        Me.bg_.TabIndex = 7
        Me.bg_.Visible = False
        '
        'balancepanel_
        '
        Me.balancepanel_.Controls.Add(Me.BalValue_)
        Me.balancepanel_.Controls.Add(Me.BalLabel_)
        Me.balancepanel_.Dock = System.Windows.Forms.DockStyle.Top
        Me.balancepanel_.Location = New System.Drawing.Point(0, 20)
        Me.balancepanel_.Margin = New System.Windows.Forms.Padding(4)
        Me.balancepanel_.Name = "balancepanel_"
        Me.balancepanel_.Size = New System.Drawing.Size(1204, 20)
        Me.balancepanel_.TabIndex = 1
        '
        'BalValue_
        '
        Me.BalValue_.AutoSize = True
        Me.BalValue_.Dock = System.Windows.Forms.DockStyle.Left
        Me.BalValue_.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BalValue_.ForeColor = System.Drawing.Color.DimGray
        Me.BalValue_.Location = New System.Drawing.Point(173, 0)
        Me.BalValue_.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.BalValue_.Name = "BalValue_"
        Me.BalValue_.Size = New System.Drawing.Size(102, 15)
        Me.BalValue_.TabIndex = 3
        Me.BalValue_.Text = "Current Balance :"
        Me.BalValue_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BalLabel_
        '
        Me.BalLabel_.Dock = System.Windows.Forms.DockStyle.Left
        Me.BalLabel_.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BalLabel_.ForeColor = System.Drawing.Color.DimGray
        Me.BalLabel_.Location = New System.Drawing.Point(0, 0)
        Me.BalLabel_.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.BalLabel_.Name = "BalLabel_"
        Me.BalLabel_.Padding = New System.Windows.Forms.Padding(27, 0, 0, 0)
        Me.BalLabel_.Size = New System.Drawing.Size(173, 20)
        Me.BalLabel_.TabIndex = 2
        Me.BalLabel_.Text = "Current Balance :"
        Me.BalLabel_.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'ParticulsPanel_
        '
        Me.ParticulsPanel_.Controls.Add(Me.particulstxt_)
        Me.ParticulsPanel_.Controls.Add(Me.drtxt_)
        Me.ParticulsPanel_.Controls.Add(Me.crtxt_)
        Me.ParticulsPanel_.Controls.Add(Me.crdrtxt_)
        Me.ParticulsPanel_.Dock = System.Windows.Forms.DockStyle.Top
        Me.ParticulsPanel_.Location = New System.Drawing.Point(0, 0)
        Me.ParticulsPanel_.Margin = New System.Windows.Forms.Padding(4)
        Me.ParticulsPanel_.Name = "ParticulsPanel_"
        Me.ParticulsPanel_.Size = New System.Drawing.Size(1204, 20)
        Me.ParticulsPanel_.TabIndex = 0
        '
        'particulstxt_
        '
        Me.particulstxt_.Auto_Cleane = True
        Me.particulstxt_.Back_color = System.Drawing.Color.White
        Me.particulstxt_.BackColor = System.Drawing.Color.White
        Me.particulstxt_.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.particulstxt_.Data_Link_ = ""
        Me.particulstxt_.Decimal_ = 2
        Me.particulstxt_.Dock = System.Windows.Forms.DockStyle.Fill
        Me.particulstxt_.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.particulstxt_.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.particulstxt_.Font_Size = 11
        Me.particulstxt_.Font_Style = System.Drawing.FontStyle.Bold
        Me.particulstxt_.Format_ = "dd-MM-yyyy"
        Me.particulstxt_.Keydown_Support = True
        Me.particulstxt_.Location = New System.Drawing.Point(47, 0)
        Me.particulstxt_.Margin = New System.Windows.Forms.Padding(4)
        Me.particulstxt_.Msg_Object = Nothing
        Me.particulstxt_.Name = "particulstxt_"
        Me.particulstxt_.Select_Auto_Show = True
        Me.particulstxt_.Select_Column_Color = "NA"
        Me.particulstxt_.Select_Columns = 0
        Me.particulstxt_.Select_Filter = Nothing
        Me.particulstxt_.Select_Hide_Columns = "NA"
        Me.particulstxt_.Select_Object = Nothing
        Me.particulstxt_.Select_Source = Nothing
        Me.particulstxt_.Size = New System.Drawing.Size(816, 14)
        Me.particulstxt_.TabIndex = 4
        Me.particulstxt_.Text = "Particuls"
        Me.particulstxt_.Type_ = "TXT"
        Me.particulstxt_.Val_max = 1000000000
        Me.particulstxt_.Val_min = 0
        '
        'drtxt_
        '
        Me.drtxt_.Auto_Cleane = True
        Me.drtxt_.Back_color = System.Drawing.Color.White
        Me.drtxt_.BackColor = System.Drawing.Color.White
        Me.drtxt_.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.drtxt_.Data_Link_ = ""
        Me.drtxt_.Decimal_ = 2
        Me.drtxt_.Dock = System.Windows.Forms.DockStyle.Right
        Me.drtxt_.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.drtxt_.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.drtxt_.Font_Size = 11
        Me.drtxt_.Font_Style = System.Drawing.FontStyle.Bold
        Me.drtxt_.Format_ = "dd-MM-yyyy"
        Me.drtxt_.Keydown_Support = True
        Me.drtxt_.Location = New System.Drawing.Point(863, 0)
        Me.drtxt_.Margin = New System.Windows.Forms.Padding(4)
        Me.drtxt_.Msg_Object = Nothing
        Me.drtxt_.Name = "drtxt_"
        Me.drtxt_.Select_Auto_Show = True
        Me.drtxt_.Select_Column_Color = "NA"
        Me.drtxt_.Select_Columns = 0
        Me.drtxt_.Select_Filter = Nothing
        Me.drtxt_.Select_Hide_Columns = "NA"
        Me.drtxt_.Select_Object = Nothing
        Me.drtxt_.Select_Source = Nothing
        Me.drtxt_.Size = New System.Drawing.Size(173, 14)
        Me.drtxt_.TabIndex = 3
        Me.drtxt_.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.drtxt_.Type_ = "TXT"
        Me.drtxt_.Val_max = 1000000000
        Me.drtxt_.Val_min = 0
        '
        'crtxt_
        '
        Me.crtxt_.Auto_Cleane = True
        Me.crtxt_.Back_color = System.Drawing.Color.White
        Me.crtxt_.BackColor = System.Drawing.Color.White
        Me.crtxt_.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.crtxt_.Data_Link_ = ""
        Me.crtxt_.Decimal_ = 2
        Me.crtxt_.Dock = System.Windows.Forms.DockStyle.Right
        Me.crtxt_.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.crtxt_.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.crtxt_.Font_Size = 11
        Me.crtxt_.Font_Style = System.Drawing.FontStyle.Bold
        Me.crtxt_.Format_ = "dd-MM-yyyy"
        Me.crtxt_.Keydown_Support = True
        Me.crtxt_.Location = New System.Drawing.Point(1036, 0)
        Me.crtxt_.Margin = New System.Windows.Forms.Padding(4)
        Me.crtxt_.Msg_Object = Nothing
        Me.crtxt_.Name = "crtxt_"
        Me.crtxt_.Select_Auto_Show = True
        Me.crtxt_.Select_Column_Color = "NA"
        Me.crtxt_.Select_Columns = 0
        Me.crtxt_.Select_Filter = Nothing
        Me.crtxt_.Select_Hide_Columns = "NA"
        Me.crtxt_.Select_Object = Nothing
        Me.crtxt_.Select_Source = Nothing
        Me.crtxt_.Size = New System.Drawing.Size(168, 14)
        Me.crtxt_.TabIndex = 2
        Me.crtxt_.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.crtxt_.Type_ = "TXT"
        Me.crtxt_.Val_max = 1000000000
        Me.crtxt_.Val_min = 0
        '
        'crdrtxt_
        '
        Me.crdrtxt_.Auto_Cleane = True
        Me.crdrtxt_.Back_color = System.Drawing.Color.White
        Me.crdrtxt_.BackColor = System.Drawing.Color.White
        Me.crdrtxt_.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.crdrtxt_.Data_Link_ = ""
        Me.crdrtxt_.Decimal_ = 2
        Me.crdrtxt_.Dock = System.Windows.Forms.DockStyle.Left
        Me.crdrtxt_.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.crdrtxt_.Font_ = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.crdrtxt_.Font_Size = 11
        Me.crdrtxt_.Font_Style = System.Drawing.FontStyle.Bold
        Me.crdrtxt_.Format_ = "dd-MM-yyyy"
        Me.crdrtxt_.Keydown_Support = True
        Me.crdrtxt_.Location = New System.Drawing.Point(0, 0)
        Me.crdrtxt_.Margin = New System.Windows.Forms.Padding(4)
        Me.crdrtxt_.Msg_Object = Nothing
        Me.crdrtxt_.Name = "crdrtxt_"
        Me.crdrtxt_.Select_Auto_Show = True
        Me.crdrtxt_.Select_Column_Color = "NA"
        Me.crdrtxt_.Select_Columns = 0
        Me.crdrtxt_.Select_Filter = Nothing
        Me.crdrtxt_.Select_Hide_Columns = "NA"
        Me.crdrtxt_.Select_Object = Nothing
        Me.crdrtxt_.Select_Source = Nothing
        Me.crdrtxt_.Size = New System.Drawing.Size(47, 14)
        Me.crdrtxt_.TabIndex = 1
        Me.crdrtxt_.Text = "Cr"
        Me.crdrtxt_.Type_ = "TXT"
        Me.crdrtxt_.Val_max = 1000000000
        Me.crdrtxt_.Val_min = 0
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 559)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1204, 40)
        Me.Panel4.TabIndex = 8
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel9, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel7, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(911, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(293, 40)
        Me.TableLayoutPanel1.TabIndex = 12
        '
        'Panel9
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel9, 2)
        Me.Panel9.Controls.Add(Me.Label4)
        Me.Panel9.Controls.Add(Me.Label5)
        Me.Panel9.Controls.Add(Me.Panel10)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel9.Location = New System.Drawing.Point(0, 20)
        Me.Panel9.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(293, 20)
        Me.Panel9.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(-1, 0)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(147, 19)
        Me.Label4.TabIndex = 14
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(146, 0)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(147, 19)
        Me.Label5.TabIndex = 13
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel10
        '
        Me.Panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel10.Location = New System.Drawing.Point(0, 19)
        Me.Panel10.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(293, 1)
        Me.Panel10.TabIndex = 12
        '
        'Panel7
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel7, 2)
        Me.Panel7.Controls.Add(Me.CL_Dr)
        Me.Panel7.Controls.Add(Me.CL_Cr)
        Me.Panel7.Controls.Add(Me.Panel5)
        Me.Panel7.Controls.Add(Me.Panel6)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(293, 20)
        Me.Panel7.TabIndex = 11
        '
        'CL_Dr
        '
        Me.CL_Dr.Dock = System.Windows.Forms.DockStyle.Right
        Me.CL_Dr.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CL_Dr.Location = New System.Drawing.Point(-1, 1)
        Me.CL_Dr.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.CL_Dr.Name = "CL_Dr"
        Me.CL_Dr.Size = New System.Drawing.Size(147, 18)
        Me.CL_Dr.TabIndex = 14
        Me.CL_Dr.Text = "0.00"
        Me.CL_Dr.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CL_Cr
        '
        Me.CL_Cr.Dock = System.Windows.Forms.DockStyle.Right
        Me.CL_Cr.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CL_Cr.Location = New System.Drawing.Point(146, 1)
        Me.CL_Cr.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.CL_Cr.Name = "CL_Cr"
        Me.CL_Cr.Size = New System.Drawing.Size(147, 18)
        Me.CL_Cr.TabIndex = 13
        Me.CL_Cr.Text = "0.00"
        Me.CL_Cr.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel5.Location = New System.Drawing.Point(0, 19)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(293, 1)
        Me.Panel5.TabIndex = 12
        '
        'Panel6
        '
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(293, 1)
        Me.Panel6.TabIndex = 11
        '
        'Panel12
        '
        Me.Panel12.Controls.Add(Me.Panel11)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel12.Location = New System.Drawing.Point(0, 599)
        Me.Panel12.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(1204, 10)
        Me.Panel12.TabIndex = 9
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.LightGray
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel11.Location = New System.Drawing.Point(0, 9)
        Me.Panel11.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(1204, 1)
        Me.Panel11.TabIndex = 14
        '
        'journal_controls
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.bg_panel)
        Me.Controls.Add(Me.Panel8)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.bg_)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel12)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "journal_controls"
        Me.Size = New System.Drawing.Size(1204, 609)
        Me.Panel1.ResumeLayout(False)
        Me.bg_.ResumeLayout(False)
        Me.balancepanel_.ResumeLayout(False)
        Me.balancepanel_.PerformLayout()
        Me.ParticulsPanel_.ResumeLayout(False)
        Me.ParticulsPanel_.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel9.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel12.ResumeLayout(False)
        CType(Me.BindingSource2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel8 As Panel
    Friend WithEvents bg_panel As Panel
    Friend WithEvents bg_ As Panel
    Friend WithEvents balancepanel_ As Panel
    Friend WithEvents BalValue_ As Label
    Friend WithEvents BalLabel_ As Label
    Friend WithEvents ParticulsPanel_ As Panel
    Friend WithEvents particulstxt_ As Tools.TXT
    Friend WithEvents drtxt_ As Tools.TXT
    Friend WithEvents crtxt_ As Tools.TXT
    Friend WithEvents crdrtxt_ As Tools.TXT
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents CL_Dr As Label
    Friend WithEvents CL_Cr As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel10 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents Panel11 As Panel
    Friend WithEvents BindingSource2 As BindingSource
End Class
