Public Class CheckListReport
    Inherits System.Web.UI.Page
    Protected WithEvents btnShow As System.Web.UI.WebControls.Button
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
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
        'Response.Redirect("http://reportserver/mmsreports/ssmold/CheckListReport.aspx")
        If Page.IsPostBack = False Then
            txtDate.Text = Now.Date
        End If
    End Sub

    Private Sub txtDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged
        lblMessage.Text = ""
        Try
            If CDate(txtDate.Text) > Now.Date Then
                lblMessage.Text = "Date cannot be greater than Today !"
                txtDate.Text = ""
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?id=8476&apsuser=Administrator&apspassword=Cris@123&apsauthtype=secEnterprise&user0=sa&password0=sadev123&promptonrefresh=0" &
                "&prompt0=DateTime(" & CStr(CDate(txtDate.Text).Year) & "," & CStr(CDate(txtDate.Text).Month) & "," & CStr(CDate(txtDate.Text).Day) & ", 00, 00, 00)" &
                "&user0@MROutTurnRejOff=sa&password0@MROutTurnRejOff=sa" &
                "&user0@MROutTurnSprueWash=sa&password0@MROutTurnSprueWash=sa" &
                "&user0@MROutTurnSpray=sa&password0@MROutTurnSpray=sa" &
                "&user0@MROutTurnEquipSts=sa&password0@MROutTurnEquipSts=sa" &
                "&user0@MROutTurnMRS=sa&password0@MROutTurnMRS=sa" &
                "&user0@MROutTurnPAT.rpt=sa&password0@MROutTurnPAT.rpt=sa"
        Response.Redirect(strPathName)
    End Sub
End Class
