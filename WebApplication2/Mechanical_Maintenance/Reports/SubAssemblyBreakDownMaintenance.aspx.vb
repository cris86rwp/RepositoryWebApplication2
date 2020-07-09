Public Class SubAssemblyBreakDownMaintenance
    Inherits System.Web.UI.Page
    Protected WithEvents txtFromDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents rfv1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtToDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents rfv2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents cboBD_Type As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboLocation As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboMachineCode As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlSubAssembly As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents btnReport As System.Web.UI.WebControls.Button
    Protected WithEvents lblGrp As System.Web.UI.WebControls.Label
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList
    Shared themeValue As String

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
    Private Sub Page_PreInit(ByVal sender As Object, ByVal e As EventArgs)
        Page.Theme = themeValue
    End Sub

    Public Sub New()
        AddHandler PreInit, New EventHandler(AddressOf Page_PreInit)
    End Sub

    Protected Sub dd1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        themeValue = Dd1.SelectedItem.Value
        Response.Redirect(Request.Url.ToString())

    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Not Page.IsPostBack Then
            lblGrp.Visible = False
            Session("group") = "EW1"
            lblGrp.Text = Session("group")
            PopulateBreakDownTypes()
            PopulateLocation()
            PopulateMachineCode()
        End If
    End Sub

    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click
        PrintableReport()
    End Sub

    Private Sub PrintableReport()
        If cboLocation.SelectedIndex = 0 Then
            lblMessage.Text = "please select Location !"
        Else
            Dim dt As Date
            Try
                dt = CDate(txtFromDate.Text)
            Catch
                lblMessage.Text = "Enter date in 'dd/mm/yyyy' Format"
                txtFromDate.Text = ""
                Exit Sub
            End Try

            Try
                dt = CDate(txtToDate.Text)
            Catch
                lblMessage.Text = "Enter date in 'dd/mm/yyyy' Format"
                txtToDate.Text = ""
                Exit Sub
            End Try

            Dim strRptName, strRptFormula, strServer, strPathName, strRptNameWithPath As String

            strServer = Server.MachineName
            strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=8008&user0=sa&password0=sadev123"
            strPathName &= "&promptonrefresh=0&prompt0=" & lblGrp.Text.Trim & ""
            strPathName &= "&prompt1=DateTime(" & CDate(txtFromDate.Text).Year & "," & CDate(txtFromDate.Text).Month & "," & CDate(txtFromDate.Text).Day & ", 00, 00, 00)"
            strPathName &= "&prompt2=DateTime(" & CDate(txtToDate.Text).Year & "," & CDate(txtToDate.Text).Month & "," & CDate(txtToDate.Text).Day & ", 00, 00, 00)"
            strPathName &= "&prompt3=" & CStr(cboLocation.SelectedItem.Value.Trim) & ""
            strPathName &= "&prompt4=" & CStr(IIf((cboMachineCode.SelectedItem.Text.ToUpper <> "ALL"), cboMachineCode.SelectedItem.Value.Trim, "ALL")) & ""
            strPathName &= "&prompt5=" & CStr("ALL") & ""
            strPathName &= "&prompt6=" & CStr(IIf((cboBD_Type.SelectedItem.Text.ToUpper <> "ALL"), cboBD_Type.SelectedItem.Value.Trim, "ALL")) & ""
            strPathName &= "&prompt7=" & 2 & ""
            strPathName &= "&prompt8=" & Val(0) & ""
            Response.Redirect(strPathName)
        End If
    End Sub

    Private Sub PopulateBreakDownTypes()
        Try
            cboBD_Type.DataSource = Maintenance.tables.CodeType
            cboBD_Type.DataTextField = "description"
            cboBD_Type.DataValueField = "code_type"
            cboBD_Type.DataBind()
            cboBD_Type.Items.Insert(0, "ALL")
            cboBD_Type.SelectedIndex = 0
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub PopulateLocation()
        Try
            'cboLocation.DataSource = Maintenance.tables.PopulateLocation
            'cboLocation.DataTextField = "description"
            cboLocation.DataSource = Maintenance.tables.ShopCode(lblGrp.Text)
            cboLocation.DataTextField = "grp"
            cboLocation.DataValueField = "code"
            cboLocation.DataBind()
            cboLocation.Items.Insert(0, "ALL")
            cboLocation.SelectedIndex = 0
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub PopulateMachineCode()
        Try
            cboMachineCode.DataSource = Maintenance.tables.PopulateMachineCode(cboLocation.SelectedItem.Value.Trim)
            cboMachineCode.DataTextField = "desc1"
            cboMachineCode.DataValueField = "machine_code"
            cboMachineCode.DataBind()
            cboMachineCode.Items.Insert(0, "ALL")
            cboMachineCode.SelectedIndex = 0
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub cboLocation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLocation.SelectedIndexChanged
        PopulateMachineCode()
    End Sub

    Private Sub cboMachineCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMachineCode.SelectedIndexChanged
        PopulateSubAssembly()
    End Sub
    Private Sub PopulateSubAssembly()
        ddlSubAssembly.Items.Clear()
        Dim dt As New DataTable()
        Try
            dt = Maintenance.tables.PopulateSubAssembly(cboMachineCode.SelectedItem.Value.Trim)
            ddlSubAssembly.DataSource = dt
            ddlSubAssembly.DataValueField = dt.Columns("code").ColumnName
            ddlSubAssembly.DataTextField = dt.Columns("description").ColumnName
            ddlSubAssembly.DataBind()
            ddlSubAssembly.Items.Insert(0, "All")
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
        End Try
    End Sub


End Class
