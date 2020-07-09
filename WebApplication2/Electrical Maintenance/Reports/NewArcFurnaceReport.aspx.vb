Public Class NewArcFurnaceReport
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents txtAsOnDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnReport As System.Web.UI.WebControls.Button
    Protected WithEvents Button2 As System.Web.UI.WebControls.Button
    Protected WithEvents Button3 As System.Web.UI.WebControls.Button
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
        'Put user code to initialize the page here
        If IsPostBack = False Then
            ' txtAsOnDate.Text = Maintenance.ElecTables.CheckReportDate("ms_furnace_melting_statistics", "Consumption_date")
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
        txtAsOnDate.Text = Maintenance.ElecTables.CheckReportDate("ms_furnace_melting_statistics", "Consumption_date", CDate(txtAsOnDate.Text))
        If CDate(txtAsOnDate.Text) = #1/1/1900# Then
            lblMessage.Text = "No Data for given Date !"
            txtAsOnDate.Text = ""
        Else
            Dim strPathName As String
            strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?id=19950&apsuser=Administrator&apspassword=Cris@123&apsauthtype=secEnterprise&user0=sa&password0=sadev123&promptonrefresh=0"
            strPathName &= "&prompt0=DateTime(" & CStr(CDate(txtAsOnDate.Text).Year) & "," & CStr(CDate(txtAsOnDate.Text).Month) & "," & CStr(CDate(txtAsOnDate.Text).Day) & ", 00, 00, 00)"
            strPathName &= "&user0@ArcFurnaceDetails=sa&password0@ArcFurnaceDetails=sa"
            Response.Redirect(strPathName)
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?id=15979&apsuser=Administrator&apspassword=Cris@123&apsauthtype=secEnterprise&user0=sa&password0=sadev123&promptonrefresh=0"
        strPathName &= "&prompt0=DateTime(" & CDate(txtAsOnDate.Text).Year & "," & CDate(txtAsOnDate.Text).Month & "," & CDate(txtAsOnDate.Text).Day & ",00,00,00)"
        strPathName &= "&user0@ArcFurnaceStas.rpt=sa&password0@ArcFurnaceStas.rpt=sa"
        Response.Redirect(strPathName)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?id=15985&apsuser=Administrator&apspassword=Cris@123&apsauthtype=secEnterprise&user0=sa&password0=sadev123&promptonrefresh=0"
        strPathName &= "&prompt0=DateTime(" & CDate(txtAsOnDate.Text).Year & "," & CDate(txtAsOnDate.Text).Month & "," & CDate(txtAsOnDate.Text).Day & ",00,00,00)"
        Response.Redirect(strPathName)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?id=15875&apsuser=Administrator&apspassword=Cris@123&apsauthtype=secEnterprise&user0=sa&password0=sadev123&promptonrefresh=0"
        strPathName &= "&prompt0=DateTime(" & CDate(txtAsOnDate.Text).Year & "," & CDate(txtAsOnDate.Text).Month & "," & CDate(txtAsOnDate.Text).Day & ",00,00,00)"
        Response.Redirect(strPathName)
    End Sub
End Class
