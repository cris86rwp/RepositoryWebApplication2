Public Class MouldRoomFormatsReport
    Inherits System.Web.UI.Page
    Protected WithEvents txtHeatNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnShow As System.Web.UI.WebControls.Button
    Protected WithEvents rblType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents rblReport As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblShift As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents pnlMPO As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlReg As System.Web.UI.WebControls.Panel
    Protected WithEvents rblRep As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents btnReport As System.Web.UI.WebControls.Button
    Protected WithEvents txtHeat As System.Web.UI.WebControls.TextBox
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
            'txtDate.Text = Now.Date

            Try
                txtHeatNumber.Text = RWF.tables.GetLatestPrePourHeat - 1
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub

    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
        Dim strPathName As String
        If rblType.SelectedItem.Value = 1 Then
            strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=17543&user0=sa&password0=sadev123" &
                    "&prompt0=" & Val(txtHeatNumber.Text) & "" &
                    "&prompt1=" & Val(rblType.SelectedItem.Value) & ""
            Response.Redirect(strPathName)
        ElseIf rblType.SelectedItem.Value = 2 Then
            strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=26659&user0=sa&password0=sadev123" &
                    "&prompt0=" & Val(txtHeatNumber.Text) & "" &
                    "&prompt1=" & Val(rblType.SelectedItem.Value) & ""
            Response.Redirect(strPathName)
        ElseIf rblType.SelectedItem.Value = 3 Then
            strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=26166&user0=sa&password0=sadev123" &
                    "&prompt0=" & Val(txtHeatNumber.Text) & "" &
                    "&prompt1=" & Val(rblType.SelectedItem.Value) & ""
            Response.Redirect(strPathName)
        ElseIf rblType.SelectedItem.Value = 4 Then
            strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=21225&user0=sa&password0=sadev123" &
                "&prompt0=" & Val(txtHeatNumber.Text) & "" &
                    "&prompt1=" & Val(rblType.SelectedItem.Value) & ""
            Response.Redirect(strPathName)
        ElseIf rblType.SelectedItem.Value = 5 Then
            strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=26182&user0=sa&password0=sadev123" &
                    "&prompt0=" & Val(txtHeatNumber.Text) & "" &
                    "&prompt1=" & Val(rblType.SelectedItem.Value) & ""
            Response.Redirect(strPathName)
        ElseIf rblType.SelectedItem.Value = 6 Then
            strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=26479&user0=sa&password0=sadev123" &
                    "&prompt0=" & Val(txtHeatNumber.Text) & "" &
                    "&prompt1=" & Val(rblType.SelectedItem.Value) & ""
            Response.Redirect(strPathName)
        ElseIf rblType.SelectedItem.Value = 7 Then
            strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=10241&user0=sa&password0=sadev123" &
                    "&prompt0=" & Val(txtHeatNumber.Text) & "" &
                    "&prompt1=" & Val(rblType.SelectedItem.Value) & ""
            Response.Redirect(strPathName)
        End If
    End Sub

End Class
