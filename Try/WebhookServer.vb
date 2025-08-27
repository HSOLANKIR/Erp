Imports System.Net
Imports System.Threading
Imports System.IO
Imports System.Management

Public Class WebhookServer
    Private listener As HttpListener
    Private listenerThread As Thread
    Private Sub btnToggleServer_Click(sender As Object, e As EventArgs) Handles btnToggleServer.Click
        listener = New HttpListener()
        ' લોકલહોસ્ટ અને પોર્ટ નંબર ઉમેરો. 
        ' પોર્ટ નંબર PHP સ્ક્રિપ્ટના URL સાથે મેચ થવો જોઈએ.
        listener.Prefixes.Add("http://localhost:5000/api/webhook/")

        Try
            listener.Start()
            Me.ListBox1.Items.Add("Server started. Listening on http://localhost:5000/api/webhook/")

            ' સર્વરને એક અલગ થ્રેડ પર ચલાવો જેથી UI બ્લોક ન થાય
            listenerThread = New Thread(AddressOf HandleRequests)
            listenerThread.Start()
        Catch ex As Exception
            Me.ListBox1.Items.Add("Error starting server: " & ex.Message)
        End Try
    End Sub
    Private Sub HandleRequests()
        While listener.IsListening
            Dim context As HttpListenerContext = listener.GetContext()
            Dim request As HttpListenerRequest = context.Request
            Dim response As HttpListenerResponse = context.Response

            ' રિક્વેસ્ટ ડેટા વાંચો
            Dim reader As New System.IO.StreamReader(request.InputStream, request.ContentEncoding)
            Dim requestBody As String = reader.ReadToEnd()

            Me.Invoke(Sub()
                          Me.ListBox1.Items.Add("New Webhook Request Received!")
                          Me.ListBox1.Items.Add("Content: " & requestBody)
                          Me.ListBox1.Items.Add("-----------------------------")
                      End Sub)

            ' રિસ્પોન્સ મોકલો
            Dim responseString As String = "Data received successfully."
            Dim buffer As Byte() = System.Text.Encoding.UTF8.GetBytes(responseString)
            response.ContentLength64 = buffer.Length
            Dim output As System.IO.Stream = response.OutputStream
            output.Write(buffer, 0, buffer.Length)
            output.Close()
        End While
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If listener IsNot Nothing AndAlso listener.IsListening Then
            listener.Stop()
            listener.Close()
            Me.ListBox1.Items.Add("Server stopped.")
        End If
    End Sub

    Private Sub WebhookServer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class