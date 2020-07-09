Public Class CalibrationOfMagAndUTInWheelShopView
    Inherits System.Web.UI.Page
    Protected WithEvents txtToDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblTestType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents btnShow As System.Web.UI.WebControls.Button
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtFromDate As System.Web.UI.WebControls.TextBox

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
            txtFromDate.Text = Now.Date
            txtToDate.Text = Now.Date
            Try
                getDetails()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub

    Private Sub getDetails()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Try
            DataGrid1.DataSource = CalibrationTest.Tables.CalibrationData(CDate(txtFromDate.Text), CDate(txtToDate.Text), rblTestType.SelectedItem.Text.ToLower)
            DataGrid1.DataBind()
        Catch exp As Exception
            Throw New Exception(exp.Message)
        End Try
    End Sub

    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
        Try
            getDetails()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub rblTestType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblTestType.SelectedIndexChanged
        Try
            getDetails()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
End Class
