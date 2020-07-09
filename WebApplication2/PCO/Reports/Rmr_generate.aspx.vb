Public Class Rmr_generate
    Inherits System.Web.UI.Page
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents BtnShow As System.Web.UI.WebControls.Button
    Protected WithEvents rfvld1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblerr As System.Web.UI.WebControls.Label
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
        'Response.Redirect("http://" & rwfGen.ReportServer.ServerName & "/mmsreports/pcopco/Rmr_generate.aspx")
    End Sub

    Private Sub BtnShow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnShow.Click
        Dim wo As String
        wo = txtDate.Text
        Dim strServer, strPathName, rptName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?id=16126&apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&user0=sa&password0=sadev123&promptonrefresh=0" &
        "&prompt0=" & wo
        Response.Redirect(strPathName, True)
    End Sub

    'Private Sub txtDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged
    '    lblerr.Text = ""
    '    Try
    '        BtnShow.Enabled = PCO.tables.CheckWODate(txtDate.Text)
    '    Catch exp As Exception
    '        txtDate.Text = ""
    '        BtnShow.Enabled = False
    '        lblerr.Text = exp.Message
    '    End Try
    'End Sub
End Class


