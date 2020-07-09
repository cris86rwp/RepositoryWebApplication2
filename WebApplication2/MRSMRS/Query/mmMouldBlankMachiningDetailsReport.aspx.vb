Public Class mmMouldBlankMachiningDetailsReport
    Inherits System.Web.UI.Page
    Protected WithEvents btnExportDetails As System.Web.UI.WebControls.Button
    Protected WithEvents btnShow As System.Web.UI.WebControls.Button
    Protected WithEvents rblQry As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtToDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFromDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
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
    Public Property MouldMaster As Object

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
        If Page.IsPostBack = False Then
            txtFromDate.Text = Now.Date
            txtToDate.Text = Now.Date
        End If
    End Sub

    Private Sub txtFromDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFromDate.TextChanged
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        lblMessage.Text = ""
        Dim dt As Date
        Try
            dt = CDate(txtFromDate.Text)
            If dt > Now.Date Then
                lblMessage.Text = "Future date not allowed "
                txtFromDate.Text = ""
            Else
                txtFromDate.Text = dt
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt = Nothing
        End Try
    End Sub

    Private Sub txtToDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtToDate.TextChanged
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        lblMessage.Text = ""
        Dim dt As Date
        Try
            dt = CDate(txtToDate.Text)
            If dt > Now.Date Then
                lblMessage.Text = "Future date not allowed "
                txtToDate.Text = ""
            Else
                txtToDate.Text = dt
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt = Nothing
        End Try
    End Sub

    Private Sub btnExportDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportDetails.Click
        If DataGrid1.Items.Count > 0 Then
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
                prevstate = Nothing
                tw = Nothing
                hw = Nothing
            End Try
        Else
            lblMessage.Text = "No Data in Grid to export !"
        End If
    End Sub

    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Try
            DataGrid1.DataSource = MouldMaster.MRSMRS.Moulds(CDate(txtFromDate.Text), CDate(txtToDate.Text), rblQry.SelectedItem.Value)
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

End Class