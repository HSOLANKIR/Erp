Imports Tools
Module Msg_mod
    Public Enum NOT_Location
        Bottom_Right = 0
        Center = 1
    End Enum
    Public Enum YN_Type
        Save = 0
        Close = 1
        Delete = 2
        Custom = 3
    End Enum
    Public Enum Dialoag_Button
        Yes_No = 0
        Ok = 1
        Retry_Cancel = 2
        any_keypress = 3
    End Enum
    Public Function Msg_(NOT_Ty As NOT_Type, Location As NOT_Location, Head As String, Message As String, TX As TXT) As DialogResult
        If IsNothing(TX.Msg_Object) Then
            Dim obj As New Msg_frm
            TX.Msg_Object = obj
        End If

        Msg_frm.Msg(TX.Msg_Object, NOT_Ty, Location, Head, Message)
        AddHandler TX.KeyDown, AddressOf Msg_KeyDown_close
        AddHandler TX.LostFocus, AddressOf Msg_LostFocus_close
    End Function
    Public Function Msg_YN_(NOT_Ty As YN_Type, Location As NOT_Location, btn As Dialoag_Button, Head As String, Message As String) As DialogResult
        Dim frm_ As New Msg_yn_frm
        Return Msg_yn_frm.Msg(frm_, NOT_Ty, Location, btn, Head, Message)
    End Function
    Private Sub Msg_LostFocus_close(sender As Object, e As EventArgs)
        sender.Msg_Object.Hide()
    End Sub
    Private Sub Msg_KeyDown_close(sender As Object, e As KeyEventArgs)
        sender.Msg_Object.Hide()
    End Sub

    Public Function Msg_Save_YN(TX As TXT, Head As String) As DialogResult
        Return Msg_YN_(YN_Type.Save, NOT_Location.Bottom_Right, Dialoag_Button.Yes_No, $"{TX.Text}", $"Do you want to save<nl>'{Head}'?")
    End Function
    Public Function Msg_Exit_YN(Head As String) As DialogResult
        Return Msg_YN_(YN_Type.Close, NOT_Location.Bottom_Right, Dialoag_Button.Yes_No, $"{Head}", $"Do you really want to<nl>Exit ?")
    End Function
    Public Function Msg_Delete_YN(TX As TXT, Head As String) As DialogResult
        Return Msg_YN_(YN_Type.Delete, NOT_Location.Bottom_Right, Dialoag_Button.Yes_No, $"{TX.Text}", $"Do you want to delete<nl>'{Head}'?")
    End Function
    Public Function Msg_Credit_Warning_Dialoag(Name_Ledger As String, current_ As String) As DialogResult
        'Return Msg_YN_(NOT_Type.Warning, NOT_Location.Bottom_Right, Dialoag_Button.Yes_No, $"Credit limit exceeded", $"'{Name_Ledger}' credit limit is over<nl><nl>Current Credit : {current_}")
        Return Msg_Custom_YN(NOT_Location.Bottom_Right, Color.Red, My.Resources.Warning_animation_icn, Dialoag_Button.Yes_No, "Credit limit exceeded", Name_Ledger, $"credit limit is over<nl>Current Credit : {current_}")
    End Function

    Public Function Msg_Internet_YN() As DialogResult
        Dim frm_ As New Msg_yn_frm
        frm_.custom_Color = Color.OrangeRed
        frm_.custom_Titel = "Network"
        frm_.custom_img = My.Resources.wifi_Load_animation_icn
        Return Msg_yn_frm.Msg(frm_, YN_Type.Custom, 0, 2, "Internet Connection error", "Please enable internet connection<nl> and try again")
    End Function

    Public Function Msg_Custom_YN(loca As NOT_Location, color As Color, img As Image, btn As Dialoag_Button, Tital As String, Head As String, msg As String) As DialogResult
        Dim frm_ As New Msg_yn_frm
        With frm_
            .Location_ = loca
            .Type_(YN_Type.Custom, frm_)
            .type_lb.Text = Tital
            .head_lb.Text = Head
            .msg_lb.Text = msg.Replace("<nl>", vbNewLine)
            .btn_ = btn
            .typ_ = YN_Type.Custom
            .Stype_(YN_Type.Custom, frm_)
            .PictureBox1.Image = img
            .custom_Color = color
            My.Computer.Audio.Play(My.Resources.Dialoag_Sound, AudioPlayMode.Background)
            Return .ShowDialog()
        End With


    End Function

    Public Function Msg_Duplicat(TX As TXT, Head As String)
        Msg_(NOT_Type.Erro, NOT_Location.Bottom_Right, $"Duplicat {Head}", $"The '{TX.Text}' is already exists.<nl> please enter a different '{Head}'.", TX)
    End Function
    Public Function Msg_Blank(TX As TXT, Head As String)
        Msg_(NOT_Type.Erro, NOT_Location.Bottom_Right, $"Input Error '{Head}'", $"Blank '{Head}' is not valid<nl>please enter a '{Head}' and try again", TX)
    End Function
    Public Function Msg_InputError(TX As TXT, Head As String)
        Msg_(NOT_Type.Erro, NOT_Location.Bottom_Right, $"Input Error '{Head}'", $"'{Head}' input error<nl> please enter current<nl>'{Head}' and try again", TX)
    End Function
    Public Function Msg_Negative_Stock(TX As TXT, Item As String, Stock As String) As DialogResult
        'Msg_(NOT_Type.Warning, NOT_Location.Bottom_Right, $"Negative Stock", $"{Item}<nl><nl>{Stock}", TX)

        Return Msg_Custom_YN(NOT_Location.Bottom_Right, Color.Red, My.Resources.Warning_animation_icn, Dialoag_Button.Yes_No, "Negative Stock", Item, $"{Stock}")

    End Function


End Module
