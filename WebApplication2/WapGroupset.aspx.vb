Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class WapGroupset
    Inherits System.Web.UI.Page
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lbl As System.Web.UI.WebControls.Label
    Protected WithEvents menuBar As System.Web.UI.WebControls.Menu
    Shared themeValue As String

    Public Sub New()

        AddHandler PreInit, New EventHandler(AddressOf Page_PreInit)
    End Sub

    Private Sub Page_PreInit(ByVal sender As Object, ByVal e As EventArgs)

        Page.Theme = themeValue
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            get_name()
            menu()
            ' get_menu()
            'Response.Write(Session("Ecode"))
        End If
    End Sub

    Protected Sub dd1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dd1.SelectedIndexChanged
        themeValue = Dd1.SelectedItem.Value
        Response.Redirect(Request.Url.ToString())

    End Sub
    Dim Group As String
    Public Sub get_name()
        Response.Write(Session("role"))
        Response.Write(Session("permission"))
        Dim ecode As Integer = Session("Ecode")
        Dim con As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
        con.Open()
        Dim cmd As New SqlCommand("SELECT distinct employee_name FROM menu_your_password_new where employee_code=@ecode", con)
        cmd.Parameters.AddWithValue("@ecode", ecode)
        Dim n As String = cmd.ExecuteScalar().ToString()
        lbl.Text = "HELLO " + n.ToUpper()
        con.Close()
    End Sub
    Public Sub menu()
        'Dim mi As MenuItem = menuBar.SelectedItem
        'If mi.Text = "PLANNING" Then
        '    Response.Write("Entered")
        'End If

    End Sub
    Public Sub get_menu()
        Dim rl As String = Session("role")
        Dim ecode As Integer = Session("Ecode")
        Dim pr As String = Session("permission")
        Dim table As DataTable = New DataTable()

        Dim conn As SqlConnection = New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
        conn.Open()
        Dim cmdd As SqlCommand = New SqlCommand("select m.menu_id, m.menu_name, m.menu_parent, m.menu_url from menu_master m full outer  join permission_menu p on m.menu_id = p.menu 
        where p.permission=@pr or m.menu_parent in( select m.menu_id from menu_master m 
		full outer  join permission_menu p on m.menu_id = p.menu
        where p.permission=@pr or m.menu_parent in( select m.menu_id 
        from menu_master m full outer  join permission_menu p on m.menu_id = p.menu
        where p.permission=@pr)or m.menu_parent in( select m.menu_id 
        from menu_master m full outer  join permission_menu p on m.menu_id = p.menu
        where p.permission=@pr or m.menu_parent in( select m.menu_id 
        from menu_master m full outer  join permission_menu p on m.menu_id = p.menu
        where p.permission=@pr)))", conn)
        cmdd.Parameters.AddWithValue("@pr", pr)
        Dim da As SqlDataAdapter = New SqlDataAdapter(cmdd)
        da.Fill(table)
        Dim view As DataView = New DataView(table)
        view.RowFilter = "menu_parent is NULL"

        For Each row As DataRowView In view
            Dim menuItem As MenuItem = New MenuItem(row("menu_name").ToString(), row("menu_id").ToString())
            menuItem.NavigateUrl = row("menu_url").ToString()
            menuBar.Items.Add(menuItem)
            AddChildItems(table, menuItem)

        Next

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

    Protected Sub menuBar_MenuItemClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MenuEventArgs) Handles menuBar.MenuItemClick
        Dim str As String
        If e.Item.Text = "PCOPCO" Then
            Group = "PCOPCO"
            str = check()
            If str = Group Then
                Session("Group") = "PCOPCO"
                Session("Apps") = "MMS"
                Response.Redirect("wapframeset.aspx")
            Else
                Response.Write("No access")
            End If
        End If
        If e.Item.Text = "PCOWTA" Then
            Group = "PCOWTA"
            str = check()
            If str = Group Then
                Session("Group") = "PCOWTA"
                Session("Apps") = "MMS"
                Response.Redirect("wapframeset.aspx")
            Else
                Response.Write("No access")
            End If
        End If
        If e.Item.Text = "SSEPCO" Then
            Group = "SSPCO"
            str = check()
            If str = Group Then
                Session("Group") = "SSPCO"
                Session("Apps") = "MMS"
                Response.Redirect("wapframeset.aspx")
            Else
                Response.Write("No access")
            End If
        End If
        If e.Item.Text = "MELTING" Then
            Group = "WHLMLT"
            str = check()
            If str = Group Then
                Session("Group") = "WHLMLT"
                Session("Apps") = "MMS"
                Response.Redirect("wapframeset.aspx")
            Else
                Response.Write("No access")
            End If
        End If
        If e.Item.Text = "MELT SUBSTORE" Then
            Group = "SSEMELT"
            str = check()
            If str = Group Then
                Session("Group") = "SSMELT"
                Session("Apps") = "MSS"
                Response.Redirect("wapframeset.aspx")
            Else
                Response.Write("No access")
            End If
        End If
        If e.Item.Text = "SSEMELT" Then
            Group = "SSEMELT"
            str = check()
            If str = Group Then
                Session("Group") = "SSEMELT"
                Session("Apps") = "MSS"
                Response.Redirect("wapframeset.aspx")
            Else
                Response.Write("No access")
            End If
        End If
        If e.Item.Text = "MOULDING" Then
            Group = "MLDING"
            str = check()
            If str = Group Then
                Session("Group") = "MLDING"
                Session("Apps") = "MMS"
                Response.Redirect("wapframeset.aspx")
            Else
                Response.Write("No access")
            End If
        End If
        If e.Item.Text = "MOULD INCHARGE" Then
            Group = "SSEMLD"
            str = check()
            If str = Group Then
                Session("Group") = "SSEMLD"
                Session("Apps") = "MMS"
                Response.Redirect("wapframeset.aspx")
            Else
                Response.Write("No access")
            End If
        End If
        If e.Item.Text = "MOULD SUBSTORE" Then
            Group = "SSMOLD"
            str = check()
            If str = Group Then
                Session("Group") = "SSMOLD"
                Session("Apps") = "MSS"
                Response.Redirect("wapframeset.aspx")
            Else
                Response.Write("No access")
            End If
        End If
        If e.Item.Text = "SAND AND HWL" Then
            Group = "HWLSAND"
            str = check()
            If str = Group Then
                Session("Group") = "HWLSAND"
                Session("Apps") = "MMS"
                Response.Redirect("wapframeset.aspx")
            Else
                Response.Write("No access")
            End If
        End If
        If e.Item.Text = "MPO AND SPRAY" Then
            Group = "MLDMPO"
            str = check()
            If str = Group Then
                Session("Group") = "MLDMPO"
                Session("Apps") = "MMS"
                Response.Redirect("wapframeset.aspx")
            Else
                Response.Write("No access")
            End If
        End If
        If e.Item.Text = "POURING" Then
            Group = "MLDPOUR"
            str = check()
            If str = Group Then
                Session("Group") = "MLDPOUR"
                Session("Apps") = "MMS"
                Response.Redirect("wapframeset.aspx")
            Else
                Response.Write("No access")
            End If
        End If
        If e.Item.Text = "WFPS INCHARGE" Then
            Group = "AWNCLR"
            str = check()
            If str = Group Then
                Session("Group") = "AWNCLR"
                Session("Apps") = "MMS"
                Response.Redirect("wapframeset.aspx")
            Else
                Response.Write("No access")
            End If
        End If
        If e.Item.Text = "WHEEL PROCESS" Then
            Group = "MLDNFDF"
            str = check()
            If str = Group Then
                Session("Group") = "MLDNFDF"
                Session("Apps") = "MMS"
                Response.Redirect("wapframeset.aspx")
            Else
                Response.Write("No access")
            End If
        End If
        If e.Item.Text = "WFPS SUBSTORE" Then
            Group = "WFPSUB"
            str = check()
            If str = Group Then
                Session("Group") = "WFPSUB"
                Session("Apps") = "MMS"
                Response.Redirect("wapframeset.aspx")
            Else
                Response.Write("No access")
            End If
        End If
        If e.Item.Text = "WHEEL INSPECTION" Then
            Group = "CLRINS"
            str = check()
            If str = Group Then
                Session("Group") = "CLRINS"
                Session("Apps") = "MMS"
                Response.Redirect("wapframeset.aspx")
            Else
                Response.Write("No access")
            End If
        End If
        If e.Item.Text = "YARD" Then
            Group = "WHLYARD"
            str = check()
            If str = Group Then
                Session("Group") = "WHLYARD"
                Session("Apps") = "MMS"
                Response.Redirect("wapframeset.aspx")
            Else
                Response.Write("No access")
            End If
        End If
        If e.Item.Text = "DESPATCH" Then
            Group = "WHLDES"
            str = check()
            If str = Group Then
                Session("Group") = "WHLDES"
                Session("Apps") = "MMS"
                Response.Redirect("wapframeset.aspx")
            Else
                Response.Write("No access")
            End If
        End If
        If e.Item.Text = "MOULD REPAIR PROCESS" Then
            Group = "MRSMRS"
            str = check()
            If str = Group Then
                Session("Group") = "MRSMRS"
                Session("Apps") = "MMS"
                Response.Redirect("wapframeset.aspx")
            Else
                Response.Write("No access")
            End If
        End If
        If e.Item.Text = "MRS INCHARGE" Then
            Group = "SSEMRS"
            str = check()
            If str = Group Then
                Session("Group") = "SSEMRS"
                Session("Apps") = "MMS"
                Response.Redirect("wapframeset.aspx")
            Else
                Response.Write("No access")
            End If
        End If
        If e.Item.Text = "MECHANICAL MELT" Then
            Group = "MW1"
            str = check()
            If str = Group Then
                Session("Group") = "MW1"
                Session("Apps") = "MSS"
                Response.Redirect("wapframeset.aspx")
            Else
                Response.Write("No access")
            End If
        End If
        If e.Item.Text = "MOULD AND MRS" Then
            Group = "MW2"
            str = check()
            If str = Group Then
                Session("Group") = "MW2"
                Session("Apps") = "MSS"
                Response.Redirect("wapframeset.aspx")
            Else
                Response.Write("No access")
            End If
        End If
        If e.Item.Text = "WFPS" Then
            Group = "MW3"
            str = check()
            If str = Group Then
                Session("Group") = "MW3"
                Session("Apps") = "MSS"
                Response.Redirect("wapframeset.aspx")
            Else
                Response.Write("No access")
            End If
        End If
        If e.Item.Text = "ELECTRICAL MELT" Then
            Group = "EW1"
            str = check()
            If str = Group Then
                Session("Group") = "EW1"
                Session("Apps") = "MSS"
                Response.Redirect("wapframeset.aspx")
            Else
                Response.Write("No access")
            End If
        End If
        If e.Item.Text = "MOULDS" Then
            Group = "EW2"
            str = check()
            If str = Group Then
                Session("Group") = "EW2"
                Session("Apps") = "MSS"
                Response.Redirect("wapframeset.aspx")
            Else
                Response.Write("No access")
            End If
        End If
        If e.Item.Text = "WFPS AND MRS" Then
            Group = "EW3"
            str = check()
            If str = Group Then
                Session("Group") = "EW3"
                Session("Apps") = "MSS"
                Response.Redirect("wapframeset.aspx")
            Else
                Response.Write("No access")
            End If
        End If
        If e.Item.Text = "TOOL ROOM" Then
            Group = "TOOLS"
            str = check()
            If str = Group Then
                Session("Group") = "TOOLS"
                Session("Apps") = "MSS"
                Response.Redirect("wapframeset.aspx")
            Else
                Response.Write("No access")
            End If
        End If
        If e.Item.Text = "UTILITY" Then
            Group = "UTILIT"
            str = check()
            If str = Group Then
                Session("Group") = "UTLIT"
                Session("Apps") = "MSS"
                Response.Redirect("wapframeset.aspx")
            Else
                Response.Write("No access")
            End If
        End If
        If e.Item.Text = "ROAD TRANSPORT" Then
            Group = "RTSHOP"
            str = check()
            If str = Group Then
                Session("Group") = "RTSHOP"
                Session("Apps") = "MSS"
                Response.Redirect("wapframeset.aspx")
            Else
                Response.Write("No access")
            End If
        End If
        If e.Item.Text = "ELECTRICAL POWER" Then
            Group = "ELECTRI"
            str = check()
            If str = Group Then
                Session("Group") = "ELECTRI"
                Session("Apps") = "MSS"
                Response.Redirect("wapframeset.aspx")
            Else
                Response.Write("No access")
            End If
        End If
        If e.Item.Text = "MAGNA" Then
            Group = "CLRMAG"
            str = check()
            If str = Group Then
                Session("Group") = "CLRMAG"
                Session("Apps") = "MMS"
                Response.Redirect("wapframeset.aspx")
            Else
                Response.Write("No access")
            End If
        End If
        If e.Item.Text = "SPECTRO" Then
            Group = "SPECTRO"
            str = check()
            If str = Group Then
                Session("Group") = "SPECTRO"
                Session("Apps") = "MSS"
                Response.Redirect("wapframeset.aspx")
            Else
                Response.Write("No access")
            End If
        End If
        If e.Item.Text = "CHEMICAL" Then
            Group = "CHEM"
            str = check()
            If str = Group Then
                Session("Group") = "CHEM"
                Session("Apps") = "MSS"
                Response.Redirect("wapframeset.aspx")
            Else
                Response.Write("No access")
            End If
        End If
        If e.Item.Text = "PHYSICAL" Then
            Group = "PHY"
            str = check()
            If str = Group Then
                Session("Group") = "PHY"
                Session("Apps") = "MSS"
                Response.Redirect("wapframeset.aspx")
            Else
                Response.Write("No access")
            End If
        End If
        If e.Item.Text = "CMT" Then
            Group = "CMTWHL"
            str = check()
            If str = Group Then
                Session("Group") = "CMTWHL"
                Session("Apps") = "MMS"
                Response.Redirect("wapframeset.aspx")
            Else
                Response.Write("No access")
            End If
        End If
        If e.Item.Text = "WHEEL QCI" Then
            Group = "WHLQCI"
            str = check()
            If str = Group Then
                Session("Group") = "WHLQCI"
                Session("Apps") = "MMS"
                Response.Redirect("wapframeset.aspx")
            Else
                Response.Write("No access")
            End If
        End If
    End Sub
    Public Function check()
        Dim rdr As SqlDataReader
        Dim grp As String
        Dim conn As SqlConnection = New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
        Dim s As String = "Select group_code from menu_your_password_new where employee_code='" & Session("Ecode") & "'"
        conn.Open()
        rdr = SqlHelper.ExecuteReader(conn, CommandType.Text, s)
        While rdr.Read
            grp = rdr.Item("group_code")
            If grp = Group Then
                Exit While
            End If
        End While
        Return grp
    End Function
End Class