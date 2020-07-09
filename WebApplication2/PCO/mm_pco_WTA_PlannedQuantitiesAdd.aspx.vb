Public Class mm_pco_WTA_PlannedQuantitiesAdd
    Inherits System.Web.UI.Page
    Protected WithEvents ddlProductCode As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtOrderQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtQuantityDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPlanRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents dgData As System.Web.UI.WebControls.DataGrid
    Protected WithEvents ddlWTANumber As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlOrderNumber As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblMode As System.Web.UI.WebControls.Label
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents lblQtyDt As System.Web.UI.WebControls.Label
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
            lblQtyDt.Visible = False
            mode = "add"
            'mode = Request.QueryString("mode")
            lblMode.Text = mode
            viewstate("mode") = mode
            populateGrid()
            GetProdList()
            GetWTANumberList()
            GetWTAOrderList()
        End If
    End Sub
    Private Sub populateGrid()
        dgData.DataSource = PCO.tables.WTA_PlannedQuantities
        dgData.DataBind()
    End Sub
    Private Sub GetProdList()
        Dim dtProductList As DataTable
        dtProductList = PCO.tables.WTA_ProductList
        ddlProductCode.DataSource = dtProductList.DefaultView
        ddlProductCode.DataTextField = dtProductList.Columns(1).ColumnName
        ddlProductCode.DataValueField = dtProductList.Columns(0).ColumnName
        ddlProductCode.DataBind()
        ddlProductCode.Items.Insert(0, New ListItem("select", 0))
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
    Private Sub GetWTANumberList()
        Dim dtNumberList As DataTable
        dtNumberList = PCO.tables.WTA_NumberList
        ddlWTANumber.DataSource = dtNumberList.DefaultView
        ddlWTANumber.DataTextField = dtNumberList.Columns(1).ColumnName
        ddlWTANumber.DataValueField = dtNumberList.Columns(0).ColumnName
        ddlWTANumber.DataBind()
        ddlWTANumber.Items.Insert(0, New ListItem("select", 0))
    End Sub

    Private Sub txtQuantityDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQuantityDate.TextChanged
        lblMessage.Text = ""
        Try
            If ChkDt() Then GetPlannedQuantitiesDetails()
        Catch exp As Exception
            lblMessage.Text = " Please Check Inputs " & exp.Message
        End Try
    End Sub
    Private Function ChkDt() As Boolean
        Dim dt As Date
        Try
            dt = CDate(txtQuantityDate.Text.Trim)
            If dt >= CDate(lblQtyDt.Text) Then
                ChkDt = True
            Else
                ChkDt = False
                Throw New Exception(" or Quantity Date cannot be lesser than Order Date !")
            End If
        Catch exp As Exception
            ChkDt = False
            lblMessage.Text = "Date not in correct format" & exp.Message
        End Try
    End Function
    Private Sub GetPlannedQuantitiesDetails()
        mode = CType(viewstate("mode"), String)
        Try
            If CheckInputs() Then
                CType(viewstate("WTA_PlanQty"), PCO.WTA_PlannedQuantities).PlanProductCode = ddlProductCode.SelectedItem.Value
                CType(viewstate("WTA_PlanQty"), PCO.WTA_PlannedQuantities).PlanWTA_Ref = ddlWTANumber.SelectedItem.Value
                CType(viewstate("WTA_PlanQty"), PCO.WTA_PlannedQuantities).PlanSupplyOrderId = ddlOrderNumber.SelectedItem.Value
                CType(viewstate("WTA_PlanQty"), PCO.WTA_PlannedQuantities).PlanQtyDate = txtQuantityDate.Text.Trim
                CType(viewstate("WTA_PlanQty"), PCO.WTA_PlannedQuantities).GetPlanID(mode)
                txtOrderQty.Text = CType(viewstate("WTA_PlanQty"), PCO.WTA_PlannedQuantities).PlanOrderQty
                txtPlanRemarks.Text = CType(viewstate("WTA_PlanQty"), PCO.WTA_PlannedQuantities).PlanRemarks
            End If
        Catch exp As Exception
            lblMessage.Text = " Please Check Inputs :" & exp.Message
        End Try
    End Sub
    Private Function CheckInputs() As Boolean
        If ddlProductCode.SelectedItem.Text = "select" Then
            lblMessage.Text = " Please select Product Code ! "
            Return False
            Exit Function
        ElseIf ddlWTANumber.SelectedItem.Text = "select" Then
            lblMessage.Text = " Please select WTA Number ! "
            Return False
            Exit Function
        ElseIf ddlOrderNumber.SelectedItem.Text = "select" Then
            lblMessage.Text = " Please select WTA Order Number ! "
            Return False
            Exit Function
        ElseIf txtQuantityDate.Text = "" OrElse ChkDt() = False Then
            lblMessage.Text = " Please provide proper Order Qty Date ! "
            Return False
            Exit Function
        End If
        Return True
    End Function
    Private Sub setValues()
        Try
            ddlProductCode.SelectedIndex = 0
            ddlWTANumber.SelectedIndex = 0
            ddlOrderNumber.SelectedIndex = 0
            txtQuantityDate.Text = ""
            txtOrderQty.Text = ""
            txtPlanRemarks.Text = ""
            lblQtyDt.Text = ""
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        If CheckInputs() Then
            Try
                mode = CType(viewstate("mode"), String)
                CType(viewstate("WTA_PlanQty"), PCO.WTA_PlannedQuantities).PlanProductCode = ddlProductCode.SelectedItem.Value
                CType(viewstate("WTA_PlanQty"), PCO.WTA_PlannedQuantities).PlanWTA_Ref = ddlWTANumber.SelectedItem.Value
                CType(viewstate("WTA_PlanQty"), PCO.WTA_PlannedQuantities).PlanSupplyOrderId = ddlOrderNumber.SelectedItem.Value
                CType(viewstate("WTA_PlanQty"), PCO.WTA_PlannedQuantities).PlanQtyDate = txtQuantityDate.Text.Trim
                CType(viewstate("WTA_PlanQty"), PCO.WTA_PlannedQuantities).PlanOrderQty = txtOrderQty.Text.Trim
                CType(viewstate("WTA_PlanQty"), PCO.WTA_PlannedQuantities).PlanRemarks = txtPlanRemarks.Text.Trim
                CType(viewstate("WTA_PlanQty"), PCO.WTA_PlannedQuantities).Save(IIf(mode = "delete", True, False), 0)
                populateGrid()
                GetProdList()
                GetWTANumberList()
                GetWTAOrderList()
                setValues()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        Else
            lblMessage.Text &= " Please check data before saving ! "
        End If
    End Sub

    Private Sub ddlProductCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlProductCode.SelectedIndexChanged
        lblMessage.Text = ""
        CheckInputs()
    End Sub

    Private Sub ddlWTANumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlWTANumber.SelectedIndexChanged
        lblMessage.Text = ""
        CheckInputs()
    End Sub

    Private Sub ddlOrderNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlOrderNumber.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            If ddlOrderNumber.SelectedItem.Text = "select" Then
                lblMessage.Text = " Please select WTA Order Number ! "
            Else
                GetOrderNumberDetails()
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub GetOrderNumberDetails()
        lblMessage.Text = ""
        Try
            Dim WTA_Order As New PCO.WTA_OrderList()
            WTA_Order.GetSupplyOrdersDetails(ddlOrderNumber.SelectedItem.Value)
            txtQuantityDate.Text = WTA_Order.OrderDate
            lblQtyDt.Text = WTA_Order.OrderDate
            Dim WTA_PlannedQty As New PCO.WTA_PlannedQuantities()
            viewstate("WTA_PlanQty") = WTA_PlannedQty
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtOrderQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOrderQty.TextChanged
        lblMessage.Text = ""
        Try
            txtOrderQty.Text = CInt(txtOrderQty.Text.Trim)
            If txtOrderQty.Text <= 0 Then Throw New Exception(" ( Order Qty cannot be less than 0 ) ")
        Catch exp As Exception
            lblMessage.Text = " Check Order Qty Value : " & txtOrderQty.Text.Trim & exp.Message
            txtOrderQty.Text = ""
        End Try
    End Sub
End Class
