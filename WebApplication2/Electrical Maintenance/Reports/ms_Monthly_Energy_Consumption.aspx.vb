Public Class ms_MonthlyEnergyConsumptionReport
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents txtFromDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtToDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtBeginDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEndDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtWheelsMonth As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtWheelsCast As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtAxlesForged As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RangeValidator1 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents Requiredfieldvalidator2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtWheelsYear As System.Web.UI.WebControls.TextBox
    Protected WithEvents Requiredfieldvalidator3 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Requiredfieldvalidator4 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Requiredfieldvalidator5 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Requiredfieldvalidator6 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Requiredfieldvalidator7 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Requiredfieldvalidator8 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Rangevalidator3 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents Rangevalidator4 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents Rangevalidator2 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
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
        If Not Page.IsPostBack Then
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Update_Energy_DataBase() Then
            lblMessage.Text &= " Data Validated!"
        Else
            lblMessage.Text &= " InValid Data !"
        End If
    End Sub
    Private Sub PrintableReport()
        Try
            Dim rptFormula As String
            rptFormula = "&prompt0=" & CDate(txtFromDate.Text).Month
            rptFormula &= "&prompt1=" & CDate(txtFromDate.Text).Year
            Dim strRptName, strRptFormula, strServer, strPathName, strRptNameWithPath As String
            strServer = Server.MachineName
            strPathName = "http://" & strServer & "/mss/"
            strPathName &= "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?id=15905&apsuser=Administrator&apspassword=Cris@123&apsauthtype=secEnterprise&user0=sa&password0=sadev123&promptonrefresh=0"
            strPathName &= "&user0@EnergyPerUnitOfProduction.rpt=sa&password0@EnergyPerUnitOfProduction.rpt=sa"
            strPathName &= "&user0@EnergyAnalysis.rpt=sa&password0@EnergyAnalysis.rpt=sa"
            strPathName &= "&user0@EnergyTotal.rpt=sa&password0@EnergyTotal.rpt=sa"
            strPathName &= "&user0@EnergyShop.rpt=sa&password0@EnergyShop.rpt=sa"
            strPathName &= "&user0@EnergyKWH.rpt=sa&password0@EnergyKWH.rpt=sa"
            strPathName &= rptFormula
            Response.Redirect(strPathName)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Function Update_Energy_DataBase()
        Dim Done As Boolean
        Dim wcast, wset, axl, twset As Integer
        wcast = CType(Trim(txtWheelsCast.Text), Integer)
        wset = CType(Trim(txtWheelsMonth.Text), Integer)
        axl = CType(Trim(txtAxlesForged.Text), Integer)
        twset = CType(Trim(txtWheelsYear.Text), Integer)
        Try
            Done = New Maintenance.Electrical().Update_Energy_DataBase(CDate(Trim(txtFromDate.Text)), CDate(Trim(txtToDate.Text)), wcast, wset, axl, twset)
        Catch exp As Exception
            Done = False
            lblMessage.Text = exp.Message
        End Try
        Return Done
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        PrintableReport()
    End Sub
End Class


