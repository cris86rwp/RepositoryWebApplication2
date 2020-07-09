Public Class ProductUnifiedPL
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblProductCode As System.Web.UI.WebControls.Label
    Protected WithEvents txtUnifiedPL As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtItemDescription As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSpecificationNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDrawingNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCategory As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents rblProduct As System.Web.UI.WebControls.RadioButtonList
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
        If Not IsPostBack Then
            GetProductList()
        End If
    End Sub

    Private Sub GetProductList()
        Clear()
        Dim ds As DataSet
        Try
            ds = PCO.tables.RWFProductList(rblProduct.SelectedItem.Value)
            DataGrid1.DataSource = ds.Tables(0)
            DataGrid1.DataBind()
            DataGrid1.SelectedIndex = -1
            DataGrid2.DataSource = ds.Tables(1)
            DataGrid2.DataBind()
            DataGrid2.SelectedIndex = -1
            If IsNothing(DataGrid1.CurrentPageIndex) Then DataGrid1.CurrentPageIndex = 0
            If ds.Tables(0).Rows.Count > 10 Then
                DataGrid1.AllowPaging = True
                DataGrid1.PageSize = 10
                DataGrid1.PagerStyle.Mode = PagerMode.NumericPages
            End If
            If IsNothing(DataGrid2.CurrentPageIndex) Then DataGrid2.CurrentPageIndex = 0
            If ds.Tables(1).Rows.Count > 10 Then
                DataGrid2.AllowPaging = True
                DataGrid2.PageSize = 10
                DataGrid2.PagerStyle.Mode = PagerMode.NumericPages
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub Clear()
        lblProductCode.Text = ""
        txtUnifiedPL.Text = ""
        txtItemDescription.Text = ""
        txtSpecificationNo.Text = ""
        txtDrawingNo.Text = ""
        txtCategory.Text = ""
    End Sub

    Private Sub rblProduct_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblProduct.SelectedIndexChanged
        lblMessage.Text = ""
        lblProductCode.Text = ""
        DataGrid1.CurrentPageIndex = 0
        DataGrid1.SelectedIndex = -1
        GetProductList()
    End Sub

    Private Sub DataGrid1_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DataGrid1.PageIndexChanged
        lblMessage.Text = ""
        lblProductCode.Text = ""
        Try
            DataGrid1.CurrentPageIndex = e.NewPageIndex
            DataGrid1.SelectedIndex = -1
            GetProductList()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub DataGrid1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.ItemCommand
        lblMessage.Text = ""
        Select Case e.CommandName
            Case "Select"
                lblProductCode.Text = e.Item.Cells(1).Text
        End Select
    End Sub

    Private Sub DataGrid2_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DataGrid2.PageIndexChanged
        lblMessage.Text = ""
        lblProductCode.Text = ""
        Try
            DataGrid2.CurrentPageIndex = e.NewPageIndex
            DataGrid2.EditItemIndex = -1
            GetProductList()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    'Private Sub DataGrid2_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid2.ItemCommand
    '    lblMessage.Text = ""
    '    Select Case e.CommandName
    '        Case "Select"
    '            lblProductCode.Text = e.Item.Cells(1).Text.Replace("&nbsp;", "")
    '            txtUnifiedPL.Text = e.Item.Cells(2).Text.Replace("&nbsp;", "")
    '            txtItemDescription.Text = e.Item.Cells(4).Text.Replace("&nbsp;", "")
    '            txtSpecificationNo.Text = e.Item.Cells(5).Text.Replace("&nbsp;", "")
    '            txtDrawingNo.Text = e.Item.Cells(6).Text.Replace("&nbsp;", "")
    '            txtCategory.Text = e.Item.Cells(7).Text.Replace("&nbsp;", "")
    '    End Select
    'End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        If txtUnifiedPL.Text.Trim.Length = 0 Then
            lblMessage.Text = "InVaid Data !"
            Exit Sub
        Else
            Try
                Dim Uni As New PCO.Product(lblProductCode.Text, txtUnifiedPL.Text.Trim, txtItemDescription.Text.Trim, txtSpecificationNo.Text, txtDrawingNo.Text.Trim, txtCategory.Text.Trim)
                lblMessage.Text = Uni.Message
            Catch exp As Exception
                lblMessage.Text &= exp.Message
            End Try
            If lblMessage.Text = "Record updated" Then
                Clear()
                GetProductList()
            End If
        End If
    End Sub

    Private Sub txtUnifiedPL_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUnifiedPL.TextChanged
        lblMessage.Text = ""
        txtItemDescription.Text = ""
        txtSpecificationNo.Text = ""
        txtDrawingNo.Text = ""
        txtCategory.Text = ""
        Try
            Dim dt As DataTable = PCO.tables.RWFProductUnifiedPLList(txtUnifiedPL.Text.Trim)
            If dt.Rows.Count > 0 Then
                txtUnifiedPL.Text = IIf(IsDBNull(dt.Rows(0)("UnifiedPL")), "", dt.Rows(0)("UnifiedPL"))
                txtItemDescription.Text = IIf(IsDBNull(dt.Rows(0)("ItemDescription")), "", dt.Rows(0)("ItemDescription"))
                txtSpecificationNo.Text = IIf(IsDBNull(dt.Rows(0)("SpecificationNo")), "", dt.Rows(0)("SpecificationNo"))
                txtDrawingNo.Text = IIf(IsDBNull(dt.Rows(0)("DrawingNo")), "", dt.Rows(0)("DrawingNo"))
                txtCategory.Text = IIf(IsDBNull(dt.Rows(0)("Category")), "", dt.Rows(0)("Category"))
            End If
            dt = Nothing
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
End Class
