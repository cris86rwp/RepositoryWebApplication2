Public Class NewEnergyConsumptionReport
    Inherits System.Web.UI.Page
    Protected WithEvents txtAsOnDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents txtToDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFromDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnProductNo As System.Web.UI.WebControls.Button
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents Button2 As System.Web.UI.WebControls.Button
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
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
            ' txtAsOnDate.Text = Maintenance.ElecTables.CheckReportDate("ms_electrical_econs", "c_date")
            ' txtFromDate.Text = Maintenance.ElecTables.CheckReportDate("ms_electrical_econs", "c_date")
            'txtToDate.Text = Maintenance.ElecTables.CheckReportDate("ms_electrical_econs", "c_date")
        End If
    End Sub

    Private Sub txtAsOnDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAsOnDate.TextChanged
        Dim dt As Date
        Try
            dt = CDate(txtAsOnDate.Text.Trim)
        Catch exp As Exception
            lblMessage.Text = "Date not in correct format  " & exp.Message
        End Try
    End Sub

    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click
        lblMessage.Text = ""
        txtAsOnDate.Text = Maintenance.ElecTables.CheckReportDate("ms_electrical_econs", "c_date", CDate(txtAsOnDate.Text))
        If CDate(txtAsOnDate.Text) = #1/1/1900# Then
            lblMessage.Text = "No Data for the given Date !"
        Else
            Dim strPathName As String
            strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?id=15941&apsuser=Administrator&apspassword=Cris@123&apsauthtype=secEnterprise&user0=sa&password0=sadev123&promptonrefresh=0 &prompt0=DateTime(" & Format(CDate(txtAsOnDate.Text), "yyyy,MM,dd, 00, 00, 00") & ")&prompt1=0"
            strPathName &= "&user0@NewMD.rpt=sa&password0@NewMD.rpt=sa"
            Response.Redirect(strPathName)
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim prevstate As Boolean = Me.EnableViewState
        Dim tw As New System.IO.StringWriter()
        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
        Try
            Response.ContentType = "application/vnd.ms_excel"
            Response.Charset = ""
            Me.EnableViewState = False
            DataGrid1.RenderControl(hw)
            Response.Write(tw.ToString)
            Response.End()
            Me.EnableViewState = prevstate
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
        End Try
    End Sub

    Private Sub btnProductNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProductNo.Click
        lblMessage.Text = ""
        GetGridData(0)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        lblMessage.Text = ""
        GetGridData(1)
    End Sub

    Private Sub GetGridData(ByVal Type As Int16)
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Try
            DataGrid1.DataSource = Maintenance.ElecTables.NewEnergyData(CDate(txtFromDate.Text), CDate(txtToDate.Text), Type)
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
End Class
