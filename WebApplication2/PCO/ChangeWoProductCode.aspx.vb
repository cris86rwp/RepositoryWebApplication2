Public Class ChangeWoProductCode
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents txtEndDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtStartDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlShops As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlWo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtProductCodeOriginal As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblEmpCode As System.Web.UI.WebControls.Label
    Protected WithEvents txtAuthorisationInfo As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSubmit As System.Web.UI.WebControls.Button
    Protected WithEvents lblWoQty As System.Web.UI.WebControls.Label
    Protected WithEvents lblProduced As System.Web.UI.WebControls.Label
    Protected WithEvents lblWoNumber As System.Web.UI.WebControls.Label
    Protected WithEvents rf As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents rfv2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents rfv3 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents rfv4 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents rfv5 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents rfv6 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents rfv7 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtNewProductCode As System.Web.UI.WebControls.TextBox
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
        If Page.IsPostBack = False Then
            Dim blnDone As Boolean
            Session("UserID") = "074632"
            Try
                Dim emp As New rwfGen.Employee()
                If emp.Check(Session("UserID"), "PCOPCO", "MMS") Then
                    lblEmpCode.Text = Session("UserID") & ""
                    blnDone = True
                End If
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
            If blnDone = False Then
                Response.Redirect("InvalidSession.aspx")
            End If
            blnDone = Nothing
            Dim oModifyWoProduct As New PCO.ModifyWoProduct()
            ViewState("tblShops") = oModifyWoProduct.ShopList
            Dim dv As New DataView()
            dv.Table = CType(ViewState("tblShops"), DataTable)
            dv.Sort = "Description"
            ddlShops.DataSource = dv
            ddlShops.DataTextField = "Description"
            ddlShops.DataValueField = "Code"
            ddlShops.DataBind()
            ddlShops.Items.Insert(0, "Select")
            dv.Dispose()
            Session("obj") = oModifyWoProduct
            txtEndDate.ReadOnly = True
            txtProductCodeOriginal.ReadOnly = True
            txtNewProductCode.ReadOnly = True
            oModifyWoProduct = Nothing
            dv = Nothing
        End If
    End Sub

    Private Sub txtStartDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStartDate.TextChanged
        Try
            CType(Session("obj"), PCO.ModifyWoProduct).StartDate = CDate(txtStartDate.Text)
            Dim dtEnd As Date
            dtEnd = CType(Session("obj"), PCO.ModifyWoProduct).StartDate
            While dtEnd.AddDays(1).Month = dtEnd.Month
                dtEnd = dtEnd.AddDays(1)
            End While
            txtEndDate.Text = dtEnd.Date
            CType(Session("obj"), PCO.ModifyWoProduct).EndDate = dtEnd
            dtEnd = Nothing
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtEndDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEndDate.TextChanged
        ' auto calculated based on start date, any input to be rejected.
        txtEndDate.Text = ""
        Exit Sub
    End Sub

    Private Sub ddlShops_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlShops.SelectedIndexChanged
        Dim dv As New DataView()
        Try
            If ddlShops.SelectedItem.Text <> "Select" Then
                CType(Session("obj"), PCO.ModifyWoProduct).ShopCode = ddlShops.SelectedItem.Value
                dv.Table = CType(Session("obj"), PCO.ModifyWoProduct).WorkOrderList
                dv.Sort = "Product_code asc"
                ddlWo.DataSource = dv
                ddlWo.DataTextField = "Product_code"
                ddlWo.DataValueField = "Number"
                ddlWo.DataBind()
                ddlWo.Items.Insert(0, "Select")
            Else
                Throw New Exception("Select Shop")
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dv.Dispose()
            dv = Nothing
        End Try
    End Sub

    Private Sub ddlWo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlWo.SelectedIndexChanged
        Try
            CType(Session("obj"), PCO.ModifyWoProduct).GetWoDetails(ddlWo.SelectedItem.Value)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        lblWoNumber.Text = ddlWo.SelectedItem.Value
        lblWoQty.Text = CType(Session("obj"), PCO.ModifyWoProduct).Wo.WoQty
        lblProduced.Text = CType(Session("obj"), PCO.ModifyWoProduct).Wo.ProducedQty
        txtProductCodeOriginal.Text = CType(Session("obj"), PCO.ModifyWoProduct).Wo.ProductCode
        txtNewProductCode.ReadOnly = IIf(lblProduced.Text = "", 0, Val(lblProduced.Text)) > 0
        btnSubmit.Enabled = txtNewProductCode.ReadOnly = False
        txtAuthorisationInfo.ReadOnly = txtNewProductCode.ReadOnly = True
    End Sub

    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        lblMessage.Text = ""
        If IIf(lblProduced.Text = "", 0, Val(lblProduced.Text)) > 0 Then
            btnSubmit.Text = "Check"
            lblMessage.Text = "Produced Qty is available. Product Code cannot be changed"
            Exit Sub
        Else
            Dim dv As New DataView()
            dv.Table = CType(Session("obj"), PCO.ModifyWoProduct).WorkOrderList
            dv.RowFilter = "Product_code = '" & txtNewProductCode.Text.Trim & "'"
            If dv.Count = 0 Then
                If btnSubmit.Text <> "Save" Then
                    btnSubmit.Text = "Save"
                    Exit Sub
                End If
            Else
                lblMessage.Text = "Wo : " & dv(0)("Number") & " already available for this product"
                btnSubmit.Text = "Check"
            End If
            dv = Nothing
        End If
        If btnSubmit.Text = "Save" Then
            Dim blnDone As Boolean
            Try
                If lblEmpCode.Text = "" OrElse txtNewProductCode.Text = "" OrElse lblWoNumber.Text = "" OrElse txtProductCodeOriginal.Text = "" Then
                    Exit Try
                Else
                    blnDone = CType(Session("obj"), PCO.ModifyWoProduct).ProductModify(txtNewProductCode.Text.Trim, lblEmpCode.Text, lblWoNumber.Text, CDate(txtStartDate.Text), CDate(txtEndDate.Text), txtProductCodeOriginal.Text, Left(txtAuthorisationInfo.Text.Trim.ToUpper, 50))
                End If
            Catch exp As Exception
                lblMessage.Text = "Insufficient Data to save : " & exp.Message
            End Try
            If blnDone Then
                If blnDone Then
                    lblMessage.Text = "Product Code of WO : " & lblWoNumber.Text & " changed from " & txtProductCodeOriginal.Text & " to " & txtNewProductCode.Text
                Else
                    lblMessage.Text = "Failed : Product Code of WO : " & lblWoNumber.Text & " Change from " & txtProductCodeOriginal.Text & " to " & txtNewProductCode.Text
                End If
            End If
            blnDone = Nothing
        Else
            Exit Sub
        End If
    End Sub
End Class

