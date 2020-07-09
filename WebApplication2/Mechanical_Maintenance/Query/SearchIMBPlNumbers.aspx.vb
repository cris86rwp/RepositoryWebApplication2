Public Class SearchIMBPlNumbers

    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents txtSearchPLNumber As System.Web.UI.WebControls.TextBox
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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
    End Sub
    Private Sub GetPLNumbers()
        lblMessage.Text = ""
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Dim dt As DataTable
        Try
            dt = imb.GetPLNumbers(txtSearchPLNumber.Text.Trim)
            If dt.Rows.Count > 0 Then
                DataGrid1.DataSource = dt.DefaultView
                DataGrid1.DataBind()
            Else
                lblMessage.Text = "No Records for the seeked word "
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
        End Try
    End Sub

    Private Sub txtSearchPLNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearchPLNumber.TextChanged
        GetPLNumbers()
    End Sub
End Class
