Imports System.Data.SqlClient
Imports System.Data.SQLite

Public Class Stock_Item_MD_frm
    Dim Unit_Compund As Boolean
    Public Unit_ID As String
    Public Path_End As String
    Dim VC_Type_ As String
    Public Item_ID As String
    Private Sub Stock_Item_MD_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel1.Location = New Point(Me.ClientSize.Width / 2 - Panel1.Size.Width / 2, Me.ClientSize.Height / 2 - Panel1.Size.Height / 2)

        Path_End = BG_frm.BG_Path_TXT.Text

        BG_frm.HADE_TXT.Text = "Stock Item Configuration"

        Display_Fill_All()

        AlternateUnit_YN.Focus()
    End Sub
    Private Function Display_Fill_All()
        AlternateUnit_YN.Text = Find_DT_Value(Database_File.lnk, "TBL_Stock_Item", "Alter_Unit_YN", "ID = '1'")
        STD_YN.Text = Find_DT_Value(Database_File.lnk, "TBL_Stock_Item", "STD_Rate_YN", "ID = '1'")
        BOM_YN.Text = Find_DT_Value(Database_File.lnk, "TBL_Stock_Item", "BOM_YN", "ID = '1'")

    End Function

    Public Function Save_Change()
        If open_MSSQL(Database_File.lnk) Then
            qury = "UPDATE TBL_Stock_Item SET Alter_Unit_YN = @Alter_Unit_YN,STD_Rate_YN = @STD_Rate_YN,BOM_YN = @BOM_YN WHERE ID = '1'"
            cmd = New SQLiteCommand(qury, con)
            Try
                With cmd.Parameters
                    .AddWithValue("@Alter_Unit_YN", AlternateUnit_YN.Text.Trim)
                    .AddWithValue("@STD_Rate_YN", STD_YN.Text.Trim)
                    .AddWithValue("@BOM_YN", BOM_YN.Text.Trim)
                    cmd.ExecuteNonQuery()
                End With
            Catch ex As Exception
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Function

    Private Sub Stock_Item_MD_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.HADE_TXT.Text = "Stock Item Configuration"
        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text
    End Sub
End Class