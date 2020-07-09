Public Class _302_cleaningroom_report
    Inherits System.Web.UI.Page
    Protected WithEvents BtnShow As System.Web.UI.WebControls.Button
    Protected WithEvents rfvld2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtToHt As System.Web.UI.WebControls.TextBox
    Protected WithEvents rfvld1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtFromHt As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblerr As System.Web.UI.WebControls.Label
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
        'Put user code to initialize the page here.
        If IsPostBack = False Then
            txtFromHt.Text = RWF.tables.GetLatestPrePourHeat
            txtToHt.Text = RWF.tables.GetLatestPrePourHeat
        End If
    End Sub

    Private Sub BtnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShow.Click
        Dim strServer, strPathName, rptName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=14360&user0=sa&password0=sadev123" &
                    "&user0@mm_302_mould_room_report1.rpt=sa&password0@mm_302_mould_room_report1.rpt=sa" &
                    "&user0@mm_302_mould_room_report.rpt=sa&password0@mm_302_mould_room_report.rpt=sa" &
                    "&prompt0=" & CInt(txtFromHt.Text) &
                    "&prompt1=" & CInt(txtToHt.Text)
        Response.Redirect(strPathName)
    End Sub

End Class
