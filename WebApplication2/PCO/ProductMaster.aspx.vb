Public Class ProductMaster
    Inherits System.Web.UI.Page
    Protected WithEvents rblProduct As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents ddlProductService As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents ddlCondition As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtProductCode As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDrawing As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDescription As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTransferQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtProdwtg As System.Web.UI.WebControls.TextBox
    Protected WithEvents RangeValidator5 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents txtScrapPercentage As System.Web.UI.WebControls.TextBox
    Protected WithEvents RangeValidator3 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents txtLossPcnt As System.Web.UI.WebControls.TextBox
    Protected WithEvents RangeValidator2 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents ddlClass As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtSpecification As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTransferPrice As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSalePrice As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRoughWeight As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFinishWeight As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtWTAName As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtcustomer_drawing_number As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlProductNature As System.Web.UI.WebControls.DropDownList
    Protected WithEvents dgProductList As System.Web.UI.WebControls.DataGrid
    Protected WithEvents pnlWheel As System.Web.UI.WebControls.Panel
    Protected WithEvents txtWeightPerWheel As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRejPercent As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMRRejPercent As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMinTreadDia As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMinPlateThk As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSplSizeMin As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSplSizeMax As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMaxPlateThk As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMaxTreadDia As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMinBoreDia As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtOverSizeMin As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMcnMinDia As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtOverSizeMax As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMaxBoreDia As System.Web.UI.WebControls.TextBox
    Protected WithEvents pnlSet As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlAxle As System.Web.UI.WebControls.Panel
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents txtWtAtForge As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMinPr As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMaxPr As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMinGauge As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMaxGauge As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlCastGroup As System.Web.UI.WebControls.DropDownList
    Protected WithEvents rblMake As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtWheelsPerHt As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtLowBHN As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtHighBHN As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlAxle As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlWheel As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtWheelPerMT As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtLongDescription As System.Web.UI.WebControls.TextBox
    Protected WithEvents chkCastGrpAvailable As System.Web.UI.WebControls.CheckBox
    Protected WithEvents ddlR43R16 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents rblSource As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents dgSimilarProducts As System.Web.UI.WebControls.DataGrid
    Protected WithEvents ddlSimilarProds As System.Web.UI.WebControls.DropDownList
    Protected WithEvents chkInputs As System.Web.UI.WebControls.CheckBox
    Protected WithEvents ddlInitialStage As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtFGtoFI As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFGtoRT As System.Web.UI.WebControls.TextBox
    Protected WithEvents pnlStageRT As System.Web.UI.WebControls.Panel
    Protected WithEvents txtRTtoFI As System.Web.UI.WebControls.TextBox
    Protected WithEvents pnlStageFI As System.Web.UI.WebControls.Panel
    Protected WithEvents lblMode As System.Web.UI.WebControls.Label
    Protected WithEvents btnCheckList As System.Web.UI.WebControls.Button
    Protected WithEvents txtMinWhlNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMaxWhlNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSeriesStart As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSereiesEnd As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNRCPrice As System.Web.UI.WebControls.TextBox
    Protected WithEvents pnlMain As System.Web.UI.WebControls.Panel
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
        Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None
        'Put user code to initialize the page here
        lblMode.Visible = False
        If Page.IsPostBack = False Then
            Session("UserID") = "014277"
            Session("Group") = "PCOPCO"

            'Try
            '    Dim oChkEmp As New rwfGen.Employee()
            '    If oChkEmp.Check(Session("UserID"), "PCOPCO") = False Then
            '        Response.Redirect("InvalidSession.aspx")
            '    End If
            '    oChkEmp = Nothing
            'Catch exp As Exception
            '    Response.Redirect("InvalidSession.aspx")
            'End Try
            Try
                setobj()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub

    Private Sub setobj()
        chkInputs.Checked = False
        ddlCastGroup.DataSource = Nothing
        ddlCastGroup.DataBind()
        dgSimilarProducts.DataSource = Nothing
        dgSimilarProducts.DataBind()
        dgProductList.SelectedIndex = -1
        dgProductList.DataSource = Nothing
        dgProductList.DataBind()
        lblMessage.Text = ""
        Session.Remove("PCO")
        txtProductCode.Text = ""
        Dim oProduct As New PCO.Product(rblProduct.SelectedItem.Value, ddlProductNature.SelectedItem.Value, ddlProductService.SelectedItem.Value, ddlCondition.SelectedItem.Value)
        Session("Product") = oProduct
        txtProductCode.Text = CType(Session("Product"), PCO.Product).NewProductCode
        dgProductList.DataSource = CType(Session("Product"), PCO.Product).ProductList
        dgProductList.DataBind()
        SetScreen()
        oProduct = Nothing
    End Sub

    Private Sub Clear()
        txtDrawing.Text = ""
        txtDescription.Text = ""
        txtLongDescription.Text = ""
        txtTransferQty.Text = ""
        txtProdwtg.Text = ""
        txtScrapPercentage.Text = ""
        txtLossPcnt.Text = ""
        txtSpecification.Text = ""
        txtTransferPrice.Text = ""
        txtSalePrice.Text = ""
        txtRoughWeight.Text = ""
        txtFinishWeight.Text = ""
        txtWTAName.Text = ""
        txtcustomer_drawing_number.Text = ""
        lblMode.Text = ""
    End Sub

    Private Sub SetScreen()
        Clear()
        SetPanel()
        If CType(Session("Product"), PCO.Product).Wheel Then
            pnlWheel.Visible = True
        ElseIf CType(Session("Product"), PCO.Product).Axle Then
            lblMessage.Text = ""
            chkInputs.Checked = False
            dgSimilarProducts.DataSource = Nothing
            dgSimilarProducts.DataBind()
            Dim dt As DataTable = CType(Session("Product"), PCO.Product).ExistingCGs
            ddlCastGroup.DataSource = dt
            ddlCastGroup.DataTextField = dt.Columns("Cast_Group").ColumnName
            ddlCastGroup.DataValueField = dt.Columns("Cast_Group").ColumnName
            ddlCastGroup.DataBind()
            dt.Dispose()
            Dim dt1 As DataTable = CType(Session("Product"), PCO.Product).AxleMake
            rblMake.DataSource = dt1
            rblMake.DataTextField = dt1.Columns("Make").ColumnName
            rblMake.DataValueField = dt1.Columns("Make").ColumnName
            rblMake.DataBind()
            rblMake.SelectedIndex = 0
            dt1 = CType(Session("Product"), PCO.Product).SourceList
            rblSource.DataSource = dt1
            rblSource.DataTextField = dt1.Columns("source").ColumnName
            rblSource.DataValueField = dt1.Columns("source").ColumnName
            rblSource.DataBind()
            rblSource.SelectedIndex = 0
            dt1.Dispose()
            pnlAxle.Visible = True
            CType(Session("Product"), PCO.Product).Make = rblMake.SelectedItem.Text.Trim
            CType(Session("Product"), PCO.Product).Source = rblSource.SelectedItem.Text.Trim
            CType(Session("Product"), PCO.Product).CastGroup = ddlCastGroup.SelectedItem.Text.Trim
            Try
                fillValues()
                selectPnls()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
            dt = Nothing
            dt1 = Nothing
        ElseIf CType(Session("Product"), PCO.Product).WheelSet Then
            Dim dt As DataTable = CType(Session("Product"), PCO.Product).GetWheelList
            ddlWheel.DataSource = dt
            ddlWheel.DataTextField = dt.Columns(0).ColumnName
            ddlWheel.DataValueField = dt.Columns(0).ColumnName
            ddlWheel.DataBind()
            ddlWheel.Items.Insert(0, "Select")
            ddlWheel.SelectedIndex = 0
            dt = CType(Session("Product"), PCO.Product).GetAxleList
            ddlAxle.DataSource = dt
            ddlAxle.DataTextField = dt.Columns(0).ColumnName
            ddlAxle.DataValueField = dt.Columns(0).ColumnName
            ddlAxle.DataBind()
            ddlAxle.Items.Insert(0, "Select")
            ddlAxle.SelectedIndex = 0
            dt.Dispose()
            pnlSet.Visible = True
            dt = Nothing
        End If
    End Sub
    Private Sub fillValues()
        Try
            CType(Session("Product"), PCO.Product).NewProductCode = txtProductCode.Text
            SimilarProduct()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub clearPnlData()
        txtHighBHN.Text = ""
        txtLowBHN.Text = ""
        txtWheelsPerHt.Text = ""
        txtWeightPerWheel.Text = ""
        txtRejPercent.Text = ""
        txtSeriesStart.Text = ""
        txtSereiesEnd.Text = ""
        txtMRRejPercent.Text = ""
        txtWheelPerMT.Text = ""
        txtMinTreadDia.Text = ""
        txtMinPlateThk.Text = ""
        txtSplSizeMin.Text = ""
        txtSplSizeMax.Text = ""
        txtMaxPlateThk.Text = ""
        txtMaxTreadDia.Text = ""
        txtMinBoreDia.Text = ""
        txtOverSizeMin.Text = ""
        txtMcnMinDia.Text = ""
        txtOverSizeMax.Text = ""
        txtMaxBoreDia.Text = ""
        txtWtAtForge.Text = ""
        txtMinPr.Text = ""
        txtMaxPr.Text = ""
        txtMinGauge.Text = ""
        txtMaxGauge.Text = ""
    End Sub

    Private Sub SetPanel()
        clearPnlData()
        pnlWheel.Visible = False
        pnlAxle.Visible = False
        pnlSet.Visible = False
    End Sub

    Private Sub rblProduct_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblProduct.SelectedIndexChanged
        Try
            setobj()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    'Private Sub rblProductNature_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblProductNature.SelectedIndexChanged
    'Try
    '       setobj()
    'Catch exp As Exception
    '       lblMessage.Text = exp.Message
    'End Try
    'End Sub

    ' Private Sub rblProductService_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblProductService.SelectedIndexChanged
    'Try
    '       setobj()
    'Catch exp As Exception
    '       lblMessage.Text = exp.Message
    'End Try
    'End Sub

    'Private Sub rblCondition_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblCondition.SelectedIndexChanged
    'Try
    '       setobj()
    'Catch exp As Exception
    '       lblMessage.Text = exp.Message
    'End Try
    'End Sub

    Private Sub dgProductList_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgProductList.ItemCommand
        lblMessage.Text = ""
        lblMode.Text = ""
        ddlCastGroup.Enabled = True
        txtProductCode.Enabled = True
        txtDrawing.Enabled = True
        txtDescription.Enabled = True
        Dim dt As DataTable
        Dim i As Integer = 0
        Try
            If e.CommandName = "Select" Then
                lblMode.Text = "edit"
                dt = PCO.tables.GetProductDetails(e.Item.Cells(1).Text, rblProduct.SelectedItem.Text)
                CType(Session("Product"), PCO.Product).NewProductCode = IIf(IsDBNull(dt.Rows(0)("product_code")), "", dt.Rows(0)("product_code"))
                txtProductCode.Text = CType(Session("Product"), PCO.Product).NewProductCode
                txtDrawing.Text = IIf(IsDBNull(dt.Rows(0)("drawing_number")), "", dt.Rows(0)("drawing_number"))
                txtDescription.Text = IIf(IsDBNull(dt.Rows(0)("descri")), "", dt.Rows(0)("descri"))
                txtProductCode.Enabled = False
                txtDrawing.Enabled = False
                txtDescription.Enabled = False
                txtLongDescription.Text = IIf(IsDBNull(dt.Rows(0)("long_description")), "", dt.Rows(0)("long_description"))
                txtTransferQty.Text = IIf(IsDBNull(dt.Rows(0)("max_quantity")), "", dt.Rows(0)("max_quantity"))
                txtProdwtg.Text = IIf(IsDBNull(dt.Rows(0)("product_weightage")), "", dt.Rows(0)("product_weightage"))
                txtScrapPercentage.Text = IIf(IsDBNull(dt.Rows(0)("scrap_percentage")), "", dt.Rows(0)("scrap_percentage"))
                txtLossPcnt.Text = IIf(IsDBNull(dt.Rows(0)("loss_percentage")), "", dt.Rows(0)("loss_percentage"))
                txtSpecification.Text = IIf(IsDBNull(dt.Rows(0)("specification")), "", dt.Rows(0)("specification"))
                txtTransferPrice.Text = IIf(IsDBNull(dt.Rows(0)("transfer_price")), "", dt.Rows(0)("transfer_price"))
                txtSalePrice.Text = IIf(IsDBNull(dt.Rows(0)("sale_price")), "", dt.Rows(0)("sale_price"))
                txtRoughWeight.Text = IIf(IsDBNull(dt.Rows(0)("rough_weight")), "", dt.Rows(0)("rough_weight"))
                txtFinishWeight.Text = IIf(IsDBNull(dt.Rows(0)("finished_weight")), "", dt.Rows(0)("finished_weight"))
                txtWTAName.Text = IIf(IsDBNull(dt.Rows(0)("WTAName")), "", dt.Rows(0)("WTAName"))
                txtcustomer_drawing_number.Text = IIf(IsDBNull(dt.Rows(0)("customer_drawing_number")), "", dt.Rows(0)("customer_drawing_number"))
                ' rblClass.ClearSelection()
                'For i = 0 To rblClass.Items.Count - 1
                'If rblClass.Items(i).Text = IIf(IsDBNull(dt.Rows(0)("class")), "", dt.Rows(0)("class")) Then
                'rblClass.Items(i).Selected = True
                'Exit For
                ' End If
                '    Next
                ddlClass.ClearSelection()
                For i = 0 To ddlClass.Items.Count - 1
                    If ddlClass.Items(i).Text = IIf(IsDBNull(dt.Rows(0)("class")), "", dt.Rows(0)("class")) Then
                        ddlClass.Items(i).Selected = True
                        Exit For
                    End If
                Next

                txtNRCPrice.Text = IIf(IsDBNull(dt.Rows(0)("axle_size")), 0, dt.Rows(0)("axle_size"))
                If CType(Session("Product"), PCO.Product).Wheel Then
                    txtHighBHN.Text = IIf(IsDBNull(dt.Rows(0)("high_bhn")), "", dt.Rows(0)("high_bhn"))
                    txtLowBHN.Text = IIf(IsDBNull(dt.Rows(0)("low_bhn")), "", dt.Rows(0)("low_bhn"))
                    txtWheelsPerHt.Text = IIf(IsDBNull(dt.Rows(0)("wheels_per_heat")), "", dt.Rows(0)("wheels_per_heat"))
                    txtWeightPerWheel.Text = IIf(IsDBNull(dt.Rows(0)("wt_per_wheel")), "", dt.Rows(0)("wt_per_wheel"))
                    txtRejPercent.Text = IIf(IsDBNull(dt.Rows(0)("rej_percent")), "", dt.Rows(0)("rej_percent"))
                    txtSeriesStart.Text = IIf(IsDBNull(dt.Rows(0)("series_start")), "", dt.Rows(0)("series_start"))
                    txtSereiesEnd.Text = IIf(IsDBNull(dt.Rows(0)("series_end")), "", dt.Rows(0)("series_end"))
                    txtMRRejPercent.Text = IIf(IsDBNull(dt.Rows(0)("MR_Rej_Percent")), "", dt.Rows(0)("MR_Rej_Percent"))
                    txtWheelPerMT.Text = IIf(IsDBNull(dt.Rows(0)("whl_per_MT")), "", dt.Rows(0)("whl_per_MT"))
                    txtMinTreadDia.Text = IIf(IsDBNull(dt.Rows(0)("MinTreadDia")), "", dt.Rows(0)("MinTreadDia"))
                    txtMinPlateThk.Text = IIf(IsDBNull(dt.Rows(0)("MinPlateThickness")), "", dt.Rows(0)("MinPlateThickness"))
                    txtSplSizeMin.Text = IIf(IsDBNull(dt.Rows(0)("SplSizeMin")), "", dt.Rows(0)("SplSizeMin"))
                    txtSplSizeMax.Text = IIf(IsDBNull(dt.Rows(0)("SplSizeMax")), "", dt.Rows(0)("SplSizeMax"))
                    txtMaxPlateThk.Text = IIf(IsDBNull(dt.Rows(0)("MaxPlateThickness")), "", dt.Rows(0)("MaxPlateThickness"))
                    txtMaxTreadDia.Text = IIf(IsDBNull(dt.Rows(0)("MaxTreadDia")), "", dt.Rows(0)("MaxTreadDia"))
                    txtMinBoreDia.Text = IIf(IsDBNull(dt.Rows(0)("MinBoreDia")), "", dt.Rows(0)("MinBoreDia"))
                    txtOverSizeMin.Text = IIf(IsDBNull(dt.Rows(0)("OverSizeMin")), "", dt.Rows(0)("OverSizeMin"))
                    txtMcnMinDia.Text = IIf(IsDBNull(dt.Rows(0)("McnMinDia")), "", dt.Rows(0)("McnMinDia"))
                    txtOverSizeMax.Text = IIf(IsDBNull(dt.Rows(0)("OverSizeMax")), "", dt.Rows(0)("OverSizeMax"))
                    txtMaxBoreDia.Text = IIf(IsDBNull(dt.Rows(0)("MaxBoreDia")), "", dt.Rows(0)("MaxBoreDia"))
                ElseIf CType(Session("Product"), PCO.Product).Axle Then
                    i = 0
                    ddlCastGroup.ClearSelection()
                    For i = 0 To ddlCastGroup.Items.Count - 1
                        If ddlCastGroup.Items(i).Text = IIf(IsDBNull(dt.Rows(0)("cast_group")), "", dt.Rows(0)("cast_group")) Then
                            ddlCastGroup.Items(i).Selected = True
                            Exit For
                        End If
                    Next
                    'txtWtAtForge.Text = IIf(IsDBNull(dt.Rows(0)("product_weightage_at_forge_shop")), "", dt.Rows(0)("product_weightage_at_forge_shop"))
                    'i = 0
                    'rdoR43R16.ClearSelection()
                    'For i = 0 To rdoR43R16.Items.Count - 1
                    '    If rdoR43R16.Items(i).Text = IIf(IsDBNull(dt.Rows(0)("R43R16")), "", dt.Rows(0)("R43R16")) Then
                    '        rdoR43R16.Items(i).Selected = True
                    '        Exit For
                    '    End If
                    txtWtAtForge.Text = IIf(IsDBNull(dt.Rows(0)("product_weightage_at_forge_shop")), "", dt.Rows(0)("product_weightage_at_forge_shop"))
                    i = 0
                    ddlR43R16.ClearSelection()
                    For i = 0 To ddlR43R16.Items.Count - 1
                        If ddlR43R16.Items(i).Text = IIf(IsDBNull(dt.Rows(0)("R43R16")), "", dt.Rows(0)("R43R16")) Then
                            ddlR43R16.Items(i).Selected = True
                            Exit For
                        End If
                    Next
                    i = 0
                    rblMake.ClearSelection()
                    For i = 0 To rblMake.Items.Count - 1
                        If rblMake.Items(i).Text = IIf(IsDBNull(dt.Rows(0)("Make")), "", dt.Rows(0)("Make")) Then
                            rblMake.Items(i).Selected = True
                            Exit For
                        End If
                    Next
                    i = 0
                    rblSource.ClearSelection()
                    For i = 0 To rblSource.Items.Count - 1
                        If rblSource.Items(i).Text = IIf(IsDBNull(dt.Rows(0)("Source")), "", dt.Rows(0)("Source")) Then
                            rblSource.Items(i).Selected = True
                            Exit For
                        End If
                    Next
                    'If e.Item.Cells(1).Text = IIf(IsDBNull(dt.Rows(0)("ProductCode")), "", dt.Rows(0)("ProductCode")) Then
                    '    i = 0
                    '    rblInitialStage.ClearSelection()
                    '    For i = 0 To rblInitialStage.Items.Count - 1
                    '        If rblInitialStage.Items(i).Text = IIf(IsDBNull(dt.Rows(0)("StageCode")), "", dt.Rows(0)("StageCode")) Then
                    '            rblInitialStage.Items(i).Selected = True
                    '            Exit For
                    '        End If
                    '    Next
                    '    selectPnls()
                    '    If rblInitialStage.SelectedIndex = 0 Then
                    '        txtFGtoRT.Text = IIf(IsDBNull(dt.Rows(0)("ProductCode")), "", dt.Rows(0)("ProductCode"))
                    '        txtFGtoFI.Text = IIf(IsDBNull(dt.Rows(0)("NextStageProductCode")), "", dt.Rows(0)("NextStageProductCode"))
                    '    ElseIf rblInitialStage.SelectedIndex = 1 Then
                    '        txtRTtoFI.Text = IIf(IsDBNull(dt.Rows(0)("NextStageProductCode")), "", dt.Rows(0)("NextStageProductCode"))
                    '    End If
                    'ElseIf e.Item.Cells(1).Text = IIf(IsDBNull(dt.Rows(0)("NextStageProductCode")), "", dt.Rows(0)("NextStageProductCode")) Then
                    '    i = 0
                    '    rblInitialStage.ClearSelection()
                    '    For i = 0 To rblInitialStage.Items.Count - 1
                    '        If rblInitialStage.Items(i).Text = IIf(IsDBNull(dt.Rows(0)("StageCode")), "", dt.Rows(0)("StageCode")) Then
                    '            rblInitialStage.Items(i).Selected = True
                    '            Exit For
                    '        End If
                    '    Next
                    '    selectPnls()
                    '    If rblInitialStage.SelectedIndex = 0 Then
                    '        txtFGtoRT.Text = IIf(IsDBNull(dt.Rows(0)("ProductCode")), "", dt.Rows(0)("ProductCode"))
                    '        txtFGtoFI.Text = IIf(IsDBNull(dt.Rows(0)("NextStageProductCode")), "", dt.Rows(0)("NextStageProductCode"))
                    '    ElseIf rblInitialStage.SelectedIndex = 1 Then
                    '        txtRTtoFI.Text = IIf(IsDBNull(dt.Rows(0)("NextStageProductCode")), "", dt.Rows(0)("NextStageProductCode"))
                    '    End If
                    'End If

                    If e.Item.Cells(1).Text = IIf(IsDBNull(dt.Rows(0)("ProductCode")), "", dt.Rows(0)("ProductCode")) Then
                        i = 0
                        ddlInitialStage.ClearSelection()
                        For i = 0 To ddlInitialStage.Items.Count - 1
                            If ddlInitialStage.Items(i).Text = IIf(IsDBNull(dt.Rows(0)("StageCode")), "", dt.Rows(0)("StageCode")) Then
                                ddlInitialStage.Items(i).Selected = True
                                Exit For
                            End If
                        Next
                        selectPnls()
                        If ddlInitialStage.SelectedIndex = 0 Then
                            txtFGtoRT.Text = IIf(IsDBNull(dt.Rows(0)("ProductCode")), "", dt.Rows(0)("ProductCode"))
                            txtFGtoFI.Text = IIf(IsDBNull(dt.Rows(0)("NextStageProductCode")), "", dt.Rows(0)("NextStageProductCode"))
                        ElseIf ddlInitialStage.SelectedIndex = 1 Then
                            txtRTtoFI.Text = IIf(IsDBNull(dt.Rows(0)("NextStageProductCode")), "", dt.Rows(0)("NextStageProductCode"))
                        End If
                    ElseIf e.Item.Cells(1).Text = IIf(IsDBNull(dt.Rows(0)("NextStageProductCode")), "", dt.Rows(0)("NextStageProductCode")) Then
                        i = 0
                        ddlInitialStage.ClearSelection()
                        For i = 0 To ddlInitialStage.Items.Count - 1
                            If ddlInitialStage.Items(i).Text = IIf(IsDBNull(dt.Rows(0)("StageCode")), "", dt.Rows(0)("StageCode")) Then
                                ddlInitialStage.Items(i).Selected = True
                                Exit For
                            End If
                        Next
                        selectPnls()
                        If ddlInitialStage.SelectedIndex = 0 Then
                            txtFGtoRT.Text = IIf(IsDBNull(dt.Rows(0)("ProductCode")), "", dt.Rows(0)("ProductCode"))
                            txtFGtoFI.Text = IIf(IsDBNull(dt.Rows(0)("NextStageProductCode")), "", dt.Rows(0)("NextStageProductCode"))
                        ElseIf ddlInitialStage.SelectedIndex = 1 Then
                            txtRTtoFI.Text = IIf(IsDBNull(dt.Rows(0)("NextStageProductCode")), "", dt.Rows(0)("NextStageProductCode"))
                        End If
                    End If

                    lblMessage.Text = "Spec(R-16/R-43),Make,Source,CastGroup and Stages cannot be altered !"
                ElseIf CType(Session("Product"), PCO.Product).WheelSet Then
                    txtMinPr.Text = IIf(IsDBNull(dt.Rows(0)("min_pressure")), "", dt.Rows(0)("min_pressure"))
                    txtMaxPr.Text = IIf(IsDBNull(dt.Rows(0)("max_pressure")), "", dt.Rows(0)("max_pressure"))
                    txtMinGauge.Text = IIf(IsDBNull(dt.Rows(0)("Min_Guage")), "", dt.Rows(0)("Min_Guage"))
                    txtMaxGauge.Text = IIf(IsDBNull(dt.Rows(0)("max_Guage")), "", dt.Rows(0)("max_Guage"))
                    i = 0
                    ddlAxle.ClearSelection()
                    For i = 0 To ddlAxle.Items.Count - 1
                        If ddlAxle.Items(i).Text = IIf(IsDBNull(dt.Rows(0)("prod_id2")), "", dt.Rows(0)("prod_id2")) Then
                            ddlAxle.Items(i).Selected = True
                            Exit For
                        End If
                    Next
                    i = 0
                    ddlWheel.ClearSelection()
                    For i = 0 To ddlWheel.Items.Count - 1
                        If ddlWheel.Items(i).Text = IIf(IsDBNull(dt.Rows(0)("prod_id1")), "", dt.Rows(0)("prod_id1")) Then
                            ddlWheel.Items(i).Selected = True
                            Exit For
                        End If
                    Next
                End If
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        i = Nothing
        dt = Nothing
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        If txtDrawing.Text.Trim.Length = 0 Then
            lblMessage.Text = "InValid Drawing Number !"
            Exit Sub
        End If
        If txtDescription.Text.Trim.Length = 0 Then
            lblMessage.Text = "InValid Description !"
            Exit Sub
        End If
        Dim Done As New Boolean()
        If lblMode.Text = "edit" Then
            Try
                Done = CType(Session("Product"), PCO.Product).Product(txtDescription.Text.Trim, txtLongDescription.Text.Trim, txtDrawing.Text.Trim, txtSpecification.Text.Trim, Val(txtScrapPercentage.Text), Val(txtProdwtg.Text), Val(txtWtAtForge.Text), Val(txtLossPcnt.Text), ddlClass.SelectedItem.Text, Val(txtTransferPrice.Text), Val(txtRoughWeight.Text), Val(txtFinishWeight.Text), Val(txtWheelsPerHt.Text), Val(txtSalePrice.Text), txtWTAName.Text.Trim, txtcustomer_drawing_number.Text.Trim, Val(txtLowBHN.Text), Val(txtHighBHN.Text), Val(txtWeightPerWheel.Text), Val(txtRejPercent.Text), Val(txtSeriesStart.Text), Val(txtSereiesEnd.Text), Val(txtWheelPerMT.Text), Val(txtMRRejPercent.Text), Val(txtMinTreadDia.Text), Val(txtMaxTreadDia.Text), Val(txtMinBoreDia.Text), Val(txtMaxBoreDia.Text), Val(txtMinPlateThk.Text), Val(txtMaxPlateThk.Text), Val(txtOverSizeMin.Text), Val(txtOverSizeMax.Text), Val(txtSplSizeMin.Text), Val(txtSplSizeMax.Text), Val(txtMcnMinDia.Text), Val(txtMinPr.Text), Val(txtMaxPr.Text), Val(txtMinGauge.Text), Val(txtMaxGauge.Text), Val(txtMinWhlNo.Text), Val(txtMaxWhlNo.Text), Val(txtNRCPrice.Text))
            Catch exp As Exception
                lblMessage.Text = "ghvufhvgufg"
            End Try
            If Done Then
                lblMessage.Text &= "Data Updated !"
            Else
                lblMessage.Text &= "Data Updation failed !"
            End If
            Done = Nothing
        Else
            Dim InitialStage, NextRTProdCode, NextFIProdCode As String
            If CType(Session("Product"), PCO.Product).Axle Then
                Try
                    If chkInputs.Checked = False Then
                        lblMessage.Text = "Please check inputs before saving."
                        Exit Sub
                    ElseIf lblMessage.Text.Trim.StartsWith("InValid") Then
                        Exit Sub
                    End If
                    lblMessage.Text = ""
                    Try
                        CType(Session("Product"), PCO.Product).Make = rblMake.SelectedItem.Text.Trim
                        CType(Session("Product"), PCO.Product).Source = rblSource.SelectedItem.Text.Trim
                        CType(Session("Product"), PCO.Product).CastGroup = ddlCastGroup.SelectedItem.Text.Trim
                        Done = True
                    Catch exp As Exception
                        lblMessage.Text = CType(Session("Product"), PCO.Product).Message & " " & exp.Message
                    End Try
                    If Not Done Then
                        Exit Sub
                    Else
                        Done = False
                        Try
                            Select Case ddlInitialStage.SelectedItem.Text.Trim
                                Case "FG"
                                    InitialStage = "FG"
                                    If txtFGtoFI.Text.Trim.Length = 0 Then
                                        NextRTProdCode = txtFGtoRT.Text.Trim
                                        NextFIProdCode = ""
                                    Else
                                        NextRTProdCode = txtFGtoRT.Text.Trim
                                        NextFIProdCode = txtFGtoFI.Text.Trim
                                    End If
                                Case "RT"
                                    InitialStage = "RT"
                                    NextRTProdCode = txtProductCode.Text.Trim
                                    If txtFGtoFI.Text.Trim.Length = 0 Then
                                        NextRTProdCode = txtFGtoRT.Text.Trim
                                        NextFIProdCode = ""
                                    Else
                                        NextFIProdCode = txtFGtoFI.Text.Trim
                                    End If
                                Case "FI"
                                    InitialStage = "FI"
                                    NextRTProdCode = ""
                                    NextFIProdCode = txtProductCode.Text.Trim
                            End Select
                            CType(Session("Product"), PCO.Product).R43R16 = ddlR43R16.SelectedItem.Text
                        Catch exp As Exception
                            lblMessage.Text = CType(Session("Product"), PCO.Product).Message & "  " & exp.Message
                        End Try
                    End If
                    CType(Session("Product"), PCO.Product).CastGroup = ddlCastGroup.SelectedItem.Text.Trim
                Catch exp As Exception
                    lblMessage.Text = "CastGroup selecttion InValid "
                    Exit Sub
                End Try
            ElseIf CType(Session("Product"), PCO.Product).WheelSet Then
                Try
                    CType(Session("Product"), PCO.Product).AxleProduct = ddlAxle.SelectedItem.Text.Trim
                Catch exp As Exception
                    lblMessage.Text = "AxleProduct selecttion InValid "
                    Exit Sub
                End Try
                Try
                    CType(Session("Product"), PCO.Product).WheelProduct = ddlWheel.SelectedItem.Text.Trim
                Catch exp As Exception
                    lblMessage.Text = "WheelProduct selecttion InValid "
                    Exit Sub
                End Try
            End If
            Try
                Done = CType(Session("Product"), PCO.Product).Product(txtDescription.Text.Trim, txtLongDescription.Text.Trim, txtDrawing.Text.Trim, txtSpecification.Text.Trim, Val(txtScrapPercentage.Text), Val(txtProdwtg.Text), Val(txtWtAtForge.Text), Val(txtLossPcnt.Text), ddlClass.SelectedItem.Text, Val(txtTransferPrice.Text), Val(txtRoughWeight.Text), Val(txtFinishWeight.Text), Val(txtWheelsPerHt.Text), Val(txtSalePrice.Text), txtWTAName.Text.Trim, txtcustomer_drawing_number.Text.Trim, Val(txtLowBHN.Text), Val(txtHighBHN.Text), Val(txtWeightPerWheel.Text), Val(txtRejPercent.Text), Val(txtSeriesStart.Text), Val(txtSereiesEnd.Text), Val(txtWheelPerMT.Text), Val(txtMRRejPercent.Text), Val(txtMinTreadDia.Text), Val(txtMaxTreadDia.Text), Val(txtMinBoreDia.Text), Val(txtMaxBoreDia.Text), Val(txtMinPlateThk.Text), Val(txtMaxPlateThk.Text), Val(txtOverSizeMin.Text), Val(txtOverSizeMax.Text), Val(txtSplSizeMin.Text), Val(txtSplSizeMax.Text), Val(txtMcnMinDia.Text), Val(txtMinPr.Text), Val(txtMaxPr.Text), Val(txtMinGauge.Text), Val(txtMaxGauge.Text), Val(txtMinWhlNo.Text), Val(txtMaxWhlNo.Text), Val(txtNRCPrice.Text))
                If Done Then
                    If CType(Session("Product"), PCO.Product).Axle Then
                        Done = False
