Imports System.Data.SQLite
Imports Tools

Public Class Inventory_Features_ctrl
    Private Sub Inventory_Features_ctrl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Load()
        List_set()
        TableLayoutPanel1.Visible = YN_Boolean(Inventory_YN.Text)
    End Sub
    Public Function Load_()
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cmp, cn) = True Then
            cmd = New SQLiteCommand("Select * From TBL_Features where Type = 'Inventory'", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                Dim Head As String = r("Head").ToString
                Dim Vlu As String = r("Value").ToString
                Dim dec As String = r("Discription").ToString
                Applay_(Head, Vlu, dec)
            End While
            r.Close()
            cn.Close()
        End If
    End Function
    Dim ag_list As List_frm
    Private Function List_set()

    End Function
    Private Function Applay_(St As String, vlu As String, dec As String)
        Select Case St
            Case Batch_YN.Data_Link_
                Batch_YN.Text = vlu
            Case Godown_YN.Data_Link_
                Godown_YN.Text = vlu
            Case Inventory_YN.Data_Link_
                Inventory_YN.Text = vlu
            Case Purchase_YN.Data_Link_
                Purchase_YN.Text = vlu
            Case Sales_YN.Data_Link_
                Sales_YN.Text = vlu
            Case PO_YN.Data_Link_
                PO_YN.Text = vlu
            Case SO_YN.Data_Link_
                SO_YN.Text = vlu
            Case IR_YN.Data_Link_
                IR_YN.Text = vlu
            Case OR_YN.Data_Link_
                OR_YN.Text = vlu
            Case StockJournal_YN.Data_Link_
                StockJournal_YN.Text = vlu
            Case Barcode_YN.Data_Link_
                Barcode_YN.Text = vlu
            Case Reorder_YN.Data_Link_
                Reorder_YN.Text = vlu
            Case Category_YN.Data_Link_
                Category_YN.Text = vlu

        End Select
    End Function
    Public Function Save_()
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cmp, cn) = True Then
            Update_(cn, Batch_YN.Data_Link_, Batch_YN.Text, "")
            Update_(cn, Godown_YN.Data_Link_, Godown_YN.Text, "")
            Update_(cn, Category_YN.Data_Link_, Category_YN.Text, "")
            Update_(cn, Inventory_YN.Data_Link_, Inventory_YN.Text, "")

            Update_(cn, Purchase_YN.Data_Link_, Purchase_YN.Text, "")
            Update_(cn, Sales_YN.Data_Link_, Sales_YN.Text, "")
            Update_(cn, PO_YN.Data_Link_, PO_YN.Text, "")
            Update_(cn, SO_YN.Data_Link_, SO_YN.Text, "")
            Update_(cn, IR_YN.Data_Link_, IR_YN.Text, "")
            Update_(cn, OR_YN.Data_Link_, OR_YN.Text, "")
            Update_(cn, StockJournal_YN.Data_Link_, StockJournal_YN.Text, "")
            Update_(cn, Barcode_YN.Data_Link_, Barcode_YN.Text, "")
            Update_(cn, Reorder_YN.Data_Link_, Reorder_YN.Text, "")
            cn.Close()
        End If
    End Function
    Private Function Update_(cn As SQLiteConnection, Head As String, Vlu As String, dec As String)
        Dim create_ As Boolean = True
        cmd = New SQLiteCommand("Select * From TBL_Features WHERE Head = '" & Head & "' and Type = 'Inventory'", cn)
        Dim r As SQLiteDataReader
        r = cmd.ExecuteReader()
        While r.Read
            If Head = r("Head") Then
                create_ = False
            End If
        End While
        r.Close()


        If create_ = True Then
            cmd = New SQLiteCommand($"INSERT INTO TBL_Features (Head,Type)
VALUES('{Head}','Inventory')", cn)
            cmd.ExecuteNonQuery()
        End If



        qury = "UPDATE TBL_Features SET Value = '" & Vlu & "',Discription = '" & dec & "' WHERE Head = '" & Head & "' and Type = 'Inventory'"
        cmd = New SQLiteCommand(qury, cn)
        cmd.ExecuteNonQuery()

        Fill_Features_Mod(Head, Vlu, dec)
    End Function

    Private Sub Inventory_YN_KeyDown(sender As Object, e As KeyEventArgs) Handles Inventory_YN.KeyDown
        If e.KeyCode = Keys.Enter Then
            TableLayoutPanel1.Visible = YN_Boolean(Inventory_YN.Text)
        End If
    End Sub
End Class
