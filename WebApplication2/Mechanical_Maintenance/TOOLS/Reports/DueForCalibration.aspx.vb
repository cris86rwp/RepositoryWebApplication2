Public Class DueForCalibration
    Inherits System.Web.UI.Page
    Protected WithEvents radList As System.Web.UI.WebControls.RadioButtonList
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
        End If
    End Sub

    Private Sub radList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radList.SelectedIndexChanged
        Dim strRptNameWithPath, strRptName As String
        If radList.SelectedIndex = 0 Then
            Dim strServer, strPathName As String
            strServer = Server.MachineName
            strPathName = "http://" & strServer & "/mss/"
            strPathName = strPathName & "mss/toolRoom/Reports/formats/ToolsOverdueRpt.rpt?user0=report&password0=report&promptonrefresh=0"
            strPathName = strPathName & ""
            Response.Redirect(strPathName)
        Else
            Response.Redirect("RecallNotice.aspx")
        End If
    End Sub
End Class
