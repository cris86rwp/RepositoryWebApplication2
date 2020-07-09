Public Class rptBreakDownsforDay
    Inherits System.Web.UI.Page
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents lblErr As System.Web.UI.WebControls.Label
    Protected WithEvents btnShow As System.Web.UI.WebControls.Button
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
        If Not Page.IsPostBack Then
            txtDate.Text = Format(Now.Date)
        End If
    End Sub

    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
        Dim dt As Date
        Try
            dt = CDate(txtDate.Text)
        Catch
            lblErr.Text = "Enter Date in 'dd/MM/yyyy' Format"
        End Try
        If txtDate.Text = "" Then
            Exit Sub
        Else
            Dim strRptNameWithPath, strRptName As String
            Dim strServer, strPathName As String

            strServer = Server.MachineName

            strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=15735&user0=sa&password0=sadev123"
            strPathName &= "&prompt0=ALL"
            strPathName &= "&prompt1= DateTime(" & CStr(CDate(dt).Year) & "," & CStr(CDate(dt).Month) & "," & CStr(CDate(dt).Day) & ", 0,0,0)"
            strPathName &= "&prompt2= DateTime(" & CStr(CDate(dt).Year) & "," & CStr(CDate(dt).Month) & "," & CStr(CDate(dt).Day) & ", 0,0,0)"
            Response.Redirect(strPathName)
        End If
    End Sub
End Class
