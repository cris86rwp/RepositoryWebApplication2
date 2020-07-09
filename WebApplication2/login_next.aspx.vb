Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports Microsoft.ApplicationBlocks.Data

Public Class logon_next
    Inherits System.Web.UI.Page
    Protected WithEvents lblmessage As System.Web.UI.WebControls.Label
    Protected WithEvents lblapplication As System.Web.UI.WebControls.Label
    Protected WithEvents group As System.Web.UI.WebControls.Label
    Protected WithEvents empcode As System.Web.UI.WebControls.Label
    Protected WithEvents password As System.Web.UI.WebControls.Label
    Protected WithEvents txtempcode As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpassword As System.Web.UI.WebControls.TextBox
    'Public WithEvents ddapplication1 As System.Web.UI.WebControls.ListBox
    Public WithEvents ddgroup1 As System.Web.UI.WebControls.ListBox
    Protected WithEvents btnlogin As System.Web.UI.WebControls.Button
    Protected WithEvents Buttongrp As System.Web.UI.WebControls.Button
    Protected WithEvents back As System.Web.UI.WebControls.Button
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label



    Dim rdr As SqlDataReader
    Dim str As String
    'Dim str As String =  "111111"
    Dim App As String
    Dim Grp1 As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        str = Session("Ecode")

        If Not Me.IsPostBack Then

            Dim con As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
            con.Open()
            Dim cmd As New SqlCommand("SELECT employee_name FROM menu_your_password_new where employee_code=@ecode ", con)

            cmd.Parameters.AddWithValue("@ecode", str)

            Dim n As String = cmd.ExecuteScalar().ToString()
            Label1.Text = "Hello " + n.ToUpper()


            Dim str2 As String = "select distinct group_code from menu_your_password_new where employee_code='" & str & "'"
            rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str2)
            ddgroup1.DataValueField = "group_code"
            ddgroup1.DataTextField = "group_code"
            ddgroup1.DataSource = rdr
            ddgroup1.DataBind()
            rdr.Close()
            'ddgroup.Items.Insert(0, "")


            con.Close()
            ddgroup1.Height = 10 * (ddgroup1.Items.Count + 4)
            ddgroup1.Width = 200
        End If


    End Sub






    Public Sub btnlogin_Click(sender As Object, e As EventArgs) Handles btnlogin.Click

        ' Dim App As String = ddapplication1.SelectedItem.Text
        Dim Grp As String = ddgroup1.SelectedItem.Text


        Dim Ecode As String = str
        'Dim Pass As String = txtpassword.Text

        Dim con As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
        con.Open()
        Dim str3 As String = "select distinct application from menu_your_password_new where employee_code='" & str & "' And group_code ='" & Grp & "'"
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str3)
        While rdr.Read
            App = rdr("application")
            Exit While
        End While
        rdr.Close()
        Dim cmd As New SqlCommand("SELECT COUNT(*) FROM menu_your_password_new where application=@App and group_code=@Grp and employee_code=@Ecode  ", con)
        cmd.Parameters.AddWithValue("@App", App)
        cmd.Parameters.AddWithValue("@Grp", Grp)
        cmd.Parameters.AddWithValue("@Ecode", Ecode)
        'cmd.Parameters.AddWithValue("@Pass", str3)
        Dim i As Integer = Convert.ToInt32(cmd.ExecuteScalar())
        cmd = Nothing
        con.Close()


        If i >= 1 Then
            Session("Group") = Grp
            Session("Ecode") = Ecode
            Session("Apps") = App
            Dim url As String = "wapframeset.aspx"
            'Page.ClientScript.RegisterStartupScript(Me.GetType(), "OpenWindow", "window.open(wapframeset.aspx','_newtab');", True)
            'Dim s As String = "window.open('" & url + "', '_newtab', 'width=300,height=100,left=100,top=100,resizable=yes');"
            Dim s As String = "window.open('" & url + "', '_newtab');"
            ClientScript.RegisterStartupScript(Me.GetType(), "script", s, True)
            'Response.Redirect("wapframeset.aspx")
        Else
            lblmessage.Visible = True
            lblmessage.Text = "invalid login"
        End If


    End Sub

    Protected Sub back_Click(sender As Object, e As EventArgs) Handles back.Click
        Response.Redirect("logon.aspx")
    End Sub



End Class