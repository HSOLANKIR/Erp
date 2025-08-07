Public Class Inventory_Register_cfg
    Public obj As Object
    Private Sub Sales_Purchase_Report_cfg_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_()
    End Sub
    Public Function Load_()
        With obj
            Narration_YN.Text = Boolean_TXT(.Narration_YN)
            GST_YN.Text = Boolean_TXT(.GST_YN)

            Transport_YN.Text = Boolean_TXT(.Transport_YN)
            Tra_Name_YN.Text = Boolean_TXT(.Tra_Name_YN)
            Vehicle_Type_YN.Text = Boolean_TXT(.Vehicle_Type_YN)
            Vehicle_No_YN.Text = Boolean_TXT(.Vehicle_No_YN)
            Driver_YN.Text = Boolean_TXT(.Driver_YN)
            Driver_Phone_YN.Text = Boolean_TXT(.Driver_Phone_YN)

            path_TXT.Text = (.cfg_print_path)
            .Fill_Grid()
        End With
    End Function
    Public Function Save_Data()
        Update_cfg(Database_File.lnk, "cfg_Inventory_Register", "Print_Path", path_TXT.Text)
        Update_cfg(Database_File.lnk, "cfg_Inventory_Register", "Narration", Narration_YN.Text)
        Update_cfg(Database_File.lnk, "cfg_Inventory_Register", "GST Details", GST_YN.Text)
        Update_cfg(Database_File.lnk, "cfg_Inventory_Register", "Transport_Details", Transport_YN.Text)
        Update_cfg(Database_File.lnk, "cfg_Inventory_Register", "Transport_Name", Tra_Name_YN.Text)
        Update_cfg(Database_File.lnk, "cfg_Inventory_Register", "Vehicle_No", Vehicle_No_YN.Text)
        Update_cfg(Database_File.lnk, "cfg_Inventory_Register", "Vehicle_Type", Vehicle_Type_YN.Text)
        Update_cfg(Database_File.lnk, "cfg_Inventory_Register", "Driver Name", Driver_YN.Text)
        Update_cfg(Database_File.lnk, "cfg_Inventory_Register", "Driver Phone", Driver_Phone_YN.Text)
    End Function
    Public Function Save_()
        With obj
            .Narration_YN = YN_Boolean(Narration_YN.Text)
            .GST_YN = YN_Boolean(GST_YN.Text)

            .Transport_YN = YN_Boolean(Transport_YN.Text)
            .Tra_Name_YN = YN_Boolean(Tra_Name_YN.Text)
            .Vehicle_Type_YN = YN_Boolean(Vehicle_Type_YN.Text)
            .Vehicle_No_YN = YN_Boolean(Vehicle_No_YN.Text)
            .Driver_YN = YN_Boolean(Driver_YN.Text)
            .cfg_print_path = (path_TXT.Text)
            .Fill_Grid()
        End With
    End Function

    Private Sub Transport_YN_TextChanged(sender As Object, e As EventArgs) Handles Transport_YN.TextChanged
        T1.Visible = YN_Boolean(sender.Text)
        T2.Visible = YN_Boolean(sender.Text)
        T3.Visible = YN_Boolean(sender.Text)
        T4.Visible = YN_Boolean(sender.Text)
        T5.Visible = YN_Boolean(sender.Text)
    End Sub
End Class
