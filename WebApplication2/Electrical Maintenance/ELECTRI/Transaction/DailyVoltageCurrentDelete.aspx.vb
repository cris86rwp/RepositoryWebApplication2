Public Class DailyVoltageCurrentDelete
    Inherits System.Web.UI.Page
    Protected WithEvents lblDate As System.Web.UI.WebControls.Label
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Not IsPostBack Then
            lblDate.Text = Maintenance.ElecTables.LatestConsumptionDate
            FillGrid()
        End If
    End Sub
    Private Sub FillGrid()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Try
            DataGrid1.DataSource = Maintenance.ElecTables.newVoltageCurrent(CDate(lblDate.Text))
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        lblMessage.Text = ""
        Dim done As Boolean
        Try
            done = New Maintenance.Electrical().LatestVoltageDateDelete(CDate(lblDate.Text))
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If done Then
            FillGrid()
            lblMessage.Text &= "  Data Deleted !"
        End If
    End Sub
End Class
