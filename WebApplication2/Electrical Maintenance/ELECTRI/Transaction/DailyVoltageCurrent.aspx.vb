Public Class DailyVoltageCurrent
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txt66 As System.Web.UI.WebControls.TextBox
    Protected WithEvents rfv66 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents btnSubmit_Clicks As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
    Protected WithEvents txtCurrent As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPower As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlMinutes As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnExit As System.Web.UI.WebControls.Button
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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        'Put user code to initialize the page here
        If Not IsPostBack Then
            txtDate.Text = Now.Date
        End If
    End Sub

    Private Sub txtDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged
        Try
            txtDate.Text = CDate(txtDate.Text.Trim)
            FillGrid()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
        End Try
    End Sub
    Private Sub FillGrid()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Try
            DataGrid1.DataSource = Maintenance.ElecTables.newVoltageCurrent(CDate(txtDate.Text))
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnSubmit_Clicks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit_Clicks.Click
        If ddlMinutes.SelectedItem.Text = "Select" Then
            lblMessage.Text = "Please select suitable Time value "
            Exit Sub
        ElseIf Val(txt66.Text) >= 75 Then
            lblMessage.Text = "KV value cannot be more than 75 ! "
            Exit Sub
        ElseIf Val(txtPower.Text) >= 40 Then
            lblMessage.Text = "MVA value cannot be more than 40 ! "
            Exit Sub
        End If
        Dim i As Integer = 0
        Try
            i = New Maintenance.Electrical().DailyVoltageCurrent(CDate(txtDate.Text), txt66.Text.Trim, txtPower.Text.Trim, ddlMinutes.SelectedItem.Value.Trim, txtCurrent.Text.Trim)

        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            If i <> 0 Then
                lblMessage.Text = "Record saved for  : '" & ddlMinutes.SelectedItem.Text & "' Hrs "
            Else
                lblMessage.Text &= "Record not saved for : '" & ddlMinutes.SelectedItem.Text & "' Hrs "
            End If
        End Try
        Clear()
        ddlMinutes.SelectedIndex = 0
        FillGrid()
    End Sub
    Private Sub Clear()
        txt66.Text = ""
        txtPower.Text = ""
        txtCurrent.Text = ""
    End Sub

    Private Sub ddlMinutes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMinutes.SelectedIndexChanged
        lblMessage.Text = ""
        Clear()
    End Sub
End Class
