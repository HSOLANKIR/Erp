Imports System.ComponentModel
Imports System.IO
Imports System.Net.Http
Imports System.Threading.Tasks
Imports System.Web
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Newtonsoft.Json.Linq

Public Class WhatsApp_Qr_Login_dialoag
    Private Async Sub WhatsApp_Qr_Login_dialoag_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Get_Device()
    End Sub
    Private Async Function Get_Device() As Task
        Dim API_ As String = Whatsapp_setup.API_TXT.Text
        Dim Number_ As String = Whatsapp_setup.Number_TXT.Text

        If Label1.Text = "WhatsApp Connected" Or Label1.Text = "Processing" Then
            Label1.Text = "Chacking..."
            Await Device_GET($"https://wh.cryptonixtechnology.in/info-devices?number={Number_.Trim}&api_key={API_.Trim}")
        Else
            Await Qr_GET($"https://wh.cryptonixtechnology.in/generate-qr?device={Number_.Trim}&api_key={API_.Trim}")
        End If
    End Function

    Private Async Function Device_GET(url As String) As Task

        Using client As New HttpClient()
            Try
                Dim response As HttpResponseMessage = Await client.GetAsync(url)
                Dim responseBody As String = Await response.Content.ReadAsStringAsync()

                Dim r = JObject.Parse(responseBody)
                Dim Status As String = r.Item("status").ToString

                If response.IsSuccessStatusCode Then
                    Dim Status_Device As String = r("info")(0)("status").ToString()
                    If Status_Device = "Connected" Then
                        Label1.Text = "WhatsApp Connected"
                        Label1.ForeColor = Color.Green
                        PictureBox2.Image = My.Resources.link_gif
                        pic_manage(PictureBox2)
                        Button1.Visible = True
                        Waite_ = 8
                    ElseIf Status_Device = "Disconnect" Then
                        Label1.Text = "WhatsApp Disconnect"
                        Label1.ForeColor = Color.Red
                        PictureBox2.Image = My.Resources.nolink_gif
                        pic_manage(PictureBox2)
                        Button1.Visible = False
                        Waite_ = 1
                    End If
                Else
                    pic_manage(PictureBox2)
                    Label1.Text = "Number is Not Found, Please check Number or API Key"
                    Label1.ForeColor = Color.Red
                    PictureBox2.Image = My.Resources.notaccess_anumation_gif
                    Button1.Visible = False
                End If
            Catch ex As HttpRequestException
                MessageBox.Show($"Request Error: {ex.Message}", "HTTP GET Error")
            Catch ex As Exception
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error")
            End Try
        End Using
    End Function
    Private Async Function Qr_GET(url As String) As Task
        Using client As New HttpClient()
            Try
                Dim response As HttpResponseMessage = Await client.GetAsync(url)
                Dim responseBody As String = Await response.Content.ReadAsStringAsync()

                Dim r = JObject.Parse(responseBody)
                Dim Status As String = r.Item("status").ToString

                If response.IsSuccessStatusCode Then
                    If r.ContainsKey("qrcode") Then
                        Dim Qr_ As String = r.Item("qrcode").ToString
                        PictureBox1.Image = Base64ToImage(Qr_)
                        Label1.Text = "Scan Me on WhatsApp"
                        Label1.ForeColor = Color.Blue

                        Waite_ = 10
                        pic_manage(PictureBox1)
                        Button1.Visible = False
                    Else
                        If r.Item("message").ToString = "Processing" Then
                            Label1.Text = "Processing"
                            Label1.ForeColor = Color.Orange
                            Waite_ = 5
                            PictureBox2.Image = My.Resources.Refresh_animation2_icn
                            pic_manage(PictureBox2)
                            Button1.Visible = False
                        End If
                    End If
                Else
                    pic_manage(PictureBox2)
                    Dim msg As String = r.Item("msg").ToString
                    Label1.Text = msg
                    Label1.ForeColor = Color.Red
                End If
            Catch ex As HttpRequestException
                MessageBox.Show($"Request Error: {ex.Message}", "HTTP GET Error")
            Catch ex As Exception
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error")
            End Try
        End Using
    End Function
    Private Function pic_manage(p As PictureBox)
        PictureBox1.Visible = False
        PictureBox2.Visible = False

        p.Visible = True
    End Function

    Public Function Base64ToImage(base64String As String) As Image
        ' Remove the data URI prefix if present
        If base64String.StartsWith("data:image") Then
            base64String = base64String.Split(","c)(1)
        End If

        ' Convert base64 string to byte array
        Dim imageBytes As Byte() = Convert.FromBase64String(base64String)

        ' Create memory stream and image
        Using ms As New MemoryStream(imageBytes)
            Return Image.FromStream(ms)
        End Using
    End Function
    Dim Waite_ As Integer = 0
    Private Async Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Waite_ -= 1
        If Waite_ = 0 Then
            Get_Device()
        End If
    End Sub

    Private Sub WhatsApp_Qr_Login_dialoag_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Me.Dispose()
    End Sub

    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MessageBox.Show("Do you really want to logout of WhatsApp?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            Await LoagOut()
        End If
    End Sub
    Private Async Function LoagOut() As Task
        Dim API_ As String = Whatsapp_setup.API_TXT.Text
        Dim Number_ As String = Whatsapp_setup.Number_TXT.Text

        Dim url As New String($"https://wh.cryptonixtechnology.in/logout-device")

        Try
            Dim postParameters As New List(Of KeyValuePair(Of String, String))

            postParameters.Add(New KeyValuePair(Of String, String)("api_key", API_))
            postParameters.Add(New KeyValuePair(Of String, String)("sender", Number_))

            Dim content As New FormUrlEncodedContent(postParameters)
            Dim status As String = "false"
            Dim msg As String = ""


            Using httpClient As New HttpClient()
                Dim response As HttpResponseMessage = Await httpClient.PostAsync(url, content)
                response.EnsureSuccessStatusCode()
                Dim responseBody As String = Await response.Content.ReadAsStringAsync()

                Dim r = JObject.Parse(responseBody)
                    status = r.Item("status").ToString
                    msg = r.Item("msg").ToString
                End Using

            If status = "true" Then
                MessageBox.Show("Device Disconnected Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Waite_ = 2
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
End Class