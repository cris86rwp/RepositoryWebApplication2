Imports System.Net
Imports System.Net.Mail

Public Class send_email
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SendMail()
    End Sub

    Public Sub SendMail()
        Dim APIKey1 As String = "95f0f61edc6954a4ba18bd8d0a687a64"
        Dim SecretKey1 As String = "a6a93c7cdb139d42799bef64b0b44845"
        Dim client As New System.Net.Mail.SmtpClient("smtp.gmail.com", 587)
        Dim msg As New System.Net.Mail.MailMessage()
        Dim subtext As String = "This is subject line"
        Dim bdtext As String = "Hi, This article is based on how to use System.Net.Mail namspace to send emails"

        msg.To.Add("prajesh.kr@gmail.com")
        msg.From = New MailAddress("prajesh.kr@gmail.com")
        msg.Subject = subtext
        msg.Body = bdtext
        'msg.Priority = "high"

        client.Credentials = New Net.NetworkCredential("prajesh.kr@gmail.com", "Rajesh")
        client.EnableSsl = True
        'client.UseDefaultCredentials = True

        client.Send(msg)



    End Sub
End Class