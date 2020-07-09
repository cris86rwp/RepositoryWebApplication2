Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports System.DateTime


Public Class addNormalisingFurnaceZoneTemp
    Inherits System.Web.UI.Page
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList

    Protected WithEvents grdDrawFurnace As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtHSD_meter_reading As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboShift As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboTime As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboZone As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnClear As System.Web.UI.WebControls.Button
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents Message As System.Web.UI.WebControls.Label
    Protected WithEvents txtOperator_name As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTemperature As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents TextBox1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Zone1t As System.Web.UI.WebControls.TextBox
    Protected WithEvents Zone2t As System.Web.UI.WebControls.TextBox
    Protected WithEvents Zone3t As System.Web.UI.WebControls.TextBox
    Protected WithEvents Zone4t As System.Web.UI.WebControls.TextBox
    Protected WithEvents Zone5t As System.Web.UI.WebControls.TextBox
    Protected WithEvents Zone6t As System.Web.UI.WebControls.TextBox



    Private strmode As String
    Private sqlStr As String
    Dim strSql As String
    Private DS As DataSet
    Private cmd As SqlDataAdapter
    Private sqlStr1 As String
    Private sqlStr2 As String
    Private sqlStr3 As String
    Private rdrtemp As SqlDataReader
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblMode As System.Web.UI.WebControls.Label
    Protected WithEvents btnExit As System.Web.UI.WebControls.Button
    Protected WithEvents rvtemp As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator2 As System.Web.UI.WebControls.RequiredFieldValidator

    Protected WithEvents rdo1 As System.Web.UI.WebControls.RadioButtonList
    Public con As New SqlConnection(ConfigurationManager.AppSettings("con"))
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
        strmode = "add"
        '  lblMode.Text = strmode



        If Page.IsPostBack = True Then

            Select Case strmode
                Case "add"
                    grdDrawFurnace.Columns(9).Visible = False
                    grdDrawFurnace.Columns(10).Visible = False
                Case "edit"
                    grdDrawFurnace.Columns(9).Visible = True
                    grdDrawFurnace.Columns(1).Visible = True
                    grdDrawFurnace.Columns(2).Visible = True
                    grdDrawFurnace.Columns(3).Visible = True
                    grdDrawFurnace.Columns(4).Visible = True
                    grdDrawFurnace.Columns(5).Visible = True
                    grdDrawFurnace.Columns(6).Visible = True
                    grdDrawFurnace.Columns(7).Visible = True

                    grdDrawFurnace.Columns(8).Visible = True
                    grdDrawFurnace.Columns(10).Visible = True
                    grdDrawFurnace.Columns(11).Visible = False
                    '  RequiredFieldValidator1.Enabled = False
                  '  rvtemp.Enabled = False
                Case "view"
                    grdDrawFurnace.Columns(10).Visible = False
                    grdDrawFurnace.Columns(11).Visible = False
                    btnSave.Visible = False
                    btnClear.Visible = False
                    btnExit.Visible = False
                Case "delete"
                    'RequiredFieldValidator1.Enabled = False
                    'rvtemp.Enabled = False
                    grdDrawFurnace.Columns(10).Visible = False
                    grdDrawFurnace.Columns(11).Visible = True
                    btnSave.Text = "Delete All"
                    Message.Text = "Carefull while using delete all button "
            End Select
        End If


    End Sub
    Private Sub grdDrawFurnace_EditCommand(ByVal source As Object, ByVal objArgs As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdDrawFurnace.EditCommand
        If strmode = "edit" Then


            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            Dim strSql As String
            Message.Text = ""
            grdDrawFurnace.EditItemIndex = objArgs.Item.ItemIndex
            strSql = "select convert(varchar(50),temperature_reading_time,108) as mytime, shift_code,zone1t,zone2t,zone3t,zone4t,zone5t,zone6t ,remarks from mm_normalising_furnace_temperatures where df_date='" & Format(CDate(txtDate.Text), "MM/dd/yyyy") & "'"
            BindDataGrid(strSql)
        End If
    End Sub

    Private Sub grdDrawFurnace_UpdateCommand(ByVal source As Object, ByVal objArgs As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdDrawFurnace.UpdateCommand
        Dim temperature, remarks As TextBox
        Dim time, zone As String
        Dim objCmd As SqlCommand
        Dim objDr As SqlDataReader

        If con.State = ConnectionState.Closed Then
            con.Open()
        End If
        Dim strUpdSql, strSql As String


        Try
            time = objArgs.Item.Cells(0).Text
            'zone = objArgs.Item.Cells(1).Text
            'temperature = objArgs.Item.Cells(2).Controls(0)
            remarks = objArgs.Item.Cells(9).Controls(0)
            'Dim date_time As Date
            'Dim strtemp As String
            'strtemp = txtDate.Text
            'date_time = Convert.ToDateTime(strtemp & " " & time)
            strUpdSql = "Update mm_normalising_furnace_temperatures set  remarks='" & Trim(remarks.Text) & "' where df_date='" & Format(CDate(txtDate.Text), "MM/dd/yyyy") & "' and temperature_reading_time='" & Format(CDate(txtDate.Text), "MM/dd/yyyy") & " " & time & "'"
            'And zone_number ='" & zone & "'"zone_temperature='" & Trim(CSng(temperature.Text)) & "',
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            objCmd = New SqlCommand()
            objCmd.CommandType = CommandType.Text
            objCmd.CommandText = strUpdSql
            objCmd.Connection = con
            objCmd.ExecuteNonQuery()
            strSql = "select convert(varchar(50),temperature_reading_time,108) as mytime,shift_code ,zone1t,zone2t,zone3t,zone4t,zone5t,zone6t ,remarks from mm_normalising_furnace_temperatures where df_date='" & Format(CDate(txtDate.Text), "MM/dd/yyyy") & "'"
            grdDrawFurnace.EditItemIndex = -1
            BindDataGrid(strSql)
            Message.Text = "Data Update Sucessfully"
        Catch exp As SqlException


            strSql = exp.StackTrace
            Message.Text = "Line : " & Mid(strSql, InStr(strSql, "line") + 5) & " Message : " + exp.Message

        Catch exp As Exception
            strSql = exp.StackTrace
            Message.Text = "Line : " & Mid(strSql, InStr(strSql, "line") + 5) & " Message : " + exp.Message
        End Try
    End Sub
    Private Sub grdDrawFurnace_CancelCommand(ByVal source As Object, ByVal objArgs As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdDrawFurnace.CancelCommand
        If con.State = ConnectionState.Closed Then
            con.Open()
        End If
        strSql = "select convert(varchar(50),temperature_reading_time,108) as mytime,,shift_code, zone1t,zone2t,zone3t,zone4t,zone5t,zone6t ,remarks from mm_normalising_furnace_temperatures where df_date='" & Format(CDate(txtDate.Text), "MM/dd/yyyy") & "'"
        grdDrawFurnace.EditItemIndex = -1
        BindDataGrid(strSql)
    End Sub

    Private Sub grdDrawFurnace_DeleteCommand(ByVal source As Object, ByVal objArgs As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdDrawFurnace.DeleteCommand
        If strmode = "delete" Then


            Dim strsql As String
            Dim time, zone As String

            time = objArgs.Item.Cells(0).Text
            zone = objArgs.Item.Cells(1).Text
            'Dim date_time As Date
            'Dim strtemp As String
            'strtemp = txtDate.Text
            'date_time = Convert.ToDateTime(strtemp & " " & time)

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            strsql = "delete from mm_normalising_furnace_temperatures where df_date='" & Format(CDate(txtDate.Text), "MM/dd/yyyy") & "' and temperature_reading_time='" & Format(CDate(txtDate.Text), "MM/dd/yyyy") & " " & time & "'"
            SqlHelper.ExecuteNonQuery(con, CommandType.Text, strsql)
            Message.Text = "Record Deleted Sucessfully"
            strsql = "select convert(varchar(50),temperature_reading_time,108) as mytime,shift_code, zone1t,zone2t,zone3t,zone4t,zone5t,zone6t ,remarks from mm_normalising_furnace_temperatures where df_date='" & Format(CDate(txtDate.Text), "MM/dd/yyyy") & "'"
            Call BindDataGrid(strsql)
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If btnSave.Text = "Save" Then
            con.Open()

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            'If strmode = "add" Then

            '    If btnSave.Text = "add" Then

            '        btnSave.Text = "save"
            '        Message.Text = ""
            '        Call clearform()
            '        'RequiredFieldValidator1.Enabled = True
            '        'rvtemp.Enabled = True

            '    Else
            '        'Dim time_in As DateTime
            'Dim time_out As DateTime




            'Declaring parameters and assigning for Normalising  table
            'Dim date_time As Date
            'Dim strtemp As String
            'strtemp = txtDate.Text
            'date_time = Convert.ToDateTime(strtemp & " " & cboTime.SelectedItem.Text)

            Dim sqlPara(12) As SqlParameter
            sqlPara(0) = New SqlParameter("@txtHSD_meter_reading", Trim(txtHSD_meter_reading.Text))
            sqlPara(1) = New SqlParameter("@txtOperator_name", Trim(txtOperator_name.Text))
            sqlPara(2) = New SqlParameter("@txtDate", CDate(Trim(txtDate.Text)))
            'sqlPara(3) = New SqlParameter("@txtTemperature", CSng(Trim(txtTemperature.Text)))
            sqlPara(4) = New SqlParameter("@txtRemarks", Trim(txtRemarks.Text))
            sqlPara(5) = New SqlParameter("@cboTime", Format(CDate(txtDate.Text), "MM/dd/yyyy") & " " & cboTime.SelectedItem.Text)
            sqlPara(6) = New SqlParameter("@cboShift", Trim(cboShift.SelectedItem.Text))
            'sqlPara(7) = New SqlParameter("@cboZone", Trim(cboZone.SelectedItem.Text))
            sqlPara(3) = New SqlParameter("@Zone1t", CSng(Trim(Zone1t.Text)))
            sqlPara(7) = New SqlParameter("@Zone2t", CSng(Trim(Zone2t.Text)))
            sqlPara(8) = New SqlParameter("@Zone3t", CSng(Trim(Zone3t.Text)))
            sqlPara(9) = New SqlParameter("@Zone4t", CSng(Trim(Zone4t.Text)))
            sqlPara(10) = New SqlParameter("@Zone5t", CSng(Trim(Zone5t.Text)))
            sqlPara(11) = New SqlParameter("@Zone6t", CSng(Trim(Zone6t.Text)))
            ' sqlPara(13) = New SqlParameter("@Zone7t", CSng(Trim(Zone7t.Text)))
            ' sqlPara(7) = New SqlParameter("@Zone8t", CSng(Trim(Zone8t.Text)))
            sqlPara(12) = New SqlParameter("@SIC", Trim(TextBox1.Text))


            Dim sqlstr As String = "insert into mm_normalising_furnace_temperatures(df_date,shift_code,shift_operator,hsd_reading_at_815,temperature_reading_time,zone1t,zone2t,zone3t,zone4t,zone5t,zone6t,remarks,SIC) values("
            sqlstr &= "@txtDate,@cboShift,@txtOperator_name,@txtHSD_meter_reading,@cboTime,@Zone1t,@Zone2t,@Zone3t,@Zone4t,@Zone5t,@Zone6t,@txtRemarks,@SIC)"
            'Dim Done As Boolean
            'Dim cmd1 As String
            'Done = IIf(IsDBNull)(cmd1.Parameters("@cnt").Value),0, Cmd1.Parameters("@cnt").Value)

            Try

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If
                SqlHelper.ExecuteNonQuery(con, CommandType.Text, sqlstr, sqlPara)
                ' btnSave.Text = "add"
                Message.Text = "Draw Furnace Temperature Added"
                'Press Add to Add one more"
                Call clearform()
                'RequiredFieldValidator1.Enabled = False
                ' rvtemp.Enabled = False
            Catch exp As SqlException
                If exp.Number = 2627 Then
                    Message.Text = "This Reading  Already Taken"
                    btnSave.Text = "Update"
                Else

                    strSql = exp.StackTrace
                    Message.Text = "Line :  " & Mid(strSql, InStr(strSql, "line") + 5) & " Message : " + exp.Message
                End If
            Catch exp As Exception
                strSql = exp.StackTrace
                Message.Text = "Line : " & Mid(strSql, InStr(strSql, "line") + 5) & " Message : " + exp.Message
            End Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            Dim sqlstr2 As String
            sqlstr2 = "select convert(varchar(50),temperature_reading_time,108) as mytime,shift_code, zone1t,zone2t,zone3t,zone4t,zone5t,zone6t,remarks from mm_normalising_furnace_temperatures where df_date='" & Format(CDate(txtDate.Text), "MM/dd/yyyy") & "'"
            grdDrawFurnace.EditItemIndex = -1
            Call BindDataGrid(sqlstr2)
        ElseIf btnSave.Text = "Update" Then
            Dim sqlPara(12) As SqlParameter
            sqlPara(0) = New SqlParameter("@txtHSD_meter_reading", Trim(txtHSD_meter_reading.Text))
            sqlPara(1) = New SqlParameter("@txtOperator_name", Trim(txtOperator_name.Text))
            sqlPara(2) = New SqlParameter("@txtDate", CDate(Trim(txtDate.Text)))
            'sqlPara(3) = New SqlParameter("@txtTemperature", CSng(Trim(txtTemperature.Text)))
            sqlPara(4) = New SqlParameter("@txtRemarks", Trim(txtRemarks.Text))
            sqlPara(5) = New SqlParameter("@cboTime", Format(CDate(txtDate.Text), "MM/dd/yyyy") & " " & cboTime.SelectedItem.Text)
            sqlPara(6) = New SqlParameter("@cboShift", Trim(cboShift.SelectedItem.Text))
            'sqlPara(7) = New SqlParameter("@cboZone", Trim(cboZone.SelectedItem.Text))
            sqlPara(3) = New SqlParameter("@Zone1t", CSng(Trim(Zone1t.Text)))
            sqlPara(7) = New SqlParameter("@Zone2t", CSng(Trim(Zone2t.Text)))
            sqlPara(8) = New SqlParameter("@Zone3t", CSng(Trim(Zone3t.Text)))
            sqlPara(9) = New SqlParameter("@Zone4t", CSng(Trim(Zone4t.Text)))
            sqlPara(10) = New SqlParameter("@Zone5t", CSng(Trim(Zone5t.Text)))
            sqlPara(11) = New SqlParameter("@Zone6t", CSng(Trim(Zone6t.Text)))
            'sqlPara(13) = New SqlParameter("@Zone7t", CSng(Trim(Zone7t.Text)))
            ' sqlPara(7) = New SqlParameter("@Zone8t", CSng(Trim(Zone8t.Text)))
            sqlPara(12) = New SqlParameter("@SIC", Trim(TextBox1.Text))
            Try
                strSql = "update mm_normalising_furnace_temperatures set df_date=@txtDate,shift_code=@cboshift,SIC=@SIC,shift_operator=@txtOperator_name,hsd_reading_at_815=@txtHSD_meter_reading,temperature_reading_time=@cboTime,zone1t=@zone1t,zone2t=@zone2t,zone3t=@zone3t, zone4t=@zone4t,zone5t=@zone5t,zone6t=@zone6t,remarks=@txtRemarks where df_date='" & Format(CDate(txtDate.Text), "MM/dd/yyyy") & "' and shift_code = '" & cboShift.SelectedItem.Text & "'"



                SqlHelper.ExecuteNonQuery(con, CommandType.Text, strSql, sqlPara)
                Message.Text = "Updated Sucessfully"
                btnSave.Text = "Save"
                Call clearform()


            Catch exp As SqlException
                strSql = exp.StackTrace
                Message.Text = "Line : " & Mid(strSql, InStr(strSql, "line") + 5) & " Message : " + exp.Message

            Catch exp As Exception
                strSql = exp.StackTrace
                Message.Text = "Line : " & Mid(strSql, InStr(strSql, "line") + 5) & " Message : " + exp.Message
            End Try
        End If
        Dim sqlstr4 As String
        sqlstr4 = "select convert(varchar(50),temperature_reading_time,108) as mytime,shift_code,zone1t,zone2t,zone3t,zone4t,zone5t,zone6t ,remarks from mm_normalising_furnace_temperatures where df_date='" & Format(CDate(txtDate.Text), "MM/dd/yyyy") & "' and shift_code = '" & cboShift.SelectedItem.Text & "'"
        grdDrawFurnace.EditItemIndex = -1
        Call BindDataGrid(sqlstr4)



        'end of add if

        'Else
        '    If strmode = "edit" Or strmode = "view" Then
        '        If con.State = ConnectionState.Closed Then
        '            con.Open()
        '        Else
        '            con.Close()
        '            con.Open()

        '        End If
        '        If btnSave.Text = "edit" Then
        '            Call clearform()
        '            btnSave.Text = "save"
        '            'RequiredFieldValidator1.Enabled = True
        '            'rvtemp.Enabled = True
        '            Message.Text = ""
        '        Else

        '            Dim strsql As String
        '            Dim sqlPara(2) As SqlParameter
        '            sqlPara(0) = New SqlParameter("@txtHSD_meter_reading", Trim(txtHSD_meter_reading.Text))
        '            sqlPara(1) = New SqlParameter("@txtOperator_name", Trim(txtOperator_name.Text))
        '            sqlPara(2) = New SqlParameter("@txtDate", CDate(Trim(txtDate.Text)))
        '            'sqlPara(3) = New SqlParameter("@txtTemperature", CSng(Trim(txtTemperature.Text)))
        '            'sqlPara(4) = New SqlParameter("@txtRemarks", Trim(txtRemarks.Text))
        '            'sqlPara(5) = New SqlParameter("@cboTime", CDate(Trim(cboTime.SelectedItem.Text)))
        '            'sqlPara(6) = New SqlParameter("@cboShift", Trim(cboShift.SelectedItem.Text))
        '            'sqlPara(7) = New SqlParameter("@cboZone", Trim(cboZone.SelectedItem.Text))

        '            Try
        '                strsql = "updatemm_normalising_furnace_temperatures set shift_operator=@txtOperator_name,hsd_reading_at_815=@txtHSD_meter_reading where df_date='" & Format(CDate(txtDate.Text), "MM/dd/yyyy") & "'"


        '                SqlHelper.ExecuteNonQuery(con, CommandType.Text, strsql, sqlPara)
        '                Message.Text = "operator Name N' Meter Reading Updated Sucessfully, PRESS EDIT to EDIT another"
        '                btnSave.Text = "edit"
        '                Call clearform()
        '                'RequiredFieldValidator1.Enabled = False
        '                'rvtemp.Enabled = False

        '            Catch exp As SqlException
        '                strsql = exp.StackTrace
        '                Message.Text = "Line : " & Mid(strsql, InStr(strsql, "line") + 5) & " Message : " + exp.Message

        '            Catch exp As Exception
        '                strsql = exp.StackTrace
        '                Message.Text = "Line : " & Mid(strsql, InStr(strsql, "line") + 5) & " Message : " + exp.Message
        '            End Try
        '        End If

        '    End If
        '    If strmode = "delete" Then
        '        If btnSave.Text = "Delete All" Then
        '            If con.State = ConnectionState.Closed Then
        '                con.Open()
        '            Else
        '                con.Close()
        '                con.Open()

        '            End If

        '            Dim strsql As String

        '            strsql = "delete from mm_normalising_furnace_temperatures where df_date='" & Format(CDate(txtDate.Text), "MM/dd/yyyy") & "'"

        '            SqlHelper.ExecuteNonQuery(con, CommandType.Text, strsql)
        '            Message.Text = " Details Deleted Sucessfully"



        '            Call clearform()
        '            grdDrawFurnace.Visible = False

        '        End If
        '    End If

        'End If

    End Sub
    Sub clearform()


        txtOperator_name.Text = ""
        txtRemarks.Text = ""
        Zone1t.Text = ""
        Zone2t.Text = ""
        Zone3t.Text = ""
        Zone4t.Text = ""
        Zone5t.Text = ""
        Zone6t.Text = ""

        ' txtTemperature.Text = ""
        'cboZone.SelectedIndex = 0

    End Sub
    Sub fillDFData()
        Dim rdrtemp As SqlDataReader
        Dim sqlstr As String
        If con.State = ConnectionState.Closed Then
            con.Open()
        End If
        Try
            sqlstr = "select shift_operator,hsd_reading_at_815 from  mm_normalising_furnace_temperatures where df_date='" & Format(CDate(txtDate.Text), "MM/dd/yyyy") & "'"
            rdrtemp = SqlHelper.ExecuteReader(con, CommandType.Text, sqlstr)

            If rdrtemp.Read = False Then
                Message.Text = "Details of Operator,Reading are Not  Available"
            Else
                txtOperator_name.Text = rdrtemp("shift_operator") & ""
                txtHSD_meter_reading.Text = rdrtemp("hsd_reading_at_815") & ""
            End If

        Catch exp As SqlException
            strSql = exp.StackTrace
            Message.Text = "Line : " & Mid(strSql, InStr(strSql, "line") + 5) & " Message : " + exp.Message

        Catch exp As Exception
            strSql = exp.StackTrace
            Message.Text = "Line : " & Mid(strSql, InStr(strSql, "line") + 5) & " Message : " + exp.Message
        End Try

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
            grdDrawFurnace.DataSource = arr
            grdDrawFurnace.DataBind()
            grdDrawFurnace.DataSource = objDr
            grdDrawFurnace.DataBind()
        Catch exp As SqlException
            strSql = exp.StackTrace
            Message.Text = "Line : " & Mid(strSql, InStr(strSql, "line") + 5) & " Message : " + exp.Message

        Catch exp As Exception
            strSql = exp.StackTrace
            Message.Text = "Line : " & Mid(strSql, InStr(strSql, "line") + 5) & " Message : " + exp.Message
        End Try

        con.Close()

    End Sub






    Private Sub txtDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged
        Try
            If CDate(txtDate.Text) > Now Then
                Message.Text = "Entered date cannot be greater than today"
                txtDate.Text = ""
                Exit Sub
            End If
            If strmode = "edit" Or strmode = "delete" Or strmode = "view" Then
                Call fillDFData()
                Dim sqlstr3 As String
                sqlstr3 = "select convert(varchar(50),temperature_reading_time,108) as mytime,shift_code, zone1t,zone2t,zone3t,zone4t,zone5t,zone6t,remarks from mm_normalising_furnace_temperatures where df_date='" & Format(CDate(txtDate.Text), "MM/dd/yyyy") & "' and shift_code = '" & cboShift.SelectedItem.Text & "'"
                Call BindDataGrid(sqlstr3)
            End If
        Catch
            Message.Text = "Enter date in 'dd-mm-yyyy' Format"
            txtDate.Text = ""
        End Try
    End Sub

    Private Sub grdDrawFurnace_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdDrawFurnace.PageIndexChanged
        grdDrawFurnace.CurrentPageIndex = e.NewPageIndex
        Dim sqlstr3 As String
        sqlstr3 = "select convert(varchar(50),temperature_reading_time,108) as mytime,shift_code,zone1t,zone2t,zone3t,zone4t,zone5t,zone6t ,remarks from mm_normalising_furnace_temperatures where df_date='" & Format(CDate(txtDate.Text), "MM/dd/yyyy") & "' and shift_code = '" & cboShift.SelectedItem.Text & "'"
        Call BindDataGrid(sqlstr3)
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("/wap/selectModule.aspx")
    End Sub

    Private Sub cboShift_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboShift.SelectedIndexChanged
        Dim sqlstr3 As String
        sqlstr3 = "select convert(varchar(50),temperature_reading_time,108) as mytime,shift_code,zone1t,zone2t,zone3t,zone4t,zone5t,zone6t ,remarks from mm_normalising_furnace_temperatures where df_date='" & Format(CDate(txtDate.Text), "MM/dd/yyyy") & "' and shift_code = '" & cboShift.SelectedItem.Text & "'"
        Call BindDataGrid(sqlstr3)
    End Sub

    Protected Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtOperator_name.Text = ""
        txtRemarks.Text = ""
        Zone1t.Text = ""
        Zone2t.Text = ""
        Zone3t.Text = ""
        Zone4t.Text = ""
        Zone5t.Text = ""
        Zone6t.Text = ""
        txtHSD_meter_reading.Text = ""
    End Sub
End Class

