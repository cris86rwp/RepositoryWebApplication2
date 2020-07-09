Public Class ms_BreakDownDetails_New
    Inherits System.Web.UI.Page
    Protected WithEvents txtFromDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents rfvld1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtToDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents rfvld2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents cboBD_Type As System.Web.UI.WebControls.DropDownList
    Protected WithEvents radProduction As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rdSelect As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents ddlLocation As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblMAchineCode As System.Web.UI.WebControls.Label
    Protected WithEvents ddlMachineCode As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents btnShowReport As System.Web.UI.WebControls.Button
    Protected WithEvents lblGrp As System.Web.UI.WebControls.Label
    Protected WithEvents txtWkDays As System.Web.UI.WebControls.TextBox
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnElecCranes As System.Web.UI.WebControls.Button
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents Button2 As System.Web.UI.WebControls.Button
    Protected WithEvents btnGrid As System.Web.UI.WebControls.Button
    Protected WithEvents txtTime As System.Web.UI.WebControls.TextBox
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
            DataGrid1.DataSource = Nothing
            DataGrid1.DataBind()
            lblGrp.Visible = False
            txtFromDate.Text = Now.Date
            txtToDate.Text = Now.Date
            ' Session("group") = "AC"
            If Session("group") = "RTSHOP" Then
                Session("group") = "MRTSHOP"
            End If
            lblGrp.Text = Session("group")
            txtTime.Text = "0"
            PopulateLocation()
            PopulateBreakDownTypes()
            PopulateMachineCode()
        End If
    End Sub
    Private Sub PopulateMachineCode()
        Try
            ddlMachineCode.DataSource = Maintenance.tables.PopulateMachineCode(ddlLocation.SelectedItem.Value.Trim)
            ddlMachineCode.DataTextField = "desc1"
            ddlMachineCode.DataValueField = "machine_code"
            ddlMachineCode.DataBind()
            ddlMachineCode.Items.Insert(0, "ALL")
            ddlMachineCode.SelectedIndex = 0
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub PopulateBreakDownTypes()
        Try
            cboBD_Type.DataSource = Maintenance.tables.CodeType
            cboBD_Type.DataTextField = "description"
            cboBD_Type.DataValueField = "code_type"
            cboBD_Type.DataBind()
            cboBD_Type.Items.Insert(0, "ALL")
            cboBD_Type.SelectedIndex = 0
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub PopulateLocation()
        Try
            'ddlLocation.DataSource = Maintenance.tables.PopulateLocation
            ddlLocation.DataSource = Maintenance.tables.ShopCode(lblGrp.Text)
            ddlLocation.DataTextField = "grp"
            ddlLocation.DataValueField = "code"
            ddlLocation.DataBind()
            ddlLocation.Items.Insert(0, "ALL")
            ddlLocation.SelectedIndex = 0
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub ddlLocation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlLocation.SelectedIndexChanged
        If rdSelect.SelectedIndex = 1 Then
            PopulateMachineCode()
        End If
    End Sub
    Private Sub rdSelect_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdSelect.SelectedIndexChanged
        If rdSelect.SelectedIndex = 1 Then
            ddlLocation.AutoPostBack = True
            lblMAchineCode.Visible = True
            ddlMachineCode.Visible = True
        Else
            ddlLocation.AutoPostBack = False
            lblMAchineCode.Visible = False
            ddlMachineCode.Visible = False
        End If
    End Sub
    Private Sub btnShowReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowReport.Click
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Dim dt As Date
        Dim i As Int16
        Try
            dt = CDate(txtFromDate.Text)
        Catch
            lblMessage.Text = "Enter date in 'dd/mm/yyyy' Format"
            txtFromDate.Text = ""
            Exit Sub
        End Try
        Try
            dt = CDate(txtToDate.Text)
            If Not (txtWkDays.Text.Trim = "0" Or txtWkDays.Text.Trim = "") Then
                If Val(txtWkDays.Text.Trim) > 0 Then
                    i = Val(txtWkDays.Text.Trim)
                Else
                    i = DateDiff(DateInterval.Day, CDate(txtFromDate.Text.Trim), CDate(txtToDate.Text.Trim))
                End If
            End If
        Catch
            lblMessage.Text = "Enter date in 'dd/mm/yyyy' Format"
            txtToDate.Text = ""
            Exit Sub
        End Try
        Dim strPathName As String
        'BreakDownDetailsNewReportWithPercent
        '            strPathName = "http:\\" & Server.MachineName & "\wap\mss\mechMaintenance\Reports\Formats\BreakDownDetailsNewReport.rpt?user0=report&password0=report"
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=8001&user0=sa&password0=sadev123"
        strPathName &= "&promptonrefresh=0&prompt0=" & lblGrp.Text.Trim & ""
        strPathName &= "&prompt1=DateTime(" & CDate(txtFromDate.Text).Year & "," & CDate(txtFromDate.Text).Month & "," & CDate(txtFromDate.Text).Day & ", 00, 00, 00)"
        strPathName &= "&prompt2=DateTime(" & CDate(txtToDate.Text).Year & "," & CDate(txtToDate.Text).Month & "," & CDate(txtToDate.Text).Day & ", 00, 00, 00)"
        strPathName &= "&prompt3=" & CStr(ddlLocation.SelectedItem.Value.Trim) & ""
        strPathName &= "&prompt4=" & CStr(IIf((ddlMachineCode.SelectedItem.Text.ToUpper <> "ALL"), ddlMachineCode.SelectedItem.Value.Trim, "ALL")) & ""
        strPathName &= "&prompt5=" & CStr("ALL") & ""
        strPathName &= "&prompt6=" & CStr(IIf((cboBD_Type.SelectedItem.Text.ToUpper <> "ALL"), cboBD_Type.SelectedItem.Value.Trim, "ALL")) & ""
        strPathName &= "&prompt7=" & radProduction.SelectedItem.Value.Trim & ""
        strPathName &= "&prompt8=" & Val(txtTime.Text.Trim) & ""
        strPathName &= "&prompt9=" & Val(i)
        Response.Redirect(strPathName)
        'End If

    End Sub

    Private Sub btnGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lblMessage.Text = ""
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Dim dt As Date
        Dim i As Int16
        Try
            dt = CDate(txtFromDate.Text)
        Catch
            lblMessage.Text = "Enter date in 'dd/mm/yyyy' Format"
            txtFromDate.Text = ""
            Exit Sub
        End Try
        Try
            dt = CDate(txtToDate.Text)
            If Not (txtWkDays.Text.Trim = "0" Or txtWkDays.Text.Trim = "") Then
                If Val(txtWkDays.Text.Trim) > 0 Then
                    i = Val(txtWkDays.Text.Trim)
                Else
                    i = DateDiff(DateInterval.Day, CDate(txtFromDate.Text.Trim), CDate(txtToDate.Text.Trim))
                End If
            End If
        Catch
            lblMessage.Text = "Enter date in 'dd/mm/yyyy' Format"
            txtToDate.Text = ""
            Exit Sub
        End Try
        Try
            DataGrid1.DataSource = Maintenance.tables.BreakDownMaintenaceDetailsWithPercent(lblGrp.Text.Trim, CDate(txtFromDate.Text), CDate(txtToDate.Text), ddlLocation.SelectedItem.Value.Trim, IIf((ddlMachineCode.SelectedItem.Text.ToUpper <> "ALL"), ddlMachineCode.SelectedItem.Value.Trim, "ALL"), IIf((cboBD_Type.SelectedItem.Text.ToUpper <> "ALL"), cboBD_Type.SelectedItem.Value.Trim, "ALL"), radProduction.SelectedItem.Value.Trim, Val(txtTime.Text.Trim), Val(i))
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnElecCranes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnElecCranes.Click
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Dim dt As Date
        Dim i As Int16
        Try
            dt = CDate(txtFromDate.Text)
        Catch
            lblMessage.Text = "Enter date in 'dd/mm/yyyy' Format"
            txtFromDate.Text = ""
            Exit Sub
        End Try
        Try
            dt = CDate(txtToDate.Text)
            If Not (txtWkDays.Text.Trim = "0" Or txtWkDays.Text.Trim = "") Then
                If Val(txtWkDays.Text.Trim) > 0 Then
                    i = Val(txtWkDays.Text.Trim)
                Else
                    i = DateDiff(DateInterval.Day, CDate(txtFromDate.Text.Trim), CDate(txtToDate.Text.Trim))
                End If
            End If
        Catch
            lblMessage.Text = "Enter date in 'dd/mm/yyyy' Format"
            txtToDate.Text = ""
            Exit Sub
        End Try
        Dim strPathName As String
        'BreakDownDetailsNewReportWithPercent
        '            strPathName = "http:\\" & Server.MachineName & "\wap\mss\mechMaintenance\Reports\Formats\BreakDownDetailsNewReport.rpt?user0=report&password0=report"
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?id=18257&apsuser=Administrator&apspassword=Cris@123&apsauthtype=secEnterprise&user0=sa&password0=sadev123"
        strPathName &= "&promptonrefresh=0&prompt0=" & lblGrp.Text.Trim & ""
        strPathName &= "&prompt1=DateTime(" & CDate(txtFromDate.Text).Year & "," & CDate(txtFromDate.Text).Month & "," & CDate(txtFromDate.Text).Day & ", 00, 00, 00)"
        strPathName &= "&prompt2=DateTime(" & CDate(txtToDate.Text).Year & "," & CDate(txtToDate.Text).Month & "," & CDate(txtToDate.Text).Day & ", 00, 00, 00)"
        strPathName &= "&prompt3=" & CStr(ddlLocation.SelectedItem.Value.Trim) & ""
        strPathName &= "&prompt4=" & CStr(IIf((ddlMachineCode.SelectedItem.Text.ToUpper <> "ALL"), ddlMachineCode.SelectedItem.Value.Trim, "ALL")) & ""
        strPathName &= "&prompt5=" & CStr("ALL") & ""
        strPathName &= "&prompt6=" & CStr(IIf((cboBD_Type.SelectedItem.Text.ToUpper <> "ALL"), cboBD_Type.SelectedItem.Value.Trim, "ALL")) & ""
        strPathName &= "&prompt7=" & radProduction.SelectedItem.Value.Trim & ""
        strPathName &= "&prompt8=" & Val(txtTime.Text.Trim) & ""
        strPathName &= "&prompt9=" & Val(i)
        Response.Redirect(strPathName)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
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

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        lblMessage.Text = ""
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Dim dt As Date
        Dim i As Int16
        Try
            dt = CDate(txtFromDate.Text)
        Catch
            lblMessage.Text = "Enter date in 'dd/mm/yyyy' Format"
            txtFromDate.Text = ""
            Exit Sub
        End Try
        Try
            dt = CDate(txtToDate.Text)
            If Not (txtWkDays.Text.Trim = "0" Or txtWkDays.Text.Trim = "") Then
                If Val(txtWkDays.Text.Trim) > 0 Then
                    i = Val(txtWkDays.Text.Trim)
                Else
                    i = DateDiff(DateInterval.Day, CDate(txtFromDate.Text.Trim), CDate(txtToDate.Text.Trim))
                End If
            End If
        Catch
            lblMessage.Text = "Enter date in 'dd/mm/yyyy' Format"
            txtToDate.Text = ""
            Exit Sub
        End Try
        Try
            DataGrid1.DataSource = Maintenance.tables.BreakDownMaintenaceElecCranes(CDate(txtFromDate.Text), CDate(txtToDate.Text))
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
End Class
