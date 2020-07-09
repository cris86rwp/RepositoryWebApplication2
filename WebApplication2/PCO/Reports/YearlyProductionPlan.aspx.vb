Public Class YearlyProductionPlan
    Inherits System.Web.UI.Page
    Protected WithEvents ddlFinYear As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents btnRWFTargetReport As System.Web.UI.WebControls.Button
    Protected WithEvents btnRBTargetReport As System.Web.UI.WebControls.Button
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
        ' Response.Redirect("http://" & rwfGen.ReportServer.ServerName & "/mmsreports/pcopco/YearlyProductionPlan.aspx")
        If Page.IsPostBack = False Then
            Dim dt As DataTable
            dt = PCO.tables.PCOFinYear
            ddlFinYear.DataSource = dt
            ddlFinYear.DataTextField = dt.Columns("finyear").ColumnName
            ddlFinYear.DataValueField = dt.Columns("finyr").ColumnName
            ddlFinYear.DataBind()
            dt = Nothing
        End If
    End Sub

    Private Sub ddlFinYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlFinYear.SelectedIndexChanged
        If ddlFinYear.SelectedItem.Text = "Select" Then
            lblMessage.Text = "Select a Financial Year"
        End If
    End Sub

    Private Sub btnRWFTargetReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRWFTargetReport.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?id=25768&apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&user0=sa&password0=sadev123&promptonrefresh=0" &
                    "&prompt0=" & ddlFinYear.SelectedItem.Text
        Response.Redirect(strPathName, True)
    End Sub

    Private Sub btnRBTargetReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRBTargetReport.Click
        Dim strServer, strPathName, rptName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?id=25774&apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&user0=sa&password0=sadev123&promptonrefresh=0" &
                    "&prompt0=" & ddlFinYear.SelectedItem.Text
        Response.Redirect(strPathName, True)
    End Sub
End Class
