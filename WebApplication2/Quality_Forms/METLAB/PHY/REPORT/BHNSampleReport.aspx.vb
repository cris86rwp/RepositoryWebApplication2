Public Class BHNSampleReport
    Inherits System.Web.UI.Page
    Protected WithEvents txtLabNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnBHNSample As System.Web.UI.WebControls.Button

    Shared themeValue As String
    Public Function DateTime(x As Date) As String
        DateTime = "Date(" & Year(x) & "," & Month(x) & "," & Day(x) & " 0,0,0)"
    End Function

    Public Sub New()

        AddHandler PreInit, New EventHandler(AddressOf Page_PreInit)
    End Sub

    Private Sub Page_PreInit(ByVal sender As Object, ByVal e As EventArgs)

        Page.Theme = themeValue
    End Sub


    'Protected Sub Dd1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
    '    themeValue = Dd1.SelectedItem.Value
    '    Response.Redirect(Request.Url.ToString())

    'End Sub


    '#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If IsPostBack = False Then

        End If
    End Sub

    Protected Sub btnBHNSample_Click(sender As Object, e As EventArgs) Handles btnBHNSample.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?id=14621&apsuser=Administrator&apspassword=Cris@123&apsauthtype=secEnterprise&user0=sa&password0=sadev123&promptonrefresh=0" &
       "&prompt0=" & (txtLabNumber.Text.Trim) & ""
        Response.Redirect(strPathName)
    End Sub

End Class