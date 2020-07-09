Public Class MRS_machineCode_Edit
    Inherits System.Web.UI.Page
    Protected WithEvents ddlMcnList As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents lblEmpCode As System.Web.UI.WebControls.Label
    Protected WithEvents rfvMcnCode As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents rfvdate As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtMcnDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents rfvmldno As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtMouldNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents dgData As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblHelp As System.Web.UI.WebControls.Label
    Protected WithEvents chkHelp As System.Web.UI.WebControls.CheckBox
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents BtnSave As System.Web.UI.WebControls.Button
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
    'Shared themeValue As String

    'Public Sub New()

    '    AddHandler PreInit, New EventHandler(AddressOf Page_PreInit)
    'End Sub

    'Private Sub Page_PreInit(ByVal sender As Object, ByVal e As EventArgs)

    '    Page.Theme = themeValue
    'End Sub


    'Protected Sub dd1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
    '    themeValue = Dd1.SelectedItem.Value
    '    Response.Redirect(Request.Url.ToString())

    'End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None
        'Put user code to initialize the page here


        If Page.IsPostBack = False Then
            Dim strHelp As New System.Text.StringBuilder()
            strHelp.Append("1. Input Machining Date in dd/mm/yyyy format")
            strHelp.Append("<BR>")
            strHelp.Append("2. Input Mould Number")
            strHelp.Append("<BR>")
            strHelp.Append("3. Select Machine Code")
            strHelp.Append("<BR>")
            strHelp.Append("4. Click Save button")
            strHelp.Append("<BR>")
            strHelp.Append("<BR>")
            strHelp.Append("<b>If mould has same machine code entered NO RECORDS TO EDIT will be displayed</b>")
            strHelp.Append("<BR>")
            strHelp.Append("<b> else UPDATED message will be displayed</b>")
            strHelp.Append("<BR>")
            strHelp.Append("<BR>")
            strHelp.Append("<b>Data Grid below save button shows moulds edited on the given machining</b>")
            strHelp.Append("<BR>")
            strHelp.Append("<b>  date in descending order</b>")
            lblHelp.Text = strHelp.ToString
            lblHelp.Visible = chkHelp.Checked
            Try
                'Session("UserID") = "078844"
                Dim oEmp As New rwfGen.Employee()
                'If oEmp.Check(Session("UserID"), "MRSMRS") Then
                lblEmpCode.Text = Session("UserID")
                'Else
                '    lblMessage.Text = "Invalid Login"
                'End If
                Dim dt As DataTable = MouldMaster.tables.getMRSMachines
                ddlMcnList.DataSource = dt
                ddlMcnList.DataTextField = dt.Columns("Machine_code").ColumnName
                ddlMcnList.DataValueField = dt.Columns("Machine_code").ColumnName
                ddlMcnList.DataBind()
                ddlMcnList.Items.Insert(0, "Select")
                oEmp = Nothing
                dt = Nothing
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
            strHelp = Nothing
        End If
    End Sub

    Private Sub SaveData()
        Dim dt As Date
        Dim blnSaved As Boolean
        Try
            dt = CDate(txtMcnDate.Text)
            If dt > Today Then
                Throw New Exception("Date Error : Future Date " & dt.ToShortDateString)
            End If
            If IsNothing(ddlMcnList.SelectedItem) OrElse ddlMcnList.SelectedItem Is Nothing OrElse ddlMcnList.SelectedItem.Text = "Select" Then
                Throw New Exception("Machine code is not selected")
            End If
            blnSaved = New MouldMaster.MRSMRS().SaveData(dt, ddlMcnList.SelectedItem.Value, txtMouldNumber.Text.Trim, lblEmpCode.Text)
        Catch exp As Exception
            blnSaved = False
            lblMessage.Text = exp.Message
        Finally
            If blnSaved Then
                lblMessage.Text = "Updated."
            Else
                lblMessage.Text &= ". Not Updated."
            End If
        End Try
        dt = Nothing
        blnSaved = Nothing
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            SaveData()
            PopulateGrid()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub PopulateGrid()
        Dim dt As DataTable
        Try
            dt = MouldMaster.tables.getMouldsMachined(CDate(txtMcnDate.Text))
            dgData.DataSource = dt.DefaultView
            dgData.DataBind()
        Catch exp As Exception
            Throw New Exception("Grid Population Error: " & exp.Message)
        Finally
            dt.Dispose()
            dt = Nothing
        End Try
    End Sub

    Private Sub txtMcnDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMcnDate.TextChanged
        Try
            PopulateGrid()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub chkHelp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHelp.CheckedChanged
        lblHelp.Visible = chkHelp.Checked
    End Sub
End Class
