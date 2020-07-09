Public Class DailyVoltageCurrentReport
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents txtAsOnDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnReport As System.Web.UI.WebControls.Button
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
            'txtAsOnDate.Text = Maintenance.ElecTables.CheckReportDate("ms_DailyVoltage", "ConsumptionDate")
        End If
    End Sub

    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click
        lblMessage.Text = ""
        txtAsOnDate.Text = Maintenance.ElecTables.CheckReportDate("ms_DailyVoltage", "ConsumptionDate", CDate(txtAsOnDate.Text))
        If CDate(txtAsOnDate.Text) = #1/1/1900# Then
            lblMessage.Text = "No Data for the given Date !"
        Else
            Dim strPathName As String
            strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?id=15959&apsuser=Administrator&apspassword=Cris@123&apsauthtype=secEnterprise&user0=sa&password0=sadev123&promptonrefresh=0 &prompt0=DateTime(" & Format(CDate(txtAsOnDate.Text), "yyyy,MM,dd, 00, 00, 00") & ")"
            strPathName &= "&user0@ElecPFReadings.rpt=report&password0@ElecPFReadings.rpt=report"
            Response.Redirect(strPathName)
        End If
    End Sub
End Class
