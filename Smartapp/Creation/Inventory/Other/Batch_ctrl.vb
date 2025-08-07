Imports System.Data.SQLite
Imports System.Xml
Imports Tools
Public Class Batch_ctrl
    Public ID_ As Integer
    Public Unit_ As String
    Private Sub BOM_ctrl_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Function Fill_data_source()
        Dim cn As New SQLiteConnection

        If platform.Controls.OfType(Of Panel).ToList.Count = 0 Then
            Add_New("", "", 0)
        End If

    End Function
    Dim idx_S As Integer = 0
    Public Function Add_New(st As String, data_ As String, Production_qty As Decimal)
        idx_S = platform.Controls.OfType(Of Panel).ToList.Count + 1
        Dim bg_p As Panel = New Panel
        Dim particuls_txt As TXT = New TXT
        Dim item_data As Label = New Label
        Dim Procustion_Qty As Label = New Label

        bg_p.Controls.Add(particuls_txt)
        bg_p.Controls.Add(item_data)
        bg_p.Controls.Add(Procustion_Qty)
        bg_p.Dock = System.Windows.Forms.DockStyle.Top
        bg_p.Location = New System.Drawing.Point(0, 0)
        bg_p.Name = "bg_" & idx_S
        bg_p.TabIndex = idx_S
        bg_p.Size = New System.Drawing.Size(903, 30)
        bg_p.Padding = New Padding(10, 10, 10, 10)

        'AddHandler bg_p.Enter, AddressOf bg_panel_Enter
        'AddHandler bg_p.Leave, AddressOf bg_panel_Leave


        item_data.Name = $"data_" & idx_S
        item_data.Text = data_
        item_data.Visible = False

        Procustion_Qty.Name = $"ProcustionQty_" & idx_S
        Procustion_Qty.Text = Production_qty
        Procustion_Qty.Visible = False


        particuls_txt.Back_color = Color.White
        particuls_txt.BackColor = Color.White
        particuls_txt.BorderStyle = System.Windows.Forms.BorderStyle.None
        particuls_txt.Data_Link_ = ""
        particuls_txt.Dock = System.Windows.Forms.DockStyle.Fill
        particuls_txt.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        particuls_txt.Keydown_Support = False
        particuls_txt.Name = $"Particulstxt_" & idx_S
        particuls_txt.Size = New System.Drawing.Size(512, 17)
        particuls_txt.TabIndex = 0
        particuls_txt.Type_ = "TXT"
        particuls_txt.Text = st

        AddHandler particuls_txt.KeyDown, AddressOf particuls_Keydown

        platform.Controls.Add(bg_p)
        bg_p.BringToFront()

    End Function
    Private Sub particuls_Keydown(sender As Object, e As KeyEventArgs)
        Dim index As Integer = Find_Idx(sender)
        If e.KeyCode = Keys.Enter Then
            Set_data(sender)
            If platform.Controls.Count = index Then
                If Find_Particuls_TXT(Find_Idx(sender)).Text <> Nothing Then
                    Add_New("", "", 0)
                    Inventory_BOM.ctrl_manag(sender.Text)
                    Inventory_BOM.Load_Item_Data(index)
                Else
                    Inventory_BOM.Save_List()
                    'Inventory_BOM.Back_Obj.Focus()
                    Inventory_BOM.Dispose()
                    SendKeys.Send("{TAB}")
                End If
            Else
                If sender.Text = Nothing Then
                    platform.Controls.Remove(sender)
                    Exit Sub
                Else
                    Inventory_BOM.ctrl_manag(sender.Text)
                    Inventory_BOM.Load_Item_Data(index)
                End If

            End If
        End If
        Dim i As Integer = sender.Name.Split("_")(1)
        Dim t As String = sender.Name.Split("_")(0)

        If e.KeyCode = Keys.Up Then
            i -= 1
            Try
                CType(platform.Controls.Find((t & "_" & i), True).First, TXT).Focus()
            Catch ex As Exception

            End Try
        End If
        If e.KeyCode = Keys.Down Then
            i += 1
            Try
                CType(platform.Controls.Find((t & "_" & i), True).First, TXT).Focus()
            Catch ex As Exception

            End Try
        End If
    End Sub
    Private Function Set_data(sender As Object)
        Dim idx As Integer = Find_Idx(sender)
        Dim nodes As XmlNodeList = Inventory_BOM.dt_batch_item.DocumentElement.SelectNodes("/List/Batch")
        For Each node As XmlNode In nodes
            Dim batch_name As String = node.SelectSingleNode("Name").InnerText

        Next


    End Function
    Public Function Find_Idx(sender As Object) As Integer
        Try
            Return sender.Name.Split("_")(1)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Particuls_TXT(index As Integer) As TXT
        Try
            Return CType(bg_Panel.Controls.Find(($"Particulstxt_" & index), True).First, TXT)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Data_Lab(index As Integer) As Label
        Try
            Return CType(bg_Panel.Controls.Find(($"data_" & index), True).First, Label)
        Catch ex As Exception

        End Try
    End Function
    Public Function Find_Production_Qty_Lab(index As Integer) As Label
        Try
            Return CType(bg_Panel.Controls.Find(($"ProcustionQty_" & index), True).First, Label)
        Catch ex As Exception

        End Try
    End Function

    Private Sub Batch_ctrl_Enter(sender As Object, e As EventArgs) Handles Me.Enter

        Fill_data_source()
    End Sub
    Private Sub bg_panel_Enter(sender As Object, e As EventArgs)
        Dim col As Color = Color.FromArgb(254, 197, 48)
        sender.BackColor = col
        Dim idx As Integer = Find_Idx(sender)

        Find_Particuls_TXT(idx).Back_color = col

        Find_Particuls_TXT(idx).BackColor = col
    End Sub
    Private Sub bg_panel_Leave(sender As Object, e As EventArgs)
        Dim col As Color = platform.BackColor
        sender.BackColor = col

        Dim idx As Integer = Find_Idx(sender)
        Find_Particuls_TXT(idx).Back_color = col

        Find_Particuls_TXT(idx).BackColor = col
    End Sub
End Class
