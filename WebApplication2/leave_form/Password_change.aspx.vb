Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports System.Data
Imports System.Net.Mail
Imports System.Net
Imports System
Imports System.Configuration
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Collections.Generic
Imports System.Linq
Imports System.IO

Public Class Password_change
    Inherits System.Web.UI.Page
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents lblname As System.Web.UI.WebControls.Label
    Protected WithEvents txtemployee_code As System.Web.UI.WebControls.TextBox
    Protected WithEvents cmdSave As System.Web.UI.WebControls.Button
    Protected WithEvents cmdReset As System.Web.UI.WebControls.Button
    Protected WithEvents txtcur_pswd As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtnew_pswd As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtconfirmnew_pswd As System.Web.UI.WebControls.TextBox
    Shared themeValue As String
    Dim fromdate As DateTime
    Public Sub New()

        AddHandler PreInit, New EventHandler(AddressOf Page_PreInit)
    End Sub

    Private Sub Page_PreInit(ByVal sender As Object, ByVal e As EventArgs)

        Page.Theme = themeValue
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblMessage.Text = ""
        'Dim ec As String = Session("Ecode")
        If Not IsPostBack Then
            txtemployee_code.Text = Session("Ecode")
            txtemployee_code.ReadOnly = True
            'txtemployee_code.Visible = False
        End If
    End Sub

    Protected Sub dd1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dd1.SelectedIndexChanged
        themeValue = Dd1.SelectedItem.Value
        Response.Redirect(Request.Url.ToString())
    End Sub
    Sub clearall()
        txtcur_pswd.Text = ""
        txtnew_pswd.Text = ""
        txtconfirmnew_pswd.Text = ""
    End Sub

    Protected Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Dim rdr As SqlDataReader
        Dim con As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
        con.Open()
        Dim s As String = "select empname,password from MENU_YOUR_PASSWORD1 where empno='" & Session("Ecode") & "'"
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, s)
        'lblname.Text = rdr.Item("employee_name")
        While rdr.Read
            If rdr.Item("password") = txtcur_pswd.Text Then
                If txtnew_pswd.Text = txtconfirmnew_pswd.Text Then
                    modify()
                End If
                If txtnew_pswd.Text <> txtconfirmnew_pswd.Text Then
                    lblMessage.Text = "Check the new password."
                End If
            End If
            If rdr.Item("password") <> txtcur_pswd.Text Then
                lblMessage.Text = "Current password is wrong."
            End If
        End While
        rdr.Close()
        con.Close()
    End Sub
    Sub modify()
        Dim con As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
        con.Open()
        Dim updatestr As String = "update MENU_YOUR_PASSWORD1 set password='" & txtnew_pswd.Text & "' where empno='" & Session("Ecode") & "'"
        SqlHelper.ExecuteNonQuery(con, CommandType.Text, updatestr)
        lblMessage.Text = "Password Updated."
        con.Close()
    End Sub

    Protected Sub txtEmployee_Code_TextChanged(sender As Object, e As EventArgs) Handles txtemployee_code.TextChanged
        Dim rdr As SqlDataReader
        Dim con As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
        con.Open()
        Dim s As String = "select empname from MENU_YOUR_PASSWORD1 where empno='" & Session("Ecode") & "'"
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, s)
        While rdr.Read
            lblname.Text = rdr.Item("empname")
        End While
    End Sub

    Protected Sub cmdReset_Click(sender As Object, e As EventArgs) Handles cmdReset.Click
        clearall()
    End Sub
End Class