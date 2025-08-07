<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Database_repair_frm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Database_repair_frm))
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ProgressBag2 = New Tools.ProgressBag_Custom()
        Me.ProgressBag_Custom2 = New Tools.ProgressBag_Custom()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.ProgressBag_Custom1 = New Tools.ProgressBag_Custom()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.DamiDatabase_Background = New System.ComponentModel.BackgroundWorker()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Panel15 = New System.Windows.Forms.Panel()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Panel17 = New System.Windows.Forms.Panel()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Panel18 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Panel20 = New System.Windows.Forms.Panel()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.Panel21 = New System.Windows.Forms.Panel()
        Me.Panel7.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel12.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel15.SuspendLayout()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel8.SuspendLayout()
        Me.Panel13.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel17.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel14.SuspendLayout()
        Me.Panel20.SuspendLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(0, 256)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(405, 17)
        Me.Label6.TabIndex = 10
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'ProgressBag2
        '
        Me.ProgressBag2.BackColor = System.Drawing.Color.White
        Me.ProgressBag2.Display_Value = False
        Me.ProgressBag2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ProgressBag2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProgressBag2.Last_TXT = "%"
        Me.ProgressBag2.Location = New System.Drawing.Point(0, 313)
        Me.ProgressBag2.Margin = New System.Windows.Forms.Padding(4)
        Me.ProgressBag2.Maximum = 100
        Me.ProgressBag2.Name = "ProgressBag2"
        Me.ProgressBag2.Progress_color = System.Drawing.Color.Orange
        Me.ProgressBag2.Size = New System.Drawing.Size(405, 20)
        Me.ProgressBag2.TabIndex = 22
        Me.ProgressBag2.Value_ForColor = System.Drawing.Color.Black
        '
        'ProgressBag_Custom2
        '
        Me.ProgressBag_Custom2.BackColor = System.Drawing.Color.White
        Me.ProgressBag_Custom2.Display_Value = False
        Me.ProgressBag_Custom2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ProgressBag_Custom2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProgressBag_Custom2.Last_TXT = "%"
        Me.ProgressBag_Custom2.Location = New System.Drawing.Point(0, 338)
        Me.ProgressBag_Custom2.Margin = New System.Windows.Forms.Padding(4)
        Me.ProgressBag_Custom2.Maximum = 100
        Me.ProgressBag_Custom2.Name = "ProgressBag_Custom2"
        Me.ProgressBag_Custom2.Progress_color = System.Drawing.Color.Wheat
        Me.ProgressBag_Custom2.Size = New System.Drawing.Size(405, 10)
        Me.ProgressBag_Custom2.TabIndex = 23
        Me.ProgressBag_Custom2.Value_ForColor = System.Drawing.Color.Black
        '
        'Panel3
        '
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 333)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(405, 5)
        Me.Panel3.TabIndex = 16
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.Label10)
        Me.Panel7.Controls.Add(Me.Button2)
        Me.Panel7.Controls.Add(Me.Button1)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel7.Location = New System.Drawing.Point(0, 191)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(384, 40)
        Me.Panel7.TabIndex = 23
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(291, 12)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(23, 18)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "or"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.LightSalmon
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(318, 6)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(59, 29)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "No"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.PaleTurquoise
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(228, 6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(59, 29)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Yes"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(16, 144)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(353, 37)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Warning : Database will not work in older version software after updating"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Green
        Me.Label4.Location = New System.Drawing.Point(124, 107)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(129, 16)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = " : "
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(124, 86)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(129, 16)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = " : "
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label3.Location = New System.Drawing.Point(12, 107)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 16)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "New Version"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 86)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 16)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Current Version"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label11.Location = New System.Drawing.Point(0, 305)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(405, 17)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "|"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Panel9
        '
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel9.Location = New System.Drawing.Point(0, 322)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(405, 1)
        Me.Panel9.TabIndex = 15
        '
        'ProgressBag_Custom1
        '
        Me.ProgressBag_Custom1.BackColor = System.Drawing.Color.White
        Me.ProgressBag_Custom1.Display_Value = True
        Me.ProgressBag_Custom1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ProgressBag_Custom1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProgressBag_Custom1.Last_TXT = "%"
        Me.ProgressBag_Custom1.Location = New System.Drawing.Point(0, 323)
        Me.ProgressBag_Custom1.Margin = New System.Windows.Forms.Padding(4)
        Me.ProgressBag_Custom1.Maximum = 100
        Me.ProgressBag_Custom1.Name = "ProgressBag_Custom1"
        Me.ProgressBag_Custom1.Progress_color = System.Drawing.Color.Orange
        Me.ProgressBag_Custom1.Size = New System.Drawing.Size(405, 20)
        Me.ProgressBag_Custom1.TabIndex = 21
        Me.ProgressBag_Custom1.Value_ForColor = System.Drawing.Color.Black
        '
        'Panel10
        '
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel10.Location = New System.Drawing.Point(0, 343)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(405, 5)
        Me.Panel10.TabIndex = 19
        '
        'DamiDatabase_Background
        '
        Me.DamiDatabase_Background.WorkerReportsProgress = True
        Me.DamiDatabase_Background.WorkerSupportsCancellation = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Panel12)
        Me.Panel1.Controls.Add(Me.Panel15)
        Me.Panel1.Controls.Add(Me.Panel16)
        Me.Panel1.Location = New System.Drawing.Point(12, 520)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(734, 353)
        Me.Panel1.TabIndex = 11
        Me.Panel1.Visible = False
        '
        'Panel12
        '
        Me.Panel12.Controls.Add(Me.PictureBox5)
        Me.Panel12.Controls.Add(Me.Label6)
        Me.Panel12.Controls.Add(Me.Label5)
        Me.Panel12.Controls.Add(Me.Label18)
        Me.Panel12.Controls.Add(Me.Label20)
        Me.Panel12.Controls.Add(Me.ProgressBag2)
        Me.Panel12.Controls.Add(Me.Panel3)
        Me.Panel12.Controls.Add(Me.ProgressBag_Custom2)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel12.Location = New System.Drawing.Point(327, 0)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(405, 348)
        Me.Panel12.TabIndex = 105
        '
        'PictureBox5
        '
        Me.PictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox5.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox5.Image = Global.Management.My.Resources.Resources.Pending_animation_icn
        Me.PictureBox5.Location = New System.Drawing.Point(0, 77)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(405, 127)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox5.TabIndex = 102
        Me.PictureBox5.TabStop = False
        '
        'Label5
        '
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label5.Font = New System.Drawing.Font("Arial Black", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label5.Location = New System.Drawing.Point(0, 273)
        Me.Label5.Name = "Label5"
        Me.Label5.Padding = New System.Windows.Forms.Padding(0, 0, 0, 5)
        Me.Label5.Size = New System.Drawing.Size(405, 40)
        Me.Label5.TabIndex = 101
        Me.Label5.Text = "0%"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label18
        '
        Me.Label18.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label18.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.DimGray
        Me.Label18.Location = New System.Drawing.Point(0, 29)
        Me.Label18.Name = "Label18"
        Me.Label18.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.Label18.Size = New System.Drawing.Size(405, 48)
        Me.Label18.TabIndex = 97
        Me.Label18.Text = "<code file>"
        '
        'Label20
        '
        Me.Label20.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label20.Font = New System.Drawing.Font("Arial Black", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label20.Location = New System.Drawing.Point(0, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(405, 29)
        Me.Label20.TabIndex = 98
        Me.Label20.Text = "<code file>"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel15
        '
        Me.Panel15.Controls.Add(Me.PictureBox8)
        Me.Panel15.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel15.Location = New System.Drawing.Point(0, 0)
        Me.Panel15.Name = "Panel15"
        Me.Panel15.Size = New System.Drawing.Size(327, 348)
        Me.Panel15.TabIndex = 99
        '
        'PictureBox8
        '
        Me.PictureBox8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox8.Image = CType(resources.GetObject("PictureBox8.Image"), System.Drawing.Image)
        Me.PictureBox8.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(327, 348)
        Me.PictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox8.TabIndex = 1
        Me.PictureBox8.TabStop = False
        '
        'Panel16
        '
        Me.Panel16.BackColor = System.Drawing.Color.RoyalBlue
        Me.Panel16.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel16.Location = New System.Drawing.Point(0, 348)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(732, 3)
        Me.Panel16.TabIndex = 107
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.White
        Me.Panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel8.Controls.Add(Me.Panel13)
        Me.Panel8.Controls.Add(Me.Panel17)
        Me.Panel8.Controls.Add(Me.Panel18)
        Me.Panel8.Location = New System.Drawing.Point(12, 130)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(734, 353)
        Me.Panel8.TabIndex = 12
        Me.Panel8.Visible = False
        '
        'Panel13
        '
        Me.Panel13.Controls.Add(Me.Label11)
        Me.Panel13.Controls.Add(Me.Panel9)
        Me.Panel13.Controls.Add(Me.PictureBox1)
        Me.Panel13.Controls.Add(Me.Label15)
        Me.Panel13.Controls.Add(Me.ProgressBag_Custom1)
        Me.Panel13.Controls.Add(Me.Label16)
        Me.Panel13.Controls.Add(Me.Panel10)
        Me.Panel13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel13.Location = New System.Drawing.Point(327, 0)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(405, 348)
        Me.Panel13.TabIndex = 105
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Image = Global.Management.My.Resources.Resources.files_animation_gif
        Me.PictureBox1.Location = New System.Drawing.Point(0, 77)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(405, 127)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 102
        Me.PictureBox1.TabStop = False
        '
        'Label15
        '
        Me.Label15.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label15.Font = New System.Drawing.Font("Arial", 11.0!)
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(0, 29)
        Me.Label15.Name = "Label15"
        Me.Label15.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.Label15.Size = New System.Drawing.Size(405, 48)
        Me.Label15.TabIndex = 97
        Me.Label15.Text = "Creating a separate database of changes made to the database."
        '
        'Label16
        '
        Me.Label16.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label16.Font = New System.Drawing.Font("Arial Black", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.DarkOrchid
        Me.Label16.Location = New System.Drawing.Point(0, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(405, 29)
        Me.Label16.TabIndex = 98
        Me.Label16.Text = "Creates an Update Database."
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel17
        '
        Me.Panel17.Controls.Add(Me.PictureBox4)
        Me.Panel17.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel17.Location = New System.Drawing.Point(0, 0)
        Me.Panel17.Name = "Panel17"
        Me.Panel17.Size = New System.Drawing.Size(327, 348)
        Me.Panel17.TabIndex = 99
        '
        'PictureBox4
        '
        Me.PictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(327, 348)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox4.TabIndex = 1
        Me.PictureBox4.TabStop = False
        '
        'Panel18
        '
        Me.Panel18.BackColor = System.Drawing.Color.DarkOrchid
        Me.Panel18.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel18.Location = New System.Drawing.Point(0, 348)
        Me.Panel18.Name = "Panel18"
        Me.Panel18.Size = New System.Drawing.Size(732, 3)
        Me.Panel18.TabIndex = 107
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Panel14)
        Me.Panel4.Controls.Add(Me.Panel20)
        Me.Panel4.Controls.Add(Me.Panel21)
        Me.Panel4.Location = New System.Drawing.Point(766, 271)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(657, 236)
        Me.Panel4.TabIndex = 13
        Me.Panel4.Visible = False
        '
        'Panel14
        '
        Me.Panel14.Controls.Add(Me.Label14)
        Me.Panel14.Controls.Add(Me.Label17)
        Me.Panel14.Controls.Add(Me.Panel7)
        Me.Panel14.Controls.Add(Me.Label4)
        Me.Panel14.Controls.Add(Me.Label9)
        Me.Panel14.Controls.Add(Me.Label1)
        Me.Panel14.Controls.Add(Me.Label3)
        Me.Panel14.Controls.Add(Me.Label7)
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel14.Location = New System.Drawing.Point(271, 0)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(384, 231)
        Me.Panel14.TabIndex = 105
        '
        'Label14
        '
        Me.Label14.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.DimGray
        Me.Label14.Location = New System.Drawing.Point(0, 29)
        Me.Label14.Name = "Label14"
        Me.Label14.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.Label14.Size = New System.Drawing.Size(384, 48)
        Me.Label14.TabIndex = 97
        Me.Label14.Text = "<code file>"
        '
        'Label17
        '
        Me.Label17.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label17.Font = New System.Drawing.Font("Arial Black", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.DarkOrange
        Me.Label17.Location = New System.Drawing.Point(0, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(384, 29)
        Me.Label17.TabIndex = 98
        Me.Label17.Text = "<code file>"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel20
        '
        Me.Panel20.Controls.Add(Me.PictureBox6)
        Me.Panel20.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel20.Location = New System.Drawing.Point(0, 0)
        Me.Panel20.Name = "Panel20"
        Me.Panel20.Size = New System.Drawing.Size(271, 231)
        Me.Panel20.TabIndex = 99
        '
        'PictureBox6
        '
        Me.PictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(271, 231)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox6.TabIndex = 1
        Me.PictureBox6.TabStop = False
        '
        'Panel21
        '
        Me.Panel21.BackColor = System.Drawing.Color.DarkOrange
        Me.Panel21.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel21.Location = New System.Drawing.Point(0, 231)
        Me.Panel21.Name = "Panel21"
        Me.Panel21.Size = New System.Drawing.Size(655, 3)
        Me.Panel21.TabIndex = 107
        '
        'Database_repair_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Cornsilk
        Me.ClientSize = New System.Drawing.Size(1477, 1147)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel8)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Database_repair_frm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Database_repair_frm"
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel15.ResumeLayout(False)
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel8.ResumeLayout(False)
        Me.Panel13.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel17.ResumeLayout(False)
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel14.ResumeLayout(False)
        Me.Panel14.PerformLayout()
        Me.Panel20.ResumeLayout(False)
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Label10 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel9 As Panel
    Friend WithEvents DamiDatabase_Background As System.ComponentModel.BackgroundWorker
    Friend WithEvents Panel10 As Panel
    Friend WithEvents Label11 As Label
    Friend WithEvents ProgressBag_Custom1 As Tools.ProgressBag_Custom
    Friend WithEvents ProgressBag2 As Tools.ProgressBag_Custom
    Friend WithEvents ProgressBag_Custom2 As Tools.ProgressBag_Custom
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents Label18 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Panel15 As Panel
    Friend WithEvents PictureBox8 As PictureBox
    Friend WithEvents Panel16 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Panel13 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Panel17 As Panel
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents Panel18 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel14 As Panel
    Friend WithEvents Label14 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Panel20 As Panel
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents Panel21 As Panel
End Class
