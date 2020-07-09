Public Class Conemned_graphite_moulds
    Inherits System.Web.UI.Page
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents txtToDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFromDt As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents rblGrid As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents btnShpw As System.Web.UI.WebControls.Button
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents rblReport As System.Web.UI.WebControls.RadioButtonList
    Public Property MouldMaster As Object

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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Page.IsPostBack = False Then
            txtFromDt.Text = Now.Date
            txtToDate.Text = Now.Date
        End If
    End Sub

    Private Sub btnShpw_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShpw.Click
        lblMessage.Text = ""
        Try
            If CDate(txtFromDt.Text) > CDate(txtToDate.Text) Then
                lblMessage.Text = "From Date More Than To Date"
                Exit Try
            End If
            If CDate(txtFromDt.Text) > Today Or CDate(txtToDate.Text) > Today Then
                lblMessage.Text = "Date more than today"
                Exit Try
            End If
            ShowDetails()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub ShowDetails()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Try
            DataGrid1.DataSource = MouldMaster.MRSMRS.NewAndConMoulds(CDate(txtFromDt.Text), CDate(txtToDate.Text), rblGrid.SelectedItem.Text.Trim, rblReport.SelectedItem.Value)
            DataGrid1.DataBind()
        Catch exp As Exception
            Throw New Exception(exp.Message & " ; Retrival of Mould Data Error ; ")
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
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
            lblMessage.Text = "No Data in Grid to export!"
        End If
    End Sub
End Class
