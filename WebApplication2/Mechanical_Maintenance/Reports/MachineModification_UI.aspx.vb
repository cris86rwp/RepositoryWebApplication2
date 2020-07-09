Public Class MachineModification_UI
    Inherits System.Web.UI.Page
    Protected WithEvents btnReport As System.Web.UI.WebControls.Button
    Protected WithEvents cboMachineCode As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboLocation As System.Web.UI.WebControls.DropDownList
    Protected WithEvents rfv2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtToDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents rfv1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtFromDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList
    Shared themeValue As String
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
    Private Sub Page_PreInit(ByVal sender As Object, ByVal e As EventArgs)
        Page.Theme = themeValue
    End Sub

    Public Sub New()
        AddHandler PreInit, New EventHandler(AddressOf Page_PreInit)
    End Sub

    Protected Sub dd1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        themeValue = Dd1.SelectedItem.Value
        Response.Redirect(Request.Url.ToString())

    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Not Page.IsPostBack Then
            txtFromDate.Text = Now.Date
            txtToDate.Text = Now.Date
            'Session("group") = "W1"
            PopulateLocation()
            PopulateMachineCode()
        End If
    End Sub

    Private Sub PopulateLocation()
        Try
            ' cboLocation.DataSource = Maintenance.tables.Location("add", (Session("group")), "M")
            cboLocation.DataSource = Maintenance.tables.Location("add", "W1", "M")
            'cboLocation.DataSource = Maintenance.tables.PopulateLocation
            cboLocation.DataTextField = "Location"
            cboLocation.DataValueField = "code"
            cboLocation.DataBind()
            cboLocation.Items.Insert(0, "ALL")
            cboLocation.SelectedIndex = 0
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub PopulateMachineCode()
        Try
            cboMachineCode.DataSource = Maintenance.tables.PopulateMachineCode(cboLocation.SelectedItem.Value.Trim)
            cboMachineCode.DataTextField = "desc1"
            cboMachineCode.DataValueField = "machine_code"
            cboMachineCode.DataBind()
            cboMachineCode.Items.Insert(0, "ALL")
            cboMachineCode.SelectedIndex = 0
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub cboLocation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLocation.SelectedIndexChanged
        PopulateMachineCode()
    End Sub

    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim dt As Date
        Try
            dt = CDate(txtFromDate.Text)
        Catch
            lblMessage.Text = "Enter date in 'dd/mm/yyyy' Format"
            txtFromDate.Text = ""
        End Try

        Try
            dt = CDate(txtToDate.Text)
        Catch
            lblMessage.Text = "Enter date in 'dd/mm/yyyy' Format"
            txtToDate.Text = ""
        End Try
        If txtFromDate.Text = "" Then
            Exit Sub
        ElseIf txtToDate.Text = "" Then
            Exit Sub
        ElseIf cboLocation.SelectedItem.Text = "Select" Then
            lblMessage.Text = "Select Location Code"
            Exit Sub
        Else
            Dim strRptName, strRptFormula, strServer, strPathName, strRptNameWithPath As String

            strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=15729&user0=sa&password0=sadev123" &
                "&promptonrefresh=0" &
                "&prompt0=DateTime(" & CDate(txtFromDate.Text).Year & "," & CDate(txtFromDate.Text).Month & "," & CDate(txtFromDate.Text).Day & ", 0,0,0)" &
                "&prompt1=DateTime(" & CDate(txtToDate.Text).Year & "," & CDate(txtToDate.Text).Month & "," & CDate(txtToDate.Text).Day & ", 0,0,0)" &
                "&prompt2=" & Left(cboLocation.SelectedItem.Value.Trim, 2) & "" &
                "&prompt3=" & CStr(IIf((cboMachineCode.SelectedItem.Text.ToUpper <> "ALL"), cboMachineCode.SelectedItem.Value.Trim, "ALL")) & ""
            Response.Redirect(strPathName)
        End If
    End Sub
End Class
