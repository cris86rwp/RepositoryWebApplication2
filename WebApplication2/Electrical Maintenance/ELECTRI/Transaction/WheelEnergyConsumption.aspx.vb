Public Class WheelEnergyConsumption
    Inherits System.Web.UI.Page
    Protected WithEvents txtwsEss_initial As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtwsEss_final As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMF_essential As System.Web.UI.WebControls.Label
    Protected WithEvents ddlMFwsess As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblUnit_essential As System.Web.UI.WebControls.Label
    Protected WithEvents lblTotal_essential As System.Web.UI.WebControls.Label
    Protected WithEvents txtwsEss_initial1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtwsEss_final1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMF_essential1 As System.Web.UI.WebControls.Label
    Protected WithEvents ddlMFwsess1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblUnit_essential1 As System.Web.UI.WebControls.Label
    Protected WithEvents txtwsNonEss_initial As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtwsNonEss_initial2 As System.Web.UI.WebControls.TextBox

    Protected WithEvents txtwsNonEss_final As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMF_nonessential As System.Web.UI.WebControls.Label
    Protected WithEvents ddlMFwsnon As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblUnit_nonessential As System.Web.UI.WebControls.Label
    Protected WithEvents lblTotal_nonessential As System.Web.UI.WebControls.Label
    Protected WithEvents txtwsNonEss_initial1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpumpesstr_initial As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpumpesstr1_initial As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpcsesstr_initial As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpcsesstr1_initial As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpumpesstr_final As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpumpesstr1_final As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpcsesstr_final As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpcsesstr1_final As System.Web.UI.WebControls.TextBox

    Protected WithEvents txtwsNonEss_final1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtwsNonEss_final2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMF_nonessential2 As System.Web.UI.WebControls.Label
    Protected WithEvents ddlMFwsnon2 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblUnit_nonessential2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblMF_nonessential1 As System.Web.UI.WebControls.Label
    Protected WithEvents ddlMFwsnon1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblUnit_nonessential1 As System.Web.UI.WebControls.Label
    Protected WithEvents txtTube_initial As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTube_final As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMF_tube As System.Web.UI.WebControls.Label
    Protected WithEvents lblmf_pumpesstr As System.Web.UI.WebControls.Label
    Protected WithEvents lblmf_pumpesstr1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblmf_pcsesstr As System.Web.UI.WebControls.Label
    Protected WithEvents lblmf_pcsesstr1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblunit_pumpesstr As System.Web.UI.WebControls.Label
    Protected WithEvents lblunit_pumpesstr1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblunit_pcsesstr As System.Web.UI.WebControls.Label
    Protected WithEvents lblunit_pcsesstr1 As System.Web.UI.WebControls.Label


    Protected WithEvents ddlMFtube As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlpumpesstr1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlpumpesstr2 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlpcsesstr1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlpcsesstr2 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblUnit_tube As System.Web.UI.WebControls.Label
    Protected WithEvents lblTotal_tube As System.Web.UI.WebControls.Label
    Protected WithEvents txtTube_initial1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTube_final1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMF_tube1 As System.Web.UI.WebControls.Label
    Protected WithEvents ddlMFtube1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblUnit_tube1 As System.Web.UI.WebControls.Label
    Protected WithEvents txtMould_initial As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMould_final As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMF_mould As System.Web.UI.WebControls.Label
    Protected WithEvents ddlMFmould As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblUnit_mould As System.Web.UI.WebControls.Label
    Protected WithEvents lblTotal_mould As System.Web.UI.WebControls.Label
    Protected WithEvents txtMould_initial1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMould_final1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMF_mould1 As System.Web.UI.WebControls.Label
    Protected WithEvents ddlMFmould1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblUnit_mould1 As System.Web.UI.WebControls.Label
    Protected WithEvents txtFume_initial As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFume_final As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMF_fume As System.Web.UI.WebControls.Label
    Protected WithEvents ddlMFfume As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblUnit_fume As System.Web.UI.WebControls.Label
    Protected WithEvents lblTotal_compressor As System.Web.UI.WebControls.Label
    Protected WithEvents ddlMFfume1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblUnit_fume1 As System.Web.UI.WebControls.Label
    Protected WithEvents txtCompressor_initial As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCompressor_final As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMF_compressor As System.Web.UI.WebControls.Label
    Protected WithEvents ddlMFcomp As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblUnit_compressor As System.Web.UI.WebControls.Label
    Protected WithEvents lblTotal_fume As System.Web.UI.WebControls.Label
    Protected WithEvents txtCompressor_initial1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCompressor_final1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMF_compressor1 As System.Web.UI.WebControls.Label
    Protected WithEvents ddlMFcomp1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblUnit_compressor1 As System.Web.UI.WebControls.Label
    Protected WithEvents btnExit As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
    Protected WithEvents btnSubmit_Clicks As System.Web.UI.WebControls.Button
    Protected WithEvents lblMessage2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblMode As System.Web.UI.WebControls.Label
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RangeValidator1 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents btnCalculateAll As System.Web.UI.WebControls.Button
    Protected WithEvents txtFume_initial1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMF_fume1 As System.Web.UI.WebControls.Label
    Protected WithEvents txtFume_final1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMould_initial2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMould_final2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMF_mould2 As System.Web.UI.WebControls.Label
    Protected WithEvents ddlMFmould2 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblUnit_mould2 As System.Web.UI.WebControls.Label
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList


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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        If Not IsPostBack Then
            lblMode.Text = "add"
            'lblMode.Text = "edit"
            'lblMode.Text = "delete"
            ' lblMode.Text = Request.QueryString("mode")
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

    Private Sub getInitialValues()
        Dim dt As DataTable = New DataTable("dt")
        Try
            dt = Maintenance.ElecTables.getWheelInitialValues
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows(0)(1)) Then txtwsEss_initial.Text = dt.Rows(0)(1)
                If Not IsDBNull(dt.Rows(0)(2)) Then txtwsEss_initial1.Text = dt.Rows(0)(2)
                If Not IsDBNull(dt.Rows(0)(3)) Then txtwsNonEss_initial.Text = dt.Rows(0)(3)
                If Not IsDBNull(dt.Rows(0)(4)) Then txtwsNonEss_initial1.Text = dt.Rows(0)(4)
                If Not IsDBNull(dt.Rows(0)(5)) Then txtTube_initial.Text = dt.Rows(0)(5)
                If Not IsDBNull(dt.Rows(0)(6)) Then txtTube_initial1.Text = dt.Rows(0)(6)
                If Not IsDBNull(dt.Rows(0)(7)) Then txtMould_initial.Text = dt.Rows(0)(7)
                If Not IsDBNull(dt.Rows(0)(8)) Then txtMould_initial1.Text = dt.Rows(0)(8)
                If Not IsDBNull(dt.Rows(0)(9)) Then txtCompressor_initial.Text = dt.Rows(0)(9)
                If Not IsDBNull(dt.Rows(0)(10)) Then txtCompressor_initial1.Text = dt.Rows(0)(10)
                If Not IsDBNull(dt.Rows(0)(11)) Then txtFume_initial.Text = dt.Rows(0)(11)
                If Not IsDBNull(dt.Rows(0)(12)) Then txtFume_initial1.Text = dt.Rows(0)(12)
                If Not IsDBNull(dt.Rows(0)(13)) Then txtwsNonEss_initial2.Text = dt.Rows(0)(13)
                If Not IsDBNull(dt.Rows(0)(14)) Then txtpumpesstr_initial.Text = dt.Rows(0)(14)
                If Not IsDBNull(dt.Rows(0)(15)) Then txtpumpesstr1_initial.Text = dt.Rows(0)(15)
                If Not IsDBNull(dt.Rows(0)(16)) Then txtpcsesstr_initial.Text = dt.Rows(0)(16)
                If Not IsDBNull(dt.Rows(0)(17)) Then txtpcsesstr1_initial.Text = dt.Rows(0)(17)
                If Not IsDBNull(dt.Rows(0)(18)) Then SelectDDL(ddlMFwsess, CStr(dt.Rows(0)(18)))
                If Not IsDBNull(dt.Rows(0)(19)) Then SelectDDL(ddlMFwsess1, CStr(dt.Rows(0)(19)))
                If Not IsDBNull(dt.Rows(0)(20)) Then SelectDDL(ddlMFwsnon, CStr(dt.Rows(0)(20)))
                If Not IsDBNull(dt.Rows(0)(21)) Then SelectDDL(ddlMFwsnon1, CStr(dt.Rows(0)(21)))
                If Not IsDBNull(dt.Rows(0)(22)) Then SelectDDL(ddlMFtube, CStr(dt.Rows(0)(22)))
                If Not IsDBNull(dt.Rows(0)(23)) Then SelectDDL(ddlMFtube1, CStr(dt.Rows(0)(23)))
                If Not IsDBNull(dt.Rows(0)(24)) Then SelectDDL(ddlMFmould, CStr(dt.Rows(0)(24)))
                If Not IsDBNull(dt.Rows(0)(25)) Then SelectDDL(ddlMFmould1, CStr(dt.Rows(0)(25)))
                If Not IsDBNull(dt.Rows(0)(26)) Then SelectDDL(ddlMFcomp, CStr(dt.Rows(0)(26)))
                If Not IsDBNull(dt.Rows(0)(27)) Then SelectDDL(ddlMFcomp1, CStr(dt.Rows(0)(27)))
                If Not IsDBNull(dt.Rows(0)(28)) Then SelectDDL(ddlMFfume, CStr(dt.Rows(0)(28)))
                If Not IsDBNull(dt.Rows(0)(29)) Then SelectDDL(ddlMFfume1, CStr(dt.Rows(0)(29)))
                If Not IsDBNull(dt.Rows(0)(30)) Then txtMould_initial2.Text = dt.Rows(0)(30)
                If Not IsDBNull(dt.Rows(0)(31)) Then SelectDDL(ddlMFmould2, CStr(dt.Rows(0)(31)))
                If Not IsDBNull(dt.Rows(0)(32)) Then SelectDDL(ddlMFwsnon2, CStr(dt.Rows(0)(32)))

                If Not IsDBNull(dt.Rows(0)(33)) Then SelectDDL(ddlpumpesstr1, CStr(dt.Rows(0)(33)))
                If Not IsDBNull(dt.Rows(0)(34)) Then SelectDDL(ddlpumpesstr2, CStr(dt.Rows(0)(34)))
                If Not IsDBNull(dt.Rows(0)(35)) Then SelectDDL(ddlpcsesstr1, CStr(dt.Rows(0)(35)))
                If Not IsDBNull(dt.Rows(0)(36)) Then SelectDDL(ddlpcsesstr2, CStr(dt.Rows(0)(36)))
            Else
                Throw New Exception("No Data ! ")
            End If
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            dt.Dispose()
        End Try
    End Sub

    Private Sub FillDDL(ByRef ddl As System.Web.UI.WebControls.DropDownList, ByRef dt As DataTable)
        ddl.DataSource = dt.DefaultView
        ddl.DataTextField = dt.Columns(0).ColumnName
        ddl.DataValueField = dt.Columns(0).ColumnName
        ddl.DataBind()
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
            FillDDL(ddlMFwsess, dtMF)
            FillDDL(ddlMFwsess1, dtMF)
            FillDDL(ddlMFwsnon, dtMF)
            FillDDL(ddlMFwsnon1, dtMF)
            'FillDDL(ddlMFwsnon2, dtMF)
            FillDDL(ddlMFtube, dtMF)
            FillDDL(ddlMFtube1, dtMF)
            FillDDL(ddlMFmould, dtMF)
            FillDDL(ddlMFmould1, dtMF)
            FillDDL(ddlMFmould2, dtMF)
            FillDDL(ddlMFcomp, dtMF)
            FillDDL(ddlMFcomp1, dtMF)
            FillDDL(ddlMFfume, dtMF)
            FillDDL(ddlMFfume1, dtMF)
            FillDDL(ddlMFwsnon2, dtMF)
            FillDDL(ddlpumpesstr1, dtMF)
            FillDDL(ddlpumpesstr2, dtMF)
            FillDDL(ddlpcsesstr1, dtMF)
            FillDDL(ddlpcsesstr2, dtMF)

        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Sub clearcumulative()
        lblTotal_essential.Text = ""
        lblTotal_nonessential.Text = ""
        lblTotal_fume.Text = ""
        lblTotal_mould.Text = ""
        lblTotal_tube.Text = ""
        lblTotal_compressor.Text = ""
    End Sub

    Sub getUnitsforMonth()
        Dim dt As DataTable
        Try
            dt = Maintenance.ElecTables.getWheelUnitsforMonth(CDate(txtDate.Text))
            If IsNothing(dt) = False Then
                lblTotal_essential.Text = IIf(IsDBNull(dt.Rows(0)("Total_essential")), 0, dt.Rows(0)("Total_essential"))
                lblTotal_nonessential.Text = IIf(IsDBNull(dt.Rows(0)("Total_nonessential")), 0, dt.Rows(0)("Total_nonessential"))
                lblTotal_tube.Text = IIf(IsDBNull(dt.Rows(0)("Total_tube")), 0, dt.Rows(0)("Total_tube"))
                lblTotal_mould.Text = IIf(IsDBNull(dt.Rows(0)("Total_mould")), 0, dt.Rows(0)("Total_mould"))
                lblTotal_compressor.Text = IIf(IsDBNull(dt.Rows(0)("Total_compressor")), 0, dt.Rows(0)("Total_compressor"))
                lblTotal_fume.Text = IIf(IsDBNull(dt.Rows(0)("Total_fume")), 0, dt.Rows(0)("Total_fume"))
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
            dt = Maintenance.ElecTables.getWheelUnitsforDay(CDate(txtDate.Text))
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows(0)(1)) Then txtwsEss_initial.Text = dt.Rows(0)(1)
                If Not IsDBNull(dt.Rows(0)(2)) Then txtwsEss_final.Text = dt.Rows(0)(2)
                If Not IsDBNull(dt.Rows(0)(3)) Then txtwsEss_initial1.Text = dt.Rows(0)(3)
                If Not IsDBNull(dt.Rows(0)(4)) Then txtwsEss_final1.Text = dt.Rows(0)(4)
                If Not IsDBNull(dt.Rows(0)(5)) Then txtwsNonEss_initial.Text = dt.Rows(0)(5)
                If Not IsDBNull(dt.Rows(0)(6)) Then txtwsNonEss_final.Text = dt.Rows(0)(6)
                If Not IsDBNull(dt.Rows(0)(7)) Then txtwsNonEss_initial1.Text = dt.Rows(0)(7)
                If Not IsDBNull(dt.Rows(0)(8)) Then txtwsNonEss_final1.Text = dt.Rows(0)(8)
                If Not IsDBNull(dt.Rows(0)(9)) Then txtTube_initial.Text = dt.Rows(0)(9)
                If Not IsDBNull(dt.Rows(0)(10)) Then txtTube_final.Text = dt.Rows(0)(10)
                If Not IsDBNull(dt.Rows(0)(11)) Then txtTube_initial1.Text = dt.Rows(0)(11)
                If Not IsDBNull(dt.Rows(0)(12)) Then txtTube_final1.Text = dt.Rows(0)(12)
                If Not IsDBNull(dt.Rows(0)(13)) Then txtMould_initial.Text = dt.Rows(0)(13)
                If Not IsDBNull(dt.Rows(0)(14)) Then txtMould_final.Text = dt.Rows(0)(14)
                If Not IsDBNull(dt.Rows(0)(15)) Then txtMould_initial1.Text = dt.Rows(0)(15)
                If Not IsDBNull(dt.Rows(0)(16)) Then txtMould_final1.Text = dt.Rows(0)(16)
                If Not IsDBNull(dt.Rows(0)(17)) Then txtCompressor_initial.Text = dt.Rows(0)(17)
                If Not IsDBNull(dt.Rows(0)(18)) Then txtCompressor_final.Text = dt.Rows(0)(18)
                If Not IsDBNull(dt.Rows(0)(19)) Then txtCompressor_initial1.Text = dt.Rows(0)(19)
                If Not IsDBNull(dt.Rows(0)(20)) Then txtCompressor_final1.Text = dt.Rows(0)(20)
                If Not IsDBNull(dt.Rows(0)(21)) Then txtFume_initial.Text = dt.Rows(0)(21)
                If Not IsDBNull(dt.Rows(0)(22)) Then txtFume_final.Text = dt.Rows(0)(22)
                If Not IsDBNull(dt.Rows(0)(23)) Then txtFume_initial1.Text = dt.Rows(0)(23)
                If Not IsDBNull(dt.Rows(0)(24)) Then txtFume_final1.Text = dt.Rows(0)(24)
                If Not IsDBNull(dt.Rows(0)(25)) Then SelectDDL(ddlMFwsess, CStr(dt.Rows(0)(25)))
                If Not IsDBNull(dt.Rows(0)(26)) Then SelectDDL(ddlMFwsess1, CStr(dt.Rows(0)(26)))
                If Not IsDBNull(dt.Rows(0)(27)) Then SelectDDL(ddlMFwsnon, CStr(dt.Rows(0)(27)))
                If Not IsDBNull(dt.Rows(0)(28)) Then SelectDDL(ddlMFwsnon1, CStr(dt.Rows(0)(28)))
                If Not IsDBNull(dt.Rows(0)(29)) Then SelectDDL(ddlMFtube, CStr(dt.Rows(0)(29)))
                If Not IsDBNull(dt.Rows(0)(30)) Then SelectDDL(ddlMFtube1, CStr(dt.Rows(0)(30)))
                If Not IsDBNull(dt.Rows(0)(31)) Then SelectDDL(ddlMFmould, CStr(dt.Rows(0)(31)))
                If Not IsDBNull(dt.Rows(0)(32)) Then SelectDDL(ddlMFmould1, CStr(dt.Rows(0)(32)))
                If Not IsDBNull(dt.Rows(0)(33)) Then SelectDDL(ddlMFcomp, CStr(dt.Rows(0)(33)))
                If Not IsDBNull(dt.Rows(0)(34)) Then SelectDDL(ddlMFcomp1, CStr(dt.Rows(0)(34)))
                If Not IsDBNull(dt.Rows(0)(35)) Then SelectDDL(ddlMFfume, CStr(dt.Rows(0)(35)))
                If Not IsDBNull(dt.Rows(0)(36)) Then SelectDDL(ddlMFfume1, CStr(dt.Rows(0)(36)))
                If Not IsDBNull(dt.Rows(0)(37)) Then txtMould_initial2.Text = dt.Rows(0)(37)
                If Not IsDBNull(dt.Rows(0)(38)) Then txtMould_final2.Text = dt.Rows(0)(38)
                If Not IsDBNull(dt.Rows(0)(39)) Then SelectDDL(ddlMFmould2, CStr(dt.Rows(0)(39)))
                If Not IsDBNull(dt.Rows(0)(40)) Then txtwsNonEss_initial2.Text = dt.Rows(0)(40)
                If Not IsDBNull(dt.Rows(0)(41)) Then txtwsNonEss_final2.Text = dt.Rows(0)(41)
                If Not IsDBNull(dt.Rows(0)(42)) Then txtpumpesstr_initial.Text = dt.Rows(0)(42)
                If Not IsDBNull(dt.Rows(0)(43)) Then txtpumpesstr_final.Text = dt.Rows(0)(43)
                If Not IsDBNull(dt.Rows(0)(44)) Then txtpumpesstr1_initial.Text = dt.Rows(0)(44)
                If Not IsDBNull(dt.Rows(0)(45)) Then txtpumpesstr1_final.Text = dt.Rows(0)(45)
                If Not IsDBNull(dt.Rows(0)(46)) Then txtpcsesstr_initial.Text = dt.Rows(0)(46)
                If Not IsDBNull(dt.Rows(0)(47)) Then txtpcsesstr_final.Text = dt.Rows(0)(47)
                If Not IsDBNull(dt.Rows(0)(48)) Then txtpcsesstr1_initial.Text = dt.Rows(0)(48)
                If Not IsDBNull(dt.Rows(0)(49)) Then txtpcsesstr1_final.Text = dt.Rows(0)(49)

                If Not IsDBNull(dt.Rows(0)(50)) Then SelectDDL(ddlMFwsnon2, CStr(dt.Rows(0)(50)))
                If Not IsDBNull(dt.Rows(0)(51)) Then SelectDDL(ddlpumpesstr1, CStr(dt.Rows(0)(51)))
                If Not IsDBNull(dt.Rows(0)(52)) Then SelectDDL(ddlpumpesstr2, CStr(dt.Rows(0)(52)))
                If Not IsDBNull(dt.Rows(0)(53)) Then SelectDDL(ddlpcsesstr1, CStr(dt.Rows(0)(53)))
                If Not IsDBNull(dt.Rows(0)(54)) Then SelectDDL(ddlpcsesstr2, CStr(dt.Rows(0)(54)))

                'If Not IsDBNull(dt.Rows(0)(52)) Then txtwsNonEss_initial2.Text = dt.Rows(0)s(52)
                'If Not IsDBNull(dt.Rows(0)(53)) Then txtwsNonEss_final2.Text = dt.Rows(0)(53)
                'If Not IsDBNull(dt.Rows(0)(54)) Then SelectDDL(ddlMFwsnon2, CStr(dt.Rows(0)(54)))

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
                If Maintenance.ElecTables.CheckTopWheelData(CDate(txtDate.Text)) > 0 Then
                    lblMessage.Text = " Data present for this date : '" & CDate(txtDate.Text) & "' cannot be EDITED for changing data ! "
                    txtDate.Text = ""
                    Exit Try
                Else
                    getUnitsforDay()
                    getUnitsforMonth()
                End If
            Else
                If Maintenance.ElecTables.CheckWheelData(CDate(txtDate.Text)) > 0 Then
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
            If CType(oObj, Maintenance.Electrical.Energy).TR(i).Name.ToLower = TRname.ToLower.Trim Then
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
            Dim oWhl As New Maintenance.Electrical.Energy()
            oWhl.ConsumptionDate = CDate(txtDate.Text)

            FillTexts(oWhl, "essential", IIf(IsDBNull(txtwsEss_initial.Text), 0.0, (Val(txtwsEss_initial.Text))), IIf(IsDBNull(txtwsEss_final.Text), 0.0, (Val(txtwsEss_final.Text))), (Val(ddlMFwsess.SelectedItem.Text)), lblMF_essential, lblUnit_essential)
            FillTexts(oWhl, "essential1", IIf(IsDBNull(txtwsEss_initial1.Text), 0.0, (Val(txtwsEss_initial1.Text))), IIf(IsDBNull(txtwsEss_final1.Text), 0.0, (Val(txtwsEss_final1.Text))), (Val(ddlMFwsess1.SelectedItem.Text)), lblMF_essential1, lblUnit_essential1)

            FillTexts(oWhl, "NonEssential", IIf(IsDBNull(txtwsNonEss_initial.Text), 0.0, (Val(txtwsNonEss_initial.Text))), IIf(IsDBNull(txtwsNonEss_final.Text), 0.0, (Val(txtwsNonEss_final.Text))), (Val(ddlMFwsnon.SelectedItem.Text)), lblMF_nonessential, lblUnit_nonessential)
            FillTexts(oWhl, "NonEssential1", IIf(IsDBNull(txtwsNonEss_initial1.Text), 0.0, (Val(txtwsNonEss_initial1.Text))), IIf(IsDBNull(txtwsNonEss_final1.Text), 0.0, (Val(txtwsNonEss_final1.Text))), (Val(ddlMFwsnon1.SelectedItem.Text)), lblMF_nonessential1, lblUnit_nonessential1)

            'FillTexts(oWhl, "NonEssential", IIf(IsDBNull(txtwsNonEss_initial.Text), 0.0, (Val(txtwsNonEss_initial.Text))), IIf(IsDBNull(txtwsNonEss_final.Text), 0.0, (Val(txtwsNonEss_final.Text))), (Val(ddlMFwsnon.SelectedItem.Text)), lblMF_nonessential, lblUnit_nonessential)
            '  FillTexts(oWhl, "NonEssential2", IIf(IsDBNull(txtwsNonEss_initial2.Text), 0.0, (Val(txtwsNonEss_initial2.Text))), IIf(IsDBNull(txtwsNonEss_final2.Text), 0.0, (Val(txtwsNonEss_final2.Text))), (Val(ddlMFwsnon2.SelectedItem.Text)), lblMF_nonessential2, lblUnit_nonessential2)

            FillTexts(oWhl, "tubepretr1", IIf(IsDBNull(txtTube_initial.Text), 0.0, (Val(txtTube_initial.Text))), IIf(IsDBNull(txtTube_final.Text), 0.0, (Val(txtTube_final.Text))), (Val(ddlMFtube.SelectedItem.Text)), lblMF_tube, lblUnit_tube)
            FillTexts(oWhl, "tubepretr2", IIf(IsDBNull(txtTube_initial1.Text), 0.0, (Val(txtTube_initial1.Text))), IIf(IsDBNull(txtTube_final1.Text), 0.0, (Val(txtTube_final1.Text))), (Val(ddlMFtube1.SelectedItem.Text)), lblMF_tube1, lblUnit_tube1)

            FillTexts(oWhl, "mouldpretr1", IIf(IsDBNull(txtMould_initial.Text), 0.0, (Val(txtMould_initial.Text))), IIf(IsDBNull(txtMould_final.Text), 0.0, (Val(txtMould_final.Text))), (Val(ddlMFmould.SelectedItem.Text)), lblMF_mould, lblUnit_mould)
            FillTexts(oWhl, "mouldpretr2", IIf(IsDBNull(txtMould_initial1.Text), 0.0, (Val(txtMould_initial1.Text))), IIf(IsDBNull(txtMould_final1.Text), 0.0, (Val(txtMould_final1.Text))), (Val(ddlMFmould1.SelectedItem.Text)), lblMF_mould1, lblUnit_mould1)

            FillTexts(oWhl, "comptr1", IIf(IsDBNull(txtCompressor_initial.Text), 0.0, (Val(txtCompressor_initial.Text))), IIf(IsDBNull(txtCompressor_final.Text), 0.0, (Val(txtCompressor_final.Text))), (Val(ddlMFcomp.SelectedItem.Text)), lblMF_compressor, lblUnit_compressor)
            FillTexts(oWhl, "comptr2", IIf(IsDBNull(txtCompressor_initial1.Text), 0.0, (Val(txtCompressor_initial1.Text))), IIf(IsDBNull(txtCompressor_final1.Text), 0.0, (Val(txtCompressor_final1.Text))), (Val(ddlMFcomp1.SelectedItem.Text)), lblMF_compressor1, lblUnit_compressor1)

            FillTexts(oWhl, "fumetr1", IIf(IsDBNull(txtFume_initial.Text), 0.0, (Val(txtFume_initial.Text))), IIf(IsDBNull(txtFume_final.Text), 0.0, (Val(txtFume_final.Text))), (Val(ddlMFfume.SelectedItem.Text)), lblMF_fume, lblUnit_fume)
            FillTexts(oWhl, "fumetr2", IIf(IsDBNull(txtFume_initial1.Text), 0.0, (Val(txtFume_initial1.Text))), IIf(IsDBNull(txtFume_final1.Text), 0.0, (Val(txtFume_final1.Text))), (Val(ddlMFfume1.SelectedItem.Text)), lblMF_fume1, lblUnit_fume1)

            FillTexts(oWhl, "mouldpretr3", IIf(IsDBNull(txtMould_initial2.Text), 0.0, (Val(txtMould_initial2.Text))), IIf(IsDBNull(txtMould_final2.Text), 0.0, (Val(txtMould_final2.Text))), (Val(ddlMFmould2.SelectedItem.Text)), lblMF_mould2, lblUnit_mould2)

            If lblMode.Text.ToLower = "add" Then
                oWhl.SaveWheelEnergyConsumption(CDate("1900-01-01"))
            Else
                oWhl.SaveWheelEnergyConsumption(CDate(txtDate.Text))
            End If
            lblMessage.Text = oWhl.Message
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtTube_final_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTube_final.TextChanged
        lblMessage.Text = ""
        Try
            lblMF_tube.Text = Difference(txtTube_initial.Text, txtTube_final.Text)
        Catch exp As Exception
            lblMessage.Text = "TUBE PRE-HEAT TR1  Values : " & exp.Message
        End Try
    End Sub

    Private Sub txtTube_final1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTube_final1.TextChanged
        lblMessage.Text = ""
        Try
            lblMF_tube1.Text = Difference(txtTube_initial1.Text, txtTube_final1.Text)
        Catch exp As Exception
            lblMessage.Text = "TUBE PRE-HEAT TR2  Values : " & exp.Message
        End Try
    End Sub

    Private Sub txtMould_final_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMould_final.TextChanged
        lblMessage.Text = ""
        Try
            lblMF_mould.Text = Difference(txtMould_initial.Text, txtMould_final.Text)
        Catch exp As Exception
            lblMessage.Text = "MOULD PRE-HEAT TR1  Values : " & exp.Message
        End Try
    End Sub

    Private Sub txtMould_final1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMould_final1.TextChanged
        lblMessage.Text = ""
        Try
            lblMF_mould1.Text = Difference(txtMould_initial1.Text, txtMould_final1.Text)
        Catch exp As Exception
            lblMessage.Text = "MOULD PRE-HEAT TR2  Values : " & exp.Message
        End Try
    End Sub

    Private Sub txtCompressor_final_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCompressor_final.TextChanged
        lblMessage.Text = ""
        Try
            lblMF_compressor.Text = Difference(txtCompressor_initial.Text, txtCompressor_final.Text)
        Catch exp As Exception
            lblMessage.Text = "COMPRESSOR TR1  Values : " & exp.Message
        End Try
    End Sub

    Private Sub txtCompressor_final1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCompressor_final1.TextChanged
        lblMessage.Text = ""
        Try
            lblMF_compressor1.Text = Difference(txtCompressor_initial1.Text, txtCompressor_final1.Text)
        Catch exp As Exception
            lblMessage.Text = "COMPRESSOR TR2  Values : " & exp.Message
        End Try
    End Sub

    Private Sub txtFume_final_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFume_final.TextChanged
        lblMessage.Text = ""
        Try
            lblMF_fume.Text = Difference(txtFume_initial.Text, txtFume_final.Text)
        Catch exp As Exception
            lblMessage.Text = "FUME EXTRACTION TR1  Values : " & exp.Message
        End Try
    End Sub

    Private Sub txtFume_final1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFume_final1.TextChanged
        lblMessage.Text = ""
        Try
            lblMF_fume1.Text = Difference(txtFume_initial1.Text, txtFume_final1.Text)
        Catch exp As Exception
            lblMessage.Text = "FUME EXTRACTION TR2  Values : " & exp.Message
        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        clear()
        lblMessage.Text = ""
    End Sub

    Sub clear()
        txtwsEss_final.Text = "0"
        txtwsEss_initial.Text = "0"
        txtwsNonEss_final.Text = "0"
        txtwsNonEss_initial.Text = "0"
        txtTube_initial.Text = "0"
        txtTube_final.Text = "0"
        txtMould_initial.Text = "0"
        txtMould_final.Text = "0"
        txtCompressor_initial.Text = "0"
        txtCompressor_final.Text = "0"
        txtFume_initial.Text = "0"
        txtFume_final.Text = "0"
        txtwsEss_final1.Text = "0"
        txtwsEss_initial1.Text = "0"
        txtwsNonEss_final1.Text = "0"
        txtwsNonEss_final2.Text = "0"
        txtwsNonEss_initial1.Text = "0"
        txtwsNonEss_initial2.Text = "0"
        txtTube_initial1.Text = "0"
        txtTube_final1.Text = "0"
        txtMould_initial1.Text = "0"
        txtMould_final1.Text = "0"
        txtCompressor_initial1.Text = "0"
        txtCompressor_final1.Text = "0"
        txtFume_initial1.Text = "0"
        txtFume_final1.Text = "0"

        lblUnit_fume.Text = "0"
        lblUnit_compressor.Text = "0"
        lblUnit_mould.Text = "0"
        lblUnit_tube.Text = "0"
        lblUnit_nonessential.Text = "0"
        lblUnit_nonessential2.Text = "0"

        lblUnit_essential.Text = "0"
        lblUnit_fume1.Text = "0"
        lblUnit_compressor1.Text = "0"
        lblUnit_mould1.Text = "0"
        lblUnit_tube1.Text = "0"
        lblUnit_nonessential1.Text = "0"
        lblUnit_essential1.Text = "0"
        lblunit_pumpesstr.Text = "0"
        lblunit_pumpesstr1.Text = "0"
        lblunit_pcsesstr.Text = "0"
        lblunit_pcsesstr1.Text = "0"
        lblmf_pcsesstr1.Text = "0"
        lblmf_pcsesstr.Text = "0"
        lblmf_pumpesstr1.Text = "0"
        lblmf_pumpesstr.Text = "0"
        lblMF_compressor.Text = "0"
        lblMF_compressor1.Text = "0"
        lblMF_fume.Text = "0"
        lblMF_fume1.Text = "0"
        lblMF_tube.Text = "0"
        lblMF_tube1.Text = "0"
        lblMF_mould.Text = "0"
        lblMF_mould1.Text = "0"
        lblMF_essential.Text = "0"
        lblMF_essential1.Text = "0"
        lblMF_nonessential.Text = "0"
        lblMF_nonessential1.Text = "0"
        lblMF_nonessential2.Text = "0"

        lblTotal_essential.Text = "0"
        lblTotal_nonessential.Text = "0"
        lblTotal_compressor.Text = "0"
        lblTotal_tube.Text = "0"
        lblTotal_fume.Text = "0"
        lblTotal_mould.Text = "0"

        txtMould_initial2.Text = "0"
        txtMould_final2.Text = "0"
        lblMF_mould2.Text = "0"
        lblUnit_mould2.Text = "0"
    End Sub

    Private Function Difference(ByVal init As String, ByVal final As String) As String
        Dim mylable As String
        Try
            If CDbl(final) < CDbl(init) Then
                Throw New Exception("Final Reading cannot be Less Than Initial")
            Else
                mylable = CStr(Val(final) - Val(init))
            End If
        Catch exp As Exception
            Throw New Exception(exp.Message)
        End Try
        Return mylable
    End Function

    Private Sub btnCalculateAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalculateAll.Click
        Try
            getUnitsforMonth()
            lblMF_essential.Text = Difference(txtwsEss_initial.Text, txtwsEss_final.Text)
            lblUnit_essential.Text = (CDbl(txtwsEss_final.Text) - CDbl(txtwsEss_initial.Text)) * (CDbl(ddlMFwsess.SelectedItem.Text))
            lblMF_essential1.Text = Difference(txtwsEss_initial1.Text, txtwsEss_final1.Text)
            lblUnit_essential1.Text = (CDbl(txtwsEss_final1.Text) - CDbl(txtwsEss_initial1.Text)) * (CDbl(ddlMFwsess1.SelectedItem.Text))
            lblMF_nonessential.Text = Difference(txtwsNonEss_initial.Text, txtwsNonEss_final.Text)
            lblUnit_nonessential.Text = (CDbl(txtwsNonEss_final.Text) - CDbl(txtwsNonEss_initial.Text)) * (CDbl(ddlMFwsnon.SelectedItem.Text))
            lblMF_nonessential1.Text = Difference(txtwsNonEss_initial1.Text, txtwsNonEss_final1.Text)
            lblMF_nonessential2.Text = Difference(txtwsNonEss_initial2.Text, txtwsNonEss_final2.Text)
            lblUnit_nonessential2.Text = (CDbl(txtwsNonEss_final2.Text) - CDbl(txtwsNonEss_initial2.Text)) * (CDbl(ddlMFwsnon2.SelectedItem.Text))
            lblmf_pumpesstr.Text = Difference(txtpumpesstr_initial.Text, txtpumpesstr_final.Text)
            lblunit_pumpesstr.Text = (CDbl(txtpumpesstr_final.Text) - CDbl(txtpumpesstr_initial.Text)) * (CDbl(ddlpumpesstr1.SelectedItem.Text))
            lblmf_pumpesstr1.Text = Difference(txtpumpesstr1_initial.Text, txtpumpesstr1_final.Text)
            lblunit_pumpesstr1.Text = (CDbl(txtpumpesstr1_final.Text) - CDbl(txtpumpesstr1_initial.Text)) * (CDbl(ddlpumpesstr2.SelectedItem.Text))
            lblmf_pcsesstr.Text = Difference(txtpcsesstr_initial.Text, txtpcsesstr_final.Text)
            lblunit_pcsesstr.Text = (CDbl(txtpcsesstr_final.Text) - CDbl(txtpcsesstr_initial.Text)) * (CDbl(ddlpcsesstr1.SelectedItem.Text))
            lblmf_pcsesstr1.Text = Difference(txtpcsesstr1_initial.Text, txtpcsesstr1_final.Text)
            lblunit_pcsesstr1.Text = (CDbl(txtpcsesstr1_final.Text) - CDbl(txtpcsesstr1_initial.Text)) * (CDbl(ddlpcsesstr2.SelectedItem.Text))

            lblUnit_nonessential1.Text = (CDbl(txtwsNonEss_final1.Text) - CDbl(txtwsNonEss_initial1.Text)) * (CDbl(ddlMFwsnon1.SelectedItem.Text))
            lblMF_tube.Text = Difference(txtTube_initial.Text, txtTube_final.Text)
            lblUnit_tube.Text = (CDbl(txtTube_final.Text) - CDbl(txtTube_initial.Text)) * (CDbl(ddlMFtube.SelectedItem.Text))
            lblMF_tube1.Text = Difference(txtTube_initial1.Text, txtTube_final1.Text)
            lblUnit_tube1.Text = (CDbl(txtTube_final1.Text) - CDbl(txtTube_initial1.Text)) * (CDbl(ddlMFtube1.SelectedItem.Text))
            lblMF_mould.Text = Difference(txtMould_initial.Text, txtMould_final.Text)
            lblUnit_mould.Text = (CDbl(txtMould_final.Text) - CDbl(txtMould_initial.Text)) * (CDbl(ddlMFmould.SelectedItem.Text))
            lblMF_mould1.Text = Difference(txtMould_initial1.Text, txtMould_final1.Text)
            lblUnit_mould1.Text = (CDbl(txtMould_final1.Text) - CDbl(txtMould_initial1.Text)) * (CDbl(ddlMFmould1.SelectedItem.Text))
            lblMF_mould2.Text = Difference(txtMould_initial2.Text, txtMould_final2.Text)
            lblUnit_mould2.Text = (CDbl(txtMould_final2.Text) - CDbl(txtMould_initial2.Text)) * (CDbl(ddlMFmould2.SelectedItem.Text))
            lblMF_fume.Text = Difference(txtFume_initial.Text, txtFume_final.Text)
            lblUnit_fume.Text = (CDbl(txtFume_final.Text) - CDbl(txtFume_initial.Text)) * (CDbl(ddlMFfume.SelectedItem.Text))
            lblMF_fume1.Text = Difference(txtFume_initial1.Text, txtFume_final1.Text)
            lblUnit_fume1.Text = (CDbl(txtFume_final1.Text) - CDbl(txtFume_initial1.Text)) * (CDbl(ddlMFfume1.SelectedItem.Text))
            lblMF_compressor.Text = Difference(txtCompressor_initial.Text, txtCompressor_final.Text)
            lblUnit_compressor.Text = (CDbl(txtCompressor_final.Text) - CDbl(txtCompressor_initial.Text)) * (CDbl(ddlMFcomp.SelectedItem.Text))
            lblMF_compressor1.Text = Difference(txtCompressor_initial1.Text, txtCompressor_final1.Text)
            lblUnit_compressor1.Text = (CDbl(txtCompressor_final1.Text) - CDbl(txtCompressor_initial1.Text)) * (CDbl(ddlMFcomp1.SelectedItem.Text))
            lblTotal_essential.Text = CStr(Val(lblUnit_essential.Text) + Val(lblUnit_essential1.Text) + Val(lblTotal_essential.Text))
            lblTotal_nonessential.Text = CStr(Val(lblUnit_nonessential.Text) + Val(lblUnit_nonessential1.Text) + Val(lblTotal_nonessential.Text))
            lblTotal_tube.Text = CStr(Val(lblUnit_tube.Text) + Val(lblUnit_tube1.Text) + Val(lblTotal_tube.Text))
            lblTotal_mould.Text = CStr(Val(lblUnit_mould.Text) + Val(lblUnit_mould1.Text) + Val(lblUnit_mould2.Text) + Val(lblTotal_mould.Text))
            lblTotal_fume.Text = CStr(Val(lblUnit_fume.Text) + Val(lblUnit_fume1.Text) + Val(lblTotal_fume.Text))
            lblTotal_compressor.Text = CStr(Val(lblUnit_compressor.Text) + Val(lblUnit_compressor1.Text) + Val(lblTotal_compressor.Text))
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub


    Private Sub ddlMFwsess_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMFwsess.SelectedIndexChanged
        lblMessage.Text = ""
        Try


            lblUnit_essential.Text = Difference(txtwsEss_initial.Text, txtwsEss_final.Text) * Val(ddlMFwsess.SelectedItem.Text)
        Catch exp As Exception
            lblMessage.Text = "Enter Numeric Values"
        End Try
    End Sub

    Private Sub ddlMFwsess1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMFwsess1.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            lblUnit_essential1.Text = Difference(txtwsEss_initial1.Text, txtwsEss_final1.Text) * Val(ddlMFwsess1.SelectedItem.Text)
        Catch exp As Exception
            lblMessage.Text = "Enter Numeric Values"
        End Try
    End Sub

    Private Sub ddlMFwsnon_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMFwsnon.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            lblUnit_nonessential.Text = Difference(txtwsNonEss_initial.Text, txtwsNonEss_final.Text) * Val(ddlMFwsnon.SelectedItem.Text)
        Catch exp As Exception
            lblMessage.Text = "Enter Numeric Values"
        End Try
    End Sub

    Private Sub ddlMFwsnon1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMFwsnon1.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            lblUnit_nonessential1.Text = Difference(txtwsNonEss_initial1.Text, txtwsNonEss_final1.Text) * Val(ddlMFwsnon1.SelectedItem.Text)
        Catch exp As Exception
            lblMessage.Text = "Enter Numeric Values"
        End Try
    End Sub

    Private Sub ddlMFwsnon2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMFwsnon1.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            lblUnit_nonessential2.Text = Difference(txtwsNonEss_initial2.Text, txtwsNonEss_final2.Text) * Val(ddlMFwsnon2.SelectedItem.Text)
        Catch exp As Exception
            lblMessage.Text = "Enter Numeric Values"
        End Try
    End Sub

    Private Sub ddlMFtube_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMFtube.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            lblUnit_tube.Text = Difference(txtTube_initial.Text, txtTube_final.Text) * Val(ddlMFtube.SelectedItem.Text)
        Catch exp As Exception
            lblMessage.Text = "Enter Numeric Values"
        End Try
    End Sub

    Private Sub ddlMFtube1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMFtube1.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            lblUnit_tube1.Text = Difference(txtTube_initial1.Text, txtTube_final1.Text) * Val(ddlMFtube1.SelectedItem.Text)
        Catch exp As Exception
            lblMessage.Text = "Enter Numeric Values"
        End Try
    End Sub

    Private Sub ddlMFmould_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMFmould.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            lblUnit_mould.Text = Difference(txtMould_initial.Text, txtMould_final.Text) * Val(ddlMFmould.SelectedItem.Text)
        Catch exp As Exception
            lblMessage.Text = "Enter Numeric Values"
        End Try
    End Sub

    Private Sub ddlMFmould1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMFmould1.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            lblUnit_mould1.Text = Difference(txtMould_initial1.Text, txtMould_final1.Text) * Val(ddlMFmould1.SelectedItem.Text)
        Catch exp As Exception
            lblMessage.Text = "Enter Numeric Values"
        End Try
    End Sub

    Private Sub ddlMFcomp_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMFcomp.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            lblUnit_compressor.Text = Difference(txtCompressor_initial.Text, txtCompressor_final.Text) * Val(ddlMFcomp.SelectedItem.Text)
        Catch exp As Exception
            lblMessage.Text = "Enter Numeric Values"
        End Try
    End Sub

    Private Sub ddlMFcomp1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMFcomp1.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            lblUnit_compressor1.Text = Difference(txtCompressor_initial1.Text, txtCompressor_final1.Text) * Val(ddlMFcomp1.SelectedItem.Text)
        Catch exp As Exception
            lblMessage.Text = "Enter Numeric Values"
        End Try
    End Sub

    Private Sub ddlMFfume_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMFfume.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            lblUnit_fume.Text = Difference(txtFume_initial.Text, txtFume_final.Text) * Val(ddlMFfume.SelectedItem.Text)
        Catch exp As Exception
            lblMessage.Text = "Enter Numeric Values"
        End Try
    End Sub

    Private Sub ddlMFfume1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMFfume1.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            lblUnit_fume1.Text = Difference(txtFume_initial1.Text, txtFume_final1.Text) * Val(ddlMFfume1.SelectedItem.Text)
        Catch exp As Exception
            lblMessage.Text = "Enter Numeric Values"
        End Try
    End Sub

    Private Sub txtwsEss_final_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtwsEss_final.TextChanged
        lblMessage.Text = ""
        Try
            lblMF_essential.Text = Difference(txtwsEss_initial.Text, txtwsEss_final.Text)
        Catch exp As Exception
            lblMessage.Text = "WS(ESS)TR1  Values : " & exp.Message
        End Try
    End Sub

    Private Sub txtwsEss_final1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtwsEss_final1.TextChanged
        lblMessage.Text = ""
        Try
            lblMF_essential1.Text = Difference(txtwsEss_initial1.Text, txtwsEss_final1.Text)
        Catch exp As Exception
            lblMessage.Text = "WS(ESS)TR2  Values : " & exp.Message
        End Try
    End Sub

    Private Sub txtwsNonEss_final_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtwsNonEss_final.TextChanged
        lblMessage.Text = ""
        Try
            lblMF_nonessential.Text = Difference(txtwsNonEss_initial.Text, txtwsNonEss_final.Text)
        Catch exp As Exception
            lblMessage.Text = "WS(NONESS)TR3  Values : " & exp.Message
        End Try
    End Sub

    Private Sub txtwsNonEss_final1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtwsNonEss_final1.TextChanged
        lblMessage.Text = ""
        Try
            lblMF_nonessential1.Text = Difference(txtwsNonEss_initial1.Text, txtwsNonEss_final1.Text)
        Catch exp As Exception
            lblMessage.Text = "WS(NONESS)TR4  Values : " & exp.Message
        End Try
    End Sub

    Private Sub txtwsNonEss_final2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtwsNonEss_final1.TextChanged
        lblMessage.Text = ""
        Try
            lblMF_nonessential2.Text = Difference(txtwsNonEss_initial2.Text, txtwsNonEss_final2.Text)
        Catch exp As Exception
            lblMessage.Text = "MELTESSTR5  Values : " & exp.Message
        End Try
    End Sub

    Private Sub txtMould_final2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMould_final2.TextChanged
        lblMessage.Text = ""
        Try
            lblMF_mould2.Text = Difference(txtMould_initial2.Text, txtMould_final2.Text)
        Catch exp As Exception
            lblMessage.Text = "MOULD PRE-HEAT TR3  Values : " & exp.Message
        End Try
    End Sub

    Private Sub ddlMFmould2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMFmould2.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            lblUnit_mould2.Text = Difference(txtMould_initial2.Text, txtMould_final2.Text) * Val(ddlMFmould2.SelectedItem.Text)
        Catch exp As Exception
            lblMessage.Text = "Enter Numeric Values"
        End Try
    End Sub

    Private Sub txtpumpesstr_final_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpumpesstr_final.TextChanged
        lblMessage.Text = ""
        Try
            lblmf_pumpesstr.Text = Difference(txtpumpesstr_initial.Text, txtpumpesstr_final.Text)
        Catch exp As Exception
            lblMessage.Text = "PUMPESSTR1  Values : " & exp.Message
        End Try
    End Sub

    Private Sub txtpumpesstr1_final_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpumpesstr1_final.TextChanged
        lblMessage.Text = ""
        Try
            lblmf_pumpesstr1.Text = Difference(txtpumpesstr1_initial.Text, txtpumpesstr1_final.Text)
        Catch exp As Exception
            lblMessage.Text = "PUMPESSTR2  Values : " & exp.Message
        End Try
    End Sub

    Private Sub txtpcsesstr_final_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpcsesstr_final.TextChanged
        lblMessage.Text = ""
        Try
            lblmf_pcsesstr.Text = Difference(txtpcsesstr_initial.Text, txtpcsesstr_final.Text)
        Catch exp As Exception
            lblMessage.Text = "PCSESSTR1  Values : " & exp.Message
        End Try
    End Sub

    Private Sub txtpcsesstr1_final_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpcsesstr1_final.TextChanged
        lblMessage.Text = ""
        Try
            lblmf_pcsesstr1.Text = Difference(txtpcsesstr1_initial.Text, txtpcsesstr1_final.Text)
        Catch exp As Exception
            lblMessage.Text = "PCSESSTR2  Values : " & exp.Message
        End Try
    End Sub

    Private Sub ddlpumpesstr1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlpumpesstr1.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            lblunit_pumpesstr.Text = Difference(txtpumpesstr_initial.Text, txtpumpesstr_final.Text) * Val(ddlpumpesstr1.SelectedItem.Text)
        Catch exp As Exception
            lblMessage.Text = "Enter Numeric Values"
        End Try
    End Sub

    Private Sub ddlpumpesstr2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlpumpesstr2.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            lblunit_pumpesstr1.Text = Difference(txtpumpesstr1_initial.Text, txtpumpesstr1_final.Text) * Val(ddlpumpesstr2.SelectedItem.Text)
        Catch exp As Exception
            lblMessage.Text = "Enter Numeric Values"
        End Try
    End Sub
    Private Sub ddlpcsesstr1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlpcsesstr1.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            lblunit_pcsesstr.Text = Difference(txtpcsesstr_initial.Text, txtpcsesstr_final.Text) * Val(ddlpcsesstr1.SelectedItem.Text)
        Catch exp As Exception
            lblMessage.Text = "Enter Numeric Values"
        End Try
    End Sub



    Private Sub ddlpcsesstr2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlpcsesstr2.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            lblunit_pcsesstr1.Text = Difference(txtpcsesstr1_initial.Text, txtpcsesstr1_final.Text) * Val(ddlpcsesstr2.SelectedItem.Text)
        Catch exp As Exception
            lblMessage.Text = "Enter Numeric Values"
        End Try

    End Sub

End Class
