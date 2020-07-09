Public Class ms_Special_Energy_Consumption
    Inherits System.Web.UI.Page
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents cboYear As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboMonth As System.Web.UI.WebControls.DropDownList
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
        If IsPostBack = False Then
            getYears()
        End If
    End Sub

    Private Sub PrintableReport()
        Try
            Dim rptFormula As String
            rptFormula = "&prompt0=" & cboMonth.SelectedItem.Value
            rptFormula &= "&prompt1=" & cboYear.SelectedItem.Text

            Dim strRptName, strRptFormula, strServer, strPathName, strRptNameWithPath As String
            strServer = Server.MachineName
            'strPathName = "http://" & strServer & "/mss/"
            strPathName &= "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?id=15991&apsuser=Administrator&apspassword=Cris@123&apsauthtype=secEnterprise&user0=sa&password0=sadev123&promptonrefresh=0"
            strPathName &= rptFormula
            Response.Redirect(strPathName)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub


    Private Sub getYears()
        Dim ds As DataSet
        Dim d As Date
        Dim y, py, ny, m As Int16
        d = Date.Now
        m = d.Month
        Try
            ds = Maintenance.ElecTables.getMonthYear("ms_electrical_econs", "c_date")
            cboMonth.DataSource = ds.Tables(0)
            cboMonth.DataTextField = ds.Tables(0).Columns(1).ColumnName
            cboMonth.DataValueField = ds.Tables(0).Columns(0).ColumnName
            cboMonth.DataBind()
            cboYear.DataSource = ds.Tables(1)
            cboYear.DataTextField = ds.Tables(1).Columns(0).ColumnName
            cboYear.DataValueField = ds.Tables(1).Columns(0).ColumnName
            cboYear.DataBind()
            cboYear.SelectedIndex = 0
            cboMonth.SelectedIndex = m - 1
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        PrintableReport()
    End Sub
End Class


