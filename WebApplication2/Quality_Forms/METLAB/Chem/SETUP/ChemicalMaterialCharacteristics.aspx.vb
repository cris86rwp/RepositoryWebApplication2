Public Class ChemicalMaterialCharacteristics
    Inherits System.Web.UI.Page
    Protected WithEvents ddlMaterial As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtCharacteristics As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMinValue As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMaxValue As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents rblMaterialType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents dgMaterialList As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblCharID As System.Web.UI.WebControls.Label
    Protected WithEvents txtOrderBY As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblUnit As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents chkUnit As System.Web.UI.WebControls.CheckBox
    Protected WithEvents txtUnit As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblUser As System.Web.UI.WebControls.Label
    Protected WithEvents txtNominalValue As System.Web.UI.WebControls.TextBox
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
        lblUser.Visible = False
        lblCharID.Visible = False
        If Page.IsPostBack = False Then
            lblUser.Text = Session("UserID")
            lblUser.Text = "078983"
            If (lblUser.Text = "078983" Or lblUser.Text = "079960" Or lblUser.Text = "074961" Or lblUser.Text = "076662" Or lblUser.Text = "077059") Then

            Else
                Response.Redirect("/mss/logon.aspx")
            End If
            Try
                fillRBL()
                rblMaterialType.SelectedIndex = 0
                FillMaterialList()
                SetUnit()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub
    Private Sub SetUnit()
        txtUnit.Visible = False
        txtUnit.Text = ""
        If chkUnit.Checked Then
            txtUnit.Visible = True
            rblUnit.ClearSelection()
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

    Private Sub FillMaterialList()
        ddlMaterial.DataSource = Nothing
        ddlMaterial.DataBind()
        Dim dt As DataTable
        Dim i As Boolean = False
        Try
            dt = metLab.tables.GetMaterialList(rblMaterialType.SelectedItem.Value)
            If dt.Rows.Count > 0 Then
                ddlMaterial.DataSource = dt
                If rblMaterialType.SelectedItem.Value = 1 Or rblMaterialType.SelectedItem.Value = 2 Then
                    ddlMaterial.DataTextField = dt.Columns("MaterialName").ColumnName
                    ddlMaterial.DataValueField = dt.Columns("MaterialID").ColumnName
                Else
                    ddlMaterial.DataTextField = dt.Columns("Material").ColumnName
                    ddlMaterial.DataValueField = dt.Columns("MaterialID").ColumnName
                End If
                ddlMaterial.DataBind()
                ddlMaterial.SelectedIndex = 0
            Else
                i = True
                Throw New Exception("No Material List Saved for " & rblMaterialType.SelectedItem.Text & " Items !")
            End If
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            dt = Nothing
        End Try
        If Not i Then
            lblMessage.Text = ""
            Try
                dgMaterialList.CurrentPageIndex = 0
                dgMaterialList.SelectedIndex = -1
                FillSavedList()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtCharacteristics.Text.Trim.Length = 0 Then
            lblMessage.Text = "Please Provide Characteristics Name !"
        End If
        Dim done As New Boolean()
        Dim oChemMaster As New metLab.ChemicalTesting()
        Try
            oChemMaster.MaterialID = ddlMaterial.SelectedItem.Value
            oChemMaster.CharName = txtCharacteristics.Text.Trim
            oChemMaster.MinValue = Val(txtMinValue.Text)
            oChemMaster.NominalValue = Val(txtNominalValue.Text)
            oChemMaster.MaxValue = Val(txtMaxValue.Text)
            oChemMaster.Remarks = txtRemarks.Text.Trim
            oChemMaster.OrderBY = txtOrderBY.Text
            If chkUnit.Checked Then
                oChemMaster.Unit = txtUnit.Text.Trim
            Else
                oChemMaster.Unit = rblUnit.SelectedItem.Value
            End If
            oChemMaster.SaveMaterialCharacteristics(Val(lblCharID.Text))
            lblMessage.Text = oChemMaster.Message
            txtCharacteristics.Text = ""
            txtMinValue.Text = ""
            txtMaxValue.Text = ""
            txtRemarks.Text = ""
            lblCharID.Text = ""
        Catch exp As Exception
            lblMessage.Text = oChemMaster.Message
        Finally
            oChemMaster = Nothing
        End Try
        Try
            dgMaterialList.CurrentPageIndex = 0
            dgMaterialList.SelectedIndex = -1
            FillSavedList()
            chkUnit.Checked = False
            SetUnit()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub FillSavedList()
        dgMaterialList.DataSource = Nothing
        dgMaterialList.DataBind()
        Dim dt As DataTable
        Try
            dt = metLab.tables.GetMaterialCharList(ddlMaterial.SelectedItem.Value)
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
        lblCharID.Text = ""
        chkUnit.Checked = False
        txtMinValue.Text = ""
        txtMaxValue.Text = ""
        txtNominalValue.Text = ""
        txtOrderBY.Text = ""
        txtRemarks.Text = ""
        txtNominalValue.Text = ""
        Try
            dgMaterialList.CurrentPageIndex = e.NewPageIndex
            dgMaterialList.SelectedIndex = -1
            FillSavedList()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub rblMaterialType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblMaterialType.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            FillMaterialList()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub dgMaterialList_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgMaterialList.ItemCommand
        lblMessage.Text = ""
        lblCharID.Text = ""
        chkUnit.Checked = False
        Select Case e.CommandName
            Case "Select"
                txtCharacteristics.Text = e.Item.Cells(1).Text
                Dim i As Integer
                Dim unit As Boolean = False
                rblUnit.ClearSelection()
                If Not e.Item.Cells(2).Text Is Nothing Then
                    For i = 0 To rblUnit.Items.Count - 1
                        If rblUnit.Items(i).Value = e.Item.Cells(2).Text Then
                            rblUnit.Items(i).Selected = True
                            unit = True
                            Exit For
                        End If
                    Next
                End If
                If Not unit Then
                    chkUnit.Checked = True
                    txtUnit.Visible = True
                    txtUnit.Text = e.Item.Cells(2).Text.Replace("&nbsp;", "")
                End If
                txtMinValue.Text = e.Item.Cells(3).Text.Replace("&nbsp;", "")
                txtMaxValue.Text = e.Item.Cells(4).Text.Replace("&nbsp;", "")
                txtNominalValue.Text = e.Item.Cells(5).Text.Replace("&nbsp;", "")
                txtOrderBY.Text = e.Item.Cells(6).Text.Replace("&nbsp;", "")
                txtRemarks.Text = e.Item.Cells(7).Text.Replace("&nbsp;", "")
                i = 0
                If Not e.Item.Cells(8).Text Is Nothing Then
                    For i = 0 To ddlMaterial.Items.Count - 1
                        If ddlMaterial.Items(i).Value = e.Item.Cells(8).Text Then
                            ddlMaterial.SelectedIndex = i
                            Exit For
                        End If
                    Next
                End If
                lblCharID.Text = e.Item.Cells(9).Text
        End Select
    End Sub

    Private Sub ddlMaterial_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMaterial.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            dgMaterialList.CurrentPageIndex = 0
            dgMaterialList.SelectedIndex = -1
            FillSavedList()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub chkUnit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUnit.CheckedChanged
        SetUnit()
    End Sub
End Class
