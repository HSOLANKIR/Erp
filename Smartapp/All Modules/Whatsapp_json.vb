Module Whatsapp_json
    Public Function json_OTP_(Phone As String, Head As String, OTP As String)
        Return "{
    ""messaging_product"": ""whatsapp"",
    ""to"": " & Phone & ",
    ""type"": ""template"",
  ""template"": {
    ""name"": ""smartapp_otp"",
    ""language"": {
      ""code"": ""en_GB""
    },
    ""components"": [
      {
        ""type"": ""header"",
        ""parameters"": [
          {
            ""type"": ""image"",
            ""image"": {
              ""link"": ""https://www.almaviva.it/dam/jcr:c66a2ebc-3d12-4c87-b72d-8ed0a15c0e73/CyberSecurity_1280x720.jpg""
            }
          }
        ]
      },
      {
        ""type"": ""body"",
        ""parameters"": [
          {
            ""type"": ""text"",
            ""text"": """ & Head & """
          },
          {
            ""type"": ""text"",
            ""text"": """ & OTP & """
          }
        ]
      }
    ]
  }
  }"
    End Function
End Module
