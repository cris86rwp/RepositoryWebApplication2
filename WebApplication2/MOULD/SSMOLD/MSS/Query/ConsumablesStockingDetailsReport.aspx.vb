Public Class ConsumablesStockingDetailsReport
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents ddlPLNumber As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents lblConsignee As System.Web.UI.WebControls.Label
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid

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
        If Page.IsPostBack = False Then
            Try
                Dim Group As String = Session("Group")
                Dim strMode As String = Request.QueryString("mode")
                Dim UserId As String = Session("UserID")
                Dim InValid As Boolean = False
                ''''''''''''''''
                Group = "SSMOLD"
                UserId = "073533"
                ''''''''''''''''
                Try
                    lblConsignee.Text = CriticalItems.ItemTables.GetConsignee(Group, UserId)
                    If lblConsignee.Text.Trim.Length = 4 Then InValid = True
                    GetPLList()
                    GetPLDetails()
                Catch exp As Exception
                    lblMessage.Text = exp.Message
                End Try
                If Not InValid Then
                    Response.Redirect("/mss/logon.aspx")
                End If
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub
    Private Sub GetPLList()
        Dim dt As DataTable
        Try
            dt = Maintenance.tables.GetPLList
            ddlPLNumber.DataSource = dt
            ddlPLNumber.DataTextField = dt.Columns(0).ColumnName
            ddlPLNumber.DataValueField = dt.Columns(0).ColumnName
            ddlPLNumber.DataBind()
            ddlPLNumber.Items.Insert("0", "ALL")
            ddlPLNumber.SelectedIndex = 0
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
        End Try
    End Sub
    Private Sub GetPLDetails()
        Try
            DataGrid1.DataSource = Maintenance.tables.GetPLDetails(ddlPLNumber.SelectedItem.Text)
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub ddlPLNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlPLNumber.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            GetPLDetails()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
End Class
