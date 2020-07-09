Public Class AdminEnergyConsumption
    Inherits System.Web.UI.Page
    Protected WithEvents btnExit As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
    Protected WithEvents btnSubmit_Clicks As System.Web.UI.WebControls.Button
    Protected WithEvents lblSubstation_month As System.Web.UI.WebControls.Label
    Protected WithEvents lblSubstation_unit As System.Web.UI.WebControls.Label
    Protected WithEvents RangeValidator19 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents txtSubstation_final As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblAdmin_month As System.Web.UI.WebControls.Label
    Protected WithEvents lblAdmin_unit As System.Web.UI.WebControls.Label
    Protected WithEvents txtAdmin_final As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtAdmin_initial As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblColony_month As System.Web.UI.WebControls.Label
    Protected WithEvents lblColony_unit As System.Web.UI.WebControls.Label
    Protected WithEvents RangeValidator15 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents txtColony_final As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtColony_initial As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblPump_month As System.Web.UI.WebControls.Label
    Protected WithEvents lblPump_unit As System.Web.UI.WebControls.Label
    Protected WithEvents RangeValidator13 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents txtPump_final As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPump_initial As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblArc3_month As System.Web.UI.WebControls.Label
    Protected WithEvents lblArc3_unit As System.Web.UI.WebControls.Label
    Protected WithEvents RangeValidator11 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents txtArc3_final As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtArc3_initial As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblArc2_month As System.Web.UI.WebControls.Label
    Protected WithEvents lblArc2_unit As System.Web.UI.WebControls.Label
    Protected WithEvents RangeValidator10 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents txtArc2_final As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtArc2_initial As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblArc1_month As System.Web.UI.WebControls.Label
    Protected WithEvents lblArc1_unit As System.Web.UI.WebControls.Label
    Protected WithEvents RangeValidator9 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents txtArc1_final As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtArc1_initial As System.Web.UI.WebControls.TextBox
    Protected WithEvents RangeValidator8 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents lblKPTCL_month As System.Web.UI.WebControls.Label
    Protected WithEvents lblKPTCL_unit As System.Web.UI.WebControls.Label
    Protected WithEvents RangeValidator7 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents txtKPTCL_initial As System.Web.UI.WebControls.TextBox
    Protected WithEvents RangeValidator1 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents lblMode As System.Web.UI.WebControls.Label
    Protected WithEvents RequiredFieldValidator2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator3 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator4 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator5 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator6 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator7 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator8 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator9 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator10 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator11 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator12 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator13 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator14 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator15 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator16 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator17 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator18 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator19 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents lblDIFF_arc1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblDIFF_arc2 As System.Web.UI.WebControls.Label
    Protected WithEvents txtSubstation_initial As System.Web.UI.WebControls.TextBox
    Protected WithEvents Requiredfieldvalidator20 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Rangevalidator21 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents Requiredfieldvalidator21 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Requiredfieldvalidator22 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Rangevalidator23 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents Requiredfieldvalidator23 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RangeValidator17 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents lblAux_unit As System.Web.UI.WebControls.Label
    Protected WithEvents lblPCS_unit As System.Web.UI.WebControls.Label
    Protected WithEvents lblAux_month As System.Web.UI.WebControls.Label
    Protected WithEvents lblPCS_month As System.Web.UI.WebControls.Label
    Protected WithEvents lblDIFF_arc3 As System.Web.UI.WebControls.Label
    Protected WithEvents lblDIFF_pump As System.Web.UI.WebControls.Label
    Protected WithEvents lblDIFF_col As System.Web.UI.WebControls.Label
    Protected WithEvents lblDIFF_Admn As System.Web.UI.WebControls.Label
    Protected WithEvents lblDIFF_aux As System.Web.UI.WebControls.Label
    Protected WithEvents lblDIFF_emms As System.Web.UI.WebControls.Label
    Protected WithEvents lblDIFF_dcos As System.Web.UI.WebControls.Label
    Protected WithEvents lblDIFF_kptcl As System.Web.UI.WebControls.Label
    Protected WithEvents txtKPTCL_final As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtAux_final As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPCS_final As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtAux_initial As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPCS_initial As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnCalculateAll As System.Web.UI.WebControls.Button
    Protected WithEvents txtDGGenI_initial As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDGGenI_final As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblDIFF_dgI As System.Web.UI.WebControls.Label
    Protected WithEvents lblDGGenI_unit As System.Web.UI.WebControls.Label
    Protected WithEvents lblDGGenI_month As System.Web.UI.WebControls.Label
    Protected WithEvents txtDGGenII_initial As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDGGenII_final As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblDIFF_dgII As System.Web.UI.WebControls.Label
    ' Protected WithEvents lblDGGenII_unit As System.Web.UI.WebControls.Label
    ' Protected WithEvents lblDGGenII_month As System.Web.UI.WebControls.Label
    Protected WithEvents Requiredfieldvalidator24 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Rangevalidator25 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents Requiredfieldvalidator25 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents ddlMFkptcl As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlMFdgI As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlMFdgII As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlMFarcA As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlMFarcB As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlMFarcC As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlMFpump As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlMFcol As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlMFadmn As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlMFaux As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlMFemms As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlMFPCS As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlTubeESS As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlMeltESS As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlMouldESS As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlFumeESS As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtrwfgen_initial As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlPCSESS As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtrwfgen_final As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblDIFF_rwfgen As System.Web.UI.WebControls.Label
    Protected WithEvents ddlMFrwfgen As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblRwfgen_unit As System.Web.UI.WebControls.Label
    Protected WithEvents lblRwfgen_month As System.Web.UI.WebControls.Label
    Protected WithEvents txtDGGenIII_initial As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDGGenIII_final As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblDIFF_dgIII As System.Web.UI.WebControls.Label
    Protected WithEvents lblDGGenIII_unit As System.Web.UI.WebControls.Label
    Protected WithEvents lblDGGenIII_month As System.Web.UI.WebControls.Label
    Protected WithEvents ddlMFdgIII As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList

    Protected WithEvents txtColony12_final As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtColony12_initial As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblColony12_month As System.Web.UI.WebControls.Label
    Protected WithEvents lblColony12_unit As System.Web.UI.WebControls.Label
    Protected WithEvents ddlMFcol12 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblDIFF_col12 As System.Web.UI.WebControls.Label

    Protected WithEvents txtColony34_final As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtColony34_initial As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblColony34_month As System.Web.UI.WebControls.Label
    Protected WithEvents lblColony34_unit As System.Web.UI.WebControls.Label
    Protected WithEvents ddlMFcol34 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblDIFF_col34 As System.Web.UI.WebControls.Label

    Protected WithEvents MouldPHESS_initial As System.Web.UI.WebControls.TextBox
    Protected WithEvents MouldPHESS_final As System.Web.UI.WebControls.TextBox
    Protected WithEvents MouldPHESS_month As System.Web.UI.WebControls.Label
    Protected WithEvents MouldPHESS_unit As System.Web.UI.WebControls.Label
    Protected WithEvents ddlMouldPHESS As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblDIFF_MouldPHESS As System.Web.UI.WebControls.Label
    Protected WithEvents lblDIFF_PCS As System.Web.UI.WebControls.Label

    Protected WithEvents MeltESS_initial As System.Web.UI.WebControls.TextBox
    Protected WithEvents MeltESS_final As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMeltESS_month As System.Web.UI.WebControls.Label
    Protected WithEvents lblMeltESS_unit As System.Web.UI.WebControls.Label
    Protected WithEvents lblDIFF_MeltESS As System.Web.UI.WebControls.Label

    Protected WithEvents TubePHESS_initial As System.Web.UI.WebControls.TextBox
    Protected WithEvents TubePHESS_final As System.Web.UI.WebControls.TextBox
    Protected WithEvents TubePHESS_month As System.Web.UI.WebControls.Label
    Protected WithEvents TubePHESS_unit As System.Web.UI.WebControls.Label
    Protected WithEvents ddlTubePHESS As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblDIFF_TubePHESS As System.Web.UI.WebControls.Label

    Protected WithEvents FumePHESS_initial As System.Web.UI.WebControls.TextBox
    Protected WithEvents FumePHESS_final As System.Web.UI.WebControls.TextBox
    Protected WithEvents FumePHESS_month As System.Web.UI.WebControls.Label
    Protected WithEvents FumePHESS_unit As System.Web.UI.WebControls.Label
    Protected WithEvents ddlFumePHESS As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblDIFF_FumePHESS As System.Web.UI.WebControls.Label
    Protected WithEvents RangeValidator2 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents RangeValidator3 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents RangeValidator4 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents RangeValidator5 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents RangeValidator6 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents Requiredfieldvalidator28 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Requiredfieldvalidator26 As System.Web.UI.WebControls.RequiredFieldValidator


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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        If Not IsPostBack Then
            ' lblMode.Text = Request.QueryString("mode")
            lblMode.Text = "add"
            'lblMode.Text = "edit"
            'lblMode.Text = "delete"
            txtDate.Text = Now.Date
            Try
                GetTables()
                getUnitsforMonth()
                If lblMode.Text = "edit" Or lblMode.Text = "delete" Then
                    getUnitsforDay()
                Else
                    getInitialValues()
                End If
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub
    Private Sub GetTables()
        Dim dtMF As DataTable
        Try
            dtMF = Maintenance.ElecTables.GetMFValues
            getMFvalues(dtMF)
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            dtMF.Dispose()
        End Try
    End Sub
    Private Sub getMFvalues(ByRef dtMF As DataTable)
        Try
            FillDDL(ddlMFkptcl, dtMF)
            FillDDL(ddlMFdgI, dtMF)
            FillDDL(ddlMouldPHESS, dtMF)
            FillDDL(ddlMeltESS, dtMF)
            FillDDL(ddlMFarcA, dtMF)
            FillDDL(ddlMFarcB, dtMF)
            FillDDL(ddlMFarcC, dtMF)
            FillDDL(ddlMFpump, dtMF)
            FillDDL(ddlMFcol12, dtMF)
            FillDDL(ddlMFcol34, dtMF)
            FillDDL(ddlMFadmn, dtMF)
            FillDDL(ddlMFaux, dtMF)
            FillDDL(ddlMFemms, dtMF)
            FillDDL(ddlMFPCS, dtMF)
            FillDDL(ddlMFrwfgen, dtMF)
            FillDDL(ddlTubePHESS, dtMF)
            FillDDL(ddlFumePHESS, dtMF)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub FillDDL(ByRef ddl As System.Web.UI.WebControls.DropDownList, ByRef dt As DataTable)
        ddl.DataSource = dt.DefaultView
        ddl.DataTextField = dt.Columns(0).ColumnName
        ddl.DataValueField = dt.Columns(0).ColumnName
        ddl.DataBind()
    End Sub
    Private Sub getInitialValues()
        Dim dt As DataTable
        Try
            dt = Maintenance.ElecTables.getAdminInitialValues(CDate(txtDate.Text))
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows(0)(1)) Then txtKPTCL_initial.Text = dt.Rows(0)(1)
                If Not IsDBNull(dt.Rows(0)(2)) Then txtDGGenI_initial.Text = dt.Rows(0)(2)
                If Not IsDBNull(dt.Rows(0)(3)) Then txtArc1_initial.Text = dt.Rows(0)(3)
                If Not IsDBNull(dt.Rows(0)(4)) Then txtArc2_initial.Text = dt.Rows(0)(4)
                If Not IsDBNull(dt.Rows(0)(5)) Then txtArc3_initial.Text = dt.Rows(0)(5)
                If Not IsDBNull(dt.Rows(0)(6)) Then txtPump_initial.Text = dt.Rows(0)(6)
                If Not IsDBNull(dt.Rows(0)(7)) Then MeltESS_initial.Text = dt.Rows(0)(7)
                If Not IsDBNull(dt.Rows(0)(6)) Then TubePHESS_initial.Text = dt.Rows(0)(8)
                If Not IsDBNull(dt.Rows(0)(9)) Then MouldPHESS_initial.Text = dt.Rows(0)(9)
                If Not IsDBNull(dt.Rows(0)(10)) Then FumePHESS_initial.Text = dt.Rows(0)(10)
                If Not IsDBNull(dt.Rows(0)(11)) Then txtSubstation_initial.Text = dt.Rows(0)(11)
                If Not IsDBNull(dt.Rows(0)(12)) Then txtColony12_initial.Text = dt.Rows(0)(12)
                If Not IsDBNull(dt.Rows(0)(13)) Then txtColony34_initial.Text = dt.Rows(0)(13)
                If Not IsDBNull(dt.Rows(0)(14)) Then txtAdmin_initial.Text = dt.Rows(0)(14)
                If Not IsDBNull(dt.Rows(0)(15)) Then txtAux_initial.Text = dt.Rows(0)(15)
                If Not IsDBNull(dt.Rows(0)(16)) Then txtrwfgen_initial.Text = dt.Rows(0)(16)
                If Not IsDBNull(dt.Rows(0)(17)) Then txtPCS_initial.Text = dt.Rows(0)(17)
                If Not IsDBNull(dt.Rows(0)(18)) Then SelectDDL(ddlMFkptcl, CStr(dt.Rows(0)(18)))
                If Not IsDBNull(dt.Rows(0)(19)) Then SelectDDL(ddlMFdgI, CStr(dt.Rows(0)(19)))
                If Not IsDBNull(dt.Rows(0)(20)) Then SelectDDL(ddlMFarcA, CStr(dt.Rows(0)(20)))
                If Not IsDBNull(dt.Rows(0)(21)) Then SelectDDL(ddlMFarcB, CStr(dt.Rows(0)(21)))
                If Not IsDBNull(dt.Rows(0)(22)) Then SelectDDL(ddlMFarcC, CStr(dt.Rows(0)(22)))
                If Not IsDBNull(dt.Rows(0)(23)) Then SelectDDL(ddlMFpump, CStr(dt.Rows(0)(23)))
                If Not IsDBNull(dt.Rows(0)(24)) Then SelectDDL(ddlMeltESS, CStr(dt.Rows(0)(24)))
                If Not IsDBNull(dt.Rows(0)(25)) Then SelectDDL(ddlTubeESS, CStr(dt.Rows(0)(25)))
                If Not IsDBNull(dt.Rows(0)(26)) Then SelectDDL(ddlMouldESS, CStr(dt.Rows(0)(26)))
                If Not IsDBNull(dt.Rows(0)(27)) Then SelectDDL(ddlFumeESS, CStr(dt.Rows(0)(27)))
                If Not IsDBNull(dt.Rows(0)(28)) Then SelectDDL(ddlMFemms, CStr(dt.Rows(0)(28)))
                If Not IsDBNull(dt.Rows(0)(29)) Then SelectDDL(ddlMFcol12, CStr(dt.Rows(0)(29)))
                If Not IsDBNull(dt.Rows(0)(30)) Then SelectDDL(ddlMFcol34, CStr(dt.Rows(0)(30)))
                If Not IsDBNull(dt.Rows(0)(31)) Then SelectDDL(ddlMFadmn, CStr(dt.Rows(0)(31)))
                If Not IsDBNull(dt.Rows(0)(32)) Then SelectDDL(ddlMFaux, CStr(dt.Rows(0)(32)))
                If Not IsDBNull(dt.Rows(0)(33)) Then SelectDDL(ddlMFrwfgen, CStr(dt.Rows(0)(33)))
                If Not IsDBNull(dt.Rows(0)(34)) Then SelectDDL(ddlMFPCS, CStr(dt.Rows(0)(34)))


            Else
                Throw New Exception("No data for the Given Date !")
            End If
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            dt.Dispose()
        End Try
    End Sub
    Sub getUnitsforMonth()
        Dim dt As DataTable
        Try
            dt = Maintenance.ElecTables.getAdminUnitsforMonth(CDate(txtDate.Text))
            If IsNothing(dt) = False Then
                lblKPTCL_month.Text = IIf(IsDBNull(dt.Rows(0)("kptcl")), 0, dt.Rows(0)("kptcl"))
                lblDGGenI_month.Text = IIf(IsDBNull(dt.Rows(0)("dg1")), 0, dt.Rows(0)("dg1"))
                lblArc1_month.Text = IIf(IsDBNull(dt.Rows(0)("arc1")), 0, dt.Rows(0)("arc1"))
                lblArc2_month.Text = IIf(IsDBNull(dt.Rows(0)("arc2")), 0, dt.Rows(0)("arc2"))
                lblArc3_month.Text = IIf(IsDBNull(dt.Rows(0)("arc3")), 0, dt.Rows(0)("arc3"))
                lblPump_month.Text = IIf(IsDBNull(dt.Rows(0)("pumphouse")), 0, dt.Rows(0)("pumphouse"))
                lblMeltESS_month.Text = IIf(IsDBNull(dt.Rows(0)("Melt")), 0, dt.Rows(0)("Melt"))
                TubePHESS_month.Text = IIf(IsDBNull(dt.Rows(0)("Tube")), 0, dt.Rows(0)("Tube"))
                MouldPHESS_month.Text = IIf(IsDBNull(dt.Rows(0)("Mould")), 0, dt.Rows(0)("Mould"))
                FumePHESS_month.Text = IIf(IsDBNull(dt.Rows(0)("Fume")), 0, dt.Rows(0)("Fume"))
                lblSubstation_month.Text = IIf(IsDBNull(dt.Rows(0)("emms")), 0, dt.Rows(0)("emms"))
                lblColony12_month.Text = IIf(IsDBNull(dt.Rows(0)("colony12")), 0, dt.Rows(0)("colony12"))
                lblColony34_month.Text = IIf(IsDBNull(dt.Rows(0)("colony34")), 0, dt.Rows(0)("colony34"))
                lblAdmin_month.Text = IIf(IsDBNull(dt.Rows(0)("admn")), 0, dt.Rows(0)("admn"))
                lblAux_month.Text = IIf(IsDBNull(dt.Rows(0)("aux")), 0, dt.Rows(0)("aux"))
                lblRwfgen_month.Text = IIf(IsDBNull(dt.Rows(0)("rwfgen")), 0, dt.Rows(0)("rwfgen"))
                lblPCS_month.Text = IIf(IsDBNull(dt.Rows(0)("pcs")), 0, dt.Rows(0)("pcs"))

            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
        End Try
    End Sub
    Sub getUnitsforDay()
        Dim dt As DataTable
        Try
            dt = Maintenance.ElecTables.getAdminUnitsforDay(CDate(txtDate.Text))
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows(0)(1)) Then txtKPTCL_initial.Text = dt.Rows(0)(1)
                If Not IsDBNull(dt.Rows(0)(2)) Then txtKPTCL_final.Text = dt.Rows(0)(2)
                If Not IsDBNull(dt.Rows(0)(3)) Then txtDGGenI_initial.Text = dt.Rows(0)(3)
                If Not IsDBNull(dt.Rows(0)(4)) Then txtDGGenI_final.Text = dt.Rows(0)(4)
                If Not IsDBNull(dt.Rows(0)(5)) Then txtArc1_initial.Text = dt.Rows(0)(5)
                If Not IsDBNull(dt.Rows(0)(6)) Then txtArc1_final.Text = dt.Rows(0)(6)
                If Not IsDBNull(dt.Rows(0)(7)) Then txtArc2_initial.Text = dt.Rows(0)(7)
                If Not IsDBNull(dt.Rows(0)(8)) Then txtArc2_final.Text = dt.Rows(0)(8)
                If Not IsDBNull(dt.Rows(0)(9)) Then txtArc3_initial.Text = dt.Rows(0)(9)
                If Not IsDBNull(dt.Rows(0)(10)) Then txtArc3_final.Text = dt.Rows(0)(10)
                If Not IsDBNull(dt.Rows(0)(11)) Then txtPump_initial.Text = dt.Rows(0)(11)
                If Not IsDBNull(dt.Rows(0)(12)) Then txtPump_final.Text = dt.Rows(0)(12)
                If Not IsDBNull(dt.Rows(0)(13)) Then MeltESS_initial.Text = dt.Rows(0)(13)
                If Not IsDBNull(dt.Rows(0)(14)) Then MeltESS_final.Text = dt.Rows(0)(14)
                If Not IsDBNull(dt.Rows(0)(15)) Then TubePHESS_initial.Text = dt.Rows(0)(15)
                If Not IsDBNull(dt.Rows(0)(16)) Then TubePHESS_final.Text = dt.Rows(0)(16)
                If Not IsDBNull(dt.Rows(0)(17)) Then MouldPHESS_initial.Text = dt.Rows(0)(17)
                If Not IsDBNull(dt.Rows(0)(18)) Then MouldPHESS_final.Text = dt.Rows(0)(18)
                If Not IsDBNull(dt.Rows(0)(19)) Then FumePHESS_initial.Text = dt.Rows(0)(19)
                If Not IsDBNull(dt.Rows(0)(20)) Then FumePHESS_final.Text = dt.Rows(0)(20)
                If Not IsDBNull(dt.Rows(0)(21)) Then txtSubstation_initial.Text = dt.Rows(0)(21)
                If Not IsDBNull(dt.Rows(0)(22)) Then txtSubstation_final.Text = dt.Rows(0)(22)
                If Not IsDBNull(dt.Rows(0)(23)) Then txtColony12_initial.Text = dt.Rows(0)(23)
                If Not IsDBNull(dt.Rows(0)(24)) Then txtColony12_final.Text = dt.Rows(0)(24)
                If Not IsDBNull(dt.Rows(0)(25)) Then txtColony34_initial.Text = dt.Rows(0)(25)
                If Not IsDBNull(dt.Rows(0)(26)) Then txtColony34_final.Text = dt.Rows(0)(26)
                If Not IsDBNull(dt.Rows(0)(27)) Then txtAdmin_initial.Text = dt.Rows(0)(27)
                If Not IsDBNull(dt.Rows(0)(28)) Then txtAdmin_final.Text = dt.Rows(0)(28)
                If Not IsDBNull(dt.Rows(0)(29)) Then txtAux_initial.Text = dt.Rows(0)(29)
                If Not IsDBNull(dt.Rows(0)(30)) Then txtAux_final.Text = dt.Rows(0)(30)
                If Not IsDBNull(dt.Rows(0)(31)) Then txtrwfgen_initial.Text = dt.Rows(0)(31)
                If Not IsDBNull(dt.Rows(0)(32)) Then txtrwfgen_final.Text = dt.Rows(0)(32)
                If Not IsDBNull(dt.Rows(0)(33)) Then txtPCS_initial.Text = dt.Rows(0)(33)
                If Not IsDBNull(dt.Rows(0)(34)) Then txtPCS_final.Text = dt.Rows(0)(34)
                If Not IsDBNull(dt.Rows(0)(35)) Then SelectDDL(ddlMFkptcl, CStr(dt.Rows(0)(35)))
                If Not IsDBNull(dt.Rows(0)(36)) Then SelectDDL(ddlMFdgI, CStr(dt.Rows(0)(36)))
                If Not IsDBNull(dt.Rows(0)(37)) Then SelectDDL(ddlMFarcA, CStr(dt.Rows(0)(37)))
                If Not IsDBNull(dt.Rows(0)(38)) Then SelectDDL(ddlMFarcB, CStr(dt.Rows(0)(38)))
                If Not IsDBNull(dt.Rows(0)(39)) Then SelectDDL(ddlMFarcC, CStr(dt.Rows(0)(39)))
                If Not IsDBNull(dt.Rows(0)(40)) Then SelectDDL(ddlMFpump, CStr(dt.Rows(0)(40)))
                If Not IsDBNull(dt.Rows(0)(41)) Then SelectDDL(ddlMeltESS, CStr(dt.Rows(0)(41)))
                If Not IsDBNull(dt.Rows(0)(42)) Then SelectDDL(ddlTubeESS, CStr(dt.Rows(0)(42)))
                If Not IsDBNull(dt.Rows(0)(43)) Then SelectDDL(ddlMouldESS, CStr(dt.Rows(0)(43)))
                If Not IsDBNull(dt.Rows(0)(44)) Then SelectDDL(ddlFumeESS, CStr(dt.Rows(0)(44)))
                If Not IsDBNull(dt.Rows(0)(45)) Then SelectDDL(ddlMFemms, CStr(dt.Rows(0)(45)))
                If Not IsDBNull(dt.Rows(0)(46)) Then SelectDDL(ddlMFcol12, CStr(dt.Rows(0)(46)))
                If Not IsDBNull(dt.Rows(0)(47)) Then SelectDDL(ddlMFcol34, CStr(dt.Rows(0)(47)))
                If Not IsDBNull(dt.Rows(0)(48)) Then SelectDDL(ddlMFadmn, CStr(dt.Rows(0)(48)))
                If Not IsDBNull(dt.Rows(0)(49)) Then SelectDDL(ddlMFaux, CStr(dt.Rows(0)(49)))
                If Not IsDBNull(dt.Rows(0)(50)) Then SelectDDL(ddlMFrwfgen, CStr(dt.Rows(0)(50)))
                If Not IsDBNull(dt.Rows(0)(51)) Then SelectDDL(ddlMFPCS, CStr(dt.Rows(0)(51)))


            Else
                Throw New Exception("No data for the Given Date !")
            End If
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            dt.Dispose()
        End Try
    End Sub
    Private Sub SelectDDL(ByRef ddl As System.Web.UI.WebControls.DropDownList, ByRef dtVal As String)
        ddl.ClearSelection()
        Dim blnSelected As Boolean
        Dim i As Integer = 0
        For i = 0 To ddl.Items.Count - 1
            If ddl.Items(i).Text = CStr(dtVal) Then
                ddl.Items(i).Selected = True
                blnSelected = True
                Exit For
            End If
        Next
        If blnSelected = False Then
            ddl.Items(0).Selected = True
        End If
        blnSelected = False
    End Sub
    Private Sub txtDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged
        lblMessage.Text = ""
        Dim dt As Date
        Dim blnOK As Boolean
        Try
            dt = CDate(txtDate.Text.Trim)
            txtDate.Text = dt
            blnOK = True
        Catch exp As Exception
            txtDate.Text = ""
            blnOK = False
            lblMessage.Text = exp.Message
        End Try
        If blnOK = True Then
            blnOK = False
        Else
            Exit Sub
        End If
        Try
            clear()
            If lblMode.Text = "edit" Or lblMode.Text = "delete" Then
                If Maintenance.ElecTables.CheckTopAdminData(CDate(txtDate.Text)) > 0 Then
                    lblMessage.Text = " Data present for this date : '" & CDate(txtDate.Text) & "' cannot be EDITED for changing data ! "
                    txtDate.Text = ""
                    Exit Try
                Else
                    getUnitsforDay()
                    getUnitsforMonth()
                End If
            Else
                If Maintenance.ElecTables.CheckAdminData(CDate(txtDate.Text)) > 0 Then
                    lblMessage.Text = " Data present for this date ; Use EDIT mode for changing data of Date : '" & CDate(txtDate.Text) & "'"
                Else
                    getInitialValues()
                    getUnitsforMonth()
                End If
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub FillTexts(ByVal oObj As Object, ByVal TRname As String, ByVal initial As Decimal, ByVal final As Decimal, ByVal mf As Decimal, ByVal diff As System.Web.UI.WebControls.Label, ByVal units As System.Web.UI.WebControls.Label)
        Dim i As Int16
        For i = 0 To CType(oObj, Maintenance.Electrical.Energy).count - 1
            If CType(oObj, Maintenance.Electrical.Energy).TR(i).Name.ToLower = TRname.Trim.ToLower Then
                CType(oObj, Maintenance.Electrical.Energy).TR(i).Reading.initial = initial
                CType(oObj, Maintenance.Electrical.Energy).TR(i).Reading.final = final
                CType(oObj, Maintenance.Electrical.Energy).TR(i).Reading.rad = mf
                diff.Text = CType(oObj, Maintenance.Electrical.Energy).TR(i).Reading.diff
                units.Text = CType(oObj, Maintenance.Electrical.Energy).TR(i).Reading.units
                Exit For
            End If
        Next
    End Sub

    Private Sub btnSubmit_Clicks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit_Clicks.Click
        lblMessage.Text = ""
        Dim i As Int16
        Try
            Dim oAdmn As New Maintenance.Electrical.Energy()
            oAdmn.ConsumptionDate = CDate(txtDate.Text)

            FillTexts(oAdmn, "kptcl", IIf(IsDBNull(txtKPTCL_initial.Text), 0.0, (Val(txtKPTCL_initial.Text))), IIf(IsDBNull(txtKPTCL_final.Text), 0.0, (Val(txtKPTCL_final.Text))), (Val(ddlMFkptcl.SelectedItem.Text)), lblDIFF_kptcl, lblKPTCL_month)
            FillTexts(oAdmn, "dggen1", IIf(IsDBNull(txtDGGenI_initial.Text), 0.0, (Val(txtDGGenI_initial.Text))), IIf(IsDBNull(txtDGGenI_final.Text), 0.0, (Val(txtDGGenI_final.Text))), (Val(ddlMFdgI.SelectedItem.Text)), lblDIFF_dgI, lblDGGenI_month)
            FillTexts(oAdmn, "arc1", IIf(IsDBNull(txtArc1_initial.Text), 0.0, (Val(txtArc1_initial.Text))), IIf(IsDBNull(txtArc1_final.Text), 0.0, (Val(txtArc1_final.Text))), (Val(ddlMFarcA.SelectedItem.Text)), lblDIFF_arc1, lblArc1_month)
            FillTexts(oAdmn, "arc2", IIf(IsDBNull(txtArc2_initial.Text), 0.0, (Val(txtArc2_initial.Text))), IIf(IsDBNull(txtArc2_final.Text), 0.0, (Val(txtArc2_final.Text))), (Val(ddlMFarcB.SelectedItem.Text)), lblDIFF_arc2, lblArc2_month)
            FillTexts(oAdmn, "arc3", IIf(IsDBNull(txtArc3_initial.Text), 0.0, (Val(txtArc3_initial.Text))), IIf(IsDBNull(txtArc3_final.Text), 0.0, (Val(txtArc3_final.Text))), (Val(ddlMFarcC.SelectedItem.Text)), lblDIFF_arc3, lblArc3_month)
            FillTexts(oAdmn, "pump", IIf(IsDBNull(txtPump_initial.Text), 0.0, (Val(txtPump_initial.Text))), IIf(IsDBNull(txtPump_final.Text), 0.0, (Val(txtPump_final.Text))), (Val(ddlMFpump.SelectedItem.Text)), lblDIFF_pump, lblPump_month)
            FillTexts(oAdmn, "Melt", IIf(IsDBNull(MeltESS_initial.Text), 0.0, (Val(MeltESS_initial.Text))), IIf(IsDBNull(MeltESS_final.Text), 0.0, (Val(MeltESS_final.Text))), (Val(ddlMeltESS.SelectedItem.Text)), lblDIFF_MeltESS, lblMeltESS_month)
            FillTexts(oAdmn, "Tube", IIf(IsDBNull(TubePHESS_initial.Text), 0.0, (Val(TubePHESS_initial.Text))), IIf(IsDBNull(TubePHESS_final.Text), 0.0, (Val(TubePHESS_final.Text))), (Val(ddlTubePHESS.SelectedItem.Text)), lblDIFF_TubePHESS, TubePHESS_month)
            FillTexts(oAdmn, "Mould", IIf(IsDBNull(MouldPHESS_initial.Text), 0.0, (Val(MouldPHESS_initial.Text))), IIf(IsDBNull(MouldPHESS_final.Text), 0.0, (Val(MouldPHESS_final.Text))), (Val(ddlMouldPHESS.SelectedItem.Text)), lblDIFF_MouldPHESS, MouldPHESS_month)
            FillTexts(oAdmn, "Fume", IIf(IsDBNull(FumePHESS_initial.Text), 0.0, (Val(FumePHESS_initial.Text))), IIf(IsDBNull(FumePHESS_final.Text), 0.0, (Val(FumePHESS_final.Text))), (Val(ddlFumePHESS.SelectedItem.Text)), lblDIFF_FumePHESS, FumePHESS_month)
            FillTexts(oAdmn, "emms", IIf(IsDBNull(txtSubstation_initial.Text), 0.0, (Val(txtSubstation_initial.Text))), IIf(IsDBNull(txtSubstation_final.Text), 0.0, (Val(txtSubstation_final.Text))), (Val(ddlMFemms.SelectedItem.Text)), lblDIFF_emms, lblSubstation_month)
            FillTexts(oAdmn, "colony12", IIf(IsDBNull(txtColony12_initial.Text), 0.0, (Val(txtColony12_initial.Text))), IIf(IsDBNull(txtColony12_final.Text), 0.0, (Val(txtColony12_final.Text))), (Val(ddlMFcol12.SelectedItem.Text)), lblDIFF_col12, lblColony12_month)
            FillTexts(oAdmn, "colony34", IIf(IsDBNull(txtColony34_initial.Text), 0.0, (Val(txtColony34_initial.Text))), IIf(IsDBNull(txtColony34_final.Text), 0.0, (Val(txtColony34_final.Text))), (Val(ddlMFcol34.SelectedItem.Text)), lblDIFF_col34, lblColony34_month)
            FillTexts(oAdmn, "adminbldg", IIf(IsDBNull(txtAdmin_initial.Text), 0.0, (Val(txtAdmin_initial.Text))), IIf(IsDBNull(txtAdmin_final.Text), 0.0, (Val(txtAdmin_final.Text))), (Val(ddlMFadmn.SelectedItem.Text)), lblDIFF_Admn, lblAdmin_month)
            FillTexts(oAdmn, "stnaux", IIf(IsDBNull(txtAux_initial.Text), 0.0, (Val(txtAux_initial.Text))), IIf(IsDBNull(txtAux_final.Text), 0.0, (Val(txtAux_final.Text))), (Val(ddlMFaux.SelectedItem.Text)), lblDIFF_aux, lblAux_month)
            FillTexts(oAdmn, "rwfgen", IIf(IsDBNull(txtrwfgen_initial.Text), 0.0, (Val(txtrwfgen_initial.Text))), IIf(IsDBNull(txtrwfgen_final.Text), 0.0, (Val(txtrwfgen_final.Text))), (Val(ddlMFrwfgen.SelectedItem.Text)), lblDIFF_rwfgen, lblRwfgen_month)
            FillTexts(oAdmn, "pcs", IIf(IsDBNull(txtPCS_initial.Text), 0.0, (Val(txtPCS_initial.Text))), IIf(IsDBNull(txtPCS_final.Text), 0.0, (Val(txtPCS_final.Text))), (Val(ddlMFPCS.SelectedItem.Text)), lblDIFF_PCS, lblPCS_month)


            If lblMode.Text.ToLower = "add" Then
                oAdmn.SaveAdminEnergyConsumption(CDate("1900-01-01"))
            Else
                oAdmn.SaveAdminEnergyConsumption(CDate(txtDate.Text))
            End If
            lblMessage.Text = oAdmn.Message
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtKPTCL_final_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKPTCL_final.TextChanged
        Session("Date") = txtDate.Text
        lblMessage.Text = ""
        Try
            Try
                Dim d1, d2, val As Double
                d1 = txtKPTCL_final.Text
                d2 = txtKPTCL_initial.Text
                val = (d1 - d2)
                lblDIFF_kptcl.Text = val
            Catch exp As Exception
                lblMessage.Text = "Enter Numeric Values"
                Exit Sub
            End Try
            If CDbl(txtKPTCL_final.Text) < CDbl(txtKPTCL_initial.Text) Then
                lblMessage.Text = "Final Reading is Less Than Initial"
                txtKPTCL_initial.Text = ""
                Exit Sub
            End If
            If txtKPTCL_final.Text = "" And txtKPTCL_initial.Text = "" Then

            Else
                lblKPTCL_unit.Text = CDbl(txtKPTCL_final.Text) - CDbl(txtKPTCL_initial.Text)
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub


    Private Sub txtArc1_final_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtArc1_final.TextChanged
        lblMessage.Text = ""
        Try
            Try
                Dim d1, d2, val As Double
                d1 = txtArc1_final.Text
                d2 = txtArc1_initial.Text
                val = (d1 - d2)
                lblDIFF_arc1.Text = val
            Catch exp As Exception
                lblMessage.Text = "Enter Numeric Values"
                Exit Sub
            End Try
            If CDbl(txtArc1_final.Text) < CDbl(txtArc1_initial.Text) Then
                lblMessage.Text = "Final Reading is Less Than Initial"
                txtArc1_initial.Text = ""
                Exit Sub
            End If
            If txtArc1_final.Text = "" And txtArc1_initial.Text = "" Then

            Else
                lblArc1_unit.Text = CDbl(txtArc1_final.Text) - CDbl(txtArc1_initial.Text)
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtArc2_final_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtArc2_final.TextChanged
        lblMessage.Text = ""
        Try
            Try
                Dim d1, d2, val As Double
                d1 = txtArc2_final.Text
                d2 = txtArc2_initial.Text
                val = (d1 - d2)
                lblDIFF_arc2.Text = val
            Catch exp As Exception
                lblMessage.Text = "Enter Numeric Values"
                Exit Sub
            End Try
            If CDbl(txtArc2_final.Text) < CDbl(txtArc2_initial.Text) Then
                lblMessage.Text = "Final Reading is Less Than Initial"
                txtArc2_initial.Text = ""
                Exit Sub
            End If
            If txtArc2_final.Text = "" And txtArc2_initial.Text = "" Then

            Else
                lblArc2_unit.Text = CDbl(txtArc2_final.Text) - CDbl(txtArc2_initial.Text)
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtArc3_final_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtArc3_final.TextChanged
        lblMessage.Text = ""
        Try
            Try
                Dim d1, d2, val As Double
                d1 = txtArc3_final.Text
                d2 = txtArc3_initial.Text
                val = (d1 - d2)
                lblDIFF_arc3.Text = val
            Catch exp As Exception
                lblMessage.Text = "Enter Numeric Values"
                Exit Sub
            End Try
            If CDbl(txtArc3_final.Text) < CDbl(txtArc3_initial.Text) Then
                lblMessage.Text = "Final Reading is Less Than Initial"
                txtArc3_initial.Text = ""
                Exit Sub
            End If
            If txtArc3_final.Text = "" And txtArc3_initial.Text = "" Then

            Else
                lblArc3_unit.Text = CDbl(txtArc3_final.Text) - CDbl(txtArc3_initial.Text)
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub MeltESS_final_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MeltESS_final.TextChanged
        lblMessage.Text = ""
        Try
            Try
                Dim d1, d2, val As Double
                d1 = MeltESS_final.Text
                d2 = MeltESS_initial.Text
                val = (d1 - d2)
                lblDIFF_MeltESS.Text = val
            Catch exp As Exception
                lblMessage.Text = "Enter Numeric Values"
                Exit Sub
            End Try
            If CDbl(MeltESS_final.Text) < CDbl(MeltESS_initial.Text) Then
                lblMessage.Text = "Final Reading is Less Than Initial"
                MeltESS_initial.Text = ""
                Exit Sub
            End If
            If MeltESS_final.Text = "" And MeltESS_initial.Text = "" Then

            Else
                lblMeltESS_unit.Text = CDbl(MeltESS_final.Text) - CDbl(MeltESS_initial.Text)
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub TubePHESS_final_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TubePHESS_final.TextChanged
        lblMessage.Text = ""
        ' lblTubePHESS_unit.Text = "Fi"
        Try
            Try
                Dim d1, d2, val As Double
                d1 = TubePHESS_final.Text
                d2 = TubePHESS_initial.Text
                val = (d1 - d2)
                lblDIFF_TubePHESS.Text = val
                ' lblTubePHESS_unit.Text = val
            Catch exp As Exception
                lblMessage.Text = "Enter Numeric Values"
                Exit Sub
            End Try
            If CDbl(TubePHESS_final.Text) < CDbl(TubePHESS_initial.Text) Then
                lblMessage.Text = "Final Reading is Less Than Initial"
                TubePHESS_initial.Text = ""
                Exit Sub
            End If
            ' If TubePHESS_final.Text = "" And TubePHESS_initial.Text = "" Then

            'Else
            TubePHESS_unit.Text = CDbl(TubePHESS_final.Text) - CDbl(TubePHESS_initial.Text)
            ' End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub MouldPHESS_final_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MouldPHESS_final.TextChanged
        lblMessage.Text = ""
        Try
            Try
                Dim d1, d2, val As Double
                d1 = MouldPHESS_final.Text
                d2 = MouldPHESS_initial.Text
                val = (d1 - d2)
                lblDIFF_MouldPHESS.Text = val

            Catch exp As Exception
                lblMessage.Text = "Enter Numeric Values"
                Exit Sub
            End Try
            If CDbl(MouldPHESS_final.Text) < CDbl(MouldPHESS_initial.Text) Then
                lblMessage.Text = "Final Reading is Less Than Initial"
                MouldPHESS_initial.Text = ""
                Exit Sub
            End If
            If MouldPHESS_final.Text = "" And MouldPHESS_initial.Text = "" Then

            Else
                MouldPHESS_unit.Text = CDbl(MouldPHESS_final.Text) - CDbl(MouldPHESS_initial.Text)
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub txtPump_final_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPump_final.TextChanged
        lblMessage.Text = ""
        Try
            Try
                Dim d1, d2, val As Double
                d1 = txtPump_final.Text
                d2 = txtPump_initial.Text
                val = (d1 - d2)
                lblDIFF_pump.Text = val
            Catch exp As Exception
                lblMessage.Text = "Enter Numeric Values"
                Exit Sub
            End Try
            If CDbl(txtPump_final.Text) < CDbl(txtPump_initial.Text) Then
                lblMessage.Text = "Final Reading is Less Than Initial"
                txtPump_initial.Text = ""
                Exit Sub
            End If
            If txtPump_final.Text = "" And txtPump_initial.Text = "" Then

            Else
                lblPump_unit.Text = CDbl(txtPump_final.Text) - CDbl(txtPump_initial.Text)
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub FumePHESS_final_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FumePHESS_final.TextChanged
        lblMessage.Text = ""
        Try
            Try
                Dim d1, d2, val As Double
                d1 = FumePHESS_final.Text
                d2 = FumePHESS_initial.Text
                val = (d1 - d2)
                lblDIFF_FumePHESS.Text = val
            Catch exp As Exception
                lblMessage.Text = "Enter Numeric Values"
                Exit Sub
            End Try
            If CDbl(FumePHESS_final.Text) < CDbl(FumePHESS_initial.Text) Then
                lblMessage.Text = "Final Reading is Less Than Initial"
                FumePHESS_initial.Text = ""
                Exit Sub
            End If
            If FumePHESS_final.Text = "" And FumePHESS_initial.Text = "" Then

            Else
                FumePHESS_unit.Text = CDbl(FumePHESS_final.Text) - CDbl(FumePHESS_initial.Text)
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtColony12_final_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtColony12_final.TextChanged
        lblMessage.Text = ""
        Try
            Try
                Dim d1, d2, val As Double
                d1 = txtColony12_final.Text
                d2 = txtColony12_initial.Text
                val = (d1 - d2)
                lblDIFF_col12.Text = val
            Catch exp As Exception
                lblMessage.Text = "Enter Numeric Values"
                Exit Sub
            End Try
            If CDbl(txtColony12_final.Text) < CDbl(txtColony12_initial.Text) Then
                lblMessage.Text = "Final Reading is Less Than Initial"
                txtColony_initial.Text = ""
                Exit Sub
            End If
            If txtColony12_final.Text = "" And txtColony12_initial.Text = "" Then

            Else
                lblColony12_unit.Text = CDbl(txtColony12_final.Text) - CDbl(txtColony12_initial.Text)
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtColony34_final_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtColony34_final.TextChanged
        lblMessage.Text = ""
        Try
            Try
                Dim d1, d2, val As Double
                d1 = txtColony34_final.Text
                d2 = txtColony34_initial.Text
                val = (d1 - d2)
                lblDIFF_col34.Text = val
            Catch exp As Exception
                lblMessage.Text = "Enter Numeric Values"
                Exit Sub
            End Try
            If CDbl(txtColony34_final.Text) < CDbl(txtColony34_initial.Text) Then
                lblMessage.Text = "Final Reading is Less Than Initial"
                txtColony34_initial.Text = ""
                Exit Sub
            End If
            If txtColony34_final.Text = "" And txtColony34_initial.Text = "" Then

            Else
                lblColony34_unit.Text = CDbl(txtColony34_final.Text) - CDbl(txtColony34_initial.Text)
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtAdmin_final_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAdmin_final.TextChanged
        lblMessage.Text = ""
        Try
            Try
                Dim d1, d2, val As Double
                d1 = txtAdmin_final.Text
                d2 = txtAdmin_initial.Text
                val = (d1 - d2)
                lblDIFF_Admn.Text = val
            Catch exp As Exception
                lblMessage.Text = "Enter Numeric Values"
                Exit Sub
            End Try
            If CDbl(txtAdmin_final.Text) < CDbl(txtAdmin_initial.Text) Then
                lblMessage.Text = "Final Reading is Less Than Initial"
                txtAdmin_initial.Text = ""
                Exit Sub
            End If
            If txtAdmin_final.Text = "" And txtAdmin_initial.Text = "" Then

            Else
                lblAdmin_unit.Text = CDbl(txtAdmin_final.Text) - CDbl(txtAdmin_initial.Text)
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtPCS_final_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPCS_final.TextChanged
        lblMessage.Text = ""
        Try
            Try
                Dim d1, d2, val As Double
                d1 = txtPCS_final.Text
                d2 = txtPCS_initial.Text
                val = (d1 - d2)
                lblDIFF_PCS.Text = val
            Catch exp As Exception
                lblMessage.Text = "Enter Numeric Values"
                Exit Sub
            End Try
            If CDbl(txtPCS_final.Text) < CDbl(txtPCS_initial.Text) Then
                lblMessage.Text = "Final Reading is Less Than Initial"
                txtPCS_initial.Text = ""
                Exit Sub
            End If
            If txtPCS_final.Text = "" And txtPCS_initial.Text = "" Then

            Else
                lblPCS_unit.Text = CDbl(txtPCS_final.Text) - CDbl(txtPCS_initial.Text)
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtSubstation_final_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSubstation_final.TextChanged
        lblMessage.Text = ""
        Try
            Try
                Dim d1, d2, val As Double
                d1 = txtSubstation_final.Text
                d2 = txtSubstation_initial.Text
                val = (d1 - d2)
                lblDIFF_emms.Text = val
            Catch exp As Exception
                lblMessage.Text = "Enter Numeric Values"
                Exit Sub
            End Try
            If CDbl(txtSubstation_final.Text) < CDbl(txtSubstation_initial.Text) Then
                lblMessage.Text = "Final Reading is Less Than Initial"
                txtSubstation_initial.Text = ""
                Exit Sub
            End If
            If txtSubstation_final.Text = "" And txtSubstation_initial.Text = "" Then

            Else
                lblSubstation_unit.Text = CDbl(txtSubstation_final.Text) - CDbl(txtSubstation_initial.Text)
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        clear()
        lblMessage.Text = ""
    End Sub

    Sub clear()
        txtKPTCL_final.Text = ""
        txtKPTCL_initial.Text = ""
        txtDGGenI_initial.Text = ""
        txtDGGenI_final.Text = ""
        txtDGGenII_initial.Text = ""
        txtDGGenII_final.Text = ""
        txtDGGenIII_initial.Text = ""
        txtDGGenIII_final.Text = ""
        txtArc1_initial.Text = ""
        txtArc1_final.Text = ""
        txtArc2_initial.Text = ""
        txtArc2_final.Text = ""
        txtArc3_initial.Text = ""
        txtArc3_final.Text = ""
        txtPump_initial.Text = ""
        txtPump_final.Text = ""
        txtColony_initial.Text = ""
        txtColony_final.Text = ""
        txtAdmin_initial.Text = ""
        txtAdmin_final.Text = ""
        txtAux_initial.Text = ""
        txtAux_final.Text = ""
        txtSubstation_initial.Text = ""
        txtSubstation_final.Text = ""
        'txtDCOS_initial.Text = ""
        'txtDCOS_final.Text = ""
        lblKPTCL_month.Text = ""
        'lblGenerated_month.Text = ""
        lblArc1_month.Text = ""
        lblArc2_month.Text = ""
        lblArc3_month.Text = ""
        lblPump_month.Text = ""
        lblColony12_month.Text = ""
        lblColony34_month.Text = ""
        lblAdmin_month.Text = ""
        lblSubstation_month.Text = ""
        lblKPTCL_unit.Text = ""
        lblDGGenI_unit.Text = ""
        'lblDGGenII_unit.Text = ""
        lblArc1_unit.Text = ""
        lblArc2_unit.Text = ""
        lblArc3_unit.Text = ""
        lblPump_unit.Text = ""
        lblColony_unit.Text = ""
        lblAdmin_unit.Text = ""
        lblAux_unit.Text = ""
        lblSubstation_unit.Text = ""
        'lblDCOS_unit.Text = ""
    End Sub

    Private Sub InitializeComponent()

    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Server.Transfer("/wap/selectModule.aspx")
    End Sub

    Private Sub txtAux_final_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAux_final.TextChanged
        lblMessage.Text = ""
        Try
            Try
                Dim d1, d2, val As Double
                d1 = txtAux_final.Text
                d2 = txtAux_initial.Text
                val = (d1 - d2)
                lblDIFF_aux.Text = val
            Catch exp As Exception
                lblMessage.Text = "Enter Numeric Values"
                Exit Sub
            End Try
            If CDbl(txtAux_final.Text) < CDbl(txtAux_initial.Text) Then
                lblMessage.Text = "Final Reading is Less Than Initial"
                txtAux_initial.Text = ""
                Exit Sub
            End If
            If txtAux_final.Text = "" And txtAux_initial.Text = "" Then
            Else
                lblAux_unit.Text = CDbl(txtAux_final.Text) - CDbl(txtAux_initial.Text)
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub



    Private Sub btnCalculateAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalculateAll.Click
        Try

            Dim oAdmn As New Maintenance.Electrical.Energy()
            oAdmn.ConsumptionDate = CDate(txtDate.Text)

            FillTexts(oAdmn, "kptcl", IIf(IsDBNull(txtKPTCL_initial.Text), 0.0, (Val(txtKPTCL_initial.Text))), IIf(IsDBNull(txtKPTCL_final.Text), 0.0, (Val(txtKPTCL_final.Text))), (Val(ddlMFkptcl.SelectedItem.Text)), lblDIFF_kptcl, lblKPTCL_month)
            FillTexts(oAdmn, "dggen1", IIf(IsDBNull(txtDGGenI_initial.Text), 0.0, (Val(txtDGGenI_initial.Text))), IIf(IsDBNull(txtDGGenI_final.Text), 0.0, (Val(txtDGGenI_final.Text))), (Val(ddlMFdgI.SelectedItem.Text)), lblDIFF_dgI, lblDGGenI_month)
            FillTexts(oAdmn, "arc1", IIf(IsDBNull(txtArc1_initial.Text), 0.0, (Val(txtArc1_initial.Text))), IIf(IsDBNull(txtArc1_final.Text), 0.0, (Val(txtArc1_final.Text))), (Val(ddlMFarcA.SelectedItem.Text)), lblDIFF_arc1, lblArc1_month)
            FillTexts(oAdmn, "arc2", IIf(IsDBNull(txtArc2_initial.Text), 0.0, (Val(txtArc2_initial.Text))), IIf(IsDBNull(txtArc2_final.Text), 0.0, (Val(txtArc2_final.Text))), (Val(ddlMFarcB.SelectedItem.Text)), lblDIFF_arc2, lblArc2_month)
            FillTexts(oAdmn, "arc3", IIf(IsDBNull(txtArc3_initial.Text), 0.0, (Val(txtArc3_initial.Text))), IIf(IsDBNull(txtArc3_final.Text), 0.0, (Val(txtArc3_final.Text))), (Val(ddlMFarcC.SelectedItem.Text)), lblDIFF_arc3, lblArc3_month)
            FillTexts(oAdmn, "pump", IIf(IsDBNull(txtPump_initial.Text), 0.0, (Val(txtPump_initial.Text))), IIf(IsDBNull(txtPump_final.Text), 0.0, (Val(txtPump_final.Text))), (Val(ddlMFpump.SelectedItem.Text)), lblDIFF_pump, lblPump_month)
            FillTexts(oAdmn, "Melt", IIf(IsDBNull(MeltESS_initial.Text), 0.0, (Val(MeltESS_initial.Text))), IIf(IsDBNull(MeltESS_final.Text), 0.0, (Val(MeltESS_final.Text))), (Val(ddlMeltESS.SelectedItem.Text)), lblDIFF_MeltESS, lblMeltESS_month)
            FillTexts(oAdmn, "Tube", IIf(IsDBNull(TubePHESS_initial.Text), 0.0, (Val(TubePHESS_initial.Text))), IIf(IsDBNull(TubePHESS_final.Text), 0.0, (Val(TubePHESS_final.Text))), (Val(ddlTubePHESS.SelectedItem.Text)), lblDIFF_TubePHESS, TubePHESS_month)
            FillTexts(oAdmn, "Mould", IIf(IsDBNull(MouldPHESS_initial.Text), 0.0, (Val(MouldPHESS_initial.Text))), IIf(IsDBNull(MouldPHESS_final.Text), 0.0, (Val(MouldPHESS_final.Text))), (Val(ddlMouldPHESS.SelectedItem.Text)), lblDIFF_MouldPHESS, MouldPHESS_month)
            FillTexts(oAdmn, "Fume", IIf(IsDBNull(FumePHESS_initial.Text), 0.0, (Val(FumePHESS_initial.Text))), IIf(IsDBNull(FumePHESS_final.Text), 0.0, (Val(FumePHESS_final.Text))), (Val(ddlFumePHESS.SelectedItem.Text)), lblDIFF_FumePHESS, FumePHESS_month)
            FillTexts(oAdmn, "emms", IIf(IsDBNull(txtSubstation_initial.Text), 0.0, (Val(txtSubstation_initial.Text))), IIf(IsDBNull(txtSubstation_final.Text), 0.0, (Val(txtSubstation_final.Text))), (Val(ddlMFemms.SelectedItem.Text)), lblDIFF_emms, lblSubstation_month)
            FillTexts(oAdmn, "colony12", IIf(IsDBNull(txtColony12_initial.Text), 0.0, (Val(txtColony12_initial.Text))), IIf(IsDBNull(txtColony12_final.Text), 0.0, (Val(txtColony12_final.Text))), (Val(ddlMFcol12.SelectedItem.Text)), lblDIFF_col12, lblColony12_month)
            FillTexts(oAdmn, "colony34", IIf(IsDBNull(txtColony34_initial.Text), 0.0, (Val(txtColony34_initial.Text))), IIf(IsDBNull(txtColony34_final.Text), 0.0, (Val(txtColony34_final.Text))), (Val(ddlMFcol34.SelectedItem.Text)), lblDIFF_col34, lblColony34_month)
            FillTexts(oAdmn, "adminbldg", IIf(IsDBNull(txtAdmin_initial.Text), 0.0, (Val(txtAdmin_initial.Text))), IIf(IsDBNull(txtAdmin_final.Text), 0.0, (Val(txtAdmin_final.Text))), (Val(ddlMFadmn.SelectedItem.Text)), lblDIFF_Admn, lblAdmin_month)
            FillTexts(oAdmn, "stnaux", IIf(IsDBNull(txtAux_initial.Text), 0.0, (Val(txtAux_initial.Text))), IIf(IsDBNull(txtAux_final.Text), 0.0, (Val(txtAux_final.Text))), (Val(ddlMFaux.SelectedItem.Text)), lblDIFF_aux, lblAux_month)
            FillTexts(oAdmn, "rwfgen", IIf(IsDBNull(txtrwfgen_initial.Text), 0.0, (Val(txtrwfgen_initial.Text))), IIf(IsDBNull(txtrwfgen_final.Text), 0.0, (Val(txtrwfgen_final.Text))), (Val(ddlMFrwfgen.SelectedItem.Text)), lblDIFF_rwfgen, lblRwfgen_month)
            FillTexts(oAdmn, "pcs", IIf(IsDBNull(txtPCS_initial.Text), 0.0, (Val(txtPCS_initial.Text))), IIf(IsDBNull(txtPCS_final.Text), 0.0, (Val(txtPCS_final.Text))), (Val(ddlMFPCS.SelectedItem.Text)), lblDIFF_PCS, lblPCS_month)

        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtDGGenI_final_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDGGenI_final.TextChanged
        lblMessage.Text = ""
        Try
            Try
                Dim d1, d2, val As Double
                d1 = txtDGGenI_final.Text
                d2 = txtDGGenI_initial.Text
                val = (d1 - d2)
                lblDIFF_dgI.Text = val
            Catch exp As Exception
                lblMessage.Text = "Enter Numeric Values"
                Exit Sub
            End Try
            If CDbl(txtDGGenI_final.Text) < CDbl(txtDGGenI_initial.Text) Then
                lblMessage.Text = "Final Reading is Less Than Initial"
                txtDGGenI_initial.Text = ""
                Exit Sub
            End If
            If txtDGGenI_final.Text = "" And txtDGGenI_initial.Text = "" Then

            Else
                lblDGGenI_unit.Text = CDbl(txtDGGenI_final.Text) - CDbl(txtDGGenI_initial.Text)
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub



    Private Sub ddlMFdgI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMFdgI.SelectedIndexChanged
        lblDGGenI_unit.Text = Val(lblDIFF_dgI.Text) * Val(ddlMFdgI.SelectedItem.Text)
    End Sub

    'Private Sub ddlMFdgII_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMFdgII.SelectedIndexChanged
    '    lblDGGenII_unit.Text = Val(lblDIFF_dgII.Text) * Val(ddlMFdgII.SelectedItem.Text)
    'End Sub

    'Private Sub ddlMFdcos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMFdcos.SelectedIndexChanged
    '    lblDCOS_unit.Text = Val(lblDIFF_dcos.Text) * Val(ddlMFdcos.SelectedItem.Text)
    'End Sub

    Private Sub ddlMFemms_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMFemms.SelectedIndexChanged
        lblSubstation_unit.Text = Val(lblDIFF_emms.Text) * Val(ddlMFemms.SelectedItem.Text)
    End Sub

    Private Sub ddlMFaux_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMFaux.SelectedIndexChanged
        lblAux_unit.Text = Val(lblDIFF_aux.Text) * Val(ddlMFaux.SelectedItem.Text)
    End Sub

    Private Sub ddlMFadmn_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMFadmn.SelectedIndexChanged
        lblAdmin_unit.Text = Val(lblDIFF_Admn.Text) * Val(ddlMFadmn.SelectedItem.Text)
    End Sub

    Private Sub ddlMFcol12_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMFcol12.SelectedIndexChanged
        lblColony12_unit.Text = Val(lblDIFF_col12.Text) * Val(ddlMFcol12.SelectedItem.Text)
    End Sub

    Private Sub ddlMFcol34_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMFcol34.SelectedIndexChanged
        lblColony34_unit.Text = Val(lblDIFF_col34.Text) * Val(ddlMFcol34.SelectedItem.Text)
    End Sub

    Private Sub ddlMFpump_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMFpump.SelectedIndexChanged
        lblPump_unit.Text = Val(lblDIFF_pump.Text) * Val(ddlMFpump.SelectedItem.Text)
    End Sub

    Private Sub ddlMFarcC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMFarcC.SelectedIndexChanged
        lblArc3_unit.Text = Val(lblDIFF_arc3.Text) * Val(ddlMFarcC.SelectedItem.Text)
    End Sub

    Private Sub ddlTubePHESS_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlTubePHESS.SelectedIndexChanged
        TubePHESS_unit.Text = Val(lblDIFF_TubePHESS.Text) * Val(ddlTubePHESS.SelectedItem.Text)
    End Sub

    Private Sub ddlMFarcB_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMFarcB.SelectedIndexChanged
        lblArc2_unit.Text = Val(lblDIFF_arc2.Text) * Val(ddlMFarcB.SelectedItem.Text)
    End Sub

    Private Sub ddlMFarcA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMFarcA.SelectedIndexChanged
        lblArc1_unit.Text = Val(lblDIFF_arc1.Text) * Val(ddlMFarcA.SelectedItem.Text)
    End Sub

    Private Sub ddlFumePHESS_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlFumePHESS.SelectedIndexChanged
        FumePHESS_unit.Text = Val(lblDIFF_FumePHESS.Text) * Val(ddlFumePHESS.SelectedItem.Text)
    End Sub
    Private Sub ddlMFkptcl_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMFkptcl.SelectedIndexChanged
        lblKPTCL_unit.Text = Val(lblDIFF_kptcl.Text.Trim) * Val(ddlMFkptcl.SelectedItem.Text.Trim)
    End Sub

    Private Sub ddlMouldPHESS_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMouldPHESS.SelectedIndexChanged
        MouldPHESS_unit.Text = Val(lblDIFF_MouldPHESS.Text.Trim) * Val(ddlMouldPHESS.SelectedItem.Text.Trim)
    End Sub

    Private Sub txtrwfgen_final_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtrwfgen_final.TextChanged
        lblMessage.Text = ""
        Try
            Try
                Dim d1, d2, val As Double
                d1 = txtrwfgen_final.Text
                d2 = txtrwfgen_initial.Text
                val = (d1 - d2)
                lblDIFF_rwfgen.Text = val
            Catch exp As Exception
                lblMessage.Text = "Enter Numeric Values"
                Exit Sub
            End Try
            If CDbl(txtrwfgen_final.Text) < CDbl(txtrwfgen_initial.Text) Then
                lblMessage.Text = "Final Reading is Less Than Initial"
                txtrwfgen_initial.Text = ""
                Exit Sub
            End If
            If txtrwfgen_final.Text = "" And txtrwfgen_initial.Text = "" Then

            Else
                lblRwfgen_unit.Text = CDbl(txtrwfgen_final.Text) - CDbl(txtrwfgen_initial.Text)
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub ddlMFrwfgen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMFrwfgen.SelectedIndexChanged
        lblRwfgen_unit.Text = Val(lblDIFF_rwfgen.Text.Trim) * Val(ddlMFrwfgen.SelectedItem.Text.Trim)
    End Sub

End Class
