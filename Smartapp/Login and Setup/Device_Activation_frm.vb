Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.IO

Public Class Device_Activation_frm
    Dim From_ID As String
    Dim Company_ID As String
    Dim Company_Name As String
    Dim Company_Serial As String
    Dim Company_Email As String
    Dim Company_Class As String
    Dim Company_Logo As Image

    Dim Type_ As String
    Dim issuccess As Boolean
    Dim Path_End As String

    Public Unlock_Serial As String

    Private Sub Device_Activation_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        From_ID = New Random().Next()
        BG_frm.From_ID = From_ID

        Serial_TXT.Focus()
        BG_frm.HADE_TXT.Text = "Import Company"

        Path_End = BG_frm.BG_Path_TXT.Text
        BG_frm.BG_Path_TXT.Text &= "->Import Company"
        Add_Hander_Remove_Handel(True)

    End Sub
    Private Function Button_Manage()
        Button_Clear()
        BG_frm.R_3.Text = "F3 : Company Create"
        BG_frm.R_5.Text = "F5 : Forgot Serial"
    End Function
    Private Function Add_Hander_Remove_Handel(ans As Boolean)
        If ans = True Then
            AddHandler BG_frm.KeyDown, AddressOf Me.R_1_Keedown
            AddHandler BG_frm.R_3.Click, AddressOf Me.R_3_Click
            AddHandler BG_frm.R_5.Click, AddressOf Me.R_5_Click
        Else
            RemoveHandler BG_frm.KeyDown, AddressOf Me.R_1_Keedown
            RemoveHandler BG_frm.R_3.Click, AddressOf Me.R_3_Click
            RemoveHandler BG_frm.R_5.Click, AddressOf Me.R_5_Click
        End If

    End Function

    Private Sub R_3_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            With Company_Creation_frm
                .TopLevel = False
                BG_frm.BG_PAN.Controls.Add(Company_Creation_frm)
                .Show()
                .Dock = DockStyle.Fill
                .BringToFront()
                .Focus()
            End With
        End If
    End Sub
    Private Sub R_5_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            With Find_Serial_frm
                .TopLevel = False
                BG_frm.BG_PAN.Controls.Add(Find_Serial_frm)
                .Show()
                .Dock = DockStyle.Fill
                .BringToFront()
                .Focus()
            End With
        End If
    End Sub
    Private Sub R_4_Click(sender As Object, e As EventArgs)
        If BG_frm.From_ID = From_ID Then
            With Select_Company_frm
                .TopLevel = False
                BG_frm.BG_PAN.Controls.Add(Select_Company_frm)
                .Show()
                .Dock = DockStyle.Fill
                .BringToFront()
                .Focus()
            End With
        End If
    End Sub
    Private Sub R_1_Keedown(sender As Object, e As KeyEventArgs)
        If BG_frm.From_ID = From_ID Then
            If e.KeyCode = Keys.F3 Then
                BG_frm.R_3.PerformClick()
            End If
            If e.KeyCode = Keys.F5 Then
                    BG_frm.R_5.PerformClick()
                End If
            End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Hide_Panel(Serial_Panel, Serial_TXT)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim issuccess1 As Boolean = False
        Dim Activated As String

        Dim cn As New SqlConnection

        If Online_MSSQL(cn) = True Then
            qury = $"SELECT * FROM TBL_Lic_link_Cmp WHERE Company_Serial = '{Company_Serial }' AND License_No = '{LC_ID_str}'"
            Dim cmd As New SqlCommand(qury, cn)
            Dim r As SqlDataReader

            r = cmd.ExecuteReader
            While r.Read
                Activated = r("Status").ToString
                issuccess1 = True
            End While
            r.Close()


            If issuccess1 = True Then
                Msg_Custom_YN(NOT_Location.Bottom_Right, Color.DarkOrange, My.Resources.PC_Error_animation_icn, Dialoag_Button.Ok, "Duplicate!", "Company is already linked", $"'{Label11.Text}'<nl>is already linked to your license.<nl>If login is not done despite the link,<nl>then permission has to be taken from the admin of<nl>'{Label11.Text}'.")
                Serial_TXT.Focus()
                Exit Sub
            Else
            End If


            If Unlock_Serial = Serial_TXT.Text Then
                Hide_Panel(Device_Panel, TextBox1)
            Else
                If Email_Verification("Device Activation", "", Company_Email, "Device Activation", "", 500) = DialogResult.Yes Then
                    Hide_Panel(Device_Panel, TextBox1)

                End If
            End If

        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Hide_Panel(cmp_details_Panel, Button1)
    End Sub
    Private Function Hide_Panel(Pa As Panel, Ob As Object)
        Serial_Panel.Hide()
        cmp_details_Panel.Hide()
        Device_Panel.Hide()
        Load_Panel.Hide()
        Pa.Show()
        Pa.BringToFront()
        Ob.Focus()
    End Function

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        If Msg_Custom_YN(NOT_Location.Bottom_Right, Color.DarkCyan, My.Resources.Question_animation_icn, Dialoag_Button.Yes_No, "Question ?", "Are You Soure", "Send Activation Request") = DialogResult.Yes Then
            Dim cn As New SqlConnection
            Online_MSSQL(cn)
            Dim qry As String = "INSERT INTO TBL_Lic_link_Cmp (Company_Serial,License_No,PC_Name,Install,Status) VALUES (@Company_Serial,@License_No,@PC_Name,@Install,@Status)"
            Try
                Dim cmd As New SqlCommand(qry, cn)
                With cmd.Parameters
                    .AddWithValue("@Company_Serial", Serial_TXT.Text)
                    .AddWithValue("@License_No", LC_ID_str)
                    .AddWithValue("@PC_Name", TextBox1.Text)
                    .AddWithValue("@Install", Now.Date)
                    .AddWithValue("@Status", "Pending")
                    cmd.ExecuteNonQuery()

                    issuccess = True
                    Msg_Custom_YN(NOT_Location.Bottom_Right, Color.Green, My.Resources.Success_animation_icn, Dialoag_Button.Ok, "Successfully", "Successfully Sent Request", "Your request has been sent successfully,<nl> your company will be activated<nl>when the request is approved")
                    Me.Dispose()
                End With
            Catch ex As Exception
                issuccess = False
                Msg(NOT_Type.Erro, "Request Send Error", ex.Message)
            End Try
        End If
    End Sub

    Private Sub Device_Activation_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub Device_Activation_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        Button_Manage()
        Button_Enabled()
        Serial_TXT.Focus()
    End Sub

    Private Sub Serial_TXT_LostFocus(sender As Object, e As EventArgs)
        Lost_(sender)
    End Sub

    Private Sub Device_Activation_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End
        Add_Hander_Remove_Handel(False)
        Frm_foCus()
    End Sub

    Private Sub MaskedTextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles Serial_TXT.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Serial_TXT.Text = "" Then
                'Msg_InputError(Serial_TXT, "Serial No.")
                Exit Sub
            End If

            Hide_Panel(Load_Panel, Txt1)
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub
    Private Sub MaskedTextBox1_LostFocus(sender As Object, e As EventArgs)
        Lost_(sender)
    End Sub

    Private Sub Serial_Panel_Paint(sender As Object, e As PaintEventArgs) Handles Serial_Panel.Paint
        obj_center(sender, Me)
    End Sub

    Private Sub cmp_details_Panel_Paint(sender As Object, e As PaintEventArgs) Handles cmp_details_Panel.Paint
        obj_center(sender, Me)
    End Sub

    Private Sub Serial_TXT_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Device_Panel_Paint(sender As Object, e As PaintEventArgs) Handles Device_Panel.Paint
        obj_center(sender, Me)
    End Sub

    Private Sub Serial_TXT_TextChanged_1(sender As Object, e As EventArgs) Handles Serial_TXT.TextChanged

    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim cn As New SqlConnection
        If Online_MSSQL(cn) = True Then

            qury = $"SELECT * FROM TBL_Company_Creation WHERE CompanySerial = '{Serial_TXT.Text}' AND Approval = 'Approval'"
            Dim cmd As New SqlCommand(qury, cn)
            Dim r As SqlDataReader

            dt.Clear()
            dt.Columns.Clear()
            dt.Columns.Add("CompanyName")
            dt.Columns.Add("CompanySerial")
            dt.Columns.Add("UserName")
            dt.Columns.Add("Password")
            dt.Columns.Add("Class")
            dt.Columns.Add("Online")
            dt.Columns.Add("Email")

            r = cmd.ExecuteReader
            While r.Read
                dr = dt.NewRow
                dr("CompanyName") = r("CompanyName")
                dr("CompanySerial") = r("CompanySerial")
                dr("UserName") = r("UserName")
                dr("Password") = r("Password")
                dr("Class") = r("Class")
                dr("Online") = r("Online")
                dr("Email") = r("Email")
                dt.Rows.Add(dr)
                Company_Name = r("CompanyName")
                Company_Serial = r("CompanySerial")
                Company_Class = r("Class")
                Company_Email = r("Email")
                Company_ID = r("ID")

                Company_Logo = Nothing

                Try
                    Dim ms As New MemoryStream
                    Dim data As Byte() = DirectCast(r("Photo"), Byte())
                    ms = New MemoryStream(data)
                    Company_Logo = Image.FromStream(ms)
                Catch ex As Exception

                End Try

            End While
            BindingSource1.DataSource = dt
            r.Close()
        End If
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Label11.Text = Company_Name
        Label10.Text = Company_Serial
        Label9.Text = Company_Class
        If Label11.Text <> "" Then
            Try
                PictureBox3.Image = Company_Logo
            Catch ex As Exception

            End Try
            Hide_Panel(cmp_details_Panel, Button1)
        Else
            Hide_Panel(Serial_Panel, Serial_TXT)
            Msg_Custom_YN(NOT_Location.Bottom_Right, Color.Red, My.Resources.Error_animation_icn, Dialoag_Button.Ok, "Error", "Serial Number Error", "Company Not found,<nl>Please enter correct serial number")
        End If
    End Sub

    Private Sub Load_Panel_Paint(sender As Object, e As PaintEventArgs) Handles Load_Panel.Paint
        obj_center(sender, Me)
    End Sub

    Private Sub Device_Activation_frm_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        BG_frm.From_ID = From_ID
    End Sub
End Class