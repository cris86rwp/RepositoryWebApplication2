Public Class TestReadingDateReport
    Inherits System.Web.UI.Page
    Protected WithEvents Button2 As System.Web.UI.WebControls.Button
    Protected WithEvents ddlMaterial As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboLab As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtTo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFrom As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RangeValidator2 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents RangeValidator1 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents btnSubmit As System.Web.UI.WebControls.Button
    Protected WithEvents rblMaterial As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents btnRevised As System.Web.UI.WebControls.Button
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label

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

        ' Page.Theme = themeValue
        Page.Theme = Session("Theme")
    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None
        'Put user code to initialize the page here
        If Not IsPostBack Then
            btnRevised.Text = "Show " & rblMaterial.SelectedItem.Text & " Results "
            txtFrom.Text = Date.Today
            txtTo.Text = Date.Today
            Dim ds As DataSet
            Try
                ds = metLab.tables.test_name
                cboLab.DataSource = ds.Tables(0)
                cboLab.DataTextField = ds.Tables(0).Columns("test_name").ColumnName
                cboLab.DataValueField = ds.Tables(0).Columns("test_name").ColumnName
                cboLab.DataBind()
                cboLab.Items.Insert(0, "ALL")
                cboLab.SelectedIndex = 0
                ddlMaterial.DataSource = ds.Tables(1)
                ddlMaterial.DataTextField = ds.Tables(1).Columns("Material").ColumnName
                ddlMaterial.DataValueField = ds.Tables(1).Columns("MaterialID").ColumnName
                ddlMaterial.DataBind()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            Finally
                ds.Dispose()
            End Try
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
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

    Private Sub cboLab_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLab.SelectedIndexChanged
        lblMessage.Text = ""
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
    End Sub

    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        lblMessage.Text = ""
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Try
            DataGrid1.DataSource = metLab.tables.OldResults(CDate(txtFrom.Text), CDate(txtTo.Text), cboLab.SelectedItem.Value.Trim)
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        lblMessage.Text = ""
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Try
            DataGrid1.DataSource = metLab.tables.NewResults(CDate(txtFrom.Text), CDate(txtTo.Text), ddlMaterial.SelectedItem.Value)
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnRevised_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRevised.Click
        lblMessage.Text = ""
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Try
            If rblMaterial.SelectedItem.Text = "Daily Samples Position" Then
                DataGrid1.DataSource = metLab.tables.DailySamples(CDate(txtFrom.Text), CDate(txtTo.Text))
                DataGrid1.DataBind()
            Else
                DataGrid1.DataSource = metLab.tables.DateWiseReport(CDate(txtFrom.Text), CDate(txtTo.Text), rblMaterial.SelectedItem.Value)
                DataGrid1.DataBind()
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub rblMaterial_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblMaterial.SelectedIndexChanged
        lblMessage.Text = ""
        btnRevised.Text = "Show " & rblMaterial.SelectedItem.Text & " Results "
    End Sub
End Class
