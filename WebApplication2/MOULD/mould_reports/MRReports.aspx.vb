Public Class MRReports
    Inherits System.Web.UI.Page
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents txtTappedDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtWeekStartDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtWeekEndDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnOffload As System.Web.UI.WebControls.Button
    Protected WithEvents txtPhlDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
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
        'Put user code to initialize the page here
        If IsPostBack = False Then
            txtTappedDate.Text = PCO.tables.GetTopPHLDate
            txtWeekStartDate.Text = PCO.tables.GetTopPHLDate
            txtWeekEndDate.Text = PCO.tables.GetTopPHLDate
            txtPhlDate.Text = PCO.tables.GetTopPHLDate
        End If
    End Sub

    Private Sub btnOffload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOffload.Click
        Dim strServer, strPathName, rptName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=26190&user0=sa&password0=sadev123" &
                "&prompt0=DateTime(" & CStr(CDate(txtTappedDate.Text).Year) & "," & CStr(CDate(txtTappedDate.Text).Month) & "," & CStr(CDate(txtTappedDate.Text).Day) & ", 00, 00, 00)" &
                "&prompt1=DateTime(" & CStr(CDate(txtWeekStartDate.Text).Year) & "," & CStr(CDate(txtWeekStartDate.Text).Month) & "," & CStr(CDate(txtWeekStartDate.Text).Day) & ", 00, 00, 00)" &
                "&prompt2=DateTime(" & CStr(CDate(txtWeekEndDate.Text).Year) & "," & CStr(CDate(txtWeekEndDate.Text).Month) & "," & CStr(CDate(txtWeekEndDate.Text).Day) & ", 00, 00, 00)"
        Response.Redirect(strPathName)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim strServer, strPathName, rptName As String
        strPathName = "http://" & rwfGen.ReportServer.ServerName & "" & _
                    "/mmsreports/ssmold/formats/X46n56.rpt?user0=report&password0=report&promptonrefresh=0" & _
                "&user0@Nov14.rpt=report&password0@Nov14.rpt=report" & _
                "&prompt0=DateTime(" & CStr(CDate(txtPhlDate.Text).Year) & "," & CStr(CDate(txtPhlDate.Text).Month) & "," & CStr(CDate(txtPhlDate.Text).Day) & ", 00, 00, 00)" & _
                "&prompt1=1"
        Response.Redirect(strPathName)
    End Sub
End Class
