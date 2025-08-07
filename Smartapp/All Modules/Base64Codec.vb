''Class for Encoding and Decoding Base64 String
Imports System.IO

Public Class Base64Codec

    ''Function to Get Image from Base64 Encoded String
    Public Function GetImageFromBase64(ByVal Base64String) As Bitmap
        Dim fileBytes As Byte()
        Dim streamImage As Bitmap
        Try
            If (String.Empty <> Base64String) Then ''Checking The Base64 string validity

                fileBytes = Convert.FromBase64String(Base64String) ''Convert Base64 to Byte Array

                Using ms As New MemoryStream(fileBytes) ''Using Memory stream to save image

                    streamImage = Image.FromStream(ms) ''Converting image from Memory stream

                    If Not IsNothing(streamImage) Then

                        ''Save image to temp path
                        streamImage.Save(Path.GetTempPath(), System.Drawing.Imaging.ImageFormat.Jpeg)

                    End If

                End Using

            End If

        Catch ex As Exception

            'MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")

        End Try

        Return streamImage

    End Function

    ''Convert the Image from Input to Base64 Encoded String
    Public Function ConvertImageToBase64(ImageInput As Image) As String

        Dim Base64Op As String = String.Empty

        Try

            Dim ms As MemoryStream = New MemoryStream()

            ImageInput.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)

            Base64Op = Convert.ToBase64String(ms.ToArray())

        Catch ex As Exception

            'MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")

        End Try

        Return Base64Op

    End Function

End Class