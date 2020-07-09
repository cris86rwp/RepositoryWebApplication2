Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Public Class WheelFinalInspection
    Inherits System.Web.UI.Page
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlWheelStatus As System.Web.UI.WebControls.Panel
    Protected WithEvents lblDayVar As System.Web.UI.WebControls.Label
    Protected WithEvents lblMnthVar As System.Web.UI.WebControls.Label
    Protected WithEvents lblDayTgt As System.Web.UI.WebControls.Label
    Protected WithEvents lblMonthTgt As System.Web.UI.WebControls.Label
    Protected WithEvents lblDayOutTurn As System.Web.UI.WebControls.Label
    Protected WithEvents lblCumOutTurn As System.Web.UI.WebControls.Label
    Protected WithEvents chkRefreshOutTurn As System.Web.UI.WebControls.CheckBox
    Protected WithEvents lblWheelType As System.Web.UI.WebControls.Label
    Protected WithEvents lblInspector As System.Web.UI.WebControls.Label
    Protected WithEvents chkGenShift As System.Web.UI.WebControls.CheckBox
    Protected WithEvents lblShift As System.Web.UI.WebControls.Label
    Protected WithEvents lblInspDate As System.Web.UI.WebControls.Label
    Protected WithEvents pnlLoginSts As System.Web.UI.WebControls.Panel
    Protected WithEvents lblMagProc As System.Web.UI.WebControls.Label
    Protected WithEvents chkRefreshGrid As System.Web.UI.WebControls.CheckBox
    Protected WithEvents pnlWheel As System.Web.UI.WebControls.Panel
    Protected WithEvents dgInspParams As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgData As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents lbl20thWheel As System.Web.UI.WebControls.Label
    Protected WithEvents lblFirstCastWheel As System.Web.UI.WebControls.Label
    Protected WithEvents txtHeatNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtWheelNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMagSts As System.Web.UI.WebControls.Label
    Protected WithEvents lblMasterStatus As System.Web.UI.WebControls.Label
    Protected WithEvents lblLocation As System.Web.UI.WebControls.Label
    Protected WithEvents lblMcnWhl As System.Web.UI.WebControls.Label
    Protected WithEvents txtTreadDia As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtBoreDia As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPlateThickness As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRimThickness As System.Web.UI.WebControls.TextBox
    Protected WithEvents rdoBoreSt As System.Web.UI.WebControls.DropDownList
    Protected WithEvents shift_dd1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents rdoPlateSt As System.Web.UI.WebControls.DropDownList
    Protected WithEvents rdoRimSt As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblFiMcnOpn As System.Web.UI.WebControls.Label
    Protected WithEvents chk20thwhlRems As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkAllowLPTRej As System.Web.UI.WebControls.CheckBox
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblRejRewCodes As System.Web.UI.WebControls.Label
    Protected WithEvents rdoWheelSts As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents ddlRewRejcodes As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlGridOption As System.Web.UI.WebControls.DropDownList
    Protected WithEvents hubst As System.Web.UI.WebControls.DropDownList
    Protected WithEvents hubdiast As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents btnClear As System.Web.UI.WebControls.Button
    Protected WithEvents chkRDTY As System.Web.UI.WebControls.CheckBox
    Protected WithEvents lblShiftActual As System.Web.UI.WebControls.Label
    Protected WithEvents lblRDTYdone As System.Web.UI.WebControls.Label
    Protected WithEvents lblReclWhl As System.Web.UI.WebControls.Label
    Protected WithEvents lblRdtySize As System.Web.UI.WebControls.Label
    Protected WithEvents txtRdtySize As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblRdtyBoc As System.Web.UI.WebControls.Label
    Protected WithEvents txtRdtyBoc As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblWheelWeight As System.Web.UI.WebControls.Label
    Protected WithEvents lblrdtySizeDisp As System.Web.UI.WebControls.Label
    Protected WithEvents lblRdtyBocDisp As System.Web.UI.WebControls.Label
    Protected WithEvents lblRdtyWheel As System.Web.UI.WebControls.Label
    Protected WithEvents rdoUbPassType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents RadioButtonList1 As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblDrgNo As System.Web.UI.WebControls.Label
    Protected WithEvents lblPCode As System.Web.UI.WebControls.Label
    Protected WithEvents lblMagStock As System.Web.UI.WebControls.Label
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList

    Public con As New SqlConnection(ConfigurationManager.AppSettings("con"))

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
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not Page.IsPostBack Then

            Try
                Label1.Visible = False

                getDateShift()
                Session("UserID") = "074632"
                Session("Group") = "CLRINS"
                lblInspector.Text = "074632"
                If Session("Group") <> "CLRINS" Or Session("UserID") = "" Then
                    Response.Redirect("/mms/InvalidSession.aspx")
                    Exit Sub
                End If
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try

        End If
    End Sub



    Private Sub txtWheelNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWheelNumber.TextChanged
        lblMessage.Text = ""
        If Val(txtWheelNumber.Text) > 0 Then
            If Val(txtHeatNumber.Text) > 0 Then
                CheckWheel1()
                st()
            Else

                SetFocus(txtHeatNumber)
            End If
        Else
            SetFocus(txtHeatNumber)
        End If

    End Sub


    Private Sub RejCode(Optional ByVal Rsts As String = "")
        If Rsts = "" Then
            lblRejRewCodes.Visible = False
            ddlRewRejcodes.ClearSelection()
            ddlRewRejcodes.Visible = False
        Else
            Dim i As Integer
            ddlRewRejcodes.ClearSelection()
            For i = 0 To ddlRewRejcodes.Items.Count - 1
                If ddlRewRejcodes.Items(i).Text = Rsts Then
                    ddlRewRejcodes.Items(i).Selected = True
                    Exit For
                End If
            Next
            i = Nothing
        End If
    End Sub



    Private Sub txtHeatNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHeatNumber.TextChanged
        lblMessage.Text = ""
        If Val(txtHeatNumber.Text) > 0 Then
            If Val(txtWheelNumber.Text) > 0 Then
                CheckWheel1()
            Else

                SetFocus(txtWheelNumber)
            End If
        Else
            SetFocus(txtWheelNumber)
        End If

    End Sub


    Dim strsql As String
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If btnSave.Text = "Save" Then
            con.Open()
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            Dim sqlPara(15) As SqlParameter
            sqlPara(0) = New SqlParameter("@date", CDate(Trim(lblInspDate.Text)))
            sqlPara(1) = New SqlParameter("@shift", Trim(shift_dd1.SelectedItem.Text))
            sqlPara(2) = New SqlParameter("@heat", Trim(txtHeatNumber.Text))

            sqlPara(3) = New SqlParameter("@wheel", Trim(txtWheelNumber.Text))
            sqlPara(4) = New SqlParameter("@tred", Trim(txtTreadDia.Text))
            sqlPara(5) = New SqlParameter("@bore", Trim(txtBoreDia.Text))
            sqlPara(6) = New SqlParameter("@plate", Trim(txtPlateThickness.Text))

            sqlPara(7) = New SqlParameter("@borest", Trim(rdoBoreSt.SelectedItem.Text))
            sqlPara(8) = New SqlParameter("@platest", Trim(rdoPlateSt.SelectedItem.Text))
            sqlPara(9) = New SqlParameter("@rimst", Trim(rdoRimSt.Text))
            sqlPara(10) = New SqlParameter("@hublength", Trim(hubst.SelectedItem.Text))
            sqlPara(11) = New SqlParameter("@hubdia", Trim(hubdiast.SelectedItem.Text))
            sqlPara(12) = New SqlParameter("@remark", Trim(txtRemarks.Text))
            sqlPara(13) = New SqlParameter("@rtyboc", Trim(RadioButtonList1.SelectedItem.Text))

            sqlPara(14) = New SqlParameter("@wheelst", Trim(rdoWheelSts.SelectedItem.Text))

            sqlPara(15) = New SqlParameter("@ins", Trim(lblInspector.Text))


            Dim sqlstr As String = "insert into  mm_wheelInspection(date,shift,wheelnumber,heatnumber,threaddia,boredia,platethickness,bore_status,plate_status,Rim_status,hublength,hubdia,Remark,RtyBoc,wheelStatus,insp ) values("
            sqlstr &= "  @date,@shift,@wheel,@heat,@tred,@bore,@plate,@borest,@platest,@rimst,@hublength,@hubdia,@remark,@rtyboc,@wheelst,@ins )"
            Try

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If
                SqlHelper.ExecuteNonQuery(con, CommandType.Text, sqlstr, sqlPara)

                lblMessage.Text = "Details Added"
                show_data()


            Catch exp As SqlException
                If exp.Number = 2627 Then
                    lblMessage.Text = "This Record Already exists"
                    btnSave.Text = "Update"

                Else

                    strsql = exp.StackTrace
                    lblMessage.Text = "Line : " & Mid(strsql, InStr(strsql, "line") + 5) & " Message : " + exp.Message
                End If
            Catch exp As Exception
                strsql = exp.StackTrace
                lblMessage.Text = "Line : " & Mid(strsql, InStr(strsql, "line") + 5) & " Message : " + exp.Message
            End Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

        Else
            If btnSave.Text = "Update" Then
                Dim strsql As String
                Dim sqlPara(15) As SqlParameter
                sqlPara(0) = New SqlParameter("@date", CDate(Trim(lblInspDate.Text)))
                sqlPara(1) = New SqlParameter("@shift", Trim(shift_dd1.SelectedItem.Text))
                sqlPara(2) = New SqlParameter("@heat", Trim(txtHeatNumber.Text))

                sqlPara(3) = New SqlParameter("@wheel", Trim(txtWheelNumber.Text))
                sqlPara(4) = New SqlParameter("@tred", Trim(txtTreadDia.Text))
                sqlPara(5) = New SqlParameter("@bore", Trim(txtBoreDia.Text))
                sqlPara(6) = New SqlParameter("@plate", Trim(txtPlateThickness.Text))

                sqlPara(7) = New SqlParameter("@borest", Trim(rdoBoreSt.SelectedItem.Text))
                sqlPara(8) = New SqlParameter("@platest", Trim(rdoPlateSt.SelectedItem.Text))
                sqlPara(9) = New SqlParameter("@rimst", Trim(rdoRimSt.Text))
                sqlPara(10) = New SqlParameter("@hublength", Trim(hubst.SelectedItem.Text))
                sqlPara(11) = New SqlParameter("@hubdia", Trim(hubdiast.SelectedItem.Text))
                sqlPara(12) = New SqlParameter("@remark", Trim(txtRemarks.Text))
                sqlPara(13) = New SqlParameter("@rtyboc", Trim(RadioButtonList1.SelectedItem.Text))

                sqlPara(14) = New SqlParameter("@wheelst", Trim(rdoWheelSts.SelectedItem.Text))

                sqlPara(15) = New SqlParameter("@ins", Trim(lblInspector.Text))


                Try
                    strsql = "update mm_wheelInspection set date=@date,shift=@shift,Wheelnumber=@wheel,Heatnumber=@heat,threaddia=@tred,boredia=@bore,platethickness=@plate,bore_status=@borest,plate_status=@platest,Rim_status=@rimst,hublength=@hublength,hubdia=@hubdia,Remark=@remark,RtyBoc=@rtyboc,wheelStatus=@wheelst,insp=@ins where  date='" & Format(Convert.ToDateTime(lblInspDate.Text), "MM/dd/yyyy") & "'  and shift='" & shift_dd1.SelectedItem.Text & "'"
                    SqlHelper.ExecuteNonQuery(con, CommandType.Text, strsql, sqlPara)
                    lblMessage.Text = "Updated Sucessfully"
                    show_data()
                    btnSave.Text = "Save"
                    'Call clearform()


                Catch exp As SqlException
                    strsql = exp.StackTrace
                    lblMessage.Text = "Line : " & Mid(strsql, InStr(strsql, "line") + 5) & " Message : " + exp.Message

                Catch exp As Exception
                    strsql = exp.StackTrace
                    lblMessage.Text = "Line : " & Mid(strsql, InStr(strsql, "line") + 5) & " Message : " + exp.Message
                End Try
            End If
        End If





    End Sub
    Private Sub CheckWheel1()
        Try
            If RWF.MLDING.CheckWheel(Val(txtHeatNumber.Text), Val(txtWheelNumber.Text)) Then
                lblMessage.Text = ""
                ' GetWheelData()
                SetFocus(txtHeatNumber)
            Else
                lblMessage.Text = "InValid Wheel/Heat Number !"
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
    Private Sub show_data()

        Try

            cmd.Connection.Open()
            cmd.CommandText = "select Wheelnumber,Heatnumber,threaddia,boredia,platethickness,wheelStatus from mm_wheelInspection where  date='" & Format(Convert.ToDateTime(lblInspDate.Text), "MM/dd/yyyy") & "'  and shift='" & shift_dd1.SelectedItem.Text & "' "
            Using sda As New SqlDataAdapter()
                sda.SelectCommand = cmd
                Using dt As New DataSet()
                    sda.Fill(dt)
                    dgData.DataSource = dt
                    dgData.DataBind()
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            cmd.Connection.Close()
        End Try
    End Sub
    Public Sub getDateShift()
        If Now.Hour = 0 OrElse Now.Hour = 1 OrElse Now.Hour = 2 OrElse Now.Hour = 3 OrElse Now.Hour = 4 OrElse Now.Hour = 5 Then
            lblInspDate.Text = CDate(Now.Date.AddDays(-1))
        Else
            lblInspDate.Text = CDate(Now.Date)
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
        shift_dd1.ClearSelection()
        For i = 0 To shift_dd1.Items.Count - 1
            If shift_dd1.Items(i).Text = Shift Then
                shift_dd1.Items(i).Selected = True
                Exit For
            End If
        Next
        dt = Nothing
        Shift = Nothing
        i = Nothing
    End Sub
    Private Sub st()
        Try
            cmd.Connection.Open()
            cmd.CommandText = "select top 1  utstatus,typeofdefect from mm_magnaglow_shiftwiserecords_new where wheelno=" & txtWheelNumber.Text & "  order by date desc  "

            Dim sdr As SqlDataReader
            sdr = cmd.ExecuteReader()
            sdr.Read()
            lblMagSts.Text = sdr("utstatus").ToString()
            If (lblMagSts.Text = "pass") Then
                btnSave.Enabled = True
            Else
                btnSave.Enabled = False
            End If
            lblMasterStatus.Text = sdr("typeofdefect").ToString()

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            cmd.Connection.Close()
        End Try
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtHeatNumber.Text = ""
        txtWheelNumber.Text = ""
        txtTreadDia.Text = ""
        txtBoreDia.Text = ""
        txtPlateThickness.Text = ""
        lblInspDate.Text = ""
        shift_dd1.SelectedIndex = 0
        rdoBoreSt.SelectedIndex = 0
        rdoPlateSt.SelectedIndex = 0
        rdoRimSt.Text = ""
        hubst.SelectedIndex = 0
        hubdiast.SelectedIndex = 0
        txtRemarks.Text = ""
        RadioButtonList1.SelectedIndex = 0

    End Sub

End Class