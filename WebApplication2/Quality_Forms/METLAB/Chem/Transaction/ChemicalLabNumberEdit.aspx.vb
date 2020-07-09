Public Class ChemicalLabNumberEdit
    Inherits System.Web.UI.Page
    Protected WithEvents ddlLabNumber As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblLabTestName As System.Web.UI.WebControls.Label
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents lblUser As System.Web.UI.WebControls.Label
    Protected WithEvents txtTestedBy As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDBR As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSampleBatchNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSampleNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtBatchNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSupplier As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtLorry As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtReferenceNote As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtremarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnUpdate As System.Web.UI.WebControls.Button
    Protected WithEvents rblResult As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtTestedDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents chkPOP As System.Web.UI.WebControls.CheckBox
    Protected WithEvents txtExpectedDt As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label

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

        ' Page.Theme = themeValue
        Page.Theme = Session("Theme")
    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None
        'Put user code to initialize the page here
        If Not IsPostBack Then
            lblUser.Text = Session("UserID")
            Try
                GetLabNumber()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub
    Private Sub GetLabNumber()
        Dim dt As DataTable
        dt = metLab.tables.GetSavedLabNumbersForEdit
        ddlLabNumber.DataSource = dt
        ddlLabNumber.DataTextField = dt.Columns(1).ColumnName
        ddlLabNumber.DataValueField = dt.Columns(0).ColumnName
        ddlLabNumber.DataBind()
        lblLabTestName.Text = ddlLabNumber.SelectedItem.Value
        GetLabDetails()
    End Sub

    Private Sub ddlLabNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlLabNumber.SelectedIndexChanged
        lblMessage.Text = ""
        lblLabTestName.Text = ddlLabNumber.SelectedItem.Value
        Try
            GetLabDetails()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub GetLabDetails()
        Dim dt As DataTable
        Try
            dt = metLab.tables.GetLabNumbersDetails(ddlLabNumber.SelectedItem.Value)
            lblUser.Text = Session("UserID")
            txtTestedBy.Text = dt.Rows(0)("tested_by")
            txtNumber.Text = dt.Rows(0)("idn_number")
            txtDBR.Text = dt.Rows(0)("dbr_number")
            txtSampleBatchNo.Text = dt.Rows(0)("sample_batch_number")
            txtSampleNo.Text = dt.Rows(0)("sample_number")
            txtBatchNo.Text = dt.Rows(0)("BatchNo")
            txtSupplier.Text = dt.Rows(0)("supplier")
            txtLorry.Text = dt.Rows(0)("lorry_number")
            txtReferenceNote.Text = dt.Rows(0)("reference_note")
            txtremarks.Text = dt.Rows(0)("remarks")
            txtTestedDate.Text = IIf(IsDBNull(dt.Rows(0)("result_date")), Now.Date, dt.Rows(0)("result_date"))
            txtExpectedDt.Text = IIf(IsDBNull(dt.Rows(0)("expected_test_date")), Now.Date, dt.Rows(0)("expected_test_date"))
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        lblMessage.Text = ""
        Try
            Dim POP As String = IIf(chkPOP.Checked = True, "1", "0")
            lblMessage.Text = New metLab.ChemicalTesting().UpdateLabNumber(ddlLabNumber.SelectedItem.Value, txtremarks.Text.Trim, txtNumber.Text.Trim, txtDBR.Text.Trim, txtTestedBy.Text.Trim, txtSampleBatchNo.Text.Trim, txtSampleNo.Text.Trim, txtSupplier.Text.Trim, txtLorry.Text.Trim, txtReferenceNote.Text.Trim, lblUser.Text, txtBatchNo.Text, CDate(txtTestedDate.Text), rblResult.SelectedItem.Text, POP, CDate(txtExpectedDt.Text))
            Clear()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub Clear()
        txtNumber.Text = ""
        txtDBR.Text = ""
        txtSampleBatchNo.Text = ""
        txtReferenceNote.Text = ""
        txtSampleNo.Text = ""
        txtSupplier.Text = ""
        txtLorry.Text = ""
        txtTestedBy.Text = ""
        txtremarks.Text = ""
        txtBatchNo.Text = ""
    End Sub
End Class
