Public Class mm_pco_WTA_SupplyOrdersView
    Inherits System.Web.UI.Page
    Protected WithEvents ddlOrderNumber As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblMode As System.Web.UI.WebControls.Label
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents txtOrderNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtOrderDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtOrderedBy As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtOrderType As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents dgData As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblOrderNumber As System.Web.UI.WebControls.Label
    Dim strMode As String
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
            lblOrderNumber.Visible = False
            ddlOrderNumber.Visible = False
            'strMode = "add"
            'strMode = "edit"
            'strMode = "delete"
            strMode = "view"
            'strMode = Request.QueryString("mode")
            ViewState("mode") = strMode
            lblMode.Text = strMode
            populateGrid()
            If strMode = "edit" Or strMode = "delete" Then
                GetWTAOrderList()
                lblOrderNumber.Visible = True
                ddlOrderNumber.Visible = True
            ElseIf strMode = "add" Then
                lblOrderNumber.Visible = False
                ddlOrderNumber.Visible = False
            ElseIf strMode = "view" Then
                Panel1.Visible = False
                populateGrid()
            End If
        End If
    End Sub
    Private Sub populateGrid()
        dgData.DataSource = PCO.tables.WTA_SupplyOrdersList
        dgData.DataBind()
    End Sub
    Private Sub GetWTAOrderList()
        Dim dtOrderList As DataTable
        dtOrderList = PCO.tables.WTA_SupplyOrdersList
        ddlOrderNumber.DataSource = dtOrderList.DefaultView
        ddlOrderNumber.DataTextField = dtOrderList.Columns(1).ColumnName
        ddlOrderNumber.DataValueField = dtOrderList.Columns(0).ColumnName
        ddlOrderNumber.DataBind()
        ddlOrderNumber.Items.Insert(0, New ListItem("select", 0))
    End Sub

    Private Sub txtOrderNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOrderNumber.TextChanged
        mode = CType(ViewState("mode"), String)
        If mode = "add" Then
            If txtOrderNumber.Text = "" Then
                lblMessage.Text = " Please enter Order Number "
                Exit Sub
            Else
                Dim WTA_Order As New PCO.WTA_OrderList()
                ViewState("WTAOrder") = WTA_Order
            End If
        End If
    End Sub

    Private Sub txtOrderDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOrderDate.TextChanged
        lblMessage.Text = ""
        Dim dt As Date
        Try
            dt = CDate(txtOrderDate.Text.Trim)
        Catch exp As Exception
            lblMessage.Text = "Date not in correct format"
        End Try
    End Sub

    Private Sub ddlOrderNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlOrderNumber.SelectedIndexChanged
        lblMessage.Text = ""
        txtOrderNumber.Text = ""
        txtOrderDate.Text = ""
        txtOrderedBy.Text = ""
        txtOrderType.Text = ""
        txtRemarks.Text = ""
        mode = CType(ViewState("mode"), String)
        If mode = "edit" Or mode = "delete" Then
            If ddlOrderNumber.SelectedItem.Text = "select" Then
                lblMessage.Text = " Please select Order Number "
                Exit Sub
            Else
                Try
                    Dim WTA_Order As New PCO.WTA_OrderList()
                    ViewState("WTAOrder") = WTA_Order
                    WTA_Order.GetSupplyOrdersDetails(ddlOrderNumber.SelectedItem.Value.Trim)
                    txtOrderNumber.Text = WTA_Order.OrderNumber
                    txtOrderDate.Text = WTA_Order.OrderDate
                    txtOrderedBy.Text = WTA_Order.OrderedBy
                    txtOrderType.Text = WTA_Order.OrderType
                    txtRemarks.Text = WTA_Order.SupplyOrdersRemarks
                Catch exp As Exception
                    lblMessage.Text = exp.Message
                End Try
            End If
        End If
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        mode = CType(ViewState("mode"), String)
        Dim Save As Boolean
        If mode = "add" Then
            If txtOrderNumber.Text = "" Then
                lblMessage.Text = " Please enter Order Number "
                Exit Sub
            Else
                Save = SaveWTAOrderNumber(mode)
            End If
        ElseIf mode = "edit" Or mode = "delete" Then
            If ddlOrderNumber.SelectedItem.Text = "select" Then
                lblMessage.Text = " Please select Order Number ! "
                Exit Sub
            Else
                Save = SaveWTAOrderNumber(mode)
            End If
        End If
        If Save = True Then
            lblMessage.Text = " Data Saved ! "
        Else
            lblMessage.Text = " Data Saving error " & lblMessage.Text
        End If
    End Sub
    Private Function SaveWTAOrderNumber(ByVal mode As String) As Boolean
        Dim blnSave As Boolean
        Try
            CType(ViewState("WTAOrder"), PCO.WTA_OrderList).OrderNumber = txtOrderNumber.Text
            CType(ViewState("WTAOrder"), PCO.WTA_OrderList).OrderDate = txtOrderDate.Text
            CType(ViewState("WTAOrder"), PCO.WTA_OrderList).OrderedBy = txtOrderedBy.Text
            CType(ViewState("WTAOrder"), PCO.WTA_OrderList).OrderType = txtOrderType.Text
            CType(ViewState("WTAOrder"), PCO.WTA_OrderList).SupplyOrdersRemarks = txtRemarks.Text
            If mode = "add" Then
                CType(ViewState("WTAOrder"), PCO.WTA_OrderList).Save(IIf(mode = "delete", True, False), 0)
                ddlOrderNumber.ClearSelection()
                ddlOrderNumber.SelectedIndex = 0
            Else
                CType(ViewState("WTAOrder"), PCO.WTA_OrderList).Save(IIf(mode = "delete", True, False), ddlOrderNumber.SelectedItem.Value)
                GetWTAOrderList()
                ddlOrderNumber.ClearSelection()
                ddlOrderNumber.SelectedIndex = 0
            End If
            populateGrid()
            txtOrderNumber.Text = ""
            txtOrderDate.Text = "01/01/1900"
            txtOrderedBy.Text = ""
            txtOrderType.Text = ""
            txtRemarks.Text = ""
            blnSave = True
        Catch exp As Exception
            blnSave = False
            lblMessage.Text = exp.Message
        End Try
        Return blnSave
    End Function
End Class
