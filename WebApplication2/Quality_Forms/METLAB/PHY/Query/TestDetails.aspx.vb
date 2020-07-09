Public Class TestDetails
    Inherits System.Web.UI.Page
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents rblQry As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents ddlWheelType As System.Web.UI.WebControls.DropDownList
    Protected WithEvents rblTesttype As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents PanelWheel As System.Web.UI.WebControls.Panel
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents txtToDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFromDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlDrg As System.Web.UI.WebControls.DropDownList
    Protected WithEvents PanelDrawing As System.Web.UI.WebControls.Panel
    Protected WithEvents lblPhos_Sul As System.Web.UI.WebControls.Label
    Protected WithEvents lblVanadium As System.Web.UI.WebControls.Label
    Protected WithEvents lblMolybd As System.Web.UI.WebControls.Label
    Protected WithEvents lblMacroL As System.Web.UI.WebControls.Label
    Protected WithEvents lblCopper As System.Web.UI.WebControls.Label
    Protected WithEvents lblMacroV As System.Web.UI.WebControls.Label
    Protected WithEvents lblNickel As System.Web.UI.WebControls.Label
    Protected WithEvents lblASTM_size As System.Web.UI.WebControls.Label
    Protected WithEvents lblChromium As System.Web.UI.WebControls.Label
    Protected WithEvents lblSulphur As System.Web.UI.WebControls.Label
    Protected WithEvents lblCharpyU As System.Web.UI.WebControls.Label
    Protected WithEvents lblPhos As System.Web.UI.WebControls.Label
    Protected WithEvents lblReduArea As System.Web.UI.WebControls.Label
    Protected WithEvents lblSilicon As System.Web.UI.WebControls.Label
    Protected WithEvents lblElongation As System.Web.UI.WebControls.Label
    Protected WithEvents lblMang As System.Web.UI.WebControls.Label
    Protected WithEvents lblYeild As System.Web.UI.WebControls.Label
    Protected WithEvents lblCarbon As System.Web.UI.WebControls.Label
    Protected WithEvents lblUTstrength As System.Web.UI.WebControls.Label
    Protected WithEvents lblDrg As System.Web.UI.WebControls.Label
    Protected WithEvents lblSpec_group As System.Web.UI.WebControls.Label
    Protected WithEvents lblSpec As System.Web.UI.WebControls.Label
    Protected WithEvents lblLab As System.Web.UI.WebControls.Label
    Protected WithEvents lblOperator As System.Web.UI.WebControls.Label
    Protected WithEvents lblResults As System.Web.UI.WebControls.Label
    Protected WithEvents lblCastGroup As System.Web.UI.WebControls.Label
    Protected WithEvents lblCast_number As System.Web.UI.WebControls.Label
    Protected WithEvents lblTest_date As System.Web.UI.WebControls.Label
    Protected WithEvents pnlResults As System.Web.UI.WebControls.Panel
    Protected WithEvents txtNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblNo As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblType As System.Web.UI.WebControls.RadioButtonList

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

        ' Page.Theme = themeValue
        Page.Theme = Session("Theme")
    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None
        'Put user code to initialize the page here
        If IsPostBack = False Then
            txtFromDate.Text = Now.Date
            txtToDate.Text = Now.Date
            Try
                Dim dt As DataTable = metLab.tables.getCastTestDrgs
                ddlDrg.DataSource = dt
                ddlDrg.DataTextField = dt.Columns(0).ColumnName
                ddlDrg.DataValueField = dt.Columns(0).ColumnName
                ddlDrg.DataBind()
                ddlDrg.Items.Insert(0, "ALL")
                ddlDrg.SelectedIndex = 0
                GetWheelTypes()
                BindGrid()
                GetDetails()
                GetDrgDeatils()
                SetType()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub

    Private Sub GetDetails()
        Dim dt As DataTable
        dt = metLab.tables.GetSampleAxleDetails(rblNo.SelectedItem.Value, txtNumber.Text.Trim)
        If dt.Rows.Count > 0 Then
            If Not IsDBNull(dt.Rows(0)("operator_code")) Then
                lblOperator.Text = dt.Rows(0)("operator_code")
            End If
            If Not IsDBNull(dt.Rows(0)("lab_number")) Then
                lblLab.Text = dt.Rows(0)("lab_number")
            End If
            If Not IsDBNull(dt.Rows(0)("Spec")) Then
                lblSpec.Text = dt.Rows(0)("Spec")
            End If

            If Not IsDBNull(dt.Rows(0)("result")) Then
                lblResults.Text = dt.Rows(0)("result")
            End If
            If Not IsDBNull(dt.Rows(0)("cast_group")) Then
                lblCastGroup.Text = dt.Rows(0)("cast_group")
            End If
            If Not IsDBNull(dt.Rows(0)("drawing_number")) Then
                lblDrg.Text = dt.Rows(0)("drawing_number")
            End If

            If Not IsDBNull(dt.Rows(0)("test_date")) Then
                lblTest_date.Text = dt.Rows(0)("test_date")
            End If
            If Not IsDBNull(dt.Rows(0)("cast_number")) Then
                lblCast_number.Text = dt.Rows(0)("cast_number")
            End If
            If Not IsDBNull(dt.Rows(0)("ut_strength")) Then
                lblUTstrength.Text = dt.Rows(0)("ut_strength")
            End If
            If Not IsDBNull(dt.Rows(0)("yield_strength")) Then
                lblYeild.Text = dt.Rows(0)("yield_strength")
            End If
            If Not IsDBNull(dt.Rows(0)("elongation")) Then
                lblElongation.Text = dt.Rows(0)("elongation")
            End If
            If Not IsDBNull(dt.Rows(0)("reduction")) Then
                lblReduArea.Text = dt.Rows(0)("reduction")
            End If
            If Not IsDBNull(dt.Rows(0)("charpy")) Then
                lblCharpyU.Text = dt.Rows(0)("charpy")
            End If
            If Not IsDBNull(dt.Rows(0)("macro_vert")) Then
                lblMacroV.Text = dt.Rows(0)("macro_vert")
            End If
            If Not IsDBNull(dt.Rows(0)("macro_long")) Then
                lblMacroL.Text = dt.Rows(0)("macro_long")
            End If
            If Not IsDBNull(dt.Rows(0)("carbon")) Then
                lblCarbon.Text = dt.Rows(0)("carbon")
            End If
            If Not IsDBNull(dt.Rows(0)("manganese")) Then
                lblMang.Text = dt.Rows(0)("manganese")
            End If
            If Not IsDBNull(dt.Rows(0)("silicon")) Then
                lblSilicon.Text = dt.Rows(0)("silicon")
            End If
            If Not IsDBNull(dt.Rows(0)("phosphorus")) Then
                lblPhos.Text = dt.Rows(0)("phosphorus")
            End If
            If Not IsDBNull(dt.Rows(0)("sulphur")) Then
                lblSulphur.Text = dt.Rows(0)("sulphur")
            End If
            If Not IsDBNull(dt.Rows(0)("chromium")) Then
                lblChromium.Text = dt.Rows(0)("chromium")
            End If
            If Not IsDBNull(dt.Rows(0)("nickle")) Then
                lblNickel.Text = dt.Rows(0)("nickle")
            End If
            If Not IsDBNull(dt.Rows(0)("copper")) Then
                lblCopper.Text = dt.Rows(0)("copper")
            End If
            If Not IsDBNull(dt.Rows(0)("molybdenum")) Then
                lblMolybd.Text = dt.Rows(0)("molybdenum")
            End If
            If Not IsDBNull(dt.Rows(0)("vanadium")) Then
                lblVanadium.Text = dt.Rows(0)("vanadium")
            End If
            If Not IsDBNull(dt.Rows(0)("phosphorus_sulphur")) Then
                lblPhos_Sul.Text = dt.Rows(0)("phosphorus_sulphur")
            End If
            If Not IsDBNull(dt.Rows(0)("astm")) Then
                lblASTM_size.Text = dt.Rows(0)("astm")
            End If
        End If
    End Sub

    Private Sub SetType()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        PanelWheel.Visible = False
        PanelDrawing.Visible = False
        pnlResults.Visible = False
        txtNumber.Text = ""
        If rblType.SelectedItem.Value = 1 Then
            PanelWheel.Visible = True
            BindGrid()
        ElseIf rblType.SelectedItem.Value = 2 Then
            pnlResults.Visible = True
            GetDetails()
        ElseIf rblType.SelectedItem.Value = 3 Then
            PanelDrawing.Visible = True
            GetDrgDeatils()
        End If
    End Sub

    Private Sub GetDrgDeatils()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Try
            DataGrid1.DataSource = metLab.tables.getCastTestDrgsDetails(CDate(txtFromDate.Text), CDate(txtToDate.Text), ddlDrg.SelectedItem.Text)
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub GetWheelTypes()
        ddlWheelType.DataSource = Nothing
        ddlWheelType.DataBind()
        Dim dt As New DataTable()
        Try
            dt = metLab.tables.GetWheelTypes()
            ddlWheelType.DataSource = dt
            ddlWheelType.DataTextField = dt.Columns(0).ColumnName
            ddlWheelType.DataValueField = dt.Columns(1).ColumnName
            ddlWheelType.DataBind()
            ddlWheelType.SelectedIndex = 0
            BindGrid()
        Catch exp As Exception
            Throw New Exception(exp.Message)
        End Try
    End Sub

    Private Sub BindGrid()
        Dim dt As New DataTable()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Try
            dt = metLab.tables.GetSampleHeatRanges(rblTesttype.SelectedItem.Value, ddlWheelType.SelectedItem.Value.Trim, rblQry.SelectedItem.Text.Trim)
            If dt.Rows.Count > 0 Then
                DataGrid1.DataSource = dt
                DataGrid1.DataBind()
            Else
                Throw New Exception("No samples for selected WheelType or TestType !")
            End If
        Catch exp As Exception
            Throw New Exception(exp.Message)
        End Try
    End Sub

    Private Sub ddlWheelType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlWheelType.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            BindGrid()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub rblTesttype_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblTesttype.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            BindGrid()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub rblQry_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblQry.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            BindGrid()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub rblType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblType.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            SetType()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        lblMessage.Text = ""
        Try
            GetDrgDeatils()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub rblNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblNo.SelectedIndexChanged
        lblMessage.Text = ""
        txtNumber.Text = ""
    End Sub

    Private Sub txtNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumber.TextChanged
        Try
            GetDetails()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
End Class
