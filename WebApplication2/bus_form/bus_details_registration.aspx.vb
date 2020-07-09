Imports System.Data
Imports System.Data.SqlClient
Imports System.DateTime
Imports Microsoft.ApplicationBlocks.Data
Public Class bus_details_registration
    Inherits System.Web.UI.Page


    Protected WithEvents lbl_msg As System.Web.UI.WebControls.Label
    Protected WithEvents lbl_bus_code As System.Web.UI.WebControls.Label
    Protected WithEvents lbl_bus_route As System.Web.UI.WebControls.Label
    Protected WithEvents lbl_date As System.Web.UI.WebControls.Label
    Protected WithEvents lbl_shift As System.Web.UI.WebControls.Label

    Protected WithEvents lbl_schdul_arr As System.Web.UI.WebControls.Label
    Protected WithEvents lbl_schdul_dept As System.Web.UI.WebControls.Label
    Protected WithEvents lbl_bus_status As System.Web.UI.WebControls.Label
    Protected WithEvents txt_bus_code As System.Web.UI.WebControls.TextBox
    Protected WithEvents txt_bus_route As System.Web.UI.WebControls.TextBox
    Protected WithEvents txt_date As System.Web.UI.WebControls.TextBox
    Protected WithEvents txt_schdul_arr As System.Web.UI.WebControls.TextBox
    Protected WithEvents txt_schdul_dept As System.Web.UI.WebControls.TextBox
    Protected WithEvents rbl_shift As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rbl_bus_status As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents btn_save As System.Web.UI.WebControls.Button
    Protected WithEvents btn_update As System.Web.UI.WebControls.Button
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList
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

        If Page.IsPostBack = False Then
            txt_date.Text = Date.Today.ToString("MM/dd/yyyy")
        End If

    End Sub

    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        If btn_save.Text = "Save" Then
            Try
                con.Open()

                Dim sqlPara(6) As SqlParameter

                sqlPara(0) = New SqlParameter("@txt_date", Format(CDate(txt_date.Text), "MM/dd/yyyy"))
                sqlPara(1) = New SqlParameter("@Shift", Trim(rbl_shift.SelectedItem.Text))
                sqlPara(2) = New SqlParameter("@txt_bus_code", Trim(txt_bus_code.Text))
                sqlPara(3) = New SqlParameter("@txt_bus_route", Trim(txt_bus_route.Text))
                sqlPara(4) = New SqlParameter("@rbl_bus_status", Trim(rbl_bus_status.SelectedItem.Text))
                sqlPara(5) = New SqlParameter("@txt_schdul_arr", Convert.ToDateTime(txt_schdul_arr.Text))
                sqlPara(6) = New SqlParameter("@txt_schdul_dept", Convert.ToDateTime(txt_schdul_dept.Text))



                Dim sqlstr As String = "insert into bus_details_registration(bus_no,bus_route,date,scheduled_arrival,shift,scheduled_departure,bus_status) values(@txt_bus_code,@txt_bus_route,@txt_date,@txt_schdul_arr,@Shift,@txt_schdul_dept,@rbl_bus_status)"

                Try
                    Dim i As Integer = SqlHelper.ExecuteNonQuery(con, CommandType.Text, sqlstr, sqlPara)
                    lbl_msg.Text = "Bus Details Saved...."

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
                lbl_msg.Text = "please select shift.."
            End Try
        Else
            If btn_save.Text = "Update" Then
                Try
                    lbl_msg.Text = ""
                    Dim sqlPara(6) As SqlParameter

                    sqlPara(0) = New SqlParameter("@txt_date", Format(CDate(txt_date.Text), "MM/dd/yyyy"))
                    sqlPara(1) = New SqlParameter("@Shift", Trim(rbl_shift.SelectedItem.Text))
                    sqlPara(2) = New SqlParameter("@txt_bus_code", Trim(txt_bus_code.Text))
                    sqlPara(3) = New SqlParameter("@txt_bus_route", Trim(txt_bus_route.Text))
                    sqlPara(4) = New SqlParameter("@rbl_bus_status", Trim(rbl_bus_status.SelectedItem.Text))
                    sqlPara(5) = New SqlParameter("@txt_schdul_arr", Convert.ToDateTime(txt_schdul_arr.Text))
                    sqlPara(6) = New SqlParameter("@txt_schdul_dept", Convert.ToDateTime(txt_schdul_dept.Text))



                    Try
                        strSql = "update bus_details_registration set bus_no=@txt_bus_code,bus_route=@txt_bus_route,scheduled_arrival=@txt_schdul_arr,shift=@Shift,scheduled_departure=@txt_schdul_dept,bus_status=@rbl_bus_status where date='" & Format(CDate(txt_date.Text), "MM/dd/yyyy") & "' and shift='" & rbl_shift.SelectedItem.Text & "'"


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
                    lbl_msg.Text = "Invalid entry..."
                End Try
            End If

        End If
    End Sub
End Class