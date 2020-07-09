Imports System.DateTime
Imports System.Data
Imports System.Data.SqlClient
Public Class PostPouring
    Inherits System.Web.UI.Page

    Protected WithEvents ddlStop_support As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtHeat_number As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtWheelsCast As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtwheelcast_drag As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtwheelcast_cope As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTotalpour_time As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtShift_supervisor As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPostRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtOperator_mould As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEndDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEnd_time As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEnd_temperature As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDrain_MM As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDomedisc_used As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCorebakingSttm As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCorebackEndTm As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCBStartDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCBEndDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCastDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblWoval1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblWoval As System.Web.UI.WebControls.Label
    Protected WithEvents lblWODesc1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblWODesc As System.Web.UI.WebControls.Label
    Protected WithEvents txtw3 As System.Web.UI.WebControls.TextBox
    Protected WithEvents ftempofmtl As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtmetalwt As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtriserwt As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtw4 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTube_condition0 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTube_condition1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTube_condition2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPostRemarks0 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPostRemarks1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPostRemark As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnpostsave As System.Web.UI.WebControls.Button
    Protected WithEvents btnPostClear As System.Web.UI.WebControls.Button
    Protected WithEvents btnPostExit As System.Web.UI.WebControls.Button
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents lblUser As System.Web.UI.WebControls.Label
    Protected WithEvents lblCastWheels As System.Web.UI.WebControls.Label
    Protected WithEvents rblGroup As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents datagrid1 As System.Web.UI.WebControls.DataGrid
    Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
    Dim i As Integer
    Dim strsql As String

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        'Session("UserID") = "111111"
        'Session("Group") = "MLDPOUR"
        lblUser.Visible = True
        lblUser.Text = Session("UserID")
        'lblUser.Text = "085139"
        Try

            Dim PreNPost As New RWF.PreNPostPouring()
            Try
                lblMessage.Text = RWF.tables.GetLatestPrePourHeat

                lblMessage.Text = "Current Heat Number is : " + lblMessage.Text
                ' SetScreen()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try

            Session("PreNPost") = PreNPost
            PreNPost = Nothing
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub SetScreen()
        txtHeat_number.Text = Val(txtHeat_number.Text)
        Try
            If Val(txtHeat_number.Text) > 0 Then
                txtHeat_number.Text = Val(txtHeat_number.Text)
                GetPostHeatDetails()

            Else
                setPost()
            End If

        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub


    Private Sub ClearPost()
        txtDomedisc_used.Text = ""
        txtEnd_temperature.Text = ""
        txtDrain_MM.Text = ""
        txtCorebakingSttm.Text = ""
        txtCorebackEndTm.Text = ""
        txtPostRemarks.Text = ""
        txtCBStartDate.Text = ""
        txtCBEndDate.Text = ""
        txtEndDate.Text = ""
        txtWheelsCast.Text = ""
        txtwheelcast_cope.Text = ""
        txtwheelcast_drag.Text = ""
    End Sub
    Private Sub GetPostHeatDetails()
        ClearPost()
        Dim dt As New DataTable()
        Dim dt1 As New DataTable()
        Dim dt2 As New DataTable()
        Try
            dt = RWF.tables.GetPostPourHeatDetails(txtHeat_number.Text)
            If dt.Rows.Count > 0 Then


                CType(Session("PreNPost"), RWF.PreNPostPouring).DomeDisc = IIf(IsDBNull(dt.Rows(0)("dome_disc_used")), "", dt.Rows(0)("dome_disc_used"))
                txtDomedisc_used.Text = CType(Session("PreNPost"), RWF.PreNPostPouring).DomeDisc

                Try
                    txtCastDate.Text = IIf(IsDBNull(dt.Rows(0)("end_time")), CDate(dt.Rows(0)("end_time")).ToShortDateString, CDate(dt.Rows(0)("end_time")).ToShortDateString)
                Catch exp As Exception
                    txtCastDate.Text = CDate(txtCastDate.Text)
                End Try

                CType(Session("PreNPost"), RWF.PreNPostPouring).Operator1 = IIf(IsDBNull(dt.Rows(0)("operator_mould")), "", dt.Rows(0)("operator_mould"))
                txtOperator_mould.Text = CType(Session("PreNPost"), RWF.PreNPostPouring).Operator1

                CType(Session("PreNPost"), RWF.PreNPostPouring).SIC = IIf(IsDBNull(dt.Rows(0)("sic")), "", dt.Rows(0)("sic"))
                txtShift_supervisor.Text = CType(Session("PreNPost"), RWF.PreNPostPouring).SIC

                CType(Session("PreNPost"), RWF.PreNPostPouring).Remarks = IIf(IsDBNull(dt.Rows(0)("remarks")), "", dt.Rows(0)("remarks"))
                txtPostRemark.Text = CType(Session("PreNPost"), RWF.PreNPostPouring).Remarks

                Try
                    txtEndDate.Text = IIf(IsDBNull(dt.Rows(0)("end_time")), CDate(dt.Rows(0)("end_time")).ToShortDateString, CDate(dt.Rows(0)("end_time")).ToShortDateString)
                Catch exp As Exception
                    txtEndDate.Text = CDate(txtCastDate.Text)
                End Try

                Try
                    CType(Session("PreNPost"), RWF.PreNPostPouring).EndTime = CDate(dt.Rows(0)("end_time")).ToShortDateString + "  " + Right(("0" + CDate(dt.Rows(0)("end_time")).Hour.ToString), 2) + ":" + Right(("0" + CDate(dt.Rows(0)("end_time")).Minute.ToString), 2)
                    txtEnd_time.Text = Right(("0" + CDate(dt.Rows(0)("end_time")).Hour.ToString), 2) + ":" + Right(("0" + CDate(dt.Rows(0)("end_time")).Minute.ToString), 2)
                Catch exp As Exception
                    CType(Session("PreNPost"), RWF.PreNPostPouring).EndTime = CDate(txtCastDate.Text).ToString + "  " + "00:00"
                    txtEnd_time.Text = "00:00"
                End Try

                CType(Session("PreNPost"), RWF.PreNPostPouring).Drain = IIf(IsDBNull(dt.Rows(0)("drain_mm")), "", dt.Rows(0)("drain_mm"))
                txtDrain_MM.Text = CType(Session("PreNPost"), RWF.PreNPostPouring).Drain

                CType(Session("PreNPost"), RWF.PreNPostPouring).EndTemp = IIf(IsDBNull(dt.Rows(0)("end_temperature")), "", dt.Rows(0)("end_temperature"))
                txtEnd_temperature.Text = CType(Session("PreNPost"), RWF.PreNPostPouring).EndTemp

                CType(Session("PreNPost"), RWF.PreNPostPouring).Riser_weight = IIf(IsDBNull(dt.Rows(0)("riserwt")), "", dt.Rows(0)("riserwt"))
                txtriserwt.Text = CType(Session("PreNPost"), RWF.PreNPostPouring).Riser_weight


                CType(Session("PreNPost"), RWF.PreNPostPouring).tube1conditionrmk = IIf(IsDBNull(dt.Rows(0)("tube1conditionrmk")), "", dt.Rows(0)("tube1conditionrmk"))
                txtTube_condition0.Text = CType(Session("PreNPost"), RWF.PreNPostPouring).tube1conditionrmk

                CType(Session("PreNPost"), RWF.PreNPostPouring).tube2conditionrmk = IIf(IsDBNull(dt.Rows(0)("tube2conditionrmk")), "", dt.Rows(0)("tube2conditionrmk"))
                txtTube_condition1.Text = CType(Session("PreNPost"), RWF.PreNPostPouring).tube2conditionrmk

                CType(Session("PreNPost"), RWF.PreNPostPouring).tube3conditionrmk = IIf(IsDBNull(dt.Rows(0)("tube3conditionrmk")), "", dt.Rows(0)("tube3conditionrmk"))
                txtTube_condition2.Text = CType(Session("PreNPost"), RWF.PreNPostPouring).tube3conditionrmk

                CType(Session("PreNPost"), RWF.PreNPostPouring).lesswheelrsn = IIf(IsDBNull(dt.Rows(0)("lesswheelrsn")), "", dt.Rows(0)("lesswheelrsn"))
                txtPostRemarks0.Text = CType(Session("PreNPost"), RWF.PreNPostPouring).lesswheelrsn

                CType(Session("PreNPost"), RWF.PreNPostPouring).excessprdelayrsn = IIf(IsDBNull(dt.Rows(0)("excessprdelayrsn")), "", dt.Rows(0)("excessprdelayrsn"))
                txtPostRemarks1.Text = CType(Session("PreNPost"), RWF.PreNPostPouring).excessprdelayrsn

                CType(Session("PreNPost"), RWF.PreNPostPouring).excessprtimersn = IIf(IsDBNull(dt.Rows(0)("excessprtimersn")), "", dt.Rows(0)("excessprtimersn"))
                txtPostRemarks.Text = CType(Session("PreNPost"), RWF.PreNPostPouring).excessprtimersn

                CType(Session("PreNPost"), RWF.PreNPostPouring).lwtatpouring = IIf(IsDBNull(dt.Rows(0)("lwtatpouring")), "", dt.Rows(0)("lwtatpouring"))
                txtw4.Text = CType(Session("PreNPost"), RWF.PreNPostPouring).lwtatpouring

                populateboxn()

            Else
                ''    txtEnd_time.Text = ""
                'txtEndDate.Text = RWF.tables.GetWorkingDate(Session("Group"))
                '  txtEndDate.Text = txtPourStartDate.Text
                'CType(Session("PreNPost"), RWF.PreNPostPouring).EndTime = CDate(txtEndDate.Text).ToString + "  " + "00:00"
                'txtCorebakingSttm.Text = ""
                'CType(Session("PreNPost"), RWF.PreNPostPouring).CBStartTime = CDate(txtEndDate.Text).ToString + "  " + "00:00"
                'txtCBStartDate.Text = txtEndDate.Text
                'txtCorebackEndTm.Text = ""
                'CType(Session("PreNPost"), RWF.PreNPostPouring).CBEndTime = CDate(txtEndDate.Text).ToString + "  " + "00:00"
                'txtCBEndDate.Text = txtEndDate.Text
                'txtw3.Text = "0"
            End If
            dt1 = RWF.tables.getWheelsCopesDragsUsed(txtHeat_number.Text)
            If dt1.Rows.Count > 0 Then
                txtWheelsCast.Text = IIf(IsDBNull(dt1.Rows(0)("WhlsCast")), "0", dt1.Rows(0)("WhlsCast"))
                txtwheelcast_cope.Text = IIf(IsDBNull(dt1.Rows(0)("CopesUsed")), "0", dt1.Rows(0)("CopesUsed"))
                txtwheelcast_drag.Text = IIf(IsDBNull(dt1.Rows(0)("DragsUsed")), "0", dt1.Rows(0)("DragsUsed")) '
                lblCastWheels.Text = IIf(IsDBNull(dt1.Rows(0)("CastWheels")), "", dt1.Rows(0)("CastWheels"))
            Else
                txtWheelsCast.Text = ""
                txtwheelcast_cope.Text = ""
                txtwheelcast_drag.Text = ""
                lblCastWheels.Text = ""
            End If

            dt2 = RWF.tables.getpourstartend(txtHeat_number.Text)
            If dt2.Rows.Count > 0 Then

                Try
                    txtCBStartDate.Text = IIf(IsDBNull(dt2.Rows(0)("start_pour")), CDate(dt2.Rows(0)("start_pour")).ToShortDateString, CDate(dt2.Rows(0)("end_time")).ToShortDateString)
                Catch exp As Exception
                    txtCBStartDate.Text = CDate(txtCastDate.Text)
                End Try

                Try
                    txtCorebakingSttm.Text = CDate(dt2.Rows(0)("start_pour")).ToShortDateString + "  " + Right(("0" + CDate(dt2.Rows(0)("start_pour")).Hour.ToString), 2) + ":" + Right(("0" + CDate(dt2.Rows(0)("start_pour")).Minute.ToString), 2)
                    txtCorebakingSttm.Text = Right(("0" + CDate(dt2.Rows(0)("start_pour")).Hour.ToString), 2) + ":" + Right(("0" + CDate(dt2.Rows(0)("start_pour")).Minute.ToString), 2)
                Catch exp As Exception
                    txtCorebakingSttm.Text = CDate(txtCastDate.Text).ToString + "  " + "00:00"
                    txtCorebakingSttm.Text = "00:00"
                End Try


                Try
                    txtCBEndDate.Text = IIf(IsDBNull(dt2.Rows(0)("end_pour")), CDate(dt2.Rows(0)("end_pour")).ToShortDateString, CDate(dt2.Rows(0)("end_pour")).ToShortDateString)
                Catch exp As Exception
                    txtCBEndDate.Text = CDate(txtCastDate.Text)
                End Try

                Try
                    txtCorebackEndTm.Text = CDate(dt2.Rows(0)("end_pour")).ToShortDateString + "  " + Right(("0" + CDate(dt2.Rows(0)("end_pour")).Hour.ToString), 2) + ":" + Right(("0" + CDate(dt2.Rows(0)("end_pour")).Minute.ToString), 2)
                    txtCorebackEndTm.Text = Right(("0" + CDate(dt2.Rows(0)("end_pour")).Hour.ToString), 2) + ":" + Right(("0" + CDate(dt2.Rows(0)("end_pour")).Minute.ToString), 2)
                Catch exp As Exception
                    txtCorebackEndTm.Text = CDate(txtCastDate.Text).ToString + "  " + "00:00"
                    txtCorebackEndTm.Text = "00:00"
                End Try

                txtTotalpour_time.Text = IIf(IsDBNull(dt2.Rows(0)("pour_time")), "", dt2.Rows(0)("pour_time"))
            End If


        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
        End Try
        dt = Nothing
        dt1 = Nothing
    End Sub
    Private Sub Clear()
        txtOperator_mould.Text = ""
        txtShift_supervisor.Text = ""
        txtCastDate.Text = ""

    End Sub

    Private Sub setPost()
        txtCorebakingSttm.Text = "00:00"
        txtCorebackEndTm.Text = "00:00"
        txtEnd_time.Text = "00:00"
        '''
        txtCorebakingSttm.Text = ""
        txtCorebackEndTm.Text = ""
        txtEnd_time.Text = ""
        '''

        txtCBStartDate.Text = Now.Date
        txtCBEndDate.Text = Now.Date

        txtEndDate.Text = Now.Date
    End Sub

    Private Sub SetFocus1(ByVal ctrl As Control)
        Dim focusScript As String = "<script language=" & "javascript" & " > " &
        "document.getElementById('" + ctrl.ClientID.ToString.Trim &
        "').focus();</script>"
        Page.RegisterStartupScript("FocusScript", focusScript)
    End Sub
    Private Sub ClearForm()
        ViewState("CopeNo") = ""
        ViewState("DragNo") = ""
    End Sub
    Private Function GetCumulativeCnt() As Integer
        Try
            GetCumulativeCnt = RWF.tables.GetCumulativeCnt(txtHeat_number.Text)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Function
    Private Function GetWOProdId(ByVal strwo As String) As String
        Try
            GetWOProdId = RWF.tables.GetWOProdId(strwo)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Function
    Private Function GetWoDesc(ByVal strwo As String) As String
        Try
            GetWoDesc = RWF.tables.GetWoDesc(strwo)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Function

    Private Sub GetData()
        Try
            If Not RWF.tables.CheckHeat(txtHeat_number.Text) Then
                lblMessage.Text = "In Vaild Heat Number '" & txtHeat_number.Text
                txtHeat_number.Text = ""
                Exit Try
            End If
            Dim dt As New DataTable()
            dt = RWF.tables.GetMeltingWO(Val(txtHeat_number.Text))
            If dt.Rows.Count > 0 Then
                lblWoval.Text = IIf(IsDBNull(dt.Rows(0)("WO")), "", dt.Rows(0)("WO"))
                lblWODesc.Text = IIf(IsDBNull(dt.Rows(0)("WODesc")), "", dt.Rows(0)("WODesc"))
            Else
                lblWoval.Text = ""
                lblWODesc.Text = ""
            End If


        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub btnPostClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPostClear.Click
        Clear()
        ClearPost()
        ClearForm()
        btnpostsave.Text = "Save"
        txtHeat_number.AutoPostBack = True
        txtHeat_number.Enabled = True
        txtHeat_number.Text = 0
    End Sub

    Private Sub btnPostExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPostExit.Click
        Response.Redirect("http://localhost:/mms/selectModule.aspx")
    End Sub


    Protected Sub btnpostsave_Click(sender As Object, e As EventArgs) Handles btnpostsave.Click
        Dim done As Boolean
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj

        Dim remarks, operator_mould, sic, tube1conditionrmk, tube2conditionrmk, tube3conditionrmk, lesswheelrsn, excessprdelayrsn, excessprtimersn, lwtatpouring As String
        Dim heat_number, dome_disc_used, end_temperature, drain_mm, riserwt As Integer
        'Dim end_time As DateTime
        end_temperature = 1570
        heat_number = Val(txtHeat_number.Text.Trim)
        dome_disc_used = Val(txtDomedisc_used.Text.Trim)
        'end_time = CDate(txtEnd_time.Text.Trim)
        Dim fit As DateTime = CDate(txtEndDate.Text + " " & txtEnd_time.Text)
        ' end_temperature = Val(txtEnd_temperature.Text)
        drain_mm = Val(txtDrain_MM.Text.Trim)
        remarks = txtPostRemarks.Text.Trim
        operator_mould = txtOperator_mould.Text.Trim
        sic = txtShift_supervisor.Text.Trim
        tube1conditionrmk = txtTube_condition0.Text.Trim
        tube2conditionrmk = txtTube_condition1.Text.Trim
        tube3conditionrmk = txtTube_condition2.Text.Trim
        lesswheelrsn = txtPostRemarks0.Text.Trim
        excessprdelayrsn = txtPostRemarks1.Text.Trim
        excessprtimersn = txtPostRemark.Text.Trim
        riserwt = Val(txtriserwt.Text)
        lwtatpouring = txtw4.Text.Trim
        domex()

        If Not RWF.tables.CheckHeatpost(txtHeat_number.Text) Then
            Try
                cmd.Connection.Open()
                '" & Convert.ToDateTime(txtEnd_time.Text.Trim)) & "',
                cmd.CommandText = " insert into mm_post_pouring (heat_number,dome_disc_used,end_time,end_temperature,drain_mm,remarks,operator_mould,sic," &
                               "tube1conditionrmk,tube2conditionrmk,tube3conditionrmk,lesswheelrsn,excessprdelayrsn," &
                               "excessprtimersn,riserwt,lwtatpouring ) " &
                               " values ('" & Val(txtHeat_number.Text.Trim) & "', '" & Val(txtDomedisc_used.Text.Trim) & "','" & Format(CDate(fit), "MM/dd/yyyy HH:mm") & "',
                                       '" & Val(txtEnd_temperature.Text) & "','" & Val(txtDrain_MM.Text.Trim) & "',
                                       '" & txtPostRemark.Text.Trim & "','" & txtOperator_mould.Text & "','" & txtShift_supervisor.Text & "', 
                                       '" & txtTube_condition0.Text.Trim & "',  '" & txtTube_condition1.Text.Trim & "', '" & txtTube_condition2.Text.Trim & "', 
                                       '" & txtPostRemarks0.Text.Trim & "',  '" & txtPostRemarks1.Text.Trim & "', '" & txtPostRemarks.Text.Trim & "', 
                                       '" & Val(txtriserwt.Text.Trim) & "',  '" & txtw4.Text.Trim & "')"


                If cmd.ExecuteNonQuery() = 1 Then done = True
                lblMessage.Text = "Data Saved for this Heat " & txtHeat_number.Text &
                btnpostsave.Text = "Update"
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try

            'Else
            '    lblMessage.Text = "Data Alreadedy feeded"
            '    btnpostsave.Text = "Update"

        End If

        populateboxn()
        If btnpostsave.Text = "Update" Then
            Try
                cmd.Connection.Open()
                cmd.CommandText = " update mm_post_pouring set  dome_disc_used ='" & Val(txtDomedisc_used.Text.Trim) & "',  end_time= '" & Format(CDate(fit), "MM/dd/yyyy HH:mm") & "' , " &
                                      "end_temperature='" & Val(txtEnd_temperature.Text) & "',drain_mm='" & Val(txtDrain_MM.Text.Trim) & "' ,remarks= '" & txtPostRemark.Text.Trim & "', operator_mould = '" & txtOperator_mould.Text & "', " &
                                      " sic='" & txtShift_supervisor.Text & "',tube1conditionrmk='" & txtTube_condition0.Text.Trim & "', " &
                                      "tube2conditionrmk='" & txtTube_condition1.Text.Trim & "',tube3conditionrmk='" & txtTube_condition2.Text.Trim & "'," &
                                      " lesswheelrsn='" & txtPostRemarks0.Text.Trim & "',excessprdelayrsn='" & txtPostRemarks1.Text.Trim & "', " &
                                      "excessprtimersn='" & txtPostRemarks.Text.Trim & "',riserwt='" & Val(txtriserwt.Text.Trim) & "',lwtatpouring ='" & txtw4.Text.Trim & "' " &
                                   " where heat_number = '" & Val(txtHeat_number.Text) & "' "


                If cmd.ExecuteNonQuery() = 1 Then done = True
                lblMessage.Text = "Data Updated for this Heat update " & txtHeat_number.Text
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try

        End If
        'savepost()
    End Sub


    Protected Sub txtHeat_number_TextChanged() Handles txtHeat_number.TextChanged
        lblMessage.Text = ""
        If RWF.tables.CheckHeat(Val(txtHeat_number.Text)) Then
            Try
                GetPostHeatDetails()
                GetData()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        Else
            lblMessage.Text = "InValid Heat Number '" & txtHeat_number.Text & "'"
            txtHeat_number.Text = ""

        End If
        If RWF.tables.CheckHeatpost(Val(txtHeat_number.Text)) Then
            Try
                GetPostHeatDetails()
                GetData()
                btnpostsave.Text = "Update"
                txtHeat_number.AutoPostBack = False
                txtHeat_number.Enabled = False

            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        Else
            btnpostsave.Text = "Save"
            txtHeat_number.AutoPostBack = True
            txtHeat_number.Enabled = True
        End If
        'Dim sqlstr3 As String
        'sqlstr3 = "select post.heat_number,post.end_time,post.end_temperature,post.total_pour_time,post.total_wheels_poured,post.riserwt,post.lwtatpouring from mm_post_pouring post,mm_pre_pouring pre where pre.cast_date='" & Format(CDate(txtCastDate.Text), "yyyy-MM-dd 00:00:00.000") & "' and post.heat_number = pre.heat_number "
        '' post.txtwheelcast_cope.Text, post.txtwheelcast_cope.Text, post.txtwheelcast_drag.Text
        'Call BindDataGrid(sqlstr3)
    End Sub

    Protected Function domex() Handles txtDomedisc_used.TextChanged
        Dim strConn As String = ConfigurationManager.ConnectionStrings("con").ConnectionString
        Dim con As New SqlConnection(strConn)
        Dim cmd As New SqlCommand()

        cmd.Connection = con
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "select count(distinct(cope_number)) from mm_spraystation_cope where heat_number='" & (Val(txtHeat_number.Text) - 1) & "' and dome_disc='Y' and cope_number in (select distinct cope_number from  mm_pouring where heat_number='" & (Val(txtHeat_number.Text)) & "') "
        con.Open()
        cmd.ExecuteReader()
        txtDomedisc_used.Text = cmd.CommandText
        Return txtDomedisc_used.Text
        con.Close()

    End Function

    Public Sub populateboxn()
        Dim strConn As String = ConfigurationManager.ConnectionStrings("con").ConnectionString

        Dim con As New SqlConnection(strConn)
        Dim cmd As New SqlCommand()
        cmd.Connection = con
        cmd.CommandType = CommandType.Text
        cmd.CommandText = " SELECT distinct(stop_pipe_make) from mm_spraystation_cope where heat_number in  ( '" & (Val(txtHeat_number.Text) - 1) & "','" & (Val(txtHeat_number.Text) - 2) & "','" & (Val(txtHeat_number.Text) - 3) & "','" & (Val(txtHeat_number.Text) - 4) & "') and cope_number in (select distinct cope_number from  mm_pouring where heat_number='" & (Val(txtHeat_number.Text)) & "')"
        cmd.Connection = con
        con.Open()
        ddlStop_support.DataSource = cmd.ExecuteReader()
        ddlStop_support.DataTextField = "stop_pipe_make"
        ddlStop_support.DataValueField = "stop_pipe_make"
        ddlStop_support.DataBind()
        con.Close()

        ddlStop_support.Items.Insert(0, New ListItem("--Select Mould No--", "0"))

    End Sub
    Private Sub GetPostPourHeatDetails()
        If txtHeat_number.Text = "" Then
            lblMessage.Text = "In Vaild Heat Number !"
            txtHeat_number.Text = ""

            Exit Sub
        End If
        Try
            GetPostData()

        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub GetPostData()
        Try
            If Not RWF.tables.CheckHeat(lblMessage.Text) Then
                lblMessage.Text = "In Vaild Heat Number '" & txtHeat_number.Text
                txtHeat_number.Text = ""
                Exit Try
            End If
            Dim dt As New DataTable()
            dt = RWF.tables.GetMeltingWO(Val(lblMessage.Text))
            If dt.Rows.Count > 0 Then
                lblWoval.Text = IIf(IsDBNull(dt.Rows(0)("WO")), "", dt.Rows(0)("WO"))
                lblWODesc.Text = IIf(IsDBNull(dt.Rows(0)("WODesc")), "", dt.Rows(0)("WODesc"))
            Else
                lblWoval.Text = ""
                lblWODesc.Text = ""
            End If
            ' GetWoNo()

        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    'Private Sub BindDataGrid(ByVal strArg As String)

    '    Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
    '    Dim strsql As String
    '    Try
    '        cmd.Connection.Open()
    '        cmd = New SqlCommand(strArg, cmd.Connection)
    '        Dim objDr As SqlDataReader = cmd.ExecuteReader()
    '        Dim arr() As String
    '        datagrid1.DataSource = arr
    '        datagrid1.DataBind()
    '        datagrid1.DataSource = objDr
    '        datagrid1.DataBind()
    '    Catch exp As SqlException
    '        strsql = exp.StackTrace
    '        lblMessage.Text = "Line : " & Mid(strsql, InStr(strsql, "line") + 5) & " Message : " + exp.Message

    '    Catch exp As Exception
    '        strsql = exp.StackTrace
    '        lblMessage.Text = "Line : " & Mid(strsql, InStr(strsql, "line") + 5) & " Message : " + exp.Message

    '    Finally
    '        If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
    '        cmd.Dispose()
    '        cmd = Nothing
    '    End Try
    'End Sub
    'Protected Sub datagrid1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles datagrid1.SelectedIndexChanged
    '    datagrid1.SelectedIndex = i
    '    Dim fit As DateTime = CDate(txtEndDate.Text + " " & txtEnd_time.Text)
    '    txtHeat_number.Text = Trim(datagrid1.Items(i).Cells(1).Text)
    '    fit = Trim(datagrid1.Items(i).Cells(2).Text)
    '    txtEnd_temperature.Text = Trim(datagrid1.Items(i).Cells(3).Text)
    '    txtTotalpour_time.Text = Trim(datagrid1.Items(i).Cells(4).Text)
    '    txtWheelsCast.Text = Trim(datagrid1.Items(i).Cells(5).Text)
    '    txtriserwt.Text = Trim(datagrid1.Items(i).Cells(6).Text)
    '    txtw4.Text = Trim(datagrid1.Items(i).Cells(7).Text)

    'End Sub

    'Private Sub datagrid1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles datagrid1.ItemCommand

    '    i = e.Item.ItemIndex()
    'End Sub

End Class