Imports System.Data
Imports System.Data.SqlClient
Imports System.DateTime
Imports Microsoft.ApplicationBlocks.Data
Public Class employeeCumByBus
    Inherits System.Web.UI.Page


    Protected WithEvents lbl_msg As System.Web.UI.WebControls.Label
    Protected WithEvents lbl_bus_no As System.Web.UI.WebControls.Label
    Protected WithEvents lbl_bus_route As System.Web.UI.WebControls.Label
    Protected WithEvents lbl_ticketno As System.Web.UI.WebControls.Label
    Protected WithEvents lbl_emp_name As System.Web.UI.WebControls.Label
    Protected WithEvents txt_bus_no As System.Web.UI.WebControls.TextBox
    Protected WithEvents txt_bus_route As System.Web.UI.WebControls.TextBox
    Protected WithEvents txt_emp_id As System.Web.UI.WebControls.TextBox
    Protected WithEvents txt_emp_name As System.Web.UI.WebControls.TextBox
    Protected WithEvents btn_save As System.Web.UI.WebControls.Button
    Protected WithEvents ddl_bus_no As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddl_bus_route As System.Web.UI.WebControls.DropDownList
    Public con As New SqlConnection(ConfigurationManager.AppSettings("con"))
    Dim strSql As String
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList

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
        'Getbusno()

        If Page.IsPostBack = False Then
            Getbusno()
            Getroute()
        End If
    End Sub

    Public Function Getroute()

        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            cmd.Connection.Open()
            Dim no As String = ddl_bus_no.SelectedItem.Text
            cmd.CommandText = "Select distinct(bus_route) from bus_details_registration where bus_no =@no"
            cmd.Parameters.AddWithValue("@no", no)
            ddl_bus_route.DataSource = cmd.ExecuteReader()
            ddl_bus_route.DataTextField = "bus_route"
            ddl_bus_route.DataBind()

        Catch exp As Exception
            lbl_msg.Text = exp.Message
        End Try

    End Function

    Public Function Getbusno()

        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            cmd.Connection.Open()
            cmd.CommandText = "Select distinct(bus_no) from bus_details_registration"
            ddl_bus_no.DataSource = cmd.ExecuteReader()
            ddl_bus_no.DataTextField = "bus_no"
            ddl_bus_no.DataBind()

        Catch exp As Exception
            lbl_msg.Text = exp.Message
        End Try

    End Function

    Protected Sub txt_emp_id_TextChanged(sender As Object, e As EventArgs) Handles txt_emp_id.TextChanged

        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            cmd.Connection.Open()
            Dim time_in2 As String
            ' Dim time_in1 As DateTime
            Dim sqlstr As String = "Select employee_name from hr_employee_master where employee_code ='" & txt_emp_id.Text & "'"
            Dim dr As SqlDataReader
            dr = SqlHelper.ExecuteReader(ConfigurationManager.AppSettings("con"), CommandType.Text, sqlstr)
            While dr.Read
                txt_emp_name.Text = dr.Item("employee_name")

            End While
        Catch ee As Exception
            lbl_msg.Text = "Please Enter Invalid Employee Id !!"
        End Try
    End Sub

    Protected Sub ddl_bus_no_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_bus_no.SelectedIndexChanged
        Getroute()
    End Sub

    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        If btn_save.Text = "Save" Then
            Try
                con.Open()

                Dim sqlPara(3) As SqlParameter

                sqlPara(0) = New SqlParameter("@txt_emp_id", Trim(txt_emp_id.Text))
                sqlPara(1) = New SqlParameter("@txt_emp_name", Trim(txt_emp_name.Text))
                sqlPara(2) = New SqlParameter("@txt_bus_no", Trim(ddl_bus_no.SelectedItem.Text))
                sqlPara(3) = New SqlParameter("@txt_bus_route", Trim(ddl_bus_route.SelectedItem.Text))


                Dim sqlstr As String = "insert into emp_cum_by_bus(employee_code,employee_name,bus_no,bus_route) values(@txt_emp_id,@txt_emp_name,@txt_bus_no,@txt_bus_route)"

                Try
                    Dim i As Integer = SqlHelper.ExecuteNonQuery(con, CommandType.Text, sqlstr, sqlPara)
                    lbl_msg.Text = "Data saved..."
                Catch exp As SqlException
                    If exp.Number = 2627 Then
                        lbl_msg.Text = "This Record Already exists"
                        btn_save.Text = "Update"
                    Else

                        strSql = exp.StackTrace
                        lbl_msg.Text = "Line : " & Mid(strSql, InStr(strSql, "line") + 5) & " Message : " + exp.Message
                    End If
                Catch exp As Exception
                    strSql = exp.StackTrace
                    lbl_msg.Text = "Line : " & Mid(strSql, InStr(strSql, "line") + 5) & " Message : " + exp.Message
                End Try
                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If
            Catch ee As Exception
                lbl_msg.Text = "please fill employee id.."
            End Try
        Else

            If btn_save.Text = "Update" Then
                Try

                    Dim sqlPara(3) As SqlParameter

                    sqlPara(0) = New SqlParameter("@txt_emp_id", Trim(txt_emp_id.Text))
                    sqlPara(1) = New SqlParameter("@txt_emp_name", Trim(txt_emp_name.Text))
                    sqlPara(2) = New SqlParameter("@txt_bus_no", Trim(ddl_bus_no.SelectedItem.Text))
                    sqlPara(3) = New SqlParameter("@txt_bus_route", Trim(ddl_bus_route.SelectedItem.Text))

                    Try
                        strSql = "update emp_cum_by_bus set employee_name=@txt_emp_name,bus_no=@txt_bus_no,bus_route=@txt_bus_route where employee_code='" & txt_emp_id.Text & "' "


                        SqlHelper.ExecuteNonQuery(con, CommandType.Text, strSql, sqlPara)
                        lbl_msg.Text = "Updated Sucessfully"
                        btn_save.Text = "Save"
                        '  Call clearform()


                    Catch exp As SqlException
                        strSql = exp.StackTrace
                        lbl_msg.Text = "Line : " & Mid(strSql, InStr(strSql, "line") + 5) & " Message : " + exp.Message

                    Catch exp As Exception
                        strSql = exp.StackTrace
                        lbl_msg.Text = "Line : " & Mid(strSql, InStr(strSql, "line") + 5) & " Message : " + exp.Message
                    End Try

                Catch ee As Exception
                    lbl_msg.Text = "please fill employee id.."
                End Try
            End If
        End If
    End Sub
End Class