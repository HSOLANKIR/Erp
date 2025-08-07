Public Class Rate_Set_popup
    Dim Unit_Compund As Boolean
    Public Unit_ID As String
    Public Path_End As String
    Dim VC_Type_ As String
    Public Item_ID As String
    Public Unit As String
    Public obj As Object
    Private Sub Rate_Set_popup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ctrl As New std_rate_ctrl
        Ctrl1 = ctrl
        With ctrl
            Panel8.Controls.Add(Ctrl1)
            .Dock = DockStyle.Fill
        End With
        ctrl = New std_rate_ctrl
        Ctrl2 = ctrl
        With ctrl
            Panel9.Controls.Add(Ctrl2)
            .Dock = DockStyle.Fill
        End With

        Label5.Text = Stock_Item_frm.Name_TXT.Text


    End Sub
    Dim Ctrl1 As std_rate_ctrl
    Dim Ctrl2 As std_rate_ctrl
    Private Sub Rate_Set_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        Button_Clear()
    End Sub
    Private Sub Grid__CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub Grid__CellEnter(sender As Object, e As DataGridViewCellEventArgs)
        List_frm.Dispose()
    End Sub
    Private Function Chack_Current_(ro As DataGridViewRow) As Boolean

        Return True
    End Function
    Dim Unit_Type As String
    Private Function Unit_Filter(ro As DataGridViewRow, cell As Integer)
        ro.Cells(cell).Value = Unit
    End Function

    Public Function Display_Fill_All()
        For Each ro As DataGridViewRow In Stock_Item_frm.DataGridView3.Rows
            Dim Type_ As String = ro.Cells(0).Value
            Dim Date_ As String = CDate(ro.Cells(1).Value).ToString("dd-MM-yyyy")
            Dim Rate_ As String = ro.Cells(2).Value
            Dim Unit_ As String = Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "Symbol", $"ID = '{ro.Cells(3).Value}'")


            If Type_ = "Cost" Then
                With Ctrl1
                    .Add_New(CDate(Date_).ToString(Date_Format_fech), Rate_, Unit_)
                End With
            ElseIf Type_ = "Price" Then
                With Ctrl2
                    .Add_New(CDate(Date_).ToString(Date_Format_fech), Rate_, Unit_)
                End With
            End If
        Next



        With Ctrl1
            If .platform.Controls.Count = 0 Then
                .Add_New(CDate(Company_Book_frm).ToString(Date_Format_fech), "", Stock_Item_frm.Unit_TXT.Text)
            End If
        End With
        With Ctrl2
            If .platform.Controls.Count = 0 Then
                .Add_New(CDate(Company_Book_frm).ToString(Date_Format_fech), "", Stock_Item_frm.Unit_TXT.Text)
            End If
        End With

    End Function

    Private Sub Txt1_TextChanged(sender As Object, e As EventArgs) Handles Txt1.TextChanged

    End Sub

    Private Sub Txt1_Enter(sender As Object, e As EventArgs) Handles Txt1.Enter
        Save_data()
        Me.Dispose()
        obj.Focus()
        SendKeys.Send("{TAB}")
        'SendKeys.Send("{TAB}")
    End Sub
    Private Function Save_data()
        With Stock_Item_frm
            .DataGridView3.Rows.Clear()

            Dim P_ As New Queue(Of Panel)()
            For Each bg_p As Panel In Ctrl1.platform.Controls.OfType(Of Panel)()
                P_.Enqueue(bg_p)
            Next
            For Each bg_p As Panel In P_.Reverse
                Dim idx As Integer = Ctrl1.Find_Idx(bg_p)

                If Ctrl1.Find_Date_TXT(idx).Text <> Nothing Then
                    Dim Type_ As String = "Cost"
                    Dim Date_ As String = CDate(Ctrl1.Find_Date_TXT(idx).Text).ToString("dd-MM-yyyy")
                    Dim Rate_ As String = Ctrl1.Find_Rate_TXT(idx).Text
                    Dim Unit_ As String = Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "ID", $"Symbol = '{Ctrl1.Find_Unit_TXT(idx).Text}'")


                    .DataGridView3.Rows.Add(Type_, Date_, Rate_, Unit_)
                End If
            Next
            P_.Clear()

            For Each bg_p As Panel In Ctrl2.platform.Controls.OfType(Of Panel)()
                P_.Enqueue(bg_p)
            Next
            For Each bg_p As Panel In P_.Reverse
                Dim idx As Integer = Ctrl2.Find_Idx(bg_p)

                If Ctrl2.Find_Date_TXT(idx).Text <> Nothing Then
                    Dim Type_ As String = "Price"
                    Dim Date_ As String = CDate(Ctrl2.Find_Date_TXT(idx).Text).ToString("dd-MM-yyyy")
                    Dim Rate_ As String = Ctrl2.Find_Rate_TXT(idx).Text
                    Dim Unit_ As String = Find_DT_Value(Database_File.cre, "TBL_Inventory_Unit", "ID", $"Symbol = '{Ctrl1.Find_Unit_TXT(idx).Text}'")


                    .DataGridView3.Rows.Add(Type_, Date_, Rate_, Unit_)
                End If
            Next
        End With

    End Function
End Class
