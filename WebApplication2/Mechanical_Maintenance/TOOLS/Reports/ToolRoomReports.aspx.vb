Public Class ToolRoomReports
    Inherits System.Web.UI.Page
    Protected WithEvents btnShow As System.Web.UI.WebControls.Button
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtToDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFromDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblQry As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents btnGrid As System.Web.UI.WebControls.Button
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnExport As System.Web.UI.WebControls.Button
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents rblList As System.Web.UI.WebControls.RadioButtonList
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
            btnShow.Text = "Show " & rblList.SelectedItem.Text & "  Report"
            txtFromDate.Text = Now.Date
            txtToDate.Text = Now.Date
        End If
    End Sub

    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
        Dim strRptNameWithPath, strRptName As String
        Dim strServer, strPathName As String

        If rblList.SelectedItem.Value = "MasterCalibrationPlan" Then
            strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=27491&user0=sa&password0=sadev123"
            'strPathName = strPathName & ""
            Response.Redirect(strPathName)
        ElseIf rblList.SelectedItem.Value = "MasterCalibrationList" Then
            strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=27497&user0=sa&password0=sadev123"
            'strPathName = strPathName & ""
            Response.Redirect(strPathName)
        ElseIf rblList.SelectedItem.Value = "ToolMaster" Then
            strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=27504&user0=sa&password0=sadev123"
            'strPathName = strPathName & ""
            Response.Redirect(strPathName)
        ElseIf rblList.SelectedItem.Value = "DeletedToolMaster" Then
            strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=19370&user0=sa&password0=sadev123"
            'strPathName = strPathName & ""
            Response.Redirect(strPathName)
        ElseIf rblList.SelectedItem.Value = "CalibrationOverDue" Then
            strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=19384&user0=sa&password0=sadev123"
            'strPathName = strPathName & ""
            Response.Redirect(strPathName)
        ElseIf rblList.SelectedItem.Value = "LocationWiseTools" Then
            strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=19377&user0=sa&password0=sadev123"
            'strPathName = strPathName & ""
            Response.Redirect(strPathName)
        Else
            Server.Transfer("/mss/selectModule.aspx")
        End If
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
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

    Private Sub btnGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrid.Click
        lblMessage.Text = ""
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Try
            DataGrid1.DataSource = ToolRoom.Tables.ToolRoomQry(CDate(txtFromDate.Text), CDate(txtToDate.Text), rblQry.SelectedItem.Value)
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub rblList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblList.SelectedIndexChanged
        btnShow.Text = "Show " & rblList.SelectedItem.Text & "  Report"
    End Sub
End Class
