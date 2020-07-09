Public Class Daily_mould_position
    Inherits System.Web.UI.Page
    Protected WithEvents txtToDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFromDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblMouldType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblProduct As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
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
        If Page.IsPostBack = False Then
            txtFromDate.Text = Now.Date
            txtToDate.Text = Now.Date
            Try
                getMachinedProduct()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            Finally
            End Try
        End If
    End Sub

    Private Sub getMachinedProduct()
        If Month(CDate(txtFromDate.Text)) <> Month(CDate(txtToDate.Text)) AndAlso Year(CDate(txtToDate.Text)) <> Year(CDate(txtFromDate.Text)) Then
            Exit Sub
        End If
        Dim dt As New DataTable()
        rblProduct.DataSource = Nothing
        rblProduct.DataBind()
        Try
            dt = MouldMaster.MRSMRS.MouldPCDOMouldTypes(CDate(txtFromDate.Text), CDate(txtToDate.Text))
            rblProduct.DataSource = dt
            rblProduct.DataTextField = dt.Columns("description").ColumnName
            rblProduct.DataValueField = dt.Columns("product_code").ColumnName
            rblProduct.DataBind()
            rblProduct.SelectedIndex = 0
            If CDate(txtToDate.Text) >= CDate(txtFromDate.Text) Then
                GetValues()
            End If
        Catch exp As Exception
            lblMessage.Text = "Unable to create product_code Table " & exp.Message
        Finally
            dt.Dispose()
            dt = Nothing
        End Try
    End Sub

    Private Sub GetValues()
        If Month(CDate(txtFromDate.Text)) <> Month(CDate(txtToDate.Text)) AndAlso Year(CDate(txtToDate.Text)) <> Year(CDate(txtFromDate.Text)) Then
            lblMessage.Text = "InValid Dates. From and To date month and year to be same !"
            Exit Sub
        End If
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        Dim Product, MouldType As String
        If rblProduct.SelectedIndex = -1 Then
            Product = ""
        Else
            Product = rblProduct.SelectedItem.Text
        End If
        If IsNothing(rblMouldType.SelectedItem.Value) Then
            MouldType = ""
        Else
            MouldType = rblMouldType.SelectedItem.Value
        End If
        Try
            DataGrid2.DataSource = MouldMaster.MRSMRS.MouldPCDO(CDate(txtFromDate.Text), CDate(txtToDate.Text), Product, MouldType)
            DataGrid2.DataBind()
        Catch exp As Exception
            Throw New Exception("Unable to create product_code Table")
        End Try
    End Sub

    Private Sub rblProduct_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblProduct.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            If CDate(txtToDate.Text) >= CDate(txtFromDate.Text) Then
                GetValues()
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub rblMouldType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblMouldType.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            If CDate(txtToDate.Text) >= CDate(txtFromDate.Text) Then
                GetValues()
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtFromDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFromDate.TextChanged
        lblMessage.Text = ""
        Dim dt As Date
        Try
            dt = CDate(txtFromDate.Text)
            If dt > Now.Date Then
                lblMessage.Text = "Future date not allowed "
                txtFromDate.Text = ""
            Else
                txtFromDate.Text = dt
                If CDate(txtToDate.Text) >= CDate(txtFromDate.Text) Then
                    getMachinedProduct()
                End If
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt = Nothing
        End Try
    End Sub

    Private Sub txtToDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtToDate.TextChanged
        lblMessage.Text = ""
        Dim dt As Date
        Try
            dt = CDate(txtToDate.Text)
            If dt > Now.Date Then
                lblMessage.Text = "Future date not allowed "
                txtToDate.Text = ""
            Else
                txtToDate.Text = dt
                If CDate(txtToDate.Text) >= CDate(txtFromDate.Text) Then
                    getMachinedProduct()
                End If
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt = Nothing
        End Try
    End Sub
End Class
