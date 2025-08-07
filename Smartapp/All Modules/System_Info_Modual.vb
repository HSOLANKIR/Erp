Imports System.Data.Entity.Core.Objects
Imports System.Management
Module System_Info_Modual
    Public Function Computer_Serial() As String
        Dim wmi As Object = GetObject("WinMgmts:")
        Dim serial_numbers As String = ""
        Dim mother_boards As Object = wmi.InstancesOf("Win32_BaseBoard")
        For Each board As Object In mother_boards
            serial_numbers &= ", " & board.SerialNumber
        Next board
        If serial_numbers.Length > 0 Then serial_numbers = serial_numbers.Substring(2)

        Return serial_numbers
    End Function
End Module
