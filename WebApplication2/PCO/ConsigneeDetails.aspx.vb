Public Class ConsigneeDetails
    Inherits System.Web.UI.Page
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents txtShortName As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPaying_authority As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPincode As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCity As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtAddress As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtConsignee_name As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtConsignee As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents btnClear As System.Web.UI.WebControls.Button
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents txtCustomerCode As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtconsignee_gst As System.Web.UI.WebControls.TextBox
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
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
        Session("UserID") = "074632"
        If IsPostBack = False Then
            BindGrid()
        End If
    End Sub

    Private Sub BindGrid()
        DataGrid1.SelectedIndex = -1
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Try
            DataGrid1.DataSource = PCO.tables.getConsigneeDetails
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub DataGrid1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.ItemCommand
        lblMessage.Text = ""
        Try
            If e.CommandName = "Select" Then
                txtConsignee.Text = e.Item.Cells(1).Text.Replace("&nbsp;", "")
                txtConsignee_name.Text = e.Item.Cells(2).Text.Replace("&nbsp;", "")
                txtAddress.Text = e.Item.Cells(3).Text.Replace("&nbsp;", "")
                txtCity.Text = e.Item.Cells(4).Text.Replace("&nbsp;", "")
                txtPincode.Text = e.Item.Cells(5).Text.Replace("&nbsp;", "")
                txtPaying_authority.Text = e.Item.Cells(6).Text.Replace("&nbsp;", "")
                txtCustomerCode.Text = e.Item.Cells(7).Text.Replace("&nbsp;", "")
                txtShortName.Text = e.Item.Cells(8).Text.Replace("&nbsp;", "") ''
                txtconsignee_gst.Text = e.Item.Cells(9).Text.Replace("&nbsp;", "")
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        lblMessage.Text = ""
        Clear()
    End Sub

    Private Sub Clear()
        txtAddress.Text = ""
        txtCity.Text = ""
        txtConsignee.Text = ""
        txtConsignee_name.Text = ""
        txtPaying_authority.Text = ""
        txtPincode.Text = ""
        txtCustomerCode.Text = ""
        txtShortName.Text = ""
        txtconsignee_gst.Text = ""
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        Dim Done As Boolean
        Try
            Done = New PCO.PCO().ConsigneeDetails(txtConsignee.Text.Trim, txtConsignee_name.Text.Trim, txtAddress.Text.Trim, txtCity.Text.Trim, txtPincode.Text.Trim, txtPaying_authority.Text.Trim, txtCustomerCode.Text.Trim, txtShortName.Text.Trim, txtconsignee_gst.Text.Trim)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If Done Then
            Try
                BindGrid()
                Clear()
                lblMessage.Text = "Updated !"
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        Else
            lblMessage.Text = "Updatedion Failed !"
        End If
        Done = Nothing
    End Sub
End Class

