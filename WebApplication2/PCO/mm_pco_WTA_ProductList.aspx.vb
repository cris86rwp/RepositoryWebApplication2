Public Class mm_pco_WTA_ProductList
    Inherits System.Web.UI.Page
    Protected WithEvents lblMode As System.Web.UI.WebControls.Label
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents ddlProductCodes As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlProductList As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtRWFDrg As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCustomerDrg As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Dim strMode As String
    Protected WithEvents lblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents dgData As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Dim mode As String
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
        If Page.IsPostBack = False Then
            'strMode = "add"
            'strMode = "edit"
            'strMode = "delete"
            'strMode = "view"
            strMode = Request.QueryString("mode")
            ddlProductCodes.Visible = False
            ddlProductList.Visible = False
            lblHeading.Visible = False
            viewstate("mode") = strMode
            lblMode.Text = strMode
            populateGrid()
            If strMode = "edit" Or strMode = "delete" Then
                GetProdList()
                ddlProductList.Visible = True
                ddlProductCodes.DataSource = Nothing
                ddlProductCodes.DataBind()
                ddlProductCodes.Visible = False
            ElseIf strMode = "add" Then
                lblHeading.Visible = True
                GetProdCodes()
                ddlProductCodes.Visible = True
                ddlProductList.DataSource = Nothing
                ddlProductList.DataBind()
                ddlProductList.Visible = False
            ElseIf strMode = "view" Then
                Panel1.Visible = False
                populateGrid()
            End If
        End If
    End Sub
    Private Sub populateGrid()
        dgData.DataSource = PCO.tables.WTA_ProductList
        dgData.DataBind()
    End Sub
    Private Sub GetProdList()
        Dim dtProductList As DataTable
        dtProductList = PCO.tables.WTA_ProductList
        ddlProductList.DataSource = dtProductList.DefaultView
        ddlProductList.DataTextField = dtProductList.Columns(1).ColumnName
        ddlProductList.DataValueField = dtProductList.Columns(0).ColumnName
        ddlProductList.DataBind()
        ddlProductList.Items.Insert(0, New ListItem("select", 0))
    End Sub
    Private Sub GetProdCodes()
        Dim dtProductCode As DataTable
        Try
            dtProductCode = PCO.tables.ProductMasterList
            ddlProductCodes.DataSource = dtProductCode.DefaultView
            ddlProductCodes.DataTextField = dtProductCode.Columns(1).ColumnName
            ddlProductCodes.DataValueField = dtProductCode.Columns(0).ColumnName
            ddlProductCodes.DataBind()
            ddlProductCodes.Items.Insert(0, New ListItem("select", 0))
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub ddlProductList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlProductList.SelectedIndexChanged
        lblMessage.Text = ""
        txtRWFDrg.Text = ""
        txtCustomerDrg.Text = ""
        mode = CType(viewstate("mode"), String)
        If mode = "edit" Or mode = "delete" Then
            If ddlProductList.SelectedItem.Text = "select" Then
                lblMessage.Text = " Please select Product Code "
                Exit Sub
            Else
                Try
                    Dim WTA_Prod As New PCO.WTA_ProductList()
                    viewstate("WTAProd") = WTA_Prod
                    WTA_Prod.GetWTAProdDetails(ddlProductList.SelectedItem.Value.Trim)
                    txtRWFDrg.Text = WTA_Prod.RWFDrawing
                    txtCustomerDrg.Text = WTA_Prod.CustomerDrawing
                Catch exp As Exception
                    lblMessage.Text = exp.Message
                End Try
            End If
        End If
    End Sub
    Private Sub ddlProductCodes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlProductCodes.SelectedIndexChanged
        lblMessage.Text = ""
        txtRWFDrg.Text = ""
        txtCustomerDrg.Text = ""
        mode = CType(viewstate("mode"), String)
        If mode = "add" Then
            If ddlProductCodes.SelectedItem.Text = "select" Then
                lblMessage.Text = " Please select Product Code "
                Exit Sub
            Else
                Try
                    Dim WTA_Prod As New PCO.WTA_ProductList()
                    viewstate("WTAProd") = WTA_Prod
                    WTA_Prod.GetProdDrg(ddlProductCodes.SelectedItem.Value.Trim)
                    txtRWFDrg.Text = WTA_Prod.RWFDrawing
                    txtCustomerDrg.Text = WTA_Prod.CustomerDrawing
                Catch exp As Exception
                    lblMessage.Text = exp.Message
                End Try
            End If
        End If
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        mode = CType(viewstate("mode"), String)
        Dim Save As Boolean
        If mode = "add" Then
            If ddlProductCodes.SelectedItem.Text = "select" Then
                lblMessage.Text = " Please select Product Code "
                Exit Sub
            Else
                Save = SaveWTAProduct(mode)
            End If
        ElseIf mode = "edit" Or mode = "delete" Then
            If ddlProductList.SelectedItem.Text = "select" Then
                lblMessage.Text = " Please select Product Code "
                Exit Sub
            Else
                Save = SaveWTAProduct(mode)
            End If
        End If
        If Save = True Then
            lblMessage.Text = " Data Saved ! "
        Else
            lblMessage.Text = " Data Saving error " & lblMessage.Text
        End If
    End Sub
    Private Function SaveWTAProduct(ByVal mode As String) As Boolean
        Dim blnSave As Boolean
        Try
            If mode = "add" Then
                CType(viewstate("WTAProd"), PCO.WTA_ProductList).ProductCode = ddlProductCodes.SelectedItem.Value.Trim
            Else
                CType(viewstate("WTAProd"), PCO.WTA_ProductList).ProductCode = ddlProductList.SelectedItem.Value.Trim
            End If
            CType(viewstate("WTAProd"), PCO.WTA_ProductList).RWFDrawing = txtRWFDrg.Text.Trim.ToUpper
            CType(viewstate("WTAProd"), PCO.WTA_ProductList).CustomerDrawing = txtCustomerDrg.Text.Trim.ToUpper
            CType(viewstate("WTAProd"), PCO.WTA_ProductList).Save(IIf(mode = "delete", True, False))
            If mode = "add" Then
                GetProdCodes()
                ddlProductCodes.ClearSelection()
                ddlProductCodes.SelectedIndex = 0
            Else
                GetProdList()
                ddlProductList.ClearSelection()
                ddlProductList.SelectedIndex = 0
            End If
            populateGrid()
            txtRWFDrg.Text = ""
            txtCustomerDrg.Text = ""
            blnSave = True
        Catch exp As Exception
            blnSave = False
            lblMessage.Text = exp.Message
        End Try
        Return blnSave
    End Function
End Class
