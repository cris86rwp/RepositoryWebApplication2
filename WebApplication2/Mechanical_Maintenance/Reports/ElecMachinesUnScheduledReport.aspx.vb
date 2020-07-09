Public Class ElecMachinesUnScheduledReport
    Inherits System.Web.UI.Page
    Protected WithEvents rfv2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtToDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents rfv1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents rblShop As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents btnElec As System.Web.UI.WebControls.Button
    Protected WithEvents txtFromDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList
    Shared themeValue As String

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
    Private Sub Page_PreInit(ByVal sender As Object, ByVal e As EventArgs)
        Page.Theme = themeValue
    End Sub

    Public Sub New()
        AddHandler PreInit, New EventHandler(AddressOf Page_PreInit)
    End Sub

    Protected Sub dd1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        themeValue = Dd1.SelectedItem.Value
        Response.Redirect(Request.Url.ToString())

    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Page.IsPostBack = False Then
            txtFromDate.Text = Now.Date
            txtToDate.Text = Now.Date
        End If
    End Sub

    Private Sub btnElec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnElec.Click
        Dim dt As Date
        Try
            dt = CDate(txtFromDate.Text)
        Catch
            lblMessage.Text = "Enter date in 'dd/mm/yyyy' Format"
            txtFromDate.Text = ""
            Exit Sub
        End Try

        Try
            dt = CDate(txtToDate.Text)
        Catch
            lblMessage.Text = "Enter date in 'dd/mm/yyyy' Format"
            txtToDate.Text = ""
            Exit Sub
        End Try
        Dim strRptName, strRptFormula, strServer, strPathName, strRptNameWithPath As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=18230&user0=sa&password0=sadev123"
        strPathName &= "&prompt0=DateTime (" & Format(CDate(txtFromDate.Text.Trim), "yyyy,MM,dd,  00, 00, 00") & ")"
        strPathName &= "&prompt1=DateTime (" & Format(CDate(txtToDate.Text.Trim), "yyyy,MM,dd,  00, 00, 00") & ")"
        strPathName &= "&prompt2=" & rblShop.SelectedItem.Text.Trim & ""
        Response.Redirect(strPathName)
    End Sub
End Class
