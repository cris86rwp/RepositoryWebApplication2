Public Class mm_pco_WTA_ComplianceDelete
    Inherits System.Web.UI.Page
    Protected WithEvents lblMode As System.Web.UI.WebControls.Label
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents txtDCNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDCQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDCRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnShowPlan As System.Web.UI.WebControls.Button
    Protected WithEvents btnShowSupply As System.Web.UI.WebControls.Button
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents btnChangeSupplyID As System.Web.UI.WebControls.Button
    Protected WithEvents lblPlanID As System.Web.UI.WebControls.Label
    Protected WithEvents lblProductCode As System.Web.UI.WebControls.Label
    Protected WithEvents lblProductDesc As System.Web.UI.WebControls.Label
    Protected WithEvents lblProductQty As System.Web.UI.WebControls.Label
    Protected WithEvents lblWTANumDt As System.Web.UI.WebControls.Label
    Protected WithEvents lblOrderNumDt As System.Web.UI.WebControls.Label
    Protected WithEvents lblSupplyID As System.Web.UI.WebControls.Label
    Protected WithEvents lblSupplierCode As System.Web.UI.WebControls.Label
    Protected WithEvents lblSupplierName As System.Web.UI.WebControls.Label
    Protected WithEvents lblSupplyQty As System.Web.UI.WebControls.Label
    Protected WithEvents txtFrDt As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblFrDt As System.Web.UI.WebControls.Label
    Protected WithEvents txtToDt As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblToDt As System.Web.UI.WebControls.Label
    Protected WithEvents btnShowDespatches As System.Web.UI.WebControls.Button
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgDCNumbers As System.Web.UI.WebControls.DataGrid
    Protected WithEvents pnlCompliance As System.Web.UI.WebControls.Panel
    Dim selected, mode As String
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
            pnlCompliance.Visible = False
            txtDCNumber.Enabled = False
            txtDCQty.Enabled = False
            txtDCQty.Enabled = False
            btnSave.Enabled = False
            btnChangeSupplyID.Enabled = False
            mode = "delete"
            'mode = Request.QueryString("mode")
            lblMode.Text = mode
            Dim WTA_Compliance As New PCO.WTA_Compliance()
            viewstate("WTA_Compliance") = WTA_Compliance
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        Try
            CType(viewstate("WTA_Compliance"), PCO.WTA_Compliance).DCNumber = txtDCNumber.Text.Trim
            CType(viewstate("WTA_Compliance"), PCO.WTA_Compliance).DCQty = txtDCQty.Text
            CType(viewstate("WTA_Compliance"), PCO.WTA_Compliance).DCRemarks = txtDCRemarks.Text
            CType(viewstate("WTA_Compliance"), PCO.WTA_Compliance).Save(True)
            showgrid()
            txtDCNumber.Text = ""
            txtDCQty.Text = ""
            txtDCRemarks.Text = ""
            CType(viewstate("WTA_Compliance"), PCO.WTA_Compliance).ComplianceID = 0
            CType(viewstate("WTA_Compliance"), PCO.WTA_Compliance).DCNumber = ""
            CType(viewstate("WTA_Compliance"), PCO.WTA_Compliance).DCQty = ""
            CType(viewstate("WTA_Compliance"), PCO.WTA_Compliance).DCRemarks = ""
            lblMessage.Text = " Data deleted ! "
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub showgrid()
        dgDCNumbers.DataSource = Nothing
        dgDCNumbers.DataBind()
        dgDCNumbers.DataSource = CType(viewstate("WTA_Compliance"), PCO.WTA_Compliance).GetComplianceList
        dgDCNumbers.DataBind()
        If CType(viewstate("WTA_Compliance"), PCO.WTA_Compliance).CompIdCount > 0 Then
            pnlCompliance.Visible = True
            dgDCNumbers.Visible = True
        Else
            dgDCNumbers.DataSource = Nothing
            dgDCNumbers.DataBind()
        End If
    End Sub
    Private Sub btnShowPlan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowPlan.Click
        lblMessage.Text = ""
        btnSave.Enabled = False
        btnChangeSupplyID.Enabled = False
        DataGrid1.Visible = True
        Try
            DataGrid1.DataSource = Nothing
            DataGrid1.DataBind()
            CType(viewstate("WTA_Compliance"), PCO.WTA_Compliance).SupplyId = 0
            CType(viewstate("WTA_Compliance"), PCO.WTA_Compliance).SupplyPlanId = 0
            CType(viewstate("WTA_Compliance"), PCO.WTA_Compliance).ProductCode = ""
            CType(viewstate("WTA_Compliance"), PCO.WTA_Compliance).ConsigneeCode = ""
            DataGrid1.DataSource = CType(viewstate("WTA_Compliance"), PCO.WTA_Compliance).GetSupplyPlanList()
            DataGrid1.DataBind()
            selected = "plan"
            viewstate("show") = selected
            setPlanVals()
            setSupplyVals()
            setDespatchVals()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub setPlanVals()
        lblPlanID.Text = ""
        lblProductCode.Text = ""
        lblProductDesc.Text = ""
        lblWTANumDt.Text = ""
        lblOrderNumDt.Text = ""
        lblProductQty.Text = ""
    End Sub
    Private Sub setSupplyVals()
        lblSupplyID.Text = ""
        lblSupplierCode.Text = ""
        lblSupplierName.Text = ""
        lblSupplyQty.Text = ""
    End Sub
    Private Sub setDespatchVals()
        txtFrDt.Text = ""
        txtToDt.Text = ""
        lblFrDt.Text = ""
        lblToDt.Text = ""
        txtDCNumber.Text = ""
        txtDCQty.Text = ""
        txtDCRemarks.Text = ""
    End Sub
    Private Sub DataGrid1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.ItemCommand
        lblMessage.Text = ""
        selected = CType(viewstate("show"), String)
        Select Case selected
            Case "plan"
                Try
                    CType(viewstate("WTA_Compliance"), PCO.WTA_Compliance).SupplyPlanId = e.Item.Cells(1).Text
                    If Not IsDBNull(e.Item.Cells(2).Text) Then CType(viewstate("WTA_Compliance"), PCO.WTA_Compliance).ProductCode = CStr(e.Item.Cells(2).Text.Trim)
                    lblPlanID.Text = e.Item.Cells(1).Text
                    lblProductCode.Text = e.Item.Cells(2).Text
                    lblProductDesc.Text = e.Item.Cells(3).Text
                    lblWTANumDt.Text = e.Item.Cells(4).Text.Trim + "--" + Format(CDate(e.Item.Cells(5).Text.Trim), "dd-MM-yyyy")
                    lblOrderNumDt.Text = e.Item.Cells(6).Text.Trim + "--" + Format(CDate(e.Item.Cells(7).Text.Trim), "dd-MM-yyyy")
                    lblProductQty.Text = e.Item.Cells(9).Text
                    DataGrid1.DataSource = Nothing
                    DataGrid1.DataBind()
                    'DataGrid1.DataSource = CType(viewstate("WTA_Compliance"), PCO.WTA_Compliance).GetSupplyConsigneeList
                    'DataGrid1.DataBind()
                Catch exp As Exception
                    lblMessage.Text = " Error in selected PlanID : " & exp.Message
                End Try
            Case "supply"
                lblMessage.Text = ""
                'Dim blnselected As Boolean
                Try
                    pnlCompliance.Visible = False
                    CType(viewstate("WTA_Compliance"), PCO.WTA_Compliance).SupplyId = e.Item.Cells(1).Text
                    If Not IsDBNull(e.Item.Cells(3).Text) Then
                        CType(viewstate("WTA_Compliance"), PCO.WTA_Compliance).ConsigneeCode = CStr(e.Item.Cells(3).Text)
                    End If
                    lblSupplyID.Text = e.Item.Cells(1).Text
                    lblSupplierCode.Text = e.Item.Cells(3).Text
                    lblSupplierName.Text = e.Item.Cells(4).Text
                    lblSupplyQty.Text = e.Item.Cells(5).Text
                    DataGrid1.DataSource = Nothing
                    DataGrid1.DataBind()
                    txtFrDt.Text = Now.Date
                    txtToDt.Text = Now.Date
                    txtFrDt.Visible = True
                    txtToDt.Visible = True
                    lblFrDt.Text = ""
                    lblToDt.Text = ""
                Catch exp As Exception
                    lblMessage.Text = exp.Message
                End Try
            Case "DCNumbers"
                'btnSave.Enabled = True
                'btnChangeSupplyID.Enabled = True
                'txtDCNumber.Text = e.Item.Cells(1).Text
                'txtDCQty.Text = e.Item.Cells(7).Text
        End Select
    End Sub

    Private Sub btnShowSupply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowSupply.Click
        lblMessage.Text = ""
        btnSave.Enabled = False
        btnChangeSupplyID.Enabled = False
        DataGrid1.Visible = True
        If lblPlanID.Text = "" Or lblPlanID.Text = "0" Then
            lblMessage.Text = " Please select Plan ID before getting Supply ID "
        Else
            Try
                CType(viewstate("WTA_Compliance"), PCO.WTA_Compliance).SupplyId = 0
                CType(viewstate("WTA_Compliance"), PCO.WTA_Compliance).ConsigneeCode = ""
                DataGrid1.DataSource = Nothing
                DataGrid1.DataBind()
                DataGrid1.DataSource = CType(viewstate("WTA_Compliance"), PCO.WTA_Compliance).GetSupplyConsigneeList
                DataGrid1.DataBind()
                dgDCNumbers.DataSource = Nothing
                dgDCNumbers.DataBind()
                selected = "supply"
                viewstate("show") = selected
                setSupplyVals()
                setDespatchVals()
            Catch exp As Exception
                lblMessage.Text = ""
            End Try
        End If
    End Sub

    Private Sub btnShowDespatches_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowDespatches.Click
        lblMessage.Text = ""
        DataGrid1.Visible = True
        If lblPlanID.Text = "" Or lblPlanID.Text = "0" Or lblSupplyID.Text = "" Or lblSupplyID.Text = "0" Then
            lblMessage.Text = " Please select PlanID and SupplyID before selecting Despatches "
        Else
            txtDCNumber.Text = ""
            txtDCQty.Text = ""
            If CDate(txtFrDt.Text.Trim) > CDate(txtToDt.Text.Trim) Then
                lblMessage.Text &= "From Date is more than To Date ! (From :" & txtFrDt.Text & " To : " & txtToDt.Text & "). "
                txtFrDt.Text = ""
                txtToDt.Text = ""
                Exit Sub
            End If
            Try
                DataGrid1.DataSource = Nothing
                DataGrid1.DataBind()
                CType(viewstate("WTA_Compliance"), PCO.WTA_Compliance).FromDate = txtFrDt.Text.Trim
                CType(viewstate("WTA_Compliance"), PCO.WTA_Compliance).ToDate = txtToDt.Text.Trim
                DataGrid1.DataSource = CType(viewstate("WTA_Compliance"), PCO.WTA_Compliance).GetDCNumbers
                DataGrid1.DataBind()
                selected = "DCNumbers"
                viewstate("show") = selected
                'If CType(viewstate("WTA_Compliance"), PCO.WTA_Compliance).DCCount <= 0 Then
                '    DataGrid1.Visible = False
                '    Throw New Exception(" No Despatches for this comination of data ! ")
                'End If
                showgrid()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub

    Private Sub txtFrDt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFrDt.TextChanged
        lblMessage.Text = ""
        Try
            txtFrDt.Text = CDate(txtFrDt.Text.Trim)
            If CDate(txtFrDt.Text.Trim) > Now.Date Then
                lblMessage.Text = "From Date:'" & txtFrDt.Text.Trim & "' Can Not Be Greater Than Current Date. "
                txtFrDt.Text = ""
            End If
            DataGrid1.DataSource = Nothing
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = " Despatch From Date not in correct format : " & txtFrDt.Text
            txtFrDt.Text = ""
        End Try
    End Sub

    Private Sub txtToDt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtToDt.TextChanged
        lblMessage.Text = ""
        Try
            txtToDt.Text = CDate(txtToDt.Text.Trim)
            If CDate(txtToDt.Text.Trim) > Now.Date Then
                lblMessage.Text = "From Date:'" & txtToDt.Text.Trim & "' Can Not Be Greater Than Current Date. "
                txtToDt.Text = ""
            End If
            DataGrid1.DataSource = Nothing
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = " Despatch From Date not in correct format : " & txtToDt.Text
            txtToDt.Text = ""
        End Try
    End Sub

    Private Sub btnChangeSupplyID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeSupplyID.Click
        lblMessage.Text = ""
        btnSave.Enabled = False
        btnChangeSupplyID.Enabled = False
        DataGrid1.Visible = True
        If lblPlanID.Text = "" Or lblPlanID.Text = "0" Then
            lblMessage.Text = " Please select Plan ID before getting Supply ID "
        Else
            Try
                CType(viewstate("WTA_Compliance"), PCO.WTA_Compliance).SupplyId = 0
                CType(viewstate("WTA_Compliance"), PCO.WTA_Compliance).ConsigneeCode = ""
                DataGrid1.DataSource = Nothing
                DataGrid1.DataBind()
                DataGrid1.DataSource = CType(viewstate("WTA_Compliance"), PCO.WTA_Compliance).GetSupplyConsigneeList
                DataGrid1.DataBind()
                selected = "supply"
                viewstate("show") = selected
                setSupplyVals()
                setDespatchVals()
                dgDCNumbers.DataSource = Nothing
                dgDCNumbers.DataBind()
            Catch exp As Exception
                lblMessage.Text = ""
            End Try
        End If
    End Sub

    Private Sub dgDCNumbers_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgDCNumbers.ItemCommand
        lblMessage.Text = ""
        Try
            btnSave.Enabled = True
            btnChangeSupplyID.Enabled = True
            CType(viewstate("WTA_Compliance"), PCO.WTA_Compliance).ComplianceID = e.Item.Cells(1).Text
            txtDCNumber.Text = e.Item.Cells(4).Text
            txtDCQty.Text = e.Item.Cells(5).Text
            txtDCRemarks.Text = e.Item.Cells(10).Text
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
End Class
