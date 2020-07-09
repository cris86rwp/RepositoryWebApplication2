Public Class ChemicalTestResults
    Inherits System.Web.UI.Page
    Protected WithEvents ddlLabNumber As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblMaterial As System.Web.UI.WebControls.Label
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents grdCharacteristics As System.Web.UI.WebControls.DataGrid
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
        dt = metLab.tables.GetLabNumbers
        ddlLabNumber.DataSource = dt
        ddlLabNumber.DataTextField = dt.Columns("lab_number").ColumnName
        ddlLabNumber.DataValueField = dt.Columns("Material").ColumnName
        ddlLabNumber.DataBind()
        ddlLabNumber.Items.Insert(0, "Select")
        dt.Dispose()
    End Sub

    Private Sub ddlLabNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlLabNumber.SelectedIndexChanged
        lblMessage.Text = ""
        lblMaterial.Text = ""
        If ddlLabNumber.SelectedItem.Value = "Select" Then
            lblMessage.Text = "Please select Lab Number !"
        Else
            Dim dt As DataTable
            Dim i, cnt As Integer
            Try
                lblMaterial.Text = ddlLabNumber.SelectedItem.Value
                dt = metLab.tables.GetTestMaterialList(ddlLabNumber.SelectedItem.Text)
                grdCharacteristics.DataSource = dt
                grdCharacteristics.DataBind()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        Dim ChemResults As New metLab.ChemicalTesting()
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim i, cnt As Integer
        Dim item As DataGridItem
        Try
            dt.TableName = "LabResults"
            dt.Columns.Add("LabNumber")
            dt.Columns.Add("CharID")
            dt.Columns.Add("Value")
            dt.Columns.Add("remarks")
            If grdCharacteristics.Items.Count > 0 Then
                For cnt = 0 To grdCharacteristics.Items.Count - 1
                    item = grdCharacteristics.Items(cnt)
                    Dim objTextbox1 As TextBox = item.FindControl("txtValue")
                    Dim objTextbox2 As TextBox = item.FindControl("txtRemarks")
                    dr = dt.NewRow
                    dr("LabNumber") = ddlLabNumber.SelectedItem.Text.Trim
                    dr("CharID") = grdCharacteristics.Items(cnt).Cells(0).Text
                    dr("Value") = objTextbox1.Text.Trim
                    dr("remarks") = objTextbox2.Text.Trim
                    dt.Rows.Add(dr)
                Next
            End If
            ChemResults.LabResults = dt
            ChemResults.SaveLabResults()
            lblMessage.Text = ChemResults.Message
            grdCharacteristics.DataSource = Nothing
            grdCharacteristics.DataBind()
        Catch exp As Exception
            lblMessage.Text &= ChemResults.Message & exp.Message
        End Try
        Try
            GetLabNumbers()
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
    End Sub

    Private Sub PopulateDatatable()

    End Sub
End Class
