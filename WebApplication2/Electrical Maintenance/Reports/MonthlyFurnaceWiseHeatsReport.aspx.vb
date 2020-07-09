Public Class MonthlyFurnaceWiseHeatsReport
    Inherits System.Web.UI.Page
    Protected WithEvents Button2 As System.Web.UI.WebControls.Button
    Protected WithEvents ddlYear As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlMonth As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
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
            getYears()
        End If
    End Sub
    Sub getYears()
        Dim ds As DataSet
        Dim d As Date
        Dim y, py, ny, m As Int16
        d = Date.Now
        m = d.Month
        Try
            ds = Maintenance.ElecTables.getMonthYear("ms_furnace_melting_statistics", "Consumption_date")
            ddlMonth.DataSource = ds.Tables(0)
            ddlMonth.DataTextField = ds.Tables(0).Columns(1).ColumnName
            ddlMonth.DataValueField = ds.Tables(0).Columns(0).ColumnName
            ddlMonth.DataBind()
            ddlYear.DataSource = ds.Tables(1)
            ddlYear.DataTextField = ds.Tables(1).Columns(0).ColumnName
            ddlYear.DataValueField = ds.Tables(1).Columns(0).ColumnName
            ddlYear.DataBind()
            ddlYear.SelectedIndex = 0
            ddlMonth.SelectedIndex = m - 1
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim yea As Int16
        Dim mon As Int16
        mon = ddlMonth.SelectedItem.Value
        yea = ddlYear.SelectedItem.Text
        Dim strPathName, strRptFormula As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?id=15924&apsuser=Administrator&apspassword=Cris@123&apsauthtype=secEnterprise&user0=sa&password0=sadev123&promptonrefresh=0 &prompt0=" & mon & "&prompt1=" & yea & ""
        'strPathName = "/testmss/electricalmaintenance/reports/formats/MonthlySlabReport.rpt?user0=report&password0=report&prompt0=" & mon & "&prompt1=" & yea & ""
        'strPathName &= "&user0=report&password0=report&promptonrefresh=0" '&prompt1=Date(" & Format(CDate(txtDate.Text), "yyyy,MM,dd 00, 00, 00") & ")"
        Response.Redirect(strPathName)
    End Sub
End Class

