Public Class MeltingProcessBoot
    Inherits System.Web.UI.Page
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents pnlAll As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlSheet1 As System.Web.UI.WebControls.Panel
    Protected WithEvents txtShift_incharge As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFurnace_Operator As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblShift As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtFunace_life As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtBank As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtSidewall_lo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtSidewall_up As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtFurnace_bottom As System.Web.UI.WebControls.DropDownList
    Protected WithEvents TXTDRM As System.Web.UI.WebControls.TextBox
    Protected WithEvents TXTBRICK As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtLadle_sidewall As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtLadle_bottom As System.Web.UI.WebControls.DropDownList
    Protected WithEvents RangeValidator1 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents txtLadle_life As System.Web.UI.WebControls.TextBox
    Protected WithEvents li As System.Web.UI.WebControls.Label
    Protected WithEvents Ht As System.Web.UI.WebControls.Label
    Protected WithEvents rngvalLadleNo As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents txtLadle_number As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtw1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRoof_outer As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRoof_delta As System.Web.UI.WebControls.TextBox
    Protected WithEvents RangeValidator3 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents txtRoof_life As System.Web.UI.WebControls.TextBox
    Protected WithEvents rfvld1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtRoof_number As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtBucket_enteredby3 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtBucket_number3 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtBucket_enteredby2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtBucket_number2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtBucket_enteredby As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtBucket_number As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEtip_e3 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEtip_e2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEtip_e1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEadded_e3 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEadded_e2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEadded_e1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEmake_e3 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEmake_e2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEmake_e1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFgmi_quantity As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFgmi_make As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtFWrmi_quantity As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFWrmi_make As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtFrmi_quantity As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFrmi_make As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtLMS As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtWheel_cut As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRiserhub As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPygmy_pot As System.Web.UI.WebControls.TextBox
    'Protected WithEvents txtRail_Cut As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTurningboring As System.Web.UI.WebControls.TextBox
    'Protected WithEvents txtAxle_cut As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtHot_heal As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTotal As System.Web.UI.WebControls.TextBox
    'Protected WithEvents txtAle_end As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtWheel As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnClear As System.Web.UI.WebControls.Button
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents txtNMclime As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNMgdust As System.Web.UI.WebControls.TextBox
    Protected WithEvents pnlSheet2 As System.Web.UI.WebControls.Panel
    Protected WithEvents txtfCalLime As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtLlimestone As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFlimestone As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtLfloor As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFfloor As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtLFeMn As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtfFeMn As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtLfesi As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFfesi As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtLsimn As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtLgdust As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFgdust As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtBucket_charge As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtBucket_chargemet As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRoof_in As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtLevelling As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFurnace_inspection As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRoof_outtime As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCharge_start As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCharge_end As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtremoved_material As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCharge_met As System.Web.UI.WebControls.TextBox
    'Protected WithEvents txtPower_t6 As System.Web.UI.WebControls.TextBox
    'Protected WithEvents txtPower_t2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPower_t12 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPower_t102 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPower_t101 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPower_t8 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPower_t6 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPower_t4 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPower_t12Date As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPower_t102Date As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPower_t101Date As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPower_t8Date As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPower_t6Date As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPower_t4Date As System.Web.UI.WebControls.TextBox
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents pnlSample As System.Web.UI.WebControls.Panel
    Protected WithEvents btnClearSample As System.Web.UI.WebControls.Button
    Protected WithEvents btnSaveSample As System.Web.UI.WebControls.Button
    Protected WithEvents txtHydro As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNitro As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMoly As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtAl As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCr As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSulpher As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPhosph As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSi As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtVen As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCu As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMn As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCarbon As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSampleTemp As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSampleTimeHr As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSampleNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents pnlSheet3 As System.Web.UI.WebControls.Panel
    Protected WithEvents Button3 As System.Web.UI.WebControls.Button
    Protected WithEvents txtTrail_material_methods As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnDelay_clear As System.Web.UI.WebControls.Button
    Protected WithEvents btnDelay_save As System.Web.UI.WebControls.Button
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtToTime As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFromtime As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDelay_code As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblDelay As System.Web.UI.WebControls.Label
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents rdBtnlst2 As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtw2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtLM_level As System.Web.UI.WebControls.TextBox
    Protected WithEvents rgvTT As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents txtTap_laptime As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtLMlevel_final As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSlag_condition As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtTap_end As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtJMP_ALstar As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtJMPstart_temperature As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTap_temperature As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtLpipe_quantity As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtLpipe_make As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtTip_quantity As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTip_make As System.Web.UI.WebControls.DropDownList
    Protected WithEvents rdBtnlst1 As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents cboHeatStatus As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtHeatNo1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtHeatNo2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtHeatNo3 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtHeatNoSample As System.Web.UI.WebControls.TextBox
    'Protected WithEvents txtSampleTimeMin As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFurnace_inspectionDate As System.Web.UI.WebControls.TextBox
    'Protected WithEvents txtPower_t2Date As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRoof_outtimeDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCharge_startDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCharge_endDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtremoved_materialDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtLevellingDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRoof_inDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtBucket_chargemetDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtBucket_chargeDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCharge_metDate As System.Web.UI.WebControls.TextBox
    'Protected WithEvents txtPower_t6Date As System.Web.UI.WebControls.TextBox
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents rblSample As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents btnSheet2 As System.Web.UI.WebControls.Button
    Protected WithEvents btnSheet3 As System.Web.UI.WebControls.Button
    Protected WithEvents txtTapBeginDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTap_beginHr As System.Web.UI.WebControls.TextBox
    'Protected WithEvents txtTap_beginMn As System.Web.UI.WebControls.TextBox
    'Protected WithEvents rblWO As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtFurnace_incharge As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNi As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblFur As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Textbox1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSlpr_cut As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboDelayCd As System.Web.UI.WebControls.DropDownList
    Protected WithEvents dgTipMake As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgLancingPipeMake As System.Web.UI.WebControls.DataGrid
    Protected WithEvents pnlElec As System.Web.UI.WebControls.Panel
    Protected WithEvents rblNo As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblReason As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblBreakage As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtEDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtETime As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtERemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtChargeRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtrsm_dept As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtrsm_contract As System.Web.UI.WebControls.TextBox
    'Protected WithEvents dgDRMMake As System.Web.UI.WebControls.DataGrid
    'Protected WithEvents dgWRMMake As System.Web.UI.WebControls.DataGrid
    'Protected WithEvents dgGMixMake As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtContractNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents dgContractNo As System.Web.UI.WebControls.DataGrid
    Protected WithEvents rblLoc As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents rblSheet As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents FurNo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DDLWO As System.Web.UI.WebControls.DropDownList
    Protected WithEvents FBRMK As System.Web.UI.WebControls.TextBox
    Protected WithEvents FSWURMK As System.Web.UI.WebControls.TextBox
    Protected WithEvents FSWLRMK As System.Web.UI.WebControls.TextBox
    Protected WithEvents FBTRMK As System.Web.UI.WebControls.TextBox
    Protected WithEvents DDLLOF As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DDLSOS As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DDLPOWERON As System.Web.UI.WebControls.DropDownList

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

    Protected Sub dd1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        themeValue = Dd1.SelectedItem.Value
        Response.Redirect(Request.Url.ToString())

    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None
        'Put user code to initialize the page here
        txtDelay_code.Enabled = False
        txtSampleNo.Enabled = False
        txtSampleNo.ReadOnly = True
        Session("UserId") = "111111"
        Session("Group") = "WHLMLT"
        'If Session("UserId") = "074510" Then ----- 26/06/2018 COMMENTED
        '    txtFunace_life.Enabled = True
        '    txtRoof_number.Enabled = True
        '    txtRoof_life.Enabled = True
        'Else
        '    txtFunace_life.Enabled = False
        '    txtRoof_number.Enabled = False
        '    txtRoof_life.Enabled = False
        'End If

        If Page.IsPostBack = False Then
            txtDate.Text = Date.Today
            ViewState("Heat") = RWF.Melting.GenerateHeatNo()
            ViewState("melt_date") = RWF.tables.GetWorkingDate(Session("Group"), ViewState("Heat"))
            SetHeat()
            SetPanel()
        End If

    End Sub

    Private Sub ScrapAccontalCB()
        Try
            Dim dt As DataTable = RWF.Melting.ScrapAccontalCB(CDate(txtDate.Text))
            DataGrid2.DataSource = dt
            DataGrid2.DataBind()
            dt = Nothing
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub GetWOList(ByVal MeltDate As Date)
        Try
            Dim dt As DataTable = RWF.Melting.GetWoNo(CDate(MeltDate))
            ' Radio Button removed 
            'rblWO.DataSource = dt
            'rblWO.DataTextField = dt.Columns(0).ColumnName
            'rblWO.DataValueField = dt.Columns(1).ColumnName
            'rblWO.DataBind()

            ' Drop Down List included
            DDLWO.DataSource = dt
            DDLWO.DataTextField = dt.Columns(0).ColumnName
            DDLWO.DataValueField = dt.Columns(1).ColumnName
            DDLWO.DataBind()

            dt = Nothing
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub SetFocus(ByVal ctrl As Control)
        Dim focusScript As String = "<script language=" & "javascript" & " > " &
        "document.getElementById('" + ctrl.ClientID.ToString.Trim &
        "').focus();</script>"
        Page.RegisterStartupScript("FocusScript", focusScript)
    End Sub

    Private Sub SetHeat()
        txtHeatNo1.Text = CLng(ViewState("Heat"))
        txtHeatNo2.Text = CLng(ViewState("Heat"))
        txtHeatNo3.Text = CLng(ViewState("Heat"))
        txtHeatNoSample.Text = CLng(ViewState("Heat"))
    End Sub

    Private Sub GetMakes()
        Try
            Dim ds As DataSet = RWF.Melting.GetMakes
            'dgTipMake.SelectedIndex = -1
            'dgTipMake.DataSource = ds.Tables(0)
            'dgTipMake.DataBind()

            txtTip_make.DataSource = ds.Tables(0)
            txtTip_make.DataValueField = ds.Tables(0).Columns(0).ColumnName
            txtTip_make.DataBind()

            'dgLancingPipeMake.SelectedIndex = -1
            'dgLancingPipeMake.DataSource = ds.Tables(1)
            'dgLancingPipeMake.DataBind()

            txtLpipe_make.DataSource = ds.Tables(1)
            txtLpipe_make.DataValueField = ds.Tables(1).Columns(0).ColumnName
            txtLpipe_make.DataBind()

            'dgDRMMake.SelectedIndex = -1
            'dgDRMMake.DataSource = ds.Tables(2)
            'dgDRMMake.DataBind()

            ' List box added
            txtFrmi_make.DataSource = ds.Tables(2)
            txtFrmi_make.DataValueField = ds.Tables(2).Columns(0).ColumnName
            txtFrmi_make.DataBind()

            'dgWRMMake.SelectedIndex = -1
            'dgWRMMake.DataSource = ds.Tables(3)
            'dgWRMMake.DataBind()
            ' List box added
            txtFWrmi_make.DataSource = ds.Tables(3)
            txtFWrmi_make.DataValueField = ds.Tables(3).Columns(0).ColumnName
            txtFWrmi_make.DataBind()

            'dgGMixMake.SelectedIndex = -1
            'dgGMixMake.DataSource = ds.Tables(4)
            'dgGMixMake.DataBind()

            ' List box added

            txtFgmi_make.DataSource = ds.Tables(4)
            txtFgmi_make.DataValueField = ds.Tables(4).Columns(0).ColumnName
            txtFgmi_make.DataBind()

            ds = Nothing
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
    End Sub

    Private Sub SetPanel()
        Try
            GetMakes()
            ClearAll()
            Select Case rblSheet.SelectedItem.Value
                Case 1
                    pnlSheet1.Visible = True
                    ViewState("Heat") = Val(txtHeatNo1.Text)
                    GetSheet1Data()
                    ScrapAccontalCB()
                    SetElectrode()
                Case 2
                    pnlSheet2.Visible = True
                    ViewState("Heat") = Val(txtHeatNo2.Text)
                    GetSheet2Data()
                Case 3
                    pnlSheet3.Visible = True
                    ViewState("Heat") = Val(txtHeatNo3.Text)
                    GetSheet3Data()
                Case 4
                    pnlSample.Visible = True
                    ViewState("Heat") = Val(txtHeatNoSample.Text)
                    GetSampleData()
            End Select
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub ClearAll()
        pnlSheet1.Visible = False
        pnlSheet2.Visible = False
        pnlSheet3.Visible = False
        pnlSample.Visible = False
        pnlElec.Visible = False
        ClearP1()
        ClearP2()
        ClearP3()
        ClearSample()
    End Sub

    Private Sub ClearP1()
        clearheader()
        ClearFurnaceCondition()
        ClearLadleDetails()
        ClearRoofDetails()
        ClearBucket()
        ClearHeatSheetCharge()
        ClearElectrode()
        txtNMclime.Text = ""
        txtNMgdust.Text = ""
        ClearFettlingDetails()
    End Sub

    Private Sub ClearP2()
        ClearHeatSheetMelting()
        ClearInprocess_additives()
    End Sub

    Private Sub ClearP3()
        ClearPostMelt()
        ClearDelay()
    End Sub

    Private Sub ClearDelay()
        lblDelay.Text = ""
        txtDelay_code.Text = ""
        txtFromtime.Text = ""
        txtToTime.Text = ""
        txtRemarks.Text = ""
    End Sub

    Private Sub ClearPostMelt()
        cboHeatStatus.SelectedIndex = 0
        rdBtnlst1.SelectedIndex = 0
        ''  txtTip_make.SelectedItem.Text = "Vishal Pipes"
        'If dgTipMake.Items.Count = 1 Then
        '    If txtTip_make.Text.Trim.Length = 0 Then
        '        txtTip_make.Text = dgTipMake.Items(0).Cells(1).Text
        '    End If
        'End If
        'txtLpipe_make.Text = " "
        '' txtLpipe_make.SelectedItem.Text = "Proheat"
        txtTip_quantity.Text = "0"
        txtLpipe_quantity.Text = "0"
        txtTap_temperature.Text = "0"
        txtTapBeginDate.Text = CDate(ViewState("melt_date")).ToShortDateString
        txtTap_beginHr.Text = Right(("0" + Now.Hour.ToString), 2) + ":" + Right(("0" + Now.Minute.ToString), 2)
        ' txtTap_beginMn.Text = Right(("0" + Now.Minute.ToString), 2)
        txtTap_end.Text = "0"
        txtTap_laptime.Text = "1"
        txtJMPstart_temperature.Text = "0"
        txtSlag_condition.SelectedItem.Text = "THIN"
        txtLM_level.Text = "FULL"
        DDLLOF.SelectedItem.Text = "NO"
        DDLSOS.SelectedItem.Text = "DONE"
        txtJMP_ALstar.Text = "0"
        txtLMlevel_final.Text = " "
        rdBtnlst2.SelectedIndex = 1
        txtTrail_material_methods.Text = " "
    End Sub

    Private Sub GetSheet1Data()
        Dim ds As DataSet
        Dim intCntr As Int16
        lblMessage.Text = ""
        FSWURMK.Text = ""
        FSWLRMK.Text = ""
        FBTRMK.Text = ""
        FBRMK.Text = ""
        Try
            ds = RWF.Melting.GetSheet1Data(Val(CLng(ViewState("Heat"))))
            If ds.Tables(0).Rows.Count > 0 Then
                If IsDBNull(ds.Tables(0).Rows(0)("shift_code")) = False Then
                    rblShift.ClearSelection()
                    For intCntr = 0 To rblShift.Items.Count - 1
                        If (Trim(rblShift.Items(intCntr).Value) = Trim(ds.Tables(0).Rows(0)("shift_code"))) Then
                            rblShift.Items(intCntr).Selected = True
                            Exit For
                        End If
                    Next
                End If
                If IsDBNull(Trim(ds.Tables(0).Rows(0)("furnace_code"))) = False Then
                    'rblFur.ClearSelection()
                    FurNo.ClearSelection()
                    Dim i As Int16
                    'For i = 0 To rblFur.Items.Count - 1
                    For i = 0 To FurNo.Items.Count - 1
                        ' If rblFur.Items(i).Text = Trim(ds.Tables(0).Rows(0)("furnace_code")) Then
                        If FurNo.Items(i).Text = Trim(ds.Tables(0).Rows(0)("furnace_code")) Then
                            '  rblFur.Items(i).Selected = True
                            FurNo.Items(i).Selected = True
                            Exit For
                        End If
                    Next
                Else
                    ' rblFur.ClearSelection()
                    FurNo.ClearSelection()
                End If
                If IsDBNull(ds.Tables(0).Rows(0)("melt_date")) = False Then
                    txtDate.Text = ds.Tables(0).Rows(0)("melt_date")
                    ViewState("melt_date") = ds.Tables(0).Rows(0)("melt_date")
                Else
                    txtDate.Text = ""
                End If
                If IsDBNull(ds.Tables(0).Rows(0)("shift_incharge")) = False Then
                    txtShift_incharge.Text = ds.Tables(0).Rows(0)("shift_incharge")
                Else
                    txtShift_incharge.Text = ""
                End If
                If IsDBNull(ds.Tables(0).Rows(0)("furnace_incharge")) = False Then
                    txtFurnace_incharge.Text = ds.Tables(0).Rows(0)("furnace_incharge")
                Else
                    txtFurnace_incharge.Text = ""
                End If
                If IsDBNull(ds.Tables(0).Rows(0)("FurnaceOperator")) = False Then
                    txtFurnace_Operator.Text = ds.Tables(0).Rows(0)("FurnaceOperator")
                Else
                    txtFurnace_Operator.Text = ""
                End If
                intCntr = 0
                GetWOList(CDate(txtDate.Text))
                If IsDBNull(ds.Tables(0).Rows(0)("workorder_number")) = False Then
                    ' Radio button removed----------------------------------
                    'rblWO.ClearSelection()
                    DDLWO.ClearSelection()
                    'For intCntr = 0 To rblWO.Items.Count - 1
                    '    If rblWO.Items(intCntr).Value = Trim(ds.Tables(0).Rows(0)("workorder_number")) Then
                    '        rblWO.Items(intCntr).Selected = True
                    For intCntr = 0 To DDLWO.Items.Count - 1
                        'If rblWO.Items(intCntr).Value = Trim(ds.Tables(0).Rows(0)("workorder_number")) Then
                        If DDLWO.Items(intCntr).Value = Trim(ds.Tables(0).Rows(0)("workorder_number")) Then
                            DDLWO.Items(intCntr).Selected = True
                            Exit For
                        End If
                    Next
                End If
            Else
                txtDate.Text = CDate(ViewState("melt_date"))
                GetWOList(CDate(ViewState("melt_date")))
            End If
            If ds.Tables(1).Rows.Count > 0 Then 'ds.Tables(1).Rows(0)
                If IsDBNull(ds.Tables(1).Rows(0)("bottom")) = False Then
                    txtFurnace_bottom.Text = ds.Tables(1).Rows(0)("bottom")
                Else
                    txtFurnace_bottom.Text = ""
                End If
                If IsDBNull(ds.Tables(1).Rows(0)("sidewall_up")) = False Then
                    txtSidewall_up.Text = ds.Tables(1).Rows(0)("sidewall_up")
                Else
                    txtSidewall_up.Text = ""
                End If
                If IsDBNull(ds.Tables(1).Rows(0)("sidewall_low")) = False Then
                    txtSidewall_lo.Text = ds.Tables(1).Rows(0)("sidewall_low")
                Else
                    txtSidewall_lo.Text = ""
                End If
                If IsDBNull(ds.Tables(1).Rows(0)("bank")) = False Then
                    txtBank.Text = ds.Tables(1).Rows(0)("bank")
                Else
                    txtBank.Text = ""
                End If
                If IsDBNull(ds.Tables(1).Rows(0)("furnace_life")) = False Then
                    txtFunace_life.Text = ds.Tables(1).Rows(0)("furnace_life")
                Else
                    txtFunace_life.Text = ""
                End If
                If IsDBNull(ds.Tables(1).Rows(0)("rmk_sidewall_up")) = False Then
                    FSWURMK.Text = ds.Tables(1).Rows(0)("rmk_sidewall_up")
                Else
                    FSWURMK.Text = ""
                End If

                If IsDBNull(ds.Tables(1).Rows(0)("rmk_sidewall_low")) = False Then
                    FSWLRMK.Text = ds.Tables(1).Rows(0)("rmk_sidewall_low")
                Else
                    FSWLRMK.Text = ""
                End If

                If IsDBNull(ds.Tables(1).Rows(0)("rmk_bank")) = False Then
                    FBTRMK.Text = ds.Tables(1).Rows(0)("rmk_bank")
                Else
                    FBTRMK.Text = ""
                End If


                If IsDBNull(ds.Tables(1).Rows(0)("rmk_bottom")) = False Then
                    FBRMK.Text = ds.Tables(1).Rows(0)("rmk_bottom")
                Else
                    FBRMK.Text = ""
                End If

                If IsDBNull(ds.Tables(1).Rows(0)("DRM_life")) = False Then
                    TXTDRM.Text = ds.Tables(1).Rows(0)("DRM_life")
                Else
                    TXTDRM.Text = ""
                End If

                If IsDBNull(ds.Tables(1).Rows(0)("BRICK_life")) = False Then
                    TXTBRICK.Text = ds.Tables(1).Rows(0)("BRICK_life")
                Else
                    TXTBRICK.Text = ""
                End If
            End If
            If ds.Tables(2).Rows.Count > 0 Then 'ds.Tables(2).Rows(0)
                If IsDBNull(ds.Tables(2).Rows(0)("ladle_number")) = False Then
                    txtLadle_number.Text = LTrim(RTrim(ds.Tables(2).Rows(0)("ladle_number")))
                    li.Text = ""
                    Ht.Text = ""
                Else
                    txtLadle_number.Text = ""
                    li.Text = ""
                End If
                If IsDBNull(ds.Tables(2).Rows(0)("life")) = False Then
                    txtLadle_life.Text = ds.Tables(2).Rows(0)("life")
                Else
                    txtLadle_life.Text = ""
                End If

                If IsDBNull(ds.Tables(2).Rows(0)("bottom")) = False Then
                    'txtLadle_bottom.Text = ds.Tables(2).Rows(0)("bottom")
                    txtLadle_bottom.SelectedIndex = txtLadle_bottom.Items.IndexOf(txtLadle_bottom.Items.FindByValue(ds.Tables(2).Rows(0)("bottom")))
                Else
                    txtLadle_bottom.SelectedItem.Text = "LPH"
                End If

                If IsDBNull(ds.Tables(2).Rows(0)("sidewall")) = False Then
                    txtLadle_sidewall.SelectedItem.Text = ds.Tables(2).Rows(0)("sidewall")
                Else
                    txtLadle_sidewall.SelectedItem.Text = "OK"
                End If
            End If
            If ds.Tables(3).Rows.Count > 0 Then 'ds.Tables(3).Rows(0)
                If IsDBNull(ds.Tables(3).Rows(0)("roof_number")) = False Then
                    txtRoof_number.Text = ds.Tables(3).Rows(0)("roof_number")
                Else
                    txtRoof_number.Text = ""
                End If
                If IsDBNull(ds.Tables(3).Rows(0)("life")) = False Then
                    txtRoof_life.Text = ds.Tables(3).Rows(0)("life")
                Else
                    txtRoof_life.Text = ""
                End If
                If IsDBNull(ds.Tables(3).Rows(0)("delta")) = False Then
                    txtRoof_delta.Text = ds.Tables(3).Rows(0)("delta")
                Else
                    txtRoof_delta.Text = ""
                End If
                If IsDBNull(ds.Tables(3).Rows(0)("roof_outer")) = False Then
                    txtRoof_outer.Text = ds.Tables(3).Rows(0)("roof_outer")
                Else
                    txtRoof_outer.Text = ""
                End If
            End If
            If ds.Tables(4).Rows.Count > 0 Then 'ds.Tables(4).Rows(0)
                If IsDBNull(ds.Tables(4).Rows(0)("bucket_number")) = False Then
                    txtBucket_number.Text = ds.Tables(4).Rows(0)("bucket_number")
                Else
                    txtBucket_number.Text = ""
                End If
                If IsDBNull(ds.Tables(4).Rows(0)("entered_by")) = False Then
                    txtBucket_enteredby.Text = ds.Tables(4).Rows(0)("entered_by")
                Else
                    txtBucket_enteredby.Text = ""
                End If

                If IsDBNull(ds.Tables(4).Rows(0)("bucket_number2")) = False Then
                    txtBucket_number2.Text = ds.Tables(4).Rows(0)("bucket_number2")
                Else
                    txtBucket_number2.Text = ""
                End If
                If IsDBNull(ds.Tables(4).Rows(0)("entered_by2")) = False Then
                    txtBucket_enteredby2.Text = ds.Tables(4).Rows(0)("entered_by2")
                Else
                    txtBucket_enteredby2.Text = ""
                End If

                If IsDBNull(ds.Tables(4).Rows(0)("bucket_number3")) = False Then
                    txtBucket_number3.Text = ds.Tables(4).Rows(0)("bucket_number3")
                Else
                    txtBucket_number3.Text = ""
                End If
                If IsDBNull(ds.Tables(4).Rows(0)("entered_by3")) = False Then
                    txtBucket_enteredby3.Text = ds.Tables(4).Rows(0)("entered_by3")
                Else
                    txtBucket_enteredby3.Text = ""
                End If
            End If
            If ds.Tables(5).Rows.Count > 0 Then 'ds.Tables(5).Rows(0)
                If IsDBNull(ds.Tables(5).Rows(0)("Remarks")) = False Then
                    txtChargeRemarks.Text = ds.Tables(5).Rows(0)("Remarks")
                Else
                    txtChargeRemarks.Text = ""
                End If
                If IsDBNull(ds.Tables(5).Rows(0)("riser_hub")) = False Then
                    txtRiserhub.Text = ds.Tables(5).Rows(0)("riser_hub")
                Else
                    txtRiserhub.Text = ""
                End If
                If IsDBNull(ds.Tables(5).Rows(0)("pygmy_pot")) = False Then
                    txtPygmy_pot.Text = ds.Tables(5).Rows(0)("pygmy_pot")
                Else
                    txtPygmy_pot.Text = ""
                End If
                If IsDBNull(ds.Tables(5).Rows(0)("wheel_cut")) = False Then
                    txtWheel_cut.Text = ds.Tables(5).Rows(0)("wheel_cut")
                Else
                    txtWheel_cut.Text = ""
                End If
                If IsDBNull(ds.Tables(5).Rows(0)("lms")) = False Then
                    txtLMS.Text = ds.Tables(5).Rows(0)("lms")
                Else
                    txtLMS.Text = ""
                End If
                If IsDBNull(ds.Tables(5).Rows(0)("slpr_cut")) = False Then
                    txtSlpr_cut.Text = ds.Tables(5).Rows(0)("slpr_cut")
                Else
                    txtSlpr_cut.Text = ""
                End If
                If IsDBNull(ds.Tables(5).Rows(0)("hot_heal")) = False Then
                    txtHot_heal.Text = ds.Tables(5).Rows(0)("hot_heal")
                Else
                    txtHot_heal.Text = ""
                End If
                'If IsDBNull(ds.Tables(5).Rows(0)("axle_cut")) = False Then
                '    txtAxle_cut.Text = ds.Tables(5).Rows(0)("axle_cut")
                'Else
                '    txtAxle_cut.Text = ""
                'End If
                If IsDBNull(ds.Tables(5).Rows(0)("tuning_boring")) = False Then
                    txtTurningboring.Text = ds.Tables(5).Rows(0)("tuning_boring")
                Else
                    txtTurningboring.Text = ""
                End If
                If IsDBNull(ds.Tables(5).Rows(0)("wheel")) = False Then
                    txtWheel.Text = ds.Tables(5).Rows(0)("wheel")
                Else
                    txtWheel.Text = ""
                End If
                'If IsDBNull(ds.Tables(5).Rows(0)("axle_end")) = False Then
                '    txtAle_end.Text = ds.Tables(5).Rows(0)("axle_end")
                'Else
                '    txtAle_end.Text = ""
                'End If
                'If IsDBNull(ds.Tables(5).Rows(0)("Rail_cut")) = False Then
                '    txtRail_Cut.Text = ds.Tables(5).Rows(0)("Rail_cut")
                'Else
                '    txtRail_Cut.Text = ""
                'End If
            End If
            If ds.Tables(6).Rows.Count > 0 Then 'ds.Tables(6).Rows(0)
                If IsDBNull(ds.Tables(6).Rows(0)("e1make")) = False Then
                    txtEmake_e1.Text = ds.Tables(6).Rows(0)("e1make")
                Else
                    txtEmake_e1.Text = ""
                End If
                If IsDBNull(ds.Tables(6).Rows(0)("e1added")) = False Then
                    txtEadded_e1.Text = ds.Tables(6).Rows(0)("e1added")
                Else
                    txtEadded_e1.Text = ""
                End If

                If IsDBNull(ds.Tables(6).Rows(0)("e1tip_profile")) = False Then
                    txtEtip_e1.Text = ds.Tables(6).Rows(0)("e1tip_profile")
                Else
                    txtEtip_e1.Text = ""
                End If
                If IsDBNull(ds.Tables(6).Rows(0)("e2make")) = False Then
                    txtEmake_e2.Text = ds.Tables(6).Rows(0)("e2make")
                Else
                    txtEmake_e2.Text = ""
                End If
                If IsDBNull(ds.Tables(6).Rows(0)("e2added")) = False Then
                    txtEadded_e2.Text = ds.Tables(6).Rows(0)("e2added")
                Else
                    txtEadded_e2.Text = ""
                End If

                If IsDBNull(ds.Tables(6).Rows(0)("e2tip_profile")) = False Then
                    txtEtip_e2.Text = ds.Tables(6).Rows(0)("e2tip_profile")
                Else
                    txtEtip_e2.Text = ""
                End If
                If IsDBNull(ds.Tables(6).Rows(0)("e3make")) = False Then
                    txtEmake_e3.Text = ds.Tables(6).Rows(0)("e3make")
                Else
                    txtEmake_e3.Text = ""
                End If
                If IsDBNull(ds.Tables(6).Rows(0)("e3added")) = False Then
                    txtEadded_e3.Text = ds.Tables(6).Rows(0)("e3added")
                Else
                    txtEadded_e3.Text = ""
                End If

                If IsDBNull(ds.Tables(6).Rows(0)("e3tip_profile")) = False Then
                    txtEtip_e3.Text = ds.Tables(6).Rows(0)("e3tip_profile")
                Else
                    txtEtip_e3.Text = ""
                End If
                SetElectrode()
            End If
            If ds.Tables(7).Rows.Count > 0 Then 'ds.Tables(7).Rows(0)
                If IsDBNull(ds.Tables(7).Rows(0)("quantity")) = False Then
                    txtNMclime.Text = ds.Tables(7).Rows(0)("quantity")
                Else
                    txtNMclime.Text = ""
                End If
                If IsDBNull(ds.Tables(7).Rows(1)("quantity")) = False Then
                    txtNMgdust.Text = ds.Tables(7).Rows(1)("quantity")
                Else
                    txtNMgdust.Text = ""
                End If
            End If
            ''If ds.Tables(8).Rows.Count > 0 Then 'ds.Tables(8).Rows(0)
            ''    If IsDBNull(ds.Tables(8).Rows(0)("ramming_mass_make")) = False Then
            ''        'txtFrmi_make.Text = ds.Tables(8).Rows(0)("ramming_mass_make")
            ''        ' Changes for List items
            ''        txtFrmi_make.SelectedItem.Text = ds.Tables(8).Rows(0)("ramming_mass_make")
            ''    Else
            ''        txtFrmi_make.SelectedItem.Text = "RHI"
            ''    End If
            ''    If IsDBNull(ds.Tables(8).Rows(0)("ramming_mass_quantity")) = False Then
            ''        txtFrmi_quantity.Text = ds.Tables(8).Rows(0)("ramming_mass_quantity")
            ''    Else
            ''        txtFrmi_quantity.Text = ""
            ''    End If
            ''    If IsDBNull(ds.Tables(8).Rows(0)("gunning_mix_make")) = False Then
            ''        'txtFgmi_make.Text = ds.Tables(8).Rows(0)("gunning_mix_make")
            ''        txtFgmi_make.SelectedItem.Text = ds.Tables(8).Rows(0)("gunning_mix_make")
            ''    Else
            ''        txtFgmi_make.SelectedItem.Text = "Controller of stores"
            ''    End If
            ''    If IsDBNull(ds.Tables(8).Rows(0)("gunning_mix_quantity")) = False Then
            ''        txtFgmi_quantity.Text = ds.Tables(8).Rows(0)("gunning_mix_quantity")
            ''    Else
            ''        txtFgmi_quantity.Text = ""
            ''    End If
            ''    If IsDBNull(ds.Tables(8).Rows(0)("wet_ramming_mass_make")) = False Then
            ''        ' txtFWrmi_make.Text = ds.Tables(8).Rows(0)("wet_ramming_mass_make")
            ''        txtFWrmi_make.SelectedItem.Text = ds.Tables(8).Rows(0)("wet_ramming_mass_make")
            ''    Else
            ''        txtFWrmi_make.SelectedItem.Text = "VRPL"
            ''    End If
            ''    If IsDBNull(ds.Tables(8).Rows(0)("wet_ramming_mass_quantity")) = False Then
            ''        txtFWrmi_quantity.Text = ds.Tables(8).Rows(0)("wet_ramming_mass_quantity")
            ''    Else
            ''        txtFWrmi_quantity.Text = ""
            ''    End If
            ''End If
            CalculateTotal()
            If txtLadle_number.Text.Trim.Length > 0 Then
                Dim dt As DataTable
                dt = RWF.Melting.PreviousLadleDetails(Val(CLng(ViewState("Heat"))), txtLadle_number.Text.Trim)
                If dt.Rows.Count > 0 Then
                    li.Text = IIf(IsDBNull(dt.Rows(0)(0)), 0, dt.Rows(0)(0))
                    Ht.Text = IIf(IsDBNull(dt.Rows(0)(1)), 0, dt.Rows(0)(1))
                    txtw1.Text = LadleWeight.Values.EmptyWt(txtHeatNo1.Text)
                End If
                dt.Dispose()
                dt = Nothing
            End If
            ' For Remarks
            If txtFurnace_bottom.SelectedItem.Text = "NOT OK" Then
                FBRMK.Visible = True
            Else
                FBRMK.Visible = False
            End If
            If txtSidewall_up.SelectedItem.Text = "NOT OK" Then
                FSWURMK.Visible = True
            Else
                FSWURMK.Visible = False
            End If
            If txtSidewall_lo.SelectedItem.Text = "NOT OK" Then
                FSWLRMK.Visible = True
            Else
                FSWLRMK.Visible = False
            End If
            If txtBank.SelectedItem.Text = "NOT OK" Then
                FBTRMK.Visible = True
            Else
                FBTRMK.Visible = False
            End If

        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            If RWF.Melting.CheckTap_time(Val(CLng(ViewState("Heat"))) - 1) = False Then
                lblMessage.Text &= "Tap_Time is not entered for Heat No : '" & Val(CLng(ViewState("Heat"))) - 1 & "'"
            End If
            ds.Dispose()
            ds = Nothing
            intCntr = Nothing
        End Try
    End Sub

    Private Sub GetSheet2Data()
        Dim ds As DataSet
        Dim intCntr As Int16
        lblMessage.Text = ""
        Try
            ds = RWF.Melting.GetSheet2Data(CLng(ViewState("Heat")))
            If ds.Tables(0).Rows.Count > 0 Then 'ds.Tables(0).Rows(0)

                If IsDBNull(ds.Tables(0).Rows(0)("furnace_inspection")) = False Then
                    Try
                        txtFurnace_inspectionDate.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("furnace_inspection")), CDate(ViewState("melt_date")), CDate(ds.Tables(0).Rows(0)("furnace_inspection")).ToShortDateString)
                    Catch exp As Exception
                        txtFurnace_inspectionDate.Text = Now.Date
                    End Try
                    Try
                        txtFurnace_inspection.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("furnace_inspection")), "00:00", Right(("0" + CDate(ds.Tables(0).Rows(0)("furnace_inspection")).Hour.ToString), 2) + ":" + Right(("0" + CDate(ds.Tables(0).Rows(0)("furnace_inspection")).Minute.ToString), 2))
                    Catch exp As Exception
                        txtFurnace_inspection.Text = "00:00"
                    End Try
                    If txtFurnace_inspection.Text = "00:00" Then
                        txtFurnace_inspection.Text = ""
                    End If
                Else
                    txtFurnace_inspectionDate.Text = Now.Date
                    txtFurnace_inspection.Text = ""
                End If

                If IsDBNull(ds.Tables(0).Rows(0)("roof_outtime")) = False Then
                    Try
                        txtRoof_outtimeDate.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("roof_outtime")), CDate(ViewState("melt_date")), CDate(ds.Tables(0).Rows(0)("roof_outtime")).ToShortDateString)
                    Catch exp As Exception
                        txtRoof_outtimeDate.Text = Now.Date
                    End Try
                    Try
                        txtRoof_outtime.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("roof_outtime")), "00:00", Right(("0" + CDate(ds.Tables(0).Rows(0)("roof_outtime")).Hour.ToString), 2) + ":" + Right(("0" + CDate(ds.Tables(0).Rows(0)("roof_outtime")).Minute.ToString), 2))
                    Catch exp As Exception
                        txtRoof_outtime.Text = "00:00"
                    End Try
                    If txtRoof_outtime.Text = "00:00" Then
                        txtRoof_outtime.Text = ""
                    End If
                Else
                    txtRoof_outtimeDate.Text = Now.Date
                    txtRoof_outtime.Text = ""
                End If

                If IsDBNull(ds.Tables(0).Rows(0)("charge_start")) = False Then
                    Try
                        txtCharge_startDate.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("charge_start")), CDate(ViewState("melt_date")), CDate(ds.Tables(0).Rows(0)("charge_start")).ToShortDateString)
                    Catch exp As Exception
                        txtCharge_startDate.Text = Now.Date
                    End Try
                    Try
                        txtCharge_start.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("charge_start")), "00:00", Right(("0" + CDate(ds.Tables(0).Rows(0)("charge_start")).Hour.ToString), 2) + ":" + Right(("0" + CDate(ds.Tables(0).Rows(0)("charge_start")).Minute.ToString), 2))
                    Catch exp As Exception
                        txtCharge_start.Text = "00:00"
                    End Try
                    If txtCharge_start.Text = "00:00" Then
                        txtCharge_start.Text = ""
                    End If
                Else
                    txtCharge_startDate.Text = Now.Date
                    txtCharge_start.Text = ""
                End If

                If IsDBNull(ds.Tables(0).Rows(0)("charge_end")) = False Then
                    Try
                        txtCharge_endDate.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("charge_end")), CDate(ViewState("melt_date")), CDate(ds.Tables(0).Rows(0)("charge_end")).ToShortDateString)
                    Catch exp As Exception
                        txtCharge_endDate.Text = Now.Date
                    End Try
                    Try
                        txtCharge_end.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("charge_end")), "00:00", Right(("0" + CDate(ds.Tables(0).Rows(0)("charge_end")).Hour.ToString), 2) + ":" + Right(("0" + CDate(ds.Tables(0).Rows(0)("charge_end")).Minute.ToString), 2))
                    Catch exp As Exception
                        txtCharge_end.Text = "00:00"
                    End Try
                    If txtCharge_end.Text = "00:00" Then
                        txtCharge_end.Text = ""
                    End If
                Else
                    txtCharge_endDate.Text = Now.Date
                    txtCharge_end.Text = ""
                End If

                If IsDBNull(ds.Tables(0).Rows(0)("removed_material")) = False Then
                    Try
                        txtremoved_materialDate.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("removed_material")), CDate(ViewState("melt_date")), CDate(ds.Tables(0).Rows(0)("removed_material")).ToShortDateString)
                    Catch exp As Exception
                        txtremoved_materialDate.Text = Now.Date
                    End Try
                    Try
                        txtremoved_material.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("removed_material")), "00:00", Right(("0" + CDate(ds.Tables(0).Rows(0)("removed_material")).Hour.ToString), 2) + ":" + Right(("0" + CDate(ds.Tables(0).Rows(0)("removed_material")).Minute.ToString), 2))
                    Catch exp As Exception
                        txtremoved_material.Text = "00:00"
                    End Try
                    If txtremoved_material.Text = "00:00" Then
                        txtremoved_material.Text = ""
                    End If
                Else
                    txtremoved_materialDate.Text = Now.Date
                    txtremoved_material.Text = ""
                End If

                If IsDBNull(ds.Tables(0).Rows(0)("levelling")) = False Then
                    Try
                        txtLevellingDate.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("levelling")), CDate(ViewState("melt_date")), CDate(ds.Tables(0).Rows(0)("levelling")).ToShortDateString)
                    Catch exp As Exception
                        txtLevellingDate.Text = Now.Date
                    End Try
                    Try
                        txtLevelling.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("levelling")), "00:00", Right(("0" + CDate(ds.Tables(0).Rows(0)("levelling")).Hour.ToString), 2) + ":" + Right(("0" + CDate(ds.Tables(0).Rows(0)("levelling")).Minute.ToString), 2))
                    Catch exp As Exception
                        txtLevelling.Text = "00:00"
                    End Try
                    If txtLevelling.Text = "00:00" Then
                        txtLevelling.Text = ""
                    End If
                Else
                    txtLevellingDate.Text = Now.Date
                    txtLevelling.Text = ""
                End If

                If IsDBNull(ds.Tables(0).Rows(0)("roof_in")) = False Then
                    Try
                        txtRoof_inDate.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("roof_in")), CDate(ViewState("melt_date")), CDate(ds.Tables(0).Rows(0)("roof_in")).ToShortDateString)
                    Catch exp As Exception
                        txtRoof_inDate.Text = Now.Date
                    End Try
                    Try
                        txtRoof_in.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("roof_in")), "00:00", Right(("0" + CDate(ds.Tables(0).Rows(0)("roof_in")).Hour.ToString), 2) + ":" + Right(("0" + CDate(ds.Tables(0).Rows(0)("roof_in")).Minute.ToString), 2))
                    Catch exp As Exception
                        txtRoof_in.Text = "00:00"
                    End Try
                    If txtRoof_in.Text = "00:00" Then
                        txtRoof_in.Text = ""
                    End If
                Else
                    txtRoof_inDate.Text = Now.Date
                    txtRoof_in.Text = ""
                End If

                If IsDBNull(ds.Tables(0).Rows(0)("back_charge_metal")) = False Then
                    Try
                        txtBucket_chargemetDate.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("back_charge_metal")), CDate(ViewState("melt_date")), CDate(ds.Tables(0).Rows(0)("back_charge_metal")).ToShortDateString)
                    Catch exp As Exception
                        txtBucket_chargemetDate.Text = Now.Date
                    End Try
                    Try
                        txtBucket_chargemet.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("back_charge_metal")), "00:00", Right(("0" + CDate(ds.Tables(0).Rows(0)("back_charge_metal")).Hour.ToString), 2) + ":" + Right(("0" + CDate(ds.Tables(0).Rows(0)("back_charge_metal")).Minute.ToString), 2))
                    Catch exp As Exception
                        txtBucket_chargemet.Text = "00:00"
                    End Try
                    If txtBucket_chargemet.Text = "00:00" Then
                        txtBucket_chargemet.Text = ""
                    End If
                Else
                    txtBucket_chargemetDate.Text = Now.Date
                    txtBucket_chargemet.Text = ""
                End If

                If IsDBNull(ds.Tables(0).Rows(0)("bucket_charge")) = False Then
                    Try
                        txtBucket_chargeDate.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("bucket_charge")), CDate(ViewState("melt_date")), CDate(ds.Tables(0).Rows(0)("bucket_charge")).ToShortDateString)
                    Catch exp As Exception
                        txtBucket_chargeDate.Text = Now.Date
                    End Try
                    Try
                        txtBucket_charge.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("bucket_charge")), "00:00", Right(("0" + CDate(ds.Tables(0).Rows(0)("bucket_charge")).Hour.ToString), 2) + ":" + Right(("0" + CDate(ds.Tables(0).Rows(0)("bucket_charge")).Minute.ToString), 2))
                    Catch exp As Exception
                        txtBucket_charge.Text = "00:00"
                    End Try
                    If txtBucket_charge.Text = "00:00" Then
                        txtBucket_charge.Text = ""
                    End If
                Else
                    txtBucket_chargeDate.Text = Now.Date
                    txtBucket_charge.Text = ""
                End If

                If IsDBNull(ds.Tables(0).Rows(0)("charge_met")) = False Then
                    txtCharge_met.Text = ds.Tables(0).Rows(0)("charge_met")
                    Try
                        txtCharge_metDate.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("charge_met")), CDate(ViewState("melt_date")), CDate(ds.Tables(0).Rows(0)("charge_met")).ToShortDateString)
                    Catch exp As Exception
                        txtCharge_metDate.Text = Now.Date
                    End Try
                    Try
                        txtCharge_met.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("charge_met")), "00:00", Right(("0" + CDate(ds.Tables(0).Rows(0)("charge_met")).Hour.ToString), 2) + ":" + Right(("0" + CDate(ds.Tables(0).Rows(0)("charge_met")).Minute.ToString), 2))
                    Catch exp As Exception
                        txtCharge_met.Text = "00:00"
                    End Try
                    If txtCharge_met.Text = "00:00" Then
                        txtCharge_met.Text = ""
                    End If
                Else
                    txtCharge_metDate.Text = Now.Date
                    txtCharge_met.Text = ""
                End If

                'If IsDBNull(ds.Tables(0).Rows(0)("t6_power")) = False Then
                '    txtPower_t6.Text = ds.Tables(0).Rows(0)("t6_power")
                '    Try
                '        txtPower_t6Date.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("t6_power")), CDate(ViewState("melt_date")), CDate(ds.Tables(0).Rows(0)("t6_power")).ToShortDateString)
                '    Catch exp As Exception
                '        txtPower_t6Date.Text = Now.Date
                '    End Try
                '    Try
                '        txtPower_t6.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("t6_power")), "00:00", Right(("0" + CDate(ds.Tables(0).Rows(0)("t6_power")).Hour.ToString), 2) + ":" + Right(("0" + CDate(ds.Tables(0).Rows(0)("t6_power")).Minute.ToString), 2))
                '    Catch exp As Exception
                '        txtPower_t6.Text = "00:00"
                '    End Try
                '    If txtPower_t6.Text = "00:00" Then
                '        txtPower_t6.Text = ""
                '    End If
                'Else
                '    txtPower_t6Date.Text = Now.Date
                '    txtPower_t6.Text = ""
                'End If

                'If IsDBNull(ds.Tables(0).Rows(0)("t2_power")) = False Then
                '    Try
                '        txtPower_t2Date.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("t2_power")), CDate(ViewState("melt_date")), CDate(ds.Tables(0).Rows(0)("t2_power")).ToShortDateString)
                '    Catch exp As Exception
                '        txtPower_t2Date.Text = Now.Date
                '    End Try
                '    Try
                '        txtPower_t2.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("t2_power")), "00:00", Right(("0" + CDate(ds.Tables(0).Rows(0)("t2_power")).Hour.ToString), 2) + ":" + Right(("0" + CDate(ds.Tables(0).Rows(0)("t2_power")).Minute.ToString), 2))
                '    Catch exp As Exception
                '        txtPower_t2.Text = "00:00"
                '    End Try
                '    If txtPower_t2.Text = "00:00" Then
                '        txtPower_t2.Text = ""
                '    End If
                'Else
                '    txtPower_t2Date.Text = Now.Date
                '    txtPower_t2.Text = ""
                'End If

                'If IsDBNull(ds.Tables(0).Rows(0)("t4_power")) = False Then
                '    txtPower_t4.Text = ds.Tables(0).Rows(0)("t4_power")
                '    Try
                '        txtPower_t4Date.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("t4_power")), CDate(ViewState("melt_date")), CDate(ds.Tables(0).Rows(0)("t4_power")).ToShortDateString)
                '    Catch exp As Exception
                '        txtPower_t4Date.Text = Now.Date
                '    End Try
                '    Try
                '        txtPower_t4.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("t4_power")), "00:00", Right(("0" + CDate(ds.Tables(0).Rows(0)("t4_power")).Hour.ToString), 2) + ":" + Right(("0" + CDate(ds.Tables(0).Rows(0)("t4_power")).Minute.ToString), 2))
                '    Catch exp As Exception
                '        txtPower_t4.Text = "00:00"
                '    End Try
                '    If txtPower_t4.Text = "00:00" Then
                '        txtPower_t4.Text = ""
                '    End If
                'Else
                '    txtPower_t4Date.Text = Now.Date
                '    txtPower_t4.Text = ""
                'End If

                'If IsDBNull(ds.Tables(0).Rows(0)("t8_power")) = False Then
                '    txtPower_t8.Text = ds.Tables(0).Rows(0)("t8_power")
                '    Try
                '        txtPower_t8Date.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("t8_power")), CDate(ViewState("melt_date")), CDate(ds.Tables(0).Rows(0)("t8_power")).ToShortDateString)
                '    Catch exp As Exception
                '        txtPower_t8Date.Text = Now.Date
                '    End Try
                '    Try
                '        txtPower_t8.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("t8_power")), "00:00", Right(("0" + CDate(ds.Tables(0).Rows(0)("t8_power")).Hour.ToString), 2) + ":" + Right(("0" + CDate(ds.Tables(0).Rows(0)("t8_power")).Minute.ToString), 2))
                '    Catch exp As Exception
                '        txtPower_t8.Text = "00:00"
                '    End Try
                '    If txtPower_t8.Text = "00:00" Then
                '        txtPower_t8.Text = ""
                '    End If
                'Else
                '    txtPower_t8Date.Text = Now.Date
                '    txtPower_t8.Text = ""
                'End If

                'If IsDBNull(ds.Tables(0).Rows(0)("t10_power")) = False Then
                '    txtPower_t102.Text = ds.Tables(0).Rows(0)("t10_power")
                '    Try
                '        txtPower_t102Date.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("t10_power")), CDate(ViewState("melt_date")), CDate(ds.Tables(0).Rows(0)("t10_power")).ToShortDateString)
                '    Catch exp As Exception
                '        txtPower_t102Date.Text = Now.Date
                '    End Try
                '    Try
                '        txtPower_t102.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("t10_power")), "00:00", Right(("0" + CDate(ds.Tables(0).Rows(0)("t10_power")).Hour.ToString), 2) + ":" + Right(("0" + CDate(ds.Tables(0).Rows(0)("t10_power")).Minute.ToString), 2))
                '    Catch exp As Exception
                '        txtPower_t102.Text = "00:00"
                '    End Try
                '    If txtPower_t102.Text = "00:00" Then
                '        txtPower_t102.Text = ""
                '    End If
                'Else
                '    txtPower_t102Date.Text = Now.Date
                '    txtPower_t102.Text = ""
                'End If

                If IsDBNull(ds.Tables(0).Rows(0)("t2_power")) = False Then
                    txtPower_t101.Text = ds.Tables(0).Rows(0)("t2_power")
                    Try
                        txtPower_t101Date.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("t2_power")), CDate(ViewState("melt_date")), CDate(ds.Tables(0).Rows(0)("t2_power")).ToShortDateString)
                    Catch exp As Exception
                        txtPower_t101Date.Text = Now.Date
                    End Try
                    Try
                        txtPower_t101.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("t2_power")), "00:00", Right(("0" + CDate(ds.Tables(0).Rows(0)("t2_power")).Hour.ToString), 2) + ":" + Right(("0" + CDate(ds.Tables(0).Rows(0)("t2_power")).Minute.ToString), 2))
                    Catch exp As Exception
                        txtPower_t101.Text = "00:00"
                    End Try
                    If txtPower_t101.Text = "00:00" Then
                        txtPower_t102.Text = ""
                    End If
                Else
                    txtPower_t101Date.Text = Now.Date
                    txtPower_t101.Text = ""
                End If

                'If IsDBNull(ds.Tables(0).Rows(0)("t12_power")) = False Then
                '    txtPower_t12.Text = ds.Tables(0).Rows(0)("t12_power")
                '    Try
                '        txtPower_t12Date.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("t12_power")), CDate(ViewState("melt_date")), CDate(ds.Tables(0).Rows(0)("t12_power")).ToShortDateString)
                '    Catch exp As Exception
                '        txtPower_t12Date.Text = Now.Date
                '    End Try
                '    Try
                '        txtPower_t12.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("t12_power")), "00:00", Right(("0" + CDate(ds.Tables(0).Rows(0)("t12_power")).Hour.ToString), 2) + ":" + Right(("0" + CDate(ds.Tables(0).Rows(0)("t12_power")).Minute.ToString), 2))
                '    Catch exp As Exception
                '        txtPower_t12.Text = "00:00"
                '    End Try
                '    If txtPower_t12.Text = "00:00" Then
                '        txtPower_t12.Text = ""
                '    End If
                'Else
                '    txtPower_t12Date.Text = Now.Date
                '    txtPower_t12.Text = ""
                'End If
                DDLPOWERON.SelectedItem.Text = ds.Tables(0).Rows(0)("PowerOn")
            Else
                txtFurnace_inspectionDate.Text = Now.Date
                txtRoof_outtimeDate.Text = Now.Date
                txtCharge_startDate.Text = Now.Date
                txtCharge_endDate.Text = Now.Date
                txtremoved_materialDate.Text = Now.Date
                txtLevellingDate.Text = Now.Date
                txtRoof_inDate.Text = Now.Date
                txtBucket_chargemetDate.Text = Now.Date
                txtBucket_chargeDate.Text = Now.Date
                txtCharge_metDate.Text = Now.Date
                txtPower_t101Date.Text = Now.Date
                'txtPower_t6Date.Text = Now.Date
                'txtPower_t4Date.Text = Now.Date
                'txtPower_t102Date.Text = Now.Date
                'txtPower_t8Date.Text = Now.Date
                'txtPower_t12Date.Text = Now.Date
                'txtPower_t2Date.Text = Now.Date

            End If
            If ds.Tables(1).Rows.Count > 0 Then
                If IsDBNull(ds.Tables(1).Rows(0)("furnace_fe_si")) = False Then
                    txtFfesi.Text = ds.Tables(1).Rows(0)("furnace_fe_si")
                Else
                    txtFfesi.Text = ""
                End If
                If IsDBNull(ds.Tables(1).Rows(0)("furnace_fe_mn")) = False Then
                    txtfFeMn.Text = ds.Tables(1).Rows(0)("furnace_fe_mn")
                Else
                    txtfFeMn.Text = ""
                End If

                If IsDBNull(ds.Tables(1).Rows(0)("ladle_fe_mn")) = False Then
                    txtLFeMn.Text = ds.Tables(1).Rows(0)("ladle_fe_mn")
                Else
                    txtLFeMn.Text = ""
                End If

                If IsDBNull(ds.Tables(1).Rows(0)("furnace_floor_spar")) = False Then
                    txtFfloor.Text = ds.Tables(1).Rows(0)("furnace_floor_spar")
                Else
                    txtFfloor.Text = ""
                End If
                If IsDBNull(ds.Tables(1).Rows(0)("furnace_limestone")) = False Then
                    txtFlimestone.Text = ds.Tables(1).Rows(0)("furnace_limestone")
                Else
                    txtFlimestone.Text = ""
                End If
                If IsDBNull(ds.Tables(1).Rows(0)("ladle_si_mn")) = False Then
                    txtLsimn.Text = ds.Tables(1).Rows(0)("ladle_si_mn")
                Else
                    txtLsimn.Text = ""
                End If
                If IsDBNull(ds.Tables(1).Rows(0)("ladle_fe_si")) = False Then
                    txtLfesi.Text = ds.Tables(1).Rows(0)("ladle_fe_si")
                Else
                    txtLfesi.Text = ""
                End If
                If IsDBNull(ds.Tables(1).Rows(0)("ladle_floor_spar")) = False Then
                    txtLfloor.Text = ds.Tables(1).Rows(0)("ladle_floor_spar")
                Else
                    txtLfloor.Text = ""
                End If
                If IsDBNull(ds.Tables(1).Rows(0)("ladle_limestone")) = False Then
                    txtLlimestone.Text = ds.Tables(1).Rows(0)("ladle_limestone")
                Else
                    txtLlimestone.Text = ""
                End If
                If IsDBNull(ds.Tables(1).Rows(0)("furnace_gunningdust")) = False Then
                    txtFgdust.Text = ds.Tables(1).Rows(0)("furnace_gunningdust")
                Else
                    txtFgdust.Text = ""
                End If
                If IsDBNull(ds.Tables(1).Rows(0)("ladle_gunningdust")) = False Then
                    txtLgdust.Text = ds.Tables(1).Rows(0)("ladle_gunningdust")
                Else
                    txtLgdust.Text = ""
                End If

                If IsDBNull(ds.Tables(1).Rows(0)("furnace_calcium_lime")) = False Then
                    txtfCalLime.Text = ds.Tables(1).Rows(0)("furnace_calcium_lime")
                Else
                    txtfCalLime.Text = ""
                End If
                If IsDBNull(ds.Tables(1).Rows(0)("rsm_contract")) = False Then
                    txtrsm_contract.Text = ds.Tables(1).Rows(0)("rsm_contract")
                Else
                    txtrsm_contract.Text = ""
                End If
                If IsDBNull(ds.Tables(1).Rows(0)("rsm_dept")) = False Then
                    txtrsm_dept.Text = ds.Tables(1).Rows(0)("rsm_dept")
                Else
                    txtrsm_dept.Text = ""
                End If
                If IsDBNull(ds.Tables(1).Rows(0)("ContractNo")) = False Then
                    txtContractNo.Text = ds.Tables(1).Rows(0)("ContractNo")
                Else
                    txtContractNo.Text = ""
                End If
                If txtContractNo.Text.Trim.Length > 0 Then
                    txtContractNo.Text = txtContractNo.Text.ToUpper.Trim
                    GetContractDatails()
                End If
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            If Not Session("UserId") = "082616" Then
                If Not Session("UserId") = "074510" Then
                    If RWF.Melting.CheckPHLDateForHeatNo(CLng(ViewState("Heat"))) Then
                        lblMessage.Text &= " ; PHL Generated Heat, Not for Editing !"
                    End If
                End If
            End If
            ds = Nothing
            intCntr = Nothing
        End Try
    End Sub

    Private Sub GetSheet3Data()
        Dim intCntr, intCntr1, intCntr2, intCntr3, intVal, intVal1, intVal2 As Integer
        intCntr1 = cboHeatStatus.Items.Count - 1
        intCntr2 = rdBtnlst1.Items.Count - 1
        intCntr3 = rdBtnlst2.Items.Count - 1

        Dim ds As DataSet
        lblMessage.Text = ""
        Try
            ds = RWF.Melting.GetSheet3Data(CLng(ViewState("Heat")))
            cboDelayCd.DataSource = ds.Tables(0)
            cboDelayCd.DataTextField = "code"
            cboDelayCd.DataValueField = "brkdn_code"
            cboDelayCd.DataBind()
            '****population of Header table starts here
            Dim sval As String
            sval = ds.Tables(1).Rows(0)("heatstatus")
            For intCntr = 1 To intCntr1
                If (Trim(cboHeatStatus.Items(intCntr).Value) = sval) Then
                    intVal = intCntr
                    Exit For
                End If
            Next

            cboHeatStatus.SelectedIndex = intVal
            sval = ds.Tables(1).Rows(0)("TapDrain")
            For intCntr = 1 To intCntr2
                If (Trim(rdBtnlst1.Items(intCntr).Value) = sval) Then
                    intVal = intCntr
                    Exit For
                End If
            Next

            rdBtnlst1.SelectedIndex = intVal
            sval = ds.Tables(1).Rows(0)("ProcessDelay")
            For intCntr = 1 To intCntr3
                If (Trim(rdBtnlst2.Items(intCntr).Value) = sval) Then
                    intVal = intCntr
                    Exit For
                End If
            Next


            If rdBtnlst2.SelectedItem.Value = "1" Then
                Panel1.Visible = True
            Else
                Panel1.Visible = False
            End If
            If ds.Tables(1).Rows.Count > 0 Then
                'txtTip_make.Text = ds.Tables(1).Rows(0)("tip_make")
                txtTip_make.DataSource = ds.Tables(1)
                txtTip_make.DataValueField = ds.Tables(1).Columns(6).ColumnName
                txtTip_make.DataBind()


                'If dgTipMake.Items.Count = 1 Then
                '    If txtTip_make.Text.Trim.Length = 0 Then
                '        txtTip_make.Text = dgTipMake.Items(0).Cells(1).Text
                '    End If
                'End If

                'txtLpipe_make.Text = ds.Tables(1).Rows(0)("lpipe_make")
                txtLpipe_make.DataSource = ds.Tables(1)
                txtLpipe_make.DataValueField = ds.Tables(1).Columns(7).ColumnName
                txtLpipe_make.DataBind()

                txtTip_quantity.Text = ds.Tables(1).Rows(0)("tip_quantity")
                txtLpipe_quantity.Text = ds.Tables(1).Rows(0)("lpipe_quantity")
                txtTap_temperature.Text = ds.Tables(1).Rows(0)("tap_temperature")

                'LOF & SOS
                'DDLLOF.SelectedIndex = 3
                'DDLLOF.SelectedItem.Text = ds.Tables(1).Rows(0)("LOF")
                DDLLOF.DataSource = ds.Tables(1)
                DDLLOF.DataValueField = ds.Tables(1).Columns(29).ColumnName
                DDLLOF.DataBind()

                'DDLSOS.SelectedItem.Text = ds.Tables(1).Rows(0)("SOS")
                'DDLSOS.SelectedIndex = 2
                'DDLSOS.SelectedItem.Text = ds.Tables(1).Rows(0)("SOS")
                DDLSOS.DataSource = ds.Tables(1)
                DDLSOS.DataValueField = ds.Tables(1).Columns(30).ColumnName
                DDLSOS.DataBind()


                If IsDBNull(ds.Tables(1).Rows(0)("heat_tapped")) Then
                    txtTapBeginDate.Text = Now.Date.ToShortDateString
                    Dim mystr As String = IIf(IsDBNull(CStr(ds.Tables(1).Rows(0)("tap_begin"))), "0", CStr(ds.Tables(1).Rows(0)("tap_begin")))
                    Dim myarray As Array
                    Dim myHr, myMn As String
                    If mystr <> "" Then
                        If mystr = "0" Then
                            myHr = "0"
                            myMn = "0"
                        Else
                            If mystr.Length = 1 Then
                                mystr = mystr + ":0"
                            End If
                            myarray = Split(mystr, ":")
                            myHr = myarray(0)
                            myMn = myarray(1)
                        End If
                    End If
                    txtTap_beginHr.Text = Left(("0" + myHr), 2) + ":" + Left((myMn + "0"), 2)
                    ' txtTap_beginMn.Text = Left((myMn + "0"), 2)
                    mystr = Nothing
                    myarray = Nothing
                    myHr = Nothing
                    myMn = Nothing
                Else
                    txtTapBeginDate.Text = CDate(ds.Tables(1).Rows(0)("heat_tapped")).ToShortDateString
                    txtTap_beginHr.Text = Right("0" + (CDate(ds.Tables(1).Rows(0)("heat_tapped")).Hour.ToString), 2) + ":" + Right("0" + (CDate(ds.Tables(1).Rows(0)("heat_tapped")).Minute.ToString), 2)  'ds.Tables(1).Rows(0)("tap_begin")
                    '    'txtTap_beginMn.Text = Right("0" + (CDate(ds.Tables(1).Rows(0)("heat_tapped")).Minute.ToString), 2)  'ds.Tables(1).Rows(0)("tap_begin")
                    'End If
                    'txtTap_beginHr.Text = ds.Tables(1).Rows(0)("tap_begin")
                End If
                txtTap_end.Text = ds.Tables(1).Rows(0)("tap_end")
                txtTap_laptime.Text = ds.Tables(1).Rows(0)("tap_time")
                txtJMPstart_temperature.Text = ds.Tables(1).Rows(0)("jmp_st_temperature")
                txtSlag_condition.SelectedItem.Text = ds.Tables(1).Rows(0)("slag_condition")
                txtLM_level.Text = ds.Tables(1).Rows(0)("lm_level")
                txtJMP_ALstar.Text = ds.Tables(1).Rows(0)("jmp_aluminium_star")
                txtLMlevel_final.Text = ds.Tables(1).Rows(0)("lm_level_final")
                txtTrail_material_methods.Text = ds.Tables(1).Rows(0)("hea_rem") & ""
            End If
            If ds.Tables(2).Rows.Count = 0 Then
                txtDelay_code.Text = cboDelayCd.SelectedItem.Value
                txtFromtime.Text = ""
                txtToTime.Text = ""
                txtRemarks.Text = ""
            Else
                txtDelay_code.Text = ds.Tables(2).Rows(0)("delay_code")
                txtFromtime.Text = ds.Tables(2).Rows(0)("fromtime")
                txtToTime.Text = ds.Tables(2).Rows(0)("totime")
                txtRemarks.Text = ds.Tables(2).Rows(0)("remarks") & ""
            End If
            txtw2.Text = LadleWeight.Values.AfterTapWt(CLng(ViewState("Heat")))
            sval = Nothing
            'Total Molten Metal
            txtLMlevel_final.Text = Val(txtw2.Text) - Val(txtw1.Text)
        Catch exp As Exception
            lblMessage.Text &= exp.Message
            If lblMessage.Text = "There is no row at position 0." Then
                lblMessage.Text = ""
            End If
        Finally
            If Not Session("UserId") = "082616" Then
                If Not Session("UserId") = "074510" Then
                    If RWF.Melting.CheckPHLDateForHeatNo(CLng(ViewState("Heat"))) Then
                        lblMessage.Text &= " ; PHL Generated Heat, Not for Editing !"
                    End If
                End If
            End If
        End Try
        intCntr = Nothing
        intCntr1 = Nothing
        intCntr2 = Nothing
        intCntr3 = Nothing
        intVal = Nothing
        intVal1 = Nothing
        intVal2 = Nothing
    End Sub

    Private Sub GetSampleData()
        lblMessage.Text = ""
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Try
            DataGrid1.DataSource = RWF.Melting.GetSampleData(CLng(ViewState("Heat")))
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            If Not Session("UserId") = "082616" Then
                If Not Session("UserId") = "074510" Then
                    If RWF.Melting.CheckPHLDateForHeatNo(CLng(ViewState("Heat"))) Then
                        lblMessage.Text &= " ; PHL Generated Heat, Not for Editing !"
                    End If
                End If
            End If
        End Try
    End Sub

    Private Sub rblSheet_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblSheet.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            SetPanel()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub CalculateTotal()
        Dim total As Double
        total = 0
        If txtHot_heal.Text <> "" And IsNumeric(txtHot_heal.Text) Then total += CDbl(txtHot_heal.Text)
        'If txtAxle_cut.Text <> "" And IsNumeric(txtAxle_cut.Text) Then total += CDbl(txtAxle_cut.Text)
        If txtTurningboring.Text <> "" And IsNumeric(txtTurningboring.Text) Then total += CDbl(txtTurningboring.Text)
        ' If txtAle_end.Text <> "" And IsNumeric(txtAle_end.Text) Then total += CDbl(txtAle_end.Text)
        If txtRiserhub.Text <> "" And IsNumeric(txtRiserhub.Text) Then total += CDbl(txtRiserhub.Text)
        If txtWheel_cut.Text <> "" And IsNumeric(txtWheel_cut.Text) Then total += CDbl(txtWheel_cut.Text)
        If txtPygmy_pot.Text <> "" And IsNumeric(txtPygmy_pot.Text) Then total += CDbl(txtPygmy_pot.Text)
        If txtSlpr_cut.Text <> "" And IsNumeric(txtSlpr_cut.Text) Then total += CDbl(txtSlpr_cut.Text)
        If txtLMS.Text <> "" And IsNumeric(txtLMS.Text) Then total += CDbl(txtLMS.Text)
        If txtWheel.Text <> "" And IsNumeric(txtWheel.Text) Then total += CDbl(txtWheel.Text)
        ' If txtRail_Cut.Text <> "" And IsNumeric(txtRail_Cut.Text) Then total += CDbl(txtRail_Cut.Text)
        txtTotal.Text = CStr(total)
        total = Nothing
    End Sub

    Private Sub clearheader()
        ' rblFur.ClearSelection()
        FurNo.ClearSelection()
        txtDate.Text = ""
        rblShift.SelectedIndex = 0
        txtShift_incharge.Text = ""
        txtFurnace_incharge.Text = ""
    End Sub

    Private Sub ClearFettlingDetails()
        'txtFrmi_make.Text = ""
        txtFrmi_quantity.Text = ""
        'txtFgmi_make.Text = ""
        txtFgmi_quantity.Text = ""
        ' txtFWrmi_make.Text = ""
        txtFWrmi_quantity.Text = ""
    End Sub

    Private Sub ClearHeatSheetCharge()
        txtRiserhub.Text = ""
        txtPygmy_pot.Text = ""
        txtWheel_cut.Text = ""
        txtLMS.Text = ""
        txtSlpr_cut.Text = ""
        txtHot_heal.Text = ""
        'txtAxle_cut.Text = ""
        txtTurningboring.Text = ""
        txtWheel.Text = ""
        'txtAle_end.Text = ""
        txtNMgdust.Text = ""
        txtNMclime.Text = ""
        'txtRail_Cut.Text = ""
    End Sub

    Private Sub ClearElectrode()
        txtEmake_e1.Text = "GI"
        txtEadded_e1.Text = "0"
        txtEtip_e1.Text = "OK"

        txtEmake_e2.Text = "GI"
        txtEadded_e2.Text = "0"
        txtEtip_e2.Text = "OK"

        txtEmake_e3.Text = "GI"
        txtEadded_e3.Text = "0"
        txtEtip_e3.Text = "OK"

        txtRemarks.Text = ""
        txtEDate.Text = ""
        txtETime.Text = ""
        rblBreakage.SelectedIndex = 0
    End Sub

    Private Sub ClearBucket()
        txtBucket_number.Text = ""
        txtBucket_enteredby.Text = ""
    End Sub

    Private Sub ClearFurnaceCondition()
        txtFurnace_bottom.Text = "OK"
        txtSidewall_up.Text = "OK"
        txtSidewall_lo.Text = "OK"
        txtBank.Text = "OK"
    End Sub

    Private Sub ClearRoofDetails()
        txtRoof_number.Text = ""
        txtRoof_life.Text = ""
        txtRoof_delta.Text = "OK"
        txtRoof_outer.Text = "OK"
    End Sub

    Private Sub ClearLadleDetails()
        txtLadle_number.Text = ""
        txtLadle_life.Text = ""
        'txtLadle_bottom.SelectedItem.Text = ""
        'txtLadle_sidewall.Text = ""
        li.Text = ""
        Ht.Text = ""
    End Sub

    Private Sub ClearHeatSheetMelting()
        txtFurnace_inspection.Text = ""
        txtRoof_outtime.Text = ""
        txtCharge_start.Text = ""
        txtCharge_end.Text = ""
        txtremoved_material.Text = ""
        txtLevelling.Text = ""
        txtRoof_in.Text = ""
        txtBucket_chargemet.Text = ""
        txtBucket_charge.Text = ""
        txtCharge_met.Text = ""
        'txtPower_t6.Text = ""
        'txtPower_t4Date.Text = ""
        'txtPower_t102Date.Text = ""
        txtPower_t101Date.Text = ""
        'txtPower_t8Date.Text = ""
        'txtPower_t12Date.Text = ""
        'txtPower_t2.Text = ""

    End Sub

    Private Sub ClearInprocess_additives()
        txtFfesi.Text = ""
        txtFfloor.Text = ""
        txtFlimestone.Text = ""
        txtFgdust.Text = ""
        txtLgdust.Text = ""
        txtLsimn.Text = ""
        txtLfesi.Text = ""
        txtLfloor.Text = ""
        txtLlimestone.Text = ""
        txtfCalLime.Text = ""
        txtfFeMn.Text = ""
        txtrsm_dept.Text = ""
        txtrsm_contract.Text = ""
        txtLFeMn.Text = ""
        txtContractNo.Text = ""
    End Sub

    Private Sub ClearSample()
        rblSample.ClearSelection()
        txtSampleTimeHr.Text = ""
        'txtSampleTimeMin.Text = ""
        txtSampleTemp.Text = ""
        txtNi.Text = ""
        txtCarbon.Text = ""
        txtMoly.Text = ""
        txtNitro.Text = ""
        txtHydro.Text = ""
        txtVen.Text = ""
        txtMn.Text = ""
        txtSi.Text = ""
        txtPhosph.Text = ""
        txtSulpher.Text = ""
        txtCr.Text = ""
        txtCu.Text = ""
        txtAl.Text = ""
    End Sub

    Private Sub txtLadle_number_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLadle_number.TextChanged
        If txtLadle_number.Text.Trim.Length > 0 Then
            Dim dt As DataTable
            dt = RWF.Melting.PreviousLadleDetails(Val(txtHeatNo1.Text), txtLadle_number.Text.Trim)
            If dt.Rows.Count > 0 Then
                li.Text = IIf(IsDBNull(dt.Rows(0)(0)), 0, dt.Rows(0)(0))
                Ht.Text = IIf(IsDBNull(dt.Rows(0)(1)), 0, dt.Rows(0)(1))
                txtw1.Text = LadleWeight.Values.EmptyWt(txtHeatNo1.Text)
            End If
            dt.Dispose()
            dt = Nothing
        End If
    End Sub


    Private Sub txtPygmy_pot_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPygmy_pot.TextChanged
        CalculateTotal()
        SetFocus(txtHot_heal)
    End Sub

    Private Sub txtHot_heal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHot_heal.TextChanged
        CalculateTotal()
        SetFocus(txtWheel)
    End Sub

    Private Sub txtWheel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWheel.TextChanged
        CalculateTotal()
        SetFocus(txtRiserhub)
    End Sub

    Private Sub txtRiserhub_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRiserhub.TextChanged
        CalculateTotal()
        SetFocus(txtWheel_cut)
    End Sub

    Private Sub txtWheel_cut_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWheel_cut.TextChanged
        CalculateTotal()
        SetFocus(txtLMS)
    End Sub

    'Private Sub txtAxle_cut_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAxle_cut.TextChanged
    '    CalculateTotal()
    '    SetFocus(txtAle_end)
    'End Sub

    'Private Sub txtAle_end_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAle_end.TextChanged
    '    CalculateTotal()
    '    SetFocus(txtLMS)
    'End Sub

    Private Sub txtLMS_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLMS.TextChanged
        CalculateTotal()
        SetFocus(txtTurningboring)
    End Sub

    'Private Sub txtRail_Cut_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRail_Cut.TextChanged
    '    CalculateTotal()
    '    SetFocus(txtTurningboring)
    'End Sub

    Private Sub txtTurningboring_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTurningboring.TextChanged
        CalculateTotal()
        SetFocus(txtTotal)
    End Sub

    Private Sub txtTotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotal.TextChanged
        CalculateTotal()
        SetFocus(txtRiserhub)
    End Sub

    Private Sub txtDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged
        Dim D As Date
        Try
            D = CDate(txtDate.Text)
            If CDate(txtDate.Text) > Now Then
                txtDate.Text = ""
                lblMessage.Text = "Date can't be greater than today's date"
                Exit Sub
            Else
                txtDate.Text = D
                ViewState("melt_date") = D
                If RWF.tables.CheckWorkingDate(Session("Group"), CDate(txtDate.Text)) Then
                    lblMessage.Text = "Melt Date is declared as holiday by PCO. Contact PCO !"
                    txtDate.Text = ""
                    Exit Sub
                Else
                    ScrapAccontalCB()
                End If
            End If
        Catch
            txtDate.Text = ""
            lblMessage.Text = "Please enter date in DD/MM/YYYY FORMAT"
            Exit Sub
        End Try
        D = Nothing
    End Sub

    Private Sub txtHeatNo1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHeatNo1.TextChanged
        lblMessage.Text = ""
        Try
            If RWF.Melting.CheckOffHeatNo(Val(txtHeatNo1.Text)) Then
                txtHeatNo1.Text = ""
                Throw New Exception("Off Heat No cannot be used !")
            Else
                'dgDRMMake.SelectedIndex = -1
                ' dgWRMMake.SelectedIndex = -1
                '  dgGMixMake.SelectedIndex = -1
                If RWF.Melting.CheckHeatNo(Val(txtHeatNo1.Text), 0) Then
                    ViewState("Heat") = Val(txtHeatNo1.Text)
                    SetHeat()
                    GetSheet1Data()
                Else
                    txtHeatNo1.Text = ""
                    SetPanel()
                    lblMessage.Text = "InValid Heat !"
                End If
            End If
            ScrapAccontalCB()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtHeatNo2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHeatNo2.TextChanged
        lblMessage.Text = ""
        Try
            If RWF.Melting.CheckOffHeatNo(Val(txtHeatNo2.Text)) Then
                txtHeatNo2.Text = ""
                Throw New Exception("Off Heat No cannot be used !")
            Else
                If RWF.Melting.CheckHeatNo(Val(txtHeatNo2.Text)) Then
                    ViewState("Heat") = Val(txtHeatNo2.Text)
                    SetHeat()
                    GetSheet2Data()
                Else
                    txtHeatNo2.Text = ""
                    SetPanel()
                    lblMessage.Text = "InValid Heat !"
                End If
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtHeatNo3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHeatNo3.TextChanged
        lblMessage.Text = ""
        Try
            If RWF.Melting.CheckOffHeatNo(Val(txtHeatNo3.Text)) Then
                txtHeatNo3.Text = ""
                Throw New Exception("Off Heat No cannot be used !")
            Else
                If RWF.Melting.CheckHeatNo(Val(txtHeatNo3.Text)) Then
                    ViewState("Heat") = Val(txtHeatNo3.Text)
                    SetHeat()
                    GetSheet3Data()
                Else
                    txtHeatNo3.Text = ""
                    SetPanel()
                    lblMessage.Text = "InValid Heat !"
                End If
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtHeatNoSample_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHeatNoSample.TextChanged
        lblMessage.Text = ""
        txtSampleNo.Text = ""
        ClearSample()
        Try
            If RWF.Melting.CheckOffHeatNo(Val(txtHeatNoSample.Text)) Then
                txtHeatNoSample.Text = ""
                Throw New Exception("Off Heat No cannot be used !")
            Else
                If RWF.Melting.CheckHeatNo(Val(txtHeatNoSample.Text)) Then
                    ViewState("Heat") = Val(txtHeatNoSample.Text)
                    SetHeat()
                    GetSampleData()
                Else
                    txtHeatNoSample.Text = ""
                    SetPanel()
                    lblMessage.Text = "InValid Heat !"
                End If
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        If RWF.Melting.IsMeltDateOfPreviousHeatGreater(CLng(ViewState("Heat")) - 1, CDate(txtDate.Text)) Then
            lblMessage.Text = "Melt Date Of Previous Heat Greater than Present Heat, Cannot be Edited !"
            Exit Sub
        End If
        If RWF.tables.CheckWorkingDate(Session("Group"), CDate(txtDate.Text)) Then
            lblMessage.Text = "Melt Date is declared as holiday by PCO. Contact PCO !"
            Exit Sub
        End If
        If Not Session("UserId") = "082616" Then
            If Not Session("UserId") = "074510" Then
                If RWF.Melting.CheckPHLDateForHeatNo(CLng(ViewState("Heat"))) Then
                    lblMessage.Text = "PHL Generated Heat, Cannot be Edited !"
                    Exit Sub
                End If
            End If
        End If
        Dim i As Integer
        Dim done As Boolean
        ' Radio button removed
        'For i = 0 To rblWO.Items.Count - 1
        '    If rblWO.Items(i).Selected = True Then
        '        done = True
        For i = 0 To DDLWO.Items.Count - 1
            If DDLWO.Items(i).Selected = True Then
                done = True
                Exit For
            End If
        Next
        If done Then
            done = False
        Else
            lblMessage.Text = "Please select WorkOrder before saving!"
            Exit Sub
        End If
        i = 0
        'For i = 0 To rblFur.Items.Count - 1
        '    If rblFur.Items(i).Selected = True Then
        '        done = True
        '        Exit For
        '    End If
        'Next
        For i = 0 To FurNo.Items.Count - 1
            If FurNo.Items(i).Selected = True Then
                done = True
                Exit For
            End If
        Next

        If done Then
            done = False
        Else
            lblMessage.Text = "Please select Furnace before saving!"
            Exit Sub
        End If
        Dim ETime As Date
        If rblBreakage.SelectedIndex = 1 Then
            i = 0
            For i = 0 To rblNo.Items.Count - 1
                If rblNo.Items(i).Selected = True Then
                    i = 1
                    Exit For
                End If
            Next
            If i = 0 Then
                lblMessage.Text = "Please select Breakage Electrode No before saving!"
                Exit Sub
            End If
            i = 0
            For i = 0 To rblReason.Items.Count - 1
                If rblReason.Items(i).Selected = True Then
                    i = 1
                    Exit For
                End If
            Next
            If i = 0 Then
                lblMessage.Text = "Please select Breakage Reason No before saving!"
                Exit Sub
            End If

            i = 0
            For i = 0 To rblLoc.Items.Count - 1
                If rblLoc.Items(i).Selected = True Then
                    i = 1
                    Exit For
                End If
            Next
            If i = 0 Then
                lblMessage.Text = "Please select Location before saving!"
                Exit Sub
            End If

            Try
                ETime = CDate(txtEDate.Text) & " " & Trim(txtETime.Text)
            Catch exp As Exception
                ETime = Now.Date
            End Try
        End If

        Try
            Try
                Dim EmptyWt As New LadleWeight.Empty(CLng(ViewState("Heat")), txtw1.Text)
                EmptyWt = Nothing
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
            Dim a As String
            ' done = New RWF.Melting().SaveHeatSheet(CLng(viewstate("Heat")), rblFur.SelectedItem.Text.Trim, CDate(txtDate.Text), rblShift.SelectedItem.Text, txtShift_incharge.Text.Trim, txtFurnace_incharge.Text.Trim, rblWO.SelectedItem.Value)
            done = New RWF.Melting().SaveHeatSheet(CLng(ViewState("Heat")), FurNo.SelectedItem.Text.Trim, CDate(txtDate.Text), rblShift.SelectedItem.Text, txtShift_incharge.Text.Trim, txtFurnace_incharge.Text.Trim, txtFurnace_Operator.Text.Trim,
 DDLWO.SelectedItem.Value)
            done = True
            If done Then
                done = False
                done = New RWF.Melting().SaveRoof(CLng(ViewState("Heat")), txtRoof_number.Text.Trim, Val(txtRoof_life.Text), txtRoof_delta.Text.Trim, txtRoof_outer.Text.Trim)
                If done Then
                    done = False
                    done = New RWF.Melting().SaveLadle(CLng(ViewState("Heat")), txtLadle_number.Text.Trim, Val(txtLadle_life.Text), txtLadle_bottom.Text.Trim, txtLadle_sidewall.SelectedItem.Text)
                    If done Then
                        done = False
                        'done = New RWF.Melting().SaveFurnace(CLng(viewstate("Heat")), rblFur.SelectedItem.Text.Trim, txtFurnace_bottom.Text.Trim, Val(txtFunace_life.Text), txtSidewall_up.Text.Trim, txtSidewall_lo.Text.Trim, txtBank.Text.Trim, CDate(txtDate.Text), rblShift.SelectedItem.Text, txtShift_incharge.Text.Trim)
                        'done = New RWF.Melting().SaveFurnace(CLng(ViewState("Heat")), FurNo.SelectedItem.Text.Trim, txtFurnace_bottom.Text.Trim, Val(txtFunace_life.Text), txtSidewall_up.Text.Trim, txtSidewall_lo.Text.Trim, txtBank.Text.Trim, CDate(txtDate.Text), rblShift.SelectedItem.Text, txtShift_incharge.Text.Trim)
                        done = New RWF.Melting().SaveFurnace(CLng(ViewState("Heat")), FurNo.SelectedItem.Text.Trim, txtFurnace_bottom.Text.Trim, Val(txtFunace_life.Text), txtSidewall_up.Text.Trim, txtSidewall_lo.Text.Trim, txtBank.Text.Trim, CDate(txtDate.Text), rblShift.SelectedItem.Text, txtShift_incharge.Text.Trim, FBRMK.Text.Trim, FSWURMK.Text.Trim, FSWLRMK.Text.Trim, FBTRMK.Text.Trim, Val(TXTDRM.Text), Val(TXTBRICK.Text))
                        If done Then
                            done = False
                            done = New RWF.Melting().SaveBucket(CLng(ViewState("Heat")), txtBucket_number.Text.Trim, txtBucket_enteredby.Text.Trim, txtBucket_number2.Text.Trim, txtBucket_enteredby2.Text.Trim, txtBucket_number3.Text.Trim, txtBucket_enteredby3.Text.Trim)
                            If done Then
                                done = False
                                ' value 0 is being inserted for txtRail_Cut,txtAxle_cut,txtAle_end
                                a = New RWF.Melting().SaveHeatCharge(CLng(ViewState("Heat")), 0, Val(txtRiserhub.Text), 0, 0, Val(txtPygmy_pot.Text), Val(txtWheel_cut.Text), Val(txtLMS.Text), Val(txtSlpr_cut.Text), Val(txtHot_heal.Text), 0, Val(txtTurningboring.Text), Val(txtWheel.Text), 0, 0, Val(txtNMgdust.Text), Val(txtNMclime.Text), 0, txtChargeRemarks.Text.Trim)
                                If Not a = "0" AndAlso Not a = "1" Then
                                    lblMessage.Text = a
                                    Exit Sub
                                Else
                                    done = Val(a)
                                End If
                                If done Then
                                    done = False
                                    done = New RWF.Melting().SaveFettling(CLng(ViewState("Heat")), txtFrmi_make.Text.Trim, Val(txtFrmi_quantity.Text), txtFWrmi_make.Text.Trim, Val(txtFWrmi_quantity.Text), txtFgmi_make.Text.Trim, Val(txtFgmi_quantity.Text))
                                    If done Then
                                        done = False
                                        done = New RWF.Melting().SaveElectrode(CLng(ViewState("Heat")), txtEmake_e1.Text.Trim, Val(txtEadded_e1.Text), txtEtip_e1.Text.Trim, txtEmake_e2.Text.Trim, Val(txtEadded_e2.Text), txtEtip_e2.Text.Trim, txtEmake_e3.Text.Trim, Val(txtEadded_e3.Text), txtEtip_e3.Text.Trim)
                                        If rblBreakage.SelectedIndex = 1 Then
                                            done = False
                                            done = New RWF.Melting().SaveElectrodeNew(CLng(ViewState("Heat")), rblNo.SelectedItem.Text, rblReason.SelectedItem.Text, ETime, txtERemarks.Text.Trim, rblLoc.SelectedItem.Text)
                                        End If
                                        If done Then
                                            done = False
                                            done = New RWF.Melting().SaveNonMetailic(CLng(ViewState("Heat")), Val(txtNMclime.Text), Val(txtNMgdust.Text), 0)
                                            If done Then
                                                lblMessage.Text = "All the tables inserted successfully"
                                            End If
                                        Else
                                            lblMessage.Text &= " Electrode data saving failed ! "
                                        End If
                                    Else
                                        lblMessage.Text &= " Fettling data saving failed ! "
                                    End If
                                Else
                                    lblMessage.Text &= " HeatCharge data saving failed ! "
                                End If
                            Else
                                lblMessage.Text &= " Bucket data saving failed ! "
                            End If
                        Else
                            lblMessage.Text &= " Furnace data saving failed ! "
                        End If
                    Else
                        lblMessage.Text &= " Ladle data saving failed ! "
                    End If
                Else
                    lblMessage.Text &= " Roof data saving failed ! "
                End If
            Else
                lblMessage.Text &= " Heat Sheet data saving failed ! "
            End If
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        Finally
            done = Nothing
            i = Nothing
        End Try
    End Sub

    Private Sub btnSheet2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSheet2.Click
        lblMessage.Text = ""
        If Not Session("UserId") = "082616" Then
            If Not Session("UserId") = "074510" Then
                If RWF.Melting.CheckPHLDateForHeatNo(CLng(ViewState("Heat"))) Then
                    lblMessage.Text = "PHL Generated Heat, Cannot be Edited !"
                    Exit Sub
                End If
            End If
        End If
        Dim Power_t101, Charge_met, Bucket_charge, Bucket_chargemet, Roof_in, Furnace, Roof_out, Charge_start, Charge_end, removed_material, Levelling As Date
        Dim PowerOn As String
        lblMessage.Text = ""
        'Try
        '    Power_t2 = CDate(txtPower_t2Date.Text) & " " & Trim(txtPower_t2.Text)
        'Catch exp As Exception
        '    Power_t2 = Now.Date
        'End Try
        'Try
        '    Power_t4 = CDate(txtPower_t4Date.Text) & " " & Trim(txtPower_t4.Text)
        'Catch exp As Exception
        '    Power_t4 = Now.Date
        'End Try
        'Try
        '    Power_t8 = CDate(txtPower_t8Date.Text) & " " & Trim(txtPower_t8.Text)
        'Catch exp As Exception
        '    Power_t8 = Now.Date
        'End Try
        'Try
        '    Power_t12 = CDate(txtPower_t12Date.Text) & " " & Trim(txtPower_t12.Text)
        'Catch exp As Exception
        '    Power_t12 = Now.Date
        'End Try
        Try
            Power_t101 = CDate(txtPower_t101Date.Text) & " " & Trim(txtPower_t101.Text)
        Catch exp As Exception
            Power_t101 = Now.Date
        End Try
        'Try
        '    Power_t102 = CDate(txtPower_t102Date.Text) & " " & Trim(txtPower_t102.Text)
        'Catch exp As Exception
        '    Power_t102 = Now.Date
        'End Try
        'Try
        '    Power_t6 = CDate(txtPower_t6Date.Text) & " " & Trim(txtPower_t6.Text)
        'Catch exp As Exception
        '    Power_t6 = Now.Date
        'End Try
        Try
            Charge_met = CDate(txtCharge_metDate.Text) & " " & Trim(txtCharge_met.Text)
        Catch exp As Exception
            Charge_met = Now.Date
        End Try
        Try
            Bucket_charge = CDate(txtBucket_chargeDate.Text) & " " & Trim(txtBucket_charge.Text)
        Catch exp As Exception
            Bucket_charge = Now.Date
        End Try
        Try
            Bucket_chargemet = CDate(txtBucket_chargemetDate.Text) & " " & Trim(txtBucket_chargemet.Text)
        Catch exp As Exception
            Bucket_chargemet = Now.Date
        End Try
        Try
            Roof_in = CDate(txtRoof_inDate.Text) & " " & Trim(txtRoof_in.Text)
        Catch exp As Exception
            Roof_in = Now.Date
        End Try
        Try
            Levelling = CDate(txtLevellingDate.Text) & " " & Trim(txtLevelling.Text)
        Catch exp As Exception
            Levelling = Now.Date
        End Try
        Try
            Furnace = CDate(txtFurnace_inspectionDate.Text) & " " & Trim(txtFurnace_inspection.Text)
        Catch exp As Exception
            Furnace = Now.Date
        End Try
        Try
            Roof_out = CDate(txtRoof_outtimeDate.Text) & " " & Trim(txtRoof_outtime.Text)
        Catch exp As Exception
            Roof_out = Now.Date
        End Try
        Try
            Charge_start = CDate(txtCharge_startDate.Text) & " " & Trim(txtCharge_start.Text)
        Catch exp As Exception
            Charge_start = Now.Date
        End Try
        Try
            Charge_end = CDate(txtCharge_endDate.Text) & " " & Trim(txtCharge_end.Text)
        Catch exp As Exception
            Charge_end = Now.Date
        End Try
        Try
            removed_material = CDate(txtremoved_materialDate.Text) & " " & Trim(txtremoved_material.Text)
        Catch exp As Exception
            removed_material = Now.Date
        End Try
        PowerOn = DDLPOWERON.SelectedItem.Value.Trim
        Dim done As Boolean
        Try
            'done = New RWF.Melting().SaveHeatLog(CLng(ViewState("Heat")), Furnace, Roof_out, Charge_start, Charge_end, removed_material, Levelling, Roof_in, Bucket_chargemet, Bucket_charge, Charge_met, Power_t6, Power_t101, Power_t4, Power_t8, Power_t102, Power_t12)
            done = New RWF.Melting().SaveHeatLog(CLng(ViewState("Heat")), Furnace, Roof_out, Charge_start, Charge_end, removed_material, Levelling, Roof_in, Bucket_chargemet, Bucket_charge, Charge_met, Power_t101, PowerOn)
            If done Then
                done = False
                done = New RWF.Melting().SaveInProcessAdditives(CLng(ViewState("Heat")), 0, Val(txtFfesi.Text), Val(txtfFeMn.Text), Val(txtFfloor.Text), Val(txtFlimestone.Text), Val(txtLsimn.Text), Val(txtLfesi.Text), Val(txtLFeMn.Text), Val(txtLfloor.Text), Val(txtLlimestone.Text), Val(txtFgdust.Text), Val(txtLgdust.Text), Val(txtfCalLime.Text), Val(txtrsm_dept.Text), Val(txtrsm_contract.Text), txtContractNo.Text.Trim)
                If done Then
                    GetContractDatails()
                    lblMessage.Text &= "Both the tables inserted successfully"
                Else
                    lblMessage.Text = " InProcessAdditives data saving failed !"
                End If
            Else
                lblMessage.Text &= " HeatLog Data Saving Failed !"
            End If
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
        done = Nothing
        'Power_t2 = Nothing
        'Power_t6 = Nothing
        'Power_t8 = Nothing
        'Power_t102 = Nothing
        Power_t101 = Nothing
        'Power_t4 = Nothing
        'Power_t12 = Nothing
        Charge_met = Nothing
        Bucket_charge = Nothing
        Bucket_chargemet = Nothing
        Roof_in = Nothing
        Furnace = Nothing
        Roof_out = Nothing
        Charge_start = Nothing
        Charge_end = Nothing
        removed_material = Nothing
        Levelling = Nothing
    End Sub
    Private Function CheckSampleValue() As Boolean
        Try
            If Val(txtCarbon.Text) > 2 Then
                Throw New Exception("Carbon Value more than 2 !")
            End If
            If Val(txtMn.Text) > 2 Then
                Throw New Exception("Manganese Value more than 2 !")
            End If
            If Val(txtSi.Text) > 2 Then
                Throw New Exception("Silicon Value more than 2 !")
            End If
            If Val(txtPhosph.Text) > 2 Then
                Throw New Exception("Phosphorous Value more than 2 !")
            End If
            If Val(txtSulpher.Text) > 2 Then
                Throw New Exception("Sulphur Value more than 2 !")
            End If
            If Val(txtCr.Text) > 12 Then
                Throw New Exception("Chromium Value more than 2 !")
            End If

            If Val(txtCu.Text) > 2 Then
                Throw New Exception("Copper Value more than 2 !")
            End If
            If Val(txtAl.Text) > 2 Then
                Throw New Exception("Aluminium Value more than 2 !")
            End If
            If Val(txtVen.Text) > 2 Then
                Throw New Exception("Vanadium Value more than 2 !")
            End If
            If Val(txtNi.Text) > 2 Then
                Throw New Exception("Nical Value more than 2 !")
            End If
            If Val(txtMoly.Text) > 2 Then
                Throw New Exception("Mollibdinium Value more than 2 !")
            End If
            If Val(txtNitro.Text) > 70 Then
                Throw New Exception("Nitrogen Value more than 70 !")
            End If
            If Val(txtHydro.Text) > 3 Then
                Throw New Exception("Hydrogen Value more than 3 !")
            End If
            CheckSampleValue = True
        Catch exp As Exception
            lblMessage.Text &= exp.Message & " Sample Data Addition Failed !"
        End Try
    End Function
    Private Sub btnSaveSample_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveSample.Click
        lblMessage.Text = ""
        If Not Session("UserId") = "082616" Then
            If Not Session("UserId") = "074510" Then
                If RWF.Melting.CheckPHLDateForHeatNo(CLng(ViewState("Heat"))) Then
                    lblMessage.Text = "PHL Generated Heat, Cannot be Edited !"
                    Exit Sub
                End If
            End If
        End If
        Try
            Dim done As Boolean
            If CheckSampleValue() Then
                Dim SampleTime As String
                SampleTime = txtSampleTimeHr.Text.Trim
                'SampleTime = txtSampleTimeHr.Text.Trim.PadLeft(2, "0").Substring(0, 2) + ":" + txtSampleTimeMin.Text.Trim.PadRight(2, "0").Substring(0, 2)
                If SampleTime = "00:00" Then SampleTime = ""
                done = New RWF.Melting().SaveSpectro(CLng(ViewState("Heat")), txtSampleNo.Text.Trim, Val(txtSampleTemp.Text), SampleTime, Val(txtNi.Text), Val(txtCarbon.Text), Val(txtMn.Text), Val(txtSi.Text), Val(txtPhosph.Text), Val(txtSulpher.Text), Val(txtCr.Text), Val(txtCu.Text), Val(txtAl.Text), Val(txtVen.Text), Val(txtMoly.Text), Val(txtNitro.Text), Val(txtHydro.Text))
                If done Then
                    lblMessage.Text = "Sample Data Added...."
                    GetSampleData()
                Else
                    lblMessage.Text = "Sample Data Addition Failed !"
                End If
            End If
            done = Nothing
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
    End Sub

    Private Sub btnDelay_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelay_save.Click
        lblMessage.Text = ""
        lblDelay.Text = ""
        If RWF.Melting.CheckPHLDateForHeatNo(CLng(ViewState("Heat"))) Then
            lblMessage.Text = "PHL Generated Heat, Cannot be Edited !"
            Exit Sub
        Else
            txtDelay_code.Text = Left(cboDelayCd.SelectedItem.Text, InStr(cboDelayCd.SelectedItem.Text, "-") - 1)
            Dim done As Boolean
            done = New RWF.Melting().SaveDelay(CLng(ViewState("Heat")), txtFromtime.Text.Trim, txtToTime.Text.Trim, txtRemarks.Text.Trim, txtDelay_code.Text.Trim)
            If done Then
                lblDelay.Text = "Inserted..."
            Else
                lblDelay.Text = "Failed to Insert data !"
            End If
            done = Nothing
        End If
    End Sub

    Private Sub btnSheet3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSheet3.Click
        lblMessage.Text = ""
        If Not Session("UserId") = "082616" Then
            If Not Session("UserId") = "074510" Then
                If RWF.Melting.CheckPHLDateForHeatNo(CLng(ViewState("Heat"))) Then
                    lblMessage.Text = "PHL Generated Heat, Cannot be Edited !"
                    Exit Sub
                End If
            End If
        End If
        Dim done As Boolean
        Dim HeatTapped As Date
        Dim TapTime As Decimal
        If txtw2.Text.Trim.Length = 0 Then txtw2.Text = "0"
        Try
            Dim AfterTapWt As New LadleWeight.AfterTap(CLng(ViewState("Heat")), txtw2.Text)
            AfterTapWt = Nothing
            Try
                HeatTapped = CDate(txtTapBeginDate.Text) & " " & txtTap_beginHr.Text.Trim '+ ":" + txtTap_beginMn.Text.Trim
            Catch exp As Exception
                HeatTapped = CDate(ViewState("melt_date"))
            End Try
            If HeatTapped > Now Then
                lblMessage.Text = "Present Heat TapTime greater than present time ! Cannot be saved !"
                Exit Sub
            End If
            Dim str As String = RWF.Melting.CheckPreviousHeatTapTime(CLng(ViewState("Heat")), HeatTapped)
            If str.Trim.Length > 0 Then
                lblMessage.Text = "Previous Heat TapTime : " & str & "  greater than present heat ! Cannot be saved !"
                Exit Sub
            End If
            Try
                TapTime = txtTap_beginHr.Text.Trim '+ "." + txtTap_beginMn.Text.Trim
            Catch exp As Exception
                TapTime = 0.0
            End Try
            done = New RWF.Melting().SavePostMelt(CLng(ViewState("Heat")), cboHeatStatus.SelectedItem.Value, rdBtnlst1.SelectedItem.Value, "", txtTip_make.SelectedItem.Text.Trim, txtLpipe_make.SelectedItem.Text.Trim, CInt(txtTip_quantity.Text), CInt(txtLpipe_quantity.Text), "", "", CInt(txtTap_temperature.Text), Val(TapTime), Val(txtTap_end.Text), Val(txtTap_laptime.Text), 0, CInt(txtJMPstart_temperature.Text), txtSlag_condition.SelectedItem.Text.Trim, txtLM_level.Text.Trim, "", txtJMP_ALstar.Text.Trim, txtLMlevel_final.Text.Trim, rdBtnlst2.SelectedItem.Value, txtTrail_material_methods.Text.Trim, HeatTapped, DDLLOF.Text, DDLSOS.Text)
            GetMakes()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            If done Then
                lblMessage.Text = "Updated...."
            Else
                lblMessage.Text &= " Updation Failed  !"
            End If
        End Try
        done = Nothing
        HeatTapped = Nothing
        TapTime = Nothing
    End Sub

    Private Sub rblSample_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblSample.SelectedIndexChanged
        lblMessage.Text = ""
        If Not Session("UserId") = "082616" Then
            If Not Session("UserId") = "074510" Then
                If RWF.Melting.CheckPHLDateForHeatNo(CLng(ViewState("Heat"))) Then
                    lblMessage.Text = "PHL Generated Heat, Cannot be Edited !"
                    Exit Sub
                End If
            End If
        End If
        Try
            FillSampleData()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub FillSampleData(Optional ByVal NewData As String = "")
        If NewData.Trim.Length = 0 Then
            txtSampleNo.Text = rblSample.SelectedItem.Text
            rblSample.ClearSelection()
        Else
            txtSampleNo.Text = txtSampleNo.Text.ToUpper
        End If
        Dim dt As DataTable
        Try
            dt = RWF.Melting.GetSampleData(CLng(ViewState("Heat")), txtSampleNo.Text.Trim)
            If dt.Rows.Count > 0 Then
                txtSampleTimeHr.Text = ""
                'txtSampleTimeMin.Text = ""
                If IsDBNull(dt.Rows(0)("SmpTime")) = False Then
                    If Not Trim(dt.Rows(0)("SmpTime")) = "" Then
                        Dim str As Array
                        str = Trim(dt.Rows(0)("SmpTime")).Split(":")
                        txtSampleTimeHr.Text = str(0) + ":" + str(1)
                        'txtSampleTimeMin.Text = str(1)
                    End If
                End If
                If IsDBNull(dt.Rows(0)("SmpTemp")) = False Then
                    txtSampleTemp.Text = dt.Rows(0)("SmpTemp")
                Else
                    txtSampleTemp.Text = ""
                End If
                If IsDBNull(dt.Rows(0)("C")) = False Then
                    txtCarbon.Text = dt.Rows(0)("C")
                Else
                    txtCarbon.Text = ""
                End If
                If IsDBNull(dt.Rows(0)("N")) = False Then
                    txtNi.Text = dt.Rows(0)("N")
                Else
                    txtNi.Text = ""
                End If
                If IsDBNull(dt.Rows(0)("Mn")) = False Then
                    txtMn.Text = dt.Rows(0)("Mn")
                Else
                    txtMn.Text = ""
                End If
                If IsDBNull(dt.Rows(0)("Cu")) = False Then
                    txtCu.Text = dt.Rows(0)("Cu")
                Else
                    txtCu.Text = ""
                End If
                If IsDBNull(dt.Rows(0)("V")) = False Then
                    txtVen.Text = dt.Rows(0)("V")
                Else
                    txtVen.Text = ""
                End If

                If IsDBNull(dt.Rows(0)("Si")) = False Then
                    txtSi.Text = dt.Rows(0)("Si")
                Else
                    txtSi.Text = ""
                End If

                If IsDBNull(dt.Rows(0)("P")) = False Then
                    txtPhosph.Text = dt.Rows(0)("P")
                Else
                    txtPhosph.Text = ""
                End If
                If IsDBNull(dt.Rows(0)("S")) = False Then
                    txtSulpher.Text = dt.Rows(0)("S")
                Else
                    txtSulpher.Text = ""
                End If

                If IsDBNull(dt.Rows(0)("Cr")) = False Then
                    txtCr.Text = dt.Rows(0)("Cr")
                Else
                    txtCr.Text = ""
                End If

                If IsDBNull(dt.Rows(0)("Al")) = False Then
                    txtAl.Text = dt.Rows(0)("Al")
                Else
                    txtAl.Text = ""
                End If
                If IsDBNull(dt.Rows(0)("Mo")) = False Then
                    txtMoly.Text = dt.Rows(0)("Mo")
                Else
                    txtMoly.Text = ""
                End If
                If IsDBNull(dt.Rows(0)("Ni")) = False Then
                    txtNitro.Text = dt.Rows(0)("Ni")
                Else
                    txtNitro.Text = ""
                End If
                If IsDBNull(dt.Rows(0)("H")) = False Then
                    txtHydro.Text = dt.Rows(0)("H")
                Else
                    txtHydro.Text = ""
                End If
                SetFocus(txtSampleTimeHr)
            Else
                ClearSample()
                SetFocus(txtSampleTimeHr)
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        dt = Nothing
    End Sub

    Private Sub txtSampleNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSampleNo.TextChanged
        lblMessage.Text = ""
        Try
            FillSampleData(txtSampleNo.Text.ToUpper)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnClearSample_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearSample.Click
        ClearSample()
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        ClearP1()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ClearP2()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        ClearP3()
    End Sub

    Private Sub btnDelay_clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelay_clear.Click
        ClearDelay()
    End Sub

    'Private Sub rblFur_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblFur.SelectedIndexChanged
    '    lblMessage.Text = ""
    '    Try
    '        txtRoof_number.Text = RWF.Melting.GetRoofNo(rblFur.SelectedItem.Text, Val(txtHeatNo1.Text))
    '        txtRoof_life.Text = RWF.Melting.GetRoofLife(txtRoof_number.Text)
    '        txtFunace_life.Text = RWF.Melting.GetFurnaceLife(rblFur.SelectedItem.Text)
    '    Catch exp As Exception
    '        lblMessage.Text = exp.Message
    '    End Try
    'End Sub

    Private Sub rdBtnlst2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdBtnlst2.SelectedIndexChanged
        lblMessage.Text = ""
        txtDelay_code.Text = cboDelayCd.SelectedItem.Value
        If rdBtnlst2.SelectedItem.Value = "1" Then
            Panel1.Visible = True
        Else
            Panel1.Visible = False
        End If
    End Sub

    Private Sub cboDelayCd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDelayCd.SelectedIndexChanged
        lblMessage.Text = ""
        txtDelay_code.Text = cboDelayCd.SelectedItem.Value
    End Sub

    'Private Sub dgTipMake_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgTipMake.ItemCommand
    '    If e.CommandName = "Select" Then
    '        txtTip_make.Text = e.Item.Cells(1).Text
    '    End If
    'End Sub

    'Private Sub dgLancingPipeMake_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgLancingPipeMake.ItemCommand
    '    If e.CommandName = "Select" Then
    '        txtLpipe_make.Text = e.Item.Cells(1).Text
    '    End If
    'End Sub

    Private Sub rblBreakage_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblBreakage.SelectedIndexChanged
        If rblBreakage.SelectedItem.Value = "Yes" Then
            lblMessage.Text = ""
            SetElectrode(, True)
            pnlElec.Visible = True
        Else
            pnlElec.Visible = False
        End If
    End Sub

    Private Sub SetElectrode(Optional ByVal Elec As Boolean = False, Optional ByVal Panel As Boolean = False)
        Dim dt As DataTable
        Dim i As Integer = 0
        Try
            pnlElec.Visible = False
            dt = RWF.Melting.GetSheet1ElectrodeDetails(Val(CLng(ViewState("Heat"))))
            rblReason.ClearSelection()
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt.Rows(0)("Location1")) = False Then
                    rblLoc.ClearSelection()
                    For i = 0 To rblLoc.Items.Count - 1
                        If rblLoc.Items(i).Text = IIf(IsDBNull(dt.Rows(0)("Location1")), "", Trim(dt.Rows(0)("Location1"))) Then
                            rblLoc.Items(i).Selected = True
                            Exit For
                        End If
                    Next
                End If
                i = 0
                If IsDBNull(dt.Rows(0)("e1Reason")) = False Then
                    If Not Elec Then
                        rblNo.ClearSelection()
                        For i = 0 To rblNo.Items.Count - 1
                            If rblNo.Items(i).Text.ToLower = "e1" Then
                                rblNo.Items(i).Selected = True
                                Exit For
                            End If
                        Next
                    End If
                    i = 0
                    For i = 0 To rblReason.Items.Count - 1
                        If rblReason.Items(i).Text = dt.Rows(0)("e1Reason") Then
                            rblReason.Items(i).Selected = True
                            Exit For
                        End If
                    Next
                    txtERemarks.Text = dt.Rows(0)("e1remark")
                    Try
                        txtEDate.Text = IIf(IsDBNull(dt.Rows(0)("e1Time")), CDate(ViewState("melt_date")), CDate(dt.Rows(0)("e1Time")).ToShortDateString)
                    Catch exp As Exception
                        txtEDate.Text = Now.Date
                    End Try
                    Try
                        txtETime.Text = IIf(IsDBNull(dt.Rows(0)("e1Time")), "00:00", Right(("0" + CDate(dt.Rows(0)("e1Time")).Hour.ToString), 2) + ":" + Right(("0" + CDate(dt.Rows(0)("e1Time")).Minute.ToString), 2))
                    Catch exp As Exception
                        txtETime.Text = "00:00"
                    End Try
                    If txtETime.Text = "00:00" Then
                        txtETime.Text = ""
                    End If
                    rblBreakage.SelectedIndex = 1
                    pnlElec.Visible = True
                Else
                    txtEDate.Text = txtDate.Text
                    txtERemarks.Text = ""
                End If
                i = 0
                If IsDBNull(dt.Rows(0)("e2Reason")) = False Then
                    rblLoc.ClearSelection()
                    For i = 0 To rblLoc.Items.Count - 1
                        If rblLoc.Items(i).Text.ToLower = IIf(IsDBNull(dt.Rows(0)("Location2")), "", dt.Rows(0)("Location2")) Then
                            rblLoc.Items(i).Selected = True
                            Exit For
                        End If
                    Next
                    i = 0
                    If Not Elec Then
                        rblNo.ClearSelection()
                        For i = 0 To rblNo.Items.Count - 1
                            If rblNo.Items(i).Text.ToLower = "e2" Then
                                rblNo.Items(i).Selected = True
                                Exit For
                            End If
                        Next
                    End If
                    i = 0
                    For i = 0 To rblReason.Items.Count - 1
                        If rblReason.Items(i).Text = dt.Rows(0)("e2Reason") Then
                            rblReason.Items(i).Selected = True
                            Exit For
                        End If
                    Next
                    txtERemarks.Text = dt.Rows(0)("e2remark")
                    Try
                        txtEDate.Text = IIf(IsDBNull(dt.Rows(0)("e2Time")), CDate(ViewState("melt_date")), CDate(dt.Rows(0)("e2Time")).ToShortDateString)
                    Catch exp As Exception
                        txtEDate.Text = Now.Date
                    End Try
                    Try
                        txtETime.Text = IIf(IsDBNull(dt.Rows(0)("e2Time")), "00:00", Right(("0" + CDate(dt.Rows(0)("e2Time")).Hour.ToString), 2) + ":" + Right(("0" + CDate(dt.Rows(0)("e2Time")).Minute.ToString), 2))
                    Catch exp As Exception
                        txtETime.Text = "00:00"
                    End Try
                    If txtETime.Text = "00:00" Then
                        txtETime.Text = ""
                    End If
                    rblBreakage.SelectedIndex = 1
                    pnlElec.Visible = True
                Else
                    txtEDate.Text = txtDate.Text
                    txtERemarks.Text = ""
                End If
                i = 0
                If IsDBNull(dt.Rows(0)("e3Reason")) = False Then
                    rblLoc.ClearSelection()
                    For i = 0 To rblLoc.Items.Count - 1
                        If rblLoc.Items(i).Text.ToLower = IIf(IsDBNull(dt.Rows(0)("Location3")), "", dt.Rows(0)("Location3")) Then
                            rblLoc.Items(i).Selected = True
                            Exit For
                        End If
                    Next
                    i = 0
                    If Not Elec Then
                        rblNo.ClearSelection()
                        For i = 0 To rblNo.Items.Count - 1
                            If rblNo.Items(i).Text.ToLower = "e3" Then
                                rblNo.Items(i).Selected = True
                                Exit For
                            End If
                        Next
                    End If
                    i = 0
                    For i = 0 To rblReason.Items.Count - 1
                        If rblReason.Items(i).Text = dt.Rows(0)("e3Reason") Then
                            rblReason.Items(i).Selected = True
                            Exit For
                        End If
                    Next
                    txtERemarks.Text = dt.Rows(0)("e3remark")
                    Try
                        txtEDate.Text = IIf(IsDBNull(dt.Rows(0)("e3Time")), CDate(ViewState("melt_date")), CDate(dt.Rows(0)("e3Time")).ToShortDateString)
                    Catch exp As Exception
                        txtEDate.Text = Now.Date
                    End Try
                    Try
                        txtETime.Text = IIf(IsDBNull(dt.Rows(0)("e3Time")), "00:00", Right(("0" + CDate(dt.Rows(0)("e3Time")).Hour.ToString), 2) + ":" + Right(("0" + CDate(dt.Rows(0)("e3Time")).Minute.ToString), 2))
                    Catch exp As Exception
                        txtETime.Text = "00:00"
                    End Try
                    If txtETime.Text = "00:00" Then
                        txtETime.Text = ""
                    End If
                    rblBreakage.SelectedIndex = 1
                    pnlElec.Visible = True
                Else
                    txtEDate.Text = txtDate.Text
                    txtERemarks.Text = ""
                End If
            End If
            If Panel Then pnlElec.Visible = True
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
    End Sub

    Private Sub rblNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblNo.SelectedIndexChanged
        lblMessage.Text = ""
        SetElectrode(True, True)
    End Sub

    'Private Sub dgDRMMake_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgDRMMake.ItemCommand
    '    If e.CommandName = "Select" Then
    '        txtFrmi_make.Text = e.Item.Cells(1).Text
    '    End If
    'End Sub

    'Private Sub dgWRMMake_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgWRMMake.ItemCommand
    '    If e.CommandName = "Select" Then
    '        txtFWrmi_make.Text = e.Item.Cells(1).Text
    '    End If
    'End Sub

    'Private Sub dgGMixMake_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgGMixMake.ItemCommand
    '    If e.CommandName = "Select" Then
    '        txtFgmi_make.Text = e.Item.Cells(1).Text
    '    End If
    'End Sub

    Private Sub txtContractNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtContractNo.TextChanged
        lblMessage.Text = ""
        txtContractNo.Text = txtContractNo.Text.Trim.ToUpper
        GetContractDatails()
    End Sub

    Private Sub GetContractDatails()
        dgContractNo.DataSource = Nothing
        dgContractNo.DataBind()
        Dim dt As DataTable
        Try
            dt = RWF.Melting.GetContractDetails(txtContractNo.Text.Trim)
            If dt.Rows.Count > 0 Then
                dgContractNo.DataSource = dt
                dgContractNo.DataBind()
            Else
                txtContractNo.Text = ""
                'as suggested by RWP no contract for RSM
                'Throw New Exception("InValid ContractNo !")
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub



    Private Sub FurNo_TextChanged(sender As Object, e As EventArgs) Handles FurNo.TextChanged
        lblMessage.Text = ""
        Try
            txtRoof_number.Text = RWF.Melting.GetRoofNo(FurNo.SelectedItem.Text, Val(txtHeatNo1.Text))
            lblMessage.Text = "Furnace No.  " & FurNo.SelectedItem.Text & "  selected "
            txtRoof_life.Text = RWF.Melting.GetRoofLife(txtRoof_number.Text)
            txtFunace_life.Text = RWF.Melting.GetFurnaceLife(FurNo.SelectedItem.Text)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Protected Sub txtFurnace_bottom_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtFurnace_bottom.SelectedIndexChanged
        If txtFurnace_bottom.SelectedItem.Text = "NOT OK" Then
            FBRMK.Visible = True
            FBRMK.Focus()
        Else
            FBRMK.Visible = False
        End If
    End Sub

    Protected Sub txtSidewall_up_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtSidewall_up.SelectedIndexChanged
        If txtSidewall_up.SelectedItem.Text = "NOT OK" Then
            FSWURMK.Visible = True
            FSWURMK.Focus()
        Else
            FSWURMK.Visible = False
        End If
    End Sub

    Private Sub txtSidewall_lo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtSidewall_lo.SelectedIndexChanged
        If txtSidewall_lo.SelectedItem.Text = "NOT OK" Then
            FSWLRMK.Visible = True
            FSWLRMK.Focus()
        Else
            FSWLRMK.Visible = False
        End If
    End Sub

    Protected Sub txtBank_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtBank.SelectedIndexChanged
        If txtBank.SelectedItem.Text = "NOT OK" Then
            FBTRMK.Visible = True
            FBTRMK.Focus()
        Else
            FBTRMK.Visible = False
        End If
    End Sub

    Protected Sub txtw2_TextChanged(sender As Object, e As EventArgs) Handles txtw2.TextChanged
        txtLMlevel_final.Text = Val(txtw2.Text) - Val(txtw1.Text)
    End Sub

    Protected Sub txtLadle_bottom_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtLadle_bottom.SelectedIndexChanged
        txtLadle_sidewall.Focus()
    End Sub

    Protected Sub txtLadle_sidewall_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtLadle_sidewall.SelectedIndexChanged
        txtRoof_number.Focus()
    End Sub

    Protected Sub txtTap_end_TextChanged(sender As Object, e As EventArgs) Handles txtTap_end.TextChanged

    End Sub
End Class
