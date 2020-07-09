Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports System.DateTime


Public Class EditDrawfurnaceDetails
    Inherits System.Web.UI.Page

    Protected WithEvents txtNF_date As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboShift As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtHeat_number As System.Web.UI.WebControls.TextBox
    Protected WithEvents hanger_no As System.Web.UI.WebControls.TextBox
    Protected WithEvents txt_sic As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtOperator_name As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtWheel_number As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtdfin_time As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtdfout_time As System.Web.UI.WebControls.TextBox
    Protected WithEvents cycle_time As System.Web.UI.WebControls.TextBox
    Protected WithEvents whltmp_charge_hub As System.Web.UI.WebControls.TextBox
    Protected WithEvents whltmp_charge_rim As System.Web.UI.WebControls.TextBox
    Protected WithEvents whltmp_discharge_hub As System.Web.UI.WebControls.TextBox
    Protected WithEvents whltmp_discharge_rim As System.Web.UI.WebControls.TextBox
    Protected WithEvents hc_duration As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtremarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents Message As System.Web.UI.WebControls.Label
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddl_hcstatus As System.Web.UI.WebControls.DropDownList
    Protected WithEvents hc1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents hc2 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents hc3 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnClear As System.Web.UI.WebControls.Button
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents btnExit As System.Web.UI.WebControls.Button
    Protected WithEvents dg_wheel_normalising As System.Web.UI.WebControls.DataGrid
    Protected WithEvents grdDrawFurnace As System.Web.UI.WebControls.DataGrid
    Protected WithEvents ddl_htstatus As System.Web.UI.WebControls.DropDownList
    Private strmode As String
    Private sqlStr As String
    Dim strSql As String
    Private DS As DataSet
    Private cmd As SqlDataAdapter
    Private sqlStr1 As String
    Private sqlStr2 As String
    Private sqlStr3 As String
    Private rdrtemp As SqlDataReader
    Public con As New SqlConnection(ConfigurationManager.AppSettings("con"))
    Protected WithEvents lblMode As System.Web.UI.WebControls.Label
    Dim i As Integer
    Dim n As Integer
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
            If (hc1.SelectedItem.Value = "ok" And hc2.SelectedItem.Value = "ok" And hc3.SelectedItem.Value = "ok") Then
                hc_duration.Text = "120"
            End If
        End If
        'Put user code to initialize the page here
        strmode = "edit"
        'strMode = Request.QueryString("mode")
        'lblMode.Text = strmode
        If Page.IsPostBack = False Then
            Select Case strmode
                Case "add"
                    'txtNF_date.AutoPostBack = False
                    'cboShift.AutoPostBack = False
                    'grdNormalizingFurnace.Columns(7).Visible = False
                    'grdNormalizingFurnace.Columns(8).Visible = False

                Case "edit"
                    grdDrawFurnace.Columns(21).Visible = True
                    grdDrawFurnace.Columns(22).Visible = False

                Case "view"
                    grdDrawFurnace.Columns(7).Visible = False
                    grdDrawFurnace.Columns(8).Visible = False
                    btnExit.Visible = False
                    btnSave.Visible = False
                    btnClear.Visible = False
                Case "delete"
                    grdDrawFurnace.Columns(7).Visible = False
                    grdDrawFurnace.Columns(8).Visible = True
                    btnSave.Text = "Delete All"
                    Message.Text = "Carefull while using delete all button "
            End Select
        End If
    End Sub
    'Private Sub grdNormalizingFurnace_EditCommand(ByVal source As Object, ByVal objArgs As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdNormalizingFurnace.EditCommand
    '    If strmode = "edit" Then
    '        If con.State = ConnectionState.Closed Then
    '            con.Open()
    '        End If
    '        Dim strSql As String
    '        Message.Text = ""
    '        grdNormalizingFurnace.EditItemIndex = objArgs.Item.ItemIndex
    '        strSql = "select wheel_number,pedestral_number,charge_in_time,charge_out_time,offload_code,quenched_number,remarks from mm_normalizing_furnace_loading where loading_date='" & Format(CDate(txtNF_date.Text), "MM/dd/yyyy") & "' and shift_code='" & cboShift.SelectedItem.Text & "' and heat_number='" & txtHeat_number.Text & "'"
    '        BindDataGrid(strSql)
    '    End If
    'End Sub

    'Private Sub grdNormalizingFurnace_UpdateCommand(ByVal source As Object, ByVal objArgs As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdNormalizingFurnace.UpdateCommand
    '    Dim pedestral_number, charge_in_time, charge_out_time, offload_code, quenched_number, remarks As TextBox
    '    Dim wheel_number As String
    '    Dim objCmd As SqlCommand
    '    Dim objDr As SqlDataReader

    '    If con.State = ConnectionState.Closed Then
    '        con.Open()
    '    End If
    '    Dim strUpdSql, strSql As String


    '    Try

    '        wheel_number = objArgs.Item.Cells(0).Text
    '        pedestral_number = objArgs.Item.Cells(1).Controls(0)
    '        charge_in_time = objArgs.Item.Cells(2).Controls(0)
    '        charge_out_time = objArgs.Item.Cells(3).Controls(0)
    '        offload_code = objArgs.Item.Cells(4).Controls(0)
    '        quenched_number = objArgs.Item.Cells(5).Controls(0)
    '        remarks = objArgs.Item.Cells(6).Controls(0)



    '        strUpdSql = "Update mm_draw_furnace_details set hanger_no='" & hanger_no.Text & "',charge_in_time='" & Format(CDate(charge_in_time.Text), "MM/dd/yyyy HH:mm:ss") & "',charge_out_time='" & Format(CDate(charge_out_time.Text), "MM/dd/yyyy HH:mm:ss") & "',offload_code='" & offload_code.Text & "',quenched_number='" & quenched_number.Text & "',remarks='" & remarks.Text & "' where loading_date='" & Format(CDate(txtNF_date.Text), "MM/dd/yyyy") & "' and shift_code='" & cboShift.SelectedItem.Text & "' and heat_number='" & txtHeat_number.Text & "' and wheel_number='" & wheel_number & "'"



    '        If con.State = ConnectionState.Closed Then
    '            con.Open()
    '        End If
    '        objCmd = New SqlCommand()
    '        objCmd.CommandType = CommandType.Text
    '        objCmd.CommandText = strUpdSql
    '        objCmd.Connection = con
    '        objCmd.ExecuteNonQuery()
    '        strSql = "select wheel_number,pedestral_number,charge_in_time,charge_out_time,offload_code,quenched_number,remarks from mm_normalizing_furnace_loading where loading_date='" & Format(CDate(txtNF_date.Text), "MM/dd/yyyy") & "' and shift_code='" & cboShift.SelectedItem.Text & "' and heat_number='" & txtHeat_number.Text & "'"
    '        grdNormalizingFurnace.EditItemIndex = -1
    '        BindDataGrid(strSql)
    '        Message.Text = "Data Update Sucessfully"
    '    Catch exp As SqlException


    '        strSql = exp.StackTrace
    '        Message.Text = "Line : " & Mid(strSql, InStr(strSql, "line") + 5) & " Message : " + exp.Message

    '    Catch exp As Exception
    '        strSql = exp.StackTrace
    '        Message.Text = "Line : " & Mid(strSql, InStr(strSql, "line") + 5) & " Message : " + exp.Message
    '    End Try
    'End Sub

    Private Sub grdDrawFurnace_DeleteCommand(ByVal source As Object, ByVal objArgs As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdDrawFurnace.DeleteCommand
        If strmode = "delete" Then
            Dim strsql As String
            Dim cellwheel_number As String
            cellwheel_number = objArgs.Item.Cells(0).Text
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            strsql = "delete from mm_draw_furnace_details where loading_date='" & Format(CDate(txtNF_date.Text), "MM/dd/yyyy") & "' and shift_code='" & cboShift.SelectedItem.Text & "' and heat_number='" & txtHeat_number.Text & "' and wheel_number='" & cellwheel_number & "'"
            SqlHelper.ExecuteNonQuery(con, CommandType.Text, strsql)
            Message.Text = "Record Deleted Sucessfully"
            strsql = "select wheel_number,hanger_no,df_in_time,df_out_time,offload_code,whltmp_charging_hub,whltmp_charging_rim,whltmp_discharging_hub,whltmp_discharging_rim,hc_duration,hc1_status,hc2_status,hc3_status,remarks from mm_draw_furnace_details where loading_date='" & Format(CDate(txtNF_date.Text), "MM/dd/yyyy") & "' and shift_code='" & cboShift.SelectedItem.Text & "' and heat_number='" & txtHeat_number.Text & "'"
            Call BindDataGrid(strsql)
        End If
    End Sub


    Private Sub grdDrawFurnace_CancelCommand(ByVal source As Object, ByVal objArgs As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdDrawFurnace.CancelCommand
        If con.State = ConnectionState.Closed Then
            con.Open()
        End If
        strSql = "select wheel_number,hanger_no,df_in_time,df_out_time,offload_code,whltmp_charging_hub,whltmp_charging_rim,whltmp_discharging_hub,whltmp_discharging_rim,hc_duration,hc1_status,hc2_status,hc3_status,remarks from mm_draw_furnace_details where loading_date='" & Format(CDate(txtNF_date.Text), "MM/dd/yyyy") & "' and shift_code='" & cboShift.SelectedItem.Text & "' and heat_number='" & txtHeat_number.Text & "'"
        grdDrawFurnace.EditItemIndex = -1
        BindDataGrid(strSql)
    End Sub

    Sub clearform()

        txtHeat_number.Text = ""
        txt_sic.Text = ""
        txtdfin_time.Text = ""
        txtdfout_time.Text = ""
        txtOperator_name.Text = ""
        txtWheel_number.Text = ""
        cycle_time.Text = ""
        hanger_no.Text = ""
        whltmp_charge_hub.Text = ""
        whltmp_charge_rim.Text = ""
        whltmp_discharge_hub.Text = ""
        whltmp_discharge_rim.Text = ""
        hc_duration.Text = ""
        ddl_htstatus.SelectedIndex = 0
        hc1.SelectedIndex = 0
        hc2.SelectedIndex = 0
        hc3.SelectedIndex = 0
        txtremarks.Text = ""
    End Sub

    Protected Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Call clearform()
    End Sub

    Protected Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Response.Redirect("selectModule.aspx")
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If btnSave.Text = "Save" Then

            con.Open()

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If


            Dim t1 As DateTime = CDate(txtNF_date.Text + " " & txtdfin_time.Text)
            Dim t2 As DateTime = CDate(txtNF_date.Text + " " & txtdfout_time.Text)


            'Declaring parameters and assigning for Normalising  table
            Dim sqlPara(19) As SqlParameter
            sqlPara(0) = New SqlParameter("@txtHeat_number", Val(Trim(txtHeat_number.Text)))
            sqlPara(1) = New SqlParameter("@txtOperator_name", Trim(txtOperator_name.Text))
            sqlPara(2) = New SqlParameter("@hanger_no", Trim(hanger_no.Text))
            sqlPara(3) = New SqlParameter("@txtRemarks", Trim(txtremarks.Text))
            sqlPara(4) = New SqlParameter("@txtNF_date", Format(CDate(txtNF_date.Text), "MM/dd/yyyy"))
            sqlPara(5) = New SqlParameter("@cboShift", Trim(cboShift.SelectedItem.Text))
            sqlPara(6) = New SqlParameter("@txtTime_in", Trim(t1))
            sqlPara(7) = New SqlParameter("@txtTime_out", Trim(t2))
            sqlPara(8) = New SqlParameter("@txtWheel_number", Trim(txtWheel_number.Text))
            sqlPara(9) = New SqlParameter("@whltmp_charge_hub", Trim(whltmp_charge_hub.Text))
            sqlPara(10) = New SqlParameter("@whltmp_charge_rim", Trim(whltmp_charge_rim.Text))
            sqlPara(11) = New SqlParameter("@whltmp_discharge_hub", Trim(whltmp_discharge_hub.Text))
            sqlPara(12) = New SqlParameter("@whltmp_discharge_rim", Trim(whltmp_discharge_rim.Text))
            sqlPara(13) = New SqlParameter("@hc_duration", Trim(hc_duration.Text))
            sqlPara(14) = New SqlParameter("@hc1", Trim(hc1.SelectedItem.Text))
            sqlPara(15) = New SqlParameter("@hc2", Trim(hc2.SelectedItem.Text))
            sqlPara(16) = New SqlParameter("@hc3", Trim(hc3.SelectedItem.Text))
            sqlPara(17) = New SqlParameter("@txtcycletime", Trim(cycle_time.Text))
            sqlPara(18) = New SqlParameter("@ddl_htstatus", Trim(ddl_htstatus.SelectedItem.Text))
            sqlPara(19) = New SqlParameter("@sic", Trim(txt_sic.Text))


            Dim sqlstr As String = "insert into mm_draw_furnace_details(loading_date,shift_code,SIC,operator_code,wheel_number,heat_number,hanger_no,df_in_time,df_out_time,cycle_time,whltmp_charging_hub,whltmp_charging_rim,whltmp_discharging_hub,whltmp_discharging_rim,ht_status,hc_duration,hc1_status,hc2_status,hc3_status,remarks) values("
            sqlstr &= "@txtNF_date,@cboShift,@sic,@txtOperator_name,@txtWheel_number,@txtHeat_number,@hanger_no,@txtTime_in,@txtTime_out,@txtcycletime,@whltmp_charge_hub,@whltmp_charge_rim,@whltmp_discharge_hub,@whltmp_discharge_rim,@ddl_htstatus,@hc_duration,@hc1,@hc2,@hc3,@txtRemarks)"

            Try

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If
                SqlHelper.ExecuteNonQuery(con, CommandType.Text, sqlstr, sqlPara)
                ' btnSave.Text = "add"
                Message.Text = "Draw Furnace Details Added"
                Call clearform()

            Catch exp As SqlException
                If exp.Number = 2627 Then
                    Message.Text = "This Record Already exists"
                    btnSave.Text = "Update"
                Else

                    strSql = exp.StackTrace
                    Message.Text = "Line : " & Mid(strSql, InStr(strSql, "line") + 5) & " Message : " + exp.Message
                End If
            Catch exp As Exception
                strSql = exp.StackTrace
                Message.Text = "Line : " & Mid(strSql, InStr(strSql, "line") + 5) & " Message : " + exp.Message
            End Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            Dim sqlstr2 As String
            sqlstr2 = "select loading_date,shift_code,SIC,operator_code,wheel_number,heat_number,hanger_no,df_in_time,df_out_time,cycle_time,whltmp_charging_hub,whltmp_charging_rim,whltmp_discharging_hub,whltmp_discharging_rim,ht_status,hc_duration,hc1_status,hc2_status,hc3_status,remarks from mm_draw_furnace_details where loading_date='" & Format(CDate(txtNF_date.Text), "MM/dd/yyyy") & "'"
            grdDrawFurnace.EditItemIndex = -1
            Call BindDataGrid(sqlstr2)

        Else
            If btnSave.Text = "Update" Then

                Message.Text = ""
                Dim t1 As DateTime = CDate(txtNF_date.Text + " " & txtdfin_time.Text)
                Dim t2 As DateTime = CDate(txtNF_date.Text + " " & txtdfout_time.Text)


                'Declaring parameters and assigning for Normalising  table
                Dim sqlPara(19) As SqlParameter
                sqlPara(0) = New SqlParameter("@txtHeat_number", Val(Trim(txtHeat_number.Text)))
                sqlPara(1) = New SqlParameter("@txtOperator_name", Trim(txtOperator_name.Text))
                sqlPara(2) = New SqlParameter("@hanger_no", Trim(hanger_no.Text))
                sqlPara(3) = New SqlParameter("@txtRemarks", Trim(txtremarks.Text))
                sqlPara(4) = New SqlParameter("@txtNF_date", Format(CDate(txtNF_date.Text), "MM/dd/yyyy"))
                sqlPara(5) = New SqlParameter("@cboShift", Trim(cboShift.SelectedItem.Text))
                sqlPara(6) = New SqlParameter("@txtTime_in", Trim(t1))
                sqlPara(7) = New SqlParameter("@txtTime_out", Trim(t2))
                sqlPara(8) = New SqlParameter("@txtWheel_number", Trim(txtWheel_number.Text))
                sqlPara(9) = New SqlParameter("@whltmp_charge_hub", Trim(whltmp_charge_hub.Text))
                sqlPara(10) = New SqlParameter("@whltmp_charge_rim", Trim(whltmp_charge_rim.Text))
                sqlPara(11) = New SqlParameter("@whltmp_discharge_hub", Trim(whltmp_discharge_hub.Text))
                sqlPara(12) = New SqlParameter("@whltmp_discharge_rim", Trim(whltmp_discharge_rim.Text))
                sqlPara(13) = New SqlParameter("@hc_duration", Trim(hc_duration.Text))
                sqlPara(14) = New SqlParameter("@hc1", Trim(hc1.SelectedItem.Text))
                sqlPara(15) = New SqlParameter("@hc2", Trim(hc2.SelectedItem.Text))
                sqlPara(16) = New SqlParameter("@hc3", Trim(hc3.SelectedItem.Text))
                sqlPara(17) = New SqlParameter("@txtcycletime", Trim(cycle_time.Text))
                sqlPara(18) = New SqlParameter("@ddl_htstatus", Trim(ddl_htstatus.SelectedItem.Text))
                sqlPara(19) = New SqlParameter("@sic", Trim(txt_sic.Text))




                Try
                    strSql = "update mm_draw_furnace_details set SIC=@sic,operator_code=@txtOperator_name,wheel_number=@txtWheel_number,heat_number=@txtHeat_number,hanger_no=@hanger_no,df_in_time=@txtTime_in,df_out_time=@txtTime_out,cycle_time=@txtcycletime,whltmp_charging_hub=@whltmp_charge_hub,whltmp_charging_rim=@whltmp_charge_rim,whltmp_discharging_hub=@whltmp_discharge_hub,whltmp_discharging_rim=@whltmp_discharge_rim,ht_status=@ddl_htstatus,hc_duration=@hc_duration,hc1_status=@hc1,hc2_status=@hc2,hc3_status=@hc3,remarks=@txtRemarks where loading_date='" & Format(CDate(txtNF_date.Text), "MM/dd/yyyy") & "' and shift_code='" & cboShift.SelectedItem.Text & "'"


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
            sqlstr4 = "select loading_date,shift_code,SIC,operator_code,wheel_number,heat_number,hanger_no,df_in_time,df_out_time,cycle_time,whltmp_charging_hub,whltmp_charging_rim,whltmp_discharging_hub,whltmp_discharging_rim,ht_status,hc_duration,hc1_status,hc2_status,hc3_status,remarks from mm_draw_furnace_details where loading_date='" & Format(CDate(txtNF_date.Text), "MM/dd/yyyy") & "'"
            grdDrawFurnace.EditItemIndex = -1
            Call BindDataGrid(sqlstr4)
        End If 'end of add if



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

    Private Sub BindDataGrid1(ByVal strArg As String)

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
            dg_wheel_normalising.DataSource = arr
            dg_wheel_normalising.DataBind()
            dg_wheel_normalising.DataSource = objDr
            dg_wheel_normalising.DataBind()
        Catch exp As SqlException
            strSql = exp.StackTrace
            Message.Text = "Line : " & Mid(strSql, InStr(strSql, "line") + 5) & " Message : " + exp.Message

        Catch exp As Exception
            strSql = exp.StackTrace
            Message.Text = "Line : " & Mid(strSql, InStr(strSql, "line") + 5) & " Message : " + exp.Message
        End Try

        con.Close()

    End Sub

    Sub fillNFData()
        Dim rdrtemp As SqlDataReader
        Dim sqlstr As String
        If con.State = ConnectionState.Closed Then
            con.Open()
        End If
        Try
            sqlstr = "select operator_code from mm_draw_furnace_details where loading_date='" & txtNF_date.Text & "' and shift_code='" & cboShift.SelectedItem.Text & "' and heat_number='" & txtHeat_number.Text & "'"
            rdrtemp = SqlHelper.ExecuteReader(con, CommandType.Text, sqlstr)

            If rdrtemp.Read = False Then
                Message.Text = "Operator Name is Not  Available"
            Else
                txtOperator_name.Text = rdrtemp("operator_code") & ""

            End If

        Catch exp As SqlException
            strSql = exp.StackTrace
            Message.Text = "Line : " & Mid(strSql, InStr(strSql, "line") + 5) & " Message : " + exp.Message

        Catch exp As Exception
            strSql = exp.StackTrace
            Message.Text = "Line : " & Mid(strSql, InStr(strSql, "line") + 5) & " Message : " + exp.Message
        End Try

    End Sub

    Private Sub grdDrawFurnace_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdDrawFurnace.PageIndexChanged
        grdDrawFurnace.CurrentPageIndex = e.NewPageIndex
        Dim sqlstr3 As String
        sqlstr3 = "select loading_date,shift_code,SIC,operator_code,wheel_number,heat_number,hanger_no,df_in_time,df_out_time,cycle_time,whltmp_charging_hub,whltmp_charging_rim,whltmp_discharging_hub,whltmp_discharging_rim,ht_status,hc_duration,hc1_status,hc2_status,hc3_status,remarks from mm_draw_furnace_details where loading_date='" & Format(CDate(txtNF_date.Text), "MM/dd/yyyy") & "'"
        Call BindDataGrid(sqlstr3)
    End Sub

    Private Sub dg_wheel_normalising_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dg_wheel_normalising.PageIndexChanged
        dg_wheel_normalising.CurrentPageIndex = e.NewPageIndex
        Dim sqlstr3 As String
        sqlstr3 = "select HeatNo,WheelNo,SIC,OP1,OP2,PedNo,TempRQ,PedPosition,TimeIn,TimeOut,Quencher,remarks,SlNo from mm_WheelNormalising where LEFT(TimeIn,11)='" & Format(CDate(txtNF_date.Text), "MM/dd/yyyy") & "'"
        Call BindDataGrid(sqlstr3)
    End Sub

    Private Sub SetFocus(ByVal ctrl As Control)
        Dim focusScript As String = "<script language=" & "javascript" & " > " &
        "document.getElementById('" + ctrl.ClientID.ToString.Trim &
        "').focus();</script>"
        ClientScript.RegisterStartupScript(GetType(DrawfurnaceDetails), "FocusScript", focusScript)
    End Sub

    Private Sub txtHeat_number_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHeat_number.TextChanged

        Message.Text = ""
        If Val(txtHeat_number.Text) > 0 Then
            If Val(txtWheel_number.Text) > 0 Then
                CheckWheel()
            Else

                SetFocus(txtWheel_number)
            End If
        Else
            SetFocus(txtWheel_number)
        End If


        'If strmode = "edit" Or strmode = "delete" Or strmode = "view" Then
        '    Call fillNFData()
        '    Dim sqlstr3 As String
        '    sqlstr3 = "select wheel_number,hanger_no,df_in_time,df_out_time,offload_code,whltmp_charging_hub,whltmp_charging_rim,whltmp_discharging_hub,whltmp_discharging_rim,hc_duration,hc1_status,hc2_status,hc3_status,remarks from mm_draw_furnace_details where loading_date='" & Format(CDate(txtNF_date.Text), "MM/dd/yyyy") & "' and shift_code='" & cboShift.SelectedItem.Text & "' and heat_number='" & txtHeat_number.Text & "'"
        '    Call BindDataGrid(sqlstr3)
        'End If
    End Sub

    Protected Sub txtWheel_number_TextChanged(sender As Object, e As EventArgs) Handles txtWheel_number.TextChanged
        Message.Text = ""
        If Val(txtWheel_number.Text) > 0 Then
            If Val(txtHeat_number.Text) > 0 Then
                CheckWheel()
            Else

                SetFocus(txtHeat_number)
            End If
        Else
            SetFocus(txtHeat_number)
        End If
    End Sub


    Private Sub CheckWheel()
        Try
            If RWF.MLDING.CheckWheel(Val(txtWheel_number.Text), Val(txtHeat_number.Text)) Then
                Message.Text = ""
                ' GetWheelData()
                SetFocus(txtOperator_name)
            Else
                Message.Text = "InValid Wheel/Heat Number !"
            End If
        Catch exp As Exception
            Message.Text = exp.Message
        End Try
    End Sub

    Private Sub cboShift_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboShift.SelectedIndexChanged
        Dim sqlstr3 As String
        sqlstr3 = "select loading_date,shift_code,SIC,operator_code,wheel_number,heat_number,hanger_no,df_in_time,df_out_time,cycle_time,whltmp_charging_hub,whltmp_charging_rim,whltmp_discharging_hub,whltmp_discharging_rim,ht_status,hc_duration,hc1_status,hc2_status,hc3_status,remarks from mm_draw_furnace_details where loading_date='" & Format(CDate(txtNF_date.Text), "MM/dd/yyyy") & "' and shift_code='" & cboShift.SelectedItem.Text & "'"
        Call BindDataGrid(sqlstr3)
    End Sub

    Protected Sub txtNF_date_TextChanged(sender As Object, e As EventArgs) Handles txtNF_date.TextChanged
        Try
            If CDate(txtNF_date.Text) > Now Then
                Message.Text = "Entered date cannot be greater than today"
                txtNF_date.Text = ""
                Exit Sub
            End If

        Catch
            Message.Text = "Enter date in 'dd-mm-yyyy' Format"
            txtNF_date.Text = ""
        End Try
        Dim sqlstr3 As String
        sqlstr3 = "select loading_date,shift_code,SIC,operator_code,wheel_number,heat_number,hanger_no,df_in_time,df_out_time,cycle_time,whltmp_charging_hub,whltmp_charging_rim,whltmp_discharging_hub,whltmp_discharging_rim,ht_status,hc_duration,hc1_status,hc2_status,hc3_status,remarks from mm_draw_furnace_details where loading_date='" & Format(CDate(txtNF_date.Text), "MM/dd/yyyy") & "'"
        Call BindDataGrid(sqlstr3)
        Dim sqlstr6 As String
        sqlstr6 = "select SlNo,HeatNo,WheelNo,SIC,OP1,OP2,PedNo,TempRQ,PedPosition,TimeIn,TimeOut,Quencher,remarks from mm_WheelNormalising where LEFT(TimeIn,10)=(select LEFT(loading_date,10) from mm_draw_furnace_details where loading_date='" & Format(CDate(txtNF_date.Text), "MM/dd/yyyy") & "')"
        Call BindDataGrid1(sqlstr6)
    End Sub

    Protected Sub cycle_time_TextChanged(sender As Object, e As EventArgs) Handles cycle_time.TextChanged

    End Sub

    Protected Sub txtdfout_time_TextChanged(sender As Object, e As EventArgs) Handles txtdfout_time.TextChanged
        Try
            Dim time_in As DateTime
            Dim time_out As DateTime
            time_in = txtdfin_time.Text
            time_out = txtdfout_time.Text
            Dim span3 As TimeSpan = time_out.Subtract(time_in)
            cycle_time.Text = Convert.ToString(span3)
        Catch ee As Exception
            Message.Text = ee.Message
        End Try
    End Sub

    Protected Sub hc1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles hc1.SelectedIndexChanged
        If (hc1.SelectedItem.Value = "ok" And hc2.SelectedItem.Value = "ok" And hc3.SelectedItem.Value = "ok") Then
            hc_duration.Text = "120"
        ElseIf ((hc1.SelectedItem.Value = "ok" And hc2.SelectedItem.Value = "ok" And hc3.SelectedItem.Value = "not ok") Or (hc1.SelectedItem.Value = "ok" And hc2.SelectedItem.Value = "not ok" And hc3.SelectedItem.Value = "ok") Or (hc1.SelectedItem.Value = "not ok" And hc2.SelectedItem.Value = "ok" And hc3.SelectedItem.Value = "ok")) Then
            hc_duration.Text = "80"
        ElseIf ((hc1.SelectedItem.Value = "ok" And hc2.SelectedItem.Value = "not ok" And hc3.SelectedItem.Value = "not ok") Or (hc1.SelectedItem.Value = "not ok" And hc2.SelectedItem.Value = "not ok" And hc3.SelectedItem.Value = "ok") Or (hc1.SelectedItem.Value = "not ok" And hc2.SelectedItem.Value = "ok" And hc3.SelectedItem.Value = "not ok")) Then
            hc_duration.Text = "40"
        Else
            hc_duration.Text = "0"
        End If
    End Sub

    Protected Sub hc2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles hc2.SelectedIndexChanged
        If (hc1.SelectedItem.Value = "ok" And hc2.SelectedItem.Value = "ok" And hc3.SelectedItem.Value = "ok") Then
            hc_duration.Text = "120"
        ElseIf ((hc1.SelectedItem.Value = "ok" And hc2.SelectedItem.Value = "ok" And hc3.SelectedItem.Value = "not ok") Or (hc1.SelectedItem.Value = "ok" And hc2.SelectedItem.Value = "not ok" And hc3.SelectedItem.Value = "ok") Or (hc1.SelectedItem.Value = "not ok" And hc2.SelectedItem.Value = "ok" And hc3.SelectedItem.Value = "ok")) Then
            hc_duration.Text = "80"
        ElseIf ((hc1.SelectedItem.Value = "ok" And hc2.SelectedItem.Value = "not ok" And hc3.SelectedItem.Value = "not ok") Or (hc1.SelectedItem.Value = "not ok" And hc2.SelectedItem.Value = "not ok" And hc3.SelectedItem.Value = "ok") Or (hc1.SelectedItem.Value = "not ok" And hc2.SelectedItem.Value = "ok" And hc3.SelectedItem.Value = "not ok")) Then
            hc_duration.Text = "40"
        Else
            hc_duration.Text = "0"
        End If
    End Sub

    Protected Sub hc3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles hc3.SelectedIndexChanged
        If (hc1.SelectedItem.Value = "ok" And hc2.SelectedItem.Value = "ok" And hc3.SelectedItem.Value = "ok") Then
            hc_duration.Text = "120"
        ElseIf ((hc1.SelectedItem.Value = "ok" And hc2.SelectedItem.Value = "ok" And hc3.SelectedItem.Value = "not ok") Or (hc1.SelectedItem.Value = "ok" And hc2.SelectedItem.Value = "not ok" And hc3.SelectedItem.Value = "ok") Or (hc1.SelectedItem.Value = "not ok" And hc2.SelectedItem.Value = "ok" And hc3.SelectedItem.Value = "ok")) Then
            hc_duration.Text = "80"
        ElseIf ((hc1.SelectedItem.Value = "ok" And hc2.SelectedItem.Value = "not ok" And hc3.SelectedItem.Value = "not ok") Or (hc1.SelectedItem.Value = "not ok" And hc2.SelectedItem.Value = "not ok" And hc3.SelectedItem.Value = "ok") Or (hc1.SelectedItem.Value = "not ok" And hc2.SelectedItem.Value = "ok" And hc3.SelectedItem.Value = "not ok")) Then
            hc_duration.Text = "40"
        Else
            hc_duration.Text = "0"
        End If
    End Sub

    Protected Sub grdDrawFurnace_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdDrawFurnace.ItemCommand

        i = e.Item.ItemIndex()
    End Sub

    Protected Sub grdDrawFurnace_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdDrawFurnace.SelectedIndexChanged
        grdDrawFurnace.SelectedIndex = i
        txtHeat_number.Text = Trim(grdDrawFurnace.Items(i).Cells(5).Text)
        txtWheel_number.Text = Trim(grdDrawFurnace.Items(i).Cells(6).Text)

    End Sub


    Protected Sub dg_wheel_normalising_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dg_wheel_normalising.ItemCommand

        n = e.Item.ItemIndex()
    End Sub

    Protected Sub dg_wheel_normalising_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dg_wheel_normalising.SelectedIndexChanged
        dg_wheel_normalising.SelectedIndex = n
        txtHeat_number.Text = Trim(dg_wheel_normalising.Items(n).Cells(2).Text)
        txtWheel_number.Text = Trim(dg_wheel_normalising.Items(n).Cells(3).Text)

    End Sub


End Class