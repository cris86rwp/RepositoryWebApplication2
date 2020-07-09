Public Class mm_pco_WTA_SuppliesEdit
    Inherits System.Web.UI.Page
    Protected WithEvents lblMode As System.Web.UI.WebControls.Label
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents dgPlanDetails As System.Web.UI.WebControls.DataGrid
    Protected WithEvents ddlProductCode As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblPlanID As System.Web.UI.WebControls.Label
    Protected WithEvents ddlWTANumber As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlOrderNumber As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtQuantityDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtOrderQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlConsigneeCode As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtOrderedQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSupplyRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents dgData As System.Web.UI.WebControls.DataGrid
    Protected WithEvents pnlPlan As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlConsignee As System.Web.UI.WebControls.Panel
    Protected WithEvents btnChange As System.Web.UI.WebControls.Button
    Protected WithEvents lblSupplyID As System.Web.UI.WebControls.Label
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
            lblSupplyID.Visible = False
            lblPlanID.Visible = False
            lblPlanID.Text = 0
            ddlProductCode.Enabled = False
            ddlWTANumber.Enabled = False
            ddlOrderNumber.Enabled = False
            txtQuantityDate.Enabled = False
            txtOrderQty.Enabled = False
            pnlPlan.Visible = True
            pnlConsignee.Visible = True
            mode = "edit"
            'mode = Request.QueryString("mode")
            lblMode.Text = mode
            Dim WTA_Supplies As New PCO.WTA_PlannedSupplies()
            viewstate("WTA_Supplies") = WTA_Supplies
            populatePlanGrid()
            populateConsigneeCode()
            GetProdList()
            GetWTAOrderList()
            GetWTANumberList()
        End If
    End Sub
    Private Sub populatePlanGrid(Optional ByVal planID As Long = 0)
        dgPlanDetails.DataSource = Nothing
        dgPlanDetails.DataBind()
        dgPlanDetails.DataSource = CType(viewstate("WTA_Supplies"), PCO.WTA_PlannedSupplies).GetSupplyPlanList(planID)
        dgPlanDetails.DataBind()
    End Sub
    Private Sub populateDataGrid(Optional ByVal planID As Long = 0)
        CType(viewstate("WTA_Supplies"), PCO.WTA_PlannedSupplies).SupplyPlanId = planID
        dgData.DataSource = CType(viewstate("WTA_Supplies"), PCO.WTA_PlannedSupplies).GetSupplyConsigneeList
        dgData.DataBind()
        dgData.Visible = CType(viewstate("WTA_Supplies"), PCO.WTA_PlannedSupplies).GetSupplyConsigneeList.Rows.Count > 0
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
            lblSupplyID.Text = ""
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
            pnlConsignee.Visible = True
            lblPlanID.Text = e.Item.Cells(1).Text
            viewstate("SelectedId") = lblPlanID.Text
            If Not IsDBNull(e.Item.Cells(2).Text) Then
                ddlProductCode.ClearSelection()
                Dim i As Integer = 0
                For i = 0 To ddlProductCode.Items.Count - 1
                    If ddlProductCode.Items(i).Value.Trim = CStr(e.Item.Cells(2).Text) Then
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
                    If ddlOrderNumber.Items(i).Value.Trim = CStr(e.Item.Cells(9).Text) Then
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
                    If ddlWTANumber.Items(i).Value.Trim = CStr(e.Item.Cells(10).Text) Then
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
            CType(viewstate("WTA_Supplies"), PCO.WTA_PlannedSupplies).SupplyPlanId = lblPlanID.Text
            CType(viewstate("WTA_Supplies"), PCO.WTA_PlannedSupplies).OrderQty = txtOrderQty.Text
            populateConsigneeCode()
            populatePlanGrid(lblPlanID.Text)
            populateDataGrid(lblPlanID.Text)
        Catch exp As Exception
            lblMessage.Text = " Error in selected PlanID : " & exp.Message
        End Try
    End Sub
    Private Sub populateConsigneeCode(Optional ByVal supplyID As Long = 0)
        ddlConsigneeCode.DataSource = Nothing
        ddlConsigneeCode.DataBind()
        Dim dtConsig As DataTable
        CType(viewstate("WTA_Supplies"), PCO.WTA_PlannedSupplies).SupplyID = supplyID
        CType(viewstate("WTA_Supplies"), PCO.WTA_PlannedSupplies).SupplyPlanId = lblPlanID.Text
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
        Dim btnSave As Boolean
        If ChkQty() = True Then
            Try
                CType(viewstate("WTA_Supplies"), PCO.WTA_PlannedSupplies).SupplyID = lblSupplyID.Text
                CType(viewstate("WTA_Supplies"), PCO.WTA_PlannedSupplies).SupplyPlanId = lblPlanID.Text
                CType(viewstate("WTA_Supplies"), PCO.WTA_PlannedSupplies).SupplyConsigneeCode = ddlConsigneeCode.SelectedItem.Value
                CType(viewstate("WTA_Supplies"), PCO.WTA_PlannedSupplies).OrderedQty = txtOrderedQty.Text
                CType(viewstate("WTA_Supplies"), PCO.WTA_PlannedSupplies).PONumber = txtOrderedPONumber.Text.Trim
                CType(viewstate("WTA_Supplies"), PCO.WTA_PlannedSupplies).SupplyRemarks = txtSupplyRemarks.Text.Trim
                btnSave = CType(viewstate("WTA_Supplies"), PCO.WTA_PlannedSupplies).Save(False)
                populateDataGrid(lblPlanID.Text)
                populateConsigneeCode()
                txtOrderedQty.Text = ""
                txtSupplyRemarks.Text = ""
                lblSupplyID.Text = ""
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
            If btnSave Then
                lblMessage.Text &= " Data Saved ! "
            Else
                lblMessage.Text &= " Data Not Saved ! "
            End If
        Else
            lblMessage.Text &= " Check Data before Saving ! "
        End If
    End Sub

    Private Sub btnChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChange.Click
        lblMessage.Text = ""
        Try
            pnlConsignee.Visible = False
            ddlConsigneeCode.DataSource = Nothing
            ddlConsigneeCode.DataBind()
            txtOrderedQty.Text = ""
            txtSupplyRemarks.Text = ""
            populatePlanGrid()
            populateDataGrid()
        Catch exp As Exception
        End Try
    End Sub

    Private Sub dgData_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgData.ItemCommand
        lblMessage.Text = ""
        Dim blnselected As Boolean
        Try
            lblSupplyID.Text = e.Item.Cells(1).Text
            populateConsigneeCode(lblSupplyID.Text)
            If Not IsDBNull(e.Item.Cells(3).Text) Then
                ddlConsigneeCode.ClearSelection()
                Dim i As Integer = 0
                For i = 0 To ddlConsigneeCode.Items.Count - 1
                    If ddlConsigneeCode.Items(i).Value.Trim = CStr(e.Item.Cells(3).Text) Then
                        ddlConsigneeCode.Items(i).Selected = True
                        blnselected = True
                        Exit For
                    End If
                Next
                If blnselected = False Then
                    ddlConsigneeCode.Items(0).Selected = True
                End If
                blnselected = False
            End If
            txtOrderedQty.Text = e.Item.Cells(5).Text
            txtOrderedPONumber.Text = e.Item.Cells(6).Text
            txtSupplyRemarks.Text = e.Item.Cells(7).Text.Replace("&nbsp;", "")
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

End Class
