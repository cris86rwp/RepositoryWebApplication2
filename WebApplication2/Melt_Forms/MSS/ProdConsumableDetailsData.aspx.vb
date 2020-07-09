Public Class ProdConsumableDetailsData
    Inherits System.Web.UI.Page
    Protected WithEvents btnReport As System.Web.UI.WebControls.Button
    Protected WithEvents rblType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtToDt As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFrDt As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents lblConsignee As System.Web.UI.WebControls.Label
    Protected WithEvents btnExportDetails As System.Web.UI.WebControls.Button
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents ddlPLs As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblPLDescr As System.Web.UI.WebControls.Label
    Protected WithEvents pnl3 As System.Web.UI.WebControls.Panel
    Protected WithEvents pnl4 As System.Web.UI.WebControls.Panel
    Protected WithEvents rblFur As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
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


    Protected Sub Dd1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        themeValue = Dd1.SelectedItem.Value
        Response.Redirect(Request.Url.ToString())

    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If IsPostBack = False Then
            Dim Group As String = Session("Group")
            Dim UserId As String = Session("UserID")
            Dim InValid As Boolean = False
            ''''''''''''''''
            'Group = "SSMELT"
            'UserId = "074510"
            ''''''''''''''''
            Try
                lblConsignee.Text = ProductionConsumables.GetConsignee(Group, UserId)
                If lblConsignee.Text.Trim.Length = 4 Then InValid = True
                GetPls()
                SetType()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
            'If Not InValid Then
            '    Response.Redirect("/mss/logon.aspx")
            'Else
            txtFrDt.Text = Now.Date
                txtToDt.Text = Now.Date
            End If
        'End If
    End Sub

    Private Sub GetPls()
        Dim dt As DataTable
        Try
            dt = ProductionConsumables.GetProdConsumableRegisterPLs(lblConsignee.Text)
            ddlPLs.DataSource = dt
            ddlPLs.DataTextField = dt.Columns(1).ColumnName
            ddlPLs.DataValueField = dt.Columns(2).ColumnName
            ddlPLs.DataBind()
            ddlPLs.Items.Insert(0, "ALL")
            ddlPLs.SelectedIndex = 0
            lblPLDescr.Text = ddlPLs.SelectedItem.Value
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt = Nothing
        End Try
    End Sub

    Private Sub btnExportDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportDetails.Click
        Dim prevstate As Boolean = Me.EnableViewState
        Dim tw As New System.IO.StringWriter()
        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
        Try
            Response.ContentType = "application/vnd.ms_excel"
            Response.Charset = ""
            Me.EnableViewState = False
            DataGrid1.RenderControl(hw)
            Response.Write(tw.ToString)
            Response.End()
            Me.EnableViewState = prevstate
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
        End Try
    End Sub

    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click
        lblMessage.Text = ""
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Dim PLorFur As String = ""
        Dim FrDt, ToDt As Date
        Try
            If rblType.SelectedItem.Value = 4 Then
                PLorFur = rblFur.SelectedItem.Text
            ElseIf rblType.SelectedItem.Value = 3 Then
                PLorFur = ddlPLs.SelectedItem.Text
            End If
            If rblType.SelectedItem.Value = 2 Then
                FrDt = Now.Date
                ToDt = Now.Date
            Else
                FrDt = CDate(txtFrDt.Text)
                ToDt = CDate(txtToDt.Text)
            End If
            DataGrid1.DataSource = ProductionConsumables.ProdConsumableDetailsData(FrDt, ToDt, Val(txtFrDt.Text), Val(txtToDt.Text), PLorFur.Trim, rblType.SelectedItem.Value)
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
        End Try
    End Sub

    Private Sub ddlPLs_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlPLs.SelectedIndexChanged
        lblMessage.Text = ""
        lblPLDescr.Text = ddlPLs.SelectedItem.Value
    End Sub

    Private Sub rblType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblType.SelectedIndexChanged
        SetType()
    End Sub

    Private Sub SetType()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        pnl3.Visible = False
        pnl4.Visible = False
        Label1.Text = "FromDate"
        Label2.Text = "ToDate"
        txtFrDt.Text = Now.Date
        txtToDt.Text = Now.Date
        If rblType.SelectedItem.Value = 2 Then
            Label1.Text = "FromHeat"
            Label2.Text = "ToHeat"
            txtFrDt.Text = 0
            txtToDt.Text = 0
        ElseIf rblType.SelectedItem.Value = 3 Then
            pnl3.Visible = True
        ElseIf rblType.SelectedItem.Value = 4 Then
            pnl4.Visible = True
        End If
    End Sub
End Class
