Public Class NewBreakDownAnalysis
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents txtFromDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtToDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnShow As System.Web.UI.WebControls.Button
    Protected WithEvents dgGroupWise As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnPrimary As System.Web.UI.WebControls.Button
    Protected WithEvents btnSecondary As System.Web.UI.WebControls.Button
    Protected WithEvents dgMachineWise As System.Web.UI.WebControls.DataGrid
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
        If Page.IsPostBack = False Then
            txtFromDate.Text = Now.Date
            txtToDate.Text = Now.Date
            GetGroupData()
            GetMachineData()
        End If
    End Sub
    Private Sub GetGroupData()
        Dim dtfr, dtto As String
        dtfr = Format(CDate(txtFromDate.Text.Trim), "yyyy-MM-dd")
        dtTo = Format(CDate(txtToDate.Text.Trim), "yyyy-MM-dd")
        dgGroupWise.DataSource = Nothing
        dgGroupWise.DataBind()
        dgGroupWise.SelectedIndex = -1
        Dim da As New SqlClient.SqlDataAdapter()
        da.SelectCommand = New SqlClient.SqlCommand()
        Dim ds As New DataSet()
        Dim dv As New DataView()
        da.SelectCommand.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
        Try
            da.SelectCommand.CommandText = " select * from dbo.ms_fn_BreakdownAnalysisGroupWise('" & dtfr & "','" & dtto & "') "
            da.Fill(ds)
            dgGroupWise.DataSource = ds.Tables(0).DefaultView
            dgGroupWise.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            da.Dispose()
            ds.Dispose()
        End Try
    End Sub
    Private Sub GetMachineData()
        Dim dtfr, dtto As String
        dtfr = Format(CDate(txtFromDate.Text.Trim), "yyyy-MM-dd")
        dtto = Format(CDate(txtToDate.Text.Trim), "yyyy-MM-dd")
        dgMachineWise.DataSource = Nothing
        dgMachineWise.DataBind()
        Dim da As New SqlClient.SqlDataAdapter()
        da.SelectCommand = New SqlClient.SqlCommand()
        Dim ds As New DataSet()
        Dim dv As New DataView()
        da.SelectCommand.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
        Try
            da.SelectCommand.CommandText = " select * from dbo.ms_fn_BreakdownAnalysisMachineWise('" & dtfr & "','" & dtto & "')  "
            da.Fill(ds)
            viewstate("MachineData") = ds
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            da.Dispose()
            ds.Dispose()
        End Try
    End Sub

    Private Sub dgGroupWise_ItemCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgGroupWise.ItemCommand
        lblMessage.Text = ""
        Dim PA, GN As String
        Dim ds As DataSet
        Dim dv As DataView
        Try
            ds = CType(viewstate("MachineData"), DataSet)
            dv = ds.Tables(0).DefaultView
            Select Case e.CommandName
                Case "Select"
                    PA = e.Item.Cells(1).Text.Trim
                    GN = e.Item.Cells(2).Text.Trim
                    dv.RowFilter = "Affected = '" & PA.Trim & "' and GroupName = '" & GN.Trim & "'"
                    dgMachineWise.DataSource = dv
                    dgMachineWise.DataBind()
            End Select
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
        lblMessage.Text = ""
        Try
            GetGroupData()
            GetMachineData()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnPrimary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrimary.Click
        If dgGroupWise.Items.Count > 0 Then
            Dim prevstate As Boolean = Me.EnableViewState
            Dim tw As New System.IO.StringWriter()
            Dim hw As New System.Web.UI.HtmlTextWriter(tw)
            Try
                Response.ContentType = "application/vnd.ms_excel"
                Response.Charset = ""
                Me.EnableViewState = False
                dgGroupWise.RenderControl(hw)
                Response.Write(tw.ToString)
                Response.End()
                Me.EnableViewState = prevstate
            Catch exp As Exception
                lblMessage.Text = exp.Message
            Finally
            End Try
        Else
            lblMessage.Text = "No Items for export !"
        End If
    End Sub

    Private Sub btnSecondary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSecondary.Click
        If dgMachineWise.Items.Count > 0 Then
            Dim prevstate As Boolean = Me.EnableViewState
            Dim tw As New System.IO.StringWriter()
            Dim hw As New System.Web.UI.HtmlTextWriter(tw)
            Try
                Response.ContentType = "application/vnd.ms_excel"
                Response.Charset = ""
                Me.EnableViewState = False
                dgMachineWise.RenderControl(hw)
                Response.Write(tw.ToString)
                Response.End()
                Me.EnableViewState = prevstate
            Catch exp As Exception
                lblMessage.Text = exp.Message
            Finally
            End Try
        Else
            lblMessage.Text = "No Items for export !"
        End If
    End Sub
End Class
