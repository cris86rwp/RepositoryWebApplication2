Public Class NewMachineryMasterEdit
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents txtDescription As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtAMBasedate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtManufacturer As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtModel As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtVendor As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPO As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPODt As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCost As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDtInService As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtWarrantyFrom As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtWarrantyTo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMachine As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
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

        End If
    End Sub
    Private Sub clear()
        txtDescription.Text = ""
        txtAMBasedate.Text = ""
        txtManufacturer.Text = ""
        txtModel.Text = ""
        txtVendor.Text = ""
        txtPO.Text = ""
        txtPODt.Text = ""
        txtCost.Text = ""
        txtDtInService.Text = ""
        txtWarrantyFrom.Text = ""
        txtWarrantyTo.Text = ""
    End Sub
    Private Sub txtMachine_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMachine.TextChanged
        lblMessage.Text = ""
        If txtMachine.Text.Trim.Length = 0 Then
            lblMessage.Text = "Please enter Machine Code !"
        Else
            txtMachine.Text = txtMachine.Text.ToUpper
            clear()
            Dim dt As DataTable
            Try
                dt = Maintenance.tables.MachineDetails(txtMachine.Text.ToUpper)
                If dt.Rows.Count > 0 Then
                    txtDescription.Text = dt.Rows(0)("description") & ""
                    txtAMBasedate.Text = dt.Rows(0)("am_basedate") & ""
                    txtManufacturer.Text = dt.Rows(0)("manufacturer") & ""
                    txtModel.Text = dt.Rows(0)("model_name") & ""
                    txtVendor.Text = dt.Rows(0)("supplier_code") & ""
                    txtPO.Text = dt.Rows(0)("po_number") & ""
                    txtPODt.Text = dt.Rows(0)("po_date") & ""
                    txtCost.Text = dt.Rows(0)("original_cost") & ""
                    txtDtInService.Text = dt.Rows(0)("inservice_date") & ""
                    txtWarrantyFrom.Text = dt.Rows(0)("warranty_from") & ""
                    txtWarrantyTo.Text = dt.Rows(0)("warranty_to") & ""
                Else
                    lblMessage.Text = "InValid Machine Code !"
                End If
            Catch exp As Exception
                dt = Nothing
                lblMessage.Text = exp.Message
            Finally
                'dt.Dispose()
                dt = Nothing
            End Try
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        Dim done As Boolean
        Dim am_basedate, po_date, warranty_from, warranty_to, txtDtInService As Date
        Try
            Try
                am_basedate = CDate(txtAMBasedate.Text)
            Catch exp As Exception
                am_basedate = CDate("1900-01-01")
            End Try
            Try
                txtDtInService = CDate(txtPODt.Text)
            Catch exp As Exception
                txtDtInService = CDate("1900-01-01")
            End Try
            Try
                po_date = CDate(txtPODt.Text)
            Catch exp As Exception
                po_date = CDate("1900-01-01")
            End Try
            Try
                warranty_from = CDate(txtWarrantyFrom.Text)
            Catch exp As Exception
                warranty_from = CDate("1900-01-01")
            End Try
            Try
                warranty_to = CDate(txtWarrantyTo.Text)
            Catch exp As Exception
                warranty_to = CDate("1900-01-01")
            End Try
            done = New Maintenance.Machinery().MachineEdit(txtMachine.Text, txtDescription.Text.Trim, am_basedate, txtManufacturer.Text.Trim, txtModel.Text, txtVendor.Text, txtPO.Text.Trim, po_date, Val(txtCost.Text.Trim), txtDtInService, warranty_from, warranty_to)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If done Then
            lblMessage.Text = "Data Updated !"
            clear()
            txtMachine.Text = ""
        Else
            lblMessage.Text = "Data Updation Failed !"
        End If
    End Sub
End Class
