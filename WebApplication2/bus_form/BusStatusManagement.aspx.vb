Imports System.Data
Imports System.Data.SqlClient
Imports System.DateTime
Imports Microsoft.ApplicationBlocks.Data
Public Class BusStatusManagement
    Inherits System.Web.UI.Page


    Protected WithEvents lbl_msg As System.Web.UI.WebControls.Label
    Protected WithEvents lbl_bus_no As System.Web.UI.WebControls.Label
    Protected WithEvents lbl_bus_route As System.Web.UI.WebControls.Label
    Protected WithEvents lbl_shift As System.Web.UI.WebControls.Label
    Protected WithEvents lbl_arr_dept_time As System.Web.UI.WebControls.Label
    Protected WithEvents lbl_time As System.Web.UI.WebControls.Label
    Protected WithEvents txt_bus_no As System.Web.UI.WebControls.TextBox
    Protected WithEvents txt_bus_route As System.Web.UI.WebControls.TextBox
    Protected WithEvents txt_time As System.Web.UI.WebControls.TextBox
    Protected WithEvents txt_arr_dept_time As System.Web.UI.WebControls.TextBox
    Protected WithEvents rbl_shift As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rbl_in_out As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents btn_Save As System.Web.UI.WebControls.Button
    Protected WithEvents dd1_route As System.Web.UI.WebControls.DropDownList
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

        End If
        '   getDateShift()
    End Sub

    Public Function Getroute()

        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            cmd.Connection.Open()
            Dim no As String = txt_bus_no.Text
            cmd.CommandText = "Select distinct(bus_route) from bus_details_registration where bus_no =@no"
            cmd.Parameters.AddWithValue("@no", no)
            dd1_route.DataSource = cmd.ExecuteReader()
            dd1_route.DataTextField = "bus_route"
            dd1_route.DataBind()

        Catch exp As Exception
            lbl_msg.Text = "please fill bus no !!"
        End Try

    End Function

    Protected Sub txt_bus_no_TextChanged(sender As Object, e As EventArgs) Handles txt_bus_no.TextChanged
        Getroute()
    End Sub

    Protected Sub txt_arr_dept_time_TextChanged(sender As Object, e As EventArgs) Handles txt_arr_dept_time.TextChanged
        Try
            If (rbl_in_out.SelectedItem.Value = "in") Then

                Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
                Try
                    cmd.Connection.Open()
                    Dim time_in3 As DateTime
                    Dim time_in2 As String
                    ' Dim time_in1 As DateTime
                    Dim sqlstr As String = "Select scheduled_arrival from bus_details_registration where bus_no ='" & txt_bus_no.Text & "' and shift='" & rbl_shift.SelectedItem.Text & "'"
                    Dim dr As SqlDataReader
                    dr = SqlHelper.ExecuteReader(ConfigurationManager.AppSettings("con"), CommandType.Text, sqlstr)
                    While dr.Read
                        time_in2 = dr.Item("scheduled_arrival")

                    End While
                    ' time_in3 = CDate(time_in1 + " " + txt_arr_dept_time.Text)
                    time_in3 = (Left(time_in2, 11) + " " + txt_arr_dept_time.Text)
                    If (time_in3 <= time_in2) Then
                        txt_time.Text = "No Delay"
                        lbl_msg.Text = ""
                    Else
                        Dim span3 As TimeSpan = time_in3.Subtract(time_in2)
                        txt_time.Text = Convert.ToString(span3)
                        lbl_msg.Text = ""
                    End If
                Catch exp As Exception
                    lbl_msg.Text = "Please Select right shift..."
                End Try


            ElseIf (rbl_in_out.SelectedItem.Value = "out") Then
                Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
                Try
                    cmd.Connection.Open()
                    Dim time_in3 As DateTime
                    Dim time_in2 As String
                    ' Dim time_in1 As DateTime
                    Dim sqlstr As String = "Select scheduled_departure from bus_details_registration where bus_no ='" & txt_bus_no.Text & "' and shift='" & rbl_shift.SelectedItem.Text & "'"
                    Dim dr As SqlDataReader
                    dr = SqlHelper.ExecuteReader(ConfigurationManager.AppSettings("con"), CommandType.Text, sqlstr)
                    While dr.Read
                        time_in2 = dr.Item("scheduled_departure")

                    End While
                    ' time_in3 = CDate(time_in1 + " " + txt_arr_dept_time.Text)
                    time_in3 = (Left(time_in2, 11) + " " + txt_arr_dept_time.Text)
                    If (time_in3 <= time_in2) Then
                        txt_time.Text = "No Delay"
                        lbl_msg.Text = ""
                    Else
                        Dim span3 As TimeSpan = time_in3.Subtract(time_in2)
                        txt_time.Text = Convert.ToString(span3)
                        lbl_msg.Text = ""
                    End If
                Catch exp As Exception
                    lbl_msg.Text = "Please select right shift..."
                End Try

            End If
        Catch ee As Exception
            lbl_msg.Text = "Please select bus shift and bus timing "
        End Try

    End Sub

    Protected Sub rbl_in_out_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rbl_in_out.SelectedIndexChanged
        If (rbl_in_out.SelectedItem.Value = "in") Then
            txt_arr_dept_time.Text = ""
            txt_time.Text = ""
        ElseIf (rbl_in_out.SelectedItem.Value = "out") Then
            txt_arr_dept_time.Text = ""
            txt_time.Text = ""
        End If
    End Sub

    Protected Sub btn_Save_Click(sender As Object, e As EventArgs) Handles btn_Save.Click
        If btn_Save.Text = "Save" Then
            Try
                con.Open()

                Dim sqlPara(5) As SqlParameter

                sqlPara(0) = New SqlParameter("@Shift", Trim(rbl_shift.SelectedItem.Text))
                sqlPara(1) = New SqlParameter("@txt_bus_code", Trim(txt_bus_no.Text))
                sqlPara(2) = New SqlParameter("@txt_bus_route", Trim(dd1_route.SelectedItem.Text))
                sqlPara(3) = New SqlParameter("@rbl_in_out", Trim(rbl_in_out.SelectedItem.Text))
                sqlPara(4) = New SqlParameter("@txt_arr_dept_time", Convert.ToDateTime(txt_arr_dept_time.Text))
                sqlPara(5) = New SqlParameter("@delay_time", Trim(txt_time.Text))



                Dim sqlstr As String = "insert into bus_status_management(bus_no,bus_route,shift,bus_timing,arr_or_dept_time,delay_time) values(@txt_bus_code,@txt_bus_route,@Shift,@rbl_in_out,@txt_arr_dept_time,@delay_time)"

                Try
                    Dim i As Integer = SqlHelper.ExecuteNonQuery(con, CommandType.Text, sqlstr, sqlPara)
                    lbl_msg.Text = "Bus status Details Saved...."
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
            If btn_Save.Text = "Update" Then

                Try

                    lbl_msg.Text = ""
                    Dim sqlPara(5) As SqlParameter

                    sqlPara(0) = New SqlParameter("@Shift", Trim(rbl_shift.SelectedItem.Text))
                    sqlPara(1) = New SqlParameter("@txt_bus_code", Trim(txt_bus_no.Text))
                    sqlPara(2) = New SqlParameter("@txt_bus_route", Trim(dd1_route.SelectedItem.Text))
                    sqlPara(3) = New SqlParameter("@rbl_in_out", Trim(rbl_in_out.SelectedItem.Text))
                    sqlPara(4) = New SqlParameter("@txt_arr_dept_time", Convert.ToDateTime(txt_arr_dept_time.Text))
                    sqlPara(5) = New SqlParameter("@delay_time", Trim(txt_time.Text))


                    Try
                        strSql = "update bus_status_management set bus_route=@txt_bus_route,bus_timing=@rbl_in_out,arr_or_dept_time=@txt_arr_dept_time,delay_time=@delay_time where bus_no='" & txt_bus_no.Text & "' and shift='" & rbl_shift.SelectedItem.Text & "' "


                        SqlHelper.ExecuteNonQuery(con, CommandType.Text, strSql, sqlPara)
                        lbl_msg.Text = "Updated Sucessfully"
                        btn_Save.Text = "Save"
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

    Public Sub getDateShift()

        Dim dt As Date
        Dim Shift As String
        dt = Now
        Select Case dt.Hour
            Case 6 To 14
                Shift = "A"
            Case 14 To 22
                Shift = "B"
            Case 9 To 16
                Shift = "G"
            Case Else
                Shift = "C"
        End Select
        Dim i As Integer = 0
        rbl_shift.ClearSelection()
        For i = 0 To rbl_shift.Items.Count - 1
            If rbl_shift.Items(i).Text = Shift Then
                rbl_shift.Items(i).Selected = True
                Exit For
            End If
        Next
        dt = Nothing

        Shift = Nothing
        i = Nothing
    End Sub





End Class