#Disable Warning BC42104 ' Variable is used before it has been assigned a value
#Disable Warning BC42104 ' Variable is used before it has been assigned a value
                        If CType(Session("Product"), PCO.Product).Save(txtProductCode.Text.Trim, rblMake.SelectedItem.Text.Trim, rblSource.SelectedItem.Text.Trim, ddlInitialStage.SelectedItem.Text.Trim, NextRTProdCode, NextFIProdCode) Then Done = True
#Enable Warning BC42104 ' Variable is used before it has been assigned a value
#Enable Warning BC42104 ' Variable is used before it has been assigned a value
                    End If
                End If
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
            If Done Then
                lblMessage.Text &= "Data Saved !"
            Else
                lblMessage.Text &= "Data Saving failed !"
            End If
            Done = Nothing
            InitialStage = Nothing
            NextRTProdCode = Nothing
            NextFIProdCode = Nothing
        End If
        dgProductList.SelectedIndex = -1
    End Sub

    Private Sub chkCastGrpAvailable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCastGrpAvailable.CheckedChanged
        chkInputs.Checked = False
        ddlCastGroup.DataSource = Nothing
        ddlCastGroup.DataBind()
        dgSimilarProducts.DataSource = Nothing
        dgSimilarProducts.DataBind()
        lblMessage.Text = ""
        Dim dt As DataTable
        Try
            If chkCastGrpAvailable.Checked Then
                dt = CType(Session("Product"), PCO.Product).NewCGs
                ddlCastGroup.DataSource = dt
                ddlCastGroup.DataTextField = dt.Columns("Cast_Group").ColumnName
                ddlCastGroup.DataValueField = dt.Columns("Cast_Group").ColumnName
                ddlCastGroup.DataBind()
            Else
                dt = CType(Session("Product"), PCO.Product).ExistingCGs
                ddlCastGroup.DataSource = dt
                ddlCastGroup.DataTextField = dt.Columns("Cast_Group").ColumnName
                ddlCastGroup.DataValueField = dt.Columns("Cast_Group").ColumnName
                ddlCastGroup.DataBind()
            End If
            'rdoSimilarProds.ClearSelection()
            'Dim i As New Int16()
            'For i = 0 To rdoSimilarProds.Items.Count - 1
            '    If rdoSimilarProds.Items(i).Text = "Cast Group" Then
            '        rdoSimilarProds.Items(i).Selected = True
            ddlSimilarProds.ClearSelection()
            Dim i As New Int16()
            For i = 0 To ddlSimilarProds.Items.Count - 1
                If ddlSimilarProds.Items(i).Text = "Cast Group" Then
                    ddlSimilarProds.Items(i).Selected = True
                    Exit For
                End If
            Next
            i = Nothing
            SimilarProduct(ddlCastGroup.SelectedItem.Text)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        dt = Nothing
    End Sub
    Private Sub SimilarProduct(Optional ByVal basedValue As String = "")
        lblMessage.Text = ""
        dgSimilarProducts.DataSource = Nothing
        dgSimilarProducts.DataBind()
        Dim dt As DataTable
        Try
            If IsNothing(dgSimilarProducts.CurrentPageIndex) Then dgSimilarProducts.CurrentPageIndex = 0
            'Select Case rdoSimilarProds.SelectedItem.Text.Trim
            '    Case "Drawing"
            '        dt = CType(Session("Product"), PCO.Product).ShowSimilarProduct(rdoSimilarProds.SelectedItem.Text.Trim, txtDrawing.Text.Trim)
            '    Case "Specification"
            '        dt = CType(Session("Product"), PCO.Product).ShowSimilarProduct(rdoSimilarProds.SelectedItem.Text.Trim, rdoR43R16.SelectedItem.Value.Trim)
            '    Case "Make"
            '        dt = CType(Session("Product"), PCO.Product).ShowSimilarProduct(rdoSimilarProds.SelectedItem.Text.Trim, rblMake.SelectedItem.Value.Trim)
            '    Case "Source"
            '        dt = CType(Session("Product"), PCO.Product).ShowSimilarProduct(rdoSimilarProds.SelectedItem.Text.Trim, rblSource.SelectedItem.Text.Trim)
            '    Case "Stage"
            '        dt = CType(Session("Product"), PCO.Product).ShowSimilarProduct(rdoSimilarProds.SelectedItem.Text.Trim, "")
            '    Case "Cast Group"
            '        dt = CType(Session("Product"), PCO.Product).ShowSimilarProduct(rdoSimilarProds.SelectedItem.Text.Trim, ddlCastGroup.SelectedItem.Text.Trim)
            '    Case Else
            'End Select
            Select Case ddlSimilarProds.SelectedItem.Text.Trim
                Case "Drawing"
                    dt = CType(Session("Product"), PCO.Product).ShowSimilarProduct(ddlSimilarProds.SelectedItem.Text.Trim, txtDrawing.Text.Trim)
                Case "Specification"
                    dt = CType(Session("Product"), PCO.Product).ShowSimilarProduct(ddlSimilarProds.SelectedItem.Text.Trim, ddlR43R16.SelectedItem.Value.Trim)
                Case "Make"
                    dt = CType(Session("Product"), PCO.Product).ShowSimilarProduct(ddlSimilarProds.SelectedItem.Text.Trim, rblMake.SelectedItem.Value.Trim)
                Case "Source"
                    dt = CType(Session("Product"), PCO.Product).ShowSimilarProduct(ddlSimilarProds.SelectedItem.Text.Trim, rblSource.SelectedItem.Text.Trim)
                Case "Stage"
                    dt = CType(Session("Product"), PCO.Product).ShowSimilarProduct(ddlSimilarProds.SelectedItem.Text.Trim, "")
                Case "Cast Group"
                    dt = CType(Session("Product"), PCO.Product).ShowSimilarProduct(ddlSimilarProds.SelectedItem.Text.Trim, ddlCastGroup.SelectedItem.Text.Trim)
                Case Else
            End Select

