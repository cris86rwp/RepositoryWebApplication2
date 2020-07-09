Public Class ChemicalTestResultsEdit
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents ddlLabNumber As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel

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
        If IsPostBack = False Then
            Try
                GetLabNumbers()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub
    Private Sub GetLabNumbers()
        ddlLabNumber.Items.Add("Select")
        Dim dt As DataTable
        dt = metLab.tables.GetLabNumbersForEdit
        ddlLabNumber.DataSource = dt
        ddlLabNumber.DataValueField = dt.Columns("lab_number").ColumnName
        ddlLabNumber.DataTextField = dt.Columns("Material").ColumnName
        ddlLabNumber.DataBind()
        ddlLabNumber.Items.Insert(0, "Select")
        dt.Dispose()
    End Sub

    Private Sub ddlLabNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlLabNumber.SelectedIndexChanged
        lblMessage.Text = ""
        Dim i, cnt As Integer
        Try
            DataGrid1.EditItemIndex = -1
            FillGrid()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub DataGrid1_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.EditCommand
        lblMessage.Text = ""
        DataGrid1.EditItemIndex = e.Item.ItemIndex
        FillGrid()
    End Sub

    Private Sub DataGrid1_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.CancelCommand
        DataGrid1.EditItemIndex = -1
        FillGrid()
    End Sub

    Private Sub DataGrid1_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.UpdateCommand
        Dim Objresult_value, ObjRemarks As TextBox
        Try
            Objresult_value = e.Item.Cells(2).Controls(0)
            ObjRemarks = e.Item.Cells(6).Controls(0)
            lblMessage.Text = New metLab.ChemicalTesting().UpdateLabResults(ddlLabNumber.SelectedItem.Value, e.Item.Cells(0).Text, Objresult_value.Text, ObjRemarks.Text)
            DataGrid1.EditItemIndex = -1
            FillGrid()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub FillGrid()
        Dim dt As DataTable
        dt = metLab.tables.GetTestMaterialListForEdit(ddlLabNumber.SelectedItem.Value)
        DataGrid1.DataSource = dt
        DataGrid1.DataBind()
    End Sub
End Class
