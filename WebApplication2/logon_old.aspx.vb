Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports Microsoft.ApplicationBlocks.Data

Public Class logon_old
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

    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    '    'Session.Abandon()
    '    'Session.Clear()
    'End Sub

    Protected Sub Buttongrp_Click() Handles Buttongrp.Click
        'If Not IsPostBack Then
        Dim con As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")


        con.Open()
        Dim str1 As String = "select distinct application from menu_your_password_new where employee_code='" & Trim(txtempcode.Text) & "'"
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str1)



        ddapplication.DataValueField = "application"
        ddapplication.DataTextField = "application"
        ddapplication.DataSource = rdr
        ddapplication.DataBind()
        rdr.Close()
        ddapplication.Items.Insert(0, "")

        Dim str2 As String = "select distinct group_code from menu_your_password_new where employee_code='" & Trim(txtempcode.Text) & "'"
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str2)
        ddgroup.DataValueField = "group_code"
        ddgroup.DataTextField = "group_code"
        ddgroup.DataSource = rdr
        ddgroup.DataBind()
        rdr.Close()
        ddgroup.Items.Insert(0, "")


        con.Close()

        'End If

    End Sub
    Protected Sub btnlogin_Click(sender As Object, e As EventArgs) Handles btnlogin.Click

        Dim App As String = ddapplication.SelectedItem.Value
        Dim Grp As String = ddgroup.SelectedItem.Value
        Dim Ecode As String = txtempcode.Text
        Dim Pass As String = txtpassword.Text

        Dim con As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
        con.Open()
        Dim cmd As New SqlCommand("SELECT COUNT(*) FROM menu_your_password_new where application=@App and group_code=@Grp and employee_code=@Ecode and password=@Pass ", con)
        cmd.Parameters.AddWithValue("@App", App)
        cmd.Parameters.AddWithValue("@Grp", Grp)
        cmd.Parameters.AddWithValue("@Ecode", Ecode)
        cmd.Parameters.AddWithValue("@Pass", Pass)
        Dim i As Integer = Convert.ToInt32(cmd.ExecuteScalar())
        cmd = Nothing
        con.Close()
        If i >= 1 Then
            Session("Group") = Grp
            Session("Ecode") = Ecode
            Session("Apps") = App
            Response.Redirect("wapframeset.aspx")
        Else
            lblmessage.Visible = True
            lblmessage.Text = "invalid login"
        End If


    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub
    'Public Function check()
    '    Dim App As String = ddapplication.SelectedItem.Value
    '    Dim Grp As String = ddgroup.SelectedItem.Value
    '    Dim Ecode As String = txtempcode.Text
    '    Dim Pass As String = txtpassword.Text

    '    Dim con As New SqlConnection("Data Source=RWFSERVER;Initial Catalog=mis;User Id=sa;Password=sadev123")
    '    con.Open()
    '    Dim cmd As New SqlCommand("SELECT COUNT(*) FROM menu_your_password_new where application=@App and group_code=@Grp and employee_code=@Ecode and password=@Pass ", con)
    '    cmd.Parameters.AddWithValue("@App", App)
    '    cmd.Parameters.AddWithValue("@Grp", Grp)
    '    cmd.Parameters.AddWithValue("@Ecode", Ecode)
    '    cmd.Parameters.AddWithValue("@Pass", Pass)
    '    Dim i As Integer = Convert.ToInt32(cmd.ExecuteScalar())
    '    cmd = Nothing
    '    con.Close()
    '    lblmessage.Text = i
    '    Return i
    'End Function

End Class