Public Class IDNReport
    Inherits System.Web.UI.Page
    Protected WithEvents txtToDt As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFrDt As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents ddlPresentStatus As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnIDN As System.Web.UI.WebControls.Button
    Protected WithEvents rblType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents Panel2 As System.Web.UI.WebControls.Panel
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
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
        'Put user code to initialize the page here
        If IsPostBack = False Then
            txtFrDt.Text = Now.Date
            txtToDt.Text = Now.Date
            SetPanel()
            Dim dt As DataTable
            Try
                dt = ProductionConsumables.IDNStatus
                ddlPresentStatus.DataSource = dt
                ddlPresentStatus.DataTextField = dt.Columns(1).ColumnName
                ddlPresentStatus.DataValueField = dt.Columns(0).ColumnName
                ddlPresentStatus.DataBind()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            Finally
                dt = Nothing
            End Try
        End If
    End Sub

    Private Sub btnIDN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIDN.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=25005&user0=sa&password0=sadev123" &
            "&prompt0=DateTime(" & CDate(txtFrDt.Text).Year & "," & CDate(txtFrDt.Text).Month & "," & CDate(txtFrDt.Text).Day & ", 0,0,0)" &
            "&prompt1=DateTime(" & CDate(txtToDt.Text).Year & "," & CDate(txtToDt.Text).Month & "," & CDate(txtToDt.Text).Day & ", 0,0,0)" &
            "&prompt2=" & rblType.SelectedItem.Value & "" &
            "&prompt3=" & ddlPresentStatus.SelectedItem.Value & ""
        Response.Redirect(strPathName)
    End Sub

    Private Sub rblType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblType.SelectedIndexChanged
        SetPanel()
    End Sub

    Private Sub SetPanel()
        Panel2.Visible = True
        If rblType.SelectedItem.Value Then Panel2.Visible = False
    End Sub
End Class
