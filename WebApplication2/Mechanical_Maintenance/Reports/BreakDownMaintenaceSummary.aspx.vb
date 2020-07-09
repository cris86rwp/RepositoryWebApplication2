Public Class BreakDownMaintenaceSummary
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents lblMaintenance_group As System.Web.UI.WebControls.Label
    Protected WithEvents cboLocation As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlMachineCode As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtFrDt As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtToDt As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlType As System.Web.UI.WebControls.DropDownList
    Protected WithEvents radProduction As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtTime As System.Web.UI.WebControls.TextBox
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents dgDetails As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnShowReport As System.Web.UI.WebControls.Button
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList
    Shared themeValue As String

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
    Private Sub Page_PreInit(ByVal sender As Object, ByVal e As EventArgs)
        Page.Theme = themeValue
    End Sub

    Public Sub New()
        AddHandler PreInit, New EventHandler(AddressOf Page_PreInit)
    End Sub

    Protected Sub dd1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        themeValue = Dd1.SelectedItem.Value
        Response.Redirect(Request.Url.ToString())

    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        'strMode = Request.QueryString("mode")
        'Session("group") = "AC"
        Dim grp As String
        grp = Session("group")
        'lblMaintenance_group.Text = grp.Substring(1)
        lblMaintenance_group.Text = Session("group")
        If Not Page.IsPostBack Then
            txtFrDt.Text = Now.Date
            txtToDt.Text = Now.Date
            ddlMachineCode.Items.Insert(0, New ListItem("ALL", "ALL"))
            PopulateLocation()
        End If
    End Sub
    Private Sub PopulateLocation()
        Dim ds As New DataSet()
        Try
            ds = Maintenance.tables.PopulateLocationType(lblMaintenance_group.Text.Trim)
            cboLocation.DataSource = ds.Tables(0).DefaultView
            cboLocation.DataTextField = ds.Tables(0).Columns(1).ColumnName
            cboLocation.DataValueField = ds.Tables(0).Columns(0).ColumnName
            cboLocation.DataBind()
            ddlType.DataSource = ds.Tables(1).DefaultView
            ddlType.DataTextField = ds.Tables(1).Columns(0).ColumnName
            ddlType.DataValueField = ds.Tables(1).Columns(0).ColumnName
            ddlType.DataBind()
            cboLocation.Items.Insert(0, New ListItem("ALL", "ALL"))
            ddlType.Items.Insert(0, New ListItem("ALL", "ALL"))
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            ds.Dispose()
        End Try
        
    End Sub

    Private Sub cboLocation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLocation.SelectedIndexChanged
        Dim strsql, grp, shop As String
        grp = Session("group")
        shop = cboLocation.SelectedItem.Value.Trim
        Dim dt As DataTable
        Try
            dt = Maintenance.tables.PopulateMachine(grp, shop)
            ddlMachineCode.DataSource = dt.DefaultView
            ddlMachineCode.DataTextField = dt.Columns(0).ColumnName
            ddlMachineCode.DataValueField = dt.Columns(1).ColumnName
            ddlMachineCode.DataBind()
            ddlMachineCode.Items.Insert(0, New ListItem("ALL", "ALL"))
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
        End Try
    End Sub

    Private Sub btnShowReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowReport.Click
        Dim strsql, grp, shop As String
        dgDetails.DataSource = Nothing
        dgDetails.DataBind()
        grp = Session("group")
        shop = cboLocation.SelectedItem.Value.Trim
        Try
            dgDetails.DataSource = Maintenance.tables.BreakDownMaintenaceSummary(grp.Trim, CDate(txtFrDt.Text.Trim), CDate(txtToDt.Text.Trim), cboLocation.SelectedItem.Value.Trim, ddlMachineCode.SelectedItem.Value.Trim, ddlType.SelectedItem.Value.Trim, radProduction.SelectedItem.Value.Trim, Val(txtTime.Text.Trim))
            dgDetails.DataBind()
        Catch exp As Exception
            Throw New Exception(exp.Message)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim prevstate As Boolean = Me.EnableViewState
        Dim tw As New System.IO.StringWriter()
        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
        Try
            Response.ContentType = "application/vnd.ms_excel"
            Response.Charset = ""
            Me.EnableViewState = False
            dgDetails.RenderControl(hw)
            Response.Write(tw.ToString)
            Response.End()
            Me.EnableViewState = prevstate
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
        End Try
    End Sub
End Class
