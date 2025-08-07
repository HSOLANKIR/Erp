Imports System.Data.SQLite
Imports System.IO

Public Class Item_cfg
    Public obj As Object

    Private Sub Repoer_Item_cfg_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_()
        List_set()
    End Sub
    Public Function Load_()
        With obj
            Description_Note_YN.Text = Boolean_TXT(.Discription_Note_YN)
            Alter_Unit_YN.Text = Boolean_TXT(.Alter_Unit_YN)
            GST_YN.Text = Boolean_TXT(.GST_YN)
            GST_Cess_YN.Text = Boolean_TXT(.Cess_YN)
            MRP_YN.Text = Boolean_TXT(.MRP_YN)
            Std_Rate_YN.Text = Boolean_TXT(.Std_Rate_YN)
            BOM_YN.Text = Boolean_TXT(.BOM_YN_)
        End With
    End Function
    Public Function Save_Data()
        Update_cfg(Database_File.lnk, "cfg_Item", "Discription/Note_YN", Description_Note_YN.Text)
        Update_cfg(Database_File.lnk, "cfg_Item", "Alternate_Units_YN", Alter_Unit_YN.Text)
        Update_cfg(Database_File.lnk, "cfg_Item", "Enable_GST_YN", GST_YN.Text)
        Update_cfg(Database_File.lnk, "cfg_Item", "Cess_Rate_YN", GST_Cess_YN.Text)
        Update_cfg(Database_File.lnk, "cfg_Item", "MRP_YN", MRP_YN.Text)
        Update_cfg(Database_File.lnk, "cfg_Item", "Standard_Rate_YN", Std_Rate_YN.Text)
        Update_cfg(Database_File.lnk, "cfg_Item", "BOM_YN", BOM_YN.Text)
        Update_cfg(Database_File.lnk, "cfg_Item", "Costing_Method_YN", Costing_Method_YN.Text)
        Update_cfg(Database_File.lnk, "cfg_Item", "Market_Valuation_YN", Market_Valuation_YN.Text)
    End Function
    Private Function List_set()

    End Function
    Public Function Save_()
        With Ledger_frm
            .cfg_Address_YN = YN_Boolean(Alter_Unit_YN.Text)
        End With
    End Function
    Private Sub Branch_YN_TextChanged(sender As Object, e As EventArgs) Handles Alter_Unit_YN.TextChanged

    End Sub

    Private Sub Repoer_Item_cfg_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        Me.Focus()
    End Sub

    Private Sub GST_YN_TextChanged(sender As Object, e As EventArgs) Handles GST_YN.TextChanged
        Panel3.Visible = YN_Boolean(sender.Text, False)
    End Sub
End Class
