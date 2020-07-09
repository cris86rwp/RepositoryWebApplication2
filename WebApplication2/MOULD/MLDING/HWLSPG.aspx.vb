Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports System.Data
Imports System.DateTime

Public Class HWLSPG
    Inherits System.Web.UI.Page
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtSSEJE As System.Web.UI.WebControls.TextBox
    Protected WithEvents TxtMCOperator As System.Web.UI.WebControls.TextBox
    Protected WithEvents TxtMCOperator1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents TxtSPG1Oper As System.Web.UI.WebControls.TextBox
    Protected WithEvents TxtSPG2Oper As System.Web.UI.WebControls.TextBox
    Protected WithEvents TxtSPG3Oper As System.Web.UI.WebControls.TextBox
    Protected WithEvents TxtSPG4Oper As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtdate As System.Web.UI.WebControls.TextBox
    Protected WithEvents DDLshift As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtmould As System.Web.UI.WebControls.TextBox
    Protected WithEvents Txtheat_no As System.Web.UI.WebControls.TextBox
    Protected WithEvents Txtstart_time As System.Web.UI.WebControls.TextBox
    Protected WithEvents Txtfinish_time As System.Web.UI.WebControls.TextBox
    Protected WithEvents DropDownList1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Txttemp As System.Web.UI.WebControls.TextBox
    Protected WithEvents DDLheatmcno As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DDLheat_status As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DDLheatXC_code As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Txtheat_no1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Txtstrt_time As System.Web.UI.WebControls.TextBox
    Protected WithEvents Txtfin_time As System.Web.UI.WebControls.TextBox
    Protected WithEvents Txtwheel_no As System.Web.UI.WebControls.TextBox
    Protected WithEvents Txttmp As System.Web.UI.WebControls.TextBox
    Protected WithEvents DDLremcno As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DDLrestatus As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DDLrexccode As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DDLSPG As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Txtspgrindheat_no As System.Web.UI.WebControls.TextBox
    Protected WithEvents DDLgrindmc As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Txtspgrindwhl_no As System.Web.UI.WebControls.TextBox
    Protected WithEvents Txtgrind As System.Web.UI.WebControls.TextBox
    Protected WithEvents Txtspg1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Txtspg2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Txtspg3 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Txtspg4 As System.Web.UI.WebControls.TextBox
    Protected WithEvents DDLStpipe As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Txtstheatno As System.Web.UI.WebControls.TextBox
    Protected WithEvents Txtstwhlno As System.Web.UI.WebControls.TextBox
    Protected WithEvents Txtstpipe As System.Web.UI.WebControls.TextBox
    Protected WithEvents Txtremark As System.Web.UI.WebControls.TextBox
    Protected WithEvents Btnsave As System.Web.UI.WebControls.Button
    Protected WithEvents BtnSHeader As System.Web.UI.WebControls.Button
    Protected WithEvents Btnclear As System.Web.UI.WebControls.Button
    Protected WithEvents Btnexit As System.Web.UI.WebControls.Button
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents rbl1 As System.Web.UI.WebControls.RadioButtonList
    Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
    Dim i As Integer
    Dim strsql As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ' set dropdownlist selected based on text
            DDLStpipe.Items.FindByText("N").Selected = True
            DDLStpipe_SelectedIndexChanged(sender, e)
            DDLSPG.Items.FindByText("N").Selected = True
            DDLSPG_SelectedIndexChanged(sender, e)
        End If
        If Page.IsPostBack = False Then
            getDateShift()
            Try
                SetScreen()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
        GetHeatWoNo()
        DDLshift_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub SetScreen()
        Panel1.Visible = False
        Panel2.Visible = False
        Txtheat_no.Text = RWF.tables.GetLatestHeathotwheelline
        Txtspgrindheat_no.Text = RWF.tables.GetLatestHeathotwheellife
        Txtstheatno.Text = RWF.tables.GetLatestHeathotwheellife1
        GetHeatWoNo()
        lblMessage.Text = ""
        Getwheel2()
        Getwheel()
        Getwheel1()
        Try
            If rbl1.SelectedItem.Value = "heat" Then
                Panel1.Visible = True
                Panel2.Visible = False
                Panel5.Visible = False
                Panel4.Visible = False
                Panel7.Visible = False
                Label1.Text = ""
                Txtremark.Text = ""
            ElseIf rbl1.SelectedItem.Value = "rework" Then
                Panel1.Visible = False
                Panel2.Visible = True
                Panel6.Visible = False
                Panel4.Visible = False
                Panel7.Visible = False
                txtmould.Text = ""
                Label1.Text = ""
                Txtremark.Text = ""
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Public Function checks()
        Dim heatno As String
        Dim wheelno As String
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.Connection.Open()
        If (rbl1.SelectedItem.Value = "heat") Then
            heatno = Txtheat_no.Text
            wheelno = DropDownList1.SelectedValue
        ElseIf (rbl1.SelectedItem.Value = "rework") Then
            heatno = Txtheat_no1.Text
            wheelno = Txtwheel_no.Text
        End If
        cmd.CommandText = ("SELECT COUNT(*) FROM  mm_hotwheelline_spgnew where heatno=@heatno and wheel_no=@wheelno")
        cmd.Parameters.AddWithValue("@heatno", heatno)
        cmd.Parameters.AddWithValue("@wheelno", wheelno)
        Try
            Dim i As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            Return i
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing
        End Try
    End Function


    Public Function update1()
        Dim done As Boolean
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            cmd.Connection.Open()

            If (rbl1.SelectedItem.Value = "heat") Then
                Dim date1 As Date = Format(CDate(txtdate.Text))
                Dim ddl_shift As String = DDLshift.SelectedItem.Value
                Dim txt_heat As String = Txtheat_no.Text
                Dim wheel_no As String = DropDownList1.SelectedItem.Value
                Dim txt_temp As String = Txttemp.Text
                Dim ddl_heatmc As String = DDLheatmcno.SelectedItem.Value
                Dim ddl_heatstatus As String = DDLheat_status.SelectedItem.Value
                Dim ddl_heatxccode As String = DDLheatXC_code.SelectedItem.Value
                Dim txt_MCOperator As String = TxtMCOperator.Text
                Dim process_type1 As String = rbl1.SelectedValue

                cmd.CommandText = ("update mm_hotwheelline_spgnew set spg_temp=@txt_temp, spg_mc_no=@ddl_heatmc, spg_status=@ddl_heatstatus, spg_xc_code=@ddl_heatxccode, MCoperator=@txt_MCOperator where date=@date1 and heatno=@txt_heat and wheel_no=@wheel_no and shift=@ddl_shift and process_type=@process_type1")
                cmd.Parameters.AddWithValue("@date1", date1)
                cmd.Parameters.AddWithValue("@ddl_shift", ddl_shift)
                cmd.Parameters.AddWithValue("@txt_heat", txt_heat)
                cmd.Parameters.AddWithValue("@wheel_no", wheel_no)
                cmd.Parameters.AddWithValue("@txt_temp", txt_temp)
                cmd.Parameters.AddWithValue("@ddl_heatmc", ddl_heatmc)
                cmd.Parameters.AddWithValue("@ddl_heatstatus", ddl_heatstatus)
                cmd.Parameters.AddWithValue("@ddl_heatxccode", ddl_heatxccode)
                cmd.Parameters.AddWithValue("@txt_MCOperator", txt_MCOperator)
                cmd.Parameters.AddWithValue("@process_type1", process_type1)
                If cmd.ExecuteNonQuery() = 1 Then
                    done = True
                    lblMessage.Text = ""
                Else
                    'lblMessage.Text = "Please check date,shift,heatno and wheelno properly to update!!"
                    lblMessage.Text = "Please select header grid!!"
                    'lblMessage.Text = ""
                End If
            End If
        Catch exp As Exception
            Throw New Exception(exp.Message)
            'lblMessage.Text = "Please check date,shift,heatno and wheelno properly to update!!"
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing
        End Try
        Return done
    End Function

    Public Function update2()
        Dim done As Boolean
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            cmd.Connection.Open()

            If (rbl1.SelectedItem.Value = "rework") Then
                Dim txt_date As Date = Format(CDate(txtdate.Text))
                Dim ddl_shift As String = DDLshift.SelectedItem.Value
                Dim txt_heat1 As String = Txtheat_no1.Text
                Dim txt_wheel As String = Txtwheel_no.Text
                Dim txt_tmp As String = Txttmp.Text

                Dim ddl_remcno As String = DDLremcno.SelectedItem.Value
                Dim ddl_restatus As String = DDLrestatus.SelectedItem.Value
                Dim ddl_rexccode As String = DDLrexccode.SelectedItem.Value
                Dim txt_MCOperator1 As String = TxtMCOperator1.Text
                Dim process_type2 As String = rbl1.SelectedValue

                cmd.CommandText = ("update mm_hotwheelline_spgnew set spg_temp=@txt_tmp, spg_mc_no=@ddl_remcno, spg_status=@ddl_restatus, spg_xc_code=@ddl_rexccode, MCoperator=@txt_MCOperator1 where date=@txt_date and heatno=@txt_heat1 and wheel_no=@txt_wheel and shift=@ddl_shift and process_type=@process_type2")
                cmd.Parameters.AddWithValue("@txt_date", txt_date)
                cmd.Parameters.AddWithValue("@ddl_shift", ddl_shift)
                cmd.Parameters.AddWithValue("@txt_heat1", txt_heat1)
                cmd.Parameters.AddWithValue("@txt_wheel", txt_wheel)
                cmd.Parameters.AddWithValue("@txt_tmp", txt_tmp)
                cmd.Parameters.AddWithValue("@ddl_remcno", ddl_remcno)
                cmd.Parameters.AddWithValue("@ddl_restatus", ddl_restatus)
                cmd.Parameters.AddWithValue("@ddl_rexccode ", ddl_rexccode)
                cmd.Parameters.AddWithValue("@txt_MCOperator1", txt_MCOperator1)
                cmd.Parameters.AddWithValue("@process_type2", process_type2)
                If cmd.ExecuteNonQuery() = 1 Then
                    done = True
                Else
                    'lblMessage.Text = "Please check date,shift,heatno and wheelno properly to update!!"
                    lblMessage.Text = "Please select header grid!!"
                End If
            End If
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing
        End Try
        Return done
    End Function

    Protected Sub BtnSave_Click(sender As Object, e As EventArgs) Handles Btnsave.Click

        Dim Done As Boolean
        Dim Done2 As Boolean
        Dim Done1 As Boolean
        Dim Donne As Boolean
        Try
            'If rbl1.SelectedValue = "heat" Then
            If (rbl1.SelectedItem.Value = "heat" And DDLheatmcno.SelectedItem.Value <> "select") Then
                Dim n As Integer = checks()
                If n > 0 Then
                    Donne = update1()
                    If Donne Then
                        Label1.Text = "updated successfully in heat"
                        updateclear()
                    End If
                Else
                    Done = save()
                    Done1 = save1()
                    lblMessage.Text = ""
                    Panel7.Visible = True
                    show_data()
                    saveclear()
                End If

            ElseIf (rbl1.SelectedItem.Value = "rework" And DDLremcno.SelectedItem.Value <> "select") Then

                Dim n As Integer = checks()
                If n > 0 Then
                    Done2 = update2()
                    If Done2 Then
                        Label1.Text = "updated successfully in rework"
                        updateclear()
                    End If
                Else Done = save()
                    Done1 = save1()
                    Panel7.Visible = True
                    show_data1()

                End If
                If Done And Done1 Then
                    lblMessage.Text = " record saved !"
                    saveclear()
                End If
            End If
        Catch exp As Exception
            Label1.Text = exp.Message
        End Try
    End Sub

    Public Function updateclear()
        TxtMCOperator.Text = ""
        TxtMCOperator1.Text = ""
        txtmould.Text = ""
        Txtheat_no.Text = ""
        Txttemp.Text = ""
        Txtheat_no1.Text = ""
        Txtwheel_no.Text = ""
        Txttmp.Text = ""
        Txtspgrindheat_no.Text = ""
        Txtspg1.Text = ""
        Txtspg2.Text = ""
        Txtspg3.Text = ""
        Txtspg4.Text = ""
        Txtstheatno.Text = ""
        Txtstpipe.Text = ""
        Txtremark.Text = ""
    End Function

    Public Function saveclear()
        TxtMCOperator.Text = ""
        TxtMCOperator1.Text = ""
        txtmould.Text = ""
        Txttemp.Text = ""
        Txtheat_no1.Text = ""
        Txtwheel_no.Text = ""
        Txttmp.Text = ""
        Txtspgrindheat_no.Text = ""
        Txtspg1.Text = ""
        Txtspg2.Text = ""
        Txtspg3.Text = ""
        Txtspg4.Text = ""
        Txtstheatno.Text = ""
        Txtstpipe.Text = ""
        Txtremark.Text = ""
    End Function

    Public Function save()
        Dim done As Boolean
        Dim aa As Integer

        aa = Autogenerate_idd()
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            cmd.Connection.Open()

            If (rbl1.SelectedItem.Value = "heat") Then
                cmd.CommandText = "Insert INTO mm_hotwheelline_spgnew(date,shift,SSEJE,MCoperator,process_type,heatno,wheel_no,spg_temp,spg_mc_no,spg_status,spg_xc_code,remark)
                VALUES('" & Format(CDate(txtdate.Text), "MM/dd/yyyy") & "', '" & DDLshift.SelectedItem.Value & "' , '" & txtSSEJE.Text & "', '" & TxtMCOperator.Text & "','" & rbl1.SelectedItem.Value & "',
                '" & Txtheat_no.Text & "',  '" & DropDownList1.SelectedItem.Value & "','" & Txttemp.Text & "','" & DDLheatmcno.SelectedItem.Value & "', 
                '" & DDLheat_status.SelectedItem.Value & "', '" & DDLheatXC_code.SelectedItem.Value & "', '" & Txtremark.Text & "')"

                If cmd.ExecuteNonQuery() = 1 Then done = True

            ElseIf (rbl1.SelectedItem.Value = "rework") Then
                cmd.CommandText = "Insert INTO mm_hotwheelline_spgnew(date,shift,SSEJE,MCoperator,process_type,heatno,wheel_no,spg_temp,spg_mc_no,spg_status,spg_xc_code,remark)
                 VALUES ('" & Format(CDate(txtdate.Text), "MM/dd/yyyy") & "', '" & DDLshift.SelectedItem.Value & "' , '" & txtSSEJE.Text & "','" & TxtMCOperator1.Text & "', '" & rbl1.SelectedItem.Value & "',
                 '" & Txtheat_no1.Text & "', '" & Txtwheel_no.Text & "', '" & Txttmp.Text & "','" & DDLremcno.SelectedItem.Value & "', '" & DDLrestatus.SelectedItem.Value & "',
                 '" & DDLrexccode.SelectedItem.Value & "', '" & Txtremark.Text & "')"

                If cmd.ExecuteNonQuery() = 1 Then done = True
            End If
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing
        End Try
        DDLheatmcno.SelectedIndex = 0
        DDLremcno.SelectedIndex = 0
        Return done
    End Function

    Public Function save1()

        Dim done1 As Boolean
        Dim aa As Integer

        aa = Autogenerate_idd()
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.CommandText = "Insert INTO mm_hotwheellife(Date,process_type, SPG_grinding_wheel_replaced, SPG_heat_no, SPG_mc_no, SPG_wheel_no, SPG1, SPG2, SPG3, SPG4, Stopper_Pipe_Cutting_Wheels_replaced, ST_Pipe_heat_no, ST_Pipe_wheel_no, ST_Pipe_Cutting_Wheels_Life, ID)
         VALUES('" & Format(CDate(txtdate.Text), "MM/dd/yyyy") & "','" & rbl1.SelectedItem.Value & "','" & DDLSPG.SelectedItem.Value & "','" & Txtspgrindheat_no.Text & "',  '" & DDLgrindmc.SelectedItem.Value & "', '" & DropDownList2.SelectedItem.Value & "',  
             '" & Txtspg1.Text & "',  '" & Txtspg2.Text & "', '" & Txtspg3.Text & "', '" & Txtspg4.Text & "', '" & DDLStpipe.SelectedItem.Value & "', '" & Txtstheatno.Text & "', '" & DropDownList4.SelectedItem.Value & "',
                '" & Txtstpipe.Text & "','" & aa & "')"
        Try
            cmd.Connection.Open()
            If cmd.ExecuteNonQuery() = 1 Then done1 = True
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing
        End Try
        Return done1
    End Function

    Private Sub Autogenerate_id1()

        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.Connection.Open()
        Dim number As Integer
        cmd.CommandText = "Select TOP 1 SPG1 from mm_hotwheellife ORDER BY id DESC"
        cmd.CommandText = "Select Max(SPG1) from mm_hotwheellife "
        If IsDBNull(cmd.ExecuteScalar) Then
            number = 1
            Txtspg1.Text = number
        Else
            number = (cmd.ExecuteScalar) + 1
            Txtspg1.Text = number
        End If
        If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        cmd.Dispose()
        cmd.Connection.Dispose()
    End Sub

    Private Sub updatee_id()

        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.Connection.Open()
        Dim number1 As Integer
        cmd.CommandText = "update mm_hotwheellife set ST_Pipe_Cutting_Wheels_Life=0 where Stopper_Pipe_Cutting_Wheels_replaced='Y'"

        If IsDBNull(cmd.ExecuteScalar) Then
            number1 = -1
            Txtstpipe.Text = (number1)
        End If
        If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        cmd.Dispose()
        cmd.Connection.Dispose()
    End Sub

    Private Sub Autogenerate_id2()

        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.Connection.Open()
        Dim number As Integer
        cmd.CommandText = "Select TOP 1 SPG2 from mm_hotwheellife ORDER BY id DESC"
        cmd.CommandText = "Select Max(SPG2) from mm_hotwheellife "
        If IsDBNull(cmd.ExecuteScalar) Then
            number = 1
            Txtspg2.Text = (number)
        Else
            number = (cmd.ExecuteScalar) + 1
            Txtspg2.Text = number
        End If
        If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        cmd.Dispose()
        cmd.Connection.Dispose()
    End Sub

    Public Function Autogenerate_idd()
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.Connection.Open()
        Dim number As Integer
        cmd.CommandText = "Select Max(id) from mm_hotwheellife "
        If IsDBNull(cmd.ExecuteScalar) Then
            number = 1
            Return number
        Else
            number = (cmd.ExecuteScalar) + 1
            Return number
        End If
        If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        cmd.Dispose()
        cmd.Connection.Dispose()
    End Function

    Private Sub Autogenerate_id3()

        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.Connection.Open()
        Dim number As Integer
        cmd.CommandText = "Select TOP 1 SPG3 from mm_hotwheellife ORDER BY id DESC"
        cmd.CommandText = "Select Max(SPG3) from mm_hotwheellife "
        If IsDBNull(cmd.ExecuteScalar) Then
            number = 1
            Txtspg3.Text = (number)
        Else
            number = (cmd.ExecuteScalar) + 1
            Txtspg3.Text = number
        End If
        If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        cmd.Dispose()
        cmd.Connection.Dispose()
    End Sub

    Private Sub Autogenerate_id4()

        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.Connection.Open()
        Dim number As Integer
        cmd.CommandText = "Select TOP 1 SPG4 from mm_hotwheellife ORDER BY id DESC"
        cmd.CommandText = "Select Max(SPG4) from mm_hotwheellife "
        If IsDBNull(cmd.ExecuteScalar) Then
            number = 1
            Txtspg4.Text = (number)
        Else
            number = (cmd.ExecuteScalar) + 1
            Txtspg4.Text = number
        End If
        If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        cmd.Dispose()
        cmd.Connection.Dispose()
    End Sub

    Private Sub Autogenerate_id()

        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.Connection.Open()
        Dim number1 As Integer
        cmd.CommandText = "Select TOP 1 ST_Pipe_Cutting_Wheels_Life from mm_hotwheellife ORDER BY id DESC"
        If IsDBNull(cmd.ExecuteScalar) Then
            number1 = 0
            Txtstpipe.Text = (number1)
        Else
            number1 = (cmd.ExecuteScalar) + 1
            Txtstpipe.Text = number1
        End If
        If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        cmd.Dispose()
        cmd.Connection.Dispose()

    End Sub

    Protected Sub Btnclear_Click(sender As Object, e As EventArgs) Handles Btnclear.Click

        TxtMCOperator.Text = ""
        TxtMCOperator1.Text = ""
        txtmould.Text = ""
        Txtheat_no.Text = ""
        Txttemp.Text = ""
        Txtheat_no1.Text = ""
        Txtwheel_no.Text = ""
        Txttmp.Text = ""
        Txtspgrindheat_no.Text = ""
        Txtspg1.Text = ""
        Txtspg2.Text = ""
        Txtspg3.Text = ""
        Txtspg4.Text = ""
        Txtstheatno.Text = ""
        Txtstpipe.Text = ""
        Txtremark.Text = ""
        Label1.Text = ""

    End Sub

    Protected Sub DDLStpipe_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDLStpipe.SelectedIndexChanged

        If (DDLStpipe.SelectedItem.Value = "Y") Then
            Txtstpipe.Text = 0
            updatee_id()
        Else
            Autogenerate_id()
        End If

    End Sub

    Protected Sub Txtheat_no_TextChanged(sender As Object, e As EventArgs) Handles Txtheat_no.TextChanged
        GetHeatWoNo()
        Getwheel()
        Try
            lblMessage.Text = ""
            If Val(Txtheat_no.Text) > 0 Then
                If Val(DropDownList1.SelectedItem.Text) > 0 Then
                    CheckWheel()
                Else
                    SetFocus(DropDownList1)
                End If
            Else
                SetFocus(DropDownList1)
            End If
            If rbl1.SelectedValue = "heat" Then
                Dim str4 As String

                str4 = "select ROW_NUMBER() OVER(ORDER BY sl_no asc) AS sl_no,date,shift,process_type,heatno,wheel_no,spg_temp,spg_mc_no,spg_xc_code,spg_status,MCoperator from mm_hotwheelline_spgnew where heatno ='" & Txtheat_no.Text & "' and process_type='" & rbl1.SelectedValue & "' order by sl_no desc"
                Call BindDataGrid1(str4)

            End If
        Catch ee As Exception
            lblMessage.Text = "invalid heat no"
        End Try
    End Sub

    Protected Sub Txtheat_no1_TextChanged(sender As Object, e As EventArgs) Handles Txtheat_no1.TextChanged
        GetHeatWoNo1()
        Try
            lblMessage.Text = ""
            If Val(Txtheat_no1.Text) > 0 Then
                If Val(Txtwheel_no.Text) > 0 Then
                    CheckWheel()
                Else
                    SetFocus(Txtwheel_no)
                End If
            Else
                SetFocus(Txtwheel_no)
            End If
            If rbl1.SelectedValue = "rework" Then
                Dim str4 As String
                str4 = "select ROW_NUMBER() OVER(ORDER BY sl_no asc) AS sl_no,date,shift,process_type,heatno,wheel_no,spg_temp,spg_mc_no,spg_status,spg_xc_code,MCoperator from mm_hotwheelline_spgnew where heatno ='" & Txtheat_no1.Text & "' and process_type='" & rbl1.SelectedValue & "' order by sl_no desc "
                Call BindDataGrid1(str4)
            End If
        Catch ee As Exception
            lblMessage.Text = "invalid heat no"
        End Try
    End Sub

    Public Function GetHeatWoNo()
        Dim dt As New DataTable()
        dt = RWF.tables.getHeatWo(Val(Txtheat_no.Text))
        If dt.Rows.Count > 0 Then
            txtmould.Text = IIf(IsDBNull(dt.Rows(0)("number")), "", dt.Rows(0)("number"))
        Else
            txtmould.Text = ""
        End If
        dt = Nothing
        Return dt
    End Function

    Public Function GetHeatWoNo1()
        Dim dt As New DataTable()
        dt = RWF.tables.getHeatWo(Val(Txtheat_no1.Text))
        If dt.Rows.Count > 0 Then
            txtmould.Text = IIf(IsDBNull(dt.Rows(0)("number")), "", dt.Rows(0)("number"))
        Else
            txtmould.Text = ""
        End If
        dt = Nothing
        Return dt
    End Function

    Public Function Getwheel()
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            cmd.Connection.Open()
            Dim heat As Integer = Convert.ToInt64(Txtheat_no.Text)
            cmd.CommandText = "Select engraved_number from mm_pouring  where heat_number =@heat"
            cmd.Parameters.AddWithValue("@heat", heat)
            DropDownList1.DataSource = cmd.ExecuteReader()
            DropDownList1.DataTextField = "engraved_number"
            DropDownList1.DataBind()

        Catch exp As Exception
            Label1.Text = "please fill heat number!!"
        End Try
    End Function

    Public Function Getwheel1()

        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.Connection.Open()
        Try
            Dim heat As Integer = Convert.ToInt64(Txtspgrindheat_no.Text)
            cmd.CommandText = "Select engraved_number from mm_pouring  where heat_number =@heat"
            cmd.Parameters.AddWithValue("@heat", heat)
            DropDownList2.DataSource = cmd.ExecuteReader()
            DropDownList2.DataTextField = "engraved_number"
            DropDownList2.DataBind()
        Catch exp As Exception
            Label1.Text = "please fill heat number!!"
        End Try
    End Function

    Public Function Getwheel2()
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            cmd.Connection.Open()
            Dim heat As Integer = Convert.ToInt64(Txtstheatno.Text)
            cmd.CommandText = "Select engraved_number from mm_pouring  where heat_number =@heat"
            cmd.Parameters.AddWithValue("@heat", heat)
            DropDownList4.DataSource = cmd.ExecuteReader()
            DropDownList4.DataTextField = "engraved_number"
            DropDownList4.DataBind()

        Catch exp As Exception
            Label1.Text = "please fill heat number!!"
        End Try
    End Function

    Public Sub getDateShift()
        If Now.Hour = 0 OrElse Now.Hour = 1 OrElse Now.Hour = 2 OrElse Now.Hour = 3 OrElse Now.Hour = 4 OrElse Now.Hour = 5 Then
            txtdate.Text = CDate(Now.Date.AddDays(-1))
        Else
            txtdate.Text = CDate(Now.Date)
        End If
        Dim dt As Date
        Dim Shift As String
        dt = Now
        Select Case dt.Hour
            Case 6 To 13
                Shift = "A"
            Case 14 To 21
                Shift = "B"
            Case Else
                Shift = "C"
        End Select
        Dim i As Integer = 0
        DDLshift.ClearSelection()
        For i = 0 To DDLshift.Items.Count - 1
            If DDLshift.Items(i).Text = Shift Then
                DDLshift.Items(i).Selected = True
                Exit For
            End If
        Next
        dt = Nothing
        Shift = Nothing
        i = Nothing
    End Sub
    Protected Sub rbl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rbl1.SelectedIndexChanged
        SetScreen()
    End Sub
    Protected Sub DDLSPG_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDLSPG.SelectedIndexChanged

        If (DDLgrindmc.SelectedItem.Value = "1") Then
            If (DDLSPG.SelectedItem.Value = "Y") Then
                Txtspg1.Text = 0
                Txtspg2.Text = ""
                Txtspg3.Text = ""
                Txtspg4.Text = ""
            ElseIf (DDLSPG.SelectedItem.Value = "N") Then
                Autogenerate_id1()
            End If
        ElseIf (DDLgrindmc.SelectedItem.Value = "2") Then
            If (DDLSPG.SelectedItem.Value = "Y") Then
                Txtspg2.Text = 0
                Txtspg1.Text = ""
                Txtspg3.Text = ""
                Txtspg4.Text = ""
            ElseIf (DDLSPG.SelectedItem.Value = "N") Then
                Autogenerate_id2()
            End If
        ElseIf (DDLgrindmc.SelectedItem.Value = "3") Then
            If (DDLSPG.SelectedItem.Value = "Y") Then
                Txtspg3.Text = 0
                Txtspg1.Text = ""
                Txtspg2.Text = ""
                Txtspg4.Text = ""
            ElseIf (DDLSPG.SelectedItem.Value = "N") Then
                Autogenerate_id3()
            End If
        ElseIf (DDLgrindmc.SelectedItem.Value = "4") Then
            If (DDLSPG.SelectedItem.Value = "Y") Then
                Txtspg4.Text = 0
                Txtspg2.Text = ""
                Txtspg3.Text = ""
                Txtspg1.Text = ""
            ElseIf (DDLSPG.SelectedItem.Value = "N") Then
                Autogenerate_id4()
            End If
        End If
    End Sub

    Protected Sub DDLheat_status_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDLheat_status.SelectedIndexChanged
        If (DDLheat_status.SelectedItem.Value = "NOT OK") Then
            Panel5.Visible = True
        Else
            Panel5.Visible = False
            DDLheatXC_code.SelectedValue = ""

        End If
    End Sub

    Protected Sub DDLrestatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDLrestatus.SelectedIndexChanged
        If (DDLrestatus.SelectedItem.Value = "NOT OK") Then
            Panel6.Visible = True
        Else
            Panel6.Visible = False
            DDLrexccode.SelectedValue = ""
        End If
    End Sub

    Protected Sub DDLremcno_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDLremcno.SelectedIndexChanged
        If (DDLremcno.SelectedItem.Value = "1") Then
            Autogenerate_id1()
            TxtMCOperator1.Text = TxtSPG1Oper.Text
            Panel4.Visible = True
            Txtspg2.Text = ""
            Txtspg3.Text = ""
            Txtspg4.Text = ""
        ElseIf (DDLremcno.SelectedItem.Value = "2") Then
            Panel4.Visible = True
            Autogenerate_id2()
            TxtMCOperator1.Text = TxtSPG2Oper.Text
            Txtspg1.Text = ""
            Txtspg3.Text = ""
            Txtspg4.Text = ""
        ElseIf (DDLremcno.SelectedItem.Value = "3") Then
            Panel4.Visible = True
            Autogenerate_id3()
            TxtMCOperator1.Text = TxtSPG3Oper.Text
            Txtspg1.Text = ""
            Txtspg2.Text = ""
            Txtspg4.Text = ""
        ElseIf (DDLremcno.SelectedItem.Value = "4") Then
            Panel4.Visible = True
            Autogenerate_id4()
            TxtMCOperator1.Text = TxtSPG4Oper.Text
            Txtspg1.Text = ""
            Txtspg2.Text = ""
            Txtspg3.Text = ""
        Else
            Panel4.Visible = False
        End If
    End Sub

    Protected Sub DDLheatmcno_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDLheatmcno.SelectedIndexChanged
        DDLgrindmc.SelectedItem.Value = ""
        If (DDLheatmcno.SelectedItem.Value = "1") Then
            DDLSPG.SelectedItem.Value = "N"

            Panel4.Visible = True
            If (DDLSPG.SelectedItem.Value = "Y") Then
                Txtspg1.Text = 0
            ElseIf (DDLSPG.SelectedItem.Value = "N") Then
                TxtMCOperator.Text = TxtSPG1Oper.Text
                Autogenerate_id1()
                Txtspg2.Text = ""
                Txtspg3.Text = ""
                Txtspg4.Text = ""
            End If

        ElseIf (DDLheatmcno.SelectedItem.Value = "2") Then
            DDLSPG.SelectedItem.Value = "N"
            Panel4.Visible = True

            If (DDLSPG.SelectedItem.Value = "Y") Then
                Txtspg2.Text = 0
            ElseIf (DDLSPG.SelectedItem.Value = "N") Then
                TxtMCOperator.Text = TxtSPG2Oper.Text
                Autogenerate_id2()
                Txtspg1.Text = ""
                Txtspg3.Text = ""
                Txtspg4.Text = ""
            End If
        ElseIf (DDLheatmcno.SelectedItem.Value = "3") Then
            DDLSPG.SelectedItem.Value = "N"
            Panel4.Visible = True

            If (DDLSPG.SelectedItem.Value = "Y") Then
                Txtspg3.Text = 0
                'DDLSPG.ClearSelection()
            ElseIf (DDLSPG.SelectedItem.Value = "N") Then
                TxtMCOperator.Text = TxtSPG2Oper.Text
                Autogenerate_id3()
                Txtspg1.Text = ""
                Txtspg2.Text = ""
                Txtspg4.Text = ""
            End If
        ElseIf (DDLheatmcno.SelectedItem.Value = "4") Then
            DDLSPG.SelectedItem.Value = "N"
            Panel4.Visible = True
            If (DDLSPG.SelectedItem.Value = "Y") Then
                Txtspg4.Text = 0
            ElseIf (DDLSPG.SelectedItem.Value = "N") Then
                TxtMCOperator.Text = TxtSPG2Oper.Text
                Autogenerate_id4()
                Txtspg1.Text = ""
                Txtspg2.Text = ""
                Txtspg3.Text = ""
            End If
        Else
            Panel4.Visible = False
        End If
    End Sub

    Protected Sub Txtspgrindheat_no_TextChanged(sender As Object, e As EventArgs) Handles Txtspgrindheat_no.TextChanged
        Getwheel1()
    End Sub

    Protected Sub Txtstheatno_TextChanged(sender As Object, e As EventArgs) Handles Txtstheatno.TextChanged
        Getwheel2()
    End Sub

    Private Sub show_data()
        Try
            cmd.Connection.Open()
            cmd.CommandText = "select process_type,heatno,wheel_no,spg_temp,spg_mc_no,spg_status,spg_xc_code,MCoperator from mm_hotwheelline_spgnew where process_type='" & rbl1.SelectedItem.Value & "' and date='" & Format(CDate(txtdate.Text), "MM/dd/yyyy") & "'  and shift='" & DDLshift.SelectedItem.Value & "' "
            Using sda As New SqlDataAdapter()
                sda.SelectCommand = cmd
                Using dt As New DataSet()
                    sda.Fill(dt)
                    dg_insert.DataSource = dt
                    dg_insert.DataBind()
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            cmd.Connection.Close()
        End Try
    End Sub

    Private Sub show_data1()
        Try
            cmd.Connection.Open()
            cmd.CommandText = "select process_type,heatno,wheel_no,spg_temp,spg_mc_no,spg_status,spg_xc_code,MCoperator from mm_hotwheelline_spgnew where process_type='" & rbl1.SelectedItem.Value & "' and date='" & Format(CDate(txtdate.Text), "MM/dd/yyyy") & "'  and shift='" & DDLshift.SelectedItem.Value & "'"
            Using sda As New SqlDataAdapter()
                sda.SelectCommand = cmd
                Using dt As New DataSet()
                    sda.Fill(dt)
                    dg_insert.DataSource = dt
                    dg_insert.DataBind()
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            cmd.Connection.Close()
        End Try
    End Sub

    Protected Sub BtnSHeader_Click(sender As Object, e As EventArgs) Handles BtnSHeader.Click
        If BtnSHeader.Text = "SAVE DETAILS" Then
            cmd.Connection.Open()

            If cmd.Connection.State = ConnectionState.Closed Then
                cmd.Connection.Open()
            End If
            'Declaring parameters and assigning for Normalising  table
            Dim sqlPara(11) As SqlParameter
            sqlPara(0) = New SqlParameter("@Txtheat_no", Trim(Txtheat_no.Text))
            sqlPara(1) = New SqlParameter("@txtSSEJE", Trim(txtSSEJE.Text))
            sqlPara(2) = New SqlParameter("@txtmould", Trim(txtmould.Text))
            sqlPara(3) = New SqlParameter("@TxtSPG1Oper", Trim(TxtSPG1Oper.Text))
            sqlPara(4) = New SqlParameter("@TxtSPG2Oper", Trim(TxtSPG2Oper.Text))
            sqlPara(5) = New SqlParameter("@txtdate", Format(CDate(txtdate.Text), "MM/dd/yyyy"))
            sqlPara(6) = New SqlParameter("@TxtSPG3Oper", Trim(TxtSPG3Oper.Text))
            sqlPara(7) = New SqlParameter("@TxtSPG4Oper", Trim(TxtSPG4Oper.Text))
            sqlPara(8) = New SqlParameter("@Txtstart_time", Trim(Txtstart_time.Text))
            sqlPara(9) = New SqlParameter("@Txtfinish_time", Trim(Txtfinish_time.Text))
            sqlPara(10) = New SqlParameter("@DDLshift", Trim(DDLshift.SelectedItem.Value))
            sqlPara(11) = New SqlParameter("@Txtheat_no1", Trim(Txtheat_no1.Text))

            Dim sqlstr As String = "Insert INTO mm_HoTWheelLineHeader(Date,Shift,SSEJE,StartTime,FinishTime,heat_heatno,rework_heatno,Moulding_WO_No,SPG1Operator,SPG2Operator,SPG3Operator,SPG4Operator)  
          values("
            sqlstr &= "@txtdate,@DDLshift,@txtSSEJE,@Txtstart_time,@Txtfinish_time,@Txtheat_no,@Txtheat_no1,@txtmould,@TxtSPG1Oper,@TxtSPG2Oper,@TxtSPG3Oper,@TxtSPG4Oper)"
            Try
                If cmd.Connection.State = ConnectionState.Closed Then
                    cmd.Connection.Open()
                End If
                SqlHelper.ExecuteNonQuery(cmd.Connection, CommandType.Text, sqlstr, sqlPara)
                Label2.Text = "HoTWheelLineHeader Details Added"

            Catch exp As SqlException
                If exp.Number = 2627 Then
                    Label2.Text = "This Record Already exists"
                    BtnSHeader.Text = "Update"
                Else
                    strsql = exp.StackTrace
                    Label2.Text = "Line : " & Mid(strsql, InStr(strsql, "line") + 5) & " Message : " + exp.Message
                End If
            Catch exp As Exception
                strsql = exp.StackTrace
                Label2.Text = "Line : " & Mid(strsql, InStr(strsql, "line") + 5) & " Message : " + exp.Message
            End Try
            If cmd.Connection.State = ConnectionState.Closed Then
                cmd.Connection.Open()
            End If
        Else
            Call update()
        End If
    End Sub

    Sub update()
        If BtnSHeader.Text = "Update" Then

            Label2.Text = ""

            'Declaring parameters and assigning for Normalising  table
            Dim sqlPara(7) As SqlParameter

            sqlPara(0) = New SqlParameter("@txtSSEJE", Trim(txtSSEJE.Text))
            sqlPara(1) = New SqlParameter("@txtmould", Trim(txtmould.Text))
            sqlPara(2) = New SqlParameter("@TxtSPG1Oper", Trim(TxtSPG1Oper.Text))
            sqlPara(3) = New SqlParameter("@TxtSPG2Oper", Trim(TxtSPG2Oper.Text))
            sqlPara(4) = New SqlParameter("@TxtSPG3Oper", Trim(TxtSPG3Oper.Text))
            sqlPara(5) = New SqlParameter("@TxtSPG4Oper", Trim(TxtSPG4Oper.Text))
            sqlPara(6) = New SqlParameter("@Txtstart_time", Trim(Txtstart_time.Text))
            sqlPara(7) = New SqlParameter("@Txtfinish_time", Trim(Txtfinish_time.Text))

            Try
                strsql = "UPDATE mm_HoTWheelLineHeader SET SSEJE=@txtSSEJE,StartTime=@Txtstart_time,FinishTime=@Txtfinish_time,Moulding_WO_No=@txtmould,SPG1Operator=@TxtSPG1Oper,SPG2Operator=@TxtSPG2Oper,SPG3Operator=@TxtSPG3Oper,SPG4Operator=@TxtSPG4Oper WHERE Date ='" & Format(CDate(txtdate.Text), "MM/dd/yyyy") & "' AND  Shift = '" & DDLshift.SelectedItem.Value & "' "

                SqlHelper.ExecuteNonQuery(cmd.Connection, CommandType.Text, strsql, sqlPara)
                Label2.Text = "Updated Sucessfully"
                BtnSHeader.Text = "SAVE DETAILS"
                'Call clearform()


            Catch exp As SqlException
                strsql = exp.StackTrace
                Label2.Text = "Line : " & Mid(strsql, InStr(strsql, "line") + 5) & " Message : " + exp.Message

            Catch exp As Exception
                strsql = exp.StackTrace
                Label2.Text = "Line : " & Mid(strsql, InStr(strsql, "line") + 5) & " Message : " + exp.Message
            End Try
        End If

    End Sub
    Protected Sub txtSSEJE_TextChanged(sender As Object, e As EventArgs) Handles txtSSEJE.TextChanged
        txtSSEJE.Text = txtSSEJE.Text.ToUpper
    End Sub

    Private Sub SetFocus(ByVal ctrl As Control)
        Dim focusScript As String = "<script language=" & "javascript" & " > " &
       "document.getElementById('" + ctrl.ClientID.ToString.Trim &
       "').focus();</script>"
        ClientScript.RegisterStartupScript(GetType(HWLSPG), "FocusScript", focusScript)
    End Sub

    Protected Sub DDLshift_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDLshift.SelectedIndexChanged
        Dim sqlstr3 As String
        sqlstr3 = "select Date,Shift,SSEJE,StartTime,FinishTime,Moulding_WO_No,SPG1Operator,SPG2Operator,SPG3Operator,SPG4Operator from mm_HoTWheelLineHeader where Date='" & Format(CDate(txtdate.Text), "MM/dd/yyyy") & "'  and shift='" & DDLshift.SelectedItem.Value & "'"
        Call BindDataGrid(sqlstr3)
    End Sub

    Private Sub BindDataGrid(ByVal strArg As String)

        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Dim strsql As String
        Try
            cmd.Connection.Open()
            cmd = New SqlCommand(strArg, cmd.Connection)
            Dim objDr As SqlDataReader = cmd.ExecuteReader()
            Dim arr() As String
            dghotwheelineheader.DataSource = arr
            dghotwheelineheader.DataBind()
            dghotwheelineheader.DataSource = objDr
            dghotwheelineheader.DataBind()
        Catch exp As SqlException
            strsql = exp.StackTrace
            Label2.Text = "Line : " & Mid(strsql, InStr(strsql, "line") + 5) & " Message : " + exp.Message

        Catch exp As Exception
            strsql = exp.StackTrace
            Label2.Text = "Line : " & Mid(strsql, InStr(strsql, "line") + 5) & " Message : " + exp.Message

        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing
        End Try
    End Sub

    Private Sub BindDataGrid1(ByVal strArg As String)
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Dim strsql As String
        Try
            cmd.Connection.Open()
            cmd = New SqlCommand(strArg, cmd.Connection)
            Dim objDr1 As SqlDataReader = cmd.ExecuteReader()
            Dim arr1() As String
            grid1.DataSource = arr1
            grid1.DataBind()
            grid1.DataSource = objDr1
            grid1.DataBind()
        Catch exp As SqlException
            strsql = exp.StackTrace
            Label2.Text = "Line : " & Mid(strsql, InStr(strsql, "line") + 5) & " Message : " + exp.Message

        Catch exp As Exception
            strsql = exp.StackTrace
            Label2.Text = "Line : " & Mid(strsql, InStr(strsql, "line") + 5) & " Message : " + exp.Message

        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing
        End Try
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        Try
            lblMessage.Text = ""
            If Val(DropDownList1.SelectedItem.Value) > 0 Then
                If Val(Txtheat_no.Text) > 0 Then
                    CheckWheel()
                Else

                    SetFocus(Txtheat_no)
                End If
            Else
                SetFocus(Txtheat_no)
            End If
        Catch ee As Exception
            lblMessage.Text = "invalid wheel no"
        End Try
    End Sub

    Private Sub CheckWheel()
        Try
            If rbl1.SelectedItem.Value = "heat" Then

                If RWF.MLDING.CheckWheel(Val(DropDownList1.SelectedItem.Value), Val(Txtheat_no.Text)) Then
                    lblMessage.Text = ""
                    SetFocus(Txttemp)
                Else
                    lblMessage.Text = "InValid Wheel/Heat Number !"
                End If
            ElseIf rbl1.SelectedItem.Value = "rework" Then
                If RWF.MLDING.CheckWheel(Val(Txtwheel_no.Text), Val(Txtheat_no1.Text)) Then
                    lblMessage.Text = ""
                    SetFocus(Txttmp)
                Else
                    lblMessage.Text = "InValid Wheel/Heat Number !"
                End If
            End If

        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub dghotwheelineheader_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dghotwheelineheader.ItemCommand
        i = e.Item.ItemIndex()
    End Sub

    Protected Sub dghotwheelineheader_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dghotwheelineheader.SelectedIndexChanged
        dghotwheelineheader.SelectedIndex = i
        txtSSEJE.Text = Trim(dghotwheelineheader.Items(i).Cells(3).Text)
        Txtstart_time.Text = Trim(dghotwheelineheader.Items(i).Cells(4).Text).Substring(Trim(dghotwheelineheader.Items(i).Cells(4).Text).Length - 5, 5)
        Txtfinish_time.Text = Trim(dghotwheelineheader.Items(i).Cells(5).Text).Substring(Trim(dghotwheelineheader.Items(i).Cells(5).Text).Length - 5, 5)
        txtmould.Text = dghotwheelineheader.Items(i).Cells(6).Text
        TxtSPG1Oper.Text = dghotwheelineheader.Items(i).Cells(7).Text
        TxtSPG2Oper.Text = dghotwheelineheader.Items(i).Cells(8).Text
        TxtSPG3Oper.Text = dghotwheelineheader.Items(i).Cells(9).Text
        TxtSPG4Oper.Text = dghotwheelineheader.Items(i).Cells(10).Text
    End Sub

    Protected Sub grid1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grid1.SelectedIndexChanged
        grid1.SelectedIndex = i

        If rbl1.SelectedItem.Value = "heat" Then
            'txtdate.Text = Trim(grid1.Items(i).Cells(1).Text)
            'DDLshift.SelectedValue = grid1.Items(i).Cells(2).Text
            rbl1.SelectedItem.Value = Trim(grid1.Items(i).Cells(4).Text)
            Txtheat_no.Text = Trim(grid1.Items(i).Cells(5).Text)
            DropDownList1.SelectedValue = grid1.Items(i).Cells(6).Text
            Txttemp.Text = Trim(grid1.Items(i).Cells(7).Text)
            DDLheatmcno.SelectedItem.Value = grid1.Items(i).Cells(8).Text
            DDLheat_status.SelectedItem.Value = grid1.Items(i).Cells(9).Text
            DDLheatXC_code.SelectedItem.Value = grid1.Items(i).Cells(10).Text
            TxtMCOperator.Text = Trim(grid1.Items(i).Cells(11).Text)

        ElseIf rbl1.SelectedItem.Value = "rework" Then
            'txtdate.Text = Trim(grid1.Items(i).Cells(1).Text)
            'DDLshift.SelectedValue = grid1.Items(i).Cells(2).Text
            rbl1.SelectedItem.Value = Trim(grid1.Items(i).Cells(4).Text)
            Txtheat_no1.Text = Trim(grid1.Items(i).Cells(5).Text)
            Txtwheel_no.Text = Trim(grid1.Items(i).Cells(6).Text)
            Txttmp.Text = Trim(grid1.Items(i).Cells(7).Text)
            DDLremcno.SelectedItem.Value = grid1.Items(i).Cells(8).Text
            DDLrestatus.SelectedItem.Value = grid1.Items(i).Cells(9).Text
            DDLrexccode.SelectedItem.Value = grid1.Items(i).Cells(10).Text
            TxtMCOperator1.Text = Trim(grid1.Items(i).Cells(11).Text)
        End If
    End Sub

    Private Sub grid1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grid1.ItemCommand
        i = e.Item.ItemIndex()
    End Sub

End Class