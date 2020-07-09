Public Class WheelMachinedInRWFReport
    Inherits System.Web.UI.Page
    Protected WithEvents txtMachinedDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblmessage As System.Web.UI.WebControls.Label
    Protected WithEvents rblQry As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtToDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFrDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents Panel2 As System.Web.UI.WebControls.Panel
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents ShowData As System.Web.UI.WebControls.Button
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList



    Shared themeValue As String

    Public Sub New()

        AddHandler PreInit, New EventHandler(AddressOf Page_PreInit)
    End Sub

    Private Sub Page_PreInit(ByVal sender As Object, ByVal e As EventArgs)

        Page.Theme = themeValue
    End Sub


    Protected Sub Dd1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        themeValue = Dd1.SelectedItem.Value
        Response.Redirect(Request.Url.ToString())

    End Sub



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
            txtMachinedDate.Text = Now.Date
            txtFrDate.Text = Now.Date
            txtToDate.Text = Now.Date
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If CDate(txtMachinedDate.Text) > Today Then
                lblmessage.Text = "Future Date "
                Exit Sub
            End If
        Catch exp As Exception
            lblmessage.Text = exp.Message
        End Try
        lblmessage.Text = ""
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Try
            DataGrid1.DataSource = RWF.WFPSQuerry.MachinedInRWF(0, CDate(txtMachinedDate.Text), CDate(txtMachinedDate.Text))
            DataGrid1.DataBind()
        Catch exp As Exception
            lblmessage.Text = exp.Message
        End Try
    End Sub
    Private Sub txtFrDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFrDate.TextChanged
        lblmessage.Text = ""
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Try
            txtFrDate.Text = CDate(txtFrDate.Text)
        Catch exp As Exception
            txtFrDate.Text = ""
            lblmessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtToDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtToDate.TextChanged
        lblmessage.Text = ""
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Try
            txtToDate.Text = CDate(txtToDate.Text)
        Catch exp As Exception
            txtToDate.Text = ""
            lblmessage.Text = exp.Message
        End Try
    End Sub

    Private Sub ShowData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowData.Click
        lblmessage.Text = ""
        Try
            Qry()
        Catch exp As Exception
            lblmessage.Text = exp.Message
        End Try
    End Sub
    Private Sub Qry()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Try
            DataGrid1.DataSource = RWF.WFPSQuerry.MachinedInRWF(rblQry.SelectedItem.Value, CDate(txtFrDate.Text), CDate(txtToDate.Text))
            DataGrid1.DataBind()
        Catch exp As Exception
            lblmessage.Text = exp.Message
        End Try
    End Sub
End Class
