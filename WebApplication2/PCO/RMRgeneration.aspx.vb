Public Class RMRgeneration
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents ddlWO As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtRMRDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents rdoStopperPipe As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents lblStopperPipe As System.Web.UI.WebControls.Label
    Protected WithEvents lblProduct_id As System.Web.UI.WebControls.Label
    Protected WithEvents lblWork_order_quantity As System.Web.UI.WebControls.Label
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnGenerateRMR As System.Web.UI.WebControls.Button
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
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
        Session("UserID") = "082421"
        Session("Group") = "PCOPCO"
        If Page.IsPostBack = False Then
            Try
                If Session("UserID") = Nothing Or Session("UserID") = "" Or Session("Group") = Nothing Or Session("Group") = "" Or Session("Group") <> "PCOPCO" Then
                    Response.Redirect("InvalidSession.Aspx")
                    Exit Sub
                End If
            Catch exp As Exception
                Response.Redirect("InvalidSession.Aspx")
                Exit Sub
            End Try
            lblStopperPipe.Visible = False
            rdoStopperPipe.Visible = False
            If Now.Date.Day <= 10 Then
                Try
                    txtRMRDate.Text = PCO.tables.GetRMRDate
                Catch exp As Exception
                    txtRMRDate.Text = Now.Date
                End Try
            Else
                txtRMRDate.Text = Now.Date
            End If
            Try
                populateWO()
                populateWOData()
                populateCompletedWO()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub

    Private Sub populateWO()
        Dim dt As DataTable
        Try
            dt = PCO.tables.populateWO(CDate(txtRMRDate.Text))
            ddlWO.DataSource = dt
            ddlWO.DataTextField = dt.Columns("number").ColumnName
            ddlWO.DataValueField = dt.Columns("number").ColumnName
            ddlWO.DataBind()
            If ddlWO.Items.Count = 0 Then
                ddlWO.Items.Add("Select")
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
#Disable Warning BC42104 ' Variable is used before it has been assigned a value
            dt.Dispose()
#Enable Warning BC42104 ' Variable is used before it has been assigned a value
            dt = Nothing
        End Try
    End Sub

    Private Sub populateWOData()
        Dim dt As DataTable
        Try
            dt = PCO.tables.populateProduct(ddlWO.SelectedItem.Text)
            If dt.Rows.Count > 0 Then
                lblProduct_id.Text = dt.Rows(0)("product_code")
                lblWork_order_quantity.Text = dt.Rows(0)("workorder_quantity")
            End If
            If (Left(lblProduct_id.Text.Trim, 1) = "1" Or Left(lblProduct_id.Text.Trim, 1) = "2") = True Then
                lblStopperPipe.Visible = True
                rdoStopperPipe.Visible = True
                btnGenerateRMR.Enabled = False
            Else
                lblStopperPipe.Visible = False
                rdoStopperPipe.Visible = False
                btnGenerateRMR.Enabled = True
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
#Disable Warning BC42104 ' Variable is used before it has been assigned a value
            dt.Dispose()
#Enable Warning BC42104 ' Variable is used before it has been assigned a value
            dt = Nothing
        End Try
    End Sub

    Private Sub rdoStopperPipe_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoStopperPipe.SelectedIndexChanged
        Dim GenerateRMR As Boolean
        btnGenerateRMR.Enabled = False
        lblMessage.Text = ""
        Try
            GenerateRMR = New PCO.PCO().UpdateStPipe(ddlWO.SelectedItem.Text, rdoStopperPipe.Items(0).Selected, rdoStopperPipe.Items(1).Selected, rdoStopperPipe.Items(0).Text.Trim, rdoStopperPipe.Items(1).Text.Trim)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If GenerateRMR Then
            lblMessage.Text = "Stopper Pipe Pl Number Selection saved successfully"
            btnGenerateRMR.Enabled = True
        Else
            lblMessage.Text = "Stopper Selection failed to be saved for : " & lblMessage.Text
            btnGenerateRMR.Enabled = False
        End If
        GenerateRMR = Nothing
    End Sub

    Private Sub populateCompletedWO()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Try
            DataGrid1.DataSource = PCO.tables.populateCompletedWO
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnGenerateRMR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerateRMR.Click
        lblMessage.Text = ""
        Try
            lblMessage.Text = New PCO.PCO().GenerateRMR(ddlWO.SelectedItem.Text, CDate(txtRMRDate.Text))
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        Try
            populateWOData()
            populateWO()
            populateCompletedWO()
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
    End Sub

    Private Sub txtRMRDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRMRDate.TextChanged
        Try
            Try
                Dim x As Date = CDate(txtRMRDate.Text)
            Catch
                lblMessage.Text = "Please Enter date in DD/MM/YYYY format"
                txtRMRDate.Text = ""
            End Try
            If CDate(txtRMRDate.Text) > Now Then
                lblMessage.Text = "RmR Date Can't Be Greater than Current Date"
                txtRMRDate.Text = ""
            ElseIf CDate(txtRMRDate.Text) < PCO.tables.GetRMRDate Then
                lblMessage.Text = "RmR Date Can't Be Lesser than Last RMR Date"
                txtRMRDate.Text = ""
            Else
                If txtRMRDate.Text <> "" Then
                    If lblMessage.Text <> "" Then
                        lblMessage.Text = ""
                    End If
                End If
                Exit Sub
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub DataGrid1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.ItemCommand
        Try
            Select Case e.CommandName
                Case "Select"
                    DataGrid2.DataSource = Nothing
                    DataGrid2.DataBind()
                    Try
                        DataGrid2.DataSource = PCO.tables.populateCompletedWOList(e.Item.Cells(2).Text)
                        DataGrid2.DataBind()
                    Catch exp As Exception
                        lblMessage.Text = exp.Message
                    End Try
            End Select
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub ddlWO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlWO.SelectedIndexChanged
        lblMessage.Text = ""
        populateWOData()
    End Sub
End Class