#Disable Warning BC42104 ' Variable is used before it has been assigned a value
            If dt.Rows.Count > 2 Then
#Enable Warning BC42104 ' Variable is used before it has been assigned a value
                dgSimilarProducts.AllowPaging = True
                dgSimilarProducts.PageSize = 2
                dgSimilarProducts.PagerStyle.Mode = PagerMode.NumericPages
            End If
            dgSimilarProducts.DataSource = dt
            dgSimilarProducts.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        dt = Nothing
    End Sub

    'Private Sub rdoSimilarProds_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoSimilarProds.SelectedIndexChanged
    '    lblMessage.Text = ""
    '    chkInputs.Checked = False
    '    Try
    '        SimilarProduct()
    '    Catch exp As Exception
    '        lblMessage.Text = exp.Message
    '    End Try
    'End Sub

    Private Sub ddlSimilarProds_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlSimilarProds.SelectedIndexChanged
        lblMessage.Text = ""
        chkInputs.Checked = False
        Try
            SimilarProduct()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub dgSimilarProducts_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgSimilarProducts.PageIndexChanged
        lblMessage.Text = ""
        Try
            dgSimilarProducts.CurrentPageIndex = e.NewPageIndex
            dgSimilarProducts.EditItemIndex = -1
            SimilarProduct()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub chkInputs_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkInputs.CheckedChanged
        lblMessage.Text = ""
        If chkInputs.Checked Then
            Dim check As New Boolean()
            Try
                CType(Session("Product"), PCO.Product).Make = rblMake.SelectedItem.Text.Trim
                CType(Session("Product"), PCO.Product).Source = rblSource.SelectedItem.Text.Trim
                check = True
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
            If Not check Then
                Exit Sub
            Else
                check = False
                Try
                    Select Case ddlInitialStage.SelectedItem.Text.Trim
                        Case "FG"
                            If txtFGtoRT.Text.Trim = txtProductCode.Text.Trim Or txtFGtoFI.Text = txtProductCode.Text.Trim Then
                                txtFGtoRT.Text = ""
                                txtFGtoFI.Text = ""
                                Throw New Exception("InValid Product Codes!")
                            ElseIf txtFGtoRT.Text.Trim.Length = 0 AndAlso txtFGtoFI.Text.Trim.Length > 0 Then
                                Throw New Exception("Rough Turn Stage for loose axle despatch will be curtailed !")
                            ElseIf txtFGtoRT.Text.Trim.Length > 0 AndAlso txtFGtoFI.Text.Trim.Length = 0 Then
                                Throw New Exception("Rough Turn Stage for loose axle despatch only but not for press with Finished Stage !")
                            ElseIf txtFGtoRT.Text.Trim.Length = 0 AndAlso txtFGtoFI.Text.Trim.Length = 0 Then
                                Throw New Exception("InValid Stage Code!")
                            End If
                        Case "RT"
                            If txtRTtoFI.Text.Trim = txtProductCode.Text.Trim Then
                                Throw New Exception("Rough Turn Stage for loose axle despatch only but not for press with Finished Stage !")
                            ElseIf txtRTtoFI.Text.Trim.Length = 0 Then
                                Throw New Exception("Rough Turn Stage for loose axle despatch only but not for press with Finished Stage !")
                            Else
                                Throw New Exception("Rough Turn Stage to  Finished Stage for press !")
                            End If
                        Case "FI"
                            If txtFGtoRT.Text.Trim.Length > 0 Or txtFGtoFI.Text.Trim.Length > 0 Or txtRTtoFI.Text.Trim.Length > 0 Then
                                Throw New Exception("InValid Next Stage Code !")
                            ElseIf txtFGtoRT.Text.Trim.Length = 0 Or txtFGtoFI.Text.Trim.Length = 0 Or txtRTtoFI.Text.Trim.Length = 0 Then
                                Throw New Exception("Finished Stage for press only avoiding Rough Turn Stage for loose axle despatch !")
                            End If
                    End Select
                    check = True
                Catch exp As Exception
                    lblMessage.Text = exp.Message
                End Try
                check = Nothing
            End If
        End If
    End Sub

    'Private Sub rblInitialStage_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblInitialStage.SelectedIndexChanged
    '    lblMessage.Text = ""
    '    chkInputs.Checked = False
    '    Try
    '        selectPnls()
    '    Catch exp As Exception
    '        lblMessage.Text = exp.Message
    '    End Try
    'End Sub

    Private Sub ddlInitialStage_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlInitialStage.SelectedIndexChanged
        lblMessage.Text = ""
        chkInputs.Checked = False
        Try
            selectPnls()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    'Private Sub selectPnls()
    '    clearPnls()
    '    If rblInitialStage.SelectedIndex = 0 Then
    '        pnlStageRT.Visible = True
    '        pnlStageFI.Visible = False
    '    ElseIf rblInitialStage.SelectedIndex = 1 Then
    '        pnlStageRT.Visible = True
    '        pnlStageFI.Visible = False
    '    End If
    'End Sub
    Private Sub selectPnls()
        clearPnls()
        If ddlInitialStage.SelectedIndex = 0 Then
            pnlStageRT.Visible = True
            pnlStageFI.Visible = False
        ElseIf ddlInitialStage.SelectedIndex = 1 Then
            pnlStageRT.Visible = True
            pnlStageFI.Visible = False
        End If
    End Sub

    Private Sub clearPnls()
        pnlStageRT.Visible = False
        txtFGtoRT.Text = ""
        txtFGtoFI.Text = ""
        pnlStageFI.Visible = False
        txtRTtoFI.Text = ""
    End Sub

    Private Sub txtFGtoRT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFGtoRT.TextChanged
        lblMessage.Text = ""
        chkInputs.Checked = False
        Try
            'If Not CType(Session("Product"), PCO.Product).CheckProdCode(txtFGtoRT.Text.Trim, ddlCastGroup.SelectedItem.Text.Trim, CType(Session("Product"), PCO.Product).NewProductCode) Then
            '    lblMessage.Text = "InValid ProdCode : " & txtFGtoRT.Text.Trim
            '    txtFGtoRT.Text = ""
            'End If
        Catch exp As Exception
            txtFGtoRT.Text = ""
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtFGtoFI_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFGtoFI.TextChanged
        lblMessage.Text = ""
        chkInputs.Checked = False
        Try
            'If Not CType(Session("Product"), PCO.Product).CheckProdCode(txtFGtoFI.Text.Trim, ddlCastGroup.SelectedItem.Text.Trim, CType(Session("Product"), PCO.Product).NewProductCode) Then
            '    lblMessage.Text = "InValid ProdCode : " & txtFGtoFI.Text.Trim
            '    txtFGtoFI.Text = ""
            'End If
        Catch exp As Exception
            txtFGtoFI.Text = ""
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtRTtoFI_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRTtoFI.TextChanged
        lblMessage.Text = ""
        chkInputs.Checked = False
        Try
            'If Not CType(Session("Product"), PCO.Product).CheckProdCode(txtRTtoFI.Text.Trim, ddlCastGroup.SelectedItem.Text.Trim, CType(Session("Product"), PCO.Product).NewProductCode) Then
            '    lblMessage.Text = "InValid ProdCode : " & txtRTtoFI.Text.Trim
            '    txtRTtoFI.Text = ""
            'End If
        Catch exp As Exception
            txtRTtoFI.Text = ""
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub ddlCastGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlCastGroup.SelectedIndexChanged
        lblMessage.Text = ""
        chkInputs.Checked = False
        Try
            'Dim i As New Int16()
            'For i = 0 To rdoSimilarProds.Items.Count - 1
            '    If rdoSimilarProds.Items(i).Text = "Cast Group" Then
            '        rdoSimilarProds.Items(i).Selected = True
            '        Exit For
            '    End If
            'Next
            Dim i As New Int16()
            For i = 0 To ddlSimilarProds.Items.Count - 1
                If ddlSimilarProds.Items(i).Text = "Cast Group" Then
                    ddlSimilarProds.Items(i).Selected = True
                    Exit For
                End If
            Next

            i = Nothing
            SimilarProduct(ddlCastGroup.SelectedItem.Text)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub rblSource_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblSource.SelectedIndexChanged
        lblMessage.Text = ""
        chkInputs.Checked = False
        selectPnls()
        'Try
        '    rdoSimilarProds.ClearSelection()
        '    Dim i As New Int16()
        '    For i = 0 To rdoSimilarProds.Items.Count - 1
        '        If rdoSimilarProds.Items(i).Text = "Source" Then
        '            rdoSimilarProds.Items(i).Selected = True
        '            Exit For
        '        End If
        '    Next
        '    i = Nothing
        '    CType(Session("Product"), PCO.Product).Source = rblSource.SelectedItem.Text.Trim
        '    SimilarProduct(rdoSimilarProds.SelectedItem.Text)
        'Catch exp As Exception
        '    lblMessage.Text = exp.Message
        'End Try
        Try
            ddlSimilarProds.ClearSelection()
            Dim i As New Int16()
            For i = 0 To ddlSimilarProds.Items.Count - 1
                If ddlSimilarProds.Items(i).Text = "Source" Then
                    ddlSimilarProds.Items(i).Selected = True
                    Exit For
                End If
            Next
            i = Nothing
            CType(Session("Product"), PCO.Product).Source = rblSource.SelectedItem.Text.Trim
            SimilarProduct(ddlSimilarProds.SelectedItem.Text)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub rblMake_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblMake.SelectedIndexChanged
        lblMessage.Text = ""
        chkInputs.Checked = False
        selectPnls()
        'Try
        '    rdoSimilarProds.ClearSelection()
        '    Dim i As New Int16()
        '    For i = 0 To rdoSimilarProds.Items.Count - 1
        '        If rdoSimilarProds.Items(i).Text = "Make" Then
        '            rdoSimilarProds.Items(i).Selected = True
        '            Exit For
        '        End If
        '    Next
        '    i = Nothing
        '    CType(Session("Product"), PCO.Product).Make = rblMake.SelectedItem.Text.Trim
        '    SimilarProduct(rblMake.SelectedItem.Text)
        'Catch exp As Exception
        '    lblMessage.Text = exp.Message
        'End Try
        Try
            ddlSimilarProds.ClearSelection()
            Dim i As New Int16()
            For i = 0 To ddlSimilarProds.Items.Count - 1
                If ddlSimilarProds.Items(i).Text = "Make" Then
                    ddlSimilarProds.Items(i).Selected = True
                    Exit For
                End If
            Next
            i = Nothing
            CType(Session("Product"), PCO.Product).Make = rblMake.SelectedItem.Text.Trim
            SimilarProduct(rblMake.SelectedItem.Text)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    'Private Sub rdoR43R16_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoR43R16.SelectedIndexChanged
    '    lblMessage.Text = ""
    '    chkInputs.Checked = False
    'Try
    '    rdoSimilarProds.SelectedItem.Text = "Specification"
    '    SimilarProduct()
    'Catch exp As Exception
    '    lblMessage.Text = exp.Message
    'End Try
    Private Sub ddlR43R16_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlR43R16.SelectedIndexChanged
        lblMessage.Text = ""
        chkInputs.Checked = False
        Try
            ddlSimilarProds.SelectedItem.Text = "Specification"
            SimilarProduct()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnCheckList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckList.Click
        Dim strPathName As String
        Dim txtDate As New TextBox()
        txtDate.Text = CDate("1900-01-01")
        strPathName = "http://" & rwfGen.ReportServer.ServerName & "" &
                    "/mmsreports/pcopco/formats/ProductMasterCheckList.rpt?user0=wap&password0=wap" &
                    "&promptonrefresh=0"
        Response.Redirect(strPathName)
    End Sub

    Protected Sub ddlProductNature_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlProductNature.SelectedIndexChanged
        Try
            setobj()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Protected Sub ddlCondition_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCondition.SelectedIndexChanged
        Try
            setobj()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub ddlProductService_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlProductService.SelectedIndexChanged
        Try
            setobj()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

End Class
