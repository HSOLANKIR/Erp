Public Class HighPerformanceDataViewer
    Inherits UserControl

    Private WithEvents vScrollBar As New VScrollBar()
    Private panel As New Panel()
    Private dataItems As New List(Of String)()
    Private firstVisibleIndex As Integer = 0
    Private lastVisibleIndex As Integer = 0
    Private itemHeight As Integer = 30 ' Adjust based on your UserControl height

    Public Sub New()
        'InitializeComponent()
        SetupScrolling()
    End Sub

    Private Sub SetupScrolling()
        ' ScrollBar setup
        vScrollBar.Dock = DockStyle.Right
        vScrollBar.Width = 20

        ' Panel setup
        panel.Dock = DockStyle.Fill
        panel.AutoScroll = False

        Me.Controls.Add(panel)
        Me.Controls.Add(vScrollBar)
    End Sub

    Public Sub LoadData(data As List(Of String))
        dataItems = data

        ' Calculate scrollbar properties
        vScrollBar.Maximum = Math.Max(0, dataItems.Count * itemHeight - panel.Height)
        vScrollBar.LargeChange = panel.Height
        vScrollBar.SmallChange = itemHeight

        ' Load initial visible items
        UpdateVisibleItems()
    End Sub

    Private Sub UpdateVisibleItems()
        ' Calculate visible range
        Dim scrollPosition = vScrollBar.Value
        firstVisibleIndex = scrollPosition \ itemHeight
        lastVisibleIndex = Math.Min(dataItems.Count - 1, firstVisibleIndex + (panel.Height \ itemHeight) + 1)

        ' Clear existing controls (keep only visible ones)
        Dim controlsToRemove As New List(Of Control)
        For Each ctrl In panel.Controls
            If TypeOf ctrl Is UserControl1 Then
                Dim uc As UserControl1 = DirectCast(ctrl, UserControl1)
                If uc.DataIndex < firstVisibleIndex OrElse uc.DataIndex > lastVisibleIndex Then
                    controlsToRemove.Add(ctrl)
                End If
            End If
        Next

        For Each ctrl In controlsToRemove
            panel.Controls.Remove(ctrl)
            ctrl.Dispose()
        Next

        ' Add or update visible controls
        For i As Integer = firstVisibleIndex To lastVisibleIndex
            Dim existingControl = panel.Controls.OfType(Of UserControl1).
                                  FirstOrDefault(Function(uc) uc.DataIndex = i)

            If existingControl Is Nothing Then
                ' Create new control
                Dim newControl As New UserControl1()
                newControl.DataIndex = i
                newControl.SetData(dataItems(i))
                newControl.Top = i * itemHeight
                newControl.Left = 0
                newControl.Width = panel.Width - If(vScrollBar.Visible, vScrollBar.Width, 0)
                newControl.Height = itemHeight
                panel.Controls.Add(newControl)
            Else
                ' Update existing control if needed
                existingControl.SetData(dataItems(i))
            End If
        Next
    End Sub

    Private Sub vScrollBar_Scroll(sender As Object, e As ScrollEventArgs) Handles vScrollBar.Scroll
        UpdateVisibleItems()
    End Sub

    Private Sub HighPerformanceDataViewer_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If dataItems IsNot Nothing AndAlso dataItems.Count > 0 Then
            vScrollBar.Maximum = Math.Max(0, dataItems.Count * itemHeight - panel.Height)
            UpdateVisibleItems()
        End If
    End Sub
End Class