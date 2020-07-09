Public Class UpdatePOofMoulds
    Inherits System.Web.UI.Page
    Protected WithEvents txtMldNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPONumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlSupplier As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblOperator As System.Web.UI.WebControls.Label
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents rblMouldSize As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblPL As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents ddlProductCode As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtMould As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlSupplierCode As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnFirm As System.Web.UI.WebControls.Button
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
        'Put user code to initialize the page here
        If Page.IsPostBack = False Then
            lblOperator.Text = Session("UserID")
            'lblOperator.Text = "078916"
            lblOperator.Visible = False
            Try
                getSupplier_codes()
                getProduct_codes()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub
    Private Sub getProduct_codes()
        Dim dt As New DataTable()
        Try
            dt = MouldMaster.tables.ProductCodesInMouldMasterTable(False)
            ddlProductCode.DataSource = dt
            ddlProductCode.DataTextField = "description"
            ddlProductCode.DataValueField = "product_code"
            ddlProductCode.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
            dt = Nothing
        End Try
    End Sub
    Private Sub getSupplier_codes()
        Dim dt As New DataTable()
        Try
            dt = MouldMaster.tables.getSupplier_codes
            ddlSupplier.DataSource = dt
            ddlSupplier.DataTextField = "Supplier_name"
            ddlSupplier.DataValueField = "supplier_code"
            ddlSupplier.DataBind()
            ddlSupplierCode.DataSource = dt
            ddlSupplierCode.DataTextField = "Supplier_name"
            ddlSupplierCode.DataValueField = "supplier_code"
            ddlSupplierCode.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
            dt = Nothing
        End Try
    End Sub

    Private Sub txtPONumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPONumber.TextChanged
        lblMessage.Text = ""
        Try
            If Len(txtPONumber.Text.Trim) > 0 Then
                Try
                    If rblMouldSize.SelectedItem.Text.Trim = "52.5" Then
                        If rblPL.SelectedItem.Text.Trim <> "76971510" Then
                            lblMessage.Text = "PL Number : '" & rblPL.SelectedItem.Text.Trim & "'  mis-match with Mould Size !"
                            txtPONumber.Text = ""
                        End If
                    ElseIf rblMouldSize.SelectedItem.Text = "48.5" Then
                        If rblPL.SelectedItem.Text.Trim <> "81980802" Then
                            lblMessage.Text = "PL Number : '" & rblPL.SelectedItem.Text.Trim & "'  mis-match with Mould Size !"
                            txtPONumber.Text = ""
                        End If
                    ElseIf rblMouldSize.SelectedItem.Text = "42.5" Then
                        If rblPL.SelectedItem.Text.Trim <> "81980851" Then
                            lblMessage.Text = "PL Number : '" & rblPL.SelectedItem.Text.Trim & "'  mis-match with Mould Size !"
                            txtPONumber.Text = ""
                        End If
                    ElseIf Not MouldMaster.tables.CheckPO(txtPONumber.Text.Trim, ddlSupplier.SelectedItem.Value, rblPL.SelectedItem.Value) Then
                        lblMessage.Text = "PO Number : '" & txtPONumber.Text.Trim & "'  InValid !"
                        txtPONumber.Text = ""
                    End If
                Catch exp As Exception
                    lblMessage.Text = exp.Message
                    txtPONumber.Text = ""
                End Try
                If Not MouldMaster.tables.CheckPO(txtPONumber.Text.Trim, ddlSupplier.SelectedItem.Value, rblPL.SelectedItem.Value) Then
                    lblMessage.Text = "PO Number : '" & txtPONumber.Text.Trim & "'  InValid !"
                    txtPONumber.Text = ""
                End If
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
            txtPONumber.Text = ""
        End Try
    End Sub

    Private Sub txtMldNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMldNo.TextChanged
        lblMessage.Text = ""
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Dim dt As DataTable
        Try
            Session.Remove("NewMld")
            Dim oMld As New MouldMaster.Moulds()
            Session("NewMld") = oMld
            If Len(txtMldNo.Text.Trim) > 0 Then
                dt = MouldMaster.tables.getMouldDetails(txtMldNo.Text.Trim)
                If dt.Rows.Count = 0 Then
                    CType(Session("NewMld"), MouldMaster.Moulds).MouldSizeExists = False
                Else
                    CType(Session("NewMld"), MouldMaster.Moulds).MouldSizeExists = True
                    DataGrid1.DataSource = dt
                    DataGrid1.DataBind()
                End If
            End If
            oMld = Nothing
        Catch exp As Exception
            lblMessage.Text = exp.Message
            txtMldNo.Text = ""
        End Try
        dt = Nothing
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        If txtMldNo.Text = "" Then
            lblMessage.Text = "Please enter Mould Number !"
            Exit Sub
        Else
            Try
                CType(Session("NewMld"), MouldMaster.Moulds).MouldNumber = txtMldNo.Text.Trim
                CType(Session("NewMld"), MouldMaster.Moulds).mould_size = rblMouldSize.SelectedItem.Value
                CType(Session("NewMld"), MouldMaster.Moulds).PONumber = txtPONumber.Text.Trim
                CType(Session("NewMld"), MouldMaster.Moulds).ProductCode = ddlProductCode.SelectedItem.Value
                If CType(Session("NewMld"), MouldMaster.Moulds).UpdateMouldPO() Then
                    DataGrid1.DataSource = Nothing
                    DataGrid1.DataBind()
                    DataGrid1.DataSource = MouldMaster.tables.getMouldDetails(txtMldNo.Text.Trim)
                    DataGrid1.DataBind()
                    txtMldNo.Text = ""
                    txtPONumber.Text = ""
                End If
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
            lblMessage.Text &= CType(Session("NewMld"), MouldMaster.Moulds).Message
        End If
    End Sub

    Private Sub btnFirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirm.Click
        lblMessage.Text = ""
        If txtMould.Text = "" Then
            lblMessage.Text = "Please enter Mould Number !"
            Exit Sub
        Else
            Try
                If New MouldMaster.MRSMRS().UpdateFirm(txtMould.Text.Trim, ddlSupplierCode.SelectedItem.Text) Then
                    DataGrid2.DataSource = Nothing
                    DataGrid2.DataBind()
                    DataGrid2.DataSource = MouldMaster.tables.getMouldSts(txtMould.Text.Trim)
                    DataGrid2.DataBind()
                    txtMould.Text = ""
                End If
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub

    Private Sub txtMould_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMould.TextChanged
        lblMessage.Text = ""
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        Try
            DataGrid2.DataSource = MouldMaster.tables.getMouldSts(txtMould.Text.Trim)
            DataGrid2.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
End Class
