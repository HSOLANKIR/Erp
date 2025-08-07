Imports System.Data.SQLite
Imports System.IO

Public Class Ledger_cfg
    Public obj As Object

    Private Sub Repoer_Ledger_cfg_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_()
        List_set()
    End Sub
    Public Function Load_()
        With obj
            Address_YN.Text = Boolean_TXT(.cfg_Address_YN)
            Bank_YN.Text = Boolean_TXT(.cfg_Bank_Details_YN)
            GST_YN.Text = Boolean_TXT(.cfg_GST_Details_YN)
            Credit_YN.Text = Boolean_TXT(.cfg_Credit_Limit_YN)
            Credit_Day_YN.Text = Boolean_TXT(.cfg_Credit_Days_YN)
        End With
    End Function
    Public Function Save_Data()
        Update_cfg(Database_File.lnk, "cfg_Ledger", "Address_YN", Address_YN.Text)
        Update_cfg(Database_File.lnk, "cfg_Ledger", "Bank_Details_YN", Bank_YN.Text)
        Update_cfg(Database_File.lnk, "cfg_Ledger", "GST_Details_YN", GST_YN.Text)
        Update_cfg(Database_File.lnk, "cfg_Ledger", "Credit_Limit_YN", Credit_YN.Text)
        Update_cfg(Database_File.lnk, "cfg_Ledger", "Credit_Days_YN", Credit_Day_YN.Text)
    End Function
    Private Function List_set()

    End Function
    Public Function Save_()
        With obj
            .cfg_Address_YN = YN_Boolean(Address_YN.Text)
            .cfg_Bank_Details_YN = YN_Boolean(Bank_YN.Text)
            .cfg_GST_Details_YN = YN_Boolean(GST_YN.Text)
            .cfg_Credit_Limit_YN = YN_Boolean(Credit_YN.Text)
            .cfg_Credit_Days_YN = YN_Boolean(Credit_Day_YN.Text)
        End With
    End Function
    Private Sub Branch_YN_TextChanged(sender As Object, e As EventArgs) Handles Address_YN.TextChanged

    End Sub

    Private Sub Repoer_Ledger_cfg_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        Me.Focus()
    End Sub

End Class
