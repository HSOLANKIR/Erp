Imports System.IO
Imports System.Net
Imports System.Data.SqlClient
Imports System.Data.SQLite
Public Class GST_Chack_frm
    Dim Path_End As String
    Dim VC_Type_ As String
    Dim VC_ID_ As String
    Private Sub GST_Chack_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Path_End = BG_frm.BG_Path_TXT.Text

        VC_Type_ = Link_Valu(0)
        VC_ID_ = Link_Valu(1)


        BG_frm.HADE_TXT.Text = "GST Search"
        BG_frm.TYP_TXT.Text = VC_Type_


        Button_Clear()
        Panel1.Height = 30

        Txt1.Text = VC_ID_
    End Sub

    Private Sub GST_Chack_frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub GST_Chack_frm_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        BG_frm.BG_Path_TXT.Text = Path_End
        BG_frm.TYP_TXT.Text = VC_Type_
        BG_frm.HADE_TXT.Text = "GST Search"
        BG_frm.BG_Path_TXT.Text &= "->" & BG_frm.HADE_TXT.Text
        Button_Clear()

        Txt1.Focus()
    End Sub

    Private Sub GST_Chack_frm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        BG_frm.BG_Path_TXT.Text = Path_End
        Frm_foCus()
    End Sub

    Private Sub Txt1_TextChanged(sender As Object, e As EventArgs) Handles Txt1.TextChanged
        Panel1.Height = 30
        obj_top(Panel1)
    End Sub

    Private Sub Txt1_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Txt1.Text.Length <> 15 Then
                Msg(NOT_Type.Warning, "Input Error", "Please check GST No and retry")
                Exit Sub
            End If
            'If Msg_Yn("Are you sure", $"Search GST No.{Txt1.Text}") = DialogResult.Yes Then
            If Panel1.Height = 30 Then
                If Search_() = True Then
                    Panel1.Height = 350
                Else
                    Panel1.Height = 30
                End If
            Else
                Button1.Focus()
            End If
            'End If
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        obj_top(sender)

    End Sub
    Private Function Apply(strData As String, Head As String, Last_str As String)
        Dim pos1 As Long, Pos2 As Long

        pos1 = InStr(strData, Head) + Head.Length - 1
        strData = strData.Substring(pos1, (strData.Length - pos1) - 1)
        Pos2 = InStr(strData, Last_str) - 1

        Return strData.Substring(0, Pos2)
    End Function
    Private Function Search_() As Boolean
        Try
            Dim pos1 As Long, Pos2 As Long, ANS As String
            'Dim requst As WebRequest = WebRequest.Create($"https://www.knowyourgst.com/gst-number-search/pollan-fertilizer-private-limited-{Txt1.Text}/")
            Dim requst As WebRequest = WebRequest.Create($"https://irisgst.com/gstin-filing-detail/?gstinno={Txt1.Text}")
            Dim responce As HttpWebResponse = CType(requst.GetResponse(), HttpWebResponse)
            Dim datatstrim As Stream = responce.GetResponseStream
            Dim readre As New StreamReader(datatstrim)
            Dim strData As String = readre.ReadToEnd


            'My.Computer.Clipboard.SetText(strData)

            Trade_Name.Text = Apply(strData, "Trade Name - </strong>", "</p>").ToString.Trim
            Legal_Name.Text = Apply(strData, "Legal Name of Business - </strong>", "</p>").ToString.Trim
            Ststus.Text = Apply(strData, "GSTIN / UIN Status - </strong>", "</p>").ToString.Trim
            Constitution_.Text = Apply(strData, "Constitution of Business - </strong>", "</p>").ToString.Trim
            Registration_.Text = Apply(strData, "Date of Registration - </strong>", "</p>").ToString.Trim
            GST_Type.Text = Apply(strData, "Taxpayer Type - </strong>", "</p>").ToString.Trim
            Label18.Text = Apply(strData, "Centre Jurisdiction - </strong>", "</p>").ToString.Trim
            Label15.Text = Apply(strData, "State Jurisdiction - </strong>", "</p>").ToString.Trim
            Additional_Place.Text = Apply(strData, "Additional Place of Business - </strong>", "</p>").ToString.Trim
            Nature.Text = Apply(strData, "Nature of Business Activities -", "</p>").ToString.Replace("</strong>", "").Trim
            Address.Text = Apply(strData, "Principal Place of Business -", "</p>").ToString.Replace("</strong>", "").Trim

            Return True
        Catch ex As Exception

            Msg(NOT_Type.Erro, "GST Find Error", ex.Message)
            Return False
        End Try
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Chack_Duplicate(Database_File.cre, "TBL_Ledger", "GSTNo", $"GSTNo = '{Txt1.Text.ToString}'") = True Then
            If Msg_Custom_YN(NOT_Location.Bottom_Right, Color.OrangeRed, My.Resources.Warning_animation_icn, Dialoag_Button.Yes_No, "Duplicate", "Duplicate GST No", "Ledger already exists") = DialogResult.Yes Then
                Add_()
            End If
        Else
            Add_()
        End If
    End Sub
    Private Function Add_()
        With Ledger_frm
            .Name_TXT.Text = Trade_Name.Text
            If Trade_Name.Text <> Legal_Name.Text Then
                .Alias_TXT.Text = Legal_Name.Text
            End If
            .Discription_TXT.Text = Nature.Text.Trim

            .Txt2.Text = GST_Type.Text
            .Address_TXT.Text = Address.Text
            .GST_TXT.Text = Txt1.Text
            .PAN_TXT.Text = Txt1.Text.Substring(2, 10)
            .Txt1.Text = "India"
            Me.Dispose()
            .Name_TXT.Focus()
        End With
    End Function

    Private Sub Address__Paint(sender As Object, e As PaintEventArgs) Handles Address_.Paint

    End Sub
End Class