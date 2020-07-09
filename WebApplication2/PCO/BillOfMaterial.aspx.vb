Public Class BillOfMaterial
    Inherits System.Web.UI.Page
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents rblShop As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents lblUom As System.Web.UI.WebControls.Label
    Protected WithEvents txtMaxRMRQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblEmployeeCode As System.Web.UI.WebControls.Label
    Protected WithEvents lblPlDesc As System.Web.UI.WebControls.Label
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents dgBOM As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtPLNumber As System.Web.UI.WebControls.TextBox
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
        'Put user code to initialize the page here
        txtPLNumber.Enabled = False
        rblShop.Enabled = True
        lblEmployeeCode.Visible = False
        If Not IsPostBack Then
            Session("Group") = "PCOPCO"
            Session("UserID") = "072442"
            lblEmployeeCode.Text = Session("UserID")
            Try
                If IsNothing(Session("Group")) OrElse Session("Group") = "" Or IsNothing(Session("UserID")) OrElse Session("UserID") = "" Then
                    Response.Redirect("InvalidSession.aspx")
                    Exit Sub
                End If
                If Session("Group") <> "PCOPCO" Then
                    Response.Redirect("InvalidSession.aspx")
                    Exit Sub
                End If
                If SelectShop() Then
                    SetShop()
                End If
            Catch exp As Exception
                Response.Redirect("InvalidSession.aspx")
                Exit Sub
            End Try
        End If
    End Sub

    Private Function SelectShop() As Boolean
        Dim Allowed As Boolean = False
        Dim Shop As String
        Dim i As Int16
        Try
            lblMessage.Text = PCO.tables.SelectShop
            If lblMessage.Text.EndsWith("Melting") Then
                Shop = "Melting"
            ElseIf lblMessage.Text.EndsWith("Moulding") Then
                Shop = "Moulding"
            ElseIf lblMessage.Text.EndsWith("WFP Shop") Then
                Shop = "WFP Shop"
            End If
            lblMessage.Text = ""
            i = 0
            rblShop.ClearSelection()
            For i = 0 To rblShop.Items.Count - 1
#Disable Warning BC42104 ' Variable is used before it has been assigned a value
                If rblShop.Items(i).Text = Shop Then
#Enable Warning BC42104 ' Variable is used before it has been assigned a value
                    rblShop.Items(i).Selected = True
                    Allowed = True
                    Exit For
                End If
            Next
            If Allowed = False Then
                Throw New Exception("No Authorised Activity allowed !")
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        i = Nothing
        Shop = Nothing
        Return Allowed
    End Function

    Private Sub SetShop()
        txtPLNumber.Text = ""
        Clear()
        dgBOM.DataSource = Nothing
        dgBOM.DataBind()
        Dim dt As DataTable
        Try
            dt = PCO.tables.GetBOMList(rblShop.SelectedItem.Value)
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
#Disable Warning BC42104 ' Variable is used before it has been assigned a value
        If dt.Rows.Count > 0 Then
#Enable Warning BC42104 ' Variable is used before it has been assigned a value
            dgBOM.DataSource = dt
            dgBOM.DataBind()
            If IsNothing(dgBOM.CurrentPageIndex) Then dgBOM.CurrentPageIndex = 0
            If dt.Rows.Count > 10 Then
                dgBOM.AllowPaging = True
                dgBOM.PageSize = 10
                dgBOM.PagerStyle.Mode = PagerMode.NumericPages
            End If
        End If
        dt = Nothing
    End Sub

    Private Sub rblShop_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblShop.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            SetShop()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtPLNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPLNumber.TextChanged
        lblMessage.Text = ""
        Clear()
        Dim dt As DataTable
        Try
            dt = PCO.tables.GetBOMPLDetails(txtPLNumber.Text)
            lblPlDesc.Text = IIf(IsDBNull(dt.Rows(0)("ShortDescription")), "", dt.Rows(0)("ShortDescription"))
            txtQty.Text = IIf(IsDBNull(dt.Rows(0)("Quantity")), "", dt.Rows(0)("Quantity"))
            lblUom.Text = IIf(IsDBNull(dt.Rows(0)("UnitName")), "", dt.Rows(0)("UnitName"))
            txtMaxRMRQty.Text = IIf(IsDBNull(dt.Rows(0)("MaxRMRQty")), "", dt.Rows(0)("MaxRMRQty"))
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt = Nothing
        End Try
    End Sub

    Private Sub Clear()
        lblPlDesc.Text = ""
        txtQty.Text = ""
        lblUom.Text = ""
        txtMaxRMRQty.Text = ""
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        Dim Done As Boolean
        Try
            Done = New PCO.PCO().UpdateBOM(rblShop.SelectedItem.Value, txtPLNumber.Text.Trim, Val(txtQty.Text), Val(txtMaxRMRQty.Text), lblEmployeeCode.Text, rblShop.SelectedItem.Text)
            If Done Then
                lblMessage.Text &= "  Saved New BOM for " & rblShop.SelectedItem.Text & "   Shop PLNumber : " & txtPLNumber.Text
                dgBOM.SelectedIndex = -1
                SetShop()
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        Done = Nothing
    End Sub

    Private Sub dgBOM_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgBOM.PageIndexChanged
        lblMessage.Text = ""
        txtPLNumber.Text = ""
        Clear()
        Try
            dgBOM.CurrentPageIndex = e.NewPageIndex
            dgBOM.SelectedIndex = -1
            SetShop()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub dgBOM_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgBOM.ItemCommand
        lblMessage.Text = ""
        Select Case e.CommandName
            Case "Select"
                txtPLNumber.Text = e.Item.Cells(1).Text
                lblPlDesc.Text = e.Item.Cells(2).Text
                txtQty.Text = e.Item.Cells(3).Text
                lblUom.Text = e.Item.Cells(4).Text
                txtMaxRMRQty.Text = e.Item.Cells(5).Text
        End Select
    End Sub
End Class
