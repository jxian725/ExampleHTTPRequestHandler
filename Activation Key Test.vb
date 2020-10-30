Imports System.IO
Imports System.Net

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Timer1.Start()
        Label2.Text = "HTTP Request Sent!"
        Dim input As String = TextBox1.Text
        'Method 1
        'Address of URL
        Dim URL As String = "http://bit.ly/UHSPremium?key="
        Dim FullUrl As String = URL + input
        ' Get HTML data
        Dim client As WebClient = New WebClient()
        Dim data As Stream = client.OpenRead(FullUrl)
        Dim reader As StreamReader = New StreamReader(data)
        Dim str As String = ""
        str = reader.ReadLine()
        If str = "true" Then
            Label1.Text = "Activation Key: " + input + Environment.NewLine + "Activated = true"
        ElseIf str = "false" Then
            Label1.Text = "Activation Key: Invalid" + Environment.NewLine + "Activated = false"
        Else
            MsgBox("Unable to communicate with server!")
        End If
        'MsgBox(str)

        '    'Method 2
        '    Try
        '        Dim fr As System.Net.HttpWebRequest
        '        Dim targetURI As New Uri("https://uhspremium.com/")

        '        fr = DirectCast(HttpWebRequest.Create(targetURI), System.Net.HttpWebRequest)
        '        If (fr.GetResponse().ContentLength > 0) Then
        '            Dim str As New System.IO.StreamReader(fr.GetResponse().GetResponseStream())
        '            Response.Write(str.ReadToEnd())
        '            str.Close(); 
        '       End If
        '    Catch ex As System.Net.WebException
        '        'Error in accessing the resource, handle it
        '        MsgBox("Error")
        '    End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label2.Text = ""
        Timer1.Stop()
    End Sub
End Class
