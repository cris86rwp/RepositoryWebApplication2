Public Class NonRWFWheels
    Inherits System.Web.UI.Page
    Protected WithEvents txtSource As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtWheel As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlProducts As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtFinalInsp As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtBoreDia As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRimThickness As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPlateThickness As System.Web.UI.WebControls.TextBox
    Protected WithEvents rdoCastType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents chkStatus As System.Web.UI.WebControls.CheckBox
    Protected WithEvents dgWheels As System.Web.UI.WebControls.DataGrid
    Protected WithEvents cvDate As System.Web.UI.WebControls.CustomValidator
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTreadDia As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents rfvwheel As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents btnsave As System.Web.UI.WebControls.Button
    Protected WithEvents RFVtreadDia As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtRWFNUmber As System.Web.UI.WebControls.TextBox
    Protected WithEvents TextBox1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Textbox2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtBoreStatus As System.Web.UI.WebControls.TextBox
    Protected WithEvents Textbox3 As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblPressStatus As System.Web.UI.WebControls.Label
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList
    Dim blnPageValid As Boolean
    ' This screen is for add/edit/view/delete for non rwf wheels
    ' for use by clrins for Durgapur wheels supplied through ICF.
    ' Written by : Satish V Itagi 24-02-2005
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
        Session("UserID") = "076355"
        If Page.IsPostBack = False Then
            ViewState("PageValid") = blnPageValid
            txtFinalInsp.Text = Session("UserID")
            txtDate.Text = Now.Date
            populateProducts()
            PopulateGrid()
        End If
        If txtFinalInsp.Text = "" Then
            'Response.Redirect("/wap/invalidSession.aspx")
            Response.Redirect("InvalidSession.aspx")
            Exit Sub
        End If
    End Sub
    Private Sub populateProducts()
        Dim dt As DataTable
        Try
            dt = NonRWFWheel.Products
            ddlProducts.DataSource = dt
            ddlProducts.DataTextField = dt.Columns("Descr").ColumnName
            ddlProducts.DataValueField = dt.Columns("Product_code").ColumnName
            ddlProducts.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
            dt = Nothing
        End Try
    End Sub


    Private Sub txtWheel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWheel.TextChanged
        If txtDate.Text = "" Then
            lblMessage.Text = "Invalid Data"
            Exit Sub
        End If
        If txtWheel.Text.IndexOf("/") >= 0 Then
            lblMessage.Text = "Invalid wheel " & txtWheel.Text
            txtWheel.Text = ""
        ElseIf txtWheel.Text.Trim.Length < 10 Then
            lblMessage.Text = "Invalid wheel " & txtWheel.Text
            txtWheel.Text = ""
        End If
        txtWheel.Text = txtWheel.Text.ToUpper
    End Sub

    Private Sub PopulateGrid(Optional ByVal CurPageNo As Integer = 0, Optional ByVal SortField As String = "sl_no")
        lblMessage.Text = ""
        dgWheels.DataSource = NonRWFWheel.PopulateGrid(CDate(txtDate.Text))
        dgWheels.AllowPaging = True
        dgWheels.AllowSorting = True
        dgWheels.CurrentPageIndex = CurPageNo
        dgWheels.PagerStyle.Mode = PagerMode.NumericPages
        dgWheels.PageSize = 5
        dgWheels.DataBind()
    End Sub

    Private Sub cvDate_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cvDate.ServerValidate
        Dim dt As Date
        Try
            dt = CDate(args.Value)
        Catch exp As Exception
            args.IsValid = False
            viewstate("PageValid") = False
            Exit Sub
        End Try
        If dt > Today Then
            args.IsValid = False
            viewstate("PageValid") = False
            Exit Sub
        End If
        args.IsValid = True
        blnPageValid = True
        viewstate("PageValid") = True
        PopulateGrid()
        dt = Nothing
    End Sub

    Private Sub txtDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged
        PopulateGrid()
    End Sub

    Private Sub dgWheels_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgWheels.PageIndexChanged
        PopulateGrid(e.NewPageIndex)
    End Sub

    Private Sub dgWheels_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgWheels.DeleteCommand
        lblMessage.Text = ""
        Try
            If New NonRWFWheel().DeleteWhl(e.Item.Cells(2).Text.Trim) Then lblMessage.Text = "Deleted : " & e.Item.Cells(2).Text
            PopulateGrid()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If viewstate("PageValid") = False Then
            lblMessage.Text = "cannot be saved"
            Exit Sub
        End If
        If NonRWFWheel.CheckWhl(txtWheel.Text) > 0 Then
            lblMessage.Text = "You cannot modify this record."
            Exit Sub
        End If
        Try
            If New NonRWFWheel().SaveWhl(txtWheel.Text.Trim, rdoCastType.SelectedItem.Text.Trim, txtSource.Text.Trim, txtRWFNUmber.Text, chkStatus.Text.Trim, txtFinalInsp.Text.Trim, ddlProducts.SelectedItem.Text.Trim, txtBoreStatus.Text.Trim, txtBoreDia.Text.Trim, txtRimThickness.Text.Trim, txtTreadDia.Text.Trim, txtPlateThickness.Text.Trim, CDate(txtDate.Text), ddlProducts.SelectedItem.Value) Then lblMessage.Text = "Saved : " & txtWheel.Text
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        Try
            PopulateGrid()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub dgWheels_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgWheels.EditCommand
        FillData(e.Item.Cells(3).Text)
    End Sub
    Private Sub FillData(ByVal RWFNum As String)
        Dim dt As DataTable
        Dim sWhlType As String
        dt = NonRWFWheel.RWFNumDetails(RWFNum)
        If dt.Rows.Count > 0 Then
            txtWheel.Text = dt.Rows(0)("NonRWFWheelNumber")
            txtTreadDia.Text = dt.Rows(0)("thread_diameter")
            txtRWFNUmber.Text = dt.Rows(0)("rwfNumber")
            lblPressStatus.Text = IIf(CStr(dt.Rows(0)("Press_Status")).Trim <> "", "Pressed", "")
            sWhlType = dt.Rows(0)("Description") & "".Trim
            sWhlType = sWhlType.Trim
        End If
        Dim i As Integer
        ddlProducts.ClearSelection()
        For i = 0 To ddlProducts.Items.Count - 1
            If ddlProducts.Items(i).Text.StartsWith(sWhlType) Then
                ddlProducts.Items(i).Selected = True
            End If
        Next
        If IsNothing(ddlProducts.SelectedItem) Then
            ddlProducts.Items(0).Selected = True
        End If
        If lblPressStatus.Text <> "" Then
            btnsave.Enabled = False
            lblMessage.Text = "Already pressed. Contact MIS Centre."
        Else
            ' btnsave is not enabled purposefully
            ' user has to be instructed to reload the page again
        End If
        i = Nothing
        sWhlType = Nothing
        dt = Nothing
    End Sub

    Private Sub txtRWFNUmber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRWFNUmber.TextChanged
        FillData(txtRWFNUmber.Text.Trim)
    End Sub

    Private Sub dgWheels_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgWheels.SortCommand
        PopulateGrid(0, e.SortExpression)
    End Sub
End Class
