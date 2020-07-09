Public Class rptNewBreakDownsforDay
    Inherits System.Web.UI.Page
    Protected WithEvents btnShow As System.Web.UI.WebControls.Button
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents txtToDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblGrp As System.Web.UI.WebControls.Label
    Protected WithEvents btnReport As System.Web.UI.WebControls.Button
    Protected WithEvents txtFrDate As System.Web.UI.WebControls.TextBox
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
        If IsPostBack = False Then
            lblGrp.Visible = False
            'Session("group") = "EAC"
            lblGrp.Text = Session("group")
            txtFrDate.Text = Format(Now.Date)
            txtToDate.Text = Format(Now.Date)
        End If
    End Sub

    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
        Dim dt As Date
        Dim dt1 As Date
        Try
            dt = CDate(txtFrDate.Text)
            dt1 = CDate(txtToDate.Text)
        Catch
            lblMessage.Text = "Enter Date in 'dd/MM/yyyy' Format"
            txtFrDate.Text = ""
            txtToDate.Text = ""
            Exit Sub
        End Try
        If txtFrDate.Text = "" Or txtToDate.Text = "" Then
            Exit Sub
        Else
            Dim strRptNameWithPath, strGroup As String
            Dim strServer, strPathName As String
            strServer = Server.MachineName

            strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=&user0=sa&password0=sadev123"
            strPathName &= "&prompt0=" & lblGrp.Text.Trim & ""
            strPathName &= "&prompt1= DateTime(" & CStr(CDate(dt).Year) & "," & CStr(CDate(dt).Month) & "," & CStr(CDate(dt).Day) & ", 0,0,0)"
            strPathName &= "&prompt2= DateTime(" & CStr(CDate(dt1).Year) & "," & CStr(CDate(dt1).Month) & "," & CStr(CDate(dt1).Day) & ", 0,0,0)"
            Response.Redirect(strPathName)
        End If
    End Sub

    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim dt As Date
        Dim dt1 As Date
        Try
            dt = CDate(txtFrDate.Text)
            dt1 = CDate(txtToDate.Text)
        Catch
            lblMessage.Text = "Enter Date in 'dd/MM/yyyy' Format"
            txtFrDate.Text = ""
            txtToDate.Text = ""
            Exit Sub
        End Try
        If txtFrDate.Text = "" Or txtToDate.Text = "" Then
            Exit Sub
        Else
            Dim strRptNameWithPath, strGroup As String
            Dim strServer, strPathName As String
            strServer = Server.MachineName

            strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=18364&user0=sa&password0=sadev123"
            strPathName &= "&prompt0=" & lblGrp.Text.Trim & ""
            strPathName &= "&prompt1= DateTime(" & CStr(CDate(dt).Year) & "," & CStr(CDate(dt).Month) & "," & CStr(CDate(dt).Day) & ", 0,0,0)"
            strPathName &= "&prompt2= DateTime(" & CStr(CDate(dt1).Year) & "," & CStr(CDate(dt1).Month) & "," & CStr(CDate(dt1).Day) & ", 0,0,0)"
            Response.Redirect(strPathName)
        End If
    End Sub
End Class
