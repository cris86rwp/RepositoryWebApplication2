Imports System.DateTime
Imports System
Imports System.Data
Imports System.Data.SqlClient
Public Class PrePouring
    Inherits System.Web.UI.Page
    Protected WithEvents pnlspray As System.Web.UI.WebControls.Panel
    Protected WithEvents txtHeatNumber As System.Web.UI.WebControls.TextBox
    ' Protected WithEvents rblType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtCastDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtOperator_mould As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtShift_supervisor As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblGroup As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtJMP_cover As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtPour_tankNo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtLLTDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtLadlelift_time As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblUser As System.Web.UI.WebControls.Label
    Protected WithEvents txtLITDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtLadle_in_tank_time As System.Web.UI.WebControls.TextBox
    'Protected WithEvents txt_ladle_in_tank_temp As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFImm As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtImmer1_time As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtImmer1_temperature As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSImm As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtImmer2_time As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtImmer2_temperature As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblIIIrdImmersion As System.Web.UI.WebControls.Label
    Protected WithEvents txtTImm As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtImmer3_time As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtImmer3_temperature As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPourStartDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPourStartTime As System.Web.UI.WebControls.TextBox
    'Protected WithEvents txtPourStartTemp As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTubeNo1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTube1_mfg As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTube1_life As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSing_condition As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtTubeNo2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTube2_mfg As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTube2_life As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTubeNo3 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTube3_mfg As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTube3_life As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtStop_support As System.Web.UI.WebControls.DropDownList
    'Protected WithEvents txtTITDate As System.Web.UI.WebControls.TextBox
    'Protected WithEvents txtTube_intime As System.Web.UI.WebControls.TextBox
    'Protected WithEvents txtTOTDate As System.Web.UI.WebControls.TextBox
    'Protected WithEvents txtTube_outtime As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtAL_stars As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtALdip_temp As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtOT13drag As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtOT14drag As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtOT20cope As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtOT21cope As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMetalRecieved As System.Web.UI.WebControls.TextBox
    'Protected WithEvents txtRiser_weight As System.Web.UI.WebControls.TextBox
    Protected WithEvents Ddlmtllvl As System.Web.UI.WebControls.DropDownList
    'Protected WithEvents txtldlInsl_metal As System.Web.UI.WebControls.TextBox
    Protected WithEvents prbheight As System.Web.UI.WebControls.TextBox
    Protected WithEvents plgpressure As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPreRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents jmporing As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Ladno As System.Web.UI.WebControls.Label
    Protected WithEvents Ladlife As System.Web.UI.WebControls.Label
    Protected WithEvents Lademptwt As System.Web.UI.WebControls.Label
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents txtHeat_number As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblWoval1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblWODesc1 As System.Web.UI.WebControls.Label
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents btnClear As System.Web.UI.WebControls.Button
    Protected WithEvents btnExit As System.Web.UI.WebControls.Button
    Protected WithEvents rblOffloadCode As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtladtaptime As System.Web.UI.WebControls.TextBox
    Shared themeValue, lltstr As String

    Public Sub New()

        AddHandler PreInit, New EventHandler(AddressOf Page_PreInit)
    End Sub

    Private Sub Page_PreInit(ByVal sender As Object, ByVal e As EventArgs)

        Page.Theme = themeValue
    End Sub


    Protected Sub dd1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        themeValue = Dd1.SelectedItem.Value
        Response.Redirect(Request.Url.ToString())

    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        'Put user code to initialize the page here
        'Session("UserID") = "080102"
        'Session("Group") = "MLDPOUR"
        lblUser.Visible = True
        lblUser.Text = Session("UserID")
        lblUser.Text = "085139"

        Try
            'setPre()

            Dim PreNPost As New RWF.PreNPostPouring()
            Session("PreNPost") = PreNPost
            PreNPost = Nothing
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try

        'Try
        '    ' txtHeatNumber.Text = RWF.tables.GetLatestPrePourHeat
        '    GetData()
        '    setPre()

        'Catch exp As Exception
        '    lblMessage.Text = exp.Message
        'End Try

    End Sub
    Private Sub GetData()
        Try
            If Not RWF.tables.CheckHeat(txtHeatNumber.Text) Then
                lblMessage.Text = "In Vaild Heat Number '" & txtHeatNumber.Text
                txtHeatNumber.Text = ""
                Exit Try
            End If
            Dim dt As New DataTable()
            dt = RWF.tables.GetMeltingWO(Val(txtHeatNumber.Text))
            If dt.Rows.Count > 0 Then
                lblWoval1.Text = IIf(IsDBNull(dt.Rows(0)("WO")), "", dt.Rows(0)("WO"))
                lblWODesc1.Text = IIf(IsDBNull(dt.Rows(0)("WODesc")), "", dt.Rows(0)("WODesc"))
            Else
                lblWoval1.Text = ""
                lblWODesc1.Text = ""
            End If
            btnSave.Text = "Save"
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub ClearPost()
        txtOT13drag.Text = ""
        txtOT14drag.Text = ""
        txtOT20cope.Text = ""
        txtOT21cope.Text = ""
        txtPreRemarks.Text = ""

    End Sub

    Private Sub Clear()
        txtOperator_mould.Text = ""
        txtShift_supervisor.Text = ""
        'txtJMP_cover.Text = ""
        txtLadlelift_time.Text = ""
        txtPour_tankNo.DataTextField = ""
        txtAL_stars.Text = ""
        txtALdip_temp.Text = ""
        txtLadle_in_tank_time.Text = ""
        txtImmer1_time.Text = ""
        txtImmer2_time.Text = ""
        txtImmer3_time.Text = ""
        txtImmer3_temperature.Text = ""
        txtImmer2_temperature.Text = ""
        txtImmer1_temperature.Text = ""
        'txt_ladle_in_tank_temp.Text = ""
        txtSing_condition.SelectedIndex = 0
        txtStop_support.SelectedIndex = 0
        'txtRiser_weight.Text = ""
        txtMetalRecieved.Text = ""
        txtTubeNo1.Text = ""
        txtTubeNo2.Text = ""
        txtTubeNo3.Text = ""
        txtTube1_mfg.Text = ""
        txtTube2_mfg.Text = ""
        txtTube3_mfg.Text = ""
        txtTube1_life.Text = ""
        txtTube2_life.Text = ""
        txtTube3_life.Text = ""
        'txtTube_intime.Text = ""
        'txtTube_outtime.Text = ""
        Ddlmtllvl.SelectedIndex = 0
        'txtldlInsl_metal.Text = ""
        txtCastDate.Text = ""
        txtLLTDate.Text = ""
        txtLITDate.Text = ""
        txtFImm.Text = ""
        txtSImm.Text = ""
        txtTImm.Text = ""
        'txtTITDate.Text = ""
        'txtTOTDate.Text = ""
    End Sub
    Private Sub GetHeatDetails()
        Clear()
        Dim dt As New DataTable()
        Try
            dt = RWF.tables.GetPreHeatDetails(txtHeatNumber.Text)
            If dt.Rows.Count > 0 Then
                btnSave.Text = "Update"
                CType(Session("PreNPost"), RWF.PreNPostPouring).Operator1 = IIf(IsDBNull(dt.Rows(0)("operator_mould")), "", Trim(dt.Rows(0)("operator_mould")))
                txtOperator_mould.Text = CType(Session("PreNPost"), RWF.PreNPostPouring).Operator1
                CType(Session("PreNPost"), RWF.PreNPostPouring).SIC = IIf(IsDBNull(dt.Rows(0)("shift_supervisor")), "", Trim(dt.Rows(0)("shift_supervisor")))
                txtShift_supervisor.Text = CType(Session("PreNPost"), RWF.PreNPostPouring).SIC

                'CType(Session("PreNPost"), RWF.PreNPostPouring).ShiftGroup = IIf(IsDBNull(dt.Rows(0)("ShiftGroup")), "", Trim(dt.Rows(0)("ShiftGroup")))

                Dim i As Int16 = 0


                Try
                    CType(Session("PreNPost"), RWF.PreNPostPouring).CastDate = IIf(IsDBNull(dt.Rows(0)("cast_date")), CDate("01/01/1900"), CDate(dt.Rows(0)("cast_date")).ToShortDateString)
                    txtCastDate.Text = IIf(IsDBNull(dt.Rows(0)("cast_date")), CDate("01/01/1900"), CDate(dt.Rows(0)("cast_date")).ToShortDateString)

                    '  CType(Session("PreNPost"), RWF.PreNPostPouring).CastDate = CDate(dt.Rows(0)("Cast_Date")).ToShortDateString

                Catch exp As Exception
                    CType(Session("PreNPost"), RWF.PreNPostPouring).CastDate = CDate("01/01/1900")
                    txtCastDate.Text = CDate("01/01/1900")
                End Try
                CType(Session("PreNPost"), RWF.PreNPostPouring).JMPCover = IIf(IsDBNull(dt.Rows(0)("jmp_cover1")), "", Trim(dt.Rows(0)("jmp_cover1")))
                txtJMP_cover.Text = CType(Session("PreNPost"), RWF.PreNPostPouring).JMPCover
                Try
                    CType(Session("PreNPost"), RWF.PreNPostPouring).LLT = CDate(dt.Rows(0)("ladle_lift_time")).ToShortDateString + "  " + Right(("0" + CDate(dt.Rows(0)("ladle_lift_time")).Hour.ToString), 2) + ":" + Right(("0" + CDate(dt.Rows(0)("ladle_lift_time")).Minute.ToString), 2)
                    txtLadlelift_time.Text = Right(("0" + CDate(dt.Rows(0)("ladle_lift_time")).Hour.ToString), 2) + ":" + Right(("0" + CDate(dt.Rows(0)("ladle_lift_time")).Minute.ToString), 2)
                Catch exp As Exception
                    CType(Session("PreNPost"), RWF.PreNPostPouring).LLT = CDate("01/01/1900").ToString + "  " + "00:00"
                    txtLadlelift_time.Text = "00:00"
                End Try
                '''
                If txtLadlelift_time.Text = "00:00" Then
                    txtLadlelift_time.Text = ""
                End If
                Try
                    txtLLTDate.Text = IIf(IsDBNull(dt.Rows(0)("ladle_lift_time")), CDate(txtCastDate.Text), CDate(dt.Rows(0)("ladle_lift_time")).ToShortDateString)
                Catch exp As Exception
                    txtLLTDate.Text = CDate(txtCastDate.Text)
                End Try

                Try
                    CType(Session("PreNPost"), RWF.PreNPostPouring).PourTankNo = IIf(IsDBNull(dt.Rows(0)("pouring_tank_number")), "", dt.Rows(0)("pouring_tank_number"))
                    txtPour_tankNo.SelectedValue = Val(CType(Session("PreNPost"), RWF.PreNPostPouring).PourTankNo)
                Catch exp As Exception
                    txtPour_tankNo.SelectedValue = 2
                End Try
                Try
                    '  CType(Session("PreNPost"), RWF.PreNPostPouring).ALStars = IIf(IsDBNull(dt.Rows(0)("aluminium_stars")), "", dt.Rows(0)("aluminium_stars"))
                    txtAL_stars.Text = IIf(IsDBNull(dt.Rows(0)("aluminium_stars")), "", dt.Rows(0)("aluminium_stars"))
                Catch ex As Exception
                    txtAL_stars.Text = 0
                End Try

                CType(Session("PreNPost"), RWF.PreNPostPouring).ALDipTemp = IIf(IsDBNull(dt.Rows(0)("aluminium_dip_temperature")), "", dt.Rows(0)("aluminium_dip_temperature"))
                txtALdip_temp.Text = CType(Session("PreNPost"), RWF.PreNPostPouring).ALDipTemp
                If txtAL_stars.Text = 0 Then txtAL_stars.Text = ""
                If txtALdip_temp.Text = 0 Then txtALdip_temp.Text = ""

                Try
                    CType(Session("PreNPost"), RWF.PreNPostPouring).LadleInTime = CDate(dt.Rows(0)("ladle_in_time")).ToShortDateString + "  " + Right(("0" + CDate(dt.Rows(0)("ladle_in_time")).Hour.ToString), 2) + ":" + Right(("0" + CDate(dt.Rows(0)("ladle_in_time")).Minute.ToString), 2)
                    txtLadle_in_tank_time.Text = Right(("0" + CDate(dt.Rows(0)("ladle_in_time")).Hour.ToString), 2) + ":" + Right(("0" + CDate(dt.Rows(0)("ladle_in_time")).Minute.ToString), 2)
                Catch exp As Exception
                    CType(Session("PreNPost"), RWF.PreNPostPouring).LadleInTime = CDate("01/01/1900").ToString + "  " + "00:00"
                    txtLadle_in_tank_time.Text = "00:00"
                End Try
                '''
                If txtLadle_in_tank_time.Text = "00:00" Then
                    txtLadle_in_tank_time.Text = ""
                End If
                '''
                Try
                    CType(Session("PreNPost"), RWF.PreNPostPouring).IstImmersionTime = CDate(dt.Rows(0)("tube1_immersion1_time")).ToShortDateString + "  " + IIf(IsDBNull(dt.Rows(0)("tube1_immersion1_time")), "00:00", Right(("0" + CDate(dt.Rows(0)("tube1_immersion1_time")).Hour.ToString), 2) + ":" + Right(("0" + CDate(dt.Rows(0)("tube1_immersion1_time")).Minute.ToString), 2))
                    txtImmer1_time.Text = IIf(IsDBNull(dt.Rows(0)("tube1_immersion1_time")), "00:00", Right(("0" + CDate(dt.Rows(0)("tube1_immersion1_time")).Hour.ToString), 2) + ":" + Right(("0" + CDate(dt.Rows(0)("tube1_immersion1_time")).Minute.ToString), 2))
                Catch exp As Exception
                    CType(Session("PreNPost"), RWF.PreNPostPouring).IstImmersionTime = CDate("01/01/1900").ToString + "  " + "00:00"
                    txtImmer1_time.Text = "00:00"
                End Try
                '''
                If txtImmer1_time.Text = "00:00" Then
                    txtImmer1_time.Text = ""
                End If
                Try
                    CType(Session("PreNPost"), RWF.PreNPostPouring).IIndImmersionTime = CDate(dt.Rows(0)("tube1_immersion2_time")).ToShortDateString + "  " + IIf(IsDBNull(dt.Rows(0)("tube1_immersion2_time")), "00:00", Right(("0" + CDate(dt.Rows(0)("tube1_immersion2_time")).Hour.ToString), 2) + ":" + Right(("0" + CDate(dt.Rows(0)("tube1_immersion2_time")).Minute.ToString), 2))
                    txtImmer2_time.Text = IIf(IsDBNull(dt.Rows(0)("tube1_immersion2_time")), "00:00", Right(("0" + CDate(dt.Rows(0)("tube1_immersion2_time")).Hour.ToString), 2) + ":" + Right(("0" + CDate(dt.Rows(0)("tube1_immersion2_time")).Minute.ToString), 2))
                Catch exp As Exception
                    CType(Session("PreNPost"), RWF.PreNPostPouring).IIndImmersionTime = CDate("01/01/1900").ToString + "  " + "00:00"
                    txtImmer2_time.Text = "00:00"
                End Try
                '''
                If txtImmer2_time.Text = "00:00" Then
                    txtImmer2_time.Text = ""
                End If
                '''
                Try
                    CType(Session("PreNPost"), RWF.PreNPostPouring).IIIrdImmersionTime = CDate(dt.Rows(0)("tube1_immersion3_time")).ToShortDateString + "  " + IIf(IsDBNull(dt.Rows(0)("tube1_immersion3_time")), "00:00", Right(("0" + CDate(dt.Rows(0)("tube1_immersion3_time")).Hour.ToString), 2) + ":" + Right(("0" + CDate(dt.Rows(0)("tube1_immersion3_time")).Minute.ToString), 2))
                    txtImmer3_time.Text = IIf(IsDBNull(dt.Rows(0)("tube1_immersion3_time")), "00:00", Right(("0" + CDate(dt.Rows(0)("tube1_immersion3_time")).Hour.ToString), 2) + ":" + Right(("0" + CDate(dt.Rows(0)("tube1_immersion3_time")).Minute.ToString), 2))
                Catch exp As Exception
                    CType(Session("PreNPost"), RWF.PreNPostPouring).IIIrdImmersionTime = CDate("01/01/1900").ToString + "  " + "00:00"
                    txtImmer3_time.Text = "00:00"
                End Try
                '''
                If txtImmer3_time.Text = "00:00" Then
                    txtImmer3_time.Text = ""
                End If
                '''
                CType(Session("PreNPost"), RWF.PreNPostPouring).IIIrdImmersionTemp = IIf(IsDBNull(dt.Rows(0)("tube1_immersion3_temperature")), "", dt.Rows(0)("tube1_immersion3_temperature"))
                txtImmer3_temperature.Text = CType(Session("PreNPost"), RWF.PreNPostPouring).IIIrdImmersionTemp
                CType(Session("PreNPost"), RWF.PreNPostPouring).IIndImmersionTemp = IIf(IsDBNull(dt.Rows(0)("tube1_immersion2_temperature")), "", dt.Rows(0)("tube1_immersion2_temperature"))
                txtImmer2_temperature.Text = CType(Session("PreNPost"), RWF.PreNPostPouring).IIndImmersionTemp
                CType(Session("PreNPost"), RWF.PreNPostPouring).IstImmersionTemp = IIf(IsDBNull(dt.Rows(0)("tube1_immersion1_temperature")), "", dt.Rows(0)("tube1_immersion1_temperature"))
                txtImmer1_temperature.Text = CType(Session("PreNPost"), RWF.PreNPostPouring).IstImmersionTemp
                CType(Session("PreNPost"), RWF.PreNPostPouring).LadleTemp = IIf(IsDBNull(dt.Rows(0)("ladle_temp")), "", dt.Rows(0)("ladle_temp"))

                CType(Session("PreNPost"), RWF.PreNPostPouring).Plunser_pressure = IIf(IsDBNull(dt.Rows(0)("plunser_pressure")), "", dt.Rows(0)("plunser_pressure"))
                plgpressure.Text = CType(Session("PreNPost"), RWF.PreNPostPouring).Plunser_pressure ''

                Try
                    CType(Session("PreNPost"), RWF.PreNPostPouring).Pouring_start_time = CDate(dt.Rows(0)("pouring_start_time")).ToShortDateString + "  " + IIf(IsDBNull(dt.Rows(0)("pouring_start_time")), "00:00", Right(("0" + CDate(dt.Rows(0)("pouring_start_time")).Hour.ToString), 2) + ":" + Right(("0" + CDate(dt.Rows(0)("pouring_start_time")).Minute.ToString), 2))
                    txtPourStartTime.Text = IIf(IsDBNull(dt.Rows(0)("pouring_start_time")), "00:00", Right(("0" + CDate(dt.Rows(0)("pouring_start_time")).Hour.ToString), 2) + ":" + Right(("0" + CDate(dt.Rows(0)("pouring_start_time")).Minute.ToString), 2))
                Catch exp As Exception
                    CType(Session("PreNPost"), RWF.PreNPostPouring).Pouring_start_time = CDate("01/01/1900").ToString + "  " + "00:00"
                    txtPourStartTime.Text = "00:00"
                End Try


                If txtImmer3_temperature.Text = 0 Then txtImmer3_temperature.Text = ""
                If txtImmer2_temperature.Text = 0 Then txtImmer2_temperature.Text = ""
                If txtImmer1_temperature.Text = 0 Then txtImmer1_temperature.Text = ""
                '''
                i = 0
                txtSing_condition.ClearSelection()
                For i = 0 To txtSing_condition.Items.Count - 1
                    If Trim(dt.Rows(0)("slag_condition")) = txtSing_condition.Items(i).Text Then
                        txtSing_condition.Items(i).Selected = True
                        CType(Session("PreNPost"), RWF.PreNPostPouring).Slag = Trim(dt.Rows(0)("slag_condition"))
                        Exit For
                    End If
                Next
                i = 0
                txtStop_support.ClearSelection()
                For i = 0 To txtStop_support.Items.Count - 1
                    If Trim(dt.Rows(0)("stop_support")) = txtStop_support.Items(i).Text Then
                        txtStop_support.Items(i).Selected = True
                        CType(Session("PreNPost"), RWF.PreNPostPouring).StopperHead = Trim(dt.Rows(0)("stop_support"))
                        Exit For
                    End If
                Next
                'CType(Session("PreNPost"), RWF.PreNPostPouring).Riser_weight = IIf(IsDBNull(dt.Rows(0)("riser_weight")), "", dt.Rows(0)("riser_weight"))
                'txtRiser_weight.Text = CType(Session("PreNPost"), RWF.PreNPostPouring).Riser_weight

                CType(Session("PreNPost"), RWF.PreNPostPouring).MetalRecd = IIf(IsDBNull(dt.Rows(0)("metal_recieved")), "", dt.Rows(0)("metal_recieved"))
                txtMetalRecieved.Text = CType(Session("PreNPost"), RWF.PreNPostPouring).MetalRecd
                CType(Session("PreNPost"), RWF.PreNPostPouring).Tube1No = IIf(IsDBNull(dt.Rows(0)("tube_no_1")), "", dt.Rows(0)("tube_no_1"))
                txtTubeNo1.Text = CType(Session("PreNPost"), RWF.PreNPostPouring).Tube1No
                CType(Session("PreNPost"), RWF.PreNPostPouring).Tube2No = IIf(IsDBNull(dt.Rows(0)("tube_no_2")), "", dt.Rows(0)("tube_no_2"))
                txtTubeNo2.Text = CType(Session("PreNPost"), RWF.PreNPostPouring).Tube2No
                CType(Session("PreNPost"), RWF.PreNPostPouring).Tube3No = IIf(IsDBNull(dt.Rows(0)("tube_no_3")), "", dt.Rows(0)("tube_no_3"))
                txtTubeNo3.Text = CType(Session("PreNPost"), RWF.PreNPostPouring).Tube3No
                CType(Session("PreNPost"), RWF.PreNPostPouring).Tube1_mfg = IIf(IsDBNull(dt.Rows(0)("tube1_mfg")), "", dt.Rows(0)("tube1_mfg"))
                txtTube1_mfg.Text = CType(Session("PreNPost"), RWF.PreNPostPouring).Tube1_mfg
                CType(Session("PreNPost"), RWF.PreNPostPouring).Tube2_mfg = IIf(IsDBNull(dt.Rows(0)("tube2_mfg")), "", dt.Rows(0)("tube2_mfg"))
                txtTube2_mfg.Text = CType(Session("PreNPost"), RWF.PreNPostPouring).Tube2_mfg
                CType(Session("PreNPost"), RWF.PreNPostPouring).Tube3_mfg = IIf(IsDBNull(dt.Rows(0)("tube3_mfg")), "", dt.Rows(0)("tube3_mfg"))
                txtTube3_mfg.Text = CType(Session("PreNPost"), RWF.PreNPostPouring).Tube3_mfg
                CType(Session("PreNPost"), RWF.PreNPostPouring).Tube1_life = IIf(IsDBNull(dt.Rows(0)("tube1_life")), "", dt.Rows(0)("tube1_life"))
                txtTube1_life.Text = CType(Session("PreNPost"), RWF.PreNPostPouring).Tube1_life
                CType(Session("PreNPost"), RWF.PreNPostPouring).Tube2_life = IIf(IsDBNull(dt.Rows(0)("tube2_life")), "", dt.Rows(0)("tube2_life"))
                txtTube2_life.Text = CType(Session("PreNPost"), RWF.PreNPostPouring).Tube2_life
                CType(Session("PreNPost"), RWF.PreNPostPouring).Tube3_life = IIf(IsDBNull(dt.Rows(0)("tube3_life")), "", dt.Rows(0)("tube3_life"))
                txtTube3_life.Text = CType(Session("PreNPost"), RWF.PreNPostPouring).Tube3_life
                '''
                If txtTube1_life.Text = 0 Then txtTube1_life.Text = ""
                If txtTube2_life.Text = 0 Then txtTube2_life.Text = ""
                If txtTube3_life.Text = 0 Then txtTube3_life.Text = ""

                CType(Session("PreNPost"), RWF.PreNPostPouring).LMLevel = IIf(IsDBNull(dt.Rows(0)("ladle_metal_level")), "", dt.Rows(0)("ladle_metal_level"))
                Ddlmtllvl.SelectedItem.Text = CType(Session("PreNPost"), RWF.PreNPostPouring).LMLevel
                CType(Session("PreNPost"), RWF.PreNPostPouring).LIMetal = IIf(IsDBNull(dt.Rows(0)("ladle_insl")), "", dt.Rows(0)("ladle_insl"))


                Try
                    txtLITDate.Text = IIf(IsDBNull(dt.Rows(0)("ladle_in_time")), CDate(txtCastDate.Text), CDate(dt.Rows(0)("ladle_in_time")).ToShortDateString)
                Catch exp As Exception
                    txtLITDate.Text = CDate(txtCastDate.Text)
                End Try
                Try
                    txtFImm.Text = IIf(IsDBNull(dt.Rows(0)("tube1_immersion1_time")), CDate(txtCastDate.Text), CDate(dt.Rows(0)("tube1_immersion1_time")).ToShortDateString)
                Catch exp As Exception
                    txtFImm.Text = CDate(txtCastDate.Text)
                End Try
                Try
                    txtSImm.Text = IIf(IsDBNull(dt.Rows(0)("tube1_immersion2_time")), CDate(txtCastDate.Text), CDate(dt.Rows(0)("tube1_immersion2_time")).ToShortDateString)
                Catch exp As Exception
                    txtSImm.Text = CDate(txtCastDate.Text)
                End Try
                Try
                    txtTImm.Text = IIf(IsDBNull(dt.Rows(0)("tube1_immersion3_time")), CDate(txtCastDate.Text), CDate(dt.Rows(0)("tube1_immersion3_time")).ToShortDateString)
                Catch exp As Exception
                    txtTImm.Text = CDate(txtCastDate.Text)
                End Try
                i = Nothing
            Else
                btnSave.Text = "Save"
                txtLadlelift_time.Text = "00:00"
                txtLadle_in_tank_time.Text = "00:00"
                txtImmer1_time.Text = "00:00"
                txtImmer2_time.Text = "00:00"
                txtImmer3_time.Text = "00:00"
                'txtTube_intime.Text = "00:00"
                'txtTube_outtime.Text = "00:00"
                ''''
                txtLadlelift_time.Text = ""
                txtLadle_in_tank_time.Text = ""
                txtImmer1_time.Text = ""
                txtImmer2_time.Text = ""
                txtImmer3_time.Text = ""
                'txtTube_intime.Text = ""
                'txtTube_outtime.Text = ""
                ''''
                txtCastDate.Text = RWF.tables.GetWorkingDate(Session("Group"))
                txtLLTDate.Text = Now.Date
                txtLITDate.Text = Now.Date
                txtFImm.Text = Now.Date
                txtSImm.Text = Now.Date
                txtTImm.Text = Now.Date
                'txtTITDate.Text = Now.Date
                'txtTOTDate.Text = Now.Date

                '''''''''''''removed
                'CType(Session("PreNPost"), RWF.PreNPostPouring).LadleInTime = CDate(txtCastDate.Text).ToString + "  " + "00:00"
                'CType(Session("PreNPost"), RWF.PreNPostPouring).LLT = CDate(txtCastDate.Text).ToString + "  " + "00:00"
                'CType(Session("PreNPost"), RWF.PreNPostPouring).IstImmersionTime = CDate(txtCastDate.Text).ToString + "  " + "00:00"
                'CType(Session("PreNPost"), RWF.PreNPostPouring).IIndImmersionTime = CDate(txtCastDate.Text).ToString + "  " + "00:00"
                'CType(Session("PreNPost"), RWF.PreNPostPouring).IIIrdImmersionTime = CDate(txtCastDate.Text).ToString + "  " + "00:00"
                'CType(Session("PreNPost"), RWF.PreNPostPouring).TubeInTime = CDate(txtCastDate.Text).ToString + "  " + "00:00"
                'CType(Session("PreNPost"), RWF.PreNPostPouring).TubeOutTime = CDate(txtCastDate.Text).ToString + "  " + "00:00"
            End If


            ' txtPourStartDate.Text = CDate(txtCastDate.Text)
            txtPourStartTime.Text = ""
            'txtPourStartTemp.Text = ""
            Dim dt1 As DataTable
            dt1 = RWF.Pouring.PouringStartTime(txtHeatNumber.Text)
            If dt1.Rows.Count > 0 Then
                txtPourStartDate.Text = CDate(dt1.Rows(0)("pouring_start_time")).Date

                txtPourStartTime.Text = IIf(IsDBNull(dt1.Rows(0)("pouring_start_time")), "", Right(("0" + CDate(dt1.Rows(0)("pouring_start_time")).Hour.ToString), 2) + ":" + Right(("0" + CDate(dt1.Rows(0)("pouring_start_time")).Minute.ToString), 2))

                'txtPourStartTemp.Text = IIf(IsDBNull(dt1.Rows(0)("PourStartTemp")), "", dt1.Rows(0)("PourStartTemp"))
                If txtPourStartTime.Text = "00:00" Then txtPourStartTime.Text = ""
                'If txtPourStartTemp.Text = 0 Then txtPourStartTemp.Text = ""
            End If
            dt1 = Nothing
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
            dt = Nothing
        End Try
    End Sub

    Private Sub setPre()
        txtCastDate.Text = RWF.tables.GetWorkingDate(Session("Group"))
        txtLLTDate.Text = Now.Date
        txtFImm.Text = Now.Date
        txtSImm.Text = Now.Date
        txtTImm.Text = Now.Date
        txtLITDate.Text = Now.Date
        'txtTITDate.Text = Now.Date
        'txtTOTDate.Text = Now.Date
        txtLadle_in_tank_time.Text = Right(("0" + Now.Hour.ToString), 2) + ":" + Right(("0" + Now.Minute.ToString), 2)
        txtImmer1_time.Text = Right(("0" + Now.Hour.ToString), 2) + ":" + Right(("0" + Now.Minute.ToString), 2)
        txtImmer2_time.Text = Right(("0" + Now.Hour.ToString), 2) + ":" + Right(("0" + Now.Minute.ToString), 2)
        txtImmer3_time.Text = Right(("0" + Now.Hour.ToString), 2) + ":" + Right(("0" + Now.Minute.ToString), 2)
        'txtTube_outtime.Text = Right(("0" + Now.Hour.ToString), 2) + ":" + Right(("0" + Now.Minute.ToString), 2)
        'txtTube_intime.Text = Right(("0" + Now.Hour.ToString), 2) + ":" + Right(("0" + Now.Minute.ToString), 2)
        txtPourStartTime.Text = Right(("0" + Now.Hour.ToString), 2) + ":" + Right(("0" + Now.Minute.ToString), 2)

        'txtTube_intime.Text = Right(("0" + Now.Hour.ToString), 2) + ":" + Right(("0" + Now.Minute.ToString), 2)
        txtLadlelift_time.Text = Right(("0" + Now.Hour.ToString), 2) + ":" + Right(("0" + Now.Minute.ToString), 2)

        txtPourStartDate.Text = CDate(txtCastDate.Text)
        'Try
        '    txtHeatNumber.Text = RWF.tables.GetLatestPrePourHeat
        'Catch exp As Exception
        '    lblMessage.Text = exp.Message
        'End Try
        populateladleData()
        populateladletimedata()
        populateladledetail()

    End Sub


    Private Function GetCumulativeCnt() As Integer
        Try
            GetCumulativeCnt = RWF.tables.GetCumulativeCnt(txtHeatNumber.Text)
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

    Private Sub GetHeatWoNo()
        Dim dt As New DataTable()
        dt = RWF.tables.GetMeltingWO(Val(txtHeatNumber.Text))
        If dt.Rows.Count > 0 Then
            lblWoval1.Text = IIf(IsDBNull(dt.Rows(0)("WO")), "", dt.Rows(0)("WO"))
            lblWODesc1.Text = IIf(IsDBNull(dt.Rows(0)("WODesc")), "", dt.Rows(0)("WODesc"))
        Else
            lblWoval1.Text = ""
            lblWODesc1.Text = ""
        End If
        dt = Nothing
    End Sub




    Private Sub txtCastDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lblMessage.Text = ""
        Try
            If CDate(txtCastDate.Text) > Now Then
                lblMessage.Text = "CastDate Can't Be Later Than Today."
                txtCastDate.Text = ""
            Else
                If RWF.tables.CheckWorkingDate(Session("Group"), CDate(txtCastDate.Text)) Then
                    lblMessage.Text = "Date Cast is declared as holiday by PCO. Contact PCO !"
                    txtCastDate.Text = ""
                    Exit Sub
                Else
                    CType(Session("PreNPost"), RWF.PreNPostPouring).CastDate = CDate(txtCastDate.Text)
                    SetFocus(txtOperator_mould)
                End If
            End If
        Catch
            lblMessage.Text = "Enter date in 'dd/mm/yyyy' Format"
            txtCastDate.Text = ""
        End Try
    End Sub



    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        savepre()

    End Sub


    Public Function savepre()
        Dim heat As Integer, dateCastDate As DateTime, Furnace As String, Operator1 As String, SIC As String, JMPCover As String, LLT As DateTime, IstImmersionTime As DateTime, IIndImmersionTime As DateTime, IIIrdImmersionTime As DateTime, ladle_insl As Integer, IstImmersionTemp As Integer, IIndImmersionTemp As Integer, IIIrdImmersionTemp As Integer, ALStars As Integer, ALDipTemp As Integer, Slag As String, StopperHead As String, Riser_weight As String, Tube1_mfg As String, Tube2_mfg As String, Tube3_mfg As String, Tube1_life As String, Tube2_life As Integer, Tube3_life As Integer, PourTankNo As Integer, LMLevel As String, LadleInTime As DateTime, LadleTemp As Integer, TubeInTime As DateTime, TubeOutTime As DateTime, MetalRecd As Double, D13 As Integer, D14 As Integer, C20 As Integer, C21 As Integer, pouring_start_time As DateTime, plunser_pressure As Double, tprobe_height As Double
        heat = Val(txtHeatNumber.Text)
        ' dateCastDate = DateTime.Now()
        Dim doc As DateTime = CDate(txtCastDate.Text)
        SIC = txtShift_supervisor.Text
        Furnace = rblGroup.SelectedItem.Text
        JMPCover = txtJMP_cover.SelectedItem.Text
        Dim LLT1 As DateTime = CDate(txtLLTDate.Text + " " & txtLadlelift_time.Text)

        'LLT = CDate(lltstr) ' "yyyy-MM-dd HH:mm tt")
        'IstImmersionTime = DateTime.Now()
        'IIndImmersionTime = DateTime.Now()
        'IIIrdImmersionTime = DateTime.Now()
        IstImmersionTemp = Val(txtImmer1_temperature.Text)
        IIndImmersionTemp = Val(txtImmer2_temperature.Text)
        IIIrdImmersionTemp = Val(txtImmer3_temperature.Text)

        Dim fit As DateTime = CDate(txtFImm.Text + " " & txtImmer1_time.Text)
        Dim sit As DateTime = CDate(txtSImm.Text + " " & txtImmer2_time.Text)
        Dim tit As DateTime = CDate(txtTImm.Text + " " & txtImmer3_time.Text)
        Dim pst As DateTime = CDate(txtPourStartDate.Text + " " & txtPourStartTime.Text)
        'Dim tbit As DateTime = CDate(txtTITDate.Text + " " & txtTube_intime.Text)
        'Dim tbot As DateTime = CDate(txtTOTDate.Text + " " & txtTube_outtime.Text)


        ALStars = Val(txtAL_stars.Text)
        ALDipTemp = Val(txtALdip_temp.Text)
        Slag = txtSing_condition.SelectedItem.Text
        StopperHead = txtStop_support.SelectedItem.Text
        'Riser_weight = Val(txtRiser_weight.Text)
        Tube1_mfg = txtTube1_mfg.Text
        Tube2_mfg = txtTube2_mfg.Text
        Tube3_mfg = txtTube3_mfg.Text
        Tube1_life = Val(txtTube1_life.Text)
        Tube2_life = Val(txtTube2_life.Text)
        Tube3_life = Val(txtTube3_life.Text)
        PourTankNo = txtPour_tankNo.SelectedItem.Value
        LMLevel = Ddlmtllvl.SelectedItem.Text
        'ladle_insl = Val(txtldlInsl_metal.Text)
        'TubeInTime = DateTime.Now()
        'TubeOutTime = DateTime.Now()
        LadleInTime = DateTime.Now()
        'LadleTemp = Val(txt_ladle_in_tank_temp.Text)
        MetalRecd = Val(txtMetalRecieved.Text)
        D14 = Val(txtOT14drag.Text)
        D13 = Val(txtOT13drag.Text)
        C20 = Val(txtOT20cope.Text)
        C21 = Val(txtOT21cope.Text)
        plunser_pressure = Val(plgpressure.Text)
        tprobe_height = Val(prbheight.Text)

        Dim done As Boolean
        Dim done2 As Boolean
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim cmd2 As New SqlCommand
        If Not RWF.tables.CheckHeat_pre(txtHeatNumber.Text) Then
            Try
                con.ConnectionString = "Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;Persist Security Info=True;User Id=sa;Password=sadev123"
                con.Open()
                cmd.Connection = con
                cmd2.Connection = con


                cmd.CommandText = " insert into mm_pre_pouring ( cast_date , heat_number , furnace_code , " &
                    " operator_mould , shift_supervisor , jmp_cover1 , ladle_lift_time , tube1_immersion1_time , " &
                    " tube1_immersion1_temperature , tube1_immersion2_time , tube1_immersion2_temperature , " &
                    " tube1_immersion3_time , tube1_immersion3_temperature , aluminium_stars , " &
                    " aluminium_dip_temperature , slag_condition , stop_support ,  " &
                    " riser_weight , tube1_mfg , tube2_mfg , tube3_mfg , tube1_life , tube2_life , tube3_life , " &
                    " pouring_tank_number , ladle_metal_level , ladle_insl , tube1_in_time , tube2_in_time , " &
                    " tube3_in_time , tube1_out_time , tube2_out_time , tube3_out_time , ladle_in_time , " &
                    " ladle_temp , metal_recieved , D13, D14, C20, C21, pouring_start_time, plunser_pressure, " &
                    "probe_height,jmporing ) " &
                    " values ( '" & Format(CDate(doc), "MM/dd/yyyy HH:mm") & "' , '" & Val(txtHeatNumber.Text) & "', '" & rblGroup.SelectedItem.Text & "', 
                    '" & txtOperator_mould.Text & "', '" & txtShift_supervisor.Text & "', '" & txtJMP_cover.SelectedItem.Text & "', '" & Format(CDate(LLT1), "MM/dd/yyyy HH:mm") & "' ,'" & Format(CDate(fit), "MM/dd/yyyy HH:mm") & "' , 
                    '" & Val(txtImmer1_temperature.Text) & "', '" & Format(CDate(sit), "MM/dd/yyyy HH:mm") & "'  , '" & Val(txtImmer2_temperature.Text) & "', '" & Format(CDate(tit), "MM/dd/yyyy HH:mm") & "' , '" & Val(txtImmer3_temperature.Text) & "','" & Val(txtAL_stars.Text) & "', 
                    '" & Val(txtALdip_temp.Text) & "', ' " & txtSing_condition.SelectedItem.Text & "', '" & txtStop_support.SelectedItem.Text & "', 
                    0, '" & txtTube1_mfg.Text & "','" & txtTube2_mfg.Text & "', '" & txtTube3_mfg.Text & "', 
		          '" & Val(txtTube1_life.Text) & "', '" & Val(txtTube2_life.Text) & "', '" & Val(txtTube3_life.Text) & "',
                    '" & txtPour_tankNo.SelectedItem.Value & "', '" & Ddlmtllvl.SelectedItem.Text & "', 0, getdate() , getdate() , 
                    getdate() , getdate() ,getdate() , getdate() , getdate() , 
                    0, '" & Val(txtMetalRecieved.Text) & "', '" & Val(txtOT13drag.Text) & "', '" & Val(txtOT14drag.Text) & "', '" & Val(txtOT20cope.Text) & "', '" & Val(txtOT21cope.Text) & "', 
                    getdate() ,'" & Val(plgpressure.Text) & "', '" & Val(prbheight.Text) & "', '" & jmporing.SelectedItem.Text & "')"
                lblMessage.Text = "Data Saved for this Heat " & txtHeatNumber.Text



                'If cmd.ExecuteNonQuery() = 1 Then done = True
                cmd2.CommandText = " insert into mm_ladle_details(heat_number, llt) values ( '" & Val(txtHeatNumber.Text) & "','" & Format(CDate(LLT1), "MM/dd/yyyy HH:mm") & "')"
                'If cmd2.ExecuteNonQuery() = 1 Then done2 = True
                If cmd.ExecuteNonQuery() = 1 And cmd2.ExecuteNonQuery() = 1 Then
                    done = True
                End If

            Catch exp As Exception
                Throw New Exception(exp.Message)
                lblMessage.Text = "Check the values"
            Finally

                con.Close()
            End Try
            Return done
        End If

        lblMessage.Text = "Data Alreadedy feeded"
        btnSave.Text = "Update"

        If btnSave.Text = "Update" Then
            Try
                con.ConnectionString = "Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;Persist Security Info=True;User Id=sa;Password=sadev123"
                con.Open()
                cmd.Connection = con
                cmd.CommandText = " update mm_pre_pouring set  furnace_code = '" & rblGroup.SelectedItem.Text & "', operator_mould = '" & txtOperator_mould.Text & "' , " &
                        " shift_supervisor = '" & txtShift_supervisor.Text & "' , jmp_cover1 =  '" & txtJMP_cover.SelectedItem.Text & "' , ladle_lift_time ='" & Format(CDate(LLT1), "MM/dd/yyyy HH:mm") & "'," &
                        " tube1_immersion1_time = '" & Format(CDate(fit), "MM/dd/yyyy HH:mm") & "' , tube1_immersion1_temperature = '" & Val(txtImmer1_temperature.Text) & "' , " &
                        " tube1_immersion2_time ='" & Format(CDate(sit), "MM/dd/yyyy HH:mm") & "' , tube1_immersion2_temperature = '" & Val(txtImmer2_temperature.Text) & "' ," &
                        " tube1_immersion3_time = '" & Format(CDate(tit), "MM/dd/yyyy HH:mm") & "' , tube1_immersion3_temperature = '" & Val(txtImmer3_temperature.Text) & "' , " &
                        " aluminium_stars= '" & Val(txtAL_stars.Text) & "',aluminium_dip_temperature = '" & Val(txtALdip_temp.Text) & "' , " &
                        " slag_condition =' " & txtSing_condition.SelectedItem.Text & "' , stop_support = '" & txtStop_support.SelectedItem.Text & "' , " &
                        " tube1_mfg = '" & txtTube1_mfg.Text & "' , tube2_mfg = '" & txtTube2_mfg.Text & "' , tube3_mfg = '" & txtTube3_mfg.Text & "'," &
                        " tube1_life = '" & Val(txtTube1_life.Text) & "' , tube2_life = '" & Val(txtTube2_life.Text) & "' , tube3_life = '" & Val(txtTube3_life.Text) & "' ," &
                        " pouring_tank_number ='" & txtPour_tankNo.SelectedItem.Value & "' , ladle_metal_level = '" & Ddlmtllvl.SelectedItem.Text & "' , " &
                        " metal_recieved ='" & Val(txtMetalRecieved.Text) & "' ,D13='" & Val(txtOT13drag.Text) & "', D14='" & Val(txtOT14drag.Text) & "', C20='" & Val(txtOT20cope.Text) & "', C21='" & Val(txtOT21cope.Text) & "', " &
                        "  plunser_pressure='" & Val(plgpressure.Text) & "', probe_height='" & Val(prbheight.Text) & "', jmporing='" & jmporing.SelectedItem.Text & "' " &
                        " where heat_number = '" & Val(txtHeatNumber.Text) & "' "
                lblMessage.Text = "Data Updated/Saved for this Heat " & txtHeatNumber.Text
                If cmd.ExecuteNonQuery() = 1 Then done = True

            Catch exp As Exception
                Throw New Exception(exp.Message)
                lblMessage.Text = "Check the values"
            Finally
                con.Close()
            End Try
            Return done


        End If

    End Function

    Private Sub populateladleData()
        Dim dt As DataTable
        dt = RWF.MLDING.LadleWeightswdetails(CInt(txtHeatNumber.Text))
        If dt.Rows.Count > 0 Then
            If IsDBNull(dt.Rows(0)("w1")) = False Then
                Lademptwt.Text = dt.Rows(0)("w1")
            Else
                Lademptwt.Text = ""
            End If

            If IsDBNull(dt.Rows(0)("ladle_number")) = False Then
                Ladno.Text = dt.Rows(0)("ladle_number")
            Else
                Ladno.Text = ""
            End If
            If IsDBNull(dt.Rows(0)("life")) = False Then
                Ladlife.Text = dt.Rows(0)("life")
            Else
                Ladlife.Text = ""
            End If
        Else
            lblMessage.Text = "No data exists for this Heat " & txtHeatNumber.Text

        End If
        dt = Nothing
    End Sub

    Protected Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        btnSave.Text = "Save"
    End Sub

    'Protected Sub txtHeatNumber_TextChanged(sender As Object, e As EventArgs) Handles txtHeatNumber.TextChanged
    '    lblMessage.Text = ""
    '    'GetHeatWoNo()
    '    setPre()

    '    If RWF.tables.CheckHeatPrePouring(Val(txtHeatNumber.Text)) Then
    '        Session("PreNPost") = Nothing
    '        Dim PreNPost As New RWF.PreNPostPouring(Val(txtHeatNumber.Text))
    '        Session("PreNPost") = PreNPost
    '        Try
    '            GetHeatDetails()
    '            GetHeatWoNo()
    '        Catch exp As Exception
    '            lblMessage.Text = exp.Message
    '        End Try
    '        PreNPost = Nothing
    '    Else

    '        lblMessage.Text = "InValid Heat Number '" & txtHeatNumber.Text & "'"
    '        txtHeatNumber.Text = ""
    '    End If
    'End Sub

    Protected Sub txtHeatNumber_TextChanged(sender As Object, e As EventArgs) Handles txtHeatNumber.TextChanged
        lblMessage.Text = ""
        'GetHeatWoNo()
        setPre()
        If RWF.tables.CheckHeat(Val(txtHeatNumber.Text)) Then
            Session("PreNPost") = Nothing
            Dim PreNPost As New RWF.PreNPostPouring(Val(txtHeatNumber.Text))
            Session("PreNPost") = PreNPost
            Try
                GetHeatDetails()
                GetHeatWoNo()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
            PreNPost = Nothing
        Else
            lblMessage.Text = "InValid Heat Number '" & txtHeatNumber.Text & "'"
            txtHeatNumber.Text = ""
        End If
    End Sub

    Private Sub populateladledetail()
        Dim dt As DataTable


        dt = RWF.MLDING.LadleDetail(CInt(txtHeatNumber.Text))
        If dt.Rows.Count > 0 Then

            If IsDBNull(dt.Rows(0)("llt")) = False Then
                lltstr = dt.Rows(0)("llt")
                txtLadlelift_time.Text = Right(LTrim(lltstr), 9)
                txtLLTDate.Text = Left(LTrim(lltstr), 10)
            Else
                txtLLTDate.Text = ""
            End If

        Else
            lblMessage.Text = "No data exists for this Heat " & txtHeatNumber.Text

        End If
        dt = Nothing
    End Sub


    Private Sub populateladletimedata()
        Dim dt As DataTable


        dt = RWF.MLDING.LadleWtempdetails(CInt(txtHeatNumber.Text))
        If dt.Rows.Count > 0 Then
            If IsDBNull(dt.Rows(0)("jmp_aluminium_star")) = False Then
                txtAL_stars.Text = dt.Rows(0)("jmp_aluminium_star")
            Else
                txtAL_stars.Text = ""
            End If

            If IsDBNull(dt.Rows(0)("heat_tapped")) = False Then
                lltstr = dt.Rows(0)("heat_tapped")
                txtLadlelift_time.Text = Right(LTrim(lltstr), 9)
                txtLLTDate.Text = Left(LTrim(lltstr), 10)
            Else
                txtLLTDate.Text = ""
            End If
            If IsDBNull(dt.Rows(0)("tap_time")) = False Then
                txtladtaptime.Text = dt.Rows(0)("tap_time")
            Else
                txtladtaptime.Text = ""
            End If
        Else
            lblMessage.Text = "No data exists for this Heat " & txtHeatNumber.Text

        End If
        dt = Nothing
    End Sub


End Class