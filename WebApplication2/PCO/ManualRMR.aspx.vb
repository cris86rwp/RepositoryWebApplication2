Public Class ManualRMR
    Inherits System.Web.UI.Page
    Protected WithEvents lblMode As System.Web.UI.WebControls.Label
    Protected WithEvents lblOldPassword As System.Web.UI.WebControls.Label
    Protected WithEvents txtOldPassword As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblNewPassword As System.Web.UI.WebControls.Label
    Protected WithEvents txtNewPassword As System.Web.UI.WebControls.TextBox
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
    Protected WithEvents btnChange As System.Web.UI.WebControls.Button
    Protected WithEvents Panel2 As System.Web.UI.WebControls.Panel
    Protected WithEvents btnGenerate As System.Web.UI.WebControls.Button
    Protected WithEvents btnLogin As System.Web.UI.WebControls.Button
    Protected WithEvents txtPLQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents RangeValidator1 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents btnCancel1 As System.Web.UI.WebControls.Button
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents btnLogOut As System.Web.UI.WebControls.Button
    Protected WithEvents grdView As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblWorkOrder As System.Web.UI.WebControls.Label
    Protected WithEvents lblShopCode As System.Web.UI.WebControls.Label
    Protected WithEvents lblPLNumber As System.Web.UI.WebControls.Label
    Protected WithEvents lblRouteCode As System.Web.UI.WebControls.Label
    Protected WithEvents lblRouteSequence As System.Web.UI.WebControls.Label
    Protected WithEvents lblQuantity As System.Web.UI.WebControls.Label
    Protected WithEvents lblUser As System.Web.UI.WebControls.Label
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents ddlWorkorder As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlShopCode As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlPlNumber As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlRouteCode As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlRouteSeq As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblPLDetails As System.Web.UI.WebControls.Label
    Protected WithEvents lblWarning As System.Web.UI.WebControls.Label
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
        lblPLDetails.Visible = True
        lblUser.Text = Session("UserID")
        'lblUser.Text = "014277"
        'lblUser.Text = "078844"
        lblMessage.Text = ""
        lblWarning.Text = ""
        btnChange.Visible = False
        btnLogOut.Visible = False
        If Not Page.IsPostBack Then
            If PCO.tables.AuthorisedUserID(lblUser.Text).Trim <> lblUser.Text Then
                btnLogin.Enabled = True
                btnChange.Visible = False
                lblMessage.Text = "Only manual_RMR_Authorities have authority to generate the Manual RMR's"
            Else
                lblMessage.Text = "Please reverify your password"
            End If
        End If
    End Sub

    Private Sub btnChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChange.Click
        lblOldPassword.Text = "Old Password"
        lblNewPassword.Text = "New Password"
        lblNewPassword.Visible = True
        txtNewPassword.Visible = True
        btnLogin.Text = "Save"
        btnChange.Visible = False
    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        If btnLogin.Text <> "Save" Then
            If txtOldPassword.Text = "" Then
                lblMessage.Text = "Please Enter Password"
                Exit Sub
            End If
            Dim Login As Boolean
            Login = False
            Dim Password As String = PCO.tables.AuthorisedUserIDPassword(lblUser.Text.Trim)
            If txtOldPassword.Text = Password Then
                Login = True
            Else
                lblMessage.Text = "Inavlid Password"
                Exit Sub
            End If
            Login = True
            Try
                If Login Then
                    Panel1.Visible = False
                    Panel2.Visible = True
                    lblMessage.Text = ""
                    PrepareForGeneration()
                End If
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
            Login = Nothing
        Else
            If txtOldPassword.Text <> PCO.tables.AuthorisedUserIDPassword(lblUser.Text.Trim) Then
                lblMessage.Text = "Invalid Password"
                Exit Sub
            End If
            Try
                If New PCO.PCO().UpdateUserPassword(txtNewPassword.Text.Trim, lblUser.Text) Then
                    lblOldPassword.Text = "Password"
                    lblNewPassword.Text = "New Password"
                    lblNewPassword.Visible = False
                    txtNewPassword.Visible = False
                    btnLogin.Text = "Login"
                    btnChange.Visible = True
                    lblMessage.Text = "Password is been saved Please Login"
                End If
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub

    Private Sub PrepareForGeneration()
        FillWorkOrder()
    End Sub

    Private Sub FillWorkOrder()
        Try
            Dim dt As DataTable
            dt = PCO.tables.FillWorkOrder
            ddlWorkorder.Items.Clear()
            ddlWorkorder.DataSource = dt
            ddlWorkorder.DataTextField = dt.Columns("WOtext").ColumnName
            ddlWorkorder.DataValueField = dt.Columns("WOvalue").ColumnName
            ddlWorkorder.DataBind()
            ddlWorkorder.Items.Insert(0, "Select")
            If ddlWorkorder.Items.Count = 2 Then
                ddlWorkorder.SelectedIndex = 1
                FillShopCode()
            End If
            dt.Dispose()
            dt = Nothing
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub FillShopCode()
        If ddlWorkorder.SelectedIndex = 0 Then
            lblMessage.Text = "Please Select the Route Sequence"
            Exit Sub
        Else
            ddlPlNumber.Items.Clear()
            ddlRouteCode.Items.Clear()
            ddlRouteSeq.Items.Clear()
        End If
        Try
            Dim dt As DataTable = PCO.tables.FillShopCode(ddlWorkorder.SelectedItem.Value.Trim)
            ddlShopCode.Items.Clear()
            ddlShopCode.DataSource = dt
            ddlShopCode.DataTextField = dt.Columns("ShopText").ColumnName
            ddlShopCode.DataValueField = dt.Columns("ShopValue").ColumnName
            ddlShopCode.DataBind()
            ddlShopCode.Items.Insert(0, "Select")
            dt.Dispose()
            If ddlShopCode.Items.Count = 2 Then
                ddlShopCode.SelectedIndex = 1
                FillPLNumber()
            End If
            dt = Nothing
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub FillPLNumber()
        If ddlPlNumber.SelectedIndex = 0 Then
            lblPLDetails.Text = ""
            txtPLQty.Text = ""
        Else
            ddlRouteCode.Items.Clear()
            ddlRouteSeq.Items.Clear()
        End If
        Dim arr As Array
        arr = Split(ddlWorkorder.SelectedItem.Text, ":")
        Dim dt As DataTable
        Try
            dt = PCO.tables.FillPlNumber(CStr(arr(1)).Trim, ddlShopCode.SelectedItem.Value)
            ddlPlNumber.Items.Clear()
            ddlPlNumber.DataSource = dt
            ddlPlNumber.DataTextField = dt.Columns("text").ColumnName
            ddlPlNumber.DataValueField = dt.Columns("value").ColumnName
            ddlPlNumber.DataBind()
            ddlPlNumber.Items.Insert(0, "Select")
            dt.Dispose()
            If ddlPlNumber.Items.Count = 2 Then
                ddlPlNumber.SelectedIndex = 1
                FillRouteCode()
            End If
            arr = Nothing
            dt = Nothing
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub FillRouteCode()
        If ddlPlNumber.SelectedIndex = 0 Then
            lblMessage.Text = "Please Select the Pl Number"
            Exit Sub
        Else
            ddlRouteSeq.Items.Clear()
        End If
        Dim pl_number As String
        Dim arr As Array
        arr = Split(ddlPlNumber.SelectedItem.Text, ":")
        pl_number = CStr(arr(0)).Trim
        Dim dt As DataTable
        Try
            dt = PCO.tables.FillRouteCode(ddlWorkorder.SelectedItem.Value.Trim, ddlShopCode.SelectedItem.Value.Trim, pl_number)
            ddlRouteCode.Items.Clear()
            ddlRouteCode.DataSource = dt
            ddlRouteCode.DataTextField = dt.Columns("text").ColumnName
            ddlRouteCode.DataValueField = dt.Columns("text").ColumnName
            ddlRouteCode.DataBind()
            ddlRouteCode.Items.Insert(0, "Select")
            dt.Dispose()
            If ddlRouteCode.Items.Count = 2 Then
                ddlRouteCode.SelectedIndex = 1
                FillRouteSequence()
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        pl_number = Nothing
        arr = Nothing
        dt = Nothing
    End Sub

    Private Sub FillRouteSequence()
        If ddlRouteCode.SelectedIndex = 0 Then
            lblMessage.Text = "Please Select the Route Code"
            Exit Sub
        Else
            lblPLDetails.Text = ""
            txtPLQty.Text = ""
        End If
        Dim pl_number As String
        Dim arr As Array
        arr = Split(ddlPlNumber.SelectedItem.Text, ":")
        pl_number = CStr(arr(0)).Trim
        Dim dt As DataTable
        Try
            dt = PCO.tables.FillRouteSequence(ddlWorkorder.SelectedItem.Value.Trim, ddlShopCode.SelectedItem.Value, pl_number.Trim, ddlRouteCode.SelectedItem.Value)
            ddlRouteSeq.Items.Clear()
            ddlRouteSeq.DataSource = dt
            ddlRouteSeq.DataTextField = dt.Columns("text").ColumnName
            ddlRouteSeq.DataValueField = dt.Columns("text").ColumnName
            ddlRouteSeq.DataBind()
            ddlRouteSeq.Items.Insert(0, "Select")
            dt.Dispose()
            If ddlRouteSeq.Items.Count = 2 Then
                ddlRouteSeq.SelectedIndex = 1
                GetPLDetails()
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        pl_number = Nothing
        arr = Nothing
        dt = Nothing
    End Sub

    Private Sub GetPLDetails()
        Dim workorder, product_code, route_code, route_sequence, shop_code, pl_number, status As String
        Dim dt As DataTable
        Try
            workorder = ddlWorkorder.SelectedItem.Value
            Dim arr As Array
            arr = Split(ddlWorkorder.SelectedItem.Text, ":")
            product_code = CStr(arr(1)).Trim
            route_code = ddlRouteCode.SelectedItem.Value
            route_sequence = ddlRouteSeq.SelectedItem.Value
            shop_code = ddlShopCode.SelectedItem.Value
            arr = Split(ddlPlNumber.SelectedItem.Text, ":")
            pl_number = CStr(arr(0)).Trim
            arr = Split(ddlPlNumber.SelectedItem.Value, ":")
            status = CStr(arr(1)).Trim
            dt = PCO.tables.GetPLDetails(workorder, product_code, route_code, route_sequence, shop_code, pl_number, status)
            Dim strUnit As String
            Dim WQ, GQ, AQ As Double
            strUnit = Trim(dt.Rows(0)(3))
            WQ = dt.Rows(0)(0)
            GQ = dt.Rows(0)(1)
            AQ = dt.Rows(0)(2)
            If AQ < 0 Then
                viewstate("AQ") = CStr(0)
            Else
                viewstate("AQ") = CStr(AQ)
            End If
            lblPLDetails.Text = "Quantity as Per WO :" & CStr(WQ) & " " & strUnit & "<br>"
            lblPLDetails.Text &= "RMR Generated Quantity :" & CStr(GQ) & " " & strUnit & "<br>"
            lblPLDetails.Text &= "Quantity allowed for Manual RMR:" & CStr(AQ) & " " & strUnit & "<br>"
            strUnit = Nothing
            WQ = Nothing
            GQ = Nothing
            AQ = Nothing
            arr = Nothing
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
#Disable Warning BC42104 ' Variable is used before it has been assigned a value
            dt.Dispose()
