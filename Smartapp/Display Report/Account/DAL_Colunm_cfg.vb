Imports Tools

Public Class DAL_Colunm_cfg
    Public obj As Object
    Private Sub DAL_Colunm_cfg_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_()
    End Sub
    Public Function Load_()

        With obj

            Yn1.Text = Boolean_TXT(.col_cfg)
            Yn3.Text = Boolean_TXT(.Col_Rate_Details)
            Yn5.Text = Boolean_TXT(.Col_Amount_Details)
            Yn2.Text = Boolean_TXT(.Col_BuyerSupplier_Details)
            Yn4.Text = Boolean_TXT(.Col_ConsigneeParty_Details)
            Yn6.Text = Boolean_TXT(.Col_Qty_Details)
            Yn8.Text = Boolean_TXT(.Col_GSTValue_Details)
            Yn7.Text = Boolean_TXT(.Col_Voucher_Details)
            Yn10.Text = Boolean_TXT(.Col_Supplier_Voucher_Details)
            Yn12.Text = Boolean_TXT(.Col_Transport_Name)
            Yn11.Text = Boolean_TXT(.Col_Vehical_No)


            Panel7.Visible = YN_Boolean(Yn1.Text)

            .Fill_Grid()
        End With

    End Function

    Public Function Save_Data()

        Update_cfg(Database_File.lnk, "cfg_Accounting_Report", "Col_Cfg", Yn1.Text)
        Update_cfg(Database_File.lnk, "cfg_Accounting_Report", "Col_Buyer/Supplier Details", Yn2.Text)
        Update_cfg(Database_File.lnk, "cfg_Accounting_Report", "Consignee/Party_Details", Yn4.Text)
        Update_cfg(Database_File.lnk, "cfg_Accounting_Report", "Col_Quantity_Details", Yn6.Text)
        Update_cfg(Database_File.lnk, "cfg_Accounting_Report", "Col_Voucher_Details", Yn7.Text)
        Update_cfg(Database_File.lnk, "cfg_Accounting_Report", "Col_Supplier_Voucher_Details", Yn10.Text)
        Update_cfg(Database_File.lnk, "cfg_Accounting_Report", "Col_Rate_Details", Yn3.Text)
        Update_cfg(Database_File.lnk, "cfg_Accounting_Report", "Col_Amount_Details", Yn5.Text)
        Update_cfg(Database_File.lnk, "cfg_Accounting_Report", "Col_GSTValue_Details", Yn8.Text)

        Update_cfg(Database_File.lnk, "cfg_Accounting_Report", "Col_Vehicle_Number", Yn11.Text)
        Update_cfg(Database_File.lnk, "cfg_Accounting_Report", "Col_Transport_Name", Yn12.Text)

        Save_()
    End Function
    Public Function Save_()
        With obj
            .col_cfg = YN_Boolean(Yn1.Text)
            .Col_Rate_Details = YN_Boolean(Yn3.Text)
            .Col_Amount_Details = YN_Boolean(Yn5.Text)
            .Col_BuyerSupplier_Details = YN_Boolean(Yn2.Text)
            .Col_ConsigneeParty_Details = YN_Boolean(Yn4.Text)
            .Col_Qty_Details = YN_Boolean(Yn6.Text)
            .Col_GSTValue_Details = YN_Boolean(Yn8.Text)
            .Col_Voucher_Details = YN_Boolean(Yn7.Text)
            .Col_Supplier_Voucher_Details = YN_Boolean(Yn10.Text)
            .Col_Transport_Name = YN_Boolean(Yn12.Text)
            .Col_Vehical_No = YN_Boolean(Yn11.Text)
        End With
    End Function
    Private Sub Yn1_TextChanged(sender As Object, e As EventArgs)

    End Sub
    Private Sub Yn6_TextChanged(sender As Object, e As EventArgs) Handles Yn6.TextChanged
        Panel18.Visible = YN_Boolean(Yn6.Text)
        Panel14.Visible = YN_Boolean(Yn6.Text)
        Panel12.Visible = YN_Boolean(Yn6.Text)

        If Yn6.Text = "No" Then
            Yn3.Text = "No"
            Yn5.Text = "No"
            Yn8.Text = "No"
        End If
    End Sub

    Private Sub Yn1_TextChanged_1(sender As Object, e As EventArgs) Handles Yn1.TextChanged
        Panel7.Visible = YN_Boolean(Yn1.Text)
    End Sub
End Class
