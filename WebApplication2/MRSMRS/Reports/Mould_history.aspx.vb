Public Class Mould_history
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents txtMldNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents dgStatus As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid3 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid4 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnQuerry As System.Web.UI.WebControls.Button
    Protected WithEvents DataGrid5 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents txtPO As System.Web.UI.WebControls.TextBox
    Protected WithEvents DataGrid6 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnSum As System.Web.UI.WebControls.Button
    Protected WithEvents rblPO As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents btnExportDetails As System.Web.UI.WebControls.Button
    Protected WithEvents DataGrid7 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid8 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Button2 As System.Web.UI.WebControls.Button
    Protected WithEvents btnReport As System.Web.UI.WebControls.Button
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList



    Shared themeValue As String
    Private MouldMaster As Object

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

    End Sub

    Private Sub btnQuerry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuerry.Click
        lblMessage.Text = ""
        dgStatus.DataSource = Nothing
        dgStatus.DataBind()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        DataGrid3.DataSource = Nothing
        DataGrid3.DataBind()
        DataGrid4.DataSource = Nothing
        DataGrid4.DataBind()
        DataGrid5.DataSource = Nothing
        DataGrid5.DataBind()
        DataGrid6.DataSource = Nothing
        DataGrid6.DataBind()
        DataGrid7.DataSource = Nothing
        DataGrid7.DataBind()
        DataGrid8.DataSource = Nothing
        DataGrid8.DataBind()
        Dim ds As New DataSet()
        Try
            ds = MouldMaster.MRSMRS.MouldsHistory(txtMldNo.Text.Trim)
            dgStatus.DataSource = ds.Tables(0)
            dgStatus.DataBind()
            DataGrid1.DataSource = ds.Tables(1)
            DataGrid1.DataBind()
            DataGrid2.DataSource = ds.Tables(2)
            DataGrid2.DataBind()
            DataGrid3.DataSource = ds.Tables(3)
            DataGrid3.DataBind()
            DataGrid4.DataSource = ds.Tables(4)
            DataGrid4.DataBind()
            DataGrid5.DataSource = ds.Tables(5)
            DataGrid5.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            ds.Dispose()
            ds = Nothing
        End Try
    End Sub

    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim strServer, strPathName, rptName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=26488&user0=sa&password0=sadev123" &
                     "&prompt0=" & Trim(txtMldNo.Text)
        Response.Redirect(strPathName)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        lblMessage.Text = ""
        dgStatus.DataSource = Nothing
        dgStatus.DataBind()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        DataGrid3.DataSource = Nothing
        DataGrid3.DataBind()
        DataGrid4.DataSource = Nothing
        DataGrid4.DataBind()
        DataGrid5.DataSource = Nothing
        DataGrid5.DataBind()
        DataGrid6.DataSource = Nothing
        DataGrid6.DataBind()
        DataGrid7.DataSource = Nothing
        DataGrid7.DataBind()
        DataGrid8.DataSource = Nothing
        DataGrid8.DataBind()
        Try
            DataGrid1.DataSource = MouldMaster.MRSMRS.MouldsRejectedWhlsList(txtMldNo.Text.Trim, 0)
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnSum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSum.Click
        lblMessage.Text = ""
        dgStatus.DataSource = Nothing
        dgStatus.DataBind()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        DataGrid3.DataSource = Nothing
        DataGrid3.DataBind()
        DataGrid4.DataSource = Nothing
        DataGrid4.DataBind()
        DataGrid5.DataSource = Nothing
        DataGrid5.DataBind()
        DataGrid6.DataSource = Nothing
        DataGrid6.DataBind()
        DataGrid7.DataSource = Nothing
        DataGrid7.DataBind()
        DataGrid8.DataSource = Nothing
        DataGrid8.DataBind()
        Try
            DataGrid6.DataSource = MouldMaster.MRSMRS.MouldsPO(txtPO.Text.Trim, rblPO.SelectedItem.Value)
            DataGrid6.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnExportDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportDetails.Click
        If DataGrid6.Items.Count > 0 Then
            Dim prevstate As Boolean = Me.EnableViewState
            Dim tw As New System.IO.StringWriter()
            Dim hw As New System.Web.UI.HtmlTextWriter(tw)
            Try
                Response.ContentType = "application/vnd.ms_excel"
                Response.Charset = ""
                Me.EnableViewState = False
                DataGrid6.RenderControl(hw)
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

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        lblMessage.Text = ""
        dgStatus.DataSource = Nothing
        dgStatus.DataBind()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        DataGrid3.DataSource = Nothing
        DataGrid3.DataBind()
        DataGrid4.DataSource = Nothing
        DataGrid4.DataBind()
        DataGrid5.DataSource = Nothing
        DataGrid5.DataBind()
        DataGrid6.DataSource = Nothing
        DataGrid6.DataBind()
        DataGrid7.DataSource = Nothing
        DataGrid7.DataBind()
        DataGrid8.DataSource = Nothing
        DataGrid8.DataBind()
        Dim ds As DataSet
        Try
            ds = MouldMaster.MRSMRS.MouldsRejectedWhlsList(txtMldNo.Text.Trim, 1)
            DataGrid1.DataSource = ds.Tables(0)
            DataGrid1.DataBind()
            DataGrid2.DataSource = ds.Tables(1)
            DataGrid2.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
End Class
