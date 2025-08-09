Imports System.Data.SQLite
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Net
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Text.RegularExpressions
Imports Newtonsoft.Json.Linq
Imports System.ComponentModel

Module GENDRAL_mod
    <DllImport("user32.dll", SetLastError:=True)>
    Public Function EnableMenuItem(ByVal menu As IntPtr, ByVal EnableItem As Integer, ByVal enable As Integer) As Integer

    End Function
    <DllImport("user32.dll", CharSet:=CharSet.Unicode, SetLastError:=True, ExactSpelling:=True)>
    Public Function GetSystemMenu(ByVal WindowsHandel As IntPtr, ByVal Reset As Integer) As IntPtr

    End Function

    Public Date_1 As Date
    Public Date_2 As Date
    Public Date_3 As Date

    Public Dft_Font As String = "Arial"
    Public Dft_Font_Size As Integer = 11
    Public Dft_Font_Size_Bold As Integer = 11
    Public Dft_Font_Style As FontStyle = FontStyle.Regular

    Public Dft_Branch As String = "Primary"
    Public Dft_Voucher As String = "All Vouchers"
    Public Dft_Valuation As String = "Default"

    Public Defolt_Fonts As Font = New Font(Dft_Font, Dft_Font_Size, Dft_Font_Style)
    Public Defolt_Fonts_Bold As Font = New Font(Dft_Font, Dft_Font_Size_Bold, FontStyle.Bold)


    Public Send_Email As String
    Public Send_Email_Password As String

    Public Function Verification_code() As String
        Return ((Val(Now.Date.Day) + Val(Now.Date.Minute) + Val(Now.Date.Hour) & Val(Val(Now.TimeOfDay.Hours + Now.TimeOfDay.Minutes & Now.Date.Month + Now.Date.Day)) + Val(Val(Now.Date.Year))) - Val(Now.TimeOfDay.Minutes) + Val(Now.TimeOfDay.Minutes)) * 12552
    End Function

    Public Function Close_Fales(Frm As Form)
        EnableMenuItem(GetSystemMenu(Frm.Handle, 0), &HF060, 1)
    End Function

    Public DialLoag_Result As DialogResult

    'Color Managment
    Public Color_SELECT_back As Color = Color.DeepSkyBlue
    Public Color_SELECT_fonr As Color = Color.Black

    Public ComputerName As String = System.Windows.Forms.SystemInformation.ComputerName
    Public Function Close_Box(obj As Object) As Boolean
        Dim dilo As DialogResult = Msg_Yn("Are you source ?", "Exit this")
        If dilo = DialogResult.Yes Or dilo = DialogResult.Cancel Then
            obj.Dispose()
            Return True
        ElseIf dilo = DialogResult.No Then
            obj.Focus()
            Return False
        End If

    End Function
    Public Function obj_center(obj As Object, bg As Object) As Point
        Dim Poi As Point = New Point(bg.ClientSize.Width / 2 - obj.Size.Width / 2, bg.ClientSize.Height / 2 - obj.Size.Height / 2)
        obj.Location = Poi
        Return Poi
    End Function
    Public Function obj_top(obj As Object) As Point
        Dim Poi As Point = New Point((BG_frm.BG_PAN.Width - obj.Width) \ 2, 0)
        obj.Location = Poi

        Return Poi
    End Function
    Public Function obj_bottom(obj As Object) As Point
        Dim loca As Point = obj_top(obj)

        obj.Location = New Point((BG_frm.BG_PAN.Width - obj.Width) \ 2, ((BG_Head_frm.Top_Bar.Height + BG_frm.Label11.Height) - obj.Height) + BG_frm.BG_PAN.Height)

        Return loca
    End Function

    Public Function Frm_Design(frm As Form)
        frm.Font = Defolt_Fonts
        frm.Icon = My.Resources.Company_icn
    End Function
    Public Function ABC_To_num(i As Integer) As String
        Select Case i
            Case 1
                Return "A"
            Case 2
                Return "B"
            Case 3
                Return "C"
            Case 4
                Return "D"
            Case 5
                Return "E"
            Case 6
                Return "F"
            Case 7
                Return "G"
            Case 8
                Return "H"
            Case 9
                Return "I"
            Case 10
                Return "J"
            Case 11
                Return "K"
            Case 12
                Return "L"
            Case 13
                Return "M"
            Case 14
                Return "N"
            Case 15
                Return "O"
            Case 16
                Return "P"
            Case 17
                Return "Q"
            Case 18
                Return "R"
            Case 19
                Return "S"
            Case 20
                Return "T"
            Case 21
                Return "U"
            Case 22
                Return "V"
            Case 23
                Return "W"
            Case 24
                Return "X"
            Case 25
                Return "Y"
            Case 26
                Return "Z"
            Case Else
                Return "Z"
        End Select

    End Function
    Public Function Boolean_TXT(vl As Boolean) As String
        If vl = True Then
            Return "Yes"
        Else
            Return "No"
        End If
        Return False
    End Function
    Public Function YN_Boolean(vl As String, Defoult As Boolean) As Boolean
        vl = vl.ToLower
        If vl = "yes" Or vl = "true" Then
            Return True
        ElseIf vl = "no" Or vl = "false" Then
            Return False
        End If
        Return Defoult
    End Function
    Public Function YN_Boolean(vl As String) As Boolean
        If vl = "Yes" Or vl = "True" Then
            Return True
        End If
        Return False
    End Function
    Public Function Send_Whatsapp(TO_ As String, message_ As String)

        Dim whatsapp_API As String = Find_DT_Value(Database_File.cmp, "TBL_Features", "Discription", "Head = 'Whatsapp'")

        whatsapp_API = "6353161009"

        'Dim whatsapp_API As String = "3501769512"
        ServicePointManager.Expect100Continue = True
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
        ServicePointManager.SecurityProtocol = DirectCast(3072, SecurityProtocolType)

        Dim request As WebRequest = WebRequest.Create("https://wa.esktraweb.my.id/send")
        request.Method = "POST"
        Dim postData As String = "number=" & whatsapp_API & "&message=" & message_ & "&to=" & TO_ & "&type=chat"


        Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
        request.ContentType = "application/x-www-form-urlencoded"
        request.ContentLength = byteArray.Length
        Dim dataStream As Stream = request.GetRequestStream()
        dataStream.Write(byteArray, 0, byteArray.Length)
        dataStream.Close()
        Dim response As WebResponse = request.GetResponse()
        response.Close()
    End Function
    Public Function Date_Formate(TXT As String) As String
        Dim DT1 As Date
        If TXT <> "" Then
            Try
                DT1 = CDate(TXT).ToString(Date_Format_fech)
                NOT_Clear()
                Return DT1.ToString(Date_Format_fech)
            Catch ex As Exception
                Return ""
            End Try
        Else
            Return ""
        End If
    End Function
    Public Function Set_Date(period As Boolean, obj As Object)
        Date_frm.Doubal_ = period
        Date_frm.obj = obj
        Cell("Date")
    End Function
    Public Function Date_Brack(TXT As String) As Boolean
        Dim DT1 As Date
        If Date_Formate(TXT) <> "" Then
            DT1 = CDate(Date_Formate(TXT)).ToString(Date_Format_fech)
            NOT_Clear()
        Else
            Return False
        End If
        If Date_Formate(TXT) <> "" Then
            Dim Company_Valu As Integer = DateDiff(DateInterval.Day, CDate(Company_Book_frm), DT1)
            If Val(Company_Valu) >= 0 Then
                NOT_Clear()
                Return True
            Else
                NOT_("Date has been Company opning after", NOT_Type.Erro)
                Return False
            End If
        Else
            Return False
        End If
    End Function
    Public Function Date_TO_Day(TXT As String) As String
        Try
            Dim DT As Date = TXT
            Return DT.DayOfWeek.ToString
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Public Function Enter_(TX As Object)
        TX.BackColor = Color.FromArgb(255, 204, 128)
        TX.Select(0, TX.Text.Length)
    End Function
    Public Function Lost_(TX As Object)
        TX.BackColor = Color.White
    End Function

    Public Function Chck_Directry(TXT As String) As Boolean
        If Directory.Exists(TXT) Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function Button_Clear()
        BG_frm.R_1.Text = ""
        BG_frm.R_2.Text = ""
        BG_frm.R_3.Text = ""
        BG_frm.R_4.Text = ""
        BG_frm.R_5.Text = ""
        BG_frm.R_6.Text = ""
        BG_frm.R_7.Text = ""
        BG_frm.R_8.Text = ""
        BG_frm.R_9.Text = ""
        BG_frm.R_10.Text = ""
        BG_frm.R_11.Text = ""
        BG_frm.R_12.Text = ""
        BG_frm.R_13.Text = ""
        BG_frm.R_14.Text = ""
        BG_frm.R_15.Text = ""
        BG_frm.R_16.Text = ""
        BG_frm.R_17.Text = ""
        BG_frm.R_18.Text = ""
        BG_frm.R_19.Text = ""
        BG_frm.R_20.Text = ""
        BG_frm.R_21.Text = ""
        'BG_frm.R_22.Text = ""

        BG_frm.B_1.Text = ""
        BG_frm.B_2.Text = ""
        BG_frm.B_3.Text = ""
        BG_frm.B_4.Text = ""
        BG_frm.B_5.Text = ""
        BG_frm.B_6.Text = ""
        BG_frm.B_7.Text = ""
        BG_frm.B_8.Text = ""
        BG_frm.B_9.Text = ""
        BG_frm.B_10.Text = ""
        BG_frm.B_11.Text = ""
        Button_Enabled()
    End Function
    Public Function Button_Enabled()
        BG_frm.R_1.Enabled = False
        BG_frm.R_2.Enabled = False
        BG_frm.R_3.Enabled = False
        BG_frm.R_4.Enabled = False
        BG_frm.R_5.Enabled = False
        BG_frm.R_6.Enabled = False
        BG_frm.R_7.Enabled = False
        BG_frm.R_8.Enabled = False
        BG_frm.R_9.Enabled = False
        BG_frm.R_10.Enabled = False
        BG_frm.R_11.Enabled = False
        BG_frm.R_12.Enabled = False
        BG_frm.R_13.Enabled = False
        BG_frm.R_14.Enabled = False
        BG_frm.R_15.Enabled = False
        BG_frm.R_16.Enabled = False
        BG_frm.R_17.Enabled = False
        BG_frm.R_18.Enabled = False
        BG_frm.R_19.Enabled = False
        BG_frm.R_20.Enabled = False
        BG_frm.R_21.Enabled = False
        BG_frm.R_22.Enabled = False

        BG_frm.B_1.Enabled = False
        BG_frm.B_2.Enabled = False
        BG_frm.B_3.Enabled = False
        BG_frm.B_4.Enabled = False
        BG_frm.B_5.Enabled = False
        BG_frm.B_6.Enabled = False
        BG_frm.B_7.Enabled = False
        BG_frm.B_8.Enabled = False
        BG_frm.B_9.Enabled = False
        BG_frm.B_10.Enabled = False
        BG_frm.B_11.Enabled = False
    End Function

    Public Function allow_Number(e As KeyPressEventArgs)
        Select Case e.KeyChar
            Case "0"c To "9"c
            Case "."c
                'If .Text.Contains(".") Then
                'e.Handled = True
                'End If
            Case ChrW(Keys.Delete), ChrW(Keys.Back)
            Case Else
                e.Handled = True
        End Select
    End Function
    Public Function Formate_Phone(Ob As Object, e As KeyPressEventArgs)
        Ob.MaxLength = 10
        If e.KeyChar <> ChrW(Keys.Back) Then
            If e.KeyChar <> ChrW(Keys.Enter) Then
                If Ob.Text.Length > 10 Then
                    e.Handled = True
                    allow_Number(e)
                Else
                    e.Handled = False
                    allow_Number(e)
                End If
            End If
        End If
    End Function
    Public Function Formate_Email(ByVal s As String) As Boolean
        Return Regex.IsMatch(s, "^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$")
    End Function
    Public Function Formate_GST(ByVal s As String) As Boolean
        Return Regex.IsMatch(s, "^[0-9]{2}[A-Z]{5}[0-9]{4}[A-Z]{1}[1-9A-Z]{1}Z[0-9A-Z]{1}$")
    End Function
    Public Function Formate_PAN(ByVal s As String) As Boolean
        Return Regex.IsMatch(s, "[A-Z]{5}[0-9]{4}[A-Z]{1}")
    End Function
    Public Function Formate_IFSC(ByVal s As String) As Boolean
        Return Regex.IsMatch(s, "^[A-Z]{4}0[A-Z0-9]{6}$")
    End Function
    Public Function Formate_URL(ByVal s As String) As Boolean
        Return Regex.IsMatch(s, "http(s)?://([\w+?\.\w+])+([a-zA-Z0-9\~\!\@\#\$\%\^\&\*\(\)_\-\=\+\\\/\?\.\:\;\'\,]*)?")
    End Function


    Public Function NOT_(Message As String, Type As NOT_Type)
        BG_frm.Label11.Text = Message

        If Type.ToString = "Success" Then
            BG_frm.PictureBox2.Image = My.Resources.Checkmark_28px
            BG_frm.BG_Noti_Panel.BackColor = Color.FromArgb(42, 171, 160)
            BG_frm.Label11.ForeColor = Color.White
        End If
        If Type.ToString = "Erro" Then
            BG_frm.PictureBox2.Image = My.Resources.Error_28px
            BG_frm.BG_Noti_Panel.BackColor = Color.FromArgb(255, 121, 70)
            BG_frm.Label11.ForeColor = Color.White
        End If
        If Type.ToString = "Info" Then
            BG_frm.PictureBox2.Image = My.Resources.Info_28px
            BG_frm.BG_Noti_Panel.BackColor = Color.FromArgb(71, 169, 248)
            BG_frm.Label11.ForeColor = Color.Black
        End If
        If Type.ToString = "Warning" Then
            BG_frm.PictureBox2.Image = My.Resources.Warning_28px
            BG_frm.BG_Noti_Panel.BackColor = Color.FromArgb(255, 109, 11)
            BG_frm.Label11.ForeColor = Color.White
        End If
        BG_frm.TableLayoutPanel6.Hide()
        BG_frm.BG_Noti_Panel.Show()
        BG_frm.BG_PAN.BringToFront()
    End Function
    Public Function NOT_Clear()
        BG_frm.TableLayoutPanel6.Show()
        BG_frm.BG_Noti_Panel.Hide()
        BG_frm.BG_PAN.BringToFront()
    End Function
    Public Enum NOT_Type
        Success = 0
        Erro = 1
        Info = 2
        Warning = 3
        YN = 4
    End Enum

    Public Function Msg(NOT_Ty As NOT_Type, Head As String, Message As String)
        Mix_frm.Msg(NOT_Ty.ToString, Head, Message)
    End Function

    Public Function Msg_Yn(Head As String, Message As String) As DialogResult
        Return Mix_frm.YN(Head, Message)
    End Function
    Public Function LOAD_(Head As String)
        Mix_frm.LOAD(Head)
    End Function
    Public Function EMAIL_sEnd(Email As String, SubJect As String, Message As String, HTML_Body As Boolean) As DialogResult
        Return Email_sending_dialiag.EMAIL(Email, SubJect, Message, HTML_Body)
    End Function

    Public Function Email_Verification(Head As String, TO_Name As String, to_Email As String, Subject As String, Body As String, Sec As Integer) As DialogResult

        Return Email_Verification_dialoag.Email_OTP("Email", Head, TO_Name, to_Email, Subject, Body, Sec)
    End Function

    Public Function nUmBeR_FORMATE(int As String) As Decimal
        Dim st As String = int.Replace(",", "")
        st = st.Replace(" ", "")

        Return Format(Val(st), "0.00")
    End Function
    Public Function nUmBeR_FORMATE(int As String, zero_yn As Boolean) As Decimal
        Dim st As String = int.Replace(",", "")
        st = st.Replace(" ", "")

        If zero_yn = False Then
            If Val(st) = 0 Then
                Return ""
            End If
        End If


        Return Format(Val(st), "0.00")
    End Function
    Public Function N2_FORMATE(int As String) As String
        Dim isNagativ As Boolean = False

        If Val(int) = 0 Then
            Return ""
        Else
            int = nUmBeR_FORMATE(int)
            Dim return_ As String = ""
            If int.Substring(0, 1) = "-" Then
                isNagativ = True
                int = int.Replace("-", "")
            End If

            Select Case int.Length
                Case 7
                    return_ = $"{int.Substring(0, 1)},{int.Substring(1, 6)}"

                    If isNagativ = True Then Return $"-{return_}"
                    Return return_
                Case 8
                    return_ = $"{int.Substring(0, 2)},{int.Substring(2, 6)}"
                    If isNagativ = True Then Return $"-{return_}"
                    Return return_
                Case 9
                    return_ = $"{int.Substring(0, 1)},{int.Substring(1, 2)},{int.Substring(3, 6)}"
                    If isNagativ = True Then Return $"-{return_}"
                    Return return_
                Case 10
                    return_ = $"{int.Substring(0, 2)},{int.Substring(2, 2)},{int.Substring(4, 6)}"
                    If isNagativ = True Then Return $"-{return_}"
                    Return return_
                Case 11
                    return_ = $"{int.Substring(0, 1)},{int.Substring(1, 2)},{int.Substring(3, 2)},{int.Substring(5, 6)}"
                    If isNagativ = True Then Return $"-{return_}"
                    Return return_
                Case 12
                    return_ = $"{int.Substring(0, 2)},{int.Substring(2, 2)},{int.Substring(4, 2)},{int.Substring(6, 6)}"
                    If isNagativ = True Then Return $"-{return_}"
                    Return return_
                Case 13
                    return_ = $"{int.Substring(0, 1)},{int.Substring(1, 2)},{int.Substring(3, 2)},{int.Substring(5, 2)},{int.Substring(7, 6)}"
                    If isNagativ = True Then Return $"-{return_}"
                    Return return_
                Case 14
                    return_ = $"{int.Substring(0, 2)},{int.Substring(2, 2)},{int.Substring(4, 2)},{int.Substring(6, 2)},{int.Substring(8, 6)}"
                    If isNagativ = True Then Return $"-{return_}"
                    Return return_
                Case Else
                    return_ = nUmBeR_FORMATE(int)
                    If isNagativ = True Then Return $"-{return_}"
                    Return (int)
            End Select

        End If
    End Function

    Public Function Value_Decimal_set(vlu As String, Decimal_ As Integer)
        Select Case Decimal_
            Case 0
                Return Format(Val(Val(vlu)), "0")
            Case 1
                Return Format(Val(Val(vlu)), "0.0")
            Case 2
                Return Format(Val(Val(vlu)), "0.00")
            Case 3
                Return Format(Val(Val(vlu)), "0.000")
            Case 4
                Return Format(Val(Val(vlu)), "0.0000")
            Case 5
                Return Format(Val(Val(vlu)), "0.00000")
            Case 6
                Return Format(Val(Val(vlu)), "0.000000")
            Case 7
                Return Format(Val(Val(vlu)), "0.0000000")
            Case 8
                Return Format(Val(Val(vlu)), "0.00000000")
            Case 9
                Return Format(Val(Val(vlu)), "0.000000000")
            Case 10
                Return Format(Val(Val(vlu)), "0.0000000000")
        End Select
    End Function
    Public Function N2_to_TXT(txt As String) As Decimal
        Return Convert.ToInt32(Convert.ToDecimal(txt))
    End Function
    Function NumberToText(num As Integer) As String
        'Constants are Defined
        Dim digit(100) As String
        digit(0) = ""
        digit(1) = "One "
        digit(2) = "Two "
        digit(3) = "Three "
        digit(4) = "Four "
        digit(5) = "Five "
        digit(6) = "Six "
        digit(7) = "Seven "
        digit(8) = "Eight "
        digit(9) = "Nine "
        digit(10) = "Ten "
        digit(11) = "Eleven "
        digit(12) = "Twelve "
        digit(13) = "Thirteen "
        digit(14) = "Fourteen "
        digit(15) = "Fifteen "
        digit(16) = "Sixteen "
        digit(17) = "Seventeen "
        digit(18) = "Eighteen "
        digit(19) = "Ninteen "
        digit(20) = "Twenty "
        digit(30) = "Thirty "
        digit(40) = "Fourty "
        digit(50) = "Fifty "
        digit(60) = "Sixty "
        digit(70) = "Seventy "
        digit(80) = "Eighty "
        digit(90) = "Ninty "
        digit(100) = "Hundred "
        Dim tt(5) As String
        tt(2) = "Thousand "
        tt(3) = "Lakh "
        tt(4) = "Crore "
        tt(5) = "Hundred Crore "
        'Separating the Whole Number and Digits
        Dim nn As String
        Dim dd As String = ""
        nn = Math.Round(Val(num), 2)
        If InStr(nn, ".") <> 0 Then
            dd = Mid(nn, InStr(nn, ".") + 1)
            nn = Mid(nn, 1, InStr(nn, ".") - 1)
        End If

        'Variable nn stores the whole number and dd stores the digits
        'Finding the Word for numbers

        Dim x As Integer
        Dim y As Integer = 0
        x = nn.Length - 1
        Dim z As String
        Dim str As String = ""
        Dim str1 As String = ""
        If x > 1 Then
            While (x > -1)
                'First Loop Last two digits of Number is evaluated(ones and Tens)
                If y = 0 Then
                    z = Mid(nn, x, 2)
                    If Val(z) < 21 And Val(z) > 0 Then
                        str = digit(Val(z))
                    ElseIf Val(z) > 0 Then
                        str = digit(Val(z(0)) * 10)
                        str = str & digit(Val(z(1)))
                    End If
                    x = x - 1
                End If


                'Second Loop 3rd digits of Number is evaluated(Hundred)

                If y = 1 Then
                    z = Mid(nn, x, 1)
                    If Val(z) <> 0 Then
                        str = digit(Val(z)) & "Hundred " & str
                    End If
                    x = x - 2
                End If

                'Subsequent Loop Next two digits sequence of Number is evaluated(Thousands,Lakhs,Crore,etc)


                If y > 1 Then
                    If x <> 0 Then
                        z = Mid(nn, x, 2)
                        If Val(z) < 21 And Val(z) > 0 Then
                            str = digit(Val(z)) & tt(y) & str
                        ElseIf Val(z) > 0 Then
                            str1 = digit(Val(z(0)) * 10)
                            str = str1 & digit(Val(z(1))) & tt(y) & str
                        End If
                        x = x - 2
                    Else
                        z = Mid(nn, 1, 1)
                        If Val(z) < 21 And Val(z) > 0 Then
                            str = digit(Val(z)) & tt(y) & str
                        ElseIf Val(z) > 0 Then
                            str1 = digit(Val(z(0)) * 10)
                            str = str1 & digit(Val(z(1))) & tt(y) & str
                        End If
                        x = -1
                    End If
                End If
                y = y + 1
            End While
        Else
            If Val(nn) < 21 And Val(nn) > 0 Then
                str = digit(Val(nn))
            ElseIf Val(nn) > 0 Then
                str = digit(Val(nn(0)) * 10)
                str = str & digit(Val(nn(1)))
            End If

            'str = digit(nn)

        End If
        If str = "" Then
            str = "Zero "
        End If
        str = str & "Rupees "

        'Digits are evaluated(Paise)

        If Val(dd) > 0 Then
            If dd.Length = 1 Then
                z = Val(dd) * 10
            Else
                z = dd
            End If

            If Val(z) < 21 And Val(z) > 0 Then
                str = str & "and " & digit(Val(z)) & "Paise"
            ElseIf Val(z) > 0 Then
                str1 = digit(Val(z(0)) * 10)
                str = str & "and " & str1 & digit(Val(z(1))) & "Paise"
            End If
        End If

        'Word string is returned

        Return str
    End Function
    Public Function Date_Set_Curr(Doubal As Boolean) As DialogResult
        With Date_frm
            .Doubal_ = Doubal
            .curr_TXT.Text = Date_3
            '.TopLevel = False
            'BG_frm.BG_PAN.Controls.Add(Date_frm)
            '.Dock = DockStyle.Fill
            Return .ShowDialog
        End With
    End Function
    Public Function Curr_Date(Curr As Object)
        With Date_frm
            .Doubal_ = False
            .Curr_Obj = Curr
            .TopLevel = False
            BG_frm.BG_PAN.Controls.Add(Date_frm)
            .Dock = DockStyle.Fill
            .BringToFront()
            .Show()
            .Focus()
        End With
    End Function
    Public Function List_Curr_(sender As Object)
        Try
            If List_frm.List_Grid.RowCount = 0 Then
                sender.Text = sender.Text.Substring(0, sender.Text.Length - 1)
                SendKeys.Send("{End}")
                NOT_(Text_Action(vl.Select_Current, ""), NOT_Type.Warning)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Public Function Data_Delete(file As Database_File, TBL As String, Filter As String) As Boolean
        If open_MSSQL(file) Then
            qury = $"DELETE FROM TBL_VC Where Tra_ID = {Filter};
