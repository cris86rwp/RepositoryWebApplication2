Public Class LateWorkOrderRelease
    Inherits System.Web.UI.Page
    Protected WithEvents lblEmpCode As System.Web.UI.WebControls.Label
    Protected WithEvents txtWorkOrder As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents txtProductCode As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtWoQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents rfvQty As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents rfvProdCode As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents rfvwo As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents rvQty As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents dgData As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblSlNo As System.Web.UI.WebControls.Label
    Protected WithEvents lblHelp As System.Web.UI.WebControls.Label
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
        lblSlNo.Visible = False
        If Page.IsPostBack = False Then
            lblSlNo.Text = 0

            Session("UserID") = "078844"
            lblEmpCode.Text = ""
            Try
                Dim oEmp As New rwfGen.Employee()
                If oEmp.Check(Session("UserID"), "PCOPCO", "MMS") = True Then
                    lblEmpCode.Text = Session("UserID") & ""
                    btnSave.Visible = True
                End If
                oEmp = Nothing
            Catch exp As Exception
                lblMessage.Text = exp.Message
                btnSave.Visible = False
            End Try
        End If
    End Sub
    Private Sub txtWorkOrder_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWorkOrder.TextChanged
        lblMessage.Text = ""
        txtWorkOrder.Text = txtWorkOrder.Text.ToUpper.Trim
        Try
            ValidateWo()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If txtWorkOrder.Text = "" Then Exit Sub
        Try
            populateGrid()
            If dgData.Items.Count > 0 Then
                lblMessage.Text = "Late " & lblMessage.Text
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub populateGrid()
        Try
            dgData.DataSource = PCO.tables.populateGrid(txtWorkOrder.Text)
            dgData.DataBind()
            dgData.SelectedIndex = -1
        Catch exp As Exception
            dgData.DataSource = Nothing
            dgData.DataBind()
        End Try
    End Sub
    Private Sub ValidateWo()
        If PCO.tables.ValidateWo(txtWorkOrder.Text.Trim) Then
            txtWorkOrder.Text = ""
        End If
    End Sub
    Private Sub txtProductCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProductCode.TextChanged
        lblMessage.Text = ""
        If txtWorkOrder.Text = "" Then
            lblMessage.Text = "Enter Work Order first"
            txtProductCode.Text = ""
            Exit Sub
        Else
            Try
                ValidateProduct()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If

    End Sub
    Private Sub ValidateProduct()
        Dim blnvalidWo As Boolean
        Try
            blnvalidWo = PCO.tables.ValidateProduct(txtWorkOrder.Text, txtProductCode.Text)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If blnvalidWo = False Then
            txtWorkOrder.Text = ""
            txtProductCode.Text = ""
            Throw New Exception("Invalid Work Order(wo exits for the product)")
        End If
        blnvalidWo = Nothing
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        If Val(lblSlNo.Text) = 0 Then
            Try
                ValidateWo()
                ValidateProduct()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
        If lblMessage.Text <> "" Then
            Exit Sub
        End If
        If lblEmpCode.Text = "" Then
            Exit Sub
        End If
        Dim blnDone As Boolean
        Try
            blnDone = New PCO.PCO().ChangeProduct(txtWorkOrder.Text, txtProductCode.Text, lblEmpCode.Text, txtWoQty.Text, Val(lblSlNo.Text))
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            If blnDone Then
                lblMessage.Text = "Saved"
            Else
                lblMessage.Text &= ". Not Saved"
            End If
            lblSlNo.Text = 0
        End Try
        If blnDone Then
            Try
                populateGrid()
            Catch exp As Exception
                lblMessage.Text = "Grid Population Error: " & exp.Message
            End Try
        End If
        blnDone = Nothing
    End Sub

    Private Sub txtWoQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWoQty.TextChanged
        If Val(txtWoQty.Text) <= 0 Then
            txtWoQty.Text = ""
        End If
    End Sub

    Private Sub dgData_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgData.ItemCommand
        lblMessage.Text = ""
        lblSlNo.Text = 0
        Try
            Select Case e.CommandName
                Case "Select"
                    txtProductCode.Text = e.Item.Cells(2).Text
                    txtWoQty.Text = e.Item.Cells(5).Text
                    lblSlNo.Text = e.Item.Cells(10).Text
            End Select
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
End Class
