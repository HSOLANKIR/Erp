Imports Tools

Module Select_TXT_mod
    Public Enum Select_List
        Botom = 0
        Right = 1
        Right_Dock = 2
        Botom_Center = 3
    End Enum
    Public Enum Select_List_Format
        Custome = 0
        Defolt = 1
        Singel = 2
    End Enum
    Public Function List_Setup(Head As String, Type_ As Select_List, format As Select_List_Format, sender As TXT, obj As List_frm, Source_ As BindingSource, With_ As Integer, ParamArray parameters() As String)
        With obj

            .TopMost = True
            .Width = With_
            .List_Head_TXT.Text = Head
            .TX = sender
            .Type_ = Type_

            .List_Grid.DataSource = Nothing
            .Source = Source_
            .List_Grid.DataSource = .Source


            .Style_()

            sender.Select_Object = obj
            sender.Select_Source = Source_

            Select_TXT_Format_set(obj, format, parameters)

            .Size_()

            AddHandler sender.GotFocus, AddressOf Select_TXT_Enter
            AddHandler sender.LostFocus, AddressOf Select_TXT_LostFocus
            AddHandler sender.KeyDown, AddressOf Select_TXT_KeyDown
            AddHandler sender.PreviewKeyDown, AddressOf Select_TXT__PreviewKeyDown

        End With
    End Function

    Private Sub Select_TXT__PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs)
        If e.KeyData = Keys.Tab Or e.KeyData = Keys.Enter Then
            'sender.SelectNextControl(sender, True, True, False, False)
            'e.IsInputKey = True
        End If
    End Sub
    Private Function Select_TXT_Format_set(obj As List_frm, type_ As Select_List_Format, ParamArray parameters() As String)
        If type_ = 1 Then
            Dim c1 As New DataGridViewCellStyle
            c1.Alignment = DataGridViewContentAlignment.MiddleLeft


            Dim c2 As New DataGridViewCellStyle
            c2.Alignment = DataGridViewContentAlignment.MiddleRight
            c2.Font = New Font("Arial", 10, FontStyle.Italic)

            With obj
                For Each col As DataGridViewColumn In .List_Grid.Columns
                    col.Visible = False
                Next
                .List_Grid.Columns(0).DefaultCellStyle = c1
                .List_Grid.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .List_Grid.Columns(1).DefaultCellStyle = c2
                .List_Grid.Columns(1).Width = 130

                .List_Grid.Columns(0).Visible = True
                .List_Grid.Columns(1).Visible = True
            End With

            For i As Integer = 0 To parameters.Length - 1
                Dim name As String = parameters(i).Split("|")(0)
                Dim shotr As String = parameters(i).Split("|")(1)

                obj.Paramert_grid.Rows.Add(name, shotr)
            Next
        ElseIf type_ = 2 Then
            Dim c1 As New DataGridViewCellStyle
            c1.Alignment = DataGridViewContentAlignment.MiddleLeft


            With obj
                For Each col As DataGridViewColumn In .List_Grid.Columns
                    col.Visible = False
                Next
                .List_Grid.Columns(0).DefaultCellStyle = c1
                .List_Grid.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                .List_Grid.Columns(0).Visible = True
            End With

            For i As Integer = 0 To parameters.Length - 1
                Dim name As String = parameters(i).Split("|")(0)
                Dim shotr As String = parameters(i).Split("|")(1)

                obj.Paramert_grid.Rows.Add(name, shotr)
            Next
        End If
    End Function

    Private Sub Select_TXT_Enter(sender As Object, e As EventArgs)
        If sender.Type_ = "Select" Then
            sender.Select_Object.Show()
        End If
    End Sub
    Private Sub Select_TXT_LostFocus(sender As Object, e As EventArgs)
        sender.Select_Object.Visible = False
    End Sub
    Private Sub Select_TXT_KeyDown(sender As Object, e As KeyEventArgs)
        If sender.Type_ = "Select" Then
            If e.KeyCode = Keys.Space Then
                If sender.Select_Object.Visible = False Then
                    sender.Select_Object.Visible = True
                End If
            End If
            If e.KeyCode = Keys.Enter Then
                sender.Select_Object.Visible = False
                sender.Text = sender.Select_Object.List_Grid.CurrentRow.Cells(sender.Select_Columns).Value.ToString
            End If
        End If
    End Sub
End Module
