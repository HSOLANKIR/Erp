Module All_Message_And_Text
    Public Function Text_Action(vl As vl, ParamArray Arr() As String) As String
        Select Case vl.ToString
            Case "Select_Current"
                Return "Please Select Current " & Arr(0)
            Case "Input_Error_Blank"
                Return "'" & Arr(0) & "' is Required, Please Enter '" & Arr(0) & "'"
            Case "Already_Exists"
                Return "The '" & Arr(0) & "' already exists, Please change '" & Arr(0) & "' and Try again"
        End Select
    End Function
    Public Enum vl
        Select_Current
        Input_Error_Blank
        Already_Exists
    End Enum
    'Filter Depart

    Public Function Company_Visible_Filter() As String
        Dim Company_Filter As String = "(Company = 'All' OR Company = 'ALL' OR Company = 'Defolt' OR Company = '" & Company_ID_str & "')"
        Dim Visible_Filter As String = "(Visible = 'Approval')"

        Return "(" & Company_Filter & " AND " & Visible_Filter & ")"
    End Function
End Module
