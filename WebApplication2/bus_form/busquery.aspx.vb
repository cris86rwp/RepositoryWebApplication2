Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class busquery
    Inherits System.Web.UI.Page

    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lbl_msg As System.Web.UI.WebControls.Label
    Protected WithEvents dg_bus_details As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btn_show As System.Web.UI.WebControls.Button
    Public con As New SqlConnection(ConfigurationManager.AppSettings("con"))
    Dim strSql As String

    Shared themeValue As String

    Public Sub New()

        AddHandler PreInit, New EventHandler(AddressOf Page_PreInit)
    End Sub

    Private Sub Page_PreInit(ByVal sender As Object, ByVal e As EventArgs)

        Page.Theme = themeValue
    End Sub


    Protected Sub Dd1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        themeValue = Dd1.SelectedItem.Value
        Response.Redirect(Request.Url.ToString())

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub


    Private Sub BindDataGrid(ByVal strArg As String)

        Dim objCmd As SqlCommand
        Dim objDr As SqlDataReader

        If con.State = ConnectionState.Closed Then
            con.Open()
        Else
            con.Close()
            con.Open()
        End If
        Try
            objCmd = New SqlCommand(strArg, con)
            objDr = objCmd.ExecuteReader()
            Dim arr() As String
            dg_bus_details.DataSource = arr
            dg_bus_details.DataBind()
            dg_bus_details.DataSource = objDr
            dg_bus_details.DataBind()
        Catch exp As SqlException
            strSql = exp.StackTrace
            lbl_msg.Text = "Line : " & Mid(strSql, InStr(strSql, "line") + 5) & " Message : " + exp.Message

        Catch exp As Exception
            strSql = exp.StackTrace
            lbl_msg.Text = "Line : " & Mid(strSql, InStr(strSql, "line") + 5) & " Message : " + exp.Message
        End Try

        con.Close()

    End Sub

    'Private Sub dg_bus_details_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dg_bus_details.PageIndexChanged
    '    dg_bus_details.CurrentPageIndex = e.NewPageIndex
    '    Dim sqlstr3 As String
    '    sqlstr3 = "select employee_code,employee_name,bus_no,bus_route from emp_cum_by_bus"
    '    Call BindDataGrid(sqlstr3)
    'End Sub

    Protected Sub btn_show_Click(sender As Object, e As EventArgs) Handles btn_show.Click
        Try
            Dim sqlstr3 As String
            sqlstr3 = "select employee_code,employee_name,bus_no,bus_route from emp_cum_by_bus"
            Call BindDataGrid(sqlstr3)
        Catch ex As Exception
            lbl_msg.Text = ex.Message
        End Try
    End Sub
End Class