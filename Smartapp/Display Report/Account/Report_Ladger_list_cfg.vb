Imports System.Data.SQLite
Imports Tools
Public Class Report_Ladger_list_cfg
    Dim obj As Object
    Private Sub Report_Ladger_list_cfg_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_()
    End Sub
    Public Function Save_Data()
        Update_cfg(Database_File.lnk, "cfg_Accounting_Report_list", "Loans (Liability)", YNY.Text)
        Update_cfg(Database_File.lnk, "cfg_Accounting_Report_list", "Current Liabilities", Yn1.Text)
        Update_cfg(Database_File.lnk, "cfg_Accounting_Report_list", "Fixed Assets", Yn2.Text)
        Update_cfg(Database_File.lnk, "cfg_Accounting_Report_list", "Investments", Yn3.Text)
        Update_cfg(Database_File.lnk, "cfg_Accounting_Report_list", "Current Assets", Yn4.Text)
        Update_cfg(Database_File.lnk, "cfg_Accounting_Report_list", "Branch / Divisions", Yn5.Text)
        Update_cfg(Database_File.lnk, "cfg_Accounting_Report_list", "Misc. Expenses (ASSET)", Yn6.Text)
        Update_cfg(Database_File.lnk, "cfg_Accounting_Report_list", "Suspense A/c", Yn7.Text)
        Update_cfg(Database_File.lnk, "cfg_Accounting_Report_list", "Sales Accounts", Yn8.Text)
        Update_cfg(Database_File.lnk, "cfg_Accounting_Report_list", "Purchase Accounts", Yn9.Text)
        Update_cfg(Database_File.lnk, "cfg_Accounting_Report_list", "Direct Incomes", Yn10.Text)
        Update_cfg(Database_File.lnk, "cfg_Accounting_Report_list", "Direct Expenses", Yn11.Text)
        Update_cfg(Database_File.lnk, "cfg_Accounting_Report_list", "Indirect incomes", Yn12.Text)
        Update_cfg(Database_File.lnk, "cfg_Accounting_Report_list", "Indirect Expenses", Yn13.Text)
        Update_cfg(Database_File.lnk, "cfg_Accounting_Report_list", "Reserves & Surplus", Yn14.Text)
        Update_cfg(Database_File.lnk, "cfg_Accounting_Report_list", "Bank OD A/c", Yn15.Text)
        Update_cfg(Database_File.lnk, "cfg_Accounting_Report_list", "Secured Loans", Yn16.Text)
        Update_cfg(Database_File.lnk, "cfg_Accounting_Report_list", "Unsecured Loans", Yn17.Text)
        Update_cfg(Database_File.lnk, "cfg_Accounting_Report_list", "Duties & Taxes", Yn18.Text)
        Update_cfg(Database_File.lnk, "cfg_Accounting_Report_list", "Provisions", Yn19.Text)
        Update_cfg(Database_File.lnk, "cfg_Accounting_Report_list", "Stock-in-Hand", Yn20.Text)
        Update_cfg(Database_File.lnk, "cfg_Accounting_Report_list", "Deposits (Asset)", Yn21.Text)
        Update_cfg(Database_File.lnk, "cfg_Accounting_Report_list", "Loans & Advances (Asset)", Yn22.Text)
        Update_cfg(Database_File.lnk, "cfg_Accounting_Report_list", "Bank Accounts", Yn23.Text)

    End Function
    Public Function Load_()

        YNY.Text = Find_DT_Value(Database_File.lnk, "cfg_Accounting_Report_list", "Value", "Head = 'Loans (Liability)'")
        Yn1.Text = Find_DT_Value(Database_File.lnk, "cfg_Accounting_Report_list", "Value", "Head = 'Current Liabilities'")
        Yn2.Text = Find_DT_Value(Database_File.lnk, "cfg_Accounting_Report_list", "Value", "Head = 'Fixed Assets'")
        Yn3.Text = Find_DT_Value(Database_File.lnk, "cfg_Accounting_Report_list", "Value", "Head = 'Investments'")
        Yn4.Text = Find_DT_Value(Database_File.lnk, "cfg_Accounting_Report_list", "Value", "Head = 'Current Assets'")
        Yn5.Text = Find_DT_Value(Database_File.lnk, "cfg_Accounting_Report_list", "Value", "Head = 'Branch / Divisions'")
        Yn6.Text = Find_DT_Value(Database_File.lnk, "cfg_Accounting_Report_list", "Value", "Head = 'Misc. Expenses (ASSET)'")
        Yn7.Text = Find_DT_Value(Database_File.lnk, "cfg_Accounting_Report_list", "Value", "Head = 'Suspense A/c'")
        Yn8.Text = Find_DT_Value(Database_File.lnk, "cfg_Accounting_Report_list", "Value", "Head = 'Sales Accounts'")
        Yn9.Text = Find_DT_Value(Database_File.lnk, "cfg_Accounting_Report_list", "Value", "Head = 'Purchase Accounts'")
        Yn10.Text = Find_DT_Value(Database_File.lnk, "cfg_Accounting_Report_list", "Value", "Head = 'Direct Incomes'")
        Yn11.Text = Find_DT_Value(Database_File.lnk, "cfg_Accounting_Report_list", "Value", "Head = 'Direct Expenses'")
        Yn12.Text = Find_DT_Value(Database_File.lnk, "cfg_Accounting_Report_list", "Value", "Head = 'Indirect incomes'")
        Yn13.Text = Find_DT_Value(Database_File.lnk, "cfg_Accounting_Report_list", "Value", "Head = 'Indirect Expenses'")
        Yn14.Text = Find_DT_Value(Database_File.lnk, "cfg_Accounting_Report_list", "Value", "Head = 'Reserves & Surplus'")
        Yn15.Text = Find_DT_Value(Database_File.lnk, "cfg_Accounting_Report_list", "Value", "Head = 'Bank OD A/c'")
        Yn16.Text = Find_DT_Value(Database_File.lnk, "cfg_Accounting_Report_list", "Value", "Head = 'Secured Loans'")
        Yn17.Text = Find_DT_Value(Database_File.lnk, "cfg_Accounting_Report_list", "Value", "Head = 'Unsecured Loans'")
        Yn18.Text = Find_DT_Value(Database_File.lnk, "cfg_Accounting_Report_list", "Value", "Head = 'Duties & Taxes'")
        Yn19.Text = Find_DT_Value(Database_File.lnk, "cfg_Accounting_Report_list", "Value", "Head = 'Provisions'")
        Yn20.Text = Find_DT_Value(Database_File.lnk, "cfg_Accounting_Report_list", "Value", "Head = 'Stock-in-Hand'")
        Yn21.Text = Find_DT_Value(Database_File.lnk, "cfg_Accounting_Report_list", "Value", "Head = 'Deposits (Asset)'")
        Yn22.Text = Find_DT_Value(Database_File.lnk, "cfg_Accounting_Report_list", "Value", "Head = 'Loans & Advances (Asset)'")
        Yn23.Text = Find_DT_Value(Database_File.lnk, "cfg_Accounting_Report_list", "Value", "Head = 'Bank Accounts'")

    End Function
    Public Function Save_()

    End Function
    Private Sub Repoer_Ledger_cfg_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        Me.Focus()
    End Sub

End Class
