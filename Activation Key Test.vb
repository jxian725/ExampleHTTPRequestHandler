Imports System.IO
Imports System.Net

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RadioButton1.Checked = True
    End Sub

    Dim errorcode As Integer
    Dim counter As Integer
    Dim input As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        counter = 0
        Label1.Text = "HTTP Response"
        Label2.Text = "HTTP Request Sent!"
        Label2.Text = "Reading......"
        'Method 1
        'Address of URL
        If RadioButton1.Checked = True Then
            Selection1()
        ElseIf RadioButton2.Checked = True Then
            Selection2()
        Else
            MsgBox("Method Selection Error!")
        End If
        Label2.Text = "Done Reading!"
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        TextBox1.Text = "Enter Activation Key"
        TextBox2.Enabled = False
        Label1.Text = ""
        Label2.Text = ""
        TextBox2.Hide()
        Panel3.Show()
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        TextBox1.Text = "Enter your parameters (optional)"
        TextBox2.Enabled = True
        Label1.Text = ""
        Label2.Text = ""
        TextBox2.Show()
        Panel3.Hide()
    End Sub

    Private Sub TextBox2_Click(sender As Object, e As EventArgs) Handles TextBox2.Click
        If TextBox2.Text = "Enter your HTTP Link" Then
            TextBox2.Text = ""
        End If
    End Sub

    Private Sub TextBox1_Click(sender As Object, e As EventArgs) Handles TextBox1.Click
        If TextBox1.Text = "Enter your parameters (optional)" Then
            TextBox1.Text = ""
        ElseIf TextBox1.Text = "Enter Activation Key" Then
            TextBox1.Text = ""
        End If
    End Sub

    Public Sub Selection1()
        input = TextBox1.Text
        Label2.Text = "Reading......"
        Dim URL As String
        If RadioButtonv1.Checked = True Then
            URL = "https://asia-southeast2-uhs-shop-93690.cloudfunctions.net/activationkeyv1?key="
        ElseIf RadioButtonv2.Checked = True Then
            URL = "https://asia-southeast2-uhs-shop-93690.cloudfunctions.net/activationkeyv2?key="
        ElseIf RadioButtons1.Checked = True Then
            URL = "https://asia-southeast2-uhs-shop-93690.cloudfunctions.net/activationkeys1?key="
        Else
            MsgBox("Product Variation Error!")
        End If
        Dim FullUrl As String = URL + input
        ' Get HTML data
        Dim client As WebClient = New WebClient()
        Dim data As Stream = client.OpenRead(FullUrl)
        Dim reader As StreamReader = New StreamReader(data)
        Dim str As String = ""
        str = reader.ReadLine()
        Console.WriteLine(str)
        If str = "true" Then
            Label1.Text = "Activation Key: " + input + Environment.NewLine + "Activated = true"
        ElseIf str = "false" Then
            Label1.Text = "Activation Key: Invalid" + Environment.NewLine + "Activated = false"
        ElseIf str = "error" Then
            Label1.Text = "Error Fetching Key......"
        Else
            Label1.Text = "Unable to communicate with server!"
        End If
        Label2.Text = "Done Reading!"
    End Sub

    Public Sub Selection2()
        Label2.Text = "Reading......"
        Dim URL As String = TextBox2.Text
        Dim FullUrl As String = URL + input
        If TextBox1.Text = "Enter your parameters (optional)" Then
            FullUrl = URL
        End If
        ' Get HTML data
        Dim client As WebClient = New WebClient()
        Dim data As Stream
        Dim reader As StreamReader
        Try
            data = client.OpenRead(FullUrl)
            reader = New StreamReader(data)
        Catch ex As Exception
            MsgBox("Error 404! Invalid Link.")
            Return
        End Try
        Dim str As String
        str = reader.ReadLine()
        Console.WriteLine(str)
        Label1.Text = str
        Do While Not (str Is Nothing)
            If Not str = "" Then
                Dim GetText As String = Label1.Text
                str = reader.ReadLine()
                Console.WriteLine(str)
                Label1.Text = GetText + Environment.NewLine + str
            ElseIf counter > 10 Then
                Exit Do
            Else
                Dim GetText As String = Label1.Text
                str = reader.ReadLine()
                Console.WriteLine(str)
                Label1.Text = GetText + Environment.NewLine + str
                counter = counter + 1
            End If
        Loop
    End Sub
End Class
