Public Class mm_pco_WTA_PlannedQuantitiesView
    Inherits System.Web.UI.Page
    Protected WithEvents lblMode As System.Web.UI.WebControls.Label
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents ddlProductCode As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlWTANumber As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlOrderNumber As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtQuantityDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblQtyDt As System.Web.UI.WebControls.Label
    Protected WithEvents txtOrderQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPlanRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents dgData As System.Web.UI.WebControls.DataGrid
    Dim mode As String
    Dim SelectedPlanID As Boolean
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
        Panel1.Visible = False
        If Page.IsPostBack = False Then
            lblQtyDt.Visible = False
            ddlProductCode.Enabled = False
            ddlOrderNumber.Enabled = False
            ddlWTANumber.Enabled = False
            txtQuantityDate.Enabled = False
            txtOrderQty.Enabled = False
            txtPlanRemarks.Enabled = False
            mode = "view"
            'mode = Request.QueryString("mode")
            lblMode.Text = mode
            ViewState("mode") = mode
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
        ddlProductCode.ClearSelection()
        ddlProductCode.SelectedIndex = 0
    End Sub
    Private Sub GetWTAOrderList()
        Dim dtOrderList As DataTable
        dtOrderList = PCO.tables.WTA_SupplyOrdersList
        ddlOrderNumber.DataSource = dtOrderList.DefaultView
        ddlOrderNumber.DataTextField = dtOrderList.Columns(1).ColumnName
        ddlOrderNumber.DataValueField = dtOrderList.Columns(0).ColumnName
        ddlOrderNumber.DataBind()
        ddlOrderNumber.Items.Insert(0, New ListItem("select", 0))
        ddlOrderNumber.ClearSelection()
        ddlOrderNumber.SelectedIndex = 0
    End Sub
    Private Sub GetWTANumberList()
        Dim dtNumberList As DataTable
        dtNumberList = PCO.tables.WTA_NumberList
        ddlWTANumber.DataSource = dtNumberList.DefaultView
        ddlWTANumber.DataTextField = dtNumberList.Columns(1).ColumnName
        ddlWTANumber.DataValueField = dtNumberList.Columns(0).ColumnName
        ddlWTANumber.DataBind()
        ddlWTANumber.Items.Insert(0, New ListItem("select", 0))
        ddlWTANumber.ClearSelection()
        ddlWTANumber.SelectedIndex = 0
    End Sub
    Private Sub txtQuantityDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQuantityDate.TextChanged
        lblMessage.Text = ""
        ChkDt()
    End Sub
    Private Function ChkDt() As Boolean
        Dim dt As Date
        Try
            dt = CDate(txtQuantityDate.Text.Trim)
            Dim WTA_Order As New PCO.WTA_OrderList()
            WTA_Order.GetSupplyOrdersDetails(ddlOrderNumber.SelectedItem.Value)
            lblQtyDt.Text = WTA_Order.OrderDate
            If dt < CDate(lblQtyDt.Text) Then Throw New Exception(" or Quantity Date cannot be lesser than Order Date !")
            ChkDt = True
        Catch exp As Exception
            lblMessage.Text = "Date not in correct format" & exp.Message
            ChkDt = False
        End Try
    End Function
    Private Sub GetPlannedQuantitiesDetails()
        mode = CType(ViewState("mode"), String)
        Try
            If CheckInputs() Then
                Dim WTA_PlannedQty As New PCO.WTA_PlannedQuantities()
                ViewState("WTA_PlanQty") = WTA_PlannedQty
                WTA_PlannedQty.PlanProductCode = ddlProductCode.SelectedItem.Value
                WTA_PlannedQty.PlanWTA_Ref = ddlWTANumber.SelectedItem.Value
                WTA_PlannedQty.PlanSupplyOrderId = ddlOrderNumber.SelectedItem.Value
                WTA_PlannedQty.PlanQtyDate = txtQuantityDate.Text.Trim
                WTA_PlannedQty.GetPlanID(mode)
                txtOrderQty.Text = WTA_PlannedQty.PlanOrderQty
                txtPlanRemarks.Text = WTA_PlannedQty.PlanRemarks
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
        ElseIf ChkQty() = False Then
            lblMessage.Text = " Please provide proper Order Qty  ! "
            Return False
            Exit Function
        End If
        Dim WTA_PlannedQty As New PCO.WTA_PlannedQuantities()
        ViewState("WTA_PlanQty") = WTA_PlannedQty
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
        SelectedPlanID = CType(ViewState("SelectedId"), Long)
        Dim blnSave As Boolean
        If CheckInputs() Then
            Try
                mode = CType(ViewState("mode"), String)
                CType(ViewState("WTA_PlanQty"), PCO.WTA_PlannedQuantities).PlanProductCode = ddlProductCode.SelectedItem.Value
                CType(ViewState("WTA_PlanQty"), PCO.WTA_PlannedQuantities).PlanWTA_Ref = ddlWTANumber.SelectedItem.Value
                CType(ViewState("WTA_PlanQty"), PCO.WTA_PlannedQuantities).PlanSupplyOrderId = ddlOrderNumber.SelectedItem.Value
                CType(ViewState("WTA_PlanQty"), PCO.WTA_PlannedQuantities).PlanQtyDate = txtQuantityDate.Text.Trim
                CType(ViewState("WTA_PlanQty"), PCO.WTA_PlannedQuantities).PlanOrderQty = txtOrderQty.Text.Trim
                CType(ViewState("WTA_PlanQty"), PCO.WTA_PlannedQuantities).PlanRemarks = txtPlanRemarks.Text.Trim
                CType(ViewState("WTA_PlanQty"), PCO.WTA_PlannedQuantities).Save(IIf(mode = "delete", True, False), SelectedPlanID)
                populateGrid()
                setValues()
                blnSave = True
            Catch exp As Exception
                lblMessage.Text = exp.Message
                blnSave = False
            End Try
        Else
            lblMessage.Text &= " Please check Inputs ! "
        End If
        If blnSave Then lblMessage.Text = " Data Saved ! "
    End Sub
    Private Sub txtOrderQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOrderQty.TextChanged
        lblMessage.Text = ""
        ChkQty()
    End Sub
    Private Function ChkQty() As Boolean
        Try
            txtOrderQty.Text = CInt(txtOrderQty.Text.Trim)
            If txtOrderQty.Text <= 0 Then Throw New Exception("  ( Order Qty cannot be less than 0 ) ")
            ChkQty = True
        Catch exp As Exception
            lblMessage.Text = " Check Order Qty Value : " & txtOrderQty.Text.Trim & exp.Message
            txtOrderQty.Text = ""
            ChkQty = False
        End Try
    End Function
    Private Sub dgData_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgData.ItemCommand
        lblMessage.Text = ""
        Dim blnselected As Boolean
        Try
            SelectedPlanID = e.Item.Cells(1).Text
            ViewState("SelectedId") = SelectedPlanID
            If Not IsDBNull(e.Item.Cells(2).Text) Then
                ddlProductCode.ClearSelection()
                Dim i As Integer = 0
                For i = 0 To ddlProductCode.Items.Count - 1
                    If ddlProductCode.Items(i).Value = CStr(e.Item.Cells(2).Text) Then
                        ddlProductCode.Items(i).Selected = True
                        blnselected = True
                        Exit For
                    End If
                Next
                If blnselected = False Then
                    ddlProductCode.Items(0).Selected = True
                End If
                blnselected = False
            End If
            txtQuantityDate.Text = e.Item.Cells(8).Text
            txtOrderQty.Text = e.Item.Cells(9).Text
            txtPlanRemarks.Text = e.Item.Cells(10).Text
            If Not IsDBNull(e.Item.Cells(11).Text) Then
                ddlOrderNumber.ClearSelection()
                Dim i As Integer = 0
                For i = 0 To ddlOrderNumber.Items.Count - 1
                    If ddlOrderNumber.Items(i).Value = CStr(e.Item.Cells(11).Text) Then
                        ddlOrderNumber.Items(i).Selected = True
                        blnselected = True
                        Exit For
                    End If
                Next
                If blnselected = False Then
                    ddlOrderNumber.Items(0).Selected = True
                End If
                blnselected = False
            End If
            If Not IsDBNull(e.Item.Cells(12).Text) Then
                ddlWTANumber.ClearSelection()
                Dim i As Integer = 0
                For i = 0 To ddlWTANumber.Items.Count - 1
                    If ddlWTANumber.Items(i).Value = CStr(e.Item.Cells(12).Text) Then
                        ddlWTANumber.Items(i).Selected = True
                        blnselected = True
                        Exit For
                    End If
                Next
                If blnselected = False Then
                    ddlWTANumber.Items(0).Selected = True
                End If
                blnselected = False
            End If
        Catch exp As Exception
            lblMessage.Text = " Error in selected PlanID : " & exp.Message
        End Try
    End Sub
End Class
