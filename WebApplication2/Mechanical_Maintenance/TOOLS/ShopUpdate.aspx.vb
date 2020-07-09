Public Class ShopUpdate
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblInstrumentType As System.Web.UI.WebControls.Label
    Protected WithEvents ddlInstruments As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlShop As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnUpdate As System.Web.UI.WebControls.Button
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


    Protected Sub dd1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        themeValue = Dd1.SelectedItem.Value
        Response.Redirect(Request.Url.ToString())

    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If IsPostBack = False Then
            Try
                getShop_codes()
                GetToolsList()
                FillGrid()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub

    Private Sub GetToolsList()
        Dim ds As DataSet
        ds = ToolRoom.Tables.ToolsForFQChange
        If ds.Tables(0).Rows.Count > 0 Then
            ddlInstruments.DataSource = ds.Tables(0)
            ddlInstruments.DataTextField = ds.Tables(0).Columns("InstrumentNumber").ColumnName
            ddlInstruments.DataValueField = ds.Tables(0).Columns("InstrumentType").ColumnName
            ddlInstruments.DataBind()
            ddlInstruments.SelectedIndex = 0
            lblInstrumentType.Text = ddlInstruments.SelectedItem.Value
        End If
    End Sub

    Private Sub getShop_codes()
        Dim ds As New DataSet()
        Try
            ds = ToolRoom.Tables.getTables
            ddlShop.DataSource = ds.Tables(1)
            ddlShop.DataTextField = ds.Tables(1).Columns("description").ColumnName
            ddlShop.DataValueField = ds.Tables(1).Columns("code").ColumnName
            ddlShop.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            ds.Dispose()
        End Try
    End Sub

    Private Sub ddlInstruments_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlInstruments.SelectedIndexChanged
        lblMessage.Text = ""
        lblInstrumentType.Text = ddlInstruments.SelectedItem.Value
        FillGrid()
    End Sub

    Private Sub FillGrid()
        Dim ds As DataSet
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Try
            ds = ToolRoom.Tables.ToolHistory(ddlInstruments.SelectedItem.Text.Trim)
            DataGrid1.DataSource = ds.Tables(0)
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        lblMessage.Text = ""
        Dim Done As Boolean
        Try
            Done = New ToolRoom.Tool("T").UpdateShop(ddlInstruments.SelectedItem.Text, ddlShop.SelectedItem.Value)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If Done Then
            FillGrid()
            lblMessage.Text &= " Data Updated !"
        End If
        Done = Nothing
    End Sub
End Class
