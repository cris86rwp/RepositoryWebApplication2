Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class wapframesetpp
    Inherits System.Web.UI.Page
    Protected WithEvents lbl As System.Web.UI.WebControls.Label
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList


    Shared themeValue As String

    Public Sub New()

        AddHandler PreInit, New EventHandler(AddressOf Page_PreInit)
    End Sub

    Private Sub Page_PreInit(ByVal sender As Object, ByVal e As EventArgs)

        Page.Theme = themeValue
    End Sub


    Protected Sub dd1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        themeValue = Dd1.SelectedItem.Value
        Response.Redirect(Request.Url.ToString())

    End Sub





    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Session("Theme") = themeValue
            get_menu()
            get_name()
            get_logintime()
        End If


    End Sub

    Public Sub get_menu()
        'Session("Group") = "WHLMLT"
        'Session("Ecode") = "013901"
        'Session("Apps") = "MMS"
        'Session("Group") = "ADMIN"
        'Session("Ecode") = "01698"
        'Session("Apps") = "MMS"
        'Session("Group") = "MLDING"
        'Session("Ecode") = "013902"
        'Session("Apps") = "MMS"
        'Session("Group") = "MRSMRS"
        'Session("Ecode") = "013903"
        'Session("Apps") = "MMS"
        Dim grp As String = Session("Group")
        Dim ecode As String = Session("Ecode")
        Dim app As String = Session("Apps")
        Dim table As DataTable = New DataTable()

        Dim conn As SqlConnection = New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User ID=sa;Password=sadev123")
        conn.Open()
        If app <> "PP" Then
            Dim cmdd As SqlCommand = New SqlCommand("select m.menu_id, m.menu_name, m.menu_parent, m.menu_url from menu_master m full outer  join permission_menu p on m.menu_id = p.menu 
        where p.permission IN (select permission from role_permission where role_id in(select role_id from menu_your_password_new
        where group_code=@grp  and application=@app and employee_code=@ecode)) or m.menu_parent in( select m.menu_id from menu_master m full outer  join permission_menu p on m.menu_id = p.menu
        where p.permission in (select permission from role_permission where role_id in(select role_id from menu_your_password_new
        where group_code=@grp  and application=@app and employee_code=@ecode))or m.menu_parent in( select m.menu_id 
        from menu_master m full outer  join permission_menu p on m.menu_id = p.menu
        where p.permission in (select permission from role_permission where role_id in(select role_id from menu_your_password_new
        where group_code=@grp  and application=@app and employee_code=@ecode)))or m.menu_parent in( select m.menu_id 
        from menu_master m full outer  join permission_menu p on m.menu_id = p.menu
        where p.permission in (select permission from role_permission where role_id in(select role_id from menu_your_password_new
        where group_code=@grp  and application=@app and employee_code=@ecode))or m.menu_parent in( select m.menu_id 
        from menu_master m full outer  join permission_menu p on m.menu_id = p.menu
        where p.permission in (select permission from role_permission where role_id in(select role_id from menu_your_password_new
        where group_code=@grp  and application=@app and employee_code=@ecode)))))", conn)
            cmdd.Parameters.AddWithValue("@grp", grp)
            cmdd.Parameters.AddWithValue("@ecode", ecode)
            cmdd.Parameters.AddWithValue("@app", app)
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmdd)
            da.Fill(table)
            Dim view As DataView = New DataView(table)
            view.RowFilter = "menu_parent is NULL"

            For Each row As DataRowView In view
                Dim menuItem As MenuItem = New MenuItem(row("menu_name").ToString(), row("menu_id").ToString())
                menuItem.NavigateUrl = row("menu_url").ToString()
                menuBar1.Items.Add(menuItem)
                AddChildItems(table, menuItem)

            Next
        End If
        If app.Equals("PP") Then
            Dim cmdd As SqlCommand = New SqlCommand("select m.menu_id, m.menu_name, m.menu_parent, m.menu_url from menu_master m full outer  join permission_menu p on m.menu_id = p.menu 
        where p.permission IN (select permission from role_permission where role_id in(select role_id from emp1
        where empno=@ecode)) or m.menu_parent in( select m.menu_id from menu_master m full outer  join permission_menu p on m.menu_id = p.menu
        where p.permission in (select permission from role_permission where role_id in(select role_id from emp1
        where empno=@ecode))or m.menu_parent in( select m.menu_id 
        from menu_master m full outer  join permission_menu p on m.menu_id = p.menu
        where p.permission in (select permission from role_permission where role_id in(select role_id from emp1
        where empno=@ecode)))or m.menu_parent in( select m.menu_id 
        from menu_master m full outer  join permission_menu p on m.menu_id = p.menu
        where p.permission in (select permission from role_permission where role_id in(select role_id from emp1
        where empno=@ecode))or m.menu_parent in( select m.menu_id 
        from menu_master m full outer  join permission_menu p on m.menu_id = p.menu
        where p.permission in (select permission from role_permission where role_id in(select role_id from emp1
        where empno=@ecode)))))", conn)
            cmdd.Parameters.AddWithValue("@grp", grp)
            cmdd.Parameters.AddWithValue("@ecode", ecode)
            cmdd.Parameters.AddWithValue("@app", app)
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmdd)
            da.Fill(table)
            Dim view As DataView = New DataView(table)
            view.RowFilter = "menu_parent is NULL"

            For Each row As DataRowView In view
                Dim menuItem As MenuItem = New MenuItem(row("menu_name").ToString(), row("menu_id").ToString())
                menuItem.NavigateUrl = row("menu_url").ToString()
                menuBar1.Items.Add(menuItem)
                AddChildItems(table, menuItem)

            Next
        End If
        'Dim menuIteml As MenuItem = New MenuItem("LOGOUT")
        'menuIteml.NavigateUrl = "~/logon.aspx"
        ''menuIteml.SeparatorImageUrl = get_logouttime()

        'menuBar.Items.Add(menuIteml)


    End Sub
    Private Sub AddChildItems(ByVal table As DataTable, ByVal menuItem As MenuItem)
        Dim viewItem As DataView = New DataView(table)
        viewItem.RowFilter = "menu_parent =  " & menuItem.Value

        For Each childView As DataRowView In viewItem
            Dim childItem As MenuItem = New MenuItem(childView("menu_name").ToString(), childView("menu_id").ToString())
            childItem.NavigateUrl = childView("menu_url").ToString()
            menuItem.ChildItems.Add(childItem)
            AddChildItems(table, childItem)
        Next
    End Sub
    Public Sub get_name()
        Dim grp As String = Session("Group")
        Dim ecode As String = Session("Ecode")
        Dim app As String = Session("Apps")
        If app <> "PP" Then
            Dim con As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User ID=sa;Password=sadev123")
            con.Open()
            Dim cmd As New SqlCommand("SELECT employee_name FROM menu_your_password_new where group_code=@grp and employee_code=@ecode and application=@app ", con)
            cmd.Parameters.AddWithValue("@grp", grp)
            cmd.Parameters.AddWithValue("@ecode", ecode)
            cmd.Parameters.AddWithValue("@app", app)
            Dim n As String = cmd.ExecuteScalar().ToString()
            lbl.Text = "HELLO " + n.ToUpper()
        End If
        If app = "PP" Then
            Dim conn As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User ID=sa;Password=sadev123")
            conn.Open()
            Dim cmd1 As New SqlCommand("SELECT empname FROM menu_your_password1 where empno=@ecode ", conn)
            '  cmd.Parameters.AddWithValue("@grp", grp)
            cmd1.Parameters.AddWithValue("@ecode", ecode)
            ' cmd.Parameters.AddWithValue("@app", app)
            Dim n1 As String = cmd1.ExecuteScalar().ToString()
            lbl.Text = "HELLO " + n1.ToUpper()
        End If
    End Sub
    Public Sub get_logintime()
        Dim grp As String = Session("Group")
        Dim ecode As String = Session("Ecode")
        Dim app As String = Session("Apps")
        Dim lt As DateTime = Convert.ToDateTime(Date.Now())
        Dim con As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User ID=sa;Password=sadev123")
        con.Open()
        Dim cmd As New SqlCommand("Update menu_your_password_new set last_login_time=@lt where group_code=@grp and employee_code=@ecode and application=@app ", con)
        cmd.Parameters.AddWithValue("@grp", grp)
        cmd.Parameters.AddWithValue("@ecode", ecode)
        cmd.Parameters.AddWithValue("@app", app)
        cmd.Parameters.AddWithValue("@lt", lt)
        cmd.ExecuteNonQuery()
    End Sub
    Public Sub get_logouttime()
        Dim grp As String = Session("Group")
        Dim ecode As String = Session("Ecode")
        Dim app As String = Session("Apps")
        Dim lt As DateTime = Convert.ToDateTime(Date.Now())
        Dim con As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User ID=sa;Password=sadev123")
        con.Open()
        Dim cmd As New SqlCommand("Update menu_your_password_new set last_logout_time=@lt where group_code=@grp and employee_code=@ecode and application=@app ", con)
        cmd.Parameters.AddWithValue("@grp", grp)
        cmd.Parameters.AddWithValue("@ecode", ecode)
        cmd.Parameters.AddWithValue("@app", app)
        cmd.Parameters.AddWithValue("@lt", lt)
        cmd.ExecuteNonQuery()
        'Session.Abandon()
        'Session.Clear()
    End Sub

End Class
