'Imports System.Web.Http
Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Security.Cryptography
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading.Tasks

Public Class Try_frm
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub
    Public Class MyCustomData
        Public Property Name As String
        Public Property Age As Integer
        Public Property Value As Double
    End Class
    Public Class MyFileHandler
        ' Define a unique magic number for your file format
        Private ReadOnly _magicNumber As Byte() = {&H4D, &H59, &H46, &H46} ' "MYFF"
        Private Const _version As Integer = 1 ' Current version of the file format

        ' Method to save data to a custom file format
        Public Sub SaveData(filePath As String, data As MyCustomData)
            Try
                Using fs As New FileStream(filePath, FileMode.Create)
                    Using writer As New BinaryWriter(fs, Encoding.UTF8)
                        ' 1. Write Header
                        writer.Write(_magicNumber) ' Write the magic number to identify the file
                        writer.Write(_version)      ' Write the file format version

                        ' 2. Write Data
                        ' BinaryWriter handles length-prefixing for strings automatically
                        writer.Write(data.Name)
                        writer.Write(data.Age)
                        writer.Write(data.Value)
                    End Using
                End Using
                Console.WriteLine($"Data saved to {filePath}")
            Catch ex As Exception
                Console.WriteLine($"Error saving data: {ex.Message}")
            End Try
        End Sub

        ' Method to load data from a custom file format
        Public Function LoadData(filePath As String) As MyCustomData
            Dim data As New MyCustomData()
            Try
                Using fs As New FileStream(filePath, FileMode.Open)
                    Using reader As New BinaryReader(fs, Encoding.UTF8)
                        ' 1. Read Header and Validate
                        Dim fileMagic As Byte() = reader.ReadBytes(_magicNumber.Length)
                        If Not CompareByteArrays(fileMagic, _magicNumber) Then
                            Throw New InvalidDataException("Invalid file format: Magic number mismatch.")
                        End If

                        Dim fileVersion As Integer = reader.ReadInt32()
                        If fileVersion <> _version Then
                            ' Handle versioning: You might implement logic here to upgrade older versions,
                            ' or simply throw an error if the version is not supported.
                            Throw New NotSupportedException($"File version {fileVersion} not supported. Expected {_version}.")
                        End If

                        ' 2. Read Data
                        data.Name = reader.ReadString()
                        data.Age = reader.ReadInt32()
                        data.Value = reader.ReadDouble()
                    End Using
                End Using
                Console.WriteLine($"Data loaded from {filePath}")
                Return data
            Catch ex As Exception
                Console.WriteLine($"Error loading data: {ex.Message}")
                Return Nothing ' Or rethrow the exception, depending on your error handling strategy
            End Try
        End Function

        ' Helper function to compare two byte arrays
        Private Function CompareByteArrays(a1 As Byte(), a2 As Byte()) As Boolean
            If a1.Length <> a2.Length Then Return False
            For i As Integer = 0 To a1.Length - 1
                If a1(i) <> a2(i) Then Return False
            Next
            Return True
        End Function

        ' IMPORTANT: In a real application, DO NOT hardcode your key like this.
        ' Secure key management is critical for actual security.
        ' This key is for demonstration purposes only.
        Private ReadOnly _encryptionKey As Byte() = Encoding.UTF8.GetBytes("ThisIsAStrongKeyForEncryption!") ' 32 bytes for AES-256

        ' Method to save encrypted data to a custom file format
        Public Sub SaveEncryptedData(filePath As String, data As MyCustomData)
            Try
                Using aesAlg As Aes = Aes.Create()
                    aesAlg.Key = _encryptionKey
                    aesAlg.GenerateIV() ' Generate a new IV for each encryption operation

                    Using fs As New FileStream(filePath, FileMode.Create)
                        Using headerWriter As New BinaryWriter(fs, Encoding.UTF8)
                            ' Write Header (including IV)
                            headerWriter.Write(_magicNumber)
                            headerWriter.Write(_version)
                            headerWriter.Write(aesAlg.IV) ' Store IV in the header for decryption
                        End Using

                        ' Encrypt and write data
                        Using cs As New CryptoStream(fs, aesAlg.CreateEncryptor(), CryptoStreamMode.Write)
                            Using dataWriter As New BinaryWriter(cs, Encoding.UTF8)
                                dataWriter.Write(data.Name)
                                dataWriter.Write(data.Age)
                                dataWriter.Write(data.Value)
                            End Using
                        End Using
                    End Using
                End Using
                Console.WriteLine($"Encrypted data saved to {filePath}")
            Catch ex As Exception
                Console.WriteLine($"Error saving encrypted data: {ex.Message}")
            End Try
        End Sub

        ' Method to load encrypted data from a custom file format
        Public Function LoadEncryptedData(filePath As String) As MyCustomData
            Dim data As New MyCustomData()
            Try
                Using aesAlg As Aes = Aes.Create()
                    aesAlg.Key = _encryptionKey

                    Using fs As New FileStream(filePath, FileMode.Open)
                        Using headerReader As New BinaryReader(fs, Encoding.UTF8)
                            ' Read Header and Validate
                            Dim fileMagic As Byte() = headerReader.ReadBytes(_magicNumber.Length)
                            If Not CompareByteArrays(fileMagic, _magicNumber) Then
                                Throw New InvalidDataException("Invalid encrypted file format: Magic number mismatch.")
                            End If

                            Dim fileVersion As Integer = headerReader.ReadInt32()
                            If fileVersion <> _version Then
                                Throw New NotSupportedException($"Encrypted file version {fileVersion} not supported. Expected {_version}.")
                            End If

                            Dim iv As Byte() = headerReader.ReadBytes(aesAlg.IV.Length)
                            aesAlg.IV = iv ' Set the IV from the file header
                        End Using

                        ' Decrypt and read data
                        Using cs As New CryptoStream(fs, aesAlg.CreateDecryptor(), CryptoStreamMode.Read)
                            Using dataReader As New BinaryReader(cs, Encoding.UTF8)
                                data.Name = dataReader.ReadString()
                                data.Age = dataReader.ReadInt32()
                                data.Value = dataReader.ReadDouble()
                            End Using
                        End Using
                    End Using
                End Using
                Console.WriteLine($"Encrypted data loaded from {filePath}")
                Return data
            Catch ex As Exception
                Console.WriteLine($"Error loading encrypted data: {ex.Message}")
                Return Nothing ' Or rethrow the exception
            End Try
        End Function
    End Class

End Class