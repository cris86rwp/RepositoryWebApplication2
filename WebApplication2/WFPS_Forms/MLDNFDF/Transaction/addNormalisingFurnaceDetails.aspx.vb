Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports System.DateTime

Public Class addNormalisingFurnaceDetails
    Inherits System.Web.UI.Page
    Protected WithEvents txtNF_date As System.Web.UI.WebControls.TextBox
    Protected WithEvents txt_sic As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboShift As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddl_pedestral_number As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddl_quencher_number As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtHeat_number As System.Web.UI.WebControls.TextBox
    Protected WithEvents grdNormalizingFurnace As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dg_wheel_details As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtWheel_number As System.Web.UI.WebControls.TextBox
    'Protected WithEvents txtPedestral_number As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTime_in As System.Web.UI.WebControls.TextBox
    'Protected WithEvents txtQuencher_number As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents Message As System.Web.UI.WebControls.Label
    Protected WithEvents btnClear As System.Web.UI.WebControls.Button
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents txtOperator_name As System.Web.UI.WebControls.TextBox
    Protected WithEvents lbl_srbit As System.Web.UI.WebControls.Label
    Protected WithEvents lbl_wheelsrno As System.Web.UI.WebControls.Label
    Private strmode As String
    Private sqlStr As String
    Dim strSql As String
    Private DS As DataSet
    Private cmd As SqlDataAdapter
    Private sqlStr1 As String
    Private sqlStr2 As String
    Private sqlStr3 As String
    Private rdrtemp As SqlDataReader
    Protected WithEvents txtwhltmp_at_rq As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtwhlouttemp_aft_nf As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtcycletime As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTime_out As System.Web.UI.WebControls.TextBox

    Protected WithEvents btnExit As System.Web.UI.WebControls.Button
    Protected WithEvents lblMode As System.Web.UI.WebControls.Label
    Public con As New SqlConnection(ConfigurationManager.AppSettings("con"))
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents offloadcodelist As System.Web.UI.WebControls.DropDownList
    Dim i As Integer
    Dim n As Integer

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region
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


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load



        strmode = "add"



        If Page.IsPostBack = True Then

            Select Case strmode
                Case "add"


                Case "edit"
                    grdNormalizingFurnace.Columns(7).Visible = True
                    grdNormalizingFurnace.Columns(8).Visible = False

                Case "view"
                    grdNormalizingFurnace.Columns(7).Visible = False
                    grdNormalizingFurnace.Columns(8).Visible = False
                    btnExit.Visible = False
                    btnSave.Visible = False
                    btnClear.Visible = False
                Case "delete"
                    grdNormalizingFurnace.Columns(7).Visible = False
                    grdNormalizingFurnace.Columns(8).Visible = True
                    btnSave.Text = "Delete All"
                    Message.Text = "Carefull while using delete all button "
            End Select
        End If

        lbl_srbit.Text = getsrbit()
        Dim srno As Integer
        Dim done As Boolean
        Dim done1 As Boolean
        done1 = check_srno()
        If done1 = True Then
            srno = getsrno()
            srno = srno + 1
        ElseIf done1 = False Then
            srno = 1
        End If


        ' getheat_wheel(srno)
        done = checkheat_wheel(srno)


        If done = True Then
            getheat_wheel(srno)
        ElseIf done = False Then
            Dim tmp As Integer
            tmp = getsrbit()

            lbl_srbit.Text = tmp + 1

            srno = 1

            getheat_wheel(srno)
        End If


    End Sub
    Private Function checkheat_wheel(ByVal srno As Integer)
        Dim srbit As Integer = lbl_srbit.Text



        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.CommandText = "select heat_number,wheel_number from mm_nf_loading where wheel_sr_no=@srno and srbit=@srbit"
        cmd.Parameters.AddWithValue("@srno", srno)
        cmd.Parameters.AddWithValue("@srbit", srbit)
        Try
            cmd.Connection.Open()

            Dim done As Boolean = cmd.ExecuteScalar()
            Return done

        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally

            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()

            cmd.Dispose()
            cmd = Nothing

        End Try

    End Function


    Private Function getsrbit()

        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.CommandText = "select top 1 srbit from mm_normalizing_furnace_loading order by srbit desc"


        Try
            cmd.Connection.Open()

            Dim srbit As Integer = cmd.ExecuteScalar()

            Return srbit


        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally

            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing

        End Try
    End Function
    Private Sub grdNormalizingFurnace_EditCommand(ByVal source As Object, ByVal objArgs As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdNormalizingFurnace.EditCommand
        If strmode = "edit" Then
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            Dim strSql As String
            Message.Text = ""
            grdNormalizingFurnace.EditItemIndex = objArgs.Item.ItemIndex
            strSql = "select wheel_number,pedestral_number,charge_in_time,charge_out_time,offload_code,quenched_number,remarks from mm_normalizing_furnace_loading where loading_date='" & Format(CDate(txtNF_date.Text), "MM/dd/yyyy") & "' and shift_code='" & cboShift.SelectedItem.Text & "' and heat_number='" & txtHeat_number.Text & "'"
            BindDataGrid(strSql)
        End If
    End Sub

    Private Sub grdNormalizingFurnace_UpdateCommand(ByVal source As Object, ByVal objArgs As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdNormalizingFurnace.UpdateCommand
        Dim pedestral_number, charge_in_time, charge_out_time, offload_code, quenched_number, remarks As TextBox
        Dim wheel_number As String
        Dim objCmd As SqlCommand
        Dim objDr As SqlDataReader

        If con.State = ConnectionState.Closed Then
            con.Open()
        End If
        Dim strUpdSql, strSql As String


        Try

            wheel_number = objArgs.Item.Cells(0).Text
            pedestral_number = objArgs.Item.Cells(1).Controls(0)
            charge_in_time = objArgs.Item.Cells(2).Controls(0)
            charge_out_time = objArgs.Item.Cells(3).Controls(0)
            offload_code = objArgs.Item.Cells(4).Controls(0)
            quenched_number = objArgs.Item.Cells(5).Controls(0)
            remarks = objArgs.Item.Cells(6).Controls(0)



            strUpdSql = "Update mm_normalizing_furnace_loading set pedestral_number='" & pedestral_number.Text & "',charge_in_time='" & Format(CDate(charge_in_time.Text), "MM/dd/yyyy HH:mm:ss") & "',charge_out_time='" & Format(CDate(charge_out_time.Text), "MM/dd/yyyy HH:mm:ss") & "',offload_code='" & offload_code.Text & "',quenched_number='" & quenched_number.Text & "',remarks='" & remarks.Text & "' where loading_date='" & Format(CDate(txtNF_date.Text), "MM/dd/yyyy") & "' and shift_code='" & cboShift.SelectedItem.Text & "' and heat_number='" & txtHeat_number.Text & "' and wheel_number='" & wheel_number & "'"



            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            objCmd = New SqlCommand()
            objCmd.CommandType = CommandType.Text
            objCmd.CommandText = strUpdSql
            objCmd.Connection = con
            objCmd.ExecuteNonQuery()
            strSql = "select wheel_number,pedestral_number,charge_in_time,charge_out_time,offload_code,quenched_number,remarks from mm_normalizing_furnace_loading where loading_date='" & Format(CDate(txtNF_date.Text), "MM/dd/yyyy") & "' and shift_code='" & cboShift.SelectedItem.Text & "' and heat_number='" & txtHeat_number.Text & "'"
            grdNormalizingFurnace.EditItemIndex = -1
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
    Private Sub grdNormalizingFurnace_CancelCommand(ByVal source As Object, ByVal objArgs As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdNormalizingFurnace.CancelCommand
        If con.State = ConnectionState.Closed Then
            con.Open()
        End If
        strSql = "select wheel_number,pedestral_number,charge_in_time,charge_out_time,offload_code,quenched_number,remarks from mm_normalizing_furnace_loading where loading_date='" & Format(CDate(txtNF_date.Text), "MM/dd/yyyy") & "' and shift_code='" & cboShift.SelectedItem.Text & "' and heat_number='" & txtHeat_number.Text & "'"
        grdNormalizingFurnace.EditItemIndex = -1
        BindDataGrid(strSql)
    End Sub

    Private Sub grdNormalizingFurnace_DeleteCommand(ByVal source As Object, ByVal objArgs As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdNormalizingFurnace.DeleteCommand
        If strmode = "delete" Then


            Dim strsql As String
            Dim cellwheel_number As String
            cellwheel_number = objArgs.Item.Cells(0).Text
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            strsql = "delete from mm_normalizing_furnace_loading where loading_date='" & Format(CDate(txtNF_date.Text), "MM/dd/yyyy") & "' and shift_code='" & cboShift.SelectedItem.Text & "' and heat_number='" & txtHeat_number.Text & "' and wheel_number='" & cellwheel_number & "'"
            SqlHelper.ExecuteNonQuery(con, CommandType.Text, strsql)
            Message.Text = "Record Deleted Sucessfully"
            strsql = "select wheel_number,pedestral_number,charge_in_time,charge_out_time,offload_code,quenched_number,remarks from mm_normalizing_furnace_loading where loading_date='" & Format(CDate(txtNF_date.Text), "MM/dd/yyyy") & "' and shift_code='" & cboShift.SelectedItem.Text & "' and heat_number='" & txtHeat_number.Text & "'"
            Call BindDataGrid(strsql)
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj


        If btnSave.Text = "Save" Then


            con.Open()

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            cmd.CommandText = "insert into mm_normalizing_furnace_loading(loading_date,shift_code,operator_code,wheel_number,heat_number,wheeltmp_at_rq,wheelouttmp_aft_nf,pedestral_number,charge_in_time,charge_out_time,cycle_time,offload_code,quenched_number,remarks,SIC,srbit,wheel_sr_no) values(@txtNF_date,@cboShift,@txtOperator_name,@txtWheel_number,@txtHeat_number,@txtwhltmp_at_rq,@txtwhlouttemp_aft_nf,@txtPedestral_number,@txtTime_in,@txtTime_out,@txtcycletime,@offloadlist,@txtQuencher_number,@txtRemarks,@sic,@srbit,@wheel_sr_no)"

            Try
                cmd.Parameters.AddWithValue("@txtNF_date", (CDate(txtNF_date.Text)))
                cmd.Parameters.AddWithValue("@cboShift", Trim(cboShift.SelectedItem.Text))
                cmd.Parameters.AddWithValue("@txtHeat_number", Val(Trim(txtHeat_number.Text)))
                cmd.Parameters.AddWithValue("@txtWheel_number", Trim(txtWheel_number.Text))
                cmd.Parameters.AddWithValue("@txtPedestral_number", Trim(ddl_pedestral_number.SelectedItem.Text))
                cmd.Parameters.AddWithValue("@txtTime_in", Trim(txtTime_in.Text))
                cmd.Parameters.AddWithValue("@txtTime_out", Trim(txtTime_out.Text))
                cmd.Parameters.AddWithValue("@txtOperator_name", Trim(txtOperator_name.Text))
                cmd.Parameters.AddWithValue("@txtQuencher_number", Trim(ddl_quencher_number.SelectedItem.Text))
                cmd.Parameters.AddWithValue("@txtRemarks", Trim(txtRemarks.Text))

                'sqlPara() = New SqlParameter("@txtOffload_code", Trim(txtOffload_code.Text))
                cmd.Parameters.AddWithValue("@txtwhltmp_at_rq", Trim(txtwhltmp_at_rq.Text))
                cmd.Parameters.AddWithValue("@txtwhlouttemp_aft_nf", Trim(txtwhlouttemp_aft_nf.Text))
                cmd.Parameters.AddWithValue("@txtcycletime", Trim(txtcycletime.Text))
                cmd.Parameters.AddWithValue("@offloadlist", Trim(offloadcodelist.SelectedItem.Text))
                cmd.Parameters.AddWithValue("@sic", Trim(txt_sic.Text))
                cmd.Parameters.AddWithValue("@srbit", Trim(lbl_srbit.Text))
                cmd.Parameters.AddWithValue("@wheel_sr_no", Trim(lbl_wheelsrno.Text))




                cmd.Connection.Open()

                cmd.ExecuteNonQuery()
                Message.Text = "Normalizing Details Added"


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
            cmd.Connection.Close()


            Dim sqlstr2 As String
            sqlstr2 = "select loading_date,shift_code,SIC,heat_number,wheel_number,pedestral_number,charge_in_time,charge_out_time,cycle_time,wheeltmp_at_rq,wheelouttmp_aft_nf,offload_code,quenched_number,remarks from mm_normalizing_furnace_loading where loading_date='" & Format(CDate(txtNF_date.Text), "MM/dd/yyyy") & "'"
            grdNormalizingFurnace.EditItemIndex = -1
            Call BindDataGrid(sqlstr2)

            lbl_srbit.Text = getsrbit()
            Dim srno As Integer
            Dim done As Boolean
            Dim done1 As Boolean
            done1 = check_srno()
            If done1 = True Then
                srno = getsrno()
                srno = srno + 1
            ElseIf done1 = False Then
                srno = 1
            End If

            done = checkheat_wheel(srno)

            If done = True Then
                getheat_wheel(srno)
            ElseIf done = False Then
                Dim tmp As Integer
                tmp = getsrbit()

                lbl_srbit.Text = tmp + 1

                srno = 1

                getheat_wheel(srno)
            End If





        Else
            Call update()


        End If



    End Sub
    Sub update()
        If btnSave.Text = "Update" Then

            Message.Text = ""

            Dim t1 As DateTime = CDate(txtNF_date.Text + " " & txtTime_in.Text)
            Dim t2 As DateTime = CDate(txtNF_date.Text + " " & txtTime_out.Text)

            'Declaring parameters and assigning for Normalising  table
            Dim sqlPara(11) As SqlParameter

            sqlPara(0) = New SqlParameter("@txtOperator_name", Trim(txtOperator_name.Text))
            sqlPara(1) = New SqlParameter("@txtPedestral_number", Trim(ddl_pedestral_number.SelectedItem.Text))
            sqlPara(2) = New SqlParameter("@txtQuencher_number", Trim(ddl_quencher_number.SelectedItem.Text))
            sqlPara(3) = New SqlParameter("@txtRemarks", Trim(txtRemarks.Text))
            sqlPara(4) = New SqlParameter("@txtTime_in", Trim(t1))
            sqlPara(5) = New SqlParameter("@txtTime_out", Trim(t2))
            sqlPara(6) = New SqlParameter("@txtwhltmp_at_rq", Trim(txtwhltmp_at_rq.Text))
            sqlPara(7) = New SqlParameter("@txtwhlouttemp_aft_nf", Trim(txtwhlouttemp_aft_nf.Text))
            sqlPara(8) = New SqlParameter("@txtcycletime", Trim(txtcycletime.Text))
            sqlPara(9) = New SqlParameter("@offloadlist", Trim(offloadcodelist.SelectedItem.Text))
            sqlPara(10) = New SqlParameter("@txtHeat_number", Val(Trim(txtHeat_number.Text)))
            sqlPara(11) = New SqlParameter("@txtWheel_number", Trim(txtWheel_number.Text))



            Try
                strSql = "update mm_normalizing_furnace_loading set heat_number=@txtHeat_number,wheel_number=@txtWheel_number,operator_code=@txtOperator_name,wheeltmp_at_rq=@txtwhltmp_at_rq,wheelouttmp_aft_nf=@txtwhlouttemp_aft_nf,pedestral_number=@txtPedestral_number,charge_in_time=@txtTime_in,charge_out_time=@txtTime_out,cycle_time=@txtcycletime,offload_code=@offloadlist,quenched_number=@txtQuencher_number,remarks=@txtRemarks where loading_date='" & Format(CDate(txtNF_date.Text), "MM/dd/yyyy") & "' and shift_code='" & cboShift.SelectedItem.Text & "'"


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
        sqlstr4 = "select loading_date,shift_code,SIC,heat_number,wheel_number,pedestral_number,charge_in_time,charge_out_time,cycle_time,wheeltmp_at_rq,wheelouttmp_aft_nf,offload_code,quenched_number,remarks from mm_normalizing_furnace_loading where loading_date='" & Format(CDate(txtNF_date.Text), "MM/dd/yyyy") & "'"
        grdNormalizingFurnace.EditItemIndex = -1
        Call BindDataGrid(sqlstr4)



    End Sub
    Public Function update_status()
        Dim srbit As Integer = Val(lbl_srbit.Text)
        Dim wheel_sr_no As Integer = Val(lbl_wheelsrno.Text)
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.CommandText = "update mm_nf_loading set status=done where srbit=@srbit and wheel_sr_no=@wheel_sr_no"
        cmd.Parameters.AddWithValue("@wheel_sr_no", wheel_sr_no)
        cmd.Parameters.AddWithValue("@srbit", srbit)
        Try
            cmd.Connection.Open()
            cmd.ExecuteNonQuery()

        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally

            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()

            cmd.Dispose()
            cmd = Nothing

        End Try
    End Function
    Sub clearform()

        ' txtOffload_code.Text = ""
        txtHeat_number.Text = ""
        txtOperator_name.Text = ""
        ddl_pedestral_number.SelectedIndex = 0
        ddl_quencher_number.SelectedIndex = 0
        txtRemarks.Text = ""
        txtTime_in.Text = ""
        txtTime_out.Text = ""
        txtWheel_number.Text = ""
        cboShift.SelectedIndex = 0
        txtcycletime.Text = ""
        txtwhltmp_at_rq.Text = ""
        txtwhlouttemp_aft_nf.Text = ""
        offloadcodelist.SelectedIndex = 0
        txt_sic.Text = ""

    End Sub
    Sub fillNFData()
        Dim rdrtemp As SqlDataReader
        Dim sqlstr As String
        If con.State = ConnectionState.Closed Then
            con.Open()
        End If
        Try
            sqlstr = "select operator_code from  mm_normalizing_furnace_loading where loading_date='" & Format(CDate(txtNF_date.Text), "MM/dd/yyyy") & "' and shift_code='" & cboShift.SelectedItem.Text & "' and heat_number='" & txtHeat_number.Text & "'"
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
            grdNormalizingFurnace.DataSource = arr
            grdNormalizingFurnace.DataBind()
            grdNormalizingFurnace.DataSource = objDr
            grdNormalizingFurnace.DataBind()
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
            dg_wheel_details.DataSource = arr
            dg_wheel_details.DataBind()
            dg_wheel_details.DataSource = objDr
            dg_wheel_details.DataBind()
        Catch exp As SqlException
            strSql = exp.StackTrace
            Message.Text = "Line : " & Mid(strSql, InStr(strSql, "line") + 5) & " Message : " + exp.Message

        Catch exp As Exception
            strSql = exp.StackTrace
            Message.Text = "Line : " & Mid(strSql, InStr(strSql, "line") + 5) & " Message : " + exp.Message
        End Try

        con.Close()

    End Sub


    Private Sub SetFocus(ByVal ctrl As Control)
        Dim focusScript As String = "<script language=" & "javascript" & " > " &
        "document.getElementById('" + ctrl.ClientID.ToString.Trim &
        "').focus();</script>"
        ClientScript.RegisterStartupScript(GetType(addNormalisingFurnaceDetails), "FocusScript", focusScript)
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
        Dim sqlstr6 As String
        sqlstr6 = "select pour_order,heat_number,wheel_number,description from mm_wheel where heat_number='" & txtHeat_number.Text & "' order by pour_order"
        Call BindDataGrid1(sqlstr6)

    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("selectModule.aspx")
    End Sub



    Protected Sub txtTime_out_TextChanged(sender As Object, e As EventArgs) Handles txtTime_out.TextChanged

        Try
            Dim time_in As DateTime
            Dim time_out As DateTime
            time_in = txtTime_in.Text
            time_out = txtTime_out.Text
            Dim span3 As TimeSpan = time_out.Subtract(time_in)
            txtcycletime.Text = Convert.ToString(span3)



        Catch
            Message.Text = "Invalid Time"
        End Try
    End Sub

    Protected Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Call clearform()
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
        sqlstr3 = "select loading_date,shift_code,SIC,heat_number,wheel_number,pedestral_number,charge_in_time,charge_out_time,cycle_time,wheeltmp_at_rq,wheelouttmp_aft_nf,offload_code,quenched_number,remarks from mm_normalizing_furnace_loading where loading_date='" & Format(CDate(txtNF_date.Text), "MM/dd/yyyy") & "' and shift_code='" & cboShift.SelectedItem.Text & "'"
        Call BindDataGrid(sqlstr3)
    End Sub




    Private Sub grdNormalizingFurnace_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdNormalizingFurnace.PageIndexChanged
        grdNormalizingFurnace.CurrentPageIndex = e.NewPageIndex
        Dim sqlstr3 As String
        sqlstr3 = "select loading_date,shift_code,SIC,heat_number,wheel_number,pedestral_number,charge_in_time,charge_out_time,cycle_time,wheeltmp_at_rq,wheelouttmp_aft_nf,offload_code,quenched_number,remarks from mm_normalizing_furnace_loading where loading_date='" & Format(CDate(txtNF_date.Text), "MM/dd/yyyy") & "'"
        Call BindDataGrid(sqlstr3)
    End Sub

    Private Sub dg_wheel_details_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dg_wheel_details.PageIndexChanged
        dg_wheel_details.CurrentPageIndex = e.NewPageIndex
        Dim sqlstr3 As String
        sqlstr3 = " select pour_order,heat_number,wheel_number,decription from mm_wheel where heat_number='" & txtHeat_number.Text & "' order by pour_order"
        Call BindDataGrid1(sqlstr3)
    End Sub

    Protected Sub txtNF_date_TextChanged(sender As Object, e As EventArgs) Handles txtNF_date.TextChanged
        Try
            If CDate(txtNF_date.Text) > Now Then
                Message.Text = "Entered date cannot be greater than today"
                'txtNF_date.Text = ""
                Exit Sub
            End If
            If strmode = "edit" Or strmode = "delete" Or strmode = "view" Then
                Call fillNFData()

            End If



        Catch

        End Try
        Dim sqlstr3 As String
        sqlstr3 = "select loading_date,shift_code,SIC,heat_number,wheel_number,pedestral_number,charge_in_time,charge_out_time,cycle_time,wheeltmp_at_rq,wheelouttmp_aft_nf,offload_code,quenched_number,remarks from mm_normalizing_furnace_loading where loading_date='" & Format(CDate(txtNF_date.Text), "MM/dd/yyyy") & "'"
        Call BindDataGrid(sqlstr3)
    End Sub

    Protected Sub grdNormalizingFurnace_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdNormalizingFurnace.ItemCommand

        i = e.Item.ItemIndex()
    End Sub


    Protected Sub grdNormalizingFurnace_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdNormalizingFurnace.SelectedIndexChanged
        grdNormalizingFurnace.SelectedIndex = i
        txtHeat_number.Text = Trim(grdNormalizingFurnace.Items(i).Cells(4).Text)
        txtWheel_number.Text = Trim(grdNormalizingFurnace.Items(i).Cells(5).Text)

    End Sub

    Protected Sub dg_wheel_details_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dg_wheel_details.ItemCommand

        n = e.Item.ItemIndex()
    End Sub
    Protected Sub dg_wheel_details_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dg_wheel_details.SelectedIndexChanged
        dg_wheel_details.SelectedIndex = n
        txtHeat_number.Text = Trim(dg_wheel_details.Items(n).Cells(2).Text)
        txtWheel_number.Text = Trim(dg_wheel_details.Items(n).Cells(3).Text)

    End Sub

    Protected Sub txt_sic_TextChanged(sender As Object, e As EventArgs) Handles txt_sic.TextChanged
        txt_sic.Text = txt_sic.Text.ToUpper()
    End Sub

    Public Sub getheat_wheel(ByVal srno As Integer)


        Dim srbit As Integer = lbl_srbit.Text




        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.CommandText = "select wheel_sr_no,heat_number,wheel_number from mm_nf_loading where wheel_sr_no=@srno and srbit=@srbit"
        cmd.Parameters.AddWithValue("@srno", srno)
        cmd.Parameters.AddWithValue("@srbit", srbit)
        Try
            cmd.Connection.Open()

            Using sdr As SqlDataReader = cmd.ExecuteReader()
                sdr.Read()
                txtHeat_number.Text = sdr("heat_number").ToString()
                txtWheel_number.Text = sdr("wheel_number").ToString()
                lbl_wheelsrno.Text = sdr("wheel_sr_no").ToString()
            End Using
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally

            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()

            cmd.Dispose()
            cmd = Nothing

        End Try
    End Sub


    Public Function check_srno()
        Dim srbit As Integer = lbl_srbit.Text

        Dim done As Boolean
        Dim cmd1 As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd1.CommandText = "select count(wheel_sr_no) from mm_normalizing_furnace_loading where srbit=@srbit"
        cmd1.Parameters.AddWithValue("@srbit", srbit)







        Try
            cmd1.Connection.Open()

            Dim count As Integer = cmd1.ExecuteScalar()

            If count > 0 Then
                done = True


            Else done = False
            End If
            Return done
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally


            If cmd1.Connection.State = ConnectionState.Open Then cmd1.Connection.Close()
            cmd1.Dispose()
            cmd1 = Nothing

        End Try
    End Function
    Public Function getsrno()
        Dim srbit As Integer = lbl_srbit.Text
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        ' cmd.CommandText = "select top 1 wheel_sr_no from mm_normalizing_furnace_loading where srbit=@srbit order by wheel_sr_no desc"
        cmd.CommandText = "Select top 1 wheel_sr_no from mm_normalizing_furnace_loading  order by srbit desc,wheel_sr_no desc"
        cmd.Parameters.AddWithValue("@srbit", srbit)

        Try
            cmd.Connection.Open()

            Dim srno As Integer = cmd.ExecuteScalar()

            Return srno


        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally

            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing

        End Try
    End Function
End Class
