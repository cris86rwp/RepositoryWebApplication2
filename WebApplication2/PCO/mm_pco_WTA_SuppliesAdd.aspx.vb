Public Class mm_pco_WTA_SuppliesAdd
    Inherits System.Web.UI.Page
    Protected WithEvents ddlProductCode As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlWTANumber As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlOrderNumber As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtQuantityDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtOrderQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents lblMode As System.Web.UI.WebControls.Label
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents lblPlanID As System.Web.UI.WebControls.Label
    Protected WithEvents ddlConsigneeCode As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtOrderedQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSupplyRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents dgPlanDetails As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgData As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtOrderedPONumber As System.Web.UI.WebControls.TextBox
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
            lblPlanID.Visible = False
            ddlProductCode.Enabled = False
            ddlWTANumber.Enabled = False
            ddlOrderNumber.Enabled = False
            txtQuantityDate.Enabled = False
            txtOrderQty.Enabled = False
            mode = "add"
            'mode = Request.QueryString("mode")
            lblMode.Text = mode
            populatePlanGrid()
            'populateDataGrid()
            GetConsigneeCodes()
            GetProdList()
            GetWTAOrderList()
            GetWTANumberList()
        End If
    End Sub
    Private Sub GetConsigneeCodes()
        Dim dtConsineeList As DataTable
        dtConsineeList = PCO.tables.ConsigneeList
        ddlConsigneeCode.DataSource = dtConsineeList
        ddlConsigneeCode.DataTextField = dtConsineeList.Columns(1).ColumnName
        ddlConsigneeCode.DataValueField = dtConsineeList.Columns(0).ColumnName
        ddlConsigneeCode.DataBind()
        ddlConsigneeCode.Items.Insert(0, New ListItem("select", 0))
        ddlConsigneeCode.ClearSelection()
        ddlConsigneeCode.SelectedIndex = 0
    End Sub
    Private Sub populatePlanGrid()
        Dim dtSuppliesPlan As DataTable
        dtSuppliesPlan = PCO.tables.WTA_SuppliesPlan
        dgPlanDetails.DataSource = dtSuppliesPlan
        dgPlanDetails.DataBind()
    End Sub
    Private Sub populateDataGrid(Optional ByVal planID As Long = 0)
        CType(viewstate("WTA_Supplies"), PCO.WTA_PlannedSupplies).SupplyPlanId = planID
        dgData.DataSource = CType(viewstate("WTA_Supplies"), PCO.WTA_PlannedSupplies).GetSupplyConsigneeList
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
    Private Sub setValues()
        Try
            ddlProductCode.SelectedIndex = 0
            ddlWTANumber.SelectedIndex = 0
            ddlOrderNumber.SelectedIndex = 0
            txtQuantityDate.Text = ""
            txtOrderQty.Text = ""
            txtOrderedQty.Text = ""
            txtSupplyRemarks.Text = ""
            lblPlanID.Text = ""
            dgData.DataSource = Nothing
            dgData.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub dgPlanDetails_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgPlanDetails.ItemCommand
        lblMessage.Text = ""
        setValues()
        Dim blnselected As Boolean
        Try
            lblPlanID.Text = e.Item.Cells(1).Text
            viewstate("SelectedId") = lblPlanID.Text
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
            txtQuantityDate.Text = e.Item.Cells(7).Text
            txtOrderQty.Text = e.Item.Cells(8).Text
            If Not IsDBNull(e.Item.Cells(9).Text) Then
                ddlOrderNumber.ClearSelection()
                Dim i As Integer = 0
                For i = 0 To ddlOrderNumber.Items.Count - 1
                    If ddlOrderNumber.Items(i).Value = CStr(e.Item.Cells(9).Text) Then
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
            If Not IsDBNull(e.Item.Cells(10).Text) Then
                ddlWTANumber.ClearSelection()
                Dim i As Integer = 0
                For i = 0 To ddlWTANumber.Items.Count - 1
                    If ddlWTANumber.Items(i).Value = CStr(e.Item.Cells(10).Text) Then
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

            Dim WTA_Supplies As New PCO.WTA_PlannedSupplies()
            viewstate("WTA_Supplies") = WTA_Supplies
            WTA_Supplies.SupplyPlanId = lblPlanID.Text
            WTA_Supplies.OrderQty = txtOrderQty.Text
            populateConsigneeCode()
            populateDataGrid(lblPlanID.Text)
        Catch exp As Exception
            lblMessage.Text = " Error in selected PlanID : " & exp.Message
        End Try
    End Sub
    Private Sub populateConsigneeCode()
        ddlConsigneeCode.DataSource = Nothing
        ddlConsigneeCode.DataBind()
        CType(viewstate("WTA_Supplies"), PCO.WTA_PlannedSupplies).SupplyPlanId = lblPlanID.Text
        Dim dtConsig As DataTable
        dtConsig = CType(viewstate("WTA_Supplies"), PCO.WTA_PlannedSupplies).GetConsigneeCodes()
        ddlConsigneeCode.DataSource = dtConsig
        ddlConsigneeCode.DataTextField = dtConsig.Columns(1).ColumnName
        ddlConsigneeCode.DataValueField = dtConsig.Columns(0).ColumnName
        ddlConsigneeCode.DataBind()
        ddlConsigneeCode.Items.Insert(0, New ListItem("select", 0))
        ddlConsigneeCode.ClearSelection()
        ddlConsigneeCode.SelectedIndex = 0
    End Sub

    Private Sub txtOrderedQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOrderedQty.TextChanged
        lblMessage.Text = ""
        ChkQty()
    End Sub
    Private Function ChkPlan() As Boolean
        If Not ddlProductCode.SelectedIndex = 0 OrElse ddlWTANumber.SelectedIndex = 0 OrElse ddlOrderNumber.SelectedIndex = 0 OrElse ddlConsigneeCode.SelectedIndex = 0 OrElse txtQuantityDate.Text = "" OrElse txtOrderQty.Text = "" Then ChkPlan = True
    End Function
    Private Function ChkQty() As Boolean
        Try
            txtOrderedQty.Text = CInt(txtOrderedQty.Text.Trim)
            If txtOrderedQty.Text <= 0 Then Throw New Exception("  ( Ordered Qty cannot be less than 0 ) ")
            CType(viewstate("WTA_Supplies"), PCO.WTA_PlannedSupplies).SupplyPlanId = lblPlanID.Text
            CType(viewstate("WTA_Supplies"), PCO.WTA_PlannedSupplies).SupplyConsigneeCode = ddlConsigneeCode.SelectedItem.Value
            CType(viewstate("WTA_Supplies"), PCO.WTA_PlannedSupplies).OrderQty = txtOrderQty.Text
            CType(viewstate("WTA_Supplies"), PCO.WTA_PlannedSupplies).OrderedQty = txtOrderedQty.Text
            ChkQty = True
        Catch exp As Exception
            lblMessage.Text = " Check Ordered Qty Value : " & txtOrderedQty.Text.Trim & " ; " & exp.Message
            txtOrderedQty.Text = ""
            ChkQty = False
        End Try
    End Function
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        If ChkQty() = True AndAlso ChkPlan() = True Then
            Try
                CType(viewstate("WTA_Supplies"), PCO.WTA_PlannedSupplies).SupplyPlanId = lblPlanID.Text
                CType(viewstate("WTA_Supplies"), PCO.WTA_PlannedSupplies).SupplyConsigneeCode = ddlConsigneeCode.SelectedItem.Value
                CType(viewstate("WTA_Supplies"), PCO.WTA_PlannedSupplies).OrderedQty = txtOrderedQty.Text
                CType(viewstate("WTA_Supplies"), PCO.WTA_PlannedSupplies).PONumber = txtOrderedPONumber.Text.Trim
                CType(viewstate("WTA_Supplies"), PCO.WTA_PlannedSupplies).SupplyRemarks = txtSupplyRemarks.Text.Trim
                CType(viewstate("WTA_Supplies"), PCO.WTA_PlannedSupplies).Save(False)
                populateDataGrid(lblPlanID.Text)
                populateConsigneeCode()
                txtOrderedQty.Text = ""
                txtSupplyRemarks.Text = ""
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        Else
            lblMessage.Text &= " Check Data before Saving ! "
        End If
    End Sub

End Class
