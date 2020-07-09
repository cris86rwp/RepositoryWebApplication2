Public Class mm_ContinueShift_AuthorisationView
    Inherits System.Web.UI.Page
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtDt As System.Web.UI.WebControls.TextBox
    Protected WithEvents DataGrid3 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
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
        If Page.IsPostBack = False Then
            txtDt.Text = Now.Date
            Try
                GetData()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
        
    End Sub
    Private Sub GetData()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        DataGrid3.DataSource = Nothing
        DataGrid3.DataBind()
        Dim ds As New DataSet()
        Try
            ds = RWF.AWMCLR.GetContinueShiftData(CDate(txtDt.Text.Trim))
            DataGrid1.DataSource = ds.Tables(0).Copy
            DataGrid1.DataBind()
            DataGrid2.DataSource = ds.Tables(1).Copy
            DataGrid2.DataBind()
            DataGrid3.DataSource = ds.Tables(2).Copy
            DataGrid3.DataBind()
        Catch exp As Exception
            DataGrid1.DataSource = Nothing
            DataGrid1.DataBind()
        Finally
            ds.Dispose()
            ds = Nothing
        End Try
    End Sub

    Private Sub txtDt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDt.TextChanged
        Try
            GetData()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
End Class
