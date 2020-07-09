Public Class RecallNotice1
    Inherits System.Web.UI.Page
    Protected WithEvents btnSubmit As System.Web.UI.WebControls.Button
    Protected WithEvents RequiredFieldValidator2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RangeValidator2 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents txtDays As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RangeValidator1 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
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
        'Put user code to initialize the page here
        If Not IsPostBack Then
            txtDate.Text = Date.Today
            txtDays.Text = 0
        End If
    End Sub

    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Dim strServer, rptName As String
        Dim Date1, Date2 As Date
        Date1 = CDate(txtDate.Text)
        Date2 = Date1.AddDays(Trim(txtDays.Text))
        strServer = Server.MachineName
        rptName = "http://" & strServer & "/mss/"
        rptName &= "mss/toolroom/reports/formats/RecallNotice.rpt?user0=report&password0=report&promptonrefresh=0"
        rptName &= "&prompt0=DateTime(" & CType(Trim(Date1), Date).Year & "," & CType(Trim(Date1), Date).Month & "," & CType(Trim(Date1), Date).Day & "," & CType(Trim(Date1), Date).Hour & "," & CType(Trim(Date1), Date).Minute & "," & CType(Trim(Date1), Date).Second & ")"
        rptName &= "&prompt1=" & Val(txtDays.Text.Trim)
        Response.Redirect(rptName)
    End Sub
End Class
