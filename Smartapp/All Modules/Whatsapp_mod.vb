Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Threading.Tasks
Imports Newtonsoft.Json.Linq

Module Whatsapp_mod
    Public Wh_Admin_API As String = ""
    Public Wh_Admin_No As String = ""

    Public Wh_Local_API As String = ""
    Public Wh_Local_No As String = ""
    Public Function Whatsapp_Upload_file(file_path As String) As String
        Dim Upload_File_Name As String = ""

        Try
            Dim url As New String("https://wh.cryptonixtechnology.in/public/Upload.php")

            Using httpClient As New HttpClient()
                Using content As New MultipartFormDataContent()
                    Dim fileBytes As Byte() = File.ReadAllBytes(file_path)
                    Dim fileContent As New ByteArrayContent(fileBytes)
                    content.Add(fileContent, "file", Path.GetFileName(file_path))
                    Dim response As HttpResponseMessage = httpClient.PostAsync(url, content).GetAwaiter().GetResult()
                    Dim responseString As String = response.Content.ReadAsStringAsync().GetAwaiter().GetResult()
                    Upload_File_Name = (responseString.ToString)
                End Using
            End Using

            Upload_Rspons = Upload_File_Name
            If Upload_File_Name.Substring(0, 8) = "Success:" Then
                Upload_File_Name = Upload_File_Name.Replace("Success:", "")
            Else
                Upload_File_Name = ""
            End If

            Return Upload_File_Name
        Catch ex As Exception
            Return Upload_File_Name
        End Try
    End Function
    Public Upload_Rspons As String = ""
    Public Function Whatsapp_delete_file(file As String) As Boolean
        Dim isvlu As Boolean = False
        Try
            Dim oIE As Object

            oIE = CreateObject("InternetExplorer.Application")
            oIE.navigate2($"https://wh.cryptonixtechnology.in/public/Delete.php?file={file}")
            oIE.Visible = False

            isvlu = True
        Catch ex As Exception
            isvlu = False
        End Try
        Return isvlu
    End Function
    Public Function Whatsapp_login_YN(API As String, Number As String) As Boolean
        Dim isvlu As Boolean = False
        Dim url As New String($"https://wh.cryptonixtechnology.in/info-devices")
        Try
            Dim postdata As New JObject
            postdata.Add("api_key", API)
            postdata.Add("number", Number)

            Dim finalString As String = postdata.ToString

            Dim httpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
            httpWebRequest.ContentType = "application/json"
            httpWebRequest.Method = "POST"

            Using streamWriter = New StreamWriter(httpWebRequest.GetRequestStream())
                streamWriter.Write(finalString)
            End Using

            Dim httpResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)
            Dim responseText As String

            Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                responseText = streamReader.ReadToEnd()
                'responseText contains the response received by the request               
            End Using

            Dim json As String = responseText
            Dim r = JObject.Parse(json)

            Dim status As String = r.Item("status").ToString
            If status.ToLower = "true" Then
                For Each player In r.Item("info")
                    If player("status").ToString.ToLower = "connected" Then
                        isvlu = True
                    End If
                Next
            End If

            httpResponse.Close()
        Catch ex As Exception
            isvlu = False
        End Try
        Return isvlu
    End Function
    Public Function Whatsapp_call_message(phone As String, msg As String) As Boolean
        Dim isvlu As Boolean = False
        Dim url As New String($"https://wh.cryptonixtechnology.in/send-message")
        Try
            Dim postdata As New JObject
            postdata.Add("api_key", Wh_Local_API)
            postdata.Add("sender", Wh_Local_No)
            postdata.Add("number", phone)
            postdata.Add("message", msg)

            Dim finalString As String = postdata.ToString

            Dim httpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
            httpWebRequest.ContentType = "application/json"
            httpWebRequest.Method = "POST"

            Using streamWriter = New StreamWriter(httpWebRequest.GetRequestStream())
                streamWriter.Write(finalString)
            End Using

            Dim httpResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)
            Dim responseText As String

            Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                responseText = streamReader.ReadToEnd()
                'responseText contains the response received by the request               
            End Using

            Dim json As String = responseText
            Dim r = JObject.Parse(json)

            Dim status As String = r.Item("status").ToString
            If status.ToLower = "true" Then
                isvlu = True
            Else
                isvlu = False
            End If

            httpResponse.Close()
        Catch ex As Exception
            isvlu = False
        End Try
        Return isvlu
    End Function
    Public Enum whmedia_type
        image = 0
        video = 1
        audio = 2
        pdf = 3
    End Enum
    Public Function Whatsapp_call_document(phone As String, msg As String, mediaType As whmedia_type, document_path As String, upload_ As Boolean, delete_ As Boolean) As String()
        Dim isvlu As Boolean = False
        Dim file_ As String = ""

        If upload_ = True Then
            file_ = Whatsapp_Upload_file(document_path)
            If file_ = "" Then
                Return {False, "File Upload Error"}
                Exit Function
            End If
        End If

        Dim url As New String($"https://wh.cryptonixtechnology.in/send-media")
        'file_ = document_path.Split("\").Last

        Dim status As String = "Sending error"
        Try
            Dim postdata As New JObject
            postdata.Add("api_key", Wh_Local_API)
            postdata.Add("sender", Wh_Local_No)
            postdata.Add("number", phone)
            postdata.Add("media_type", "document")
            postdata.Add("caption", msg)
            postdata.Add("footer", Company_Name_str)
            postdata.Add("url", $"https://wh.cryptonixtechnology.in/public/Resource/{file_}")
            Dim finalString As String = postdata.ToString

            Dim httpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
            httpWebRequest.ContentType = "application/json"
            httpWebRequest.Method = "POST"
            'httpWebRequest.Timeout = 5000
            Using streamWriter = New StreamWriter(httpWebRequest.GetRequestStream())
                streamWriter.Write(finalString)
            End Using

            Dim httpResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)
            Dim responseText As String

            Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                responseText = streamReader.ReadToEnd()
            End Using

            Dim json As String = responseText
            Dim r = JObject.Parse(json)

            status = r.Item("status").ToString

            httpResponse.Close()
        Catch ex As Exception
            status = "Sending Error"
            MsgBox(ex.Message)
        End Try

        If delete_ = True Then
            Whatsapp_delete_file(file_)
        End If

        If status.ToLower = "true" Then
            Return {True, "success"}
        Else
            Return {False, status}
        End If
    End Function
End Module