DELETE FROM TBL_Attendance_VC Where Tra_ID = {Filter} and TBL_VC_ID = 'NA';
DELETE FROM TBL_VC_Ledger Where Tra_ID = {Filter};
DELETE FROM TBL_VC_Other Where Tra_ID = {Filter};
DELETE FROM TBL_VC_Item_Other_Details Where Tra_ID = {Filter};
DELETE FROM TBL_VC_Item_Details Where Tra_ID = {Filter};
DELETE FROM TBL_VC_Payroll Where Tra_ID = {Filter};
"
            cmd = New SQLiteCommand(qury, con)
            cmd.ExecuteNonQuery()
        End If
        Return True
    End Function
    Public Function Audit_Vouchers(Tra_ID As String) As Boolean
        If Val(Tra_ID) = 0 Then
            Return True
        End If

        If Audit_Save("TBL_VC", "Tra_ID", Tra_ID) = True Then
            If Audit_Save("TBL_Attendance_VC", "Tra_ID", Tra_ID) = True Then
                If Audit_Save("TBL_VC_Ledger", "Tra_ID", Tra_ID) = True Then
                    If Audit_Save("TBL_VC_Other", "Tra_ID", Tra_ID) = True Then
                        If Audit_Save("TBL_VC_Item_Other_Details", "Tra_ID", Tra_ID) = True Then
                            If Audit_Save("TBL_VC_Item_Details", "Tra_ID", Tra_ID) = True Then
                                If Audit_Save("TBL_VC_Payroll", "Tra_ID", Tra_ID) = True Then
                                    Return True
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Function
    Public Function Byte_(st As String) As Byte()
        'Dim F_str As FileStream = New FileStream(st, FileMode.Open, FileAccess.Read)
        'Dim B_red As BinaryReader = New BinaryReader(F_str)
        'F_str.Close()
        'Dim Byt() As Byte = B_red.ReadBytes(F_str.Length)


        Dim fs As FileStream = New FileStream(st, FileMode.Open, FileAccess.Read)
        Dim br As BinaryReader = New BinaryReader(fs)
        Dim bm() As Byte = br.ReadBytes(fs.Length)
        fs.Close()
        Dim Byt() As Byte = bm

        Return Byt
    End Function
    Public Function ImageToByteArray(ByVal img As System.Drawing.Image) As Byte()
        Dim converter As ImageConverter = New ImageConverter()
        Return CType(converter.ConvertTo(img, GetType(Byte())), Byte())
    End Function
    Public Function ImageFormat_(st As String) As ImageFormat
        Select Case st
            Case ".png"
                Return ImageFormat.Png
            Case ".gif"
                Return ImageFormat.Gif
            Case ".tiff"
                Return ImageFormat.Tiff
            Case ".bmp"
                Return ImageFormat.Bmp
            Case ".jpeg"
                Return ImageFormat.Jpeg
            Case ".jpg"
                Return ImageFormat.Jpeg
            Case ".jpg2"
                Return ImageFormat.Jpeg
            Case ".ico"
                Return ImageFormat.Icon
        End Select
    End Function
    Public Function lISt_sEleCt_auTo(TXT As String)
        Try
            If List_frm.Visible = True Then
                For i As Integer = 0 To List_frm.List_Grid.Rows.Count - 1
                    Dim ro As DataGridViewRow = List_frm.List_Grid.Rows(i)
                    If ro.Cells(1).Value = TXT Then
                        List_frm.List_Grid.CurrentCell = List_frm.List_Grid.Rows(i).Cells(1)
                        Exit For
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Function
    Public Function Grid_Count(Grid As DataGridView, Cel As Integer) As Decimal
        Try
            Dim vl As Decimal = 0.00
            For Each Ro As DataGridViewRow In Grid.Rows
                If Val(Ro.Cells(Cel).Value) > 0 Then
                    vl += Val(Ro.Cells(Cel).Value)
                End If
            Next
            Return Format(vl, "0.00")
        Catch ex As Exception

        End Try

    End Function
    Public Function Send_WhatsApp_api(Data As String)
        Dim uri As String = "https://graph.facebook.com/v15.0/100170019575633/messages"
        Dim request As Net.HttpWebRequest = Net.HttpWebRequest.Create(uri)

        request.Method = "POST"

        request.Headers.Add("Authorization", "Bearer EAAJO1scRN0cBAGRde5YNru9PwApXZCyIsHdDZB8zu4zJDKBNPQxizIcdDbeRK4ZBoWz6L6MebGDeX3fzjQkEgJxmaXiqv6lffhOweRDAP4btFxcbhfLwNFXMOXR8ze6zgqPUMK7b0J5FZBzYCztYtf1DOxhtxmiYmTHrZBSAyGjkyfXXf6ZCulO7jM1MJHl5PSHdehioeXYgZDZD")
        Dim json_data As String = Data

        request.ContentType = "application/json"
        Dim json_bytes() As Byte = System.Text.Encoding.ASCII.GetBytes(json_data)
        request.ContentLength = json_bytes.Length

        Dim stream As IO.Stream = request.GetRequestStream

        stream.Write(json_bytes, 0, json_bytes.Length)


        Dim response As Net.HttpWebResponse = request.GetResponse

        Debug.Print(response.StatusDescription)

        Dim dataStream As IO.Stream = response.GetResponseStream()
        Dim reader As New IO.StreamReader(dataStream)
        Dim responseFromServer As String = reader.ReadToEnd()

        reader.Close()
        dataStream.Close()
        response.Close()


    End Function
    Public Function number_eng_guj(vl As String) As String
        vl = (vl)
        vl = vl.Replace("0", "૦")
        vl = vl.Replace("1", "૧")
        vl = vl.Replace("2", "૨")
        vl = vl.Replace("3", "૩")
        vl = vl.Replace("4", "૪")
        vl = vl.Replace("5", "૫")
        vl = vl.Replace("6", "૬")
        vl = vl.Replace("7", "૭")
        vl = vl.Replace("8", "૮")
        vl = vl.Replace("9", "૯")

        Return vl
    End Function
    Public Function Chack_Communication_allow(Ledger_Id As String, LD_Colunm As String) As Boolean
        Return YN_Boolean(Find_DT_Value(Database_File.cre, "TBL_Ledger", LD_Colunm, $"ID = '{Ledger_Id}'"))
    End Function
    Public Function path_validation(st As String, reples As String)
        st = st.Replace("\", reples)
        st = st.Replace("/", reples)
        st = st.Replace(":", reples)
        st = st.Replace("*", reples)
        st = st.Replace("?", reples)
        st = st.Replace("|", reples)
        st = st.Replace("<", reples)
        st = st.Replace(">", reples)

        Return st
    End Function
    Public Function Update_cfg(file As Database_File, TBL_ As String, head As String, vlu As String) As Boolean
        Dim cn As New SQLiteConnection
        Dim create_ As Boolean = True
        If open_MSSQL_Cstm(file, cn) = True Then
            cmd = New SQLiteCommand($"Select * From [{TBL_}] WHERE Head = '{head}'", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader()
            While r.Read
                If head = r("Head") Then
                    create_ = False
                End If
            End While
            r.Close()

            If create_ = True Then
                cmd = New SQLiteCommand($"INSERT INTO [{TBL_}] (Head) VALUES ('{head}')", cn)
                cmd.ExecuteNonQuery()
            End If

            qury = $"UPDATE {TBL_} SET Value = '{vlu}' WHERE Head = '{head}'"
            cmd = New SQLiteCommand(qury, cn)
            cmd.ExecuteNonQuery()
        End If
        Return True
    End Function
    Public Function From_Access(Head As String, Type As String) As Boolean
        Dim cn As New SQLiteConnection
        Dim vlu As String = ""
        If open_MSSQL_Cstm(Database_File.cmp, cn) = True Then
            cmd = New SQLiteCommand($"Select * From TBL_User_Authority where (Head = '{Head}')", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                vlu = r("Value")
            End While
            r.Close()
        End If


        If Type = "Create" Or Type = "Create_Close" Then
            If vlu = "Create Not Access" Or vlu = "Not Access" Then
                Return False
            Else
                Return True
            End If
        ElseIf Type = "Alter" Or Type = "Alter_Close" Then
            If vlu = "Alter Not Access" Or vlu = "Not Access" Then
                Return False
            Else
                Return True
            End If
        ElseIf Type = "Print" Then
            If vlu = "Print Not Access" Or vlu = "Not Access" Then
                Return False
            Else
                Return True
            End If
        ElseIf Type = "Display" Then
            If vlu = "Not Access" Then
                Return False
            Else
                Return True
            End If
        End If

        Return True
    End Function
    Public Enum PeriodCity_Type
        Fortnightly = 0
        Half_Yearly = 1
        Monthly = 2
        Quarterly = 3
        Weekly = 4
        Yearly = 5
    End Enum
    Public Function Date_PeriodCity(curr As Date, PeriodCity As PeriodCity_Type) As List(Of String)
        Dim list_ As New List(Of String)

        Dim f As Date
        If curr >= CDate($"01-01-{curr.ToString("yyyy")}") And curr <= CDate($"31-03-{curr.ToString("yyyy")}") Then
            f = $"01-04-{curr.AddYears(-1).ToString("yyyy")}"
        Else
            f = $"01-04-{curr.ToString("yyyy")}"
        End If

        If PeriodCity = 0 Then
            list_.Add($"01-04-{f.ToString("yyyy")}*15-04-{f.ToString("yyyy")}")
            list_.Add($"16-04-{f.ToString("yyyy")}*30-04-{f.ToString("yyyy")}")

            list_.Add($"01-05-{f.ToString("yyyy")}*15-05-{f.ToString("yyyy")}")
            list_.Add($"16-05-{f.ToString("yyyy")}*31-05-{f.ToString("yyyy")}")

            list_.Add($"01-06-{f.ToString("yyyy")}*15-06-{f.ToString("yyyy")}")
            list_.Add($"16-06-{f.ToString("yyyy")}*30-06-{f.ToString("yyyy")}")

            list_.Add($"01-07-{f.ToString("yyyy")}*15-07-{f.ToString("yyyy")}")
            list_.Add($"16-07-{f.ToString("yyyy")}*31-07-{f.ToString("yyyy")}")

            list_.Add($"01-08-{f.ToString("yyyy")}*15-08-{f.ToString("yyyy")}")
            list_.Add($"16-08-{f.ToString("yyyy")}*31-08-{f.ToString("yyyy")}")

            list_.Add($"01-09-{f.ToString("yyyy")}*15-09-{f.ToString("yyyy")}")
            list_.Add($"16-09-{f.ToString("yyyy")}*30-09-{f.ToString("yyyy")}")

            list_.Add($"01-10-{f.ToString("yyyy")}*15-10-{f.ToString("yyyy")}")
            list_.Add($"16-10-{f.ToString("yyyy")}*31-10-{f.ToString("yyyy")}")

            list_.Add($"01-11-{f.ToString("yyyy")}*15-11-{f.ToString("yyyy")}")
            list_.Add($"16-11-{f.ToString("yyyy")}*30-11-{f.ToString("yyyy")}")

            list_.Add($"01-12-{f.ToString("yyyy")}*15-12-{f.ToString("yyyy")}")
            list_.Add($"16-12-{f.ToString("yyyy")}*31-12-{f.ToString("yyyy")}")

            f = f.AddYears(1)

            list_.Add($"01-01-{f.ToString("yyyy")}*15-01-{f.ToString("yyyy")}")
            list_.Add($"16-01-{f.ToString("yyyy")}*31-01-{f.ToString("yyyy")}")

            list_.Add($"01-02-{f.ToString("yyyy")}*15-02-{f.ToString("yyyy")}")
            list_.Add($"16-02-{f.ToString("yyyy")}*{Month_last_date(f.ToString("MM"), f.ToString("yyyy"))}")

            list_.Add($"01-03-{f.ToString("yyyy")}*15-03-{f.ToString("yyyy")}")
            list_.Add($"16-03-{f.ToString("yyyy")}*31-03-{f.ToString("yyyy")}")
        ElseIf PeriodCity = 1 Then
            list_.Add($"01-04-{f.ToString("yyyy")}*30-09-{f.ToString("yyyy")}")
            list_.Add($"01-10-{f.ToString("yyyy")}*31-03-{f.AddYears(1).ToString("yyyy")}")
        ElseIf PeriodCity = 2 Then
            list_.Add($"01-04-{f.ToString("yyyy")}*30-04-{f.ToString("yyyy")}")
            list_.Add($"01-05-{f.ToString("yyyy")}*31-05-{f.ToString("yyyy")}")
            list_.Add($"01-06-{f.ToString("yyyy")}*30-06-{f.ToString("yyyy")}")
            list_.Add($"01-07-{f.ToString("yyyy")}*31-07-{f.ToString("yyyy")}")
            list_.Add($"01-08-{f.ToString("yyyy")}*31-08-{f.ToString("yyyy")}")
            list_.Add($"01-09-{f.ToString("yyyy")}*30-09-{f.ToString("yyyy")}")
            list_.Add($"01-10-{f.ToString("yyyy")}*31-10-{f.ToString("yyyy")}")
            list_.Add($"01-11-{f.ToString("yyyy")}*30-11-{f.ToString("yyyy")}")
            list_.Add($"01-12-{f.ToString("yyyy")}*31-12-{f.ToString("yyyy")}")
            f = f.AddYears(1)
            list_.Add($"01-01-{f.ToString("yyyy")}*31-01-{f.ToString("yyyy")}")
            list_.Add($"01-02-{f.ToString("yyyy")}*{Month_last_date(f.ToString("MM"), f.ToString("yyyy"))}")
            list_.Add($"01-03-{f.ToString("yyyy")}*31-03-{f.ToString("yyyy")}")

        ElseIf PeriodCity = 3 Then
            list_.Add($"01-04-{f.ToString("yyyy")}*30-06-{f.ToString("yyyy")}")
            list_.Add($"01-07-{f.ToString("yyyy")}*30-09-{f.ToString("yyyy")}")
            list_.Add($"01-10-{f.ToString("yyyy")}*31-12-{f.ToString("yyyy")}")
            f = f.AddYears(1)
            list_.Add($"01-01-{f.ToString("yyyy")}*31-03-{f.ToString("yyyy")}")
        ElseIf PeriodCity = 4 Then
        ElseIf PeriodCity = 5 Then
            f = "01-04-" & CDate(Company_Book_frm).ToString("yyyy")
            Dim last_date As Date = CDate(Company_Book_frm)

            Dim cn As New SQLiteConnection
            If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
                cmd = New SQLiteCommand("Select vc.[date] From TBL_VC vc
where vc.Visible = 'Approval'
ORDER by [date] desc LIMIT 1;", cn)
                Dim r As SQLiteDataReader
                r = cmd.ExecuteReader
                While r.Read
                    last_date = CDate(r("Date"))
                End While
                r.Close()
            End If
            cn.Close()
            Dim c As Integer = DateDiff(DateInterval.Year, CDate(f), CDate(last_date))
            For i As Integer = 0 To c
                list_.Add($"{f}*31-03-{f.AddYears(1).ToString("yyyy")}")
                f = f.AddYears(1)
            Next
        End If
        Return list_
    End Function
    Private Botom_Total_Grid As DataGridView

    Public Function Grid_Bottom(pan As Panel, bg As DataGridView)
        Dim gri As DataGridView
        Dim isnew As Boolean

        Try
            gri = CType(pan.Controls.Find(($"{bg}_totalgrid"), True).First, DataGridView)
            isnew = False
        Catch ex As Exception
            gri = New DataGridView
            isnew = True
        End Try

        If isnew = True Then
            gri.Name = $"{bg}_totalgrid"
            gri.BackgroundColor = bg.BackgroundColor
            gri.DefaultCellStyle.SelectionBackColor = bg.BackgroundColor
            gri.DefaultCellStyle.SelectionForeColor = Color.Black
            gri.ScrollBars = ScrollBars.None
            gri.ColumnHeadersVisible = False
            gri.GridColor = Color.DarkGray
            gri.BorderStyle = BorderStyle.None
            gri.CellBorderStyle = DataGridViewCellBorderStyle.Single
            gri.Dock = DockStyle.Bottom
            gri.RowHeadersVisible = False
            gri.Height = 20
            gri.ReadOnly = True
            gri.Enabled = False
            gri.RowTemplate.Height = 20
            gri.SendToBack()


            gri.Columns.Clear()
            For Each c As DataGridViewColumn In bg.Columns
                gri.Columns.Add(c.Name, c.HeaderText)
            Next
            For Each c As DataGridViewColumn In bg.Columns
                Dim i As Integer = c.Index


                gri.Columns(i).Width = c.Width
                gri.Columns(i).DefaultCellStyle.Alignment = c.DefaultCellStyle.Alignment
                gri.Columns(i).Visible = c.Visible
                gri.Columns(i).Frozen = c.Frozen
                gri.Columns(i).DisplayIndex = c.DisplayIndex

            Next

            pan.Controls.Add(gri)

            gri.Rows.Add("")

            Dim DGVVerticalScroll As VScrollBar = bg.Controls.OfType(Of VScrollBar).SingleOrDefault

            If DGVVerticalScroll.Visible Then
                gri.Width = bg.Width + DGVVerticalScroll.Width
            Else
                gri.Width = bg.Width
            End If
            Botom_Total_Grid = gri
            AddHandler bg.Scroll, AddressOf ScrollMe
        End If
        Return gri
    End Function

    Private Sub ScrollMe(ByVal sender As Object, ByVal e As EventArgs)
        Botom_Total_Grid.HorizontalScrollingOffset = sender.HorizontalScrollingOffset
    End Sub

    Public Function Find_IfscCode(IFSC As String) As String()
        Dim str As String()

        Dim Bank_ As String = ""
        Dim Branch_ As String = ""

        Try
            Dim url As New String($"https://ifsc.razorpay.com/{IFSC}")
            Dim httpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
            httpWebRequest.ContentType = "application/json"
            httpWebRequest.Method = "GET"

            Dim httpResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)
            Dim responseText As String

            Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                responseText = streamReader.ReadToEnd()
            End Using
            Dim json As String = responseText
            Dim r = JObject.Parse(json)

            Bank_ = r.Item("BANK").ToString
            Branch_ = r.Item("BRANCH").ToString

            httpResponse.Close()

        Catch ex As Exception
            Bank_ = ""
            Branch_ = ""
        End Try


        Return {Bank_, Branch_}
    End Function
    '    Public Function Update_Ledger_balance(l As String)
    '        Dim cn As New SQLiteConnection
    '        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
    '            cmd = New SQLiteCommand($"UPDATE TBL_VC SET Ledger_Closing = (Select SUM(ifnull(v.Credit_Amount,0))-SUM(ifnull(v.Debit_Amount,0)) From TBL_VC v Where v.Ledger = '{l}' AND v.[Date] <= TBL_VC.[Date] and v.Visible = 'Approval' and v.Effect_Ledger = 'Yes')
    'where Ledger = '{l}' and Visible = 'Approval' and [Date] > '{CDate(Date_Formate(Cfg_Setting.Default.Frm_Date)).ToString(Lite_date_Format)}';", cn)
    '            cmd.ExecuteNonQuery()
    '        End If
    '    End Function

    Public Function LoadBox(Head As String, Msg As String, img As Image, BackGroundW As BackgroundWorker)
        Dim frm As New Load_Box
        With frm
            .Head.Text = Head
            .Message.Text = Msg
            If IsNothing(img) Then
                .PictureBox1.Image = My.Resources.Loding_Progress
            Else
                .PictureBox1.Image = img
            End If
            .BackW = BackGroundW
            .ShowDialog()
        End With
    End Function

    Public Function Tra_ID_Search(Tra_ID As String, vc_type_ As String) As Integer
        Dim cn As New SQLiteConnection
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            If vc_type_ = "Create" Or vc_type_ = "Create_Close" Or vc_type_ = "Duplicate" Or vc_type_ = "Duplicate_Close" Or Val(Tra_ID) = 0 Then
                cmd = New SQLiteCommand($"SELECT MAX(Tra_ID) as Tra_ID FROM TBL_VC", cn)
                Dim r As SQLiteDataReader = cmd.ExecuteReader
                While r.Read
                    Tra_ID = Val(r("Tra_ID").ToString)
                End While
                r.Close()
                Tra_ID = Val(Tra_ID) + 1
            Else
                'TBL_VC
                qury = $"Delete From TBL_VC where Tra_ID = '{Tra_ID}';
Delete From TBL_VC_Other where Tra_ID = '{Tra_ID}';
Delete From TBL_VC_Ledger where Tra_ID = '{Tra_ID}';
Delete From TBL_VC_Item_Other_Details where Tra_ID = '{Tra_ID}';
Delete From TBL_VC_item_Details where Tra_ID = '{Tra_ID}';
Delete From TBL_Attendance_VC where Tra_ID = '{Tra_ID}';
Delete From TBL_VC_Payroll where Tra_ID = '{Tra_ID}';
"

                cmd = New SQLiteCommand(qury, cn)
                cmd.ExecuteNonQuery()


            End If
        End If
        Return Tra_ID
    End Function
    Public Function Audit_Save(TBL As String, Orignal_String As String, Orignal_ID As String) As Boolean
        If Audit_YN = False Then
            Return True
        End If


        Dim cn As New SQLiteConnection()
        open_MSSQL_Cstm(Database_File.cre, cn)

        Dim Parameters As New DataTable
        Parameters.Columns.Add("Name")

        Try
            cmd = New SQLiteCommand($"PRAGMA table_info('{TBL}')", cn)
            Dim r As SQLiteDataReader = cmd.ExecuteReader
            While r.Read
                If r("pk") <> 1 Then
                    Parameters.Rows.Add(r("name").ToString)
                End If
            End While
            r.Close()


            Return Audit_Sate(TBL, Orignal_String, Orignal_ID, Parameters, cn)
        Catch ex As Exception
            cn.Close()
            MsgBox(ex.Message)
            Return False
        End Try

    End Function

    Private Function Audit_Sate(TBL As String, Orignal_String As String, Orignal_ID As String, Parameters As DataTable, csn As SQLiteConnection) As Boolean
        Try

            Dim col As String = ""
            For Each s As DataRow In Parameters.Rows
                col &= $",[{s(0).ToString}]"
            Next
            col = col.Substring(1, col.Length - 1)

            Dim Q As String = $"--attach database '{Connection_Path}\{Connection_Data}\aud.db' as aud;
INSERT INTO aud.[{TBL}] ({col},[Original_ID],[Audit_ID]) SELECT {col},'{Orignal_ID}',ifnull((Select [Audit_ID] From aud.[{TBL}] where [Original_ID] = '{Orignal_ID}' Order By [Audit_ID] desc limit 1),0)+1 FROM [{TBL}] where {Orignal_String} = {Orignal_ID};"


            cmd = New SQLiteCommand(Q, cn_audit)
            cmd.ExecuteNonQuery()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

    End Function
    Public Function GetAllControls(control As Control) As IEnumerable(Of Control)
        Dim controls = control.Controls.Cast(Of Control)()
        Return controls.SelectMany(Function(ctrl) GetAllControls(ctrl)).Concat(controls)
    End Function
    Public Function RoundNumber(typ As Rounding_Type, Number As Decimal, RoundTo As Decimal) As Decimal
        If Number = 0 Or RoundTo = 0 Then
            Return Number
        End If
        'MessageBox.Show(typ)

        Dim cal_1 As Decimal = Number / RoundTo
        cal_1 = Math.Floor(cal_1)
        Dim cal_2 As Decimal = cal_1 * RoundTo
        cal_1 = Number - cal_2

        Dim Upp As Decimal = (RoundTo - cal_1)
        If Upp = RoundTo Then
            Upp = 0
        End If
        Dim Low As Decimal = cal_1 * -1
        Dim Normal As Decimal = (Math.Round(Number / RoundTo) - (Number / RoundTo)) * RoundTo

        If typ = 0 Then
            Return Number
        ElseIf typ = 1 Then
            Return Upp
        ElseIf typ = 2 Then
            Return Low
        ElseIf typ = 3 Then
            Return Normal
        End If

    End Function
    Public Enum Rounding_Type
        Not_Applicable = 0
        Up = 1
        Down = 2
        Normal = 3
    End Enum
    Public Function Find_Software_Details(Software_ID As String, col As String)
        For Each ro As DataRow In Dt_Software_Type.Rows
            If ro(0).ToString = Software_ID Then
                Return ro(col).ToString
            End If
        Next
    End Function
End Module
