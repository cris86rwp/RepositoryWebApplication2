Public Class IMBPLDetails
    Inherits System.Web.UI.Page
    Protected WithEvents lblLocationID As System.Web.UI.WebControls.Label
    Protected WithEvents lblBalance As System.Web.UI.WebControls.Label
    Protected WithEvents lblPLUnit As System.Web.UI.WebControls.Label
    Protected WithEvents ddlPLNumber As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblInStore As System.Web.UI.WebControls.Label
    Protected WithEvents lblLocation As System.Web.UI.WebControls.Label
    Protected WithEvents txtFromDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtToDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblUnitRate As System.Web.UI.WebControls.Label
    Protected WithEvents lblLedgerNo As System.Web.UI.WebControls.Label
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Not IsPostBack Then
            txtFromDate.Text = Now.Date
            txtToDate.Text = Now.Date
            GetPlNumber()
        End If
    End Sub
    Private Sub GetPlNumber()
        Dim dt As DataTable
        Try
            dt = imb.GetPls
            ddlPLNumber.DataSource = dt
            ddlPLNumber.DataTextField = dt.Columns(1).ColumnName
            ddlPLNumber.DataValueField = dt.Columns(0).ColumnName
            ddlPLNumber.DataBind()
            ddlPLNumber.Items.Insert(0, New ListItem("Select", 0))
        Catch exp As Exception
            lblMessage.Text = exp.Message
            'Finally
            'dt.Dispose()
        End Try
    End Sub

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


    Private Sub ddlPLNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlPLNumber.SelectedIndexChanged
        lblMessage.Text = ""
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        lblLedgerNo.Text = ""
        lblLocationID.Text = ""
        lblLocation.Text = ""
        lblInStore.Text = ""
        lblBalance.Text = ""
        lblPLUnit.Text = ""
        lblUnitRate.Text = ""
        If ddlPLNumber.SelectedIndex = 0 Then
        Else
            Dim ds As DataSet
            Try
                ds = imb.PLDetails(ddlPLNumber.SelectedItem.Value.Trim, CDate(txtFromDate.Text), CDate(txtToDate.Text))
                If ds.Tables(0).Rows.Count > 0 Then
                    lblLedgerNo.Text = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("LedgerNumber")), "", ds.Tables(0).Rows(0).Item("LedgerNumber"))
                    lblLocationID.Text = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("Location")), "", ds.Tables(0).Rows(0).Item("Location"))
                    lblLocation.Text = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("LocationDesc")), "", ds.Tables(0).Rows(0).Item("LocationDesc"))
                    lblBalance.Text = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("InIMB")), 0, ds.Tables(0).Rows(0).Item("InIMB"))
                    lblPLUnit.Text = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("PLUnitName")), "", ds.Tables(0).Rows(0).Item("PLUnitName"))
                    lblInStore.Text = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("InStore")), 0, ds.Tables(0).Rows(0).Item("InStore"))
                    lblUnitRate.Text = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("UnitRate")), 0, ds.Tables(0).Rows(0).Item("UnitRate"))
                End If
                DataGrid1.DataSource = ds.Tables(1)
                DataGrid1.DataBind()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
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
            End Try
        Else
            lblMessage.Text = "No Data to export !"
        End If
    End Sub
End Class
