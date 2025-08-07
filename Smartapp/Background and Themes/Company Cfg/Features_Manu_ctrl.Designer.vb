<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Features_Manu_ctrl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Features_Manu_ctrl))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Head = New System.Windows.Forms.Label()
        Me.Shortcut = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.img = New System.Windows.Forms.PictureBox()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.img, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(4, 55)
        Me.Panel1.TabIndex = 0
        '
        'Head
        '
        Me.Head.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Head.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Head.Location = New System.Drawing.Point(49, 5)
        Me.Head.Name = "Head"
        Me.Head.Size = New System.Drawing.Size(158, 45)
        Me.Head.TabIndex = 2
        Me.Head.Text = "Backup & Restore"
        Me.Head.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Head.UseMnemonic = False
        '
        'Shortcut
        '
        Me.Shortcut.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Shortcut.Dock = System.Windows.Forms.DockStyle.Right
        Me.Shortcut.Location = New System.Drawing.Point(207, 5)
        Me.Shortcut.Name = "Shortcut"
        Me.Shortcut.Padding = New System.Windows.Forms.Padding(0, 0, 4, 0)
        Me.Shortcut.Size = New System.Drawing.Size(43, 45)
        Me.Shortcut.TabIndex = 4
        Me.Shortcut.Text = "F35"
        Me.Shortcut.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel2
        '
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(49, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(201, 5)
        Me.Panel2.TabIndex = 6
        '
        'Panel3
        '
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(49, 50)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(201, 5)
        Me.Panel3.TabIndex = 7
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 18.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 18.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.img, 0, 0)
        Me.TableLayoutPanel1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(4, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(45, 55)
        Me.TableLayoutPanel1.TabIndex = 9
        '
        'img
        '
        Me.img.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.img.Dock = System.Windows.Forms.DockStyle.Fill
        Me.img.Image = CType(resources.GetObject("img.Image"), System.Drawing.Image)
        Me.img.Location = New System.Drawing.Point(8, 9)
        Me.img.Margin = New System.Windows.Forms.Padding(8, 9, 8, 9)
        Me.img.Name = "img"
        Me.img.Size = New System.Drawing.Size(29, 37)
        Me.img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.img.TabIndex = 3
        Me.img.TabStop = False
        '
        'Features_Manu_ctrl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Bisque
        Me.Controls.Add(Me.Head)
        Me.Controls.Add(Me.Shortcut)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Features_Manu_ctrl"
        Me.Size = New System.Drawing.Size(250, 55)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.img, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Head As Label
    Friend WithEvents Shortcut As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents img As PictureBox
End Class
