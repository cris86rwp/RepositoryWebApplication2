Public Class PODetailsQry
    Inherits System.Web.UI.Page
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents txtPONumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents DataGrid0 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid3 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid4 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid5 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid6 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid7 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid8 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid9 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid10 As System.Web.UI.WebControls.DataGrid
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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
    End Sub

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



    Private Sub txtPONumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPONumber.TextChanged
        lblMessage.Text = ""
        Dim str As String
        DataGrid0.DataSource = Nothing
        DataGrid0.DataBind()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        DataGrid3.DataSource = Nothing
        DataGrid3.DataBind()
        DataGrid4.DataSource = Nothing
        DataGrid4.DataBind()
        DataGrid5.DataSource = Nothing
        DataGrid5.DataBind()
        DataGrid6.DataSource = Nothing
        DataGrid6.DataBind()
        DataGrid7.DataSource = Nothing
        DataGrid7.DataBind()
        DataGrid8.DataSource = Nothing
        DataGrid8.DataBind()
        DataGrid9.DataSource = Nothing
        DataGrid9.DataBind()
        DataGrid10.DataSource = Nothing
        DataGrid10.DataBind()
        If txtPONumber.Text.Trim.Length <> 9 Then
            lblMessage.Text = " PO Number : '" & txtPONumber.Text.Trim & "' is In Valid ! "
            txtPONumber.Text = ""
        Else
            If SparesCell.NSIDN.IsValidPO(txtPONumber.Text.Trim) Then
                Try
                    Dim ds As New DataSet()
                    ds = SparesCell.NSIDN.PODetailsQry(txtPONumber.Text.Trim)
                    DataGrid0.DataSource = ds.Tables(0).DefaultView
                    DataGrid0.DataBind()
                    DataGrid1.DataSource = ds.Tables(1).DefaultView
                    DataGrid1.DataBind()
                    DataGrid2.DataSource = ds.Tables(2).DefaultView
                    DataGrid2.DataBind()
                    DataGrid3.DataSource = ds.Tables(3).DefaultView
                    DataGrid3.DataBind()
                    DataGrid4.DataSource = ds.Tables(4).DefaultView
                    DataGrid4.DataBind()
                    DataGrid5.DataSource = ds.Tables(5).DefaultView
                    DataGrid5.DataBind()
                    DataGrid6.DataSource = ds.Tables(6).DefaultView
                    DataGrid6.DataBind()
                    DataGrid7.DataSource = ds.Tables(7).DefaultView
                    DataGrid7.DataBind()
                    DataGrid8.DataSource = ds.Tables(8).DefaultView
                    DataGrid8.DataBind()
                    DataGrid9.DataSource = ds.Tables(9).DefaultView
                    DataGrid9.DataBind()
                    DataGrid10.DataSource = ds.Tables(10).DefaultView
                    DataGrid10.DataBind()
                Catch exp As Exception
                    lblMessage.Text = exp.Message
                End Try
            Else
                lblMessage.Text = " PO Number : '" & txtPONumber.Text.Trim & "' is In Valid ! "
                txtPONumber.Text = ""
            End If
        End If

    End Sub
End Class