#Enable Warning BC42104 ' Variable is used before it has been assigned a value
            dt = Nothing
        End Try
        workorder = Nothing
        product_code = Nothing
        route_code = Nothing
        route_sequence = Nothing
        shop_code = Nothing
        pl_number = Nothing
        status = Nothing
    End Sub

    Private Sub ddlWorkorder_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlWorkorder.SelectedIndexChanged
        If ddlWorkorder.SelectedIndex = 0 Then
            ddlPlNumber.Items.Clear()
            ddlRouteCode.Items.Clear()
            ddlRouteSeq.Items.Clear()
            ddlShopCode.Items.Clear()
            lblPLDetails.Text = ""
            txtPLQty.Text = ""
        Else
            FillShopCode()
        End If
    End Sub

    Private Sub ddlShopCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlShopCode.SelectedIndexChanged
        If ddlShopCode.SelectedIndex = 0 Then
            ddlPlNumber.Items.Clear()
            ddlRouteCode.Items.Clear()
            ddlRouteSeq.Items.Clear()
            lblPLDetails.Text = ""
            lblPLDetails.Text = ""
            txtPLQty.Text = ""
        Else
            FillPLNumber()
        End If
    End Sub

    Private Sub ddlPlNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlPlNumber.SelectedIndexChanged
        txtPLQty.Text = ""
        If ddlPlNumber.SelectedIndex = 0 Then
            ddlRouteCode.Items.Clear()
            ddlRouteSeq.Items.Clear()
            lblPLDetails.Text = ""
            lblPLDetails.Text = ""
        Else
            FillRouteCode()
        End If
    End Sub

    Private Sub ddlRouteCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlRouteCode.SelectedIndexChanged
        If ddlRouteCode.SelectedIndex = 0 Then
            ddlRouteSeq.Items.Clear()
            lblPLDetails.Text = ""
            lblPLDetails.Text = ""
            txtPLQty.Text = ""
        Else
            FillRouteSequence()
        End If
    End Sub

    Private Sub ddlRouteSeq_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlRouteSeq.SelectedIndexChanged
        If ddlRouteSeq.SelectedIndex = 0 Then
            lblPLDetails.Text = ""
            txtPLQty.Text = ""
        Else
            GetPLDetails()
        End If
    End Sub

    Private Sub btnGenerate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        If btnGenerate.Text = "Generate RMR" Then
            If ddlWorkorder.SelectedIndex = 0 Then
                lblMessage.Text = "Please select Workorder"
                Exit Sub
            End If

            If ddlShopCode.SelectedIndex = 0 Then
                lblMessage.Text = "Please select shop code"
                Exit Sub
            End If

            If ddlPlNumber.SelectedIndex = 0 Then
                lblMessage.Text = "Please select Pl Number "
                Exit Sub
            End If

            If ddlRouteCode.SelectedIndex = 0 Then
                lblMessage.Text = "Please select route code"
                Exit Sub
            End If

            If ddlRouteSeq.SelectedIndex = 0 Then
                lblMessage.Text = "Please select the route sequence"
                Exit Sub
            End If

            If txtPLQty.Text = "" Then
                lblMessage.Text = "Please enter PL Qty"
                Exit Sub
            End If

            Dim AQ As Double
            AQ = viewstate("AQ")

            If CDbl(txtPLQty.Text) > AQ Then
                lblMessage.Text = "PL Qty is out of range"
                Exit Sub
            End If

            lblWarning.Text = "Are you Sure ?"
            btnGenerate.Text = "Yes"
            lblWorkOrder.Text = ddlWorkorder.SelectedItem.Text
            lblShopCode.Text = ddlShopCode.SelectedItem.Text
            lblRouteCode.Text = ddlRouteCode.SelectedItem.Text
            lblRouteSequence.Text = ddlRouteSeq.SelectedItem.Text
            lblQuantity.Text = txtPLQty.Text
            lblPLNumber.Text = ddlPlNumber.SelectedItem.Text
            lblWorkOrder.Visible = True
            lblShopCode.Visible = True
            lblRouteCode.Visible = True
            lblRouteSequence.Visible = True
            lblQuantity.Visible = True
            lblPLNumber.Visible = True
            btnCancel1.Visible = True
            ddlWorkorder.Visible = False
            ddlShopCode.Visible = False
            ddlRouteCode.Visible = False
            ddlRouteSeq.Visible = False
            txtPLQty.Visible = False
            ddlPlNumber.Visible = False
            AQ = Nothing
        Else
            lblMessage.Text = ""
            Dim pl_number, status As String
            Try
                Dim arr As Array = Split(ddlPlNumber.SelectedItem.Text, ":")
                pl_number = CStr(arr(0)).Trim
                arr = Split(ddlPlNumber.SelectedItem.Value, ":")
                status = CStr(arr(1)).Trim
                lblMessage.Text = CDbl(txtPLQty.Text)
                Dim dt As DataTable
                Dim Done As Boolean
                dt = New PCO.PCO().ManualRMR(ddlWorkorder.SelectedItem.Value, ddlShopCode.SelectedItem.Value, pl_number, status, ddlRouteCode.SelectedItem.Value, ddlRouteSeq.SelectedItem.Value, CDbl(txtPLQty.Text), lblUser.Text)
                If dt.Rows.Count > 0 Then
                    Done = True
                    grdView.Visible = True
                    grdView.DataSource = dt
                    grdView.DataBind()
                Else
                    grdView.Visible = False
                End If
                If Done Then
                    btnGenerate.Text = "Generate RMR"
                    ddlPlNumber.Items.Clear()
                    ddlRouteCode.Items.Clear()
                    ddlRouteSeq.Items.Clear()
                    ddlShopCode.Items.Clear()
                    ddlWorkorder.SelectedIndex = 0
                    lblPLDetails.Text = ""
                    txtPLQty.Text = ""
                    btnCancel1.Visible = False
                    lblMessage.Text = "RMR's Generated"
                    lblWorkOrder.Visible = False
                    lblShopCode.Visible = False
                    lblRouteCode.Visible = False
                    lblRouteSequence.Visible = False
                    lblQuantity.Visible = False
                    lblPLNumber.Visible = False
                    ddlWorkorder.Visible = True
                    ddlShopCode.Visible = True
                    ddlRouteCode.Visible = True
                    ddlRouteSeq.Visible = True
                    txtPLQty.Visible = True
                    ddlPlNumber.Visible = True
                Else
                    lblMessage.Text = "RMR's Generation Failed !"
                End If
                arr = Nothing
                dt = Nothing
                Done = Nothing
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
            pl_number = Nothing
            status = Nothing
        End If
    End Sub

    Private Sub btnCancel1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel1.Click
        lblMessage.Text = ""
        ddlPlNumber.Items.Clear()
        ddlRouteCode.Items.Clear()
        ddlRouteSeq.Items.Clear()
        ddlShopCode.Items.Clear()
        ddlWorkorder.SelectedIndex = 0
        lblPLDetails.Text = ""
        txtPLQty.Text = ""
        btnGenerate.Text = "Generate RMR"
        btnCancel1.Visible = False
        lblWorkOrder.Visible = False
        lblShopCode.Visible = False
        lblRouteCode.Visible = False
        lblRouteSequence.Visible = False
        lblQuantity.Visible = False
        lblPLNumber.Visible = False
        ddlWorkorder.Visible = True
        ddlShopCode.Visible = True
        ddlRouteCode.Visible = True
        ddlRouteSeq.Visible = True
        txtPLQty.Visible = True
        ddlPlNumber.Visible = True
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If btnLogin.Text = "Save" Then
            btnChange.Visible = True
            lblOldPassword.Text = "Password:"
            btnLogin.Text = "Login"
            lblNewPassword.Visible = False
            txtNewPassword.Visible = False
        Else
            Response.Redirect("\mms\SelectModule.aspx")
        End If
    End Sub

    Private Sub btnLogOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogOut.Click
        Panel1.Visible = True
        Panel2.Visible = False
        grdView.Visible = False
    End Sub

    Private Sub txtOldPassword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOldPassword.TextChanged

    End Sub

    Private Sub txtNewPassword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNewPassword.TextChanged

    End Sub
End Class
