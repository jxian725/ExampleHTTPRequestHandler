Imports System.IO
Imports System.Net

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim input As String = TextBox1.Text
        'Method 1
        'Address of URL
        Dim URL As String = "https://server/activationkey?key="
        Dim FullUrl As String = URL + input
        ' Get HTML data
        Dim client As WebClient = New WebClient()
        Dim data As Stream = client.OpenRead(FullUrl)
        Dim reader As StreamReader = New StreamReader(data)
        Dim str As String = ""
        str = reader.ReadLine()
        MsgBox(str)
        Do
            Console.WriteLine(str)
            str = reader.ReadLine()
            MsgBox(str)
        Loop Until (str = "")

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



End Class
