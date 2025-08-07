Imports System.ComponentModel
Imports System.Data.SQLite

Public Class Whatsapp_setup

    Public focus_YN As Boolean = False
    Public focus_Obj As Object
    Private Sub Whatsapp_setup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_data()
        API_TXT.Focus()
    End Sub
    Private Function Load_data()

    End Function
    Private Sub Whatsapp_setup_Enter(sender As Object, e As EventArgs) Handles Me.Enter

        API_TXT.Focus()
    End Sub

    Private Sub Whatsapp_setup_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = DialogResult.Cancel
        End If
    End Sub

    Private Sub Whatsapp_setup_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        'Add_Hander_Remove_Handel(False)
        Frm_foCus()

        If focus_YN = True Then
            focus_Obj.Focus()
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)
        obj_center(sender, Me)
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs)



    End Sub
    Dim objBase64Codec As New Base64Codec
    Dim Login_type As String = ""

    Private Function Panel_Manage(pa As Panel)
        Login_P.Visible = False

        pa.Visible = True
    End Function
    Private Sub Login_Panel_Paint(sender As Object, e As PaintEventArgs)
        obj_center(sender, Me)
    End Sub
    Dim qr_ As String

    Private Sub Success_P_Paint(sender As Object, e As PaintEventArgs)
        obj_center(sender, Me)
    End Sub

    Private Function Update_Data()
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cfgs, cn) = True Then
            Update_(cn, "Whatsapp_API", API_TXT.Text, "")
            Update_(cn, "Whatsapp_Number", Number_TXT.Text, "")
        End If
    End Function

    Private Function Update_(cn As SQLiteConnection, Head As String, Vlu As String, dec As String)
        Dim create_ As Boolean = True
        cmd = New SQLiteCommand($"Select * From TBL_Features WHERE Head = '{Head }' and Type = 'General'", cn)
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
VALUES('{Head}','General')", cn)
            cmd.ExecuteNonQuery()
        End If

        qury = $"UPDATE TBL_Features SET Value = '{Vlu }',Discription = '{dec}' WHERE Head = '{Head }' and Type = 'General'"
        cmd = New SQLiteCommand(qury, cn)
        cmd.ExecuteNonQuery()

        Fill_Features_Mod(Head, Vlu, dec)
    End Function

    Private Sub Retry_P_Paint(sender As Object, e As PaintEventArgs)
        obj_center(sender, Me)
    End Sub

    Private Sub Whatsapp_setup_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        API_TXT.Focus()
    End Sub

    Private Sub Whatsapp_setup_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Me.Dispose()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        Me.Dispose()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Button1.Visible = False
        'Label6.Visible = False
        'Label8.Visible = True
        'BackgroundWorker1.RunWorkerAsync()


        WhatsApp_Qr_Login_dialoag.ShowDialog()

    End Sub

    Private Sub API_TXT_TextChanged(sender As Object, e As EventArgs) Handles API_TXT.TextChanged, Number_TXT.TextChanged
        Label6.Visible = False
        Label8.Visible = False
        If API_TXT.Text = Nothing Or Number_TXT.Text = Nothing Then
            Button1.Visible = False
        Else
            Button1.Visible = True
        End If
    End Sub

    Dim testing_bool As Boolean = False
    Private Sub BackgroundWorker1_DoWork_1(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            testing_bool = Whatsapp_login_YN(API_TXT.Text, Number_TXT.Text)
        Catch ex As Exception
            testing_bool = False
        End Try

    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Label6.Visible = True
        Button1.Visible = True
        Label8.Visible = False

        If testing_bool = True Then
            Label6.ForeColor = Color.Green
            Label6.Text = "Connection Ok"
        Else
            Label6.ForeColor = Color.Red
            Label6.Text = "Connection is not Ok"
        End If
    End Sub

    Private Sub Login_P_Paint(sender As Object, e As PaintEventArgs) Handles Login_P.Paint
        obj_center(sender, Me)
    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click
        Process.Start("https://wh.cryptonixtechnology.in/en/register")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Update_Data()
        Me.DialogResult = DialogResult.OK
    End Sub
End Class
