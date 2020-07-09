Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports Microsoft.ApplicationBlocks.Data

Public Class logon
    Inherits System.Web.UI.Page
    Protected WithEvents lblmessage As System.Web.UI.WebControls.Label
    Protected WithEvents lblapplication As System.Web.UI.WebControls.Label
    Protected WithEvents group As System.Web.UI.WebControls.Label
    Protected WithEvents empcode As System.Web.UI.WebControls.Label
    Protected WithEvents password As System.Web.UI.WebControls.Label
    Protected WithEvents txtempcode As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpassword As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddapplication As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddgroup As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnlogin As System.Web.UI.WebControls.Button
    'Protected WithEvents Buttongrp As System.Web.UI.WebControls.Button
    Protected WithEvents btnclear As System.Web.UI.WebControls.Button

    Dim rdr As SqlDataReader

    Protected Sub btnlogin_Click(sender As Object, e As EventArgs) Handles btnlogin.Click


        Dim Ecode As String = txtempcode.Text
        Dim Pass As String = txtpassword.Text

        Dim con As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
        con.Open()
        Dim cmd As New SqlCommand("SELECT COUNT(*) FROM menu_your_password_new where employee_code=@Ecode and password=@Pass ", con)

        cmd.Parameters.AddWithValue("@Ecode", Ecode)
        cmd.Parameters.AddWithValue("@Pass", Pass)
        Dim i As Integer = Convert.ToInt32(cmd.ExecuteScalar())
        cmd = Nothing
        con.Close()
        If i >= 1 Then

            Session("Ecode") = Ecode

            Response.Redirect("login_next.aspx")
        Else
            Dim conn As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
            conn.Open()
            Dim toffc As New SqlCommand("SELECT COUNT(*) FROM menu_your_password1 where empno=@Ecode and password=@Pass ", conn)
            toffc.Parameters.AddWithValue("@Ecode", Ecode)
            toffc.Parameters.AddWithValue("@Pass", Pass)
            Dim j As Integer = Convert.ToInt32(toffc.ExecuteScalar())
            toffc = Nothing
            conn.Close()
            If j >= 1 Then

                Session("Ecode") = Ecode
                Session("Group") = "Admin"
                Session("Apps") = "PP"
                'Response.Redirect("wapframesetpp.aspx")
                Dim url As String = "wapframesetpp.aspx"
                Dim s As String = "window.open('" & url + "', '_newtab');"
                ClientScript.RegisterStartupScript(Me.GetType(), "script", s, True)


            Else
                lblmessage.Visible = True
                lblmessage.Text = "invalid login"
            End If
        End If


    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

End Class