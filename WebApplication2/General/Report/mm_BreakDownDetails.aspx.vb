Public Class mm_BreakDownDetails
    Inherits System.Web.UI.Page
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents btnReport As System.Web.UI.WebControls.Button
    Protected WithEvents ddlMachine As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnDetails As System.Web.UI.WebControls.Button
    Protected WithEvents BtnShow As System.Web.UI.WebControls.Button
    Protected WithEvents rblLocation As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rfvld2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtToDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents rfvld1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtFromDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
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
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        Panel1.Visible = True
        If Page.IsPostBack = False Then
            'Session("GROUP") = "MLDING"
            txtFromDate.Text = Now.Date
            txtToDate.Text = Now.Date
            Try
                GetMachines()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub

    Private Sub GetMachines()
        Dim ds As New DataSet()
        Try
            ds = RWF.tables.GetMachines(Session("GROUP"))
            ddlMachine.DataSource = ds.Tables(0)
            ddlMachine.DataTextField = ds.Tables(0).Columns(1).ColumnName
            ddlMachine.DataValueField = ds.Tables(0).Columns(0).ColumnName
            ddlMachine.DataBind()
            rblLocation.DataSource = ds.Tables(1)
            rblLocation.DataTextField = ds.Tables(1).Columns(0).ColumnName
            rblLocation.DataValueField = ds.Tables(1).Columns(0).ColumnName
            rblLocation.DataBind()
            rblLocation.SelectedIndex = 0
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            ds.Dispose()
            ds = Nothing
        End Try
    End Sub

    Private Sub BtnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShow.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=29832&user0=sa&password0=sadev123" &
            "&prompt0=" & Session("GROUP") & "" &
            "&prompt1=" & rblLocation.SelectedItem.Text & "" &
            "&prompt2=DateTime(" & CStr(CDate(txtFromDate.Text).Year) & "," & CStr(CDate(txtFromDate.Text).Month) & "," & CStr(CDate(txtFromDate.Text).Day) & ", 06, 00, 00)" &
            "&prompt3=DateTime(" & CStr(CDate(txtToDate.Text).Year) & "," & CStr(CDate(txtToDate.Text).Month) & "," & CStr(CDate(txtToDate.Text).Day) & ", 05, 59, 00)"
        Response.Redirect(strPathName)
    End Sub

    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Try
            txtFromDate.Text = CDate(txtFromDate.Text)
            txtToDate.Text = CDate(txtToDate.Text)
        Catch
            lblMessage.Text = "Enter valid date in 'dd/mm/yyyy' Format"
            txtToDate.Text = ""
            txtFromDate.Text = ""
            Exit Sub
        End Try
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Try
            DataGrid1.DataSource = RWF.tables.BreakDownMemo(Session("GROUP"), ddlMachine.SelectedItem.Value, CDate(txtFromDate.Text), CDate(txtToDate.Text))
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetails.Click
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Try
            DataGrid1.DataSource = RWF.tables.GroupWiseBreakDownDetails(Session("GROUP"), Trim(rblLocation.SelectedItem.Value), CDate(txtFromDate.Text), CDate(txtToDate.Text))
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If DataGrid1.Items.Count > 0 Then
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
                prevstate = Nothing
                tw = Nothing
                hw = Nothing
            End Try
        Else
            lblMessage.Text = "No Data in Grid to export !"
        End If
    End Sub

End Class
