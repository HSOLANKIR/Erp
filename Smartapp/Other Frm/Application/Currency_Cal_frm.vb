Imports System.ComponentModel
Imports System.Data.SQLite
Imports System.IO
Imports System.Net

Public Class Currency_Cal_frm
    Dim rat As Decimal = 0.00
    Dim fromCurrency As String, toCurrency As String
    Dim issuccess As Boolean
    Private Sub Currency_Cal_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Fill_Data()

        ComboBox1.DataSource = BindingSource1
        ComboBox1.DisplayMember = "Name"

        ComboBox2.DataSource = BindingSource2
        ComboBox2.DisplayMember = "Name"

        'Me.Label8.DataBindings.Clear()
        'Me.Label8.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "Symbol", True))
        'Me.Label9.DataBindings.Clear()
        'Me.Label9.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource2, "Symbol", True))
    End Sub
    Private Function Fill_Data()
        Dim cn As New SQLiteConnection
        Dim dt As New DataTable
        If open_MSSQL_Cstm(Database_File.cre, cn) = True Then
            Dim dr As DataRow
            dt.Clear()
            dt.Columns.Add("Code")
            dt.Columns.Add("Country_Name")
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
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
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

            rat = Format(Val(strData.Substring(pos1 + 22, Pos2 - pos1 - 38)), "0.00")
            issuccess = True
        Catch ex As Exception
            issuccess = False
            Msg(NOT_Type.Erro, "Error", ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        fromCurrency = ComboBox1.Text.ToString.Substring(0, 3)
        toCurrency = ComboBox2.Text.ToString.Substring(0, 3)
        Load_(Label7)
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If issuccess = True Then
            Label5.Text = Format(Val(Val(NumericUpDown1.Value) * Val(rat)), "0.00") & Label9.Text
            Label6.Text = "1 " & Label8.Text & " to " & rat & " " & Label9.Text
            Load_(Panel3)
        Else
            Load_(Label7)
            Label7.Hide()
        End If
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Function Load_(ob As Object)
        Label7.Hide()
        Panel3.Hide()
        ob.Show()
    End Function
End Class