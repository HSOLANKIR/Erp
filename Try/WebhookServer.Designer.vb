<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class WebhookServer
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Public Sub New()
        MyBase.New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub

    ' NOTE: The following procedure is required by the Windows Form Designer
    ' It can be modified using the Windows Form Designer.
    ' Do not modify it using the code editor.
    <System.Diagnostics.DebuggerNonUserCode()>
    Private Sub InitializeComponent()
        Me.btnToggleServer = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'btnToggleServer
        '
        Me.btnToggleServer.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnToggleServer.Location = New System.Drawing.Point(12, 12)
        Me.btnToggleServer.Name = "btnToggleServer"
        Me.btnToggleServer.Size = New System.Drawing.Size(150, 40)
        Me.btnToggleServer.TabIndex = 0
        Me.btnToggleServer.Text = "Start Server"
        Me.btnToggleServer.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(168, 12)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(354, 238)
        Me.ListBox1.TabIndex = 1
        '
        'WebhookServer
        '
        Me.ClientSize = New System.Drawing.Size(584, 411)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.btnToggleServer)
        Me.Name = "WebhookServer"
        Me.Text = "VB.NET Webhook Listener"
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents btnToggleServer As System.Windows.Forms.Button
    Friend WithEvents ListBox1 As ListBox
End Class
