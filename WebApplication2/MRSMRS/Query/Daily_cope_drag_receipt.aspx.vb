Public Class Daily_cope_drag_receipt
    Inherits System.Web.UI.Page
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblerr As System.Web.UI.WebControls.Label
    Protected WithEvents TextBox1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid3 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents txtFromDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtToDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents Panel3 As System.Web.UI.WebControls.Panel
    Protected WithEvents btnPODetails As System.Web.UI.WebControls.Button
    Protected WithEvents txtFrDt As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnReceipt As System.Web.UI.WebControls.Button
    Protected WithEvents txtToDt As System.Web.UI.WebControls.TextBox
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
            txtDate.Text = Now.Date
            txtFromDate.Text = Now.Date
            txtToDate.Text = Now.Date
            txtFrDt.Text = Now.Date
            txtToDt.Text = Now.Date
        End If
    End Sub
    Private Sub clear()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        DataGrid3.DataSource = Nothing
        DataGrid3.DataBind()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ds As DataSet
        clear()
        Try
            ds = MouldMaster.MRSMRS.MouldReceiptDetails(CDate(txtFromDate.Text), CDate(txtToDate.Text), TextBox1.Text.Trim)
            DataGrid1.DataSource = ds.Tables(0).Copy
            DataGrid1.DataBind()
            DataGrid2.DataSource = ds.Tables(1).Copy
            DataGrid2.DataBind()
            DataGrid3.DataSource = ds.Tables(2).Copy
            DataGrid3.DataBind()
        Catch exp As Exception
            Throw New Exception("Unable to create Consumption Details Table")
        Finally
            ds.Dispose()
            ds = Nothing
        End Try
    End Sub

    Private Sub btnPODetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPODetails.Click
        Try
            DataGrid1.DataSource = MouldMaster.MRSMRS.MouldPODetails(CDate(txtFrDt.Text), CDate(txtToDt.Text))
            DataGrid1.DataBind()
            DataGrid2.DataSource = Nothing
            DataGrid2.DataBind()
            DataGrid3.DataSource = Nothing
            DataGrid3.DataBind()
        Catch exp As Exception
            Throw New Exception("Unable to create Consumption Details Table")
        End Try
    End Sub

    Private Sub btnReceipt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReceipt.Click
        clear()
        Try
            DataGrid1.DataSource = MouldMaster.MRSMRS.MouldsReceipt(CDate(txtDate.Text))
            DataGrid1.DataBind()
        Catch exp As Exception
            lblerr.Text = exp.Message
        End Try
    End Sub
End Class
