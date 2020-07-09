Public Class HeatSheet_3011_UI
    Inherits System.Web.UI.Page
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents BtnShow As System.Web.UI.WebControls.Button
    Protected WithEvents lblerr As System.Web.UI.WebControls.Label
    Protected WithEvents txtFromHeat As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSubmit As System.Web.UI.WebControls.Button
    Protected WithEvents txtHeatNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents rfvld2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtToHt As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtFromHt As System.Web.UI.WebControls.TextBox
    Protected WithEvents rfvld1 As System.Web.UI.WebControls.RequiredFieldValidator
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


    Protected Sub Dd1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        themeValue = Dd1.SelectedItem.Value
        Response.Redirect(Request.Url.ToString())

    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Response.Redirect("http://reportserver/mmsreports/whlmlt/HeatSheet_3011_UI.aspx")
        If IsPostBack = False Then
            txtHeatNumber.Text = RWF.tables.GetLatestPrePourHeat(1)
            txtFromHeat.Text = RWF.tables.GetLatestPrePourHeat
            txtFromHt.Text = RWF.tables.GetLatestPrePourHeat
            txtToHt.Text = RWF.tables.GetLatestPrePourHeat
        End If
    End Sub

    Private Sub BtnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShow.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?id=23777&apsuser=Administrator&apspassword=Cris@123&apsauthtype=secEnterprise&user0=sa&password0=sadev123&promptonrefresh=0" &
                    "&promptex0=" & Val(txtFromHeat.Text) &
                    "&promptex1=" & Val(txtFromHeat.Text) &
                    "&promptex2=" & 0
        '"&user0@NewProcessDelay.rpt=report&password0@NewProcessDelay.rpt=report" &
        '"&user0@NewProcessDelay1.rpt=report&password0@NewProcessDelay1.rpt=report"
        Response.Redirect(strPathName)
    End Sub

    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If RWF.tables.CheckOffHeat(Val(txtHeatNumber.Text)) Then
            Dim strPathName As String
            strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?id=23777&apsuser=Administrator&apspassword=Cris@123&apsauthtype=secEnterprise&user0=sa&password0=sadev123&promptonrefresh=0" &
                        "&promptex0=" & Val(txtHeatNumber.Text) &
                        "&promptex1=" & Val(txtHeatNumber.Text) &
                        "&promptex2=" & 1
            '"&user0@NewProcessDelay.rpt=report&password0@NewProcessDelay.rpt=report" &
            '"&user0@NewProcessDelay1.rpt=report&password0@NewProcessDelay1.rpt=report"
            Response.Redirect(strPathName)
        Else
            lblerr.Text = "InValid Off Heat Number !"
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?id=23777&apsuser=Administrator&apspassword=Cris@123&apsauthtype=secEnterprise&user0=sa&password0=sadev123&promptonrefresh=0" &
                    "&promptex0=" & Val(txtFromHt.Text) &
                    "&promptex1=" & Val(txtToHt.Text) &
                    "&promptex2=" & 0
        '"&user0@NewProcessDelay.rpt=report&password0@NewProcessDelay.rpt=report" &
        '"&user0@NewProcessDelay1.rpt=report&password0@NewProcessDelay1.rpt=report"
        Response.Redirect(strPathName)
    End Sub
End Class
