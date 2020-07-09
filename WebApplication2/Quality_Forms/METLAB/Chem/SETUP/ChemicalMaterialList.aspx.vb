Public Class ChemicalMaterialList
    Inherits System.Web.UI.Page
    Protected WithEvents rblMaterialType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtMaterial As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents rblBased As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents btnSearch As System.Web.UI.WebControls.Button
    Protected WithEvents txtOn As System.Web.UI.WebControls.TextBox
    Protected WithEvents dgPL As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents dgMaterialList As System.Web.UI.WebControls.DataGrid
    Protected WithEvents pnlName As System.Web.UI.WebControls.Panel
    Protected WithEvents lblName As System.Web.UI.WebControls.Label
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMaterialID As System.Web.UI.WebControls.Label
    Protected WithEvents txtSpec As System.Web.UI.WebControls.TextBox
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
        If Page.IsPostBack = False Then
            pnlName.Visible = False
            lblName.Text = ""
            Try
                fillRBL()
                dgMaterialList.CurrentPageIndex = 0
                FillSavedList()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub
    Private Sub fillRBL()
        rblMaterialType.DataSource = Nothing
        rblMaterialType.DataBind()
        Dim dt As DataTable
        Try
            dt = metLab.tables.GetChemicalTestingTestType
            rblMaterialType.DataSource = dt
            rblMaterialType.DataTextField = dt.Columns(0).ColumnName
            rblMaterialType.DataValueField = dt.Columns(1).ColumnName
            rblMaterialType.DataBind()
            rblMaterialType.SelectedIndex = 0
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            dt = Nothing
        End Try
    End Sub

    Private Sub txtMaterial_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMaterial.TextChanged
        lblMessage.Text = ""
        pnlName.Visible = False
        lblName.Text = ""
        If rblMaterialType.SelectedIndex = 0 Or rblMaterialType.SelectedIndex = 1 Then
            pnlName.Visible = True
            Dim dt As DataTable
            Try
                dt = metLab.tables.GetChemicalMaterialData(txtMaterial.Text.Trim)
                If dt.Rows.Count > 0 Then
                    lblName.Text = dt.Rows(0)("short_description")
                End If
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                dt = Nothing
            End Try
        ElseIf txtMaterial.Text.Trim.Length = 0 Then
            lblMessage.Text = "Please Provide Material Name !"
        End If
    End Sub

    Private Sub rblBased_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblBased.SelectedIndexChanged
        lblMessage.Text = ""
        txtOn.Text = ""
        dgPL.DataSource = Nothing
        dgPL.DataBind()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        lblMessage.Text = ""
        If txtOn.Text.Trim.Length = 0 Then
            lblMessage.Text = "Please Provide string for search!"
            Exit Sub
        Else
            Try
                dgPL.CurrentPageIndex = 0
                dgPL.EditItemIndex = -1
                FillGrid(GetSearchString)
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub
    Private Function GetSearchString() As String
        Dim searchString As String
        If rblBased.SelectedIndex = 0 Then
            Dim str As Array
            str = txtOn.Text.Split(" ")
            Dim i As Int16
            searchString = "%"
            For i = 0 To str.Length - 1
                searchString &= str.GetValue(i) + "%"
            Next
        Else
            searchString = "%" + txtOn.Text.Trim + "%"
        End If
        Return searchString
    End Function
    Private Sub FillGrid(ByVal searchString As String)
        dgPL.DataSource = Nothing
        dgPL.DataBind()
        Dim dt As DataTable
        Try
            dt = metLab.tables.GetPLDetails(searchString, rblBased.SelectedIndex)
            If IsNothing(dgPL.CurrentPageIndex) Then dgPL.CurrentPageIndex = 0
            If dt.Rows.Count > 5 Then
                dgPL.AllowPaging = True
                dgPL.PageSize = 5
                dgPL.PagerStyle.Mode = PagerMode.NumericPages
            End If
            dgPL.DataSource = dt
            dgPL.DataBind()
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            dt = Nothing
        End Try
    End Sub

    Private Sub dgPL_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgPL.PageIndexChanged
        lblMessage.Text = ""
        If txtOn.Text.Trim.Length = 0 Then
            lblMessage.Text = "Please Provide string for search!"
            Exit Sub
        Else
            Try
                dgPL.CurrentPageIndex = e.NewPageIndex
                dgPL.EditItemIndex = -1
                FillGrid(GetSearchString)
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub

    Private Sub rblMaterialType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblMaterialType.SelectedIndexChanged
        lblMessage.Text = ""
        pnlName.Visible = False
        lblName.Text = ""
        txtMaterial.Text = ""
        txtRemarks.Text = ""
        Try
            dgMaterialList.CurrentPageIndex = 0
            dgMaterialList.SelectedIndex = -1
            FillSavedList()
        Catch exp As Exception
            Throw New Exception(exp.Message)
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtMaterial.Text.Trim.Length = 0 Then
            lblMessage.Text = "Please Provide Material Name !"
        End If
        Dim done As New Boolean()
        Dim oChemMaster As New metLab.ChemicalTesting()
        Try
            oChemMaster.Material = txtMaterial.Text.Trim
            oChemMaster.Spec = txtSpec.Text.Trim
            oChemMaster.TestType = rblMaterialType.SelectedItem.Value
            oChemMaster.Remarks = txtRemarks.Text.Trim
            oChemMaster.SaveMaterialList(Val(lblMaterialID.Text))
            lblMessage.Text = oChemMaster.Message
        Catch exp As Exception
            lblMessage.Text = oChemMaster.Message
        End Try
        Try
            dgMaterialList.CurrentPageIndex = 0
            dgMaterialList.SelectedIndex = -1
            FillSavedList()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        pnlName.Visible = False
        lblName.Text = ""
    End Sub
    Private Sub FillSavedList()
        dgMaterialList.DataSource = Nothing
        dgMaterialList.DataBind()
        Dim dt As DataTable
        Try
            dt = metLab.tables.GetMaterialList(rblMaterialType.SelectedItem.Value)
            If IsNothing(dgMaterialList.CurrentPageIndex) Then dgMaterialList.CurrentPageIndex = 0
            If dt.Rows.Count > 5 Then
                dgMaterialList.AllowPaging = True
                dgMaterialList.PageSize = 5
                dgMaterialList.PagerStyle.Mode = PagerMode.NumericPages
            End If
            dgMaterialList.DataSource = dt
            dgMaterialList.DataBind()
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            dt = Nothing
        End Try
    End Sub
    Private Sub dgMaterialList_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgMaterialList.PageIndexChanged
        lblMessage.Text = ""
        Try
            dgMaterialList.CurrentPageIndex = e.NewPageIndex
            dgMaterialList.EditItemIndex = -1
            FillSavedList()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub dgMaterialList_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgMaterialList.ItemCommand
        lblMessage.Text = ""
        lblMaterialID.Text = ""
        Select Case e.CommandName
            Case "Select"
                txtMaterial.Text = e.Item.Cells(1).Text
                txtSpec.Text = e.Item.Cells(3).Text.Replace("&nbsp;", "")
                txtRemarks.Text = e.Item.Cells(4).Text.Replace("&nbsp;", "")
                Dim i As Integer
                If Not e.Item.Cells(5).Text Is Nothing Then
                    For i = 0 To rblMaterialType.Items.Count - 1
                        If rblMaterialType.Items(i).Value = e.Item.Cells(5).Text Then
                            rblMaterialType.SelectedIndex = i
                            Exit For
                        End If
                    Next
                End If
                lblMaterialID.Text = e.Item.Cells(6).Text
        End Select
    End Sub
End Class
