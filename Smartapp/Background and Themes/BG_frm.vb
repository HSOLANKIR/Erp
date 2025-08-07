Imports System.Data.SqlClient
Imports System.IO
Imports System.IO.FileInfo
Imports System.IO.DirectoryInfo
Imports System.ComponentModel

Public Class BG_frm
    Public Backgroud_Prossecc As Boolean = False
    Public From_ID As String = ""
    Public Active_Contols As List(Of Form) = New List(Of Form)()

    Private Sub BG_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Frm_Design(Me)
        Me.Icon = My.Resources.Erp_icn
        BG_PAN.Controls.Clear()
        'BG_Path_TXT.Text = "Smartapp"
        Logout_time = Auto_Logout_Sec
    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)
        If Msg_Yn("Are You Source", "Exit Application") = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs)
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If R_1.Text = "" Then
            R_1.Enabled = False
        Else
            R_1.Enabled = True
        End If

        If R_2.Text = "" Then
            R_2.Enabled = False
        Else
            R_2.Enabled = True
        End If

        If R_3.Text = "" Then
            R_3.Enabled = False
        Else
            R_3.Enabled = True
        End If

        If R_4.Text = "" Then
            R_4.Enabled = False
        Else
            R_4.Enabled = True
        End If

        If R_5.Text = "" Then
            R_5.Enabled = False
        Else
            R_5.Enabled = True
        End If

        If R_6.Text = "" Then
            R_6.Enabled = False
        Else
            R_6.Enabled = True
        End If

        If R_7.Text = "" Then
            R_7.Enabled = False
        Else
            R_7.Enabled = True
        End If

        If R_8.Text = "" Then
            R_8.Enabled = False
        Else
            R_8.Enabled = True
        End If

        If R_9.Text = "" Then
            R_9.Enabled = False
        Else
            R_9.Enabled = True
        End If

        If R_10.Text = "" Then
            R_10.Enabled = False
        Else
            R_10.Enabled = True
        End If

        If R_11.Text = "" Then
            R_11.Enabled = False
        Else
            R_11.Enabled = True
        End If

        If R_12.Text = "" Then
            R_12.Enabled = False
        Else
            R_12.Enabled = True
        End If

        If R_13.Text = "" Then
            R_13.Enabled = False
        Else
            R_13.Enabled = True
        End If

        If R_14.Text = "" Then
            R_14.Enabled = False
        Else
            R_14.Enabled = True
        End If

        If R_15.Text = "" Then
            R_15.Enabled = False
        Else
            R_15.Enabled = True
        End If

        If R_16.Text = "" Then
            R_16.Enabled = False
        Else
            R_16.Enabled = True
        End If

        If R_17.Text = "" Then
            R_17.Enabled = False
        Else
            R_17.Enabled = True
        End If

        If R_18.Text = "" Then
            R_18.Enabled = False
        Else
            R_18.Enabled = True
        End If

        If R_19.Text = "" Then
            R_19.Enabled = False
        Else
            R_19.Enabled = True
        End If

        If R_20.Text = "" Then
            R_20.Enabled = False
        Else
            R_20.Enabled = True
        End If

        If R_21.Text = "" Then
            R_21.Enabled = False
        Else
            R_21.Enabled = True
        End If

        If R_22.Text = "" Then
            R_22.Enabled = False
        Else
            R_22.Enabled = True
        End If


        If B_1.Text = "" Then
            B_1.Enabled = False
        Else
            B_1.Enabled = True
        End If

        If B_2.Text = "" Then
            B_2.Enabled = False
        Else
            B_2.Enabled = True
        End If

        If B_3.Text = "" Then
            B_3.Enabled = False
        Else
            B_3.Enabled = True
        End If

        If B_4.Text = "" Then
            B_4.Enabled = False
        Else
            B_4.Enabled = True
        End If

        If B_5.Text = "" Then
            B_5.Enabled = False
        Else
            B_5.Enabled = True
        End If

        If B_6.Text = "" Then
            B_6.Enabled = False
        Else
            B_6.Enabled = True
        End If

        If B_7.Text = "" Then
            B_7.Enabled = False
        Else
            B_7.Enabled = True
        End If

        If B_8.Text = "" Then
            B_8.Enabled = False
        Else
            B_8.Enabled = True
        End If

        If B_9.Text = "" Then
            B_9.Enabled = False
        Else
            B_9.Enabled = True
        End If

        If B_10.Text = "" Then
            B_10.Enabled = False
        Else
            B_10.Enabled = True
        End If

        If B_11.Text = "" Then
            B_11.Enabled = False
        Else
            B_11.Enabled = True
        End If


    End Sub
    Private Sub BG_frm_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        NOT_Clear()
    End Sub
    Private Sub BG_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Logout_time = Auto_Logout_Sec
        Label1.ForeColor = Color.Black
        Label1.BackColor = Panel1.BackColor
        Label1.Font = New Font("Arial", 14, FontStyle.Bold)

        If e.KeyCode = Keys.Escape Then
            If Panel11.Visible = False Then

            End If
        End If
    End Sub
    Private Sub adminViewForm_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        Logout_time = Auto_Logout_Sec
        Label1.ForeColor = Color.Black
        Label1.BackColor = Panel1.BackColor
        Label1.Font = New Font("Arial", 14, FontStyle.Bold)
    End Sub
    Private Sub Company_List_Grid_MouseDown(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            SendKeys.Send("{Enter}")
        End If
    End Sub

    Private Sub PictureBox1_Click_1(sender As Object, e As EventArgs)

    End Sub

    Dim Logout_time As Integer = 600
    Private Sub count_timer_Tick(sender As Object, e As EventArgs) Handles count_timer.Tick
        If Login_YN = True And Auto_Logout_YN = True Then
            Panel1.Visible = True
            If Logout_time <> 0 Then
                Logout_time -= 1

                Dim Min As Integer = Math.Floor(Logout_time / 60)
                Dim Sec As Integer = Logout_time - Math.Floor(Min * 60)
                Label1.Text = $"{Min.ToString("00")}:{Sec}"


                If Logout_time = 0 Then
                    My.Computer.Audio.Play(My.Resources.loagout_ton, AudioPlayMode.Background)
                    Label1.Text = $"Logout at {TimeOfDay.ToString("hh:mm:ss tt")}"
                    Label1.ForeColor = Color.Black
                    Label1.BackColor = Color.Orange
                    Label1.Font = New Font("Arial", 9.75, FontStyle.Bold)

                    Lock_System()
                End If

                If Logout_time <> 0 Then
                    If Logout_time = 30 Then
                        My.Computer.Audio.Play(My.Resources.dot_ton, AudioPlayMode.Background)
                    End If
                    If Logout_time <= 30 Then
                        If Label1.BackColor = Color.Red Then
                            Label1.ForeColor = Color.Black
                            Label1.BackColor = Panel1.BackColor
                            Label1.Font = New Font("Arial", 14, FontStyle.Bold)
                        Else
                            Label1.BackColor = Color.Red
                            Label1.ForeColor = Color.Black
                            Label1.Font = New Font("Arial", 18, FontStyle.Bold)
                        End If
                    ElseIf Logout_time <= 60 Then
                        Label1.ForeColor = Color.OrangeRed
                        Label1.BackColor = Panel1.BackColor
                    End If
                End If
            Else
            End If
        Else
            Panel1.Visible = False
        End If
    End Sub
    Private Function Lock_System()
        With Lock_frm
            .TopLevel = False
            Me.Controls.Add(Lock_frm)
            .Dock = DockStyle.Fill
            .Show()
            .BringToFront()
            .Focus()
        End With
    End Function

    Private Sub BG_frm_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged

    End Sub

    Private Sub BG_PAN_Paint(sender As Object, e As PaintEventArgs) Handles BG_PAN.Paint

    End Sub

    Private Sub BG_PAN_ControlRemoved(sender As Object, e As ControlEventArgs) Handles BG_PAN.ControlRemoved
        Try
            Active_Contols.Remove(e.Control)
        Catch ex As Exception

        End Try

        Focus_()
    End Sub
    Public Function Focus_()
        For Each obj As Object In Active_Contols
            Try
                obj.Focus()
            Catch ex As Exception

            End Try
        Next
    End Function
    Private Sub BG_PAN_ControlAdded(sender As Object, e As ControlEventArgs) Handles BG_PAN.ControlAdded
        Active_Contols.Add(e.Control)
    End Sub
End Class