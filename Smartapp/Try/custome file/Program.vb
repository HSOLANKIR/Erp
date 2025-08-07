Imports Management.Try_frm

Module Program
    Sub Main()
        Dim handler As New MyFileHandler()
        Dim myData As New MyCustomData With {
            .Name = "Example Data",
            .Age = 42,
            .Value = 123.45
        }

        Dim fileName As String = "mycustomfile.dat"
        Dim encryptedFileName As String = "myencryptedfile.enc"

        ' Save data to the custom file format
        handler.SaveData(fileName, myData)

        ' Load data from the custom file format
        Dim loadedData As MyCustomData = handler.LoadData(fileName)
        If loadedData IsNot Nothing Then
            Console.WriteLine($"Loaded Data: Name={loadedData.Name}, Age={loadedData.Age}, Value={loadedData.Value}")
        End If

        Console.WriteLine(Environment.NewLine & "--- Encrypted File Example ---" & Environment.NewLine)

        ' Save encrypted data
        handler.SaveEncryptedData(encryptedFileName, myData)

        ' Load encrypted data
        Dim loadedEncryptedData As MyCustomData = handler.LoadEncryptedData(encryptedFileName)
        If loadedEncryptedData IsNot Nothing Then
            Console.WriteLine($"Loaded Encrypted Data: Name={loadedEncryptedData.Name}, Age={loadedEncryptedData.Age}, Value={loadedEncryptedData.Value}")
        End If

        Console.ReadLine() ' Keep console open
    End Sub
End Module
