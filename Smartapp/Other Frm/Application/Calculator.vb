Imports System.ComponentModel
Imports System.Data.SQLite
Imports System.IO
Imports System.Net

Public Class Calculator
    Dim Clear_ As New Boolean
    Dim Cal As String
    Dim Simbol As String
    Private Sub Calculator_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Fill_Data()
        List_set()
        bg_Panel.Size = New Size(370, 620)

    End Sub
    Dim cou1_list As List_frm
    Dim cou2_list As List_frm
    Private Function List_set()
        cou1_list = New List_frm
        List_Setup("List of Countries", Select_List.Right, Select_List_Format.Defolt, Txt1, cou1_list, BindingSource1, 320)

        cou2_list = New List_frm
        List_Setup("List of Countries", Select_List.Right, Select_List_Format.Defolt, Txt2, cou2_list, BindingSource2, 320)

    End Function

    Private Function Fill_Data()
        Dim cn As New SQLiteConnection
        Dim dt As New DataTable
        If open_MSSQL_Cstm(Database_File.cfgs, cn) = True Then
            Dim dr As DataRow
            dt.Clear()
            dt.Columns.Add("Country_Name")
            dt.Columns.Add("Code")
            dt.Columns.Add("Currency_Name")
            dt.Columns.Add("Symbol")
            dt.Columns.Add("Name")
            cmd = New SQLiteCommand("Select * From TBL_Currency", cn)
            Dim r As SQLiteDataReader
            r = cmd.ExecuteReader
            While r.Read
                dr = dt.NewRow
                dr("Code") = r("Code")
                dr("Country_Name") = r("Country_Name")
                dr("Currency_Name") = r("Currency_Name")
                dr("Symbol") = r("Symbol")
                dr("Name") = r("Code") & " (" & r("Currency_Name") & ")"
                dt.Rows.Add(dr)
            End While
            r.Close()
        End If

        BindingSource1.DataSource = dt
        BindingSource2.DataSource = dt
    End Function
    Private Sub Calculator_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter AndAlso e.Modifiers = Keys.Shift Then
            Button24.PerformClick()
            Frm_foCus()
            SendKeys.Send(nUmBeR_FORMATE(Textbox1.Text.Trim))
            Me.Dispose()
        End If
        If e.KeyCode = Keys.Delete Then
            Button3.PerformClick()
        End If
        If e.KeyCode = Keys.Escape Then
            If Val(Textbox1.Text) = 0 Then
                Me.Dispose()
            End If
            Button2.PerformClick()
        End If
        If e.KeyCode = Keys.Back Then
            Button4.PerformClick()
        End If
        If e.KeyCode = Keys.Multiply Then
            Button12.PerformClick()
        End If
        If e.KeyCode = Keys.Divide Then
            Button8.PerformClick()
        End If
        If e.KeyCode = Keys.Oemplus Then
            Button20.PerformClick()
        End If
        If e.KeyCode = Keys.OemMinus Then
            Button16.PerformClick()
        End If
        If e.KeyCode = Keys.Enter Then
            Button24.PerformClick()
        End If

        If e.KeyCode = Keys.NumPad1 Or e.KeyCode = Keys.D1 Then
            Button17.PerformClick()
        End If
        If e.KeyCode = Keys.NumPad2 Or e.KeyCode = Keys.D2 Then
            Button18.PerformClick()
        End If
        If e.KeyCode = Keys.NumPad3 Or e.KeyCode = Keys.D3 Then
            Button19.PerformClick()
        End If
        If e.KeyCode = Keys.NumPad4 Or e.KeyCode = Keys.D4 Then
            Button13.PerformClick()
        End If
        If e.KeyCode = Keys.NumPad5 Or e.KeyCode = Keys.D5 Then
            Button14.PerformClick()
        End If
        If e.KeyCode = Keys.NumPad6 Or e.KeyCode = Keys.D6 Then
            Button15.PerformClick()
        End If
        If e.KeyCode = Keys.NumPad7 Or e.KeyCode = Keys.D7 Then
            Button9.PerformClick()
        End If
        If e.KeyCode = Keys.NumPad8 Or e.KeyCode = Keys.D8 Then
            Button10.PerformClick()
        End If
        If e.KeyCode = Keys.NumPad9 Or e.KeyCode = Keys.D9 Then
            Button11.PerformClick()
        End If
        If e.KeyCode = Keys.NumPad0 Or e.KeyCode = Keys.D0 Then
            Button22.PerformClick()
        End If
        If e.KeyCode = Keys.Decimal Then
            Button23.PerformClick()
        End If
        If e.KeyCode = Keys.OemPeriod Then
            Button1.PerformClick()
        End If
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click, Button9.Click, Button10.Click, Button11.Click, Button13.Click, Button14.Click, Button15.Click, Button18.Click, Button19.Click, Button22.Click, Button23.Click
        If Clear_ = True Then
            Textbox1.Text = ""
            Textbox1.Text &= sender.Text
            Clear_ = False
        Else
            Textbox1.Text &= sender.Text
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Textbox1.Text = ""
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Label2.Text = ""
        Textbox1.Text = ""
        Cal = ""
        Button8.Enabled = True
        Button12.Enabled = True
        Button16.Enabled = True
        Button20.Enabled = True
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Textbox1.Text.Length > 0 Then
            Textbox1.Text = Textbox1.Text.Substring(0, Textbox1.Text.Length - 1)
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If Label2.Text = "" Then
            Label2.Text = Textbox1.Text & "÷"
            Cal = Textbox1.Text
        Else
            Label2.Text &= Textbox1.Text & "÷"
            Cal /= Val(Textbox1.Text)
            Textbox1.Text = Format(Val(Cal), "#.##")
        End If
        Clear_ = True
        Simbol = "÷"
        Button_Enable(sender)
    End Sub
    Private Function Button_Enable(Btn As Button)
        Button8.Enabled = False
        Button12.Enabled = False
        Button16.Enabled = False
        Button20.Enabled = False
        Button1.Enabled = False
        Button5.Enabled = False
        Button6.Enabled = False
        Btn.Enabled = True
    End Function

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        If Label2.Text = "" Then
            Label2.Text = Textbox1.Text & "x"
            Cal = Textbox1.Text
        Else
            Label2.Text &= Textbox1.Text & "x"
            Cal *= Val(Textbox1.Text)
            Textbox1.Text = Format(Val(Cal), "#.##")
        End If
        Clear_ = True
        Simbol = "x"
        Button_Enable(sender)
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        If Label2.Text = "" Then
            Label2.Text = Textbox1.Text & "-"
            Cal = Textbox1.Text
        Else
            Label2.Text &= Textbox1.Text & "-"
            Cal -= Val(Textbox1.Text)
            Textbox1.Text = Format(Val(Cal), "#.##")
        End If
        Clear_ = True
        Simbol = "-"
        Button_Enable(sender)
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        If Label2.Text = "" Then
            Label2.Text = Textbox1.Text & "+"
            Cal = Textbox1.Text
        Else
            Label2.Text &= Textbox1.Text & "+"
            Cal += Val(Textbox1.Text)
            Textbox1.Text = Format(Val(Cal), "#.##")
        End If
        Clear_ = True
        Simbol = "+"
        Button_Enable(sender)
    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        Button8.Enabled = True
        Button12.Enabled = True
        Button16.Enabled = True
        Button20.Enabled = True
        Button1.Enabled = True
        Button5.Enabled = True
        Button6.Enabled = True
        Sub_Calculation()
        Label2.Text = Textbox1.Text
        Clear_ = True
        Label2.Text = ""
    End Sub
    Private Function Sub_Calculation()
        If Simbol = "+" Then
            If Label2.Text = "" Then
                Label2.Text = Textbox1.Text & "+"
                Cal = Textbox1.Text
            Else
                Label2.Text &= Textbox1.Text & "+"
                Cal += Val(Textbox1.Text)
                Textbox1.Text = Format(Val(Cal), "#.##")
            End If
            Clear_ = True
        Else
            If Simbol = "x" Then
                If Label2.Text = "" Then
                    Label2.Text = Textbox1.Text & "x"
                    Cal = Textbox1.Text
                Else
                    Label2.Text &= Textbox1.Text & "x"
                    Cal *= Val(Textbox1.Text)
                    Textbox1.Text = Format(Val(Cal), "#.##")
                End If
                Clear_ = True
            Else
                If Simbol = "÷" Then
                    If Label2.Text = "" Then
                        Label2.Text = Textbox1.Text & "÷"
                        Cal = Textbox1.Text
                    Else
                        Label2.Text &= Textbox1.Text & "÷"
                        Cal /= Val(Textbox1.Text)
                        Textbox1.Text = Format(Val(Cal), "#.##")
                    End If
                    Clear_ = True
                Else
                    If Simbol = "-" Then
                        If Label2.Text = "" Then
                            Label2.Text = Textbox1.Text & "-"
                            Cal = Textbox1.Text
                        Else
                            Label2.Text &= Textbox1.Text & "-"
                            Cal -= Val(Textbox1.Text)
                            Textbox1.Text = Format(Val(Cal), "#.##")
                        End If
                        Clear_ = True
                    Else
                        If Simbol = "%" Then
                            Label2.Text = Textbox1.Text
                            Clear_ = True
                        End If
                    End If
                End If
            End If
        End If
    End Function

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        If Val(Textbox1.Text) > 0 Then
            Textbox1.Text = "-" & Textbox1.Text
        Else
            If Val(Textbox1.Text) < 0 Then
                Textbox1.Text = Val(Textbox1.Text) - (Val(Textbox1.Text) * 2)
            End If
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Cal = Val(Textbox1.Text) * Val(Textbox1.Text)
        Label2.Text &= Textbox1.Text & "²"
        Textbox1.Text = Format(Val(Cal), "#.##")
        Simbol = "X2"
        Button_Enable(sender)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Cal = ((Val(Textbox1.Text) * Val(Textbox1.Text)) * Val(Textbox1.Text))
        Label2.Text &= Textbox1.Text & "³"
        Textbox1.Text = Format(Val(Cal), "#.##")
        Simbol = "X2"
        Button_Enable(sender)
    End Sub

    Private Sub Calculator_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        Try
            Label17.Text = NumberToText(Val(Textbox1.Text))
        Catch ex As Exception
            Label17.Text = "Error!"
        End Try
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedTab Is TabPage1 Then
            bg_Panel.Size = New Size(370, 620)
        ElseIf TabControl1.SelectedTab Is TabPage2 Then
            bg_Panel.Size = New Size(467, 263)
        ElseIf TabControl1.SelectedTab Is TabPage3 Then
            bg_Panel.Size = New Size(370, 638)
        End If
    End Sub

    Private Sub Txt1_TextChanged(sender As Object, e As EventArgs) Handles Txt1.TextChanged

    End Sub

    Private Sub Txt1_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Label11.Text = cou1_list.List_Grid.CurrentRow.Cells(1).Value
        End If
    End Sub
    Private Sub Txt2_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt2.KeyDown
        If e.KeyCode = Keys.Enter Then
            Label10.Text = cou2_list.List_Grid.CurrentRow.Cells(1).Value
        End If
    End Sub


    Dim fromCurrency As String, toCurrency As String
    Dim issuccess As Boolean
    Dim rat As Decimal = 0.00

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        fromCurrency = Label11.Text
        toCurrency = Label10.Text
        Panel_manage_curr(currancy_load_panel)
        Txt3.Focus()
        SendKeys.Send("+{TAB}")
        currency_back.RunWorkerAsync()
    End Sub

    Private Sub currency_back_DoWork(sender As Object, e As DoWorkEventArgs) Handles currency_back.DoWork
        Try
            Dim pos1 As Long, Pos2 As Long, ANS As String
            Dim requst As WebRequest = WebRequest.Create(String.Format("https://www.calculator.net/currency-calculator.html?eamount={0}&efrom={1}&eto={2}&ccmajorccsettingbox=1&type=1&x=56&y=28", 1, fromCurrency, toCurrency))
            Dim responce As HttpWebResponse = CType(requst.GetResponse(), HttpWebResponse)
            Dim datatstrim As Stream = responce.GetResponseStream
            Dim readre As New StreamReader(datatstrim)
            Dim strData As String = readre.ReadToEnd

            pos1 = InStr(strData, "1 " & fromCurrency)
            pos1 = InStr(pos1 + 1, strData, "=", vbTextCompare)
            Pos2 = InStr(pos1 + 1, strData, toCurrency, vbTextCompare)

            rat = Format(Val(strData.Substring(pos1 + 22, Pos2 - pos1 - 30)))
            issuccess = True
        Catch ex As Exception
            issuccess = False
            Msg(NOT_Type.Erro, "Error", ex.Message)
        End Try
    End Sub

    Private Function Panel_manage_curr(pa As Panel)
        currency_panel.Visible = False
        currancy_load_panel.Visible = False

        pa.Visible = True
        pa.Dock = DockStyle.Top
    End Function

    Private Sub Txt4_TextChanged(sender As Object, e As EventArgs) Handles Txt4.TextChanged
        Label16.Text = N2_FORMATE(Val(sender.Text) * 1)
        cal_()
    End Sub

    Private Sub Txt5_TextChanged(sender As Object, e As EventArgs) Handles Txt5.TextChanged
        Label18.Text = N2_FORMATE(Val(sender.Text) * 2)
        cal_()
    End Sub

    Private Sub Txt6_TextChanged(sender As Object, e As EventArgs) Handles Txt6.TextChanged
        Label20.Text = N2_FORMATE(Val(sender.Text) * 5)
        cal_()
    End Sub

    Private Sub Txt7_TextChanged(sender As Object, e As EventArgs) Handles Txt7.TextChanged
        Label22.Text = N2_FORMATE(Val(sender.Text) * 10)
        cal_()
    End Sub

    Private Sub Txt8_TextChanged(sender As Object, e As EventArgs) Handles Txt8.TextChanged
        Label24.Text = N2_FORMATE(Val(sender.Text) * 20)
        cal_()
    End Sub

    Private Sub Txt9_TextChanged(sender As Object, e As EventArgs) Handles Txt9.TextChanged
        Label27.Text = N2_FORMATE(Val(sender.Text) * 50)
        cal_()
    End Sub

    Private Sub Txt10_TextChanged(sender As Object, e As EventArgs) Handles Txt10.TextChanged
        Label29.Text = N2_FORMATE(Val(sender.Text) * 100)
        cal_()
    End Sub

    Private Sub Txt11_TextChanged(sender As Object, e As EventArgs) Handles Txt11.TextChanged
        Label31.Text = N2_FORMATE(Val(sender.Text) * 500)
        cal_()
    End Sub
    Private Sub Txt12_TextChanged(sender As Object, e As EventArgs) Handles Txt12.TextChanged
        Label37.Text = N2_FORMATE(Val(sender.Text) * 200)
        cal_()
    End Sub

    Private Function cal_()
        Label35.Text = N2_FORMATE(nUmBeR_FORMATE(Txt4.Text) + nUmBeR_FORMATE(Txt5.Text) + nUmBeR_FORMATE(Txt6.Text) + nUmBeR_FORMATE(Txt7.Text) + nUmBeR_FORMATE(Txt8.Text) + nUmBeR_FORMATE(Txt9.Text) + nUmBeR_FORMATE(Txt10.Text) + nUmBeR_FORMATE(Txt11.Text) + nUmBeR_FORMATE(Txt12.Text))
        Label36.Text = N2_FORMATE(nUmBeR_FORMATE(Label16.Text) + nUmBeR_FORMATE(Label18.Text) + nUmBeR_FORMATE(Label20.Text) + nUmBeR_FORMATE(Label22.Text) + nUmBeR_FORMATE(Label24.Text) + nUmBeR_FORMATE(Label27.Text) + nUmBeR_FORMATE(Label29.Text) + nUmBeR_FORMATE(Label31.Text) + nUmBeR_FORMATE(Label37.Text))
    End Function

    Private Sub Panel25_Paint(sender As Object, e As PaintEventArgs) Handles bg_Panel.Paint
        obj_center(sender, Me)
    End Sub

    Private Sub currency_back_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles currency_back.RunWorkerCompleted
        If issuccess = True Then
            Label13.Text = $"{Format(Val(Val(Txt3.Text) * Val(rat)), "0.00")} {Label10.Text}"
            Label12.Text = $"1 {Label11.Text} to {rat} {Label10.Text}"

        Else
        End If
        Panel_manage_curr(currency_panel)

        Txt3.Focus()
    End Sub

End Class